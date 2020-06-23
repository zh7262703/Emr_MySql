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
    public partial class ArchiveStatistics : UserControl
    {
        public ArchiveStatistics()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        public void GetAllSection_Name() {
            try
            {
                DataSet ds = new DataSet();
                string sql = "select sID,Section_Name from t_sectioninfo";
                ds = App.GetDataSet(sql);
                this.cmbSectionOffice.DataSource = ds.Tables[0].DefaultView;
                cmbSectionOffice.DisplayMember = "Section_Name";
                cmbSectionOffice.ValueMember = "sID";
            }
            catch
            { }
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {
            GetAllSection_Name();
        }
        
        private void btnSum_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("科室", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("未归档病案号", Type.GetType("System.String"));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("患者姓名", Type.GetType("System.String"));
            dt.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("应该归档日期", Type.GetType("System.String"));
            dt.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("管床医师", Type.GetType("System.String"));
            dt.Columns.Add(dc4);
            
            DataRow dr = dt.NewRow();
            dr[0] = "肿瘤科";
            dr[1] = "371838";
            dr[2] = "齐立民";
            dr[3] = "2009-02-16 08:37:00";
            dr[4] = " ";

            DataRow dr1 = dt.NewRow();
            dr1[0] = "ICU病区";
            dr1[1] = "372425";
            dr1[2] = "孙爱玲";
            dr1[3] = "2008-12-18 08:59:46";
            dr1[4] = " ";

            DataRow dr2 = dt.NewRow();
            dr2[0] = "肿瘤科";
            dr2[1] = "375584";
            dr2[2] = "高义陈";
            dr2[3] = "2009-01-26 15:40:00";
            dr2[4] = " ";

            DataRow dr3 = dt.NewRow();
            dr3[0] = "ICU病区";
            dr3[1] = "375618";
            dr3[2] = "樊太银";
            dr3[3] = "2009-02-17 14:34:00";
            dr3[4] = " ";

            DataRow dr4 = dt.NewRow();
            dr4[0] = "肿瘤科";
            dr4[1] = "376019";
            dr4[2] = "苏少玉";
            dr4[3] = "2009-02-11 17:03:00";
            dr4[4] = " ";

            DataRow dr5 = dt.NewRow();
            dr5[0] = "神经外科";
            dr5[1] = "378466";
            dr5[2] = "王荣飞";
            dr5[3] = "2009-02-13 08:57:00";
            dr5[4] = " ";

            DataRow dr6 = dt.NewRow();
            dr6[0] = "消化内科";
            dr6[1] = "378568";
            dr6[2] = "周曰兰";
            dr6[3] = "2009-02-18 05:40:00";
            dr6[4] = "王伟";

            DataRow dr7 = dt.NewRow();
            dr7[0] = "消化内科";
            dr7[1] = "378905";
            dr7[2] = "陈淑敏";
            dr7[3] = "2009-02-17 14:07:00";
            dr7[4] = " ";

            DataRow dr8 = dt.NewRow();
            dr8[0] = "神经外科二病房";
            dr8[1] = "379369";
            dr8[2] = "张延武";
            dr8[3] = "2009-03-01 10:10:00";
            dr8[4] = "杨淑野";

            DataRow dr9 = dt.NewRow();
            dr9[0] = "肝胆外科";
            dr9[1] = "378698";
            dr9[2] = "高金铭";
            dr9[3] = "2009-03-02 14:37:00";
            dr9[4] = "张长习";

            DataRow dr10 = dt.NewRow();
            dr10[0] = "神经外科";
            dr10[1] = "380008";
            dr10[2] = "董升学";
            dr10[3] = "2010-03-19 06:59:00";
            dr10[4] = "徐军";

            DataRow dr11 = dt.NewRow();
            dr11[0] = "急诊科";
            dr11[1] = "380066";
            dr11[2] = "付从刚";
            dr11[3] = "2009-03-04 11:40:00";
            dr11[4] = " ";

           
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);
            dt.Rows.Add(dr6);
            dt.Rows.Add(dr7);
            dt.Rows.Add(dr8);
            dt.Rows.Add(dr9);
            dt.Rows.Add(dr10);
            dt.Rows.Add(dr11);
            ucC1FlexGrid1.fg.DataSource = dt;

            ucC1FlexGrid1.fg.Cols["科室"].Width = 200;
            ucC1FlexGrid1.fg.Cols["未归档病案号"].Width = 200;
            ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 200;
            ucC1FlexGrid1.fg.Cols["应该归档日期"].Width = 200;
            ucC1FlexGrid1.fg.Cols["管床医师"].Width = 200;
        }
    }
}
