using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_DOCTOR
{
    /// <summary>
    /// 创建补录文书设置
    /// 创建人：张华
    /// 创建时间：2012-02-21
    /// </summary>
    public partial class frmCreateDocSet :DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        ///质控选择时间  
        /// </summary>
        public static string q_time = "";      

        /// <summary>
        /// 初始化构造函数
        /// </summary>
        public frmCreateDocSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 规则类型ID
        /// </summary>
        /// <param name="q_records"></param>
        public frmCreateDocSet(DataSet q_records)
        {
            InitializeComponent();
            if (q_records!=null)
            {
                dataGridViewX1.DataSource = q_records.Tables[0].DefaultView;
                dataGridViewX1.Refresh();
                dataGridViewX1.Columns["id"].Visible = false;
                dataGridViewX1.Columns["pid"].Visible = false;
                dataGridViewX1.Columns["doctypeid"].Visible = false;
                dataGridViewX1.Columns["pv"].Visible = false;
                dataGridViewX1.Columns["patient_id"].Visible = false;
                dataGridViewX1.Columns["红灯说明"].Width = 450;
                dataGridViewX1.Columns["红灯时间"].Width = 200;             
                dataGridViewX1.AutoResizeColumns();               
            }
        }

        private void frmCreateDocSet_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            q_time = dataGridViewX1["红灯时间", dataGridViewX1.SelectedRows[0].Index].Value.ToString();
            q_time = Convert.ToDateTime(q_time).AddMinutes(-1).ToString();
            this.Close();
        }

        private void chkCj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCj.Checked)
            {
                groupBox1.Enabled = false;
                chkbl.Checked = false;
            }
            else
            {
                groupBox1.Enabled = true;
                chkbl.Checked = true;
            }
        }

        private void frmCreateDocSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkCj.Checked)
                q_time = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkbl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbl.Checked)
            {
                chkCj.Checked = false;
                groupBox1.Enabled = true;
            }
            else
            {
                chkCj.Checked = true;
                groupBox1.Enabled = false;
            }
        }

        /// <summary>
        ///取消        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
