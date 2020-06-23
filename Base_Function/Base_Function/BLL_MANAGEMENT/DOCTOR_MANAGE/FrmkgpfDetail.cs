using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class FrmkgpfDetail : DevComponents.DotNetBar.Office2007Form
    {
        private string paid = "";
        public FrmkgpfDetail()
        {
            InitializeComponent();
        }
        public FrmkgpfDetail(string pid)
        {
            InitializeComponent();
            this.paid = pid;
        }
        private void InitTable(string patient_id)
        {
            string sql = @"select rmv.section_name 科室,rmv.DOCTYPE 文书名称,rmv.PID 住院号,rmv.sick_bed_no 床号,rmv.sick_doctor_name 管床医生,
                            rmv.note 提醒信息,rmv.patient_name 病人姓名,rmv.in_time 入院时间,rmv.leave_time 出院时间,tu.user_name 创建或补录医师,
                            rmv.TAKE_GRADE 扣分 from record_monitor_view rmv
                            left join t_quality_text tqt on rmv.tid=tqt.id and pv!=0
                            left join t_patients_doc tpd on tqt.tid=tpd.tid
                            left join t_userinfo tu on tpd.createid=tu.user_id where rmv.patient_id='" + patient_id + "'";
            DataSet ds = App.GetDataSet(sql);
            dgvkgpflist.DataSource = ds.Tables[0].DefaultView;
            dgvkgpflist.Columns["提醒信息"].Width = 400;
        }

        private void FrmkgpfDetail_Load(object sender, EventArgs e)
        {
            InitTable(paid);
        }
    }
}
