using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    //查询收条功能   袁杨2014-11-26 添加
    public partial class frmMsgSendCheckReceipt : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 用来接收消息主键id
        /// </summary>
        public string strMsg_id = "";
        public string strReturn_value = "";
        public frmMsgSendCheckReceipt()
        {
            InitializeComponent();
        }
        public frmMsgSendCheckReceipt(string id)
        {
            InitializeComponent();
            strMsg_id = id;
        }
        private void frmMsgSendCheckReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.getMsg();
            }
            catch
            {

            }
        }
        private void getMsg()
        {
            try
            {
                dgvMsg.Rows.Clear();
                string strSql = @"select t.id,t.pid,t.patient_name,
                                   t.type_name_cy,
                                   t.type_name,
                                   t.content,
                                   t.operator_user_name,
                                   to_char(t.add_time, 'yyyy-MM-dd hh24:mi') as add_time,
                                   t.type_id,
                                   p.user_name,
                                   p.isreply,
                                   t.msg_status
                              from T_MSG_INFO t,t_msg_user p where t.id=p.id and p.id='" + strMsg_id + "' and p.isreply !='0' and t.msg_status='1' and t.warn_type='19' order by add_time desc";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvMsg.Rows.Add();

                        dgvMsg.Rows[i].Cells["Column9"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                        dgvMsg.Rows[i].Cells["Column1"].Value = ds.Tables[0].Rows[i]["type_name_cy"].ToString();
                        dgvMsg.Rows[i].Cells["Column2"].Value = ds.Tables[0].Rows[i]["type_name"].ToString();
                        dgvMsg.Rows[i].Cells["Column3"].Value = ds.Tables[0].Rows[i]["content"].ToString();
                        if (ds.Tables[0].Rows[i]["type_id"].ToString() == "1")
                        {
                            dgvMsg.Rows[i].Cells["Column4"].Value = ds.Tables[0].Rows[i]["patient_name"].ToString();
                        }
                        else
                        {
                            dgvMsg.Rows[i].Cells["Column4"].Value = ds.Tables[0].Rows[i]["operator_user_name"].ToString();
                        }
                        dgvMsg.Rows[i].Cells["Column5"].Value = ds.Tables[0].Rows[i]["add_time"].ToString();
                        dgvMsg.Rows[i].Cells["Column6"].Value = ds.Tables[0].Rows[i]["user_name"].ToString();
                        if (ds.Tables[0].Rows[i]["isreply"].ToString() == "1")
                        {
                            dgvMsg.Rows[i].Cells["Column7"].Value = "未发送";
                        }
                        else
                        {
                            dgvMsg.Rows[i].Cells["Column7"].Value = "已发送";
                        }
                        if (ds.Tables[0].Rows[i]["msg_status"].ToString() == "1")
                        {
                            dgvMsg.Rows[i].Cells["Column8"].Value = "已发布";
                        }
                    }
                    dgvMsg.Columns["Column1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column4"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["column5"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column6"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column8"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //换行显示 已读界面的提醒内容
                    dgvMsg.Columns["Column3"].Width = 250;
                    dgvMsg.Columns[4].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                    dgvMsg.AutoResizeRows();
                    dgvMsg.Refresh();
                    //dgvMsg.AutoResizeColumns();//内容全部
                }
            }
            catch
            {

            }
        }
    }
}