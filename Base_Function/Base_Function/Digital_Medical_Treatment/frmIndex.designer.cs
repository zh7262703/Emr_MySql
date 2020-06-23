namespace Digital_Medical_Treatment
{
    partial class frmIndex
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
            this.btnConfig = new DevComponents.DotNetBar.ButtonX();
            this.btnDoctor = new DevComponents.DotNetBar.ButtonX();
            this.btnNurse = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnConfig.Location = new System.Drawing.Point(67, 149);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(88, 70);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "护理看板配置";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDoctor.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnDoctor.Location = new System.Drawing.Point(349, 149);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(88, 70);
            this.btnDoctor.TabIndex = 2;
            this.btnDoctor.Text = "医生看板";
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnNurse
            // 
            this.btnNurse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNurse.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnNurse.Location = new System.Drawing.Point(255, 149);
            this.btnNurse.Name = "btnNurse";
            this.btnNurse.Size = new System.Drawing.Size(88, 70);
            this.btnNurse.TabIndex = 3;
            this.btnNurse.Text = "护士看板";
            this.btnNurse.Click += new System.EventHandler(this.btnNurse_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnEdit.Location = new System.Drawing.Point(161, 149);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 70);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "备注编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX1.Location = new System.Drawing.Point(443, 149);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(88, 70);
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "病情讨论";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(541, 338);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNurse);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmIndex";
            this.Size = new System.Drawing.Size(541, 338);
            this.Load += new System.EventHandler(this.frmIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnConfig;
        private DevComponents.DotNetBar.ButtonX btnDoctor;
        private DevComponents.DotNetBar.ButtonX btnNurse;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}