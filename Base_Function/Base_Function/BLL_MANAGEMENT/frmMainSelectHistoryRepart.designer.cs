namespace Base_Function.BLL_MANAGEMENT
{
    partial class frmMainSelectHistoryRepart
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.contextMenuStripDeleteUpdate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStripDeleteUpdate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucC1FlexGrid1.AutoScroll = true;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(979, 626);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            this.ucC1FlexGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucC1FlexGrid1_MouseClick);
            // 
            // contextMenuStripDeleteUpdate
            // 
            this.contextMenuStripDeleteUpdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.contextMenuStripDeleteUpdate.Name = "contextMenuStripDeleteUpdate";
            this.contextMenuStripDeleteUpdate.Size = new System.Drawing.Size(101, 48);
            this.contextMenuStripDeleteUpdate.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDeleteUpdate_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 632);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 52);
            this.panel1.TabIndex = 2;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(409, 15);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "打印报表";
            this.buttonX1.Visible = false;
            // 
            // frmMainSelectHistoryRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 684);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucC1FlexGrid1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainSelectHistoryRepart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看主观历史报表";
            this.Load += new System.EventHandler(this.frmMainSelectHistoryRepart_Load);
            this.contextMenuStripDeleteUpdate.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeleteUpdate;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}