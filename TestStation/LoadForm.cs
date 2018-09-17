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

namespace TestStation
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }
        string Authority;
        public EventHandler CheckAuthoruty;
        private void LoadForm_Load(object sender, EventArgs e)
        {
            Txt_Password.PasswordChar = '*';  //隱藏密碼輸入
            if (this.Authority != "")  //如果form1的權限顯示為空,判定當下狀況為未登入
            {
                Btn_Login.Text = "登出";
            }
            else
            {
                Btn_Login.Text = "登入";
            }
        }
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Btn_Login.Text == "登入")
            {
                AuthorityManagent managent = MainForm.broker.Login(Txt_UserName.Text, Txt_Password.Text);//抓取sql server中儲存的登入權限
                if (managent.CheckAuthority)  // 如果輸入的帳號密碼符合sql server中登錄的資訊,則將此form關閉
                {
                    CheckAuthoruty(this, new AuthorityCheckEvent() { UserName = managent.UserName, Password = managent.Password, AuthorityManagent = managent.Auth.ToString() });  //觸發事件,告知form1當前的登入者是誰
                    this.Close();
                }
                else if (Txt_UserName.Text == "WhosYourDaddy")  //開啟創造者模式
                {
                    CheckAuthoruty(this, new AuthorityCheckEvent() { UserName = "創造模式", Password = "", AuthorityManagent = "創造者" });
                    this.Close();
                }
                else
                {
                    MessageBox.Show("請確認輸入的帳號及密碼");
                }
            }
            else
            {
                CheckAuthoruty(this, new AuthorityCheckEvent() { UserName = "", Password = "", AuthorityManagent = "" });
                Btn_Login.Text = "登入";
                Txt_Password.Text = "";
                this.Authority = "";
            }
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            if (Authority == "")
            {
                if (MessageBox.Show("在未登入的狀態下離開將會強制關閉程式\r\n您確定要進行該動作嗎?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Environment.Exit(Environment.ExitCode);
                }
            }
            else
            {
                this.Close();
            }
        }
        public void ReceiveAuthority(object sender, EventArgs e)
        {
             AuthorityEvent arg = e as AuthorityEvent;
            this.Txt_UserName.Text = arg.UserName;
            this.Txt_Password.Text = arg.Password;
            this.Authority = arg.Authority;
        } //如果從form1按鈕開啟這個form,則註冊一個事件將form1現在的登入者資訊傳回
    }
}
