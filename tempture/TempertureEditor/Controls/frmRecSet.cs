using System;
using System.Drawing;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmRecSet : Form
    {
        private string Id;
        Comm cm = null;
        public frmRecSet(string id, ref Comm cm)
        {
            InitializeComponent();
            Id = id;
            this.cm = cm;
            lblID.Text = "ID:" + Id;
        }

        private void frmRecSet_Load(object sender, System.EventArgs e)
        {
            if (cm.listpens.Count > 0)
            {
                foreach (ClsPens temppen in cm.listpens)
                {
                    cboPenType.Items.Add(temppen);
                    cboPenType.DisplayMember = "Id";
                    cboPenType.ValueMember = "Id";
                }

                cboPenType.SelectedIndex = 0;
            }
        }

        private void btnSure_Click(object sender, System.EventArgs e)
        {
            try
            {
                ClsRec tRec = new ClsRec();
                tRec.Id = Id;
                Rectangle rec = new Rectangle(Convert.ToInt16(numD_X.Value), 
                                              Convert.ToInt16(numD_Y.Value), 
                                              Convert.ToInt16(numD_Width.Value), 
                                              Convert.ToInt16(numD_Width.Height));
                tRec.Rec = rec;
                tRec.Penid =cboPenType.Text;
               
                TreeNode tn = new TreeNode();
                tn.Tag = tRec;
                tn.Text = "边框区域-"+Id;
                tn.Name =Id;

                cm.newnode = tn;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }
            

        }

        private void cboPenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            picPenShow.Refresh();
        }

        private void picPenShow_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawLine(cm.GetCurrentPen(cboPenType.Text), 10, 10, 40, 10);
            }
            catch
            {

            }
        }
    }
}
