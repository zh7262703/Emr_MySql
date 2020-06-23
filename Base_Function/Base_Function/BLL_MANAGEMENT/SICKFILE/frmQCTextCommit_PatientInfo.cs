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
    public partial class frmQCTextCommit_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        public frmQCTextCommit_PatientInfo()
        {
            InitializeComponent();
        }
        public frmQCTextCommit_PatientInfo(DataTable dt_info, DataTable dt_allinDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);

            flgView.DataSource = dt_info;
            flgView.AllowEditing = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["SICK_AREA_ID"].Visible = false;
            flgView.Cols["SICK_AREA_name"].Visible = false;
            flgView.Cols["����"].Visible = false;
            flgView.Cols["����ID"].Visible = false;
            flgView.Cols["��Ժ���"].Width = 300;

            string[] patientsId = new string[dt_info.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "����ID"].ToString(); //dt.Rows[i]["����ID"].ToString();
            }
            //������Ժ���
            SetInDiagnose(patientsId, dt_allinDiag);
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
            saveFileDialog1.FileName = "�ʿذ��������ͳ����ϸ�б�.xls";
            saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            flgView.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        }
    }
}