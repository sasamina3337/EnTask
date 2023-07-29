using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace EnTask
{
    public partial class Form1 : Form
    {
        private mainForm MainForm;
        public string DateItem;
        public DateTime StartTime;
        public DateTime EndTime;

        public Boolean timerEnable = true;

        public int timeCul, minCul, secCul;
        public Form1(mainForm mainFormInstance)
        {
            InitializeComponent();
            MainForm = mainFormInstance;
            timeCul = 0;
            minCul = 0;
            secCul = 0;

        }

        private void timerTick(object sender, EventArgs e)
        {
            string secSpace, minSpace, timeSpace;
            secSpace = "";
            minSpace = "";
            timeSpace = "";

            secCul++;
            if(secCul >= 60)
            {
                minCul = minCul + secCul / 60;
                secCul %= 60;
            }
            if (minCul >= 60)
            {
                timeCul = timeCul　+ minCul / 60;
                minCul %= 60;
            }
            if (secCul < 10) secSpace = "0";
            if (minCul < 10) minSpace = "0";
            if (timeCul < 10) timeSpace = "0";
            timerLabel.Text =  timeSpace + timeCul + ":" + minSpace  + minCul + ":" + secSpace + secCul;
        }

        private async void timerBtn_Click(object sender, EventArgs e)
        {
            if (timerEnable)
            {
                timeCul = 0;
                minCul = 0;
                secCul = 0;
                timerLabel.Text = "00:00:00";
                timer.Start();
                timerEnable = false;
                timerBtn.Text = "stop";
                StartTime = DateTime.Now;
            }
            else
            {
                timer.Stop();
                timerEnable = true;
                timerBtn.Text = "start";
                DateItem = timerComboBox.Text;
                EndTime = DateTime.Now;

                MainForm.CreateEvent(DateItem, StartTime, EndTime);

                await Task.Delay(2000);

                Form3 form3 = (Form3)MainForm.form3;
                form3.LoadCalendarData();
            }
        }

        public void UpdateForm()
        {
            timerComboBox.Items.Clear();
            foreach (var data in ((Form2)MainForm.form2).listDatas)
            {
                timerComboBox.Items.Add(data.ItemText);
            }
        }


    }
}
