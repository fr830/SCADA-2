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
using ConnectLib;
using SupToolLib;
using System.Threading;
using System.Net.Sockets;
using System.Collections;

namespace TestStation
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }
        public static short[] UnitDataBuffer = new short[68]; 
        private Thread StationConnectThread;
        public EventHandler sockethandler;
        public EventHandler UnitSocketHandler;
        public static ReaderWriterLock RWLock2 = new ReaderWriterLock();
        private Thread UnitConnectThread;
        private bool DisConnectToStation;
        private bool DisConnectToUnit;
        private bool[] Singal = new bool[16];
        private short PCControl;
        
        private string[] TripType1 = new string[32] {"Trip-APR欠逆相","Trip-APR過壓"
                                                    ,"Trip-膨脹機軸承供油異常(開關)","Trip-膨脹機轉子供油異常"
                                                    ,"Trip-油位過低(開關)","Trip-油泵過載(MS)","Trip-MC未動作"
                                                    ,"Trip-保護電驛綜合跳脫","Trip-警急開關被按下","Trip-高壓過高(開關)"
                                                    ,"Trip-低壓過高(油分開關)","Trip-低壓過高(冷凝器開關)"
                                                    ,"Trip-熱水流量不足(開關)","Trip-冷水流量不足(開關)"
                                                    ,"Trip-變頻器異常","Trip-液泵未運轉","T-DI8"
                                                    ,"T-DI9","T-DI10","T-DI11","T-DI12","T-DI13","T-DI14","T-DI15","Trip-馬達線圈過溫(PTC)","T-DI1"
                                                    ,"T-DI2","T-DI3","T-DI4","T-DI5","T-DI6","T-DI7"};
        private string[] TripType2 = new string[32] {"Trip-膨脹機入口壓過高","Trip-膨脹機出口壓過高","Trip-電流過高"
                                                    ,"Trip-發電功率過高","Trip-機組震動過大","Trip-發電機震動過大"
                                                    ,"Trip-熱水溫度過低","Trip-發電功率過低","Trip-膨脹機溫度感測器異常","Trip-膨脹機壓力感測器異常"
                                                    ,"Trip-轉速計異常","Trip-與電表通訊異常","Trip-與震動計通訊異常"
                                                    ,"Trip-膨脹機轉速過高","Trip-熱源溫度過高","Trip-冷源溫度過高","T-AI8"
                                                    ,"T-AI9","T-AI10","T-AI11","T-AI12","T-AI13","T-AI14","T-AI15","Trip-電網頻率過低"
                                                    ,"T-AI1","T-AI2","T-AI3","T-AI4","T-AI5","T-AI6","T-AI7"};


        private delegate void ButtonChangeDel(Button TrueButton, Button FalseButton,Label label);
        //Button_Click_Event_Start
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Btn_StationConnect_Click(object sender, EventArgs e)
        {
            Lab_StationConnecting.Visible = true;
            StationConnectThread = new Thread(new ParameterizedThreadStart(ConnectToStation));
            StationConnectThread.Start(Txt_StationIP.Text);
            Btn_StationDisconnect.Focus();
        }
        private void Btn_StationDisconnect_Click(object sender, EventArgs e)
        {
            DisConnectToStation = false;
            sockethandler(this, new SocketDisconnectEvent() { status = "與試車站連線中斷", TextColor = "Red" });
            Btn_StationConnect.Enabled = true;
            Btn_StationDisconnect.Enabled = false;
        }
        private void Btn_UnitConnect_Click(object sender, EventArgs e)
        {
            Lab_UnitConnecting.Visible = true;
            UnitConnectThread = new Thread(new ParameterizedThreadStart(ConnectToUnit));
            UnitConnectThread.Start(Txt_UnitIP.Text);
            Btn_Exit.Focus();
        }
        private void Btn_UnitDisconnect_Click(object sender, EventArgs e)
        {
            DisConnectToUnit = false;
            UnitSocketHandler(this, new SocketDisconnectEvent() { status = "與機組連線中斷", TextColor = "Red" });
            Btn_UnitConnect.Enabled = true;
            Btn_UnitDisconnect.Enabled = false;
        }
        //Button_Click_Event_Stop
        //Button_Paint_Event_Start
        private void Btn_StationConnect_Paint(object sender, PaintEventArgs e)
        {
            EnableButton((Button)sender, e);
        }
        private void Btn_StationDisconnect_Paint(object sender, PaintEventArgs e)
        {
            EnableButton((Button)sender, e);
        }
        private void Btn_UnitConnect_Paint(object sender, PaintEventArgs e)
        {
            EnableButton((Button)sender, e);
        }
        private void Btn_UnitDisconnect_Paint(object sender, PaintEventArgs e)
        {
            EnableButton((Button)sender, e);
        }
        //Button_Paint_Event_Stop
        
        //Customize_Function_Start
        public void GetConnectStatus(object sneder,EventArgs e)
        {
                ConnectStatusEvent arg = (ConnectStatusEvent)e;
                switch (arg.authority)
                {
                    case "管理員":
                        if (arg.ConnectStatus == "與試車站連線中斷" || arg.ConnectStatus == "未與試車站建立連結")
                        {
                            Btn_StationConnect.Enabled = true;
                            Btn_StationDisconnect.Enabled = false;
                        }
                        else
                        {
                            Btn_StationConnect.Enabled = false;
                            Btn_StationDisconnect.Enabled = true;
                        }
                        Txt_UnitIP.Enabled = true;
                        Txt_UnitPort.Enabled = true;
                        Txt_StationIP.Enabled = true;
                        Txt_StationPort.Enabled = true;
                        break;
                    case "操作者":
                        if (arg.ConnectStatus == "與試車站連線中斷" || arg.ConnectStatus == "未與試車站建立連結")
                        {
                            Btn_StationConnect.Enabled = true;
                            Btn_StationDisconnect.Enabled = false;
                        }
                        else
                        {
                            Btn_StationConnect.Enabled = false;
                            Btn_StationDisconnect.Enabled = true;
                        }
                        Txt_UnitIP.Enabled = true;
                        Txt_UnitPort.Enabled = true;
                        break;
                    case "訪客":
                        Btn_StationConnect.Enabled = false;
                        Btn_StationDisconnect.Enabled = false;
                        Btn_UnitConnect.Enabled = false;
                        Btn_UnitDisconnect.Enabled = false;
                        break;
                }

        }
        private void EnableButton(Button btn,PaintEventArgs e)
        {
            btn.ForeColor = btn.Enabled == false ? Color.Gray : Color.WhiteSmoke;
            Brush drawBursh = new SolidBrush(btn.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            btn.Text = string.Empty;
            e.Graphics.DrawString((string)btn.Tag, btn.Font, drawBursh, e.ClipRectangle, sf);
            drawBursh.Dispose();
            sf.Dispose();
        }
        private void ConnectToStation(object IP)
        {
            ModbusClient StationClient;
            try
            {
                StationClient = new ModbusClient((string)IP);
                sockethandler(this, new SocketDisconnectEvent() { status = "試車站PLC在線", TextColor = "WhiteSmoke" });
                CallButtonChangeDel(Btn_StationDisconnect, Btn_StationConnect, Lab_StationConnecting);
                DisConnectToStation = true;
                while (true)
                {
                    if (DisConnectToStation)
                    {
                        Thread.Sleep(1000);
                        Form1.RWLock.AcquireWriterLock(2000);
                        try
                        {
                            StationClient.ReadHoldRegister(1, 1, 20).CopyTo(Form1.StationDataBuffer, 0);
                        }
                        catch (SocketException)
                        {
                            sockethandler(this, new SocketDisconnectEvent() { status = "與試車站連線中斷", TextColor = "Red" });
                            CallButtonChangeDel(Btn_StationConnect, Btn_StationDisconnect, Lab_StationConnecting);
                            StationClient.Disconnect();
                            break;
                        }
                        finally
                        {
                            Form1.RWLock.ReleaseWriterLock();
                        }
                    }
                    else
                    {
                        StationClient.Disconnect();
                        break;
                    }
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("未取得與伺服器的連線\n請檢察線路及IP是否正確", "連接錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sockethandler(this, new SocketDisconnectEvent() { status = "未與試車站建立連結", TextColor = "Red" });
                CallButtonChangeDel(Btn_StationConnect, Btn_StationDisconnect, Lab_StationConnecting);
            }
            //Customize_Function_Stop
        }
        private void ConnectToUnit(object IP)
        {
            try
            {
                ModbusClient UintClient = new ModbusClient((string)IP);
                UnitSocketHandler(this, new SocketDisconnectEvent() { status = "機組PLC在線", TextColor = "WhiteSmoke", OpenButton =true });
                CallButtonChangeDel(Btn_UnitDisconnect, Btn_UnitConnect, Lab_UnitConnecting);
                DisConnectToUnit = true;
                while (true)
                {
                    if (DisConnectToUnit)
                    {
                        Thread.Sleep(1000);
                        RWLock2.AcquireWriterLock(2000);
                        try
                        {
                            UintClient.ReadHoldRegister(1, 0, 68).CopyTo(UnitDataBuffer, 0);
                          //  TripArray.GetTrip(UnitDataBuffer[51], UnitDataBuffer[50], 0, 0, 0, 0,UnitDataBuffer[51], UnitDataBuffer[50], MainForm.broker.TripValueSearch("OldTrip", "UnitTrip"), TripType1, DateTime.Now,MainForm.broker);
                            TripArray.GetTrip(UnitDataBuffer[51], UnitDataBuffer[50], UnitDataBuffer[53], UnitDataBuffer[52], UnitDataBuffer[53], UnitDataBuffer[52], MainForm.broker.TripValueSearch("OldTrip", "UnitTrip"), MainForm.broker.TripValueSearch("OldTrip2", "UnitTrip"), TripType1, TripType2, DateTime.Now, MainForm.broker);
                            if (PCControl > 0)
                            {
                                for (int i = 0; i < Singal.Length; i++)
                                {
                                    UintClient.WriteSingleCoil(1, (ushort)(8001 + i), Singal[i]);
                                    Singal[i] = false;
                                }
                                PCControl --;
                            }                    
                        }
                        catch (SocketException)
                        {
                            UnitSocketHandler(this, new SocketDisconnectEvent() { status = "與機組連線中斷", TextColor = "Red" });
                            CallButtonChangeDel(Btn_UnitConnect, Btn_UnitDisconnect, Lab_UnitConnecting);
                            UintClient.Disconnect();
                            break;
                        }
                        finally
                        {
                            RWLock2.ReleaseWriterLock();
                        }
                    }
                    else
                    {
                        UintClient.Disconnect();
                        break;
                    }
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("未取得與伺服器的連線\n請檢察線路及IP是否正確", "連接錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnitSocketHandler(this, new SocketDisconnectEvent() { status = "未與機組建立連結", TextColor = "Red" });
                CallButtonChangeDel(Btn_UnitConnect, Btn_UnitDisconnect, Lab_UnitConnecting);
            }
        }
        private void ButtonChange(Button TrueButton,Button FalseButton,Label label)
        {
            TrueButton.Enabled = true;
            FalseButton.Enabled = false;
            label.Visible = false;
        }
        private void CallButtonChangeDel(Button TrueButton, Button FalseButton,Label label)
        {
            this.Invoke(new ButtonChangeDel(ButtonChange), new object[] { TrueButton, FalseButton,label });
        }
        public void GetCommandSingal(object sender,EventArgs e)
        {
            SingalTransferEvent arg = (SingalTransferEvent)e;
            for (int i = 0; i < 15; i ++)
            {
                Singal[i] = ((arg.CommandSingal >> i & 1) == 1);
            }
            PCControl = arg.IWantControl;
        }
        //Customize_Function_Stop
    }
}
