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
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"select a.id,a.apply_sectionname �������,a.apply_name ������,to_char(a.apply_time,'yyyy-MM-dd hh24:mi') ��������,case a.consultation_type when 0 then '��ͨ����' else '������' end �������,
                         b.patient_name ��������,a.pid סԺ��,case b.gender_code when '0' then '��' else 'Ů' end �Ա�,b.age||b.age_unit ����,b.in_time ��Ժʱ��,a.consul_section_name �������,a.consul_r_name ����ҽʦ,
                         a.consul_time ����ʱ��
                         from t_consultaion_apply a
                         inner join t_in_patient b on a.patient_id = b.id
                         where a.submited = 'Y' ";

            if (txtName.Text != "")//����������
            {
                sql += " and b.patient_name like '" + txtName.Text + "%'";
            }
            if (txtPid.Text != "")//��סԺ��
            {
                sql += " and a.pid like '%" + txtPid.Text + "%'";
            }
            //����������
            if (cboConsulType.SelectedIndex == 0)//������
            {
                if (cbxInSection.Text != "��ѡ��")
                    sql += " and apply_sectionid=" + cbxInSection.SelectedValue;
            }
            else
            {
                sql += " and consul_record_submite_state=1 ";
                if (cbxInSection.Text != "��ѡ��")
                    sql += " and consul_record_section_ID=" + cbxInSection.SelectedValue;
            }
            if (checkBoxX1.Checked)//��ʱ���
            {
                if (cboConsulTimeType.SelectedIndex == 0)//����������
                {
                    sql += " and apply_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 1)//����������
                {
                    sql += " and consul_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 2)//����Ժʱ��
                {
                    sql += " and b.in_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                else if (cboConsulTimeType.SelectedIndex == 3)//����Ժʱ��
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
        /// ��ȡ�����б�
        /// </summary>
        private void GetSection()
        {
            string sql_section = "select sid,section_name from t_sectioninfo a where a.enable_flag='Y'";
            //��Ժ����
            DataSet ds_inSection = App.GetDataSet(sql_section);
            if (ds_inSection != null)
            {
                DataRow dr_inSection = ds_inSection.Tables[0].NewRow();
                dr_inSection["sid"] = 0;
                dr_inSection["section_name"] = "��ѡ��";
                ds_inSection.Tables[0].Rows.InsertAt(dr_inSection, 0);

                cbxInSection.DisplayMember = "section_name";
                cbxInSection.ValueMember = "sid";
                cbxInSection.DataSource = ds_inSection.Tables[0];
            }
        }
    }
}
