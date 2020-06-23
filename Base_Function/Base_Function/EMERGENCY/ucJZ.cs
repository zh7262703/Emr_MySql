using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TextEditor;
using Bifrost;
using System.Xml;
using Bifrost.WebReference;
using Base_Function.BASE_COMMON;
using TextEditor.TextDocument.Document;

namespace Base_Function.EMERGENCY
{
    public partial class ucJZ : UserControl
    {
        public ucJZ()
        {
            InitializeComponent();
        }

        public ucJZ(string uid)
        {
            InitializeComponent();
            strUid = uid;
        }

        frmText JJXXtext = null;
        frmText HZSFtext = null;
        frmText HZZGtext = null;
        frmText XTZLtext = null;
        frmText textCont = null;
        Button btnOK = null;
        Panel pl = null;
        string strUid = "";
        XmlNode xn = null;


        private void ucJZ_Load(object sender, EventArgs e)
        {
            getTree(strUid);

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TabItem tabIJJ = new DevComponents.DotNetBar.TabItem();
            tabIJJ.Click += new System.EventHandler(this.tabItem1_Click);

            TabControlPanel tabConPJJ = new DevComponents.DotNetBar.TabControlPanel();


            switch (e.Node.Text)
            {
                case "急救信息":
                    try
                    {
                        string content = "";
                        foreach (TabItem var in tabControl1.Tabs)
                        {
                            if (var.Text == "急救信息 " + e.Node.Tag.ToString())
                            {
                                MessageBox.Show("已存在急救信息文书,请勿重复打开!");
                                return;
                            }
                        }

                        tabIJJ.Name = "急救信息";
                        tabIJJ.Text = "急救信息 " + e.Node.Tag.ToString();


                        tabConPJJ.Name = "tabConPJJ";
                        tabConPJJ.TabItem = tabIJJ;
                        tabConPJJ.Dock = DockStyle.Fill;
                        tabIJJ.AttachedControl = tabConPJJ;

                        JJXXtext = new frmText();


                        XmlDocument tmpxml = new System.Xml.XmlDocument();
                        tmpxml.PreserveWhitespace = true;

                        content = App.ReadSqlVal("select * from jjhz_cont where id='" + e.Node.Tag.ToString() + "' and tid=4946791", 0, "CONTENT");


                        if (content == null)
                        {
                            content = App.ReadSqlVal("select * from t_tempplate_cont where tid=4946791", 0, "CONTENT");
                        }


                        tmpxml.LoadXml(content);
                        JJXXtext.MyDoc.FromXML(tmpxml.DocumentElement);
                        JJXXtext.MyDoc.OnDrawPageHeader += new TextEditor.TextDocument.Document.ZYTextDocument.DrawPageHeader(MyDoc_onDrawHeader);
                        JJXXtext.MyDoc.ContentChanged();
                        //JJXXtext.Tag = e.Node.Tag;

                        CSHKJ(e.Node.Text, e.Node.Tag.ToString());

                        tabConPJJ.Controls.Add(pl);
                        pl.Dock = DockStyle.Bottom;
                        tabConPJJ.Controls.Add(JJXXtext);
                        JJXXtext.Dock = DockStyle.Fill;


                        tabControl1.Tabs.Add(tabIJJ);
                        tabControl1.Controls.Add(tabConPJJ);
                        tabControl1.SelectedTab = tabIJJ;

                        setPrint(JJXXtext);
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "患者随访":
                    try
                    {
                        string content = "";
                        foreach (TabItem var in tabControl1.Tabs)
                        {
                            if (var.Text == "患者随访 " + e.Node.Tag.ToString())
                            {
                                MessageBox.Show("已存在患者随访文书,请勿重复打开!");
                                return;
                            }
                        }
                        //TabItem tabIJJ = new DevComponents.DotNetBar.TabItem();
                        tabIJJ.Name = "患者随访";
                        tabIJJ.Text = "患者随访 " + e.Node.Tag.ToString();

                        //TabControlPanel tabConPJJ = new DevComponents.DotNetBar.TabControlPanel();
                        tabConPJJ.Name = "tabConPJJ";
                        tabConPJJ.TabItem = tabIJJ;
                        tabConPJJ.Dock = DockStyle.Fill;
                        tabIJJ.AttachedControl = tabConPJJ;

                        HZSFtext = new frmText();


                        XmlDocument tmpxml = new System.Xml.XmlDocument();
                        tmpxml.PreserveWhitespace = true;

                        content = App.ReadSqlVal("select * from jjhz_cont where id='" + e.Node.Tag.ToString() + "' and tid=4990475", 0, "CONTENT");


                        if (content == null)
                        {
                            content = App.ReadSqlVal("select * from t_tempplate_cont where tid=4990475", 0, "CONTENT");
                        }


                        tmpxml.LoadXml(content);
                        HZSFtext.MyDoc.FromXML(tmpxml.DocumentElement);
                        HZSFtext.MyDoc.OnDrawPageHeader += new TextEditor.TextDocument.Document.ZYTextDocument.DrawPageHeader(MyDoc_onDrawHeader);
                        HZSFtext.MyDoc.ContentChanged();
                        //HZSFtext.Tag = e.Node.Tag;

                        CSHKJ(e.Node.Text, e.Node.Tag.ToString());

                        tabConPJJ.Controls.Add(pl);
                        pl.Dock = DockStyle.Bottom;
                        tabConPJJ.Controls.Add(HZSFtext);
                        HZSFtext.Dock = DockStyle.Fill;



                        tabControl1.Tabs.Add(tabIJJ);
                        tabControl1.Controls.Add(tabConPJJ);
                        tabControl1.SelectedTab = tabIJJ;

                        setPrint(HZSFtext);
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "患者转归":
                    try
                    {
                        string content = "";
                        foreach (TabItem var in tabControl1.Tabs)
                        {
                            if (var.Text == "患者转归 " + e.Node.Tag.ToString())
                            {
                                MessageBox.Show("已存在患者转归文书,请勿重复打开!");
                                return;
                            }
                        }
                        //TabItem tabIJJ = new DevComponents.DotNetBar.TabItem();
                        tabIJJ.Name = "患者转归";
                        tabIJJ.Text = "患者转归 " + e.Node.Tag.ToString();

                        //TabControlPanel tabConPJJ = new DevComponents.DotNetBar.TabControlPanel();
                        tabConPJJ.Name = "tabConPJJ";
                        tabConPJJ.TabItem = tabIJJ;
                        tabConPJJ.Dock = DockStyle.Fill;
                        tabIJJ.AttachedControl = tabConPJJ;

                        HZZGtext = new frmText();


                        XmlDocument tmpxml = new System.Xml.XmlDocument();
                        tmpxml.PreserveWhitespace = true;

                        content = App.ReadSqlVal("select * from jjhz_cont where id='" + e.Node.Tag.ToString() + "' and tid=4950717", 0, "CONTENT");


                        if (content == null)
                        {
                            content = App.ReadSqlVal("select * from t_tempplate_cont where tid=4950717", 0, "CONTENT");
                        }


                        tmpxml.LoadXml(content);
                        HZZGtext.MyDoc.FromXML(tmpxml.DocumentElement);
                        HZZGtext.MyDoc.OnDrawPageHeader += new TextEditor.TextDocument.Document.ZYTextDocument.DrawPageHeader(MyDoc_onDrawHeader);
                        HZZGtext.MyDoc.ContentChanged();
                        //HZZGtext.Tag = e.Node.Tag;

                        CSHKJ(e.Node.Text, e.Node.Tag.ToString());

                        tabConPJJ.Controls.Add(pl);
                        pl.Dock = DockStyle.Bottom;
                        tabConPJJ.Controls.Add(HZZGtext);
                        HZZGtext.Dock = DockStyle.Fill;



                        tabControl1.Tabs.Add(tabIJJ);
                        tabControl1.Controls.Add(tabConPJJ);
                        tabControl1.SelectedTab = tabIJJ;

                        setPrint(HZZGtext);
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "胸痛诊疗":
                    try
                    {
                        string content = "";
                        foreach (TabItem var in tabControl1.Tabs)
                        {
                            if (var.Text == "胸痛诊疗 " + e.Node.Tag.ToString())
                            {
                                MessageBox.Show("已存在胸痛诊疗文书,请勿重复打开!");
                                return;
                            }
                        }
                        //TabItem tabIJJ = new DevComponents.DotNetBar.TabItem();
                        tabIJJ.Name = "胸痛诊疗";
                        tabIJJ.Text = "胸痛诊疗 " + e.Node.Tag.ToString();
                        tabIJJ.Tag = e.Node.Tag;

                        //TabControlPanel tabConPJJ = new DevComponents.DotNetBar.TabControlPanel();
                        tabConPJJ.Name = "tabConPJJ";
                        tabConPJJ.TabItem = tabIJJ;
                        tabConPJJ.Dock = DockStyle.Fill;
                        tabIJJ.AttachedControl = tabConPJJ;

                        XTZLtext = new frmText();


                        XmlDocument tmpxml = new System.Xml.XmlDocument();
                        tmpxml.PreserveWhitespace = true;

                        content = App.ReadSqlVal("select * from jjhz_cont where id='" + e.Node.Tag.ToString() + "' and tid=4946118", 0, "CONTENT");


                        if (content == null)
                        {
                            content = App.ReadSqlVal("select * from t_tempplate_cont where tid=4946118", 0, "CONTENT");
                        }


                        tmpxml.LoadXml(content);
                        XTZLtext.MyDoc.FromXML(tmpxml.DocumentElement);
                        XTZLtext.MyDoc.OnDrawPageHeader += new TextEditor.TextDocument.Document.ZYTextDocument.DrawPageHeader(MyDoc_onDrawHeader);
                        XTZLtext.MyDoc.ContentChanged();
                        //XTZLtext.Tag = e.Node.Tag;

                        CSHKJ(e.Node.Text, e.Node.Tag.ToString());

                        tabConPJJ.Controls.Add(pl);
                        pl.Dock = DockStyle.Bottom;
                        tabConPJJ.Controls.Add(XTZLtext);
                        XTZLtext.Dock = DockStyle.Fill;



                        tabControl1.Tabs.Add(tabIJJ);
                        tabControl1.Controls.Add(tabConPJJ);
                        tabControl1.SelectedTab = tabIJJ;


                        setPrint(XTZLtext);
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("姓名不能为空!");
                return;
            }
            try
            {
                string sql = "insert into jjhz(name,sex,intime) values('" + txtName.Text + "','" + cboSex.Text + "',to_timestamp('" + dtiIn.Text + "','yyyy-MM-dd hh24:mi:ss'))";
                int add = App.ExecuteSQL(sql);
                if (add > 0)
                {
                    txtName.Text = "";
                    getTree(strUid);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void getTree(string uid)
        {
            try
            {
                string sql = "select * from jjhz where 1=1 ";
                if (uid != "")
                {
                    sql += "and id='" + uid + "'";
                    panel1.Visible = false;
                }
                else
                {
                    sql += "and type=1";
                }
                sql += " order by intime desc";
                DataSet ds = App.GetDataSet(sql);
                treeView1.Nodes.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int id = Int32.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    TreeNode treeJJXX = new TreeNode("急救信息");
                    treeJJXX.Tag = id;
                    TreeNode treeHZSF = new TreeNode("患者随访");
                    treeHZSF.Tag = id;
                    TreeNode treeHZZZ = new TreeNode("患者转归");
                    treeHZZZ.Tag = id;
                    TreeNode treeXTZL = new TreeNode("胸痛诊疗");
                    treeXTZL.Tag = id;
                    TreeNode treeName = new TreeNode(ds.Tables[0].Rows[i]["id"].ToString() + " " + ds.Tables[0].Rows[i]["name"].ToString(), new TreeNode[] { treeJJXX, treeXTZL, treeHZZZ, treeHZSF });
                    treeName.Tag = id;
                    treeView1.Nodes.AddRange(new TreeNode[] { treeName });
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void CSHKJ(string strTag, string id)
        {

            btnOK = new Button();
            pl = new Panel();

            btnOK.Name = "btnOK";
            btnOK.Text = "保存";
            btnOK.Size = new Size(75, 23);
            btnOK.Location = new Point(tabControl1.Width / 2 - 75 / 2, 10);
            btnOK.Tag = strTag + "," + id;
            btnOK.Click += new System.EventHandler(btnOK_Click);
            pl.Name = "plOK";
            pl.Size = new Size(200, 40);
            pl.Controls.Add(btnOK);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (TabItem var in tabControl1.Tabs)
                {
                    if (var.IsSelected)
                    {
                        for (int i = 0; i < var.AttachedControl.Controls.Count; i++)
                        {
                            if (var.AttachedControl.Controls[i].GetType().ToString() == "TextEditor.frmText")
                            {
                                textCont = var.AttachedControl.Controls[i] as frmText;
                            }
                        }
                    }
                }
                Button btn = sender as Button;
                int index = btn.Tag.ToString().IndexOf(",");
                string btnTag = btn.Tag.ToString().Substring(0, index);
                string id = btn.Tag.ToString().Substring(index + 1, btn.Tag.ToString().Length - index - 1);
                int tid = 0;
                string sql = "";
                string ctsql = "update jjhz_cont_time set ";
                //获取文书XMl
                XmlDocument tempxmldoc = new XmlDocument();
                tempxmldoc.PreserveWhitespace = true;
                tempxmldoc.LoadXml("<emrtextdoc/>");
                textCont.MyDoc.ToXML(tempxmldoc.DocumentElement);
                XmlNodeList xnArrInput = tempxmldoc.GetElementsByTagName("input");
                XmlNodeList xnArrCbo = tempxmldoc.GetElementsByTagName("checkbox");
                switch (btnTag)
                {
                    case "急救信息":
                        tid = 4946791;
                        break;
                    case "患者随访":
                        tid = 4990475;
                        break;
                    case "患者转归":
                        tid = 4950717;
                        break;
                    case "胸痛诊疗":
                        tid = 4946118;
                        break;
                }
                string cont = App.ReadSqlVal("select * from jjhz_cont where id='" + id + "' and tid='" + tid + "'", 0, "CONTENT");
                if (cont == null)
                {
                    sql = "insert into jjhz_cont(id,tid,content) values('" + id + "','" + tid + "',:doc1)";
                }
                else
                {
                    sql = "update jjhz_cont set content=:doc1 where id='" + id + "' and tid='" + tid + "'";

                }

                OracleParameter[] xmlPars = new OracleParameter[1];
                xmlPars[0] = new OracleParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = tempxmldoc.OuterXml;
                xmlPars[0].OracleType = OracleType.Clob;

                int j = App.ExecuteSQL(sql, xmlPars);
                if (j > 0)
                {
                    string ctcont = App.ReadSqlVal("select * from jjhz_cont_time where id='" + id + "'", 0, "id");
                    if (ctcont == null)
                    {
                        ctsql = "insert into jjhz_cont_time(id) values('" + id + "')";
                        App.ExecuteSQL(ctsql);
                    }

                    int sw = 0;
                    foreach (XmlNode node in xnArrCbo)
                    {
                        if (node.Attributes["id"].Value == "死亡")
                        {
                            if (node.Attributes["check"].Value == "Y")
                            {
                                sw = 1;
                            }
                        }
                    }
                    ctsql = "update jjhz_cont_time set HZZG='" + sw + "'";
                    foreach (XmlNode node in xnArrInput)
                    {
                        if (node.Attributes["name"].Value == "时间")
                        {
                            try
                            {
                                DateTime dt = DateTime.ParseExact(node.InnerText, "yyyy-MM-dd HH:mm", null);
                                switch (node.Attributes["id"].Value)
                                {
                                    case "首次医疗接触时间":
                                        ctsql += ",scyljc=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "心电图诊断时间":
                                        ctsql += ",SCXDT=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "传输时间":
                                        ctsql += ",XDTCS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "报告时间":
                                        ctsql += ",FZJCBG=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        ctsql += ",SHBZWBG=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "溶栓时间":
                                        ctsql += ",RSZL=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "到达本院大门时间":
                                        ctsql += ",DDBYDM=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "启动导管室时间":
                                        ctsql += ",QDDGS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "决定介入手术时间":
                                        ctsql += ",JDJRSS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "患者到达导管室":
                                        ctsql += ",HZDDGS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "球囊扩张时间":
                                        ctsql += ",QNKZ=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "发病时间":
                                        ctsql += ",fb=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "呼救时间":
                                        ctsql += ",hj=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "出车时间":
                                        ctsql += ",cc=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "出诊医生到达现场时间":
                                        ctsql += ",CZYSDDXC=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "院前首份心电图":
                                        ctsql += ",YQSFXDT=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "到达急诊时间":
                                        ctsql += ",HZDDJZK=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "院内接诊时间":
                                        ctsql += ",YNJZ=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "院内首份心电图":
                                        ctsql += ",YNSFXDT=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "初步诊断时间":
                                        ctsql += ",CBZD=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "首次给药时间":
                                        ctsql += ",SCGY=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "到达CCU时间":
                                        ctsql += ",HZDDCCU=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "开始知情同意时间":
                                        ctsql += ",KSZQTY=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "签署知情同意时间":
                                        ctsql += ",QSZQTY=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "导管室激活时间":
                                        ctsql += ",DGSJH=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "开始穿刺时间":
                                        ctsql += ",KSCC=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "造影开始时间":
                                        ctsql += ",ZYKS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "造影结束时间":
                                        ctsql += ",ZYJS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "再次签署知情同意":
                                        ctsql += ",ZCQSZQTY=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "手术结束时间":
                                        ctsql += ",SSJS=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "D2B时间":
                                        ctsql += ",DTOB=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "抽血时间":
                                        ctsql += ",SHBZWCX=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "院内心内科医生首诊时间":
                                        ctsql += ",YNXNKYSSZ=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                    case "介入人员到达时间":
                                        ctsql += ",JRRYDD=to_date('" + node.InnerText + "','yyyy-MM-dd hh24:mi')";
                                        break;
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            if (node.Attributes["id"].Value == "远程心电传输")
                            {
                                if (node.InnerText == "是")
                                {
                                    ctsql += ",YCXDCS=1";
                                }
                                else
                                {
                                    ctsql += ",YCXDCS=0";
                                }
                            }
                        }

                    }

                    ctsql += " where id='" + id + "'";
                    App.ExecuteSQL(ctsql);
                    textCont.MyDoc.Locked = true;
                    MessageBox.Show("文书保存成功!");

                }
                else
                {
                    MessageBox.Show("文书保存失败!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文书保存失败!");
            }
        }

        private void 出院ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "";
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (App.Ask("是否确定出院?"))
                    {
                        frmJZ frmot = new frmJZ();
                        frmot.ShowDialog();
                        if (frmot.flag)
                        {
                            string dt = frmot.outTime;
                            id = treeView1.SelectedNode.Tag.ToString();
                            string sql = "update jjhz set type=0,outtime=to_date('" + dt + "','yyyy-MM-dd hh24:mi:ss') where id='" + id + "'";
                            int i = App.ExecuteSQL(sql);
                            getTree(strUid);
                        }

                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ucOutPatient ucOP = new ucOutPatient();
            App.UsControlStyle(ucOP);
            App.AddNewBusUcControl(ucOP, "出院患者查看");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ucOutPatientTJ ucOPTJ = new ucOutPatientTJ();
            App.UsControlStyle(ucOPTJ);
            App.AddNewBusUcControl(ucOPTJ, "出院患者统计");
        }

        private void 时间轴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    string id = treeView1.SelectedNode.Tag.ToString();
                    string sql = "select fb 发病时间,HJ 呼救时间,CC 出车时间,CZYSDDXC 出诊医生到达现场,SCYLJC 首次医疗接触时间,YQSFXDT 院前首份心电图,SCXDT 心电图诊断时间,XDTCS 远程心电传输时间,SHBZWCX 生化标志物抽血时间,SHBZWBG 生化标志物报告时间,YNXNKYSSZ 院内心内科医生首诊时间,JRRYDD 介入人员到达时间,DDBYDM 到达本院大门时间,HZDDJZK 患者到达急诊科时间,YNJZ 院内接诊时间,YNSFXDT 院内首份心电图时间,CBZD 初步诊断时间,SCGY 首次给药时间,HZDDCCU 患者到达CCU,RSZL 溶栓时间,JDJRSS 决定介入手术时间,QDDGS 启动导管室时间,KSZQTY 开始知情同意时间,QSZQTY 签署知情同意时间,DGSJH 导管室激活时间,HZDDGS 患者到达导管室,KSCC 开始穿刺时间,ZYKS 造影开始时间,ZYJS 造影结束时间,ZCQSZQTY 再次签署知情同意,QNKZ 球囊扩张时间,SSJS 手术结束时间,(case when fb is not null and ssjs is not null then floor((SSJS-fb)*24*60) end) D2B时间 from jjhz_cont_time where id='" + id + "'";
                    DataTable dt = App.GetDataSet(sql).Tables[0];
                    frmSJZ sjz = new frmSJZ(dt);
                    sjz.Show();
                }
            }
        }


        private void setPrint(frmText ft)
        {

            App.SetToolButtonByUser("ttsbtnPrint", true);
            DataInit.SetToolEvent(ft);
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            frmText text = new frmText();

            if (tabControl1.Tabs.Count > 0)
            {
                TabItem item = (TabItem)sender;

                //Point mp = Cursor.Position;
                MouseEventArgs mp = (MouseEventArgs)e;
                Point pTab = item.CloseButtonBounds.Location;
                if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                    mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                {
                    if (tabControl1.Tabs.Count == 1)
                    {
                        App.SetToolButtonByUser("ttsbtnPrint", false);
                        return;
                    }
                    else
                    {
                        foreach (TabItem var in tabControl1.Tabs)
                        {
                            if (var.IsSelected)
                            {
                                tabControl1.Tabs.Remove(var);
                                TabItem ti = tabControl1.Tabs[tabControl1.Tabs.Count - 1];
                                for (int i = 0; i < ti.AttachedControl.Controls.Count; i++)
                                {
                                    if (ti.AttachedControl.Controls[i].GetType().ToString() == "TextEditor.frmText")
                                    {
                                        text = ti.AttachedControl.Controls[i] as frmText;
                                        setPrint(text);
                                        return;
                                    }
                                }
                            }
                        }
                        
                    }
                }
                else
                {
                    foreach (TabItem var in tabControl1.Tabs)
                    {
                        if (var.IsSelected)
                        {
                            for (int i = 0; i < var.AttachedControl.Controls.Count; i++)
                            {
                                if (var.AttachedControl.Controls[i].GetType().ToString() == "TextEditor.frmText")
                                {
                                    text = var.AttachedControl.Controls[i] as frmText;
                                }
                            }
                        }
                    }
                    setPrint(text);
                }

            }

        }



        public static string TextTittle = "胸痛病人信息采集表";  //当前文书的标题

        /// <summary>
        /// 绘制页眉页脚
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        /// <param name="pageIndex"></param>
        void MyDoc_onDrawHeader(Graphics g, Rectangle rectContent, int pageIndex, ZYCommon.PageHeaders currentPage, ZYTextDocument emrdoc)
        {
            Font headNameFont = null;
            Font headHospitalTittleFont = null;
            Font bottomPageCurrent = null;
            Font headNameFont2 = null;

            if (headNameFont == null)
                headNameFont = new Font("宋体", 12f);
            if (headHospitalTittleFont == null)
                headHospitalTittleFont = new Font("宋体", 16f);
            if (bottomPageCurrent == null)
                bottomPageCurrent = new Font("宋体", 10.5f);
            if (headNameFont2 == null)
                headNameFont2 = new Font("宋体", 15f);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;


            #region 页眉
            //标题
            g.DrawString(TextTittle, headNameFont2, Brushes.Black, new Rectangle(rectContent.Left, rectContent.Top - 80, rectContent.Width, 34), format);
            g.DrawString(App.HospitalTittle, headHospitalTittleFont, Brushes.Black, new Rectangle(rectContent.Left, rectContent.Top - 110, rectContent.Width, 25), format);
            #endregion
        }
    }
}
