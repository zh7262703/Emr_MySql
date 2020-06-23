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
    /// ϵͳ����������
    /// ���ߣ��Ż�
    /// ʱ�䣺2012-5-14
    /// </summary>
    public partial class frmToolItemSet : Office2007Form
    {
        string strOlds = "";
       
        ButtonItem[] ToolBtns;
        public frmToolItemSet()
        {
            InitializeComponent();
        }

        #region �Զ��庯��
        /// <summary>
        /// �ڵ������
        /// </summary>
        /// <param name="ObjNode">ѡ�нڵ�</param>
        /// <param name="trvTypedCategory">���ؼ�</param>
        private void NodeMovUp(Node ObjNode, AdvTree trvTypedCategory)
        {
            //----�ڵ�������ƶ�   
            if (ObjNode != null)
            {
                Node newnode = new Node();
                //--------���ѡ�нڵ�Ϊ��ڵ�   
                if (ObjNode.Index == 0)
                {
                    //-------------   
                }
                else if (ObjNode.Index != 0)
                {
                    newnode = ObjNode.Copy();
                    //-------------��ѡ�нڵ�Ϊ���ڵ�   
                    if (ObjNode.Level == 0)
                    {
                        trvTypedCategory.Nodes.Insert(ObjNode.PrevNode.Index, newnode);
                    }
                    //-------------��ѡ�нڵ㲢�Ǹ��ڵ�   
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
        /// �ڵ������
        /// </summary>
        /// <param name="ObjNode">���ڵ�</param>
        /// <param name="trvTypedCategory">���ؼ�</param>
        private void NodeMovDown(Node ObjNode, AdvTree trvTypedCategory)
        {
            //----�ڵ�������ƶ�   
            if (ObjNode != null)
            {
                Node newnode = new Node();
                //-------------���ѡ�е��Ǹ��ڵ�   
                if (ObjNode.Level == 0)
                {
                    //---------���ѡ�нڵ�Ϊ��׽ڵ�   
                    if (ObjNode.Index == trvTypedCategory.Nodes.Count - 1)
                    {
                        //---------------   
                    }
                    //---------���ѡ�еĲ�����׵Ľڵ�   
                    else
                    {
                        newnode = ObjNode.Copy();
                        trvTypedCategory.Nodes.Insert(ObjNode.NextNode.Index + 1, newnode);
                        ObjNode.Remove();
                        ObjNode = newnode;

                    }
                }
                //-------------���ѡ�нڵ㲻�Ǹ��ڵ�   
                else if (ObjNode.Level != 0)
                {
                    //---------���ѡ����׵Ľڵ�   
                    if (ObjNode.Index == ObjNode.Parent.Nodes.Count - 1)
                    {
                        //-----------   
                    }
                    //---------���ѡ�еĲ�����͵Ľڵ�   
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
        /// ��ȡ���еĹ�������ť
        /// </summary>
        /// <param name="toolBtns"></param>
        public frmToolItemSet(ButtonItem[] toolBtns)
        {
            InitializeComponent();
            ToolBtns = toolBtns;            
        }

        /// <summary>
        /// ���/�Ƴ�����
        /// </summary> 
        /// <param name="AddTr">��Ҫ��ӵ���</param>
        /// <param name="DelTr">��Ҫ�Ƴ�����</param>
        private void AddOrRemoveNode(DevComponents.AdvTree.AdvTree AddTr, DevComponents.AdvTree.AdvTree DelTr)
        {
            //���ѡ�е���
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
        /// ԭʼ����
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
        /// ���水ť����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("���蹤����֮�󽫻������������Ӳ���ϵͳ��ȷ��Ҫ�޸���"))
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
                        App.Msg("���óɹ���");
                    else
                        App.MsgErr("����ʧ�ܣ�");
                    frmMain.isReset = true;
                    Application.Restart();
                }

            }
            catch(Exception ex)
            {
                App.MsgErr("����ʧ�ܣ�ԭ��"+ex.Message);
            }
        }

        /// <summary>
        /// ���ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrRemoveNode(advTree_SelectedTools, advTree_AllTools);
        }
      

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            AddOrRemoveNode(advTree_AllTools,advTree_SelectedTools);
        }

        /// <summary>
        /// �˳�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ���ò���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnBack_Click(object sender, EventArgs e)
        {
            ReSet(strOlds);
        }

        /// <summary>
        /// ȫѡ
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            NodeMovUp(advTree_SelectedTools.SelectedNode, advTree_SelectedTools);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            NodeMovDown(advTree_SelectedTools.SelectedNode, advTree_SelectedTools);
        }

        /// <summary>
        /// �������͵ı仯
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