using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA.KBS
{
    /// <summary>
    /// 连伟20160517
    /// </summary>
    public partial class frmSelectSection : Office2007Form
    {
       public List<string> Sn = new List<string>();
        public frmSelectSection()
        {
            InitializeComponent();
            #region 下拉框
            //            string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
//                                        inner join t_section_area b on a.sid=b.sid
//                                        group  by a.shid,a.sid,a.section_code,a.section_name
//                                        order by a.shid,a.section_code";//查询科室
//            DataSet ds_InSection = new DataSet();
//            ds_InSection = App.GetDataSet(sql_Section);
//            //插入默认选项（请选择）
//            if (ds_InSection != null)
//            {
//                DataRow dr = ds_InSection.Tables[0].NewRow();
//                dr["sid"] = 0;
//                dr["section_name"] = "请选择";
//                ds_InSection.Tables[0].Rows.InsertAt(dr, 0);
//            }
//            cbxSick_section.DataSource = ds_InSection.Tables[0];
//            cbxSick_section.DisplayMember = "section_name";
            //            cbxSick_section.ValueMember = "sid";
            #endregion
            DataSet dsSection = App.GetDataSet("select a.sid as 科室主键,a.section_name as 科室名称 from t_sectioninfo a where ENABLE_FLAG='Y' and ISBELONGTOBIGSECTION='Y'");
            dataGridViewX1.DataSource = dsSection.Tables[0].DefaultView;
          
            DataGridViewCheckBoxColumn chkSectioncol = new DataGridViewCheckBoxColumn();
            chkSectioncol.HeaderText = "选择";
            chkSectioncol.Name = "选择";
            chkSectioncol.DisplayIndex = 0;
            chkSectioncol.Width = 40;
            chkSectioncol.TrueValue = "true";
            chkSectioncol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkSectioncol);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            string _name = "";
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                int count = 0;//存checkbox
                if (dataGridViewX1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    count++;
                    if (count == 0)
                    {
                        MessageBox.Show("请至少选择一条数据！", "提示");
                        return;
                    }
                    else
                    {
                        string sec = dataGridViewX1.Rows[i].Cells["科室名称"].Value.ToString();
                        if (_name != null)
                        {
                            _name = sec;
                            Sn.Add(_name);
                        }
                    }

                }
            }
           
            this.Close();
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell sc1 = dataGridViewX1["选择", i] as DataGridViewCheckBoxCell;
                    sc1.Value = "true";
                }
            }
            else
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell sc1 = dataGridViewX1["选择", i] as DataGridViewCheckBoxCell;
                    sc1.Value = "false";
                }
            }
        }
    }
}