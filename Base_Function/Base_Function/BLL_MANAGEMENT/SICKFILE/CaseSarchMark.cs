using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using System.Collections;
using Base_Function.BLL_DOCTOR;
using Bifrost.HisInstance;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class CaseSearchMark : UserControl
    {
        DataSet ds = new DataSet();
        public CaseSearchMark()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            ucC1FlexGrid1.fg.AllowEditing = false;
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
            ucC1FlexGrid1.fg.ContextMenuStrip = this.contextMenuStrip1;
            
            cbxTimeType.SelectedIndex = 0;
            cbxDocumentState.SelectedIndex = 0;
            //btnQuery_Click(sender, e);
            try
            {
                string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,a.section_code";//��ѯ����
                string sql_Sick = @"select a.said,a.sick_area_code,a.sick_area_name from t_sickareainfo a 
                                    inner join t_section_area b on a.said=b.said
                                    group  by a.shid,a.said,a.sick_area_code,a.sick_area_name
                                    order by a.shid,a.sick_area_code";//��ѯ����
                //�������˵���
                //��Ժ����
                DataSet ds_InSection = new DataSet();

                ds_InSection = App.GetDataSet(sql_Section);
                //����Ĭ��ѡ���ѡ��
                if (ds_InSection != null)
                {
                    DataRow dr = ds_InSection.Tables[0].NewRow();
                    dr["sid"] = 0;
                    dr["section_name"] = "��ѡ��";
                    ds_InSection.Tables[0].Rows.InsertAt(dr, 0);
                }
                cbxInSection.DataSource = ds_InSection.Tables[0];
                cbxInSection.DisplayMember = "section_name";
                cbxInSection.ValueMember = "sid";

                //��Ժ����
                DataSet ds_OutSection = new DataSet();
                ds_OutSection = App.GetDataSet(sql_Section);
                //����Ĭ��ѡ���ѡ��
                if (ds_OutSection != null)
                {
                    DataRow dr = ds_OutSection.Tables[0].NewRow();
                    dr["sid"] = 0;
                    dr["section_name"] = "��ѡ��";
                    ds_OutSection.Tables[0].Rows.InsertAt(dr, 0);
                }
                cbxOutSection.DataSource = ds_OutSection.Tables[0];
                cbxOutSection.DisplayMember = "section_name";
                cbxOutSection.ValueMember = "sid";

                //��Ժ����
                DataSet ds_InSick = App.GetDataSet(sql_Sick);
                //����Ĭ��ѡ���ѡ��
                if (ds_InSick != null)
                {
                    DataRow dr = ds_InSick.Tables[0].NewRow();
                    dr["said"] = 0;
                    dr["sick_area_name"] = "��ѡ��";
                    ds_InSick.Tables[0].Rows.InsertAt(dr, 0);
                }
                cbxInSick.DataSource = ds_InSick.Tables[0];
                cbxInSick.DisplayMember = "sick_area_name";
                cbxInSick.ValueMember = "said";

                //��Ժ����
                DataSet ds_OutSick = App.GetDataSet(sql_Sick);
                //����Ĭ��ѡ���ѡ��
                if (ds_OutSick != null)
                {
                    DataRow dr = ds_OutSick.Tables[0].NewRow();
                    dr["said"] = 0;
                    dr["sick_area_name"] = "��ѡ��";
                    ds_OutSick.Tables[0].Rows.InsertAt(dr, 0);
                }
                cbxOutSick.DataSource = ds_OutSick.Tables[0];
                cbxOutSick.DisplayMember = "sick_area_name";
                cbxOutSick.ValueMember = "said";

                cbxUnit.SelectedIndex = 0;//��ʱ���ѯ��λĬ�Ͼ�ȷ����


            }
            catch { }
        }

        private void CaseSearchMark_Load(object sender, EventArgs e)
        {
            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lblCount.Text = "0";
                //,concat(age,age_unit) ����
                string sql = "";
                if (cbxDocumentState.Text == "ȫ��")
                {
                    sql = "select distinct t.id,t.pid סԺ��,t.sick_bed_no ����,t.patient_name ��������,(case when gender_code=0 then '��' else 'Ů' end) �Ա� ,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name �ܴ�ҽ��,to_char(in_time,'yyyy-MM-dd HH24:mi') ��Ժʱ��,die_time ��Ժʱ��,insection_name ��Ժ����,section_name ��Ժ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,birthday from t_in_patient t left join t_diagnose_item b on t.id=b.patient_id where 1=1 ";
                }
                else if (cbxDocumentState.Text == "�ѹ鵵")
                {
                    sql = "select distinct t.id,t.pid סԺ��,t.sick_bed_no ����,t.patient_name ��������,(case when gender_code=0 then '��' else 'Ů' end) �Ա� ,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name �ܴ�ҽ��,to_char(in_time,'yyyy-MM-dd HH24:mi') ��Ժʱ��,die_time ��Ժʱ��,insection_name ��Ժ����,section_name ��Ժ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,birthday from t_in_patient t left join t_diagnose_item b on t.id=b.patient_id where document_state is not null ";
                }
                else//δ�鵵
                {
                    sql = "select distinct t.id,t.pid סԺ��,t.sick_bed_no ����,t.patient_name ��������,(case when gender_code=0 then '��' else 'Ů' end) �Ա� ,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  ����,sick_doctor_name �ܴ�ҽ��,to_char(in_time,'yyyy-MM-dd HH24:mi') ��Ժʱ��,die_time ��Ժʱ��,insection_name ��Ժ����,section_name ��Ժ����,case DOCUMENT_STATE when '1' then '�ѹ鵵' else 'δ�鵵' end �鵵״̬,birthday from t_in_patient t left join t_diagnose_item b on t.id=b.patient_id where document_state is null ";
                }
                if (txtPid.Text != "")//סԺ��ģ����ѯ
                {
                    sql += " and pid like '%" + txtPid.Text.Trim() + "%'";
                }
                if (txtName.Text != "")//������������ѯ
                {
                    sql += " and patient_name like '" + txtName.Text.Trim() + "%'";
                }
                if (cbxInSection.SelectedIndex != 0)//����Ժ���Ҳ�ѯ
                {
                    sql += " and insection_id =" + cbxInSection.SelectedValue.ToString();
                }
                if (cbxInSick.SelectedIndex != 0)//����Ժ������ѯ
                {
                    sql += " and in_area_id =" + cbxInSick.SelectedValue.ToString();
                }
                if (cbxOutSection.SelectedIndex != 0)//����Ժ���Ҳ�ѯ
                {
                    sql += " and section_id =" + cbxOutSection.SelectedValue.ToString();
                }
                if (cbxOutSick.SelectedIndex != 0)//����Ժ������ѯ
                {
                    sql += " and sick_area_id =" + cbxOutSick.SelectedValue.ToString();
                }
                if (cbxDoctor.SelectedIndex != 0 && cbxDoctor.SelectedIndex != -1)//���ܴ�ҽ����ѯ
                {
                    sql += " and sick_doctor_id ='" + cbxDoctor.SelectedValue.ToString() + "'";
                }
                else if (cbxDoctor.Text.Trim() != "" && cbxDoctor.Text!="��ѡ��")
                {
                    sql += " and sick_doctor_name like '%" + cbxDoctor.Text.ToString() + "%'";
                }
                if (cbxStatus.SelectedIndex > 0)//������״̬��ѯ
                {
                    if (cbxStatus.Text.Contains("��Ժ"))
                    {
                        sql += " and die_time is null";
                    }
                    else
                    {
                        sql += " and die_time is not null";
                    }
                }
                if (chbEnable.Checked)//��ʱ���ѯ
                {
                    if (cbxTimeType.Text == "��Ժʱ��")
                    {
                        if (cbxUnit.Text == "��")
                            sql += " and to_char(in_time,'yyyy-MM')='" + dtpTimestart.Value.ToString("yyyy-MM") + "'";
                        else
                            sql += " and to_char(in_time,'yyyy-MM-dd')='" + dtpTimestart.Value.ToString("yyyy-MM-dd") + "'";

                    }
                    else if (cbxTimeType.Text == "��Ժʱ��")
                    {
                        if (cbxUnit.Text == "��")
                            sql += " and to_char(die_time,'yyyy-MM')='" + dtpTimestart.Value.ToString("yyyy-MM") + "'";
                        else
                            sql += " and to_char(die_time,'yyyy-MM-dd')='" + dtpTimestart.Value.ToString("yyyy-MM-dd") + "'";
                    }
                }
                if (txtDiagnoseName.Text != "")
                {
                    sql += " and b.diagnose_type=406 and b.diagnose_name like '%" + txtDiagnoseName.Text + "%'";
                }
                if (!chbNewborn.Checked)
                {//�Ƿ��ѯ������
                    sql += " and instr(t.pid,'_')=0";
                }

                sql += " order by id desc";
                
                string sqlCount = @"select count(1) cc from (" + sql + ")";
                ds = App.GetDataSet(sqlCount);
                if (ds != null)
                {
                    lblCount.Text=ds.Tables[0].Rows[0][0].ToString();
                    ucC1FlexGrid1.DataBd(sql, "id", "", "");
                    ucC1FlexGrid1.fg.Cols["birthday"].Visible = false;
                    //��������
                    //CountAgeByBirthday();
                }
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message.ToString());
            }
            ucC1FlexGrid1.fg.AllowEditing = false;
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
                    string birthday = ds.Tables[0].Rows[i]["birthday"].ToString(); //����
                    string in_time = ds.Tables[0].Rows[i]["��Ժʱ��"].ToString(); //����
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
                    ucC1FlexGrid1.fg.Cols["����"][i + 1] = strTemp;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ����/����ʱ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnable.Checked)
            {
                dtpTimestart.Enabled = true;
                label3.Enabled = true;
                cbxUnit.Enabled = true;
                cbxTimeType.Enabled = true;
                
            }
            else
            {
                dtpTimestart.Enabled = false;
                label3.Enabled = false;
                cbxUnit.Enabled = false;
                cbxTimeType.Enabled = false;

            }
        }

        /// <summary>
        /// ����ʱ����������ʾ��ʽ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUnit.Text == "��")
            {
                dtpTimestart.CustomFormat = "yyyy-MM";
            }
            else
            {
                dtpTimestart.CustomFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// ��Ժ���������˵�ѡ����ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOutSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxDoctor.Items.Clear();//���ҽ�������б��������
            cbxDoctor.DataSource = null;
            string sql_doctor = "select user_id,user_name from t_userinfo order by user_name";
            if (Convert.ToInt32(cbxOutSection.SelectedIndex) != 0)
            {
                sql_doctor = "select user_id,user_name from t_userinfo where section_id=" + cbxOutSection.SelectedValue.ToString() + " order by user_name";
                string said = GetSaid(cbxOutSection.SelectedValue);
                cbxOutSick.SelectedValue = said;
            }
            DataSet ds_Doctores = App.GetDataSet(sql_doctor);
            if (ds_Doctores != null)
            {
                DataRow dr = ds_Doctores.Tables[0].NewRow();
                dr["user_id"] = 0;
                dr["user_name"] = "��ѡ��";
                ds_Doctores.Tables[0].Rows.InsertAt(dr, 0);
            }
            cbxDoctor.DataSource = ds_Doctores.Tables[0];
            cbxDoctor.ValueMember = "user_id";
            cbxDoctor.DisplayMember = "user_name";
            
        }

        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel >= 1)
                {

                    int row = this.ucC1FlexGrid1.fg.MouseRow;
                    string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                    string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                    string sql = "select * from t_in_patient t where t.id='" + id + "'";
                    DataSet ds1 = App.GetDataSet(sql);
                    if (ds1 != null)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            InPatientInfo patientInfo = new InPatientInfo();
                            patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                            patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                            patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
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

                            ucDoctorOperater fq = new ucDoctorOperater(patientInfo);
                            //frmMain fq = new frmMain(patientInfo, false, patientInfo.Id);
                            App.AddNewBusUcControl(fq,"��������");
                            ucC1FlexGrid1.fg.AllowEditing = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        /// <summary>
        /// ���ò�ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lklNullCondition_Click(object sender, EventArgs e)
        {
            lblCount.Text = "0";
            txtName.Text = "";
            txtPid.Text = "";
            txtDiagnoseName.Text = "";
            cbxInSection.SelectedIndex = 0;
            cbxInSick.SelectedIndex = 0;
            cbxOutSection.SelectedIndex = 0;
            cbxOutSick.SelectedIndex = 0;
            chbEnable.Checked = false;
        }

        private void �鵵�˻�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //t_doc_neaten

            int id = App.GenId("t_inhospital_action", "id");
            ArrayList Sqls = new ArrayList();

            string sql_Select = "select * from T_INHOSPITAL_ACTION_HISTORY where pid='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString() + "' order by id";
            DataSet dsactionhistory = App.GetDataSet(sql_Select);
            //string[] strsqls = new string[dsactionhistory.Tables[0].Rows.Count+3];


            string strsql = "delete from t_doc_neaten where pid='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString() + "'";
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

            strsql = "delete from T_INHOSPITAL_ACTION_HISTORY where pid='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString() + "'";
            Sqls.Add(strsql);
            strsql = "update t_in_patient set baupload='2',document_state=null,exe_document_time=(Sysdate+1) where id='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString() + "'";
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
            catch (Exception ex)
            {
                App.Msg("�˻�ʧ�ܣ�ԭ��" + ex.Message);
            }
        }

        private void cbxInSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxInSection.SelectedIndex != 0)
            {
                string said = GetSaid(cbxInSection.SelectedValue);
                cbxInSick.SelectedValue = said;
            }
        }
        private string GetSaid(object sid)
        {
            string said =string.Empty;
            string select_said = "select said from t_section_area where sid='" + sid + "'";
            said = App.ReadSqlVal(select_said, 0, "said");

            return said;
        }

        /// <summary>
        /// �鿴PACS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                InPatientInfo inPatient =BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// �鿴LIS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                FrmLis fc = new FrmLis(pid);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void ҽ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                if (inPatient != null)
                {
                    frmYZ fc = new frmYZ(inPatient);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("����ѡ���˻�ǰ����û������!");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /*
             * ����admin�Ҽ��в���ʾ���鵵�˻ء���ť
             */
            if (App.UserAccount.UserInfo.User_name == "����Ա" && ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�鵵״̬"].ToString()=="�ѹ鵵")
            {
                �鵵�˻�ToolStripMenuItem.Visible = true;
            }
            else
            {
                �鵵�˻�ToolStripMenuItem.Visible = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "��������.xls";
            saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            //fg.SaveExcel(pathname);
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
            //DataInit.DataSetToExcel(ds, pathname, false);
        }

        

    }
}
