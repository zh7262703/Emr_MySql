namespace Base_Function.BLL_MANAGEMENT
{
    partial class UcAccountAction
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbxTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtOperUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtOperAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dtpEndTime);
            this.groupPanel1.Controls.Add(this.dtpStartTime);
            this.groupPanel1.Controls.Add(this.cbxTime);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.txtOperUser);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.txtOperAccount);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txtAccount);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(646, 100);
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
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "查询";
            // 
            // cbxTime
            // 
            this.cbxTime.Location = new System.Drawing.Point(314, 50);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(75, 23);
            this.cbxTime.TabIndex = 11;
            this.cbxTime.Text = "按时间";
            this.cbxTime.CheckedChanged += new System.EventHandler(this.cbxTime_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(488, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(166, 50);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(18, 21);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "-";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(9, 50);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(49, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "时间：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtOperUser
            // 
            // 
            // 
            // 
            this.txtOperUser.Border.Class = "TextBoxBorder";
            this.txtOperUser.Location = new System.Drawing.Point(463, 10);
            this.txtOperUser.Name = "txtOperUser";
            this.txtOperUser.Size = new System.Drawing.Size(100, 21);
            this.txtOperUser.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(399, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "操作人：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtOperAccount
            // 
            // 
            // 
            // 
            this.txtOperAccount.Border.Class = "TextBoxBorder";
            this.txtOperAccount.Location = new System.Drawing.Point(284, 10);
            this.txtOperAccount.Name = "txtOperAccount";
            this.txtOperAccount.Size = new System.Drawing.Size(100, 21);
            this.txtOperAccount.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(184, 10);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "操作人帐号：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtAccount
            // 
            // 
            // 
            // 
            this.txtAccount.Border.Class = "TextBoxBorder";
            this.txtAccount.Location = new System.Drawing.Point(63, 10);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(100, 21);
            this.txtAccount.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(8, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(49, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "帐号：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 100);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(646, 318);
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "异动帐号信息";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(640, 294);
            this.ucGridviewX1.TabIndex = 0;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(63, 50);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(97, 21);
            this.dtpStartTime.TabIndex = 12;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(190, 50);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(97, 21);
            this.dtpEndTime.TabIndex = 13;
            // 
            // UcAccountAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "UcAccountAction";
            this.Size = new System.Drawing.Size(646, 418);
            this.Load += new System.EventHandler(this.UcAccountAction_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxTime;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOperUser;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOperAccount;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAccount;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private Bifrost.ucGridviewX ucGridviewX1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
    }
}
