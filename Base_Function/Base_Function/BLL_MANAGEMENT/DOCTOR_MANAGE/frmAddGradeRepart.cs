using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Microsoft.ReportingServices.ReportRendering;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// �������ֲ���
    /// </summary>
    /// �޸� ������
    /// �޸�ʱ�� 2013��12��25��
    public partial class frmAddGradeRepart : DevComponents.DotNetBar.Office2007Form
    {
        private ucfrmMainGradeRepart fmgr;
        /// <summary>
        /// ѡ�еĲ��˿���
        /// </summary>
        public string sickname;

        public frmAddGradeRepart(ucfrmMainGradeRepart _fmgr,string sick_name)
        {
            this.sickname = sick_name;
            InitializeComponent();
            this.fmgr = _fmgr;
        }
        /// <summary>
        /// ����ʱ����ʾ������
        /// </summary>
        private void SetSickData()
        {
            LinkLabel lkbel = new LinkLabel();
            lkbel.Text = "ѡ��";
            string querySQL = "select id as ���, SECTION_NAME as ����, pid as סԺ��, patient_name as ��������, in_time as סԺ����, " +
                              "die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ�� from T_IN_Patient where id not in(select distinct patient_id from t_Doc_Grade where patient_id is not null) and die_time is not null  ";

            if (cboxSick.Text != "ȫԺ")
            {
                querySQL += " and SECTION_NAME ='" + cboxSick.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtPid.Text.Trim()))
            {
                querySQL += " and pid like '%" + txtPid.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                querySQL += " and patient_name like '%" + txtName.Text.Trim() + "%'";
            }
            querySQL += " order by SECTION_NAME,id,pid";
            DataSet ds = App.GetDataSet(querySQL);
            DataTable dt = ds.Tables[0];//��datatable��ֵ
            //���һ��checkedbox
            DataColumn dc = new DataColumn("" + lkbel.Text + "", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            this.ucC1FlexGrid1.fg.DataSource = dt.DefaultView;//������Դdt
            this.ucC1FlexGrid1.fg.Cols["ѡ��"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["���"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["����"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["סԺ��"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["��������"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["סԺ����"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["��Ժ����"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["�ܴ�ҽ��"].Width = 50;
            //this.ucC1FlexGrid1.fg.Cols["����ID"].Width = 60;

            ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //����ӵ�һ���ƶ������ݱ�ĵ�һ��
            this.ucC1FlexGrid1.fg.Cols["" + lkbel.Text + ""].Move(1);
            for (int i = 0; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }


        }
        //List<string> list = new List<string>();
        private void btnConfrom_Click(object sender, EventArgs e)
        {
            //ѭ��UCC1��ÿ�С����ѡ�еľ����  ucC1FlexGrid1.fg.Rows[i]����UCC1��һ�С�
            for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
            {
                //ѡ��checkedbox�Ժ�᷵��һ��ȫ����Сд��true ���ѡ��
                if (ucC1FlexGrid1.fg[i, 1].ToString().ToLower() == "true")
                {
                    //����addrow�������һ��
                    this.fmgr.AddRow(ucC1FlexGrid1.fg.Rows[i]);
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int oldRow2 = 0;//��һ�ε�������к�
        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.ucC1FlexGrid1.fg.ColSel == 1)
            {
                this.ucC1FlexGrid1.fg.AllowEditing = true;
            }
            else
            {
                this.ucC1FlexGrid1.fg.AllowEditing = false;
            }

            if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1].ToString().ToLower() == "true")
            {
                ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1] = false;
            }
            else
            {
                ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1] = true;
            }

            int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к�
            if (rows == oldRow2)
            {
                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            }
            else
            {
                //�������ͷ��
                if (rows > 0)
                {
                    //�͸ı䱳��ɫ
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                }
                if (oldRow2 > 0)
                {
                    //������һ�ε�������л�ԭ
                    this.ucC1FlexGrid1.fg.Rows[oldRow2].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                }
            }
            //����һ�ε��кŸ�ֵ
            oldRow2 = rows;
        }
        int oldRow = 0;//��һ�ε�������к�
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (this.ucC1FlexGrid1.fg.ColSel == 1)
            {
                this.ucC1FlexGrid1.fg.AllowEditing = true;
            }
            else
            {
                this.ucC1FlexGrid1.fg.AllowEditing = false;
            }


            int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к�
            if (rows == oldRow)
            {
                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            }
            else
            {
                //�������ͷ��
                if (rows > 0)
                {
                    //�͸ı䱳��ɫ
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                }
                if (oldRow > 0)
                {
                    //������һ�ε�������л�ԭ
                    this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                }
            }
            //����һ�ε��кŸ�ֵ
            oldRow = rows;
        }

        private void frmAddGradeRepart_Load(object sender, EventArgs e)
        {
            DataBandSick();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SetSickData();
        }

        private void DataBandSick()
        {
            string sickSQL = "select t.sid,section_name from t_sectioninfo t inner join t_section_area x on t.sid=x.sid where  enable_flag='Y' order by section_name";
            DataSet ds1 = App.GetDataSet(sickSQL);

            DataRow dr = ds1.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "ȫԺ";
            ds1.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds1.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "section_name";
            this.cboxSick.ValueMember = "sid";
            cboxSick.Text = this.sickname;
        }
    }
}   