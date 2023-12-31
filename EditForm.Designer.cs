﻿namespace EnTask
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.targetTimeLabel = new System.Windows.Forms.Label();
            this.importanceLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.importanceNum = new System.Windows.Forms.NumericUpDown();
            this.targetTimePick = new System.Windows.Forms.DateTimePicker();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importanceNum)).BeginInit();
            this.SuspendLayout();
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(24, 51);
            this.itemTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(336, 23);
            this.itemTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detailsLabel);
            this.groupBox1.Controls.Add(this.categoryLabel);
            this.groupBox1.Controls.Add(this.targetTimeLabel);
            this.groupBox1.Controls.Add(this.importanceLabel);
            this.groupBox1.Controls.Add(this.itemLabel);
            this.groupBox1.Controls.Add(this.importanceNum);
            this.groupBox1.Controls.Add(this.targetTimePick);
            this.groupBox1.Controls.Add(this.categoryBox);
            this.groupBox1.Controls.Add(this.detailsTextBox);
            this.groupBox1.Controls.Add(this.itemTextBox);
            this.groupBox1.Location = new System.Drawing.Point(32, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(587, 290);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新規作成";
            // 
            // detailsLabel
            // 
            this.detailsLabel.Location = new System.Drawing.Point(22, 163);
            this.detailsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(78, 15);
            this.detailsLabel.TabIndex = 8;
            this.detailsLabel.Text = "詳細";
            // 
            // categoryLabel
            // 
            this.categoryLabel.Location = new System.Drawing.Point(207, 93);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(66, 16);
            this.categoryLabel.TabIndex = 7;
            this.categoryLabel.Text = "カテゴリー";
            // 
            // targetTimeLabel
            // 
            this.targetTimeLabel.Location = new System.Drawing.Point(22, 93);
            this.targetTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetTimeLabel.Name = "targetTimeLabel";
            this.targetTimeLabel.Size = new System.Drawing.Size(66, 16);
            this.targetTimeLabel.TabIndex = 6;
            this.targetTimeLabel.Text = "目標時間";
            // 
            // importanceLabel
            // 
            this.importanceLabel.Location = new System.Drawing.Point(388, 33);
            this.importanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.importanceLabel.Name = "importanceLabel";
            this.importanceLabel.Size = new System.Drawing.Size(52, 15);
            this.importanceLabel.TabIndex = 5;
            this.importanceLabel.Text = "重要度";
            // 
            // itemLabel
            // 
            this.itemLabel.Location = new System.Drawing.Point(22, 33);
            this.itemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(41, 15);
            this.itemLabel.TabIndex = 0;
            this.itemLabel.Text = "項目";
            // 
            // importanceNum
            // 
            this.importanceNum.Location = new System.Drawing.Point(389, 51);
            this.importanceNum.Margin = new System.Windows.Forms.Padding(4);
            this.importanceNum.Name = "importanceNum";
            this.importanceNum.Size = new System.Drawing.Size(140, 23);
            this.importanceNum.TabIndex = 4;
            // 
            // targetTimePick
            // 
            this.targetTimePick.CustomFormat = "HH:mm:ss";
            this.targetTimePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.targetTimePick.Location = new System.Drawing.Point(24, 113);
            this.targetTimePick.Margin = new System.Windows.Forms.Padding(4);
            this.targetTimePick.Name = "targetTimePick";
            this.targetTimePick.ShowUpDown = true;
            this.targetTimePick.Size = new System.Drawing.Size(158, 23);
            this.targetTimePick.TabIndex = 3;
            this.targetTimePick.Value = new System.DateTime(2023, 7, 17, 0, 0, 0, 0);
            // 
            // categoryBox
            // 
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(210, 113);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(140, 23);
            this.categoryBox.TabIndex = 2;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(24, 182);
            this.detailsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(536, 75);
            this.detailsTextBox.TabIndex = 1;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(421, 348);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(88, 29);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(531, 348);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 29);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 386);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditForm";
            this.Load += new System.EventHandler(this.editFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importanceNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker targetTimePick;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.NumericUpDown importanceNum;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label importanceLabel;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label targetTimeLabel;
    }
}