using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class FrmPupilSet : DevComponents.DotNetBar.Office2007Form
    {

        public string returnValue = "";//返回值,用斜杠"/"隔开
        public bool flag = false;//操作标志

        public FrmPupilSet()
        {
            InitializeComponent();
        }

        public FrmPupilSet(string value)
        {
            InitializeComponent();
            returnValue = value;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                App.Msg("请输入瞳孔大小！");
                textBox1.Focus();
                return;
            }

            flag = true;
            returnValue = textBox1.Text + "/" + cboDGFS.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPupilSet_Load(object sender, EventArgs e)
        {
            //设置下拉选项
            SetCommbox();
            textBox1.Focus();
            if (returnValue != "")
            {
                textBox1.Text = returnValue.Split('/')[0];
                cboDGFS.Text = returnValue.Split('/')[1];
            }
        }

        private void SetCommbox()
        {
            string sql = "select name,code from t_data_code where type=198";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                //DataRow dr = ds.Tables[0].NewRow;
                //dr["name"] = "请选择";
                //dr["code"] = "0";
                //ds.Tables[0].Rows.InsertAt(0, dr);

                cboDGFS.DataSource = ds.Tables[0];
                cboDGFS.DisplayMember = "name";
                cboDGFS.ValueMember = "code";
            }
        }
    }
}