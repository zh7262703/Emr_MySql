using System;
using System.Collections.Generic;
using System.Text;
using TextEditor.TextDocument.Document;
using System.Xml;
using System.Drawing;
using System.Data;
using Bifrost;
using TextEditor;
using System.Collections;

namespace Base_Function.BLL_DIAGNOSE
{
    public class DiagnoseAction
    {
//        static string sql = @"select id,to_char(fix_time,'yyyy-mm-dd') fix_time,to_char(fix_time,'yyyy-mm-dd') fix_time2,diagnose_name, diagnose_sort,
//                                SYMPTOMS_NAME,SYMPTOMS_CODE,fssx_id, yjsx_id, ejsx_id, sjsx_id, fssx_name, yjsx_name, ejsx_name, sjsx_name,
//                                (fssx_id||'/'||yjsx_id||'/'||ejsx_id||'/'||sjsx_id) qm ,tu.guid_doctor_id
//                                from t_diagnose_item  t left join t_userinfo tu on t.fssx_id=tu.user_id
//                                where diagnose_type = '{2}' and patient_id = '{0}' and is_chinese = '{1}' order by fix_time,diagnose_sort";
        static string sql = @"select id,to_char(fix_time,'yyyy-mm-dd') fix_time,to_char(fix_time,'yyyy-mm-dd') fix_time2,diagnose_name, diagnose_sort,
                                        SYMPTOMS_NAME,SYMPTOMS_CODE,fssx_id, yjsx_id, ejsx_id, sjsx_id, fssx_name, yjsx_name, ejsx_name, sjsx_name,
                                        (fssx_id||'/'||yjsx_id||'/'||ejsx_id||'/'||sjsx_id) qm ,tu.guid_doctor_id
                                        from t_diagnose_item  t left join t_userinfo tu on t.create_id=tu.user_id
                                        where diagnose_type = '{2}' and patient_id = '{0}' and is_chinese = '{1}' order by fix_time,diagnose_sort";
        static string sql2 = "select id, trend_diagnose_name, sort_sequence, parent_id from t_trend_diagnose where parent_id = '{0}' order by sort_sequence";
        /// <summary>
        /// 诊断转换成 string
        /// </summary>
        /// <param name="document">编辑器对象</param>
        /// <param name="diagnoseType">诊断类型</param>
        /// <param name="title">文本框名称</param>
        /// <returns>适用编辑器诊断xml字符串</returns>
        public static string GetDiagnoseToStr(ZYTextDocument document, string diagnoseType, string title, string divname, string patient_id, bool EnableTime, string TimeName)
        {
            string text1 = "<span>{0}</span>";
            string text2 = "<p leftchars = '{0}' />";
            string text3 = "<span>                         </span><input candelete=\"1\" name=\"诊断医师签名\" id=\"{1}\">        {0}</input>";
            string text4 = "<input candelete=\"1\" name=\"诊断日期\">{0}</input>";
            string text5 = "<p />";
            string text6 = "<p align =\"{0}\" />";
            StringBuilder strb = new StringBuilder();
            SizeF ef = document.View.Graph.MeasureString("一", document.View.DefaultFont, 1000, StringFormat.GenericTypographic);
            int titleWhiteSpace1 = Convert.ToInt32(ef.Width * 2);
            int titleWhiteSpace = Convert.ToInt32(ef.Width * 7.5);
            int haveChineseDiagnose = Convert.ToInt32(ef.Width * 4.5);
            int twoCharSize = 0;
            List<Diagnose_item> diagnoseList = GetDiagnose(patient_id, diagnoseType);
            int x = 1;
            bool haveZX = false;
            if (diagnoseList.Count > 0)
            {
                //string TextKind = ",294,400,1876,151,1929,297,286,1878,316,327,6988544,132,523,6988518,500,509,284,296,510,891,1877,300,308,306,285,288,301,426,1624,136,130,131,47847151,333,362,1875,291,427,512,368,890,287,319,47553058,2147099025,158,126,127,312,313,295,338,";
                string TextKind = ",6988518,284,";
                string TextKind_id = "," + document.Us.TextKind_id + ",";
                //加入div中name属性值展示
                if (divname != "")
                    strb.Append("<span fontbold=\"1\">" + divname + "</span><p operatercreater=\"0\"/>");
                Diagnose_item oldItem = new Diagnose_item();
                string oldQmId = string.Empty;
                string oldQmName = string.Empty;
                for (int i = 0; i < diagnoseList.Count; i++)
                {
                    string fsQm = string.Empty;
                    string yjQm = string.Empty;
                    string ejQm = string.Empty;
                    string sjQm = string.Empty;

                    string fsId = string.Empty;
                    string yjId = string.Empty;
                    string ejId = string.Empty;
                    string sjId = string.Empty;
                    
                    Diagnose_item item = diagnoseList[i];
                    if (item.Lever == 0)
                    {
                        if (string.IsNullOrEmpty(fsQm) && !string.IsNullOrEmpty(item.fssx_name))
                        {
                            fsQm = item.fssx_name;
                            fsId = item.fssx_id;
                        }

                        if (string.IsNullOrEmpty(yjQm) && !string.IsNullOrEmpty(item.yjsx_name))
                        {
                            yjQm = item.yjsx_name;
                            yjId = item.yjsx_id;
                        }


                        if (string.IsNullOrEmpty(ejQm) && !string.IsNullOrEmpty(item.ejsx_name))
                        {
                            ejQm = item.ejsx_name;
                            ejId = item.ejsx_id;
                        }

                        if (string.IsNullOrEmpty(sjQm) && !string.IsNullOrEmpty(item.sjsx_name))
                        {
                            sjQm = item.sjsx_name;
                            sjId = item.sjsx_id;
                        }
                        if (TextKind.Contains(TextKind_id))
                        {//入院记录中诊断带签名(顺序:高到底- 三级,二级,一级,附属),

                            StringBuilder qmBuilder = new StringBuilder();
                            StringBuilder qmIdBuilder = new StringBuilder();


                            if (!string.IsNullOrEmpty(sjQm))
                            {
                                qmBuilder.Append("/");
                                qmBuilder.Append(sjQm);
                                qmIdBuilder.Append("/");
                                qmIdBuilder.Append(sjId);
                            }

                            if (!string.IsNullOrEmpty(ejQm))
                            {
                                qmBuilder.Append("/");
                                qmBuilder.Append(ejQm);
                                qmIdBuilder.Append("/");
                                qmIdBuilder.Append(ejId);
                            }

                            if (!string.IsNullOrEmpty(yjQm))
                            {
                                qmBuilder.Append("/");
                                qmBuilder.Append(yjQm);
                                qmIdBuilder.Append("/");
                                qmIdBuilder.Append(yjId);
                            }

                            if (!string.IsNullOrEmpty(fsQm))
                            {
                                qmBuilder.Append("/");
                                qmBuilder.Append(fsQm);
                                qmIdBuilder.Append("/");
                                qmIdBuilder.Append(fsId);
                            }


                            if (!string.IsNullOrEmpty(qmBuilder.ToString()))
                            {
                                qmBuilder.Remove(0, 1);
                                qmIdBuilder.Remove(0, 1);
                            }

                            if (!string.IsNullOrEmpty(oldQmName) && (oldItem.fix_time != item.fix_time || oldItem.qm != item.qm || (oldItem.qm == "/0//" && item.qm == "/0//" && item.yjsx_name != oldItem.yjsx_name)))//|| item.yjsx_name != oldItem.yjsx_name)) // && item.qm=='\0' && 
                            {
                                //if (title == "确定诊断")
                                ////if (title == "初步诊断")
                                //{
                                //    strb.Append(string.Format(text1, "确诊医师："));
                                //}
                                //else
                                //{
                                //    strb.Append(string.Format(text1, "医师签名："));
                                //}
                                if (item.yjsx_name != oldItem.yjsx_name || oldItem.fix_time != item.fix_time)
                                {
                                    strb.Append(string.Format(text3, oldQmName, oldQmId));
                                    strb.Append(text5);
                                    if (EnableTime)
                                    {
                                        strb.Append(string.Format(text4, oldItem.fix_time));
                                    }
                                    strb.Append(string.Format(text6, "1"));
                                    oldQmId = string.Empty;
                                    oldQmName = string.Empty;
                                }

                            }

                            oldQmId = qmIdBuilder.ToString();
                            oldQmName = qmBuilder.ToString();
                            oldItem = item;

                        }
                    }

                    if (item.ZyStart)
                    {
                        twoCharSize = Convert.ToInt32(ef.Width * 4);
                        haveZX = true;
                        x++;
                    }

                    string diagNose = item.DiagnoseName.Trim();

                    //签名诊断排列对齐
                    //if (i == 0) { strb.Append(string.Format(text1, diagNose)); } else
                    //{
                        strb.Append(string.Format(text1, "<span>      </span>" + diagNose));
                    //}
                    
                    int marginLeftWidth = titleWhiteSpace;//(item.Lever * Convert.ToInt32(ef.Width) * 2 + ((x == 2 && item.Lever == 0) ? Convert.ToInt32(ef.Width) : 0) + titleWhiteSpace + (item.ZyStart ? 0 : twoCharSize));
                    int marginLeftWidth1 = titleWhiteSpace1;
                    if (item.Lever > 0)
                    {
                        if (TextKind.Contains(TextKind_id))
                        {
                            marginLeftWidth1 += (item.Lever * Convert.ToInt32(ef.Width) * 2);
                        }
                        else 
                        {
                            marginLeftWidth += (item.Lever * Convert.ToInt32(ef.Width) * 2);
                        }
                    }
                    if (haveZX && item.ZyStart == false)
                    {
                        marginLeftWidth += haveChineseDiagnose;
                    }
                    //strb.Append(string.Format(text2, marginLeftWidth));
                    if (TextKind.Contains(TextKind_id))
                    {
                        strb.Append(string.Format(text2, marginLeftWidth1));
                    }
                    else 
                    {
                        strb.Append(string.Format(text2, marginLeftWidth));
                    }
                }

                if (TextKind.Contains(TextKind_id))
                {
                    //if (title == "确定诊断")
                    //{
                    //    strb.Append(string.Format(text1, "确诊医师："));
                    //}
                    //else
                    //{
                    //    strb.Append(string.Format(text1, "医师签名："));
                    //}
                    strb.Append(string.Format(text3, oldQmName.ToString(), oldQmId.ToString()));
                    //strb.Append(text5);
                    if (EnableTime)
                    {
                        strb.Append(string.Format(text4, oldItem.fix_time));
                        
                    }
                    strb.Append(string.Format(text6, "1"));
                }
            }
            return strb.ToString();
        }

        /// <summary>
        /// 将诊断转换成编辑器元素
        /// </summary>
        /// <param name="document">编辑器对象</param>
        /// <param name="diagnoseType">诊断类型</param>
        /// <param name="title">诊断title</param>
        /// <param name="patient_id">病人ID</param>
        /// <returns>诊断元素集合</returns>
        public static ArrayList GetDiagnoseToElement(ZYTextDocument document, string diagnoseType, string title, string divname, string patient_id, bool EnableTime, string TimeName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.PreserveWhitespace = true;
            StringBuilder strb = new StringBuilder();
            strb.Append("<emrtextdocument2005>");
            strb.Append(GetDiagnoseToStr(document, diagnoseType, title, divname, patient_id, EnableTime, TimeName));
            strb.Append("</emrtextdocument2005>");
            ArrayList myList = new ArrayList();
            xmlDocument.LoadXml(strb.ToString());
            document.LoadElementsToList(xmlDocument.DocumentElement, myList);
            return myList;
            //return null;
        }

        public static string GetDiagnoseToInputText(string patient_id, string diagnoseType)
        {
            List<Diagnose_item> diagnoseList = GetDiagnose(patient_id, diagnoseType);
            StringBuilder strb = new StringBuilder();
            int diagnoseLength = diagnoseList.Count;
            if (diagnoseLength > 0)
            {
                Dictionary<int, int> lever = new Dictionary<int, int>();
                for (int i = 0; i < diagnoseLength; i++)
                {
                    Diagnose_item iterm = diagnoseList[i];
                    strb.Append(iterm.DiagnoseName);
                    if (i == diagnoseLength - 1)
                        strb.Append("。");
                    else
                        strb.Append("；");
                }
            }
            return strb.ToString();
        }

        public static List<Diagnose_item> GetDiagnose(string patient_id, string diagnoseType)
        {
            List<Diagnose_item> diagnoseList = new List<Diagnose_item>();
            //查询中医诊断
            DataTable cnDiagnoseTable = App.GetDataSet(string.Format(sql, patient_id, "Y", diagnoseType)).Tables[0];
            DataTable amDiagnoseTable = App.GetDataSet(string.Format(sql, patient_id, "N", diagnoseType)).Tables[0];
            bool haveCnDiagnose = false;

            if (cnDiagnoseTable != null && cnDiagnoseTable.Rows.Count > 0)
            {
                haveCnDiagnose = true;
            }
            if (amDiagnoseTable != null && amDiagnoseTable.Rows.Count > 0)
            {
                int count1 = 1;
                foreach (DataRow row in amDiagnoseTable.Rows)
                {
                    Diagnose_item item = new Diagnose_item();
                    string diagnose_name = row["diagnose_name"].ToString();
                    if (haveCnDiagnose && count1 == 1)
                    {
                        item.DiagnoseName = "西医诊断:" + (cnDiagnoseTable.Rows.Count > 0 ? count1.ToString() + "." : "") + diagnose_name;
                        item.ZyStart = true;
                    }
                    else
                    {
                        if (amDiagnoseTable.Rows.Count > 1)
                            item.DiagnoseName = count1.ToString() + "." + diagnose_name;
                        else
                            item.DiagnoseName = diagnose_name;

                        //item.DiagnoseName = count1.ToString() + "." + diagnose_name;
                    }
                    item.fixDiagnoseName = diagnose_name;

                    item.Lever = 0;
                    item.Index = count1;

                    item.fssx_id = row["fssx_id"].ToString();
                    item.fssx_name = row["fssx_name"].ToString();

                    item.yjsx_id = row["yjsx_id"].ToString();
                    item.yjsx_name = row["yjsx_name"].ToString();

                    item.ejsx_id = row["ejsx_id"].ToString();
                    item.ejsx_name = row["ejsx_name"].ToString();

                    item.sjsx_id = row["sjsx_id"].ToString();
                    item.sjsx_name = row["sjsx_name"].ToString();
                    item.fix_time = row["fix_time2"].ToString();
                    item.qm = row["qm"].ToString();

                    if (!String.IsNullOrEmpty(item.fssx_id))
                    {
                        //string djys = row["guid_doctor_id"].ToString();
                        if (!String.IsNullOrEmpty(item.yjsx_id) || !String.IsNullOrEmpty(item.ejsx_id) || !String.IsNullOrEmpty(item.sjsx_id))
                        {//跟袁驰确认:附属账号下达诊断，则三级医师有审签才给予显示
                            diagnoseList.Add(item);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        diagnoseList.Add(item);
                    }
                    DataTable trendDiagnose = App.GetDataSet(string.Format(sql2, row["id"].ToString())).Tables[0];
                    if (trendDiagnose != null && trendDiagnose.Rows.Count > 0)
                    {
                        int index = 0;
                        foreach (DataRow trendRow in trendDiagnose.Rows)
                        {
                            Diagnose_item trendItem = new Diagnose_item();
                            string trend_diagnose_name = trendRow["trend_diagnose_name"].ToString();
                            trendItem.DiagnoseName = (trendDiagnose.Rows.Count > 0 ? (index + 1).ToString() + "）" : "") + trend_diagnose_name;
                            trendItem.Lever = 1;
                            trendItem.Index = index + 1;
                            diagnoseList.Add(trendItem);
                            AddTrendDiagnose(trendRow["id"].ToString(), diagnoseList, 1);
                            index++;
                        }
                    }
                    count1++;
                }
            }

            if (cnDiagnoseTable != null && cnDiagnoseTable.Rows.Count > 0)
            {
                int count1 = 1;
                foreach (DataRow row in cnDiagnoseTable.Rows)
                {
                    Diagnose_item item = new Diagnose_item();
                    string diagnose_name = row["diagnose_name"].ToString();
                    if (count1 == 1)
                    {
                        item.DiagnoseName = "中医诊断:" + (cnDiagnoseTable.Rows.Count > 0 ? count1.ToString() + "." : "") + diagnose_name;
                        item.ZyStart = true;
                    }
                    else
                    {
                        item.DiagnoseName = count1.ToString() + "." + diagnose_name;
                    }
                    item.fixDiagnoseName = diagnose_name;

                    item.Lever = 0;
                    item.Index = count1;

                    item.fssx_id = row["fssx_id"].ToString();
                    item.fssx_name = row["fssx_name"].ToString();

                    item.yjsx_id = row["yjsx_id"].ToString();
                    item.yjsx_name = row["yjsx_name"].ToString();

                    item.ejsx_id = row["ejsx_id"].ToString();
                    item.ejsx_name = row["ejsx_name"].ToString();

                    item.sjsx_id = row["sjsx_id"].ToString();
                    item.sjsx_name = row["sjsx_name"].ToString();

                    item.fix_time = row["fix_time2"].ToString();
                    item.qm = row["qm"].ToString();

                    if (!String.IsNullOrEmpty(item.fssx_id))
                    {//诊断内容位于页面左侧，签名位于右侧，如此诊断为附属账号下达，前台内容中不显示出附属账号名字，如附属账号下达诊断，则必须带教医生审签后此诊断生效。
                        string djys = row["guid_doctor_id"].ToString();
                        if (djys == item.yjsx_id || djys == item.ejsx_id || djys == item.sjsx_id)
                        {
                            diagnoseList.Add(item);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        diagnoseList.Add(item);
                    }
                    Diagnose_item item2 = new Diagnose_item();
                    string cnDiagnoseZh = row["SYMPTOMS_NAME"].ToString();
                    if (!string.IsNullOrEmpty(cnDiagnoseZh))
                    {
                        item2.DiagnoseName = cnDiagnoseZh;
                        item2.Lever = 1;
                        item2.Index = 0;
                        diagnoseList.Add(item2);
                    }

                    DataTable trendDiagnose = App.GetDataSet(string.Format(sql2, row["id"].ToString())).Tables[0];
                    if (trendDiagnose != null && trendDiagnose.Rows.Count > 0)
                    {
                        int index = 0;
                        foreach (DataRow trendRow in trendDiagnose.Rows)
                        {
                            Diagnose_item trendItem = new Diagnose_item();
                            string trend_diagnose_name = trendRow["trend_diagnose_name"].ToString();
                            trendItem.DiagnoseName = (trendDiagnose.Rows.Count > 0 ? (index + 1).ToString() + "）" : "") + trend_diagnose_name;
                            trendItem.Lever = 1;
                            trendItem.Index = index + 1;
                            diagnoseList.Add(trendItem);
                            AddTrendDiagnose(trendRow["id"].ToString(), diagnoseList, 1);
                            index++;
                        }
                    }
                    count1++;
                }
            }

            return diagnoseList;
        }

        public static void AddTrendDiagnose(string parent_id, List<Diagnose_item> diagnoseList, int addCount)
        {
            DataTable trendDiagnose = App.GetDataSet(string.Format(sql2, parent_id)).Tables[0];
            if (trendDiagnose != null && trendDiagnose.Rows.Count > 0)
            {
                int index = 0;
                addCount++;
                foreach (DataRow row in trendDiagnose.Rows)
                {
                    Diagnose_item item = new Diagnose_item();
                    string diagnose_name = row["trend_diagnose_name"].ToString();
                    item.DiagnoseName = (trendDiagnose.Rows.Count > 0 ? (index + 1).ToString() + "）" : "") + diagnose_name;
                    item.Lever = addCount;
                    item.Index = index + 1;
                    diagnoseList.Add(item);
                    index++;
                    AddTrendDiagnose(row["id"].ToString(), diagnoseList, addCount);
                }
            }
        }

        public class Diagnose_item
        {
            public string fixDiagnoseName;

            private string _diagnoseName;

            public string DiagnoseName
            {
                get { return _diagnoseName; }
                set { _diagnoseName = value; }
            }

            private string _diagnoseCode;

            public string DiagnoseCode
            {
                get { return _diagnoseCode; }
                set { _diagnoseCode = value; }
            }

            private int _lever;

            public int Lever
            {
                get { return _lever; }
                set { _lever = value; }
            }

            private int _index;

            public int Index
            {
                get { return _index; }
                set { _index = value; }
            }

            private bool zyStart = false;

            public bool ZyStart
            {
                get { return zyStart; }
                set { zyStart = value; }
            }

            public string Fix_time
            {
                get
                {
                    return fix_time;
                }
                set
                {
                    fix_time = value;
                }
            }

            public string qm;
            public string fix_time;
            public string fssx_id;
            public string fssx_name;
            public string yjsx_id;
            public string yjsx_name;
            public string ejsx_id;
            public string ejsx_name;
            public string sjsx_id;
            public string sjsx_name;
        }
    }
}
