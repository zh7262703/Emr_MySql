namespace Base_Function.BLL_DOCTOR
{
    partial class frmSpecialSectionAction
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
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Location = new System.Drawing.Point(63, 25);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(180, 21);
            this.comboBoxEx1.TabIndex = 0;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(63, 61);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(144, 61);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(28, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "转到：";
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Owner = this;
            // 
            // frmSpecialSectionAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 106);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpecialSectionAction";
            this.Text = "特殊科室手动转科";
            this.Load += new System.EventHandler(this.frmSpecialSectionAction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
    }
}