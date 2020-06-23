using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class ucUserInfo : UserControl
    {
       
        bool isSave = false;                 //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID = "";              //用户ID
        private string mark = "Y";           //有效标志
        private string prescription = "true";//职业资格证
        private string T_user_sql;           //用户查询
        private string user_number = "";     //当前选中的工号
        private string accounttype = "0";    //帐号性质
        private DevComponents.DotNetBar.TabControl MainTabControl;    //用于存放父容器的TabControl信息
        private string sectionIds = "";       //当前登录的科主任的使用范围ID字符串


        DataSet ds;

        public ucUserInfo()
        {
            InitializeComponent();
            try
            {
                //T_user_sql = @"select user_id　as 用户编号,user_num as 用户工号,user_name as 用户姓名,(case when gender_code=0 then '男' else '女' end) as 用户性别,to_char(birthday,'yyyy-mm-dd ') as 出生年月," +
                //            @"u_tech_post as 职称编号,c.name as 职称,u_seniority as 年资编号,f.name as 年资,to_char(in_time,'yyyy-mm-dd ')  as 入职年月,u_position as 职务编号,b.name as 职务,u_recipe_power as 处方权编号," +
                //            @"g.name as 处方权,section_id as 科室编号,d.section_name as 所属科室,sickarea_id as 病区编号,s.sick_area_name as 所属病区,phone as 电话,email as 邮箱地址," +
                //            @"mobile_phone as 手机号码,(case when a.enable='Y' then '有效' else '无效' end) as 有效标志,(case when profession_card='true' then '有' else '无' end) as 职业资格证," +
                //            @"prof_card_name as 资格证书名称,to_char(pass_time,'yyyy-mm-dd ') as 通过时间,to_char(receive_time,'yyyy-mm-dd ') as 领证时间," +
                //            @"to_char(register_time,'yyyy-mm-dd ') as 注册时间,a.ACCOUNT_TYPE as 用户类型 from t_userinfo a inner join T_DATA_CODE b on a.u_position=b.id  left join T_DATA_CODE c on a.u_tech_post=c.id left join T_SECTIONINFO d on a.section_id=d.sid  left join T_DATA_CODE f on a.u_seniority=f.id left join T_DATA_CODE g on a.u_recipe_power=g.id left join T_SICKAREAINFO s on a.sickarea_id=s.said  where enable='Y'";

                //if (App.UserAccount.UserInfo.Section_id == "24" || App.UserAccount.UserInfo.Section_id == "25" || App.UserAccount.UserInfo.Section_id == "26" || App.UserAccount.UserInfo.Section_id == "51")
                //{
                //    T_user_sql = @"select user_id　as 用户编号,user_num as 用户工号,user_name as 用户姓名,(case when gender_code=0 then '男' else '女' end) as 用户性别,to_char(birthday,'yyyy-mm-dd ') as 出生年月," +
                //                @"u_tech_post as 职称编号,c.name as 职称,u_seniority as 年资编号,f.name as 年资,to_char(in_time,'yyyy-mm-dd ')  as 入职年月,u_position as 职务编号,b.name as 职务,u_recipe_power as 处方权编号," +
                //                @"g.name as 处方权,section_id as 科室编号,d.section_name as 所属科室,sickarea_id as 病区编号,s.sick_area_name as 所属病区,phone as 电话,email as 邮箱地址," +
                //                @"mobile_phone as 手机号码,(case when a.enable='Y' then '有效' else '无效' end) as 有效标志,(case when profession_card='true' then '有' else '无' end) as 职业资格证," +
                //                @"prof_card_name as 资格证书名称,to_char(pass_time,'yyyy-mm-dd ') as 通过时间,to_char(receive_time,'yyyy-mm-dd ') as 领证时间," +
                //                @"to_char(register_time,'yyyy-mm-dd ') as 注册时间,a.ACCOUNT_TYPE as 用户类型 from t_userinfo a inner join T_DATA_CODE b on a.u_position=b.id  left join T_DATA_CODE c on a.u_tech_post=c.id left join T_SECTIONINFO d on a.section_id=d.sid  left join T_DATA_CODE f on a.u_seniority=f.id left join T_DATA_CODE g on a.u_recipe_power=g.id left join T_SICKAREAINFO s on a.sickarea_id=s.said  where a.enable='Y' and d.SID in (24,25,26,51)";//24,25,26,47,48,49,50,51,56,57,58,64,65
                //}
                //else
                //{
                    T_user_sql = @"select user_id　as 用户编号,user_num as 用户工号,user_name as 用户姓名,(case when gender_code=0 then '男' else '女' end) as 用户性别,to_char(birthday,'yyyy-mm-dd ') as 出生年月," +
                                                  @"u_tech_post as 职称编号,c.name as 职称,u_seniority as 年资编号,f.name as 年资,to_char(in_time,'yyyy-mm-dd ')  as 入职年月,u_position as 职务编号,b.name as 职务,u_recipe_power as 处方权编号," +
                                                  @"g.name as 处方权,section_id as 科室编号,d.section_name as 所属科室,sickarea_id as 病区编号,s.sick_area_name as 所属病区,phone as 电话,email as 邮箱地址," +
                                                  @"mobile_phone as 手机号码,(case when a.enable='Y' then '有效' else '无效' end) as 有效标志,(case when profession_card='true' then '有' else '无' end) as 职业资格证," +
                                                  @"prof_card_name as 资格证书名称,to_char(pass_time,'yyyy-mm-dd ') as 通过时间,to_char(receive_time,'yyyy-mm-dd ') as 领证时间," +
                                                  @"to_char(register_time,'yyyy-mm-dd ') as 注册时间,a.ACCOUNT_TYPE as 用户类型 from t_userinfo a inner join T_DATA_CODE b on a.u_position=b.id  left join T_DATA_CODE c on a.u_tech_post=c.id left join T_SECTIONINFO d on a.section_id=d.sid  left join T_DATA_CODE f on a.u_seniority=f.id left join T_DATA_CODE g on a.u_recipe_power=g.id left join T_SICKAREAINFO s on a.sickarea_id=s.said  where a.enable='Y' ";//24,25,26,47,48,49,50,51,56,57,58,64,65
                //}
            }
            catch
            {
            }
        }

        /// <summary>
        ///设置对应的 MainTabControl
        /// </summary>
        /// <param name="devtabcontrol"></param>
        public void setParentTabControl(DevComponents.DotNetBar.TabControl devtabcontrol)
        {
            MainTabControl = devtabcontrol;
        }

        private void ucUserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetSectionIds();
                App.SetMainFrmMsgToolBarText("用户信息");
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                cboGender.SelectedIndex = 0;
                cboCondition.SelectedIndex = 0;
                Bangding();
                professional();
                position();
                Price();
                Prescription();
                Sick();
                RefleshFrm();
                btnLookup_Click(sender, e);
            }
            catch
            {
            }
        }


        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["用户编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["用户编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }


        /// <summary>
        /// 显示列表数据
        /// </summary>
        private void ShowValue()
        {
            string SQl = T_user_sql + " and d.SID  in  '" + sectionIds + "' order by User_Id asc ";
            //ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucC1FlexGrid1.DataBd(SQl, "用户编号", false, "", "");
                ucC1FlexGrid1.fg.Cols["用户编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["用户编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }


        }
        /// <summary>
        /// 绑定职称
        /// </summary>
        private void professional()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE  where Type='1' and enable='Y'");
            cboCreer.DataSource = ds.Tables[0].DefaultView;
            cboCreer.ValueMember = "ID";
            cboCreer.DisplayMember = "NAME";         
            cboCreer.SelectedText = "住院医师";

        }
        /// <summary>
        /// 绑定职务
        /// </summary>
        private void position()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='2' and enable='Y'");
            cboCreers.DataSource = ds.Tables[0].DefaultView;
            cboCreers.ValueMember = "ID";
            cboCreers.DisplayMember = "NAME";          
            cboCreers.SelectedText = "普通职工";            
        }
        /// <summary>
        /// 绑定年资
        /// </summary>
        private void Price()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='6'");
            cboPrice.DataSource = ds.Tables[0].DefaultView;
            cboPrice.ValueMember = "ID";
            cboPrice.DisplayMember = "NAME";
        }
        /// <summary>
        /// 绑定处方权
        /// </summary>
        private void Prescription()
        {

            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='7' order by ID asc");
            cboPrescription.DataSource = ds.Tables[0].DefaultView;
            cboPrescription.ValueMember = "ID";
            cboPrescription.DisplayMember = "NAME";
            cboPrescription.SelectedText = "无处方权";
            cboPrescription.SelectedValue = "214";
        }

        private void Prescriptions()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='7' and id>59");
            cboPrescription.DataSource = ds.Tables[0].DefaultView;
            cboPrescription.ValueMember = "ID";
            cboPrescription.DisplayMember = "NAME";
        }
        /// <summary>
        /// 绑定所属科室
        /// </summary>
        private void Bangding()
        {
            string section_id =App.UserAccount.CurrentSelectRole.Section_Id;
            DataSet dsc = App.GetDataSet("select * from T_SECTIONINFO where ENABLE_FLAG='Y' and SID=" + section_id + "");
            cboOffice.DataSource = dsc.Tables[0].DefaultView;
            cboOffice.ValueMember = "SID";
            cboOffice.DisplayMember = "SECTION_NAME";
           
            if (cboOffice.Items.Count > 0)
            {
                cboOffice.SelectedIndex = 0;
            }

        }
        /// <summary>
        /// 绑定所属病区
        /// </summary>
        private void Sick()
        {
            string Section_id = App.UserAccount.CurrentSelectRole.Section_Id;
            string sick_id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
            try
            {
                DataSet dt = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join t_sickareainfo b on b.said=g.said where g.sid='" + Section_id + "' and ENABLE_FLAG='Y' and g.SAID=" + sick_id + " ");
                cboSick.DataSource = dt.Tables[0].DefaultView;
                cboSick.ValueMember = "SAID";
                cboSick.DisplayMember = "SICK_AREA_NAME";
                if (cboSick.Items.Count>0)
                {
                    cboSick.SelectedIndex = 0;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            dtpBirthday.Enabled = false;
            cboCreer.Enabled = false;
            cboPrice.Enabled = false;
            dtpAppointment.Enabled = false;
            cboCreers.Enabled = false;
            cboOffice.Enabled = false;
            cboSick.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtTelphone.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            cboPrescription.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            isSave = false;

        }
        /// <summary>
        /// 临时帐号添加编辑状态
        /// </summary>
        /// <param name="flag"></param>
        private void LEdit(bool flag)
        {
            if (flag)
            {
                txtNumber.Text = "";
                txtName.Text = "";
                cboSick.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtTelphone.Text = "";
                txtCertificatename.Text = "";
                rbtnNoselected.Checked = true;

            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboGender.Enabled = true;
            dtpBirthday.Enabled = true;
            cboCreer.Enabled = true;
            cboPrice.Enabled = true;
            dtpAppointment.Enabled = true;
            cboCreers.Enabled = true;
            cboOffice.Enabled = true;
            cboSick.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtTelphone.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            rbtnSelected.Enabled = true;
            rbtnNoselected.Enabled = true;
            txtCertificatename.Enabled = true;
            cboPrescription.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            btnAddTempUser.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            Prescriptions();
            txtNumber.Focus();
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
                cboSick.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtTelphone.Text = "";
                txtCertificatename.Text = "";
                
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboGender.Enabled = true;
            dtpBirthday.Enabled = true;
            cboCreer.Enabled = true;
            cboPrice.Enabled = true;
            dtpAppointment.Enabled = true;
            cboCreers.Enabled = true;
            cboOffice.Enabled = true;
            cboSick.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtTelphone.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            rbtnSelected.Enabled = true;
            rbtnNoselected.Enabled = true;
            txtCertificatename.Enabled = true;
            dtpPassingtime.Enabled = true;
            dtpLeadcard.Enabled = true;
            dtpRegdate.Enabled = true;
            cboPrescription.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            btnAddTempUser.Enabled = false;
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
                Prescription();
            }
            else
            {
                txtCertificatename.Enabled = false;
                dtpPassingtime.Enabled = false;
                dtpLeadcard.Enabled = false;
                dtpRegdate.Enabled = false;
                Prescriptions();
            }



            //if (Convert.ToInt32( cboCreer.SelectedValue.ToString()) ==5)
            //{
            //    if (Convert.ToInt32(cboCreers.SelectedIndex.ToString()) ==27 )
            //    {
            //        Prescriptions();
            //    }
            //}
            txtNumber.Focus();
        }

        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from t_userinfo where  USER_NUM='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from t_userinfo where USER_NAME='" + name + "'");
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
            accounttype = "0";
            isSave = true;
            rbtnSelected.Checked = true;
            Edit(isSave);
            txtNumber.ReadOnly = false;
            for (int i = 0; i < cboCreers.Items.Count; i++)
            {
                DataRowView drv = cboCreers.Items[i] as DataRowView;
                if (drv["NAME"].ToString() == "普通职工")
                {
                    cboCreers.SelectedItem = cboCreers.Items[i];
                }
            }
            cboPrescription.Text = "普通处方权";
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
                #region 拼音码生成
                string sql_pinyin = "select tt.user_num,tt.user_name,tt.shortcut_code from t_userinfo tt where tt.shortcut_code is null";
                DataSet ds_pinyin = App.GetDataSet(sql_pinyin);
                if (ds_pinyin.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_pinyin.Tables[0].Rows.Count; i++)
                    {
                        string pinyin = App.getSpell(App.ToDBC(ds_pinyin.Tables[0].Rows[i]["user_name"].ToString()));
                        string sql_update = "update t_userinfo set shortcut_code='" + pinyin + "' where user_num='" + ds_pinyin.Tables[0].Rows[i]["user_num"].ToString() + "'";
                        App.ExecuteSQL(sql_update);
                    }
                }
                #endregion
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
                //if (mark == "")
                //{
                //    App.Msg("有效标志未填写，不能保存！");
                //    txtNumber.Focus();
                //    return;
                //}
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("工号未填写，不能保存！");
                    txtNumber.Focus();
                    return;
                }

                if (txtName.Text.Trim() == "")
                {
                    App.Msg("名字未填写，不能保存！");
                    txtName.Focus();
                    return;
                }
                //拼音码
                string SpellName = App.getSpell(App.ToDBC(txtName.Text.Trim()));

                if (cboGender.Text.Trim() == "")
                {
                    App.Msg("性别未填写，不能保存");
                    cboGender.Focus();
                    return;
                }
                if (cboCreer.Text.Trim() == "")
                {
                    App.Msg("职称未填写，不能保存！");
                    cboCreer.Focus();
                    return;
                }
                if (cboCreers.Text.Trim() == "")
                {
                    App.Msg("职务必须填写！");
                    cboCreers.Focus();
                    return;
                }
                if (cboOffice.Text.Trim() == "")
                {
                    App.Msg("所属科室未填写，不能保存！");
                    cboOffice.Focus();
                    return;
                }
                if (cboSick.Text.Trim() == "")
                {
                    App.Msg("所属病区未填写，不能保存！");
                    cboSick.Focus();
                    return;
                }

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

                //if (cboPrescription.Text.Trim() == "")
                //{
                //    App.Msg("处方权必须填写！");
                //    cboPrescription.Focus();
                //    return;
                //}

                //出生年月
                string Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                //入职年月
                string Appointment = dtpAppointment.Value.ToString("yyyy-MM-dd");
                //通过时间
                string Passingtime = dtpPassingtime.Value.ToString("yyyy-MM-dd");
                //领证时间
                string Leadcard = dtpLeadcard.Value.ToString("yyyy-MM-dd");
                //注册时间
                string Regdate = dtpRegdate.Value.ToString("yyyy-MM-dd");
                cboPrescription.Enabled = true;

                string sql = "";
                ID = App.GenId("t_userinfo", "USER_ID").ToString();

                if (isSave)
                {

                    if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同用户的工号了！");
                        txtNumber.Focus();
                        return;
                    }
                    //else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("已经存在了相同名称用户的名称了！");
                    //    //txtName.Focus();
                    //    return;
                    //}

                    sql = "insert into t_userinfo(User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,U_Seniority,In_Time,U_Position,U_Recipe_Power,Section_Id,Sickarea_Id,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time,ACCOUNT_TYPE,shortcut_code)  values("
                          + ID + ",'"
                          + App.ToDBC(txtNumber.Text) + "','"
                          + App.ToDBC(txtName.Text) + "','"
                          + cboGender.SelectedIndex.ToString() + "',to_timestamp('"
                          + Birthday + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + cboCreer.SelectedValue + "','"
                          + cboPrice.SelectedValue + "',to_timestamp('"
                          + Appointment + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + cboCreers.SelectedValue + "','"
                          + cboPrescription.SelectedValue + "','"
                          + cboOffice.SelectedValue + "','"
                          + cboSick.SelectedValue + "','"
                          + txtPhone.Text + "','"
                          + txtEmail.Text + "','"
                          + txtTelphone.Text + "','"
                          + mark + "','"
                          + prescription + "','"
                          + txtCertificatename.Text + "',to_timestamp('"
                          + Passingtime + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Leadcard + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Regdate + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + accounttype + "','"+SpellName+"')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (user_number.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != user_number.Trim())
                        {
                            if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("已经存在了相同用户的工号了！");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update t_userinfo set User_Num='"
                             + App.ToDBC(txtNumber.Text) + "', User_Name='"
                             + App.ToDBC(txtName.Text) + "',Gender_Code='"
                             + cboGender.SelectedIndex.ToString() + "',Birthday=to_timestamp('"
                             + dtpBirthday.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),U_Tech_Post='"
                             + cboCreer.SelectedValue + "',U_Seniority='"
                             + cboPrice.SelectedValue + "',In_Time=to_timestamp('"
                             + dtpAppointment.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),U_Position='"
                             + cboCreers.SelectedValue + "',U_Recipe_Power='"
                             + cboPrescription.SelectedValue + "',Section_Id='"
                             + cboOffice.SelectedValue + "',Sickarea_Id='"
                             + cboSick.SelectedValue + "',Phone='"
                             + txtPhone.Text + "',Email='"
                             + txtEmail.Text + "',Mobile_Phone='"
                             + txtTelphone.Text + "',Enable='"
                             + mark + "',shortcut_code='" + SpellName + "',Profession_Card='"
                             + prescription + "',Prof_Card_Name='"
                             + txtCertificatename.Text + "',Pass_Time=to_timestamp('"
                             + dtpPassingtime.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),Receive_Time=to_timestamp('"
                             + dtpLeadcard.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),Register_Time=to_timestamp('"
                             + dtpRegdate.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),ACCOUNT_TYPE='" + accounttype + "'  where User_Id=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户编号"].ToString() + "";
                    btnUpdate_Click(sender, e);
                }

                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                        btnLookup_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
                ucUserInfo_Load(sender, e);
                //string SQl = T_user_sql + "  order by User_Id asc";
                //ucC1FlexGrid1.DataBd(SQl, "User_Id", "User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,u_tech_post_name,U_Seniority,u_seniority_name,In_Time,U_Position,u_position_name,U_Recipe_Power,u_recipe_power_name,Section_Id,section_id_name,Sickarea_Id,sickarea_id_name,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time", "用户编号,用户工号,用户姓名,用户性别,出生年月,职称编号,职称,年资编号,年资,入职年月,职务编号,职务,处方权编号,处方权,科室编号,所属科室,病区编号,所属病区,电话,邮箱地址,手机号码,有效标志,职业资格证,资格证书名称,通过时间,领证时间,注册时间");         
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
            //cboPrescription.Enabled = true;
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
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            cboSick.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtTelphone.Text = "";
            txtCertificatename.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            dtpBirthday.Enabled = false;
            cboCreer.Enabled = false;
            cboPrice.Enabled = false;
            dtpAppointment.Enabled = false;
            cboCreers.Enabled = false;
            cboOffice.Enabled = false;
            cboSick.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtTelphone.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            cboPrescription.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            btnAddTempUser.Enabled = true;
            //groupBox1.Enabled = true;

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataSet ds = App.GetDataSet("select Count(*) from t_account_user where USER_ID=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户编号"].ToString() + "");
            if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
            {
                if (App.Ask("你是否要删除"))
                {
                    App.ExecuteSQL("update  t_userinfo  set enable='N' where  User_Id='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户编号"].ToString() + "'");
                }
            }
            else
            {
                if (App.Ask("该用户信息已经与账号管理相关联，点击“是”删除用户并解除关联!"))
                    App.ExecuteSQL("update  t_userinfo  set enable='N' where  User_Id='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户编号"].ToString() + "'");


            }


            //显示列表数据
            ShowValue();
            refurbish();
            //btnCancel_Click(sender,e);
            //string SQl = T_user_sql + "  order by User_Id asc";
            //ucC1FlexGrid1.DataBd(SQl, "User_Id", "User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,u_tech_post_name,U_Seniority,u_seniority_name,In_Time,U_Position,u_position_name,U_Recipe_Power,u_recipe_power_name,Section_Id,section_id_name,Sickarea_Id,sickarea_id_name,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time", "用户编号,用户工号,用户姓名,用户性别,出生年月,职称编号,职称,年资编号,年资,入职年月,职务编号,职务,处方权编号,处方权,科室编号,所属科室,病区编号,所属病区,电话,邮箱地址,手机号码,有效标志,职业资格证,资格证书名称,通过时间,领证时间,注册时间");  
        }
        int index = 0;
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param Name="sender"></param>
        ///// <param Name="e"></param>
        //private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (index > 0)
        //    {
        //        btnDelete_Click(sender, e);
        //    }
        //    else
        //    {
        //        App.Msg("您还没有选中要操作的用户");
        //    }
        //}

        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                index = ucC1FlexGrid1.fg.RowSel;
                if (ucC1FlexGrid1.fg.RowSel >= 0)
                {
                    ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户编号"].ToString();
                    txtNumber.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户工号"].ToString();
                    user_number = txtNumber.Text;
                    txtName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户姓名"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户性别"].ToString() == "男")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "出生年月"] != DBNull.Value)
                    {
                        dtpBirthday.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "出生年月"]);

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "职称编号"] != null)
                    {
                        cboCreer.SelectedValue = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "职称编号"];
                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "年资编号"].ToString() != "")
                    {
                        cboPrice.SelectedValue = Convert.ToInt16(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "年资编号"].ToString());

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "入职年月"] != DBNull.Value)
                    {
                        dtpAppointment.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "入职年月"]);

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "职务编号"].ToString() != "")
                    {
                        cboCreers.SelectedValue = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "职务编号"].ToString();

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "处方权编号"].ToString() != "")
                    {
                        cboPrescription.SelectedValue = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "处方权编号"].ToString();

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString() != "")
                    {
                        cboOffice.SelectedValue = Convert.ToInt64(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString());

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString() != "")
                    {
                        cboSick.SelectedValue = Convert.ToInt64(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"]);

                    }
                    txtPhone.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "电话"].ToString();
                    txtEmail.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "邮箱地址"].ToString();
                    txtTelphone.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "手机号码"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "有效标志"].ToString() == "有效")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "职业资格证"].ToString() == "有")
                    {
                        rbtnSelected.Checked = true;
                    }
                    else
                    {
                        rbtnNoselected.Checked = true;
                    }
                    txtCertificatename.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "资格证书名称"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "通过时间"] != DBNull.Value)
                    {
                        dtpPassingtime.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "通过时间"]);

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "领证时间"] != DBNull.Value)
                    {
                        dtpLeadcard.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "领证时间"]);

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "注册时间"] != DBNull.Value)
                    {
                        dtpRegdate.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "注册时间"]);
                    }
                    accounttype = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "用户类型"].ToString();

                    int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    if (rows > 0)
                    {
                        if (Rowcount == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //如果不是头行
                            if (rows > 0)
                            {
                                //就改变背景色
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            if (Rowcount > 0 && ucC1FlexGrid1.fg.Rows.Count >= Rowcount)
                            {
                                //定义上一次点击过的行还原
                                this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //给上一次的行号赋值
                    Rowcount = rows;
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
                string SQl = T_user_sql + " order by user_id desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //按用户姓名进行查询
                if (cboCondition.SelectedIndex == 0)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and   User_Name　like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //按用户编号进行查询
                else if (cboCondition.SelectedIndex == 1)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and 　User_Num  like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                    }
                }
                //按病区名称进行查询
                else if (cboCondition.SelectedIndex == 2)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and  　s.sick_area_name  like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                    }
                }
                //按科室进行查询
                else if (cboCondition.SelectedIndex == 3)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and  　d.section_name  like'%" + txtBox.Text.Trim() + "%' order by User_Id asc";
                    }
                }
                //按职称进行查询
                else if (cboCondition.SelectedIndex == 4)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and 　c.name  like'%" + txtBox.Text.Trim() + "%' order by User_Id asc";
                    }
                }
                if (txtBox.Text.Trim() == "")
                {
                    SQl = T_user_sql + " and d.SID  in  ( " + sectionIds + " ) order by User_Id asc ";
                }
                ucC1FlexGrid1.DataBd(SQl, "用户编号", false, "", "");
                ucC1FlexGrid1.fg.Cols["用户编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["用户编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职称编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["年资编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["职务编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["处方权编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
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

        private void 账号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                Class_User user = new Class_User();
                user.User_id = ID;
                user.User_name = txtName.Text;
                user.User_num = txtNumber.Text;
                user.Accounttype = accounttype;
                App.frmAccountSetByUser(user);
            }
            else
            {
                App.Msg("您还没有选中要操作的用户");
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
                cboGender.Focus();
            }


        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpBirthday.Focus();
            }

        }
        private void cboCreer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPrice.Focus();
            }
        }

        private void cboCreers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboOffice.Focus();
            }

        }

        private void cboOffice_KeyDown(object sender, KeyEventArgs e)
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
                cboPrescription.Focus();
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
                cboPrescription.Focus();
            }

        }

        private void cboPrescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void rbtnSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
                Prescription();
            }
        }

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
                    Prescriptions();
                }
            }
        }

        /// <summary>
        /// 添加临时帐号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTempUser_Click(object sender, EventArgs e)
        {
            accounttype = "2";
            isSave = true;
            LEdit(isSave);

            txtNumber.ReadOnly = true;
            txtNumber.Text = GenTempAccount();
            cboCreers.Text = "普通职工";
            cboCreer.Text = "住院医师";
            cboPrescription.Enabled = false;
        }
        /// <summary>
        /// 自动生成临时帐号（工号）
        /// </summary>
        /// <returns></returns>
        private string GenTempAccount()
        {
            string sql1 = "select t.user_num from t_userinfo t where t.user_num='A0001'";
            DataSet ds = App.GetDataSet(sql1);
            string account = "A";
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql2 = "select MAX(t.user_num) as num from t_userinfo t where Length(t.user_num)=5  and  substr(t.user_num,0,1)='A' and IsNumber(substr(t.user_num,2,4))=0";
                string num = App.ReadSqlVal(sql2, 0, "num");

                int tempindex = Convert.ToInt32(num.Replace("A", ""));
                tempindex = tempindex + 1;

                for (int i = 0; i < 4 - tempindex.ToString().Length; i++)
                {
                    account = account + "0";
                }
                account = account + tempindex.ToString();
            }
            else
            {
                account = "A0001";
            }
            return account;
        }

        private void dtpBirthday_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCreer.Focus();
            }
        }

        private void cboPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpAppointment.Focus();
            }
        }

        private void dtpAppointment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCreers.Focus();
            }
        }

        private void cboOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sick();
        }

        private void 账号管理ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //if (index > 0)
            //{
            //    Class_User user = new Class_User();
            //    user.User_id = ID;
            //    user.User_name = txtName.Text;
            //    user.User_num = txtNumber.Text;
            //    user.Accounttype = accounttype;
            //    App.frmAccountSetByUser(user);
            //}
            //else
            //{
            //    App.Msg("您还没有选中要操作的用户");
            //}
            Class_User user = new Class_User();
            user.User_id = ID;
            user.User_name = txtName.Text;
            user.User_num = txtNumber.Text;
            user.Accounttype = accounttype;
            
            //App.frmAccountSetByUser(user);
            if (ID == "")
            {
                MessageBox.Show("请选择角色！");
                return;
            }
            ucSectionkeep uckeep = this.Parent.Parent.Controls[1].Controls[0] as ucSectionkeep;//new ucSectionkeep(user);
            uckeep.SetUserInfo(user);
            uckeep.Dock = DockStyle.Fill;
            App.UsControlStyle(uckeep);
            if (MainTabControl.Tabs.Count == 1)
            {               
                DevComponents.DotNetBar.TabItem wuhu = new DevComponents.DotNetBar.TabItem();
                wuhu.Name = "zhanghao";
                wuhu.Text = "用户权限维护";
                DevComponents.DotNetBar.TabControlPanel modelpane2 = new DevComponents.DotNetBar.TabControlPanel();
                modelpane2.TabIndex = 1;
                modelpane2.TabItem = wuhu;
                wuhu.AttachedControl = modelpane2;
                modelpane2.Dock = DockStyle.Fill;
                modelpane2.AutoScroll = true;
                modelpane2.Controls.Add(uckeep);
                MainTabControl.Controls.Add(modelpane2);
                MainTabControl.Tabs.Add(wuhu);
                MainTabControl.SelectedTabIndex = 1;
            }
            else
            {
                MainTabControl.SelectedTabIndex = 1;
                uckeep.user = user;
                uckeep.Dock = DockStyle.Fill;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ID);
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {

        }

        private void rbtnNoselected_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnNoselected.Checked == true)
            {
                cboPrescription.Text = "无处方权";
            }
            else
            {
                cboPrescription.Text = "普通处方权";
            }
        }
        /// <summary>
        /// 获取科室ID字符串，作为SQL查询范围
        /// </summary>
        private void GetSectionIds()
        {

            for (int i = 0; i < App.UserAccount.Roles.Length; i++)
            {
                if (App.UserAccount.Roles[i].Role_name.Contains("主任") == true)
                {
                    for (int j = 0; j < App.UserAccount.Roles[i].Rnages.Length; j++)
                    {
                        if (sectionIds == "")
                        {
                            sectionIds = App.UserAccount.Roles[i].Rnages[j].Section_id;
                        }
                        else
                        {
                            sectionIds += "," + App.UserAccount.Roles[i].Rnages[j].Section_id;
                        }
                    }
                }
            }
        }
    }
}
