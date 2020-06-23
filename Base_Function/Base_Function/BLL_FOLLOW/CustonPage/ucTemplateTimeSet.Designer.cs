namespace Base_Function.BLL_FOLLOW.CustonPage
{
    partial class ucTemplateTimeSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAttach = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpNextTimeSet = new System.Windows.Forms.GroupBox();
            this.btnNextCancel = new System.Windows.Forms.Button();
            this.btnSaveNext = new System.Windows.Forms.Button();
            this.dtNextTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnSetting = new System.Windows.Forms.RadioButton();
            this.rbtnOrigin = new System.Windows.Forms.RadioButton();
            this.rbtnThisTime = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnNotEnd = new System.Windows.Forms.RadioButton();
            this.rbtnEnd = new System.Windows.Forms.RadioButton();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttach)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpNextTimeSet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAttach);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "随访数据设置记录";
            // 
            // dgvAttach
            // 
            this.dgvAttach.AllowUserToAddRows = false;
            this.dgvAttach.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttach.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvAttach.Location = new System.Drawing.Point(3, 17);
            this.dgvAttach.Name = "dgvAttach";
            this.dgvAttach.RowTemplate.Height = 23;
            this.dgvAttach.Size = new System.Drawing.Size(696, 304);
            this.dgvAttach.TabIndex = 0;
            this.dgvAttach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttach_CellClick);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpNextTimeSet);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 317);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // grpNextTimeSet
            // 
            this.grpNextTimeSet.Controls.Add(this.btnNextCancel);
            this.grpNextTimeSet.Controls.Add(this.btnSaveNext);
            this.grpNextTimeSet.Controls.Add(this.dtNextTime);
            this.grpNextTimeSet.Controls.Add(this.label4);
            this.grpNextTimeSet.Controls.Add(this.panel1);
            this.grpNextTimeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNextTimeSet.Location = new System.Drawing.Point(3, 160);
            this.grpNextTimeSet.Name = "grpNextTimeSet";
            this.grpNextTimeSet.Size = new System.Drawing.Size(696, 154);
            this.grpNextTimeSet.TabIndex = 23;
            this.grpNextTimeSet.TabStop = false;
            this.grpNextTimeSet.Text = "下次随访时间的设定";
            // 
            // btnNextCancel
            // 
            this.btnNextCancel.Location = new System.Drawing.Point(306, 100);
            this.btnNextCancel.Name = "btnNextCancel";
            this.btnNextCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNextCancel.TabIndex = 22;
            this.btnNextCancel.Text = "取消";
            this.btnNextCancel.UseVisualStyleBackColor = true;
            this.btnNextCancel.Click += new System.EventHandler(this.btnNextCancel_Click);
            // 
            // btnSaveNext
            // 
            this.btnSaveNext.Location = new System.Drawing.Point(219, 100);
            this.btnSaveNext.Name = "btnSaveNext";
            this.btnSaveNext.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNext.TabIndex = 21;
            this.btnSaveNext.Text = "保存";
            this.btnSaveNext.UseVisualStyleBackColor = true;
            this.btnSaveNext.Click += new System.EventHandler(this.btnSaveNext_Click);
            // 
            // dtNextTime
            // 
            this.dtNextTime.Location = new System.Drawing.Point(153, 54);
            this.dtNextTime.Name = "dtNextTime";
            this.dtNextTime.Size = new System.Drawing.Size(135, 21);
            this.dtNextTime.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "下次随访时间：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnSetting);
            this.panel1.Controls.Add(this.rbtnOrigin);
            this.panel1.Controls.Add(this.rbtnThisTime);
            this.panel1.Location = new System.Drawing.Point(323, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 27);
            this.panel1.TabIndex = 7;
            // 
            // rbtnSetting
            // 
            this.rbtnSetting.AutoSize = true;
            this.rbtnSetting.Checked = true;
            this.rbtnSetting.Location = new System.Drawing.Point(225, 4);
            this.rbtnSetting.Name = "rbtnSetting";
            this.rbtnSetting.Size = new System.Drawing.Size(119, 16);
            this.rbtnSetting.TabIndex = 2;
            this.rbtnSetting.TabStop = true;
            this.rbtnSetting.Text = "根据设定时间循环";
            this.rbtnSetting.UseVisualStyleBackColor = true;
            this.rbtnSetting.CheckedChanged += new System.EventHandler(this.rbtnSetting_CheckedChanged);
            // 
            // rbtnOrigin
            // 
            this.rbtnOrigin.AutoSize = true;
            this.rbtnOrigin.Location = new System.Drawing.Point(119, 4);
            this.rbtnOrigin.Name = "rbtnOrigin";
            this.rbtnOrigin.Size = new System.Drawing.Size(107, 16);
            this.rbtnOrigin.TabIndex = 1;
            this.rbtnOrigin.Text = "根据原方案循环";
            this.rbtnOrigin.UseVisualStyleBackColor = true;
            this.rbtnOrigin.CheckedChanged += new System.EventHandler(this.rbtnOrigin_CheckedChanged);
            // 
            // rbtnThisTime
            // 
            this.rbtnThisTime.AutoSize = true;
            this.rbtnThisTime.Location = new System.Drawing.Point(4, 4);
            this.rbtnThisTime.Name = "rbtnThisTime";
            this.rbtnThisTime.Size = new System.Drawing.Size(119, 16);
            this.rbtnThisTime.TabIndex = 0;
            this.rbtnThisTime.Text = "根据本次随访循环";
            this.rbtnThisTime.UseVisualStyleBackColor = true;
            this.rbtnThisTime.CheckedChanged += new System.EventHandler(this.rbtnThisTime_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.dtTime);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.txtUser);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.txtRemark);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.cmbState);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 143);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "随访完成时间";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnNotEnd);
            this.panel2.Controls.Add(this.rbtnEnd);
            this.panel2.Location = new System.Drawing.Point(94, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 23);
            this.panel2.TabIndex = 22;
            // 
            // rbtnNotEnd
            // 
            this.rbtnNotEnd.AutoSize = true;
            this.rbtnNotEnd.Location = new System.Drawing.Point(99, 3);
            this.rbtnNotEnd.Name = "rbtnNotEnd";
            this.rbtnNotEnd.Size = new System.Drawing.Size(83, 16);
            this.rbtnNotEnd.TabIndex = 1;
            this.rbtnNotEnd.Text = "随访未结束";
            this.rbtnNotEnd.UseVisualStyleBackColor = true;
            // 
            // rbtnEnd
            // 
            this.rbtnEnd.AutoSize = true;
            this.rbtnEnd.Checked = true;
            this.rbtnEnd.Location = new System.Drawing.Point(3, 3);
            this.rbtnEnd.Name = "rbtnEnd";
            this.rbtnEnd.Size = new System.Drawing.Size(71, 16);
            this.rbtnEnd.TabIndex = 0;
            this.rbtnEnd.TabStop = true;
            this.rbtnEnd.Text = "随访结束";
            this.rbtnEnd.UseVisualStyleBackColor = true;
            // 
            // dtTime
            // 
            this.dtTime.Location = new System.Drawing.Point(153, 20);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(135, 21);
            this.dtTime.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "随访时间：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(219, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(416, 20);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 21);
            this.txtUser.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(306, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(416, 59);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(100, 21);
            this.txtRemark.TabIndex = 13;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(128, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "随访状态：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(153, 59);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 20);
            this.cmbState.TabIndex = 9;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "随访者：";
            // 
            // ucTemplateTimeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucTemplateTimeSet";
            this.Size = new System.Drawing.Size(702, 641);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttach)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpNextTimeSet.ResumeLayout(false);
            this.grpNextTimeSet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvAttach;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.RadioButton rbtnSetting;
        private System.Windows.Forms.RadioButton rbtnOrigin;
        private System.Windows.Forms.RadioButton rbtnThisTime;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpNextTimeSet;
        private System.Windows.Forms.DateTimePicker dtNextTime;
        private System.Windows.Forms.Button btnNextCancel;
        private System.Windows.Forms.Button btnSaveNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnNotEnd;
        private System.Windows.Forms.RadioButton rbtnEnd;
    }
}
