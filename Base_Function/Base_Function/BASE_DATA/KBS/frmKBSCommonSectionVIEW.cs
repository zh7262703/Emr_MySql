using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;
using TextEditor;
using DevComponents.DotNetBar;

using Base_Function.BASE_DATA.KBS;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Base_Function.BASE_DATA
{
    public partial class frmKBSCommonSectionVIEW : UserControl
    {     
        private XmlNode xmlNode;
        public frmText CurrentTextEdit;   //编辑器当前操作的编辑器  
        private ZYTextInput inputText; //当前操作的文本域
        private frmText text; //展示用编辑器
        private DataTable dtParent = new DataTable();   //目录表
        private bool IsTextInput = false;

        /// <summary>
        /// 当前选中的模板
        /// </summary>
        private string loadContent;
        public string LoadContent
        {
            get { return loadContent; }
            set { loadContent = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmKBSCommonSectionVIEW()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            text = new frmText();
            text.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(text);
            IsTextInput = false;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ucText"></param>
        public frmKBSCommonSectionVIEW(ZYTextInput inputText)
        {
            InitializeComponent();
            App.UsControlStyle(this);
            this.inputText = inputText;
            text = new frmText();
            text.Dock = DockStyle.Fill;
            IsTextInput = true;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ucText"></param>
        public frmKBSCommonSectionVIEW(frmText ucText_New)
        {
            InitializeComponent();
            App.UsControlStyle(this);
            CurrentTextEdit = ucText_New;
            text = new frmText();
            text.Dock = DockStyle.Fill;
            IsTextInput = false;
        }
    
        private void frmKBSCommon_Load(object sender, EventArgs e)
        {
            TreeRefresh();

            if (this.advTreeSmallTemplate.Nodes.Count > 0)
            {
                this.advTreeSmallTemplate.Nodes[0].Expand();
            }

            //选中
            if (IsTextInput)
            {
                for (int i = 0; i < advTreeSmallTemplate.Nodes[0].Nodes.Count; i++)
                {
                    if (advTreeSmallTemplate.Nodes[0].Nodes[i].Text == inputText.Name)
                    {
                        advTreeSmallTemplate.SelectedNode = advTreeSmallTemplate.Nodes[0].Nodes[i];
                        advTreeSmallTemplate.Nodes[0].Nodes[i].ExpandAll();
                    }
                }
                this.advTreeSmallTemplate.Select();
            }

        }


        #region 右键菜单事件

        private void 增加子目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.Nodes != null)
            {
                updateTitleKBS udt = new updateTitleKBS(0, this.advTreeSmallTemplate.SelectedNode, "新建子目录", "请输入子目录的名称：",true);
                udt.ShowDialog();
            }
        }

        private void 增加选择类元素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.Nodes != null)
            {
                updateTitleKBS udt = new updateTitleKBS(1, this.advTreeSmallTemplate.SelectedNode, "新建基础元素", "请输入选择类元素的名称：",true);
                udt.ShowDialog();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.Nodes != null && this.advTreeSmallTemplate.SelectedNode.Parent != null)
            {
                updateTitleKBS udt = new updateTitleKBS(3, this.advTreeSmallTemplate.SelectedNode, "修改标题", "请输入新的标题名称：",true);
                udt.ShowDialog();
            }
        }

        private void 父节点选择StripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode != null)
            {
                //frmUpdateParentNode frmUpn = new frmUpdateParentNode(this.advTreeSmallTemplate.SelectedNode.Tag.ToString(), true);
                //if (frmUpn.ShowDialog() == DialogResult.OK)
                //{
                //    TreeRefresh();
                //}
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (App.Ask("您确定要删除该节点吗？   \n\n提示：删除之后将无法恢复"))
            {
                if (this.advTreeSmallTemplate.SelectedNode != null)
                {
                    try
                    {
                        //string sql = string.Format("DELETE kbs_tree_section WHERE ID = '{0}' or parentId = '{1}'"
                        //                , this.advTreeSmallTemplate.SelectedNode.Tag.ToString(), this.advTreeSmallTemplate.SelectedNode.Tag.ToString());
                        //App.ExecuteSQL(sql);
                        //this.advTreeSmallTemplate.Nodes.Remove(this.advTreeSmallTemplate.SelectedNode);
                        //App.Msg("删除成功");
                    }
                    catch
                    {
                        App.Msg("网络不通！请检查网络是否良好！");
                    }
                }
            }
        }

        private void 全部展开WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode != null)
            {
                this.advTreeSmallTemplate.SelectedNode.ExpandAll();
            }
        }

        private void 全部收缩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode != null)
            {
                this.advTreeSmallTemplate.SelectedNode.Toggle();
            }
        }

        private void tspUp_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.advTreeSmallTemplate.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index > 0)
                {
                    dataSourceHelper.MovUp(tn, this.advTreeSmallTemplate);
                }
            }
        }

        private void tspDown_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.advTreeSmallTemplate.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index < tn.Parent.Nodes.Count - 1)
                {
                    dataSourceHelper.MovDown(tn, this.advTreeSmallTemplate);
                }
            }
        }

        private void 刷新ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> list = new List<int>();
                TreeNode tn = this.advTreeSmallTemplate.SelectedNode;
                string treeNodePath = tn.FullPath;
                for (int i = 0; i < treeNodePath.Split('〓').Length; i++)
                {
                    if (tn != null)
                    {
                        list.Add(tn.Index);
                        if (tn.Parent != null)
                        {
                            tn = tn.Parent;
                        }
                    }
                }

                this.TreeRefresh();
                if (this.advTreeSmallTemplate.Nodes.Count > 0)
                {
                    TreeNodeCollection tn3 = this.advTreeSmallTemplate.Nodes;
                    for (int i = list.Count; i > 0; i--)
                    {
                        if (i == 1)
                        {
                            this.advTreeSmallTemplate.SelectedNode = tn3[list[0]];
                        }
                        else
                        {
                            tn3[list[i - 1]].Expand();
                            tn3 = tn3[list[i - 1]].Nodes;
                        }
                    }
                }
                this.advTreeSmallTemplate.Focus();
            }
            catch (Exception)
            {
                this.TreeRefresh();
                this.advTreeSmallTemplate.Focus();
            }
        }

        #endregion


        #region 函数

        /// <summary>
        /// 刷新所有节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeRefresh()
        {
            this.advTreeSmallTemplate.Nodes.Clear();
            try
            {
                dtParent = App.GetDataSet("SELECT k.*,t.section_name FROM kbs_tree_section k left join t_sectioninfo t on k.section_id = t.sid where k.section_id = (select s.belongto_bigsection_id from t_sectioninfo s where s.sid = " + App.UserAccount.CurrentSelectRole.Section_Id + ") ORDER BY k.PARENTID").Tables[0];
                //dtParent = App.GetDataSet("SELECT t.* FROM kbs_tree_section k inner join kbs_tree_section t on (k.id = t.parentid or k.id = t.id) where k.section_id = '" + App.UserAccount.CurrentSelectRole.Section_Id + "'and " + "k.name like'%" + inputText.Name + "%' ORDER BY k.PARENTID").Tables[0];  
            }
            catch
            {
                App.Msg("网络不通！请检查网络是否良好！");
                return;
            }

            if (dtParent != null && dtParent.Rows.Count > 0)
            {
                string bigSectionName = dtParent.Rows[0]["section_name"].ToString();//获取大科

                TreeNode tn = new TreeNode(bigSectionName);
                tn.ImageIndex = 0;
                tn.Tag = "0";
                tn.SelectedImageIndex = 1;
                TreeChildNodesAdd(tn, "0");
                this.advTreeSmallTemplate.Nodes.Add(tn);
                GC.Collect();
            }
        }

        /// <summary>
        /// 节点添加
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="parentId"></param>
        public void TreeChildNodesAdd(TreeNode tn, string parentId)
        {
            DataRow[] drs = dtParent.Select(string.Format("ParentId = '{0}'", parentId), "NUM");
            foreach (DataRow dr in drs)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Text = dr["name"].ToString();
                tn2.Tag = dr["id"].ToString();
                tn2.Name = dr["showtype"].ToString();
                switch (dr["showtype"].ToString())
                {
                    case "3":
                        tn2.ImageIndex = 2;
                        tn2.SelectedImageIndex = 3;
                        break;
                    default:
                        tn2.ImageIndex = 0;
                        tn2.SelectedImageIndex = 1;
                        break;
                }

                tn.Nodes.Add(tn2);
                TreeChildNodesAdd(tn2, dr["id"].ToString());
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
            text.MyDoc.IsHaveDeleted = true;
            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
            text.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        private void GetCheckIds(TreeNodeCollection nodes, ref string ids)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Checked)
                {
                    if (nodes[i].ImageIndex == 2)
                    {
                        if (ids == "")
                        {
                            ids = "'" + nodes[i].Tag.ToString() + "'";
                        }
                        else
                        {
                            ids = ids + ",'" + nodes[i].Tag.ToString() + "'";
                        }
                    }
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    GetCheckIds(nodes[i].Nodes, ref ids);
                }
            }
        }

        private void GetOrderSqls(TreeNodeCollection nodes, ref List<string> sqls, int num)
        {
            string sql = "";

            for (int i = 0; i < nodes.Count; i++)
            {
                sql = string.Format("update kbs_tree_section set num = '{1}' where id = '{0}'",
                                     nodes[i].Tag, ++num);
                sqls.Add(sql);

                if (nodes[i].Nodes.Count > 0)
                {
                    GetOrderSqls(nodes[i].Nodes, ref sqls, num);
                }
            }
        }

        private bool Flag = false;
        private string lastText = "";
        private ArrayList SelectNodes = new ArrayList();//记录查找过的节点

        /// <summary>
        /// 查找节点
        /// </summary>
        /// <param name="tn"></param>
        public void FindNode(TreeNodeCollection tn)
        {
            if (Flag)
            {
                for (int i = 0; i < tn.Count; i++)
                {
                    if (Flag == false)
                    {
                        break;
                    }
                    if (tn[i].Text.Trim().Contains(this.txtComplexName.Text.Trim()))
                    {
                        if (SelectNodes.Count > 0)
                        {
                            Flag = false;
                            for (int j = 0; j < SelectNodes.Count; j++)
                            {

                                if (tn[i].Tag == ((TreeNode)SelectNodes[j]).Tag &&
                                    tn[i].Text == ((TreeNode)SelectNodes[j]).Text) //判断是否选择过
                                {
                                    Flag = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Flag = false;
                        }

                        if (!Flag)
                        {
                            this.advTreeSmallTemplate.SelectedNode = tn[i];
                            this.SelectNodes.Add(tn[i].Clone());
                            break;
                        }
                    }
                    if (Flag)
                    {
                        if (tn[i].Nodes.Count > 0)
                        {
                            FindNode(tn[i].Nodes);
                        }
                    }
                }
            }
        }

        #endregion

        private void cmDirectory_Opening(object sender, CancelEventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode == null)
            {
                this.cmDirectory.Visible = false;
                return;
            }

            if (this.advTreeSmallTemplate.SelectedNode.Text == "专科知识库" && this.advTreeSmallTemplate.SelectedNode.Parent == null)
            {
                this.zToolStripMenuItem.Visible = true;
                toolStripMenuItem1.Visible = false;
                toolStripMenuItem2.Visible = false;
            }
            else
            {
                toolStripMenuItem1.Visible = true;
                toolStripMenuItem2.Visible = true;
            }

            if (this.advTreeSmallTemplate.SelectedNode.ImageIndex == 2)
            {
                this.zToolStripMenuItem.Visible = false;
                this.父节点选择StripMenuItem.Visible = true;
            }
            else
            {
                this.zToolStripMenuItem.Visible = true;
                this.父节点选择StripMenuItem.Visible = false;
            }
        }

        //当前操作复杂元素的状态
        private string complexAction = "ADD";

        private void advTreeSmallTemplate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.complexAction = "ADD";

            if (this.advTreeSmallTemplate.SelectedNode != null )
            {
                XmlDocument xmldoc = new XmlDocument();//加入XML的声明段落                

                if (this.advTreeSmallTemplate.SelectedNode.ImageIndex == 2)
                {
                    xmldoc.PreserveWhitespace = true;
                    string strXml = GetXmlContent();
                    xmldoc.LoadXml(strXml);
                    xmlNode = xmldoc.SelectSingleNode("emrtextdoc");//查找<body>

                    DataTable dt =
                        App.GetDataSet("select content from kbs_tempplate_cont where tid=" + this.advTreeSmallTemplate.SelectedNode.Tag.ToString() + "").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.complexAction = "UPDATE";

                        foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                        {
                            if (bodyNode.Name == "body")
                            {
                                bodyNode.InnerXml = dt.Rows[0]["content"].ToString();
                                LoadContent = dt.Rows[0]["content"].ToString();
                            }
                        }

                        this.text.MyDoc.FromXML(xmldoc.DocumentElement);
                        this.text.MyDoc.ContentChanged();

                        XmlDocument dc = new XmlDocument();
                        dc.LoadXml(GetXmlContent());
                        this.rtbComplexElement.Text = dc.DocumentElement.SelectNodes("text").Item(0).InnerText;
                    }
                    else
                    {
                        this.rtbComplexElement.Text = "";
                        this.text.MyDoc.ClearContent();
                        this.text.MyDoc.ContentChanged();
                    }

                    this.advTreeSmallTemplate.Focus();
                    this.btnSelect.Enabled = true;
                    this.btnOK.Enabled = true;
                }
                else
                {
                    this.rtbComplexElement.Text = "";

                    this.text.MyDoc.ClearContent();
                    this.text.MyDoc.ContentChanged();

                    this.btnSelect.Enabled = false;
                    this.btnOK.Enabled = false;
                }
            }
        }

        private void btnComplexSave_Click(object sender, EventArgs e)
        {
            string tempxml = GetXmlContent();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = true;
            xmldoc.LoadXml(tempxml);

            XmlElement xmlElement = xmldoc.DocumentElement;
            int message = 0;
            try
            {
                foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {

                        if (bodyNode.HasChildNodes)
                        {
                            if (complexAction == "ADD")
                            {
                                int id = App.GenId();
                                string sql_clob = "insert into kbs_tempplate_cont(id,tid,CONTENT)values(" + id + "," + advTreeSmallTemplate.SelectedNode.Tag + ",:doc1)";
                                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                xmlPars[0] = new MySqlDBParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].DBType = MySqlDbType.Text;
                                message = App.ExecuteSQL(sql_clob, xmlPars);
                                if (message > 0)
                                {
                                    App.Msg("保存成功！");
                                }
                                else
                                {
                                    App.Msg("保存失败！");
                                }
                            }
                            else
                            {
                                String sql_clob = string.Format("update kbs_tempplate_cont set CONTENT=:doc1 where TID = '{0}'", advTreeSmallTemplate.SelectedNode.Tag);
                                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                xmlPars[0] = new MySqlDBParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].DBType = MySqlDbType.Text;
                                message = App.ExecuteSQL(sql_clob, xmlPars);
                                if (message > 0)
                                {
                                    App.Msg("保存成功！");
                                }
                                else
                                {
                                    App.Msg("保存失败！");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("保存失败,错误原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 知识库提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            #region 复选框多条插入
            //string ids = "";
            //GetCheckIds(advTreeSmallTemplate.Nodes,ref ids);
            //if (ids != "")
            //{
            //    string sql = "select content from kbs_tempplate_cont where tid  in (" + ids + ") order by tid";
            //    DataSet dsTemp = App.GetDataSet(sql);
            //    DataTable dtTemp = dsTemp.Tables[0];
            //    string content = "";
            //    for (int i = 0; i < dtTemp.Rows.Count; i++)
            //    {
            //        content = content + dtTemp.Rows[i][0].ToString();
            //    }

            //    LoadContent = content.Remove(content.Length - 25);

            //    if (IsTextInput)
            //    {
            //        XmlDocument xmldoc = new XmlDocument();
            //        xmldoc.PreserveWhitespace = true;
            //        string strXml = GetXmlContent();
            //        xmldoc.LoadXml(strXml);
            //        xmlNode = xmldoc.SelectSingleNode("emrtextdoc");//查找<body>

            //        foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            //        {
            //            if (bodyNode.Name == "body")
            //            {
            //                bodyNode.InnerXml = LoadContent;
            //            }
            //        }

            //        this.text.MyDoc.FromXML(xmldoc.DocumentElement);
            //        XmlDocument dc = new XmlDocument();
            //        dc.LoadXml(GetXmlContent());
            //        this.inputText.Text = dc.DocumentElement.SelectNodes("text").Item(0).InnerText;
            //        this.inputText.OwnerDocument.ContentChanged();
            //    }
            //    else
            //    {              
            //        CurrentTextEdit.MyDoc._insertElements("<a>" + LoadContent + "</a>");
            //    }
            //}
            #endregion

            if (IsTextInput)
            {
                XmlDocument dc = new XmlDocument();
                dc.LoadXml(GetXmlContent());
                this.inputText.Text = dc.DocumentElement.SelectNodes("text").Item(0).InnerText;
                this.inputText.OwnerDocument.ContentChanged();
            }
            else
            {
                CurrentTextEdit.MyDoc._insertElements("<a>" + LoadContent + "</a>");
            }

            this.FindForm().Close();
        }

        private void 排序确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 1;
            List<string> Sqls = new List<string>();
            GetOrderSqls(advTreeSmallTemplate.Nodes[0].Nodes, ref Sqls, num);

            if (Sqls.Count == 0) return;

            try
            {
                App.ExecuteBatch(Sqls.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            App.Msg("排序成功!");
        }

        private void buttonXX_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.Nodes.Count > 0)
            {
                if (lastText != this.txtComplexName.Text)
                {
                    this.SelectNodes.Clear();
                }
                Flag = true;
                FindNode(this.advTreeSmallTemplate.Nodes);
                lastText = this.txtComplexName.Text;
                this.advTreeSmallTemplate.Focus();
                if (Flag)
                {
                    App.Msg("已查找到最后");
                    this.advTreeSmallTemplate.Nodes[0].Toggle();
                    this.advTreeSmallTemplate.Nodes[0].Expand();
                    this.SelectNodes.Clear();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadContent = this.rtbComplexElement.SelectedText;
            if (IsTextInput)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.PreserveWhitespace = true;
                string strXml = GetXmlContent();
                xmldoc.LoadXml(strXml);
                xmlNode = xmldoc.SelectSingleNode("emrtextdoc");//查找<body>

                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = LoadContent;
                    }
                }

                this.text.MyDoc.FromXML(xmldoc.DocumentElement);
                XmlDocument dc = new XmlDocument();
                dc.LoadXml(GetXmlContent());
                this.inputText.Text = dc.DocumentElement.SelectNodes("text").Item(0).InnerText;
                this.inputText.OwnerDocument.ContentChanged();
            }
            else
            {
                CurrentTextEdit.MyDoc._insertElements("<a>" + LoadContent + "</a>");
            }

            this.FindForm().Close();
        }


    }
}
