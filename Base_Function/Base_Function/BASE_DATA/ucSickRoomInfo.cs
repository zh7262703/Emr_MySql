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
    public partial class ucSickRoomInfo : UserControl
    {
        bool IsSave = false;　　　　　　　//用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID;　　　　　　　　//病房ID
        private string mark = "Y";　　　　//有效标志
        private string T_SickRoomInfo;　　//病房查询
        private string sick_room_code;    //当前选中的病室编号
        DataSet ds;
        public ucSickRoomInfo()
        {
            InitializeComponent();
            T_SickRoomInfo = @"select SRID as 编号,a.SAID 病区编号,b.sick_area_name as 病区名称,SICK_ROOM_CODE as 病室编号," +
                            @"BEDLEVEL as 等级编号,c.name as 等级,ORG_PROP as 编制,(case when SEX_CTRL=0 then '是' else '否' end) as 性别控制标志," +
                            @"(case when SEX_FLAG=0 then '男' else '女' end) as 性别,(case when ENABLEFLAG='Y' then '有效' else '无效' end) as 有效标志 from T_SICKROOMINFO a left join T_SICKAREAINFO b on b.said=a.said left join T_DATA_CODE c on c.id=a.bedlevel  where  ENABLEFLAG='Y' ";
           
        }

        private void frmSickRoomInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("病房信息");
            //显示列表数据
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            cboGender.SelectedIndex = 0;
            cboGender1.SelectedIndex = 0;
            Grade();
            Sick();
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //显示列表数据
        private void ShowValue()
        {
            string SQl = T_SickRoomInfo + "  order by SRID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }



        }
        //绑定等级
        private void Grade()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='13'");
            cboGrade.DataSource = ds.Tables[0].DefaultView;
            cboGrade.ValueMember = "ID";
            cboGrade.DisplayMember = "NAME";
        }
        //绑定病区
        private void Sick()
        {
            DataSet ds = App.GetDataSet("select * from  T_SICKAREAINFO where ISBELONGTOSECTION='N' and  ENABLE_FLAG='Y'");
            cboSick.DataSource = ds.Tables[0].DefaultView;
            cboSick.ValueMember = "SAID";
            cboSick.DisplayMember = "SICK_AREA_NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
           
            txtNumber.Enabled = false;
            cboSick.Enabled = false;
            cboGrade.Enabled = false;
            txtBraid.Enabled = false;
            cboGender.Enabled = false;
            cboGender1.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
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
                txtBraid.Text = "";
            }
            txtNumber.Enabled = true;
            cboSick.Enabled = true;
            cboGrade.Enabled = true;
            txtBraid.Enabled = true;
            cboGender.Enabled = true;
            cboGender1.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if(cboGender.SelectedIndex==0)
            {
                cboGender1.Enabled = true;

            }
            else
            {
                if (btnCancel.Enabled)
                    cboGender1.Enabled = false; 
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
            DataSet ds = App.GetDataSet("select * from T_SICKROOMINFO where SICK_ROOM_CODE='" + id + "'");
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
                    App.Msg("病房编号不能为空！");
                    txtNumber.Focus();
                    return;
                }
                if (cboSick.Text.Trim() == "")
                {
                    App.Msg("所属病区不能为空！");
                    cboSick.Focus();
                    return;
                }
                if (cboGrade.Text.Trim() == "")
                {
                    App.Msg("等级不能为空！");
                    cboGrade.Focus();
                    return;
                }

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                string sql = "";

                ID = App.GenId("T_SICKROOMINFO", "SRID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的病室编号了！");
                        txtNumber.Focus();
                        return;
                    }
                    sql = "insert into T_SICKROOMINFO(SRID,SAID,SICK_ROOM_CODE,BEDLEVEL,ORG_PROP,SEX_CTRL,SEX_FLAG,ENABLEFLAG) values('"
                         + ID + "','"
                         + cboSick.SelectedValue + "','"
                         + txtNumber.Text + "','"
                         + cboGrade.SelectedValue + "','"
                         + txtBraid.Text + "','"
                         + cboGender.SelectedIndex.ToString() + "','"
                         + cboGender1.SelectedIndex.ToString() + "','"
                         + mark + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (sick_room_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != sick_room_code.Trim())
                        {
                             if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的病室编号了！");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SICKROOMINFO set SAID='"
                              + cboSick.SelectedValue + "',SICK_ROOM_CODE='"
                              + txtNumber.Text + "',BEDLEVEL='"
                              + cboGrade.SelectedValue + "',ORG_PROP='"
                              + txtBraid.Text + "',SEX_CTRL='"
                              + cboGender.SelectedIndex.ToString() + "',SEX_FLAG='"
                              + cboGender1.SelectedIndex.ToString() + "',ENABLEFLAG='"
                              + mark + "'  where SRID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].ToString() + "";

                }
                 if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
                //string SQl = T_SickRoomInfo + "  order by SRID asc";
                //ucC1FlexGrid1.DataBd(SQl, "SRID", "SRID,SAID,SAID_name,SICK_ROOM_CODE,BEDLEVEL,BEDLEVEL_NAME,ORG_PROP,SEX_CTRL,SEX_FLAG,ENABLEFLAG", "编号,病区编号,病区名称,病室编号,等级编号,等级,编制,性别控制标志,性别(当前),有效标志");
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
            }
        }
        /// <summary>
        /// 添加
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
                    if (ucGridviewX1.fg["病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSick.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    txtNumber.Text = ucGridviewX1.fg["病室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sick_room_code = txtNumber.Text;
                    if (ucGridviewX1.fg["等级编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboGrade.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["等级编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    txtBraid.Text = ucGridviewX1.fg["编制", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["性别控制标志", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        cboGender.SelectedIndex = 0;

                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;

                    }
                    if (ucGridviewX1.fg["性别", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "男")
                    {
                        cboGender1.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender1.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["有效标志", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有效")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }

                    //int rows = this.ucGridviewX1.fg.RowSel;//定义选中的行号 
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
                RefleshFrm();
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
            txtBraid.Text = "";
            txtNumber.Enabled = false;
            cboSick.Enabled = false;
            cboGrade.Enabled = false;
            txtBraid.Enabled = false;
            cboGender.Enabled = false;
            cboGender1.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
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
                App.ExecuteSQL("update  T_SICKROOMINFO set ENABLEFLAG='N' where  SRID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //显示列表数据
            ShowValue();
            refurbish();
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
                string SQl = T_SickRoomInfo + " order by SRID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //按病区名称
                if (chkSick.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {

                        SQl = T_SickRoomInfo + " and 　b.sick_area_name 　like'%" + txtBox.Text.Trim() + "%' order by SRID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //按病房编号
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickRoomInfo + " and 　SICK_ROOM_CODE　like'%" + txtBox.Text.Trim() + "%' order by SRID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
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
        private void chkId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkId.Checked)
            {
                chkSick.Checked = false;
            }
            else
            {
                chkSick.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkSick_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSick.Checked)
            {
                chkId.Checked = false;
            }
            else
            {
                chkId.Checked = true;
                txtBox.Text = "";
            }
        }
        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSick.Focus();
            }

        }

        private void cboSick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGrade.Focus();
            }

        }

        private void cboGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBraid.Focus();
            }

        }

        private void txtBraid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGender.Focus();
            }

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboGender1.Focus();
                }

            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbtnValidmark.Focus();
                }

            }
           
        }

        private void cboGender1_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender,e);
            }
       
        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
            {
                cboGender1.Enabled = true;
            }
            else
            {
                if(btnCancel.Enabled)
                    cboGender1.Enabled = false; 
            }
        }




  

     
    }
}