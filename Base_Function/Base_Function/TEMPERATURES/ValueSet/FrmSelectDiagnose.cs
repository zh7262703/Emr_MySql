using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.TEMPERATURES.ValueSet
{
    public partial class FrmSelectDiagnose : Form
    {
        public FrmSelectDiagnose(string patient_id,string _diagnose,string _diagnosecount)
        {
            InitializeComponent();
            this.Patien_ID = patient_id;
            this.DialogResult = DialogResult.Cancel;
            this.textBox1.Text = _diagnose;
            if (_diagnose.Length > 0)
            {
                index = int.Parse(_diagnosecount);
            }
            Init();
        }

        string Patien_ID = string.Empty;

        private string diagnose = string.Empty;

        public string Diagnose
        {
            get { return diagnose; }
            set { diagnose = value; }
        }

        private int index = 0;
        /// <summary>
        /// ��ϸ���
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        void Init()
        {
            string Sql = "select distinct a.diagnose_name ������� from t_diagnose_item a where a.patient_id = " + this.Patien_ID;
            DataTable table = Bifrost.App.GetDataSet(Sql).Tables[0];
            this.fg.DataSource = table;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (index == 3)
            {
                Bifrost.App.Msg("���ֻ����д������ϣ�");
                return;
            }
            if (this.fg.RowSel >= this.fg.Rows.Fixed)
            {
                index++;
                if (this.textBox1.Text.Trim().Length > 0)
                {
                    this.textBox1.Text += "," + index.ToString() + "." + fg[fg.Row, "�������"].ToString();
                }
                else
                {
                    this.textBox1.Text += index.ToString() + "." + fg[fg.Row, "�������"].ToString();
                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.index = 0;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.diagnose = this.textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}