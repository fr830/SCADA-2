namespace TestStation
{
    partial class ManagentForm
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
            this.Txt_UserName = new System.Windows.Forms.TextBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Combo_Authority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Insert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.AuthorityGrayViews = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorityGrayViews)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_UserName
            // 
            this.Txt_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_UserName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.Txt_UserName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_UserName.Location = new System.Drawing.Point(159, 68);
            this.Txt_UserName.Name = "Txt_UserName";
            this.Txt_UserName.Size = new System.Drawing.Size(134, 23);
            this.Txt_UserName.TabIndex = 0;
            // 
            // Txt_Password
            // 
            this.Txt_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Password.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.Txt_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_Password.Location = new System.Drawing.Point(159, 125);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(134, 23);
            this.Txt_Password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(34, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "用戶名稱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(34, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "用戶密碼：";
            // 
            // Combo_Authority
            // 
            this.Combo_Authority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Combo_Authority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Combo_Authority.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.Combo_Authority.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Combo_Authority.FormattingEnabled = true;
            this.Combo_Authority.Items.AddRange(new object[] {
            "管理員",
            "操作者",
            "訪客"});
            this.Combo_Authority.Location = new System.Drawing.Point(159, 182);
            this.Combo_Authority.Name = "Combo_Authority";
            this.Combo_Authority.Size = new System.Drawing.Size(134, 30);
            this.Combo_Authority.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(34, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "用戶權限：";
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Btn_Insert.FlatAppearance.BorderSize = 0;
            this.Btn_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Insert.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Insert.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Insert.Location = new System.Drawing.Point(37, 253);
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.Size = new System.Drawing.Size(110, 43);
            this.Btn_Insert.TabIndex = 7;
            this.Btn_Insert.Text = "增加用戶";
            this.Btn_Insert.UseVisualStyleBackColor = false;
            this.Btn_Insert.Click += new System.EventHandler(this.Btn_Insert_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(183, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "刪除用戶";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_Exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Exit.Location = new System.Drawing.Point(183, 329);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(110, 43);
            this.Btn_Exit.TabIndex = 9;
            this.Btn_Exit.Text = "離開";
            this.Btn_Exit.UseVisualStyleBackColor = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // AuthorityGrayViews
            // 
            this.AuthorityGrayViews.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.AuthorityGrayViews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorityGrayViews.GridColor = System.Drawing.Color.WhiteSmoke;
            this.AuthorityGrayViews.Location = new System.Drawing.Point(391, 35);
            this.AuthorityGrayViews.Name = "AuthorityGrayViews";
            this.AuthorityGrayViews.RowTemplate.Height = 27;
            this.AuthorityGrayViews.Size = new System.Drawing.Size(452, 337);
            this.AuthorityGrayViews.TabIndex = 10;
            // 
            // ManagentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(871, 431);
            this.Controls.Add(this.AuthorityGrayViews);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Insert);
            this.Controls.Add(this.Combo_Authority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.Name = "ManagentForm";
            this.Text = "ManagentForm";
            this.Load += new System.EventHandler(this.ManagentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuthorityGrayViews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_UserName;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Combo_Authority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Insert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.DataGridView AuthorityGrayViews;
    }
}