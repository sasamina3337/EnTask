namespace EnTask
{
    partial class mainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.authBtn = new System.Windows.Forms.Button();
            this.gPic = new System.Windows.Forms.PictureBox();
            this.menuPanel.SuspendLayout();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuPanel.Controls.Add(this.button3);
            this.menuPanel.Controls.Add(this.button2);
            this.menuPanel.Controls.Add(this.button1);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 450);
            this.menuPanel.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(0, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "カレンダー";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.menu_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(0, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "ToDoリスト";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.menu_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "メイン";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.menu_Click);
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.gPic);
            this.formPanel.Controls.Add(this.authBtn);
            this.formPanel.Location = new System.Drawing.Point(206, 12);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(582, 426);
            this.formPanel.TabIndex = 0;
            // 
            // authBtn
            // 
            this.authBtn.Location = new System.Drawing.Point(194, 183);
            this.authBtn.Name = "authBtn";
            this.authBtn.Size = new System.Drawing.Size(200, 48);
            this.authBtn.TabIndex = 0;
            this.authBtn.Text = "認証ボタン";
            this.authBtn.UseVisualStyleBackColor = true;
            this.authBtn.Click += new System.EventHandler(this.authBtn_Click);
            // 
            // gPic
            // 
            this.gPic.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gPic.Image = global::EnTask.Properties.Resources.google;
            this.gPic.Location = new System.Drawing.Point(140, 183);
            this.gPic.Name = "gPic";
            this.gPic.Size = new System.Drawing.Size(48, 48);
            this.gPic.TabIndex = 1;
            this.gPic.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "mainForm";
            this.Text = "EnTask";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button authBtn;
        private System.Windows.Forms.PictureBox gPic;
    }
}

