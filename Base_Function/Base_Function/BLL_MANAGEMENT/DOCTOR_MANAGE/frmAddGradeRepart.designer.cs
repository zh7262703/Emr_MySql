namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class frmAddGradeRepart
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
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnConfrom = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboxSick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.AutoScroll = true;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(790, 470);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            this.ucC1FlexGrid1.DoubleClick += new System.EventHandler(this.ucC1FlexGrid1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(398, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfrom
            // 
            this.btnConfrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfrom.Location = new System.Drawing.Point(317, 11);
            this.btnConfrom.Name = "btnConfrom";
            this.btnConfrom.Size = new System.Drawing.Size(75, 23);
            this.btnConfrom.TabIndex = 2;
            this.btnConfrom.Text = "确 定";
            this.btnConfrom.Click += new System.EventHandler(this.btnConfrom_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.txtPid);
            this.splitContainer1.Panel1.Controls.Add(this.cboxSick);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucC1FlexGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(790, 520);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 2;
            // 
            // cboxSick
            // 
            this.cboxSick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSick.FormattingEnabled = true;
            this.cboxSick.Location = new System.Drawing.Point(82, 11);
            this.cboxSick.Name = "cboxSick";
            this.cboxSick.Size = new System.Drawing.Size(189, 20);
            this.cboxSick.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "入院科室：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "住院号：";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(354, 12);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(119, 21);
            this.txtPid.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "姓名：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(555, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 21);
            this.txtName.TabIndex = 11;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(703, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmAddGradeRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 564);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmAddGradeRepart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增评分病历";
            this.Load += new System.EventHandler(this.frmAddGradeRepart_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnConfrom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.ComboBox cboxSick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
    }
}