using System;
using System.Drawing;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmLineSet : Form
    {
        private string _id;
        Pen npen;
        ClsPens clspen;
        Comm cm = null;
        public frmLineSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
            lblLineId.Text = "ID:"+Id;
            if (cm.listpens.Count > 0)
            {
                foreach (ClsPens temppen in cm.listpens)
                {
                    cboPenType.Items.Add(temppen);
                    cboPenType.DisplayMember = "Tname";
                    cboPenType.ValueMember ="Id";
                }

                cboPenType.SelectedIndex = 0;
            }
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

        private void frmLineSet_Load(object sender, EventArgs e)
        {
            cboDirctionType.SelectedIndex = 0;
        }

        /// <summary>
        /// 确定操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                ClsLine templine = new ClsLine();

                templine.Id = Id.ToString();
                templine.Penid =cboPenType.Text;
                templine.X1 = Convert.ToSingle(numD_X1.Value);
                templine.Y1 = Convert.ToSingle(numD_Y1.Value);
                templine.X2 = Convert.ToSingle(numD_X2.Value);
                templine.Y2 = Convert.ToSingle(numD_Y2.Value);

                templine.Times = Convert.ToInt16(numD_Times.Value);
                if(txtSpan.Text.Trim()!="")
                   templine.Spans = Convert.ToSingle(txtSpan.Text);
                else
                   templine.Spans = 0;
                templine.Direction = cboDirctionType.Text;


                cm.newnode = new TreeNode();
                cm.newnode.Text = "线-" + Id.ToString();
                cm.newnode.Name = Id.ToString();
                cm.newnode.Tag = templine;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }
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

        private void picPenShow_Click(object sender, EventArgs e)
        {

        }

        private void picPenShow_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawLine(npen, 10, 10, 50, 10);
            //e.Graphics.DrawLine(npen,Convert.ToSingle(numD_X1.Value), Convert.ToSingle(numD_Y1.Value), Convert.ToSingle(numD_X2.Value), Convert.ToSingle(numD_Y2.Value));
        }

        private void cboPenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clspen = (ClsPens)cboPenType.SelectedItem;
                npen = new Pen(clspen.Pencolor, clspen.Pensize);
                picPenShow.Refresh();
            }
            catch
            { }
        }
    }
}
