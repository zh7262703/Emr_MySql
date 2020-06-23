namespace Base_Function.TEMPLATE
{
    partial class frmMacrosElement
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
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOnlyOnNull = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSplit = new System.Windows.Forms.TextBox();
            this.txtSelectIndex = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJoin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Location = new System.Drawing.Point(185, 390);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Location = new System.Drawing.Point(323, 390);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 9);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 23);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "描述：";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(321, 9);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(226, 23);
            this.txtDesc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "列名：";
            // 
            // txtColname
            // 
            this.txtColname.Location = new System.Drawing.Point(104, 40);
            this.txtColname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtColname.Name = "txtColname";
            this.txtColname.ReadOnly = true;
            this.txtColname.Size = new System.Drawing.Size(116, 23);
            this.txtColname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "格式：";
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(321, 40);
            this.txtFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(226, 23);
            this.txtFormat.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "默认值：";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(321, 102);
            this.txtDefaultValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(228, 23);
            this.txtDefaultValue.TabIndex = 4;
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(104, 133);
            this.cbEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(75, 21);
            this.cbEnable.TabIndex = 5;
            this.cbEnable.Text = "是否可用";
            this.cbEnable.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 180);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(490, 197);
            this.dataGridView1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "可选择的列名列表：";
            // 
            // cbOnlyOnNull
            // 
            this.cbOnlyOnNull.AutoSize = true;
            this.cbOnlyOnNull.Checked = true;
            this.cbOnlyOnNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnlyOnNull.Location = new System.Drawing.Point(321, 133);
            this.cbOnlyOnNull.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbOnlyOnNull.Name = "cbOnlyOnNull";
            this.cbOnlyOnNull.Size = new System.Drawing.Size(171, 21);
            this.cbOnlyOnNull.TabIndex = 5;
            this.cbOnlyOnNull.Text = "是否只在元素值为空时执行";
            this.cbOnlyOnNull.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "分割字符：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "取位数：";
            // 
            // txtSplit
            // 
            this.txtSplit.Location = new System.Drawing.Point(103, 72);
            this.txtSplit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSplit.Name = "txtSplit";
            this.txtSplit.Size = new System.Drawing.Size(116, 23);
            this.txtSplit.TabIndex = 4;
            // 
            // txtSelectIndex
            // 
            this.txtSelectIndex.Location = new System.Drawing.Point(320, 72);
            this.txtSelectIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSelectIndex.Name = "txtSelectIndex";
            this.txtSelectIndex.Size = new System.Drawing.Size(226, 23);
            this.txtSelectIndex.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "连接字符：";
            // 
            // txtJoin
            // 
            this.txtJoin.Location = new System.Drawing.Point(103, 102);
            this.txtJoin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJoin.Name = "txtJoin";
            this.txtJoin.Size = new System.Drawing.Size(116, 23);
            this.txtJoin.TabIndex = 4;
            // 
            // frmMacrosElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 426);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbOnlyOnNull);
            this.Controls.Add(this.cbEnable);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtSelectIndex);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.txtDefaultValue);
            this.Controls.Add(this.txtJoin);
            this.Controls.Add(this.txtSplit);
            this.Controls.Add(this.txtColname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMacrosElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "元素配置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbOnlyOnNull;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSplit;
        private System.Windows.Forms.TextBox txtSelectIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtJoin;
    }
}