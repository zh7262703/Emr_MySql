using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using Base_Function.BASE_COMMON;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmEditPanel : DevComponents.DotNetBar.Office2007Form
    {
        private string id;//����ѡ�е�template_id��
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;

        public frmEditPanel()
        {
            InitializeComponent();
        }
        public frmEditPanel(string Id)
        {
            InitializeComponent();
            id = Id;
            panel1.Controls.Add(Template.fmT);
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            InitialEdit();
        }
        public void InitialEdit()
        {
            string temp = "select Content from T_Follow_TempPlate_Cont where tid=" + id;
            DataSet dsTemp = App.GetDataSet(temp);
            DataTable dtTemp = dsTemp.Tables[0];
            string content = "";
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                content = content + dtTemp.Rows[i][0].ToString();
            }
            xmlDoc = new XmlDocument();//����XML����������                
            xmlDoc.PreserveWhitespace = true;
            if (content.Contains("emrtextdoc"))
            {
                xmlDoc.LoadXml(content);
            }
            else
            {
                string strXml = GetXmlContent();
                xmlDoc.LoadXml(strXml);
                xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = content;
                    }
                }
            }
            Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
            Template.fmT.MyDoc.ContentChanged();
        }
        /// <summary>
        /// ����ǰ�༭���е�����ת����xml�������ַ�������ʽ���� �����ڲ������ݿ⣩
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            Template.fmT.MyDoc.IsHaveDeleted = true;
            Template.fmT.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.fmT.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }
        /// <summary>
        /// �����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string temp = GetXmlContent();
            int message = 0;
            try
            {
                string updateLable = "update T_Follow_TempPlate_Cont set Content=:divContent where tid=" + id;
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "divContent";
                xmlPars[0].Value = temp;//bodyNode.InnerXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                xmlPars[0].Direction = ParameterDirection.Input;
                message = App.ExecuteSQL(updateLable, xmlPars);
                if (message > 0)
                {
                    App.Msg("����ɹ�");
                }
                else
                {
                    App.MsgErr("����ʧ��");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,����ԭ��:" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}