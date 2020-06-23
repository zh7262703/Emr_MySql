using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Bifrost.WebReference;

namespace Base_Function.BLL_DOCTOR.HisInStance.危急值查看
{
    public partial class FrmVJZ : DevComponents.DotNetBar.Office2007Form
    {
        string accountId = "";
        DataSet dsVJZ;
        bool flag = true;
        public FrmVJZ()
        {
            InitializeComponent();
        }

        public FrmVJZ(string accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }

        public FrmVJZ(DataSet dsVJZ, bool flag)
        {
            InitializeComponent();
            this.dsVJZ = dsVJZ;
            this.flag = flag;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVJZ_Load(object sender, EventArgs e)
        {
            try
            {
                DataBand();
                btnBL.Visible = flag;
                btnLis.Visible = flag;
                btnPacs.Visible = flag;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBand()
        {
            //if (accountId != "")
            //{

            //DataSet dsVJZ = App.GetDataSet("select pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(age,age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,vjz 危急值 from t_pasc_data a inner join t_in_patient b on a.zyh=b.pid  where vjz is not null and b.leave_time is null and sick_doctor_id= " + accountId);
            if (dsVJZ != null)
            {
                //PACS
                dgvPacsVJZ.DataSource = dsVJZ.Tables["pacs"];
                dgvPacsVJZ.Columns["id"].Visible = false;
                //病理
                dgvBLVJZ.DataSource = dsVJZ.Tables["bl"];
                dgvBLVJZ.Columns["medicalno"].Visible = false;
                //LIS
                dgvLisVJZ.DataSource = dsVJZ.Tables["lis"];
                dgvLisVJZ.Columns["report_item_id"].Visible = false;
                dgvLisVJZ.Columns["危急值"].DefaultCellStyle.ForeColor = Color.Red;
            }

            //病理
            //DataSet dsBL = App.GetDataSet("select a.medicalno, pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(age,age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,a.SFYX 是否阳性 from ESB_VIEW_BLZD@esb a inner join t_in_patient b on a.zyh=b.pid  where a.sfyx is not null and b.leave_time is null and a.medicalno not in(select id from VJZ_MESSAGE) and sick_doctor_id= " + accountId);
            //if (dsBL != null)
            //{
            //    dgvBLVJZ.DataSource = dsBL.Tables[0];
            //    dgvBLVJZ.Columns["medicalno"].Visible = false;
            //}

            //LIS
            //DataSet dsLIS = App.GetDataSet("select report_item_id,pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(b.age,b.age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,a.alarm_flag 危急值 from esb_view_test_report@esb a inner join t_in_patient b on a.inp_no=b.pid  where a.alarm_flag is not null and b.leave_time is null and report_item_id not in(select id from VJZ_MESSAGE) and sick_doctor_id= " + accountId);
            //if (dsLIS != null)
            //{
            //    dgvLisVJZ.DataSource = dsLIS.Tables[0];
            //    dgvLisVJZ.Columns["report_item_id"].Visible = false;

            //}
            //}
        }
        //刷新当前数据集
        private void RefreshData()
        {
            //PACS危急值提醒
            string pacsSql = "select a.id,pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(age,age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,vjz 危急值 from t_pasc_data a inner join t_in_patient b on a.zyh=b.pid  where vjz is not null and b.leave_time is null and a.id not in(select id from VJZ_MESSAGE) and sick_doctor_id= " + App.UserAccount.Account_id;
            //LIS危急值提醒
            string lisSql = "select report_item_id,pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(b.age,b.age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,a.alarm_flag 危急值 from esb_view_test_report@esb a inner join t_in_patient b on a.inp_no=b.pid  where a.alarm_flag is not null and b.leave_time is null and report_item_id not in(select id from VJZ_MESSAGE) and sick_doctor_id= " + App.UserAccount.Account_id;
            //病理
            string blSql = "select a.medicalno, pid 住院号,patient_name 患者姓名,(case when gender_code=0 then '男' else '女' end) 性别,concat(age,age_unit) 年龄,sick_bed_no 床位,section_name 当前科室,a.SFYX 是否阳性 from ESB_VIEW_BLZD@esb a inner join t_in_patient b on a.zyh=b.pid  where a.sfyx is not null and b.leave_time is null and a.medicalno not in(select id from VJZ_MESSAGE) and sick_doctor_id= " + App.UserAccount.Account_id;

            Class_Table[] tabs = new Class_Table[3];
            tabs[0] = new Class_Table();
            tabs[0].Sql = pacsSql;
            tabs[0].Tablename = "pacs";

            tabs[1] = new Class_Table();
            tabs[1].Sql = lisSql;
            tabs[1].Tablename = "lis";

            tabs[2] = new Class_Table();
            tabs[2].Sql = blSql;
            tabs[2].Tablename = "bl";

            dsVJZ = App.GetDataSet(tabs);
        }

        private void btnLis_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList sqlList = new ArrayList();
                for (int i = 0; i < dgvLisVJZ.Rows.Count; i++)
                {
                    sqlList.Add("insert into vjz_message(id, time)values('" + dgvLisVJZ.Rows[i].Cells["report_item_id"].Value.ToString() + "', sysdate)");
                }

                if (sqlList.Count > 0)
                {
                    string[] sqlArr = new string[sqlList.Count];
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        sqlArr[i] = sqlList[i].ToString();
                    }
                    int num = App.ExecuteBatch(sqlArr);
                    if (num > 0)
                    {
                        RefreshData();
                        DataBand();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPacs_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList sqlList = new ArrayList();
                for (int i = 0; i < dgvPacsVJZ.Rows.Count; i++)
                {
                    sqlList.Add("insert into vjz_message(id, time)values('" + dgvPacsVJZ.Rows[i].Cells["id"].Value.ToString() + "', sysdate)");
                }

                if (sqlList.Count > 0)
                {
                    string[] sqlArr = new string[sqlList.Count];
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        sqlArr[i] = sqlList[i].ToString();
                    }
                    int num = App.ExecuteBatch(sqlArr);
                    if (num > 0)
                    {
                        RefreshData();
                        DataBand();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBL_Click(object sender, EventArgs e)
        {

        }
    }
}
