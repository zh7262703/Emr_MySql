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
         *Сģ���ά��
         */

        private static ArrayList source_words= new ArrayList();
        private static ArrayList target_words = new ArrayList();
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        //private XmlElement xmlElem;
        //private Class_Patients[] patients; //ģ��
        //private Class_Patients_Cont[] patients_conts;//ģ��ı�ǩ����
        private static TreeView temptrvbook;
        public static int text_kind;
        public static Class_Template[] Current_Template ;
        private string current_id = "";   //��ȡ��ǰѡ��ģ���ID
        public string isdefault = "N";
        public string default_sec = "N";

        private DataTable dataTable;
        private DataRow newrow;
        //private bool isSysInit = false;   //������Դ�Ƿ񴥷��¼���һ��Ŀ¼��
        //private bool isSickInit = false;  //������Դ�Ƿ񴥷��¼�������Ŀ¼��
        //private bool isTextKindInit = false;  //������Դ�Ƿ񴥷��¼�������Ŀ¼��
        //private bool isQueryTag = false;   //��ѯ���

        //private string CurrentSickId = "";


        ArrayList listNodes = new ArrayList();    //ģ����ѯ�����ڵ㼯��
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

                groupBox3.Controls.Add(Template.fmS);//�༭������Ƕ��
                Template.fmS.Dock = System.Windows.Forms.DockStyle.Fill;

                InitSmallTypeList();    //��ʼ��һ��Ŀ¼������ϵͳ��                               
            }
            catch
            { }

           
        }

        //��������¼�
        private void frmTemplateManageMent_Load(object sender, EventArgs e)
        {
            
        }

        //һ��Ŀ¼ѡ����ı��¼�
        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isSysInit)
            //{
            //    string msg = this.cboSys.SelectedValue.ToString();
            //    InitSickList(msg);
            //}
        }

        //Сģ�����
        private void InitSmallTypeList()
        {
            //isSysInit = false;   //������Դ�Ƿ񴥷��¼�

            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboModelType.DataSource = dataTable.DefaultView;
            this.cboModelType.ValueMember = "ID";
            this.cboModelType.DisplayMember = "Name";

            //isSysInit = true;  //������Դ�Ƿ񴥷��¼�
        }      

        /// <summary>
        /// ���β˵���Ϣ���أ�������⣩
        /// </summary>
        /// <param name="trvBook">���β˵�</param>
        public void ReflashBookTree(TreeView trvBook)
        {           
            treeView1.Nodes.Clear();
            if (rdoPersonal.Checked)
            {
                //����Сģ�弯��
                treeView1.Nodes.Add("����Сģ��");
            }
            else
            {
                //����Сģ�弯��
                treeView1.Nodes.Add("����Сģ��");
            }
            treeView1.Nodes[0].ImageIndex = 6;
            treeView1.Nodes[0].SelectedImageIndex = 6;
            string sql ="";
            if(cboModelType.Items.Count>0)
            {
                if (cboModelType.Text == "��ѡ��...")
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
        /// ��յ�ǰ�༭��
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
        /// ��XML���ݲ�չʾ���༭����(��ȡ���ݿ��е����飬����ʾ���༭����)
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
        /// ����ǰ�༭���е�����ת����xml�������ַ�������ʽ���� �����ڲ������ݿ⣩
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
        /// �����ݿ��ȡģ��
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
        /// ��ģ��������ݿ�
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
                                    App.Msg("����ɹ�");
                                    btnSearch_Click(sender, e);
                                }
                                else
                                {
                                    App.MsgErr("����ʧ��");
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    App.MsgErr("����ʧ��,����ԭ��:"+ex.Message);
                }
            }

        }

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReflashBookTree(this.treeView1);           
        }

        ///// <summary>
        ///// ���˹ؼ���
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
        /// ���˹ؼ���
        /// </summary>
        /// <param name="source">��Ҫ���˵�Դ�ļ�������Ҫ����ı༭�������ɵ�XMl��</param>
        /// <param name="filter">�ؼ���</param>
        /// <returns></returns>
        public static string IsFilter(string source, ArrayList filter)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(source);
            XmlElement rootElement = doc.DocumentElement;
            XmlNodeList list = doc.GetElementsByTagName("select");

          
            //��ȡ����֪ʶ���� ���˹ؼ���
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

            //����<span>�е�����,����Ӧ�����ֹ��ˣ��������ı���ʾǰ��ɫ
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
        /// ����һ���ַ����г����ض��ַ��Ĵ�������ÿ�γ��ֵ��ַ�������������
        /// </summary>
        /// <param name="str">Դ�ַ���</param>
        /// <param name="value">��Ҫ���ҵ�Ŀ�괮</param>
        /// <returns></returns>
        public static ArrayList getIndex(string str,string value)
        {
            ArrayList list = new ArrayList();

            list.Add(0);//list�еĵ�һ��λ�ù̶�Ϊ�ַ�������ʼλ��
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
        /// ����༭������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            Template.fmS.MyDoc.ClearContent();
        }

        private void ɾ������ģ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    bool result = App.Ask("ȷ��Ҫɾ����");
                    if (result)
                    {



                        string delPatients_Doc = "delete from t_tempplate where tid=" + treeView1.SelectedNode.Name;

                        string delModel_Lable = "delete from t_tempplate_cont where tid=" + treeView1.SelectedNode.Name;
                        string[] strSqls ={ delPatients_Doc, delModel_Lable };
                        int i = App.ExecuteBatch(strSqls);
                        if (i > 0)
                        {
                            App.Msg("�����ɹ�");
                            this.treeView1.SelectedNode.Remove();
                            Template.fmS.MyDoc.ClearContent();
                        }
                        else
                        {
                            App.Msg("����ʧ��");
                        }


                    }
                }
                else
                {
                    App.MsgWaring("�ýڵ㲻�ܱ�ɾ��");
                }
            }
            else
            {
                App.MsgWaring("��ѡ��Ҫɾ���Ľڵ�");
            }
            
        }

        /// <summary>
        /// ģ��������
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
                    App.MsgErr("�ýڵ㲻�ܽ������ã�");
                }
            }
            else
            {
                App.MsgErr("��ѡ����Ҫ���õĽڵ㣡");
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
            //LeftMouseClick();   //�����������¼�

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
                    ɾ������ģ��ToolStripMenuItem.Enabled = true;
                    tsmiRename.Enabled = true;
                    //tsmiDefaultModel.Enabled = true;
                    tsmiSetPerson.Enabled = true;
                    tsmiSetSectionModel.Enabled = true;
                    button2.Enabled = true;                 
                    xmlDoc = new XmlDocument();//����XML����������                
                    xmlDoc.PreserveWhitespace = true;
                    string strXml = GetXmlContent();
                    //xmlDoc.Load(@"C:\tempplate.xml");
                    xmlDoc.LoadXml(strXml);
                    xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

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

                ɾ������ģ��ToolStripMenuItem.Enabled = false;
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
                xmlDoc = new XmlDocument();//����XML����������                
                string strXml = GetXmlContent();
                //xmlDoc.Load(@"C:\tempplate.xml");
                xmlDoc.LoadXml(strXml);
                xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

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

        //����Ҽ���ʱ�����¼�
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

        //����ΪȫԺĬ��ģ��
        private void tsmiDefaultModel_Click(object sender, EventArgs e)
        {
          

        }
     

        //��Ϊ����ģ��
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
                    App.MsgErr("�ýڵ㲻�ܽ������ã�");
                }

            }             
            else
            {
                App.MsgErr("��ѡ����Ҫ���õĽڵ㣡");
            }


        }
       
       
      

        private void rdoPersonal_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// ����Ϊ����ģ��
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
                        App.Msg("�����ɹ���");
                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                }
                else
                {
                    App.MsgErr("�ýڵ㲻�ܽ������ã�");
                }
            }
            else
            {
                App.MsgErr("��ѡ����Ҫ���õĽڵ㣡");
            }
        }

        private void chkSmallTemplate_CheckedChanged(object sender, EventArgs e)
        {         
        }
      
    }
}
