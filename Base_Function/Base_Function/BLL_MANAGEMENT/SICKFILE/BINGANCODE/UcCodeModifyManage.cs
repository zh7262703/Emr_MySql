using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Base_Function.MODEL;
using Bifrost;
using Base_Function.BASE_COMMON;
using System.Linq;
//using Base_Function.BLL_DOCTOR.Doc_Modify;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE
{
    public partial class UcCodeModifyManage : UserControl
    {
        public UcCodeModifyManage()
        {
            InitializeComponent();
            this.InitData();
            this.BindControls();
            if (App.UserAccount.CurrentSelectRole.Role_type == "B")
                toolStripMenuItem2.Visible = true;//审核
            else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                撤销ToolStripMenuItem.Visible = true;
                cmbSection.Enabled = false;
            }
        }
        public bool TimeSelected { get; set; }
        public DateTime Time1 { get; set; }

        public DateTime Time2 { get; set; }

        public string PatientName { get; set; }

        public string Pid { get; set; }

        public List<EntityData> Sections { get; set; }
        public string Section_Id { get; set; }

        public List<EntityData> StatusList { get; set; }
        public string Status { get; set; }

        public DevComponents.DotNetBar.Command SearchCommand { get; set; }

        void InitData()
        {
            this.TimeSelected = false;
            this.Time1 = App.GetSystemTime();
            this.Time2 = App.GetSystemTime();

            this.Sections = new List<EntityData>();
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {//医生科室不变
                this.Sections.Add(new EntityData() { Key = "0", Data = App.UserAccount.CurrentSelectRole.Section_name });
            }
            else
            {
                this.Sections.Add(new EntityData() { Key = "0", Data = "--请选择--" });
            }
            this.Sections.AddRange(DataInit.GetAllClinicSection());
            this.Section_Id = this.Sections.FirstOrDefault().Key;

            this.StatusList = new List<EntityData>(){
                new EntityData(){Key="-1",Data="--请选择--"},
                new EntityData(){Key="0",Data="未审核"},
                new EntityData(){Key="1",Data="通过"},
                new EntityData(){Key="2",Data="未通过"}
            };
            this.Status = this.StatusList.FirstOrDefault().Key;

            this.SearchCommand = new DevComponents.DotNetBar.Command();
        }
        void BindControls()
        {
            this.chkTime.DataBindings.Add(new Binding("Checked", this, "TimeSelected"));
            this.dtpStartTime.DataBindings.Add(new Binding("Value", this, "Time1"));
            this.dtpEndTime.DataBindings.Add(new Binding("Value", this, "Time2"));

            this.cmbSection.DisplayMember = "Data";
            this.cmbSection.ValueMember = "Key";
            this.cmbSection.DataSource = this.Sections;
            this.cmbSection.DataBindings.Add(new Binding("SelectedValue", this, "Section_Id"));

            this.txtName.DataBindings.Add(new Binding("Text", this, "PatientName"));
            this.txtPid.DataBindings.Add(new Binding("Text", this, "Pid"));

            this.cmbStatus.DisplayMember = "Data";
            this.cmbStatus.ValueMember = "Key";
            this.cmbStatus.DataSource = this.StatusList;
            this.cmbStatus.DataBindings.Add(new Binding("SelectedValue", this, "Status"));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select a.id,a.patient_id 患者id, b.pid 住院号, b.patient_name 姓名,a.apply_reason 申请原因, a.apply_date 申请时间, a.doctor_id, c.user_name 申请医生, e.section_name 申请科室, decode(a.status, '0', '未审核', '1', '通过', '2', '未通过') 审核状态, d.user_name 审核者, a.audit_date 审核时间, a.validate_hours as \"有效时间/小时\", a.cancel_reason 未通过原因 from t_in_Code_modify_apply a inner join t_in_patient b on a.patient_id = b.id left join t_userinfo c on a.doctor_id = c.user_id left join t_userinfo d on a.auditor = d.user_id inner join t_sectioninfo e on e.sid = a.section_id where 1 = 1";
            if (this.TimeSelected)
            {
                sql += " and to_char(a.apply_date,'yyyy-mm-dd') between '" + this.Time1.ToString("yyyy-MM-dd") + "' and '" + this.Time2.ToString("yyyy-MM-dd") + "'";
            }
            this.Section_Id = cmbSection.SelectedValue.ToString();
            if (this.Section_Id != "0")
            {
                sql += " and a.section_id='" + this.Section_Id + "'";
            }
            if (!string.IsNullOrEmpty(this.PatientName) && this.PatientName.Trim().Length > 0)
            {
                sql += " and instr(b.patient_name,'" + this.PatientName.Trim() + "',1)>0";
            }
            if (!string.IsNullOrEmpty(this.Pid) && this.Pid.Trim().Length > 0)
            {
                sql += " and instr(b.pid,'" + this.Pid.Trim() + "',1)>0";
            }
            if (this.Status != "-1")
            {
                sql += " and a.status='" + this.Status + "'";
            }
            if (App.UserAccount.CurrentSelectRole.Role_name != "病案室主任")
            {
                sql += " and (a.auditor<>'10922782' or a.auditor is null)";
            }
            ucfg.DataBd(sql, "申请时间", "", "");
            ucfg.fg.Cols["id"].Visible = false;
            ucfg.fg.Cols["doctor_id"].Visible = false;
            ucfg.fg.Cols["申请时间"].Format = "yyyy-MM-dd HH:mm:ss";
            ucfg.fg.Cols["审核时间"].Format = "yyyy-MM-dd HH:mm:ss";
            this.ucfg.fg.AllowEditing = false;
            ucfg.fg.AutoSizeCols();
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ucfg.fg.Row >= this.ucfg.fg.Rows.Fixed)
                {
                    string id = this.ucfg.fg[this.ucfg.fg.Row, "id"].ToString();
                    string zt = this.ucfg.fg[this.ucfg.fg.Row, "审核状态"].ToString();
                    if (zt != "未审核")
                    {
                        App.Msg("申请已经审核，无需再审核");
                        return;
                    }
                    string reason = "";
                    int hours = 0;

                    DialogResult dr;
                    dr = MessageBox.Show("是否通过该条修改申请？", "审核", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        FrmHours frm = new FrmHours();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            hours = frm.Hours;
                            zt = "1";
                        }
                        else
                            return;
                    }
                    else if (dr == DialogResult.No)
                    {
                        FrmCode frm = new FrmCode("不通过原因");
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            zt = "2";
                            reason = frm.Reason;
                        }
                    }
                    else if (dr == DialogResult.Cancel)
                        return;
                    else
                        return;

                    if (zt == "1" || zt == "2")
                    {
                        string sql = "update t_in_Code_modify_apply a set a.auditor='" + App.UserAccount.UserInfo.User_id + "',audit_date=sysdate,cancel_reason='" + reason + "',a.validate_hours='" + hours.ToString() + "',a.status='" + zt + "' where a.id='" + id + "' and a.status='0'";
                        int count = App.ExecuteSQL(sql);
                        if (count > 0)
                            App.Msg("审核成功！");
                        else
                            App.Msg("审核失败！");
                        this.SearchCommand.Execute();
                        //TODO:t_in_code_information授权状态
                        string iid = App.ReadSqlVal("select iid from t_in_Code_modify_apply where id='"+ id +"'",0,"iid");
                        string sqls = "update t_in_code_information set codestate='授权' where id='" + iid + "'";
                        App.ExecuteSQL(sqls);
                        btnSearch_Click(sender, e);
                    }
                }
            }
            catch { App.Msg("审核文书修改申请出现异常"); }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ucfg.fg.Row >= this.ucfg.fg.Rows.Fixed)
                {
                    string doctor_id = this.ucfg.fg[this.ucfg.fg.Row, "doctor_id"].ToString();
                    if (doctor_id != App.UserAccount.UserInfo.User_id)
                    {
                        App.Msg("必需由申请人才能撤销申请！");
                        return;
                    }
                    string zt = this.ucfg.fg[this.ucfg.fg.Row, "审核状态"].ToString();
                    if (zt != "未审核")
                    {
                        App.Msg("申请已经审核无法撤销！");
                        return;
                    }
                    string id = this.ucfg.fg[this.ucfg.fg.Row, "id"].ToString();
                    string sql = "delete from t_in_Code_modify_apply a where a.id='" + id + "' and a.status='0'";
                    int count = App.ExecuteSQL(sql);
                    if (count > 0)
                        App.Msg("撤销成功！");
                    else
                        App.Msg("撤销失败！");
                    this.SearchCommand.Execute();
                    btnSearch_Click(sender, e);
                }
            }
            catch { App.Msg("撤销文书修改申请出现异常"); }
        }

        private void chkTime_CheckedChanged (object sender, EventArgs e)
        {
            if(chkTime.Checked)
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
        
    }
}
