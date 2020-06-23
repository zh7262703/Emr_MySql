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
    public partial class ucDiag_DEF : UserControl
    {
        bool isSave = false;                 //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string DiagCEF = "Y";       //是否有ICD10诊断码
        private string T_DiagCEF_Sql;       //诊断名称定义查询
        private string diag_id = "";        //当前选中的诊断编号
        private string diag_name = "";      //当前选中的诊断名称
        DataSet ds;

        public ucDiag_DEF()
        {
            InitializeComponent();
            T_DiagCEF_Sql = @"select DIAG_ID as 诊断编号,a.NAME as 诊断名称,CATEGORY_ID as 所属目录编号,b.name as 所属目录," +
                   @"(case when IS_CHN=0 then '是' else '否' end) as 是否中医诊断,SHORTCUT1 as 拼音,SHORTCUT2 as 五笔 ,(case when IS_ICD10='Y' then '有' else '无' end) as 是否ICD10诊断码," +
                   @"ICD10_ID as  ICD10诊断码,ATTKIND  as 诊断属性种类编号,c.name as 诊断属性种类 from T_DIAG_DEF a inner  join T_DIAG_CAT b on b.id=a.category_id   inner join T_DATA_CODE c on c.id=a.attkind";
        }

        private void frmDiag_DEF_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("诊断名称定义");
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.RowColChange += new EventHandler(CurrentDataChange); 
            ucGridviewX1.fg.AllowUserToAddRows = true;
            cboMedicine.SelectedIndex = 0;
            DiagCAT();
            Types();
            RefleshFrm();

        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["诊断编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属目录编号"].Visible = false;
                ucGridviewX1.fg.Columns["所属目录编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //显示数据
        private void ShowValue()
        {
          
            string SQl = T_DiagCEF_Sql + " order by DIAG_ID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQl, "诊断编号", false, "", "");

                ucGridviewX1.fg.Columns["诊断编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属目录编号"].Visible = false;
                ucGridviewX1.fg.Columns["所属目录编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            
           
        }

        //绑定所属目录
        private void DiagCAT()
        {
            DataSet ds = App.GetDataSet("select * from T_DIAG_CAT");
            cboDiagCAT.DataSource = ds.Tables[0].DefaultView;
            cboDiagCAT.ValueMember = "ID";
            cboDiagCAT.DisplayMember = "NAME";
        }
        //绑定所诊断所属种类
        private void Types()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE where TYPE='19'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtPinyin.Enabled = false;
            txtWuBi.Enabled = false;
            cboDiagCAT.Enabled = false;
            cboMedicine.Enabled = false;
            rbtnYes.Enabled = false;
            rbtnNo.Enabled = false;
            txtDTC.Enabled = false;
            cboType.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            isSave = false;

        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtDTC.Text = "";
            }
            txtCode.Enabled = true;
            txtName.Enabled = true;
            txtPinyin.Enabled = true;
            txtWuBi.Enabled = true;
            cboDiagCAT.Enabled = true;
            cboMedicine.Enabled = true;
            rbtnYes.Enabled = true;
            rbtnNo.Enabled = true;
            txtDTC.Enabled = true;
            cboType.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (rbtnYes.Checked == true)
            {
                txtDTC.Enabled = true;
            }
            else
            {
                txtDTC.Enabled = false;
            }
            
            txtCode.Focus();
        }
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_DIAG_DEF where  DIAG_ID='" + id + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_DIAG_DEF where NAME='" + name + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbtnYes.Checked)
                {
                    DiagCEF = "N";
                }

                if (txtCode.Text.Trim() == "")
                {
                    App.Msg("诊断编号不能为空");
                    txtCode.Focus();
                    return;
                }
           

                if (txtName.Text.Trim() == "")
                {
                    App.Msg("诊断名字必须填写！");
                    txtName.Focus();
                    return;
                }

                if (cboDiagCAT.Text.Trim() == "")
                {
                    App.Msg("所属目录必须填写！");
                    cboDiagCAT.Focus();
                    return;
                }
                if (cboMedicine.Text.Trim() == "")
                {
                    App.Msg("是否中医诊断必须填写！");
                    cboMedicine.Focus();
                    return;
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("诊断属性种类必须填写！");
                    cboType.Focus();
                    return;
                }
                string sql = "";
                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtCode.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的诊断编号了！");
                        txtCode.Focus();
                        return;
                    }
                    else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同诊断名称的值了！");
                        txtName.Focus();
                        return;
                    }

                    sql = "insert into T_DIAG_DEF(DIAG_ID,NAME,CATEGORY_ID,IS_CHN,SHORTCUT1,SHORTCUT2,IS_ICD10,ICD10_ID,ATTKIND)  values('"
                          + txtCode.Text + "','"
                          + App.ToDBC(txtName.Text) + "','"
                          + cboDiagCAT.SelectedValue + "','"
                          + cboMedicine.SelectedIndex.ToString() + "','"
                          + txtPinyin.Text + "','"
                          + txtWuBi.Text + "','"
                          + DiagCEF + "','"
                          + txtDTC.Text + "','"
                          +cboType.SelectedValue+ "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (diag_id.Trim()!="")
                    {
                        if (txtCode.Text.Trim() != diag_id.Trim())
                        {
                            if (isExisitName(App.ToDBC(txtCode.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的诊断编号值了！");
                                txtCode.Focus();
                                return;
                            }
                        }
                    }
                    else if (diag_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != diag_name.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同诊断名称的值了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }

                    sql = "update T_DIAG_DEF set NAME='"
                             +App.ToDBC(txtName.Text) + "', CATEGORY_ID='"
                             + cboDiagCAT.SelectedValue + "',IS_CHN='"
                             + cboMedicine.SelectedIndex.ToString() + "',SHORTCUT1='"
                             + txtPinyin.Text + "',SHORTCUT2='"
                             + txtWuBi.Text + "',IS_ICD10='"
                             + DiagCEF + "',ICD10_ID='"
                             +txtDTC.Text+ "',ATTKIND='"
                             + cboType.SelectedValue + "' where DIAG_ID='" + ucGridviewX1.fg["诊断编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    btnUpdate_Click(sender, e);

                }

                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        refurbish();

                    }
                //显示列表数据
                ShowValue();
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");

            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefleshFrm();
        }
        int Rowcount = 0;
        /// <summary>
        ///单击表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count >= 0)
                {
                    txtCode.Text = ucGridviewX1.fg["诊断编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    diag_id = txtCode.Text;
                    txtName.Text = ucGridviewX1.fg["诊断名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    diag_name = txtName.Text;
                    cboDiagCAT.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["所属目录编号", ucGridviewX1.fg.CurrentRow.Index].Value);
                    if (ucGridviewX1.fg["是否中医诊断", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        cboMedicine.SelectedIndex = 0;
                    }
                    else
                    {
                        cboMedicine.SelectedIndex = 1;
                    }
                    txtPinyin.Text = ucGridviewX1.fg["拼音", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtWuBi.Text = ucGridviewX1.fg["五笔", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["是否ICD10诊断码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有")
                    {
                        rbtnYes.Checked = true;
                    }
                    else
                    {
                        rbtnNo.Checked = true;
                    }
                    txtDTC.Text = ucGridviewX1.fg["ICD10诊断码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    cboType.SelectedValue = ucGridviewX1.fg["诊断属性种类编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                   
                    //int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    //if (rows > 0)
                    //{
                    //    if (Rowcount == rows)
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
                    //        if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                    //        {
                    //            //定义上一次点击过的行还原
                    //            this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    //        }
                    //    }
                    //}
                    ////给上一次的行号赋值
                    //Rowcount = rows;
                    RefleshFrm();
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void rbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnYes.Checked == true)
            {
                txtDTC.Enabled = true;
            }
        }

        private void rbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNo.Checked == true)
            {
                if (btnCancel.Enabled)
                    txtDTC.Enabled = false;

            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                chkPY.Checked = false;
                chkWB.Checked = false;
            }
            else
            {
                chkPY.Checked = true;
                chkWB.Checked = false;
                txtInquiry.Text = "";
            }
        }

        private void chkPY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPY.Checked)
            {
                chkName.Checked = false;
                chkWB.Checked = false;
            }
            else
            {
                chkName.Checked = false;
                chkWB.Checked = true;
                txtInquiry.Text = "";
            }
        }

        private void chkWB_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWB.Checked)
            {
                chkName.Checked = false;
                chkPY.Checked = false;
            }
            else
            {
                chkName.Checked = true;
                chkPY.Checked = false;
                txtInquiry.Text = "";
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                String SQl = T_DiagCEF_Sql + " order by DIAG_ID desc";
                if (txtInquiry.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtInquiry.Focus();
                    return;
                }
                //根据诊断名称进行查询
                if (chkName.Checked)
                {

                    if (txtInquiry.Text.Trim() != "")
                    {
                        SQl = T_DiagCEF_Sql + " and  a.NAME　like'%" + txtInquiry.Text.Trim() + "%' order by DIAG_ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //根据拼音进行查询
                else if (chkPY.Checked)
                {
                    if (txtInquiry.Text.Trim() != "")
                    {
                        SQl = T_DiagCEF_Sql + "  and  SHORTCUT1  like '%" + txtInquiry.Text.Trim() + "%' order by DIAG_ID desc";
                    }
                }
                //根据五笔进行查询
                else if (chkWB.Checked)
                {
                    if (txtInquiry.Text.Trim() != "")
                    {
                        SQl = T_DiagCEF_Sql + "  and  SHORTCUT2  like '%" + txtInquiry.Text.Trim() + "%' order by DIAG_ID desc";
                    }
                }
                else
                {
                }
                ucGridviewX1.DataBd(SQl, "诊断编号", false, "", "");
                ucGridviewX1.fg.Columns["诊断编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属目录编号"].Visible = false;
                ucGridviewX1.fg.Columns["所属目录编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].Visible = false;
                ucGridviewX1.fg.Columns["诊断属性种类编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
               

            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSelect.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPinyin.Text =App.getSpell(App.ToDBC(txtName.Text.Trim()));
            txtWuBi.Text = App.GetWBcode(App.ToDBC(txtName.Text.Trim()));

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboDiagCAT.Focus();
            }

        }

        private void cboDiagCAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMedicine.Focus();
            }

        }

        private void cboMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnYes.Focus();
            }

        }

        private void rbtnYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDTC.Focus();
            }

        }

        private void rbtnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }

        }

        private void txtDTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }

        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
  
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        　　
        }
        /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
                txtCode.Text = "";
                txtName.Text = "";
                txtDTC.Text = "";
                txtCode.Enabled = false;
                txtName.Enabled = false;
                txtPinyin.Enabled = false;
                txtWuBi.Enabled = false;
                cboDiagCAT.Enabled = false;
                cboMedicine.Enabled = false;
                rbtnYes.Enabled = false;
                rbtnNo.Enabled = false;
                txtDTC.Enabled = false;
                cboType.Enabled = false;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                //groupBox1.Enabled = true;
                groupPanel2.Enabled = true;
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                App.ExecuteSQL("delete from T_DIAG_DEF where  DIAG_ID='" + ucGridviewX1.fg["诊断编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
            }
            ShowValue();
            refurbish();
            
        }





    }

}