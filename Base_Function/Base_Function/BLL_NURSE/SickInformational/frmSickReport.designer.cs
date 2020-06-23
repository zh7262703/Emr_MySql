namespace Base_Function.BLL_NURSE.SickInformational
{
    partial class frmSickReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SickName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.PKdateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cfgTableHand = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cfgcentent = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.DelectUpdateMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnight = new System.Windows.Forms.Button();
            this.btnDay = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgTableHand)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgcentent)).BeginInit();
            this.DelectUpdateMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SickName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.PKdateTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "交接班记录查询";
            // 
            // SickName
            // 
            this.SickName.AutoSize = true;
            this.SickName.Location = new System.Drawing.Point(464, 27);
            this.SickName.Name = "SickName";
            this.SickName.Size = new System.Drawing.Size(17, 12);
            this.SickName.TabIndex = 4;
            this.SickName.Text = "啊";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "病区：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(231, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // PKdateTime
            // 
            this.PKdateTime.CustomFormat = "yyyy-MM-dd";
            this.PKdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PKdateTime.Location = new System.Drawing.Point(107, 23);
            this.PKdateTime.Name = "PKdateTime";
            this.PKdateTime.Size = new System.Drawing.Size(99, 21);
            this.PKdateTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cfgTableHand);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病区基本信息";
            // 
            // cfgTableHand
            // 
            this.cfgTableHand.AllowEditing = false;
            this.cfgTableHand.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.cfgTableHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgTableHand.Location = new System.Drawing.Point(3, 17);
            this.cfgTableHand.Name = "cfgTableHand";
            this.cfgTableHand.Rows.DefaultSize = 18;
            this.cfgTableHand.Size = new System.Drawing.Size(952, 116);
            this.cfgTableHand.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cfgcentent);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(958, 509);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "病区详细信息";
            // 
            // cfgcentent
            // 
            this.cfgcentent.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.cfgcentent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cfgcentent.Location = new System.Drawing.Point(3, 17);
            this.cfgcentent.Name = "cfgcentent";
            this.cfgcentent.Rows.DefaultSize = 18;
            this.cfgcentent.Size = new System.Drawing.Size(952, 489);
            this.cfgcentent.TabIndex = 0;
            // 
            // DelectUpdateMenuStrip
            // 
            this.DelectUpdateMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.DelectUpdateMenuStrip.Name = "contextMenuStrip1";
            this.DelectUpdateMenuStrip.Size = new System.Drawing.Size(110, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F);
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.删除ToolStripMenuItem.Text = "删  除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnnight);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 702);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 39);
            this.panel1.TabIndex = 3;
            // 
            // btnnight
            // 
            this.btnnight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnnight.Location = new System.Drawing.Point(482, 8);
            this.btnnight.Name = "btnnight";
            this.btnnight.Size = new System.Drawing.Size(75, 23);
            this.btnnight.TabIndex = 1;
            this.btnnight.Text = "添加夜班";
            this.btnnight.UseVisualStyleBackColor = true;
            this.btnnight.Click += new System.EventHandler(this.btnnight_Click);
            // 
            // btnDay
            // 
            this.btnDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDay.Location = new System.Drawing.Point(401, 8);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(75, 23);
            this.btnDay.TabIndex = 0;
            this.btnDay.Text = "添加白班";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // frmSickReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 741);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "frmSickReport";
            this.Text = "交接班记录";
            this.Load += new System.EventHandler(this.frmSickReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cfgTableHand)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cfgcentent)).EndInit();
            this.DelectUpdateMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DateTimePicker PKdateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SickName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnight;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.ContextMenuStrip DelectUpdateMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private C1.Win.C1FlexGrid.C1FlexGrid cfgcentent;
        private C1.Win.C1FlexGrid.C1FlexGrid cfgTableHand;
    }
}