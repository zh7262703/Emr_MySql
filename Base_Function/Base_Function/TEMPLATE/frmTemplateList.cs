using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using System.IO;
namespace Base_Function.TEMPLATE
{
    public partial class frmTemplateList : DevComponents.DotNetBar.Office2007Form
    {

        private string loadContent;
        public string LoadContent
        {
            get { return loadContent; }
            set { loadContent = value; }
        }

        private string templateId;
        public string TemplateId
        {
            get { return templateId; }
            set { templateId = value; }
        }

        private string temptype;

        public string Temptype
        {
            get { return temptype; }
            set { temptype = value; }
        }
       

        public frmTemplateList()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        public frmTemplateList(string Tid)
        {
            InitializeComponent();
            ucTempList_Big1.Section_id= App.UserAccount.CurrentSelectRole.Section_Id;            
            ucTempList_Big1.Kindtid=Tid;
            App.UsControlStyle(this);
        }

        private void frmTemplateList_Load(object sender, EventArgs e)
        {
            this.loadContent = string.Empty;

        }



        private void btnSure_Click(object sender, EventArgs e)
        { 
            string content = "";
            string temp = "";

            if (tabControl1.SelectedTabIndex == 0)
            {
                temp = "select Content from T_TempPlate_Cont where tid=" + ucTempList_Big1.Tid;
                this.TemplateId = ucTempList_Big1.Tid;
                this.Temptype = "B";             
            }
            else
            {
                temp = "select Content from T_TempPlate_Cont where tid=" +ucTempList_Small1.Tid;
                this.TemplateId = ucTempList_Small1.Tid;
                this.Temptype = "S"; 
            }
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp != null)
            {
                DataTable dtTemp = dsTemp.Tables[0];

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    content = content + dtTemp.Rows[i][0].ToString();
                }
                this.loadContent = content;
               
                this.Close();
            }
            else
            {
                App.MsgWaring("请先选择要插入的模板！");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.loadContent = string.Empty;
            this.Close();
        }

        private void frmTemplateList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("1111");
            //if (chbDefaultSelect.Checked)
            //{
            //    SetInfoToXml();
            //}
            //else
            //{
            //    string path = Application.StartupPath + @"\TemplateList.xml";
            //    if (File.Exists(path))
            //    {
            //        XmlDocument myXml = new XmlDocument();
            //        myXml.Load(path);

            //        //查找TemplateList节点
            //        XmlNode root = myXml.SelectSingleNode("TemplateList");
            //        foreach (XmlNode node in root.ChildNodes)
            //        {
            //            if (node.Attributes["value"].Value == App.UserAccount.Account_id)  //已经存在此账号
            //            {
            //                foreach (XmlNode subNode in node.SelectNodes("Item"))
            //                {
            //                    if (subNode.Attributes["value"].Value == tid)    //Item节点已经存在
            //                    {
            //                        //subNode.RemoveAll();
            //                        node.RemoveChild(subNode);
            //                        myXml.Save(path);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}