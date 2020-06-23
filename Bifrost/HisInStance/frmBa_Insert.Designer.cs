namespace Bifrost.HisInStance
{
    partial class frmBa_Insert
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPatientFee = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCancelAll = new System.Windows.Forms.Label();
            this.lblSelectAll = new System.Windows.Forms.Label();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPatientFee);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_start);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件设置";
            // 
            // btnPatientFee
            // 
            this.btnPatientFee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPatientFee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPatientFee.Location = new System.Drawing.Point(591, 29);
            this.btnPatientFee.Name = "btnPatientFee";
            this.btnPatientFee.Size = new System.Drawing.Size(225, 30);
            this.btnPatientFee.TabIndex = 6;
            this.btnPatientFee.Text = "重新计算已归档患者费用";
            this.btnPatientFee.Click += new System.EventHandler(this.btnPatientFee_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsert.Location = new System.Drawing.Point(468, 29);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(117, 30);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "导入病案系统";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(381, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(249, 35);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(116, 21);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "归档时间：";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(101, 35);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(116, 21);
            this.dateTimePicker_start.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCancelAll);
            this.groupBox2.Controls.Add(this.lblSelectAll);
            this.groupBox2.Controls.Add(this.dataGridViewX1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(842, 384);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导入信息列表";
            // 
            // lblCancelAll
            // 
            this.lblCancelAll.AutoSize = true;
            this.lblCancelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancelAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancelAll.ForeColor = System.Drawing.Color.Blue;
            this.lblCancelAll.Location = new System.Drawing.Point(146, 0);
            this.lblCancelAll.Name = "lblCancelAll";
            this.lblCancelAll.Size = new System.Drawing.Size(41, 12);
            this.lblCancelAll.TabIndex = 2;
            this.lblCancelAll.Text = "全取消";
            this.lblCancelAll.Click += new System.EventHandler(this.lblCancelAll_Click);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AutoSize = true;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectAll.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectAll.Location = new System.Drawing.Point(111, 0);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(29, 12);
            this.lblSelectAll.TabIndex = 1;
            this.lblSelectAll.Text = "全选";
            this.lblSelectAll.Click += new System.EventHandler(this.lblSelectAll_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(836, 364);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // frmBa_Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBa_Insert";
            this.Size = new System.Drawing.Size(842, 463);
            this.Load += new System.EventHandler(this.frmBa_Insert_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Label lblSelectAll;
        private System.Windows.Forms.Label lblCancelAll;
        private DevComponents.DotNetBar.ButtonX btnPatientFee;
    }
}