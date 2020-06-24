using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    /// <summary>
    /// 在院病案查询
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class UserfrmQueryLevy : UserControl
    {
        public UserfrmQueryLevy()
        {
            try
            {
                InitializeComponent();
                App.UsControlStyle(this);
                //try
                //{
                    LoadCard();
                //}
                //catch (Exception exe)
                //{
                //    App.MsgErr(exe.Message);
                //}
            }
            catch (Exception exe)
            {
                App.MsgErr(exe.Message);
            }
        }

        private void LoadCard()
        {
            try
            {
                this.panel1.Controls.Clear();
                //this.Controls.Clear();
                dt = App.GetDataSet(sql).Tables[0] as DataTable;
                Brush brush = new SolidBrush(Color.Green);//所绘制的文本颜色和纹理
                StringFormat stringFormat = new StringFormat();//用来文本布局 居中对其方式
                stringFormat.Alignment = StringAlignment.Center;//垂直面上的文本对其方式
                stringFormat.LineAlignment = StringAlignment.Center;//设置水平面上文本对其方式
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;//表示如何在這個 StringFormat 物件所繪製的文字超過配置矩形邊緣時修剪該文字 这里是....

                Image image = global::Base_Function.Resource.科室选择小卡图标_未选中;
                int howHeight = 10;//初始化PictureBox 高度的大小
                int howWeight = 15;//初始化PictureBox 宽度的大小


                //入院人数
                string sql_into_area = "select a.SICK_AREA_ID from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 and to_char(a.in_time,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";

                //在院人数
                string sql_at_area = "select distinct a.id,a.SICK_AREA_ID from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.ACTION_TYPE<>'出区' and b.Next_id=0 and b.ACTION_STATE<>3 ";

                //床位数
                string sql_bed = "select said from t_sickbedinfo";

                //I（x） 危（x） 重（x）
                string sql_nurse_level = "select t.sick_area_id,td.name from t_in_patient t inner join (select * from t_data_code where type in (53) and name in('一级护理')) td on t.nurse_level=td.id  where  DOCUMENT_STATE is null ";//inner join t_inhospital_action b on t.id=b.patient_id where b.ACTION_TYPE<>'出区' and b.Next_id=0 and b.ACTION_STATE<>3 ";
                string sql_sick_degree = "select t.sick_area_id,decode(t.sick_degree,'1','一般','2','病重','3','病危') name from t_in_patient t where  DOCUMENT_STATE is null ";//inner join t_inhospital_action b on t.id=b.patient_id where b.ACTION_TYPE<>'出区' and b.Next_id=0 and b.ACTION_STATE<>3 ";

                

                Class_Table[] temtables = new Class_Table[5];
                temtables[0] = new Class_Table();
                temtables[0].Sql = sql_into_area;
                temtables[0].Tablename = "in";

                temtables[1] = new Class_Table();
                temtables[1].Sql = sql_at_area;
                temtables[1].Tablename = "at";

                temtables[2] = new Class_Table();
                temtables[2].Sql = sql_bed;
                temtables[2].Tablename = "bed";

                temtables[3] = new Class_Table();
                temtables[3].Sql = sql_nurse_level;
                temtables[3].Tablename = "nurse";

                temtables[4] = new Class_Table();
                temtables[4].Sql = sql_sick_degree;
                temtables[4].Tablename = "sick";



                DataSet ds = App.GetDataSet(temtables);

                //dt里面有多少行就有多少个PictureBox 第一个PictureBox出来之后，会在宽度+164的基础上在出来第二个，出来6个以后就换行
                //高度会在每个 PictureBox 的高度之上加120
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        howWeight += 164;
                        if (howWeight > this.panel1.Width)
                        {
                            howHeight += 130;
                            howWeight = 25;
                        }
                    }
                    saID = dt.Rows[i]["said"].ToString();//得到每个病区ID
                    //当前在院人数
                    int at_Count = ds.Tables["at"].Select("sick_area_id=" + saID).Length;
                    //今日入院人数
                    int in_Count = ds.Tables["in"].Select("sick_area_id=" + saID).Length;
                    //今日出院人数
                    int out_Count = 0;
                    try
                    {
                        out_Count=ds.Tables["bed"].Select("said=" + saID).Length;
                    }
                    catch
                    { }

                    PictureBox pb = new PictureBox();
                    pb.MouseHover += new EventHandler(pb_MouseHover);//鼠标悬停事件
                    pb.MouseLeave += new EventHandler(pb_MouseLeave);//鼠标移开事件
                    pb.DoubleClick += new EventHandler(pb_DoubleClick);//鼠标双击事件
                    pb.Size = new Size(image.Width + 15, image.Height + 35);//定义PictureBox的大小，这里比图片大5个像素
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;//设置如何显示PictureBox里面的图像，这里居中
                    //pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.BackColor = Color.White;//定义PictureBox的背景颜色
                    pb.Tag = dt.Rows[i][0].ToString();//与病区ID关联
                    pb.Name = dt.Rows[i][2].ToString();//与病区名称关联
                    Image im = new Bitmap(image.Width +8, image.Height +30);//表示要加入PictureBox中的背景图片，并初始化大小
                    pb.Location = new Point(howWeight, howHeight);//设定PictureBox 对于容器左上角坐标值
                    Graphics g = Graphics.FromImage(im);//设置要在图片上面画东西
                    g.Clear(Color.White);//清除要绘画的图面，并用指定的背景色填充
                    g.DrawImage(image, -4, -2, image.Width+10, image.Height+35);//要绘制的图像，并确定他要绘制的左上角的坐标
                    g.DrawString(dt.Rows[i]["section_name"].ToString(), Control.DefaultFont, brush, new RectangleF(0, 10, im.Width, 22), stringFormat);//把病区名称显示在绘制面板上
                    g.DrawString(dt.Rows[i][2].ToString(), Control.DefaultFont, brush, new RectangleF(0, 23, im.Width, 22), stringFormat);//把病区名称显示在绘制面板上

                    //g.DrawString(rows_nowHave.Length.ToString(), Control.DefaultFont, brush, new RectangleF(5, 38, 100, 22), stringFormat);//把医院现有人多少显示在面板上
                    //g.DrawString("(" + rows_daySQl.Length.ToString() + ")", Control.DefaultFont, brush, new RectangleF(30, 38, 100, 22), stringFormat);//把医院今天的人多少显示在面板上
                    //g.DrawString(rows_leaveSQl.Length.ToString(), Control.DefaultFont, brush, new RectangleF(18, 58, 100, 22), stringFormat);//把医院出院的人多少显示在面板上
                    g.DrawString(at_Count.ToString(), Control.DefaultFont, brush, new RectangleF(5, 43, 100, 22), stringFormat);//把医院现有人多少显示在面板上
                    g.DrawString("(" + in_Count.ToString() + ")", Control.DefaultFont, brush, new RectangleF(30, 43, 100, 22), stringFormat);//把医院今天的人多少显示在面板上
                    g.DrawString(out_Count.ToString(), Control.DefaultFont, brush, new RectangleF(18, 63, 100, 22), stringFormat);//把医院出院的人多少显示在面板上

                    //I（x）危（x）重（x）
                    //一级护理
                    int yjhl = ds.Tables["nurse"].Select("sick_area_id=" + saID + " and name='一级护理'").Length;
                    //病危
                    int bw = ds.Tables["sick"].Select("sick_area_id=" + saID + " and name='病危'").Length;
                    //病重
                    int bz = ds.Tables["sick"].Select("sick_area_id=" + saID + " and name='病重'").Length;
                    Font font = new Font("宋体", 8);
                    g.DrawString("I(" + yjhl + ")危(" + bw + ")重(" + bz + ")", font, brush, new RectangleF(5, 83, 140, 22), stringFormat);

                    
                    
                    pb.Image = im;//确定要在PictureBox里面显示的背景图像
                    g.Dispose();//释放资源
                    this.panel1.Controls.Add(pb);//添加到panel1
                }
                brush.Dispose();//释放资源
                GC.Collect();//垃圾回收
            }
            catch (Exception ex)
            {
                
            }
        }
        static string sql = @"select a.said,a.sick_area_code,a.sick_area_name,c.section_name from t_sickareainfo a 
                              inner join t_section_area b on a.said=b.said
                              inner join t_sectioninfo c on c.sid = b.sid
                              group  by a.shid,a.said,a.sick_area_code,a.sick_area_name,c.section_name 
                              order by a.shid,a.sick_area_code";

        DataTable dt;
        static string saID = "";

        private void frmQueryLevy_Load(object sender, EventArgs e)
        {
            try
            {
                #region 添加用户控件
                //int howWeight = 10;
                //int howHeight = 10;
                //for (int i = 0; i < 10; i++)
                //{
                //    //System.Windows.Forms.Control
                //    if (i != 0)
                //    {
                //        howWeight += 200;
                //        if (i % 5 == 0)
                //        {
                //            howWeight = 10;
                //            howHeight += 200;
                //        }
                //    }

                //    QueryPatient q=new QueryPatient();
                //    q.BorderStyle = BorderStyle.FixedSingle;
                //    q.Location = new Point(howWeight, howHeight);
                //    this.panel1.Controls.Add(q);
                //}
                //Pen p = new Pen(Color.Red);
                #endregion


            }
            catch (Exception ex)
            {

            }
        }
        public void pb_MouseHover(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            p.BackColor = ColorTranslator.FromHtml("#b2ecfe");
            p.Cursor = Cursors.Hand;
            //p.Image = global::Base_Function.Resource.科室选择小卡图标_选中;
        }
        public void pb_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            p.BackColor = Color.White;
            //p.Image = global::Base_Function.Resource.科室选择小卡图标_未选中;
        }
        public void pb_DoubleClick(object sender, EventArgs e)
        {
            PictureBox temppic = (sender as PictureBox);
            string id = temppic.Tag.ToString();
            QueryAllLevy allLevy = new QueryAllLevy(id);
            App.UsControlStyle(allLevy);
            App.AddNewBusUcControl(allLevy,"病人信息表");
        }
    }
}
