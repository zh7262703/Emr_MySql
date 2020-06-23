using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.HisInStance.量表提醒
{
    public partial class frmElementQuality : DevComponents.DotNetBar.Office2007Form
    {
        DataSet ds;
        public frmElementQuality()
        {
            InitializeComponent();
        }
        public frmElementQuality(DataSet dsElement)
        {
            InitializeComponent();
            this.ds = dsElement;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmElementQuality_Load(object sender, EventArgs e)
        {
            try
            {
                DataBand();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBand()
        {
            if (ds != null)
            {
                dgvDataShow.DataSource = ds.Tables[0].DefaultView;
            }
        }
    }
}
