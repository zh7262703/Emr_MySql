using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using System.Xml;

namespace Base_Function.BLL_FOLLOW.StaticsAnalysis
{
    class StaticsToDB
    {
        /// <summary>
        /// 遍历Xml文档节点
        /// </summary>
        /// <param name="xml"></param>
        public void xmlSpit(XmlDocument xml)
        {
            try
            {
                XmlNode bodynode = xml.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");
                List<string> sqllist = new List<string>();
                string sql = "";
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["name"] != null)
                    {
                        string xnname = xn.Attributes["name"].Value.ToString().Trim();

                        if (!xnname.Contains("新增的输入域"))
                        {
                            
                            sql = "insert into T_FOLLOW_ELEMENT_CONTENT (element_name,element_code,element_type,element_content,pid,tid,PATIENT_ID) " +
                                      " values ('','" + xnname + "','',0,0,0,0)";
                            sqllist.Add(sql);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isInsertTable(string name)
        {
            bool flag = false;
            try
            {
                string element_name = name.Trim();
                if (element_name.Length > 0)
                {
                    if (name.Contains("新增的输入域"))
                    {
                        flag = false;
                    }
                    else
                    {
                        string sql = "select * from T_FOLLOW_ELEMENT t where code ='" + element_name + "'";
                        if (App.ExecuteSQL(sql) > 0)
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}
