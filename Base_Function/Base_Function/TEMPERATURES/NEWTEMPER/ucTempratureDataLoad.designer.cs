namespace Base_Function.TEMPERATURES
{
    partial class ucTempratureDataLoad
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dsReportSource1 = new Base_Function.REPORT_DATASET.DsReportSource();
            this.panel2 = new System.Windows.Forms.Panel();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.btn_next = new DevComponents.DotNetBar.ButtonX();
            this.btn_up = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(16, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 334);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // dsReportSource1
            // 
            this.dsReportSource1.DataSetName = "DsReportSource";
            this.dsReportSource1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.expandableSplitter1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 744);
            this.panel2.TabIndex = 9;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panel3;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(481, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 744);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 0;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 744);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(481, 705);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.cboTime);
            this.panel6.Controls.Add(this.btn_next);
            this.panel6.Controls.Add(this.btn_up);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(481, 39);
            this.panel6.TabIndex = 8;
            // 
            // cboTime
            // 
            this.cboTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Location = new System.Drawing.Point(140, 9);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(200, 20);
            this.cboTime.TabIndex = 34;
            this.cboTime.SelectedIndexChanged += new System.EventHandler(this.cboTime_SelectedIndexChanged);
            // 
            // btn_next
            // 
            this.btn_next.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_next.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_next.Location = new System.Drawing.Point(346, 9);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(23, 20);
            this.btn_next.TabIndex = 33;
            this.btn_next.Text = "〉";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_up
            // 
            this.btn_up.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_up.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_up.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_up.Location = new System.Drawing.Point(111, 9);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(23, 20);
            this.btn_up.TabIndex = 32;
            this.btn_up.Text = "〈";
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(481, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(557, 744);
            this.panel4.TabIndex = 1;
            // 
            // ucTempratureDataLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "ucTempratureDataLoad";
            this.Size = new System.Drawing.Size(1038, 744);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Base_Function.REPORT_DATASET.DsReportSource dsReportSource1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.DotNetBar.ButtonX btn_next;
        private DevComponents.DotNetBar.ButtonX btn_up;
        private System.Windows.Forms.ComboBox cboTime;
    }
}
