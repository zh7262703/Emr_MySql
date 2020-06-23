using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmInOut_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {

        DataTable dt = new DataTable();//���ݱ�
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public static string titleName = "";
        public frmInOut_PatientInfo()
        {
            InitializeComponent();
        }
        public frmInOut_PatientInfo(DataTable dt_info)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            btnPrint.Visible = false;
            DataTable dt = new DataTable();
            dt = dt_info;
            if (dt != null)
            {
                dt.Columns[0].ColumnName = "����ID";
                dt.Columns[1].ColumnName = "����";
                dt.Columns[2].ColumnName = "סԺ��";
                //dt.Columns[3].ColumnName = "����";
                dt.Columns[4].ColumnName = "�Ա�";
                dt.Columns[5].ColumnName = "��Ժʱ��";
                dt.Columns[6].ColumnName = "����ID";
                dt.Columns[7].ColumnName = "��������";
                dt.Columns[8].ColumnName = "����ID";
                dt.Columns[9].ColumnName = "��������";
                flgView.DataSource = dt;
                flgView.AllowEditing = false;
                flgView.Cols["birthday"][0] = "����";
            }
        }

        public frmInOut_PatientInfo(DataTable dt,DataTable dt_inDiag,DataTable dt_outDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            dt.Columns[0].ColumnName = "���";
            dt.Columns[1].ColumnName = "סԺ��";
            dt.Columns[2].ColumnName = "����";
            dt.Columns[3].ColumnName = "�Ա�";
            dt.Columns[4].ColumnName = "����";
            dt.Columns[5].ColumnName = "��Ժʱ��";
            dt.Columns[6].ColumnName = "��Ժʱ��";
            dt.Columns[7].ColumnName = "��Ժ���";
            dt.Columns[8].ColumnName = "��Ժ���";
            dt.Columns[9].ColumnName = "��Ժ����";
            dt.Columns[10].ColumnName = "��Ժ����";
            flgView.DataSource= dt;
            flgView.AllowEditing = false;//a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name
            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["SICK_AREA_ID"].Visible = false;
            flgView.Cols["SICK_AREA_name"].Visible = false;

            string[] patientsId = new string[dt.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "���"].ToString(); //dt.Rows[i]["����ID"].ToString();
            }
            //������Ժ���
            SetInDiagnose(patientsId, dt_inDiag);
            //������Ժ���
            SetOutDiagnose(patientsId, dt_outDiag);
            if (beginTime=="" || endTime == "")
            {
                btnPrint.Visible = false;
            }
        }

        private void frmTheday_PatientInfo_Load(object sender, EventArgs e)
        {

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

        public void SetOutDiagnose(string[] patientsId, DataTable dt_alloutDiag)
        {
            string diagNoseSort = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                DataRow[] dr_outDiag = dt_alloutDiag.Select("patient_id=" + patientsId[i]);
                if (dr_outDiag.Length == 1)//ֻ��һ����Ժ���
                {
                    flgView[i + 1, "��Ժ���"] = dr_outDiag[0]["diagnose_name"].ToString();
                }
                else if (dr_outDiag.Length == 0)//û�г�Ժ���
                {
                    flgView[i + 1, "��Ժ���"] = "";
                }
                else //������Ժ��ϣ������ж�diagnose_sort��ֵ�������Ϊ�գ�����ϵĴ���ʱ����������
                {
                    for (int j = 0; j < dr_outDiag.Length; j++)
                    {
                        diagNoseSort = dr_outDiag[j]["diagnose_sort"].ToString();
                        if (diagNoseSort == "1")//1����ʾ�����
                        {
                            flgView[i + 1, "��Ժ���"] = dr_outDiag[j]["diagnose_sort"].ToString();
                        }
                    }
                    if (diagNoseSort == "")//��ʱ�������ţ�ȡ���紴�������
                    {
                        //������ʱ��ȡ�������浽List��
                        List<DateTime> list = new List<DateTime>();
                        for (int j = 0; j < dr_outDiag.Length; j++)
                        {
                            list.Add(Convert.ToDateTime(dr_outDiag[j]["create_time"]));
                        }
                        list.Sort();
                        //�ҵ�ʱ���������ϣ�������
                        for (int j = 0; j < dr_outDiag.Length; j++)
                        {
                            if (Convert.ToDateTime(dr_outDiag[j]["create_time"]) == list[0])
                            {
                                flgView[i + 1, "��Ժ���"] = dr_outDiag[j]["diagnose_name"].ToString();
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
                    frmInOut_Print fp = new frmInOut_Print(ds, frmInOut_PatientInfo.sectionName, frmInOut_PatientInfo.beginTime, frmInOut_PatientInfo.endTime, frmInOut_PatientInfo.titleName);
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
                    dr[j - 1] = fg.Rows[i][j].ToString();
                }
                ds.Tables[0].Rows.Add(dr);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["��Ժʱ��"] = ds.Tables[0].Rows[i]["��Ժʱ��"].ToString().Split(' ')[0];
                ds.Tables[0].Rows[i]["��Ժʱ��"] = ds.Tables[0].Rows[i]["��Ժʱ��"].ToString().Split(' ')[0];
            }
            return ds;
        } 
    }
}