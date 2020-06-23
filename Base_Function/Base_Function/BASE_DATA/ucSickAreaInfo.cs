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
    public partial class ucSickAreaInfo : UserControl
    {
        bool IsSave = false;　               //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string BigsickArea = "Y";   //是否为大病区
        private string mark = "Y";         //有效标志
        private string  ID="";            //病区ID
        private string T_SickArea_Sql;   //病区查询
        Class_Sickarea[] sickarea;
        private string sick_area_code;   //当前选中的病区编号
        private string sick_area_name;   //当前选中的病区名称
        DataSet ds;
        public ucSickAreaInfo()
        {
            InitializeComponent();
            T_SickArea_Sql = @"select SAID as 编号,a.SHID as 分院编号,c.sub_hospital_name as 分院名称,SICK_AREA_CODE as 病区编号," +
                         @"SICK_AREA_NAME as 病区名称,(case when ISBELONGTOSECTION='Y' then '是' else '否' end) as 是否大病区," +
                         @"BELONGTOSECTION as 所属大病区,(select SICK_AREA_NAME from T_SICKAREAINFO b where b.SAID=a.belongtosection and ENABLE_FLAG='Y') as 大病区名称," +
                         @"(case when ENABLE_FLAG='Y' then '有效' else '无效' end) as 有效标志," +
                         @"BED_COUNT as 标准病床数,ALOW_COUNT as 允许加床数 from T_SICKAREAINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid where ENABLE_FLAG='Y'";
        }

        private void frmSickAreaInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("病区信息");
            //显示列表数据
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            HospitalInfo();
            Bigsickarea();
            btnCancel_Click(sender, e);
            cboBigsickarea.SelectedIndex = 0;
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {

                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属大病区"].Visible = false;
                ucGridviewX1.fg.Columns["所属大病区"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //显示列表数据
        private void ShowValue()
        {
           
                string SQl = T_SickArea_Sql + " order by SAID desc";
                 ds = App.GetDataSet(SQl);
                 if (ds != null)
                 {

                     //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                     ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                     ucGridviewX1.fg.Columns["编号"].Visible = false;
                     ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                     ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                     ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                     ucGridviewX1.fg.Columns["所属大病区"].Visible = false;
                     ucGridviewX1.fg.Columns["所属大病区"].ReadOnly = true;
                     ucGridviewX1.fg.ReadOnly = true;
                 }

        }
        //绑定大病区
        private void Bigsickarea()
        {
            cboBigsickarea.Items.Clear();
            Class_Sickarea none=new Class_Sickarea();
            none.Said = "";
            none.Shid = "无";
            none.Sick_area_code = "无";
            none.Sick_area_name = "无";
            none.Isbelongtosection = "无";
            none.Belongtosection="无";
            none.Enable_flag = "无";
            none.Bed_count = "无";
            none.Alow_count = "无";
            cboBigsickarea.Items.Add(none);
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where ISBELONGTOSECTION='Y'and ENABLE_FLAG='Y'");
            sickarea = new Class_Sickarea[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sickarea[i] = new Class_Sickarea();
                sickarea[i].Said =ds.Tables[0].Rows[i]["SAID"].ToString();
                sickarea[i].Shid = ds.Tables[0].Rows[i]["SHID"].ToString();
                sickarea[i].Sick_area_code = ds.Tables[0].Rows[i]["SICK_AREA_CODE"].ToString();
                sickarea[i].Sick_area_name = ds.Tables[0].Rows[i]["SICK_AREA_NAME"].ToString();
                sickarea[i].Isbelongtosection = ds.Tables[0].Rows[i]["ISBELONGTOSECTION"].ToString();
                sickarea[i].Belongtosection = ds.Tables[0].Rows[i]["BELONGTOSECTION"].ToString();
                sickarea[i].Enable_flag = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                sickarea[i].Bed_count = ds.Tables[0].Rows[i]["BED_COUNT"].ToString();
                sickarea[i].Alow_count = ds.Tables[0].Rows[i]["ALOW_COUNT"].ToString();
                cboBigsickarea.Items.Add(sickarea[i]);
                
            }
            //cboBigsickarea.DataSource = ds.Tables[0].DefaultView;
            cboBigsickarea.ValueMember = "SAID";
            cboBigsickarea.DisplayMember = "SICK_AREA_NAME";
        }
        //所属分院
        private void HospitalInfo()
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO ");
            cboBranchcourts.DataSource = ds.Tables[0].DefaultView;
            cboBranchcourts.ValueMember = "SHID";
            cboBranchcourts.DisplayMember = "SUB_HOSPITAL_NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
   
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboBigsickarea.Enabled = false;
            rdtnSickAreaYes.Enabled = false;
            rdtnSickAreaNo.Enabled = false;
            cboBranchcourts.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            txtSickbed.Enabled = false;
            txtExtrabed.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            IsSave = false;

        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtNumber.Text = "";
                txtName.Text = "";
                txtSickbed.Text = "";
                txtExtrabed.Text = "";
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboBigsickarea.Enabled = true;
            rdtnSickAreaYes.Enabled = true;
            rdtnSickAreaNo.Enabled = true;
            cboBranchcourts.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            txtSickbed.Enabled = true;
            txtExtrabed.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (rdtnSickAreaYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigsickarea.Enabled = false;
                    cboBigsickarea.SelectedIndex = -1;
                }
            }
            else
            {
                cboBigsickarea.Enabled = true;
            }
            txtNumber.Focus();
        }

        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where SICK_AREA_CODE='" + id + "'");
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
        private bool Isnames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where SICK_AREA_NAME='" + name + "'");
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
        ///添加
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
           
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
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("病区编号不能为空！");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("病区名称不能为空！");
                    txtName.Focus();
                    return;
                }
                if (cboBranchcourts.Text.Trim() == "")
                {
                    App.Msg("所属分院不能为空！");
                    cboBranchcourts.Focus();
                    return;
                }
                if (!rdtnSickAreaYes.Checked)
                {
                    BigsickArea = "N";

                }
                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                string sql = "";
                string bigid = "";
                if (rdtnSickAreaYes.Checked)
                {
                    bigid = null;
                }
                else
                {
                
                    if (cboBigsickarea.SelectedItem != null)
                    {
                        Class_Sickarea temp = (Class_Sickarea)cboBigsickarea.SelectedItem;
                        bigid = temp.Said.ToString();
                    }
                }
                ID = App.GenId("T_SICKAREAINFO", "SAID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同名称的病区编号了！");
                        txtNumber.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同名称的病区名称了！");
                        txtName.Focus();
                        return;
                    }

                    sql = "insert into T_SICKAREAINFO(SAID,SHID,SICK_AREA_CODE,SICK_AREA_NAME,ISBELONGTOSECTION,BELONGTOSECTION,ENABLE_FLAG,BED_COUNT,ALOW_COUNT) values('"
                         + ID + "','"
                         + cboBranchcourts.SelectedValue + "','"
                         + txtNumber.Text + "','"
                         + App.ToDBC(txtName.Text) + "','"
                         + BigsickArea + "','"
                         + bigid + "','"
                         + mark + "','"
                         +txtSickbed.Text+ "','"
                         +txtExtrabed.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (sick_area_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim()!=sick_area_code.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("已经存在了相同名称的病区编号了！");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    else if (sick_area_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != sick_area_name.Trim())
                        {
                            if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同名称的病区名称了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SICKAREAINFO set SHID='"
                              + cboBranchcourts.SelectedValue + "',SICK_AREA_CODE='"
                              + txtNumber.Text + "',SICK_AREA_NAME='"
                              + App.ToDBC(txtName.Text) + "',ISBELONGTOSECTION='"
                              + BigsickArea + "',BELONGTOSECTION='"
                              + bigid + "',ENABLE_FLAG='"
                              + mark + "',BED_COUNT='"
                              + txtSickbed.Text + "',ALOW_COUNT='"
                              + txtExtrabed.Text + "' where SAID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
                //string SQl = T_SickArea_Sql;
                //ucC1FlexGrid1.DataBd(SQl, "SAID", "SAID,SHID,SHID_NAME,SICK_AREA_CODE,SICK_AREA_NAME,ISBELONGTOSECTION,BELONGTOSECTION,ENABLE_FLAG,BED_COUNT,ALOW_COUNT", "编号,分院编号,分院名称,病区编号,病区名称,是否大病区,所属大病区,有效标志,标准病床数,允许加床数");
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
            //RefleshFrm();
            refurbish();
        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sick_area_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["病区名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sick_area_name = txtName.Text;
                    //cboBigsickarea.Text = "";
                    //cboBigsickarea.Items.Clear();
                    cboBigsickarea.SelectedItem = null;
                    if (ucGridviewX1.fg["是否大病区", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        rdtnSickAreaYes.Checked = true;
                        //cboBigsickarea.SelectedItem = -1;
                        cboBigsickarea.SelectedItem = null;
                    }
                    else
                    {
                        string said = "";
                        rdtnSickAreaNo.Checked = true;
                        if (ucGridviewX1.fg["所属大病区", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                        {
                            said = ucGridviewX1.fg["所属大病区", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            SelectValues(said);
                        }
                        else
                        {

                            SelectValues(said);
                        }


                    }

                    if (ucGridviewX1.fg["分院编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboBranchcourts.SelectedValue = ucGridviewX1.fg["分院编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["有效标志", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有效")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["标准病床数", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        txtSickbed.Text = Convert.ToInt32(ucGridviewX1.fg["标准病床数", ucGridviewX1.fg.CurrentRow.Index].Value).ToString();
                    }
                    if (ucGridviewX1.fg["允许加床数", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        txtExtrabed.Text = Convert.ToInt32(ucGridviewX1.fg["允许加床数", ucGridviewX1.fg.CurrentRow.Index].Value).ToString();
                    }

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
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }

         /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtSickbed.Text = "";
            txtExtrabed.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboBigsickarea.Enabled = false;
            rdtnSickAreaYes.Enabled = false;
            rdtnSickAreaNo.Enabled = false;
            cboBranchcourts.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            txtSickbed.Enabled = false;
            txtExtrabed.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
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
                DataSet ds = App.GetDataSet("select Count(*) from T_SECTION_AREA where SAID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    string sql = "update  T_SICKAREAINFO  set ENABLE_FLAG='N' where  SAID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    App.ExecuteSQL(sql);
                    
                }
                else
                {
                    
                    if (App.Ask("该病区信息已经与科室或其它相关联，点击“是”删除病区并解除关联!"))
                    {
                        App.ExecuteSQL("update T_SICKAREAINFO  set ENABLE_FLAG='N' where  SAID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                        
                    }
                }
            }
            //显示列表数据
            ShowValue();
            refurbish();
        }
        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                chkId.Checked = false;
            }
            else
            {
                chkId.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkId.Checked)
            {
                chkName.Checked = false;
            }
            else
            {
                chkName.Checked = true;
                txtBox.Text = "";
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                btnLookup.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                string Sql = T_SickArea_Sql + " order by SAID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //按病区名称进行查询
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_SickArea_Sql + " and SICK_AREA_NAME　like'%" + txtBox.Text.Trim() + "%' order by SAID desc";
                      
                    }

                }
                //按病区编号进行查询
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_SickArea_Sql + " and 　SICK_AREA_CODE 　like'%" + txtBox.Text.Trim() + "%' order by SAID desc";
                       
                    }
                }
                ucGridviewX1.DataBd(Sql, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属大病区"].Visible = false;
                ucGridviewX1.fg.Columns["所属大病区"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;

            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
            }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
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
                cboBranchcourts.Focus();
            }

        }

        private void cboBranchcourts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnSickAreaYes.Focus();
            }

        }

        private void rdtnSickAreaYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnValidmark.Focus();
            }

        }

        private void rdtnSickAreaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigsickarea.Focus();
            }

        }
        private void cboBigsickarea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnValidmark.Focus();
            }

        }

  
        private void rbtnValidmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSickbed.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSickbed.Focus();
            }

        }

        private void txtSickbed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtExtrabed.Focus();
            }

        }

        private void txtExtrabed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        
        }

        private void rdtnSickAreaYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnSickAreaYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigsickarea.Enabled = false;
                    cboBigsickarea.SelectedIndex = -1;
                } 
            } 
        }

        private void rdtnSickAreaNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnSickAreaNo.Checked == true)
            {
                Bigsickarea();
                if (btnCancel.Enabled)
                    cboBigsickarea.Enabled = true;
                cboBigsickarea.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 根据表格选中下拉列表
        /// </summary>
        /// <returns></returns>
        public void SelectValues(string said)
        { 
            //bool flag =false;
            foreach (object var in cboBigsickarea.Items)
	        {
                Class_Sickarea class_Sickarea = var as Class_Sickarea;
                if (said == class_Sickarea.Said.ToString())
                {
                    cboBigsickarea.SelectedItem = var;
                    break;
                }
                else
                {
                    cboBigsickarea.SelectedIndex = 0;
                }
	        }
        }
     
    }
}