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
    /// 群签界面
    /// </summary>
    public partial class frmNotSignature : DevComponents.DotNetBar.Office2007Form
    {
        public frmNotSignature()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 签字类型
        /// </summary>
        string signType = "";

        private void frmNotSignature_Load(object sender, EventArgs e)
        {
            //设置在院病人下拉菜单
            //SetInPatients(); 
            //设置已出院病人下拉菜单
            //SetOutPatients();
            cboSignType.SelectedIndex = 0;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ComboItem cbiSelected = cboSignType.SelectedItem as ComboItem;
            signType = cbiSelected.Text;
            if (signType == "")
            {
                App.Msg("请选择签名类型！");
                return;
            }
            if (signType == "管床医生")
            {
                SetDoctorPatients();
            }
            else if (signType == "上级医生")
            {
                SetHigherPatients();
            }
        }
        /// <summary>
        /// 管床未签字病人
        /// </summary>
        private void SetDoctorPatients()
        {
            //管床医师未签字的在院病人
            string sql_patients = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type<>'出区' and c.havedoctorsign='N' ";
            DataSet ds = App.GetDataSet(sql_patients);
            cboInPatients.DisplayMember = "patient_name";
            cboInPatients.ValueMember = "id";
            cboInPatients.DataSource = ds.Tables[0].DefaultView;

            if (cboInPatients.Items.Count > 0)
            {
                cboInPatients.SelectedIndex = 0;
            }

            //管床未签字的出院病人
            string sql_patientsOut = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type='出区' and c.havedoctorsign='N' and b.happen_time>sysdate-50";
            DataSet ds_out = App.GetDataSet(sql_patientsOut);
            cboOutPatient.DisplayMember = "patient_name";
            cboOutPatient.ValueMember = "id";
            cboOutPatient.DataSource = ds_out.Tables[0].DefaultView;
        }

        /// <summary>
        /// 上级未签字病人
        /// </summary>
        private void SetHigherPatients()
        {
            //上级医师未签字的在院病人
            string sql_higherSing = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type<>'出区' and c.ishighersign='Y' and c.havehighersign='N'";
            DataSet ds_higher = App.GetDataSet(sql_higherSing);
            cboInPatients.DisplayMember = "patient_name";
            cboInPatients.ValueMember = "id";
            cboInPatients.DataSource = ds_higher.Tables[0].DefaultView;

            //上级未签字的出院病人（48小时内）
            string sql_patients_Higher = "select distinct a.id,a.patient_name from t_in_patient a inner join t_inhospital_action b on a.id=b.pid inner join t_patients_doc c on a.id=c.patient_id where a.sick_doctor_id=" + App.UserAccount.UserInfo.User_id + " and b.next_id=0 and action_type='出区' and c.ishighersign='Y' and c.havehighersign='N' and b.happen_time>sysdate-50";
            DataSet ds_higherOut = App.GetDataSet(sql_patients_Higher);
            cboOutPatient.DisplayMember = "patient_name";
            cboOutPatient.ValueMember = "id";
            cboOutPatient.DataSource = ds_higherOut.Tables[0].DefaultView;
        }


        /// <summary>
        /// 查询上级医生未签字的文书
        /// </summary>
        private void SearchHigherNotSign(int patientId)
        {
            //需要上级签字的文书
            string sql_higher = "select b.id 病人ID,b.patient_name 姓名,a.textname 文书名,(case when a.havehighersign='Y' then '是' else '否' end) 上级是否签字,a.tid " +
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
                checkColumn.HeaderText = "选择";
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
        /// 查询当前管床医生未签字的文书
        /// </summary>
        private void SearchDoctorNotSign(int patientId)
        {
            //需要管床签字的文书
            string sql_doctor = "select b.id 病人ID,b.patient_name 姓名,a.textname 文书名,(case when a.havedoctorsign='Y' then '是' else '否' end) 管床是否签字,a.tid " +
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
                checkColumn.HeaderText = "选择";
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
        /// 下拉菜单索引改变时，刷新表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(cboInPatients.SelectedValue);//下拉列表选择的病人ID

            if (signType == "管床医生")
            {
                SearchDoctorNotSign(patientId);
            }
            else if (signType == "上级医生")
            {
                SearchHigherNotSign(patientId);
            }
        }
        /// <summary>
        /// 已出院病人列表SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboOutPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int patientId = Convert.ToInt32(cboOutPatient.SelectedValue);//下拉列表选择的病人ID

            if (signType == "管床医生")
            {

                SearchDoctorNotSign(patientId);
            }
            else if (signType == "上级医生")
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
        /// 全选
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
        /// 群签
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
                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "普通医师签名")
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
                //            //就让他删
                //        }
                //    }
                //    break;
                //}

                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "管床医师签名")
                //{
                //    var.Attributes["id"].Value = App.UserAccount.UserInfo.User_id;
                //    var.InnerText = "        " + App.UserAccount.UserInfo.User_name;
                //    textDocument.Save(@"D:\dddddddfffff.xml");
                //    break;
                //}

                //if (var.Attributes["name"] != null && var.Attributes["name"].Value == "上级医师签名")
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