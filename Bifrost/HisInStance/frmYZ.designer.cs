namespace Bifrost.HisInstance
{
    partial class frmYZ
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZ));
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.lblPatient = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNoMedical = new System.Windows.Forms.CheckBox();
            this.chkMedical = new System.Windows.Forms.CheckBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.ShortDgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.shorttab = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.longDgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.longtab = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShortDgv)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longDgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(158, 30);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "查询";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.Location = new System.Drawing.Point(9, 8);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(65, 12);
            this.lblPatient.TabIndex = 12;
            this.lblPatient.Text = "病人编号：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.panel2);
            this.groupPanel1.Controls.Add(this.btnOk);
            this.groupPanel1.Controls.Add(this.lblPatient);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(974, 66);
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
            this.groupPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.chkNoMedical);
            this.panel2.Controls.Add(this.chkMedical);
            this.panel2.Location = new System.Drawing.Point(9, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 22);
            this.panel2.TabIndex = 18;
            // 
            // chkNoMedical
            // 
            this.chkNoMedical.AutoSize = true;
            this.chkNoMedical.Checked = true;
            this.chkNoMedical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoMedical.Location = new System.Drawing.Point(55, 4);
            this.chkNoMedical.Name = "chkNoMedical";
            this.chkNoMedical.Size = new System.Drawing.Size(60, 16);
            this.chkNoMedical.TabIndex = 2;
            this.chkNoMedical.Text = "非药品";
            this.chkNoMedical.UseVisualStyleBackColor = true;
            // 
            // chkMedical
            // 
            this.chkMedical.AutoSize = true;
            this.chkMedical.Checked = true;
            this.chkMedical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMedical.Location = new System.Drawing.Point(0, 4);
            this.chkMedical.Name = "chkMedical";
            this.chkMedical.Size = new System.Drawing.Size(48, 16);
            this.chkMedical.TabIndex = 1;
            this.chkMedical.Text = "药品";
            this.chkMedical.UseVisualStyleBackColor = true;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.tabControl1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 66);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(974, 470);
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
            this.groupPanel2.TabIndex = 4;
            this.groupPanel2.Text = "医嘱查询";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(968, 446);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.longtab);
            this.tabControl1.Tabs.Add(this.shorttab);
            this.tabControl1.Text = "tabControl1";
            this.tabControl1.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabControl1_SelectedTabChanged);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.ShortDgv);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(968, 420);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.shorttab;
            // 
            // ShortDgv
            // 
            this.ShortDgv.AllowUserToAddRows = false;
            this.ShortDgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ShortDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ShortDgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShortDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.ShortDgv.Location = new System.Drawing.Point(1, 1);
            this.ShortDgv.Name = "ShortDgv";
            this.ShortDgv.RowTemplate.Height = 23;
            this.ShortDgv.Size = new System.Drawing.Size(966, 418);
            this.ShortDgv.TabIndex = 1;
            // 
            // shorttab
            // 
            this.shorttab.AttachedControl = this.tabControlPanel2;
            this.shorttab.Name = "shorttab";
            this.shorttab.Text = "临时医嘱";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.longDgv);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(968, 420);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.longtab;
            // 
            // longDgv
            // 
            this.longDgv.AllowUserToAddRows = false;
            this.longDgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.longDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.longDgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.longDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.longDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.longDgv.Location = new System.Drawing.Point(1, 1);
            this.longDgv.Name = "longDgv";
            this.longDgv.RowTemplate.Height = 23;
            this.longDgv.Size = new System.Drawing.Size(966, 418);
            this.longDgv.TabIndex = 0;
            this.longDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_CellMouseClick);
            // 
            // longtab
            // 
            this.longtab.AttachedControl = this.tabControlPanel1;
            this.longtab.Name = "longtab";
            this.longtab.Text = "长期医嘱";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkAll);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSure);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 536);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(974, 34);
            this.panel3.TabIndex = 5;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(325, 9);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(490, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(409, 5);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 15;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmYZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 570);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZ_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShortDgv)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.longDgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label lblPatient;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkMedical;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX longDgv;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkNoMedical;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem longtab;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem shorttab;
        private DevComponents.DotNetBar.Controls.DataGridViewX ShortDgv;
    }
}