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
        string SQL = "select t.id as ���,b.user_name as ������,e.textname as ��������,t.content as ��������,c.section_name as ����,d.sick_area_name as ���� ,t.oper_time as ����ʱ��,t.ip_address as ���Ե�ַ from t_operate_log t " +
                     "inner join t_userinfo b on t.operator_user_id=b.user_id " +
                     "inner join t_sectioninfo c on c.sid=t.section_id " +
                     "inner join t_sickareainfo d on t.sickarea_id=d.said " +
                     "inner join t_patients_doc e on e.tid=t.tid ";

        public ucOperaterLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʼ������סԺ��Ϣ
        /// </summary>
        private void IniHospitalInfo()
        {
            cboHosptalInfo.Items.Clear();
            string sql="select t.patient_name as ��������,t.in_time as ��Ժʱ��,(select a.happen_time from t_inhospital_action a where a.patient_id=t.id and a.next_id=0 and a.action_type='����' and a.action_state=3) as ��Ժʱ��,t.section_name as ����,t.id as ���� from t_in_patient t where t.pid='"+txtPid.Text+"'";
            DataSet dsHInfo = App.GetDataSet(sql);
            if (dsHInfo != null)
            {
                for (int i = 0; i < dsHInfo.Tables[0].Rows.Count; i++)
                {
                    pinfo temp = new pinfo();
                    int num = i + 1;
                    temp.Inhospitalinfo = num.ToString() + "." + "����:" + dsHInfo.Tables[0].Rows[i]["��������"].ToString() + ",��Ժʱ��:" + dsHInfo.Tables[0].Rows[i]["��Ժʱ��"].ToString() + ",��Ժʱ��:" + dsHInfo.Tables[0].Rows[i]["��Ժʱ��"].ToString() + ",����:" + dsHInfo.Tables[0].Rows[i]["����"].ToString() + ",����:" + dsHInfo.Tables[0].Rows[i]["����"].ToString();
                    temp.Patient_id = dsHInfo.Tables[0].Rows[i]["����"].ToString();
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
        /// ����������ȡ���еĲ�����
        /// </summary>
        /// <param name="patient_id">��������</param>
        private void IniOperters(string patient_id)
        {
            string sql = "select distinct t.operator_id,b.user_name from t_operate_log t "+
"inner join t_account_user d on t.operator_id=d.account_id "+
"inner join t_userinfo b on d.user_id=b.user_id where t.patient_id=" + patient_id + "";
            DataSet dsUser = App.GetDataSet(sql);
            DataRow temprow = dsUser.Tables[0].NewRow();
            temprow["user_name"] = "��ѡ��";
            temprow["operator_id"] = "0";
            dsUser.Tables[0].Rows.Add(temprow);
            cmbOperator.DataSource = dsUser.Tables[0].DefaultView;
            cmbOperator.DisplayMember = "user_name";
            cmbOperator.ValueMember = "operator_id";
            cmbOperator.Text = "��ѡ��";
        }

        private void ucOperaterLog_Load(object sender, EventArgs e)
        {
            cboOpertContent.SelectedIndex = 0;
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql2 = "";
            sql2 = SQL;
            if (cboHosptalInfo.Items.Count <= 0)
            {
                App.MsgWaring("�����벡��סԺ�Ż��סԺ�Ų���ȷ��");
                return;
            }

            pinfo temp = (pinfo)cboHosptalInfo.SelectedItem;
            sql2 = sql2 + " where t.patient_id=" + temp.Patient_id + " ";


            if (cmbOperator.Text != "��ѡ��")
            {
                sql2 = sql2 + " and t.operator_id=" + cmbOperator.SelectedValue.ToString() + " ";               
            }
           
            if (cboOpertContent.Text.Trim() != "��ѡ��")
            {
                sql2 = sql2 + " and t.content like '%" + cboOpertContent.Text + "%' ";
            }


            sql2 = sql2 + " order by t.tid,t.content,t.operator_id,t.oper_time";

            ucGridviewX1.DataBd(sql2, "���", "", "");
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
    /// ������Ϣ
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
