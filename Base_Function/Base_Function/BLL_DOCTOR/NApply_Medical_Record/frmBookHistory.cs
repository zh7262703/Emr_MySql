using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class frmBookHistory : DevComponents.DotNetBar.Office2007Form
    {
        public frmBookHistory()
        {
            InitializeComponent();
        }
        private string card_Id;
        private InPatientInfo inPatient;
        public frmBookHistory(InPatientInfo inpatient)
        {
            InitializeComponent();
            try
            {
                card_Id = inpatient.Card_Id;
                lblName.Text = inpatient.Patient_Name;
                if (inpatient.Gender_Code == "1" || inpatient.Gender_Code.Equals("女"))
                {
                    lblSex.Text = "女";
                }
                else
                {
                    lblSex.Text = "男";
                }
                lblBirthday.Text = inpatient.Birthday;
                lblAge.Text = inpatient.Age.ToString();
                if (inpatient.Marrige_State == "0")
                {
                    lblMarry.Text = "未婚";
                }
                else
                {
                    lblMarry.Text = "已婚";
                }
                lblCount.Text = inpatient.InHospital_count.ToString();
                lblType.Text = "社会基本医疗保险";
                lblNational.Text = "汉";
                BookHistoryList(inpatient.Card_Id, null);
                inPatient = inpatient;
                SecionList();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void chbPid_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPid.Checked)
            {
                txtPid.Enabled = true;
            }
            else
            {
                txtPid.Enabled = false;
                txtPid.Text = "";
            }
        }

        private void chbIn_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIn_Time.Checked)
            {
                dtpIn_Start.Enabled = true;
                dtpIn_End.Enabled = true;
            }
            else
            {
                dtpIn_Start.Enabled = false;
                dtpIn_End.Enabled = false;
            }
        }

        private void chbOut_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOut_Time.Checked)
            {
                dtpOut_End.Enabled = true;
                dtpOut_Start.Enabled = true;
            }
            else
            {
                dtpOut_End.Enabled = false;
                dtpOut_Start.Enabled = false;
            }
        }

        private void chbIn_Section_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIn_Section.Checked)
            {
                cbxIn_Section.Enabled = true;
            }
            else
            {
                cbxIn_Section.Enabled = false;
            }
        }

        private void chbOut_Section_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOut_Section.Checked)
            {
                cbxOut_Section.Enabled = true;
            }
            else
            {
                cbxOut_Section.Enabled = false;
            }
        }

        private void chbIn_Diagnose_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIn_Diagnose.Checked)
            {
                txtIn_Diagnose.Enabled = true;
            }
            else
            {
                txtIn_Diagnose.Enabled = false;
            }
        }

        private void chbOut_Diagnose_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOut_Diagnose.Checked)
            {
                txtOut_Diagnose.Enabled = true;
            }
            else
            {
                txtOut_Diagnose.Enabled = false;
            }
        }

        private void BookHistoryList(string card_Id,string swicth)
        {
            try
            {
                string sql = "select a.card_id 序号,a.pid 住院号, to_char(a.in_time,'yyyy-MM-dd HH24:mi') 入院时间,a.insection_name 入院科室," +
                            " (select c.diagnose_name from T_Diagnose_Item c where c.in_patient_id=a.id and c.diagnose_type='408') 入院诊断 ," +
                            " (select c.diagnose_name from T_Diagnose_Item c where c.in_patient_id=a.id and c.diagnose_type='406') 出院诊断 ," +
                            " (select c.turn_to from T_Diagnose_Item c where c.in_patient_id=a.id and c.diagnose_type='406') 出院转归 ," +
                            " to_char(a.die_time,'yyyy-MM-dd HH24:mi') 出院时间,a.section_name 出院科室,a.insection_id,a.section_id,a.patient_Id from t_in_patient a" +
                            " where a.card_id='"+card_Id+"'"+swicth;
                DataSet ds = App.GetDataSet(sql);
                DataTable dt = ds.Tables[0];
                DataColumn column = new DataColumn();
                column.DataType = typeof(String);
                column.ColumnName = "操作";
                column.DefaultValue = "查看";
                dt.Columns.Add(column);
                flgView.DataSource = dt.DefaultView;
                flgView.Cols["insection_id"].Visible = false;
                flgView.Cols["section_id"].Visible = false;
                flgView.AllowEditing = false;
            }
            catch (Exception ex)
            {
                
                
            }
        }

        private void flgView_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if(flgView.RowSel>0)
            {
                //if(flgView.Cols[flgView.ColSel].Name=="操作")
                //{
                //    frmBookTree frmbookTree = new frmBookTree();
                //    frmbookTree.ShowDialog();
                //}
            }
        }

        private void flgView_Click(object sender, EventArgs e)
        {
            if (flgView.RowSel > 0)
            {
                if (flgView.Cols[flgView.ColSel].Name == "操作")
                {
                    frmBookTree frmbookTree = new frmBookTree(flgView[flgView.RowSel,"住院号"].ToString(),inPatient);
                    frmbookTree.ShowDialog();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            //住院号
            if(chbPid.Checked)
            {
                string swicth = " and a.pid='"+txtPid.Text.Trim()+"'";
                strBuilder.Append(swicth);
            }
            //入院时间
            if(chbIn_Time.Checked)
            {
                string swicth = " and a.in_time begin to_timestamp('" + dtpIn_Start.Value + "','yyyy-MM-dd HH24:mi:ss') and to_timestamp('"+dtpIn_End.Value+"','yyyy-MM-dd HH24:mi:ss')";
                strBuilder.Append(swicth);
            }
            //出院时间
            if(chbOut_Time.Checked)
            {
                string swicth = " and a.die_time begin to_timestamp('" + dtpOut_Start.Value + "','yyyy-MM-dd HH24:mi:ss') and to_timestamp('" + dtpOut_End.Value + "','yyyy-MM-dd HH24:mi:ss') ";
                strBuilder.Append(swicth);
            }
            //入院科室
            if(chbIn_Section.Checked)
            {
                string swicth = " and a.insection_id = "+cbxIn_Section.SelectedValue+"";
                strBuilder.Append(swicth);
            }
            //出院科室
            if(chbOut_Section.Checked)
            {
                string swicth = " and a.section_id = " + cbxOut_Section.SelectedValue + "";
                strBuilder.Append(swicth);
            }
            BookHistoryList(card_Id,strBuilder.ToString());
        }

        private void SecionList()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            //入院科室
            cbxIn_Section.ValueMember = "sid";
            cbxIn_Section.DisplayMember = "section_name";
            cbxIn_Section.DataSource = ds.Tables[0].DefaultView;

            //出院科室
            cbxOut_Section.ValueMember = "sid";
            cbxOut_Section.DisplayMember = "section_name";
            cbxOut_Section.DataSource = ds.Tables[0].DefaultView;
        }

    }
}