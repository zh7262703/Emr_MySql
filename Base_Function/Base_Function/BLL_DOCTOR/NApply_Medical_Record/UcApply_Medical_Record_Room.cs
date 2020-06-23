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
        private string sql_DOC_REQ_RECORD = "";//�������Ĳ�ѯ
        DataSet ds;
        public UcApply_Medical_Record_Room()
        {
            try
            {
                InitializeComponent();
                //sql_DOC_REQ_RECORD = @"select t.ID as ���,t.IN_PATIENT_ID as ����סԺ��,p.patient_name as ��������,REQ_BY as �����˱��,REQ_BY_NAME as ������,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��," +
                //            @" t.STATE as ״̬,t.SECTION_NAME as ����,t.SICKORSECTION_NAME as ����,REQ_REMARK as ��������,t.SECTION_ID as ���ұ��,t.SICKORSECTION_ID as �������," +
                //            @" t.PATIENT_ID as �������� from T_BORROW_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id";
                sql_DOC_REQ_RECORD = @"select t.ID as ���," +
                                    @"t.IN_PATIENT_ID as ����סԺ��," +
                                    @"p.patient_name as ��������," +
                                    @"to_char(p.in_time, 'yyyy-MM-dd HH24:mi') as ��Ժʱ��," +
                                    @"to_char(p.die_time, 'yyyy-MM-dd HH24:mi') as ��Ժʱ��," +
                                    @"REQ_BY as �����˱��," +
                                    @"REQ_BY_NAME as ������," +
                                    @"REQ_BY_SECTION as �������," +
                                    @"to_char(REQ_BY_TIME, 'yyyy-MM-dd HH24:mi:ss') as ����ʱ��," +
                                    @"REQ_REMARK as ��������," +
                                    @"t.STATE as ״̬," +
                                    @"t.APPROVAL as ������," +
                                    @"to_char(t.borrow_failure_time, 'yyyy-MM-dd HH24:mi:ss') as ����ʧЧʱ��," +
                                    @"t.SECTION_ID as ���ұ��," +
                                    @"t.SECTION_NAME as ����," +
                                    @"t.SICKORSECTION_ID as �������," +
                                    @"t.SICKORSECTION_NAME as ����," +
                                    @"t.PATIENT_ID as ��������" +
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
                SQl = sql_DOC_REQ_RECORD;// +" where t.state='δͨ��'";
                //ʱ��
                if (chkTime.Checked == true)
                {
                    if (StarTime == EndTime)
                    {
                        SQl = sql_DOC_REQ_RECORD + " and to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                        return;
                    }
                    else
                    {
                        SQl = sql_DOC_REQ_RECORD + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //סԺ��
                if (Pids != "")
                {
                    SQl = sql_DOC_REQ_RECORD + " and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                }
                //ʱ���סԺ��
                if (chkTime.Checked == true && Pids != "")
                {
                    if (StarTime == EndTime)
                    {
                        SQl = sql_DOC_REQ_RECORD + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '" + txtPid.Text + "%'";
                    }
                    else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                    {
                        App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                        return;
                    }
                    else
                    {
                        SQl = sql_DOC_REQ_RECORD + " and IN_PATIENT_ID like '" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                    }
                }
                //����״̬
                if (chkState.Checked == true)
                {//״̬ID��0����С�1ͨ����2δͨ��
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='�����'";
                    }
                    else if(cboState.SelectedIndex == 1)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='ͨ��'";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='δͨ��'";
                    }
                }
                if (chkState.Checked == true && Pids != "")
                {
                    if (cboState.SelectedIndex == 0)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='�����' and  IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                    else if (cboState.SelectedIndex == 1)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='ͨ��' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                    else if (cboState.SelectedIndex == 2)
                    {
                        SQl = sql_DOC_REQ_RECORD + " where t.state='δͨ��' and IN_PATIENT_ID like '" + txtPid.Text + "%";
                    }
                }
                //ds = App.GetDataSet(SQl);
                //if (ds != null)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                        ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                        ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                        ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
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
        private string pid = "";//סԺ��
        private string patient_id = "";//��������
        private string dataApplyTime = "";//����ʱ��
        private string section_0r_Sick_ID = "";//���һ���ID
        private string section_0r_Sick_name = "";//���һ�������
        private string Applicant_id = "";//������ID
        private string Applicant_name = "";//������
        private string ApplyReason = "";//��������
        private string TS = "";
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)                                                                   
                {
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "״̬"].ToString() == "ͨ��")
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
                            //if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                            //{
                            //    if (oldRow < t)
                            //    {
                            //        //������һ�ε�������л�ԭ
                            //        this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            //    }
                            //}
                            if (oldRow > 0 && oldRow < t)
                            {
                                //������һ�ε�������л�ԭ
                                this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //����һ�ε��кŸ�ֵ
                    oldRow = rows;
                }

            }
            catch (Exception)
            {
            }
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    App.Msg("����ѡ������!");
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
