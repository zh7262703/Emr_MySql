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
    public partial class UcTestNews : UserControl
    {
        public UcTestNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            if (dgvMsgInfoNew.Rows.Count > 0)
            {
                int strCount = 0;
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        strCount = strCount + 1;
                        if (strCount > 1)
                        {
                            App.Msg("�ظ���ťֻ֧�ֵ�������,��֧������������");
                            return;
                        }
                    }
                }
            }
            for (int j = 0; j < dgvMsgInfoNew.Rows.Count; j++)
            {
                if (dgvMsgInfoNew.Rows[j].Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    string msgIds = "";
                    if (dgvMsgInfoNew.Rows[j].Cells["�ظ�"].Value.ToString() == "��")
                    {
                        msgIds = dgvMsgInfoNew.Rows[j].Cells["id"].Value.ToString();
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
                        App.Msg("��ѡ����Ҫ�ظ�����Ϣ���в�����");
                        return;
                    }
                }
            }
            #region ע�͵�
            //if (dgvMsgInfoNew.CurrentCell!=null)
            //{
            //    string msgIds = "";
            //    if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "��")
            //    {
            //        msgIds = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
            //    }
            //    if (msgIds != "")
            //    {
            //        frmMsgReplay frmR = new frmMsgReplay(msgIds);
            //        frmR.ShowDialog();
            //        if (frmR.flag)
            //        {
            //            GetMessage();
            //        }
            //    }
            //    else
            //    {
            //        App.Msg("��ѡ����Ҫ�ظ�����Ϣ��");
            //    } 
            //} 
            #endregion
        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string strId = "";
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() != "��" && dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        strId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
                        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                        sqls.Add(strSql);
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "��" && dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        App.Msg("��ǰѡ�е���Ϣ�к�����Ҫ�ظ�����Ϣ�������²�����");
                        return;
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
                #region ע�͵�
                //if (dgvMsgInfoNew.CurrentCell!=null)
                //{
                //    string msgId = "";
                //    if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() != "��")
                //    {
                //        msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //        if (msgId != "")
                //        {
                //            string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,flag='true' where id ='" + msgId + "'";
                //            int num = App.ExecuteSQL(update);
                //            if (num > 0)
                //            {
                //                App.Msg("ȷ�ϳɹ���");
                //                GetMessage();

                //            }
                //            else
                //            {
                //                App.Msg("ȷ��ʧ�ܣ�");
                //            }
                //        }
                //    }
                //    else
                //    {
                //        App.Msg("ֻ�в���Ҫ�ظ�����Ϣ���д�ȷ�ϲ�����");
                //    } 
                //} 
                #endregion
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
            //����Ϣ
            string sqlMsg = @"select distinct( m.id),
                                   m.isreply �ظ�,
                                   p.patient_name ��������,
                                   p.in_doctor_name �ܴ�ҽ��,
                                   case p.gender_code
                                     when '0' then
                                      '��'
                                     else
                                      'Ů'
                                   end �Ա�,
                                   p.age || p.age_unit ����,
                                   p.his_id,
                                   p.in_bed_no ����,
                                   p.section_name ��ǰ����,
                                   m.type_name ��Ϣ����,
                                   m.content ��Ϣ����,
                                   m.operator_user_name ������,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi') ����ʱ��
                              from T_MSG_INFO m, t_in_patient p, t_msg_setting t
                             where m.pid = p.id
                               and t.WARN_TYPE = m.WARN_TYPE
                               and m.WARN_TYPE in (1,2)
                               and t.MSG_START_UP = '1'
                               and flag = 'true'
                               and msg_status = '0'
                               and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            //��ѯһ���ڵ��Ѷ���Ϣ
            string sqlHistoryMsg = "select distinct( m.id), m.patient_name ��������,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,type_name ��Ϣ����,content ��Ϣ����,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') ����ʱ��,operator_user_name ������,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') ȷ��ʱ��,reply_msg �ظ����� " +
                                    "from t_msg_info m , t_in_patient p ,t_msg_setting t " +
                                    "where  m.pid=p.id and t.WARN_TYPE = m.WARN_TYPE and t.MSG_START_UP='1' and  m.WARN_TYPE in (1,2) " +
                                    "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id=" + App.UserAccount.UserInfo.User_id + " and dispose_time>(sysdate-7) order by ����ʱ�� desc";
            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlHistoryMsg;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //����Ϣ
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                DataGridViewCheckBoxColumn cBox_zd = new DataGridViewCheckBoxColumn();
                cBox_zd.HeaderText = "ѡ��";
                cBox_zd.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_zd);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "�µ���Ϣ" + "(" + n_newMsg + ")";
                }
                dgvMsgInfoNew.Columns["id"].Visible = false;

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "�ظ�";
                cBox.Name = "replay";
                dgvMsgInfoNew.Columns.Insert(0, cBox);
                dgvMsgInfoNew.Columns["replay"].ReadOnly = true;
                dgvMsgInfoNew.Columns["replay"].Visible = false;


                //��ʷ��Ϣ
                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];
                dgvHistoryMsgNew.Columns["id"].Visible = false;
                //Ĭ�ϻظ��ֶ��Ƿ�ѡ��
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "1")
                    {

                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "��";
                    }
                    else
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "��";
                    }
                }

                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ظ�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvMsgInfoNew.Columns["��Ϣ����"].Width = 250;
                dgvMsgInfoNew.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvHistoryMsgNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["��Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["ȷ��ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ �Ѷ��������������
                dgvHistoryMsgNew.Columns["��Ϣ����"].Width = 200;
                dgvHistoryMsgNew.Columns[8].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.Columns["�ظ�����"].Width = 200;
                dgvHistoryMsgNew.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();
            }

        }

        private void UcTestNews_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
                tabItem2_Click(null,null);
            }
            catch
            {
            }
        }

        private void UcTestNews_SizeChanged(object sender, EventArgs e)
        {
            int x = btnReply.Parent.Size.Width / 2 - btnReply.Size.Width;
            btnReply.Location = new Point(x, btnReply.Location.Y);
            btnRefurbish.Location = new Point(btnReply.Location.X + 100, btnRefurbish.Location.Y);
            btnMakeSure.Location = new Point(btnReply.Location.X - 100, btnMakeSure.Location.Y);
        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

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

        private void tabItem2_Click(object sender, EventArgs e)
        {
            dgvMsgInfoNew.AutoResizeRows();
            dgvMsgInfoNew.Refresh();
            dgvHistoryMsgNew.AutoResizeRows();
            dgvHistoryMsgNew.Refresh();
        }
    }
}
