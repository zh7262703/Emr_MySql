namespace Base_Function.BLL_MANAGEMENT
{
    partial class CellNote
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
            this._txtNote = new System.Windows.Forms.TextBox();
            this._lblShadow = new System.Windows.Forms.Label();
            this._lblGrip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _txtNote
            // 
            this._txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNote.BackColor = System.Drawing.SystemColors.Info;
            this._txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtNote.Location = new System.Drawing.Point(43, 9);
            this._txtNote.Multiline = true;
            this._txtNote.Name = "_txtNote";
            this._txtNote.Size = new System.Drawing.Size(262, 197);
            this._txtNote.TabIndex = 0;
            // 
            // _lblShadow
            // 
            this._lblShadow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lblShadow.BackColor = System.Drawing.Color.DimGray;
            this._lblShadow.Location = new System.Drawing.Point(48, 13);
            this._lblShadow.Name = "_lblShadow";
            this._lblShadow.Size = new System.Drawing.Size(262, 197);
            this._lblShadow.TabIndex = 1;
            // 
            // _lblGrip
            // 
            this._lblGrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblGrip.BackColor = System.Drawing.Color.Black;
            this._lblGrip.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this._lblGrip.Location = new System.Drawing.Point(295, 197);
            this._lblGrip.Name = "_lblGrip";
            this._lblGrip.Size = new System.Drawing.Size(15, 13);
            this._lblGrip.TabIndex = 1;
            this._lblGrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lblGrip_MouseMove);
            this._lblGrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this._lblGrip_MouseDown);
            // 
            // CellNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(314, 215);
            this.Controls.Add(this._txtNote);
            this.Controls.Add(this._lblGrip);
            this.Controls.Add(this._lblShadow);
            this.Name = "CellNote";
            this.Text = "CellNoteForm";
            this.Load += new System.EventHandler(this.CellNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}