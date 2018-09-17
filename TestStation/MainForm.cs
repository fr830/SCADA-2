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
using ConnectLib;
using Domain;

namespace TestStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public ConnectForm connectForm;
        public DataLogForm logForm;
        public UnitPIDForm unitPIDForm;
        public TestForm testForm;
        public ManagentForm managentForm;
        public AlarmForm alarmForm;
        public static SQLBroke broker;  //SQL server
        private EventHandler ConnectStatusEventHandler;
        private event EventHandler SendAuthority;
        private event EventHandler SendDelayTime;
        private LoadForm loginForm;
        private int TimerDelay;
        private string UserName = "";
        private string PassWird = "";
        private string Auth = "";
        private delegate void LabStatusChangedel(string status,string TextColor);
        private delegate void LabUnitStatusChangedel(string status, string TextColor,bool Open);
        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Focus();
            broker = new SQLBroke("Data");
            if (!broker.Login(UserName, PassWird).CheckAuthority)
            {
                if (loginForm == null)
                {
                    loginForm = new LoadForm();
                    loginForm.CheckAuthoruty += LoginCheck;  //註冊事件給loginform,在loginform有人登入時,傳回一個是否符合認證的布林
                    this.SendAuthority += loginForm.ReceiveAuthority;  //註冊事件給loginform,在loginform認證登入者後,將登入者資料丟回
                }
                SendAuthority(this, new AuthorityEvent() { UserName = this.UserName, Password = this.PassWird, Authority = this.Auth });//觸發事件,告知現在form1登入者的身分
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.SetDesktopLocation(450, 300);
                loginForm.ShowDialog();
            }
            TimerDelay = 1000;
        }
        //Button_Click_Event_Start
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (connectForm == null)
            {
                connectForm = new ConnectForm();
            }
            ConnectStatusEventHandler += connectForm.GetConnectStatus;
            connectForm.sockethandler += SocketError;
            connectForm.UnitSocketHandler += UnitSocketStatus;
            FormShow(connectForm, panel1);
            ConnectStatusEventHandler(this,new ConnectStatusEvent() {ConnectStatus = Lab_StationConnectStatus.Text,authority = Auth,UnitConnectStatus = Lab_UnitConnectStatus.Text});
        }
        private void Btn_System_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void Btn_DataBase_Click(object sender, EventArgs e)
        {
            if (logForm == null)
            {
                logForm = new DataLogForm();
            }
            ConnectStatusEventHandler += logForm.GetConnectStatus;
            logForm.SendTimerDelay += ReceiveTimerDelay;
            FormShow(logForm, panel1);
            ConnectStatusEventHandler(this, new ConnectStatusEvent() { ConnectStatus = Lab_StationConnectStatus.Text, UnitConnectStatus = Lab_UnitConnectStatus.Text ,UnitConnectStatusColor = Lab_UnitConnectStatus .ForeColor.Name});
        }
        private void Btn_Unit_Click(object sender, EventArgs e)
        {
            if (Lab_UnitConnectStatus.Text == "機組PLC在線")
            {
                if (unitPIDForm == null)
                {
                    unitPIDForm = new UnitPIDForm();
                }
                ConnectStatusEventHandler += unitPIDForm.GetConnectStatus;
                SendDelayTime += unitPIDForm.GetDelayTime;
                unitPIDForm.Owner = this;
                unitPIDForm.Show();
                ConnectStatusEventHandler(this, new ConnectStatusEvent() { ConnectStatus = Lab_StationConnectStatus.Text, UnitConnectStatus = Lab_UnitConnectStatus.Text, UnitConnectStatusColor = Lab_UnitConnectStatus.ForeColor.Name, UserName = Lab_UserName.Text, authority = Lab_Auth.Text });
                SendDelayTime(this, new TimerDelayEvent() { DelayTime = TimerDelay });
                this.Hide();
            }
            else
            {
                MessageBox.Show("您尚未與機組PLC進行連線或是連線已經終止", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Btn_Station_Click(object sender, EventArgs e)
        {
            if (testForm == null)
            {
                testForm = new TestForm();
            }
            testForm.Show();
            ConnectStatusEventHandler += testForm.GetConnectStatus;
            ConnectStatusEventHandler(this, new ConnectStatusEvent() { ConnectStatus = Lab_StationConnectStatus.Text, UnitConnectStatus = Lab_UnitConnectStatus.Text });
            SendDelayTime += testForm.GetDelayTime;
            SendDelayTime(this, new TimerDelayEvent() { DelayTime = TimerDelay });            
            this.Hide();
        }
        private void Btn_Managet_Click(object sender, EventArgs e)
        {
            if (Lab_Auth.Text == "管理員" | Lab_Auth.Text == "創造者")
            {
                if (managentForm == null)
                {
                    managentForm = new ManagentForm();
                }
                managentForm.StartPosition = FormStartPosition.Manual;
                managentForm.SetDesktopLocation(300, 200);
                managentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您沒有這個操作權限!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Btn_Alarm_Click(object sender, EventArgs e)
        {
            if (Lab_UnitConnectStatus.Text == "機組PLC在線")
            {
                if (alarmForm == null)
                {
                    alarmForm = new AlarmForm();
                }
                alarmForm.StartPosition = FormStartPosition.Manual;
                alarmForm.SetDesktopLocation(700, 40);
                alarmForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("您尚未與機組PLC進行連線或是連線已經終止", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Btn_Authority_Click(object sender, EventArgs e)
        {
            SendAuthority(this, new AuthorityEvent() { UserName = this.UserName, Password = this.PassWird, Authority = this.Auth });
            loginForm.ShowDialog();
        }
        //Button_Click_Event_Stop

        //Customize_Function_Start
        public void SocketError(object ender,EventArgs e)
        {
            SocketDisconnectEvent arg = (SocketDisconnectEvent)e;   
            CalLabStatusChangeDel(arg.status,arg.TextColor);            
        }
        public void UnitSocketStatus(object ender, EventArgs e)
        {
            SocketDisconnectEvent arg = (SocketDisconnectEvent)e;
            CalLabUnitStatusChangeDel(arg.status, arg.TextColor,arg.OpenButton);
        }
        //錯誤消息來自讀取試車站PLC資訊的線程,如果直接修改UI線程會造成跨線程錯誤
        private void LabStatusChange(string Status,string TextColor)
        {
            Lab_StationConnectStatus.Text = Status;
            Lab_StationConnectStatus.ForeColor = Color.FromName(TextColor);
        }
        private void LabUnitStatusChange(string Status, string TextColor,bool OpenButton)
        {
            Lab_UnitConnectStatus.Text = Status;
            Lab_UnitConnectStatus.ForeColor = Color.FromName(TextColor);
        }
        private void CalLabStatusChangeDel(string str,string textcolor)
        {
            this.Invoke(new LabStatusChangedel(LabStatusChange),new object[] { str ,textcolor});
        } //呼叫委派
        private void CalLabUnitStatusChangeDel(string str, string textcolor,bool OpenButton)
        {
            this.Invoke(new LabUnitStatusChangedel(LabUnitStatusChange), new object[] { str, textcolor ,OpenButton});
        } //呼叫委派    
        private void FormShow(Form form, Panel Panel)
        {
            Panel.SuspendLayout();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            Panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            Panel.ResumeLayout();
            Panel.PerformLayout();
            form.Show();
        }    //將指定的form增加到panel上的函式
        private void LoginCheck(object sender, EventArgs e)
            {
                AuthorityCheckEvent arg = e as AuthorityCheckEvent;
                this.UserName = arg.UserName;
                this.PassWird = arg.Password;
                this.Auth = arg.AuthorityManagent;
                Lab_Auth.Text = this.Auth;
                Lab_UserName.Text = this.UserName;
            }  //確認使用者是否為合法登入   
        private void ReceiveTimerDelay(object sender, EventArgs e)
        {
            TimerDelayEvent arg = (TimerDelayEvent)e;
            TimerDelay = arg.DelayTime;       
        }
        private void Lab_StationConnectStatus_TextChanged(object sender, EventArgs e)
        {
            if (ConnectStatusEventHandler != null )
            {
                ConnectStatusEventHandler(this, new ConnectStatusEvent() { ConnectStatus = Lab_StationConnectStatus.Text, UnitConnectStatus = Lab_UnitConnectStatus.Text, UnitConnectStatusColor = Lab_UnitConnectStatus.ForeColor.Name });
            }
        }
        private void Lab_UnitConnectStatus_Click(object sender, EventArgs e)
        {
            if (ConnectStatusEventHandler != null )
            {
                ConnectStatusEventHandler(this, new ConnectStatusEvent() { ConnectStatus = Lab_StationConnectStatus.Text, UnitConnectStatus = Lab_UnitConnectStatus.Text, UnitConnectStatusColor = Lab_UnitConnectStatus.ForeColor.Name });
            }
        }


        //Customize_Function_Stop
    }
}
