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
    public partial class frmBack_Area : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;
        public frmBack_Area()
        {
            InitializeComponent();
        }
        public frmBack_Area(InPatientInfo inPatient)
        {
            InitializeComponent();
            this.inPatientInfo = inPatient;
            App.FormStytleSet(this, false);
            GetEmptyBed();
        }

        private void frmBack_Section_Load(object sender, EventArgs e)
        {
            /*
             * 获得转出的时间
             * **/
            string SqlHappenTime ="select happen_time from t_inhospital_action where id=(select max(id) "+
                                  " from t_inhospital_action where patient_id='" + inPatientInfo.Id + "')";
            string Time =string.Format("{0:g}",DateTime.Parse(App.ReadSqlVal(SqlHappenTime, 0, "happen_time")));
            this.lblInhospital_Id.Text = inPatientInfo.PId;
            this.lblAge.Text = inPatientInfo.Age.ToString()+inPatientInfo.Age_unit;
            this.lblName.Text = inPatientInfo.Patient_Name;
            string sex = DataInit.StringFormat(inPatientInfo.Gender_Code);
            this.lblSex.Text = sex;
            this.lblWard.Text = inPatientInfo.Sick_Area_Name;
            this.lblInHos_section.Text = inPatientInfo.Section_Name;
            this.lblOutArea_Time.Text = Time;
            this.lblInhospital_time.Text = string.Format("{0:g}",inPatientInfo.In_Time);
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool validate = DataInit.IsCanSure(inPatientInfo.Id.ToString(), "", "", cbxBed_Id.SelectedValue.ToString(), "出区收回");
            if (validate)
            {
                if (this.cbxBed_Id.Text != "")
                {
                    //获取异动表中最后一条记录的ID
                    string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id='" + inPatientInfo.Id + "'", 0, "nowid");

                    //生成异动表新记录的ID
                    string New_Id = App.GenId("t_inhospital_action", "id").ToString();

                    /*
                     * 新增加一条转科记录,修改最近的一条异动记录，与新增记录建立连接
                     */
                    string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                        " action_state,happen_time,operate_id,next_id,preview_id,patient_id)" +
                                        " values(" + New_Id + "," + inPatientInfo.Section_Id + "," + inPatientInfo.Sike_Area_Id + ",'" + inPatientInfo.Id + "'," +
                                        "'收回','4',sysdate," + App.UserAccount.Account_id + ",0," + Now_Id + "," + inPatientInfo.Id + ")";

                    string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                    string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + cbxBed_Id.SelectedValue.ToString() + "";
                    /*
                     * 收回成功后，修改病人当前床号。
                     * **/
                    string Update_inPat_Bed = "update t_in_patient set sick_bed_id=" + cbxBed_Id.SelectedValue.ToString() + "," +
                                              "sick_bed_no='" + cbxBed_Id.Text + "',DIE_TIME=null,LEAVE_TIME=null,DIE_FLAG=0 where id=" + inPatientInfo.Id + "";
                    string stjob = "update t_job_temp set event_type='-' where patient_id=" + inPatientInfo.Id + " and operate_type='出区' ";
                    string[] cmdstr = new string[5];
                    cmdstr[0] = InsertSQL;
                    cmdstr[1] = UdateOld;
                    cmdstr[2] = UpdateBed_State;
                    cmdstr[3] = Update_inPat_Bed;
                    cmdstr[4] = stjob;
                    App.ExecuteBatch(cmdstr);
                    DataInit.isInAreaSucceed = true;
                    inPatientInfo.Sick_Bed_Id = Convert.ToInt32(cbxBed_Id.SelectedValue);
                    inPatientInfo.Sick_Bed_Name = cbxBed_Id.Text;
                    App.Msg(inPatientInfo.Patient_Name + " 已收回");
                    Node node = new Node();
                    node.Tag = inPatientInfo as object;
                    node.Text = inPatientInfo.Patient_Name;
                    DataInit.PatientsNode.Nodes.Add(node);
                    this.Close();
                }
                else
                {
                    App.Msg("床位号不能为空！");
                }
            }
            else
            {
                App.Msg("操作失败，病人已出区或床位被占用！");
            }
        }

        /// <summary>
        /// 获得当前科室的空床
        /// </summary>
        private void GetEmptyBed()
        {

            //state74表示‘占有’,75表示‘未占有’

            string Select_All_Bed = "select distinct(a.bed_id),a.bed_no,a.bed_code from T_SICKBEDINFO a left join t_section_area b on a.said=b.said " +
                                    " where a.said = " + inPatientInfo.Sike_Area_Id +
                                    " and a.enableflag='Y'  order by length(bed_code),bed_code";                         //查找所属科室病区所有空闲的病床  order by cast(a.bed_id as number)

            DataSet ds = App.GetDataSet(Select_All_Bed);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    cbxBed_Id.DisplayMember = "bed_no";
                    cbxBed_Id.ValueMember = "bed_id";

                    cbxBed_Id.DataSource = dt;
                }
            }
        }
    }
}