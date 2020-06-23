namespace Base_Function.BLL_FOLLOW.Element
{
    partial class ucElement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucElement));
            this.showContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showContent
            // 
            this.showContent.AutoSize = true;
            this.showContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showContent.Location = new System.Drawing.Point(0, 0);
            this.showContent.Name = "showContent";
            this.showContent.Size = new System.Drawing.Size(0, 12);
            this.showContent.TabIndex = 0;
            this.showContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showContent.DoubleClick += new System.EventHandler(this.showContent_DoubleClick);
            // 
            // ucElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.showContent);
            this.Name = "ucElement";
            this.Size = new System.Drawing.Size(105, 33);
            this.DoubleClick += new System.EventHandler(this.showContent_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label showContent;

    }
}
