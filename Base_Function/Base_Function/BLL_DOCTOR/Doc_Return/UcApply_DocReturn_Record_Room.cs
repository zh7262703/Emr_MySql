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
        private string sql_DOC_REQ_RECORD = "";//�鵵������ѯ
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
                 * ��ʼ����ϸ��Ϣҳ
                */
                sql_DOC_REQ_RECORD = @"select t.ID as ���,t.IN_PATIENT_ID as ����סԺ��," +
                           @" p.patient_name as ��������,"+
                           @" to_char(in_time, 'yyyy-MM-dd HH24:mi') as ��Ժʱ��,"+
                           @" to_char(p.die_time, 'yyyy-MM-dd HH24:mi') as ��Ժʱ��,"+
                           @" REQ_BY as �����˱��,"+
                           @" REQ_BY_NAME as ������,"+
                           @" REQ_BY_SECTION as �������,"+
                           @" to_char(REQ_BY_TIME, 'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,"+
                           @" REQ_REMARK as ��������,"+
                           @" t.APPROVAL as ������,"+
                           @" t.STATE as ״̬,"+
                           @" t.SECTION_ID as ���ұ��,"+
                           @" t.SECTION_NAME as ����,"+
                           @" t.SICKORSECTION_ID as �������," +
                           @" t.SICKORSECTION_NAME as ����," +
                           @" t.PATIENT_ID as �������� from t_doc_req_record t inner join t_in_patient p on p.id=t.patient_id";
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
                 *��ʼ�����ɱ���ҳ
                 */
                cboStatisticType.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        /// <summary>
        /// �󶨱������
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
        /// �󶨿���
        /// </summary>
        private void BindSection()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            //����Ĭ��ѡ��
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["sid"] = 0;
                dr["section_name"] = "��ѡ��";
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
        /// ��ѯ
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
                //ʱ��
                if (chkTime.Checked == true)
                {
                    if (StarTime == EndTime)
                    {
                        SQl += " and to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                        return;
                    }
                    else
                    {
                        SQl += " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //סԺ��
                if (Pids != "")
                {
                    SQl += " and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                }
                //ʱ���סԺ��
                if (chkTime.Checked == true && Pids != "")
                {
                    if (StarTime == EndTime)
                    {
                        SQl += " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                        return;
                    }
                    else
                    {
                        SQl += " and IN_PATIENT_ID like '" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //����״̬
                if (chkState.Checked == true)
                {
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl += " and t.state='δͨ��'";
                    }
                    else if (cboState.SelectedIndex == 1)
                    {
                        SQl += " and t.state='ͬ��'";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl += " and t.state='�ܾ�'";
                    }
                }
                //������
                if (chkDoctor.Checked == true)
                {
                    SQl += " and REQ_BY_NAME like '%" + txtDoctorName.Text + "%'";
                }
                if (cboSection.SelectedIndex != 0)//������
                {
                    SQl += " and t.section_id=" + cboSection.SelectedValue;
                }
                //if (chkState.Checked == true && Pids != "")
                //{
                //    if (cboState.SelectedIndex == 0)
                //    {
                //        SQl += " and t.state='δͨ��' and  IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //    else if (cboState.SelectedIndex == 1)
                //    {
                //        SQl += " and t.state='ͬ��' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //    else if (cboState.SelectedIndex == 2)
                //    {
                //        SQl +=  " and t.state='�ܾ�' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                //    }
                //}
                //ds = App.GetDataSet(SQl);
                ds = App.GetDataSet("select ��� from (" + SQl + ")");
                if (ds != null)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    this.ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                    //ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                    //ucC1FlexGrid1.DataBd();
                    ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
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
        private string pid = "";//סԺ��
        private string patient_id = "";//��������
        private string dataApplyTime = "";//����ʱ��
        private string section_0r_Sick_ID = "";//���һ���ID
        private string section_0r_Sick_name = "";//���һ���ID
        private string Applicant_id = "";//������ID
        private string Applicant_name = "";//������
        private string ApplyReason = "";//��������
        private string TS = "";
        int oldRow = 0;

        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel > 0)
            {
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "״̬"].ToString() == "ͬ��")
                {
                    this.�������ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.�������ToolStripMenuItem.Enabled = true;
                }

                pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����סԺ��"].ToString();
                patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString() == "")
                {
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString() != "")
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
                        TS = "����";
                    }
                }
                else
                {
                    section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString();
                    section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
                    TS = "����";
                }
                ApplyReason = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                Applicant_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����˱��"].ToString();
                Applicant_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "������"].ToString();
                int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
                if (rows > 0)
                {
                    if (oldRow == rows)
                    {
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    }
                    else
                    {
                        //�������ͷ��
                        if (rows > 0)
                        {
                            //�͸ı䱳��ɫ
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        int t = ucC1FlexGrid1.fg.Rows.Count;
                        if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                        {
                            if (oldRow < t)
                            {


                                //������һ�ε�������л�ԭ
                                this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }

                        }
                    }
                }
                //����һ�ε��кŸ�ֵ
                oldRow = rows;
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void �鿴��������toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string lastTime = "";
            DataSet ds_LastTime = App.GetDataSet("select back_time from t_doc_req_history where patient_id=" + patient_id + " order by back_time desc");
            if (ds_LastTime != null)
            {
                if (ds_LastTime.Tables[0].Rows.Count > 0)
                {
                    lastTime = Convert.ToDateTime(ds_LastTime.Tables[0].Rows[0]["back_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    string patientName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                    string inTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��Ժʱ��"].ToString();
                    string sectionName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();

                    FrmSearchDocHistory frmHistory = new FrmSearchDocHistory(patient_id, lastTime, patientName, inTime, pid, sectionName);
                    frmHistory.StartPosition = FormStartPosition.CenterParent;
                    frmHistory.ShowDialog();
                }
                else
                {
                    App.Msg("û�����ݣ�");
                }
            }
        }

        /// <summary>
        /// �����˿����ѯ
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
                            string sql_select = "select distinct(a.user_id) as ���,a.user_name as ����,g.name as ְ��,m.section_name as ���� from t_userinfo a" +
                                                " inner join t_account_user b on a.user_id=b.user_id" +
                                                " inner join t_account c on b.account_id = c.account_id" +
                                                " inner join t_acc_role d on d.account_id = c.account_id" +
                                                " inner join t_role e on e.role_id = d.role_id" +
                                                " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                                                " inner join t_data_code g on g.id=a.u_tech_post" +
                                                " inner join t_sectioninfo m on f.section_id=m.sid" +
                                                " where e.role_type='D' and UPPER(a.shortcut_code) like '" + txtDoctorName.Text.ToUpper().Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctorName, "����", "ְ��");
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
        /// ͳ�Ʒ�ʽѡ����ı��¼�
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
                BindStatisticSection();//�����ɱ���ҳ����
                cboDoctor.DataSource = null;
            }
            else
            {
                cboSection2.Enabled = true;
                cboDoctor.Enabled = true;
                BindStatisticSection();//�����ɱ���ҳ����
            }
        }
        /// <summary>
        /// ����ѡ����ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSection2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatisticType.SelectedIndex == 2)//��ҽ������ͳ��ʱ�����ص�ǰ���ҵ�ҽ��
            {
                string sql_doctor = "select user_id,user_name from t_userinfo where section_id=" + cboSection2.SelectedValue.ToString();
                DataSet ds_Doctores = App.GetDataSet(sql_doctor);
                cboDoctor.DataSource = ds_Doctores.Tables[0];
                cboDoctor.ValueMember = "user_id";
                cboDoctor.DisplayMember = "user_name";
            }
        }

        /// <summary>
        /// �����˻���ͳ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            string startTime = dtpStartTime2.Value.ToString("yyyy-MM-dd");//��ʼʱ��
            string endTime = dtpEndTime2.Value.ToString("yyyy-MM-dd");//����ʱ��
            string sql_req = "";
            //if (cboStatisticType.SelectedIndex == 0)//��ȫԺ����
            //{
            //    sql_req = @"select distinct s.section_name ��������," +
            //                 " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "') ��Ժ����," +
            //                 " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and c.state='ͬ��' and a.section_id=c.section_id ) �����ɹ��˻���,'' �˻���" +
            //                 " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id inner join t_sectioninfo s on a.section_id=s.sid "+
            //                 " where a.state='ͬ��' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            //}
            //else if (cboStatisticType.SelectedIndex == 1)//������ҽ��
            //{
            //    sql_req = "select distinct a.req_by_name ҽ������," +
            //                " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "') ��Ժ����," +
            //                " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and c.state='ͬ��' and a.section_id=c.section_id and a.req_by=c.req_by) �����ɹ��˻���,'' �˻���" +
            //                " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id  where a.state='ͬ��' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'" +
            //                " and a.section_id=" + cboSection2.SelectedValue;
            //}
            //else if (cboStatisticType.SelectedIndex == 2)
            //{
            //    sql_req = "select distinct a.req_by_name ҽ������," +
            //               " (select count(*) from t_in_patient b inner join convert_cost c on t.id=c.patient_id where a.section_id=b.section_id and c.total_cost>0 and instr(b.his_id, '_') = 0 and to_char(die_time,'yyyy-MM-dd') between '" + startTime + "' and '" + endTime + "' and b.sick_doctor_id=a.req_by) ��Ժ����," +
            //               " (select count(*) from t_doc_req_record c inner join t_in_patient i on c.patient_id=i.id where instr(his_id,'_')=0 and  c.state='ͬ��' and a.section_id=c.section_id and a.req_by=c.req_by) �����ɹ��˻���,'' �˻���" +
            //               " from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id  where a.state='ͬ��' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'" +
            //               " and a.section_id=" + cboSection2.SelectedValue + " and a.req_by=" + cboDoctor.SelectedValue;
            //}

            string sqlwhere = "and to_char(die_time, 'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            if (cboStatisticType.SelectedIndex == 0)//��ȫԺ����
            {
                /*   û����ҳ,û�з�������
                  inner join (select b.section_id,b.sick_doctor_id,count(*) ��Ժ���� from t_in_patient b
                              inner join convert_cost c on b.id = c.patient_id
                              where  c.total_cost > 0 and instr(b.his_id, '_') = 0
                              {0} group by b.section_id,b.sick_doctor_id) c on s.sid=c.section_id and c.sick_doctor_id=a.req_by
                 */
                sql_req = string.Format(@"select distinct s.section_name ��������, ��Ժ����, �����ɹ��˻���,'' �˻���
                          from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                            inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.section_id,count(*) ��Ժ���� from t_in_patient b
                                         where   instr(b.his_id, '_') = 0
                                         {0} group by b.section_id) c on s.sid=c.section_id
                            inner join (select c.section_id,count(*) �����ɹ��˻���
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = 'ͬ��' 
                                        {0} group by c.section_id) d on s.sid=d.section_id", sqlwhere);
                //where a.state='ͬ��' and instr(b.his_id, '_') = 0 and to_char(a.req_by_time,'yyyy-MM-dd') between  '" + startTime + "' and '" + endTime + "'";
            }
            else if (cboStatisticType.SelectedIndex == 1)//������ҽ��
            {
                sql_req = string.Format(@"select distinct a.req_by_name ����ҽ��, ��Ժ����, �����ɹ��˻���, '' �˻���
                            from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                            inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.section_id,b.sick_doctor_id,count(*) ��Ժ���� from t_in_patient b
                                         where instr(b.his_id, '_') = 0
                                         {0} group by b.section_id,b.sick_doctor_id) c on s.sid=c.section_id and c.sick_doctor_id=a.req_by
                            inner join (select c.section_id,c.req_by,count(*) �����ɹ��˻���
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = 'ͬ��' 
                                         {0} group by c.section_id,c.req_by) d on s.sid=d.section_id and d.req_by=a.req_by 
                            where a.section_id={1}", sqlwhere, cboSection2.SelectedValue);
            }
            else if (cboStatisticType.SelectedIndex == 2)
            {
                sql_req = string.Format(@"select distinct a.req_by_name ����ҽ��, ��Ժ����, �����ɹ��˻���, '' �˻���
                              from t_doc_req_record a inner join t_in_patient b on a.section_id = b.section_id
                                inner join t_sectioninfo s on a.section_id = s.sid
                            inner join (select b.sick_doctor_id,count(*) ��Ժ���� from t_in_patient b
                                         where  instr(b.his_id, '_') = 0
                                         {0} group by b.sick_doctor_id) c on c.sick_doctor_id=a.req_by
                            inner join (select c.req_by,count(*) �����ɹ��˻���
                                         from t_doc_req_record c inner join t_in_patient i on c.patient_id = i.id
                                         where instr(his_id, '_') = 0 and c.state = 'ͬ��' 
                                         {0} group by c.req_by) d on d.req_by=a.req_by
                            where a.req_by={1}", sqlwhere, cboDoctor.SelectedValue);
            }
            DataSet ds = App.GetDataSet(sql_req);
            if (ds != null)
            {
                fg.DataSource = ds.Tables[0].DefaultView;
            }

            //�����˻���
            if (fg.Rows.Count > 1)
            {
                for (int i = 1; i < fg.Rows.Count; i++)
                {
                    double valDouble = 0.00;
                    if (Convert.ToInt32(fg[i, "��Ժ����"]) != 0)
                    {
                        valDouble = Convert.ToDouble(fg[i, "�����ɹ��˻���"]) * 100 / Convert.ToDouble(fg[i, "��Ժ����"]);
                        fg[i, "�˻���"] = valDouble.ToString("0.00") + "%";
                    }
                }
            }

        }

        private void �ʿز�ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string patientName =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
            string inTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��Ժʱ��"].ToString();
            string sectionName = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();

            FrmSearchQuality frm = new FrmSearchQuality(patient_id, patientName, inTime, pid, sectionName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnExcel2_Click(object sender, EventArgs e)
        {
            saveFileDialog2.FileName = "�����˻ر���.xls";
            saveFileDialog2.Filter = "Excel������(*.xls)|*.xls";
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
            saveFileDialog1.FileName = "��ϸ��Ϣ����.xls";
            saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

        }
    }
}
