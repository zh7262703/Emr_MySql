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
        /// 查询显示未及时转科的数据
        /// </summary>
        private void SetDate()
        {
            dgvHISSection.DataSource = null;
            try
            {
                string sql_turnSection = "select (select section_name from t_sectioninfo b where b.sid=a.our_section_id) 转出科室," +
                                        "(select sick_area_name from t_sickareainfo c inner join t_section_area d on c.said=d.said where d.sid=a.our_section_id) 转出病区, " +
                                        "case(select e.action_type from t_inhospital_action e where a.patient_id=e.pid and e.next_id = 0) when '转出' then '是' else '否' end 是否已转出," +
                                        "(select section_name from t_sectioninfo f where f.sid=a.his_section_id) 转入科室," +
                                        "(select sick_area_name from t_sickareainfo g inner join t_section_area d on g.said=d.said where d.sid=a.his_section_id) 转入病区," +
                                        "to_char(a.change_time,'yyyy-MM-dd HH24:mi:ss') HIS接入时间," +
                                        "(select user_name from t_userinfo h inner join t_in_patient j on h.user_id=j.sick_doctor_id where j.id=a.patient_id) 转出科管床医生" +
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
                    dgvHISSection.Columns["HIS接入时间"].Width = 120;
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
