namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class Section_HeadEmpowerment
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstSetionName = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btntakeBack = new DevComponents.DotNetBar.ButtonX();
            this.btnImpower = new DevComponents.DotNetBar.ButtonX();
            this.cboSetionName = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSetionName = new System.Windows.Forms.Label();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lstSetionName);
            this.panel3.Controls.Add(this.txtBox);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.cboSetionName);
            this.panel3.Location = new System.Drawing.Point(-1, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 109);
            this.panel3.TabIndex = 8;
            // 
            // lstSetionName
            // 
            this.lstSetionName.AutoArrange = false;
            this.lstSetionName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstSetionName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSetionName.Location = new System.Drawing.Point(304, 7);
            this.lstSetionName.Name = "lstSetionName";
            this.lstSetionName.Size = new System.Drawing.Size(121, 97);
            this.lstSetionName.TabIndex = 4;
            this.lstSetionName.UseCompatibleStateImageBehavior = false;
            this.lstSetionName.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(15, 33);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(93, 21);
            this.txtBox.TabIndex = 1;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btntakeBack);
            this.panel2.Controls.Add(this.btnImpower);
            this.panel2.Location = new System.Drawing.Point(218, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 108);
            this.panel2.TabIndex = 3;
            // 
            // btntakeBack
            // 
            this.btntakeBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btntakeBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btntakeBack.Location = new System.Drawing.Point(9, 56);
            this.btntakeBack.Name = "btntakeBack";
            this.btntakeBack.Size = new System.Drawing.Size(60, 23);
            this.btntakeBack.TabIndex = 16;
            this.btntakeBack.Text = "收回";
            this.btntakeBack.Click += new System.EventHandler(this.btntakeBack_Click);
            // 
            // btnImpower
            // 
            this.btnImpower.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImpower.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImpower.Location = new System.Drawing.Point(9, 23);
            this.btnImpower.Name = "btnImpower";
            this.btnImpower.Size = new System.Drawing.Size(60, 23);
            this.btnImpower.TabIndex = 15;
            this.btnImpower.Text = "授权";
            this.btnImpower.Click += new System.EventHandler(this.btnImpower_Click);
            // 
            // cboSetionName
            // 
            this.cboSetionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSetionName.FormattingEnabled = true;
            this.cboSetionName.Location = new System.Drawing.Point(115, 33);
            this.cboSetionName.Name = "cboSetionName";
            this.cboSetionName.Size = new System.Drawing.Size(97, 20);
            this.cboSetionName.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(498, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "科室：";
            // 
            // lblSetionName
            // 
            this.lblSetionName.AutoSize = true;
            this.lblSetionName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSetionName.Location = new System.Drawing.Point(60, 3);
            this.lblSetionName.Name = "lblSetionName";
            this.lblSetionName.Size = new System.Drawing.Size(83, 12);
            this.lblSetionName.TabIndex = 12;
            this.lblSetionName.Text = "lblSetionName";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(180, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(252, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Section_HeadEmpowerment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSetionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel3);
            this.Name = "Section_HeadEmpowerment";
            this.Size = new System.Drawing.Size(498, 164);
            this.Load += new System.EventHandler(this.Section_HeadEmpowerment_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSetionName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSetionName;
        private System.Windows.Forms.ListView lstSetionName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btntakeBack;
        private DevComponents.DotNetBar.ButtonX btnImpower;

    }
}
