using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bifrost
{
    /// <summary>
    /// 进程等待显示
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
	public class FrmProgress :Form
	{		
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public FrmProgress()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgress));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(80, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请稍后...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmProgress
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 67);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmProgress";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.objFrmProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void objFrmProgress_Load(object sender, System.EventArgs e)
		{
      
		}
	}
}
