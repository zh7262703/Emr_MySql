using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using TempertureEditor.Element;
using System.Data;
using System.Xml;

namespace TempertureEditor.Tempreture_Management
{
    public class tempetureDataComm
    {
        public const string TEMPLATE_NORMAL = "temperature";   //普通模板类型
        public const string TEMPLATE_BABY = "temperature_baby";   //幼儿模板类型
        public const string TEMPLATE_CHILD = "temperature_child";   //儿童模板类型

        #region 体温单通用接口
        /// <summary>
        /// 插入病历中主动生成的操作事件，如：出院、入院、转科等。
        /// </summary>
        /// <param name="tPatInfo">患者信息结构体</param>
        /// <param name="dtEvent">事件时间</param>
        /// <param name="sEventName">事件名称</param>
        /// <param name="templateType">模板类型</param>
        /// <returns>调用成功返回true</returns>
        public static bool InsertAutoOptEvent(InPatientInfo tPatInfo, DateTime dtEvent, string sEventName, string templateType)
        {
            List<string> sqls = new List<string>();
            string ctype = "操作事件";
            if (sEventName == "入院" || sEventName == "出院" || sEventName == "死亡")    //在体温单中只出现一次的事件
            {
                sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and VALTYPE='" + ctype + "' and t_val like'" + sEventName + "%' and template_type='" + templateType + "'");
            }
            else  //在体温单中,可出现多次的事件
            {
                sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and VALTYPE='" + ctype + "' and t_val like'" + sEventName + "%' and VALTYPE_TIME=to_date('" + dtEvent.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and template_type='" + templateType + "'");
            }
            DateTime SelectTime = tempetureDataComm.GetInsertDateTime(dtEvent, templateType);
            string l_val = tempetureDataComm.ConvertOptEventToDBString(dtEvent, sEventName);
            sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, dtEvent, templateType, "", ctype));
            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 更新病历中主动生成的操作事件，如：出院、入院、转科等。
        /// (如果是添加事件，dtOldEvent，dtNewEvent取相同值就可以)
        /// </summary>
        /// <param name="tPatInfo">患者信息结构体</param>
        /// <param name="sEventName">事件名称</param>
        /// <param name="dtNewEvent">事件新时间点</param>
        /// <param name="dtOldEvent">事件旧时间</param>
        /// <param name="templateType">模板类型</param>
        /// <returns>调用成功返回true</returns>
        public static bool UpdateAutoOptEvent(InPatientInfo tPatInfo, string sEventName, DateTime dtNewEvent, DateTime dtOldEvent, string templateType)
        {
            List<string> sqls = new List<string>();
            string ctype = "操作事件";
            if (sEventName == "入院" || sEventName == "出院" || sEventName == "死亡")    //在体温单中只出现一次的事件
            {
                sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and VALTYPE='" + ctype + "' and t_val like'" + sEventName + "%' and template_type='" + templateType + "'");
            }
            else  //在体温单中,可出现多次的事件
            {
                sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                     " and VALTYPE='" + ctype + "' and t_val like'" + sEventName + "%' and VALTYPE_TIME=to_date('" + dtNewEvent.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and template_type='" + templateType + "'");
                sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                    " and VALTYPE='" + ctype + "' and t_val like'" + sEventName + "%' and VALTYPE_TIME=to_date('" + dtOldEvent.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and template_type='" + templateType + "'");
            }
            DateTime SelectTime = tempetureDataComm.GetInsertDateTime(dtNewEvent, templateType);
            string l_val = tempetureDataComm.ConvertOptEventToDBString(dtNewEvent, sEventName);
            sqls.Add(tempetureDataComm.GetInsertSql(tPatInfo, SelectTime, ctype, l_val, dtNewEvent, templateType, "", ctype));
            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 插入病历中主动生成的体温单数据。（测量时间存在时，在该时间点上对原数据更新）
        /// </summary>
        /// <param name="tPatInfo">患者信息结构体</param>
        /// <param name="dtStartMeasure">测量开始时间(精确到分)</param>
        /// <param name="dtEndMeasure">测量结束时间(单点数据，结束时间传入开始时间，精确到分)</param>
        /// <param name="ctype">数据类型（如，体重、血压、体温等）</param>
        /// <param name="l_val">测量值</param>
        /// <param name="templateType">模板类型</param>
        /// <param name="measureRemark">测量备注（辅助，短绌，复测）</param>
        /// <param name="valCategory">数据类型所属大类</param>
        /// <returns>调用成功返回true</returns>
        public static bool InsertTemperatureData(InPatientInfo tPatInfo, DateTime dtStartMeasure, DateTime dtEndMeasure, string ctype, string l_val, string templateType, string measureRemark, string valCategory)
        {

            List<string> sqls = new List<string>();

            List<string> listCtypes = new List<string>();

            GetTemperatureDataTypeTemplate(templateType, ref listCtypes);

            if (!listCtypes.Contains(ctype))
            {
                //thorw("未知数据类型！");
                return false;
            }

            sqls.Add("delete from t_temperature_record where patient_id=" + tPatInfo.Id.ToString() +
                   " and VALTYPE='" + ctype + "' and template_type='" + templateType + "' and  MEASURE_TIME=to_date('" + dtStartMeasure.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')");

            sqls.Add(GetInsertSql(tPatInfo, dtStartMeasure, ctype, l_val, dtEndMeasure, templateType, measureRemark, valCategory));
            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 通过模板类型，获取模板文件名称
        /// </summary>
        /// <param name="templateType">模板类型</param>
        /// <returns></returns>
        /// 
        public static string GetTemplateFileByType(string templateType)
        {
            string tmbXmlFile;
            if (templateType == tempetureDataComm.TEMPLATE_NORMAL)
                tmbXmlFile = "TempertureSet_newTable.tmb";
            else if (templateType == tempetureDataComm.TEMPLATE_BABY)
                tmbXmlFile = "TempertureSet_newTable_baby.tmb";
            else if (templateType == tempetureDataComm.TEMPLATE_CHILD)
                tmbXmlFile = "TempertureSet_newTable_child.tmb";
            else
                tmbXmlFile = "";
            return tmbXmlFile;
        }

        /// <summary>
        /// 通过模板类型，获取对应模板文件内体温单数据类型
        /// </summary>
        /// <param name="templateType">模板类型</param>
        /// <returns></returns>
        /// 
        public static void GetTemperatureDataTypeTemplate(string templateType, ref List<string> listDataTypes)
        {
            XmlDocument XmlDoc = new XmlDocument();

            string templateFile = GetTemplateFileByType(templateType);

            if (templateType == "")
            {
                //throw ("模板类型无法识别！");
                return;

            }
            string xmlFile = App.SysPath + "\\" + templateFile;

            XmlDoc.Load(xmlFile);

            string ctype = "";

            XmlNodeList listLineDataNodes = XmlDoc.GetElementsByTagName("ClsLinedata");

            //画线设置
            foreach (XmlNode tempxmlnode in listLineDataNodes)
            {
                ctype = tempxmlnode.Attributes["Name"].Value;

                if (ctype.Trim() != "")
                {
                    listDataTypes.Add(ctype);
                }
            }

            XmlNodeList listTextDataNodes = XmlDoc.GetElementsByTagName("ClsTextdata");

            foreach (XmlNode tempxmlnode in listTextDataNodes)
            {
                ctype = tempxmlnode.Attributes["Name"].Value;
                if (ctype.Trim() != "")
                {
                    listDataTypes.Add(ctype);
                }
            }

        }

        /// <summary>
        /// 初始化病人信息
        /// </summary>
        /// <param name="row">当前行</param>
        /// <returns>病人对象</returns>
        private static InPatientInfo InitPatient(DataRow row)
        {
            DataSet DS_AREA = null; ;
            DataSet DS_CODE = App.GetDataSet("select * from t_data_code where type in (53,70,71,134,132,130)");
            InPatientInfo inpatient = new InPatientInfo();
            
            inpatient.Id = 0;
            inpatient.Patient_Name = "";
            inpatient.Gender_Code = "";
            inpatient.Birthday = "";
            inpatient.PId = "";
            inpatient.Age = "";
            inpatient.Action_State = "";
            inpatient.Age_unit = "";
            inpatient.Sick_Degree = "";
            inpatient.Nurse_Level = "";
            
            try
            {

                DataRow[] codesrows = null;
                //婚姻
                codesrows = DS_CODE.Tables[0].Select("type='132' and code='" + row["Marriage_State"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Marrige_State = codesrows[0]["name"].ToString();
                else
                    inpatient.Marrige_State = row["Marriage_State"].ToString();
                //籍贯 查不到默认北京市
                //if (ds_code_type == null)
                //    ds_code_type = App.GetDataSet("select * from t_data_code_type");
                //codesrows = ds_code_type.Tables[0].Select("type='" + row["native_place"].ToString() + "'");
                //if (codesrows.Length > 0)
                //    inpatient.Natiye_place = codesrows[0]["name"].ToString();
                //else
                //    inpatient.Natiye_place = "北京市";//row["native_place"].ToString();
                if (DS_AREA != null)
                {
                    if (row["native_place"].ToString() != "")
                    {
                        inpatient.Natiye_place = row["native_place"].ToString();
                    }
                    else
                    {
                        inpatient.Natiye_place = "";
                    }
                }

                //民族

                codesrows = DS_CODE.Tables[0].Select("type='71' and code='" + row["Folk_Code"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Folk_code = codesrows[0]["name"].ToString();
                else
                    inpatient.Folk_code = row["Folk_Code"].ToString();
                //职业

                codesrows = DS_CODE.Tables[0].Select("type='134' and code='" + row["Career"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Career = codesrows[0]["name"].ToString();
                else
                    inpatient.Career = row["Career"].ToString();

                inpatient.Career_other = row["career_other"].ToString();
                //病人性质
                codesrows = DS_CODE.Tables[0].Select("type='70' and code='" + row["Pay_Manner"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Pay_Manager = codesrows[0]["name"].ToString();
                else
                    inpatient.Pay_Manager = row["Pay_Manner"].ToString();
            }
            catch (Exception ex)
            {
                //App.Msg(ex.Message);
            }
            try
            {
                inpatient.Now_address = row["now_address"].ToString();
                inpatient.Now_addres_phone = row["now_addres_phone"].ToString();
                inpatient.Country = row["country"].ToString();
                inpatient.Medicare_no = row["Medicare_NO"].ToString();
                inpatient.Home_address = row["Home_Address"].ToString();
                inpatient.HomePostal_code = row["Homepostal_Code"].ToString();
                inpatient.Home_phone = row["Home_Phone"].ToString();
                inpatient.Office = row["Office"].ToString();
                inpatient.Office_address = row["Office_Address"].ToString();
                inpatient.Office_phone = row["Office_Phone"].ToString();
                inpatient.Relation = row["Relation"].ToString();
                inpatient.Relation_name = row["Relation_Name"].ToString();
                inpatient.Relation_address = row["Relation_Address"].ToString();
                inpatient.Relation_phone = row["Relation_Phone"].ToString();
                inpatient.RelationPos_code = row["RelationPOS_Code"].ToString();
                inpatient.OfficePos_code = row["OfficePOS_Code"].ToString();
                if (row["InHospital_Count"].ToString() != "")
                    inpatient.InHospital_count = Convert.ToInt32(row["InHospital_Count"].ToString());
                inpatient.Cert_Id = row["CERT_ID"].ToString();
                inpatient.Out_Id = row["out_id"].ToString();
                inpatient.In_Circs = row["IN_Circs"].ToString();
                inpatient.Birth_place = row["Birth_Place"].ToString();
                inpatient.Id = Int32.Parse(row["id"].ToString());
                inpatient.Patient_Name = row["patient_name"].ToString();
                inpatient.Gender_Code = row["gender_code"].ToString();
                inpatient.Birthday = row["birthday"].ToString();
                inpatient.PId = row["pid"].ToString();
                if (row["insection_id"].ToString() != "")
                    inpatient.Insection_Id = Convert.ToInt32(row["insection_id"]);
                inpatient.Insection_Name = row["insection_name"].ToString();
                inpatient.In_Area_Id = row["in_area_id"].ToString();
                inpatient.In_Area_Name = row["in_area_name"].ToString();
                //计算年龄和单位
                int year = 0, month, day;
                if (row["age"].ToString() != "")
                {
                    inpatient.Age = row["age"].ToString();
                }
                else
                {
                    //GetAgeByBirthday(Convert.ToDateTime(inpatient.Birthday), App.GetSystemTime(), out year, out month, out day);
                    if (year != 0)
                    {
                        inpatient.Age = year.ToString();
                        inpatient.Age_unit = "岁";
                    }
                    //else if (year == 0 && month != 0)
                    //{
                    //    inpatient.Age = month.ToString();
                    //    inpatient.Age_unit = "月";
                    //}
                    //else if (year == 0 && month == 0)
                    //{
                    //    inpatient.Age = day.ToString();
                    //    inpatient.Age_unit = "天";
                    //}
                }
                if (row["age_unit"].ToString() == "")
                {
                    inpatient.Age_unit = "岁";
                }
                else
                {
                    inpatient.Age_unit = row["age_unit"].ToString();
                }
                try
                {
                    inpatient.Child_age = row["child_age"].ToString();
                }
                catch (Exception) { }
                //inpatient.Action_State = row["action_state"].ToString();
                inpatient.Sick_Doctor_Id = row["sick_doctor_id"].ToString();
                inpatient.Sick_Doctor_Name = row["sick_doctor_name"].ToString();
                if (row["sick_area_id"].ToString() != "")
                    inpatient.Sike_Area_Id = row["sick_area_id"].ToString();
                inpatient.Sick_Area_Name = row["sick_area_name"].ToString();
                if (row["section_id"].ToString() != "")
                    inpatient.Section_Id = Int32.Parse(row["section_id"].ToString());
                inpatient.Section_Name = row["section_name"].ToString();
                if (row["in_time"] != null)
                    inpatient.In_Time = DateTime.Parse(row["in_time"].ToString());
                inpatient.State = row["state"].ToString();
                if (row["sick_bed_id"].ToString() != "")
                    inpatient.Sick_Bed_Id = Int32.Parse(row["sick_bed_id"].ToString());
                inpatient.Sick_Bed_Name = row["sick_bed_no"].ToString();


                inpatient.Sick_Degree = Convert.ToString(row["Sick_Degree"]);
                inpatient.Nurse_Level = Convert.ToString(row["Nurse_Level"]);
                if (row["Die_flag"].ToString() != "")
                    inpatient.Die_flag = Convert.ToInt32(row["Die_flag"]);
                if (row["die_time"].ToString() != "")
                {
                    inpatient.Die_time = Convert.ToDateTime(row["die_time"]);
                }
                if (row["Sick_Group_Id"].ToString() != "")
                    inpatient.Sick_Group_Id = Convert.ToInt32(row["Sick_Group_Id"]);
                inpatient.Card_Id = row["card_id"].ToString();

                inpatient.Patient_Id = row["patient_Id"].ToString();
                if (row["PROPERTY_FLAG"] != null)
                    inpatient.Property_flag = row["PROPERTY_FLAG"].ToString();
                if (row["CAREER_OTHER"] != null)
                    inpatient.Property_flag = row["CAREER_OTHER"].ToString();
                inpatient.Sick_doc_no = row["SICK_DOC_NO"].ToString();

                inpatient.His_id = row["his_id"].ToString();

                //袁杨添加  责任护士 151125 
                //if (row["zrhs"].ToString() != "")
                //{
                //    inpatient.ZRHS = row["zrhs"].ToString();
                //}
                //if (row["zrhsname"].ToString() != "")
                //{
                //    inpatient.ZRHSNAME = row["zrhsname"].ToString();
                //}
                if (row["exe_document_time"] != null)
                {
                    inpatient.Exe_document_time = row["exe_document_time"].ToString();
                }
                try
                {
                    if (row["document_state"] != null)
                        inpatient.Document_State = row["document_state"].ToString();
                }
                catch (System.Exception ex)
                {

                }

            }
            catch (System.Exception ex)
            {
                //App.Msg(ex.Message);
            }
            return inpatient;
        }
        /// <summary>
        /// 根据病人id得到病人信息
        /// </summary>
        /// <param name="patientid">病人id</param>
        /// <returns>InPatientInfo对象</returns>
        public static InPatientInfo GetInpatientInfoByPid(string patientid)
        {
            string SqlByPId = "select t1.* from t_in_patient t1 where t1.id ='" + patientid + "'";
            InPatientInfo inpatient = null;
            DataSet ds = App.GetDataSet(SqlByPId);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    inpatient = InitPatient(dt.Rows[0]);
                }
            }
            return inpatient;
        }

        /// <summary>
        /// 根据模板类型，获取体温单的录入时间点(必须从小到大设置时间点)
        /// </summary>
        /// <returns>录入时间</returns>
        public static string[] GetTemperatureWriteTime(string templateType)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(App.SysPath + "\\" + GetTemplateFileByType(templateType));

            //初始化树节点
            string[] times = null;

            foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsWriteTimes"))
            {
                times = tempxmlnode.InnerText.Split(',');
            }

            return times;
        }

        ///<summary>
        ///　根据模板类型,生成插入时间
        /// </summary>
        public static DateTime GetInsertDateTime(DateTime dt, string templateType)
        {
            string[] times = GetTemperatureWriteTime(templateType);
            DateTime dtReturn = GetInsertTimeFromRange(dt, times, templateType);
            
            return dtReturn;
        }


        /// 将数字时间转中文时间
        /// <summary>
        /// 将阿拉伯数字转换为中文简体
        /// </summary>
        /// <param name="time">HH:mm</param>
        /// <returns></returns>
        public static string ConvertText(string time)
        {
            string[] stringArr = time.Split(':');
            if (stringArr.Length > 1)
            {
                int temperHour = Convert.ToInt32(stringArr[0]);
                int temperMinute = Convert.ToInt32(stringArr[1]);
                if (temperMinute == 00)
                {
                    return NumForChinese(temperHour, 0) + "时";
                }
                else
                {
                    return NumForChinese(temperHour, 0) + "时" + NumForChinese(temperMinute, 1) + "分";
                }
            }
            return "";
        }

        public static string NumForChinese(int number, int type)
        {
            string returnTime = "";
            if (number < 10)
            {
                if (type == 1)
                {
                    returnTime = "零";
                }
                if (number == 0)
                {
                    returnTime = "零";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "一";
                            break;
                        case 2:
                            returnTime += "二";
                            break;
                        case 3:
                            returnTime += "三";
                            break;
                        case 4:
                            returnTime += "四";
                            break;
                        case 5:
                            returnTime += "五";
                            break;
                        case 6:
                            returnTime += "六";
                            break;
                        case 7:
                            returnTime += "七";
                            break;
                        case 8:
                            returnTime += "八";
                            break;
                        case 9:
                            returnTime += "九";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "十";
                        break;
                    case 2:
                        returnTime = "二十";
                        break;
                    case 3:
                        returnTime = "三十";
                        break;
                    case 4:
                        returnTime = "四十";
                        break;
                    case 5:
                        returnTime = "五十";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "一";
                        break;
                    case 2:
                        returnTime += "二";
                        break;
                    case 3:
                        returnTime += "三";
                        break;
                    case 4:
                        returnTime += "四";
                        break;
                    case 5:
                        returnTime += "五";
                        break;
                    case 6:
                        returnTime += "六";
                        break;
                    case 7:
                        returnTime += "七";
                        break;
                    case 8:
                        returnTime += "八";
                        break;
                    case 9:
                        returnTime += "九";
                        break;
                }
            }
            return returnTime;
        }

        /// <summary>
        /// 获取插入字符串
        /// </summary>
        /// <param name="inPat">患者信息</param>
        /// <param name="SelectTime">测量时间</param>
        /// <param name="cctype"></param>
        /// <param name="cval"></param>
        /// <param name="cctypeTime">类型时间</param>
        /// <param name="template">模板类型</param>
        /// <returns></returns>

        public static string GetInsertSql(int Id, string Sick_Bed_Name,  string Sick_Area_Name, string Section_Name, DateTime SelectTime, string cctype, string cval, DateTime cctypeTime, string template, string operateUserId)
        {
            string sql = "insert into t_temperature_record(SICK_BED_NAME,SICK_AREA_NAME,SECTION_NAME,TEMPLATE_TYPE,MEASURE_TIME,T_VAL,VALTYPE,PATIENT_ID, VALTYPE_TIME, OPERATE_TIME, OPERATE_USERID)values('" +
                 Sick_Bed_Name + "','" + Sick_Area_Name + "','" + Section_Name + "','" + template + "',to_date('" +
                SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + cval + "','" + cctype + "','" + Id + "'," +
                "to_date('" + cctypeTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')," +
                "to_date('" + App.GetSystemTime().ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + operateUserId + "')";
            return sql;
        }
        /*
        /// <summary>
        /// 生成数据表t_temperature_record插入语句
        /// </summary>
        /// <param name="inPat"></param>
        /// <param name="SelectTime"></param>
        /// <param name="cctype"></param>
        /// <param name="cval"></param>
        /// <param name="cctypeTime"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static string GetInsertSql(InPatientInfo inPat, DateTime SelectTime, string cctype, string cval, DateTime cctypeTime, string template)
        {
            string operateUserId = "";
            if (inPat.User_Id != null)
            {
                operateUserId = inPat.User_Id;
            }
            string sql = "insert into t_temperature_record(SICK_BED_NAME,SICK_AREA_NAME,SECTION_NAME,TEMPLATE_TYPE,MEASURE_TIME,T_VAL,VALTYPE,PATIENT_ID, VALTYPE_TIME, OPERATE_TIME, OPERATE_USERID, MEASURE_REMARK, VALCATEGORY)values('" +
                 inPat.Sick_Bed_Name + "','" + inPat.Sick_Area_Name + "','" + inPat.Section_Name + "','" + template + "',to_date('" +
                SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + cval + "','" + cctype + "','" + inPat.Id + "'," +
                "to_date('" + cctypeTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')," +
                "to_date('" + App.GetSystemTime().ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + operateUserId + "')";
            return sql;
        }
        */
        /// <summary>
        /// 生成数据表t_temperature_record插入语句
        /// </summary>
        /// <param name="inPat"></param>
        /// <param name="SelectTime"></param>
        /// <param name="cctype"></param>
        /// <param name="cval"></param>
        /// <param name="cctypeTime"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public static string GetInsertSql(InPatientInfo inPat, DateTime SelectTime, string cctype, string cval, DateTime cctypeTime, string template, string measureRemark, string valCategory)
        {
            string operateUserId = "";
            if (inPat.User_Id != null)
            {
                operateUserId = inPat.User_Id;
            }
            string sql = "insert into t_temperature_record(SICK_BED_NAME,SICK_AREA_NAME,SECTION_NAME,TEMPLATE_TYPE,MEASURE_TIME,T_VAL,VALTYPE,PATIENT_ID, VALTYPE_TIME, OPERATE_TIME, OPERATE_USERID, MEASURE_REMARK, VALCATEGORY)values('" +
                 inPat.Sick_Bed_Name + "','" + inPat.Sick_Area_Name + "','" + inPat.Section_Name + "','" + template + "',to_date('" +
                SelectTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + cval + "','" + cctype + "','" + inPat.Id + "'," +
                "to_date('" + cctypeTime.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')," +
                "to_date('" + App.GetSystemTime().ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi'),'" + operateUserId + "','" +
                measureRemark + "','" + valCategory + "')";
            return sql;
        }

        ///<summary>
        ///　根据时间范围，自动生成插入时间
        ///　注意：times需为由小到大的有序队列
        /// </summary>
        public static DateTime GetInsertTimeFromRange(DateTime dt, string[] times, string templateType)
        {
            DateTime dtMeasure;
            DateTime dtLow = new DateTime();
            DateTime dtUpper = new DateTime();

            for (int i = 0; i < times.Length; i++)
            {
                string text = times[i];
                if (text == "24:00")
                    text = "00:00";
                dtMeasure = Convert.ToDateTime(dt.ToString("yyyy-MM-dd ") + text);

                if (tempetureDataComm.GetDateTimeRangeByMeasure(dtMeasure, dt, ref dtLow, ref dtUpper, templateType))
                {
                    return dtMeasure;
                }
            }
            return dtUpper;//返回跨天时间点24:00为第二天时间， 取最大值

        }
        /// <summary>
        /// 根据规则生成操作事件数据库存储字符串
        /// </summary>
        /// <param name="dtEvent">事件时间</param>
        /// <param name="sEventName">事件名称</param>
        /// <returns>按规则生成后的字符串</returns>
        public static string ConvertOptEventToDBString(DateTime dtEvent, string sEventName)
        {
            string optEvent = sEventName + "_" + dtEvent.ToString("HH:mm");
            return optEvent;
        }
        ///<summary>
        /// 生成尿量数据库存储格式(入院| |2|h| |1200|/|C|F|)
        /// <param name="sUrineAmount">尿量</param>
        /// <param name="bInHospital">入院</param>
        /// <param name="bOperation">术后</param>
        /// <param name="sUrineHour">(入院或术后)小时</param>
        /// <param name="bExportUrine">导尿</param>
        /// <param name="bPGZL">膀胱造瘘</param>
        /// </summary>
        public static string ConvertUrineAmountToDBString(string sUrineAmount, bool bInHospital, bool bOperation, string sUrineHour, bool bExportUrine, bool bPGZL)
        {

            //尿量返回值
            string Urine_amount = "";
            if (sUrineAmount != "")
            {
                //尿量采集节点(入院/术后)
                if (bInHospital)
                {
                    Urine_amount += "入院| ";
                }
                else if (bOperation)
                {
                    Urine_amount += "术后| ";
                }
                else
                {
                    Urine_amount += "|";
                }

                Urine_amount += "|";

                //尿量采集后小时
                if (sUrineHour != "" && (bInHospital || bOperation))
                {
                    Urine_amount += sUrineHour + "|" + "h|";
                }
                else
                {
                    Urine_amount += "||";
                }

                if (Urine_amount.Length > 4)
                    Urine_amount += " |";
                else
                {
                    Urine_amount += "|";
                }

                Urine_amount += sUrineAmount;

                Urine_amount += "|";
                Urine_amount += "/";
                Urine_amount += "|";

                //导尿
                if (bExportUrine)
                {
                    Urine_amount += "C";
                }

                Urine_amount += "|";
                //膀胱造瘘
                if (bPGZL)
                {
                    Urine_amount += "F";
                }
                Urine_amount += "|";
            }
            return Urine_amount;
        }

        ///<summary>
        /// 生成尿量数据库存储格式(入院| |2|h| |1200|/|C|F|)
        /// <param name="sUrineAmount">尿量</param>
        /// </summary>
        public static string ConvertUrineAmountToDBString(string sUrineAmount)
        {
            return ConvertUrineAmountToDBString(sUrineAmount, false, false, "", false, false);
        }

        ///<summary>
        /// 从尿量数据库存储字符串中提取尿量数值, 存储格式－(入院| |2|h| |1200|/|C|F|)
        /// <param name="sDBString">尿量</param>
        /// </summary>
        public static string GetUrineAmountFromDBString(string sDBString)
        {
            string sUrineAmount = "";

            if (sDBString != "")
            {
                //                 0|1|2|3|4|5   |6|7|8|
                //数据组织方式：入院| |2|h| |1200|/|C|F|
                string[] strs = sDBString.Split('|');
                if (strs.Length > 5)
                    sUrineAmount = strs[5];
            }
            return sUrineAmount;
        }

        /// <summary>
        /// 根据事件时间，获取测量时间有效上限值、下限值
        /// 返回值：ture-表示dtEvent在测量时间点有效范围内
        /// </summary>
        /// <param name="dtMeasure">测量时间点</param>
        /// <param name="dtEvent">事件时间</param>
        /// <param name="dtLower">下限值</param>
        /// <param name="dtUpper">上限值</param>
        /// <returns></returns>
        public static bool GetDateTimeRangeByMeasure(DateTime dtMeasure, DateTime dtEvent, ref DateTime dtLower, ref DateTime dtUpper, string templateType)
        {

            //精确到分
            TimeSpan tsPlus, tsMinus;
            if (templateType == TEMPLATE_NORMAL || templateType == TEMPLATE_CHILD)
            {
                if (dtMeasure.Hour == 4)
                {
                    tsPlus = new TimeSpan(1, 59, 0);
                    tsMinus = new TimeSpan(4, 0, 0);
                }
                else if (dtMeasure.Hour == 0)
                {
                    tsPlus = new TimeSpan(23, 59, 0);
                    tsMinus = new TimeSpan(-22, 0, 0);
                }
                else
                {
                    tsPlus = new TimeSpan(1, 59, 0);
                    tsMinus = new TimeSpan(2, 0, 0);
                }
            }
            else
            {
                return false;
            }
            dtUpper = dtMeasure + tsPlus;
            dtLower = dtMeasure - tsMinus;


            //精确到分
            //dtEvent = dtEvent - new TimeSpan(0, 0, 0, dtEvent.Second, dtEvent.Millisecond); //此种方法精确到分,通过<=或>=比较有问题
            dtEvent = Convert.ToDateTime(dtEvent.ToString("yyyy-MM-dd HH:mm"));
            dtUpper = Convert.ToDateTime(dtUpper.ToString("yyyy-MM-dd HH:mm"));
            dtLower = Convert.ToDateTime(dtLower.ToString("yyyy-MM-dd HH:mm"));


            if (dtEvent >= dtLower && dtEvent <= dtUpper)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 打印普通体温单日期、手术后天数、时间点、
        /// </summary>
        private static void printTime(InPatientInfo inPat, ref Page currentPage, DateTime? outTime, string template, ref Comm cm)
        {
            
            string in_date = inPat.In_Time.ToString("yyyy-MM-dd HH:mm");
            DateTime dtStart = Convert.ToDateTime(currentPage.Starttime);
            string dateString = "";
            DataSet dtSurgery = null;
            DateTime systime = App.GetSystemTime();
            //手术记录和分娩记录集合
            if (dtSurgery == null)
            {
                string sql = string.Format("select * from t_temperature_record t where t.valtype='操作事件' and t.t_val like '%手术%' and t.patient_id='{0}' and to_char(MEASURE_TIME,'yyyy-MM-dd') BETWEEN '{1}' AND '{2}' and t.template_type = '{3}' ORDER BY MEASURE_TIME", 
                                            inPat.Id.ToString(), DateTime.Parse(in_date).ToString("yyyy-MM-dd"), DateTime.Parse(currentPage.Endtime).ToString("yyyy-MM-dd"), template);

                dtSurgery = App.GetDataSet(sql);
              
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime oldTime = dtStart;     //下个时间
                if ( outTime != null && (outTime < (i == 0 ? dtStart : dtStart.AddDays(1))) || (i == 0 ? dtStart > systime : dtStart.AddDays(1) > systime))
                {
                    return;
                }
                if (i == 0)
                {
                    dateString = oldTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    oldTime = dtStart.AddDays(1);
                    if (oldTime.Month != dtStart.Month)
                    {
                        if (oldTime.Year != dtStart.Year)
                        {
                            dateString = oldTime.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dateString = oldTime.ToString("MM-dd");
                        }
                    }
                    else
                    {
                        dateString = oldTime.ToString("dd");
                    }
                    dtStart = oldTime;
                }
                //体温单天数
                ClsDataObj tojbdt = new ClsDataObj(cm);             
                tojbdt.Val = dateString;
                tojbdt.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                tojbdt.Typename = "日期";
                tojbdt.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tojbdt);

                /***
                 * 手术后天数
                 */
                if (dtSurgery != null && dtSurgery.Tables[0] != null && dtSurgery.Tables[0].Rows.Count > 0)
                {
                    if (DateTime.Compare(dtStart, dtStart.AddDays(i)) < 1)
                    {
                        string surgeryDays = "";
                        for (int j = 0; j < dtSurgery.Tables[0].Rows.Count; j++)
                        {
                            DateTime dttimeRos = Convert.ToDateTime(Convert.ToDateTime(dtSurgery.Tables[0].Rows[j]["measure_time"]).ToString("yyyy-MM-dd"));//手术分娩事件行
                            TimeSpan abject = oldTime - dttimeRos; //
                            if (abject.Days >= 0 && abject.Days <= 14 && DateTime.Compare(dtStart, dttimeRos) >= 0)
                            {
                                string[] surgerys = dtSurgery.Tables[0].Rows[j]["t_val"].ToString().Split('|');
                                foreach (string surgeryStr in surgerys)
                                {
                                    string surgery = "";
                                    if (surgeryStr.Contains("手术") || surgeryStr.Contains("分娩"))
                                    {
                                        surgery = "";// surgeryStr.Contains("手术") ? "手术" : "分娩";

                                        if (abject.Days.ToString() == "0")
                                        {

                                            if (j > 0)
                                                surgeryDays = surgeryDays + "/" + "术" + (j+1).ToString();

                                            else
                                                surgeryDays = "术日";//I

                                        }
                                        else
                                        {
                                            if (surgeryDays != "")
                                                surgeryDays = surgeryDays + "/" + abject.Days.ToString();
                                            else
                                                surgeryDays = abject.Days.ToString();
                                        }
                                    }
                                }
                            }
                        }

                        if (surgeryDays.Length > 0 && cm.GetVDataSetByName("手术天数") != null)
                        {
                            //体温单天数
                            ClsDataObj tojbOper = new ClsDataObj(cm);                       
                            tojbOper.Val = surgeryDays;
                            tojbOper.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                            tojbOper.Typename = "手术天数";
                            tojbOper.setdataxy(currentPage.Starttime);
                            currentPage.Objs.Add(tojbOper);

                        }
                    }
                }
                
                //住院天数
                TimeSpan tsp = new TimeSpan();
                if (cm.GetVDataSetByName("住院天数") != null && dtStart != null && in_date != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(in_date).ToString("yyyy-MM-dd"));
                    int Days = tsp.Days + 1;

                    //体温单天数
                    ClsDataObj tojbDay = new ClsDataObj(cm);
                    tojbDay.Val = Days.ToString();
                    tojbDay.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                    tojbDay.Typename = "住院天数";
                    tojbDay.setdataxy(currentPage.Starttime);
                    currentPage.Objs.Add(tojbDay);
                }

                //生后日数
                if (cm.GetVDataSetByName("生后日数") != null && dtStart != null && inPat.Birthday != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(inPat.Birthday).ToString("yyyy-MM-dd"));
                    if (tsp.Days >= 0)
                    {
                        //体温单天数
                        ClsDataObj tojbDay = new ClsDataObj(cm);
                        if (tsp.Days == 0)
                            tojbDay.Val = "生日";
                        else
                            tojbDay.Val = tsp.Days.ToString();
                        tojbDay.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                        tojbDay.Typename = "生后日数";
                        tojbDay.setdataxy(currentPage.Starttime);
                        currentPage.Objs.Add(tojbDay);
                    }
                }

            }
        }

        #endregion

        #region 体温单各模块兼容接口
        /// <summary>
        /// 获取页信息内容
        /// </summary>
        /// <param name="inPat">患者基本信息</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="indexPage">页码</param>
        public static void GetPageContentByPageObj(InPatientInfo inPat, ref Page currentPage, string indexPage, DateTime? dtOutHospital, ref Comm cm, string templateType)
        {
            if (templateType == tempetureDataComm.TEMPLATE_NORMAL)
            {
                GetPageContentByPageObj(inPat, ref currentPage, indexPage, dtOutHospital, ref cm);
            }
            else if (templateType == tempetureDataComm.TEMPLATE_CHILD)
            {
                GetPageContentByPageObj_child(inPat, ref currentPage, indexPage, dtOutHospital, ref cm);
            }
        }
        #endregion
        #region 普通体温单
        /// <summary>
        /// 获取页信息内容(普通体温单)
        /// </summary>
        /// <param name="inPat">患者基本信息</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="indexPage">页码</param>
        public static void GetPageContentByPageObj(InPatientInfo inPat, ref Page currentPage, string indexPage, DateTime? dtOutHospital, ref Comm cm)
        {
            string startTime = Convert.ToDateTime(currentPage.Starttime).ToString("yyyy-MM-dd HH:mm");
            string endTime = Convert.ToDateTime(currentPage.Endtime).ToString("yyyy-MM-dd HH:mm");
          
            try
            {
                DataSet ds = new DataSet();
                string sql = "select * from t_temperature_record aa where " +
                             "aa.measure_time between to_date('{0}','yyyy-MM-dd hh24:mi') and " +
                             "to_date('{1}','yyyy-MM-dd hh24:mi') and patient_id={2} and template_type='{3}' order by aa.VALTYPE_TIME asc";

                sql = String.Format(sql, startTime, endTime, inPat.Id, TEMPLATE_NORMAL);
                ds = App.GetDataSet(sql);

                if (currentPage.Objs == null)
                    currentPage.Objs = new List<ClsDataObj>();
                else
                    currentPage.Objs.Clear();

                #region 组织数据
                //基本信息
                ClsDataObj tempobj_name = new ClsDataObj(cm);
                tempobj_name.Typename = "姓名";
                tempobj_name.Rdatatime = "";
                tempobj_name.Val = inPat.Patient_Name;
                tempobj_name.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_name);


                ClsDataObj tempobj_sex = new ClsDataObj(cm);
                tempobj_sex.Typename = "性别";
                tempobj_sex.Rdatatime = "";
                if (inPat.Gender_Code == "0")
                    tempobj_sex.Val = "男";
                else if (inPat.Gender_Code == "1")
                    tempobj_sex.Val = "女";
                else
                    tempobj_sex.Val = "";
                tempobj_sex.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_sex);

                ClsDataObj tempobj_age = new ClsDataObj(cm);
                tempobj_age.Typename = "年龄";    
                tempobj_age.Rdatatime = "";
                tempobj_age.Val = inPat.Age;
                tempobj_age.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_age);

                ClsDataObj tempobj_pid = new ClsDataObj(cm);
                tempobj_pid.Typename = "住院号";
                tempobj_pid.Rdatatime = "";
                tempobj_pid.Val = inPat.PId;
                tempobj_pid.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_pid);

                ClsDataObj tempobj_intime = new ClsDataObj(cm);
                tempobj_intime.Typename = "入院时间";
                tempobj_intime.Rdatatime = "";
                tempobj_intime.Val = inPat.In_Time.ToString("yyyy-MM-dd");
                tempobj_intime.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_intime);

                ClsDataObj tempobj_page = new ClsDataObj(cm);
                tempobj_page.Typename = "页码";
                tempobj_page.Rdatatime = "";
                tempobj_page.Val = indexPage;
                tempobj_page.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_page);

                //特殊处理－可变的患者基本信息
                ClsDataObj tempobj_bed = new ClsDataObj(cm);
                tempobj_bed.Typename = "床位";
                tempobj_bed.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_bed.Val = ds.Tables[0].Rows[0]["SICK_BED_NAME"].ToString();
                else
                    tempobj_bed.Val = inPat.Sick_Bed_Name;
                tempobj_bed.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_bed.Typename) != null)
                    currentPage.Objs.Add(tempobj_bed);
                /*
                ClsDataObj tempobj_area = new ClsDataObj(cm);
                tempobj_area.Typename = "病室";
                tempobj_area.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_area.Val = ds.Tables[0].Rows[0]["SICK_AREA_NAME"].ToString();
                else
                    tempobj_area.Val = inPat.Sick_Area_Name;
                tempobj_area.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_area.Typename) != null)
                    currentPage.Objs.Add(tempobj_area);
                */
                ClsDataObj tempobj_section = new ClsDataObj(cm);
                tempobj_section.Typename = "科室";
                tempobj_section.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_section.Val = ds.Tables[0].Rows[0]["SECTION_NAME"].ToString();
                else
                    tempobj_section.Val = inPat.Section_Name;
                tempobj_section.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_section.Typename) != null)
                    currentPage.Objs.Add(tempobj_section);


                /*
                 *打印普通体温单日期、手术后天数、时间点、
                 */
                
                printTime(inPat, ref currentPage, dtOutHospital, TEMPLATE_NORMAL,ref cm);


                //其他数据点
                string ps1 = ""; //皮试阴性
                string ps2 = ""; //皮试阳性
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["T_VAL"].ToString() != "已测" &&
                        !ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试"))
                    {
                        //体温不升（低温）
                        //不升
                        if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("腋温") ||
                            ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("口温") ||
                            ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("肛温"))
                        {
                            string val = ds.Tables[0].Rows[i]["T_VAL"].ToString();
                            if (Convert.ToSingle(ds.Tables[0].Rows[i]["T_VAL"]) <= 35)
                            {
                                ClsDataObj tempdownobj = new ClsDataObj(cm);
                                tempdownobj.Val = "↓";
                                tempdownobj.Typename = "体温不升";
                                tempdownobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                                tempdownobj.setdataxy(currentPage.Starttime);
                                currentPage.Objs.Add(tempdownobj);
                                val = "35";
                            }

                            ClsDataObj tempobj = new ClsDataObj(cm);
                            tempobj.Val = val;
                            tempobj.Typename = ds.Tables[0].Rows[i]["VALTYPE"].ToString();
                            tempobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                            tempobj.setdataxy(currentPage.Starttime);
                            currentPage.Objs.Add(tempobj);

                        }
                        else if (cm.GetVDataSetByName(ds.Tables[0].Rows[i]["VALTYPE"].ToString()) != null)
                        {
                            if (ds.Tables[0].Rows[i]["T_VAL"].ToString() != "")
                            {
                                ClsDataObj tempobj = new ClsDataObj(cm);

                                tempobj.Typename = ds.Tables[0].Rows[i]["VALTYPE"].ToString();
                                if (tempobj.Typename == "呼吸次数" && ds.Tables[0].Rows[i]["MEASURE_REMARK"].ToString() == "辅助")
                                {
                                    tempobj.Val = "R";
                                }
                                else
                                {
                                    tempobj.Val = ds.Tables[0].Rows[i]["T_VAL"].ToString();
                                }
                                if (tempobj.Typename == "自定义名称")
                                    tempobj.Rdatatime = "";
                                else if (tempobj.Typename == "操作事件" && tempobj.Val.Contains("手术"))
                                    continue;
                                else
                                    tempobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                                tempobj.setdataxy(currentPage.Starttime);
                                currentPage.Objs.Add(tempobj);
                            }
                        }
                    }
                    /*
                     * 皮试拼接处理
                     */
                    if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试-阴性"))
                    {
                        if (ps1 != "")
                            ps1 += ";";
                        string[] arySkinMinus = ds.Tables[0].Rows[i]["T_VAL"].ToString().Split('_');
                        DateTime dt = Convert.ToDateTime(arySkinMinus[1]);
                        ps1 += string.Format("{0}(-){1}年{2}月{3}日 {4}时{5}分", arySkinMinus[0], dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
                    }

                    if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试-阳性"))
                    {
                        if (ps2 != "")
                            ps2 += ";";
                        string[] arySkinPlus = ds.Tables[0].Rows[i]["T_VAL"].ToString().Split('+');
                        DateTime dt = Convert.ToDateTime(arySkinPlus[1]);
                        ps2 += string.Format("{0}(+){1}年{2}月{3}日 {4}时{5}分", arySkinPlus[0], dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
                    }
                   
                    //

                }

                //阴性
                if (ps1.Trim() != "")
                {
                    ClsDataObj tempops1 = new ClsDataObj(cm);
                    tempops1.Typename = "皮试-阴性";
                    tempops1.Rdatatime = "";
                    tempops1.Val = ps1;
                    tempops1.setdataxy(currentPage.Starttime);
                    currentPage.Objs.Add(tempops1);
                }
                //阳性
                if (ps2.Trim() != "")
                {
                    ClsDataObj tempops2 = new ClsDataObj(cm);
                    tempops2.Typename = "皮试-阳性";
                    tempops2.Rdatatime = "";
                    tempops2.Val = ps2;
                    tempops2.setdataxy(currentPage.Starttime);
                    currentPage.Objs.Add(tempops2);
                }

                /*
                 *操作事件 时间转中文处理
                */
                for (int i = 0; i < currentPage.Objs.Count; i++)
                {
                    if (currentPage.Objs[i].Typename == "操作事件")
                    {
                        string sEventName = currentPage.Objs[i].Val.Split('_')[0];

                        DateTime dtEvent = Convert.ToDateTime(Convert.ToDateTime(currentPage.Objs[i].Rdatatime).ToString("yyyy-MM-dd") + " " + currentPage.Objs[i].Val.Split('_')[1]);

                        if (sEventName != "手术")
                        {
                            currentPage.Objs[i].Val = sEventName + "｜｜" + ConvertText(dtEvent.ToString("HH:mm"));
                        }
                        else
                        {
                            currentPage.Objs[i].Val = sEventName;
                        }
                    }
                }
            
                #endregion
            }
            catch (Exception ex)
            {
                App.Msg("tempertureDataComm.GetPageContentByPageObj方法异常!");
            }

        }
        #endregion

        #region 新生儿体温单
        /// <summary>
        /// 获取页信息内容(新生儿体温单)
        /// </summary>
        /// <param name="inPat">患者基本信息</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="indexPage">页码</param>
        public static void GetPageContentByPageObj_child(InPatientInfo inPat, ref Page currentPage, string indexPage, DateTime? dtOutHospital, ref Comm cm)
        {
            string startTime = Convert.ToDateTime(currentPage.Starttime).ToString("yyyy-MM-dd HH:mm");
            string endTime = Convert.ToDateTime(currentPage.Endtime).ToString("yyyy-MM-dd HH:mm");

           // try
            {
                DataSet ds = new DataSet();
                string sql = "select * from t_temperature_record aa where " +
                             "aa.measure_time between to_date('{0}','yyyy-MM-dd hh24:mi') and " +
                             "to_date('{1}','yyyy-MM-dd hh24:mi') and patient_id={2} and template_type='{3}' order by aa.VALTYPE_TIME asc";

                sql = String.Format(sql, startTime, endTime, inPat.Id, TEMPLATE_CHILD);
                ds = App.GetDataSet(sql);

                if (currentPage.Objs == null)
                    currentPage.Objs = new List<ClsDataObj>();
                else
                    currentPage.Objs.Clear();

                #region 组织数据
                //基本信息
                ClsDataObj tempobj_name = new ClsDataObj(cm);
                tempobj_name.Typename = "姓名";
                tempobj_name.Rdatatime = "";
                tempobj_name.Val = inPat.Patient_Name;
                tempobj_name.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_name);


                ClsDataObj tempobj_sex = new ClsDataObj(cm);
                tempobj_sex.Typename = "性别";
                tempobj_sex.Rdatatime = "";
                if (inPat.Gender_Code == "0")
                    tempobj_sex.Val = "男";
                else if (inPat.Gender_Code == "1")
                    tempobj_sex.Val = "女";
                else
                    tempobj_sex.Val = "";
                tempobj_sex.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_sex);

                ClsDataObj tempobj_age = new ClsDataObj(cm);
                tempobj_age.Typename = "年龄";
                tempobj_age.Rdatatime = "";
                tempobj_age.Val = inPat.Age;
                tempobj_age.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_age);

                ClsDataObj tempobj_pid = new ClsDataObj(cm);
                tempobj_pid.Typename = "住院号";
                tempobj_pid.Rdatatime = "";
                tempobj_pid.Val = inPat.PId;
                tempobj_pid.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_pid);

                ClsDataObj tempobj_intime = new ClsDataObj(cm);
                tempobj_intime.Typename = "入院时间";
                tempobj_intime.Rdatatime = "";
                tempobj_intime.Val = inPat.In_Time.ToString("yyyy-MM-dd");
                tempobj_intime.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_intime);

                ClsDataObj tempobj_page = new ClsDataObj(cm);
                tempobj_page.Typename = "页码";
                tempobj_page.Rdatatime = "";
                tempobj_page.Val = indexPage;
                tempobj_page.setdataxy(currentPage.Starttime);
                currentPage.Objs.Add(tempobj_page);

                //特殊处理－可变的患者基本信息
                ClsDataObj tempobj_bed = new ClsDataObj(cm);
                tempobj_bed.Typename = "床位";
                tempobj_bed.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_bed.Val = ds.Tables[0].Rows[0]["SICK_BED_NAME"].ToString();
                else
                    tempobj_bed.Val = inPat.Sick_Bed_Name;
                tempobj_bed.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_bed.Typename) != null)
                    currentPage.Objs.Add(tempobj_bed);
                /*
                ClsDataObj tempobj_area = new ClsDataObj(cm);
                tempobj_area.Typename = "病室";
                tempobj_area.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_area.Val = ds.Tables[0].Rows[0]["SICK_AREA_NAME"].ToString();
                else
                    tempobj_area.Val = inPat.Sick_Area_Name;
                tempobj_area.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_area.Typename) != null)
                    currentPage.Objs.Add(tempobj_area);
                */
                ClsDataObj tempobj_section = new ClsDataObj(cm);
                tempobj_section.Typename = "科室";
                tempobj_section.Rdatatime = "";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    tempobj_section.Val = ds.Tables[0].Rows[0]["SECTION_NAME"].ToString();
                else
                    tempobj_section.Val = inPat.Section_Name;
                tempobj_section.setdataxy(currentPage.Starttime);
                if (cm.GetVDataSetByName(tempobj_section.Typename) != null)
                    currentPage.Objs.Add(tempobj_section);


                /*
                 *打印普通体温单日期、手术后天数、时间点、
                 */

                printTime(inPat, ref currentPage, dtOutHospital, TEMPLATE_CHILD, ref cm);


                //其他数据点
                string ps1 = ""; //皮试阴性
                string ps2 = ""; //皮试阳性
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["T_VAL"].ToString() != "已测" &&
                        !ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试"))
                    {
                        //体温不升（低温）
                        //不升
                        if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("腋温") ||
                            ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("口温") ||
                            ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("肛温"))
                        {
                            string val = ds.Tables[0].Rows[i]["T_VAL"].ToString();
                            if (Convert.ToSingle(ds.Tables[0].Rows[i]["T_VAL"]) <= 35)
                            {
                                ClsDataObj tempdownobj = new ClsDataObj(cm);
                                tempdownobj.Val = "↓";
                                tempdownobj.Typename = "体温不升";
                                tempdownobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                                tempdownobj.setdataxy(currentPage.Starttime);
                                currentPage.Objs.Add(tempdownobj);
                                val = "35";
                            }

                            ClsDataObj tempobj = new ClsDataObj(cm);
                            tempobj.Val = val;
                            tempobj.Typename = ds.Tables[0].Rows[i]["VALTYPE"].ToString();
                            tempobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                            tempobj.setdataxy(currentPage.Starttime);
                            currentPage.Objs.Add(tempobj);

                        }
                        else if (cm.GetVDataSetByName(ds.Tables[0].Rows[i]["VALTYPE"].ToString()) != null)
                        {
                            if (ds.Tables[0].Rows[i]["T_VAL"].ToString() != "")
                            {
                                ClsDataObj tempobj = new ClsDataObj(cm);

                                tempobj.Typename = ds.Tables[0].Rows[i]["VALTYPE"].ToString();
                                if (tempobj.Typename == "呼吸次数" && ds.Tables[0].Rows[i]["MEASURE_REMARK"].ToString() == "辅助")
                                {
                                    tempobj.Val = "R";
                                }
                                else
                                {
                                    tempobj.Val = ds.Tables[0].Rows[i]["T_VAL"].ToString();
                                }
                                if (tempobj.Typename == "自定义名称")
                                    tempobj.Rdatatime = "";
                                else if (tempobj.Typename == "操作事件" && tempobj.Val.Contains("手术"))
                                    continue;
                                else
                                    tempobj.Rdatatime = Convert.ToDateTime(ds.Tables[0].Rows[i]["MEASURE_TIME"]).ToString("yyyy-MM-dd HH:mm");
                                tempobj.setdataxy(currentPage.Starttime);
                                currentPage.Objs.Add(tempobj);
                            }
                        }
                    }
                    /*
                     * 皮试拼接处理
                     */
                    if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试-阴性"))
                    {
                        if (ps1 != "")
                            ps1 += ";";
                        string[] arySkinMinus = ds.Tables[0].Rows[i]["T_VAL"].ToString().Split('_');
                        DateTime dt = Convert.ToDateTime(arySkinMinus[1]);
                        ps1 += string.Format("{0}(-){1}年{2}月{3}日 {4}时{5}分", arySkinMinus[0], dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
                    }

                    if (ds.Tables[0].Rows[i]["VALTYPE"].ToString().Contains("皮试-阳性"))
                    {
                        if (ps2 != "")
                            ps2 += ";";
                        string[] arySkinPlus = ds.Tables[0].Rows[i]["T_VAL"].ToString().Split('+');
                        DateTime dt = Convert.ToDateTime(arySkinPlus[1]);
                        ps2 += string.Format("{0}(+){1}年{2}月{3}日 {4}时{5}分", arySkinPlus[0], dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
                    }

                    //

                }

                //阴性
                if (ps1.Trim() != "")
                {
                    ClsDataObj tempops1 = new ClsDataObj(cm);
                    tempops1.Typename = "皮试-阴性";
                    tempops1.Rdatatime = "";
                    tempops1.Val = ps1;
                    tempops1.setdataxy(currentPage.Starttime);
                    currentPage.Objs.Add(tempops1);
                }
                //阳性
                if (ps2.Trim() != "")
                {
                    ClsDataObj tempops2 = new ClsDataObj(cm);
                    tempops2.Typename = "皮试-阳性";
                    tempops2.Rdatatime = "";
                    tempops2.Val = ps2;
                    tempops2.setdataxy(currentPage.Starttime);
                    currentPage.Objs.Add(tempops2);
                }

                /*
                 *操作事件 时间转中文处理
                */
                for (int i = 0; i < currentPage.Objs.Count; i++)
                {
                    if (currentPage.Objs[i].Typename == "操作事件")
                    {
                        string sEventName = currentPage.Objs[i].Val.Split('_')[0];

                        DateTime dtEvent = Convert.ToDateTime(Convert.ToDateTime(currentPage.Objs[i].Rdatatime).ToString("yyyy-MM-dd") + " " + currentPage.Objs[i].Val.Split('_')[1]);

                        if (sEventName != "手术")
                        {
                            currentPage.Objs[i].Val = sEventName + "｜｜" + ConvertText(dtEvent.ToString("HH:mm"));
                        }
                        else
                        {
                            currentPage.Objs[i].Val = sEventName;
                        }
                    }
                }

                #endregion
            }
            /*
            catch (Exception ex)
            {
                App.Msg("tempertureDataComm.GetPageContentByPageObj_child方法异常!");
            }
            */
        }
        #endregion
    }
}
