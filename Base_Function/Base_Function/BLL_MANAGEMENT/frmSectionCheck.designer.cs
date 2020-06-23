using Base_Function.BASE_COMMON;
namespace Base_Function.BLL_MANAGEMENT
{
    partial class frmSectionCheck
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
            this.chkSectionListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.selectForCSC1 = new SelectForCSC(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSectionListBox
            // 
            this.chkSectionListBox.CheckOnClick = true;
            this.chkSectionListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSectionListBox.FormattingEnabled = true;
            this.chkSectionListBox.HorizontalScrollbar = true;
            this.chkSectionListBox.Location = new System.Drawing.Point(3, 19);
            this.chkSectionListBox.MultiColumn = true;
            this.chkSectionListBox.Name = "chkSectionListBox";
            this.chkSectionListBox.Size = new System.Drawing.Size(625, 346);
            this.chkSectionListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnClean);
            this.groupBox1.Controls.Add(this.btnInverse);
            this.groupBox1.Controls.Add(this.btnAllSelect);
            this.groupBox1.Controls.Add(this.chkSectionListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 415);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "科室列表";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(103, 373);
            this.btnSave.Name = "btnSave";
            this.selectForCSC1.SetSelectionSource(this.btnSave, null);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(427, 373);
            this.btnClose.Name = "btnClose";
            this.selectForCSC1.SetSelectionSource(this.btnClose, null);
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(346, 373);
            this.btnClean.Name = "btnClean";
            this.selectForCSC1.SetSelectionSource(this.btnClean, this.chkSectionListBox);
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "清空";
            this.btnClean.UseVisualStyleBackColor = true;
            // 
            // btnInverse
            // 
            this.btnInverse.Location = new System.Drawing.Point(265, 373);
            this.btnInverse.Name = "btnInverse";
            this.selectForCSC1.SetSelectionSource(this.btnInverse, this.chkSectionListBox);
            this.selectForCSC1.SetSelectionType(this.btnInverse, SelectionTypes.反选);
            this.btnInverse.Size = new System.Drawing.Size(75, 23);
            this.btnInverse.TabIndex = 2;
            this.btnInverse.Text = "反选";
            this.btnInverse.UseVisualStyleBackColor = true;
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(184, 373);
            this.btnAllSelect.Name = "btnAllSelect";
            this.selectForCSC1.SetSelectionSource(this.btnAllSelect, this.chkSectionListBox);
            this.selectForCSC1.SetSelectionType(this.btnAllSelect, SelectionTypes.全选);
            this.btnAllSelect.Size = new System.Drawing.Size(75, 23);
            this.btnAllSelect.TabIndex = 1;
            this.btnAllSelect.Text = "全选";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            // 
            // frmSectionCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 415);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSectionCheck";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "起效科室选择";
            this.Load += new System.EventHandler(this.frmSectionCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkSectionListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.Button btnClose;
        private SelectForCSC selectForCSC1;
        private System.Windows.Forms.Button btnSave;
    }
}