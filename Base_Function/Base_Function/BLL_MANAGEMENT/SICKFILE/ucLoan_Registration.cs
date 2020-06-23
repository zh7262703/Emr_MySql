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
        
       //��ѯ״̬
        private void State()
        {
            DataSet ds = App.GetDataSet("select * from t_data_code where Type='44' order by ID asc");
            cboState.DataSource = ds.Tables[0].DefaultView;
            cboState.ValueMember = "ID";
            cboState.DisplayMember = "NAME";
        }
      


        /// <summary>
        /// ����
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

                #region   סԺ�Ų�Ϊ��
                if (txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ������ like'%" + txtCode.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ������ like'%" + txtCode.Text.Trim() + "%' and ���� like'%" + txtName.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ������ like'%" + txtCode.Text.Trim() + "%' and ���� like'%" + txtName.Text.Trim() + "%' and  ����������� like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ������ like'%" + txtCode.Text.Trim() + "%' and ���� like'%" + txtName.Text.Trim() + "%' and  ����������� like'%" + txtICD10.Text.Trim() + "%' and  �����������  like'%" + txtICD9.Text.Trim() + "%'";
                }
                #endregion

                #region  ����������Ϊ��
                else if (txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ���� like'%" + txtName.Text.Trim() + "%'";

                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ���� like'%" + txtName.Text.Trim() + "%' and  ����������� like'%" + txtICD10.Text.Trim() + "%'";

                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ���� like'%" + txtName.Text.Trim() + "%' and  ����������� like'%" + txtICD10.Text.Trim() + "%' and  �����������  like'%" + txtICD9.Text.Trim() + "%' ";

                }
                #endregion

                #region   ��Ժ���ڲ�Ϊ��
                else if (chkHospital.Checked == true)
                {
                    if (startTime != "" && EndTime != "")
                    {
                        if (dtpEndTime.Value < dtpStartTime.Value)
                        {
                            App.Msg("��Ժ�������ڲ���С����Ժ��ʼ���ڣ�");
                            dtpEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where ��Ժ���� between '" + startTime + "' and '" + EndTime + "' order by  ��Ժ���� asc";
                    }
                }
                else if (chkToHospital.Checked == true)
                {
                    if (HospitalstartTime != "" && HospitalendTime != "")
                    {
                        if (dtpHospitalEndTime.Value < dtpHospitalStartTime.Value)
                        {
                            App.Msg("��Ժ�������ڲ���С�ڳ�Ժ��ʼ���ڣ�");
                            dtpHospitalEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where  ��Ժ����  between '" + HospitalstartTime + "'   and  '" + HospitalendTime + "'  order by  ��Ժ���� asc";
                    }
                }
                else if (chkHospital.Checked == true && chkToHospital.Checked == true)
                {
                    if (startTime != "" && EndTime != "" && HospitalstartTime != "" && HospitalendTime != "")
                    {
                        if (dtpEndTime.Value < dtpStartTime.Value)
                        {
                            App.Msg("��Ժ�������ڲ���С����Ժ��ʼ���ڣ�");
                            dtpEndTime.Focus();
                            return;
                        }
                        if (dtpHospitalEndTime.Value < dtpHospitalStartTime.Value)
                        {
                            App.Msg("��Ժ�������ڲ���С�ڳ�Ժ��ʼ���ڣ�");
                            dtpHospitalEndTime.Focus();
                            return;
                        }
                        sql = Hospital_sql + "  where ��Ժ���� between '" + startTime + "' and  '" + EndTime + "'and  ��Ժ����  between '" + HospitalstartTime + "'    and  '" + HospitalendTime + "'  order by  ��Ժ���� asc ";

                    }
                }
                #endregion

                #region ����������벻Ϊ��
                else if (txtICD10.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ����������� like'%" + txtICD10.Text.Trim() + "%'";

                }
                else if (txtICD10.Text.Trim() != "" && txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ����������� like'%" + txtICD10.Text.Trim() + "%' and  ������ like'%" + txtCode.Text.Trim() + "%'";

                }
                else if (txtICD10.Text.Trim() != "" && txtCode.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where ����������� like'%" + txtICD10.Text.Trim() + "%' and  ������ like'%" + txtCode.Text.Trim() + "%' and  �����������  like'%" + txtICD9.Text.Trim() + "%'";

                }
                #endregion

                #region    ����������벻Ϊ��
                else if (txtICD9.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where �����������  like'%" + txtICD9.Text.Trim() + "%'";

                }
                else if (txtICD9.Text.Trim() != "" && txtCode.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where �����������  like'%" + txtICD9.Text.Trim() + "%' and  ������ like'%" + txtCode.Text.Trim() + "%'";

                }
                else if (txtICD9.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Hospital_sql + "  where �����������  like'%" + txtICD9.Text.Trim() + "%' and  ���� like'%" + txtName.Text.Trim() + "%'";

                }
                #endregion

                //��ѯ״̬��ѯ
                else if (chkState.Checked == true)
                {
                    if (cboState.Text.Trim() != null)
                    {

                    }
                }
                flgView.DataBd(sql, "���", "", "");
                flgView.fg.Cols["�����������"].Visible = false;
                flgView.fg.Cols["�����������"].AllowEditing = false;
                flgView.fg.Cols["�����������"].Visible = false;
                flgView.fg.Cols["�����������"].AllowEditing = false;
                flgView.fg.Cols["���"].Visible = false;
                flgView.fg.Cols["���"].AllowEditing = false;
                flgView.fg.AllowEditing = false;
            }
            catch(Exception ee)
            {
            }         
        }
        /// <summary>
        /// ��Ժʱ�����
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
        /// ��Ժʱ�����
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
        /// ��ѯ״̬����
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
