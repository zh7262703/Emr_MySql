using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Microsoft.Reporting.WinForms;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.BLL_DOCTOR.AppForm
{
    public partial class frmCheckNurseRecord : DevComponents.DotNetBar.Office2007Form
    {

        private InPatientInfo currentPatient = null;
        /// <summary>
        /// ��ʾ��ӡ����
        /// </summary>
        ArrayList nusers_Print = new ArrayList();

        /// <summary>
        /// �������
        /// </summary>
        private string Diagnose = "";
        public frmCheckNurseRecord()
        {
            InitializeComponent();
        }

        private void frmCheckNurseRecord_Load(object sender, EventArgs e)
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
            this.reportViewer1.RefreshReport();
        }

        private void cboPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPatient = DataInit.GetInpatientInfoByPid(cboPatientName.SelectedValue.ToString());
            DataSet ds = GetNusersRecords(ref Diagnose);
            reportViewer1.LocalReport.DataSources.Clear();
            if (ds!=null)
            {
                try
                {
                    string Sex = "";
                    if (currentPatient.Gender_Code == "0")
                    {
                        Sex = "��";
                    }
                    else if (currentPatient.Gender_Code == "1")
                    {
                        Sex = "Ů";
                    }
                    else
                    {
                        Sex = currentPatient.Gender_Code;
                    }
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + @"\ReportFile\Report_Nurse_records.rdlc";
                    ReportParameter[] pams1 = new ReportParameter[8];
                    pams1[0] = new ReportParameter("PName", currentPatient.Patient_Name);
                    pams1[1] = new ReportParameter("P_section", currentPatient.Section_Name);
                    pams1[2] = new ReportParameter("P_sick", currentPatient.Sick_Area_Name);
                    pams1[3] = new ReportParameter("P_bed", currentPatient.Sick_Bed_Name);
                    pams1[4] = new ReportParameter("P_pid", currentPatient.PId);
                    pams1[5] = new ReportParameter("P_age", currentPatient.Age+currentPatient.Age_unit);
                    pams1[6] = new ReportParameter("P_intime", Convert.ToDateTime(currentPatient.In_Time.ToString()).ToShortDateString());
                    pams1[7] = new ReportParameter("p_sex", Sex);
                    reportViewer1.LocalReport.SetParameters(pams1);
                    //reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_record", ds.Tables[0]));
                    reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                }
                catch (Exception ex)
                {
                    App.Msg(ex.Message);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                string Sex = "";
                if (currentPatient.Gender_Code == "0")
                {
                    Sex = "��";
                }
                else if (currentPatient.Gender_Code == "1")
                {
                    Sex = "Ů";
                }
                else
                {
                    Sex = currentPatient.Gender_Code;
                } //currentPatient.Gender_Code == "0" ? "��" : "Ů";
                this.reportViewer1.LocalReport.ReportPath = App.SysPath + @"\ReportFile\Report_Nurse_records.rdlc";
                ReportParameter[] pams1 = new ReportParameter[8];
                pams1[0] = new ReportParameter("PName", currentPatient.Patient_Name);
                pams1[1] = new ReportParameter("P_section", currentPatient.Section_Name);
                pams1[2] = new ReportParameter("P_sick", currentPatient.Sick_Area_Name);
                pams1[3] = new ReportParameter("P_bed", currentPatient.Sick_Bed_Name);
                pams1[4] = new ReportParameter("P_pid", currentPatient.PId);
                pams1[5] = new ReportParameter("P_age", currentPatient.Age + currentPatient.Age_unit);
                pams1[6] = new ReportParameter("P_intime", Convert.ToDateTime(currentPatient.In_Time.ToString()).ToShortDateString());
                pams1[7] = new ReportParameter("p_sex", Sex);
                reportViewer1.LocalReport.SetParameters(pams1);
                //reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Nurse_Record_DataTable_nurse_record", dt));
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;
            }
        }

        /// <summary>
        /// /��ȡ��¼�����ݼ�
        /// </summary>
        /// <returns></returns>
        public DataSet GetNusersRecords(ref string diagnose)
        {
            try
            {

                ShowDatas(ref diagnose);

                //����
                string TempDate = null;
                //ʱ��
                string time = null;

                //RefleshEnterLines();
                Class_Nurse_records[] Nusers_objs = new Class_Nurse_records[nusers_Print.Count];
                for (int i = 0; i < nusers_Print.Count; i++)
                {
                    Nusers_objs[i] = new Class_Nurse_records();
                    Nusers_objs[i] = (Class_Nurse_records)nusers_Print[i];
                    Nusers_objs[i].Age = Convert.ToString(i / 11);
                }
                DataSet ds = App.ObjectArrayToDataSet(Nusers_objs);
                return ds
                    ;
            }
            catch
            {
                return null;
            }
        }
        //��ӡ��ʾ�������
        public void ShowDatas(ref string diagnose)
        {
            //���Nusers�����е�����
            nusers_Print.Clear();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd') as DATEVAL,to_char(t.measure_time,'hh24:mi:ss.ff9') as TIMERVAR,t.item_code,a.item_name,a.item_attribute,t.item_value,t.c_state,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name from t_nurse_record t " +
                             " left join t_nurse_record_dict a on a.item_code=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                             " join T_ACCOUNT_USER c on t.creat_id=c.account_id inner join T_USERINFO d on d.user_id=c.user_id where  RECORD_TYPE in ('D',null)  and patient_Id=" + cboPatientName.SelectedValue.ToString() + " and to_char(t.measure_time,'yyyy-MM-dd')='" + date + "'  order by t.measure_time asc";//" order by t.measure_time asc";

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd') as DATEVAL,to_char(t.measure_time,'hh24:mi:ss.ff9') as TIMERVAR from t_nurse_record t where  RECORD_TYPE in ('D',null)  and  t.patient_Id=" + cboPatientName.SelectedValue.ToString() + " order by DATEVAL,TIMERVAR";

            //ʱ�伯��
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            DataSet ds_value_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_value_sets.Tables[0];

            if (dt_sets.Rows[0]["diagnose_name"] != null)
            {
                diagnose = dt_sets.Rows[0]["diagnose_name"].ToString();
            }
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string DateVale = Convert.ToDateTime(dt_time.Rows[i]["DATEVAL"].ToString()).ToString("yyyy-MM-dd");
                    string TimeValue = dt_time.Rows[i]["TIMERVAR"].ToString();

                    //Σ�ص���ؼ�¼����

                    DataRow[] dt_sets_rows_byconditions = dt_sets.Select("DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");

                    //����
                    DataRow[] inrows = dt_sets.Select("item_type=96 and DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");

                    //����
                    DataRow[] outrows = dt_sets.Select("item_type=97 and DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");

                    //����
                    DataRow[] oxygenrows = dt_sets.Select("item_type=927 and DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");

                    //��·���
                    DataRow[] gulurows = dt_sets.Select("item_type=932 and DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");

                    //����ʳƷҩƷ������·����ĸ�������������
                    int maxrow = MaxRowCount(inrows.Length, outrows.Length, oxygenrows.Length, gulurows.Length);

                    if (maxrow == 0)
                        maxrow = 1;
                    for (int k = 0; k < maxrow; k++)
                    {
                        Class_Nurse_records temp = new Class_Nurse_records();
                        temp.Date = DateVale;
                        temp.Time = TimeValue;
                        //�Ƕ�����
                        if (k == 0)
                        {
                            //����                            
                            if (k < inrows.Length && inrows.Length > 0)
                            {
                                if (inrows[k]["other_name"].ToString() != "")
                                {
                                    temp.R_item_name = inrows[k]["other_name"].ToString();
                                    temp.R_item_count = inrows[k]["item_value"].ToString();
                                }
                                else
                                {
                                    temp.R_item_name = inrows[k]["item_name"].ToString();
                                    temp.R_item_count = inrows[k]["item_value"].ToString();
                                }
                            }
                            //����
                            if (k < outrows.Length && outrows.Length > 0)
                            {
                                if (outrows[k]["other_name"].ToString() != "")
                                {
                                    //temp.C_item_name = outrows[k]["other_name"].ToString();
                                    //temp.C_item_count = outrows[k]["item_value"].ToString();
                                }
                                else
                                {
                                    //temp.C_item_name = outrows[k]["item_name"].ToString();
                                    //temp.C_item_count = outrows[k]["item_value"].ToString();
                                }
                            }

                            for (int j = 0; j < dt_sets_rows_byconditions.Length; j++)
                            {
                                if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "����")
                                {
                                    temp.Temperature = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                else if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "��ʶ")
                                {
                                    //temp.Idea = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                else if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "����")
                                {
                                    temp.Pulse = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                else if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "����")
                                {
                                    temp.Breathe = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                else if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "Ѫ�����Ͷ�")
                                {
                                    temp.Bp_saturation = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                else if (dt_sets_rows_byconditions[j]["item_name"].ToString() == "Ѫѹ")
                                {
                                    temp.Blood_pressure = dt_sets_rows_byconditions[j]["item_value"].ToString();
                                }
                                temp.Pathograhy = dt_sets_rows_byconditions[j]["status_measure"].ToString();
                                temp.Signature = dt_sets_rows_byconditions[j]["user_name"].ToString();
                            }
                        }
                        else
                        {
                            //����                            
                            if (k < inrows.Length && inrows.Length > 0)
                            {
                                if (inrows[k]["other_name"].ToString() != "")
                                {
                                    temp.R_item_name = inrows[k]["other_name"].ToString();
                                    temp.R_item_count = inrows[k]["item_value"].ToString();
                                }
                                else
                                {
                                    temp.R_item_name = inrows[k]["item_name"].ToString();
                                    temp.R_item_count = inrows[k]["item_value"].ToString();
                                }
                            }

                            //����
                            if (k < outrows.Length && outrows.Length > 0)
                            {
                                if (outrows[k]["other_name"].ToString() != "")
                                {
                                    //temp.C_item_name = outrows[k]["other_name"].ToString();
                                    //temp.C_item_count = outrows[k]["item_value"].ToString();
                                    //temp.C_state = outrows[k]["c_state"].ToString();
                                }
                                else
                                {
                                    //temp.C_item_name = outrows[k]["item_name"].ToString();
                                    //temp.C_item_count = outrows[k]["item_value"].ToString();
                                    //temp.C_state = outrows[k]["c_state"].ToString();
                                }
                            }
                           
                        }
                        temp.Date = Valite(temp.Date);
                        temp.Temperature = Valite(temp.Temperature);
                        temp.Pulse = Valite(temp.Pulse);
                        temp.Breathe = Valite(temp.Breathe);
                        temp.Blood_pressure = Valite(temp.Blood_pressure);
                        //�����¼
                        temp.Pathograhy = App.ToSBC(Valite(temp.Pathograhy));
                        temp.Bp_saturation = Valite(temp.Bp_saturation);
                        //temp.Pupil_left = Valite(temp.Pupil_left);
                        //temp.Pupil_right = Valite(temp.Pupil_right);
                        temp.R_item_name = Valite(temp.R_item_name);
                        temp.R_item_count = Valite(temp.R_item_count);
                        //temp.C_item_name = Valite(temp.C_item_name);
                        //temp.C_item_count = Valite(temp.C_item_count);
                        temp.Time = StringFormat(temp.Time);
                        nusers_Print.Add(temp);
                    }



                }
            }
        }
        /// <summary>
        /// ������� ҩƷ ʳƷ �ĸ������
        /// </summary>
        /// <param name="drigcount">ҩƷ</param>
        /// <param name="footcount">ʳƷ</param>
        /// <param name="outcount">����</param>
        /// <returns></returns>
        private int MaxRowCount(int incount, int outcount, int oxygenrows, int gulurows)
        {
            int max = 0;
            max = incount;
            if (outcount > max)
            {
                max = outcount;
            }
            if (oxygenrows > max)
            {
                max = oxygenrows;
            }
            if (gulurows > max)
            {
                max = gulurows;
            }
            return max;
        }


        //��֤���������0�ľ���ʾΪ��
        public string Valite(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
        }

        //��ʽ��ʱ�䣬��ȡ������
        public string StringFormat(string time)
        {
            if (time != string.Empty || time != "")
            {
                if (time != null)
                    time = time.Substring(0, 5);
            }
            return time;
        }
    }
}