using Base_Function.BASE_COMMON;
using Bifrost;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using System;
using System.Data;
using System.Drawing;
//using Bifrost_Doctor.CommonClass;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR
{
    public class UCPictureBox : System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// 病人小卡的初始化横坐标
        /// </summary>
        private int card_X = 0;
        /// <summary>
        /// 病人小卡的初始化纵坐标
        /// </summary>
        private int card_Y = 0;
        /// <summary>
        /// 鼠标初始化的横坐标
        /// </summary>
        private static int mX = 0;
        /// <summary>
        /// 鼠标初始化的纵坐标
        /// </summary>
        private static int mY = 0;
        /// <summary>
        /// 鼠标释放的鼠标横坐标
        /// </summary>
        private static int MouseUp_X = 0;
        /// <summary>
        /// 鼠标释放的鼠标纵坐标
        /// </summary>
        private static int MouseUp_Y = 0;
        /// <summary>
        /// 判断是否按下左键，按下true，释放为false
        /// </summary>
        private bool KeyPress = false;
        /// <summary>
        /// 是否按住左键，移动小卡
        /// </summary>
        private bool PressLeftMove = false;
        private InPatientInfo inpat;

        public InPatientInfo Inpat
        {
            get { return inpat; }
            set { inpat = value; }
        }
        private NodeCollection nodes;
        //private TreeNode nodeInpatient = new TreeNode();
        private bool flag = false;
        private System.ComponentModel.IContainer components;                    //判断是否是跳到文书操作
        private bool ChangeColor = false;             //打开右键菜单，小卡还是蓝色
        //鼠标移到小卡，触发动画的效果
        //public event Bifrost_Doctor.ucHospitalIofn.DeleFlash EventFlash;
        //public event Bifrost_Doctor.ucHospitalIofn.DelerefInpatient EventRefinpatient;
        public event ucHospitalIofn.DelerefInpatient2 EventReflash;

        //小卡扩展界面隐藏
        public event ucHospitalIofn.CardToolTipHide ToolTipHide;

        public static string dianose_Name = "";

        //小卡父窗体对象
        DevComponents.DotNetBar.TabControl tabControl_Patient = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UCPictureBox()
        {

        }

        /// <summary>
        /// 年龄差
        /// </summary>
        /// <param name="dtBirthday">出生年月日</param>
        /// <param name="dtNow">当前时间</param>
        /// <returns></returns>
        public static string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty;                         // 年龄的字符串表示
            int intYear = 0;                                    // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天

            // 如果没有设定出生日期, 返回空
            

            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;
            strAge = intYear.ToString();
            // 格式化年龄输出
            //if (intYear >= 1)                                            // 年份输出
            //{
            //    strAge = intYear.ToString() + "岁";
            //}

            //if (intMonth > 0 && intYear <= 1)                           // 1岁以下可以输出月数
            //{
            //    strAge += intMonth.ToString() + "月";
            //}

            //if (intDay >= 0 && intYear < 1)                              // 一岁以下可以输出天数
            //{
            //    if (strAge.Length == 0 || intDay > 0)
            //    {
            //        strAge += intDay.ToString() + "日";
            //    }
            //}

            return strAge;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inpatinetInfo"></param>
        /// <param name="node"></param>
        /// <param name="dianose_name"></param>
        public UCPictureBox(InPatientInfo inpatinetInfo, NodeCollection node, string dianose_name)
        {
            if (inpatinetInfo != null)
            {
                if (inpatinetInfo.Age == "0" && inpatinetInfo.Id != 0)
                {
                    //inpatinetInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(inpatinetInfo.Birthday).Year);
                    inpatinetInfo.Age = GetAge(Convert.ToDateTime(inpatinetInfo.Birthday), App.GetSystemTime());
                    if ((inpatinetInfo.Child_age != null || inpatinetInfo.Child_age != "") && inpatinetInfo.Age=="0")
                    {
                        inpatinetInfo.Age = inpatinetInfo.Child_age;
                        inpatinetInfo.Age_unit = "";
                    }
                    else
                    {
                        inpatinetInfo.Age_unit = "岁";
                    }
                }
                else if (inpatinetInfo.Age!=null&&inpatinetInfo.Age.Contains("岁"))
                {
                    inpatinetInfo.Age_unit = "";
                }
            }

            this.Inpat = inpatinetInfo;
            //this.BackColor = SystemColors.Info;
            this.nodes = node;
            this.Width = 210;//206
            this.Height = 131;//181
            this.BorderStyle = BorderStyle.None;

            dianose_Name = dianose_name;//App.ReadSqlVal(sql, 0, "diagnose_name");
                                        //this.BackgroundImage = global::Base_Function.Resource.card_unselect;
            this.BackColor = Color.Transparent;
            Img(inpat);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            ////移动中病人小卡的横坐标
            //int x = 0;
            ////移动中病人小卡的纵坐标
            //int y = 0;
            //if (e.Button == MouseButtons.Left && KeyPress == true)
            //{
            //    x = Cursor.Position.X - mX + card_X;
            //    y = Cursor.Position.Y - mY +card_Y;
            //    this.Location = new Point(x, y);
            //    PressLeftMove = true;
            //}
            //base.OnMouseMove(e);
            //if (!DataInit.isInAreaSucceed)
            //{   
            //this.BackgroundImage = global::Base_Function.Resource.card_select;
            this.BackColor =Color.Lavender;
            
            //} 
            try
            {
                if (inpat != null)
                {
                    if (inpat.Id != 0)
                    {
                        if (inpat.Sick_Bed_Id != 0)
                        {
                            string sex = null;
                            if (inpat.Gender_Code.Equals("0") || inpat.Gender_Code.Equals("男"))
                            {
                                sex = "男";
                            }
                            else
                            {
                                sex = "女";
                            }
                            App.SetMainFrmMsgToolBarText(inpat.Sick_Bed_Name + "床  " + "ID:" + inpat.Id.ToString() +
                                                        "  住院号:" + inpat.PId + "  姓名:" + inpat.Patient_Name +
                                                        "  性别:" + sex + "  年龄:" + inpat.Age.ToString() + inpat.Age_unit +
                                                        "  入院时间:" + inpat.In_Time.ToString() +
                                                        "  当前科室:" + inpat.Sick_Area_Name);
                        }
                    }
                    else
                    {
                        App.SetMainFrmMsgToolBarText("");
                    }
                }
            }

            catch
            { }
            if (EventReflash != null)
            {
                EventReflash(inpat, this);
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //base.OnMouseLeave(e);
            if (!DataInit.isInAreaSucceed)
            {
                if (Inpat.IsChangeSection == 'T')//运行病例查阅
                {
                    //this.BackgroundImage = global::Base_Function.Resource.card_Red_Turn;
                    Graphics gh = this.CreateGraphics();
                    gh.DrawImage(global::Base_Function.Resource.trunsection, global::Base_Function.Resource.card_unselect.Width -
                             global::Base_Function.Resource.trunsection.Width - 8, 8, global::Base_Function.Resource.trunsection.Width,
                             global::Base_Function.Resource.trunsection.Height);
                }
                else if (Inpat.IsHaveRight)//授权文书背景图片
                {
                    //this.BackgroundImage = global::Base_Function.Resource.card_Purple;
                }
                else
                {
                    //this.BackgroundImage = global::Base_Function.Resource.card_unselect;
                    this.BackColor = Color.Transparent;
                }
            }
            if (ToolTipHide != null)
            {
                ToolTipHide(this);
            }

        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
            DataInit.boolAgree = false;
            DataInit.isRightDoc = false;
            if (e.Button == MouseButtons.Left)
            {
                if (inpat.Id != 0)
                {
                    string action_State = DataInit.GetActionState(inpat.Id.ToString());
                    if (action_State == "4" || action_State == "3")
                    {
                        tabControl_Patient = (this.Parent.Parent.Parent.Parent.Parent.Parent.Parent) as DevComponents.DotNetBar.TabControl;
                        //验证TabControl是否有重复
                        if (tabControl_Patient != null)
                        {
                            for (int i = 0; i < tabControl_Patient.Tabs.Count; i++)
                            {
                                if (inpat.Id.ToString() == tabControl_Patient.Tabs[i].Name)
                                {
                                    tabControl_Patient.SelectedTabIndex = i;
                                    return;
                                }
                            } 
                        }
                        ucMain main = (this.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent) as ucMain;
                        main.action_State = action_State;
                        main.currentPatient = inpat;
                        
                        TabControlPanel tabctpnDoc = new TabControlPanel();
                        tabctpnDoc.AutoScroll = true;
                        TabItem pageDoc = new TabItem();
                        pageDoc.Name = inpat.Id.ToString();
                        pageDoc.Text = inpat.Sick_Bed_Name+" "+inpat.Patient_Name;
                        pageDoc.Click += new EventHandler(page_Click);
                        pageDoc.Tag = inpat;
                        ucDoctorOperater fm = new ucDoctorOperater(inpat);
                        fm.Dock = DockStyle.Fill;
                        tabctpnDoc.Controls.Add(fm);
                        tabctpnDoc.Dock = DockStyle.Fill;
                        pageDoc.AttachedControl = tabctpnDoc;
                        tabControl_Patient.Controls.Add(tabctpnDoc);
                        tabControl_Patient.Tabs.Add(pageDoc);
                        tabControl_Patient.Refresh();
                        tabControl_Patient.SelectedTab = pageDoc;
                        flag = true;
                    }
                }
                else
                {
                    App.Msg("该床是空床！");
                }
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // UCPictureBox
            // 
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        public void Img(InPatientInfo inpatient)
        {
          
            if (inpatient.IsHaveRight)//授权文书背景图片
            {
                //this.BackgroundImage = global::Base_Function.Resource.card_Purple;
            }
            this.BackColor = Color.Transparent;
            if (inpatient != null)
            {
                Bitmap b = new Bitmap(210, 131);//new Bitmap(206,181);
                Graphics gh = Graphics.FromImage(b);
                gh.DrawRectangle(new Pen(  Color.FromArgb(160,198,229)), 0, 0, global::Base_Function.Resource.card_unselect.Width-1, global::Base_Function.Resource.card_unselect.Height-1);


                string sick_bed_name = "";
                sick_bed_name = inpat.Sick_Bed_Name;
                if (inpatient.Sick_Bed_Name != null)
                    if (!inpatient.Sick_Bed_Name.Contains("床"))
                        sick_bed_name = inpat.Sick_Bed_Name + "床";

                //护理等级
                string nurse_Name = "";
                if (App.IsNumeric(inpatient.Nurse_Level))
                {
                    nurse_Name = DataInit.GetNurse_Leavel_Name(inpatient.Nurse_Level);
                }
                else
                {
                    nurse_Name = inpatient.Nurse_Level;
                }

                if (inpatient.IsChangeSection == 'T')//是否转科
                {                   
                    gh.DrawImage(global::Base_Function.Resource.trunsection, global::Base_Function.Resource.card_unselect.Width - 
                              global::Base_Function.Resource.trunsection.Width - 8, 8, global::Base_Function.Resource.trunsection.Width, 
                              global::Base_Function.Resource.trunsection.Height);
                }

                //病危病重
                //string sick_Degree = stringFormat(inpatient.Sick_Degree);
                if (inpatient.Id != 0)
                {
                    if (inpatient.Gender_Code.Equals("1") || inpatient.Gender_Code.Contains("女")) //女
                    {
                        gh.DrawImage(global::Base_Function.Resource.card_woman, 20, 4, 22,22);//, new Point(4, 1));
                    }
                    else
                    {
                        gh.DrawImage(global::Base_Function.Resource.card_man, 20, 4, 22,22);//new Point(4, 1));
                    }
                    //if (inpatient.State.Equals("1"))
                    //{
                    gh.DrawString(inpatient.Patient_Name + " " + (inpatient.Age.Replace("-","") == "" ? inpatient.Child_age : inpatient.Age + inpatient.Age_unit), new Font("宋体", 9F, FontStyle.Bold,
                                GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width+8,8));

                      
                    //}
                    //else
                    //{
                    //    gh.DrawString(inpatient.Patient_Name + " " + inpatient.Age.ToString() + inpatient.Age_unit, new Font("宋体", 10F, FontStyle.Bold,
                    //       GraphicsUnit.Point, ((byte)(134))), Brushes.DarkRed, new PointF(30, 5));
                    //}
                    //gh.DrawString(sick_Degree, new Font("宋体", 12F, FontStyle.Regular,
                    //                GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(190, 5));

                    
                    if (inpatient.Sick_Degree .IndexOf( "病危" )>=0|| inpatient.Sick_Degree.IndexOf("3")>=0)
                    {
                        gh.DrawImage(global::Base_Function.Resource.wei,190,5, 18, 18);
                    }
                    else if (inpatient.Sick_Degree.IndexOf("2") >= 0 || inpatient.Sick_Degree.IndexOf("病重") >= 0 || inpatient.Sick_Degree.Contains("急"))
                    {
                        gh.DrawImage(global::Base_Function.Resource.zhong, 190, 5, 18, 18);
                    }

                    gh.DrawString("住 院 号：" + inpatient.PId, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(8, 41));
                    gh.DrawString("住院日期：" + string.Format("{0:g}", inpatient.In_Time), new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(8, 59));
                    gh.DrawString("管床医生：" + inpatient.Sick_Doctor_Name, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(8, 80));
                    gh.DrawString("初步诊断：" + dianose_Name, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(8, 100));

                    
                    gh.DrawImage(global::Base_Function.Resource.bg ,  global::Base_Function.Resource.card_man.Width + 110, 24, System.Text.Encoding.Default.GetBytes(sick_bed_name).Length*10+2,22);//110, 8

                    gh.DrawString(sick_bed_name, new Font("宋体", 14F, FontStyle.Regular,
                                GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 110, 25));//110, 8
                    

                    //if (DataInit.GetActionState(inpatient.Id.ToString()) == "3")
                    //{
                    //    gh.DrawString( sick_bed_name, new Font("宋体", 14F, FontStyle.Regular,
                    //        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(120, 8));
                    //}
                    //else
                    //{
                    //    gh.DrawString(sick_bed_name, new Font("宋体", 14F, FontStyle.Regular,
                    //            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 120, 8));
                    //}

                    try
                    {//传染病提醒
                        if (DataInit.IsPatientInfection(inpatient.Id))
                        {
                            gh.DrawImage(global::Base_Function.Resource.提示, 10, 111,
                                global::Base_Function.Resource.提示.Width, global::Base_Function.Resource.提示.Height);
                        }
                    }
                    catch (System.Exception ex)
                    { }

                    /*
                     *护理等级 
                     */
                    if (nurse_Name == "特级护理")
                    {
                        //gh.DrawString("▲", new Font("宋体", 9F, FontStyle.Regular,
                        //    GraphicsUnit.Point, ((byte)(134))), Brushes.Purple, new PointF(150, global::Base_Function.Resource.card_select.Height-15));

                        gh.DrawImage(global::Base_Function.Resource.teji, 150, global::Base_Function.Resource.card_select.Height - 15,18, 18);

                    }
                    else if (nurse_Name == "一级护理")
                    {
                        //gh.DrawString("▲", new Font("宋体", 9F, FontStyle.Regular,
                        //    GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(150, global::Base_Function.Resource.card_select.Height - 15));

                        gh.DrawImage(global::Base_Function.Resource._1ji, 150, global::Base_Function.Resource.card_select.Height - 15, 18, 18);


                    }
                    else if (nurse_Name =="二级护理")
                    {
                        //gh.DrawString("▲", new Font("宋体", 9F, FontStyle.Regular,
                        //    GraphicsUnit.Point, ((byte)(134))), Brushes.Blue, new PointF(150, global::Base_Function.Resource.card_select.Height - 15));
                        gh.DrawImage(global::Base_Function.Resource._2ji, 150, global::Base_Function.Resource.card_select.Height - 15, 18, 18);
                    }
                    else if (nurse_Name == "三级护理")
                    {
                        
                    }


                    //压疮、跌倒、坠床状态提醒
                        string sql_ydz = "select * from t_dyz where patient_id=" + inpat.Id;
                        DataSet ds_ydz = App.GetDataSet(sql_ydz);
                        if (ds_ydz != null)
                        {
                            string ydz = "";
                            if (ds_ydz.Tables[0].Rows.Count > 0)
                            {
                                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                                {
                                    //压疮
                                    if (ds_ydz.Tables[0].Rows[0]["yc"].ToString() != "")
                                    {
                                        ydz = ds_ydz.Tables[0].Rows[0]["yc"].ToString();
                                    }
                                    //跌倒
                                    if (ds_ydz.Tables[0].Rows[0]["dd"].ToString() != "")
                                    {
                                        if (ydz == "")
                                        {
                                            ydz = ds_ydz.Tables[0].Rows[0]["dd"].ToString();
                                        }
                                        else
                                        {
                                            ydz += " " + ds_ydz.Tables[0].Rows[0]["dd"].ToString();
                                        }
                                    }
                                    //坠床
                                    if (ds_ydz.Tables[0].Rows[0]["zc"].ToString() != "")
                                    {
                                        if (ydz == "")
                                        {
                                            ydz = ds_ydz.Tables[0].Rows[0]["zc"].ToString();
                                        }
                                        else
                                        {
                                            ydz += " " + ds_ydz.Tables[0].Rows[0]["zc"].ToString();
                                        }
                                    }
                                    //导管
                                    if (ds_ydz.Tables[0].Rows[0]["dg"].ToString() != "")
                                    {
                                        if (ydz == "")
                                        {
                                            ydz = ds_ydz.Tables[0].Rows[0]["dg"].ToString();
                                        }
                                        else
                                        {
                                            ydz += " " + ds_ydz.Tables[0].Rows[0]["dg"].ToString();
                                        }
                                    }
                                }

                            }
                          
                            if (ydz != "")
                            {
                                gh.DrawString(ydz, new Font("宋体", 9F, FontStyle.Regular,
                                GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(5, global::Base_Function.Resource.card_select.Height - 15));
                            }
                        }

                    if (inpatient.Die_flag == 1)
                    {
                        //死亡病人
                        gh.DrawString("死亡", new Font("宋体", 9F, FontStyle.Regular,
                               GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(125, 8));
                    }
                    if (inpatient.Section_Id == 20)//产科
                    {
                        //获得当前病人的婴儿数量
                        int count = GetBabyNumber(inpatient.PId);
                        if (count > 1)
                        {
                            gh.DrawImage(global::Base_Function.Resource.baby, new Point(130, 8));
                            gh.DrawString("x" + count.ToString(), new Font("宋体", 11F, FontStyle.Regular,
                                    GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(148, 8));

                        }
                        else if (count == 1)
                        {
                            gh.DrawImage(global::Base_Function.Resource.baby, new Point(130, 8));
                        }
                    }








                }
                else
                {                                        
                    gh.DrawImage(global::Base_Function.Resource.unbed, 8, 8, global::Base_Function.Resource.unbed.Width, global::Base_Function.Resource.unbed.Height);                                   

                    gh.DrawString("住 院 号：" + inpatient.PId, new Font("宋体", 9F, FontStyle.Regular,
                      GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 8, 33));
                    gh.DrawString("住院日期：", new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 8, 54));
                    gh.DrawString("管床医生：" + inpatient.Sick_Doctor_Name, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 8, 75));
                    gh.DrawString("初步诊断：" + dianose_Name, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 8, 96));
                  
                    gh.DrawString("床   号：" + sick_bed_name, new Font("宋体", 10F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(global::Base_Function.Resource.card_man.Width + 8, 12));
                   

                    ///*
                }
                this.SizeMode = PictureBoxSizeMode.CenterImage;
                gh.Dispose();
                this.Image = b;
                //b.Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                DataInit.isInAreaSucceed = false;
                //this.BackColor = Color.SkyBlue;

                for (int i = 0; i < this.Parent.Controls.Count; i++)
                {
                    if (this.Parent.Controls[i] != this)
                    {
                        //this.Parent.Controls[i].BackColor = SystemColors.Info;
                    }
                }
                //if (e.Button == MouseButtons.Left)
                //{
                //    mX = Cursor.Position.X;
                //    mY = Cursor.Position.Y;
                //    card_X = this.Location.X;
                //    card_Y = this.Location.Y;
                //    KeyPress = true;
                //    this.BringToFront();
                //}
            }
            catch
            {

            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //MouseUp_X = Cursor.Position.X;
            //MouseUp_Y = Cursor.Position.Y;
            //KeyPress = false;
            //if(PressLeftMove) //按住左键移动过小卡
            //{
            //    PressLeftMove = false;
            //    Panel pnl = this.Parent as Panel;
            //    for (int i = 0; i < pnl.Controls.Count;i++)
            //    {
            //        int x = pnl.Controls[i].Location.X;
            //        int y = pnl.Controls[i].Location.Y;
            //        /*
            //         *算出当前病人小卡的对角线坐标
            //         */
            //        Point p_start = pnl.Controls[i].PointToScreen(pnl.Controls[i].Location);
            //        Point p = new Point(pnl.Controls[i].Location.X + pnl.Controls[i].Width,
            //                            pnl.Controls[i].Location.Y + pnl.Controls[i].Height);
            //        Point p_diagonal = pnl.Controls[i].PointToScreen(p);
            //        int diagonal_X = p_diagonal.X;
            //        int diagonal_Y = p_diagonal.Y;
            //        if (MouseUp_X >= p_start.X && MouseUp_X <= diagonal_X &&
            //            MouseUp_Y >= p_start.Y && MouseUp_Y <= diagonal_Y)
            //        {
            //            if (App.Ask("确定要换床吗？"))
            //            {
            //                InPatientInfo Tartget_Inpat = pnl.Controls[i].Tag as InPatientInfo;
            //                Update_Bed(Tartget_Inpat);
            //                if (DataInit.isInAreaSucceed)
            //                {
            //                    pnl.Controls[i].Location = new Point(x, y);
            //                    this.Location = new Point(card_X, card_Y);
            //                    ucHospitalIofn ucHospitalIofn1 = this.Parent.Parent.Parent as ucHospitalIofn;
            //                    TreeNodeCollection nodetemp = ucHospitalIofn1.nodetemp;
            //                    TreeNode node = DataInit.RefCardTree(nodetemp, inpat);
            //                    if (node != null)
            //                    {
            //                        foreach (TreeNode tempNode in nodetemp[0].Nodes["tnSection_patient"].Nodes)
            //                        {
            //                            if (tempNode.Name == inpat.Section_Id.ToString())
            //                            {
            //                                node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
            //                                //把当前选中的节点移到科室病人节点下
            //                                DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
            //                            }
            //                        }
            //                    }
            //                    string name = inpat.Patient_Name;
            //                    string sex = DataInit.StringFormat(inpat.Gender_Code);
            //                    string bed_no = inpat.Sick_Bed_Name;
            //                    string doctor_Name = inpat.Sick_Doctor_Name;
            //                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
            //                    App.SendMessage(content, App.GetHostIp());
            //                    DataInit.UpdatPatientsNodes(nodeInpatient, 4);
            //                    if (Test.ViewSwitch == 0)
            //                    {
            //                        ucHospitalIofn1.HospitalIni(DataInit.PatientsNode.Nodes, nodetemp, inpat.Patient_Name, Test.ViewSwitch);
            //                    }
            //                    DataInit.isInAreaSucceed = false;
            //                }
            //            }
            //            else
            //            {
            //                this.Location = new Point(card_X, card_Y);
            //            }
            //            break;
            //        }
            //    }
            //}
        }

        private int GetBabyNumber(string pid)
        {
            int count = 0;
            try
            {
                string sql = "select count(-1) num from t_in_patient a" +
                    " inner join T_NEW_BORN_PATIENT b on a.pid=b.pid" +
                    " where a.pid='" + pid + "'";
                count = Convert.ToInt32(App.ReadSqlVal(sql, 0, "num"));
            }
            catch (Exception)
            {

            }
            return count;
        }
        private void Update_Bed(InPatientInfo Target_Inpat)
        {
            if (Target_Inpat.Id == 0)
            {
                DataTable dt = DataInit.GetBedInfo(inpat);
                string bedId = Target_Inpat.Sick_Bed_Id.ToString();
                string state = null;
                if (dt != null)
                {
                    state = GetBedState(bedId, dt);
                }
                string Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where pid='" + inpat.Id + "'", 0, "nowid");

                //生成异动表新记录的ID
                string New_Id = App.GenId("t_inhospital_action", "id").ToString();
                /*
                 * 新增加一条换床记录,修改最近的一条异动记录，与新增记录建立连接
                 */
                string InsertSQL = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                    " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid)" +
                                    " values(" + New_Id + "," + inpat.Section_Id + "," + inpat.Sike_Area_Id + ",'" + inpat.Id + "'," +
                                    "'换床','4',sysdate," +
                                    " " + Target_Inpat.Sick_Bed_Id + ",'" + inpat.Sick_Doctor_Id + "'," + App.UserAccount.Account_id + ",0," +
                                    " " + Now_Id + ",0,0)";
                string UdateOld = "update t_inhospital_action set next_id=" + New_Id + " where id=" + Now_Id + "";
                if (state.Equals("75"))                       //75表示空床位
                {
                    /*
                     * 修改目标床位的状态为忙碌 74
                     */
                    string UpdateBed_State = "update t_sickbedinfo set state=74 where bed_id=" + Target_Inpat.Sick_Bed_Id + "";
                    /*
                     * 修改来源床位的状态为忙碌 75
                     */
                    string UpdateBed_StateBySelf = "update t_sickbedinfo set state=75 where bed_id=" + inpat.Sick_Bed_Id + "";
                    /*
                     * 修改当前病人的当前床位号和床位编号
                     */
                    string UpdateIn_patient = "update t_in_patient set sick_bed_id=" + Target_Inpat.Sick_Bed_Id + "," +
                                              " sick_bed_no='" + Target_Inpat.Sick_Bed_Name + "' where id =" + inpat.Id + "";
                    string[] arr = new string[5];
                    arr[0] = InsertSQL;
                    arr[1] = UdateOld;
                    arr[2] = UpdateBed_State;
                    arr[3] = UpdateBed_StateBySelf;
                    arr[4] = UpdateIn_patient;
                    int count = App.ExecuteBatch(arr);
                    if (count > 0)
                    {
                        int bed_id = inpat.Sick_Bed_Id;
                        string bed_no = inpat.Sick_Bed_Name;
                        inpat.Sick_Bed_Id = Convert.ToInt32(Target_Inpat.Sick_Bed_Id);
                        inpat.Sick_Bed_Name = Target_Inpat.Sick_Bed_Name;
                        Target_Inpat.Sick_Bed_Id = bed_id;
                        Target_Inpat.Sick_Bed_Name = bed_no;
                        DataInit.isInAreaSucceed = true;
                    }
                }
                else
                {
                    //DialogResult dialog = MessageBox.Show("此床上有病人是否继续？", "提示", MessageBoxButtons.YesNo);
                    //if (dialog == DialogResult.Yes)
                    //{
                    //    //根据目标床号，得到目标床位上的病人信息。
                    //    InPatientInfo inpatient = DataInit.GetInpatientInfoById(Convert.ToInt32(cbxNewBed.SelectedValue));

                    //    string Target_Now_Id = App.ReadSqlVal("select max(id) as nowid from t_inhospital_action where pid='" +inpatient.Id + "'", 0, "nowid");
                    //    int Target_Id = Convert.ToInt32(New_Id) + 1;
                    //    //生成异动表新记录的ID
                    //    string Target_New_Id = App.GenId("t_inhospital_action", "id").ToString();

                    //    /*
                    //     * 修改来源床位
                    //     */
                    //    string UpdateIn_patientFrom = "update t_in_patient set sick_bed_id=" + cbxNewBed.SelectedValue.ToString() + "," +
                    //                                  " sick_bed_no='" + cbxNewBed.Text + "' where id =" + inPatientInfo.Id + "";
                    //    /*
                    //     * 修改目标床位
                    //     */
                    //    string UpdateIn_patientTo = "update t_in_patient set sick_bed_id=" + inPatientInfo.Sick_Bed_Id + ",sick_bed_no ='" + inPatientInfo.Sick_Bed_Name + "'" +
                    //                               " where id =" +inpatient.Id + "";

                    //    /*
                    //     * 目标床位病人向异动表里面插一条异动信息
                    //     */
                    //    string InsertSQL_Target = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                    //                " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id, target_said,target_sid)" +
                    //                " values(" +Target_Id+ "," + inpatient.Section_Id + "," + inpatient.Sike_Area_Id + ",'" + inpatient.Id + "'," +
                    //                "'换床','4',to_timestamp('" + dtpRollBedTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd hh24:mi:ss')," +
                    //                " " + inPatientInfo.Sick_Bed_Id + ",'" + inpatient.Sick_Doctor_Id + "'," + App.UserAccount.Account_id+ ",0," +
                    //                " " + Target_Now_Id + ",0,0)";
                    //    string Target_UdateOld = "update t_inhospital_action set next_id=" + Target_New_Id + " where id=" + Target_Now_Id + "";
                    //    string[] arr = new string[6];
                    //    arr[0] = InsertSQL;
                    //    arr[1] = UdateOld;
                    //    arr[3] = UpdateIn_patientFrom;
                    //    arr[2] = UpdateIn_patientTo;
                    //    arr[4] = InsertSQL_Target;
                    //    arr[5] = Target_UdateOld;
                    //    App.ExecuteBatch(arr);
                    //    inPatientInfo.Sick_Bed_Id = Int32.Parse(cbxNewBed.SelectedValue.ToString());
                    //    inPatientInfo.Sick_Bed_Name = cbxNewBed.Text;
                    //    DataInit.isInAreaSucceed = true;
                    //    ////修改目标病人的当期床号
                    //    //DataInit.RefCardBySection(DataInit.PatientsNode.Nodes, id, inPatientInfo);
                    //}
                    App.Msg("目标床位已有人,现阶段不支持互换操作！");
                }
            }
            else
            {
                this.Location = new Point(card_X, card_Y);
                App.Msg("暂不支持病人互换床位！");
            }
        }
        /// <summary>
        /// 根据床号，得到该床位的状态.
        /// </summary>
        /// <returns></returns>
        public static string GetBedState(string bedId, DataTable dt)
        {
            string str = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["bed_id"].ToString().Equals(bedId))
                {
                    str = dt.Rows[i]["state"].ToString();
                    break;
                }
                str = null;
            }
            return str;
        }

        private static string stringFormat(string str)
        {
            string result = "";
            if (str != null)
            {
                if (str == "病危" || str == "3")
                {
                    result = "※";
                }
                else if (str == "2" || str == "病重" || str.Contains("急"))
                {
                    result = "△";
                }
            }
            return result;
        }

        void page_Click(object sender, EventArgs e)
        {
            if (tabControl_Patient.Tabs.Count > 0)
            {
                this.tabControl_Patient.AutoCloseTabs = false;
                TabItem item = (TabItem)sender;
                //Point mp = Cursor.Position;
                MouseEventArgs mp = (MouseEventArgs)e;
                Point pTab = item.CloseButtonBounds.Location;
                if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                    mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                {
                    if (App.Ask("是否关闭当前病人的文书？")) 
                    {
                        App.ReleaseLockedDoc(item.Name);
                        this.tabControl_Patient.Tabs.Remove(item);
                    }
                }
            }
        }
    }
}
