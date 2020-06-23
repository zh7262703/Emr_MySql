using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using System.Collections;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmUpdateBed : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        private bool _isEmpty;
        private int _target_Bed_Id;
        /// <summary>
        /// 目标床号id
        /// </summary>
        public int Target_Bed_Id
        {
            get { return _target_Bed_Id; }
            set { _target_Bed_Id = value; }
        }
        private string _target_Bed_No;
        /// <summary>
        /// 目标床号名称
        /// </summary>
        public string Target_Bed_No
        {
            get { return _target_Bed_No; }
            set { _target_Bed_No = value; }
        }
        /// <summary>
        /// 是否为空床
        /// </summary>
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set { _isEmpty = value; }
        }
        private DataTable dt;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inPatient">当前病人</param>
        public frmUpdateBed(InPatientInfo inPatient)
        {
            InitializeComponent();

            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            GetSickArea();
        }
        public frmUpdateBed()
        {
            InitializeComponent();
        }
        private void frmUpdateBed_Load(object sender, EventArgs e)
        {
            this.lblPid.Text = inPatientInfo.PId.ToString();
            this.lblUserName.Text = inPatientInfo.Patient_Name;
            this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
            this.txtRollBedNotes.Text = DataInit.ReturnNotes(inPatientInfo);
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            //this.lblCurentArea.Text = inPatientInfo.Sick_Area_Name;
            this.lblOldBed.Text = inPatientInfo.Sick_Bed_Name;
            this.lblInAreaTime.Text =string.Format("{0:g}",inPatientInfo.In_Time);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(inPatientInfo.Id.ToString(), "",App.UserAccount.CurrentSelectRole.Sickarea_Id, cbxNewBed.SelectedValue.ToString(), "换床");
            if (validate)
            {
                if (cbxNewBed.Text != string.Empty)
                {
                    //DataTable dt = DataInit.GetBedInfo(inPatientInfo);
                    //string bedId = cbxNewBed.SelectedValue.ToString();
                    //string state = null;
                    //if (dt != null)
                    //{
                    //    state = GetBedState(bedId, dt);
                    //}
                    string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPatientInfo.Id + "'", 0, "nowid");

                    //生成异动表新记录的ID
                    string New_Id = App.GenId("t_inhospital_action", "id").ToString();
                    /*
                     * 新增加一条换床记录,修改最近的一条异动记录，与新增记录建立连接
                     */
                    string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                        " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                        " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + cbxSickArea.SelectedValue + ",'" + inPatientInfo.Id + "'," +
                                        "'换床','4',to_timestamp('" + dtpRollBedTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                        " " + cbxNewBed.SelectedValue.ToString() + ",'" + inPatientInfo.Sick_Doctor_Id + "'," + App.UserAccount.Account_id + ",0," +
                                        " " + Now_Id + ",0,0," + inPatientInfo.Id + ")";
                    string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                    InPatientInfo inpatient = DataInit.GetInpatientInfoById(Convert.ToInt32(cbxNewBed.SelectedValue));
                    //if (state.Equals("75"))                       //75表示空床位
                    if (inpatient==null)  
                    {
                        /*
                         * 修改目标床位的状态为忙碌 74
                         */
                        string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + cbxNewBed.SelectedValue.ToString() + "";

                        /*
                         * 修改来源床位的状态为空闲 75
                         */
                        string UpdateBed_StateBySelf = "update t_sickbedinfo set state=75 where bed_id=" + inPatientInfo.Sick_Bed_Id + "";

                        /*
                         * 修改当前病人的当前床位号和床位编号
                         */
                        string UpdateIn_patient = "update t_in_patient set sick_bed_id=" + cbxNewBed.SelectedValue.ToString() + "," +
                                                  " sick_bed_no='" + cbxNewBed.Text + "',sick_area_id="+cbxSickArea.SelectedValue+",sick_area_name='"+cbxSickArea.Text+"' where id =" + inPatientInfo.Id + "";

                        string[] arr = new string[5];
                        arr[0] = InsertSQL;
                        arr[1] = UdateOld;
                        arr[2] = UpdateBed_State;
                        arr[3] = UpdateBed_StateBySelf;
                        arr[4] = UpdateIn_patient;
                        
                        int count = 0;
                        count = App.ExecuteBatch(arr);
                        if (count > 0)
                        {
                            this.IsEmpty = true;
                            //Bed_Id = inPatientInfo.Sick_Bed_Id;
                            //Bed_No = inPatientInfo.Sick_Bed_Name;
                            //inPatientInfo.Sick_Bed_Id = Convert.ToInt32(cbxNewBed.SelectedValue);
                            //inPatientInfo.Sick_Bed_Name = cbxNewBed.Text;
                            Target_Bed_Id = Convert.ToInt32(cbxNewBed.SelectedValue);
                            Target_Bed_No = cbxNewBed.Text;
                            DataInit.isInAreaSucceed = true;
                            App.Msg("提示: 换床成功!");
                        }
                    }
                    else
                    {
                       
                        if (inpatient != null)
                        {
                            DialogResult dialog = MessageBox.Show("此床上有病人是否继续？", "提示", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.Yes)
                            {
                                //根据目标床号，得到目标床位上的病人信息。


                                string Target_Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inpatient.Id + "'", 0, "nowid");
                                int Target_Id = Convert.ToInt32(New_Id) +1;
                                //生成异动表新记录的ID
                                // string Target_New_Id = App.GenId("t_inhospital_action", "id").ToString();

                                /*
                                 * 修改来源床位
                                 */
                                string UpdateIn_patientFrom = "update t_in_patient set sick_bed_id=" + cbxNewBed.SelectedValue.ToString() + ", sick_bed_no='" + cbxNewBed.Text +
                                                              "',sick_area_id=" + cbxSickArea.SelectedValue + ",sick_area_name='" + cbxSickArea.Text + "' where id =" + inPatientInfo.Id + "";
                                /*
                                 * 修改目标床位
                                 */
                                string UpdateIn_patientTo = "update t_in_patient set sick_bed_id=" + inPatientInfo.Sick_Bed_Id + ",sick_bed_no ='" + inPatientInfo.Sick_Bed_Name + "'" +
                                                           ",sick_area_id=" + inPatientInfo.Sike_Area_Id+ ",sick_area_name='" + inPatientInfo.Sick_Area_Name + "' where id =" + inpatient.Id + "";

                                /*
                                 * 目标床位病人向异动表里面插一条异动信息
                                 */
                                string InsertSQL_Target = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                            " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                            " values(" + Target_Id + "," + inpatient.Section_Id + "," + inpatient.Sike_Area_Id + ",'" + inpatient.Id + "'," +
                                            "'换床','4',to_timestamp('" + dtpRollBedTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                            " " + inPatientInfo.Sick_Bed_Id + ",'" + inpatient.Sick_Doctor_Id + "'," + App.UserAccount.Account_id + ",0," +
                                            " " + Target_Now_Id + ",0,0," + inpatient.Id + ")";
                                string Target_UdateOld = "update t_inhospital_action set next_id=" + Target_Id + " where id=" + Target_Now_Id + "";
                                string[] arr = new string[6];
                                arr[0] = InsertSQL;
                                arr[1] = UdateOld;
                                arr[2] = UpdateIn_patientFrom;
                                arr[3] = UpdateIn_patientTo;
                                arr[4] = InsertSQL_Target;
                                arr[5] = Target_UdateOld;

                                int count = 0;
                                count = App.ExecuteBatch(arr);
                                if (count > 0)
                                {
                                    this.IsEmpty = false;
                                    Target_Bed_Id = Convert.ToInt32(cbxNewBed.SelectedValue);
                                    Target_Bed_No = cbxNewBed.Text;
                                    //Bed_Id = inPatientInfo.Sick_Bed_Id;
                                    //Bed_No = inPatientInfo.Sick_Bed_Name;
                                    //inPatientInfo.Sick_Bed_Id = Int32.Parse(cbxNewBed.SelectedValue.ToString());
                                    //inPatientInfo.Sick_Bed_Name = cbxNewBed.Text;
                                    DataInit.isInAreaSucceed = true;
                                    App.Msg("提示: 换床成功!");
                                }
                                ////修改目标病人的当期床号
                                //DataInit.RefCardBySection(DataInit.PatientsNode.Nodes, id, inPatientInfo);
                            }
                        }
                        //App.Msg("目标床位已有人,现阶段不支持互换操作！");
                    }
                    this.Close();
                }
                else
                {
                    App.Msg("床号不能为空！");
                }
            }
            else
            {
                App.Msg("操作失败，不是在院病人或已经出区！");
            }
        }
        /// <summary>
        /// 根据床号，得到该床位的状态.
        /// </summary>
        /// <returns></returns>
        public static string GetBedState(string bedId,DataTable dt)
        {
            string str = string.Empty;
            DataRow[] rws = dt.Select("bed_id=" + bedId + "");
            //rws[0]["bed_id"]

            if (rws.Length > 0)
            {
                str = rws[0]["state"].ToString();
            }
            //for (int i = 0; i < dt.Rows.Count;i++ )
            //{
            //    if (dt.Rows[i]["bed_id"].ToString().Equals(bedId))
            //    {
            //        str=dt.Rows[i]["state"].ToString();
            //        break;
            //    }
            //    str = null;
            //}
            return str;
        }

        /// <summary>
        /// 获得当前科室的空床
        /// </summary>
        private void GetEmptyBed()
        {
            //state74表示‘占有’,75表示‘未占有’

            string Select_All_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a" +
                                   // " left join t_sickroominfo b on a.srid = b.srid" +
                                    //" left join t_sickareainfo c on b.said = c.said" +
                                    " where a.bed_id!="+inPatientInfo.Sick_Bed_Id+""+
                                    " and a.said=" + inPatientInfo.Sike_Area_Id;                      //查找所属科室病区所有空闲的病床

            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxNewBed.DisplayMember = "bed_no";
                    cbxNewBed.ValueMember = "bed_id";
                    cbxNewBed.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// 绑定病区
        /// </summary>
        private void GetSickArea()
        {
            string sql_sickarea = "select said,sick_area_name from t_sickareainfo ";
            DataSet ds = App.GetDataSet(sql_sickarea);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxSickArea.DisplayMember = "sick_area_name";
                    cbxSickArea.ValueMember = "said";
                    cbxSickArea.DataSource = dt;

                    cbxSickArea.SelectedValue = inPatientInfo.Sike_Area_Id;
                    if (App.CurrentHospitalId != 201)//南区禁用病区下拉菜单
                    {
                        cbxSickArea.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 根据病区加载床号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSickArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //state74表示‘占有’,75表示‘未占有’

            string Select_All_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a" +
                                    //" left join t_sickroominfo b on a.srid = b.srid" +
                                    //" left join t_sickareainfo c on b.said = c.said" +
                                    " where a.bed_id!=" + inPatientInfo.Sick_Bed_Id + "" +
                                    //" where a.bed_id!=(select sick_bed_id from t_in_patient where id= " + inPatientInfo.Id + ")" +
                                    " and a.enableflag='Y' and a.said=" + cbxSickArea.SelectedValue.ToString() + " order by length(a.bed_no),a.bed_no";// " order by a.bed_no asc";//查找所属科室病区所有空闲的病床

            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxNewBed.DisplayMember = "bed_no";
                    cbxNewBed.ValueMember = "bed_id";
                    cbxNewBed.DataSource = dt;
                }
            }
        }

    }
}