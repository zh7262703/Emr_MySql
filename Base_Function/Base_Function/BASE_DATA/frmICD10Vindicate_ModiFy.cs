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
    public partial class frmICD10Vindicate_ModiFy : Office2007Form
    {
        string ID = "";         

        public frmICD10Vindicate_ModiFy()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取ICD10编码
        /// </summary>
        /// <param name="gname">名称</param>
        /// <param name="id">主键</param>
        /// <param name="Codeicd10">ICD10代码</param>
        public frmICD10Vindicate_ModiFy(string gname,string id,string zy,string zd,string Codeicd10)
        {
            InitializeComponent();
            ID = id;
            txtName.Text = gname;
            txtDiaselogCode.Text = Codeicd10;
            if (ID.Trim() != "")
            {
                if (zy == "Y")
                {
                    cobisberbalistdocter.Checked = true;
                }
                else
                {
                    cobisberbalistdocter.Checked = false;
                }

                if (zd == "Y")
                {
                    cxbisDiagnoseCode.Checked = true;
                }
                else
                {
                    cxbisDiagnoseCode.Checked = false;
                }
                this.btnAdd.Enabled = false;
            }
            else
            {
                this.btnAdd.Enabled = true;
            }
            txtName.Focus();
        }

        private void frmICD10Vindicate_ModiFy_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string spellcode = App.getSpell(this.txtName.Text.Trim());
                string fivecode = App.GetWBcode(this.txtName.Text.Trim());
                this.txtspellcode.Text = spellcode;
                this.txtfivecode.Text = fivecode;
            }
            catch
            { }
        }

        private void cxbisDiagnoseCode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (ID.Trim() == "")
            {

                string sysTemcode = App.GenId("T_DIAG_DEF", "DIAG_ID").ToString();
                //添加
                string isherbalist = "N";
                string isdiagnoseCode = "Y";

                string name = this.txtName.Text.Trim();
                string cotelog = this.txtMuLuID.Text.Trim();
                string spellcode = this.txtspellcode.Text.Trim();
                string fivecode = this.txtfivecode.Text.Trim();
                if (this.cobisberbalistdocter.Checked == false)
                {
                    isherbalist = "N";
                }
                else
                {
                    isherbalist = "Y";
                }
                if (this.cxbisDiagnoseCode.Checked == false)
                {
                    isdiagnoseCode = "N";
                }
                else
                {
                    isdiagnoseCode = "Y";
                }
                string diaselogCode = this.txtDiaselogCode.Text.Trim();                                                   //cotelog
                string innsetsql = "insert into T_DIAG_DEF values('" + Convert.ToInt64(sysTemcode) + "','" + name + "'," + 1 +
                    ",'" + isherbalist + "','" + spellcode + "','" + fivecode + "','" + isdiagnoseCode + "','" + diaselogCode + "')";
                if (App.ExecuteSQL(innsetsql) > 0)
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
                string isherbalist = "N";
                string isdiagnoseCode = "Y";
                string spellcode = App.getSpell(this.txtName.Text.Trim());
                string fivecode = App.GetWBcode(this.txtName.Text.Trim());
                if (this.cobisberbalistdocter.Checked == false)
                {
                    isherbalist = "N";
                }
                else
                {
                    isherbalist = "Y";
                }
                if (this.cxbisDiagnoseCode.Checked == false)
                {
                    isdiagnoseCode = "N";
                }
                else
                {
                    isdiagnoseCode = "Y";
                }
                string updatesql = "update T_DIAG_DEF set name='" + this.txtName.Text.Trim() + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',is_chn='" + isherbalist + "',is_icd10='" + isdiagnoseCode + "',ICD10_ID='" + this.txtDiaselogCode.Text.Trim() + "' where diag_id='" + ID + "'";
                if (App.ExecuteSQL(updatesql) > 0)
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
            txtName.Text = "";
            txtMuLuID.Text = "";
            txtspellcode.Text = "";
            txtfivecode.Text = "";
            cobisberbalistdocter.Checked = false;
            cxbisDiagnoseCode.Checked = true;
            txtName.Focus();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}