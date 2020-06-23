using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using System.Diagnostics;

namespace Base_Function.BLL_DOCTOR.HandoverRecord
{
    public partial class UcHandoverRecord : UserControl
    {
        /// <summary>
        /// 交接班记录
        /// </summary>
        public UcHandoverRecord()
        {
            InitializeComponent();
            rDay.Checked = true;
        }

        string SectionId = string.Empty;

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnHanoverSet_Click(object sender, EventArgs e)
        {
            FrmSetSectionHandoverTimePoint frm = new FrmSetSectionHandoverTimePoint();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.btnRefresh.Enabled = IsCanRefresh();
            }
        }

        string handovertype = string.Empty;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsSetTime())
            {
                App.Msg("请先点击“班次设置”设置班次！");
                return;
            }
            ShowData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {  
            string senderdoctor = cmbSendDoctor.Text;
            string recieverdoctor = cmbRecieveDoctor.Text;
            if (rDay.Checked)
            {
                senderdoctor += "(白班)";
                recieverdoctor += "(夜班)";
            }
            else
            {
                senderdoctor += "(夜班)";
                recieverdoctor += "(白班)";
            }
            DateTime handovertime = dtphandovertime.Value;
            DataTable counttable = new DataTable();
            counttable.Columns.Add();
            counttable.Columns.Add();
            DataRow row;
            row = counttable.NewRow();
            row[0] = "原有病人数:";
            row[1] = txtoldPatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "入院人数:";
            row[1] = txtInpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "出院人数:";
            row[1] = txtoutpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "死亡人数:";
            row[1] =txtdeadpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "危重人数:";
            row[1] = txtcrititalpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "现有病人数:";
            row[1] = txtnowpatients.Text;
            counttable.Rows.Add(row);

            string title = "主要记事、病危病人情况及注意事项";

            DataTable table = detailtable.Copy();
            table.Columns.Remove("handoverid");
            table.Columns.Remove("patientid");

            string filename=string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "交接班记录.xls";
            sfd.Filter = "Excel工作簿(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                exportExcel(counttable, table, filename, title, senderdoctor, recieverdoctor, handovertime);
            }
        }

        private void rDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rDay.Checked)
            {
                handovertype = "1";
            }
            else if (rNight.Checked)
            {
                handovertype = "2";
            }
            rDay2.Checked = rDay.Checked;
            rDay3.Checked = rNight.Checked;
            rNight2.Checked = rNight.Checked;
            rNight3.Checked = rDay.Checked;
        }

        bool IsRecord = false;

        private void UcHandoverRecord_Load(object sender, EventArgs e)
        {
            this.SectionId = App.UserAccount.CurrentSelectRole.Section_Id;
            this.labSection.Text = App.UserAccount.CurrentSelectRole.Section_name;
            this.btnRefresh.Enabled = IsCanRefresh();
            btnSearch_Click(null, null);
        }

        DataTable detailtable = null;

        void ShowData()
        {
            string Sql = " select * from t_handoverrecord a where a.sectionid='" + SectionId + "' and to_char(a.handoverdate,'yyyy-mm-dd')='" + date.Value.ToString("yyyy-MM-dd") + "' and a.type='" + handovertype + "'";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            string handoverid = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                handoverid = row["id"].ToString();
                txtoldPatients.Text = row["oldpatients"].ToString();
                txtInpatients.Text = row["inpatients"].ToString();
                txtoutpatients.Text = row["outpatients"].ToString();
                txtdeadpatients.Text = row["deadpatients"].ToString();
                if (txtcrititalpatients.Text.Length == 0)
                {
                    txtcrititalpatients.Text = "0";
                }
                txtnowpatients.Text = row["nowpatients"].ToString();
            }
            else
            {
                RefreshCount();
            }
            if (!string.IsNullOrEmpty(handoverid))
            {
                Sql = " select b.handoverid,a.id patientid,a.pid 住院号,a.patient_name 患者姓名,decode(a.gender_code,0,'男',1,'女') 性别,a.age||a.age_unit 年龄,to_char(a.in_time,'yyyy-mm-dd hh24:mi') 入院时间";
                Sql += ",b.chiefcomplaint 主诉,b.diagnose 诊断,b.diagnosisbasis 诊断依据,b.plan 诊疗计划 from t_in_patient a inner join t_handoverdetailrecord b ";
                Sql += " on a.id=b.patientid where b.handoverid='" + handoverid + "' order by b.id asc";
                detailtable = App.GetDataSet(Sql).Tables[0];
            }
            else
            {
                Sql = " select '' handoverid,a.id patientid,a.pid 住院号,a.patient_name 患者姓名,decode(a.gender_code,0,'男',1,'女') 性别,a.age||a.age_unit 年龄,to_char(a.in_time,'yyyy-mm-dd hh24:mi') 入院时间";
                Sql += ",'' 主诉,'' 诊断,'' 诊断依据,'' 诊疗计划 from t_in_patient a ";
                Sql += " where to_char(a.in_time,'yyyy-mm-dd hh24:mi') between '" + starttime.ToString("yyyy-MM-dd HH:mm") + "' and '" + endtime.ToString("yyyy-MM-dd HH:mm") + "' and a.section_id='" + SectionId + "' order by a.sick_bed_no";
                detailtable = App.GetDataSet(Sql).Tables[0];
                foreach (DataRow row in detailtable.Rows)
                {
                    DataRow obj = row;
                    GetPatientInfo(ref obj);
                }
            }
            this.fg.AutoSizeRows();
            this.fg.AutoSizeCols();
            this.fg.DataSource = detailtable.DefaultView;
            this.fg.Cols["handoverid"].Visible = false;
            this.fg.Cols["patientid"].Visible = false;
            this.fg.Cols["住院号"].AllowEditing = false;
            this.fg.Cols["患者姓名"].AllowEditing = false;
            this.fg.Cols["性别"].AllowEditing = false;
            this.fg.Cols["入院时间"].AllowEditing = false;

            this.fg.Cols["主诉"].Width = 200;
            this.fg.Cols["诊断"].Width = 200;
            this.fg.Cols["诊断依据"].Width = 300;
            this.fg.Cols["诊疗计划"].Width = 300;

            //this.fg.Cols["诊断依据"].StyleNew.WordWrap = true;
            //this.fg.Cols["主诉"].StyleNew.WordWrap=true;
            //this.fg.AutoSizeCols();
            //this.fg.AutoSizeRows();
            for (int i = this.fg.Rows.Fixed; i < this.fg.Rows.Count; i++)
            {
                this.fg.Rows[i].Height = GetHeight(detailtable.Rows[i - this.fg.Rows.Fixed]);
            } 
            this.fg.Cols["主诉"].StyleNew.WordWrap = true;
            this.fg.Cols["诊断"].StyleNew.WordWrap = true;
            this.fg.Cols["诊断依据"].StyleNew.WordWrap = true;
            this.fg.Cols["诊疗计划"].StyleNew.WordWrap = true;
        }

        int GetHeight(DataRow row)
        {
            int height = 30;
            int h = height;
            h = Math.Max(h, GetHeight(row["主诉"].ToString(), height, "主诉"));
            h = Math.Max(h, GetHeight(row["诊断"].ToString(), height, "诊断"));
            h = Math.Max(h, GetHeight(row["诊断依据"].ToString(), height, "诊断依据"));
            h = Math.Max(h, GetHeight(row["诊疗计划"].ToString(), height, "诊疗计划"));
            return h;
        }

        int GetHeight(string text, int h,string colname)
        {
            using (Graphics g = fg.CreateGraphics())
            {
                StringFormat sf = new StringFormat();
                int wid = fg.Cols[colname].WidthDisplay;
                SizeF sz = g.MeasureString(text, fg.Font, wid, sf);
                h = (int)sz.Height;
            }
            return h;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshCount();
        }

        void GetPatientInfo(ref DataRow row)
        {
            string patientid = row["patientid"].ToString();
            if (string.IsNullOrEmpty(patientid))
                return;
            XmlDocument doc = GetPatientFirstRecord(patientid);
            XmlNodeList nodedelete = doc.GetElementsByTagName("span");
            for (int i = 0; i < nodedelete.Count; i++)
            {
                XmlNode node = nodedelete[i];
                try
                {
                    XmlAttribute obj = node.Attributes["deleter"];
                    if (obj != null)
                    {
                        node.ParentNode.RemoveChild(node);
                        i--;
                    }
                }
                catch { continue; }
            }
            nodedelete = doc.GetElementsByTagName("input");
            for (int i = 0; i < nodedelete.Count; i++)
            {
                XmlNode node = nodedelete[i];
                try
                {
                    XmlAttribute obj = node.Attributes["deleter"];
                    if (obj != null)
                    {
                        node.ParentNode.RemoveChild(node);
                        i--;
                    }
                }
                catch { continue; }
            }
            XmlNodeList nodelist = doc.GetElementsByTagName("div");
            foreach (XmlNode node in nodelist)
            {
                string nodetitle = string.Empty;
                try
                {
                    nodetitle = node.Attributes["title"].Value.ToString();
                }
                catch { }
                if (string.IsNullOrEmpty(nodetitle))
                {
                    continue;
                }
                if (nodetitle.Contains("初步诊断"))
                {
                    row["诊断"] = node.InnerText;
                    continue;
                }
                else if (nodetitle.Contains("诊断依据"))
                {
                    row["诊断依据"] = node.InnerText;
                    continue;
                }
                else if (nodetitle.Contains("诊疗计划"))
                {
                    row["诊疗计划"] = node.InnerText;
                    continue;
                }
                else
                {
                    continue;
                }
            }
            nodelist = doc.GetElementsByTagName("input");
            foreach (XmlNode node in nodelist)
            {
                string nodename = string.Empty;
                try
                {
                    nodename = node.Attributes["name"].Value.ToString();
                }
                catch { }
                if (string.IsNullOrEmpty(nodename))
                {
                    continue;
                }
                if (nodename.Equals("主诉"))
                {
                    row["主诉"] = node.InnerText;
                    continue;
                }
                else
                {
                    continue;
                }
            }
        }

        //获取患者首程记录
        XmlDocument GetPatientFirstRecord(string patientid)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            string Sql = " select tid from t_patients_doc a where a.textkind_id='125' and a.patient_id='" + patientid + "'";
            string tid = App.ReadSqlVal(Sql, 0, "tid");
            if (!string.IsNullOrEmpty(tid))
            {
                string strXml = App.DownLoadFtpPatientDoc(tid + ".xml", patientid);
                if (!string.IsNullOrEmpty(strXml))
                {
                    doc.LoadXml(strXml);
                }
            }
            return doc;
        }

        /// <summary>
        /// 刷新统计结果
        /// </summary>
        void RefreshCount()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(" select ");
            sBuilder.Append(" sum(case when a.in_time<to_date('" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.leave_time is null then 1 else 0 end) oldpatients");
            sBuilder.Append(",sum(case when a.in_time>=to_date('" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.in_time<=to_date('" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') then 1 else 0 end) inpatients");
            sBuilder.Append(",sum(case when a.leave_time>=to_date('" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.leave_time<=to_date('" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') then 1 else 0 end) outpatients");
            sBuilder.Append(",sum(case when a.leave_time>=to_date('" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.leave_time<=to_date('" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.die_flag='1' then 1 else 0 end) deadpatients");
            //sBuilder.Append(",sum(case when a.in_time>=to_date('" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.in_time<=to_date('" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.leave_time is null then 1 else 0 end) nowpatients");
            sBuilder.Append(",sum(case when a.in_time<=to_date('" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') and a.leave_time is null then 1 else 0 end) nowpatients");
            sBuilder.Append(" from t_in_patient a group by a.section_id having a.section_id='" + SectionId + "'");
            DataTable table = App.GetDataSet(sBuilder.ToString()).Tables[0];
            if (table != null && table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                txtoldPatients.Text = row["oldpatients"].ToString();
                txtInpatients.Text = row["inpatients"].ToString();
                txtoutpatients.Text = row["outpatients"].ToString();
                txtdeadpatients.Text = row["deadpatients"].ToString();
                if (txtcrititalpatients.Text.Length == 0)
                {
                    txtcrititalpatients.Text = "0";
                }
                txtnowpatients.Text = row["nowpatients"].ToString();
            }
        }
        DateTime starttime;
        DateTime endtime;
        bool IsCanRefresh()
        {
            bool b = false;
            DateTime CurTime = App.GetSystemTime();
            SetValidatedTime();
            TimeSpan ts = CurTime - starttime;
            TimeSpan ts2 = endtime - CurTime;
            if (ts.Seconds >= 0 && ts2.Seconds >= 0)
            {
                b = true;
            }
            return b;
        }

        bool IsSetTime()
        {
            bool b = false;
            string Sql = "select Count(*) num from t_sectionhandovertimepoint a where a.sectionid='" + SectionId + "'";
            if (App.ReadSqlVal(Sql, 0, "num").Equals("0"))
            {
                b = false;
            }
            else
            {
                b = true;
            }
            return b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Sqls = new List<string>();
            string Sql = " select * from t_handoverrecord a where a.sectionid='" + SectionId + "' and to_char(a.handoverdate,'yyyy-mm-dd')='" + date.Value.ToString("yyyy-MM-dd") + "' and a.type='" + handovertype + "'";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            string handoverid = string.Empty;
            int criticalpatients = 0;
            int oldpatients = 0;
            int inpatients = 0;
            int outpatients = 0;
            int deadpatients = 0;
            int nowpatients = 0;
            string senderid = string.Empty;
            string recieverid = string.Empty;
            string recorderid = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                handoverid = table.Rows[0]["id"].ToString();
            }
            if (this.cmbSendDoctor.SelectedIndex > 0)
            {
                senderid = cmbSendDoctor.SelectedValue.ToString();
            }
            else
            {
                App.Msg("请选择交班医师！");
                return;
            }
            if (this.cmbRecieveDoctor.SelectedIndex > 0)
            {
                recieverid = cmbRecieveDoctor.SelectedValue.ToString();
            }
            else
            {
                App.Msg("请选择接班医师！");
                return;
            }
            recorderid = App.UserAccount.UserInfo.User_id.ToString();
            if (!string.IsNullOrEmpty(handoverid))
            {
                Sql = "delete from t_handoverrecord a where a.id='" + handoverid + "'";
                Sqls.Add(Sql);
            }
            handoverid = App.GenId().ToString();
            Sql = "insert into t_handoverrecord(id, sectionid, handoverdate, type, criticalpatients, recordtime, oldpatients, inpatients, outpatients, deadpatients, nowpatients, senderid, recieverid, recorderid)";
            Sql += " values('" + handoverid + "','" + SectionId + "',to_date('" + date.Value.ToString("yyyy-MM-dd") + "','yyyy-mm-dd'),'" + handovertype + "','" + criticalpatients + "'";
            Sql += ",to_date('" + date.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" + oldpatients + "','" + inpatients + "','" + outpatients + "','" + deadpatients + "','" + nowpatients + "'";
            Sql += ",'" + senderid + "','" + recieverid + "','" + recorderid + "')";
            Sqls.Add(Sql);
            Sql = "delete from t_handoverdetailrecord a where a.handoverid='" + handoverid + "'";
            Sqls.Add(Sql);
            for (int i = fg.Rows.Fixed; i < fg.Rows.Count; i++)
            {
                string id = App.GenId().ToString();
                string patientid = string.Empty;
                string diagnose = string.Empty;
                string chiefcomplaint = string.Empty;
                string diagnosisbasis = string.Empty;
                string plan = string.Empty;
                patientid = fg.Rows[i]["patientid"].ToString();
                chiefcomplaint = fg.Rows[i]["主诉"].ToString();
                diagnose = fg.Rows[i]["诊断"].ToString();
                diagnosisbasis = fg.Rows[i]["诊断依据"].ToString();
                plan = fg.Rows[i]["诊疗计划"].ToString();
                Sql = "insert into t_handoverdetailrecord(id,handoverid,patientid,chiefcomplaint,diagnose,diagnosisbasis,plan)";
                Sql += " values('" + id + "','" + handoverid + "','" + patientid + "','" + chiefcomplaint + "','" + diagnose + "','" + diagnosisbasis + "','" + plan + "')";
                Sqls.Add(Sql);
            }
            int count = 0;
            try
            {
                count = App.ExecuteBatch(Sqls.ToArray());
                if (count > 0)
                {
                    App.Msg("保存成功！");
                }
            }
            catch (Exception ex)
            {
                App.Msg("保存数据出现异常：" + ex.Message.ToString());
                return;
            }
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SectionId))
            {
                this.SectionId = App.UserAccount.CurrentSelectRole.Section_Id;
            }
            SetValidatedTime();
            InitCombox();
        }

        void SetValidatedTime()
        {
            string Sql = "select * from t_sectionhandovertimepoint a where a.sectionid='" + SectionId + "'";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            if (table.Rows.Count > 0)
            {
                string sstart = string.Empty;
                string send = string.Empty;
                if (handovertype.Equals("1"))
                {
                    sstart = table.Rows[0]["daystart"].ToString();
                    send = table.Rows[0]["dayend"].ToString();
                }
                else if (handovertype.Equals("2"))
                {
                    sstart = table.Rows[0]["nightstart"].ToString();
                    send = table.Rows[0]["nightend"].ToString();
                }
                starttime = Convert.ToDateTime(this.date.Value.ToString("yyyy-MM-dd") + " " + sstart);
                endtime = Convert.ToDateTime(this.date.Value.ToString("yyyy-MM-dd") + " " + send);
                TimeSpan ts3 = endtime - starttime;
                if (ts3.TotalSeconds < 0)
                {
                    endtime = endtime.AddDays(1);
                }
            }

        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg.Row > this.fg.Rows.Fixed)
            {
                int rowindex1 = this.fg.Row - this.fg.Rows.Fixed;
                int rowindex2 = rowindex1 - 1;
                SwapTowRows(rowindex1, rowindex2);
            }
        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg.Row < this.fg.Rows.Count - 1 && this.fg.Row >= this.fg.Rows.Fixed)
            {
                int rowindex1 = this.fg.Row - this.fg.Rows.Fixed;
                int rowindex2 = rowindex1 + 1;
                SwapTowRows(rowindex1, rowindex2);
            }
        }

        void SwapTowRows(int rowindex1, int rowindex2)
        {
            for (int i = 0; i < detailtable.Columns.Count; i++)
            {
                object obj1 = detailtable.Rows[rowindex1][i];
                object obj2 = detailtable.Rows[rowindex2][i];
                detailtable.Rows[rowindex1][i] = obj2;
                detailtable.Rows[rowindex2][i] = obj1;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg.Row >= 0 && this.fg.Row >= this.fg.Rows.Fixed)
            {
                detailtable.Rows.RemoveAt(this.fg.Row - this.fg.Rows.Fixed);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (detailtable != null)
            {
                if (this.cmbPatient.SelectedIndex > 0)
                {
                    string patientid = this.cmbPatient.SelectedValue.ToString();
                    if (ExistsPatient(patientid))
                    {
                        App.Msg("列表已经存在此患者，不能添加！");
                        return;
                    }
                    DataRow row = detailtable.NewRow();
                    string Sql = "select '' handoverid,a.id patientid,a.pid 住院号,a.patient_name 患者姓名,decode(a.gender_code,0,'男',1,'女') 性别,a.age||a.age_unit 年龄,to_char(a.in_time,'yyyy-mm-dd hh24:mi') 入院时间 ";
                    Sql += " from t_in_patient a where a.id='" + patientid + "'";
                    DataTable table = App.GetDataSet(Sql).Tables[0];
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        string colname = table.Columns[i].ColumnName;
                        row[colname] = table.Rows[0][colname];
                    }
                    GetPatientInfo(ref row);
                    detailtable.Rows.Add(row);
                    this.fg.Rows[this.fg.Rows.Count - 1].Height = GetHeight(row);
                }
            }
        }

        bool ExistsPatient(string PatientID)
        {
            for (int i = 0; i < detailtable.Rows.Count; i++)
            {
                if (detailtable.Rows[i]["patientid"].ToString().Equals(PatientID))
                {
                    return true;
                }
            }
            return false;
        }

        void InitCombox()
        {
            string Sql = " select a.id,a.sick_bed_no||' '||a.patient_name name from t_in_patient a where a.section_id='" + SectionId + "'";
            Sql += " and to_char(a.in_time,'yyyy-mm-dd hh24:mi')<='" + endtime.ToString("yyyy-MM-dd HH:mm") + "'";
            Sql += " and (a.leave_time is null or to_char(a.leave_time,'yyyy-mm-dd hh24:mi')<='" + endtime.ToString("yyyy-MM-dd HH:mm") + "')";
            Sql += " order by length(a.sick_bed_no),a.sick_bed_no";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            DataRow row;
            row = table.NewRow();
            row["name"] = "--请选择--";
            table.Rows.InsertAt(row, 0);
            cmbPatient.DisplayMember = "name";
            cmbPatient.ValueMember = "id";
            cmbPatient.DataSource = table;
            cmbPatient.SelectedIndex = 0;

            Sql = " select e.user_id,e.user_name from t_account a,t_acc_role b,t_acc_role_range c,t_account_user d,t_userinfo e "
                + " where a.account_id=b.account_id "
                + " and b.id=c.acc_role_id "
                + " and a.account_id=d.account_id "
                + " and d.user_id=e.user_id "
                + " and c.section_id='" + App.UserAccount.CurrentSelectRole.Section_Id + "'"
                + " and b.role_id='" + App.UserAccount.CurrentSelectRole.Role_id + "'";

            DataTable sendertable = App.GetDataSet(Sql).Tables[0];
            row = sendertable.NewRow();
            row["user_name"] = "--请选择--";
            sendertable.Rows.InsertAt(row, 0);
            cmbSendDoctor.DisplayMember = "user_name";
            cmbSendDoctor.ValueMember = "user_id";
            cmbSendDoctor.DataSource = sendertable;
            cmbSendDoctor.SelectedIndex = 0;

            DataTable recievertable = App.GetDataSet(Sql).Tables[0];
            row = recievertable.NewRow();
            row["user_name"] = "--请选择--";
            recievertable.Rows.InsertAt(row, 0);
            cmbRecieveDoctor.DisplayMember = "user_name";
            cmbRecieveDoctor.ValueMember = "user_id";
            cmbRecieveDoctor.DataSource = recievertable;
            cmbRecieveDoctor.SelectedIndex = 0;

        }

        /// 导出为Excel格式文件
        /// </summary>
        /// <param name="counttable">统计数据</param>
        /// <param name="dt">作为数据源的DataTable</param>
        /// <param name="saveFile">带路径的保存文件名</param>
        /// <param name="title">一个Excel sheet的标题</param>
        void exportExcel(DataTable counttable, DataTable dt, string saveFile, string title, string senderdoctor, string recieverdoctor, DateTime handovertime)
        {
            Microsoft.Office.Interop.Excel.Application rptExcel = new Microsoft.Office.Interop.Excel.Application();
            if (rptExcel == null)
            {
                MessageBox.Show("无法打开EXcel，请检查Excel是否可用或者是否安装好Excel", "系统提示");
                return;
            }
            int rowCount = dt.Rows.Count;//行数
            int columnCount = dt.Columns.Count;//列数
            float percent = 0;//导出进度

            //this.Cursor = Cursors.WaitCursor;
            //保存文化环境
            System.Globalization.CultureInfo currentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Workbook workbook = rptExcel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.get_Item(1);
            worksheet.Name = "报表";//一个sheet的名称

            //rptExcel.Visible = true;//打开导出的Excel文件

            //填充统计数据
            int countrows = 1;
            int countcols = counttable.Rows.Count * 2;
            object[,] objcountdata = new object[countrows, countcols];
            for (int i = 0; i < countcols; i++)
            {
                int j = i / 2;
                int k = i % 2;
                objcountdata[0, i] = counttable.Rows[j][k];
            }

            Microsoft.Office.Interop.Excel.Range countrange = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]);
            countrange.Value2 = objcountdata;

            worksheet.Cells[3, 1] = title;//表标题

            //填充列标题
            for (int i = 0; i < columnCount; i++)
            {
                worksheet.Cells[4, i + 1] = dt.Columns[i].ColumnName;
            }

            //创建对象数组存储DataTable的数据，这样的效率比直接将Datateble的数据填充worksheet.Cells[row,col]高
            object[,] objData = new object[rowCount, columnCount];

            //填充内容到对象数组
            for (int r = 0; r < rowCount; r++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    objData[r, col] = dt.Rows[r][col].ToString();
                }
                percent = ((float)(r + 1) * 100) / rowCount;
                //this.panelProgress.Visible = true;//显示进度条
                //this.lblPercents.Text=percent.ToString("n") + "%";
                //this.progressBar1.Value = Convert.ToInt32(percent);
                System.Windows.Forms.Application.DoEvents();
            }
            //将对象数组的值赋给Excel对象
            Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowCount + 4, columnCount]);
            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.NumberFormat = "@";//设置数字文本格式
            range.Value2 = objData;

            string handinfo=senderdoctor+"     "+recieverdoctor+"     "+handovertime.ToString("yyyy-MM-dd HH:mm");
            worksheet.Cells[5 + rowCount, 1] = handinfo;

            //设置格式

            //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;//居中对齐
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).Font.Bold = true;
            //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]).Font.Name = "黑体";
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).MergeCells = true;//合并单元格
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).MergeCells = true;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).Font.Bold = true;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).Font.Bold = true;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).Font.Size = 16;
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).Borders.LineStyle = 1;//设置边框
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[rowCount + 5, columnCount]).Borders.LineStyle = 1;//设置边框
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[rowCount + 5, columnCount]).Columns.AutoFit();//设置单元格宽度为自适应

            //恢复文化环境
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCI;
            try
            {
                //rptExcel.Save(saveFile); //自动创建一个新的Excel文档保存在“我的文档”里，如果不用SaveFileDialog就可用这种方法
                workbook.Saved = true;
                workbook.SaveCopyAs(saveFile);//以复制的形式保存在已有的文档里
                //this.Cursor = Cursors.Default;
                //this.panelProgress.Visible = false;//隐藏进度条
                MessageBox.Show("导出成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出文件出错，文件可能正被打开，具体原因：" + ex.Message, "出错信息");
            }
            finally
            {
                dt.Dispose();
                rptExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(rptExcel);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                GC.Collect();
                KillAllExcel();
            }
        }

        void KillAllExcel()
        {
            List<Process> excelProcess = GetExcelProcesses();
            for (int i = 0; i < excelProcess.Count; i++)
            {
                excelProcess[i].Kill();
            }
        }

        /**/
        /// <summary>
        /// 获得所有的Excel进程
        /// </summary>
        /// <returns>所有的Excel进程</returns>
        List<Process> GetExcelProcesses()
        {
            Process[] processes = Process.GetProcesses();
            List<Process> excelProcesses = new List<Process>();

            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName.ToUpper() == "EXCEL")
                    excelProcesses.Add(processes[i]);
            }
            return excelProcesses;
        }

        private void fg_ChangeEdit(object sender, EventArgs e)
        {
            //using (Graphics g = fg.CreateGraphics())
            //{
            //    string colname = fg.Cols[fg.Col].Name;
            //    if (colname.Equals("主诉") || colname.Equals("诊断") || colname.Equals("诊断依据") || colname.Equals("诊疗计划"))
            //    {
            //        this.fg.Cols[colname].StyleNew.WordWrap = true;
            //        this.fg.Cols[colname].StyleDisplay.WordWrap = true;
            //        // measure text height
            //        StringFormat sf = new StringFormat();
            //        int wid = fg.Cols[colname].WidthDisplay;
            //        string text = fg.Editor.Text;
            //        SizeF sz = g.MeasureString(text, fg.Font, wid, sf);
            //        // adjust row height if necessary
            //        C1.Win.C1FlexGrid.Row row = fg.Rows[fg.Row];
            //        if (sz.Height + 4 > row.HeightDisplay)
            //            row.HeightDisplay = (int)sz.Height + 4;
            //    }
            //}
        }

        private void fg_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
    }
}
