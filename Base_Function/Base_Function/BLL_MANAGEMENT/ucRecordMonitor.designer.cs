namespace Base_Function.BLL_MANAGEMENT
{
    partial class ucRecordMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecordMonitor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkbl = new System.Windows.Forms.CheckBox();
            this.lblred = new System.Windows.Forms.Label();
            this.lblyellow = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.cboTextType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSickArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstCount = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkbl);
            this.groupBox1.Controls.Add(this.lblred);
            this.groupBox1.Controls.Add(this.lblyellow);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Controls.Add(this.lblY);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.cboTextType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboSickArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // lblno
            // 
            this.lblno.AutoSize = true;
            this.lblno.Location = new System.Drawing.Point(128, 61);
            this.lblno.Name = "lblno";
            this.lblno.Size = new System.Drawing.Size(11, 12);
            this.lblno.TabIndex = 14;
            this.lblno.Text = "0";
            this.lblno.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "科室全院排名:";
            this.label3.Visible = false;
            // 
            // chkbl
            // 
            this.chkbl.AutoSize = true;
            this.chkbl.Location = new System.Drawing.Point(524, 32);
            this.chkbl.Name = "chkbl";
            this.chkbl.Size = new System.Drawing.Size(48, 16);
            this.chkbl.TabIndex = 12;
            this.chkbl.Text = "补录";
            this.chkbl.UseVisualStyleBackColor = false;
            this.chkbl.Visible = false;
            // 
            // lblred
            // 
            this.lblred.AutoSize = true;
            this.lblred.ForeColor = System.Drawing.Color.Red;
            this.lblred.Location = new System.Drawing.Point(807, 33);
            this.lblred.Name = "lblred";
            this.lblred.Size = new System.Drawing.Size(23, 12);
            this.lblred.TabIndex = 10;
            this.lblred.Text = "red";
            this.lblred.Visible = false;
            // 
            // lblyellow
            // 
            this.lblyellow.AutoSize = true;
            this.lblyellow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblyellow.Location = new System.Drawing.Point(679, 33);
            this.lblyellow.Name = "lblyellow";
            this.lblyellow.Size = new System.Drawing.Size(41, 12);
            this.lblyellow.TabIndex = 9;
            this.lblyellow.Text = "yellow";
            this.lblyellow.Visible = false;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(736, 33);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(65, 12);
            this.lblR.TabIndex = 8;
            this.lblR.Text = "红灯数量：";
            this.lblR.Visible = false;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(608, 33);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(65, 12);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "黄灯数量：";
            this.lblY.Visible = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(962, 28);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 6;
            this.buttonX1.Text = "刷新";
            this.buttonX1.Visible = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(847, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboTextType
            // 
            this.cboTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextType.FormattingEnabled = true;
            this.cboTextType.Location = new System.Drawing.Point(328, 29);
            this.cboTextType.Name = "cboTextType";
            this.cboTextType.Size = new System.Drawing.Size(173, 20);
            this.cboTextType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文书类型：";
            // 
            // cboSickArea
            // 
            this.cboSickArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSickArea.FormattingEnabled = true;
            this.cboSickArea.Location = new System.Drawing.Point(80, 29);
            this.cboSickArea.Name = "cboSickArea";
            this.cboSickArea.Size = new System.Drawing.Size(173, 20);
            this.cboSickArea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区：";
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(100, 20);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "red.png");
            this.imageList1.Images.SetKeyName(1, "yellow.png");
            this.imageList1.Images.SetKeyName(2, "bul.png");
            this.imageList1.Images.SetKeyName(3, "bule.png");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Controls.Add(this.lstCount);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(0, 416);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1052, 184);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "统计列表";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1046, 164);
            this.panel2.TabIndex = 9;
            this.panel2.SizeChanged += new System.EventHandler(this.panel2_SizeChanged);
            // 
            // lstCount
            // 
            this.lstCount.Location = new System.Drawing.Point(18, 20);
            this.lstCount.Name = "lstCount";
            this.lstCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstCount.Size = new System.Drawing.Size(1031, 219);
            this.lstCount.SmallImageList = this.imageList1;
            this.lstCount.TabIndex = 0;
            this.lstCount.UseCompatibleStateImageBehavior = false;
            this.lstCount.View = System.Windows.Forms.View.SmallIcon;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 330);
            this.panel1.TabIndex = 8;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // ucRecordMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucRecordMonitor";
            this.Size = new System.Drawing.Size(1052, 600);
            this.Load += new System.EventHandler(this.ucRecordMonitor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTextType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSickArea;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblyellow;
        private System.Windows.Forms.Label lblred;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstCount;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblno;
    }
}
