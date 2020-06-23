using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevComponents.AdvTree;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class Col_FilesBrowse : UserControl
    {

        private ArrayList patients = new ArrayList();
        private Object tagTest = new object();

        #region 设置树形结构中需要显示的Info_MedicalRecords集合
        /// <summary>
        /// 设置树形结构中需要显示的Info_MedicalRecords集合
        /// </summary>
        public ArrayList Patients
        {
            //get { return patients; }
            set { patients = value; }
        }
        #endregion

        #region 得到当前选中的所有节点的集合
        /// <summary>
        /// 得到当前选中的所有节点的集合
        /// </summary>
        /// <returns></returns>
        public NodeCollection GetSelectedNodes()
        {
            return this.files_Tree.SelectedNodes;
        }
        #endregion

        public Col_FilesBrowse()
        {
            InitializeComponent();
        }

        #region 树形结构 结点 点击 事件

        private void files_Tree_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            
            
        }

        #endregion

        #region 

        /// <summary>
        /// 生成文件树形结构 +1重载
        /// </summary>
        public void LoadTree()
        {
            Tools_FileOperation.ShowFilesView(patients,this.files_Tree.Nodes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        public void LoadTree(ArrayList files)
        {
            this.patients = files;
            this.LoadTree();
        }
        #endregion

        #region 浏览，滚动条

        private void pic_FlowPal_MouseDown(object sender, MouseEventArgs e)
        {
            this.pic_FlowPal.Focus();
        }

        private void pic_FlowPal_Scroll(object sender, ScrollEventArgs e)
        {
            this.pic_FlowPal.Refresh();
        }

        private void pic_FlowPal_MouseEnter(object sender, EventArgs e)
        {
            this.pic_FlowPal.Focus();
        }

        #endregion

        #region 树形 右键菜单 控制
        private void freeTree_RightMenu_Opening(object sender, CancelEventArgs e)
        {
            if (this.files_Tree.SelectedNode != null && this.files_Tree.SelectedNode.Nodes.Count < 1 && this.files_Tree.SelectedNode.Parent != null)
            {
                this.moveUp_FileTreeItem.Enabled = true;
                this.moveDown_FileTreeItem.Enabled = true;
            }
            else
            {
                this.moveUp_FileTreeItem.Enabled = false;
                this.moveDown_FileTreeItem.Enabled = false;
            }
        }

        private void moveUp_FileTreeItem_Click(object sender, EventArgs e)
        {
            if (this.files_Tree.SelectedNode.PrevNode == null)
            {
                return;
            }
            Node temp = this.files_Tree.SelectedNode;
            Node tempParent = this.files_Tree.SelectedNode.Parent;
            int index = this.files_Tree.SelectedNode.Index;
            //MessageBox.Show("" + index);
            //return;
            this.files_Tree.SelectedNode.Remove();
            tempParent.Nodes.Insert(index - 1, temp);
            tempParent.LastNode.Checked = true;
        }

        private void moveDown_FileTreeItem_Click(object sender, EventArgs e)
        {
            if (this.files_Tree.SelectedNode.NextNode == null)
            {
                return;
            }
            Node temp = this.files_Tree.SelectedNode;
            int index = this.files_Tree.SelectedNode.Index;
            Node tempParent = this.files_Tree.SelectedNode.Parent;
            //MessageBox.Show("" + index);
            //return;
            this.files_Tree.SelectedNode.Remove();
            tempParent.Nodes.Insert(index + 1, temp);
        }
        #endregion

        private void Col_FilesBrowse_SizeChanged(object sender, EventArgs e)
        {
            this.verSplitCont.SplitterDistance = this.Width / 4;
            //MessageBox.Show((verSplitCont.Width - files_Tree.Width).ToString());
        }

        #region files_Tree单击事件

        private void files_Tree_Click(object sender, EventArgs e)
        {
            //节点选择判断
            if (files_Tree.SelectedNode == null)
            {
                return;
            }

            if (tagTest.Equals(this.files_Tree.SelectedNode.Tag))
            {
                return;
            }
            else
            { 
                tagTest = this.files_Tree.SelectedNode.Tag;
            }

            //显示图像
            this.pic_FlowPal.Controls.Clear();

            ArrayList filesPath = new ArrayList();

            Tools_Others.GetNodesFiles(filesPath, this.files_Tree.SelectedNode);

            int i = 0;
            int width = this.pic_FlowPal.Width - 25;
            int height = width / 2 * 3;


            foreach (Info_MedicalRecords imr in filesPath)
            {
                Image image;
                try
                {
                    image = Image.FromFile(GlobalSettings.BrowsePath + @"\" + imr.FileName);
                }
                catch (Exception ex)
                {
                    image = null;
                }
                Col_FilePicShow pic = new Col_FilePicShow();
                pic.Image = image;
                //pic.ReFreshing();

                //pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                //        | System.Windows.Forms.AnchorStyles.Left)
                //        | System.Windows.Forms.AnchorStyles.Right)));

                this.pic_FlowPal.Controls.Add(pic);
                pic.Location = new Point(15, (height + 10) * i + 10);

                pic.Size = new Size(width, height);

                i++;
            }
        }
        #endregion
    }
}
