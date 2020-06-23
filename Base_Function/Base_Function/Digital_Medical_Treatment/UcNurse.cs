using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace Digital_Medical_Treatment
{
    public partial class UcNurse : DevComponents.DotNetBar.Office2007Form
    {
        private Pen blackPen = new Pen(Color.Black, 1);//黑笔
        private Pen lightblackPen = new Pen(Color.Gray, 0.1f);//黑笔
        private Pen redPen = new Pen(Color.Red, 1);    //红笔
        private Pen bluePen = new Pen(Color.Blue, 1);//网格
        private Pen wightPen = new Pen(Color.White, 1);//边框白线
        private Brush brush = new SolidBrush(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.DarkCyan);
        private Brush blackBrush = new SolidBrush(Color.Black);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);

        private Brush FillBrush = new SolidBrush(Color.LightSkyBlue); //区域填充

        private Brush whiteBrush = new SolidBrush(Color.White);
        private Font BigFont = new Font("宋体", 15f, FontStyle.Bold);
        private Font BigFont2 = new Font("宋体", 20f, FontStyle.Bold);
        private Font tenFont = new Font("宋体", 18f);
        private Font fifteenFont = new Font("宋体", 15f);
        private Font nineFont = new Font("宋体", 9f);
        private Font eightFont = new Font("宋体", 8f);
        //private Font eightBlodFont = new Font("宋体", 8f, FontStyle.Bold);
        private Font sevenFont = new Font("宋体", 7f);
        //private Font sevenBlodFont = new Font("宋体", 7f, FontStyle.Bold);
        private Font sixFont = new Font("宋体", 6.5f);

        SizeF sf;

        Graphics graphics;

        string strTittle;

        int graWidth = 1920;
        int graHeight = 1080;

        int tittlehight = 0;
        int contentheight = 200;
        int tittlehight2 = 0;
        int contentheight2 = 0;
        int tittlehight3 = 0;
        int contentheight3 = 0;

        int zjx = 140;//中间线

        int tittleWidth = 360;

        ArrayList Vals1 = new ArrayList();
        ArrayList Vals2 = new ArrayList();
        ArrayList Vals3 = new ArrayList();

        public UcNurse()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 表格1
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable1(Graphics e)
        {
            #region 表格绘制
            /*
             *表头
             */
            e.DrawRectangle(wightPen, 0, 0, graWidth - 1, tittlehight);
            e.FillRectangle(FillBrush, 0, 0, graWidth - 1, tittlehight);

            Class_Val temp = new Class_Val();
            temp.Tittle = "表一标题";
            temp.Reg = new RectangleF(0, 2, graWidth - 1, tittlehight);
            Vals1.Add(temp);

            /*
             * 内容
             */
            e.DrawRectangle(wightPen, 0, tittlehight, graWidth - 1, contentheight / 2);
            e.DrawRectangle(wightPen, 0, tittlehight + contentheight / 2, graWidth - 1, contentheight / 2);
            int spandwidth = graWidth / 5;
            for (int i = 0; i < 5; i++)
            {
                e.DrawLine(wightPen, i * spandwidth, tittlehight, i * spandwidth, tittlehight + contentheight);

                Class_Val temp1 = new Class_Val();
                temp1.Tittle = "1_" + Convert.ToString(i + 1);
                temp1.Reg = new RectangleF(i * spandwidth - 5, tittlehight, spandwidth + 5, contentheight / 2);
                Vals1.Add(temp1);

                Class_Val temp2 = new Class_Val();
                temp2.Tittle = "2_" + Convert.ToString(i + 1);
                temp2.Reg = new RectangleF(i * spandwidth - 5, tittlehight + contentheight / 2, spandwidth + 5, contentheight / 2);
                Vals1.Add(temp2);
            }

            #endregion

            #region 内容展示

            #endregion


        }

        /// <summary>
        /// 绘制所有的值内容
        /// </summary>
        private void DrawAllContent(Graphics e)
        {


            #region 表格1
            //标题
            for (int i = 0; i < Vals1.Count; i++)
            {
                Class_Val tittle = (Class_Val)Vals1[i];
                RectangleF R1 = new RectangleF(tittle.Reg.X + 5, tittle.Reg.Y + 45, tittle.Reg.Width - 10, tittle.Reg.Height - 45);
                if (tittle.Tittle == "表一标题")
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    e.DrawString("9月1日    今日值班医师：李XX(白) 吴XX(黑)", BigFont2, blackBrush, tittle.Reg, stringFormat);
                }
                else if (tittle.Tittle == "1_1")
                {
                    //病人总数
                    e.DrawString("病人总数：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 40);
                    e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "1_2")
                {
                    //入院
                    e.DrawString("入院：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("6人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "1_3")
                {
                    //转入
                    e.DrawString("转入：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("0人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "1_4")
                {
                    //手术
                    e.DrawString("手术：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("2人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    //e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", tenFont, blackBrush, R1);
                    //e.DrawString("23", tenFont, redBrush, R1);
                }
                else if (tittle.Tittle == "1_5")
                {
                    //病危
                    e.DrawString("病危：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("0人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_1")
                {
                    //换床
                    e.DrawString("换床：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("12-13，14-15,18-19", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_2")
                {
                    //出院
                    e.DrawString("出院：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("4人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_3")
                {
                    //转出
                    e.DrawString("转出：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("1人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_4")
                {
                    //拟手术
                    e.DrawString("拟手术：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("3人", BigFont, whiteBrush, tittle.Reg.X + 75, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_5")
                {
                    //病重
                    e.DrawString("病重：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("9人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", tenFont, blackBrush, R1);
                }

            }




            #endregion

            #region 表格2
            for (int i = 0; i < Vals2.Count; i++)
            {
                Class_Val tittle = (Class_Val)Vals2[i];
                RectangleF R1 = new RectangleF(tittle.Reg.X + 5, tittle.Reg.Y + 5, tittle.Reg.Width, tittle.Reg.Height);
                if (tittle.Tittle == "3_0")
                {
                    //体温单
                    sf = graphics.MeasureString("6am体温", fifteenFont);
                    e.DrawString("6am体温", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y - 20);
                }
                else if (tittle.Tittle == "3_1")
                {
                    //体重
                    sf = graphics.MeasureString("体重", fifteenFont);
                    e.DrawString("体重", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_2")
                {
                    //大便
                    sf = graphics.MeasureString("大便", fifteenFont);
                    e.DrawString("大便", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_3")
                {
                    //Bp:Qd
                    sf = graphics.MeasureString("Bp:Qd", fifteenFont);
                    e.DrawString("Bp:Qd", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_4")
                {
                    //Bp:Bid
                    sf = graphics.MeasureString("Bp:Bid", fifteenFont);
                    e.DrawString("Bp:Bid", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_5")
                {
                    //Bp:Tid
                    sf = graphics.MeasureString("Bp:Tid", fifteenFont);
                    e.DrawString("Bp:Tid", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_6")
                {
                    //P/R/Bp:Q1h
                    sf = graphics.MeasureString("P/R/Bp:Q1h", fifteenFont);
                    e.DrawString("P/R/Bp:Q1h", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "3_7")
                {
                    //P/R/Bp:Q2h
                    sf = graphics.MeasureString("P/R/Bp:Q2h", fifteenFont);
                    e.DrawString("P/R/Bp:Q2h", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_-1")
                {
                    //体温单
                    R1 = new RectangleF(tittle.Reg.X + 5, tittle.Reg.Y + 5, tittle.Reg.Width, tittle.Reg.Height * 2);
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "4_1")
                {
                    //体重
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_2")
                {
                    //大便
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_3")
                {
                    //Bp:Qd
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_4")
                {
                    //Bp:Bid
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_5")
                {
                    //Bp:Tid
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_6")
                {
                    //P/R/Bp:Q1h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
                else if (tittle.Tittle == "4_7")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                    //e.DrawString("55人", BigFont2, whiteBrush, tittle.Reg.X + 100, tittle.Reg.Y + 35);
                }
            }
            #endregion

            #region 表格3
            for (int i = 0; i < Vals3.Count; i++)
            {
                Class_Val tittle = (Class_Val)Vals3[i];
                RectangleF R1 = new RectangleF(tittle.Reg.X + 15, tittle.Reg.Y + 5, tittle.Reg.Width - 20, tittle.Reg.Height);
                if (tittle.Tittle == "5_1")
                {
                    //静脉留置
                    sf = graphics.MeasureString("静脉留置", fifteenFont);
                    e.DrawString("静脉留置", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_2")
                {
                    //吸氧
                    sf = graphics.MeasureString("吸氧", fifteenFont);
                    e.DrawString("吸氧", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_3")
                {
                    //记24H出入盘
                    sf = graphics.MeasureString("记24H出入盘", fifteenFont);
                    e.DrawString("记24H出入盘", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_4")
                {
                    //记24H尿量
                    sf = graphics.MeasureString("记24H尿量", fifteenFont);
                    e.DrawString("记24H尿量", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_5")
                {
                    //雾化
                    sf = graphics.MeasureString("雾化", fifteenFont);
                    e.DrawString("雾化", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_6")
                {
                    //跌倒高危
                    sf = graphics.MeasureString("跌倒高危", fifteenFont);
                    e.DrawString("跌倒高危", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_7")
                {
                    //压疮高危
                    sf = graphics.MeasureString("压疮高危", fifteenFont);
                    e.DrawString("压疮高危", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_8")
                {
                    //口腔护理
                    sf = graphics.MeasureString("口腔护理", fifteenFont);
                    e.DrawString("口腔护理", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_9")
                {
                    //会阴抹洗
                    sf = graphics.MeasureString("会阴抹洗", fifteenFont);
                    e.DrawString("会阴抹洗", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "5_10")
                {
                    //膀胱冲洗
                    sf = graphics.MeasureString("膀胱冲洗", fifteenFont);
                    e.DrawString("膀胱冲洗", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);

                }
                else if (tittle.Tittle == "5_11")
                {
                    //换药
                    sf = graphics.MeasureString("换药", fifteenFont);
                    e.DrawString("换药", fifteenFont, yellowBrush, tittle.Reg.X - sf.Width / 2, tittle.Reg.Y);
                }
                else if (tittle.Tittle == "6_1")
                {
                    //体温单
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_2")
                {
                    //大便
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_3")
                {
                    //Bp:Qd
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_4")
                {
                    //Bp:Bid
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_5")
                {
                    //Bp:Tid
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_6")
                {
                    //P/R/Bp:Q1h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_7")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_8")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_9")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_10")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "6_11")
                {
                    //P/R/Bp:Q2h
                    e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);
                }
            }
            #endregion

            #region 备注
            #endregion
        }


        /// <summary>
        /// 表格--生命体征
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable2(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight - contentheight - (tittlehight * 2);

            int start_x = 0;
            int start_y = contentheight + tittlehight;

            int SPAN_X = 10;
            int SPAN_Y = contentheight2 / 11;



            RectangleF R1;

            #region 表格绘制
            /*
             *表头
             */

            e.FillRectangle(FillBrush, start_x, start_y, graWidth / 5 * 2, tittlehight2);
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 2, tittlehight2);


            strTittle = "生命体征监测";
            sf = graphics.MeasureString(strTittle, fifteenFont);
            e.DrawString(strTittle, fifteenFont, blackBrush, graWidth / 5 - sf.Width / 2, start_y + sf.Height / 2);
            /*
             * 内容区域
             */
            e.DrawRectangle(wightPen, 0, start_y, graWidth / 5 * 2, contentheight2 + tittlehight);
            for (int i = 0; i < 10; i++)
            {
                e.DrawLine(wightPen, start_x, start_y + tittlehight2 + SPAN_Y * i, start_x + graWidth / 5 * 2, start_y + tittlehight2 + SPAN_Y * i);
                //e.FillRectangle(FillBrush, start_x, start_y + tittlehight2 + SPAN_Y * i, start_x + graWidth / 5 * 2, start_y + tittlehight2 + SPAN_Y * i);

                Class_Val temp1 = new Class_Val();
                temp1.Tittle = "3_" + Convert.ToString(i - 1);
                temp1.Reg = new RectangleF(30 + (zjx - 30) / 2, start_y + tittlehight2 + SPAN_Y * i + SPAN_Y / 3, start_x + graWidth / 5 * 2, start_y + tittlehight2 + SPAN_Y * i);
                Vals2.Add(temp1);

                Class_Val temp2 = new Class_Val();
                temp2.Tittle = "4_" + Convert.ToString(i - 1);
                temp2.Reg = new RectangleF(start_x + zjx, start_y + tittlehight2 + SPAN_Y * i, graWidth / 5 * 2 - zjx, SPAN_Y / 5 * 4);
                Vals2.Add(temp2);
            }


            //中间线
            e.DrawLine(wightPen, start_x + zjx, start_y + tittlehight2, start_x + zjx, graHeight - 1);

            //合并相关的行
            //体温单
            e.FillRectangle(blueBrush, start_x, start_y + tittlehight2, 30, SPAN_Y * 4);
            e.DrawRectangle(wightPen, start_x, start_y + tittlehight2, 30, SPAN_Y * 4);

            R1 = new RectangleF(start_x, start_y + tittlehight2 + SPAN_Y + SPAN_Y / 2, 30, SPAN_Y * 4);
            e.DrawString("体温单", BigFont, yellowBrush, R1);

            //6am体温
            e.FillRectangle(blueBrush, start_x + 30, start_y + tittlehight2, zjx - 30, SPAN_Y * 2);
            e.DrawRectangle(wightPen, start_x + 30, start_y + tittlehight2, zjx - 30, SPAN_Y * 2);

            //体温
            e.FillRectangle(blueBrush, start_x + zjx, start_y + tittlehight2, graWidth / 5 * 2 - zjx, SPAN_Y * 2);
            e.DrawRectangle(wightPen, start_x + zjx, start_y + tittlehight2, graWidth / 5 * 2 - zjx, SPAN_Y * 2);

            //医嘱
            e.FillRectangle(blueBrush, start_x, start_y + tittlehight2 + SPAN_Y * 4, 30, SPAN_Y * 5);
            e.DrawRectangle(wightPen, start_x, start_y + tittlehight2 + SPAN_Y * 4, 30, SPAN_Y * 5);

            R1 = new RectangleF(start_x, start_y + tittlehight2 + SPAN_Y * 6, 30, SPAN_Y * 4);
            e.DrawString("医嘱", BigFont, yellowBrush, R1);

            //心电护理
            //e.FillRectangle(blueBrush, start_x, start_y + tittlehight2 + SPAN_Y * 9, 140, SPAN_Y * 2);
            //e.DrawRectangle(wightPen, start_x, start_y + tittlehight2 + SPAN_Y * 9, 140, SPAN_Y * 2);

            //e.FillRectangle(blueBrush, start_x + 140, start_y + tittlehight2 + SPAN_Y * 9, graWidth / 5 * 2 - 140, SPAN_Y * 2);
            //e.DrawRectangle(wightPen, start_x + 140, start_y + tittlehight2 + SPAN_Y * 9, graWidth / 5 * 2 - 140, SPAN_Y * 2);

            sf = graphics.MeasureString("心电护理", fifteenFont);
            e.DrawString("心电护理", fifteenFont, yellowBrush, zjx / 2 - sf.Width / 2, start_y + tittlehight2 + SPAN_Y * 10);
            R1 = new RectangleF(start_x + zjx, start_y + tittlehight2 + SPAN_Y * 9, graWidth / 5 * 2 - zjx, SPAN_Y * 2);
            e.DrawString("01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、01、02、03、04、05、06、07、08、09、10、11、12、13、14、15、16、17、18、19、20、21、22、23、24、25、26、27、28、", tenFont, blackBrush, R1);

            //合并相关的列





            #endregion

            #region 内容展示

            #endregion
        }



        /// <summary>
        /// 表格3
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable3(Graphics e)
        {
            tittlehight3 = tittlehight;
            contentheight3 = graHeight - contentheight - (tittlehight * 2);

            int start_x = graWidth / 5 * 2;
            int start_y = contentheight + tittlehight;

            int SPAN_X = 10;
            int SPAN_Y = contentheight3 / 11;


            #region 表格绘制
            /*
             *表头start_x + (start_x - graWidth / 3) / 2
             */

            e.FillRectangle(FillBrush, start_x, start_y, graWidth / 3, tittlehight3);
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 3, tittlehight3);

            /*
             * 内容
             */
            //e.DrawRectangle(wightPen, start_x, start_y, graWidth / 3, contentheight3 - 1);
            for (int i = 0; i < 11; i++)
            {
                e.DrawLine(wightPen, start_x, start_y + tittlehight3 + SPAN_Y * i, start_x + graWidth / 3, start_y + tittlehight3 + SPAN_Y * i);

                Class_Val temp1 = new Class_Val();
                temp1.Tittle = "5_" + Convert.ToString(i + 1);
                temp1.Reg = new RectangleF(start_x + zjx / 2, start_y + tittlehight2 + SPAN_Y * i + SPAN_Y / 3, start_x + graWidth / 5 * 2, start_y + tittlehight2 + SPAN_Y * i);
                Vals3.Add(temp1);

                Class_Val temp2 = new Class_Val();
                temp2.Tittle = "6_" + Convert.ToString(i + 1);
                temp2.Reg = new RectangleF(start_x + 150, start_y + tittlehight2 + SPAN_Y * i, start_x + graWidth / 3 - graWidth / 5 * 2 - zjx, SPAN_Y / 5 * 4);
                Vals3.Add(temp2);
            }

            e.DrawLine(wightPen, start_x + zjx, start_y + tittlehight3, start_x + zjx, graHeight);
            #endregion

            #region 内容展示
            strTittle = "专科护理";
            sf = graphics.MeasureString(strTittle, fifteenFont);
            e.DrawString(strTittle, fifteenFont, blackBrush, start_x + graWidth / 3 / 2 - sf.Width / 2, start_y + sf.Height / 2);

            //换药
            //e.DrawString("换药", fifteenFont, yellowBrush, start_x, start_y + tittlehight2 + SPAN_Y * 10);
            #endregion
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="e"></param>
        private void DrawMark(Graphics e)
        {
            contentheight3 = graHeight - contentheight - tittlehight;
            int start_x = graWidth / 5 * 2 + graWidth / 3;
            int start_y = contentheight + tittlehight;

            #region 区域设置
            e.DrawRectangle(wightPen, start_x, start_y, graWidth - (graWidth / 5 * 2 + graWidth / 3) - 1, contentheight3 - 1);

            #endregion

            #region 内容区域
            strTittle = "备注:";
            e.DrawString(strTittle, BigFont2, blackBrush, start_x + 10, start_y + 10);
            sf = graphics.MeasureString(strTittle, fifteenFont);
            RectangleF R1 = new RectangleF(start_x + 10, start_y + 20 + sf.Height, graWidth - start_x, contentheight3 - 1);
            e.DrawString("备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注", fifteenFont, blackBrush, R1);
            #endregion
        }

        /// <summary>
        /// 值的初始化
        /// </summary>
        private void IniVals()
        {
            #region 表格1



            #endregion
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int width = this.Width;
            int heiht = this.Height;

            graphics = this.CreateGraphics();

            Rectangle srcRect = new Rectangle(0, 0, 1920, 1080);
            Rectangle destRect = new Rectangle(0, 0, width, heiht);

            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);

            tittlehight = graHeight / 20;
            DrawTable1(e.Graphics);
            DrawTable2(e.Graphics);
            DrawTable3(e.Graphics);
            DrawMark(e.Graphics);
            DrawAllContent(e.Graphics);
            e.Graphics.DrawRectangle(wightPen, 0, 0, graWidth, graHeight - 1);
            e.Graphics.EndContainer(containerState);
        }

        private void UcNurse_Load(object sender, EventArgs e)
        {

        }

        private void UcNurse_AutoSizeChanged(object sender, EventArgs e)
        {           
        }

        private void UcNurse_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
