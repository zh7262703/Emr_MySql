using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class UcMerger : UserControl
    {
        /// <summary>
        /// 医务处，护理部标志
        /// </summary>
        private string Name;

        Image img_yel;
        Image img_red;
        private bool Flag = false;
        /// <summary>
        /// 是否显示医生Page
        /// </summary>
        private bool IsVisDoctor = false;
        /// <summary>
        /// 是否质控提醒界面查询
        /// </summary>
        private bool IsQualityAlert = false;
        public UcMerger()
        {
            InitializeComponent();
        }
        public UcMerger(string doc_name,int yelNum,Image imgYel,int redNum,Image imgRed,string name)
        {
            InitializeComponent();
            this.img_yel = imgYel;
            this.img_red = imgRed;
            this.Name = name;
            this.lblDocName.Text = doc_name;
            lblYel.Text = yelNum.ToString();
            lblRed.Text = redNum.ToString();
            pbxYel.Image = imgYel;
            pbxRed.Image = imgRed;
            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width-10;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;
            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label2.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label2.Location.Y);
            lblRed.Location = new Point(label2.Location.X + label2.Width + 1, lblRed.Location.Y);
            pbxRed.Location = new Point(lblRed.Location.X + lblRed.Width + 1, pbxRed.Location.Y);
            label1.Location = new Point(pbxRed.Location.X + pbxRed.Width + 1, label1.Location.Y);
        }

        public UcMerger(bool IsQA,string doc_name, int yelNum, Image imgYel, int redNum, Image imgRed, string name)
        {
            InitializeComponent();
            this.IsQualityAlert = IsQA;
            this.img_yel = imgYel;
            this.img_red = imgRed;
            this.Name = name;
            this.lblDocName.Text = doc_name;
            lblYel.Text = yelNum.ToString();
            lblRed.Text = redNum.ToString();
            pbxYel.Image = imgYel;
            pbxRed.Image = imgRed;
            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 10;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;
            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label2.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label2.Location.Y);
            lblRed.Location = new Point(label2.Location.X + label2.Width + 1, lblRed.Location.Y);
            pbxRed.Location = new Point(lblRed.Location.X + lblRed.Width + 1, pbxRed.Location.Y);
            label1.Location = new Point(pbxRed.Location.X + pbxRed.Width + 1, label1.Location.Y);
        }

        public UcMerger(bool isVisable,bool IsQA,string doc_name, int yelNum, Image imgYel, int redNum, Image imgRed, string name)
        {
            InitializeComponent();
            this.IsVisDoctor = isVisable;
            this.IsQualityAlert = IsQA;
            this.img_yel = imgYel;
            this.img_red = imgRed;
            this.Name = name;
            this.lblDocName.Text = doc_name;
            lblYel.Text = yelNum.ToString();
            lblRed.Text = redNum.ToString();
            pbxYel.Image = imgYel;
            pbxRed.Image = imgRed;
            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 10;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;
            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label2.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label2.Location.Y);
            lblRed.Location = new Point(label2.Location.X + label2.Width + 1, lblRed.Location.Y);
            pbxRed.Location = new Point(lblRed.Location.X + lblRed.Width + 1, pbxRed.Location.Y);
            label1.Location = new Point(pbxRed.Location.X + pbxRed.Width + 1, label1.Location.Y);
        }

        public UcMerger(string doc_name, int yelNum, Image imgYel, int redNum, Image imgRed, string name,bool flag)
        {
            InitializeComponent();
            this.img_yel = imgYel;
            this.img_red = imgRed;
            this.Name = name;
            this.lblDocName.Text = doc_name;
            lblYel.Text = yelNum.ToString();
            lblRed.Text = redNum.ToString();
            pbxYel.Image = imgYel;
            pbxRed.Image = imgRed;
            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 10;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;
            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label2.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label2.Location.Y);
            lblRed.Location = new Point(label2.Location.X + label2.Width + 1, lblRed.Location.Y);
            pbxRed.Location = new Point(lblRed.Location.X + lblRed.Width + 1, pbxRed.Location.Y);
            label1.Location = new Point(pbxRed.Location.X + pbxRed.Width + 1, label1.Location.Y);
            this.Flag = flag;
        }

        private void UcMerger_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void UcMerger_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void UcMerger_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void UcMerger_DoubleClick(object sender, EventArgs e)
        {
            if (!this.IsQualityAlert)
            {//不是质控提醒进入
                if (!Flag)
                {
                    Class_Record_Monitor_View q = (Class_Record_Monitor_View)this.Tag;
                    frmHint f;
                    if (IsVisDoctor)
                    {
                        f = new frmHint(false, q, Name, true, img_yel, img_red);
                    }
                    else
                    {
                        f = new frmHint(q, Name, true, img_yel, img_red);
                    }
                    f.ShowDialog();
                }
                else
                {
                    if (this.Parent.Parent.Parent.GetType().Name.Contains("frmHint"))
                    {
                        frmHint frmhint = this.Parent.Parent.Parent as frmHint;
                        frmhint.uc_DoubleClick(lblDocName.Text);
                    }
                }
            }
        }
        public string GetBDEvent()
        {
            return lblDocName.Text;
        }
    }
}
