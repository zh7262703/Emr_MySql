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
    public partial class ucSickBedInfo : UserControl
    {
        bool IsSave = false;              //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID;               //病床ID
        private string mark = "Y";      //有效标志
        private string T_SickBedInfo;   //病房查询
        private string bed_code;        //当前选中的病床编号
        private string bed_name;        //当前选中的床号
        DataSet ds;
        public ucSickBedInfo()
        {
            InitializeComponent();
            T_SickBedInfo = @"select BED_ID as 编号,a.SRID as 病室编号,b.sick_room_code as 病室名称,a.SID as 科室编号,c.section_name as 科室名称," +
                        @"a.SAID as 病区编号,d.sick_area_name as 病区名称,BED_CODE as 病床编号,BED_NO as 床号,a.typeinfo as 类别编号,g.name as 类别名称," +
                        @"a.BEDLEVEL as 等级编号,k.name as 等级名称,a.ORG_PROP as 编制,STATE as 状态编号,t.name as 状态名称," +
                        @"(case when a.SEX_CTRL=0 then '是' else '否' end) as 性别控制标志,(case when a.SEX_FLAG=0 then '男' when a.SEX_FLAG=1 then '女' else  '无' end) as 性别," +
                        @"(case when a.ENABLEFLAG='Y' then '有效' else '无效' end) as 有效标志," +
                        @"PID as 所属病人 from T_SICKBEDINFO a left join T_SICKROOMINFO b on b.srid=a.srid left join T_SECTIONINFO c on c.sid=a.sid left join T_SICKAREAINFO d on d.said=a.said left join T_DATA_CODE g on g.id=a.typeinfo left join T_DATA_CODE k on k.id=a.bedlevel left join T_DATA_CODE t on t.id=a.state";
        }
        private void frmSickBedInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("病床信息");
            //显示列表数据
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            cboGender.SelectedIndex = 0;
            cboGender1.SelectedIndex = 0;
            cboSickbedconstion.SelectedIndex = 0;
            SickRoom();
            Section();
            SickBay();
            Type();
            Grade();
            RefleshFrm();
        }
        private void frmSickBedInfo_Activated(object sender, EventArgs e)
        {
            //显示列表数据
            ShowValue();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病床编号"].Visible = false;
                ucGridviewX1.fg.Columns["病床编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病室编号"].Visible = false;
                ucGridviewX1.fg.Columns["病室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["科室编号"].Visible = false;
                ucGridviewX1.fg.Columns["科室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["状态编号"].Visible = false;
                ucGridviewX1.fg.Columns["状态编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属病人"].Visible = false;
                ucGridviewX1.fg.Columns["所属病人"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //显示列表数据
        private void ShowValue()
        {
            string SQl = T_SickBedInfo + " order by BED_ID desc";
             ds = App.GetDataSet(SQl);
             if (ds != null)
             {

                 //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                 ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                 ucGridviewX1.fg.Columns["编号"].Visible = false;
                 ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["病床编号"].Visible = false;
                 ucGridviewX1.fg.Columns["病床编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["病室编号"].Visible = false;
                 ucGridviewX1.fg.Columns["病室编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["科室编号"].Visible = false;
                 ucGridviewX1.fg.Columns["科室编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                 ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                 ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                 ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["状态编号"].Visible = false;
                 ucGridviewX1.fg.Columns["状态编号"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["所属病人"].Visible = false;
                 ucGridviewX1.fg.Columns["所属病人"].ReadOnly = true;
                 ucGridviewX1.fg.ReadOnly = true;

             }

        }
        //绑定病房
        private void SickRoom()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from  T_SICKROOMINFO where SAID='" + cboSickBay.SelectedValue + "' and  ENABLEFLAG='Y'");
                cboSickRoom.DataSource = ds.Tables[0].DefaultView;
                cboSickRoom.ValueMember = "SRID";
                cboSickRoom.DisplayMember = "SICK_ROOM_CODE";
            }
            catch
            {
            }
        }
        //绑定科室
        private void Section()
        {
            try
            {

                DataSet ds = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join T_SECTIONINFO  b on b.sid=g.sid  where g.said='" + cboSickBay.SelectedValue + "' and  b.ENABLE_FLAG='Y'");
                cboSection.DataSource = ds.Tables[0].DefaultView;
                cboSection.ValueMember = "SID";
                cboSection.DisplayMember = "SECTION_NAME";

            }
            catch
            { }

        }
        //绑定病区
        private void SickBay()
        {
            DataSet ds = App.GetDataSet("select * from  T_SICKAREAINFO  where ISBELONGTOSECTION='N' and  ENABLE_FLAG='Y'");
            cboSickBay.DataSource = ds.Tables[0].DefaultView;
            cboSickBay.ValueMember = "SAID";
            cboSickBay.DisplayMember = "SICK_AREA_NAME";

        }
        //绑定等级
        private void Grade()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='13'");
                cboGrade.DataSource = ds.Tables[0].DefaultView;
                cboGrade.ValueMember = "ID";
                cboGrade.DisplayMember = "NAME";
            }
            catch
            {
            }
        }
        //绑定病床类别
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE where Type='15'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            txtID.Enabled = false;
            cboSickRoom.Enabled = false;
            cboSickBay.Enabled = false;
            cboSection.Enabled = false;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = false;
            cboType.Enabled = false;
            cboGrade.Enabled = false;
            txtPlait.Enabled = false;
            cboState.Enabled = false;
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
                txtID.Text = "";
                txtBed.Text = "";
                txtPlait.Text = "";
            }
            txtID.Enabled = true;
            cboSickRoom.Enabled = true;
            cboSickBay.Enabled = true;
            cboSection.Enabled = true;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = true;
            cboType.Enabled = true;
            cboGrade.Enabled = true;
            txtPlait.Enabled = true;
            cboState.Enabled = true;
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
            if (cboGender.SelectedIndex == 0)
            {
                cboGender1.Enabled = true;
            }
            else
            {
                if (btnCancel.Enabled)
                {
                    cboGender1.Enabled = false;
                    cboGender1.SelectedIndex = 2;

                }
            }
            txtID.Focus();
        }

        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SICKBEDINFO  where BED_CODE='" + id + "'");
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
        private bool IsExisitBed(string Bed)
        {
            DataSet ds = App.GetDataSet("select SAID from T_SICKBEDINFO where  BED_NO='" + Bed + "'and SAID='" + cboSickBay.SelectedValue + "'");
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
                //if (txtID.Text.Trim()=="")
                //{
                //    App.Msg("病床编号不能为空！");
                //    txtID.Focus();
                //    return;
                //}
                //if (cboSickRoom.Text.Trim() == "")
                //{
                //    App.Msg("所属病房不能为空！");
                //    cboSickRoom.Focus();
                //    return;
                //}
                if (cboSickBay.Text.Trim() == "")
                {
                    App.Msg("所属科室不能为空！");
                    cboSickBay.Focus();
                    return;
                }
                if (cboSection.Text.Trim() == "")
                {
                    App.Msg("所属病区不能为空！");
                    cboSection.Focus();
                    return;
                }
                if (txtBed.Text.Trim() == "")
                {
                    App.Msg("床号不能为空！");
                    txtBed.Focus();
                    return;
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("类别不能为空！");
                    cboType.Focus();
                    return;
                }
                if (cboGrade.Text.Trim() == "")
                {
                    App.Msg("等级不能为空！");
                    cboGrade.Focus();
                    return;
                }
                if (cboGender.Text.Trim() == "")
                {
                    App.Msg("性别控制标志必须填写");
                    cboGender.Focus();
                    return;
                }

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                string sql = "";

                ID = App.GenId("T_SICKBEDINFO ", "BED_ID").ToString();
                if (IsSave)
                {
                    //if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    //{
                    //    App.Msg("已经存在了相同名称的病床编号了！");
                    //    txtID.Focus();
                    //    return;
                    //}
                    if (IsExisitBed(App.ToDBC(txtBed.Text.Trim())))
                    {
                        App.Msg("相同的病区中已经有相同的床号了！");
                        txtBed.Focus();
                        return;
                    }
                    sql = "insert into T_SICKBEDINFO(BED_ID,SRID,SID,SAID,BED_CODE,BED_NO,TYPEINFO,BEDLEVEL,ORG_PROP,STATE,SEX_CTRL,SEX_FLAG,ENABLEFLAG) values("
                         + ID + ",'"
                         + cboSickRoom.SelectedValue + "',"
                         + cboSection.SelectedValue + ","
                         + cboSickBay.SelectedValue + ",'"
                         + txtBed.Text + "','"
                         + txtBed.Text + "',"
                         + cboType.SelectedValue + ","
                         + cboGrade.SelectedValue + ",'"
                         + txtPlait.Text + "',75,'"
                         + cboGender.SelectedIndex.ToString() + "','"
                         + cboGender1.SelectedIndex.ToString() + "','"
                         + mark + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    //if (bed_code.Trim() != "")
                    //{
                    //    if (txtID.Text.Trim() != bed_code.Trim())
                    //    {
                    //       if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    //        {
                    //            App.Msg("已经存在了相同名称的病床编号了！");
                    //            txtID.Focus();
                    //            return;
                    //        }
                    //    }
                    //}
                    if (bed_name.Trim() != "")
                    {
                        if (txtBed.Text.Trim() != bed_name.Trim())
                        {
                            if (IsExisitBed(App.ToDBC(txtBed.Text.Trim())))
                            {
                                App.Msg("相同的病区中已经有相同的床号了！");
                                txtBed.Focus();
                                return;
                            }
                        }
                    }

                    sql = "update T_SICKBEDINFO set SRID='"
                              + cboSickRoom.SelectedValue + "',SID="
                              + cboSection.SelectedValue + ",SAID="
                              + cboSickBay.SelectedValue + ",BED_CODE='"
                              + txtBed.Text + "',BED_NO='"
                              + txtBed.Text + "',TYPEINFO="
                              + cboType.SelectedValue + ",BEDLEVEL="
                              + cboGrade.SelectedValue + ",ORG_PROP='"
                              + txtPlait.Text + "',SEX_CTRL='"
                              + cboGender.SelectedIndex.ToString() + "',SEX_FLAG='"
                              + cboGender1.SelectedIndex.ToString() + "',ENABLEFLAG='"
                              + mark + "'  where BED_ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
                //string SQl = T_SickBedInfo;
                //ucC1FlexGrid1.DataBd(SQl, "BED_ID", "BED_ID,SRID,SRID_NAME,SID,SECTION_SID,SAID,SICK_SAID,BED_CODE,BED_NO,TYPEINFO,TYPEINFO_NAME,BEDLEVEL,BEDLEVEL_NAME,ORG_PROP,STATE,STATE_NAME,SEX_CTRL,SEX_FLAG,ENABLEFLAG,PID", "编号,病室编号,病室名称,科室编号,科室名称,病区编号,病区名称,病床编号,床号,类别编号,类别名称,等级编号,等级名称,编制,状态编号,状态名称,性别控制标志,性别(当前),有效标志,所属病人");

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
                    if (ucGridviewX1.fg["病室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSickRoom.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["病室编号",ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["科室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSection.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["科室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSickBay.SelectedValue = ucGridviewX1.fg["病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();//Convert.ToInt32

                    }
                    txtID.Text = ucGridviewX1.fg["病床编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    bed_code = txtID.Text;
                    txtBed.Text = ucGridviewX1.fg["床号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    bed_name = txtBed.Text;
                    if (ucGridviewX1.fg["类别编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboType.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["类别编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["等级编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboGrade.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["等级编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    txtPlait.Text = ucGridviewX1.fg["编制", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["状态编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboState.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["状态编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
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
                    //cboSickperson.Text =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "所属病人"].ToString();
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
                string SQl = T_SickBedInfo + " order by BED_ID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                // 按床号
                if (cboSickbedconstion.SelectedIndex == 0)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where 　BED_NO　like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //按科室名称
                else if (cboSickbedconstion.SelectedIndex == 1)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where  　c.section_name　like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                //按病区名称
                else  if (cboSickbedconstion.SelectedIndex == 2)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where 　d.sick_area_name　like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                //按有效标志 
                else if (cboSickbedconstion.SelectedIndex == 3)
                {

                    if (cboValidmark.SelectedIndex == 0)
                    {
                        SQl = T_SickBedInfo + "  where  a.ENABLEFLAG='Y' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                    else if (cboValidmark.SelectedIndex == 1)
                    {
                        SQl = T_SickBedInfo + "  where  a.ENABLEFLAG='N' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病床编号"].Visible = false;
                ucGridviewX1.fg.Columns["病床编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病室编号"].Visible = false;
                ucGridviewX1.fg.Columns["病室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["科室编号"].Visible = false;
                ucGridviewX1.fg.Columns["科室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["病区编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["等级编号"].Visible = false;
                ucGridviewX1.fg.Columns["等级编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["状态编号"].Visible = false;
                ucGridviewX1.fg.Columns["状态编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属病人"].Visible = false;
                ucGridviewX1.fg.Columns["所属病人"].ReadOnly = true;
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
        /// 根据床号的编号获得创的状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string State(string id)
        {
            string sql = "select STATE from T_SICKBEDINFO where BED_ID='" + id + "'";
            string sta_id = App.ReadSqlVal(sql, 0, "STATE");
            return sta_id;
        }
        /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtBed.Text = "";
            txtPlait.Text = "";
            txtID.Enabled = false;
            cboSickRoom.Enabled = false;
            cboSickBay.Enabled = false;
            cboSection.Enabled = false;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = false;
            cboType.Enabled = false;
            cboGrade.Enabled = false;
            txtPlait.Enabled = false;
            cboState.Enabled = false;
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
                string state_id = "";
                state_id = ucGridviewX1.fg["状态编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (state_id == "75")
                {

                    if (App.ExecuteSQL("delete from T_SICKBEDINFO where  BED_ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("操作已经成功！");
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }
                }
                else
                {
                    App.MsgErr("床号已经被病人占有，不能进行删除");
                }

            }
            //显示列表数据
            ShowValue();
            refurbish();
            //string SQl = T_SickBedInfo;
            //ucC1FlexGrid1.DataBd(SQl, "BED_ID", "BED_ID,SRID,SRID_NAME,SID,SECTION_SID,SAID,SICK_SAID,BED_CODE,BED_NO,TYPEINFO,TYPEINFO_NAME,BEDLEVEL,BEDLEVEL_NAME,ORG_PROP,STATE,STATE_NAME,SEX_CTRL,SEX_FLAG,ENABLEFLAG,PID", "编号,病室编号,病室名称,科室编号,科室名称,病区编号,病区名称,病床编号,床号,类别编号,类别名称,等级编号,等级名称,编制,状态编号,状态名称,性别控制标志,性别(当前),有效标志,所属病人");

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
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickBay.Focus();
            }
        }

        private void txtBed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickBay.Focus();
            }

        }
        private void cboSickBay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSection.Focus();
            }

        }

        private void cboSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickRoom.Focus();
            }

        }

        private void cboSickRoom_KeyDown(object sender, KeyEventArgs e)
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
                cboGrade.Focus();
            }

        }

        private void cboGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPlait.Focus();
            }

        }

        private void txtPlait_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender, e);
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void cboSickBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Section();
            SickRoom();
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SickBay();
        }

        private void cboSickRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grade();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
            {
                cboGender1.Enabled = true;

            }
            else
            {
                if (btnCancel.Enabled)
                {

                    cboGender1.Enabled = false;
                    cboGender1.SelectedIndex = 2;

                }
            }
        }
        /// <summary>
        /// 查询条件的判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSickbedconstion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSickbedconstion.Enabled == true)
            {
                //查询条件为按有效标志
                if (cboSickbedconstion.SelectedIndex == 3)
                {
                    cboValidmark.Visible = true;
                    cboValidmark.Enabled = true;
                    txtBox.Enabled = false;
                    txtBox.Visible = false;
                }
                else
                {
                    cboValidmark.Visible = false;
                    cboValidmark.Enabled = false;
                    txtBox.Enabled = true;
                    txtBox.Visible = true;
                }
            }
        }

        /// <summary>
        /// 床位同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBedRef_Click(object sender, EventArgs e)
        {

            try
            {

                //HIS床位
                //select * from HNYZ_ZXYY.intf_emr_bedview where BQID=2037

                //我方床位
                //select * from t_sickbedinfo bb where bb.said=39

                //床位对照
                DataSet ds_Area = App.GetDataSet("select bbb.said,bbb.sick_area_code from t_sickareainfo bbb where length(bbb.sick_area_code)>=4");// and shid=221");//221南院,1北院
                List<string> Sqls = new List<string>();
                for (int i1 = 0; i1 < ds_Area.Tables[0].Rows.Count; i1++)
                {
                    string hisaid = ds_Area.Tables[0].Rows[i1]["sick_area_code"].ToString();//EMR中的sick_area_code对应his中的病区id
                    string said = ds_Area.Tables[0].Rows[i1]["said"].ToString();
                    //查出his中对应病室的所有床位信息
                    DataSet ds_his_bed = App.GetDataSet("select * from HNYZ_ZXYY.intf_emr_bedview@dbhislink where BQID=" + hisaid + "");
                    DataSet ds_our_bed = App.GetDataSet("select * from t_sickbedinfo bb where bb.said=" + said + "");

                    for (int i = 0; i < ds_our_bed.Tables[0].Rows.Count; i++)
                    {//用床号去匹配his中床号
                        string bedno = ds_our_bed.Tables[0].Rows[i]["bed_no"].ToString();
                        for (int j = 0; j < ds_his_bed.Tables[0].Rows.Count; j++)
                        {
                            string bed_his_CWM = ds_his_bed.Tables[0].Rows[j]["CWMC"].ToString();
                            string bed_his_Code = ds_his_bed.Tables[0].Rows[j]["CWDM"].ToString();
                            if (App.IsNumeric(bedno) && App.IsNumeric(bed_his_CWM))
                            {
                                if (Convert.ToInt16(bedno) == Convert.ToInt16(bed_his_CWM))
                                {
                                    Sqls.Add("update t_sickbedinfo set bed_code='" + bed_his_Code + "' where said=" + said + " and bed_no='" + bedno + "' and bed_code<>'" + bed_his_Code + "'");
                                }
                            }
                            else
                            {
                                if (bedno == bed_his_CWM)
                                {
                                    Sqls.Add("update t_sickbedinfo set bed_code='" + bed_his_Code + "' where said=" + said + " and bed_no='" + bedno + "' and bed_code<>'" + bed_his_Code + "'");
                                }
                            }
                        }
                    }
                }
                if (App.ExecuteBatch(Sqls.ToArray()) > 0)
                {
                    App.Msg("同步成功!");
                }
                else
                {
                    App.Msg("同步失败!");
                }
            }
            catch (Exception ex)
            {
                App.Msg("提示:同步床位出错,原因:" + ex.Message);
            }
        }


    }
}