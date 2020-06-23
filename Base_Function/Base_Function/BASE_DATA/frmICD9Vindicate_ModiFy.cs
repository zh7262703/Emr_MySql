using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class frmICD9Vindicate_ModiFy : Office2007Form
    {
        string ID = "";         

        public frmICD9Vindicate_ModiFy()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ��ȡICD10����
        /// </summary>
        /// <param name="gname">����</param>
        /// <param name="id">����</param>
        /// <param name="Codeicd10">ICD10����</param>
        public frmICD9Vindicate_ModiFy(string gname,string id,string Codeicd9)
        {
            InitializeComponent();
            ID = id;
            txtICD9name.Text = gname;
            txtICD9code.Text = Codeicd9;
            if (ID.Trim() != "")
            {                
                this.btnAdd.Enabled = false;
            }
            else
            {
                this.btnAdd.Enabled = true;
            }
            txtICD9name.Focus();
        }

        private void frmICD10Vindicate_ModiFy_Load(object sender, EventArgs e)
        {
            txtICD9name.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cxbisDiagnoseCode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (ID.Trim() == "")
            {

                string sysTemcode = App.GenId("T_OPER_DEF", "DIAG_ID").ToString();
                //���                                                                      
                string insertSql = "insert into T_OPER_DEF values('" + sysTemcode + "','" + txtICD9name.Text + "','" + txtspellCode.Text +
                    "','" + txtWbCode.Text + "','Y','" + txtICD9code.Text + "')";
                if (App.ExecuteSQL(insertSql) > 0)
                {
                    App.Msg("��ӳɹ���");
                    ShowEClear(); 
                }
                else
                {
                    App.MsgErr("���ʧ�ܣ�����ֵ�Ƿ�Ϊ�գ�");
                }
            }
            else
            {
                //�޸�                
                string updateSql = "update T_OPER_DEF set name='" + txtICD9name.Text + "',shortcut1='" + txtspellCode.Text +
                    "',shortcut2='" + txtWbCode.Text + "',is_icd9='Y',icd9='" + txtICD9code.Text + "' where diag_id='" + ID + "'";
                if (App.ExecuteSQL(updateSql) > 0)
                {
                    App.Msg("�޸ĳɹ�");                  
                }
                else
                {
                    App.MsgErr("�޸�ʧ�ܣ������Ƿ��д˼�¼���߹رպ�����");
                }

            }
        }

        /// <summary>
        /// ����µ��Զ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowEClear(); 
        }

        /// <summary>
        /// ���
        /// </summary>
        private void ShowEClear()
        {            
             txtICD9name.Text="";
             txtICD9name.Focus();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ȡ��ʺ�ƴ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtICD9name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string spellcode = App.getSpell(this.txtICD9name.Text.Trim());
                string fivecode = App.GetWBcode(this.txtICD9name.Text.Trim());
                this.txtspellCode.Text = spellcode;
                this.txtWbCode.Text = fivecode;
            }
            catch
            { }
        }
    }
}