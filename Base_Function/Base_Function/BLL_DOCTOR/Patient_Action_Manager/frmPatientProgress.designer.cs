namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmPatientProgress
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnFenxi = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkItemList = new System.Windows.Forms.CheckedListBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.axisScroll1 = new Steema.TeeChart.Tools.AxisScroll();
            this.label4 = new System.Windows.Forms.Label();
            this.txtzycs = new System.Windows.Forms.TextBox();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtzycs);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.btnSure);
            this.groupPanel1.Controls.Add(this.dateTimePicker2);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.dateTimePicker1);
            this.groupPanel1.Controls.Add(this.btnFenxi);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1279, 85);
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
            this.groupPanel1.Text = "查询调试";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(922, 12);
            this.btnSure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(100, 34);
            this.btnSure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(279, 19);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(168, 25);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(248, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(71, 19);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(168, 25);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnFenxi
            // 
            this.btnFenxi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFenxi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFenxi.Location = new System.Drawing.Point(819, 12);
            this.btnFenxi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFenxi.Name = "btnFenxi";
            this.btnFenxi.Size = new System.Drawing.Size(95, 34);
            this.btnFenxi.TabIndex = 1;
            this.btnFenxi.Text = "结果分析";
            this.btnFenxi.Click += new System.EventHandler(this.btnFenxi_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(717, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.chkItemList);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 85);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1279, 185);
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
            this.groupPanel2.Text = "检验项目";
            // 
            // chkItemList
            // 
            this.chkItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkItemList.FormattingEnabled = true;
            this.chkItemList.Location = new System.Drawing.Point(0, 0);
            this.chkItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkItemList.MultiColumn = true;
            this.chkItemList.Name = "chkItemList";
            this.chkItemList.Size = new System.Drawing.Size(1273, 158);
            this.chkItemList.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.tChart1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 270);
            this.groupPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1279, 444);
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
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 2;
            this.groupPanel3.Text = "趋势分析图";
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.View3D = false;
            this.tChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(0, 0);
            this.tChart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tChart1.Size = new System.Drawing.Size(1273, 417);
            this.tChart1.TabIndex = 0;
            this.tChart1.Tools.Add(this.axisScroll1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(489, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "住院次数：";
            // 
            // txtzycs
            // 
            this.txtzycs.Location = new System.Drawing.Point(575, 19);
            this.txtzycs.Name = "txtzycs";
            this.txtzycs.Size = new System.Drawing.Size(100, 25);
            this.txtzycs.TabIndex = 10;
            // 
            // frmPatientProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 714);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人检验趋势图";
            this.Load += new System.EventHandler(this.frmPatientProgress_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevComponents.DotNetBar.ButtonX btnFenxi;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.CheckedListBox chkItemList;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private Steema.TeeChart.TChart tChart1;
        private Steema.TeeChart.Tools.AxisScroll axisScroll1;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtzycs;
    }
}