using Bifrost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor
{
    public partial class frmInputAll : Form
    {
        public frmInputAll()
        {
            InitializeComponent();
            App.Ini();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTreeView();
          
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = this.tvPatientArea.SelectedNode;

            string templateType;
            if (selectNode.Text.Contains("精神"))
                templateType = tempetureDataComm.TEMPLATE_CHILD;
            else
                templateType = tempetureDataComm.TEMPLATE_NORMAL;
            if (selectNode != null)
            {
                panel2.Controls.Clear();
                ucTempretureList tt = new ucTempretureList(templateType, Convert.ToInt32(selectNode.Name), "", "");
                tt.Dock = DockStyle.Fill;
                panel2.Controls.Add(tt);
            }
        }

        private void InitTreeView()
        {
            tvPatientArea.Nodes.Clear();    //清空树视图原节点

            string sql = "select aa.said,aa.sick_area_name from t_sickareainfo aa inner join t_section_area bb on aa.said=bb.said ";
            DataSet ds = App.GetDataSet(sql);

            foreach (DataRow trow in ds.Tables[0].Rows)
            {
                tvPatientArea.Nodes.Add(trow["said"].ToString(), trow["sick_area_name"].ToString());
            }

            if (tvPatientArea.Nodes.Count > 0)
                tvPatientArea.SelectedNode = tvPatientArea.Nodes[0];    //默认选择第1个病区
        }
    }
}
