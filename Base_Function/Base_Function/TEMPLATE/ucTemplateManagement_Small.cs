using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Bifrost;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Threading;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;
using MySql.Data.MySqlClient;

namespace Base_Function.TEMPLATE
{
    public partial class ucTemplateManagement_Small : UserControl
    {       

        /*
         *小模板的维护
         */

        private static ArrayList source_words= new ArrayList();
        private static ArrayList target_words = new ArrayList();
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        //private XmlElement xmlElem;
        //private Class_Patients[] patients; //模版
        //private Class_Patients_Cont[] patients_conts;//模版的标签内容
        private static TreeView temptrvbook;
        public static int text_kind;
        public static Class_Template[] Current_Template ;
        private string current_id = "";   //获取当前选中模版的ID
        public string isdefault = "N";
        public string default_sec = "N";

        private DataTable dataTable;
        private DataRow newrow;
        //private bool isSysInit = false;   //绑定数据源是否触发事件（一级目录）
        //private bool isSickInit = false;  //绑定数据源是否触发事件（二级目录）
        //private bool isTextKindInit = false;  //绑定数据源是否触发事件（三级目录）
        //private bool isQueryTag = false;   //查询标记

        //private string CurrentSickId = "";


        ArrayList listNodes = new ArrayList();    //模糊查询的树节点集合
        //int nodeNum = 0;
        //string temp = "";

        public ucTemplateManagement_Small()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            try
            {               
                ReflashBookTree(this.treeView1);             
                temptrvbook = this.treeView1;               

                groupBox3.Controls.Add(Template.fmS);//编辑器界面嵌入
                Template.fmS.Dock = System.Windows.Forms.DockStyle.Fill;

                InitSmallTypeList();    //初始化一级目录（所属系统）                               
            }
            catch
            { }

           
        }

        //窗体加载事件
        private void frmTemplateManageMent_Load(object sender, EventArgs e)
        {
            
        }

        //一级目录选定项改变事件
        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isSysInit)
            //{
            //    string msg = this.cboSys.SelectedValue.ToString();
            //    InitSickList(msg);
            //}
        }

        //小模板类别
        private void InitSmallTypeList()
        {
            //isSysInit = false;   //绑定数据源是否触发事件

            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboModelType.DataSource = dataTable.DefaultView;
            this.cboModelType.ValueMember = "ID";
            this.cboModelType.DisplayMember = "Name";

            //isSysInit = true;  //绑定数据源是否触发事件
        }      

        /// <summary>
        /// 树形菜单信息加载（文书除外）
        /// </summary>
        /// <param name="trvBook">树形菜单</param>
        public void ReflashBookTree(TreeView trvBook)
        {           
            treeView1.Nodes.Clear();
            if (rdoPersonal.Checked)
            {
                //个人小模板集合
                treeView1.Nodes.Add("个人小模板");
            }
            else
            {
                //科室小模板集合
                treeView1.Nodes.Add("科室小模板");
            }
            treeView1.Nodes[0].ImageIndex = 6;
            treeView1.Nodes[0].SelectedImageIndex = 6;
            string sql ="";
            if(cboModelType.Items.Count>0)
            {
                if (cboModelType.Text == "请选择...")
                {
                    sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.TNAME like '" + txtDocName.Text + "%' ";
                }
                else
                {
                    sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.smalltemptype=" + cboModelType.SelectedValue.ToString() + " and t.TNAME like '" + txtDocName.Text + "%'";
                }
            }
            else
            {
                sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.TNAME like '" + txtDocName.Text + "%'";
            }

            if (rdoSection.Checked)
            {
                sql = sql + " and tempplate_level='S'";
            }
            else
            {
                sql = sql + " and tempplate_level='P'";
            }

            sql = sql + " order by b.name";

            DataSet dsnods = App.GetDataSet(sql);

            if (dsnods != null)
            {
                for (int i = 0; i < dsnods.Tables[0].Rows.Count; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dsnods.Tables[0].Rows[i]["name"].ToString() + "--" + dsnods.Tables[0].Rows[i]["TNAME"].ToString();
                    tn.Name = dsnods.Tables[0].Rows[i]["TID"].ToString();
                    tn.ImageIndex = 13;
                    tn.SelectedImageIndex = 13;
                    treeView1.Nodes[0].Nodes.Add(tn);
                }                
            }
            treeView1.Nodes[0].ExpandAll();

        }                         
       
     
        /// <summary>
        /// 清空当前编辑器
        /// </summary>
        private void ClearEditor()
        {
            if (Template.fmS.MyDoc.DocumentElement != null)
            {
                Template.fmS.MyDoc.DocumentElement.ClearChild();
                Template.fmS.MyDoc.ContentChanged();
            }
        }

        /// <summary>
        /// 将XML内容并展示到编辑器上(读取数据库中的文书，并显示到编辑器上)
        /// </summary>
        /// <param name="temdoc"></param>
        private void IniEditContent(string xmldoc)  
        {
            XmlDocument temdoc = new XmlDocument();
            temdoc.LoadXml(xmldoc); 
            Template.fmS.MyDoc.FromXML(temdoc.DocumentElement);
          
            Template.fmS.MyDoc.ContentChanged();            
        }

        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {            
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            Template.fmS.MyDoc.IsHaveDeleted = true;
            Template.fmS.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.fmS.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        /// <summary>
        /// 从数据库读取模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //string temp = App.ReadSqlVal("select * from t_patients_doc", 1, "PATIENTS_DOC");
            //IniEditContent(temp);
            current_id = "";
            Template.fmS.MyDoc.ClearContent();
            this.button2.Enabled = true;

        }

        /// <summary>
        /// 将模版插入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string temp = GetXmlContent();            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(temp);

            if (current_id == "")
            {
                frmSmallTemplateSave tpSave = new frmSmallTemplateSave(xmlDoc, Template.fmS.MyDoc);
                App.FormStytleSet(tpSave, false);
                tpSave.ShowDialog();
            }
            else
            {
                XmlElement xmlElement = xmlDoc.DocumentElement;
                int message = 0;                                  
                try
                {
                    foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                    {                       
                        if (bodyNode.Name == "body")
                        {
                           
                            if (bodyNode.HasChildNodes)
                            {   //int i = 1;           
                                string updateLable = "update T_TempPlate_Cont set Content=:divContent where tid=" + current_id;
                                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                xmlPars[0] = new MySqlDBParameter();
                                xmlPars[0].ParameterName = "divContent";
                                //xmlPars[0].Value = divNode.OuterXml;
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].DBType = MySqlDbType.Text;
                                xmlPars[0].Direction = ParameterDirection.Input;
                                message = App.ExecuteSQL(updateLable, xmlPars);
                                if (message > 0)
                                {
                                    App.Msg("保存成功");
                                    btnSearch_Click(sender, e);
                                }
                                else
                                {
                                    App.MsgErr("保存失败");
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    App.MsgErr("保存失败,错误原因:"+ex.Message);
                }
            }

        }

        /// <summary>
        /// 查询文书类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReflashBookTree(this.treeView1);           
        }

        ///// <summary>
        ///// 过滤关键字
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //public static string IsFilter(string source, ArrayList filter)
        //{

        //    for (int i = 0; i < filter.Count; i++)
        //    {
        //        source = source.Replace(filter[i].ToString(), target_words[i].ToString());

        //    }

        //    return source;
        //}

        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <param name="source">需要过滤的源文件，即需要保存的编辑器中生成的XMl串</param>
        /// <param name="filter">关键字</param>
        /// <returns></returns>
        public static string IsFilter(string source, ArrayList filter)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(source);
            XmlElement rootElement = doc.DocumentElement;
            XmlNodeList list = doc.GetElementsByTagName("select");

          
            //获取下拉知识库结点 过滤关键字
            for (int i = 0; i < filter.Count; i++)
            {

                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Name == "select")
                    {
                       // keys[i] = list[i].Attributes["value"].Value;
                        if (list[j].Attributes["text"].Value.Trim() == source_words[i].ToString().Trim())
                        {
                            //list[j].Attributes["forecolor"].Value = "#FF0000";
                            list[j].Attributes["value"].Value = list[j].Attributes["name"].Value;
                            list[j].Attributes["text"].Value = list[j].Attributes["name"].Value;
                        }
                    }
                }
            }
            source = doc.OuterXml;

            //遍历<span>中的文字,把相应的文字过滤，并设置文本显示前景色
            list = doc.GetElementsByTagName("span");
            for (int i = 0; i < filter.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Name == "span")
                    {
                       
                        if (list[j].InnerText.IndexOf(filter[i].ToString()) > -1)
                        {                          


                           list[j].InnerText = list[j].InnerText.Replace(source_words[i].ToString().Trim(), target_words[i].ToString());
                           list[j].Attributes["forecolor"].Value = "#FF0000";
                        }
                    }
                }
            }
            source = doc.OuterXml;
            return source;
        }
               


        /// <summary>
        /// 返回一个字符串中出现特定字符的次数并把每次出现的字符索引存入数组
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="value">需要查找的目标串</param>
        /// <returns></returns>
        public static ArrayList getIndex(string str,string value)
        {
            ArrayList list = new ArrayList();

            list.Add(0);//list中的第一个位置固定为字符串的起始位置
            int i = -1, x = -1;
            do
            {
                i = str.IndexOf(value, ++i);
                list.Add(i);
                x++;
            } while (i != -1);

            return list;
        }
                   
        /// <summary>
        /// 清除编辑器内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            Template.fmS.MyDoc.ClearContent();
        }

        private void 删除文书模版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    bool result = App.Ask("确认要删除吗？");
                    if (result)
                    {



                        string delPatients_Doc = "delete from t_tempplate where tid=" + treeView1.SelectedNode.Name;

                        string delModel_Lable = "delete from t_tempplate_cont where tid=" + treeView1.SelectedNode.Name;
                        string[] strSqls ={ delPatients_Doc, delModel_Lable };
                        int i = App.ExecuteBatch(strSqls);
                        if (i > 0)
                        {
                            App.Msg("操作成功");
                            this.treeView1.SelectedNode.Remove();
                            Template.fmS.MyDoc.ClearContent();
                        }
                        else
                        {
                            App.Msg("操作失败");
                        }


                    }
                }
                else
                {
                    App.MsgWaring("该节点不能被删除");
                }
            }
            else
            {
                App.MsgWaring("请选择要删除的节点");
            }
            
        }

        /// <summary>
        /// 模板重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    frmRenameTemplate renameTemplate = new frmRenameTemplate(current_id, this);
                    App.FormStytleSet(renameTemplate, false);
                    renameTemplate.Show();
                }
                else
                {
                    App.MsgErr("该节点不能进行设置！");
                }
            }
            else
            {
                App.MsgErr("请选择需要设置的节点！");
            }

        } 

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LeftMouseClick();
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            //LeftMouseClick();   //鼠标左键单击事件

            //    Class_patients_doc doc = (Class_patients_doc)treeView1.SelectedNode.Tag;
            //    string temp = App.ReadSqlVal("select * from t_patients_doc where tid=" + doc.Tid + "", 0, "PATIENTS_DOC");
            //    Class_patients_doc pdoc = (Class_patients_doc)treeView1.SelectedNode.Tag;
            //    IniEditContent(temp);
            //}
        }

        private void LeftMouseClick()
        {
            ctmTreeViewMenu.Enabled = true;
            //if (e.Button == MouseButtons.Left)
            //{
            if (treeView1.SelectedNode!=null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    toolStripMenuItem1.Enabled = false;
                    删除文书模版ToolStripMenuItem.Enabled = true;
                    tsmiRename.Enabled = true;
                    //tsmiDefaultModel.Enabled = true;
                    tsmiSetPerson.Enabled = true;
                    tsmiSetSectionModel.Enabled = true;
                    button2.Enabled = true;                 
                    xmlDoc = new XmlDocument();//加入XML的声明段落                
                    xmlDoc.PreserveWhitespace = true;
                    string strXml = GetXmlContent();
                    //xmlDoc.Load(@"C:\tempplate.xml");
                    xmlDoc.LoadXml(strXml);
                    xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//查找<body>

                    current_id = treeView1.SelectedNode.Name;
                    string temp = "select Content from T_TempPlate_Cont where tid=" + treeView1.SelectedNode.Name;


                    DataSet dsTemp = App.GetDataSet(temp);
                    DataTable dtTemp = dsTemp.Tables[0];
                    string content = "";
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        content = content + dtTemp.Rows[i][0].ToString();
                    }

                    foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {
                            bodyNode.InnerXml = content;
                        }
                    }
                    Template.fmS.MyDoc.FromXML(xmlDoc.DocumentElement);
                    Template.fmS.MyDoc.ContentChanged();
                }
            }
            else
            {

                删除文书模版ToolStripMenuItem.Enabled = false;
                tsmiRename.Enabled = false;
                tsmiSetPerson.Enabled = false;
                tsmiSetSectionModel.Enabled = false;
                //tsmiDefaultModel.Enabled = false;
                toolStripMenuItem1.Enabled = true;
                button2.Enabled = false;

            }
        }        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            current_id = "";
            Template.fmS.MyDoc.ClearContent();         
            this.button2.Enabled = true;
        }

        public static string SelectTempContent = "";

        private void button1_Click_1(object sender, EventArgs e)
        {            
            frmTemplateList ff = new frmTemplateList();
            App.FormStytleSet(ff, false);
            ff.ShowDialog();
            if (SelectTempContent != "")
            {
                xmlDoc = new XmlDocument();//加入XML的声明段落                
                string strXml = GetXmlContent();
                //xmlDoc.Load(@"C:\tempplate.xml");
                xmlDoc.LoadXml(strXml);
                xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//查找<body>

                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = SelectTempContent;
                    }
                }
                Template.fmS.MyDoc.FromXML(xmlDoc.DocumentElement);
                Template.fmS.MyDoc.ContentChanged();
            }
        }

        //鼠标右键打开时触发事件
        private void ctmTreeViewMenu_Opening(object sender, CancelEventArgs e)
        {
            if (rdoPersonal.Checked)
            {
                tsmiSetPerson.Enabled = false;
                tsmiSetSectionModel.Enabled = true;
            }
            else
            {
                tsmiSetPerson.Enabled = true;
                tsmiSetSectionModel.Enabled = true;
            }
        }

        //设置为全院默认模板
        private void tsmiDefaultModel_Click(object sender, EventArgs e)
        {
          

        }
     

        //设为科室模板
        private void tsmiSetSectionModel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode!=null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    frmSetSecModel secModel = new frmSetSecModel(current_id, this);
                    App.FormStytleSet(secModel, false);
                    secModel.Show();
                } 
                else
                {
                    App.MsgErr("该节点不能进行设置！");
                }

            }             
            else
            {
                App.MsgErr("请选择需要设置的节点！");
            }


        }
       
       
      

        private void rdoPersonal_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// 设置为个人模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSetPerson_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    if (App.ExecuteSQL("update t_tempplate set SECTION_ID=0 where tid=" + treeView1.SelectedNode.Name + "") > 0)
                    {
                        App.Msg("操作成功！");
                    }
                    else
                    {
                        App.Msg("操作失败！");
                    }
                }
                else
                {
                    App.MsgErr("该节点不能进行设置！");
                }
            }
            else
            {
                App.MsgErr("请选择需要设置的节点！");
            }
        }

        private void chkSmallTemplate_CheckedChanged(object sender, EventArgs e)
        {         
        }
      
    }
}
