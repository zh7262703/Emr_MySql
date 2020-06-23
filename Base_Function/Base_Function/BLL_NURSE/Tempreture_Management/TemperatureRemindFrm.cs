using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BLL_NURSE.Tempreture_Management
{
        /// <summary>
        /// 特温提醒
        /// </summary>

    public partial class TemperatureRemindFrm : Office2007Form
    {
        private string sql = "select tip.sick_bed_no,tip.patient_name,tqr.note from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  tqr.pv='2' and tqr.patient_id  IN(SELECT t.patient_id FROM t_inhospital_action t WHERE t.action_type not in('出区'))  and noteztime> to_timestamp('{0}','syyyy-mm-dd hh24:mi:ss') and noteztime<  to_timestamp('{1}','syyyy-mm-dd hh24:mi:ss')  order by tip.sick_bed_id, tqr.noteztime asc";

        public TemperatureRemindFrm()
        {
            try
            {
                InitializeComponent();

                this.dataGridView1.CellMouseMove += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseMove);
                this.dataGridView1.CellMouseLeave += new DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);
            }
            catch
            {
            }
        }

        void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
            }
        }

        private void TemperatureRemindFrm_Load(object sender, EventArgs e)
        {
            try
            {
                int currentHour = App.GetSystemTime().Hour;
                if (currentHour < 2 || currentHour > 22)
                {
                    //2:00
                }
                else if (currentHour < 6 && currentHour > 2)
                {
                    //6:00
                }
                else if (currentHour < 10 && currentHour > 6)
                {
                    //10:00
                }
                else if (currentHour < 14 && currentHour > 10)
                {
                    //14:00
                    sql = string.Format(sql, "2011-09-23 10:00:00", "2011-09-23 14:00:00");
                }
                else if (currentHour < 18 && currentHour > 14)
                {
                    //18:00
                }
                else if (currentHour < 22 && currentHour > 18)
                {
                    //22:00
                }
                this.TopMost = true;

                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch
            {
            }
        }
    }
}