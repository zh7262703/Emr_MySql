namespace Bifrost.HisInstance
{
    partial class FrmLis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLis));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flgview_Patient = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flgView_Yb = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flgView_Gm = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtPid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询设置";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(259, 20);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "查询(&Q)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(98, 23);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(142, 21);
            this.txtPid.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "病人编号：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flgview_Patient);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(792, 418);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 0;
            // 
            // flgview_Patient
            // 
            this.flgview_Patient.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview_Patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview_Patient.Location = new System.Drawing.Point(0, 0);
            this.flgview_Patient.Name = "flgview_Patient";
            this.flgview_Patient.Rows.DefaultSize = 18;
            this.flgview_Patient.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgview_Patient.Size = new System.Drawing.Size(293, 418);
            this.flgview_Patient.StyleInfo = resources.GetString("flgview_Patient.StyleInfo");
            this.flgview_Patient.TabIndex = 0;
            this.flgview_Patient.Click += new System.EventHandler(this.flgview_Patient_Click);
            this.flgview_Patient.SelChange += new System.EventHandler(this.flgview_Patient_SelChange);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(73, 277);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(322, 66);
            this.splitContainer2.SplitterDistance = 37;
            this.splitContainer2.TabIndex = 5;
            this.splitContainer2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flgView_Yb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 418);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检验结果";
            // 
            // flgView_Yb
            // 
            this.flgView_Yb.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView_Yb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView_Yb.Location = new System.Drawing.Point(3, 17);
            this.flgView_Yb.Name = "flgView_Yb";
            this.flgView_Yb.Rows.DefaultSize = 18;
            this.flgView_Yb.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.flgView_Yb.Size = new System.Drawing.Size(489, 398);
            this.flgView_Yb.StyleInfo = resources.GetString("flgView_Yb.StyleInfo");
            this.flgView_Yb.TabIndex = 1;
            this.flgView_Yb.Click += new System.EventHandler(this.flgView_Yb_Click);
            this.flgView_Yb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseClick);
            this.flgView_Yb.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.flgView_Yb_AfterEdit);
            this.flgView_Yb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flgView_Yb_KeyDown);
            this.flgView_Yb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseDown);
            this.flgView_Yb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flgView_Yb_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flgView_Gm);
            this.groupBox4.Location = new System.Drawing.Point(0, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(398, 136);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "细菌结果";
            this.groupBox4.Visible = false;
            // 
            // flgView_Gm
            // 
            this.flgView_Gm.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView_Gm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView_Gm.Location = new System.Drawing.Point(3, 17);
            this.flgView_Gm.Name = "flgView_Gm";
            this.flgView_Gm.Rows.DefaultSize = 18;
            this.flgView_Gm.Size = new System.Drawing.Size(392, 116);
            this.flgView_Gm.StyleInfo = resources.GetString("flgView_Gm.StyleInfo");
            this.flgView_Gm.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制CopyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // 复制CopyToolStripMenuItem
            // 
            this.复制CopyToolStripMenuItem.Name = "复制CopyToolStripMenuItem";
            this.复制CopyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.复制CopyToolStripMenuItem.Text = "复制Copy";
            this.复制CopyToolStripMenuItem.Click += new System.EventHandler(this.复制CopyToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(798, 438);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 32);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(397, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(316, 5);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 8;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // FrmLis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 529);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验报告";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview_Patient;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Yb;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Gm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制CopyToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
    }
}