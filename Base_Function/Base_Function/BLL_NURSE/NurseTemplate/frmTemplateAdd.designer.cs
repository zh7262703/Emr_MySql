namespace Base_Function.BLL_NURSE.NurseTemplate
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
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.group1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboCondiction = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.txtTemplateName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtModelID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtModelContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtModelTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.group1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Enabled = false;
            this.buttonX1.Location = new System.Drawing.Point(378, 93);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 29);
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(477, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // group1
            // 
            this.group1.CanvasColor = System.Drawing.SystemColors.Control;
            this.group1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.group1.Controls.Add(this.cboCondiction);
            this.group1.Controls.Add(this.txtTemplateName);
            this.group1.Controls.Add(this.labelX5);
            this.group1.Controls.Add(this.btnQuery);
            this.group1.Dock = System.Windows.Forms.DockStyle.Top;
            this.group1.Location = new System.Drawing.Point(0, 0);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(921, 74);
            this.group1.TabIndex = 8;
            this.group1.Text = "查询";
            // 
            // cboCondiction
            // 
            this.cboCondiction.DisplayMember = "Text";
            this.cboCondiction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCondiction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondiction.FormattingEnabled = true;
            this.cboCondiction.ItemHeight = 15;
            this.cboCondiction.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem8});
            this.cboCondiction.Location = new System.Drawing.Point(77, 25);
            this.cboCondiction.Name = "cboCondiction";
            this.cboCondiction.Size = new System.Drawing.Size(125, 21);
            this.cboCondiction.TabIndex = 9;
            this.cboCondiction.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx2_SelectedIndexChanged);
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "--请选择--";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "按模板名称查询";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "按模板内容查询";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "个人模板查询";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "病区模板查询";
            // 
            // txtTemplateName
            // 
            // 
            // 
            // 
            this.txtTemplateName.Border.Class = "TextBoxBorder";
            this.txtTemplateName.Location = new System.Drawing.Point(219, 25);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(143, 21);
            this.txtTemplateName.TabIndex = 8;
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(3, 23);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(68, 23);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "查询条件：";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(381, 25);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboType);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.txtModelID);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.btnDelete);
            this.groupPanel1.Controls.Add(this.btnUpdate);
            this.groupPanel1.Controls.Add(this.btnAdd);
            this.groupPanel1.Controls.Add(this.txtModelContent);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txtModelTitle);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 399);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(921, 157);
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
            this.groupPanel1.TabIndex = 9;
            this.groupPanel1.Text = "模板信息编辑";
            // 
            // cboType
            // 
            this.cboType.DisplayMember = "Text";
            this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Enabled = false;
            this.cboType.FormattingEnabled = true;
            this.cboType.ItemHeight = 15;
            this.cboType.Items.AddRange(new object[] {
            this.comboItem10,
            this.comboItem1,
            this.comboItem2});
            this.cboType.Location = new System.Drawing.Point(109, 53);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 18;
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "--请选择--";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "个人";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "病区";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX4.Location = new System.Drawing.Point(18, 53);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "类型：";
            // 
            // txtModelID
            // 
            // 
            // 
            // 
            this.txtModelID.Border.Class = "TextBoxBorder";
            this.txtModelID.Location = new System.Drawing.Point(109, 11);
            this.txtModelID.Name = "txtModelID";
            this.txtModelID.ReadOnly = true;
            this.txtModelID.Size = new System.Drawing.Size(121, 21);
            this.txtModelID.TabIndex = 16;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(18, 11);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "编号：";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(274, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(174, 93);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(73, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 29);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtModelContent
            // 
            // 
            // 
            // 
            this.txtModelContent.Border.Class = "TextBoxBorder";
            this.txtModelContent.Location = new System.Drawing.Point(351, 34);
            this.txtModelContent.Multiline = true;
            this.txtModelContent.Name = "txtModelContent";
            this.txtModelContent.ReadOnly = true;
            this.txtModelContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModelContent.Size = new System.Drawing.Size(429, 54);
            this.txtModelContent.TabIndex = 11;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX2.Location = new System.Drawing.Point(259, 53);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "模板内容：";
            // 
            // txtModelTitle
            // 
            // 
            // 
            // 
            this.txtModelTitle.Border.Class = "TextBoxBorder";
            this.txtModelTitle.Location = new System.Drawing.Point(351, 7);
            this.txtModelTitle.Name = "txtModelTitle";
            this.txtModelTitle.ReadOnly = true;
            this.txtModelTitle.Size = new System.Drawing.Size(429, 21);
            this.txtModelTitle.TabIndex = 9;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX1.Location = new System.Drawing.Point(259, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "模板名称：";
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 80);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(909, 313);
            this.ucGridviewX1.TabIndex = 10;
            this.ucGridviewX1.Load += new System.EventHandler(this.ucGridviewX1_Load);
            // 
            // frmTemplateAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 556);
            this.Controls.Add(this.ucGridviewX1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.group1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTemplateAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "护理模板添加";
            this.Load += new System.EventHandler(this.frmTemplateAdd_Load);
            this.group1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.GroupPanel group1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtModelTitle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtModelContent;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtModelID;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTemplateName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCondiction;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem10;

    }
}