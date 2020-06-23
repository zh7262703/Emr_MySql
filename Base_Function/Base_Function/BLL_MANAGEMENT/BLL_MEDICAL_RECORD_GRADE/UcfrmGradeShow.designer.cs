namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class UcfrmGradeShow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSource = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRef = new DevComponents.DotNetBar.ButtonX();
            this.btnQRXG = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSource);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 418);
            this.panel1.TabIndex = 0;
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSource.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSource.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSource.Location = new System.Drawing.Point(0, 0);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowHeadersVisible = false;
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.Size = new System.Drawing.Size(424, 418);
            this.dgvSource.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "评分项目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "扣分值";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "扣分标准";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 160;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "扣分理由";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "项目ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "是否修改";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "绿色内容表示已修改，其他颜色（含底纹）内容表示未修改";
            // 
            // btnRef
            // 
            this.btnRef.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRef.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRef.Location = new System.Drawing.Point(178, 36);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(75, 23);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "刷新";
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // btnQRXG
            // 
            this.btnQRXG.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQRXG.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQRXG.Location = new System.Drawing.Point(266, 36);
            this.btnQRXG.Name = "btnQRXG";
            this.btnQRXG.Size = new System.Drawing.Size(87, 23);
            this.btnQRXG.TabIndex = 3;
            this.btnQRXG.Text = "确认修改";
            this.btnQRXG.Click += new System.EventHandler(this.btnQRXG_Click);
            // 
            // UcfrmGradeShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(428, 452);
            this.Controls.Add(this.btnQRXG);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UcfrmGradeShow";
            this.Load += new System.EventHandler(this.UcfrmGradeShow_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnRef;
        private DevComponents.DotNetBar.ButtonX btnQRXG;

    }
}
