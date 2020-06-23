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
using Base_Function.BLL_FOLLOW.Element;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucFollowTemplateManagement : UserControl
    {
        private string sid = "";
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private static TreeView temptrvbook;
        public static int text_kind;
        public static Class_Template[] Current_Template;
        private string current_id = "";   //获取当前选中模版的ID
        public string isdefault = "N";
        public string default_sec = "N";
        private bool isQueryTag = false;   //查询标记
        public static DataSet Temp_Sections;           //获取所有的模板绑定的科室
        public static string isSecDefault = "false";   //默认科室模板
        ArrayList listNodes = new ArrayList();         //模糊查询的树节点集合

        public ucFollowTemplateManagement()
        {
            InitializeComponent();
            try
            {
                Temp_Sections = App.GetDataSet("select * from T_FOLLOW_TEMPPLATE_SECTION");//有取所有科室和模板的关系
                ReflashBookTree(this.trvModel);
                temptrvbook = this.trvModel;
                ReflashTrvBook("");

                grpBoxEditor.Controls.Add(Template.fmT);//编辑器界面嵌入
                Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;

            }
            catch
            { }


        }

        /// <summary>
        /// 树形菜单信息加载（文书除外）
        /// </summary>
        /// <param name="trvBook">树形菜单</param>
        public void ReflashBookTree(TreeView trvBook)
        {

            string SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Follow_Text[] Directionarys = GetSelectClassDs(ds);
            this.trvModel.Nodes.Clear(); ;
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i] as Class_Follow_Text;
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();

                    //插入顶级节点
                    if (Directionarys[i].Parentid == 0)
                    {
                        trvModel.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn);
                    }
                }
            }

        }

        /// <summary>
        /// 文书类型树
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
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
        /// 刷新文书操作的树
        /// </summary>
        public void ReflashTrvBook(string msg)
        {
            Class_Follow_Patients[] templates;
            if (isQueryTag)
            {
                templates = GetTemplates(msg);
                if (templates != null)  //存在模板
                {
                    foreach (Class_Follow_Patients template in templates)
                    {
                        setTreeView3(template, trvModel.Nodes);

                    }
                }
            }
            else
            {
                templates = GetTemplates("");
                foreach (Class_Follow_Patients template in templates)
                {
                    setTreeView2(template, trvModel.Nodes);
                }
            }

        }
        /// <summary>
        /// 设置节点颜色
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="node"></param>
        public void setNodeColor(Class_Follow_Patients templates, TreeNode node)
        {
            if (templates != null)
            {

                if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                {
                    //科室级默认模板
                    node.ForeColor = Color.Blue;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                {
                    //全院默认模板
                    node.ForeColor = Color.Green;
                }
                else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                         Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                {
                    //科室模板
                    node.ForeColor = Color.Crimson;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                {
                    //全院默认模板
                    node.ForeColor = Color.DarkGoldenrod;
                }
                else
                {
                    //什么都不是
                    node.ForeColor = Color.Black;
                }

            }
        }

        /// <summary>
        /// 实例化查询结果 Class_Template
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
        /// 加载文书模板
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
                                //科室级默认模板
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //全院默认模板
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //科室模板
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //全院默认模板
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //什么都不是
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
                                //科室级默认模板
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //全院默认模板
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //科室模板
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //全院默认模板
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //什么都不是
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
        /// 展开父节点
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

        /// <summary>
        /// 实例Class_Follow_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Follow_Text[] GetSelectClassDs(DataSet tempds)
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
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Sid = tempds.Tables[0].Rows[i]["sid"].ToString();
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


    

        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
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
        /// 将模版插入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string temp = GetXmlContent();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(temp);

            if (current_id == "")
            {
                Template.XmlClearInfo(ref xmlDoc);
                frmFollowTemplateSave tpSave = new frmFollowTemplateSave(xmlDoc, trvModel, Template.fmT.MyDoc);
                App.FormStytleSet(tpSave, false);
                tpSave.ShowDialog();
            }
            else
            {
                int message = 0;
                try
                {
                    string updateLable = "update T_Follow_TempPlate_Cont set Content=:divContent where tid=" + current_id;
                    Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                    xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                    xmlPars[0].ParameterName = "divContent";
                    xmlPars[0].Value = temp;//bodyNode.InnerXml;
                    xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                    xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                    message = App.ExecuteSQL(updateLable, xmlPars);
                    if (message > 0)
                    {
                        App.Msg("保存成功");
                    }
                    else
                    {
                        App.MsgErr("保存失败");
                    }
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    App.MsgErr("保存失败,错误原因:" + ex.Message);
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
            string msg = "";

            //使用范围
            if (rdoPersonal.Checked)
            {
                msg += "TEMPPLATE_LEVEL='P' ";
            }
            else if (rdoSection.Checked)
            {
                msg += "TEMPPLATE_LEVEL='S' ";
            }
            else if (rdoHospital.Checked)
            {
                msg += "TEMPPLATE_LEVEL='H' ";
            }
            string tname = "";  //模板名称
            if (this.txtDocName.Text.Trim() != "")
            {
                tname = this.txtDocName.Text.Trim();
                msg += "and TNAME like '%" + tname + "%' ";
            }
            this.isQueryTag = true;   //设为查询标记
            ReflashBookTree(this.trvModel);
            temptrvbook = this.trvModel;
            ReflashTrvBook(msg);
        }

        /// <summary>
        /// 清除文书模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除文书模版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = App.Ask("确认要删除吗？");
            if (result)
            {

                Class_Follow_Patients pdoc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                string delPatients_Doc = "delete from t_follow_tempplate where tid=" + pdoc.Tid;
                string delModel_Lable = "delete from t_follow_tempplate_cont where tid=" + pdoc.Tid;
                string[] strSqls ={ delPatients_Doc, delModel_Lable };
                int i = App.ExecuteBatch(strSqls);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                    this.trvModel.SelectedNode.Remove();
                    Template.fmT.MyDoc.ClearContent();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }

        }

        /// <summary>
        /// 模板重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmirename_click(object sender, EventArgs e)
        {
            frmRenameFollowTemplate renametemplate = new frmRenameFollowTemplate(current_id, this);
            App.FormStytleSet(renametemplate, false);
            renametemplate.Show();

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LeftMouseClick();
        }


        /// <summary>
        /// 加载模板
        /// </summary>
        private void LeftMouseClick()
        {
            ctmTreeViewMenu.Enabled = true;
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                添加文书模板toolStripMenuItem.Enabled = false;
                删除文书模版ToolStripMenuItem.Enabled = true;
                tsmiRename.Enabled = true;
                tsmiModel.Enabled = true;
                tsmiDefaultModel.Enabled = true;
                tsmiSetSectionModel.Enabled = true;
                btnSave.Enabled = true;
                Class_Follow_Patients doc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                Class_Follow_Text parent=trvModel.SelectedNode.Parent.Tag as Class_Follow_Text;
                current_id = doc.Tid.ToString();
                text_kind =Convert.ToInt32( doc.TextKind);
                sid = parent.Sid;
                string temp = "select Content from T_Follow_TempPlate_Cont where tid=" + doc.Tid;


                DataSet dsTemp = App.GetDataSet(temp);
                DataTable dtTemp = dsTemp.Tables[0];
                string content = "";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    content = content + dtTemp.Rows[i][0].ToString();
                }
                xmlDoc = new XmlDocument();//加入XML的声明段落                
                xmlDoc.PreserveWhitespace = true;
                if (content.Contains("emrtextdoc"))
                {
                    xmlDoc.LoadXml(content);
                }
                else
                {
                    string strXml = GetXmlContent();
                    xmlDoc.LoadXml(strXml);
                    xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//查找<body>

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
            else
            {
                if (trvModel.SelectedNode.Parent == null)
                    ctmTreeViewMenu.Enabled = false;
                else
                {
                    ctmTreeViewMenu.Enabled = true;
                    if (trvModel.SelectedNode.Nodes.Count > 0)
                    {
                        //文书类型的叶节点
                        if (trvModel.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Class_Follow_Patients"))
                        {
                            添加文书模板toolStripMenuItem.Enabled = true;
                            删除文书模版ToolStripMenuItem.Enabled = false;
                            tsmiRename.Enabled = false;
                            tsmiDefaultModel.Enabled = false;
                            tsmiModel.Enabled = false;
                            tsmiSetSectionModel.Enabled = false;
                            btnSave.Enabled = false;
                        }
                        else
                        {
                            ctmTreeViewMenu.Enabled = false;
                            btnSave.Enabled = false;
                        }
                    }
                    else
                    {
                        添加文书模板toolStripMenuItem.Enabled = true;
                        删除文书模版ToolStripMenuItem.Enabled = false;
                        tsmiRename.Enabled = false;
                        tsmiModel.Enabled = false;
                        tsmiSetSectionModel.Enabled = false;
                        tsmiDefaultModel.Enabled = false;
                        btnSave.Enabled = false;
                    }

                }

            }
        }


        /// <summary>
        /// 添加文书模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加文书模板toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            current_id = "";
            Template.fmT.MyDoc.ClearContent();
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
            {
                Class_Follow_Text text = (Class_Follow_Text)this.trvModel.SelectedNode.Tag;
                text_kind = text.Id;
            }
            this.btnSave.Enabled = true;
        }

        //鼠标右键打开时触发事件
        private void ctmTreeViewMenu_Opening(object sender, CancelEventArgs e)
        {
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                Class_Follow_Patients pdoc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                Class_Follow_Text parent = (Class_Follow_Text)trvModel.SelectedNode.Parent.Tag;
                //判断是否为该类型下全院默认模板
                string defaultSql = "select * from T_FOLLOW_TEMPPLATE where tid=" + pdoc.Tid + " and isdefault='Y' and tempplate_level='H' and Text_type="+parent.Id+"";
                //判断全院级模板
                string sql = "select * from T_FOLLOW_TEMPPLATE where tid=" + pdoc.Tid+" and tempplate_level='H' ";
                DataSet dsTest1 = App.GetDataSet(sql);
                if (dsTest1 != null)
                {
                    //判断默认模板
                    if (dsTest1.Tables[0].Rows.Count!=0)
                    {
                        tsmiModel.Enabled = false;
                        DataSet dsTest2 = App.GetDataSet(defaultSql);
                        if (dsTest2 != null)
                        {
                            if (dsTest2.Tables[0].Rows.Count!=0)
                                tsmiDefaultModel.Enabled = false;
                        }
                    }
                }
                else
                {
                    tsmiDefaultModel.Enabled = true;

                }
            }
        }

        //设置为全院默认模板
        private void tsmiDefaultModel_Click(object sender, EventArgs e)
        {
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                Class_Follow_Patients pdoc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                TreeNode selectedNode = trvModel.SelectedNode;
                TreeNode parentNode = selectedNode.Parent;
                string[] sqls = new string[3];
                int x = 0;


                //取消老模板
                string oldSql = "select * from T_Follow_TempPlate where  ISDEFAULT='Y'  and tempplate_level='H' and text_type="+parentNode.Name+"";
                string oldId = App.ReadSqlVal(oldSql, 0, "TID");
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Name == oldId)
                    {
                        node.ForeColor = SystemColors.ControlText;   //老模板
                    }
                }

                //默认模板的取消
                if (oldId != null)
                    sqls[0] = "update T_Follow_TempPlate set ISDEFAULT='N' where tid=" + oldId + "";
                else
                    sqls[0] = "";

                //设置默认模板
                sqls[1] = "update T_Follow_TempPlate set tempplate_level='H',ISDEFAULT='Y' where tid =" + pdoc.Tid;

                //删除所有的科室模板设置
                sqls[2] = "delete from t_Follow_tempplate_section  where TEMPLATE_ID=" + pdoc.Tid + "";
                x = App.ExecuteBatch(sqls);

                selectedNode.ForeColor = Color.Green;  //新模板

                if (x > 0)
                {
                    App.Msg("设置成功!");
                }
            }
        }

        /// <summary>
        /// 设置为全院模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiModel_Click(object sender, EventArgs e)
        {
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                Class_Follow_Patients pdoc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                TreeNode selectedNode = trvModel.SelectedNode;
                TreeNode parentNode = selectedNode.Parent;
                string[] sqls = new string[2];
                int x = 0;
                //设置默认模板
                sqls[0] = "update T_Follow_TempPlate set tempplate_level='H',ISDEFAULT='N' where tid =" + pdoc.Tid;

                //删除所有的科室模板设置
                sqls[1] = "delete from t_Follow_tempplate_section t where TEMPLATE_ID=" + pdoc.Tid + "";
                x = App.ExecuteBatch(sqls);

                selectedNode.ForeColor = Color.DarkGoldenrod;  //新模板

                if (x > 0)
                {
                    App.Msg("设置成功!");
                }
            }
        }

        //设为科室模板
        private void tsmiSetSectionModel_Click(object sender, EventArgs e)
        {
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                ucFollowTemplateManagement.isSecDefault = "false";
                frmFollowSetSecModel secModel = new frmFollowSetSecModel(current_id,text_kind.ToString(),sid, this);
                App.FormStytleSet(secModel, false);
                secModel.ShowDialog();
                ReflashBookTree(this.trvModel);
                ReflashTrvBook("");
                trvModel.ExpandAll();
            }
        }
        /// <summary>
        /// 无效文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 无效ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvModel.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Patients"))
            {
                Class_Follow_Patients pdoc = (Class_Follow_Patients)trvModel.SelectedNode.Tag;
                string sql = "update T_FOLLOW_TEMPPLATE set enable_flag='N' where tid=" + pdoc.Tid + "";
                if (App.Ask("确定无效化文书？"))
                {
                    try
                    {
                        App.ExecuteSQL(sql);
                        trvModel.SelectedNode.Remove();
                    }
                    catch (Exception ex)
                    {
                        App.Msg(ex.Message);
                    }
                    
                }
                else
                    return;
            }
        }

        private void btnDetaiInfo_Click(object sender, EventArgs e)
        {
            frmDetailInformation frm = new frmDetailInformation();
            frm.ShowDialog();
        }

    }
}
