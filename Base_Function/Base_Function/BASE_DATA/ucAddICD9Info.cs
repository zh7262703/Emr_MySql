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
    /// <summary>
    /// 手术名称定义
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class ucAddICD9Info :UserControl
    {
        string sysTemcode = "";
        bool isDelectUpdate = false;
        public ucAddICD9Info()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select diag_id as ID ,NAME as 名称,SHORTCUT1 as 拼音码,SHORTCUT2 as 五笔码,IS_ICD9 as 是否ICD9手术码, ICD9 as ICD9手术码 from t_oper_def";

            //string sql = "select code as ICD10编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD10 from diag_def_icd10";
            ds = App.GetDataSet(sql);
            if (ds != null)
            {

                this.ucGridviewX1.DataBd(sql, "ID", false, "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        private void frmAddICD9Info_Load(object sender, EventArgs e)
        {
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            this.txtName.Enabled = false;
            txtDiaselogCode.Enabled = false;
            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = false;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            isDelectUpdate = true;
            this.txtName.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            txtDiaselogCode.Enabled = true;
         
            txtSystemCode.Enabled = true;
            txtName.Enabled = true;
            txtspellcode.Enabled = true;
            txtfivecode.Enabled = true;
      
            cxbisDiagnoseCode.Enabled = true;
            this.cxbisDiagnoseCode.Checked = false;
            //this.txtDiaselogCode.Text = "";
            sysTemcode = App.GenId("t_oper_def", "DIAG_ID").ToString();
            this.txtSystemCode.Text = sysTemcode;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                App.Msg("您没有要修改的信息");
                return;
            }
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            isDelectUpdate = false;
            this.txtName.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnUpdate.Enabled = false;
            txtDiaselogCode.Enabled = true;
            txtDiaselogCode.Enabled = true;

            txtSystemCode.Enabled = true;
            txtName.Enabled = true;
            txtspellcode.Enabled = true;
            txtfivecode.Enabled = true;

            cxbisDiagnoseCode.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtName.Text == "")
                //{
                //    App.Msg("请确定你要删除的信息");
                //    return;
                //}
                //else
                //{
                    string deletesql = "delete t_oper_def where diag_id='" + this.txtSystemCode.Text + "'";

                    if (App.Ask("您确定要删除吗？"))
                    {
                        if (App.ExecuteSQL(deletesql) > 0)
                        {
                            App.Msg("删除成功！");
                            SetflgViewData();
                            this.btnAdd.Enabled = true;
                            this.btnUpdate.Enabled = true;
                            this.btnDelete.Enabled = true;
                            this.btnconfirm.Enabled = false;
                            this.btncancel.Enabled = false;
                            ShowClear();
                       
                        }
                        else
                        {
                            App.MsgErr("删除失败，请检查是否有此记录或者关闭后再试");
                        }
                    }
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowClear()
        {
            txtSystemCode.Text = "";
            txtName.Text = "";
            txtspellcode.Text = "";
            txtfivecode.Text = "";
            txtDiaselogCode.Text = "";
            cxbisDiagnoseCode.Checked = false;
        }
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = true;
            string codeID = this.txtSystemCode.Text.Trim();
            string icd9Name = this.txtName.Text.Trim();
            string spellCode = this.txtspellcode.Text.Trim();
            string fiveCode = this.txtfivecode.Text.Trim();
            string isicd9code = "";
            if (this.cxbisDiagnoseCode.Checked == true)
            {
                isicd9code = "1";
            }
            else
            {
                isicd9code = "0";
            }
            string diagnoseCode = this.txtDiaselogCode.Text.Trim();
            if (isDelectUpdate == true)
            {
                string insertSql = "insert into T_OPER_DEF values('" + codeID + "','" + icd9Name + "','" + spellCode +
                    "','" + fiveCode + "','" + isicd9code + "','" + diagnoseCode + "')";
                if (App.ExecuteSQL(insertSql) > 0)
                {
                    App.Msg("添加成功！");
                    SetflgViewData();
                    this.btnAdd.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btncancel.Enabled = false;
                    this.btnconfirm.Enabled = false;
                    ShowClear();
                }
                else
                {
                    App.MsgErr("添加失败，请检查值是否为空！");
                }
            }
            else
            {
                string updateSql = "update T_OPER_DEF set name='" + icd9Name + "',shortcut1='" + spellCode +
                    "',shortcut2='" + fiveCode + "',is_icd9='" + isicd9code + "',icd9='" + diagnoseCode + "' where diag_id='" + codeID + "'";
                if (App.ExecuteSQL(updateSql) > 0)
                {
                    App.Msg("修改成功！");
                    SetflgViewData();
                    this.btnAdd.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btncancel.Enabled = false;
                    this.btnconfirm.Enabled = false;
                    ShowClear();
                }
                else
                {
                    App.MsgErr("修改失败，请检查是否有此记录或者关闭后再试");
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    App.SelectFastCodeCheck();
            //}
            //else if (e.KeyCode == Keys.Left)
            //{

            //}
            //else if (e.KeyCode == Keys.Right)
            //{

            //}
            //else if (e.KeyCode == Keys.Escape)
            //{
            //    App.HideFastCodeCheck();
            //}
            //else
            //{
            //    if (!App.FastCodeFlag)
            //        if (txtName.Text.Trim() != "")
            //        {
            //            App.FastCodeCheck("select code as ICD9编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD9 from oper_def_icd9 where rownum<11 and shortcut1 like '" + this.txtName.Text.Trim() + "%'", txtName, "诊断名", "ICD9编码");
            //            //App.FastCodeCheck("select code as 代码,name as 诊断名,(code || name) as ICD10 from diag_def_icd10 where rownum<11 and shortcut1 like '" + this.txtName.Text + "%'", txtName, "诊断名", "ICD10");
            //        }
            //    App.FastCodeFlag = false;
            //}
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //if (App.SelectObj != null)
            //{
            //    this.txtSystemCode.Text = App.SelectObj.Select_Val;
            //}
            string spellcode = App.getSpell(this.txtName.Text);
            string fivecode = App.GetWBcode(this.txtName.Text);
            this.txtspellcode.Text = spellcode;
            this.txtfivecode.Text = fivecode;
        }

        private void cxbisDiagnoseCode_CheckedChanged(object sender, EventArgs e)
        {
            if (cxbisDiagnoseCode.Checked == true)
            {
                if (App.SelectObj != null)
                {
                    this.txtDiaselogCode.Text = App.SelectObj.Select_Val + App.SelectObj.Select_Name;
                }
            }
            else
            {
                this.txtDiaselogCode.Text = "";//App.SelectObj.Select_Val;// +App.SelectObj.Select_Name;
            }
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiaselogCode.Enabled = false;
                txtSystemCode.Enabled = false ;
                txtName.Enabled = false;
                txtspellcode.Enabled = false;
                txtfivecode.Enabled = false;
                txtDiaselogCode.Enabled = false;
                cxbisDiagnoseCode.Enabled = false;
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    this.txtSystemCode.Text = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtName.Text = ucGridviewX1.fg["名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellcode.Text = ucGridviewX1.fg["拼音码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfivecode.Text = ucGridviewX1.fg["五笔码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["是否ICD9手术码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "1")
                    {
                        this.cxbisDiagnoseCode.Checked = true;
                    }
                    else
                    {
                        this.cxbisDiagnoseCode.Checked = false;
                    }
                    this.txtDiaselogCode.Text = ucGridviewX1.fg["ICD9手术码", ucGridviewX1.fg.CurrentRow.Index].ToString();                    
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.txtName.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            //this.txtName.Enabled = true;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            txtDiaselogCode.Enabled = false ;
            cxbisDiagnoseCode.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string txtname = this.txtVindicateName.Text.Trim();
            string sql = "";
            if (txtname=="")
            {
                 sql = "select diag_id as ID ,NAME as 名称,SHORTCUT1 as 拼音码,SHORTCUT2 as 五笔码,IS_ICD9 as 是否ICD9手术码, ICD9 as ICD9手术码 from t_oper_def";
            }
            else
            {
                 sql = "select diag_id as ID ,NAME as 名称,SHORTCUT1 as 拼音码,SHORTCUT2 as 五笔码,IS_ICD9 as 是否ICD9手术码, ICD9 as ICD9手术码 from t_oper_def where NAME like '%" + txtname + "%'";
            }
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql, "ID", false, "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }
        }

        private void txtDiaselogCode_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

        private void txtDiaselogCode_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtDiaselogCode_KeyDown(sender, e);

            //}
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {

                    if (!App.FastCodeFlag)
                    {
                        if (txtDiaselogCode.Text.Trim() != "")
                        {
                            App.FastCodeCheck("select CODE as ICD9编号,NAME as 名称 from OPER_DEF_ICD9 t where shortcut1 like '" + txtDiaselogCode.Text + "%'", txtDiaselogCode, "ICD9编号", "名称");
                            App.FastCodeFlag = false;
                        }
                        else
                        {
                            App.HideFastCodeCheck();
                        }
                    }


                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }
    }
}