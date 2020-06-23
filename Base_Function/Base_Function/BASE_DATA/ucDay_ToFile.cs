using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using System.Collections;

namespace Base_Function.BASE_DATA
{
    public partial class ucDay_ToFile : UserControl
    {
        public ucDay_ToFile()
        {
            InitializeComponent();            
        }



        private void frmDay_ToFile_Load(object sender, EventArgs e)
        {
            cbb_ItemAdd();
            refersh();
        }
        /// <summary>
        /// ���������˵�
        /// </summary>
        private void cbb_ItemAdd()
        {
            //int year = 2011;
            for (int year = 2011; year < 2100; year++)
            {
                cbb_Year.Items.Add(year.ToString());
            }
            cbb_Year.SelectedIndex = 0;
        }
        /// <summary>
        /// ת���������ڼ��ĺ���
        /// </summary>
        /// <param name="date">����ʱ��</param>
        /// <returns></returns>
        public static string dateToChsWeek(System.DateTime date)
        {
            string week = date.DayOfWeek.ToString();
            switch (week)
            {
                case "Monday": return "����һ";
                case "Tuesday": return "���ڶ�";
                case "Wednesday": return "������";
                case "Thursday": return "������";
                case "Friday": return "������";
                case "Saturday": return "������";
                default: return "������";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            refersh();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int Month = 0;
            int Day = 0;
            DateTime dt = new DateTime();
            #region
            try //�·�
            {
                Month = Convert.ToInt32(txt_AddMonth.Text.ToString());
                if (Month < 1 || Month > 12)
                {
                    App.MsgErr("��������·ݲ���������������");
                    return;
                }
            }
            catch
            {
                App.MsgErr("��������·ݲ���������������");
                return;

            }
            try //����
            {
                Day = Convert.ToInt32(txt_AddDay.Text.ToString());
                if (Day < 1 || Day > 31)
                {
                    App.MsgErr("��������ղ���������������");
                    return;
                }
            }
            catch
            {
                App.MsgErr("��������ղ���������������");
                return;
            }
            try
            {
                dt = Convert.ToDateTime(cbb_Year.Text.ToString() + "-" + Month.ToString() + "-" + Day.ToString());
            }
            catch
            {
                App.MsgErr("����������ڲ����ڣ�����������");
                return;

            }
            #endregion
            string sql_select = "select * from T_HOLIDAY_SET where year_val='" + Convert.ToInt32(cbb_Year.Text.ToString()) + "' and month_val='" + Month + "' and day_val='" + Day + "'";
            DataSet ds = App.GetDataSet(sql_select);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    App.Msg("�����Ѿ��ǽڼ���");
                }
                else
                {
                    string Type = "����";
                    string sql_insert = "insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + Month + "','" + Day + "','" + Type + "','" + Convert.ToInt32(cbb_Year.Text.ToString()) + "')";
                    App.ExecuteSQL(sql_insert);
                    App.Msg("���óɹ���");
                    refersh();
                }
            }
        }
       
        /// <summary>
        /// ˢ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            refersh();
        }
        // ˢ��
        private void refersh()
        {
            try
            {
                /// ��ѯ�������нڼ���
                string sql_Search = "select month_val ��,day_val ��,day_type ���� from t_holiday_set where year_val='" + cbb_Year.Text.ToString() + "' order by month_val,day_val";
                DataSet ds = App.GetDataSet(sql_Search);
                if (ds != null)
                {
                    dgvHoliday.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {

            }
        }
        // ����
        private void save()
        {
            try
            {
                string Year = cbb_Year.Text.ToString();
                string sql_del = "DELETE from T_HOLIDAY_SET where year_val='" + Convert.ToInt32(Year) + "'";
                DateTime dt = Convert.ToDateTime(cbb_Year.Text.ToString() + "-01-01");
                ArrayList arr = new ArrayList();
                while (dt.Year.ToString() == cbb_Year.Text.ToString())
                {

                    //�ڼ���1.1-1.3 5.1-5.3 10.1-10.7
                    if (dt.Month.ToString() == "1" && (dt.Day.ToString() == "1" || dt.Day.ToString() == "2" || dt.Day.ToString() == "3"))
                    {
                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','����','" + dt.Year.ToString() + "')");
                    }
                    else if (dt.Month.ToString() == "5" && (dt.Day.ToString() == "1" || dt.Day.ToString() == "2" || dt.Day.ToString() == "3"))
                    {

                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','����','" + dt.Year.ToString() + "')");
                    }
                    else if (dt.Month.ToString() == "10" && (Convert.ToInt32(dt.Day.ToString()) < 8))
                    {
                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','����','" + dt.Year.ToString() + "')");
                    }
                    else
                    {
                        string week = dateToChsWeek(dt);
                        //˫����
                        if (week == "������" || week == "������")
                        {
                            arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','˫����','" + dt.Year.ToString() + "')");
                        }
                    }
                    dt = dt.AddDays(1);
                }
                string[] sqlarr = new string[arr.Count + 1];
                sqlarr[0] = sql_del;
                for (int i = 1; i < arr.Count + 1; i++)
                {
                    sqlarr[i] = arr[i - 1].ToString();
                }
                App.ExecuteBatch(sqlarr);
            }
            catch
            {
                App.MsgErr("����ʧ�ܣ�");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "select month_val ��,day_val ��,day_type ���� from t_holiday_set where year_val='" + cbb_Year.Text.ToString() + "'";
            DataSet ds = App.GetDataSet(sql);
            bool flag = false;  //�������ǰ�Ƿ���ʾ
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                if (App.Ask("����Ľ����ѱ��棬ȷ�����ǵ�ǰ������"))
                {
                    save();
                    refersh();
                }
            }
            else
            {
                save();
                refersh();
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvHoliday.CurrentRow != null)
            {
                if (App.Ask("ȷ��Ҫɾ���ý�����"))
                {
                    string year = cbb_Year.Text.ToString();
                    string month = dgvHoliday.CurrentRow.Cells["��"].Value.ToString();
                    string day = dgvHoliday.CurrentRow.Cells["��"].Value.ToString();
                    string sql_del = "delete from T_HOLIDAY_SET where year_val='" + year + "' and month_val='" + month + "' and day_val='" + day + "'";
                    int num = App.ExecuteSQL(sql_del);
                    if (num > 0)
                    {
                        App.Msg("ɾ���ɹ���");
                        refersh();
                    } 
                }
            }
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

    }
}