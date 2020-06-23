using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Bifrost;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPLATE
{
    public partial class frmDocument : DevComponents.DotNetBar.Office2007Form
    {
        private Class_Patients_Doc[] patients_Docs;  //文书集合
        private Class_Struct[] docStructs;   //结构集合
        private XmlDocument xmlDoc;     
        private string T_tempplate_struct_Sql; //查询结构化表

        public frmDocument()
        {
            InitializeComponent();
         
        }

        /// <summary>
        /// 将XML内容并展示到编辑器上(读取数据库中的文书，并显示到编辑器上)
        /// </summary>
        /// <param name="temdoc"></param>
        private void IniEditContent(string xmldoc)
        {
            XmlDocument temdoc = new XmlDocument();
            temdoc.LoadXml(xmldoc);
            Template.fmT.MyDoc.FromXML(temdoc.DocumentElement);

            Template.fmT.MyDoc.ContentChanged();
        }

        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.LoadXml("<emrtextdoc/>");   //读取xml文件
            Template.fmT.MyDoc.ToXML(tempxmldoc.DocumentElement);
            return tempxmldoc.OuterXml;
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            groupBox1.Controls.Add(Template.fmT);//编辑器界面嵌入
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            InitDocTree();
        }

       

        /// <summary>
        /// 初始化树节点
        /// </summary>
        private void InitDocTree()
        {
            this.treeView1.Nodes.Clear();
            string temp = "select * from t_patients_doc";
            DataSet dataSet = App.GetDataSet(temp);
            patients_Docs = new Class_Patients_Doc[dataSet.Tables[0].Rows.Count];
            
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                patients_Docs[i] = new Class_Patients_Doc();
                patients_Docs[i].Tid = Convert.ToInt32(dataSet.Tables[0].Rows[i]["TID"].ToString());
                patients_Docs[i].Pid=dataSet.Tables[0].Rows[i]["PID"].ToString();
                patients_Docs[i].TextName = dataSet.Tables[0].Rows[i]["TEXTNAME"].ToString();
                patients_Docs[i].Patients_Doc = dataSet.Tables[0].Rows[i]["PATIENTS_DOC"].ToString();

                TreeNode tnRoot = new TreeNode();
                tnRoot.Tag = patients_Docs[i];
                tnRoot.Text = patients_Docs[i].TextName;
                treeView1.Nodes.Add(tnRoot);
            }
        }

        /// <summary>
        /// 当点击树节点之后 先调用模版初始化编辑区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.treeView2.Nodes.Clear();
            Class_Patients_Doc patients_Doc = (Class_Patients_Doc)treeView1.SelectedNode.Tag;
           // xmlDoc = new XmlDocument();//加入XML的声明段落
            string strXml = patients_Doc.Patients_Doc;
            this.IniEditContent(strXml);

            string temp = "select * from t_struct where tid="+patients_Doc.Tid;
            DataSet dataSet = App.GetDataSet(temp);

            docStructs = new Class_Struct[dataSet.Tables[0].Rows.Count];

            //刷新结构化树列表
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                docStructs[i] = new Class_Struct();
                docStructs[i].Lid = Convert.ToInt32(dataSet.Tables[0].Rows[i]["LID"].ToString());
                docStructs[i].Sid = Convert.ToInt32(dataSet.Tables[0].Rows[i]["SID"].ToString());
                docStructs[i].Struct_Lable = dataSet.Tables[0].Rows[i]["STRUCT_LABLE"].ToString();
                docStructs[i].Struct_Value = dataSet.Tables[0].Rows[i]["STRUCT_VALUE"].ToString();

                TreeNode trNode = new TreeNode();
                trNode.Tag = docStructs[i];
                trNode.Text = docStructs[i].Struct_Lable;
                treeView2.Nodes.Add(trNode);

                
            }


            T_tempplate_struct_Sql = "select * from t_struct where tid=" + patients_Doc.Tid;
            //刷新结构化表格
            ucC1FlexGrid1.DataBd(T_tempplate_struct_Sql, "SID", "STRUCT_LABLE,STRUCT_VALUE", "结构化标签,结构化值");

        }

        /// <summary>
        /// 插入文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            string temp=GetXmlContent();
            xmlDoc=new XmlDocument();
            xmlDoc.LoadXml(temp);
            string flag=App.InsertModel("0100010",84,xmlDoc,79,82,this.txtTextName.Text);//调用webservice中的方法
            if (flag != null)
            {
                App.Msg("插入成功");
                InitDocTree();
                return;
            }
            else
            {
                App.MsgErr("插入失败");
                return;
            }
        }
    }
}