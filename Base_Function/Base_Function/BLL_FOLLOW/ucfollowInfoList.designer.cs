namespace Base_Function.BLL_FOLLOW
{
    partial class ucfollowInfoList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cmbValid = new System.Windows.Forms.ComboBox();
            this.cmbMaintainSection = new System.Windows.Forms.ComboBox();
            this.txtOperation = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.txtFollowMethod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvFollowMethod = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无效ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowMethod)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmbSection);
            this.groupPanel1.Controls.Add(this.btnAdd);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.cmbValid);
            this.groupPanel1.Controls.Add(this.cmbMaintainSection);
            this.groupPanel1.Controls.Add(this.txtOperation);
            this.groupPanel1.Controls.Add(this.txtUser);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtDiag);
            this.groupPanel1.Controls.Add(this.txtFollowMethod);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1167, 126);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "查询设置";
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(324, 58);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(126, 20);
            this.cmbSection.TabIndex = 18;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(1010, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "新建";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(1010, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbValid
            // 
            this.cmbValid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValid.FormattingEnabled = true;
            this.cmbValid.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cmbValid.Location = new System.Drawing.Point(603, 58);
            this.cmbValid.Name = "cmbValid";
            this.cmbValid.Size = new System.Drawing.Size(126, 20);
            this.cmbValid.TabIndex = 12;
            // 
            // cmbMaintainSection
            // 
            this.cmbMaintainSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaintainSection.FormattingEnabled = true;
            this.cmbMaintainSection.Items.AddRange(new object[] {
            "本科维护",
            "临床科室维护"});
            this.cmbMaintainSection.Location = new System.Drawing.Point(110, 58);
            this.cmbMaintainSection.Name = "cmbMaintainSection";
            this.cmbMaintainSection.Size = new System.Drawing.Size(126, 20);
            this.cmbMaintainSection.TabIndex = 11;
            // 
            // txtOperation
            // 
            this.txtOperation.Location = new System.Drawing.Point(603, 18);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.Size = new System.Drawing.Size(126, 21);
            this.txtOperation.TabIndex = 10;
            this.txtOperation.TextChanged += new System.EventHandler(this.txtOperation_TextChanged);
            this.txtOperation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOperation_KeyUp);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(838, 18);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(126, 21);
            this.txtUser.TabIndex = 9;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(516, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "是否有效：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(548, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "手术：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(268, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "科室：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(33, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "维护科室：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(767, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "随访用户：";
            // 
            // txtDiag
            // 
            this.txtDiag.Location = new System.Drawing.Point(324, 18);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(188, 21);
            this.txtDiag.TabIndex = 3;
            this.txtDiag.TextChanged += new System.EventHandler(this.txtDiag_TextChanged);
            this.txtDiag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiag_KeyUp);
            // 
            // txtFollowMethod
            // 
            this.txtFollowMethod.Location = new System.Drawing.Point(110, 18);
            this.txtFollowMethod.Name = "txtFollowMethod";
            this.txtFollowMethod.Size = new System.Drawing.Size(126, 21);
            this.txtFollowMethod.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(277, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "诊断：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "随访方案名称：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvFollowMethod);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 126);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1167, 647);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "随访方案";
            // 
            // dgvFollowMethod
            // 
            this.dgvFollowMethod.AllowUserToAddRows = false;
            this.dgvFollowMethod.BackgroundColor = System.Drawing.Color.White;
            this.dgvFollowMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFollowMethod.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFollowMethod.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFollowMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFollowMethod.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvFollowMethod.Location = new System.Drawing.Point(0, 0);
            this.dgvFollowMethod.Name = "dgvFollowMethod";
            this.dgvFollowMethod.RowTemplate.Height = 23;
            this.dgvFollowMethod.Size = new System.Drawing.Size(1161, 623);
            this.dgvFollowMethod.TabIndex = 0;
            this.dgvFollowMethod.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFollowMethod_ColumnHeaderMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.无效ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 无效ToolStripMenuItem
            // 
            this.无效ToolStripMenuItem.Name = "无效ToolStripMenuItem";
            this.无效ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.无效ToolStripMenuItem.Text = "无效";
            this.无效ToolStripMenuItem.Click += new System.EventHandler(this.无效ToolStripMenuItem_Click);
            // 
            // ucfollowInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucfollowInfoList";
            this.Size = new System.Drawing.Size(1167, 773);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowMethod)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFollowMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.TextBox txtFollowMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.ComboBox cmbValid;
        private System.Windows.Forms.ComboBox cmbMaintainSection;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtOperation;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ToolStripMenuItem 无效ToolStripMenuItem;
    }
}
