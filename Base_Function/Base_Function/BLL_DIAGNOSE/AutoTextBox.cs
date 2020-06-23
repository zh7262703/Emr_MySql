using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Bifrost;

namespace Base_Function.BLL_DIAGNOSE
{
    public class AutoTextBox : TextBox
    {
        public ListBox listBoxAutoComplete = new ListBox();
        public delegate void ReturnId(string id);
        public ReturnId OnReturnId;
        public AutoTextBox()
        {
            listBoxAutoComplete.Visible = false;
            listBoxAutoComplete.DoubleClick += new EventHandler(listBoxAutoComplete_DoubleClick);
            listBoxAutoComplete.SelectedIndexChanged += new EventHandler(listBoxAutoComplete_SelectedIndexChanged);
            //listBoxAutoComplete.Enter += new EventHandler(listBoxAutoComplete_Enter);
            //listBoxAutoComplete.Click += new EventHandler(listBoxAutoComplete_Click);
        }

        public void SetPoint()
        {
            listBoxAutoComplete.Width = this.Width + 200;
            listBoxAutoComplete.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + this.Height + 2);
        }

        void listBoxAutoComplete_Click(object sender, EventArgs e)
        {
        }

        //void listBoxAutoComplete_Enter(object sender, EventArgs e)
        //{
        //    this.Focus();
        //}

        void listBoxAutoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changer)
                return;
            this.Focus();
        }
        bool changer = false;
        void listBoxAutoComplete_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBoxAutoComplete.SelectedItems.Count == 1)
            {
                this.listBoxAutoComplete.Hide();
                DataRowView drv = (DataRowView)this.listBoxAutoComplete.SelectedItem;
                changer = true;
                this.Text = "";
                this.Focus();
                this.AppendText(drv["name"].ToString());
                changer = false;
                if (OnReturnId != null)
                {
                    OnReturnId(drv["id"].ToString());
                }
            }
        }
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (listBoxAutoComplete.Visible)
                {
                    if (listBoxAutoComplete.SelectedIndex > 0)
                        listBoxAutoComplete.SelectedIndex--;
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (this.listBoxAutoComplete.Visible)
                {
                    if (this.listBoxAutoComplete.SelectedIndex < this.listBoxAutoComplete.Items.Count - 1)
                        this.listBoxAutoComplete.SelectedIndex++;
                    e.Handled = true;
                }
            }
            else if (e.KeyValue < 48 || (e.KeyValue >= 58 && e.KeyValue <= 64) || (e.KeyValue >= 91 && e.KeyValue <= 96) || e.KeyValue > 122)
            {

                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                {
                    if (this.listBoxAutoComplete.Visible)
                    {
                        DataRowView drv = (DataRowView)this.listBoxAutoComplete.SelectedItem;
                        changer = true;
                        this.Text = "";
                        changer = false;
                        this.AppendText(drv["name"].ToString());
                        this.Focus();
                        if (OnReturnId != null)
                        {
                            OnReturnId(drv["id"].ToString());
                        }
                        this.listBoxAutoComplete.Hide();
                        e.Handled = true;
                    }
                    else
                    {
                        if (OnReturnId != null)
                        {
                            OnReturnId("add");
                        }
                    }
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.listBoxAutoComplete.Hide();
            base.OnMouseDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (changer)
                return;
            if (populateListBox())
            {
                listBoxAutoComplete.BringToFront();
                listBoxAutoComplete.Show();
            }
            else
            {
                listBoxAutoComplete.Hide();
            }
            base.OnTextChanged(e);
        }
        //string sql = "select name,id,name||'  '||id as ni from (select name,ICD10_ID AS id,SHORTCUT1 from t_diag_def t  where (lower(SHORTCUT1) like lower('{0}%') AND substr(lower(SHORTCUT1),0,{1})='{0}') or (lower(SHORTCUT2) like lower('{0}%') AND substr(lower(SHORTCUT2),0,{1})='{0}')  or name like '%{0}%' and IS_CHN = 'N' union all" +
        //      " select name,code AS id,SHORTCUT1 FROM diag_def_icd10 where (lower(SHORTCUT1) like lower('{0}%') AND substr(lower(SHORTCUT1),0,{1})='{0}') or (lower(SHORTCUT2) like lower('{0}%') AND substr(lower(SHORTCUT2),0,{1})='{0}') or name like '%{0}%') t where rownum <101 order by SHORTCUT1 desc";
        string sql = "select distinct name,id,name||'  '||id as ni " +
                     "from (" +
                     "select name,ICD10_ID AS id from t_diag_def t where lower(SHORTCUT1) like lower('{0}%') and IS_CHN = 'N' or lower(ICD10_ID) like '{0}%' union all " +
                     "select name,code AS id FROM diag_def_icd10 where lower(SHORTCUT1) like lower('{0}%') or lower(code) like '{0}%' union all " +
                     "select name,ICD10_ID AS id from t_diag_def t where lower(SHORTCUT2) like lower('{0}%')  and IS_CHN = 'N' or lower(ICD10_ID) like '{0}%' union all " +
                     "select name,code AS id FROM diag_def_icd10 where lower(SHORTCUT2) like lower('{0}%') or lower(code) like '{0}%' union all " +
                     "select name,ICD10_ID AS id from t_diag_def t where name like '%{0}%' and IS_CHN = 'N' or lower(ICD10_ID) like '{0}%' union all " +
                     "select name,code AS id FROM diag_def_icd10 where name like '%{0}%' or lower(code) like '{0}%') t where rownum <101  ";

        public void SetSql(string newSql)
        {
            sql = newSql;
        }

        bool populateListBox()
        {
            bool result = false;
            string world = this.Text.Trim().ToLower().Replace("'", "''");
            listBoxAutoComplete.DataSource = null;
            if (string.IsNullOrEmpty(world))
            {
                if (OnReturnId != null)
                {
                    OnReturnId("");
                }
                return result;
            }
            DataTable seachTable = App.GetDataSet(string.Format(sql, world)).Tables[0];
            if (seachTable == null || seachTable.Rows.Count < 1)
                return result;
            changer = true;
            listBoxAutoComplete.DataSource = seachTable;
            listBoxAutoComplete.ValueMember = "id";
            listBoxAutoComplete.DisplayMember = "ni";
            changer = false;
            result = true;
            return result;
        }
    }
}