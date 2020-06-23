using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
//using Bifrost_Doctor.WebReferenceSouthHis;

namespace Base_Function.BASE_DATA
{
    public partial class frmImportSouthPatient : DevComponents.DotNetBar.Office2007Form
    {
        public frmImportSouthPatient()
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
        }
        DataSet Ds_Patient = new DataSet(); //��ԺHIS���˼���
        //public static Service sv = new Service();


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
                string our_current_date = "";//App.ReadSqlVal("select to_char(SQSJ,'yyyy-MM-dd') as num from T_PASC_DATA where rownum=1 order by SQSJ desc", 0, "num");
                DateTime datetemp = App.GetSystemTime();
                datetemp = datetemp.AddDays(-2);
                our_current_date = datetemp.Year.ToString() + "-";
                if (datetemp.Month / 10 == 0)
                {
                    our_current_date = our_current_date + "0" + datetemp.Month.ToString() + "-";
                }
                else
                {
                    our_current_date = our_current_date + datetemp.Month.ToString() + "-";
                }
                if (datetemp.Day / 10 == 0)
                {
                    our_current_date = our_current_date + "0" + datetemp.Day.ToString();
                }
                else
                {
                    our_current_date = our_current_date + datetemp.Day.ToString();
                }

                string sql_His = "";
                //if (txtPid.Text != "" || txtName.Text != "")
                //{
                string sectionCode = App.ReadSqlVal("select section_code from t_sectioninfo where sid=" + App.UserAccount.CurrentSelectRole.Section_Id, 0, "section_code");
                if (ckbTime.Checked)
                {
                    sql_His = "select * from INTF_EMR_INPATIENTINFVIEW where caseid like '%" + txtPid.Text + "%' and indate between to_date('"+dtpStartTime.Value.ToString("yyyy-MM-dd")+"','yyyy-MM-dd') and to_date('"+dtpEndTime.Value.ToString("yyyy-MM-dd")+"','yyyy-MM-dd') and hname like '%" + txtName.Text + "%' and subspecialtycode = '" + sectionCode + "' and rownum<20";
                }
                else
                {
                    sql_His = "select * from INTF_EMR_INPATIENTINFVIEW where caseid like '%" + txtPid.Text + "%' and indate>=to_date('" + our_current_date + "','yyyy-MM-dd') and hname like '%" + txtName.Text + "%' and subspecialtycode = '" + sectionCode + "'  and rownum<20";
                }
                //Ds_Patient = sv.GetSouthHisData(sql_His);
                dgvHISPatient.DataSource = Ds_Patient.Tables[0].DefaultView;
                dgvHISPatient.Columns["INCHCODE"].HeaderText = "סԺ��ˮ��";
                dgvHISPatient.Columns["CASEID"].HeaderText = "סԺ����";
                dgvHISPatient.Columns["HNAME"].HeaderText = "��������";
                dgvHISPatient.Columns["SEXCODE"].HeaderText = "�Ա�";
                dgvHISPatient.Columns["CERTIFICATEID"].HeaderText = "���֤��";
                dgvHISPatient.Columns["INDATE"].HeaderText = "סԺʱ��";

                dgvHISPatient.Columns["INSURANCEID"].Visible = false;
                dgvHISPatient.Columns["MIOCARDID"].Visible = false;
                dgvHISPatient.Columns["HISCARDID"].Visible = false;
                dgvHISPatient.Columns["PHONENUMB"].Visible = false;
                dgvHISPatient.Columns["BORNPLACEPROVINCE"].Visible = false;
                dgvHISPatient.Columns["DOB"].Visible = false;
                dgvHISPatient.Columns["HOMEADDRESS"].Visible = false;
                dgvHISPatient.Columns["MARRYCODE"].Visible = false;
                dgvHISPatient.Columns["COUNTRYSCODE"].Visible = false;
                dgvHISPatient.Columns["NATIVEPLACE"].Visible = false;
                dgvHISPatient.Columns["RACE"].Visible = false;
                dgvHISPatient.Columns["LINKMANNAME"].Visible = false;
                dgvHISPatient.Columns["LINKMANADDRESS"].Visible = false;
                dgvHISPatient.Columns["LINKMANPHONE"].Visible = false;
                dgvHISPatient.Columns["RELATIONSHIP"].Visible = false;
                dgvHISPatient.Columns["ININFODATE"].Visible = false;
                dgvHISPatient.Columns["SUBSPECIALTYCODE"].Visible = false;
                dgvHISPatient.Columns["ATTENDINGDOCTOR"].Visible = false;
                dgvHISPatient.Columns["CLAIMPOLICYCODE"].Visible = false;
                dgvHISPatient.Columns["OUTCOMETYPE"].Visible = false;
                dgvHISPatient.Columns["ADMITTINGSOURCE"].Visible = false;

                for (int i = 0; i < dgvHISPatient.Rows.Count; i++)
                {
                    if (dgvHISPatient.Rows[i].Cells["SEXCODE"].Value.ToString() =="M")
                    {
                        dgvHISPatient.Rows[i].Cells["SEXCODE"].Value = "��";
                    }
                    else
                    {
                        dgvHISPatient.Rows[i].Cells["SEXCODE"].Value = "Ů";
                    }
                }

                dgvHISPatient_Click(sender, e);
            }
            catch (Exception ex)
            {
                App.MsgErr("��ѯʧ�ܣ���ϸԭ�򣺽���������࣬����Ĳ�ѯ��Χ��" );
            }

        }

        private void frmImportSouthPatient_Load(object sender, EventArgs e)
        {
            BandSickArea();//�󶨲���
        }
        private void BandSickArea()
        {
            string sql_sickArea = "select said,sick_area_name from t_sickareainfo";
            cbxSickArea.DisplayMember = "sick_area_name";
            cbxSickArea.ValueMember = "said";
            cbxSickArea.DataSource = App.GetDataSet(sql_sickArea).Tables[0];
        }

        //�󶨵�ǰ����ҽ��
        private void BandDoctor(string sectionId)
        {
            try
            {
                string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                        " inner join t_account_user b on a.user_id=b.user_id" +
                        " inner join t_account c on b.account_id = c.account_id" +
                        " inner join t_acc_role d on d.account_id = c.account_id" +
                        " inner join t_role e on e.role_id = d.role_id" +
                        " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                        " where f.section_id='" + sectionId + "' and  e.role_type='D' and a.Profession_Card='true'";
                DataSet ds = App.GetDataSet(Sql);
                cboSickDoctor.ValueMember = "user_id";
                cboSickDoctor.DisplayMember = "user_name";
                cboSickDoctor.DataSource = ds.Tables[0].DefaultView;
            }
            catch
            {
            }
        }

        private void dgvHISPatient_Click(object sender, EventArgs e)
        {
            if (dgvHISPatient.CurrentRow != null)
            {
                cboSickDoctor.DataSource = null;
                //���Ҵ���
                string sectionCode = dgvHISPatient.CurrentRow.Cells["SUBSPECIALTYCODE"].Value.ToString();
                //���ݿ��Ҵ����ȡ����ID
                string sectionId = App.ReadSqlVal("select sid from t_sectioninfo where section_code='" + sectionCode + "'", 0, "sid");
                if (sectionId != "")
                {
                    BandDoctor(sectionId);
                }
            }
        }

        /// <summary>
        /// ����HIS���˵Ļ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList sqls = new ArrayList();
                int currRowIndex = dgvHISPatient.CurrentRow.Index;//��ǰѡ���е�����
                string patientpid = "select * from t_in_patient where inhospital_id = '" + dgvHISPatient.CurrentRow.Cells["INCHCODE"].Value + "'";
                DataSet dspatientpid = App.GetDataSet(patientpid);
                if (dspatientpid.Tables[0].Rows.Count > 0)
                {
                    App.Msg("��ǰ������Ϣ�Ѿ�ͬ���������ٴβ�����");
                    return;
                }
                if (cboSickDoctor.DataSource != null && cboSickDoctor.Items.Count > 0)
                {

                    //����ǰ������Ϣ���뵽���ݿ���
                    string sql_doc = "";
                    DataSet Ds_Doctor = new DataSet();
                    //���˻�����Ϣ
                    if (Ds_Patient != null && Ds_Patient.Tables[0].Rows.Count > 0)
                    {
                        //Ds_Patient.Tables[0].Rows[0][""].ToString();������Ϣ
                    }
                    else
                    {
                        App.Msg("������Ϣû�в鵽��");
                    }
                    //�������ݿ�
                    if (cboSickDoctor.Text.ToString().Trim() != "")
                    {
                        sql_doc = "select * from t_userinfo tt where tt.user_name='" + cboSickDoctor.Text.ToString().Trim() + "'";
                        Ds_Doctor = App.GetDataSet(sql_doc);
                        if (Ds_Patient != null && Ds_Patient.Tables[0].Rows.Count > 0)
                        {
                            int id = App.GenId("t_in_patient", "id");
                            if (id == 1)
                            {
                                id = 100001;
                            }
                            #region �Ա�
                            //�Ա�
                            char gender_code = ' ';
                            if (Ds_Patient.Tables[0].Rows[currRowIndex]["SEXCODE"].ToString() == "M")
                            {
                                gender_code = '0';
                            }
                            else
                            {
                                gender_code = '1';
                            }
                            #endregion
                            #region ����״̬
                            //����״̬ δ�� 1   �ѻ� 2  ��� 3   ɥż 4  ���� 5
                            string marriage_state = "";
                            if (Ds_Patient.Tables[0].Rows[currRowIndex]["MARRYCODE"].ToString() == "M")
                            {
                                marriage_state = "2";
                            }
                            else if (Ds_Patient.Tables[0].Rows[currRowIndex]["MARRYCODE"].ToString() == "D")
                            {
                                marriage_state = "3";
                            }
                            else if (Ds_Patient.Tables[0].Rows[currRowIndex]["MARRYCODE"].ToString() == "S")
                            {
                                marriage_state = "1";
                            }
                            else if (Ds_Patient.Tables[0].Rows[currRowIndex]["MARRYCODE"].ToString() == "W")
                            {
                                marriage_state = "4";
                            }
                            else
                            {
                                marriage_state = "5";
                            }
                            #endregion
                            #region ��ǰ������Ϣ
                            string section_id = Ds_Doctor.Tables[0].Rows[0]["section_id"].ToString();
                            string section_name = App.ReadSqlVal("select section_name from t_sectioninfo where sid='" + section_id + "'", 0, "section_name");
                            #endregion
                            #region ����
                            string sql_folk = "select * from INTF_FOLKVIEW where Code_ABBR='" + Ds_Patient.Tables[0].Rows[currRowIndex]["RACE"].ToString() + "'";
                            DataSet ds_folk =new DataSet(); //sv.GetSouthHisData(sql_folk);
                            int folk = 0;
                            if (ds_folk !=null &&ds_folk.Tables[0].Rows.Count>0)
                            {
                                folk = Convert.ToInt32(App.ReadSqlVal("select * from t_data_code where id>5000 and id<5057 and  name='" + ds_folk.Tables[0].Rows[0]["Code_Desc"].ToString() + "'", 0, "code")); 
                            }
                            #endregion
                            #region ����
                            string sql_country = "select * from INTF_COUNTRYSVIEW where Code_ABBR='" + Ds_Patient.Tables[0].Rows[currRowIndex]["COUNTRYSCODE"].ToString() + "'";
                            DataSet ds_country = new DataSet(); //sv.GetSouthHisData(sql_country);
                            string country = "";
                            string country_code = "";
                            if (ds_country!=null && ds_country.Tables[0].Rows.Count>0)
                            {
                                country = ds_country.Tables[0].Rows[0]["Code_Desc"].ToString();
                                country_code = App.ReadSqlVal("select * from t_data_code a where a.id>5057 and a.id<5278 and a.name='" + country + "'", 0, "code");
                            }
                           
                            #endregion
                            #region ��ϵ
                            string sql_relation = "select * from INTF_RELATIONSHIPVIEW a where a.code_abbr='" + Ds_Patient.Tables[0].Rows[currRowIndex]["RELATIONSHIP"].ToString() + "'";
                            DataSet ds_relation = new DataSet();//sv.GetSouthHisData(sql_relation);
                            string relation = "";
                            string relation_code = "";
                            if (ds_relation!= null && ds_relation.Tables[0].Rows.Count>0)
                            {
                                relation = ds_relation.Tables[0].Rows[0]["code_desc"].ToString();
                                relation_code = App.ReadSqlVal("select * from t_data_code a where a.id>5278 and a.id<5381 and a.name='" + relation + "'", 0, "code");
                            }
                           
                            #endregion
                            //���˻�����Ϣ
                            string sql_insert = "insert into t_in_patient (ID,PATIENT_NAME,GENDER_CODE,BIRTHDAY," +
                                        "MARRIAGE_STATE,PID,COUNTRY," +
                                        "NATIVE_PLACE,BIRTH_PLACE,FOLK_CODE," +
                                        " MEDICARE_NO,HOME_ADDRESS," +
                                        "RELATION_NAME,RELATION,RELATION_ADDRESS,RELATION_PHONE," +
                                        "CERT_ID,out_id,SECTION_ID,SECTION_NAME,SICK_DOCTOR_ID," +
                                        "SICK_DOCTOR_NAME,IN_Time,INHOSPITAL_ID,sick_bed_id,sick_bed_no,in_bed_id,in_bed_no,in_doctor_id,in_doctor_name," +
                                        "in_area_id,in_area_name,sick_area_id,sick_area_name)values(" +
                                        "'" + id + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["HNAME"].ToString() + "','" + gender_code + "',to_timestamp('" + Convert.ToDateTime(Ds_Patient.Tables[0].Rows[currRowIndex]["DOB"]).ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9')," +
                                        "'" + marriage_state + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["CASEID"].ToString() + "','" + country_code + "'," +
                                        "'" + Ds_Patient.Tables[0].Rows[currRowIndex]["NATIVEPLACE"].ToString() + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["BORNPLACEPROVINCE"].ToString() + "','" + folk + "'," +
                                        "'" + Ds_Patient.Tables[0].Rows[currRowIndex]["CERTIFICATEID"].ToString() + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["HOMEADDRESS"].ToString() + "'," +
                                        "'" + Ds_Patient.Tables[0].Rows[currRowIndex]["LINKMANNAME"].ToString() + "','" + relation_code + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["LINKMANADDRESS"].ToString() + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["LINKMANPHONE"].ToString() + "'," +
                                        "'" + Ds_Patient.Tables[0].Rows[currRowIndex]["CERTIFICATEID"].ToString() + "','" + Ds_Patient.Tables[0].Rows[currRowIndex]["INCHCODE"].ToString() + "'," +
                                        "'" + Convert.ToInt32(Ds_Doctor.Tables[0].Rows[0]["section_id"].ToString()) + "','" + section_name + "'," +
                                        "'" + Ds_Doctor.Tables[0].Rows[0]["user_id"].ToString() + "','" + Ds_Doctor.Tables[0].Rows[0]["user_name"].ToString() + "',to_timestamp('" + Convert.ToDateTime(Ds_Patient.Tables[0].Rows[currRowIndex]["INDATE"]).ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + Ds_Patient.Tables[0].Rows[currRowIndex]["INCHCODE"].ToString() + "'," +
                                        cbxSickBedNo.SelectedValue + ",'" + cbxSickBedNo.Text + "'," + cbxSickBedNo.SelectedValue + ",'" + cbxSickBedNo.Text + "'," +
                                        cboSickDoctor.SelectedValue + ",'" + cboSickDoctor.Text + "'," +
                                        cbxSickArea.SelectedValue + ",'" + cbxSickArea.Text + "'," + cbxSickArea.SelectedValue + ",'" + cbxSickArea.Text + "')";

                            //ָ�����ź󣬸ô���״̬��Ϊռ��74
                            string UpdateBed_State = "update t_sickbedinfo set state=74,pid=" + id + " where bed_no='" + cbxSickBedNo.SelectedValue + "'";
                            int actionId = App.GenId("t_inhospital_action", "id");
                            //���춯�����һ��������¼
                            string InsertInArea = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                                   " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                                   " values(" + actionId.ToString() + ",(select sid from T_SECTIONINFO where section_code='" + Ds_Patient.Tables[0].Rows[currRowIndex]["SUBSPECIALTYCODE"].ToString() + "' and rownum=1)," + cbxSickArea.SelectedValue + ",'" + Ds_Patient.Tables[0].Rows[currRowIndex]["caseid"].ToString() + "'," +
                                                   "'����','4',sysdate," + cbxSickBedNo.SelectedValue + ",'" + cboSickDoctor.SelectedValue + "',0,0,0," + id + ")";
                            //���ʿ���ʱ������һ��������¼
                            string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
                                                    " values('" + Ds_Patient.Tables[0].Rows[currRowIndex]["caseid"].ToString() + "','����',to_timestamp('" + Convert.ToDateTime(Ds_Patient.Tables[0].Rows[currRowIndex]["indate"]).ToString("yyyy-MM-dd HH:mm:ss")
                                                    + "','yyyy-MM-dd hh24:mi:ss')," + id + ")";
                            sqls.Add(sql_insert);
                            sqls.Add(UpdateBed_State);
                            sqls.Add(InsertInArea);
                            sqls.Add(InsertJob_Temp);
                            string[] sqlsstrs = new string[sqls.Count];
                            for (int i = 0; i < sqls.Count; i++)
                            {
                                sqlsstrs[i] = sqls[i].ToString();
                            }
                            if (App.ExecuteBatch(sqlsstrs) > 0)
                            {
                                App.Msg("��ǰ���������ɹ���");
                            }
                        }
                        else
                        {
                            //
                        }
                    }
                    else
                    {
                        App.MsgWaring("�ò������ڿ��ҵ�ҽ����δ�������Ӳ���ϵͳ�ĵ�¼�ʺţ�");

                    }
                }
                else
                {
                    App.MsgWaring("�ò������ڿ��ҵ�ҽ����δ�������Ӳ���ϵͳ�ĵ�¼�ʺţ�");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ�ܣ���ϸԭ��" + ex.Message);
            }
        }

        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSickArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_sickBed = "select bed_id,bed_no from t_sickbedinfo where said=" + cbxSickArea.SelectedValue;
            //cbxSickBedNo.DataSource = null;
            cbxSickBedNo.DisplayMember = "bed_no";
            cbxSickBedNo.ValueMember = "bed_id";
            cbxSickBedNo.DataSource = App.GetDataSet(sql_sickBed).Tables[0];

        }

        private void ckbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTime.Checked)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }
    }
}