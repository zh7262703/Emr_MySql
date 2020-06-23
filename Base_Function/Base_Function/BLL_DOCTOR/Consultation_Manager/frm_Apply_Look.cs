using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class frm_Apply_Look : DevComponents.DotNetBar.Office2007Form
    {
        public frm_Apply_Look()
        {
            InitializeComponent();
        }
        private  string id;
        private string pid;
        public frm_Apply_Look(string Id, string Pid)
        {
            this.id = Id;
            this.pid = Pid;
            InitializeComponent();
        }

        private void frm_Apply_Look_Load(object sender, EventArgs e)
        {
            string Sql_Grid = "select to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 会诊申请日期," +
                         " a.apply_sectionname 申请科室,a.apply_name 会诊申请人,a.pid 病人住院号,c.patient_name 患者姓名,a.pid 住院号, c.sick_bed_no 床号," +
                         " case a.consultation_type when 0 then '普通会诊' else '急会诊' end 会诊类别," +
                         " case a.apply_type when 0 then '本院' else '外院' end 申请类别," +
                         " case a.consultation_end when 0 then '未会诊' else '已会诊' end 会诊状态," +
                         " case a.submited when 'N' then '未提交' else '已提交' end 提交状态," +
                         " case a.islock when 0 then '未锁定' else '锁定' end 是否锁定," +
                         " b.consul_section_name 会诊科室,b.consul_r_name 会诊医生," +
                         " to_char(b.consul_time,'yyyy-MM-dd hh24:mi') 会诊日期,a.consultation_content," +
                         " case isrecieve when 0 then '否' else '是' end 是否接诊," +
                         " a.save_name 书写者,a.save_id," +
                         " b.consul_record_section_id,b.consul_r_id,a.apply_sectionid,a.apply_userid,a.id,a.submited,a.patient_id" +
                         " from t_consultaion_apply a " +
                         " inner join t_in_patient c on a.patient_id=c.id  inner join t_consultaion_record b" +
                         " on a.id = b.apply_id where a.is_dalete!='Y' and a.patient_id ='" + pid + "' and a.id='"+id+"' order by a.id";
            DataSet ds = App.GetDataSet(Sql_Grid);
            if(ds!=null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["会诊申请日期"].ToString() != "")
                {
                    dtpapply.Text = dt.Rows[0]["会诊申请日期"].ToString();
                }
                if (dt.Rows[0]["会诊申请人"].ToString()!="")
                {
                    txtapply.Text = dt.Rows[0]["会诊申请人"].ToString();
                }
                if (dt.Rows[0]["患者姓名"].ToString() != "")
                {
                    txtname.Text = dt.Rows[0]["患者姓名"].ToString();
                }
                if (dt.Rows[0]["住院号"].ToString() != "")
                {
                    txthono.Text = dt.Rows[0]["住院号"].ToString();
                }
                if (dt.Rows[0]["床号"].ToString() != "")
                {
                    txtbedno.Text = dt.Rows[0]["床号"].ToString();
                }
                if (dt.Rows[0]["会诊类别"].ToString() == "普通会诊")
                {
                    txtconsul.Text = "普通会诊";
                }
                if (dt.Rows[0]["会诊类别"].ToString() == "急会诊")
                {
                    txtconsul.Text = "紧急会诊";
                }
                if (dt.Rows[0]["会诊科室"].ToString() !="")
                {
                    txtsection.Text = dt.Rows[0]["会诊科室"].ToString();
                }
                if (dt.Rows[0]["会诊医生"].ToString() != "")
                {
                    txtdoctor.Text = dt.Rows[0]["会诊医生"].ToString();
                }

                if (dt.Rows[0]["会诊状态"].ToString() == "未会诊")
                {
                    txtconsultation.Text = "未会诊";
                }
                if (dt.Rows[0]["会诊状态"].ToString() == "已会诊")
                {
                    txtconsultation.Text = "已会诊";
                }
                if (dt.Rows[0]["提交状态"].ToString() == "未提交")
                {
                    txtsubmited.Text = "未提交";
                }
                if (dt.Rows[0]["提交状态"].ToString() == "已提交")
                {
                    txtsubmited.Text = "已提交";
                }

                if (dt.Rows[0]["会诊日期"].ToString() != "")
                {
                    dtpanser.Text = dt.Rows[0]["会诊日期"].ToString();
                }
                if (dt.Rows[0]["consultation_content"].ToString() != "")
                {
                    txtCon.Text = dt.Rows[0]["consultation_content"].ToString();
                }
            }
            SetContion();
        }
        /// <summary>
        /// 设置不可用状态
        /// </summary>
        private void SetContion()
        {
            dtpapply.Enabled = false;
            dtpanser.Enabled = false;
            txtapply.Enabled = false;
            txtbedno.Enabled = false;
            txtCon.ReadOnly = true;
            txtconsul.Enabled = false;
            txtconsultation.Enabled = false;
            txtdoctor.Enabled = false;
            txthono.Enabled = false;
            txtisrecieve.Enabled = false;
            txtname.Enabled = false;
            txtsection.Enabled = false;
            txtsubmited.Enabled = false;
        }
    }
}