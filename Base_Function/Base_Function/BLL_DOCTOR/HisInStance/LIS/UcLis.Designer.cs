namespace Base_Function.BLL_DOCTOR.HisInStance.LIS
{
    partial class UcLis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcLis));
            this.chb_qx = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.flgView_Yb = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.复制CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flgview_Patient = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flgView_Gm = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tChart3 = new Steema.TeeChart.TChart();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.tChart2 = new Steema.TeeChart.TChart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chb_qx
            // 
            this.chb_qx.AutoSize = true;
            this.chb_qx.Location = new System.Drawing.Point(417, 23);
            this.chb_qx.Name = "chb_qx";
            this.chb_qx.Size = new System.Drawing.Size(48, 16);
            this.chb_qx.TabIndex = 10;
            this.chb_qx.Text = "全选";
            this.chb_qx.UseVisualStyleBackColor = true;
            this.chb_qx.CheckedChanged += new System.EventHandler(this.chb_qx_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox1.Controls.Add(this.chb_qx);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.chbAll);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.txtPid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSure);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询设置";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(761, 20);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(95, 23);
            this.buttonX2.TabIndex = 12;
            this.buttonX2.Text = "取消分析(&N)";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(346, 23);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(60, 16);
            this.chbAll.TabIndex = 10;
            this.chbAll.Text = "异常项";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
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
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(661, 20);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(94, 23);
            this.buttonX1.TabIndex = 11;
            this.buttonX1.Text = "结果分析(&M)";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
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
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(569, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(475, 20);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(86, 23);
            this.btnSure.TabIndex = 8;
            this.btnSure.Text = "插入(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // flgView_Yb
            // 
            this.flgView_Yb.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView_Yb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView_Yb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flgView_Yb.Location = new System.Drawing.Point(3, 17);
            this.flgView_Yb.Name = "flgView_Yb";
            this.flgView_Yb.Rows.DefaultSize = 18;
            this.flgView_Yb.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.flgView_Yb.Size = new System.Drawing.Size(700, 440);
            this.flgView_Yb.StyleInfo = resources.GetString("flgView_Yb.StyleInfo");
            this.flgView_Yb.TabIndex = 1;
            this.flgView_Yb.Click += new System.EventHandler(this.flgView_Yb_Click);
            this.flgView_Yb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseClick);
            this.flgView_Yb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flgView_Yb_KeyDown);
            this.flgView_Yb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseDown);
            this.flgView_Yb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseDoubleClick);
            this.flgView_Yb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flgView_Yb_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 32);
            this.panel1.TabIndex = 10;
            // 
            // 复制CopyToolStripMenuItem
            // 
            this.复制CopyToolStripMenuItem.Name = "复制CopyToolStripMenuItem";
            this.复制CopyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.复制CopyToolStripMenuItem.Text = "复制Copy";
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
            this.splitContainer1.Size = new System.Drawing.Size(1213, 460);
            this.splitContainer1.SplitterDistance = 503;
            this.splitContainer1.TabIndex = 0;
            // 
            // flgview_Patient
            // 
            this.flgview_Patient.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview_Patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview_Patient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flgview_Patient.Location = new System.Drawing.Point(0, 0);
            this.flgview_Patient.Name = "flgview_Patient";
            this.flgview_Patient.Rows.DefaultSize = 18;
            this.flgview_Patient.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgview_Patient.Size = new System.Drawing.Size(503, 460);
            this.flgview_Patient.StyleInfo = resources.GetString("flgview_Patient.StyleInfo");
            this.flgview_Patient.TabIndex = 0;
            this.flgview_Patient.Click += new System.EventHandler(this.flgview_Patient_SelChange);
            this.flgview_Patient.SelChange += new System.EventHandler(this.flgview_Patient_SelChange);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flgView_Yb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(706, 460);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检验结果";
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
            this.splitContainer2.Size = new System.Drawing.Size(322, 60);
            this.splitContainer2.SplitterDistance = 31;
            this.splitContainer2.TabIndex = 5;
            this.splitContainer2.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flgView_Gm);
            this.groupBox4.Location = new System.Drawing.Point(0, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(398, 130);
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
            this.flgView_Gm.Size = new System.Drawing.Size(392, 110);
            this.flgView_Gm.StyleInfo = resources.GetString("flgView_Gm.StyleInfo");
            this.flgView_Gm.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制CopyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Controls.Add(this.groupPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1219, 480);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.tChart3);
            this.groupPanel3.Location = new System.Drawing.Point(3, 17);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1213, 460);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "趋势分析图";
            this.groupPanel3.Visible = false;
            // 
            // tChart3
            // 
            // 
            // 
            // 
            this.tChart3.Aspect.View3D = false;
            this.tChart3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart3.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart3.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart3.Legend.Title.Pen.Visible = false;
            this.tChart3.Location = new System.Drawing.Point(0, 0);
            this.tChart3.Name = "tChart3";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart3.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart3.Size = new System.Drawing.Size(1207, 436);
            this.tChart3.TabIndex = 0;
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.View3D = false;
            this.tChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(0, 0);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart1.Size = new System.Drawing.Size(953, 331);
            this.tChart1.TabIndex = 0;
            // 
            // tChart2
            // 
            // 
            // 
            // 
            this.tChart2.Aspect.View3D = false;
            this.tChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Legend.Title.Pen.Visible = false;
            this.tChart2.Location = new System.Drawing.Point(0, 0);
            this.tChart2.Name = "tChart2";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart2.Size = new System.Drawing.Size(953, 331);
            this.tChart2.TabIndex = 0;
            // 
            // UcLis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "UcLis";
            this.Size = new System.Drawing.Size(1219, 561);
            this.Load += new System.EventHandler(this.FrmLis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chb_qx;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbAll;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Yb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 复制CopyToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview_Patient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Gm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        public DevComponents.DotNetBar.ButtonX btnSure;
        public DevComponents.DotNetBar.ButtonX buttonX1;
        public DevComponents.DotNetBar.ButtonX buttonX2;
        private Steema.TeeChart.TChart tChart1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private Steema.TeeChart.TChart tChart3;
        private Steema.TeeChart.TChart tChart2;

    }
}
