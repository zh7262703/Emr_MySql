namespace Base_Function.BLL_FOLLOW.Element
{
    partial class ucFollowStateSet
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
            this.dgvStateList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvNotEnd = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnToLeft2 = new DevComponents.DotNetBar.ButtonX();
            this.btnToRight2 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvEnd = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnToLeft1 = new DevComponents.DotNetBar.ButtonX();
            this.btnToRight1 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtState = new System.Windows.Forms.TextBox();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotEnd)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnd)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStateList);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1488, 490);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示";
            // 
            // dgvStateList
            // 
            this.dgvStateList.AllowUserToAddRows = false;
            this.dgvStateList.BackgroundColor = System.Drawing.Color.White;
            this.dgvStateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStateList.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStateList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStateList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStateList.Location = new System.Drawing.Point(3, 17);
            this.dgvStateList.Name = "dgvStateList";
            this.dgvStateList.RowTemplate.Height = 23;
            this.dgvStateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStateList.Size = new System.Drawing.Size(764, 470);
            this.dgvStateList.TabIndex = 0;
            this.dgvStateList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStateList_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(767, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 470);
            this.panel1.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.panel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(718, 236);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "未结束随访状态";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvNotEnd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(84, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(631, 216);
            this.panel4.TabIndex = 2;
            // 
            // dgvNotEnd
            // 
            this.dgvNotEnd.AllowUserToAddRows = false;
            this.dgvNotEnd.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotEnd.Location = new System.Drawing.Point(0, 0);
            this.dgvNotEnd.Name = "dgvNotEnd";
            this.dgvNotEnd.RowTemplate.Height = 23;
            this.dgvNotEnd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotEnd.Size = new System.Drawing.Size(631, 216);
            this.dgvNotEnd.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnToLeft2);
            this.panel5.Controls.Add(this.btnToRight2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(81, 216);
            this.panel5.TabIndex = 1;
            // 
            // btnToLeft2
            // 
            this.btnToLeft2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToLeft2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToLeft2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToLeft2.Location = new System.Drawing.Point(16, 117);
            this.btnToLeft2.Name = "btnToLeft2";
            this.btnToLeft2.Size = new System.Drawing.Size(48, 71);
            this.btnToLeft2.TabIndex = 2;
            this.btnToLeft2.Text = "<<";
            this.btnToLeft2.Click += new System.EventHandler(this.btnToLeft2_Click);
            // 
            // btnToRight2
            // 
            this.btnToRight2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToRight2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToRight2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToRight2.Location = new System.Drawing.Point(16, 28);
            this.btnToRight2.Name = "btnToRight2";
            this.btnToRight2.Size = new System.Drawing.Size(48, 71);
            this.btnToRight2.TabIndex = 1;
            this.btnToRight2.Text = ">>";
            this.btnToRight2.Click += new System.EventHandler(this.btnToRight2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(718, 234);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "结束随访状态";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvEnd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(84, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 214);
            this.panel2.TabIndex = 1;
            // 
            // dgvEnd
            // 
            this.dgvEnd.AllowUserToAddRows = false;
            this.dgvEnd.BackgroundColor = System.Drawing.Color.White;
            this.dgvEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEnd.Location = new System.Drawing.Point(0, 0);
            this.dgvEnd.Name = "dgvEnd";
            this.dgvEnd.RowTemplate.Height = 23;
            this.dgvEnd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnd.Size = new System.Drawing.Size(631, 214);
            this.dgvEnd.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnToLeft1);
            this.panel3.Controls.Add(this.btnToRight1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(81, 214);
            this.panel3.TabIndex = 0;
            // 
            // btnToLeft1
            // 
            this.btnToLeft1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToLeft1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToLeft1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToLeft1.Location = new System.Drawing.Point(16, 116);
            this.btnToLeft1.Name = "btnToLeft1";
            this.btnToLeft1.Size = new System.Drawing.Size(48, 71);
            this.btnToLeft1.TabIndex = 1;
            this.btnToLeft1.Text = "<<";
            this.btnToLeft1.Click += new System.EventHandler(this.btnToLeft1_Click);
            // 
            // btnToRight1
            // 
            this.btnToRight1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToRight1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToRight1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToRight1.Location = new System.Drawing.Point(16, 27);
            this.btnToRight1.Name = "btnToRight1";
            this.btnToRight1.Size = new System.Drawing.Size(48, 71);
            this.btnToRight1.TabIndex = 0;
            this.btnToRight1.Text = ">>";
            this.btnToRight1.Click += new System.EventHandler(this.btnToRight1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 490);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1488, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据设置";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(579, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(336, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(146, 51);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 21);
            this.txtState.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(498, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "随访状态:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(417, 51);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ucFollowStateSet
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucFollowStateSet";
            this.Size = new System.Drawing.Size(1488, 595);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotEnd)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnd)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStateList;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private DevComponents.DotNetBar.ButtonX btnToLeft2;
        private DevComponents.DotNetBar.ButtonX btnToRight2;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btnToLeft1;
        private DevComponents.DotNetBar.ButtonX btnToRight1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvNotEnd;
        private System.Windows.Forms.DataGridView dgvEnd;
    }
}
