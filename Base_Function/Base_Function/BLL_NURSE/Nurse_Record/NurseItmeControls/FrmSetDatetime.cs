using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class FrmSetDatetime : DevComponents.DotNetBar.Office2007Form
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string Patientid = "0";
        private string Type="";//护理记录的类型:类型 空（或者 D） 成人    C 儿童  O 产科  B新生儿
        public bool flag = false;
        public FrmSetDatetime()
        {
            InitializeComponent();
        }

        public FrmSetDatetime(DateTime dateTime,string patientid)
        {
            InitializeComponent();
            dtpDate.Value = dateTime;
            Patientid = patientid;
        }
        public FrmSetDatetime(DateTime dateTime, string patientid,string type)
        {
            InitializeComponent();
            dtpDate.Value = dateTime;
            Patientid = patientid;
            Type = type;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }

        private void FrmModifyTitle_Load(object sender, EventArgs e)
        {
            dtpDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            date = dtpDate.Value;

            if (App.GetSystemTime().Year - dtpDate.Value.Year >1)
            {
                App.MsgWaring("年份跨度太大，请确定年份填写正确！");
                return;
            }
            try
            {
                int count =0;
                if (Type != "")
                {
                    if (Type=="D")
                        count = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + Patientid + "", 0, "count(*)"));
                    else
                        count = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + Type + "' and patient_id=" + Patientid + "", 0, "count(*)"));
                }
                else
                {
                    count = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + Patientid + "", 0, "count(*)"));
                }
                if (count > 0)
                {
                    flag = false;
                    App.Msg("您选择的时间已存在！");
                }
                else
                {
                    flag = true;
                    this.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dtpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}