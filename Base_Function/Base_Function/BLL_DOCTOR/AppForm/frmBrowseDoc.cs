using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using TextEditor;
using System.Xml;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.AppForm
{
    public partial class frmBrowseDoc : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo currentPatient = null;
        //���˵���������
        Patient_Doc[] patient_Docs = null;
        frmText ucText = null;
        public frmBrowseDoc()
        {
            InitializeComponent();
        }


        private void frmBrowseDoc_Load(object sender, EventArgs e)
        {
            //�󶨲����б�
            string sql_PatientList = "select a.id,a.patient_name from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and b.action_state<>2";
            DataSet ds = App.GetDataSet(sql_PatientList);
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                cboPatientName.DisplayMember = "patient_name";
                cboPatientName.ValueMember = "id";
                cboPatientName.DataSource = dt;
            }
        }

        /// <summary>
        /// ��õ�ǰ�ڵ��������в�������Ľڵ�
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ�������������</param>
        /// <returns>����Patient_Doc����</returns>
        private Patient_Doc[] GetSelectNodes(int textid)
        {
            Patient_Doc[] patient_Docs = null;
            if (currentPatient != null)
            {
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134��ǰ����
                             " and textkind_id in (select id from t_text where parentid=" + textid + ")  and submitted='Y' order by doc_name";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        //ȥ����ͬ������
                        int tid = 0;
                        patient_Docs = new Patient_Doc[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                            {
                                patient_Docs[i] = new Patient_Doc();
                                patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                                if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc==null)
                                {
                                    patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());                            
                                }
                                patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                                patient_Docs[i].Belongtosys_id = Convert.ToInt32(dt.Rows[i]["issi mpleinstance"].ToString());
                                patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                                patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                                tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            }
                        }
                    }
                }
            }
            return patient_Docs;

        }

        private void cboPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPatient = DataInit.GetInpatientInfoByPid(cboPatientName.SelectedValue.ToString());

            patient_Docs = GetSelectNodes(103);
            ucText = new frmText(0, 0, 0, "���̼�¼", -2, currentPatient, true);
            SpiltXml(patient_Docs, ucText, false);
            ucText.Dock = DockStyle.Fill;
            pnlDoc.Controls.Clear();
            pnlDoc.Controls.Add(ucText);
        }

        /// <summary>
        /// ƴ��xml�ļ�
        /// </summary>
        /// <param name="Contents">xml����</param>
        /// <param name="ucText">�༭��</param>
        /// <param name="flag">�����״β��̼�¼�Ƿ����ӽڵ�����</param>
        private void SpiltXml(Patient_Doc[] patient_Docs, frmText ucText, bool flag)
        {
            XmlDocument TempXml = new XmlDocument();
            TempXml.PreserveWhitespace = true;
            StringBuilder strBuilder = new StringBuilder();
            #region ���󲡳̼�¼û���ӽڵ�ƴ��xml
            
            for (int i = 0; i < patient_Docs.Length; i++)
            {
                if (patient_Docs[i] == null)
                    continue;
                XmlDocument ChildXml = new XmlDocument();
                ChildXml.PreserveWhitespace = true;
                ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                if (patient_Docs[i].Textkind_id == 136)    //�����״β��̼�¼�����ҳ��
                {
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//��������
                strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name + "' />");

                if (patient_Docs[i].Belongtosys_id == 1)
                {
                    //strBuilder.Append(@"<split textId = '" + patient_Docs[i].Id + "'/><p operatercreater='0' align='2'/>");
                }
                else
                {

                }
                {
                    // strBuilder.Append(@"<split textId = '" + patient_Docs[i].Textkind_id + "'/><p operatercreater='0' align='2'/>");
                }
            }
            //}
            #endregion

            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            ucText.MyDoc.ToXML(tempxmldoc.DocumentElement);

            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
            string ss = strBuilder.ToString();
            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            {
                if (bodyNode.Name == "body")
                {
                    bodyNode.InnerXml = strBuilder.ToString();
                }
            }

            ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);
            ucText.MyDoc.ContentChanged();
            ucText.Dock = DockStyle.Fill;

            ucText.MyDoc.Locked = true;
        }
    }
}