using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Digital_Medical_Treatment.A_Discussion
{
    public partial class FrmDiagnose : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDiagnose()
        {
            InitializeComponent();
        }
        public FrmDiagnose(ref List<DiagnoseInfo> temp)
        {
            InitializeComponent();
            temp = diagnoseInfoList;
        }
        #region 变量与属性
        /// <summary>
        /// 患者的pantientID
        /// </summary>
        private string patientID;
        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }
        //需要提取的诊断信息集合
        private List<DiagnoseInfo> diagnoseInfoList = new List<DiagnoseInfo>();
        #endregion


        #region  方法
        /// <summary>
        /// 根据患者的病人号查找患者的诊断信息
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatientDiagnoseInfo(string patientID)
        {
            this.dgvSource.Rows.Clear();
            string sql = string.Empty;
            sql = "select * from t_diagnose_item  d where  d.patient_id =" + patientID;
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.dgvSource.Rows.Add();
                        this.dgvSource.Rows[i].Cells["zdbm"].Value = dt.Rows[i]["diagnose_code"].ToString();
                        this.dgvSource.Rows[i].Cells["zdmc"].Value = dt.Rows[i]["diagnose_name"].ToString();
                        this.dgvSource.Rows[i].Cells["iszyzd"].Value = this.TransDiagnoseTypeName(dt.Rows[i]["is_chinese"].ToString());
                    }
                }
                else
                {
                    //App.Msg("当前病区无该患者");
                }
            }
        }
        /// <summary>
        /// 显示是否是中医诊断
        /// </summary>
        /// <param name="isChinese"></param>
        /// <returns></returns>
        private string TransDiagnoseTypeName(string isChinese)
        {
            if (!string.IsNullOrEmpty(isChinese))
            {
                if (isChinese.Equals("N"))
                {
                    return isChinese = "否";
                }
                else
                {
                    if (isChinese.Equals("Y"))
                    {
                        return isChinese = "是";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion



        # region 事件
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDiagnose_Load(object sender, EventArgs e)
        {
            this.GetPatientDiagnoseInfo(this.patientID);
        }
        /// <summary>
        /// 提取诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTQ_Click(object sender, EventArgs e)
        {
            this.diagnoseInfoList.Clear();

            foreach (DataGridViewRow var in this.dgvSource.Rows)
            {
               // CheckBox check = (CheckBox)var.Cells["xz"];
                if ( (bool)var.Cells["xz"].EditedFormattedValue)
                {
                    DiagnoseInfo diagnoseInfo = new DiagnoseInfo();
                    diagnoseInfo.DiagnoseCode = var.Cells["zdbm"].Value.ToString();
                    diagnoseInfo.DiagnoseName = var.Cells["zdmc"].Value.ToString();
                    diagnoseInfo.IsChinese = var.Cells["iszyzd"].Value.ToString();
                    diagnoseInfoList.Add(diagnoseInfo);
                }
            }
            if (diagnoseInfoList.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                App.Msg("请至少选择一条需要提取的诊断！");
            }

        }
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvrSelected=this.dgvSource.SelectedRows;
            if (dgvrSelected.Count > 0)
            {
                int index = this.dgvSource.SelectedRows[0].Index;
                if (index > 0)
                {
                    DataGridViewRow dgvr = this.dgvSource.Rows[index - dgvrSelected.Count];
                    this.dgvSource.Rows.RemoveAt(index - dgvrSelected.Count);
                    this.dgvSource.Rows.Insert((index),dgvr);
                    for(int i=0;i<dgvrSelected.Count;i++)
                    {
                        this.dgvSource.Rows[index-i-1].Selected=true;
                    }
                }
            }
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvrSelected = this.dgvSource.SelectedRows;
            if (dgvrSelected.Count > 0)
            {
                int index = this.dgvSource.SelectedRows[0].Index;
                if (index >= 0&&(this.dgvSource.RowCount-1)!=index)
                {
                    DataGridViewRow dgvr = this.dgvSource.Rows[index];
                    dgvSource.Rows.Remove(dgvSource.Rows[index]);
                    dgvSource.Rows.Insert(index + 1, dgvr);
                    dgvSource.Rows[index].Selected = false;
                    dgvr.Selected = true;
                }
            }
        }
        #endregion

     


    }
}