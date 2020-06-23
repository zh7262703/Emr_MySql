using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bifrost
{
	/// <summary>
	/// Summary description for AlertCustom.
	/// </summary>
	public class AlertCustom : DevComponents.DotNetBar.Balloon
	{
		private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
		private DevComponents.DotNetBar.Bar bar1;
		private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.LabelX lblTittle;
        private string LinkAddress;
        private DevComponents.DotNetBar.LabelX lblMsg; //连接地址

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AlertCustom()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        /// <summary>
        /// 消息提示
        /// </summary>
        /// <param name="Msg"></param>
        public AlertCustom(string tittle,string Msg,string LinkUrl)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            if (tittle.Trim() != "")
            {
                lblTittle.Text = tittle;
            }           
            lblMsg.Text = Msg;
            LinkAddress = LinkUrl;
        }

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertCustom));
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.lblTittle = new DevComponents.DotNetBar.LabelX();
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // reflectionImage1
            // 
            this.reflectionImage1.BackColor = System.Drawing.Color.Transparent;
            this.reflectionImage1.Image = ((System.Drawing.Image)(resources.GetObject("reflectionImage1.Image")));
            this.reflectionImage1.Location = new System.Drawing.Point(10, 9);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(76, 107);
            this.reflectionImage1.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2});
            this.bar1.Location = new System.Drawing.Point(0, 111);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(345, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImagePaddingHorizontal = 8;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ImagePaddingHorizontal = 8;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            // 
            // lblTittle
            // 
            this.lblTittle.BackColor = System.Drawing.Color.Transparent;
            this.lblTittle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTittle.Location = new System.Drawing.Point(106, 12);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(108, 18);
            this.lblTittle.TabIndex = 2;
            this.lblTittle.Text = "<b>信息提示</b>";
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Location = new System.Drawing.Point(106, 36);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(220, 88);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "Using Balloon and other controls included with DotNetBar you can create great loo" +
                "king custom alerts.";
            this.lblMsg.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lblMsg.WordWrap = true;
            this.lblMsg.Click += new System.EventHandler(this.lblMsg_Click);
            this.lblMsg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMsg_MouseClick);
            this.lblMsg.MouseEnter += new System.EventHandler(this.lblMsg_MouseEnter);
            this.lblMsg.MouseLeave += new System.EventHandler(this.lblMsg_MouseLeave);
            // 
            // AlertCustom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(345, 136);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblTittle);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.reflectionImage1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(55)))), ((int)(((byte)(114)))));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AlertCustom";
            this.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert;
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.devcomponents.com");
		}

        private void lblMsg_Click(object sender, EventArgs e)
        {
            if (LinkAddress != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(LinkAddress);
                }
                catch
                { 
                }
            }
            
        }

        private void lblMsg_MouseEnter(object sender, EventArgs e)
        {
            if (LinkAddress != "")
            {
                lblMsg.Font = new Font("宋体", 9, FontStyle.Underline);
                lblMsg.ForeColor = Color.Red;
                lblMsg.Cursor = Cursors.Hand;               
            }
            else
            {
                lblMsg.Font = new Font("宋体", 9);
                lblMsg.ForeColor=System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(55)))), ((int)(((byte)(114)))));
                lblMsg.Cursor = Cursors.Arrow;             
            }
        }

        private void lblMsg_MouseLeave(object sender, EventArgs e)
        {
            lblMsg.Font = new Font("宋体", 9);
            lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(55)))), ((int)(((byte)(114)))));
        }

        private void lblMsg_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
	}
}
