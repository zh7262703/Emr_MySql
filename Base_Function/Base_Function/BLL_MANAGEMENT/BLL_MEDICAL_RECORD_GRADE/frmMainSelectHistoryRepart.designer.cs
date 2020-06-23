namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class frmMainSelectHistoryRepart
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
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.contextMenuStripDeleteUpdate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.护理编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医疗报表toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.护理报表toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxSick = new Bifrost.MultiColumnComboBox();
            this.contextMenuStripDeleteUpdate.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.AutoScroll = true;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 78);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(916, 606);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.DoubleClick += new System.EventHandler(this.ucC1FlexGrid1_DoubleClick);
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            this.ucC1FlexGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucC1FlexGrid1_MouseClick);
            // 
            // contextMenuStripDeleteUpdate
            // 
            this.contextMenuStripDeleteUpdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.护理编辑ToolStripMenuItem,
            this.医疗报表toolStripMenuItem,
            this.护理报表toolStripMenuItem});
            this.contextMenuStripDeleteUpdate.Name = "contextMenuStripDeleteUpdate";
            this.contextMenuStripDeleteUpdate.Size = new System.Drawing.Size(147, 114);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Visible = false;
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.编辑ToolStripMenuItem.Text = "医疗评分编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 护理编辑ToolStripMenuItem
            // 
            this.护理编辑ToolStripMenuItem.Name = "护理编辑ToolStripMenuItem";
            this.护理编辑ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.护理编辑ToolStripMenuItem.Text = "护理评分编辑";
            this.护理编辑ToolStripMenuItem.Click += new System.EventHandler(this.护理编辑ToolStripMenuItem_Click);
            // 
            // 医疗报表toolStripMenuItem
            // 
            this.医疗报表toolStripMenuItem.Name = "医疗报表toolStripMenuItem";
            this.医疗报表toolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.医疗报表toolStripMenuItem.Text = "医疗报表";
            this.医疗报表toolStripMenuItem.Visible = false;
            this.医疗报表toolStripMenuItem.Click += new System.EventHandler(this.医疗报表toolStripMenuItem_Click);
            // 
            // 护理报表toolStripMenuItem
            // 
            this.护理报表toolStripMenuItem.Name = "护理报表toolStripMenuItem";
            this.护理报表toolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.护理报表toolStripMenuItem.Text = "护理报表";
            this.护理报表toolStripMenuItem.Visible = false;
            this.护理报表toolStripMenuItem.Click += new System.EventHandler(this.护理报表toolStripMenuItem_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(735, 16);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(109, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "打印报表";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cboxSick);
            this.groupPanel2.Controls.Add(this.dtpEnd);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.dtpStart);
            this.groupPanel2.Controls.Add(this.cbxDoctor);
            this.groupPanel2.Controls.Add(this.label8);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Controls.Add(this.buttonX1);
            this.groupPanel2.Controls.Add(this.button5);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(916, 78);
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
            this.groupPanel2.TabIndex = 8;
            this.groupPanel2.Text = "查询";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(540, 17);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(90, 21);
            this.dtpEnd.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "—";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd ";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(422, 17);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(89, 21);
            this.dtpStart.TabIndex = 35;
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(226, 17);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(102, 20);
            this.cbxDoctor.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(165, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "管床医生：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "病区：";
            // 
            // button5
            // 
            this.button5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button5.Location = new System.Drawing.Point(645, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "查 询";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "出区/死亡年月：";
            // 
            // cboxSick
            // 
            this.cboxSick.AutoComplete = true;
            this.cboxSick.AutoDropdown = true;
            this.cboxSick.AutoSelectColumn = true;
            this.cboxSick.BackColorEven = System.Drawing.Color.White;
            this.cboxSick.BackColorOdd = System.Drawing.Color.White;
            this.cboxSick.ColumnNames = "sick_area_name";
            this.cboxSick.ColumnWidthDefault = 75;
            this.cboxSick.ColumnWidths = "100";
            this.cboxSick.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboxSick.FormattingEnabled = true;
            this.cboxSick.LinkedColumnIndex = 0;
            this.cboxSick.LinkedTextBox = null;
            this.cboxSick.Location = new System.Drawing.Point(39, 16);
            this.cboxSick.Name = "cboxSick";
            this.cboxSick.Size = new System.Drawing.Size(121, 22);
            this.cboxSick.SqlColumnNameIndex = 0;
            this.cboxSick.TabIndex = 72;
            this.cboxSick.SelectedIndexChanged += new System.EventHandler(this.cboxSick_SelectedIndexChanged);
            // 
            // frmMainSelectHistoryRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 684);
            this.Controls.Add(this.ucC1FlexGrid1);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainSelectHistoryRepart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看评分历史报表";
            this.Load += new System.EventHandler(this.frmMainSelectHistoryRepart_Load);
            this.contextMenuStripDeleteUpdate.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeleteUpdate;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 护理编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医疗报表toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 护理报表toolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private Bifrost.MultiColumnComboBox cboxSick;
    }
}