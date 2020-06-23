namespace Base_Function.BLL_DOCTOR
{
    partial class frmCreateDocSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkCj = new System.Windows.Forms.CheckBox();
            this.chkbl = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCj
            // 
            this.chkCj.AutoSize = true;
            this.chkCj.Checked = true;
            this.chkCj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCj.Location = new System.Drawing.Point(21, 12);
            this.chkCj.Name = "chkCj";
            this.chkCj.Size = new System.Drawing.Size(72, 16);
            this.chkCj.TabIndex = 0;
            this.chkCj.Text = "创建文书";
            this.chkCj.UseVisualStyleBackColor = true;
            this.chkCj.CheckedChanged += new System.EventHandler(this.chkCj_CheckedChanged);
            // 
            // chkbl
            // 
            this.chkbl.AutoSize = true;
            this.chkbl.Location = new System.Drawing.Point(99, 12);
            this.chkbl.Name = "chkbl";
            this.chkbl.Size = new System.Drawing.Size(72, 16);
            this.chkbl.TabIndex = 1;
            this.chkbl.Text = "补录文书";
            this.chkbl.UseVisualStyleBackColor = true;
            this.chkbl.CheckedChanged += new System.EventHandler(this.chkbl_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewX1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(21, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 210);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "补录时间点设置";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(540, 190);
            this.dataGridViewX1.TabIndex = 2;
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(223, 250);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(69, 32);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(298, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreateDocSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 294);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkbl);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCj);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateDocSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文书创建补录设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateDocSet_FormClosing);
            this.Load += new System.EventHandler(this.frmCreateDocSet_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCj;
        private System.Windows.Forms.CheckBox chkbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}