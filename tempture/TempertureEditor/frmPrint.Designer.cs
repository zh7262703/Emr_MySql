namespace TempertureEditor  
{
    partial class frmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.ucTemperturePrint1 = new TempertureEditor.ucTemperturePrint(this.cm);
            this.SuspendLayout();
            // 
            // ucTemperturePrint1
            // 
            this.ucTemperturePrint1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemperturePrint1.Location = new System.Drawing.Point(0, 0);
            this.ucTemperturePrint1.Name = "ucTemperturePrint1";
            this.ucTemperturePrint1.Size = new System.Drawing.Size(674, 377);
            this.ucTemperturePrint1.TabIndex = 0;
            this.ucTemperturePrint1.Load += new System.EventHandler(this.ucTemperturePrint1_Load);
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 377);
            this.Controls.Add(this.ucTemperturePrint1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印预览";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTemperturePrint ucTemperturePrint1;
    }
}