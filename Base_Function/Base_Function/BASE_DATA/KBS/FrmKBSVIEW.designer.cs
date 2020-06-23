namespace Base_Function.BASE_DATA.KBS
{
    partial class FrmKBSVIEW
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
            this.tabSmallTemplate = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabBigTemplate = new DevComponents.DotNetBar.TabItem(this.components);
            this.SuspendLayout();
            // 
            // tabSmallTemplate
            // 
            this.tabSmallTemplate.Name = "tabSmallTemplate";
            this.tabSmallTemplate.Text = "小模板";
            // 
            // tabBigTemplate
            // 
            this.tabBigTemplate.Name = "tabBigTemplate";
            this.tabBigTemplate.Text = "";
            // 
            // FrmKBSVIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 368);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmKBSVIEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "知识库";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabItem tabSmallTemplate;
        private DevComponents.DotNetBar.TabItem tabBigTemplate;
    }
}