using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Data.OleDb;
using C1.Win.C1FlexGrid;
using System.Collections;
using DevComponents.DotNetBar;
//using Bifrost_ThreadManagement.Tsbl;

using System.Collections.Specialized;

namespace Base_Function.BLL_MSG_REMIND.MSG_RULE_SETTING
{
    public partial class ucMsgParam : UserControl
    {
        string strSectionIDs = "";//科室id
        string strSectionNames = "";//科室名称
        public ucMsgParam()
        {
            InitializeComponent();
        }

        private void ucMsgParam_Load(object sender, EventArgs e)
        {
            dstMsg_Setting.t_msg_setting.Clear();//清空数据集
            string strSql = @"select id,
                           warn_type,
                           msg_type,
                           msg_border_value,
                           msgsection_id,
                           msg_voluntarily_pop,
                           msg_start_up,
                           warn_type_name,
                           msg_section_name
                      from T_MSG_SETTING order by id asc
                    ";
            DataSet ds = App.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    this.dstMsg_Setting.t_msg_setting.ImportRow(dr);
                }
                dgvMsgInfoNew.DataSource = dstMsg_Setting.t_msg_setting;
            }
            for (int i = 0; i < dgvMsgInfoNew.Columns.Count; i++)
            {

            }



        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    ArrayList sqlList = new ArrayList();
                    string strMSG_VOLUNTARILY_POP = "";//自动弹出
                    string strMSG_START_UP = "";//是否启动
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell cellOne = dgvMsgInfoNew.Rows[i].Cells["MSG_VOLUNTARILY_POP"] as DataGridViewCheckBoxCell;
                        if (cellOne != null && cellOne.EditedFormattedValue.ToString() == "True")
                        {
                            strMSG_VOLUNTARILY_POP = "1";
                        }
                        else
                        {
                            strMSG_VOLUNTARILY_POP = "";
                        }
                        DataGridViewCheckBoxCell cellTwo = dgvMsgInfoNew.Rows[i].Cells["MSG_START_UP"] as DataGridViewCheckBoxCell;
                        if (cellTwo != null && cellTwo.EditedFormattedValue.ToString() == "True")
                        {
                            strMSG_START_UP = "1";
                        }
                        else
                        {
                            strMSG_START_UP = "";
                        }
                        string strMSG_BORDER_VALUE = dgvMsgInfoNew.Rows[i].Cells["MSG_BORDER_VALUE"].Value.ToString();
                        string strSql = "update t_msg_setting t set t.MSG_BORDER_VALUE='" + strMSG_BORDER_VALUE + "', " +
                                        "t.msg_voluntarily_pop='" + strMSG_VOLUNTARILY_POP + "',t.msg_start_up='" + strMSG_START_UP + "'" +
                                         "  where t.id='" + dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString() + "'";
                        sqlList.Add(strSql);
                    }
                    string[] sqlArr = new string[sqlList.Count];
                    for (int i = 0; i < sqlArr.Length; i++)
                    {
                        sqlArr[i] = sqlList[i].ToString();
                    }
                    int result = App.ExecuteBatch(sqlArr);

                    if (result > 0)
                    {
                        App.Msg("保存成功！");
                    }
                    else
                    {
                        App.Msg("保存失败！");
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

        private void dgvMsgInfoNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvMsgInfoNew.Columns[e.ColumnIndex].HeaderText == "启用科室")
                {
                    string strID = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                    if (strID != "")
                    {
                        string strSql = "select t.msgsection_id,t.warn_type from T_MSG_SETTING t  where t.id='" + strID + "'";
                        DataSet ds = App.GetDataSet(strSql);
                        string strMSGSECTION_ID = "";
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strMSGSECTION_ID = ds.Tables[0].Rows[0]["msgsection_id"].ToString();
                        }
                        // string strMSGSECTION_ID = dgvMsgInfoNew.CurrentRow.Cells["MSGSECTION_ID"].Value.ToString();
                        string strMSG_SECTION_NAME = dgvMsgInfoNew.CurrentRow.Cells["MSG_SECTION_NAME"].Value.ToString();
                       Base_Function.BLL_MANAGEMENT. frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(1, strMSGSECTION_ID, strMSG_SECTION_NAME);
                        frm.ShowDialog();
                        if (frm.flag)
                        {
                            strSectionIDs = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                            strSectionNames = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                            if ((strSectionIDs != "" && strSectionNames != "") || (strSectionIDs != null && strSectionNames != null))
                            {
                                List<string> sqlbatch = new List<string>();
                                string strWarn_type = ds.Tables[0].Rows[0]["warn_type"].ToString();
                                string strDelete_sql = "delete from  T_MSG_SETTING_SECTION  t where t.warn_type='" + strWarn_type + "'";
                                sqlbatch.Add(strDelete_sql);
                                string[] strSection_ids = strSectionIDs.Split(',');
                                for (int i = 0; i < strSection_ids.Length; i++)
                                {
                                    string strInsert = "insert into t_msg_setting_section(warn_type, section_id) values ('" + strWarn_type + "', '" + strSection_ids[i] + "') ";
                                    sqlbatch.Add(strInsert);
                                }
                                string strSQL = "update t_msg_setting  set msgsection_id='" + strSectionIDs + "',MSG_SECTION_NAME='" + strSectionNames + "' where id='" + strID + "'";
                                sqlbatch.Add(strSQL);
                                if (sqlbatch.Count > 0)
                                {
                                    App.ExecuteBatch(sqlbatch.ToArray());
                                }
                            }
                            ucMsgParam_Load(null, null);
                            dgvMsgInfoNew_CellFormatting(null, null);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 添加tooltiptext功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
            {
                if (dgvMsgInfoNew.Rows[i].Cells["MSG_SECTION_NAME"].Value.ToString() != "")
                {
                    DataGridViewCell cell = dgvMsgInfoNew.Rows[i].Cells["MSGSECTION_ID"];
                    cell.ToolTipText = dgvMsgInfoNew.Rows[i].Cells["MSG_SECTION_NAME"].Value.ToString();
                }
            }
        }

        private void dgvMsgInfoNew_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
