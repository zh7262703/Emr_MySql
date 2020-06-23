namespace Base_Function.BLL_DOCTOR
{
    partial class Frm30Day
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInfo
            // 
            this.dgvInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.Size = new System.Drawing.Size(726, 401);
            this.dgvInfo.TabIndex = 0;
            this.dgvInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm30Day_KeyDown);
            // 
            // Frm30Day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 401);
            this.Controls.Add(this.dgvInfo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Frm30Day";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院30天患者";
            this.TopLeftCornerSize = 0;
            this.TopRightCornerSize = 0;
            this.Load += new System.EventHandler(this.Frm30Day_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm30Day_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvInfo;
    }
}