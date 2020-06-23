using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;

namespace Base_Function.BLL_DOCTOR
{
    public partial class ucMsgFB : UserControl
    {


        DataTable dt;
        string SickID = "";
        public ucMsgFB()
        {
            InitializeComponent();
        }

        public ucMsgFB(string sick_id)
        {
            InitializeComponent();
            SickID = sick_id == null ? "" : sick_id;
            SetHostoryPingFen();
        }

        /// <summary>
        /// ���ü�����ʾ����
        /// </summary>
        private void SetHostoryPingFen()
        {
            string selectSQL = "select a.id as ID, a.SECTION_NAME ����, a.pid as סԺ��, " +
                "patient_name as ��������, in_time as סԺ����,leave_time as ��Ժ����, " +
                "Sick_Doctor_Name as �ܴ�ҽ��, (100-sum(down_point)) as ��ֵ,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,b.grade_doc_name as ������ " +
                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid where a.section_id='" + SickID + "' group by " +
                " grade_time,a.pid,a.id, a.SECTION_NAME,patient_name,in_time,leave_time,Sick_Doctor_Name,b.grade_doc_name";
            dt = App.GetDataSet(selectSQL).Tables[0];
            this.ucC1FlexGrid1.fg.DataSource = dt;

            this.ucC1FlexGrid1.fg.Cols["ID"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["����"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["סԺ��"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["��������"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["סԺ����"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["��Ժ����"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["�ܴ�ҽ��"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["��ֵ"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["����ʱ��"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["������"].Width = 80;

            this.ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //�ı�c1�еĳ���
            for (int i = 1; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                //this.ucC1FlexGrid1.fg.Cols[i].Width = 123;
                this.ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
        }

        private void ucMsgFB_Load(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.MouseDoubleClick += new MouseEventHandler(ucC1FlexGrid1_MouseDoubleClick);
            }
            catch
            {
            }
        }

        int rowsel = 0;
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            rowsel = 1;
            ucC1FlexGrid1.fg.AllowEditing = false;
            int rows = ucC1FlexGrid1.fg.RowSel;
            if (rows > 0)
            {
                if (oldRow == rows)
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
                    if (oldRow > 0 && dt.Rows.Count >= oldRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            oldRow = rows;
        }

       
        int oldRow2 = 0;
        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            ucC1FlexGrid1.fg.AllowEditing = false;
            int rows = ucC1FlexGrid1.fg.RowSel;
            if (rows > 0)
            {
                if (oldRow2 == rows)
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
                    if (oldRow2 > 0 && dt.Rows.Count >= oldRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.ucC1FlexGrid1.fg.Rows[oldRow2].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
                string fgid =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"]==null?"":ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                string fgpid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                string fgtime =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"]==null?"":ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                if (fgpid != "" && fgtime != "")
                {
                    frmGrade fGrade = new frmGrade(fgid, fgpid, fgtime);
                    fGrade.ShowDialog();
                }
            }
            oldRow2 = rows;
        }

        private void ucC1FlexGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    Point p = ucC1FlexGrid1.fg.PointToClient(Cursor.Position);
            //    if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)// �ж����Ƿ�����Ϣ������
            //    {
            //        contextMenuStripDeleteUpdate.Show(ucC1FlexGrid1, p);
            //    }
            //}

            int rows = ucC1FlexGrid1.fg.RowSel;
            if (rows > 0)
            {
                string fgid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                string fgpid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                string fgtime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                if (fgpid != "" && fgtime != "")
                {
                    frmGrade fGrade = new frmGrade(fgid, fgpid, fgtime);
                    fGrade.ShowDialog();
                }
            }
        }
        
    }
}
