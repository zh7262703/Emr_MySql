using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using System.Xml;
using Bifrost;
using DevComponents.AdvTree;
using TextEditor;
using Base_Function.BASE_COMMON;

namespace Base_Function.Digital_Medical_Treatment
{
    public partial class frmDoctorBookGet : DevComponents.DotNetBar.Office2007Form
    {
        //病人住院号
        private string Pid;
        public event Bifrost_Doctor.Consultation_Manager.frmConsultation_Apply.GetDocContent Event_GetContent;
        frmText text = null;
        frmText text2 = null;


        /// <summary>
        /// 病人id号
        /// </summary>
        private int patient_Id;
        public frmDoctorBookGet()
        {
            InitializeComponent();
        }
        public frmDoctorBookGet(string pid,int patient_Id,frmText Mtext)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            this.Pid = pid;
            this.patient_Id = patient_Id;
            ReflashBookTreeByPatientID(trvDoctorBook);
            RefTreeView();
            text = Mtext;
            text2 = new frmText();
            text2.Dock = DockStyle.Fill;
            splitContainerVertical.Panel2.Controls.Add(text2);
           
        }
        private void frmDoctorBook_Load(object sender, EventArgs e)
        {
            trvDoctorBook.ExpandAll();
        }
        /// <summary>
        /// 刷新病人文书
        /// </summary>
        private void ReflashTrvBook()
        {
            Node node = null;
            node = DataInit.SelectDoc(patient_Id);           //得到该病人的所有文书
            if (node != null)
            {
                trvDoctorBook.Nodes.Clear();
                /*
                 * 将该病人的文书添加到具体的文书类型下面
                 */
                foreach (Node ChildNode in node.Nodes)
                {
                    GetPatientDoc(trvDoctorBook.Nodes, ChildNode);
                }
            }
        }
        public void GetPatientDoc(NodeCollection nodes, Node node)
        {
            Patient_Doc doc = node.Tag as Patient_Doc;
            foreach (Node TempNode in nodes)
            {
                Class_Text text = TempNode.Tag as Class_Text;
                if (text != null)
                {
                    if (text.Issimpleinstance == "1")   //多例文书
                    {
                        if (doc.Textkind_id == text.Id)
                        {
                            TempNode.Nodes.Add(node.DeepCopy());
                            //TempNode.SelectedImageIndex = 6;
                            //TempNode.ImageIndex = 6;
                            break;
                        }
                    }
                    else
                    {
                        if (TempNode.Nodes.Count == 0)
                        {
                            if (doc.Textkind_id == text.Id)
                            {
                                //TempNode.SelectedImageIndex = 7;
                                TempNode.ImageIndex = 7;
                                break;
                            }
                        }
                    }
                }
                if (TempNode.Nodes.Count > 0)
                    GetPatientDoc(TempNode.Nodes, node);
            }
        }
        
        private void trvDoctorBook_DoubleClick(object sender, EventArgs e)
        {
            XmlDocument tempXml = new XmlDocument();
            string xml=null;
            if (trvDoctorBook.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                Class_Text text = this.trvDoctorBook.SelectedNode.Tag as Class_Text;
               
                if (text.Issimpleinstance == "1")           //多例 
                {
                    StringBuilder strBuilder = new StringBuilder();
                    int i = 1;
                    foreach(Node node in trvDoctorBook.SelectedNode.Nodes)
                    {
                        Patient_Doc pDoc = node.Tag as Patient_Doc;
                        xml = GetSelectNodes(pDoc);
                        if (xml != null)
                        {
                            tempXml.LoadXml(xml);
                            //XmlNode xmlNode = tempXml.GetElementsByTagName("text")[0];
                            //strBuilder.Append(text.Textname + ":子文书" + i.ToString() + "\r\n" + xmlNode.InnerText + "\r\n");
                            //i++;
                            text2.MyDoc.FromXML(tempXml.DocumentElement);
                        }
                    }
                    //txtContent.Text = strBuilder.ToString();
                }
                else
                {
                     xml= GetSelectNodes(text);
                     if (xml != null)
                     {
                         tempXml.LoadXml(xml);
                         //XmlNode xmlNode = tempXml.GetElementsByTagName("text")[0];
                         ////txtContent.Text = xmlNode.InnerText;
                         text2.MyDoc.FromXML(tempXml.DocumentElement);
                     }
                }
            }
            else if (trvDoctorBook.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {
                Patient_Doc pDoc = this.trvDoctorBook.SelectedNode.Tag as Patient_Doc;
                xml = GetSelectNodes(pDoc);
                 if (xml != null)
                 {
                     tempXml.LoadXml(xml);
                     //XmlNode xmlNode = tempXml.GetElementsByTagName("text")[0];
                     //txtContent.Text = xmlNode.InnerText;
                     text2.MyDoc.FromXML(tempXml.DocumentElement);
                 }
            }
        }

        /// <summary>
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
        private string GetSelectNodes(Class_Text text)
        {
            string sql = "select tid from t_patients_doc where patient_id='" + patient_Id + "' and textkind_id=" + text.Id + "";
            DataSet ds = App.GetDataSet(sql);
            string arrs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string content=App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", patient_Id.ToString());
                        if (content == "")
                        {
                            content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                        }
                        arrs += content;
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
        private string GetSelectNodes(Patient_Doc text)
        {
            string arrs = null;
            if (text!=null)
            {
                string sql = "select tid,textname from t_patients_doc where patient_id='" + patient_Id + "' and tid=" + text.Id + "";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string content = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", patient_Id.ToString());
                            if (content == "")
                            {
                                content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            }
                            arrs += content;//dt.Rows[i]["patients_doc"].ToString();
                        }
                    }
                }
            }
            return arrs;
        }

        /// <summary>
        ///  显示所有文书
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(AdvTree trvBook)
        {
            //查出所有文书
            string SQl = "select a.* from t_text ";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);
            Node tn = new Node();
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Id == 103)//住院病程记录
                    {
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            DataInit.SetTreeView(Directionarys, tn);   //插入文书的子类文书。
                        }
                    }
                }
            }
            trvBook.Nodes.Add(tn);
        }


        /// <summary>
        /// 显示医生已写的病程文书
        /// </summary>
        /// <param name="trvBook"></param>
        private void ReflashBookTreeByPatientID(AdvTree trvBook)
        {
            //查出所有文书
            string SQl = "select a.* from t_text a where  a.id in(select b.textkind_id from t_patients_doc b where b.patient_id='" + patient_Id + "') order by shownum asc ";
            //string SQl = "select * from T_TEXT where enable_flag='Y' and id not in(select distinct parentid from t_text) and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);
          
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    Node tn = new Node();
                    //if (Directionarys[i].Id == 103)//住院病程记录
                    //{
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    //插入顶级节点
                    if (Directionarys[i].Parentid == 0)
                    {
                        DataInit.SetTreeView(Directionarys, tn);   //插入文书的子类文书。
                    }
                    //}
                    trvBook.Nodes.Add(tn);
                }
            }
            

            //DataInit.ReflashBookTree(trvBook);
        }

        private void RefTreeView()
        {
            Node node = null;           
            node = DataInit.SelectDoc(patient_Id);           //得到该病人的所有文书           //得到该病人的所有文书
            if (node != null)
            {
                /*
                 * 将该病人的文书添加到具体的文书类型下面
                 */
                foreach (Node ChildNode in node.Nodes)
                {
                    GetPatientDoc(trvDoctorBook.Nodes, ChildNode);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {                                     
                //text.MyDoc._InsertString(txtContent.Text);
                 this.Close();                          
        }

       
        private void trvDoctorBook_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advTree1_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            //txtContent.Text = "";
            if (trvDoctorBook.SelectedNode.Parent != null)
            {
                XmlDocument tempXml = new XmlDocument();
                if (trvDoctorBook.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                {
                    Class_Text text = this.trvDoctorBook.SelectedNode.Tag as Class_Text;

                    if (text.Issimpleinstance == "1")           //多例 
                    {
                        StringBuilder strBuilder = new StringBuilder();
                        int i = 1;
                        foreach (Node node in trvDoctorBook.SelectedNode.Nodes)
                        {
                            Patient_Doc pDoc = node.Tag as Patient_Doc;
                            string xml = GetSelectNodes(pDoc);
                            if (xml != null && xml != string.Empty)
                            {
                                tempXml.LoadXml(xml);
                                StringBuilder builder = new StringBuilder();
                                XmlNodeList xmlNodes = tempXml.SelectNodes("emrtextdoc/body/span");
                                tempXml.GetElementsByTagName("span");
                                foreach (XmlNode childNode in xmlNodes)
                                {
                                    builder.Append(childNode.InnerText);
                                }
                                strBuilder.Append(text.Textname + ":子文书" + i.ToString() + "\r\n" + builder.ToString() + "\r\n");
                                i++;
                            }
                        }
                        //txtContent.Text = strBuilder.ToString();
                    }
                    else
                    {
                        string xml = GetSelectNodes(text);
                        if (xml != null && xml != string.Empty)
                        {
                            tempXml.LoadXml(xml);
                            XmlNodeList xmlNodes = tempXml.SelectNodes("emrtextdoc/text"); //body/span
                            foreach (XmlNode node in xmlNodes)
                            {
                                //txtContent.Text += node.InnerText +"\r\n";
                            }
                        }
                    }
                }
                else if (trvDoctorBook.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    Patient_Doc pDoc = this.trvDoctorBook.SelectedNode.Tag as Patient_Doc;
                    string xml = GetSelectNodes(pDoc);
                    if (xml != null && xml != string.Empty)
                    {
                        tempXml.LoadXml(xml);
                        XmlNodeList xmlNodes = tempXml.SelectNodes("emrtextdoc/body/span");
                        foreach (XmlNode node in xmlNodes)
                        {
                            //txtContent.Text += node.InnerText;
                        }
                    }
                }
            }
        }

    }
}