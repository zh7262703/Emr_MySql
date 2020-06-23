using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using System.Collections;

namespace Base_Function.BASE_DATA.KBS
{
    public partial class frmUpdateParentNode : Office2007Form
    {

        private TreeNode selectNode = new TreeNode();
        private Class_KBSOperType selectType = Class_KBSOperType.复制节点;
        private DataTable dtParent = new DataTable();   //目录表
        private bool Flag = false;
        private string lastText = "";
        private ArrayList SelectNodes = new ArrayList();//记录查找过的节点

        public frmUpdateParentNode(TreeNode node,Class_KBSOperType type)
        {
            InitializeComponent();

            this.selectNode = node;
            this.selectType = type;
        }

        /// <summary>
        /// 刷新所有节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeRefresh()
        {
            advTreeSmallTemplate.Nodes.Clear();
            string sql = "select * from T_SECTIONINFO where ENABLE_FLAG='Y' and ISBELONGTOBIGSECTION='Y'";
            DataSet ds = App.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode First = new TreeNode();//创建根节点
                First.Text = dt.Rows[i]["section_name"].ToString();//获取科室
                dtParent = App.GetDataSet("SELECT * FROM kbs_tree_section a left join t_sectioninfo b on a.section_id = b.sid where a.showtype != 3 and b.section_name = '" + First.Text + "' ORDER BY PARENTID").Tables[0];
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
        /// 获取需要更新的子节点ID
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="ids"></param>
        private void GetUpdateParentIds(TreeNodeCollection nodes, ref string ids)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (ids == "")
                {
                    ids = "'" + nodes[i].Tag.ToString() + "'";
                }
                else
                {
                    ids = ids + ",'" + nodes[i].Tag.ToString() + "'";
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    GetUpdateParentIds(nodes[i].Nodes, ref ids);
                }
            }
        }

        /// <summary>
        /// 复制节点目录（包含子节点）
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="parentId"></param>
        /// <param name="sqls"></param>
        /// <param name="num"></param>
        /// <param name="sectionId"></param>
        private void GetDirectSqls(TreeNodeCollection nodes, string parentId, ref List<string> sqls, int num, string sectionId)
        {
            string sql = "";
            for (int i = 0; i < nodes.Count; i++)
            {
                string id = App.GenId().ToString();
                if (nodes[i].ImageIndex == 0)
                {
                    sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,NUM) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         nodes[i].Text, parentId, 2, id, sectionId, ++num);
                    sqls.Add(sql);
                }

                if (nodes[i].ImageIndex == 2)
                {
                    sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,NUM) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         nodes[i].Text, parentId, 3, id, sectionId, ++num);
                    sqls.Add(sql);
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    GetDirectSqls(nodes[i].Nodes, id, ref sqls, num, sectionId);
                }
            }
        }

        /// <summary>  
        /// 按字符串长度切分成数组  
        /// </summary>  
        /// <param name="str">原字符串</param>  
        /// <param name="separatorCharNum">切分长度</param>  
        /// <returns>字符串数组</returns>  
        private string[] SplitByLen(string str, int separatorCharNum)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= separatorCharNum)
            {
                return new string[] { str };
            }
            string tempStr = str;
            List<string> strList = new List<string>();
            int iMax = Convert.ToInt32(Math.Ceiling(str.Length / (separatorCharNum * 1.0)));//获取循环次数  
            for (int i = 1; i <= iMax; i++)
            {
                string currMsg = tempStr.Substring(0, tempStr.Length > separatorCharNum ? separatorCharNum : tempStr.Length);
                strList.Add(currMsg);
                if (tempStr.Length > separatorCharNum)
                {
                    tempStr = tempStr.Substring(separatorCharNum, tempStr.Length - separatorCharNum);
                }
            }
            return strList.ToArray();
        }


        private string GetClobContent(string content)
        {
            string[] arr = SplitByLen(content, 2000);
            string s = string.Empty;
            foreach (string str in arr)
            {
                if (s == string.Empty)
                {
                    s = "to_clob('" + str + "')";
                }
                else
                {
                    s = s + "||to_clob('" + str + "')";
                }
            }

            return s;
        }

        /// <summary>
        /// 复制节点目录+内容（包含子节点）
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="parentId"></param>
        /// <param name="sqls"></param>
        /// <param name="num"></param>
        /// <param name="sectionId"></param>
        private void GetDirectContSqls(TreeNodeCollection nodes, string parentId, ref List<string> sqls, int num, string sectionId)
        {
            DataTable dt = new DataTable();
            string content = "";
            string sql = "";
            for (int i = 0; i < nodes.Count; i++)
            {
                string id = App.GenId().ToString();
                if (nodes[i].ImageIndex == 0)
                {
                    sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,NUM) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         nodes[i].Text, parentId, 2, id, sectionId, ++num);
                    sqls.Add(sql);
                }

                if (nodes[i].ImageIndex == 2)
                {
                    sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,NUM) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                         nodes[i].Text, parentId, 3, id, sectionId, ++num);
                    sqls.Add(sql);

                    dt = App.GetDataSet("select content from kbs_tempplate_cont where tid=" + nodes[i].Tag.ToString() + "").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        content = GetClobContent(dt.Rows[0]["content"].ToString());
                        sql = "insert into kbs_tempplate_cont(id,tid,CONTENT)values(" + id + "," + id + "," + content + ")";
                        sqls.Add(sql);
                    }
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    GetDirectContSqls(nodes[i].Nodes, id, ref sqls, num, sectionId);
                }
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.advTreeSmallTemplate.SelectedNode == null)
            {
                App.Msg("请选中节点后再执行此操作！");
                return;
            }

            TreeNode pathNode = this.advTreeSmallTemplate.SelectedNode; //路径节点

            string sql = "";
            List<string> Sqls = new List<string>();

            try
            {

                if (selectType == Class_KBSOperType.更改父节点)
                {
                    sql = string.Format("update kbs_tree_section set parentid = '{0}',SECTION_ID = '{1}' where id = '{2}'", pathNode.Tag.ToString(), pathNode.ToolTipText.Trim(), selectNode.Tag.ToString());
                    Sqls.Add(sql);

                    string ids = "";
                    GetUpdateParentIds(selectNode.Nodes, ref ids);
                    if (ids != "")
                    {
                        sql = "update kbs_tree_section set SECTION_ID = '" + pathNode.ToolTipText.Trim() + "' where id in (" + ids + ")";
                        Sqls.Add(sql);
                    }

                    App.ExecuteBatch(Sqls.ToArray());
                }
                else
                {
                    if (rbnTitle.Checked)         //复制标题
                    {
                        string id = App.GenId().ToString();
                        int showType = selectNode.ImageIndex == 0 ? 2 : 3;
                        sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,num) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                             selectNode.Text, pathNode.Tag.ToString(), showType, id, pathNode.ToolTipText.Trim(), id);
                        App.ExecuteSQL(sql);
                    }
                    else if (rbnDirector.Checked) //复制目录
                    {
                        string id = App.GenId().ToString();
                        int showType = selectNode.ImageIndex == 0 ? 2 : 3;
                        sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,num) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                             selectNode.Text, pathNode.Tag.ToString(), showType, id, pathNode.ToolTipText.Trim(), id);

                        Sqls.Add(sql);

                        GetDirectSqls(selectNode.Nodes, id, ref Sqls, 1, pathNode.ToolTipText.Trim());

                        App.ExecuteBatch(Sqls.ToArray());
                    }
                    else //复制目录+内容
                    {
                        string id = App.GenId().ToString();
                        int showType = selectNode.ImageIndex == 0 ? 2 : 3;
                        sql = string.Format("INSERT INTO kbs_tree_section(NAME,PARENTID,SHOWTYPE,id,SECTION_ID,num) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                             selectNode.Text, pathNode.Tag.ToString(), showType, id, pathNode.ToolTipText.Trim(), id);

                        Sqls.Add(sql);

                        if (showType == 3)
                        {
                            DataTable dt = App.GetDataSet("select content from kbs_tempplate_cont where tid=" + selectNode.Tag.ToString() + "").Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string content = GetClobContent(dt.Rows[0]["content"].ToString());
                                sql = "insert into kbs_tempplate_cont(id,tid,CONTENT)values(" + id + "," + id + "," + content + ")";
                                Sqls.Add(sql);
                            }
                        }
                        else
                        {
                            GetDirectContSqls(selectNode.Nodes, id, ref Sqls, 1, pathNode.ToolTipText.Trim());
                        }

                        App.ExecuteBatch(Sqls.ToArray());
                    }
                }
            }
            catch { }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmUpdateParentNode_Load(object sender, EventArgs e)
        {
            if (selectType == Class_KBSOperType.更改父节点)
            {
                panel5.Visible = false;
            }

            this.Text = selectType.ToString() + ":" + selectNode.Text;

            TreeRefresh();

            if (this.advTreeSmallTemplate.Nodes.Count > 0)
            {
                this.advTreeSmallTemplate.Nodes[0].Expand();
            }
        }

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
    }

    /// <summary>
    /// 知识库操作类型
    /// </summary>
    public enum Class_KBSOperType
    {
        复制节点,
        更改父节点
    }
}
