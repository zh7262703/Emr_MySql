using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// ���������밲ȫָ��¼�����
    /// ����:������
    /// ʱ��:2014-02-24,����������ҽԺ��Ŀ
    /// </summary>
    public partial class ucCover_Append_QAS : UserControl
    {
        private string PatientId="";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������
        /// <summary>
        /// ��ȡ������Ϣ����ʵ��
        /// </summary>
        private InPatientInfo inPatientInfo;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="inpatient">����</param>
        public ucCover_Append_QAS(InPatientInfo inpatient)
        {
            InitializeComponent();
            inPatientInfo = inpatient;
            PatientId = inPatientInfo.Id.ToString();
            iniValues();
            if (Cover_Append_id != "")
            {
                //����ҳ���Ѿ�д���ĸ�ҳ
                iniData(Cover_Append_id);
            }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        /// <param name="cover_append_id">סԺ��ҳ������</param>
        public ucCover_Append_QAS(string patientid,string cover_append_id)
        {
            InitializeComponent();
            PatientId = patientid;
            Cover_Append_id = cover_append_id;
            iniValues();
            if (Cover_Append_id != "")
            {
                //����ҳ���Ѿ�д���ĸ�ҳ
                iniData(cover_append_id);
            }

        }

        /// <summary>
        /// ��ʼ��ֵ
        /// </summary>
        private void iniValues()
        {
            try
            {
                //����סԺ�š����������䡢�Ա𡢿��ҡ�����
                lblpid.Text = inPatientInfo.PId;
                lblname.Text = inPatientInfo.Patient_Name;
                lblage.Text = inPatientInfo.Age + inPatientInfo.Age_unit;
                lblsex.Text = inPatientInfo.Gender_Code == "0" ? "��" : "Ů";
                lblsection.Text = inPatientInfo.Section_Name;
                lblbed.Text = inPatientInfo.Sick_Bed_Name;
                //���ݲ���������ѯ�Ƿ��Ѿ��м�¼
                string selsql="select id,create_time from COVER_APPEND_QAS where patient_id=" + inPatientInfo.Id.ToString() + "";
                Cover_Append_id = App.ReadSqlVal(selsql, 0, "id") == null ? "" : App.ReadSqlVal(selsql, 0, "id");
                
            }
            catch (Exception)
            {
            }
        }

       /// <summary>
        /// ��������
        /// </summary>
        public bool SaveData()
        {
            try
            {
                //ISHAVEIN �Ƿ�Ϊ������һ��������סԺ����:��� ���������ڣ���������һ����
                //INHOSPITAL_REASON ��סԺԭ��
                string ISHAVEIN = "";
                string INHOSPITAL_REASON = "";
                if (radISHAVEIN_NO.Checked)
                {
                    ISHAVEIN = "1";
                }
                else if (radISHAVEIN_LZL.Checked || radISHAVEIN_YYL.Checked)
                {
                    if (radISHAVEIN_LZL.Checked)
                    {
                        ISHAVEIN = "2";
                    }
                    else if (radISHAVEIN_YYL.Checked)
                    {
                        ISHAVEIN = "3";
                    }
                    INHOSPITAL_REASON = txtINHOSPITAL_REASON.Text;
                    if (INHOSPITAL_REASON.Trim()=="")
                    {
                        return false;
                    }
                }
                else
                {
                    //label8.ForeColor = Color.Red;
                    //App.Msg("��ʾ:[" + label8.Text + "]δѡ��!");
                    return false;
                }

                //ISCRITICAL_PATIENT �Ƿ�סԺΣ�ػ��� Y �� N ��
                //ISRESCUE סԺ�ڼ��Ƿ����� Y �� N ��
                //RESCUE_COUNT סԺ�ڼ����ȴ���
                //RESCUE_SUCCESS_COUNT ���ȳɹ�����
                //ISRESCUE_FINAL_SUCCESS ���������Ƿ�ɹ�����ɹ���    ��������     ���Զ���Ժ
                string ISCRITICAL_PATIENT = "";
                string ISRESCUE = "";
                string RESCUE_COUNT = "";
                string RESCUE_SUCCESS_COUNT = "";
                string ISRESCUE_FINAL_SUCCESS = "";
                if (radISCRITICAL_PATIENT_N.Checked)
                {//ISCRITICAL_PATIENT �Ƿ�סԺΣ�ػ��� Y �� N ��
                    ISCRITICAL_PATIENT = "N";
                }
                else if (radISCRITICAL_PATIENT_Y.Checked)
                {
                    ISCRITICAL_PATIENT = "Y";
                    if (radISRESCUE_N.Checked)
                    {//ISRESCUE סԺ�ڼ��Ƿ����� Y �� N ��
                        ISRESCUE = "N";
                    }
                    else if (radISRESCUE_Y.Checked)
                    {
                        ISRESCUE = "Y";
                        RESCUE_COUNT = txtRESCUE_COUNT.Text;
                        RESCUE_SUCCESS_COUNT = txtRESCUE_SUCCESS_COUNT.Text;
                        if (RESCUE_COUNT.Trim() == "" || RESCUE_SUCCESS_COUNT.Trim() == "")
                        {
                            return false;
                        }
                        if (radISRESCUE_FINAL_SUCCESS_CG.Checked)
                        {//ISRESCUE_FINAL_SUCCESS ���������Ƿ�ɹ�����ɹ���    ��������     ���Զ���Ժ
                            ISRESCUE_FINAL_SUCCESS = "1";
                        }
                        else if (radISRESCUE_FINAL_SUCCESS_SW.Checked)
                        {
                            ISRESCUE_FINAL_SUCCESS = "2";
                        }
                        else if (radISRESCUE_FINAL_SUCCESS_ZDCY.Checked)
                        {
                            ISRESCUE_FINAL_SUCCESS = "3";
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                //ISOPER_PATIENT �Ƿ�Ϊ�������ߣ���񣻡���������������������
                //ISREOPERATION �Ƿ�Ϊ����Ǽƻ��ٴ����� Y �� N ��
                //ISCOMPLICATIONS �Ƿ��������󲢷�֢���� Y �� N ��
                //PULMONARY_EMBOLISM ��˨��
                //DEEP_VEIN_THROMBOSIS ���˨��
                //SEPSIS ��Ѫ֢
                //BLEEDING_OR_HEMATOMA ��Ѫ��Ѫ��
                //WOUND_DEHISCENCE �˿��ѿ�
                //SUDDEN_DEATH ���
                //RESPIRATORY_FAILURE ����˥��
                //FRACTURE ����
                //PHYSIOLOGIC_DERANGEMENT ������л����
                //PULMONARY_INFECTION �β���Ⱦ
                //TRACHEAL_OUT �˹����������ѳ�
                //OTHER_COMPLICATIONS ��������֢
                //ISCANCER �Ƿ������������ Y �� N ��
                //ISPATHOLOGY_DIAGNOSIS ������������Ƿ���� Y �� N ��
                //ISFROZEN_SECTION �����Ƿ��Ϳ��ٱ�����Ƭ Y �� N ��
                //ISPARAFFIN_DIAGNOSIS ������ʯ������Ƿ���� Y �� N ��
                //ISOPER_DIE �Ƿ��������������� ��񣻡�����������������������������
                //DIE_REASON ����ԭ��
                string ISOPER_PATIENT = "";
                string ISREOPERATION = "";
                string ISCOMPLICATIONS = "";
                string PULMONARY_EMBOLISM = "";
                string DEEP_VEIN_THROMBOSIS = "";
                string SEPSIS = "";
                string BLEEDING_OR_HEMATOMA = "";
                string WOUND_DEHISCENCE = "";
                string SUDDEN_DEATH = "";
                string RESPIRATORY_FAILURE = "";
                string FRACTURE = "";
                string PHYSIOLOGIC_DERANGEMENT = "";
                string PULMONARY_INFECTION = "";
                string TRACHEAL_OUT = "";
                string OTHER_COMPLICATIONS = "";
                string ISCANCER = "";
                string ISPATHOLOGY_DIAGNOSIS = "";
                string ISFROZEN_SECTION = "";
                string ISPARAFFIN_DIAGNOSIS = "";
                string ISOPER_DIE = "";
                string DIE_REASON = "";

                if (radISOPER_PATIENT_N.Checked)
                {//ISOPER_PATIENT �Ƿ�Ϊ�������ߣ���񣻡���������������������
                    ISOPER_PATIENT = "1";
                }
                else if (radISOPER_PATIENT_JZSS.Checked || radISOPER_PATIENT_ZQSS.Checked)
                {
                    if (radISOPER_PATIENT_JZSS.Checked)
                    {
                        ISOPER_PATIENT = "2";
                    }
                    else if (radISOPER_PATIENT_ZQSS.Checked)
                    {
                        ISOPER_PATIENT = "3";
                    }
                    //ISREOPERATION �Ƿ�Ϊ����Ǽƻ��ٴ����� Y �� N ��
                    if (radISREOPERATION_N.Checked)
                    {
                        ISREOPERATION = "N";
                    }
                    else if (radISREOPERATION_Y.Checked)
                    {
                        ISREOPERATION = "Y";
                    }
                    else
                    {
                        return false;
                    }

                    //ISCOMPLICATIONS �Ƿ��������󲢷�֢���� Y �� N ��
                    if (radISCOMPLICATIONS_N.Checked)
                    {
                        ISCOMPLICATIONS = "N";
                    }
                    else if (radISCOMPLICATIONS_Y.Checked)
                    {
                        ISCOMPLICATIONS = "Y";
                        //PULMONARY_EMBOLISM ��˨��
                        if (chkPULMONARY_EMBOLISM.Checked)
                        {
                            PULMONARY_EMBOLISM = "1";
                        }
                        //DEEP_VEIN_THROMBOSIS ���˨��
                        if (chkDEEP_VEIN_THROMBOSIS.Checked)
                        {
                            DEEP_VEIN_THROMBOSIS = "1";
                        }
                        //SEPSIS ��Ѫ֢
                        if (chkSEPSIS.Checked)
                        {
                            SEPSIS = "1";
                        }
                        //BLEEDING_OR_HEMATOMA ��Ѫ��Ѫ��
                        if (chkBLEEDING_OR_HEMATOMA.Checked)
                        {
                            BLEEDING_OR_HEMATOMA = "1";
                        }
                        //WOUND_DEHISCENCE �˿��ѿ�
                        if (chkWOUND_DEHISCENCE.Checked)
                        {
                            WOUND_DEHISCENCE = "1";
                        }
                        //SUDDEN_DEATH ���
                        if (chkSUDDEN_DEATH.Checked)
                        {
                            SUDDEN_DEATH = "1";
                        }
                        //RESPIRATORY_FAILURE ����˥��
                        if (chkRESPIRATORY_FAILURE.Checked)
                        {
                            RESPIRATORY_FAILURE = "1";
                        }
                        //FRACTURE ����
                        if (chkFRACTURE.Checked)
                        {
                            FRACTURE = "1";
                        }
                        //PHYSIOLOGIC_DERANGEMENT ������л����
                        if (chkPHYSIOLOGIC_DERANGEMENT.Checked)
                        {
                            PHYSIOLOGIC_DERANGEMENT = "1";
                        }
                        //PULMONARY_INFECTION �β���Ⱦ
                        if (chkPULMONARY_INFECTION.Checked)
                        {
                            PULMONARY_INFECTION = "1";
                        }
                        //TRACHEAL_OUT �˹����������ѳ�
                        if (chkTRACHEAL_OUT.Checked)
                        {
                            TRACHEAL_OUT = "1";
                        }
                        //OTHER_COMPLICATIONS ��������֢
                        OTHER_COMPLICATIONS = txtOTHER_COMPLICATIONS.Text;

                        //PULMONARY_EMBOLISM ��˨��
                        //DEEP_VEIN_THROMBOSIS ���˨��
                        //SEPSIS ��Ѫ֢
                        //BLEEDING_OR_HEMATOMA ��Ѫ��Ѫ��
                        //WOUND_DEHISCENCE �˿��ѿ�
                        //SUDDEN_DEATH ���
                        //RESPIRATORY_FAILURE ����˥��
                        //FRACTURE ����
                        //PHYSIOLOGIC_DERANGEMENT ������л����
                        //PULMONARY_INFECTION �β���Ⱦ
                        //TRACHEAL_OUT �˹����������ѳ�
                        if (PULMONARY_EMBOLISM !="1" && DEEP_VEIN_THROMBOSIS !="1"&& SEPSIS !="1"&& BLEEDING_OR_HEMATOMA !="1"&& WOUND_DEHISCENCE !="1"
                            && SUDDEN_DEATH != "1" && RESPIRATORY_FAILURE != "1" && FRACTURE != "1" && PHYSIOLOGIC_DERANGEMENT != "1" && PULMONARY_INFECTION != "1" && TRACHEAL_OUT != "1" && OTHER_COMPLICATIONS.Trim()=="")
                        {
                            return false;
                        }
                        

                    }
                    else
                    {
                        return false;
                    }

                    //ISCANCER �Ƿ������������ Y �� N ��
                    if (radISCANCER_N.Checked)
                    {
                        ISCANCER = "N";
                    }
                    else if (radISCANCER_Y.Checked)
                    {
                        ISCANCER = "Y";
                        //ISPATHOLOGY_DIAGNOSIS ������������Ƿ���� Y �� N ��
                        if (radISPATHOLOGY_DIAGNOSIS_N.Checked)
                        {
                            ISPATHOLOGY_DIAGNOSIS = "N";
                        }
                        else if (radISPATHOLOGY_DIAGNOSIS_Y.Checked)
                        {
                            ISPATHOLOGY_DIAGNOSIS = "Y";
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                    //ISFROZEN_SECTION �����Ƿ��Ϳ��ٱ�����Ƭ Y �� N ��
                    if (radISFROZEN_SECTION_N.Checked)
                    {
                        ISFROZEN_SECTION = "N";
                    }
                    else if (radISFROZEN_SECTION_Y.Checked)
                    {
                        ISFROZEN_SECTION = "Y";
                        //ISPARAFFIN_DIAGNOSIS ������ʯ������Ƿ���� Y �� N ��
                        if (radISPARAFFIN_DIAGNOSIS_N.Checked)
                        {
                            ISPARAFFIN_DIAGNOSIS = "N";
                        }
                        else if (radISPARAFFIN_DIAGNOSIS_Y.Checked)
                        {
                            ISPARAFFIN_DIAGNOSIS = "Y";
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    //ISOPER_DIE �Ƿ��������������� ��񣻡�����������������������������
                    if (radISOPER_DIE_N.Checked)
                    {
                        ISOPER_DIE = "1";
                    }
                    else if (radISOPER_DIE_SSGCZSW.Checked || radISOPER_DIE_SSHSW.Checked)
                    {
                        if (radISOPER_DIE_SSGCZSW.Checked)
                        {
                            ISOPER_DIE = "2";
                        }
                        else if (radISOPER_DIE_SSHSW.Checked)
                        {
                            ISOPER_DIE = "3";
                        }
                        DIE_REASON = txtDIE_REASON.Text;
                        if (DIE_REASON.Trim() == "")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                //ISDUAL_REFERRAL	CHAR(1)	Y			�Ƿ�Ϊ˫��ת�ﻼ�ߣ���� ����ת������ת
                //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			ת���ҽԺ����ѡ����
                string ISDUAL_REFERRAL = "";
                string REFERRAL_HOSPITAL = "";
                if (radISDUAL_REFERRAL_N.Checked)
                {
                    ISDUAL_REFERRAL = "1";
                }
                else if (radISDUAL_REFERRAL_SZ.Checked || radISDUAL_REFERRAL_XZ.Checked)
                {
                    if (radISDUAL_REFERRAL_SZ.Checked)
                    {
                        ISDUAL_REFERRAL = "2";
                    }
                    else if (radISDUAL_REFERRAL_XZ.Checked)
                    {
                        ISDUAL_REFERRAL = "3";
                    }
                    //����ˮ̲��ͩ���������������ģ��������ظ��ױ���Ժ�������������ƺ��������Ժ��
                    //�𶫰�������ҽԺ����˫��������ҽԺ���𽭻��ص�һ����ҽԺ
                    if (radREFERRAL_HOSPITAL_LSTWTSQWSFWZX.Checked)
                    {
                        REFERRAL_HOSPITAL = "1";
                    }
                    else if (radREFERRAL_HOSPITAL_QYXFYBJY.Checked)
                    {
                        REFERRAL_HOSPITAL = "2";
                    }
                    else if (radREFERRAL_HOSPITAL_QYXLJPZXWSY.Checked)
                    {
                        REFERRAL_HOSPITAL = "3";
                    }
                    else if (radREFERRAL_HOSPITAL_DAXRMYY.Checked)
                    {
                        REFERRAL_HOSPITAL = "4";
                    }
                    else if (radREFERRAL_HOSPITAL_SPXRMYY.Checked)
                    {
                        REFERRAL_HOSPITAL = "5";
                    }
                    else if (radREFERRAL_HOSPITAL_JHXDYRMYY.Checked)
                    {
                        REFERRAL_HOSPITAL = "6";
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                //PATIENT_ID,ISHAVEIN,INHOSPITAL_REASON,ISCRITICAL_PATIENT,ISRESCUE,RESCUE_COUNT,RESCUE_SUCCESS_COUNT,
                //ISRESCUE_FINAL_SUCCESS,ISOPER_PATIENT,ISREOPERATION,ISCOMPLICATIONS,PULMONARY_EMBOLISM,DEEP_VEIN_THROMBOSIS,
                //SEPSIS,BLEEDING_OR_HEMATOMA,WOUND_DEHISCENCE,SUDDEN_DEATH,RESPIRATORY_FAILURE,FRACTURE,PHYSIOLOGIC_DERANGEMENT,
                //PULMONARY_INFECTION,TRACHEAL_OUT,OTHER_COMPLICATIONS,ISCANCER,ISPATHOLOGY_DIAGNOSIS,ISFROZEN_SECTION,
                //ISPARAFFIN_DIAGNOSIS,ISOPER_DIE,DIE_REASON,CREATE_TIME,USER_ID

                string Sql = "";
                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_QAS(PATIENT_ID,ISHAVEIN,INHOSPITAL_REASON,ISCRITICAL_PATIENT,ISRESCUE,RESCUE_COUNT,RESCUE_SUCCESS_COUNT," +
                        "ISRESCUE_FINAL_SUCCESS,ISOPER_PATIENT,ISREOPERATION,ISCOMPLICATIONS,PULMONARY_EMBOLISM,DEEP_VEIN_THROMBOSIS," +
                        "SEPSIS,BLEEDING_OR_HEMATOMA,WOUND_DEHISCENCE,SUDDEN_DEATH,RESPIRATORY_FAILURE,FRACTURE,PHYSIOLOGIC_DERANGEMENT," +
                        "PULMONARY_INFECTION,TRACHEAL_OUT,OTHER_COMPLICATIONS,ISCANCER,ISPATHOLOGY_DIAGNOSIS,ISFROZEN_SECTION," +
                        "ISPARAFFIN_DIAGNOSIS,ISOPER_DIE,DIE_REASON,CREATE_TIME,USER_ID,ISDUAL_REFERRAL,REFERRAL_HOSPITAL)values({0},'{1}','{2}','{3}','{4}','{5}'" +
                        ",'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'" +
                        ",'{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}',to_timestamp('{29}','syyyy-mm-dd hh24:mi'),{30},'{31}','{32}')";

                    Sql = string.Format(Sql, PatientId, ISHAVEIN, INHOSPITAL_REASON, ISCRITICAL_PATIENT, ISRESCUE, RESCUE_COUNT, RESCUE_SUCCESS_COUNT,
                            ISRESCUE_FINAL_SUCCESS, ISOPER_PATIENT, ISREOPERATION, ISCOMPLICATIONS, PULMONARY_EMBOLISM, DEEP_VEIN_THROMBOSIS,
                            SEPSIS, BLEEDING_OR_HEMATOMA, WOUND_DEHISCENCE, SUDDEN_DEATH, RESPIRATORY_FAILURE, FRACTURE, PHYSIOLOGIC_DERANGEMENT,
                            PULMONARY_INFECTION, TRACHEAL_OUT, OTHER_COMPLICATIONS, ISCANCER, ISPATHOLOGY_DIAGNOSIS, ISFROZEN_SECTION,
                            ISPARAFFIN_DIAGNOSIS, ISOPER_DIE, DIE_REASON, App.GetSystemTime().ToShortDateString(), App.UserAccount.UserInfo.User_id, ISDUAL_REFERRAL, REFERRAL_HOSPITAL);
                }
                else
                {
                    Sql = "update COVER_APPEND_QAS set ISHAVEIN='{0}',INHOSPITAL_REASON='{1}',ISCRITICAL_PATIENT='{2}',ISRESCUE='{3}',RESCUE_COUNT='{4}',RESCUE_SUCCESS_COUNT='{5}'," +
                        "ISRESCUE_FINAL_SUCCESS='{6}',ISOPER_PATIENT='{7}',ISREOPERATION='{8}',ISCOMPLICATIONS='{9}',PULMONARY_EMBOLISM='{10}',DEEP_VEIN_THROMBOSIS='{11}'," +
                        "SEPSIS='{12}',BLEEDING_OR_HEMATOMA='{13}',WOUND_DEHISCENCE='{14}',SUDDEN_DEATH='{15}',RESPIRATORY_FAILURE='{16}',FRACTURE='{17}',PHYSIOLOGIC_DERANGEMENT='{18}'," +
                        "PULMONARY_INFECTION='{19}',TRACHEAL_OUT='{20}',OTHER_COMPLICATIONS='{21}',ISCANCER='{22}',ISPATHOLOGY_DIAGNOSIS='{23}',ISFROZEN_SECTION='{24}'," +
                        "ISPARAFFIN_DIAGNOSIS='{25}',ISOPER_DIE='{26}',DIE_REASON='{27}',ISDUAL_REFERRAL='{28}',REFERRAL_HOSPITAL='{29}' " +
                                                            " where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql, ISHAVEIN, INHOSPITAL_REASON, ISCRITICAL_PATIENT, ISRESCUE, RESCUE_COUNT, RESCUE_SUCCESS_COUNT,
                                        ISRESCUE_FINAL_SUCCESS, ISOPER_PATIENT, ISREOPERATION, ISCOMPLICATIONS, PULMONARY_EMBOLISM, DEEP_VEIN_THROMBOSIS,
                                        SEPSIS, BLEEDING_OR_HEMATOMA, WOUND_DEHISCENCE, SUDDEN_DEATH, RESPIRATORY_FAILURE, FRACTURE, PHYSIOLOGIC_DERANGEMENT,
                                        PULMONARY_INFECTION, TRACHEAL_OUT, OTHER_COMPLICATIONS, ISCANCER, ISPATHOLOGY_DIAGNOSIS, ISFROZEN_SECTION,
                                        ISPARAFFIN_DIAGNOSIS, ISOPER_DIE, DIE_REASON, ISDUAL_REFERRAL, REFERRAL_HOSPITAL);
                }
                if (App.ExecuteSQL(Sql) > 0)
                {
                    App.Msg("����ɹ�!");
                    iniValues();
                    return true;
                }
                else
                {
                    App.MsgErr("����ʧ��!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ��ʼ����ҳ��Ϣ
        /// </summary>
        /// <param name="Cover_Append_id">��ҳ������</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string sql = "select ISHAVEIN,INHOSPITAL_REASON,ISCRITICAL_PATIENT,ISRESCUE,RESCUE_COUNT,RESCUE_SUCCESS_COUNT," +
                        "ISRESCUE_FINAL_SUCCESS,ISOPER_PATIENT,ISREOPERATION,ISCOMPLICATIONS,PULMONARY_EMBOLISM,DEEP_VEIN_THROMBOSIS," +
                        "SEPSIS,BLEEDING_OR_HEMATOMA,WOUND_DEHISCENCE,SUDDEN_DEATH,RESPIRATORY_FAILURE,FRACTURE,PHYSIOLOGIC_DERANGEMENT," +
                        "PULMONARY_INFECTION,TRACHEAL_OUT,OTHER_COMPLICATIONS,ISCANCER,ISPATHOLOGY_DIAGNOSIS,ISFROZEN_SECTION," +
                        "ISPARAFFIN_DIAGNOSIS,ISOPER_DIE,DIE_REASON,ISDUAL_REFERRAL,REFERRAL_HOSPITAL" +
                                    " from COVER_APPEND_QAS where id=" + Cover_Append_id;
                                    
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //ISHAVEIN				�Ƿ�Ϊ������һ��������סԺ����:��� ���������ڣ���������һ����
                        if (dt.Rows[i]["ISHAVEIN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISHAVEIN"].ToString() == "2"||dt.Rows[i]["ISHAVEIN"].ToString() == "3")
                            {
                                if (dt.Rows[i]["ISHAVEIN"].ToString() == "2")
                                {
                                    radISHAVEIN_LZL.Checked = true;
                                    panelEnabled(radISHAVEIN_LZL.Name);
                                }
                                else if (dt.Rows[i]["ISHAVEIN"].ToString() == "3")
                                {
                                    radISHAVEIN_YYL.Checked = true;
                                    panelEnabled(radISHAVEIN_YYL.Name);
                                }
                                //INHOSPITAL_REASON				��סԺԭ��
                                if (dt.Rows[i]["INHOSPITAL_REASON"].ToString().Trim() != "")
                                {
                                    txtINHOSPITAL_REASON.Text = dt.Rows[i]["INHOSPITAL_REASON"].ToString();
                                }
                            }
                            else
                            {
                                radISHAVEIN_NO.Checked = true;
                            }
                        }


                        //ISCRITICAL_PATIENT				�Ƿ�סԺΣ�ػ��� Y �� N ��
                        if (dt.Rows[i]["ISCRITICAL_PATIENT"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISCRITICAL_PATIENT"].ToString() == "Y")
                            {
                                radISCRITICAL_PATIENT_Y.Checked = true;
                                panelEnabled(radISCRITICAL_PATIENT_Y.Name);
                                //ISRESCUE				סԺ�ڼ��Ƿ����� Y �� N ��
                                if (dt.Rows[i]["ISRESCUE"].ToString().Trim() != "")       
                                {
                                    if (dt.Rows[i]["ISRESCUE"].ToString() == "Y")
                                    {
                                        radISRESCUE_Y.Checked = true;
                                        panelEnabled(radISRESCUE_Y.Name);
                                        //RESCUE_COUNT				סԺ�ڼ����ȴ���
                                        if (dt.Rows[i]["RESCUE_COUNT"].ToString().Trim() != "")
                                        {
                                            txtRESCUE_COUNT.Text = dt.Rows[i]["RESCUE_COUNT"].ToString();
                                        }
                                        //RESCUE_SUCCESS_COUNT				���ȳɹ�����
                                        if (dt.Rows[i]["RESCUE_SUCCESS_COUNT"].ToString().Trim() != "")
                                        {
                                            txtRESCUE_SUCCESS_COUNT.Text = dt.Rows[i]["RESCUE_SUCCESS_COUNT"].ToString();
                                        }
                                        //ISRESCUE_FINAL_SUCCESS				���������Ƿ�ɹ�����ɹ���    ��������     ���Զ���Ժ
                                        if (dt.Rows[i]["ISRESCUE_FINAL_SUCCESS"].ToString().Trim() != "")       //ѹ����
                                        {
                                            if (dt.Rows[i]["ISRESCUE_FINAL_SUCCESS"].ToString() == "2")
                                            {
                                                radISRESCUE_FINAL_SUCCESS_SW.Checked = true;
                                            }
                                            else if (dt.Rows[i]["ISRESCUE_FINAL_SUCCESS"].ToString() == "3")
                                            {
                                                radISRESCUE_FINAL_SUCCESS_ZDCY.Checked = true;
                                            }
                                            else
                                            {
                                                radISRESCUE_FINAL_SUCCESS_CG.Checked = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        radISRESCUE_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                radISCRITICAL_PATIENT_N.Checked = true;
                            }
                        }


                        //ISOPER_PATIENT				�Ƿ�Ϊ�������ߣ���񣻡���������������������
                        if (dt.Rows[i]["ISOPER_PATIENT"].ToString().Trim() != "")       
                        {
                            if (dt.Rows[i]["ISOPER_PATIENT"].ToString() == "2"||dt.Rows[i]["ISOPER_PATIENT"].ToString() == "3")
                            {
                                if (dt.Rows[i]["ISOPER_PATIENT"].ToString() == "2")
                                {
                                    radISOPER_PATIENT_JZSS.Checked = true;
                                    panelEnabled(radISOPER_PATIENT_JZSS.Name);
                                }
                                else if (dt.Rows[i]["ISOPER_PATIENT"].ToString() == "3")
                                {
                                    radISOPER_PATIENT_ZQSS.Checked = true;
                                    panelEnabled(radISOPER_PATIENT_ZQSS.Name);
                                }
                                //ISREOPERATION				�Ƿ�Ϊ����Ǽƻ��ٴ����� Y �� N ��
                                if (dt.Rows[i]["ISREOPERATION"].ToString().Trim() != "")      
                                {
                                    if (dt.Rows[i]["ISREOPERATION"].ToString() == "Y")
                                    {
                                        radISREOPERATION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        radISREOPERATION_N.Checked = true;
                                    }
                                }
                                //ISCOMPLICATIONS				�Ƿ��������󲢷�֢���� Y �� N ��
                                if (dt.Rows[i]["ISCOMPLICATIONS"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISCOMPLICATIONS"].ToString() == "Y")
                                    {
                                        radISCOMPLICATIONS_Y.Checked = true;
                                        panelEnabled(radISCOMPLICATIONS_Y.Name);
                                        //PULMONARY_EMBOLISM				��˨��
                                        if (dt.Rows[i]["PULMONARY_EMBOLISM"].ToString().Trim() != "")
                                        {
                                            chkPULMONARY_EMBOLISM.Checked = true;
                                        }
                                        //DEEP_VEIN_THROMBOSIS				���˨��
                                        if (dt.Rows[i]["DEEP_VEIN_THROMBOSIS"].ToString().Trim() != "")
                                        {
                                            chkDEEP_VEIN_THROMBOSIS.Checked = true;
                                        }
                                        //SEPSIS				��Ѫ֢
                                        if (dt.Rows[i]["SEPSIS"].ToString().Trim() != "")
                                        {
                                            chkSEPSIS.Checked = true;
                                        }
                                        //BLEEDING_OR_HEMATOMA				��Ѫ��Ѫ��
                                        if (dt.Rows[i]["BLEEDING_OR_HEMATOMA"].ToString().Trim() != "")
                                        {
                                            chkBLEEDING_OR_HEMATOMA.Checked = true;
                                        }
                                        //WOUND_DEHISCENCE				�˿��ѿ�
                                        if (dt.Rows[i]["WOUND_DEHISCENCE"].ToString().Trim() != "")
                                        {
                                            chkWOUND_DEHISCENCE.Checked = true;
                                        }
                                        //SUDDEN_DEATH				���
                                        if (dt.Rows[i]["SUDDEN_DEATH"].ToString().Trim() != "")
                                        {
                                            chkSUDDEN_DEATH.Checked = true;
                                        }
                                        //RESPIRATORY_FAILURE				����˥��
                                        if (dt.Rows[i]["RESPIRATORY_FAILURE"].ToString().Trim() != "")
                                        {
                                            chkRESPIRATORY_FAILURE.Checked = true;
                                        }
                                        //FRACTURE				����
                                        if (dt.Rows[i]["FRACTURE"].ToString().Trim() != "")
                                        {
                                            chkFRACTURE.Checked = true;
                                        }
                                        //PHYSIOLOGIC_DERANGEMENT				������л����
                                        if (dt.Rows[i]["PHYSIOLOGIC_DERANGEMENT"].ToString().Trim() != "")
                                        {
                                            chkPHYSIOLOGIC_DERANGEMENT.Checked = true;
                                        }
                                        //PULMONARY_INFECTION				�β���Ⱦ
                                        if (dt.Rows[i]["PULMONARY_INFECTION"].ToString().Trim() != "")
                                        {
                                            chkPULMONARY_INFECTION.Checked = true;
                                        }
                                        //TRACHEAL_OUT				�˹����������ѳ�
                                        if (dt.Rows[i]["TRACHEAL_OUT"].ToString().Trim() != "")
                                        {
                                            chkTRACHEAL_OUT.Checked = true;
                                        }
                                        //OTHER_COMPLICATIONS				��������֢
                                        if (dt.Rows[i]["OTHER_COMPLICATIONS"].ToString().Trim() != "")
                                        {
                                            txtOTHER_COMPLICATIONS.Text = dt.Rows[i]["OTHER_COMPLICATIONS"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        radISCOMPLICATIONS_N.Checked = true;
                                    }
                                }
                                //ISCANCER				�Ƿ������������ Y �� N ��
                                if (dt.Rows[i]["ISCANCER"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISCANCER"].ToString() == "Y")
                                    {
                                        radISCANCER_Y.Checked = true;
                                        panelEnabled(radISCANCER_Y.Name);
                                        //ISPATHOLOGY_DIAGNOSIS				������������Ƿ���� Y �� N ��
                                        if (dt.Rows[i]["ISPATHOLOGY_DIAGNOSIS"].ToString().Trim() != "")
                                        {
                                            if (dt.Rows[i]["ISPATHOLOGY_DIAGNOSIS"].ToString() == "Y")
                                            {
                                                radISPATHOLOGY_DIAGNOSIS_Y.Checked = true;
                                            }
                                            else
                                            {
                                                radISPATHOLOGY_DIAGNOSIS_N.Checked = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        radISCANCER_N.Checked = true;
                                    }
                                }
                                
                                //ISFROZEN_SECTION				�����Ƿ��Ϳ��ٱ�����Ƭ Y �� N ��
                                if (dt.Rows[i]["ISFROZEN_SECTION"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISFROZEN_SECTION"].ToString() == "Y")
                                    {
                                        radISFROZEN_SECTION_Y.Checked = true;
                                        panelEnabled(radISFROZEN_SECTION_Y.Name);
                                        //ISPARAFFIN_DIAGNOSIS				������ʯ������Ƿ���� Y �� N ��
                                        if (dt.Rows[i]["ISPARAFFIN_DIAGNOSIS"].ToString().Trim() != "")
                                        {
                                            if (dt.Rows[i]["ISPARAFFIN_DIAGNOSIS"].ToString() == "Y")
                                            {
                                                radISPARAFFIN_DIAGNOSIS_Y.Checked = true;
                                            }
                                            else
                                            {
                                                radISPARAFFIN_DIAGNOSIS_N.Checked = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        radISFROZEN_SECTION_N.Checked = true;
                                    }
                                }
                                
                                //ISOPER_DIE				�Ƿ��������������� ��񣻡�����������������������������
                                if (dt.Rows[i]["ISOPER_DIE"].ToString().Trim() != "")       //ѹ����
                                {
                                    if (dt.Rows[i]["ISOPER_DIE"].ToString() == "2"||dt.Rows[i]["ISOPER_DIE"].ToString() == "3")
                                    {
                                        if (dt.Rows[i]["ISOPER_DIE"].ToString() == "2")
                                        {
                                            radISOPER_DIE_SSGCZSW.Checked = true;
                                            panelEnabled(radISOPER_DIE_SSGCZSW.Name);
                                        }
                                        else if (dt.Rows[i]["ISOPER_DIE"].ToString() == "3")
                                        {
                                            radISOPER_DIE_SSHSW.Checked = true;
                                            panelEnabled(radISOPER_DIE_SSHSW.Name);
                                        }
                                        //DIE_REASON				����ԭ��
                                        if (dt.Rows[i]["DIE_REASON"].ToString().Trim() != "")
                                        {
                                            txtDIE_REASON.Text = dt.Rows[i]["DIE_REASON"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        radISOPER_DIE_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                radISOPER_PATIENT_N.Checked = true;
                            }
                        }
                        //ISDUAL_REFERRAL	CHAR(1)	Y			�Ƿ�Ϊ˫��ת�ﻼ�ߣ���� ����ת������ת
                        //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			ת���ҽԺ����ѡ����
                        if (dt.Rows[i]["ISDUAL_REFERRAL"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISDUAL_REFERRAL"].ToString() == "2" || dt.Rows[i]["ISDUAL_REFERRAL"].ToString() == "3")
                            {
                                if (dt.Rows[i]["ISDUAL_REFERRAL"].ToString() == "2")
                                {
                                    radISDUAL_REFERRAL_SZ.Checked = true;
                                    panelEnabled(radISDUAL_REFERRAL_SZ.Name);
                                }
                                else if (dt.Rows[i]["ISDUAL_REFERRAL"].ToString() == "3")
                                {
                                    radISDUAL_REFERRAL_XZ.Checked = true;
                                    panelEnabled(radISDUAL_REFERRAL_XZ.Name);
                                }


                                //����ˮ̲��ͩ���������������ģ��������ظ��ױ���Ժ�������������ƺ��������Ժ��
                                //�𶫰�������ҽԺ����˫��������ҽԺ���𽭻��ص�һ����ҽԺ
                                if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "1")
                                    {
                                        radREFERRAL_HOSPITAL_LSTWTSQWSFWZX.Checked = true;
                                    }
                                    else if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "2")
                                    {
                                        radREFERRAL_HOSPITAL_QYXFYBJY.Checked = true;
                                    }
                                    else if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "3")
                                    {
                                        radREFERRAL_HOSPITAL_QYXLJPZXWSY.Checked = true;
                                    }
                                    else if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "4")
                                    {
                                        radREFERRAL_HOSPITAL_DAXRMYY.Checked = true;
                                    }
                                    else if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "5")
                                    {
                                        radREFERRAL_HOSPITAL_SPXRMYY.Checked = true;
                                    }
                                    else if (dt.Rows[i]["REFERRAL_HOSPITAL"].ToString() == "6")
                                    {
                                        radREFERRAL_HOSPITAL_JHXDYRMYY.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                radISDUAL_REFERRAL_N.Checked = true;
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
            }
        }

        /// <summary>
        /// ֻ�����������ֺ�С����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete)
            {
                if ((sender as TextBox).Text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panelEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //��Ϊ��������ѡ��ȫ����ң�����ѡ��
            panelEnabled((sender as RadioButton).Name);
        }

        private void panelEnabled(string radname)
        {

            //�Ƿ�Ϊ������һ��������סԺ���ߣ���� ���������ڣ���������һ���ڡ�
            if (radname == "radISHAVEIN_LZL" || radname == "radISHAVEIN_YYL")
            {
                plISHAVEIN.Enabled = true;
            }
            else if (radname == "radISHAVEIN_NO")
            {
                txtINHOSPITAL_REASON.Text = "";
                plISHAVEIN.Enabled = false;
            }
            //�Ƿ�סԺΣ�ػ��ߣ�
            if (radname == "radISCRITICAL_PATIENT_Y" || radname == "radISRESCUE_Y" || radname == "radISRESCUE_N")
            {
                plISCRITICAL_PATIENT.Enabled = true;
                //סԺ�ڼ��Ƿ�����
                if (radname == "radISRESCUE_Y")
                {
                    plISRESCUE.Enabled = true;
                }
                else if (radname == "radISRESCUE_N")
                {
                    txtRESCUE_COUNT.Text = "";
                    txtRESCUE_SUCCESS_COUNT.Text = "";
                    radISRESCUE_FINAL_SUCCESS_CG.Checked = false;
                    radISRESCUE_FINAL_SUCCESS_SW.Checked = false;
                    radISRESCUE_FINAL_SUCCESS_ZDCY.Checked = false;
                    plISRESCUE.Enabled = false;
                }
            }
            else if (radname == "radISCRITICAL_PATIENT_N")
            {//���
                radISRESCUE_Y.Checked = false;
                radISRESCUE_N.Checked = false;
                txtRESCUE_COUNT.Text = "";
                txtRESCUE_SUCCESS_COUNT.Text = "";
                radISRESCUE_FINAL_SUCCESS_CG.Checked = false;
                radISRESCUE_FINAL_SUCCESS_SW.Checked = false;
                radISRESCUE_FINAL_SUCCESS_ZDCY.Checked = false;
                plISRESCUE.Enabled = false;
                plISCRITICAL_PATIENT.Enabled = false;
            }

            //�Ƿ�Ϊ�������� :��񣻡���������������������
            if (radname == "radISOPER_PATIENT_JZSS" || radname == "radISOPER_PATIENT_ZQSS" ||
                radname == "radISCOMPLICATIONS_Y" || radname == "radISCOMPLICATIONS_N" ||
                radname == "radISCANCER_Y" || radname == "radISCANCER_N" ||
                radname == "radISFROZEN_SECTION_Y" || radname == "radISFROZEN_SECTION_N" ||
                radname == "radISOPER_DIE_N" || radname == "radISOPER_DIE_SSGCZSW" || radname == "radISOPER_DIE_SSHSW")
            {
                plISOPER_PATIENT.Enabled = true;
                if (radname == "radISCOMPLICATIONS_Y")
                {//�Ƿ��������󲢷�֢���� Y �� N ��
                    plISCOMPLICATIONS.Enabled = true;
                }
                else if (radname == "radISCOMPLICATIONS_N")
                {
                    //����֢
                    chkPULMONARY_EMBOLISM.Checked = false;
                    chkDEEP_VEIN_THROMBOSIS.Checked = false;
                    chkSEPSIS.Checked = false;
                    chkBLEEDING_OR_HEMATOMA.Checked = false;
                    chkWOUND_DEHISCENCE.Checked = false;
                    chkSUDDEN_DEATH.Checked = false;
                    chkRESPIRATORY_FAILURE.Checked = false;
                    chkFRACTURE.Checked = false;
                    chkPHYSIOLOGIC_DERANGEMENT.Checked = false;
                    chkPULMONARY_INFECTION.Checked = false;
                    chkTRACHEAL_OUT.Checked = false;
                    txtOTHER_COMPLICATIONS.Text = "";//��������֢
                    plISCOMPLICATIONS.Enabled = false;
                }
                if (radname == "radISCANCER_Y")
                {//�Ƿ������������ Y �� N ��
                    plISCANCER.Enabled = true;
                }
                else if (radname == "radISCANCER_N")
                {
                    //������������Ƿ����
                    radISPATHOLOGY_DIAGNOSIS_N.Checked = false;
                    radISPATHOLOGY_DIAGNOSIS_Y.Checked = false;
                    plISCANCER.Enabled = false;
                }
                if (radname == "radISFROZEN_SECTION_Y")
                {//�����Ƿ��Ϳ��ٱ�����Ƭ Y �� N ��
                    plISFROZEN_SECTION.Enabled = true;
                }
                else if (radname == "radISFROZEN_SECTION_N")
                {
                    //������������Ƿ����
                    radISPARAFFIN_DIAGNOSIS_N.Checked = false;
                    radISPARAFFIN_DIAGNOSIS_Y.Checked = false;
                    plISFROZEN_SECTION.Enabled = false;
                }
                if (radname == "radISOPER_DIE_SSGCZSW" || radname == "radISOPER_DIE_SSHSW")
                { //�Ƿ��������������� ��񣻡�����������������������������
                    plISOPER_DIE.Enabled = true;
                }
                else if (radname == "radISOPER_DIE_N")
                {
                    txtDIE_REASON.Text = "";
                    plISOPER_DIE.Enabled = false;
                }
            }
            else if (radname == "radISOPER_PATIENT_N")
            {
                //�Ƿ�Ϊ����Ǽƻ��ٴ����� Y �� N ��
                radISREOPERATION_N.Checked = false;
                radISREOPERATION_Y.Checked = false;
                //�Ƿ��������󲢷�֢���� Y �� N ��
                radISCOMPLICATIONS_N.Checked = false;
                radISCOMPLICATIONS_Y.Checked = false;
                //����֢
                chkPULMONARY_EMBOLISM.Checked = false;
                chkDEEP_VEIN_THROMBOSIS.Checked = false;
                chkSEPSIS.Checked = false;
                chkBLEEDING_OR_HEMATOMA.Checked = false;
                chkWOUND_DEHISCENCE.Checked = false;
                chkSUDDEN_DEATH.Checked = false;
                chkRESPIRATORY_FAILURE.Checked = false;
                chkFRACTURE.Checked = false;
                chkPHYSIOLOGIC_DERANGEMENT.Checked = false;
                chkPULMONARY_INFECTION.Checked = false;
                chkTRACHEAL_OUT.Checked = false;
                txtOTHER_COMPLICATIONS.Text = "";//��������֢
                //�Ƿ������������ Y �� N ��
                radISCANCER_N.Checked = false;
                radISCANCER_Y.Checked = false;
                //������������Ƿ���� Y �� N ��
                radISPATHOLOGY_DIAGNOSIS_N.Checked = false;
                radISPATHOLOGY_DIAGNOSIS_Y.Checked = false;
                //�����Ƿ��Ϳ��ٱ�����Ƭ Y �� N ��
                radISFROZEN_SECTION_N.Checked = false;
                radISFROZEN_SECTION_Y.Checked = false;
                //������ʯ������Ƿ���� Y �� N ��
                radISPARAFFIN_DIAGNOSIS_N.Checked = false;
                radISPARAFFIN_DIAGNOSIS_Y.Checked = false;
                //�Ƿ��������������� ��񣻡�����������������������������
                radISOPER_DIE_N.Checked = false;
                radISOPER_DIE_SSGCZSW.Checked = false;
                radISOPER_DIE_SSHSW.Checked = false;
                txtDIE_REASON.Text = "";//����ԭ��
                //panel
                plISCOMPLICATIONS.Enabled = false;
                plISCANCER.Enabled = false;
                plISFROZEN_SECTION.Enabled = false;
                plISOPER_DIE.Enabled = false;
                plISOPER_PATIENT.Enabled = false;
            }

            //ISDUAL_REFERRAL	CHAR(1)	Y			�Ƿ�Ϊ˫��ת�ﻼ�ߣ���� ����ת������ת
            if (radname == "radISDUAL_REFERRAL_SZ" || radname == "radISDUAL_REFERRAL_XZ")
            {
                plISDUAL_REFERRAL.Enabled = true;
            }
            else if (radname == "radISDUAL_REFERRAL_N")
            {
                //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			ת���ҽԺ����ѡ����
                //����ˮ̲��ͩ���������������ģ��������ظ��ױ���Ժ�������������ƺ��������Ժ��
                //�𶫰�������ҽԺ����˫��������ҽԺ���𽭻��ص�һ����ҽԺ
                radREFERRAL_HOSPITAL_LSTWTSQWSFWZX.Checked = false;
                radREFERRAL_HOSPITAL_QYXFYBJY.Checked = false;
                radREFERRAL_HOSPITAL_QYXLJPZXWSY.Checked = false;
                radREFERRAL_HOSPITAL_DAXRMYY.Checked = false;
                radREFERRAL_HOSPITAL_SPXRMYY.Checked = false;
                radREFERRAL_HOSPITAL_JHXDYRMYY.Checked = false;
                plISDUAL_REFERRAL.Enabled = false;
            }
        }


        
    }
}
