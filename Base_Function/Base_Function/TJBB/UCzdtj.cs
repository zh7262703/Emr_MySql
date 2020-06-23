using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.TJBB
{
    public partial class UCzdtj : UserControl
    {
        public UCzdtj()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        private void BindSection()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            //插入默认选项
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["sid"] = 0;
                dr["section_name"] = "全院";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboSection.DataSource = ds.Tables[0].DefaultView;
            cboSection.DisplayMember = "section_name";
            cboSection.ValueMember = "sid";
            cboSection.SelectedIndex = 0;
        }


        /// <summary>
        /// 绑定医保
        /// </summary>
        private void BindYB()
        {
            string sql = "select id,name from t_data_code where type='70'";
            DataSet ds = App.GetDataSet(sql);
            //插入默认选项
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["id"] = 0;
                dr["name"] = "全部";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboYBLX.DataSource = ds.Tables[0].DefaultView;
            cboYBLX.DisplayMember = "name";
            cboYBLX.ValueMember = "id";
            cboYBLX.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定诊断
        /// </summary>
        private void BindZD()
        {
            string sql = "select id,name from t_data_code where type='65'";
            DataSet ds = App.GetDataSet(sql);
            //插入默认选项
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["id"] = 0;
                dr["name"] = "全部";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboZDLX.DataSource = ds.Tables[0].DefaultView;
            cboZDLX.DisplayMember = "name";
            cboZDLX.ValueMember = "id";
            cboZDLX.SelectedIndex = 0;
        }

        private void UCzdtj_Load(object sender, EventArgs e)
        {
            BindSection();
            BindZD();
            BindYB();
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                cboSection.SelectedValue = App.UserAccount.CurrentSelectRole.Section_Id;
                cboSection.Enabled = false;
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                cboSection.SelectedValue = App.ReadSqlVal("select sid from t_section_area where said='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'", 0, "sid");
                cboSection.Enabled = false;
            }
            else
            {
                cboSection.SelectedValue = 0;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = getSQL();
                DataTable dt = App.GetDataSet(sql).Tables[0];
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {

            }

        }

        string start = "";
        string end = "";

        private string getSQL()
        {
            string sel_sql = "";
            string where_sql = "";

            if (cboSection.SelectedIndex != 0)
            {
                where_sql += " and a.section_id='" + cboSection.SelectedValue.ToString() + "'";
            }
            if (cboYBLX.SelectedIndex != 0)
            {
                where_sql += " and a.Pay_Manner='" + cboYBLX.Text.ToString() + "'";
            }
            if (cboZDLX.SelectedIndex != 0)
            {
                where_sql += " and d.diagnose_type='" + cboZDLX.SelectedValue.ToString() + "'";
            }
            if (rdoInTime.Checked)
            {
                start = dtiInStart.Value.ToString("yyyy-MM-dd");
                end = dtiInEnd.Value.ToString("yyyy-MM-dd");
                where_sql += " and to_char(in_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "'";
            }
            else
            {
                start = dtiLeaveStart.Value.ToString("yyyy-MM-dd");
                end = dtiLeaveEnd.Value.ToString("yyyy-MM-dd");
                where_sql += " and to_char(leave_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "'";
            }
            if (txtZDMC.Text.Trim().Length > 0)
            {
                where_sql += " and diagnose_name like '%" + txtZDMC.Text.Trim() + "%'";
            }
            sel_sql += @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,Pay_Manner as 医保类型,in_time as 入院时间,leave_time as 出院时间,icd.code as 诊断编码,diagnose_name as 诊断名称,c.name as 诊断类型,sick_doctor_name as 管床医生 
                        from t_diagnose_item d inner join t_in_patient a on a.id=d.patient_id left join t_data_code c on d.diagnose_type=c.id left join diag_def_icd10 icd on icd.name=d.diagnose_name";
            //科室条件
            sel_sql += @" where 1=1 " + where_sql + " order by a.in_time";

            return sel_sql;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataInit.DataToExcel(dgv);
        }
    }
}
