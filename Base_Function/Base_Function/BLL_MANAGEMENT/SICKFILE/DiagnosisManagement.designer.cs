namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class DiagnosisManagement
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
            this.lblIsNull = new System.Windows.Forms.LinkLabel();
            this.txtDisagnoseICD10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStadardDisagnoseName = new System.Windows.Forms.TextBox();
            this.txtDiagnoseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIsNull
            // 
            this.lblIsNull.AutoSize = true;
            this.lblIsNull.BackColor = System.Drawing.Color.Transparent;
            this.lblIsNull.Location = new System.Drawing.Point(794, 23);
            this.lblIsNull.Name = "lblIsNull";
            this.lblIsNull.Size = new System.Drawing.Size(35, 12);
            this.lblIsNull.TabIndex = 12;
            this.lblIsNull.TabStop = true;
            this.lblIsNull.Text = "清 空";
            // 
            // txtDisagnoseICD10
            // 
            this.txtDisagnoseICD10.Location = new System.Drawing.Point(577, 20);
            this.txtDisagnoseICD10.Name = "txtDisagnoseICD10";
            this.txtDisagnoseICD10.Size = new System.Drawing.Size(114, 21);
            this.txtDisagnoseICD10.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(476, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "标准诊断ICD10：";
            // 
            // txtStadardDisagnoseName
            // 
            this.txtStadardDisagnoseName.Location = new System.Drawing.Point(346, 20);
            this.txtStadardDisagnoseName.Name = "txtStadardDisagnoseName";
            this.txtStadardDisagnoseName.Size = new System.Drawing.Size(114, 21);
            this.txtStadardDisagnoseName.TabIndex = 9;
            // 
            // txtDiagnoseName
            // 
            this.txtDiagnoseName.Location = new System.Drawing.Point(121, 20);
            this.txtDiagnoseName.Name = "txtDiagnoseName";
            this.txtDiagnoseName.Size = new System.Drawing.Size(114, 21);
            this.txtDiagnoseName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(251, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "标准诊断名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(26, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "通用诊断名称：";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.BackColor = System.Drawing.Color.Transparent;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(1062, 679);
            this.ucC1FlexGrid1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(504, 741);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "添 加";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.lblIsNull);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtDisagnoseICD10);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtStadardDisagnoseName);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtDiagnoseName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1068, 74);
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
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "诊断管理设置";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(697, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 13;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 74);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1068, 703);
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
            this.groupPanel2.TabIndex = 4;
            this.groupPanel2.Text = "诊断管理显示列表";
            // 
            // DiagnosisManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.button3);
            this.Name = "DiagnosisManagement";
            this.Size = new System.Drawing.Size(1068, 777);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.TextBox txtStadardDisagnoseName;
        private System.Windows.Forms.TextBox txtDiagnoseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisagnoseICD10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel lblIsNull;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnQuery;
    }
}
