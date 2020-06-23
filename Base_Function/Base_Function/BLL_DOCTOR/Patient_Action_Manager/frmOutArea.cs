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

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmOutArea : DevComponents.DotNetBar.Office2007Form
    {
        public frmOutArea()
        {
            InitializeComponent();
        }
        private InPatientInfo inPatientInfo;
        public frmOutArea(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(inPatientInfo.Id.ToString(), "", "", "", "出区");
            TimeSpan ts = new TimeSpan();
            ts = Convert.ToDateTime(dtpHappen_Time.Value) - Convert.ToDateTime(inPatientInfo.In_Time);

            string daysnum = App.ReadSqlVal("select t.document_days from T_GRADE_PARAM_SHEZHI t", 0, "document_days");

            if (validate)
            {
                try
                {
                    //string time = string.Format("{0:g}", dtpHappen_Time.Value);
                    if (Convert.ToDateTime(dtpHappen_Time.Value) > inPatientInfo.In_Time)
                    {
                        //int t;
                        //if (ts.Days != 0)
                        //{
                        //     t=
                        //}
                        int days = Convert.ToInt16(daysnum);

                        //获取异动表中最后一条记录的ID
                        string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPatientInfo.Id + "'", 0, "nowid");

                        //生成异动表新记录的ID
                        string New_Id = App.GenId().ToString();//"t_inhospital_action", "id"

                        /*
                         * 新增加一条转科记录,修改最近的一条异动记录，与新增记录建立连接
                         */
                        string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                            " action_state,happen_time,operate_id,next_id,preview_id,patient_id)" +
                                            " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + inPatientInfo.Sike_Area_Id + ",'" + inPatientInfo.Id + "'," +
                                            "'出区','3',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                            " " + App.UserAccount.Account_id + ",0," + Now_Id + "," + inPatientInfo.Id + ")";

                        string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                        string UpdateBed_State = "update t_sickbedinfo set state=75 where bed_id=" + inPatientInfo.Sick_Bed_Id + "";
                        string[] cmdstr1 = null;
                        string msg = "";
                        string UpdatePatient = "";
                        string InsertJob_Temp = "";
                        string Job_Temp = "";
                        //string SQlVal = App.ReadSqlVal("select r.id from t_quality_record r where r.patient_id = " + inPatientInfo.Id + " and r.note like '%入院记录%'", 0, "ID");
                        if (chbDead.Checked)      //死亡
                        {
                            UpdatePatient = "update t_in_patient set DIE_FLAG=1,DIE_TIME=to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),LEAVE_TIME=to_timestamp('" +
                                dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),exe_document_time=to_timestamp('" + dtpHappen_Time.Value.AddDays(days).ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss') where id='" + inPatientInfo.Id + "'";
                            msg = inPatientInfo.Patient_Name + " 已死亡";
                            inPatientInfo.Die_flag = 1;
                            //向质控临时表新增一条死亡记录
                            if ((ts.Days * 24) + ts.Hours < 24)
                            {
                                Job_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                         " values('" + inPatientInfo.PId + "','24死亡',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                             + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";
                                App.ExecuteSQL(Job_Temp);
                                InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                                          " values('" + inPatientInfo.PId + "','死亡',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                              + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";
                            }
                            else
                            {
                                InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                                          " values('" + inPatientInfo.PId + "','死亡',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                              + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";
                            }
                        }
                        else
                        {
                            //向质控临时表新增一条死亡记录

                            //TimeSpan ts1 = new TimeSpan(dtpHappen_Time.Value.Ticks);
                            //TimeSpan ts2 = new TimeSpan(inPatientInfo.In_Time.Ticks);
                            //TimeSpan ts = ts1.Subtract(ts2).Duration();

                            if ((ts.Days * 24) + ts.Hours < 24)
                            {
                                Job_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                                 " values('" + inPatientInfo.PId + "','24出院',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                        + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";
                                App.ExecuteSQL(Job_Temp);
                                InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                                 " values('" + inPatientInfo.PId + "','出区',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                                                        + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";


                            }
                            else
                            {
                                InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                     " values('" + inPatientInfo.PId + "','出区',to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                            + "','yyyy-MM-dd hh24:mi:ss')," + inPatientInfo.Id + ")";

                            }
                            UpdatePatient = "update t_in_patient set DIE_FLAG=0 ,DIE_TIME=to_timestamp('" + dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),LEAVE_TIME=to_timestamp('" +
                                dtpHappen_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),exe_document_time=to_timestamp('" + dtpHappen_Time.Value.AddDays(days).ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss') where id='" + inPatientInfo.Id + "'";


                            msg = inPatientInfo.Patient_Name + " 已出院";
                            inPatientInfo.Die_flag = 0;
                        }
                        string delsql = "";
                        string c = App.ReadSqlVal("select count(*) c from t_inhospital_action where patient_id=" + inPatientInfo.Id + " and id<" + New_Id + " and next_id=0", 0, "c");
                        if (Convert.ToInt32(c) > 1)
                        {
                            //删除该病人异动表id小于New_Id,且next_id还为0的记录.
                            delsql = "delete from t_inhospital_action where patient_id=" + inPatientInfo.Id + " and id<" + New_Id + " and next_id=0";
                        }
                        cmdstr1 = new string[6];
                        cmdstr1[0] = InsertSQL;
                        cmdstr1[1] = UdateOld;
                        cmdstr1[2] = UpdateBed_State;
                        cmdstr1[3] = UpdatePatient;
                        cmdstr1[4] = InsertJob_Temp;
                        cmdstr1[5] = delsql;
                        //cmdstr1[3] = Update_inPat_Bed;
                        int count = 0;
                        count = App.ExecuteBatch(cmdstr1);
                        if (count > 0)
                        {
                            DataInit.isInAreaSucceed = true;
                            App.Msg(msg);
                            foreach (Node node in DataInit.PatientsNode.Nodes)
                            {
                                if (node.Text.Trim() == inPatientInfo.Patient_Name)
                                {
                                    DataInit.PatientsNode.Nodes.Remove(node);
                                    break;
                                }
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        App.Msg("出区时间必须大于入院时间！！！");
                    }
                }
                catch (System.Exception ex)
                {

                }            
            }
            else
            {
                App.Msg("操作失败，病人已出区！");
            }
        }

        private void frmOutArea_Load(object sender, EventArgs e)
        {
            this.lblPid.Text = inPatientInfo.PId.ToString();
            this.lblUserName.Text = inPatientInfo.Patient_Name;
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
            if (inPatientInfo.Sick_Area_Name != "")
            {
                this.lblInArea.Text = inPatientInfo.Sick_Area_Name;
            }
            else
            {
                string Sql = "select a.sick_area_name from t_sickareainfo a inner join t_in_patient b on a.said=b.sick_area_id where b.sick_area_id="+App.UserAccount.UserInfo.Sickarea_id+"";
                DataSet ds = App.GetDataSet(Sql);
                if (ds.Tables.Count>0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                        this.lblInArea.Text = dt.Rows[0]["sick_area_name"].ToString();
                }
            }
            this.lblInSid.Text = inPatientInfo.Section_Name;
            this.lblInArea_Time.Text = string.Format("{0:g}", inPatientInfo.In_Time);
        }

        private void chbDead_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDead.Checked)
            {
                lblOutArea_time.Text = "死亡时间：";
            }
            else
            {
                lblOutArea_time.Text = "出区时间：";
            }
        }
    }
}