using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class frmSendNotice : DevComponents.DotNetBar.Office2007Form
    {
        public delegate void RefEventHandler();
        public event RefEventHandler BtnEnable;

        string Sendee = "";//接收人
        string SendSec = "";//接收科室
        string type = "";//整改级别
        string infoId = "";//整改信息主键id
        DataTable dtSubjective = new DataTable();
        DataTable dtObjective = new DataTable();
        InPatientInfo PatientInfo = new InPatientInfo();
        DataTable dtInfoOld = new DataTable(); //存储上一次未反馈的整改信息
        public frmSendNotice()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dtSubjective">主观评分表</param>
        /// <param name="_dtObjective">客观评分表</param>
        public frmSendNotice(DataTable _dtSubjective, DataTable _dtObjective,InPatientInfo inpat, string strType,string strInfoId)
        {
            InitializeComponent();
            dtSubjective = _dtSubjective;
            dtObjective = _dtObjective;
            PatientInfo = inpat;
            type = strType;
            infoId = strInfoId;
        }

        private void frmSendNotice_Load(object sender, EventArgs e)
        {
            
                lblQPeo.Text = App.UserAccount.UserInfo.User_name;
                lblQSec.Text = App.UserAccount.CurrentSelectRole.Role_name;
                lblNTime.Text = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                lblSendee.Text = PatientInfo.Sick_Doctor_Name.ToString();
                lblSendSec.Text = PatientInfo.Section_Name.ToString();
                //自评、科室和院级都为环节质控
                if (type == "E")
                    lblGrade.Text = "终末质控";
                else
                    lblGrade.Text = "环节质控";


                DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
                colCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
                colCB.Name = "1";
                colCB.HeaderCell = cbHeader;
                dgvObjective.Columns.Insert(0, colCB);
                cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
                dgvObjective.DataSource = dtObjective.DefaultView;

                dgvSubjective.DataSource = dtSubjective.DefaultView;
                for (int i = 0; i < dgvObjective.Columns.Count; i++)
                {
                    if (dgvObjective.Columns[i].Name == "1")
                    {
                        dgvObjective.Columns[i].ReadOnly = false;
                        dgvObjective.Columns[i].Width = 30;
                    }
                    else
                    {
                        dgvObjective.Columns[i].ReadOnly = true;
                        dgvObjective.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                dgvObjective.Columns["项目编码"].Visible = false;
                try
                {
                    //是否有上一次未反馈的整改信息
                    string strSql = "select id,CONTENT from T_AMENDMENTS_INFO t where (t.state_flag='0' or t.state_flag='1') and t.patient_id='" +
                                               PatientInfo.Id.ToString() + "' and t.receive_user_id='" + PatientInfo.Sick_Doctor_Id + "' and type='" + type + "'";
                    dtInfoOld = App.GetDataSet(strSql).Tables[0];
                    if (dtInfoOld.Rows.Count > 0)
                    {
                        string strMarkId = App.ReadSqlVal("select mark_id from t_quality_relation where key_id='" + dtInfoOld.Rows[0]["id"].ToString() + "'and flag='1'", 0, "mark_id");
                        if (!string.IsNullOrEmpty(strMarkId))
                        {
                            foreach (DataGridViewRow Row in dgvObjective.Rows)
                            {
                                if (strMarkId.Contains("," + Row.Cells["项目编码"].Value.ToString() + ","))
                                    Row.Cells["1"].Value = true;
                            }
                        }
                        rtxRemarks.Text = dtInfoOld.Rows[0]["CONTENT"].ToString();
                    }
                }
                catch { }
        }

        /// <summary>
        /// 发送整改通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            try
            {
                #region 作废
                //if (!string.IsNullOrEmpty(infoId))//反馈界面再次发送整改通知、将本条通知信息状态改为反馈确认
                //{
                //    string strSql = "update T_AMENDMENTS_INFO set STATE_FLAG='4',CONFIRM_TIME=sysdate where id='" + infoId + "'";
                //    if (App.ExecuteSQL(strSql) > 0)
                //    {
                //        string id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");
                //        sqls.Add("insert into T_AMENDMENTS_INFO(id,PATIENT_ID,PID,PATIENT_NAME,CONTENT,SEND_TIME,RECEIVE_USER_ID,RECEIVE_USER_NAME,OPERATOR_USER_ID,OPERATOR_USER_NAME,STATE_FLAG,TYPE)" + "values('"+id+"','" + PatientInfo.Id + "','" + PatientInfo.PId + "','" + PatientInfo.Patient_Name + "','" + rtxRemarks.Text + "',to_TIMESTAMP('" + lblNTime.Text
                //                           + "','yyyy-MM-dd hh24:mi') ,'" + PatientInfo.Sick_Doctor_Id + "','" + PatientInfo.Sick_Doctor_Name + "','" +
                //                           App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "',0,'" + type + "')");

                //        string strMark_id = ",";
                //        //保存自动质控扣分项
                //        for (int k = 0; k < dgvObjective.Rows.Count; k++)
                //        {
                //            if (dgvObjective.Rows[k].Cells["11"].EditedFormattedValue.ToString() == Boolean.TrueString)
                //            {
                //                strMark_id += dgvObjective.Rows[k].Cells["项目编码"].Value.ToString() + ",";
                //            }

                //        }
                //        if (strMark_id != ",")
                //        {                            
                //            sqls.Add("insert into T_QUALITY_RELATION(key_id,mark_id,OPERATOR_USER_ID,time,flag) values('" + id + "','" + strMark_id + "','" +
                //                    App.UserAccount.UserInfo.User_id.ToString() + "',sysdate,'0')");
                //        }

                //        if (App.ExecuteBatch(sqls.ToArray()) > 0)
                //        {
                //            App.Msg("发送成功！");
                //            if (BtnEnable != null)
                //                BtnEnable();

                //            this.Dispose();
                //            this.Close();
                //        }
                //        else
                //        {
                //            App.Msg("发送失败，请重试！");
                //        }
                //    }
                //}
                //else {
                #endregion                
                string id = "";
                //反馈确认界面再次发送整改通知，更新之前的整改通知
                if (!string.IsNullOrEmpty(infoId))
                {
                    sqls.Add("update T_AMENDMENTS_INFO set CONTENT='" + rtxRemarks.Text + "',SEND_TIME=to_TIMESTAMP('" + lblNTime.Text
                                              + "','yyyy-MM-dd hh24:mi'),STATE_FLAG='1' where id='" + infoId + "'");
                    id = infoId;
                }
                else
                {
                    //判断是否有反馈之前的整改通知，有：更新信息；没有：继续插入数据                  
                    if (dtInfoOld.Rows.Count>0)
                    {
                        id = dtInfoOld.Rows[0]["id"].ToString();
                        sqls.Add("update T_AMENDMENTS_INFO set CONTENT='" + rtxRemarks.Text + "',SEND_TIME=to_TIMESTAMP('" + lblNTime.Text
                                                 + "','yyyy-MM-dd hh24:mi'),STATE_FLAG='1' where id='" + id + "'");

                    }
                    else
                    {                      
                        id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");
                        sqls.Add("insert into T_AMENDMENTS_INFO(id,PATIENT_ID,PID,PATIENT_NAME,CONTENT,SEND_TIME,RECEIVE_USER_ID,RECEIVE_USER_NAME,OPERATOR_USER_ID,OPERATOR_USER_NAME,STATE_FLAG,TYPE)" + "values('" + id + "','" + PatientInfo.Id + "','" + PatientInfo.PId + "','" + PatientInfo.Patient_Name + "','" + rtxRemarks.Text + "',to_TIMESTAMP('" + lblNTime.Text
                                                  + "','yyyy-MM-dd hh24:mi') ,'" + PatientInfo.Sick_Doctor_Id + "','" + PatientInfo.Sick_Doctor_Name + "','" +
                                                  App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "',0,'" + type + "')");
                    }
                }
                //保存自动质控扣分项
                string strMark_id = ",";              
                for (int k = 0; k < dgvObjective.Rows.Count; k++)
                {

                    if (dgvObjective.Rows[k].Cells["1"].EditedFormattedValue.ToString() == Boolean.TrueString)
                    {
                        strMark_id += dgvObjective.Rows[k].Cells["项目编码"].Value.ToString() + ",";
                    }

                }
                sqls.Add("delete T_QUALITY_RELATION where key_id='" + id + "' and flag='1'");
                if (strMark_id != ",")
                {                    
                    sqls.Add("insert into T_QUALITY_RELATION(key_id,mark_id,OPERATOR_USER_ID,time,flag) values('" + id + "','" + strMark_id + "','" +
                            App.UserAccount.UserInfo.User_id.ToString() + "',sysdate,'1')");
                }

                if (App.ExecuteBatch(sqls.ToArray()) > 0)
                {
                    App.Msg("发送成功！");
                    if (BtnEnable != null)
                        BtnEnable();
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    App.Msg("发送失败，请重试！");
                }
            }
            catch (Exception ex) { App.Msg(ex.ToString()); }
        }

        /// <summary>
        /// 整改通知列头全选
        /// </summary>
        /// <param name="state"></param>
        void cbHeader_OnCheckBoxClicked(bool state)
        {
            foreach (DataGridViewRow Row in dgvObjective.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["1"]).Value = state;
            }
            dgvObjective.RefreshEdit();
        }                

    }
}
