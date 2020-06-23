namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    partial class frmKouFenDetailsCheck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvKouFenDetails = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnOpen = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKouFenDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvKouFenDetails);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 222);
            this.panel1.TabIndex = 0;
            // 
            // dgvKouFenDetails
            // 
            this.dgvKouFenDetails.AllowUserToAddRows = false;
            this.dgvKouFenDetails.AllowUserToDeleteRows = false;
            this.dgvKouFenDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvKouFenDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKouFenDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKouFenDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKouFenDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvKouFenDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvKouFenDetails.Name = "dgvKouFenDetails";
            this.dgvKouFenDetails.ReadOnly = true;
            this.dgvKouFenDetails.RowTemplate.Height = 23;
            this.dgvKouFenDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKouFenDetails.Size = new System.Drawing.Size(570, 222);
            this.dgvKouFenDetails.TabIndex = 20;
            // 
            // btnOpen
            // 
            this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpen.Location = new System.Drawing.Point(483, 228);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开文书";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmKouFenDetailsCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 262);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panel1);
            this.Name = "frmKouFenDetailsCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扣分详细信息查看";
            this.Load += new System.EventHandler(this.frmKouFenDetailsCheck_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKouFenDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvKouFenDetails;
        private DevComponents.DotNetBar.ButtonX btnOpen;





    }
}