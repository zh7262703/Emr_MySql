namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class Col_FilePicShow
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
            this.fileShow_PicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileShow_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileShow_PicBox
            // 
            this.fileShow_PicBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.fileShow_PicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileShow_PicBox.Location = new System.Drawing.Point(0, 0);
            this.fileShow_PicBox.Name = "fileShow_PicBox";
            this.fileShow_PicBox.Size = new System.Drawing.Size(707, 452);
            this.fileShow_PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fileShow_PicBox.TabIndex = 0;
            this.fileShow_PicBox.TabStop = false;
            this.fileShow_PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileShow_PicBox_MouseDown);
            // 
            // Col_FilePicShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.fileShow_PicBox);
            this.Name = "Col_FilePicShow";
            this.Size = new System.Drawing.Size(707, 452);
            this.Load += new System.EventHandler(this.FilePicShow_UserCol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileShow_PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox fileShow_PicBox;
    }
}
