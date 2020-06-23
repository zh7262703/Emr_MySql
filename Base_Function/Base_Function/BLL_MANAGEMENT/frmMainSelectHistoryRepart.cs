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
    /// 查看主观历史报表
    /// </summary>
    /// 修改 李文明
    /// 修改时间 2013年12月25号
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
            //打印的权利
            //if (userRights.isExistRole("ttsbtnPrint", buttonRights))
            //{
            //    this.buttonX1.Enabled = true;
            //}
        }
        
        /// <summary>
        /// 设置加载显示数据
        /// </summary>
        private void SetHostoryPingFen()
        {
            time = fmgr.SetTime();
            section_name = fmgr.SetSection_name();
            string selectSQL = "select a.id as ID, SECTION_NAME as 科室, a.pid as 住院号, " +
                "patient_name as 患者姓名, in_time as 住院日期,die_time as 出院日期, " +
                "Sick_Doctor_Name as 管床医生, (case when (100 - sum(down_point)) is null then 100 else (100 - sum(down_point)) end) as 分值,to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 评分时间,b.grade_doc_name as 评分人 " +
                "from T_IN_Patient a join t_Doc_Grade b on a.pid=b.pid where a.SECTION_NAME like '" + section_name + "' and to_char(b.grade_time,'yyyy-MM-dd HH24:mi:ss')='" + time + "' group by " +
                " grade_time,a.pid,a.id, SECTION_NAME,patient_name,in_time,die_time,Sick_Doctor_Name,grade_doc_name";
            if (section_name == "医务科" || section_name == "质控科")
            {
                selectSQL = selectSQL.Replace("a.SECTION_NAME", "OPERATE_SECTION");
            }

            dt = App.GetDataSet(selectSQL).Tables[0];
            this.ucC1FlexGrid1.fg.DataSource = dt;

            this.ucC1FlexGrid1.fg.Cols["ID"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["科室"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["住院号"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["住院日期"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["出院日期"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["管床医生"].Width = 80;
            this.ucC1FlexGrid1.fg.Cols["分值"].Width = 95;
            this.ucC1FlexGrid1.fg.Cols["评分时间"].Width = 145;
            this.ucC1FlexGrid1.fg.Cols["评分人"].Width = 80;

            this.ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //改变c1列的长度
            for (int i = 1; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                //this.ucC1FlexGrid1.fg.Cols[i].Width = 123;
                this.ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
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

            string deleteSQL = "delete t_Doc_Grade where pid='" + pid + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + time + "'";
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
        /// 把选中pID传过去 进行评分编辑
        /// </summary>
        public string SetPingFenPID()
        {
            string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
            return pid;
        }
        /// <summary>
        /// 把选中的病人id传过去 进行评分编辑
        /// </summary>
        public string SetPingFenID()
        {
            string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
            return id;
        }
        /// <summary>
        /// 把选中评分时间传过去 进行评分编辑
        /// </summary>
        public string SetPingFenTime()
        {
            string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分时间"].ToString();
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
                string fgid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                string fgpid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
                string fgtime = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分时间"] == null ? "" : ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分时间"].ToString();
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
                if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)// 判断他是否在信息行里面
                {
                    contextMenuStripDeleteUpdate.Show(ucC1FlexGrid1, p);
                }
            }
        }

        /// <summary>
        /// 医生站登陆都不显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripDeleteUpdate_Opening(object sender, CancelEventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                删除ToolStripMenuItem.Visible=false;
                编辑ToolStripMenuItem.Visible = false;
            }
        }
    }
}