using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class frmHeartpicShow :DevComponents.DotNetBar.Office2007Form
    {
        private string SQl = "";
        private string data = "";//����
        private string time = "";//ʱ��
        private string value_val = "";//Ѫ��ֵ
        private string sign_name = "";//ִ����ǩ��
        private string bz = "";//��ע
        int  ID = -1;
        public frmHeartpicShow()
        {
            InitializeComponent();
        }
        public frmHeartpicShow(string data, string time, string value_val, string sign_name, string bz)
        {
            InitializeComponent();
            this.data = data;
            this.time = time;
            this.value_val = value_val;
            this.sign_name = sign_name;
            this.bz = bz;
            string sql="";
            if (bz == "")
            {
                sql = "select t.id from t_heart_pic t where to_char(t.record_time,'yyyy-mm-dd')='" + data + "' and to_char(t.record_time,'HH24:mi')='" + time + "' and t.sing_name='" + sign_name + "' and t.heart_val='" + value_val + "' and t.bz is null";// and t.bz='" + bz + "'
            }
            else
            {
                sql = "select t.id from t_heart_pic t where to_char(t.record_time,'yyyy-mm-dd')='" + data + "' and to_char(t.record_time,'HH24:mi')='" + time + "' and t.sing_name='" + sign_name + "' and t.heart_val='" + value_val + "'and t.bz='" + bz + "'";// 
            }
            ID=Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0]["id"].ToString());
            SQl = "select t.id as ���,to_char(t.record_time,'yyyy-MM-dd hh24:mi') as ʱ��,t.heart_val as Ѫ�Ǽ��ֵ,t.bz as ��ע from t_heart_pic t where t.id='" + ID + "'";
        }
        //string date;
        //public frmBgrecord(string Date)
        //{
        //    InitializeComponent();
        //    this.date = Date;
        //    SQl="select t.ID as ���,to_char(t.record_time,'yyyy-MM-dd hh24:mi') as ʱ��,t.item_kind as Ѫ�Ǽ�ⵥ���,"+
        //        @"name as Ѫ�Ǽ������,t.item_value as Ѫ�Ǽ��ֵ,t.record_name as ǩ�� from T_PERIPHERY_BG_RECORD t " +
        //        @"inner join t_data_code s on s.id=t.item_kind where t.record_time=to_timestamp('"+ date + "','syyyy-mm-dd hh24:mi:ss.ff9')";
        //}
        /// <summary>
        /// Load ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHeartpicShow_Load(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                flgView.DataSource = ds.Tables[0].DefaultView;
                //flgView.Cols["���"].Visible = false;
                //flgView.Cols["Ѫ�Ǽ�ⵥ���"].Visible = false;
                //flgView.Cols[0].AllowEditing = false;
                //flgView.Cols[1].AllowEditing = false;
                //flgView.Cols[2].AllowEditing = false;
                //flgView.Cols[3].AllowEditing = false; 
                txtName.Text = ID.ToString();
                txtName.Enabled = false;
                txtValue.Text = value_val;
                dtpTime.Value = Convert.ToDateTime(data + " " + time);
                txtBZ.Text = bz;

             
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
             if (txtName.Text.Trim() != "")
            {
                try
                {
                    int value=Convert.ToInt32(txtName.Text.Trim());
                }
                catch
                {
                    {
                        App.Msg("��Ŀ���ֵֻ��������ֵ����");
                        txtValue.Focus();
                        txtValue.Clear();
                        return;
                    }

                }
                string Sql = "update t_heart_pic set heart_val='" + txtValue.Text + "',record_time=to_timestamp('" + dtpTime.Value.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9'),sing_name='" + App.UserAccount.UserInfo.User_name + "',bz='" + txtBZ.Text + "' where id='" + ID + "'";
                int count=App.ExecuteSQL(Sql);
                if (count > 0)
                {
                    App.Msg("�޸��ѳɹ���");
                    frmHeartpicShow_Load(sender, e);
                    this.Close();

                }
            }
        }


        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void flgView_Click(object sender, EventArgs e)
        {
            //if (flgView.Rows.Count > 1)
            //{
            //    txtName.Text = flgView[flgView.RowSel, "���"].ToString();
            //    txtValue.Text = flgView[flgView.RowSel, "�ĵ�ʾ��ֵ"].ToString();
            //    dtpTime.Value = Convert.ToDateTime(flgView[flgView.RowSel, "ʱ��"].ToString());
            //    txtBZ.Text = flgView[flgView.RowSel, "��ע"].ToString();
            //}
            //this.Close();
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (App.Ask("��ȷ��Ҫɾ����"))
            {
                string sql = "delete from  t_heart_pic  where  ID=" + ID + "";
                int count = App.ExecuteSQL(sql);
                if (count > 0)
                {
                    frmHeartpicShow_Load(sender, e);
                    App.Msg("ɾ���ɹ�");
                    this.Close();
                }
            }
        }

        private void btb_Del_Click(object sender, EventArgs e)
        {
            if (App.Ask("��ȷ��Ҫɾ����"))
            {
                string sql = "delete from  t_heart_pic  where  ID=" + ID + "";
                int count = App.ExecuteSQL(sql);
                if (count > 0)
                {
                    frmHeartpicShow_Load(sender, e);
                    App.Msg("ɾ���ɹ�");
                    this.Close();
                }
            }
        }

    }
}