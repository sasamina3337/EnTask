using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using EnTask;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnTask
{
    public partial class Form3 : Form
    {
        public TimeSpan achieveTime;
        public DateTime pickDate;
        private mainForm mainFormInstance;

        public void LoadCalendarData()
        {
            //mainFormの関数を呼び出して選択した日付のカレンダーイベントを取得
            List<EnTask.mainForm.CalendarData> calendarDataList = mainFormInstance.GetCalendarEventsForDate(pickDate);

            //listViewの項目をクリア
            listView.Items.Clear();

            //listViewにカレンダーイベントを表示
            foreach (var calendarData in calendarDataList)
            {
                //達成時間を計算する
                AchieveTimeSpan(calendarData.StratTime, calendarData.EndTime);

                //イベントデータからListViewItemを作成
                ListViewItem item = new ListViewItem(calendarData.CalanderItem);
                item.SubItems.Add(calendarData.StratTime.ToString("HH:mm"));
                item.SubItems.Add(calendarData.EndTime.ToString("HH:mm"));
                item.SubItems.Add(achieveTime.ToString(@"hh\:mm"));

                listView.Items.Add(item);
            }
        }

        public Form3(mainForm mainFormInstance)
        {
            InitializeComponent();
            this.mainFormInstance = mainFormInstance;
            dateTimePicker.Value = DateTime.Now;
            LoadCalendarData();
        }

        private void dateChange(object sender, EventArgs e)
        {
            pickDate = dateTimePicker.Value;
            LoadCalendarData();
        }

        private void AchieveTimeSpan(DateTime startTime, DateTime endTime)
        {
            achieveTime = endTime - startTime;
        }

        //カレンダーの新規作成
        private void button1_Click(object sender, EventArgs e)
        {
            //EventEditフォームを新規作成するために開く
            EventEdit eventEditForm = new EventEdit(mainFormInstance, this);
            eventEditForm.ShowDialog();

            LoadCalendarData();
        }

        //カレンダーの修正
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                //選択されたイベントのデータを取得
                string eventName = listView.SelectedItems[0].Text;
                DateTime startTime = DateTime.ParseExact(listView.SelectedItems[0].SubItems[1].Text, "HH:mm", null);
                DateTime endTime = DateTime.ParseExact(listView.SelectedItems[0].SubItems[2].Text, "HH:mm", null);

                //EventEditフォームを開く
                EventEdit eventEditForm = new EventEdit(mainFormInstance, this, eventName, startTime, endTime);
                eventEditForm.ShowDialog();

                LoadCalendarData();
            }
        }

        //カレンダーの削除
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                //選択されたイベントのデータを取得
                string eventName = listView.SelectedItems[0].Text;
                DateTime startTime = DateTime.ParseExact(listView.SelectedItems[0].SubItems[1].Text, "HH:mm", null);

                //イベントを削除
                mainFormInstance.DeleteEvent(eventName, startTime);

                LoadCalendarData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadCalendarData();
        }
    }
}
