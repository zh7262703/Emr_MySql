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
    /// 开发者:袁杨    130705
    /// </summary>
    public partial class ucMsgShow : UserControl
    {
        /// <summary>
        /// 获取当前提醒内容名称
        /// </summary>
        string strWarnSubstance;
        public ucMsgShow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvMsgInfoNew.Columns.Clear();//清空表格显示数据
                strWarnSubstance = cbWarnSubstance.Text.ToString();//提醒内容
                string strOperatorName = this.txtName.Text.ToString();//发布人
                string strPatientID = this.txtPatientID.Text.ToString();//患者id
                string strMsgStatus = this.txtMsgStatus.Text.ToString();//回复状态
                string strBeginTime = this.dtpBegin.Value.AddDays(-1).ToShortDateString();//发布开始时间
                string strEndTime = this.dtpEnd.Value.AddDays(+1).ToShortDateString();//发布结束时间
                if (Convert.ToDateTime(strEndTime) < Convert.ToDateTime(strBeginTime))
                {
                    App.Msg("输入的结束时间必须大于开始时间！");
                    return;
                }
                if (strBeginTime == "" || strEndTime == "")
                {
                    App.Msg("必需要输入开始和结束时间！");
                    return;
                }

                string strSql_One = @"select to_char(t.add_time,'yyyy-MM-dd hh24:mi') 发布时间,
                                       t.type_name 	主消息类型,
                                       t.type_name_cy 子消息类型,
                                       t.patient_name 病人姓名,
                                       m.his_id his_id,
                                       m.sick_bed_no 床号,
                                       t.warn_type,
                                       m.sick_doctor_name 管床医生,
                                       t.content 消息内容,
                                       t.operator_user_sender 发送方,
                                       t.operator_user_name 发送人,
                                       t.reply_flag 回复标记 ,
                                       t.msg_status 阅读状态,
                                       t.Receive_User_Name 接收人,
                                       s.msg_section_name 接收科室 
                                  from t_msg_info t, t_in_patient m,t_msg_setting  s
                                 where t.pid = m.id and t.warn_type=s.warn_type";
                if (strWarnSubstance == "质控提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE in (3,4) ";
                }
                if (strWarnSubstance == "检验提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE in (5,6,7) ";
                }
                if (strWarnSubstance == "Pacs检查提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE in (8,9) ";
                }
                if (strWarnSubstance == "状态提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE =10 ";
                }
                if (strWarnSubstance == "体征提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE in (11,12,13,14,15)";
                }
                if (strWarnSubstance == "医嘱提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE =16";
                }
                if (strWarnSubstance == "其他提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE = 18 ";
                }
                if (strWarnSubstance == "主动提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE in (1,2)";
                }
                if (strWarnSubstance == "评分提醒")//判断是哪个提醒类别
                {
                    strSql_One += " and t.WARN_TYPE =17 ";
                }
                if (strWarnSubstance == "消息发布提醒")//判断是哪个提醒类别
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

                string strSql_Two = @"select to_char(t.add_time,'yyyy-MM-dd hh24:mi') 发布时间,
                                       t.type_name 	主消息类型,
                                       t.type_name_cy 子消息类型,
                                       t.patient_name 病人姓名,
                                       t.patient_name his_id,
                                       t.patient_name 床号,
                                       t.warn_type,
                                       t.patient_name 管床医生,
                                       t.content 消息内容,
                                       t.operator_user_sender 发送方,
                                       t.operator_user_name 发送人,
                                       t.reply_flag 回复标记 ,
                                       t.flag 阅读状态,
                                       t.Receive_User_Name 接收人,
                                       t.section_target 接收科室 
                                  from t_msg_info t
                                 where  1=1 ";
                if (strWarnSubstance == "消息发布提醒")//判断是哪个提醒类别
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
                    dgvMsgInfoNew.Columns["发布时间"].Width = 90;
                    dgvMsgInfoNew.Columns["主消息类型"].Width = 80;
                    dgvMsgInfoNew.Columns["子消息类型"].Width = 80;
                    dgvMsgInfoNew.Columns["病人姓名"].Width = 60;
                    dgvMsgInfoNew.Columns["his_id"].Width = 60;
                    dgvMsgInfoNew.Columns["床号"].Width = 40;
                    dgvMsgInfoNew.Columns["管床医生"].Width = 60;
                    dgvMsgInfoNew.Columns["消息内容"].Width = 180;
                    dgvMsgInfoNew.Columns["发送方"].Width = 50;
                    dgvMsgInfoNew.Columns["发送人"].Width = 50;
                    dgvMsgInfoNew.Columns["回复标记"].Width = 60;
                    dgvMsgInfoNew.Columns["阅读状态"].Width = 60;
                    dgvMsgInfoNew.Columns["接收人"].Width = 50;
                    dgvMsgInfoNew.Columns["接收科室"].Width = 80;
                    dgvMsgInfoNew.Columns["warn_type"].Visible = false;
                }
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["阅读状态"].Value.ToString() == "true" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["阅读状态"].Value = "已阅读";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["阅读状态"].Value.ToString() == "" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["阅读状态"].Value = "未阅读";
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
            string strSql_One = "update t_msg_info t set t.reply_flag='未回复' where t.isreply='1' and t.reply_msg is null";
            sqls.Add(strSql_One);
            string strsql_Two = "update t_msg_info t set t.reply_flag='需要收条' where t.isreply='1' and t.warn_type='19'";
            sqls.Add(strsql_Two);
            string strsql_Three = "update t_msg_info t set t.reply_flag='不需要收条' where t.isreply='0' and t.warn_type='19'";
            sqls.Add(strsql_Three);
            int n = App.ExecuteBatch(sqls.ToArray());
            if (n > 0)
            {
                this.GetOperator_User_Name();
            }

        }
        /// <summary>
        /// 查找当前发布者信息
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
        /// 导出到excel文件
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
        ////    //建立Excel对象 
        ////    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        ////    excel.Application.Workbooks.Add(true);
        ////    excel.Visible = isShowExcle;
        ////    //生成字段名称 
        ////    for (int i = 0; i < dgvMsgInfoNew.ColumnCount; i++)
        ////    {
        ////        excel.Cells[1, i + 1] = dgvMsgInfoNew.Columns[i].HeaderText;
        ////    }
        ////    //填充数据 
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
