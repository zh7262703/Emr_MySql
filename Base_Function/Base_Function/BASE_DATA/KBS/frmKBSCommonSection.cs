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
using Bifrost.WebReference;
using Base_Function.BASE_DATA.KBS;
using System.Collections;

namespace Base_Function.BASE_DATA
{
    public partial class frmKBSCommonSection : UserControl
    {     
        private XmlNode xmlNode;
        public frmText CurrentTextEdit;   //编辑器当前操作的编辑器      
        private frmText text; //展示用编辑器
        private DataTable dtParent = new DataTable();   //目录表

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
        public frmKBSCommonSection()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            text = new frmText();
            text.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(text);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ucText"></param>
        public frmKBSCommonSection(frmText ucText)
        {
            InitializeComponent();
            App.UsControlStyle(this);
            CurrentTextEdit = ucText;
            text = new frmText();
            text.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(text);
        }

        private void frmKBSCommon_Load(object sender, EventArgs e)
        {
            TreeRefresh();

            if (this.advTreeSmallTemplate.Nodes.Count > 0)
            {
                this.advTreeSmallTemplate.Nodes[0].Expand();
            }

            this.btnComplexSave.Enabled = false;
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
                frmUpdateParentNode frmUpn = new frmUpdateParentNode(this.advTreeSmallTemplate.SelectedNode, Class_KBSOperType.更改父节点);
                if (frmUpn.ShowDialog() == DialogResult.OK)
                {
                    TreeRefresh();
                }
                
            }
        }

        private void 复制节点toolStripMenu_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode != null)
            {
                frmUpdateParentNode frmUpn = new frmUpdateParentNode(this.advTreeSmallTemplate.SelectedNode, Class_KBSOperType.复制节点);
                if (frmUpn.ShowDialog() == DialogResult.OK)
                {
                    TreeRefresh();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode != null && this.advTreeSmallTemplate.SelectedNode.Nodes.Count > 0)
            {
                App.MsgWaring("该类型节点下存在子节点，不允许执行删除操作！");
                return;
            }

            if (App.Ask("您确定要删除该节点吗？   \n\n提示：删除之后将无法恢复"))
            {
                if (this.advTreeSmallTemplate.SelectedNode != null)
                {

                    List<string> Sqls = new List<string>();
                    string sql = "delete from kbs_tree_section t where t.id = " + this.advTreeSmallTemplate.SelectedNode.Tag.ToString() + "";
                    Sqls.Add(sql);
                    sql = "delete from kbs_tempplate_cont t where t.tid  = " + this.advTreeSmallTemplate.SelectedNode.Tag.ToString() + "";
                    Sqls.Add(sql);

                    try
                    {
                        App.ExecuteBatch(Sqls.ToArray());
                        App.Msg("删除成功");
                        this.advTreeSmallTemplate.Nodes.Remove(this.advTreeSmallTemplate.SelectedNode);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
            advTreeSmallTemplate.Nodes.Clear();
            string sql = "select * from T_SECTIONINFO where ENABLE_FLAG='Y' ";
            DataSet ds = App.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode First = new TreeNode();//创建根节点
                First.Text = dt.Rows[i]["section_name"].ToString();//获取科室
                dtParent = App.GetDataSet("SELECT * FROM kbs_tree_section a left join t_sectioninfo b on a.section_id = b.sid where b.section_name = '" + First.Text +"' ORDER BY PARENTID").Tables[0];
                First.ImageIndex = 0;
                First.Tag = "0";
                First.SelectedImageIndex = 1;//文件夹
                First.ToolTipText = dt.Rows[i]["sid"].ToString();
                TreeChildNodesAdd(First, "0");//创建子节点的方法
                advTreeSmallTemplate.Nodes.Add(First);//添加根节点
             }
              
             GC.Collect();
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
                tn2.ToolTipText = dr["section_id"].ToString();
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

            if (this.advTreeSmallTemplate.SelectedNode.Parent == null)
            {
                toolStripMenuItem1.Visible = false;
                toolStripMenuItem2.Visible = false;

                父节点选择StripMenuItem.Visible = false;
                复制节点toolStripMenu.Visible = false;

                tspUp.Visible = false;
                tspDown.Visible = false;
                排序确认ToolStripMenuItem.Visible = true;
            }
            else
            {
                toolStripMenuItem1.Visible = true;
                toolStripMenuItem2.Visible = true;

                父节点选择StripMenuItem.Visible = true;
                复制节点toolStripMenu.Visible = true;

                tspUp.Visible = true;
                tspDown.Visible = true;
                排序确认ToolStripMenuItem.Visible = false;
            }

            if (this.advTreeSmallTemplate.SelectedNode.ImageIndex == 2)
            {
                this.zToolStripMenuItem.Visible = false;
                //this.父节点选择StripMenuItem.Visible = true;
            }
            else
            {
                this.zToolStripMenuItem.Visible = true;
                //this.父节点选择StripMenuItem.Visible = false;
            }

            //this.父节点选择StripMenuItem.Visible = false;
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
                    //this.txtComplexName.Text = this.advTreeSmallTemplate.SelectedNode.Text.Trim();
                    this.btnComplexSave.Enabled = true;

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
                            }
                        }

                        this.text.MyDoc.FromXML(xmldoc.DocumentElement);
                        this.text.MyDoc.ContentChanged();
                    }
                    else
                    {
                        this.text.MyDoc.ClearContent();
                        this.text.MyDoc.ContentChanged();
                    }

                    this.advTreeSmallTemplate.Focus();
                }
                else
                {
                    //this.txtComplexName.Text = "";
                    this.btnComplexSave.Enabled = false;

                    this.text.MyDoc.ClearContent();
                    this.text.MyDoc.ContentChanged();
                }
            }
        }

        private void ImportSmallTemplate()
        {
            try
            {
                string sql = @"select t.tid,t.tname,t.temptype,c.content,DBMS_LOB.getlength(c.content) from T_TEMPPLATE_tempin t 
inner join T_TEMPPLATE_CONT_tempin c on t.tid = c.tid
where t.temptype = 'S'";

                DataSet ds = App.GetDataSet(sql);

                string tid = "";
                string cont = "";
                string name = "";

                List<string> sqls = new List<string>();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        tid = ds.Tables[0].Rows[i]["tid"].ToString();
                        cont = ds.Tables[0].Rows[i]["content"].ToString();
                        name = ds.Tables[0].Rows[i]["tname"].ToString();

                        string sql1 = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,num) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                 name, "10944063", "3", tid, "10939283", tid);
                        sqls.Add(sql1);

                        //int id = App.GenId();
                        //string sql_clob = "insert into kbs_tempplate_cont(id,tid,CONTENT)values(" + id + "," + tid + ",:doc1)";
                        //OracleParameter[] xmlPars = new OracleParameter[1];
                        //xmlPars[0] = new OracleParameter();
                        //xmlPars[0].ParameterName = "doc1";
                        //xmlPars[0].Value = cont;
                        //xmlPars[0].OracleType = OracleType.Clob;
                        //App.ExecuteSQL(sql_clob, xmlPars);
                    }

                    App.ExecuteBatch(sqls.ToArray());
                }
            }
            catch(Exception ex) 
            {
                App.MsgErr("导入失败！" + ex.ToString());
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
                                OracleParameter[] xmlPars = new OracleParameter[1];
                                xmlPars[0] = new OracleParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].OracleType = OracleType.Clob;
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
                                OracleParameter[] xmlPars = new OracleParameter[1];
                                xmlPars[0] = new OracleParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].OracleType = OracleType.Clob;
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


        private void 排序确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 1;
            List<string> Sqls = new List<string>();

            if (advTreeSmallTemplate.SelectedNode != null)
            {
                GetOrderSqls(advTreeSmallTemplate.SelectedNode.Nodes, ref Sqls, num);
            }

            if (Sqls.Count == 0) return;

            try
            {
                App.ExecuteBatch(Sqls.ToArray());
                App.Msg("排序成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    this.btnComplexSave.Enabled = false;

                }
            }
        }

        

    }
}
