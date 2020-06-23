using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using System.Collections;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;

namespace Base_Function.BLL_MANAGEMENT
{
    /// <summary>
    /// �鿴������ʷ����
    /// </summary>
    /// �޸� ������
    /// �޸�ʱ�� 2013��12��25��
    public partial class frmMainSelectHistoryRepart : DevComponents.DotNetBar.Office2007Form
    {
        UserRights userRights = new UserRights();
        ucfrmMainGradeRepart fmgr;
        DataTable dt;
        string time = "";
        string section_name = "";
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            SetHostoryPingFen();
        }
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepart _fmgr, ArrayList buttonRights)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            SetHostoryPingFen();
            this.buttonX1.Enabled = false;
            //��ӡ��Ȩ��
            //if (userRights.isExistRole("ttsbtnPrint", buttonRights))
            //{
            //    this.buttonX1.Enabled = true;
            //}
        }
        
        /// <summary>
        /// ���ü�����ʾ����
        /// </summary>
        private void SetHostoryPingFen()
        {
            time = fmgr.SetTime();
            section_name = fmgr.SetSection_name();
            string selectSQL = "select a.id as ID, SECTION_NAME as ����, a.pid as סԺ��, " +
                "patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, " +
                "Sick_Doctor_Name as �ܴ�ҽ��, (case when (100 - sum(down_point)) is null then 100 else (100 - sum(down_point)) end) as ��ֵ,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,b.grade_doc_name as ������ " +
                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid where a.SECTION_NAME like '" + section_name + "' and to_char(b.grade_time,'yyyy-MM-dd HH24:mi:ss')='" + time + "' group by " +
                " grade_time,a.pid,a.id, SECTION_NAME,patient_name,in_time,die_time,Sick_Doctor_Name,grade_doc_name";
            if (section_name == "ҽ���" || section_name == "�ʿؿ�")
            {
                selectSQL = selectSQL.Replace("a.SECTION_NAME", "OPERATE_SECTION");
            }

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
        /// <summary>
        /// ����ID����ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel<= 0)
            {
                App.Msg("û��ѡ��Ҫɾ������Ϣ������ɾ��");
                return;
            }
            string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();

            string deleteSQL = "delete t_Doc_Grade where pid='" + pid + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + time + "'";
            if (App.Ask("��ȷ��Ҫɾ����"))
            {
                if (App.ExecuteSQL(deleteSQL) > 0)
                    App.Msg("ɾ���ɹ�");
                SetHostoryPingFen();//ˢ����
                if (dt.Rows.Count < 1)
                {
                    this.Close();
                    fmgr.button5_Click(sender, e);
                }
            }
        }
        /// <summary>
        /// �ѹܴ�ҽ����������ȥ
        /// </summary>
        /// <returns></returns> 
        public string SetSuffererName()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�ܴ�ҽ��"].ToString();
        }
        /// <summary>
        /// �༭�۷�ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("����δѡ��Ҫ�༭����");
                return;
            }
            frmGrade fg = new frmGrade(this);
            //App.AddNewChildForm(fg);
            fg.ShowDialog();
        }
        /// <summary>
        /// ��ѡ��pID����ȥ �������ֱ༭
        /// </summary>
        public string SetPingFenPID()
        {
            string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
            return pid;
        }
        /// <summary>
        /// ��ѡ�еĲ���id����ȥ �������ֱ༭
        /// </summary>
        public string SetPingFenID()
        {
            string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
            return id;
        }
        /// <summary>
        /// ��ѡ������ʱ�䴫��ȥ �������ֱ༭
        /// </summary>
        public string SetPingFenTime()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
            return time;
        }
        ///// <summary>
        ///// ��ѡ������ʱ�䴫��ȥ �������ֱ༭
        ///// </summary>
        //public string SetPingFenItem_ID()
        //{
        //    string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
        //    return time;
        //}
        /// <summary>
        /// ���������ִܷ�����
        /// </summary>
        /// <param name="values">100-�۷������ܷ֣�</param>
        public void SetFenzhi(double values)
        {
            ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 8] = values;
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

        private void frmMainSelectHistoryRepart_Load(object sender, EventArgs e)
        {
            try
            {
                
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
                ucC1FlexGrid1.fg.MouseClick += new MouseEventHandler(ucC1FlexGrid1_MouseClick);
            }
            catch
            {
            }

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
                string fgid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                string fgpid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
                string fgtime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
                if (fgpid != "" && fgtime != "")
                {
                    frmGrade fGrade = new frmGrade(fgid, fgpid, fgtime);
                    fGrade.ShowDialog();
                }
            }
            oldRow2 = rows;
        }

        private void ucC1FlexGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = ucC1FlexGrid1.fg.PointToClient(Cursor.Position);
                if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)// �ж����Ƿ�����Ϣ������
                {
                    contextMenuStripDeleteUpdate.Show(ucC1FlexGrid1, p);
                }
            }
        }

        /// <summary>
        /// ҽ��վ��½������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripDeleteUpdate_Opening(object sender, CancelEventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                ɾ��ToolStripMenuItem.Visible=false;
                �༭ToolStripMenuItem.Visible = false;
            }
        }
    }
}