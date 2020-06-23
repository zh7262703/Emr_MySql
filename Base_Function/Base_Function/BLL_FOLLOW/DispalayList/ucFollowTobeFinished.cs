using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;
using System.IO;

namespace Base_Function.BLL_FOLLOW.DispalayList
{
    public partial class ucFollowTobeFinished : UserControl
    {
        private string User_Id;  //�û���
        private Class_FollowInfo[] myInfo; //ʵ������ط���
        DataTable Show; // ��������Դ
        private string DId = "";         //�ܴ�ҽ��ID
        private string Diag = "";        //���
        
        
        public ucFollowTobeFinished()
        {
            InitializeComponent();
            txtState.ReadOnly = true;
            InicmbFollowInfo();
            IniSection();
            
        }

        /// <summary>
        /// ����÷���������
        /// </summary>
        public void InicmbFollowInfo()
        {
            DataSet desDs=null;
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                string User_SickArea_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                string qurySickArea = "select * from t_follow_info where exec_sickarea='" + User_SickArea_Id + "' or exec_sickarea like '%," + User_SickArea_Id + ",%' or exec_sickarea like '," + User_SickArea_Id + "%' or exec_sickarea like '" + User_SickArea_Id + ",%' or exec_sickarea='0'";
                desDs = App.GetDataSet(qurySickArea);
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                string User_Section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
                string qurySection = "select * from t_follow_info where exec_sections='" + User_Section_Id + "' or exec_sections like '%," + User_Section_Id + ",%' or exec_sections like '," + User_Section_Id + "%' or exec_sections like '" + User_Section_Id + ",%' or exec_sections='0'";
                desDs = App.GetDataSet(qurySection);
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                
                string qurySection = "select * from t_follow_info where rownum<100";
                desDs = App.GetDataSet(qurySection);
            }
            myInfo = GetInfo(desDs);
            if (myInfo != null&&myInfo.Length!=0)
            {
                for (int i = 0; i < myInfo.Length; i++)
                    cmbFollowInfo.Items.Add(myInfo[i]);
                cmbFollowInfo.DisplayMember = "Follow_Name";
                cmbFollowInfo.ValueMember = "id";
                cmbFollowInfo.SelectedIndex = 0;
            }
            else
                cmbFollowInfo.DataSource = null;

        }
        /// <summary>
        /// ʵ��������
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_FollowInfo[] GetInfo(DataSet temp)
        {
            if (temp != null)
                if (temp.Tables[0].Rows.Count != 0)
                {
                    
                    DataTable dt = temp.Tables[0];
                    Class_FollowInfo[] info = new Class_FollowInfo[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        info[i] = new Class_FollowInfo();
                        info[i].Id = dt.Rows[i]["id"].ToString();
                        info[i].Follow_name = dt.Rows[i]["follow_name"].ToString();                        
                        info[i].Section_ids = dt.Rows[i]["section_ids"].ToString();
                        info[i].Icd9codes = dt.Rows[i]["icd9codes"].ToString();
                        info[i].Icd10codes = dt.Rows[i]["icd10codes"].ToString();
                        info[i].Ismaindiag = dt.Rows[i]["ismaindiag"].ToString();
                        info[i].Startingtime = dt.Rows[i]["startingtime"].ToString();
                        info[i].Defaultdays = dt.Rows[i]["defaultdays"].ToString();
                        info[i].Followtype = dt.Rows[i]["followtype"].ToString();
                        info[i].Definefollows=dt.Rows[i]["definefollows"].ToString();
                        info[i].Followtextid = dt.Rows[i]["followtextid"].ToString();
                        info[i].Createtime = dt.Rows[i]["createtime"].ToString();
                        info[i].Isenable = dt.Rows[i]["isenable"].ToString();
                        info[i].Maintain_section = dt.Rows[i]["maintain_section"].ToString();
                        info[i].FinishType = dt.Rows[i]["finishType"].ToString();
                    }
                    return info;
                }
            return null;              
        }
        /// <summary>
        /// �󶨿���
        /// </summary>
        public void IniSection()
        {
            string secSql = "select a.sid,a.section_name from T_SECTIONINFO a  where a.is_follow_visit='Y'";
            DataSet secTemp = App.GetDataSet(secSql);
            DataRow newRow = secTemp.Tables[0].NewRow();
            newRow[0] = "0";
            newRow[1] = "";
            secTemp.Tables[0].Rows.InsertAt(newRow, 0);
            cmbSection.DataSource = secTemp.Tables[0].DefaultView;
            cmbSection.DisplayMember = "section_name";
            cmbSection.ValueMember = "sid";
            cmbSection.SelectedIndex = 0;
        }
        /// <summary>
        /// �ؼ���ʼ��
        /// </summary>
        public void IniControl()
        {
            txtPatientName.Text = "";
            txtHospital.Text = "";
            txtDoctor.Text = "";
            txtDiag.Text = "";
            txtDays.Text = "";
            ckbFollowTime.Checked = false;
            cmbSection.SelectedIndex = 0;
            cmbSymbol.SelectedIndex = 0;
            
        }
                
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cmbFollowInfo.SelectedItem != null)
            {
                Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
                DisplayPatients(info);
            }
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// ת��
        /// </summary>
        /// <param name="Row"></param>
        /// <returns></returns>
        public DataTable DataRowToDataTable(DataRow[] Row)
        {
            if (Row.Length != 0&&Row!=null)
            {
                DataTable table = Row[0].Table.Clone();
                foreach (DataRow r in Row)
                {
                    table.ImportRow(r);
                }
                return table;
            }
            return null;
        }

        /// <summary>
        /// ��Ӳ�ѯ����
        /// </summary>
        /// <returns></returns>
        public DataTable FilterSource(DataTable ExistTb)
        {
            DataRow[] tempRow;
            DataRow[] newRow;
            if (txtPatientName.Text.Trim() != "")
            {
                tempRow = ExistTb.Select("  ��������='" + txtPatientName.Text.Trim() + "'");
                ExistTb = DataRowToDataTable(tempRow);
                tempRow = null;
            }
            if (txtHospital.Text.Trim() != "")
            {
                newRow = ExistTb.Select();
                tempRow = ExistTb.Select("  סԺ�� like '%" + txtHospital.Text.Trim() + "%'");
                ExistTb = DataRowToDataTable(tempRow);
                tempRow = null;
            }
            if (cmbSection.Text != "")
            {
                tempRow = ExistTb.Select("  ���Һ� =" + cmbSection.SelectedValue.ToString() + "");
                ExistTb = DataRowToDataTable(tempRow);
                tempRow = null;
            }
            if (DId != "")
            {
                tempRow = ExistTb.Select("  ҽ����='" + DId + "'");
                ExistTb = DataRowToDataTable(tempRow);
                tempRow = null;
            }
            if (txtState.Text != "")
            {
                string tempStr=ReArrange(txtState.Text);
                tempRow = ExistTb.Select("���״̬ in (" + tempStr + ")");
                ExistTb = DataRowToDataTable(tempRow);
                tempRow = null;
            }
            if (Diag != "")
            {
                string paId = "";
                string temp = "select patient_id from COVER_DIAGNOSE where icd10code is not null and icd10code ='" + Diag + "' and type not in ('E','S','P')";
                DataSet dsTemp = App.GetDataSet(temp);
                if(dsTemp!=null)
                    if (dsTemp.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
                        {
                            if (paId == "")
                                paId = dsTemp.Tables[0].Rows[i]["patient_id"].ToString();
                            else
                                paId += "," + dsTemp.Tables[0].Rows[i]["patient_id"].ToString();
                        }
                    }
                if (paId != "")
                {
                    tempRow = ExistTb.Select("����ID in (" + paId + ")");
                    ExistTb = DataRowToDataTable(tempRow);
                    tempRow = null;
                }
                else
                    ExistTb = null;
            }
            if (txtDays.Text != "" || ckbLTime.Checked || ckbFollowTime.Checked)
            {
                if (ExistTb == null)
                    return null;
                if (ExistTb.Rows.Count == 0)
                    return null;
                else
                {
                    for (int i = ExistTb.Rows.Count - 1; i > -1; i--)
                    {
                        if (ckbFollowTime.Checked)
                        {
                            string StartTime1 = dtStartTime.Value.ToString("yyyy-MM-dd");
                            string EndTime1 = dtEndTime.Value.ToString("yyyy-MM-dd");
                            if (string.Compare(ExistTb.Rows[i]["�ϴ����ʱ��"].ToString(), StartTime1) < 0 || string.Compare(ExistTb.Rows[i]["�ϴ����ʱ��"].ToString(), EndTime1) > 0)
                            {
                                ExistTb.Rows.RemoveAt(i);
                                continue;
                            }
                        }
                        if (ckbLTime.Checked)
                        {
                            string StartTime2 = dtStartTime1.Value.ToShortDateString();
                            string EndTime2 = dtEndTime1.Value.ToShortDateString();
                            if (string.Compare(ExistTb.Rows[i]["Ӧ���ʱ��"].ToString(), StartTime2) < 0 || string.Compare(ExistTb.Rows[i]["Ӧ���ʱ��"].ToString(), EndTime2) > 0)
                            {
                                ExistTb.Rows.RemoveAt(i);
                                continue;
                            }
                        }
                        if (txtDays.Text != "")
                        {
                            if (cmbSymbol.SelectedItem.ToString() == ">")
                            {
                                if (Convert.ToInt32(ExistTb.Rows[i]["���ڣ��죩"].ToString()) <= Convert.ToInt32(txtDays.Text.ToString()))
                                {
                                    ExistTb.Rows.RemoveAt(i);
                                    continue;
                                }
                            }
                            if (cmbSymbol.SelectedItem.ToString() == "=")
                            {
                                if (Convert.ToInt32(ExistTb.Rows[i]["���ڣ��죩"].ToString()) != Convert.ToInt32(txtDays.Text.ToString()))
                                {
                                    ExistTb.Rows.RemoveAt(i);
                                    continue;
                                }
                            }
                            if (cmbSymbol.SelectedItem.ToString() == "<")
                            {
                                if (Convert.ToInt32(ExistTb.Rows[i]["���ڣ��죩"].ToString()) >= Convert.ToInt32(txtDays.Text.ToString()))
                                {
                                    ExistTb.Rows.RemoveAt(i);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            return ExistTb;

        }
        private void rtnSelectState_Click(object sender, EventArgs e)
        {
            frmState st = new frmState((string)txtState.Tag);
            st.ShowDialog();
            txtState.Text = st.StateDes;
            txtState.Tag = st.StateIds;
        }
        public void DisplayPatients(Class_FollowInfo info)
        {
            dgvPatients.ReadOnly = true;
            Show = SelectDataSet(info);
            Show = FilterSource(Show);
            //ɸѡ���������ʱ�����ƣ���ó����������ƣ�
            if (Show != null)
            {

                dgvPatients.DataSource = Show.DefaultView;
                for (int i = 0; i < dgvPatients.Rows.Count; i++)
                {
                    dgvPatients.Rows[i].Cells["���"].Value = i + 1;
                    dgvPatients.Rows[i].Cells["��÷���"].Value = cmbFollowInfo.Text;

                }
                dgvPatients.Columns["���Һ�"].Visible = false;
                dgvPatients.Columns["ҽ����"].Visible = false;
                dgvPatients.Columns["�������"].Visible = false;
                dgvPatients.Columns["�ο�ʱ��"].Visible = false;
            }
            else
                dgvPatients.DataSource = null;

        }
        /// <summary>
        /// ��ȡDataTable
        /// </summary>
        public DataTable SelectDataSet(Class_FollowInfo selectedInfo)
        {
            //�ӵ�ǰѡ��Ľ�������л�ȡɸѡ��Ϣ
            int sMethod = 0;    //�ο���ʼʱ��
            //int cMethod = 0;    //ѭ����ʽ
            switch (selectedInfo.Startingtime)
            {
                case "��Ժʱ��":
                    sMethod = 1;
                    break;
                case "��Ժʱ��":
                    sMethod = 2;
                    break;
                case "����ʱ��":
                    sMethod = 3;
                    break;
                default:
                    sMethod = 4;
                    break;
            }
            string ReSpell="";
            string pIds="";
            //ɸѡ����
            string opeTemp;
            try
            {
                if (selectedInfo.Icd9codes != "")
                {
                    ReSpell = ReArrange(selectedInfo.Icd9codes);
                    opeTemp = "select distinct(patient_id) from COVER_OPERATION where oper_code in (" + ReSpell + ") and oper_code is not null";
                    DataTable ds_opeTemp = App.GetDataSet(opeTemp).Tables[0];
                    if (ds_opeTemp.Rows.Count != 0)
                        for (int i = 0; i < ds_opeTemp.Rows.Count; i++)
                        {
                            if (pIds == "")
                                pIds = ds_opeTemp.Rows[i]["patient_id"].ToString();
                            else
                                pIds += "," + ds_opeTemp.Rows[i]["patient_id"].ToString();
                        }
                    else
                        return null;
                }

                string diagTemp;
                //ɸѡ���
                if (selectedInfo.Icd10codes != "")
                {
                    ReSpell = ReArrange(selectedInfo.Icd10codes);                    
                    if (pIds != "")
                    {
                        if (selectedInfo.Ismaindiag == "Y")
                        {
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ") and TYPE='M' and inpatient_id in (" + pIds + ") and icd10code is not null";
                        }
                        else
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ")  and inpatient_id in (" + pIds + ") and icd10code is not null and type not in ('E','S','P')";
                        pIds = "";
                    }
                    else
                    {
                        if (selectedInfo.Ismaindiag == "Y")
                            diagTemp = "select distinct(patient_id) from COVER_DIAGNOSE where icd10code in (" + ReSpell + ") and TYPE='M' and icd10code is not null";
                        else
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ")  and icd10code is not null";
                    }
                    DataTable ds_diagTemp = App.GetDataSet(diagTemp).Tables[0];
                    if (ds_diagTemp.Rows.Count != 0)
                    {
                        for (int i = 0; i < ds_diagTemp.Rows.Count; i++)
                        {
                            if (pIds == "")
                                pIds = ds_diagTemp.Rows[i]["patient_id"].ToString();
                            else
                                pIds += "," + ds_diagTemp.Rows[i]["patient_id"].ToString();
                        }
                        
                    }
                    else
                        return null;
                }
                string paTemp="";
                if(sMethod==1)
                {
                //ɸѡ����
                    paTemp = "select ''���,t.id ����ID,t.pid סԺ��,t.patient_name ��������,t.age||t.age_unit  ����,t.section_id ���Һ�,t.section_name ����,t.sick_doctor_id ҽ����,t.sick_doctor_name �ܴ�ҽ��,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) ���,t.now_addres_phone �绰,t.now_address ��ַ,t.leave_time �ο�ʱ��,t.die_flag ������� from T_IN_PATIENT t inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id where t.die_flag=0 and t.leave_time >to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0,selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd') and tf.solution_id=" + selectedInfo.Id + "";
                }
                if (sMethod == 2)
                {
                    paTemp = "select ''���,t.id ����ID,t.pid סԺ��,t.patient_name ��������,t.age||t.age_unit  ����,t.section_id ���Һ�,t.section_name ����,t.sick_doctor_id ҽ����,t.sick_doctor_name �ܴ�ҽ��,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) ���,t.now_addres_phone �绰,t.now_address ��ַ,t.in_time �ο�ʱ��,t.die_flag ������� from T_IN_PATIENT t inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id  where t.die_flag=0 and t.leave_time > to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0, selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd') and tf.solution_id=" + selectedInfo.Id + "";
                }
                if (sMethod == 3)
                {
                    paTemp = "select ''���,t.id ����ID,t.pid סԺ��,t.patient_name ��������,t.age||t.age_unit  ����,t.section_id ���Һ�,t.section_name ����,t.sick_doctor_id ҽ����,t.sick_doctor_name �ܴ�ҽ��,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) ���,t.now_addres_phone �绰,t.now_address ��ַ,max(oper_date) �ο�ʱ��,t.die_flag ������� from T_IN_PATIENT t join COVER_OPERATION o on t.id=patient_id inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id where t.die_flag=0 and t.leave_time > to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0, selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd') and tf.solution_id=" + selectedInfo.Id + "";
                }
                if (sMethod == 4)
                {
                    
                }
                //�������Ƿ��п�������
                if (selectedInfo.Section_ids != "0")
                {
                    if (pIds != "")
                        paTemp += " and t.section_id in(" + selectedInfo.Section_ids + ") and t.id in (" + pIds + ") and rownum<100";
                    else
                        paTemp += "and t.section_id in(" + selectedInfo.Section_ids + ")  and rownum<100";

                }
                else
                {
                    if (pIds != "")
                        paTemp += " and t.id in (" + pIds + ") and rownum<100";
                    else
                        paTemp += " and rownum<100";
                        
                }
                //��Ӷ�������ݣ��ֶ�����÷����ģ�
                string Add = "";
                string Dele = "";
                string Manual = "select * from T_FOLLOW_MANUALPATIENT where solution_id=" + selectedInfo.Id + "";
                DataTable dsManual = App.GetDataSet(Manual).Tables[0];
                for (int n = 0; n < dsManual.Rows.Count; n++)
                {
                    if (dsManual.Rows[n]["IsAdd"].ToString() == "1")
                    {
                        if (Add == "")
                            Add = dsManual.Rows[n]["patient_id"].ToString();
                        else
                            Add += "," + dsManual.Rows[n]["patient_id"].ToString();
                    }
                    else
                    {
                        if (Dele == "")
                            Dele = dsManual.Rows[n]["patient_id"].ToString();
                        else
                            Dele += "," + dsManual.Rows[n]["patient_id"].ToString();
                    }
                }
                if (Dele != "")
                    paTemp += " and t.id not in (" + Dele + ")";
                //if (Add != "")
                //    paTemp += " union select ''���,t.id ����ID,t.pid סԺ��,t.patient_name ��������,t.age||t.age_unit ����,t.section_id ���Һ�,t.section_name ����,t.sick_doctor_id ҽ����,t.sick_doctor_name �ܴ�ҽ��,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) ���,t.now_addres_phone �绰,t.now_address ��ַ,m.update_time �ο�ʱ��,t.die_flag ������� from T_IN_PATIENT t join T_FOLLOW_MANUALPATIENT m on t.id=m.patient_id where t.die_flag=0  and t.id in (" + Add + ") and m.solution_id="+selectedInfo.Id+"";

                //paTemp = FilterSource(paTemp);
                DataTable Patients = App.GetDataSet(paTemp).Tables[0];

                //Patients.Rows.Clear();

                //��ӳ��ڣ���ô������ϴ���ô��������״̬�У�Ĭ��Ϊ������
                Patients.Columns.Add("���ڣ��죩", typeof(System.Int16));
                Patients.Columns.Add("��ô���", typeof(System.Int16));
                Patients.Columns.Add("�ϴ����ʱ��", typeof(System.String));
                Patients.Columns.Add("Ӧ���ʱ��", typeof(System.String));
                DataColumn StateCol = new DataColumn("���״̬", typeof(System.String));                
                StateCol.DefaultValue = "�������";
                Patients.Columns.Add(StateCol);
                DataColumn FollowName = new DataColumn("��÷���", typeof(System.String));
                StateCol.DefaultValue = selectedInfo.Follow_name;
                Patients.Columns.Add(FollowName);
                string ExistRecord = "select (select max(ACTUAL_TIME) from T_FOLLOW_RECORD WHERE patient_id=t.patient_id and solution_id=t.solution_id) ������ʱ��,PATIENT_ID,(select count(*) from t_follow_record where t.patient_id=patient_id and t.solution_id=solution_id and isfinished=1) ��ô���,(select min(requested_time) from T_FOLLOW_RECORD where patient_id=t.patient_id and solution_id=t.solution_id and isfinished=0) ��Сδ���ʱ��,(select count(*) from t_follow_record where patient_id=t.patient_id and solution_id=t.solution_id) ����,t.requested_time Ӧ���ʱ��,(select des from t_follow_record r join  T_FOLLOW_STATE a on r.state_id=a.id where r.id =(select max(id) from T_FOLLOW_RECORD where isfinished=1 and t.patient_id=patient_id and solution_id=t.solution_id)) des  from T_FOLLOW_RECORD t  where not exists (select 1 from T_FOLLOW_RECORD where t.patient_id=patient_id and t.solution_id=solution_id and t.id<id)  and solution_id =" + selectedInfo.Id + "";
                DataTable ExistPatients = App.GetDataSet(ExistRecord).Tables[0];

                int flag = 0;   //����Ƿ�����ù�

                for (int i = Patients.Rows.Count-1; i >-1; i--)
                {
                    for (int j = 0; j < ExistPatients.Rows.Count; j++)
                    {
                        #region �����ɼ�¼
                        if (Patients.Rows[i]["����ID"].ToString() == ExistPatients.Rows[j]["patient_id"].ToString())
                        {

                            flag = 1;
                            //�޸ķ��ʹ��ļ�¼
                            if (ExistPatients.Rows[j]["��ô���"] != null && ExistPatients.Rows[j]["��ô���"].ToString() != "")
                                Patients.Rows[i]["��ô���"] = Convert.ToInt32(ExistPatients.Rows[j]["��ô���"].ToString());
                            if (ExistPatients.Rows[j]["des"] != null && ExistPatients.Rows[j]["des"].ToString()!="")
                                Patients.Rows[i]["���״̬"] = ExistPatients.Rows[j]["des"].ToString();
                            if (ExistPatients.Rows[j]["������ʱ��"] != null && ExistPatients.Rows[j]["������ʱ��"].ToString()!="")
                                Patients.Rows[i]["�ϴ����ʱ��"] = ExistPatients.Rows[j]["������ʱ��"].ToString();
                            if (ExistPatients.Rows[j]["Ӧ���ʱ��"] != null && ExistPatients.Rows[j]["Ӧ���ʱ��"].ToString()!="")
                                Patients.Rows[i]["Ӧ���ʱ��"] =Convert.ToDateTime(ExistPatients.Rows[j]["Ӧ���ʱ��"].ToString()).ToShortDateString();
                            //���㳬������
                            int existTimes=0;
                            if (ExistPatients.Rows[j]["����"] != null && ExistPatients.Rows[j]["����"].ToString() != "")
                                existTimes=Convert.ToInt32(ExistPatients.Rows[j]["����"].ToString());
                            DateTime timeMin,timeMinCopy;
                            int MinusDays = 0;
                            DateTime timeNow = DateTime.Today;
                            if (ExistPatients.Rows[j]["��Сδ���ʱ��"].ToString() != "" && ExistPatients.Rows[j]["��Сδ���ʱ��"].ToString() != null)
                            {
                                timeMinCopy = timeMin = Convert.ToDateTime(ExistPatients.Rows[j]["��Сδ���ʱ��"].ToString());
                                
                                MinusDays = (int)(timeNow - timeMin).TotalDays;
                                if (MinusDays <= 0)
                                {
                                    Patients.Rows.RemoveAt(i);
                                    break;
                                }
                                else
                                {
                                    Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                                    Patients.Rows[i]["Ӧ���ʱ��"] = timeMin.ToShortDateString();
                                    //timeMin = Convert.ToDateTime(ExistPatients.Rows[j]["Ӧ���ʱ��"].ToString());
                                    //if ((int)(timeNow - timeMin).TotalDays > 0)
                                    //{
                                    //    if (selectedInfo.Definefollows != "")
                                    //    {
                                    //        int ExistTimes = Convert.ToInt32(ExistPatients.Rows[j]["����"].ToString());
                                    //        string[] TimeSpan = selectedInfo.Definefollows.Split(',');
                                    //        string Time = "";
                                    //        if (ExistTimes >= TimeSpan.Length)
                                    //            Time = TimeSpan[TimeSpan.Length - 1];
                                    //        else
                                    //            Time = TimeSpan[ExistTimes - 1];
                                    //        if (Time.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddYears(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    //        if (Time.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddMonths(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    //        if (Time.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddDays(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    //        Patients.Rows[i]["Ӧ���ʱ��"] = timeMin.ToShortDateString();

                                    //    }
                                    //    if (selectedInfo.Followtype != "")
                                    //    {
                                    //        if (selectedInfo.Followtype.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    //        if (selectedInfo.Followtype.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    //        if (selectedInfo.Followtype.IndexOf("��") != -1)
                                    //            timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    //        Patients.Rows[i]["Ӧ���ʱ��"] = timeMin.ToShortDateString();
                                    //    }
                                    //}
                                }
                            }
                            else
                            {
                                timeMin= Convert.ToDateTime(ExistPatients.Rows[j]["Ӧ���ʱ��"].ToString());
                                if (selectedInfo.Definefollows != "")
                                {
                                    int ExistTimes =Convert.ToInt32( ExistPatients.Rows[j]["����"].ToString());
                                    string[] TimeSpan=selectedInfo.Definefollows.Split(',');
                                    string Time="";
                                    if (ExistTimes >= TimeSpan.Length)
                                        Time = TimeSpan[TimeSpan.Length - 1];
                                    else
                                        Time = TimeSpan[ExistTimes - 1];
                                    if (Time.IndexOf("��") != -1)
                                        timeMin = timeMin.AddYears(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    if (Time.IndexOf("��") != -1)
                                        timeMin = timeMin.AddMonths(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    if (Time.IndexOf("��") != -1)
                                        timeMin = timeMin.AddDays(Convert.ToInt32(Time.Substring(0, Time.IndexOf("��"))));
                                    MinusDays = (int)(timeNow - timeMin).TotalDays;
                                    if (MinusDays <= 0)
                                    {
                                        Patients.Rows.RemoveAt(i);
                                        break;
                                    }
                                    else
                                    {
                                        Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                                        Patients.Rows[i]["Ӧ���ʱ��"] = timeMin.ToShortDateString();
                                    }

                                }
                                if (selectedInfo.Followtype != "")
                                {
                                    if (selectedInfo.Followtype.IndexOf("��") != -1)
                                        timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    if (selectedInfo.Followtype.IndexOf("��") != -1)
                                        timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    if (selectedInfo.Followtype.IndexOf("��") != -1)
                                        timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                    MinusDays = (int)(timeNow - timeMin).TotalDays;
                                    if (MinusDays <= 0)
                                    {
                                        Patients.Rows.RemoveAt(i);
                                        break;
                                    }
                                    else
                                    {
                                        Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                                        Patients.Rows[i]["Ӧ���ʱ��"] = timeMin.ToShortDateString();
                                    }
                                }
                            }                           

                            #region �������¼�����в���
                            //if (selectedInfo.Followtype != "")
                            //{                                
                            //    if (selectedInfo.Followtype.IndexOf('��') != -1)
                            //    {
                            //        timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                            //    }
                            //    if (selectedInfo.Followtype.IndexOf('��') != -1)
                            //    {
                            //        timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                            //    }
                            //    if (selectedInfo.Followtype.IndexOf('��') != -1)
                            //    {
                            //        timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                            //    }
                            //    MinusDays = (int)(timeNow - timeMin).TotalDays;
                            //    if (MinusDays <= 0)
                            //        Patients.Rows.RemoveAt(i);
                            //    //Patients.Rows[i]["���ڣ��죩"] = 0;
                            //    else
                            //        Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                                                                                                   
                            //}
                            //else
                            //{
                            //    string[] Items = selectedInfo.Definefollows.Split(',');
                            //    for (int count = 0; count < Items.Length; count++)
                            //    {
                            //        if (existTimes != 0)
                            //        {
                            //            existTimes--;
                            //            if (count >= Items.Length - 1)
                            //                count = Items.Length - 1;
                            //            continue;
                            //        }
                            //        string Item = Items[count];
                            //        if (Item.IndexOf("��") != -1)
                            //        {
                            //            timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                            //        }
                            //        if (Item.IndexOf("��") != -1)
                            //        {
                            //            timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                            //        }
                            //        if (Item.IndexOf("��") != -1)
                            //        {
                            //            timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                            //        }
                            //        MinusDays = (int)(timeNow - timeMin).TotalDays;
                            //        if (MinusDays <= 0)
                            //            Patients.Rows[i]["���ڣ��죩"] = 0;
                            //        else
                            //            Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //        break;
                            //    }                                
                            //}                       
                            ////�Ƿ�������ֶ���ӱ���
                            //DataRow[] Rows = dsManual.Select("isadd=1 and definefollows is not null");

                            //if (Rows != null)
                            //    if (Rows.Length != 0)
                            //        for (int m = 0; m < Rows.Length; m++)
                            //        {
                            //            if (Patients.Rows[i]["����ID"].ToString() == Rows[m]["patient_id"].ToString())
                            //            {
                            //                //�ж����ֶ���Ӻ�����������
                            //                if (string.Compare(timeMinCopy.ToShortDateString(), Rows[m]["update_time"].ToString()) == -1)
                            //                {
                            //                    MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                    if (MinusDays <= 0)
                            //                        Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                    else
                            //                        Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                    break;
                            //                }
                            //                DateTime timeRef = Convert.ToDateTime(Rows[m]["update_time"].ToString());
                            //                string FollowWay = Rows[m]["definefollows"].ToString();
                            //                int MinusDays1 = (int)(timeMinCopy - timeRef).TotalDays;
                            //                //�Զ�����÷�ʽ
                            //                if (FollowWay.IndexOf(",") != -1)
                            //                {
                            //                    string[] Items = FollowWay.Split(',');
                            //                    for (int n = 0; n < Items.Length; n++)
                            //                    {
                            //                        if (Items[n].IndexOf("��") != -1)
                            //                        {
                            //                            if (MinusDays1 <= 0)
                            //                            {
                            //                                n++;
                            //                                timeRef=timeRef.AddYears(Convert.ToInt32(Items[n].Substring(0,Items[n].IndexOf("��"))));
                            //                                 MinusDays1 = (int)(timeMinCopy - timeRef).TotalDays;
                            //                            }
                            //                            else
                            //                            {
                            //                                timeMinCopy = timeMinCopy.AddYears(Convert.ToInt32(Items[n].Substring(0, Items[n].IndexOf("��"))));

                            //                                MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                                if (MinusDays <= 0)
                            //                                    Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                                else
                            //                                    Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                                break;
                            //                            }
                            //                        }
                            //                        if (Items[n].IndexOf("��") != -1)
                            //                        {
                            //                            if (MinusDays1 <= 0)
                            //                            {
                            //                                n++;
                            //                                timeRef = timeRef.AddMonths(Convert.ToInt32(Items[n].Substring(0, Items[n].IndexOf("��"))));
                            //                                MinusDays1 = (int)(timeMinCopy - timeRef).TotalDays;
                            //                            }
                            //                            else
                            //                            {
                            //                                timeMinCopy = timeMinCopy.AddMonths(Convert.ToInt32(Items[n].Substring(0, Items[n].IndexOf("��"))));

                            //                                MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                                if (MinusDays <= 0)
                            //                                    Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                                else
                            //                                    Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                                break;
                            //                            }
                            //                        }
                            //                        if (Items[n].IndexOf("��") != -1)
                            //                        {
                            //                            if (MinusDays1 <= 0)
                            //                            {
                            //                                n++;
                            //                                timeRef = timeRef.AddDays(Convert.ToInt32(Items[n].Substring(0, Items[n].IndexOf("��"))));
                            //                                MinusDays1 = (int)(timeMinCopy - timeRef).TotalDays;
                            //                            }
                            //                            else
                            //                            {
                            //                                timeMinCopy = timeMinCopy.AddDays(Convert.ToInt32(Items[n].Substring(0, Items[n].IndexOf("��"))));

                            //                                MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                                if (MinusDays <= 0)
                            //                                    Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                                else
                            //                                    Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                                break;
                            //                            }
                            //                        }
                            //                        if (n == Items.Length - 1)
                            //                        {
                            //                            n--;
                            //                        }
                            //                    }
                            //                }
                            //                else
                            //                {

                            //                    if (FollowWay.IndexOf("��") != -1)
                            //                    {
                            //                        timeMinCopy=timeMinCopy.AddYears(Convert.ToInt32(FollowWay.Substring(0,FollowWay.IndexOf("��"))));

                            //                        MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                        if (MinusDays <= 0)
                            //                            Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                        else
                            //                            Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                        break;
                            //                    }
                            //                    if (FollowWay.IndexOf("��") != -1)
                            //                    {
                            //                        timeMinCopy = timeMinCopy.AddMonths(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));
                            //                        MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                        if (MinusDays <= 0)
                            //                            Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                        else
                            //                            Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                        break;
                            //                    }
                            //                    if (FollowWay.IndexOf("��") != -1)
                            //                    {
                            //                        timeMinCopy = timeMinCopy.AddDays(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));

                            //                        MinusDays = (int)(timeNow - timeMinCopy).TotalDays;
                            //                        if (MinusDays <= 0)
                            //                            Patients.Rows[i]["���ڣ��죩"] = 0;
                            //                        else
                            //                            Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            //                        break;
                            //                    }
                            //                }
                            //            }
                            //        }
                            #endregion
                        }
                        #endregion
                    }
                       
                    
                    #region δ���ɼ�¼
                    if (flag == 0)
                    {
                        //int Count = 0;  //��������������1�����ݲ�����Ҫ��
                        Patients.Rows[i]["��ô���"] = 0;
                        //�ο�ʱ��Ϊ��Ժʱ��
                        DateTime myTime = Convert.ToDateTime(Patients.Rows[i]["�ο�ʱ��"].ToString());
                        DateTime timeNow = DateTime.Today;
                        TimeSpan span = timeNow - myTime;
                        int MinusDays = (int)span.TotalDays;
                        
                        DateTime time1=myTime;
                        //����δ��ù��Ĳ��˵ĳ��������������ֶ���ӣ�
                        if (selectedInfo.Defaultdays != "0")
                        {
                            
                            time1 = myTime.AddDays(Convert.ToInt32(selectedInfo.Defaultdays));
                            span = timeNow - time1;
                            MinusDays = (int)span.TotalDays;
                        }
                        else
                        {
                            if (selectedInfo.Followtype != "")
                            {
                                if (selectedInfo.Followtype.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                }
                                if (selectedInfo.Followtype.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                }
                                if (selectedInfo.Followtype.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("��"))));
                                }
                            }
                            if (selectedInfo.Definefollows != "")
                            {
                                string Item = selectedInfo.Definefollows.Substring(0, selectedInfo.Definefollows.IndexOf(','));
                                if (Item.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                }
                                if (Item.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                }
                                if (Item.IndexOf("��") != -1)
                                {
                                    time1 = myTime.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                }
                            } 
                            span = timeNow - time1;
                            MinusDays = (int)span.TotalDays;
                        }
                        if (MinusDays < 0)
                        {

                            Patients.Rows.RemoveAt(i);
                            continue;
                            //Patients.Rows[i]["���ڣ��죩"] = 0;

                        }
                        else
                        {
                            Patients.Rows[i]["���ڣ��죩"] = MinusDays;
                            Patients.Rows[i]["Ӧ���ʱ��"] = time1;
                        }
                        int times=0;
                        if (selectedInfo.FinishType != "")
                        {
                            if (selectedInfo.FinishType.IndexOf("��") != -1)
                            {
                                times = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("��")));
                            }
                            else
                            {
                                DateTime tempTime = time1;
                                if (selectedInfo.FinishType.IndexOf("��") != -1)
                                {
                                    tempTime = time1.AddYears(Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("��"))));
                                }
                                if (selectedInfo.FinishType.IndexOf("��") != -1)
                                {
                                    tempTime = time1.AddMonths(Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("��"))));
                                }
                                if (selectedInfo.FinishType.IndexOf("��") != -1)
                                {
                                    tempTime = time1.AddDays(Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("��"))));
                                }
                                if (DateTime.Compare(timeNow, tempTime) > 0)
                                    timeNow = tempTime;
                            }
                        }
                        if (times != 0)
                        {
                            if (selectedInfo.Followtype != "")
                            {

                                string Item = selectedInfo.Followtype;
                                while (times > 0)
                                {

                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    times--;
                                }
                            }
                            else
                            {
                                string[] Item = selectedInfo.Definefollows.Split(',');
                                for (int num = 1; num < Item.Length; num++)
                                {
                                    string Str = Item[num];
                                    if (times <= 0)
                                        break;
                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddYears(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddYears(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddMonths(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddMonths(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddDays(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddDays(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (num == Item.Length - 1)
                                        num--;
                                    times--;
                                }
                            }
                            
                        }
                        else
                        {
                            if (selectedInfo.Followtype != "")
                            {

                                string Item = selectedInfo.Followtype;
                                while (true)
                                {

                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    if (Item.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("��"))));
                                    }
                                    
                                }
                            }
                            else
                            {
                                string[] Item = selectedInfo.Definefollows.Split(',');
                                for (int num = 1; num < Item.Length; num++)
                                {
                                    string Str = Item[num];

                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddYears(Convert.ToInt32(Str.Substring(0,Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddYears(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddMonths(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddMonths(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (Str.IndexOf("��") != -1)
                                    {
                                        if (DateTime.Compare(timeNow, time1.AddDays(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))))) < 0)
                                        {
                                            break;
                                        }
                                        time1 = time1.AddDays(Convert.ToInt32(Str.Substring(0, Str.IndexOf("��"))));
                                    }
                                    if (num == Item.Length - 1)
                                        num--;

                                }
                            }
                           
                        }
                                                
                        //#region �������ֶ�����б��ڵĲ��ˣ�����DefineFollows�ֶ���ֵ��˵���޸������ѭ����ʽ�����򸲸�ԭ���㷨
                        ////�Ƿ�������ֶ���ӱ��ڣ����α������򸲸�ǰ��ļ�¼
                        //timeNow = App.GetSystemTime();
                        //DataRow[] Rows = dsManual.Select("isadd=1 and definefollows is not null");

                        //if (Rows != null)
                        //    if (Rows.Length != 0)
                        //        for (int m = 0; m < Rows.Length; m++)
                        //        {
                        //            if (Patients.Rows[i]["����ID"].ToString() == Rows[m]["patient_id"].ToString())
                        //            {
                        //                string FollowWay = Rows[m]["definefollows"].ToString();

                        //                if (FollowWay.IndexOf(",") != -1)
                        //                {
                        //                    string[] Items = FollowWay.Split(',');
                        //                    if (Items[0].IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddYears(Convert.ToInt32(Items[0].Substring(0, Items[0].IndexOf("��"))));
                        //                        span = timeNow - myTime;
                        //                        MinusDays = (int)span.TotalDays;                                             
                        //                        if (MinusDays <= 0)
                        //                        {
                        //                            DelayDays = 0;

                        //                        }
                        //                        else
                        //                            DelayDays = MinusDays;
                        //                        break;

                        //                    }
                        //                    if (Items[0].IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddMonths(Convert.ToInt32(Items[0].Substring(0, Items[0].IndexOf("��"))));
                        //                        span = timeNow - myTime;
                        //                        MinusDays = (int)span.TotalDays;
                                                
                        //                        if (MinusDays <= 0)
                        //                        {
                        //                            DelayDays = 0;

                        //                        }
                        //                        else
                        //                            DelayDays = MinusDays;
                        //                        break;
                        //                    }
                        //                    if (Items[0].IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddDays(Convert.ToInt32(Items[0].Substring(0, Items[0].IndexOf("��"))));
                        //                        span = timeNow - myTime;
                        //                        MinusDays = (int)span.TotalDays;
                                                
                        //                        if (MinusDays <= 0)
                        //                        {
                        //                            DelayDays = 0;

                        //                        }
                        //                        else
                        //                            DelayDays = MinusDays;
                                                
                        //                    }

                                            
                        //                }
                        //                else
                        //                {
                                            
                        //                    if (FollowWay.IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddYears(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));

                                                
                        //                    }
                        //                    if (FollowWay.IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddMonths(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));
                                                
                        //                    }
                        //                    if (FollowWay.IndexOf("��") != -1)
                        //                    {
                                                
                        //                        myTime = myTime.AddDays(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));
                                               
                        //                    }
                        //                    span = timeNow - myTime;
                        //                    MinusDays = (int)span.TotalDays;
                        //                    if (MinusDays <= 0)
                        //                        DelayDays = 0;
                        //                    else
                        //                        DelayDays = MinusDays;
                                            
                        //                }
                        //                Patients.Rows[i]["���ڣ��죩"] = DelayDays;
                        //                if (FollowWay.IndexOf(",") != -1)
                        //                {
                        //                    string[] Items = FollowWay.Split(',');
                        //                    for (int num = 1; num < Items.Length; num++)
                        //                    {
                        //                        if (Items[num].IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddYears(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddYears(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))));


                        //                        }
                        //                        if (Items[num].IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddMonths(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddMonths(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))));
                        //                        }
                        //                        if (Items[num].IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddDays(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddDays(Convert.ToInt32(Items[num].Substring(0, Items[num].IndexOf("��"))));

                        //                        }
                        //                        if (num == Items.Length - 1)
                        //                            num--;
                        //                    }
                        //                }
                        //                else
                        //                {
                                            
                        //                    while(true)
                        //                    {
                        //                        if (FollowWay.IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddYears(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddYears(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));

                        //                        }
                        //                        if (FollowWay.IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddMonths(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddMonths(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));
                        //                        }
                        //                        if (FollowWay.IndexOf("��") != -1)
                        //                        {
                        //                            if (DateTime.Compare(timeNow, myTime.AddDays(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))))) < 0)
                        //                                break;
                        //                            myTime = myTime.AddDays(Convert.ToInt32(FollowWay.Substring(0, FollowWay.IndexOf("��"))));

                        //                        }
                        //                    }
                        //                }
                        //                Patients.Rows[i]["Ӧ���ʱ��"] =myTime.ToShortDateString();
                        //                break;
                        //            }
                                    
                        //        }
                        //#endregion
                    }
                    #endregion
                    else
                        flag = 0;
                }
                return Patients;
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
                return null;
            }
            
        }
        /// <summary>
        /// �����ַ�������'','',''��ʽ�ַ���
        /// </summary>
        /// <param name="temp"></param>
        public string ReArrange(string temp)
        {
            string finalStr="";
            if (temp.IndexOf(',') != -1)
            {
                string[] swap = temp.Split(',');
                foreach (string str in swap)
                {
                    if (finalStr == "")
                        finalStr = "'" + str + "'";
                    else
                        finalStr += ",'" + str + "'";
                }
                return finalStr;
            }
            return "'"+temp+"'";
        }
        #region
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDoctor.Text = row["ҽ��"].ToString(); //textName;
                            DId = row["ҽ����"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    DId = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id ҽ����,user_name ҽ�� from T_USERINFO"
                                                + " where shortcut_code like '%" + txtDoctor.Text.Trim().ToUpper() + "%' or user_name like '%"+txtDoctor.Text.Trim()+"%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "ҽ��", "ҽ��");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void txtDiag_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDiag.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select CODE ��Ϻ�,name ��� from DIAG_DEF_ICD10"
                                                + " where SHORTCUT1 like '%" + txtDiag.Text.Trim().ToUpper() + "%' or name like '%"+txtDiag.Text.Trim()+"%'";
                            App.FastCodeCheck(sql_select, txtDiag, "���", "���");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void txtDiag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiag.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDiag.Text = row["���"].ToString(); //textName;
                            Diag = row["��Ϻ�"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Diag = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// ��������,�˸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
            if (e.KeyChar == 08)
                e.Handled = false;
        }
        #endregion

        private void �����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmPatientDiagnose diag = new frmPatientDiagnose(selectedId);
                diag.ShowDialog();
            }
        }
        private string selectedId="";
        
        private DataGridViewRow selectrow;
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selectedId = dgvPatients.Rows[e.RowIndex].Cells["����ID"].Value.ToString();
                
                selectrow = dgvPatients.Rows[e.RowIndex];
            }
            else
            {
                selectedId = "";
                selectrow = null;
            }
        }

        private void dgvPatients_DoubleClick(object sender, EventArgs e)
        {
            if (selectedId != ""&&selectrow!=null)
            {
                Class_FollowInfo info=cmbFollowInfo.SelectedItem as Class_FollowInfo;
                frmFollowRecord uc = new frmFollowRecord(selectedId,info.Id,selectrow);
                uc.ShowDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataToExcel(dgvPatients);
        }

        private void �˳����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                Class_FollowInfo info=cmbFollowInfo.SelectedItem as Class_FollowInfo;
                frmFollowDelete dele = new frmFollowDelete(selectedId, info, this);
                dele.ShowDialog();
            }
        }

        private void btnAddFollow_Click(object sender, EventArgs e)
        {
            frmFollowAddPatient frm = new frmFollowAddPatient();
            frm.ShowDialog();

        }
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "����EXECL�ļ�";
            kk.Filter = "EXCEL�ļ�(*.xls) |*.xls |�����ļ�(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "����EXCEL�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ���߻�����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                frmFollowPatientBaseInfo frm = new frmFollowPatientBaseInfo(selectedId);
                frm.ShowDialog();
            }
        }
    }
}
