namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class Col_FilesBrowse
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.verSplitCont = new System.Windows.Forms.SplitContainer();
            this.files_Tree = new DevComponents.AdvTree.AdvTree();
            this.freeTree_RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUp_FileTreeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDown_FileTreeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.pic_FlowPal = new System.Windows.Forms.FlowLayoutPanel();
            this.verSplitCont.Panel1.SuspendLayout();
            this.verSplitCont.Panel2.SuspendLayout();
            this.verSplitCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.files_Tree)).BeginInit();
            this.freeTree_RightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // verSplitCont
            // 
            this.verSplitCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verSplitCont.Location = new System.Drawing.Point(0, 0);
            this.verSplitCont.Name = "verSplitCont";
            // 
            // verSplitCont.Panel1
            // 
            this.verSplitCont.Panel1.Controls.Add(this.files_Tree);
            // 
            // verSplitCont.Panel2
            // 
            this.verSplitCont.Panel2.Controls.Add(this.pic_FlowPal);
            this.verSplitCont.Size = new System.Drawing.Size(771, 484);
            this.verSplitCont.SplitterDistance = 223;
            this.verSplitCont.SplitterWidth = 1;
            this.verSplitCont.TabIndex = 0;
            // 
            // files_Tree
            // 
            this.files_Tree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.files_Tree.AllowDrop = true;
            this.files_Tree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.files_Tree.BackgroundStyle.Class = "TreeBorderKey";
            this.files_Tree.ColorSchemeStyle = DevComponents.AdvTree.eColorSchemeStyle.VS2005;
            this.files_Tree.ContextMenuStrip = this.freeTree_RightMenu;
            this.files_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files_Tree.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.files_Tree.Location = new System.Drawing.Point(0, 0);
            this.files_Tree.Name = "files_Tree";
            this.files_Tree.NodesConnector = this.nodeConnector1;
            this.files_Tree.NodeStyle = this.elementStyle1;
            this.files_Tree.PathSeparator = ";";
            this.files_Tree.Size = new System.Drawing.Size(223, 484);
            this.files_Tree.Styles.Add(this.elementStyle1);
            this.files_Tree.TabIndex = 0;
            this.files_Tree.Text = "advTree1";
            this.files_Tree.Click += new System.EventHandler(this.files_Tree_Click);
            this.files_Tree.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.files_Tree_AfterCheck);
            // 
            // freeTree_RightMenu
            // 
            this.freeTree_RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUp_FileTreeItem,
            this.moveDown_FileTreeItem});
            this.freeTree_RightMenu.Name = "freeTree_RightMenu";
            this.freeTree_RightMenu.Size = new System.Drawing.Size(95, 48);
            this.freeTree_RightMenu.Opening += new System.ComponentModel.CancelEventHandler(this.freeTree_RightMenu_Opening);
            // 
            // moveUp_FileTreeItem
            // 
            this.moveUp_FileTreeItem.Name = "moveUp_FileTreeItem";
            this.moveUp_FileTreeItem.Size = new System.Drawing.Size(94, 22);
            this.moveUp_FileTreeItem.Text = "上移";
            this.moveUp_FileTreeItem.Click += new System.EventHandler(this.moveUp_FileTreeItem_Click);
            // 
            // moveDown_FileTreeItem
            // 
            this.moveDown_FileTreeItem.Name = "moveDown_FileTreeItem";
            this.moveDown_FileTreeItem.Size = new System.Drawing.Size(94, 22);
            this.moveDown_FileTreeItem.Text = "下移";
            this.moveDown_FileTreeItem.Click += new System.EventHandler(this.moveDown_FileTreeItem_Click);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // pic_FlowPal
            // 
            this.pic_FlowPal.AutoScroll = true;
            this.pic_FlowPal.BackColor = System.Drawing.SystemColors.Control;
            this.pic_FlowPal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_FlowPal.Location = new System.Drawing.Point(0, 0);
            this.pic_FlowPal.Name = "pic_FlowPal";
            this.pic_FlowPal.Size = new System.Drawing.Size(547, 484);
            this.pic_FlowPal.TabIndex = 0;
            this.pic_FlowPal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pic_FlowPal_Scroll);
            this.pic_FlowPal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_FlowPal_MouseDown);
            // 
            // Col_FilesBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.verSplitCont);
            this.Name = "Col_FilesBrowse";
            this.Size = new System.Drawing.Size(771, 484);
            this.SizeChanged += new System.EventHandler(this.Col_FilesBrowse_SizeChanged);
            this.verSplitCont.Panel1.ResumeLayout(false);
            this.verSplitCont.Panel2.ResumeLayout(false);
            this.verSplitCont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.files_Tree)).EndInit();
            this.freeTree_RightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer verSplitCont;
        private System.Windows.Forms.FlowLayoutPanel pic_FlowPal;
        private System.Windows.Forms.ContextMenuStrip freeTree_RightMenu;
        private System.Windows.Forms.ToolStripMenuItem moveUp_FileTreeItem;
        private System.Windows.Forms.ToolStripMenuItem moveDown_FileTreeItem;
        private DevComponents.AdvTree.AdvTree files_Tree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;


    }
}
