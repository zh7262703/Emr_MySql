namespace Base_Function.BLL_NURSE.First_cases
{
    partial class ucCOVER_APPEND_MAIN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGvAppendPages = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel8 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label136 = new System.Windows.Forms.Label();
            this.btnAddAppendPage = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGvAppendPages)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupPanel5);
            this.splitContainer2.Panel1.Controls.Add(this.groupPanel8);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupPanel7);
            this.splitContainer2.Size = new System.Drawing.Size(768, 550);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.button2);
            this.groupPanel5.Controls.Add(this.button1);
            this.groupPanel5.Controls.Add(this.dataGvAppendPages);
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel5.Location = new System.Drawing.Point(0, 85);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(250, 465);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel5.TabIndex = 0;
            this.groupPanel5.Text = "附页列表";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "↓";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "↑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGvAppendPages
            // 
            this.dataGvAppendPages.AllowUserToAddRows = false;
            this.dataGvAppendPages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGvAppendPages.BackgroundColor = System.Drawing.Color.White;
            this.dataGvAppendPages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGvAppendPages.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGvAppendPages.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGvAppendPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGvAppendPages.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGvAppendPages.Location = new System.Drawing.Point(0, 0);
            this.dataGvAppendPages.Name = "dataGvAppendPages";
            this.dataGvAppendPages.ReadOnly = true;
            this.dataGvAppendPages.RowTemplate.Height = 23;
            this.dataGvAppendPages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGvAppendPages.Size = new System.Drawing.Size(244, 441);
            this.dataGvAppendPages.TabIndex = 0;
            this.dataGvAppendPages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGvAppendPages_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // groupPanel8
            // 
            this.groupPanel8.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel8.Controls.Add(this.cboType);
            this.groupPanel8.Controls.Add(this.label136);
            this.groupPanel8.Controls.Add(this.btnAddAppendPage);
            this.groupPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel8.Location = new System.Drawing.Point(0, 0);
            this.groupPanel8.Name = "groupPanel8";
            this.groupPanel8.Size = new System.Drawing.Size(250, 85);
            // 
            // 
            // 
            this.groupPanel8.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel8.Style.BackColorGradientAngle = 90;
            this.groupPanel8.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel8.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderBottomWidth = 1;
            this.groupPanel8.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel8.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderLeftWidth = 1;
            this.groupPanel8.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderRightWidth = 1;
            this.groupPanel8.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel8.Style.BorderTopWidth = 1;
            this.groupPanel8.Style.CornerDiameter = 4;
            this.groupPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel8.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel8.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel8.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel8.TabIndex = 1;
            this.groupPanel8.Text = "操作";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "住院首页附页",
            "手术操作附页",
            "抗生素使用附页",
            "重症医学附页",
            "压疮附页",
            "坠床/跌倒附页"});
            this.cboType.Location = new System.Drawing.Point(70, 19);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(118, 20);
            this.cboType.TabIndex = 2;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(13, 23);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(59, 12);
            this.label136.TabIndex = 1;
            this.label136.Text = "附页类型:";
            // 
            // btnAddAppendPage
            // 
            this.btnAddAppendPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddAppendPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddAppendPage.Location = new System.Drawing.Point(194, 13);
            this.btnAddAppendPage.Name = "btnAddAppendPage";
            this.btnAddAppendPage.Size = new System.Drawing.Size(68, 34);
            this.btnAddAppendPage.TabIndex = 0;
            this.btnAddAppendPage.Text = "添加附页";
            this.btnAddAppendPage.Click += new System.EventHandler(this.btnAddAppendPage_Click);
            // 
            // groupPanel7
            // 
            this.groupPanel7.AutoScroll = true;
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel7.Location = new System.Drawing.Point(0, 0);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(514, 550);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderBottomWidth = 1;
            this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderLeftWidth = 1;
            this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderRightWidth = 1;
            this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderTopWidth = 1;
            this.groupPanel7.Style.CornerDiameter = 4;
            this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel7.TabIndex = 0;
            this.groupPanel7.Text = "附页编辑";
            // 
            // ucCOVER_APPEND_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer2);
            this.Name = "ucCOVER_APPEND_MAIN";
            this.Size = new System.Drawing.Size(768, 550);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGvAppendPages)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel8.ResumeLayout(false);
            this.groupPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGvAppendPages;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel8;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label136;
        private DevComponents.DotNetBar.ButtonX btnAddAppendPage;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
