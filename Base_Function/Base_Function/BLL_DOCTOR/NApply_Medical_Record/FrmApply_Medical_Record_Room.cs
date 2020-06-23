using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class FrmApply_Medical_Record_Room :DevComponents.DotNetBar.Office2007Form
    {
        private string Pid = "";//住院号
        private string Patient_id = "";//病人主键
        private string DataApplyTime = "";//申请时间
        private string Section_0r_Sick_ID = "";//科室或病区ID
        private string Section_0r_Sick_name = "";//科室或病区ID
        private string Applicant_id = "";//申请人ID
        private string Applicant_name = "";//申请人
        private string ApplyReason = "";//申请理由
        private string AppSick_or_Section = "";
        private string Approval = "";
        UcApply_Medical_Record_Room UCApply;
        public FrmApply_Medical_Record_Room()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="_ucApply">加载UcApply_Medical_Record_Room窗体</param>
        /// <param name="pid">住院号</param>
        /// <param name="patient_id">病人主键</param>
        /// <param name="dataapplytime">申请时间</param>
        /// <param name="section_0r_sick_id">科室或病区ID</param>
        /// <param name="section_0r_sick_name">科室或病区名称</param>
        /// <param name="applicant_id">申请人ID</param>
        /// <param name="applicant_name">申请人</param>
        /// <param name="applyreason">理由申请</param>
        /// <param name="applyreasonAppSick">是否显示科室或病区</param>
        /// <param name="approval">审批人</param>
        public FrmApply_Medical_Record_Room(UcApply_Medical_Record_Room _ucApply, string pid, string patient_id, string dataapplytime, string section_0r_sick_id, string section_0r_sick_name, string applicant_id, string applicant_name, string applyreason, string applyreasonAppSick, string approval)
        {
            
            InitializeComponent();
            UCApply = _ucApply;
            Pid = pid;
            Patient_id = patient_id;
            DataApplyTime = dataapplytime;
            Section_0r_Sick_ID = section_0r_sick_id;
            Section_0r_Sick_name = section_0r_sick_name;
            Applicant_id = applicant_id;
            Applicant_name = applicant_name;
            ApplyReason = applyreason;
            AppSick_or_Section = applyreasonAppSick;
            Approval = approval;
            
        }
        private void FrmApply_Medical_Record_Room_Load(object sender, EventArgs e)
        {
            try
            {
                txtPIDS.Text = Pid;
                txtApption.Text = Applicant_name;
                dtpApply.Text = DataApplyTime;
                txtApplyReason.Text = ApplyReason;
                txtSecton_or_Sick.Text = Section_0r_Sick_name;
                if (AppSick_or_Section == "科室")
                {
                    label2.Text = "科室：";
                }
                else
                {
                    label2.Text = "病区：";
                }
                cboState.SelectedIndex = 0;
                cboState.Focus();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboState.Text != "")
                {
                   
                    string sql = "";
                    if (cboState.Text == "通过")
                    {
                        string BFT = txtBORROW_FAILURE_TIME.Text;
                        DateTime dt = App.GetSystemTime();
                        if (BFT != "")
                        {
                            dt = dt.AddDays(double.Parse(BFT));
                        }
                        //ArrayList Sqls = new ArrayList();
                        //string bedid = "";
                        //int id = App.GenId("t_inhospital_action", "id");
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='1',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='1',state='{0}',approval='{1}',BORROW_FAILURE_TIME=to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss') " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,dt, Patient_id, DataApplyTime, Applicant_id);
                       try
                       {
                           int i=App.ExecuteSQL(sql);
                           if (i != 0)
                           {
                               App.Msg("审核状态修改成功");
                               UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                           }
                           else
                           {
                               App.Msg("审核状态修改失败");
                           }
                       }
                       catch (Exception ex)
                       {
                           App.Msg("退回失败！原因：" + ex.Message);
                       }
                     
                    }
                    if(cboState.Text == "未通过")
                    {
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='2',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='2',state='{0}',approval='{1}',BORROW_FAILURE_TIME='{2}' " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,"", Patient_id, DataApplyTime, Applicant_id);
                        int i = App.ExecuteSQL(sql);
                        if (i != 0)
                        {
                            App.Msg("审核状态修改成功");
                            UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                        }
                        else
                        {
                            App.Msg("审核状态修改失败");
                        }
                    }
                    if (cboState.Text == "审核中")
                    {
                        //sql = "update T_BORROW_REQ_RECORD set STATE_ID='0',state='" + cboState.Text + "',approval='" + Approval + "' where PATIENT_ID='" + Patient_id + "'";
                        sql = "update T_BORROW_REQ_RECORD set STATE_ID='0',state='{0}',approval='{1}',BORROW_FAILURE_TIME='{2}' " +
                            " where PATIENT_ID='{3}'  and REQ_BY_TIME=to_timestamp('{4}','syyyy-mm-dd hh24:mi:ss') and REQ_BY='{5}'";
                        sql = string.Format(sql, cboState.Text, Approval,"", Patient_id, DataApplyTime, Applicant_id);
                        int i = App.ExecuteSQL(sql);
                        if (i != 0)
                        {
                            App.Msg("审核状态修改成功");
                            UCApply.UcApply_Medical_Record_Room_Load(sender, e);
                        }
                        else
                        {
                            App.Msg("审核状态修改失败");
                        }
                    }
                   
                }
            }
            catch
            {
               
            }
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboState.SelectedIndex.ToString() == "0")
            //{
            //    txtBORROW_FAILURE_TIME.Enabled = false;
            //    txtBORROW_FAILURE_TIME.Text = "";
            //}
            //else 
            if (cboState.SelectedIndex.ToString() == "0")
            {
                txtBORROW_FAILURE_TIME.Enabled = true;
            }
            else if (cboState.SelectedIndex.ToString() == "1")
            {
                txtBORROW_FAILURE_TIME.Enabled = false;
                txtBORROW_FAILURE_TIME.Text = "";
            }
        }
   
    }
}