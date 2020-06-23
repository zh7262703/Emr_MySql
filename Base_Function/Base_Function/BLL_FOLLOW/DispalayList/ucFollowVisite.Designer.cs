namespace Base_Function.BLL_FOLLOW.DispalayList
{
    partial class ucFollowVisite
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
            this.grpBoxFilter = new System.Windows.Forms.GroupBox();
            this.cmbFollowInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnAddPatients = new DevComponents.DotNetBar.ButtonX();
            this.btnToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnComplicateSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLast = new DevComponents.DotNetBar.ButtonX();
            this.btnRear = new DevComponents.DotNetBar.ButtonX();
            this.btnFirst = new DevComponents.DotNetBar.ButtonX();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.cmbEachPage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCurrentPage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.诊断信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出随访ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBoxFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxFilter
            // 
            this.grpBoxFilter.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxFilter.Controls.Add(this.cmbFollowInfo);
            this.grpBoxFilter.Controls.Add(this.btnAddPatients);
            this.grpBoxFilter.Controls.Add(this.btnToExcel);
            this.grpBoxFilter.Controls.Add(this.btnComplicateSearch);
            this.grpBoxFilter.Controls.Add(this.btnSearch);
            this.grpBoxFilter.Controls.Add(this.label1);
            this.grpBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.grpBoxFilter.Name = "grpBoxFilter";
            this.grpBoxFilter.Size = new System.Drawing.Size(1106, 68);
            this.grpBoxFilter.TabIndex = 0;
            this.grpBoxFilter.TabStop = false;
            this.grpBoxFilter.Text = "查询";
            // 
            // cmbFollowInfo
            // 
            this.cmbFollowInfo.DisplayMember = "Text";
            this.cmbFollowInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFollowInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowInfo.FormattingEnabled = true;
            this.cmbFollowInfo.ItemHeight = 15;
            this.cmbFollowInfo.Location = new System.Drawing.Point(93, 26);
            this.cmbFollowInfo.Name = "cmbFollowInfo";
            this.cmbFollowInfo.Size = new System.Drawing.Size(155, 21);
            this.cmbFollowInfo.TabIndex = 6;
            // 
            // btnAddPatients
            // 
            this.btnAddPatients.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddPatients.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddPatients.Location = new System.Drawing.Point(582, 24);
            this.btnAddPatients.Name = "btnAddPatients";
            this.btnAddPatients.Size = new System.Drawing.Size(75, 23);
            this.btnAddPatients.TabIndex = 5;
            this.btnAddPatients.Text = "增加病人";
            this.btnAddPatients.Click += new System.EventHandler(this.btnAddPatients_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToExcel.Location = new System.Drawing.Point(485, 24);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 4;
            this.btnToExcel.Text = "导出Excel";
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnComplicateSearch
            // 
            this.btnComplicateSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComplicateSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComplicateSearch.Location = new System.Drawing.Point(388, 24);
            this.btnComplicateSearch.Name = "btnComplicateSearch";
            this.btnComplicateSearch.Size = new System.Drawing.Size(75, 23);
            this.btnComplicateSearch.TabIndex = 3;
            this.btnComplicateSearch.Text = "多条件查询";
            this.btnComplicateSearch.Click += new System.EventHandler(this.btnComplicateSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(291, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "方案：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvPatients);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1106, 621);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.Location = new System.Drawing.Point(3, 17);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowTemplate.Height = 23;
            this.dgvPatients.Size = new System.Drawing.Size(1100, 543);
            this.dgvPatients.TabIndex = 7;
            this.dgvPatients.DoubleClick += new System.EventHandler(this.dgvPatients_DoubleClick);
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnRear);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.cmbEachPage);
            this.panel1.Controls.Add(this.cmbCurrentPage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 58);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "条纪录";
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLast.Location = new System.Drawing.Point(778, 21);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(44, 20);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = ">>";
            // 
            // btnRear
            // 
            this.btnRear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRear.Location = new System.Drawing.Point(710, 21);
            this.btnRear.Name = "btnRear";
            this.btnRear.Size = new System.Drawing.Size(44, 20);
            this.btnRear.TabIndex = 6;
            this.btnRear.Text = ">";
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirst.Location = new System.Drawing.Point(279, 21);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(44, 20);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "<<";
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre.Location = new System.Drawing.Point(355, 21);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(44, 20);
            this.btnPre.TabIndex = 4;
            this.btnPre.Text = "<";
            // 
            // cmbEachPage
            // 
            this.cmbEachPage.DisplayMember = "Text";
            this.cmbEachPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEachPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEachPage.FormattingEnabled = true;
            this.cmbEachPage.ItemHeight = 15;
            this.cmbEachPage.Location = new System.Drawing.Point(584, 21);
            this.cmbEachPage.Name = "cmbEachPage";
            this.cmbEachPage.Size = new System.Drawing.Size(73, 21);
            this.cmbEachPage.TabIndex = 3;
            // 
            // cmbCurrentPage
            // 
            this.cmbCurrentPage.DisplayMember = "Text";
            this.cmbCurrentPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCurrentPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrentPage.FormattingEnabled = true;
            this.cmbCurrentPage.ItemHeight = 15;
            this.cmbCurrentPage.Location = new System.Drawing.Point(464, 21);
            this.cmbCurrentPage.Name = "cmbCurrentPage";
            this.cmbCurrentPage.Size = new System.Drawing.Size(66, 21);
            this.cmbCurrentPage.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "每页：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前页：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.诊断信息ToolStripMenuItem,
            this.退出随访ToolStripMenuItem,
            this.患者基本信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // 诊断信息ToolStripMenuItem
            // 
            this.诊断信息ToolStripMenuItem.Name = "诊断信息ToolStripMenuItem";
            this.诊断信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.诊断信息ToolStripMenuItem.Text = "诊断信息";
            this.诊断信息ToolStripMenuItem.Click += new System.EventHandler(this.诊断信息ToolStripMenuItem_Click);
            // 
            // 退出随访ToolStripMenuItem
            // 
            this.退出随访ToolStripMenuItem.Name = "退出随访ToolStripMenuItem";
            this.退出随访ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出随访ToolStripMenuItem.Text = "退出随访";
            this.退出随访ToolStripMenuItem.Click += new System.EventHandler(this.退出随访ToolStripMenuItem_Click);
            // 
            // 患者基本信息ToolStripMenuItem
            // 
            this.患者基本信息ToolStripMenuItem.Name = "患者基本信息ToolStripMenuItem";
            this.患者基本信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.患者基本信息ToolStripMenuItem.Text = "患者基本信息";
            this.患者基本信息ToolStripMenuItem.Click += new System.EventHandler(this.患者基本信息ToolStripMenuItem_Click);
            // 
            // ucFollowVisite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxFilter);
            this.Name = "ucFollowVisite";
            this.Size = new System.Drawing.Size(1106, 689);
            this.grpBoxFilter.ResumeLayout(false);
            this.grpBoxFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnAddPatients;
        private DevComponents.DotNetBar.ButtonX btnToExcel;
        private DevComponents.DotNetBar.ButtonX btnComplicateSearch;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnLast;
        private DevComponents.DotNetBar.ButtonX btnRear;
        private DevComponents.DotNetBar.ButtonX btnFirst;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEachPage;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCurrentPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFollowInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 诊断信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出随访ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者基本信息ToolStripMenuItem;
    }
}
