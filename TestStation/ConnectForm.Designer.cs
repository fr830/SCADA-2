namespace TestStation
{
    partial class ConnectForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_StationConnect = new System.Windows.Forms.Button();
            this.Btn_StationDisconnect = new System.Windows.Forms.Button();
            this.Txt_StationIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_StationPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_UnitConnect = new System.Windows.Forms.Button();
            this.Btn_UnitDisconnect = new System.Windows.Forms.Button();
            this.Txt_UnitIP = new System.Windows.Forms.TextBox();
            this.Txt_UnitPort = new System.Windows.Forms.TextBox();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Lab_UnitConnecting = new System.Windows.Forms.Label();
            this.Lab_StationConnecting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(56, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "試車站伺服器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(422, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "機組伺服器";
            // 
            // Btn_StationConnect
            // 
            this.Btn_StationConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_StationConnect.FlatAppearance.BorderSize = 0;
            this.Btn_StationConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_StationConnect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_StationConnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_StationConnect.Location = new System.Drawing.Point(301, 76);
            this.Btn_StationConnect.Name = "Btn_StationConnect";
            this.Btn_StationConnect.Size = new System.Drawing.Size(91, 46);
            this.Btn_StationConnect.TabIndex = 1;
            this.Btn_StationConnect.Tag = "連接";
            this.Btn_StationConnect.Text = "連接";
            this.Btn_StationConnect.UseVisualStyleBackColor = false;
            this.Btn_StationConnect.Click += new System.EventHandler(this.Btn_StationConnect_Click);
            this.Btn_StationConnect.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_StationConnect_Paint);
            // 
            // Btn_StationDisconnect
            // 
            this.Btn_StationDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_StationDisconnect.FlatAppearance.BorderSize = 0;
            this.Btn_StationDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_StationDisconnect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_StationDisconnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_StationDisconnect.Location = new System.Drawing.Point(301, 151);
            this.Btn_StationDisconnect.Name = "Btn_StationDisconnect";
            this.Btn_StationDisconnect.Size = new System.Drawing.Size(91, 46);
            this.Btn_StationDisconnect.TabIndex = 1;
            this.Btn_StationDisconnect.Tag = "中斷";
            this.Btn_StationDisconnect.Text = "中斷";
            this.Btn_StationDisconnect.UseVisualStyleBackColor = false;
            this.Btn_StationDisconnect.Click += new System.EventHandler(this.Btn_StationDisconnect_Click);
            this.Btn_StationDisconnect.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_StationDisconnect_Paint);
            // 
            // Txt_StationIP
            // 
            this.Txt_StationIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_StationIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_StationIP.Enabled = false;
            this.Txt_StationIP.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_StationIP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_StationIP.Location = new System.Drawing.Point(87, 95);
            this.Txt_StationIP.Name = "Txt_StationIP";
            this.Txt_StationIP.Size = new System.Drawing.Size(172, 27);
            this.Txt_StationIP.TabIndex = 2;
            this.Txt_StationIP.Text = "192.168.1.3";
            this.Txt_StationIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(83, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "伺服器地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(83, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "伺服器端口";
            // 
            // Txt_StationPort
            // 
            this.Txt_StationPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_StationPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_StationPort.Enabled = false;
            this.Txt_StationPort.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_StationPort.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_StationPort.Location = new System.Drawing.Point(87, 164);
            this.Txt_StationPort.Name = "Txt_StationPort";
            this.Txt_StationPort.Size = new System.Drawing.Size(172, 27);
            this.Txt_StationPort.TabIndex = 2;
            this.Txt_StationPort.Text = "502";
            this.Txt_StationPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(461, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "伺服器地址";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(461, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "伺服器端口";
            // 
            // Btn_UnitConnect
            // 
            this.Btn_UnitConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_UnitConnect.FlatAppearance.BorderSize = 0;
            this.Btn_UnitConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_UnitConnect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_UnitConnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_UnitConnect.Location = new System.Drawing.Point(679, 76);
            this.Btn_UnitConnect.Name = "Btn_UnitConnect";
            this.Btn_UnitConnect.Size = new System.Drawing.Size(91, 46);
            this.Btn_UnitConnect.TabIndex = 1;
            this.Btn_UnitConnect.Tag = "連接";
            this.Btn_UnitConnect.Text = "連接";
            this.Btn_UnitConnect.UseVisualStyleBackColor = false;
            this.Btn_UnitConnect.Click += new System.EventHandler(this.Btn_UnitConnect_Click);
            this.Btn_UnitConnect.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_UnitConnect_Paint);
            // 
            // Btn_UnitDisconnect
            // 
            this.Btn_UnitDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_UnitDisconnect.Enabled = false;
            this.Btn_UnitDisconnect.FlatAppearance.BorderSize = 0;
            this.Btn_UnitDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_UnitDisconnect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_UnitDisconnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_UnitDisconnect.Location = new System.Drawing.Point(679, 151);
            this.Btn_UnitDisconnect.Name = "Btn_UnitDisconnect";
            this.Btn_UnitDisconnect.Size = new System.Drawing.Size(91, 46);
            this.Btn_UnitDisconnect.TabIndex = 1;
            this.Btn_UnitDisconnect.Tag = "中斷";
            this.Btn_UnitDisconnect.Text = "中斷";
            this.Btn_UnitDisconnect.UseVisualStyleBackColor = false;
            this.Btn_UnitDisconnect.Click += new System.EventHandler(this.Btn_UnitDisconnect_Click);
            this.Btn_UnitDisconnect.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_UnitDisconnect_Paint);
            // 
            // Txt_UnitIP
            // 
            this.Txt_UnitIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_UnitIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_UnitIP.Enabled = false;
            this.Txt_UnitIP.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_UnitIP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_UnitIP.Location = new System.Drawing.Point(465, 95);
            this.Txt_UnitIP.Name = "Txt_UnitIP";
            this.Txt_UnitIP.Size = new System.Drawing.Size(172, 27);
            this.Txt_UnitIP.TabIndex = 2;
            this.Txt_UnitIP.Text = "192.168.1.13";
            this.Txt_UnitIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_UnitPort
            // 
            this.Txt_UnitPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_UnitPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_UnitPort.Enabled = false;
            this.Txt_UnitPort.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Txt_UnitPort.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_UnitPort.Location = new System.Drawing.Point(465, 164);
            this.Txt_UnitPort.Name = "Txt_UnitPort";
            this.Txt_UnitPort.Size = new System.Drawing.Size(172, 27);
            this.Txt_UnitPort.TabIndex = 2;
            this.Txt_UnitPort.Text = "502";
            this.Txt_UnitPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Exit.Location = new System.Drawing.Point(799, 153);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(91, 46);
            this.Btn_Exit.TabIndex = 1;
            this.Btn_Exit.Tag = "離開";
            this.Btn_Exit.Text = "離開";
            this.Btn_Exit.UseVisualStyleBackColor = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            this.Btn_Exit.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_UnitDisconnect_Paint);
            // 
            // Lab_UnitConnecting
            // 
            this.Lab_UnitConnecting.AutoSize = true;
            this.Lab_UnitConnecting.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lab_UnitConnecting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lab_UnitConnecting.Location = new System.Drawing.Point(627, 36);
            this.Lab_UnitConnecting.Name = "Lab_UnitConnecting";
            this.Lab_UnitConnecting.Size = new System.Drawing.Size(158, 24);
            this.Lab_UnitConnecting.TabIndex = 0;
            this.Lab_UnitConnecting.Text = "與伺服器連接中...";
            this.Lab_UnitConnecting.Visible = false;
            // 
            // Lab_StationConnecting
            // 
            this.Lab_StationConnecting.AutoSize = true;
            this.Lab_StationConnecting.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lab_StationConnecting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lab_StationConnecting.Location = new System.Drawing.Point(258, 36);
            this.Lab_StationConnecting.Name = "Lab_StationConnecting";
            this.Lab_StationConnecting.Size = new System.Drawing.Size(158, 24);
            this.Lab_StationConnecting.TabIndex = 0;
            this.Lab_StationConnecting.Text = "與伺服器連接中...";
            this.Lab_StationConnecting.Visible = false;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(919, 221);
            this.ControlBox = false;
            this.Controls.Add(this.Txt_UnitPort);
            this.Controls.Add(this.Txt_StationPort);
            this.Controls.Add(this.Txt_UnitIP);
            this.Controls.Add(this.Txt_StationIP);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_UnitDisconnect);
            this.Controls.Add(this.Btn_StationDisconnect);
            this.Controls.Add(this.Btn_UnitConnect);
            this.Controls.Add(this.Btn_StationConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lab_StationConnecting);
            this.Controls.Add(this.Lab_UnitConnecting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConnectForm";
            this.Text = "ConnectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_StationConnect;
        private System.Windows.Forms.Button Btn_StationDisconnect;
        private System.Windows.Forms.TextBox Txt_StationIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_StationPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btn_UnitConnect;
        private System.Windows.Forms.Button Btn_UnitDisconnect;
        private System.Windows.Forms.TextBox Txt_UnitIP;
        private System.Windows.Forms.TextBox Txt_UnitPort;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.Label Lab_UnitConnecting;
        private System.Windows.Forms.Label Lab_StationConnecting;
    }
}