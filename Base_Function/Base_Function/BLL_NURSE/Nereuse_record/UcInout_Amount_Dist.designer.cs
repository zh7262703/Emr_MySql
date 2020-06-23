namespace Base_Function.BLL_NURSE.Nereuse_record
{
    partial class UcInout_Amount_Dist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcInout_Amount_Dist));
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ctmnspDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboBeds = new System.Windows.Forms.ComboBox();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdds = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btncalCulating = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxTotal = new System.Windows.Forms.ComboBox();
            this.dtpcSelect = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.flgGgDisPlay = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.ctmnspDelete.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgGgDisPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "13,0,0,0,0,0,Columns:";
            this.flgView.ContextMenuStrip = this.ctmnspDelete;
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.Size = new System.Drawing.Size(1144, 167);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 1;
            this.flgView.Click += new System.EventHandler(this.flgView_Click_1);
            this.flgView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flgView_MouseClick);
            this.flgView.DoubleClick += new System.EventHandler(this.flgView_DoubleClick_1);
            this.flgView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flgView_KeyUp);
            // 
            // ctmnspDelete
            // 
            this.ctmnspDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.ctmnspDelete.Name = "ctmnspDelete";
            this.ctmnspDelete.Size = new System.Drawing.Size(101, 26);
            this.ctmnspDelete.Opening += new System.ComponentModel.CancelEventHandler(this.ctmnspDelete_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
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
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 480);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 14;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 53);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1150, 191);
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
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "表格显示";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboBeds);
            this.groupPanel1.Controls.Add(this.btnPrint);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1150, 53);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "查询";
            // 
            // cboBeds
            // 
            this.cboBeds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBeds.Enabled = false;
            this.cboBeds.FormattingEnabled = true;
            this.cboBeds.Location = new System.Drawing.Point(55, 1);
            this.cboBeds.Name = "cboBeds";
            this.cboBeds.Size = new System.Drawing.Size(102, 20);
            this.cboBeds.TabIndex = 5;
            this.cboBeds.SelectedValueChanged += new System.EventHandler(this.cboBeds_SelectedValueChanged);
            this.cboBeds.Click += new System.EventHandler(this.cboBeds_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(723, -297);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxItem1});
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.GlobalItem = false;
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "床号：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdds);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 35);
            this.panel1.TabIndex = 6;
            // 
            // btnAdds
            // 
            this.btnAdds.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdds.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdds.Location = new System.Drawing.Point(479, 3);
            this.btnAdds.Name = "btnAdds";
            this.btnAdds.Size = new System.Drawing.Size(75, 23);
            this.btnAdds.TabIndex = 13;
            this.btnAdds.Text = "添加";
            this.btnAdds.Click += new System.EventHandler(this.btnAdds_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(579, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 12;
            this.buttonX1.Text = "打印";
            this.buttonX1.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.expandablePanel1);
            this.groupPanel3.Controls.Add(this.flgGgDisPlay);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1133, 199);
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
            this.groupPanel3.TabIndex = 5;
            this.groupPanel3.Text = "计算";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel1.Controls.Add(this.label5);
            this.expandablePanel1.Controls.Add(this.btncalCulating);
            this.expandablePanel1.Controls.Add(this.label7);
            this.expandablePanel1.Controls.Add(this.lblHour);
            this.expandablePanel1.Controls.Add(this.label10);
            this.expandablePanel1.Controls.Add(this.dtpStart);
            this.expandablePanel1.Controls.Add(this.label6);
            this.expandablePanel1.Controls.Add(this.label8);
            this.expandablePanel1.Controls.Add(this.cbxTotal);
            this.expandablePanel1.Controls.Add(this.dtpcSelect);
            this.expandablePanel1.Controls.Add(this.dtpEnd);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(1127, 89);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 13;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "计算出入量总量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "出入总量计算类型：";
            // 
            // btncalCulating
            // 
            this.btncalCulating.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncalCulating.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncalCulating.Location = new System.Drawing.Point(482, 62);
            this.btncalCulating.Name = "btncalCulating";
            this.btncalCulating.Size = new System.Drawing.Size(181, 23);
            this.btncalCulating.TabIndex = 2;
            this.btncalCulating.Text = "确认计算并加入到出入量记录中";
            this.btncalCulating.Click += new System.EventHandler(this.btncalCulating_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "截止时间：";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.ForeColor = System.Drawing.Color.Red;
            this.lblHour.Location = new System.Drawing.Point(859, 40);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(23, 12);
            this.lblHour.TabIndex = 9;
            this.lblHour.Text = "lab";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(884, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "小时";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(437, 37);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(139, 21);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "起始时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(804, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "时间跨度";
            // 
            // cbxTotal
            // 
            this.cbxTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTotal.FormattingEnabled = true;
            this.cbxTotal.Items.AddRange(new object[] {
            "24小时汇总",
            "随机汇总"});
            this.cbxTotal.Location = new System.Drawing.Point(148, 37);
            this.cbxTotal.Name = "cbxTotal";
            this.cbxTotal.Size = new System.Drawing.Size(121, 20);
            this.cbxTotal.TabIndex = 1;
            this.cbxTotal.SelectedIndexChanged += new System.EventHandler(this.cbxTotal_SelectedIndexChanged);
            // 
            // dtpcSelect
            // 
            this.dtpcSelect.CustomFormat = "yyyy-MM-dd";
            this.dtpcSelect.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcSelect.Location = new System.Drawing.Point(274, 36);
            this.dtpcSelect.Name = "dtpcSelect";
            this.dtpcSelect.Size = new System.Drawing.Size(94, 21);
            this.dtpcSelect.TabIndex = 11;
            this.dtpcSelect.ValueChanged += new System.EventHandler(this.dtpcSelect_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(647, 37);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(143, 21);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // flgGgDisPlay
            // 
            this.flgGgDisPlay.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgGgDisPlay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flgGgDisPlay.Location = new System.Drawing.Point(0, 91);
            this.flgGgDisPlay.Name = "flgGgDisPlay";
            this.flgGgDisPlay.Rows.DefaultSize = 18;
            this.flgGgDisPlay.Size = new System.Drawing.Size(1127, 84);
            this.flgGgDisPlay.StyleInfo = resources.GetString("flgGgDisPlay.StyleInfo");
            this.flgGgDisPlay.TabIndex = 12;
            // 
            // UcInout_Amount_Dist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UcInout_Amount_Dist";
            this.Size = new System.Drawing.Size(1150, 480);
            this.Load += new System.EventHandler(this.UcInout_Amount_Dist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.ctmnspDelete.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgGgDisPlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip ctmnspDelete;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private C1.Win.C1FlexGrid.C1FlexGrid flgGgDisPlay;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX btncalCulating;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpcSelect;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cbxTotal;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnAdds;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.ComboBox cboBeds;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
