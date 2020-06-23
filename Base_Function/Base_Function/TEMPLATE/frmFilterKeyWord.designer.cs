namespace Base_Function.TEMPLATE
{
    partial class frmFilterKeyWord
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.chkIsEnable = new System.Windows.Forms.CheckBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnNew = new DevComponents.DotNetBar.ButtonX();
            this.txtTargetWord = new System.Windows.Forms.TextBox();
            this.txtSourceWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(588, 392);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucC1FlexGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 274);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关键字列表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(3, 17);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(582, 254);
            this.ucC1FlexGrid1.TabIndex = 0;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.chkIsEnable);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.txtTargetWord);
            this.groupBox2.Controls.Add(this.txtSourceWord);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 114);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "关键字过滤设置";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(175, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "修改";
          
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(337, 64);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "删除";
            
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // chkIsEnable
            // 
            this.chkIsEnable.AutoSize = true;
            this.chkIsEnable.Enabled = false;
            this.chkIsEnable.Location = new System.Drawing.Point(432, 26);
            this.chkIsEnable.Name = "chkIsEnable";
            this.chkIsEnable.Size = new System.Drawing.Size(72, 16);
            this.chkIsEnable.TabIndex = 7;
            this.chkIsEnable.Text = "是否有效";
            this.chkIsEnable.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(420, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
           
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(256, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
           
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(94, 64);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "新增";
           
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTargetWord
            // 
            this.txtTargetWord.Enabled = false;
            this.txtTargetWord.Location = new System.Drawing.Point(285, 24);
            this.txtTargetWord.Name = "txtTargetWord";
            this.txtTargetWord.Size = new System.Drawing.Size(128, 21);
            this.txtTargetWord.TabIndex = 3;
            // 
            // txtSourceWord
            // 
            this.txtSourceWord.Enabled = false;
            this.txtSourceWord.Location = new System.Drawing.Point(92, 24);
            this.txtSourceWord.Name = "txtSourceWord";
            this.txtSourceWord.Size = new System.Drawing.Size(128, 21);
            this.txtSourceWord.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "目标词：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源词：";
            // 
            // frmFilterKeyWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 392);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmFilterKeyWord";
            this.Text = "模版关键字过滤";
            this.Load += new System.EventHandler(this.frmFilterKeyWord_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceWord;
        private System.Windows.Forms.TextBox txtTargetWord;
        private DevComponents.DotNetBar.ButtonX btnNew;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.CheckBox chkIsEnable;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnUpdate;

        

    }
}