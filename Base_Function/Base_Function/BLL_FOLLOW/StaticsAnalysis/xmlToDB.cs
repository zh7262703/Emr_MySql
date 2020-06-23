using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Bifrost;
namespace MyCode
{
    public partial class xmlToDB : Form
    {
        /// <summary>
        /// 将xml格式的内容抽出插入到数据库
        /// </summary>
        public xmlToDB()
        {
            InitializeComponent();    
        }

        XmlDocument xmldocument = new XmlDocument();
        private void getXml()
        {    
    
            xmldocument.Load(Application.StartupPath + "\\183845.xml");
        }

        private void xmlToDB_Load(object sender, EventArgs e)
        {
            getXml();
            xmlSpit(xmldocument);
        }



        private void xmlSpit(XmlDocument xml)
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
                            textBox1.Text += xnname + ":" + xn.InnerText + "\r\n";
                             sql="insert into T_FOLLOW_ELEMENT_CONTENT (element_name,element_code,element_type,element_content,pid,tid,PATIENT_ID) " +
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

        private bool isInsertTable(string name)
        {
            bool flag = false;
            try
            {
                string element_name=name.Trim();
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