using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
//using Bifrost_Hospital_Management;
using Base_Function.MODEL;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class UcApply_DocReturn_Record : UserControl
    {
        #region 废弃代码
        /*
        DataSet ds;
        public UcApply_Medical_Record()
        {
            InitializeComponent();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            this.ucC1FlexGrid1.fg.SelectionMode = SelectionModeEnum.Row;
        }

        public void UcApply_Medical_Record_Load(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
            if (chkState.Checked == true)
            {
                cboState.Enabled = true;
            }
            else
            {
                cboState.Enabled = false;
            }
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmApply_Medical_Record fm = new FrmApply_Medical_Record(this);
            fm.Show();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("你是否要删除"))
                {
                    string sql = "delete from t_doc_req_record where PATIENT_ID='" + patient_id + "'";
                    App.ExecuteSQL(sql);
                    btnSelect_Click(sender, e);
                }

            }
            catch
            {
            }
        }
        private string pid = "";//住院号
        private string patient_id = "";//病人主键
        private string dataApplyTime = "";//申请时间
        private string section_0r_Sick_ID = "";//科室或病区ID
        private string section_0r_Sick_name = "";//科室或病区ID
        private string Applicant_id = "";//申请人ID
        private string Applicant_name = "";//申请人
        private string ApplyReason = "";//申请理由
        private string TS = "";
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人住院号"].ToString();
                    patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人主键"].ToString();
                    dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请时间"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString() == "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString() != "")
                        {
                            section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString();
                            section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区"].ToString();

                        }
                    }
                    else
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室"].ToString();
                    }
                    ApplyReason = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请理由"].ToString();
                    Applicant_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人编号"].ToString();
                    Applicant_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人"].ToString();
                    int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    if (rows > 0)
                    {
                        if (oldRow == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //如果不是头行
                            if (rows > 0)
                            {
                                //就改变背景色
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            int t = ucC1FlexGrid1.fg.Rows.Count;
                            if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                            {
                                if (oldRow < t)
                                {


                                    //定义上一次点击过的行还原
                                    this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                                }

                            }
                        }
                    }
                    //给上一次的行号赋值
                    oldRow = rows;
                }
            }
            catch
            {
            }
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            if (chkState.Checked == true)
            {
                cboState.Enabled = true;
            }
            else
            {
                cboState.Enabled = false;
            }
        }

        //================================== Xiao Jun ============================================

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = @"select t.ID as 编号,t.IN_PATIENT_ID as 病人住院号,p.patient_name as 病人姓名,REQ_BY as 申请人编号,
                        REQ_BY_NAME as 申请人,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as 申请时间,REQ_REMARK as 申请理由,
                        t.STATE as 状态,t.SECTION_ID as 科室编号,t.SECTION_NAME as 科室,t.SICKORSECTION_ID as 病区编号,
                        t.PATIENT_ID as 病人主键 from t_doc_req_record t inner join t_in_patient p on p.id = t.patient_id 
                        where t.SICKORSECTION_ID = '" + App.UserAccount.CurrentSelectRole.Section_Id + "'";


            try
            {
                string StarTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                string Pids = txtPid.Text.ToString();
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")//医师
                {
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string SQl = "";
                        SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + "";
                        #region  时间
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 住院号
                        if (Pids != "")
                        {
                            SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                        }
                        #endregion
                        #region 住院号和时间
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 申请状态
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='未通过'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='同意'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='拒绝'";
                            }
                        }
                        #endregion
                        #region 申请状态和住院号
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='未通过' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='同意' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='拒绝' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                                ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                            }
                        }
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")//护士长
                    {
                        string SQl = "";
                        SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
                        #region 时间
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 住院号
                        if (Pids != "")
                        {
                            SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and IN_PATIENT_ID like '%" + txtPid.Text + "%'";

                        }
                        #endregion
                        #region 时间和住院号
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "' ";

                            }
                        }
                        #endregion
                        #region 申请状态
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='未通过'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='同意'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='拒绝'";
                            }
                        }
                        #endregion
                        #region 申请状态和住院号
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='未通过' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='同意' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='拒绝' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                                ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["科室"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["科室"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
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
         * */
        #endregion

        public delegate void RefEventHandler(object sender, Child_EventArgs e);
        //浏览文书
        public event RefEventHandler browse_Book;
        private string sql_DOC_REQ_RECORD = "";
        DataSet ds;

        public UcApply_DocReturn_Record()
        {
            InitializeComponent();
            sql_DOC_REQ_RECORD = @"select t.ID as 编号,t.IN_PATIENT_ID as 病人住院号,p.patient_name as 病人姓名,t.SECTION_NAME as 病人科室,p.sick_doctor_name as 管床医师,REQ_BY as 申请人编号," +
                               @" REQ_REMARK as 申请理由,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as 申请时间,REQ_BY_NAME as 申请人,t.STATE as 状态,t.SICKORSECTION_NAME as 病区,t.SECTION_ID as 科室编号,t.SICKORSECTION_ID as 病区编号," +
                               @" t.PATIENT_ID as 病人主键 from T_DOC_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id where 1=1";
        }

        public void UcApply_DocReturn_Record_Load(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fg_DoubleClick);
                btnSelect_Click(sender, e);
                ucC1FlexGrid1.fg.SelectionMode = SelectionModeEnum.Row;

                if (chkTime.Checked == true)
                {
                    dtpStartTime.Enabled = true;
                    dtpEndTime.Enabled = true;
                }
                else
                {
                    dtpStartTime.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
                if (chkState.Checked == true)
                {
                    cboState.Enabled = true;
                }
                else
                {
                    cboState.Enabled = false;
                }
            }
            catch
            {
            }
        }

        void fg_DoubleClick(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel > 0)
            {
                string state = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "状态"].ToString();
                Child_EventArgs args = new Child_EventArgs();
                args.State = state;
                args.Id = Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人主键"].ToString());
                args.User_Id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人编号"].ToString();
                if (browse_Book != null)
                {
                    browse_Book(sender, args);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string StarTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                string Pids = txtPid.Text;
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")//医师
                {
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "'";
                        #region  时间
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 住院号
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                        }
                        #endregion
                        #region 住院号和时间
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 申请状态
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='未通过'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='同意'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='拒绝'";
                            }
                        }
                        #endregion
                        #region 申请状态和住院号
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='未通过' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='同意' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='拒绝' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                            ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病区"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病区"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
                            ucC1FlexGrid1.fg.AllowEditing = false;
                        }
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")//护士长
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'";
                        #region 时间
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region 住院号
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";

                        }
                        #endregion
                        #region 时间和住院号
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("结束时间不能小于开始时间");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "' ";

                            }
                        }
                        #endregion
                        #region 申请状态
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='未通过'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='同意'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='拒绝'";
                            }
                        }
                        #endregion
                        #region 申请状态和住院号
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='未通过' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='同意' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='拒绝' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                            ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病区"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病区"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
                            ucC1FlexGrid1.fg.AllowEditing = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.UserInfo.Profession_card == "true")
            {
                FrmApply_DocReturn_Record fm = new FrmApply_DocReturn_Record(this);
                fm.StartPosition = FormStartPosition.CenterParent;
                App.FormStytleSet(fm, false);
                fm.ShowDialog(this);
                // btnSelect_Click(sender, e);
            }
            else
            {
                App.MsgWaring("只有有资格证的医师才能操作此功能！");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    if (App.Ask("你是否要删除？"))
                    {
                        string sql = "delete from T_DOC_REQ_RECORD where id=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString() + "";
                        int i = App.ExecuteSQL(sql);
                        if (i > 0)
                        {
                            App.Msg("删除成功！");
                            btnSelect_Click(sender, e);
                        }

                    }
                }
                else
                {
                    App.Msg("您没有选择数据!");
                }
            }
            catch
            {
            }
        }
        private string pid = "";//住院号
        private string patient_id = "";//病人主键
        private string dataApplyTime = "";//申请时间
        private string section_0r_Sick_ID = "";//科室或病区ID
        private string section_0r_Sick_name = "";//科室或病区ID
        private string Applicant_id = "";//申请人ID
        private string Applicant_name = "";//申请人
        private string ApplyReason = "";//申请理由
        private string TS = "";
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人住院号"].ToString().Trim();
                    patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人主键"].ToString();
                    dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请时间"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString() == "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString() != "")
                        {
                            section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString();
                            section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人病区"].ToString();

                        }
                    }
                    else
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人科室"].ToString();
                    }
                    ApplyReason = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请理由"].ToString();
                    Applicant_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人编号"].ToString();
                    Applicant_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人"].ToString();
                    int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    if (rows > 0)
                    {
                        if (oldRow == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //如果不是头行
                            if (rows > 0)
                            {
                                //就改变背景色
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            int t = ucC1FlexGrid1.fg.Rows.Count;
                            if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                            {
                                if (oldRow < t)
                                {


                                    //定义上一次点击过的行还原
                                    this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                                }

                            }
                        }
                    }
                    //给上一次的行号赋值
                    oldRow = rows;

                }
            }
            catch
            {
            }
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            if (chkState.Checked == true)
            {
                cboState.Enabled = true;
            }
            else
            {
                cboState.Enabled = false;
            }
        }


    }
}
