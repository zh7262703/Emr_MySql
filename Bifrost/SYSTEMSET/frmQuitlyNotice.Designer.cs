namespace Bifrost
{
    partial class frmQuitlyNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuitlyNotice));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnQueary = new DevComponents.DotNetBar.ButtonX();
            this.txtBedNum = new System.Windows.Forms.TextBox();
            this.cmbNotice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "yellow.gif");
            this.imageList1.Images.SetKeyName(1, "red.gif");
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(985, 675);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(985, 650);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "管床医生监控列表";
            this.tabItem2.Visible = false;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupPanel2);
            this.tabControlPanel1.Controls.Add(this.groupPanel1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(985, 650);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(1, 82);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(983, 567);
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
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "查询结果";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(977, 543);
            this.ucGridviewX1.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnQueary);
            this.groupPanel1.Controls.Add(this.txtBedNum);
            this.groupPanel1.Controls.Add(this.cmbNotice);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cmbDocType);
            this.groupPanel1.Controls.Add(this.txtPatient);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(1, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(983, 81);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "查询设置";
            // 
            // btnQueary
            // 
            this.btnQueary.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQueary.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQueary.Location = new System.Drawing.Point(663, 11);
            this.btnQueary.Name = "btnQueary";
            this.btnQueary.Size = new System.Drawing.Size(88, 28);
            this.btnQueary.TabIndex = 9;
            this.btnQueary.Text = "查询";
            this.btnQueary.Click += new System.EventHandler(this.btnQueary_Click);
            // 
            // txtBedNum
            // 
            this.txtBedNum.Location = new System.Drawing.Point(48, 18);
            this.txtBedNum.Name = "txtBedNum";
            this.txtBedNum.Size = new System.Drawing.Size(73, 21);
            this.txtBedNum.TabIndex = 2;
            // 
            // cmbNotice
            // 
            this.cmbNotice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotice.FormattingEnabled = true;
            this.cmbNotice.Items.AddRange(new object[] {
            "请选择",
            "是",
            "否"});
            this.cmbNotice.Location = new System.Drawing.Point(562, 18);
            this.cmbNotice.Name = "cmbNotice";
            this.cmbNotice.Size = new System.Drawing.Size(73, 20);
            this.cmbNotice.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "床号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(519, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "预警:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(129, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "病人姓名:";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Items.AddRange(new object[] {
            "请选择",
            "体温单",
            "一般护理记录",
            "危重护理记录"});
            this.cmbDocType.Location = new System.Drawing.Point(387, 18);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(124, 20);
            this.cmbDocType.TabIndex = 5;
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(196, 18);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(116, 21);
            this.txtPatient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(320, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "文书类型:";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "质控详细信息查询";
            // 
            // frmQuitlyNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 675);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuitlyNotice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控提醒";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmQuitlyNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnQueary;
        private System.Windows.Forms.TextBox txtBedNum;
        private System.Windows.Forms.ComboBox cmbNotice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;      
    }
}