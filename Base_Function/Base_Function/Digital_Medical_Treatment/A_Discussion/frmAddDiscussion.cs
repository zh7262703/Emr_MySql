using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Digital_Medical_Treatment.A_Discussion
{
    public partial class frmAddDiscussion : DevComponents.DotNetBar.Office2007Form
    {
        public frmAddDiscussion()
        {
            InitializeComponent();
        }
        #region ����������
        /// <summary>
        /// ��ǰ����ID
        /// </summary>
        private string currentSickArea = App.UserAccount.CurrentSelectRole.Sickarea_Id;
        /// <summary>
        /// ��ǰ���ߵ�סԺ��
        /// </summary>
        private string currentPatientID = string.Empty;
        /// <summary>
        /// ��ǰ���ߵ�HIS_ID
        /// </summary>
        private string currentPatientHisID = string.Empty;
        #endregion


        #region ����
        /// <summary>
        /// �Ա����ת�����Ա�����
        /// </summary>
        /// <param name="genderCode"></param>
        /// <returns></returns>
        private string TransGender(string genderCode)
        {
            if (!string.IsNullOrEmpty(genderCode))
            {
                if (genderCode.Equals("1"))
                {
                    return genderCode = "Ů";
                }
                else
                {
                    if (genderCode.Equals("0"))
                    {
                        return genderCode = "��";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ͨ���������һ�����Ϣ
        /// </summary>
        /// <param name="patientName"></param>
        private void GetPatientInfoByName(string patientName)
        {
            string sql = string.Empty;
            //��ʱҪ�������  ��ע�͵���sql. 
            //sql = "select * from t_in_patient  d where  d.patient_name ='" + patientName + "'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
            sql = "select * from t_in_patient  d where  d.patient_name ='" + patientName + " and d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    //����
                    this.lblAge.Text = dt.Rows[0]["AGE"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                    //�Ա�
                    this.lblSex.Text = this.TransGender(dt.Rows[0]["GENDER_CODE"].ToString());
                    //����סԺ��
                    this.txtPatientID.Text = dt.Rows[0]["ID"].ToString();
                    //����HIS_ID
                    this.currentPatientHisID = dt.Rows[0]["his_id"].ToString();
                    //����Patient_ID
                    this.currentPatientID = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        //���ظ������Ļ���
                        this.dgvSameNamePatient.Visible = true;
                        this.dgvSameNamePatient.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            this.dgvSameNamePatient.Rows.Add();
                            this.dgvSameNamePatient.Rows[i].Cells["name"].Value = dt.Rows[i]["patient_name"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["ID"].Value = dt.Rows[i]["id"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["bedno"].Value = dt.Rows[i]["SICK_BED_NO"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["sex"].Value = this.TransGender(dt.Rows[i]["GENDER_CODE"].ToString());
                            this.dgvSameNamePatient.Rows[i].Cells["age"].Value = dt.Rows[i]["age"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["intime"].Value = dt.Rows[i]["in_time"].ToString().Substring(0, 16);
                            this.dgvSameNamePatient.Rows[i].Cells["his_id"].Value = dt.Rows[i]["his_id"].ToString();
                        }
                    }
                    else
                    {
                        App.Msg("��ǰ�����޸û���");
                    }
                }
            }
        }
        /// <summary>
        /// ͨ�������������һ�����Ϣ
        /// </summary>
        /// <param name="patientName"></param>
        private void FilterPatientInfoByName(string patientName)
        {
            string sql = string.Empty;
             //sql = "select * from t_in_patient  d where  d.patient_name like'%" + patientName + "%'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
             sql = "select * from t_in_patient  d where  d.patient_name like'%" + patientName + "%'and  d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //���ظ������Ļ���
                    this.dgvSameNamePatient.Visible = true;
                    this.dgvSameNamePatient.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.dgvSameNamePatient.Rows.Add();
                        this.dgvSameNamePatient.Rows[i].Cells[0].Value = dt.Rows[i]["patient_name"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[1].Value = dt.Rows[i]["id"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[2].Value = dt.Rows[i]["SICK_BED_NO"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[3].Value = dt.Rows[i]["in_time"].ToString().Substring(0, 16);
                        this.dgvSameNamePatient.Rows[i].Cells[4].Value = this.TransGender(dt.Rows[i]["GENDER_CODE"].ToString());
                        this.dgvSameNamePatient.Rows[i].Cells[5].Value = dt.Rows[i]["age"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[6].Value = dt.Rows[i]["his_id"].ToString();
                    }
                }
                else
                {
                    App.Msg("��ǰ�����޸û���");
                }
            }
        }
        /// <summary>
        /// ���ݻ���סԺ�Ų��һ�����Ϣ
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatientInfoByPatientID(string patientID)
        {
            string sql = string.Empty;
            sql = "select * from t_in_patient  d where  d.id ='" + patientID + "'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    //����
                    this.lblAge.Text = dt.Rows[0]["AGE"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                    //�Ա�
                    this.lblSex.Text = this.TransGender(dt.Rows[0]["GENDER_CODE"].ToString());
                    //����
                    this.txtPatientName.Text = dt.Rows[0]["PATIENT_NAME"].ToString();
                    this.currentPatientID = dt.Rows[0]["id"].ToString();
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        //���ظ������Ļ���
                    }
                    else
                    {
                        App.Msg("��ǰ�����޸û���");
                    }
                }
            }
        }
        /// <summary>
        /// �������ӵ����ۼ�¼��Ϣ
        /// </summary>
        private void SaveDisscussInfo()
        {
            int int_id = App.GenId("t_patient_disscuss", "id");
            //�������ۼ�¼������һ����¼
            string InsertJob_Temp = "insert into t_patient_disscuss(patient_name,patient_id,disscuss_date,creater,diagnose_info,sex,age,his_id,id)" +
                                    " values('" + this.txtPatientName.Text.ToString() + "','" + this.txtPatientID.Text.ToString() + "',to_timestamp('" + this.dtpDisscussDate.Value.ToString() + "','yyyy-MM-dd hh24:mi:ss'),'" + this.lblDoctorName.Text.ToString() + "','" + this.rtxtDiagnose.Text.ToString() + "','" + this.lblSex.Text.ToString() + "','" + this.lblAge.Text.ToString() + "','" + this.currentPatientHisID.ToString() + "','" + int_id + "')";
            App.ExecuteSQL(InsertJob_Temp);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion



        #region �¼�
        /// <summary>
        /// ҳ�����ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddDiscussion_Load(object sender, EventArgs e)
        {
            //����������
            this.lblDoctorName.Text = App.UserAccount.UserInfo.User_name;
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ���ݻ����������һ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetPatientInfoByName(this.txtPatientName.Text.Trim().ToString());
            }
        }
        /// <summary>
        /// ͨ��סԺ�Ų��һ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetPatientInfoByPatientID(this.txtPatientID.Text.Trim().ToString());
            }
        }
        /// <summary>
        /// �������ӵ����ۼ�¼��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text==""||txtPatientID.Text=="")
            {
                App.Msg("����������סԺ�Ų�����Ϊ�գ�");
                return;
            }
            this.SaveDisscussInfo();
        }
        /// <summary>
        /// ˫��ѡ����Ҫ�������ۼ�¼�Ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSameNamePatient_DoubleClick(object sender, EventArgs e)
        {
           
            //��������
            this.txtPatientName.Text = this.dgvSameNamePatient.CurrentRow.Cells["name"].Value.ToString();
            //����Patient_ID
            this.txtPatientID.Text = this.dgvSameNamePatient.CurrentRow.Cells["id"].Value.ToString();
            //�Ա�
            this.lblSex.Text = this.dgvSameNamePatient.CurrentRow.Cells["sex"].Value.ToString();
            //����
            this.lblAge.Text = this.dgvSameNamePatient.CurrentRow.Cells["age"].Value.ToString();
            //����HIS_ID
            this.currentPatientHisID = this.dgvSameNamePatient.CurrentRow.Cells["his_id"].Value.ToString();
            //����Patient_ID
            this.currentPatientID = this.dgvSameNamePatient.CurrentRow.Cells["ID"].Value.ToString();
            this.dgvSameNamePatient.Visible = false;
        }
        /// <summary>
        /// ��ȡ���������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblDiagnose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<DiagnoseInfo> diagnoseList = new List<DiagnoseInfo>();
            FrmDiagnose frmDiag = new FrmDiagnose(ref diagnoseList);
            //FrmDiagnose frmDiag = new FrmDiagnose();
            frmDiag.PatientID = this.currentPatientID;
            this.rtxtDiagnose.Text = string.Empty;
            if (frmDiag.ShowDialog() == DialogResult.OK)
            {
                if (diagnoseList.Count == 1)
                {
                    this.rtxtDiagnose.Text = diagnoseList[0].DiagnoseName.ToString();
                }
                else
                {
                    if (diagnoseList.Count > 1)
                    {
                        int num = 1;
                        for (int i = 0; i < diagnoseList.Count; i++)
                        {
                            this.rtxtDiagnose.Text += num.ToString() + "." + diagnoseList[i].DiagnoseName + "��";
                            num++;
                        }
                    }
                    else
                    {
                        //��������
                    }
                }
            }
        }
        /// <summary>
        /// ������Ҫ���ҵĻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            this.FilterPatientInfoByName(this.txtPatientName.Text.Trim().ToString());
        }
        #endregion















    }
}