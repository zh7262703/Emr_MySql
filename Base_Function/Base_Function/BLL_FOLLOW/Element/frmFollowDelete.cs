using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.DispalayList;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowDelete : DevComponents.DotNetBar.Office2007Form
    {
        private string Sid = "";
        private string Pid = "";
        Class_FollowInfo info;
        ucFollowTobeFinished parent1;
        ucFollowVisite parent2;
        public frmFollowDelete(string param1,Class_FollowInfo param2,ucFollowTobeFinished param3)
        {
            InitializeComponent();
            Sid = param2.Id;
            info = param2;
            Pid = param1;
            parent1 = param3;
            IniState();
        }
        public frmFollowDelete(string param1, Class_FollowInfo param2, ucFollowVisite param3)
        {
            InitializeComponent();
            Sid = param2.Id;
            info = param2;
            Pid = param1;
            parent2 = param3;
            IniState();
        }
        public void IniState()
        {
            string temp = "select * from T_FOLLOW_CANCEL_REASON";
            DataSet dsTemp = App.GetDataSet(temp);
            if(dsTemp!=null)
                if (dsTemp.Tables[0].Rows.Count != 0)
                {
                    cmbState.DataSource = dsTemp.Tables[0].DefaultView;
                    cmbState.DisplayMember = "des";
                    cmbState.ValueMember = "id";
                }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbState.Text != "")
            {
                
                string[] Sql = new string[2];
                DateTime now = dtPickTime.Value;
                string stateId = cmbState.SelectedValue.ToString();
                string Exist = "select * from T_FOLLOW_MANUALPATIENT where patient_id=" + Pid + " and solution_id=" + Sid + "";
                DataSet dsExist = App.GetDataSet(Exist);
                if (dsExist != null)
                    if (dsExist.Tables[0].Rows.Count != 0)
                    {
                        Sql[0] = "update T_FOLLOW_MANUALPATIENT set isadd=0,state_id=null,cancel_id="+stateId+",definefollows=null,update_time=to_date('"+now.ToShortDateString()+"','yyyy-MM-dd') where patient_id=" + Pid + " and solution_id=" + Sid + "";
                    }
                    else
                        Sql[0] = "insert into T_FOLLOW_MANUALPATIENT(patient_id,solution_id,isadd,cancel_id,update_time) values(" + Pid + "," + Sid + ",0," + stateId + ",to_date('"+now.ToShortDateString()+"','yyyy-MM-dd'))";
                Sql[1] = "update T_FOLLOW_RECORD t set cancel_id=" + stateId + " where patient_id=" + Pid + " and solution_id=" + Sid + " and not exists ( select 1 from T_FOLLOW_RECORD where t.patient_id=patient_id and solution_id=t.solution_id and t.requested_time<requested_time and isfinished=1) and isfinished=1";
                try
                {
                    App.ExecuteBatch(Sql);
                    if (parent1 == null)
                        parent2.DisplayPatients("");
                    else
                        parent1.DisplayPatients(info);
                    this.Close();

                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}