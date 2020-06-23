namespace Base_Function.TEMPERATURES
{
    partial class ucTemperPrint
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
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvTimes = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvTimes)).BeginInit();
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
            this.ppcPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ppcPreview.Name = "ppcPreview";
            this.ppcPreview.Size = new System.Drawing.Size(670, 902);
            this.ppcPreview.TabIndex = 1;
            this.ppcPreview.UseAntiAlias = true;
            this.ppcPreview.Zoom = 1;
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
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPrint,
            this.slider1});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(969, 47);
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
            // btnPrint
            // 
            this.btnPrint.Image = global::Base_Function.Resource.Print1;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.SubItemsExpandWidth = 14;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ppcPreview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(299, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 902);
            this.panel2.TabIndex = 2;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(287, 0);
            this.expandableSplitter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.expandableSplitter1.MinSize = 0;
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(12, 902);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 4;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvTimes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 902);
            this.panel3.TabIndex = 3;
            // 
            // tvTimes
            // 
            this.tvTimes.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvTimes.AllowDrop = true;
            this.tvTimes.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tvTimes.BackgroundStyle.Class = "TreeBorderKey";
            this.tvTimes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTimes.Location = new System.Drawing.Point(0, 0);
            this.tvTimes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvTimes.Name = "tvTimes";
            this.tvTimes.NodesConnector = this.nodeConnector1;
            this.tvTimes.NodeSpacing = 2;
            this.tvTimes.NodeStyle = this.elementStyle1;
            this.tvTimes.PathSeparator = ";";
            this.tvTimes.Size = new System.Drawing.Size(287, 902);
            this.tvTimes.Styles.Add(this.elementStyle1);
            this.tvTimes.TabIndex = 0;
            this.tvTimes.Text = "advTree1";
            this.tvTimes.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.tvTimes_AfterNodeSelect);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 902);
            this.panel1.TabIndex = 4;
            // 
            // ucTemperPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonBar1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucTemperPrint";
            this.Size = new System.Drawing.Size(969, 949);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvTimes)).EndInit();
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
    }
}
