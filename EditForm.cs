using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class EditForm : Form
    {
        private mainForm MainForm;
        private List<string> CategoryList;
        public string ItemText;
        public string TargetTime;
        public string Importance;
        public string Category;
        public string Details;
        public string Achievement;

        public EditForm(mainForm MainForm, List<string> CategoryList)
        {
            InitializeComponent();
            this.MainForm = MainForm;
            this.CategoryList = CategoryList;
        }

        public EditForm(string itemText, string targetTime, string importance, string category, string details, string achievement, List<string> CategoryList)
        {
            InitializeComponent();
            ItemText = itemText;
            TargetTime = targetTime;
            Importance = importance;
            Category = category;
            Details = details;
            if (ItemText != "") groupBox1.Text = ItemText + "の編集";
            Achievement = achievement;
            this.CategoryList = CategoryList;
            categoryBox.Items.Clear();
            foreach (var categoryList in this.CategoryList)
            {
                categoryBox.Items.Add(categoryList);
            }

        }

        //Load時の処理
        private void editFormLoad(object sender, EventArgs e)
        {
            //各
            itemTextBox.Text = ItemText;
            targetTimePick.Value = DateTime.ParseExact(TargetTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            importanceNum.Value = decimal.Parse(Importance);
            categoryBox.Text = Category;
            detailsTextBox.Text = Details;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //編集結果を取得
            ItemText = itemTextBox.Text;
            TargetTime = targetTimePick.Value.ToString("HH:mm:ss");
            Importance = ((int)importanceNum.Value).ToString();
            Category = categoryBox.Text;
            Details = detailsTextBox.Text;

            //Form2に編集結果を渡す
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            form2.updateList(ItemText, TargetTime, Importance, Category, Details, Achievement);

            //OKに設定
            this.DialogResult = DialogResult.OK;

            //EditFormを閉じる
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
