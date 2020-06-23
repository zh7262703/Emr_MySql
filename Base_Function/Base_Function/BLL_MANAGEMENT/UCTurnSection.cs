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
    public partial class UCTurnSection : UserControl
    {
        public UCTurnSection()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void UCTurnSection_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "12";
        }

        /// <summary>
        /// ��ѯ��ʾδ��ʱת�Ƶ�����
        /// </summary>
        private void SetDate()
        {
            dgvHISSection.DataSource = null;
            try
            {
                string sql_turnSection = "select (select section_name from t_sectioninfo b where b.sid=a.our_section_id) ת������," +
                                        "(select sick_area_name from t_sickareainfo c inner join t_section_area d on c.said=d.said where d.sid=a.our_section_id) ת������, " +
                                        "case(select e.action_type from t_inhospital_action e where a.patient_id=e.pid and e.next_id = 0) when 'ת��' then '��' else '��' end �Ƿ���ת��," +
                                        "(select section_name from t_sectioninfo f where f.sid=a.his_section_id) ת�����," +
                                        "(select sick_area_name from t_sickareainfo g inner join t_section_area d on g.said=d.said where d.sid=a.his_section_id) ת�벡��," +
                                        "to_char(a.change_time,'yyyy-MM-dd HH24:mi:ss') HIS����ʱ��," +
                                        "(select user_name from t_userinfo h inner join t_in_patient j on h.user_id=j.sick_doctor_id where j.id=a.patient_id) ת���ƹܴ�ҽ��" +
                                        " from t_turn_section a ";

                if (comboBox1.Text != "0")
                {
                    DateTime rightNow = App.GetSystemTime();
                    int hours = Convert.ToInt32(comboBox1.Text);
                    rightNow = rightNow.AddHours(-hours);
                    sql_turnSection += " where a.change_time < to_timestamp('" + rightNow + "','yyyy-MM-dd HH24:mi:ss')";
                }
                DataSet ds = App.GetDataSet(sql_turnSection);
                if(ds != null)
                {
                    dgvHISSection.DataSource = ds.Tables[0];
                    dgvHISSection.Columns["HIS����ʱ��"].Width = 120;
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SetDate();
            }
        }
    }
}
