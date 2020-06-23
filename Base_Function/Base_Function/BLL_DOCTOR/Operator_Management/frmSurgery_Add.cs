using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmSurgery_Add : DevComponents.DotNetBar.Office2007Form
    {
        private string Pid = null;
        public frmSurgery_Add(string pid)
        {
            InitializeComponent();
            Pid = pid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //确认
        private void btnOK_Click(object sender, EventArgs e)
        {
            string ICD_9 = App.SelectObj.Select_Val;
            string Operation_Id = GetMaxOperationId();
            string Type = null;
            if (chboxType.Checked)
                Type = "特殊手术";
            int NewId=1;
            if (Operation_Id != null)
            {
                string Sub_Id = Operation_Id.Substring(6, Operation_Id.Length - 6);
                NewId += Convert.ToInt32(Sub_Id);
            }
            string Insert_Sql = " insert into t_operapproval_application (oper_type,operation_id,inpatient_id,desioper_names,code_icd9,create_date)" +
                                "values('" + Type + "','CS1000" + NewId + "','" + Pid + "','" + txtSurgery_Select.Text.Trim() + "','" + ICD_9 + "',sysdate)";
            int count = App.ExecuteSQL(Insert_Sql);
            if(count>0)
            {
                App.Msg("插入成功！");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql_select = "select code,name from oper_def_icd9 t where t.shortcut1 like '%"+txtSurgery_Select.Text.Trim()+"%'";
            App.FastCodeCheck(sql_select, txtSurgery_Select, "name", "code");
        }

        private string GetMaxOperationId()
        {
            string Select_Sql= "select operation_id from t_operapproval_application where id = (select max(id) from t_operapproval_application)";
            string MaxOperation_Id = App.ReadSqlVal(Select_Sql, 0, "operation_id");
            return MaxOperation_Id;
        }

        private void frmSurgery_Add_Load(object sender, EventArgs e)
        {

        }
    }
}