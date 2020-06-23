using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.Editors;
using System.Xml;
using System.Collections;
using TextEditor;

namespace Base_Function.BLL_DOCTOR
{
    /// <summary>
    /// Ⱥǩ����
    /// </summary>
    public partial class frmNotSignature : DevComponents.DotNetBar.Office2007Form
    {
        public frmNotSignature()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ǩ������
        /// </summary>
        string signType = "";

        private void frmNotSignature_Load(object sender, EventArgs e)
        {
            //������Ժ���������˵�
            //SetInPatients(); 
            //�����ѳ�Ժ���������˵�
            //SetOutPatients();
            cboSignType.SelectedIndex = 0;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ComboItem cbiSelected = cboSignType.SelectedItem as ComboItem;
            signType = cbiSelected.Text;
            if (signType == "")
            {
                App.Msg("��ѡ��ǩ�����ͣ�");
                return;
            }
            if (signType == "�ܴ�ҽ��")
            {
                SetDoctorPatients();
            }
            else if (signType == "�ϼ�ҽ��")
            {
                SetHigherPatients();
            }
        }
        /// <summary>
        /// �ܴ�δǩ�ֲ���
        /// </summary>
        private void SetDoctorPatients()
        {
            //�ܴ�ҽʦδǩ�ֵ���Ժ����
            string sql_patients = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type<>'����' and c.havedoctorsign='N' ";
            DataSet ds = App.GetDataSet(sql_patients);
            cboInPatients.DisplayMember = "patient_name";
            cboInPatients.ValueMember = "id";
            cboInPatients.DataSource = ds.Tables[0].DefaultView;

            if (cboInPatients.Items.Count > 0)
            {
                cboInPatients.SelectedIndex = 0;
            }

            //�ܴ�δǩ�ֵĳ�Ժ����
            string sql_patientsOut = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type='����' and c.havedoctorsign='N' and b.happen_time>sysdate-50";
            DataSet ds_out = App.GetDataSet(sql_patientsOut);
            cboOutPatient.DisplayMember = "patient_name";
            cboOutPatient.ValueMember = "id";
            cboOutPatient.DataSource = ds_out.Tables[0].DefaultView;
        }

        /// <summary>
        /// �ϼ�δǩ�ֲ���
        /// </summary>
        private void SetHigherPatients()
        {
            //�ϼ�ҽʦδǩ�ֵ���Ժ����
            string sql_higherSing = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type<>'����' and c.ishighersign='Y' and c.havehighersign='N'";
            DataSet ds_higher = App.GetDataSet(sql_higherSing);
            cboInPatients.DisplayMember = "patient_name";
            cboInPatients.ValueMember = "id";
            cboInPatients.DataSource = ds_higher.Tables[0].DefaultView;

            //�ϼ�δǩ�ֵĳ�Ժ���ˣ�48Сʱ�ڣ�
            string sql_patients_Higher = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type='����' and c.ishighersign='Y' and c.havehighersign='N' and b.happen_time>sysdate-50";
            DataSet ds_higherOut = App.GetDataSet(sql_patients_Higher);
            cboOutPatient.DisplayMember = "patient_name";
            cboOutPatient.ValueMember = "id";
            cboOutPatient.DataSource = ds_higherOut.Tables[0].DefaultView;
        }


        /// <summary>
        /// ��ѯ�ϼ�ҽ��δǩ�ֵ�����
        /// </summary>
        private void SearchHigherNotSign(int patientId)
        {
            //��Ҫ�ϼ�ǩ�ֵ�����
            string sql_higher = "select b.id ����ID,b.patient_name ����,a.textname ������,(case when a.havehighersign='Y' then '��' else '��' end) �ϼ��Ƿ�ǩ��,a.tid " +
                                "from t_patients_doc a inner join t_in_patient b on a.patient_id=b.id " +
                                "where a.patient_id=" + patientId + " and a.ishighersign='Y'  and a.havehighersign='N' order by b.patient_name";

            DataSet ds_higher = App.GetDataSet(sql_higher);
            if (ds_higher != null)
            {
                dgvDoctorSign.DataSource = ds_higher.Tables[0].DefaultView;
            }

            if (!dgvDoctorSign.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "ѡ��";
                checkColumn.DisplayIndex = 0;
                checkColumn.Width = 30;
                checkColumn.TrueValue = "true";
                checkColumn.FalseValue = "false";
                dgvDoctorSign.Columns.Insert(0, checkColumn);
            }
            else
            {
                for (int i = 0; i < dgvDoctorSign.Rows.Count; i++)
                {
                    dgvDoctorSign[0, i].Value = "false";
                }
            }
            dgvDoctorSign.Columns["tid"].Visible = false;
        }

        /// <summary>
        /// ��ѯ��ǰ�ܴ�ҽ��δǩ�ֵ�����
        /// </summary>
        private void SearchDoctorNotSign(int patientId)
        {
            //��Ҫ�ܴ�ǩ�ֵ�����
            string sql_doctor = "select b.id ����ID,b.patient_name ����,a.textname ������,(case when a.havedoctorsign='Y' then '��' else '��' end) �ܴ��Ƿ�ǩ��,a.tid " +
                                "from t_patients_doc a inner join t_in_patient b on a.patient_id=b.id " +
                                "where a.patient_id=" + patientId + " and a.havedoctorsign='N' order by b.patient_name";
            DataSet ds_doctor = App.GetDataSet(sql_doctor);
            if (ds_doctor != null)
            {
                dgvDoctorSign.DataSource = ds_doctor.Tables[0].DefaultView;
            }


            if (!dgvDoctorSign.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.HeaderText = "ѡ��";
                checkColumn.DisplayIndex = 0;
                checkColumn.Width = 30;
                checkColumn.TrueValue = "true";
                checkColumn.FalseValue = "false";
                dgvDoctorSign.Columns.Insert(0, checkColumn);
            }
            else
            {
                for (int i = 0; i < dgvDoctorSign.Rows.Count; i++)
                {
                    dgvDoctorSign[0, i].Value = "false";
                }
            }
            dgvDoctorSign.Columns["tid"].Visible = false;
        }

        /// <summary>
        /// �����˵������ı�ʱ��ˢ�±��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(cboInPatients.SelectedValue);//�����б�ѡ��Ĳ���ID

            if (signType == "�ܴ�ҽ��")
            {
                SearchDoctorNotSign(patientId);
            }
            else if (signType == "�ϼ�ҽ��")
            {
                SearchHigherNotSign(patientId);
            }
        }
        /// <summary>
        /// �ѳ�Ժ�����б�SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboOutPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(cboOutPatient.SelectedValue);//�����б�ѡ��Ĳ���ID

            if (signType == "�ܴ�ҽ��")
            {

                SearchDoctorNotSign(patientId);
            }
            else if (signType == "�ϼ�ҽ��")
            {
                SearchHigherNotSign(patientId);
            }
        }
        private void dgvDoctorSign_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewCheckBoxCell sc = dgvDoctorSign[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
                    if (sc != null)
                    {
                        if (sc.Value != null)
                        {
                            if (sc.Value.ToString() != "true")
                            {
                                sc.Value = "true";
                            }
                            else
                            {
                                sc.Value = "false";
                            }
                        }
                        else
                        {
                            sc.Value = "true";
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCheckedAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell cell = null;
            for (int i = 0; i < dgvDoctorSign.Rows.Count; i++)
            {
                cell = dgvDoctorSign[0, i] as DataGridViewCheckBoxCell;
                if (cell != null)
                {

                    if (cbxDoctorAll.Checked)
                    {
                        cell.Value = "true";
                    }
                    else
                    {
                        cell.Value = "false";
                    }

                }
            }

        }

        /// <summary>
        /// Ⱥǩ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctorSign_Click(object sender, EventArgs e)
        {
            frmText text = new frmText();
            XmlDocument textDocument = new XmlDocument();
            textDocument.PreserveWhitespace = true;
            textDocument.Load(@"D:\ddddddd.xml");
            XmlNodeList sign = textDocument.GetElementsByTagName("input");
            foreach (XmlNode var in sign)
            {
                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "��ͨҽʦǩ��")
                //{
                //    //XmlNode newNode = var.Clone();
                //    //newNode.Attributes["id"].Value = App.UserAccount.UserInfo.User_id;
                //    //newNode.InnerText = "        " + App.UserAccount.UserInfo.User_name;
                //    //var.ParentNode.InsertBefore(newNode, var);
                //    //textDocument.Save(@"D:\dddddddfffff.xml");va
                //    if (var.Attributes["id"] != null)
                //    {
                //        if (var.Attributes["id"].Value == "")
                //        {
                //            //������ɾ
                //        }
                //    }
                //    break;
                //}

                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "�ܴ�ҽʦǩ��")
                //{
                //    var.Attributes["id"].Value = App.UserAccount.UserInfo.User_id;
                //    var.InnerText = "        " + App.UserAccount.UserInfo.User_name;
                //    textDocument.Save(@"D:\dddddddfffff.xml");
                //    break;
                //}

                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "�ϼ�ҽʦǩ��")
                //{
                //    var.Attributes["id"].Value = App.UserAccount.UserInfo.User_id;
                //    var.InnerText = "        " + App.UserAccount.UserInfo.User_name;
                //    textDocument.Save(@"D:\dddddddfffff.xml");
                //    break;
                //}
            }
        }
    }
}