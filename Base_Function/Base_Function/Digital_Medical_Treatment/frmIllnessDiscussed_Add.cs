using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Digital_Medical_Treatment
{
    public partial class frmIllnessDiscussed_Add : DevComponents.DotNetBar.Office2007Form
    {
        public frmIllnessDiscussed_Add()
        {
            InitializeComponent();
        }
        public int inPatient_id = 0;
        /// <summary>
        /// �Զ���������-���벡������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSql = @"select t.id,
                                   t.pid,
                                   t.patient_name,
                                   case t.gender_code
                                     when '0' then
                                      '��'
                                     else
                                      'Ů'
                                   end �Ա�,
                                   t.age || t.age_unit ����,
                                   t1.diagnose_name,
                                   t.in_time
                              from t_in_patient t, t_diagnose_item t1
                             where t.id = t1.patient_id 
                                   and t1.diagnose_sort='1'
                                   and t.patient_name='" + txtPatientName.Text+ "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count>0)
                {
                    inPatient_id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                    txtPatientName.Text = ds.Tables[0].Rows[0]["patient_name"].ToString();
                    txtPid.Text = ds.Tables[0].Rows[0]["pid"].ToString();
                    labelX2.Text = ds.Tables[0].Rows[0]["�Ա�"].ToString();
                    labelX4.Text = ds.Tables[0].Rows[0]["����"].ToString();
                    Txtdiagnose_Name.Text = ds.Tables[0].Rows[0]["diagnose_name"].ToString();

                }
            }
            catch 
            {
                
                
            }
        }
        /// <summary>
        /// �Զ���������-���벡��סԺ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPid_TextChanged(object sender, EventArgs e)
        {
            string  strSql = @"select t.id,
                                   t.pid,
                                   t.patient_name,
                                   case t.gender_code
                                     when '0' then
                                      '��'
                                     else
                                      'Ů'
                                   end �Ա�,
                                   t.age || t.age_unit ����,
                                   t1.diagnose_name,
                                   t.in_time
                              from t_in_patient t, t_diagnose_item t1
                             where t.id = t1.patient_id 
                                   and t1.diagnose_sort='1'
                                   and t.pid='" + txtPid.Text + "'";
            DataSet ds = App.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                inPatient_id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                txtPatientName.Text = ds.Tables[0].Rows[0]["patient_name"].ToString();
                txtPid.Text = ds.Tables[0].Rows[0]["pid"].ToString();
                labelX2.Text = ds.Tables[0].Rows[0]["�Ա�"].ToString();
                labelX4.Text = ds.Tables[0].Rows[0]["����"].ToString();
                Txtdiagnose_Name.Text = ds.Tables[0].Rows[0]["diagnose_name"].ToString();

            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientName.Text=="")
                {
                    App.Msg("�������Ʋ���Ϊ�գ�");
                    return;
                }
                if (txtPid.Text=="")
                {
                    App.Msg("����סԺ�Ų���Ϊ�գ�");
                    return;
                }
                if (Txtdiagnose_Name.Text == "")
                {
                    App.Msg("������ϲ���Ϊ�գ�");
                    return;
                }
                if (txtEditer.Text == "")
                {
                    App.Msg("�༭�߲���Ϊ�գ�");
                    return;
                }
                string strDateTime = dtTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                int int_id = App.GenId("t_in_patient_illness", "id");
                string strInsert_sql = @" insert into t_in_patient_illness
                                                 (id, patient_id, patient_name, pid, sex, age, diagnose_name, time, editer_id, editer_name)
                                               values
                                                 ('" + int_id + "', '"+inPatient_id+"', '" + txtPatientName.Text + "', '" + txtPid.Text + "', '" + labelX2.Text + "', '" + labelX4.Text + "', '" + Txtdiagnose_Name.Text + "', to_date('" + strDateTime + "','yyyy-MM-dd hh24:mi:ss'), '', '" + txtEditer.Text + "')";
                int n = App.ExecuteSQL(strInsert_sql);
                if (n>0)
                {
                    App.Msg("����ɹ���");
                    btnClear_Click(null,null);
                    
                }
            }
            catch 
            {
                
            }
        }
        /// <summary>
        /// ��ղ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtPatientName.Text = "";
                txtPid.Text = "";
                labelX2.Text = "";
                labelX4.Text = "";
                Txtdiagnose_Name.Text = "";
                txtEditer.Text = "";

            }
            catch 
            {
                
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch 
            {
                
            }
        }
    }
}