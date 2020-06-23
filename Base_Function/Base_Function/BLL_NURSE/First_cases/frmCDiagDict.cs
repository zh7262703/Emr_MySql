using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmCDiagDict : DevComponents.DotNetBar.Office2007Form
    {
        public frmCDiagDict()
        {
            InitializeComponent();
            rbBM.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string bmname;

        public string Bmname
        {
            get { return bmname; }
            set { bmname = value; }
        }
        private string bmcode;

        public string Bmcode
        {
            get { return bmcode; }
            set { bmcode = value; }
        }
        private string zhname;

        public string Zhname
        {
            get { return zhname; }
            set { zhname = value; }
        }
        private string zhcode;

        public string Zhcode
        {
            get { return zhcode; }
            set { zhcode = value; }
        }

        string sql = "";
        private void SetSql()
        {
            if (rbBM.Checked == true)
            {
                sql = "select a.bm_name ²¡Ãû,a.bm_code ±àÂë from t_bm a";
                sql += " where (a.bm_name like '%" + textBox1.Text.ToUpper() + "%'";
            }
            else
            {
                sql = "select a.zh_name Ö¢ºò,a.zh_code ±àÂë from t_zh a";
                sql += " where (a.zh_name like '%" + textBox1.Text.ToUpper() + "%'";
            }
            sql += " or a.py like '%" + textBox1.Text.ToUpper() + "%')";
            sql += " and rownum<200";
        }
        private void BindData()
        {
            SetSql();
            DataSet ds = Bifrost.App.GetDataSet(sql);
            this.dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
        }

        private void rbBM_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            BindData();
        }

        private void rbZH_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            BindData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridViewX1.CurrentRow;
            if (rbBM.Checked)
            {
                txtBmname.Text = curRow.Cells["²¡Ãû"].Value.ToString();
                txtBmcode.Text = curRow.Cells["±àÂë"].Value.ToString();
            }
            else
            {
                txtZhname.Text = curRow.Cells["Ö¢ºò"].Value.ToString();
                txtZhcode.Text = curRow.Cells["±àÂë"].Value.ToString();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.bmname = txtBmname.Text;
            this.bmcode = txtBmcode.Text;
            this.zhname = txtZhname.Text;
            this.zhcode = txtZhcode.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnOk_Click(this, null);
        }

    }
}