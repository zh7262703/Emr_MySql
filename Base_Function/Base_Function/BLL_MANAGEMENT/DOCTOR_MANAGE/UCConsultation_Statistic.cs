using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class UCConsultation_Statistic : UserControl
    {
        public UCConsultation_Statistic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"select a.id,a.apply_sectionname 申请科室,a.apply_name 申请人,to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请日期,case a.consultation_type when 0 then '普通会诊' else '急会诊' end 会诊类别,
                         b.patient_name 患者姓名,a.pid 住院号,case b.gender_code when '0' then '男' else '女' end 性别,b.age||b.age_unit 年龄,b.in_time 入院时间,a.consul_section_name 会诊科室,a.consul_r_name 会诊医师,
                         a.consul_time 会诊时间
                         from t_consultaion_apply a
                         inner join t_in_patient b on a.patient_id = b.id
                         where a.submited = 'Y' ";

            if (txtName.Text != "")//按患者姓名
            {
                sql += " and b.patient_name like '" + txtName.Text + "%'";
            }
            if (txtPid.Text != "")//按住院号
            {
                sql += " and a.pid like '%" + txtPid.Text + "%'";
            }
            //按会诊类型
            if (cboConsulType.SelectedIndex == 0)//发会诊
            {
                if (cbxInSection.Text != "请选择")
                    sql += " and apply_sectionid=" + cbxInSection.SelectedValue;
            }
            else
            {
                sql += " and consul_record_submite_state=1 ";
                if (cbxInSection.Text != "请选择")
                    sql += " and consul_record_section_ID=" + cbxInSection.SelectedValue;
            }
            if (checkBoxX1.Checked)//按时间段
            {
                if (cboConsulTimeType.SelectedIndex == 0)//按申请日期
                {
                    sql += " and apply_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 1)//按会诊日期
                {
                    sql += " and consul_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 2)//按入院时间
                {
                    sql += " and b.in_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 3)//按出院时间
                {
                    sql += " and b.die_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
            }
            sql += " order by a.apply_time desc";
            ucGridviewX1.DataBd(sql, "id", "", "");
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                cboConsulTimeType.Enabled = true;
                dtpBegin.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                cboConsulTimeType.Enabled = false;
                dtpBegin.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

        private void UCConsultation_Statistic_Load(object sender, EventArgs e)
        {
            try
            {
                GetSection();
                cboConsulTimeType.SelectedIndex = 0;
                cboConsulType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 获取科室列表
        /// </summary>
        private void GetSection()
        {
            string sql_section = "select sid,section_name from t_sectioninfo a where a.enable_flag='Y'";
            //入院科室
            DataSet ds_inSection = App.GetDataSet(sql_section);
            if (ds_inSection != null)
            {
                DataRow dr_inSection = ds_inSection.Tables[0].NewRow();
                dr_inSection["sid"] = 0;
                dr_inSection["section_name"] = "请选择";
                ds_inSection.Tables[0].Rows.InsertAt(dr_inSection, 0);

                cbxInSection.DisplayMember = "section_name";
                cbxInSection.ValueMember = "sid";
                cbxInSection.DataSource = ds_inSection.Tables[0];
            }
        }
    }
}
