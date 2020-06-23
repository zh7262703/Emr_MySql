namespace Base_Function.TEMPLATE
{
    partial class frmDocument
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTextName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseDoc = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(935, 746);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(252, 746);
            this.splitContainer2.SplitterDistance = 138;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTextName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCloseDoc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 138);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条件设置";
            // 
            // txtTextName
            // 
            this.txtTextName.Location = new System.Drawing.Point(93, 39);
            this.txtTextName.Name = "txtTextName";
            this.txtTextName.Size = new System.Drawing.Size(140, 21);
            this.txtTextName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文书名称";
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.Location = new System.Drawing.Point(139, 84);
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDoc.TabIndex = 1;
            this.btnCloseDoc.Text = "保存文书";            
            this.btnCloseDoc.Click += new System.EventHandler(this.btnCloseDoc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 604);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文书列表";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeView2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 373);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 228);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "文书结构化列表";
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(3, 17);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(240, 208);
            this.treeView2.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(246, 356);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ucC1FlexGrid1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 516);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(679, 230);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "结构化表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(3, 17);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(673, 210);
            this.ucC1FlexGrid1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模版编辑";
            // 
            // frmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 746);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDocument";
            this.Text = "文书管理";
            this.Load += new System.EventHandler(this.frmDocument_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.ButtonX btnCloseDoc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TextBox txtTextName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
    }
}