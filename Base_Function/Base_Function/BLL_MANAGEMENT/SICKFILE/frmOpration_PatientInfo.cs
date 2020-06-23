using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmOpration_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dt = new DataTable();//���ݱ�
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public frmOpration_PatientInfo()
        {
            InitializeComponent();
        }

        public frmOpration_PatientInfo(DataTable dt)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            flgView.AllowEditing = false;
            dt.Columns[0].ColumnName = "���";
            dt.Columns[1].ColumnName = "����";
            dt.Columns[2].ColumnName = "����ҽʦ";
            dt.Columns[3].ColumnName = "����һ��";
            dt.Columns[4].ColumnName = "��������";
            dt.Columns[5].ColumnName = "סԺ��";
            dt.Columns[6].ColumnName = "����";
            dt.Columns[7].ColumnName = "�Ա�";
            dt.Columns[8].ColumnName = "����";
            dt.Columns[9].ColumnName = "��ǰ���";
            dt.Columns[10].ColumnName = "��������";
            dt.Columns[11].ColumnName = "��������";
            dt.Columns[12].ColumnName = "��������";
            flgView.DataSource = dt;
            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["in_time"].Visible = false;
            flgView.Cols["sick_area_id"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            if (beginTime=="" &&endTime=="")
            {
                btnPrint.Visible = false;
            }
        }
        /// <summary>
        /// ������ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = CreateDataSetWidthFlexGrid(this.flgView);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmOpration_Print fp = new frmOpration_Print(ds, frmOpration_PatientInfo.sectionName, frmOpration_PatientInfo.beginTime, frmOpration_PatientInfo.endTime);
                    fp.Show();
                }
            }
        }

        /// <summary>
        /// �����ת�������ݼ�
        /// </summary>
        /// <param name="fg"></param>
        /// <returns></returns>
        private static DataSet CreateDataSetWidthFlexGrid(C1FlexGrid fg)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            //������
            for (int i = 1; i < fg.Cols.Count; i++)
            {
                DataColumn dc;
                dc = new DataColumn(fg.Cols[i][0].ToString());
                dt.Columns.Add(dc);
            }

            //�����У�������
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].NewRow();
                for (int j = 1; j < fg.Cols.Count; j++)
                {
                    dr[j - 1] = fg.Rows[i][j].ToString();
                }
                ds.Tables[0].Rows.Add(dr);
            }
            return ds;
        } 
    }
}