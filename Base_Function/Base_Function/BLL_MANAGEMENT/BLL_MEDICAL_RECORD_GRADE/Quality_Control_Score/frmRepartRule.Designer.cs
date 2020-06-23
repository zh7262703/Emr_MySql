namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    partial class frmRepartRule
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
            this.dgvRules = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.AllowUserToResizeColumns = false;
            this.dgvRules.AllowUserToResizeRows = false;
            this.dgvRules.BackgroundColor = System.Drawing.Color.White;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRules.Location = new System.Drawing.Point(0, 0);
            this.dgvRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.ReadOnly = true;
            this.dgvRules.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRules.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRules.RowTemplate.Height = 23;
            this.dgvRules.Size = new System.Drawing.Size(915, 391);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellDoubleClick);
            // 
            // frmRepartRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 391);
            this.Controls.Add(this.dgvRules);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepartRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评分标准";
            this.Load += new System.EventHandler(this.frmRepartRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRules;

    }
}