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
    /// 查看主观历史报表
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
            //打印的权利
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
            dr["sick_area_name"] = "全院";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "sick_area_name";
            this.cboxSick.ValueMember = "said";
        }

        /// <summary>
        /// 设置加载显示数据
        /// </summary>
        private void SetHostoryPingFen()
        {
            //time = fmgr.SetTime();
            dataStart = dtpStart.Value.ToString("yyyy-MM-dd ");
            dataend = dtpEnd.Value.ToString("yyyy-MM-dd ");


            string selectSQL = "";

            if (this.cboxSick.Text == "全院")
            {
                selectSQL = "select ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生, sum(医疗分值) as 医疗分值 ,sum(护理分值) as 护理分值,max(医疗评分时间) as 医疗评分时间,max(护理评分时间) as 护理评分时间,max(医疗评审人) as 医疗评审人,max(护理评审人) as 护理评审人 " +
                                "from( " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生, sum_point as 医疗分值,null as 护理分值,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 医疗评分时间,null as 护理评分时间,b.grade_doc_name as 医疗评审人,'' as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生,null as 医疗分值 ,sum_point as 护理分值,null as 医疗评分时间,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 护理评分时间,'' as 医疗评审人,b.grade_doc_name as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "group by ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生 ";
            }
            else
            {
                selectSQL = "select ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生, sum(医疗分值) as 医疗分值 ,sum(护理分值) as 护理分值,max(医疗评分时间) as 医疗评分时间,max(护理评分时间) as 护理评分时间,max(医疗评审人) as 医疗评审人,max(护理评审人) as 护理评审人 " +
                                "from( " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生, sum_point as 医疗分值,null as 护理分值,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 医疗评分时间,null as 护理评分时间,b.grade_doc_name as 医疗评审人,'' as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生,null as 医疗分值 ,sum_point as 护理分值,null as 医疗评分时间,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 护理评分时间,'' as 医疗评审人,b.grade_doc_name as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "where 病区='" + this.cboxSick.Text + "' "+
                                "group by ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生 ";

                if (cbxDoctor.SelectedIndex != 0 && cbxDoctor.SelectedIndex != -1)//按管床医生查询
                {
                    selectSQL = "select ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生, sum(医疗分值) as 医疗分值 ,sum(护理分值) as 护理分值,max(医疗评分时间) as 医疗评分时间,max(护理评分时间) as 护理评分时间,max(医疗评审人) as 医疗评审人,max(护理评审人) as 护理评审人 " +
                                "from( " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生, sum_point as 医疗分值,null as 护理分值,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 医疗评分时间,null as 护理评分时间,b.grade_doc_name as 医疗评审人,'' as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'D' and a.sick_doctor_id ='" + cbxDoctor.SelectedValue.ToString() + "' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name " +
                                "union all " +
                                "select a.id as ID, in_area_name as 病区, a.pid as 住院号, patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, Sick_Doctor_Name as 管床医生,null as 医疗分值 ,sum_point as 护理分值,null as 医疗评分时间,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 护理评分时间,'' as 医疗评审人,b.grade_doc_name as 护理评审人 " +
                                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid " +
                                "where to_char(a.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' and b.emptype = 'N' and a.sick_doctor_id ='" + cbxDoctor.SelectedValue.ToString() + "' " +
                                "group by  grade_time,a.pid,a.id, in_area_name,patient_name,in_time,die_time,Sick_Doctor_Name,sum_point,b.grade_doc_name) " +
                                "where 病区='" + this.cboxSick.Text + "' " +
                                "group by ID, 病区, 住院号, 患者姓名, 住院日期,出院日期, 管床医生 ";
                }
            }

            dt = App.GetDataSet(selectSQL).Tables[0];

            DataColumn d = new DataColumn("总分", typeof(double));
            dt.Columns.Add(d);

            this.ucC1FlexGrid1.fg.DataSource = dt;

            this.ucC1FlexGrid1.fg.Cols["ID"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["病区"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["住院号"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["住院日期"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["出院日期"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["管床医生"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["医疗分值"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["护理分值"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["医疗评分时间"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["护理评分时间"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["总分"].Width = 95;

            this.ucC1FlexGrid1.fg.Cols["医疗评分时间"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["护理评分时间"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["医疗评审人"].Visible = false;
            this.ucC1FlexGrid1.fg.Cols["护理评审人"].Visible = false;


            this.ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //改变c1列的长度
            for (int i = 1; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                //this.ucC1FlexGrid1.fg.Cols[i].Width = 123;
                this.ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }

            for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(this.ucC1FlexGrid1.fg[i, "医疗分值"].ToString()) && !string.IsNullOrEmpty(this.ucC1FlexGrid1.fg[i, "护理分值"].ToString()))
                {
                    string zongfen = (Convert.ToDouble(this.ucC1FlexGrid1.fg[i, "医疗分值"].ToString()) * 0.9 + Convert.ToDouble(this.ucC1FlexGrid1.fg[i, "护理分值"].ToString()) * 0.1).ToString("0.00");
                    this.ucC1FlexGrid1.fg[i, "总分"] = zongfen;
                }
            }
        }
        /// <summary>
        /// 根据ID进行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel<= 0)
            {
                App.Msg("没有选中要删除的信息，不能删除");
                return;
            }
            string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();

            string deleteSQL = "delete t_Doc_Grade where pid='" + pid + "'";
            if (App.Ask("您确定要删除吗"))
            {
                if (App.ExecuteSQL(deleteSQL) > 0)
                    App.Msg("删除成功");
                SetHostoryPingFen();//刷新下
                if (dt.Rows.Count < 1)
                {
                    this.Close();
                    fmgr.button5_Click(sender, e);
                }
            }
        }
        /// <summary>
        /// 把管床医生姓名传过去
        /// </summary>
        /// <returns></returns> 
        public string SetSuffererName()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "管床医生"].ToString();
        }
        /// <summary>
        /// 编辑扣分值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("您还未选中要编辑的人");
                return;
            }
            frmGrade fg = new frmGrade(this);
            //App.AddNewChildForm(fg);
            fg.ShowDialog();
        }
        /// <summary>
        /// 把选中ID传过去 进行评分编辑
        /// </summary>
        public string SetPingFenID()
        {
            string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
            return id;
        }

        /// <summary>
        /// 把患者ID传过去（ID）
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
                App.Msg("还没选中人吧");
                return "";
            }
        }

        /// <summary>
        /// 医疗评审人
        /// </summary>
        public string SetPingFenName()
        {
            string name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "医疗评审人"].ToString();
            return name;
        }

        /// <summary>
        /// 护理评审人
        /// </summary>
        public string SetPingFenNameNurse()
        {
            string name = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "护理评审人"].ToString();
            return name;
        }

        /// <summary>
        /// 把选中评分时间传过去 进行评分编辑
        /// </summary>
        public string SetPingFenTime()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "医疗评分时间"].ToString();
            return time;
        }

        /// <summary>
        /// 把选中评分时间传过去 进行评分编辑(护理)
        /// </summary>
        public string SetPingFenTimeNurse()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "护理评分时间"].ToString();
            return time;
        }


        ///// <summary>
        ///// 把选中评分时间传过去 进行评分编辑
        ///// </summary>
        //public string SetPingFenItem_ID()
        //{
        //    string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分时间"].ToString();
        //    return time;
        //}

        /// <summary>
        /// 把评过的总分传过来
        /// </summary>
        /// <param name="values">100-扣分数（总分）</param>
        public void SetFenzhi(double values)
        {
            ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "医疗分值"] = values;
        }

        /// <summary>
        /// 把评过的总分传过来(护理)
        /// </summary>
        /// <param name="values">100-扣分数（总分）</param>
        public void SetFenzhiNurse(double values)
        {
            ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "护理分值"] = values;
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
                    //如果不是头行
                    if (rows > 0)
                    {
                        //就改变背景色
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    }
                    if (oldRow > 0 && dt.Rows.Count >= oldRow)
                    {
                        //定义上一次点击过的行还原
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
                    //如果不是头行
                    if (rows > 0)
                    {
                        //就改变背景色
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    }
                    if (oldRow2 > 0 && dt.Rows.Count >= oldRow)
                    {
                        //定义上一次点击过的行还原
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
                if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)// 判断他是否在信息行里面
                {
                    contextMenuStripDeleteUpdate.Show(ucC1FlexGrid1, p);

                    if (string.IsNullOrEmpty(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "医疗分值"].ToString()))
                    {
                        编辑ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        编辑ToolStripMenuItem.Enabled = true;
                    }

                    if (string.IsNullOrEmpty(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "护理分值"].ToString()))
                    {
                        护理编辑ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        护理编辑ToolStripMenuItem.Enabled = true;
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
            this.ucC1FlexGrid1.fg.PrintGrid("评分报表", PrintGridFlags.FitToPageWidth|PrintGridFlags.ShowPreviewDialog);
        }

        private void 护理编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("您还未选中要编辑的人");
                return;
            }
            frmGradeNurse fg = new frmGradeNurse(this);
            //App.AddNewChildForm(fg);
            fg.ShowDialog();
        }

        private void 护理报表toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("您还未选中患者");
                return;
            }
            frmGradeReport fgr = new frmGradeReport(this, "N");
            //fgr.ShowDialog();
            fgr.printGrid();
        }

        private void 医疗报表toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("您还未选中患者");
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
        /// 获得当前科室的医生(有证)
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
                    dr["user_name"] = "请选择";
                    dt.Rows.InsertAt(dr, 0);
                }

                cbxDoctor.DisplayMember = "user_name";
                cbxDoctor.ValueMember = "user_id";
                cbxDoctor.DataSource = dt.DefaultView;
            }
        }
    }
}