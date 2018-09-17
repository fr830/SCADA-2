namespace TestStation
{
    partial class DataLogForm
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
            this.Txt_LogTimer = new System.Windows.Forms.TextBox();
            this.Btn_DataStartLog = new System.Windows.Forms.Button();
            this.Btn_DataLogStop = new System.Windows.Forms.Button();
            this.CB_Station = new System.Windows.Forms.CheckBox();
            this.CB_Unit = new System.Windows.Forms.CheckBox();
            this.Btn_LogOut = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Txt_UnitDataPath = new System.Windows.Forms.TextBox();
            this.Txt_StationDataPath = new System.Windows.Forms.TextBox();
            this.Btn_StationFolderSelect = new System.Windows.Forms.Button();
            this.Btn_UnitFolderSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_LogTimer
            // 
            this.Txt_LogTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_LogTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_LogTimer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_LogTimer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_LogTimer.Location = new System.Drawing.Point(195, 104);
            this.Txt_LogTimer.Name = "Txt_LogTimer";
            this.Txt_LogTimer.Size = new System.Drawing.Size(91, 27);
            this.Txt_LogTimer.TabIndex = 5;
            this.Txt_LogTimer.Text = "1000";
            this.Txt_LogTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_LogTimer.TextChanged += new System.EventHandler(this.Txt_LogTimer_TextChanged);
            // 
            // Btn_DataStartLog
            // 
            this.Btn_DataStartLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_DataStartLog.FlatAppearance.BorderSize = 0;
            this.Btn_DataStartLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_DataStartLog.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_DataStartLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_DataStartLog.Location = new System.Drawing.Point(195, 149);
            this.Btn_DataStartLog.Name = "Btn_DataStartLog";
            this.Btn_DataStartLog.Size = new System.Drawing.Size(91, 46);
            this.Btn_DataStartLog.TabIndex = 4;
            this.Btn_DataStartLog.Tag = "連接";
            this.Btn_DataStartLog.Text = "開始";
            this.Btn_DataStartLog.UseVisualStyleBackColor = false;
            this.Btn_DataStartLog.Click += new System.EventHandler(this.Btn_DataStartLog_Click);
            // 
            // Btn_DataLogStop
            // 
            this.Btn_DataLogStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_DataLogStop.Enabled = false;
            this.Btn_DataLogStop.FlatAppearance.BorderSize = 0;
            this.Btn_DataLogStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_DataLogStop.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_DataLogStop.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_DataLogStop.Location = new System.Drawing.Point(308, 149);
            this.Btn_DataLogStop.Name = "Btn_DataLogStop";
            this.Btn_DataLogStop.Size = new System.Drawing.Size(91, 46);
            this.Btn_DataLogStop.TabIndex = 4;
            this.Btn_DataLogStop.Tag = "連接";
            this.Btn_DataLogStop.Text = "結束";
            this.Btn_DataLogStop.UseVisualStyleBackColor = false;
            this.Btn_DataLogStop.Click += new System.EventHandler(this.Btn_DataLogStop_Click);
            // 
            // CB_Station
            // 
            this.CB_Station.AutoSize = true;
            this.CB_Station.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_Station.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CB_Station.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.CB_Station.Location = new System.Drawing.Point(82, 62);
            this.CB_Station.Name = "CB_Station";
            this.CB_Station.Size = new System.Drawing.Size(94, 29);
            this.CB_Station.TabIndex = 6;
            this.CB_Station.Text = "試車站";
            this.CB_Station.UseVisualStyleBackColor = true;
            // 
            // CB_Unit
            // 
            this.CB_Unit.AutoSize = true;
            this.CB_Unit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_Unit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CB_Unit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.CB_Unit.Location = new System.Drawing.Point(192, 62);
            this.CB_Unit.Name = "CB_Unit";
            this.CB_Unit.Size = new System.Drawing.Size(114, 29);
            this.CB_Unit.TabIndex = 6;
            this.CB_Unit.Text = "待測機組";
            this.CB_Unit.UseVisualStyleBackColor = true;
            // 
            // Btn_LogOut
            // 
            this.Btn_LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_LogOut.FlatAppearance.BorderSize = 0;
            this.Btn_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LogOut.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_LogOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_LogOut.Location = new System.Drawing.Point(680, 149);
            this.Btn_LogOut.Name = "Btn_LogOut";
            this.Btn_LogOut.Size = new System.Drawing.Size(91, 46);
            this.Btn_LogOut.TabIndex = 4;
            this.Btn_LogOut.Tag = "連接";
            this.Btn_LogOut.Text = "輸出";
            this.Btn_LogOut.UseVisualStyleBackColor = false;
            this.Btn_LogOut.Click += new System.EventHandler(this.Btn_LogOut_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Exit.Location = new System.Drawing.Point(801, 149);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(91, 46);
            this.Btn_Exit.TabIndex = 4;
            this.Btn_Exit.Tag = "連接";
            this.Btn_Exit.Text = "離開";
            this.Btn_Exit.UseVisualStyleBackColor = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Txt_UnitDataPath
            // 
            this.Txt_UnitDataPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_UnitDataPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_UnitDataPath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_UnitDataPath.ForeColor = System.Drawing.Color.Silver;
            this.Txt_UnitDataPath.Location = new System.Drawing.Point(484, 64);
            this.Txt_UnitDataPath.Name = "Txt_UnitDataPath";
            this.Txt_UnitDataPath.Size = new System.Drawing.Size(287, 27);
            this.Txt_UnitDataPath.TabIndex = 5;
            this.Txt_UnitDataPath.Tag = "請選擇機組數據存檔位置";
            this.Txt_UnitDataPath.Text = "請選擇機組數據存檔位置";
            // 
            // Txt_StationDataPath
            // 
            this.Txt_StationDataPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_StationDataPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_StationDataPath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_StationDataPath.ForeColor = System.Drawing.Color.Silver;
            this.Txt_StationDataPath.Location = new System.Drawing.Point(484, 105);
            this.Txt_StationDataPath.Name = "Txt_StationDataPath";
            this.Txt_StationDataPath.Size = new System.Drawing.Size(287, 27);
            this.Txt_StationDataPath.TabIndex = 5;
            this.Txt_StationDataPath.Tag = "請選擇試車站數據存檔位置";
            this.Txt_StationDataPath.Text = "請選擇試車站數據存檔位置";
            // 
            // Btn_StationFolderSelect
            // 
            this.Btn_StationFolderSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_StationFolderSelect.FlatAppearance.BorderSize = 0;
            this.Btn_StationFolderSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_StationFolderSelect.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_StationFolderSelect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_StationFolderSelect.Location = new System.Drawing.Point(801, 105);
            this.Btn_StationFolderSelect.Name = "Btn_StationFolderSelect";
            this.Btn_StationFolderSelect.Size = new System.Drawing.Size(91, 29);
            this.Btn_StationFolderSelect.TabIndex = 4;
            this.Btn_StationFolderSelect.Tag = "連接";
            this.Btn_StationFolderSelect.Text = "選擇";
            this.Btn_StationFolderSelect.UseVisualStyleBackColor = false;
            this.Btn_StationFolderSelect.Click += new System.EventHandler(this.Btn_StationFolderSelect_Click);
            // 
            // Btn_UnitFolderSelect
            // 
            this.Btn_UnitFolderSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_UnitFolderSelect.FlatAppearance.BorderSize = 0;
            this.Btn_UnitFolderSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_UnitFolderSelect.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_UnitFolderSelect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_UnitFolderSelect.Location = new System.Drawing.Point(801, 61);
            this.Btn_UnitFolderSelect.Name = "Btn_UnitFolderSelect";
            this.Btn_UnitFolderSelect.Size = new System.Drawing.Size(91, 29);
            this.Btn_UnitFolderSelect.TabIndex = 4;
            this.Btn_UnitFolderSelect.Tag = "連接";
            this.Btn_UnitFolderSelect.Text = "選擇";
            this.Btn_UnitFolderSelect.UseVisualStyleBackColor = false;
            this.Btn_UnitFolderSelect.Click += new System.EventHandler(this.Btn_UnitFolderSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(62, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "數據紀錄";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(496, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "數據輸出";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(97, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "紀錄延遲";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(307, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "ms";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_Clear.FlatAppearance.BorderSize = 0;
            this.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Clear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Clear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Clear.Location = new System.Drawing.Point(564, 149);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(91, 46);
            this.Btn_Clear.TabIndex = 4;
            this.Btn_Clear.Tag = "連接";
            this.Btn_Clear.Text = "清除";
            this.Btn_Clear.UseVisualStyleBackColor = false;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // DataLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(919, 221);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_Unit);
            this.Controls.Add(this.CB_Station);
            this.Controls.Add(this.Txt_StationDataPath);
            this.Controls.Add(this.Txt_UnitDataPath);
            this.Controls.Add(this.Txt_LogTimer);
            this.Controls.Add(this.Btn_DataLogStop);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_UnitFolderSelect);
            this.Controls.Add(this.Btn_StationFolderSelect);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_LogOut);
            this.Controls.Add(this.Btn_DataStartLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.Name = "DataLogForm";
            this.Text = "DataLogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_LogTimer;
        private System.Windows.Forms.Button Btn_DataStartLog;
        private System.Windows.Forms.Button Btn_DataLogStop;
        private System.Windows.Forms.CheckBox CB_Station;
        private System.Windows.Forms.CheckBox CB_Unit;
        private System.Windows.Forms.Button Btn_LogOut;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox Txt_UnitDataPath;
        private System.Windows.Forms.TextBox Txt_StationDataPath;
        private System.Windows.Forms.Button Btn_StationFolderSelect;
        private System.Windows.Forms.Button Btn_UnitFolderSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Clear;
    }
}