namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    partial class frmApply_DocReturn_Record_Rooms
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
            this.ucApply_DocReturn_Record_Room1 = new UcApply_DocReturn_Record_Room();
            this.SuspendLayout();
            // 
            // ucApply_Medical_Record_Room1
            // 
            this.ucApply_DocReturn_Record_Room1.BackColor = System.Drawing.Color.Transparent;
            this.ucApply_DocReturn_Record_Room1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucApply_DocReturn_Record_Room1.Location = new System.Drawing.Point(0, 0);
            this.ucApply_DocReturn_Record_Room1.Name = "ucApply_Medical_Record_Room1";
            this.ucApply_DocReturn_Record_Room1.Size = new System.Drawing.Size(847, 597);
            this.ucApply_DocReturn_Record_Room1.TabIndex = 0;
            // 
            // frmApply_Medical_Record_Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 597);
            this.Controls.Add(this.ucApply_DocReturn_Record_Room1);
            this.Name = "frmApply_Medical_Record_Rooms";
            this.ShowIcon = false;
            this.Text = "归档病历修改申请";
            this.ResumeLayout(false);

        }

        #endregion

        private UcApply_DocReturn_Record_Room ucApply_DocReturn_Record_Room1;
    }
}