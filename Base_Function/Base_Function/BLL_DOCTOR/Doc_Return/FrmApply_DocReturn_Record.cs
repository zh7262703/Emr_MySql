using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class FrmApply_DocReturn_Record : DevComponents.DotNetBar.Office2007Form
    {
        private string Sql_patient = "";
        private string Pids = "";
        private string Sick_OR_Section = "";
        UcApply_DocReturn_Record uc_Apply;
        private string ID = "";
        private string patient_id = "";
        string ApplyReason = "";  //�ʿ������ã�

        private void FrmApply_DocReturn_Record_Load(object sender, EventArgs e)
        {
            try
            {
                btnSelect_Click(sender, e);
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ReFleshs();
            }
            catch
            {
            }
        }

        private void ReFleshs()
        {
            txtPIDs.Text = "";
            txtApplyReason.Text = "";
            txtApplicant.Text = "";
            txtSick_OR_Section.Text = "";
        }

        // =================================== Xiao Jun ==========================================

        public FrmApply_DocReturn_Record()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �вι���
        /// </summary>
        /// <param name="apply_record">�鵵���������ѯ���������</param>
        public FrmApply_DocReturn_Record(UcApply_DocReturn_Record apply_record)
        {
            InitializeComponent();
            this.uc_Apply = apply_record;
            this.ucC1FlexGrid1.fg.SelectionMode = SelectionModeEnum.Row;
            Sql_patient = @"select ID as ���,PATIENT_NAME as ��������,(case GENDER_CODE when '0' then '��' else 'Ů' end) as  �Ա�,PID  as סԺ��,to_char(in_time,'yyyy-MM-dd HH24:mi') as ��Ժʱ��,to_char(die_time,'yyyy-MM-dd HH24:mi') as ��Ժʱ��," +
                            @"SECTION_ID as ���ұ��,SECTION_NAME as ��������,SICK_AREA_ID as �������,SICK_AREA_NAME as ��������,sick_doctor_name as �ܴ�ҽʦ," +
                           @" (case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end) as �鵵״̬,sick_doctor_id  from t_in_patient where  DOCUMENT_STATE='1'";
        }
        public FrmApply_DocReturn_Record(string strPid)
        {
            InitializeComponent();
            txtPid.Text = strPid;
            ApplyReason = "��������";
            //Sql_patient = @"select ID as ���,PATIENT_NAME as ��������,(case GENDER_CODE when '0' then '��' else 'Ů' end) as  �Ա�,PID  as סԺ��,to_char(in_time,'yyyy-MM-dd HH24:mi') as ��Ժʱ��,to_char(die_time,'yyyy-MM-dd HH24:mi') as ��Ժʱ��," +
            //                @"SECTION_ID as ���ұ��,SECTION_NAME as ��������,SICK_AREA_ID as �������,SICK_AREA_NAME as ��������,sick_doctor_name as �ܴ�ҽʦ," +
            //               @" (case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end) as �鵵״̬,sick_doctor_id  from t_in_patient where  DOCUMENT_STATE='1'";
        }
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = txtPid.Text;
                string pname = txtPName.Text;
                if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                {
                    label4.Text = "����: ";
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        sql += " and section_id = '" + App.UserAccount.CurrentSelectRole.Section_Id + "'";
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + "  and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != "" && pname != "")
                        {
                            sql = Sql_patient + "  and PID like '%" + pid + "%' and PATIENT_NAME like '%" + pname + "%'";
                        }
                        DataSet dst = App.GetDataSet(sql);
                        if (dst != null)
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(sql, "סԺ��", true, "", "");
                                ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["��������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["��������"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["sick_doctor_id"].Visible = false;
                                ucC1FlexGrid1.fg.AllowEditing = false;
                            }
                        }
                    }
                }
                else
                {
                    label4.Text = "����: ";
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        sql += " and Sick_area_Id = '" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'";
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + " and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != "" && pname != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%' and PATIENT_NAME like '%" + pname + "%'";
                        }
                        DataSet dst = App.GetDataSet(sql);
                        if (dst != null)
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                ucC1FlexGrid1.DataBd(sql, "סԺ��", true, "", "");
                                ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["���ұ��"].AllowEditing = false;
                                ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
                                ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
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

        /// <summary>
        /// �رմ���
        /// </summary>
        private void btnCanle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// ������ֵ�ı���
        /// </summary>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {
                    if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                        {
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                        }
                    }
                    else
                    {
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                        {
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// �ύ
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string SQl = "";
                if (txtPIDs.Text.Trim() == "")
                {
                    App.Msg("����סԺ�Ų���Ϊ�գ�");
                    txtPIDs.Focus();
                    return;
                }
                if (txtApplyReason.Text.Trim() == "")
                {
                    App.Msg("�������ɲ���Ϊ�գ�");
                    txtApplyReason.Focus();
                    return;
                }
                else if (System.Text.Encoding.Default.GetBytes(txtApplyReason.Text).Length > 200)
                {
                    App.Msg("�������ɲ��ܳ���200���ַ����ȣ�");
                    txtApplyReason.Focus();
                    return;
                }
                if (txtApplicant.Text.Trim() == "")
                {

                    App.Msg("�����˲���Ϊ�գ�");
                    txtApplicant.Focus();
                    return;
                }
                if (txtSick_OR_Section.Text == "")
                {
                    if (label4.Text == "���ң�")
                    {
                        App.Msg("���Ҳ���Ϊ�գ�");
                        txtSick_OR_Section.Focus();
                        return;
                    }
                    else
                    {
                        App.Msg("��������Ϊ�գ�");
                        txtSick_OR_Section.Focus();
                        return;
                    }
                }

                //if (App.UserAccount.UserInfo.User_id != ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "sick_doctor_id"].ToString())
                //{
                //    App.MsgWaring("�����ǵ�ǰѡ�в��˵Ĺܴ�ҽ����ֻ�йܴ�ҽ���ſ����ύ��");
                //    return;
                //}

                //if ((IsUpdateOrInsert(patient_id)))  //�޸�
                //{
                //    if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                //    {
                //        if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                //        {
                //            SQl = "update T_BORROW_REQ_RECORD set REQ_REMARK='" + txtApplyReason.Text + "',SECTION_ID='" + Sick_OR_Section + "',REQ_BY='" + App.UserAccount.UserInfo.User_id + "',REQ_BY_NAME='" + txtApplicant.Text + "',SECTION_NAME='" + txtSick_OR_Section.Text + "',IN_PATIENT_ID='" + txtPIDs.Text + "',REQ_BY_TIME=sysdate,STATE='δͨ��',state_id = 0 where PATIENT_ID='" + patient_id + "'";
                //        }
                //    }
                //    else
                //    {
                //        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                //        {
                //            SQl = "update T_BORROW_REQ_RECORD set REQ_REMARK='" + txtApplyReason.Text + "',SICKORSECTION_ID='" + Sick_OR_Section + "',REQ_BY='" + App.UserAccount.UserInfo.User_id + "',REQ_BY_NAME='" + txtApplicant.Text + "',SICKORSECTION_NAME='" + txtSick_OR_Section.Text + "',IN_PATIENT_ID='" + txtPIDs.Text + "',REQ_BY_TIME=sysdate,STATE='δͨ��',state_id = 0 where  PATIENT_ID='" + patient_id + "'";
                //        }
                //    }
                //}
                //else
                //{

                ID = App.GenId("T_DOC_REQ_RECORD", "ID").ToString();
                if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                {
                    if (App.UserAccount.CurrentSelectRole.Role_name!="������"&&App.UserAccount.UserInfo.User_id != ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "sick_doctor_id"].ToString())
                    {//ҽ���˺Ŷ�Ӧ�ܴ�ҽʦ
                        App.MsgWaring("�����ǵ�ǰѡ�в��˵Ĺܴ�ҽ����ֻ�йܴ�ҽ���ſ����ύ��");
                        return;
                    }
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string REQ_BY_SECTION = App.UserAccount.CurrentSelectRole.Section_name;
                        if (REQ_BY_SECTION == "")
                        {
                            REQ_BY_SECTION = txtSick_OR_Section.Text;
                        }
                        SQl = "insert into T_DOC_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SECTION_ID,STATE,SECTION_NAME,PATIENT_ID,REQ_BY_SECTION) values("
                              + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','δ����','" + txtSick_OR_Section.Text + "','" + patient_id + "','" + REQ_BY_SECTION + "')";
                    }
                }
                else
                {
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        string REQ_BY_SECTION = App.UserAccount.CurrentSelectRole.Sickarea_name;
                        if (REQ_BY_SECTION == "")
                        {
                            REQ_BY_SECTION = txtSick_OR_Section.Text;
                        }
                        SQl = "insert into T_DOC_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SECTION_ID,STATE,SECTION_NAME,PATIENT_ID,REQ_BY_SECTION) values("
                              + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','δ����','" + txtSick_OR_Section.Text + "','" + patient_id + "','" + REQ_BY_SECTION + "')";
                    }
                }
                // }
                if (SQl != "")
                {
                    string sqlcon = "select count(*) count from T_DOC_REQ_RECORD t where t.req_by='" + App.UserAccount.UserInfo.User_id + "' and t.state='δ����' and t.patient_id='" + patient_id + "'";
                    string count = App.ReadSqlVal(sqlcon, 0, "count");
                    if (count == "0")
                    {//�ò���û���Ѵ��ڲ���δ�����ļ�¼.
                        int number = App.ExecuteSQL(SQl);
                        if (number > 0)
                        {
                            App.Msg("�����ɹ���");
                            uc_Apply.UcApply_DocReturn_Record_Load(sender, e);
                            this.Close();
                        }
                    }
                    else
                    {
                        App.Msg("��ʾ:����ʧ��,����������ò����˵�,δ�������ϵ�������˵���");
                    }

                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// �����ǲ��뻹���޸Ĳ���
        /// </summary>
        /// <param name="pid">����pid</param>
        /// <returns></returns>
        private bool IsUpdateOrInsert(string Patient_id)
        {
            string Sql_IsUpdateOrInsert = "select count(*) as id from T_DOC_REQ_RECORD where PATIENT_ID ='" + Patient_id + "'";
            string count = App.ReadSqlVal(Sql_IsUpdateOrInsert, 0, "id");
            return Convert.ToInt32(count) > 0 ? true : false;
        }

    }
}