﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private Form form3;

        private CalendarService service;
        private string calendarId;

        public class CalendarData
        {
            public string CalendarId { get; set; }
            public string EventId { get; set; }
            public string CalanderItem { get; set; }
            public DateTime StratTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form1);

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form2);

            form3 = new Form3();
            form3.TopLevel = false;
            form3.Dock = DockStyle.Fill;
            formPanel.Controls.Add(form3);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;   //クリックされたボタンを取得

            //すべてのボタンの背景色を初期化
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;

            //クリックされたボタンの背景色を変更
            clickedButton.BackColor = Color.Red;

            //他のフォームを隠す
            form1.Hide();
            form2.Hide();
            form3.Hide();

            //クリックされたボタンに対応するフォームを表示
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
        private void SaveCalendarDataToFile(string calendarId, string eventId)
        {
            var data = new CalendarData
            {
                CalendarId = calendarId,
                EventId = eventId
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
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
                    var data = JsonConvert.DeserializeObject<CalendarData>(json);
                    calendarDataList.Add(data);
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
                SaveCalendarDataToFile(calendarId, null);
            }
            else
            {
                //カレンダーがすでに存在する場合、そのカレンダーのIDを取得
                calendarId = enTaskCalendar.Id;
            }

            //JSONファイルからカレンダーのデータを読み込む
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            // 取得したデータをリストに代入
            if (calendarDataList.Count > 0)
            {
                // カレンダーIDと予定IDがファイルに保存されている場合は、リストに代入
                calendarId = calendarDataList[0].CalendarId;
                string eventId = calendarDataList[0].EventId;
                string eventName = calendarDataList[0].CalanderItem;
                DateTime startTime = calendarDataList[0].StratTime;
                DateTime endTime = calendarDataList[0].EndTime;
            }
            else
            {
                //ファイルにデータが保存されていない場合は、新規作成してファイルに保存
                SaveCalendarDataToFile(calendarId, null);
            }

            //ボタンを非表示にする
            authBtn.Visible = false;

            //form1を表示する
            form1.Show();
        }

        private async Task<string> CreateEvent(string eventName, DateTime startTime, DateTime endTime)
        {
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
                // イベントの作成
                var createdEvent = await service.Events.Insert(newEvent, calendarId).ExecuteAsync();
                SaveCalendarDataToFile(calendarId, createdEvent.Id);
                return createdEvent.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予定の作成に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //カレンダーの削除
        private async Task DeleteEvent(string eventId)
        {
            if (service == null || string.IsNullOrEmpty(calendarId))
            {
                MessageBox.Show("カレンダーが正しく設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //イベントを削除
                await service.Events.Delete(calendarId, eventId).ExecuteAsync();

                //カレンダーIDとイベントIDが一致するデータをファイルから削除
                DeleteCalendarDataFromFile(calendarId, eventId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予定の削除に失敗しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //JSONファイルから削除
        private void DeleteCalendarDataFromFile(string calendarId, string eventId)
        {
            List<CalendarData> calendarDataList = GetCalendarDataFromFile();

            // カレンダーIDとイベントIDが一致するデータを削除
            var dataToDelete = calendarDataList.FirstOrDefault(data => data.CalendarId == calendarId && data.EventId == eventId);
            if (dataToDelete != null)
            {
                calendarDataList.Remove(dataToDelete);
                string updatedJson = JsonConvert.SerializeObject(calendarDataList, Formatting.Indented);
                File.WriteAllText("Calendar.json", updatedJson);
            }
        }

        //カレンダーの更新
        private async Task UpdateEvent(string eventId, string newEventName, DateTime newStartTime, DateTime newEndTime)
        {
            if (service == null || string.IsNullOrEmpty(calendarId))
            {
                MessageBox.Show("カレンダーが正しく設定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //イベントの取得
                var existingEvent = await service.Events.Get(calendarId, eventId).ExecuteAsync();

                //イベントの更新
                existingEvent.Summary = newEventName;
                existingEvent.Start.DateTime = newStartTime;
                existingEvent.End.DateTime = newEndTime;
                await service.Events.Update(existingEvent, calendarId, eventId).ExecuteAsync();

                // カレンダーのデータをファイルに更新
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
                dataToUpdate.StratTime = newStartTime;
                dataToUpdate.EndTime = newEndTime;
                string updatedJson = JsonConvert.SerializeObject(calendarDataList, Formatting.Indented);
                File.WriteAllText("Calendar.json", updatedJson);
            }
        }
    }
}