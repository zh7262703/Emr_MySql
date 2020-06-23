using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class ucFeeClassSet : UserControl
    {
        private string CurrentBigFee = "";  //��ǰ�ķ��ô���
        private string bigno = "";          //��׼����

        public ucFeeClassSet()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// ���ô����ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            lvBigFeeClass.Items.Clear();
            DataSet ds=App.GetDataSet("select * from t_data_code where type=210 and name like '%"+txtConditions.Text+"%'");                        
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                ListViewItem tempitem=new ListViewItem();
                tempitem.Name=ds.Tables[0].Rows[i]["CODE"].ToString();
                tempitem.Text=ds.Tables[0].Rows[i]["NAME"].ToString();
                tempitem.Tag = ds.Tables[0].Rows[i];
                lvBigFeeClass.Items.Add(tempitem);
            }

            
        }

        /// <summary>
        /// ����С���ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_B_Click(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet("select * from t_data_code where type=209 and BZDM is null and name like '%"+txtConditions_B.Text+"%'");
            lvSmallFeeClass.Items.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListViewItem tempitem = new ListViewItem();
                tempitem.Name = ds.Tables[0].Rows[i]["CODE"].ToString();
                tempitem.Text = ds.Tables[0].Rows[i]["NAME"].ToString();
                tempitem.Tag = ds.Tables[0].Rows[i];
                lvSmallFeeClass.Items.Add(tempitem);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CurrentBigFee != "")
            {
                if (App.Ask("ȷ��Ҫɾ�����й�ϵ��"))
                {
                    try
                    {
                        for (int i = 0; i < lvRelation.Items.Count; i++)
                        {
                            DataRow temptr = (DataRow)lvRelation.Items[i].Tag;
                            ListViewItem templv = new ListViewItem();
                            templv.Text = temptr["NAME"].ToString();
                            templv.Name = temptr["CODE"].ToString();
                            templv.Tag = temptr;
                            lvSmallFeeClass.Items.Add(templv);
                        }
                        lvRelation.Items.Clear();
                        string sql = "Update t_data_code set BZDM=null where SUBSTR(BZDM,0,2)='" + bigno + "' and type=209";
                        if (App.ExecuteSQL(sql) > 0)
                        {
                            App.Msg("�����ɹ���");
                        }
                        else
                        {
                            App.MsgErr("����ʧ�ܣ�");
                        }                        
                    }
                    catch(Exception ex)
                    {
                        App.MsgErr("����ʧ�ܣ�ԭ��"+ex.Message);
                    }
                }
            }
        }

        
        private void lvBigFeeClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentBigFee=lvBigFeeClass.SelectedItems[0].Name;
                bigno=CurrentBigFee;
                if(bigno.Length<2)
                {
                    bigno="0"+bigno;
                }
                lblShowLb.Text = "��ǰ�������ô��ࣺ"+lvBigFeeClass.SelectedItems[0].Text;

                /*
                 * �����Ѿ�ƥ�����Ŀ
                 */
                lvRelation.Items.Clear();
                string Sql = "select * from t_data_code where type=209 and SUBSTR(BZDM,0,2)='" + bigno + "'";
                DataSet ds = App.GetDataSet(Sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListViewItem tempitem = new ListViewItem();
                    tempitem.Name = ds.Tables[0].Rows[i]["CODE"].ToString();
                    tempitem.Text = ds.Tables[0].Rows[i]["name"].ToString();
                    tempitem.Tag = ds.Tables[0].Rows[i];
                    lvRelation.Items.Add(tempitem);
                }
            }
            catch
            {}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSmallFeeClass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSmallFeeClass.SelectedItems != null)
            {
                bool flag = false;
                for (int i = 0; i < lvRelation.Items.Count; i++)
                {
                    DataRow tr1 = (DataRow)lvSmallFeeClass.SelectedItems[0].Tag;
                    DataRow tr2 = (DataRow)lvRelation.Items[i].Tag;
                    if (tr2["CODE"].ToString() == tr1["CODE"].ToString())
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    DataRow temptr = (DataRow)lvSmallFeeClass.SelectedItems[0].Tag;
                    ListViewItem templv = new ListViewItem();
                    templv.Text = temptr["NAME"].ToString();
                    templv.Name = temptr["CODE"].ToString();
                    templv.Tag = temptr;
                    lvRelation.Items.Add(templv);
                    lvSmallFeeClass.Items.Remove(lvSmallFeeClass.SelectedItems[0]);
                }
            }
        }

        /// <summary>
        /// �Ƴ���ϵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvRelation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRelation.SelectedItems != null)
            {
                bool flag = false;
                for (int i = 0; i < lvSmallFeeClass.Items.Count; i++)
                {
                    DataRow tr1 = (DataRow)lvSmallFeeClass.SelectedItems[0].Tag;
                    DataRow tr2 = (DataRow)lvRelation.Items[i].Tag;
                    if (lvSmallFeeClass.Items[i].Name == lvRelation.SelectedItems[0].Name)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {                   
                    DataRow temptr = (DataRow)lvRelation.SelectedItems[0].Tag;
                    ListViewItem templv = new ListViewItem();
                    templv.Text = temptr["NAME"].ToString();
                    templv.Name = temptr["CODE"].ToString();
                    templv.Tag = temptr;
                    lvSmallFeeClass.Items.Add(templv);
                    lvRelation.Items.Remove(lvRelation.SelectedItems[0]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
                for (int i = 0; i < lvRelation.Items.Count; i++)
                {                   
                    string bzbm=bigno+lvRelation.Items[i].Name;
                    DataRow tr = (DataRow)lvRelation.Items[i].Tag;
                    string sql = "update t_data_code set BZDM='" + bzbm + "' where id=" + tr["id"].ToString() + " and type=209";
                    sqls.Add(sql);
                }
                if (sqls.Count > 0)
                {
                    if (App.ExecuteBatch(sqls.ToArray()) > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                    }
                    else
                    {
                        App.MsgErr("����ʧ�ܣ�");
                    }
                }
                else
                {
                    App.MsgWaring("�������ù�ϵ��");
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("����ʧ�ܣ�ԭ��"+ex.Message);
            }
        }

        private void ucFeeClassSet_Load(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
            btnSelect_B_Click(sender, e);
        }

        
    }

    
}
