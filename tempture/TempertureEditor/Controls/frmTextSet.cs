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
    public partial class frmTextSet : Form
    {
        private string Id;
        private ClsFont CurrentFont;
        Comm cm = null;



        public frmTextSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
            lblId.Text = "ID:" + Id;
            if (cm.listfonts.Count > 0)
            {
                foreach (ClsFont temppen in cm.listfonts)
                {
                    cboFontType.Items.Add(temppen);
                    cboFontType.DisplayMember = "Tname";
                    cboFontType.ValueMember = "Id";
                }
                cboFontType.SelectedIndex=0;
            }

            cboFontType.SelectedIndex = 0;
            cboTDirection.SelectedIndex = 0;
            cboDirection.SelectedIndex = 1;
        }
                    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsText temptext = new ClsText();

                temptext.Id = Id.ToString();
                temptext.Fontid = cboFontType.Text;
                temptext.X1 = Convert.ToSingle(numD_X.Value);
                temptext.Y1 = Convert.ToSingle(numD_Y.Value);

                temptext.Times = Convert.ToInt16(numD_Times.Value);
                if (txtSpan.Text.Trim() != "")
                    temptext.Spans = Convert.ToSingle(txtSpan.Text);
                else
                    temptext.Spans = 0;
                temptext.Tdirection = cboTDirection.Text;
                temptext.Vtext = txtVal.Text;
                temptext.Direction = cboDirection.Text;
                cm.newnode = new TreeNode();

                if (temptext.Vtext.Length > 5)
                {
                    cm.newnode.Text = "文字-" + temptext.Vtext.Substring(0, 4) + "...";
                }
                else
                {
                    cm.newnode.Text = "文字-" + temptext.Vtext;
                }                
                cm.newnode.Name = Id.ToString();
                cm.newnode.Tag = temptext;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }
        }

        private void picFontShow_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Brush tbrush = new SolidBrush(CurrentFont.Fontcolor);
                Font ft=cm.GetFontById(CurrentFont.Tname);
                //Font ft = new Font(new FontFamily(CurrentFont.Fontname), Convert.ToSingle(CurrentFont.Fontsize));
                //if (CurrentFont.Isbold)
                //{
                //    //粗体
                //    ft = new Font(ft, FontStyle.Bold);
                //}

                //if (CurrentFont.Isunderline)
                //{
                //    //下划线
                //    ft = new Font(ft, ft.Style | FontStyle.Underline);
                //}

                //if (CurrentFont.Isita)
                //{
                //    //斜体
                //    ft = new Font(ft, ft.Style | FontStyle.Italic);
                //}
                e.Graphics.DrawString("测试test", ft, tbrush, 10, 10);
            }
            catch
            { }
        }

        private void cboFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentFont = (ClsFont)cboFontType.SelectedItem;
                this.picFontShow.Refresh();
            }
            catch
            { }
        }

        private void txtSpan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmTextSet_Load(object sender, EventArgs e)
        {

        }
    }
}
