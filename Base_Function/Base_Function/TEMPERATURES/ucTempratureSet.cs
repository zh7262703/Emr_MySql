using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPERATURES
{
    /// <summary>
    /// 体温单属性的设置
    /// </summary>
    public partial class ucTempratureSet : UserControl
    {

        printTemper ph = new printTemper();
        private string in_date = string.Empty;
        private string pid = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        private string id = string.Empty;
        public string CurrentNodeStr;

        private Point start = new Point();//矩形起点
        private Point end = new Point();//矩形终点
        private bool blnDraw = false;//是否开始画矩形
        Graphics g;
        Graphics g_p;

        public ucTempratureSet()
        {
            InitializeComponent();
            //ph.Hospital = "XXXXXX医院";
            //ph.TextName = "体 温 记 录 单";
            //ph.User.Add("姓名：", "张三");
            //ph.User.Add("床号：", "1床");
            //ph.User.Add("性别：", "男");
            //ph.User.Add("科室：", "消化内科");
            //ph.User.Add("病区：", "消化内科病区");
            //ph.User.Add("入院日期:", "2010-11-05 11:11");
            //ph.User.Add("住院号:", "98905");

            //this.startTime = "2011-12-22";
            //this.endTime = "2011-12-28";
            //this.in_date = "2011-12-22 00:00";
            //this.pid = "98905";
            //ph.Init("98905", "2010-11-05 11:11");                               
            
            ph.Hospital = App.HospitalTittle;
            ph.Bingqu = "消化内科病区";
            ph.TextName = "体 温 记 录 单";
            ph.User.Add("姓名:", "XXX");
            ph.User.Add("性别:", "男");
            ph.User.Add("科别:", "消化内科");
            ph.User.Add("年龄:","61岁");
            ph.User.Add("床号:", "01");
            ph.User.Add("入院日期:", "2011-12-22 00:00");
            ph.User.Add("住院号:", "98905");
            this.startTime = "2011-12-22";
            this.endTime = "2011-12-28";
            this.in_date = "2011-12-22 00:00";
            this.pid = "98905";
            ph.Init("98905", "2010-11-05 11:11");    
        }

        /// <summary>
        /// 体温单已经设置属性
        /// </summary>
        private void RefreshDataGrid()
        {
            DataSet ds = App.GetDataSet("select t.area_name as 区域名称,t.start_x as 起点坐标X,t.start_y as 起点坐标Y,t.height as 区域高度,t.width as 区域宽度,t.operater_form as 操作方式 from t_tempreture_op_set t");
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
        }
                     
          

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(38, 78);
            ph.printMain(e.Graphics, this.startTime, this.endTime);  
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          
            g = this.pictureBox1.CreateGraphics();
            start.X = e.X;
            start.Y = e.Y;
            end.X = e.X;
            end.Y = e.Y;
            blnDraw = true;            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                pictureBox1.Refresh();
                g_p = pictureBox1.CreateGraphics();
                g_p.TranslateTransform(38, 78);
                ph.printMain(g_p, this.startTime, this.endTime);
                g.DrawRectangle(new Pen(Color.GreenYellow, 3), start.X, start.Y, e.X - start.X, e.Y - start.Y);

                blnDraw = false;

                if (start.X != e.X)
                {
                    frmSetValueProperty fc = new frmSetValueProperty(start.X, start.Y, e.X - start.X, e.Y - start.Y);
                    fc.ShowDialog();
                    RefreshDataGrid();
                    g_p = pictureBox1.CreateGraphics();
                    g_p.TranslateTransform(38, 78);
                    ph.printMain(g_p, this.startTime, this.endTime);

                }
            }
            catch
            { }
        }            

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                pictureBox1.Refresh();
                g_p = pictureBox1.CreateGraphics();
                g_p.TranslateTransform(38, 78);
                ph.printMain(g_p, this.startTime, this.endTime);
                g.DrawRectangle(new Pen(Color.GreenYellow, 3), start.X, start.Y, e.X - start.X, e.Y - start.Y);
            }
        }

        private void ucTempratureSet_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                pictureBox1.Width = ph.pWidth;
                pictureBox1.Height = ph.pHeight;                        
                pictureBox1.Refresh();
                RefreshDataGrid();
             
            }
            catch
            { }
        }

        private void dataGridViewX1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            g_p = pictureBox1.CreateGraphics();
            g_p.TranslateTransform(38, 78);
            ph.printMain(g_p, this.startTime, this.endTime);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //pictureBox1.Refresh();
            //g_p = pictureBox1.CreateGraphics();
            //g_p.TranslateTransform(38, 78);
            //ph.printMain(g_p, this.startTime, this.endTime);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void 删除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("确定要删除“" + dataGridViewX1["区域名称", dataGridViewX1.CurrentRow.Index].Value.ToString() + "”吗？"))
                {
                    if (App.ExecuteSQL("delete from t_tempreture_op_set where area_name='" + dataGridViewX1["区域名称", dataGridViewX1.CurrentRow.Index].Value.ToString() + "'") > 0)
                    {
                        App.Msg("操作已经成功！");
                    }
                    else
                    {
                        App.MsgErr("操作不成功！");
                    }
                }

            }
            catch
            {
                App.MsgErr("操作不成功！");
            }
        }         

    }
}
