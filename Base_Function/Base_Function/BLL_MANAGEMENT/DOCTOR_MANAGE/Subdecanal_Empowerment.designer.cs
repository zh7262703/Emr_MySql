namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class Subdecanal_Empowerment
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstSetionName = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTakeback = new DevComponents.DotNetBar.ButtonX();
            this.btnImpower = new DevComponents.DotNetBar.ButtonX();
            this.cboSubdcanal = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Location = new System.Drawing.Point(57, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 171);
            this.panel4.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(252, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(180, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lstSetionName);
            this.panel3.Controls.Add(this.txtBox);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.cboSubdcanal);
            this.panel3.Location = new System.Drawing.Point(-1, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 109);
            this.panel3.TabIndex = 4;
            // 
            // lstSetionName
            // 
            this.lstSetionName.AutoArrange = false;
            this.lstSetionName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstSetionName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSetionName.Location = new System.Drawing.Point(307, 3);
            this.lstSetionName.Name = "lstSetionName";
            this.lstSetionName.Size = new System.Drawing.Size(121, 97);
            this.lstSetionName.TabIndex = 5;
            this.lstSetionName.UseCompatibleStateImageBehavior = false;
            this.lstSetionName.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(18, 33);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(93, 21);
            this.txtBox.TabIndex = 1;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnTakeback);
            this.panel2.Controls.Add(this.btnImpower);
            this.panel2.Location = new System.Drawing.Point(221, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 108);
            this.panel2.TabIndex = 3;
            // 
            // btnTakeback
            // 
            this.btnTakeback.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTakeback.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTakeback.Location = new System.Drawing.Point(9, 58);
            this.btnTakeback.Name = "btnTakeback";
            this.btnTakeback.Size = new System.Drawing.Size(60, 23);
            this.btnTakeback.TabIndex = 18;
            this.btnTakeback.Text = "收回";
            // 
            // btnImpower
            // 
            this.btnImpower.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImpower.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImpower.Location = new System.Drawing.Point(9, 22);
            this.btnImpower.Name = "btnImpower";
            this.btnImpower.Size = new System.Drawing.Size(60, 23);
            this.btnImpower.TabIndex = 17;
            this.btnImpower.Text = "授权";
            // 
            // cboSubdcanal
            // 
            this.cboSubdcanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubdcanal.FormattingEnabled = true;
            this.cboSubdcanal.Location = new System.Drawing.Point(118, 33);
            this.cboSubdcanal.Name = "cboSubdcanal";
            this.cboSubdcanal.Size = new System.Drawing.Size(97, 20);
            this.cboSubdcanal.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(498, 21);
            this.textBox1.TabIndex = 0;
            // 
            // Subdecanal_Empowerment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel4);
            this.Name = "Subdecanal_Empowerment";
            this.Size = new System.Drawing.Size(703, 208);
            this.Load += new System.EventHandler(this.Subdecanal_Empowerment_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSubdcanal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView lstSetionName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnTakeback;
        private DevComponents.DotNetBar.ButtonX btnImpower;

    }
}
