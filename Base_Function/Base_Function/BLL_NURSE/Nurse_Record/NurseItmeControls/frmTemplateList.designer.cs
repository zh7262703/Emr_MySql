namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    partial class frmTemplateList
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempName = new System.Windows.Forms.TextBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.group2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnNewTemplate = new DevComponents.DotNetBar.ButtonX();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1.SuspendLayout();
            this.group2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "模板内容";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(355, 64);
            this.textBox1.TabIndex = 7;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(464, 44);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 13;
            this.buttonX2.Text = "确定";
            this.buttonX2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(626, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboType);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtTempName);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(810, 61);
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
            this.groupPanel1.TabIndex = 15;
            this.groupPanel1.Text = "查询设置";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "个人",
            "病区",
            "全院"});
            this.cboType.Location = new System.Drawing.Point(76, 9);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(132, 20);
            this.cboType.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(17, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "模板类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(214, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "模板名称";
            // 
            // txtTempName
            // 
            this.txtTempName.Location = new System.Drawing.Point(273, 9);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.Size = new System.Drawing.Size(124, 21);
            this.txtTempName.TabIndex = 18;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(420, 6);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 14;
            this.buttonX1.Text = "查询";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click_1);
            // 
            // group2
            // 
            this.group2.CanvasColor = System.Drawing.SystemColors.Control;
            this.group2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.group2.Controls.Add(this.btnNewTemplate);
            this.group2.Controls.Add(this.textBox1);
            this.group2.Controls.Add(this.label3);
            this.group2.Controls.Add(this.btnCancel);
            this.group2.Controls.Add(this.buttonX2);
            this.group2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group2.Location = new System.Drawing.Point(0, 376);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(810, 108);
            // 
            // 
            // 
            this.group2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.group2.Style.BackColorGradientAngle = 90;
            this.group2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.group2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderBottomWidth = 1;
            this.group2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.group2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderLeftWidth = 1;
            this.group2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderRightWidth = 1;
            this.group2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderTopWidth = 1;
            this.group2.Style.CornerDiameter = 4;
            this.group2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.group2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.group2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.group2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.group2.TabIndex = 16;
            this.group2.Text = "编辑";
            // 
            // btnNewTemplate
            // 
            this.btnNewTemplate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNewTemplate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNewTemplate.Location = new System.Drawing.Point(545, 44);
            this.btnNewTemplate.Name = "btnNewTemplate";
            this.btnNewTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnNewTemplate.TabIndex = 15;
            this.btnNewTemplate.Text = "添加新模板";
            this.btnNewTemplate.Click += new System.EventHandler(this.btnNewTemplate_Click);
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(804, 291);
            this.ucGridviewX1.TabIndex = 12;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 61);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(810, 315);
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
            this.groupPanel2.TabIndex = 17;
            this.groupPanel2.Text = "模板列表";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // frmTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 484);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.group2);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模板提取";
            this.Load += new System.EventHandler(this.frmTemplateList_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.GroupPanel group2;
        private System.Windows.Forms.TextBox txtTempName;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnNewTemplate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}