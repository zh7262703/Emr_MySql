using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class frmTemplateAdd : DevComponents.DotNetBar.Office2007Form
    {
        private string T_Content = ""; //ģ������          

        public frmTemplateAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="template_content">ģ�������</param>
        public frmTemplateAdd(string template_content)
        {
            InitializeComponent();
            T_Content = template_content;//��ǰ�ı�������
        }

        private void frmTemplateAdd_Load(object sender, EventArgs e)
        {
            this.txtRemark.Text = T_Content;
        }  
 
        /// <summary>
        /// ȷ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)//ȷ����ť
        {
            int id = App.GenId("t_nures_template","id");
            string temptype = "";
            if (cboType.Text == "����")
            {
                temptype = "p";
            }
            else if (cboType.Text == "����")
            {
                temptype = "s";
            }
            else if (cboType.Text == "ȫԺ")
            {
                temptype = "h";
            }
            if (temptype.Length == 0)
            {
                App.MsgWaring("����дģ������!");                  
                return;
            }
            if (txtTemplateName.Text.Trim() == "")
            {
                App.MsgWaring("����дģ������!");
                return;
            }
            string Sql = "insert into t_nures_template (ID,TEMP_NAME,TEMP_CONTENT,TEMP_TYPE,CREATE_ID,SAID) values (" + id + ",'" + txtTemplateName.Text + "','" + this.txtRemark.Text + "','" + temptype + "'," + App.UserAccount.UserInfo.User_id + "," + App.UserAccount.CurrentSelectRole.Sickarea_Id + ")";
            int num=App.ExecuteSQL(Sql);
            if (num > 0)
            {
                App.Msg("�����ɹ�!");
            }
            else
            {
                App.Msg("����û�гɹ�!");
            }
            this.Close();
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }                       
    }
}