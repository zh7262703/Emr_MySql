using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW
{
    /// <summary>
    /// 初始化t_follow_failedtimes表先给一个数据
    /// </summary>
    public partial class ucFollowFailedTimes : UserControl
    {
        private static string times=null;
        private static  int _flag=0; //标记是否首次进入系统
        public ucFollowFailedTimes()
        {
            InitializeComponent();
            InitialData();
        }
        private void InitialData()
        {
            
            DataSet ds = App.GetDataSet("select * from t_follow_failedtimes");
            times = ds.Tables[0].Rows[0]["times"].ToString();
            textBox1.Text = times;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            
            string sql;
            if (textBox1.Text == "")
            {
                App.Msg("输入不得为空");
                return;
            }
            sql = "update t_follow_failedtimes set times=" + Convert.ToInt32(textBox1.Text.Trim()) + " where times="+times+"";
            try
            {
                App.ExecuteSQL(sql);
                App.Msg("设置成功");
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
            if (e.KeyChar == 08)
                e.Handled = false;
        }
    }
}
