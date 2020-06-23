using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost.WebReference;
using DevComponents.AdvTree;
using System.Collections;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class UcDoctorIdeaNews : UserControl
    {
        public UcDoctorIdeaNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            string msgIds = "";
            DataGridViewCheckBoxCell cell = dgvMsgInfoNew.CurrentRow.Cells["replay"] as DataGridViewCheckBoxCell;
            if (cell != null && cell.EditedFormattedValue.ToString() == "True")
            {
                msgIds = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
            }
            if (msgIds != "")
            {
                frmMsgReplay frmR = new frmMsgReplay(msgIds);
                frmR.ShowDialog();
                if (frmR.flag)
                {
                    GetMessage();
                }
            }
            else
            {
                App.Msg("��ѡ����Ҫ�ظ�����Ϣ��");
            }
        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// ��ȡδ��������������Ϣ
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvHistoryMsgNew.Columns.Clear();
            string sqlMsg = "select distinct(m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name pacs��鱨������,m.TYPE_Name_CY ��鱨����������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��鱨��' and  t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='16' and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            string sqlMsgReaded = "select distinct(m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name pacs��鱨������,m.TYPE_Name_CY ��鱨����������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��鱨��' and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='16' and  m.msg_status=1 " +
               " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlMsgReaded;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //����Ϣ

                DataGridViewCheckBoxColumn cBox_yz = new DataGridViewCheckBoxColumn();
                cBox_yz.HeaderText = "ѡ��";
                cBox_yz.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_yz);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];
                dgvMsgInfoNew.Columns["id"].Visible = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "ҽ������δ����Ϣ" + "(" + n_newMsg + ")";
                }

                //��ʷ��Ϣ
                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];
                dgvHistoryMsgNew.Columns["id"].Visible = false;
            }

        }

        private void UcDoctorIdeaNews_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
                dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //GetMessage();  
                //MessageBox.Show("����ҽ�����ѹ���������Ҫ���ƣ���ʱ��������");
            }
            catch
            {
            }
        }
        private void UcDoctorIdeaNews_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
    }
}
