using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucRecordMonitor : UserControl
    {
        /// <summary>
        /// 排序格式
        /// </summary>
        private static string strDecode = @"decode(doctype,'首次病程记录',1,'D型病例查房',2,'入院记录',3,'再次（多次）入院记录',4,'24小时入出院',5,'24小时入院死亡',6,'病程',7,'主治查房',8,'病危患者病程记录',9,'病重患者病程记录',10,'转入记录',11,'转出记录',12,'交班记录',13,'接班记录',14,'会诊记录',15,'抢救记录',16,'手术记录',17,'术后首次病程记录',18,'术后病程',19,'术后上级查房记录',20,'阶段小结',21,'出院记录',22,'死亡记录',23,'死亡病历讨论记录',24,'体温单',25,'体温单其他',26,27)";
        private string sqlSection_Area = "select t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 where t1.sid=t2.sid and t1.said=t3.said and t2.section_name not in( '北院介入中心','北院麻醉科','北院手术室','北院血透室他科记账','南院急诊科','南院介入中心','南院麻醉科','南院手术室','南院血透室') order by t2.section_name,t2.sid";
        private string sqlSelHLB = "select * from record_monitor_view_hlb ";
        private string sqlSelYWC = "select * from record_monitor_view_ywc r ";
        private string sqlHLBCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r group by r.doctype,r.pv";
        private string sqlYWCCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r ";
        private string sqlYellow = "select count(*) as pv from t_quality_record where pv='0'";
        private string sqlRed = "select count(*) as pv from t_quality_record where pv='1'";
        private string strOrder = @" order by " + strDecode;
        /// <summary>
        /// 按所有文书总数排
        /// </summary>
        private string strOrderSum = @" order by sum desc," + strDecode;
        private string strSelOrder = @" order by sum desc,section_name," + strDecode;
        /// <summary>
        /// 按单一文书总数排列
        /// </summary>
        private string strOrderNum = @" order by num desc," + strDecode;
        private string strSelOrderNum = @" order by num desc,section_name," + strDecode;

        Con_RecordMonitor con = new Con_RecordMonitor();
        public string selSickname = string.Empty;//当前查询科室
        private static string names;
        private static DataView dv;
        private DataTable dataTable;
        private DataRow newrow;
        DataSet CBO_DS;// 初始化下拉列表框数据集
        private string Hlb = string.Empty;
        /// <summary>
        /// 是否是管床医生监控列表
        /// </summary>
        private bool IsDoctor = false;
        /// <summary>
        /// 是否质控提醒界面查询
        /// </summary>
        private bool IsQualityAlert = false;
        public ucRecordMonitor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">类型 医务处，护理部</param>
        /// <param name="dataView">数据集</param>
        /// <param name="isDoctor">是否是管床医生监控列表</param>
        public ucRecordMonitor(string name, DataView dataView, bool isDoctor)
        {
            InitializeComponent();
            try
            {
                this.IsDoctor = isDoctor;
                if (isDoctor)
                {
                    label2.Visible = false;
                    cboTextType.Visible = false;
                    chkbl.Visible = true;
                }
                lstCount.Clear();
                names = name;
                Hlb = name;
                dv = dataView;

                //if (names == "护理部")
                //{
                //    //con.InitFlexGrid(this.lstSelectResault, sqlSelHLB, this.cboSickArea, "HLB", lstCount, sqlHLBCount);
                //    con.InitFlexGrid(panel1, sqlSelHLB, cboSickArea, names, lstCount, sqlHLBCount);
                //    this.cboTextType.DataSource = dv;
                //    this.cboTextType.DisplayMember = "Name";
                //    this.cboTextType.ValueMember = "ID";
                //}
                //else
                //{
                //    //con.InitFlexGrid(this.lstSelectResault, sqlSelYWC, this.cboSickArea, "YWC", lstCount, sqlYWCCount);
                //    con.InitFlexGrid(panel1, sqlSelYWC, cboSickArea, names, lstCount, sqlYWCCount);
                //    this.cboTextType.DataSource = dv;
                //    this.cboTextType.DisplayMember = "Name";
                //    this.cboTextType.ValueMember = "ID";
                //}

                //con.ShowCommboBox += new Con_RecordMonitor.DisplayCommboBoxValue(con.ShowCommboBoxValue);
            }
            catch { }
        }

        /// <summary>
        /// 质控提醒界面进入
        /// </summary>
        /// <param name="name">类型 医务处，护理部</param>
        /// <param name="sickname">科室名称</param>
        public ucRecordMonitor(string name, string sickname)
        {
            InitializeComponent();
            try
            {
                this.IsDoctor = true;
                this.IsQualityAlert = true;
                label2.Visible = false;
                cboTextType.Visible = false;
                chkbl.Visible = false;

                lstCount.Clear();
                names = name;
                Hlb = name;
                selSickname = sickname;
                //this.sqlSection_Area = "select t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 where t1.sid=t2.sid and t1.said=t3.said and t2.section_name like '%" + sickname + "%' order by t2.section_name,t2.sid";
                //sickRank();
                
                this.cboSickArea.Enabled = false;
                //this.panel1.Enabled = false;
                this.panel2.Enabled = false;
                //dv = dataView;
            }
            catch { }
        }

        /// <summary>
        /// 科室在全院中排名显示
        /// </summary>
        private void sickRank()
        {
            try
            {
                string sqlselno = "select n from (select Dense_rank() over (order by sum desc) n,d.* from (select distinct d.section_id,d.section_name,d.sum from record_monitor_view_doc d) d) d where d.section_name like '%" + selSickname + "%'";
                string no = App.ReadSqlVal(sqlselno, 0, "n") == null ? "" : App.ReadSqlVal(sqlselno, 0, "n");
                if (no != "")
                {
                    lblno.Text = no;
                    label3.Visible = true;
                    lblno.Visible = true;
                }
            }
            catch (Exception)
            {
                
            }
            
        }
        //private void lstCount_DoubleClick(object sender, EventArgs e)
        //{
        //    if (lstCount.SelectedItems.Count > 0)
        //    {
        //        Class_Record_Monitor_View q = (Class_Record_Monitor_View)lstCount.SelectedItems[0].Tag;
        //        frmHint f = new frmHint(q, names);
        //        f.ShowDialog();
        //    }
        //}



        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "";
            string flag = "";
            string sqlCount = "";
            lstCount.Clear();
            if (Hlb.Contains("护理部"))
            {
                flag = "HLB";
                #region 护理部
                if (!IsDoctor)
                {//不是管床医生监控列表进入
                    if (this.cboSickArea.Text == "请选择..." && this.cboTextType.Text == "请选择...")
                    {
                        sql = sqlSelHLB;
                        sqlCount = sqlHLBCount;
                    }
                    else if ((this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院") && this.cboTextType.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_hlb r where r.shid='" + this.cboSickArea.SelectedValue + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r" +
                                   " group by r.doctype,r.pv ,r.shid" +
                                   " having shid = '" + this.cboSickArea.SelectedValue + "'";
                    }
                    else if (this.cboTextType.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_hlb r where r.section_name='" + this.cboSickArea.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r" +
                                   " group by r.doctype,r.pv ,r.section_name" +
                                   " having section_name = '" + this.cboSickArea.Text + "'";
                    }
                    else if (this.cboSickArea.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_hlb r where r.doctype='" + this.cboTextType.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r" +
                                   " group by r.doctype,r.pv " +
                                   " having  r.doctype='" + this.cboTextType.Text + "'";
                    }
                    else if (this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院")
                    {
                        sql = "select * from record_monitor_view_hlb r where r.doctype='" +
                            this.cboTextType.Text + "' and r.shid='" + this.cboSickArea.SelectedValue + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r" +
                                   " group by r.doctype,r.pv ,r.shid" +
                                   " having r.doctype='" + this.cboTextType.Text + "' and r.shid = '" + this.cboSickArea.SelectedValue + "'";
                    }
                    else
                    {
                        sql = "select * from record_monitor_view_hlb r where r.doctype='" +
                            this.cboTextType.Text + "' and r.section_name='" + this.cboSickArea.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_hlb r" +
                                   " group by r.doctype,r.pv ,r.section_name" +
                                   " having  r.doctype='" + this.cboTextType.Text + "' and r.section_name='" + this.cboSickArea.Text + "'";
                    }

                }
                else
                {
                    //if (this.cboSickArea.Text != "请选择...")
                    //{
                    //    sql = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                    //              " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                    //              " tip.sick_doctor_name,tip.sick_doctor_id,tip.section_name names from t_quality_record_hlb tqr" +
                    //              " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                    //              " where  tip.sick_area_name='" + this.cboSickArea.Text + "'" +
                    //              " group by tip.sick_doctor_name,tip.sick_doctor_id,tip.section_name";
                    //}
                    //else
                    //{
                    //    App.Msg("请您选择科室！");
                    //    return;
                    //}
                }
                #endregion
            }
            else
            {
                flag = "YWC";
                string wheresql = "";
                if (chkbl.Checked)
                {
                    wheresql = " where r.pv=3";
                }
                else
                {
                    wheresql = " where r.pv!=3";
                }
                #region 医务科,质控科
                if (!IsDoctor)
                {//不是管床医生监控列表进入
                    if (this.cboSickArea.Text == "请选择..." && this.cboTextType.Text == "请选择...")
                    {
                        sql = sqlSelYWC + wheresql;
                        sqlCount = sqlYWCCount + wheresql + "group by r.doctype,r.pv";
                    }
                    else if ((this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院") && this.cboTextType.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_ywc r "+wheresql+" and r.shid='" + this.cboSickArea.SelectedValue + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +wheresql+
                                   " group by r.doctype,r.pv ,r.shid" +
                                   " having shid = '" + this.cboSickArea.SelectedValue + "'";
                    }
                    else if (this.cboTextType.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_ywc r " + wheresql + " and  r.section_name='" + this.cboSickArea.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" + wheresql +
                                   " group by r.doctype,r.pv ,r.section_name" +
                                   " having section_name = '" + this.cboSickArea.Text + "'";
                    }
                    else if (this.cboSickArea.Text == "请选择...")
                    {
                        sql = "select * from record_monitor_view_ywc r " + wheresql + " and  r.doctype='" + this.cboTextType.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" + wheresql +
                                   " group by r.doctype,r.pv " +
                                   " having  r.doctype='" + this.cboTextType.Text + "'";
                    }
                    else if (this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院")
                    {
                        sql = "select * from record_monitor_view_ywc r " + wheresql + " and  r.doctype='" +
                            this.cboTextType.Text + "' and r.shid='" + this.cboSickArea.SelectedValue + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" + wheresql +
                                   " group by r.doctype,r.pv ,r.shid" +
                                   " having r.doctype='" + this.cboTextType.Text + "' and r.shid = '" + this.cboSickArea.SelectedValue + "'";
                    }
                    else
                    {
                        sql = "select * from record_monitor_view_ywc r " + wheresql + " and  r.doctype='" +
                            this.cboTextType.Text + "' and r.section_name='" + this.cboSickArea.Text + "'";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" + wheresql +
                                   " group by r.doctype,r.pv ,r.section_name" +
                                   " having  r.doctype='" + this.cboTextType.Text + "' and r.section_name='" + this.cboSickArea.Text + "'";
                    }
                    //if (chkbl.Checked)
                    //{//是否勾选补录
                    //    sql = sql.Replace("record_monitor_view_ywc", "record_monitor_view_ywc_temp");
                    //    sqlCount = sqlCount.Replace("record_monitor_view_ywc", "record_monitor_view_ywc_temp");
                    //}
                }
                else
                {
                    if (this.cboSickArea.Text != "请选择...")
                    {
                        sql = "select * from record_monitor_view_doc d where section_name='" + this.cboSickArea.Text + "' ";//查询所有
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +wheresql+
                                   " group by r.doctype,r.pv ,r.section_name" +
                                   " having section_name = '" + this.cboSickArea.Text + "'";
                        #region 原来的查询
                        //if (chkbl.Checked)
                        //{//是否勾选补录
                        //    if (this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院")
                        //    {
                                
                        //        sql = "select * from record_monitor_view_doc_temp d" +
                        //                      " where d.shid='" + this.cboSickArea.SelectedValue + "'";
                        //        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc_temp r" +
                        //                   " group by r.doctype,r.pv ,r.shid" +
                        //                   " having shid = '" + this.cboSickArea.SelectedValue + "' ";
                        //    }
                        //    else
                        //    {
                        //        sql = "select * from record_monitor_view_doc_temp d" +
                        //                      " where d.section_name='" + this.cboSickArea.Text + "'";
                        //        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc_temp r" +
                        //                   " group by r.doctype,r.pv ,r.section_name" +
                        //                   " having section_name = '" + this.cboSickArea.Text + "'";
                        //    }
                        //}
                        //else
                        //{
                        //    if (IsQualityAlert)
                        //    {//补录没这种定制情况
                        //        sql = "select * from record_monitor_view_doc d";//查询所有
                        //        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +
                        //                   " group by r.doctype,r.pv ,r.section_name" +
                        //                   " having section_name = '" + this.cboSickArea.Text + "'";
                        //    }
                        //    else if (this.cboSickArea.Text == "北院" || this.cboSickArea.Text == "南院")
                        //    {
                        //        sql = "select * from record_monitor_view_doc d" +
                        //                      " where d.shid='" + this.cboSickArea.SelectedValue + "'";
                        //        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +
                        //                   " group by r.doctype,r.pv ,r.shid" +
                        //                   " having shid = '" + this.cboSickArea.SelectedValue + "'";
                        //    }
                        //    else
                        //    {
                        //        sql = "select * from record_monitor_view_doc d" +
                        //                      " where d.section_name='" + this.cboSickArea.Text + "'";
                        //        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +
                        //                   " group by r.doctype,r.pv ,r.section_name" +
                        //                   " having section_name = '" + this.cboSickArea.Text + "'";
                        //        //if (selSickname!="")
                        //        //{
                        //        //    sickRank();
                        //        //}
                        //    }
                        //}
#endregion
                    }
                    else
                    {
                        //if (chkbl.Checked)
                        //{//是否勾选补录
                        //    sql = "select * from record_monitor_view_doc_temp d";
                        //    sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc_temp r" +
                        //               " group by r.doctype,r.pv ";
                        //}
                        //else
                        //{
                        //    sql = "select * from record_monitor_view_doc d";
                        //    sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +
                        //               " group by r.doctype,r.pv ";

                        //}
                        //App.Msg("请您选择科室！");
                        //return;
                        sql = "select * from record_monitor_view_doc d where 1=1 ";
                        sqlCount = "select r.pv,r.doctype,sum(r.num) as num from record_monitor_view_ywc r" +wheresql+
                                   " group by r.doctype,r.pv ";
                    }
                }
                #endregion
            }
            
            sqlCount += strOrder;
            if (IsDoctor)
            {
                string str= " order by sum desc,section_id";
                if (chkbl.Checked)
                {
                    str += ",补录 desc";
                    sql += " and d.补录>0 ";
                }
                else
                {
                    str += ",红灯 desc,黄灯 desc";
                    sql += " and (红灯>0 or 黄灯>0) ";
                }
                sql += str;
                //con.InitFlexGrid(panel1, sql, cboSickArea, flag, lstCount, sqlCount, true);
                con.InitFlexGrid(panel1, sql, cboSickArea, flag, panel2, sqlCount, chkbl.Checked, imageList1, IsQualityAlert);
            }
            else
            {
                if (this.cboTextType.Text == "请选择...")
                {//不是单一文书查询
                    if (Hlb.Contains("护理部"))
                        sql += strOrderSum;
                    else
                        sql += strSelOrder;
                }
                else
                {//单一文书查询
                    if (Hlb.Contains("护理部"))
                        sql += strOrderNum;
                    else
                        sql += strSelOrderNum;
                }
                
                //con.InitFlexGrid(panel1, sql, cboSickArea, flag, lstCount, sqlCount);
                con.InitFlexGrid(panel1, sql, cboSickArea, flag, panel2, sqlCount,imageList1);
            }
            panel1_SizeChanged(sender, e);
            panel2_SizeChanged(sender, e);
            //buttonX1_Click(sender, e);
            //不加下面属性设置,下拉条显示不完整
            panel1.AutoScroll = true;
            panel2.AutoScroll = true;
        }


        private void ucRecordMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                InitCombox();
                string wheresql = "";
                if (chkbl.Checked)
                {
                    wheresql = " where r.pv=3";
                }
                else
                {
                    wheresql = " where r.pv=1 or r.pv=0";
                }
                if (!IsDoctor)
                {
                    Hlb = App.UserAccount.CurrentSelectRole.Role_name;
                    lstCount.Clear();
                    if (Hlb.Contains("护理部"))
                    {
                        chkbl.Visible = false;
                        //con.InitFlexGrid(panel1, sqlSelHLB + strOrder, cboSickArea, "HLB", lstCount, sqlHLBCount + strOrder);
                        con.InitFlexGrid(panel1, sqlSelHLB + strOrderSum, cboSickArea, "HLB", panel2, sqlHLBCount + strOrder, imageList1);
                        this.cboTextType.DataSource = dv;
                        this.cboTextType.DisplayMember = "Name";
                        this.cboTextType.ValueMember = "ID";
                    }
                    else
                    {
                        chkbl.Visible = true;
                        //con.InitFlexGrid(panel1, sqlSelYWC + strSelOrder, cboSickArea, "YWC", lstCount, sqlYWCCount + strOrder);
                        con.InitFlexGrid(panel1, sqlSelYWC + wheresql + strSelOrder, cboSickArea, "YWC", panel2, sqlYWCCount + wheresql + "group by r.doctype,r.pv" + strOrder, imageList1);
                        this.cboTextType.DataSource = dv;
                        this.cboTextType.DisplayMember = "Name";
                        this.cboTextType.ValueMember = "ID";
                    }
                    panel1_SizeChanged(sender, e);
                    panel2_SizeChanged(sender, e);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        public void InitCombox()
        {
            try
            {
                Class_Table[] cboTables = new Class_Table[4];


                cboTables[0] = new Class_Table();
                cboTables[0].Sql = sqlSection_Area;
                //select distinct(ts.sid),ts.section_name from t_Section_Area tsa inner join t_Sectioninfo ts on tsa.sid=ts.sid order by ts.section_name,ts.sid";//科室
                cboTables[0].Tablename = "YWC";

                cboTables[1] = new Class_Table();
                cboTables[1].Sql = sqlSection_Area;
                    //"select SAID,SICK_AREA_NAME from t_sickareainfo order by sick_area_name,said";//病区
                cboTables[1].Tablename = "HLB";

                cboTables[2] = new Class_Table();
                cboTables[2].Sql = sqlYellow;//黄灯
                cboTables[2].Tablename = "yellow";

                cboTables[3] = new Class_Table();
                cboTables[3].Sql = sqlRed;//红灯
                cboTables[3].Tablename = "red";


                CBO_DS = App.GetDataSet(cboTables);

                if (names == "护理部")
                {
                    label1.Text = "病区：";

                    dataTable = CBO_DS.Tables["HLB"];
                    newrow = dataTable.NewRow();
                    newrow = dataTable.NewRow();
                    newrow[3] = "请选择...";
                    dataTable.Rows.InsertAt(newrow, 0);
                    //newrow = dataTable.NewRow();
                    //newrow[1] = "1";//1是北院,221是南院
                    //newrow[3] = "北院";
                    //dataTable.Rows.InsertAt(newrow, 1);
                    //newrow = dataTable.NewRow();
                    //newrow[1] = "221";//1是北院,221是南院
                    //newrow[3] = "南院";
                    //dataTable.Rows.InsertAt(newrow, 2);
                    this.cboSickArea.DataSource = CBO_DS.Tables["HLB"].DefaultView;
                    this.cboSickArea.ValueMember = "SAID";
                    this.cboSickArea.DisplayMember = "SICK_AREA_NAME";
                }
                else
                {
                    label1.Text = "科室：";
                    dataTable = CBO_DS.Tables["YWC"];
                    newrow = dataTable.NewRow();
                    newrow[2] = "请选择...";
                    dataTable.Rows.InsertAt(newrow, 0);
                    //newrow = dataTable.NewRow();
                    //newrow[0] = "1";//1是北院,221是南院
                    //newrow[2] = "北院";
                    //dataTable.Rows.InsertAt(newrow, 1);
                    //newrow = dataTable.NewRow();
                    //newrow[0] = "221";//1是北院,221是南院
                    //newrow[2] = "南院";
                    //dataTable.Rows.InsertAt(newrow, 2);
                    this.cboSickArea.DataSource = CBO_DS.Tables["YWC"].DefaultView;
                    this.cboSickArea.ValueMember = "SID";
                    this.cboSickArea.DisplayMember = "SECTION_NAME";
                    if (selSickname!="")
                    {
                        this.cboSickArea.Text = selSickname;
                    }
                    
                }

                string yellow = CBO_DS.Tables["yellow"].Select()[0]["PV"].ToString();
                string red = CBO_DS.Tables["red"].Select()[0]["PV"].ToString();
                this.lblyellow.Text = yellow;
                this.lblred.Text = red;
            }
            catch (Exception ex)
            {
                string strEx=ex.Message;
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
            //lstCount.Clear();
            //if (Hlb.Contains("护理部"))
            //{
            //    //con.InitFlexGrid(panel1, sqlSelHLB + strOrder, cboSickArea, names, lstCount, sqlHLBCount + strOrder);
            //    con.InitFlexGrid(panel1, sqlSelHLB + strOrder, cboSickArea, Hlb, panel2, sqlHLBCount + strOrder, imageList1);
            //    this.cboTextType.DataSource = dv;
            //    this.cboTextType.DisplayMember = "Name";
            //    this.cboTextType.ValueMember = "ID";
            //}
            //else
            //{
            //    //con.InitFlexGrid(panel1, sqlSelYWC + strSelOrder, cboSickArea, names, lstCount, sqlYWCCount + strOrder);
            //    con.InitFlexGrid(panel1, sqlSelYWC + strSelOrder, cboSickArea, Hlb, panel2, sqlYWCCount + strOrder, imageList1);
            //    this.cboTextType.DataSource = dv;
            //    this.cboTextType.DisplayMember = "Name";
            //    this.cboTextType.ValueMember = "ID";
            //}
            //panel1_SizeChanged(sender, e);
            //panel2_SizeChanged(sender, e);


            //panel1.AutoScroll = true;
            //panel2.AutoScroll = true;
        }

        private void btnSelectList2_Click(object sender, EventArgs e)
        {
            string sql = "";
            string flag = "";
            string sqlCount = "";
            if ((this.cboTextType.Text == "请选择..." || this.cboTextType.Text == "") && names == "护理部")
            {
                flag = "HLB";
                sql = "select * from record_monitor_view_hlb r where r.sick_area_name='" + this.cboSickArea.Text + "'";

            }
            else
            {
                flag = "YWC";
                if (this.cboTextType.Text == "请选择...")
                {
                    sql = "select tip.section_id,tip.section_name,tip.Sick_Doctor_Name,tip.IN_Doctor_Name,tip.sick_bed_no,"
                           + "tip.patient_name,tqr.note,tqr.noteztime,tqr.take_grade from t_quality_record tqr inner join t_in_patient tip "
                            + "on tqr.PATIENT_ID=tip.id  and tip.DOCUMENT_STATE is null  where tip.section_name='" + this.cboSickArea.Text + "' and pv=1 order by tip.patient_name,tqr.note desc";
                }
                else
                {
                    sql = "select tip.section_id,tip.section_name,tip.Sick_Doctor_Name,tip.IN_Doctor_Name,tip.sick_bed_no,"
                           + "tip.patient_name,tqr.note,tqr.noteztime,tqr.take_grade from t_quality_record tqr inner join t_in_patient tip "
                            + "on tqr.PATIENT_ID=tip.id  and tip.DOCUMENT_STATE is null  where tip.section_name='" + this.cboSickArea.Text + "' and tqr.doctype='"
                            + this.cboTextType.Text + "' and pv=1 order by tip.patient_name,tqr.note desc";
                }
            }
            DataSet dsQuality = App.GetDataSet(sql);
            if (dsQuality.Tables[0].Rows.Count != 0)
            {
                frmQualityList fq = new frmQualityList(dsQuality, this.cboSickArea.Text, this.cboTextType.Text);
                fq.ShowDialog();
            }
            else
            {
                App.Msg("该查询条件没有对应的质控记录");
            }

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            Point pt = new Point(2, 1);
            int x = 2;
            int y = 1;
            bool isFirst = false;
            int height = 24;
            foreach (Control item in panel1.Controls)
            {
                if (!isFirst)
                {
                    isFirst = true;
                }
                else
                {
                    if (item.GetType().Name.Contains("Label"))
                    {
                        x = 2;
                        y += height + 15;
                    }
                    else
                    {
                        if (x + item.Width + item.Width + 5 > panel1.Width)
                        {
                            x = 2;
                            y += height + 5;
                        }
                    }
                }
                pt.X = x;
                pt.Y = y;
                item.Location = pt;
                x = x + item.Width + 10;
            }
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            Point pt = new Point(2, 1);
            int x = 2;
            int y = 1;
            bool isFirst = false;
            int height = 24;
            foreach (Control item in panel2.Controls)
            {
                if (!isFirst)
                {
                    isFirst = true;
                }
                else
                {
                    //if (item.GetType().Name.Contains("Label"))
                    //{
                    //    x = 2;
                    //    y += height + 15;
                    //}
                    //else
                    //{
                        if (x + item.Width + item.Width + 5 > panel2.Width)
                        {
                            x = 2;
                            y += height + 5;
                        }
                    //}
                }
                pt.X = x;
                pt.Y = y;
                item.Location = pt;
                x = x + item.Width + 10;
            }
        }



    }
}
