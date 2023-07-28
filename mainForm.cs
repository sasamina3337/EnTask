using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Resolvers;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Newtonsoft.Json;

namespace EnTask
{
    public partial class mainForm : Form
    {
        private Form form1;
        private Form form2;
        public Form form3 { get; private set; }

        public CalendarService service;
        public string calendarId;

        public class CalendarData
        {
            public string CalendarId { get; set; }
            public string EventId { get; set; }
            public string CalanderItem { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            form1 = new Form1(this);
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form1);

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form2);

            form3 = new Form3(this);
            form3.TopLevel = false;
            form3.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form3);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;

            clickedButton.BackColor = Color.Red;

            form1.Hide();
            form2.Hide();
            form3.Hide();

            if (clickedButton == button1)
            {
                form1.Show();
            }
            else if (clickedButton == button2)
            {
                form2.Show();
            }
            else if (clickedButton == button3)
            {
                form3.Show();
            }
        }

        //カレンダーIDと予定IDをファイルに保存
        private void SaveCalendarDataToFile(string calendarId, string eventId, string itemName, DateTime startTime, DateTime endTime)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            if (calendarDataList == null)
            {
                calendarDataList = new List<CalendarData>();
            }

            var data = new CalendarData
            {
                CalendarId = calendarId,
                EventId = eventId,
                CalanderItem = itemName,
                StartTime = startTime,
                EndTime = endTime
            };
            calendarDataList.Add(data);

            string json = JsonConvert.SerializeObject(calendarDataList, Formatting.Indented);
            File.WriteAllText("Calendar.json", json);
        }

        //ファイルからカレンダーのデータを読み込む
        private List<CalendarData> GetCalendarDataFromFile()
        {
            List<CalendarData> calendarDataList = new List<CalendarData>();

            if (File.Exists("Calendar.json"))
            {
                try
                {
                    string json = File.ReadAllText("Calendar.json");
                    calendarDataList = JsonConvert.DeserializeObject<List<CalendarData>>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("カレンダーデータの読み込みに失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return calendarDataList;
        }

        private async void authBtn_Click(object sender, EventArgs e)
        {
            string credentialPath = "client_secret.json";

            //ユーザー認証を実行
            UserCredential credential;
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                var secrets = GoogleClientSecrets.FromStream(stream);
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    secrets.Secrets,
                    new[] { CalendarService.Scope.Calendar },
                    "user",
                    CancellationToken.None
                );
            }

            //APIのクライアントを初期化
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "EnTask"
            });

            Console.WriteLine(service);

            //カレンダーが存在するか確認
            string calendarName = "EnTask";
            var calendarList = await service.CalendarList.List().ExecuteAsync();
            var enTaskCalendar = calendarList.Items.FirstOrDefault(c => c.Summary == calendarName);

            if (enTaskCalendar == null)
            {
                //新しくカレンダーを作成
                var newCalendar = new Calendar { Summary = calendarName };
                var createdCalendar = await service.Calendars.Insert(newCalendar).ExecuteAsync();
                calendarId = createdCalendar.Id;

                //カレンダーIDをファイルに保存
                SaveCalendarIdToFile(calendarId);
            }
            else
            {
                //カレンダーがすでに存在する場合、そのカレンダーのIDを取得
                calendarId = GetCalendarIdFromFile();
            }

            //JSONファイルからカレンダーのデータを読み込む
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            if (calendarDataList.Count > 0)
            {
                //カレンダーIDと予定IDがファイルに保存されている場合は、リストに代入
            }
            else
            {
                //ファイルにデータが保存されていない場合は、新規作成してファイルに保存
                SaveCalendarDataToFile(calendarId, null, null, DateTime.MinValue, DateTime.MinValue);
            }

            authBtn.Visible = false;
            gPic.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            form1.Show();
        }

        // カレンダーIDをファイルに保存
        private void SaveCalendarIdToFile(string calendarId)
        {
            File.WriteAllText("CalendarId.json", calendarId);
        }

        // JSONファイルからカレンダーIDを読み込む
        private string GetCalendarIdFromFile()
        {
            if (File.Exists("CalendarId.json"))
            {
                return File.ReadAllText("CalendarId.json");
            }
            return null;
        }


        //予定の新規作成
        public async Task<string> CreateEvent(string eventName, DateTime startTime, DateTime endTime)
        {
            calendarId = GetCalendarIdFromFile();
            if (service == null || string.IsNullOrEmpty(calendarId))
            {
                MessageBox.Show("カレンダーが正しく設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Event newEvent = new Event
            {
                Summary = eventName,
                Start = new EventDateTime { DateTime = startTime, TimeZone = "Asia/Tokyo" },
                End = new EventDateTime { DateTime = endTime, TimeZone = "Asia/Tokyo" }
            };

            try
            {
                //予定の作成
                var createdEvent = await service.Events.Insert(newEvent, calendarId).ExecuteAsync();
                SaveCalendarDataToFile(calendarId, createdEvent.Id, eventName, startTime, endTime);
                return createdEvent.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予定の作成に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //予定の削除
        public async Task DeleteEvent(string eventName, DateTime startTime)
        {
            if (service == null || string.IsNullOrEmpty(calendarId))
            {
                MessageBox.Show("カレンダーが正しく設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // イベント名と開始時刻が一致するイベントの情報を取得
                string eventId = GetEventIdFromFile(eventName, startTime);
                if (string.IsNullOrEmpty(eventId))
                {
                    MessageBox.Show("指定されたイベントが見つかりません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Google Calendarからイベントを削除
                await service.Events.Delete(calendarId, eventId).ExecuteAsync();

                // カレンダーデータファイルから削除
                DeleteCalendarDataFromFile(eventName, startTime);

            }
            catch (Exception ex)
            {
                MessageBox.Show("予定の削除に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GetEventIdFromFile(string eventName, DateTime startTime)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            // イベント名と開始時刻が一致するデータを検索してイベントIDを取得
            var eventData = calendarDataList.FirstOrDefault(data => data.CalanderItem == eventName && data.StartTime.Date == startTime.Date);
            if (eventData != null)
            {
                return eventData.EventId;
            }

            return null;
        }


        //JSONファイルから削除
        private void DeleteCalendarDataFromFile(string eventName, DateTime startTime)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();
            var eventData = calendarDataList.FirstOrDefault(data => data.CalanderItem == eventName && data.StartTime.Date == startTime.Date);
            if (eventData != null)
            {
                calendarDataList.Remove(eventData);
                string updatedJson = JsonConvert.SerializeObject(calendarDataList, Formatting.Indented);
                File.WriteAllText("Calendar.json", updatedJson);
            }
        }


        //予定の更新
        public async Task UpdateEvent(string eventId, string newEventName, DateTime newStartTime, DateTime newEndTime)
        {
            if (service == null || string.IsNullOrEmpty(calendarId))
            {
                MessageBox.Show("カレンダーが正しく設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //予定の取得
                var existingEvent = await service.Events.Get(calendarId, eventId).ExecuteAsync();

                //予定の更新
                existingEvent.Summary = newEventName;
                existingEvent.Start.DateTime = newStartTime;
                existingEvent.End.DateTime = newEndTime;
                await service.Events.Update(existingEvent, calendarId, eventId).ExecuteAsync();

                UpdateCalendarDataToFile(eventId, newEventName, newStartTime, newEndTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予定の更新に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // カレンダーのデータをファイルに更新
        private void UpdateCalendarDataToFile(string eventId, string newEventName, DateTime newStartTime, DateTime newEndTime)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            //カレンダーIDとイベントIDが一致するデータを検索して更新
            var dataToUpdate = calendarDataList.FirstOrDefault(data => data.EventId == eventId);
            if (dataToUpdate != null)
            {
                dataToUpdate.CalanderItem = newEventName;
                dataToUpdate.StartTime = newStartTime;
                dataToUpdate.EndTime = newEndTime;
                string updatedJson = JsonConvert.SerializeObject(calendarDataList, Formatting.Indented);
                File.WriteAllText("Calendar.json", updatedJson);
            }
        }

        public List<CalendarData> GetCalendarEventsForDate(DateTime date)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();
            List<CalendarData> eventsForDate = calendarDataList.Where(data => data.StartTime.Date == date.Date).ToList();
            return eventsForDate;
        }
    }
}
