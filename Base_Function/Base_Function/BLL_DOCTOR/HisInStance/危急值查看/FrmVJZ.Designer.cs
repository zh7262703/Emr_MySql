namespace Base_Function.BLL_DOCTOR.HisInStance.危急值查看
{
    partial class FrmVJZ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvBLVJZ = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnBL = new DevComponents.DotNetBar.ButtonX();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvPacsVJZ = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPacs = new DevComponents.DotNetBar.ButtonX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvLisVJZ = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnLis = new DevComponents.DotNetBar.ButtonX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBLVJZ)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacsVJZ)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLisVJZ)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 337);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.dgvBLVJZ);
            this.tabControlPanel3.Controls.Add(this.groupPanel3);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(797, 312);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // dgvBLVJZ
            // 
            this.dgvBLVJZ.AllowUserToAddRows = false;
            this.dgvBLVJZ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBLVJZ.BackgroundColor = System.Drawing.Color.White;
            this.dgvBLVJZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBLVJZ.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBLVJZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBLVJZ.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBLVJZ.Location = new System.Drawing.Point(1, 1);
            this.dgvBLVJZ.Name = "dgvBLVJZ";
            this.dgvBLVJZ.ReadOnly = true;
            this.dgvBLVJZ.RowTemplate.Height = 23;
            this.dgvBLVJZ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBLVJZ.Size = new System.Drawing.Size(795, 281);
            this.dgvBLVJZ.TabIndex = 5;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnBL);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(1, 282);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(795, 29);
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
            this.groupPanel3.TabIndex = 4;
            // 
            // btnBL
            // 
            this.btnBL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBL.Location = new System.Drawing.Point(659, 0);
            this.btnBL.Name = "btnBL";
            this.btnBL.Size = new System.Drawing.Size(75, 23);
            this.btnBL.TabIndex = 0;
            this.btnBL.Text = "确认";
            this.btnBL.Click += new System.EventHandler(this.btnBL_Click);
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "病理";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvPacsVJZ);
            this.tabControlPanel1.Controls.Add(this.groupPanel1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(797, 312);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // dgvPacsVJZ
            // 
            this.dgvPacsVJZ.AllowUserToAddRows = false;
            this.dgvPacsVJZ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPacsVJZ.BackgroundColor = System.Drawing.Color.White;
            this.dgvPacsVJZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPacsVJZ.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPacsVJZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacsVJZ.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPacsVJZ.Location = new System.Drawing.Point(1, 1);
            this.dgvPacsVJZ.Name = "dgvPacsVJZ";
            this.dgvPacsVJZ.ReadOnly = true;
            this.dgvPacsVJZ.RowTemplate.Height = 23;
            this.dgvPacsVJZ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacsVJZ.Size = new System.Drawing.Size(795, 281);
            this.dgvPacsVJZ.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPacs);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(1, 282);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(795, 29);
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
            this.groupPanel1.TabIndex = 2;
            // 
            // btnPacs
            // 
            this.btnPacs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPacs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPacs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPacs.Location = new System.Drawing.Point(700, 0);
            this.btnPacs.Name = "btnPacs";
            this.btnPacs.Size = new System.Drawing.Size(75, 23);
            this.btnPacs.TabIndex = 0;
            this.btnPacs.Text = "确认";
            this.btnPacs.Click += new System.EventHandler(this.btnPacs_Click);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Pacs";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvLisVJZ);
            this.tabControlPanel2.Controls.Add(this.groupPanel2);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(797, 312);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // dgvLisVJZ
            // 
            this.dgvLisVJZ.AllowUserToAddRows = false;
            this.dgvLisVJZ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLisVJZ.BackgroundColor = System.Drawing.Color.White;
            this.dgvLisVJZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLisVJZ.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLisVJZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLisVJZ.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLisVJZ.Location = new System.Drawing.Point(1, 1);
            this.dgvLisVJZ.Name = "dgvLisVJZ";
            this.dgvLisVJZ.ReadOnly = true;
            this.dgvLisVJZ.RowTemplate.Height = 23;
            this.dgvLisVJZ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLisVJZ.Size = new System.Drawing.Size(795, 281);
            this.dgvLisVJZ.TabIndex = 4;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnLis);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel2.Location = new System.Drawing.Point(1, 282);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(795, 29);
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
            this.groupPanel2.TabIndex = 3;
            // 
            // btnLis
            // 
            this.btnLis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLis.Location = new System.Drawing.Point(659, 0);
            this.btnLis.Name = "btnLis";
            this.btnLis.Size = new System.Drawing.Size(75, 23);
            this.btnLis.TabIndex = 0;
            this.btnLis.Text = "确认";
            this.btnLis.Click += new System.EventHandler(this.btnLis_Click);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Lis";
            // 
            // FrmVJZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 337);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FrmVJZ";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "危急值查看";
            this.Load += new System.EventHandler(this.FrmVJZ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBLVJZ)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacsVJZ)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLisVJZ)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvLisVJZ;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnLis;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPacsVJZ;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnPacs;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBLVJZ;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnBL;
        private DevComponents.DotNetBar.TabItem tabItem3;
    }
}