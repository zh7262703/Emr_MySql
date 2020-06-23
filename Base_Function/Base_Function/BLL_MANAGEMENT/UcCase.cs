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
    public partial class UcCase : UserControl
    {
        //DataTable dt = null;
        private bool isvisable = false;
        private string SQL = string.Empty;

        private string old_Name = string.Empty;
        private string new_Name = string.Empty;
        DataSet ds = new DataSet();
        string[] Cols =null;
        public UcCase()
        {
            InitializeComponent();
        }
        public UcCase(string sql)
        {
            InitializeComponent();
            try
            {
                //DataInit(sql);
                //DataSection();
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        public UcCase(string sql,bool isVisable,string old_name,string new_name)
        {
            InitializeComponent();
            try
            {
                this.pnlState.Visible = isVisable;
                DataInit(sql,old_name,new_name);
                DataSection();
                this.isvisable = isVisable;
                this.SQL = sql;
                this.old_Name = old_name;
                this.new_Name = new_name;
            }
            catch (Exception)
            {

                //throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isVisable"></param>
        /// <param name="columns">要隐藏的列</param>
        public UcCase(string sql, bool isVisable, string old_name, string new_name, string[] columns)
        {
            InitializeComponent();
            try
            {
                this.pnlState.Visible = isVisable;
                DataInit(sql,old_name,new_name,columns);
                DataSection();
                this.isvisable = isVisable;
                this.SQL = sql;
                this.Cols = columns;
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void DataInit(string sql,string old_name,string new_name)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                this.flgList.DataBd(sql, "姓名", old_name, new_name);
                
            }
        }
        private void DataInit(string sql, string old_name, string new_name,string[] columns)
        {
            try
            {
                if (!string.IsNullOrEmpty(sql))
                {
                    ds = App.GetDataSet(sql);
                    this.flgList.DataBd(sql, "姓名",true, old_name, new_name);
                    foreach (string col in columns)
                    {
                        this.flgList.fg.Columns[col].Visible = false;
                    }
                    //计算年龄
                    //CountAgeByBirthday();

                }

            }
            catch (Exception ex)
            {
                //App.Msg("错误: 原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        private void CountAgeByBirthday()
        {
            //分页统计当数据行数超过200时不计算
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    string birthday = ds.Tables[0].Rows[i]["birthday"].ToString(); //生日
                    string in_time = ds.Tables[0].Rows[i]["入院时间"].ToString(); //生日
                    int year, month, day;
                    Base_Function.BASE_COMMON.DataInit.GetAgeByBirthday(Convert.ToDateTime(birthday), Convert.ToDateTime(in_time), out year, out month, out day);
                    string strTemp = "";
                    if (year > 0)
                    {
                        strTemp = year.ToString() + "岁";
                    }
                    else if (month > 0)
                    {
                        strTemp = month.ToString() + "月";
                    }
                    else
                    {
                        strTemp = day.ToString() + "天";
                    }
                    this.flgList.fg["年龄",i].Value = strTemp;
                }
            }
            catch (Exception ex)
            {
                //App.Msg("错误: 原因:" + ex.Message);
            }
        }
        private void DataSection()
        {
            string sql = "select distinct(ts.sid),ts.section_name from t_Section_Area tsa inner join t_Sectioninfo ts on tsa.sid=ts.sid order by section_name";
            DataSet ds = App.GetDataSet(sql);
            DataTable dt_Section = ds.Tables[0];
            DataRow row = dt_Section.NewRow();
            row[0] = 0;
            row[1] = "请选择...";
            dt_Section.Rows.InsertAt(row, 0);
            this.cbxSection.DisplayMember = "section_name";
            this.cbxSection.ValueMember = "sid";
            this.cbxSection.DataSource = dt_Section;
            this.cbxSection.SelectedIndex = 0;
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string switchs = string.Empty;
            if (this.cbxSection.SelectedIndex != 0)
            {
                switchs = " where 科室='" + cbxSection.Text + "'";
            }
            if (this.chbTime.Checked)
            {
                if (!string.IsNullOrEmpty(switchs))
                {
                    switchs += " and" + " 入院时间 between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'";
                }
                else
                {
                    switchs = " where 入院时间 between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'";
                }
            }
            if (this.pnlState.Visible)
            {
                string str = rbtnInHospital.Checked ? "die_time is null" : "die_time is not null";
                if (!string.IsNullOrEmpty(switchs))
                {

                    switchs += " and "+str;
                }
                else
                {
                    switchs =" where " +str;
                }
            }
            if (!string.IsNullOrEmpty(switchs))
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append(SQL);
                strBuilder.Append(switchs);
                try
                {
                    if (Cols != null)
                    {
                        this.DataInit(strBuilder.ToString(), old_Name, new_Name, Cols);
                    }
                    else
                    {
                        this.DataInit(strBuilder.ToString(), old_Name, new_Name);
                    }
                }
                catch (Exception)
                {

                    //throw;
                }
            }
            else
            {
                if (Cols != null)
                {
                    this.DataInit(SQL, old_Name, new_Name, Cols);
                }
                else
                {
                    this.DataInit(SQL, old_Name, new_Name);
                }

            }
        }

        private void chbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbTime.Checked)
            {
                this.dtpStart.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpStart.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }
    }
}
