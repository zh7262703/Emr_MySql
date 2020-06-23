using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class frmConsultation_Remind : Form
    {
        public frmConsultation_Remind()
        {
            InitializeComponent();
            flgGrid.DataSource = ShowGrid();
            flgGrid.Cols["pid"].Visible = false;
            flgGrid.Cols["consultation_content"].Visible = false;
        }
        public DataTable ShowGrid()
        {
            /*
             *查出当前科室的所有会诊记录 
             */
            string Sql_select = "select b.id 序号,a.apply_sectionname 申请科室,a.apply_name 申请医生,"+
                               " to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请时间,"+
                               " case a.apply_type when 0 then '普通会诊' else '急会诊' end 会诊类别,"+
                               " case b.state when '0' then '未会诊' else '已会诊' end 会诊状态,a.pid,a.consultation_content" + 
                               " from t_consultaion_apply a "+
                               " inner join t_consultaion_record b on a.id = b.apply_id"+
                               " where b.consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.submited='Y'";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_select);
            if(ds!=null)
            {
                dt = ds.Tables[0];

            }
            return dt;
       }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 查看，写会诊记录
        /// </summary>
        private void flgGrid_DoubleClick(object sender, EventArgs e)
        {
            if(flgGrid.RowSel>0)
            {
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(flgGrid[flgGrid.RowSel,"pid"].ToString());
                string Apply_Time = flgGrid[flgGrid.RowSel,"申请时间"].ToString();
                string Apply_SectionName = flgGrid[flgGrid.RowSel,"申请科室"].ToString();
                string Consul_Type = flgGrid[flgGrid.RowSel,"会诊类别"].ToString();
                string Recoed_Id = flgGrid[flgGrid.RowSel,"序号"].ToString();
                string Apply_Content = flgGrid[flgGrid.RowSel, "consultation_content"].ToString();
                //frmConsultation_Record frmRecord = new frmConsultation_Record(inPatient, Apply_Time,Apply_SectionName,Consul_Type,Recoed_Id,Apply_Content);
                ////App.FormStytleSet(frmRecord);

                //frmRecord.ShowDialog();
            }
        }
    }
}