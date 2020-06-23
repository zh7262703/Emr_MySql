namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmDetailInformation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cmbIsValid = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAttribute = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.isUseTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtFollowName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbIsValid);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbAttribute);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCreator);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.isUseTime);
            this.groupBox1.Controls.Add(this.txtFollowName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbLevel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbParent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbSection
            // 
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Items.AddRange(new object[] {
            "默认"});
            this.cmbSection.Location = new System.Drawing.Point(778, 13);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(125, 20);
            this.cmbSection.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(930, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbIsValid
            // 
            this.cmbIsValid.FormattingEnabled = true;
            this.cmbIsValid.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cmbIsValid.Location = new System.Drawing.Point(778, 57);
            this.cmbIsValid.Name = "cmbIsValid";
            this.cmbIsValid.Size = new System.Drawing.Size(68, 20);
            this.cmbIsValid.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(707, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "是否有效：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(707, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "创建科室：";
            // 
            // cmbAttribute
            // 
            this.cmbAttribute.FormattingEnabled = true;
            this.cmbAttribute.Items.AddRange(new object[] {
            "默认"});
            this.cmbAttribute.Location = new System.Drawing.Point(561, 56);
            this.cmbAttribute.Name = "cmbAttribute";
            this.cmbAttribute.Size = new System.Drawing.Size(111, 20);
            this.cmbAttribute.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "属性：";
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(561, 12);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(117, 21);
            this.txtCreator.TabIndex = 10;
            this.txtCreator.TextChanged += new System.EventHandler(this.txtCreator_TextChanged);
            this.txtCreator.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCreator_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "创建者：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(378, 55);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(270, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // isUseTime
            // 
            // 
            // 
            // 
            this.isUseTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.isUseTime.Location = new System.Drawing.Point(200, 53);
            this.isUseTime.Name = "isUseTime";
            this.isUseTime.Size = new System.Drawing.Size(75, 23);
            this.isUseTime.TabIndex = 6;
            this.isUseTime.Text = "时间";
            // 
            // txtFollowName
            // 
            this.txtFollowName.Location = new System.Drawing.Point(270, 13);
            this.txtFollowName.Name = "txtFollowName";
            this.txtFollowName.Size = new System.Drawing.Size(210, 21);
            this.txtFollowName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "问卷名称：";
            // 
            // cmbLevel
            // 
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "",
            "全院",
            "科室",
            "个人"});
            this.cmbLevel.Location = new System.Drawing.Point(72, 54);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(111, 20);
            this.cmbLevel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "级别：";
            // 
            // cmbParent
            // 
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(72, 13);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(111, 20);
            this.cmbParent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "父节点：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewX1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1029, 319);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
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
            this.dataGridViewX1.Size = new System.Drawing.Size(1023, 299);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellClick);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // frmDetailInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDetailInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFollowName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbParent;
        private DevComponents.DotNetBar.Controls.CheckBoxX isUseTime;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.ComboBox cmbIsValid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAttribute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
    }
}