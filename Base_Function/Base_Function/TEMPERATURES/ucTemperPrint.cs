using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Bifrost;
using System.Reflection;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTemperPrint : UserControl
    {
        printTemper ph = new printTemper();
        printTemper_Child phChild = new printTemper_Child();
        PrintDocument pdDocument = new PrintDocument();
        private FieldInfo m_Position;
        private MethodInfo m_SetPositionMethod;
        private bool isMouseDown;
        private Point startPosition;
        private Point endPosition;
        private Point curPos;


        private string in_date = string.Empty;
        private string id = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        private string pid = string.Empty;
        PrintDialog pd = new PrintDialog();

        public ucTemperPrint()
        {
            try
            {
                InitializeComponent();
                ph.Hospital = "XXXXXX医院";
                ph.TextName = "体 温 记 录 单";
                ph.User.Add("姓名：", "张三");
                ph.User.Add("床号：", "1床");
                ph.User.Add("性别：", "男");
                ph.User.Add("科室：", "消化内科");
                ph.User.Add("病区：", "消化内科病区");
                this.startTime = "2011-12-22";
                this.endTime = "2011-12-28";
                this.in_date = "2011-12-22 00:00";
                this.id = "98905";
                ph.Init("98905", "2010-11-05 11:11");
                pdDocument.DocumentName = "无双钟情一生红";
                temperInit();
            }
            catch { }
        }


        /// <summary>
        /// 普通体温单打印构造函数 新方法
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="bedNo">床号</param>
        /// <param name="sex">性别</param>
        /// <param name="in_time">出生时间</param>
        /// <param name="pid">住院号</param>                 
        public ucTemperPrint(InPatientInfo info)//string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time, string out_time)
        {
            InitializeComponent();

            string age = info.Age;
            string sex = info.Gender_Code;

            this.id = info.Id.ToString();//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            this.pid = info.PId;

            this.bedNo = info.Sick_Bed_Name;
            this.medicareNo = info.Medicare_no;
            string Age_Child = DataInit.GetAge(info.Id.ToString());
            if (string.IsNullOrEmpty(age) || age.Equals("0岁") )
            {
                age = Age_Child;
            }
            if (pid.Contains("_"))
            {
                this.isChild = true;
            }
            else
            {
                if (Age_Child.Contains("天"))
                    Age_Child = Age_Child.Replace("天", "");

                if (Age_Child.Contains("小时") || Age_Child.Contains("分") || (App.IsNumeric(Age_Child) && Convert.ToInt32(Age_Child) < 28))
                    this.isChild = true;
                else
                    this.isChild = false;
            }
            if (isChild)
            {
                if (sex == "0" || sex == "男")
                    sex = "男";
                else
                    sex = "女";
                phChild.Hospital = App.HospitalTittle;
                phChild.Bingqu = info.Sick_Area_Name;
                phChild.TextName = "体 温 记 录 单";
                phChild.User.Add("姓名:", info.Patient_Name);
                phChild.User.Add("性别:", sex);
                phChild.User.Add("病区:", info.Sick_Area_Name);
                phChild.User.Add("年龄:", age);
                phChild.User.Add("床号:", bedNo);
                phChild.User.Add("入院日期:", in_date);
                phChild.User.Add("登记号:", medicareNo);
                phChild.User.Add("住院号:", pid);
                phChild.User.Add("转入日期:", "");
                string diagnose = "新生儿";
                phChild.User.Add("诊断:", "");
                phChild.User.Add("编号:", id);// App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + phChild.User["入院日期:"] + "' ", 0, "id"));
                phChild.User.Add("科室:", TemperatureMethod.GetSection(phChild.User["编号:"], phChild.PageIndex.ToString()));
                //if (out_time.Trim()!="")
                //  ph.User.Add("出院日期:", Convert.ToDateTime(out_time).ToString("yyyy-MM-dd HH:mm"));
                //else
                //  ph.User.Add("出院日期:","");

                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + "");
                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t inner join t_in_patient a on t.pid=a.id where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + " and a.die_flag<>1");
                //if (ds.Tables[0].Rows.Count > 0)
                //    phChild.User.Add("出院日期:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
                //else
                //    phChild.User.Add("出院日期:", "");

                phChild.Init(id, in_date);
                
            }
            else
            {
                if (sex == "0" || sex == "男")
                    sex = "男";
                else
                    sex = "女";
                ph.Hospital = App.HospitalTittle;
                ph.Bingqu = info.Sick_Area_Name;
                ph.TextName = "体 温 记 录 单";
                ph.User.Add("姓名:", info.Patient_Name);
                ph.User.Add("性别:", sex);
                ph.User.Add("病区:", info.Sick_Area_Name);
                ph.User.Add("年龄:", age);
                ph.User.Add("床号:", bedNo);
                ph.User.Add("入院日期:", in_date);
                ph.User.Add("登记号:", medicareNo);
                ph.User.Add("住院号:", pid);
                ph.User.Add("转入日期:", "");
                ph.User.Add("编号:", id);//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + ph.User["入院日期:"] + "'", 0, "id"));
                ph.User.Add("科室:", TemperatureMethod.GetSection(ph.User["编号:"], ph.PageIndex.ToString()));
                string diagnose = "";
                string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
                sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
                DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
                if (dtdiagnose != null)
                {
                    for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        }
                        else if (i >= 3)
                        {
                            break;
                        }
                        else
                        {
                            diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        }
                    }
                }
                ph.User.Add("诊断:", diagnose);
                //if (out_time.Trim()!="")
                //  ph.User.Add("出院日期:", Convert.ToDateTime(out_time).ToString("yyyy-MM-dd HH:mm"));
                //else
                //  ph.User.Add("出院日期:","");

                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + "");
                DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t inner join t_in_patient a on t.pid=a.id where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + " and a.die_flag<>1");
                if (ds.Tables[0].Rows.Count > 0)
                    ph.User.Add("出院日期:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
                else
                    ph.User.Add("出院日期:", "");

                ph.Init(id, in_date);
            }
            
            temperInit();
        }

        private string bedNo = string.Empty;
        private string medicareNo = string.Empty;

        /// <summary>
        /// 普通体温单打印构造函数 原方法
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="medicare_no">登记号</param>
        /// <param name="bedNo">床号</param>
        /// <param name="sex">性别</param>
        /// <param name="in_time">出生时间</param>
        /// <param name="pid">住院号</param>                 
        //public ucTemperPrint(string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        //{
        //    InitializeComponent();
        //    this.bedNo = bedNo;
        //    this.medicareNo = medicare_no;
        //    string Age_Child = DataInit.GetAge(id);
        //    if (string.IsNullOrEmpty(age) || age.Equals("0岁"))
        //    {
        //        age = Age_Child;
        //    }
        //    if (pid.Contains("_"))
        //    {
        //        this.isChild = true;
        //    }
        //    else
        //    {
        //        if (Age_Child.Contains("天"))
        //            Age_Child = Age_Child.Replace("天", "");

        //        if (Age_Child.Contains("小时") || Age_Child.Contains("分") || (App.IsNumeric(Age_Child) && Convert.ToInt32(Age_Child) < 28))
        //            this.isChild = true;
        //        else
        //            this.isChild = false;
        //    }
        //    if (isChild)
        //    {
        //        if (sex == "0" || sex == "男")
        //            sex = "男";
        //        else
        //            sex = "女";
        //        phChild.Hospital = App.HospitalTittle;
        //        phChild.Bingqu = ward;
        //        phChild.TextName = "体 温 记 录 单";
        //        phChild.User.Add("床号:", bedNo);
        //        phChild.User.Add("姓名:", name);
        //        phChild.User.Add("性别:", sex);
        //        phChild.User.Add("年龄:", age);
        //        phChild.User.Add("病区:", section);
        //        phChild.User.Add("入院日期:", Convert.ToDateTime(in_time).ToString("yyyy-MM-dd HH:mm"));
        //        phChild.User.Add("登记号:", medicare_no);
        //        phChild.User.Add("住院号:", pid);
        //        phChild.User.Add("转入日期:", "");
        //        phChild.User.Add("编号:", id);//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + phChild.User["入院日期:"] + "'", 0, "id"));
        //        phChild.User.Add("科室:", TemperatureMethod.GetSection(phChild.User["编号:"], phChild.PageIndex.ToString()));
        //        string diagnose = "新生儿";
        //        //phChild.User.Add("诊断:", diagnose);
        //        DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + "");
        //        if (ds.Tables[0].Rows.Count > 0)
        //            phChild.User.Add("出院日期:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
        //        else
        //            phChild.User.Add("出院日期:", "");
        //        phChild.Init(id, in_time);
        //        this.id = id;//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
        //        this.in_date = in_time;
        //        this.pid = pid;
        //    }
        //    else
        //    {
        //        if (sex == "0" || sex == "男")
        //            sex = "男";
        //        else
        //            sex = "女";
        //        ph.Hospital = App.HospitalTittle;
        //        ph.Bingqu = ward;
        //        ph.TextName = "体 温 记 录 单";
        //        ph.User.Add("姓名:", name);
        //        ph.User.Add("性别:", sex);
        //        ph.User.Add("病区:", section);
        //        ph.User.Add("年龄:", age);
        //        ph.User.Add("床号:", bedNo);
        //        ph.User.Add("入院日期:", Convert.ToDateTime(in_time).ToString("yyyy-MM-dd HH:mm"));
        //        ph.User.Add("登记号:", medicare_no);
        //        ph.User.Add("住院号:", pid);
        //        ph.User.Add("转入日期:", "");
        //        ph.User.Add("编号:",id);// App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + ph.User["入院日期:"] + "'", 0, "id"));
        //        ph.User.Add("科室:", TemperatureMethod.GetSection(ph.User["编号:"], ph.PageIndex.ToString()));
        //        string diagnose = "";
        //        string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
        //        sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
        //        DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
        //        if (dtdiagnose != null)
        //        {
        //            for (int i = 0; i < dtdiagnose.Rows.Count; i++)
        //            {
        //                if (i == 0)
        //                {
        //                    diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
        //                }
        //                else if (i >= 3)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
        //                }
        //            }
        //        }
        //        //ph.User.Add("诊断:", diagnose);
        //        DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='出区' and t.patient_id=" + id + "");
        //        if (ds.Tables[0].Rows.Count > 0)
        //            ph.User.Add("出院日期:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
        //        else
        //            ph.User.Add("出院日期:", "");
        //        ph.Init(id, in_time);
        //        this.isChild = false;
        //        this.id = id;//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
        //        this.in_date = in_time;
        //        this.pid = pid;
        //    }
        //    temperInit();


        //    //FormTest fc = new FormTest(pid,id,bedNo,name,sex,age,section,ward,in_time);
        //    //fc.Show();

        //}

        /// <summary>
        /// 初始化
        /// </summary>
        private void temperInit()
        {
            this.ppcPreview.Document = pdDocument;
            this.pd.Document = pdDocument;
            this.pd.AllowSomePages = true;
            this.pd.ShowHelp = true;
            this.pd.UseEXDialog = true;
            this.pdDocument.DefaultPageSettings.Margins.Left = 38;//38
            this.pdDocument.DefaultPageSettings.Margins.Top = 78;  //78
            this.pdDocument.DefaultPageSettings.Landscape = false;
            //this.pdDocument.PrinterSettings.CanDuplex
            //this.pdDocument.DefaultPageSettings.Margins.Bottom = 15;
            this.pdDocument.OriginAtMargins = true;
            Type type = typeof(System.Windows.Forms.PrintPreviewControl);
            m_Position = type.GetField("position", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            m_SetPositionMethod = type.GetMethod("SetPositionNoInvalidate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            ppcPreview.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);
            ppcPreview.Click += new EventHandler(ppcPreview_Click);
            ppcPreview.MouseDown += new MouseEventHandler(ppcPreview_MouseDown);
            ppcPreview.MouseUp += new MouseEventHandler(ppcPreview_MouseUp);
            ppcPreview.MouseMove += new MouseEventHandler(ppcPreview_MouseMove);
            pdDocument.PrintPage += new PrintPageEventHandler(pdDocument_PrintPage);
            foreach (PaperSize _papersize in this.pdDocument.PrinterSettings.PaperSizes)
            {
                if (_papersize.PaperName == "A4")
                {
                    pdDocument.DefaultPageSettings.PaperSize = _papersize;
                    break;
                }
            }
            this.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);

            loadTree();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int index = 0;              //打印第几页
        private bool isAll = false; //是否全部打印
        /// <summary>
        /// 打印函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (id != "")
                {
                    e.Graphics.ScaleTransform(1f, 0.97f);
                    Graphics g = e.Graphics;
                    if (isAll)
                    {
                        StarToEndTime(this.tvTimes.Nodes[index].Text);
                        if (isChild)
                        {
                            phChild.PageIndex = index + 1;
                            phChild.User["科室:"] = TemperatureMethod.GetSection(phChild.User["编号:"], phChild.PageIndex.ToString());
                            //phChild.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                            phChild.printMain(e.Graphics, startTime, endTime);
                        }
                        else
                        {
                            ph.PageIndex = index + 1;
                            //ph.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                            //ph.User["诊断:"] = TemperatureMethod.GetDiagnose(this.pid);
                            ph.User["科室:"] = TemperatureMethod.GetSection(ph.User["编号:"], ph.PageIndex.ToString());
                            ph.User["病区:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["病区:"] : TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
                            ph.printMain(e.Graphics, startTime, endTime);
                        }
                        index++;
                        if (index == this.tvTimes.Nodes.Count - 1)
                        {
                            e.HasMorePages = false;
                            index = 0;
                        }
                        else
                        {
                            e.HasMorePages = true;
                        }
                    }
                    else
                    {

                        if (isChild)
                        {
                            phChild.printMain(e.Graphics, startTime, endTime);
                        }
                        else
                        {
                            ph.printMain(e.Graphics, startTime, endTime);
                        }
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show("数据异常或没有安装打印机");
                // this.Close();
            }
        }

        private void tvTime_MouseDown(object sender, MouseEventArgs e)
        {
            this.tvTimes.SelectedNode = tvTimes.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Node select = this.tvTimes.SelectedNode;
                if (select != null)
                {
                    if (select.Text == "显示全部")
                    {
                        if (MessageBox.Show("确定要打印全部体温单吗?", "温馨提示!"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    this.pdDocument.Print();
                }
            }
            catch (Exception)
            {
                App.Msg("打印机异常！");
            }
        }


        /// <summary>
        /// 加载时间项目
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = null;
            if (this.isChild)
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%出院%' OR T.DESCRIBE like '%死亡%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            else
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%出院%' OR T.DESCRIBE like '%死亡%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                today = Convert.ToDateTime(dt.Rows[0]["MEASURE_TIME"].ToString());
                if (isChild)
                {
                    phChild.out_time = today;
                }
                else
                {
                    ph.out_time = today;
                }
            }
            if (pid.Contains("_"))
            {
                inDatetime = Convert.ToDateTime(App.ReadSqlVal(" select to_char(birthday,'yyyy-MM-dd') birthday from t_in_patient where id=" + this.id, 0, "birthday"));
            }
            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            if ((ts.Days + 1) % 7 == 0)
                weekCount = (ts.Days + 1) / 7;
            else
                weekCount = (ts.Days + 1) / 7 + 1;

            string temper = "";
            for (int i = 0; i < weekCount; i++)
            {
                temper = "第" + (i + 1).ToString() + "周(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
                Node tn = new Node();
                tn.Text = temper;
                this.tvTimes.Nodes.Add(tn);
                temper = "";
            }
            string tempString = tvTimes.Nodes[tvTimes.Nodes.Count - 1].Text.ToString();
            StarToEndTime(tempString);
            if (isChild)
            {
                phChild.PageIndex = tvTimes.Nodes.Count;
                phChild.User["科室:"] = TemperatureMethod.GetSection(phChild.User["编号:"], phChild.PageIndex.ToString());
                //phChild.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                //ph.User["诊断:"] = TemperatureMethod.GetDiagnose(this.pid, ph.PageIndex.ToString());
            }
            else
            {
                ph.PageIndex = tvTimes.Nodes.Count;
                ph.User["科室:"] = TemperatureMethod.GetSection(ph.User["编号:"], ph.PageIndex.ToString());
                //ph.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                //ph.User["诊断:"] = TemperatureMethod.GetDiagnose(this.pid);
                ph.User["病区:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["病区:"] :
                                    TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
            }
            Node de = new Node();
            de.Text = "显示全部";
            this.tvTimes.Nodes.Add(de);
        }


        /// <summary>
        /// 设置开始时间 结束时间
        /// </summary>
        /// <param name="tempString"></param>
        private void StarToEndTime(string tempString)
        {
            string temp = tempString.Split('(')[1].ToString();
            string howWeek = tempString.Split('(')[0].ToString();
            string weeks = howWeek.Substring(1, howWeek.Length - 2);
            string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
            this.startTime = startEndDate[0];
            this.endTime = startEndDate[1];
        }

        /// <summary>
        /// 树节点 选择打印日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null && this.tvTimes.Nodes.Count > 1)
            {
                if (selectNode.Text == "显示全部")
                {
                    this.isAll = true;
                    this.ppcPreview.Rows = this.tvTimes.Nodes.Count - 1;
                    this.pdDocument.DocumentName = (this.tvTimes.Nodes.Count - 1).ToString();
                }
                else
                {
                    this.isAll = false;
                    string tempString = selectNode.Text;
                    string temp = tempString.Split('(')[1].ToString();
                    string howWeek = tempString.Split('(')[0].ToString();
                    string weeks = howWeek.Substring(1, howWeek.Length - 2);
                    string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
                    this.startTime = startEndDate[0];
                    this.endTime = startEndDate[1];
                    if (isChild)
                    {
                        phChild.PageIndex = selectNode.Index + 1;
                        phChild.User["科室:"] = TemperatureMethod.GetSection(phChild.User["编号:"], phChild.PageIndex.ToString());
                        //phChild.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                        //ph.User["诊断:"] = TemperatureMethod.GetDiagnose(this.pid);
                    }
                    else
                    {
                        ph.PageIndex = selectNode.Index + 1;
                        //ph.User["床号:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                        //ph.User["诊断:"] = TemperatureMethod.GetDiagnose(this.pid);
                        ph.User["科室:"] = TemperatureMethod.GetSection(ph.User["编号:"], ph.PageIndex.ToString());
                        ph.User["病区:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["病区:"] :
                                           TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
                    }
                    this.ppcPreview.Rows = 1;
                    this.pdDocument.DocumentName = "1";
                }
                this.ppcPreview.InvalidatePreview();
            }
        }

        /// <summary>       
        /// 鼠标滚轮       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        void ppcPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!SystemInformation.MouseWheelPresent)
            {
                //If have no wheel       
                return;
            }
            int scrollAmount;
            float amount = Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta;
            amount *= SystemInformation.MouseWheelScrollLines;
            amount *= 12;//Row height       
            amount *= (float)ppcPreview.Zoom;//Zoom Rate       
            if (e.Delta < 0)
            {
                scrollAmount = (int)amount;
            }
            else
            {
                scrollAmount = -(int)amount;
            }
            Point curPos = (Point)(m_Position.GetValue(ppcPreview));
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + 0, curPos.Y + scrollAmount) });
        }

        /// <summary>       
        /// 鼠标在控件上点击时，需要处理获得焦点，因为默认不会获得焦点       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_Click(object sender, EventArgs e)
        {
            ppcPreview.Select();
            ppcPreview.Focus();
        }

        /// <summary>       
        /// 鼠标按下，开始拖动       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            startPosition = new Point(e.X, e.Y);
            curPos = (Point)(m_Position.GetValue(ppcPreview));
        }

        /// <summary>       
        /// 鼠标释放，完成拖动       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            endPosition = new Point(e.X, e.Y);
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
        }

        /// <summary>       
        /// 鼠标移动，拖动中       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                endPosition = new Point(e.X, e.Y);
                m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
            }
        }

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            this.ppcPreview.Zoom = float.Parse(this.slider1.Value.ToString("#0.0")) / 10;
        }

        /// <summary>
        /// 窗体加载完执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTemperPrint_Load(object sender, EventArgs e)
        {
            this.tvTimes.SelectedNode = this.tvTimes.Nodes[tvTimes.Nodes.Count - 2];
            this.tvTimes.Focus();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Stream StreamRead;
            OpenFileDialog DialogueCharger = new OpenFileDialog();
            DialogueCharger.DefaultExt = "shape";
            DialogueCharger.Title = "Load shape";
            DialogueCharger.Filter = "frame files (*.shape)|*.shape|All files (*.*)|*.*";
            if (DialogueCharger.ShowDialog() == DialogResult.OK)
            {
                if ((StreamRead = DialogueCharger.OpenFile()) != null)
                {
                    BinaryFormatter BinaryRead = new BinaryFormatter();
                    Base_Function.BASE_COMMON.Class1 cls = new Base_Function.BASE_COMMON.Class1();
                    cls = (Base_Function.BASE_COMMON.Class1)BinaryRead.Deserialize(StreamRead);
                    StreamRead.Close();
                    if (isChild)
                    {
                        this.phChild.dbList = cls.List;
                    }
                    else
                    {
                        this.ph.dbList = cls.List;
                    }
                    this.ppcPreview.InvalidatePreview();
                }
            }
        }

        public void getList(List<DataTable> tabs)
        {
            //Stream streamWrite;
            //SaveFileDialog sf = new SaveFileDialog();
            //sf.DefaultExt = "shape";
            //sf.Title = "保存";
            //sf.Filter = "shape files (*.shape)|*.shape|All files (*.*)|*.*";
            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //    if ((streamWrite = sf.OpenFile()) != null)
            //    {
            //        BinaryFormatter BinaryWrite = new BinaryFormatter();
            //        TemperPrints.Class1 cla = new TemperPrints.Class1();
            //        cla.List = tabs;
            //        BinaryWrite.Serialize(streamWrite, cla);
            //        streamWrite.Close();
            //    }
            //}
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.ppcPreview.InvalidatePreview();
        }
    }
}
