namespace Base_Function.BLL_DOCTOR.HisInStance.LIS
{
    partial class FrmLis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLis));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flgview_Patient = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flgView_Yb = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flgView_Gm = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chb_qx = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 438);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flgview_Patient);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 418);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 0;
            // 
            // flgview_Patient
            // 
            this.flgview_Patient.AllowEditing = false;
            this.flgview_Patient.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgview_Patient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgview_Patient.Location = new System.Drawing.Point(0, 0);
            this.flgview_Patient.Name = "flgview_Patient";
            this.flgview_Patient.Rows.DefaultSize = 18;
            this.flgview_Patient.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgview_Patient.Size = new System.Drawing.Size(418, 418);
            this.flgview_Patient.StyleInfo = resources.GetString("flgview_Patient.StyleInfo");
            this.flgview_Patient.TabIndex = 0;
            this.flgview_Patient.Click += new System.EventHandler(this.flgview_Patient_Click);
            this.flgview_Patient.SelChange += new System.EventHandler(this.flgview_Patient_SelChange);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flgView_Yb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(709, 418);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检验结果";
            // 
            // flgView_Yb
            // 
            this.flgView_Yb.AllowEditing = false;
            this.flgView_Yb.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView_Yb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView_Yb.Location = new System.Drawing.Point(3, 17);
            this.flgView_Yb.Name = "flgView_Yb";
            this.flgView_Yb.Rows.DefaultSize = 18;
            this.flgView_Yb.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.flgView_Yb.Size = new System.Drawing.Size(703, 398);
            this.flgView_Yb.StyleInfo = resources.GetString("flgView_Yb.StyleInfo");
            this.flgView_Yb.TabIndex = 1;
            this.flgView_Yb.Click += new System.EventHandler(this.flgView_Yb_Click);
            this.flgView_Yb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseClick);
            this.flgView_Yb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseDown);
            this.flgView_Yb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flgView_Yb_MouseDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(73, 277);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(322, 66);
            this.splitContainer2.SplitterDistance = 37;
            this.splitContainer2.TabIndex = 5;
            this.splitContainer2.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flgView_Gm);
            this.groupBox4.Location = new System.Drawing.Point(0, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(398, 136);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "细菌结果";
            this.groupBox4.Visible = false;
            // 
            // flgView_Gm
            // 
            this.flgView_Gm.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView_Gm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView_Gm.Location = new System.Drawing.Point(3, 17);
            this.flgView_Gm.Name = "flgView_Gm";
            this.flgView_Gm.Rows.DefaultSize = 18;
            this.flgView_Gm.Size = new System.Drawing.Size(392, 116);
            this.flgView_Gm.StyleInfo = resources.GetString("flgView_Gm.StyleInfo");
            this.flgView_Gm.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制CopyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
            // 
            // 复制CopyToolStripMenuItem
            // 
            this.复制CopyToolStripMenuItem.Name = "复制CopyToolStripMenuItem";
            this.复制CopyToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.复制CopyToolStripMenuItem.Text = "复制Copy";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.chb_qx);
            this.panel1.Controls.Add(this.chbAll);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 32);
            this.panel1.TabIndex = 7;
            // 
            // chb_qx
            // 
            this.chb_qx.AutoSize = true;
            this.chb_qx.Location = new System.Drawing.Point(668, 9);
            this.chb_qx.Name = "chb_qx";
            this.chb_qx.Size = new System.Drawing.Size(48, 16);
            this.chb_qx.TabIndex = 10;
            this.chb_qx.Text = "全选";
            this.chb_qx.UseVisualStyleBackColor = true;
            this.chb_qx.CheckedChanged += new System.EventHandler(this.chb_qx_CheckedChanged);
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(578, 9);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(60, 16);
            this.chbAll.TabIndex = 10;
            this.chbAll.Text = "异常项";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(397, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(316, 5);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 8;
            this.btnSure.Text = "确定(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtPid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1137, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询设置";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(259, 20);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "查询(&Q)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(98, 23);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(142, 21);
            this.txtPid.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "病人编号：";
            // 
            // FrmLis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 529);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FrmLis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验报告";
            this.Load += new System.EventHandler(this.FrmLis_Load);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgview_Patient)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Yb)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgView_Gm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1FlexGrid.C1FlexGrid flgview_Patient;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Yb;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private C1.Win.C1FlexGrid.C1FlexGrid flgView_Gm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制CopyToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chb_qx;
        private System.Windows.Forms.CheckBox chbAll;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label3;
    }
}