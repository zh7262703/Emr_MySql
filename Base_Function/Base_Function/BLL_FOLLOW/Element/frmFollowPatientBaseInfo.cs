using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowPatientBaseInfo : DevComponents.DotNetBar.Office2007Form
    {
        public frmFollowPatientBaseInfo(string pid)
        {
            InitializeComponent();
            ucPatientInfo1.RefleshForm(pid);
        }
    }
}