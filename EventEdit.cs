﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnTask
{
    public partial class EventEdit : Form
    {
        private mainForm mainFormInstance;
        private Form3 form3Instance;
        private string eventName;
        private DateTime startTime;
        private DateTime endTime;

        public EventEdit(mainForm mainFormInstance, Form3 form3Instance)
        {
            InitializeComponent();
            this.mainFormInstance = mainFormInstance;
            this.form3Instance = form3Instance;
            InitializeDateTimePickers();
        }

        public EventEdit(mainForm mainFormInstance, Form3 form3Instance, string eventName, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            this.mainFormInstance = mainFormInstance;
            this.form3Instance = form3Instance;
            this.eventName = eventName;
            this.startTime = startTime;
            this.endTime = endTime;
            InitializeDateTimePickers();

            eventNameTextBox.Text = eventName;
            startTimePicker.Value = startTime;
            endTimePicker.Value = endTime;
        }


        private async void OK_Click(object sender, EventArgs e)
        {
            string newEventName = eventNameTextBox.Text;
            DateTime newStartTime = startTimePicker.Value;
            DateTime newEndTime = endTimePicker.Value;

            if (!string.IsNullOrEmpty(eventName) && eventName != newEventName)
            {
                //イベントを更新
                mainFormInstance.UpdateEvent(eventName, newEventName, newStartTime, newEndTime);
            }
            else
            {
                //イベントを作成
                mainFormInstance.CreateEvent(newEventName, newStartTime, newEndTime);
            }

            this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //開始日時が変わったら
        private void statDateChange(object sender, EventArgs e)
        {
            // startTimePickerとstartDatePickerを同期させる
            startTimePicker.Value = new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day,
                                                  startTimePicker.Value.Hour, startTimePicker.Value.Minute, startTimePicker.Value.Second);
        }

        //終了時刻の日時が変わった時
        private void endTimeChange(object sender, EventArgs e)
        {
            // endTimePickerとendDatePickerを同期させる
            endTimePicker.Value = new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day,
                                                endTimePicker.Value.Hour, endTimePicker.Value.Minute, endTimePicker.Value.Second);
        }

        private void InitializeDateTimePickers()
        {
            startDatePicker.ValueChanged += (sender, e) =>
            {
                startTimePicker.Value = new DateTime(startDatePicker.Value.Year, startDatePicker.Value.Month, startDatePicker.Value.Day,
                                                      startTimePicker.Value.Hour, startTimePicker.Value.Minute, startTimePicker.Value.Second);
            };

            endDatePicker.ValueChanged += (sender, e) =>
            {
                endTimePicker.Value = new DateTime(endDatePicker.Value.Year, endDatePicker.Value.Month, endDatePicker.Value.Day,
                                                    endTimePicker.Value.Hour, endTimePicker.Value.Minute, endTimePicker.Value.Second);
            };

            startTimePicker.ValueChanged += (sender, e) =>
            {
                startDatePicker.Value = startTimePicker.Value.Date;
            };

            endTimePicker.ValueChanged += (sender, e) =>
            {
                endDatePicker.Value = endTimePicker.Value.Date;
            };
        }
    }
}