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
    public partial class frmRoll_Out : DevComponents.DotNetBar.Office2007Form
    {
        public frmRoll_Out()
        {
            InitializeComponent();
        }

        InPatientInfo inptInfo;
        public frmRoll_Out(InPatientInfo inpatient)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            this.inptInfo = inpatient;
            lblPid.Text = inptInfo.PId;
            lblUserName.Text = inptInfo.Patient_Name;
            lblAge.Text = inptInfo.Age.ToString() + inptInfo.Age_unit;
            string sex = DataInit.StringFormat(inptInfo.Gender_Code);
            lblSex.Text = sex;
            lblInArea.Text = inptInfo.Sick_Area_Name;
            lblInBed_id.Text = inptInfo.Sick_Bed_Name;
            //获得科室
            GetSection();
        }

        private void frmInAction_Load(object sender, EventArgs e)
        {
            this.cbxSick_section.SelectedIndexChanged+=new EventHandler(cbxSick_section_SelectedIndexChanged);
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //转出
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!App.Ask("注意:转科前请确保该患者的所有文书是否已完成!\r\n(患者转科后病历不能被操作!)"))
            {
                return;
            }
            
            bool validate = DataInit.IsCanSure(inptInfo.Id.ToString(), cbxSick_section.SelectedValue.ToString(), "", "", "转科(转出)");
            if (validate)
            {
                try
                {
                    if (cbxSick_Area.Text != string.Empty && cbxSick_section.Text != string.Empty)
                    {
                        //获取异动表中最后一条记录的ID
                        string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where patient_id=" + inptInfo.Id + "", 0, "nowid");

                        //生成异动表新记录的ID
                        string New_Id = App.GenId("t_inhospital_action", "id").ToString();

                        /*
                         * 新增加一条转科记录,修改最近的一条异动记录，与新增记录建立连接
                         */
                        //string time = string.Format("{0:g}", dtpHappentTime.Value);
                        string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                            " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid,patient_id)" +
                                            " values(" + New_Id + "," + inptInfo.Section_Id + "," + inptInfo.Sike_Area_Id + ",'" + inptInfo.Id + "'," +
                                            "'转出','2',to_timestamp('" + dtpHappentTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                                            " " + inptInfo.Sick_Bed_Id + ",'" + inptInfo.Sick_Doctor_Id + "'," + App.UserAccount.Account_id + ",0," +
                                            " " + Now_Id + "," + cbxSick_Area.SelectedValue.ToString() + "," + cbxSick_section.SelectedValue.ToString() + "," + inptInfo.Id + ")";

                        string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                        ////向质控临时表新增一条转出记录
                        //string strAge = string.Empty;
                        //if (App.IsNumeric(inptInfo.Age))
                        //{
                        //    strAge = inptInfo.Age;
                        //}
                        //string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                        //                        " values('" + inptInfo.PId + "','转出记录',to_timestamp('" + dtpHappentTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        //                        + "','yyyy-MM-dd hh24:mi:ss')," + inptInfo.Id + ",'" + strAge + "')";

                        //把当前床号修改为空闲状态
                        string UpdateBed_State = "update t_sickbedinfo set state=75 where bed_id=" + inptInfo.Sick_Bed_Id + "";
                        ///*
                        // * 转出成功后，修改病人当前床号为空。
                        // * **/
                        //string update_inpat_bed = "update t_in_patient" +
                        //                          " set sick_bed_id=0,sick_bed_no='' where id=" +inptInfo.Id+ "";
                        string[] cmdstr = new string[3];
                        cmdstr[0] = InsertSQL;
                        cmdstr[1] = UdateOld;
                        //cmdstr[2] = InsertJob_Temp;
                        cmdstr[2] = UpdateBed_State;
                        //cmdstr[4] = update_inpat_bed;
                        try
                        {
                            if (App.ExecuteBatch(cmdstr) > 0)
                            {
                                App.Msg("提示: 转出成功!");
                            }
                        }
                        catch
                        {
                            App.Msg("提示: 转出失败!");
                        }
                        DataInit.isInAreaSucceed = true;
                        App.SenderMessage(cbxSick_section.SelectedValue.ToString(), inptInfo.Patient_Name + "转出到" + cbxSick_section.Text);
                        foreach (Node node in DataInit.PatientsNode.Nodes)
                        {
                            if (node.Name == inptInfo.Id.ToString())
                            {
                                DataInit.PatientsNode.Nodes.Remove(node);
                                break;
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        App.Msg("转出的病区或科室不能为空！", this);
                    }
                }
                catch (System.Exception ex)
                {

                }
            }
            else
            {
                App.Msg("操作失败，病人已在目标科室！");
            }
            
        }
     


        private void cbxSick_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSick_section.Text != "")
            {
                /*
                 * 根据科室查出与之关联的所有病区
                 * **/
                string SQLSECTION = "";
                if (App.CurrentHospitalId==201)//南区
                {
                    SQLSECTION = "select b.said, b.SICK_AREA_NAME from t_sickareainfo b";
                }
                else
                {
                    SQLSECTION = "select b.said, b.SICK_AREA_NAME from t_section_area a" +
                                    " inner join t_sickareainfo b on a.said=b.said" +
                                    " where a.sid=" + cbxSick_section.SelectedValue.ToString() + "";
                }
                DataSet dsSection = App.GetDataSet(SQLSECTION);
                if (dsSection != null)
                {
                    DataTable dt = dsSection.Tables[0];
                    if (dt != null)
                    {
                        cbxSick_Area.DataSource = dsSection.Tables[0];
                        cbxSick_Area.DisplayMember = "SICK_AREA_NAME";
                        cbxSick_Area.ValueMember = "said";
                    }
                }

            }
        }

        /// <summary>
        /// 获得所有科室
        /// </summary>
        private void GetSection()
        {
            /*
            * 查出所有科室，当前科室除外
            * **/
            //string SQLAREA = "select sid,SECTION_NAME from t_sectioninfo " +
            //                  " where  isbelongtobigsection='N' and not sid=" + inptInfo.Section_Id + "";

            string SQLAREA = "select a.sid,SECTION_NAME from t_sectioninfo a inner join t_section_area b on a.sid=b.sid where  isbelongtobigsection='N' and not a.sid=" + inptInfo.Section_Id + "  order by a.section_name,a.sid";

            DataSet dsArea = App.GetDataSet(SQLAREA);
            if (dsArea != null)
            {
                cbxSick_section.DisplayMember = "SECTION_NAME";
                cbxSick_section.ValueMember = "sid";
                cbxSick_section.DataSource = dsArea.Tables[0].DefaultView;

            }
            //HIS和电子病历中的病人当前科室不一致，转出时，默认选中HIS中的当前科室
            if (inptInfo.IsChangeSection == 'T')
            {
                //HIS中病人的当前科室
                string his_sectionId = App.ReadSqlVal("select his_section_id from t_turn_section where patient_id=" + inptInfo.Id, 0, "his_section_id");
                cbxSick_section.SelectedValue = his_sectionId;
            }
        }

    }
}