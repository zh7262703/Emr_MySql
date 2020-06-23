using Bifrost;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Element;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor.EditDesigner
{
    class ucTemperatureReport : UserControl
    {
        private PrintTp pt = new PrintTp(); //体温单的绘制对象

        public Page currentPage = new Page();
        public Comm cm = new Comm();
        private PictureBox pictureBox1;



        #region 组件设计器生成的代码
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
        #endregion

        public ucTemperatureReport(string tfilename)
        {
            InitializeComponent();

            UpdateTmbFileName(tfilename);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(26, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 88);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // ucTemperatureReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucTemperatureReport";
            this.SizeChanged += new System.EventHandler(this.ucTemperatureReport_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentPage.Objs != null)
            {
                if (currentPage.Objs.Count == 0)
                {
                    pt.TemperturePaintInterface(e.Graphics, null);
                }
                else
                {
                    pt.TemperturePaintInterface(e.Graphics, currentPage);
                }
            }


            GC.Collect();

        }

        private void ucTemperatureReport_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, -this.VerticalScroll.Value);
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Focus();   //鼠标在控件上点击时，需要处理获得焦点，因为默认不会获得焦点       
        }

        #region 自定义方法

        public void UpdateTmbFileName(string tfilename)
        {
            cm.startini(tfilename); //体温单初始化;
            pt.cm = cm;

            currentPage.Objs = new List<ClsDataObj>();

            pictureBox1.Width = cm.MaxWidth;
            pictureBox1.Height = cm.MaxHeight + 100;
        }

        public void RefreshData(string startDate, string endDate, InPatientInfo tPatInfo, string pageNumber, DateTime? outTime, string templateType)
        {
            currentPage.Objs.Clear();
            currentPage.Starttime = startDate + " 00:00:00";
            currentPage.Endtime = endDate + " 23:59:59";
            //模板赋值
            tempetureDataComm.GetPageContentByPageObj(tPatInfo, ref currentPage, pageNumber, outTime, ref cm, templateType);

            pictureBox1.Refresh();
        }

        #endregion
    }
}
