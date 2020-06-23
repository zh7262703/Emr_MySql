using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nereuse_record
{
    public partial class frmNursePrint_Records : DevComponents.DotNetBar.Office2007Form
    {
        private string PrintType = "N"; //N ��ʿ O���� C ��ͯ B ������
        private string pname;
        private string section;
        private string p_sick;
        private string bed_no;
        private string pid;
        private string his_id;  //������
        private string age;     //��ȡ��������
        private string sex;     //�Ա�
        private string intime;  //סԺʱ��
        private string diagnose_name;//���
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        /// <summary>
        /// ��������
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Section
        {
            get { return section; }
            set { section = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string P_sick
        {
            get { return p_sick; }
            set { p_sick = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Bed_no
        {
            get { return bed_no; }
            set { bed_no = value; }
        }
        /// <summary>
        /// סԺ��
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string His_id
        {
            get { return his_id; }
            set { his_id = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// ��Ժʱ��
        /// </summary>
        public string Intime
        {
            get { return intime; }
            set { intime = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public string Diagnose_name
        {
            get { return diagnose_name; }
            set { diagnose_name = value; }
        }


        DataSet dsItems = new DataSet();
        DataSet dsPatients = new DataSet();
        InPatientInfo patient;

        public frmNursePrint_Records()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Σ�ش�ӡ
        /// </summary>, string age)
        /// <param name="dsitems"></param>
        /// <param name="dspatients"></param>
        /// <param name="pidname">��������</param>
        /// <param name="section">�Ʊ�</param>
        /// <param name="sick">����</param>
        /// <param name="bed_no">����</param>
        /// <param name="pid">סԺ��</param>
        public frmNursePrint_Records(DataSet dsitems, DataSet dspatients, string pidname, string section, string sick, string bed_no, string pid, string diagnose)
        {
            InitializeComponent();
            dsItems = dsitems;
            Pname = pidname;
            Section = section;
            P_sick = sick;
            Pid = pid;
            Bed_no = bed_no;
            //Diagnose_name = diagnose;
            if (diagnose != null && diagnose != "")
            {
                Diagnose_name = diagnose;
            }
            else
            {
                Diagnose_name = "";
            }

            //��ȡ���䣬�Ա�Ȼ�����Ϣ
            DataSet ds = App.GetDataSet("select t.HIS_ID,t.gender_code,t.age,t.age_unit,t.in_time from t_in_patient t where t.pid='" + pid + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    His_id = ds.Tables[0].Rows[0]["HIS_ID"].ToString();
                    Age = ds.Tables[0].Rows[0]["age"].ToString() + ds.Tables[0].Rows[0]["age_unit"].ToString();
                    if (Age.Trim() == "")
                    {
                        Age = "0��";
                    }

                    if (ds.Tables[0].Rows[0]["gender_code"].ToString() == "0")
                    {
                        Sex = "��";
                    }
                    else
                    {
                        Sex = "Ů";
                    }

                    if (ds.Tables[0].Rows[0]["in_time"] != null)
                    {
                        if (ds.Tables[0].Rows[0]["in_time"].ToString().Trim() != "")
                            Intime = Convert.ToDateTime(ds.Tables[0].Rows[0]["in_time"].ToString()).ToShortDateString();
                    }

                }
            }
        }

        /// <summary>
        /// �����¼��
        /// </summary>, string age)
        /// <param name="dsitems"></param>
        /// <param name="dspatients"></param>
        /// <param name="pidname">��������</param>
        /// <param name="section">�Ʊ�</param>
        /// <param name="sick">����</param>
        /// <param name="bed_no">����</param>
        /// <param name="pid">סԺ��</param>
        public frmNursePrint_Records(DataSet dsitems, InPatientInfo patient, string diagnose, string pipe1, string pipe2, string pipe3, string pipe4, string pipe5)
        {
            InitializeComponent();
            dsItems = dsitems;
            this.patient = patient;
            //diagnose_name = diagnose;
            if (diagnose != null && diagnose != "")
            {
                diagnose_name = diagnose;
            }
            else
            {
                diagnose_name = "";
            }
            p1 = pipe1;
            p2 = pipe2;
            p3 = pipe3;
            p4 = pipe4;
            p5 = pipe5;
        }
        /// <summary>
        /// ���ƻ����¼��
        /// </summary>, string age)
        /// <param name="dsitems"></param>
        /// <param name="dspatients"></param>
        /// <param name="pidname">��������</param>
        /// <param name="section">�Ʊ�</param>
        /// <param name="sick">����</param>
        /// <param name="bed_no">����</param>
        /// <param name="pid">סԺ��</param>
        public frmNursePrint_Records(DataSet dsitems, InPatientInfo patient,string diagnose, string Type, string pipe1, string pipe2)
        {
            InitializeComponent();
            dsItems = dsitems;
            this.patient = patient;
            //diagnose_name = diagnose;
            if (diagnose != null && diagnose != "")
            {
                diagnose_name = diagnose;
            }
            else
            {
                diagnose_name = "";
            }
            PrintType = Type; //���Ʊ��
            p1 = pipe1;
            p2 = pipe2;
        }
        /// <summary>
        /// �������ƻ����¼��
        /// </summary>
        /// <param name="dsitems"></param>
        /// <param name="patient"></param>
        /// <param name="Type"></param>
        public frmNursePrint_Records(DataSet dsitems, string diagnose, InPatientInfo patient, string Type)
        {
            InitializeComponent();
            dsItems = dsitems;
            //diagnose_name = diagnose;
            if (diagnose != null && diagnose != "")
            {
                diagnose_name = diagnose;
            }
            else
            {
                diagnose_name = "";
            }
            this.patient = patient;
            PrintType = Type; 
        }

        private void frmNursePrint_Records_Load(object sender, EventArgs e)
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
            
            if (dsItems != null)
            {
                if (dsItems.Tables.Count > 0)
                {
                    string strAge = patient.Age + patient.Age_unit;
                    if (patient.Age == "" || patient.Age == "0")
                        strAge = patient.Child_age;

                    if (PrintType == "N")
                    {
                        reportViewer1.LocalReport.DataSources.Clear();                      
                        this.reportViewer1.RefreshReport();
                        this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Nurse_records.rdlc";
                        ReportParameter[] pams1 = new ReportParameter[14];
                        //��ӡ�����ݱ�ͷ�����¼��:patient.Patient_Name=patient.Section_Name=patient.Sick_Area_Name=patient.Sick_Bed_Name=patient.PId=patient.Age=patient.Age_unit=""
                        pams1[0] = new ReportParameter("PName", patient.Patient_Name);
                        pams1[1] = new ReportParameter("P_section", patient.Section_Name);
                        pams1[2] = new ReportParameter("P_sick", patient.Sick_Area_Name);
                        pams1[3] = new ReportParameter("P_bed", patient.Sick_Bed_Name);
                        pams1[4] = new ReportParameter("P_pid", patient.PId);
                        pams1[5] = new ReportParameter("P_age", strAge);
                        pams1[6] = new ReportParameter("P_intime", patient.In_Time.ToString("yyyy-MM-dd"));
                        pams1[7] = new ReportParameter("p_sex", patient.Gender_Code == "0" ? "��" : "Ů");
                        pams1[8] = new ReportParameter("Diagnose_name", diagnose_name);
                        pams1[9] = new ReportParameter("pipe1", p1);
                        pams1[10] = new ReportParameter("pipe2", p2);
                        pams1[11] = new ReportParameter("pipe3", p3);
                        pams1[12] = new ReportParameter("pipe4", p4);
                        pams1[13] = new ReportParameter("pipe5", p5);
                        reportViewer1.LocalReport.SetParameters(pams1);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_record", dsItems.Tables[0]));
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        this.reportViewer1.ZoomMode = ZoomMode.Percent;
                        this.reportViewer1.ZoomPercent = 100;                      
                    }
                    else if (PrintType == "O")
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        this.reportViewer1.RefreshReport();
                        this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Women_records.rdlc";
                        ReportParameter[] pams1 = new ReportParameter[8];
                        pams1[0] = new ReportParameter("PName", patient.Patient_Name);
                        pams1[1] = new ReportParameter("P_section", patient.Section_Name);
                        pams1[2] = new ReportParameter("P_bed", patient.Sick_Bed_Name);
                        pams1[3] = new ReportParameter("P_pid", patient.PId);
                        pams1[4] = new ReportParameter("P_diagnose_name", diagnose_name);
                        pams1[5] = new ReportParameter("P_age", strAge);
                        pams1[6] = new ReportParameter("P_intime", patient.In_Time.ToString("yyyy-MM-dd"));
                        pams1[7] = new ReportParameter("P_sex", patient.Gender_Code == "0" ? "��" : "Ů");
                        reportViewer1.LocalReport.SetParameters(pams1);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_Record_ob", dsItems.Tables[0]));
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        this.reportViewer1.ZoomMode = ZoomMode.Percent;
                        this.reportViewer1.ZoomPercent = 100;
                    }
                    else if (PrintType == "C")
                    {
                        reportViewer1.LocalReport.DataSources.Clear();                       
                        this.reportViewer1.RefreshReport();
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Child_Nurse_Record.rdlc";
                        ReportParameter[] pams1 = new ReportParameter[10];
                        pams1[0] = new ReportParameter("PName", patient.Patient_Name);
                        pams1[1] = new ReportParameter("P_section", patient.Section_Name);
                        pams1[2] = new ReportParameter("P_bed", patient.Sick_Bed_Name);
                        pams1[3] = new ReportParameter("P_pid", patient.PId);
                        pams1[4] = new ReportParameter("P_in", p1);
                        pams1[5] = new ReportParameter("P_out", p2);
                        pams1[6] = new ReportParameter("Diagnose_name",diagnose_name);
                        pams1[7] = new ReportParameter("P_age", strAge);
                        pams1[8] = new ReportParameter("P_intime", patient.In_Time.ToString("yyyy-MM-dd"));
                        pams1[9] = new ReportParameter("P_sex", patient.Gender_Code == "0" ? "��" : "Ů");
                        reportViewer1.LocalReport.SetParameters(pams1);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_Record_Ped", dsItems.Tables[0]));
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        this.reportViewer1.ZoomMode = ZoomMode.Percent;
                        this.reportViewer1.ZoomPercent = 100;                      
                    }
                    else if (PrintType == "B")
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        this.reportViewer1.RefreshReport();
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Nurse_Record_NewBorn.rdlc";
                        ReportParameter[] pams1 = new ReportParameter[8];
                        pams1[0] = new ReportParameter("pName", patient.Patient_Name);
                        pams1[1] = new ReportParameter("pSex", patient.Gender_Code == "0" ? "��" : "Ů");
                        pams1[2] = new ReportParameter("pSection", patient.Section_Name);
                        pams1[3] = new ReportParameter("pBed", patient.Sick_Bed_Name);
                        pams1[4] = new ReportParameter("pPid", patient.PId);
                        pams1[5] = new ReportParameter("pAge", strAge);
                        pams1[6] = new ReportParameter("pIntime", patient.In_Time.ToString("yyyy-MM-dd"));
                        pams1[7] = new ReportParameter("pDiagnose_name", diagnose_name);
                        reportViewer1.LocalReport.SetParameters(pams1);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_Nurse_Record_NewBorn", dsItems.Tables[0]));
                        this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        this.reportViewer1.ZoomMode = ZoomMode.Percent;
                        this.reportViewer1.ZoomPercent = 100;
                    }
                }
            }
        }

        private void reportViewer1_Print(object sender, CancelEventArgs e)
        {          
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}