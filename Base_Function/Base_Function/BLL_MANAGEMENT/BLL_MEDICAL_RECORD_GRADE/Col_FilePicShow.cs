using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class Col_FilePicShow : UserControl
    {
        private string imagePath = "";
        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public Col_FilePicShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新空间中显示的内容
        /// </summary>
        public void ReFreshing()
        {
            this.fileShow_PicBox.Image = image;            
        }

        private void FilePicShow_UserCol_Load(object sender, EventArgs e)
        {
            this.fileShow_PicBox.Image = image;             
        }

        private void FilePicShow_UserCol_Paint(object sender, PaintEventArgs e)
        {
            this.FilePicShow_UserCol_Load(null,null);
        }

        private void fileShow_PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.Parent.Focus();
        }

        private void fileShow_PicBox_MouseEnter(object sender, EventArgs e)
        {
            this.Parent.Focus();
        }



        
    }
}
