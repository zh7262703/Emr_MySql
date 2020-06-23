using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class ucPatientDocCheck : UserControl
    {
        public ucPatientDocCheck()
        {
            InitializeComponent();
            ucGridviewX1.fg.Sorted += new EventHandler(fg_Sorted);
        }

        /// <summary>
        /// 查询统计       
        /// </summary>
        private void CheckData()
        {
            try
            {
                string Sql = "select distinct t.id,t.section_name as 科室,t.patient_name as 姓名," +
                             "t.pid as 住院号,t.in_time as 入区时间,case when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id in (125,119) and a1.patient_id=t.id)=2 then '两个都写了' when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id=125 and a1.patient_id=t.id)=1 then '首次病程' else '入院记录' end 所写首程或入院记录,case when (select count(tid) from T_PATIENTS_DOC a2 where a2.patient_id=t.id and a2.submitted='Y' and a2.textkind_id=158)>0 then '完成' else '未完成' end 出院记录,case when (select c.action_type from t_inhospital_action c where c.next_id=0 and c.action_state=3 and c.pid=t.id and rownum=1)='出区' then '是' else '否' end 是否出院," +
                             "t.sick_doctor_name 管床医生 from t_in_patient t " +
                             "inner join T_PATIENTS_DOC b on b.patient_id=t.id " +                            
                             "where b.textkind_id=125 or b.textkind_id=119 order by t.section_name";

              
                    ucGridviewX1.DataBd(Sql, "id", "", "");                                                         
                    ucGridviewX1.fg.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    
                    /*
                     * 已出院，但是出院记录未完成的
                     */
                    for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
                    {
                        if (ucGridviewX1.fg["出院记录", i].Value.ToString() == "未完成")
                        {
                            if (ucGridviewX1.fg["是否出院", i].Value.ToString() == "是")
                            {
                                for (int j = 0; j < ucGridviewX1.fg.Columns.Count; j++)
                                {
                                    ucGridviewX1.fg[j, i].Style.ForeColor = Color.Red;
                                }                                  
                            }
                        }
                    }
                    ucGridviewX1.fg.Refresh();                    
                                    
            }
            catch//(Exception ex)
            {
                //App.MsgErr("查询出错，原因："+ex.ToString());
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //CheckData();
        }

        private void ucPatientDocCheck_Load(object sender, EventArgs e)
        {
            //CheckData();
            timer1.Enabled = true;
        }

        private void fg_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
            {
                if (ucGridviewX1.fg["出院记录", i].Value != null)
                {
                    if (ucGridviewX1.fg["出院记录", i].Value.ToString() == "未完成")
                    {
                        if (ucGridviewX1.fg["是否出院", i].Value.ToString() == "是")
                        {
                            for (int j = 0; j < ucGridviewX1.fg.Columns.Count; j++)
                            {
                                ucGridviewX1.fg[j, i].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }
    }
}
