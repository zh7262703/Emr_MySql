using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class frmKFXQ : DevComponents.DotNetBar.Office2007Form
    {
        string id_list = "";
        public frmKFXQ(string id)
        {
            InitializeComponent();
            id_list = id;
        }

        private void frmKFXQ_Load(object sender, EventArgs e)
        {
            string sql = getSQL();
            DataTable dt = App.GetDataSet(sql).Tables[0];
            dgv.DataSource = dt;
        }

        private string getSQL()
        {
            string sql = "select a.section_name as 当前科室,a.sick_bed_no as 床号,a.sick_doctor_name as 管床医生,a.pid as 住院号,a.patient_name as 姓名,tds.item as 扣分项目,tds.item_content as 扣分内容,tds.ITEM_SCORE as 扣分值,tds.ITEM_REASON as 扣分理由 from t_in_patient a left join t_deduct_score tds on a.id=tds.item_patientid where a.id in (" + id_list + ") order by a.pid";

            return sql;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataInit.DataToExcel(dgv);
        }




    }
}
