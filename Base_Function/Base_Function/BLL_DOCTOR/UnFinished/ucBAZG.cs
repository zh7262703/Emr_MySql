using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class ucBAZG : UserControl
    {
        public ucBAZG()
        {
            InitializeComponent();

            BindDGV();
            richTextBox1.Text = "*****************************************************";
            richTextBox2.Text = "*****************************************************";
        }

        private void BindDGV()
        {
            dgvHJZKCS.Rows.Add();
            dgvHJZKCS.Rows[0].Cells[0].Value = "2016-01-10 10:00";
            dgvHJZKCS.Rows[0].Cells[1].Value = "质控科";

            dgvHJZKCS.Rows.Add();
            dgvHJZKCS.Rows[1].Cells[0].Value = "2016-01-11 10:00";
            dgvHJZKCS.Rows[1].Cells[1].Value = "内一科";



            dgvMX.Rows.Add();
            dgvMX.Rows[0].Cells[0].Value = "2016-01-10 ";
            dgvMX.Rows[0].Cells[1].Value = "入院记录";
            dgvMX.Rows[0].Cells[2].Value = "患者一般项目填写不全或不准确";
            dgvMX.Rows[0].Cells[3].Value = "0.5/项";
            dgvMX.Rows[0].Cells[4].Value = "2";
            dgvMX.Rows[0].Cells[5].Value = "1";
            dgvMX.Rows[0].Cells[6].Value = "√";
            dgvMX.Rows[0].Cells[7].Value = "0000-00-00 00：00";
            dgvMX.Rows[0].Cells[8].Value = "√";


            dgvMX.Rows.Add();
            dgvMX.Rows[1].Cells[0].Value = "2016-01-10 ";
            dgvMX.Rows[1].Cells[1].Value = "入院记录";
            dgvMX.Rows[1].Cells[2].Value = "主诉描述有缺陷";
            dgvMX.Rows[1].Cells[3].Value = "4";
            dgvMX.Rows[1].Cells[4].Value = "1";
            dgvMX.Rows[1].Cells[5].Value = "1";
            dgvMX.Rows[1].Cells[6].Value = "√";
            dgvMX.Rows[1].Cells[7].Value = "0000-00-00 00：00";
            dgvMX.Rows[1].Cells[8].Value = "";

            dgvMX.Rows.Add();
            dgvMX.Rows[2].Cells[0].Value = "2016-01-10 ";
            dgvMX.Rows[2].Cells[1].Value = "病程记录";
            dgvMX.Rows[2].Cells[2].Value = "病情变化无分析、判断、处理及结果";
            dgvMX.Rows[2].Cells[3].Value = "3";
            dgvMX.Rows[2].Cells[4].Value = "1";
            dgvMX.Rows[2].Cells[5].Value = "3";
            dgvMX.Rows[2].Cells[6].Value = "";
            dgvMX.Rows[2].Cells[7].Value = "0000-00-00 00：00";
            dgvMX.Rows[2].Cells[8].Value = "";
        }
    }
}
