using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
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
        private mainForm MainForm;
        private string todoListFilePath = "ToDoList.json";
        public string itemText, targetTime, importance, category, details, achivement;
        public List<Data> listDatas = new List<Data>();
        // カテゴリーリスト
        List<string> CategoryList = new List<string>();

        public Form2(mainForm MainForm)
        {
            InitializeComponent();
            this.MainForm = MainForm;
        }

        //新規作成処理
        private void button1_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm("", "00:00:00", "0", "選択してください", "", "0%", CategoryList);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // リストに新規データを追加
                addNewData(editForm.ItemText, editForm.TargetTime, editForm.Importance, editForm.Category, editForm.Details, editForm.Achievement);
            }
        }

        public void addNewData(string itemText, string targetTime, string importance, string category, string details, string achievement)
        {
            Data newData = new Data()
            {
                ItemText = itemText,
                TargetTime = targetTime,
                Importance = int.Parse(importance),
                Category = category,
                Details = details,
                Achievement = achievement
            };

            listDatas.Add(newData);
            UpdateListView();
            SaveToDoListData();
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

                EditForm editForm = new EditForm(selectedData.ItemText, selectedData.TargetTime, selectedData.Importance.ToString(), selectedData.Category, selectedData.Details, selectedData.Achievement, CategoryList);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    selectedData.ItemText = editForm.ItemText;
                    selectedData.TargetTime = editForm.TargetTime;
                    selectedData.Importance = int.Parse(editForm.Importance);
                    selectedData.Category = editForm.Category;
                    selectedData.Details = editForm.Details;
                    selectedData.Achievement = editForm.Achievement;

                    UpdateListView();
                    SaveToDoListData();
                }
            }
        }

        //ロードイベント
        private void Form2_Load(object sender, EventArgs e)
        {
            listDatas = ListToDate();
            LoadToDoListData();
            UpdateListView();
            ((Form1)MainForm.form1).UpdateForm();
            MainForm.eventEdit.UpdateForm();
            categoryToFileList();
            ListInBox();

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
                SaveToDoListData();
            }
        }

        public void UpdateListView()
        {
            listView1.Items.Clear();
            UpdateAchievementPercentage();

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

        private void LoadToDoListData()
        {
            if (File.Exists(todoListFilePath))
            {
                string jsonData = File.ReadAllText(todoListFilePath);
                listDatas = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            }
            else
            {
                listDatas = new List<Data>();
            }
        }

        //カテゴリー登録
        private void button4_Click(object sender, EventArgs e)
        {
            string newCategory = categoryTextBox.Text;
            if (!string.IsNullOrEmpty(newCategory))
            {
                //リストに追加
                CategoryList.Add(newCategory);

                //JSONファイルに保存
                File.WriteAllText("Category.json", JsonConvert.SerializeObject(CategoryList));

                //リストボックスに追加
                categoryListBox.Items.Add(newCategory);

                //テキストボックスを空にする
                categoryTextBox.Clear();
            }
        }

        //カテゴリー削除
        private void button5_Click(object sender, EventArgs e)
        {
            //選択されていない場合
            if (categoryListBox.SelectedIndex == -1)
            {
                return;
            }

            string selectedCategory = categoryListBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                //リストから削除
                CategoryList.Remove(selectedCategory);

                //JSONファイルに保存
                File.WriteAllText("Category.json", JsonConvert.SerializeObject(CategoryList));

                //リストボックスから削除
                categoryListBox.Items.Remove(selectedCategory);
            }
        }

        // ToDoリストデータをファイルに保存する
        private void SaveToDoListData()
        {
            string jsonData = JsonConvert.SerializeObject(listDatas);
            File.WriteAllText(todoListFilePath, jsonData);
        }

        public void updateList(string editItemText, string editTargetTime, string editImportance, string editCategory, string editDetails, string achievement)
        {
            foreach (Data data in listDatas)
            {
                if (data.ItemText == editItemText)
                {
                    data.TargetTime = editTargetTime;
                    data.Importance = int.Parse(editImportance);
                    data.Category = editCategory;
                    data.Details = editDetails;
                    data.Achievement = achievement;
                    break;
                }
            }

            UpdateListView();
            SaveToDoListData();
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

        private void UpdateAchievementPercentage()
        {
            foreach (Data data in listDatas)
            {
                // 同じ名前の項目をフィルタリング
                var sameNameItems = listDatas.Where(item => item.ItemText == data.ItemText).ToList();

                // 同じ名前の項目の達成時間の合計を計算
                TimeSpan totalAchievedTime = TimeSpan.Zero;
                foreach (var item in sameNameItems)
                {
                    TimeSpan achievedTime;
                    if (TimeSpan.TryParse(item.Achievement, out achievedTime))
                    {
                        totalAchievedTime += achievedTime;
                    }
                }

                // 達成度を計算して設定
                int itemCount = sameNameItems.Count;
                if (itemCount > 0)
                {
                    int achievementPercentage = (int)(totalAchievedTime.TotalMinutes / (itemCount * TimeSpan.FromHours(24).TotalMinutes) * 100);
                    data.Achievement = achievementPercentage.ToString() + "%";
                }
            }
        }

        //JSONを読み込んでカテゴリーリストに格納
        void categoryToFileList()
        {
            //ファイルが存在しない場合
            if (!File.Exists("Category.json"))
            {
                File.Create("Category.json").Close();
                CategoryList = new List<string>();
            }
            else
            {
                //ファイルが存在する場合
                string json = File.ReadAllText("Category.json");
                CategoryList = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
            }
        }

        //カテゴリーリストをcategoryListBoxに入れ込む
        void ListInBox()
        {
            categoryListBox.Items.Clear();
            foreach (string category in CategoryList)
            {
                categoryListBox.Items.Add(category);
            }
        }


    }
}
