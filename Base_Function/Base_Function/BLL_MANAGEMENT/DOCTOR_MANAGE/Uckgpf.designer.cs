namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class Uckgpf
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDoctor = new DevComponents.DotNetBar.ButtonX();
            this.btnSecion = new DevComponents.DotNetBar.ButtonX();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.cboSickArea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.chbLeave_Time = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOutStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOutEnd = new System.Windows.Forms.DateTimePicker();
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDoctor);
            this.splitContainer1.Panel1.Controls.Add(this.btnSecion);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.cboSickArea);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txtMax);
            this.splitContainer1.Panel1.Controls.Add(this.txtMin);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtDoctor);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtPatientName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtPid);
            this.splitContainer1.Panel1.Controls.Add(this.chbLeave_Time);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucGridviewX1);
            this.splitContainer1.Size = new System.Drawing.Size(1044, 513);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnDoctor
            // 
            this.btnDoctor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDoctor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDoctor.Location = new System.Drawing.Point(852, 39);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(107, 28);
            this.btnDoctor.TabIndex = 5;
            this.btnDoctor.Text = "导出管床医生报表";
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnSecion
            // 
            this.btnSecion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSecion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSecion.Location = new System.Drawing.Point(724, 35);
            this.btnSecion.Name = "btnSecion";
            this.btnSecion.Size = new System.Drawing.Size(97, 28);
            this.btnSecion.TabIndex = 5;
            this.btnSecion.Text = "导出科室报表";
            this.btnSecion.Click += new System.EventHandler(this.btnSecion_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(628, 35);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(90, 28);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboSickArea
            // 
            this.cboSickArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSickArea.FormattingEnabled = true;
            this.cboSickArea.Location = new System.Drawing.Point(456, 42);
            this.cboSickArea.Name = "cboSickArea";
            this.cboSickArea.Size = new System.Drawing.Size(130, 20);
            this.cboSickArea.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "科室：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(591, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "姓名拼音首字母快捷查询";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(934, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "得分范围0-100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(806, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "≤ 得分 ≤";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(876, 9);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(52, 21);
            this.txtMax.TabIndex = 3;
            this.txtMax.Text = "100";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(750, 8);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(52, 21);
            this.txtMin.TabIndex = 2;
            this.txtMin.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(392, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "管床医生：";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(457, 8);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(128, 21);
            this.txtDoctor.TabIndex = 1;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(209, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "姓名：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(250, 8);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(128, 21);
            this.txtPatientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "住院号：";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(61, 8);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(128, 21);
            this.txtPid.TabIndex = 0;
            // 
            // chbLeave_Time
            // 
            this.chbLeave_Time.AutoSize = true;
            this.chbLeave_Time.Checked = true;
            this.chbLeave_Time.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLeave_Time.Location = new System.Drawing.Point(7, 44);
            this.chbLeave_Time.Name = "chbLeave_Time";
            this.chbLeave_Time.Size = new System.Drawing.Size(15, 14);
            this.chbLeave_Time.TabIndex = 18;
            this.chbLeave_Time.UseVisualStyleBackColor = true;
            this.chbLeave_Time.CheckedChanged += new System.EventHandler(this.chbLeave_Time_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpOutStart);
            this.panel2.Controls.Add(this.dtpOutEnd);
            this.panel2.Location = new System.Drawing.Point(25, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 24);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "出院时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "-";
            // 
            // dtpOutStart
            // 
            this.dtpOutStart.Location = new System.Drawing.Point(70, 2);
            this.dtpOutStart.Name = "dtpOutStart";
            this.dtpOutStart.Size = new System.Drawing.Size(97, 21);
            this.dtpOutStart.TabIndex = 13;
            // 
            // dtpOutEnd
            // 
            this.dtpOutEnd.Location = new System.Drawing.Point(185, 2);
            this.dtpOutEnd.Name = "dtpOutEnd";
            this.dtpOutEnd.Size = new System.Drawing.Size(97, 21);
            this.dtpOutEnd.TabIndex = 13;
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 0);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(1044, 438);
            this.ucGridviewX1.TabIndex = 2;
            // 
            // Uckgpf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Uckgpf";
            this.Size = new System.Drawing.Size(1044, 513);
            this.Load += new System.EventHandler(this.Uckgpf_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Bifrost.ucGridviewX ucGridviewX1;
        private System.Windows.Forms.CheckBox chbLeave_Time;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpOutStart;
        private System.Windows.Forms.DateTimePicker dtpOutEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.ComboBox cboSickArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btnDoctor;
        private DevComponents.DotNetBar.ButtonX btnSecion;

    }
}
