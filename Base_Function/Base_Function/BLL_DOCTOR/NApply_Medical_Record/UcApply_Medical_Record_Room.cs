using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class UcApply_Medical_Record_Room : UserControl
    {
        private string sql_DOC_REQ_RECORD = "";//病历借阅查询
        DataSet ds;
        public UcApply_Medical_Record_Room()
        {
            try
            {
                InitializeComponent();
                //sql_DOC_REQ_RECORD = @"select t.ID as 编号,t.IN_PATIENT_ID as 病人住院号,p.patient_name as 病人姓名,REQ_BY as 申请人编号,REQ_BY_NAME as 申请人,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as 申请时间," +
                //            @" t.STATE as 状态,t.SECTION_NAME as 科室,t.SICKORSECTION_NAME as 病区,REQ_REMARK as 申请理由,t.SECTION_ID as 科室编号,t.SICKORSECTION_ID as 病区编号," +
                //            @" t.PATIENT_ID as 病人主键 from T_BORROW_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id";
                sql_DOC_REQ_RECORD = @"select t.ID as 编号," +
                                    @"t.IN_PATIENT_ID as 病人住院号," +
                                    @"p.patient_name as 病人姓名," +
                                    @"to_char(p.in_time, 'yyyy-MM-dd HH24:mi') as 入院时间," +
                                    @"to_char(p.die_time, 'yyyy-MM-dd HH24:mi') as 出院时间," +
                                    @"REQ_BY as 申请人编号," +
                                    @"REQ_BY_NAME as 申请人," +
                                    @"REQ_BY_SECTION as 申请科室," +
                                    @"to_char(REQ_BY_TIME, 'yyyy-MM-dd HH24:mi:ss') as 申请时间," +
                                    @"REQ_REMARK as 申请理由," +
                                    @"t.STATE as 状态," +
                                    @"t.APPROVAL as 审批人," +
                                    @"to_char(t.borrow_failure_time, 'yyyy-MM-dd HH24:mi:ss') as 借阅失效时间," +
                                    @"t.SECTION_ID as 科室编号," +
                                    @"t.SECTION_NAME as 科室," +
                                    @"t.SICKORSECTION_ID as 病区编号," +
                                    @"t.SICKORSECTION_NAME as 病区," +
                                    @"t.PATIENT_ID as 病人主键" +
                                    @" from T_BORROW_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id";
            }
            catch
            {
            }
        }

        public void UcApply_Medical_Record_Room_Load(object sender, EventArgs e)
        {
            try
            {
                btnSelect_Click(sender, e);
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
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
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string StarTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                string Pids = txtPid.Text;

                string SQl = "";
                SQl = sql_DOC_REQ_RECORD;// +" where t.state='未通过'";
                //时间
                if (chkTime.Checked == true)
                {
                    if (StarTime == EndTime)
                    {
                        SQl = sql_DOC_REQ_RECORD + " and to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("结束时间不能小于开始时间");
                        return;
                    }
                    else
                    {
                        SQl = sql_DOC_REQ_RECORD + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //住院号
                if (Pids != "")
                {
                    SQl = sql_DOC_REQ_RECORD + " and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                }
                //时间和住院号
                if (chkTime.Checked == true && Pids != "")
                {
                    if (StarTime == EndTime)
                    {
                        SQl = sql_DOC_REQ_RECORD + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("结束时间不能小于开始时间");
                        return;
                    }
                    else
                    {
                        SQl = sql_DOC_REQ_RECORD + " and IN_PATIENT_ID like '" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //申请状态
                if (chkState.Checked == true)
                {//状态ID：0审核中、1通过、2未通过
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='审核中'";
                    }
                    else if(cboState.SelectedIndex == 1)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='通过'";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='未通过'";
                    }
                }
                if (chkState.Checked == true && Pids != "")
                {
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='审核中' and  IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                    else if (cboState.SelectedIndex == 1)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='通过' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='未通过' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                }
                //ds = App.GetDataSet(SQl);
                //if (ds != null)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                        ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                        ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["科室"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["科室"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["病区"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["病区"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
                        ucC1FlexGrid1.fg.AllowEditing = false;
                //    }
                //}
            }
            catch
            {
            }
        }
        //private void Req_remark()
        //{
        //    if (ucC1FlexGrid1.fg.RowSel > 0)
        //    {
        //        string remark = "";
        //        for (int i = 0; i < ucC1FlexGrid1.fg.Rows.Count; i++)
        //        {

        //        }
        //    }
        //}
        private string pid = "";//住院号
        private string patient_id = "";//病人主键
        private string dataApplyTime = "";//申请时间
        private string section_0r_Sick_ID = "";//科室或病区ID
        private string section_0r_Sick_name = "";//科室或病区名称
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
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "状态"].ToString() == "通过")
                    {
                        this.进行审核ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        this.进行审核ToolStripMenuItem.Enabled = true;
                    }
                    pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人住院号"].ToString();
                    patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人主键"].ToString();
                    dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请时间"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString() == "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString() != "")
                        {
                            section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区编号"].ToString();
                            section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病区"].ToString();
                            TS = "病区";
                        }
                    }
                    else
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室编号"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室"].ToString();
                        TS = "科室";
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
                            //if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                            //{
                            //    if (oldRow < t)
                            //    {
                            //        //定义上一次点击过的行还原
                            //        this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            //    }
                            //}
                            if (oldRow > 0 && oldRow < t)
                            {
                                //定义上一次点击过的行还原
                                this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //给上一次的行号赋值
                    oldRow = rows;
                }

            }
            catch (Exception)
            {
            }
        }

        private void 进行审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {

                    FrmApply_Medical_Record_Room fx = new FrmApply_Medical_Record_Room(this, pid, patient_id, dataApplyTime, section_0r_Sick_ID, section_0r_Sick_name, Applicant_id, Applicant_name, ApplyReason, TS, App.UserAccount.UserInfo.User_name);
                    fx.ShowDialog(this);
                    //btnSelect_Click(sender, e);
                }
                else
                {
                    App.Msg("请您选中数据!");
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
