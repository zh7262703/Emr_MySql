namespace Base_Function.Digital_Medical_Treatment
{
    partial class frmDoctorBookGet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorBookGet));
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
            this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
            this.trvDoctorBook = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.splitContainerHorizontal.Panel1.SuspendLayout();
            this.splitContainerHorizontal.Panel2.SuspendLayout();
            this.splitContainerHorizontal.SuspendLayout();
            this.splitContainerVertical.Panel1.SuspendLayout();
            this.splitContainerVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvDoctorBook)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListBook
            // 
            this.imgListBook.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBook.ImageStream")));
            this.imgListBook.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBook.Images.SetKeyName(0, "paintm.ico");
            this.imgListBook.Images.SetKeyName(1, "joym.ico");
            this.imgListBook.Images.SetKeyName(2, "manilla.ico");
            this.imgListBook.Images.SetKeyName(3, "net1m.ico");
            this.imgListBook.Images.SetKeyName(4, "net2m.ico");
            this.imgListBook.Images.SetKeyName(5, "New Text Doc.ico");
            this.imgListBook.Images.SetKeyName(6, "NOTEPA~1.ICO");
            this.imgListBook.Images.SetKeyName(7, "NOTEPA~2.ICO");
            this.imgListBook.Images.SetKeyName(8, "NOTEPA~3.ICO");
            this.imgListBook.Images.SetKeyName(9, "NOTEPA~4.ICO");
            this.imgListBook.Images.SetKeyName(10, "NOTEPA~5.ICO");
            this.imgListBook.Images.SetKeyName(11, "notesg.ico");
            this.imgListBook.Images.SetKeyName(12, "notesm.ico");
            this.imgListBook.Images.SetKeyName(13, "BETEXT~1.ICO");
            this.imgListBook.Images.SetKeyName(14, "FORMATED.ICO");
            // 
            // splitContainerHorizontal
            // 
            this.splitContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHorizontal.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHorizontal.Name = "splitContainerHorizontal";
            this.splitContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHorizontal.Panel1
            // 
            this.splitContainerHorizontal.Panel1.Controls.Add(this.splitContainerVertical);
            // 
            // splitContainerHorizontal.Panel2
            // 
            this.splitContainerHorizontal.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerHorizontal.Panel2.Controls.Add(this.btnOK);
            this.splitContainerHorizontal.Size = new System.Drawing.Size(1004, 630);
            this.splitContainerHorizontal.SplitterDistance = 579;
            this.splitContainerHorizontal.TabIndex = 1;
            // 
            // splitContainerVertical
            // 
            this.splitContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVertical.Name = "splitContainerVertical";
            // 
            // splitContainerVertical.Panel1
            // 
            this.splitContainerVertical.Panel1.Controls.Add(this.trvDoctorBook);
            this.splitContainerVertical.Size = new System.Drawing.Size(1004, 579);
            this.splitContainerVertical.SplitterDistance = 199;
            this.splitContainerVertical.TabIndex = 0;
            // 
            // trvDoctorBook
            // 
            this.trvDoctorBook.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.trvDoctorBook.AllowDrop = true;
            this.trvDoctorBook.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.trvDoctorBook.BackgroundStyle.Class = "TreeBorderKey";
            this.trvDoctorBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDoctorBook.Font = new System.Drawing.Font("宋体", 10.5F);
            this.trvDoctorBook.ImageList = this.imgListBook;
            this.trvDoctorBook.Location = new System.Drawing.Point(0, 0);
            this.trvDoctorBook.Name = "trvDoctorBook";
            this.trvDoctorBook.NodesConnector = this.nodeConnector1;
            this.trvDoctorBook.NodeStyle = this.elementStyle1;
            this.trvDoctorBook.PathSeparator = ";";
            this.trvDoctorBook.Size = new System.Drawing.Size(199, 579);
            this.trvDoctorBook.Styles.Add(this.elementStyle1);
            this.trvDoctorBook.TabIndex = 1;
            this.trvDoctorBook.DoubleClick += new System.EventHandler(this.trvDoctorBook_DoubleClick);
            this.trvDoctorBook.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTree1_AfterNodeSelect);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(505, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(424, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmDoctorBookGet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1004, 630);
            this.Controls.Add(this.splitContainerHorizontal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDoctorBookGet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院病程文书";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDoctorBook_Load);
            this.splitContainerHorizontal.Panel1.ResumeLayout(false);
            this.splitContainerHorizontal.Panel2.ResumeLayout(false);
            this.splitContainerHorizontal.ResumeLayout(false);
            this.splitContainerVertical.Panel1.ResumeLayout(false);
            this.splitContainerVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvDoctorBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerHorizontal;
        private System.Windows.Forms.SplitContainer splitContainerVertical;
        private System.Windows.Forms.ImageList imgListBook;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.AdvTree.AdvTree trvDoctorBook;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}