namespace Base_Function.Infection
{
    partial class UcInfection
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fg1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtDiagCode = new System.Windows.Forms.TextBox();
            this.txtDiagName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fg2 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fg1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(732, 417);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // fg1
            // 
            this.fg1.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.fg1.ContextMenuStrip = this.contextMenuStrip1;
            this.fg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg1.Location = new System.Drawing.Point(0, 0);
            this.fg1.Name = "fg1";
            this.fg1.Rows.DefaultSize = 18;
            this.fg1.Size = new System.Drawing.Size(235, 417);
            this.fg1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.修改ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 70);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 417);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "传染病介绍";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtDiagCode);
            this.panel1.Controls.Add(this.txtDiagName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fg2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 144);
            this.panel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(293, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";          
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(233, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";          
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDiagCode
            // 
            this.txtDiagCode.Location = new System.Drawing.Point(284, 39);
            this.txtDiagCode.Name = "txtDiagCode";
            this.txtDiagCode.Size = new System.Drawing.Size(144, 21);
            this.txtDiagCode.TabIndex = 3;
            this.txtDiagCode.TextChanged += new System.EventHandler(this.txtDiagCode_TextChanged);
            this.txtDiagCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiagCode_KeyUp);
            // 
            // txtDiagName
            // 
            this.txtDiagName.Location = new System.Drawing.Point(284, 10);
            this.txtDiagName.Name = "txtDiagName";
            this.txtDiagName.Size = new System.Drawing.Size(144, 21);
            this.txtDiagName.TabIndex = 3;
            this.txtDiagName.TextChanged += new System.EventHandler(this.txtDiagName_TextChanged);
            this.txtDiagName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiagName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "诊断编码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "诊断名称：";
            // 
            // fg2
            // 
            this.fg2.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.fg2.Dock = System.Windows.Forms.DockStyle.Left;
            this.fg2.Location = new System.Drawing.Point(0, 0);
            this.fg2.Name = "fg2";
            this.fg2.Rows.DefaultSize = 18;
            this.fg2.Size = new System.Drawing.Size(216, 144);
            this.fg2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(487, 397);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // UcInfection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UcInfection";
            this.Size = new System.Drawing.Size(732, 417);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fg1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1FlexGrid.C1FlexGrid fg1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid fg2;
        private System.Windows.Forms.TextBox txtDiagName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.TextBox txtDiagCode;
        private System.Windows.Forms.Label label2;
    }
}
