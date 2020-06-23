using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucEmprstimo_Preferences : UserControl
    {
        private string ID = "";//病案借阅参数设置ID
        private string olddoudays = ""; //原归档时间
        
        public ucEmprstimo_Preferences()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        private void ucEmprstimo_Preferences_Load(object sender, EventArgs e)
        {
            try
            {
                Hospital_TimeUnit();
                Outside_Hospital_TimeUnit();
                cboHospital_TimeUnit.SelectedIndex = 0;
                cboOutside_Hospital_TimeUnit.SelectedIndex = 0;
                Time();
            }
            catch { }

        }
        /// <summary>
        /// 绑定院内借阅时间参数设置
        /// </summary>
        private void Hospital_TimeUnit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='43' order by ID asc");
            cboHospital_TimeUnit.DataSource = ds.Tables[0].DefaultView;
            cboHospital_TimeUnit.ValueMember = "ID";
            cboHospital_TimeUnit.DisplayMember = "NAME";
        }
        /// <summary>
        /// 绑定院外借阅时间参数设置
        /// </summary>
        private void Outside_Hospital_TimeUnit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='43' order by ID asc");
            cboOutside_Hospital_TimeUnit.DataSource = ds.Tables[0].DefaultView;
            cboOutside_Hospital_TimeUnit.ValueMember = "ID";
            cboOutside_Hospital_TimeUnit.DisplayMember = "NAME";
        }

        private void Time()
        {
            string sql = @"select a.ID,YUANNEI_BORROWTYPE,SET_DATETIME,DATETIME_YN,YUANWAI_BORROW,YUANWAI_DA,"+
                @"SET_YUANWAI_DATETIME,CRADTE_TIME,UPDATE_TIME,USERNAME,DOCUMENT_DAYS  from t_grade_param_shezhi a " +
                @"inner join t_data_code b on b.id=a.datetime_yn " +
                @"inner join t_data_code c on c.id=a.set_yuanwai_datetime";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    txtHospital_Markup.Text = ds.Tables[0].Rows[i]["YUANNEI_BORROWTYPE"].ToString();
                    txtHospital_Time.Text = ds.Tables[0].Rows[i]["SET_DATETIME"].ToString();
                    cboHospital_TimeUnit.SelectedValue = ds.Tables[0].Rows[i]["DATETIME_YN"].ToString();
                    txtOutside_Hospital_Markup.Text = ds.Tables[0].Rows[i]["YUANWAI_BORROW"].ToString();
                    txtOutside_Hospital_Time.Text = ds.Tables[0].Rows[i]["YUANWAI_DA"].ToString();
                    cboOutside_Hospital_TimeUnit.SelectedValue = ds.Tables[0].Rows[i]["SET_YUANWAI_DATETIME"].ToString();
                    txtDocumentDays.Text = ds.Tables[0].Rows[i]["DOCUMENT_DAYS"].ToString();                    
                    olddoudays = ds.Tables[0].Rows[i]["DOCUMENT_DAYS"].ToString();                    
                    if (txtDocumentDays.Text.Trim() == "")
                    {
                        txtDocumentDays.Text = "1";
                    }
                }
            }
   
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumentDays.Text.Trim() != "")
                {
                    if (Convert.ToInt16(txtDocumentDays.Text) < 1)
                    {
                        App.MsgErr("出院后归档天数必须大于等于1");
                        txtDocumentDays.Text = "1";
                        return;
                    }
                }
                else
                {
                    App.MsgErr("出院后归档天数必须大于等于1");
                    return;
                }
                string sql = "";
                ID = App.GenId("T_GRADE_PARAM_SHEZHI", "ID").ToString();
                string hospitalcount = App.ReadSqlVal("select Count(*) as cot from t_grade_param_shezhi", 0, "cot");
                if (hospitalcount == "0")
                {
                    sql = "insert into T_GRADE_PARAM_SHEZHI(ID,YUANNEI_BORROWTYPE,SET_DATETIME,DATETIME_YN,YUANWAI_BORROW,YUANWAI_DA,SET_YUANWAI_DATETIME,CRADTE_TIME,USERNAME,DOCUMENT_DAYS)  values("
                           + ID + ",'"
                           + txtHospital_Markup.Text + "','"
                           + txtHospital_Time.Text + "','"
                           + cboHospital_TimeUnit.SelectedValue + "','"
                           + txtOutside_Hospital_Markup.Text + "','"
                           + txtOutside_Hospital_Time.Text + "','"
                           + cboOutside_Hospital_TimeUnit.SelectedValue + "',sysdate,'" + App.UserAccount.Account_name + "','"+txtDocumentDays.Text+"')";
                }
                else
                {
                    sql = "update T_GRADE_PARAM_SHEZHI set YUANNEI_BORROWTYPE='"
                         + txtHospital_Markup.Text + "',SET_DATETIME='"
                         + txtHospital_Time.Text + "',DATETIME_YN='"
                         + cboHospital_TimeUnit.SelectedValue + "',YUANWAI_BORROW='"
                         + txtOutside_Hospital_Markup.Text + "',YUANWAI_DA='"
                         + txtOutside_Hospital_Time.Text + "',SET_YUANWAI_DATETIME='"
                         + cboHospital_TimeUnit.SelectedValue + "',UPDATE_TIME=sysdate,USERNAME='"
                         + App.UserAccount.Account_name + "',DOCUMENT_DAYS='"+txtDocumentDays.Text+"'";
                }
                if (sql != "")
                {

                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("参数设置操作成功！");
                    }
                    if(olddoudays!=txtDocumentDays.Text)
                    {
                        ReSetExeDocTime();
                    }
                    Time();
                }
            }
            catch (Exception ee)
            {
            }
        }

        /// <summary>
        /// 重新设置归档时间
        /// </summary>
        private void ReSetExeDocTime()
        {
            try
            {
                DataSet ds = App.GetDataSet("select id,t.die_time from t_in_patient t where t.die_time is not null and t.id in (select pid from t_inhospital_action)");
                int Days = Convert.ToInt16(txtDocumentDays.Text);
                List<string> Sqls = new List<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime exeTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["die_time"]).AddDays(Days);
                    string id = ds.Tables[0].Rows[i]["id"].ToString();
                    string sql = "update t_in_patient set EXE_DOCUMENT_TIME=to_timestamp('" + exeTime.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') where id=" + id + "";
                    Sqls.Add(sql);
                }
                if (App.ExecuteBatch(Sqls.ToArray()) <= 0)
                {
                    App.MsgErr("设置病人信息表的中的归档执行时间,不成功！");
                    return;
                }
            }
            catch
            {
                App.MsgErr("设置病人信息表的中的归档执行时间,不成功！");
                return;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Time();
        }

        private void txtHospital_Markup_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtHospital_Markup.Text.Trim() == "")
            {
                App.Msg("院内借阅时间设置标识不能为空！");
                txtHospital_Markup.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHospital_Time.Focus();
                }
            }
        }

        private void txtHospital_Time_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtHospital_Time.Text.Trim() == "")
            {
                App.Msg("院内借阅时间设置不能为空！");
                txtHospital_Time.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboHospital_TimeUnit.Focus();
                }
            }
        }

        private void txtHospital_TimeUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboHospital_TimeUnit.Text.Trim() == "")
            {
                App.Msg("院内借阅时间单位参数不能为空！");
                cboHospital_TimeUnit.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOutside_Hospital_Markup.Focus();
                }
            }
        }

        private void txtOutside_Hospital_Markup_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtOutside_Hospital_Markup.Text.Trim() == "")
            {
                App.Msg("院外借阅时间设置标识不能为空！");
                txtOutside_Hospital_Markup.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOutside_Hospital_Time.Focus();
                }
            }
        }

        private void txtOutside_Hospital_Time_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtOutside_Hospital_Time.Text.Trim() == "")
            {
                App.Msg("院外借阅时间设置不能为空！");
                txtOutside_Hospital_Time.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboOutside_Hospital_TimeUnit.Focus();
                }
            }
        }

        private void txtOutside_Hospital_TimeUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboOutside_Hospital_TimeUnit.Text.Trim() == "")
            {
                App.Msg("院外借阅时间设置不能为空！");
                cboOutside_Hospital_TimeUnit.Focus();
                return;
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(sender, e);
                }
            }
        }

        private void txtDocumentDays_TextChanged(object sender, EventArgs e)
        {          
        }

        private void txtDocumentDays_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void txtDocumentDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

    
    }
}
