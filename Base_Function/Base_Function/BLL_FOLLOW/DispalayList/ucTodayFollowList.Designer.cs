namespace Base_Function.BLL_FOLLOW.DispalayList
{
    partial class ucTodayFollowList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFollowInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.患者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.诊断信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFollowInfo);
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHospital);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1141, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // cmbFollowInfo
            // 
            this.cmbFollowInfo.DisplayMember = "Text";
            this.cmbFollowInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFollowInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowInfo.FormattingEnabled = true;
            this.cmbFollowInfo.ItemHeight = 15;
            this.cmbFollowInfo.Location = new System.Drawing.Point(746, 35);
            this.cmbFollowInfo.Name = "cmbFollowInfo";
            this.cmbFollowInfo.Size = new System.Drawing.Size(234, 21);
            this.cmbFollowInfo.TabIndex = 10;
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Text";
            this.cmbSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.ItemHeight = 15;
            this.cmbSection.Location = new System.Drawing.Point(558, 35);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(121, 21);
            this.cmbSection.TabIndex = 9;
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(400, 35);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 21);
            this.txtDoctor.TabIndex = 8;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(1012, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(685, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "随访方案：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "科室：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "管床医生：";
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(223, 35);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "住院号：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(68, 35);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(100, 21);
            this.txtPatientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPatients);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1141, 540);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人列表";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatients.Location = new System.Drawing.Point(3, 17);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowTemplate.Height = 23;
            this.dgvPatients.Size = new System.Drawing.Size(1135, 520);
            this.dgvPatients.TabIndex = 0;
            this.dgvPatients.DoubleClick += new System.EventHandler(this.dgvPatients_DoubleClick);
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.患者信息ToolStripMenuItem,
            this.诊断信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 患者信息ToolStripMenuItem
            // 
            this.患者信息ToolStripMenuItem.Name = "患者信息ToolStripMenuItem";
            this.患者信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.患者信息ToolStripMenuItem.Text = "患者信息";
            this.患者信息ToolStripMenuItem.Click += new System.EventHandler(this.患者信息ToolStripMenuItem_Click);
            // 
            // 诊断信息ToolStripMenuItem
            // 
            this.诊断信息ToolStripMenuItem.Name = "诊断信息ToolStripMenuItem";
            this.诊断信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.诊断信息ToolStripMenuItem.Text = "诊断信息";
            this.诊断信息ToolStripMenuItem.Click += new System.EventHandler(this.诊断信息ToolStripMenuItem_Click);
            // 
            // ucTodayFollowList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucTodayFollowList";
            this.Size = new System.Drawing.Size(1141, 628);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatients;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoctor;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFollowInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 患者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 诊断信息ToolStripMenuItem;




    }
}
