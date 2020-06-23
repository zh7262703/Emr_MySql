using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;
using System.Xml;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowWrite_Type : DevComponents.DotNetBar.Office2007Form
    {
        private bool isQueryTag = false;
        public static DataSet Temp_Sections;
        private string current_id = "";   //��ȡ��ǰѡ��ģ���ID
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;

        public frmFollowWrite_Type()
        {
            InitializeComponent();
            editePanel.Controls.Add(Template.fmT);
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            Template.fmT.MyDoc.Locked= true;
            
            ReflashBookTree(this.trvFollowType);
            Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
            ReflashTrvBook("");
        }
        #region
        /// <summary>
        /// ���β˵���Ϣ���أ�������⣩
        /// </summary>
        /// <param name="trvBook">���β˵�</param>
        public void ReflashBookTree(TreeView trvBook)
        {

            string SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Follow_Text[] Directionarys = GetSelectClassDs(ds);
            this.trvFollowType.Nodes.Clear(); ;
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i] as Class_Follow_Text;
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();

                    //���붥���ڵ�
                    if (Directionarys[i].Parentid == 0)
                    {
                        trvFollowType.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn);
                    }
                }
            }

        }
        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
        private static void SetTreeView(Class_Follow_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    tn.ImageIndex = 9;
                    tn.SelectedImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        /// <summary>
        /// ˢ�������������
        /// </summary>
        public void ReflashTrvBook(string msg)
        {
            Class_Follow_Patients[] templates;
            if (isQueryTag)
            {
                templates = GetTemplates(msg);
                if (templates != null)  //����ģ��
                {
                    foreach (Class_Follow_Patients template in templates)
                    {
                        setTreeView3(template, trvFollowType.Nodes);
                    }
                }
            }
            else
            {
                templates = GetTemplates("");
                foreach (Class_Follow_Patients template in templates)
                {
                    setTreeView2(template, trvFollowType.Nodes);
                }
            }

        }
        /// <summary>
        /// ʵ������ѯ��� Class_Template
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Class_Follow_Patients[] GetTemplates(string msg)
        {
            string sql = "";
            if (msg != "")
            {
                sql = "select * from t_follow_tempplate where " + msg;// where Text_type = " + textId;
            }
            else
            {
                sql = "select * from t_follow_tempplate";// where Text_type = " + textId;
            }
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                Class_Follow_Patients[] templates = new Class_Follow_Patients[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    templates[i] = new Class_Follow_Patients();
                    templates[i].Tid = Convert.ToInt32(ds.Tables[0].Rows[i]["TID"]);
                    templates[i].TName = ds.Tables[0].Rows[i]["TNAME"].ToString();
                    if (ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString().Trim() != "")
                        templates[i].TextKind = ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString();
                    if (ds.Tables[0].Rows[i]["TEMPPLATE_LEVEL"].ToString().Trim() != "")
                        templates[i].TempPlate_Level = Convert.ToChar(ds.Tables[0].Rows[i]["TEMPPLATE_LEVEL"]);
                    if (ds.Tables[0].Rows[i]["ISDEFAULT"].ToString().Trim() != "")
                        templates[i].IsDefault = Convert.ToChar(ds.Tables[0].Rows[i]["ISDEFAULT"]);
                    templates[i].Default_sec_id = ds.Tables[0].Rows[i]["DEFAULT_SEC_ID"].ToString();
                }
                return templates;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ���ýڵ���ɫ
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="node"></param>
        public void setNodeColor(Class_Follow_Patients templates, TreeNode node)
        {
            if (templates != null)
            {

                if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                {
                    //���Ҽ�Ĭ��ģ��
                    node.ForeColor = Color.Blue;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                {
                    //ȫԺĬ��ģ��
                    node.ForeColor = Color.Green;
                }
                else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                         Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                {
                    //����ģ��
                    node.ForeColor = Color.Crimson;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                {
                    //ȫԺĬ��ģ��
                    node.ForeColor = Color.DarkGoldenrod;
                }
                else
                {
                    //ʲô������
                    node.ForeColor = Color.Black;
                }

            }
        }
        /// <summary>
        /// ��������ģ��
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="nodes"></param>

        private static void setTreeView2(Class_Follow_Patients templates, TreeNodeCollection nodes)
        {
            if (templates != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                    {
                        Class_Follow_Text cunrrentDir = node.Tag as Class_Follow_Text;
                        if (templates.TextKind == cunrrentDir.Id.ToString())
                        {
                            TreeNode tn = new TreeNode();
                            if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //���Ҽ�Ĭ��ģ��
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //ʲô������
                                tn.ForeColor = Color.Black;
                            }

                            tn.Tag = templates;
                            tn.Text = templates.TName;
                            tn.Name = templates.Tid.ToString();
                            tn.ImageIndex = 13;
                            tn.SelectedImageIndex = 13;
                            node.Nodes.Add(tn);
                            tn.Parent.SelectedImageIndex = 6;
                            tn.Parent.ImageIndex = 6;
                        }
                    }

                    if (node.Nodes.Count > 0)
                        setTreeView2(templates, node.Nodes);

                }
            }
        }

        private static void setTreeView3(Class_Follow_Patients templates, TreeNodeCollection nodes)
        {
            if (templates != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                    {
                        Class_Follow_Text cunrrentDir = node.Tag as Class_Follow_Text;
                        if (templates.TextKind == cunrrentDir.Id.ToString())
                        {
                            TreeNode tn = new TreeNode();
                            if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //���Ҽ�Ĭ��ģ��
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //ʲô������
                                tn.ForeColor = Color.Black;
                            }
                            tn.Tag = templates;
                            tn.Text = templates.TName;
                            tn.Name = templates.Tid.ToString();
                            tn.ImageIndex = 13;
                            tn.SelectedImageIndex = 13;
                            node.Nodes.Add(tn);
                            tn.Parent.SelectedImageIndex = 6;
                            tn.Parent.ImageIndex = 6;
                            SetParentNodeExpand(tn);

                        }
                    }

                    if (node.Nodes.Count > 0)
                        setTreeView3(templates, node.Nodes);

                }
            }
        }
        /// <summary>
        /// չ�����ڵ�
        /// </summary>
        /// <param name="tn"></param>

        private static void SetParentNodeExpand(TreeNode tn)
        {
            if (tn.Parent != null)
            {
                tn.Parent.Expand();
                TreeNode tempNode = tn.Parent;
                SetParentNodeExpand(tempNode);
            }
        }
        #endregion
        /// <summary>
        /// ʵ����
        /// </summary>
        /// <param name="tempds"></param>
        /// <returns></returns>
        private Class_Follow_Text[] GetSelectClassDs(DataSet tempds)
        {

            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Follow_Text[] class_text = new Class_Follow_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Follow_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"] != null)
                        {
                            if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0" && tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "")
                            {
                                class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                            }
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["ISSIMPLEINSTANCE"].ToString();
                        class_text[i].Enable = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        class_text[i].Shownum = tempds.Tables[0].Rows[i]["shownum"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                        if (tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString() == "")
                        {
                            class_text[i].Right_range = "D";
                        }
                        else
                        {
                            class_text[i].Right_range = tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString() == "")
                        {
                            class_text[i].Isneedsign = "Y";
                        }
                        else
                        {
                            class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString() == "")
                        {
                            class_text[i].Isnewpage = "N";
                        }
                        else
                        {
                            class_text[i].Isnewpage = tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString() == "")
                        {
                            class_text[i].Issubmitsign = "N";
                        }
                        else
                        {
                            class_text[i].Issubmitsign = tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString();
                        }

                    }
                    return class_text;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void trvFollowWrite_DoubleClick(object sender, EventArgs e)
        {
            if (trvFollowType.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                TreeNode node = new TreeNode();
                node = trvFollowType.SelectedNode;
                ucElement.id = node.Name;
                ucElement.myName = node.Text;
                txtCondition.Text = node.Text;
            }
           
        }
        private void trvFollowWrite_MouseDown(object sender, MouseEventArgs e)
        {
            trvFollowType.SelectedNode = trvFollowType.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// ���������������ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string msg="";
            if (txtCondition.Text.Trim() != "")
                msg += " tname like '" + txtCondition.Text.Trim() + "%'";
            this.isQueryTag = true;   //��Ϊ��ѯ���
            ReflashBookTree(this.trvFollowType);
            ReflashTrvBook(msg);
        }

        private void trvFollowWrite_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode node = new TreeNode();
            node = trvFollowType.SelectedNode;
            ucElement.id = node.Name;
            ucElement.myName = node.Text;
            txtCondition.Text = node.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCondition.Text != "")
                this.Close();
            else
                App.Msg("��ѡ������");
        }

        private void trvFollowWrite_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LeftMouseClick();
        }
        /// <summary>
        /// ����ģ��
        /// </summary>
        private void LeftMouseClick()
        {
            if (trvFollowType.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                Class_Follow_Patients doc = (Class_Follow_Patients)trvFollowType.SelectedNode.Tag;

                //current_id = doc.Tid.ToString();
                string temp = "select Content from T_Follow_TempPlate_Cont where tid=" + doc.Tid;


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

    }
}