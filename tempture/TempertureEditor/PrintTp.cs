using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using TempertureEditor.Element;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Drawing2D;
using System.IO;
using Bifrost;

namespace TempertureEditor
{
    /// <summary>
    /// 体温单绘制
    /// </summary>
    public class PrintTp
    {
        private Pen Currentpen = new Pen(Color.Black, 1);
        private Brush tbrush;
        private ClsFont tempFont;
        private Font tempf;
        private Color selectColor;
        private Color editColor;
        private float X1 = 0;
        private float Y1 = 0;
        private float X2 = 0;
        private float Y2 = 0;
        private StringFormat textFormat = new StringFormat(); //字体设置
        List<Point> ptds = new List<Point>(); //体温点
        List<Point> ptds2 = new List<Point>();//体温降温点

        List<Point> listplus = new List<Point>();  //脉搏
        List<Point> listheart = new List<Point>(); //心率
        public Comm cm;
        private Brush fillBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.FromArgb(0));
        public Color SelectColor
        {
            get
            {
                return selectColor;
            }

            set
            {
                selectColor = value;
            }
        }

        public Color EditColor
        {
            get
            {
                return editColor;
            }

            set
            {
                editColor = value;
            }
        }

        /// <summary>
        /// 设置对齐类型
        /// </summary>
        /// <param name="alignment"></param>
        /// <param name="linAlignment"></param>
        /// <param name="trimming"></param>
        internal void setFormat(StringAlignment alignment, StringAlignment linAlignment, StringTrimming trimming)
        {
            this.textFormat.Alignment = alignment;
            this.textFormat.LineAlignment = linAlignment;
            this.textFormat.Trimming = trimming;
        }

        internal void DrawTemper(Graphics g, TreeNode selectNode, bool isEdit)
        {
            if (isEdit)
            {
                foreach (TreeNode tn in cm.CurrentTree.Nodes)
                {
                    if (tn.Name == "element")
                    {
                        foreach (TreeNode temptd in tn.Nodes)
                        {

                            if (temptd.Tag.ToString() == "TempertureEditor.Element.ClsLine")
                            {
                                ClsLine templ = (ClsLine)temptd.Tag;
                                DrawLine(g, templ, selectNode);
                            }
                            else if (temptd.Tag.ToString() == "TempertureEditor.Element.ClsRec")
                            {
                                //边框区域
                                ClsRec temprec = (ClsRec)temptd.Tag;
                                DrawRec(g, temprec, selectNode);
                            }
                            else if (temptd.Tag.ToString() == "TempertureEditor.Element.ClsText")
                            {
                                ClsText temptext = (ClsText)temptd.Tag;
                                DrawText(g, temptext, selectNode);
                            }
                            else if (temptd.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                            {
                                ClsImg tempImg = (ClsImg)temptd.Tag;
                                DrawImg(g, tempImg, selectNode);
                            }
                        }
                    }
                }
            }
            else
            {

                //字体
                foreach (XmlNode tempxmlnode in cm.XmlDoc.GetElementsByTagName("ClsText"))
                {
                    ClsText tempelement = new ClsText();
                    tempelement.Id = tempxmlnode.Attributes["Id"].Value;
                    tempelement.Fontid = tempxmlnode.Attributes["Fontid"].Value;
                    tempelement.Direction = tempxmlnode.Attributes["Direction"].Value;
                    tempelement.X1 = Convert.ToSingle(tempxmlnode.Attributes["X"].Value);
                    tempelement.Y1 = Convert.ToSingle(tempxmlnode.Attributes["Y"].Value);
                    tempelement.Times = Convert.ToInt16(tempxmlnode.Attributes["Times"].Value);
                    tempelement.Spans = Convert.ToSingle(tempxmlnode.Attributes["Spans"].Value);
                    tempelement.Vtext = tempxmlnode.InnerText;
                    tempelement.Tdirection = tempxmlnode.Attributes["Tdirection"].Value;
                    DrawText(g, tempelement, selectNode);
                }

                //画笔
                foreach (XmlNode tempxmlnode in cm.XmlDoc.GetElementsByTagName("ClsLine"))
                {
                    ClsLine tempelement = new ClsLine();
                    tempelement.Id = tempxmlnode.Attributes["Id"].Value;
                    tempelement.Penid = tempxmlnode.Attributes["Penid"].Value;
                    tempelement.Direction = tempxmlnode.Attributes["Direction"].Value;
                    tempelement.X1 = Convert.ToSingle(tempxmlnode.Attributes["X1"].Value);
                    tempelement.Y1 = Convert.ToSingle(tempxmlnode.Attributes["Y1"].Value);
                    tempelement.X2 = Convert.ToSingle(tempxmlnode.Attributes["X2"].Value);
                    tempelement.Y2 = Convert.ToSingle(tempxmlnode.Attributes["Y2"].Value);
                    tempelement.Times = Convert.ToInt16(tempxmlnode.Attributes["Times"].Value);
                    tempelement.Spans = Convert.ToSingle(tempxmlnode.Attributes["Spans"].Value);

                    DrawLine(g, tempelement, selectNode);


                }

                foreach (XmlNode tempxmlnode in cm.XmlDoc.GetElementsByTagName("ClsRec"))
                {
                    //矩形区域
                    ClsRec tempelement = new ClsRec();
                    tempelement.Id = tempxmlnode.Attributes["Id"].Value;
                    tempelement.Penid = tempxmlnode.Attributes["Penid"].Value;
                    int X = Convert.ToInt16(tempxmlnode.Attributes["X"].Value);
                    int Y = Convert.ToInt16(tempxmlnode.Attributes["Y"].Value);
                    int Wd = Convert.ToInt16(tempxmlnode.Attributes["Width"].Value);
                    int Ht = Convert.ToInt16(tempxmlnode.Attributes["Height"].Value);
                    tempelement.Rec = new Rectangle(X, Y, Wd, Ht);
                    DrawRec(g, tempelement, selectNode);
                }

                foreach (XmlNode tempxmlnode in cm.XmlDoc.GetElementsByTagName("ClsImg"))
                {
                    //矩形区域
                    ClsImg tempelement = new ClsImg();
                    tempelement.Id = tempxmlnode.Attributes["Id"].Value;
                    tempelement.Imgname = tempxmlnode.Attributes["Imgname"].Value;
                    if (tempelement.Imgname != "")
                    {
                        // Update by xiao at 2017/4/5
                        string imgFileFullName = App.SysPath + "\\" + tempelement.Imgname;
                        if (File.Exists(imgFileFullName))
                        {
                            tempelement.Img = new Bitmap(imgFileFullName);//cm.getImgBybytes(tempxmlnode.InnerText);
                        }
                    }
                    tempelement.X = Convert.ToInt16(tempxmlnode.Attributes["X"].Value);
                    tempelement.Y = Convert.ToInt16(tempxmlnode.Attributes["Y"].Value);
                    tempelement.Pwidth = Convert.ToInt16(tempxmlnode.Attributes["Pwidth"].Value);
                    tempelement.Pheight = Convert.ToInt16(tempxmlnode.Attributes["Pheight"].Value);

                    DrawImg(g, tempelement, selectNode);
                }

                //体温单大小节点
                XmlNodeList mainnodes = cm.XmlDoc.GetElementsByTagName("ClsMainFrame");
                if (mainnodes.Count > 0)
                {
                    XmlNode mainnode = mainnodes[0];
                    ClsMainFrame mainfram = new ClsMainFrame();
                    mainfram.Twidth = Convert.ToInt16(mainnode.Attributes["Twidth"].Value);
                    mainfram.Theight = Convert.ToInt16(mainnode.Attributes["Theight"].Value);
                    //一张A4 白纸是2100*2970DMM
                    //0.1毫米＝1DMM丝米，1英寸＝25.4毫米
                    double xPinexCountPerDMM = g.DpiX / 254.0; //横向：每丝米像素点个数
                    double yPinexCountPerDMM = g.DpiY / 254.0; //纵向：每丝米像素点个数

                    cm.MaxWidth = Convert.ToInt16(mainfram.Twidth * xPinexCountPerDMM);
                    cm.MaxHeight = Convert.ToInt16(mainfram.Theight * yPinexCountPerDMM);

                }
            }
        }

        #region   体温单绘制
        internal void DrawImg(Graphics g, ClsImg tempI, TreeNode selectNode)
        {
            //if (selectNode != null)
            //    if (selectNode.Name == temprec.Id)
            //        g.DrawRectangle()

            if (tempI.Img != null)
            {
                Bitmap tempImg = cm.GetThumbnail((Bitmap)tempI.Img.Clone(), tempI.Pwidth, tempI.Pheight);
                g.DrawImage(tempImg, tempI.X, tempI.Y, tempI.Pwidth, tempI.Pheight);
            }
        }


        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="templ"></param>
        internal void DrawLine(Graphics g, ClsLine templ, TreeNode selectNode)
        {
            #region 画线的处理
            //ClsLine templ = (ClsLine)temptd.Tag;
            Currentpen = cm.GetCurrentPen(templ.Penid);

            //当前选中
            if (selectNode != null)
                if (selectNode.Name == templ.Id)
                    Currentpen.Color = EditColor;

            if (templ.Times <= 1)
                g.DrawLine(Currentpen, templ.X1, templ.Y1, templ.X2, templ.Y2);
            else
            {
                X1 = templ.X1;
                Y1 = templ.Y1;
                X2 = templ.X2;
                Y2 = templ.Y2;
                for (int i = 0; i < templ.Times; i++)
                {
                    g.DrawLine(Currentpen, X1, Y1, X2, Y2);
                    if (templ.Direction == "左")
                    {
                        X1 = X1 - templ.Spans;
                        X2 = X2 - templ.Spans;
                    }
                    else if (templ.Direction == "右")
                    {
                        X1 = X1 + templ.Spans;
                        X2 = X2 + templ.Spans;
                    }
                    else if (templ.Direction == "上")
                    {
                        Y1 = Y1 - templ.Spans;
                        Y2 = Y2 - templ.Spans;
                    }
                    else
                    {
                        Y1 = Y1 + templ.Spans;
                        Y2 = Y2 + templ.Spans;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="temprec"></param>
        internal void DrawRec(Graphics g, ClsRec temprec, TreeNode selectNode)
        {
            Pen tpn = cm.GetCurrentPen(temprec.Penid);
            if (selectNode != null)
                if (selectNode.Name == temprec.Id)
                    tpn.Color = EditColor;
            g.DrawRectangle(tpn, temprec.Rec);
        }

        /// <summary>
        /// 画文字
        /// </summary>
        /// <param name="g"></param>
        /// <param name="temprec"></param>
        internal void DrawText(Graphics g, ClsText temptext, TreeNode selectNode)
        {
            tempFont = cm.GetClsFontById(temptext.Fontid);  //获取自定义字体类
            if (tempFont != null)
            {
                tbrush = new SolidBrush(tempFont.Fontcolor);  //获取字体颜色
                tempf = cm.GetFontById(temptext.Fontid);     //获取字体

                if (selectNode != null)
                    if (selectNode.Name == temptext.Id)
                        tbrush = new SolidBrush(EditColor);
                if (temptext.Times <= 1)
                {
                    //无频次循环
                    if (temptext.Tdirection == "横")
                    {
                        //横
                        g.DrawString(temptext.Vtext, tempf, tbrush, temptext.X1, temptext.Y1);

                    }
                    else
                    {
                        float tempY = temptext.Y1;
                        int tfontheight = cm.GetTextHeight(g, temptext.Vtext, tempf);
                        //竖
                        for (int i = 0; i < temptext.Vtext.Length; i++)
                        {
                            g.DrawString(temptext.Vtext[i].ToString(), tempf, tbrush, temptext.X1, tempY);
                            tempY = tempY + tfontheight;
                        }
                    }
                }
                else
                {
                    X1 = temptext.X1;
                    Y1 = temptext.Y1;
                    //频次循环
                    for (int k = 0; k < temptext.Times; k++)
                    {
                        if (temptext.Tdirection == "横")
                        {
                            //横
                            g.DrawString(temptext.Vtext, tempf, tbrush, X1, Y1);
                        }
                        else
                        {
                            float tempY = Y1;
                            int tfontheight = cm.GetTextHeight(g, temptext.Vtext, tempf);
                            //竖
                            for (int i = 0; i < temptext.Vtext.Length; i++)
                            {
                                g.DrawString(temptext.Vtext[i].ToString(), tempf, tbrush, X1, tempY);
                                tempY = tempY + tfontheight;
                            }
                        }

                        if (temptext.Direction == "左")
                        {
                            X1 = X1 - temptext.Spans;
                        }
                        else if (temptext.Direction == "右")
                        {
                            X1 = X1 + temptext.Spans;
                        }
                        else if (temptext.Direction == "上")
                        {
                            Y1 = Y1 - temptext.Spans;
                        }
                        else if (temptext.Direction == "下")
                        {
                            Y1 = Y1 + temptext.Spans;
                        }
                    }
                }
            }
        }



        #endregion

        #region 体温单数据连线绘制
        /*
                /// <summary>
                /// 上下显示类型
                /// </summary>
                /// <param name="g"></param>
                /// <param name="page"></param>
                internal void DrawUpdownTextData(Graphics g, Page page)
                {
                    string texttype = "上";
                    int index = 0;
                    object typeobj;
                    for (int i = 0; i < page.Objs.Count; i++)
                    {
                        ClsDataObj tempobj = (ClsDataObj)page.Objs[i];
                        typeobj = cm.GetVDataSetByName(tempobj.Typename);
                        if (typeobj != null && typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                        {
                            ClsTextdata tempc = (ClsTextdata)typeobj;
                            tempFont = cm.GetClsFontById(tempc.Fontid);
                            tbrush = new SolidBrush(tempFont.Fontcolor);
                            tempf = cm.GetFontById(tempc.Fontid);     //获取字体
                            if (tempc.Texttype == "上下" || tempc.Texttype == "下上")
                            {
                                if (index == 0)
                                {
                                    if (tempc.Texttype == "上下")
                                    {
                                        texttype = "上";
                                    }
                                    else if (tempc.Texttype == "下上")
                                    {
                                        texttype = "下";
                                    }
                                }

                                //RectangleF refc = new RectangleF(tempobj.X, tempobj.Y, tempc.Twidth, tempc.Theight);
                                if (texttype == "上")
                                    g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y);
                                else if (texttype == "下")
                                    g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y + tempc.Theight - cm.GetTextHeight(g, tempobj.Val, tempf));


                                if (texttype == "上")
                                {
                                    texttype = "下";
                                }
                                else
                                {
                                    texttype = "上";
                                }
                                index++;
                            }
                        }
                    }
                }
                */

        /// <summary>
        /// 上下显示类型
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        internal void DrawUpdownTextData(Graphics g, Page page)
        {
            string texttype = "上";

            //因为24点时间被改为当天0点，所以要按横坐标大小重新排序
            List<ClsDataObj> listClsDataObj = new List<ClsDataObj>();

            for (int i = 0; i < page.Objs.Count; i++)
            {
                ClsDataObj tempobj = (ClsDataObj)page.Objs[i];
                object typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj != null && typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                {
                    ClsTextdata tempc = (ClsTextdata)typeobj;
                    if (tempc.Texttype == "上下" || tempc.Texttype == "下上")
                    {

                        int index = 0;
                        for (index = 0; index < listClsDataObj.Count; index++)
                        {
                            if (page.Objs[i].X < listClsDataObj[index].X)
                            {
                                break;
                            }
                        }
                        listClsDataObj.Insert(index, page.Objs[i]);
                    }
                }
            }

            bool bFirst = true;
            for (int j = 0; j < listClsDataObj.Count; j++)
            {
                ClsDataObj tempobj = (ClsDataObj)listClsDataObj[j];
                object typeobj = cm.GetVDataSetByName(tempobj.Typename);

                ClsTextdata tempc = (ClsTextdata)typeobj;
                tempFont = cm.GetClsFontById(tempc.Fontid);
                tbrush = new SolidBrush(tempFont.Fontcolor);
                tempf = cm.GetFontById(tempc.Fontid);     //获取字体

                if (bFirst)
                {
                    if (tempc.Texttype == "上下")
                    {
                        texttype = "上";
                    }
                    else if (tempc.Texttype == "下上")
                    {
                        texttype = "下";
                    }

                    bFirst = false;
                }
                //RectangleF refc = new RectangleF(tempobj.X, tempobj.Y, tempc.Twidth, tempc.Theight);
                if (texttype == "上")
                    g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y);
                else if (texttype == "下")
                    g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y + tempc.Theight - cm.GetTextHeight(g, tempobj.Val, tempf));


                if (texttype == "上")
                {
                    texttype = "下";
                }
                else
                {
                    texttype = "上";
                }
            }
        }



        List<ClsDataObj> objBrokens = new List<ClsDataObj>();
        internal void DrawData(Graphics g, Page page)
        {
            this.ptds.Clear();
            this.ptds2.Clear();
            object typeobj;
            ClsTextdata tempc;
            ClsLinedata templ;
            RectangleF refc;
            ClsTextdata temptt;
            Font tempChangeF;
            Brush tempChangeBrush;
            ClsFont tempChangeFCls;
            for (int indeTempobj = 0; indeTempobj < page.Objs.Count; indeTempobj++)
            {
                ClsDataObj tempobj = page.Objs[indeTempobj];
                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj == null)
                    continue;
                if (typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                {
                    tempc = (ClsTextdata)typeobj;
                    tempFont = cm.GetClsFontById(tempc.Fontid);
                    tbrush = new SolidBrush(tempFont.Fontcolor);
                    tempf = cm.GetFontById(tempc.Fontid);     //获取字体
                    tempChangeFCls = cm.GetClsFontById(tempc.Changecolorfontid);


                    //无时间点数据
                    if (tempobj.Rdatatime.Trim() == "")
                    {
                        if (tempc.Tdirection == "横")
                        {
                            //g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y);                     
                            if (tempc.Changecolorstr == null || tempc.Changecolorstr == "")
                            {
                                //正常显示文字
                                g.DrawString(tempobj.Val, tempf, tbrush, tempobj.X, tempobj.Y);
                            }
                            else
                            {
                                //替换字体颜色或状态
                                float tt_x = 0;
                                string tempvals = tempobj.Val.Replace(tempc.Changecolorstr, "^"); //特殊符号替换
                                string[] tvals = tempvals.Split('^');     //产生切割数组
                                tt_x = tempobj.X;

                                if (tempc.Changecolorfontid != "")
                                {
                                    tempChangeF = cm.GetFontById(tempc.Changecolorfontid); //指定字符串文字样式
                                    tempChangeBrush = new SolidBrush(tempChangeFCls.Fontcolor);
                                }
                                else
                                {
                                    tempChangeF = tempf; //指定字符串文字样式
                                    tempChangeBrush = tbrush;
                                }

                                //头部分
                                for (int i = 0; i < tvals.Length; i++)
                                {

                                    //正常文字显示
                                    g.DrawString(tvals[i], tempf, tbrush, tt_x, tempobj.Y);
                                    tt_x = tt_x + cm.GetTextWidth(g, tvals[i].ToString(), tempf);

                                    if (i < tvals.Length - 1)
                                    {
                                        //特殊文字处理
                                        g.DrawString(tempc.Changecolorstr, tempChangeF, tempChangeBrush, tt_x, tempobj.Y);
                                        tt_x = tt_x + cm.GetTextWidth(g, tempc.Changecolorstr, tempChangeF);
                                    }
                                }
                            }


                        }
                        else
                        {
                            float tempY = tempobj.Y;
                            int tfontheight = cm.GetTextHeight(g, tempobj.Val, tempf);
                            //竖
                            for (int i = 0; i < tempobj.Val.Length; i++)
                            {
                                g.DrawString(tempobj.Val[i].ToString(), tempf, tbrush, tempobj.X, tempY);
                                tempY = tempY + tfontheight;
                            }
                        }
                    }
                    else if (tempobj.Rdatatime.Trim() != "")
                    {
                        //有时间点数据
                        if (tempc.Tdirection == "横")
                        {
                            if (tempc.Align == "left")
                            {
                                setFormat(StringAlignment.Near, StringAlignment.Near, StringTrimming.EllipsisCharacter);
                            }
                            else if (tempc.Align == "right")
                            {
                                setFormat(StringAlignment.Far, StringAlignment.Near, StringTrimming.EllipsisCharacter);
                            }
                            else
                            {
                                setFormat(StringAlignment.Center, StringAlignment.Center, StringTrimming.EllipsisCharacter);
                            }
                            if (tempc.Texttype == "")
                            {
                                refc = new RectangleF(tempobj.X, tempobj.Y, tempc.Twidth, tempc.Theight);
                                g.DrawString(tempobj.Val, tempf, tbrush, refc, textFormat);
                            }
                        }
                        else
                        {
                            float tempY = tempobj.Y;
                            //int tfontwidth = cm.GetTextWidth(g, tempobj.Val, tempf);
                            int tfontheight = cm.GetTextHeight(g, tempobj.Val, tempf);
                            /*
                             * 事件等数据显示是同一时间段的话向X偏移
                             */
                            int cindex = 0;
                            if (tempobj.Rdatatime != "")
                            {
                                for (int i = 0; i < indeTempobj; i++)
                                {
                                    typeobj = cm.GetVDataSetByName(page.Objs[i].Typename);
                                    if (typeobj == null)
                                        continue;
                                    if (typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                                    {
                                        temptt = (ClsTextdata)typeobj;
                                        if (temptt.Name == tempc.Name)
                                        {
                                            if (page.Objs[i].Rdatatime == tempobj.Rdatatime)
                                            {
                                                cindex++;
                                            }
                                        }
                                    }
                                }
                            }
                            //竖
                            for (int i = 0; i < tempobj.Val.Length; i++)
                            {
                                g.DrawString(tempobj.Val[i].ToString(), tempf, tbrush, tempobj.X + cm.Time_width * cindex, tempY);
                                tempY = tempY + tfontheight;
                            }
                        }
                    }


                }
                else if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    templ = (ClsLinedata)typeobj;
                    ClsSymbol tempsmybol = cm.getClsSymbolByName(templ.Symbolname);
                    tempf = new Font(tempsmybol.fontname, Convert.ToSingle(tempsmybol.fontsize));
                    selectColor = Color.FromArgb(Convert.ToInt16(tempsmybol.color.Split(',')[0]),
                                          Convert.ToInt16(tempsmybol.color.Split(',')[1]),
                                          Convert.ToInt16(tempsmybol.color.Split(',')[2]));

                    Size offset = new Size(0, 0);
                    float xOffset = 0.0f;
                    if (tempsmybol.blackcolor)
                    {
                        Font blackkfont = new Font(tempsmybol.fontname, Convert.ToSingle(tempf.Size - 1));

                        tbrush = new SolidBrush(Color.White);
                        offset.Width = cm.GetTextWidth(g, "●", blackkfont);
                        offset.Height = cm.GetTextHeight(g, "●", blackkfont);
                        xOffset = (cm.Time_width - offset.Width) / 2.0f;
                        g.DrawString("●", blackkfont, tbrush, tempobj.X + xOffset, tempobj.Y - offset.Height / 2.0f);
                    }
                    tbrush = new SolidBrush(selectColor);

                    offset.Width = cm.GetTextWidth(g, tempsmybol.symbol1, tempf);
                    offset.Height = cm.GetTextHeight(g, tempsmybol.symbol1, tempf);
                    xOffset = (cm.Time_width - offset.Width) / 2.0f;
                    g.DrawString(tempsmybol.symbol1, tempf, tbrush, tempobj.X + xOffset, tempobj.Y - offset.Height / 2.0f);
                    if (tempsmybol.symbol2.Trim() != "")
                    {
                        tempf = new Font(tempsmybol.fontname, Convert.ToSingle(tempsmybol.fontsize) - Convert.ToSingle(tempsmybol.cfontsize));

                        if (tempsmybol.color2 != "")
                        {
                            selectColor = Color.FromArgb(Convert.ToInt16(tempsmybol.color2.Split(',')[0]),
                                             Convert.ToInt16(tempsmybol.color2.Split(',')[1]),
                                             Convert.ToInt16(tempsmybol.color2.Split(',')[2]));
                        }
                        tbrush = new SolidBrush(selectColor);
                        /*注销,添加以下代码,symbol2会错位,如H心率起搏
                        offset.Width = cm.GetTextWidth(g, tempsmybol.symbol2, tempf);
                        offset.Height = cm.GetTextHeight(g, tempsmybol.symbol2, tempf);
                        xOffset = (cm.Time_width - offset.Width) / 2.0f;
                        */
                        g.DrawString(tempsmybol.symbol2, tempf, tbrush, tempobj.X + xOffset + tempsmybol.cx, tempobj.Y - offset.Height / 2.0f + tempsmybol.cy);
                    }
                }
            }
        }

        internal void DrawComboDatas(Graphics g, Page page)
        {
            #region 重合点绘制

            int namecount = 0;
            ClsSymbol tempsymbol;
            List<ClsDataObj> CurrentClsDatas = new List<ClsDataObj>();
            List<ClsDataObj> listCobDatas = new List<ClsDataObj>();
            object typeobj;
            Font blackkfont;
            Color symbolColor2;

            foreach (ClsDataObj tempobj in page.Objs)
            {
                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    CurrentClsDatas.Add(tempobj);
                }
            }

            for (int index = 0; index < CurrentClsDatas.Count; index++)
            {
                listCobDatas = GetCobPoint(CurrentClsDatas, CurrentClsDatas[index]);

                //组合数据的显示
                foreach (ClsComboData tempcbom in cm.listcomboydatas)
                {
                    namecount = 0;

                    foreach (string tt in tempcbom.name.Split('+'))
                    {
                        foreach (ClsDataObj tobj in listCobDatas)
                        {
                            if (tobj.Typename == tt)
                            {
                                namecount++;
                                break;
                            }
                        }
                    }
                    if (tempcbom.name.Split('+').Length == namecount)
                    {
                        //有重复点
                        //绘制重复点
                        Point point = new Point(Convert.ToInt32(CurrentClsDatas[index].X), Convert.ToInt32(CurrentClsDatas[index].Y));

                        //背景                
                        for (int i = 0; i < cm.listsymbols.Count; i++)
                        {
                            tempsymbol = cm.listsymbols[i];
                            if (tempsymbol.name == tempcbom.combolsymbol)
                            {

                                tempf = new Font(tempsymbol.fontname, Convert.ToSingle(tempsymbol.fontsize));
                                selectColor = Color.FromArgb(Convert.ToInt16(tempsymbol.color.Split(',')[0]),
                                                        Convert.ToInt16(tempsymbol.color.Split(',')[1]),
                                                        Convert.ToInt16(tempsymbol.color.Split(',')[2]));


                                blackkfont = new Font(tempsymbol.fontname, Convert.ToSingle(tempf.Size - 1));
                                tbrush = new SolidBrush(Color.White);

                                g.DrawString("●", blackkfont, tbrush, point.X, point.Y - blackkfont.Size / 2 - 1);

                                tbrush = new SolidBrush(selectColor);
                                g.DrawString(tempsymbol.symbol1, tempf, tbrush, point.X, point.Y - tempf.Size / 2 - 1);
                                if (tempsymbol.symbol2.Trim() != "")
                                {
                                    if (tempsymbol.color2.Trim() != "")
                                    {
                                        symbolColor2 = Color.FromArgb(Convert.ToInt16(tempsymbol.color2.Split(',')[0]),
                                                        Convert.ToInt16(tempsymbol.color2.Split(',')[1]),
                                                        Convert.ToInt16(tempsymbol.color2.Split(',')[2]));
                                        tbrush = new SolidBrush(symbolColor2);
                                    }

                                    tempf = new Font(tempsymbol.fontname, Convert.ToSingle(tempsymbol.fontsize) - Convert.ToSingle(tempsymbol.cfontsize));
                                    g.DrawString(tempsymbol.symbol2, tempf, tbrush, point.X + tempsymbol.cx, point.Y + tempsymbol.cy - tempf.Size / 2 - 1);
                                }

                                break;  //找到就跳出循环
                            }
                        }
                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// 从listLineData中查找同dataObj,坐标重叠的数据
        /// </summary>
        /// <param name="listLineData"></param>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        internal List<ClsDataObj> GetCobPoint(List<ClsDataObj> listLineData, ClsDataObj dataObj)
        {
            List<ClsDataObj> tt = new List<ClsDataObj>();

            foreach (ClsDataObj tempobj in listLineData)
            {
                if (Math.Abs(tempobj.X - dataObj.X) < 0.001 && Math.Abs(tempobj.Y - dataObj.Y) < 0.001)
                {
                    tt.Add(tempobj);
                }
            }
            return tt;
        }


        /// <summary>
        /// 绘制线的连接
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        internal void DrawLineLink(Graphics g, Page page)
        {
            #region 画线新代码

            listplus.Clear();
            listheart.Clear();

            List<Point> pots = new List<Point>();
            List<int> brokesindexs = new List<int>(); //画线中断位置
            int cx = 0;
            object typeobj;


            //大类 正常点和骑线点            
            foreach (SymeType stype in cm.samestyes)
            {
                cx = -1;
                pots.Clear();
                objBrokens.Clear();
                foreach (string typestr in stype.Val.ToString().Split(','))
                {
                    foreach (ClsDataObj tempobj in page.Objs)
                    {
                        typeobj = cm.GetVDataSetByName(tempobj.Typename);
                        if (typeobj == null)
                            continue;
                        if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                        {
                            //点线类型
                            ClsLinedata tempDataTy = (ClsLinedata)typeobj;

                            // if (!tempobj.Typename.Contains("心率"))
                            {

                                if (tempDataTy.Name == typestr)
                                {
                                    #region  获取中断事件
                                    if (objBrokens.Count == 0)
                                    {
                                        foreach (ClsDataObj tempobj2 in page.Objs)
                                        {
                                            object typeobj2 = cm.GetVDataSetByName(tempobj2.Typename);
                                            if (typeobj2 == null)
                                                continue;
                                            if (typeobj2.ToString() == "TempertureEditor.Element.ClsTextdata")
                                            {
                                                foreach (string tempbrokenstr in tempDataTy.Broken.Split(','))
                                                {
                                                    if (tempbrokenstr == tempobj2.Typename)
                                                    {
                                                        objBrokens.Add(tempobj2);//索取所有需要中断的操作对象
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                    if (cx == -1)
                                    {
                                        this.Currentpen = cm.GetCurrentPen(tempDataTy.Penid);
                                        cx = Convert.ToInt16(tempDataTy.Span_x);
                                    }
                                    pots.Add(new Point(Convert.ToInt16(tempobj.X) + Convert.ToInt16(tempDataTy.Span_x),
                                                     Convert.ToInt16(tempobj.Y) + Convert.ToInt16(tempDataTy.Span_y)));

                                }
                            }
                        }
                    }
                }

                pots = GetSortPoint(pots);
                if (pots.Count > 1)
                {
                    for (int i = 0; i < pots.Count - 1; i++)
                    {
                        //设置中断点
                        bool isbroke = false;
                        for (int k = 0; k < objBrokens.Count; k++)
                        {
                            if ((objBrokens[k].X + cx) >= pots[i].X && (objBrokens[k].X + cx) < pots[i + 1].X)
                            {
                                isbroke = true;
                                break;
                            }
                        }
                        if (!isbroke)
                        {
                            g.DrawLine(this.Currentpen, pots[i], pots[i + 1]);
                        }
                    }
                }
            }


            //非大类
            foreach (ClsLinedata linedata in cm.listlinedatas)
            {
                cx = -1;
                pots.Clear();
                objBrokens.Clear();
                foreach (ClsDataObj tempobj in page.Objs)
                {
                    if (!tempobj.Typename.Contains("↓")) //体温降温点不连线
                    {
                        typeobj = cm.GetVDataSetByName(tempobj.Typename);
                        if (typeobj != null && typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                        {
                            //点线类型
                            ClsLinedata tempDataTy = (ClsLinedata)typeobj;
                            bool isnottype = false;
                            foreach (SymeType stype in cm.samestyes)
                            {
                                foreach (string typestr in stype.Val.ToString().Split(','))
                                {
                                    if (tempDataTy.Name == typestr)
                                    {

                                        #region  获取中断事件
                                        if (objBrokens.Count == 0)
                                        {
                                            foreach (ClsDataObj tempobj2 in page.Objs)
                                            {
                                                object typeobj2 = cm.GetVDataSetByName(tempobj2.Typename);
                                                if (typeobj2 != null && typeobj2.ToString() == "TempertureEditor.Element.ClsTextdata")
                                                {
                                                    foreach (string tempbrokenstr in tempDataTy.Broken.Split(','))
                                                    {
                                                        if (tempbrokenstr == tempobj2.Typename)
                                                        {
                                                            objBrokens.Add(tempobj2);//索取所有需要中断的操作对象
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        isnottype = true;
                                        break;
                                    }
                                }
                            }
                            if (!isnottype)
                            {
                                if (linedata.Name == tempDataTy.Name)
                                {
                                    if (cx == -1)
                                    {
                                        this.Currentpen = cm.GetCurrentPen(tempDataTy.Penid);
                                        cx = Convert.ToInt16(tempDataTy.Span_x);
                                    }

                                    //坐标
                                    pots.Add(new Point(Convert.ToInt16(tempobj.X) + Convert.ToInt16(tempDataTy.Span_x),
                                                     Convert.ToInt16(tempobj.Y) + Convert.ToInt16(tempDataTy.Span_y)));
                                }
                            }
                        }
                    }
                }
                pots = GetSortPoint(pots);
                if (pots.Count > 1)
                {
                    for (int i = 0; i < pots.Count - 1; i++)
                    {
                        //设置中断点
                        bool isbroke = false;
                        for (int k = 0; k < objBrokens.Count; k++)
                        {
                            if ((objBrokens[k].X + cx) >= pots[i].X && (objBrokens[k].X + cx) < pots[i + 1].X)
                            {
                                isbroke = true;
                                break;
                            }
                        }
                        if (!isbroke)
                            g.DrawLine(this.Currentpen, pots[i], pots[i + 1]);

                    }
                }
            }
            #endregion

            hertLineLink(g, page);
        }

        /// <summary>
        /// 心率连线设置
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        internal void hertLineLink(Graphics g, Page page)
        {

            object typeobj;
            foreach (ClsDataObj tempobj in page.Objs)
            {
                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj == null)
                    continue;
                if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    //点线类型
                    ClsLinedata tempDataTy = (ClsLinedata)typeobj;

                    if (tempobj.Typename.Contains("脉搏"))
                    {
                        listplus.Add(new Point(Convert.ToInt16(tempobj.X) + Convert.ToInt16(tempDataTy.Span_x),
                                     Convert.ToInt16(tempobj.Y) + Convert.ToInt16(tempDataTy.Span_y)));
                    }
                    else if (tempobj.Typename.Contains("心率"))
                    {
                        this.Currentpen = cm.GetCurrentPen(tempDataTy.Penid);
                        listheart.Add(new Point(Convert.ToInt16(tempobj.X) + Convert.ToInt16(tempDataTy.Span_x),
                                    Convert.ToInt16(tempobj.Y) + Convert.ToInt16(tempDataTy.Span_y)));
                    }
                }
            }

            #region 事件中断
            List<PointF> objBrokensPoints = new List<PointF>();

            foreach (ClsDataObj tempobj in page.Objs)
            {

                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj != null && typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                {
                    foreach (ClsLinedata tempdata in cm.listlinedatas)
                    {
                        if (tempdata.Name == "心率")
                        {
                            foreach (string tempbrokenstr in tempdata.Broken.Split(','))
                            {
                                if (tempbrokenstr == tempobj.Typename)
                                {

                                    PointF pt = new PointF(tempobj.X + tempdata.Span_x, tempobj.Y + tempdata.Span_y);

                                    objBrokensPoints.Add(pt);

                                    //objBrokens.Add(tempobj);//索取所有需要中断的操作对象
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            #endregion

            listplus = GetSortPoint(listplus);
            listheart = GetSortPoint(listheart);
            int heartindex = 0;

            for (int i = 0; i < listplus.Count - 1; i++)
            {

                if (listheart.Count > 1 && listplus[i].X == listheart[heartindex].X)
                {

                    if (listplus[i + 1].X == listheart[heartindex + 1].X)
                    {

                        bool isbroken = false;
                        foreach (PointF ptb in objBrokensPoints)
                        {
                            if (ptb.X >= listheart[heartindex].X && ptb.X < listheart[heartindex + 1].X)
                            {
                                isbroken = true;
                            }
                        }

                        if (!isbroken)
                            g.DrawLine(this.Currentpen, listheart[heartindex], listheart[heartindex + 1]);

                    }
                    if (heartindex < listheart.Count - 2)
                        heartindex = heartindex + 1;

                }


            }
        }

        /// <summary>
        /// 根据点的X轴由小
        /// </summary>
        /// <param name="pots"></param>
        /// <returns></returns>
        private List<Point> GetSortPoint(List<Point> pots)
        {
            List<Point> pts = pots;
            try
            {
                Point tempp = new Point();
                for (int i = 0; i < pots.Count; i++)
                {

                    for (int k = 0; k < pots.Count - 1; k++)
                    {
                        if (pots[k].X > pots[k + 1].X)
                        {
                            tempp = pots[k];
                            pots[k] = pots[k + 1];
                            pots[k + 1] = tempp;
                        }
                    }
                }
                return pots;
            }
            catch
            {
                return pts;
            }
        }

        /// <summary>
        /// 根据点的X轴由小 -F
        /// </summary>
        /// <param name="pots"></param>
        /// <returns></returns>
        private List<PointF> GetSortPointF(List<PointF> pots)
        {
            List<PointF> pts = pots;
            try
            {
                PointF tempp = new PointF();
                for (int i = 0; i < pots.Count; i++)
                {

                    for (int k = 0; k < pots.Count - 1; k++)
                    {
                        if (pots[k].X > pots[k + 1].X)
                        {
                            tempp = pots[k];
                            pots[k] = pots[k + 1];
                            pots[k + 1] = tempp;
                        }
                    }
                }
                return pots;
            }
            catch
            {
                return pts;
            }
        }

        /// <summary>
        ///体温降温虚线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        internal void DrawLineLinkTempDown(Graphics g, Page page)
        {
            object typeobj;
            ClsLinedata tempc;
            foreach (ClsDataObj tempobj in page.Objs)
            {
                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj == null)
                    continue;
                if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    tempc = (ClsLinedata)typeobj;
                    foreach (SymeType temptype in cm.samestyes)
                    {
                        //获取体温单
                        if (temptype.name == "体温组合")
                        {
                            if (temptype.Val.Contains(tempc.Name))
                            {
                                ptds.Add(new Point(Convert.ToInt32(tempobj.X + tempc.Span_x), Convert.ToInt32(tempobj.Y + tempc.Span_y)));
                            }
                        }

                        //获取降温点
                        if (tempc.Name.Contains("↓"))
                        {
                            this.Currentpen = cm.GetCurrentPen(tempc.Penid);
                            ptds2.Add(new Point(Convert.ToInt32(tempobj.X + tempc.Span_x), Convert.ToInt32(tempobj.Y + tempc.Span_y)));
                        }
                    }
                }
            }

            this.Currentpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.Currentpen.DashPattern = new float[] { 5, 5 };

            foreach (Point t1 in ptds)
            {
                foreach (Point t2 in ptds2)
                {
                    if (t1.X == t2.X)
                    {
                        //降温虚线
                        g.DrawLine(this.Currentpen, t1, t2);
                    }
                }
            }
        }


        /// <summary>
        /// 斜线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        internal void DrawPurseBriefness(Graphics g, Page page)
        {
            List<PointF> pulse = new List<PointF>();
            List<PointF> heart = new List<PointF>();

            List<PointF> pulse2 = new List<PointF>();
            List<PointF> heart2 = new List<PointF>();
            Pen pn = new Pen(Color.Red);
            ClsLinedata tempc;
            object typeobj;


            List<PointF> objBrokensPoints = new List<PointF>();

            foreach (ClsDataObj tempobj in page.Objs)
            {

                typeobj = cm.GetVDataSetByName(tempobj.Typename);
                if (typeobj == null)
                    continue;
                if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    foreach (ClsLinedata tempdata in cm.listlinedatas)
                    {
                        if (tempdata.Name == "心率")
                        {
                            foreach (string tempbrokenstr in tempdata.Broken.Split(','))
                            {
                                if (tempbrokenstr == tempobj.Typename)
                                {

                                    PointF pt = new PointF(tempobj.X + tempdata.Span_x, tempobj.Y + tempdata.Span_y);

                                    objBrokensPoints.Add(pt);

                                    //objBrokens.Add(tempobj);//索取所有需要中断的操作对象
                                    break;
                                }
                            }
                        }
                    }

                }
            }

            foreach (ClsBlock tempblock in cm.blocks)
            {
                foreach (ClsDataObj tempobj in page.Objs)
                {
                    typeobj = cm.GetVDataSetByName(tempobj.Typename);
                    if (typeobj == null)
                        continue;
                    if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                    {
                        tempc = (ClsLinedata)typeobj;
                        for (int i = 0; i < tempblock.Val.Split(',').Length; i++)
                        {
                            if (tempblock.Val.Split(',')[i].Contains("心率"))
                            {
                                if (tempc.Name == tempblock.Val.Split(',')[i])
                                {
                                    heart.Add(new PointF(tempobj.X + tempc.Span_x, tempobj.Y + tempc.Span_y));
                                }
                            }
                            if (tempblock.Val.Split(',')[i].Contains("脉搏"))
                            {
                                if (tempc.Name == tempblock.Val.Split(',')[i])
                                {
                                    pulse.Add(new PointF(tempobj.X + tempc.Span_x, tempobj.Y + tempc.Span_y));
                                }
                            }
                        }
                    }
                }
                heart = GetSortPointF(heart);
                pulse = GetSortPointF(pulse);

                objBrokensPoints = GetSortPointF(objBrokensPoints);

                for (int i = 0; i < objBrokensPoints.Count; i++)
                {
                    heart2.Clear();
                    pulse2.Clear();
                    /*
                     *中断事件 
                     */
                    if (i == 0)
                    {
                        for (int i2 = 0; i2 < heart.Count; i2++)
                        {
                            if (heart[i2].X <= objBrokensPoints[i].X)
                            {
                                heart2.Add(heart[i2]);
                            }
                        }
                        for (int i2 = 0; i2 < pulse.Count; i2++)
                        {
                            if (pulse[i2].X <= objBrokensPoints[i].X)
                            {
                                pulse2.Add(pulse[i2]);
                            }
                        }
                        heart2 = GetSortPointF(heart2);
                        pulse2 = GetSortPointF(pulse2);
                        if (tempblock.Showtype == "横")
                        {
                            //横
                            fillBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(0));
                        }
                        else if (tempblock.Showtype == "竖")
                        {
                            //竖
                            fillBrush = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(0));
                        }
                        else
                        {
                            //斜
                            fillBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.FromArgb(0));
                        }
                        printPurseBriefness(pulse2, heart2, pn, g, page);

                    }
                    else
                    {
                        for (int i2 = 0; i2 < heart.Count; i2++)
                        {
                            if (heart[i2].X > objBrokensPoints[i - 1].X && heart[i2].X <= objBrokensPoints[i].X)
                            {
                                heart2.Add(heart[i2]);
                            }
                        }
                        for (int i2 = 0; i2 < pulse.Count; i2++)
                        {
                            if (pulse[i2].X > objBrokensPoints[i - 1].X && pulse[i2].X <= objBrokensPoints[i].X)
                            {
                                pulse2.Add(pulse[i2]);
                            }
                        }
                        heart2 = GetSortPointF(heart2);
                        pulse2 = GetSortPointF(pulse2);
                        if (tempblock.Showtype == "横")
                        {
                            //横
                            fillBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(0));
                        }
                        else if (tempblock.Showtype == "竖")
                        {
                            //竖
                            fillBrush = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(0));
                        }
                        else
                        {
                            //斜
                            fillBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.FromArgb(0));
                        }
                    }
                }
                #region   最后一个中断事件之后的所有点或无中断事件情况
                heart2.Clear();
                pulse2.Clear();
                if (objBrokensPoints.Count > 0)
                {
                    int lastEventIndex = objBrokensPoints.Count - 1;
                    //存在中断事件
                    for (int i2 = 0; i2 < heart.Count; i2++)
                    {
                        if (heart[i2].X > objBrokensPoints[lastEventIndex].X)
                        {
                            heart2.Add(heart[i2]);
                        }
                    }
                    for (int i2 = 0; i2 < pulse.Count; i2++)
                    {
                        if (pulse[i2].X > objBrokensPoints[lastEventIndex].X)
                        {
                            pulse2.Add(pulse[i2]);
                        }
                    }

                }
                else
                {
                    //不存在中断事件
                    for (int i2 = 0; i2 < heart.Count; i2++)
                    {
                        heart2.Add(heart[i2]);
                    }
                    for (int i2 = 0; i2 < pulse.Count; i2++)
                    {
                        pulse2.Add(pulse[i2]);
                    }


                }
                heart2 = GetSortPointF(heart2);
                pulse2 = GetSortPointF(pulse2);
                if (tempblock.Showtype == "横")
                {
                    //横
                    fillBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(0));
                }
                else if (tempblock.Showtype == "竖")
                {
                    //竖
                    fillBrush = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(0));
                }
                else
                {
                    //斜
                    fillBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.FromArgb(0));
                }
                printPurseBriefness(pulse2, heart2, pn, g, page);

                #endregion

            }
        }

        /// <summary>
        /// 脉搏短促 -
        /// </summary>
        /// <param name="pulse"></param>
        /// <param name="heart"></param>
        private void printPurseBriefness(List<PointF> pulse, List<PointF> heart, Pen pn, Graphics g, Page page)
        {
            if (heart.Count > 0)
            {
                List<PointF> pulses = new List<PointF>();
                List<PointF> hearts = new List<PointF>();
                PointF pheart;
                PointF ppulse;
                PointF startP;
                PointF endP;
                for (int i = 0; i < heart.Count; i++)
                {
                    pheart = heart[i];

                    ppulse = pulse.Find(delegate (PointF pf) { return pf.X == pheart.X; });
                    startP = getStartPoint(pulse, ppulse);
                    endP = getEndPoint(pulse, ppulse);
                    if (hearts.Count == 0)
                    {
                        hearts.Add(pheart);
                        pulses.Add(startP);
                        if (!pulses.Contains(ppulse))
                            pulses.Add(ppulse);
                        if (!pulses.Contains(endP))
                            pulses.Add(endP);
                    }
                    else
                    {
                        if (pulses.Contains(ppulse) && pulses.Contains(startP))
                        {
                            if (!pulses.Contains(endP))
                            {
                                pulses.Add(endP);
                            }
                            if (!hearts.Contains(pheart))
                            {
                                hearts.Add(pheart);
                            }
                        }
                        else
                        {
                            printPurseBriefness1(pulses, hearts, g, pn);
                            pulses.Clear();
                            hearts.Clear();
                            i--;
                        }
                    }
                }
                printPurseBriefness1(pulses, hearts, g, pn);

            }

        }


        /// <summary>
        /// 每个小区间脉搏短促画线
        /// </summary>
        /// <param name="pulse"></param>
        /// <param name="heart"></param>
        private void printPurseBriefness1(List<PointF> pulse, List<PointF> heart, Graphics g, Pen rp)
        {
            if (heart.Count > 0)
            {
                g.DrawLine(rp, pulse[0], heart[0]);
                g.DrawLine(rp, pulse[pulse.Count - 1], heart[heart.Count - 1]);
                //短促连线
                if (heart.Count > 1)
                {
                    for (int i = 0; i < heart.Count - 1; i++)
                    {
                        //this.graph.DrawLine(redPen, heart[i], heart[i + 1]);
                    }
                }
                heart.Reverse();
                foreach (PointF pd in heart)
                {
                    pulse.Add(pd);
                }
                g.FillPolygon(fillBrush, pulse.ToArray());
            }
        }


        private PointF GetPoint(PointF pf1, PointF pf2, float pfx)
        {
            float pfy = (pfx - pf1.X) * (pf2.Y - pf1.Y) / (pf2.X - pf1.X) + pf1.Y;
            return new PointF(pfx, pfy);
        }

        /// <summary>
        /// 得到以前的第一个点
        /// </summary>
        private PointF getStartPoint(List<PointF> pulse, PointF ppulse)
        {
            PointF px = ppulse;
            for (int i = 0; i < pulse.Count; i++)
            {
                if (pulse[i].X < ppulse.X)
                    px = pulse[i];
            }
            return px;
        }


        /// <summary>
        /// 得到之后的第一个点
        /// </summary>
        private PointF getEndPoint(List<PointF> pulse, PointF ppulse)
        {
            PointF px = ppulse;
            for (int i = 0; i < pulse.Count; i++)
            {
                if (pulse[i].X > ppulse.X)
                {
                    px = pulse[i];
                    break;
                }
            }
            return px;
        }
        #endregion

        /// <summary>
        /// 体温单绘制外部接口
        /// </summary>
        public void TemperturePaintInterface(Graphics g, Page page)
        {
            //cm.SysXmlfileName = App.SysPath + "\\TempertureSet_newTable.tmb";
            //cm.XmlDoc.Load(cm.SysXmlfileName);
            //cm.IniTreeView(cm.XmlDoc,ref cm.CurrentTree);

            DrawTemper(g, null, false);  //体温单样式

            if (page != null)
            {
                //数据存在的话刷数据
                DrawLineLinkTempDown(g, page);
                DrawLineLink(g, page);
                DrawPurseBriefness(g, page);
                DrawData(g, page);
                DrawComboDatas(g, page);
                DrawUpdownTextData(g, page);
            }
            GC.Collect();
        }

        /// <summary>
        /// 体温单绘制内部接口
        /// </summary>
        /// <param name="g"></param>
        /// <param name="page"></param>
        /// <param name="isedit"></param>
        internal void TemperturePaintInternal(Graphics g, TreeNode selectnode, Page page, bool isedit)
        {
            DrawTemper(g, selectnode, isedit);  //体温单样式
            if (page != null)
            {
                //数据存在的话刷数据
                DrawLineLinkTempDown(g, page);
                DrawLineLink(g, page);
                DrawPurseBriefness(g, page);
                DrawData(g, page);
                DrawComboDatas(g, page);
                DrawUpdownTextData(g, page);
            }
            GC.Collect();
        }
    }
}
