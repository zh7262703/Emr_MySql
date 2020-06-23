using System;
using System.Drawing;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmMainSet : Form
    {
        Comm cm = new Comm();
        public frmMainSet()
        {
            InitializeComponent();
        }

        private void frmMainSet_Load(object sender, System.EventArgs e)
        {
            
        }

        private void btnSure_Click(object sender, System.EventArgs e)
        {
            try
            {
                ClsMainFrame mainfram = new ClsMainFrame();
                mainfram.Twidth = Convert.ToInt16(numD_Width.Value);
                mainfram.Theight= Convert.ToInt16(numD_Width.Height);
                mainfram.Day_x = 0;
                mainfram.Day_y = 0;
                mainfram.Daywidth = 72;
                mainfram.Timewidth = 12;
                TreeNode tn = new TreeNode();
                tn.Tag = mainfram;
                tn.Text = "主区域";
                tn.Name = "m1";
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
           
        }

        private void picPenShow_Paint(object sender, PaintEventArgs e)
        {            
        }
    }
}
