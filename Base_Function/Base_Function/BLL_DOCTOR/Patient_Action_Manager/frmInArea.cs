using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Bifrost_Nurse;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    /// <summary>
    /// 入区
    /// </summary>
    public partial class frmInArea : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 构造函数fk
        /// </summary>
        public frmInArea()
        {
            InitializeComponent();
        }
        private InPatientInfo Inpatient;
        private string tng_Id;   //诊疗组id
        private string tng_Name; //诊疗组名称
        private bool flag = false;

        /// <summary>
        /// 入区
        /// </summary>
        /// <param name="inpatient">病人实体</param>
        public frmInArea(InPatientInfo inpatient)//,frmMain fMain
        {
            InitializeComponent();
           
            App.FormStytleSet(this, false);
            //this.ffMain = fMain;
            this.Inpatient = inpatient;
            //this.lblInHos_section.Text = inpatient.Section_Name;
            this.lblWard.Text = App.UserAccount.CurrentSelectRole.Sickarea_name;
            this.lblInhospital_Id.Text = inpatient.PId;
            this.lblName.Text = inpatient.Patient_Name;
            this.lblAge.Text = inpatient.Age.ToString() + inpatient.Age_unit;
            string strSex = DataInit.StringFormat(inpatient.Gender_Code);
            this.lblSex.Text = strSex;
            this.lblInhospital_time.Text = string.Format("{0:g}", inpatient.In_Time);
            GetSection();
            GetEmptyBed(); 
            //是否有床位
            flag=IsHaveBed(inpatient);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(Inpatient.Id.ToString(), "", "", cbxBed_Id.SelectedValue.ToString(), "入区");
            if (validate)
            {
                string msg = "";
                bool isValidating = IsValidating(ref msg);
                if (!isValidating)
                {
                    try
                    {
                        if (cbxDoctor.Text != string.Empty)
                        {
                            string strBed_id = cbxBed_Id.SelectedValue.ToString();               //获取当前选中床位Id
                            string strBed_code = cbxBed_Id.Text;
                            //if (flag)//his那边已经分配床号
                            //{
                            //    strBed_id = Inpatient.Sick_Bed_Id.ToString();               //获取当前选中床位Id
                            //    strBed_code = Inpatient.Sick_Bed_Name;  
                            //}
                            //else
                            //{
                            //    if (cbxBed_Id.Text != string.Empty)
                            //    {
                            strBed_id = cbxBed_Id.SelectedValue.ToString();               //获取当前选中床位Id
                            strBed_code = cbxBed_Id.Text;
                            //}
                            //else
                            //{
                            //    App.Msg("请您选择床号!");
                            //    return;
                            //}
                            // }
                            string strDoctor_name = cbxDoctor.Text;                              //获取当前选中医生的名字
                            string strDoctor_id = cbxDoctor.SelectedValue.ToString();            //获取当前选中医生的ID



                            //获取当前选中床位代码
                            if (strDoctor_name != string.Empty && strDoctor_id != string.Empty &&
                                strBed_id != string.Empty && strBed_code != string.Empty)
                            {
                                string id = App.GenId("t_inhospital_action", "id").ToString();       //得到当前异动表里面的最大id加1.
                                //string time = string.Format("{0:g}", dateTimePicker1.Value);
                                //string strSection_id = App.UserAccount.CurrentSelectRole.Section_Id;
                                //string strSickArea_id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                                string UpdateRowSource = "update t_in_patient set in_doctor_id='" + strDoctor_id + "'," +
                                                        " in_doctor_name='" + strDoctor_name + "',sick_doctor_id='" + strDoctor_id + "'," +
                                                        " sick_doctor_name='" + strDoctor_name + "',in_bed_id=" + strBed_id + "," +
                                                        " in_bed_no='" + strBed_code + "',sick_bed_id=" + strBed_id + ",sick_bed_no='" + strBed_code + "'," +
                                                        " in_time=to_timestamp('" + dtpInAreaTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss'),Sick_Group_ID='" + tng_Id + "'," +
                                                        " Sick_Group_Name='" + tng_Name + "',IN_Treatgroup_ID='" + tng_Id + "'," +
                                                        " IN_Treatgroup_Name='" + tng_Name + "',section_id=" + cbxInHos_section.SelectedValue + "," +
                                                        " section_name='" + cbxInHos_section.Text + "',insection_id=" + cbxInHos_section.SelectedValue + "," +
                                                        " insection_name='" + cbxInHos_section.Text + "'" +
                                                        " where id=" + Inpatient.Id + "";           //状态4表示‘已完成’

                                //指定床号后，该床的状态改为占有74
                                string UpdateBed_State = "update t_sickbedinfo set state=74,sid=" + cbxInHos_section.SelectedValue + ",pid=" + Inpatient.Id + ",patient_id=" + Inpatient.Id + " where bed_id=" + strBed_id + "";

                                //向异动表插入一条入区记录
                                string InsertInArea = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                                       " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                                       " values(" + id + "," + cbxInHos_section.SelectedValue + "," + Inpatient.Sike_Area_Id + ",'" + Inpatient.Id + "'," +
                                                       "'入区','4',sysdate," + strBed_id + ",'" + strDoctor_id + "'," + App.UserAccount.Account_id + ",0,0," + Inpatient.Id + ")";
                                //向质控临时表新增一条入区记录
                                string strAge = string.Empty;
                                if (App.IsNumeric(Inpatient.Age))
                                {
                                    strAge = Inpatient.Age;
                                }
                                string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                                        " values('" + Inpatient.PId + "','入区',to_timestamp('" + dtpInAreaTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                        + "','yyyy-MM-dd hh24:mi:ss')," + Inpatient.Id + ",'" + strAge + "')";
                                string[] arr = new string[4];
                                arr[0] = UpdateRowSource;
                                arr[1] = UpdateBed_State;
                                arr[2] = InsertInArea;
                                arr[3] = InsertJob_Temp;
                                int count = App.ExecuteBatch(arr);
                                if (count > 0)
                                {
                                    DataInit.isInAreaSucceed = true;
                                    Inpatient.Sick_Bed_Id = Convert.ToInt32(cbxBed_Id.SelectedValue);
                                    Inpatient.Sick_Bed_Name = cbxBed_Id.Text;
                                    Inpatient.Sick_Doctor_Id = cbxDoctor.SelectedValue.ToString();
                                    Inpatient.Sick_Doctor_Name = cbxDoctor.Text;
                                    Inpatient.Sick_Group_Id = Convert.ToInt32(tng_Id);
                                    Inpatient.Sick_Group_Name = tng_Name;
                                    Inpatient.In_Time = dtpInAreaTime.Value;
                                    Inpatient.Section_Id = Convert.ToInt32(cbxInHos_section.SelectedValue.ToString());
                                    Inpatient.Section_Name = cbxInHos_section.Text;
                                    App.Msg("入区成功！");
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            App.Msg("管床医生不能为空！");
                        }
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
                else
                {
                    App.Msg(msg);
                }
            }
            else
            {
                App.Msg("操作失败，病人已入区或床位被占用！");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInArea_Load(object sender, EventArgs e)
        {

        }
        //
        private void cbxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTng.Visible = false;
            this.cbxTng.Visible = false;
            if (cbxDoctor.Text != "" &&
                cbxDoctor.Text != null)
            {
                string sql = "select c.tng_id,c.tng_name  from t_account_user a" +
                             " inner join t_tng_account b on a.account_id = b.account_id" +
                             " inner join t_treatornurse_group c on b.tng_id = c.tng_id" +
                             " where a.user_id ='" + cbxDoctor.SelectedValue + "' and c.belongto_id='" + Inpatient.Section_Id + "' ";
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

        private void cbxDoctor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.lblTng.Visible = false;
            this.cbxTng.Visible = false;
            if (cbxDoctor.Text != "" &&
                cbxDoctor.Text != null)
            {
                string sql = "select c.tng_id,c.tng_name  from t_account_user a" +
                             " inner join t_tng_account b on a.account_id = b.account_id" +
                             " inner join t_treatornurse_group c on b.tng_id = c.tng_id" +
                             " where a.user_id ='" + cbxDoctor.SelectedValue + "' and c.belongto_id='" + Inpatient.Section_Id + "' ";
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
                         " where f.section_id='" + cbxInHos_section.SelectedValue + "' and  e.role_type='D'";
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                DataTable dt = dsuser.Tables[0];
                cbxDoctor.DisplayMember = "user_name";
                cbxDoctor.ValueMember = "user_id";
                cbxDoctor.DataSource = dt.DefaultView;
            }
        }
        /// <summary>
        /// 获得当前病区的空床
        /// </summary>
        private void GetEmptyBed()
        {
            //state74表示‘占有’,75表示‘未占有’

            string Select_All_Bed = @" select a.bed_id,a.bed_no from t_sickbedinfo a  where a.state = 75 and a.enableflag = 'Y' and a.said = " + Inpatient.Sike_Area_Id + " order by a.bed_no asc";

            //string Select_All_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a" +
            //                        " left join t_sickroominfo b on a.srid = b.srid" +
            //                        " left join t_sickareainfo c on b.said = c.said" +
            //                        " where a.state=75 and a.enableflag='Y' and a.said=" + Inpatient.Sike_Area_Id + " order by a.bed_no asc ";                          //查找所属科室病区所有空闲的病床

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
        /// 获得当前病区的科室
        /// </summary>
        private void GetSection()
        {
            string Sql_getSection_ByArea = "select b.sid,b.section_name from t_section_area a" +
                                      " inner join t_sectioninfo b on a.sid = b.sid" +
                                      " where a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
            DataSet ds = App.GetDataSet(Sql_getSection_ByArea);
            DataTable dt = ds.Tables[0];
            cbxInHos_section.DisplayMember = "section_name";
            cbxInHos_section.ValueMember = "sid";
            cbxInHos_section.DataSource = dt.DefaultView;
        }

        private void cbxInHos_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDoctor();
        }
        /// <summary>
        /// 从his读过来，看床号是否已经分配
        /// </summary>
        /// <param name="inpate"></param>
        /// <returns></returns>
        private bool IsHaveBed(InPatientInfo inpate)
        {
            bool flag = false;
            if (inpate.Sick_Bed_Name != "") //有床
            {
                //lblBed.Visible = true;
                //Label lbl = new Label();30
                //lbl.Name = "lblBedNumber";
                //lbl.Text = inpate.Sick_Bed_Name;
                //lbl.Location = cbxBed_Id.Location;
                //lbl.Visible = true;
                //cbxBed_Id.Visible = false;
                //this.Controls.Add(lbl);
                cbxBed_Id.Text = inpate.Sick_Bed_Name;
                flag = true;
            }
            //else
            //{
            //    lblBed.Visible = true;
            //    cbxBed_Id.Visible = true;
            //}
            return flag;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool IsValidating(ref string msg)
        {

            bool isValidating = false;
            if (cbxInHos_section.Text == string.Empty)
            {
                isValidating = true;
                msg = "科室不能为空！";
            }
            if(cbxBed_Id.Text==string.Empty)
            {
                isValidating = true;
                msg = "床号不能为空！";
            }
            if(cbxDoctor.Text==string.Empty)
            {
                isValidating = true;
                msg = "管床医生不能为空！";
            }
            if (cbxTng.Visible == true)
            { 
                if(cbxTng.Text==string.Empty)
                {
                    isValidating = true;
                    msg = "诊疗组不能为空！";
                }
            }
            return isValidating;
        }

        private void frmInArea_Load_1(object sender, EventArgs e)
        {

        }

    }
}