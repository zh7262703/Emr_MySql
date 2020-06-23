namespace Base_Function.BLL_MANAGEMENT
{
    partial class UcCase
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
            this.gplSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnlState = new System.Windows.Forms.Panel();
            this.rbtnOutHospitao = new System.Windows.Forms.RadioButton();
            this.rbtnInHospital = new System.Windows.Forms.RadioButton();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbxSection = new System.Windows.Forms.ComboBox();
            this.chbTime = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgList = new Bifrost.ucGridviewX();
            this.gplSelect.SuspendLayout();
            this.pnlState.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gplSelect
            // 
            this.gplSelect.BackColor = System.Drawing.Color.Transparent;
            this.gplSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.gplSelect.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gplSelect.Controls.Add(this.pnlState);
            this.gplSelect.Controls.Add(this.btnSelect);
            this.gplSelect.Controls.Add(this.dtpEnd);
            this.gplSelect.Controls.Add(this.dtpStart);
            this.gplSelect.Controls.Add(this.cbxSection);
            this.gplSelect.Controls.Add(this.chbTime);
            this.gplSelect.Controls.Add(this.label3);
            this.gplSelect.Controls.Add(this.label2);
            this.gplSelect.Controls.Add(this.label1);
            this.gplSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.gplSelect.Location = new System.Drawing.Point(0, 0);
            this.gplSelect.Name = "gplSelect";
            this.gplSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gplSelect.Size = new System.Drawing.Size(1055, 72);
            // 
            // 
            // 
            this.gplSelect.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gplSelect.Style.BackColorGradientAngle = 90;
            this.gplSelect.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gplSelect.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gplSelect.Style.BorderBottomWidth = 1;
            this.gplSelect.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gplSelect.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gplSelect.Style.BorderLeftWidth = 1;
            this.gplSelect.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gplSelect.Style.BorderRightWidth = 1;
            this.gplSelect.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gplSelect.Style.BorderTopWidth = 1;
            this.gplSelect.Style.CornerDiameter = 4;
            this.gplSelect.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gplSelect.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gplSelect.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gplSelect.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gplSelect.TabIndex = 0;
            this.gplSelect.Text = "查询";
            // 
            // pnlState
            // 
            this.pnlState.Controls.Add(this.rbtnOutHospitao);
            this.pnlState.Controls.Add(this.rbtnInHospital);
            this.pnlState.Location = new System.Drawing.Point(718, 14);
            this.pnlState.Name = "pnlState";
            this.pnlState.Size = new System.Drawing.Size(111, 23);
            this.pnlState.TabIndex = 5;
            this.pnlState.Visible = false;
            // 
            // rbtnOutHospitao
            // 
            this.rbtnOutHospitao.AutoSize = true;
            this.rbtnOutHospitao.Location = new System.Drawing.Point(57, 4);
            this.rbtnOutHospitao.Name = "rbtnOutHospitao";
            this.rbtnOutHospitao.Size = new System.Drawing.Size(47, 16);
            this.rbtnOutHospitao.TabIndex = 0;
            this.rbtnOutHospitao.TabStop = true;
            this.rbtnOutHospitao.Text = "出院";
            this.rbtnOutHospitao.UseVisualStyleBackColor = true;
            // 
            // rbtnInHospital
            // 
            this.rbtnInHospital.AutoSize = true;
            this.rbtnInHospital.Checked = true;
            this.rbtnInHospital.Location = new System.Drawing.Point(4, 4);
            this.rbtnInHospital.Name = "rbtnInHospital";
            this.rbtnInHospital.Size = new System.Drawing.Size(47, 16);
            this.rbtnInHospital.TabIndex = 0;
            this.rbtnInHospital.TabStop = true;
            this.rbtnInHospital.Text = "在院";
            this.rbtnInHospital.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(838, 14);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(572, 14);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(137, 21);
            this.dtpEnd.TabIndex = 3;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStart.Enabled = false;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(401, 14);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(136, 21);
            this.dtpStart.TabIndex = 3;
            // 
            // cbxSection
            // 
            this.cbxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSection.FormattingEnabled = true;
            this.cbxSection.Location = new System.Drawing.Point(179, 14);
            this.cbxSection.Name = "cbxSection";
            this.cbxSection.Size = new System.Drawing.Size(121, 20);
            this.cbxSection.TabIndex = 2;
            // 
            // chbTime
            // 
            this.chbTime.AutoSize = true;
            this.chbTime.BackColor = System.Drawing.Color.Transparent;
            this.chbTime.Location = new System.Drawing.Point(309, 17);
            this.chbTime.Name = "chbTime";
            this.chbTime.Size = new System.Drawing.Size(15, 14);
            this.chbTime.TabIndex = 1;
            this.chbTime.UseVisualStyleBackColor = false;
            this.chbTime.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(546, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "—";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(333, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "入院时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(135, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室:";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgList);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 72);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1055, 409);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "列表";
            // 
            // flgList
            // 
            this.flgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgList.Location = new System.Drawing.Point(0, 0);
            this.flgList.Name = "flgList";
            this.flgList.Size = new System.Drawing.Size(1049, 385);
            this.flgList.TabIndex = 1;
            // 
            // UcCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.gplSelect);
            this.Name = "UcCase";
            this.Size = new System.Drawing.Size(1055, 481);
            this.gplSelect.ResumeLayout(false);
            this.gplSelect.PerformLayout();
            this.pnlState.ResumeLayout(false);
            this.pnlState.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gplSelect;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cbxSection;
        private System.Windows.Forms.CheckBox chbTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.Panel pnlState;
        private System.Windows.Forms.RadioButton rbtnOutHospitao;
        private System.Windows.Forms.RadioButton rbtnInHospital;
        private Bifrost.ucGridviewX flgList;
    }
}
