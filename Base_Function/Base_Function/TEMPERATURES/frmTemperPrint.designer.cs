namespace Base_Function.TEMPERATURES
{
    partial class frmTemperPrint
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
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.SuspendLayout();
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1页视图";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2页视图";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3页视图";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "4页视图";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImagePaddingHorizontal = 8;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "buttonItem2";
            // 
            // frmTemperPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 638);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTemperPrint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体温打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTemperPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;

    }
}

