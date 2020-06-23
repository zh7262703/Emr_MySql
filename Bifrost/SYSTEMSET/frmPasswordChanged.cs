using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Bifrost
{
    /// <summary>
    /// 密码修改
    /// 创建者：张华
    /// 创建时间：2010-10-15
    /// </summary>
    public partial class frmPasswordChanged : DevComponents.DotNetBar.Office2007Form
    {
        /*
           * 说明：
           * 1.先匹配原密码是否正确。
           * 2.如果原来密码正确的话，匹配新密码两次输入是否正确。
           * 3.修改密码
           */

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPasswordChanged()
        {
            InitializeComponent();
        }

        private void frmPasswordChanged_Load(object sender, EventArgs e)
        {
            txtOldPassword.Focus();
        }

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
          
            if (Encrypt.EncryptStr(txtOldPassword.Text) == App.UserAccount.Password)
            {
                if (txtNewPassword.Text == txtNewPasswordAgin.Text)
                {
                    if (App.UserAccount.CurrentSelectRole != null)
                    {
                        /*
                         * 正式账号修改
                         */
                        App.ExecuteSQL("update t_account set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), "update t_account set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                    }
                    else
                    {
                        /*
                         * 临时账号的修改
                         */
                        App.ExecuteSQL("update T_TEMP_ACCOUNT set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), "update T_TEMP_ACCOUNT set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                    }
                    App.Msg("修改成功！");
                }
                else
                {
                    App.MsgErr("新密码两次输入不一致！");                   
                    txtNewPassword.Text = "";
                    txtNewPasswordAgin.Text = "";
                    txtNewPassword.Focus();
                }
            }
            else
            {
                App.MsgErr("原密码不正确！");
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtNewPasswordAgin.Text = "";
                txtOldPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ucPasswordStrongCheck1.RefleshState(txtNewPassword.Text);
        }
    }
}