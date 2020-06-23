using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;
using Base_Function.BASE_DATA;
using System.Text.RegularExpressions;
using Base_Function.BLL_DOCTOR.Patient_Action_Manager;

namespace Base_Function.BLL_DOCTOR
{
    /// <summary>
    /// ������Ϣ
    /// 2011.8.4 ��д����
    /// </summary>
    public partial class UcPatientInfo : UserControl
    {
        private InPatientInfo inPatient;
        //private string AGE_UNIT = "��";//���䵥λ,Ĭ��Ϊ��
        //ucMain frmMain = null;
        TreeNode tempNode = null;
        /// <summary>
        /// �Ƿ���ܺ���һ�����ϵĻ�����Ϣ
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        private bool isHaveMoreOlderInfos(string pid, string idcard)
        {
            try
            {
                string sql = string.Format("select  id from t_in_patient t where pid='{0}' or card_id='{1}'", pid, idcard);

                DataSet ds = App.GetDataSet(sql);

                if (ds.Tables[0].Rows.Count > 1)
                {
                    //����һ�����ϵĻ�����Ϣ
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //��ʼ�����ʽ
        private void InitCbxPay()
        {
            DataTable dataTable;
            DataRow newrow;
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type=70");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            //newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cbxPay1.DataSource = dataTable.DefaultView;
            this.cbxPay1.ValueMember = "CODE";
            this.cbxPay1.DisplayMember = "Name";
        }


        /// <summary>
        /// �󶨹���
        /// </summary>
        private void InitCbxNationality()
        {
            DataTable dt = null;
            DataSet ds = App.GetDataSet("select code,name from t_data_code t where t.type=130 order by case  when t.name='�й�' then 0 else 1 end,code");
            dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row[0] = "0";
            row[1] = "��ѡ��";
            dt.Rows.InsertAt(row, 0);
            cbxNationality.DisplayMember = "name";
            cbxNationality.ValueMember = "code";
            cbxNationality.DataSource = dt.DefaultView;
            if (!string.IsNullOrEmpty(inPatient.Country))
            {
                cbxNationality.SelectedValue = inPatient.Country;
            }
            else
            {
                cbxNationality.SelectedIndex = 0;
            }
        }
        private void btnAddIn_Danger_Click(object sender, EventArgs e)
        {
            //this.btnAddIn_Danger.Enabled = true;
            //this.btnStopIn_Danger.Enabled = true;
            //this.btnAddIll.Enabled = false;
            //this.btnStopIll.Enabled = false;
            //inPatient.Sick_Degree = "��Σ";
            //try
            //{
            //    //���ʿ���ʱ������һ����Σ��¼
            //    string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
            //                            " values('" + inPatient.PId + "','��Σ',sysdate," + inPatient.Id + ")";
            //    App.ExecuteSQL(InsertJob_Temp);
            //}
            //catch (Exception)
            //{
            //}
        }

        private void btnAddIll_Click(object sender, EventArgs e)
        {
            //this.btnAddIn_Danger.Enabled = false;
            //this.btnStopIn_Danger.Enabled = false;
            //this.btnAddIll.Enabled = true;
            //this.btnStopIll.Enabled = true;
            //inPatient.Sick_Degree = "����";
            //try
            //{
            //    //���ʿ���ʱ������һ����Σ��¼
            //    string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
            //                            " values('" + inPatient.PId + "','����',sysdate," + inPatient.Id + ")";
            //    App.ExecuteSQL(InsertJob_Temp);
            //}
            //catch (Exception)
            //{
            //}
        }

        private void btnStopIn_Danger_Click(object sender, EventArgs e)
        {
            //this.btnAddIn_Danger.Enabled = true;
            //this.btnAddIll.Enabled = true;
            //this.btnStopIn_Danger.Enabled = false;
            //this.btnStopIll.Enabled = false;
            //inPatient.Sick_Degree = "һ��";
        }

        private void btnStopIll_Click(object sender, EventArgs e)
        {
            //this.btnAddIn_Danger.Enabled = true;
            //this.btnAddIll.Enabled = true;
            //this.btnStopIn_Danger.Enabled = false;
            //this.btnStopIll.Enabled = false;
            //inPatient.Sick_Degree = "һ��";
        }

        //=========================================================================================================
        //=========================================================================================================

        #region ���캯��

        /// <summary>
        /// Ĭ�Ϲ���
        /// </summary>
        public UcPatientInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����Ĳ�����Ϣ���ϲ�������
        /// ��д���췽������������������д����ʵ��
        /// </summary>
        /// <param name="inPatientInfo"></param>
        public UcPatientInfo(InPatientInfo inPatientInfo)
        {
            InitializeComponent();
            App.UsControlStyle(this);
            this.inPatient = GetInPatientById(inPatientInfo.Id.ToString()); // �ع�����ʵ��
            if (isHaveMoreOlderInfos(this.inPatient.PId, this.inPatient.Card_Id))
            {
                btnOldInfoUser.Enabled = true;
            }
            else
            {
                btnOldInfoUser.Enabled = false;
            }

        }

        #endregion

        /// <summary>
        /// ���ز���ʵ��
        /// </summary>
        /// <param name="id">���˱����� ID</param>
        /// <returns></returns>
        private InPatientInfo GetInPatientById(string id)
        {
            InPatientInfo inPatientInfo = new InPatientInfo();
            if (string.IsNullOrEmpty(id))
            {
                return inPatientInfo;
            }

            #region ����������Ϣʵ��

            string sql = string.Format("select * from t_in_patient where id = '{0}'", id);
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt != null && dt.Rows.Count == 1)
            {
                inPatientInfo.Id = Convert.ToInt32(id);
                //������
                inPatientInfo.Sick_doc_no = dt.Rows[0]["Sick_doc_no"] is DBNull ? "" : dt.Rows[0]["Sick_doc_no"].ToString();
                //ҽ�Ƹ��ʽ
                inPatientInfo.Pay_Manager = dt.Rows[0]["PAY_MANNER"] is DBNull ? "" : dt.Rows[0]["PAY_MANNER"].ToString();

                //סԺ����
                inPatientInfo.InHospital_count = dt.Rows[0]["INHOSPITAL_COUNT"] is DBNull ? 1 : Convert.ToInt32(dt.Rows[0]["INHOSPITAL_COUNT"]);

                //����
                inPatientInfo.Patient_Name = dt.Rows[0]["PATIENT_NAME"] is DBNull ? "" : dt.Rows[0]["PATIENT_NAME"].ToString();

                //�Ա�
                inPatientInfo.Gender_Code = dt.Rows[0]["GENDER_CODE"] is DBNull ? "" : dt.Rows[0]["GENDER_CODE"].ToString();

                //����
                inPatientInfo.Marrige_State = dt.Rows[0]["MARRIAGE_STATE"] is DBNull ? "" : dt.Rows[0]["MARRIAGE_STATE"].ToString();

                //���֤
                inPatientInfo.Card_Id = dt.Rows[0]["card_id"] is DBNull ? "" : dt.Rows[0]["card_id"].ToString();

                //��������
                inPatientInfo.Birthday = dt.Rows[0]["BIRTHDAY"] is DBNull ? "" : dt.Rows[0]["BIRTHDAY"].ToString();

                //����
                inPatientInfo.Folk_code = dt.Rows[0]["FOLK_CODE"] is DBNull ? "" : dt.Rows[0]["FOLK_CODE"].ToString();

                //����
                inPatientInfo.Country = dt.Rows[0]["COUNTRY"] is DBNull ? "" : dt.Rows[0]["COUNTRY"].ToString();

                //������
                inPatientInfo.Birth_place = dt.Rows[0]["BIRTH_PLACE"] is DBNull ? "" : dt.Rows[0]["BIRTH_PLACE"].ToString();

                //������λ����ַ
                inPatientInfo.Office_address = dt.Rows[0]["OFFICE_ADDRESS"] is DBNull ? "" : dt.Rows[0]["OFFICE_ADDRESS"].ToString();

                //ְҵ
                inPatientInfo.Career = dt.Rows[0]["CAREER"] is DBNull ? "" : dt.Rows[0]["CAREER"].ToString();
                inPatientInfo.Career_other = dt.Rows[0]["career_other"] is DBNull ? "" : dt.Rows[0]["career_other"].ToString();
                //��λ�绰
                inPatientInfo.Office_phone = dt.Rows[0]["OFFICE_PHONE"] is DBNull ? "" : dt.Rows[0]["OFFICE_PHONE"].ToString();

                //��λ��������
                inPatientInfo.OfficePos_code = dt.Rows[0]["OFFICEPOS_CODE"] is DBNull ? "" : dt.Rows[0]["OFFICEPOS_CODE"].ToString();

                //���ڵ�ַ��
                inPatientInfo.Home_address = dt.Rows[0]["HOME_ADDRESS"] is DBNull ? "" : dt.Rows[0]["HOME_ADDRESS"].ToString();

                //��������
                inPatientInfo.HomePostal_code = dt.Rows[0]["HOMEPOSTAL_CODE"] is DBNull ? "" : dt.Rows[0]["HOMEPOSTAL_CODE"].ToString();

                //��ϵ�˵�ַ
                inPatientInfo.Relation_address = dt.Rows[0]["RELATION_ADDRESS"] is DBNull ? "" : dt.Rows[0]["RELATION_ADDRESS"].ToString();

                //��ϵ
                inPatientInfo.Relation = dt.Rows[0]["RELATION"] is DBNull ? "" : dt.Rows[0]["RELATION"].ToString();

                //��ϵ������
                inPatientInfo.Relation_name = dt.Rows[0]["RELATION_NAME"] is DBNull ? "" : dt.Rows[0]["RELATION_NAME"].ToString();

                //��ϵ�˵绰
                inPatientInfo.Relation_phone = dt.Rows[0]["RELATION_PHONE"] is DBNull ? "" : dt.Rows[0]["RELATION_PHONE"].ToString();

                //��Ժ����
                inPatientInfo.In_Time = dt.Rows[0]["IN_TIME"] is DBNull ? Convert.ToDateTime("3000-1-1") : Convert.ToDateTime(dt.Rows[0]["IN_TIME"]);

                //����ȼ�
                inPatientInfo.Nurse_Level = dt.Rows[0]["NURSE_LEVEL"] is DBNull ? "" : dt.Rows[0]["NURSE_LEVEL"].ToString();

                //��Ժʱ���
                inPatientInfo.In_Circs = dt.Rows[0]["IN_CIRCS"] is DBNull ? "" : dt.Rows[0]["IN_CIRCS"].ToString();

                //״̬
                inPatientInfo.State = dt.Rows[0]["State"] is DBNull ? "" : dt.Rows[0]["State"].ToString();


                //��Ժ����
                inPatientInfo.Insection_Name = dt.Rows[0]["insection_name"].ToString();
                //��Ժ����
                inPatientInfo.In_Area_Name = dt.Rows[0]["In_Area_Name"].ToString();
                //��Ժ����
                inPatientInfo.Die_time = dt.Rows[0]["Die_time"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["Die_time"]);
                //��Ժ����
                inPatientInfo.Section_Name = dt.Rows[0]["Section_Name"].ToString();
                //��Ժ����
                inPatientInfo.Sick_Area_Name = dt.Rows[0]["Sick_Area_Name"].ToString();

                //���˺�
                inPatientInfo.PId = dt.Rows[0]["PID"].ToString();

                //�ǼǺ�
                inPatientInfo.Medicare_no = dt.Rows[0]["medicare_no"] is DBNull ? "" : dt.Rows[0]["medicare_no"].ToString();

                //������
                inPatientInfo.His_id = dt.Rows[0]["his_id"].ToString();
                //��ס��ַ
                inPatientInfo.Now_address = dt.Rows[0]["Now_address"] is DBNull ? "" : dt.Rows[0]["Now_address"].ToString();
                //��ס��ַ�ʱ�
                inPatientInfo.Now_addres_postno = dt.Rows[0]["Now_addres_PostNo"] is DBNull ? "" : dt.Rows[0]["Now_addres_PostNo"].ToString();
                //��ס��ַ�绰 
                inPatientInfo.Now_addres_phone = dt.Rows[0]["home_phone"] is DBNull ? "" : dt.Rows[0]["home_phone"].ToString();
                // ��������
                inPatientInfo.Health_card_no = dt.Rows[0]["Health_card_no"] is DBNull ? "" : dt.Rows[0]["Health_card_no"].ToString();
                //��������������
                inPatientInfo.Bornweight = dt.Rows[0]["BornWeight"].ToString();
                //��������Ժ����
                inPatientInfo.Inweight = dt.Rows[0]["INWEIGHT"].ToString();// == "" ? 0 : float.Parse(dt.Rows[0]["Weight"].ToString());
                //����
                inPatientInfo.Natiye_place = dt.Rows[0]["NATIVE_PLACE"] is DBNull ? "" : dt.Rows[0]["NATIVE_PLACE"].ToString();
                //��Ժ;��
                inPatientInfo.In_Approach = dt.Rows[0]["In_Approach"] is DBNull ? "" : dt.Rows[0]["In_Approach"].ToString();
                //����
                inPatientInfo.Age = dt.Rows[0]["age"] is DBNull ? "0" : dt.Rows[0]["age"].ToString();
                //���䵥λ
                inPatientInfo.Age_unit = dt.Rows[0]["AGE_UNIT"] is DBNull ? "" : dt.Rows[0]["AGE_UNIT"].ToString();
                //��ͯ���䣨����һ����ģ�
                inPatientInfo.Child_age = dt.Rows[0]["CHILD_AGE"] is DBNull ? "" : dt.Rows[0]["CHILD_AGE"].ToString();
            }
            #endregion

            return inPatientInfo;
        }



        /// <summary>
        /// ��ʼ����Ϣ���ѡ�������
        /// ȡֵ���� this.inPatient
        /// </summary>
        private void InitForm()
        {
            //if (inPatient.Age != "0")
            //{
            txtAge1.Text = inPatient.Age;
            //}

            //if (inPatient.Child_age != "0" || inPatient.Child_age != "")
            //{
            txtAge2.Text = inPatient.Child_age;
            //}  

            // �������ı���ֵ�����϶��£��������
            txtIn_Count.Text = this.inPatient.InHospital_count.ToString();
            // �����������޸�
            txtPName.Text = this.inPatient.Patient_Name;
            //txtPName.Enabled = false;

            //Card_Id ���֤���� medicare_no�ǼǺ�
            txtId_Number.Text = this.inPatient.Card_Id;

            txtWorkAddress.Text = this.inPatient.Office_address;
            txtOffice_Phone.Text = this.inPatient.Office_phone;
            txtOffice_Post.Text = this.inPatient.OfficePos_code;
            txtAccountAddress.Text = this.inPatient.Home_address;
            txtHome_Post.Text = this.inPatient.HomePostal_code;
            txtContactAddress.Text = this.inPatient.Relation_address;
            txtRelationName.Text = this.inPatient.Relation_name;
            txtRelation_Phone.Text = this.inPatient.Relation_phone;
            //txtIn_Hospital_Time.Text = string.Format("{0:g}", this.inPatient.In_Time.ToString());
            //lblAge.Text = App.GetAge(Convert.ToDateTime(this.inPatient.Birthday), this.inPatient);

            // ��Ժʱ�䲻�����޸�
            dtpInTime.Value = this.inPatient.In_Time;
            dtpInTime.Enabled = false;

            txtInSection.Text = this.inPatient.Insection_Name;
            txtInSickArea.Text = this.inPatient.In_Area_Name;

            // ���û��Ժ,���س�Ժ�����Ϣ
            if (this.inPatient.Die_time.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss"))
            {
                dtpOutTime.Visible = false;
                txtOutSection.Visible = false;
                txtOutSickArea.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
            }
            else
            {
                dtpOutTime.Value = this.inPatient.Die_time;
                txtOutSection.Text = this.inPatient.Section_Name;
                txtOutSickArea.Text = this.inPatient.Sick_Area_Name;
            }
            //��������ȡ�ֶβ���ȷ��ӦΪzy+סԺ����+סԺ�ŵ�14λ���룬����ȡסԺ�š�
            //this.inPatient.InHospital_count.ToString()
            txtPID.Text = inPatient.PId;//this.inPatient.His_id;
            //��������
            txtCardNo.Text = this.inPatient.Health_card_no;
            ////��������
            txtBornWeight.Text = this.inPatient.Bornweight;
            //��Ժ����
            txtBornInWeight.Text = this.inPatient.Inweight; //== 0 ? "" : this.inPatient.Weight.ToString();
            //��ס��ַ�绰
            txtNowHomePhone.Text = this.inPatient.Now_addres_phone;
            //��ס��ַ�ʱ�
            txtNowPostNo.Text = this.inPatient.Now_addres_postno;
            //��סַ
            //txtNowAddress.Text = this.inPatient.Now_address.Replace("|","");
            // סԺ����

            //if (this.inPatient.Die_time == DateTime.MinValue) //δ��Ժ
            //{
            //    ts = (Convert.ToDateTime(App.GetSystemTime()) - Convert.ToDateTime(this.inPatient.In_Time));
            //    //txtIn_Hospital_Time.Text = ((TimeSpan)(Convert.ToDateTime(App.GetSystemTime().ToShortDateString()) - Convert.ToDateTime(this.inPatient.In_Time.ToShortDateString()))).Days.ToString() + "��";
            //}
            //else
            //{
            //    ts = (Convert.ToDateTime(this.inPatient.Die_time) - Convert.ToDateTime(this.inPatient.In_Time));
            //}

            DateTime dtime = App.GetSystemTime();
            if (this.inPatient.Die_time != DateTime.MinValue) //�ѳ�Ժ
            {
                dtime = this.inPatient.Die_time;
            }
            TimeSpan ts = (Convert.ToDateTime(dtime) - Convert.ToDateTime(this.inPatient.In_Time));
            if (ts.Days == 0)
            {
                int h = 0;
                if (ts.Minutes > 0)//����0����ʱ,Сʱ��1
                    h = ts.Hours + 1;
                else
                    h = ts.Hours;
                txtIn_Hospital_Time.Text = h.ToString() == "0" ? "1Сʱ" : h.ToString() + "Сʱ";
                if (h == 24)
                    txtIn_Hospital_Time.Text = "1��";
            }
            else
            {//����һ��İ������ڼ�
                txtIn_Hospital_Time.Text = ((TimeSpan)(Convert.ToDateTime(dtime.ToShortDateString()) - Convert.ToDateTime(this.inPatient.In_Time.ToShortDateString()))).Days.ToString() + "��";
            }


            // ��Ժ;��
            //string sT1 = "����,����,����ҽ�ƻ���ת��,����";
            //if (this.inPatient.In_Approach != "" && sT1.Contains(this.inPatient.In_Approach))
            //{
            //    cboInKind.Text = this.inPatient.In_Approach;
            //}
            //else
            //{
            //    cboInKind.SelectedIndex = 0; 
            //}
            try
            {
                cboInKind.SelectedValue = this.inPatient.In_Approach.Length == 0 ? "0" : this.inPatient.In_Approach;
            }
            catch
            {
                cboInKind.SelectedIndex = 0;
            }

            //ҽ�Ƹ��ʽ
            //cbxPay.SelectedValue = this.inPatient.Pay_Manager.Length == 0 ? 0 : int.Parse(this.inPatient.Pay_Manager.ToString());

            //SelectedValue
            //cbxPay.Text = this.inPatient.Pay_Manager.Length == 0 ? "0" : this.inPatient.Pay_Manager;//this.inPatient.Pay_Manager;
            cbxPay.Text = App.ReadSqlVal("select name from t_data_code where type=70 and code='" + this.inPatient.Pay_Manager + "'", 0, "name");


            string selTurnWithAction = "select distinct ti.sid,ts.section_name,ti.happen_time,ti.action_type from t_inhospital_action ti"
                    + " inner join t_sectioninfo ts on ti.sid=ts.sid where ti.patient_id='" + inPatient.Id + "' and ti.action_type in ('ת��','����')"
                    + " order by ti.happen_time asc";

            DataSet dsTuen = App.GetDataSet(selTurnWithAction);
            int length = dsTuen.Tables[0].Rows.Count;
            string sectionTemp = "";
            for (int i = 0; i < length; i++)
            {
                string sectionName = dsTuen.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                if (length > 1)
                {
                    sectionTemp += sectionName + "��";
                }
            }

            txtTurnSection.Text = sectionTemp.Substring(0, sectionTemp.Length > 1 ? sectionTemp.Length - 1 : 0);
            int temp = 0;
            if (int.TryParse(inPatient.Gender_Code, out temp))
            {
                temp++;
            }
            cbxSex.SelectedIndex = temp;

            // ����
            try
            {
                //cbxMarred.SelectedValue = this.inPatient.Marrige_State.Length == 0 ? "0" : this.inPatient.Marrige_State;
                cbxMarred.Text = this.inPatient.Marrige_State;
            }
            catch
            {
                cbxMarred.SelectedIndex = 0;
            }

            dtpBirth_Date.Value = Convert.ToDateTime(this.inPatient.Birthday);

            try
            {
                // ����
                //cbxNational.SelectedValue = this.inPatient.Folk_code.Length == 0 ? "1" : this.inPatient.Folk_code;
                cbxNational.Text = this.inPatient.Folk_code;

            }
            catch
            {
                cbxNational.SelectedIndex = 0;
            }

            try
            {
                if (this.inPatient.Country == "CN")
                {
                    cbxNationality.Text = "�й�";
                }
                else
                {
                    cbxNationality.Text = this.inPatient.Country.Length == 0 ? "CN" : this.inPatient.Country; ; // ���� CN
                }
            }
            catch
            {
                cbxNationality.Text = "�й�";
            }

            //������
            try
            {
                if (this.inPatient.Birth_place.Length != 0)
                {
                    txtXian.Text = inPatient.Birth_place;
                    //                    if (inPatient.Birth_place.ToString().Contains("|"))
                    //                    {
                    //                        string[] birthPlace = this.inPatient.Birth_place.Split('|');
                    //                        for (int i = 0; i < birthPlace.Length; i++)
                    //                        {
                    //                            if (i == 0)
                    //                            {
                    //                                cbxProvince.Text = birthPlace[0];
                    //                            }
                    //                            else if (i == 1)
                    //                            {
                    //                                cbxShi.Text = birthPlace[1];
                    //                            }
                    //                            else if (i == 2)
                    //                            {
                    //                                txtXian.Text = birthPlace[2];
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Birth_place.ToString() == "����ʡ������" || inPatient.Birth_place.ToString() == "����������" || inPatient.Birth_place.ToString() == "��������")
                    //                    {
                    //                        cbxProvince.Text = "����ʡ";
                    //                        cbxShi.Text = "������";
                    //                    }
                    //                    else if (inPatient.Birth_place.ToString().Contains("ʡ"))
                    //                    {
                    //                        string[] birthPlace = this.inPatient.Birth_place.Split('ʡ');
                    //                        if (birthPlace.Length == 2)
                    //                        {
                    //                            cbxProvince.Text = birthPlace[0] + "ʡ";
                    //                            if (birthPlace[1].ToString().Contains("��"))
                    //                            {
                    //                                string[] birthPlaces = birthPlace[1].ToString().Split('��');
                    //                                cbxShi.Text = birthPlaces[0] + "��";
                    //                                txtXian.Text = birthPlaces[1];
                    //                            }
                    //                            else
                    //                            {
                    //                                txtXian.Text = birthPlace[1];
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Birth_place.ToString().Contains("��"))
                    //                    {
                    //                        string[] birthPlace = this.inPatient.Birth_place.Split('��');
                    //                        if (birthPlace.Length == 2)
                    //                        {
                    //                            //cbxProvince.Text = birthPlace[0];
                    //                            string shi = birthPlace[0] + "��";
                    //                            string sql = @"select name from t_data_code 
                    //                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                    //                                        from t_data_code where name='" + shi + "')";
                    //                            DataTable dts = App.GetDataSet(sql).Tables[0];
                    //                            if (dts.Rows.Count > 0)
                    //                            {
                    //                                cbxProvince.Text = dts.Rows[0]["name"].ToString();
                    //                            }
                    //                            cbxShi.Text = shi;
                    //                            txtXian.Text = birthPlace[1];

                    //                        }
                    //                    }
                }

                //����
                if (this.inPatient.Natiye_place.Length != 0)
                {
                    txtJGXian.Text = inPatient.Natiye_place;
                    //                    if (inPatient.Natiye_place.ToString().Contains("|"))
                    //                    {
                    //                        string[] Natiye_place = this.inPatient.Natiye_place.Split('|');
                    //                        for (int i = 0; i < Natiye_place.Length; i++)
                    //                        {
                    //                            if (i == 0)
                    //                            {
                    //                                cboNativePlaceS.Text = Natiye_place[0];
                    //                            }
                    //                            else if (i == 1)
                    //                            {
                    //                                cboNativePlaceSh.Text = Natiye_place[1];
                    //                            }
                    //                            else if (i == 2)
                    //                            {
                    //                                txtJGXian.Text = Natiye_place[2];
                    //                                //txtJGXian.Text = "";
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Natiye_place.ToString().Contains("ʡ"))
                    //                    {
                    //                        string[] natiye_place = this.inPatient.Natiye_place.Split('ʡ');
                    //                        if (natiye_place.Length == 2)
                    //                        {
                    //                            cboNativePlaceS.Text = natiye_place[0] + "ʡ";
                    //                            if (natiye_place[1].ToString().Contains("��"))
                    //                            {
                    //                                string[] natiye_placeS = natiye_place[1].ToString().Split('��');
                    //                                cboNativePlaceSh.Text = natiye_placeS[0] + "��";
                    //                                txtJGXian.Text = natiye_placeS[1];
                    //                            }
                    //                            else
                    //                            {
                    //                                txtJGXian.Text = natiye_place[1];
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Natiye_place.ToString().Contains("��"))
                    //                    {
                    //                        string[] natiye_place = this.inPatient.Natiye_place.Split('��');
                    //                        if (natiye_place.Length == 2)
                    //                        {
                    //                            //cbxProvince.Text = birthPlace[0];
                    //                            string shi = natiye_place[0] + "��";
                    //                            string sql = @"select name from t_data_code 
                    //                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                    //                                        from t_data_code where name='" + shi + "')";
                    //                            DataTable dts = App.GetDataSet(sql).Tables[0];
                    //                            if (dts.Rows.Count > 0)
                    //                            {
                    //                                cboNativePlaceS.Text = dts.Rows[0]["name"].ToString();
                    //                            }
                    //                            cboNativePlaceSh.Text = shi;
                    //                            txtJGXian.Text = natiye_place[1];
                    //                        }
                    //                    }
                }
                //��ס��ַ
                if (this.inPatient.Now_address.Length != 0)
                {
                    txtNowXian.Text = inPatient.Now_address;
                    //                    if (inPatient.Now_address.ToString().Contains("|"))
                    //                    {
                    //                        string[] Now_address = this.inPatient.Now_address.Split('|');
                    //                        for (int i = 0; i < Now_address.Length; i++)
                    //                        {
                    //                            if (i == 0)
                    //                            {
                    //                                cboNowAddressS.Text = Now_address[0];
                    //                            }
                    //                            else if (i == 1)
                    //                            {
                    //                                cboNowAddressSh.Text = Now_address[1];
                    //                            }
                    //                            else if (i == 2)
                    //                            {
                    //                                txtNowXian.Text = Now_address[2];
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Now_address.ToString().Contains("ʡ"))
                    //                    {
                    //                        string[] now_address = this.inPatient.Now_address.Split('ʡ');
                    //                        if (now_address.Length == 2)
                    //                        {
                    //                            cboNowAddressS.Text = now_address[0] + "ʡ";
                    //                            if (now_address[1].ToString().Contains("��"))
                    //                            {
                    //                                string[] now_addressS = now_address[1].ToString().Split('��');
                    //                                cboNowAddressSh.Text = now_addressS[0] + "��";
                    //                                txtNowXian.Text = now_addressS[1];
                    //                            }
                    //                            else
                    //                            {
                    //                                txtNowXian.Text = now_address[1];
                    //                            }
                    //                        }
                    //                    }
                    //                    else if (inPatient.Now_address.ToString().Contains("��"))
                    //                    {
                    //                        string[] now_address = this.inPatient.Now_address.Split('��');
                    //                        if (now_address.Length == 2)
                    //                        {
                    //                            //cbxProvince.Text = birthPlace[0];
                    //                            string shi = now_address[0] + "��";
                    //                            string sql = @"select name from t_data_code 
                    //                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                    //                                        from t_data_code where name='" + shi + "')";
                    //                            DataTable dts = App.GetDataSet(sql).Tables[0];
                    //                            if (dts.Rows.Count > 0)
                    //                            {
                    //                                cboNowAddressS.Text = dts.Rows[0][0].ToString();
                    //                            }
                    //                            cboNowAddressSh.Text = shi;
                    //                            txtNowXian.Text = now_address[1];
                    //                        }
                    //                    }
                }
            }
            catch
            {
            }
            cboCreer.Text = this.inPatient.Career.Length == 0 ? "-��ѡ��-" : this.inPatient.Career;

            // ��ϵ
            //cbxRelationship.Text = GetRelation(this.inPatient.Relation);
            try
            {
                cbxRelationship.SelectedValue = this.inPatient.Relation;
            }
            catch
            {
                cbxRelationship.SelectedValue = 0;
            }
            // ְҵ
            if (this.inPatient.Career.Length != 0)
            {
                cboCreer.SelectedValue = this.inPatient.Career;
                //txtCreer.Text = this.inPatient.Career;
            }
            else
            {
                cboCreer.SelectedIndex = 0;
            }

            // ����
            //DateTime dt1 = this.inPatient.In_Time;
            //DateTime dt2 = Convert.ToDateTime(this.inPatient.Birthday);
            //TimeSpan ts1 = dt1.Date - dt2.Date;
            //int year = ts1.Days / 365;
            //int month = ts1.Days % 365 / 30;
            //int day = ts1.Days % 365 % 30;
            //int hour = ts1.Hours;
            //txtAge1.Text = year == 0 ? "" : year.ToString();
            //txtAge2.Text = month == 0 ? "" : month.ToString();
            //txtAge3.Text = day == 0 ? "" : day.ToString();
            //txtAge4.Text = hour == 0 ? "" : hour.ToString();

        }

        /// <summary>
        /// �������պ���Ժʱ������ȡ������������ʾ
        /// </summary>
        /// <param name="birthday">����</param>
        /// <param name="inTime">��Ժʱ��</param>
        /// <returns>����������ʱ��','���</returns>
        //private string GetYearMonthDayHour(DateTime birthday, DateTime inTime)
        //{
        //    //if (inTime.CompareTo(birthday) < 0) // ��̭�Ƿ�����Ժ����
        //    //{
        //    //    return "";
        //    //}

        //    //int year = inTime.Year - birthday.Year;
        //    //int month = inTime.Month - birthday.Month;
        //    //int day = inTime.Day - birthday.Day; // ��,��Ҫ���ִ�С��,����
        //    //int hour = inTime.Hour - birthday.Hour;

        //    //if (hour <= 0) // ��������λ
        //    //{
        //    //    hour += 24;
        //    //    if (hour > 0)
        //    //    {
        //    //        hour -= 1;
        //    //    }
        //    //    else
        //    //    {

        //    //    }
        //    //}
        //    //00




        //}



        /// <summary>
        /// ��ȡ��Ӧ��ϵ
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetRelation(string p)
        {
            if (p.Length == 0)
            {
                return "-��ѡ��-";
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("1", "����");
            dict.Add("2", "��Ů");
            dict.Add("3", "ĸ��");
            dict.Add("4", "ĸŮ");
            dict.Add("5", "����");
            dict.Add("6", "����");
            dict.Add("7", "����");
            dict.Add("8", "�ֵ�");
            dict.Add("9", "�����໤��");

            try
            {
                return dict[p];
            }
            catch (Exception ex)
            {
                return p;
            }




        }

        /// <summary>
        /// Load �¼����� InitForm() ��ʼ�� Form ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcPatientInfo_Load(object sender, EventArgs e)
        {
            dataBindNational();
            dataBindMarred();
            dataBindRelation();
            dataBindboInKind();
            dataBindCareer();
            dataBingProvince();
            dataBingProvinceNP();
            dataBingProvinceNS();
            //InitCbxPay();
            InitCbxNationality();
            InitForm();
        }

        #region �����塢ʡ�ݡ����С�����ȼ���ҽ�Ƹ��ʽ����������Ժ;������ϵ

        /// <summary>
        /// �󶨹�ϵ
        /// </summary>
        private void dataBindRelation()
        {
            string sql = "select id,name,code from t_data_code t where type='131' and enable='Y' order by length(code),code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["code"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxRelationship.DisplayMember = "name";
            cbxRelationship.ValueMember = "code";
            cbxRelationship.DataSource = dt;
        }
        /// <summary>
        /// ����Ժ��ʽ
        /// </summary>
        private void dataBindboInKind()
        {
            string sql = "select id,name,code from t_data_code where type='110' and enable='Y'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboInKind.DisplayMember = "name";
            cboInKind.ValueMember = "code";
            cboInKind.DataSource = dt;
        }

        /// <summary>
        /// �󶨻���
        /// </summary>
        private void dataBindMarred()
        {
            string sql = "select id,name,code from t_data_code where type='132' and enable='Y'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxMarred.DisplayMember = "name";
            cbxMarred.ValueMember = "code";
            cbxMarred.DataSource = dt;
        }

        ///// <summary>
        ///// ��ҽ�Ƹ��ʽ
        ///// </summary>
        //private void dataBindPayKind()
        //{
        //    string sql = "select id,name,code from t_data_code where type='70' and enable='Y'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-��ѡ��-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cbxPay.DisplayMember = "name";
        //    cbxPay.ValueMember = "id";
        //    cbxPay.DataSource = dt;
        //}
        /// <summary>
        /// ְҵ
        /// </summary>
        private void dataBindCareer()
        {
            string sql = "select id,code,name from t_data_code where type='134' and enable='Y'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboCreer.DisplayMember = "name";
            cboCreer.ValueMember = "code";
            cboCreer.DataSource = dt;
        }
        /// <summary>
        /// ��56�����������б�
        /// </summary>
        private void dataBindNational()
        {
            string sql = "select code,name from t_data_code where type='71' and enable='Y' order by case  when name='����' then 0 else 1 end,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["code"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxNational.DisplayMember = "name";
            cbxNational.ValueMember = "code";
            cbxNational.DataSource = dt;
        }


        /// <summary>
        /// �󶨻���ȼ�
        /// </summary>
        private void dataBindNurseLevel()
        {
            //            string sql = @"select a.id,a.name from t_data_code a inner join t_data_code_type b 
            //                            on a.type = b.id where b.name = '����ȼ�'";
            //            DataTable dt = App.GetDataSet(sql).Tables[0];
            //            DataRow row = dt.NewRow();
            //            row["name"] = "-��ѡ��-";
            //            row["id"] = "-1";
            //            dt.Rows.InsertAt(row, 0);
            //            cbxNurse_Leavel.DataSource = dt;
            //            cbxNurse_Leavel.DisplayMember = "NAME";
            //            cbxNurse_Leavel.ValueMember = "ID";
        }

        #endregion


        /// <summary>
        /// Update ������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ȷ��Ҫ�޸Ĳ�����Ϣ��", "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            #region ��̬ƴ�� SQL��ִ�и���
            string strTemp = string.Empty;
            StringBuilder sb = new StringBuilder(@"update t_in_patient set ");
            //������birth_place
            if (cbxProvince.SelectedIndex != 0)
            {
                strTemp = cbxProvince.Text + "|";
                if (cbxShi.SelectedIndex != 0)
                {
                    strTemp += cbxShi.Text + "|" + txtXian.Text;
                }

            }
            sb.Append(string.Format(@" birth_place='{0}',", App.ReplaceSQLCharEN(strTemp)));

            strTemp = string.Empty;
            //����
            if (cboNativePlaceS.SelectedIndex != 0)
            {
                strTemp = cboNativePlaceS.Text + "|";
                if (cboNativePlaceSh.SelectedIndex != 0)
                {
                    strTemp += cboNativePlaceSh.Text + "|" + txtJGXian.Text;
                }
            }
            sb.Append(string.Format(@" native_place='{0}',", App.ReplaceSQLCharEN(strTemp)));

            strTemp = string.Empty;
            //��סַnow_address
            if (cboNowAddressS.SelectedIndex != 0)
            {
                strTemp = cboNowAddressS.Text + "|";
                if (cboNowAddressSh.SelectedIndex != 0)
                {
                    strTemp += cboNowAddressSh.Text + "|" + txtNowXian.Text;
                }
            }
            sb.Append(string.Format(@" now_address='{0}',", App.ReplaceSQLCharEN(strTemp)));

            //��ס��ַ�绰          
            sb.Append(string.Format(@" Now_addres_phone='{0}',", txtNowHomePhone.Text));
            //��ס��ַ�ʱ�            
            sb.Append(string.Format(@" Now_addres_PostNo='{0}',", txtNowPostNo.Text));


            //������Sick_Doc_No
            //sb.Append(string.Format(@" Sick_Doc_No='{0}',", txtPID.Text.Trim()));

            //��������Ժ����
            sb.Append(string.Format(@" INWEIGHT='{0}',", txtBornInWeight.Text));

            ////��������������          
            sb.Append(string.Format(@" BORNWEIGHT='{0}',", txtBornWeight.Text));

            //��������           
            sb.Append(string.Format(@" health_card_no='{0}',", txtCardNo.Text));

            // סԺ����           
            sb.Append(string.Format(@" inhospital_count={0},", txtIn_Count.Text));

            // ����          
            sb.Append(string.Format(@" patient_name='{0}',", App.ReplaceSQLCharEN(txtPName.Text)));

            // ���֤           
            sb.Append(string.Format(@" card_id='{0}',", txtId_Number.Text));

            // ��λ��ַ            
            sb.Append(string.Format(@" office_address='{0}',", App.ReplaceSQLCharEN(txtWorkAddress.Text)));

            // ��λ�绰            
            sb.Append(string.Format(@" office_phone='{0}',", txtOffice_Phone.Text));

            // ��λ��������            
            sb.Append(string.Format(@" officepos_code='{0}',", txtOffice_Post.Text));

            // ���ڵ�ַ            
            sb.Append(string.Format(@" home_address='{0}',", App.ReplaceSQLCharEN(txtAccountAddress.Text)));

            // ������������           
            sb.Append(string.Format(@" homepostal_code='{0}',", txtHome_Post.Text));

            // ��ϵ�˵�ַ            
            sb.Append(string.Format(@" relation_address='{0}',", App.ReplaceSQLCharEN(txtContactAddress.Text)));

            // ��ϵ������           
            sb.Append(string.Format(@" relation_name='{0}',", App.ReplaceSQLCharEN(txtRelationName.Text)));

            // ��ϵ�˵绰            
            sb.Append(string.Format(@" relation_phone='{0}',", txtRelation_Phone.Text));

            //����            
            sb.Append(string.Format(@" AGE='{0}',", txtAge1.Text == "" ? "0" : txtAge1.Text));

            //���䵥λ 
            if (!txtAge1.Text.Contains("��"))
            {
                sb.Append(string.Format(@" AGE_UNIT='{0}',", "��"));
            }
            else
            {
                sb.Append(string.Format(@" AGE_UNIT='{0}',", ""));
            }


            //��ͯ����            
            sb.Append(string.Format(@" CHILD_AGE='{0}',", txtAge2.Text));

            //if (cbxPay1.SelectedValue != null && cbxPay1.SelectedValue.ToString() != "") // ҽ�Ƹ��ʽ
            //{
            //    sb.Append(string.Format(@" pay_manner='{0}',", cbxPay1.SelectedValue.ToString()));
            //}
            //else
            //{
            //    sb.Append(string.Format(@" pay_manner='{0}',", ""));
            //}
            if (cbxSex.SelectedIndex != 0) // �Ա�
            {
                sb.Append(string.Format(@" gender_code='{0}',", cbxSex.SelectedIndex - 1));
            }
            else
            {
                sb.Append(string.Format(@" gender_code='{0}',", " "));
            }
            if (cbxMarred.SelectedValue != null && cbxMarred.SelectedIndex != 0) // ����
            {
                sb.Append(string.Format(@" marriage_state='{0}',", cbxMarred.SelectedValue));
            }
            else
            {
                sb.Append(string.Format(@" marriage_state='{0}',", ""));
            }

            sb.Append(string.Format(@" birthday=to_Date('{0}','yyyy-mm-dd hh24:mi:ss'),", Convert.ToDateTime(dtpBirth_Date.Text).ToString("yyyy-MM-dd HH:mm:ss"))); // ����

            if (cbxNational.SelectedValue != null && cbxNational.SelectedIndex != 0) // ����
            {
                sb.Append(string.Format(@" folk_code='{0}',", cbxNational.SelectedValue));
            }
            else
            {
                sb.Append(string.Format(@" folk_code='{0}',", ""));
            }
            if (cbxNationality.SelectedValue != null && cbxNationality.SelectedIndex != 0) // ����
            {
                sb.Append(string.Format(@" Country='{0}',", cbxNationality.SelectedValue));
            }
            else
            {
                sb.Append(string.Format(@" Country='{0}',", ""));
            }
            if (cboInKind.SelectedValue != null && cboInKind.SelectedIndex != 0)//��Ժ;��
            {
                sb.Append(string.Format(@" IN_Approach='{0}',", cboInKind.SelectedValue));
            }
            else
            {
                sb.Append(string.Format(@" IN_Approach='{0}',", ""));
            }


            if (cboCreer.SelectedValue != null && cboCreer.SelectedIndex != 0) // ְҵ
            {
                //if (cboCreer.SelectedIndex == 3)
                //{
                //    if (txtCreer.Text.Trim() == "��ͯ")
                //    {
                //        sb.Append(string.Format(" career='{0}',", "13"));
                //    }
                //    else if (txtCreer.Text.Trim() == "ɢͯ")
                //    {
                //        sb.Append(string.Format(" career='{0}',", "14"));
                //    }
                //    else
                //    {
                //        sb.Append(string.Format(" career='{0}',", txtCreer.Text));
                //    }
                //}
                //else
                //{
                sb.Append(string.Format(@" career='{0}',", cboCreer.SelectedValue));
                sb.Append(string.Format(@" CAREER_OTHER='{0}',", txtCreer.Text));
                //}
            }
            else
            {
                sb.Append(string.Format(@" career='{0}',", ""));
                sb.Append(string.Format(@" CAREER_OTHER='{0}',", ""));
            }

            // ��ϵ
            if (cbxRelationship.SelectedValue != null && cbxRelationship.SelectedIndex != 0)
            {
                sb.Append(string.Format(@" relation='{0}',", cbxRelationship.SelectedValue));
            }
            else
            {
                sb.Append(string.Format(@" relation='{0}',", ""));
            }

            string sql = sb.ToString().Substring(0, sb.Length - 1);
            sql += string.Format(@" where id='{0}'", this.inPatient.Id);
            #endregion

            if (sql.Contains(@"where id="))
            {
                int count = 0;
                try
                {
                    count = App.ExecuteSQL(sql);
                }
                catch (Exception ex)
                {
                    App.Msg(ex.Message);
                }
                if (count == 1)
                {
                    DialogResult rs = MessageBox.Show("��ʾ: �޸ĳɹ���", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    try
                    {
                        //ucMain frmmain = (this.TopLevelControl as Patient_Action_Manager.frmPatientInfo).uc;
                        //ucMain frmmain = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                        //DataRow row = App.GetDataSet("select * from t_in_patient where id='" + this.inPatient.Id + "'").Tables[0].Rows[0];
                        //InPatientInfo tempInPatient = DataInit.InitPatient(row);
                        ////��ȡ��ӦС��
                        //UCPictureBox ucPicBox = null;
                        //Control control = ((ucHospitalIofn)frmmain.ta.Controls[2]).panel1;
                        //foreach (Control var in control.Controls)
                        //{
                        //    ucPicBox = var as UCPictureBox;
                        //    if (ucPicBox != null && ucPicBox.Inpat != null && ucPicBox.Inpat.Id == tempInPatient.Id)
                        //    {
                        //        frmmain.ucCurrentPictureBox = ucPicBox;
                        //        break;
                        //    }
                        //}
                        //frmmain.ucCurrentPictureBox.Inpat = tempInPatient;
                        //frmmain.ucCurrentPictureBox.Img(tempInPatient);
                        //GetNodeByPatientID(tempInPatient.Id, frmmain.trvInpatientManager.Nodes);
                        //this.tempNode.Tag = tempInPatient;
                        //this.tempNode.Text = tempInPatient.Sick_Bed_Name + " " + tempInPatient.Patient_Name;

                        //if (rs == DialogResult.OK)
                        //{
                        //    this.TopLevelControl.Dispose();
                        //}

                    }
                    catch { }
                }
                else
                {
                    App.Msg("���ź������쳣���ݣ��޸�ʧ�ܣ�");
                }
            }
        }

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.TopLevelControl.Dispose();
        }

        /// <summary>
        /// ���ز����ڲ������еĽڵ�
        /// </summary>
        /// <param name="id">��������id</param>
        /// <param name="nodes">���ڵ㼯��</param>
        private void GetNodeByPatientID(int id, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    GetNodeByPatientID(id, node.Nodes);
                }
                else
                {
                    InPatientInfo inPatient = node.Tag as InPatientInfo;
                    if (inPatient != null && inPatient.Id == id)
                    {
                        this.tempNode = node;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ְҵѡ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCreer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCreer.Text == "����" || cboCreer.Text == "�����Ͷ���")
            {
                txtCreer.Enabled = true;
            }
            else
            {
                txtCreer.Text = "";
                txtCreer.Enabled = false;
            }
        }

        private void cbxShi_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtOutSection_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ������Ϣ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOldInfoUser_Click(object sender, EventArgs e)
        {
            frmOldsPatientInfo fc = new frmOldsPatientInfo(inPatient.PId, inPatient.Card_Id);
            fc.ShowDialog();
            if (fc.Patientid != "")
            {
                //��ʱ��¼ԭ����PID �� ID
                string OlderId = inPatient.Id.ToString();
                string OlderPid = inPatient.PId;
                //��ȡѡ�еĲ��� ������Ϣ
                GetInPatientById(fc.Patientid);
                //��ԭԭ����PID �� ID
                inPatient.Id = Convert.ToInt32(OlderId);
                inPatient.PId = OlderPid;
                //��ʼ��������Ϣ
                InitForm();
            }
            fc.Close();
        }

        private void dtpBirth_Date_ValueChanged(object sender, EventArgs e)
        {
            getAge();
        }

        private void getAge()
        {
            try
            {
                if (inPatient.Child_age != "")
                {
                    txtAge1.Text = "";
                    txtAge2.Text = inPatient.Child_age;
                    return;
                }
                else if (inPatient.Age != "")
                {
                    txtAge1.Text = inPatient.Age;
                    txtAge2.Text = "";
                    return;
                }
                string AGE_UNIT = "";
                int year = 0;
                int mont = 0;
                int day = 0;
                int hour = 0;
                int minute = 0;
                DataInit.GetAgeByBirthday(dtpBirth_Date.Value, inPatient.In_Time, out year, out mont, out day, out hour, out minute);//App.GetSystemTime()
                //���ݳ������ڼ������䣺1�¡����䣾3�꣬��ȷ���㵽�£���3�¡�1��2�£���1�»��ߣ���ȷ���㵽�졣
                //��ԺΪ����ҽԺ����ͯ�����ʽ�Ѿ���ѯ�������κ�ҽ������Ρ�
                //�����ʽ��Ϊ��
                //��1��	����>=7��,��ʾX��
                //��2��	����>=1�꣬��ʾ��X��X�£�ǡ��һ��ֻ��ʾ1�ꡣ
                //��3��	��<����<1�꣬��ʾ��X��X�죻ǡ��һ������ʾ1�¡�
                //��4��	��<=����<1�£���ʾ��X��XСʱ��ǡ����һ�����ʾ1�졣
                //��5��	����<1�죬��ʾ��XСʱ��
                //��6�� Сʱ<1Сʱ,��ʾ: X���ӡ�
                if (year > 0)
                {
                    txtAge1.Text = year.ToString();
                    AGE_UNIT = "��";
                    if (year < 7)
                    {
                        if (mont > 0 && mont != 0)
                            txtAge1.Text += AGE_UNIT + mont + "��";
                    }
                }
                else if (mont > 0)
                {
                    txtAge1.Text = "-";
                    AGE_UNIT = "��";
                    txtAge2.Text = mont.ToString() + "��";
                    if (day > 0 && day != 0)
                        txtAge2.Text += day.ToString() + "��";
                }
                else if (day > 0)
                {
                    txtAge1.Text = "-";
                    AGE_UNIT = "��";
                    txtAge2.Text = day.ToString() + "��";
                    if (hour > 0)
                        txtAge2.Text += hour.ToString() + "Сʱ";
                }
                else if (hour > 0)
                {
                    txtAge1.Text = "-";
                    AGE_UNIT = "Сʱ";
                    txtAge2.Text = hour.ToString() + "Сʱ";
                }
                else
                {
                    txtAge1.Text = "-";
                    AGE_UNIT = "����";
                    txtAge2.Text = minute.ToString() + "����";
                }
            }
            catch
            { }
        }

        private void txtNowPostNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ֻ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAge1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtAge2_TextChanged(object sender, EventArgs e)
        {
            if (txtAge2.Text != "")
            {
                txtAge1.Text = "";
                //txtAge1.ReadOnly = true;
            }
            else
            {
                //txtAge1.ReadOnly = false;
            }

        }

        private void txtAge1_TextChanged(object sender, EventArgs e)
        {
            if (txtAge1.Text != "")
            {
                txtAge2.Text = "";
                //txtAge2.ReadOnly = true;
            }
            else
            {
                //txtAge2.ReadOnly = false;
            }
        }

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProvince.SelectedIndex != 0)
            {
                dataBindShi(cbxProvince.SelectedValue);
            }
            else
            {
                cbxShi.DataSource = null;
                cbxShi.Items.Add("-��ѡ��-");
                cbxShi.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ����ʡ������
        /// </summary>
        /// <param name="id"></param>
        private void dataBindShi(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by order_id,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//ֱϽ�г��� �������Ϻ� �����
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by order_id,bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxShi.DisplayMember = "name";
            cbxShi.ValueMember = "id";
            cbxShi.DataSource = dt;
        }

        private void cboNativePlaceS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNativePlaceS.SelectedIndex != 0)
            {
                dataBindNativePlaceSh(cboNativePlaceS.SelectedValue);
            }
            else
            {
                cboNativePlaceSh.DataSource = null;
                cboNativePlaceSh.Items.Add("-��ѡ��-");
                cboNativePlaceSh.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ����ʡ������1
        /// </summary>
        /// <param name="id"></param>
        private void dataBindNativePlaceSh(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by order_id,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//ֱϽ�г��� �������Ϻ� �����
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by order_id,bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboNativePlaceSh.DisplayMember = "name";
            cboNativePlaceSh.ValueMember = "id";
            cboNativePlaceSh.DataSource = dt;
        }

        private void cboNowAddressS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNowAddressS.SelectedIndex != 0)
            {
                dataBindNowAddressSh(cboNowAddressS.SelectedValue);
            }
            else
            {
                cboNowAddressSh.DataSource = null;
                cboNowAddressSh.Items.Add("-��ѡ��-");
                cboNowAddressSh.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ����ʡ������2
        /// </summary>
        /// <param name="id"></param>
        private void dataBindNowAddressSh(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by order_id,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//ֱϽ�г��� �������Ϻ� �����
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by order_id,bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboNowAddressSh.DisplayMember = "name";
            cboNowAddressSh.ValueMember = "id";
            cboNowAddressSh.DataSource = dt;
        }

        ///// <summary>
        ///// �󶨳�����ʡ��
        ///// </summary>
        private void dataBingProvince()
        {
            //ע��:��������Ĭ��ʡ���޸�order_id˳��;
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and bzdm is not null order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";

            dt.Rows.InsertAt(row, 0);
            cbxProvince.DisplayMember = "name";
            cbxProvince.ValueMember = "id";
            cbxProvince.DataSource = dt;
        }

        ///// <summary>
        ///// �󶨼���ʡ��
        ///// </summary>
        private void dataBingProvinceNP()
        {
            //string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 order by order_id,code";
            //ע��:��������Ĭ��ʡ���޸�order_id˳��;
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and bzdm is not null order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";

            dt.Rows.InsertAt(row, 0);
            cboNativePlaceS.DisplayMember = "name";
            cboNativePlaceS.ValueMember = "id";
            cboNativePlaceS.DataSource = dt;
        }

        ///// <summary>
        ///// ����סַʡ��
        ///// </summary>
        private void dataBingProvinceNS()
        {
            //string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 order by order_id,code";
            //ע��:��������Ĭ��ʡ���޸�order_id˳��;
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and bzdm is not null order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-��ѡ��-";
            row["id"] = "-1";

            dt.Rows.InsertAt(row, 0);
            cboNowAddressS.DisplayMember = "name";
            cboNowAddressS.ValueMember = "id";
            cboNowAddressS.DataSource = dt;
        }

        /// <summary>
        /// ���ݳ�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCS_Click(object sender, EventArgs e)
        {
            getAge();
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNL_Click(object sender, EventArgs e)
        {
            if (txtAge1.Text.Trim() != "" || txtAge2.Text.Trim() != "")
            {
                try
                {
                    string AgeCount = txtAge1.Text.Trim() == "" ? "0" : txtAge1.Text.Trim();
                    string AgeCount2 = txtAge2.Text.Trim() == "" ? "0" : txtAge2.Text.Trim();

                    //�����������������ڣ�
                    //����д��׼��n�ꡢn��n�£�ֻ���ڣ�3�껼�ߣ���n�¡�n�죬���Զ����㣬��3����㵽�꣬
                    //n��n�¡�n�£�1�¡����䣾3�꾫ȷ���£�
                    //n�죺��ȷ���㵽�ա���д���淶���ڼ��㷶Χ�ڡ�
                    dtpBirth_Date.Value = inPatient.In_Time;
                    if (!Regex.IsMatch(AgeCount, @"^[-]?\d+[.]?\d*$")) //�ı������ǲ�������)
                    {
                        if (AgeCount.Contains("��"))//|| AgeCount.Contains("��") || AgeCount.Contains("��"))
                        {
                            string[] age = AgeCount.Split("��".ToCharArray(), 2);
                            if (age[0] != "" && Regex.IsMatch(age[0], @"^[-]?\d+[.]?\d*$"))
                            {
                                dtpBirth_Date.Value = dtpBirth_Date.Value.AddYears(-Convert.ToInt32(age[0]));
                            }
                            string[] age1 = age[age.Length - 1].Split("��".ToCharArray(), 2);
                            if (age1[0] != "" && Regex.IsMatch(age1[0], @"^[-]?\d+[.]?\d*$"))
                            {
                                dtpBirth_Date.Value = dtpBirth_Date.Value.AddMonths(-Convert.ToInt32(age1[0]));
                            }
                            string[] age2 = age1[age1.Length - 1].Split("��".ToCharArray(), 2);
                            if (age2[0] != "" && Regex.IsMatch(age2[0], @"^[-]?\d+[.]?\d*$"))
                            {
                                dtpBirth_Date.Value = dtpBirth_Date.Value.AddDays(-Convert.ToInt32(age2[0]));
                            }
                        }
                    }
                    else
                    {//��һ�겻����λĬ��:��
                        dtpBirth_Date.Value = dtpBirth_Date.Value.AddYears(-Convert.ToInt32(AgeCount));
                    }
                    if (AgeCount2 != "" && !Regex.IsMatch(AgeCount2, @"^[-]?\d+[.]?\d*$")) //�ı������ǲ�������)
                    {
                        if (AgeCount2.Contains("��") || AgeCount2.Contains("��"))
                        {
                            string[] age = AgeCount2.Split("��".ToCharArray(), 2);
                            if (age[0] != "" && Regex.IsMatch(age[0], @"^[-]?\d+[.]?\d*$"))
                            {
                                dtpBirth_Date.Value = dtpBirth_Date.Value.AddMonths(-Convert.ToInt32(age[0]));
                            }
                            string[] age1 = age[age.Length - 1].Split("��".ToCharArray(), 2);
                            if (age1[0] != "" && Regex.IsMatch(age1[0], @"^[-]?\d+[.]?\d*$"))
                            {
                                dtpBirth_Date.Value = dtpBirth_Date.Value.AddDays(-Convert.ToInt32(age1[0]));
                            }
                        }
                    }
                    else
                    {//����һ�겻����λĬ��:��
                        dtpBirth_Date.Value = dtpBirth_Date.Value.AddMonths(-Convert.ToInt32(AgeCount));
                    }
                }
                catch
                {
                    App.Msg("�����������������ڣ�\r\n��һ�����������д��'��'�������\r\n��д��׼��ʽ:n�ꡢn��n�¡�n��n�졢n��n��n�죻\r\n ����һ�����������д��'����һ��'�������\r\n��д��׼��ʽ:n�¡�n�졢n��n�졣\r\n��д���淶���ڼ��㷶Χ�ڡ�");
                }
            }
        }

        private void txtTurnSection_TextChanged(object sender, EventArgs e)
        {

        }

        public void RefleshForm(string Id)
        {
            try
            {
                this.inPatient = GetInPatientById(Id.ToString()); // �ع�����ʵ��
                if (isHaveMoreOlderInfos(this.inPatient.PId, this.inPatient.Medicare_no))
                {
                    btnOldInfoUser.Enabled = true;
                }
                else
                {
                    btnOldInfoUser.Enabled = false;
                }

                InitForm();
            }
            catch
            { }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {

                //���˻���
                DataSet ds_Marriage = App.GetDataSet("select code,name from t_data_code where type='132'");

                //�������
                DataSet ds_Circs = App.GetDataSet("select code,name from t_data_code where type='133'");

                //����ȼ� 
                DataSet ds_Nures = App.GetDataSet("select name,id from t_data_code where type='53'");

                DataSet Ds_Patient = App.GetDataSet("select * from  patient_info_view@dbhislink where his_id='" + inPatient.His_id + "' and inhospital_count='" + inPatient.InHospital_count + "'");
                if (Ds_Patient != null)
                {
                    DataTable dt = Ds_Patient.Tables[0];
                    //�Ա�
                    string sex = "0";
                    if (dt.Rows[0]["gender_code"].ToString() == "��")
                    {
                        sex = "0";
                    }
                    else
                    {
                        sex = "1";
                    }

                    string CSD = "";
                    if (dt.Rows[0]["NATIVE_PLACE"].ToString() != "")
                    {
                        CSD = App.ReadSqlVal("select (case when area_name is null then '�⼮' else area_name end) as area_name from area_dict where area_code='" + dt.Rows[0]["NATIVE_PLACE"].ToString() + "'", 0, "area_name");
                    }

                    //���˻����¼
                    string brhljb = "";
                    string HLJB = "";
                    if (dt.Rows[0]["NURSE_LEVEL"].ToString().Trim() != "")
                    {
                        brhljb = ds_Nures.Tables[0].Select("name='" + dt.Rows[0]["NURSE_LEVEL"].ToString() + "'")[0]["id"].ToString();
                        HLJB = "='" + brhljb + "'";

                    }
                    else
                    {
                        HLJB = " is null";
                    }

                    //�������
                    string brqk_code = "";
                    string BRQK = "";
                    if (dt.Rows[0]["IN_CIRCS"].ToString().Trim() != "")
                    {
                        brqk_code = ds_Circs.Tables[0].Select("name='" + dt.Rows[0]["IN_CIRCS"].ToString() + "'")[0]["code"].ToString();
                        BRQK = "='" + brqk_code + "'";
                    }
                    else
                    {
                        BRQK = " is null";
                    }

                    //���˻���
                    string BRHY = "";
                    if (dt.Rows[0]["Marriage_State"].ToString().Trim() != "")
                    {
                        BRHY = "='" + ds_Marriage.Tables[0].Select("name='" + dt.Rows[0]["Marriage_State"].ToString() + "'")[0]["code"].ToString() + "'";
                    }
                    else
                    {
                        BRHY = " = null";
                    }


                    #region �������
                    string AGE = "";
                    string AGE_UNIT = "";
                    string CHILD_AGE = "";
                    try
                    {
                        //if (dt.Rows[0]["pid"].ToString().Contains("_"))
                        //{//������������������������������סԺ�Ŷ���XXXXXX_1����XXXXXXX_2��ʽ������סԺ�����»��ߵ�����ͳһΪ"������"��
                        //    CHILD_AGE = "������";
                        //}
                        //else
                        //{
                        int year = 0;
                        int mont = 0;
                        int day = 0;
                        int hour = 0;
                        int minute = 0;
                        DataInit.GetAgeByBirthday(Convert.ToDateTime(dt.Rows[0]["birthday"].ToString()), Convert.ToDateTime(dt.Rows[0]["in_time"].ToString()), out year, out mont, out day, out hour, out minute);//App.GetSystemTime()
                        //���ݳ������ڼ������䣺1�¡����䣾3�꣬��ȷ���㵽�£���3�¡�1��2�£���1�»��ߣ���ȷ���㵽�졣
                        //��ԺΪ����ҽԺ����ͯ�����ʽ�Ѿ���ѯ�������κ�ҽ������Ρ�
                        //��1��	����>=7��,��ʾX��
                        //��2��	����>=1�꣬��ʾ��X��X�¡�
                        //��3��	1��<=����<1�꣬��ʾ��X��X�죻ǡ��һ������ʾ1�¡�
                        //��4��	1��<=����<1�£���ʾ��X��XСʱ��ǡ����һ�����ʾ1�졣
                        //��5��	����<1�죬��ʾ��XСʱ��
                        //��6�� ����<1Сʱ,��ʾ: X���ӡ�
                        if (year > 0)
                        {
                            AGE = year.ToString();
                            AGE_UNIT = "��";
                            if (year < 7 && mont > 0)
                            {
                                AGE += AGE_UNIT + mont + "��";
                                AGE_UNIT = "";
                            }
                        }
                        else if (mont > 0)
                        {
                            AGE = "";
                            AGE_UNIT = "";
                            CHILD_AGE = mont.ToString() + "��";
                            if (day > 0)
                                CHILD_AGE += day.ToString() + "��";
                        }
                        else if (day > 0)
                        {
                            AGE = "";
                            AGE_UNIT = "";
                            CHILD_AGE = day.ToString() + "��";
                            if (hour > 0)
                                CHILD_AGE += hour.ToString() + "Сʱ";
                        }
                        else if (hour > 0)
                        {
                            AGE = "";
                            AGE_UNIT = "";
                            CHILD_AGE = hour.ToString() + "Сʱ";//����ȷ��Сʱ���ô�����
                        }
                        else
                        {
                            AGE = "";
                            AGE_UNIT = "";
                            CHILD_AGE = minute.ToString() + "����";
                        }
                        //}
                        if (AGE == "" && CHILD_AGE != "")//ֱ�Ӵ��age��������
                            AGE = CHILD_AGE;

                    }
                    catch (Exception)
                    {
                        AGE = dt.Rows[0]["AGE"].ToString();
                        AGE_UNIT = ConvertToAge(ref AGE);
                    }
                    #endregion

                    string UpdatePatient = "update T_IN_PATIENT set PATIENT_NAME='"
                                                             + dt.Rows[0]["patient_name"].ToString() + "',NAME_PINYIN='"
                                                             + App.getSpell(dt.Rows[0]["patient_name"].ToString()) + "',GENDER_CODE='"
                                                             + sex + "',BIRTHDAY=to_timestamp('" + dt.Rows[0]["BIRTHDAY"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),PID='"
                                                             + dt.Rows[0]["pid"].ToString() + "',Country='"
                                                             + dt.Rows[0]["Country"].ToString() + "',Native_Place='"
                                                             + CSD + "',Birth_Place='"
                                                             + CSD + "',Office_Phone='"
                                                             + dt.Rows[0]["Office_Phone"].ToString() + "',Relation='"
                                                             + dt.Rows[0]["Relation"].ToString() + "',HOME_ADDRESS='"
                                                             + dt.Rows[0]["HOME_ADDRESS"].ToString() + "',Homepostal_Code='"
                                                             + dt.Rows[0]["Homepostal_Code"].ToString() + "',Relation_Name='"
                                                             + dt.Rows[0]["Relation_Name"].ToString() + "',Relation_Address='"
                                                             + dt.Rows[0]["Relation_Address"].ToString() + "',Relation_Phone='"
                                                             + dt.Rows[0]["Relation_Phone"].ToString() + "',health_card_no='" + dt.Rows[0]["health_card_no"].ToString() + "',Folk_Code='"
                                                             + dt.Rows[0]["Folk_Code"].ToString() + "'," +
                                                                                "Career='"
                                                             + dt.Rows[0]["Career"].ToString() + "',Home_Phone='"
                                                             + dt.Rows[0]["Home_Phone"].ToString() + "'," + "Office='" + dt.Rows[0]["OFFICE"].ToString()
                                                             + "',Office_address='" + dt.Rows[0]["OFFICE_ADDRESS"].ToString() + "',NOW_ADDRESS='" + dt.Rows[0]["NOW_ADDRESS"].ToString() + "',Now_addres_phone='" + dt.Rows[0]["NOW_PHONE"].ToString() + "',Now_addres_PostNo='" + dt.Rows[0]["NOW_ADDRES_POSTNO"].ToString() + "',card_id='" + dt.Rows[0]["CARD_ID"].ToString() + "',medicare_no='" + dt.Rows[0]["ADMIT_INP_NO"].ToString() + "',PAY_MANNER='"
                                                             + dt.Rows[0]["PAY_MANNER"].ToString()
                                                             + "',NURSE_LEVEL='" + brhljb + "',SICK_DEGREE='" + brqk_code + "',AGE='" + AGE + "',AGE_UNIT='" + AGE_UNIT + "',CHILD_AGE='" + CHILD_AGE
                                                             + "',Marriage_State" + BRHY + ",In_Approach='" + dt.Rows[0]["In_Approach"].ToString()
                                                             + "',IN_TIME=to_timestamp('" + dt.Rows[0]["in_time"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9')"
                                                             + ",leave_time=to_timestamp('" + dt.Rows[0]["leave_time"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9')"
                                                             + ",die_time=to_timestamp('" + dt.Rows[0]["leave_time"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9')"
                                                             + " where his_id='"
                                                             + dt.Rows[0]["his_id"].ToString() + "' and InHospital_Count='" + dt.Rows[0]["InHospital_Count"].ToString() + "'";
                    int num = App.ExecuteSQL(UpdatePatient);
                    if (num > 0)
                    {
                        App.Msg("���³ɹ���");
                        DataInit.isInAreaSucceed = true;
                        if (this.Parent.GetType().ToString() == "Base_Function.BLL_DOCTOR.Patient_Action_Manager.frmPatientInfo")
                        {
                            Form frm = this.Parent as frmPatientInfo;
                            frm.Close();
                        }
                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ����ת��
        /// </summary>
        /// <param name="AGE"></param>
        /// <returns></returns>
        private static string ConvertToAge(ref string AGE)
        {
            int year = 0;
            string str = "��,��,��,Сʱ,����";
            string AGE_UNIT = "��";
            if (!string.IsNullOrEmpty(AGE))
            {

                foreach (string var in str.Split(','))
                {
                    bool flag = false;
                    year = AGE.IndexOf(var);
                    switch (var)
                    {
                        case "��":
                            int YearToInt = 0;
                            int.TryParse(AGE, out YearToInt);
                            if (year > 0)
                            {
                                AGE_UNIT = AGE.Substring(year);
                                AGE = AGE.Substring(0, year);
                                flag = true;
                            }
                            if (YearToInt > 0)
                            {
                                AGE = AGE;
                                AGE_UNIT = var;
                                flag = true;
                            }
                            break;
                        default:
                            if (year > 0)
                            {
                                AGE_UNIT = AGE.Substring(year);
                                AGE = AGE.Substring(0, year);
                                flag = true;
                            }
                            break;
                    }
                    if (flag)
                        break;
                }

            }
            else
            {
                AGE_UNIT = "��";
                AGE = "0";
            }
            return AGE_UNIT;
        }

        private void btnSaveAge_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ȷ��Ҫ�޸Ĳ�����Ϣ��", "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            #region ����
            string AGE = "";
            string AGE_UNIT = "";
            string CHILD_AGE = "";
            if (this.inPatient.PId.Contains("_"))
            {//������������������������������סԺ�Ŷ���XXXXXX_1����XXXXXXX_2��ʽ������סԺ�����»��ߵ�����ͳһΪ"������"��
                CHILD_AGE = "������";
            }
            else
            {
                AGE = txtAge1.Text;
                CHILD_AGE = txtAge2.Text;
            }
            if (AGE == "" && CHILD_AGE != "")//ֱ�Ӵ��age��������
                AGE = CHILD_AGE;
            if (AGE.Contains("��") || CHILD_AGE != "")
                AGE_UNIT = "";
            else
                AGE_UNIT = "��";
            string sql = @"update t_in_patient set  AGE='" + AGE + "', AGE_UNIT='" + AGE_UNIT + "', CHILD_AGE='" + CHILD_AGE + "' ";
            sql += string.Format(@" where id='{0}'", this.inPatient.Id);
            #endregion

            if (sql.Contains(@"where id="))
            {
                int count = 0;
                try
                {
                    count = App.ExecuteSQL(sql);
                }
                catch (Exception ex)
                {
                    App.Msg(ex.Message);
                }
                if (count == 1)
                {
                    DialogResult rs = MessageBox.Show("��ʾ: ����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    try
                    {
                        DataRow row = App.GetDataSet("select * from t_in_patient where id='" + this.inPatient.Id + "'").Tables[0].Rows[0];
                        InPatientInfo tempInPatient = DataInit.InitPatient(row);
                    }
                    catch { }
                }
                else
                {
                    App.Msg("���ź������쳣���ݣ��޸�ʧ�ܣ�");
                }
            }
        }
    }
}
