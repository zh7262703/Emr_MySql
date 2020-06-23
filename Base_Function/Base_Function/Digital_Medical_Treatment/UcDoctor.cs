using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Digital_Medical_Treatment
{
    public partial class UcDoctor : DevComponents.DotNetBar.Office2007Form
    {
        private Pen blackPen = new Pen(Color.Black, 1);//黑笔
        private Pen lightblackPen = new Pen(Color.Gray, 0.1f);//黑笔
        private Pen redPen = new Pen(Color.Red, 1);    //红笔
        private Pen bluePen = new Pen(Color.Blue, 1);//网格
        private Pen wightPen = new Pen(Color.White, 1);//边框白线
        private Brush brush = new SolidBrush(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush blackBrush = new SolidBrush(Color.Black);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);
        private Brush greenBrush = new SolidBrush(Color.GreenYellow);
        private Brush orangeBrush = new SolidBrush(Color.Orange);

        private Brush FillBrush = new SolidBrush(Color.LightSkyBlue); //区域填充

        private Brush whiteBrush = new SolidBrush(Color.White);
        private Font BigFont = new Font("宋体", 15f, FontStyle.Bold);
        private Font BigFont2 = new Font("宋体", 20f, FontStyle.Bold);
        private Font eighteenFont = new Font("宋体", 18f);
        private Font fifteenFont = new Font("宋体", 15f);
        private Font nineFont = new Font("宋体", 9f);
        private Font eightFont = new Font("宋体", 8f);
        private Font sevenFont = new Font("宋体", 7f);
        private Font sixFont = new Font("宋体", 6.5f);

        private Font BigeighteenFont = new Font("宋体", 18f, FontStyle.Bold);
        private Font BigsixteenFont = new Font("宋体", 16f);
        SizeF sf;
        SizeF Redsf;

        Graphics graphics;

        string strTittle;
        string strRedTittle;


        int graWidth = 1920;
        int graHeight = 1080;

        int tittlehight = 0;
        int contentheight = 200;
        int tittlehight2 = 0;
        int contentheight2 = 0;
        int tittlehight3 = 0;
        int contentheight3 = 0;

        ArrayList Vals1 = new ArrayList();

        public UcDoctor()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.BeginContainer
            int width = this.Width;
            int heiht = this.Height;
            graphics = pictureBox1.CreateGraphics();
            // Define transformation for container.
            Rectangle srcRect = new Rectangle(0, 0, 1920, 1080);
            Rectangle destRect = new Rectangle(0, 0, width, heiht);

            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);

            tittlehight = graHeight / 20;
            DrawTable1(e.Graphics);
            DrawTable2(e.Graphics);
            DrawTable3(e.Graphics);
            DrawTable4(e.Graphics);
            DrawFRHZ(e.Graphics);
            DrawMark(e.Graphics);
            DrawZK(e.Graphics);
            DrawAllContent(e.Graphics);
            e.Graphics.DrawRectangle(wightPen, 0, 0, graWidth - 1, graHeight - 1);
            //e.Graphics.ScaleTransform(100, 100);
            // End graphics container.
            e.Graphics.EndContainer(containerState);

        }


        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="e"></param>
        private void DrawMark(Graphics e)
        {
            contentheight3 = graHeight - contentheight - tittlehight;
            int start_x = graWidth / 5 * 4;
            int start_y = contentheight + tittlehight;




            #region 备注内容
            strTittle = "备注:";
            e.DrawString(strTittle, BigFont2, blackBrush, start_x + 10, start_y + 10);
            sf = graphics.MeasureString(strTittle, fifteenFont);
            RectangleF R1 = new RectangleF(start_x + 10, start_y + 20 + sf.Height, graWidth - start_x, contentheight3 - 1);
            e.DrawString("备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注", fifteenFont, blackBrush, R1);
            #endregion
        }

        /// <summary>
        /// 质控
        /// </summary>
        /// <param name="e"></param>
        private void DrawZK(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight / 10 * 7;

            int start_x = graWidth / 5 * 4;
            int start_y = contentheight2;

            int SPAN_X = 10;
            int SPAN_Y = start_y;

            #region 表格绘制

            //质控
            e.DrawLine(wightPen, start_x, start_y, graWidth, start_y);
            #endregion

            #region 内容展示
            //发热患者
            strTittle = "质控:";
            sf = graphics.MeasureString(strTittle, BigFont2);
            e.DrawString(strTittle, BigFont2, blackBrush, start_x + SPAN_X, start_y + SPAN_X);

            SPAN_Y += Convert.ToInt32(sf.Height) + 5;

            strTittle = "李XX    超时0    预警8    夏XX    超时12   预警10";
            sf = graphics.MeasureString(strTittle, BigsixteenFont);
            RectangleF R1 = new RectangleF(start_x + SPAN_X * 6, SPAN_Y, start_x / 4 - SPAN_X * 7, SPAN_Y);
            e.DrawString(strTittle, BigsixteenFont, blackBrush, R1);
            SPAN_Y += Convert.ToInt32(sf.Height) + 5;


            #endregion
        }


        /// <summary>
        /// 发热患者
        /// </summary>
        /// <param name="e"></param>
        private void DrawFRHZ(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight / 10 * 8;

            int start_x = graWidth / 5 * 4 / 3 * 2;
            int start_y = contentheight2;

            int SPAN_X = 10;
            int SPAN_Y = start_y;

            int font_x = 0;
            #region 表格绘制

            //6am发热患者
            e.DrawLine(wightPen, start_x, start_y, graWidth / 5 * 4, start_y);
            #endregion

            #region 内容展示
            //发热患者
            strTittle = "6am发热患者";
            sf = graphics.MeasureString(strTittle, BigFont2);
            e.DrawString(strTittle, BigFont2, blackBrush, start_x + SPAN_X, start_y + SPAN_X);

            SPAN_Y += Convert.ToInt32(sf.Height) + 5;

            strTittle = "01床36.9   02床37.5   09床38.0   10床39.5   18床37.9   22床37.8   25床38.8   02床37.5   09床38.0   10床39.5   18床37.9   22床37.8   25床38.8";
            sf = graphics.MeasureString(strTittle, BigsixteenFont);
            RectangleF R1 = new RectangleF(start_x + SPAN_X * 2, SPAN_Y, start_x / 2 - SPAN_X * 2, SPAN_Y);
            e.DrawString(strTittle, BigsixteenFont, blackBrush, R1);
            SPAN_Y += Convert.ToInt32(sf.Height) + 5;


            #endregion
        }

        /// <summary>
        /// 心电监护
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable4(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight - contentheight - (tittlehight * 2);

            int start_x = graWidth / 5 * 4 / 3 * 2;
            int start_y = contentheight + tittlehight;

            int SPAN_X = 10;
            int SPAN_Y = contentheight + tittlehight * 2;

            int font_x = 0;
            #region 表格绘制
            /*
             *表头
             */

            e.FillRectangle(FillBrush, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);


            strTittle = "心电监护";
            sf = graphics.MeasureString(strTittle, fifteenFont);
            e.DrawString(strTittle, fifteenFont, blackBrush, start_x + graWidth / 5 * 4 / 3 / 2 - sf.Width / 2, start_y + sf.Height / 2);
            /*
             * 内容区域
             */
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 4 / 3, contentheight2 + tittlehight);


            #endregion

            #region 内容展示
            //心电监护
            for (int i = 0; i < 5; i++)
            {
                //01床 BP180/110mmHg P80次/分 HR222次/分
                strTittle = "01床 BP";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                font_x = Convert.ToInt32(sf.Width);
                RectangleF R1 = new RectangleF(start_x + SPAN_X, SPAN_Y + SPAN_X, sf.Width, SPAN_Y);
                e.DrawString(strTittle, BigsixteenFont, blackBrush, R1);



                strRedTittle = "80/110";
                Redsf = graphics.MeasureString(strRedTittle, BigsixteenFont);
                R1 = new RectangleF(start_x + SPAN_X + font_x - 5, SPAN_Y + SPAN_X, Redsf.Width, SPAN_Y);
                e.DrawString(strRedTittle, BigsixteenFont, redBrush, R1);
                font_x += Convert.ToInt32(Redsf.Width);


                strTittle = "mmHg P80次/分 HR222次/分";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                R1 = new RectangleF(start_x + SPAN_X + font_x - 5, SPAN_Y + SPAN_X, sf.Width, SPAN_Y);
                e.DrawString(strTittle, BigsixteenFont, blackBrush, R1);

                SPAN_Y += Convert.ToInt32(sf.Height) + 5;
            }

            #endregion
        }



        /// <summary>
        /// 危急值
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable3(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight - contentheight - (tittlehight * 2);

            int start_x = graWidth / 5 * 4 / 3;
            int start_y = contentheight + tittlehight;

            int SPAN_X = 10;
            int SPAN_Y = start_y + tittlehight2;

            #region 表格绘制
            /*
             *表头
             */

            e.FillRectangle(FillBrush, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);


            strTittle = "危急值";
            sf = graphics.MeasureString(strTittle, fifteenFont);
            e.DrawString(strTittle, fifteenFont, blackBrush, start_x + graWidth / 5 * 4 / 3 / 2 - sf.Width / 2, start_y + sf.Height / 2);
            /*
             * 内容区域
             */
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 4 / 3, contentheight2 + tittlehight);



            #endregion

            #region 内容展示
            for (int i = 0; i < 5; i++)
            {
                strTittle = "01床 K:10mmol/L↑";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                RectangleF R1 = new RectangleF(start_x + SPAN_X, SPAN_Y + SPAN_X, graWidth / 5 * 4 / 3 - SPAN_X, SPAN_Y);
                e.DrawString(strTittle, BigsixteenFont, blackBrush, R1);
                SPAN_Y += Convert.ToInt32(sf.Height) + 5;
            }
            #endregion
        }

        /// <summary>
        /// 表格2
        /// </summary>
        /// <param name="e"></param>
        private void DrawTable2(Graphics e)
        {
            tittlehight2 = tittlehight;
            contentheight2 = graHeight - contentheight - (tittlehight * 2);

            int start_x = 0;
            int start_y = contentheight + tittlehight;

            int SPAN_X = 80;
            int SPAN_Y = start_y + tittlehight2 + 10;



            #region 表格绘制
            /*
             *表头
             */

            e.FillRectangle(FillBrush, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);
            e.DrawRectangle(wightPen, start_x, start_y, graWidth / 5 * 4 / 3, tittlehight2);


            strTittle = "";
            sf = graphics.MeasureString(strTittle, fifteenFont);
            e.DrawString(strTittle, fifteenFont, blackBrush, graWidth / 5 * 4 / 3 / 2 - sf.Width / 2, start_y + sf.Height / 2);

            #endregion

            #region 内容展示
            strTittle = "入院 ";
            e.DrawString(strTittle, BigeighteenFont, whiteBrush, start_x, SPAN_Y);
            for (int i = 0; i < 5; i++)
            {
                strTittle = "15床 乳腺瘤";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                RectangleF R1 = new RectangleF(start_x + SPAN_X, SPAN_Y, graWidth / 5 * 4 / 3, SPAN_Y);
                e.DrawString("15床 乳腺瘤", BigsixteenFont, whiteBrush, R1);
                SPAN_Y += Convert.ToInt32(sf.Height) + 5;
            }
            strTittle = "转入 ";
            e.DrawString(strTittle, BigeighteenFont, greenBrush, start_x, SPAN_Y);
            for (int i = 0; i < 3; i++)
            {
                strTittle = "08床 阑尾炎";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                RectangleF R1 = new RectangleF(start_x + SPAN_X, SPAN_Y, graWidth / 5 * 4 / 3, SPAN_Y);
                e.DrawString("08床 阑尾炎", BigsixteenFont, greenBrush, R1);
                SPAN_Y += Convert.ToInt32(sf.Height) + 5;
            }
            strTittle = "手术 ";
            e.DrawString(strTittle, BigeighteenFont, orangeBrush, start_x, SPAN_Y);
            for (int i = 0; i < 3; i++)
            {
                strTittle = "20床 手术";
                sf = graphics.MeasureString(strTittle, BigsixteenFont);
                RectangleF R1 = new RectangleF(start_x + SPAN_X, SPAN_Y, graWidth / 5 * 4 / 3, SPAN_Y);
                e.DrawString("20床 手术", BigsixteenFont, orangeBrush, R1);
                SPAN_Y += Convert.ToInt32(sf.Height) + 5;
            }
            #endregion
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
                temp1.Reg = new RectangleF(i * spandwidth, tittlehight, spandwidth + 5, contentheight / 2);
                Vals1.Add(temp1);

                Class_Val temp2 = new Class_Val();
                temp2.Tittle = "2_" + Convert.ToString(i + 1);
                temp2.Reg = new RectangleF(i * spandwidth, tittlehight + contentheight / 2, spandwidth + 5, contentheight / 2);
                Vals1.Add(temp2);
            }

            #endregion

            #region 内容展示

            #endregion


        }

        /// <summary>
        /// 绘制表格内容
        /// </summary>
        /// <param name="e"></param>
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
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "1_3")
                {
                    //转入
                    e.DrawString("转入：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("0人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", eighteenFont, blackBrush, R1);
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
                    e.DrawString("", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_1")
                {
                    //换床
                    e.DrawString("换床：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("12-13，14-15,18-19", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_2")
                {
                    //出院
                    e.DrawString("出院：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("4人", BigFont, whiteBrush, tittle.Reg.X + 55, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27,18,19,20,21,22,23,24,25,26,27", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_3")
                {
                    //转出
                    e.DrawString("转出：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("1人", BigFont, whiteBrush, tittle.Reg.X + 50, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_4")
                {
                    //拟手术
                    e.DrawString("拟手术：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("3人", BigFont, whiteBrush, tittle.Reg.X + 70, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", eighteenFont, blackBrush, R1);
                }
                else if (tittle.Tittle == "2_5")
                {
                    //病重
                    e.DrawString("病重：", BigFont, yellowBrush, tittle.Reg.X, tittle.Reg.Y + 20);
                    e.DrawString("9人", BigFont, whiteBrush, tittle.Reg.X + 50, tittle.Reg.Y + 20);
                    //RectangleF R1 = new RectangleF(tittle.Reg.X + 10, tittle.Reg.Y + 50, tittleWidth, tittle.Reg.Height - 50);
                    e.DrawString("", eighteenFont, blackBrush, R1);
                }

            }




            #endregion
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UcDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UcDoctor_AutoSizeChanged(object sender, EventArgs e)
        {            
        }

        private void UcDoctor_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
