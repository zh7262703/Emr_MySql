namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucWork_Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWork_Statistics));
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.c1FlexGrid3 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button10 = new DevComponents.DotNetBar.ButtonX();
            this.button8 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid3)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(524, 19);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(94, 21);
            this.dateTimePicker3.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "—";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(401, 20);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(94, 21);
            this.dateTimePicker4.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(363, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "时间：";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(265, 21);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(83, 20);
            this.comboBox6.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(218, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "频率：";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(86, 21);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 20);
            this.comboBox7.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "统计项目：";
            // 
            // c1FlexGrid3
            // 
            this.c1FlexGrid3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid3.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.c1FlexGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid3.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid3.Name = "c1FlexGrid3";
            this.c1FlexGrid3.Rows.DefaultSize = 18;
            this.c1FlexGrid3.Size = new System.Drawing.Size(946, 489);
            this.c1FlexGrid3.StyleInfo = resources.GetString("c1FlexGrid3.StyleInfo");
            this.c1FlexGrid3.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.button8);
            this.groupPanel1.Controls.Add(this.button10);
            this.groupPanel1.Controls.Add(this.dateTimePicker3);
            this.groupPanel1.Controls.Add(this.comboBox6);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.dateTimePicker4);
            this.groupPanel1.Controls.Add(this.comboBox7);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(952, 84);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "考勤统计查询设置";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.c1FlexGrid3);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 84);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(952, 513);
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
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "考勤统计显示列表";
            // 
            // button10
            // 
            this.button10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button10.Location = new System.Drawing.Point(633, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "统 计";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button8.Location = new System.Drawing.Point(714, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "打 印";
            // 
            // ucWork_Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucWork_Statistics";
            this.Size = new System.Drawing.Size(952, 597);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid3)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label16;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX button10;
        private DevComponents.DotNetBar.ButtonX button8;
    }
}
