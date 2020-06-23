using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Web.UI.WebControls;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmPatientIN : DevComponents.DotNetBar.Office2007Form
    {
        public frmPatientIN()
        {
            InitializeComponent();
        }

        //病区ID
        int sickareaId = 0;
        private string inpatientID = "";        //病人ID
        string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,to_number(a.section_code)";//查询科室

        string CurrentSickAraCode = "";     //当前病区代码
        string CurrentSickSectionCode = ""; //当前科室代码

        string Medicare_NO, Home_Address, Homepostal_Code, Home_Phone, office, Office_Address, Office_Phone, Relation_Name, Relation, Relation_Address, Relation_Phone, PAY_MANNER, PROPERTY_FLAG, SICK_DEGREE, NURSE_LEVEL;

        private void frmPatientIN_Load(object sender, EventArgs e)
        {

            try
            {
                if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                {
                    //由于App.UserAccount得不到病区ID，使用科室ID在t_section_area表中得到病区ID
                    string sql_getSickareaId = "select said from t_section_area where sid=" + App.UserAccount.CurrentSelectRole.Section_Id;
                    DataSet ds1 = App.GetDataSet(sql_getSickareaId);
                    DataTable dt1 = ds1.Tables[0];
                    DataRow row = dt1.Rows[0];
                    sickareaId = Convert.ToInt32(row["said"].ToString());                   
                }
                else
                {
                    sickareaId = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Sickarea_Id); 
                }

             

                App.SetMainFrmMsgToolBarText("病人信息");
                //绑定当前病区
                CuSick();
                //绑定当前科室
                Section();
                //绑定年龄单位

                cboAgeunit.SelectedIndex = 0;

                //获取当前病区的空床
                GetEmptyBed();
                //获取管床医生
                GetDoctor();
                cboGender.SelectedIndex = 0;


                /*
                        * 肿瘤科的处理
                        */
                if (CurrentSickAraCode == "2020")
                {
                    CurrentSickSectionCode = "2120";
                }
                if (CurrentSickAraCode == "2021")
                {
                    CurrentSickSectionCode = "2120";
                }
                /*
                 * 消化内科
                 */
                if (CurrentSickAraCode == "2002")
                {
                    CurrentSickSectionCode = "2102";
                }
                if (CurrentSickAraCode == "2003")
                {
                    CurrentSickSectionCode = "2102";
                }

                btnReflresh_Click(sender, e);
                cboConditions.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获得当前病区的空床
        /// </summary>
        private void GetEmptyBed()
        {
            //state74表示‘占有’,75表示‘未占有’

            string Select_All_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a" +
                                    " left join t_sickroominfo b on a.srid = b.srid" +
                                    " left join t_sickareainfo c on b.said = c.said" +
                                    " where a.enableflag='Y' and a.said=" + sickareaId + " order by bed_no asc";                          //查找所属科室病区所有空闲的病床

            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxBed_Id.DataSource = dt;
                    cbxBed_Id.DisplayMember = "bed_no";
                    cbxBed_Id.ValueMember = "bed_id";
                }
            }
        }

        /// <summary>
        /// 获取管床医生
        /// </summary>
        private void GetDoctor()
        {
            //获取当前用户所在科室的医生            
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + cboCusection.SelectedValue + "' and  e.role_type='D'";
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                DataTable dt = dsuser.Tables[0];
                cbxDoctor.DisplayMember = "user_name";
                cbxDoctor.ValueMember = "user_id";
                cbxDoctor.DataSource = dt.DefaultView;

                DataRowCollection rows = dt.Rows;
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i];
                    string doctorName = row["user_name"].ToString();
                    if (doctorName.Equals(App.UserAccount.UserInfo.User_name))
                    {
                        cbxDoctor.SelectedIndex = i;
                    }
                }

            }

        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        private void Section()
        {
            if (App.UserAccount.CurrentSelectRole.Section_name != "" && App.UserAccount.CurrentSelectRole.Section_name != null)
            {
                int sid = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);
                DataSet ds = App.GetDataSet("select sid,section_code,section_name from t_sectioninfo where sid=" + sid);
                cboCusection.DataSource = ds.Tables[0].DefaultView;
                cboCusection.DisplayMember = "section_name";
                cboCusection.ValueMember = "sid";
                CurrentSickSectionCode = ds.Tables[0].Rows[0]["section_code"].ToString();
            }
            else
            {
                DataSet ds = App.GetDataSet("select aa.sid,aa.section_code,aa.section_name from t_sectioninfo aa inner join t_section_area bb on aa.sid=bb.sid where bb.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id);
                cboCusection.DataSource = ds.Tables[0].DefaultView;
                cboCusection.DisplayMember = "section_name";
                cboCusection.ValueMember = "sid";
                CurrentSickSectionCode = ds.Tables[0].Rows[0]["section_code"].ToString();
            }
        }
        /// <summary>
        /// 绑定病区
        /// </summary>
        private void CuSick()
        {
//            string sql_Sick = @"select a.said,a.sick_area_code,a.sick_area_name from t_sickareainfo a 
//                                    inner join t_section_area b on a.said=b.said
//                                    where said=" + sickareaId“
//                                    group  by a.shid,a.said,a.sick_area_code,a.sick_area_name
//                                    order by a.shid,to_number(a.sick_area_code)";//查询病区
            DataSet ds = App.GetDataSet("select said,sick_area_code,sick_area_name from t_sickareainfo where said=" + sickareaId);
            
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                cboCusick.DataSource = dt.DefaultView;
                cboCusick.DisplayMember = "sick_area_name";
                cboCusick.ValueMember = "said";

                CurrentSickAraCode = dt.Rows[0]["sick_area_code"].ToString();

            }


        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            //stamp();
        }

        /// <summary>
        /// 根据时间的变化从而得到病人的年龄
        /// </summary>
        private void stamp()
        {
            try
            {
                int year = 0;
                int mont = 0;
                int day = 0;
                DataInit.GetAgeByBirthday(dtpBirthday.Value, App.GetSystemTime(), out year, out mont, out day);
                if (year > 0)
                    txtAge.Text = year.ToString();
            }
            catch
            { }                      
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPiyin.Text = App.getSpell(App.ToDBC(txtName.Text.Trim()));
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool IsValidating()
        {
            if (txtNumber.Text.Trim() == "")
            {
                App.Msg("病人住院号不能为空！");
                txtNumber.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                App.Msg("病人姓名不能为空！");
                txtName.Focus();
                return false;

            }
            if (txtAge.Text.Trim() == "")
            {
                App.Msg("年龄不能为空！");
                txtAge.Focus();
                return false;
            }
            if (cboAgeunit.Text.Trim() == "")
            {
                App.Msg("年龄单位不能为空！");
                cboAgeunit.Focus();
                return false;
            }
            if (cbxBed_Id.Text == string.Empty)
            {
                App.Msg("床号不能为空！");
                cbxBed_Id.Focus();
                return false;
            }
            if (cbxDoctor.Text == string.Empty)
            {
                App.Msg("管床医生不能为空！");
                cbxDoctor.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 确定提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lblZYH.Text.Trim() == "")
            {
                App.MsgWaring("HIS主键不能为空,请在当前HIS病人信息中选择要入区的病人！");
                return;
            }

            if (IsValidating())
            {
                //1
                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd ");
                string datetime = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
                string gender = cboGender.Text == "男" ? "0" : "1";
                string sql = "";
                inpatientID = App.GenId("T_IN_PATIENT ", "ID").ToString();//自动生成病人ID

                string sqlstr = "select a.id from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.patient_name='" + txtName.Text.Trim() + "' and a.pid='" + txtNumber.Text + "'";
                DataSet dsPatient=App.GetDataSet(sqlstr);
                if (dsPatient != null)
                {
                    if (dsPatient.Tables[0].Rows.Count > 0)
                    {
                        App.MsgWaring("已经存在了相同的病人！");
                        return;
                    }
                }


                if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                {
                    App.Msg("已经存在了相同名称的病人住院号了！");
                    txtNumber.Focus();
                    return;
                }

                string childage = "";
                if (cboAgeunit.Text == "不满一岁")
                {
                    childage = txtAge.Text;
                }

                //向病人表中添加一个新病人
                sql = "insert into T_IN_PATIENT(ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE,BIRTHDAY,PID,AGE,AGE_UNIT,SECTION_ID,SECTION_NAME,INSECTION_ID,INSECTION_NAME,IN_AREA_ID,IN_AREA_NAME,SICK_AREA_ID,SICK_AREA_NAME,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone,office,Office_Address,Office_Phone,Relation_Name,Relation,Relation_Address,Relation_Phone,PAY_MANNER,PROPERTY_FLAG,SICK_DEGREE,NURSE_LEVEL,IN_TIME,CHILD_AGE,his_id) values('"
                     + inpatientID + "','"
                     + txtName.Text + "','"
                     + txtPiyin.Text + "','"
                     + gender + "',to_timestamp('"
                     + birthday + "','syyyy-mm-dd '),'"
                     + txtNumber.Text + "','"
                     + txtAge.Text + "','岁','"
                     + cboCusection.SelectedValue + "','"
                     + cboCusection.Text + "','"
                     + cboCusection.SelectedValue + "','"
                     + cboCusection.Text + "','"
                     + cboCusick.SelectedValue + "','"
                     + cboCusick.Text + "','"
                     + cboCusick.SelectedValue + "','"
                     + cboCusick.Text + "','"
                     + Medicare_NO + "','"
                     + Home_Address + "','"
                     + Homepostal_Code + "','"
                     + Home_Phone + "','"
                     + office + "','"
                     + Office_Address + "','"
                     + Office_Phone + "','"
                     + Relation_Name + "','"
                     + Relation + "','"
                     + Relation_Address + "','"
                     + Relation_Phone + "','"
                     + PAY_MANNER + "','"
                     + PROPERTY_FLAG + "','"
                     + SICK_DEGREE + "','"
                     + NURSE_LEVEL + "',to_timestamp('" + datetime + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + childage + "','" + lblZYH.Text + "')";

                //2
                if (cbxDoctor.Text != string.Empty)
                {
                    string strBed_id = cbxBed_Id.SelectedValue.ToString();               //获取当前选中床位Id
                    string strBed_code = cbxBed_Id.Text;

                    string strDoctor_name = cbxDoctor.Text;                              //获取当前选中医生的名字
                    string strDoctor_id = cbxDoctor.SelectedValue.ToString();            //获取当前选中医生的ID

                    //获取当前选中床位代码
                    if (strDoctor_name != string.Empty && strDoctor_id != string.Empty &&
                        strBed_id != string.Empty && strBed_code != string.Empty)
                    {
                        string id = App.GenId("t_inhospital_action", "id").ToString();       //得到当前异动表里面的最大id加1.

                        string UpdateRowSource = "update t_in_patient set in_doctor_id='" + strDoctor_id + "'," +
                                                " in_doctor_name='" + strDoctor_name + "',sick_doctor_id='" + strDoctor_id + "'," +
                                                " sick_doctor_name='" + strDoctor_name + "',in_bed_id=" + strBed_id + "," +
                                                " in_bed_no='" + strBed_code + "',sick_bed_id=" + strBed_id + ",sick_bed_no='" + strBed_code + "'," +
                                                " in_time=to_timestamp('" + dtpInAreaTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                                " section_id=" + cboCusection.SelectedValue + "," +
                                                " section_name='" + cboCusection.Text + "',insection_id=" + cboCusection.SelectedValue + "," +
                                                " insection_name='" + cboCusection.Text + "'" +
                                                " where id=" + inpatientID + "";           //状态4表示‘已完成’

                        //指定床号后，该床的状态改为占有74
                        string UpdateBed_State = "update t_sickbedinfo set state=74,sid=" + cboCusection.SelectedValue + ",pid=" + inpatientID + ",patient_id=" + inpatientID + " where bed_id=" + strBed_id + "";

                        //向异动表插入一条入区记录
                        string InsertInArea = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                               " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                               " values(" + id + "," + cboCusection.SelectedValue + "," + cboCusick.SelectedValue + ",'" + inpatientID + "'," +
                                               "'入区','4',sysdate," + strBed_id + ",'" + strDoctor_id + "'," + App.UserAccount.Account_id + ",0,0," + inpatientID + ")";
                        //向质控临时表新增一条入区记录
                        string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                " values('" + inpatientID + "','入区',to_timestamp('" + dtpInAreaTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                + "','yyyy-MM-dd hh24:mi:ss')," + inpatientID + ")";
                        string[] arr = new string[5];
                        arr[0] = sql;
                        arr[1] = UpdateRowSource;
                        arr[2] = UpdateBed_State;
                        arr[3] = InsertInArea;
                        arr[4] = InsertJob_Temp;

                        int count = App.ExecuteBatch(arr);
                        if (count > 0)
                        {
                            DataInit.isInAreaSucceed = true;
                            //Inpatient.Sick_Bed_Id = Convert.ToInt32(cbxBed_Id.SelectedValue);
                            //Inpatient.Sick_Bed_Name = cbxBed_Id.Text;
                            //Inpatient.Sick_Doctor_Id = cbxDoctor.SelectedValue.ToString();
                            //Inpatient.Sick_Doctor_Name = cbxDoctor.Text;
                            //Inpatient.Sick_Group_Id = Convert.ToInt32(tng_Id);
                            //Inpatient.Sick_Group_Name = tng_Name;
                            //Inpatient.In_Time = dtpInAreaTime.Value;
                            //Inpatient.Section_Id = Convert.ToInt32(cbxInHos_section.SelectedValue.ToString());
                            //Inpatient.Section_Name = cbxInHos_section.Text;
                            App.Msg("操作成功！");
                            this.Close();
                        }
                    }
                }

            }

        }

        /// <summary>
        /// 判断是否出现重名ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_IN_PATIENT a  inner join t_inhospital_action b on a.id=b.pid where a.patient_name<>'"+txtName.Text+"' and a.pid='" + id + "' and b.action_type<>'出区'");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cboAgeunit.Text == "岁")
                //{
                //    if (txtAge.Text != "" && txtAge.Text != "0")
                //    {
                //        dtpBirthday.Value = App.GetSystemTime().AddYears(-Convert.ToInt32(txtAge.Text));
                //    }
                //}
                //else
                //{
                //    //不满一周岁
                //    dtpBirthday.Value = App.GetSystemTime();
                //}
            }
            catch
            {}
        }

        private void cboAgeunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgeunit.Text == "不满一岁")
            {
                dtpBirthday.Value = App.GetSystemTime();
                txtAge.Text = "";
            }
        }

        private void lblAgeCheck_Click(object sender, EventArgs e)
        {
            stamp();
        }

        /// <summary>
        /// 刷新HIS病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReflresh_Click(object sender, EventArgs e)
        {


            string SQl = "select * from HNYZ_ZXYY.intf_emr_inpatientinfview@DBHISLINK where brzt='I' and (BRBQ='" + CurrentSickAraCode + "' or BRKS='" + CurrentSickSectionCode + "') and ZYH not in (select his_id from t_in_patient a where a.his_id is not null)"; //一般查询


            if (chkUnusual.Checked)
            {
                //特殊查询
                SQl = "select * from HNYZ_ZXYY.intf_emr_inpatientinfview@DBHISLINK where brzt='I' and ZYH not in (select his_id from t_in_patient a where a.his_id is not null) ";
                if (cboConditions.Text == "住院号")
                {
                    SQl =SQl+ " and ZYHM='" + txtConditions.Text.Trim() + "'";
                }
                else
                {
                    SQl =SQl+ " and BRXM like '" + txtConditions.Text.Trim() + "%'";
                }
            }           

            DataSet ds = App.GetDataSet(SQl);
            dataHisInfos.DataSource = ds.Tables[0].DefaultView;


            for (int i = 0; i < dataHisInfos.ColumnCount; i++)
            {
                dataHisInfos.Columns[i].Visible = false;
            }

            for (int i = 0; i < dataHisInfos.ColumnCount; i++)
            {               
                dataHisInfos.Columns["ZYH"].HeaderText = "主键";
                dataHisInfos.Columns["ZYH"].Visible = true;
                dataHisInfos.Columns["ZYHM"].HeaderText = "住院号";
                dataHisInfos.Columns["ZYHM"].Visible = true;
                dataHisInfos.Columns["BRXM"].HeaderText = "姓名";
                dataHisInfos.Columns["BRXM"].Visible = true;
                dataHisInfos.Columns["BRXB"].HeaderText = "性别";
                dataHisInfos.Columns["BRXB"].Visible=true;
                dataHisInfos.Columns["SFZH"].HeaderText = "身份证";
                dataHisInfos.Columns["SFZH"].Visible = true;
                dataHisInfos.Columns["CSNY"].HeaderText = "出生日期";
                dataHisInfos.Columns["CSNY"].Visible = true;
                dataHisInfos.Columns["DJRQ"].HeaderText = "登记时间";
                dataHisInfos.Columns["DJRQ"].Visible = true;         
                dataHisInfos.Columns["RYRQ"].HeaderText = "入院时间";
                dataHisInfos.Columns["RYRQ"].Visible = true;                
            }
            dataHisInfos.AutoResizeColumns();

            lblZYH.Text = "";
        }

        private void dataHisInfos_Click(object sender, EventArgs e)
        {
            try
            {
                lblZYH.Text = dataHisInfos["ZYH", dataHisInfos.CurrentRow.Index].Value.ToString();
                txtNumber.Text = dataHisInfos["ZYHM", dataHisInfos.CurrentRow.Index].Value.ToString();
                txtName.Text = dataHisInfos["BRXM", dataHisInfos.CurrentRow.Index].Value.ToString();
                if (dataHisInfos["BRXB", dataHisInfos.CurrentRow.Index].Value.ToString() == "M")
                    cboGender.Text = "男";
                else
                    cboGender.Text = "女";

                dtpDatetime.Value = Convert.ToDateTime(dataHisInfos["DJRQ", dataHisInfos.CurrentRow.Index].Value);

                dtpInAreaTime.Value = Convert.ToDateTime(dataHisInfos["RYRQ", dataHisInfos.CurrentRow.Index].Value);

                dtpBirthday.Value = Convert.ToDateTime(dataHisInfos["CSNY", dataHisInfos.CurrentRow.Index].Value);

                Medicare_NO = dataHisInfos["SFZH", dataHisInfos.CurrentRow.Index].Value.ToString();
                Home_Address = dataHisInfos["HKDZ", dataHisInfos.CurrentRow.Index].Value.ToString();
                Homepostal_Code = dataHisInfos["HKYB", dataHisInfos.CurrentRow.Index].Value.ToString();
                Home_Phone = dataHisInfos["LXDH", dataHisInfos.CurrentRow.Index].Value.ToString();
                string workAddress = "";//工作单位优先显示合同单位的名称，如果为空则显示工作单位
                if (dataHisInfos["GZDW", dataHisInfos.CurrentRow.Index].Value != null)
                {
                    if (dataHisInfos["GZDW", dataHisInfos.CurrentRow.Index].Value.ToString() != "")
                    {
                        workAddress = dataHisInfos["GZDW", dataHisInfos.CurrentRow.Index].Value.ToString();
                    }
                }
                office = workAddress;
                Office_Address = workAddress;
                Office_Phone = dataHisInfos["DWDH", dataHisInfos.CurrentRow.Index].Value.ToString();
                Relation_Name = dataHisInfos["LXRM", dataHisInfos.CurrentRow.Index].Value.ToString();
                Relation = dataHisInfos["LXGX", dataHisInfos.CurrentRow.Index].Value.ToString();
                Relation_Address = dataHisInfos["LXDZ", dataHisInfos.CurrentRow.Index].Value.ToString();
                Relation_Phone = dataHisInfos["LXDH1", dataHisInfos.CurrentRow.Index].Value.ToString();
                PAY_MANNER = dataHisInfos["BRXZ", dataHisInfos.CurrentRow.Index].Value.ToString();
                PROPERTY_FLAG = dataHisInfos["BRXZ", dataHisInfos.CurrentRow.Index].Value.ToString();
                SICK_DEGREE = dataHisInfos["BRQK", dataHisInfos.CurrentRow.Index].Value.ToString() == "" ? "1" : dataHisInfos["BRQK", dataHisInfos.CurrentRow.Index].Value.ToString();
                string nurse_Level = "0";
                if (dataHisInfos["HLJB", dataHisInfos.CurrentRow.Index].Value.ToString() != "")
                {
                    nurse_Level = App.ReadSqlVal("select id from t_data_code where type=53 and name='" + dataHisInfos["HLJB", dataHisInfos.CurrentRow.Index].Value.ToString() + "'", 0, "id");
                }
                NURSE_LEVEL = nurse_Level;

            }
            catch
            {
 
            }
        }

        private void chkUnusual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnusual.Checked)
            {
                cboConditions.Enabled = true;
                txtConditions.Enabled = true;
            }
            else
            {
                cboConditions.Enabled = true;
                txtConditions.Enabled = true;
            }
        }

    }
}
