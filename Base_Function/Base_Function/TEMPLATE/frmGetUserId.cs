using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    public partial class frmGetUserId : DevComponents.DotNetBar.Office2007Form
    {
        private string User_id="";
        private string Account_id = "";

        public frmGetUserId()
        {
            InitializeComponent();
        }

        private void frmGetUserId_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text.Trim() == "")
            {
                App.Msg("���ʺŲ���Ϊ�գ�");
                txtAccount.Focus();
                return;
            }

            /*
            * �ж��Ƿ���ҽ���ʺ�
            */
            Account_id="";
            string sqltype = "select a.role_type,t.kind,t.account_id from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id inner join T_account t on b.account_id=t.account_id  where upper(t.account_name)=upper('" + txtAccount.Text + "')";            
            DataSet dsettype = App.GetDataSet(sqltype);
            
            if (dsettype.Tables[0].Rows.Count > 0)
            {
                if (dsettype.Tables[0].Rows[0][0].ToString().Trim() != "D")
                {
                    App.MsgWaring("���ʺŲ���ҽ���ʺţ�");
                    return;
                }
                else
                {
                    Account_id = dsettype.Tables[0].Rows[0]["account_id"].ToString().Trim();
                }
            }
            else
            {               
                this.txtAccount.Focus();
                App.Msg("���Ż����벻��ȷ��");
                return;
            }

            if (!App.IsHigherMasterDoctor(User_id))
            {
                if (App.Ask("�Ƿ�ɾ����ҽ��������������Сģ�壿"))
                {
                    //Account_id
                    if (App.ExecuteSQL("delete from t_tempplate t where t.tempplate_level='P' and t.temptype='S' and t.section_id="+App.UserAccount.CurrentSelectRole.Section_Id+" and t.Creator_Id=" + Account_id + "")>0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                        this.Close();
                    }
                    else
                    {
                        App.MsgErr("����ʧ��,���ܵ�ǰ�û��ڸÿ���û�д�����Сģ�壡");
                    }
                }
            }
            else
            {
                App.MsgErr("�˹���ֻ��ɾ���ÿ����������¼���ҽ����������Сģ�壡");
            }                       
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            
            if (txtAccount.Text != "")
            {
                User_id = "";
                DataSet ds = App.GetDataSet("select b.user_name,b.user_id from t_account_user a inner join T_USERINFO b on a.user_id=b.user_id inner join T_ACCOUNT c on c.account_id=a.account_id where c.account_name='" + txtAccount.Text + "'");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblName.Text = "���������ߣ�" + ds.Tables[0].Rows[0]["user_name"].ToString();
                        lblName.ForeColor = Color.Black;
                        User_id = ds.Tables[0].Rows[0]["user_id"].ToString();
                    }
                    else
                    {
                        lblName.Text = "�޴˹��Ż򹤺���δ����";
                        lblName.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblName.Text = "�޴˹��Ż򹤺���δ����";
                    lblName.ForeColor = Color.Red;
                }
            }
            else
            {
                lblName.Text = "";
            }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSure_Click(sender, e);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    btnSure_Click(sender, e);
        }
    }
}