namespace Base_Function.BLL_NURSE.SickInformational
{
    partial class ucfrmSickReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucfrmSickReport));
            this.cfgcentent = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.DelectUpdateMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cfgTableHand = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnight = new DevComponents.DotNetBar.ButtonX();
            this.btnDay = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.SickName = new System.Windows.Forms.Label();
            this.PKdateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cfgcentent)).BeginInit();
            this.DelectUpdateMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgTableHand)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cfgcentent
            // 
            this.cfgcentent.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.cfgcentent.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.cfgcentent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgcentent.Location = new System.Drawing.Point(0, 0);
            this.cfgcentent.Name = "cfgcentent";
            this.cfgcentent.Rows.DefaultSize = 18;
            this.cfgcentent.Size = new System.Drawing.Size(955, 514);
            this.cfgcentent.StyleInfo = resources.GetString("cfgcentent.StyleInfo");
            this.cfgcentent.TabIndex = 2;
            this.cfgcentent.Click += new System.EventHandler(this.cfgcentent_Click);
            this.cfgcentent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cfgcentent_MouseClick);
            this.cfgcentent.DoubleClick += new System.EventHandler(this.cfgcentent_DoubleClick);
            // 
            // DelectUpdateMenuStrip
            // 
            this.DelectUpdateMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.DelectUpdateMenuStrip.Name = "contextMenuStrip1";
            this.DelectUpdateMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F);
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.删除ToolStripMenuItem.Text = "删  除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // cfgTableHand
            // 
            this.cfgTableHand.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.cfgTableHand.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.cfgTableHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgTableHand.Location = new System.Drawing.Point(0, 0);
            this.cfgTableHand.Name = "cfgTableHand";
            this.cfgTableHand.Rows.DefaultSize = 18;
            this.cfgTableHand.Size = new System.Drawing.Size(955, 129);
            this.cfgTableHand.StyleInfo = resources.GetString("cfgTableHand.StyleInfo");
            this.cfgTableHand.TabIndex = 1;
            this.cfgTableHand.Click += new System.EventHandler(this.cfgTableHand_Click);
            this.cfgTableHand.DoubleClick += new System.EventHandler(this.cfgTableHand_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.btnnight);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 772);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 39);
            this.panel1.TabIndex = 7;
            // 
            // btnnight
            // 
            this.btnnight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnnight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnnight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnnight.Location = new System.Drawing.Point(486, 8);
            this.btnnight.Name = "btnnight";
            this.btnnight.Size = new System.Drawing.Size(75, 23);
            this.btnnight.TabIndex = 2;
            this.btnnight.Text = "添加夜班";
            this.btnnight.Click += new System.EventHandler(this.btnnight_Click);
            // 
            // btnDay
            // 
            this.btnDay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDay.Location = new System.Drawing.Point(400, 8);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(75, 23);
            this.btnDay.TabIndex = 2;
            this.btnDay.Text = "添加白班";
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "病区：";
            // 
            // SickName
            // 
            this.SickName.AutoSize = true;
            this.SickName.Location = new System.Drawing.Point(435, 22);
            this.SickName.Name = "SickName";
            this.SickName.Size = new System.Drawing.Size(17, 12);
            this.SickName.TabIndex = 4;
            this.SickName.Text = "啊";
            // 
            // PKdateTime
            // 
            this.PKdateTime.CustomFormat = "yyyy-MM-dd";
            this.PKdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PKdateTime.Location = new System.Drawing.Point(78, 18);
            this.PKdateTime.Name = "PKdateTime";
            this.PKdateTime.Size = new System.Drawing.Size(99, 21);
            this.PKdateTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.SickName);
            this.groupPanel1.Controls.Add(this.PKdateTime);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(961, 81);
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
            this.groupPanel1.Text = "交接班记录查询";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(829, 17);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "打 印";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(193, 16);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cfgTableHand);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 81);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(961, 153);
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
            this.groupPanel2.Text = "病区基本信息";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.cfgcentent);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 234);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(961, 538);
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
            this.groupPanel3.TabIndex = 10;
            this.groupPanel3.Text = "病区详细信息";
            // 
            // ucfrmSickReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "ucfrmSickReport";
            this.Size = new System.Drawing.Size(961, 811);
            this.Load += new System.EventHandler(this.ucfrmSickReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cfgcentent)).EndInit();
            this.DelectUpdateMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cfgTableHand)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid cfgcentent;
        private System.Windows.Forms.ContextMenuStrip DelectUpdateMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private C1.Win.C1FlexGrid.C1FlexGrid cfgTableHand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SickName;
        private System.Windows.Forms.DateTimePicker PKdateTime;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnnight;
        private DevComponents.DotNetBar.ButtonX btnDay;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
