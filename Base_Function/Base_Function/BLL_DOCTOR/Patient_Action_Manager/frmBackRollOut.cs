using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmBackRollOut : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        public frmBackRollOut(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            //获得当前病区的空床
            GetEmptyBed();
        }
        public frmBackRollOut()
        {
            InitializeComponent();
            
        }
        private void frmBackRollOut_Load(object sender, EventArgs e)
        {
            string SectionName=null;
            string ArreaName = null;
            if (DataInit.GetTargetSName(inPatientInfo).Rows.Count>0)
            {
                SectionName =Convert.ToString(DataInit.GetTargetSName(inPatientInfo).Rows[0]["section_name"]);
                ArreaName = DataInit.GetTargetSName(inPatientInfo).Rows[0]["sick_area_name"].ToString();
            }
            else
            {
                return;
            }
            /*
            * 获得转出的时间
            * **/
            string SqlHappenTime = "select happen_time from t_inhospital_action where id=(select max(id) " +
                                  " from t_inhospital_action where pid='" + inPatientInfo.Id + "')";
            string Time =string.Format("{0:g}",DateTime.Parse(App.ReadSqlVal(SqlHappenTime, 0, "happen_time")));
            this.lblInhospital_Id.Text = inPatientInfo.PId;
            this.lblAge.Text = inPatientInfo.Age.ToString() + inPatientInfo.Age_unit;
            this.lblName.Text = inPatientInfo.Patient_Name;
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            this.lblWard.Text = inPatientInfo.Sick_Area_Name;
            this.lblOutTime.Text = Time;
            this.lblRollOut_section.Text = SectionName;
            this.lblRoll_out_Area.Text = ArreaName;
            this.lblSickBed.Text = inPatientInfo.Sick_Bed_Name;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(inPatientInfo.Id.ToString(), "", "", cbxNewBed_Id.SelectedValue.ToString(), "转科收回");
            if (validate)
            {
                try
                {
                    string state = DataInit.GetState(inPatientInfo);
                    if (state.Equals("2"))
                    {
                        //获取异动表中最后一条记录的ID
                        string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPatientInfo.Id + "'", 0, "nowid");

                        //生成异动表新记录的ID
                        string New_Id = App.GenId("t_inhospital_action", "id").ToString();

                        /*
                         * 新增加一条取消转科记录,修改最近的一条异动记录，与新增记录建立连接
                         */
                        string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                            " action_state,happen_time,operate_id,next_id,preview_id,patient_id)" +
                                            " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + inPatientInfo.Sike_Area_Id + ",'" + inPatientInfo.Id + "'," +
                                            "'取消转科','4',to_timestamp('" + dtpCancel_time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')," + App.UserAccount.Account_id + ",0," + Now_Id + "," + inPatientInfo.Id + ")";

                        string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";

                        string[] cmdstr = null;
                        if (cbxNewBed_Id.Text != null && cbxNewBed_Id.Text != "")
                        {
                            cmdstr = new string[4];
                            // 修改病人原来的床号为忙碌状态
                            string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + cbxNewBed_Id.SelectedValue.ToString() + "";
                            /*
                             * 取消转出成功后，修改病人当前床号。
                             * **/
                            string Update_inPat_Bed = "update t_in_patient set sick_bed_id=" + cbxNewBed_Id.SelectedValue.ToString() + "," +
                                                      "sick_bed_no='" + cbxNewBed_Id.Text + "' where id=" + inPatientInfo.Id + "";
                            cmdstr[0] = InsertSQL;
                            cmdstr[1] = UdateOld;
                            cmdstr[2] = UpdateBed_State;
                            cmdstr[3] = Update_inPat_Bed;
                            //cmdstr[4] = Update_Inpatient_Old_BedState;
                            inPatientInfo.Sick_Bed_Id = Int32.Parse(cbxNewBed_Id.SelectedValue.ToString());
                            inPatientInfo.Sick_Bed_Name = cbxNewBed_Id.Text;
                        }
                        else
                        {
                            App.Msg("请您选择床号！");
                            return;
                            //cmdstr = new string[2];
                            //cmdstr[0] = InsertSQL;
                            //cmdstr[1] = UdateOld;
                        }
                        int count = App.ExecuteBatch(cmdstr);
                        if (count > 0)
                        {
                            DataInit.isInAreaSucceed = true;
                            App.Msg(inPatientInfo.Patient_Name + " 已取消转出");
                            Node node = new Node();
                            node.Tag = inPatientInfo as object;
                            node.Text = inPatientInfo.Patient_Name;
                            DataInit.PatientsNode.Nodes.Add(node);
                            this.Close();
                        }
                    }
                }
                catch (System.Exception ex)
                {

                } 
            }
            else
            {
                App.Msg("操作失败，病人已转科或床位被占用！");
            }
        }


        /// <summary>
        /// 获得当前科室的空床
        /// </summary>
        private void GetEmptyBed()
        {
            cbxNewBed_Id.DataSource = null;

            //state74表示‘占有’,75表示‘未占有’

            //cbxBed_Id.Items.Insert(0, "请选择床号");
            /*
             * 查找当前病人所属科室病区所有空闲的病床
             * **/
            string Select_All_Bed = "select a.bed_id,a.bed_no,a.bed_code from t_sickbedinfo a" +
                                    " left join t_sickroominfo b on a.srid = b.srid" +
                                    " left join t_sickareainfo c on b.said = c.said" +
                                    " where a.state=75 and a.enableflag='Y' and a.said=" + inPatientInfo.Sike_Area_Id+
                                    "  order by a.bed_no";                           //查找所属病区所有空闲的病床

            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxNewBed_Id.DisplayMember = "bed_no";
                    cbxNewBed_Id.ValueMember = "bed_id";

                    cbxNewBed_Id.DataSource = dt;
                }
            }
        }
    }
}