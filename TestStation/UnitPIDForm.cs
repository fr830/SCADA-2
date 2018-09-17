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
    public partial class UnitPIDForm : Form
    {
        public UnitPIDForm()
        {
            InitializeComponent();
        }
        object[] LastTime;
        object[] LastData;
        object[] LastData2;
        Control[] StationData;
        Button[] ButtonList;
        public  EventHandler SendCommandEvent;
        private void UnitPIDForm_Load(object sender, EventArgs e)
        {
            ChartInit(Chart_Power, new string[] { "Power", "Current" }, new Color[] { Color.FromArgb(180, 238, 139, 101), Color.FromArgb(180, 162, 179, 136) });
            ChartInit(Chart_Press, new string[] { "ExpInletP", "OilFiliterP" }, new Color[] { Color.FromArgb(180, 238, 139, 101), Color.FromArgb(180, 162, 179, 136) });
            ChartInit(Chart_HW, new string[] { "HWInletT", "HWOutletT" }, new Color[] { Color.FromArgb(180, 238, 139, 101), Color.FromArgb(180, 162, 179, 136) });
            ChartInit(Chart_CW, new string[] { "CWInletT", "CWOutletT" }, new Color[] { Color.FromArgb(230, 238, 139, 101), Color.FromArgb(230, 162, 179, 136) });
            StationData = new Control[] {Lab_Stat1,Lab_Stat2,Lab_Stat3, Lab_Stat4, Lab_Stat5, Lab_Stat6,Lab_Stat7, Lab_Stat8, Lab_Stat9,Lab_Stat10
                                                   ,Lab_Stat11,Lab_Stat12,Lab_Stat13,Lab_Stat_AFSP,Lab_Stat_BESP,Lab_Stat_CWInletT,Lab_Stat_CWOutletT,Lab_Stat_HWInletT
                                                   ,Lab_Stat_HWOutletT,Lab_Stat_HW_BPFR,Lab_Stat_HW_SPFR,Lab_Stat_CW_BPFR,Lab_Stat_CW_SPFR,Lab_Stat_SFR,Lab_Stat_ST,Btn_Button_List};
            ButtonList = new Button[] {button1,button2 };
            SendCommandEvent += ((MainForm)(this.Owner)).connectForm.GetCommandSingal;
        }

        //Button_Click_Start
        private void button1_Click(object sender, EventArgs e)
          {
            Form1.mainForm.Show();
            this.Hide();
          }
        private void Btn_PowerChartOn_Click(object sender, EventArgs e)
          {
                Timer_PowerChart.Enabled = true;
          }
        private void Btn_ChartPressON_Click(object sender, EventArgs e)
          {
            Timer_PressChart.Enabled = true;
          }
        private void Btn_ChartHWON_Click(object sender, EventArgs e)
          {
            Timer_HWChart.Enabled = true;
          }
        private void Btn_ChartCWON_Click(object sender, EventArgs e)
        {
            Timer_CWChart.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in StationData)
            {
                item.Visible = true;
            }
            foreach (var item in ButtonList)
            {
                item.Visible = false;
            }
        }
        private void Btn_Button_List_Click(object sender, EventArgs e)
        {
            foreach (var item in StationData)
            {
                item.Visible = false;
            }
            foreach (var item in ButtonList)
            {
                item.Visible = true;
            }
        }
        private void Btn_Chart_Power_Left_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_PowerChart, Chart_Power, "Power", "Current", -10, "Power", "CurrentR", "時間", "StationUnit");
        }       
        private void Btn_Chart_Power_Right_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_PowerChart, Chart_Power, "Power", "Current", 10, "Power", "CurrentR", "時間", "StationUnit");
        }
        private void Btn_Chart_Press_Left_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_PressChart, Chart_Press, "ExpInletP", "OilFiliterP", -10, "ExpInletP", "FiliterOutletP", "時間", "StationUnit");
        }
        private void Btn_Chart_Press_Right_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_PressChart, Chart_Press, "ExpInletP", "OilFiliterP", 10, "ExpInletP", "FiliterOutletP", "時間", "StationUnit");
        }
        private void Btn_Chart_HW_Left_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_HWChart, Chart_HW, "HWInletT", "HWOutletT", -10, "HWInletT", "HWOutletT", "時間", "StationUnit");
        }
        private void Btn_Chart_HW_Right_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_HWChart, Chart_HW, "HWInletT", "HWOutletT", 10, "HWInletT", "HWOutletT", "時間", "StationUnit");
        }
        private void Btn_Chart_CW_Left_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_CWChart, Chart_CW, "CWInletT", "CWOutletT", -10, "CWinletT", "CWoutletT", "時間", "StationUnit");
        }
        private void Btn_Chart_CW_Right_Click(object sender, EventArgs e)
        {
            ChartMove(Timer_CWChart, Chart_CW, "CWInletT", "CWOutletT", 10, "CWinletT", "CWoutletT", "時間", "StationUnit");
        }
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您確定要遠端啟動機組嗎?","再次確定",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            SendCommandEvent(this, new SingalTransferEvent() { CommandSingal = 1,IWantControl = 2});
        }
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要遠端關閉機組嗎?", "再次確定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SendCommandEvent(this, new SingalTransferEvent() { CommandSingal = 2, IWantControl = 2 });
        }
        //Button_Click_Stop

        //Customize_Function_start
        public void DataChangeLab()
        {
            try
            {
                ConnectForm.RWLock2.AcquireReaderLock(2000);
                Lab_Rotation.Text = ConnectForm.UnitDataBuffer[2].ToString() + "RPM";
                Lab_Rotatoin2.Text = ConnectForm.UnitDataBuffer[1].ToString() + "RPM";
                Lab_SH.Text = ((float)ConnectForm.UnitDataBuffer[3] / 10).ToString() + "℃";
                Lab_VLLavg.Text = ((float)ConnectForm.UnitDataBuffer[7] / 10).ToString() + "V";
                Lab_Iavg.Text = ((float)ConnectForm.UnitDataBuffer[10] / 10).ToString() + "A";
                Lab_Power.Text = ((float)ConnectForm.UnitDataBuffer[12] / 10).ToString() + "kW";
                Lab_XV.Text = ((float)ConnectForm.UnitDataBuffer[16] / 100).ToString() + "mm/s";
                Lab_YV.Text = ((float)ConnectForm.UnitDataBuffer[17] / 100).ToString() + "mm/s";
                Lab_ZV.Text = ((float)ConnectForm.UnitDataBuffer[18] / 100).ToString() + "mm/s";
                Lab_Cond.Text = ConnectForm.UnitDataBuffer[19].ToString() + "kPa";
                Lab_ExpinletP.Text = ConnectForm.UnitDataBuffer[20].ToString() + "kPa";
                Lab_ExpoutletP.Text = ConnectForm.UnitDataBuffer[21].ToString() + "kPa";
                Lab_OilFiliterInletP.Text = ConnectForm.UnitDataBuffer[23].ToString() + "kPa";
                Lab_OilFiliterOutletP.Text = ConnectForm.UnitDataBuffer[24].ToString() + "kPa";
                Lab_CondLevel.Text = ConnectForm.UnitDataBuffer[29].ToString() + "mm";
                Lab_PunpPower.Text = ((float)ConnectForm.UnitDataBuffer[38] / 100).ToString() + "kW";
                Lab_HWinletT.Text = ((float)ConnectForm.UnitDataBuffer[42] / 10).ToString() + "℃";
                Lab_HWoutletT.Text = ((float)ConnectForm.UnitDataBuffer[43] / 10).ToString() + "℃";
                Lab_ExpInletT.Text = ((float)ConnectForm.UnitDataBuffer[44] / 10).ToString() + "℃";
                Lab_ExpoutletT.Text = ((float)ConnectForm.UnitDataBuffer[45] / 10).ToString() + "℃";
                Lab_OilTankT.Text = ((float)ConnectForm.UnitDataBuffer[49] / 10).ToString() + "℃";
                Lab_CWInletT.Text = ((float)ConnectForm.UnitDataBuffer[54] / 10).ToString() + "℃";
                Lab_CWOutletT.Text = ((float)ConnectForm.UnitDataBuffer[55] / 10).ToString() + "℃";
            }
            catch (ApplicationException)
            {
            }
            finally
            {
                if(ConnectForm.RWLock2.IsReaderLockHeld)
                   ConnectForm.RWLock2.ReleaseReaderLock();
            }
            if (Lab_Stat13.Visible)
            {
                try
                {
                    Form1.RWLock.AcquireReaderLock(2000);
                    Lab_Stat_HW_SPFR.Text = ((float)Form1.StationDataBuffer[0] / 10).ToString() + "m3/H";
                    Lab_Stat_HW_BPFR.Text = ((float)Form1.StationDataBuffer[1] / 10).ToString() + "m3/H";
                    Lab_Stat_CW_SPFR.Text = ((float)Form1.StationDataBuffer[2] / 10).ToString() + "m3/H";
                    Lab_Stat_CW_BPFR.Text = ((float)Form1.StationDataBuffer[3] / 10).ToString() + "m3/H";
                    Lab_Stat_SFR.Text = ((float)Form1.StationDataBuffer[4] / 10).ToString() + "m3/H";
                    Lab_Stat_ST.Text = ((float)Form1.StationDataBuffer[5] / 10).ToString() + "℃";
                    Lab_Stat_AFSP.Text = Form1.StationDataBuffer[6].ToString() + "kPa";
                    Lab_Stat_BESP.Text = Form1.StationDataBuffer[7].ToString() + "kPa";
                    Lab_Stat_HWOutletT.Text = ((float)Form1.StationDataBuffer[8] / 10).ToString() + "℃";
                    Lab_Stat_HWInletT.Text = ((float)Form1.StationDataBuffer[9] / 10).ToString() + "℃";
                    Lab_Stat_CWOutletT.Text = ((float)Form1.StationDataBuffer[13] / 10).ToString() + "℃";
                    Lab_Stat_CWInletT.Text = ((float)Form1.StationDataBuffer[14] / 10).ToString() + "℃";                  
                }
                finally
                {
                    if (Form1.RWLock.IsReaderLockHeld) 
                        Form1.RWLock.ReleaseLock();
                }
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
        public void GetConnectStatus(object sender, EventArgs e)
        {
            ConnectStatusEvent arg = (ConnectStatusEvent)e;
            string UnitConnectStatus = arg.UnitConnectStatus;
            Lab_UnitConnectStatus.Text = arg.UnitConnectStatus;
            if (arg.UserName != null && arg.authority != null)
            {
                Lab_UserName.Text = arg.UserName;
                Lab_Auth.Text = arg.authority;
            }
            if(arg.UnitConnectStatusColor != null)
            {
                Lab_UnitConnectStatus.ForeColor = Color.FromName(arg.UnitConnectStatusColor);
            }            
            string StationConnectStatus = arg.ConnectStatus;
            if (UnitConnectStatus == "機組PLC在線")
            {
                timer1.Enabled = true;
            }
            if (StationConnectStatus == "試車站PLC在線")
            {
                button2.Enabled = true;
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
            Timer_CWChart.Interval = arg.DelayTime;
            Timer_HWChart.Interval = arg.DelayTime;
            Timer_PowerChart.Interval = arg.DelayTime;
            Timer_PressChart.Interval = arg.DelayTime;
        }
        //Customize_Function_Stop

        //Timer_Tick_Start
        private void timer1_Tick(object sender, EventArgs e)
        { 
            DataChangeLab();
        }
        private void Timer_PowerChart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_Power, "Power", "Power", "StationUnit", "時間");
            ChartStart(Chart_Power, "Current", "CurrentR", "StationUnit", "時間");
        }
        private void Timer_PressChart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_Press, "ExpInletP", "ExpInletP", "StationUnit", "時間");
            ChartStart(Chart_Press, "OilFiliterP", "FiliterOutletP", "StationUnit", "時間");
        }
        private void Timer_HWChart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_HW, "HWInletT", "HWInletT", "StationUnit", "時間");
            ChartStart(Chart_HW, "HWOutletT", "HWOutletT", "StationUnit", "時間");
        }
        private void Timer_CWChart_Tick(object sender, EventArgs e)
        {
            ChartStart(Chart_CW, "CWInletT", "CWinletT", "StationUnit", "時間");
            ChartStart(Chart_CW, "CWOutletT", "CWoutletT", "StationUnit", "時間");
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, 511, 275),
                                   Color.Gray, 0, ButtonBorderStyle.None,
                                   Color.Gray, 0, ButtonBorderStyle.None,
                                   Color.Gray, 3, ButtonBorderStyle.Solid,
                                   Color.Gray, 3, ButtonBorderStyle.Solid);
        }

        //Timer_Tick_Stop
    }
}
