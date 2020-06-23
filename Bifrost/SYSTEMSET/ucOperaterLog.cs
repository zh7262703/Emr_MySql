using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucOperaterLog : UserControl
    {
        string SQL = "select t.id as 序号,b.user_name as 操作人,e.textname as 文书类型,t.content as 操作内容,c.section_name as 科室,d.sick_area_name as 病区 ,t.oper_time as 操作时间,t.ip_address as 电脑地址 from t_operate_log t " +
                     "inner join t_userinfo b on t.operator_user_id=b.user_id " +
                     "inner join t_sectioninfo c on c.sid=t.section_id " +
                     "inner join t_sickareainfo d on t.sickarea_id=d.said " +
                     "inner join t_patients_doc e on e.tid=t.tid ";

        public ucOperaterLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化病人住院信息
        /// </summary>
        private void IniHospitalInfo()
        {
            cboHosptalInfo.Items.Clear();
            string sql="select t.patient_name as 病人姓名,t.in_time as 入院时间,(select a.happen_time from t_inhospital_action a where a.patient_id=t.id and a.next_id=0 and a.action_type='出区' and a.action_state=3) as 出院时间,t.section_name as 科室,t.id as 主键 from t_in_patient t where t.pid='"+txtPid.Text+"'";
            DataSet dsHInfo = App.GetDataSet(sql);
            if (dsHInfo != null)
            {
                for (int i = 0; i < dsHInfo.Tables[0].Rows.Count; i++)
                {
                    pinfo temp = new pinfo();
                    int num = i + 1;
                    temp.Inhospitalinfo = num.ToString() + "." + "姓名:" + dsHInfo.Tables[0].Rows[i]["病人姓名"].ToString() + ",入院时间:" + dsHInfo.Tables[0].Rows[i]["入院时间"].ToString() + ",出院时间:" + dsHInfo.Tables[0].Rows[i]["出院时间"].ToString() + ",科室:" + dsHInfo.Tables[0].Rows[i]["科室"].ToString() + ",主键:" + dsHInfo.Tables[0].Rows[i]["主键"].ToString();
                    temp.Patient_id = dsHInfo.Tables[0].Rows[i]["主键"].ToString();
                    cboHosptalInfo.Items.Add(temp);
                }
                if (cboHosptalInfo.Items.Count > 0)
                {
                    cboHosptalInfo.DisplayMember = "Inhospitalinfo";
                    cboHosptalInfo.ValueMember = "Patient_id";
                    cboHosptalInfo.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 根据主键获取所有的操作人
        /// </summary>
        /// <param name="patient_id">病人主键</param>
        private void IniOperters(string patient_id)
        {
            string sql = "select distinct t.operator_id,b.user_name from t_operate_log t "+
"inner join t_account_user d on t.operator_id=d.account_id "+
"inner join t_userinfo b on d.user_id=b.user_id where t.patient_id=" + patient_id + "";
            DataSet dsUser = App.GetDataSet(sql);
            DataRow temprow = dsUser.Tables[0].NewRow();
            temprow["user_name"] = "请选择";
            temprow["operator_id"] = "0";
            dsUser.Tables[0].Rows.Add(temprow);
            cmbOperator.DataSource = dsUser.Tables[0].DefaultView;
            cmbOperator.DisplayMember = "user_name";
            cmbOperator.ValueMember = "operator_id";
            cmbOperator.Text = "请选择";
        }

        private void ucOperaterLog_Load(object sender, EventArgs e)
        {
            cboOpertContent.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql2 = "";
            sql2 = SQL;
            if (cboHosptalInfo.Items.Count <= 0)
            {
                App.MsgWaring("请输入病人住院号或该住院号不正确！");
                return;
            }

            pinfo temp = (pinfo)cboHosptalInfo.SelectedItem;
            sql2 = sql2 + " where t.patient_id=" + temp.Patient_id + " ";


            if (cmbOperator.Text != "请选择")
            {
                sql2 = sql2 + " and t.operator_id=" + cmbOperator.SelectedValue.ToString() + " ";               
            }
           
            if (cboOpertContent.Text.Trim() != "请选择")
            {
                sql2 = sql2 + " and t.content like '%" + cboOpertContent.Text + "%' ";
            }


            sql2 = sql2 + " order by t.tid,t.content,t.operator_id,t.oper_time";

            ucGridviewX1.DataBd(sql2, "序号", "", "");
            ucGridviewX1.fg.AutoResizeColumns();        
        }

        private void txtPid_TextChanged(object sender, EventArgs e)
        {
            IniHospitalInfo();
        }

        private void cboHosptalInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHosptalInfo.Items.Count > 0)
            {
                pinfo temp = (pinfo)cboHosptalInfo.SelectedItem;
                IniOperters(temp.Patient_id);
            }
            
        }
    }

    /// <summary>
    /// 病人信息
    /// </summary>
    public class pinfo
    {
        private string inhospitalinfo;
        public string Inhospitalinfo
        {
            get { return inhospitalinfo; }
            set { inhospitalinfo = value; }
        }

        private string patient_id;
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }
    }
}
