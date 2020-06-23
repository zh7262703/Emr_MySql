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
        #region ��������
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

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("���Ƿ�Ҫɾ��"))
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
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����סԺ��"].ToString();
                    patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                    dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString() == "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString() != "")
                        {
                            section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                            section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();

                        }
                    }
                    else
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
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
            string sql = @"select t.ID as ���,t.IN_PATIENT_ID as ����סԺ��,p.patient_name as ��������,REQ_BY as �����˱��,
                        REQ_BY_NAME as ������,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,REQ_REMARK as ��������,
                        t.STATE as ״̬,t.SECTION_ID as ���ұ��,t.SECTION_NAME as ����,t.SICKORSECTION_ID as �������,
                        t.PATIENT_ID as �������� from t_doc_req_record t inner join t_in_patient p on p.id = t.patient_id 
                        where t.SICKORSECTION_ID = '" + App.UserAccount.CurrentSelectRole.Section_Id + "'";


            try
            {
                string StarTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                string Pids = txtPid.Text.ToString();
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")//ҽʦ
                {
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string SQl = "";
                        SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + "";
                        #region  ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                        }
                        #endregion
                        #region סԺ�ź�ʱ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='δͨ��'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='ͬ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='�ܾ�'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='ͬ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  t.state='�ܾ�' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                                ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                            }
                        }
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")//��ʿ��
                    {
                        string SQl = "";
                        SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
                        #region ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and IN_PATIENT_ID like '%" + txtPid.Text + "%'";

                        }
                        #endregion
                        #region ʱ���סԺ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "' ";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='δͨ��'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='ͬ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='�ܾ�'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='ͬ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql + " where SICKORSECTION_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  t.state='�ܾ�' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                                ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
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
        //�������
        public event RefEventHandler browse_Book;
        private string sql_DOC_REQ_RECORD = "";
        DataSet ds;

        public UcApply_DocReturn_Record()
        {
            InitializeComponent();
            sql_DOC_REQ_RECORD = @"select t.ID as ���,t.IN_PATIENT_ID as ����סԺ��,p.patient_name as ��������,t.SECTION_NAME as ���˿���,p.sick_doctor_name as �ܴ�ҽʦ,REQ_BY as �����˱��," +
                               @" REQ_REMARK as ��������,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,REQ_BY_NAME as ������,t.STATE as ״̬,t.SICKORSECTION_NAME as ����,t.SECTION_ID as ���ұ��,t.SICKORSECTION_ID as �������," +
                               @" t.PATIENT_ID as �������� from T_DOC_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id where 1=1";
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
                string state = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "״̬"].ToString();
                Child_EventArgs args = new Child_EventArgs();
                args.State = state;
                args.Id = Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString());
                args.User_Id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����˱��"].ToString();
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
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")//ҽʦ
                {
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "'";
                        #region  ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                        }
                        #endregion
                        #region סԺ�ź�ʱ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='δͨ��'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='ͬ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='�ܾ�'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='ͬ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Section_Id + "' and  t.state='�ܾ�' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                            ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
                            ucC1FlexGrid1.fg.AllowEditing = false;
                        }
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")//��ʿ��
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'";
                        #region ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";

                        }
                        #endregion
                        #region ʱ���סԺ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "' ";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='δͨ��'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='ͬ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='�ܾ�'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='ͬ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.SECTION_ID='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "' and  t.state='�ܾ�' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
                        ds = App.GetDataSet(SQl);
                        if (ds != null)
                        {
                            ucC1FlexGrid1.DataBd(SQl, "����ʱ��", false, "", "");
                            ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["����"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["����"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                            ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                            ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
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
                App.MsgWaring("ֻ�����ʸ�֤��ҽʦ���ܲ����˹��ܣ�");
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    if (App.Ask("���Ƿ�Ҫɾ����"))
                    {
                        string sql = "delete from T_DOC_REQ_RECORD where id=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString() + "";
                        int i = App.ExecuteSQL(sql);
                        if (i > 0)
                        {
                            App.Msg("ɾ���ɹ���");
                            btnSelect_Click(sender, e);
                        }

                    }
                }
                else
                {
                    App.Msg("��û��ѡ������!");
                }
            }
            catch
            {
            }
        }
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
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����סԺ��"].ToString().Trim();
                    patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                    dataApplyTime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString() == "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString() != "")
                        {
                            section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                            section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���˲���"].ToString();

                        }
                    }
                    else
                    {
                        section_0r_Sick_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString();
                        section_0r_Sick_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���˿���"].ToString();
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
