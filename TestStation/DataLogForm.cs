using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Domain;
namespace TestStation
{
    public partial class DataLogForm : Form
    {
        public DataLogForm()
        {
            InitializeComponent();
        }
        private Thread SQLThread;
        private string UnitConnectStatus;
        private string StationConnectStatus;
        private string[] DataTag = new string[]
        { "時間", "State" , "Rotatoin" , "RotationTwo","Superheat" , "Vrs", "Vst", "Vtr",
          "VLLavg","CurrentR","CurrentS","CurrentT","CurrentAvg","Power","Frquency","PF","kWh1",
          "kWh2","kWh3","kWh4","CondenserP","ExpInletP","ExpOutletP","OilPSpare","FiliterInletP",
          "FiliterOutletP","MotorTankP","PreSP1","PreSp2","PreSP3","LiquidLevel","EavpLevel","OilLevel",
          "LevelSP","HSourceFR","HSinkFR","RefrFR","OilFR","FRSP","PPkW","PPkW2","OilPkW","PPSP","HWInletT",
          "HWOutletT","ExpInletT","ExpOutletT","RefrTankT","FroBearT","RearBearT","OilTankT","MTT1","MTT2",
          "MTT3","MTT4","CWinletT","CWoutletT"
        };
        private string[] StationDataTag = new string[] { "時間","HW_SP_FR" , "HW_BP_FR" , "CW_SP_FR" , "CW_BP_FR", "ST_FR", "ST_Temp", "ST_AF_P",
            "ST_Be_P", "HW_Outlet_Temp", "HW_Inlet_Temp", "CW_Outlet_Temp", "CW_Inlet_Temp", "RTD1", "RTD2", "RTD3", "Spare1", "Spare2",
            "Spare3", "Spare4", "Spare5" };
        public event EventHandler SendTimerDelay;
        private BCPWorker bCPWorker = new BCPWorker();
        //Button_Click_Start
        private void Btn_DataStartLog_Click(object sender, EventArgs e)
        {
            if (CB_Station.Checked || CB_Unit.Checked)
            {
                SQLThread = new Thread(StartLogin);
                SQLThread.Start();
                Btn_DataLogStop.Enabled = true;
                Btn_DataStartLog.Enabled = false;
            }
            Btn_Exit.Focus();
        }
        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            if (CB_Station.Checked)
            {
                bCPWorker.GetDataFromServer("Station", Txt_StationDataPath.Text.Trim());
                Txt_StationDataPath.Text = (string)Txt_StationDataPath.Tag;
                Txt_StationDataPath.ForeColor = Color.Silver;
            }
            else if (CB_Unit.Checked)
            {
                bCPWorker.GetDataFromServer("StationUnit", Txt_UnitDataPath.Text.Trim());
                Txt_UnitDataPath.Text = (string)Txt_UnitDataPath.Tag;
                Txt_UnitDataPath.ForeColor = Color.Silver;
            }
            else
            {
                MessageBox.Show("請至少勾選試車站或是機組");
            }
        }
        private void Btn_StationFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了路徑
            {
                Txt_StationDataPath.Text = folderBrowserDialog1.SelectedPath;//顯示選擇的路徑
                Txt_StationDataPath.ForeColor = Color.WhiteSmoke;
            }
        }
        private void Btn_DataLogStop_Click(object sender, EventArgs e)
        {
            SQLThread.Abort();
            Btn_DataStartLog.Enabled = true;
            Btn_DataLogStop.Enabled = false;
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("將要清除機組與試車站的數據紀錄\n確定要執行嗎?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MainForm.broker.Delete("StationUnit");
                MainForm.broker.Delete("Station");
            }
        }
        //Button_Click_Stop
        //Customize_Function_Start
        private void StartLogin()
        {
            while (true)
            {
                if (CB_Station.Checked)
                {
                    if (StationConnectStatus == "試車站PLC在線")
                    {
                        try
                        {
                            Form1.RWLock.AcquireReaderLock(2000);
                            MainForm.broker.Insert(Form1.StationDataBuffer, "Station", StationDataTag, DateTime.Now);                            
                        }
                        catch (ApplicationException)
                        {

                        }
                        finally
                        {
                            if (Form1.RWLock.IsReaderLockHeld)
                            {
                                Form1.RWLock.ReleaseLock();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("尚未與試車站建立連線", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (CB_Unit.Checked)
                {
                    if (UnitConnectStatus == "機組PLC在線")
                    {
                        try
                        {
                            ConnectForm.RWLock2.AcquireReaderLock(2000);
                            MainForm.broker.Insert(ConnectForm.UnitDataBuffer, "StationUnit", DataTag, DateTime.Now);                            
                        }
                        catch (ApplicationException)
                        {
                        }
                        finally
                        {
                            if(ConnectForm.RWLock2.IsReaderLockHeld)
                               ConnectForm.RWLock2.ReleaseLock();
                        }
                    }
                    else
                    {
                        MessageBox.Show("尚未與機組建立連線", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Thread.Sleep(Convert.ToInt32(Txt_LogTimer.Text));
            }
        }
        public void GetConnectStatus(object sender , EventArgs e)
        {
            ConnectStatusEvent arg = (ConnectStatusEvent)e;
            UnitConnectStatus = arg.UnitConnectStatus;
            StationConnectStatus = arg.ConnectStatus;
        }
        private void Btn_UnitFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判斷是否選擇了路徑
            {
                Txt_UnitDataPath.Text = folderBrowserDialog1.SelectedPath;//顯示選擇的路徑
                Txt_UnitDataPath.ForeColor = Color.WhiteSmoke;
            }
        }
        private void Txt_LogTimer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SendTimerDelay(this, new TimerDelayEvent() { DelayTime = Convert.ToInt32(Txt_LogTimer.Text) });
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入數字");
            }
            catch (OverflowException)
            {
                MessageBox.Show("請輸入0~4,294,967,2955之間的延遲時間");
            }
        }
        //Customize_Function_Stop
    }
}
