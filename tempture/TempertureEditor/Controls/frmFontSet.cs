using System;
using System.Drawing;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmFontSet : Form
    {
        private string _id;
        private string TestStr = "测试文字 test 123456";
        SolidBrush Brush;
        Color fontcolor;
        Font ft;
        Comm cm = null;
        public frmFontSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
            
        }

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

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            //int red = colorDialog1.Color.R;
            //int green = colorDialog1.Color.G;
            //int blue = colorDialog1.Color.B;

            txtColor.Text = colorDialog1.Color.R.ToString() + "," +
                            colorDialog1.Color.G.ToString() + "," +
                            colorDialog1.Color.B.ToString();
        }

        private void frmFontSet_Load(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Text.InstalledFontCollection font; //安装在系统的所有字体，无法继承  
                font = new System.Drawing.Text.InstalledFontCollection();
                foreach (System.Drawing.FontFamily family in font.Families)
                {
                    this.cboFtype.Items.Add(family.Name);
                }

                this.cboFtype.Text = "宋体";
                lblID.Text = "字体ID:"+Id.ToString();
            }
            catch
            { }
        }

        private void txtFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar == '.')
               {
                    e.Handled = false;
               } 
               else
                   e.Handled = true;
                //MessageBox.Show("只能输入数字和小数点!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                fontcolor = Color.FromArgb(Convert.ToInt16(txtColor.Text.Split(',')[0]),
                                           Convert.ToInt16(txtColor.Text.Split(',')[1]),
                                           Convert.ToInt16(txtColor.Text.Split(',')[2]));

                Brush = new SolidBrush(fontcolor);
                ft = new Font(new FontFamily(cboFtype.Text), Convert.ToSingle(txtFontSize.Text));
                if (chkBold.Checked)
                {
                    //粗体
                    ft = new Font(ft, FontStyle.Bold);
                }

                if (chkUnderLine.Checked)
                {
                    //下划线
                    ft = new Font(ft, ft.Style|FontStyle.Underline);
                }

                if (chkIta.Checked)
                {
                    //斜体
                    ft = new Font(ft, ft.Style | FontStyle.Italic);
                }

                e.Graphics.DrawString(TestStr, ft
                    , Brush, 10, 10);
            }
            catch
            { }
        
        }

        private void cboFtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void txtFontSize_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void chkUnderLine_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void chkIta_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsFont tempfont = new ClsFont();
                tempfont.Id = Id.ToString();
                tempfont.Tname = txtTname.Text;
                tempfont.Fontcolor = cm.GetColorByStr(txtColor.Text);
                tempfont.Fontsize = Convert.ToSingle(txtFontSize.Text);
                tempfont.Fontname = cboFtype.Text;
                tempfont.Isbold = false;
                tempfont.Isita = false;
                tempfont.Isunderline = false;
                if (chkBold.Checked)
                    tempfont.Isbold = true;
                if(chkIta.Checked)
                    tempfont.Isita = true;
                if(chkUnderLine.Checked)
                    tempfont.Isunderline = true;

                cm.newnode = new TreeNode();                
                cm.newnode.Text = "字体-" + Id.ToString();
                if (txtTname.Text.Trim() != "")
                    cm.newnode.Text = txtTname.Text;
                cm.newnode.Name = Id.ToString();
                cm.newnode.Tag = tempfont;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }
        }
    }
}
