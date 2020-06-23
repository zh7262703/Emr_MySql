using Bifrost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor
{
    public partial class frmUser : DevComponents.DotNetBar.Office2007Form
    {

        public frmUser()
        {
            InitializeComponent();

            App.Ini();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            //在院病人信息
            string sql = "select ID,a.patient_name as 姓名,a.gender_code as 性别," +
                         "a.age as 年龄,a.in_time as  入院时间,a.section_name as 科室," +
                         "a.sick_area_name as 病区,a.sick_doctor_name as 管床医生 from t_in_patient a where a.id in " +
                         "(select b.patient_id from t_inhospital_action b " +
                         " where b.next_id=0 and b.action_type<>'出区')";


            DataSet ds = App.GetDataSet(sql);
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            string id = dataGridViewX1["ID", e.RowIndex].Value.ToString();
            InPatientInfo cttp = tempetureDataComm.GetInpatientInfoByPid(id);
            frmOperaterTest fc = new frmOperaterTest(cttp);
            fc.ShowDialog();

            //}
            //catch (Exception ex)
            //{
            //    App.MsgErr(ex.Message);
            //}
        }
    }
}
