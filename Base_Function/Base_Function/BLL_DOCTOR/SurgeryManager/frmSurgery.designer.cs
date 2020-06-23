namespace Base_Function.BLL_DOCTOR.SurgeryManager
{
    partial class frmSurgery
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
            this.flgSergeryList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.进入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请审批ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通知ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApply_user = new System.Windows.Forms.Label();
            this.txtApply_User = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.flgSergeryList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flgSergeryList
            // 
            this.flgSergeryList.ColumnInfo = "15,1,0,0,0,0,Columns:1{Name:\"审批状态\";}\t2{Name:\"手术医师\";}\t3{Name:\"手术日期\";}\t4{Name:\"手术名称" +
                "\";}\t5{Name:\"拟施手术名称\";}\t6{Name:\"手术序号\";}\t";
            this.flgSergeryList.ContextMenuStrip = this.contextMenuStrip1;
            this.flgSergeryList.Location = new System.Drawing.Point(0, 0);
            this.flgSergeryList.Name = "flgSergeryList";
            this.flgSergeryList.Rows.DefaultSize = 18;
            this.flgSergeryList.Size = new System.Drawing.Size(807, 211);
            this.flgSergeryList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进入ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.申请审批ToolStripMenuItem,
            this.通知ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 92);
            // 
            // 进入ToolStripMenuItem
            // 
            this.进入ToolStripMenuItem.Name = "进入ToolStripMenuItem";
            this.进入ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.进入ToolStripMenuItem.Text = "进入";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 申请审批ToolStripMenuItem
            // 
            this.申请审批ToolStripMenuItem.Name = "申请审批ToolStripMenuItem";
            this.申请审批ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.申请审批ToolStripMenuItem.Text = "申请审批";
            this.申请审批ToolStripMenuItem.Click += new System.EventHandler(this.申请审批ToolStripMenuItem_Click);
            // 
            // 通知ToolStripMenuItem
            // 
            this.通知ToolStripMenuItem.Name = "通知ToolStripMenuItem";
            this.通知ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.通知ToolStripMenuItem.Text = "通知";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(194, 217);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "历史申报查看";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(6, 250);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 3;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 246);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(253, 246);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "结束时间：";
            // 
            // lblApply_user
            // 
            this.lblApply_user.AutoSize = true;
            this.lblApply_user.Location = new System.Drawing.Point(387, 250);
            this.lblApply_user.Name = "lblApply_user";
            this.lblApply_user.Size = new System.Drawing.Size(53, 12);
            this.lblApply_user.TabIndex = 5;
            this.lblApply_user.Text = "申报人：";
            // 
            // txtApply_User
            // 
            this.txtApply_User.Location = new System.Drawing.Point(446, 246);
            this.txtApply_User.Name = "txtApply_User";
            this.txtApply_User.Size = new System.Drawing.Size(100, 21);
            this.txtApply_User.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "术者：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(610, 246);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(732, 246);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = "15,1,0,0,0,0,Columns:1{Name:\"状态\";}\t2{Name:\"术者\";}\t3{Name:\"手术名称\";}\t4{Name:\"申请时间\";}\t" +
                "5{Name:\"申报人\";}\t6{Name:\"申报时间\";}\t";
            this.c1FlexGrid1.ContextMenuStrip = this.contextMenuStrip2;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 273);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 18;
            this.c1FlexGrid1.Size = new System.Drawing.Size(807, 180);
            this.c1FlexGrid1.TabIndex = 8;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看ToolStripMenuItem,
            this.打印ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(95, 48);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // frmSurgery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 453);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtApply_User);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblApply_user);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.flgSergeryList);
            this.Name = "frmSurgery";
            this.Text = "手术";
            this.Load += new System.EventHandler(this.frmSurgery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flgSergeryList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgSergeryList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApply_user;
        private System.Windows.Forms.TextBox txtApply_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSelect;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 进入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请审批ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通知ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
    }
}