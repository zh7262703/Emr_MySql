namespace Bifrost.Speech
{
    partial class frmLearn
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOver = new System.Windows.Forms.Button();
            this.btnReSet = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前识别：";
            // 
            // txtOld
            // 
            this.txtOld.BackColor = System.Drawing.Color.White;
            this.txtOld.Location = new System.Drawing.Point(25, 33);
            this.txtOld.Multiline = true;
            this.txtOld.Name = "txtOld";
            this.txtOld.ReadOnly = true;
            this.txtOld.Size = new System.Drawing.Size(580, 103);
            this.txtOld.TabIndex = 1;
            this.txtOld.TextChanged += new System.EventHandler(this.txtOld_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "修改纠正：";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(25, 170);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(580, 21);
            this.txtNew.TabIndex = 3;
            this.txtNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNew_KeyDown);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(614, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 26);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "说话";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOver
            // 
            this.btnOver.Enabled = false;
            this.btnOver.Location = new System.Drawing.Point(614, 65);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(59, 26);
            this.btnOver.TabIndex = 5;
            this.btnOver.Text = "结束";
            this.btnOver.UseVisualStyleBackColor = true;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // btnReSet
            // 
            this.btnReSet.Location = new System.Drawing.Point(614, 97);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(59, 26);
            this.btnReSet.TabIndex = 6;
            this.btnReSet.Text = "重置";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new System.EventHandler(this.btnReSet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 26);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLearn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 218);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.btnOver);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLearn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音学习积累";
            this.Activated += new System.EventHandler(this.frmLearn_Activated);
            this.Load += new System.EventHandler(this.frmLearn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOver;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.Button btnSave;
    }
}