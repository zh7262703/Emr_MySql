namespace TempertureEditor
{
    partial class frmTempertureDataEdit
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNowOperaterType = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.cboDataType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataTpicTime = new System.Windows.Forms.DateTimePicker();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.chkNoTime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNowOperaterType);
            this.groupBox3.Controls.Add(this.lblEndTime);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.cboDataType);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dataTpicTime);
            this.groupBox3.Controls.Add(this.txtVal);
            this.groupBox3.Controls.Add(this.btnSure);
            this.groupBox3.Controls.Add(this.chkNoTime);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 106);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "体温单编辑";
            // 
            // lblNowOperaterType
            // 
            this.lblNowOperaterType.AutoSize = true;
            this.lblNowOperaterType.ForeColor = System.Drawing.Color.Red;
            this.lblNowOperaterType.Location = new System.Drawing.Point(429, 47);
            this.lblNowOperaterType.Name = "lblNowOperaterType";
            this.lblNowOperaterType.Size = new System.Drawing.Size(77, 12);
            this.lblNowOperaterType.TabIndex = 16;
            this.lblNowOperaterType.Text = "当前操作状态";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(319, 21);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 12);
            this.lblEndTime.TabIndex = 15;
            this.lblEndTime.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 21);
            this.button1.TabIndex = 14;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "结束时间";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(63, 17);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(133, 21);
            this.dtpStart.TabIndex = 11;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "开始时间";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(320, 73);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(63, 22);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // cboDataType
            // 
            this.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataType.FormattingEnabled = true;
            this.cboDataType.Location = new System.Drawing.Point(63, 44);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.Size = new System.Drawing.Size(134, 20);
            this.cboDataType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "新建数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "值";
            // 
            // dataTpicTime
            // 
            this.dataTpicTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dataTpicTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataTpicTime.Location = new System.Drawing.Point(260, 44);
            this.dataTpicTime.Name = "dataTpicTime";
            this.dataTpicTime.ShowUpDown = true;
            this.dataTpicTime.Size = new System.Drawing.Size(147, 21);
            this.dataTpicTime.TabIndex = 3;
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(62, 70);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(134, 21);
            this.txtVal.TabIndex = 6;
            this.txtVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVal_KeyPress);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(389, 73);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(63, 22);
            this.btnSure.TabIndex = 7;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // chkNoTime
            // 
            this.chkNoTime.AutoSize = true;
            this.chkNoTime.Location = new System.Drawing.Point(210, 46);
            this.chkNoTime.Name = "chkNoTime";
            this.chkNoTime.Size = new System.Drawing.Size(48, 16);
            this.chkNoTime.TabIndex = 4;
            this.chkNoTime.Text = "时间";
            this.chkNoTime.UseVisualStyleBackColor = true;
            this.chkNoTime.CheckedChanged += new System.EventHandler(this.chkNoTime_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 322);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "体温数据";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(548, 302);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // frmTempertureDataEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTempertureDataEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体温测试数据操作";
            this.Load += new System.EventHandler(this.frmTempertureDataEdit_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboDataType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataTpicTime;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.CheckBox chkNoTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblNowOperaterType;
    }
}