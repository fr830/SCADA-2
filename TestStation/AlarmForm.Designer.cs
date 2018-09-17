namespace TestStation
{
    partial class AlarmForm
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
            this.AlarmGrayViews = new System.Windows.Forms.DataGridView();
            this.Btn_Reset = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmGrayViews)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(860, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "警報與跳脫";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmGrayViews
            // 
            this.AlarmGrayViews.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.AlarmGrayViews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlarmGrayViews.GridColor = System.Drawing.Color.WhiteSmoke;
            this.AlarmGrayViews.Location = new System.Drawing.Point(12, 70);
            this.AlarmGrayViews.Name = "AlarmGrayViews";
            this.AlarmGrayViews.RowTemplate.Height = 27;
            this.AlarmGrayViews.Size = new System.Drawing.Size(720, 799);
            this.AlarmGrayViews.TabIndex = 11;
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.BackgroundImage = global::TestStation.Properties.Resources.ResetButton;
            this.Btn_Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Reset.FlatAppearance.BorderSize = 0;
            this.Btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Reset.Location = new System.Drawing.Point(765, 150);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.Size = new System.Drawing.Size(60, 60);
            this.Btn_Reset.TabIndex = 12;
            this.Btn_Reset.UseVisualStyleBackColor = true;
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.BackgroundImage = global::TestStation.Properties.Resources.RecycleButton2;
            this.Btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Clear.FlatAppearance.BorderSize = 0;
            this.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Clear.Location = new System.Drawing.Point(765, 70);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(60, 60);
            this.Btn_Clear.TabIndex = 45;
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Btn_Exit.BackgroundImage = global::TestStation.Properties.Resources.ReturnButtonR3;
            this.Btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Exit.Location = new System.Drawing.Point(765, 803);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(60, 60);
            this.Btn_Exit.TabIndex = 44;
            this.Btn_Exit.UseVisualStyleBackColor = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(860, 1000);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_Reset);
            this.Controls.Add(this.AlarmGrayViews);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlarmForm";
            this.Text = "AlarmForm";
            this.Load += new System.EventHandler(this.AlarmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlarmGrayViews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView AlarmGrayViews;
        private System.Windows.Forms.Button Btn_Reset;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.Button Btn_Clear;
    }
}