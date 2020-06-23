using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.Hook
{
    public partial class FrmPassWordChecked : DevComponents.DotNetBar.Office2007Form
    {
        public bool flag = true;
        public FrmPassWordChecked()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql_account = "select * from T_ACCOUNT where upper(ACCOUNT_NAME)='" + App.UserAccount.Account_name.ToUpper() + "' and PASSWORD='" + Encrypt.EncryptStr(txtPassWord.Text) + "'";
            DataSet ds_account = App.GetDataSet(sql_account);
            if (ds_account != null)
            {
                //密码正确
                if (ds_account.Tables[0].Rows.Count > 0)
                {
                    App.StartHook();
                   
                    if (App.UserAccount.TimeOut_Unit == "分")
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddMinutes(App.UserAccount.TimeOut);
                    }
                    else 
                    {
                        App.UserAccount.Enable_end_time = DateTime.Now.AddSeconds(App.UserAccount.TimeOut);
                    }
                    flag = false;
                    this.Close();
                }
                else
                {
                    App.MsgWaring("您输入的密码不正确！");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (App.Ask("确定要退出程序吗？"))
            {
                Application.Exit();
            }
        }

        private void FrmPassWordChecked_FormClosing(object sender, FormClosingEventArgs e)
        {
            //App.StartHook();

            e.Cancel = flag;
        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}