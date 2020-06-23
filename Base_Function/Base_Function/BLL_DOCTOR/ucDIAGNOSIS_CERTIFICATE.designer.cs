namespace Base_Function.BLL_DOCTOR
{
    partial class ucDIAGNOSIS_CERTIFICATE
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblPid = new System.Windows.Forms.Label();
            this.lblMZZZ = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtAdvice = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入诊断ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dptCreateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxPrientNum = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblPid);
            this.groupPanel1.Controls.Add(this.lblMZZZ);
            this.groupPanel1.Controls.Add(this.lblSection);
            this.groupPanel1.Controls.Add(this.lblAge);
            this.groupPanel1.Controls.Add(this.lblSex);
            this.groupPanel1.Controls.Add(this.lblName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(727, 63);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "患者基本情况";
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.BackColor = System.Drawing.Color.Transparent;
            this.lblPid.Location = new System.Drawing.Point(515, 13);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(41, 12);
            this.lblPid.TabIndex = 5;
            this.lblPid.Text = "病案号";
            // 
            // lblMZZZ
            // 
            this.lblMZZZ.AutoSize = true;
            this.lblMZZZ.BackColor = System.Drawing.Color.Transparent;
            this.lblMZZZ.Location = new System.Drawing.Point(395, 13);
            this.lblMZZZ.Name = "lblMZZZ";
            this.lblMZZZ.Size = new System.Drawing.Size(53, 12);
            this.lblMZZZ.TabIndex = 4;
            this.lblMZZZ.Text = "门诊诊治";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.BackColor = System.Drawing.Color.Transparent;
            this.lblSection.Location = new System.Drawing.Point(299, 13);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(29, 12);
            this.lblSection.TabIndex = 3;
            this.lblSection.Text = "科别";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Location = new System.Drawing.Point(203, 13);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 12);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "年龄";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Location = new System.Drawing.Point(107, 13);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 12);
            this.lblSex.TabIndex = 1;
            this.lblSex.Text = "性别";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(11, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtAdvice);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 63);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(727, 292);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "诊断及意见";
            // 
            // txtAdvice
            // 
            this.txtAdvice.ContextMenuStrip = this.contextMenuStrip1;
            this.txtAdvice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAdvice.Location = new System.Drawing.Point(0, 0);
            this.txtAdvice.Name = "txtAdvice";
            this.txtAdvice.Size = new System.Drawing.Size(721, 228);
            this.txtAdvice.TabIndex = 1;
            this.txtAdvice.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入诊断ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 插入诊断ToolStripMenuItem
            // 
            this.插入诊断ToolStripMenuItem.Name = "插入诊断ToolStripMenuItem";
            this.插入诊断ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.插入诊断ToolStripMenuItem.Text = "插入诊断";
            this.插入诊断ToolStripMenuItem.Click += new System.EventHandler(this.插入诊断ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxPrientNum);
            this.panel1.Controls.Add(this.dptCreateTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 40);
            this.panel1.TabIndex = 0;
            // 
            // dptCreateTime
            // 
            this.dptCreateTime.CustomFormat = "yyyy-MM-dd";
            this.dptCreateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptCreateTime.Location = new System.Drawing.Point(45, 6);
            this.dptCreateTime.Name = "dptCreateTime";
            this.dptCreateTime.Size = new System.Drawing.Size(173, 21);
            this.dptCreateTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(366, 3);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(84, 28);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(276, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 28);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSure);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 41);
            this.panel2.TabIndex = 4;
            // 
            // cbxPrientNum
            // 
            this.cbxPrientNum.DisplayMember = "Text";
            this.cbxPrientNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxPrientNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPrientNum.FormattingEnabled = true;
            this.cbxPrientNum.ItemHeight = 15;
            this.cbxPrientNum.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbxPrientNum.Location = new System.Drawing.Point(301, 6);
            this.cbxPrientNum.Name = "cbxPrientNum";
            this.cbxPrientNum.Size = new System.Drawing.Size(68, 21);
            this.cbxPrientNum.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "打印数量：";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2";
            // 
            // ucDIAGNOSIS_CERTIFICATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucDIAGNOSIS_CERTIFICATE";
            this.Size = new System.Drawing.Size(727, 396);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.Label lblMZZZ;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dptCreateTime;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 插入诊断ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtAdvice;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxPrientNum;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}
