using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
namespace BifrostMainPro
{
    public partial class frmPassWordConfirmDel : DevComponents.DotNetBar.Office2007Form
    {       
        public frmPassWordConfirmDel()
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
        }

        private void frmPassWordConfirm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       /// <summary>
       /// 账号注销        
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (Encrypt.EncryptStr(textBox1.Text) == App.UserAccount.Password)
            {
                //注销操作
                string[] sqls = new string[2];
                sqls[0] = "delete from t_acc_role_range a where a.acc_role_id in (select b.id from t_acc_role b where b.account_id=" + App.UserAccount.Account_id + ")";
                sqls[1] = "delete from t_acc_role c where c.account_id=" + App.UserAccount.Account_id + "";

                if (App.ExecuteBatch(sqls) > 0)
                {
                    App.Msg("帐号注销成功！");
                    LogHelper.Account_SystemLog(App.UserAccount.Account_id, "注销", "");
                    frmMain.isReset = true;
                    Application.Restart();
                }
            }
            else
            {
                App.MsgWaring("密码不正确！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
