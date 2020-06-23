namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    partial class frmTemplateAdd
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(160, 161);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 29);
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(241, 161);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 29);
            this.buttonX2.TabIndex = 7;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX4.Location = new System.Drawing.Point(22, 9);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "类型：";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX2.Location = new System.Drawing.Point(21, 82);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "模板内容：";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX1.Location = new System.Drawing.Point(21, 38);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "模板名称：";
            // 
            // cboType
            // 
            this.cboType.AutoCompleteCustomSource.AddRange(new string[] {
            "个人",
            "病区",
            "全院",
            "无"});
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "个人",
            "病区",
            "全院"});
            this.cboType.Location = new System.Drawing.Point(113, 9);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(108, 20);
            this.cboType.TabIndex = 20;
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(113, 36);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(344, 21);
            this.txtTemplateName.TabIndex = 21;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(113, 63);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(344, 85);
            this.txtRemark.TabIndex = 22;
            // 
            // frmTemplateAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 208);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTemplateAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "护理模板添加";
            this.Load += new System.EventHandler(this.frmTemplateAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.TextBox txtRemark;

    }
}