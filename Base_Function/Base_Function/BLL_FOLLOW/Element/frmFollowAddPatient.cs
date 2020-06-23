using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.DispalayList;
using System.Collections;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowAddPatient : DevComponents.DotNetBar.Office2007Form
    {
        private string Doctor = ""; //管床医生Id
        private string Diag = "";   //诊断Icd10码
        private string Oper = "";   //手术Icd9码
        private string FisrtIn = "Y";   //是否首次打开该界面
        public frmFollowAddPatient()
        {
            InitializeComponent();

            IniRelatedSchema();
        }
        /// <summary>
        /// 绑定相关科室方案
        /// </summary>
        public void IniRelatedSchema()
        {
            string UserShema = "";
            string quryStr="";
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                UserShema = App.UserAccount.CurrentSelectRole.Section_Id;
                quryStr = "select id,follow_name from T_FOLLOW_INFO where exec_sections='" + UserShema + "' or exec_sections like '" + UserShema + ",%' or exec_sections like '%," + UserShema + ",%' or exec_sections like '%," + UserShema + "' or exec_sections='0'";

            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                UserShema = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                quryStr = "select id,follow_name from T_FOLLOW_INFO where exec_sickarea='" + UserShema + "' or exec_sickarea like '" + UserShema + ",%' or exec_sickarea like '%," + UserShema + ",%' or exec_sickarea like '%," + UserShema + "'or exec_sickarea='0'";
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                UserShema = "0";
                quryStr = "select id,follow_name from T_FOLLOW_INFO where rownum<100";
            }
            DataSet ds = App.GetDataSet(quryStr);
            if (ds.Tables[0].Rows.Count != 0)
            {
                cmbFollowSchema.DataSource = ds.Tables[0].DefaultView;
                cmbFollowSchema.DisplayMember = "Follow_Name";
                cmbFollowSchema.ValueMember = "Id";
                cmbFollowSchema_SelectedIndexChanged(new object(), new EventArgs());
            }
            else
            {
                cmbFollowSchema.DataSource = null;
            }
            
        }
        /// <summary>
        /// 绑定方案相关科室
        /// </summary>
        public void IniRelatedSections()
        {
            if(cmbFollowSchema.Text!="")
            {
                string RelatedSecs = App.ReadSqlVal("select section_ids from T_FOLLOW_INFO where id=" + cmbFollowSchema.SelectedValue.ToString() + "", 0, "section_ids");
                string quryStr="";
                if (RelatedSecs == "0")
                    quryStr = "Select sid,section_name from T_SECTIONINFO ";
                else
                    quryStr = "select sid,section_name from T_SECTIONINFO where sid in (" + RelatedSecs + ")";
                
                DataSet ds=App.GetDataSet(quryStr);
                DataRow Row=ds.Tables[0].NewRow();
                Row[0] = 0;
                Row[1] = "";
                ds.Tables[0].Rows.InsertAt(Row, 0);
                if (ds.Tables[0].Rows.Count > 1)
                {
                    cmbSections.DataSource = ds.Tables[0].DefaultView;
                    cmbSections.DisplayMember = "section_name";
                    cmbSections.ValueMember = "sid";
                    cmbSections.SelectedIndex = 0;
                }
                else
                    cmbSections.DataSource = null;
            }   
        }
        /// <summary>
        /// 显示方案相关循环方式
        /// </summary>
        public void MethodOfFollow()
        {
            if (cmbFollowSchema.Text != null)
            {
                string Id = cmbFollowSchema.SelectedValue.ToString();
                string quryStr = "Select startingtime 参考时间,defaultdays 首次默认时间,followtype 随访时间类别,definefollows 随访循环天数,finishtype 随访结束方式 from T_FOLLOW_INFO where id=" + Id + "";
                DataSet ds = App.GetDataSet(quryStr);
                if (ds.Tables[0].Rows.Count != 0)
                    dgvTimeSet.DataSource = ds.Tables[0].DefaultView;
                else
                    dgvTimeSet.DataSource = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList Batch=new ArrayList();
            string Pid = "";
            string SchemaId = cmbFollowSchema.SelectedValue.ToString();
            string FollowMethod="";
            if (dgvTimeSet.Rows[0].Cells["随访时间类别"].Value.ToString() != "")
                FollowMethod = dgvTimeSet.Rows[0].Cells["随访时间类别"].Value.ToString();
            else
                FollowMethod = dgvTimeSet.Rows[0].Cells["随访循环天数"].Value.ToString();
            string Stime="";

            for (int i = 0; i < dgvPatients.Rows.Count; i++)
            {
                if (dgvPatients.Rows[i].Cells["选择"].Value != null)
                {
                    if (dgvPatients.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        if (rbtnLeaveHos.Checked)
                            Stime =Convert.ToDateTime( dgvPatients.Rows[i].Cells["出院时间"].Value.ToString()).ToShortDateString();
                        if (rbtnSetTime.Checked)
                            Stime = dtTimeSet.Value.ToShortDateString();
                        if (rbtnToday.Checked)
                            Stime = DateTime.Today.ToShortDateString();
                        Pid = dgvPatients.Rows[i].Cells["病人号"].Value.ToString();
                        string Insert = "insert into T_FOLLOW_MANUALPATIENT(patient_id,solution_id,isadd,update_time) values(" + Pid + "," + SchemaId + ",1,to_date('" + Stime + "','yyyy-MM-dd'))";
                        Batch.Add(Insert);

                    }
                }
                
            }
            if (Batch.Count != 0)
            {
                string[] SqlBatch = new string[Batch.Count];
                for (int i = 0; i < Batch.Count; i++)
                {
                    SqlBatch[i] = Batch[i].ToString();
                }
                try
                {
                    App.ExecuteBatch(SqlBatch);
                    App.Msg("病人已加入方案");
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }

        }
        public string GetSchemaExist()
        {

            string quryStr = "select patient_id from T_FOLLOW_MANUALPATIENT where solution_id=" + cmbFollowSchema.SelectedValue.ToString() + "";
            DataSet ds = App.GetDataSet(quryStr);
            string ReStr = "";
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ReStr == "")
                        ReStr = ds.Tables[0].Rows[i]["patient_id"].ToString();
                    else
                        ReStr += "," + ds.Tables[0].Rows[i]["patient_id"].ToString();
                }
                return ReStr;
            }
            else
                return "";
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int NullDs = 0;
            string quryStr="";
            string IncludeIn = GetSchemaExist();
            if(IncludeIn!="")
                quryStr = "select t.id 病人号,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit 年龄,t.section_name 科室,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE where type='E' and patient_id=t.id ) 诊断,t.now_addres_phone 电话,t.now_address 地址,t.leave_time 出院时间 from T_IN_PATIENT t  where t.id not in ("+IncludeIn+ ") and t.leave_time is not null ";
            else
                quryStr = "select t.id 病人号,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit 年龄,t.section_name 科室,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE where type='E' and patient_id=t.id ) 诊断,t.now_addres_phone 电话,t.now_address 地址,t.leave_time 出院时间 from T_IN_PATIENT t  where t.id is not null and t.leave_time is not null";
            if (txtPatient.Text != "")
                quryStr += "and t.patient_name='" + txtPatient.Text.Trim() + "' ";
            if (txtHospital.Text != "")
                quryStr += "and t.pid like '%" + txtHospital.Text.Trim() + "%' ";
            if (ckStartTime.Checked)
            {
                string Stime = dtStart.Value.ToShortDateString();
                string Etime = dtEnd.Value.ToShortDateString();
                quryStr += "and t.leave_time between to_date('" + Stime + "','yyyy-MM-dd') and to_date('" + Etime + "','yyyy-MM-dd') ";
            }
            if (Diag != "")
            {
                string Pids = "";
                string temp = "select patient_id from COVER_DIAGNOSE where icd10code='" + Diag + "'";
                DataSet diagDs = App.GetDataSet(temp);
                if (diagDs.Tables[0].Rows.Count != 0)
                    for (int i = 0; i < diagDs.Tables[0].Rows.Count; i++)
                    {
                        if (Pids == "")
                            Pids = diagDs.Tables[0].Rows[i]["patient_id"].ToString();
                        else
                            Pids += "," + diagDs.Tables[0].Rows[i]["patient_id"].ToString();
                    }
                else
                    NullDs = 1;
                        quryStr += "and t.id in (" + Pids + ") ";
            }
            if (Oper != "")
            {
                string Pids = "";
                string temp = "select patient_id from COVER_OPERATION where oper_code='" + Diag + "'";
                DataSet diagDs = App.GetDataSet(temp);
                if (diagDs.Tables[0].Rows.Count != 0)
                    for (int i = 0; i < diagDs.Tables[0].Rows.Count; i++)
                    {
                        if (Pids == "")
                            Pids = diagDs.Tables[0].Rows[i]["patient_id"].ToString();
                        else
                            Pids += "," + diagDs.Tables[0].Rows[i]["patient_id"].ToString();
                    }
                else
                    NullDs = 1;
                quryStr += "and t.id in (" + Pids + ") ";
            }
            if (Doctor != "")
                quryStr += "and t.sick_doctor_id='" + Doctor + "' ";
            if (cmbSections.Text != "")
                quryStr += "and t.section_id =" + cmbSections.SelectedValue.ToString() + "";
            DataSet ds = App.GetDataSet(quryStr);
            if (NullDs == 1)
                ds = null;
            dgvPatients.Columns.Clear();
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataGridViewCheckBoxColumn ckCol = new DataGridViewCheckBoxColumn();
                ckCol.HeaderText = "选择";
                ckCol.Name = "选择";
                dgvPatients.Columns.Add(ckCol);
                dgvPatients.DataSource = ds.Tables[0].DefaultView;
                dgvPatients.Columns["病人号"].Visible = false;
            }
            else
                dgvPatients.DataSource = null;
            this.Cursor = Cursors.Default;
        }
        #region 按钮事件
        private void cmbFollowSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FisrtIn == "N")
            {                
                MethodOfFollow();
                IniRelatedSections();
            }
            else
                FisrtIn = "N";
        }

        private void rbtnSetTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSetTime.Checked)
            {
                dtTimeSet.Enabled = true;
            }
            else
            {
                dtTimeSet.Enabled = false;
            }
        }
        /// <summary>
        /// 医生快码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDoctor.Text = row["医生"].ToString(); //textName;
                            Doctor = row["医生号"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Doctor = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 手术快码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOper_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOper.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtOper.Text = row["手术"].ToString(); //textName;
                            Oper = row["手术码"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Oper = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 诊断快码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiag.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDiag.Text = row["诊断"].ToString(); //textName;
                            Diag = row["诊断码"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Diag = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 诊断快码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiag_KeyUp(object sender, KeyEventArgs e)
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
                        if (txtDiag.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select code 诊断码,name 诊断 from DIAG_DEF_ICD10 where shortcut1 like '%" + txtDiag.Text.ToUpper() + "%' or name like '%" + txtDiag.Text + "%'";
                            App.FastCodeCheck(sql_select, txtDiag, "诊断", "诊断");
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

        private void txtOper_KeyUp(object sender, KeyEventArgs e)
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
                        if (txtOper.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select code 手术码,name 手术 from OPER_DEF_ICD9 where shortcut1 like '%" + txtOper.Text.ToLower() + "%' or name like '%" + txtOper.Text + "%'";
                            App.FastCodeCheck(sql_select, txtOper, "手术", "手术");
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

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
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
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id 医生号,user_name 医生 from T_USERINFO  where shortcut_code like '%" + txtDoctor.Text.ToUpper() + "%' or user_name like '%" + txtDoctor.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "医生", "医生");
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
        #endregion




    }
}