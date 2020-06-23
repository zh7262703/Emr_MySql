using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;
using TempertureEditor.Tempreture_Management;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmTurn_In : DevComponents.DotNetBar.Office2007Form
    {
        public frmTurn_In()
        {
            InitializeComponent();
        }
        private InPatientInfo inPateintInfo;
        private string sectionId;
        private string sectionName;
        private string sick_area_id;
        private string sick_area_name;
        private string tng_Id;   //诊疗组id
        private string tng_Name; //诊疗组
        //标记当前登录科室是否和HIS中的病人科室ID一致
        private bool isHisSection = false;
        /// <summary>
        /// 目标科室id
        /// </summary>
        private string Target_Sid = null;
        public frmTurn_In(InPatientInfo inpateint)
        {
            InitializeComponent();
            this.inPateintInfo = inpateint;
            App.FormStytleSet(this, false);

            //判断HIS中的科室ID和当前登录科室是否一致
            string his_section_id = App.ReadSqlVal("select his_section_id from t_turn_section where patient_id=" + inPateintInfo.Id, 0, "his_section_id");
            if (his_section_id == App.UserAccount.CurrentSelectRole.Section_Id)
            {
                isHisSection = true;
            }
            InitForm();
            //获得空床
            GetEmptyBed();

            //获取管床医生
            GetDoctors();

        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            try
            {
                DataTable dt_section = DataInit.GetTargetSName(inPateintInfo);
                if (dt_section.Rows.Count > 0)
                {
                    /*
                     * 根据当前病人的id得到科室名称，科室ID
                     * **/
                    sectionName = dt_section.Rows[0]["section_name"].ToString();
                    sick_area_id = dt_section.Rows[0]["target_said"].ToString();
                    sick_area_name = dt_section.Rows[0]["sick_area_name"].ToString();

                    //从异动表获取当前病人最后一条异动信息发生时间，目标科室ID,名称
                    string SQLLast_time = "select happen_time,target_sid from t_inhospital_action  " +
                                          " where id = (select max(id) from t_inhospital_action where patient_id ='" + inPateintInfo.Id + "')";


                    DataSet ds = App.GetDataSet(SQLLast_time);
                    DataTable dt = ds.Tables[0];
                    DateTime RollOut_Time = DateTime.Parse(dt.Rows[0]["happen_time"].ToString());
                    Target_Sid = dt.Rows[0]["target_sid"].ToString();
                    lblPid.Text = inPateintInfo.PId;
                    lblUserName.Text = inPateintInfo.Patient_Name;
                    lblAge.Text = inPateintInfo.Age.ToString() + inPateintInfo.Age_unit;
                    string sex = DataInit.StringFormat(inPateintInfo.Gender_Code);
                    lblSex.Text = sex;
                    //lblCurentArea.Text = App.UserAccount.CurrentSelectRole.Sickarea_name;
                    lblCurentArea.Text = sectionName;
                    lblRollout_Time.Text = string.Format("{0:g}", RollOut_Time);
                    lblRollout_Area.Text = inPateintInfo.Section_Name + "—" + inPateintInfo.Sick_Area_Name;
                }
            }
            catch (Exception)
            {

            }

        }

        private void frmTurn_In_Load(object sender, EventArgs e)
        {
            //InitForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(inPateintInfo.Id.ToString(), inPateintInfo.Section_Id.ToString(), inPateintInfo.Sike_Area_Id.ToString(), cbxBed_Id.SelectedValue.ToString(), "转科(转入)");
            string currSID = App.ReadSqlVal("select section_id from t_in_patient where id=" + inPateintInfo.Id, 0, "section_id");
            if (currSID == App.UserAccount.CurrentSelectRole.Section_Id)
            {
                App.Msg("该病人已转入！");
                DataInit.isInAreaSucceed = true;
                btnCancel_Click(sender,e);
                return;
            }
            if (validate)
            {
                if (cbx_Doctor.Text != string.Empty && cbxBed_Id.Text != string.Empty && dtpTurnInTime.Value > inPateintInfo.In_Time)
                {
                    //string time = string.Format("{0:g}", dtpTurnInTime.Value);
                    string DoctorId = cbx_Doctor.SelectedValue.ToString();
                    string DoctorName = cbx_Doctor.Text;
                    string BedId = cbxBed_Id.SelectedValue.ToString();
                    string BedNo = cbxBed_Id.Text;
                    //获取异动表中最后一条记录的ID
                    string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPateintInfo.Id + "'", 0, "nowid");

                    //生成异动表新记录的ID
                    string New_Id = App.GenId("t_inhospital_action", "id").ToString();

                    /*
                     * 新增加一条转科记录,修改最近的一条异动记录，与新增记录建立连接
                     */

                    string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                        " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                        " values(" + New_Id + "," + sectionId + "," + App.UserAccount.CurrentSelectRole.Sickarea_Id + ",'" + inPateintInfo.Id + "'," +
                                        "'转入','4',to_timestamp('" + dtpTurnInTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                        " " + cbxBed_Id.SelectedValue.ToString() + ",'" + cbx_Doctor.SelectedValue.ToString() + "'," + App.UserAccount.Account_id + ",0," +
                                        " " + Now_Id + ",0,0," + inPateintInfo.Id + ")";

                    string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                    //修改住院病人当前的科室，病区
                    //string Update_InPatient_Curent_sidAndArea = "update t_in_patient set section_id=" + sectionId + "," +
                    //                                            " section_name='" + sectionName + "',sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "," +
                    //                                            " sick_area_name='" + App.UserAccount.CurrentSelectRole.Sickarea_name + "',SICK_DOCTOR_ID='" + DoctorId + "'," +
                    //                                            " SICK_DOCTOR_Name='" + DoctorName + "',SICK_BED_ID=" + BedId + "," +
                    //                                            " SICK_BED_NO='" + BedNo + "',Sick_Group_ID='" + tng_Id + "',Sick_Group_Name='" + tng_Name + "',IN_Treatgroup_ID='" + tng_Id + "'," +
                    //                                            "IN_Treatgroup_Name='" + tng_Name + "' where id=" + inPateintInfo.Id + "";

                    string Update_InPatient_Curent_sidAndArea = "update t_in_patient set section_id=" + sectionId + "," +
                                                                " section_name='" + sectionName + "',sick_area_id=" + sick_area_id + "," +
                                                                " sick_area_name='" + sick_area_name + "',SICK_DOCTOR_ID='" + DoctorId + "'," +
                                                                " SICK_DOCTOR_Name='" + DoctorName + "',SICK_BED_ID=" + BedId + "," +
                                                                " SICK_BED_NO='" + BedNo + "',Sick_Group_ID='" + tng_Id + "',Sick_Group_Name='" + tng_Name + "',IN_Treatgroup_ID='" + tng_Id + "'," +
                                                                "IN_Treatgroup_Name='" + tng_Name + "' where id=" + inPateintInfo.Id + "";
                    //修改病人当前选择的床号为忙碌状态
                    string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + cbxBed_Id.SelectedValue.ToString() + "";
                    //向质控临时表新增一条转入记录
                    string strAge = string.Empty;
                    if (App.IsNumeric(inPateintInfo.Age))
                    {
                        strAge = inPateintInfo.Age;
                    }
                    string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                            " values('" + inPateintInfo.PId + "','转入记录',to_timestamp('" + dtpTurnInTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                            + "','yyyy-MM-dd hh24:mi:ss')," + inPateintInfo.Id + ",'" + strAge + "')";
                    //向质控临时表新增一条转出记录
                    string InsertJob_Temp_out = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                            " values('" + inPateintInfo.PId + "','转出记录',to_timestamp('" + dtpTurnInTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                            + "','yyyy-MM-dd hh24:mi:ss')," + inPateintInfo.Id + ",'" + strAge + "')";

                    string[] cmdstr = new string[6];
                    cmdstr[0] = InsertSQL;
                    cmdstr[1] = UdateOld;
                    cmdstr[2] = Update_InPatient_Curent_sidAndArea;
                    cmdstr[3] = UpdateBed_State;
                    //cmdstr[4] = Update_Inpatient_Old_BedState;
                    cmdstr[4] = InsertJob_Temp_out;
                    cmdstr[5] = InsertJob_Temp;
                    int count = 0;
                    count = App.ExecuteBatch(cmdstr);
                    if (count > 0)
                    {
                        DataInit.isInAreaSucceed = true;
                        inPateintInfo.Section_Id = Int32.Parse(sectionId);
                        inPateintInfo.Section_Name = sectionName;
                        inPateintInfo.Sick_Area_Name = sick_area_name;// DataInit.section_name;
                        inPateintInfo.Sike_Area_Id = sick_area_id;//App.UserAccount.CurrentSelectRole.Sickarea_Id);
                        inPateintInfo.Sick_Doctor_Id = DoctorId;
                        inPateintInfo.Sick_Doctor_Name = DoctorName;
                        inPateintInfo.Sick_Bed_Id = Int32.Parse(BedId);
                        inPateintInfo.Sick_Bed_Name = BedNo;
                        inPateintInfo.Sick_Group_Id = Convert.ToInt32(tng_Id);
                        inPateintInfo.Sick_Group_Name = tng_Name;
                        App.Msg(inPateintInfo.Patient_Name + " 已转入");
                        Node node = new Node();
                        node.Tag = inPateintInfo as object;
                        node.Text = inPateintInfo.Patient_Name;
                        DataInit.PatientsNode.Nodes.Add(node);

                        if (inPateintInfo.PId.Contains("_"))
                        //新生儿
                            tempetureDataComm.InsertAutoOptEvent(inPateintInfo, dtpTurnInTime.Value, "转入", tempetureDataComm.TEMPLATE_CHILD);
                        else
                            tempetureDataComm.InsertAutoOptEvent(inPateintInfo, dtpTurnInTime.Value, "转入", tempetureDataComm.TEMPLATE_NORMAL);
                    }
                    this.Close();
                }
                else
                {
                    App.Msg("床号或管床医生不能为空！");
                }
            }
            else
            {
                App.Msg("操作失败，病人已经存在！");
            }
        }

        private void GetEmptyBed()
        {
            //if (DataInit.GetTargetSName(inPateintInfo).Rows.Count > 0)
            //    sectionId = DataInit.GetTargetSName(inPateintInfo).Rows[0]["sid"].ToString();
            string Select_All_Bed = "";
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                DataSet dssection = App.GetDataSet("select a1.sid,a1.section_name from t_sectioninfo a1 inner join t_inhospital_action b1 on a1.sid=b1.target_sid and b1.next_id=0 and b1.pid=" + inPateintInfo.Id.ToString() + "");
                sectionId = dssection.Tables[0].Rows[0]["sid"].ToString();
                //查找所属科室病区所有空闲的病床--a.state=75 表示空床
                Select_All_Bed = "select distinct(a.bed_id),a.bed_no,a.bed_code from T_SICKBEDINFO a left join t_section_area b on a.said=b.said " +
                                        " where a.said = (select said from t_section_area t where t.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and rownum=1) and " +
                                        " a.enableflag='Y' order by length(a.bed_no),a.bed_no";//cast(a.bed_id as number)";

            }
            else
            {
                sectionId = App.UserAccount.CurrentSelectRole.Section_Id;
                //查找所属科室病区所有空闲的病床--a.state=75 表示空床
                Select_All_Bed = "select distinct(a.bed_id),a.bed_no,a.bed_code from T_SICKBEDINFO a left join t_section_area b on a.said=b.said " +
                                        " where a.said = (select said from t_section_area t where t.sid=" + App.UserAccount.CurrentSelectRole.Section_Id + " and rownum=1) and " +
                                        " a.enableflag='Y' order by length(a.bed_no),a.bed_no";//cast(a.bed_id as number)";

            }
            //查找所属科室病区所有空闲的病床
            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                cbxBed_Id.DisplayMember = "bed_no";
                cbxBed_Id.ValueMember = "bed_id";
                cbxBed_Id.DataSource = dt;
            }
            //如果和HIS中的科室ID一致，则设置默认值
            if (isHisSection)
            {
                //病人需要转入的床位
                string his_bed = App.ReadSqlVal("select bed_id from t_turn_section t inner join t_sickbedinfo s on t.his_bed=s.bed_id and t.his_section_id=s.sid where t.patient_id=" + inPateintInfo.Id, 0, "bed_id");
                if (his_bed != "")
                {
                    cbxBed_Id.SelectedValue = his_bed;
                }
            }

        }

        private void GetDoctors()
        {
            //获得当前角色ID
            string id = App.UserAccount.CurrentSelectRole.Role_id;
            string Sql = "";
            //if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            //{
            //获取当前用户所在科室的医生            
            Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + Target_Sid + "' and  e.role_type='D'";
            //}
            //else
            //{
            //            //获取当前用户所在科室的医生            
            //    Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
            //                 " inner join t_account_user b on a.user_id=b.user_id" +
            //                 " inner join t_account c on b.account_id = c.account_id" +
            //                 " inner join t_acc_role d on d.account_id = c.account_id" +
            //                 " inner join t_role e on e.role_id = d.role_id" +
            //                 " inner join t_acc_role_range f on d.id = f.acc_role_id" +
            //                 " where f.section_id='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  e.role_type='D'";

            //}
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                cbx_Doctor.DisplayMember = "user_name";
                cbx_Doctor.ValueMember = "user_id";
                cbx_Doctor.DataSource = dsuser.Tables[0].DefaultView;
            }
            //如果和HIS中的科室ID一致，则设置默认值
            if (isHisSection)
            {
                //HIS中病人的管床医生
                string his_doctor = App.ReadSqlVal("select his_doctor from t_turn_section where patient_id=" + inPateintInfo.Id, 0, "his_doctor");
                if (his_doctor !="" && Convert.ToInt32(his_doctor) != -1)
                {
                    cbx_Doctor.SelectedValue = his_doctor;
                }
            }


        }

        private void cbx_Doctor_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void cbx_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTng.Visible = false;
            this.cbxTng.Visible = false;
            if (cbx_Doctor.Text != "" &&
                cbx_Doctor.Text != null)
            {
                string sql = "select c.tng_id,c.tng_name  from t_account_user a" +
                             " inner join t_tng_account b on a.account_id = b.account_id" +
                             " inner join t_treatornurse_group c on b.tng_id = c.tng_id" +
                             " where a.user_id ='" + cbx_Doctor.SelectedValue + "' and c.belongto_id='" + App.UserAccount.CurrentSelectRole.Section_Id + "'";
                DataSet ds = App.GetDataSet(sql);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cbxTng.DataSource = dt.DefaultView;
                    cbxTng.DisplayMember = "tng_name";
                    cbxTng.ValueMember = "tng_id";
                    this.lblTng.Visible = true;
                    this.cbxTng.Visible = true;
                    tng_Id = cbxTng.SelectedValue.ToString();
                    tng_Name = cbxTng.Text;
                }
                else
                {
                    tng_Id = "0";
                    tng_Name = "";
                }
            }
        }


    }
}