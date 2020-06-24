using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using TextEditor.TextDocument.Document;
using TextEditor;
using MySql.Data.MySqlClient;

namespace Base_Function.BASE_DATA
{
    public partial class frKnowledge : UserControl
    {
        public frKnowledge()
        {
            InitializeComponent();
            this.tcEdit.TabPages.Clear();
        }

        public frKnowledge(ZYTextDocument _myDocument)
        {
            InitializeComponent();
            this.tcEdit.TabPages.Clear();
            this.myDocument = _myDocument;
        }


        private ZYTextDocument myDocument;
        public ZYTextInput mySelect;
        private DataTable dtParent = new DataTable();   //Ŀ¼��
        private ArrayList SelectNodes = new ArrayList();//��¼���ҹ��Ľڵ�
        private frmText fmText = new frmText();


        public void setfrKnowledge(ZYTextInput _select, ZYTextDocument _myDocument)
        {
            if (this.myDocument == null)
            {
                this.myDocument = _myDocument;
            }
            Flag = true;
            this.mySelect = _select;
            enable();
            FindNode(this.tvDirectory.Nodes, _select.Name, _select.ListSource);
            this.tvDirectory_AfterSelect(null, null);
            this.tvDirectory.Focus();
        }

        /// <summary>
        /// �������ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frKnowledge_Load(object sender, EventArgs e)
        {
            TreeRefresh();
            if (this.tvDirectory.Nodes.Count > 0)
            {
                this.tvDirectory.Nodes[0].Expand();
            }
            this.panel6.Controls.Add(fmText);
            fmText.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// ���㶨λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDirectory_MouseDown(object sender, MouseEventArgs e)
        {
            this.tvDirectory.SelectedNode = tvDirectory.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// ˢ�����нڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeRefresh()
        {
            this.tvDirectory.Nodes.Clear();
            try
            {
                dtParent = App.GetDataSet("SELECT * FROM TABLE_F ORDER BY PARENTID").Tables[0];
            }
            catch
            {
                App.Msg("���粻ͨ�����������Ƿ����ã�");
                return;
            }
            TreeNode tn = new TreeNode("ͨ�ü�Ԫ��");
            tn.ImageIndex = 0;
            tn.Tag = "0";
            tn.ContextMenuStrip = this.cmDirectory;
            tn.SelectedImageIndex = 1;
            TreeChildNodesAdd(tn, "0");
            this.tvDirectory.Nodes.Add(tn);
            GC.Collect();
        }

        /// <summary>
        /// �ڵ����
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="parentId"></param>
        public void TreeChildNodesAdd(TreeNode tn, string parentId)
        {
            DataRow[] drs = dtParent.Select(string.Format("ParentId = '{0}'", parentId), "ID");
            foreach (DataRow dr in drs)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Text = dr["name"].ToString();
                tn2.Tag = dr["id"].ToString();
                //if (dr["id"].ToString() == "2366")
                //{ 

                //}
                tn2.Name = dr["showtype"].ToString();
                tn2.ContextMenuStrip = this.cmDirectory;
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
        /// �ڵ�ѡ��󴥷����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                TreeNode selectNode = this.tvDirectory.SelectedNode;
                this.tvList.Nodes.Clear();
                this.tcEdit.TabPages.Clear();
                switch (selectNode.ImageIndex)
                {
                    case 0:
                        this.tcEdit.TabPages.Add(this.tpDirectory);
                        this.lbMenu.Text = selectNode.Text;
                        this.tsMenuElement.Enabled = false;
                        break;
                    case 2:
                        this.tcEdit.TabPages.Add(this.tpElements);
                        this.lblELementName.Text = selectNode.Text;
                        this.tsMenuElement.Enabled = true;
                        LoadElements(selectNode.Tag.ToString());
                        break;
                }
            }
            this.tvDirectory.Focus();
        }


        public void LoadElements(string id)
        {
            string sql = string.Format("SELECT * FROM TABLE_E WHERE SIMPLEMETAID_F = '{0}' ORDER BY NUM", id);
            DataTable childNode = App.GetDataSet(sql).Tables[0];
            for (int i = 0; i < childNode.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Name = childNode.Rows[i]["ID"].ToString();
                tn.Text = childNode.Rows[i]["evalue"].ToString();
                tn.Tag = childNode.Rows[i]["evaluecode"].ToString();                
                if (childNode.Rows[i]["ITEM_STYLE"].ToString() == "100")
                {
                    tn.ImageIndex = 5;
                    tn.SelectedImageIndex = 5;
                }
                else
                {
                    tn.ImageIndex = 4;
                    tn.SelectedImageIndex = 4;
                }
                this.tvList.Nodes.Add(tn);
            }
        }


        private void ȫ��չ��WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                this.tvDirectory.SelectedNode.ExpandAll();
            }
        }


        private string lastText = "";
        /// <summary>
        /// ���ҽڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsp_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.Nodes.Count > 0)
            {
                if (lastText != this.txtSeachNode.Text)
                {
                    this.SelectNodes.Clear();
                }
                Flag = true;
                FindNode(this.tvDirectory.Nodes);
                lastText = this.txtSeachNode.Text;
                this.tvDirectory.Focus();
                if (Flag)
                {
                    App.Msg("�Ѳ��ҵ����");
                    this.tvDirectory.Nodes[0].Toggle();
                    this.tvDirectory.Nodes[0].Expand();
                    this.SelectNodes.Clear();
                }
            }
        }


        private bool Flag = false;

        /// <summary>
        /// ���ҽڵ�
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
                    if (tn[i].Text.Trim().Contains(this.txtSeachNode.Text.Trim()))
                    {
                        if (SelectNodes.Count > 0)
                        {
                            Flag = false;
                            for (int j = 0; j < SelectNodes.Count; j++)
                            {

                                if (tn[i].Tag == ((TreeNode)SelectNodes[j]).Tag &&
                                    tn[i].Text == ((TreeNode)SelectNodes[j]).Text) //�ж��Ƿ�ѡ���
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
                            this.tvDirectory.SelectedNode = tn[i];
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


        /// <summary>
        /// ���ҽڵ� 
        /// </summary>
        /// <param name="tn"></param>
        public void FindNode(TreeNodeCollection tn, string text, string tag)
        {
            if (Flag)
            {
                for (int i = 0; i < tn.Count; i++)
                {
                    if (Flag == false)
                    {
                        break;
                    }
                    if (tn[i].Text.Trim() == text.Trim() && tn[i].Tag.ToString() == tag)
                    {
                        this.tvDirectory.SelectedNode = tn[i];
                        Flag = false;
                        break;
                    }
                    if (Flag)
                    {
                        if (tn[i].Nodes.Count > 0)
                        {
                            FindNode(tn[i].Nodes, text, tag);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public void setLoadNode()
        {
            if (this.tvDirectory.Nodes.Count > 0)
            {
                this.tvDirectory.Nodes[0].Toggle();
                this.tvDirectory.Nodes[0].Expand();
            }

            this.tvDirectory_AfterSelect(null, null);
        }

        private void ȫ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                this.tvDirectory.SelectedNode.Toggle();
            }
        }

        /// <summary>
        /// ˢ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRefreshAll_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> list = new List<int>();
                TreeNode tn = this.tvDirectory.SelectedNode;
                string treeNodePath = tn.FullPath;
                for (int i = 0; i < treeNodePath.Split('��').Length; i++)
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
                if (this.tvDirectory.Nodes.Count > 0)
                {
                    TreeNodeCollection tn3 = this.tvDirectory.Nodes;
                    for (int i = list.Count; i > 0; i--)
                    {
                        if (i == 1)
                        {
                            this.tvDirectory.SelectedNode = tn3[list[0]];
                        }
                        else
                        {
                            tn3[list[i - 1]].Expand();
                            tn3 = tn3[list[i - 1]].Nodes;
                        }
                    }
                }
                this.tvDirectory.Focus();
            }
            catch (Exception)
            {
                //App.Msg("��Ԫ���ڱ�ĵط�����ɾ��");

                this.TreeRefresh();
                this.tvDirectory.Focus();
            }
        }

        /// <summary>
        /// ɾ��Ŀ¼/Ԫ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspDeleteNode_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ȷ��Ҫɾ���ýڵ���   \n\n��ʾ��ɾ��֮���޷��ָ�   ", "��ܰ��ʾ"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (this.tvDirectory.SelectedNode != null)
                {
                    try
                    {
                        string sql = string.Format("DELETE TABLE_F WHERE ID = '{0}' or parentId = '{1}'"
                                        , this.tvDirectory.SelectedNode.Tag.ToString(), this.tvDirectory.SelectedNode.Tag.ToString());
                        App.ExecuteSQL(sql);
                        this.tvDirectory.Nodes.Remove(this.tvDirectory.SelectedNode);
                        App.Msg("ɾ���ɹ�");
                    }
                    catch
                    {
                        App.Msg("���粻ͨ�����������Ƿ����ã�");
                    }
                }
            }
        }

        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ������Ŀ¼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.Nodes != null)
            {
                updateTitle udt = new updateTitle(0, this.tvDirectory.SelectedNode, "�½���Ŀ¼", "��������Ŀ¼�����ƣ�");
                udt.ShowDialog();
            }
        }

        /// <summary>
        /// ����ѡ����Ԫ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ѡ����Ԫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.Nodes != null)
            {
                updateTitle udt = new updateTitle(1, this.tvDirectory.SelectedNode, "�½�����Ԫ��", "������ѡ����Ԫ�ص����ƣ�");
                udt.ShowDialog();
            }
        }

        /// <summary>
        /// �����������Ԫ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �����������Ԫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.Nodes != null)
            {
                updateTitle udt = new updateTitle(2, this.tvDirectory.SelectedNode, "�½�����Ԫ��", "�������������Ԫ�ص����ƣ�");
                udt.ShowDialog();
            }
        }

        /// <summary>
        /// �Ҽ��˵�����Ŀ¼������ʵ��ͬѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmDirectory_Opening(object sender, CancelEventArgs e)
        {
            if (this.tvDirectory.SelectedNode == null)
            {
                this.cmDirectory.Visible = false;
                return;
            }

            if (this.tvDirectory.SelectedNode.Text == "ͨ�ü�Ԫ��" && this.tvDirectory.SelectedNode.Parent == null)
            {
                this.zToolStripMenuItem.Visible = true;
                toolStripMenuItem1.Visible = false;
                toolStripMenuItem2.Visible = false;
                return;
            }
            else
            {
                toolStripMenuItem1.Visible = true;
                toolStripMenuItem2.Visible = true;
            }

            if (this.tvDirectory.SelectedNode.ImageIndex == 2)
            {
                this.zToolStripMenuItem.Visible = false;
            }
            else
            {
                this.zToolStripMenuItem.Visible = true;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.Nodes != null && this.tvDirectory.SelectedNode.Parent != null)
            {
                updateTitle udt = new updateTitle(3, this.tvDirectory.SelectedNode, "�޸ı���", "�������µı������ƣ�");
                udt.ShowDialog();
            }
        }

        /// <summary>
        /// ���̰����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                if (this.tvDirectory.SelectedNode.ImageIndex == 0)
                {
                    if (e.Alt && (e.KeyCode.ToString() == "D1" || e.KeyCode.ToString() == "NumPad1"))
                    {
                        ������Ŀ¼ToolStripMenuItem_Click(null, null);
                    }
                    else if (e.Alt && (e.KeyCode.ToString() == "D2" || e.KeyCode.ToString() == "NumPad2"))
                    {
                        ����ѡ����Ԫ��ToolStripMenuItem_Click(null, null);
                    }
                    else if (e.Alt && (e.KeyCode.ToString() == "D3" || e.KeyCode.ToString() == "NumPad3"))
                    {
                        �����������Ԫ��ToolStripMenuItem_Click(null, null);
                    }
                }
            }
        }

        /// <summary>
        /// ˫��ѡ���б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDirectory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        /// <summary>
        /// ����֪ʶ���༭��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspBtnSelect_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                if (this.tvDirectory.SelectedNode.Name == "3")
                {
                    if (this.mySelect == null)
                    {
                        //this.Hide();
                        //this.myDocument._InsertKB(this.tvDirectory.SelectedNode.Text, this.tvDirectory.SelectedNode.Tag.ToString());
                        
                    }
                    else
                    {
                        this.mySelect.SelectType = "1";
                        this.mySelect.ListSource = this.tvDirectory.SelectedNode.Tag.ToString();
                        this.mySelect.Name = this.tvDirectory.SelectedNode.Text;
                        this.mySelect.Text = this.tvDirectory.SelectedNode.Text;
                       // this.mySelect.RefreshSize();
                        this.myDocument.ContentChanged();
                        this.Hide();
                    }
                }
            }
        }

        private void tspUp_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index > 0)
                {
                    dataSourceHelper.MovUp(tn, this.tvDirectory);
                }
            }
        }

        private void tspDown_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index < tn.Parent.Nodes.Count - 1)
                {
                    dataSourceHelper.MovDown(tn, this.tvDirectory);
                }
            }

        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index > 0)
                {
                    dataSourceHelper.MovUp(tn, this.tvDirectory);
                }
            }
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null && tn.Parent != null)
            {
                if (tn.Index < tn.Parent.Nodes.Count - 1)
                {
                    dataSourceHelper.MovDown(tn, this.tvDirectory);
                }
            }
        }

        /// <summary>
        /// ����Ԫ��չʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvList.SelectedNode != null)
            {
                this.tcEdit.TabPages.Clear();
                switch (this.tvList.SelectedNode.ImageIndex)
                {
                    case 4:
                        this.tcEdit.TabPages.Add(this.tpBasicElement);
                        this.txtName.Text = this.tvList.SelectedNode.Text;
                        this.txtNum.Text = this.tvList.SelectedNode.Index.ToString();
                        this.txtCode.Text = this.tvList.SelectedNode.Tag.ToString();
                        break;
                    case 5:
                        XmlDocument temp = new XmlDocument();
                        DataTable dt =
                            App.GetDataSet("select OBJECTDATA from et_document where objectid=" + this.tvList.SelectedNode.Tag.ToString() + "").Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            this.complexAction = "UPDATE";
                            this.txtComplexName.Text = this.tvList.SelectedNode.Text.Trim();
                            temp.LoadXml(dt.Rows[0]["OBJECTDATA"].ToString());
                            this.tcEdit.TabPages.Add(this.tpComplex);
                            this.fmText.MyDoc.FromXML(temp.DocumentElement);
                            this.fmText.MyDoc.ContentChanged();
                        }
                        break;
                }
                this.tvList.Focus();
            }
        }

        /// <summary>
        /// �����ͨԪ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null)
            {
                if (tn.ImageIndex == 2)
                {
                    this.txtName.Text = "";
                    if (this.tvList.Nodes.Count > 0)
                    {
                        this.txtNum.Text = this.tvList.Nodes.Count.ToString();
                    }
                    else
                    {
                        this.txtNum.Text = "0";
                    }

                    this.txtCode.Text = "";
                    Action = "ADD";
                    enable2();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvDirectory.SelectedNode;
            if (tn != null)
            {
                if (tn.ImageIndex == 2)
                {
                    Action = "ADD";
                    this.tcEdit.TabPages.Clear();
                    this.tcEdit.TabPages.Add(this.tpBasicElement);
                    this.txtName.Text = "";
                    if (this.tvList.Nodes.Count > 0)
                    {
                        this.txtNum.Text = this.tvList.Nodes.Count.ToString();
                    }
                    else
                    {
                        this.txtNum.Text = "0";
                    }

                    this.txtCode.Text = "";
                    enable2();
                }
            }
        }
        string Action = "ADD";
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.tvList.SelectedNode != null)
            {
                Action = "UPDATE";
                this.tvList_AfterSelect(null, null);
                enable2();
            }
        }

        public bool CheckElement()
        {
            if (txtName.Text.Trim() == "")
            {
                App.Msg("��Ԫ��ֵ���Ʋ���Ϊ�գ�");
                return false;
            }
            if (txtNum.Text.Trim() == "")
            {
                txtNum.Text = "0";
            }
            else
            {
                if (!App.isNumval(App.ToDBC(txtNum.Text)))
                {
                    App.Msg("��ű���Ϊ��ֵ���ͣ�");
                    txtNum.Focus();
                    txtNum.SelectAll();
                    return false;
                }
            }
            if (Action == "ADD")
            {
                foreach (TreeNode oldNode in this.tvList.Nodes)
                {
                    if (oldNode.Text.Trim() == this.txtName.Text.Trim())
                    {
                        App.Msg("�������ֵ�뵱ǰĿ¼�µ�ֵ�ظ���");
                        return false;
                    }
                }
            }
            else
            {
                foreach (TreeNode oldNode in this.tvList.Nodes)
                {
                    if (oldNode.Text.Trim() == this.txtName.Text.Trim() && oldNode.Name != this.tvList.SelectedNode.Name)
                    {
                        App.Msg("�������ֵ�뵱ǰĿ¼�µ�ֵ�ظ���");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ��Ԫ�� ���  �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckElement())
            {
                if (Action == "ADD")  //���
                { 
                    try
                    {
                        string id = App.GenId().ToString();//App.GenId("TABLE_E", "ID").ToString()
                        string sql = string.Format("INSERT INTO TABLE_E(NUM,EVALUE,NAME,SIMPLEMETAID_F,id)VALUES('{0}','{1}','{2}','{3}','{4}')"
                                        , this.txtNum.Text.Trim()
                                        , this.txtName.Text.Trim()
                                        , this.tvDirectory.SelectedNode.Text.ToString()
                                        , this.tvDirectory.SelectedNode.Tag.ToString(),id);
                        if (App.ExecuteSQL(sql) > 0)
                        {
                            App.Msg("��Ԫ����ӳɹ�");
                            TreeNode newNode = new TreeNode();
                            newNode.Text = this.txtName.Text.Trim();
                            newNode.ImageIndex = 4;
                            newNode.Name = id;
                            newNode.Tag = this.txtCode.Text;                            
                            newNode.SelectedImageIndex = 4;
                            this.tvList.Nodes.Add(newNode);
                            enable();                        
                        }
                    }
                    catch
                    {
                        App.Msg("���粻ͨ");
                    }
                }
                else   //�޸�
                {
                    try
                    {
                        string sql =
                    string.Format("UPDATE TABLE_E SET NUM = '{0}' , EVALUE = '{1}' , EVALUECODE = '{2}' WHERE ID = '{3}'"
                                 , this.txtNum.Text.Trim()
                                 , this.txtName.Text.Trim()
                                 , this.txtCode.Text.Trim()
                                 , this.tvList.SelectedNode.Name);
                        if (App.ExecuteSQL(sql) > 0)
                        {
                            App.Msg("��Ԫ���޸ĳɹ���");
                            this.tvList.SelectedNode.Text = this.txtName.Text.Trim();
                            //this.tvList.SelectedNode.Name =                                
                            enable();
                        }
                    }
                    catch
                    {
                        App.Msg("���粻ͨ��");
                    }
                }
                if (this.tvList.SelectedNode != null)
                {
                    this.tvList.Focus();
                }
                else
                {
                    this.tvDirectory.Focus();
                }
            }
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            enable();
            if (this.tvList.SelectedNode == null)
            {
                this.tvDirectory_AfterSelect(null, null);
                this.tvDirectory.Focus();
            }
            else
            {
                this.tvList_AfterSelect(null, null);
                this.tvList.Focus();
            }
        }

        /// <summary>
        /// �ؼ��Ƿ��������״̬ ������֮�� �� ȡ��
        /// </summary>
        public void enable()
        {
            this.tvDirectory.Enabled = true;
            this.tvList.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        /// <summary>
        /// �ؼ��Ƿ���� ״̬Ϊ����������ʱ��
        /// </summary>
        public void enable2()
        {
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;

            this.tvDirectory.Enabled = false;
            this.tvList.Enabled = false;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
        }

        /// <summary>
        /// �˵���ť  �����Ӹ���Ԫ�� �ı�״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                if (this.tvDirectory.SelectedNode.ImageIndex == 2)
                {
                    this.txtComplexName.Text = "";
                    this.complexAction = "ADD";
                    this.tcEdit.TabPages.Clear();
                    this.tcEdit.TabPages.Add(this.tpComplex);
                    this.fmText.MyDoc.ClearContent();
                    enable2();
                }
            }
        }
        //��ǰ��������Ԫ�ص�״̬
        private string complexAction = "ADD";
        /// <summary>
        /// ��ӻ��� �޸ĸ���Ԫ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspSave_Click(object sender, EventArgs e)
        {
            if (this.tvDirectory.SelectedNode != null)
            {
                if (this.tvDirectory.SelectedNode.ImageIndex == 2)
                {
                    if (this.txtComplexName.Text.Trim() == "")
                    {
                        App.Msg("����Ԫ�����Ʋ���Ϊ�գ�");
                        return;
                    }
                    if (complexAction == "ADD")  //���
                    {
                        try
                        {
                            foreach (TreeNode oldNode in this.tvList.Nodes)
                            {
                                if (oldNode.Text.Trim() == this.txtComplexName.Text.Trim())
                                {
                                    App.Msg("�������ֵ�뵱ǰĿ¼�µ�ֵ�ظ���");
                                    return;
                                }
                            }
                            DataTable dt = App.GetDataSet("select max(objectid) from ET_DOCUMENT").Tables[0];
                            string evalueCode = "";
                            if (dt.Rows.Count > 0)
                            {
                                evalueCode = (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1).ToString();
                            }
                            string id = App.GenId("TABLE_E", "ID").ToString();
                            string sql = string.Format("insert into TABLE_E(name,EVALUE,EVALUECODE,SIMPLEMETAID_F,ITEM_STYLE,NUM,ID)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                                                       , this.tvDirectory.SelectedNode.Text
                                                       , this.txtComplexName.Text.Trim()
                                                       , evalueCode
                                                       , this.tvDirectory.SelectedNode.Tag.ToString()
                                                       , "100"
                                                       , this.tvList.Nodes.Count,id);


                            XmlDocument tempxmldoc = new XmlDocument();
                            tempxmldoc.LoadXml("<emrtextdoc/>");
                            fmText.MyDoc.ToXML(tempxmldoc.DocumentElement);
                            string sql2 = string.Format("insert into ET_DOCUMENT(OBJECTID,OBJECTNAME,OBJECTTYPE,OBJECTDATA)values('{0}','{1}','{2}',:doc)"
                                                        , evalueCode
                                                        , this.txtComplexName.Text.Trim()
                                                        , "-1");
                            MySqlDBParameter[] op = new MySqlDBParameter[] { new MySqlDBParameter() };
                            op[0].ParameterName = "doc";
                            op[0].DBType = MySqlDbType.Text; 
                            op[0].Value = tempxmldoc.OuterXml;
                            if (App.ExecuteSQL(sql) > 0 && App.ExecuteSQL(sql2,op)>0)
                            {
                                App.Msg("����Ԫ�ر���ɹ���");
                                TreeNode newTn = new TreeNode();
                                newTn.ImageIndex = 5;
                                newTn.SelectedImageIndex = 5;
                                newTn.Text = this.txtComplexName.Text.Trim();
                                newTn.Tag = evalueCode;
                                newTn.Name = id;
                                enable();
                                this.tvList.Nodes.Add(newTn);
                                this.tvDirectory_AfterSelect(null, null);
                                this.tvDirectory.Focus();
                            }
                        }
                        catch
                        {
                            App.Msg( "���粻ͨ");
                        }
                    }
                    else          //�޸�
                    {
                        foreach (TreeNode oldNode in this.tvList.Nodes)
                        {
                            if (oldNode.Text.Trim() == this.txtComplexName.Text.Trim() && oldNode.Name != this.tvList.SelectedNode.Name)
                            {
                                App.ShowTip("֪ʶ��", "�������ֵ�뵱ǰĿ¼�µ�ֵ�ظ���");
                                return;
                            }
                        }
                        try
                        {
                            string sql = string.Format("UPDATE TABLE_E SET EVALUE = '{0}'  WHERE ID = '{1}'"
                                                      , this.txtComplexName.Text.Trim()
                                                      , this.tvList.SelectedNode.Name);
                            XmlDocument temxmldoc = new XmlDocument();
                            temxmldoc.LoadXml("<emrtextdoc/>");
                            fmText.MyDoc.ToXML(temxmldoc.DocumentElement);
                            string sql2 = string.Format("UPDATE ET_DOCUMENT SET OBJECTDATA=:doc,OBJECTNAME='{0}' where objectid='{1}'"
                                                        , this.txtComplexName.Text
                                                        , this.tvList.SelectedNode.Tag.ToString());
                            MySqlDBParameter[] op2 = new MySqlDBParameter[] { new MySqlDBParameter() };
                            op2[0].ParameterName = "doc";
                            op2[0].DBType = MySqlDbType.Text;
                            op2[0].Value = temxmldoc.OuterXml;
                            if (App.ExecuteSQL( sql) > 0 && App.ExecuteSQL(sql2,op2)>0)
                            {
                                App.Msg("����Ԫ�ر���ɹ���");
                                this.tvList.SelectedNode.Text = this.txtComplexName.Text.Trim();
                                enable();
                                this.tvList.Focus();
                            }
                        }
                        catch
                        {
                            App.Msg("����Ԫ�ر���ʧ�ܣ�");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��갴��  ��ȡ���ṹ ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvList_MouseDown(object sender, MouseEventArgs e)
        {
            this.tvList.SelectedNode = tvList.GetNodeAt(e.X, e.Y);
        }

        private void tspElementDelete_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvList.SelectedNode;
            if (tn != null)
            {
                if (MessageBox.Show("��ȷ��Ҫɾ����Ԫ����   \n\n��ʾ��ɾ��֮���޷��ָ�   ", "��ܰ��ʾ"
                  , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string sql = string.Format("DELETE TABLE_E WHERE ID = '{0}'", tn.Name.ToString());
                    String sql2 = "";
                    if (tn.ImageIndex == 5)
                    {
                        sql2 = string.Format("DELETE ET_DOCUMENT WHERE objectid ='{0}'", tn.Tag.ToString());
                    }
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        if (sql2 != "")
                            App.ExecuteSQL(sql2);
                        App.Msg("ɾ���ɹ�");
                        this.tvList.Nodes.Remove(tn);
                    }

                    if (this.tvList.SelectedNode == null)
                    {
                        this.tvDirectory_AfterSelect(null, null);
                        this.tvDirectory.Focus();
                    }
                    else
                    {
                        this.tvList.Focus();
                    }
                }
            }
        }

        private void tpBasicElement_Click(object sender, EventArgs e)
        {

        }

        private void tvDirectory_NodeMouseDoubleClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            tspBtnSelect_Click(null, null);
        }

        private void frKnowledge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                tsp_Click(null, null);
                this.txtSeachNode.Focus();
            }
        }

        private void frKnowledge_FormClosing(object sender, FormClosingEventArgs e)
        {            
            e.Cancel = true;
            this.Hide();
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}