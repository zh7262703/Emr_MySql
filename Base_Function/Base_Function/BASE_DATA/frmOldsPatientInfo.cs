using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmOldsPatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        DataSet ds; //暂存用户基本信息集合     
        private string _patientid;


        /// <summary>
        /// 病人主键
        /// </summary>
        public string Patientid
        {
            get { return _patientid; }
            set { _patientid = value; }
        }

        public frmOldsPatientInfo()
        {
            InitializeComponent();
            App.Ini();
            App.ButtonStytle(this);
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="idcard"></param>
        public frmOldsPatientInfo(string pid,string idcard)
        {
            InitializeComponent();
            App.Ini();
            App.ButtonStytle(this);
            txtPid.Text = pid;
            txtIDCARD.Text = idcard;
        }

        private void frmOldsPatientInfo_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender,e);
        }

        /// <summary>
        /// 查询设置        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string sql = string.Format("select  * from t_in_patient t where pid='{0}' or MEDICARE_NO='{1}'", txtPid.Text, txtIDCARD.Text);

            ds = App.GetDataSet(sql);

            dgvPatientInfo.Rows.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dgvPatientInfo.Rows.Add();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < dgvPatientInfo.Columns.Count; j++)
                {
                    dgvPatientInfo[dgvPatientInfo.Columns[j].Name, i].Value = ds.Tables[0].Rows[i][dgvPatientInfo.Columns[j].Name].ToString();
                }
            }

            dgvPatientInfo.AutoResizeColumns();
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Patientid = "";           
            btnCancel.DialogResult = DialogResult.Cancel; 
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                Patientid = dgvPatientInfo["ID", dgvPatientInfo.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                Patientid = "";
            }
            btnSure.DialogResult = DialogResult.OK;
        }
    }
}