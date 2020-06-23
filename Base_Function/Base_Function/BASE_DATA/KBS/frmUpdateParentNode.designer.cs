namespace Base_Function.BASE_DATA.KBS
{
    partial class frmUpdateParentNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateParentNode));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComplexName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbnDirectAndCont = new System.Windows.Forms.RadioButton();
            this.rbnDirector = new System.Windows.Forms.RadioButton();
            this.rbnTitle = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.advTreeSmallTemplate = new Base_Function.BASE_DATA.KBS.uc_TreeView(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(194, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 27);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(94, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 27);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 37);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtComplexName);
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 33);
            this.panel2.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(177, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(59, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查找";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "名称：";
            // 
            // txtComplexName
            // 
            this.txtComplexName.Location = new System.Drawing.Point(40, 7);
            this.txtComplexName.Name = "txtComplexName";
            this.txtComplexName.Size = new System.Drawing.Size(131, 21);
            this.txtComplexName.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 343);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.advTreeSmallTemplate);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(361, 310);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbnTitle);
            this.panel5.Controls.Add(this.rbnDirector);
            this.panel5.Controls.Add(this.rbnDirectAndCont);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(361, 27);
            this.panel5.TabIndex = 2;
            // 
            // rbnDirectAndCont
            // 
            this.rbnDirectAndCont.AutoSize = true;
            this.rbnDirectAndCont.Checked = true;
            this.rbnDirectAndCont.Location = new System.Drawing.Point(12, 6);
            this.rbnDirectAndCont.Name = "rbnDirectAndCont";
            this.rbnDirectAndCont.Size = new System.Drawing.Size(77, 16);
            this.rbnDirectAndCont.TabIndex = 0;
            this.rbnDirectAndCont.TabStop = true;
            this.rbnDirectAndCont.Text = "目录+内容";
            this.rbnDirectAndCont.UseVisualStyleBackColor = true;
            // 
            // rbnDirector
            // 
            this.rbnDirector.AutoSize = true;
            this.rbnDirector.Location = new System.Drawing.Point(131, 6);
            this.rbnDirector.Name = "rbnDirector";
            this.rbnDirector.Size = new System.Drawing.Size(47, 16);
            this.rbnDirector.TabIndex = 1;
            this.rbnDirector.Text = "目录";
            this.rbnDirector.UseVisualStyleBackColor = true;
            // 
            // rbnTitle
            // 
            this.rbnTitle.AutoSize = true;
            this.rbnTitle.Location = new System.Drawing.Point(220, 6);
            this.rbnTitle.Name = "rbnTitle";
            this.rbnTitle.Size = new System.Drawing.Size(47, 16);
            this.rbnTitle.TabIndex = 2;
            this.rbnTitle.Text = "标题";
            this.rbnTitle.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "TextEditor.icon.close_2.bmp");
            this.imageList1.Images.SetKeyName(1, "TextEditor.icon.open_2.bmp");
            this.imageList1.Images.SetKeyName(2, "TextEditor.icon.close.bmp");
            this.imageList1.Images.SetKeyName(3, "TextEditor.icon.open.bmp");
            this.imageList1.Images.SetKeyName(4, "TextEditor.icon.frm.bmp");
            this.imageList1.Images.SetKeyName(5, "script.bmp");
            // 
            // advTreeSmallTemplate
            // 
            this.advTreeSmallTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeSmallTemplate.ImageIndex = 0;
            this.advTreeSmallTemplate.ImageList = this.imageList1;
            this.advTreeSmallTemplate.Location = new System.Drawing.Point(0, 27);
            this.advTreeSmallTemplate.Name = "advTreeSmallTemplate";
            this.advTreeSmallTemplate.PathSeparator = "〓";
            this.advTreeSmallTemplate.SelectedImageIndex = 0;
            this.advTreeSmallTemplate.Size = new System.Drawing.Size(361, 283);
            this.advTreeSmallTemplate.TabIndex = 1;
            // 
            // frmUpdateParentNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 380);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateParentNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpdateParentNode_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Panel panel1;
        private uc_TreeView advTreeSmallTemplate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtComplexName;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbnTitle;
        private System.Windows.Forms.RadioButton rbnDirector;
        private System.Windows.Forms.RadioButton rbnDirectAndCont;
        private System.Windows.Forms.ImageList imageList1;
    }
}