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
    public partial class ucLoan_Registration : UserControl
    {

        private string Hospital_sql;
        public ucLoan_Registration()
        {
            InitializeComponent();
            Hospital_sql = "select * from percuriam_case_history";
            App.UsControlStyle(this);
        }

        private void ucLoan_Registration_Load(object sender, EventArgs e)
        {
            try
            {
                State();
                chkHospital_CheckedChanged(sender, e);
                chkToHospital_CheckedChanged(sender, e);
                chkState_CheckedChanged(sender, e);
            }
            catch { }
        }
        
       //查询状态
        private void State()
        {
            DataSet ds = App.GetDataSet("select * from t_data_code where Type='44' order by ID asc");
            cboState.DataSource = ds.Tables[0].DefaultView;
            cboState.ValueMember = "ID";
            cboState.DisplayMember = "NAME";
        }
      


        /// <summary>
        /// 查找
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {


            try
            {
                string startTime = dtpStartTime.Value.ToString("yyyy-MM-dd");
                string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd");
                string HospitalstartTime = dtpHospitalStartTime.Value.ToString("yyyy-MM-dd");
                string HospitalendTime = dtpHospitalEndTime.Value.ToString("yyyy-MM-dd");

                string sql = Hospital_sql;

                #region   住院号不为空
                if (txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 病案号 like'%" + txtCode.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 病案号 like'%" + txtCode.Text.Trim() + "%' and 姓名 like'%" + txtName.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 病案号 like'%" + txtCode.Text.Trim() + "%' and 姓名 like'%" + txtName.Text.Trim() + "%' and  疾病分类代码 like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 病案号 like'%" + txtCode.Text.Trim() + "%' and 姓名 like'%" + txtName.Text.Trim() + "%' and  疾病分类代码 like'%" + txtICD10.Text.Trim() + "%' and  手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                #endregion

                #region  患者姓名不为空
                else if (txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 姓名 like'%" + txtName.Text.Trim() + "%'";

                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 姓名 like'%" + txtName.Text.Trim() + "%' and  疾病分类代码 like'%" + txtICD10.Text.Trim() + "%'";

                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 姓名 like'%" + txtName.Text.Trim() + "%' and  疾病分类代码 like'%" + txtICD10.Text.Trim() + "%' and  手术分类代码  like'%" + txtICD9.Text.Trim() + "%' ";

                }
                #endregion

                #region   入院日期不为空
                else if (chkHospital.Checked == true)
                {
                    if (startTime != "" && EndTime != "")
                    {
                        if (dtpEndTime.Value < dtpStartTime.Value)
                        {
                            App.Msg("入院结束日期不能小于入院起始日期！");
                            dtpEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where 入院日期 between '" + startTime + "' and '" + EndTime + "' order by  入院日期 asc";
                    }
                }
                else if (chkToHospital.Checked == true)
                {
                    if (HospitalstartTime != "" && HospitalendTime != "")
                    {
                        if (dtpHospitalEndTime.Value < dtpHospitalStartTime.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpHospitalEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where  出院日期  between '" + HospitalstartTime + "'   and  '" + HospitalendTime + "'  order by  入院日期 asc";
                    }
                }
                else if (chkHospital.Checked == true && chkToHospital.Checked == true)
                {
                    if (startTime != "" && EndTime != "" && HospitalstartTime != "" && HospitalendTime != "")
                    {
                        if (dtpEndTime.Value < dtpStartTime.Value)
                        {
                            App.Msg("入院结束日期不能小于入院起始日期！");
                            dtpEndTime.Focus();
                            return;
                        }
                        if (dtpHospitalEndTime.Value < dtpHospitalStartTime.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpHospitalEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where 入院日期 between '" + startTime + "' and  '" + EndTime + "'and  出院日期  between '" + HospitalstartTime + "'    and  '" + HospitalendTime + "'  order by  入院日期 asc ";

                    }
                }
                #endregion

                #region 疾病分类代码不为空
                else if (txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 疾病分类代码 like'%" + txtICD10.Text.Trim() + "%'";

                }
                else if (txtICD10.Text.Trim() != "" && txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 疾病分类代码 like'%" + txtICD10.Text.Trim() + "%' and  病案号 like'%" + txtCode.Text.Trim() + "%'";

                }
                else if (txtICD10.Text.Trim() != "" && txtCode.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 疾病分类代码 like'%" + txtICD10.Text.Trim() + "%' and  病案号 like'%" + txtCode.Text.Trim() + "%' and  手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";

                }
                #endregion

                #region    手术分类代码不为空
                else if (txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";

                }
                else if (txtICD9.Text.Trim() != "" && txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%' and  病案号 like'%" + txtCode.Text.Trim() + "%'";

                }
                else if (txtICD9.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%' and  姓名 like'%" + txtName.Text.Trim() + "%'";

                }
                #endregion

                //查询状态查询
                else if (chkState.Checked == true)
                {
                    if (cboState.Text.Trim() != null)
                    {

                    }
                }
                flgView.DataBd(sql, "编号", "", "");
                flgView.fg.Cols["手术分类代码"].Visible = false;
                flgView.fg.Cols["手术分类代码"].AllowEditing = false;
                flgView.fg.Cols["疾病分类代码"].Visible = false;
                flgView.fg.Cols["疾病分类代码"].AllowEditing = false;
                flgView.fg.Cols["编号"].Visible = false;
                flgView.fg.Cols["编号"].AllowEditing = false;
                flgView.fg.AllowEditing = false;
            }
            catch(Exception ee)
            {
            }         
        }
        /// <summary>
        /// 入院时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHospital_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHospital.Checked == true)
            {
                dtpStartTime.Enabled = true;
                lblHospital.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                lblHospital.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }
        /// <summary>
        /// 出院时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkToHospital_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToHospital.Checked == true)
            {
                dtpHospitalStartTime.Enabled = true;
                lblTohospital.Enabled = true;
                dtpHospitalEndTime.Enabled = true;
            }
            else
            {
                dtpHospitalStartTime.Enabled = false;
                lblTohospital.Enabled = false;
                dtpHospitalEndTime.Enabled = false;
            }
        }
        /// <summary>
        /// 查询状态控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            if (chkState.Checked == true)
            {
                cboState.Enabled = true;
            }
            else
            {
                cboState.Enabled = false;
            }
        }
    }
 
}
