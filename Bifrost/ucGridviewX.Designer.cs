namespace Bifrost
{
    partial class ucGridviewX
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBottom = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.btnTop = new DevComponents.DotNetBar.ButtonX();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrentPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fg = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 556);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1376, 41);
            this.panel2.TabIndex = 4;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnBottom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.cboSize);
            this.panel1.Controls.Add(this.btnTop);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboCurrentPage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(119, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 34);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // btnBottom
            // 
            this.btnBottom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBottom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBottom.Location = new System.Drawing.Point(514, 4);
            this.btnBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(56, 26);
            this.btnBottom.TabIndex = 7;
            this.btnBottom.Text = ">>";
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "条记录";
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Location = new System.Drawing.Point(450, 4);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 26);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = ">";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "100",
            "150",
            "200",
            "250",
            "300"});
            this.cboSize.Location = new System.Drawing.Point(313, 5);
            this.cboSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(66, 23);
            this.cboSize.TabIndex = 6;
            this.cboSize.SelectedIndexChanged += new System.EventHandler(this.cboSize_SelectedIndexChanged);
            // 
            // btnTop
            // 
            this.btnTop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTop.Location = new System.Drawing.Point(0, 4);
            this.btnTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(56, 26);
            this.btnTop.TabIndex = 4;
            this.btnTop.Text = "<<";
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Location = new System.Drawing.Point(64, 4);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 26);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "<";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "每页:";
            // 
            // cboCurrentPage
            // 
            this.cboCurrentPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentPage.FormattingEnabled = true;
            this.cboCurrentPage.Location = new System.Drawing.Point(186, 5);
            this.cboCurrentPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCurrentPage.Name = "cboCurrentPage";
            this.cboCurrentPage.Size = new System.Drawing.Size(66, 23);
            this.cboCurrentPage.TabIndex = 3;
            this.cboCurrentPage.SelectedIndexChanged += new System.EventHandler(this.cboCurrentPage_SelectedIndexChanged);
            this.cboCurrentPage.TextChanged += new System.EventHandler(this.cboCurrentPage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(126, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前页:";
            // 
            // fg
            // 
            this.fg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.fg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.fg.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fg.DefaultCellStyle = dataGridViewCellStyle2;
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.fg.Location = new System.Drawing.Point(0, 0);
            this.fg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fg.Name = "fg";
            this.fg.RowTemplate.Height = 23;
            this.fg.Size = new System.Drawing.Size(1376, 556);
            this.fg.TabIndex = 5;
            this.fg.Sorted += new System.EventHandler(this.fg_Sorted);
            this.fg.Click += new System.EventHandler(this.fg_Click);
            this.fg.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            // 
            // ucGridviewX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fg);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucGridviewX";
            this.Size = new System.Drawing.Size(1376, 597);
            this.Load += new System.EventHandler(this.ucC1FlexGrid_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnBottom;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private System.Windows.Forms.ComboBox cboSize;
        private DevComponents.DotNetBar.ButtonX btnTop;
        private DevComponents.DotNetBar.ButtonX btnUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCurrentPage;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.DataGridViewX fg;
    }
}
