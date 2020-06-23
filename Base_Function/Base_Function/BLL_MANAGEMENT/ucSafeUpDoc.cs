/***************************************
病历封存功能
20170711 添加
****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using System.Collections;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucSafeUpDoc : UserControl
    {
        #region   构造函数
        public ucSafeUpDoc()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSafeUpDoc_Load(object sender, EventArgs e)
        {
            dateTimeStrat.Enabled = false;
            dateTimeEnd.Enabled = false;
            DataBindSection();
            getlist();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btoQuery_Click(object sender, EventArgs e)
        {
            getlist();
        }
        /// <summary>
        /// 绑定dgv列表数据
        /// </summary>
        public void getlist()
        {
            StringBuilder strsql = new StringBuilder();

            //strsql.Append("select distinct(t2.id) as 患者id,t2.pid as 住院号,t2.patient_name as 患者姓名 ,t2.sick_doctor_name  as 管床医生,t2.section_name  as 科室,t2.in_time  as 入院时间,t1.issafeup as 封存状态 ,t3.lockpeople as 封存人,t3.locktime as 封存时间 , t3.safeuppeople as 解封人,t3.safeuptime as 解封时间 from T_PATIENTS_DOC t1,t_in_patient t2,t_docsafeup t3 where t1.patient_id=t2.id  and t2.id=t3.patient_id  ");

            strsql.Append("select distinct(t2.id) as 患者id,t2.pid as 住院号,t2.patient_name as 患者姓名 ,t2.sick_doctor_name  as 管床医生,t2.section_name  as 科室,t2.in_time  as 入院时间  from T_PATIENTS_DOC t1,t_in_patient t2 where t1.patient_id=t2.id ");



            if (!string.IsNullOrEmpty(txtInNum.Text))//住院号
            {
                strsql.Append(" and t2.pid =");
                strsql.Append(" '" + txtInNum.Text + "' ");
            }
            if (!string.IsNullOrEmpty(txtNme.Text))//患者名
            {
                strsql.Append(" and t2.patient_name like");
                strsql.Append(" '%" + txtNme.Text + "%'");
            }
            if (cboSection.Text != "全院")//科室
            {
                strsql.Append("  and t2.section_name =");
                strsql.Append(" '" + cboSection.Text + "'");
            }
            if (!string.IsNullOrEmpty(cboDoctor.Text))//管床医生
            {
                strsql.Append(" and t2.sick_doctor_name =");
                strsql.Append(" '" + cboDoctor.Text + "'");
            }
            if (cheBoxintime.Checked == true)// 入院时间
            {
                strsql.Append(" and (to_char(t2.in_time ,'yyyy-MM-dd') >=");
                strsql.Append(" '" + dateTimeStrat.Value.ToString("yyyy-MM-dd") + "')");
                strsql.Append(" and (to_char(t2.in_time ,'yyyy-MM-dd') <=");
                strsql.Append(" '" + dateTimeEnd.Value.ToString("yyyy-MM-dd") + "')");
            }


         

            DataSet ds = App.GetDataSet(strsql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvDocList.DataSource = dt;
            }
          

            



        }
        public void getlist_JF()
        {
            StringBuilder strsql = new StringBuilder();

            strsql.Append("select distinct(t2.id) as 患者id,t2.pid as 住院号,t2.patient_name as 患者姓名 ,t2.sick_doctor_name  as 管床医生,t2.section_name  as 科室,t2.in_time  as 入院时间,t3.lockmakr as 封存状态 ,t3.lockpeople as 封存人,t3.locktime as 封存时间 , t3.safeuppeople as 解封人,t3.safeuptime as 解封时间 from T_PATIENTS_DOC t1,t_in_patient t2,t_docsafeup t3 where t1.patient_id=t2.id  and t2.id=t3.patient_id  ");

            // strsql.Append("select distinct(t2.id) as 患者id,t2.pid as 住院号,t2.patient_name as 患者姓名 ,t2.sick_doctor_name  as 管床医生,t2.section_name  as 科室,t2.in_time  as 入院时间, from T_PATIENTS_DOC t1,t_in_patient t2,t_docsafeup t3 where t1.patient_id=t2.id");



            if (!string.IsNullOrEmpty(txtInNum.Text))//住院号
            {
                strsql.Append(" and t2.pid =");
                strsql.Append(" '" + txtInNum.Text + "' ");
            }
            if (!string.IsNullOrEmpty(txtNme.Text))//患者名
            {
                strsql.Append(" and t2.patient_name like");
                strsql.Append(" '%" + txtNme.Text + "%'");
            }
            if (cboSection.Text != "全院")//科室
            {
                strsql.Append("  and t2.section_name =");
                strsql.Append(" '" + cboSection.Text + "'");
            }
            if (!string.IsNullOrEmpty(cboDoctor.Text))//管床医生
            {
                strsql.Append(" and t2.sick_doctor_name =");
                strsql.Append(" '" + cboDoctor.Text + "'");
            }
            if (cheBoxintime.Checked == true)// 入院时间
            {
                strsql.Append(" and (to_char(t2.in_time ,'yyyy-MM-dd') >=");
                strsql.Append(" '" + dateTimeStrat.Value.ToString("yyyy-MM-dd") + "')");
                strsql.Append(" and (to_char(t2.in_time ,'yyyy-MM-dd') <=");
                strsql.Append(" '" + dateTimeEnd.Value.ToString("yyyy-MM-dd") + "')");
            }


            DataTable dt = new DataTable();
            dt = App.GetDataSet(strsql.ToString()).Tables[0];

            dgvDocList.DataSource = dt;

            for (int i = 0; i < this.dgvDocList.Rows.Count; i++)
            {
                if (this.dgvDocList.Rows[i].Cells["封存状态"].Value.ToString() == "0")
                {
                    dgvDocList.Rows[i].Cells["封存状态"].Value = "已封存";
                }
                if (this.dgvDocList.Rows[i].Cells["封存状态"].Value.ToString() == "1")
                {
                    dgvDocList.Rows[i].Cells["封存状态"].Value = "已解封";
                }
            }

            //dgvDocList.Columns["入院时间"].Width = 150;
            //dgvDocList.Columns["封存时间"].Width = 150;
            //dgvDocList.Columns["解封时间"].Width = 150;

        }
        /// <summary>
        ///绑定科室
        /// </summary>
        private void DataBindSection()
        {
            try
            {
                string sql = "select a.sid,section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        DataRow row = dt.NewRow();
                        row[0] = "0";
                        row[1] = "全院";
                        dt.Rows.InsertAt(row, 0);
                        cboSection.DataSource = dt;
                        cboSection.DisplayMember = "section_name";
                        cboSection.ValueMember = "sid";
                        cboSection.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("绑定科室错误！" + ex.Message);
            }
        }

        #region   选择管床医生
        ///// <summary>
        ///// 选择管床医生
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Down)
        //        {
        //            App.SelectFastCodeCheck();
        //        }
        //        else if (e.KeyCode == Keys.Left)
        //        {
        //        }
        //        else if (e.KeyCode == Keys.Right)
        //        {
        //        }
        //        else if (e.KeyCode == Keys.Escape)
        //        {
        //            App.HideFastCodeCheck();
        //        }
        //        else
        //        {
        //            if (!App.FastCodeFlag)
        //            {
        //                if (txtDoctor.Text.Trim() != "")
        //                {
        //                    App.SelectObj = null;
        //                    string sql_select = "select distinct(a.user_id) as 序号,a.user_name as 姓名,g.name as 职称,m.section_name as 科室 from t_userinfo a" +
        //                                        " inner join t_account_user b on a.user_id=b.user_id" +
        //                                        " inner join t_account c on b.account_id = c.account_id" +
        //                                        " inner join t_acc_role d on d.account_id = c.account_id" +
        //                                        " inner join t_role e on e.role_id = d.role_id" +
        //                                        " inner join t_acc_role_range f on d.id = f.acc_role_id" +
        //                                        " inner join t_data_code g on g.id=a.u_tech_post" +
        //                                        " inner join t_sectioninfo m on f.section_id=m.sid" +
        //                                        " where e.role_type='D' and UPPER(a.shortcut_code) like '" + txtDoctor.Text.ToUpper().Trim() + "%'";
        //                    App.FastCodeCheck(sql_select, txtDoctor, "姓名", "职称");
        //                }
        //            }
        //            App.FastCodeFlag = false;
        //        }
        //    }
        //    catch
        //    { }
        //    finally
        //    {
        //        App.FastCodeFlag = false;
        //    }
        //}
        #endregion
        /// <summary>
        /// 绑定管床医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDoctor.DataSource = null;
            if (Convert.ToInt32(cboSection.SelectedIndex) != 0)
            {
                cboDoctor.DataSource = DataInit.GetSectionDoctor(cboSection.SelectedValue.ToString(), true);
                cboDoctor.ValueMember = "user_id";
                cboDoctor.DisplayMember = "user_name";
            }
        }
        #region   选择入院时间条件
        /// <summary>
        /// 选择条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cheBoxintime_Click(object sender, EventArgs e)
        {
            if (cheBoxintime.Checked == true)
            {
                dateTimeStrat.Enabled = true;
                dateTimeEnd.Enabled = true;
            }
            else
            {
                dateTimeStrat.Enabled = false;
                dateTimeEnd.Enabled = false;
            }
        }
        #endregion

        #region   解锁文书
        /// <summary>
        /// 解封文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 解锁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocList.CurrentCell != null)
            {
                int n = this.dgvDocList.CurrentCell.RowIndex;
                int patientid = Convert.ToInt32(this.dgvDocList.Rows[n].Cells["患者ID"].Value.ToString());

                string strdqdlr = App.UserAccount.UserInfo.User_name.ToString();
                ArrayList Sqllist = new ArrayList();
                string sql = "update  t_docsafeup t set t.safeuppeople = '" + strdqdlr + "',t.safeuptime=to_date('" +
                            DateTime.Now.ToString() + "','yyyy-mm-dd hh24:mi:ss'),t.lockmakr = 1 where t.patient_id = " + patientid + "";
                Sqllist.Add(sql);
                string str_updateSql = "update t_patients_doc t set t.issafeup='' where  t.patient_id='" + patientid + "'";
                Sqllist.Add(str_updateSql);
                string[] sqlArr = new string[Sqllist.Count];
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    sqlArr[i] = Sqllist[i].ToString();
                }
                int m = App.ExecuteBatch(sqlArr);
                if (m > 0)
                {
                    MessageBox.Show("解封成功！");
                }
                else
                {
                    MessageBox.Show("解封成功！");
                }
                getlist_JF();
            }
        }
        #endregion
        #region 通过住院号进行解锁 160601
        /// <summary>
        /// 袁杨添加 通过住院号进行解锁 160601
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtZYH.Text.ToString() != "")
                {
                    string strPatient_Id = "";
                    string strSql_patient = "select id from t_in_patient t where t.pid='" + txtZYH.Text.ToString() + "'";
                    DataSet ds_patient = App.GetDataSet(strSql_patient);
                    if (ds_patient.Tables[0].Rows.Count > 0)
                    {
                        strPatient_Id = ds_patient.Tables[0].Rows[0]["id"].ToString();
                    }
                    if (strPatient_Id != "")
                    {
                        string strSql_sd = "update T_DOCLOCK t set t.lockbiaoshi='0',t.lockpeople='李倩' where t.patient_id='" + strPatient_Id + "'";
                        int n = App.ExecuteSQL(strSql_sd);
                        if (n > 0)
                        {
                            MessageBox.Show("解锁成功！");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("解锁失败！");
                            return;
                        }
                    }


                }
            }
            catch
            {

            }
        }
        #endregion
        /// <summary>
        /// 封存功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 封存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocList.CurrentCell != null)
            {
                int n = this.dgvDocList.CurrentCell.RowIndex;

                int patientid = Convert.ToInt32(this.dgvDocList.Rows[n].Cells["患者ID"].Value.ToString());
                ArrayList Sqllist = new ArrayList();
                string strdqdlr = App.UserAccount.UserInfo.User_name.ToString();
                string strsql = "select t.lockmakr from t_docsafeup t where t.patient_id='" + patientid + "'";
                DataSet ds_sql = App.GetDataSet(strsql);
                if (ds_sql.Tables[0].Rows.Count > 0)
                {
                    if (ds_sql.Tables[0].Rows[0]["lockmakr"].ToString() == "0")
                    {
                        MessageBox.Show("当前患者病历已经封存完毕,无法进行再次封存！");
                        return;
                    }
                    if (ds_sql.Tables[0].Rows[0]["lockmakr"].ToString() == "1")
                    {
                        string strupdate_sql = "update t_docsafeup t set t.lockmakr='0', t.lockpeople='" + strdqdlr + "',t.locktime=to_date('" + DateTime.Now.ToString() + "','yyyy-mm-dd hh24:mi:ss'),t.safeuppeople='',t.safeuptime='' where t.patient_id='" + patientid + "'";
                        Sqllist.Add(strupdate_sql);
                    }
                }

                else
                {
                    int m = App.GenId("t_docsafeup", "id");
                    string sql = @" insert into t_docsafeup (id, patient_id, lockmakr, lockpeople, locktime, safeuppeople, safeuptime)
                                                                                             values
                                ('" + m + "', '" + patientid + "', '0', '" + strdqdlr + "', to_date('" + DateTime.Now.ToString() + "','yyyy-mm-dd hh24:mi:ss'), '', '')";
                    Sqllist.Add(sql);
                }
                string strSql_update = "update t_patients_doc t set t.issafeup='0' where t.patient_id='" + patientid + "'";
                Sqllist.Add(strSql_update);
                string[] sqlArr = new string[Sqllist.Count];
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    sqlArr[i] = Sqllist[i].ToString();
                }
                int result = App.ExecuteBatch(sqlArr);
                if (result > 0)
                {
                    MessageBox.Show("封存成功！");
                }
                else
                {
                    MessageBox.Show("封存失败！");
                }
                getlist_JF();
            }
        }

        private void btnJF_Click(object sender, EventArgs e)
        {
            getlist_JF();
        }

        private void dgvDocList_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    int n = this.dgvDocList.CurrentCell.RowIndex;
            //    if (this.dgvDocList.Rows[n].Cells["封存人"].Value != "")
            //    {
            //        封存ToolStripMenuItem.Visible = false;
            //    }
            //    else
            //    {
            //        封存ToolStripMenuItem.Visible = true;
            //    }
            //}
        }

        private void dgvDocList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDocList.CurrentCell != null)
            {
                int n = this.dgvDocList.CurrentCell.RowIndex;
                string  patientid = this.dgvDocList.Rows[n].Cells["患者ID"].Value.ToString();
                InPatientInfo inpatient = DataInit.GetInpatientInfoByPid(patientid);
                ucDoctorOperater fq = new ucDoctorOperater(inpatient, "1", "1", "1");
                App.UsControlStyle(fq);
                App.AddNewBusUcControl(fq, inpatient.Patient_Name + "文书查看");
            }
        }
    }
}
