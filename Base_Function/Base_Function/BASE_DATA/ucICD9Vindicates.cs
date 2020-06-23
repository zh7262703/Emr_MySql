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
    /// ICD9维护
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class ucICD9Vindicates : UserControl
    {

        bool isDelectUpdate = false;
        string current_id = "";
        string current_name = "";
        string current_icd9code = "";

        public ucICD9Vindicates()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select code as ICD9编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD9,QTXM as 报表编码,FJBM as 诊断编码 from oper_def_icd9";
             ds= App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql, "ICD9编码", "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }

        }

        /// <summary>
        /// 显示指定的自定义手术ICD9
        /// </summary>
        /// <param name="Icd9code"></param>
        private void ShowUserICD9Data(string Icd9code)
        {
            string sql = "select diag_id as ID ,NAME as 名称,SHORTCUT1 as 拼音码,SHORTCUT2 as 五笔码,IS_ICD9 as 是否ICD9手术码, ICD9 as ICD9手术码 from t_oper_def where ICD9='" + Icd9code + "'";

            //string sql = "select code as ICD10编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD10 from diag_def_icd10";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX2.DataBd(sql, "ID", false, "", "");
                ucGridviewX2.fg.ReadOnly = true;
            }

        }

        private void frmICD10Vindicate_Load(object sender, EventArgs e)
        {
            txtICD9code.Enabled = false;
            txtICD9name.Enabled = false;
            this.btncancel.Enabled = false;
            this.btnconfirm.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX2.fg.ContextMenuStrip = contextMenuStrip1;
            ucGridviewX2.fg.DoubleClick += new EventHandler(ucC1FlexGrid2_DoubleClick);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX2.fg.AllowUserToAddRows = false;
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count >0)
                {
                    txtICD9code.Enabled = false;
                    txtICD9name.Enabled = false;

                    this.txtICD9code.Text = ucGridviewX1.fg["ICD9编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtICD9name.Text = ucGridviewX1.fg["诊断名", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellCode.Text = ucGridviewX1.fg["拼音码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfiveCode.Text = ucGridviewX1.fg["五笔码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtBIAO.Text = ucGridviewX1.fg["报表编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtZHEND.Text = ucGridviewX1.fg["诊断编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    ShowUserICD9Data(this.txtICD9code.Text);

                    //int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    //if (rows > 0)
                    //{
                    //    if (oldRow == rows)
                    //    {
                    //        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //    }
                    //    else
                    //    {
                    //        //如果不是头行
                    //        if (rows > 0)
                    //        {
                    //            //就改变背景色
                    //            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //        }
                    //        int count = ucC1FlexGrid1.fg.Rows.Count;
                    //        if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow)
                    //        {
                    //            if (oldRow < count - 1)
                    //            {
                    //                //定义上一次点击过的行还原
                    //                this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    //            }
                    //        }
                    //        //else
                    //        //{
                    //        //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    //        //}
                    //    }
                    //}
                    ////给上一次的行号赋值
                    //oldRow = rows;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucGridviewX1.Enabled = false;
            isDelectUpdate = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtICD9code.Enabled = true;
            txtICD9name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
       
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {

            try
            {
                ucGridviewX1.Enabled = true;
              
                    if (this.txtICD9code.Text == "")
                    {
                        App.Msg("ICD9编码不能为空");
                        this.txtICD9code.Focus();
                        return;
                    }
                    if (this.txtICD9name.Text == "")
                    {
                        App.Msg("名称不能为空");
                        this.txtICD9name.Focus();
                        return;
                    }
                    if (isDelectUpdate == true)
                    {
                        string innsetsql = "insert into oper_def_icd9(CODE,NAME,SHORTCUT1,SHORTCUT2,QTXM,FJBM) values('" + txtICD9code.Text + "','" + txtICD9name.Text + "','" + txtspellCode.Text + "','" + txtfiveCode.Text + "','" + txtBIAO.Text + "','" + txtZHEND.Text + "')";
                        int count = App.ExecuteSQL(innsetsql);
                        if (count > 0)
                        {
                            App.Msg("添加成功！");
                            SetflgViewData();
                            btncancel_Click(sender,e);
                        }
                    }
                    else
                    {
                        string spellcode = App.getSpell(this.txtICD9name.Text);
                        string fivecode = App.GetWBcode(this.txtICD9name.Text);
                        string updatesql = "update oper_def_icd9 set name='" + this.txtICD9name.Text + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',QTXM='" + txtBIAO.Text + "',FJBM='" + txtZHEND.Text + "' where code='" + txtICD9code.Text + "'";
                        if (App.ExecuteSQL(updatesql) > 0)
                        {
                            App.Msg("修改成功");
                            SetflgViewData();
                            btncancel_Click(sender, e);
                        }
                    }
            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtICD9code.Text == "" || this.txtICD9name.Text == "")
            {
                App.Msg("您没有要修改的信息");
                return;
            }
            isDelectUpdate = false;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtICD9code.Enabled = true;
            txtICD9name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnconfirm.Enabled = true;
        }

        private void txtICD9name_TextChanged(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD9name.Text);
            string fivecode = App.GetWBcode(this.txtICD9name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            txtICD9code.Enabled = false;
            txtICD9name.Enabled = false;
            txtspellCode.Enabled = false;
            txtfiveCode.Enabled = false;
            txtICD9code.Text = "";
            txtICD9name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtICD9code.Text == "" || this.txtICD9name.Text == "")
                {
                    App.Msg("请确定你要删除的信息");
                    return;
                }
                else
                {
                    string deletesql = "delete oper_def_icd9 where code='" + this.txtICD9code.Text + "'";

                    if (App.Ask("您确定要删除吗？"))
                    {
                        if (App.ExecuteSQL(deletesql) > 0)
                        {
                            App.Msg("删除成功！");
                            SetflgViewData();
                            btncancel_Click(sender, e);
                        }
                    }
                    
                }
            }
            catch
            {
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string icd9Name = this.txtVindicateName.Text;
            if (icd9Name == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = "select code as ICD9编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD9,QTXM as 报表编码,FJBM as 诊断编码 from oper_def_icd9 where name like '" + icd9Name + "%' or shortcut1 like '" + icd9Name + "%'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "ICD9编码", "", "");
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 自定义手术维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpmodify_Click(object sender, EventArgs e)
        {
            if (txtICD9code.Text.Trim() != "")
            {
                current_id = "";
                frmICD9Vindicate_ModiFy fc = new frmICD9Vindicate_ModiFy(current_name, current_id,txtICD9code.Text.Trim());
                App.FormStytleSet(fc, false);
                fc.ShowDialog();
                ShowUserICD9Data(txtICD9code.Text.Trim());
            }
            else
            {
                App.MsgWaring("请先选择标准ICD9诊断！");
            }
        }

        private void 删除自定义手术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucGridviewX2.fg.Rows.Count > 0)
            {
                if (App.Ask("确定要删除这条手术自定义记录吗？"))
                {
                    if (App.ExecuteSQL("delete from t_oper_def where DIAG_ID=" + ucGridviewX2.fg["ID", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("操作已经成功！");
                        ShowUserICD9Data(txtICD9code.Text);
                    }

                }
            }
            else
            {
                App.MsgErr("请选择要删除的记录！");
            }
        }

        private void ucC1FlexGrid2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX2.fg.Rows.Count >0)
                {
                    current_id = ucGridviewX2.fg["ID", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_name = ucGridviewX2.fg["名称", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_icd9code = ucGridviewX2.fg["ICD9手术码", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    frmICD9Vindicate_ModiFy fc = new frmICD9Vindicate_ModiFy(current_name, current_id,current_icd9code);
                    App.FormStytleSet(fc, false);
                    fc.ShowDialog();
                    ShowUserICD9Data(current_icd9code);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("请选择要修改的数据！" + ex.Message);
            }
        }


    
    }
}