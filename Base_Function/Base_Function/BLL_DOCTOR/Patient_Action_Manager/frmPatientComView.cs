using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using DevComponents.AdvTree;
using System.Xml;
using TextEditor;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmPatientComView : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inPatientInfo;

        private int currentindex = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPatient"></param>
        public frmPatientComView(InPatientInfo inPatient)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            this.inPatientInfo = inPatient;
        }

        /// <summary>
        /// 
        /// </summary>
        public frmPatientComView()
        {
            InitializeComponent();
        }
        private string doc_name = "";
        private string textname = "";
        private int textkind_id=-1 ;
        private string document_time = "";
        private DateTime referTime = new DateTime(); //参考时间       
        private DateTime in_time = new DateTime();   //入院时间
        private DateTime start_time = new DateTime();//开始时间
        private string Pid = string.Empty;
        private bool isIn_time = false;

        private void frmPatientComView_Load(object sender, EventArgs e)
        {
            lbhuanzheInfo.Text = "姓名：" + inPatientInfo.Patient_Name + "   性别:" + DataInit.StringFormat(inPatientInfo.Gender_Code) + "   年龄：" + inPatientInfo.Age + "   科别：" + inPatientInfo.Section_Name + "   床号：" + inPatientInfo.Sick_Bed_Name + "   住院号：" + inPatientInfo.PId + "   入院日期：" + inPatientInfo.In_Time + "   入院诊断：" +  "";
            //生成comboboex1的下拉菜单
            TimeSpan ts = App.GetSystemTime().Subtract(inPatientInfo.In_Time);
            int tsday = (int)ts.TotalDays/7;
            for (int i = 0; i < tsday; i++)
            {
                if (i >= 0)
                {
                    comboBoxEx1.Items.Add((i + 2).ToString());
                }
            }

            comboBoxEx1.SelectedIndex = 0; 

            //ClearNumber();//重置数据
            //start_time = inPatientInfo.In_Time;
            //drawSevenTime(start_time);//刷新7天时间
            //getInfo(start_time,comboBoxEx1.SelectedIndex);//数据库中找到需要的信息
            //drawPaseandLis(start_time, comboBoxEx1.SelectedIndex);//刷新事件，检查
            //drawErmDocument(start_time);           
        }
        /// <summary>
        /// 画事件
        /// </summary>
        /// <param name="start_time">这周开始时间</param>
        /// <param name="selectIndex">第几周</param>
        private void getInfo(DateTime start_time,int selectIndex)
        {

            string SqlInfo = "select in_time,b.textkind_id,b.doc_name,b.textname,document_time,b.tid from t_in_patient a inner join t_patients_doc b on a.id=b.patient_id where  a.id='" + inPatientInfo.Id + "'";
            DataSet dts = App.GetDataSet(SqlInfo);
            if (dts != null)
            {
                DataTable dt = dts.Tables[0];
                if (dt.Rows.Count >= 0)
                {
                    int[] pointY ={ 0, 0, 0, 0, 0, 0, 0 };
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            #region 找到事件和发生的时间
                            textname = dt.Rows[i]["textname"].ToString();
                            doc_name = dt.Rows[i]["doc_name"].ToString();
                            textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            DateTime happenTime = inPatientInfo.In_Time;
                            //事件lb形式画到panel_E上,入院，出院，分娩，手术，抢救，转入，转出
                            #region
                            if (textkind_id == 151)//手术记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 158)//出院记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 461 || textkind_id == 462 || textkind_id == 1052)//分娩记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 151)//手术记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 130)//转出记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 301)//转入记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            else if (textkind_id == 132)//抢救记录
                            {
                                if (doc_name.Trim() != "")
                                {
                                    happenTime = Convert.ToDateTime(App.GetTimeString(doc_name));
                                }
                            }
                            #endregion
                            #endregion
                            //DateTime happenTime = Convert.ToDateTime(Convert.ToDateTime(App.GetTimeString(doc_name)).ToShortDateString());
                            //if (happenTime == in_time)
                            //{
                            //    continue;
                            //}
                            #region 在画布上画事件
                            //if (happenTime == inPatientInfo.In_Time && isIn_time == true)
                            //    continue;
                            //if (happenTime == inPatientInfo.In_Time && isIn_time == false)
                            //    isIn_time = true;
                            TimeSpan c = Convert.ToDateTime(happenTime.ToShortDateString()).Subtract(Convert.ToDateTime(start_time.ToShortDateString()));
                            int day = (int)c.TotalDays;
                            if (day >= 0 && day < 7)
                            {
                                DevComponents.DotNetBar.LabelX lbxEvent = new DevComponents.DotNetBar.LabelX();
                                lbxEvent.BackgroundImage = imageList1.Images[0];
                                lbxEvent.BackgroundImageLayout = ImageLayout.Stretch;
                                lbxEvent.TextAlignment = StringAlignment.Center;
                                lbxEvent.Size = new Size(76, 24);
                                lbxEvent.BackColor = Color.Transparent;
                                //if (textname != "病程记录")
                                //{
                                //    lbxEvent.Text = textname.Remove(2);
                                //}
                                //else
                                //{
                                //    lbxEvent.Text = doc_name.Replace(App.GetTimeString(doc_name), " ").Trim().Remove(2);
                                //}
                                if (happenTime == inPatientInfo.In_Time)
                                {
                                    lbxEvent.Text = "入院";
                                    isIn_time = true;
                                }
                                else if (textkind_id == 158)
                                    lbxEvent.Text = "出院";
                                else if (textkind_id == 151)
                                    lbxEvent.Text = "手术";
                                else if (textkind_id == 461 || textkind_id == 462 || textkind_id == 1052)
                                    lbxEvent.Text = "分娩";
                                else if (textkind_id == 301)
                                    lbxEvent.Text = "转入";
                                else if (textkind_id == 130)
                                    lbxEvent.Text = "转出";
                                else if (textkind_id == 132)
                                    lbxEvent.Text = "抢救";
                                if (lbxEvent.Text.Trim().Length == 0)
                                    continue;
                                lbxEvent.Name = "lbxEventn" + (i).ToString();
                                lbxEvent.ForeColor = Color.Red;
                                //lbxEvent.Width = 108;
                                //lbxEvent.Height = 20;
                                lbxEvent.Location = new Point(0 + 10, pointY[day] * 24);
                                lbxEvent.Tag = dt.Rows[i]["tid"].ToString();
                                pointY[day]++;

                                bool isexits = false;
                                for (int i1 = 0; i1 < panel_E1.Controls.Count; i1++)
                                {
                                    if (lbxEvent.Text == panel_E1.Controls[i1].Text)
                                    {
                                        isexits = true;
                                        break;
                                    }
                                }

                                if (!isexits)
                                {
                                    if (day == 0)
                                    {
                                        panel_E1.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 1)
                                    {
                                        panel_E2.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 2)
                                    {
                                        panel_E3.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 3)
                                    {
                                        panel_E4.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 4)
                                    {
                                        panel_E5.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 5)
                                    {
                                        panel_E6.Controls.Add(lbxEvent);
                                    }
                                    else if (day == 6)
                                    {
                                        panel_E7.Controls.Add(lbxEvent);
                                    }
                                }
                            }
                            #endregion
                            document_time = dt.Rows[i]["document_time"].ToString();
                        }
                        catch(Exception ex)
                        {
                            App.MsgErr("出现一个异常！原因："+ex.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 画7天时间
        /// </summary>
        /// <param name="startTime">开始时间</param>
        private void drawSevenTime(DateTime startTime)
        {
            if (startTime != referTime)
            {
                string[] strTime1 = startTime.GetDateTimeFormats('D')[2].ToString().Split(',');
                //GetDateTimeFormats('D')[2].ToString() 星期四 2011-05-11
                if (strTime1.Length >= 2)
                {
                    lblTime1.Text = strTime1[1];
                    lblTime11.Text = strTime1[0];
                    if (lblTime1.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime1.ForeColor = Color.Red;
                        lblTime11.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(1).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime2.Text = strTime1[1];
                    lblTime12.Text = strTime1[0];
                    if (lblTime2.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime2.ForeColor = Color.Red;
                        lblTime12.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(2).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime3.Text = strTime1[1];
                    lblTime13.Text = strTime1[0];
                    if (lblTime3.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime3.ForeColor = Color.Red;
                        lblTime13.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(3).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime4.Text = strTime1[1];
                    lblTime14.Text = strTime1[0];
                    if (lblTime4.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime4.ForeColor = Color.Red;
                        lblTime14.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(4).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime5.Text = strTime1[1];
                    lblTime15.Text = strTime1[0];
                    if (lblTime5.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime5.ForeColor = Color.Red;
                        lblTime15.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(5).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime6.Text = strTime1[1];
                    lblTime16.Text = strTime1[0];
                    if (lblTime6.Text.Trim() == App.GetSystemTime().ToShortDateString())
                    {
                        lblTime6.ForeColor = Color.Red;
                        lblTime16.ForeColor = Color.Red;
                    }
                }
                strTime1 = startTime.AddDays(6).GetDateTimeFormats('D')[2].ToString().Split(',');
                if (strTime1.Length >= 2)
                {
                    lblTime7.Text = strTime1[1];
                    lblTime17.Text = strTime1[0];
                    if (lblTime7.Text.Trim()== App.GetSystemTime().ToShortDateString())
                    {
                        lblTime7.ForeColor = Color.Red;
                        lblTime17.ForeColor = Color.Red;
                    }
                }
            }
        }
        /// <summary>
        /// 画pacs映像和检查
        /// </summary>
        private void drawPaseandLis(DateTime start_time,int selectIndex)
        {
            string SqlPasc = "select jcsj,jcff as method,jclx from INTERFACEUSER.T_PASC_DATA@DBPACSLINK t inner join t_in_patient b on t.zyh=b.his_id where b.id='" + inPatientInfo.Id + "'";
            //string SqlLis = "select bblsh,jyrq,bbmc from t_lis_sample t inner join t_in_patient b on t.mzh=b.pid where b.pid='" + inPatientInfo.PId + "'";
            string SqlLis = "select c.*,d.YZMC from hnyz_zxyy.View_LIS_SampleInfo@DBHISLINK t inner join hnyz_zxyy.View_LIS_Result@DBHISLINK c on t.bblsh=c.bblsh inner join hnyz_zxyy.intf_emr_undruginfo@dbhislink d on c.yzxmdm=d.yzdm " +
                          "where t.mzh='" + inPatientInfo.PId + "'";
            DateTime paseTime = new DateTime();
            DateTime lisTime = new DateTime();
            int[] pointY ={ 0,0,0,0,0,0,0};
            int widthpp = 25;
            #region  画pacs
            DataSet dts = App.GetDataSet(SqlPasc);
            if (dts != null)
            {
                DataTable dt = dts.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count;i++)
                    {
                        paseTime = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[i]["jcsj"].ToString()).ToShortDateString());
                        if (paseTime != referTime)
                        {
                            TimeSpan c = paseTime.Subtract(Convert.ToDateTime(start_time.ToShortDateString()));//inPatientInfo.In_Time
                            int day = (int)c.TotalDays;
                            //day = day + 1;
                            if (day >= 0 && day < 7)
                            {
                                if (dt.Rows[i]["jclx"].ToString() != "")
                                {
                                    Bifrost.GlassButton btxPacs = new Bifrost.GlassButton();
                                    //Button btxPacs = new Button();
                                    btxPacs.Name = "Pase" + (1 + i).ToString();
                                    btxPacs.Text = dt.Rows[i]["jclx"].ToString();
                                    btxPacs.BackColor = Color.DarkGreen;
                                    btxPacs.Width = 106;
                                    btxPacs.Height = 20;
                                    btxPacs.Click += new EventHandler(btxPacs_Click);

                                    if (day == 0)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C1.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C1.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 1)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C2.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C2.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 2)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C3.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C3.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 3)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C4.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C4.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 4)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C5.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C5.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 5)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C6.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C6.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 6)
                                    {
                                        if (!isHaveSameVal(btxPacs.Text, panel_C7.Controls))
                                        {
                                            btxPacs.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C7.Controls.Add(btxPacs);
                                            pointY[day]++;
                                        }
                                    }
                                }
                                
                            }
                           
                        }
                        
                    }
                }
            }
            #endregion
            #region 画lis
            DataSet dts1 = App.GetDataSet(SqlLis);
            if (dts1 != null)
            {
                DataTable dt1 = dts1.Tables[0];
                if (dt1.Rows.Count > 0)
                {

                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        if (dt1.Rows[j]["cssj"].ToString() != "")
                        {

                           string Year=dt1.Rows[j]["cssj"].ToString().Substring(0,4);
                           string Month=dt1.Rows[j]["cssj"].ToString().Substring(4,2);

                           string Days=dt1.Rows[j]["cssj"].ToString().Substring(6,2);
                           lisTime = Convert.ToDateTime(Year + "-" + Month+"-"+Days);
                        }
                        if (lisTime != referTime)
                        {
                            TimeSpan c = Convert.ToDateTime(lisTime.ToShortDateString()).Subtract(Convert.ToDateTime(start_time.ToShortDateString()));
                            int day = (int)c.TotalDays;
                            //day = day;
                            if (day >= 0 && day < 7)
                            {
                                if (dt1.Rows[j]["yzxmdm"].ToString() != "")
                                {
                                    string yzxmdm = "";
                                    Bifrost.GlassButton btxLis = new Bifrost.GlassButton();
                                    //Button btxLis = new Button();
                                    btxLis.Name = "Lis" + (j + 1).ToString();
                                    
                                    btxLis.Text = dt1.Rows[j]["YZMC"].ToString();

                                    if (btxLis.Text.Length > 7)
                                    {
                                        btxLis.Text = btxLis.Text.Substring(0, 7) + "...";
                                    }

                                    yzxmdm = dt1.Rows[j]["yzxmdm"].ToString();
                                    btxLis.Width = 106;
                                    btxLis.Height = 20;
                                    string strnull = " ";
                                    string sqlJgbz = "select c.jgbz,c.cssj from t_lis_sample t " +
                                                      "inner join  hnyz_zxyy.View_LIS_Result@DBHISLINK c on t.bblsh=c.bblsh " +
                                                      "where t.MZH='" + inPatientInfo.PId + "'and c.yzxmdm='" + yzxmdm + "' and  c.jgbz<>'" + strnull + "'";
                                    //and  to_char(c.cssj, 'YYYY-MM-DD')='" + lisTime.ToShortDateString() + "'
                                    DataSet dtsjgbz = App.GetDataSet(sqlJgbz);
                                    if (dtsjgbz != null)
                                    {
                                        if (dtsjgbz.Tables[0].Rows.Count > 0)
                                        {
                                            for (int liscount = 0; liscount < dtsjgbz.Tables[0].Rows.Count; liscount++)
                                            {
                                                string lisTime2 = "";
                                                if (dtsjgbz.Tables[0].Rows[liscount]["cssj"].ToString() != "")
                                                {

                                                    string Year1 = dt1.Rows[j]["cssj"].ToString().Substring(0, 4);
                                                    string Month1 = dt1.Rows[j]["cssj"].ToString().Substring(4, 2);
                                                    string Days1 = dt1.Rows[j]["cssj"].ToString().Substring(6, 2);

                                                    lisTime2 = Year1 + "-" + Month1 + "-" + Days1;
                                                }

                                                if (lisTime2 == lisTime.ToShortDateString())
                                                    strnull += dtsjgbz.Tables[0].Rows[liscount]["jgbz"].ToString();
                                            }
                                            if (strnull.Contains("H") || strnull.Contains("L") || strnull.Contains("阳"))
                                                btxLis.ForeColor = Color.Red;
                                            else
                                                btxLis.ForeColor = Color.Purple;
                                        }
                                        else
                                            btxLis.ForeColor = Color.Purple;
                                    }
                                    btxLis.Tag += dt1.Rows[j]["bblsh"].ToString();
                                    btxLis.Click += new EventHandler(btxLis_Click);

                                    if (day == 0)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C1.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C1.Controls.Add(btxLis);
                                            pointY[day]++;

                                        }
                                    }
                                    else if (day == 1)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C2.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C2.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 2)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C3.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C3.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 3)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C4.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C4.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 4)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C5.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C5.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 5)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C6.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C6.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                    else if (day == 6)
                                    {
                                        if (!isHaveSameVal(btxLis.Text, panel_C7.Controls))
                                        {
                                            btxLis.Location = new Point(0, pointY[day] * widthpp);
                                            panel_C7.Controls.Add(btxLis);
                                            pointY[day]++;
                                        }
                                    }
                                }
                               
                            }
                            
                        }
                        
                    }
                }
            }
            #endregion
            int maxh=MaxHeight(pointY);
            if (maxh <= 4)
                maxh = 4;
            int widthp = 21;
            panel17.Height =  (maxh - 1) * 25 + widthp;
            panel_C1.Height = (maxh - 1) * 25 + widthp;
            panel_C2.Height = (maxh - 1) * 25 + widthp;
            panel_C3.Height = (maxh - 1) * 25 + widthp;
            panel_C4.Height = (maxh - 1) * 25 + widthp;
            panel_C5.Height = (maxh - 1) * 25 + widthp;
            panel_C6.Height = (maxh - 1) * 25 + widthp;
            panel_C7.Height = (maxh - 1) * 25 + widthp;

        }

        /// <summary>
        /// 判断是否已经有相同名称
        /// </summary>
        /// <param name="val"></param>
        /// <param name="ConArrs">控件集合</param>
        /// <returns></returns>
        private bool isHaveSameVal(string val, System.Windows.Forms.Control.ControlCollection ConArrs)
        {
            if (ConArrs != null)
            {
                for (int i = 0; i < ConArrs.Count; i++)
                {
                    if (ConArrs[i].Text == val)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取最大值
        /// </summary>
        /// <param name="ints"></param>
        private int MaxHeight(int[] ints)
        {
            int max = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] > max)
                    max = ints[i];
            }
            return max;
        }

        void btxLis_Click(object sender, EventArgs e)
        {
            #region
            Bifrost.GlassButton btlis = (Bifrost.GlassButton)sender;
            //string datetimes = "";
            //datetimes = gettimestr(btlis.Parent.Name);
            string bblsh = btlis.Tag.ToString();
            if (bblsh != "")
            {
                string Sqlcondition = " and a.bblsh='" + bblsh+"'";//" and b.yzxmmc='" + btlis.Text + "' and jyrq=to_date('" + datetimes + "','yyyy-MM-dd')";
                Bifrost.HisInstance.FrmLis frm = new Bifrost.HisInstance.FrmLis(inPatientInfo.PId, Sqlcondition);                
                frm.ShowDialog();               
            }
            #endregion
        }

        void btxPacs_Click(object sender, EventArgs e)
        {            
            string datetimes="";
            Bifrost.GlassButton btpacs = (Bifrost.GlassButton)sender;
            datetimes=gettimestr(btpacs.Parent.Name);
            if (datetimes != "")
            {
                string Sqlcondition = " and jclx='" + btpacs.Text + "' and to_char(jcsj,'yyyy-MM-dd')='" + datetimes.Trim() + "'";
                Bifrost.HisInStance.frm_Pasc frm = new Bifrost.HisInStance.frm_Pasc(inPatientInfo, Sqlcondition);                
                frm.ShowDialog();             
            }
        }

        private string gettimestr(string pnalnames)
        {
            string datetimes = "";
            if (pnalnames == "panel_C1")
            {
                datetimes = lblTime1.Text;
            }
            else if (pnalnames == "panel_C2")
            {
                datetimes = lblTime2.Text;
            }
            else if (pnalnames == "panel_C3")
            {
                datetimes = lblTime3.Text;
            }
            else if (pnalnames == "panel_C4")
            {
                datetimes = lblTime4.Text;
            }
            else if (pnalnames == "panel_C5")
            {
                datetimes = lblTime5.Text;
            }
            else if (pnalnames == "panel_C6")
            {
                datetimes = lblTime6.Text;
            }
            else if (pnalnames == "panel_C7")
            {
                datetimes = lblTime7.Text;
            }

            return datetimes;
        }

     

        /// <summary>
        /// 重置，清屏
        /// </summary>
        private void ClearNumber()
        {
            #region 重置，清屏
            lblTime1.Text = "";
            lblTime11.Text = "";
            lblTime2.Text = "";
            lblTime12.Text = "";
            lblTime3.Text = "";
            lblTime13.Text = "";
            lblTime4.Text = "";
            lblTime14.Text = "";
            lblTime5.Text = "";
            lblTime15.Text = "";
            lblTime6.Text = "";
            lblTime16.Text = "";
            lblTime7.Text = "";
            lblTime17.Text = "";

            lblTime1.ForeColor = SystemColors.ControlText;
            lblTime11.ForeColor = SystemColors.ControlText;
            lblTime2.ForeColor = SystemColors.ControlText;
            lblTime12.ForeColor = SystemColors.ControlText;
            lblTime3.ForeColor = SystemColors.ControlText;
            lblTime13.ForeColor = SystemColors.ControlText;
            lblTime4.ForeColor = SystemColors.ControlText;
            lblTime14.ForeColor = SystemColors.ControlText;
            lblTime5.ForeColor = SystemColors.ControlText;
            lblTime15.ForeColor = SystemColors.ControlText;
            lblTime6.ForeColor = SystemColors.ControlText;
            lblTime16.ForeColor = SystemColors.ControlText;
            lblTime7.ForeColor = SystemColors.ControlText;
            lblTime17.ForeColor = SystemColors.ControlText;

            panel_E1.Controls.Clear();
            panel_E2.Controls.Clear();
            panel_E3.Controls.Clear();
            panel_E4.Controls.Clear();
            panel_E5.Controls.Clear();
            panel_E6.Controls.Clear();
            panel_E7.Controls.Clear();
            panel_C1.Controls.Clear();
            panel_C2.Controls.Clear();
            panel_C3.Controls.Clear();
            panel_C4.Controls.Clear();
            panel_C5.Controls.Clear();
            panel_C6.Controls.Clear();
            panel_C7.Controls.Clear();
            panel_Bl1.Controls.Clear();
            panel_Bl2.Controls.Clear();
            panel_Bl3.Controls.Clear();
            panel_Bl4.Controls.Clear();
            panel_Bl5.Controls.Clear();
            panel_Bl6.Controls.Clear();
            panel_Bl7.Controls.Clear();
            //panel_D1.Controls.Clear();
            //panel_D2.Controls.Clear();
            //panel_D3.Controls.Clear();
            //panel_D4.Controls.Clear();
            //panel_D5.Controls.Clear();
            //panel_D6.Controls.Clear();
            //panel_D7.Controls.Clear();
            //panel_P1.Controls.Clear();
            //panel_P2.Controls.Clear();
            //panel_P3.Controls.Clear();
            //panel_P4.Controls.Clear();
            //panel_P5.Controls.Clear();
            //panel_P6.Controls.Clear();
            //panel_P7.Controls.Clear();
#endregion
        }
        /// <summary>
        /// 画病历文书
        /// </summary>
        /// <param name="start_time">周期开始时间</param>
        private void drawErmDocument(DateTime start_time)
        {
            string sqlErmDoc = "select b.doc_name,b.textname,document_time,b.tid from t_in_patient a inner join t_patients_doc b on a.id=b.patient_id where  a.id='"+inPatientInfo.Id+"'";
            DataSet ds = App.GetDataSet(sqlErmDoc);
            string doc_name = string.Empty;
            int widthpp = 25;
            int[] pointY ={ 0,0,0,0,0,0,0};
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                   DataTable  dt = ds.Tables[0];
                   if (dt.Rows.Count > 0)
                   {
                       for (int i = 0; i < dt.Rows.Count; i++)
                       {
                           doc_name = dt.Rows[i]["doc_name"].ToString();
                           if (doc_name.Trim().Length != 0)
                           {
                               try
                               {
                                   string strTime = Convert.ToDateTime(App.GetTimeString(doc_name)).ToShortDateString();//短时间格式
                                   string starttime = start_time.ToShortDateString();
                                   TimeSpan ts = Convert.ToDateTime(strTime).Subtract(Convert.ToDateTime(starttime));
                                   int day = (int)ts.TotalDays;
                                   if (day >= 0 && day < 7)
                                   {

                                       Bifrost.GlassButton btnxEmrDoc = new Bifrost.GlassButton();
                                       btnxEmrDoc.Name = "病历文书" + Convert.ToString(i + 1);
                                       btnxEmrDoc.BackColor = Color.Yellow;
                                       btnxEmrDoc.ForeColor = Color.Black;
                                       string textname = dt.Rows[i]["textname"].ToString();
                                       if (textname != "病程记录" && textname.Length != 0)
                                       {
                                           btnxEmrDoc.Text = textname;
                                       }
                                       else if (textname == "病程记录")
                                       {
                                           if (doc_name.Replace(App.GetTimeString(doc_name), " ").Trim().Length != 0)
                                           {
                                               btnxEmrDoc.Text = doc_name.Replace(App.GetTimeString(doc_name), " ").Trim();
                                               //if (btnxEmrDoc.Text.Length > 9)
                                               //    btnxEmrDoc.Text = btnxEmrDoc.Text.Remove(7);
                                           }
                                           else
                                           {
                                               btnxEmrDoc.Text = textname;
                                           }
                                       }
                                       btnxEmrDoc.Width = 106;
                                       btnxEmrDoc.Height = 20;
                                       btnxEmrDoc.Location = new Point(0, pointY[day] * widthpp);
                                       btnxEmrDoc.Click += new EventHandler(btnxEmrDoc_Click);
                                       pointY[day]++;
                                       btnxEmrDoc.Tag = dt.Rows[i]["tid"].ToString();
                                       if (day == 0)
                                       {
                                           panel_Bl1.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 1)
                                       {
                                           panel_Bl2.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 2)
                                       {
                                           panel_Bl3.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 3)
                                       {
                                           panel_Bl4.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 4)
                                       {
                                           panel_Bl5.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 5)
                                       {
                                           panel_Bl6.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 6)
                                       {
                                           panel_Bl7.Controls.Add(btnxEmrDoc);
                                       }
                                       if (day == 7)
                                       {
                                           panel_Bl1.Controls.Add(btnxEmrDoc);
                                       }
                                   }
                               }
                               catch
                               { }
                           }
                       }
                   }
                }
            }
            int maxh = MaxHeight(pointY);
            if (maxh <= 4)
                maxh = 4;
            int widthp = 21;
            panel10.Height = (maxh - 1) * 25 + widthp;
            panel_Bl1.Height = (maxh - 1) * 25 + widthp;
            panel_Bl2.Height = (maxh - 1) * 25 + widthp;
            panel_Bl3.Height = (maxh - 1) * 25 + widthp;
            panel_Bl4.Height = (maxh - 1) * 25 + widthp;
            panel_Bl5.Height = (maxh - 1) * 25 + widthp;
            panel_Bl6.Height = (maxh - 1) * 25 + widthp;
            panel_Bl7.Height = (maxh - 1) * 25 + widthp;
        }
        //根据病人id，文书id生成编辑器。
        void btnxEmrDoc_Click(object sender, EventArgs e)
        {
            Bifrost.GlassButton btnx = (Bifrost.GlassButton)sender;
            int tid = Convert.ToInt32(btnx.Tag.ToString().Trim());
            string sql = "select * from t_patients_doc where tid=" + tid + " and patient_id='" + inPatientInfo.Id + "'";
            DataSet dts = App.GetDataSet(sql);
            if (dts != null)
            {
                if (dts.Tables.Count > 0)
                {
                    DataTable dt = dts.Tables[0];
                    if (dt != null)
                    {

                        int txtid= Convert.ToInt32(dt.Rows[0]["textkind_id"].ToString());
                        int belongtosys_id=Convert.ToInt32(dt.Rows[0]["belongtosys_id"].ToString());
                        int sickkind_id=Convert.ToInt32(dt.Rows[0]["sickkind_id"].ToString());
                        string txtname=dt.Rows[0]["textName"].ToString();
                        int Tid=tid;
                        string content=App.DownLoadFtpPatientDoc(Tid.ToString() + ".xml", inPatientInfo.Id.ToString());
                        if (content == "")
                        {
                            content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + Tid.ToString() + "", 0, "CONTENT");
                        }
                        //false
                        //dt.Rows[0]["patients_doc"].ToString()
                        popupView pop = new popupView(txtid, belongtosys_id, sickkind_id, txtname, Tid, inPatientInfo, content, "姓名：" + inPatientInfo.Patient_Name + ",住院号：" + inPatientInfo.Id + " --" + btnx.Text);
                        pop.ShowDialog();                                              
                    }
                }
            }
            
        }


        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentindex != comboBoxEx1.SelectedIndex)
            {
                ClearNumber();
                int i = (int)(comboBoxEx1.SelectedIndex);
                start_time = inPatientInfo.In_Time.AddDays(i * 7);
                drawSevenTime(start_time);
                getInfo(start_time, i);
                drawPaseandLis(start_time, i);
                drawErmDocument(start_time);
                currentindex = comboBoxEx1.SelectedIndex;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex != 0)
                comboBoxEx1.SelectedIndex = comboBoxEx1.SelectedIndex - 1;
            else
            {
                App.Msg("当前周是第一周");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex >=comboBoxEx1.Items.Count-1)
                App.Msg("当前周是最后一周");
            else
                comboBoxEx1.SelectedIndex = comboBoxEx1.SelectedIndex + 1;
        }

    }
}