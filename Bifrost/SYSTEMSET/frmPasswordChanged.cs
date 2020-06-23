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
    /// �����޸�
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-10-15
    /// </summary>
    public partial class frmPasswordChanged : DevComponents.DotNetBar.Office2007Form
    {
        /*
           * ˵����
           * 1.��ƥ��ԭ�����Ƿ���ȷ��
           * 2.���ԭ��������ȷ�Ļ���ƥ�����������������Ƿ���ȷ��
           * 3.�޸�����
           */

        /// <summary>
        /// ���캯��
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
        /// �޸Ĳ���
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
                         * ��ʽ�˺��޸�
                         */
                        App.ExecuteSQL("update t_account set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), "update t_account set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                    }
                    else
                    {
                        /*
                         * ��ʱ�˺ŵ��޸�
                         */
                        App.ExecuteSQL("update T_TEMP_ACCOUNT set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), "update T_TEMP_ACCOUNT set PASSWORD='" + Encrypt.EncryptStr(txtNewPassword.Text) + "' where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                    }
                    App.Msg("�޸ĳɹ���");
                }
                else
                {
                    App.MsgErr("�������������벻һ�£�");                   
                    txtNewPassword.Text = "";
                    txtNewPasswordAgin.Text = "";
                    txtNewPassword.Focus();
                }
            }
            else
            {
                App.MsgErr("ԭ���벻��ȷ��");
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