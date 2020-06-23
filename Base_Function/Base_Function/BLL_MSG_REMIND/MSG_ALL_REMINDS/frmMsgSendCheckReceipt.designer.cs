namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    partial class frmMsgSendCheckReceipt
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
            this.dgvMsg = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMsg
            // 
            this.dgvMsg.AllowUserToAddRows = false;
            this.dgvMsg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMsg.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMsg.Location = new System.Drawing.Point(0, 0);
            this.dgvMsg.Name = "dgvMsg";
            this.dgvMsg.ReadOnly = true;
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.Size = new System.Drawing.Size(846, 484);
            this.dgvMsg.TabIndex = 1;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "id";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "收条";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "消息类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "标题";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "内容";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "编辑人";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "发送时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "接收对象";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "发布状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // frmMsgSendCheckReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 484);
            this.Controls.Add(this.dgvMsg);
            this.DoubleBuffered = true;
            this.Name = "frmMsgSendCheckReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看收条功能";
            this.Load += new System.EventHandler(this.frmMsgSendCheckReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}