using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

using System.Collections.Specialized;
using System.Collections;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class frmNotice : DevComponents.DotNetBar.Office2007Form
    {
        //当前病人
        InPatientInfo currPatient;
        public frmNotice()
        {
            InitializeComponent();
        }
        public frmNotice(InPatientInfo patient)
        {
            InitializeComponent();
            currPatient = patient;
        }
        private void ucNotice_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                dgvNewMsg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvReadMsg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //设置病人信息
                SetPatientInfo();
                //绑定表格数据
                DataBand();
                ListDictionary ldPathography = new ListDictionary();//是否需要回复
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void DataBand()
        {
            string sql_NewMsg = "select id,pid,type_id,type_name,content,content_id,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') add_time,operator_user_name,operator_user_id,receive_user_name,(case flag when 'true' then '已发送' else '未发送' end) flag,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') dispose_time,isreply from t_msg_info where dispose_time is null and pid=" + currPatient.Id;
            string sql_ReadMsg = "select id,pid,type_id,type_name 消息类型,content_id 消息级别,content 消息内容,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') 发布时间,operator_user_name 发布人,operator_user_id,receive_user_name 接收人,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') 处理时间,REPLY_MSG 回复内容 from t_msg_info where dispose_time is not null and pid=" + currPatient.Id;

            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sql_NewMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "readMsg";
            tab[1].Sql = sql_ReadMsg;
            DataSet ds = App.GetDataSet(tab);


            if (ds != null)
            {
                dgvNewMsg.DataSource = null;
                dst_t_msg_info.T_MSG_INFO.Clear();
                #region 未处理的消息（未读和未发送的）
                if (ds.Tables["newMsg"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables["newMsg"].Rows)
                    {
                        this.dst_t_msg_info.T_MSG_INFO.ImportRow(dr);
                    }
                    dgvNewMsg.DataSource = dst_t_msg_info.T_MSG_INFO;

                    //dgvNewMsg.Columns["id"].Visible = false;
                    //dgvNewMsg.Columns["pid"].Visible = false;
                    //dgvNewMsg.Columns["type_id"].Visible = false;
                    //dgvNewMsg.Columns["operator_user_id"].Visible = false;
                    //dgvNewMsg.Columns["处理时间"].Visible = false;


                }
                #endregion
                #region 已读消息
                if (ds.Tables["readMsg"].Rows.Count > 0)
                {
                    dgvReadMsg.DataSource = ds.Tables["readMsg"];
                    dgvReadMsg.Columns["id"].Visible = false;
                    dgvReadMsg.Columns["pid"].Visible = false;
                    dgvReadMsg.Columns["type_id"].Visible = false;
                    dgvReadMsg.Columns["operator_user_id"].Visible = false;

                }
                #endregion
            }



        }
        /// <summary>
        /// 设置病人信息
        /// </summary>
        private void SetPatientInfo()
        {
            if (currPatient != null)
            {
                lblPatientId.Text = currPatient.His_id.Split('-')[0];//his病人ID
                lblPid.Text = currPatient.PId;
                lblName.Text = currPatient.Patient_Name;
                lblSex.Text = currPatient.Gender_Code == "0" ? "男" : "女";
                lblAge.Text = currPatient.Age + " " + currPatient.Age_unit;
                lblPayManner.Text = currPatient.Pay_Manager;
                lblInTime.Text = currPatient.In_Time.ToString("yyyy-MM-dd HH:mm");
                lblOutSection.Text = currPatient.Section_Name;
               // lblInDoctor.Text = currPatient.Sick_Doctor_Name;
                lblSickDegree.Text = App.ReadSqlVal("select * from t_data_code where type='133' and code='" + currPatient.Sick_Degree + "'", 0, "name");
                lblSickDoctor.Text = currPatient.Sick_Doctor_Name;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChooseMsg frm = new frmChooseMsg(currPatient);
            frm.ShowDialog();
            DataBand();
        }

        private void frmNotice_SizeChanged(object sender, EventArgs e)
        {
            int x = btnAdd.Parent.Size.Width / 2 - btnAdd.Size.Width;
            btnAdd.Location = new Point(x, btnAdd.Location.Y);
            btnDelete.Location = new Point(btnAdd.Location.X + 81, btnDelete.Location.Y);
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNewMsg.CurrentRow != null)
            {
               // DataRowView drv = this.T_Msg_InfobindingSource.Current as DataRowView;
                string strId = dgvNewMsg.CurrentRow.Cells["id"].Value.ToString();
                if (strId != "")
                {
                    //发布人ID
                    string operatorId = dgvNewMsg.CurrentRow.Cells["operator_user_id"].Value.ToString();
                    if (dgvNewMsg.CurrentRow.Cells["flag"].Value.ToString() == "已发送")
                    {
                        App.Msg("消息已发送，不能删除！");
                    }
                    else if (App.UserAccount.UserInfo.User_id == operatorId)
                    {
                        string sqlDel = "delete from t_msg_info where id=" + strId;
                        int num = App.ExecuteSQL(sqlDel);
                        if (num > 0)
                        {
                            DataBand();
                            App.Msg("删除成功！");
                        }
                        else
                        {
                            App.Msg("删除失败！");
                        }
                    }
                    else
                    {
                        App.Msg("只能删除本人发布的消息！");
                    }
                }
            }
        }

        /// <summary>
        /// 发送所有消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string msgIds_zy = "";    //需要回复的重要消息集合
            string msgIds_pt = "";    //需要回复的普通消息集合
            string numsgIds_zy = "";  //不需要回复的重要消息集合
            string numsgIds_pt = "";  //不需要回复的普通消息集合
            ArrayList sqlList = new ArrayList();
            for (int i = 0; i < dgvNewMsg.Rows.Count; i++)
            {
                if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["flag"].ToString() == "未发送")//flag发送标志，false表示这条消息没有发送
                {
                    if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["isreply"].ToString() == "1")//需要回复的消息
                    {
                        if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "重要消息")//需要回复的重要消息
                        {
                            if (msgIds_zy == "")
                            {
                                msgIds_zy = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                msgIds_zy += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                        else if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "普通消息")
                        {
                            if (msgIds_pt == "")
                            {
                                msgIds_pt = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                msgIds_pt += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }

                    }
                    else//不需要回复的消息
                    {
                        if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "重要消息")//不需要回复的重要消息
                        {
                            if (numsgIds_zy == "")
                            {
                                numsgIds_zy = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                numsgIds_zy += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                        else if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "普通消息")
                        {
                            if (numsgIds_pt == "")
                            {
                                numsgIds_pt = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                numsgIds_pt += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                    }
                }
            }
            #region 隐藏掉
            //if (msgIds != "" && msgId != "")//需要回复和不需要回复的消息都存在
            //{
            //    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='8' where id in(" + msgIds + ")");
            //    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,WARN_TYPE='8' where id in(" + msgId + ")");
            //    string[] arrStr = new string[sqlList.Count];
            //    for (int i = 0; i < sqlList.Count; i++)
            //    {
            //        arrStr[i] = sqlList[i].ToString();
            //    }
            //    int num = App.ExecuteBatch(arrStr);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("发送成功！");
            //    }
            //    else
            //    {
            //        App.Msg("发送失败！");
            //    }
            //}
            //else if (msgIds != "" && msgId == "")//只存在需要回复的消息
            //{
            //    string strSql = "update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='8' where id in(" + msgIds + ")";
            //    int num = App.ExecuteSQL(strSql);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("发送成功！");
            //    }
            //    else
            //    {
            //        App.Msg("发送失败！");
            //    }
            //}
            //else if (msgIds == "" && msgId != "")//只存在不需要回复的消息
            //{
            //    string strSql = "update t_msg_info set flag='true',add_time=sysdate,WARN_TYPE='8' where id in(" + msgId + ")";
            //    int num = App.ExecuteSQL(strSql);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("发送成功！");
            //    }
            //    else
            //    {
            //        App.Msg("发送失败！");
            //    }
            //}
            //else
            //{
            //    App.Msg("没有要发送的消息！");
            //} 
            #endregion
            if (msgIds_zy != "" || msgIds_pt != "" || numsgIds_zy != "" || numsgIds_pt != "") //更新数据库操作
            {
                if (msgIds_zy != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='1' where id in(" + msgIds_zy + ")");//需要回复的重要消息集合
                }
                if (msgIds_pt != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='2' where id in(" + msgIds_pt + ")");  //需要回复的普通消息集合
                }
                if (numsgIds_zy != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='0',WARN_TYPE='1' where id in(" + numsgIds_zy + ")");   //不需要回复的重要消息集合                
                }
                if (numsgIds_pt != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='0',WARN_TYPE='2' where id in(" + numsgIds_pt + ")");   //不需要回复的普通消息集合
                }
                string[] arrStr = new string[sqlList.Count];
                for (int i = 0; i < sqlList.Count; i++)
                {
                    arrStr[i] = sqlList[i].ToString();
                }
                int num = App.ExecuteBatch(arrStr);
                if (num > 0)
                {
                    DataBand();
                    App.Msg("发送成功！");
                }
                else
                {
                    App.Msg("发送失败！");
                }
            }
        }
    }
}
