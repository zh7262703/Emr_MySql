namespace Base_Function.TEMPLATE
{
    partial class ucTempList_Small
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTempList_Small));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboSicknessKind = new System.Windows.Forms.ComboBox();
            this.cboSys1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUseRange = new System.Windows.Forms.ComboBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSys = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSys = new System.Windows.Forms.CheckBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboSicknessKind);
            this.groupPanel1.Controls.Add(this.cboSys1);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtTemplateName);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.cboUseRange);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cboSys);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.chkSys);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(726, 109);
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
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 13;
            this.groupPanel1.Text = "查询";
            // 
            // cboSicknessKind
            // 
            this.cboSicknessKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSicknessKind.Enabled = false;
            this.cboSicknessKind.FormattingEnabled = true;
            this.cboSicknessKind.Items.AddRange(new object[] {
            "请选择..."});
            this.cboSicknessKind.Location = new System.Drawing.Point(326, 42);
            this.cboSicknessKind.Name = "cboSicknessKind";
            this.cboSicknessKind.Size = new System.Drawing.Size(112, 20);
            this.cboSicknessKind.TabIndex = 25;
            // 
            // cboSys1
            // 
            this.cboSys1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSys1.Enabled = false;
            this.cboSys1.FormattingEnabled = true;
            this.cboSys1.Location = new System.Drawing.Point(85, 42);
            this.cboSys1.Name = "cboSys1";
            this.cboSys1.Size = new System.Drawing.Size(164, 20);
            this.cboSys1.TabIndex = 24;
            this.cboSys1.SelectedIndexChanged += new System.EventHandler(this.cboSys1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(267, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "病种类：";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(439, 10);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(147, 21);
            this.txtTemplateName.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(381, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "模板名称：";
            // 
            // cboUseRange
            // 
            this.cboUseRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseRange.FormattingEnabled = true;
            this.cboUseRange.Items.AddRange(new object[] {
            "请选择...",
            "个人",
            "科室"});
            this.cboUseRange.Location = new System.Drawing.Point(64, 10);
            this.cboUseRange.Name = "cboUseRange";
            this.cboUseRange.Size = new System.Drawing.Size(95, 20);
            this.cboUseRange.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(592, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 22);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "使用范围：";
            // 
            // cboSys
            // 
            this.cboSys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSys.FormattingEnabled = true;
            this.cboSys.Location = new System.Drawing.Point(203, 10);
            this.cboSys.Name = "cboSys";
            this.cboSys.Size = new System.Drawing.Size(164, 20);
            this.cboSys.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(169, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "类型：";
            // 
            // chkSys
            // 
            this.chkSys.AutoSize = true;
            this.chkSys.BackColor = System.Drawing.Color.Transparent;
            this.chkSys.Location = new System.Drawing.Point(7, 44);
            this.chkSys.Name = "chkSys";
            this.chkSys.Size = new System.Drawing.Size(84, 16);
            this.chkSys.TabIndex = 26;
            this.chkSys.Text = "所属系统：";
            this.chkSys.UseVisualStyleBackColor = false;
            this.chkSys.CheckedChanged += new System.EventHandler(this.chkSys_CheckedChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 109);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(726, 365);
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
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 14;
            this.groupPanel2.Text = "模板列表";
            // 
            // flgView
            // 
            this.flgView.AllowEditing = false;
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "1,1,0,0,0,0,Columns:0{Width:20;}\t";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgView.Size = new System.Drawing.Size(720, 341);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 3;
            this.flgView.Click += new System.EventHandler(this.flgView_Click);
            // 
            // ucTempList_Small
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucTempList_Small";
            this.Size = new System.Drawing.Size(726, 474);
            this.Load += new System.EventHandler(this.ucTempList_Small_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboUseRange;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSys;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private System.Windows.Forms.ComboBox cboSicknessKind;
        private System.Windows.Forms.ComboBox cboSys1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSys;
    }
}
