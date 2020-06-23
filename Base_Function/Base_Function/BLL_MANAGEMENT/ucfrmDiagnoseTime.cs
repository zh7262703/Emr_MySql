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
        string Sql = "select t.id,t.section_name as ���߿���,t.patient_name as ����,t.pid as סԺ��,t.sick_doctor_name as �ܴ�ҽʦ,t.in_time as ��Ժʱ��,b.m_diagnose_time as ȷ�����ʱ�� from t_in_patient t inner join t_patients_doc a on a.patient_id=t.id inner join t_diagnose_unrole b on b.tid=a.tid";

        /// <summary>
        /// 
        /// </summary>
        public ucfrmDiagnoseTime()
        {
            InitializeComponent();
            BindSection();
            
        }

        /// <summary>
        /// ��ʼ������ֵ
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
        /// ��ѯ�����Ϲ淶��ȷ����ϼ���
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
                App.MsgErr("��ѯʧ�ܣ�ԭ��"+ex.ToString());
            }
        }
    }
}
