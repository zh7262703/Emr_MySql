using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucLisTimeSpanQuerry : UserControl
    {
        public ucLisTimeSpanQuerry()
        {
            InitializeComponent();
        }

        private void ucLisTimeSpanQuerry_Load(object sender, EventArgs e)
        {
            try
            {
                string sql_lisList = "select * from t_lis_item t where t.item_type='��Ҫ'";
                string lis_name = "";
                DataSet ds = App.GetDataSet(sql_lisList);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lis_name = ds.Tables[0].Rows[i]["item_name"].ToString();
                        checkedListBox_Left.Items.Add(lis_name);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //private string GetjgbzString(string jgbz)
        //{
        //    if (radioButton1.Checked == true)
        //    {
        //        jgbz = "'H'";
        //    }
        //    else if (radioButton2.Checked == true)
        //    {
        //        jgbz = "'L'";
        //    }
        //    else if (radioButton3.Checked == true)
        //    {
        //        jgbz = "'����'";
        //    }
        //    else if (radioButton4.Checked == true)
        //    {
        //        jgbz = "'H','L','����'";
        //    }
        //    return jgbz;
        //}
        //�����Ŀ
        private void buttonX_Lis_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Length == 0)
            {
                checkedListBox_Left.Items.Clear();
                checkedListBox_Right.Items.Clear();
                string sql_lisList = "select * from t_lis_item t where t.item_type='��Ҫ'";
                string lis_name = "";
                DataSet ds = App.GetDataSet(sql_lisList);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lis_name = ds.Tables[0].Rows[i]["item_name"].ToString();
                        checkedListBox_Left.Items.Add(lis_name);
                    }
                }
            }
            else
            {
                checkedListBox_Left.Items.Clear();
                checkedListBox_Right.Items.Clear();
                string sql_lisList = "select * from t_lis_item t where t.item_type='��Ҫ'and t.item_name like '%" + textBox1.Text.ToString() + "%'";
                string lis_name = "";
                DataSet ds = App.GetDataSet(sql_lisList);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        lis_name = ds.Tables[0].Rows[i]["item_name"].ToString();
                        checkedListBox_Left.Items.Add(lis_name);
                    }
                }
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX_LeftToRights_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_Left.CheckedItems.Count; i++)
            {
                checkedListBox_Right.Items.Add(checkedListBox_Left.CheckedItems[i].ToString());
            }
            for (int j = checkedListBox_Left.CheckedItems.Count; j > 0; j--)
            {
                checkedListBox_Left.Items.Remove(checkedListBox_Left.CheckedItems[j - 1].ToString());
            }
        }
        /// <summary>
        /// �׸�ѡ�е�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX_LeftToRight_Click(object sender, EventArgs e)
        {
            if (checkedListBox_Left.CheckedItems.Count >= 1)
            {
                checkedListBox_Right.Items.Add(checkedListBox_Left.CheckedItems[0].ToString());
                checkedListBox_Left.Items.Remove(checkedListBox_Left.CheckedItems[0].ToString());
            }
        }
        /// <summary>
        /// �׸�ѡ�е�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX_RightToLeft_Click(object sender, EventArgs e)
        {
            if (checkedListBox_Right.CheckedItems.Count >= 1)
            {
                checkedListBox_Left.Items.Add(checkedListBox_Right.CheckedItems[0].ToString());
                checkedListBox_Right.Items.Remove(checkedListBox_Right.CheckedItems[0].ToString());
            }
        }
        /// <summary>
        /// ����ѡ�е�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX_RightToLefts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_Right.CheckedItems.Count; i++)
            {
                checkedListBox_Left.Items.Add(checkedListBox_Right.CheckedItems[i].ToString());
            }
            for (int j = checkedListBox_Right.CheckedItems.Count; j > 0; j--)
            {
                checkedListBox_Right.Items.Remove(checkedListBox_Right.CheckedItems[j - 1].ToString());
            }
        }
        //��ѯ
        private void buttonX_LisQuery_Click(object sender, EventArgs e)
        {
            string jgbz = "";
            string sql = "";
            //jgbz = GetjgbzString(jgbz);
            DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text).AddHours(23).AddMinutes(59).AddSeconds(59);
            int jcmc = checkedListBox_Right.Items.Count;

            string xmmc = "";

            for (int i = 0; i < jcmc; i++)
            {
                if (xmmc == "")
                {
                    xmmc = "'" + checkedListBox_Right.Items[i].ToString() + "'";
                }
                else
                {
                    xmmc += ",'" + checkedListBox_Right.Items[i].ToString()+"'";
                }
                
            }
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    jgbz = "H";
                }
                else
                {
                    jgbz = "L";
                }
                sql = "select distinct bb.mzh סԺ��,cc.sick_bed_no ����,cc.patient_name  ����,case when cc.gender_code='0' then '��' when cc.gender_code='1' then 'Ů' end �Ա�,cc.age ����,cc.sick_doctor_name �ܴ�ҽ��,cc.in_time ��Ժʱ��  from t_lis_result t  inner join t_lis_sample bb on t.bblsh=bb.bblsh inner join t_in_patient cc on bb.mzh=cc.pid  where t.xmmc in (" + xmmc + ") and t.jgbz='" + jgbz + "' and to_date(t.cssj,'yyyy-MM-dd hh24:mi:ss') between to_date('" + dt1.ToString() + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + dt2.ToString() + "','yyyy-MM-dd hh24:mi:ss')";
            }
            else if (radioButton3.Checked == true)
            {
                jgbz = "����";
                sql = "select distinct bb.mzh סԺ��,cc.sick_bed_no ����,cc.patient_name  ����,case when cc.gender_code='0' then '��' when cc.gender_code='1' then 'Ů' end �Ա�,cc.age ����,cc.sick_doctor_name �ܴ�ҽ��,cc.in_time ��Ժʱ��  from t_lis_result t  inner join t_lis_sample bb on t.bblsh=bb.bblsh inner join t_in_patient cc on bb.mzh=cc.pid  where t.xmmc in (" + xmmc + ") and t.xmjg='" + jgbz + "' and to_date(t.cssj,'yyyy-MM-dd hh24:mi:ss') between to_date('" + dt1.ToString() + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + dt2.ToString() + "','yyyy-MM-dd hh24:mi:ss')";
            }
            else if (radioButton4.Checked == true)
            {
                //xmjg
                jgbz = "����";
                sql = "select distinct bb.mzh סԺ��,cc.sick_bed_no ����,cc.patient_name  ����,case when cc.gender_code='0' then '��' when cc.gender_code='1' then 'Ů' end �Ա�,cc.age ����,cc.sick_doctor_name �ܴ�ҽ��,cc.in_time ��Ժʱ��  from t_lis_result t  inner join t_lis_sample bb on t.bblsh=bb.bblsh inner join t_in_patient cc on bb.mzh=cc.pid  where t.xmmc in (" + xmmc + ")  and (t.jgbz is not null or t.xmjg='" + jgbz + "')and to_date(t.cssj,'yyyy-MM-dd hh24:mi:ss') between to_date('" + dt1.ToString() + "','yyyy-MM-dd hh24:mi:ss') and to_date('" + dt2.ToString() + "','yyyy-MM-dd hh24:mi:ss')";
            }
            if (sql != "")
            {
                frmLis_Query frmlis = new frmLis_Query(sql);
                frmlis.StartPosition = FormStartPosition.CenterParent;
                frmlis.ShowDialog();
            }
        }
        public void ClickGrid(object sender, EventArgs e)
        {

        }
    }
}
