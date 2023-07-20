using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace EnTask
{
    public partial class Form2 : Form
    {
        public string itemText, targetTime, importance, category, details, achivement;
        private List<Data> listDatas = new List<Data>();
        public Form2()
        {
            InitializeComponent();
        }

        //新規作成処理
        private void button1_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm("", "00:00:00", "0", "選択してください", "", "0%");
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                Data newData = new Data()
                {
                    ItemText = editForm.ItemText,
                    TargetTime = editForm.TargetTime,
                    Importance = int.Parse(editForm.Importance),
                    Category = editForm.Category,
                    Details = editForm.Details,
                    Achievement = ""
                };

                listDatas.Add(newData);
                UpdateListView();
            }
        }

        //更新処理
        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                ListViewItem selectedItem = selectedItems[0];
                int selectedIndex = selectedItem.Index;

                Data selectedData = listDatas[selectedIndex];

                EditForm editForm = new EditForm(selectedData.ItemText, selectedData.TargetTime, selectedData.Importance.ToString(), selectedData.Category, selectedData.Details, selectedData.Achievement); // Achievement の値を渡します
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    selectedData.ItemText = editForm.ItemText;
                    selectedData.TargetTime = editForm.TargetTime;
                    selectedData.Importance = int.Parse(editForm.Importance);
                    selectedData.Category = editForm.Category;
                    selectedData.Details = editForm.Details;
                    selectedData.Achievement = editForm.Achievement;

                    UpdateListView();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listDatas = ListToDate();
        }

        //削除処理
        private void button3_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            if (selectedItems.Count > 0)
            {
                ListViewItem selectedItem = selectedItems[0];
                int selectedIndex = selectedItem.Index;

                listDatas.RemoveAt(selectedIndex);
                UpdateListView();
            }
        }

        //リストビューのアップデート
        public void UpdateListView()
        {
            listView1.Items.Clear();
            foreach (Data data in listDatas)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
            data.ItemText,
            data.TargetTime,
            data.Importance.ToString(),
            data.Category,
            data.Details,
            data.Achievement
                });
                listView1.Items.Add(item);
            }
        }

        public void updateList(string editItemText, string editTargetTime, string editImportance, string editCategory, string editDetails, string achievement)
        {
            // リストビューのデータを更新します。
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == editItemText)
                {
                    item.SubItems[1].Text = editTargetTime;
                    item.SubItems[2].Text = editImportance.ToString();
                    item.SubItems[3].Text = editCategory;
                    item.SubItems[4].Text = editDetails;
                    item.SubItems[5].Text = achievement;
                    break;
                }
            }

            // リストビューを更新します。
            listView1.Refresh();
        }
        // リストビューに新しい項目を追加する関数
        private void newList(string itemText, string targetTime, string importance, string category, string details, string achievement)
        {
            ListViewItem newItem = new ListViewItem(itemText);
            newItem.SubItems.Add(targetTime);
            newItem.SubItems.Add(importance);
            newItem.SubItems.Add(category);
            newItem.SubItems.Add(details);
            newItem.SubItems.Add(achievement);

            listView1.Items.Add(newItem);
        }

        private List<Data> ListToDate()
        {
            List<Data> dataList = new List<Data>();
            foreach (ListViewItem item in listView1.Items)
            {
                Data data = new Data
                {
                    ItemText = item.SubItems[0].Text,
                    TargetTime = item.SubItems[1].Text,
                    Importance = int.Parse(item.SubItems[2].Text),
                    Category = item.SubItems[3].Text,
                    Details = item.SubItems[4].Text,
                    Achievement = item.SubItems[5].Text
                };
                dataList.Add(data);
            }
            return dataList;
        }

    }
}
