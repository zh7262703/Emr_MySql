using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class ucElementQuality : UserControl
    {
        public ucElementQuality()
        {
            InitializeComponent();
            DataSet ds = getLbxx();
            if (ds != null)
            {
                dgvDataShow.DataSource = ds.Tables[0].DefaultView;
            }
        }

        ///<summary>
        ///量表信息
        ///</summary>
        private DataSet getLbxx()
        {
            string sql = "";//where b.section_id= or b.sick_area_id
            if (Bifrost.App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                sql = "select b.pid 住院号,b.patient_name 姓名,b.sick_bed_no 床号,a.elementtype 类型,a.note 内容 from T_QUALITY_ELEMENT  a inner join t_in_patient b on a.patient_id=b.id and b.sick_area_id='" + Bifrost.App.UserAccount.CurrentSelectRole.Sickarea_Id + "'";
            }
            else
            {
                sql = "select b.pid 住院号,b.patient_name 姓名,b.sick_bed_no 床号,a.elementtype 类型,a.note 内容 from T_QUALITY_ELEMENT  a inner join t_in_patient b on a.patient_id=b.id ";
            }
            DataSet ds = Bifrost.App.GetDataSet(sql);
            return ds;
        }
    }
}
