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
        public Boolean timerEnable = true;

        public int timeCul, minCul, secCul;
        public Form1()
        {
            InitializeComponent();
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
                minCul = secCul / 60;
                secCul %= 60;
            }
            if (minCul >= 60)
            {
                timeCul = minCul / 60;
                minCul %= 60;
            }
            if (secCul < 10) secSpace = "0";
            if (minCul < 10) minSpace = "0";
            if (timeCul < 10) timeSpace = "0";
            timerLabel.Text =  timeSpace + timeCul + ":" + minSpace  + minCul + ":" + secSpace + secCul;
        }

        private void timerBtn_Click(object sender, EventArgs e)
        {
            if (timerEnable)
            {
                timer.Start();
                timerEnable = false;
                timerBtn.Text = "stop";
            }

            else
            {
                timer.Stop();
                timerEnable = true;
                timerBtn.Text = "start";
            }
        }
    }
}
