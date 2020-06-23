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
        private string T_Content = ""; //模板内容          

        public frmTemplateAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="template_content">模板的内容</param>
        public frmTemplateAdd(string template_content)
        {
            InitializeComponent();
            T_Content = template_content;//当前文本的内容
        }

        private void frmTemplateAdd_Load(object sender, EventArgs e)
        {
            this.txtRemark.Text = T_Content;
        }  
 
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)//确定按钮
        {
            int id = App.GenId("t_nures_template","id");
            string temptype = "";
            if (cboType.Text == "个人")
            {
                temptype = "p";
            }
            else if (cboType.Text == "病区")
            {
                temptype = "s";
            }
            else if (cboType.Text == "全院")
            {
                temptype = "h";
            }
            if (temptype.Length == 0)
            {
                App.MsgWaring("请填写模板类型!");                  
                return;
            }
            if (txtTemplateName.Text.Trim() == "")
            {
                App.MsgWaring("请填写模板名称!");
                return;
            }
            string Sql = "insert into t_nures_template (ID,TEMP_NAME,TEMP_CONTENT,TEMP_TYPE,CREATE_ID,SAID) values (" + id + ",'" + txtTemplateName.Text + "','" + this.txtRemark.Text + "','" + temptype + "'," + App.UserAccount.UserInfo.User_id + "," + App.UserAccount.CurrentSelectRole.Sickarea_Id + ")";
            int num=App.ExecuteSQL(Sql);
            if (num > 0)
            {
                App.Msg("操作成功!");
            }
            else
            {
                App.Msg("操作没有成功!");
            }
            this.Close();
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }                       
    }
}