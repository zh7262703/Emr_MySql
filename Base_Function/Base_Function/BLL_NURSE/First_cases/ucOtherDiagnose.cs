using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;



namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class ucOtherDiagnose : UserControl
    {
        public ucOtherDiagnose()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ÆäËûÕï¶Ï
        /// </summary>
        public string OtherDiagnose
        {
            get { return this.txtOtherDiagnose.Text; }
            set { this.txtOtherDiagnose.Text = value; }
        }

        /// <summary>
        /// ¼²²¡±àÂëICD10
        /// </summary>
        public string ICD10
        {
            get { return this.txtICD10.Text; }
            set { this.txtICD10.Text = value; }
        }

        /// <summary>
        /// ÈëÔº²¡Çé
        /// </summary>
        public string InCondition
        {
            get { return this.cboInCondition.Text; }
            set
            {
                //if (value.Length == 0)
                //{
                //    this.cboInCondition.SelectedIndex = -1;
                //    cboInCondition.Enabled = true;
                //}
                //else
                //{
                    this.cboInCondition.Text = value;
                //}

            }
        }

        private void txtOtherDiagnose_TextChanged(object sender, EventArgs e)
        {
            newname = "";
            //if (checkBoxX1.Checked)
            //    return;
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["¼²²¡Ãû³Æ"].ToString();
                            newname = row["¼²²¡Ãû³Æ"].ToString();
                            txtICD10.Text = row["¼²²¡±àÂë"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textNametxtICD10
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOtherDiagnose_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtOtherDiagnose.ReadOnly == true)
            //    return;
            //if (checkBoxX1.Checked)
            //    return;
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
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
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code ¼²²¡±àÂë,name ¼²²¡Ãû³Æ from diag_def_icd10  where ((upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%')";
                            if (checkBoxX1.Checked)
                            {
                                sql_select += " and is_chinese='Y'";
                                sql_select += " Union";
                                sql_select += " select bm_code ¼²²¡±àÂë,bm_name ¼²²¡Ãû³Æ from t_bm  where (upper(py) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(py,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(bm_name) like '%" + text.ToUpper() + "%'";
                            }
                            else
                            {
                                sql_select += " and (is_chinese is null or is_chinese='N')";
                            }
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "¼²²¡±àÂë", "¼²²¡Ãû³Æ");
                            App.FastCodeFlag = true;
          
                        }
                    }
                }
            }
            catch
            { }
        }

        private string oldname;
        private string newname;
        private void txtOtherDiagnose_DoubleClick(object sender, EventArgs e)
        {
            //if (checkBoxX1.Checked == true)
            //{
            //    oldname = txtOtherDiagnose.Text;
            //    ischinese = true;
            //    frmCDiagDict frm = new frmCDiagDict();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.ICD10 = frm.Bmcode;
            //        this.OtherDiagnose = frm.Bmname;
            //        if (frm.Zhname.Length > 0)
            //        {
            //            this.OtherDiagnose += "¡ª" + frm.Zhname;
            //        }
            //        newname = txtOtherDiagnose.Text;
            //    }
            //}
            //else
            //{
            //    ischinese = false;
            //}
            //if (txtOtherDiagnose.ReadOnly == false)
            //    return;
            //string sql_select = "select code ¼²²¡±àÂë,name ¼²²¡Ãû³Æ from diag_def_icd10 where rownum<200";
            //List<string> oldlist = new List<string>();
            //oldlist.Add("name");
            //oldlist.Add("code");
            //oldlist.Add("shortcut1");
            //List<string> Newlist = new List<string>();
            //Newlist.Add("¼²²¡Ãû³Æ");
            //Newlist.Add("¼²²¡±àÂë");
            //Newlist.Add("Ãû³ÆÆ´Òô");
            //Bifrost.frmCode f = new frmCode(sql_select,oldlist,Newlist);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    if (App.SelectObj != null)
            //    {
            //        if (App.SelectObj.Select_Row != null)
            //        {
            //            DataRow row = App.SelectObj.Select_Row;
            //            txtOtherDiagnose.Text = row["¼²²¡Ãû³Æ"].ToString();
            //            txtICD10.Text = row["¼²²¡±àÂë"].ToString();
            //            App.SelectObj = null;
            //        }
            //    }
            //}
        }
        private bool ischinese = false;

        public bool Ischinese
        {
            get { return ischinese; }
            set 
            { 
                ischinese = value;
            }
        }
        private bool isInit = false;
        public void SetCheckBox(bool b)
        {
            isInit = true;
            checkBoxX1.Checked = b;
        }
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
            {
                ischinese = true;
            }
            else
            {
                ischinese = false;
            }
            if (isInit)
            {
                isInit = false;
                return;
            }
            this.txtOtherDiagnose.Text = "";
            this.txtICD10.Text = "";
        }

        private void txtOtherDiagnose_Leave(object sender, EventArgs e)
        {
            //if (!isValidation)
            //    return;
            //if (string.IsNullOrEmpty(newname))
            //{
            //    if (txtOtherDiagnose.Text != oldname&&txtOtherDiagnose.Text.Length>0)
            //    {
            //        txtOtherDiagnose.Text = oldname;
            //        App.Msg("Ö»ÔÊÐíÌí¼Ó×ÖµäÖÐµÄÕï¶Ï");
            //    }
            //}
        }

        private void txtOtherDiagnose_Enter(object sender, EventArgs e)
        {
            //newname = "";
            oldname = this.txtOtherDiagnose.Text;
            isValidation = true;
        }
        /// <summary>
        /// ÊÇ·ñÐèÒªÑéÖ¤txtOtherDiagnoseµÄleaveÊÂ¼þ
        /// </summary>
        private bool isValidation = true;
        private void checkBoxX1_MouseEnter(object sender, EventArgs e)
        {
            isValidation = false;
        }

        private void checkBoxX1_MouseLeave(object sender, EventArgs e)
        {
            isValidation = true;
        }
    }
}
