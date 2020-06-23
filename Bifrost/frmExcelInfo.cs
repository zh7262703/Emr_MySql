using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bifrost
{
	/// <summary>
	/// frmExcelInfo 的摘要说明。
	/// </summary>
	public class frmExcelInfo :DevComponents.DotNetBar.Office2007Form
	{
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.ComboBox cmbTableName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DevComponents.DotNetBar.ButtonX btnDialog;
        private DevComponents.DotNetBar.ButtonX btnSure;

		private int flag=0;

        /// <summary>
        /// 构造函数
        /// </summary>
		public frmExcelInfo()
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
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDialog = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(56, 16);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.ReadOnly = true;
            this.txtExcelPath.Size = new System.Drawing.Size(200, 21);
            this.txtExcelPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "路径:";
            // 
            // cmbTableName
            // 
            this.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableName.Location = new System.Drawing.Point(56, 48);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(200, 20);
            this.cmbTableName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "表名:";
            // 
            // btnDialog
            // 
            this.btnDialog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDialog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDialog.Location = new System.Drawing.Point(262, 14);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(41, 22);
            this.btnDialog.TabIndex = 6;
            this.btnDialog.Text = "...";
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(262, 46);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(41, 22);
            this.btnSure.TabIndex = 7;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // frmExcelInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(316, 93);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.cmbTableName);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExcelInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "读取Excel条件设置";
            this.Load += new System.EventHandler(this.frmExcelInfo_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmExcelInfo_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion		


		private void btnDialog_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Filter="Excel文件类型|*.xls";
			if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			{
                App.ExcelFileName=openFileDialog1.FileName;
				this.txtExcelPath.Text=App.ExcelFileName;
				cmbTableName.Items.Clear();
				App.GetExcelTableName(App.ExcelFileName,this.cmbTableName);
				if(cmbTableName.Items.Count>0)
				{
                   cmbTableName.SelectedIndex=0;
				}
			}
		}

		private void frmExcelInfo_Load(object sender, System.EventArgs e)
		{
            App.FormStytleSet(this, false);
		}

		private void btnSure_Click(object sender, System.EventArgs e)
		{			
		    App.tableName=cmbTableName.Text;
			this.flag=1;
			this.Close();
		}

		private void frmExcelInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.flag==0)
			{
				App.ExcelFileName="";
				App.tableName="";
			}
		}
	}
}
