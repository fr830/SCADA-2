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
using System.Windows.Forms.DataVisualization.Charting;

namespace TestStation
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        private object[] LastTime;
        private object[] LastData;
        private object[] LastData2;

      private void TestForm_Load(object sender, EventArgs e)
        {
            ChartInit(Chart_HW, new string[] { "HWInletT", "HWOutletT" }, new Color[] { Color.FromArgb(148, 110, 121), Color.FromArgb(139, 152, 121) });
            ChartInit(Chart_CW, new string[] { "CWInletT", "CWOutletT" }, new Color[] { Color.FromArgb(139,152,121), Color.FromArgb(148, 110, 121) });
        }

        //Button_Click_Start
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.mainForm.Show();
            this.Hide();
        }
        private void Btn_HWChartOn_Click(object sender, EventArgs e)
        {
            TM_HW_Chart.Enabled = true;
        }
        private void Btn_ChartCWON_Click(object sender, EventArgs e)
        {
            TM_CW_Chart.Enabled = true;
        }
        private void Btn_Chart_HW_Left_Click(object sender, EventArgs e)
        {
            ChartMove(TM_HW_Chart, Chart_HW, "HWInletT","HWOutletT", -10, "HW_Inlet_Temp", "HW_Outlet_Temp", "時間", "Station");
        }
        private void Btn_Chart_HW_Right_Click(object sender, EventArgs e)
        {
            ChartMove(TM_HW_Chart, Chart_HW, "HWInletT", "HWOutletT", 10, "HW_Inlet_Temp", "HW_Outlet_Temp", "時間", "Station");
        }
        private void Btn_Chart_CW_Left_Click(object sender, EventArgs e)
        {
            ChartMove(TM_CW_Chart,Chart_CW, "CWInletT", "CWOutletT", -10, "RTD2", "RTD3", "時間", "Station");
        }
        private void Btn_Chart_CW_Right_Click(object sender, EventArgs e)
        {
            ChartMove(TM_CW_Chart, Chart_CW, "CWInletT", "CWOutletT", 10, "RTD2", "RTD3", "時間", "Station");
        }
        //Button_Click_Stop

        //Timer_Tick_Start
        private void TM_LabChange_Tick(object sender, EventArgs e)
        {
            DataChangeLab();
        }
        private void TM_HW_Chart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_HW, "HWInletT", "HW_Inlet_Temp", "Station", "時間");
            ChartStart(Chart_HW, "HWOutletT", "HW_Outlet_Temp", "Station", "時間");
        }
        private void TM_CW_Chart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_CW, "CWInletT", "RTD2", "Station", "時間"); 
            ChartStart(Chart_CW, "CWOutletT", "RTD3", "Station", "時間");
        }
        //Timer_Click_Stop

        //Customize_Function_Start
        private void DataChangeLab()
        {
            try
            {
                Form1.RWLock.AcquireReaderLock(2000);
                Lab_SPFR.Text = ((float)Form1.StationDataBuffer[0] / 10).ToString() + "m3/H";
                Lab_BPFR.Text = ((float)Form1.StationDataBuffer[1] / 10).ToString() + "m3/H";
                Lab_CW_SPFR.Text = ((float)Form1.StationDataBuffer[2] / 10).ToString() + "m3/H";
                Lab_CW_BPFR.Text = ((float)Form1.StationDataBuffer[3] / 10).ToString() + "m3/H";
                Lab_SFR.Text = ((float)Form1.StationDataBuffer[4] / 10).ToString() + "m3/H";
                Lab_StramT.Text = ((float)Form1.StationDataBuffer[5] / 10).ToString() + "℃";
                Lab_AVP.Text = Form1.StationDataBuffer[6].ToString() + "kPa";
                Lab_BVP.Text = Form1.StationDataBuffer[7].ToString() + "kPa";
                Lab_HWOutletT.Text = ((float)Form1.StationDataBuffer[8] / 10).ToString() + "℃";
                Lab_HWInletT.Text = ((float)Form1.StationDataBuffer[9] / 10).ToString() + "℃";
                Lab_CWOutletT.Text = ((float)Form1.StationDataBuffer[13] / 10).ToString() + "℃";
                Lab_CWInletT.Text = ((float)Form1.StationDataBuffer[14] / 10).ToString() + "℃";
            }
            catch (ApplicationException)
            {
            }
            finally
            {
                if (Form1.RWLock.IsReaderLockHeld)
                    Form1.RWLock.ReleaseLock();
            }
        }
        public void GetConnectStatus(object sender, EventArgs e)
        {
            ConnectStatusEvent arg = (ConnectStatusEvent)e;
            string StationConnectStatus = arg.ConnectStatus;

            if (StationConnectStatus == "試車站PLC在線")
            {
                TM_LabChange.Enabled = true;
            }
        }
        private void ChartStart(Chart chart, string SeriesName, string Datatag, string TableName, string SearchName)
        {
            chart.Series[SeriesName].Points.Clear();
            LastTime = (MainForm.broker.LastSearch(Datatag, TableName, SearchName))[0].ToArray();
            LastData = (MainForm.broker.LastSearch(Datatag, TableName, SearchName))[1].ToArray();
            for (int i = 0; i < LastTime.Length; i++)
            {
                chart.Series[SeriesName].Points.InsertXY(0, ((DateTime)LastTime[i]).ToString("HH:mm:ss"), LastData[i]);
            }
        }
        private void ChartInit(Chart chart, string[] Member, Color[] colors)
        {
            ChartArea PChartArea = chart.ChartAreas[0];
            PChartArea.InnerPlotPosition.X = 10;
            PChartArea.InnerPlotPosition.Y = 5;
            PChartArea.InnerPlotPosition.Height = 85;
            PChartArea.AxisY.LabelStyle.ForeColor = Color.WhiteSmoke;
            PChartArea.AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            PChartArea.AxisX.LabelStyle.ForeColor = Color.WhiteSmoke;
            PChartArea.InnerPlotPosition.Width = 85;
            PChartArea.BackColor = Color.FromName("");
            PChartArea.AxisX.Maximum = 1000;
            PChartArea.AxisX.Interval = 250;
            PChartArea.AxisX.MajorGrid.LineColor = Color.FromName("Transparent");   //X軸格線
            for (int i = 0; i < Member.Length; i++)
            {
                chart.Series[Member[i]].Color = colors[i];
            }
        }
        private void ChartMove(Timer timer, Chart chart, string SeriesName, string SeriesName2, double Move, string DataTag, string DataTag2, string SearchName, string TableName)
        {
            timer.Enabled = false;
            ChartArea chartArea = chart.ChartAreas[0];
            DateTime DT = Convert.ToDateTime(chart.Series[SeriesName].Points[(int)chartArea.AxisX.Minimum].AxisLabel);
            DT = DT.AddMinutes(Move);
            string str = DT.ToString("HH:mm:ss");
            LastTime = (MainForm.broker.Search(str, DataTag, SearchName, TableName))[0].ToArray();
            LastData = (MainForm.broker.Search(str, DataTag, SearchName, TableName))[1].ToArray();
            LastData2 = (MainForm.broker.Search(str, DataTag2, SearchName, TableName))[1].ToArray();
            //chartArea.AxisX.Maximum = LastTime.Length;
            chart.Series[SeriesName].Points.Clear();
            for (int i = 0; i < LastTime.Length; i++)
            {
                chart.Series[SeriesName].Points.InsertXY(0, ((DateTime)LastTime[i]).ToString("HH:mm:ss"), LastData[i]);
                chart.Series[SeriesName2].Points.InsertXY(0, ((DateTime)LastTime[i]).ToString("HH:mm:ss"), LastData2[i]);
            }
        }
        public void GetDelayTime(object sender, EventArgs e)
        {
            TimerDelayEvent arg = (TimerDelayEvent)e;
            TM_CW_Chart.Interval = arg.DelayTime;
            TM_HW_Chart.Interval = arg.DelayTime;
        }
        //Customize_Function_Stop

        //Paint_Event_Start
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 597, 670),
                       Color.WhiteSmoke, 2, ButtonBorderStyle.Solid,
                       Color.WhiteSmoke, 2, ButtonBorderStyle.Solid,
                       Color.Gray, 0, ButtonBorderStyle.None,
                       Color.Gray, 0, ButtonBorderStyle.None);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 1056, 670),
                     Color.Gray, 0, ButtonBorderStyle.None,
                     Color.WhiteSmoke, 2, ButtonBorderStyle.Solid,
                     Color.WhiteSmoke, 2, ButtonBorderStyle.Solid,
                     Color.Gray, 0, ButtonBorderStyle.None);
        }
        //Paint_Event_Stop
    }
}
