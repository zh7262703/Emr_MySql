using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class frmChooseMsg : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 当前病人
        /// </summary>
        private InPatientInfo pat;

        public frmChooseMsg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId">电子病历病人ID</param>
        public frmChooseMsg(InPatientInfo patient)
        {
            InitializeComponent();
            this.pat = patient;
        }
        private void frmChooseMsg_Load(object sender, EventArgs e)
        {
            try
            {
                lvMsg.HeaderStyle = ColumnHeaderStyle.None;
                lvMsg.MinimumSize = new Size(200, 150);
                lvMsg.FullRowSelect = true;

                SetMsgType();
                SetDoctor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置消息类型下拉菜单
        /// </summary>
        private void SetMsgType()
        {
            cbxMsgType.DataSource = null;

            string sqlMsgType = "select id,type_name from t_msg_type";
            DataSet ds = App.GetDataSet(sqlMsgType);

            //查询类型
            cbxMsgType.DisplayMember = "type_name";
            cbxMsgType.ValueMember = "id";
            cbxMsgType.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 设置接收医生
        /// 写过文书或者当前经治医师
        /// </summary>
        private void SetDoctor()
        {
            string sql_doctor = "select user_id,user_name from t_userinfo " +
                        "where user_id in(select createid from t_patients_doc where patient_id=" + pat.Id + ")" +
                         "or   user_id in(select highersignuserid from t_patients_doc where patient_id=" + pat.Id + ")";
            DataSet ds = App.GetDataSet(sql_doctor);
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = App.GetDataSet("select user_id,user_name from t_userinfo where user_id in(select sick_doctor_id from t_in_patient where id=" + pat.Id + " )");
            }
            cbxDoctor2.DisplayMember = "user_name";
            cbxDoctor2.ValueMember = "user_id";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cbxDoctor2.Items.Add(ds.Tables[0].Rows[i]["user_name"], false);

            }
            cbxDoctor2.DataSource = ds.Tables[0];

        }

        private void cbxMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMsgType.SelectedIndex >= 0)
            {
                string sql_Msg = "select * from t_msg_content where type_id=" + cbxMsgType.SelectedValue.ToString();
                DataSet ds_Msg = App.GetDataSet(sql_Msg);
                if (ds_Msg != null)
                {
                    lvMsg.Items.Clear();
                    for (int i = 0; i < ds_Msg.Tables[0].Rows.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Text = ds_Msg.Tables[0].Rows[i]["message"].ToString();
                        //2014-10-22  袁杨修改 因为此处接收的id在后面的操作中没有实际用处，所以修改为接收msg_scale（消息类型）字段
                        //用来后面做关联使用。

                        //lvItem.Tag = ds_Msg.Tables[0].Rows[i]["id"].ToString();

                        lvItem.Tag = ds_Msg.Tables[0].Rows[i]["msg_scale"].ToString();


                        lvMsg.Items.Add(lvItem);
                    }
                }
            }
        }
        private void lvMsg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvMsg.SelectedItems.Count > 0)
                {
                    ArrayList sqlList = new ArrayList();
                    int newid = App.GenId("t_msg_info", "id");
                    if (cbxDoctor2.CheckedItems.Count > 0)
                    {
                        foreach (DataRowView drv in cbxDoctor2.CheckedItems)
                        {

                            sqlList.Add("insert into t_msg_info" +
                                                        "(id, pid, patient_name, receive_user_id,receive_user_name, operator_user_id , operator_user_name, type_id, type_name, content_id, content, msg_status,flag)" +
                                                        "values" +
                                                        "(" + newid + ", " + pat.Id + ", '" + pat.Patient_Name + "', " + cbxDoctor2.SelectedValue + ", '" + drv["user_name"].ToString() + "', '" + App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "', " +
                                                        cbxMsgType.SelectedValue + ", '" + cbxMsgType.Text + "', '" +
                                                        lvMsg.SelectedItems[0].Tag.ToString() + "', '" + lvMsg.SelectedItems[0].Text + "', '0','false')");
                            newid++;

                        }
                    }
                    else
                    {
                        App.Msg("请先选择科室值班医生！");
                        return;
                    }
                    string[] arrStr = new string[sqlList.Count];
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        arrStr[i] = sqlList[i].ToString();
                    }
                    int num = App.ExecuteBatch(arrStr);
                    if (num > 0)
                    {
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message);
            }
        }
    }
}