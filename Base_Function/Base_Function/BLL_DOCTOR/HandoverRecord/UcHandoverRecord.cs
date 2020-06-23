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
        /// ���Ӱ��¼
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
                App.Msg("���ȵ����������á����ð�Σ�");
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
                senderdoctor += "(�װ�)";
                recieverdoctor += "(ҹ��)";
            }
            else
            {
                senderdoctor += "(ҹ��)";
                recieverdoctor += "(�װ�)";
            }
            DateTime handovertime = dtphandovertime.Value;
            DataTable counttable = new DataTable();
            counttable.Columns.Add();
            counttable.Columns.Add();
            DataRow row;
            row = counttable.NewRow();
            row[0] = "ԭ�в�����:";
            row[1] = txtoldPatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "��Ժ����:";
            row[1] = txtInpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "��Ժ����:";
            row[1] = txtoutpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "��������:";
            row[1] =txtdeadpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "Σ������:";
            row[1] = txtcrititalpatients.Text;
            counttable.Rows.Add(row);

            row = counttable.NewRow();
            row[0] = "���в�����:";
            row[1] = txtnowpatients.Text;
            counttable.Rows.Add(row);

            string title = "��Ҫ���¡���Σ���������ע������";

            DataTable table = detailtable.Copy();
            table.Columns.Remove("handoverid");
            table.Columns.Remove("patientid");

            string filename=string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "���Ӱ��¼.xls";
            sfd.Filter = "Excel������(*.xls)|*.xls";
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
                Sql = " select b.handoverid,a.id patientid,a.pid סԺ��,a.patient_name ��������,decode(a.gender_code,0,'��',1,'Ů') �Ա�,a.age||a.age_unit ����,to_char(a.in_time,'yyyy-mm-dd hh24:mi') ��Ժʱ��";
                Sql += ",b.chiefcomplaint ����,b.diagnose ���,b.diagnosisbasis �������,b.plan ���Ƽƻ� from t_in_patient a inner join t_handoverdetailrecord b ";
                Sql += " on a.id=b.patientid where b.handoverid='" + handoverid + "' order by b.id asc";
                detailtable = App.GetDataSet(Sql).Tables[0];
            }
            else
            {
                Sql = " select '' handoverid,a.id patientid,a.pid סԺ��,a.patient_name ��������,decode(a.gender_code,0,'��',1,'Ů') �Ա�,a.age||a.age_unit ����,to_char(a.in_time,'yyyy-mm-dd hh24:mi') ��Ժʱ��";
                Sql += ",'' ����,'' ���,'' �������,'' ���Ƽƻ� from t_in_patient a ";
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
            this.fg.Cols["סԺ��"].AllowEditing = false;
            this.fg.Cols["��������"].AllowEditing = false;
            this.fg.Cols["�Ա�"].AllowEditing = false;
            this.fg.Cols["��Ժʱ��"].AllowEditing = false;

            this.fg.Cols["����"].Width = 200;
            this.fg.Cols["���"].Width = 200;
            this.fg.Cols["�������"].Width = 300;
            this.fg.Cols["���Ƽƻ�"].Width = 300;

            //this.fg.Cols["�������"].StyleNew.WordWrap = true;
            //this.fg.Cols["����"].StyleNew.WordWrap=true;
            //this.fg.AutoSizeCols();
            //this.fg.AutoSizeRows();
            for (int i = this.fg.Rows.Fixed; i < this.fg.Rows.Count; i++)
            {
                this.fg.Rows[i].Height = GetHeight(detailtable.Rows[i - this.fg.Rows.Fixed]);
            } 
            this.fg.Cols["����"].StyleNew.WordWrap = true;
            this.fg.Cols["���"].StyleNew.WordWrap = true;
            this.fg.Cols["�������"].StyleNew.WordWrap = true;
            this.fg.Cols["���Ƽƻ�"].StyleNew.WordWrap = true;
        }

        int GetHeight(DataRow row)
        {
            int height = 30;
            int h = height;
            h = Math.Max(h, GetHeight(row["����"].ToString(), height, "����"));
            h = Math.Max(h, GetHeight(row["���"].ToString(), height, "���"));
            h = Math.Max(h, GetHeight(row["�������"].ToString(), height, "�������"));
            h = Math.Max(h, GetHeight(row["���Ƽƻ�"].ToString(), height, "���Ƽƻ�"));
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
                if (nodetitle.Contains("�������"))
                {
                    row["���"] = node.InnerText;
                    continue;
                }
                else if (nodetitle.Contains("�������"))
                {
                    row["�������"] = node.InnerText;
                    continue;
                }
                else if (nodetitle.Contains("���Ƽƻ�"))
                {
                    row["���Ƽƻ�"] = node.InnerText;
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
                if (nodename.Equals("����"))
                {
                    row["����"] = node.InnerText;
                    continue;
                }
                else
                {
                    continue;
                }
            }
        }

        //��ȡ�����׳̼�¼
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
        /// ˢ��ͳ�ƽ��
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
                App.Msg("��ѡ�񽻰�ҽʦ��");
                return;
            }
            if (this.cmbRecieveDoctor.SelectedIndex > 0)
            {
                recieverid = cmbRecieveDoctor.SelectedValue.ToString();
            }
            else
            {
                App.Msg("��ѡ��Ӱ�ҽʦ��");
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
                chiefcomplaint = fg.Rows[i]["����"].ToString();
                diagnose = fg.Rows[i]["���"].ToString();
                diagnosisbasis = fg.Rows[i]["�������"].ToString();
                plan = fg.Rows[i]["���Ƽƻ�"].ToString();
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
                    App.Msg("����ɹ���");
                }
            }
            catch (Exception ex)
            {
                App.Msg("�������ݳ����쳣��" + ex.Message.ToString());
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg.Row > this.fg.Rows.Fixed)
            {
                int rowindex1 = this.fg.Row - this.fg.Rows.Fixed;
                int rowindex2 = rowindex1 - 1;
                SwapTowRows(rowindex1, rowindex2);
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
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
                        App.Msg("�б��Ѿ����ڴ˻��ߣ�������ӣ�");
                        return;
                    }
                    DataRow row = detailtable.NewRow();
                    string Sql = "select '' handoverid,a.id patientid,a.pid סԺ��,a.patient_name ��������,decode(a.gender_code,0,'��',1,'Ů') �Ա�,a.age||a.age_unit ����,to_char(a.in_time,'yyyy-mm-dd hh24:mi') ��Ժʱ�� ";
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
            row["name"] = "--��ѡ��--";
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
            row["user_name"] = "--��ѡ��--";
            sendertable.Rows.InsertAt(row, 0);
            cmbSendDoctor.DisplayMember = "user_name";
            cmbSendDoctor.ValueMember = "user_id";
            cmbSendDoctor.DataSource = sendertable;
            cmbSendDoctor.SelectedIndex = 0;

            DataTable recievertable = App.GetDataSet(Sql).Tables[0];
            row = recievertable.NewRow();
            row["user_name"] = "--��ѡ��--";
            recievertable.Rows.InsertAt(row, 0);
            cmbRecieveDoctor.DisplayMember = "user_name";
            cmbRecieveDoctor.ValueMember = "user_id";
            cmbRecieveDoctor.DataSource = recievertable;
            cmbRecieveDoctor.SelectedIndex = 0;

        }

        /// ����ΪExcel��ʽ�ļ�
        /// </summary>
        /// <param name="counttable">ͳ������</param>
        /// <param name="dt">��Ϊ����Դ��DataTable</param>
        /// <param name="saveFile">��·���ı����ļ���</param>
        /// <param name="title">һ��Excel sheet�ı���</param>
        void exportExcel(DataTable counttable, DataTable dt, string saveFile, string title, string senderdoctor, string recieverdoctor, DateTime handovertime)
        {
            Microsoft.Office.Interop.Excel.Application rptExcel = new Microsoft.Office.Interop.Excel.Application();
            if (rptExcel == null)
            {
                MessageBox.Show("�޷���EXcel������Excel�Ƿ���û����Ƿ�װ��Excel", "ϵͳ��ʾ");
                return;
            }
            int rowCount = dt.Rows.Count;//����
            int columnCount = dt.Columns.Count;//����
            float percent = 0;//��������

            //this.Cursor = Cursors.WaitCursor;
            //�����Ļ�����
            System.Globalization.CultureInfo currentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Workbook workbook = rptExcel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.get_Item(1);
            worksheet.Name = "����";//һ��sheet������

            //rptExcel.Visible = true;//�򿪵�����Excel�ļ�

            //���ͳ������
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

            worksheet.Cells[3, 1] = title;//�����

            //����б���
            for (int i = 0; i < columnCount; i++)
            {
                worksheet.Cells[4, i + 1] = dt.Columns[i].ColumnName;
            }

            //������������洢DataTable�����ݣ�������Ч�ʱ�ֱ�ӽ�Datateble���������worksheet.Cells[row,col]��
            object[,] objData = new object[rowCount, columnCount];

            //������ݵ���������
            for (int r = 0; r < rowCount; r++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    objData[r, col] = dt.Rows[r][col].ToString();
                }
                percent = ((float)(r + 1) * 100) / rowCount;
                //this.panelProgress.Visible = true;//��ʾ������
                //this.lblPercents.Text=percent.ToString("n") + "%";
                //this.progressBar1.Value = Convert.ToInt32(percent);
                System.Windows.Forms.Application.DoEvents();
            }
            //�����������ֵ����Excel����
            Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowCount + 4, columnCount]);
            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.NumberFormat = "@";//���������ı���ʽ
            range.Value2 = objData;

            string handinfo=senderdoctor+"     "+recieverdoctor+"     "+handovertime.ToString("yyyy-MM-dd HH:mm");
            worksheet.Cells[5 + rowCount, 1] = handinfo;

            //���ø�ʽ

            //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;//���ж���
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).Font.Bold = true;
            //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnCount]).Font.Name = "����";
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).MergeCells = true;//�ϲ���Ԫ��
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).MergeCells = true;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).Font.Bold = true;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).RowHeight = 38;
            worksheet.get_Range(worksheet.Cells[5 + rowCount, 1], worksheet.Cells[5 + rowCount, columnCount]).Font.Bold = true;
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, columnCount]).Font.Size = 16;
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, countcols]).Borders.LineStyle = 1;//���ñ߿�
            worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[rowCount + 5, columnCount]).Borders.LineStyle = 1;//���ñ߿�
            worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[rowCount + 5, columnCount]).Columns.AutoFit();//���õ�Ԫ����Ϊ����Ӧ

            //�ָ��Ļ�����
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCI;
            try
            {
                //rptExcel.Save(saveFile); //�Զ�����һ���µ�Excel�ĵ������ڡ��ҵ��ĵ�����������SaveFileDialog�Ϳ������ַ���
                workbook.Saved = true;
                workbook.SaveCopyAs(saveFile);//�Ը��Ƶ���ʽ���������е��ĵ���
                //this.Cursor = Cursors.Default;
                //this.panelProgress.Visible = false;//���ؽ�����
                MessageBox.Show("�����ɹ���");
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����ļ������ļ����������򿪣�����ԭ��" + ex.Message, "������Ϣ");
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
        /// ������е�Excel����
        /// </summary>
        /// <returns>���е�Excel����</returns>
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
            //    if (colname.Equals("����") || colname.Equals("���") || colname.Equals("�������") || colname.Equals("���Ƽƻ�"))
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
