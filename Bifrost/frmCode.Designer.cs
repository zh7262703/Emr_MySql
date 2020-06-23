namespace Bifrost
{
    partial class frmCode
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.rcode = new System.Windows.Forms.RadioButton();
            this.rname = new System.Windows.Forms.RadioButton();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtinput);
            this.panel2.Controls.Add(this.rcode);
            this.panel2.Controls.Add(this.rname);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 36);
            this.panel2.TabIndex = 9;
            // 
            // txtinput
            // 
            this.txtinput.Location = new System.Drawing.Point(144, 8);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(221, 21);
            this.txtinput.TabIndex = 2;
            this.txtinput.TextChanged += new System.EventHandler(this.txtinput_TextChanged);
            // 
            // rcode
            // 
            this.rcode.AutoSize = true;
            this.rcode.Location = new System.Drawing.Point(75, 10);
            this.rcode.Name = "rcode";
            this.rcode.Size = new System.Drawing.Size(47, 16);
            this.rcode.TabIndex = 1;
            this.rcode.TabStop = true;
            this.rcode.Text = "编码";
            this.rcode.UseVisualStyleBackColor = true;
            this.rcode.CheckedChanged += new System.EventHandler(this.rcode_CheckedChanged);
            // 
            // rname
            // 
            this.rname.AutoSize = true;
            this.rname.Location = new System.Drawing.Point(6, 10);
            this.rname.Name = "rname";
            this.rname.Size = new System.Drawing.Size(47, 16);
            this.rname.TabIndex = 0;
            this.rname.TabStop = true;
            this.rname.Text = "名称";
            this.rname.UseVisualStyleBackColor = true;
            this.rname.CheckedChanged += new System.EventHandler(this.rname_CheckedChanged);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 36);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(374, 222);
            this.dataGridViewX1.TabIndex = 10;
            // 
            // frmCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 258);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快码查询";
            this.Load += new System.EventHandler(this.frmCode_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.RadioButton rcode;
        private System.Windows.Forms.RadioButton rname;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
    }
}