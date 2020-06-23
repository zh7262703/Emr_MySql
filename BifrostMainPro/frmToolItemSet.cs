using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using DevComponents.AdvTree;

namespace BifrostMainPro
{

    /// <summary>
    /// 系统工具栏设置
    /// 作者：张华
    /// 时间：2012-5-14
    /// </summary>
    public partial class frmToolItemSet : Office2007Form
    {
        string strOlds = "";
       
        ButtonItem[] ToolBtns;
        public frmToolItemSet()
        {
            InitializeComponent();
        }

        #region 自定义函数
        /// <summary>
        /// 节点的上移
        /// </summary>
        /// <param name="ObjNode">选中节点</param>
        /// <param name="trvTypedCategory">树控件</param>
        private void NodeMovUp(Node ObjNode, AdvTree trvTypedCategory)
        {
            //----节点的向上移动   
            if (ObjNode != null)
            {
                Node newnode = new Node();
                //--------如果选中节点为最顶节点   
                if (ObjNode.Index == 0)
                {
                    //-------------   
                }
                else if (ObjNode.Index != 0)
                {
                    newnode = ObjNode.Copy();
                    //-------------若选中节点为根节点   
                    if (ObjNode.Level == 0)
                    {
                        trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    //-------------若选中节点并非根节点   
                    else if (ObjNode.Level != 0)
                    {
                        ObjNode.Parent.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    ObjNode.Remove();
                    ObjNode = newnode;
                    trvTypedCategory.SelectedNode = ObjNode;
                }
            }
        }

        /// <summary>
        /// 节点的下移
        /// </summary>
        /// <param name="ObjNode">树节点</param>
        /// <param name="trvTypedCategory">树控件</param>
        private void NodeMovDown(Node ObjNode, AdvTree trvTypedCategory)
        {
            //----节点的向下移动   
            if (ObjNode != null)
            {
                Node newnode = new Node();
                //-------------如果选中的是根节点   
                if (ObjNode.Level == 0)
                {
                    //---------如果选中节点为最底节点   
                    if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
                    {
                        //---------------   
                    }
                    //---------如果选中的不是最底的节点   
                    else
                    {
                        newnode = ObjNode.Copy();
                        trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;

                    }
                }
                //-------------如果选中节点不是根节点   
                else if (ObjNode.Level != 0)
                {
                    //---------如果选中最底的节点   
                    if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
                    {
                        //-----------   
                    }
                    //---------如果选中的不是最低的节点   
                    else
                    {
                        newnode = ObjNode.Copy();
                        ObjNode.Parent.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;
                    }
                }
                trvTypedCategory.SelectedNode = ObjNode;
            }
        }

        /// <summary>
        /// 获取所有的工具栏按钮
        /// </summary>
        /// <param name="toolBtns"></param>
        public frmToolItemSet(ButtonItem[] toolBtns)
        {
            InitializeComponent();
            ToolBtns = toolBtns;            
        }

        /// <summary>
        /// 添加/移除操作
        /// </summary> 
        /// <param name="AddTr">需要添加的书</param>
        /// <param name="DelTr">需要移除的树</param>
        private void AddOrRemoveNode(DevComponents.AdvTree.AdvTree AddTr, DevComponents.AdvTree.AdvTree DelTr)
        {
            //添加选中的项
            for (int i = 0; i < DelTr.Nodes.Count; i++)
            {
                if (DelTr.Nodes[i].Checked)
                {
                    DelTr.Nodes[i].Checked = false;
                    AddTr.Nodes.Add(DelTr.Nodes[i].Copy());
                    DelTr.Nodes.Remove(DelTr.Nodes[i]);
                    AddOrRemoveNode(AddTr, DelTr);
                }
            }
        }

        /// <summary>
        /// 原始设置
        /// </summary>
        /// <param name="StrOlds"></param>
        private void ReSet(string StrOlds)
        {
            advTree_AllTools.Nodes.Clear();
            for (int i = 0; i < ToolBtns.Length; i++)
            {
                DevComponents.AdvTree.Node temp = new DevComponents.AdvTree.Node();
                temp.Image = ToolBtns[i].Image;
                temp.Text = ToolBtns[i].Text;
                temp.Name = ToolBtns[i].Name;
                temp.CheckBoxVisible = true;
                advTree_AllTools.Nodes.Add(temp);
            }
            advTree_SelectedTools.Nodes.Clear();
            AdvTree TempadvTree = new AdvTree();
            if (StrOlds != "")
            {               

                for (int i = 0; i < StrOlds.Split(',').Length; i++)
                {
                    for (int j = 0; j < advTree_AllTools.Nodes.Count; j++)
                    {
                        if (StrOlds.Split(',')[i] == advTree_AllTools.Nodes[j].Name)
                        {
                            advTree_AllTools.Nodes[j].Checked = true;
                            TempadvTree.Nodes.Add(advTree_AllTools.Nodes[j].Copy());
                        }
                    }
                }                              
                for (int i = 0; i < TempadvTree.Nodes.Count; i++)
                {
                    TempadvTree.Nodes[i].Checked = false;
                    advTree_SelectedTools.Nodes.Add(TempadvTree.Nodes[i].Copy());
                }


                AddOrRemoveNode(TempadvTree, advTree_AllTools);
            }
            else
            {
                AddOrRemoveNode(advTree_AllTools, advTree_SelectedTools);
            }
        }
        #endregion

        private void frmToolItemSet_Load(object sender, EventArgs e)
        {
            comboBoxExSet.SelectedIndex = 0;
            if (ToolBtns != null)
            {
                advTree_AllTools.Nodes.Clear();
                for (int i = 0; i < ToolBtns.Length; i++)
                {
                    DevComponents.AdvTree.Node temp = new DevComponents.AdvTree.Node();
                    temp.Image = ToolBtns[i].Image;                    
                    temp.Text = ToolBtns[i].Text;
                    temp.Name = ToolBtns[i].Name;                  
                    temp.CheckBoxVisible = true;
                    advTree_AllTools.Nodes.Add(temp);
                }                
                strOlds=App.Read_ConfigInfo("SYSTEMSET", "TOOLS", Application.StartupPath + "\\Config.ini");               
                ReSet(strOlds);
            }          
        }      

        /// <summary>
        /// 保存按钮设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("重设工具栏之后将会重新启动电子病历系统，确定要修改吗？"))
                {
                    string strToolSet = "";
                    for (int i = 0; i < advTree_SelectedTools.Nodes.Count; i++)
                    {
                        if (strToolSet == "")
                        {
                            strToolSet = advTree_SelectedTools.Nodes[i].Name;
                        }
                        else
                        {
                            strToolSet = strToolSet + "," + advTree_SelectedTools.Nodes[i].Name;
                        }
                    }
                    int resount = 0;
                    if (comboBoxExSet.SelectedIndex == 0)
                    {
                        App.Write_ConfigInfo("SYSTEMSET", "TOOLS", strToolSet, Application.StartupPath + "\\Config.ini");
                        resount = 1;
                    }
                    else
                    {
                        //App.Write_ConfigInfo("SYSTEMSET", App.UserAccount.Account_name, strToolSet, Application.StartupPath + "\\Config.ini");
                        string[] sqls = new string[2];
                        sqls[0] = "delete from T_ACCOUNT_SET where ACCOUNT_ID="+App.UserAccount.Account_id+"";
                        sqls[1] = "insert into T_ACCOUNT_SET(ACCOUNT_ID,TOOL_BUTTON_SET)values(" + App.UserAccount.Account_id + ",'" + strToolSet + "')";
                        resount = App.ExecuteBatch(sqls);                       
                    }
                    if (resount > 0)
                        App.Msg("设置成功！");
                    else
                        App.MsgErr("设置失败！");
                    frmMain.isReset = true;
                    Application.Restart();
                }

            }
            catch(Exception ex)
            {
                App.MsgErr("设置失败，原因："+ex.Message);
            }
        }

        /// <summary>
        /// 添加选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrRemoveNode(advTree_SelectedTools, advTree_AllTools);
        }
      

        /// <summary>
        /// 移除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            AddOrRemoveNode(advTree_AllTools,advTree_SelectedTools);
        }

        /// <summary>
        /// 退出操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 重置操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnBack_Click(object sender, EventArgs e)
        {
            ReSet(strOlds);
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
           
                for (int i = 0; i < advTree_SelectedTools.Nodes.Count; i++)
                {
                    if (chkSelectAll.Checked)
                    {
                        advTree_SelectedTools.Nodes[i].Checked = true;
                    }
                    else
                    {
                        advTree_SelectedTools.Nodes[i].Checked = false;
                    }
                }
            

        }



        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            NodeMovUp(advTree_SelectedTools.SelectedNode, advTree_SelectedTools);
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            NodeMovDown(advTree_SelectedTools.SelectedNode, advTree_SelectedTools);
        }

        /// <summary>
        /// 设置类型的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxExSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToolBtns != null)
            {
                advTree_AllTools.Nodes.Clear();
                for (int i = 0; i < ToolBtns.Length; i++)
                {
                    DevComponents.AdvTree.Node temp = new DevComponents.AdvTree.Node();
                    temp.Image = ToolBtns[i].Image;
                    temp.Text = ToolBtns[i].Text;
                    temp.Name = ToolBtns[i].Name;
                    temp.CheckBoxVisible = true;
                    advTree_AllTools.Nodes.Add(temp);
                }
                if (comboBoxExSet.SelectedIndex == 0)
                    strOlds = App.Read_ConfigInfo("SYSTEMSET", "TOOLS", Application.StartupPath + "\\Config.ini");
                else                
                {
                    strOlds = App.ReadSqlVal("select TOOL_BUTTON_SET from T_ACCOUNT_SET where ACCOUNT_ID=" + App.UserAccount.Account_id + "", 0, "TOOL_BUTTON_SET");
                    if (strOlds == null)
                        strOlds = "";
                }
                ReSet(strOlds);
            }       
        }
    }
}