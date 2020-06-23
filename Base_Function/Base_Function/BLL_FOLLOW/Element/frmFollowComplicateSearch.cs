using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW.Element
{

    public partial class frmFollowComplicateSearch : DevComponents.DotNetBar.Office2007Form
    {
        private string Diag = "";
        private string Oper = "";
        private string SchemaId = "";
        private string Doctor = "";
        private string Visitor = "";



        public frmFollowComplicateSearch(string schemaID)
        {
            InitializeComponent();
            SchemaId = schemaID;
            txtState.ReadOnly = true;
            IniSection();
        }
        /// <summary>
        /// 绑定科室列表
        /// </summary>
        public void IniSection()
        {
            string secSql = "select a.sid,a.section_name from T_SECTIONINFO a  where a.is_follow_visit='Y'";
            DataSet secTemp = App.GetDataSet(secSql);
            DataRow newRow = secTemp.Tables[0].NewRow();
            newRow[0] = "0";
            newRow[1] = "";
            secTemp.Tables[0].Rows.InsertAt(newRow, 0);
            cmbSection.DataSource = secTemp.Tables[0].DefaultView;
            cmbSection.DisplayMember = "section_name";
            cmbSection.ValueMember = "sid";
            cmbSection.SelectedIndex = 0;
        }

        private void rtnSelectState_Click(object sender, EventArgs e)
        {
            if (txtState.Tag != null && txtState.Tag.ToString() != "")
            {
                frmState st = new frmState((string)txtState.Tag);
                st.ShowDialog();
                txtState.Text = st.StateDes;
                txtState.Tag = st.StateIds;
            }
            else
            {
                frmState st = new frmState("");
                st.ShowDialog();
                txtState.Text = st.StateDes;
                txtState.Tag = st.StateIds;
            }
        }

        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDoctor.Text = row["医生"].ToString(); //textName;
                            Doctor = row["医生号"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Doctor = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id 医生号,user_name 医生 from T_USERINFO"
                                                + " where shortcut_code like '%" + txtDoctor.Text.Trim().ToUpper() + "%' or user_name like '%" + txtDoctor.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "医生", "医生");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            IniControls();
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        public void IniControls()
        {
            txtState.Text = "";
            txtState.Tag = null;

            txtHospital.Text = "";

            txtDoctor.Text = "";

            txtPatientName.Text="";

            txtVisitor.Text = "";

            ucICD10.disposeElement();
            ucICD9.disposeElement();

            ckBoxActual.Checked = false;
            dtActualTimeS.Value=DateTime.Today;
            dtActualTimeE.Value = DateTime.Today;
            
            ckBoxNext.Checked = false;
            dtNextTimeS.Value = DateTime.Today; ;
            dtNextTimeE.Value = DateTime.Today; ;

            ckBoxOutOfDate.Checked = false;
            dtOutOfDateTimeS.Value = DateTime.Today;
            dtOutOfDateTimeE.Value = DateTime.Today;

            ckBoxLeave.Checked = false;
            dtLeaveTimeS.Value = DateTime.Today;
            dtLeaveTimeE.Value = DateTime.Today;

            ckBoxLatest.Checked = false;

            rbtnOutOfDate.Checked = true;
        }
        /// <summary>
        /// 字符转换格式
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string NumToStr(string source)
        {
            if(source.IndexOf(",")!=-1)
            {
                string[] Item=source.Split(',');
                string Des="";
                foreach(string Str in Item)
                {
                    if(Des=="")
                        Des="'"+Str+"'";
                    else
                        Des+=",'"+Str+"'";
                }
                return Des;
            }
            else
                return source;
        }
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string FilterStr = "";
            string Qury="select patient_id from T_FOLLOW_RECORD where solution_id="+SchemaId+" ";
            if (ckBoxLatest.Checked)
            {
                if (txtState.Tag != null && txtState.Tag.ToString() != "")
                    Qury += "and state_id in (" + NumToStr(txtState.Tag.ToString()) + ") ";
                if (txtVisitor.Text != "")
                    Qury += "and creator_id=" + Visitor + " ";
                if (ckBoxActual.Checked)
                    Qury += "and actual_time between to_date('" + dtActualTimeS.Value.ToShortDateString() + "','yyyy-MM-dd') and to_date('" + dtActualTimeE.Value.ToShortDateString() + "','yyyy-MM-dd') ";
            }
            else
            {
                if (txtState.Tag != null && txtState.Tag.ToString() != "")
                    Qury += "and id in (select record_id from T_FOLLOW_DOC_ATTACH where state_id in (" + NumToStr(txtState.Tag.ToString()) + ") ) ";
                if (txtVisitor.Text != "")
                    Qury += "and id in (select record_id from T_FOLLOW_DOC_ATTACH where creator_id =" + Visitor + ") ";
                if (ckBoxActual.Checked)
                    Qury += "and id in (select record_id from T_FOLLOW_DOC_ATTACH where finish_time between to_date('','yyyy-MM-dd') and to_date('','yyyy-MM-dd')) ";
            }
            if (rbtnOutOfDate.Checked)
            {
                if (ckBoxOutOfDate.Checked)
                    Qury += "and requested_time between to_date('" + dtOutOfDateTimeS.Value.ToShortDateString() + "','yyyy-MM-dd') and to_date('" + dtOutOfDateTimeE.Value.ToShortDateString() + "','yyyy-MM-dd') and isfinished=0 ";
            }
            Qury += "intersect select id from T_IN_PATIENT where id is not null ";
            if (cmbSection.Text != "")
                Qury += "and section_id =" + cmbSection.SelectedValue.ToString() + " ";
            if (txtHospital.Text != "")
                Qury += "and pid like '%" + txtHospital.Text + "%' ";
            if (txtDoctor.Text != "")
                Qury += "and sick_doctor_id='" + Doctor + "' ";
            if (txtPatientName.Text != "")
                Qury += "and patient_name ='" + txtPatientName.Text.Trim() + "' ";
            if (ucICD10.GetIds() != "")
                Qury += "and id in (select patient_id from COVER_DIAGNOSE where icd10code in (" + NumToStr(ucICD10.GetIds()) + ")) ";
            if (ucICD9.GetIds() != "")
                Qury += "and id in (select patient_id from COVER_OPERATION where oper_code in (" + NumToStr(ucICD9.GetIds()) + ")) ";
            if (ckBoxLeave.Checked)
                Qury += "and leave_time between to_date('" + dtLeaveTimeS.Value.ToShortDateString() + "','yyyy-MM-dd') and to_date('" + dtLeaveTimeE.Value.ToShortDateString() + "','yyyy-MM-dd') ";
            DataSet dsTemp = App.GetDataSet(Qury);
            if(dsTemp.Tables[0].Rows.Count!=0)
                for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
                {
                    if (FilterStr == "")
                        FilterStr = "ID"+ dsTemp.Tables[0].Rows[i][0].ToString();
                    else
                        FilterStr += ","+dsTemp.Tables[0].Rows[i][0].ToString();
                }

            if (rbtnOutOfDate.Checked)
                FilterStr += ":OUTOFDATE:";
            else
                FilterStr += ":FINISH:";
            if (ckBoxNext.Checked)
                FilterStr += "NEXT" + dtNextTimeS.Value.ToShortDateString() + ":TO:" + dtNextTimeE.Value.ToShortDateString();
            this.Tag = FilterStr;
            this.Close();

        }

        private void btnICD10_Click(object sender, EventArgs e)
        {
            //初始化自定义控件宽度
            ucICD10.setWidth(ucICD10.Width);
            frmUser us = new frmUser("ICD10");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD10.createUser(element);
            }
        }

        private void btnICD9_Click(object sender, EventArgs e)
        {
            ucICD9.setWidth(ucICD9.Width);
            frmUser us = new frmUser("ICD9");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD9.createUser(element);
            }
        }

        private void txtVisitor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVisitor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtVisitor.Text = row["随访者"].ToString(); //textName;
                            Visitor = row["随访者ID"].ToString();
                            App.SelectObj = null;

                        }
                }
                else
                {
                    Visitor = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtVisitor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtVisitor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id 随访者ID,user_name 随访者 from T_USERINFO"
                                                + " where shortcut_code like '%" + txtVisitor.Text.Trim().ToUpper() + "%' or user_name like '%" + txtVisitor.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtVisitor, "随访者", "随访者");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }
    }
}