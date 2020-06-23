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

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 主观评分用户控件
    /// </summary>
    public partial class ucfrmMainGradeRepartSection : UserControl
    {
        UserRights userRights = new UserRights();
        public int intMark = 0;
        public string strSectionName = "";
        public string strSectionId = "";
        public string strText = "2";//科室评分模块标识为2
        public string strDOCType = "";
        /// <summary>
        /// 运行病历评分
        /// </summary>
        public string strYunXingDoc = "";
        /// <summary>
        /// 终末病历评分
        /// </summary>
        public string strZhongMoDoc = "";
        /// <summary>
        /// 默认选中科室
        /// </summary>
        public string sickname;

        public ucfrmMainGradeRepartSection()
        {
            InitializeComponent();
        }

        public ucfrmMainGradeRepartSection(ArrayList buttonRights)
        {
            try
            {
                InitializeComponent();
                SetSickName();
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
            string sickSQL = "select a.section_name,a.sid from T_SECTIONINFO a inner join t_section_area  b on a.sid =b.sid";
            DataSet ds = App.GetDataSet(sickSQL);
            DataRow dr = ds.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = App.UserAccount.CurrentSelectRole.Section_name;
            ds.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "section_name";
            this.cboxSick.ValueMember = "sid";
        }
        /// <summary>
        /// 获取管床医生
        /// </summary>
        private void GetDoctor()
        {
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + strSectionId + "' and  e.role_type='D' and a.Profession_Card='true'";
            DataSet dsuser = App.GetDataSet(Sql);
            if (dsuser != null)
            {
                DataTable dt = dsuser.Tables[0];
                DataRow drnew = dt.NewRow();
                drnew["user_id"] = "0";
                drnew["user_name"] = "";
                dt.Rows.InsertAt(drnew, 0);
                if (dt != null)
                {
                    cbbDoctorr.DisplayMember = "user_name";
                    cbbDoctorr.ValueMember = "user_id";
                    cbbDoctorr.DataSource = dt.DefaultView;
                }
            }
        }
        int selRow = 0;
        private void pingfentoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("您还未选中要评分的人");
                return;
            }
            string sql = "select * from t_doc_grade where pid ='" + SetPingfen() + "' and alltypepf is not null ";
            string sql1 = "select * from t_doc_grade where pid ='" + SetPingfen() + "' and sectiontypepf is not null ";
            DataSet ds = App.GetDataSet(sql);
            DataSet ds1 = App.GetDataSet(sql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                App.Msg("该病案全院已评完！无法操作！");
                return;
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                App.Msg("该病案科室已评完！无法操作！");
                return;
            }
            if (checkBox2.Checked == true)
            {
                strDOCType = "1";
            }
            else
            {
                strDOCType = "2";
            }
            frmGrade fg = new frmGrade(this, strText, true, strDOCType);
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
                return c1FlexGrid1[c1FlexGrid1.RowSel, "住院号"].ToString();
            }
            else
            {
                App.Msg("还没选中人吧");
                return "";
            }
        }

        /// <summary>
        /// 把患者ID传过去（ID）
        /// </summary>
        /// <returns></returns>
        public string SetPatientID()
        {
            if (c1FlexGrid1.RowSel >= 0)
            {
                return c1FlexGrid1[c1FlexGrid1.RowSel, "编号"].ToString();
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
        /// 点击新增评分病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            frmAddGradeRepart fagr = new frmAddGradeRepart(this);
            App.ButtonStytle(fagr, false);
            fagr.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.ucC1FlexGrid1.fg.DataSource = null;
            string num = this.cboxRand.Text;//查询多少条数
            string querySQL = "";
            if (DateTime.Compare(DateTime.Parse(dtpInTime1.Value.ToString("yyyy-MM-dd")), DateTime.Parse(dtpIntime2.Value.ToString("yyyy-MM-dd"))) > 0)
            {
                App.Msg("入院日期填写错误！");
                return;
            }
            #region 终末评分
            if (checkBox2.Checked == true)
            {
                strZhongMoDoc = "1";
                querySQL =
                 " select distinct a.id as 编号,regexp_substr(a.his_id,'[^-]+',1,1) as 病人id,(select section_name from t_sectioninfo where sid= a.section_id) as 科室, a.pid as 住院号, a.patient_name as 患者姓名, to_char(a.in_time, 'yyyy-MM-dd HH24:mi') as 入院日期, to_char(a.die_time, 'yyyy-MM-dd HH24:mi') as 出院日期, a.Sick_Doctor_Name as 管床医生, " +
                 "(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'D' and b.alltypepf='1') as 全院医疗分值, " +
                "(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.alltypepf='1') as 全院护理分值," +
                "(select max(b.sum_point)  from t_Doc_Grade b  where a.pid=b.pid and b.emptype = 'D' and b.sectiontypepf='2') as 科室医疗分值," +
                " (select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.sectiontypepf='2') as 科室护理分值," +
                " (select max(b.sum_point)  from t_Doc_Grade b  where a.pid=b.pid and b.emptype = 'D' and b.doctortypepf='3') as 医生医疗分值," +
                " (select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.doctortypepf='3') as 医生护理分值" +
                " from T_IN_Patient a left join t_Doc_Grade b on a.pid =b.pid where 1=1";


                //                else
                //                {
                //                    querySQL = @"select distinct(c.sum_point) as 分值, 
                //                               a.id as 编号,
                //                               b.section_name as 科室,
                //                               regexp_substr(a.his_id, '[^-]+', 1, 1) as id,
                //                               a.pid as 住院号,
                //                               a.patient_name as 患者姓名,
                //                               a.in_time as 住院日期,
                //                               a.die_time as 出院日期,
                //                               a.Sick_Doctor_Name as 管床医生
                //                          from T_IN_Patient a, t_sectioninfo b, t_doc_grade c
                //                         where a.section_id = b.sid  and a.pid =c.pid";
                //                }
            }
            #endregion
            #region 运行病历
            if (checkBox1.Checked == true)
            {
                strYunXingDoc = "2";
                querySQL =
              " select distinct a.id as 编号,regexp_substr(a.his_id,'[^-]+',1,1) as 病人id,(select section_name from t_sectioninfo where sid= a.section_id) as 科室, a.pid as 住院号, a.patient_name as 患者姓名, to_char(a.in_time, 'yyyy-MM-dd HH24:mi') as 入院日期, to_char(a.die_time, 'yyyy-MM-dd HH24:mi') as 出院日期, a.Sick_Doctor_Name as 管床医生, " +
              "(100-(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'D' and b.alltypepf='1')) as 全院医疗扣分值, " +
             "(100-(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.alltypepf='1')) as 全院护理扣分值," +
             "(100-(select max(b.sum_point)  from t_Doc_Grade b  where a.pid=b.pid and b.emptype = 'D' and b.sectiontypepf='2')) as 科室医疗扣分值," +
             " (100-(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.sectiontypepf='2')) as 科室护理扣分值," +
             " (100-(select max(b.sum_point)  from t_Doc_Grade b  where a.pid=b.pid and b.emptype = 'D' and b.doctortypepf='3')) as 医生医疗扣分值," +
             " (100-(select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'N' and b.doctortypepf='3')) as 医生护理扣分值" +
             " from T_IN_Patient a left join t_Doc_Grade b on a.pid =b.pid where a.die_time is null";
            }
            #endregion


            if (this.cboxSick.Text == "全院" )
            {
                if (strZhongMoDoc == "1")
                {
                    querySQL += " and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
                }
            }
            else
            {
                if (strZhongMoDoc == "1")
                {
                    querySQL += " and (select section_name from t_sectioninfo where sid = a.section_id)='" + this.cboxSick.Text + "' and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
                }
                if (strYunXingDoc == "2")
                {
                    querySQL += " and (select section_name from t_sectioninfo where sid = a.section_id)='" + this.cboxSick.Text + "'";

                }
            }
            if (txtName.Text != "")
            {
                querySQL += " and a.patient_name='" + txtName.Text.ToString() + "'";
            }
            if (txtZYH.Text != "")
            {
                querySQL += " and regexp_substr(a.his_id, '[^-]+', 1, 1) = '" + txtZYH.Text.ToString() + "'";
            }
            if (this.cbbDoctorr.Text != "")
            {
                querySQL += " and a.Sick_Doctor_Name='" + cbbDoctorr.Text.ToString() + "'";
            }
            if (checkBox7.Checked == true)
            {

                //允许查看历史评分
                if (checkBox5.Checked == true)
                {
                    //querySQL += " and  (select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'D' and b.alltypepf='1')";//查看全院历史评分
                    querySQL += " and (select distinct(b.alltypepf) from t_Doc_Grade b where a.pid = b.pid and b.emptype = 'D' and b.alltypepf = '1') =1";
                }
                if (checkBox4.Checked == true)
                {
                    //querySQL += " and  (select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'D' and b.sectiontypepf='1')";//查看科室历史评分
                    querySQL += " and (select distinct(b.sectiontypepf) from t_Doc_Grade b where a.pid = b.pid and b.emptype = 'D' and b.sectiontypepf = '2') =2";
                }
                if (checkBox3.Checked == true)
                {
                    //querySQL += " and  (select max(b.sum_point) from t_Doc_Grade b where a.pid=b.pid and b.emptype = 'D' and b.doctortypepf='1')";//查看医生历史评分
                    querySQL += " and (select distinct(b.doctortypepf) from t_Doc_Grade b where a.pid = b.pid and b.emptype = 'D' and b.doctortypepf = '3') =3";
                }
                if (checkBox6.Checked == true)
                {
                    querySQL += " and  to_char(b.grade_time,'yyyy-MM')>='" + datePFStart.Text + "' and to_char(b.grade_time,'yyyy-MM')<='" + datePFEnd.Text + "'";//查看医生历史评分
                }

            }
            if (checkBox8.Checked == true)
            {
                querySQL += " and  to_char(a.in_time,'yyyy-MM-DD')>='" + dtpInTime1.Value.ToString("yyyy-MM-dd") + "' and to_char(a.in_time,'yyyy-MM-DD')<='" + dtpIntime2.Value.ToString("yyyy-MM-dd") + "'";
            }
            dt = App.GetDataSet(querySQL).Tables[0];//给数据源赋值




            if (this.cboxRand.Text == "请选择")
            {
                //Dataview是表示用于排序、筛选、搜索、编辑和导航的 System.Data.DataTable 的可绑定数据的自定义视图。
                dv = dt.DefaultView;

                dt2 = dv.ToTable();
            }
            else
            {
                #region 随机效果

                Random rd = new Random();

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

                #endregion

                //Dataview是表示用于排序、筛选、搜索、编辑和导航的 System.Data.DataTable 的可绑定数据的自定义视图。
                dv = dt.DefaultView;

                //再进行筛选
                dv.RowFilter = idlist;

                dt2 = dv.ToTable();
            }




            //DataColumn d = new DataColumn("医疗分值", typeof(double));
            //dt2.Columns.Add(d);

            //DataColumn d1 = new DataColumn("护理分值", typeof(double));
            //dt2.Columns.Add(d1);

            this.c1FlexGrid1.DataSource = dt2;//绑定数据源
            this.c1FlexGrid1.Cols["编号"].Visible = false;
            this.c1FlexGrid1.Cols["住院号"].Visible = false;
            c1FlexGrid1.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //改变c1列的长度
            for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
            {
                c1FlexGrid1.Cols[i].Width = 123;
                c1FlexGrid1.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
            this.c1FlexGrid1.Cols["患者姓名"].Width = 50;
            this.c1FlexGrid1.Cols["管床医生"].Width = 50;
            if (checkBox2.Checked == true)
            {
                this.c1FlexGrid1.Cols["全院医疗分值"].Width = 100;
                this.c1FlexGrid1.Cols["全院护理分值"].Width = 100;
                this.c1FlexGrid1.Cols["医生医疗分值"].Width = 100;
                this.c1FlexGrid1.Cols["医生护理分值"].Width = 100;
                this.c1FlexGrid1.Cols["科室医疗分值"].Width = 100;
                this.c1FlexGrid1.Cols["科室护理分值"].Width = 100;
            }
            if (checkBox1.Checked == true)
            {
                this.c1FlexGrid1.Cols["全院医疗扣分值"].Width = 100;
                this.c1FlexGrid1.Cols["全院护理扣分值"].Width = 100;
                this.c1FlexGrid1.Cols["医生医疗扣分值"].Width = 100;
                this.c1FlexGrid1.Cols["医生护理扣分值"].Width = 100;
                this.c1FlexGrid1.Cols["科室医疗扣分值"].Width = 100;
                this.c1FlexGrid1.Cols["科室护理扣分值"].Width = 100;
            }
            if (checkBox1.Checked == true && checkBox7.Checked == true)
            {
                if (checkBox3.Checked == false)
                {
                    this.c1FlexGrid1.Cols["医生医疗扣分值"].Visible = false;
                    this.c1FlexGrid1.Cols["医生护理扣分值"].Visible = false;
                    //this.c1FlexGrid1.Cols["全院医疗扣分值"].Visible = false;
                    //this.c1FlexGrid1.Cols["全院护理扣分值"].Visible = false;
                    //this.c1FlexGrid1.Cols["科室医疗扣分值"].Visible = false;
                    //this.c1FlexGrid1.Cols["科室护理扣分值"].Visible = false;
                }
                if (checkBox4.Checked == false)
                {
                    this.c1FlexGrid1.Cols["科室医疗扣分值"].Visible = false;
                    this.c1FlexGrid1.Cols["科室护理扣分值"].Visible = false;
                }
                if (checkBox5.Checked == false)
                {
                    this.c1FlexGrid1.Cols["全院医疗扣分值"].Visible = false;
                    this.c1FlexGrid1.Cols["全院护理扣分值"].Visible = false;
                }
            }
            if (checkBox2.Checked == true && checkBox7.Checked == true)
            {
                if (checkBox5.Checked == true)
                {
                    this.c1FlexGrid1.Cols["医生医疗分值"].Visible = false;
                    this.c1FlexGrid1.Cols["医生护理分值"].Visible = false;
                    this.c1FlexGrid1.Cols["科室医疗分值"].Visible = false;
                    this.c1FlexGrid1.Cols["科室护理分值"].Visible = false;
                }
            }
          

        }
        /// <summary>
        /// 把评分值传过来
        /// </summary>
        /// <param name="values">100-扣分值</param>
        public void SetFenzhi(double values)
        {
          
            if (strZhongMoDoc == "1")
            {
                c1FlexGrid1[c1FlexGrid1.RowSel, "科室医疗分值"] = values;
            }
            if (strYunXingDoc == "2")
            {
                c1FlexGrid1[c1FlexGrid1.RowSel, "科室医疗扣分值"] = 100 - values;
            }
        }

        /// <summary>
        /// 把评分值传过来(护理)
        /// </summary>
        /// <param name="values">100-扣分值</param>
        public void SetFenzhiNurse(double values)
        {
            
            if (strZhongMoDoc == "1")
            {
                c1FlexGrid1[c1FlexGrid1.RowSel, "科室护理分值"] = values;
            }
            if (strYunXingDoc == "2")
            {
                c1FlexGrid1[c1FlexGrid1.RowSel, "科室护理扣分值"] = 100 - values;
            }
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
            string selectSQL = "select to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as 评分时间  from t_doc_grade where to_char(grade_time,'yyyy-MM') like '" + dateTimePicker2.Text + "%'group by grade_time ";
            history = App.GetDataSet(selectSQL).Tables[0];
            DataColumn dc = new DataColumn("病区", typeof(string));
            dc.DefaultValue = "全院";
            history.Columns.Add(dc);
            ucC1FlexGrid1.fg.DataSource = history;
            this.ucC1FlexGrid1.fg.Cols["评分时间"].Width = 400;
            this.ucC1FlexGrid1.fg.Cols["病区"].Width = 400;
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
                
                dateTimePickerIN_OUT_time.Enabled = false;
                btntransitorily_Save.Visible = false;
                SetSickName();
                //护理评分控制连伟
                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {
                    pingfentoolStripMenuItem1.Visible = false;
                    tsmlsws.Visible = false;
                    cboxSick.Text = App.UserAccount.CurrentSelectRole.Sickarea_name;
                    cboxSick.Enabled = false;
                }
                this.cboxRand.SelectedIndex = 0;
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
                ucC1FlexGrid1.fg.MouseClick += new MouseEventHandler(ucC1FlexGrid1_MouseClick);
                //btnQuery_Click(sender, e);
                ucC1FlexGrid1.fg.ContextMenuStrip = contextMenuStrip1Sel;
                //判断当前登陆类型
                //                string strUser_id = App.UserAccount.UserInfo.User_id.ToString();
                //                string strSql = @"select t1.user_id,t1.user_name,t4.role_name
                //                                  from t_userinfo t1,t_account t2, t_account_user t3, t_role t4,t_acc_role t5
                //                                 where t1.user_id = t3.user_id
                //                                   and t3.account_id = t2.account_id
                //                                   and t2.account_id=t5.account_id
                //                                   and t4.role_id=t5.role_id  and t1.user_id='" + strUser_id + "'";
                //                DataSet ds = App.GetDataSet(strSql);
                //                if (ds.Tables[0].Rows.Count > 0)
                //                {
                //                    foreach (DataRow dr in ds.Tables[0].Rows)
                //                    {
                //                        if (dr["role_name"].ToString() == "科室质控医师")
                //                        {
                //                            intMark = 1;
                strSectionName = App.UserAccount.CurrentSelectRole.Section_name.ToString().Substring(4);
                strSectionId = App.UserAccount.CurrentSelectRole.Section_Id.ToString();
                cboxSick.Text = strSectionName;
                cboxSick.Enabled = false;
                this.GetDoctor();
                //        }
                //    }
                //}
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                datePFStart.Enabled = false;
                datePFEnd.Enabled = false;
            }
            catch
            {
            }
        }

        private void btntransitorily_Save_Click(object sender, EventArgs e)
        {
            frmMainSelectHistoryRepart fsht = new frmMainSelectHistoryRepart(this);
            fsht.ShowDialog();
            btnQuery_Click(sender, e);
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
                    if (strZhongMoDoc == "1")
                    {
                        if (string.IsNullOrEmpty(c1FlexGrid1[c1FlexGrid1.RowSel, "科室医疗分值"].ToString()))
                        {
                            pingfentoolStripMenuItem1.Enabled = true;
                        }
                        else
                        {
                            pingfentoolStripMenuItem1.Enabled = false;
                        }

                        if (string.IsNullOrEmpty(c1FlexGrid1[c1FlexGrid1.RowSel, "科室护理分值"].ToString()))
                        {
                            pingfenNurseMenuItem.Enabled = true;
                        }
                        else
                        {
                            pingfenNurseMenuItem.Enabled = false;
                        }
                    }
                    if (strYunXingDoc == "2")
                    {
                        if (string.IsNullOrEmpty(c1FlexGrid1[c1FlexGrid1.RowSel, "科室医疗扣分值"].ToString()))
                        {
                            pingfentoolStripMenuItem1.Enabled = true;
                        }
                        else
                        {
                            pingfentoolStripMenuItem1.Enabled = false;
                        }

                        if (string.IsNullOrEmpty(c1FlexGrid1[c1FlexGrid1.RowSel, "科室护理扣分值"].ToString()))
                        {
                            pingfenNurseMenuItem.Enabled = true;
                        }
                        else
                        {
                            pingfenNurseMenuItem.Enabled = false;
                        }
                    }
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
                    contextMenuStrip1Sel.Show(ucC1FlexGrid1, p);
                }
            }
        }

        private void pingfenNurseMenuItem_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("您还未选中要评分的人");
                return;
            }
           
            frmGradeNurse fg = new frmGradeNurse(this);
            fg.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtZYH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbbDoctorr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboxRand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerIN_OUT_time_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboxSick_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSCSJBB_Click(object sender, EventArgs e)
        {
            string strMark = "";
            if (strZhongMoDoc != "")
            {
                strMark = strZhongMoDoc;
            }
            if (strYunXingDoc != "")
            {
                strMark = strYunXingDoc;
            }
            int blType;
            int ysflag;
            int ksflag;
            int qyflag;
            if (checkBox1.Checked == true)
            {
                blType = 1;
            }
            else
            {
                blType = 2;
            }
            if (checkBox3.Checked == true)
            {
                ysflag = 1;
            }
            else
            {
                ysflag = 0;
            }
            if (checkBox4.Checked == true)
            {
                ksflag = 1;
            }
            else
            {
                ksflag = 0;
            }
            if (checkBox5.Checked == true)
            {
                qyflag = 1;
            }
            else
            {
                qyflag = 0;
            }
            int lsflag;
            if (checkBox7.Checked == true)
            {
                lsflag = 1;
            }
            else
            {
                lsflag = 0;
            }
            frmStochasticRepart frm = new frmStochasticRepart(dt2, strMark, blType, ysflag, ksflag, qyflag, lsflag);
            frm.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                if (checkBox1.Checked == true)
                {
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                }
                else
                {
                    checkBox3.Enabled = false;
                    checkBox4.Enabled = false;
                }
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                datePFStart.Enabled = true;
                datePFEnd.Enabled = true;
            }
            else
            {
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                datePFStart.Enabled = false;
                datePFEnd.Enabled = false;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (checkBox3.Checked == true)
            //    {
            //        checkBox4.Checked = false;
            //        //checkBox4.Checked = false;
            //        checkBox5.Checked = false;
            //        //checkBox5.Checked = false;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (checkBox4.Checked == true)
            //    {
            //        checkBox3.Checked = false;
            //        //checkBox3.Enabled = false;
            //        checkBox5.Checked = false;
            //        //checkBox5.Enabled = false;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        if (checkBox5.Checked == true)
        //        {
        //            checkBox3.Checked = false;
        //            //checkBox3.Enabled = false;
        //            checkBox4.Checked = false;
        //            //checkBox4.Enabled = false;
        //        }
        //    }
        //    catch
        //    {

        //    }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            dateTimePickerIN_OUT_time.Enabled = false;
            //if (checkBox1.Checked == true)
            //{
            //    checkBox2.Checked = false;
            //    dateTimePickerIN_OUT_time.Enabled = false;
            //    strYunXingDoc = "";
            //    strZhongMoDoc = "";
            //}
            //if (checkBox1.Checked == false)
            //{
            //    checkBox2.Checked = true;
            //    dateTimePickerIN_OUT_time.Enabled = true;
            //    strYunXingDoc = "";
            //    strZhongMoDoc = "";
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                dateTimePickerIN_OUT_time.Enabled = true;
                strYunXingDoc = "";
                strZhongMoDoc = "";
            }
            if (checkBox2.Checked == false)
            {
                checkBox1.Checked = true;
                if (checkBox7.Checked == true)
                {
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                }
                dateTimePickerIN_OUT_time.Enabled = false;
                strYunXingDoc = "";
                strZhongMoDoc = "";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                dtpInTime1.Enabled = true;
                dtpIntime2.Enabled = true;
            }
            else
            {
                dtpInTime1.Enabled = false;
                dtpIntime2.Enabled = false;
            }
        }

        private void tsmlsws_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("您还未选中要评分的人");
                return;
            }
            if (checkBox2.Checked == true)
            {
                strDOCType = "1";
            }
            else
            {
                strDOCType = "2";
            }
            frmGrade fg = new frmGrade(this, strText, false, strDOCType);            
            fg.ShowDialog();
        }
    }
}
