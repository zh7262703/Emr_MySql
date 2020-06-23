namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class UcPaperArchiveRegister
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
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.归档退回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纸质病历上交ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbOutTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbePArchive = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.cbeEArchive = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.tbxName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbxPID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbeSeccion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbeHospital = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.ContextMenuStrip = this.contextMenuStrip1;
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(981, 420);
            this.flgView.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.归档退回ToolStripMenuItem,
            this.纸质病历上交ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 归档退回ToolStripMenuItem
            // 
            this.归档退回ToolStripMenuItem.Name = "归档退回ToolStripMenuItem";
            this.归档退回ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.归档退回ToolStripMenuItem.Text = "归档退回";
            this.归档退回ToolStripMenuItem.Click += new System.EventHandler(this.归档退回ToolStripMenuItem_Click);
            // 
            // 纸质病历上交ToolStripMenuItem
            // 
            this.纸质病历上交ToolStripMenuItem.Name = "纸质病历上交ToolStripMenuItem";
            this.纸质病历上交ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.纸质病历上交ToolStripMenuItem.Text = "纸质病历上交";
            this.纸质病历上交ToolStripMenuItem.Click += new System.EventHandler(this.纸质病历上交ToolStripMenuItem_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtEnd);
            this.groupPanel1.Controls.Add(this.dtStart);
            this.groupPanel1.Controls.Add(this.btnExport);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.cbOutTime);
            this.groupPanel1.Controls.Add(this.cbePArchive);
            this.groupPanel1.Controls.Add(this.cbeEArchive);
            this.groupPanel1.Controls.Add(this.tbxName);
            this.groupPanel1.Controls.Add(this.tbxPID);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.cbeSeccion);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.cbeHospital);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(987, 100);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "纸质归档登记查询";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(242, 37);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(97, 21);
            this.dtEnd.TabIndex = 51;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(109, 37);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(98, 21);
            this.dtStart.TabIndex = 50;
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(659, 33);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 49;
            this.btnExport.Text = "导出Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(578, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(217, 39);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(19, 16);
            this.labelX7.TabIndex = 47;
            this.labelX7.Text = "—";
            // 
            // cbOutTime
            // 
            this.cbOutTime.AutoSize = true;
            this.cbOutTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbOutTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbOutTime.Location = new System.Drawing.Point(15, 38);
            this.cbOutTime.Name = "cbOutTime";
            this.cbOutTime.Size = new System.Drawing.Size(88, 18);
            this.cbOutTime.TabIndex = 44;
            this.cbOutTime.Text = "出院时间：";
            this.cbOutTime.CheckedChanged += new System.EventHandler(this.cbOutTime_CheckedChanged);
            // 
            // cbePArchive
            // 
            this.cbePArchive.DisplayMember = "Text";
            this.cbePArchive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbePArchive.FormattingEnabled = true;
            this.cbePArchive.ItemHeight = 15;
            this.cbePArchive.Items.AddRange(new object[] {
            this.comboItem9,
            this.comboItem7,
            this.comboItem8});
            this.cbePArchive.Location = new System.Drawing.Point(430, 35);
            this.cbePArchive.Name = "cbePArchive";
            this.cbePArchive.Size = new System.Drawing.Size(121, 21);
            this.cbePArchive.TabIndex = 43;
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "--请选择--";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "出院未归档";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "已归档";
            // 
            // cbeEArchive
            // 
            this.cbeEArchive.DisplayMember = "Text";
            this.cbeEArchive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbeEArchive.FormattingEnabled = true;
            this.cbeEArchive.ItemHeight = 15;
            this.cbeEArchive.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem5,
            this.comboItem6});
            this.cbeEArchive.Location = new System.Drawing.Point(828, 3);
            this.cbeEArchive.Name = "cbeEArchive";
            this.cbeEArchive.Size = new System.Drawing.Size(121, 21);
            this.cbeEArchive.TabIndex = 42;
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "--请选择--";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "出院未归档";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "已归档";
            // 
            // tbxName
            // 
            // 
            // 
            // 
            this.tbxName.Border.Class = "TextBoxBorder";
            this.tbxName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxName.Location = new System.Drawing.Point(626, 3);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(100, 21);
            this.tbxName.TabIndex = 41;
            // 
            // tbxPID
            // 
            // 
            // 
            // 
            this.tbxPID.Border.Class = "TextBoxBorder";
            this.tbxPID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPID.Location = new System.Drawing.Point(458, 3);
            this.tbxPID.Name = "tbxPID";
            this.tbxPID.Size = new System.Drawing.Size(100, 21);
            this.tbxPID.TabIndex = 8;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(371, 39);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(68, 18);
            this.labelX6.TabIndex = 7;
            this.labelX6.Text = "纸质归档：";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(744, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(68, 18);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "电子归档：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(578, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 18);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "姓名：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(398, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "住院号：";
            // 
            // cbeSeccion
            // 
            this.cbeSeccion.DisplayMember = "Text";
            this.cbeSeccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbeSeccion.FormattingEnabled = true;
            this.cbeSeccion.ItemHeight = 15;
            this.cbeSeccion.Location = new System.Drawing.Point(261, 3);
            this.cbeSeccion.Name = "cbeSeccion";
            this.cbeSeccion.Size = new System.Drawing.Size(121, 21);
            this.cbeSeccion.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(213, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(44, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "科室：";
            // 
            // cbeHospital
            // 
            this.cbeHospital.DisplayMember = "Text";
            this.cbeHospital.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbeHospital.FormattingEnabled = true;
            this.cbeHospital.ItemHeight = 15;
            this.cbeHospital.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cbeHospital.Location = new System.Drawing.Point(63, 3);
            this.cbeHospital.Name = "cbeHospital";
            this.cbeHospital.Size = new System.Drawing.Size(121, 21);
            this.cbeHospital.TabIndex = 1;
            this.cbeHospital.SelectedIndexChanged += new System.EventHandler(this.cbeHospital_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "全院";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "南院";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "北院";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "分院：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 100);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(987, 444);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "纸质归档登记显示列表";
            // 
            // UcPaperArchiveRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "UcPaperArchiveRegister";
            this.Size = new System.Drawing.Size(987, 544);
            this.Load += new System.EventHandler(this.UcPaperArchiveRegister_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bifrost.ucC1FlexGrid flgView;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxPID;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbeSeccion;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbeHospital;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbOutTime;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbePArchive;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbeEArchive;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbxName;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 归档退回ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纸质病历上交ToolStripMenuItem;
        private DevComponents.Editors.ComboItem comboItem9;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
    }
}
