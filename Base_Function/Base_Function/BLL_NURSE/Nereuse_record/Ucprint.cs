using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.Reporting.WinForms;
using System.Collections;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_NURSE.Nereuse_record
{
    public partial class Ucprint : UserControl
    {
        private DataSet ds = null;
        private InPatientInfo inpatien = null;
        private string tid = "";
        ArrayList zds = new ArrayList();
        ArrayList list = new ArrayList();
        private string OT = "-";
        private string diagnose_name;//���
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        /// <summary>
        /// ���
        /// </summary>
        private string Diagnose = "";
        public Ucprint()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �������鲻ͬ��id�����ɱ����ļ�
        /// </summary>
        /// <param name="ds">����Դ</param>
        /// <param name="inpatientInfo">��ǰ������Ϣ</param>
        /// <param name="tid">����id</param>
        public Ucprint(DataSet ds,InPatientInfo inpatientInfo,string tid)
        {
            InitializeComponent();
            this.ds = ds;
            this.inpatien = inpatientInfo;
            this.tid = tid;
        }
        /// <summary>
        /// �������鲻ͬ��id�����ɱ����ļ�
        /// </summary>
        /// <param name="ds">����Դ</param>
        /// <param name="inpatientInfo">��ǰ������Ϣ</param>
        /// <param name="tid">����id</param>
        public Ucprint(DataSet ds, InPatientInfo inpatientInfo, string tid, string diagnose)
        {
            InitializeComponent();
            this.ds = ds;
            this.inpatien = inpatientInfo;
            this.tid = tid;
            if (diagnose != null && diagnose != "")
            {
                diagnose_name = diagnose;
            }
            else
            {
                diagnose_name = "";
            }
        }

        /// <summary>
        /// �����¼��
        /// </summary>
        /// <param name="dsitems"></param>
        /// <param name="patient"></param>
        /// <param name="diagnose"></param>
        /// <param name="pipe1"></param>
        /// <param name="pipe2"></param>
        /// <param name="pipe3"></param>
        /// <param name="pipe4"></param>
        public Ucprint(DataSet dsitems, string Tid, InPatientInfo patient, string diagnose, string pipe1, string pipe2, string pipe3, string pipe4, string pipe5)
        {
            InitializeComponent();
            ds = dsitems;
            this.inpatien = patient;
            if (diagnose != null && diagnose != "")
            {
                diagnose_name = diagnose;
            }
            else
            {
                diagnose_name = "";
            }
            tid = Tid;
            p1 = pipe1;
            p2 = pipe2;
            p3 = pipe3;
            p4 = pipe4;
            p5 = pipe5;
        }


        private void Ucprint_Load(object sender, EventArgs e)
        {
            try
            {
                //reportview��������
                DeletingStores isod = new DeletingStores();
                isod.DeleteIsoStores();
            }
            catch (System.Exception ex)
            {
                string bug = ex.Message;
            }
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count < 1)
                {
                    App.Msg("û�п��Դ�ӡ����Ϣ��");
                    return;
                }

            }
            else
            {
                App.Msg("û�п��Դ�ӡ����Ϣ��");
                return;
            }
            try
            {
                string strAge = inpatien.Age + inpatien.Age_unit;
                if (inpatien.Age == "" || inpatien.Age == "0")
                    strAge = inpatien.Child_age;
                if (tid == "2171")//�����¼��
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Nurse_records.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[14];
                    pams1[0] = new ReportParameter("PName", inpatien.Patient_Name);
                    pams1[1] = new ReportParameter("P_section", inpatien.Section_Name);
                    pams1[2] = new ReportParameter("P_sick", inpatien.Sick_Area_Name);
                    pams1[3] = new ReportParameter("P_bed", inpatien.Sick_Bed_Name);
                    pams1[4] = new ReportParameter("P_pid", inpatien.PId);
                    pams1[5] = new ReportParameter("P_age", strAge);
                    pams1[6] = new ReportParameter("P_intime", inpatien.In_Time.ToString("yyyy-MM-dd"));
                    pams1[7] = new ReportParameter("p_sex", inpatien.Gender_Code == "0" ? "��" : "Ů");
                    pams1[8] = new ReportParameter("Diagnose_name", diagnose_name);
                    pams1[9] = new ReportParameter("pipe1", p1);
                    pams1[10] = new ReportParameter("pipe2", p2);
                    pams1[11] = new ReportParameter("pipe3", p3);
                    pams1[12] = new ReportParameter("pipe4", p4);
                    pams1[13] = new ReportParameter("pipe5", p5);
                    reportViewer1.LocalReport.SetParameters(pams1);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_record", ds.Tables[0]));
                                     
                }
                else if (tid == "173") //��������¼
                {
                    reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_InOutMount.rdlc";
                    ReportParameter[] pams = new ReportParameter[4];
                    pams[0] = new ReportParameter("BedRoom", inpatien.Section_Name);
                    pams[1] = new ReportParameter("BedNumber", inpatien.Sick_Bed_Name);
                    pams[2] = new ReportParameter("UserName", inpatien.Patient_Name);
                    pams[3] = new ReportParameter("InPid", inpatien.PId);
                    reportViewer1.LocalReport.SetParameters(pams);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Inhospital_Info_Model_NuserInout_show", ds.Tables[0]));
                    reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.RefreshReport();

                }
                else if (tid == "172") //���¼�¼
                {
                }
                else if (tid == "118") //סԺ������ҳ
                {                  

                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\First_Cases.rdlc";

                    // �������Դ
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Info", ds.Tables[0]));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Diagnose", ds.Tables[1]));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Operation", ds.Tables[2]));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Quality", ds.Tables[3]));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Temp", ds.Tables[4]));
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_cover_patient_cost", ds.Tables[5]));
                    this.reportViewer1.RefreshReport();
                  
                }
                else if (tid == "561")
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Bgrecord.rdlc";
                    Class_Blood.GetBloods(ds, null, inpatien.Sick_Bed_Name, inpatien.Patient_Name, inpatien.PId, inpatien.Section_Name, inpatien.Sick_Area_Name, reportViewer1);
                }             
                else if (tid == "561") //Ѫ�Ǽ�ⵥ 
                {
                    string path = "file:///" + App.SysPath + @"\2.jpg";//ͼƬ��ַ                       
                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] pams = new ReportParameter[6];
                    pams[0] = new ReportParameter("Bed", inpatien.Sick_Bed_Name);
                    pams[1] = new ReportParameter("Name", inpatien.Patient_Name);
                    pams[2] = new ReportParameter("Hospital", inpatien.PId);
                    pams[3] = new ReportParameter("setion_name", inpatien.Section_Name);
                    pams[4] = new ReportParameter("sickarea_name", inpatien.Sick_Area_Name);
                    pams[5] = new ReportParameter("image1", path);
                    reportViewer1.LocalReport.SetParameters(pams);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Bgrecord_DateBgrecord", ds.Tables[0]));
                    this.reportViewer1.RefreshReport();
                }
                else if (tid == "1921") //���ư�Ļ���۲쵥
                {
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_nurse_observes.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[6];
                    pams1[0] = new ReportParameter("psection", inpatien.Section_Name);
                    pams1[1] = new ReportParameter("pbed", inpatien.Sick_Bed_Name);
                    pams1[2] = new ReportParameter("PName", inpatien.Patient_Name);
                    pams1[3] = new ReportParameter("pid", inpatien.PId);
                    pams1[4] = new ReportParameter("PSex", inpatien.Gender_Code);
                    pams1[5] = new ReportParameter("PAge", inpatien.Age.ToString());
                    reportViewer1.LocalReport.SetParameters(pams1);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1_NureserObserver", ds.Tables[0]));                  
                }
                else if (tid == "2177") //���ƻ����¼��
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Women_records.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[8];
                    pams1[0] = new ReportParameter("PName", inpatien.Patient_Name);
                    pams1[1] = new ReportParameter("P_section", inpatien.Section_Name);
                    pams1[2] = new ReportParameter("P_bed", inpatien.Sick_Bed_Name);
                    pams1[3] = new ReportParameter("P_pid", inpatien.PId);
                    pams1[4] = new ReportParameter("P_diagnose_name", diagnose_name);
                    pams1[5] = new ReportParameter("P_age", strAge);
                    pams1[6] = new ReportParameter("P_intime", inpatien.In_Time.ToString("yyyy-MM-dd"));
                    pams1[7] = new ReportParameter("P_sex", inpatien.Gender_Code == "0" ? "��" : "Ů");

                    reportViewer1.LocalReport.SetParameters(pams1);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_Record_ob", ds.Tables[0]));
                }
                else if (tid == "2174") //���ƻ����¼��
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Child_Nurse_Record.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[10];
                    pams1[0] = new ReportParameter("PName", inpatien.Patient_Name);
                    pams1[1] = new ReportParameter("P_section", inpatien.Section_Name);
                    pams1[2] = new ReportParameter("P_bed", inpatien.Sick_Bed_Name);
                    pams1[3] = new ReportParameter("P_pid", inpatien.PId);
                    pams1[4] = new ReportParameter("P_in", p1);
                    pams1[5] = new ReportParameter("P_out", p2);
                    pams1[6] = new ReportParameter("Diagnose_name", diagnose_name);
                    pams1[7] = new ReportParameter("P_age", strAge);
                    pams1[8] = new ReportParameter("P_intime", inpatien.In_Time.ToString("yyyy-MM-dd"));
                    pams1[9] = new ReportParameter("P_sex", inpatien.Gender_Code == "0" ? "��" : "Ů");
                    reportViewer1.LocalReport.SetParameters(pams1);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_Record_Ped", ds.Tables[0]));
                }
                else if (tid == "2299811") //�������ƻ����¼��
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Nurse_Record_NewBorn.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[8];
                    pams1[0] = new ReportParameter("pName", inpatien.Patient_Name);
                    pams1[1] = new ReportParameter("pSex", inpatien.Gender_Code == "0" ? "��" : "Ů");
                    pams1[2] = new ReportParameter("pSection", inpatien.Section_Name);
                    pams1[3] = new ReportParameter("pBed", inpatien.Sick_Bed_Name);
                    pams1[4] = new ReportParameter("pPid", inpatien.PId);
                    pams1[5] = new ReportParameter("pAge", strAge);
                    pams1[6] = new ReportParameter("pIntime", inpatien.In_Time.ToString("yyyy-MM-dd"));
                    pams1[7] = new ReportParameter("pDiagnose_name", diagnose_name);
                    reportViewer1.LocalReport.SetParameters(pams1);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_Nurse_Record_NewBorn", ds.Tables[0]));
                }
                // ���ÿؼ�����ʾģʽΪ��ӡ����ģʽ(�����ҳ��ӡ���ȵ��һ�²���,����ᶪʧ��ҳ)
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;   
            }
            catch(Exception ex)
            {
                App.MsgErr("��ӡ���ʧ�ܣ�ԭ��"+ex.Message);
            }
        }
    }
}
