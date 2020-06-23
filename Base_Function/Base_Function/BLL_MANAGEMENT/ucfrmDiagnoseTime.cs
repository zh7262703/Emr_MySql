using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucfrmDiagnoseTime : UserControl
    {
        string Sql = "select t.id,t.section_name as 患者科室,t.patient_name as 姓名,t.pid as 住院号,t.sick_doctor_name as 管床医师,t.in_time as 入院时间,b.m_diagnose_time as 确定诊断时间 from t_in_patient t inner join t_patients_doc a on a.patient_id=t.id inner join t_diagnose_unrole b on b.tid=a.tid";

        /// <summary>
        /// 
        /// </summary>
        public ucfrmDiagnoseTime()
        {
            InitializeComponent();
            BindSection();
            
        }

        /// <summary>
        /// 初始化科室值
        /// </summary>
        public void BindSection()
        {
            try
            {
                DataSet ds_section = App.GetDataSet("select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid");
                DataRow tn = ds_section.Tables[0].NewRow();
                ds_section.Tables[0].Rows.Add(tn);
                cmbSections.DataSource = ds_section.Tables[0].DefaultView;
                cmbSections.DisplayMember = "section_name";
                cmbSections.ValueMember = "sid";
                cmbSections.SelectedIndex = ds_section.Tables[0].Rows.Count-1;
            }
            catch
            { }
        }

        /// <summary>
        /// 查询不符合规范的确定诊断集合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = Sql;
                if (cmbSections.Text.Trim() != "")
                {
                    strSql = strSql + " where t.section_id=" + cmbSections.SelectedValue.ToString() + "";
                }

                ucGridviewX1.DataBd(strSql, "id", "", "");
                ucGridviewX1.fg.AutoResizeColumns();
                ucGridviewX1.fg.Columns[0].Visible = false;
            }
            catch(Exception ex)
            {
                App.MsgErr("查询失败！原因："+ex.ToString());
            }
        }
    }
}
