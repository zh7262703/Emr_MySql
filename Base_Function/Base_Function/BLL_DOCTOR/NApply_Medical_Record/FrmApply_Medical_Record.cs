using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class FrmApply_Medical_Record : DevComponents.DotNetBar.Office2007Form
    {
        private string Sql_patient = "";
        private string Pids = "";
        private string Sick_OR_Section = "";
        private string Sick_doctor_name = "";
        UcApply_Medical_Record uc_Apply;
        private string ID = "";
        private string patient_id = "";
        public FrmApply_Medical_Record()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
            }
        }
        public FrmApply_Medical_Record(UcApply_Medical_Record apply_record)
        {
            try
            {
                InitializeComponent();
                uc_Apply = apply_record;
                Sql_patient = @"select ID as ���,PATIENT_NAME as ��������,(case GENDER_CODE when '0' then '��' else 'Ů' end) as  �Ա�,PID  as סԺ��," +
                             @"to_char(t.in_time,'yyyy-MM-dd HH24:mi') ��Ժʱ��,to_char(t.die_time,'yyyy-MM-dd HH24:mi') ��Ժʱ��," +
                            @"SECTION_ID as ���ұ��,SECTION_NAME as ��������,sick_doctor_name as �ܴ�ҽʦ,SICK_AREA_ID as �������,SICK_AREA_NAME as ��������," +
                           @" (case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end) as �鵵״̬  from t_in_patient t where  DOCUMENT_STATE='1'";
            }
            catch
            {
            }
        }

        private void FrmApply_Medical_Record_Load(object sender, EventArgs e)
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
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = txtPid.Text;
                string pname = txtPName.Text;
                if (App.UserAccount.CurrentSelectRole.Role_type.ToString()== "D")
                {
                    label4.Text = "����: ";
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%"+pid+"%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + "  and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != "" && pname != "")
                        {
                            sql = Sql_patient + "  and PID like '%" + pid + "%' and PATIENT_NAME like '%"+pname+"%'";
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
                else
                {
                    label4.Text = "����: ";
                    if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        string sql = "";
                        sql = Sql_patient;
                        if (pid != "")
                        {
                            sql = Sql_patient + " and PID like '%" + pid + "%'";
                        }
                        if (pname != "")
                        {
                            sql = Sql_patient + " and PATIENT_NAME  like '%" + pname + "%'";
                        }
                        if (pid != ""&&pname != "")
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
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString().Trim();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ұ��"].ToString();
                            Sick_doctor_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�ܴ�ҽʦ"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                            txtBY_SECTIONT.Text = App.UserAccount.CurrentSelectRole.Section_name;
                        }
                    }
                    else
                    {
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                        {
                            txtPIDs.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString().Trim();
                            txtSick_OR_Section.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
                            Sick_OR_Section = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                            Sick_doctor_name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�ܴ�ҽʦ"].ToString();
                            txtApplicant.Text = App.UserAccount.UserInfo.User_name;
                            patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                            txtBY_SECTIONT.Text =App.UserAccount.CurrentSelectRole.Section_name;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string SQl = "";
                if (txtPIDs.Text == "")
                {
                    App.Msg("����סԺ�Ų���Ϊ�գ�");
                    txtPIDs.Focus();
                    return;
                }
                if (txtApplyReason.Text == "")
                {
                    App.Msg("�������ɲ���Ϊ�գ�");
                    txtApplyReason.Focus();
                    return;
                }
                else if (System.Text.Encoding.Default.GetBytes(txtApplyReason.Text).Length>200)
                {
                    App.Msg("�������ɲ��ܳ���200���ַ����ȣ�");
                    txtApplyReason.Focus();
                    return;
                }
                if (txtApplicant.Text == "")
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
                    ID = App.GenId("T_BORROW_REQ_RECORD", "ID").ToString();
                    if (App.UserAccount.CurrentSelectRole.Role_type.ToString() == "D")
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                        {
                            SQl = "insert into T_BORROW_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SECTION_ID,STATE,SECTION_NAME,PATIENT_ID,STATE_ID,REQ_BY_SECTION,SICK_DOCTOR_NAME) values("//
                                  + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','�����','" + txtSick_OR_Section.Text + "','" + patient_id + "',0,'" + txtBY_SECTIONT.Text.Trim() + "','" + Sick_doctor_name + "')";
                        }
                    }
                    else
                    {
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                        {
                            SQl = "insert into T_BORROW_REQ_RECORD(ID,IN_PATIENT_ID,REQ_REMARK,REQ_BY,REQ_BY_NAME,REQ_BY_TIME,SICKORSECTION_ID,STATE,SICKORSECTION_NAME,PATIENT_ID,STATE_ID,REQ_BY_SECTION,SICK_DOCTOR_NAME) values("
                                  + ID + ",'" + txtPIDs.Text.Trim() + "','" + txtApplyReason.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + txtApplicant.Text + "',sysdate,'" + Sick_OR_Section + "','�����','" + txtSick_OR_Section.Text + "','" + patient_id + "',0,'" + txtBY_SECTIONT.Text.Trim() + "','" + Sick_doctor_name + "')";
                        }
                    }
               // }
                if (SQl != "")
                {
                    int number = App.ExecuteSQL(SQl);
                    if (number > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCanle_Click(sender,e);
                        uc_Apply.UcApply_Medical_Record_Load(sender,e); 
                    }
                }
            }
            catch
            {
            }
            this.Close();
        }
        /// <summary>
        /// �����ǲ��뻹���޸Ĳ���
        /// </summary>
        /// <param name="pid">����pid</param>
        /// <returns></returns>
        private bool IsUpdateOrInsert(string Patient_id)
        {
            string Sql_IsUpdateOrInsert = "select count(id) as id from T_BORROW_REQ_RECORD where PATIENT_ID ='" + Patient_id + "'";
            string count = App.ReadSqlVal(Sql_IsUpdateOrInsert, 0, "id");
            return Convert.ToInt32(count) > 0 ? true : false;
        }

        private void btnCanle_Click(object sender, EventArgs e)
        {
            //ReFleshs();
            Close();
           
        }
    }
}