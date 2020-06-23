using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Bifrost_Doctor;
using Base_Function.BLL_DOCTOR;

namespace Digital_Medical_Treatment.A_Discussion
{
    public partial class UcDiscussionList : DevComponents.DotNetBar.Office2007Form
    {
        public UcDiscussionList()
        {
            InitializeComponent();
        }
        #region 变量与属性
        /// <summary>
        /// 当前病人
        /// </summary>
        private InPatientInfo currentInpatient;
       
        #endregion

        #region 方法
        /// <summary>
        /// 获取当前选中患者
        /// </summary>
        /// <returns></returns>
        private InPatientInfo GetPatientByList()
        {
            InPatientInfo patientInfo = new InPatientInfo();
            if (this.dgvDisscussInfo.CurrentRow != null)
            {
                if (dgvDisscussInfo.CurrentRow.Index > 0 || dgvDisscussInfo.CurrentRow.Index == 0)
                {
                    //患者住院号
                    patientInfo.Id = Int32.Parse(dgvDisscussInfo["zyh", dgvDisscussInfo.CurrentRow.Index].Value.ToString());
                    string sql = string.Empty;
                    sql = "select * from t_in_patient  d where  d.id =" + patientInfo.Id;
                    DataSet ds = App.GetDataSet(sql);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            //患者HIS_ID
                            patientInfo.His_id = dt.Rows[0]["his_id"].ToString();
                            //患者姓名
                            patientInfo.Patient_Name = dt.Rows[0]["PATIENT_NAME"].ToString();
                            patientInfo.Gender_Code = dt.Rows[0]["GENDER_CODE"].ToString();
                            patientInfo.Marrige_State=dt.Rows[0]["MARRIAGE_STATE"].ToString();
                            patientInfo.Medicare_no=dt.Rows[0]["MEDICARE_NO"].ToString();
                            patientInfo.Home_address=dt.Rows[0]["HOME_ADDRESS"].ToString();
                            patientInfo.HomePostal_code=dt.Rows[0]["HOME_ADDRESS"].ToString();
                            patientInfo.Home_phone=dt.Rows[0]["HOME_PHONE"].ToString();
                            patientInfo.Office=dt.Rows[0]["OFFICE"].ToString();
                            patientInfo.Office_address=dt.Rows[0]["OFFICE_ADDRESS"].ToString();
                            patientInfo.Office_phone=dt.Rows[0]["OFFICE_PHONE"].ToString();
                            patientInfo.Relation=dt.Rows[0]["RELATION"].ToString();
                            patientInfo.Relation_address=dt.Rows[0]["RELATION_ADDRESS"].ToString();
                            patientInfo.Relation_phone=dt.Rows[0]["RELATION_PHONE"].ToString();
                            patientInfo.RelationPos_code =dt.Rows[0]["RELATIONPOS_CODE"].ToString();
                            patientInfo.OfficePos_code =dt.Rows[0]["OFFICEPOS_CODE"].ToString();
                            if( dt.Rows[0]["his_id"].ToString().Contains("-"))
                            {
                             patientInfo.InHospital_count =Int32.Parse(dt.Rows[0]["his_id"].ToString().Split('-')[1]) ;
                            }
                            patientInfo.Cert_Id = dt.Rows[0]["CERT_ID"].ToString();
                            patientInfo.Pay_Manager =dt.Rows[0]["PAY_MANNER"].ToString() ;
                            patientInfo.In_Circs = dt.Rows[0]["IN_CIRCS"].ToString();
                            patientInfo.Natiye_place = dt.Rows[0]["NATIVE_PLACE"].ToString();
                            patientInfo.Birth_place = dt.Rows[0]["BIRTH_PLACE"].ToString();
                            patientInfo.Folk_code = dt.Rows[0]["FOLK_CODE"].ToString();
                            patientInfo.Birthday = dt.Rows[0]["BIRTHDAY"].ToString();
                            patientInfo.PId =dt.Rows[0]["PID"].ToString() ;
                            if (!string.IsNullOrEmpty(dt.Rows[0]["INSECTION_ID"].ToString()))
                            {
                                patientInfo.Insection_Id = Int32.Parse(dt.Rows[0]["INSECTION_ID"].ToString());
                            }
                            patientInfo.Insection_Name = dt.Rows[0]["INSECTION_NAME"].ToString() ;
                            if (!string.IsNullOrEmpty(dt.Rows[0]["IN_AREA_ID"].ToString()))
                            {
                                patientInfo.In_Area_Id = dt.Rows[0]["IN_AREA_ID"].ToString();
                            }
                            patientInfo.In_Area_Name = dt.Rows[0]["IN_AREA_NAME"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["AGE"].ToString()))
                            {
                                patientInfo.Age = dt.Rows[0]["AGE"].ToString();
                            }
                            patientInfo.Sick_Doctor_Id = dt.Rows[0]["SICK_DOCTOR_ID"].ToString();
                            patientInfo.Sick_Doctor_Name = dt.Rows[0]["SICK_DOCTOR_NAME"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["SICK_AREA_ID"].ToString()))
                            { 
                                patientInfo.Sike_Area_Id = dt.Rows[0]["SICK_AREA_ID"].ToString();
                            }
                            patientInfo.Sick_Area_Name = dt.Rows[0]["SICK_AREA_NAME"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["SECTION_ID"].ToString()))
                            {
                                patientInfo.Section_Id = Int32.Parse(dt.Rows[0]["SECTION_ID"].ToString());
                            }
                            patientInfo.Section_Name = dt.Rows[0]["SECTION_NAME"].ToString();

                            patientInfo.In_Time = DateTime.Parse(dt.Rows[0]["IN_TIME"].ToString());
                            patientInfo.State = dt.Rows[0]["STATE"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["SICK_BED_ID"].ToString()))
                            {
                                patientInfo.Sick_Bed_Id = Int32.Parse(dt.Rows[0]["SICK_BED_ID"].ToString());
                            }
                            patientInfo.Sick_Bed_Name = dt.Rows[0]["SICK_BED_NO"].ToString();
                            patientInfo.Age_unit = dt.Rows[0]["AGE_UNIT"].ToString();
                            patientInfo.Sick_Degree = dt.Rows[0]["SICK_DEGREE"].ToString();
                            if (!string.IsNullOrEmpty(dt.Rows[0]["DIE_FLAG"].ToString()))
                            {
                                patientInfo.Die_flag = Convert.ToInt32(dt.Rows[0]["DIE_FLAG"].ToString());
                            }
                            patientInfo.Card_Id = dt.Rows[0]["CARD_ID"].ToString();
                            patientInfo.Nurse_Level = dt.Rows[0]["NURSE_LEVEL"].ToString();
                        }
                    }
                }
                return patientInfo;
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region  事件
        /// <summary>
        /// 新增讨论患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDiscussion frm = new frmAddDiscussion();
            frm.ShowDialog();
            this.btnSearch_Click(this, null);
        }
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcDiscussionList_Load(object sender, EventArgs e)
        {
            this.dtpDisscussDateBegin.Value = App.GetSystemTime().AddMonths(-1);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            sql = "select * from t_patient_disscuss  d where  d.DISSCUSS_DATE between to_timestamp('" + this.dtpDisscussDateBegin.Value.Date + "','yyyy-MM-dd HH24:mi:ss') and to_timestamp('" + this.dtpDisscussDateEnd.Value.AddDays(1).Date + "','yyyy-MM-dd HH24:mi:ss')";
            if (!string.IsNullOrEmpty(this.txtPatientName.Text.ToString()))
            {
                sql += "and d.patient_name='" + this.txtPatientName.Text.ToString() + "'";
            }
            if (!string.IsNullOrEmpty(this.txtCreater.Text.ToString()))
            {
                sql += "and  d.creater='" + this.txtCreater.Text.ToString() + "'";
            }
            DataSet ds = App.GetDataSet(sql);
            this.dgvDisscussInfo.Rows.Clear();
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.dgvDisscussInfo.Rows.Add();
                        //序号
                        this.dgvDisscussInfo.Rows[i].Cells["num"].Value = (i + 1).ToString();
                        //主键
                        this.dgvDisscussInfo.Rows[i].Cells["id"].Value = dt.Rows[i]["id"].ToString();
                        //住院号
                        this.dgvDisscussInfo.Rows[i].Cells["zyh"].Value = dt.Rows[i]["patient_id"].ToString();
                        //患者姓名
                        this.dgvDisscussInfo.Rows[i].Cells["patient_name"].Value = dt.Rows[i]["patient_name"].ToString();
                        //性别
                        this.dgvDisscussInfo.Rows[i].Cells["sex"].Value = dt.Rows[i]["sex"].ToString();
                        //年龄
                        this.dgvDisscussInfo.Rows[i].Cells["age"].Value = dt.Rows[i]["age"].ToString();
                        //诊断
                        this.dgvDisscussInfo.Rows[i].Cells["zd"].Value = dt.Rows[i]["diagnose_info"].ToString();
                        //讨论时间
                        this.dgvDisscussInfo.Rows[i].Cells["tlsj"].Value = dt.Rows[i]["disscuss_date"].ToString();
                        //创建者
                        this.dgvDisscussInfo.Rows[i].Cells["cjz"].Value = dt.Rows[i]["creater"].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 病历概述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 病历概述ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentInpatient = this.GetPatientByList();;
            //Form frm = new Form();
            //frm.WindowState = FormWindowState.Maximized;
            //ucDoctorOperater ucOperater = new ucDoctorOperater(this.currentInpatient);
            //frm.Controls.Add(ucOperater);
            //ucOperater.Dock = DockStyle.Fill;
            //frm.ShowDialog();

            frmMain frm = new frmMain(this.currentInpatient);
            frm.ShowDialog();
        }
        /// <summary>
        /// 曲线图配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 曲线图配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentInpatient = this.GetPatientByList();
            frmPatientProgress fpp = new frmPatientProgress(currentInpatient);
            fpp.ShowDialog();
        }
        /// <summary>
        /// 显示屏展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示屏展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentInpatient = this.GetPatientByList();
            UcScreen frm = new UcScreen(currentInpatient);
            frm.ShowDialog();

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strId = dgvDisscussInfo.CurrentRow.Cells["id"].Value.ToString();
                if (strId!="")
                {
                    string strDelete_sql = "delete from T_PATIENT_DISSCUSS t where t.id='" + strId + "'";
                    int n = App.ExecuteSQL(strDelete_sql);
                    if (n>0)
                    {
                        App.Msg("删除成功！");
                        btnSearch_Click(null,null);
                        return;
                    }
                }
            }
            catch 
            {
                
            }
            finally
            {
                this.Cursor=Cursors.Default;
            }
        }
        /// <summary>
        /// 右键获取当前选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDisscussInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvDisscussInfo.ClearSelection();
            if (e.Button == MouseButtons.Right && this.dgvDisscussInfo.Rows.Count > 0)
            {
                if (e.RowIndex >= 0 && e.RowIndex < this.dgvDisscussInfo.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < this.dgvDisscussInfo.Columns.Count)
                {
                    for (int i = 0; i < this.contextMenuStrip1.Items.Count; i++)
                    {
                        this.contextMenuStrip1.Items[i].Visible = true ;
                    }
                    this.dgvDisscussInfo.Rows[e.RowIndex].Selected = true;
                    this.dgvDisscussInfo.CurrentCell = this.dgvDisscussInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
                else
                {
                    for (int i=0; i < this.contextMenuStrip1.Items.Count; i++)
                    {
                        this.contextMenuStrip1.Items[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i=0; i < this.contextMenuStrip1.Items.Count; i++)
                {
                    this.contextMenuStrip1.Items[i].Visible = false;
                }
            }
        }
        /// <summary>
        /// 展开右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.dgvDisscussInfo.Rows.Count == 0)
            {
                for (int i=0; i < this.contextMenuStrip1.Items.Count; i++)
                {
                    this.contextMenuStrip1.Items[i].Visible = false;
                }
            }
        }
        #endregion

       

       

       

        








    }
}
