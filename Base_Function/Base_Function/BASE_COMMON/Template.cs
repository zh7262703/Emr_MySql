using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using TextEditor;
using System.Xml;
using Base_Function.TEMPLATE;

namespace Base_Function.BASE_COMMON
{
    public class Template
    {
        public static frmText fmT;
        public static frmText fmS;     

        public static void XmlClearInfo(ref XmlDocument document)
        {
            try
            {

                /*
                 * 移除日志
                 */
                XmlNodeList listsavelogs = document.DocumentElement.GetElementsByTagName("savelogs");
                foreach (XmlNode item in listsavelogs)
                {
                    document.DocumentElement.RemoveChild(item);
                    break;
                }

                /*
               * 移除text
               */
                XmlNodeList listtexts = document.DocumentElement.GetElementsByTagName("text");
                foreach (XmlNode item in listtexts)
                {
                    document.DocumentElement.RemoveChild(item);
                    break;
                }


                XmlNodeList list = document.DocumentElement.GetElementsByTagName("input");
                foreach (XmlNode item in list)
                {
                    if (item.Attributes["name"] != null)
                    {
                        string name = item.Attributes["name"].Value;
                        if (name.Contains("医师签名")
                            || name == "上级医师签名"
                            || name == "管床医师签名"
                            || name == "普通护士签名"
                            || name.Contains("诊断")
                            || name.Contains("护士签名")
                            || name == "签名集合"
                             )
                        {
                            item.InnerXml = "";
                            if (item.Attributes["id"] != null)
                            {
                                item.Attributes["id"].Value = "";
                            }
                        }
                        else if (IsClearInput(name))
                        {
                            item.InnerXml = "";
                        }
                    }
                }

                XmlNodeList diagnoseDiv = document.DocumentElement.GetElementsByTagName("div");
                foreach (XmlNode item in diagnoseDiv)
                {
                    if (item.Attributes["title"] != null)
                    {
                        string title = item.Attributes["title"].Value;
                        if (title.Contains("术前诊断")||
                            title.Contains("术后诊断")||
                            title.Contains("初步诊断")||
                            title.Contains("补充诊断")||
                            title.Contains("修正诊断")||
                            title.Contains("出院诊断")||
                            title.Contains("死亡诊断")||
                            title.Contains("入院诊断")||
                            title.Contains("确定诊断")||
                            title.Contains("术中诊断")||
                            title.Contains("术中诊断")||
                            title.Contains("转出诊断")||
                            title.Contains("转入诊断"))
                        {
                            item.InnerXml = "<p operatercreater=\"0\" />";//"<p/>";
                        }

                        if (item.Attributes["sign"] != null)
                        {
                            item.Attributes["sign"].Value = "";
                        }
                    }
                }
            }
            catch
            { }
        }

        public static bool IsClearInput(string inputName)
        {
            if (string.IsNullOrEmpty(inputName))
                return false;
            switch (inputName)
            {
                case "家庭地址":
                case "us_jtdz":
                case "联系电话":
                case "家庭电话":
                case "联系人":
                case "姓名":
                case "us_xm":
                case "出生地":
                case "us_csd":
                case "性别":
                case "us_xb":
                case "民族":
                case "us_mz":
                case "年龄":
                case "us_nl":
                case "入院日期":
                case "us_rysj":
                case "us_ryrq":
                case "记录日期":
                case "us_jlrq":
                case "婚姻":
                case "us_hy":
                case "职业":
                case "us_zy":
                case "单位及职业":
                case "us_dwjzy":
                case "工作单位":
                case "us_gzdw":
                case "住址":
                case "us_jtzz":
                case "us_jg":
                case "籍贯":
                case "初步诊断":
                case "住院号":
                case "us_zyh":
                case "住院日数":
                case "科室":
                case "us_ks":
                case "病区":
                case "us_bq":
                case "床号":
                case "us_ch":
                case "身份证":
                case "us_sfz":
                case "his_id":
                //case "住院号":
                    return true;
            }
            return false;
        }



    }
}
