namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
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
            this.btnConfrom = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.AutoScroll = true;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(790, 520);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.DoubleClick += new System.EventHandler(this.ucC1FlexGrid1_DoubleClick);
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
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
            // frmAddGradeRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 564);
            this.Controls.Add(this.ucC1FlexGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddGradeRepart";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增评分病历";
            this.Load += new System.EventHandler(this.frmAddGradeRepart_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnConfrom;
    }
}