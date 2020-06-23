namespace Bifrost
{
    partial class TextEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEdit));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxName = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonBold = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonItalic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorFont = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCenter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFull = new System.Windows.Forms.ToolStripButton();
            this.rtxtEdit = new System.Windows.Forms.RichTextBox();
            this.toolStripToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MTS.ico");
            this.imageList1.Images.SetKeyName(1, "APPTL.ICO");
            this.imageList1.Images.SetKeyName(2, "COMMIT.ICO");
            this.imageList1.Images.SetKeyName(3, "DB_Refresh.ico");
            this.imageList1.Images.SetKeyName(4, "DB_Save.ico");
            this.imageList1.Images.SetKeyName(5, "DB_User.ico");
            this.imageList1.Images.SetKeyName(6, "Provider.ico");
            this.imageList1.Images.SetKeyName(7, "StoredProcWiz.ico");
            this.imageList1.Images.SetKeyName(8, "UPDATE.ICO");
            this.imageList1.Images.SetKeyName(9, "controls1.ico");
            this.imageList1.Images.SetKeyName(10, "controls2.ico");
            this.imageList1.Images.SetKeyName(11, "controls3.ico");
            this.imageList1.Images.SetKeyName(12, "controls4.ico");
            this.imageList1.Images.SetKeyName(13, "controls5.ico");
            this.imageList1.Images.SetKeyName(14, "file.ico");
            this.imageList1.Images.SetKeyName(15, "MAIL14.ICO");
            this.imageList1.Images.SetKeyName(16, "NOTEPA~1.ICO");
            this.imageList1.Images.SetKeyName(17, "NOTEPA~2.ICO");
            this.imageList1.Images.SetKeyName(18, "NOTEPA~3.ICO");
            this.imageList1.Images.SetKeyName(19, "NOTEPA~4.ICO");
            // 
            // toolStripToolBar
            // 
            this.toolStripToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxName,
            this.toolStripComboBoxSize,
            this.toolStripButtonBold,
            this.toolStripButtonItalic,
            this.toolStripButtonUnderline,
            this.toolStripButtonColor,
            this.toolStripSeparatorFont,
            this.toolStripButtonLeft,
            this.toolStripButtonCenter,
            this.toolStripButtonRight,
            this.toolStripButtonFull});
            this.toolStripToolBar.Location = new System.Drawing.Point(0, 0);
            this.toolStripToolBar.Name = "toolStripToolBar";
            this.toolStripToolBar.Size = new System.Drawing.Size(565, 25);
            this.toolStripToolBar.TabIndex = 2;
            this.toolStripToolBar.Text = "Tool Bar";
            // 
            // toolStripComboBoxName
            // 
            this.toolStripComboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxName.MaxDropDownItems = 30;
            this.toolStripComboBoxName.Name = "toolStripComboBoxName";
            this.toolStripComboBoxName.Size = new System.Drawing.Size(100, 25);
            this.toolStripComboBoxName.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxName_SelectedIndexChanged);
            this.toolStripComboBoxName.Click += new System.EventHandler(this.toolStripComboBoxName_Click);
            // 
            // toolStripComboBoxSize
            // 
            this.toolStripComboBoxSize.AutoSize = false;
            this.toolStripComboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxSize.Name = "toolStripComboBoxSize";
            this.toolStripComboBoxSize.Size = new System.Drawing.Size(36, 20);
            this.toolStripComboBoxSize.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSize_SelectedIndexChanged);
            this.toolStripComboBoxSize.Click += new System.EventHandler(this.toolStripComboBoxSize_Click);
            // 
            // toolStripButtonBold
            // 
            this.toolStripButtonBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBold.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBold.Image")));
            this.toolStripButtonBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBold.Name = "toolStripButtonBold";
            this.toolStripButtonBold.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBold.Text = "Bold";
            this.toolStripButtonBold.Click += new System.EventHandler(this.toolStripButtonBold_Click);
            // 
            // toolStripButtonItalic
            // 
            this.toolStripButtonItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonItalic.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonItalic.Image")));
            this.toolStripButtonItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonItalic.Name = "toolStripButtonItalic";
            this.toolStripButtonItalic.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonItalic.Text = "Italic";
            this.toolStripButtonItalic.Click += new System.EventHandler(this.toolStripButtonItalic_Click);
            // 
            // toolStripButtonUnderline
            // 
            this.toolStripButtonUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUnderline.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUnderline.Image")));
            this.toolStripButtonUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUnderline.Name = "toolStripButtonUnderline";
            this.toolStripButtonUnderline.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUnderline.Text = "Underline";
            this.toolStripButtonUnderline.Click += new System.EventHandler(this.toolStripButtonUnderline_Click);
            // 
            // toolStripButtonColor
            // 
            this.toolStripButtonColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonColor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColor.Image")));
            this.toolStripButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor.Name = "toolStripButtonColor";
            this.toolStripButtonColor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonColor.Text = "Font Color";
            this.toolStripButtonColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);
            // 
            // toolStripSeparatorFont
            // 
            this.toolStripSeparatorFont.Name = "toolStripSeparatorFont";
            this.toolStripSeparatorFont.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLeft
            // 
            this.toolStripButtonLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLeft.Image")));
            this.toolStripButtonLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLeft.Name = "toolStripButtonLeft";
            this.toolStripButtonLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLeft.Text = "Align Left";
            this.toolStripButtonLeft.Click += new System.EventHandler(this.toolStripButtonLeft_Click);
            // 
            // toolStripButtonCenter
            // 
            this.toolStripButtonCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCenter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCenter.Image")));
            this.toolStripButtonCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCenter.Name = "toolStripButtonCenter";
            this.toolStripButtonCenter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCenter.Text = "Center";
            this.toolStripButtonCenter.Click += new System.EventHandler(this.toolStripButtonCenter_Click);
            // 
            // toolStripButtonRight
            // 
            this.toolStripButtonRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRight.Image")));
            this.toolStripButtonRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRight.Name = "toolStripButtonRight";
            this.toolStripButtonRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRight.Text = "Align Right";
            this.toolStripButtonRight.Click += new System.EventHandler(this.toolStripButtonRight_Click);
            // 
            // toolStripButtonFull
            // 
            this.toolStripButtonFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFull.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFull.Image")));
            this.toolStripButtonFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFull.Name = "toolStripButtonFull";
            this.toolStripButtonFull.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFull.Text = "Justify";
            // 
            // rtxtEdit
            // 
            this.rtxtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtEdit.Location = new System.Drawing.Point(0, 25);
            this.rtxtEdit.Name = "rtxtEdit";
            this.rtxtEdit.Size = new System.Drawing.Size(565, 434);
            this.rtxtEdit.TabIndex = 3;
            this.rtxtEdit.Text = "";
            // 
            // TextEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxtEdit);
            this.Controls.Add(this.toolStripToolBar);
            this.Name = "TextEdit";
            this.Size = new System.Drawing.Size(565, 459);
            this.Load += new System.EventHandler(this.TextEdit_Load);
            this.toolStripToolBar.ResumeLayout(false);
            this.toolStripToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStripToolBar;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxName;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSize;
        private System.Windows.Forms.ToolStripButton toolStripButtonBold;
        private System.Windows.Forms.ToolStripButton toolStripButtonItalic;
        private System.Windows.Forms.ToolStripButton toolStripButtonUnderline;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonCenter;
        private System.Windows.Forms.ToolStripButton toolStripButtonRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonFull;
        private System.Windows.Forms.RichTextBox rtxtEdit;

    }
}
