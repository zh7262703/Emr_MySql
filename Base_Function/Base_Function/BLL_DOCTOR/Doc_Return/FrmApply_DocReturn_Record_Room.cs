using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    public partial class FrmApply_DocReturn_Record_Room : DevComponents.DotNetBar.Office2007Form
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
        private string Approval = "";//������
        UcApply_DocReturn_Record_Room UCApply;
        public FrmApply_DocReturn_Record_Room()
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
        /// <param name="section_0r_sick_id">���ұ��</param>
        /// <param name="section_0r_sick_name">����</param>
        /// <param name="applicant_id">�������</param>
        /// <param name="applicant_name">����</param>
        /// <param name="applyreason">��������</param>
        /// <param name="applyreasonAppSick">�Ƿ���ʾ���һ���</param>
        public FrmApply_DocReturn_Record_Room(UcApply_DocReturn_Record_Room _ucApply, string pid, string patient_id, string dataapplytime, string section_0r_sick_id, string section_0r_sick_name, string applicant_id, string applicant_name, string applyreason, string applyreasonAppSick, string approval)
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
        private void FrmApply_DocReturn_Record_Room_Load(object sender, EventArgs e)
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
                    if (cboState.Text == "ͬ��")
                    {
                        if (this.txtLoseTime.Text.Trim() == "" || this.txtLoseTime.Text.Trim() == "0" || Convert.ToInt32(this.txtLoseTime.Text.Trim()) < 0)
                        {
                            App.MsgWaring("�����������������������!");
                            return;
                        }
                       
                        ArrayList Sqls = new ArrayList();
                        string bedid = "";
                                                 //sql = "update t_doc_req_record set state='" + cboState.Text + "',losetime=to_timestamp('" + loseTime.ToShortDateString() + "','yyyy-MM-dd') where PATIENT_ID='" + Patient_id + "'";
                        sql = "update t_doc_req_record set state='" + cboState.Text + "',APPROVAL='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql += string.Format(" and id = '{0}'", this.UCApply.ucC1FlexGrid1.fg.Rows[this.UCApply.ucC1FlexGrid1.fg.RowSel]["���"].ToString());
                        Sqls.Add(sql);
                        //App.ExecuteSQL(sql);
                        //App.Msg("����ɹ�");

                        //Sqls.Clear();
                        string TSSql = "select * from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + Patient_id + "' order by id asc";
                        DataSet dsactionhistory = App.GetDataSet(TSSql);
                        string strsql = "delete from t_doc_neaten where patient_id='" + Patient_id + "'";
                        Sqls.Add(strsql);

                        for (int i = 0; i < dsactionhistory.Tables[0].Rows.Count; i++)
                        {
                            bedid = dsactionhistory.Tables[0].Rows[i]["bed_id"].ToString();
                            string sqls = "";
                            if (bedid.Trim() == "")
                            {
                                bedid = "0";
                            }
                            sqls = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                                   " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                                   " values(" + App.GenId("t_inhospital_action", "id") + "," + dsactionhistory.Tables[0].Rows[i]["sid"].ToString() + "," +
                                                   dsactionhistory.Tables[0].Rows[i]["said"].ToString() + ",'" +
                                                   dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + "'," +
                                                   "'" + dsactionhistory.Tables[0].Rows[i]["action_type"].ToString() + "','" +
                                                   dsactionhistory.Tables[0].Rows[i]["action_state"].ToString() + "',to_timestamp('" + dsactionhistory.Tables[0].Rows[i]["happen_time"].ToString()
                                                                + "','yyyy-MM-dd hh24:mi:ss')," +
                                                                bedid + ",'" +
                                                                dsactionhistory.Tables[0].Rows[i]["doctor_id"].ToString() + "'," +
                                                                dsactionhistory.Tables[0].Rows[i]["operate_id"].ToString() + "," +
                                                                dsactionhistory.Tables[0].Rows[i]["next_id"].ToString() + "," +
                                                                dsactionhistory.Tables[0].Rows[i]["preview_id"].ToString() + "," +
                                                                dsactionhistory.Tables[0].Rows[i]["patient_id"].ToString() + ")";
                          
                            Sqls.Add(sqls);
                        }
                        TSSql = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + Patient_id + "'";
                        Sqls.Add(TSSql);
                        string strsqls = "update t_in_patient set baupload='2',document_state=null,exe_document_time=(Sysdate+" + this.txtLoseTime.Text + ") where id='" + Patient_id + "'";
                        Sqls.Add(strsqls);

                        //��¼�鵵��ʷ
                        string sql_req_history = "insert into t_doc_req_history(patient_id,back_time,back_operator) values(" + Patient_id + ",sysdate," + App.UserAccount.UserInfo.User_id + ")";
                        Sqls.Add(sql_req_history);

                        try
                        {
                            string[] strsqlst = new string[Sqls.Count];
                            for (int i = 0; i < Sqls.Count; i++)
                            {
                                strsqlst[i] = Sqls[i].ToString();
                            }
                            int count = App.ExecuteBatch(strsqlst);
                            if (count >0)
                            {
                                App.Msg("�˻سɹ���");
                                this.Close();
                                UCApply.UcApply_DocReturn_Record_Room_Load(sender, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            App.Msg("�˻�ʧ�ܣ��������ύ��" );
                        }
                    }
                    if (cboState.Text == "�ܾ�")
                    {
                        sql = "update t_doc_req_record set state='" + cboState.Text + "',APPROVAL='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql += string.Format(" and id = '{0}'", this.UCApply.ucC1FlexGrid1.fg.Rows[this.UCApply.ucC1FlexGrid1.fg.RowSel]["���"].ToString());
                        int count = App.ExecuteSQL(sql);
                        if (count >0)
                        {
                            App.Msg("����ɹ�");
                            this.Close();
                            UCApply.UcApply_DocReturn_Record_Room_Load(sender, e);
                        }
                    }
                    //if (cboState.Text == "δͨ��")
                    //{
                    //    sql = "update t_doc_req_record set state='" + cboState.Text + "' where PATIENT_ID='" + Patient_id + "'";
                    //    sql += string.Format(" and id = '{0}'", this.UCApply.ucC1FlexGrid1.fg.Rows[this.UCApply.ucC1FlexGrid1.fg.RowSel]["���"].ToString());
                    //    App.ExecuteSQL(sql);
                    //    App.Msg("����ɹ�");
                    //    UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                    //    this.Close();
                    //}
                }
            }
            catch
            {
            }
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
        /// ֻ����������
        /// </summary>
        private void txtLoseTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }       
    }
}