namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucCase_History_Apply_Totreat
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.txtShenqing = new System.Windows.Forms.TextBox();
            this.dtpStartYear = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboFrequencyItem = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnStatistics = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtShenqing
            // 
            this.txtShenqing.Location = new System.Drawing.Point(276, 15);
            this.txtShenqing.Name = "txtShenqing";
            this.txtShenqing.Size = new System.Drawing.Size(107, 21);
            this.txtShenqing.TabIndex = 14;
            // 
            // dtpStartYear
            // 
            this.dtpStartYear.CustomFormat = "yyyy-MM-dd";
            this.dtpStartYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartYear.Location = new System.Drawing.Point(463, 14);
            this.dtpStartYear.Name = "dtpStartYear";
            this.dtpStartYear.Size = new System.Drawing.Size(118, 21);
            this.dtpStartYear.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(401, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "申请时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "申请人：";
            // 
            // cboFrequencyItem
            // 
            this.cboFrequencyItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrequencyItem.FormattingEnabled = true;
            this.cboFrequencyItem.Location = new System.Drawing.Point(93, 15);
            this.cboFrequencyItem.Name = "cboFrequencyItem";
            this.cboFrequencyItem.Size = new System.Drawing.Size(121, 20);
            this.cboFrequencyItem.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "申请科室：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnStatistics);
            this.groupPanel1.Controls.Add(this.txtShenqing);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.dtpStartYear);
            this.groupPanel1.Controls.Add(this.cboFrequencyItem);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(785, 73);
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
            this.groupPanel1.TabIndex = 8;
            this.groupPanel1.Text = "病历申请处理查询设置";
            // 
            // btnStatistics
            // 
            this.btnStatistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStatistics.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStatistics.Location = new System.Drawing.Point(587, 12);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(75, 23);
            this.btnStatistics.TabIndex = 15;
            this.btnStatistics.Text = "查 询";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 73);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(785, 489);
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
            this.groupPanel2.TabIndex = 9;
            this.groupPanel2.Text = "病历申请处理显示列表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(779, 465);
            this.ucC1FlexGrid1.TabIndex = 1;
            this.ucC1FlexGrid1.Load += new System.EventHandler(this.ucC1FlexGrid1_Load);
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 65);
            this.panel1.TabIndex = 10;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(313, 21);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "同意申请";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(396, 21);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = "拒绝";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // ucCase_History_Apply_Totreat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ucCase_History_Apply_Totreat";
            this.Size = new System.Drawing.Size(785, 627);
            this.Load += new System.EventHandler(this.ucCase_History_Apply_Totreat_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtShenqing;
        private System.Windows.Forms.DateTimePicker dtpStartYear;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFrequencyItem;
        private System.Windows.Forms.Label label12;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnStatistics;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
