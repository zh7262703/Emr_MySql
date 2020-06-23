using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class frmMessageShow : DevComponents.DotNetBar.Office2007Form
    {
        public frmMessageShow()
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
          
        }

        /// <summary>
        /// ��ȡδ��ȡ����Ϣ
        /// </summary>
        private void GetUnReadMessages()
        {
            try
            {
                trvMessage.Nodes.Clear();
                RichTxtMessage.Text = "";
                lblCreateTime.Text = "����ʱ�䣺";
                lblCreator.Text = "�����ˣ�";
                string Sql = "select * from T_MSG_INFO t where t.receive_user_ID like '%" + App.UserAccount.UserInfo.User_id + "%' and (select count(*) from T_MSG_USER a where a.MSG_ID=t.id and USER_ID="+App.UserAccount.UserInfo.User_id+")=0";
                DataSet ds = App.GetDataSet(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Class_Message msg = new Class_Message();

                        msg.Id = ds.Tables[0].Rows[i]["id"].ToString();
                        msg.Pid = ds.Tables[0].Rows[i]["pid"].ToString(); ;
                        msg.Patient_name = ds.Tables[0].Rows[i]["patient_name"].ToString();
                        msg.In_time = ds.Tables[0].Rows[i]["in_time"].ToString();
                        msg.Receive_user = ds.Tables[0].Rows[i]["receive_user_Id"].ToString();
                        msg.Title = ds.Tables[0].Rows[i]["title"].ToString();
                        msg.Content = ds.Tables[0].Rows[i]["content"].ToString();
                        msg.Add_time = ds.Tables[0].Rows[i]["add_time"].ToString();
                        msg.Operator_user = ds.Tables[0].Rows[i]["operator_user"].ToString(); ;

                        TreeNode tn = new TreeNode();
                        tn.Text = msg.Title;
                        tn.Name = msg.Id;
                        tn.Tag = msg;

                        trvMessage.Nodes.Add(tn);
                    }

                 
                }
                else
                {
                    App.Msg("��ǰû���κ���Ϣ��");                   
                }
              

            }
            catch(Exception ex)
            {
                App.MsgErr("��ȡ��Ϣʧ�ܣ�ԭ��:"+ex.Message);              
            }                       
        }

        /// <summary>
        /// ȷ���Ѷ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (trvMessage.SelectedNode != null)
            {
                try
                {
                    Class_Message temp=(Class_Message)trvMessage.SelectedNode.Tag;
                    string[] sqls = new string[2];
                    sqls[0] = "delete from T_MSG_USER where MSG_ID=" + temp.Id + " and USER_ID=" + App.UserAccount.UserInfo.User_id + "";
                    sqls[1] = "insert into T_MSG_USER(MSG_ID,USER_ID)values(" + temp.Id + "," + App.UserAccount.UserInfo.User_id + ")";
                    if (App.ExecuteBatch(sqls) > 0)
                    {
                        App.Msg("�����ɹ���");
                        GetUnReadMessages();
                    }
                }
                catch(Exception ex)
                {
                    App.MsgErr("����ʧ�ܣ�ԭ��:" + ex.Message);
                }
            }
            else
            {
                App.MsgWaring("��ѡ����ѡ����Ҫȷ�ϵ���Ϣ��");
            }
        }

        /// <summary>
        /// �ر�ҳ��        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageShow_Load(object sender, EventArgs e)
        {
            GetUnReadMessages();
        }

        private void trvMessage_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvMessage.SelectedNode != null)
            {
                if(trvMessage.SelectedNode.Tag!=null)
                {
                    try
                    {
                        Class_Message temp = (Class_Message)trvMessage.SelectedNode.Tag;
                        RichTxtMessage.Text = temp.Content;

                        lblCreateTime.Text = "����ʱ�䣺" + temp.Add_time;
                        lblCreator.Text = "�����ˣ�" + temp.Operator_user;
                    }
                    catch
                    { }
                }
            }
        }
      
    }
}