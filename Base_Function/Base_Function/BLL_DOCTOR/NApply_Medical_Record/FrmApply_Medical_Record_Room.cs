using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class FrmApply_Medical_Record_Room :DevComponents.DotNetBar.Office2007Form
    {
        private string Pid = "";//סԺ��
        private string Patient_id = "";//��������
        private string DataApplyTime = "";//����ʱ��
        private string Section_0r_Sick_ID = "";//���һ���ID
        private string Section_0r_Sick_name = "";//���һ���ID
        private string Applicant_id = "";//������ID
        private string Applicant_name = "";//������
        private string ApplyReason = "";//��������
        private string AppSick_or_Section = "";
        private string Approval = "";
        UcApply_Medical_Record_Room UCApply;
        public FrmApply_Medical_Record_Room()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �����ʼ��
        /// </summary>
        /// <param name="_ucApply">����UcApply_Medical_Record_Room����</param>
        /// <param name="pid">סԺ��</param>
        /// <param name="patient_id">��������</param>
        /// <param name="dataapplytime">����ʱ��</param>
        /// <param name="section_0r_sick_id">���һ���ID</param>
        /// <param name="section_0r_sick_name">���һ�������</param>
        /// <param name="applicant_id">������ID</param>
        /// <param name="applicant_name">������</param>
        /// <param name="applyreason">��������</param>
        /// <param name="applyreasonAppSick">�Ƿ���ʾ���һ���</param>
        /// <param name="approval">������</param>
        public FrmApply_Medical_Record_Room(UcApply_Medical_Record_Room _ucApply, string pid, string patient_id, string dataapplytime, string section_0r_sick_id, string section_0r_sick_name, string applicant_id, string applicant_name, string applyreason, string applyreasonAppSick, string approval)
        {
            
            InitializeComponent();
            UCApply = _ucApply;
            Pid = pid;
            Patient_id = patient_id;
            DataApplyTime = dataapplytime;
            Section_0r_Sick_ID = section_0r_sick_id;
            Section_0r_Sick_name = section_0r_sick_name;
            Applicant_id = applicant_id;
            Applicant_name = applicant_name;
            ApplyReason = applyreason;
            AppSick_or_Section = applyreasonAppSick;
            Approval = approval;
            
        }
        private void FrmApply_Medical_Record_Room_Load(object sender, EventArgs e)
        {
            try
            {
                txtPIDS.Text = Pid;
                txtApption.Text = Applicant_name;
                dtpApply.Text = DataApplyTime;
                txtApplyReason.Text = ApplyReason;
                txtSecton_or_Sick.Text = Section_0r_Sick_name;
                if (AppSick_or_Section == "����")
                {
                    label2.Text = "���ң�";
                }
                else
                {
                    label2.Text = "������";
                }
                cboState.SelectedIndex = 0;
                cboState.Focus();
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
                if (cboState.Text != "")
                {
                   
                    string sql = "";
                    if (cboState.Text == "ͨ��")
                    {
                        string BFT = txtBORROW_FAILURE_TIME.Text;
                        DateTime dt = App.GetSystemTime();
                        if (BFT != "")
                        {
                            dt = dt.AddDays(double.Parse(BFT));
                        }
                        //ArrayList Sqls = new ArrayList();
                        //string bedid = "";
                        //int id = App.GenId("t_inhospital_action", "id");
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='1',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='1',state='{0}',approval='{1}',BORROW_FAILURE_TIME=to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss') " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,dt, Patient_id, DataApplyTime, Applicant_id);
                       try
                       {
                           int i=App.ExecuteSQL(sql);
                           if (i != 0)
                           {
                               App.Msg("���״̬�޸ĳɹ�");
                               UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                           }
                           else
                           {
                               App.Msg("���״̬�޸�ʧ��");
                           }
                       }
                       catch (Exception ex)
                       {
                           App.Msg("�˻�ʧ�ܣ�ԭ��" + ex.Message);
                       }
                     
                    }
                    if(cboState.Text == "δͨ��")
                    {
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='2',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='2',state='{0}',approval='{1}',BORROW_FAILURE_TIME='{2}' " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,"", Patient_id, DataApplyTime, Applicant_id);
                        int i = App.ExecuteSQL(sql);
                        if (i != 0)
                        {
                            App.Msg("���״̬�޸ĳɹ�");
                            UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                        }
                        else
                        {
                            App.Msg("���״̬�޸�ʧ��");
                        }
                    }
                    if (cboState.Text == "�����")
                    {
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='0',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='0',state='{0}',approval='{1}',BORROW_FAILURE_TIME='{2}' " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,"", Patient_id, DataApplyTime, Applicant_id);
                        int i = App.ExecuteSQL(sql);
                        if (i != 0)
                        {
                            App.Msg("���״̬�޸ĳɹ�");
                            UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                        }
                        else
                        {
                            App.Msg("���״̬�޸�ʧ��");
                        }
                    }
                   
                }
            }
            catch
            {
               
            }
            this.Close();
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboState.SelectedIndex.ToString() == "0")
            //{
            //    txtBORROW_FAILURE_TIME.Enabled = false;
            //    txtBORROW_FAILURE_TIME.Text = "";
            //}
            //else 
            if (cboState.SelectedIndex.ToString() == "0")
            {
                txtBORROW_FAILURE_TIME.Enabled = true;
            }
            else if (cboState.SelectedIndex.ToString() == "1")
            {
                txtBORROW_FAILURE_TIME.Enabled = false;
                txtBORROW_FAILURE_TIME.Text = "";
            }
        }
   
    }
}