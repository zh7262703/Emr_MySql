using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucCase_History : UserControl
    {
        public ucCase_History()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }


        private void ucCase_History_Load(object sender, EventArgs e)
        {
            try
            {
                chkSection_CheckedChanged(sender, e);
                chkTime_CheckedChanged(sender, e);
            }
            catch { }
        }
        private void Sections()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO");
            cboFrequencyItem.DataSource = dt.Tables[0].DefaultView;
            cboFrequencyItem.ValueMember = "SID";
            cboFrequencyItem.DisplayMember = "SECTION_NAME";
        }
        /// <summary>
        /// 查询设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("科室", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("住院号", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("患者姓名", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("管床医师", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("已退回次数", Type.GetType("System.String"));
            dt.Columns.Add(dc4);

            DataRow dr = dt.NewRow();
            dr[0] = "神经内科";
            dr[1] = "363669";
            dr[2] = "王广平";
            dr[3] = "";
            dr[4] = "0";

            DataRow dr1 = dt.NewRow();
            dr1[0] = "ICU病区";
            dr1[1] = "372425";
            dr1[2] = "孙爱玲";
            dr1[3] = "";
            dr1[4] = "0";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "肿瘤科";
            dr2[1] = "375584";
            dr2[2] = "高义陈";
            dr2[3] = "";
            dr2[4] = "0";

            DataRow dr3 = dt.NewRow();
            dr3[0] = "ICU病区";
            dr3[1] = "375618";
            dr3[2] = "樊太银";
            dr3[3] = "";
            dr3[4] = "0";

            DataRow dr4 = dt.NewRow();
            dr4[0] = "肿瘤科";
            dr4[1] = "376019";
            dr4[2] = "苏少玉";
            dr4[3] = "";
            dr4[4] = "0";

            DataRow dr5 = dt.NewRow();
            dr5[0] = "神经外科";
            dr5[1] = "378466";
            dr5[2] = "王荣飞";
            dr5[3] = "";
            dr5[4] = "0";

            DataRow dr6 = dt.NewRow();
            dr6[0] = "消化内科";
            dr6[1] = "378568";
            dr6[2] = "周曰兰";
            dr6[3] = "冯波";
            dr6[4] = "0";

            DataRow dr7 = dt.NewRow();
            dr7[0] = "消化内科";
            dr7[1] = "378905";
            dr7[2] = "陈淑敏";
            dr7[3] = "";
            dr7[4] = "0";

            DataRow dr8 = dt.NewRow();
            dr8[0] = "神经外科二病房";
            dr8[1] = "379369";
            dr8[2] = "张延武";
            dr8[3] = "";
            dr8[4] = "0";


            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);
            dt.Rows.Add(dr6);
            dt.Rows.Add(dr7);
            dt.Rows.Add(dr8);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["科室"].Width = 200;
            ucC1FlexGrid1.fg.Cols["住院号"].Width = 200;
            ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 200;
            ucC1FlexGrid1.fg.Cols["管床医师"].Width = 200;
            ucC1FlexGrid1.fg.Cols["已退回次数"].Width = 200;
        }
        /// <summary>
        /// 科室控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSection.Checked == true)
                {
                    cboFrequencyItem.Enabled = true;
                    DataSet ds = new DataSet();
                    string sql = "select sID,Section_Name from t_sectioninfo";
                    ds = App.GetDataSet(sql);
                    this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                    cboFrequencyItem.DisplayMember = "Section_Name";
                    cboFrequencyItem.ValueMember = "sID";
                }
                else
                {
                    cboFrequencyItem.Enabled = false;
                    DataSet ds = new DataSet();
                    string sql = "select sID,Section_Name from t_sectioninfo";
                    ds = App.GetDataSet(sql);
                    this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                    cboFrequencyItem.DisplayMember = "Section_Name";
                    cboFrequencyItem.ValueMember = "sID";
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// 归档时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartYear.Enabled = true;

            }
            else
            {
                dtpStartYear.Enabled = false;
            }
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {

        }

    }
}
