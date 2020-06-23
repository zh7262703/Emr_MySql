using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using TempertureEditor.Controls;
using System.IO;
using TempertureEditor.Element;
using Bifrost;

namespace TempertureEditor
{
    public partial class ucTempertureEditor : UserControl
    {
        private Point p1, p2; //定义两个点（启点，终点） 
        private bool tdrag = false; //拖拽标志 
        PrintTp printTp;  //体温单绘制对象

        private string _strTip;  //数据提示信息 
        private Point _ptTip;   //数据提示信息显示坐标
        public Comm cm = new Comm();

        public ucTempertureEditor()
        {
            InitializeComponent();
            cm.OrignalTree = new TreeView(); //获取最原始节点

            cm.OrignalTree.Nodes.Clear();
            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                cm.OrignalTree.Nodes.Add((TreeNode)tn.Clone());
            }
            cm.SysXmlfileName = App.SysPath + "\\TempertureSet_newTable.tmb";
            cm.SysXmlTempfileName = App.SysPath + "\\TempertureSet_newTable_tmp.tmb";
            if (!File.Exists(cm.SysXmlfileName))
            {
                File.Delete(cm.GetTestDataFullName());//删除旧的测试数据文件，避免新模板加载失败。
                cm.XmlDoc.LoadXml(TempertureEditor.Properties.Resources.TempertureSet_new);
                cm.XmlDoc.Save(cm.SysXmlfileName);
            }
            else
            {
                cm.XmlDoc.Load(cm.SysXmlfileName);
            }
            printTp = new PrintTp();
            printTp.cm = cm;
            cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
            printTp.EditColor = Color.CadetBlue;
            refleshioc();
            cm.GetTestPages();
        }

        /// <summary>
        /// 整体调整位置
        /// </summary>
        /// <param name="span_rx"></param>
        /// <param name="span_ry"></param>
        /// <param name="isSelectNode"></param>
        private void AllElementReLocation(int span_rx, int span_ry, bool isSelectNode)
        {
            try
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    foreach (TreeNode tnelement in tn.Nodes)
                    {
                        //元素集合

                        if (isSelectNode)
                        {
                            if (trvTemperture.SelectedNode != null)
                            {
                                if (tnelement.Name != trvTemperture.SelectedNode.Name)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (tn.Name == "element")
                        {

                            if (tnelement.Tag.ToString().Contains("ClsRec"))
                            {
                                ClsRec temp = (ClsRec)tnelement.Tag;
                                Rectangle rec = new Rectangle(temp.Rec.X + span_rx, temp.Rec.Y + span_ry, temp.Rec.Width, temp.Rec.Height);
                                temp.Rec = rec;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsText")
                            {
                                ClsText temp = (ClsText)tnelement.Tag;
                                temp.X1 = temp.X1 + span_rx;
                                temp.Y1 = temp.Y1 + span_ry;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsLine")
                            {
                                ClsLine temp = (ClsLine)tnelement.Tag;
                                temp.X1 = temp.X1 + span_rx;
                                temp.Y1 = temp.Y1 + span_ry;
                                temp.X2 = temp.X2 + span_rx;
                                temp.Y2 = temp.Y2 + span_ry;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                            {
                                ClsImg temp = (ClsImg)tnelement.Tag;
                                temp.X = temp.X + span_rx;
                                temp.Y = temp.Y + span_ry;

                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }

                        }
                        else if (tn.Name == "vdataset")
                        {

                            if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsLinedata")
                            {
                                ClsLinedata temp = (ClsLinedata)tnelement.Tag;
                                temp.X = temp.X + span_rx;
                                temp.Y = temp.Y + span_ry;

                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                                //cm.GetTestPages();

                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsTextdata")
                            {
                                ClsTextdata temp = (ClsTextdata)tnelement.Tag;
                                temp.X = temp.X + span_rx;
                                temp.Y = temp.Y + span_ry;

                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                                //cm.GetTestPages();
                            }

                        }

                    }

                }
                if (trvTemperture.SelectedNode != null)
                    propertyGrid1.SelectedObject = trvTemperture.SelectedNode.Tag;
                cm.GetTestPages();
                this.picTemperatureShow.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 整体居中对齐
        /// </summary>
        /// <param name="isSelectNode"></param>
        private void AllElementAlignCenter(bool bHorAlign, bool bVerAlign, bool isSelectNode)
        {
            int rx = 0;
            int ry = 0;
            Graphics g = picTemperatureShow.CreateGraphics();
            try
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    foreach (TreeNode tnelement in tn.Nodes)
                    {
                        //元素集合

                        if (isSelectNode)
                        {
                            if (trvTemperture.SelectedNode != null)
                            {
                                if (tnelement.Name != trvTemperture.SelectedNode.Name)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                        else
                        {
                            //当前框架不好做整体居中，所以整体居中以目前唯一的矩形区域ClsRec为参照物，调整其他元素的坐标。
                            //存在的问题是：如标题已经居中，需在整体调整居中后，再次单独调整居中处理
                            if (tn.Name != "element" || !tnelement.Tag.ToString().Contains("ClsRec"))
                            {
                                continue;
                            }
                        }

                        if (tn.Name == "element")
                        {

                            if (tnelement.Tag.ToString().Contains("ClsRec"))
                            {
                                ClsRec temp = (ClsRec)tnelement.Tag;

                                if (bHorAlign)
                                    rx = (cm.MaxWidth - temp.Rec.Width) / 2;
                                else
                                    rx = temp.Rec.X;
                                if (bVerAlign)
                                    ry = (cm.MaxHeight - temp.Rec.Height) / 2;
                                else
                                    ry = temp.Rec.Y;
                                int span_rx = rx - temp.Rec.X;
                                int span_ry = ry - temp.Rec.Y;
                                AllElementReLocation(span_rx, span_ry, false);
                                return;
                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsText")
                            {
                                ClsText temp = (ClsText)tnelement.Tag;
                                int width = cm.GetTextWidth(g, temp.Vtext, cm.GetFontById(temp.Fontid));
                                int height = cm.GetTextHeight(g, temp.Vtext, cm.GetFontById(temp.Fontid));

                                if (bHorAlign)
                                    temp.X1 = (cm.MaxWidth - width) / 2;
                                if (bVerAlign)
                                    temp.Y1 = (cm.MaxHeight - height) / 2;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                            else if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                            {
                                ClsImg temp = (ClsImg)tnelement.Tag;
                                if (bHorAlign)
                                    temp.X = (cm.MaxWidth - temp.Pwidth) / 2;
                                if (bVerAlign)
                                    temp.Y = (cm.MaxHeight - temp.Pheight) / 2;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                        }
                        else if (tn.Name == "vdataset")
                        {
                            if (tnelement.Tag.ToString() == "TempertureEditor.Element.ClsTextdata")
                            {
                                ClsTextdata temp = (ClsTextdata)tnelement.Tag;

                                if (bHorAlign)
                                    temp.X = (cm.MaxWidth - temp.Twidth) / 2;
                                if (bVerAlign)
                                    temp.Y = (cm.MaxHeight - temp.Theight) / 2;
                                tnelement.Tag = temp;
                                cm.UpdateXml(1, tnelement, cm.XmlDoc, trvTemperture);
                            }
                        }
                    }

                }
                if (trvTemperture.SelectedNode != null)
                    propertyGrid1.SelectedObject = trvTemperture.SelectedNode.Tag;
                cm.GetTestPages();
                this.picTemperatureShow.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            cm.UpdateXml(1, trvTemperture.SelectedNode, cm.XmlDoc, trvTemperture);
            trvTemperture.Nodes.Clear();
            cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
            refleshioc();
            cm.GetTestPages();
            
            this.picTemperatureShow.Width = cm.MaxWidth;
            this.picTemperatureShow.Height = cm.MaxHeight;
            picTemperatureShow.Refresh();
        }

        private void ucTempertureEditor_Load(object sender, EventArgs e)
        {
            this.picTemperatureShow.Left = 0;
            this.picTemperatureShow.Top = 0;


            this.picTemperatureShow.Width = cm.MaxWidth;
            this.picTemperatureShow.Height = cm.MaxHeight;
            this.picTemperatureShow.Refresh();


        }

        /// <summary>
        /// 刷新树节点的图标
        /// </summary>
        private void refleshioc()
        {

            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                foreach (TreeNode temp in tn.Nodes)
                {
                    if (tn.Name.ToLower() == "element")
                    {
                        if (temp.Tag.ToString().Contains("ClsText"))
                        {
                            temp.ImageIndex = 0;
                            temp.SelectedImageIndex = 0;
                        }
                        else if (temp.Tag.ToString().Contains("ClsImg"))
                        {
                            temp.ImageIndex = 10;
                            temp.SelectedImageIndex = 10;
                        }
                        else if (temp.Tag.ToString().Contains("ClsRec"))
                        {
                            temp.ImageIndex = 7;
                            temp.SelectedImageIndex = 7;
                        }
                        else if (temp.Tag.ToString().Contains("ClsLine"))
                        {
                            temp.ImageIndex = 6;
                            temp.SelectedImageIndex = 6;
                        }
                        else if (temp.Tag.ToString().Contains("ClsMainFrame"))
                        {
                            temp.ImageIndex = 9;
                            temp.SelectedImageIndex = 9;
                        }
                    }
                    if (tn.Name.ToLower() == "vdataset")
                    {
                        if (temp.Tag.ToString() == "TempertureEditor.Element.ClsLinedata")
                        {
                            temp.ImageIndex = 13;
                            temp.SelectedImageIndex = 13;
                        }
                        else if (temp.Tag.ToString() == "TempertureEditor.Element.ClsTextdata")
                        {
                            temp.ImageIndex = 14;
                            temp.SelectedImageIndex = 14;
                        }
                        else if (temp.Tag.ToString() == "TempertureEditor.Element.SymeType")
                        {
                            temp.ImageIndex = 15;
                            temp.SelectedImageIndex = 15;
                        }
                        else if (temp.Tag.ToString() == "TempertureEditor.Element.ClsComboData")
                        {
                            temp.ImageIndex = 16;
                            temp.SelectedImageIndex = 16;
                        }
                    }

                }
            }

            //元素展开
            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                foreach (TreeNode temp in tn.Nodes)
                {
                    if (tn.Name.ToLower() == "element")
                    { tn.ExpandAll(); }
                }
            }
        }


        private void trvTemperture_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null)
                {
                    propertyGrid1.SelectedObject = e.Node.Tag;
                    this.picTemperatureShow.Refresh();
                }
            }
            catch
            { }
        }

        private void picTemperatureShow_Paint(object sender, PaintEventArgs e)
        {
            // 每0.1毫米多少个像素(丝米)
            double cxLogPixPerDMM = e.Graphics.DpiX / 254.0;
            double cyLogPixPerDMM = e.Graphics.DpiY / 254.0;

            //A4纸大小（2100*2970丝米）
            picTemperatureShow.Width = cm.MaxWidth;
            picTemperatureShow.Height = cm.MaxHeight + 100;
            cm.CurrentTree = trvTemperture; //获取当前树控件           
            printTp.TemperturePaintInternal(e.Graphics, trvTemperture.SelectedNode, cm.Pages[0], true);

            //实现类似tooltip样式效果
            if (null != _strTip && "" != _strTip)
            {
                Font ftTip;   //数据提示信息字体
                ftTip = new Font("宋体", 12);   //创建数据提示信息字体
                e.Graphics.DrawString(_strTip, ftTip, Brushes.Black, _ptTip);
                ftTip.Dispose();
            }
        }


        #region 菜单操作
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            添加ToolStripMenuItem.Enabled = false;
            画线ToolStripMenuItem.Enabled = false;
            添加文字ToolStripMenuItem.Enabled = false;
            创建主边框ToolStripMenuItem.Enabled = false;
            添加矩形区域ToolStripMenuItem.Enabled = false;
            添加图片ToolStripMenuItem.Enabled = false;


            if (trvTemperture.SelectedNode.Tag == null)
            {

                if (trvTemperture.SelectedNode.Name == "element")
                {

                    XmlNodeList mainnodes = cm.XmlDoc.GetElementsByTagName("ClsMainFrame");
                    if (mainnodes.Count > 0)
                    {
                        // 已经存在主区域设置
                        画线ToolStripMenuItem.Enabled = true;
                        添加文字ToolStripMenuItem.Enabled = true;
                        添加矩形区域ToolStripMenuItem.Enabled = true;
                        添加图片ToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        创建主边框ToolStripMenuItem.Enabled = true;
                    }
                }
                else if (trvTemperture.SelectedNode.Name == "pens" ||
                    trvTemperture.SelectedNode.Name == "fonts")
                {
                    添加ToolStripMenuItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string obId = "";
                cm.newnode = null;
                if (trvTemperture.SelectedNode.Name == "fonts")
                {
                    //添加字体
                    obId = "f" + Convert.ToString(cm.getGenid());
                    frmFontSet fc = new frmFontSet(obId, ref this.cm);
                    fc.ShowDialog();
                }
                else if (trvTemperture.SelectedNode.Name == "pens")
                {

                    //添加画笔
                    obId = "p" + Convert.ToString(cm.getGenid());
                    frmPensSet fc = new frmPensSet(obId, ref cm);
                    fc.ShowDialog();
                }
                if (cm.newnode != null)
                {
                    trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());
                    cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);


                    if (cm.newnode.Tag.ToString().Contains("ClsPens"))
                    {
                        ClsPens temppen = (ClsPens)cm.newnode.Tag;
                        cm.listpens.Add(temppen);
                    }
                    else if (cm.newnode.Tag.ToString().Contains("ClsFont"))
                    {
                        ClsFont temppen = (ClsFont)cm.newnode.Tag;
                        cm.listfonts.Add(temppen);
                    }
                }


            }
            catch
            {

            }
        }


        private void 画线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmLineSet fc = new frmLineSet("l" + Convert.ToString(cm.getGenid()), ref cm);
            fc.ShowDialog();

            if (cm.newnode != null)
            {
                trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }

        }

        private void 创建主边框ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainSet fc = new frmMainSet();
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());

                ClsMainFrame tem = (ClsMainFrame)cm.newnode.Tag;
                cm.MaxWidth = tem.Twidth;
                cm.MaxHeight = tem.Theight;
                this.picTemperatureShow.Width = tem.Twidth;
                this.picTemperatureShow.Height = tem.Theight;

                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        private void 添加矩形区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmRecSet fc = new frmRecSet("r" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        private void 添加图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm.newnode = null;

            frmImgSet fc = new frmImgSet("img" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        private void 添加文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmTextSet fc = new frmTextSet("t" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                trvTemperture.SelectedNode.Nodes.Add((TreeNode)cm.newnode.Clone());
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        /// <summary>
        /// 删除所选择的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除对象ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbtnDel_Click(sender, e);
        }
        #endregion

        private void picTemperatureShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (trvTemperture.SelectedNode != null)
                if (trvTemperture.SelectedNode.Tag != null)
                    cm.UpdateXml(1, trvTemperture.SelectedNode, cm.XmlDoc, trvTemperture);
            tdrag = false;
        }

        private void picTemperatureShow_MouseMove(object sender, MouseEventArgs e)
        {
            _strTip = "";
            _ptTip = new Point(e.X + 10, e.Y);
            tlbllocation.Text = "当前鼠标坐标:" + "X：" + e.X.ToString() + "     Y：" + e.Y.ToString();
            if (tdrag)
            {
                int spanx = e.X - p1.X;
                int spany = e.Y - p1.Y;
                try
                {
                    if (trvTemperture.SelectedNode.Tag != null)
                    {
                        if (trvTemperture.SelectedNode.Tag.ToString() == "TempertureEditor.Element.ClsRec")
                        {
                            ClsRec temp = (ClsRec)trvTemperture.SelectedNode.Tag;
                            Rectangle rec = new Rectangle(temp.Rec.X + spanx, temp.Rec.Y + spany, temp.Rec.Width, temp.Rec.Height);
                            temp.Rec = rec;
                            trvTemperture.SelectedNode.Tag = temp;
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString() == "TempertureEditor.Element.ClsLine")
                        {
                            ClsLine temp = (ClsLine)trvTemperture.SelectedNode.Tag;
                            temp.X1 = temp.X1 + spanx;
                            temp.Y1 = temp.Y1 + spany;
                            temp.X2 = temp.X2 + spanx;
                            temp.Y2 = temp.Y2 + spany;
                            trvTemperture.SelectedNode.Tag = temp;
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString() == "TempertureEditor.Element.ClsText")
                        {
                            ClsText temp = (ClsText)trvTemperture.SelectedNode.Tag;
                            temp.X1 = temp.X1 + spanx;
                            temp.Y1 = temp.Y1 + spany;
                            trvTemperture.SelectedNode.Tag = temp;
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString() == "TempertureEditor.Element.ClsText")
                        {
                            ClsText temp = (ClsText)trvTemperture.SelectedNode.Tag;
                            temp.X1 = temp.X1 + spanx;
                            temp.Y1 = temp.Y1 + spany;
                            trvTemperture.SelectedNode.Tag = temp;
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString() == "TempertureEditor.Element.ClsImg")
                        {
                            ClsImg temp = (ClsImg)trvTemperture.SelectedNode.Tag;
                            temp.X = temp.X + spanx;
                            temp.Y = temp.Y + spany;
                            trvTemperture.SelectedNode.Tag = temp;
                        }
                        this.propertyGrid1.SelectedObject = trvTemperture.SelectedNode.Tag;
                    }
                }
                catch
                {

                }
                p1.X = e.X;
                p1.Y = e.Y;
                this.picTemperatureShow.Refresh();
            }
            else
            {
                foreach (Page page in cm.Pages)
                {
                    foreach (ClsDataObj obj in page.Objs)
                    {
                        //if(obj.Typename== "TempertureEditor.Element.ClsLinedata")
                        object objtype = cm.GetVDataSetByName(obj.Typename);
                        if (objtype == null)
                            continue;
                        if (objtype.ToString() == "TempertureEditor.Element.ClsLinedata")
                        {
                            ClsLinedata lindedata = (ClsLinedata)objtype;
                            ClsSymbol symbol = cm.getClsSymbolByName(lindedata.Symbolname);
                            if (symbol != null)
                            {
                                Rectangle rc = new Rectangle((int)obj.X, (int)obj.Y, Convert.ToInt32(symbol.fontsize) + symbol.cx, Convert.ToInt32(symbol.fontsize) + symbol.cy);
                                if (rc.Contains(e.X, e.Y))
                                {
                                    _strTip = obj.Val.ToString();
                                    break;
                                }
                            }
                        }


                    }
                }
                picTemperatureShow.Refresh();
            }
        }

        private void toolbtnPrintShow_Click(object sender, EventArgs e)
        {
            frmPrint fc = new frmPrint(this.cm);
            fc.ShowDialog();

            trvTemperture.Nodes.Clear();
            cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
            refleshioc();
            cm.GetTestPages();

            this.picTemperatureShow.Width = cm.MaxWidth;
            this.picTemperatureShow.Height = cm.MaxHeight;
            picTemperatureShow.Refresh();

        }

        private void picTemperatureShow_MouseLeave(object sender, EventArgs e)
        {
            tlbllocation.Text = "当前鼠标坐标:";
        }

        private void picTemperatureShow_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = new System.Drawing.Point(e.X, e.Y);
            tdrag = true;
        }

        #region 树快捷工具栏操作

        private void tbtnAddPen_Click(object sender, EventArgs e)
        {
            string obId = "";
            cm.newnode = null;

            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                if (tn.Name == "pens")
                {
                    //添加画笔
                    obId = "p" + Convert.ToString(cm.getGenid());
                    frmPensSet fc = new frmPensSet(obId, ref cm);
                    fc.ShowDialog();
                }
            }

            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "pens")
                    {
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }

                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);


                if (cm.newnode.Tag.ToString().Contains("ClsPens"))
                {
                    ClsPens temppen = (ClsPens)cm.newnode.Tag;
                    cm.listpens.Add(temppen);
                }
                else if (cm.newnode.Tag.ToString().Contains("ClsFont"))
                {
                    ClsFont temppen = (ClsFont)cm.newnode.Tag;
                    cm.listfonts.Add(temppen);
                }
            }
        }

        private void tbtnFont_Click(object sender, EventArgs e)
        {
            string obId = "";
            cm.newnode = null;

            foreach (TreeNode tn in trvTemperture.Nodes)
            {
                if (tn.Name == "fonts")
                {
                    //添加字体
                    obId = "f" + Convert.ToString(cm.getGenid());
                    frmFontSet fc = new frmFontSet(obId, ref this.cm);
                    fc.ShowDialog();
                }
            }

            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "fonts")
                    {
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }

                }



                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);


                if (cm.newnode.Tag.ToString().Contains("ClsPens"))
                {
                    ClsPens temppen = (ClsPens)cm.newnode.Tag;
                    cm.listpens.Add(temppen);
                }
                else if (cm.newnode.Tag.ToString().Contains("ClsFont"))
                {
                    ClsFont temppen = (ClsFont)cm.newnode.Tag;
                    cm.listfonts.Add(temppen);
                }
            }
        }

        private void tbtnAddLine_Click(object sender, EventArgs e)
        {
            cm.newnode = null;


            frmLineSet fc = new frmLineSet("l" + Convert.ToString(cm.getGenid()), ref cm);
            fc.ShowDialog();

            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "element")
                    {
                        cm.newnode.ImageIndex = 6;
                        cm.newnode.SelectedImageIndex = 6;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }

                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        private void tbtnAddRec_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmRecSet fc = new frmRecSet("r" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "element")
                    {
                        cm.newnode.ImageIndex = 7;
                        cm.newnode.SelectedImageIndex = 7;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }
                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }



        private void tbtnAddText_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmTextSet fc = new frmTextSet("t" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "element")
                    {
                        cm.newnode.ImageIndex = 0;
                        cm.newnode.SelectedImageIndex = 0;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }
                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }

        /// <summary>
        /// 添加数据设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnAddDataType_Click(object sender, EventArgs e)
        {
            //cm.newnode = null;
            //int count = 0;
            //foreach (TreeNode tn in trvTemperture.Nodes)
            //{
            //    if (tn.Name == "vdataset")
            //    { count = tn.Nodes.Count; }
            //}
            //frmDataSet fc = new frmDataSet("vd"+ Convert.ToString(count + 1));
            //fc.ShowDialog();
            //if (cm.newnode != null)
            //{
            //    foreach (TreeNode tn in trvTemperture.Nodes)
            //    {
            //        if (tn.Name == "vdataset")
            //        {
            //            cm.newnode.ImageIndex = 0;
            //            cm.newnode.SelectedImageIndex = 0;
            //            tn.Nodes.Add((TreeNode)cm.newnode.Clone());
            //            refleshioc();
            //        }
            //    }
            //    cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
            //    picTemperatureShow.Refresh();
            //}
        }

        /// <summary>
        /// 刷新操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnReflesh_Click(object sender, EventArgs e)
        {
            trvTemperture.Nodes.Clear();

            foreach (TreeNode tn in cm.OrignalTree.Nodes)
            {
                trvTemperture.Nodes.Add((TreeNode)tn.Clone());
            }
            cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
            refleshioc();
        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnAddImage_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmImgSet fc = new frmImgSet("img" + Convert.ToString(cm.getGenid()), ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "element")
                    {
                        cm.newnode.ImageIndex = 0;
                        cm.newnode.SelectedImageIndex = 0;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }
                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                picTemperatureShow.Refresh();
            }
        }


        private void tbtnDataType_Click(object sender, EventArgs e)
        {
            cm.newnode = null;
            frmDataLineTypeSet fc = new frmDataLineTypeSet(ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "vdataset")
                    {
                        cm.newnode.ImageIndex = 0;
                        cm.newnode.SelectedImageIndex = 0;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }
                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                cm.listlinedatas.Add((ClsLinedata)cm.newnode.Tag);
                picTemperatureShow.Refresh();
            }
        }

        private void tbtnTextType_Click(object sender, EventArgs e)
        {

            cm.newnode = null;
            frmDataTxtTypeSet fc = new frmDataTxtTypeSet(ref this.cm);
            fc.ShowDialog();
            if (cm.newnode != null)
            {
                foreach (TreeNode tn in trvTemperture.Nodes)
                {
                    if (tn.Name == "vdataset")
                    {
                        cm.newnode.ImageIndex = 0;
                        cm.newnode.SelectedImageIndex = 0;
                        tn.Nodes.Add((TreeNode)cm.newnode.Clone());
                        refleshioc();
                    }
                }
                cm.UpdateXml(0, cm.newnode, cm.XmlDoc, trvTemperture);
                cm.listtextdatas.Add((ClsTextdata)cm.newnode.Tag);
                picTemperatureShow.Refresh();
            }
        }

        /// <summary>
        /// 删除相关元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvTemperture.SelectedNode != null)
                {
                    if (trvTemperture.SelectedNode.Tag != null)
                    {
                        bool sflag = false;
                        if (trvTemperture.SelectedNode.Tag.ToString().Contains("ClsPens"))
                        {
                            if (MessageBox.Show("画笔素材如果删除，已使用项将会受到影响！", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                cm.DelXmlNodeById(trvTemperture.SelectedNode.Name, cm.XmlDoc.ChildNodes, ref sflag);

                            }
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString().Contains("ClsFont"))
                        {
                            if (MessageBox.Show("字体素材如果删除，已使用项将会受到影响！", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                cm.DelXmlNodeById(trvTemperture.SelectedNode.Name, cm.XmlDoc.ChildNodes, ref sflag);


                            }
                        }
                        else if (trvTemperture.SelectedNode.Tag.ToString().Contains("ClsMainFrame"))
                        {
                            MessageBox.Show("主区域是不能被删除的！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("确定要删除该节点“" + trvTemperture.SelectedNode.Text + "”吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                cm.DelXmlNodeById(trvTemperture.SelectedNode.Name, cm.XmlDoc.ChildNodes, ref sflag);
                                if (!sflag)
                                {
                                    cm.DelXmlNodeByName(trvTemperture.SelectedNode.Name, trvTemperture.SelectedNode.Tag.ToString(), cm.XmlDoc.ChildNodes, ref sflag);
                                }
                            }
                        }

                        if (sflag)
                        {
                            trvTemperture.SelectedNode.Remove();
                            cm.XmlDoc.Save(cm.SysXmlfileName);
                            MessageBox.Show("删除成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该节点无法被删除！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("请选择需要删除的节点！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败原因：" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 图形区域工具栏

        private void tbtnUp_Click(object sender, EventArgs e)
        {
            if (tcboreType.Text == "整体")
                AllElementReLocation(0, -1, false);
            else
                AllElementReLocation(0, -1, true);
        }

        private void tbtnDowm_Click(object sender, EventArgs e)
        {
            if (tcboreType.Text == "整体")
                AllElementReLocation(0, 1, false);
            else
                AllElementReLocation(0, 1, true);
        }

        private void tbtnLeft_Click(object sender, EventArgs e)
        {
            if (tcboreType.Text == "整体")
                AllElementReLocation(-1, 0, false);
            else
                AllElementReLocation(-1, 0, true);
        }





        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnDataBind_Click(object sender, EventArgs e)
        {
            //cm.GetTestPages();
            //tbtnReflesh_Click(sender,e);
            //this.picTemperatureShow.Refresh();
            frmTempertureDataEdit fc = new frmTempertureDataEdit(this);

            fc.ShowDialog();
        }

        private void tbtnloadtempleFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Temperature Template Files|*.tmb";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                cm.SysXmlfileName = openFileDialog1.FileName;
                if (!File.Exists(cm.SysXmlfileName))
                {
                    string oldxml = "<temperture Genid='0'><pens></pens><fonts></fonts><symbol></symbol><element></element><vdataset></vdataset></temperture>";
                    cm.XmlDoc.LoadXml(oldxml);

                    cm.XmlDoc.Save(cm.SysXmlfileName);

                }
                else
                {
                    cm.XmlDoc.Load(cm.SysXmlfileName);
                }

                trvTemperture.Nodes.Clear();
                foreach (TreeNode tn in cm.OrignalTree.Nodes)
                {
                    trvTemperture.Nodes.Add((TreeNode)tn.Clone());
                }

                cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
                refleshioc();
                cm.GetTestPages();
                picTemperatureShow.Refresh();
            }
            tlbllocation.Text = "当前选择的模板文件:" + cm.SysXmlfileName;
        }

        private void tbtnnewtempleFile_Click(object sender, EventArgs e)
        {
            if (cm.SysXmlfileName == App.SysPath + "\\厦门新阳体温单一_tmp.tmb")
            {
                if (DialogResult.OK != System.Windows.Forms.MessageBox.Show("当前模板尚未另存为；继续执行，临时模板将被覆盖！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    return;
            }

            cm.SysXmlfileName = App.SysPath + "\\厦门新阳体温单一_tmp.tmb";

            string xmldoca = TempertureEditor.Properties.Resources.TempertureSet_new.ToString();
            cm.XmlDoc.LoadXml(xmldoca);

            cm.XmlDoc.Save(cm.SysXmlfileName);

            trvTemperture.Nodes.Clear();
            foreach (TreeNode tn in cm.OrignalTree.Nodes)
            {
                trvTemperture.Nodes.Add((TreeNode)tn.Clone());
            }

            cm.IniTreeView(cm.XmlDoc, ref trvTemperture);
            refleshioc();

            #region 旧的临时测试数据文件应该被删除
            string testDataFullName = cm.GetTestDataFullName();
            File.Delete(testDataFullName);
            #endregion

            cm.GetTestPages();
            picTemperatureShow.Refresh();
            tlbllocation.Text = "当前选择的模板文件:" + cm.SysXmlfileName;
        }

        private void tbtnsaveas_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Temperature Template Files|*.tmb";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string oldTestDataFile = cm.GetTestDataFullName();    //保留临时测试数据文件完整路径名称
                cm.SysXmlfileName = sfd.FileName;
                if (File.Exists(oldTestDataFile))
                {
                    string newTestDataFile = cm.GetTestDataFullName();    //获取另存为测试数据文件完整路径名称
                    File.Copy(oldTestDataFile, newTestDataFile, true);      //如果当前目录下有同名测试数据文件，将被强制替换
                }

                cm.XmlDoc.Save(cm.SysXmlfileName);
            }
            tlbllocation.Text = "当前选择的模板文件:" + cm.SysXmlfileName;
        }

        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            if (tcboreType.Text == "整体")
                AllElementAlignCenter(true, false, false);
            else
                AllElementAlignCenter(true, false, true);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            picTemperatureShow.Location = new Point((panel1.Width - picTemperatureShow.Width) / 2, 0);
        }

        private void tbtnsyncodetype_Click(object sender, EventArgs e)
        {
            //同步体温单模板到数据类型到病历数据库常量表里,供资控使用
            if (cm.InsertNewTemperatureType())
            {
                App.Msg("同步模板数据类型至病历数据库常量表,操作成功!");
            }
            else
            {
                App.Msg("同步模板数据类型至病历数据库常量表,操作失败!");
            }

        }      

        private void tbtnRight_Click(object sender, EventArgs e)
        {
            if (tcboreType.Text == "整体")
                AllElementReLocation(1, 0, false);
            else
                AllElementReLocation(1, 0, true);
        }
        #endregion


    }
}
