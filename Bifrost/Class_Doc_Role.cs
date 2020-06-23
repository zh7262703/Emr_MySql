using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;

namespace Bifrost
{
    /// <summary>
    /// 客户端质控规则校验
    /// 创建者：卢才星
    /// 创建时间：2011-11-28
    /// </summary>
    public class Class_Doc_Rule
    {

        /// <summary>
        /// 入院记录
        /// </summary>
        /// <param name="in_time">入院时间</param>
        /// <param name="record_time">记录时间</param>
        /// <param name="inital_time">初步诊断时间</param>
        /// <param name="confirm_time">确定诊断时间</param>
        /// <param name="reference_time">参考时间</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控周期：单位</param>
        /// <param name="isOkDiagnose">是否有确定诊断时间</param>
        /// <param name="referDiagnoseTime">确定诊断时间（字符串形式）</param>
        /// <returns></returns>
        public static string In_Area_Rule(DateTime in_time, DateTime record_time, DateTime inital_time, DateTime confirm_time, DateTime reference_time, int turntime, string unit, ref bool isOkDiagnose, ref string referDiagnoseTime)
        {           
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = in_time.AddDays(turntime);
            }

            if (in_time < record_time)
            {
                if (record_time < inital_time || record_time == inital_time)
                {
                    if (confirm_time != reference_time)
                    //判断是否有确定诊断时间
                    {
                        isOkDiagnose = true;
                        referDiagnoseTime = confirm_time.ToString();
                        if (inital_time < confirm_time || inital_time == confirm_time)
                        {
                            if (inital_time < temptime || inital_time == temptime)
                            {
                                if (confirm_time < in_time.AddDays(7) || confirm_time == in_time.AddDays(7))
                                {
                                    return "";
                                }
                                else
                                {
                                    return "确定诊断时间超过入院时间+7天，是否确认提交？如确认提交会在质控部生成数据报表！";
                                }

                            }
                            else
                            {
                                return "初步诊断时间/日期应该小于等于入院时间+24小时";
                            }
                        }
                        else
                        {
                            return "初步诊断时间/日期应该小于等于确定诊断时间/日期";
                        }
                    }
                    else
                    {
                        //没有确定诊断时间
                        if (inital_time < temptime || inital_time == temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "初步诊断时间/日期应该小于等于入院时间+24小时";
                        }

                    }
                }
                else
                {
                    return "记录时间/日期应该小于等于初步诊断时间/日期";
                }

            }
            else
            {
                return "入院时间应该小于记录时间/日期";
            }
        }

        /// <summary>
        /// 24小时内入出院记录
        /// </summary>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控周期：单位</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="sign_time">签名时间</param>
        /// <param name="xmldocument">当前文书</param>
        /// <returns></returns>
        public static string In_Out_Area_Rule(int turntime, string unit, DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument)
        {
            DateTime out_time1 = new DateTime();
            string strout_time = "";
            XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < footnodeListInput.Count; ii++)
            {
                if (footnodeListInput[ii].Attributes["name"].Value == "出院时间" || 
                    footnodeListInput[ii].Attributes["name"].Value == "出院日期")
                {

                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                    {

                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                        }

                    }
                }
            }
            strout_time = strout_time.Replace("，", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("：", ":");
            if (strout_time != "")
                try
                {
                    out_time1 = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "出院时间格式不正确，请修正后再提交！";

                }
            else
                out_time1 = Convert.ToDateTime("1900-01-01 01:01");
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = out_time1.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = out_time1.AddDays(turntime);
            }
            if (in_time < sign_time)
            {
                if (in_time < out_time1)
                {
                    if (out_time1 < in_time.AddHours(24) || out_time1 == in_time.AddHours(24))
                    {
                        if (sign_time < temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "文书签名时间应该小于出院时间/日期+24小时";
                        }

                    }
                    else
                    {
                        return "出院时间/日期应该小于等于入院时间+24小时";
                    }

                }
                else
                {
                    return "入院时间应该小于出院时间/日期";
                }
            }
            else
            {
                return "文书签名时间应该大于入院时间";
            }
        }

        /// <summary>
        /// 24小时内入院死亡记录
        /// </summary>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控周期：单位</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="sign_time">签名时间</param>
        /// <param name="xmldocument">当前文书</param>
        /// <returns></returns>
        public static string In_Die_Area_Rule(int turntime, string unit, DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument)
        {
            DateTime out_time1 = new DateTime();
            string strout_time = "";
            XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < footnodeListInput.Count; ii++)
            {
                if (footnodeListInput[ii].Attributes["name"].Value == "死亡时间")
                {

                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                    {

                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                        }

                    }
                }
            }
            strout_time = strout_time.Replace("，", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("：", ":");
            if (strout_time != "")
                try
                {
                    out_time1 = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "死亡时间格式不正确，请修正后再提交！";
                }
            else
                out_time1 = Convert.ToDateTime("1900-01-01 01:01");
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = out_time1.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = out_time1.AddDays(turntime);
            }
            if (in_time < sign_time)
            {
                if (in_time < out_time1)
                {
                    if (out_time1 < in_time.AddHours(24) || out_time1 == in_time.AddHours(24))
                    {
                        if (sign_time < temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "文书签名时间应该小于死亡时间/日期+24小时";
                        }

                    }
                    else
                    {
                        return "死亡时间/日期应该小于等于入院时间+24小时";
                    }
                }
                else
                {
                    return "入院时间应该小于死亡时间/日期";
                }
            }
            else
            {
                return "文书签名时间应该大于入院时间";
            }
        }

        /// <summary>
        /// 一般病程记录
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控周期：单位</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="replaceHigher">代（主任或者主治）上级医生</param>
        /// <returns></returns>
        public static string Day_Medical_Record_Rule(string patient_Id, DateTime in_time, int turntime, string unit, DateTime tittle_time, string doc_tittle, int replaceHigher)
        {
            DateTime referTime = new DateTime();
            int bingchengNumber = 0;
            string strResult = "";
            DateTime temptime = new DateTime();
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            string Sqlbingcheng = "select * from t_patients_doc  t  where t.textname like '%病程记录%' and t.patient_id='" + patient_Id + "' and textkind_id=126 order by doc_name desc";
            DataSet bingcheng = App.GetDataSet(Sqlbingcheng);
            if (bingcheng != null && bingcheng.Tables.Count > 0)
            {
                bingchengNumber = bingcheng.Tables[0].Rows.Count;
                if (bingchengNumber > 0)
                {
                    referTime = Convert.ToDateTime(App.GetTimeString(bingcheng.Tables[0].Rows[0]["doc_name"].ToString()));
                }
            }
            #region
            if (tittle_time < in_time || tittle_time == in_time)
                return "文书标题时间应该大于入院时间";

            if (bingchengNumber == 0)
            {
                if (tittle_time > in_time.AddHours(24))
                {
                    strResult = "日常病程记录入院时间+72小时内每24小时内至少要写一份！";
                }
            }
            else
            {
                //上一份文书的时间是入院24小时内
                if (referTime > in_time && referTime < in_time.AddHours(24))
                {
                    if (tittle_time > in_time.AddHours(48))
                    {
                        strResult = "日常病程记录入院时间+72小时内每24小时内至少要写一份！";
                    }
                }
                //上一份文书的时间是入院48小时内
                else if ((referTime > in_time.AddHours(24) || referTime == in_time.AddHours(24)) && referTime < in_time.AddHours(48))
                {
                    if (tittle_time > in_time.AddHours(72))
                    {
                        strResult = "日常病程记录入院时间+72小时内每24小时内至少要写一份！";
                    }
                }
                //上一份文书的时间是入院72小时内
                else if ((referTime > in_time.AddHours(48) || referTime == in_time.AddHours(48)) && referTime < in_time.AddHours(72))
                {
                    if (tittle_time > referTime.AddHours(72))
                    {
                        strResult = "日常病程记录应每3天至少1次！";
                    }
                }
                //上一份文书的时间是入院72小时以外
                else
                {
                    if (tittle_time > referTime.AddHours(72))
                    {
                        strResult = "日常病程记录应每3天至少1次！";
                    }
                }
            }
            #endregion
            if (strResult != "")
                return strResult;
            else
            {
                //代主任
                if (replaceHigher == 1)
                {
                    #region
                    string SqlChairman = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                    DataSet dsChairman = App.GetDataSet(SqlChairman);
                    if (dsChairman != null && dsChairman.Tables.Count > 0)
                    {
                        //没有首次主治查房
                        #region
                        if (dsChairman.Tables[0].Rows.Count == 0)
                        {
                            temptime = in_time.AddHours(48);
                            if (in_time < tittle_time)
                            {
                                if (tittle_time < temptime || tittle_time == temptime)
                                {
                                    return "";
                                }
                                else
                                {
                                    return "[首次主治查房]标题时间应该小于等于入院时间+48小时";
                                }
                            }
                            else
                            {
                                return "入院时间应该小于[首次主治查房]标题时间";
                            }
                        }
                        #endregion
                        //有首次主治查房记录
                        else
                        {
                            //主治
                            string sqlIsHaveFirstChain = "select * from t_patients_doc  t where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                                                         "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%主治%' order by doc_name desc";
                            //主任
                            string sqlIsHaveFirstChain2 = "select * from t_patients_doc  t  where  " +
                                                            " t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                                                            "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%主任%'order by doc_name desc";
                            //没有首次查房记录，只有首次主任查房记录，这个时候就将首次主任当做首次主治
                            if (App.GetDataSet(sqlIsHaveFirstChain).Tables[0].Rows.Count == 0 )
                            {
                                //代主治
                                if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                                {
                                    temptime = in_time.AddHours(48);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[首次主治查房]标题时间应该小于等于入院时间+48小时";
                                        }
                                    }
                                    else
                                    {
                                        return "入院时间应该小于[首次主治查房]标题时间";
                                    }
                                }
                                //代主任
                                else if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 1)
                                {
                                    temptime = in_time.AddHours(72);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[首次主任查房]标题时间应该小于等于入院时间+72小时（没有首次查房记录，只有首次主任查房记录，这个时候就将首次主任当做首次主治）";
                                        }
                                    }
                                    else
                                    {
                                        return "入院时间应该小于[首次主任查房]标题时间（没有首次查房记录，只有首次主任查房记录，这个时候就将首次主任当做首次主治）";
                                    }
                                }
                                else
                                {
                                    DateTime refTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                    if (tittle_time > refTime.AddDays(7))
                                    {
                                        return "每周期（7日）内至少有一份主任查房录";
                                    }
                                    else
                                    {
                                        return "";
                                    }
                                }
                            }
                            //写了首次主任查房
                            else
                            {
                                if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                                {
                                    temptime = in_time.AddHours(72);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[首次主任查房]标题时间应该小于等于入院时间+72小时";
                                        }
                                    }
                                    else
                                    {
                                        return "入院时间应该小于[首次主任查房]标题时间";
                                    }
                                }
                                else
                                {
                                    DateTime refTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                    if (tittle_time > refTime.AddDays(7))
                                    {
                                        return "每周期（7日）内至少有一份主任查房录";
                                    }
                                    else
                                    {
                                        return "";
                                    }
                                }
                            }

                        }
                    }
                    #endregion
                }
                //代主治
                if (replaceHigher == 2)
                {
                    #region
                    temptime = in_time.AddHours(48);//t.pid='00507075' and textkind_id=126 and t.israplacehightdoctor='Y' 
                    string SqlAttending = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                    DataSet dsAttending = App.GetDataSet(SqlAttending);
                    if (dsAttending != null && dsAttending.Tables.Count > 0)
                    {
                        //没有首次主治查房
                        if (dsAttending.Tables[0].Rows.Count == 0)
                        {
                            if (in_time < tittle_time)
                            {
                                if (tittle_time < temptime || tittle_time == temptime)
                                {
                                    return "";
                                }
                                else
                                {
                                    return "[首次主治查房]标题时间应该小于入院时间+48小时";
                                }
                            }
                            else
                            {
                                return "入院时间应该小于[首次主治查房]标题时间";
                            }
                        }
                        //有首次主治查房记录
                        else
                        {
                            DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsAttending.Tables[0].Rows[0]["doc_name"].ToString()));
                            if (tittle_time > beforeTime.AddDays(3))
                            {
                                return "日常主治查房时间应每3天至少一次（主任查房可代主治查房）！";
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    #endregion
                }
            }
            return strResult;
        }

        /// <summary>
        /// 首次病程记录
        /// </summary>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控周期：单位</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string First_Medical_Record_Rule(int turntime, string unit, DateTime tittle_time, string doc_tittle,DateTime in_time)
        {
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = in_time.AddDays(turntime);
            }
            if (doc_tittle.Length != 0)
            {
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            }


            if (in_time < tittle_time)
            {
                if (tittle_time < temptime || tittle_time == temptime)
                {
                    return "";
                }
                else
                {
                    return "标题时间应该小于等于入院时间+8小时";
                }
            }
            else
            {
                return "入院时间应该小于标题时间";
            }
        }

        /// <summary>
        /// 上级医生查房记录
        /// </summary>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="tittle_time">标题时间</param>
        /// <returns></returns>
        public static string Higher_Docter_Check_Rule(string doc_tittle,string patient_Id,DateTime in_time,DateTime tittle_time)
        {
            DateTime temptime = new DateTime();
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (doc_tittle.Contains("主治"))
            {
                #region
                temptime = in_time.AddHours(48);//t.pid='00507075' and textkind_id=126 and t.israplacehightdoctor='Y' 
                string SqlAttending = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                DataSet dsAttending = App.GetDataSet(SqlAttending);
                if (dsAttending != null && dsAttending.Tables.Count > 0)
                {
                    //没有首次主治查房
                    if (dsAttending.Tables[0].Rows.Count == 0)
                    {
                        if (in_time < tittle_time)
                        {
                            if (tittle_time < temptime || tittle_time == temptime)
                            {
                                return "";
                            }
                            else
                            {
                                return "[首次主治查房]标题时间应该小于入院时间+48小时";
                            }
                        }
                        else
                        {
                            return "入院时间应该小于[首次主治查房]标题时间";
                        }
                    }
                    //有首次主治查房记录
                    else
                    {
                        DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsAttending.Tables[0].Rows[0]["doc_name"].ToString()));
                        if (tittle_time > beforeTime.AddDays(3))
                        {
                            return "日常主治查房时间应每3天至少一次（主任查房可代主治查房）！";
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                #endregion
            }
            else if (doc_tittle.Contains("主任"))
            {
                #region
                DateTime LastTime=new DateTime();
                string SqlChairman = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                DataSet dsChairman = App.GetDataSet(SqlChairman);
                if (dsChairman != null && dsChairman.Tables.Count > 0)
                {
                    //没有首次主治查房
                    #region
                    if (dsChairman.Tables[0].Rows.Count == 0)
                    {
                        temptime = in_time.AddHours(48);
                        if (in_time < tittle_time)
                        {
                            if (tittle_time < temptime || tittle_time == temptime)
                            {
                                return "";
                            }
                            else
                            {
                                return "[首次主治查房]标题时间应该小于等于入院时间+48小时";
                            }
                        }
                        else
                        {
                            return "入院时间应该小于[首次主治查房]标题时间";
                        }
                    }
                    #endregion
                    //有首次主治查房记录
                    else
                    {
                        string sqlIsHaveFirstChain = "select * from t_patients_doc  t where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                                                     "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%主治%' order by doc_name desc";
                        string sqlIsHaveFirstChain2 = "select * from t_patients_doc  t  where  " +
                                                        " t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                                                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%主任%'order by doc_name desc";
                        //没有首次查房记录，只有首次主任查房记录，这个时候就将首次主任当做首次主治
                        if (App.GetDataSet(sqlIsHaveFirstChain).Tables[0].Rows.Count == 0 )
                        {
                            if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                            {
                                if (tittle_time > in_time.AddDays(2))
                                {
                                    return "首次主治查房时间应在入院时间+48小时内！";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 1)
                            {
                                if (tittle_time > in_time.AddDays(3))
                                {
                                    return "首次主任查房时间应在入院时间+72小时内！";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else
                            {
                                LastTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                if (tittle_time > in_time.AddDays(7))
                                {
                                    return "主任日常查房记录每7天一次！";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                        }
                        //写了首次主任查房
                        else 
                        {
                            if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                            {
                                if (tittle_time > in_time.AddDays(3))
                                {
                                    return "首次主任查房时间应在入院时间+72小时内！";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else
                            {
                                LastTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                if (tittle_time > LastTime.AddDays(7))
                                {
                                    return "主任日常查房记录每7天一次！";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                           
                        }

                    }
                }
                #endregion
            }
            return "";
        }

        /// <summary>
        /// 转出记录
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="reference_time">参考时间</param>
        /// <param name="out_time">转出时间</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string Turn_Out_Rule(DateTime tittle_time, string doc_tittle, string patient_Id, DateTime reference_time, DateTime out_time, DateTime in_time)
        {
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            //out_time = tittle_time;
            out_time = reference_time;
            string SqlInfoouttime = "select b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + " and b.next_id=0 and b.action_type='转出' order by happen_time desc";
            DataSet PatientInfodsouttime = App.GetDataSet(SqlInfoouttime);
            if (PatientInfodsouttime != null && PatientInfodsouttime.Tables.Count > 0)
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
                {
                    if (PatientInfodsouttime.Tables[0].Rows[0]["action_type"].ToString() == "转出")
                    {
                        out_time = Convert.ToDateTime(PatientInfodsouttime.Tables[0].Rows[0]["happen_time"].ToString());
                    }
                }
            }
            if (out_time == reference_time)
            {
                //没有转出记录的时候
                if (in_time < tittle_time)
                {
                    return "";
                }
                else
                {
                    return "入院时间应该小于标题时间";
                }
            }
            if (in_time < tittle_time)
            {
                //有转出记录的时候
                if (tittle_time < out_time)
                {
                    return "";
                }
                else
                {
                    return "标题时间应该小于转出时间";
                }
            }
            else
            {
                return "入院时间应该小于标题时间";
            }
        }

        /// <summary>
        /// 转入记录
        /// </summary>
        /// <param name="reference_time">参考时间</param>
        /// <param name="out_time">转出时间</param>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控时间：单位</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <returns></returns>
        public static string Turn_In_Rule(DateTime in_time,DateTime reference_time, DateTime out_time, string patient_Id, int turntime, string unit, DateTime tittle_time, string doc_tittle, bool isNew)
        {
            DateTime temptime = new DateTime();
            //找到病人记录里面的转出记录，没有找到的话直接弹出没有找到记录
            //out_time = reference_time;
            //string SqlInfoouttime = "select b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + "and b.action_type='转出' order by happen_time desc";
            //DataSet PatientInfodsouttime = App.GetDataSet(SqlInfoouttime);
            //if (PatientInfodsouttime != null && PatientInfodsouttime.Tables.Count > 0)
            //{
            //    if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
            //    {
            //        if (PatientInfodsouttime.Tables[0].Rows[0]["action_type"].ToString() == "转出")
            //        {
            //            out_time = Convert.ToDateTime(PatientInfodsouttime.Tables[0].Rows[0]["happen_time"].ToString());
            //        }
            //    }
            //}
            //转出记录
            string turn_outInfo = "select doc_name from t_patients_doc t where  t.textkind_id=130 and t.patient_id='" + patient_Id + "' order by doc_name desc ";
            //转入信息
            string turn_inInfo = "select doc_name from t_patients_doc t where  t.textkind_id=301 and t.patient_id='" + patient_Id + "' order by doc_name desc ";
            DataSet PatientInfodsouttime = App.GetDataSet(turn_outInfo);
            DataSet PatientInfodsintime = App.GetDataSet(turn_inInfo);
            if (PatientInfodsintime != null)
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        out_time = Convert.ToDateTime(App.GetTimeString(PatientInfodsouttime.Tables[0].Rows[0]["doc_name"].ToString()));
                    }
                    catch 
                    {
                        return "未找到相对应的转出记录";
                    }
                }
                else
                {
                    return "未找到相对应的转出记录";
                }
            }
            if (unit == "小时")
            {
                temptime = out_time.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = out_time.AddDays(turntime);
            }
            //out_time 转出时间 temptime转出时间+24小时  in_time 入院时间 tittle_time 标题时间
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (isNew == false)
            {
                //转出记录要大于转入记录
                if (PatientInfodsouttime.Tables[0].Rows.Count > PatientInfodsintime.Tables[0].Rows.Count)
                {
                    if (out_time < tittle_time)
                    {
                        return "";
                    }
                    else
                    {
                        return "转出记录标题时间应该小于转入记录标题时间（仅相对应的）";
                    }
                }
                else
                {
                    return "未找到相对应的转出记录";
                }
            }
            else
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count+1 > PatientInfodsintime.Tables[0].Rows.Count)
                {
                    if (out_time < tittle_time)
                    {
                        return "";
                    }
                    else
                    {
                        return "转出记录标题时间应该小于转入记录标题时间（仅相对应的）";
                    }
                }
                else
                {
                    return "未找到相对应的转出记录";
                }
            }
            //if (tittle_time < temptime || tittle_time == temptime)
            //{
            //    if (out_time < tittle_time)
            //    {
            //        return "";
            //    }
            //    else
            //    {
            //        return "相对应的转出时间应该小于转入记录标题时间）";
            //    }
            //}
            //else
            //{
            //    return "标题时间应该小于等于转入时间+24小时";
            //}
        }

        /// <summary>
        /// 交班记录
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="reference_time">参考时间</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string JiaoBan_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime reference_time, DateTime in_time)
        {
            if (doc_tittle.Length != 0)
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (tittle_time != reference_time)
            {
                if (in_time < tittle_time)
                {
                    return "";
                }
                else
                {
                    return "入院时间应该小于相对应的交班记录 标题时间";
                }
            }
            return "";
        }

        /// <summary>
        /// 接班记录
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string JieBan_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time,string patient_id)
        {
            DataSet dsexchange = new DataSet();
            string Sqlexchange = "select doc_name from t_patients_doc e where  e.textkind_id=890 and e.patient_id='"+patient_id+"' order by doc_name desc ";
            dsexchange = App.GetDataSet(Sqlexchange);
            DateTime jiaob_time = new DateTime();
            if (dsexchange != null)
            {
                DataTable dt = dsexchange.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count == 0)
                    {
                        return "未找到相应的交班记录！";
                    }
                    else
                    {
                        string tittle_name = dt.Rows[0][0].ToString();//交班记录
                        if (tittle_name.Length != 0)
                        {
                            jiaob_time = Convert.ToDateTime(App.GetTimeString(tittle_name));
                        }
                    }
                }
            }
            if (doc_tittle.Length > 0)
            {
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            }
            if (in_time < jiaob_time)
            {
                if (jiaob_time < tittle_time)
                {
                    if (tittle_time < jiaob_time.AddHours(24) || tittle_time == jiaob_time.AddHours(24))
                    {
                        return "";
                    }
                    else
                    {
                        return "相对应的接班记录标题时间应该小于相对应的交班记录标题时间+24小时";
                    }
                }
                else
                {
                    return "相对应的交班记录标题时间应该小于相对应的接班记录标题时间";
                }
            }
            else
            {
                return "入院时间应该小于相对应的交班记录的标题时间";
            }
            return "";
        }

        /// 阶段小结
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控时间：单位</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="patient_Id">病人ID</param>
        /// <returns></returns>
        public static string Stage_Summary_Rule(DateTime tittle_time, string doc_tittle, int turntime, string unit, DateTime in_time, string patient_Id)
        {
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = in_time.AddDays(turntime);
            }
            if (tittle_time < in_time || tittle_time == in_time)
            {
                return "标题时间应该大于入院时间";
            }
            //阶段小结，入院时间，术前讨论，转入记录，接班记录
            string Sqlstage = "select * from t_patients_doc  t  where  t.textkind_id in ('131','301','891') and t.patient_id='" + patient_Id + "'  order by t.doc_name desc";
            string Sqlstage1 = "select * from t_patients_doc  t  where  t.textkind_id='134' and t.patient_id='" + patient_Id + "'  order by t.doc_name desc";
            DataSet dsStage = App.GetDataSet(Sqlstage);
            DataSet dsStage1 = App.GetDataSet(Sqlstage1);
            if (dsStage != null && dsStage1 != null)
            {
                if (dsStage.Tables[0].Rows.Count == 0 && dsStage1.Tables[0].Rows.Count==0)
                {
                    if (tittle_time < temptime || tittle_time == temptime)
                    {
                        return "";
                    }
                    else
                    {
                        return "标题时间应该小于等于入院时间（读取后不允许修改）+30天";
                    }
                }
                else
                {
                    if (dsStage.Tables[0].Rows.Count > 0)
                    {
                        DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsStage.Tables[0].Rows[0]["doc_name"].ToString()));
                        if (dsStage1.Tables[0].Rows.Count == 0)
                        {
                            if (tittle_time > beforeTime.AddDays(30))
                            {
                                return "每30天应该有一个阶段小结";
                            }
                        }
                        else
                        {
                            
                            #region
                            for (int num = 0; num < dsStage1.Tables[0].Rows.Count; num++)
                            {
                                XmlDocument xnldocument = new XmlDocument();
                                DateTime taolun = new DateTime();
                                xnldocument.LoadXml(dsStage1.Tables[0].Rows[num]["patients_doc"].ToString());
                                XmlNodeList footnodeListInput = xnldocument.GetElementsByTagName("input");
                                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                                {
                                    string strout_time = "";
                                    if (footnodeListInput[ii].Attributes["name"].Value == "讨论日期")
                                    {
                                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                        {

                                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                            }

                                        }
                                        strout_time = strout_time.Replace("，", " ");
                                        strout_time = strout_time.Replace(",", " ");
                                        strout_time = strout_time.Replace("：", ":");
                                        if (strout_time != "")
                                        {
                                            try
                                            {
                                                //讨论时间
                                                taolun = Convert.ToDateTime(strout_time);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                        }
                                        if (taolun > beforeTime)
                                        {
                                            beforeTime = taolun;
                                        }
                                    }
                                }
                            }
                            if (tittle_time > beforeTime.AddDays(30))
                            {
                                return "每30天应该有一个阶段小结";
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        DateTime beforeTime = new DateTime();
                        #region
                        for (int num = 0; num < dsStage1.Tables[0].Rows.Count; num++)
                        {
                            XmlDocument xnldocument = new XmlDocument();
                            DateTime taolun = new DateTime();
                            xnldocument.LoadXml(dsStage1.Tables[0].Rows[num]["patients_doc"].ToString());
                            XmlNodeList footnodeListInput = xnldocument.GetElementsByTagName("input");
                            for (int ii = 0; ii < footnodeListInput.Count; ii++)
                            {
                                string strout_time = "";
                                if (footnodeListInput[ii].Attributes["name"].Value == "讨论日期")
                                {
                                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                    {

                                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                        }

                                    }
                                    strout_time = strout_time.Replace("，", " ");
                                    strout_time = strout_time.Replace(",", " ");
                                    strout_time = strout_time.Replace("：", ":");
                                    if (strout_time != "")
                                    {
                                        try
                                        {
                                            //讨论时间
                                            taolun = Convert.ToDateTime(strout_time);
                                        }
                                        catch
                                        {
                                            taolun = Convert.ToDateTime("0001-01-01");
                                        }
                                    }
                                    if (taolun > beforeTime)
                                    {
                                        beforeTime = taolun;
                                    }
                                }
                            }
                        }
                        if (tittle_time > beforeTime.AddDays(30))
                        {
                            return "每30天应该有一个阶段小结";
                        }
                        #endregion
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 会诊记录
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控时间：单位</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <returns></returns>
        public static string Consultaion_Record_Rule(string patient_id, int turntime, string unit, DateTime tittle_time, string doc_tittle)
        {
            //请会诊申请表t_consultaion_apply  会诊申请表t_consultaion_record 
            string Sqlapply = "select apply_time from t_consultaion_apply t where 1=1 and t.patient_id='" + patient_id + "'";
            DateTime consulTime = new DateTime();//请会诊时间
            DataSet ds = App.GetDataSet(Sqlapply);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        consulTime = Convert.ToDateTime(dt.Rows[0]["apply_time"].ToString());
                    }
                    else
                    {
                        return "找不到对应的请会诊记录";
                    }
                }
                else
                {
                    return "找不到对应的请会诊记录";
                }
            }
            else
            {
                return "找不到对应的请会诊记录";

            }
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            DateTime temptime = new DateTime();
            if (unit == "小时")
            {
                temptime = consulTime.AddHours(turntime);
            }
            else if (unit == "天")
            {
                temptime = consulTime.AddDays(turntime);
            }
            if (consulTime < tittle_time)
            {
                if ((tittle_time < temptime) || (tittle_time == temptime))
                {
                    return "";
                }
                else
                {
                    return "应诊科室意见书写时间应该小于等于请会诊科室记录时间/日期+48小时";
                }
            }
            else
            {
                return "请会诊科室记录时间/日期应该小于应诊科室意见书写时间";
            }
        }

        /// <summary>
        /// 出院记录
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="xmldocument">当前文书</param>
        /// <returns></returns>
        public static string Out_Record_Rule(string patient_id, DateTime in_time, DateTime tittle_time, string doc_tittle, System.Xml.XmlDocument xmldocument)
        {
            string Sqllastbc = "select textname,doc_name,textkind_id from t_patients_doc  t where t.patient_id='" + patient_id + "' and t.textkind_id='844' order by doc_name desc";
            DataSet dslastbingcheng = App.GetDataSet(Sqllastbc);//最后一次病程记录

            if (dslastbingcheng != null && dslastbingcheng.Tables[0].Rows.Count == 0)
            {
                return "出院前最后一次病程文书没有写";
            }
            else
            {
                DateTime out_time1 = new DateTime();
                string strout_time = "";
                XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                {
                    if (footnodeListInput[ii].Attributes["name"].Value == "出院日期" || 
                        footnodeListInput[ii].Attributes["name"].Value == "出院时间")
                    {

                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                        {

                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                            }

                        }
                    }
                }
                strout_time = strout_time.Replace("，", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("：", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //出院时间
                        out_time1 = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "出院时间格式不正确，请修正后再提交！";
                    }
                }
                //最后一次病程记录的时间
                doc_tittle = dslastbingcheng.Tables[0].Rows[0]["doc_name"].ToString();
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                //出院前最后一次病程记录和出院日期是一天的话，并且出院日期的后面等于00：00的时候，时间就默认为23:59
                if (out_time1.ToShortDateString() == tittle_time.ToShortDateString() && out_time1.ToString().Contains("0:00:00") == true && out_time1.ToString().Contains("10:00:00") == false && out_time1.ToString().Contains("20:00:00")==false)
                {
                    out_time1 = out_time1.AddHours(23).AddMinutes(59);
                }
                if (in_time < tittle_time)
                {
                    if (tittle_time < out_time1)
                    {
                        return "";
                    }
                    else
                    {
                        return "出院/死亡前最后一次病程 标题时间应该小于出院时间/日期 ";
                    }
                }
                else
                {
                    return "住院时间/日期（入院时间/日期）应该小于出院/死亡前最后一次病程 标题时间";
                }
            }
        }

        /// <summary>
        /// <summary>
        /// 死亡记录
        /// </summary>
        /// <param name="patient_id">病人ID</param>
        /// <param name="in_time">入院时间</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="xmldocument">当前文书</param>
        /// <returns></returns>
        public static string Die_Record_Rule(string patient_id, DateTime in_time, DateTime tittle_time, string doc_tittle, System.Xml.XmlDocument xmldocument)
        {
            string Sqllastbc = "select textname,doc_name,textkind_id from t_patients_doc  t  where t.patient_id='" + patient_id + "' and t.textkind_id='844' order by doc_name desc";
            DataSet dslastbingcheng = App.GetDataSet(Sqllastbc);//最后一次病程记录
            if (dslastbingcheng != null && dslastbingcheng.Tables[0].Rows.Count == 0)
            {
                return "死亡前最后一次病程文书没有写";
            }
            else
            {
                DateTime out_time1 = new DateTime();
                string strout_time = "";
                XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                {
                    if (footnodeListInput[ii].Attributes["name"].Value == "出院时间"|| 
                        footnodeListInput[ii].Attributes["name"].Value == "出院日期")
                    {

                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                        {

                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                            }
                        }
                    }
                }
                strout_time = strout_time.Replace("，", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("：", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //死亡时间
                        out_time1 = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "出院时间格式不正确，请修正后再提交！";
                    }
                }
                //最后一次病程记录时间
                //doc_tittle = dslastbingcheng.Tables[0].Rows[0]["doc_name"].ToString();
                //tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));

                //if (in_time < tittle_time)
                //{
                //    if (tittle_time < out_time1)
                //    {
                //        return "";
                //    }
                //    else
                //    {
                //        return "死亡前最后一次病程 标题时间应该小于死亡时间/日期";
                //    }
                //}
                //else
                //{
                //    return "住院时间/日期（入院时间/日期）应该小于死亡前最后一次病程 标题时间";
                //}
                if (in_time < out_time1)
                {

                }
                else
                {
                    return "住院时间/日期（入院时间/日期）应该小于死亡时间/日期";
                }
            }
            return "";
        }

        /// <summary>
        /// 最后一次病程记录
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string Last_Medical_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time)
        {
            if (doc_tittle != "")
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (in_time < tittle_time)
            {
                return "";
            }
            else
            {
                return "住院时间/日期（入院时间/日期）应该小于出院/死亡前最后一次病程 标题时间";
            }
        }

        /// <summary>
        /// 死亡病例讨论记录
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="turntime">质控时间：数字位</param>
        /// <param name="unit">质控时间：单位</param>
        /// <param name="out_time">死亡时间</param>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <returns></returns>
        public static string Die_Discussion_Record(string patient_Id, int turntime, string unit, DateTime out_time, DateTime tittle_time, string doc_tittle)
        {
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            string Sqldie = "select * from t_patients_doc t inner join  t_in_patient b on t.pid=b.pid where textname like '%死亡记录%' and b.id='" + patient_Id + "' ";
            DataSet dsDie = App.GetDataSet(Sqldie);
            if (dsDie != null && dsDie.Tables.Count > 0)
            {
                if (dsDie.Tables[0].Rows.Count == 0)
                {
                    return "死亡记录/24小时内入院死亡记录没有写";
                }
                else
                {
                    string strout_time = "";
                    string t_textkind_id= dsDie.Tables[0].Rows[0]["textkind_id"].ToString();
                    //死亡记录
                    if (t_textkind_id == "138")
                    {
                        XmlDocument die = new XmlDocument();
                        die.LoadXml(dsDie.Tables[0].Rows[0]["patients_doc"].ToString());
                        //dsDie.Tables[0].Rows[0]["patients_doc"] as XmlDocument;
                        XmlNodeList footnodeListInput = die.GetElementsByTagName("input");
                        for (int ii = 0; ii < footnodeListInput.Count; ii++)
                        {
                            if (footnodeListInput[ii].Attributes["name"].Value == "出院时间")
                            {

                                for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                {

                                    if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                    }
                                }
                            }
                        }
                        strout_time = strout_time.Replace("，", " ");
                        strout_time = strout_time.Replace(",", " ");
                        strout_time = strout_time.Replace("：", ":");
                        if (strout_time != "")
                        {
                            try
                            {
                                //死亡时间
                                out_time = Convert.ToDateTime(strout_time);
                            }
                            catch
                            {
                                return "出院时间格式不正确，请修正后再提交！";
                            }
                        }

                    }
                    //24小时内入院死亡记录
                    else if (t_textkind_id == "121")
                    {
                        XmlDocument die = new XmlDocument();
                        die.LoadXml(dsDie.Tables[0].Rows[0]["patients_doc"].ToString());
                        XmlNodeList footnodeListInput = die.GetElementsByTagName("input");
                        for (int ii = 0; ii < footnodeListInput.Count; ii++)
                        {
                            if (footnodeListInput[ii].Attributes["name"].Value == "死亡时间")
                            {

                                for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                {

                                    if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                    }
                                }
                            }
                        }
                        strout_time = strout_time.Replace("，", " ");
                        strout_time = strout_time.Replace(",", " ");
                        strout_time = strout_time.Replace("：", ":");
                        if (strout_time != "")
                        {
                            try
                            {
                                //死亡时间
                                out_time = Convert.ToDateTime(strout_time);
                            }
                            catch
                            {
                                return "出院时间格式不正确，请修正后再提交！";
                            }
                        }

                    }
                    DateTime temptime = new DateTime();
                    if (unit == "小时")
                    {
                        temptime = out_time.AddHours(turntime);
                    }
                    else if (unit == "天")
                    {
                        temptime = out_time.AddDays(turntime);
                    }
                    if (out_time < tittle_time)
                    {
                        if (tittle_time < temptime || tittle_time == temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "标题时间应该小于等于+7天";
                        }
                    }
                    else
                    {
                        return "死亡时间应该小于标题时间";
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 妇产科【计划生育门诊/住院病历】
        /// </summary>
        /// <param name="in_time">入院时间</param>
        /// <param name="sign_time">签名时间</param>
        /// <param name="XmlDocument">当前文书</param>
        /// <param name="out_time">出院时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <returns></returns>
        public static string Beijing_Birth_Control_Record_Rule(DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument, DateTime out_time, string doc_tittle)
        {
            XmlNodeList HeadNode = xmldocument.GetElementsByTagName("head");
            doc_tittle = HeadNode[0].Attributes["text_name"].Value;
            string strout_time = "";
            //北京市计划生育门诊/住院病历 日期<文书签名时间（文书签名下面的时间）
            if (doc_tittle.Contains("北京") == true)
            {
                if (in_time < sign_time)
                {
                    return "";
                }
                else
                {
                    return "入院日期应该小于签名时间";
                }
            }
            //入院时间（读取后不允许修改)<出院时间<=入院时间（读取后不允许修改)+24小时
            //And 入院时间<=文书签名时间（文书签名下面的时间）<=出院时间（读取后不允许修改)+24小时
            else if (doc_tittle.Contains("北京") == false && doc_tittle.Contains("计划生育") == true)
            {
                bool IsFirstNew = false;
                XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < InputNodeList.Count; ii++)
                {
                    if (InputNodeList[ii].Attributes["name"].Value == "新增的输入域")
                    {
                        IsFirstNew = true;
                        for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                        {

                            if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                            }
                        }
                        if (IsFirstNew == true)
                        {
                            break;
                        }
                    }
                }
                strout_time = strout_time.Replace("，", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("：", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //出院时间
                        out_time = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "出院时间格式不正确，请修正后再提交！";
                    }
                }
                if (in_time < out_time)
                {
                    if (out_time < in_time.AddHours(24)||out_time==in_time.AddHours(24))
                    {
                        if (in_time < sign_time || in_time == sign_time)
                        {
                            if (sign_time < out_time.AddHours(24) || sign_time == out_time.AddHours(24))
                            {
                                return "";
                            }
                            else
                            {
                                return "文书签名时间应该小于等于出院时间+24小时";
                            }
                        }
                        else
                        {
                            return "入院时间应该小于等于文书签名时间";
                        }
                    }
                    else
                    {
                        return "出院时间应该小于等于入院时间+24小时";
                    }
                }
                else
                {
                    return "入院时间应该小于出院时间";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 一日病房住院病历（诊刮）
        /// </summary>
        /// <param name="in_time">入院时间</param>
        /// <param name="sign_time">文书时间</param>
        /// <param name="xmldocument">当前文书</param>
        /// <param name="out_time">出院时间</param>
        /// <returns></returns>
        public static string Day_Medical_Record_Curattage_Rule(DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument, DateTime out_time)
        {
            bool IsFirstNew = false;
            string strout_time = "";
            XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < InputNodeList.Count; ii++)
            {
                if (InputNodeList[ii].Attributes["name"].Value == "新增的输入域")
                {
                    IsFirstNew = true;
                    for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                    {

                        if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                        }
                    }
                    if (IsFirstNew == true)
                    {
                        break;
                    }
                }
            }
            strout_time = strout_time.Replace("，", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("：", ":");
            if (strout_time != "")
            {
                try
                {
                    //出院时间
                    out_time = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "出院时间格式不正确，请修正后再提交！";
                }
            }
            if (in_time < out_time)
            {
                if (out_time < in_time.AddHours(24) || out_time == in_time.AddHours(24))
                {
                    if (sign_time < out_time.AddHours(24) || sign_time == out_time.AddHours(24))
                    {
                        return "";
                    }
                    else
                    {
                        return "文书签名时间应该小于等于出院时间+24小时";
                    }
                }
                else
                {
                    return "出院时间应该小于等于入院时间+24小时";
                }
            }
            else
            {
                return "入院时间应该小于出院时间";
            }
        }



        /// <summary>
        /// 手术记录
        /// </summary>
        /// <param name="patient_Id">病人ID</param>
        /// <param name="xmldocument">当前文书</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string Operation_Record_Rule(string patient_Id, System.Xml.XmlDocument xmldocument,DateTime in_time,bool isNew)
        {
            DateTime operation_time = new DateTime();//手术时间
            DateTime medical_time = new DateTime();//病程记录标题时间
            bool IsFirstNew = false;
            string strout_time = "";
            string sql_before_operation = "select * from t_patients_doc t where t.textkind_id='135' and t.patient_id='" + patient_Id + "' ";
            string sql_operation = "select * from t_patients_doc t where t.textkind_id='151' and t.patient_id='" + patient_Id + "' ";
            string sql_medical_recodr = "select * from t_patients_doc t where  t.patient_id='" + patient_Id + "' and textkind_id in ('125','126','127','135') " +
                                        " order by doc_name desc";
            XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < InputNodeList.Count; ii++)
            {
                if (InputNodeList[ii].Attributes["name"].Value == "手术日期")
                {
                    IsFirstNew = true;
                    for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                    {

                        if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                        }
                    }
                    if (IsFirstNew == true)
                    {
                        break;
                    }
                }
            }
            strout_time = strout_time.Replace("，", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("：", ":");
            if (strout_time != "")
            {
                try
                {
                    //手术时间
                    operation_time = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "手术日期格式不正确，请修正后再提交！";
                }
            }

            operation_time = Convert.ToDateTime(operation_time.ToShortDateString());
            if (operation_time.ToString().Contains("0:00:00") == true && operation_time.ToString().Contains("10:00:00") == false && operation_time.ToString().Contains("20:00:00") == false)
            {
                operation_time = operation_time.AddHours(23).AddMinutes(59);
            }
            DataSet ds_before_operation = App.GetDataSet(sql_before_operation);
            DataSet ds_operation = App.GetDataSet(sql_operation);
            if (ds_before_operation != null)
            {
                if (ds_before_operation.Tables.Count > 0)
                {
                    if (ds_before_operation.Tables[0].Rows.Count == 0)
                    {
                        return "手术记录提交前必须有术前小结！";
                    }
                }
            }
            if (operation_time < Convert.ToDateTime(in_time.ToShortDateString()))
            {
                return "入院日期应该小于等于手术日期";
            }
            if (isNew == false)
            {
                if (ds_before_operation.Tables[0].Rows.Count == ds_operation.Tables[0].Rows.Count || ds_before_operation.Tables[0].Rows.Count < ds_operation.Tables[0].Rows.Count)
                {
                    return "每次手术记录前最少要有一份术前小结！";
                }
                if (operation_time.ToShortDateString() == in_time.ToShortDateString())
                {
                    return "";
                }
                DataSet ds_medical_record = App.GetDataSet(sql_medical_recodr);
                if (ds_medical_record != null)
                {
                    
                    if (ds_medical_record.Tables.Count > 0)
                    {
                        if (ds_medical_record.Tables[0].Rows.Count == 0)
                        {
                            return "手术记录提交时间前一天必须有一次病程记录！";
                        }
                        else
                        {
                            for (int i = 0; i < ds_medical_record.Tables[0].Rows.Count; i++)
                            {
                                string doc_name = ds_medical_record.Tables[0].Rows[i]["doc_name"].ToString();
                                medical_time = Convert.ToDateTime(App.GetTimeString(doc_name));
                                if (medical_time.AddHours(24).ToShortDateString() == operation_time.ToShortDateString())
                                {
                                    return "";
                                }
                            }
                            return "手术记录提交时间前一天必须有一次病程记录";
                        }
                    }
                }
            }
            else
            {
                if (ds_before_operation.Tables[0].Rows.Count < ds_operation.Tables[0].Rows.Count)
                {
                    return "每次手术记录前最少要有一份术前小结！";
                }
                if (operation_time.ToShortDateString() == in_time.ToShortDateString())
                {
                    return "";
                }
                DataSet ds_medical_record = App.GetDataSet(sql_medical_recodr);
                if (ds_medical_record != null)
                {
                    if (ds_medical_record.Tables.Count > 0)
                    {
                        if (ds_medical_record.Tables[0].Rows.Count == 0)
                        {
                            return "手术记录提交时间前一天必须有一次病程记录！";
                        }
                        else
                        {
                            for (int i = 0; i < ds_medical_record.Tables[0].Rows.Count; i++)
                            {
                                string doc_name = ds_medical_record.Tables[0].Rows[i]["doc_name"].ToString();
                                medical_time = Convert.ToDateTime(App.GetTimeString(doc_name));
                                if (medical_time.AddHours(24).ToShortDateString() == operation_time.ToShortDateString())
                                {
                                    return "";
                                }
                            }
                            return "手术记录提交时间前一天必须有一次病程记录";
                        }
                    }
                }
            }
            return "";
        }


        /// <summary>
        /// 术前小结
        /// </summary>
        /// <param name="tittle_time">标题时间</param>
        /// <param name="doc_tittle">文书标题</param>
        /// <param name="in_time">入院时间</param>
        /// <returns></returns>
        public static string Before_Operation_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time)
        {
            if (doc_tittle != "") 
            {
                try
                {
                    tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                }
                catch
                {
                    return "术前小结标题时间不标准";
                }
            }
            if (in_time < tittle_time || in_time == tittle_time)
            {
                return "";
            }
            else
            {
                return "入院时间应该小于等于文书标题时间";
            }
            //return "";
        }
    }
}
