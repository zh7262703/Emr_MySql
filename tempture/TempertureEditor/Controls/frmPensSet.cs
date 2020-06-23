using System;
using System.Drawing;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    /// <summary>
    /// 画笔设置
    /// </summary>
    public partial class frmPensSet : Form
    {

        private string _id; //主键      
        SolidBrush Brush;
        Color bcolor;
        Pen pn;
        Comm cm = null;
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public frmPensSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
            lblId.Text = "画笔ID：" + Id.ToString();

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();           

            txtColor.Text = colorDialog1.Color.R.ToString() + "," +
                            colorDialog1.Color.G.ToString() + "," +
                            colorDialog1.Color.B.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsPens temppen = new ClsPens();
                temppen.Id = Id.ToString();
                temppen.Pencolor = cm.GetColorByStr(txtColor.Text);
                temppen.Pensize = Convert.ToSingle(txtWidth.Text);
                temppen.Tname = txtTname.Text;
                cm.newnode = new TreeNode();
                cm.newnode.Text ="画笔-"+Id.ToString();
                if (txtTname.Text.Trim() != "")
                {
                    cm.newnode.Text = txtTname.Text;
                }
              
                cm.newnode.Name = Id.ToString();
                cm.newnode.Tag = temppen;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                bcolor = Color.FromArgb(Convert.ToInt16(txtColor.Text.Split(',')[0]),
                                              Convert.ToInt16(txtColor.Text.Split(',')[1]),
                                              Convert.ToInt16(txtColor.Text.Split(',')[2]));
                Brush = new SolidBrush(bcolor);
                pn = new Pen(bcolor, Convert.ToSingle(txtWidth.Text));

                e.Graphics.DrawLine(pn, 10, 10, 100, 10);
            }
            catch
            { }
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Refresh();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Refresh();
        }

        private void frmPensSet_Load(object sender, EventArgs e)
        {

        }
    }
}
