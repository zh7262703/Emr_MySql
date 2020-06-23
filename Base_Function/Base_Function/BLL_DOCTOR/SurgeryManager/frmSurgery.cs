using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.SurgeryManager
{
    public partial class frmSurgery : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatinet;
        public frmSurgery(InPatientInfo inPatientInfo)
        {
            InitializeComponent();
            this.inPatinet = inPatientInfo;
            flgSergeryList.DataSource = GetAllInfo();
            flgSergeryList.Cols["code_icd9"].Visible = false;
            flgSergeryList.Cols["id"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSurgery_Add frmS_Add = new frmSurgery_Add(inPatinet.PId);
            frmS_Add.ShowDialog();
        }

        public DataTable GetAllInfo()
        {
            /*
             *查找所有手术信息 
             */
            string Sql_All = "select operation_id 手术序号,desioper_names 手术名称,to_char(operation_date,'yyyy-MM-dd hh24:mi') 手术日期,operation_docname 手术医师," +
                             "applystate_doc 审批状态,code_icd9,id from t_operapproval_application";
            DataSet ds = App.GetDataSet(Sql_All);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        //删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Sql_Delete_Surgery = "delete t_operapproval_application where operation_id='"+flgSergeryList[flgSergeryList.RowSel,0]+"'";
            if (App.Ask("确定要删除吗？"))
            {
                int count = App.ExecuteSQL(Sql_Delete_Surgery);
                if (count > 0)
                {
                    App.Msg("删除成功！");
                }
                else
                {
                    App.Msg("删除失败！");
                }
            }
            
        }
        //申请审批
        private void 申请审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgSergeryList.RowSel > 0)
            {
                string code_icd9 = flgSergeryList[flgSergeryList.RowSel, "code_icd9"].ToString();
                string name = flgSergeryList[flgSergeryList.RowSel, "手术名称"].ToString();
                string id = flgSergeryList[flgSergeryList.RowSel, "id"].ToString();
                frmSurgery_Apply frmApply = new frmSurgery_Apply(code_icd9, name,id);
                frmApply.Show();
                //Form1 f = new Form1();
                //f.Show();
            }

        }

        private void frmSurgery_Load(object sender, EventArgs e)
        {

        }
    }
}