namespace TempertureEditor
{
    partial class ucTemperturePrint
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemperturePrint));
            this.ppcPreview = new System.Windows.Forms.PrintPreviewControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ppcPreview
            // 
            this.ppcPreview.AutoZoom = false;
            this.ppcPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ppcPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppcPreview.Location = new System.Drawing.Point(0, 25);
            this.ppcPreview.Name = "ppcPreview";
            this.ppcPreview.Size = new System.Drawing.Size(362, 304);
            this.ppcPreview.TabIndex = 2;
            this.ppcPreview.UseAntiAlias = true;
            this.ppcPreview.Zoom = 1D;
            this.ppcPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.ppcPreview_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(362, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnPrint
            // 
            this.tbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbtnPrint.Image")));
            this.tbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnPrint.Name = "tbtnPrint";
            this.tbtnPrint.Size = new System.Drawing.Size(23, 22);
            this.tbtnPrint.Text = "打印";
            this.tbtnPrint.Click += new System.EventHandler(this.tbtnPrint_Click);
            // 
            // ucTemperturePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ppcPreview);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ucTemperturePrint";
            this.Size = new System.Drawing.Size(362, 329);
            this.Load += new System.EventHandler(this.ucTemperturePrint_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl ppcPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnPrint;
    }
}
