namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmState
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cklbState = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cklbState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 262);
            this.panel1.TabIndex = 0;
            // 
            // cklbState
            // 
            this.cklbState.CheckOnClick = true;
            this.cklbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklbState.FormattingEnabled = true;
            this.cklbState.Location = new System.Drawing.Point(0, 0);
            this.cklbState.Name = "cklbState";
            this.cklbState.Size = new System.Drawing.Size(284, 262);
            this.cklbState.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 44);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(148, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(50, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加随访状态";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmState_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.CheckedListBox cklbState;

    }
}