namespace Bifrost
{
    partial class frmRoleRange
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
            this.rdbArea = new System.Windows.Forms.RadioButton();
            this.rdbSection = new System.Windows.Forms.RadioButton();
            this.chkListRanges = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdbBigArea = new System.Windows.Forms.RadioButton();
            this.rdbBigSection = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSubHospital = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbArea
            // 
            this.rdbArea.AutoSize = true;
            this.rdbArea.Checked = true;
            this.rdbArea.Location = new System.Drawing.Point(140, 12);
            this.rdbArea.Name = "rdbArea";
            this.rdbArea.Size = new System.Drawing.Size(47, 16);
            this.rdbArea.TabIndex = 0;
            this.rdbArea.TabStop = true;
            this.rdbArea.Text = "病区";
            this.rdbArea.UseVisualStyleBackColor = true;
            this.rdbArea.CheckedChanged += new System.EventHandler(this.rdbArea_CheckedChanged);
            // 
            // rdbSection
            // 
            this.rdbSection.AutoSize = true;
            this.rdbSection.Location = new System.Drawing.Point(258, 12);
            this.rdbSection.Name = "rdbSection";
            this.rdbSection.Size = new System.Drawing.Size(47, 16);
            this.rdbSection.TabIndex = 1;
            this.rdbSection.Text = "科室";
            this.rdbSection.UseVisualStyleBackColor = true;
            this.rdbSection.CheckedChanged += new System.EventHandler(this.rdbSection_CheckedChanged);
            // 
            // chkListRanges
            // 
            this.chkListRanges.CheckOnClick = true;
            this.chkListRanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListRanges.FormattingEnabled = true;
            this.chkListRanges.Location = new System.Drawing.Point(0, 0);
            this.chkListRanges.Name = "chkListRanges";
            this.chkListRanges.Size = new System.Drawing.Size(366, 324);
            this.chkListRanges.TabIndex = 2;
            this.chkListRanges.SelectedIndexChanged += new System.EventHandler(this.chkListRanges_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel1);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 34);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel1
            // 
            this.btnCancel1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel1.Location = new System.Drawing.Point(190, 3);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(67, 27);
            this.btnCancel1.TabIndex = 3;
            this.btnCancel1.Text = "取消";
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(117, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(67, 27);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.chkListRanges);
            this.groupPanel1.Location = new System.Drawing.Point(3, 34);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(372, 354);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "使用范围列表";
            // 
            // rdbBigArea
            // 
            this.rdbBigArea.AutoSize = true;
            this.rdbBigArea.Location = new System.Drawing.Point(193, 12);
            this.rdbBigArea.Name = "rdbBigArea";
            this.rdbBigArea.Size = new System.Drawing.Size(59, 16);
            this.rdbBigArea.TabIndex = 5;
            this.rdbBigArea.Text = "大病区";
            this.rdbBigArea.UseVisualStyleBackColor = true;
            this.rdbBigArea.CheckedChanged += new System.EventHandler(this.rdbBigArea_CheckedChanged);
            // 
            // rdbBigSection
            // 
            this.rdbBigSection.AutoSize = true;
            this.rdbBigSection.Location = new System.Drawing.Point(311, 12);
            this.rdbBigSection.Name = "rdbBigSection";
            this.rdbBigSection.Size = new System.Drawing.Size(59, 16);
            this.rdbBigSection.TabIndex = 6;
            this.rdbBigSection.Text = "大科室";
            this.rdbBigSection.UseVisualStyleBackColor = true;
            this.rdbBigSection.CheckedChanged += new System.EventHandler(this.rdbBigSection_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "分院：";
            // 
            // cboSubHospital
            // 
            this.cboSubHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubHospital.FormattingEnabled = true;
            this.cboSubHospital.Location = new System.Drawing.Point(46, 11);
            this.cboSubHospital.Name = "cboSubHospital";
            this.cboSubHospital.Size = new System.Drawing.Size(88, 20);
            this.cboSubHospital.TabIndex = 8;
            this.cboSubHospital.SelectedIndexChanged += new System.EventHandler(this.cboSubHospital_SelectedIndexChanged);
            // 
            // frmRoleRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 428);
            this.Controls.Add(this.cboSubHospital);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbBigSection);
            this.Controls.Add(this.rdbBigArea);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rdbSection);
            this.Controls.Add(this.rdbArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoleRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色使用范围设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRoleRange_Load);
            this.panel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbArea;
        private System.Windows.Forms.RadioButton rdbSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chkListRanges;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel1;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.RadioButton rdbBigArea;
        private System.Windows.Forms.RadioButton rdbBigSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSubHospital;
    }
}