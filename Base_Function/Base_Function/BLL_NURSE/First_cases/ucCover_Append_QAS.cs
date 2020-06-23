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
    /// 患者质量与安全指标录入界面
    /// 开发:李文明
    /// 时间:2014-02-24,永州市中心医院项目
    /// </summary>
    public partial class ucCover_Append_QAS : UserControl
    {
        private string PatientId="";           //当前病人的主键
        private string Cover_Append_id = "";   //当前选中的住院附页的主键
        /// <summary>
        /// 读取病人信息表病人实例
        /// </summary>
        private InPatientInfo inPatientInfo;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inpatient">病人</param>
        public ucCover_Append_QAS(InPatientInfo inpatient)
        {
            InitializeComponent();
            inPatientInfo = inpatient;
            PatientId = inPatientInfo.Id.ToString();
            iniValues();
            if (Cover_Append_id != "")
            {
                //当附页是已经写过的附页
                iniData(Cover_Append_id);
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        /// <param name="cover_append_id">住院附页的主键</param>
        public ucCover_Append_QAS(string patientid,string cover_append_id)
        {
            InitializeComponent();
            PatientId = patientid;
            Cover_Append_id = cover_append_id;
            iniValues();
            if (Cover_Append_id != "")
            {
                //当附页是已经写过的附页
                iniData(cover_append_id);
            }

        }

        /// <summary>
        /// 初始化值
        /// </summary>
        private void iniValues()
        {
            try
            {
                //患者住院号、姓名、年龄、性别、科室、床号
                lblpid.Text = inPatientInfo.PId;
                lblname.Text = inPatientInfo.Patient_Name;
                lblage.Text = inPatientInfo.Age + inPatientInfo.Age_unit;
                lblsex.Text = inPatientInfo.Gender_Code == "0" ? "男" : "女";
                lblsection.Text = inPatientInfo.Section_Name;
                lblbed.Text = inPatientInfo.Sick_Bed_Name;
                //根据病人主键查询是否已经有记录
                string selsql="select id,create_time from COVER_APPEND_QAS where patient_id=" + inPatientInfo.Id.ToString() + "";
                Cover_Append_id = App.ReadSqlVal(selsql, 0, "id") == null ? "" : App.ReadSqlVal(selsql, 0, "id");
                
            }
            catch (Exception)
            {
            }
        }

       /// <summary>
        /// 保存数据
        /// </summary>
        public bool SaveData()
        {
            try
            {
                //ISHAVEIN 是否为两周与一个月内再住院患者:○否 ；○两周内；○两周至一月内
                //INHOSPITAL_REASON 再住院原因
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
                    //App.Msg("提示:[" + label8.Text + "]未选择!");
                    return false;
                }

                //ISCRITICAL_PATIENT 是否住院危重患者 Y 是 N 否
                //ISRESCUE 住院期间是否抢救 Y 是 N 否
                //RESCUE_COUNT 住院期间抢救次数
                //RESCUE_SUCCESS_COUNT 抢救成功次数
                //ISRESCUE_FINAL_SUCCESS 抢救最终是否成功：○成功；    ○死亡；     ○自动出院
                string ISCRITICAL_PATIENT = "";
                string ISRESCUE = "";
                string RESCUE_COUNT = "";
                string RESCUE_SUCCESS_COUNT = "";
                string ISRESCUE_FINAL_SUCCESS = "";
                if (radISCRITICAL_PATIENT_N.Checked)
                {//ISCRITICAL_PATIENT 是否住院危重患者 Y 是 N 否
                    ISCRITICAL_PATIENT = "N";
                }
                else if (radISCRITICAL_PATIENT_Y.Checked)
                {
                    ISCRITICAL_PATIENT = "Y";
                    if (radISRESCUE_N.Checked)
                    {//ISRESCUE 住院期间是否抢救 Y 是 N 否
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
                        {//ISRESCUE_FINAL_SUCCESS 抢救最终是否成功：○成功；    ○死亡；     ○自动出院
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

                //ISOPER_PATIENT 是否为手术患者：○否；○急诊手术；○择期手术。
                //ISREOPERATION 是否为术后非计划再次手术 Y 是 N 否
                //ISCOMPLICATIONS 是否有手术后并发症发生 Y 是 N 否
                //PULMONARY_EMBOLISM 肺栓塞
                //DEEP_VEIN_THROMBOSIS 深静脉栓塞
                //SEPSIS 败血症
                //BLEEDING_OR_HEMATOMA 出血或血肿
                //WOUND_DEHISCENCE 伤口裂开
                //SUDDEN_DEATH 猝死
                //RESPIRATORY_FAILURE 呼吸衰竭
                //FRACTURE 骨折
                //PHYSIOLOGIC_DERANGEMENT 生理、代谢紊乱
                //PULMONARY_INFECTION 肺部感染
                //TRACHEAL_OUT 人工气管意外脱出
                //OTHER_COMPLICATIONS 其他并发症
                //ISCANCER 是否恶性肿瘤患者 Y 是 N 否
                //ISPATHOLOGY_DIAGNOSIS 与术后病理诊断是否符合 Y 是 N 否
                //ISFROZEN_SECTION 术中是否送快速冰冻切片 Y 是 N 否
                //ISPARAFFIN_DIAGNOSIS 与术后石蜡诊断是否符合 Y 是 N 否
                //ISOPER_DIE 是否手术导致死亡： ○否；○手术过程中死亡；○手术后死亡
                //DIE_REASON 死亡原因
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
                {//ISOPER_PATIENT 是否为手术患者：○否；○急诊手术；○择期手术。
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
                    //ISREOPERATION 是否为术后非计划再次手术 Y 是 N 否
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

                    //ISCOMPLICATIONS 是否有手术后并发症发生 Y 是 N 否
                    if (radISCOMPLICATIONS_N.Checked)
                    {
                        ISCOMPLICATIONS = "N";
                    }
                    else if (radISCOMPLICATIONS_Y.Checked)
                    {
                        ISCOMPLICATIONS = "Y";
                        //PULMONARY_EMBOLISM 肺栓塞
                        if (chkPULMONARY_EMBOLISM.Checked)
                        {
                            PULMONARY_EMBOLISM = "1";
                        }
                        //DEEP_VEIN_THROMBOSIS 深静脉栓塞
                        if (chkDEEP_VEIN_THROMBOSIS.Checked)
                        {
                            DEEP_VEIN_THROMBOSIS = "1";
                        }
                        //SEPSIS 败血症
                        if (chkSEPSIS.Checked)
                        {
                            SEPSIS = "1";
                        }
                        //BLEEDING_OR_HEMATOMA 出血或血肿
                        if (chkBLEEDING_OR_HEMATOMA.Checked)
                        {
                            BLEEDING_OR_HEMATOMA = "1";
                        }
                        //WOUND_DEHISCENCE 伤口裂开
                        if (chkWOUND_DEHISCENCE.Checked)
                        {
                            WOUND_DEHISCENCE = "1";
                        }
                        //SUDDEN_DEATH 猝死
                        if (chkSUDDEN_DEATH.Checked)
                        {
                            SUDDEN_DEATH = "1";
                        }
                        //RESPIRATORY_FAILURE 呼吸衰竭
                        if (chkRESPIRATORY_FAILURE.Checked)
                        {
                            RESPIRATORY_FAILURE = "1";
                        }
                        //FRACTURE 骨折
                        if (chkFRACTURE.Checked)
                        {
                            FRACTURE = "1";
                        }
                        //PHYSIOLOGIC_DERANGEMENT 生理、代谢紊乱
                        if (chkPHYSIOLOGIC_DERANGEMENT.Checked)
                        {
                            PHYSIOLOGIC_DERANGEMENT = "1";
                        }
                        //PULMONARY_INFECTION 肺部感染
                        if (chkPULMONARY_INFECTION.Checked)
                        {
                            PULMONARY_INFECTION = "1";
                        }
                        //TRACHEAL_OUT 人工气管意外脱出
                        if (chkTRACHEAL_OUT.Checked)
                        {
                            TRACHEAL_OUT = "1";
                        }
                        //OTHER_COMPLICATIONS 其他并发症
                        OTHER_COMPLICATIONS = txtOTHER_COMPLICATIONS.Text;

                        //PULMONARY_EMBOLISM 肺栓塞
                        //DEEP_VEIN_THROMBOSIS 深静脉栓塞
                        //SEPSIS 败血症
                        //BLEEDING_OR_HEMATOMA 出血或血肿
                        //WOUND_DEHISCENCE 伤口裂开
                        //SUDDEN_DEATH 猝死
                        //RESPIRATORY_FAILURE 呼吸衰竭
                        //FRACTURE 骨折
                        //PHYSIOLOGIC_DERANGEMENT 生理、代谢紊乱
                        //PULMONARY_INFECTION 肺部感染
                        //TRACHEAL_OUT 人工气管意外脱出
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

                    //ISCANCER 是否恶性肿瘤患者 Y 是 N 否
                    if (radISCANCER_N.Checked)
                    {
                        ISCANCER = "N";
                    }
                    else if (radISCANCER_Y.Checked)
                    {
                        ISCANCER = "Y";
                        //ISPATHOLOGY_DIAGNOSIS 与术后病理诊断是否符合 Y 是 N 否
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

                    //ISFROZEN_SECTION 术中是否送快速冰冻切片 Y 是 N 否
                    if (radISFROZEN_SECTION_N.Checked)
                    {
                        ISFROZEN_SECTION = "N";
                    }
                    else if (radISFROZEN_SECTION_Y.Checked)
                    {
                        ISFROZEN_SECTION = "Y";
                        //ISPARAFFIN_DIAGNOSIS 与术后石蜡诊断是否符合 Y 是 N 否
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
                    //ISOPER_DIE 是否手术导致死亡： ○否；○手术过程中死亡；○手术后死亡
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

                //ISDUAL_REFERRAL	CHAR(1)	Y			是否为双向转诊患者：○否； ○上转；○下转
                //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			转诊的医院（单选）：
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
                    //○冷水滩梧桐社区卫生服务中心；○祁阳县妇幼保健院；○祁阳县黎家坪中心卫生院；
                    //○东安县人民医院；○双牌县人民医院；○江华县第一人民医院
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
                    App.Msg("保存成功!");
                    iniValues();
                    return true;
                }
                else
                {
                    App.MsgErr("保存失败!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 初始化附页信息
        /// </summary>
        /// <param name="Cover_Append_id">附页的主键</param>
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
                        //ISHAVEIN				是否为两周与一个月内再住院患者:○否 ；○两周内；○两周至一月内
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
                                //INHOSPITAL_REASON				再住院原因
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


                        //ISCRITICAL_PATIENT				是否住院危重患者 Y 是 N 否
                        if (dt.Rows[i]["ISCRITICAL_PATIENT"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISCRITICAL_PATIENT"].ToString() == "Y")
                            {
                                radISCRITICAL_PATIENT_Y.Checked = true;
                                panelEnabled(radISCRITICAL_PATIENT_Y.Name);
                                //ISRESCUE				住院期间是否抢救 Y 是 N 否
                                if (dt.Rows[i]["ISRESCUE"].ToString().Trim() != "")       
                                {
                                    if (dt.Rows[i]["ISRESCUE"].ToString() == "Y")
                                    {
                                        radISRESCUE_Y.Checked = true;
                                        panelEnabled(radISRESCUE_Y.Name);
                                        //RESCUE_COUNT				住院期间抢救次数
                                        if (dt.Rows[i]["RESCUE_COUNT"].ToString().Trim() != "")
                                        {
                                            txtRESCUE_COUNT.Text = dt.Rows[i]["RESCUE_COUNT"].ToString();
                                        }
                                        //RESCUE_SUCCESS_COUNT				抢救成功次数
                                        if (dt.Rows[i]["RESCUE_SUCCESS_COUNT"].ToString().Trim() != "")
                                        {
                                            txtRESCUE_SUCCESS_COUNT.Text = dt.Rows[i]["RESCUE_SUCCESS_COUNT"].ToString();
                                        }
                                        //ISRESCUE_FINAL_SUCCESS				抢救最终是否成功：○成功；    ○死亡；     ○自动出院
                                        if (dt.Rows[i]["ISRESCUE_FINAL_SUCCESS"].ToString().Trim() != "")       //压疮日
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


                        //ISOPER_PATIENT				是否为手术患者：○否；○急诊手术；○择期手术。
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
                                //ISREOPERATION				是否为术后非计划再次手术 Y 是 N 否
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
                                //ISCOMPLICATIONS				是否有手术后并发症发生 Y 是 N 否
                                if (dt.Rows[i]["ISCOMPLICATIONS"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISCOMPLICATIONS"].ToString() == "Y")
                                    {
                                        radISCOMPLICATIONS_Y.Checked = true;
                                        panelEnabled(radISCOMPLICATIONS_Y.Name);
                                        //PULMONARY_EMBOLISM				肺栓塞
                                        if (dt.Rows[i]["PULMONARY_EMBOLISM"].ToString().Trim() != "")
                                        {
                                            chkPULMONARY_EMBOLISM.Checked = true;
                                        }
                                        //DEEP_VEIN_THROMBOSIS				深静脉栓塞
                                        if (dt.Rows[i]["DEEP_VEIN_THROMBOSIS"].ToString().Trim() != "")
                                        {
                                            chkDEEP_VEIN_THROMBOSIS.Checked = true;
                                        }
                                        //SEPSIS				败血症
                                        if (dt.Rows[i]["SEPSIS"].ToString().Trim() != "")
                                        {
                                            chkSEPSIS.Checked = true;
                                        }
                                        //BLEEDING_OR_HEMATOMA				出血或血肿
                                        if (dt.Rows[i]["BLEEDING_OR_HEMATOMA"].ToString().Trim() != "")
                                        {
                                            chkBLEEDING_OR_HEMATOMA.Checked = true;
                                        }
                                        //WOUND_DEHISCENCE				伤口裂开
                                        if (dt.Rows[i]["WOUND_DEHISCENCE"].ToString().Trim() != "")
                                        {
                                            chkWOUND_DEHISCENCE.Checked = true;
                                        }
                                        //SUDDEN_DEATH				猝死
                                        if (dt.Rows[i]["SUDDEN_DEATH"].ToString().Trim() != "")
                                        {
                                            chkSUDDEN_DEATH.Checked = true;
                                        }
                                        //RESPIRATORY_FAILURE				呼吸衰竭
                                        if (dt.Rows[i]["RESPIRATORY_FAILURE"].ToString().Trim() != "")
                                        {
                                            chkRESPIRATORY_FAILURE.Checked = true;
                                        }
                                        //FRACTURE				骨折
                                        if (dt.Rows[i]["FRACTURE"].ToString().Trim() != "")
                                        {
                                            chkFRACTURE.Checked = true;
                                        }
                                        //PHYSIOLOGIC_DERANGEMENT				生理、代谢紊乱
                                        if (dt.Rows[i]["PHYSIOLOGIC_DERANGEMENT"].ToString().Trim() != "")
                                        {
                                            chkPHYSIOLOGIC_DERANGEMENT.Checked = true;
                                        }
                                        //PULMONARY_INFECTION				肺部感染
                                        if (dt.Rows[i]["PULMONARY_INFECTION"].ToString().Trim() != "")
                                        {
                                            chkPULMONARY_INFECTION.Checked = true;
                                        }
                                        //TRACHEAL_OUT				人工气管意外脱出
                                        if (dt.Rows[i]["TRACHEAL_OUT"].ToString().Trim() != "")
                                        {
                                            chkTRACHEAL_OUT.Checked = true;
                                        }
                                        //OTHER_COMPLICATIONS				其他并发症
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
                                //ISCANCER				是否恶性肿瘤患者 Y 是 N 否
                                if (dt.Rows[i]["ISCANCER"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISCANCER"].ToString() == "Y")
                                    {
                                        radISCANCER_Y.Checked = true;
                                        panelEnabled(radISCANCER_Y.Name);
                                        //ISPATHOLOGY_DIAGNOSIS				与术后病理诊断是否符合 Y 是 N 否
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
                                
                                //ISFROZEN_SECTION				术中是否送快速冰冻切片 Y 是 N 否
                                if (dt.Rows[i]["ISFROZEN_SECTION"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[i]["ISFROZEN_SECTION"].ToString() == "Y")
                                    {
                                        radISFROZEN_SECTION_Y.Checked = true;
                                        panelEnabled(radISFROZEN_SECTION_Y.Name);
                                        //ISPARAFFIN_DIAGNOSIS				与术后石蜡诊断是否符合 Y 是 N 否
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
                                
                                //ISOPER_DIE				是否手术导致死亡： ○否；○手术过程中死亡；○手术后死亡
                                if (dt.Rows[i]["ISOPER_DIE"].ToString().Trim() != "")       //压疮日
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
                                        //DIE_REASON				死亡原因
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
                        //ISDUAL_REFERRAL	CHAR(1)	Y			是否为双向转诊患者：○否； ○上转；○下转
                        //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			转诊的医院（单选）：
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


                                //○冷水滩梧桐社区卫生服务中心；○祁阳县妇幼保健院；○祁阳县黎家坪中心卫生院；
                                //○东安县人民医院；○双牌县人民医院；○江华县第一人民医院
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
                App.MsgErr("操作失败,原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 只允许输入数字和小数点
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
        /// 只允许输入数字
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
            //若为否，则以下选项全部变灰，不须选择
            panelEnabled((sender as RadioButton).Name);
        }

        private void panelEnabled(string radname)
        {

            //是否为两周与一个月内再住院患者：○否 ；○两周内；○两周至一月内。
            if (radname == "radISHAVEIN_LZL" || radname == "radISHAVEIN_YYL")
            {
                plISHAVEIN.Enabled = true;
            }
            else if (radname == "radISHAVEIN_NO")
            {
                txtINHOSPITAL_REASON.Text = "";
                plISHAVEIN.Enabled = false;
            }
            //是否住院危重患者：
            if (radname == "radISCRITICAL_PATIENT_Y" || radname == "radISRESCUE_Y" || radname == "radISRESCUE_N")
            {
                plISCRITICAL_PATIENT.Enabled = true;
                //住院期间是否抢救
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
            {//清空
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

            //是否为手术患者 :○否；○急诊手术；○择期手术。
            if (radname == "radISOPER_PATIENT_JZSS" || radname == "radISOPER_PATIENT_ZQSS" ||
                radname == "radISCOMPLICATIONS_Y" || radname == "radISCOMPLICATIONS_N" ||
                radname == "radISCANCER_Y" || radname == "radISCANCER_N" ||
                radname == "radISFROZEN_SECTION_Y" || radname == "radISFROZEN_SECTION_N" ||
                radname == "radISOPER_DIE_N" || radname == "radISOPER_DIE_SSGCZSW" || radname == "radISOPER_DIE_SSHSW")
            {
                plISOPER_PATIENT.Enabled = true;
                if (radname == "radISCOMPLICATIONS_Y")
                {//是否有手术后并发症发生 Y 是 N 否
                    plISCOMPLICATIONS.Enabled = true;
                }
                else if (radname == "radISCOMPLICATIONS_N")
                {
                    //并发症
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
                    txtOTHER_COMPLICATIONS.Text = "";//其他并发症
                    plISCOMPLICATIONS.Enabled = false;
                }
                if (radname == "radISCANCER_Y")
                {//是否恶性肿瘤患者 Y 是 N 否
                    plISCANCER.Enabled = true;
                }
                else if (radname == "radISCANCER_N")
                {
                    //与术后病理诊断是否符合
                    radISPATHOLOGY_DIAGNOSIS_N.Checked = false;
                    radISPATHOLOGY_DIAGNOSIS_Y.Checked = false;
                    plISCANCER.Enabled = false;
                }
                if (radname == "radISFROZEN_SECTION_Y")
                {//术中是否送快速冰冻切片 Y 是 N 否
                    plISFROZEN_SECTION.Enabled = true;
                }
                else if (radname == "radISFROZEN_SECTION_N")
                {
                    //与术后病理诊断是否符合
                    radISPARAFFIN_DIAGNOSIS_N.Checked = false;
                    radISPARAFFIN_DIAGNOSIS_Y.Checked = false;
                    plISFROZEN_SECTION.Enabled = false;
                }
                if (radname == "radISOPER_DIE_SSGCZSW" || radname == "radISOPER_DIE_SSHSW")
                { //是否手术导致死亡： ○否；○手术过程中死亡；○手术后死亡
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
                //是否为术后非计划再次手术 Y 是 N 否
                radISREOPERATION_N.Checked = false;
                radISREOPERATION_Y.Checked = false;
                //是否有手术后并发症发生 Y 是 N 否
                radISCOMPLICATIONS_N.Checked = false;
                radISCOMPLICATIONS_Y.Checked = false;
                //并发症
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
                txtOTHER_COMPLICATIONS.Text = "";//其他并发症
                //是否恶性肿瘤患者 Y 是 N 否
                radISCANCER_N.Checked = false;
                radISCANCER_Y.Checked = false;
                //与术后病理诊断是否符合 Y 是 N 否
                radISPATHOLOGY_DIAGNOSIS_N.Checked = false;
                radISPATHOLOGY_DIAGNOSIS_Y.Checked = false;
                //术中是否送快速冰冻切片 Y 是 N 否
                radISFROZEN_SECTION_N.Checked = false;
                radISFROZEN_SECTION_Y.Checked = false;
                //与术后石蜡诊断是否符合 Y 是 N 否
                radISPARAFFIN_DIAGNOSIS_N.Checked = false;
                radISPARAFFIN_DIAGNOSIS_Y.Checked = false;
                //是否手术导致死亡： ○否；○手术过程中死亡；○手术后死亡
                radISOPER_DIE_N.Checked = false;
                radISOPER_DIE_SSGCZSW.Checked = false;
                radISOPER_DIE_SSHSW.Checked = false;
                txtDIE_REASON.Text = "";//死亡原因
                //panel
                plISCOMPLICATIONS.Enabled = false;
                plISCANCER.Enabled = false;
                plISFROZEN_SECTION.Enabled = false;
                plISOPER_DIE.Enabled = false;
                plISOPER_PATIENT.Enabled = false;
            }

            //ISDUAL_REFERRAL	CHAR(1)	Y			是否为双向转诊患者：○否； ○上转；○下转
            if (radname == "radISDUAL_REFERRAL_SZ" || radname == "radISDUAL_REFERRAL_XZ")
            {
                plISDUAL_REFERRAL.Enabled = true;
            }
            else if (radname == "radISDUAL_REFERRAL_N")
            {
                //REFERRAL_HOSPITAL	VARCHAR2(20)	Y			转诊的医院（单选）：
                //○冷水滩梧桐社区卫生服务中心；○祁阳县妇幼保健院；○祁阳县黎家坪中心卫生院；
                //○东安县人民医院；○双牌县人民医院；○江华县第一人民医院
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
