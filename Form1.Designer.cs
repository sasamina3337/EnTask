namespace EnTask
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timerLabel = new System.Windows.Forms.Label();
            this.charcterPIcBox = new System.Windows.Forms.PictureBox();
            this.timerBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.speakPictureBox = new System.Windows.Forms.PictureBox();
            this.speakLabel = new System.Windows.Forms.Label();
            this.timerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.charcterPIcBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speakPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timerLabel.Location = new System.Drawing.Point(347, 125);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(123, 30);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "00:00:00";
            // 
            // charcterPIcBox
            // 
            this.charcterPIcBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.charcterPIcBox.Image = global::EnTask.Properties.Resources.state4;
            this.charcterPIcBox.Location = new System.Drawing.Point(74, 54);
            this.charcterPIcBox.Name = "charcterPIcBox";
            this.charcterPIcBox.Size = new System.Drawing.Size(200, 200);
            this.charcterPIcBox.TabIndex = 1;
            this.charcterPIcBox.TabStop = false;
            // 
            // timerBtn
            // 
            this.timerBtn.Location = new System.Drawing.Point(468, 231);
            this.timerBtn.Name = "timerBtn";
            this.timerBtn.Size = new System.Drawing.Size(75, 23);
            this.timerBtn.TabIndex = 2;
            this.timerBtn.Text = "start";
            this.timerBtn.UseVisualStyleBackColor = true;
            this.timerBtn.Click += new System.EventHandler(this.timerBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timerTick);
            // 
            // speakPictureBox
            // 
            this.speakPictureBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.speakPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speakPictureBox.Location = new System.Drawing.Point(74, 310);
            this.speakPictureBox.Name = "speakPictureBox";
            this.speakPictureBox.Size = new System.Drawing.Size(429, 78);
            this.speakPictureBox.TabIndex = 1;
            this.speakPictureBox.TabStop = false;
            // 
            // speakLabel
            // 
            this.speakLabel.AutoSize = true;
            this.speakLabel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.speakLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.speakLabel.Location = new System.Drawing.Point(163, 329);
            this.speakLabel.Name = "speakLabel";
            this.speakLabel.Size = new System.Drawing.Size(259, 40);
            this.speakLabel.TabIndex = 0;
            this.speakLabel.Text = "あなたは堕落した1日をすごしています。\r\nもう少し頑張りましょう。";
            this.speakLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerComboBox
            // 
            this.timerComboBox.FormattingEnabled = true;
            this.timerComboBox.Location = new System.Drawing.Point(330, 231);
            this.timerComboBox.Name = "timerComboBox";
            this.timerComboBox.Size = new System.Drawing.Size(121, 23);
            this.timerComboBox.TabIndex = 3;
            this.timerComboBox.Text = "選択してください";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "項目名";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerComboBox);
            this.Controls.Add(this.speakLabel);
            this.Controls.Add(this.speakPictureBox);
            this.Controls.Add(this.timerBtn);
            this.Controls.Add(this.charcterPIcBox);
            this.Controls.Add(this.timerLabel);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.charcterPIcBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speakPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.PictureBox charcterPIcBox;
        private System.Windows.Forms.Button timerBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox speakPictureBox;
        private System.Windows.Forms.Label speakLabel;
        private System.Windows.Forms.ComboBox timerComboBox;
        private System.Windows.Forms.Label label1;
    }
}