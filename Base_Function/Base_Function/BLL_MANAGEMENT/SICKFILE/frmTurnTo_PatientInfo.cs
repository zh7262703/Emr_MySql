using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.ReportingServices.ReportRendering;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmTurnTo_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        public frmTurnTo_PatientInfo()
        {
            InitializeComponent();
        }

        public frmTurnTo_PatientInfo(DataTable dt, DataTable dt_allinDiag, DataTable dt_alloutDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            this.flgView.AllowEditing = false;
            dt.Columns[0].ColumnName = "����ID";
            dt.Columns[1].ColumnName = "����";
            dt.Columns[2].ColumnName = "סԺ��";
            dt.Columns[3].ColumnName = "����";
            dt.Columns[4].ColumnName = "�Ա�";
            dt.Columns[5].ColumnName = "����ID";
            dt.Columns[6].ColumnName = "��������";
            dt.Columns[7].ColumnName = "����ID";
            dt.Columns[8].ColumnName = "��������";
            dt.Columns[9].ColumnName = "��Ժʱ��";
            dt.Columns[10].ColumnName = "��Ժʱ��";
            dt.Columns[11].ColumnName = "�ܴ�ҽ��ID";
            dt.Columns[12].ColumnName = "�ܴ�ҽ������";
            //dt.Columns[13].ColumnName = "��Ժ���";
            //dt.Columns[14].ColumnName = "��Ժ���ʱ��";
            //dt.Columns[15].ColumnName = "��Ժ��ϴ���";
            //dt.Columns[16].ColumnName = "��Ժ���";
            //dt.Columns[17].ColumnName = "��Ժ���ʱ��";
            //dt.Columns[18].ColumnName = "��Ժ��ϴ���";
            flgView.DataSource = dt;
            flgView.Cols["����ID"].Visible = false;
            flgView.Cols["����ID"].Visible = false;
            flgView.Cols["����ID"].Visible = false;
            flgView.Cols["�ܴ�ҽ��ID"].Visible = false;
            //flgView.Cols["��Ժ���ʱ��"].Visible = false;
            //flgView.Cols["��Ժ��ϴ���"].Visible = false;
            //flgView.Cols["��Ժ���ʱ��"].Visible = false;
            //flgView.Cols["��Ժ��ϴ���"].Visible = false;
            string[] patientsId = new string[dt.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i+1,"����ID"].ToString(); //dt.Rows[i]["����ID"].ToString();
            }
            //������Ժ���
            SetInDiagnose(patientsId, dt_allinDiag);
            //������Ժ���
            SetOutDiagnose(patientsId, dt_alloutDiag);
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
                            if (Convert.ToDateTime(dr_inDiag[j]["create_time"])==list[0])
                            {
                                flgView[i+1, "��Ժ���"] = dr_inDiag[j]["diagnose_name"].ToString();
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
                                flgView[i+1, "��Ժ���"] = dr_outDiag[j]["diagnose_name"].ToString();
                            }
                        }

                    }
                }
            }

        }
    }
}