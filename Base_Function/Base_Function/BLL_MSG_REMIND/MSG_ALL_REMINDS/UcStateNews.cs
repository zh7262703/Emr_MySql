using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevComponents.AdvTree;
using System.Collections;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class UcStateNews : UserControl
    {
        public UcStateNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// ��ȡ״̬������Ϣ
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoState.Columns.Clear();
            dgvMsgInfoStateReaded.Columns.Clear();

            //״̬��������
            string sqlMsg = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ״̬��������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='״̬����' and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='10' and  m.msg_status=0 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            string sqlMsgReaded = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ״̬��������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='״̬����' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='10' and  m.msg_status=1 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "newMsgReaded";
            tab[1].Sql = sqlMsgReaded;
            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //״̬��������

                DataGridViewCheckBoxColumn cBox_zt = new DataGridViewCheckBoxColumn();
                cBox_zt.HeaderText = "ѡ��";
                cBox_zt.Name = "select";
                dgvMsgInfoState.Columns.Insert(0, cBox_zt);
                dgvMsgInfoState.Columns["select"].ReadOnly = false;

                dgvMsgInfoState.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "״̬����δ����Ϣ" + "(" + n_newMsg + ")";
                }

                dgvMsgInfoState.Columns["id"].Visible = false;
                dgvMsgInfoState.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoStateReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoStateReaded.Columns["id"].Visible = false;
                dgvMsgInfoStateReaded.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoState.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["״̬��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvMsgInfoState.Columns["��������"].Width = 250;
                dgvMsgInfoState.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoState.AutoResizeRows();
                dgvMsgInfoState.Refresh();

                dgvMsgInfoStateReaded.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["״̬��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ �Ѷ��������������
                dgvMsgInfoStateReaded.Columns["��������"].Width = 250;
                dgvMsgInfoStateReaded.Columns[10].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoStateReaded.AutoResizeRows();
                dgvMsgInfoStateReaded.Refresh();
            }

        }

        private void UcStateNews_Load(object sender, EventArgs e)
        {
            try
            {
                //�趨����Header�����е�Ԫ����п��Զ����� 
                //dgvMsgInfoState.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoStateReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcStateNews_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQR_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            string strId = "";
            for (int i = 0; i < dgvMsgInfoState.Rows.Count; i++)
            {
                if (dgvMsgInfoState.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    strId = dgvMsgInfoState.Rows[i].Cells["id"].Value.ToString();
                    string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                    sqls.Add(strSql);
                }
            }
            if (sqls.Count > 0)
            {
                int n = App.ExecuteBatch(sqls.ToArray());
                if (n > 0)
                {
                    App.Msg("ȷ�ϳɹ���");
                    GetMessage();
                }
                else
                {
                    App.Msg("ȷ��ʧ�ܣ�");
                }
            }

        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {

            try
            {
                dgvMsgInfoState.AutoResizeRows();
                dgvMsgInfoState.Refresh();
                dgvMsgInfoStateReaded.AutoResizeRows();
                dgvMsgInfoStateReaded.Refresh();
                if (tabControl1.SelectedTab == tabItem7)
                {
                    this.buttonX1.Visible = false;
                    this.btnRefurbish.Visible = false;

                }
                else
                {
                    this.buttonX1.Visible = true;
                    this.btnRefurbish.Visible = true;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefurbish_Click(object sender, EventArgs e)
        {
            try
            {
                GetMessage();
            }
            catch
            {
            }
        }
    }
}
