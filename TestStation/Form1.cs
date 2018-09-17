using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectLib;
using Domain;
using System.Threading;
using System.Net.Sockets;

namespace TestStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static short[] StationDataBuffer = new short[20]; 
        public static ReaderWriterLock RWLock = new ReaderWriterLock();
        private Thread StationTread;
        private bool StationConnectStatic;
        public static MainForm mainForm;
        private EventHandler sockethandler;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.SetDesktopLocation(480,250);
        }        
        private void ConnectToStation()
        {
            try
            {
                ModbusClient StationClient = new ModbusClient("192.168.1.3");
                StationConnectStatic = true;
                while (true)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        RWLock.AcquireWriterLock(2000);
                        StationClient.ReadHoldRegister(1, 0, 20).CopyTo(StationDataBuffer, 0);
                    }
                    catch (SocketException)
                    {
                        sockethandler(this, new SocketDisconnectEvent() { status = "與試車站連線中斷", TextColor = "Red" });
                        StationClient.Disconnect();
                        break;
                    }
                    finally
                    {                        
                        if(RWLock.IsWriterLockHeld)
                           RWLock.ReleaseWriterLock();
                    }
                }
            }
            catch (SocketException)
            {
                StationConnectStatic = false;
            }            
        }
        private void ConnectEvent()
        {
            StationTread = new Thread(ConnectToStation);
            StationTread.Start();
            label1.Text = "與試車站嘗試連結中...";
            StationTread.Join(TimeSpan.FromSeconds(4));
            if (mainForm == null)
            {
                mainForm = new MainForm();
                sockethandler += mainForm.SocketError;
            }
                if (StationConnectStatic)
                {
                    this.Hide();
                    mainForm.Show();
                    sockethandler(this, new SocketDisconnectEvent() { status = "試車站PLC在線", TextColor = "WhiteSmoke" });                  
                }
                else
                {
                    if (MessageBox.Show("未與試車站建立通訊連結\n是否要繼續執行?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                      this.Hide();
                      mainForm.Show();
                      sockethandler(this, new SocketDisconnectEvent() { status = "未與試車站建立連結",TextColor ="Red"});
                      StationTread.Abort();
                    }
                    else
                    {
                        Environment.Exit(Environment.ExitCode);
                    }
                } 
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            ConnectEvent();
        }
    }
}
