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
    public partial class ucCoseOperate : UserControl
    {
        public ucCoseOperate()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            AddNewEnvelop addnow = new AddNewEnvelop(this);
            App.ButtonStytle(addnow,false);
            addnow.ShowDialog();
        }

        private void ucCoseOperate_Load(object sender, EventArgs e)
        {
            try
            {
                this.ucC1FlexGrid1.fg.AllowEditing = false;
                GetCoseData();
            }
            catch
            {
            }

        }
        
        public void GetCoseData()
        {
            //this.dateTimePicker1.Text = App.GetSystemTime().ToString("yyyy-MM-dd");
            string querySQL = "select REQ_BY_TIME as 申请时间,IN_HOSPITAL_ID as 申请病案号,IN_COUNT as 申请病案住院次数," +
                              "REQ_REMARK as 申请理由,REQ_BY_NAME as 申请人姓名,RECORD_BY_NAME as 退回操作人姓名,STATE as 档案状态" +
                              " from T_DOC_REQ_RECORD where 1=1";
            DataSet ds = App.GetDataSet(querySQL);
            this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
            for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                this.ucC1FlexGrid1.fg.Cols[i].Width = 178;
                ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }
            this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string querySQL = "select REQ_BY_TIME as 申请时间,IN_HOSPITAL_ID as 申请病案号,IN_COUNT as 申请病案住院次数," +
                                     "REQ_REMARK as 申请理由,REQ_BY_NAME as 申请人姓名,RECORD_BY_NAME as 退回操作人姓名,STATE as 档案状态" +
                                     " from T_DOC_REQ_RECORD where 1=1";
                if (txtEvolp.Text.Trim() != "")
                {
                    querySQL += " and to_char(REQ_BY_TIME,'yyyy-MM-dd') like '%" + this.dateTimePicker1.Text + "%' and REQ_BY_NAME like '%" + this.txtEvolp.Text.Trim() + "%'";
                }
                if (txtInHospet.Text.Trim() != "")
                {
                    querySQL += " and to_char(REQ_BY_TIME,'yyyy-MM-dd') like '%" + this.dateTimePicker1.Text + "%' and IN_HOSPITAL_ID='" + txtInHospet.Text.Trim() + "'";
                }
                if (this.dateTimePicker1.Text.Trim() != "" && txtEvolp.Text.Trim() == "" && txtInHospet.Text.Trim() == "")
                {
                    querySQL += " and to_char(REQ_BY_TIME,'yyyy-MM-dd') like '%" + this.dateTimePicker1.Text + "%'";
                }
                DataSet ds = App.GetDataSet(querySQL);
                this.ucC1FlexGrid1.fg.DataSource = ds.Tables[0];
                for (int i = 1; i < this.ucC1FlexGrid1.fg.Cols.Count; i++)
                {
                    this.ucC1FlexGrid1.fg.Cols[i].Width = 178;
                    ucC1FlexGrid1.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
                this.ucC1FlexGrid1.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
            catch (Exception ee)
            {
            }
        }
    }
}
