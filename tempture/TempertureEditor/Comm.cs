using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using TempertureEditor.Element;
using Bifrost;
using System.Data;

namespace TempertureEditor
{
    public class Comm
    {
        /// <summary>
        /// 体温单配置文件
        /// </summary>
        public XmlDocument XmlDoc = new XmlDocument();
        public  TreeNode newnode;   //寄存器
        public  string SysXmlfileName = "";      //配置文件路径
        public  string SysXmlTempfileName = "";  //配置操作临时文件
        public  List<ClsPens> listpens = new List<ClsPens>();   //当前画笔素材
        public  List<ClsFont> listfonts = new List<ClsFont>();  //当前字体素材
        public  List<ClsSymbol> listsymbols = new List<ClsSymbol>();  //当前标签素材
        public  List<ClsLinedata> listlinedatas = new List<ClsLinedata>();  //当前画线数据设置集合
        public  List<ClsTextdata> listtextdatas = new List<ClsTextdata>();  //当前文字数据设置集合
        public  List<ClsComboData> listcomboydatas = new List<ClsComboData>(); //组合标签类型集合
        //特殊体温单时间点容器，(每日录入时间点各不固定)；正常体温单时间点容器，(每日录入时间点固定)listWriteTimes
        public  List<string> listWriteTimes = new List<string>();
        public  int MaxWidth = 200;
        public  int MaxHeight = 400;
        public  int Day_X = 200;
        public  int Day_Y = 400;
        public  int Day_Width = 72;
        public  int Time_width = 12;
        public  int ggenid = 0; //自动生成主键
        public  TreeView CurrentTree; //用于寄存当前树控件
        public  TreeView OrignalTree; //用于寄存当前树控件
        public  List<Page> Pages = new List<Page>(); //体温单页集合
        public  List<SymeType> samestyes = new List<SymeType>(); //获取相同大类设置
        public  List<ClsBlock> blocks = new List<ClsBlock>(); //区域组合类型集合
       



        /// <summary>
        /// 根据颜色字符串返回颜色对象
        /// </summary>
        /// <param name="colorstr"></param>
        /// <returns></returns>
        public Color GetColorByStr(string colorstr)
        {
            try
            {
                Color bcolor = Color.FromArgb(Convert.ToInt16(colorstr.Split(',')[0]),
                                                 Convert.ToInt16(colorstr.Split(',')[1]),
                                                 Convert.ToInt16(colorstr.Split(',')[2]));
                return bcolor;
            }
            catch
            {
                return Color.Black;
            }
        }
        /// <summary>
        /// 获取插入病历数据库常量表sql
        /// </summary>
        /// <param name="typename">类名</param>
        /// <param name="idParentType">父类id</param>
        /// <param name="baseType">类名所属组合</param>
        /// <returns></returns>
        public static string GetInsertDataCodeTypeSql(string typename, int idParentType, string baseType)
        {
            string sql = "insert into t_data_code (ID, NAME, CODE, SHORTCUT_CODE, ENABLE, TYPE, BZDM, ORDER_ID)" +
                        " values(" + App.GenId() + ", '" + typename + "', '" + App.GenTextId() + "', '', 'Y', '" + idParentType.ToString() + "','" + baseType + "', null)";
            return sql;
        }

        /// <summary>
        /// 把体温单模板里的数据类型名称添加到"新体温类型"常量表里
        /// </summary>
        /// <returns></returns>
        public bool InsertNewTemperatureType()
        {
            App.Ini();
            //同步质控数据类型
            const string parentTypeName = "新体温类型";
            const string parentType = "8989898989";
            int idParentType = 12317257;


            string sql = "select * from t_data_code_type t where t.id=" + idParentType;
            DataTable dTable = App.GetDataSet(sql).Tables[0];
            if (dTable.Rows.Count > 0)
            {
                if (dTable.Rows[0]["name"].ToString() != parentTypeName || dTable.Rows[0]["type"].ToString() != parentType)
                {
                    string msg = "新体温类型ID:'" + idParentType + "'已经被" + dTable.Rows[0]["name"].ToString() + "占用,\r\n位置:Comm.InsertNewTemperatureType()！\r\n";
                    msg += "提示:新体温类型的name,type分别是'" + parentTypeName + "','" + parentType + "'应该保持一致,不应该改变!";
                    App.Msg(msg);
                    return false;
                }
            }
            else
            {
                sql = "insert into t_data_code_type (ID, NAME, TYPE) values(" + idParentType + ", '" + parentTypeName + "', '" + parentType + "')";
                if (App.ExecuteSQL(sql) <= 0)
                {
                    App.Msg("数据库操作失败,位置:Comm.InsertNewTemperatureType()！");
                    return false;
                }

            }

            sql = "select t.name from t_data_code t where type='" + idParentType + "'";

            dTable = App.GetDataSet(sql).Tables[0];

            List<string> listExistTypeCode = new List<string>();
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                listExistTypeCode.Add(dTable.Rows[i]["name"].ToString());
            }

            List<string> sqls = new List<string>();
            SymeType tmpSymeType;
            string baseType;
            foreach (ClsLinedata linedata in listlinedatas)
            {
                if (!listExistTypeCode.Contains(linedata.Name))
                {
                    tmpSymeType = samestyes.Find(delegate (SymeType st) { return st.Val.Contains(linedata.Name); });

                    if (tmpSymeType != null)
                        baseType = tmpSymeType.name;
                    else
                        baseType = "";

                    sqls.Add(GetInsertDataCodeTypeSql(linedata.Name, idParentType, baseType));
                }

            }

            foreach (ClsTextdata textdata in listtextdatas)
            {
                if (!listExistTypeCode.Contains(textdata.Name))
                {
                    tmpSymeType = samestyes.Find(delegate (SymeType st) { return st.Val.Contains(textdata.Name); });

                    if (tmpSymeType != null)
                        baseType = tmpSymeType.name;
                    else
                        baseType = "";
                    sqls.Add(GetInsertDataCodeTypeSql(textdata.Name, idParentType, baseType));
                }

            }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 外部调用初始化
        /// </summary>
        public  void startini()
        {
            if (SysXmlfileName == null || SysXmlfileName == "")
                SysXmlfileName = App.SysPath + "\\TempertureSet_newTable.tmb";
            XmlDoc.Load(SysXmlfileName);
            CurrentTree = new TreeView();

            foreach (XmlNode tn in XmlDoc.DocumentElement.ChildNodes)
            {
                TreeNode temptn = new TreeNode();
                temptn.Name = tn.Name;
                temptn.Text = tn.Name;
                CurrentTree.Nodes.Add(temptn);
            }

            IniTreeView(XmlDoc, ref CurrentTree);

        }

        /// <summary>
        /// 外部调用初始化
        /// </summary>
        /// <param name="tempfliename">模版名称</param>
        public  void startini(string tempfliename)
        {
            //if (SysXmlfileName == null || SysXmlfileName == "")
            SysXmlfileName = App.SysPath + "\\" + tempfliename;
            XmlDoc.Load(SysXmlfileName);
            CurrentTree = new TreeView();

            foreach (XmlNode tn in XmlDoc.DocumentElement.ChildNodes)
            {
                TreeNode temptn = new TreeNode();
                temptn.Name = tn.Name;
                temptn.Text = tn.Name;
                CurrentTree.Nodes.Add(temptn);
            }

            IniTreeView(XmlDoc, ref CurrentTree);
        }

        /// <summary>
        /// 根据画笔主键获取画笔
        /// </summary>
        /// <param name="penid"></param>
        /// <returns></returns>
        public  Pen GetCurrentPen(string penid)
        {
            try
            {
                foreach (ClsPens temp in listpens)
                {
                    if (temp.Tname == penid)
                    {
                        return new Pen(temp.Pencolor, temp.Pensize);
                    }
                }
                return new Pen(Color.Black, 1);
            }
            catch
            {
                return new Pen(Color.Black, 1);
            }
        }

        /// <summary>
        /// 获取字体类型对象
        /// </summary>
        /// <param name="fontid"></param>
        /// <returns></returns>
        public  ClsFont GetClsFontById(string fontid)
        {
            try
            {
                foreach (ClsFont temp in listfonts)
                {
                    if (temp.Tname == fontid)
                    {
                        return temp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        public  Font GetFontById(string fontid)
        {
            Font ft = new Font("宋体", 10);
            try
            {
                foreach (ClsFont temp in listfonts)
                {
                    if (temp.Tname == fontid)
                    {
                        ft = new Font(new FontFamily(temp.Fontname), Convert.ToSingle(temp.Fontsize));
                        if (temp.Isbold)
                        {
                            //粗体
                            ft = new Font(ft, FontStyle.Bold);
                        }

                        if (temp.Isunderline)
                        {
                            //下划线
                            ft = new Font(ft, ft.Style | FontStyle.Underline);
                        }

                        if (temp.Isita)
                        {
                            //斜体
                            ft = new Font(ft, ft.Style | FontStyle.Italic);
                        }
                        return ft;
                    }
                }
                return ft;
            }
            catch
            {
                return ft;
            }
        }

        /// <summary>
        /// 生成自定义ID
        /// </summary>
        /// <returns></returns>
        public int getGenid()
        {
            ggenid = ggenid + 1;
            XmlNode tn = XmlDoc.DocumentElement;
            tn.Attributes["Genid"].Value = ggenid.ToString();
            XmlDoc.Save(SysXmlfileName);
            return ggenid;
        }

        /// <summary>
        /// 根据配置文件初始化树节点
        /// </summary>
        /// <param name="XmlDoc"></param>
        internal  void IniTreeView(XmlDocument XmlDoc, ref TreeView trvTemperture)
        {
            listpens = new List<ClsPens>();
            listfonts = new List<ClsFont>();
            listsymbols = new List<ClsSymbol>();
            listlinedatas = new List<ClsLinedata>();
            listtextdatas = new List<ClsTextdata>();
            listcomboydatas = new List<ClsComboData>();

            ggenid = Convert.ToInt32(XmlDoc.DocumentElement.Attributes["Genid"].Value);

            //初始化树节点
            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                if (tn.Name.ToLower() == "times")
                {
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsWriteTimes"))
                    {
                        string[] strs = tempxmlnode.InnerText.Split(',');
                        listWriteTimes = new List<string>(strs);
                    }
                }
                else if (tn.Name.ToLower() == "pens")
                {
                    //画笔
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsPens"))
                    {
                        ClsPens temppen = new ClsPens();
                        temppen.Id = tempxmlnode.Attributes["Id"].Value;
                        temppen.Tname = tempxmlnode.Attributes["Tname"].Value;
                        temppen.Pensize = Convert.ToSingle(tempxmlnode.Attributes["Pensize"].Value);
                        temppen.Pencolor = GetColorByStr(tempxmlnode.Attributes["Pencolor"].Value);
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = temppen.Id;
                        tempnode.Text = temppen.Tname;
                        tempnode.Tag = temppen;
                        tn.Nodes.Add(tempnode);

                        listpens.Add(temppen);
                    }
                }
                else if (tn.Name.ToLower() == "fonts")
                {
                    //字体信息
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsFont"))
                    {
                        ClsFont temppen = new ClsFont();
                        temppen.Id = tempxmlnode.Attributes["Id"].Value;
                        temppen.Tname = tempxmlnode.Attributes["Tname"].Value;
                        temppen.Fontname = tempxmlnode.Attributes["Fontname"].Value;
                        temppen.Fontcolor = GetColorByStr(tempxmlnode.Attributes["Fontcolor"].Value);
                        temppen.Fontsize = Convert.ToSingle(tempxmlnode.Attributes["Fontsize"].Value);
                        temppen.Isbold = Convert.ToBoolean(tempxmlnode.Attributes["Isbold"].Value);
                        temppen.Isita = Convert.ToBoolean(tempxmlnode.Attributes["Isita"].Value);
                        temppen.Isunderline = Convert.ToBoolean(tempxmlnode.Attributes["Isunderline"].Value);

                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = temppen.Id;
                        tempnode.Text = temppen.Tname;
                        tempnode.Tag = temppen;
                        tn.Nodes.Add(tempnode);

                        listfonts.Add(temppen);
                    }
                }
                else if (tn.Name.ToLower() == "symbol")
                {
                    //标签信息
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsSymbol"))
                    {
                        ClsSymbol tempSymbol = new ClsSymbol();
                        tempSymbol.name = tempxmlnode.Attributes["name"].Value;
                        tempSymbol.symbol1 = tempxmlnode.Attributes["symbol1"].Value;
                        tempSymbol.symbol2 = tempxmlnode.Attributes["symbol2"].Value;
                        tempSymbol.symbol3 = tempxmlnode.Attributes["symbol3"].Value;
                        tempSymbol.color = tempxmlnode.Attributes["color"].Value;
                        tempSymbol.color2 = tempxmlnode.Attributes["color2"].Value;
                        tempSymbol.fontname = tempxmlnode.Attributes["fontname"].Value;
                        tempSymbol.fontsize = tempxmlnode.Attributes["fontsize"].Value;
                        tempSymbol.blackcolor = Convert.ToBoolean(tempxmlnode.Attributes["blackcolor"].Value);
                        tempSymbol.cx = Convert.ToInt16(tempxmlnode.Attributes["cx"].Value);
                        tempSymbol.cy = Convert.ToInt16(tempxmlnode.Attributes["cy"].Value);
                        tempSymbol.cfontsize = tempxmlnode.Attributes["cfontsize"].Value;
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempSymbol.name;
                        tempnode.Text = tempSymbol.name;
                        tempnode.Tag = tempSymbol;
                        tn.Nodes.Add(tempnode);
                        listsymbols.Add(tempSymbol);
                    }


                }
                else if (tn.Name.ToLower() == "element")
                {
                    //图片
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsImg"))
                    {
                        ClsImg tempelement = new ClsImg();
                        tempelement.Id = tempxmlnode.Attributes["Id"].Value;
                        tempelement.Imgname = tempxmlnode.Attributes["Imgname"].Value;
                        if (tempelement.Imgname != "")
                            if (File.Exists(App.SysPath + "\\" + tempelement.Imgname))
                                tempelement.Img = new Bitmap(App.SysPath + "\\" + tempelement.Imgname);//getImgBybytes(tempxmlnode.InnerText);
                        tempelement.X = Convert.ToInt16(tempxmlnode.Attributes["X"].Value);
                        tempelement.Y = Convert.ToInt16(tempxmlnode.Attributes["Y"].Value);
                        tempelement.Pwidth = Convert.ToInt16(tempxmlnode.Attributes["Pwidth"].Value);
                        tempelement.Pheight = Convert.ToInt16(tempxmlnode.Attributes["Pheight"].Value);
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Id;
                        tempnode.Text = "图片-" + tempelement.Id;
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);

                    }

                    //字体
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsText"))
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
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Id;
                        if (tempelement.Vtext.Length > 5)
                        {
                            tempnode.Text = "文字-" + tempelement.Vtext.Substring(0, 4) + "...";
                        }
                        else
                        {
                            tempnode.Text = "文字-" + tempelement.Vtext;
                        }
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);
                    }

                    //画笔
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsLine"))
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

                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Id;
                        tempnode.Text = "线-" + tempelement.Id;
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);


                    }

                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsRec"))
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

                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Id;
                        tempnode.Text = "矩形区域-" + tempelement.Id;
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);
                    }

                    //体温单大小节点
                    XmlNodeList mainnodes = XmlDoc.GetElementsByTagName("ClsMainFrame");
                    if (mainnodes.Count > 0)
                    {
                        XmlNode mainnode = mainnodes[0];
                        ClsMainFrame mainfram = new ClsMainFrame();
                        mainfram.Twidth = Convert.ToInt16(mainnode.Attributes["Twidth"].Value);
                        mainfram.Theight = Convert.ToInt16(mainnode.Attributes["Theight"].Value);
                        mainfram.Day_x = Convert.ToInt16(mainnode.Attributes["Day_x"].Value);
                        mainfram.Day_y = Convert.ToInt16(mainnode.Attributes["Day_y"].Value);
                        mainfram.Timewidth = Convert.ToInt16(mainnode.Attributes["Timewidth"].Value);
                        mainfram.Daywidth = Convert.ToInt16(mainnode.Attributes["Daywidth"].Value);
                        //一张A4 白纸是2100*2970DMM
                        //0.1毫米＝1DMM丝米，1英寸＝25.4毫米
                        Graphics g = trvTemperture.CreateGraphics();
                        double xPinexCountPerDMM = g.DpiX / 254.0; //横向：每丝米像素点个数
                        double yPinexCountPerDMM = g.DpiY / 254.0; //纵向：每丝米像素点个数
                        g.Dispose();
                        MaxWidth = Convert.ToInt16(mainfram.Twidth * xPinexCountPerDMM);
                        MaxHeight = Convert.ToInt16(mainfram.Theight * yPinexCountPerDMM);
                        Day_X = mainfram.Day_x;
                        Day_Y = mainfram.Day_y;
                        Time_width = mainfram.Timewidth;
                        Day_Width = mainfram.Daywidth;
                        //ishavemainset = true;
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = "m1";
                        tempnode.Text = "体温单主区域";
                        tempnode.Tag = mainfram;
                        tn.Nodes.Add(tempnode);
                    }
                }
                else if (tn.Name.ToLower() == "vdataset")
                {
                    //获取相同大类设置           
                    foreach (XmlNode temp in XmlDoc.GetElementsByTagName("SymeType"))
                    {
                        SymeType stype = new SymeType();
                        stype.name = temp.Attributes["name"].Value;
                        stype.Val = temp.InnerText;
                        samestyes.Add(stype);

                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = stype.name;
                        tempnode.Text = stype.name;
                        tempnode.Tag = stype;
                        tn.Nodes.Add(tempnode);

                    }
                    //获取区域组合设置集合           
                    foreach (XmlNode temp in XmlDoc.GetElementsByTagName("ClsBlock"))
                    {
                        ClsBlock block = new ClsBlock();
                        block.Name = temp.Attributes["Name"].Value;
                        block.Showtype = temp.Attributes["Showtype"].Value;
                        block.Val = temp.InnerText;
                        blocks.Add(block);
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = block.Name;
                        tempnode.Text = block.Name;
                        tempnode.Tag = block;
                        tn.Nodes.Add(tempnode);
                    }

                    //画线设置
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsLinedata"))
                    {
                        ClsLinedata tempelement = new ClsLinedata();
                        tempelement.Name = tempxmlnode.Attributes["Name"].Value;
                        tempelement.X = Convert.ToSingle(tempxmlnode.Attributes["X"].Value);
                        tempelement.Y = Convert.ToSingle(tempxmlnode.Attributes["Y"].Value);
                        tempelement.Span_x = Convert.ToSingle(tempxmlnode.Attributes["Span_x"].Value);
                        tempelement.Span_y = Convert.ToSingle(tempxmlnode.Attributes["Span_y"].Value);
                        tempelement.Symbolname = tempxmlnode.Attributes["Symbolname"].Value;
                        tempelement.Penid = tempxmlnode.Attributes["Penid"].Value;
                        tempelement.Scale = tempxmlnode.Attributes["Scale"].Value;
                        tempelement.Basevalue = tempxmlnode.Attributes["Basevalue"].Value;
                        tempelement.Broken = tempxmlnode.Attributes["Broken"].Value;
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Name;
                        tempnode.Text = tempelement.Name;
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);

                        listlinedatas.Add(tempelement);
                    }

                    //文字数据设置
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsTextdata"))
                    {
                        ClsTextdata tempelement = new ClsTextdata();

                        tempelement.Name = tempxmlnode.Attributes["Name"].Value;
                        tempelement.X = Convert.ToSingle(tempxmlnode.Attributes["X"].Value);
                        tempelement.Y = Convert.ToSingle(tempxmlnode.Attributes["Y"].Value);
                        tempelement.Twidth = Convert.ToInt16(tempxmlnode.Attributes["Twidth"].Value);
                        tempelement.Theight = Convert.ToInt16(tempxmlnode.Attributes["Theight"].Value);
                        tempelement.Texttype = tempxmlnode.Attributes["Texttype"].Value;
                        tempelement.Tdirection = tempxmlnode.Attributes["Tdirection"].Value;
                        tempelement.Fontid = tempxmlnode.Attributes["Fontid"].Value;
                        tempelement.Align = tempxmlnode.Attributes["Align"].Value;
                        if (tempxmlnode.Attributes["Changecolorfontid"] != null)
                            tempelement.Changecolorfontid = tempxmlnode.Attributes["Changecolorfontid"].Value;
                        else
                            tempelement.Changecolorfontid = "";


                        if (tempxmlnode.Attributes["Changecolorstr"] != null)
                            tempelement.Changecolorstr = tempxmlnode.Attributes["Changecolorstr"].Value;
                        else
                            tempelement.Changecolorstr = "";

                        if (tempxmlnode.Attributes["Positiontype"] != null)
                            tempelement.Positiontype = tempxmlnode.Attributes["Positiontype"].Value;
                        else
                            tempelement.Positiontype = "";
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempelement.Name;
                        tempnode.Text = tempelement.Name;
                        tempnode.Tag = tempelement;
                        tn.Nodes.Add(tempnode);

                        listtextdatas.Add(tempelement);

                    }

                    //组合数据信息
                    foreach (XmlNode tempxmlnode in XmlDoc.GetElementsByTagName("ClsComboData"))
                    {
                        ClsComboData tempComboSymbol = new ClsComboData();
                        tempComboSymbol.name = tempxmlnode.Attributes["name"].Value;
                        tempComboSymbol.combolsymbol = tempxmlnode.Attributes["combolsymbol"].Value;
                        TreeNode tempnode = new TreeNode();
                        tempnode.Name = tempComboSymbol.name;
                        tempnode.Text = tempComboSymbol.name;
                        tempnode.Tag = tempComboSymbol;
                        tn.Nodes.Add(tempnode);
                        listcomboydatas.Add(tempComboSymbol);
                    }
                }
            }
        }

        /// <summary>
        /// 更新XML
        /// </summary>
        /// <param name="operatertype">操作类型 0 添加 1修改</param>
        /// <param name="node">节点</param>
        internal void UpdateXml(int operatertype, TreeNode node, XmlDocument XmlDoc, TreeView trvTemperture)
        {
            if (operatertype == 0)
            {
                #region 添加操作
                //添加
                if (node.Tag.ToString().Contains("ClsPens"))
                {
                    //画笔
                    ClsPens tpen = (ClsPens)node.Tag;


                    XmlElement tn = XmlDoc.CreateElement("ClsPens");
                    tn.SetAttribute("Id", tpen.Id);
                    tn.SetAttribute("Tname", tpen.Tname);
                    tn.SetAttribute("Pensize", tpen.Pensize.ToString());
                    tn.SetAttribute("Pencolor", tpen.Pencolor.R.ToString() + "," +
                                            tpen.Pencolor.G.ToString() + "," +
                                            tpen.Pencolor.B.ToString());
                    XmlDoc.GetElementsByTagName("pens")[0].AppendChild(tn);

                }
                else if (node.Tag.ToString().Contains("ClsFont"))
                {
                    //字体
                    //画笔
                    ClsFont tft = (ClsFont)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsFont");
                    tn.SetAttribute("Id", tft.Id);
                    tn.SetAttribute("Tname", tft.Tname);
                    tn.SetAttribute("Fontname", tft.Fontname);
                    tn.SetAttribute("Fontsize", tft.Fontsize.ToString());
                    tn.SetAttribute("Fontcolor", tft.Fontcolor.R.ToString() + "," +
                                                tft.Fontcolor.G.ToString() + "," +
                                                tft.Fontcolor.B.ToString());
                    tn.SetAttribute("Isbold", tft.Isbold.ToString());
                    tn.SetAttribute("Isunderline", tft.Isunderline.ToString());
                    tn.SetAttribute("Isita", tft.Isita.ToString());
                    XmlDoc.GetElementsByTagName("fonts")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                {
                    //文字             

                    ClsImg tempimg = (ClsImg)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsImg");
                    tn.SetAttribute("Id", tempimg.Id);
                    tn.SetAttribute("Imgname", tempimg.Imgname);
                    //tn.InnerText = GetImgStrByBitmap(tempimg.Img);
                    tn.SetAttribute("X", tempimg.X.ToString());
                    tn.SetAttribute("Y", tempimg.Y.ToString());
                    tn.SetAttribute("Pwidth", tempimg.Pwidth.ToString());
                    tn.SetAttribute("Pheight", tempimg.Pheight.ToString());
                    XmlDoc.GetElementsByTagName("element")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString() == "TempertureEditor.Element.ClsText")
                {
                    //文字             

                    ClsText tft = (ClsText)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsText");
                    tn.SetAttribute("Id", tft.Id);
                    tn.SetAttribute("Fontid", tft.Fontid);
                    tn.InnerText = tft.Vtext;
                    tn.SetAttribute("X", tft.X1.ToString());
                    tn.SetAttribute("Y", tft.Y1.ToString());
                    tn.SetAttribute("Times", tft.Times.ToString());
                    tn.SetAttribute("Spans", tft.Spans.ToString());
                    tn.SetAttribute("Direction", tft.Direction.ToString());
                    tn.SetAttribute("Tdirection", tft.Tdirection.ToString());
                    XmlDoc.GetElementsByTagName("element")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString() == "TempertureEditor.Element.ClsLine")
                {
                    //线             

                    ClsLine tft = (ClsLine)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsLine");
                    tn.SetAttribute("Id", tft.Id);
                    tn.SetAttribute("Penid", tft.Penid);
                    tn.SetAttribute("X1", tft.X1.ToString());
                    tn.SetAttribute("Y1", tft.Y1.ToString());
                    tn.SetAttribute("X2", tft.X2.ToString());
                    tn.SetAttribute("Y2", tft.Y2.ToString());
                    tn.SetAttribute("Times", tft.Times.ToString());
                    tn.SetAttribute("Spans", tft.Spans.ToString());
                    tn.SetAttribute("Direction", tft.Direction.ToString());
                    XmlDoc.GetElementsByTagName("element")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString().Contains("ClsRec"))
                {
                    //区域框
                    ClsRec tft = (ClsRec)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsRec");
                    tn.SetAttribute("Id", tft.Id);
                    tn.SetAttribute("Penid", tft.Penid);
                    tn.SetAttribute("X", tft.Rec.X.ToString());
                    tn.SetAttribute("Y", tft.Rec.Y.ToString());
                    tn.SetAttribute("Width", tft.Rec.Width.ToString());
                    tn.SetAttribute("Height", tft.Rec.Height.ToString());
                    XmlDoc.GetElementsByTagName("element")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString().Contains("ClsMainFrame"))
                {
                    //主区域框
                    ClsMainFrame tft = (ClsMainFrame)node.Tag;
                    //tft.Fontsize
                    XmlElement tn = XmlDoc.CreateElement("ClsMainFrame");
                    tn.SetAttribute("Twidth", tft.Twidth.ToString());
                    tn.SetAttribute("Theight", tft.Theight.ToString());
                    tn.SetAttribute("Day_x", tft.Day_x.ToString());
                    tn.SetAttribute("Day_y", tft.Day_y.ToString());
                    tn.SetAttribute("Daywidth", tft.Daywidth.ToString());
                    tn.SetAttribute("Timewidth", tft.Timewidth.ToString());
                    XmlDoc.GetElementsByTagName("element")[0].AppendChild(tn);
                }
                else if (node.Tag.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    //点线数据类型
                    ClsLinedata tft = (ClsLinedata)node.Tag;
                    //tft.Fontsize

                    XmlElement tn = XmlDoc.CreateElement("ClsLinedata");
                    tn.SetAttribute("Name", tft.Name);
                    tn.SetAttribute("Penid", tft.Penid);
                    tn.SetAttribute("X", tft.X.ToString());
                    tn.SetAttribute("Y", tft.Y.ToString());
                    tn.SetAttribute("Span_x", tft.Span_x.ToString());
                    tn.SetAttribute("Span_y", tft.Span_y.ToString());
                    tn.SetAttribute("Symbolname", tft.Symbolname);
                    tn.SetAttribute("Scale", tft.Scale);
                    tn.SetAttribute("Broken", tft.Broken);
                    tn.SetAttribute("Basevalue", tft.Basevalue);
                    XmlDoc.GetElementsByTagName("vdataset")[0].AppendChild(tn);

                }
                else if (node.Tag.ToString() == "TempertureEditor.Element.ClsTextdata")
                {
                    //文字数据类型
                    //点线数据类型
                    ClsTextdata tft = (ClsTextdata)node.Tag;
                    //tft.Fontsize
                    XmlElement tn = XmlDoc.CreateElement("ClsTextdata");
                    tn.SetAttribute("Name", tft.Name);
                    tn.SetAttribute("Fontid", tft.Fontid);
                    tn.SetAttribute("X", tft.X.ToString());
                    tn.SetAttribute("Y", tft.Y.ToString());
                    tn.SetAttribute("Twidth", tft.Twidth.ToString());
                    tn.SetAttribute("Theight", tft.Theight.ToString());
                    tn.SetAttribute("Texttype", tft.Texttype);
                    tn.SetAttribute("Tdirection", tft.Tdirection);
                    tn.SetAttribute("Align", tft.Align);
                    XmlDoc.GetElementsByTagName("vdataset")[0].AppendChild(tn);
                }

                #endregion
            }
            else
            {
                #region 修改操作
                if (node.Tag != null)
                {

                    //修改               
                    if (node.Tag.ToString().Contains("ClsPens"))
                    {
                        ClsPens tft = (ClsPens)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/pens/ClsPens[@Id='" + node.Name + "']");
                        tn.Attributes["Pencolor"].Value = tft.Pencolor.R.ToString() + "," +
                                                    tft.Pencolor.G.ToString() + "," +
                                                    tft.Pencolor.B.ToString();
                        tn.Attributes["Pensize"].Value = tft.Pensize.ToString();


                    }
                    else if (node.Tag.ToString().Contains("ClsFont"))
                    {
                        ClsFont tft = (ClsFont)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/fonts/ClsFont[@Id='" + node.Name + "']");
                        tn.Attributes["Fontname"].Value = tft.Fontname;
                        tn.Attributes["Fontsize"].Value = tft.Fontsize.ToString();
                        tn.Attributes["Fontcolor"].Value = tft.Fontcolor.R.ToString() + "," +
                                                    tft.Fontcolor.G.ToString() + "," +
                                                    tft.Fontcolor.B.ToString();
                        tn.Attributes["Isbold"].Value = tft.Isbold.ToString();
                        tn.Attributes["Isunderline"].Value = tft.Isunderline.ToString();
                        tn.Attributes["Isita"].Value = tft.Isita.ToString();
                    }
                    else if (node.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                    {
                        ClsImg tempImg = (ClsImg)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/element/ClsImg[@Id='" + node.Name + "']");
                        tn.Attributes["Id"].Value = tempImg.Id;
                        tn.Attributes["X"].Value = tempImg.X.ToString();
                        tn.Attributes["Y"].Value = tempImg.Y.ToString();
                        tn.Attributes["Imgname"].Value = tempImg.Imgname;
                        //tn.InnerText= GetImgStrByBitmap(tempImg.Img);
                        tn.Attributes["Pwidth"].Value = tempImg.Pwidth.ToString();
                        tn.Attributes["Pheight"].Value = tempImg.Pheight.ToString();
                    }
                    else if (node.Tag.ToString() == "TempertureEditor.Element.ClsText")
                    {
                        ClsText tft = (ClsText)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/element/ClsText[@Id='" + node.Name + "']");
                        tn.Attributes["Fontid"].Value = tft.Fontid;
                        tn.Attributes["X"].Value = tft.X1.ToString();
                        tn.Attributes["Y"].Value = tft.Y1.ToString();
                        tn.Attributes["Times"].Value = tft.Times.ToString();
                        tn.Attributes["Spans"].Value = tft.Spans.ToString();
                        tn.Attributes["Direction"].Value = tft.Direction.ToString();
                        tn.Attributes["Tdirection"].Value = tft.Tdirection.ToString();
                        //tn.Attributes["Vtext"].Value = tft.Vtext.ToString();
                        tn.InnerText = tft.Vtext;
                    }
                    else if (node.Tag.ToString() == "TempertureEditor.Element.ClsLine")
                    {
                        ClsLine tft = (ClsLine)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/element/ClsLine[@Id='" + node.Name + "']");
                        tn.Attributes["Penid"].Value = tft.Penid;
                        tn.Attributes["X1"].Value = tft.X1.ToString();
                        tn.Attributes["Y1"].Value = tft.Y1.ToString();
                        tn.Attributes["X2"].Value = tft.X2.ToString();
                        tn.Attributes["Y2"].Value = tft.Y2.ToString();
                        tn.Attributes["Times"].Value = tft.Times.ToString();
                        tn.Attributes["Spans"].Value = tft.Spans.ToString();
                        tn.Attributes["Direction"].Value = tft.Direction.ToString();
                    }
                    else if (node.Tag.ToString().Contains("ClsRec"))
                    {
                        ClsRec tft = (ClsRec)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/element/ClsRec[@Id='" + node.Name + "']");
                        tn.Attributes["Penid"].Value = tft.Penid;
                        tn.Attributes["Penid"].Value = tft.Penid;
                        tn.Attributes["X"].Value = tft.Rec.X.ToString();
                        tn.Attributes["Y"].Value = tft.Rec.Y.ToString();
                        tn.Attributes["Width"].Value = tft.Rec.Width.ToString();
                        tn.Attributes["Height"].Value = tft.Rec.Height.ToString();
                    }
                    else if (node.Tag.ToString().Contains("ClsMainFrame"))
                    {
                        ClsMainFrame tft = (ClsMainFrame)node.Tag;
                        XmlNode tn = XmlDoc.GetElementsByTagName("ClsMainFrame")[0];
                        tn.Attributes["Twidth"].Value = tft.Twidth.ToString();
                        tn.Attributes["Theight"].Value = tft.Theight.ToString();
                        tn.Attributes["Day_x"].Value = tft.Day_x.ToString();
                        tn.Attributes["Day_y"].Value = tft.Day_y.ToString();
                        tn.Attributes["Daywidth"].Value = tft.Daywidth.ToString();
                        tn.Attributes["Timewidth"].Value = tft.Timewidth.ToString();

                        MaxWidth = tft.Twidth;
                        MaxHeight = tft.Theight;
                    }
                    else if (node.Tag.ToString().Contains("ClsData"))
                    {
                        //ClsData tdata = (ClsData)node.Tag;
                        //XmlNode tn = XmlDoc.SelectSingleNode("temperture/vdataset/ClsData[@Id='" + node.Name + "']");
                        //tn.Attributes["Showtext"].Value = tdata.Showtext;

                        //tn.Attributes["X"].Value = tdata.X.ToString();
                        //tn.Attributes["Y"].Value = tdata.Y.ToString();
                        //tn.Attributes["Tdirection"].Value = tdata.Tdirection;
                        //tn.Attributes["Align"].Value = tdata.Align;
                        //tn.Attributes["Val1"].Value = tdata.Val1;
                        //tn.Attributes["Val2"].Value = tdata.Val2;
                        //tn.Attributes["Val3"].Value = tdata.Val3;
                        //tn.Attributes["Span_x"].Value = tdata.Span_x.ToString();
                        //tn.Attributes["Span_y"].Value = tdata.Span_y.ToString();

                        //tn.Attributes["Updowmshow"].Value = tdata.Updowmshow;
                        //tn.Attributes["Datename"].Value = tdata.Datename;
                        //tn.Attributes["IsLink"].Value = tdata.IsLink.ToString();
                        //tn.Attributes["Linkbroken"].Value = tdata.Linkbroken;
                        //tn.Attributes["Fontname"].Value = tdata.Fontname;
                        //tn.Attributes["Fontsize"].Value = tdata.Fontsize;
                        //tn.Attributes["Isunderline"].Value = tdata.Isunderline.ToString();
                        //tn.Attributes["Isbold"].Value = tdata.Isbold.ToString();
                        //tn.Attributes["Isita"].Value = tdata.Isita.ToString();
                        //tn.Attributes["Pensize"].Value = tdata.Pensize.ToString();
                        //tn.Attributes["SColor"].Value = tdata.SColor.ToString();

                        //tn.Attributes["Line_span_x"].Value = tdata.Line_span_x.ToString();
                        //tn.Attributes["Line_span_y"].Value = tdata.Line_span_y.ToString();
                        //tn.Attributes["Updown_span_y"].Value = tdata.Updown_span_y.ToString();
                    }

                    //数据类型                    
                    else if (node.Tag.ToString() == "TempertureEditor.Element.ClsTextdata")
                    {
                        //文字类型
                        ClsTextdata tft = (ClsTextdata)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/vdataset/ClsTextdata[@Name='" + node.Name + "']");
                        tn.Attributes["Tdirection"].Value = tft.Tdirection;
                        tn.Attributes["Fontid"].Value = tft.Fontid;
                        tn.Attributes["Align"].Value = tft.Align;
                        tn.Attributes["Texttype"].Value = tft.Texttype;
                        tn.Attributes["X"].Value = tft.X.ToString();
                        tn.Attributes["Y"].Value = tft.Y.ToString();
                        tn.Attributes["Twidth"].Value = tft.Twidth.ToString();
                        tn.Attributes["Theight"].Value = tft.Theight.ToString();

                    }
                    else if (node.Tag.ToString() == "TempertureEditor.Element.ClsLinedata")
                    {
                        //点线类型
                        ClsLinedata tft = (ClsLinedata)node.Tag;
                        XmlNode tn = XmlDoc.SelectSingleNode("temperture/vdataset/ClsLinedata[@Name='" + node.Name + "']");
                        tn.Attributes["Basevalue"].Value = tft.Basevalue;
                        tn.Attributes["Broken"].Value = tft.Broken;
                        tn.Attributes["Scale"].Value = tft.Scale;
                        tn.Attributes["Span_x"].Value = tft.Span_x.ToString();
                        tn.Attributes["Span_y"].Value = tft.Span_y.ToString();
                        tn.Attributes["Symbolname"].Value = tft.Symbolname;
                        tn.Attributes["X"].Value = tft.X.ToString();
                        tn.Attributes["Y"].Value = tft.Y.ToString();
                        tn.Attributes["Penid"].Value = tft.Penid;
                    }
                }
                #endregion
            }

            XmlDoc.Save(SysXmlfileName);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="xnodes"></param>
        /// <param name="sflag"></param>
        internal  void DelXmlNodeById(string Id, XmlNodeList xnodes, ref bool sflag)
        {
            foreach (XmlNode xnode in xnodes)
            {
                bool ishaveattributes = false;
                if (xnode.Attributes != null)
                {
                    foreach (XmlAttribute tat in xnode.Attributes)
                    {
                        if (tat.Name == "Id")
                        {
                            ishaveattributes = true;
                            break;  //Add by xiao at 2017/3/15
                        }
                    }

                    if (ishaveattributes)
                    {
                        if (xnode.Attributes["Id"].Value.ToString() == Id)
                        {

                            XmlElement xe = (XmlElement)xnode.ParentNode;
                            xe.RemoveChild(xnode);

                            sflag = true;
                            return;
                        }
                    }
                    if (xnode.ChildNodes.Count > 0)
                        DelXmlNodeById(Id, xnode.ChildNodes, ref sflag);
                }
            }

        }

        /// Add by xiao at 2017/3/15
        /// <summary>
        /// 删除节点(通过名称和类型)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        /// <param name="xnodes"></param>
        /// <param name="sflag"></param>
        internal  void DelXmlNodeByName(string name, string tag, XmlNodeList xnodes, ref bool sflag)
        {
            foreach (XmlNode xnode in xnodes)
            {
                bool ishaveattributes = false;
                if (xnode.Attributes != null)
                {
                    foreach (XmlAttribute tat in xnode.Attributes)
                    {
                        if (tat.Name == "Name")
                        {
                            ishaveattributes = true;
                            break;
                        }
                    }

                    if (ishaveattributes)
                    {
                        if (xnode.Attributes["Name"].Value.ToString() == name && tag.Contains(xnode.Name))
                        {

                            XmlElement xe = (XmlElement)xnode.ParentNode;
                            xe.RemoveChild(xnode);

                            sflag = true;
                            return;
                        }
                    }
                    if (xnode.ChildNodes.Count > 0)
                        DelXmlNodeByName(name, tag, xnode.ChildNodes, ref sflag);
                }
            }

        }

        internal  int GetTextWidth(Graphics g, string name, Font f)
        {
            return (int)g.MeasureString(name, f, 1000, System.Drawing.StringFormat.GenericTypographic).Width;
        }

        internal  int GetTextHeight(Graphics g, string name, Font f)
        {
            return (int)g.MeasureString(name, f, 1000, System.Drawing.StringFormat.GenericTypographic).Height;
        }

        /// <summary>
        /// 获取中间点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="twidth"></param>
        /// <param name="theight"></param>
        /// <returns></returns>
        internal  Point GetMidPoint(int x, int y, int twidth, int theight)
        {
            Point midp = new Point(x + twidth / 2, y + theight / 2);
            return midp;
        }

        /// <summary>
        /// 转换中文
        /// </summary>
        /// <param name="Val"></param>
        /// <returns></returns>
        internal string GetChinaStr(string Val)
        {
            string chineseStr = "";
            return chineseStr;
        }

        /// <summary>
        /// 获取测试数据文件初始化xml内容
        /// </summary>
        /// <returns></returns>
        internal  string GetTestDataDefaultContent()
        {
            string oldxml = string.Format("<Tempture> <page Starttime=\"{0} 00:00:00\" Endtime=\"{1} 23:59:59\"></page></Tempture>", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(6).ToString("yyyy-MM-dd"));
            return oldxml;
        }
        internal  string GetTestDataFullName()
        {
            int start = SysXmlfileName.LastIndexOf(".");
            string postfix = SysXmlfileName.Substring(0, start);
            string testFilePath = postfix + "_dataTest.xml";
            return testFilePath;
        }
        /// <summary>
        /// 获取测试数据页集合
        /// </summary>
        internal  void GetTestPages()
        {
            Pages.Clear();
            XmlDocument testXMl = new XmlDocument();

            string testDataFullName = GetTestDataFullName();

            if (!File.Exists(testDataFullName))
            {

                testXMl.LoadXml(GetTestDataDefaultContent());
                testXMl.Save(testDataFullName);
            }
            else
            {
                testXMl.Load(testDataFullName);
            }


            XmlNodeList nodes = testXMl.GetElementsByTagName("page");
            object typeobj;
            //获取所有的页
            foreach (XmlNode tempelement in nodes)
            {
                Page temppage = new Page();
                temppage.Starttime = tempelement.Attributes["Starttime"].Value;
                temppage.Endtime = tempelement.Attributes["Endtime"].Value;
                temppage.Objs = new List<ClsDataObj>();  //对象集合
                foreach (XmlNode tempobjelement in tempelement.ChildNodes)
                {
                    ClsDataObj tojb = new ClsDataObj(this);                                
                    tojb.Typename = tempobjelement.Attributes["clsdate"].Value;
                    tojb.Rdatatime = tempobjelement.Attributes["rdatetime"].Value;
                    tojb.Val = tempobjelement.InnerText;
                    tojb.setdataxy(temppage.Starttime); //设置相关坐标
                    temppage.Objs.Add(tojb);



                }
                Pages.Add(temppage);
            }

            resetSpecialObjectsXY(Pages[0]);
        }

        /// <summary>
        /// 特殊体温单坐标处理
        /// </summary>
        /// <param name="currentpage"></param>
        public void resetSpecialObjectsXY(Page currentpage)
        {
            listWriteTimes.Clear();
            #region 特殊体温单 插入时间集合判断时间点是否已经存在
            if (Day_Width == Time_width)
            {
                foreach (ClsDataObj tojb in currentpage.Objs)
                {
                    if (tojb.Rdatatime.Trim() != "")
                    {
                        bool tflag = false;
                        for (int i = 0; i < listWriteTimes.Count; i++)
                        {
                            if (listWriteTimes[i] == tojb.Rdatatime)
                            {
                                //如果有相同的值
                                tflag = true;
                                break;
                            }

                        }
                        if (!tflag)
                            listWriteTimes.Add(tojb.Rdatatime); //没有出现过添加
                    }
                }

                //特殊体温单处理--获取时间点集合
                string tempstr = "";
                for (int i = 0; i < listWriteTimes.Count - 1; i++)
                {

                    for (int j = 0; j < listWriteTimes.Count - 1 - i; j++)
                    {
                        if (Convert.ToDateTime(listWriteTimes[j]) > Convert.ToDateTime(listWriteTimes[j + 1]))
                        {
                            tempstr = listWriteTimes[j + 1];
                            listWriteTimes[j + 1] = listWriteTimes[j];
                            listWriteTimes[j] = tempstr;
                        }
                    }

                }

                foreach (ClsDataObj tojb in currentpage.Objs)
                {
                    SetDrawDayTimePoint(listWriteTimes.ToArray(), tojb);
                }


                foreach (ClsDataObj tojb in currentpage.Objs)
                {
                    if (tojb.Typename == "日期" &&
                        tojb.Val.Trim() != "")
                    {
                        foreach (ClsDataObj tojbtep in currentpage.Objs)
                        {
                            if (
                               tojbtep.Typename.Contains("大便次数") ||
                               tojbtep.Typename.Contains("小便次数") ||
                               tojbtep.Typename.Contains("尿量") ||
                               tojbtep.Typename.Contains("体重") ||
                               tojbtep.Typename.Contains("其他"))
                            {
                                if (Convert.ToDateTime(tojbtep.Rdatatime).ToString("yyyy-MM-dd") == tojb.Val)
                                {
                                    tojbtep.X = tojb.X;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }




        /// <summary>
        ///  根据时间获取天坐标  正常体温单
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="datestr"></param>
        /// <param name="clsobj"></param>    
        public  void SetDrawDayTimePoint(string starttime, string datestr, ClsDataObj clsobj)
        {
            try
            {
                Point pt = new Point(0, 0);
                DateTime tempDate = Convert.ToDateTime(datestr);
                DateTime StartDate = Convert.ToDateTime(starttime);

                bool bVariablePosition = false;
                int dayindex = 0;
                TimeSpan st = tempDate.Subtract(StartDate);
                dayindex = st.Days;

                object typeobj = GetVDataSetByName(clsobj.Typename);
                if (typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                {
                    ClsTextdata tempcls = (ClsTextdata)typeobj;
                    clsobj.X = tempcls.X + dayindex * Day_Width;
                    if (tempcls.Positiontype == "按天位移")
                        bVariablePosition = false;
                    else
                        bVariablePosition = true;

                }
                else if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                {
                    ClsLinedata tempcls = (ClsLinedata)typeobj;
                    clsobj.X = tempcls.X + dayindex * Day_Width;
                    float spance = Convert.ToSingle(clsobj.Val) - Convert.ToSingle(tempcls.Basevalue);
                    clsobj.Y = clsobj.Y - spance * Convert.ToSingle(tempcls.Scale);
                    bVariablePosition = true;
                }
                if (bVariablePosition)
                {
                    int k = 0;
                    DateTime dtTmp;
                    for (; k < listWriteTimes.Count; k++)
                    {
                        string text = listWriteTimes[k];
                        if (text == "24:00")
                        {
                            text = "00:00";
                        }
                        dtTmp = DateTime.Parse(tempDate.ToString("yy-MM-dd") + " " + text);
                        if (dtTmp == tempDate)
                            break;
                    }
                    if (k < listWriteTimes.Count)
                    {
                        //计算时间点偏移坐标
                        clsobj.X += k * Time_width/* + Time_width / 2*/;
                    }
                }
            }
            catch
            { }
        }


        /// <summary>
        ///  根据时间获取天坐标  正常体温单
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="datestr"></param>
        /// <param name="clsobj"></param>    
        public  void SetDrawDayTimePoint(string[] timestrs, ClsDataObj clsobj)
        {
            try
            {
                //吉林版非正常体温单
                if (Day_Width == Time_width)
                {
                    /*
                     * 吉林时间点21列
                     */
                    int timeindex = 0;
                    for (int i = 0; i < timestrs.Length; i++)
                    {

                        Point pt = new Point(0, 0);
                        timeindex = i;
                        //clsobj.X = Day_X + timeindex; //天所在位置
                        if (timestrs[i] == clsobj.Rdatatime)
                        {
                            object typeobj = GetVDataSetByName(clsobj.Typename);
                            if (typeobj.ToString() == "TempertureEditor.Element.ClsTextdata")
                            {
                                ClsTextdata tempcls = (ClsTextdata)typeobj;
                                clsobj.X = tempcls.X + timeindex * Time_width;

                            }
                            else if (typeobj.ToString() == "TempertureEditor.Element.ClsLinedata")
                            {
                                ClsLinedata tempcls = (ClsLinedata)typeobj;
                                clsobj.X = tempcls.X + timeindex * Time_width;
                                float spance = Convert.ToSingle(clsobj.Val) - Convert.ToSingle(tempcls.Basevalue);
                                clsobj.Y = clsobj.Y - spance * Convert.ToSingle(tempcls.Scale);

                            }
                        }
                    }
                }
            }
            catch
            { }
        }




        /// <summary>
        /// 将数字转换为天数
        /// </summary>
        /// <param name="number"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string NumForChinese(int number, int type)
        {
            string returnTime = "";
            if (number < 10)
            {
                if (type == 1)
                {
                    returnTime = "零";
                }
                if (number == 0)
                {
                    returnTime = "零";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "一";
                            break;
                        case 2:
                            returnTime += "二";
                            break;
                        case 3:
                            returnTime += "三";
                            break;
                        case 4:
                            returnTime += "四";
                            break;
                        case 5:
                            returnTime += "五";
                            break;
                        case 6:
                            returnTime += "六";
                            break;
                        case 7:
                            returnTime += "七";
                            break;
                        case 8:
                            returnTime += "八";
                            break;
                        case 9:
                            returnTime += "九";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "十";
                        break;
                    case 2:
                        returnTime = "二十";
                        break;
                    case 3:
                        returnTime = "三十";
                        break;
                    case 4:
                        returnTime = "四十";
                        break;
                    case 5:
                        returnTime = "五十";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "一";
                        break;
                    case 2:
                        returnTime += "二";
                        break;
                    case 3:
                        returnTime += "三";
                        break;
                    case 4:
                        returnTime += "四";
                        break;
                    case 5:
                        returnTime += "五";
                        break;
                    case 6:
                        returnTime += "六";
                        break;
                    case 7:
                        returnTime += "七";
                        break;
                    case 8:
                        returnTime += "八";
                        break;
                    case 9:
                        returnTime += "九";
                        break;
                }
            }
            return returnTime;
        }

        /// <summary>
        /// 获取标签信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public  ClsSymbol getClsSymbolByName(string name)
        {
            foreach (ClsSymbol tempsymbol in listsymbols)
            {
                if (name == tempsymbol.name)
                {
                    return tempsymbol;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据名称返回数据设置类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetVDataSetByName(string name)
        {
            try
            {
                object tempobj = null;
                foreach (ClsLinedata tempclass in listlinedatas)
                {
                    if (tempclass.Name == name)
                    {
                        tempobj = tempclass;
                        return tempobj;
                    }
                }

                foreach (ClsTextdata tempclass in listtextdatas)
                {
                    if (tempclass.Name == name)
                    {
                        tempobj = tempclass;
                        return tempobj;
                    }
                }
                return tempobj;
            }
            catch
            {
                return null;
            }
        }

        public  void GetVDataXY(ClsDataObj tempobj)
        {
            if (tempobj.Typename != "" && tempobj.Typename != null)
            {
                object typeobj = GetVDataSetByName(tempobj.Typename);
                if (typeobj.ToString().Contains("ClsLinedata"))
                {
                    ClsLinedata tempc = (ClsLinedata)typeobj;
                    tempobj.X = tempc.X;
                    tempobj.Y = tempc.Y;
                }
                else if (typeobj.ToString().Contains("ClsTextdata"))
                {
                    ClsTextdata tempc = (ClsTextdata)typeobj;
                    tempobj.X = tempc.X;
                    tempobj.Y = tempc.Y;
                }


            }
        }

        /// <summary>
        /// 获取图片二进制字符串
        /// </summary>
        /// <returns></returns>
        public static string GetImgStrByBitmap(Bitmap bmp)
        {
            try
            {
                string textString = "";
                //FileStream fileStream = new FileStream(imgpath, FileMode.Open);
                //BinaryReader binaryReader = new BinaryReader(fileStream);
                //byte[] imageBuffer = new byte[binaryReader.BaseStream.Length];
                //binaryReader.Read(imageBuffer, 0, Convert.ToInt32(binaryReader.BaseStream.Length));
                //string textString = System.Convert.ToBase64String(imageBuffer);
                //fileStream.Close();
                //binaryReader.Close();

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Flush();
                byte[] bmpBytes = ms.ToArray();
                //foreach (var item in bmpBytes)
                //{
                //    textString += item;
                //}



                textString = Convert.ToBase64String(bmpBytes);
                return textString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取图片二进制失败！" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>        
        /// 根据二进制获取图片
        /// </summary>
        /// <param name="bytestr"></param>
        /// <returns></returns>
        public static Bitmap getImgBybytes(string bytestr)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(bytestr);
                Bitmap img = (Bitmap)Image.FromStream(new MemoryStream(byteArray));
                return img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取图片失败！" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// 按照比例缩放图片
        /// </summary>
        /// <param name="b"></param>
        /// <param name="destWidth"></param>
        /// <param name="destHeight"></param>
        /// <returns></returns>
        public  Bitmap GetThumbnail(Bitmap b, int destWidth, int destHeight)
        {
            try
            {
                System.Drawing.Image imgSource = b;
                System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
                int sW = 0, sH = 0;
                // 按比例缩放           
                int sWidth = imgSource.Width;
                int sHeight = imgSource.Height;
                if (sHeight > destHeight || sWidth > destWidth)
                {
                    if ((sWidth * destHeight) > (sHeight * destWidth))
                    {
                        sW = destWidth;
                        sH = (destWidth * sHeight) / sWidth;
                    }
                    else
                    {
                        sH = destHeight;
                        sW = (sWidth * destHeight) / sHeight;
                    }
                }
                else
                {
                    sW = sWidth;
                    sH = sHeight;
                }
                Bitmap outBmp = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage(outBmp);
                g.Clear(Color.Transparent);
                // 设置画布的描绘质量         
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
                g.Dispose();
                // 以下代码为保存图片时，设置压缩质量     
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                imgSource.Dispose();
                return outBmp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 是否是数值类型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool isfloattype(string val)
        {
            try
            {
                Convert.ToSingle(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///Add by xiao at 2017/3/15
        /// <summary>
        /// 判断xml中是否存在指定元素的相同属性name
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="xnodes"></param>
        internal  bool IsExistsNodeName(string element, string name, XmlNodeList xnodes)
        {
            foreach (XmlNode xnode in xnodes)
            {
                bool ishaveattributes = false;
                if (xnode.Attributes != null)
                {
                    foreach (XmlAttribute tat in xnode.Attributes)
                    {
                        if (tat.Name == "Name")
                        {
                            ishaveattributes = true;
                            break;
                        }
                    }

                    if (ishaveattributes)
                    {
                        if (xnode.Attributes["Name"].Value.ToString() == name && element == xnode.Name)
                        {
                            return true;
                        }
                    }
                    if (xnode.ChildNodes.Count > 0)
                        if (IsExistsNodeName(element, name, xnode.ChildNodes))
                            return true;
                }
            }
            return false;
        }
    }
}