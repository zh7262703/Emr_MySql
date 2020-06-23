namespace Bifrost
{
    partial class ucPasswordStrongCheck
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
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblPassWordLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(0, 2);
            this.progressBarX1.Maximum = 4;
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(131, 15);
            this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.progressBarX1.TabIndex = 0;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // lblPassWordLevel
            // 
            this.lblPassWordLevel.AutoSize = true;
            this.lblPassWordLevel.Location = new System.Drawing.Point(133, 3);
            this.lblPassWordLevel.Name = "lblPassWordLevel";
            this.lblPassWordLevel.Size = new System.Drawing.Size(18, 12);
            this.lblPassWordLevel.TabIndex = 1;
            this.lblPassWordLevel.Text = "弱";
            // 
            // ucPasswordStrongCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblPassWordLevel);
            this.Controls.Add(this.progressBarX1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "ucPasswordStrongCheck";
            this.Size = new System.Drawing.Size(176, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.Label lblPassWordLevel;

    }
}
