namespace Base_Function.BLL_DOCTOR.Archive
{
    partial class ucLookSign
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
            this.gpnlSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnOut_Hospital = new System.Windows.Forms.RadioButton();
            this.rbtnIn_Hostipal = new System.Windows.Forms.RadioButton();
            this.txtDoctor_Name = new System.Windows.Forms.TextBox();
            this.txtPatient_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpnlList = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.gpnlSelect.SuspendLayout();
            this.gpnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpnlSelect
            // 
            this.gpnlSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpnlSelect.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpnlSelect.Controls.Add(this.btnSelect);
            this.gpnlSelect.Controls.Add(this.rbtnOut_Hospital);
            this.gpnlSelect.Controls.Add(this.rbtnIn_Hostipal);
            this.gpnlSelect.Controls.Add(this.txtDoctor_Name);
            this.gpnlSelect.Controls.Add(this.txtPatient_Name);
            this.gpnlSelect.Controls.Add(this.label2);
            this.gpnlSelect.Controls.Add(this.label1);
            this.gpnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpnlSelect.Location = new System.Drawing.Point(0, 0);
            this.gpnlSelect.Name = "gpnlSelect";
            this.gpnlSelect.Size = new System.Drawing.Size(845, 83);
            // 
            // 
            // 
            this.gpnlSelect.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpnlSelect.Style.BackColorGradientAngle = 90;
            this.gpnlSelect.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpnlSelect.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlSelect.Style.BorderBottomWidth = 1;
            this.gpnlSelect.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpnlSelect.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlSelect.Style.BorderLeftWidth = 1;
            this.gpnlSelect.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlSelect.Style.BorderRightWidth = 1;
            this.gpnlSelect.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlSelect.Style.BorderTopWidth = 1;
            this.gpnlSelect.Style.CornerDiameter = 4;
            this.gpnlSelect.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpnlSelect.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpnlSelect.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpnlSelect.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gpnlSelect.TabIndex = 0;
            this.gpnlSelect.Text = "查询";
            // 
            // rbtnOut_Hospital
            // 
            this.rbtnOut_Hospital.AutoSize = true;
            this.rbtnOut_Hospital.Checked = true;
            this.rbtnOut_Hospital.Location = new System.Drawing.Point(431, 20);
            this.rbtnOut_Hospital.Name = "rbtnOut_Hospital";
            this.rbtnOut_Hospital.Size = new System.Drawing.Size(47, 16);
            this.rbtnOut_Hospital.TabIndex = 3;
            this.rbtnOut_Hospital.TabStop = true;
            this.rbtnOut_Hospital.Text = "出院";
            this.rbtnOut_Hospital.UseVisualStyleBackColor = true;
            // 
            // rbtnIn_Hostipal
            // 
            this.rbtnIn_Hostipal.AutoSize = true;
            this.rbtnIn_Hostipal.Location = new System.Drawing.Point(384, 20);
            this.rbtnIn_Hostipal.Name = "rbtnIn_Hostipal";
            this.rbtnIn_Hostipal.Size = new System.Drawing.Size(47, 16);
            this.rbtnIn_Hostipal.TabIndex = 3;
            this.rbtnIn_Hostipal.Text = "在院";
            this.rbtnIn_Hostipal.UseVisualStyleBackColor = true;
            // 
            // txtDoctor_Name
            // 
            this.txtDoctor_Name.BackColor = System.Drawing.SystemColors.Control;
            this.txtDoctor_Name.Location = new System.Drawing.Point(256, 17);
            this.txtDoctor_Name.Name = "txtDoctor_Name";
            this.txtDoctor_Name.Size = new System.Drawing.Size(122, 21);
            this.txtDoctor_Name.TabIndex = 1;
            this.txtDoctor_Name.Text = "可拼音码或名称查询";
            this.txtDoctor_Name.Leave += new System.EventHandler(this.txtPatient_Name_Leave);
            this.txtDoctor_Name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPatient_Name_MouseClick);
            // 
            // txtPatient_Name
            // 
            this.txtPatient_Name.BackColor = System.Drawing.SystemColors.Control;
            this.txtPatient_Name.Location = new System.Drawing.Point(63, 17);
            this.txtPatient_Name.Name = "txtPatient_Name";
            this.txtPatient_Name.Size = new System.Drawing.Size(117, 21);
            this.txtPatient_Name.TabIndex = 1;
            this.txtPatient_Name.Text = "可拼音码或名称查询";
            this.txtPatient_Name.Leave += new System.EventHandler(this.txtPatient_Name_Leave);
            this.txtPatient_Name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPatient_Name_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "管床医生：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人姓名：";
            // 
            // gpnlList
            // 
            this.gpnlList.BackColor = System.Drawing.Color.White;
            this.gpnlList.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpnlList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpnlList.Controls.Add(this.flgView);
            this.gpnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpnlList.Location = new System.Drawing.Point(0, 83);
            this.gpnlList.Name = "gpnlList";
            this.gpnlList.Size = new System.Drawing.Size(845, 398);
            // 
            // 
            // 
            this.gpnlList.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpnlList.Style.BackColorGradientAngle = 90;
            this.gpnlList.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpnlList.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlList.Style.BorderBottomWidth = 1;
            this.gpnlList.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpnlList.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlList.Style.BorderLeftWidth = 1;
            this.gpnlList.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlList.Style.BorderRightWidth = 1;
            this.gpnlList.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpnlList.Style.BorderTopWidth = 1;
            this.gpnlList.Style.CornerDiameter = 4;
            this.gpnlList.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpnlList.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpnlList.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpnlList.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gpnlList.TabIndex = 0;
            this.gpnlList.Text = "未签名文书列表";
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(839, 374);
            this.flgView.TabIndex = 3;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(484, 17);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ucLookSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gpnlList);
            this.Controls.Add(this.gpnlSelect);
            this.Name = "ucLookSign";
            this.Size = new System.Drawing.Size(845, 481);
            this.gpnlSelect.ResumeLayout(false);
            this.gpnlSelect.PerformLayout();
            this.gpnlList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gpnlSelect;
        private DevComponents.DotNetBar.Controls.GroupPanel gpnlList;
        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.RadioButton rbtnOut_Hospital;
        private System.Windows.Forms.RadioButton rbtnIn_Hostipal;
        private System.Windows.Forms.TextBox txtDoctor_Name;
        private System.Windows.Forms.TextBox txtPatient_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
    }
}
