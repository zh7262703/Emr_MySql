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

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// �鿴������ʷ����
    /// </summary>
    public partial class frmMainSelectHistoryRepart : DevComponents.DotNetBar.Office2007Form
    {
        UserRights userRights = new UserRights();
        ucfrmMainGradeRepart fmgr;
        ucfrmMainGradeRepartDoctor fmgrDoctor;
        ucfrmMainGradeRepartSection fmgrSection;
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            SetHostoryPingFen();
            SetSickName();
        }
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepartDoctor _fmgrDoctor)
        {
            InitializeComponent();
            this.fmgrDoctor = _fmgrDoctor;
            SetHostoryPingFen();
            SetSickName();
        }
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepartSection _fmgrSection)
        {
            InitializeComponent();
            this.fmgrSection = _fmgrSection;
            SetHostoryPingFen();
            SetSickName();
        }
        public frmMainSelectHistoryRepart(ucfrmMainGradeRepart _fmgr, ArrayList buttonRights)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            SetHostoryPingFen();
            SetSickName();
            this.buttonX1.Enabled = false;
            //��ӡ��Ȩ��
            if (userRights.isExistRole("ttsbtnPrint", buttonRights))
            {
                this.buttonX1.Enabled = true;
            }
        }
        DataTable dt;
        string dataStart = "";
        string dataend = "";

        private void SetSickName()
        {
            string sickSQL = "select said, sick_area_name from t_sickareainfo";
            DataSet ds = App.GetDataSet(sickSQL);
            DataRow dr = ds.Tables[0].NewRow();
            dr["said"] = "0";
            dr["sick_area_name"] = "ȫԺ";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "sick_area_name";
            this.cboxSick.ValueMember = "said";
        }

        /// <summary>
        /// ���ü�����ʾ����
        /// </summary>
        private void SetHostoryPingFen()
        {
            //time = fmgr.SetTime();
            dataStart = dtpStart.Value.ToString("yyyy-MM-dd ");
            dataend = dtpEnd.Value.ToString("yyyy-MM-dd ");


            string selectSQL = "";

            if (this.cboxSick.Text == "ȫԺ")
            {
                selectSQL = "select ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ��, sum(ҽ�Ʒ�ֵ) as ҽ�Ʒ�ֵ ,sum(�����ֵ) as �����ֵ,max(ҽ������ʱ��) as ҽ������ʱ��,max(��������ʱ��) as ��������ʱ��,max(ҽ��������) as ҽ��������,max(����������) as ���������� " +
                                "from( " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��, sum_point as ҽ�Ʒ�ֵ,null as �����ֵ,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ҽ������ʱ��,null as ��������ʱ��,b.grade_doc_name as ҽ��������,'' as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��,null as ҽ�Ʒ�ֵ ,sum_point as �����ֵ,null as ҽ������ʱ��,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ��������ʱ��,'' as ҽ��������,b.grade_doc_name as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "group by ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ�� ";
            }
            else
            {
                selectSQL = "select ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ��, sum(ҽ�Ʒ�ֵ) as ҽ�Ʒ�ֵ ,sum(�����ֵ) as �����ֵ,max(ҽ������ʱ��) as ҽ������ʱ��,max(��������ʱ��) as ��������ʱ��,max(ҽ��������) as ҽ��������,max(����������) as ���������� " +
                                "from( " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��, sum_point as ҽ�Ʒ�ֵ,null as �����ֵ,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ҽ������ʱ��,null as ��������ʱ��,b.grade_doc_name as ҽ��������,'' as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��,null as ҽ�Ʒ�ֵ ,sum_point as �����ֵ,null as ҽ������ʱ��,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ��������ʱ��,'' as ҽ��������,b.grade_doc_name as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "where ����='" + this.cboxSick.Text + "' "+
                                "group by ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ�� ";

                if (cbxDoctor.SelectedIndex != 0 && cbxDoctor.SelectedIndex != -1)//���ܴ�ҽ����ѯ
                {
                    selectSQL = "select ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ��, sum(ҽ�Ʒ�ֵ) as ҽ�Ʒ�ֵ ,sum(�����ֵ) as �����ֵ,max(ҽ������ʱ��) as ҽ������ʱ��,max(��������ʱ��) as ��������ʱ��,max(ҽ��������) as ҽ��������,max(����������) as ���������� " +
                                "from( " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��, sum_point as ҽ�Ʒ�ֵ,null as �����ֵ,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ҽ������ʱ��,null as ��������ʱ��,b.grade_doc_name as ҽ��������,'' as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' and a.sick_doctor_id ='" + cbxDoctor.SelectedValue.ToString() + "' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as ����, a.pid as סԺ��, patient_name as ��������, in_time as סԺ����,die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ��,null as ҽ�Ʒ�ֵ ,sum_point as �����ֵ,null as ҽ������ʱ��,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ��������ʱ��,'' as ҽ��������,b.grade_doc_name as ���������� " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' and a.sick_doctor_id ='" + cbxDoctor.SelectedValue.ToString() + "' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "where ����='" + this.cboxSick.Text + "' " +
                                "group by ID, ����, סԺ��, ��������, סԺ����,��Ժ����, �ܴ�ҽ�� ";
                }
            }

            dt = App.GetDataSet(selectSQL).Tables[0];

            DataColumn d = new DataColumn("�ܷ�", typeof(double));
            dt.Columns.Add(d);

            this.ucC1FlexGrid1.fg.DataSource = dt;

            this.ucC1FlexGrid1.fg.Cols["ID"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["����"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["סԺ��"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["��������"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["סԺ����"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["��Ժ����"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["�ܴ�ҽ��"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["ҽ�Ʒ�ֵ"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["�����ֵ"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["ҽ������ʱ��"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["��������ʱ��"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["�ܷ�"].Width = 95;

            this.ucC1FlexGrid1.fg.Cols["ҽ������ʱ��"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["��������ʱ��"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["ҽ��������"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["����������"].Visible = false;


            this.ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //�ı�c1�еĳ���
            for (int i = 1; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                //this.ucC1FlexGrid1.fg.Cols[i].Width = 123;
                this.ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }

            for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(this.ucC1FlexGrid1.fg[i, "ҽ�Ʒ�ֵ"].ToString()) && !string.IsNullOrEmpty(this.ucC1FlexGrid1.fg[i, "�����ֵ"].ToString()))
                {
                    string zongfen = (Convert.ToDouble(this.ucC1FlexGrid1.fg[i, "ҽ�Ʒ�ֵ"].ToString()) * 0.9 + Convert.ToDouble(this.ucC1FlexGrid1.fg[i, "�����ֵ"].ToString()) * 0.1).ToString("0.00");
                    this.ucC1FlexGrid1.fg[i, "�ܷ�"] = zongfen;
                }
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

            string deleteSQL = "delete t_Doc_Grade where pid='" + pid + "'";
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
        /// ��ѡ��ID����ȥ �������ֱ༭
        /// </summary>
        public string SetPingFenID()
        {
            string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "סԺ��"].ToString();
            return id;
        }

        /// <summary>
        /// �ѻ���ID����ȥ��ID��
        /// </summary>
        /// <returns></returns>
        public string SetPatientID()
        {
            if (ucC1FlexGrid1.fg.RowSel >= 0)
            {
                return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
            }
            else
            {
                App.Msg("��ûѡ���˰�");
                return "";
            }
        }

        /// <summary>
        /// ҽ��������
        /// </summary>
        public string SetPingFenName()
        {
            string name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ҽ��������"].ToString();
            return name;
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string SetPingFenNameNurse()
        {
            string name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����������"].ToString();
            return name;
        }

        /// <summary>
        /// ��ѡ������ʱ�䴫��ȥ �������ֱ༭
        /// </summary>
        public string SetPingFenTime()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ҽ������ʱ��"].ToString();
            return time;
        }

        /// <summary>
        /// ��ѡ������ʱ�䴫��ȥ �������ֱ༭(����)
        /// </summary>
        public string SetPingFenTimeNurse()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������ʱ��"].ToString();
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
            ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ҽ�Ʒ�ֵ"] = values;
        }

        /// <summary>
        /// ���������ִܷ�����(����)
        /// </summary>
        /// <param name="values">100-�۷������ܷ֣�</param>
        public void SetFenzhiNurse(double values)
        {
            ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����ֵ"] = values;
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

                    if (string.IsNullOrEmpty(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ҽ�Ʒ�ֵ"].ToString()))
                    {
                        �༭ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        �༭ToolStripMenuItem.Enabled = true;
                    }

                    if (string.IsNullOrEmpty(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����ֵ"].ToString()))
                    {
                        ����༭ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        ����༭ToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetHostoryPingFen();
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.ucC1FlexGrid1.fg.PrintGrid("���ֱ���", PrintGridFlags.FitToPageWidth|PrintGridFlags.ShowPreviewDialog);
        }

        private void ����༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("����δѡ��Ҫ�༭����");
                return;
            }
            frmGradeNurse fg = new frmGradeNurse(this);
            //App.AddNewChildForm(fg);
            fg.ShowDialog();
        }

        private void ������toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("����δѡ�л���");
                return;
            }
            frmGradeReport fgr = new frmGradeReport(this, "N");
            //fgr.ShowDialog();
            fgr.printGrid();
        }

        private void ҽ�Ʊ���toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("����δѡ�л���");
                return;
            }
            frmGradeReport fgr = new frmGradeReport(this, "D");
            //fgr.ShowDialog();
            fgr.printGrid();
        }

        private void cboxSick_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDoctor.DataSource = null;
            if (Convert.ToInt32(this.cboxSick.SelectedIndex) != 0)
            {
                GetDoctor();
            }
        }

        /// <summary>
        /// ��õ�ǰ���ҵ�ҽ��(��֤)
        /// </summary>
        private void GetDoctor()
        {
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + this.cboxSick.SelectedValue.ToString() + "' and  e.role_type='D' and a.Profession_Card='true'";
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                DataTable dt = dsuser.Tables[0];
                if (dt != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["user_id"] = 0;
                    dr["user_name"] = "��ѡ��";
                    dt.Rows.InsertAt(dr, 0);
                }

                cbxDoctor.DisplayMember = "user_name";
                cbxDoctor.ValueMember = "user_id";
                cbxDoctor.DataSource = dt.DefaultView;
            }
        }
    }
}