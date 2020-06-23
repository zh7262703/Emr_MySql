using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmTurnToDie_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dt = new DataTable();//���ݱ�
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public frmTurnToDie_PatientInfo()
        {
            InitializeComponent();
        }

        public frmTurnToDie_PatientInfo(DataTable dt, DataTable dt_inDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            flgView.AllowEditing = false;
            dt.Columns[0].ColumnName = "���";
            dt.Columns[1].ColumnName = "����";
            dt.Columns[2].ColumnName = "סԺ��";
            dt.Columns[3].ColumnName = "����";
            dt.Columns[4].ColumnName = "�Ա�";
            dt.Columns[5].ColumnName = "����";
            dt.Columns[6].ColumnName = "��ͥ��ַ";
            dt.Columns[7].ColumnName = "�໤������";
            dt.Columns[8].ColumnName = "��Ժʱ��";
            dt.Columns[9].ColumnName = "��Ժ���";
            dt.Columns[10].ColumnName = "����ԭ��";
            dt.Columns[11].ColumnName = "����ʱ��";
            dt.Columns[12].ColumnName = "����ҽ��";

            flgView.DataSource = dt;

            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["sick_area_id"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            string[] patientsId = new string[dt.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "���"].ToString(); //dt.Rows[i]["����ID"].ToString();
            }
            //������Ժ���
            SetInDiagnose(patientsId, dt_inDiag);
            //��������ԭ��ʱ��
            SetDieReason(patientsId);
        }

        /// <summary>
        /// ��������ԭ��
        /// ˼·����ȡ������¼���飬�����ڵ�õ�����ԭ��
        /// </summary>
        public void SetDieReason(string[] patientsId)
        {
            string strPid = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                if (strPid == "")
                {
                    strPid += patientsId[i];
                }
                else
                {
                    strPid +=","+ patientsId[i];
                }

            }
            string sql_die = "select patient_id,patients_doc from t_patients_doc where textkind_id=138 and patient_id in(" + strPid + ")";
            DataSet ds = App.GetDataSet(sql_die);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string patientid = dt.Rows[i]["patient_id"].ToString();//����ID
                    string patientDoc = dt.Rows[i]["patients_doc"].ToString();//��������
                    //����XML���󣬼�����������
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(patientDoc);
                    XmlNodeList xmlListDiv = xml.GetElementsByTagName("div");
                    //����xml�е�ÿ��DIV��ǩ���ҵ�����ԭ��
                    foreach (XmlNode divNode in xmlListDiv)
                    {
                        if (divNode.Attributes["title"].Value.ToString().Contains("����ԭ��"))
                        {
                            string dieReason = "";//����ԭ��
                            //��������ԭ��ڵ㣬������ԭ�������ƴ�ӳ��ַ���
                            foreach (XmlNode spanNode in divNode)
                            {
                                dieReason += spanNode.InnerText;
                            }
                            for (int j = 0; j < flgView.Rows.Count; j++)
                            {
                                if (flgView.Rows[j]["���"].ToString()==patientid)
                                {
                                    flgView[j, "����ԭ��"] = dieReason;
                                    break;
                                }
                            }
                        }
                    }
                    XmlNodeList xmlListInput = xml.GetElementsByTagName("input");
                    //������ʱ��
                    foreach (XmlNode inputNode in xmlListInput)
                    {
                        string dieTime = "";//��������
                        if (inputNode.Attributes["id"].Value == "��������")
                        {
                            foreach (XmlNode spanNode in inputNode)
                            {
                                dieTime += spanNode.InnerText;
                            }
                            for (int j = 0; j < flgView.Rows.Count; j++)
                            {
                                if (flgView.Rows[j]["���"].ToString() == patientid)
                                {
                                    flgView[j, "����ʱ��"] = dieTime;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// ������Ժ���
        /// ˼·��1������Ժ��ϱ����ҳ�patient_Id��Ӧ�����
        ///        �����0������ʾ�գ�1��ֱ����ʾ�����
        ///        �������1����(1)���ҳ�������ϵĴ���ʱ�䣬�ŵ�List<DateTime>�У���������
        ///                     (2)ѭ���ҳ�DataRow[]�д���ʱ����ͬ����ϣ���������
        ///        
        /// </summary>
        /// <param name="patientsId">��������ID����</param>
        /// <param name="dt_allinDiag">������Ժ��ϵı�</param>
        public void SetInDiagnose(string[] patientsId, DataTable dt_allinDiag)
        {
            string diagNoseSort = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                DataRow[] dr_inDiag = dt_allinDiag.Select("patient_id=" + patientsId[i]);
                if (dr_inDiag.Length == 1)//ֻ��һ����Ժ���
                {
                    flgView[i + 1, "��Ժ���"] = dr_inDiag[0]["diagnose_name"].ToString();
                }
                else if (dr_inDiag.Length == 0)//û����Ժ���
                {
                    flgView[i + 1, "��Ժ���"] = "";
                }
                else //������Ժ��ϣ������ж�diagnose_sort��ֵ�������Ϊ�գ�����ϵĴ���ʱ����������
                {
                    for (int j = 0; j < dr_inDiag.Length; j++)
                    {
                        diagNoseSort = dr_inDiag[j]["diagnose_sort"].ToString();
                        if (diagNoseSort == "1")//1����ʾ�����
                        {
                            flgView[i + 1, "��Ժ���"] = dr_inDiag[j]["diagnose_sort"].ToString();
                        }
                    }
                    if (diagNoseSort == "")//��ʱ�������ţ�ȡ���紴�������
                    {
                        //������ʱ��ȡ�������浽List��
                        List<DateTime> list = new List<DateTime>();
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            list.Add(Convert.ToDateTime(dr_inDiag[j]["create_time"]));
                        }
                        list.Sort();
                        //�ҵ�ʱ���������ϣ�������
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            if (Convert.ToDateTime(dr_inDiag[j]["create_time"]) == list[0])
                            {
                                flgView[i + 1, "��Ժ���"] = dr_inDiag[j]["diagnose_name"].ToString();
                            }
                        }

                    }
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = CreateDataSetWidthFlexGrid(this.flgView);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmTurnToDie_Print fp = new frmTurnToDie_Print(ds,frmTurnToDie_PatientInfo.sectionName,frmTurnToDie_PatientInfo.beginTime,frmTurnToDie_PatientInfo.endTime);
                    fp.Show();
                }
            }
        }

        /// <summary>
        /// �����ת�������ݼ�
        /// </summary>
        /// <param name="fg"></param>
        /// <returns></returns>
        private static DataSet CreateDataSetWidthFlexGrid(C1FlexGrid fg)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            //������
            for (int i = 1; i < fg.Cols.Count; i++)
            {
                DataColumn dc;
                dc = new DataColumn(fg.Cols[i][0].ToString());
                dt.Columns.Add(dc);
            }

            //�����У�������
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].NewRow();
                for (int j = 1; j < fg.Cols.Count; j++)
                {
                    dr[j-1] = fg.Rows[i][j].ToString();
                }
                ds.Tables[0].Rows.Add(dr);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["��Ժʱ��"] = ds.Tables[0].Rows[i]["��Ժʱ��"].ToString().Split(' ')[0];
                //ds.Tables[0].Rows[i]["��Ժʱ��"] = ds.Tables[0].Rows[i]["��Ժʱ��"].ToString().Split(' ')[0];
            }
            return ds;
        } 


    }
}