using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;
using TextEditor;
using System.Xml;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmBachePrints : DevComponents.DotNetBar.Office2007Form
    {
        public frmBachePrints()
        {
            InitializeComponent();
        }
        //当前病人对象
        InPatientInfo currentPatient;
        //记录全选节点的选中状态
        bool allCheck = false;
        public frmBachePrints(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
        }

        private void frmBachePrints_Load(object sender, EventArgs e)
        {
            try
            {
                //设置文书一级节点
                SetNode();
                //设置文书实例节点
                SelectDoc();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 树节点单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nodeAllChecked_NodeClick(object sender, EventArgs e)
        {
            CheckedAllNode();
        }

        /// <summary>
        /// 树节点双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nodeAllChecked_NodeDoubleClick(object sender, EventArgs e)
        {
            CheckedAllNode();
        }

        /// <summary>
        /// 设置子节点全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedSonNode(object sender, EventArgs e)
        {
            Node currNode = sender as Node;
            if (currNode != null)
            {
                if (currNode.Checked == true)
                {
                    for (int i = 0; i < currNode.Nodes.Count; i++)
                    {
                        currNode.Nodes[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < currNode.Nodes.Count; i++)
                    {
                        currNode.Nodes[i].Checked = false;
                    }
                }
            }
        }
        /// <summary>
        /// 设置全选
        /// </summary>
        private void CheckedAllNode()
        {
            if (allCheck != nodeAllChecked.Checked)
            {
                allCheck = nodeAllChecked.Checked;
                if (nodeAllChecked.Checked)
                {
                    for (int i = 0; i < nodeAllChecked.Nodes.Count; i++)
                    {
                        nodeAllChecked.Nodes[i].Checked = true;
                        if (nodeAllChecked.Nodes[i].Nodes.Count > 0)
                        {
                            for (int j = 0; j < nodeAllChecked.Nodes[i].Nodes.Count; j++)
                            {
                                nodeAllChecked.Nodes[i].Nodes[j].Checked = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < nodeAllChecked.Nodes.Count; i++)
                    {
                        nodeAllChecked.Nodes[i].Checked = false;
                        if (nodeAllChecked.Nodes[i].Nodes.Count > 0)
                        {
                            for (int j = 0; j < nodeAllChecked.Nodes[i].Nodes.Count; j++)
                            {
                                nodeAllChecked.Nodes[i].Nodes[j].Checked = false;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 批量打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                Patient_Doc[] patient_Docs = GetSelectNodes();

                if (patient_Docs != null)
                {
                    //特别注意这里是每一份单独打印而不是像浏览一样的拼接
                    for (int i = 0; i < patient_Docs.Length; i++)
                    {
                        frmText uc = new frmText(0, 0, 0, patient_Docs[i].Textname, -2, currentPatient, true);
                        XmlDocument document = new XmlDocument();
                        document.PreserveWhitespace = true;
                        uc.MyDoc.Locked = true;
                        uc.MyDoc.Section_name = currentPatient.Section_Name;

                        document.LoadXml(patient_Docs[i].Patients_doc);
                        uc.MyDoc.FromXML(document.DocumentElement);
                        uc.MyDoc.print();
                    }
                    //} 
                }
                else
                {
                    App.Msg("请选择至少一份文书再打印！");
                }
            }
            catch (Exception ex)
            {
                App.Msg("请设置默认打印机！");
            }
            this.Close();
        }


        /// <summary>
        /// 获得当前选中节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
        private Patient_Doc[] GetSelectNodes()
        {
            string allTextId = "";
            //if (nodeAllChecked.Checked)
            //{
            for (int i = 0; i < nodeAllChecked.Nodes.Count; i++)
            {
                Class_Text text = nodeAllChecked.Nodes[i].Tag as Class_Text;
                if (text != null)
                {
                    if (text.Issimpleinstance == "1")//多例文书循环子节点获取文书ID
                    {
                        for (int j = 0; j < nodeAllChecked.Nodes[i].Nodes.Count; j++)
                        {
                            if (nodeAllChecked.Nodes[i].Nodes[j].Checked)//节点被选中，获取tid拼接字符串
                            {
                                Patient_Doc pat_doc = nodeAllChecked.Nodes[i].Nodes[j].Tag as Patient_Doc;
                                if (pat_doc != null)
                                {
                                    if (allTextId == "")
                                    {
                                        allTextId = pat_doc.Id.ToString();
                                    }
                                    else
                                    {
                                        allTextId += "," + pat_doc.Id;
                                    }
                                }
                            }
                        }
                    }
                    else //单例文书
                    {
                        if (nodeAllChecked.Nodes[i].Checked)
                        {
                            string docId = isExitRecord(text.Id, currentPatient.Id);
                            if (allTextId == "")
                            {
                                allTextId = docId;
                            }
                            else
                            {
                                allTextId += "," + docId;
                            }
                        }
                    }
                }
            }

            if (allTextId != "")
            {
                Patient_Doc[] patient_Docs = null;
                if (currentPatient != null)
                {
                    string sql_doc = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name from t_patients_doc a" +
                                     " inner join t_text c on a.textkind_id = c.id" +
                                     " where a.tid in(" + allTextId + ")";
                    DataSet ds = App.GetDataSet(sql_doc);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt != null)
                        {
                            //arrs = new string[dt.Rows.Count,2];
                            //去掉相同的文书
                            int tid = 0;
                            patient_Docs = new Patient_Doc[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                                {
                                    patient_Docs[i] = new Patient_Doc();
                                    patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                                    if (patient_Docs[i].Patients_doc == "")
                                    {
                                        patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                                    }
                                    patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                    patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                                    patient_Docs[i].Belongtosys_id = Convert.ToInt32(dt.Rows[i]["issimpleinstance"].ToString());
                                    patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                                    patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                                    patient_Docs[i].Textname = dt.Rows[i]["textname"].ToString();
                                    tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                }

                            }
                        }
                    }
                }
                return patient_Docs;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 设置文书节点
        /// </summary>
        private void SetNode()
        {
            //查出当前病人所有知情同意书类型
            string sql_text = "select * from t_text where id in" +
                            "(select textkind_id from t_patients_doc where textkind_id in(select id from t_text where isbelongtotype=915) and patient_id=" + currentPatient.Id + ")";
            DataSet ds_text = App.GetDataSet(sql_text);
            if (ds_text != null)
            {
                for (int i = 0; i < ds_text.Tables[0].Rows.Count; i++)
                {
                    Node nodeText = new Node();
                    nodeText.Text = ds_text.Tables[0].Rows[i]["textname"].ToString();
                    nodeText.Name = ds_text.Tables[0].Rows[i]["id"].ToString();

                    Class_Text text = new Class_Text();
                    text.Id = Convert.ToInt32(ds_text.Tables[0].Rows[i]["ID"].ToString());
                    if (ds_text.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                    {
                        text.Parentid = Convert.ToInt32(ds_text.Tables[0].Rows[i]["PARENTID"].ToString());
                    }
                    text.Sid = ds_text.Tables[0].Rows[i]["sid"].ToString();
                    text.Textcode = ds_text.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                    text.Textname = ds_text.Tables[0].Rows[i]["TEXTNAME"].ToString();
                    text.Isenable = ds_text.Tables[0].Rows[i]["ISENABLE"].ToString();
                    text.Txxttype = ds_text.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                    text.Issimpleinstance = ds_text.Tables[0].Rows[i]["issimpleinstance"].ToString();
                    text.Ishighersign = ds_text.Tables[0].Rows[i]["ishighersign"].ToString();
                    text.Right_range = ds_text.Tables[0].Rows[i]["right_range"].ToString();
                    text.Ishavetime = ds_text.Tables[0].Rows[i]["ishavetime"].ToString();
                    text.Formname = ds_text.Tables[0].Rows[i]["formname"].ToString();

                    nodeText.Tag = text;
                    nodeText.CheckBoxVisible = true;
                    nodeText.NodeClick += new EventHandler(CheckedSonNode);
                    nodeText.NodeDoubleClick += new EventHandler(CheckedSonNode);
                    nodeAllChecked.Nodes.Add(nodeText);
                }
            }
        }

        /// <summary>
        /// 查询所有知情同意书
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns>返回</returns>
        public void SelectDoc()
        {
            string sql_doc = "select * from t_patients_doc where textkind_id in(select id from t_text where isbelongtotype=915 and issimpleinstance=1) and patient_id=" + currentPatient.Id + " order by tid";
            Node nodeTemp = new Node();
            DataSet ds = App.GetDataSet(sql_doc);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //去掉重复的文书id
                    string tid = "0";
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["tid"].ToString() != "")
                        {
                            if (tid != row["tid"].ToString())
                            {
                                Patient_Doc pDoc = new Patient_Doc();
                                pDoc.Id = Convert.ToInt32(row["tid"]);
                                pDoc.Patient_id = row["patient_Id"].ToString();
                                pDoc.Pid = row["pid"].ToString();

                                if (row["textkind_id"].ToString() != "")
                                    pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);

                                if (row["belongtosys_id"].ToString() != "")
                                    pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                                //pDoc.Patients_doc =row["patients_doc"].ToString();
                                if (row["sickkind_id"].ToString() != "")
                                    pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);

                                pDoc.Docname = row["doc_name"].ToString().TrimStart();
                                pDoc.Textname = row["textname"].ToString().TrimStart();
                                pDoc.Ishighersign = row["ishighersign"].ToString();
                                pDoc.Havehighersign = row["havehighersign"].ToString();
                                pDoc.Havedoctorsign = row["Havedoctorsign"].ToString();
                                pDoc.Submitted = row["submitted"].ToString();
                                pDoc.Createid = row["createId"].ToString();
                                pDoc.Highersignuserid = row["highersignuserid"].ToString();
                                pDoc.Isreplacehighdoctor = row["israplacehightdoctor"].ToString();
                                pDoc.Isreplacehighdoctor2 = row["israplacehightdoctor2"].ToString();
                                pDoc.Section_name = row["SECTION_NAME"].ToString();
                                Node node = new Node();
                                node.Text = pDoc.Docname;
                                node.Tag = pDoc as object;
                                node.Name = pDoc.Id.ToString();
                                node.CheckBoxVisible = true;
                                for (int i = 0; i < nodeAllChecked.Nodes.Count; i++)
                                {
                                    if (nodeAllChecked.Nodes[i].Name == pDoc.Textkind_id.ToString())
                                    {
                                        nodeAllChecked.Nodes[i].Nodes.Add(node);
                                    }
                                }

                                tid = row["tid"].ToString();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 判断该类单例文书是否已经存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

    }
}