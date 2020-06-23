using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.SurgeryManager
{
    public partial class UcApproval : UserControl
    {
        public UcApproval()
        {
            InitializeComponent();
            tabControlApproval.TabIndex = 0;
            flgView.fg.DataSource = GetApprovalList();
            flgView.fg.Cols["code_icd9"].Visible = false;
            flgView.fg.Cols["apply_docid"].Visible = false;
            flgView.fg.Cols["id"].Visible = false;
        }
        //审批
        private void 审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApprovalEdit frmApproval = new frmApprovalEdit(flgView.fg[flgView.fg.RowSel,"id"].ToString());
            frmApproval.ShowDialog(this);
        }
        //获得审批列表
        private DataTable GetApprovalList()
        {
            string Sql_Approval_List = "select a.sick_bed_no 床号,a.patient_name 姓名,case a.gender_code when '1' then '女' else '男' end 性别," +
                                      " b.display 诊断码,b.desioper_names 手术名称,b.opery_date 手术日期,b.apply_date 申请日期," +
                                      " b.apply_docname 申请人,b.oper_type 手术类型,b.code_icd9,b.apply_docid,b.id from t_in_patient a" +
                                      " inner join t_operapproval_application b on a.pid = inpatient_id" +
                                      " inner join t_operationdoctor_approval c on b.id = c.oper_type" +
                                      " where approval_doctid ='"+App.UserAccount.UserInfo.User_id+"' and applystate_doc='未通过'";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_Approval_List);
            if(ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        //获取审批查看列表
        private DataTable GetLook_ApprovalList()
        {
            DataTable dt = null;
            string Sql_Approval_List = "select a.sick_bed_no 床号,a.patient_name 姓名,case a.gender_code when '1' then '女' else '男' end 性别," +
                                      " b.display 诊断码,b.desioper_names 手术名称,b.opery_date 手术日期,b.apply_date 申请日期," +
                                      " b.apply_docname 申请人,b.oper_type 手术类型,b.code_icd9,b.apply_docid,c.id from t_in_patient a" +
                                      " inner join t_operapproval_application b on a.pid = inpatient_id" +
                                      " inner join t_operationdoctor_approval c on b.id = c.oper_type";
            DataSet ds = App.GetDataSet(Sql_Approval_List);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        
        }

        private void tabControlApproval_TabIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            if(tabControlApproval.TabIndex==1&&i==0)   //只加载一次
            {
                flgView_Look.fg.DataSource = GetLook_ApprovalList();
                i++;
            }
        }
    }
}
