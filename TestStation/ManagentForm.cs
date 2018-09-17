using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace TestStation
{
    public partial class ManagentForm : Form
    {
        public ManagentForm()
        {
            InitializeComponent();
        }
        private void ManagentForm_Load(object sender, EventArgs e)
        {
            //修改DataGridViewer的外觀
            AuthorityGrayViews.DataSource = MainForm.broker.GetDataSource("Authority");
            AuthorityGrayViews.EnableHeadersVisualStyles = false;
            AuthorityGrayViews.ReadOnly = true;
            AuthorityGrayViews.ColumnHeadersVisible = false;
            AuthorityGrayViews.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            AuthorityGrayViews.ScrollBars = ScrollBars.None;
            AuthorityGrayViews.DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            AuthorityGrayViews.DefaultCellStyle.SelectionForeColor = Color.FromArgb(80, 80, 80);
            AuthorityGrayViews.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            AuthorityGrayViews.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(80, 80, 80);
            AuthorityGrayViews.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            AuthorityGrayViews.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            AuthorityGrayViews.RowHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            AuthorityGrayViews.GridColor = Color.Black;
            AuthorityGrayViews.DefaultCellStyle.Font = new Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            //修改DataGridViewer的外觀
        }

         
        //Botton_click_event_Start
        private void Btn_Insert_Click_1(object sender, EventArgs e)
        {
            if (Txt_UserName.Text.Length < 10)
            {
                MainForm.broker.Insert(new AuthorityManagent(Txt_UserName.Text, Txt_Password.Text, (AuthorityManagent.Authority)Enum.Parse(typeof(AuthorityManagent.Authority), Combo_Authority.Text.Trim())), "Authority");
                AuthorityGrayViews.DataSource = MainForm.broker.GetDataSource("Authority");//刷新顯示
            }
            else
            {
                MessageBox.Show("用戶名稱不得多於10個字", "警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.broker.Delete("Authority", "UserName", AuthorityGrayViews.CurrentRow.Cells[0].Value.ToString().Trim()); //將Sql server中符合UserName的資料刪除
            AuthorityGrayViews.DataSource = MainForm.broker.GetDataSource("Authority");
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        //Botton_click_event_Stop
    }
}
