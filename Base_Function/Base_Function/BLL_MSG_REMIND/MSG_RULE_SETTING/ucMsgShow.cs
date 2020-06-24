using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;

//using Microsoft.Office.Core;

namespace Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING
{
    /// <summary>
    /// ������:Ԭ��    130705
    /// </summary>
    public partial class ucMsgShow : UserControl
    {
        /// <summary>
        /// ��ȡ��ǰ������������
        /// </summary>
        string strWarnSubstance;
        public ucMsgShow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvMsgInfoNew.Columns.Clear();//��ձ����ʾ����
                strWarnSubstance = cbWarnSubstance.Text.ToString();//��������
                string strOperatorName = this.txtName.Text.ToString();//������
                string strPatientID = this.txtPatientID.Text.ToString();//����id
                string strMsgStatus = this.txtMsgStatus.Text.ToString();//�ظ�״̬
                string strBeginTime = this.dtpBegin.Value.AddDays(-1).ToShortDateString();//������ʼʱ��
                string strEndTime = this.dtpEnd.Value.AddDays(+1).ToShortDateString();//��������ʱ��
                if (Convert.ToDateTime(strEndTime) < Convert.ToDateTime(strBeginTime))
                {
                    App.Msg("����Ľ���ʱ�������ڿ�ʼʱ�䣡");
                    return;
                }
                if (strBeginTime == "" || strEndTime == "")
                {
                    App.Msg("����Ҫ���뿪ʼ�ͽ���ʱ�䣡");
                    return;
                }

                string strSql_One = @"select to_char(t.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,
                                       t.type_name 	����Ϣ����,
                                       t.type_name_cy ����Ϣ����,
                                       t.patient_name ��������,
                                       m.his_id his_id,
                                       m.sick_bed_no ����,
                                       t.warn_type,
                                       m.sick_doctor_name �ܴ�ҽ��,
                                       t.content ��Ϣ����,
                                       t.operator_user_sender ���ͷ�,
                                       t.operator_user_name ������,
                                       t.reply_flag �ظ���� ,
                                       t.msg_status �Ķ�״̬,
                                       t.Receive_User_Name ������,
                                       s.msg_section_name ���տ��� 
                                  from t_msg_info t, t_in_patient m,t_msg_setting  s
                                 where t.pid = m.id and t.warn_type=s.warn_type";
                if (strWarnSubstance == "�ʿ�����")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE in (3,4) ";
                }
                if (strWarnSubstance == "��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE in (5,6,7) ";
                }
                if (strWarnSubstance == "Pacs�������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE in (8,9) ";
                }
                if (strWarnSubstance == "״̬����")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE =10 ";
                }
                if (strWarnSubstance == "��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE in (11,12,13,14,15)";
                }
                if (strWarnSubstance == "ҽ������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE =16";
                }
                if (strWarnSubstance == "��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE = 18 ";
                }
                if (strWarnSubstance == "��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE in (1,2)";
                }
                if (strWarnSubstance == "��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE =17 ";
                }
                if (strWarnSubstance == "��Ϣ��������")//�ж����ĸ��������
                {
                    strSql_One += " and t.WARN_TYPE =19 ";
                }
                if (strOperatorName != "")
                {
                    strSql_One += " and t.OPERATOR_USER_NAME='" + strOperatorName + "'";
                }
                if (strPatientID != "")
                {
                    strSql_One += " and m.his_id like '%" + strPatientID + "%'";
                }
                if (strMsgStatus != "")
                {
                    strSql_One += " and t.reply_flag='" + strMsgStatus + "'";
                }
                if (strBeginTime != "" && strEndTime != "")
                {
                    strSql_One += " and t.add_time between to_date('" + strBeginTime + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + strEndTime + "','yyyy-MM-dd hh24:mi:ss')";
                }

                string strSql_Two = @"select to_char(t.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,
                                       t.type_name 	����Ϣ����,
                                       t.type_name_cy ����Ϣ����,
                                       t.patient_name ��������,
                                       t.patient_name his_id,
                                       t.patient_name ����,
                                       t.warn_type,
                                       t.patient_name �ܴ�ҽ��,
                                       t.content ��Ϣ����,
                                       t.operator_user_sender ���ͷ�,
                                       t.operator_user_name ������,
                                       t.reply_flag �ظ���� ,
                                       t.flag �Ķ�״̬,
                                       t.Receive_User_Name ������,
                                       t.section_target ���տ��� 
                                  from t_msg_info t
                                 where  1=1 ";
                if (strWarnSubstance == "��Ϣ��������")//�ж����ĸ��������
                {
                    strSql_Two += " and t.WARN_TYPE =19 ";
                }
                if (strOperatorName != "")
                {
                    strSql_Two += " and t.OPERATOR_USER_NAME='" + strOperatorName + "'";
                }
                if (strPatientID != "")
                {
                    strSql_Two += " and m.his_id like '%" + strPatientID + "%'";
                }
                if (strMsgStatus != "")
                {
                    strSql_Two += " and t.reply_flag='" + strMsgStatus + "'";
                }
                if (strBeginTime != "" && strEndTime != "")
                {
                    strSql_Two += " and t.add_time between to_date('" + strBeginTime + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + strEndTime + "','yyyy-MM-dd hh24:mi:ss')";
                }

                string strSql = strSql_One + " union " + strSql_Two;
                Class_Table[] tab = new Class_Table[1];
                tab[0] = new Class_Table();
                tab[0].Tablename = "MsgShow";
                tab[0].Sql = strSql;
                DataSet dsMsg = App.GetDataSet(tab);
                if (dsMsg != null)
                {
                    dgvMsgInfoNew.DataSource = dsMsg.Tables["MsgShow"];
                    dgvMsgInfoNew.Columns["����ʱ��"].Width = 90;
                    dgvMsgInfoNew.Columns["����Ϣ����"].Width = 80;
                    dgvMsgInfoNew.Columns["����Ϣ����"].Width = 80;
                    dgvMsgInfoNew.Columns["��������"].Width = 60;
                    dgvMsgInfoNew.Columns["his_id"].Width = 60;
                    dgvMsgInfoNew.Columns["����"].Width = 40;
                    dgvMsgInfoNew.Columns["�ܴ�ҽ��"].Width = 60;
                    dgvMsgInfoNew.Columns["��Ϣ����"].Width = 180;
                    dgvMsgInfoNew.Columns["���ͷ�"].Width = 50;
                    dgvMsgInfoNew.Columns["������"].Width = 50;
                    dgvMsgInfoNew.Columns["�ظ����"].Width = 60;
                    dgvMsgInfoNew.Columns["�Ķ�״̬"].Width = 60;
                    dgvMsgInfoNew.Columns["������"].Width = 50;
                    dgvMsgInfoNew.Columns["���տ���"].Width = 80;
                    dgvMsgInfoNew.Columns["warn_type"].Visible = false;
                }
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["�Ķ�״̬"].Value.ToString() == "true" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�Ķ�״̬"].Value = "���Ķ�";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["�Ķ�״̬"].Value.ToString() == "" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�Ķ�״̬"].Value = "δ�Ķ�";
                    }
                }

            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ucMsgShow_Load(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            string strSql_One = "update t_msg_info t set t.reply_flag='δ�ظ�' where t.isreply='1' and t.reply_msg is null";
            sqls.Add(strSql_One);
            string strsql_Two = "update t_msg_info t set t.reply_flag='��Ҫ����' where t.isreply='1' and t.warn_type='19'";
            sqls.Add(strsql_Two);
            string strsql_Three = "update t_msg_info t set t.reply_flag='����Ҫ����' where t.isreply='0' and t.warn_type='19'";
            sqls.Add(strsql_Three);
            int n = App.ExecuteBatch(sqls.ToArray());
            if (n > 0)
            {
                this.GetOperator_User_Name();
            }

        }
        /// <summary>
        /// ���ҵ�ǰ��������Ϣ
        /// </summary>
        private void GetOperator_User_Name()
        {
            txtName.DataSource = null;
            string sql = "select distinct(operator_user_name) from t_msg_info";
            DataSet ds = App.GetDataSet(sql);
            txtName.DisplayMember = "operator_user_name";
            txtName.DataSource = ds.Tables[0];

        }
        /// <summary>
        /// ������excel�ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    bool isShowExcel = true;
            //    DataGridviewShowToExcel(dgvMsgInfoNew, isShowExcel);
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    this.Cursor=Cursors.Default;
            //}
        }
        //public bool DataGridviewShowToExcel(DataGridView dgvMsgInfoNew, bool isShowExcle)
        //{
        ////    if (dgvMsgInfoNew.Rows.Count == 0)
        ////        return false;
        ////    //����Excel���� 
        ////    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        ////    excel.Application.Workbooks.Add(true);
        ////    excel.Visible = isShowExcle;
        ////    //�����ֶ����� 
        ////    for (int i = 0; i < dgvMsgInfoNew.ColumnCount; i++)
        ////    {
        ////        excel.Cells[1, i + 1] = dgvMsgInfoNew.Columns[i].HeaderText;
        ////    }
        ////    //������� 
        ////    for (int i = 0; i < dgvMsgInfoNew.RowCount - 1; i++)
        ////    {
        ////        for (int j = 0; j < dgvMsgInfoNew.ColumnCount; j++)
        ////        {
        ////            if (dgvMsgInfoNew[j, i].ValueType == typeof(string))
        ////            {
        ////                excel.Cells[i + 2, j + 1] = "'" + dgvMsgInfoNew[j, i].Value.ToString();
        ////            }
        ////            else
        ////            {
        ////                excel.Cells[i + 2, j + 1] = dgvMsgInfoNew[j, i].Value.ToString();
        ////            }
        ////        }
        ////    }
        ////    return true;
        //}
    }
}
