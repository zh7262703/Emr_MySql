namespace Base_Function.BASE_DATA
{
    partial class FrmECGReport
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvECG = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开心电图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvECG)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvECG
            // 
            this.dgvECG.BackgroundColor = System.Drawing.Color.White;
            this.dgvECG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvECG.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvECG.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvECG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvECG.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvECG.Location = new System.Drawing.Point(0, 0);
            this.dgvECG.Name = "dgvECG";
            this.dgvECG.RowTemplate.Height = 23;
            this.dgvECG.Size = new System.Drawing.Size(803, 276);
            this.dgvECG.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开心电图ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // 打开心电图ToolStripMenuItem
            // 
            this.打开心电图ToolStripMenuItem.Name = "打开心电图ToolStripMenuItem";
            this.打开心电图ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开心电图ToolStripMenuItem.Text = "打开心电图";
            this.打开心电图ToolStripMenuItem.Click += new System.EventHandler(this.打开心电图ToolStripMenuItem_Click);
            // 
            // FrmECGReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 276);
            this.Controls.Add(this.dgvECG);
            this.DoubleBuffered = true;
            this.Name = "FrmECGReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "心电报告";
            this.Load += new System.EventHandler(this.FrmECGReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvECG)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvECG;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开心电图ToolStripMenuItem;
    }
}