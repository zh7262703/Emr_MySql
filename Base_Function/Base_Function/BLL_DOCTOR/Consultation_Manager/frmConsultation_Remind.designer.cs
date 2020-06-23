namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    partial class frmConsultation_Remind
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
            this.splitContainerBody = new System.Windows.Forms.SplitContainer();
            this.flgGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainerBody.Panel1.SuspendLayout();
            this.splitContainerBody.Panel2.SuspendLayout();
            this.splitContainerBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerBody
            // 
            this.splitContainerBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBody.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBody.Name = "splitContainerBody";
            this.splitContainerBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBody.Panel1
            // 
            this.splitContainerBody.Panel1.Controls.Add(this.flgGrid);
            // 
            // splitContainerBody.Panel2
            // 
            this.splitContainerBody.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerBody.Size = new System.Drawing.Size(893, 328);
            this.splitContainerBody.SplitterDistance = 297;
            this.splitContainerBody.TabIndex = 0;
            // 
            // flgGrid
            // 
            this.flgGrid.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgGrid.Location = new System.Drawing.Point(0, 0);
            this.flgGrid.Name = "flgGrid";
            this.flgGrid.Rows.DefaultSize = 18;
            this.flgGrid.Size = new System.Drawing.Size(893, 297);
            this.flgGrid.TabIndex = 0;
            this.flgGrid.DoubleClick += new System.EventHandler(this.flgGrid_DoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(402, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConsultation_Remind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 328);
            this.Controls.Add(this.splitContainerBody);
            this.MaximizeBox = false;
            this.Name = "frmConsultation_Remind";
            this.ShowIcon = false;
            this.Text = "会诊提醒";
            this.splitContainerBody.Panel1.ResumeLayout(false);
            this.splitContainerBody.Panel2.ResumeLayout(false);
            this.splitContainerBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerBody;
        private C1.Win.C1FlexGrid.C1FlexGrid flgGrid;
        private System.Windows.Forms.Button btnCancel;
    }
}