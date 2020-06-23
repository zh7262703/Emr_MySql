using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Data.SqlClient;
using Bifrost.WebReference;
using Base_Function.MODEL;
//using Bifrost.WebReference;

namespace Base_Function.BLL_NURSE.SickInformational
{
    /// <summary>
    /// 添加异动信息
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class AddSickTeport : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmSickReport ucfsr;
        frmSickReport fsr;
        string work = "";
        //public AddSickTeport(frmSickReport _fsr, string baiban)
        //{
        //    InitializeComponent();
        //    this.fsr = _fsr;
        //    this.work = baiban;
        //    App.FormStytleSet(this, false);
        //}
        public AddSickTeport(ucfrmSickReport _ucfsr, string baiban)
        {
            InitializeComponent();
            this.ucfsr = _ucfsr;
            this.work = baiban;
            App.FormStytleSet(this, false);
        }
        string bingquID = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            t_handovers_recordInfo handovers = new t_handovers_recordInfo();
            try
            {
                string projectID = "";//异动项目
                if (this.cckbOutHospital.Checked)
                    projectID = "240";
                if (this.cckbConvey.Checked)
                    projectID = "241";
                if (this.cckbkill.Checked)
                    projectID = "242";
                if (this.cckbInHospital.Checked)
                    projectID = "243";
                if (this.cckbShiftTo.Checked)
                    projectID = "244";
                if (this.cckbSymptom.Checked)
                    projectID = "245";
                if (this.cckbterminally.Checked)
                    projectID = "246";
                if (this.cckbOperation.Checked)
                    projectID = "247";
                if (this.cckbchildbearing.Checked)
                    projectID = "248";
                if (this.ccbkCaenozoic.Checked)
                    projectID = "249";
                if (this.ccbkmornOPS.Checked)
                    projectID = "250";
                string bed_no = this.ccbkbed_No.Text;//病床号
                string userName = this.txtuserName.Text;//病人姓名
                string illNessNO = this.txtIllNessNO.Text;//诊断号(病案号)
                string diagnoseName = this.txtDiagnoseName.Text;//诊断名
                string time = this.dateTimePicker1.Text;//时间
                string datatime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
                string remak = this.txtRemak.Text;//备注(特殊说明)
                string nurse_ID = App.UserAccount.UserInfo.User_id;//护士ID
                bingquID = App.UserAccount.UserInfo.Sickarea_id;//病区ID
                string dayWork = "";
                if (work == "白班")
                {
                    dayWork = "白班";
                }
                else
                {
                    dayWork = "晚班";
                }
                //string innertSQL = string.Format("insert into t_handovers_record(bed_no, pid," +
                //    " diagnosis_id, actiontype, remark, set_yuanwai_datetime, sid, nurse_id," +
                //    " recodertime, daywork) values({0},'{1}',{2},{3},'{4}','{5}',{6},'{7}',to_TIMESTAMP('{8}','yyyy-MM-dd'),'{9}')" +
                //    " ", bed_no, illNessNO, diagnoseName, projectID, remak, datatime, bingquID, nurse_ID, time, dayWork);

                Bifrost.WebReference.OracleParameter p_bed_no = new Bifrost.WebReference.OracleParameter();
                p_bed_no.Value = bed_no;
                p_bed_no.ParameterName = "bed_no";
                p_bed_no.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter p_pid = new Bifrost.WebReference.OracleParameter();
                p_pid.Value = illNessNO;
                p_pid.ParameterName = "pid";
                p_pid.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter p_diagnosis_id = new Bifrost.WebReference.OracleParameter();
                p_diagnosis_id.Value = diagnoseName;
                p_diagnosis_id.ParameterName = "diagnosis_id";
                p_diagnosis_id.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter p_actiontype = new Bifrost.WebReference.OracleParameter();
                p_actiontype.Value = projectID;
                p_actiontype.ParameterName = "actiontype";
                p_actiontype.OracleType = Bifrost.WebReference.OracleType.Number;

                Bifrost.WebReference.OracleParameter p_remark = new Bifrost.WebReference.OracleParameter();
                p_remark.Value = remak;
                p_remark.ParameterName = "remark";
                p_remark.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter p_set_yuanwai_datetime = new Bifrost.WebReference.OracleParameter();
                p_set_yuanwai_datetime.Value = datatime;
                p_set_yuanwai_datetime.ParameterName = "set_yuanwai_datetime";
                p_set_yuanwai_datetime.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter p_sid = new Bifrost.WebReference.OracleParameter();
                p_sid.Value = bingquID;
                p_sid.ParameterName = "sid";
                p_sid.OracleType = Bifrost.WebReference.OracleType.Number;

                Bifrost.WebReference.OracleParameter p_nurse_id = new Bifrost.WebReference.OracleParameter();
                p_nurse_id.Value = nurse_ID;
                p_nurse_id.ParameterName = "nurse_id";
                p_nurse_id.OracleType = Bifrost.WebReference.OracleType.Number;

                //Bifrost.WebReference.OracleParameter p_recodertime = new Bifrost.WebReference.OracleParameter();
                //p_recodertime.Value =time;
                //p_recodertime.ParameterName = "recodertime";
                //p_recodertime.OracleType = Bifrost.WebReference.OracleType.Timestamp;

                Bifrost.WebReference.OracleParameter p_daywork = new Bifrost.WebReference.OracleParameter();
                p_daywork.Value = dayWork;
                p_daywork.ParameterName = "daywork";
                p_daywork.OracleType = Bifrost.WebReference.OracleType.VarChar;

                Bifrost.WebReference.OracleParameter[] parameters = new Bifrost.WebReference.OracleParameter[] { 
                    p_bed_no,
                    p_pid,
                    p_diagnosis_id,
                    p_actiontype,
                    p_remark,
                    p_set_yuanwai_datetime,
                    p_sid,
                    p_nurse_id,
                   // p_recodertime,
                    p_daywork
                };
                string innertSQL = "INSERT INTO t_handovers_record(bed_no,pid,diagnoseName,actiontype, remark,set_yuanwai_datetime, sid, nurse_id,RECODERTIME, daywork)" +
                    " VALUES (:bed_no,:pid,:diagnosis_id,:actiontype, :remark,:set_yuanwai_datetime, :sid, :nurse_id,to_TIMESTAMP('" + time + "','yyyy-MM-dd HH24:mi:ss'), :daywork)";//;; SELECT @@IDENTITY;
                if (App.ExecuteSQL(innertSQL, parameters) > 0)
                {
                    App.Msg("增加成功");
                    //frmSickReport sick = new frmSickReport();
                    //sick.Show();
                    ucfsr.refreshLoad();
                    this.Close();
                }
                else
                {
                    App.Msg("增加失败");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);

            }
        }
        DataSet dsBedNO = null;
        private void SetBed_NO()
        {
            if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
            {
                //string beingSql = "select sick_bed_id,sick_bed_no,pid,patient_name from t_in_patient where sick_bed_no is not null and section_ID='" + App.UserAccount.UserInfo.Sickarea_id+ "'";
                string beingSql = " select a.id,patient_name,gender_code,birthday,a.pid,age,sick_doctor_id," +
                                            " sick_doctor_name,sick_area_id,sick_area_name,section_id," +
                                            " section_name,in_time,state,sick_bed_id,sick_bed_no,age_unit,Sick_Degree,NURSE_LEVEL,insection_id,insection_name,in_area_id,in_area_name from t_in_patient a " +
                                            " inner join t_inhospital_action b on a.id=b.pid  " +
                                            " inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                                            " where b.saID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "" +
                                         " and  b.action_state=4 and b.id in (select max(id) from t_inhospital_action group by pid) order by sick_bed_no";


                dsBedNO = App.GetDataSet(beingSql);
                ccbkbed_No.DataSource = dsBedNO.Tables[0].DefaultView;
                this.ccbkbed_No.DisplayMember = "sick_bed_no";
                ccbkbed_No.ValueMember = "sick_bed_id";

                //ccbkbed_No.SelectedIndex = 0;
            }
        }

        private void AddSickTeport_Load(object sender, EventArgs e)
        {
            SetBed_NO();
        }


        private void ccbkbed_No_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectSql = "select pid,patient_name from t_in_patient where sick_bed_no='" + ccbkbed_No.Text + "' and sick_bed_id='" + ccbkbed_No.SelectedValue + "'";
            DataSet dsName = App.GetDataSet(selectSql);

            if (dsName != null && dsName.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsName.Tables[0] as DataTable;
                //DataRow dr = dt.Rows[0];
                //dr[0].ToString();
                this.txtuserName.Text = dt.Rows[0][1].ToString();
                this.txtIllNessNO.Text = dt.Rows[0][0].ToString(); //dt.Rows[0].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cckbOutHospital_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.checkPanl.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).Text == (sender as CheckBox).Text)
                    {
                        (sender as CheckBox).Checked = (sender as CheckBox).Checked;
                        //(sender as CheckBox).Checked = (sender as CheckBox).Checked; 
                    }
                    else
                    {
                        (c as CheckBox).Checked = false;
                    }
                }
            }
        }
    }
}

