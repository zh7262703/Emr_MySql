using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class uc30day : UserControl
    { 
        public uc30day()
        {
            InitializeComponent();

            string sql30 = @"select patient_name 姓名,(case when gender_code='0' then '男' else '女' end) 性别,age||age_unit 年龄,sick_bed_no 床位,ceil(sysdate-to_date(to_char(in_time,'yyyy-MM-dd'),'yyyy-MM-dd')) 住院天数,trunc((ceil(sysdate-to_date(to_char(in_time,'yyyy-MM-dd'),'yyyy-MM-dd'))/30)) 需写份数,(select count(*) from t_patients_doc where patient_id=a.id and textkind_id=131) 已写份数 from t_in_patient a where leave_time is null and a.document_time is null  and trunc((ceil(sysdate-to_date(to_char(in_time,'yyyy-MM-dd'),'yyyy-MM-dd'))/30))>(select count(*) from t_patients_doc where patient_id=a.id and textkind_id=131) and sick_doctor_id='" + Bifrost.App.UserAccount.UserInfo.User_id + "' and section_id=" + Bifrost.App.UserAccount.CurrentSelectRole.Section_Id + " order by cast(sick_bed_no as number)";
            //30天病人提醒
            DataSet ds =Bifrost.App.GetDataSet(sql30);
            if (ds != null)
            {
                dgvInfo.DataSource = ds.Tables[0];
            }

        }
    }
}
