using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using System.Collections;

namespace Base_Function.BASE_DATA
{
    public partial class ucIn_Patient : UserControl
    {
        bool IsSave = false;         //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID = "";        //病人ID
        private string Inpaint_Sql;  //病人信息查询
        private string pids = "";    //当前选中的病人住院号
        public ucIn_Patient()
        {
            InitializeComponent();
            Inpaint_Sql = @"select ID as 编号,PATIENT_NAME as 病人姓名,NAME_PINYIN  as 拼音," +
                      @"(case when GENDER_CODE=0 then '男' else '女' end) as 性别,AGE as 年龄,AGE_UNIT as 年龄单位," +
                      @"to_char(BIRTHDAY,'yyyy-MM-dd') as 出生日期,PID as 病人住院号,SECTION_ID as 当前科室编号,SECTION_NAME as 当前科室,sick_area_id as 当前病区编号," +
                      @"sick_area_name as 当前病区,to_char(IN_TIME,'yyyy-MM-dd hh24:mi') as 住院时间,CARD_ID as 病人唯一卡号 from T_IN_PATIENT ";
        }
        //public static WebReferenceHIS.Service sv = new Bifrost_Nurse.WebReferenceHIS.Service();

        private void frmIn_Patient_Load(object sender, EventArgs e)
        {
            try
            {
                //App.SetMainFrmMsgToolBarText("病人信息");
                //显示列表数据
                ShowValue();

                ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                ucGridviewX1.fg.AllowUserToAddRows = false;
                ucGridviewX1.fg.ContextMenuStrip = contextMenuStrip1;
                cboGender.SelectedIndex = 0;
                //绑定当前病区
                CuSick();
                //绑定年龄单位
                AgeUint();
                //绑定科室
                Cusection();
                RefleshFrm();
            }
            catch
            {
            }


        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前科室编号"].Visible = false;
                ucGridviewX1.fg.Columns["当前科室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["当前病区编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        DataSet ds;
        //显示列表数据
        private void ShowValue()
        {
            try
            {
                string SQl = Inpaint_Sql + " order by IN_TIME desc";
                ds = App.GetDataSet(SQl);
                if (ds != null)
                {
                    ucGridviewX1.DataBd(SQl, "住院时间", false, "", "");
                    ucGridviewX1.fg.Columns["编号"].Visible = false;
                    ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                    ucGridviewX1.fg.Columns["当前科室编号"].Visible = false;
                    ucGridviewX1.fg.Columns["当前科室编号"].ReadOnly = true;
                    ucGridviewX1.fg.Columns["当前病区编号"].Visible = false;
                    ucGridviewX1.fg.Columns["当前病区编号"].ReadOnly = true;
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
            catch
            { }
        }
        ///// <summary>
        ///// 如果时间为当前时间时，就默认为一天
        ///// </summary>
        // private void datetime()
        // {
        //     int ages = 1;
        //     string agesunit = "天";
        //     if (dtpDatetime.Value.Year == dtpBirthday.Value.Year)
        //     {

        //         if (dtpDatetime.Value.Month == dtpDatetime.Value.Month)
        //         {
        //             if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
        //             {
        //                 txtAge.Text = ages.ToString();
        //                 cboAgeunit.Text =agesunit;

        //             }
        //         }
        //     }
        // }
        /// <summary>
        /// 根据时间的变化从而得到病人的年龄
        /// </summary>
        private void stamp()
        {
            //int incount;
            //string ageunit = "岁";
            //if(dtpDatetime.Value.Year==dtpBirthday.Value.Year)
            //{
            //    if(dtpDatetime.Value.Month==dtpDatetime.Value.Month)
            //    {
            //        天
            //        if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
            //        {
            //            incount = 1;
            //            ageunit = "天";
            //        }
            //        else
            //        {
            //            incount = dtpDatetime.Value.Day - dtpBirthday.Value.Day;
            //            ageunit = "天";
            //        }
            //    }
            //    else
            //    {
            //        月
            //        incount=dtpDatetime.Value.Month-dtpBirthday.Value.Month;
            //        ageunit = "月";
            //    }
            //}
            //else
            //{
            //    if (dtpDatetime.Value.Month == dtpDatetime.Value.Month)
            //    {
            //        if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
            //        {
            //            incount = dtpDatetime.Value.Year - dtpBirthday.Value.Year;
            //        }
            //    }

            //    incount=dtpDatetime.Value.Year-dtpBirthday.Value.Year;
            //    岁
            //}

            //string  date = Convert.ToDateTime(dtpBirthday.Value.ToShortDateString());
            // string  date1 = Convert.ToDateTime(dtpDateTime.Value.ToString("yyyy-MM-dd"));
            TimeSpan sp = new TimeSpan();
            sp = dtpDatetime.Value - dtpBirthday.Value;
            int indaycount;
            int incount;
            string ageunit = "岁";
            indaycount = sp.Days;
            if (indaycount >= 365)
            {
                if (indaycount == 365)
                {
                    incount = 1;
                }
                else
                {
                    incount = indaycount / 365;
                }
            }
            else
            {
                if (indaycount >= 30)
                {
                    if (indaycount == 30)
                    {
                        incount = 1;
                        ageunit = "月";
                    }
                    else
                    {
                        incount = indaycount / 30;
                        ageunit = "月";
                    }
                }
                else
                {

                    incount = indaycount;
                    ageunit = "天";
                }
            }

            txtAge.Text = incount.ToString();
            cboAgeunit.Text = ageunit;
        }
        //绑定当前病区
        private void Cusick()
        {
            try
            {
                DataSet ds = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join  T_SICKAREAINFO b on b.said=g.said  where g.sid='" + cboCusection.SelectedValue + "' and  b.ENABLE_FLAG='Y' and  b.ISBELONGTOSECTION='N'");
                cboCusick.DataSource = ds.Tables[0].DefaultView;
                cboCusick.ValueMember = "SAID";
                cboCusick.DisplayMember = "SICK_AREA_NAME";
            }
            catch
            {
            }
        }
        //绑定年龄单位
        private void AgeUint()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='37'order by ID asc");

            cboAgeunit.DataSource = ds.Tables[0].DefaultView;
            cboAgeunit.ValueMember = "ID";
            cboAgeunit.DisplayMember = "NAME";
        }
        //绑定当前科室
        private void Cusection()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO where ENABLE_FLAG='Y' and ISBELONGTOBIGSECTION='N'");
            cboCusection.DataSource = dt.Tables[0].DefaultView;
            cboCusection.ValueMember = "SID";
            cboCusection.DisplayMember = "SECTION_NAME";
        }
        private void CuSick()
        {
            DataSet dt = App.GetDataSet("select * from T_SICKAREAINFO  where ISBELONGTOSECTION='N'and ENABLE_FLAG='Y'");
            cboCusick.DataSource = dt.Tables[0].DefaultView;
            cboCusick.ValueMember = "SAID";
            cboCusick.DisplayMember = "SICK_AREA_NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtPiyin.Enabled = false;
            dtpBirthday.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            cboCusection.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusick.Enabled = false;
            dtpDatetime.Enabled = false;
            txtCardId.Enabled = false;
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
                txtAge.Text = "";

            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            txtPiyin.Enabled = true;
            dtpBirthday.Enabled = true;
            cboGender.Enabled = true;
            txtAge.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusection.Enabled = true;
            cboCusick.Enabled = true;
            dtpDatetime.Enabled = true;
            txtCardId.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (dtpBirthday.Enabled == true)
            {
                stamp();
            }
            txtNumber.Focus();

        }
        /// <summary>
        /// 判断是否出现重名ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_IN_PATIENT  where PID='" + id + "'");
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
        private bool IsExisitName(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_IN_PATIENT where  PATIENT_NAME='" + name + "'");
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

                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("病人住院号不能为空！");
                    txtNumber.Focus();
                    return;

                }
                else if (txtName.Text.Trim() == "")
                {
                    App.Msg("病人姓名不能为空！");
                    txtName.Focus();
                    return;

                }
                //else if (cboCusection.Text.Trim() == "")
                //{
                //    App.Msg("当前科室不能为空！");
                //    cboCusection.Focus();
                //    return;

                //}
                //else if (cboCusick.Text.Trim() == "")
                //{
                //    App.Msg("当前病区不能为空！");
                //    cboCusick.Focus();
                //    return;

                //}
                else if (txtAge.Text.Trim() == "")
                {
                    App.Msg("年龄不能为空！");
                    txtAge.Focus();
                    return;
                }
                else if (cboAgeunit.Text.Trim() == "")
                {
                    App.Msg("年龄单位不能为空！");
                    cboAgeunit.Focus();
                    return;
                }

                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd ");
                string datetime = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
                string sql = "";


                ID = App.GenId("T_IN_PATIENT ", "ID").ToString();

                if (IsSave)
                {
                    //if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    //{
                    //    App.Msg("已经存在了相同名称的病人住院号了！");
                    //    txtNumber.Focus();
                    //    return;
                    //}
                    //if (IsExisitName(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("病人信息中已经有相同的姓名了！");
                    //    txtName.Focus();
                    //    return;
                    //}
                    sql = "insert into T_IN_PATIENT(ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE,BIRTHDAY,PID,AGE,AGE_UNIT,SECTION_ID,SECTION_NAME,INSECTION_ID,INSECTION_NAME,IN_AREA_ID,IN_AREA_NAME,SICK_AREA_ID,SICK_AREA_NAME,IN_TIME,CARD_ID) values('"
                         + ID + "','"
                         + txtName.Text + "','"
                         + txtPiyin.Text + "','"
                         + cboGender.SelectedIndex.ToString() + "',to_timestamp('"
                         + birthday + "','syyyy-mm-dd '),'"
                         + txtNumber.Text + "','"
                         + txtAge.Text + "','"
                         + cboAgeunit.Text + "','"
                         + cboCusection.SelectedValue + "','"
                         + cboCusection.Text + "','"
                         + cboCusection.SelectedValue + "','"
                         + cboCusection.Text + "','"
                         + cboCusick.SelectedValue + "','"
                         + cboCusick.Text + "','"
                         + cboCusick.SelectedValue + "','"
                         + cboCusick.Text + "',to_timestamp('"
                         + datetime + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                         + txtCardId.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (pids.Trim() != null)
                    {
                        if (txtNumber.Text.Trim() != pids.Trim())
                        {
                            if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("已经存在了相同名称的病人住院号了！");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    //
                    string in_patient = "";
                    sql = "update T_IN_PATIENT set PATIENT_NAME='"
                              + txtName.Text + "',NAME_PINYIN='"
                              + txtPiyin.Text + "',GENDER_CODE='"
                              + cboGender.SelectedIndex.ToString() + "',BIRTHDAY=to_timestamp('"
                              + birthday + "','syyyy-mm-dd hh24:mi:ss.ff9'),PID='"
                              + txtNumber.Text + "',AGE='"
                              + txtAge.Text + "',AGE_UNIT='"
                              + cboAgeunit.Text + "',SECTION_ID='"
                              + cboCusection.SelectedValue + "',SECTION_NAME='"
                              + cboCusection.Text + "',SICK_AREA_ID='"
                              //+ cboCusection.Text + "',INSECTION_ID='"
                              //+ cboCusection.SelectedValue + "',INSECTION_NAME='"
                              //+ cboCusection.Text + "',IN_AREA_ID='"
                              //+ cboCusick.SelectedValue + "',IN_AREA_NAME='"
                              //+ cboCusick.Text + "',SICK_AREA_ID='"
                              + cboCusick.SelectedValue + "',SICK_AREA_NAME='"
                              + cboCusick.Text + "',IN_TIME=to_timestamp('"
                              + datetime + "','syyyy-mm-dd hh24:mi:ss.ff9'),CARD_ID='"
                              + txtCardId.Text + "'  where ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);

                    }
                }
                ShowValue();
                //string SQl = Inpaint_Sql;
                //ucC1FlexGrid1.DataBd(SQl, "ID", "ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE,AGE,AGE_UNIT,BIRTHDAY,PID,SECTION_ID,SECTION_NAME,IN_AREA_ID,IN_AREA_NAME,IN_TIME", "编号,病人姓名,拼音,性别,年龄,年龄单位,出生日期,病人住院号,当前科室编号,当前科室,当前病区编号,当前病区,入院日期");
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
        /// <summary>
        /// 单击表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {

                if (ucGridviewX1.fg.Rows.Count >0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["病人住院号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    pids = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["病人姓名", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtAge.Text = ucGridviewX1.fg["年龄", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["年龄单位", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        cboAgeunit.Text = ucGridviewX1.fg["年龄单位", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    } txtPiyin.Text = ucGridviewX1.fg["拼音", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["出生日期", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpBirthday.Value = Convert.ToDateTime(ucGridviewX1.fg["出生日期", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["住院时间", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpDatetime.Value = Convert.ToDateTime(ucGridviewX1.fg["住院时间", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["当前科室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCusection.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["当前科室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["当前病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCusick.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["当前病区编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["性别", ucGridviewX1.fg.CurrentRow.Index].ToString() == "男")
                    {
                        cboGender.SelectedIndex = 0;

                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;

                    }

                    txtCardId.Text = ucGridviewX1.fg["病人唯一卡号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPiyin.Text = App.getSpell(App.ToDBC(txtName.Text.Trim()));
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
                string SQl = Inpaint_Sql + "order by IN_TIME desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //根据病人PID进行查询
                if (chId.Checked == true)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  PID　like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //根据病人姓名进行查询
                if (chkName.Checked == true)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  PATIENT_NAME　like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                if (chkCardID.Checked == true)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  CARD_ID　like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }
                }

                ucGridviewX1.DataBd(SQl, "住院时间", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前科室编号"].Visible = false;
                ucGridviewX1.fg.Columns["当前科室编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前病区编号"].Visible = false;
                ucGridviewX1.fg.Columns["当前病区编号"].ReadOnly = true;
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }
        /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtPiyin.Enabled = false;
            dtpBirthday.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            cboCusection.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusick.Enabled = false;
            dtpDatetime.Enabled = false;
            txtCardId.Enabled = false;
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
                App.ExecuteSQL("delete from T_IN_PATIENT where  ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            ShowValue();
            refurbish();

        }
        private void chId_CheckedChanged(object sender, EventArgs e)
        {
            if (chId.Checked == true)
            {
                chId.Checked = true;
                chkName.Checked = false;
                chkCardID.Checked = false;
            }
            else
            {
                chId.Checked = false;
                txtBox.Text = "";
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked == true)
            {
                chkName.Checked = true;
                chId.Checked = false;
                chkCardID.Checked = false;
            }
            else
            {
                chkName.Checked = false;
                txtBox.Text = "";
            }
        }
        private void chkCardID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCardID.Checked == true)
            {
                chkCardID.Checked = true;
                chId.Checked = false;
                chkName.Checked = false;
            }
            else
            {
                chkCardID.Checked = false;
                txtBox.Text = "";
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
                dtpBirthday.Focus();
            }

        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGender.Focus();
            }

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCusection.Focus();
            }

        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    cboCusection.Focus();
            //}

        }

        private void cboCusection_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cboCusick.Focus();
            }

        }


        private void cboCusick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDatetime.Focus();
            }

        }

        private void dtpDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void cboCusection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cusick();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            stamp();
        }

       

        

        private void 新入院病人换床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBedInfo fm = new frmBedInfo();
                App.FormStytleSet(fm, false);
                fm.ShowDialog();
                string bed_id = fm.bedInfo_id;
                string bed_name = fm.bedInfo_name;
                fm.Close();
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (bed_id != "" && bed_name != "")
                    {
                        string sql_update = "update T_IN_PATIENT set sick_bed_id=" + bed_id + ",sick_bed_no='" + bed_name + "' where id=" + ID + "";
                        if (App.ExecuteSQL(sql_update) > 0)
                        {
                            App.Msg("换床成功！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("换床失败,原因:" + ex.Message);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ///*
            // *获取新入院病人住院号的集合 
            // */
            //ArrayList sqls = new ArrayList();

            ///*
            // * 获取是否已经存在了
            // */
            ////获取当前数据库的病人  histime
            //string oursql = "select id,his_id from t_in_patient";
            ////if (histime != "")
            ////{
            ////    DateTime starttime = Convert.ToDateTime(histime);
            ////    oursql = "select id,his_id from t_in_patient where in_time>=to_timestamp('"
            ////                 + starttime.AddDays(-15).ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9')";
            ////}
            //DataSet DataOurPatient = App.GetDataSet(oursql);

            ////cypb=0 在院    

            //DataSet Ds_Patient = sv.His_GetDataSet("select * from V_DZBL_ZY_BRRY where cypb=0 and zyys is not null and zyys<>''");


            //int action_id = App.GenId("t_inhospital_action", "id");
            //string zyys = "0";
            //int id = App.GenId("t_in_patient", "id");
            //if (id < 10000)
            //{
            //    id = 10000;
            //}

            ///*
            // * 导入到我方数据库
            // */
            //for (int i = 0; i < Ds_Patient.Tables[0].Rows.Count; i++)
            //{

            //    if (DataOurPatient.Tables[0].Select("his_id='" + Ds_Patient.Tables[0].Rows[i]["ZYH"].ToString() + "'").Length == 0)
            //    {
            //        if (Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString().Trim() == "")
            //        {
            //            zyys = "-1";
            //            //hisGanBao.Add("-1," + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());
            //        }
            //        else
            //        {
            //            zyys = Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString();
            //            //hisGanBao.Add(Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString() + "," + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());
            //        }

            //        //病人性别过滤
            //        string sex = "0";
            //        if (Ds_Patient.Tables[0].Rows[i]["BRXB"].ToString() == "1")
            //        {
            //            sex = "0";
            //        }
            //        else
            //        {
            //            sex = "1";
            //        }

            //        int year = 0;
            //        int month = 0;
            //        int days = 0;
            //        string AGE = "";
            //        string AGE_UNIT = "";
            //        GetAgeByBirthday(Convert.ToDateTime(Ds_Patient.Tables[0].Rows[i]["CSNY"]), App.GetSystemTime(), out year, out month, out days);
            //        if (year != 0)
            //        {
            //            AGE = year.ToString();
            //            AGE_UNIT = "岁";
            //        }
            //        else
            //        {
            //            if (month != 0)
            //            {
            //                AGE = month.ToString();
            //                AGE_UNIT = "月";

            //            }
            //            else
            //            {
            //                if (days != 0)
            //                {
            //                    AGE = days.ToString();
            //                    AGE_UNIT = "天";
            //                }
            //            }
            //        }

            //        string PROPERTY = "";
            //        if (Ds_Patient.Tables[0].Rows[i]["xzbz_zjg"] != null)
            //        {
            //            PROPERTY = Ds_Patient.Tables[0].Rows[i]["xzbz_zjg"].ToString();
            //        }

            //        //如果没有床的话自动生成床位
            //        GenBed(Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString(), Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString(), Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());

            //        string InsertPatient = "insert into T_IN_PATIENT(ID,HIS_ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE," +
            //                            "BIRTHDAY,Marriage_State,PID," +
            //                            "Country,Native_Place,Birth_Place,Folk_Code," +
            //                            "Career,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone," +
            //                            "Office,Office_Phone,Relation_Name,Relation,Relation_Address," +
            //                            "Relation_Phone,IN_AREA_ID,SICK_AREA_ID," +
            //                            "Section_ID,Insection_ID," +
            //                            "IN_TIME,CARD_ID,IN_DOCTOR_ID,SICK_DOCTOR_ID,IN_DOCTOR_NAME,SICK_DOCTOR_NAME,SECTION_NAME," +
            //                            "INSECTION_NAME,IN_AREA_NAME,SICK_AREA_NAME,SICK_BED_NO,SICK_BED_ID,IN_BED_NO,IN_BED_ID,PAY_MANNER,AGE,AGE_UNIT,PROPERTY_FLAG,SICK_DOC_NO) values("
            //         + id + ",'"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["BRXM"].ToString() + "','"
            //         + App.getSpell(Ds_Patient.Tables[0].Rows[i]["BRXM"].ToString()) + "','"
            //         + sex + "',to_timestamp('"
            //         + Ds_Patient.Tables[0].Rows[i]["CSNY"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
            //         + Ds_Patient.Tables[0].Rows[i]["HYZK"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYHM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["GJDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["SFDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKDZ"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["MZDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["SFZH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKDZ"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKYB"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["DH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["GZDW"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["DWDH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXRM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXGX"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXDZ2"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXDH"].ToString() +
            //         "',(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select sid from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select sid from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)"
            //         + ",to_timestamp('"
            //         + Ds_Patient.Tables[0].Rows[i]["RYRQ"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
            //         + Ds_Patient.Tables[0].Rows[i]["GFZH"].ToString() + "'" +
            //         ",(select USER_ID from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_ID from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_NAME from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_NAME from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +

            //         ",(select SECTION_NAME from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select SECTION_NAME from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select SICK_AREA_NAME from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select SICK_AREA_NAME from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1),'"

            //          + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() +
            //          "',(select BED_ID from T_SICKBEDINFO where BED_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'"

            //          + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() +
            //           "',(select BED_ID from T_SICKBEDINFO where BED_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'"
            //          + Ds_Patient.Tables[0].Rows[i]["BRXZ"].ToString() + "'" + AGE + ",'" + AGE_UNIT + "','" + PROPERTY + "','" + Ds_Patient.Tables[0].Rows[i]["BAHM"].ToString() + "')";


            //        //指定床号后，该床的状态改为占有74
            //        string UpdateBed_State = "update t_sickbedinfo set state=74,pid=" + id + " where bed_no='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "'";

            //        //向异动表插入一条入区记录
            //        string InsertInArea = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
            //                               " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
            //                               " values(" + action_id.ToString() + ",(select sid from T_SECTIONINFO where section_code='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1),(select said from T_SICKAREAINFO where sick_area_code='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1),'" + id + "'," +
            //                               "'入区','4',sysdate,(select bed_id from T_SICKBEDINFO where bed_no='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'" + zyys + "',0,0,0," + id + ")";
            //        //向质控临时表新增一条入区记录
            //        string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
            //                                " values('" + Ds_Patient.Tables[0].Rows[i]["ZYHM"].ToString() + "','入区',to_timestamp('" + Ds_Patient.Tables[0].Rows[i]["RYRQ"].ToString()
            //                                + "','yyyy-MM-dd hh24:mi:ss')," + id + ")";

            //        sqls.Add(InsertPatient);
            //        sqls.Add(UpdateBed_State);
            //        sqls.Add(InsertInArea);
            //        sqls.Add(InsertJob_Temp);
            //        id++;
            //        action_id++;
            //    }
            //}
            //string[] sqlsstrs = new string[sqls.Count];
            //for (int i = 0; i < sqls.Count; i++)
            //{
            //    sqlsstrs[i] = sqls[i].ToString();
            //}
            //int count = App.ExecuteBatch(sqlsstrs);
            //if (count > 0)
            //{
            //    App.Msg("导入成功！病人数：" + sqlsstrs.Length / 4);
            //}
            //else
            //{
            //    App.Msg("导入失败！");
            //}
        }

        #region HIS病人自动入区相关操作
        /// 通过生日和当前日期计算岁，月，天
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="now">当前日期</param>
        /// <param name="year">岁</param>
        /// <param name="month">月</param>
        /// <param name="day">天</param>
        public static void GetAgeByBirthday(DateTime birthday, DateTime now, out int year, out int month, out int day)
        {
            //int day, month, year;
            //生日的年，月，日
            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;
            //当前时间的年,月,日
            int nowYear = now.Year;
            int nowMonth = now.Month;
            int nowDay = now.Day;

            //得到天

            if (nowDay >= birthdayDay)
            {
                day = nowDay - birthdayDay;
            }
            else
            {
                nowMonth -= 1;
                day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;
            }


            //得到月
            if (nowMonth >= birthdayMonth)
            {
                month = nowMonth - birthdayMonth;
            }

            else
            {
                nowYear -= 1;
                month = 12 + nowMonth - birthdayMonth;
            }
            //得到年
            year = nowYear - birthdayYear;
        }

        /// <summary>
        /// 获取天数
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private static int GetDay(int month, int year)
        {

            int day = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = 31;
                    break;
                case 2:

                    //闰年天，平年天

                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {

                        day = 29;

                    }

                    else
                    {

                        day = 28;

                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    day = 30;
                    break;
            }
            return day;

        }
        /// <summary>
        /// 当没有HIS中的床号的自动新建床号
        /// </summary>
        /// <param name="BedCode"></param>
        /// <param name="sickareacode"></param>
        /// <param name="sectioncode"></param>
        private static void GenBed(string BedCode, string sickareacode, string sectioncode)
        {
            try
            {
                DataSet ds_bed = App.GetDataSet("select a.bed_id from t_sickbedinfo a where a.bed_code='" + BedCode + "'");
                if (ds_bed != null)
                {
                    if (ds_bed.Tables[0].Rows.Count == 0)
                    {
                        string BedId = App.GenId("t_sickbedinfo", "bed_id").ToString();
                        string Sql = "insert into T_SICKBEDINFO(BED_ID,SRID,SID,SAID,BED_CODE,BED_NO,TYPEINFO,BEDLEVEL,ORG_PROP,STATE,SEX_CTRL,SEX_FLAG,ENABLEFLAG) values(" + BedId + ",'',(select sid from T_SECTIONINFO where SECTION_CODE='" +
                            sectioncode + "' and rownum=1),(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + sickareacode + "' and rownum=1),'" +
                            BedCode + "','" + BedCode + "',76,73,'',75,'1','2','Y')";
                        App.ExecuteSQL(Sql);
                    }
                }
            }
            catch
            { }
        }
        #endregion

    }
}