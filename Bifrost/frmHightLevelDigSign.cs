using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class frmHightLevelDigSign : DevComponents.DotNetBar.Office2007Form
    {
        string Sql;   //Sql���
        string STYPE;

        private string Userid;  

        public frmHightLevelDigSign()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strType">�ܴ�ҽ�� D  �ϼ�ҽ�� H</param>
        public frmHightLevelDigSign(string strType, string userid)
        {
            InitializeComponent();
            STYPE = strType;
            Userid = userid;

            label3.Visible = false;
            panel2.Visible = false;

            if (STYPE == "D")
            {
                this.Text = "�ܴ�ҽ����ǩ";
                this.Height = this.Height - panel2.Height+10;
            }
            else if (STYPE == "")
            {
                this.Text = "�ϼ�ҽʦǩ��";
                this.Height = this.Height - panel2.Height+10;
            }
            else
            {

                this.Text = "ҽʦǩ��";
                if (userid != "")
                {
                    label3.Visible = true;
                    panel2.Visible = true;
                    txtAccount.ReadOnly = true;
                    DataSet ds_account = App.GetDataSet("select a.account_name from t_account a inner join t_account_user b on a.account_id=b.account_id where b.user_id=" + userid + "");
                    if (ds_account != null)
                    {
                        if (ds_account.Tables[0].Rows.Count > 0)
                            txtAccount.Text = ds_account.Tables[0].Rows[0][0].ToString();
                        else
                            App.MsgWaring("ԭǩ���ʺſ��ܲ����ڻ�����");
                    }
                    else
                    {
                        App.MsgWaring("ԭǩ���ʺſ��ܲ����ڻ�����");
                    }
                }
                else
                {
                    this.Height = this.Height - panel2.Height + 10;
                }
                
            }

        }       

        
        private void frmHightLevelSign_Load(object sender, EventArgs e)
        {
            cboDigType.SelectedIndex = 0;
        }

        /// <summary>
        /// ȷ��ǩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {

            if (STYPE != "S")
            {
                /*
                 * �ж��Ƿ���ҽ���ʺ�,���޸�ҽ��ǩ���Ĳ���
                 */               
                SaveSign(STYPE, txtAccount.Text.ToUpper(), txtPassword.Text);
            }
            else
            {
                /*
                 * �޸�ҽ��ǩ���Ĳ���
                 */                
                if (Userid!="")
                  SaveSign(STYPE, txtNewAccount.Text.ToUpper(), txtNewPassword.Text);
                else
                  SaveSign(STYPE, txtAccount.Text.ToUpper(), txtPassword.Text);

            }
        }

        /// <summary>
        /// ȡ��ǩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.DocSign = null;
            this.Close();
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (STYPE != "S")
                    btnSure_Click(sender, e);
                else
                    txtNewAccount.Focus();
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtAccount.Text.ToUpper() != "")
            {
                string strName = App.ReadSqlVal("select b.user_name from t_account_user a inner join T_USERINFO b on a.user_id=b.user_id inner join T_ACCOUNT c on c.account_id=a.account_id where c.account_name='" + txtAccount.Text.ToUpper() + "'", 0, "user_name");
                if (strName != null)
                {
                    lblName.Text = "���������ߣ�" + strName;
                    lblName.ForeColor = Color.Black;
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

        /// <summary>
        /// ����ǩ��
        /// </summary>
        /// <param name="Type">����</param>
        /// <param name="account">�ʺ�</param>
        /// <param name="pass">����</param>
        private void SaveSign(string Type,string account,string pass)
        {
            if (Type == "S" && Userid!="")
            {
                DataSet ds_old_account = App.GetDataSet("select a.account_id from T_ACCOUNT a where a.ACCOUNT_NAME='" + txtAccount.Text.ToUpper() + "' and a.PASSWORD='" + Encrypt.EncryptStr(txtPassword.Text) + "'");
                if (ds_old_account != null)
                {
                    if (ds_old_account.Tables[0].Rows.Count < 1)
                    {
                        App.Msg("ԭ������ʺŲ���ȷ��");
                        return;
                    }
                }
                else
                {
                    App.Msg("ԭ������ʺŲ���ȷ��");
                    return;
                }
            }


            App.DocSign = null;
            string sqltype = "select a.role_type,t.kind from T_ROLE a inner join T_ACC_ROLE b on a.role_id=b.role_id inner join T_account t on b.account_id=t.account_id  where t.account_name='" + account + "'";

            DataSet dsettype = App.GetDataSet(sqltype);
            if (dsettype.Tables[0].Rows.Count > 0)
            {
                if (dsettype.Tables[0].Rows[0][0].ToString().Trim() != "D")
                {
                    App.MsgWaring("���ʺŲ���ҽ���ʺţ�");
                    return;
                }
            }
            else
            {
                if (STYPE == "S")
                {
                    this.txtNewPassword.Text = "";
                    this.txtNewAccount.Focus();
                }
                else
                {
                    this.txtPassword.Text = "";
                    this.txtAccount.Focus();
                }
                App.Msg("���Ż����벻��ȷ��");
                return;
            }

            string AccountType = dsettype.Tables[0].Rows[0][1].ToString().Trim();

            if (Type != "S")
            {
                if (AccountType != "52")
                {
                    if (AccountType == "53")
                    {
                        App.Msg("���ʺ���ʵϰ���ʺţ�������ǩ�������飡");
                        return;
                    }
                    else if (AccountType == "54")
                    {
                        App.Msg("���ʺ��ǽ������ʺţ�������ǩ�������飡");
                        return;
                    }
                    else if (AccountType == "70")
                    {
                        App.Msg("���ʺ�����תҽ���ʺţ�������ǩ�������飡");
                        return;
                    }
                    else if (AccountType == "7921")
                    {
                        App.Msg("���ʺ����о����ʺţ�������ǩ�������飡");
                        return;
                    }
                }

            }

           
                Sql = "select c.user_id,c.user_name,c.u_tech_post,d1.name as u_tech_post_name,c.u_position,d2.name as u_position_name from T_ACCOUNT a inner join t_account_user b on a.account_id=b.account_id inner join T_USERINFO c on b.user_id=c.user_id inner join T_DATA_CODE d1 on c.u_tech_post=d1.id inner join T_DATA_CODE d2 on c.u_position=d2.id where a.ACCOUNT_NAME='" + account + "' and a.PASSWORD='" + Encrypt.EncryptStr(pass) + "'";

                DataSet ds = App.GetDataSet(Sql);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        App.DocSign = new Class_DocSign();
                        App.DocSign.Userid = ds.Tables[0].Rows[0]["user_id"].ToString();
                        App.DocSign.Username = ds.Tables[0].Rows[0]["user_name"].ToString();
                        App.DocSign.U_tech_post = ds.Tables[0].Rows[0]["u_tech_post"].ToString();
                        App.DocSign.U_tech_post_name = ds.Tables[0].Rows[0]["u_tech_post_name"].ToString();
                        App.DocSign.U_position = ds.Tables[0].Rows[0]["u_position"].ToString();
                        App.DocSign.U_position_name = ds.Tables[0].Rows[0]["u_position_name"].ToString();
                        App.DocSign.Digtype = cboDigType.Text;
                        this.Close();
                    }
                    else
                    {
                        if (STYPE == "S")
                        {
                            this.txtNewPassword.Text = "";
                            this.txtNewAccount.Focus();
                        }
                        else
                        {
                            this.txtPassword.Text = "";
                            this.txtAccount.Focus();
                        }
                        App.Msg("���Ż����벻��ȷ��");
                    }
                }
                else
                {
                    if (STYPE == "S")
                    {
                        this.txtNewPassword.Text = "";
                        this.txtNewAccount.Focus();
                    }
                    else
                    {
                        this.txtPassword.Text = "";
                        this.txtAccount.Focus();
                    }
                    App.Msg("���Ż����벻��ȷ��");
                }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNewAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtNewAccount.Text.ToUpper() != "")
            {
                string strName = App.ReadSqlVal("select b.user_name from t_account_user a inner join T_USERINFO b on a.user_id=b.user_id inner join T_ACCOUNT c on c.account_id=a.account_id where c.account_name='" + txtNewAccount.Text.ToUpper() + "'", 0, "user_name");
                if (strName != null)
                {
                    lblNewName.Text = "���������ߣ�" + strName;
                    lblNewName.ForeColor = Color.Black;
                }
                else
                {
                    lblNewName.Text = "�޴˹��Ż򹤺���δ����";
                    lblNewName.ForeColor = Color.Red;
                }
            }
            else
            {
                lblNewName.Text = "";
            }
        }

        private void txtNewAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPassword.Focus();
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSure_Click(sender, e);
            }
        }
    }
}