namespace Base_Function.BLL_FOLLOW.DispalayList
{
    partial class ucFollowDieList
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnLast = new DevComponents.DotNetBar.ButtonX();
            this.btnRear = new DevComponents.DotNetBar.ButtonX();
            this.btnFirst = new DevComponents.DotNetBar.ButtonX();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.cmbEach = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.取消死亡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.诊断信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCurrent = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ckbFollowTime = new System.Windows.Forms.CheckBox();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFollowInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(761, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "条纪录";
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLast.Location = new System.Drawing.Point(876, 21);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(44, 20);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = ">>";
            // 
            // btnRear
            // 
            this.btnRear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRear.Location = new System.Drawing.Point(808, 21);
            this.btnRear.Name = "btnRear";
            this.btnRear.Size = new System.Drawing.Size(44, 20);
            this.btnRear.TabIndex = 6;
            this.btnRear.Text = ">";
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirst.Location = new System.Drawing.Point(377, 21);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(44, 20);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "<<";
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre.Location = new System.Drawing.Point(453, 21);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(44, 20);
            this.btnPre.TabIndex = 4;
            this.btnPre.Text = "<";
            // 
            // cmbEach
            // 
            this.cmbEach.DisplayMember = "Text";
            this.cmbEach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEach.FormattingEnabled = true;
            this.cmbEach.ItemHeight = 15;
            this.cmbEach.Location = new System.Drawing.Point(682, 21);
            this.cmbEach.Name = "cmbEach";
            this.cmbEach.Size = new System.Drawing.Size(73, 21);
            this.cmbEach.TabIndex = 3;
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
            this.dgvPatients.Size = new System.Drawing.Size(1322, 532);
            this.dgvPatients.TabIndex = 0;
            this.dgvPatients.DoubleClick += new System.EventHandler(this.dgvPatients_DoubleClick);
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消死亡ToolStripMenuItem,
            this.患者基本信息ToolStripMenuItem,
            this.诊断信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // 取消死亡ToolStripMenuItem
            // 
            this.取消死亡ToolStripMenuItem.Name = "取消死亡ToolStripMenuItem";
            this.取消死亡ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消死亡ToolStripMenuItem.Text = "取消死亡";
            this.取消死亡ToolStripMenuItem.Click += new System.EventHandler(this.取消死亡ToolStripMenuItem_Click);
            // 
            // 患者基本信息ToolStripMenuItem
            // 
            this.患者基本信息ToolStripMenuItem.Name = "患者基本信息ToolStripMenuItem";
            this.患者基本信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.患者基本信息ToolStripMenuItem.Text = "患者基本信息";
            this.患者基本信息ToolStripMenuItem.Click += new System.EventHandler(this.患者基本信息ToolStripMenuItem_Click);
            // 
            // 诊断信息ToolStripMenuItem
            // 
            this.诊断信息ToolStripMenuItem.Name = "诊断信息ToolStripMenuItem";
            this.诊断信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.诊断信息ToolStripMenuItem.Text = "诊断信息";
            this.诊断信息ToolStripMenuItem.Click += new System.EventHandler(this.诊断信息ToolStripMenuItem_Click);
            // 
            // cmbCurrent
            // 
            this.cmbCurrent.DisplayMember = "Text";
            this.cmbCurrent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrent.FormattingEnabled = true;
            this.cmbCurrent.ItemHeight = 15;
            this.cmbCurrent.Location = new System.Drawing.Point(562, 21);
            this.cmbCurrent.Name = "cmbCurrent";
            this.cmbCurrent.Size = new System.Drawing.Size(66, 21);
            this.cmbCurrent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "每页：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前页：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnRear);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.cmbEach);
            this.panel1.Controls.Add(this.cmbCurrent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 580);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 58);
            this.panel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPatients);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1328, 552);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiag);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ckbFollowTime);
            this.groupBox1.Controls.Add(this.dtEndTime);
            this.groupBox1.Controls.Add(this.dtStartTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFollowInfo);
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHospital);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPatient);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1328, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // txtDiag
            // 
            this.txtDiag.Location = new System.Drawing.Point(693, 59);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(121, 21);
            this.txtDiag.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(646, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 33;
            this.label12.Text = "诊断：";
            // 
            // ckbFollowTime
            // 
            this.ckbFollowTime.AutoSize = true;
            this.ckbFollowTime.Location = new System.Drawing.Point(222, 62);
            this.ckbFollowTime.Name = "ckbFollowTime";
            this.ckbFollowTime.Size = new System.Drawing.Size(72, 16);
            this.ckbFollowTime.TabIndex = 32;
            this.ckbFollowTime.Text = "随访时间";
            this.ckbFollowTime.UseVisualStyleBackColor = true;
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(444, 59);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(121, 21);
            this.dtEndTime.TabIndex = 31;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(300, 59);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(121, 21);
            this.dtStartTime.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "-";
            // 
            // cmbFollowInfo
            // 
            this.cmbFollowInfo.DisplayMember = "Text";
            this.cmbFollowInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFollowInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowInfo.FormattingEnabled = true;
            this.cmbFollowInfo.ItemHeight = 15;
            this.cmbFollowInfo.Location = new System.Drawing.Point(683, 20);
            this.cmbFollowInfo.Name = "cmbFollowInfo";
            this.cmbFollowInfo.Size = new System.Drawing.Size(234, 21);
            this.cmbFollowInfo.TabIndex = 21;
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Text";
            this.cmbSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.ItemHeight = 15;
            this.cmbSection.Location = new System.Drawing.Point(79, 59);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(121, 21);
            this.cmbSection.TabIndex = 20;
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(498, 20);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 21);
            this.txtDoctor.TabIndex = 19;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(972, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(622, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "随访方案：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "科室：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "管床医生：";
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(284, 20);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "住院号：";
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(79, 20);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(100, 21);
            this.txtPatient.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "病人姓名：";
            // 
            // ucFollowDieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucFollowDieList";
            this.Size = new System.Drawing.Size(1328, 638);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnLast;
        private DevComponents.DotNetBar.ButtonX btnRear;
        private DevComponents.DotNetBar.ButtonX btnFirst;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEach;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatients;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCurrent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFollowInfo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSection;
        private System.Windows.Forms.TextBox txtDoctor;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckbFollowTime;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 取消死亡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者基本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 诊断信息ToolStripMenuItem;
    }
}
