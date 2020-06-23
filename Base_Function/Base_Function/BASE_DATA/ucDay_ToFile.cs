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
        /// 生成下拉菜单
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
        /// 转换中文星期几的函数
        /// </summary>
        /// <param name="date">日期时间</param>
        /// <returns></returns>
        public static string dateToChsWeek(System.DateTime date)
        {
            string week = date.DayOfWeek.ToString();
            switch (week)
            {
                case "Monday": return "星期一";
                case "Tuesday": return "星期二";
                case "Wednesday": return "星期三";
                case "Thursday": return "星期四";
                case "Friday": return "星期五";
                case "Saturday": return "星期六";
                default: return "星期日";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            refersh();
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int Month = 0;
            int Day = 0;
            DateTime dt = new DateTime();
            #region
            try //月份
            {
                Month = Convert.ToInt32(txt_AddMonth.Text.ToString());
                if (Month < 1 || Month > 12)
                {
                    App.MsgErr("您输入的月份不合理！请重新输入");
                    return;
                }
            }
            catch
            {
                App.MsgErr("您输入的月份不合理！请重新输入");
                return;

            }
            try //日期
            {
                Day = Convert.ToInt32(txt_AddDay.Text.ToString());
                if (Day < 1 || Day > 31)
                {
                    App.MsgErr("您输入的日不合理！请重新输入");
                    return;
                }
            }
            catch
            {
                App.MsgErr("您输入的日不合理！请重新输入");
                return;
            }
            try
            {
                dt = Convert.ToDateTime(cbb_Year.Text.ToString() + "-" + Month.ToString() + "-" + Day.ToString());
            }
            catch
            {
                App.MsgErr("您输入的日期不存在！请重新输入");
                return;

            }
            #endregion
            string sql_select = "select * from T_HOLIDAY_SET where year_val='" + Convert.ToInt32(cbb_Year.Text.ToString()) + "' and month_val='" + Month + "' and day_val='" + Day + "'";
            DataSet ds = App.GetDataSet(sql_select);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    App.Msg("此天已经是节假日");
                }
                else
                {
                    string Type = "节日";
                    string sql_insert = "insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + Month + "','" + Day + "','" + Type + "','" + Convert.ToInt32(cbb_Year.Text.ToString()) + "')";
                    App.ExecuteSQL(sql_insert);
                    App.Msg("设置成功！");
                    refersh();
                }
            }
        }
       
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            refersh();
        }
        // 刷新
        private void refersh()
        {
            try
            {
                /// 查询当年所有节假日
                string sql_Search = "select month_val 月,day_val 日,day_type 类型 from t_holiday_set where year_val='" + cbb_Year.Text.ToString() + "' order by month_val,day_val";
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
        // 保存
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

                    //节假日1.1-1.3 5.1-5.3 10.1-10.7
                    if (dt.Month.ToString() == "1" && (dt.Day.ToString() == "1" || dt.Day.ToString() == "2" || dt.Day.ToString() == "3"))
                    {
                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','节日','" + dt.Year.ToString() + "')");
                    }
                    else if (dt.Month.ToString() == "5" && (dt.Day.ToString() == "1" || dt.Day.ToString() == "2" || dt.Day.ToString() == "3"))
                    {

                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','节日','" + dt.Year.ToString() + "')");
                    }
                    else if (dt.Month.ToString() == "10" && (Convert.ToInt32(dt.Day.ToString()) < 8))
                    {
                        arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','节日','" + dt.Year.ToString() + "')");
                    }
                    else
                    {
                        string week = dateToChsWeek(dt);
                        //双休日
                        if (week == "星期六" || week == "星期日")
                        {
                            arr.Add("insert into T_HOLIDAY_SET (month_val,day_val,day_type,year_val) Values ('" + dt.Month.ToString() + "','" + dt.Day.ToString() + "','双休日','" + dt.Year.ToString() + "')");
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
                App.MsgErr("保存失败！");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "select month_val 月,day_val 日,day_type 类型 from t_holiday_set where year_val='" + cbb_Year.Text.ToString() + "'";
            DataSet ds = App.GetDataSet(sql);
            bool flag = false;  //插入节日前是否提示
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                if (App.Ask("今年的节日已保存，确定覆盖当前数据吗？"))
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvHoliday.CurrentRow != null)
            {
                if (App.Ask("确定要删除该节日吗？"))
                {
                    string year = cbb_Year.Text.ToString();
                    string month = dgvHoliday.CurrentRow.Cells["月"].Value.ToString();
                    string day = dgvHoliday.CurrentRow.Cells["日"].Value.ToString();
                    string sql_del = "delete from T_HOLIDAY_SET where year_val='" + year + "' and month_val='" + month + "' and day_val='" + day + "'";
                    int num = App.ExecuteSQL(sql_del);
                    if (num > 0)
                    {
                        App.Msg("删除成功！");
                        refersh();
                    } 
                }
            }
        }

        /// <summary>
        /// 只允许输入数字
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