using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Base_Function.BLL_FOLLOW;

namespace Base_Function.BASE_DATA
{
    public partial class frmFollowWrite_Type_TrvSelect : Office2007Form
    {
        private Class_Follow_Text selectClasstext = null;   //用于寄存当前选中的节点实例

        private string SelectId = "";

        public frmFollowWrite_Type_TrvSelect()
        {
            InitializeComponent();
        }
        public frmFollowWrite_Type_TrvSelect(string selectid)
        {
            InitializeComponent();
            SelectId = selectid;
        }

        private void frmWrite_Type_TrvSelect_Load(object sender, EventArgs e)
        {
            IniTreeView();
        }
        /// <summary>
        /// 初始化文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IniTreeView()
        {

            trvDictionary.Nodes.Clear();
            string SQl = "select * from T_FOLLOW_TEXT where  ENABLE_FLAG='Y'  order by ID asc";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Follow_Text[] Directionarys = GetSelectClassDs(ds);
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    //插入顶级节点
                    if (Directionarys[i].Parentid == 0)
                    {
                        trvDictionary.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn);
                    }
                }
                trvDictionary.ExpandAll();
            }
            
        }
        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
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
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;

                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["ISSIMPLEINSTANCE"].ToString();
                        class_text[i].Enable = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();

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
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="current">当前文书节点</param>
        private void SetTreeView(Class_Follow_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }
        private void trvDictionary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                {

                    selectClasstext = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;

                    bool flag = false; //当前节点不是本身或有关子节点

                    flag = isChild(SelectId, trvDictionary.SelectedNode);

                    if (!flag)
                    {
                        ucFollowWrite_Type.fahterId = selectClasstext.Id.ToString();
                        ucFollowWrite_Type.fahterName = selectClasstext.Textname;
                        ucFollowWrite_Type.texttype = selectClasstext.Txxttype;
                        this.Close();
                    }
                    else
                    {
                        App.Msg("你选择的节点是本身或者界别更低的节点！");
                    }
                }
            }
        }
        private void trvDictionary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private bool isChild(string selectid, TreeNode node)
        {
            if (node.Tag != null)
            {
                Class_Follow_Text temp = (Class_Follow_Text)node.Tag;
                if (temp.Id.ToString() == selectid)
                {
                    return true;
                }
                else
                {
                    if (node.Parent != null)
                    {
                        return isChild(selectid, node.Parent);
                    }
                }
            }
            return false;
        } 
    }
}