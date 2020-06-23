using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmCancleTurnIn : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        public frmCancleTurnIn(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            //获得当前病区的空床
            GetEmptyBed();
        }
        public frmCancleTurnIn()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 取消转出科室，把病人异动状态改为，已完成（我的科室病人），重新分配床号。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
             {
	             if (cbxBed.Text != null)
	                {
                        //找出病人的最近转出信息
                        string Sql_near_roll_out_info = "select * from t_inhospital_action where patient_id=" + inPatientInfo.Id + " order by id desc";
                        DataSet ds = App.GetDataSet(Sql_near_roll_out_info);

                        string target_said = ds.Tables[0].Rows[0]["TARGET_SAID"].ToString();
                        string target_sid = ds.Tables[0].Rows[0]["TARGET_SID"].ToString();
                        
                        //获取异动表中最后一条记录的ID
                        string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id=" + inPatientInfo.Id + "", 0, "nowid");
    	
                        //生成异动表新记录的ID
                        string New_Id = App.GenId("t_inhospital_action", "id").ToString();
    	
                        /*
                         * 新增加一条转科记录,修改最近的一条异动记录，与新增记录建立连接
                         */
                        string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                            " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                            " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + inPatientInfo.Sike_Area_Id + ",'" + inPatientInfo.Id + "'," +
                                            "'退回','2',to_timestamp('" + dtpCancle_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                            " " + inPatientInfo.Sick_Bed_Id + ",'" + inPatientInfo.Sick_Doctor_Id + "'," + App.UserAccount.Account_id + ",0," +
                                            " " + Now_Id + "," + target_said + "," + target_sid + "," + inPatientInfo.Id + ")";
    	
                        string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                        //修改住院病人当前的当前床号
                        //string Update_InPatient_Curent_sidAndArea = "update t_in_patient set SICK_BED_ID=" + cbxBed.SelectedValue.ToString() + "," +
                        //                                            "SICK_BED_NO='" + cbxBed.Text + "' where id=" + inPatientInfo.Id + "";
                        //string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + cbxBed.SelectedValue.ToString() + "";
                        string[] cmdstr = new string[2];
                        cmdstr[0] = InsertSQL;
                        cmdstr[1] = UdateOld;
                        //cmdstr[2] = Update_InPatient_Curent_sidAndArea;
                        //cmdstr[3] = UpdateBed_State;
                        int count = 0;
                        count=App.ExecuteBatch(cmdstr);
                        if (count > 0)
                        {
                            DataInit.isInAreaSucceed = true;
                            inPatientInfo.Sike_Area_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id.ToString();
                            inPatientInfo.Sick_Area_Name = App.UserAccount.CurrentSelectRole.Sickarea_name;
                            // inPatientInfo.Sick_Bed_Id = Int32.Parse(cbxBed.SelectedValue.ToString());
                            //inPatientInfo.Sick_Bed_Name = cbxBed.Text;
                            App.Msg(inPatientInfo.Patient_Name + " 已退回");
                            this.Close();
                        }
                    }
                    else
                    {
                        App.Msg("床号不能为空！");
                    }
             }
             catch (System.Exception ex)
             {
             	
             }

        }

        private void frmCancleSection_Load(object sender, EventArgs e)
        {
            if (inPatientInfo != null)
            {
                /*
                 *根据异动表的目标科室ID，病区ID，得到科室，病区的名字 
                 **/
               
                string Sql_GetName = "select a.happen_time from t_inhospital_action a"+
                                     " where a.id = (select max(id) from t_inhospital_action where pid = "+inPatientInfo.Id+")";

                DataSet ds_getName = App.GetDataSet(Sql_GetName);
                DataTable dt = ds_getName.Tables[0];

                this.lblPid.Text = inPatientInfo.PId;
                this.lblUserName.Text = inPatientInfo.Patient_Name;
                this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
                string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
                this.lblSex.Text = sex;
                this.lblInArea.Text = DataInit.sickarea_name;
                this.lblInBed_id.Text = inPatientInfo.Sick_Bed_Name;
                this.lblToAreaName.Text = inPatientInfo.Sick_Area_Name;
                this.lblToSectionName.Text = inPatientInfo.Section_Name;
                this.lblOut_Time.Text =string.Format("{0:g}",DateTime.Parse(dt.Rows[0]["happen_time"].ToString()));



            }
        }

        //private void cbxBed_MouseDown(object sender, MouseEventArgs e)
        //{
        //    GetEmptyBed();
        //}
        /// <summary>
        /// 获得空床
        /// </summary>
        private void GetEmptyBed()
        {
            /*
             * state74表示‘占有’,75表示‘未占有’
             * 查找所属科室病区所有空闲的病床
             **/

            string Select_All_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a" +
                                    " left join t_sickroominfo b on a.srid = b.srid" +
                                    " left join t_sickareainfo c on b.said = c.said" +
                                    " where a.state=75 and a.enableflag='Y' and a.said=" + inPatientInfo.Sike_Area_Id;   
            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                cbxBed.DataSource = ds.Tables[0];
                cbxBed.DisplayMember = "bed_no";
                cbxBed.ValueMember = "bed_id";
            }
        }
    }
}