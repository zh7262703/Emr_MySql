namespace Base_Function.BLL_DOCTOR.HisInStance.病理检查
{
    partial class frmBljc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBljc));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flgview_Patient = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtPid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询设置";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(660, 19);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "查询(&Q)";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(502, 22);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(142, 21);
            this.txtPid.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "病人编号：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(258, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(145, 21);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "-->";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(78, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(145, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "日期：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flgview_Patient);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(766, 314);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // flgview_Patient
            // 
            this.flgview_Patient.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview_Patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview_Patient.Location = new System.Drawing.Point(3, 17);
            this.flgview_Patient.Name = "flgview_Patient";
            this.flgview_Patient.Rows.DefaultSize = 18;
            this.flgview_Patient.Size = new System.Drawing.Size(760, 294);
            this.flgview_Patient.StyleInfo = resources.GetString("flgview_Patient.StyleInfo");
            this.flgview_Patient.TabIndex = 1;
            // 
            // frmBljc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(766, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmBljc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病理检查";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview_Patient;

    }
}