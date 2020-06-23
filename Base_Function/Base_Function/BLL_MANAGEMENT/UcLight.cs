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
    public partial class UcLight : UserControl
    {
        private string Name;
        private bool Flag = false;
        Image img_light;
        /// <summary>
        /// 是否显示医生Page
        /// </summary>
        private bool IsVisDoctor = false;
        /// <summary>
        /// 是否质控提醒界面查询
        /// </summary>
        private bool IsQualityAlert = false;
        public UcLight()
        {
            InitializeComponent();
        }
        public UcLight(string doc_name,int lightNum,Image light,string name)
        {
            InitializeComponent();
            Graphics gh = Graphics.FromHwnd(this.Handle);
            this.img_light = light;
            this.Name = name;
            pbxYel.Image = light;
            lblDocName.Text = doc_name;
            lblYel.Text = lightNum.ToString();

            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width-4;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;

            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label1.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label1.Location.Y);
        }

        public UcLight(bool IsQA, string doc_name, int lightNum, Image light, string name)
        {
            InitializeComponent();
            
            Graphics gh = Graphics.FromHwnd(this.Handle);
            this.IsQualityAlert = IsQA;
            this.img_light = light;
            this.Name = name;
            pbxYel.Image = light;
            lblDocName.Text = doc_name;
            lblYel.Text = lightNum.ToString();

            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 4;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;

            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label1.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label1.Location.Y);
        }

        public UcLight(bool IsDoctor, bool IsQA, string doc_name, int lightNum, Image light, string name)
        {
            InitializeComponent();
            Graphics gh = Graphics.FromHwnd(this.Handle);
            this.IsVisDoctor = IsDoctor;
            this.IsQualityAlert = IsQA;
            this.img_light = light;
            this.Name = name;
            pbxYel.Image = light;
            lblDocName.Text = doc_name;
            lblYel.Text = lightNum.ToString();

            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 4;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;

            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label1.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label1.Location.Y);
        }


        public UcLight(string doc_name, int lightNum, Image light, string name,bool flag)
        {
            InitializeComponent();
            this.img_light = light;
            this.Name = name;
            pbxYel.Image = light;
            lblDocName.Text = doc_name;
            lblYel.Text = lightNum.ToString();
            Point pt = new Point();
            pt.X = lblDocName.Location.X + lblDocName.Width - 4;
            pt.Y = lblDocName.Location.Y;
            panel1.Location = pt;
            this.Flag = flag;
            pbxYel.Location = new Point(lblYel.Location.X + lblYel.Width + 1, pbxYel.Location.Y);
            label1.Location = new Point(pbxYel.Location.X + pbxYel.Width + 1, label1.Location.Y);
        }

        private void UcLight_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void UcLight_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void UcLight_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void UcLight_DoubleClick(object sender, EventArgs e)
        {
            if (!IsQualityAlert)
            {//质控提醒界面进入
                if (!Flag)
                {
                    Class_Record_Monitor_View q = (Class_Record_Monitor_View)this.Tag;
                    if (q.PV != 3)
                    {
                        frmHint f = new frmHint(q, Name, img_light);
                        f.ShowDialog();
                    }
                    else
                    {
                        frmHint f = new frmHint(q, Name, img_light, IsVisDoctor);
                        f.ShowDialog();
                    }
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
