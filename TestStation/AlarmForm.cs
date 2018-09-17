using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStation
{
    public partial class AlarmForm : Form
    {
        public AlarmForm()
        {
            InitializeComponent();
        }
      /*  SqlDataAdapter adapter;
        DataSet dataSet;
        DataTable table;*/
        SqlConnectionStringBuilder SqlConnectionStringBuilder;
        private void AlarmForm_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder.DataSource = "DESKTOP-M4V9RKV";    //資料庫指標
            SqlConnectionStringBuilder.InitialCatalog = "Data";
            SqlConnectionStringBuilder.IntegratedSecurity = true;
            SqlDependency.Start(SqlConnectionStringBuilder.ToString());
            SqlDependencyWatch();
            RefreshTable();
            DataGripViewInit(); //修改DataGridViewer的外觀
        }
        //Button_Click_Event_Start
        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("該功能尚未實裝", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("您確定要刪除所有的跳脫與警報嗎?","警告",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
               MainForm.broker.Delete("UnitTrip");
        }
        //Button_Click_Event_Stop

        //Customize_Function_Start
        private void SqlDependencyWatch()
        {
            //這邊用的查詢欄位不能式PK，資料表也必須是完整的像dbo.TableName
            string sSQL = "select [Name],[Time],[status] from [dbo].[UnitTrip] order by Time desc";
            SqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder.DataSource = "DESKTOP-M4V9RKV";    //資料庫指標
            SqlConnectionStringBuilder.InitialCatalog = "Data";
            SqlConnectionStringBuilder.IntegratedSecurity = true;
            using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder.ToString()))
            {
                using (SqlCommand command = new SqlCommand(sSQL, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDependency dependency = new SqlDependency(command);
                    //這間加入監聽事件SQLTableOnChange
                    dependency.OnChange += new OnChangeEventHandler(SQLTableOnChange);
                    SqlDataReader sdr = command.ExecuteReader();
                }
            }
        }
        void SQLTableOnChange(object sender, SqlNotificationEventArgs e)
        {
            //觸發後再開啟一次監聽事件    
            SqlDependencyWatch();
            //執行我自己要執行的邏輯處理
            RefreshTable();
        }
        private void RefreshTable()
        {
            try
            {
                string sSQL22 = "select [Name],[Time],[status] from [dbo].[UnitTrip] order by Time desc";
                SqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                SqlConnectionStringBuilder.DataSource = "DESKTOP-M4V9RKV";    //資料庫指標
                SqlConnectionStringBuilder.InitialCatalog = "Data";
                SqlConnectionStringBuilder.IntegratedSecurity = true;
                DataTable datatable = new DataTable();
                using (SqlConnection connection = new SqlConnection(SqlConnectionStringBuilder.ToString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sSQL22, connection))
                    {
                        using (SqlDataAdapter dr = new SqlDataAdapter(sSQL22, connection))
                        {
                            dr.Fill(datatable);
                            //這邊要注意，因為SqlDependency是屬於另外個執行緒
                            //所以要使用Invoke來做UI的更新
                            this.Invoke((EventHandler)(delegate
                            {
                                AlarmGrayViews.DataSource = datatable;
                            }));
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {

            }
        }
        private void DataGripViewInit()
        {
            AlarmGrayViews.EnableHeadersVisualStyles = false;
            AlarmGrayViews.ReadOnly = true;
            AlarmGrayViews.RowHeadersVisible = false;
            AlarmGrayViews.ColumnHeadersVisible = true;
            AlarmGrayViews.ColumnHeadersHeight = 50;
            AlarmGrayViews.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            AlarmGrayViews.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            AlarmGrayViews.ScrollBars = ScrollBars.None;
            AlarmGrayViews.AutoResizeColumns();
            AlarmGrayViews.Columns[0].Width = 250;
            AlarmGrayViews.Columns[1].Width = 203;
            AlarmGrayViews.Columns[2].Width = 121;
            AlarmGrayViews.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            AlarmGrayViews.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AlarmGrayViews.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AlarmGrayViews.DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            AlarmGrayViews.DefaultCellStyle.SelectionForeColor = Color.FromArgb(80, 80, 80);
            AlarmGrayViews.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            AlarmGrayViews.RowHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(80, 80, 80);
            AlarmGrayViews.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            AlarmGrayViews.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            AlarmGrayViews.RowHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            AlarmGrayViews.GridColor = Color.Black;
            AlarmGrayViews.DefaultCellStyle.Font = new Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        }
        //Customize_Function_Stop
    }
}
