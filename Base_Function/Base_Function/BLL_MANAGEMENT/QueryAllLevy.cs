using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
//using Inhospital_Info.CommonClass;
using System.Xml;
using System.Text.RegularExpressions;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using Bifrost.HisInstance;

namespace Base_Function.BLL_MANAGEMENT
{
    /// <summary>
    /// ��ѯ���в�����Ϣ
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class QueryAllLevy : UserControl
    {
        /// <summary>
        /// �鵵״̬
        /// </summary>
        private bool boolFlag = false;
        string str = "";
        InPatientInfo inpatent=new InPatientInfo();
        private DataSet ds = null;
        public QueryAllLevy()
        {
            try
            {
                InitializeComponent();
                App.UsControlStyle(this);
            }
            catch
            {
            }
        }
        string saID = "";
        public QueryAllLevy(string said)
        {
            try
            {

                InitializeComponent();
                App.UsControlStyle(this);
                this.saID = said;
            }
            catch
            {
            }
        }

        private void QueryAllLevy_Load(object sender, EventArgs e)
        {
            try
            {
                cmbBox.SelectedIndex = 0;
                SelectAllLevy(); 
                this.ucGridviewX1.fg.ContextMenuStrip = this.contextMenuStrip1;
                ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ucGridviewX1.fg.DataSourceChanged += new EventHandler(CurrentDataChange);
                ucGridviewX1.fg.MouseHover += new EventHandler(fg_MouseHover);
                ucGridviewX1.fg.DoubleClick += new EventHandler(fg_DoubleClick);
            }
            catch(Exception ex)
            {
 
            }
        }

        private void  SelectAllLevy()
        {
            str = "";
            //, as ��Ժ��� 
            try
            {
                string colorswitch = "";
                if (!string.IsNullOrEmpty(saID))
                {
                    str = " and Sick_area_id='" + saID + "'";
                    colorswitch = str;
                }
                str = str + " order by id desc";
                string sql = "select ID as ID,PID as סԺ��, sick_bed_no as ����,patient_name as ����,case gender_code when '1' then 'Ů' else '��' end as �Ա�,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name as �ܴ�ҽ��,in_time as סԺ����,decode(a.sick_degree,'1','һ��','2','����','3','��Σ') as Σ�س̶�,case (select count(*) from t_vital_signs b where b.patient_id=a.id and b.describe like'%����%' ) when 0 then 'N' else 'Y' end ����," +
                  " section_name as ��ǰ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,EXE_DOCUMENT_TIME as �鵵ִ��ʱ��,ISGETPAPERDOC as �Ͻ�ֽ�ʲ���,section_name,birthday from t_in_patient a where  patient_name like '%" + txtPatientName.Text + "%' and PID like '%" + txtPid.Text.Trim() + "%' ";
                if (cmbBox.SelectedIndex == 0)
                {
                    //δ���鵵
                    sql = "select ID as ID,PID as סԺ��, sick_bed_no as ����,patient_name as ����,case gender_code when '1' then 'Ů' else '��' end as �Ա�,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name as �ܴ�ҽ��,in_time as סԺ����,decode(a.sick_degree,'1','һ��','2','����','3','��Σ') as Σ�س̶�,case (select count(*) from t_vital_signs b where b.patient_id=a.id and b.describe like'%����%' ) when 0 then 'N' else 'Y' end ����," +
                  " section_name as ��ǰ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,EXE_DOCUMENT_TIME as �鵵ִ��ʱ��,ISGETPAPERDOC as �Ͻ�ֽ�ʲ���,section_name,birthday from t_in_patient a where   patient_name like '%" + txtPatientName.Text + "%' and PID like '%" + txtPid.Text.Trim() + "%' and DOCUMENT_STATE is null "+str;
                }
                else
                {
                    //�Ѿ��鵵
                    sql = "select ID as ID,PID as סԺ��, sick_bed_no as ����,patient_name as ����,case gender_code when '1' then 'Ů' else '��' end as �Ա�,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name as �ܴ�ҽ��,in_time as סԺ����,decode(a.sick_degree,'1','һ��','2','����','3','��Σ') as Σ�س̶�,case (select count(*) from t_vital_signs b where b.patient_id=a.id and b.describe like'%����%' ) when 0 then 'N' else 'Y' end ����," +
                  " section_name as ��ǰ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,EXE_DOCUMENT_TIME as �鵵ִ��ʱ��,ISGETPAPERDOC as �Ͻ�ֽ�ʲ���,section_name,birthday from t_in_patient a where  patient_name like '%" + txtPatientName.Text + "%' and PID like '%" + txtPid.Text.Trim() + "%' and DOCUMENT_STATE ='1'"+str;
                }

                string final = "select count(id) from (" + sql + ")";
                
                ds = App.GetDataSet(final);

                if (ds != null)
                {
                    ucGridviewX1.DataBd(sql, "ID", "", "");
                    ucGridviewX1.fg.Columns["ID"].Width = 100;
                    ucGridviewX1.fg.Columns["סԺ��"].Width = 100;
                    ucGridviewX1.fg.Columns["����"].Width = 100;
                    ucGridviewX1.fg.Columns["����"].Width = 100;
                    ucGridviewX1.fg.Columns["�Ա�"].Width = 100;
                    ucGridviewX1.fg.Columns["����"].Width = 100;
                    ucGridviewX1.fg.Columns["�ܴ�ҽ��"].Width = 100;
                    ucGridviewX1.fg.Columns["סԺ����"].Width = 100;
                    ucGridviewX1.fg.Columns["Σ�س̶�"].Width = 100;
                    ucGridviewX1.fg.Columns["����"].Width = 60;
                    ucGridviewX1.fg.Columns["��ǰ����"].Width = 100;
                    ucGridviewX1.fg.Columns["�鵵״̬"].Width = 100;
                    ucGridviewX1.fg.Columns["section_name"].Visible = false;
                    ucGridviewX1.fg.Columns["birthday"].Visible = false;
                    ucGridviewX1.fg.Columns["�Ͻ�ֽ�ʲ���"].Visible = false;
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    //this.ucGridviewX1.fg.Columns[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
                    //}
                    BackColorSet(colorswitch);

                    //��������
                    //CountAgeByBirthday();
                }
            }
            catch (Exception ex)
            {
            }
            //ucGridviewX1.fg.Sort = false;
            //ucGridviewX1.fg.DataSource = ds;

        }
        /// <summary>
        /// ��Ϣ���ѱ���ɫ����
        /// ���Ѷ���Ϣ����ɫ
        /// ��δ����Ϣ����ɫ
        /// ��δ������Ϣ����ɫ
        /// </summary>
        private void BackColorSet(string switchs)
        {
            try
            {
                string strsql = "";
                if (cmbBox.SelectedIndex == 0)
                {
                    strsql = "select pid,flag,dispose_time from t_msg_info msg where msg.pid in(select id from t_in_patient where patient_name like '%" +
                             txtPatientName.Text + "%' and PID like '%" + txtPid.Text.Trim() + "%' and DOCUMENT_STATE is null " + switchs + ")";
                }
                else
                {
                    strsql = "select pid,flag,dispose_time from t_msg_info msg where msg.pid in(select id from t_in_patient where patient_name like '%" +
                            txtPatientName.Text + "%' and PID like '%" + txtPid.Text.Trim() + "%' and DOCUMENT_STATE ='1' " + switchs + ")";
                }
                DataSet ds_Msg = App.GetDataSet(strsql);
                for (int i = 0; i < ucGridviewX1.fg.Rows.Count; i++)
                {

                    if (ucGridviewX1.fg.Rows[i].Cells["ID"].Value != null)
                    {
                        string id = ucGridviewX1.fg.Rows[i].Cells["ID"].Value.ToString();
                        if (id != null)
                        {
                            //��ɫ
                            if (ds_Msg.Tables[0].Select("pid='" + id + "' and flag='true' and dispose_time is null").Length > 0)
                            {
                                ucGridviewX1.fg.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else if (ds_Msg.Tables[0].Select("pid='" + id + "' and flag='false'").Length > 0)//��ɫ
                            {
                                ucGridviewX1.fg.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                            }
                            else if (ds_Msg.Tables[0].Select("pid='" + id + "'").Length > 0)//gree
                            {
                                ucGridviewX1.fg.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                App.Msg(ex.Message);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void CountAgeByBirthday()
        {
            //��ҳͳ�Ƶ�������������200ʱ������
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    //string age = ds.Tables[0].Rows[i]["����"].ToString();
                    string birthday = ds.Tables[0].Rows[i]["birthday"].ToString(); //����
                    string in_time = ds.Tables[0].Rows[i]["סԺ����"].ToString(); //����
                    int year, month, day;
                    DataInit.GetAgeByBirthday(Convert.ToDateTime(birthday), Convert.ToDateTime(in_time), out year, out month, out day);
                    string strTemp = "";
                    if (year > 0)
                    {
                        strTemp = year.ToString() + "��";
                    }
                    else if (month > 0)
                    {
                        strTemp = month.ToString() + "��";
                    }
                    else
                    {
                        strTemp = day.ToString() + "��";
                    }
                    ucGridviewX1.fg["����",i + 1].Value = strTemp;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {

            try
            {
                ucGridviewX1.fg.Columns["ID"].Width = 100;
                ucGridviewX1.fg.Columns["����"].Width = 100;
                ucGridviewX1.fg.Columns["����"].Width = 100;
                ucGridviewX1.fg.Columns["�Ա�"].Width = 100;
                ucGridviewX1.fg.Columns["����"].Width = 100;
                ucGridviewX1.fg.Columns["�ܴ�ҽ��"].Width = 100;
                ucGridviewX1.fg.Columns["סԺ����"].Width = 100;
                ucGridviewX1.fg.Columns["Σ�س̶�"].Width = 100;
                ucGridviewX1.fg.Columns["����"].Width = 60;
                ucGridviewX1.fg.Columns["��ǰ����"].Width = 100;
                ucGridviewX1.fg.Columns["�鵵״̬"].Width = 100;
                //ucGridviewX1.fg.AllowEditing = false;
            }
            catch
            {
            }
        }

        int oldRow = 0;
        private void fg_MouseHover(object sender, EventArgs e)
        {
            
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    ucGridviewX1.fg.Styles[ucGridviewX1.fg.Row].BackColor = Color.Red;
            //}
            //App.Msg("��");
            //for (int i = 1; i < 200; i++)
            //{
            //    int row = ucGridviewX1.fg.BottomRow;
            //    ucGridviewX1.fg.Rows[i].StyleNew.BackColor = Color.Red;
            //}
            if (this.ucGridviewX1.fg.CurrentRow != null)
            {
                int Row = this.ucGridviewX1.fg.CurrentRow.Index;

                if (Row > 0)
                {
                    if (Row != oldRow && oldRow <= ucGridviewX1.fg.Rows.Count)
                    {
                        this.ucGridviewX1.fg.Rows[Row].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e9f7f6");
                        this.ucGridviewX1.fg.Rows[Row].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#00619d");
                        this.ucGridviewX1.fg.Cursor = Cursors.Hand;
                        //this.ucGridviewX1.fg.Columns[2].DefaultCellStyle.Font = Font.
                        if (oldRow > 0)
                        {
                            if (oldRow < ucGridviewX1.fg.Rows.Count)
                            {
                                this.ucGridviewX1.fg.Rows[oldRow].DefaultCellStyle.BackColor = this.ucGridviewX1.fg.BackColor;
                                this.ucGridviewX1.fg.Rows[oldRow].DefaultCellStyle.ForeColor = this.ucGridviewX1.fg.ForeColor;
                            }
                        }
                    }
                    oldRow = Row;
                }
            }
        }
        private void fg_DoubleClick(object sender, EventArgs e)
        {
            //DataTable table = ds.Tables[0].Rows as DataTable;
            try
            {
                if (ucGridviewX1.fg.CurrentRow != null)
                {
                    if (ucGridviewX1.fg.CurrentRow.Index >= 0)
                    {
                        if (ds!=null && ds.Tables[0].Rows.Count > 0)
                        {
                            //int row = this.ucGridviewX1.fg.MouseRow;
                            string id = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            string pid = ucGridviewX1.fg["סԺ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            if (pid != "")
                            {
                                if (ucGridviewX1.fg["�鵵״̬", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "�ѹ鵵")
                                {
                                    boolFlag = true;
                                }
                                else
                                {
                                    boolFlag = false;
                                }
                                string sql = "select * from t_in_patient t where t.id='" + id + "'";
                                DataSet ds1 = App.GetDataSet(sql);
                                if (ds1 != null)
                                {
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        InPatientInfo patientInfo = new InPatientInfo();

                                        patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                                        patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                                        //if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("��"))
                                        //{
                                        patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                                        //}
                                        //else
                                        //{
                                        //    patientInfo.Gender_Code = "1";
                                        //}
                                        patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                                        patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                                        patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                                        patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                                        patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                                        patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                                        patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                                        patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                                        patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                                        patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                                        patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                                        patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                                        patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                                        if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                                            patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                                        patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                                        patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                                        patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                                        patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                                        patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                                        patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                                        patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                                        patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                                        patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                                        patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                                        patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                                        patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                                            patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                                        else
                                        {
                                            if (patientInfo.Age == "0")
                                            {
                                                patientInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(patientInfo.Birthday).Year);
                                                patientInfo.Age_unit = "��";
                                            }
                                        }
                                        //inpatient.Action_State = row["action_state"].ToString();
                                        patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                                        patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                                            patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                                        patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                                            patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                                        patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["in_time"] != null)
                                            patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                                        patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                                        if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                                            patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                                        patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                                        patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                                        patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                                        if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                                            patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                                        patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                                        patientInfo.Nurse_Level = ds1.Tables[0].Rows[0]["nurse_level"].ToString();
                                        patientInfo.Career = ds1.Tables[0].Rows[0]["Career"].ToString();//ְҵ
                                        patientInfo.Out_Id = ds1.Tables[0].Rows[0]["out_id"].ToString();//�����
                                        patientInfo.Relation_name = ds1.Tables[0].Rows[0]["Relation_Name"].ToString();//��ϵ������

                                        inpatent = patientInfo;
                                        //inpatent.Action_State = "����";
                                        inpatent.PatientState = "����";
                                        DataInit.boolAgree = true;
                                        ucDoctorOperater fq = new ucDoctorOperater(patientInfo);
                                        App.UsControlStyle(fq);
                                        App.AddNewBusUcControl(fq, patientInfo.Patient_Name + "�������");
                                        
                                    }
                                }
                            }
                            //InPatientInfo temppatient = new InPatientInfo();
                            //temppatient.Id = Convert.ToInt32(ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "ID"].ToString());
                            //temppatient.In_Bed_Name = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"].ToString();
                            //temppatient.PId = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "סԺ��"].ToString();
                            //temppatient.Patient_Name = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"].ToString();
                            //temppatient.Section_Name = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "section_name"].ToString();
                            ////string aa = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"].ToString();
                            //if (temppatient.Age == 0)
                            //{
                            //    ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"] = "0";
                            //}
                            //else
                            //{
                            //    ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"] = temppatient.Age;
                            //}
                            //if (ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "�鵵״̬"].ToString() == "�ѹ鵵")
                            //{
                            //    boolFlag = true;
                            //}
                            //else
                            //{
                            //    boolFlag = false;
                            //}
                            //temppatient.Sick_Bed_Name = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "����"].ToString();
                            //temppatient.Gender_Code = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "�Ա�"].ToString();
                            //temppatient.In_Time = Convert.ToDateTime(ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "סԺ����"].ToString());
                            //temppatient.Sick_Area_Name = ucGridviewX1.fg[ucGridviewX1.fg.RowSel, "��ǰ����"].ToString();
                            //frmMain fq = new frmMain(temppatient, boolFlag);
                            //App.AddNewChildForm(fq);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAllLevy();
            }
            catch
            {
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (cmbBox.SelectedIndex == 1 && App.UserAccount.UserInfo.User_name == "����Ա" && ucGridviewX1.fg["�鵵״̬",
                ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "�ѹ鵵")
                �鵵�˻�ToolStripMenuItem.Visible = true;
            else
                �鵵�˻�ToolStripMenuItem.Visible = false;
            ֽ�ʲ����Ͻ�ToolStripMenuItem.Visible = false;
            if (App.UserAccount.CurrentSelectRole.Role_type == "D" || App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                this.��Ϣ����ToolStripMenuItem.Visible = false;
            }
            /*
             * �Ҽ��в���ʾ��ֽ�ʲ����Ͻ�����ť
             */
            //if (App.UserAccount.CurrentSelectRole.Role_type == "B")
            //{
            //    ֽ�ʲ����Ͻ�ToolStripMenuItem.Visible = true;
            //}
            //else
            //{
            //    ֽ�ʲ����Ͻ�ToolStripMenuItem.Visible = false;
            //}

        }

        /// <summary>
        /// �鵵�˻ز���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �鵵�˻�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //t_doc_neaten

            int id = App.GenId("t_inhospital_action", "id");
            ArrayList Sqls = new ArrayList();

            string sql_Select = "select * from T_INHOSPITAL_ACTION_HISTORY where pid='" + ucGridviewX1.fg["ID",ucGridviewX1.fg. CurrentRow.Index].Value.ToString() + "' order by id";
            DataSet dsactionhistory = App.GetDataSet(sql_Select);
            //string[] strsqls = new string[dsactionhistory.Tables[0].Rows.Count+3];


            string strsql = "delete from t_doc_neaten where pid='" + ucGridviewX1.fg["סԺ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
            Sqls.Add(strsql);
            string bedid = "";
            for (int i = 0; i < dsactionhistory.Tables[0].Rows.Count; i++)
            {
                bedid = dsactionhistory.Tables[0].Rows[i]["bed_id"].ToString();
                if (bedid.Trim() == "")
                {
                    bedid = "0";
                }
                strsql = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                       " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                       " values(" + id + "," + dsactionhistory.Tables[0].Rows[i]["sid"].ToString() + "," +
                                       dsactionhistory.Tables[0].Rows[i]["said"].ToString() + ",'" +
                                       dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + "'," +
                                       "'" + dsactionhistory.Tables[0].Rows[i]["action_type"].ToString() + "','" +
                                       dsactionhistory.Tables[0].Rows[i]["action_state"].ToString() + "',to_timestamp('" + dsactionhistory.Tables[0].Rows[i]["happen_time"].ToString()
                                                    + "','yyyy-MM-dd hh24:mi:ss')," +
                                                    bedid + ",'" +
                                                    dsactionhistory.Tables[0].Rows[i]["doctor_id"].ToString() + "'," +
                                                    dsactionhistory.Tables[0].Rows[i]["operate_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["next_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["preview_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + ")";
                id = App.GenId("t_inhospital_action", "id");
                Sqls.Add(strsql);
            }

            strsql = "delete from T_INHOSPITAL_ACTION_HISTORY where pid='" + ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
            Sqls.Add(strsql);
            //�˵���ʷ����ת��
            Sqls=App.GetData_Transfer_SQL(Sqls, ucGridviewX1.fg["ID",ucGridviewX1.fg.CurrentRow.Index].Value.ToString(), false);
            strsql = "update t_in_patient set baupload='2',document_state=null,exe_document_time=(Sysdate+1) where id='" + ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
            Sqls.Add(strsql);
            try
            {
                string[] strsqls = new string[Sqls.Count];
                for (int i = 0; i < Sqls.Count; i++)
                {
                    strsqls[i] = Sqls[i].ToString();
                }
                App.ExecuteBatch(strsqls);
                App.Msg("�˻سɹ���");
                btnQuery_Click(sender, e);
            }
            catch(Exception ex)
            {
                App.Msg("�˻�ʧ�ܣ�ԭ��"+ex.Message);
            }
        }

        /*/// <summary>
        /// �Զ��鵵����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnguidang_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlpatient = "select distinct a.id,a.pid from t_in_patient a  " +
"inner join t_inhospital_action b on a.id=b.patient_Id inner join t_sickbedinfo c on " +
"a.sick_bed_id=c.bed_id where b.next_id=0 and b.action_state=3 and b.action_type='����' and ROUND(TO_NUMBER(sysdate-to_date(to_char(b.happen_time,'yyyy-MM-dd'),'yyyy-MM-dd')))>" + numericUpDownday.Value.ToString()+ "";

                DataSet ds = App.GetDataSet(sqlpatient);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string pid = ds.Tables[0].Rows[i]["pid"].ToString();
                        string patient_Id = ds.Tables[0].Rows[i]["id"].ToString();

                        StringBuilder strBuilder = new StringBuilder();
                        //����
                        string SqlNeaten_Nurse = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                    " values ('" + pid + "',0,1,sysdate," + patient_Id + ")";
                        string SqlNeaten_Doctor = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                        " values ('" + pid + "',1,1,sysdate," + patient_Id + ")";
                        //�鵵����
                        string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
                        string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select ID,SID,SAID,TARGET_SID,TARGET_SAID,PID,ACTION_TYPE,ACTION_STATE,HAPPEN_TIME,BED_ID,TNG_ID,DOCTOR_ID,NURSE_ID,OPERATE_ID,NEXT_ID,PREVIEW_ID,patient_id from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
                        string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
                        string sql = "update t_in_patient  set document_state='1',document_time=sysdate,DOCUMENT_OPER_ID=" + App.UserAccount.UserInfo.User_id + " where id='" + patient_Id + "'";
                        strBuilder.Append(SqlNeaten_Nurse + ";");
                        strBuilder.Append(SqlNeaten_Doctor + ";");
                        strBuilder.Append(SqlActions_History + ";");
                        strBuilder.Append(SqlActions + ";");
                        strBuilder.Append(sql + ";");
                        string[] arr = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split(';');
                        App.ExecuteBatch(arr);
                    }

                    App.Msg("�����Ѿ��ɹ�");
                }
                else
                {
                    App.Msg("û�з��Ͽ��Թ鵵�Ĳ���");
                }
            }
            catch (System.Exception ex)
            {
                App.MsgErr("�Զ��鵵ʧ�ܣ�ԭ��:" + ex.Message);
            }

        }*/

        private void numericUpDownday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ��Ϣ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.CurrentRow.Index >= 1)
                {
                    if (null != ds && ds.Tables[0].Rows.Count > 0)
                    {
                        //int row = this.ucGridviewX1.fg.mou;
                        string id = ucGridviewX1.fg["ID",ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                        string pid = ucGridviewX1.fg["סԺ��",ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                        if (pid != "")
                        {
                            InPatientInfo patientInfo = DataInit.GetInpatientInfoByPid(id);
                            Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.frmNotice notice = new Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND.frmNotice(patientInfo);
                            notice.ShowDialog();
                            SelectAllLevy();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }            
        }


        private void ֽ�ʲ����Ͻ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.CurrentRow.Index >= 1)
                {
                    if (null != ds && ds.Tables[0].Rows.Count > 0)
                    {
                        string id = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                        string sql="update T_IN_PATIENT set ISGETPAPERDOC='Y' where ID=" + id + "";
                        if (ucGridviewX1.fg["ISGETPAPERDOC", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "Y")
                        {
                           sql="update T_IN_PATIENT set ISGETPAPERDOC='N' where ID=" + id + "";
                        }
                        if (App.ExecuteSQL(sql) > 0)
                        {
                            App.Msg("�����Ѿ��ɹ���");
                        }
                        else
                        {
                            App.MsgErr("�����Ѿ�ʧ�ܣ�");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }         
        }

        private void pACSӰ�񱨸�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                App.frmShowPACS(inPatient);
            }
            catch (Exception ex)
            {

            }
        }

        private void lIS���鱨��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = ucGridviewX1.fg["סԺ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                App.frmShowLIS(pid);
            }
            catch (Exception ex)
            {

            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                App.frmShowSSMZ(inPatient);
            }
            catch
            {
                App.MsgErr("����ѡ����!");
            }
        }

        private void ҽ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                frmYZ fc = new frmYZ(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }
       
    }
}