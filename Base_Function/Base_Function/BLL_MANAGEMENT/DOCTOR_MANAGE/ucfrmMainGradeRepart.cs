using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Bifrost;
using System.Collections;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// 主观评分报表用户控件
    /// </summary>
    /// 修改 李文明
    /// 修改时间 2013年12月25号
    public partial class ucfrmMainGradeRepart : UserControl
    {
        UserRights userRights = new UserRights();
        /// <summary>
        /// 选中病人id
        /// </summary>
        public string gid;
        /// <summary>
        /// 选中病人pid
        /// </summary>
        public string gpid;
        /// <summary>
        /// 默认选中科室
        /// </summary>
        public string sickname;

        /// <summary>
        /// 生产评分界面是否显示,默认显示
        /// </summary>
        public bool tabItemVisible = true;

        int selRow = 0;

        public ucfrmMainGradeRepart()
        {           
           InitializeComponent();
           AddComboxItem();
        }

        /// <summary>
        /// 工具栏指定科室传入
        /// </summary>
        /// <param name="sick_name"></param>
        public ucfrmMainGradeRepart(string sick_name)
        {
            sickname = sick_name;
            InitializeComponent();
            AddComboxItem();
        }

         /// <summary>
        /// 评分反馈指定科室传入
         /// </summary>
         /// <param name="sick_name">科室名</param>
         /// <param name="visbool">是否显示评分页</param>
        public ucfrmMainGradeRepart(string sick_name,bool visbool)
        {
            sickname = sick_name;
            InitializeComponent();
            //评分反馈只用看到历史评分
            tabItem1.Visible = visbool;
            AddComboxItem();
        }

        public ucfrmMainGradeRepart(ArrayList buttonRights)
        {
            try
            {
                InitializeComponent();
                SetSickName();
                AddComboxItem();
                this.cboxRand.SelectedIndex = 0;
                this.btnQuery.Enabled = false;
                this.btnAddGrade.Enabled = false;
                this.btnSave.Enabled = false;
                this.button5.Enabled = false;
                //书写的权利
                if (userRights.isExistRole("tsbtnWrite", buttonRights))
                {
                    this.btnAddGrade.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnQuery.Enabled = true;
                }
                //查看的权利
                if (userRights.isExistRole("tsbtnLook", buttonRights))
                {
                    this.button5.Enabled = true;
                }
            }
            catch
            {
            }
        }
        DataTable dt = new DataTable();//数据查询出来的时候第一次绑定的datatable
        DataView dv;//要进行随机抽取的时候保存数据的自定义视图
        DataTable dt2;//随机出来在绑定的datatable
        //DataRowView drview;
        private void SetSickName()
        {
            string sickSQL = "select sid,section_name from t_sectioninfo t where  enable_flag='Y' order by section_name";
            DataSet ds1 = App.GetDataSet(sickSQL);
            DataSet ds2 = App.GetDataSet(sickSQL);

            DataRow dr = ds1.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "全院";
            ds1.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds1.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "section_name";
            this.cboxSick.ValueMember = "sid";

            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "全院";
            ds2.Tables[0].Rows.InsertAt(dr, 0);
            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "1";
            dr["section_name"] = "质控科";
            ds2.Tables[0].Rows.InsertAt(dr, 1);
            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "2";
            dr["section_name"] = "医务科";
            ds2.Tables[0].Rows.InsertAt(dr, 2);
            this.cboxSickname.DataSource = ds2.Tables[0].DefaultView;
            this.cboxSickname.DisplayMember = "section_name";
            this.cboxSickname.ValueMember = "sid";

            if (sickname!=null&&sickname!="")
            {//是否工具栏操作进入
                this.cboxSick.Text = sickname;
                this.cboxSick.Enabled = false;
                this.cboxSickname.Text = sickname;
                this.cboxSickname.Enabled = false;
            }

        }

        /// <summary>
        /// 主观评分生成评分中"随机抽取"最大改为200份。
        /// </summary>
        private void AddComboxItem()
        {
            this.cboxRand.Items.Clear();
            for (int i = 1; i <= 200; i++)
            {
                this.cboxRand.Items.Add(i);
            }
            this.cboxRand.SelectedIndex = 0;
        }
        
        private void pingfentoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("您还未选中要评分的人");
                return;
            }
            frmGrade fg = new frmGrade(this);
            fg.ShowDialog();
        }
        /// <summary>
        /// 把住院号传过去（PID）
        /// </summary>
        /// <returns></returns>
        public string SetPingfen()
        {
            if (c1FlexGrid1.RowSel >= 0)
            {
                gid = c1FlexGrid1[c1FlexGrid1.RowSel, "编号"].ToString();
                gpid = c1FlexGrid1[c1FlexGrid1.RowSel, "住院号"].ToString();
                return gpid;
            }
            else
            {
                App.Msg("还没选中人吧");
                return "";
            }
        }
        /// <summary>
        /// 把管床医生姓名传过去
        /// </summary>
        /// <returns></returns> 
        public string SetSuffererName()
        {
            if (c1FlexGrid1.RowSel >= 0)
            {
                return c1FlexGrid1[c1FlexGrid1.RowSel, "管床医生"].ToString();
            }
            else
            {
                App.Msg("还没选中人吧");
                return "";
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("您还未选中要删除的人");
                return;
            }
            //删除不是删除数据库。而是把他选中的一行移除掉
            int r = c1FlexGrid1.Rows[c1FlexGrid1.RowSel].DataIndex;//选中的行
            if (r >= 0)
                dt2.Rows.RemoveAt(r);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //查看
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("您还未选中要查看的人");
                return;
            }
            frmMainSelectHistoryRepart fsht = new frmMainSelectHistoryRepart(this);
            fsht.ShowDialog();
        }
        /// <summary>
        /// 设置时间把评分的时间传过去
        /// </summary>
        /// <returns></returns>
        public string SetTime()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分时间"].ToString();
        }

        /// <summary>
        /// 把科室条件传过去
        /// </summary>
        /// <returns></returns>
        public string SetSection_name()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "评分科室"].ToString();
        }
        /// <summary>
        /// 点击新增评分病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            frmAddGradeRepart fagr = new frmAddGradeRepart(this, this.cboxSick.Text);
            App.ButtonStytle(fagr, false);
            fagr.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string num = this.cboxRand.Text;//查询多少条数
            string querySQL = "select id as 编号, SECTION_NAME as 科室, pid as 住院号, patient_name as 患者姓名, in_time as 住院日期, " +
                              "die_time as 出院日期, Sick_Doctor_Name as 管床医生 from T_IN_Patient where id not in(select distinct patient_id from t_Doc_Grade where patient_id is not null)  and die_time is not null ";
            if (this.cboxSick.Text == "全院")
            {
                querySQL += "and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
            }
            else
            {
                querySQL += "and SECTION_NAME='" + this.cboxSick.Text + "' and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
            }

            dt = App.GetDataSet(querySQL).Tables[0];//给数据源赋值

            Random rd = new Random();
            #region 随机效果
            //string where = "";
            //List<int> iList = new List<int>();
            //bool b = true;
            //if (dt.Rows.Count > Convert.ToInt32(this.cboxRand.Text))
            //{
            //    do
            //    {
            //        int numRand = rd.Next(0, dt.Rows.Count - 1);
            //        b = true;
            //        foreach (int var in iList)
            //        {
            //            if (numRand == var)
            //            {
            //                b = false;
            //                break;
            //            }
            //        }
            //        if (b)
            //        {
            //            iList.Add(numRand);
            //        }
            //    }
            //    while (iList.Count < Convert.ToInt32(this.cboxRand.Text));

            //    for (int i = 0; i < iList.Count; i++)
            //    {
            //        if (where == "")
            //        {
            //            where = dt.Rows[Convert.ToInt32(iList[i])]["ID"].ToString();
            //        }
            //        else
            //        {
            //            where = where + "," + dt.Rows[Convert.ToInt32(iList[i])]["ID"].ToString();
            //        }
            //    }
            //    if (where != "")
            //    {
            //        where = "id in (" + where + ")";
            //    }
            //}
            #endregion
            /*设计思路 首先我要根据他随机抽取条数循环多少次 循环一次产生一个随机数
             *然后循环判断产生的随机数里面有没有重复的数 如果有就把他移除，再重新产生
             * 直到没有重复的为止，然后给一个设定的值idlist赋值 idlist的值就是随机出来
             * 那每行记录的ID值
             */
            List<int> randSum = new List<int>();
            randSum.Clear();
            string idlist = "";//保存每行记录的ID

            int dtrowCount = dt.Rows.Count;//查询总条数
            int randm = Convert.ToInt32(this.cboxRand.Text);//需要随机查询的条数
            if (dtrowCount < randm)//如果查询总条数小于随机查询查询条数
            {
                randm = dtrowCount;//如果 需要随机查询的条数 大于 查询出来总的行数 就给需要随机查询的条数赋值成查询总的条数
                //第一个循环是随机抽取条数
                for (int i = 0; i < randm; i++)
                {
                    if (dt.Rows.Count <= 0)
                    {
                        App.Msg("未能找到数据");
                        c1FlexGrid1.Clear();
                        return;
                    }
                    //生成一个随机数，与datatable的行要一致（如果有10行 就要产生0到10之间的随机数）
                    int numSum = rd.Next(0, dt.Rows.Count);
                    //循环随机数集合里面的元素，如果有相同的就在循环一次
                    for (int j = 0; j < randSum.Count; j++)
                    {
                        if (randSum[j] == numSum)
                        {
                            //numSum = rd.Next(0, dt.Rows.Count - 1);

                            //如果有相同的就把他移除
                            randSum.RemoveAt(j);
                            i--;//移除了一个元素就要多i--多循环一次
                        }
                    }
                    //每次把循环出来的数添加到一个集合里面
                    randSum.Add(numSum);
                    //如果集合不为空idlist的值就是ID相加
                    if (idlist == "")
                    {
                        idlist = dt.Rows[numSum]["编号"].ToString();
                    }
                    else
                    {
                        idlist = idlist + "," + dt.Rows[numSum]["编号"].ToString();
                    }
                }
            }
            else
            {
                //第一个循环是随机抽取条数
                for (int i = 0; i < randm; i++)
                {
                    if (dt.Rows.Count <= 0)
                    {
                        App.Msg("未能找到数据");
                        c1FlexGrid1.Clear();
                        return;
                    }
                    //生成一个随机数，与datatable的行要一致（如果有10行 就要产生0到10之间的随机数）
                    int numSum = rd.Next(0, dt.Rows.Count);
                    //循环随机数集合里面的元素，如果有相同的就在循环一次
                    for (int j = 0; j < randSum.Count; j++)
                    {
                        if (randSum[j] == numSum)
                        {
                            //numSum = rd.Next(0, dt.Rows.Count - 1);

                            //如果有相同的就把他移除
                            randSum.RemoveAt(j);
                            i--;//移除了一个元素就要多i--多循环一次
                        }
                    }
                    //每次把循环出来的数添加到一个集合里面
                    randSum.Add(numSum);
                    //如果集合不为空idlist的值就是ID相加
                    if (idlist == "")
                    {
                        idlist = dt.Rows[numSum]["编号"].ToString();
                    }
                    else
                    {
                        idlist = idlist + "," + dt.Rows[numSum]["编号"].ToString();
                    }
                }
            }
            //如果idlist不为空就给idlist赋值
            if (idlist != "")
            {
                idlist = "编号 in (" + idlist + ")";
            }
            //Dataview是表示用于排序、筛选、搜索、编辑和导航的 System.Data.DataTable 的可绑定数据的自定义视图。
            dv = dt.DefaultView;

            //再进行筛选
            dv.RowFilter = idlist;

            dt2 = dv.ToTable();
            DataColumn d = new DataColumn("分值", typeof(double));
            dt2.Columns.Add(d);
            this.c1FlexGrid1.DataSource = dt2;//绑定数据源
            c1FlexGrid1.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //改变c1列的长度
            for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
            {
                c1FlexGrid1.Cols[i].Width = 123;
                c1FlexGrid1.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
        }
        /// <summary>
        /// 把评分值传过来
        /// </summary>
        /// <param name="values">100-扣分值</param>
        public void SetFenzhi(double values)
        {
            c1FlexGrid1[c1FlexGrid1.RowSel, 8] = values;
        }


        int setNum = 1;
        /// <summary>
        /// 新增时调用事件
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(Row row)
        {
            if (dt2 != null)
            {
                DataRow dr = dt2.NewRow();//new 行
                //drview = dv.AddNew();
                if (dr.Table.Columns.Count > 0)
                {
                    //给dataRow赋值
                    dr[0] = row[2].ToString();
                    dr[1] = row[3].ToString();
                    dr[2] = row[4].ToString();
                    dr[3] = row[5].ToString();
                    dr[4] = Convert.ToDateTime(row[6].ToString());
                    if (row[7].ToString() == "")
                    {
                        dr[5] = DBNull.Value;
                    }
                    else
                    {
                        dr[5] = Convert.ToDateTime(row[7].ToString());
                    }
                    dr[6] = row[8].ToString();

                    //dr[7] = row[9].ToString();
                    //drview["ID"] = row[2].ToString();
                    //drview["病区"] = row[3].ToString();
                    //drview["住院号"] = row[4].ToString();
                    //drview["患者姓名"] = row[5].ToString();
                    //drview["住院日期"] = Convert.ToDateTime(row[6].ToString());
                    //if (row[7].ToString() == "")
                    //{
                    //    drview["出院日期"] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    drview["出院日期"] = Convert.ToDateTime(row[7].ToString());
                    //}
                    //drview["管床医生"] = row[8].ToString();
                    this.dt2.Rows.Add(dr);
                    this.c1FlexGrid1.DataSource = dt2;
                }
                //else
                //{
                //    //为了不让他每次循环都要执行所以只是让他执行一次
                //    if (setNum == 1)
                //    {
                //        App.Msg("新增之前原数据结构要存在");
                //        setNum++;
                //    }
                //}
            }
            else
            {
                if (setNum == 1)
                {
                    App.Msg("新增之前原数据结构要存在");
                    setNum++;
                }
            }

        }
        int oldRow = 0;
        /// <summary>
        /// 单击c1FlexGrid1事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            selRow = 1;
            c1FlexGrid1.AllowEditing = false;


            int rows = this.c1FlexGrid1.RowSel;//定义选中的行号 
            if (rows > 0)
            {
                if (oldRow == rows)
                {
                    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //如果不是头行
                    if (rows > 0)
                    {
                        //就改变背景色
                        this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow > 0 && dt2.Rows.Count >= oldRow)
                    {
                        //定义上一次点击过的行还原
                        this.c1FlexGrid1.Rows[oldRow].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    }
                    //else
                    //{
                    //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    //}
                }
            }
            //给上一次的行号赋值
            oldRow = rows;
        }
        List<string> itmeList = new List<string>();
        /// <summary>
        ///  保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //执行要插入的所有sql语句
            if (App.ExecuteBatch(itmeList.ToArray()) > 0)
            {
                App.Msg("保存成功");
                //每次保存一次都要清空一次
                itmeList.Clear();
            }
            else
            {
                App.Msg("保存失败");
                itmeList.Clear();
            }

        }
        /// <summary>
        /// 返回来的list是所有要插入的评分项
        /// </summary>
        /// <param name="list"></param>
        public void addPingFen(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                itmeList.Add(list[i]);
            }
        }
        /// <summary>
        /// 单击查询历史报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DataTable history;
        public void button5_Click(object sender, EventArgs e)
        {
            
            //历史报表查询时根据评分时间相同 分个组，查出一条记录
            string selectSQL = "select to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 评分时间,t.SECTION_NAME as 评分科室  " +
                               " from t_doc_grade g inner join t_in_patient t on g.patient_id=t.id where "+
                               " to_char(grade_time,'yyyy-MM') like '" + dateTimePicker2.Text + "%' "+
                               " {0}  group by grade_time,t.SECTION_NAME "+
                               " order by grade_time desc,t.SECTION_NAME ";

            if (this.cboxSickname.Text == "医务科" || this.cboxSickname.Text == "质控科")
            {
                selectSQL = string.Format(selectSQL, "and OPERATE_SECTION='" + this.cboxSickname.Text + "'");
                selectSQL = selectSQL.Replace("t.SECTION_NAME", "OPERATE_SECTION");
            }
            else if (this.cboxSickname.Text == "全院")
            {
                selectSQL = string.Format(selectSQL, "");
            }
            else
            {
                selectSQL = string.Format(selectSQL, "and t.SECTION_NAME='" + this.cboxSickname.Text + "'");
            }
            
            history = App.GetDataSet(selectSQL).Tables[0];
            //DataColumn dc = new DataColumn("科室", typeof(string));
            //dc.DefaultValue = "全院";
            //history.Columns.Add(dc);
            ucC1FlexGrid1.fg.DataSource = history;
            this.ucC1FlexGrid1.fg.Cols["评分时间"].Width = 400;
            this.ucC1FlexGrid1.fg.Cols["评分科室"].Width = 400;
        }

        //看用户是否点击过UCC1控件如果点击了 就给他赋值为1
        int rowselect = 0;
        int rowselectold = 0;
        /// <summary>
        /// 单击历史报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            rowselect = 1;
            int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号
            if (rows > 0)
            {
                if (rowselectold == rows)
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
                    if (rowselectold > 0 && history.Rows.Count >= rowselect)
                    {
                        //定义上一次点击过的行还原
                        this.ucC1FlexGrid1.fg.Rows[rowselectold].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //给上一次的行号赋值
            rowselectold = rows;
        }
        private void frmMainGradeRepart_Load(object sender, EventArgs e)
        {
            try
            {                                  
                SetSickName();
                
                             
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
                ucC1FlexGrid1.fg.MouseClick += new MouseEventHandler(ucC1FlexGrid1_MouseClick);
                //btnQuery_Click(sender, e);
                ucC1FlexGrid1.fg.ContextMenuStrip = contextMenuStrip1;
            }
            catch
            {
            }
        }
        private void btntransitorily_Save_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 双击生成报表时
        /// </summary>
        int oldRow2 = 0;
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            c1FlexGrid1.AllowEditing = false;

            int rows = this.c1FlexGrid1.RowSel;//定义选中的行号
            if (rows > 0)
            {
                if (oldRow2 == rows)
                {
                    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //如果不是头行
                    if (rows > 0)
                    {
                        //就改变背景色
                        this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow2 > 0 && dt2.Rows.Count >= oldRow)
                    {
                        //定义上一次点击过的行还原
                        this.c1FlexGrid1.Rows[oldRow2].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    }
                }
                try
                {
                    string id = this.c1FlexGrid1[c1FlexGrid1.RowSel, "编号"].ToString().ToString();
                    if (id != null && id != "")
                    {
                        string sql = "select * from t_in_patient t where t.id='" + id + "'";
                        DataSet ds1 = App.GetDataSet(sql);
                        if (ds1 != null)
                        {
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                InPatientInfo patientInfo = new InPatientInfo();

                                patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                                patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                                //if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("男"))
                                //{
                                patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                                //}
                                //else
                                //{
                                //    patientInfo.Gender_Code = "1";
                                //}
                                patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                                patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                                patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                                patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                                patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                                patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                                patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                                patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                                patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                                patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                                patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                                patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                                patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                                if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                                    patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                                patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                                patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                                patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                                patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                                patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                                patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                                patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                                patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                                patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                                patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                                patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                                patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                                    patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                                else
                                {
                                    if (patientInfo.Age == "0")
                                    {
                                        patientInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(patientInfo.Birthday).Year);
                                        patientInfo.Age_unit = "岁";
                                    }
                                }
                                //inpatient.Action_State = row["action_state"].ToString();
                                patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                                patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                                    patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                                patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                                    patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                                patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["in_time"] != null)
                                    patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                                patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                                if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                                    patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                                patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                                patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                                patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                                if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                                    patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                                patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                                patientInfo.Nurse_Level = ds1.Tables[0].Rows[0]["nurse_level"].ToString();
                                patientInfo.Career = ds1.Tables[0].Rows[0]["Career"].ToString();//职业
                                patientInfo.Out_Id = ds1.Tables[0].Rows[0]["out_id"].ToString();//门诊号
                                patientInfo.Relation_name = ds1.Tables[0].Rows[0]["Relation_Name"].ToString();//联系人姓名


                                ucDoctorOperater fq = new ucDoctorOperater(patientInfo); //new ucDoctorOperater(patientInfo, false, patientInfo.Id);
                                App.UsControlStyle(fq);
                                App.AddNewBusUcControl(fq, "病人文书");
                                frmGrade fg = new frmGrade(this);
                                fg.Show();
                                fg.TopMost = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }


            }
            //给上一次的行号赋值
            oldRow2 = rows;
        }
        /// <summary>
        /// 双击历史 报表
        /// </summary>
        int hostoryRow = 0;
        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            ucC1FlexGrid1.fg.AllowEditing = false;
            int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号
            if (rows > 0)
            {
                if (hostoryRow == rows)
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
                    if (hostoryRow > 0 && history.Rows.Count >= hostoryRow)
                    {
                        //定义上一次点击过的行还原
                        this.ucC1FlexGrid1.fg.Rows[hostoryRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //给上一次的行号赋值
            hostoryRow = rows;
        }
        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = c1FlexGrid1.PointToClient(Cursor.Position);
                if (c1FlexGrid1.HitTest(e.X, e.Y).Row >= 1)//看是否在信息行里面
                {
                    ctmnspDelete.Show(c1FlexGrid1, p);
                }
            }
        }
        /// <summary>
        /// 历史报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = ucC1FlexGrid1.fg.PointToClient(Cursor.Position);
                if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)
                {
                    contextMenuStrip1.Show(ucC1FlexGrid1, p);
                }
            }
        }
    }
}
