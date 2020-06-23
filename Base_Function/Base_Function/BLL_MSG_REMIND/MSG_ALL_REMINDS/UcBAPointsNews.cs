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
    public partial class UcBAPointsNews : UserControl
    {
        public UcBAPointsNews()
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
        /// ��ȡ��������������Ϣ
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();
            //����������������
            string sqlMsg = "select distinct( m.id),p.patient_name ��������,p.pid סԺ��,m.pid,m.add_time,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��������' and  t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='17' and  m.msg_status=0 "+
                " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            
            string sqlMsgReaded = "select distinct( m.id),p.patient_name ��������,p.pid סԺ��,m.pid,m.add_time,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��������' and t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='17' and  m.msg_status=1 and  to_char(sysdate,'dd')-to_char(m.add_time,'dd')< 15 "+
               " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            
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
                //����������������
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "ѡ��";
                cBox.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "��������δ����Ϣ" + "(" + n_newMsg + ")";
                }


                dgvMsgInfoNew.Columns["id"].Visible = false;
                dgvMsgInfoNew.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNew.Columns["סԺ��"].Visible = false;
                dgvMsgInfoNew.Columns["pid"].Visible = false;
                dgvMsgInfoNew.Columns["add_time"].Visible = false;

                dgvMsgInfoNewReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["סԺ��"].Visible = false;
                dgvMsgInfoNewReaded.Columns["pid"].Visible = false;
                dgvMsgInfoNewReaded.Columns["add_time"].Visible = false;


                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvMsgInfoNew.Columns["�۷�����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvMsgInfoNew.Columns["��������"].Width = 250;
                dgvMsgInfoNew.Columns[13].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvMsgInfoNewReaded.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
              
                dgvMsgInfoNewReaded.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               // dgvMsgInfoNewReaded.Columns["�۷�����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ �Ѷ��������������
                dgvMsgInfoNewReaded.Columns["��������"].Width = 250;
                dgvMsgInfoNewReaded.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();
            }

        }

        private void UcBAPointsNews_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoNewReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                getKouFennDetails();
                GetMessage();
                
            }
            catch
            {
            }
        }
        /// <summary>
        /// �鿴�۷�������Ϣ
        /// </summary>
        private void getKouFennDetails()
        {
            try
            {
                DataGridViewButtonColumn cBox1 = new DataGridViewButtonColumn();
                cBox1.HeaderText = "�۷�����";
                cBox1.Name = "KouFennDetails";
                //cBox.Text = "�鿴";
                cBox1.DefaultCellStyle.NullValue = "�鿴";
                dgvMsgInfoNew.Columns.Add(cBox1);

                DataGridViewButtonColumn cBox2 = new DataGridViewButtonColumn();
                cBox2.HeaderText = "�۷�����";
                cBox2.Name = "KouFennDetails";
                //cBox.Text = "�鿴";
                cBox2.DefaultCellStyle.NullValue = "�鿴";
                dgvMsgInfoNewReaded.Columns.Add(cBox2);
            }
            catch 
            {

            }
        }

        private void UcBAPointsNews_SizeChanged(object sender, EventArgs e)
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
            for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
            {
                if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    strId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
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
                    getKouFennDetails();
                }
                else
                {
                    App.Msg("ȷ��ʧ�ܣ�");
                }
            }
            #region ע�͵�
            //if (dgvMsgInfoNew.CurrentCell!=null)
            //{
            //    string strId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
            //    if (strId != "")
            //    {
            //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
            //        int num = App.ExecuteSQL(strSql);
            //        if (num > 0)
            //        {
            //            App.Msg("ȷ�ϳɹ���");
            //            GetMessage();
            //            getKouFennDetails();
            //        }
            //        else
            //        {
            //            App.Msg("ȷ��ʧ�ܣ�");
            //        }
            //    } 
            //} 
            #endregion
        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();
                if (tabControl1.SelectedTab == tabItem7)
                {
                    this.btnQR.Visible = false;
                    this.btnRefurbish.Visible = false;

                }
                else
                {
                    this.btnQR.Visible = true;
                    this.btnRefurbish.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void btnRefurbish_Click(object sender, EventArgs e)
        {
            try
            {
                GetMessage();
                getKouFennDetails();
            }
            catch 
            {
             
            }
        }
        
        private void dgvMsgInfoNew_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// �鿴�۷���ϸ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMsgInfoNew.Columns[e.ColumnIndex].HeaderText == "�۷�����")
                {
                    // string strZYH = dgvMsgInfoNew.CurrentRow.Cells["סԺ��"].Value.ToString();//סԺ��
                    string strID = dgvMsgInfoNew.CurrentRow.Cells["pid"].Value.ToString();//����id

                    //string strADD_TIME = dgvMsgInfoNew.CurrentRow.Cells["add_time"].Value.ToString();//���ʱ��
                    if (strID != "")
                    {
                        string strZYH = App.ReadSqlVal("select pid from t_in_patient where id='" + strID + "'", 0, "pid");//ͨ������id�������ӦסԺ��
                        if (strZYH != "")
                        {
                            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck frm = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck(strZYH);
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void dgvMsgInfoNewReaded_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMsgInfoNewReaded.Columns[e.ColumnIndex].HeaderText == "�۷�����")
                {
                   // string strZYH = dgvMsgInfoNew.CurrentRow.Cells["סԺ��"].Value.ToString();//סԺ��
                    string strID = dgvMsgInfoNewReaded.CurrentRow.Cells["pid"].Value.ToString();//����id

                    //string strADD_TIME = dgvMsgInfoNew.CurrentRow.Cells["add_time"].Value.ToString();//���ʱ��
                    if (strID != "")
                    {
                        string strZYH = App.ReadSqlVal("select pid from t_in_patient where id='" + strID + "'", 0, "pid");//ͨ������id�������ӦסԺ��
                        if (strZYH != "")
                        {
                            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck frm= new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck(strZYH);
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch
            {
                
            }
        }
    }
}
