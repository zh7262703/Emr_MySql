using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class ucWjzZk : UserControl
    {
        public string idWhere;
        public string Name = null;
        string tempSQL = "";

        public delegate void AddNewDoc(string tid);
        public event AddNewDoc add;

        public ucWjzZk()
        {
            InitializeComponent();
        }

        public ucWjzZk(InPatientInfo info)
        {
            InitializeComponent();
            idWhere = info.Id.ToString();
        }

        /// <summary>
        /// 科室id
        /// </summary>
        /// <param name="sid"></param>
        public ucWjzZk(string sick_doctor_id)
        {
            InitializeComponent();
            idWhere = @"select id from t_in_patient t where t.die_time is null and t.sick_doctor_id=" + sick_doctor_id;
        }

        private void ucWjzZk_Load(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void GetInfo()
        {
            string strRoleType = App.UserAccount.CurrentSelectRole.Role_type;
            if (strRoleType == "N")
            {
                tempSQL = @"select tip.id,tip.patient_name,tqr.doctype,substr(tqr.note,20) nr, tqr.noteztime,tqr.pv 
                            from t_quality_record tqr inner join t_in_patient tip
                            on tqr.patient_id=tip.id   where tip.id in(" + idWhere + ")";
            }
            else if (strRoleType == "D")
            {
                tempSQL = @"select tip.id,tip.patient_name,tqr.doctype,substr(tqr.note,20) nr, tqr.noteztime,tqr.pv 
                            from t_quality_record tqr inner join t_in_patient tip
                            on tqr.patient_id=tip.id   where tip.id in(" + idWhere + ")";
            }

            tempSQL = tempSQL + " order by substr(tqr.note,0,20) desc";
            DataSet ds = App.GetDataSet(tempSQL);

            if (ds != null)
            {
                DateTime dtNow = App.GetSystemTime();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvZK.Rows.Add();
                    dgvZK.Rows[i].Cells["pname"].Value = ds.Tables[0].Rows[i]["patient_name"].ToString();
                    dgvZK.Rows[i].Cells["wslx"].Value = ds.Tables[0].Rows[i]["doctype"].ToString();
                    dgvZK.Rows[i].Cells["tsnr"].Value = ds.Tables[0].Rows[i]["nr"].ToString();
                    dgvZK.Rows[i].Cells["ywcsj"].Value = ds.Tables[0].Rows[i]["noteztime"].ToString();
                    dgvZK.Rows[i].Cells["cssj"].Value = DateDiff(dtNow, DateTime.Parse(ds.Tables[0].Rows[i]["noteztime"].ToString()));
                    if (ds.Tables[0].Rows[i]["pv"].ToString() == "1")
                    {
                        dgvZK.Rows[i].Cells["tx"].Value = imageList1.Images[0];
                    }
                    else
                    {
                        dgvZK.Rows[i].Cells["tx"].Value = imageList1.Images[1];
                    }
                }
            }

            //测试
            //if (dgvZK.Rows.Count < 1)
            //{
            //    dgvZK.Rows.Add();
            //    dgvZK.Rows[0].Cells["wslx"].Value = "首次病程记录";
            //    dgvZK.Rows[0].Cells["tsnr"].Value = "首次病程记录入院后8小时未完成";
            //    dgvZK.Rows[0].Cells["ywcsj"].Value = "2016-01-10 16:00";
            //    dgvZK.Rows[0].Cells["cssj"].Value = "+1天2h";

            //    dgvZK.Rows[0].Cells["tx"].Value = imageList1.Images[1];

            //    dgvZK.Rows.Add();
            //    dgvZK.Rows[1].Cells["wslx"].Value = "入院记录";
            //    dgvZK.Rows[1].Cells["tsnr"].Value = "入院记录入院后24小时完成";
            //    dgvZK.Rows[1].Cells["ywcsj"].Value = "2016-01-11 16:00";
            //    dgvZK.Rows[1].Cells["cssj"].Value = "-8h";

            //    dgvZK.Rows[1].Cells["tx"].Value = imageList1.Images[0];


            //    dgvZK.Rows.Add();
            //    dgvZK.Rows[2].Cells["wslx"].Value = "主任查房记录";
            //    dgvZK.Rows[2].Cells["tsnr"].Value = "主任查房记录每7天一次";
            //    dgvZK.Rows[2].Cells["ywcsj"].Value = "2016-01-15 16:00";
            //    dgvZK.Rows[2].Cells["cssj"].Value = "-1天";

            //    dgvZK.Rows[2].Cells["tx"].Value = imageList1.Images[0];



            //}
        }

        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts = DateTime1.Subtract(DateTime2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时";
            if (DateTime1 > DateTime2)
            {
                dateDiff = "+" + dateDiff;
            }
            else
            {
                dateDiff = "-" + dateDiff;
            }

            return dateDiff;
        }

        private void dgvZK_DoubleClick(object sender, EventArgs e)
        {
            int index = dgvZK.CurrentRow.Index;
            //add("126");

        }


    }
}
