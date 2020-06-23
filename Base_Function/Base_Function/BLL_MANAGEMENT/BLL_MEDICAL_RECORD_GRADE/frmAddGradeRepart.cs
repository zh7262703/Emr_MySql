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


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// �������ֲ���
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class frmAddGradeRepart : DevComponents.DotNetBar.Office2007Form
    {
        private ucfrmMainGradeRepart fmgr;
        private ucfrmMainGradeRepartDoctor fmgrDoctor;
        private ucfrmMainGradeRepartSection fmgrSection;
        public frmAddGradeRepart(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();

            this.fmgr = _fmgr;
        }
        public frmAddGradeRepart(ucfrmMainGradeRepartDoctor _fmgrDoctor)
        {
            InitializeComponent();

            this.fmgrDoctor = _fmgrDoctor;
        }
        public frmAddGradeRepart(ucfrmMainGradeRepartSection _fmgrSection)
        {
            InitializeComponent();

            this.fmgrSection = _fmgrSection;
        }
        /// <summary>
        /// ����ʱ����ʾ������
        /// </summary>
        private void SetSickData()
        {
            LinkLabel lkbel = new LinkLabel();
            lkbel.Text = "ѡ��";
            string querySQL = "select id as ���, in_area_name as ����, pid as סԺ��, patient_name as ��������, in_time as סԺ����, " +
                              "die_time as ��Ժ����, Sick_Doctor_Name as ����ҽʦ,pid as ����ID from T_IN_Patient";
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
            this.ucC1FlexGrid1.fg.Cols["����ҽʦ"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["����ID"].Width = 60;

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
            SetSickData();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
        }
    }
}   