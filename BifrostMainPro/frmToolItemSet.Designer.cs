namespace BifrostMainPro
{
    partial class frmToolItemSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToolItemSet));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.advTree_AllTools = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxExSet = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboHost = new DevComponents.Editors.ComboItem();
            this.cboPersoner = new DevComponents.Editors.ComboItem();
            this.btnReturnBack = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.advTree_SelectedTools = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkSelectAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_AllTools)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_SelectedTools)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.advTree_AllTools);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(213, 415);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "工具栏按钮";
            // 
            // advTree_AllTools
            // 
            this.advTree_AllTools.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree_AllTools.AllowDrop = true;
            this.advTree_AllTools.BackColor = System.Drawing.Color.SkyBlue;
            // 
            // 
            // 
            this.advTree_AllTools.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree_AllTools.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree_AllTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree_AllTools.Location = new System.Drawing.Point(0, 0);
            this.advTree_AllTools.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.advTree_AllTools.Name = "advTree_AllTools";
            this.advTree_AllTools.NodesConnector = this.nodeConnector1;
            this.advTree_AllTools.NodeStyle = this.elementStyle1;
            this.advTree_AllTools.PathSeparator = ";";
            this.advTree_AllTools.Size = new System.Drawing.Size(207, 389);
            this.advTree_AllTools.Styles.Add(this.elementStyle1);
            this.advTree_AllTools.TabIndex = 0;
            this.advTree_AllTools.Text = "advTree1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxExSet);
            this.panel1.Controls.Add(this.btnReturnBack);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 415);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "类型：";
            // 
            // comboBoxExSet
            // 
            this.comboBoxExSet.DisplayMember = "Text";
            this.comboBoxExSet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExSet.FormattingEnabled = true;
            this.comboBoxExSet.ItemHeight = 17;
            this.comboBoxExSet.Items.AddRange(new object[] {
            this.cboHost,
            this.cboPersoner});
            this.comboBoxExSet.Location = new System.Drawing.Point(41, 89);
            this.comboBoxExSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxExSet.Name = "comboBoxExSet";
            this.comboBoxExSet.Size = new System.Drawing.Size(102, 23);
            this.comboBoxExSet.TabIndex = 3;
            this.comboBoxExSet.SelectedIndexChanged += new System.EventHandler(this.comboBoxExSet_SelectedIndexChanged);
            // 
            // cboHost
            // 
            this.cboHost.Text = "本机";
            // 
            // cboPersoner
            // 
            this.cboPersoner.Text = "个人";
            // 
            // btnReturnBack
            // 
            this.btnReturnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturnBack.Location = new System.Drawing.Point(41, 308);
            this.btnReturnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturnBack.Name = "btnReturnBack";
            this.btnReturnBack.Size = new System.Drawing.Size(104, 39);
            this.btnReturnBack.TabIndex = 2;
            this.btnReturnBack.Text = "重置(&E)";
            this.btnReturnBack.Click += new System.EventHandler(this.btnReturnBack_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(41, 230);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(104, 39);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "<<删除(&D)";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(41, 153);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 39);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加(&A)>>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.advTree_SelectedTools);
            this.groupPanel2.Controls.Add(this.panel5);
            this.groupPanel2.Controls.Add(this.panel4);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupPanel2.Location = new System.Drawing.Point(405, 0);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(250, 415);
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "选中的工具栏按钮";
            // 
            // advTree_SelectedTools
            // 
            this.advTree_SelectedTools.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree_SelectedTools.AllowDrop = true;
            this.advTree_SelectedTools.BackColor = System.Drawing.Color.SkyBlue;
            // 
            // 
            // 
            this.advTree_SelectedTools.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree_SelectedTools.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree_SelectedTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree_SelectedTools.Location = new System.Drawing.Point(0, 41);
            this.advTree_SelectedTools.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.advTree_SelectedTools.Name = "advTree_SelectedTools";
            this.advTree_SelectedTools.NodesConnector = this.nodeConnector2;
            this.advTree_SelectedTools.NodeStyle = this.elementStyle2;
            this.advTree_SelectedTools.PathSeparator = ";";
            this.advTree_SelectedTools.Size = new System.Drawing.Size(204, 348);
            this.advTree_SelectedTools.Styles.Add(this.elementStyle2);
            this.advTree_SelectedTools.TabIndex = 1;
            this.advTree_SelectedTools.Text = "advTree1";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnDown);
            this.panel5.Controls.Add(this.btnUp);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(204, 41);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(40, 348);
            this.panel5.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "排 序";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.chkSelectAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 41);
            this.panel4.TabIndex = 2;
            // 
            // chkSelectAll
            // 
            // 
            // 
            // 
            this.chkSelectAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSelectAll.Location = new System.Drawing.Point(30, 7);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(72, 27);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "全选";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Controls.Add(this.groupPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 415);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 415);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(655, 78);
            this.panel3.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(331, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(220, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(5, 194);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 51);
            this.btnDown.TabIndex = 1;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(5, 133);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 51);
            this.btnUp.TabIndex = 0;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmToolItemSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolItemSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具栏设置";
            this.Load += new System.EventHandler(this.frmToolItemSet_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree_AllTools)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree_SelectedTools)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.AdvTree.AdvTree advTree_AllTools;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.AdvTree.AdvTree advTree_SelectedTools;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ButtonX btnReturnBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSelectAll;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private DevComponents.DotNetBar.ButtonX btnUp;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExSet;
        private DevComponents.Editors.ComboItem cboHost;
        private DevComponents.Editors.ComboItem cboPersoner;
    }
}