namespace TempertureEditor.Tempreture_Management
{
    partial class ucTemperPrintDataLoad
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
            this.slider1 = new DevComponents.DotNetBar.SliderItem();
            this.ppcPreview = new System.Windows.Forms.PrintPreviewControl();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.btn_next = new DevComponents.DotNetBar.ButtonX();
            this.btn_up = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvTimes = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvTimes)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slider1
            // 
            this.slider1.Maximum = 40;
            this.slider1.Minimum = 1;
            this.slider1.Name = "slider1";
            this.slider1.Text = "缩放";
            this.slider1.Tooltip = "缩放";
            this.slider1.Value = 10;
            this.slider1.Width = 150;
            this.slider1.ValueChanged += new System.EventHandler(this.slider1_ValueChanged);
            // 
            // ppcPreview
            // 
            this.ppcPreview.AutoZoom = false;
            this.ppcPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ppcPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppcPreview.Location = new System.Drawing.Point(0, 0);
            this.ppcPreview.Name = "ppcPreview";
            this.ppcPreview.Size = new System.Drawing.Size(603, 626);
            this.ppcPreview.TabIndex = 1;
            this.ppcPreview.UseAntiAlias = true;
            this.ppcPreview.Zoom = 1D;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.txtIndex);
            this.ribbonBar1.Controls.Add(this.btn_next);
            this.ribbonBar1.Controls.Add(this.btn_up);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrint,
            this.slider1});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(831, 44);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 5;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(392, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "页";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(334, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "第";
            // 
            // txtIndex
            // 
            this.txtIndex.Enabled = false;
            this.txtIndex.Location = new System.Drawing.Point(355, 12);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.ReadOnly = true;
            this.txtIndex.Size = new System.Drawing.Size(34, 21);
            this.txtIndex.TabIndex = 29;
            this.txtIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // btn_next
            // 
            this.btn_next.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_next.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_next.Location = new System.Drawing.Point(414, 10);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 28;
            this.btn_next.Text = "下一页";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_up
            // 
            this.btn_up.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_up.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_up.Location = new System.Drawing.Point(254, 10);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 23);
            this.btn_up.TabIndex = 27;
            this.btn_up.Text = "上一页";
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::TempertureEditor.Properties.Resources.Print1;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.SubItemsExpandWidth = 14;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ppcPreview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(228, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 626);
            this.panel2.TabIndex = 2;
            // 
            // tvTimes
            // 
            this.tvTimes.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvTimes.AllowDrop = true;
            this.tvTimes.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tvTimes.BackgroundStyle.Class = "TreeBorderKey";
            this.tvTimes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTimes.Location = new System.Drawing.Point(0, 0);
            this.tvTimes.Name = "tvTimes";
            this.tvTimes.NodesConnector = this.nodeConnector1;
            this.tvTimes.NodeSpacing = 2;
            this.tvTimes.NodeStyle = this.elementStyle1;
            this.tvTimes.PathSeparator = ";";
            this.tvTimes.Size = new System.Drawing.Size(218, 626);
            this.tvTimes.Styles.Add(this.elementStyle1);
            this.tvTimes.TabIndex = 0;
            this.tvTimes.Text = "advTree1";
            this.tvTimes.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.tvTimes_AfterNodeSelect);
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
            this.elementStyle1.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // expandableSplitter1
            // 
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
            this.expandableSplitter1.Location = new System.Drawing.Point(218, 0);
            this.expandableSplitter1.MinSize = 0;
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 626);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 4;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.tvTimes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 626);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 626);
            this.panel1.TabIndex = 4;
            // 
            // ucTemperPrintDataLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonBar1);
            this.Name = "ucTemperPrintDataLoad";
            this.Size = new System.Drawing.Size(831, 670);
            this.Load += new System.EventHandler(this.ucTemperPrint_Load);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvTimes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SliderItem slider1;
        private System.Windows.Forms.PrintPreviewControl ppcPreview;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.AdvTree.AdvTree tvTimes;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private System.Windows.Forms.TextBox txtIndex;
        private DevComponents.DotNetBar.ButtonX btn_next;
        private DevComponents.DotNetBar.ButtonX btn_up;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
