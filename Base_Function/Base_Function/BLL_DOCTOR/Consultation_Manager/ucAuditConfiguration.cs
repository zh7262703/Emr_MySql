using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class ucAuditConfiguration : UserControl
    {
        public ucAuditConfiguration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getDoctor(this.textBox1.Text);
        }



        private void getAuditconfig()
        {
            string sql = @" SELECT  A.XH 序号,A.YSBM 医生编码,A.YSMC 医生名称,A.KSBM 科室编码,A.KSMC 科室名称 FROM T_AUDITCONFIG A  where 1=1 ";

            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                sql += " and (a.YSBM like '%" + this.textBox2.Text.Trim() + "%' or a.YSMC like '%" + this.textBox2.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.textBox3.Text))
            {
                sql += " and (a.KSBM like '%" + this.textBox3.Text.Trim() + "%' or a.KSMC like '%" + this.textBox3.Text.Trim() + "%') ";
            }
            sql += " ORDER BY a.YSMC ";

            DataSet ds = App.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                this.dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView1.Refresh();
            }
        }

        private void getSectiont(string gltj)
        {
            string sql = @"SELECT  A.SID,A.SECTION_NAME  FROM T_SECTIONINFO  a  
                            WHERE ENABLE_FLAG = 'Y'  AND A.SID IN (SELECT DISTINCT B.SID FROM T_SECTION_AREA b) ";

            if(!string.IsNullOrEmpty(gltj))
            {
                sql += " and (a.sid like '%" + gltj.Trim() + "%' or a.section_name like '%" + gltj .Trim()+ "%') ";
            }

            sql += " ORDER BY SECTION_NAME ";

            DataSet ds= App.GetDataSet(sql);
            if(ds!=null&&ds.Tables.Count>0)
            {
                this.checkedListBox1.DataSource = ds.Tables[0];
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    this.checkedListBox1.Items.Add(dr);
                //}
                this.checkedListBox1.DisplayMember = "SECTION_NAME";
                this.checkedListBox1.ValueMember = "SID";               
            }
        }

        private void getDoctor(string gltj)
        {
            string sql = @"SELECT DISTINCT(A.USER_ID),A.USER_NAME FROM T_USERINFO A 
                                         INNER JOIN T_ACCOUNT_USER B ON A.USER_ID=B.USER_ID 
                                         INNER JOIN T_ACCOUNT C ON B.ACCOUNT_ID = C.ACCOUNT_ID 
                                         INNER JOIN T_ACC_ROLE D ON D.ACCOUNT_ID = C.ACCOUNT_ID 
                                         INNER JOIN T_ROLE E ON E.ROLE_ID = D.ROLE_ID 
                                         INNER JOIN T_ACC_ROLE_RANGE F ON D.ID = F.ACC_ROLE_ID 
                                         WHERE   E.ROLE_TYPE='D' ";

            if (!string.IsNullOrEmpty(gltj))
            {
                sql += " and (A.USER_ID like '%" + gltj.Trim() + "%' or A.USER_NAME like '%" + gltj.Trim() + "%') ";
            }
            sql += " ORDER BY A.USER_NAME ";

            DataSet ds = App.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                this.listBox1.DataSource = ds.Tables[0];
                this.listBox1.DisplayMember = "USER_NAME";
                this.listBox1.ValueMember = "USER_ID";
            }
        }


        private void checkedSectiont(string ysbm)
        {

            string sql = string.Empty;

            if (!string.IsNullOrEmpty(ysbm))
            {
                sql += @" select*from T_AUDITCONFIG where YSBM='" + ysbm.Trim() + "' ";
            }
            else
            {
                return;
            }
            sql += " ORDER BY KSMC ";

            DataSet ds = App.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    DataRowView dr = (DataRowView)checkedListBox1.Items[i];
                    if (dr != null && dr.Row != null)
                    {
                        DataRow[] drr = ds.Tables[0].Select(" KSBM='" + dr.Row["SID"].ToString().Trim() + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            this.checkedListBox1.SetItemChecked(i, true);
                        }
                        else
                        {
                            this.checkedListBox1.SetItemChecked(i, false);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            getAuditconfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedValue != null)
            {
                StringBuilder sb = new StringBuilder();
                 App.ExecuteSQL(" delete from t_auditconfig where ysbm='" + this.listBox1.SelectedValue.ToString().Trim() + "'");
                if (this.checkedListBox1.CheckedItems != null && this.checkedListBox1.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
                    {
                        DataRowView dv = (DataRowView)checkedListBox1.CheckedItems[i];
                        if (dv != null&&dv.Row!=null)
                        { 
                            App.ExecuteSQL(" insert into t_auditconfig(KSBM,KSMC,SFYX,SJKS,YSBM,YSMC)values('" + dv.Row["SID"].ToString() + "','" + dv.Row["SECTION_NAME"].ToString() + "','1','','" + this.listBox1.SelectedValue.ToString().Trim() + "','" + this.listBox1.GetItemText(this.listBox1.SelectedItem).ToString().Trim() + "')");
                        }
                    }                   
                }
            }
            getAuditconfig();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0 && this.listBox1.SelectedValue != null)
            {
                checkedSectiont(this.listBox1.SelectedValue.ToString());
            }
        }

        private void checkall_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.Items != null && this.checkedListBox1.Items.Count > 0)
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void uncheckall_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.Items != null && this.checkedListBox1.Items.Count > 0)
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0 && this.listBox1.SelectedValue != null)
            {
                checkedSectiont(this.listBox1.SelectedValue.ToString());
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows!=null&& this.dataGridView1.SelectedRows.Count>0)
            {
                this.listBox1.SelectedValue = this.dataGridView1.SelectedRows[0].Cells["医生编码"].Value.ToString();
                checkedSectiont(this.listBox1.SelectedValue.ToString().Trim());
            }
        }

        private void ucAuditConfiguration_Load(object sender, EventArgs e)
        {
            getAuditconfig();
            getSectiont(null);
            getDoctor(null);
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.checkall.Click += new System.EventHandler(this.checkall_Click);
            this.uncheckall.Click += new System.EventHandler(this.uncheckall_Click);          
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
        }
    }
}


