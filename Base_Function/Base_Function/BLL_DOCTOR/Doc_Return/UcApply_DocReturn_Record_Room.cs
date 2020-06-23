using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class UcApply_DocReturn_Record_Room : UserControl
    {
        private string sql_DOC_REQ_RECORD = "";//归档病历查询
        DataSet ds;
        public UcApply_DocReturn_Record_Room()
        {
            InitializeComponent();
        }

        public void UcApply_DocReturn_Record_Room_Load(object sender, EventArgs e)
        {
            try
            {
                /*
                 * 初始化详细信息页
                */
                sql_DOC_REQ_RECORD = @"select t.ID as 编号,t.IN_PATIENT_ID as 病人住院号," +
                           @" p.patient_name as 病人姓名,"+
                           @" to_char(in_time, 'yyyy-MM-dd HH24:mi') as 入院时间,"+
                           @" to_char(p.die_time, 'yyyy-MM-dd HH24:mi') as 出院时间,"+
                           @" REQ_BY as 申请人编号,"+
                           @" REQ_BY_NAME as 申请人,"+
                           @" REQ_BY_SECTION as 申请科室,"+
                           @" to_char(REQ_BY_TIME, 'yyyy-MM-dd HH24:mi:ss') as 申请时间,"+
                           @" REQ_REMARK as 申请理由,"+
                           @" t.APPROVAL as 审批人,"+
                           @" t.STATE as 状态,"+
                           @" t.SECTION_ID as 科室编号,"+
                           @" t.SECTION_NAME as 科室,"+
                           @" t.SICKORSECTION_ID as 病区编号," +
                           @" t.SICKORSECTION_NAME as 病区," +
                           @" t.PATIENT_ID as 病人主键 from t_doc_req_record t inner join t_in_patient p on p.id=t.patient_id";
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                BindSection();
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

                /*
                 *初始化生成报表页
                 */
                cboStatisticType.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 绑定报表科室
        /// </summary>
        private void BindStatisticSection()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            cboSection2.DisplayMember = "section_name";
            cboSection2.ValueMember = "sid";
            cboSection2.DataSource = ds.Tables[0].DefaultView;
            cboSection2.SelectedIndex = 0;
        }
        /// <summary>
        /// 绑定科室
        /// </summary>
        private void BindSection()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            //插入默认选项
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["sid"] = 0;
                dr["section_name"] = "请选择";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboSection.DataSource = ds.Tables[0].DefaultView;
            cboSection.DisplayMember = "section_name";
            cboSection.ValueMember = "sid";
            cboSection.SelectedIndex = 0;
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
                SQl = sql_DOC_REQ_RECORD + " where 1=1 ";
                //时间
                if (chkTime.Checked == true)
                {
                    if (StarTime == EndTime)
                    {
                        SQl += " and to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("结束时间不能小于开始时间");
                        return;
                    }
                    else
                    {
                        SQl += " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //住院号
                if (Pids != "")
                {
                    SQl += " and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                }
                //时间和住院号
                if (chkTime.Checked == true && Pids != "")
                {
                    if (StarTime == EndTime)
                    {
                        SQl += " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("结束时间不能小于开始时间");
                        return;
                    }
                    else
                    {
                        SQl += " and IN_PATIENT_ID like '" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //申请状态
                if (chkState.Checked == true)
                {
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl += " and t.state='未通过'";
                    }
                    else if (cboState.SelectedIndex == 1)
                    {
                        SQl += " and t.state='同意'";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl += " and t.state='拒绝'";
                    }
                }
                //申请人
                if (chkDoctor.Checked == true)
                {
                    SQl += " and REQ_BY_NAME like '%" + txtDoctorName.Text + "%'";
                }
                if (cboSection.SelectedIndex != 0)//按科室
                {
                    SQl += " and t.section_id=" + cboSection.SelectedValue;
                }
                //if (chkState.Checked == true && Pids != "")
                //{
                //    if (cboState.SelectedIndex == 0)
                //    {
                //        SQl += " and t.state='未通过' and  IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //    else if (cboState.SelectedIndex == 1)
                //    {
                //        SQl += " and t.state='同意' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //    else if (cboState.SelectedIndex == 2)
                //    {
                //        SQl +=  " and t.state='拒绝' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //}
                //ds = App.GetDataSet(SQl);
                ds = App.GetDataSet("select 编号 from (" + SQl + ")");
                if (ds != null)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    this.ucC1FlexGrid1.DataBd(SQl, "申请时间", false, "", "");
                    //ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                    //ucC1FlexGrid1.DataBd();
                    ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["科室"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["科室"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["病区"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["病区"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["科室编号"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["科室编号"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["申请人编号"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["申请人编号"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["病人主键"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["病人主键"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                //App.MsgErr(ex.Message);
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
        private string section_0r_Sick_name = "";//科室或病区ID
        private string Applicant_id = "";//申请人ID
        private string Applicant_name = "";//申请人
        private string ApplyReason = "";//申请理由
        private string TS = "";
        int oldRow = 0;

        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel > 0)
            {
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "状态"].ToString() == "同意")
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

        private void 进行审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmApply_DocReturn_Record_Room fx = new FrmApply_DocReturn_Record_Room(this, pid, patient_id, dataApplyTime, section_0r_Sick_ID, section_0r_Sick_name, Applicant_id, Applicant_name, ApplyReason, TS, App.UserAccount.UserInfo.User_name);
                //fx.StartPosition = FormStartPosition.CenterParent;
                App.FormStytleSet(fx, false);
                fx.Show();
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

        private void 查看新增文书toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string lastTime = "";
            DataSet ds_LastTime = App.GetDataSet("select back_time from t_doc_req_history where patient_id=" + patient_id + " order by back_time desc");
            if (ds_LastTime != null)
            {
                if (ds_LastTime.Tables[0].Rows.Count > 0)
                {
                    lastTime = Convert.ToDateTime(ds_LastTime.Tables[0].Rows[0]["back_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    string patientName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人姓名"].ToString();
                    string inTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "入院时间"].ToString();
                    string sectionName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室"].ToString();

                    FrmSearchDocHistory frmHistory = new FrmSearchDocHistory(patient_id, lastTime, patientName, inTime, pid, sectionName);
                    frmHistory.StartPosition = FormStartPosition.CenterParent;
                    frmHistory.ShowDialog();
                }
                else
                {
                    App.Msg("没有数据！");
                }
            }
        }

        /// <summary>
        /// 申请人快码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDoctorName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDoctorName.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select distinct(a.user_id) as 序号,a.user_name as 姓名,g.name as 职称,m.section_name as 科室 from t_userinfo a" +
                                                " inner join t_account_user b on a.user_id=b.user_id" +
                                                " inner join t_account c on b.account_id = c.account_id" +
                                                " inner join t_acc_role d on d.account_id = c.account_id" +
                                                " inner join t_role e on e.role_id = d.role_id" +
                                                " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                                                " inner join t_data_code g on g.id=a.u_tech_post" +
                                                " inner join t_sectioninfo m on f.section_id=m.sid" +
                                                " where e.role_type='D' and UPPER(a.shortcut_code) like '" + txtDoctorName.Text.ToUpper().Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctorName, "姓名", "职称");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void chkDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoctor.Checked)
            {
                txtDoctorName.Enabled = true;
            }
            else
            {
                txtDoctorName.Enabled = false;
            }
        }

        /// <summary>
        /// 统计方式选中项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStatisticType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatisticType.SelectedIndex == 0)
            {
                cboSection2.Enabled = false;
                cboDoctor.Enabled = false;
                cboSection2.DataSource = null;
                cboDoctor.DataSource = null;
            }
            else if (cboStatisticType.SelectedIndex == 1)
            {
                cboSection2.Enabled = true;
                cboDoctor.Enabled = false;
                BindStatisticSection();//绑定生成报表页科室
                cboDoctor.DataSource = null;
            }
            else
            {
                cboSection2.Enabled = true;
                cboDoctor.Enabled = true;
                BindStatisticSection();//绑定生成报表页科室
            }
        }
        /// <summary>
        /// 科室选中项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSection2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatisticType.SelectedIndex == 2)//按医生个人统计时，加载当前科室的医生
            {
                string sql_doctor = "select user_id,user_name from t_userinfo where section_id=" + cboSection2.SelectedValue.ToString();
                DataSet ds_Doctores = App.GetDataSet(sql_doctor);
                cboDoctor.DataSource = ds_Doctores.Tables[0];
                cboDoctor.ValueMember = "user_id";
                cboDoctor.DisplayMember = "user_name";
            }
        }

        /// <summary>
        /// 病案退回率统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            string startTime = dtpStartTime2.Value.ToString("yyyy-MM-dd");//开始时间
            string endTime = dtpEndTime2.Value.ToString("yyyy-MM-dd");//结束时间
            string sql_req = "";
            //if (cboStatisticType.SelectedIndex == 0)//按全院科室
            //{
            //    sql_req = @"select distinct s.section_name 科室名称," +
            //                 " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "') 出院人数," +
            //                 " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and c.state='同意' and a.section_id=c.section_id ) 病案成功退回数,'' 退回率" +
            //                 " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id inner join t_sectioninfo s on a.section_id=s.sid "+
            //                 " where a.state='同意' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            //}
            //else if (cboStatisticType.SelectedIndex == 1)//按科室医生
            //{
            //    sql_req = "select distinct a.req_by_name 医生姓名," +
            //                " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "') 出院人数," +
            //                " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and c.state='同意' and a.section_id=c.section_id and a.req_by=c.req_by) 病案成功退回数,'' 退回率" +
            //                " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id  where a.state='同意' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'" +
            //                " and a.section_id=" + cboSection2.SelectedValue;
            //}
            //else if (cboStatisticType.SelectedIndex == 2)
            //{
            //    sql_req = "select distinct a.req_by_name 医生姓名," +
            //               " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "' and b.sick_doctor_id=a.req_by) 出院人数," +
            //               " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and  c.state='同意' and a.section_id=c.section_id and a.req_by=c.req_by) 病案成功退回数,'' 退回率" +
            //               " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id  where a.state='同意' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'" +
            //               " and a.section_id=" + cboSection2.SelectedValue + " and a.req_by=" + cboDoctor.SelectedValue;
            //}

            string sqlwhere = "and to_char(die_time, 'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            if (cboStatisticType.SelectedIndex == 0)//按全院科室
            {
                /*   没上首页,没有费用数据
                  inner join (select b.section_id,b.sick_doctor_id,count(*) 出院人数 from t_in_patient b
                              inner join convert_cost c on b.id = c.patient_id
                              where  c.total_cost > 0 and instr(b.his_id, '_') = 0
                              {0} group by b.section_id,b.sick_doctor_id) c on s.sid=c.section_id and c.sick_doctor_id=a.req_by
                 */
                sql_req = string.Format(@"select distinct s.section_name 科室名称, 出院人数, 病案成功退回数,'' 退回率
                          from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                            inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.section_id,count(*) 出院人数 from t_in_patient b
                                         where   instr(b.his_id, '_') = 0
                                         {0} group by b.section_id) c on s.sid=c.section_id
                            inner join (select c.section_id,count(*) 病案成功退回数
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = '同意' 
                                        {0} group by c.section_id) d on s.sid=d.section_id", sqlwhere);
                //where a.state='同意' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            }
            else if (cboStatisticType.SelectedIndex == 1)//按科室医生
            {
                sql_req = string.Format(@"select distinct a.req_by_name 申请医生, 出院人数, 病案成功退回数, '' 退回率
                            from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                            inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.section_id,b.sick_doctor_id,count(*) 出院人数 from t_in_patient b
                                         where instr(b.his_id, '_') = 0
                                         {0} group by b.section_id,b.sick_doctor_id) c on s.sid=c.section_id and c.sick_doctor_id=a.req_by
                            inner join (select c.section_id,c.req_by,count(*) 病案成功退回数
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = '同意' 
                                         {0} group by c.section_id,c.req_by) d on s.sid=d.section_id and d.req_by=a.req_by 
                            where a.section_id={1}", sqlwhere, cboSection2.SelectedValue);
            }
            else if (cboStatisticType.SelectedIndex == 2)
            {
                sql_req = string.Format(@"select distinct a.req_by_name 申请医生, 出院人数, 病案成功退回数, '' 退回率
                              from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                                inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.sick_doctor_id,count(*) 出院人数 from t_in_patient b
                                         where  instr(b.his_id, '_') = 0
                                         {0} group by b.sick_doctor_id) c on c.sick_doctor_id=a.req_by
                            inner join (select c.req_by,count(*) 病案成功退回数
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = '同意' 
                                         {0} group by c.req_by) d on d.req_by=a.req_by
                            where a.req_by={1}", sqlwhere, cboDoctor.SelectedValue);
            }
            DataSet ds = App.GetDataSet(sql_req);
            if (ds != null)
            {
                fg.DataSource = ds.Tables[0].DefaultView;
            }

            //插入退回率
            if (fg.Rows.Count > 1)
            {
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    double valDouble = 0.00;
                    if (Convert.ToInt32(fg[i, "出院人数"]) != 0)
                    {
                        valDouble = Convert.ToDouble(fg[i, "病案成功退回数"]) * 100 / Convert.ToDouble(fg[i, "出院人数"]);
                        fg[i, "退回率"] = valDouble.ToString("0.00") + "%";
                    }
                }
            }

        }

        private void 质控查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string patientName =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病人姓名"].ToString();
            string inTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "入院时间"].ToString();
            string sectionName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "科室"].ToString();

            FrmSearchQuality frm = new FrmSearchQuality(patient_id, patientName, inTime, pid, sectionName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnExcel2_Click(object sender, EventArgs e)
        {
            saveFileDialog2.FileName = "病案退回报表.xls";
            saveFileDialog2.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog2.FileName;
            //fg.SaveExcel(pathname);
            fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "详细信息报表.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

        }
    }
}
