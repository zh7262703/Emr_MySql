using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class ucInterim_userInfo :UserControl
    {
        bool isSave = false;　　　　　　　　　//用于存放当前的操作状态 true为添加操作 false为修改操作
        private string mark = "Y";　　　　　　//有效标志
        private string prescription = "true"; //职业资格证
        private string T_IntermUser_Sql;　　  //临时用户表
        private string temp_id = "";          //当前选中的用户工号
        DataSet ds;

        public ucInterim_userInfo()
        {
            InitializeComponent();
            T_IntermUser_Sql=@"select TEMP_ID as 用户工号,a.NAME as 用户姓名,(case when GENDER=0 then '男' else '女' end) as 用户性别,"+
                            @"TECH_POST as 职称编号,b.name as 职称,PHONE as 电话,MOBILE_PHONE as 手机号码,EMAIL as 邮箱地址,"+
                            @"(case when ENABLE_FLAG='Y' then '有效' else '无效' end) as 有效标志,"+
                            @"(case when PROFESSION_CARD='true' then '有' else '无' end) as 职业资格证,"+
                            @"PROF_CARD_NAME as 资格证书名称,to_char(PASS_TIME,'yyyy-mm-dd ') as 通过时间,to_char(RECEIVE_TIME,'yyyy-mm-dd ') as 领证时间,to_char(REGISTER_TIME,'yyyy-mm-dd ') as 注册时间,TUTOR as 指导老师," +
                            @"ISBELONGTO_HOSPITAL as 所属医院,ISBELONGTO_SCHOOL as 所属学校,SPECIALTY as 所学专业,PRAXIS_NO as 实习批次号,"+
                            @"STUDY_NO as 学号 from T_TEMP_USER a inner join T_DATA_CODE b on a.tech_post=b.id  where ENABLE_FLAG='Y'";
        }
        private void frmInterim_userInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("临时用户信息");
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            cboGender.SelectedIndex = 0;
            professional();
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["职称编号"].Visible = false;
                ucGridviewX1.fg.Columns["职称编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
       //显示表格数据
        private void ShowValue()
        {
            string SQl = T_IntermUser_Sql + "  order by 用户工号 desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {

            //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                ucGridviewX1.DataBd(SQl, "用户工号", false, "", "");
                ucGridviewX1.fg.Columns["职称编号"].Visible = false;
                ucGridviewX1.fg.Columns["职称编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        //绑定职称
        private void professional()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE  where Type='1'");
            cboCreer.DataSource = ds.Tables[0].DefaultView;
            cboCreer.ValueMember = "ID";
            cboCreer.DisplayMember = "NAME";
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            cboCreer.Enabled = false;
            txtPhone.Enabled = false;
            txtTelphone.Enabled = false;
            txtEmail.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            txtToguid_teacher.Enabled = false;
            txtHospital.Enabled = false;
            txtSchool.Enabled = false;
            txtSpecialized_field.Enabled = false;
            txtBatchno.Enabled = false;
            txtNumber.Enabled = false;
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
                txtID.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtTelphone.Text = "";
                txtCertificatename.Text = "";
                txtToguid_teacher.Text = "";
                txtHospital.Text = "";
                txtSchool.Text = "";
                txtSpecialized_field.Text = "";
                txtBatchno.Text = "";
                txtNumber.Text = "";
            }
            txtID.Enabled = true;
            txtName.Enabled = true;
            cboGender.Enabled = true;
            cboCreer.Enabled = true;
            txtPhone.Enabled = true;
            txtTelphone.Enabled = true;
            txtEmail.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            rbtnSelected.Enabled = true;
            rbtnNoselected.Enabled = true;
            txtCertificatename.Enabled = true;
            dtpPassingtime.Enabled = true;
            dtpLeadcard.Enabled = true;
            dtpRegdate.Enabled = true;
            txtToguid_teacher.Enabled = true;
            txtHospital.Enabled = true;
            txtSchool.Enabled = true;
            txtSpecialized_field.Enabled = true;
            txtBatchno.Enabled = true;
            txtNumber.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
            }
            else
            {
                txtCertificatename.Enabled = false;
                dtpPassingtime.Enabled = false;
                dtpLeadcard.Enabled = false;
                dtpRegdate.Enabled = false;
            }
            txtID.Focus();
        }
        /// <summary>
        /// 判断是否出现重名TEMP_ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_TEMP_USER where  TEMP_ID='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from T_TEMP_USER where NAME='" + name + "'");
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
        ///保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                //有效标志

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                //职业资格证

                if (!rbtnSelected.Checked)
                {
                    prescription = "false";
                }

                if (txtID.Text.Trim() == "")
                {
                    App.Msg("临时用户编号不能为空");
                    txtID.Focus();
                    return;
                }

                if (txtName.Text.Trim() == "")
                {
                    App.Msg("名字必须填写！");
                    txtName.Focus();
                    return;
                }
                if (cboGender.Text.Trim() == "")
                {
                    App.Msg("性别必须填写");
                    cboGender.Focus();
                    return;
                }
                if (cboCreer.Text.Trim() == "")
                {
                    App.Msg("职称必须填写！");
                    cboCreer.Focus();
                    return;
                }

                //if (txtCertificatename.Text.Trim() == "")
                //{
                //    App.Msg("执业资格证书必须填写！");
                //    txtCertificatename.Focus();
                //    return;
                //}
                //if (txtEmail.Text.Trim() == "")
                //{
                //    App.Msg("Email不能为空！");
                //    return;
                //}
                //Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                //if (!regex.IsMatch(txtEmail.Text.Trim()))
                //{
                //    App.Msg("Email不合法！");
                //    return;
                //}
                if (txtToguid_teacher.Text.Trim() == "")
                {
                    App.Msg("指导老师必须填写！");
                    txtToguid_teacher.Focus();
                    return;
                }
                if (txtHospital.Text.Trim() == "")
                {
                    App.Msg("所属医院必须填写！");
                    txtHospital.Focus();
                    return;
                }
                if (txtSchool.Text.Trim() == "")
                {
                    App.Msg("所属学校必须填写！");
                    txtSchool.Focus();
                    return;
                }
                if (txtSpecialized_field.Text.Trim() == "")
                {
                    App.Msg("所属专业必须填写！");
                    txtSpecialized_field.Focus();
                    return;
                }
                if (txtBatchno.Text.Trim() == "")
                {
                    App.Msg("实习批次号必须填写！");
                    txtBatchno.Focus();
                    return;
                }
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("学号必须填写！");
                    txtNumber.Focus();
                    return;
                }
                //通过时间
                string Passingtime = dtpPassingtime.Value.ToString("yyyy-MM-dd");
                //领证时间
                string Leadcard = dtpLeadcard.Value.ToString("yyyy-MM-dd");
                //注册时间
                string Regdate = dtpRegdate.Value.ToString("yyyy-MM-dd");

                string sql = "";

                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtID.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的用户工号了！");
                        txtID.Focus();
                        return;
                    }
                    //else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("已经存在了相同名称用户的值了！");
                    //    txtName.Focus();
                    //    return;
                    //}

                    sql = "insert into T_TEMP_USER(TEMP_ID,NAME,GENDER,TECH_POST,PHONE,MOBILE_PHONE,EMAIL,ENABLE_FLAG,PROFESSION_CARD,PROF_CARD_NAME,PASS_TIME,RECEIVE_TIME,REGISTER_TIME,TUTOR,ISBELONGTO_HOSPITAL,ISBELONGTO_SCHOOL,SPECIALTY,PRAXIS_NO,STUDY_NO)  values('"
                          + txtID.Text + "','"
                          + txtName.Text + "','"
                          + cboGender.SelectedIndex.ToString() + "','"
                          + cboCreer.SelectedValue + "','"
                          + txtPhone.Text + "','"
                          + txtTelphone.Text + "','"
                          + txtEmail.Text + "','"
                          + mark + "','"
                          + prescription + "','"
                          + txtCertificatename.Text + "',to_timestamp('"
                          + Passingtime + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Leadcard + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Regdate + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + txtToguid_teacher.Text + "','"
                          + txtHospital.Text + "','"
                          + txtSchool.Text + "','"
                          + txtSpecialized_field.Text + "','"
                          + txtBatchno.Text + "','"
                          + txtNumber.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (temp_id.Trim() != "")
                    {
                        if (txtID.Text.Trim() != temp_id.Trim())
                        {
                            if (isExisitName(App.ToDBC(txtID.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的用户工号了！");
                                txtID.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_TEMP_USER  set TEMP_ID='"
                             +txtID.Text+"',NAME='"
                             + App.ToDBC(txtName.Text) + "',GENDER='"
                             + cboGender.SelectedIndex.ToString() + "',TECH_POST='"
                             + cboCreer.SelectedValue + "',PHONE='"
                             + txtPhone.Text + "',MOBILE_PHONE='"
                             + txtTelphone.Text + "',EMAIL='"
                             + txtEmail.Text + "',ENABLE_FLAG='"
                             + mark + "',PROFESSION_CARD='"
                             + prescription + "',PROF_CARD_NAME='"
                             + txtCertificatename.Text + "',PASS_TIME=to_timestamp('"
                             + dtpPassingtime.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),RECEIVE_TIME=to_timestamp('"
                             + dtpLeadcard.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),REGISTER_TIME=to_timestamp('"
                             + dtpRegdate.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),TUTOR='"
                             + txtToguid_teacher.Text + "',ISBELONGTO_HOSPITAL='"
                             + txtHospital.Text + "',ISBELONGTO_SCHOOL='"
                             + txtSchool.Text + "',SPECIALTY='"
                             + txtSpecialized_field.Text + "',PRAXIS_NO='"
                             + txtBatchno.Text + "',STUDY_NO='"
                             + txtNumber.Text + "'  where  TEMP_ID='" + ucGridviewX1.fg["用户工号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    

                }

                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {

                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示表格数据
                ShowValue();
                //string SQl = T_IntermUser_Sql + "  order by TEMP_ID asc";
                //ucC1FlexGrid1.DataBd(SQl, "TEMP_ID", "TEMP_ID,NAME,GENDER,TECH_POST,TECH_POST_NAME,PHONE,MOBILE_PHONE,EMAIL,ENABLE_FLAG,PROFESSION_CARD,PROF_CARD_NAME,PASS_TIME,RECEIVE_TIME,REGISTER_TIME,TUTOR,ISBELONGTO_HOSPITAL,ISBELONGTO_SCHOOL,SPECIALTY,PRAXIS_NO,STUDY_NO", "用户编号,用户姓名,用户性别,职称编号,职称,电话,手机号码,邮箱地址,有效标志,职业资格证,资格证书名称,通过时间,领证时间,注册时间,指导老师,所属医院,所属学校,所学专业,实习批次号,学号");
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");

            }
          
        }
        /// <summary>
        ///添加
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
                if (ucGridviewX1.fg.Rows.Count>0)
                {
                    txtID.Text = ucGridviewX1.fg["用户工号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    temp_id = txtID.Text;
                    txtName.Text = ucGridviewX1.fg["用户姓名",ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["用户性别", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "男")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["职称编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCreer.SelectedValue = ucGridviewX1.fg["职称编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    txtPhone.Text = ucGridviewX1.fg["电话", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtTelphone.Text = ucGridviewX1.fg["手机号码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtEmail.Text = ucGridviewX1.fg["邮箱地址", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["有效标志", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有效")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["职业资格证", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有")
                    {
                        rbtnSelected.Checked = true;
                    }
                    else
                    {
                        rbtnNoselected.Checked = true;
                    }
                    txtCertificatename.Text = ucGridviewX1.fg["资格证书名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    if (ucGridviewX1.fg["通过时间", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpPassingtime.Value = Convert.ToDateTime(ucGridviewX1.fg["通过时间", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["领证时间", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpLeadcard.Value = Convert.ToDateTime(ucGridviewX1.fg["领证时间", ucGridviewX1.fg.CurrentRow.Index].Value);
                    }
                    if (ucGridviewX1.fg["注册时间", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpRegdate.Value = Convert.ToDateTime(ucGridviewX1.fg["注册时间", ucGridviewX1.fg.CurrentRow.Index].Value);
                    }
                    txtToguid_teacher.Text = ucGridviewX1.fg["指导老师", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtHospital.Text = ucGridviewX1.fg["所属医院", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSchool.Text = ucGridviewX1.fg["所属学校", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSpecialized_field.Text = ucGridviewX1.fg["所学专业", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtBatchno.Text = ucGridviewX1.fg["实习批次号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["学号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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
        //int index = 0;
        private void 账号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (index > 0)
            //{
            //    class_T_ user = new Class_User();
            //    user.User_id = ID;
            //    user.User_name = txtName.Text;
            //    App.frmAccountSetByUser(user);
            //}
            //else
            //{
            //    App.Msg("您还没有选中要操作的用户");
            //}
        }
           /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtTelphone.Text = "";
            txtCertificatename.Text = "";
            txtToguid_teacher.Text = "";
            txtHospital.Text = "";
            txtSchool.Text = "";
            txtSpecialized_field.Text = "";
            txtBatchno.Text = "";
            txtNumber.Text = "";
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            cboCreer.Enabled = false;
            txtPhone.Enabled = false;
            txtTelphone.Enabled = false;
            txtEmail.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            txtToguid_teacher.Enabled = false;
            txtHospital.Enabled = false;
            txtSchool.Enabled = false;
            txtSpecialized_field.Enabled = false;
            txtBatchno.Enabled = false;
            txtNumber.Enabled = false;
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
                App.ExecuteSQL("update  T_TEMP_USER  set  ENABLE_FLAG='N' where  TEMP_ID=" + ucGridviewX1.fg["用户工号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //显示表格数据
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
                string Sql = T_IntermUser_Sql+" order by TEMP_ID desc";

                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //根据临时用户姓名进行查询
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_IntermUser_Sql + "  and    a.NAME　like'%" + txtBox.Text.Trim() + "%' order by TEMP_ID desc";

                    }

                }
                //根据临时用户编号进行查询
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_IntermUser_Sql + " and  TEMP_ID like'%" + txtBox.Text.Trim() + "%' order by TEMP_ID desc";

                    }
                }

                ucGridviewX1.DataBd(Sql, "用户工号", false, "", "");

                ucGridviewX1.fg.Columns["职称编号"].Visible = false;
                ucGridviewX1.fg.Columns["职称编号"].ReadOnly = true;
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
        ///  职业资格证为“有”时,资格证书名称、通过时间、领证时间、 注册时间为true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
            }
        }
        /// <summary>
        /// 职业资格证为“无”时,资格证书名称、通过时间、领证时间、 注册时间为false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNoselected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNoselected.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    txtCertificatename.Enabled = false;
                    dtpPassingtime.Enabled = false;
                    dtpLeadcard.Enabled = false;
                    dtpRegdate.Enabled = false;
                }
            }

        }


        private void txtID_KeyDown(object sender, KeyEventArgs e)
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
                cboGender.Focus();
            }

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCreer.Focus();
            }

        }

        private void cboCreer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }

        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelphone.Focus();
            }

        }

        private void txtTelphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }

        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
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
                rbtnSelected.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnSelected.Focus();
            }

        }

        private void rbtnSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCertificatename.Focus();
            }

        }

        private void rbtnNoselected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtToguid_teacher.Focus();
            }

        }

        private void txtCertificatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpPassingtime.Focus();
            }

        }

        private void dtpPassingtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpLeadcard.Focus();
            }

        }

        private void dtpLeadcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpRegdate.Focus();
            }

        }

        private void dtpRegdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtToguid_teacher.Focus();
            }

        }

        private void txtToguid_teacher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHospital.Focus();
            }

        }

        private void txtHospital_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtSchool.Focus();
            }

        }

        private void txtSchool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSpecialized_field.Focus();
            }

        }

        private void txtSpecialized_field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBatchno.Focus();
            }

        }

        private void txtBatchno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumber.Focus();
            }

        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        
        }

        //private void buttonX1_Click(object sender, EventArgs e)
        //{
        //    test tt = new test();
        //    tt.ucHisUserSearchPatientInfo();
        //}




 
    

  




    }
}