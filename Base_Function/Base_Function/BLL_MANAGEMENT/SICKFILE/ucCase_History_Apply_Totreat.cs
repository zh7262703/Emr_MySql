using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucCase_History_Apply_Totreat : UserControl
    {
        public ucCase_History_Apply_Totreat()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void ucC1FlexGrid1_Load(object sender, EventArgs e)
        {
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            try
            {
                DataSet ds = new DataSet();
                string sql = "select sID,Section_Name from t_sectioninfo";
                ds = App.GetDataSet(sql);
                this.cboFrequencyItem.DataSource = ds.Tables[0].DefaultView;
                cboFrequencyItem.DisplayMember = "Section_Name";
                cboFrequencyItem.ValueMember = "sID";
            }
            catch { }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            #region 数据
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn("申请时间", Type.GetType("System.String"));
            //dt.Columns.Add(dc);

            //DataColumn dc1 = new DataColumn("申请科室", Type.GetType("System.String"));
            //dt.Columns.Add(dc1);

            //DataColumn dc2 = new DataColumn("申请理由", Type.GetType("System.String"));
            //dt.Columns.Add(dc2);

            //DataColumn dc3 = new DataColumn("申请人", Type.GetType("System.String"));
            //dt.Columns.Add(dc3);

            //DataColumn dc4 = new DataColumn("病案号", Type.GetType("System.String"));
            //dt.Columns.Add(dc4);

            //DataColumn dc5 = new DataColumn("住院次数", Type.GetType("System.String"));
            //dt.Columns.Add(dc5);

            //DataColumn dc6 = new DataColumn("患者姓名", Type.GetType("System.String"));
            //dt.Columns.Add(dc6);

            //DataRow dr = dt.NewRow();
            //dr[0] = "2009-03-15";
            //dr[1] = "神经外科";
            //dr[2] = "";
            //dr[3] = "杜洪澎";
            //dr[4] = "";
            //dr[5] = "1";
            //dr[6] = "王在娥";


            //DataRow dr1 = dt.NewRow();
            //dr1[0] = "2009-03-19";
            //dr1[1] = "脊柱外科病房";
            //dr1[2] = "";
            //dr1[3] = "系统测试";
            //dr1[4] = "PD0900000012";
            //dr1[5] = "1";
            //dr1[6] = "郭振刚";

            //DataRow dr2 = dt.NewRow();
            //dr2[0] = "2009-03-19";
            //dr2[1] = "神经内科";
            //dr2[2] = "";
            //dr2[3] = "系统测试";
            //dr2[4] = "PD0900000016";
            //dr2[5] = "1";
            //dr2[6] = "王尽禧";

            //DataRow dr3 = dt.NewRow();
            //dr3[0] = "2009-07-31";
            //dr3[1] = "神经外科";
            //dr3[2] = "";
            //dr3[3] = "系统测试";
            //dr3[4] = "";
            //dr3[5] = "1";
            //dr3[6] = "王在娥";

            //DataRow dr4 = dt.NewRow();
            //dr4[0] = "2010-02-23";
            //dr4[1] = "肿瘤科";
            //dr4[2] = "";
            //dr4[3] = "李绵利";
            //dr4[4] = "";
            //dr4[5] = "1";
            //dr4[6] = "罗进元";

            //DataRow dr5 = dt.NewRow();
            //dr5[0] = "2010-04-15";
            //dr5[1] = "神经外科";
            //dr5[2] = "";
            //dr5[3] = "系统测试";
            //dr5[4] = "";
            //dr5[5] = "1";
            //dr5[6] = "王在娥";

            //dt.Rows.Add(dr);
            //dt.Rows.Add(dr1);
            //dt.Rows.Add(dr2);
            //dt.Rows.Add(dr3);
            //dt.Rows.Add(dr4);
            //dt.Rows.Add(dr5);
            //ucC1FlexGrid1.fg.DataSource = dt;

            //ucC1FlexGrid1.fg.Cols["申请时间"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["申请科室"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["申请理由"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["申请人"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["病案号"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["住院次数"].Width = 170;
            //ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 170;
            #endregion
            GetCoseData();
        }
        DataSet ds = null;
        string querySQLS = ""; 
        public void GetCoseData()
        {
            querySQLS = "select doc.id as ID, REQ_BY_TIME as 申请时间,sick.sick_area_name as 申请科室, REQ_REMARK as 申请理由,REQ_BY_NAME as 申请人姓名, " +
                              "RECORD_BY_NAME as 退回操作人姓名,IN_HOSPITAL_ID as 申请病案号,IN_COUNT as 申请病案住院次数,patient_name as 患者姓名 " +
                              "from T_DOC_REQ_RECORD doc " +
                              "join t_Sickareainfo sick on sickorsection_id=sick.said " +
                              "join t_in_patient pati on in_patient_id=pati.pid";
            if (this.cboFrequencyItem.Text != "")
            {
                querySQLS += " and sick.sick_area_name='" + this.cboFrequencyItem.Text + "'";
            }

            if (this.txtShenqing.Text != "")
            {
                querySQLS += " and REQ_BY_NAME like '%" + this.txtShenqing.Text + "%'";
            }
            if (this.dtpStartYear.Text != "")
            {
                querySQLS += " and to_char(REQ_BY_TIME,'yyyy-MM-dd') like '" + this.dtpStartYear.Text + "'";
            }
             ds = App.GetDataSet(querySQLS);
            this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
            for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                this.ucC1FlexGrid1.fg.Cols[i].Width = 158;
                ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }
            this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

        }
        //string querySQLS = "";
        private void ucCase_History_Apply_Totreat_Load(object sender, EventArgs e)
        {

            //GetCoseData();
            try
            {
                string querySQLS = "select doc.id as ID, REQ_BY_TIME as 申请时间,sick.sick_area_name as 申请科室, REQ_REMARK as 申请理由,REQ_BY_NAME as 申请人姓名, " +
                                     "RECORD_BY_NAME as 退回操作人姓名,IN_HOSPITAL_ID as 申请病案号,IN_COUNT as 申请病案住院次数,patient_name as 患者姓名 " +
                                     "from T_DOC_REQ_RECORD doc " +
                                     "join t_Sickareainfo sick on sickorsection_id=sick.said " +
                                     "join t_in_patient pati on in_patient_id=pati.pid where 1=1";
                DataSet ds = App.GetDataSet(querySQLS);
                this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
                for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
                {
                    this.ucC1FlexGrid1.fg.Cols[i].Width = 158;
                    ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
                this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
            catch (Exception ee)
            {
            }

        }
        string ID = "";
        int oldRow = 0;//点击原来的行
        int selRow = 0;//新的行
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.Rows.Count > 1)
            {
                ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
            }

            selRow = 1;
            ucC1FlexGrid1.fg.AllowEditing = false;


            int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
            if (rows > 0)
            {
                if (oldRow == rows)
                {
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //如果不是头行
                    if (rows > 0)
                    {
                        //就改变背景色
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow)
                    {
                        //定义上一次点击过的行还原
                        this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //给上一次的行号赋值
            oldRow = rows;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string updateSQL = "update T_DOC_REQ_RECORD set STATE='1' where id='" + ID + "'";
            int go = App.ExecuteSQL(updateSQL);
            if (go > 0)
            {
                App.Msg("同意申请成功");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string updateSQL = "update T_DOC_REQ_RECORD set REQ_STATE='1' where id='" + ID + "'";
            int go = App.ExecuteSQL(updateSQL);
            if (go > 0)
            {
                App.Msg("已拒绝");
            }
        }

        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
    }
}
