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
    public partial class frmAddDiscussion : DevComponents.DotNetBar.Office2007Form
    {
        public frmAddDiscussion()
        {
            InitializeComponent();
        }
        #region 变量和属性
        /// <summary>
        /// 当前病区ID
        /// </summary>
        private string currentSickArea = App.UserAccount.CurrentSelectRole.Sickarea_Id;
        /// <summary>
        /// 当前患者的住院号
        /// </summary>
        private string currentPatientID = string.Empty;
        /// <summary>
        /// 当前患者的HIS_ID
        /// </summary>
        private string currentPatientHisID = string.Empty;
        #endregion


        #region 方法
        /// <summary>
        /// 性别编码转换成性别名称
        /// </summary>
        /// <param name="genderCode"></param>
        /// <returns></returns>
        private string TransGender(string genderCode)
        {
            if (!string.IsNullOrEmpty(genderCode))
            {
                if (genderCode.Equals("1"))
                {
                    return genderCode = "女";
                }
                else
                {
                    if (genderCode.Equals("0"))
                    {
                        return genderCode = "男";
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
        /// <summary>
        /// 通过姓名查找患者信息
        /// </summary>
        /// <param name="patientName"></param>
        private void GetPatientInfoByName(string patientName)
        {
            string sql = string.Empty;
            //暂时要查出数据  先注释掉老sql. 
            //sql = "select * from t_in_patient  d where  d.patient_name ='" + patientName + "'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
            sql = "select * from t_in_patient  d where  d.patient_name ='" + patientName + " and d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    //年龄
                    this.lblAge.Text = dt.Rows[0]["AGE"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                    //性别
                    this.lblSex.Text = this.TransGender(dt.Rows[0]["GENDER_CODE"].ToString());
                    //患者住院号
                    this.txtPatientID.Text = dt.Rows[0]["ID"].ToString();
                    //患者HIS_ID
                    this.currentPatientHisID = dt.Rows[0]["his_id"].ToString();
                    //患者Patient_ID
                    this.currentPatientID = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        //有重复姓名的患者
                        this.dgvSameNamePatient.Visible = true;
                        this.dgvSameNamePatient.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            this.dgvSameNamePatient.Rows.Add();
                            this.dgvSameNamePatient.Rows[i].Cells["name"].Value = dt.Rows[i]["patient_name"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["ID"].Value = dt.Rows[i]["id"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["bedno"].Value = dt.Rows[i]["SICK_BED_NO"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["sex"].Value = this.TransGender(dt.Rows[i]["GENDER_CODE"].ToString());
                            this.dgvSameNamePatient.Rows[i].Cells["age"].Value = dt.Rows[i]["age"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                            this.dgvSameNamePatient.Rows[i].Cells["intime"].Value = dt.Rows[i]["in_time"].ToString().Substring(0, 16);
                            this.dgvSameNamePatient.Rows[i].Cells["his_id"].Value = dt.Rows[i]["his_id"].ToString();
                        }
                    }
                    else
                    {
                        App.Msg("当前病区无该患者");
                    }
                }
            }
        }
        /// <summary>
        /// 通过患者姓名查找患者信息
        /// </summary>
        /// <param name="patientName"></param>
        private void FilterPatientInfoByName(string patientName)
        {
            string sql = string.Empty;
             //sql = "select * from t_in_patient  d where  d.patient_name like'%" + patientName + "%'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
             sql = "select * from t_in_patient  d where  d.patient_name like'%" + patientName + "%'and  d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //有重复姓名的患者
                    this.dgvSameNamePatient.Visible = true;
                    this.dgvSameNamePatient.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.dgvSameNamePatient.Rows.Add();
                        this.dgvSameNamePatient.Rows[i].Cells[0].Value = dt.Rows[i]["patient_name"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[1].Value = dt.Rows[i]["id"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[2].Value = dt.Rows[i]["SICK_BED_NO"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[3].Value = dt.Rows[i]["in_time"].ToString().Substring(0, 16);
                        this.dgvSameNamePatient.Rows[i].Cells[4].Value = this.TransGender(dt.Rows[i]["GENDER_CODE"].ToString());
                        this.dgvSameNamePatient.Rows[i].Cells[5].Value = dt.Rows[i]["age"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                        this.dgvSameNamePatient.Rows[i].Cells[6].Value = dt.Rows[i]["his_id"].ToString();
                    }
                }
                else
                {
                    App.Msg("当前病区无该患者");
                }
            }
        }
        /// <summary>
        /// 根据患者住院号查找患者信息
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatientInfoByPatientID(string patientID)
        {
            string sql = string.Empty;
            sql = "select * from t_in_patient  d where  d.id ='" + patientID + "'and d.sick_area_id=" + currentSickArea + "and d.die_time is null";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    //年龄
                    this.lblAge.Text = dt.Rows[0]["AGE"].ToString() + dt.Rows[0]["AGE_UNIT"].ToString();
                    //性别
                    this.lblSex.Text = this.TransGender(dt.Rows[0]["GENDER_CODE"].ToString());
                    //姓名
                    this.txtPatientName.Text = dt.Rows[0]["PATIENT_NAME"].ToString();
                    this.currentPatientID = dt.Rows[0]["id"].ToString();
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        //有重复姓名的患者
                    }
                    else
                    {
                        App.Msg("当前病区无该患者");
                    }
                }
            }
        }
        /// <summary>
        /// 保存增加的讨论记录信息
        /// </summary>
        private void SaveDisscussInfo()
        {
            int int_id = App.GenId("t_patient_disscuss", "id");
            //向患者讨论记录表新增一条记录
            string InsertJob_Temp = "insert into t_patient_disscuss(patient_name,patient_id,disscuss_date,creater,diagnose_info,sex,age,his_id,id)" +
                                    " values('" + this.txtPatientName.Text.ToString() + "','" + this.txtPatientID.Text.ToString() + "',to_timestamp('" + this.dtpDisscussDate.Value.ToString() + "','yyyy-MM-dd hh24:mi:ss'),'" + this.lblDoctorName.Text.ToString() + "','" + this.rtxtDiagnose.Text.ToString() + "','" + this.lblSex.Text.ToString() + "','" + this.lblAge.Text.ToString() + "','" + this.currentPatientHisID.ToString() + "','" + int_id + "')";
            App.ExecuteSQL(InsertJob_Temp);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion



        #region 事件
        /// <summary>
        /// 页面加载时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddDiscussion_Load(object sender, EventArgs e)
        {
            //创建者姓名
            this.lblDoctorName.Text = App.UserAccount.UserInfo.User_name;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 根据患者姓名查找患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetPatientInfoByName(this.txtPatientName.Text.Trim().ToString());
            }
        }
        /// <summary>
        /// 通过住院号查找患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetPatientInfoByPatientID(this.txtPatientID.Text.Trim().ToString());
            }
        }
        /// <summary>
        /// 保存增加的讨论记录信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text==""||txtPatientID.Text=="")
            {
                App.Msg("患者姓名或住院号不允许为空！");
                return;
            }
            this.SaveDisscussInfo();
        }
        /// <summary>
        /// 双击选中需要增加讨论记录的患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSameNamePatient_DoubleClick(object sender, EventArgs e)
        {
           
            //患者姓名
            this.txtPatientName.Text = this.dgvSameNamePatient.CurrentRow.Cells["name"].Value.ToString();
            //患者Patient_ID
            this.txtPatientID.Text = this.dgvSameNamePatient.CurrentRow.Cells["id"].Value.ToString();
            //性别
            this.lblSex.Text = this.dgvSameNamePatient.CurrentRow.Cells["sex"].Value.ToString();
            //年龄
            this.lblAge.Text = this.dgvSameNamePatient.CurrentRow.Cells["age"].Value.ToString();
            //患者HIS_ID
            this.currentPatientHisID = this.dgvSameNamePatient.CurrentRow.Cells["his_id"].Value.ToString();
            //患者Patient_ID
            this.currentPatientID = this.dgvSameNamePatient.CurrentRow.Cells["ID"].Value.ToString();
            this.dgvSameNamePatient.Visible = false;
        }
        /// <summary>
        /// 获取患者诊断信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblDiagnose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<DiagnoseInfo> diagnoseList = new List<DiagnoseInfo>();
            FrmDiagnose frmDiag = new FrmDiagnose(ref diagnoseList);
            //FrmDiagnose frmDiag = new FrmDiagnose();
            frmDiag.PatientID = this.currentPatientID;
            this.rtxtDiagnose.Text = string.Empty;
            if (frmDiag.ShowDialog() == DialogResult.OK)
            {
                if (diagnoseList.Count == 1)
                {
                    this.rtxtDiagnose.Text = diagnoseList[0].DiagnoseName.ToString();
                }
                else
                {
                    if (diagnoseList.Count > 1)
                    {
                        int num = 1;
                        for (int i = 0; i < diagnoseList.Count; i++)
                        {
                            this.rtxtDiagnose.Text += num.ToString() + "." + diagnoseList[i].DiagnoseName + "。";
                            num++;
                        }
                    }
                    else
                    {
                        //不做处理
                    }
                }
            }
        }
        /// <summary>
        /// 过滤需要查找的患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            this.FilterPatientInfoByName(this.txtPatientName.Text.Trim().ToString());
        }
        #endregion















    }
}