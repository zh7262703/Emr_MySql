namespace Base_Function.BASE_DATA
{
    partial class frmBedInfo
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
            this.txtBedName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBedInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBedInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBedName
            // 
            this.txtBedName.Location = new System.Drawing.Point(53, 17);
            this.txtBedName.Name = "txtBedName";
            this.txtBedName.Size = new System.Drawing.Size(224, 21);
            this.txtBedName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "床位：";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(283, 17);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 15;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.txtBedName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 43);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBedInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 265);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // dgvBedInfo
            // 
            this.dgvBedInfo.AllowUserToAddRows = false;
            this.dgvBedInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvBedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBedInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBedInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBedInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBedInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvBedInfo.Name = "dgvBedInfo";
            this.dgvBedInfo.ReadOnly = true;
            this.dgvBedInfo.RowTemplate.Height = 23;
            this.dgvBedInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBedInfo.Size = new System.Drawing.Size(415, 244);
            this.dgvBedInfo.TabIndex = 28;
            this.dgvBedInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvBedInfo_MouseDoubleClick);
            this.dgvBedInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBedInfo_CellContentClick);
            // 
            // frmBedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 308);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBedInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "床位信息";
            this.Load += new System.EventHandler(this.frmBedInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBedInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBedName;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBedInfo;
    }
}