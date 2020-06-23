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
                 * �Ƴ���־
                 */
                XmlNodeList listsavelogs = document.DocumentElement.GetElementsByTagName("savelogs");
                foreach (XmlNode item in listsavelogs)
                {
                    document.DocumentElement.RemoveChild(item);
                    break;
                }

                /*
               * �Ƴ�text
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
                        if (name.Contains("ҽʦǩ��")
                            || name == "�ϼ�ҽʦǩ��"
                            || name == "�ܴ�ҽʦǩ��"
                            || name == "��ͨ��ʿǩ��"
                            || name.Contains("���")
                            || name.Contains("��ʿǩ��")
                            || name == "ǩ������"
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
                        if (title.Contains("��ǰ���")||
                            title.Contains("�������")||
                            title.Contains("�������")||
                            title.Contains("�������")||
                            title.Contains("�������")||
                            title.Contains("��Ժ���")||
                            title.Contains("�������")||
                            title.Contains("��Ժ���")||
                            title.Contains("ȷ�����")||
                            title.Contains("�������")||
                            title.Contains("�������")||
                            title.Contains("ת�����")||
                            title.Contains("ת�����"))
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
                case "��ͥ��ַ":
                case "us_jtdz":
                case "��ϵ�绰":
                case "��ͥ�绰":
                case "��ϵ��":
                case "����":
                case "us_xm":
                case "������":
                case "us_csd":
                case "�Ա�":
                case "us_xb":
                case "����":
                case "us_mz":
                case "����":
                case "us_nl":
                case "��Ժ����":
                case "us_rysj":
                case "us_ryrq":
                case "��¼����":
                case "us_jlrq":
                case "����":
                case "us_hy":
                case "ְҵ":
                case "us_zy":
                case "��λ��ְҵ":
                case "us_dwjzy":
                case "������λ":
                case "us_gzdw":
                case "סַ":
                case "us_jtzz":
                case "us_jg":
                case "����":
                case "�������":
                case "סԺ��":
                case "us_zyh":
                case "סԺ����":
                case "����":
                case "us_ks":
                case "����":
                case "us_bq":
                case "����":
                case "us_ch":
                case "���֤":
                case "us_sfz":
                case "his_id":
                //case "סԺ��":
                    return true;
            }
            return false;
        }



    }
}
