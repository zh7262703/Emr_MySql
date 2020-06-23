using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmImgSet : Form
    {
        private string Id;
        Bitmap Img;
        Bitmap cImg;
        Comm cm = null;
        public frmImgSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                ClsImg tempImg = new ClsImg();
                tempImg.Id = Id;
                tempImg.Imgname= System.IO.Path.GetFileName(txtImgPath.Text);
                tempImg.Img = Img;
                tempImg.X = Convert.ToInt16(numD_x1.Value);
                tempImg.Y = Convert.ToInt16(numD_y1.Value);
                tempImg.Pwidth= Convert.ToInt16(numD_Width.Value);
                tempImg.Pheight = Convert.ToInt16(numD_Hight.Value);

                //string bytstr = cm.GetImgStr((Bitmap)pictureBox1.Image);
                cm.newnode = new TreeNode();
                cm.newnode.Name = Id.ToString();
                cm.newnode.Text = "img-"+ Id.ToString();
                cm.newnode.Tag = tempImg;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }
            //Image.FromStream(new MemoryStream(bmpBytes))
        }

        private void frmImgSet_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件 jpg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";
        }

        private void btnPicChoose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImgPath.Text = openFileDialog1.FileName;
                Img = new Bitmap(txtImgPath.Text);
                cImg = new Bitmap(txtImgPath.Text);
                //this.pictureBox1.Image = (Bitmap)Img.Clone();
                numD_x1.Value = 0;
                numD_y1.Value = 0;
                pictureBox1.Width = Img.Width;
                pictureBox1.Height = Img.Height;
                numD_Width.Value = Img.Width;
                numD_Hight.Value = Img.Height;
                pictureBox1.Refresh();
            } 
        }

        private void numD_Width_ValueChanged(object sender, EventArgs e)
        {
            Bitmap tempimg = cm.GetThumbnail((Bitmap)Img.Clone(), Convert.ToInt16(numD_Width.Value), Convert.ToInt16(numD_Hight.Value));
            if (tempimg != null)
                cImg = tempimg;
            else
                cImg = (Bitmap)Img.Clone();
            pictureBox1.Image = cImg;
            //pictureBox1.Width = cImg.Width;
            //pictureBox1.Height = cImg.Height;       
        }

        private void numD_Hight_ValueChanged(object sender, EventArgs e)
        {
            Bitmap tempimg = cm.GetThumbnail((Bitmap)Img.Clone(), Convert.ToInt16(numD_Width.Value), Convert.ToInt16(numD_Hight.Value));
            if (tempimg != null)
                cImg = tempimg;
            else
                cImg = (Bitmap)Img.Clone();
            pictureBox1.Image = cImg;
            //pictureBox1.Width = cImg.Width;
            //pictureBox1.Height = cImg.Height;


           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    pictureBox1.Width = cImg.Width;
            //    pictureBox1.Height = cImg.Height;
            //    e.Graphics.DrawImage((Bitmap)cImg, 0,
            //        0,
            //        Convert.ToSingle(numD_Width.Value),
            //        Convert.ToSingle(numD_Hight.Value));
            //}
            //catch
            //{ }
        }
    }
}
