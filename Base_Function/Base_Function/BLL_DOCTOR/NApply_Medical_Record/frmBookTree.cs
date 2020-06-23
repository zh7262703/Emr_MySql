using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using TextEditor;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class frmBookTree : DevComponents.DotNetBar.Office2007Form
    {
        public frmBookTree()
        {
            InitializeComponent();
        }       
        private frmText text;
        private string Pid;
        private string patient_Id;
        private InPatientInfo inPatient;
        public frmBookTree(string pid,InPatientInfo inpatient)
        {
            InitializeComponent();
            text = new frmText();
            text.BringToFront();
            this.Controls.Add(text);
            text.Dock = DockStyle.Fill;
            text.BringToFront();
            InitTree(inpatient.Patient_Id);
            this.Pid = pid;
            inPatient = inpatient;
            patient_Id = inpatient.Patient_Id;
        }
        private void InitTree(string pid)
        {
            string sql = "select a.id,a.textname,b.tid,a.issimpleinstance,b.textname as Child_TextName from t_text a" +
                         " inner join t_patients_doc b on a.id = b.textkind_id" +
                         " where b.patient_Id='" + pid + "'";
            DataSet ds = App.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tempNode = new TreeNode();
                tempNode.Name = dt.Rows[i]["id"].ToString();
                tempNode.Text = dt.Rows[i]["textname"].ToString();
                tempNode.Tag = dt.Rows[i]["issimpleinstance"].ToString();
                if (!IsSame(tempNode.Name, trvBook.Nodes))
                {
                    trvBook.Nodes.Add(tempNode);
                }
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["issimpleinstance"].ToString() == "1")
                {
                    TreeNode node = new TreeNode();
                    node.Name = dt.Rows[j]["tid"].ToString();
                    node.Text = dt.Rows[j]["Child_TextName"].ToString();
                    for (int k = 0; k < trvBook.Nodes.Count; k++)
                    {
                        if (trvBook.Nodes[k].Name == dt.Rows[j]["id"].ToString())
                        {
                            trvBook.Nodes[k].Nodes.Add(node);
                            break;
                        }
                    }
                }
            }
        }
        public bool IsSame(string id, TreeNodeCollection nodes)
        {
            bool flag = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name == id)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private void trvBook_AfterSelect(object sender, TreeViewEventArgs e)
        {
            text.MyDoc.ClearContent();
            text.setNewDoc(Convert.ToInt32(trvBook.SelectedNode.Name), 0, 0, "", 0, inPatient, false);
            //text.setNewDoc(Pid,Convert.ToInt32(trvBook.SelectedNode.Name), 0, 0, "", 0, "", Pid,
            //               "", "", "住院病程", false);
            text.MyDoc.Us.Tid = 1; //0增加 文书id 修改
            text.MyDoc.Us.RecordText = App.UserAccount.CurrentSelectRole.Section_name + " " + App.UserAccount.UserInfo.User_name; //节点名称
            text.MyDoc.Us.RecordTime = string.Format("{0:g}", App.GetSystemTime()); //记录时间
            string xmlDoc = GetXml();
            if (xmlDoc != null)
            {
                XmlDocument tempXml = new XmlDocument();
                tempXml.LoadXml(xmlDoc);
                text.MyDoc.FromXML(tempXml.DocumentElement);
                text.MyDoc.ContentChanged();
                text.Enabled = false;
            }
        }

        private string GetXml()
        {
            string xml = null;
            if (trvBook.SelectedNode.Parent==null)
            {
                if (trvBook.SelectedNode.Tag.ToString() == "1")           //多例 
                {
                    if (trvBook.SelectedNode.Nodes.Count > 1)
                    {
                        StringBuilder strBuilder = new StringBuilder();
                        foreach (TreeNode node in trvBook.SelectedNode.Nodes)
                        {
                            string spiltXml = GetSelectNodes_Pdoc(node.Name);
                            XmlDocument childXml = new XmlDocument();
                            childXml.PreserveWhitespace = true;
                            childXml.LoadXml(spiltXml);
                            strBuilder.Append(childXml.GetElementsByTagName("body")[0].InnerXml);
                        }
                        XmlDocument tempXml = new XmlDocument();
                        tempXml.PreserveWhitespace = true;
                        tempXml.LoadXml("<emrtextdoc/>");
                        text.MyDoc.ToXML(tempXml.DocumentElement);

                        XmlNode xmlNode = tempXml.SelectSingleNode("emrtextdoc");
                        foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                        {
                            if (bodyNode.Name == "body")
                            {
                                bodyNode.InnerXml = strBuilder.ToString();
                            }
                        }

                        xml = tempXml.InnerXml;
                    }
                    else
                    {
                        xml = GetSelectNodes_Pdoc(trvBook.SelectedNode.Name);
                    }
                }
                else
                {
                    xml = GetSelectNodes(trvBook.SelectedNode.Name);
                }
            }
            else
            {
                xml = GetSelectNodes_Pdoc(trvBook.SelectedNode.Name);
            }
            return xml;
        }
        /// <summary>
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
        private string GetSelectNodes(string id)
        {
            string sql = "select patients_doc from t_patients_doc where patient_Id='" + patient_Id + "' and textkind_id=" + id + "";
            DataSet ds = App.GetDataSet(sql);
            string arrs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        arrs += dt.Rows[i]["patients_doc"].ToString();
                    }
                }
            }
            return arrs;
        }

        /// <summary>
        /// 获得当前节点病人文书
        /// </summary>
        /// <param name="nodes">当前节点下的文书内容</param>
        /// <returns>返回Patient_Doc</returns>
        private string GetSelectNodes_Pdoc(string tid)
        {
            string arrs = null;
            if (text != null)
            {
                string sql = "select patients_doc,textname from t_patients_doc where pid='" + Pid + "' and tid=" + tid+ "";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            arrs += dt.Rows[i]["patients_doc"].ToString();
                        }
                    }
                }
            }
            return arrs;
        }

        private void frmBookTree_Load(object sender, EventArgs e)
        {

        }


    }
}