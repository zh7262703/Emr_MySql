namespace Base_Function.BLL_DOCTOR.UnFinished
{
    partial class ucElementQuality
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDataShow = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataShow
            // 
            this.dgvDataShow.AllowUserToAddRows = false;
            this.dgvDataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDataShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataShow.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDataShow.Location = new System.Drawing.Point(0, 0);
            this.dgvDataShow.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDataShow.Name = "dgvDataShow";
            this.dgvDataShow.ReadOnly = true;
            this.dgvDataShow.RowTemplate.Height = 23;
            this.dgvDataShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataShow.Size = new System.Drawing.Size(845, 503);
            this.dgvDataShow.TabIndex = 8;
            // 
            // ucElementQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDataShow);
            this.Name = "ucElementQuality";
            this.Size = new System.Drawing.Size(845, 503);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDataShow;
    }
}
