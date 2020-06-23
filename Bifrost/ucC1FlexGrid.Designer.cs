namespace Bifrost
{
    partial class ucC1FlexGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucC1FlexGrid));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBottom = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.btnTop = new DevComponents.DotNetBar.ButtonX();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrentPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnBottom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.cboSize);
            this.panel1.Controls.Add(this.btnTop);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboCurrentPage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(89, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 34);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // btnBottom
            // 
            this.btnBottom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBottom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBottom.Location = new System.Drawing.Point(386, 3);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(42, 25);
            this.btnBottom.TabIndex = 7;
            this.btnBottom.Text = ">>";
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "条记录";
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Location = new System.Drawing.Point(338, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(42, 25);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = ">";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "100",
            "150",
            "200",
            "250",
            "300"});
            this.cboSize.Location = new System.Drawing.Point(235, 8);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(50, 20);
            this.cboSize.TabIndex = 6;
            this.cboSize.SelectedIndexChanged += new System.EventHandler(this.cboSize_SelectedIndexChanged);
            // 
            // btnTop
            // 
            this.btnTop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTop.Location = new System.Drawing.Point(0, 3);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(42, 25);
            this.btnTop.TabIndex = 4;
            this.btnTop.Text = "<<";
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Location = new System.Drawing.Point(48, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(42, 25);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "<";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "每页:";
            // 
            // cboCurrentPage
            // 
            this.cboCurrentPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentPage.FormattingEnabled = true;
            this.cboCurrentPage.Location = new System.Drawing.Point(140, 8);
            this.cboCurrentPage.Name = "cboCurrentPage";
            this.cboCurrentPage.Size = new System.Drawing.Size(50, 20);
            this.cboCurrentPage.TabIndex = 3;
            this.cboCurrentPage.SelectedIndexChanged += new System.EventHandler(this.cboCurrentPage_SelectedIndexChanged);
            this.cboCurrentPage.TextChanged += new System.EventHandler(this.cboCurrentPage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(94, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前页:";
            // 
            // fg
            // 
            this.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.fg.ColumnInfo = "1,1,0,0,0,0,Columns:0{Width:20;Name:\"No\";AllowMerging:True;Style:\"EditMask:\"\"1\"\";" +
    "DataType:System.Decimal;TextAlign:RightCenter;\";}\t";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(0, 0);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.DefaultSize = 18;
            this.fg.Size = new System.Drawing.Size(611, 410);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 2;
            this.fg.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fg.Tree.NodeImageCollapsed = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageCollapsed")));
            this.fg.Tree.NodeImageExpanded = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageExpanded")));
            this.fg.Click += new System.EventHandler(this.fg_Click);
            this.fg.Paint += new System.Windows.Forms.PaintEventHandler(this.fg_Paint);
            this.fg.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fg_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 38);
            this.panel2.TabIndex = 3;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // ucC1FlexGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fg);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Name = "ucC1FlexGrid";
            this.Size = new System.Drawing.Size(611, 448);
            this.Load += new System.EventHandler(this.ucC1FlexGrid_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// C1表格表格
        /// </summary>
        public C1.Win.C1FlexGrid.C1FlexGrid fg;
        private DevComponents.DotNetBar.ButtonX btnBottom;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private DevComponents.DotNetBar.ButtonX btnUp;
        private DevComponents.DotNetBar.ButtonX btnTop;
        public System.Windows.Forms.ComboBox cboCurrentPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
