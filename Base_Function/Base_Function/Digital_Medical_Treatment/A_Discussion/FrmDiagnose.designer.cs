namespace Digital_Medical_Treatment.A_Discussion
{
    partial class FrmDiagnose
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvSource = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.xz = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zdbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zdmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iszyzd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTQ = new DevComponents.DotNetBar.ButtonX();
            this.btnMoveUp = new DevComponents.DotNetBar.ButtonX();
            this.btnMoveDown = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvSource);
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(536, 203);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xz,
            this.zdbm,
            this.zdmc,
            this.iszyzd});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSource.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSource.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSource.Location = new System.Drawing.Point(0, 0);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowHeadersVisible = false;
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.Size = new System.Drawing.Size(530, 197);
            this.dgvSource.TabIndex = 1;
            // 
            // xz
            // 
            this.xz.HeaderText = "请选择";
            this.xz.Name = "xz";
            this.xz.Width = 50;
            // 
            // zdbm
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.zdbm.DefaultCellStyle = dataGridViewCellStyle2;
            this.zdbm.HeaderText = "诊断编码";
            this.zdbm.Name = "zdbm";
            this.zdbm.ReadOnly = true;
            // 
            // zdmc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.zdmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.zdmc.HeaderText = "诊断名称";
            this.zdmc.Name = "zdmc";
            this.zdmc.ReadOnly = true;
            this.zdmc.Width = 260;
            // 
            // iszyzd
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.iszyzd.DefaultCellStyle = dataGridViewCellStyle4;
            this.iszyzd.HeaderText = "是否中医诊断";
            this.iszyzd.Name = "iszyzd";
            this.iszyzd.ReadOnly = true;
            // 
            // btnTQ
            // 
            this.btnTQ.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTQ.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTQ.Location = new System.Drawing.Point(58, 221);
            this.btnTQ.Name = "btnTQ";
            this.btnTQ.Size = new System.Drawing.Size(75, 23);
            this.btnTQ.TabIndex = 1;
            this.btnTQ.Text = "提取";
            this.btnTQ.Click += new System.EventHandler(this.btnTQ_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMoveUp.Location = new System.Drawing.Point(200, 221);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMoveDown.Location = new System.Drawing.Point(342, 221);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // FrmDiagnose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 261);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnTQ);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDiagnose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "诊断显示";
            this.Load += new System.EventHandler(this.FrmDiagnose_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSource;
        private DevComponents.DotNetBar.ButtonX btnTQ;
        private DevComponents.DotNetBar.ButtonX btnMoveUp;
        private DevComponents.DotNetBar.ButtonX btnMoveDown;
        private System.Windows.Forms.DataGridViewCheckBoxColumn xz;
        private System.Windows.Forms.DataGridViewTextBoxColumn zdbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn zdmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn iszyzd;

    }
}