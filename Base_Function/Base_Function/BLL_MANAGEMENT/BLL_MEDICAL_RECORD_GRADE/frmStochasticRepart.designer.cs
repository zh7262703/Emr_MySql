namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    partial class frmStochasticRepart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKFXX = new DevComponents.DotNetBar.ButtonX();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.扣分详情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKFXX);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入报表名称";
            // 
            // btnKFXX
            // 
            this.btnKFXX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKFXX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKFXX.Location = new System.Drawing.Point(683, 28);
            this.btnKFXX.Name = "btnKFXX";
            this.btnKFXX.Size = new System.Drawing.Size(86, 23);
            this.btnKFXX.TabIndex = 45;
            this.btnKFXX.Text = "扣分详细";
            this.btnKFXX.Click += new System.EventHandler(this.btnKFXX_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(576, 28);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 23);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "导 出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(466, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "请输入报表名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(188, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 21);
            this.txtName.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 276);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewX1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.ShowEditingIcon = false;
            this.dataGridViewX1.Size = new System.Drawing.Size(831, 276);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.扣分详情ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // 扣分详情ToolStripMenuItem
            // 
            this.扣分详情ToolStripMenuItem.Name = "扣分详情ToolStripMenuItem";
            this.扣分详情ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.扣分详情ToolStripMenuItem.Text = "扣分详情";
            this.扣分详情ToolStripMenuItem.Click += new System.EventHandler(this.扣分详情ToolStripMenuItem_Click);
            // 
            // frmStochasticRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 353);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmStochasticRepart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机报表的生成";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStochasticRepart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 扣分详情ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnKFXX;
    }
}