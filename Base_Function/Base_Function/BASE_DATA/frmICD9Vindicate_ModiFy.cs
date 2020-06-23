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
        /// 获取ICD10编码
        /// </summary>
        /// <param name="gname">名称</param>
        /// <param name="id">主键</param>
        /// <param name="Codeicd10">ICD10代码</param>
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
                //添加                                                                      
                string insertSql = "insert into T_OPER_DEF values('" + sysTemcode + "','" + txtICD9name.Text + "','" + txtspellCode.Text +
                    "','" + txtWbCode.Text + "','Y','" + txtICD9code.Text + "')";
                if (App.ExecuteSQL(insertSql) > 0)
                {
                    App.Msg("添加成功！");
                    ShowEClear(); 
                }
                else
                {
                    App.MsgErr("添加失败，请检查值是否为空！");
                }
            }
            else
            {
                //修改                
                string updateSql = "update T_OPER_DEF set name='" + txtICD9name.Text + "',shortcut1='" + txtspellCode.Text +
                    "',shortcut2='" + txtWbCode.Text + "',is_icd9='Y',icd9='" + txtICD9code.Text + "' where diag_id='" + ID + "'";
                if (App.ExecuteSQL(updateSql) > 0)
                {
                    App.Msg("修改成功");                  
                }
                else
                {
                    App.MsgErr("修改失败，请检查是否有此记录或者关闭后再试");
                }

            }
        }

        /// <summary>
        /// 添加新的自定义诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowEClear(); 
        }

        /// <summary>
        /// 清空
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
        /// 获取五笔和拼音
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