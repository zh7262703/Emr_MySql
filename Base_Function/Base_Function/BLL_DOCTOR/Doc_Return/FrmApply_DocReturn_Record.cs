using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class FrmApply_DocReturn_Record : DevComponents.DotNetBar.Office2007Form
    {
        private string Sql_patient = "";
        private string Pids = "";
        private string Sick_OR_Section = "";
        UcApply_DocReturn_Record uc_Apply;
        private string ID = "";
        private string patient_id = "";
        string ApplyReason = "";  //质控评分用；

        private void FrmApply_DocReturn_Record_Load(object sender, EventArgs e)
        {
            try
            {
                btnSelect_Click(sender, e);
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ReFleshs();
            }
            catch
            {
            }
        }

        private void ReFleshs()
        {
            txtPIDs.Text = "";
            txtApplyReason.Text = "";
            txtApplicant.Text = "";
            txtSick_OR_Section.Text = "";
        }

        // =================================== Xiao Jun ==========================================

        public FrmApply_DocReturn_Record()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="apply_record">归档病历申请查询窗体的引用</param>
        public FrmApply_DocReturn_Record(UcApply_DocReturn_Record apply_record)
        {
            InitializeComponent();
            this.uc_Apply = apply_record;
            this.ucC1FlexGrid1.fg.SelectionMode = SelectionModeEnum.Row;
            Sql_patient = @"select ID as 编号,PATIENT_NAME as 病人姓名,(case GENDER_CODE when '0' then '男' else '女' end) as  性别,PID  as 住院号,to_char(in_time,'yyyy-MM-dd HH24:mi') as 入院时间,to_char(die_time,'yyyy-MM-dd HH24:mi') as 出院时间," +
                            @"SECTION_ID as 科室编号,SECTION_NAME as 科室名称,SICK_AREA_ID as 病区编号,SICK_AREA_NAME as 病区名称,sick_doctor_name as 管床医师," +
                           @" (case DOCUMENT_STATE when '1' then '已归档' else '未归档' end) as 归档状态,sick_doctor_id  from t_in_patient where  DOCUMENT_STATE='1'";
        }
        public FrmApply_DocReturn_Record(string strPid)
        {
            InitializeComponent();
            txtPid.Text = strPid;
            ApplyReason = "病历整改";
            //Sql_patient = @"select ID as 编号,PATIENT_NAME as 病人姓名,(case GENDER_CODE when '0' then '男' else '女' end) as  性别,PID  as 住院号,to_char(in_time,'yyyy-MM-dd HH24:mi') as 入院时间,to_char(die_time,'yyyy-MM-dd HH24:mi') as 出院时间," +
            //                @"SECTION_ID as 科室编号,SECTION_NAME as 科室名称,SICK_AREA_ID as 病区编号,SICK_AREA_NAME as 病区名称,sick_doctor_name as 管床医师," +
            //               @" (case DOCUMENT_STATE when '1' then '已归档' else '未归档' end) as 归档状态,sick_doctor_id  from t_in_patient where  DOCUMENT_STATE='1'";
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = txtPid.Text;
                string pname = txtPName.Text;
                if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                {
                    label4.Text = "科室: ";
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        sql += " and section_id = '" + App.UserAccount.CurrentSelectRole.Section_Id + "'";
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + "  and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != "" && pname != "")
                        {
                            sql = Sql_patient + "  and PID like '%" + pid + "%' and PATIENT_NAME like '%" + pname + "%'";
                        }
                        DataSet dst = App.GetDataSet(sql);
                        if (dst != null)
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(sql, "住院号", true, "", "");
                                ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区名称"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区名称"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["sick_doctor_id"].Visible = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                            }
                        }
                    }
                }
                else
                {
                    label4.Text = "病区: ";
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        sql += " and Sick_area_Id = '" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'";
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + " and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != "" && pname != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%' and PATIENT_NAME like '%" + pname + "%'";
                        }
                        DataSet dst = App.GetDataSet(sql);
                        if (dst != null)
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(sql, "住院号", true, "", "");
                                ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室名称"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室名称"].AllowEditing = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                            }
                        }
                    }
                }
            }
            catch
            {
            }


        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void btnCanle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// 单击赋值文本框
        /// </summary>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                        {
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室名称"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString();
                        }
                    }
                    else
                    {
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                        {
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区名称"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 提交
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string SQl = "";
                if (txtPIDs.Text.Trim() == "")
                {
                    App.Msg("病人住院号不能为空！");
                    txtPIDs.Focus();
                    return;
                }
                if (txtApplyReason.Text.Trim() == "")
                {
                    App.Msg("申请理由不能为空！");
                    txtApplyReason.Focus();
                    return;
                }
                else if (System.Text.Encoding.Default.GetBytes(txtApplyReason.Text).Length > 200)
                {
                    App.Msg("申请理由不能超过200个字符长度！");
                    txtApplyReason.Focus();
                    return;
                }
                if (txtApplicant.Text.Trim() == "")
                {

                    App.Msg("申请人不能为空！");
                    txtApplicant.Focus();
                    return;
                }
                if (txtSick_OR_Section.Text == "")
                {
                    if (label4.Text == "科室：")
                    {
                        App.Msg("科室不能为空！");
                        txtSick_OR_Section.Focus();
                        return;
                    }
                    else
                    {
                        App.Msg("病区不能为空！");
                        txtSick_OR_Section.Focus();
                        return;
                    }
                }

                //if (App.UserAccount.UserInfo.User_id != ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "sick_doctor_id"].ToString())
                //{
                //    App.MsgWaring("您并非当前选中病人的管床医生，只有管床医生才可以提交！");
                //    return;
                //}

                //if ((IsUpdateOrInsert(patient_id)))  //修改
                //{
                //    if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                //    {
                //        if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                //        {
                //            SQl = "update T_BORROW_REQ_RECORD set REQ_REMARK='" + txtApplyReason.Text + "',SECTION_ID='" + Sick_OR_Section + "',REQ_BY='" + App.UserAccount.UserInfo.User_id + "',REQ_BY_NAME='" + txtApplicant.Text + "',SECTION_NAME='" + txtSick_OR_Section.Text + "',IN_PATIENT_ID='" + txtPIDs.Text + "',REQ_BY_TIME=sysdate,STATE='未通过',state_id = 0 where PATIENT_ID='" + patient_id + "'";
                //        }
                //    }
                //    else
                //    {
                //        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                //        {
                //            SQl = "update T_BORROW_REQ_RECORD set REQ_REMARK='" + txtApplyReason.Text + "',SICKORSECTION_ID='" + Sick_OR_Section + "',REQ_BY='" + App.UserAccount.UserInfo.User_id + "',REQ_BY_NAME='" + txtApplicant.Text + "',SICKORSECTION_NAME='" + txtSick_OR_Section.Text + "',IN_PATIENT_ID='" + txtPIDs.Text + "',REQ_BY_TIME=sysdate,STATE='未通过',state_id = 0 where  PATIENT_ID='" + patient_id + "'";
                //        }
                //    }
                //}
                //else
                //{

                ID = App.GenId("T_DOC_REQ_RECORD", "ID").ToString();
                if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                {
                    if (App.UserAccount.CurrentSelectRole.Role_name!="科主任"&&App.UserAccount.UserInfo.User_id != ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "sick_doctor_id"].ToString())
                    {//医生账号对应管床医师
                        App.MsgWaring("您并非当前选中病人的管床医生，只有管床医生才可以提交！");
                        return;
                    }
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string REQ_BY_SECTION = App.UserAccount.CurrentSelectRole.Section_name;
                        if (REQ_BY_SECTION == "")
                        {
                            REQ_BY_SECTION = txtSick_OR_Section.Text;
                        }
                        SQl = "insert into T_DOC_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SECTION_ID,STATE,SECTION_NAME,PATIENT_ID,REQ_BY_SECTION) values("
                              + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','未审批','" + txtSick_OR_Section.Text + "','" + patient_id + "','" + REQ_BY_SECTION + "')";
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        string REQ_BY_SECTION = App.UserAccount.CurrentSelectRole.Sickarea_name;
                        if (REQ_BY_SECTION == "")
                        {
                            REQ_BY_SECTION = txtSick_OR_Section.Text;
                        }
                        SQl = "insert into T_DOC_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SECTION_ID,STATE,SECTION_NAME,PATIENT_ID,REQ_BY_SECTION) values("
                              + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','未审批','" + txtSick_OR_Section.Text + "','" + patient_id + "','" + REQ_BY_SECTION + "')";
                    }
                }
                // }
                if (SQl != "")
                {
                    string sqlcon = "select count(*) count from T_DOC_REQ_RECORD t where t.req_by='" + App.UserAccount.UserInfo.User_id + "' and t.state='未审批' and t.patient_id='" + patient_id + "'";
                    string count = App.ReadSqlVal(sqlcon, 0, "count");
                    if (count == "0")
                    {//该病人没有已存在并且未审批的记录.
                        int number = App.ExecuteSQL(SQl);
                        if (number > 0)
                        {
                            App.Msg("操作成功！");
                            uc_Apply.UcApply_DocReturn_Record_Load(sender, e);
                            this.Close();
                        }
                    }
                    else
                    {
                        App.Msg("提示:申请失败,您已申请过该病人退档,未审核请联系病案室退档！");
                    }

                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 决定是插入还是修改操作
        /// </summary>
        /// <param name="pid">病人pid</param>
        /// <returns></returns>
        private bool IsUpdateOrInsert(string Patient_id)
        {
            string Sql_IsUpdateOrInsert = "select count(*) as id from T_DOC_REQ_RECORD where PATIENT_ID ='" + Patient_id + "'";
            string count = App.ReadSqlVal(Sql_IsUpdateOrInsert, 0, "id");
            return Convert.ToInt32(count) > 0 ? true : false;
        }

    }
}