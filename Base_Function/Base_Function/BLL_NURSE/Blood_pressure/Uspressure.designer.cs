namespace Base_Function.BLL_NURSE.Blood_pressure
{
    partial class Uspressure
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtvalue2 = new System.Windows.Forms.TextBox();
            this.txtvalue1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "/";
            // 
            // txtvalue2
            // 
            this.txtvalue2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtvalue2.Location = new System.Drawing.Point(52, 6);
            this.txtvalue2.Name = "txtvalue2";
            this.txtvalue2.Size = new System.Drawing.Size(33, 21);
            this.txtvalue2.TabIndex = 2;
            // 
            // txtvalue1
            // 
            this.txtvalue1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtvalue1.Location = new System.Drawing.Point(6, 5);
            this.txtvalue1.Name = "txtvalue1";
            this.txtvalue1.Size = new System.Drawing.Size(33, 21);
            this.txtvalue1.TabIndex = 3;
            // 
            // Uspressure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtvalue1);
            this.Controls.Add(this.txtvalue2);
            this.Controls.Add(this.label1);
            this.Name = "Uspressure";
            this.Size = new System.Drawing.Size(90, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvalue2;
        private System.Windows.Forms.TextBox txtvalue1;
    }
}
