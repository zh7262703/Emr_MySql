using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmUpdateDoctor : DevComponents.DotNetBar.Office2007Form
    {
        public frmUpdateDoctor()
        {
            InitializeComponent();
        }
        private InPatientInfo inPatientInfo;
        private string tng_Id;   //诊疗组id
        private string tng_Name; //诊疗组
        public frmUpdateDoctor(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            //获得当前科室的医生
            GetDoctor();
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 更换管床医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
	        if (cbxNewDoctor.Text != string.Empty)
            {
                string DoctorId = cbxNewDoctor.SelectedValue.ToString();
                string DoctorName = cbxNewDoctor.Text;
                string sql_UptSick_Doctor = " update t_in_patient set SICK_DOCTOR_ID='" + DoctorId + "'," +
                                            " SICK_DOCTOR_NAME='" + DoctorName + "' where id =" + inPatientInfo.Id + " ";

                string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPatientInfo.Id + "'", 0, "nowid");

                //生成异动表新记录的ID
                string New_Id = App.GenId("t_inhospital_action", "id").ToString();
                /*
                 * 新增加一条换管床医生记录,修改最近的一条异动记录，与新增记录建立连接
                 */
                string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                    " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                    " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + inPatientInfo.Sike_Area_Id + ",'" + inPatientInfo.Id + "'," +
                                    "'换管床医生','4',sysdate," +
                                    " " +inPatientInfo.Sick_Bed_Id+ ",'" +cbxNewDoctor.SelectedValue.ToString()+ "'," + App.UserAccount.Account_id + ",0," +
                                    " " + Now_Id + ",0,0,"+inPatientInfo.Id+")";
                
                string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                /*
                     * 修改当前病人的当前管床医生
                     * **/
                string UpdateIn_patient_doctor = "update t_in_patient set SICK_DOCTOR_ID='"+cbxNewDoctor.SelectedValue.ToString()+"'," +
                                                 " SICK_DOCTOR_NAME='" + cbxNewDoctor.Text+ "' ,"+
                                                 " Sick_Group_ID='" + tng_Id + "',Sick_Group_Name='" + tng_Name + "',IN_Treatgroup_ID='" + tng_Id + "',"+
                                                 " IN_Treatgroup_Name='" + tng_Name + "' where id =" + inPatientInfo.Id + "";

                //向质控临时表新增一条转出记录
                string strAge = string.Empty;
                if (App.IsNumeric(inPatientInfo.Age))
                {
                    strAge = inPatientInfo.Age;
                }
                string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                        " values('" + inPatientInfo.PId + "','更换管床医生',sysdate," + inPatientInfo.Id + ",'" + strAge + "')";

                string [] arr = new string[4];
                arr[0] = InsertSQL;
                arr[1] = UdateOld;
                arr[2] = UpdateIn_patient_doctor;
                arr[3] = InsertJob_Temp;
                int count =App.ExecuteBatch(arr);
                if(count>0)
                {
                    inPatientInfo.Sick_Doctor_Id = cbxNewDoctor.SelectedValue.ToString();
                    inPatientInfo.Sick_Doctor_Name = cbxNewDoctor.Text;
                    inPatientInfo.Sick_Group_Id = Convert.ToInt32(tng_Id);
                    inPatientInfo.Sick_Group_Name = tng_Name;
                    DataInit.isInAreaSucceed = true;
                    this.Close();
                }
            }
            else
            {
                App.Msg("医生不能为空！");
            }
        }
        catch (System.Exception ex)
        {
        	
        }
       }

        private void frmUpdateDoctor_Load(object sender, EventArgs e)
        {
            this.lblPid.Text = inPatientInfo.PId;
            this.lblUserName.Text = inPatientInfo.Patient_Name;
            this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            this.lblSectionName.Text = inPatientInfo.Section_Name;
            this.lblCurentArea.Text = inPatientInfo.Sick_Area_Name;
            this.lblOldDoctor.Text = inPatientInfo.Sick_Doctor_Name;
            this.lblInHospital_Time.Text =string.Format("{0:g}",inPatientInfo.In_Time);
        }

        //private void cbxNewDoctor_MouseDown(object sender, MouseEventArgs e)
        //{
        //    GetDoctor();
        //}
        /// <summary>
        /// 获得当前科室的医生(有证)
        /// </summary>
        private void GetDoctor()
        {
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + inPatientInfo.Section_Id + "' and  e.role_type='D' and a.Profession_Card='true' and a.enable='Y'";
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                DataTable dt = dsuser.Tables[0];
                if (dt != null)
                {
                    cbxNewDoctor.DisplayMember = "user_name";
                    cbxNewDoctor.ValueMember = "user_id";
                    cbxNewDoctor.DataSource = dt.DefaultView;
                }
            }
        }

        private void cbxTng_SelectedIndexChanged(object sender, EventArgs e) 
        {
            this.lblTng.Visible = false;
            this.cbxTng.Visible = false;
            if (cbxNewDoctor.Text != "" &&
                cbxNewDoctor.Text != null)
            {
                string sql = "select c.tng_id,c.tng_name  from t_account_user a" +
                             " inner join t_tng_account b on a.account_id = b.account_id" +
                             " inner join t_treatornurse_group c on b.tng_id = c.tng_id" +
                             " where a.user_id ='" + cbxNewDoctor.SelectedValue + "' and c.belongto_id='" + inPatientInfo.Section_Id + "'";
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
                    tng_Name ="";
                }
            }
        }
    }
}