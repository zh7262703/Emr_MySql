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
    /// ICD10维护
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class ucICD10Vindicate :UserControl
    {

        bool isDelectUpdate = false;                //用于存放当前的操作状态 true为添加操作 false为修改操作

        string current_id = "";
        string current_name = "";
        string current_icd10code = "";
        string current_iszy = "";
        string current_isicd10 = "";

        public ucICD10Vindicate()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select code as ICD10编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD10,QTXM as 报表编码,FJBM as 诊断编码 from diag_def_icd10";
             ds= App.GetDataSet(sql);
            if (ds != null)
            {               
                this.ucGridviewX1.DataBd(sql, "ICD10编码", "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }

        }

        /// <summary>
        /// 显示自定义诊断
        /// </summary>
        private void ShowSelfDigs(string icd10code)
        {
            try
            {
                string sql = "select DIAG_ID as 代码, NAME as 名称, CATEGORY_ID as 目录ID, IS_CHN as 是否中医诊断, SHORTCUT1 as 拼音码, SHORTCUT2 as 五笔码, IS_ICD10 as 是否ICD10诊断码, ICD10_ID as ICD10诊断码  from T_DIAG_DEF where ICD10_ID='" + icd10code + "'";
                this.ucGridviewX2.DataBd(sql, "代码", false, "", "");
                ucGridviewX2.fg.ReadOnly = true;

            }
            catch
            { }
        }

        private void frmICD10Vindicate_Load(object sender, EventArgs e)
        {
            txtICD10code.Enabled = false;
            txtICD10name.Enabled = false;
            txtspellCode.Enabled = false;
            txtfiveCode.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;            

            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX2.fg.DoubleClick += new EventHandler(ucC1FlexGrid2_DoubleClick);
            ucGridviewX2.fg.ContextMenuStrip = contextMenuStrip1;
            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX2.fg.AllowUserToAddRows = false;
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count>0)
                {
                    txtICD10code.Enabled = false;
                    txtICD10name.Enabled = false;
                    txtspellCode.Enabled = false;
                    txtfiveCode.Enabled = false;

                    this.txtICD10code.Text = ucGridviewX1.fg["ICD10编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtICD10name.Text = ucGridviewX1.fg["诊断名", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellCode.Text = ucGridviewX1.fg["拼音码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfiveCode.Text = ucGridviewX1.fg["五笔码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtBIAO.Text = ucGridviewX1.fg["报表编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtZHEND.Text = ucGridviewX1.fg["诊断编码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    ShowSelfDigs(this.txtICD10code.Text);

                   // int rows = this.ucGridviewX1.fg.RowSel;//定义选中的行号 
                   // if (rows > 0)
                   // {
                   //     if (oldRow == rows)
                   //     {
                   //         this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                   //     }
                   //     else
                   //     {
                   //         //this.ucC1FlexGrid1.fg.BackColor= ucC1FlexGrid1.fg.BackColor;
                   //         //如果不是头行
                   //         if (rows > 0)
                   //         {
                   //             //就改变背景色
                   //             this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                   //         }
                   //         int t = ucC1FlexGrid1.fg.Rows.Count;
                   //         if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                   //         {
                   //             if (oldRow < t)
                   //             {
                                   

                   //                 //定义上一次点击过的行还原
                   //                 //this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                   //                 this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                   //             }

                   //         }
                   //         //else
                   //         //{
                   //         //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                   //         //}
                   //     }
                   // }
                   // //给上一次的行号赋值
                   //oldRow = rows;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }


        private void ucC1FlexGrid2_Click(object sender, EventArgs e)
        {
            
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucGridviewX1.Enabled = false;
            isDelectUpdate = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            txtICD10code.Enabled = true;
            txtICD10name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            txtICD10code.Text = "";
            txtICD10name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.Enabled = true;
          
                    if (this.txtICD10code.Text == "")
                    {
                        App.Msg("ICD10编码不能为空");
                        this.txtICD10code.Focus();
                        return;
                    }
                    if (this.txtICD10name.Text == "")
                    {
                        App.Msg("名称不能为空");
                        this.txtICD10name.Focus();
                        return;
                    }
                    if (isDelectUpdate == true)
                    {
                        string innsetsql = "insert into diag_def_icd10 (code,name,shortcut1,shortcut2,qtxm,fjbm) values('" + txtICD10code.Text + "','" + txtICD10name.Text + "','" + txtspellCode.Text + "','" + txtfiveCode.Text + "','" + txtBIAO.Text + "','" + txtZHEND.Text + "')";
                        int count = App.ExecuteSQL(innsetsql);
                        if (count > 0)
                        {
                            App.Msg("添加成功！");
                            btncancel_Click(sender, e);
                            SetflgViewData();
                        }
                    }
                    else
                    {
                        string spellcode = App.getSpell(this.txtICD10name.Text);
                        string fivecode = App.GetWBcode(this.txtICD10name.Text);
                        string updatesql = "update diag_def_icd10 set name='" + this.txtICD10name.Text + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',QTXM='" + txtBIAO.Text + "',FJBM='" + txtZHEND.Text + "'  where code='" + txtICD10code.Text + "'";
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
            if (txtICD10code.Text == "" || this.txtICD10name.Text == "")
            {
                App.Msg("您没有要修改的信息");
                return;
            }
            isDelectUpdate = false;
            txtICD10code.Enabled = true;
            txtICD10name.Enabled = true;
            txtspellCode.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtfiveCode.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnconfirm.Enabled = true;
        }

        private void txtICD10name_TextChanged(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD10name.Text);
            string fivecode = App.GetWBcode(this.txtICD10name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            txtICD10code.Enabled = false;
            txtICD10name.Enabled = false;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            txtICD10code.Text = "";
            txtICD10name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtICD10code.Text == "" || this.txtICD10name.Text == "")
                {
                    App.Msg("请确定你要删除的信息");
                    return;
                }
                else
                {
                    string deletesql = "delete diag_def_icd10 where code='" + this.txtICD10code.Text + "'";

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
            string icd10Name = this.txtVindicateName.Text;
            if (icd10Name == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = "select code as ICD10编码,name as 诊断名,shortcut1 as 拼音码,shortcut2 as 五笔码,(code || name) as ICD10,QTXM as 报表编码,FJBM as 诊断编码 from diag_def_icd10 where name like '" + icd10Name + "%' or shortcut1 like '" + icd10Name + "%'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "ICD10编码", "", "");
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        private void txtICD10name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtICD10name_KeyUp(object sender, KeyEventArgs e)
        {
           

        }

        /// <summary>
        /// 自定义诊断维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDigmodify_Click(object sender, EventArgs e)
        {         
            if (txtICD10code.Text.Trim() != "")
            {
                current_id = "";
                frmICD10Vindicate_ModiFy fc = new frmICD10Vindicate_ModiFy(current_name, current_id, current_iszy, current_isicd10, txtICD10code.Text.Trim());
                App.FormStytleSet(fc, false);
                fc.ShowDialog();
                ShowSelfDigs(txtICD10code.Text.Trim());
            }
            else
            {
                App.MsgWaring("请先选择标准ICD10诊断！");
            }
        }

        private void ucC1FlexGrid2_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (ucGridviewX2.fg.Rows.Count >0)
                {
                    current_id = ucGridviewX2.fg["代码", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_name = ucGridviewX2.fg["名称", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX2.fg["是否中医诊断", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() == "N")
                    {
                        current_iszy = "N";
                    }
                    else
                    {
                        current_iszy = "Y";
                    }
                    if (ucGridviewX2.fg["是否ICD10诊断码",ucGridviewX2.fg.CurrentRow.Index].Value.ToString() == "Y")
                    {
                        current_isicd10 = "N";
                    }
                    else
                    {
                        current_isicd10 = "Y";
                    }
                    current_icd10code = ucGridviewX2.fg["ICD10诊断码", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    frmICD10Vindicate_ModiFy fc = new frmICD10Vindicate_ModiFy(current_name, current_id, current_iszy, current_isicd10, current_icd10code);
                    App.FormStytleSet(fc, false);
                    fc.ShowDialog();
                    ShowSelfDigs(current_icd10code);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("请选择要修改的数据！"+ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除自定义诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucGridviewX2.fg.Rows.Count >0)
            {
                if (App.Ask("确定要删除这条诊断自定义记录吗？"))
                {
                    if (App.ExecuteSQL("delete from T_DIAG_DEF where DIAG_ID=" + ucGridviewX2.fg["代码", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("操作已经成功！");
                        ShowSelfDigs(txtICD10code.Text);
                    }

                }
            }
            else
            {
                App.MsgErr("请选择要删除的记录！");
            }
        }

        private void txtICD10name_TextChanged_1(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD10name.Text);
            string fivecode = App.GetWBcode(this.txtICD10name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }
    }
}