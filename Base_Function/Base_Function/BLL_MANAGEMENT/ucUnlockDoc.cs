/***************************************
质控文书解锁
20160308 毛成文添加
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

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucUnlockDoc : UserControl
    {
        #region   构造函数
        public ucUnlockDoc()
        {
            InitializeComponent();
        }
        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucUnlockDoc_Load(object sender, EventArgs e)
        {
            dateTimeStrat.Enabled = false;
            dateTimeEnd.Enabled = false;
            DataBindSection();
            getlist();
        }
        #endregion

        #region   刷新
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btoQuery_Click(object sender, EventArgs e)
        {
            getlist();
        }
        #endregion

        #region   绑定dgv列表数据
        /// <summary>
        /// 绑定dgv列表数据
        /// </summary>
        public void getlist()
        {
            StringBuilder strsql = new StringBuilder();


            strsql.Append(@"select 
                     d.doc_name as 文书名称, 
                    tin.patient_name as 患者姓名, tin.pid as 住院号, tin.section_name as 科室, tin.sick_doctor_name as 管床医生
                    , to_char(tin.in_time ,'yyyy-MM-dd HH24:MI:ss') as 入院时间, t.kzsj as 锁定时间, tdk.lockpeople as 解锁人
                    , t.qtbljlxh as 文书ID
                     ,CASE t.WGZT WHEN '0' THEN '无违规信息' WHEN '1' THEN '预警未完成' WHEN '2' THEN '时限内完成' WHEN '3' THEN '超时未完成' 
                      WHEN '4' THEN '超时完成'  WHEN '5' THEN '条件时间前完成'   WHEN '6' THEN '豁免' END 质控状态
                    , te.textname as 文书类型
                    , t.syxh as 患者ID 
                    from qc_zlkzjlk t 
                    left join T_IN_PATIENT tin on t.syxh = tin.id 
                    left join T_DOCLOCK tdk on  to_char( t.blxh) = tdk.doctype and t.syxh = tdk.patient_id 
                    left join t_text te on te.id=t.blxh
                    left join t_patients_doc d on d.tid=t.qtbljlxh
                    where (t.kzbz = '1' ) and (tdk.lockbiaoshi = 1 or tdk.lockbiaoshi = 0) and t.zklb ='YL' ");
            //strsql.Append(" select ");
            //strsql.Append(" substr(t.note,instr(t.note, '\"', 1, 1) + 1,(instr(t.note, '\"', 1, 2) - instr(t.note, '\"', 1, 1) - 1)) as 文书名称,");
            //strsql.Append(" tin.patient_name as 患者姓名,");
            //strsql.Append(" tin.pid as 住院号,");
            //strsql.Append(" tin.section_name as 科室,");
            //strsql.Append(" tin.sick_doctor_name as 管床医生,");
            //strsql.Append(" to_char(tin.in_time ,'yyyy-MM-dd HH24:MI:ss') as 入院时间,");
            //strsql.Append(" substr(t.note,0,20) as 锁定时间,");
            //strsql.Append(" tdk.lockpeople as 解锁人,");
            //strsql.Append(" t.tid as 文书ID,");
            //strsql.Append(" t.pv as 质控灯,");
            //strsql.Append(" t.doctype as 文书类型,");
            //strsql.Append(" t.patient_id as 患者ID");
            //strsql.Append(" from t_quality_record t");
            //strsql.Append(" left join T_IN_PATIENT tin");
            //strsql.Append(" on t.patient_id = tin.id");
            //strsql.Append(" left join T_DOCLOCK tdk");
            //strsql.Append(" on t.doctype = tdk.doctype and t.patient_id = tdk.patient_id");
            //strsql.Append(" where (t.pv = 1 or t.pv=3)");
            //strsql.Append(" and (tdk.lockbiaoshi = 1 or tdk.lockbiaoshi = 0)");

            //strsql.Append(" and substr(t.note,0,20) in");
            //strsql.Append(" (select min(substr(t.note, 0, 20))  from t_quality_record t ");
            //strsql.Append(" where t.patient_id in (select patient_id from t_doclock) ");
            //strsql.Append(" and (substr(t.note,instr(t.note, '\"', 1, 1) + 1,(instr(t.note, '\"', 1, 2) - instr(t.note, '\"', 1, 1) - 1))) ");
            //strsql.Append(" in (select doctype from t_doclock)");
            //strsql.Append(" group by  substr(t.note,instr(t.note, '\"', 1, 1) + 1,(instr(t.note, '\"', 1, 2) - instr(t.note, '\"', 1, 1) - 1)),t.patient_id )");
            if (!string.IsNullOrEmpty(txtInNum.Text))//住院号
            {
                strsql.Append(" and tin.pid =");
                strsql.Append(" '" + txtInNum.Text + "' ");
            }
            if (!string.IsNullOrEmpty(txtNme.Text))//患者名
            {
                strsql.Append(" and tin.patient_name like");
                strsql.Append(" '%" + txtNme.Text + "%'");
            }
            if (cboSection.Text != "全院")//科室
            {
                strsql.Append(" and tin.section_name =");
                strsql.Append(" '" + cboSection.Text + "'");
            }
            if (!string.IsNullOrEmpty(cboDoctor.Text))//管床医生
            {
                strsql.Append(" and tin.sick_doctor_name =");
                strsql.Append(" '" + cboDoctor.Text + "'");
            }
            if (cheBoxintime.Checked == true)// 入院时间
            {
                strsql.Append(" and (to_char(tin.in_time ,'yyyy-MM-dd') >=");
                strsql.Append(" '" + dateTimeStrat.Value.ToString("yyyy-MM-dd") + "')");
                strsql.Append(" and (to_char(tin.in_time ,'yyyy-MM-dd') <=");
                strsql.Append(" '" + dateTimeEnd.Value.ToString("yyyy-MM-dd") + "')");
            }
            strsql.Append(" order by t.syxh asc");

            DataTable dt = new DataTable();
            dt = App.GetDataSet(strsql.ToString()).Tables[0];

            dgvDocList.DataSource = dt;

            dgvDocList.Columns["入院时间"].Width = 200;
            dgvDocList.Columns["锁定时间"].Width = 200;
            dgvDocList.Columns["文书ID"].Visible = false;
            dgvDocList.Columns["质控状态"].Visible = false;
            dgvDocList.Columns["患者ID"].Visible = false;
            dgvDocList.Columns["文书类型"].Visible = false;
        }
        #endregion

        #region   绑定科室
        /// <summary>
        ///绑定科室
        /// </summary>
        private void DataBindSection()
        {
            try
            {
                string sql = "select a.sid,section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
                DataSet ds = App.GetDataSet(sql);
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
            catch (Exception ex)
            {
                App.MsgErr("绑定科室错误！" + ex.Message);
            }
        }
        #endregion

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
        #region    绑定管床医生
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
        #endregion

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
        /// 解锁文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 解锁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocList.CurrentCell != null)
            {
                int n = this.dgvDocList.CurrentCell.RowIndex;
                int patientid = Convert.ToInt32(this.dgvDocList.Rows[n].Cells["患者ID"].Value.ToString());
                string strdoctype = this.dgvDocList.Rows[n].Cells["文书类型"].Value.ToString();
                this.dgvDocList.Rows[n].Cells["解锁人"].Value = App.UserAccount.UserInfo.User_name.ToString();
                string sql = "update  T_DOCLOCK t set t.lockpeople = '" + App.UserAccount.UserInfo.User_name.ToString() + "'" +
                            ",t.lockbiaoshi = 0 where t.patient_id = " + patientid + " and t.doctype ='" + strdoctype + "'";
                App.ExecuteSQL(sql); 
                MessageBox.Show("解锁成功！");
            }
        }
        #endregion
        /// <summary>
        /// 袁杨添加 通过住院号进行解锁 160601
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtZYH.Text.ToString()!="")
                {
                    string strPatient_Id = "";
                    string strSql_patient = "select id from t_in_patient t where t.pid='" + txtZYH.Text.ToString() + "'";
                    DataSet ds_patient = App.GetDataSet(strSql_patient);
                    if (ds_patient.Tables[0].Rows.Count>0)
                    {
                        strPatient_Id = ds_patient.Tables[0].Rows[0]["id"].ToString();
                    }
                    if (strPatient_Id!="")
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
    }
}
