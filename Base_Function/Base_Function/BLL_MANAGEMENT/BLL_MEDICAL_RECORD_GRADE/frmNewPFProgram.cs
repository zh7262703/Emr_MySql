using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class frmNewPFProgram : DevComponents.DotNetBar.Office2007Form
    {
        string strRole_tyep = "";
        public frmNewPFProgram()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
               
                int t_data_code_id = App.GenId("t_data_code", "id");
                string strProgramName = tbxProgramName.Text.ToString();
                string strMaxScore = txtMaxScore.Text.ToString();
                string strProgramNameJM = App.getSpell(strProgramName).ToUpper();
                string strHLSY = txtHLSY.Text.ToString();
                if (strProgramName == "" || strMaxScore == "")
                {
                    App.Msg("����������Ŀ�����۷�ֵ��������Ϊ�գ�");
                    return;
                }
                if (strHLSY != "1")
                {
                    string strSqlInsert = "insert into t_data_code(id,name,code,shortcut_code,enable,type,sort) values('" + t_data_code_id + "','" + strProgramName + "[" + strMaxScore + "��" + "]" + "','" + t_data_code_id + "','" + strProgramNameJM + "','Y','196','')";
                    int n = App.ExecuteSQL(strSqlInsert);
                    if (n > 0)
                    {
                        App.Msg("����������Ŀ�ɹ���");
                        this.Close();
                    }
                    else
                    {
                        App.Msg("����������Ŀʧ�ܣ�");
                        return;
                    }
                }
                else
                {
                    string strSqlInsert = "insert into t_data_code(id,name,code,shortcut_code,enable,type,sort) values('" + t_data_code_id + "','" + strProgramName + "[" + strMaxScore + "��" + "]" + "','" + t_data_code_id + "','" + strProgramNameJM + "','Y','196','" + strHLSY + "')";
                    int n = App.ExecuteSQL(strSqlInsert);
                    if (n > 0)
                    {
                        App.Msg("����������Ŀ�ɹ���");
                        this.Close();
                    }
                    else
                    {
                        App.Msg("����������Ŀʧ�ܣ�");
                        return;
                    }
                }
               
            }
            catch
            {
             
            }
        }
        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
              
            }
        }

        private void frmNewPFProgram_Load(object sender, EventArgs e)
        {
            strRole_tyep = App.UserAccount.CurrentSelectRole.Role_type.ToString();//��ȡ��ǰ��½��ɫ����
            if(strRole_tyep!="H")
            {
                label3.Visible = false;
                txtHLSY.Visible = false;
                label4.Visible = false;
            }
        }
    }
}