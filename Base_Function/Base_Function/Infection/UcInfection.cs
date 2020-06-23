using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.Infection
{
    public partial class UcInfection : UserControl
    {
        int oldrowindex = 0;
        int currentInfection_id = 0;
        public UcInfection()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            fg1.AllowEditing = false;
            fg1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            fg2.AllowEditing = false;
            fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            fg1.Click += new EventHandler(fg1_Click);
            fg2.Click += new EventHandler(fg2_Click);
            LoadData();
        }

        void fg2_Click(object sender, EventArgs e)
        {
            if (this.currentInfection_id > 0)
            {
                if (this.fg2.Row >= this.fg2.Rows.Fixed)
                {
                    this.txtDiagName.Text = fg2[fg2.Row, "¼²²¡Ãû³Æ"].ToString();
                    this.txtDiagCode.Text = fg2[fg2.Row, "¼²²¡±àÂë"].ToString();
                }
            }
        }

        void LoadData()
        {
            oldrowindex = 0;
            currentInfection_id = 0;
            string sql = "select a.infection_id,a.infection_name ´«È¾²¡Ãû³Æ,decode(a.enabled,1,'ÆôÓÃ','Î´ÆôÓÃ') ×´Ì¬,a.description from t_infection_index a";
            DataTable tableindex = App.GetDataSet(sql).Tables[0];
            this.fg1.DataSource = tableindex;
            this.fg1.Cols["infection_id"].Visible = false;
            this.fg1.Cols["description"].Visible = false;
        }

        void LoadDiagnosis()
        {
            if (this.currentInfection_id > 0)
            {
                string sql = @" select d.diagnosis_code ¼²²¡±àÂë,c.¼²²¡Ãû³Æ from (
                             select a.code ¼²²¡±àÂë,a.name ¼²²¡Ãû³Æ from diag_def_icd10 a 
                             union
                             select b.icd10_id ¼²²¡±àÂë,b.name ¼²²¡Ãû³Æ from t_diag_def b ) c 
                             right join t_infection_detail d on c.¼²²¡±àÂë=d.diagnosis_code
                             where d.infection_id=" + currentInfection_id;
                DataTable table = App.GetDataSet(sql).Tables[0];
                this.fg2.DataSource = table;
            }
        }

        void fg1_Click(object sender, EventArgs e)
        {
            int currentRowindex = this.fg1.Row;
            if (currentRowindex >= this.fg1.Rows.Fixed && currentRowindex != oldrowindex)
            {
                int.TryParse(this.fg1[currentRowindex, "infection_id"].ToString(), out currentInfection_id);
                //DataRow row = table.Rows[0];
                byte[] bs = (byte[])this.fg1[currentRowindex, "description"];
                string content = System.Text.Encoding.Default.GetString(bs);
                this.richTextBox1.Clear();
                this.richTextBox1.AppendText(content);
                LoadDiagnosis();
            }
        }

        /// <summary>
        /// Ìí¼Ó´«È¾²¡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ìí¼ÓToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModifyInfect frm = new FrmModifyInfect();
            if (frm.ShowDialog() == DialogResult.OK)
                this.LoadData();
        }

        /// <summary>
        /// É¾³ý´«È¾²¡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void É¾³ýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg1.Row >= this.fg1.Rows.Fixed)
            {
                int infection_id = 0;
                int.TryParse(this.fg1[this.fg1.Row, "infection_id"].ToString(), out infection_id);
                if (infection_id > 0)
                {
                    List<string> sqls = new List<string>();
                    string sql = "delete from t_infection_detail a where a.infection_id=" + infection_id;
                    sqls.Add(sql);
                    sql = "delete from t_infection_index a where a.infection_id=" + infection_id;
                    sqls.Add(sql);
                    int count = App.ExecuteSQL(sql);
                    if (count > 0)
                    {
                        App.Msg("É¾³ý³É¹¦£¡");
                        this.LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// ÐÞ¸Ä´«È¾²¡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ÐÞ¸ÄToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fg1.Row >= this.fg1.Rows.Fixed)
            {
                int infection_id = 0;
                int.TryParse(this.fg1[this.fg1.Row, "infection_id"].ToString(), out infection_id);
                if (infection_id > 0)
                {
                    FrmModifyInfect frm = new FrmModifyInfect(infection_id, true);
                    if (frm.ShowDialog() == DialogResult.OK)
                        this.LoadData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.currentInfection_id > 0)
            {
                string code = this.txtDiagCode.Text.Trim();
                if (code.Length == 0)
                {
                    App.Msg("¼²²¡±àÂë²»ÄÜÎª¿Õ£¡");
                    return;
                }
                string sql = "insert into t_infection_detail (infection_id, diagnosis_code) ";
                sql += " select " + currentInfection_id + ", '" + code + "' from dual";
                sql += " where not exists (select 1 from t_infection_detail where infection_id=" + currentInfection_id;
                sql += " and diagnosis_code='" + code + "')";
                int count = App.ExecuteSQL(sql);
                if (count > 0)
                {
                    App.Msg("Ìí¼Ó³É¹¦£¡");
                    this.LoadDiagnosis();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentInfection_id > 0)
            {
                string code = this.txtDiagCode.Text.Trim();
                if (code.Length == 0)
                {
                    App.Msg("¼²²¡±àÂë²»ÄÜÎª¿Õ£¡");
                    return;
                }
                string sql = "delete from t_infection_detail ";
                sql += " where infection_id=" + currentInfection_id;
                sql += " and diagnosis_code='" + code + "'";
                int count = App.ExecuteSQL(sql);
                if (count > 0)
                {
                    App.Msg("Ìí¼Ó³É¹¦£¡");
                    this.LoadDiagnosis();
                }
            }
        }
        

        private void txtDiagName_TextChanged(object sender, EventArgs e)
        {
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
                            txtDiagCode.Text= row["¼²²¡±àÂë"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDiagCode_TextChanged(object sender, EventArgs e)
        {
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
                            textBox.Text = row["¼²²¡±àÂë"].ToString();
                            txtDiagName.Text = row["¼²²¡Ãû³Æ"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDiagName_KeyUp(object sender, KeyEventArgs e)
        {
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
                            string sql_select = " select a.code ¼²²¡±àÂë,a.name ¼²²¡Ãû³Æ from diag_def_icd10 a where instr(lower(a.shortcut1),lower('" + text + "'),1)>0 ";
                            sql_select += " or instr(a.name,'" + text + "',1)>0 union ";
                            sql_select += " select b.icd10_id ¼²²¡±àÂë,b.name ¼²²¡Ãû³Æ from t_diag_def b where instr(lower(b.shortcut1),lower('" + text + "'),1)>0 ";
                            sql_select += " or instr(b.name,'" + text + "',1)>0";
                            App.FastCodeCheck(sql_select, txtBox, "¼²²¡±àÂë", "¼²²¡Ãû³Æ");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtDiagCode_KeyUp(object sender, KeyEventArgs e)
        {
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
                            string sql_select = " select a.code ¼²²¡±àÂë,a.name ¼²²¡Ãû³Æ from diag_def_icd10 a where instr(lower(a.code),lower('"+text+"'),1)>0 ";
                            sql_select+=" union ";
                            sql_select += " select b.icd10_id ¼²²¡±àÂë,b.name ¼²²¡Ãû³Æ from t_diag_def b where instr(lower(b.is_icd10),lower('" + text + "'),1)>0"; 
                            App.FastCodeCheck(sql_select, txtBox, "¼²²¡±àÂë", "¼²²¡Ãû³Æ");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}
