using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class UcApply_Medical_Record : UserControl
    {
        public delegate void RefEventHandler(object sender,Child_EventArgs e);
        //�������
        public event RefEventHandler browse_Book;
        private string sql_DOC_REQ_RECORD = "";
        DataSet ds;
        
        public UcApply_Medical_Record()
        {
            InitializeComponent();
            sql_DOC_REQ_RECORD = @"select t.ID as ���,t.IN_PATIENT_ID as ����סԺ��,p.patient_name as ��������,t.SECTION_NAME as ���˿���,t.SICK_DOCTOR_NAME as �ܴ�ҽʦ,REQ_BY as �����˱��,
                                REQ_REMARK as ��������,to_char(REQ_BY_TIME,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,REQ_BY_NAME as ������,t.REQ_BY_SECTION as �����˿���,t.STATE as ״̬,to_char(BORROW_FAILURE_TIME,'yyyy-MM-dd HH24:mi:ss') as ����ʧЧʱ��,t.SICKORSECTION_NAME as ����,t.SECTION_ID as ���ұ��,t.SICKORSECTION_ID as �������,
                                t.PATIENT_ID as �������� from T_BORROW_REQ_RECORD t inner join t_in_patient p on p.id=t.patient_id ";//where t.STATE_ID = 0";
        }
 
        public void UcApply_Medical_Record_Load(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fg_DoubleClick);
                btnSelect_Click(sender,e);
                
               
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

        //void fg_DoubleClick(object sender, EventArgs e)
        //{
        //    if (ucC1FlexGrid1.fg.RowSel > 0)
        //    {
        //        string state = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "״̬"].ToString();
        //        Child_EventArgs args = new Child_EventArgs();
        //        args.State = state;
        //        args.Id =Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString());
        //        args.User_Id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����˱��"].ToString();
        //        if (browse_Book != null)
        //        {
        //            browse_Book(sender,args);
        //        }
        //    }
          
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string StarTime=dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime=dtpEndTime.Value.ToString("yyyy-MM-dd");
                string Pids = txtPid.Text;
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")//ҽʦ
                {
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "'";
                        #region  ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                        }
                        #endregion
                        #region סԺ�ź�ʱ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='�����'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='ͨ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='δͨ��'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='�����' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='ͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
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
                                ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�����˿���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˿���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                        //    }
                        //}
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")//��ʿ��
                    {
                        string SQl = "";
                        SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "'";
                        #region ʱ��
                        if (chkTime.Checked == true)
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "'";

                            }
                        }
                        #endregion
                        #region סԺ��
                        if (Pids != "")
                        {
                            SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";

                        }
                        #endregion
                        #region ʱ���סԺ��
                        if (chkTime.Checked == true && Pids != "")
                        {
                            if (StarTime == EndTime)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  to_char(REQ_BY_TIME,'yyyy-MM-dd')='" + StarTime + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (Convert.ToDateTime(EndTime) < Convert.ToDateTime(StarTime))
                            {
                                App.Msg("����ʱ�䲻��С�ڿ�ʼʱ��");
                                return;
                            }
                            else
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  IN_PATIENT_ID like '%" + txtPid.Text + "%' and to_char(REQ_BY_TIME,'yyyy-MM-dd') between '" + StarTime + "' and '" + EndTime + "' ";

                            }
                        }
                        #endregion
                        #region ����״̬
                        if (chkState.Checked == true)
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='�����'";
                            }
                            else if(cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='ͨ��'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='δͨ��'";
                            }
                        }
                        #endregion
                        #region ����״̬��סԺ��
                        if (chkState.Checked == true && Pids != "")
                        {
                            if (cboState.SelectedIndex == 0)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='�����' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 1)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='ͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                            else if (cboState.SelectedIndex == 2)
                            {
                                SQl = sql_DOC_REQ_RECORD + " and t.req_by_name='" + App.UserAccount.UserInfo.User_name + "' and  t.state='δͨ��' and IN_PATIENT_ID like '%" + txtPid.Text + "%'";
                            }
                        }
                        #endregion
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
                                ucC1FlexGrid1.fg.Cols["�����˱��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˱��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�����˿���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�����˿���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                        //    }
                        //}
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
            FrmApply_Medical_Record fm = new FrmApply_Medical_Record(this);
            App.FormStytleSet(fm, false);
            fm.ShowDialog(this);
           // btnSelect_Click(sender, e);
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    if (App.Ask("���Ƿ�Ҫɾ��"))
                    {
                        string REQ_ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                        if (REQ_ID.Length > 0)
                        {
                            string sql = "delete from T_BORROW_REQ_RECORD where ID='" + REQ_ID + "'";
                            App.ExecuteSQL(sql);
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
                                if (oldRow > 0 && t >= oldRow) //
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

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            //DataTable table = ds.Tables[0].Rows as DataTable;
            try
            {
                if (ucC1FlexGrid1.fg.RowSel >= 1)
                {
                    int row = this.ucC1FlexGrid1.fg.MouseRow;
                    string patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                    string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����סԺ��"].ToString();
                    if (pid != "")
                    {
                        if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "״̬"].ToString() == "ͨ��")// && App.UserAccount.UserInfo.User_name == ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "������"].ToString())
                        {

                            if (Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʧЧʱ��"].ToString()) < App.GetSystemTime())
                            {
                                App.Msg("����ʧЧʱ���ѹ�,����������!");
                                return;
                            }
                            string sql = "select * from t_in_patient t where t.id='" + patient_id + "'";
                            DataSet ds1 = App.GetDataSet(sql);
                            if (ds1 != null)
                            {
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    //InPatientInfo patientInfo = DataInit.GetIninpatientByPid(ds1.Tables[0]);
                                    //patientInfo.PatientState = "����";
                                    //ucDoctorOperater fq = new ucDoctorOperater(patientInfo);
                                    ////frmMain fq = new frmMain(patientInfo, true, patientInfo.Id);
                                    //App.UsControlStyle(fq);
                                    //App.AddNewBusUcControl(fq, "��������");
                                    //((Form)this.ParentForm).Close();

                                    Child_EventArgs args = new Child_EventArgs();
                                    args.State = "����";
                                    args.Id = Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString());
                                    args.User_Id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����˱��"].ToString();
                                    if (browse_Book != null)
                                    {
                                        browse_Book(sender, args);
                                    }
                                    ((Form)this.ParentForm).Close();
                                }
                            }
                        }
                        else
                        {
                            App.Msg("ֻ�ܲ鿴��ͨ����˵���!");
                            return;
                        }
                        
                    }

                }

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
            
        }

    }
}
