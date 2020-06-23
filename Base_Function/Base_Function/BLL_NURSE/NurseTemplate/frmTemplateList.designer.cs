namespace Base_Function.BLL_NURSE.NurseTemplate
{
    partial class frmTemplateList
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txtTempName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.group2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "模板内容";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(597, 78);
            this.textBox1.TabIndex = 7;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(694, 17);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 13;
            this.buttonX2.Text = "确定";
            this.buttonX2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(694, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.comboBoxEx1);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.txtTempName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(810, 51);
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
            this.groupPanel1.TabIndex = 15;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem1,
            this.comboItem2});
            this.comboBoxEx1.Location = new System.Drawing.Point(76, 11);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(120, 21);
            this.comboBoxEx1.TabIndex = 17;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "--请选择--";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "个人";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "病区";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(15, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(55, 23);
            this.labelX2.TabIndex = 16;
            this.labelX2.Text = "模板类型";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(209, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(62, 25);
            this.labelX1.TabIndex = 15;
            this.labelX1.Text = "模板名称";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(428, 10);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 14;
            this.buttonX1.Text = "查询";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // txtTempName
            // 
            // 
            // 
            // 
            this.txtTempName.Border.Class = "TextBoxBorder";
            this.txtTempName.Location = new System.Drawing.Point(273, 11);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.Size = new System.Drawing.Size(141, 21);
            this.txtTempName.TabIndex = 13;
            // 
            // group2
            // 
            this.group2.CanvasColor = System.Drawing.SystemColors.Control;
            this.group2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.group2.Controls.Add(this.textBox1);
            this.group2.Controls.Add(this.label3);
            this.group2.Controls.Add(this.btnCancel);
            this.group2.Controls.Add(this.buttonX2);
            this.group2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group2.Location = new System.Drawing.Point(0, 370);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(810, 114);
            // 
            // 
            // 
            this.group2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.group2.Style.BackColorGradientAngle = 90;
            this.group2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.group2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderBottomWidth = 1;
            this.group2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.group2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderLeftWidth = 1;
            this.group2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderRightWidth = 1;
            this.group2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.group2.Style.BorderTopWidth = 1;
            this.group2.Style.CornerDiameter = 4;
            this.group2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.group2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.group2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.group2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.group2.TabIndex = 16;
            this.group2.Text = "备注内容";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 57);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(798, 307);
            this.ucGridviewX1.TabIndex = 12;
            // 
            // frmTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 484);
            this.Controls.Add(this.group2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.ucGridviewX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模板提取";
            this.Load += new System.EventHandler(this.frmTemplateList_Load);
            this.groupPanel1.ResumeLayout(false);
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTempName;
        private DevComponents.DotNetBar.Controls.GroupPanel group2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}