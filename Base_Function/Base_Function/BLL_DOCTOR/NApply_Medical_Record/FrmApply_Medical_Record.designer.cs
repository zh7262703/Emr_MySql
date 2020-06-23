namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    partial class FrmApply_Medical_Record
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtBY_SECTIONT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApplicant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCanle = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtSick_OR_Section = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApplyReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPIDs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(684, 497);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 67);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(684, 220);
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
            this.groupPanel2.Text = "归档病人列表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(678, 196);
            this.ucC1FlexGrid1.TabIndex = 1;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtPName);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.txtPid);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(684, 67);
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
            this.groupPanel1.Text = "归档病人查询";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(180, 8);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(111, 21);
            this.txtPName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(117, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "病人姓名：";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(486, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(354, 9);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(111, 21);
            this.txtPid.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(303, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "住院号：";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.txtBY_SECTIONT);
            this.groupPanel3.Controls.Add(this.label7);
            this.groupPanel3.Controls.Add(this.txtApplicant);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.btnCanle);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.txtSick_OR_Section);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Controls.Add(this.txtApplyReason);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Controls.Add(this.txtPIDs);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(684, 206);
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
            this.groupPanel3.TabIndex = 0;
            this.groupPanel3.Text = "病历借阅申请";
            // 
            // txtBY_SECTIONT
            // 
            this.txtBY_SECTIONT.BackColor = System.Drawing.Color.White;
            this.txtBY_SECTIONT.Enabled = false;
            this.txtBY_SECTIONT.Location = new System.Drawing.Point(492, 115);
            this.txtBY_SECTIONT.Name = "txtBY_SECTIONT";
            this.txtBY_SECTIONT.ReadOnly = true;
            this.txtBY_SECTIONT.Size = new System.Drawing.Size(115, 21);
            this.txtBY_SECTIONT.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(417, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "申请者科室：";
            // 
            // txtApplicant
            // 
            this.txtApplicant.BackColor = System.Drawing.Color.White;
            this.txtApplicant.Enabled = false;
            this.txtApplicant.Location = new System.Drawing.Point(284, 116);
            this.txtApplicant.Name = "txtApplicant";
            this.txtApplicant.ReadOnly = true;
            this.txtApplicant.Size = new System.Drawing.Size(115, 21);
            this.txtApplicant.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(235, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "申请者：";
            // 
            // btnCanle
            // 
            this.btnCanle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCanle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCanle.Location = new System.Drawing.Point(342, 151);
            this.btnCanle.Name = "btnCanle";
            this.btnCanle.Size = new System.Drawing.Size(75, 23);
            this.btnCanle.TabIndex = 7;
            this.btnCanle.Text = "关闭";
            this.btnCanle.Click += new System.EventHandler(this.btnCanle_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(261, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "提交";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSick_OR_Section
            // 
            this.txtSick_OR_Section.BackColor = System.Drawing.Color.White;
            this.txtSick_OR_Section.Enabled = false;
            this.txtSick_OR_Section.Location = new System.Drawing.Point(100, 116);
            this.txtSick_OR_Section.Name = "txtSick_OR_Section";
            this.txtSick_OR_Section.ReadOnly = true;
            this.txtSick_OR_Section.Size = new System.Drawing.Size(107, 21);
            this.txtSick_OR_Section.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "病人所属科室：";
            // 
            // txtApplyReason
            // 
            this.txtApplyReason.Location = new System.Drawing.Point(100, 40);
            this.txtApplyReason.Multiline = true;
            this.txtApplyReason.Name = "txtApplyReason";
            this.txtApplyReason.Size = new System.Drawing.Size(507, 69);
            this.txtApplyReason.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(39, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "申请理由：";
            // 
            // txtPIDs
            // 
            this.txtPIDs.BackColor = System.Drawing.Color.White;
            this.txtPIDs.Location = new System.Drawing.Point(100, 12);
            this.txtPIDs.Name = "txtPIDs";
            this.txtPIDs.ReadOnly = true;
            this.txtPIDs.Size = new System.Drawing.Size(167, 21);
            this.txtPIDs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病历住院号：";
            // 
            // FrmApply_Medical_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 497);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Name = "FrmApply_Medical_Record";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "归档病历借阅申请";
            this.Load += new System.EventHandler(this.FrmApply_Medical_Record_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label3;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPIDs;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnCanle;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.TextBox txtSick_OR_Section;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApplyReason;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBY_SECTIONT;
        private System.Windows.Forms.Label label7;
    }
}