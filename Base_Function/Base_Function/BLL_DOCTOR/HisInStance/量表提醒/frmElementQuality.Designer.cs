namespace Base_Function.BLL_DOCTOR.HisInStance.量表提醒
{
    partial class frmElementQuality
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
            this.dgvDataShow = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.dgvDataShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDataShow.Location = new System.Drawing.Point(0, 0);
            this.dgvDataShow.Name = "dgvDataShow";
            this.dgvDataShow.ReadOnly = true;
            this.dgvDataShow.RowTemplate.Height = 23;
            this.dgvDataShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataShow.Size = new System.Drawing.Size(633, 295);
            this.dgvDataShow.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 73);
            this.panel2.TabIndex = 8;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(279, 25);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmElementQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 374);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDataShow);
            this.DoubleBuffered = true;
            this.Name = "frmElementQuality";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "量表提醒";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataShow)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDataShow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOk;
    }
}