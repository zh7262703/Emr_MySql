namespace Base_Function.BLL_MANAGEMENT
{
    partial class ucKey_Words
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
            this.label7 = new System.Windows.Forms.Label();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtKEY_COMPLAINT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKEY_DIAGNOSE = new System.Windows.Forms.TextBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnconfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "主诉关键字：";
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Location = new System.Drawing.Point(457, 67);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(74, 28);
            this.btncancel.TabIndex = 42;
            this.btncancel.Text = "取 消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(164, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "内容：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtKEY_COMPLAINT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKEY_DIAGNOSE, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 57);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // txtKEY_COMPLAINT
            // 
            this.txtKEY_COMPLAINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKEY_COMPLAINT.Location = new System.Drawing.Point(86, 3);
            this.txtKEY_COMPLAINT.Name = "txtKEY_COMPLAINT";
            this.txtKEY_COMPLAINT.Size = new System.Drawing.Size(575, 21);
            this.txtKEY_COMPLAINT.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "诊断关键字：";
            // 
            // txtKEY_DIAGNOSE
            // 
            this.txtKEY_DIAGNOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKEY_DIAGNOSE.Location = new System.Drawing.Point(86, 32);
            this.txtKEY_DIAGNOSE.Name = "txtKEY_DIAGNOSE";
            this.txtKEY_DIAGNOSE.Size = new System.Drawing.Size(575, 21);
            this.txtKEY_DIAGNOSE.TabIndex = 19;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.tableLayoutPanel1);
            this.groupPanel3.Controls.Add(this.btncancel);
            this.groupPanel3.Controls.Add(this.btnconfirm);
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.btnUpdate);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(670, 134);
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
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "关键字内容编辑";
            // 
            // btnconfirm
            // 
            this.btnconfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnconfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnconfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnconfirm.Location = new System.Drawing.Point(376, 67);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(74, 28);
            this.btnconfirm.TabIndex = 41;
            this.btnconfirm.Text = "确 定";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(295, 67);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 28);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "删 除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(214, 67);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 28);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "修 改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(133, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 28);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "添 加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(664, 365);
            this.ucGridviewX1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucGridviewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 56);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(670, 389);
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
            this.groupPanel2.Text = "关键字列表";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(670, 583);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtKey);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(670, 56);
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
            this.groupPanel1.Text = "查询";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(391, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(74, 28);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查 找";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtKey
            // 
            this.txtKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtKey.Location = new System.Drawing.Point(213, 5);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(170, 21);
            this.txtKey.TabIndex = 0;
            // 
            // ucKey_Words
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucKey_Words";
            this.Size = new System.Drawing.Size(670, 583);
            this.Load += new System.EventHandler(this.ucKey_Words_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btncancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnconfirm;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private Bifrost.ucGridviewX ucGridviewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtKEY_DIAGNOSE;
        private System.Windows.Forms.TextBox txtKEY_COMPLAINT;

    }
}
