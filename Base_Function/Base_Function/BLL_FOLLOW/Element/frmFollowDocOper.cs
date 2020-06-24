using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.MODEL;
using Bifrost;
using DevComponents.AdvTree;
using System.Xml;
using TextEditor;
using DevComponents.DotNetBar;
using Base_Function.BLL_FOLLOW.CustonPage;
using Base_Function.BLL_FOLLOW.StaticsAnalysis;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowDocOper : DevComponents.DotNetBar.Office2007Form
    {
        
        private Class_Follow_Patient myRecord;
        private Class_Follow_Text[] DirectionarysText;
        private DataSet dsSection;
        private frmFollowRecord myFrm;
        private string TempText_type = "";    //记录当前相关模版的文书类型号
        
        private Node SelectedNode;
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        public frmFollowDocOper(string rid, frmFollowRecord frm)
        {
            InitializeComponent();
            myFrm = frm;
            dsSection = App.GetDataSet("select * from T_FOLLOW_TEMPPLATE_SECTION");
            GetPatient(rid);
            IniAllDoc(rid);
            IniFinishedDoc();
        }
        #region 节点加载
        /// <summary>
        /// 实例化该随访记录
        /// </summary>
        /// <param name="id"></param>
        public void GetPatient(string id)
        {

            string temp = "";
            temp = "select * from T_FOLLOW_RECORD where id=" + id + "";
            DataTable tempTb = App.GetDataSet(temp).Tables[0];
            if (tempTb != null)
                if (tempTb.Rows.Count != 0)
                {
                    myRecord = new Class_Follow_Patient();
                    myRecord.Id = tempTb.Rows[0]["id"].ToString();
                    myRecord.Patient_Id = tempTb.Rows[0]["patient_id"].ToString();                    
                    myRecord.Solution_Id = tempTb.Rows[0]["solution_id"].ToString();                    
                    myRecord.Creator_ID = tempTb.Rows[0]["creator_id"].ToString();
                    myRecord.State_id = tempTb.Rows[0]["state_id"].ToString();
                    myRecord.Isfinished = tempTb.Rows[0]["isfinished"].ToString();
                    myRecord.Actual_time = tempTb.Rows[0]["actual_time"].ToString();
                    myRecord.Requested_time = tempTb.Rows[0]["requested_time"].ToString();
                }
        }
        /// <summary>
        /// 初始化全部文书树的类型节点
        /// </summary>
        /// <param name="id"></param>
        public void IniAllDoc(string id)
        {
            string TextIds = App.ReadSqlVal("select followtextid from T_FOLLOW_INFO where id =(select solution_id from T_FOLLOW_RECORD where id=" + id + " and rownum=1)", 0, "followtextid");
            string temp = "select * from T_FOLLOW_TEXT where id in ("+TextIds+") order by iscommon";
            DataSet tempDs = App.GetDataSet(temp);
            DirectionarysText = GetSelectClassDs(tempDs);
            this.advAllDoc.Nodes.Clear();
            Node rootNode = new Node();
            rootNode.Text = "随访文书";
            advAllDoc.Nodes.Add(rootNode);
            if (DirectionarysText != null)
            {
                for (int i = 0; i < DirectionarysText.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = DirectionarysText[i];
                    tn.Text = DirectionarysText[i].Textname;
                    tn.Name = DirectionarysText[i].Id.ToString();

                    //插入顶级节点
                    if (DirectionarysText[i].Parentid != 0)
                    {
                        rootNode.Nodes.Add(tn);
                        if (DirectionarysText[i].Id == 100)
                            tn.ImageIndex = 6;
                        if (DirectionarysText[i].Issimpleinstance != "1")
                            tn.ImageIndex = 9;
                        else
                            tn.ImageIndex = 8;
                        SetTreeView(DirectionarysText, tn);
                    }

                }
                advAllDoc.ExpandAll();
            }
            
        }
        /// <summary>
        /// 初始化已完成文书树
        /// </summary>
        public void IniFinishedDoc()
        {
            string temp = "select * from T_FOLLOW_TEXT where id in (select distinct text_type from T_FOLLOW_RECORD_DOC where record_id =" + myRecord.Id + ") order by shownum";
            DataSet tempDs = App.GetDataSet(temp);
            Class_Follow_Text[] myText = GetSelectClassDs(tempDs);
            advFinishDoc.Nodes.Clear();
            Node CustomerNode = new Node();
            CustomerNode.Text = "定制";
            CustomerNode.Name = "100";
            CustomerNode.ImageIndex = 6;
            advFinishDoc.Nodes.Add(CustomerNode);
            if (myText != null)
            {
                if (myText.Length != 0)
                {
                    for (int i = 0; i < myText.Length; i++)
                    {
                        Node tn = new Node();
                        tn.Name = myText[i].Id.ToString();
                        tn.Text = myText[i].Textname;
                        tn.ImageIndex = 1;
                        if (myText[i].Issimpleinstance != "1")
                            tn.Tag = myText[i] as Class_Follow_Text;
                        advFinishDoc.Nodes.Add(tn);

                    }
                    string tempSon = "select * from T_FOLLOW_RECORD_DOC where text_type in (select id from T_FOLLOW_TEXT where issimpleinstance=1) and record_id=" + myRecord.Id + " order by doc_name";
                    DataSet SonNode = App.GetDataSet(tempSon);
                    Class_Follow_Doc[] mydoc = GetClassDoc(SonNode);
                    if (mydoc != null)
                        if (mydoc.Length != 0)
                        {
                            foreach (Node nd in advFinishDoc.Nodes) 
                            {
                                if (nd.Tag == null&&nd.Nodes.Count==0)
                                {
                                    for (int j = 0; j < mydoc.Length; j++)
                                    {
                                        if (nd.Name == mydoc[j].Text_type)
                                        {
                                            Node tn = new Node();
                                            tn.Name = mydoc[j].Id;
                                            tn.Text = mydoc[j].Doc_name;
                                            tn.ImageIndex = 2;
                                            tn.Tag = mydoc[j] as Class_Follow_Doc;
                                            nd.Nodes.Add(tn);
                                        }
                                    }
                                }
                            }
                        }
                    advFinishDoc.ExpandAll();
                }
            }
        }

        /// <summary>
        /// 实例化多例文书
        /// </summary>
        /// <param name="ds"></param>
        private Class_Follow_Doc[] GetClassDoc(DataSet ds)
        {
            if (ds != null)
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Class_Follow_Doc[] docs = new Class_Follow_Doc[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        docs[i] = new Class_Follow_Doc();
                        docs[i].Id = ds.Tables[0].Rows[i]["id"].ToString();
                        docs[i].Record_id = ds.Tables[0].Rows[i]["Record_id"].ToString();
                        docs[i].Doc_name = ds.Tables[0].Rows[i]["Doc_name"].ToString();
                        docs[i].Text_type = ds.Tables[0].Rows[i]["Text_type"].ToString();
                        docs[i].Doc_content = ds.Tables[0].Rows[i]["Doc_content"].ToString();
                        docs[i].Issimpleinstance = ds.Tables[0].Rows[i]["Issimpleinstance"].ToString();
                        docs[i].Text_name = ds.Tables[0].Rows[i]["Text_name"].ToString();
                        docs[i].Creator_id = ds.Tables[0].Rows[i]["Creator_id"].ToString();
                        docs[i].Doc_content = ds.Tables[0].Rows[i]["Doc_content"].ToString();
                    }
                    return docs;
                }
                else
                    return null;
            else
                return null;
        }
        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param name="tempds"></param>
        /// <returns></returns>
        private Class_Follow_Text[] GetSelectClassDs(DataSet tempds)
        {

            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Follow_Text[] class_text = new Class_Follow_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Follow_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"] != null)
                        {
                            if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0" && tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "")
                            {
                                class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                            }
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Iscommon = tempds.Tables[0].Rows[i]["Iscommon"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["ISSIMPLEINSTANCE"].ToString();
                        class_text[i].Enable = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        class_text[i].Shownum = tempds.Tables[0].Rows[i]["shownum"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                        if (tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString() == "")
                        {
                            class_text[i].Right_range = "D";
                        }
                        else
                        {
                            class_text[i].Right_range = tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString() == "")
                        {
                            class_text[i].Isneedsign = "Y";
                        }
                        else
                        {
                            class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString() == "")
                        {
                            class_text[i].Isnewpage = "N";
                        }
                        else
                        {
                            class_text[i].Isnewpage = tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString() == "")
                        {
                            class_text[i].Issubmitsign = "N";
                        }
                        else
                        {
                            class_text[i].Issubmitsign = tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString();
                        }
                    }
                    return class_text;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        private static void SetTreeView(Class_Follow_Text[] Directionarys, Node current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    tn.ImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }
        #endregion
        /*
        
        */
        /// <summary>
        /// 点击全部文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_Click(object sender, EventArgs e)
        {
            if (advAllDoc.SelectedNode != null)
            {
                SelectedNode = advAllDoc.SelectedNode;
            }
            else
                SelectedNode = null;
        }
        /// <summary>
        /// 双击全部文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_DoubleClick(object sender, EventArgs e)
        {

            //排除根节点
            if (SelectedNode.Tag != null)
            {
                if (SelectedNode != null)
                {
                    
                    Class_Follow_Text Text = SelectedNode.Tag as Class_Follow_Text;
                    if (SelectedNode.Name == "100")
                    {
                        if (!ExistTab(SelectedNode.Text))
                            CreateCustomPage(SelectedNode);
                        else
                        {
                            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                            {
                                if (SelectedNode.Text == tctlDoc.Tabs[i].Text)
                                {
                                    tctlDoc.SelectedTabIndex = i;
                                    break;
                                }
                            }
                        }
                        trvRelatedDoc.Nodes.Clear();
                    }
                    else
                    {
                        //单例节点
                        if (Text.Issimpleinstance != "1")
                        {
                            //是否已存在该Tab
                            if (!ExistTab(Text.Textname))
                            {
                                //是否是已完成文书
                                if (!IsExistDoc(Text.Id.ToString()))
                                {
                                    CreateTab(false);
                                    IniRelatedDoc(SelectedNode.Name, "");
                                }
                                else
                                {
                                    CreateTab(true);
                                    IniRelatedDoc(SelectedNode.Name, "");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                                {
                                    //判断Tab的Name属性内的Id是否相同
                                    if (SelectedNode.Name == tctlDoc.Tabs[i].Name.Substring(0, tctlDoc.Tabs[i].Name.IndexOf(":")))
                                    {
                                        tctlDoc.SelectedTabIndex = i;
                                        break;
                                    }
                                }
                            }
                        }
                        //多例节点
                        else
                        {
                            CreateTab(false);
                            IniRelatedDoc(SelectedNode.Name, "");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始化相关文书树
        /// </summary>
        /// <param name="text_type"></param>
        /// <param name="condition"></param>
        public void IniRelatedDoc(string text_type, string condition)
        {
            if (TempText_type != "" || text_type != "")
            {
                string temp = "";

                if (condition == "")
                {
                    TempText_type = text_type;
                    temp = "select * from T_FOLLOW_TEMPPLATE WHERE text_type=" + text_type + "";
                }
                else
                    temp = "select * from T_FOLLOW_TEMPPLATE where text_type=" + TempText_type + " " + condition;
                DataSet tempDs = App.GetDataSet(temp);

                Class_Follow_Patients[] template = GetPatients(tempDs);
                this.trvRelatedDoc.Nodes.Clear();
                if (tempDs != null)
                {
                    if (tempDs.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < template.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Name = template[i].Tid.ToString();
                            tn.Text = template[i].TName;
                            tn.Tag = template[i];
                            tn.ImageIndex = 5;
                            trvRelatedDoc.Nodes.Add(tn);
                        }
                    }
                }
            }


        }
        /// <summary>
        /// 实例化文书模版
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_Follow_Patients[] GetPatients(DataSet temp)
        {
            if (temp != null)
                if (temp.Tables[0].Rows.Count != 0)
                {
                    int sum = temp.Tables[0].Rows.Count;
                    Class_Follow_Patients[] des = new Class_Follow_Patients[sum];
                    for (int i = 0; i < sum; i++)
                    {
                        des[i] = new Class_Follow_Patients();
                        des[i].Tid = Convert.ToInt32(temp.Tables[0].Rows[i]["tid"].ToString());
                        des[i].TName = temp.Tables[0].Rows[i]["TName"].ToString();
                        des[i].TextKind = temp.Tables[0].Rows[i]["text_type"].ToString();
                        des[i].TempPlate_Level = Convert.ToChar(temp.Tables[0].Rows[i]["TempPlate_Level"].ToString());
                        des[i].Section_ID = temp.Tables[0].Rows[i]["Section_ID"].ToString();
                        des[i].Creator_ID = Convert.ToInt32(temp.Tables[0].Rows[i]["Creator_ID"].ToString());
                        des[i].Create_Time = temp.Tables[0].Rows[i]["Create_Time"].ToString();
                        des[i].Enable_Flag = Convert.ToChar(temp.Tables[0].Rows[i]["Enable_Flag"].ToString());
                        des[i].IsDefault = Convert.ToChar(temp.Tables[0].Rows[i]["IsDefault"].ToString());
                        des[i].Creator_Role = temp.Tables[0].Rows[i]["Creator_Role"].ToString();
                    }
                    return des;
                }
                else
                    return null;
            else
                return null;
        }

        /// <summary>
        /// 判断是否已完成该类型文书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExistDoc(string id)
        {
            string temp = "select * from T_FOLLOW_RECORD_DOC WHERE text_type=" + id + " and record_id=" + myRecord.Id + "";
            DataSet tempDs = App.GetDataSet(temp);
            if (tempDs != null)
                if (tempDs.Tables[0].Rows.Count != 0)
                    return true;
                else
                    return false;
            else
                return false;
        }
        /// <summary>
        /// 检查是否存在该选项卡
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistTab(string Name)
        {
            if (tctlDoc.Tabs.Count != 0)
            {
               
                for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                {
                    if (Name == tctlDoc.Tabs[i].Text)
                        return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 创建定制页
        /// </summary>
        /// <param name="node"></param>
        public void CreateCustomPage(Node node)
        {
            groupBox1.Visible = false;
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Name = node.Name+":Custom";
            page.Text =  node.Text;
            page.Click += new EventHandler(Item_Click);
            if (node.Text == "定制")
            {
                ucTemplateTimeSet uc = new ucTemplateTimeSet(myRecord.Id);
                uc.Dock = DockStyle.Fill;
                tabctpnDoc.Controls.Add(uc);
                page.AttachedControl = tabctpnDoc;
                tabctpnDoc.Dock = DockStyle.Fill;
                tabctpnDoc.TabItem = page;
                tctlDoc.Controls.Add(tabctpnDoc);
                tctlDoc.Tabs.Add(page);
            }

        }
        /// <summary>
        /// 自动生成定制页面
        /// </summary>
        public void CreateCustomPage()
        {
            groupBox1.Visible = false;
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Name = "100:Custom";
            page.Text = "定制";
            page.Click += new EventHandler(Item_Click);

            ucTemplateTimeSet uc = new ucTemplateTimeSet(myRecord.Id);
            uc.Dock = DockStyle.Fill;
            tabctpnDoc.Controls.Add(uc);
            page.AttachedControl = tabctpnDoc;
            tabctpnDoc.Dock = DockStyle.Fill;
            tabctpnDoc.TabItem = page;
            tctlDoc.Controls.Add(tabctpnDoc);
            tctlDoc.Tabs.Add(page);
            tctlDoc.SelectedTab = page;

        }
        /// <summary>
        /// 添加选项卡
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Finish"></param>
        public void CreateTab( bool Finish)
        {

            DevComponents.DotNetBar.TabControlPanel DocPnl = new TabControlPanel();
            DocPnl.AutoScroll = true;
            DevComponents.DotNetBar.TabItem DocItem = new TabItem();
            DocItem.Click += new EventHandler(Item_Click);
            DocItem.AttachedControl = DocPnl;
            string DocContent = "";
            //初始化Item及Panel,根据是否是已完成文书->是否是单例文书分类
            if (Finish)
            {
                //点击AllDoc，或者FinishedDoc
                if (SelectedNode.Tag.ToString().Contains("Class_Follow_Text"))
                {
                    Class_Follow_Text Text = SelectedNode.Tag as Class_Follow_Text;
                    string creator = App.ReadSqlVal("select creator_id from T_FOLLOW_RECORD_DOC where text_type=" + Text.Id + " and record_id=" + myRecord.Id + "", 0, "creator_id");
                    if (creator != App.UserAccount.UserInfo.User_id)
                    {
                        App.Msg("无权对该文书进行修改，只可浏览");
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                    
                    DocItem.Name = Text.Id + ":Finish:" + SelectedNode.ToString();
                    DocItem.Text = Text.Textname;
                    DocContent = App.ReadSqlVal("select doc_content from T_FOLLOW_RECORD_DOC where text_type=" + Text.Id + " and record_id="+myRecord.Id+"", 0, "doc_content");
                }
                if (SelectedNode.Tag.ToString().Contains("Class_Follow_Doc"))
                {
                    Class_Follow_Doc Doc = SelectedNode.Tag as Class_Follow_Doc;
                    if (Doc.Creator_id != App.UserAccount.UserInfo.User_id)
                    {
                        App.Msg("无权对该文书进行修改，只可浏览");
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                    DocItem.Name = Doc.Text_type + ":Finish:" + SelectedNode.ToString();
                    DocItem.Text = Doc.Text_name + ":" + Doc.Doc_name;
                    DocContent = App.ReadSqlVal("select doc_content from T_FOLLOW_RECORD_DOC where text_type=" + Doc.Text_type + " and doc_name='" + Doc.Doc_name + "' and record_id="+myRecord.Id+"", 0, "doc_content");
                }
            }
            else
            {
                //
                string TimeStamp=App.GetSystemTime().ToString();
                if (SelectedNode.Tag != null)
                {
                    Class_Follow_Text Text = SelectedNode.Tag as Class_Follow_Text;
                    //新增单例文书
                    if (Text.Issimpleinstance != "1")
                    {
                        DocItem.Name = Text.Id + ":New:" + SelectedNode.ToString();
                        DocItem.Text = Text.Textname;
                    }
                    //AllDoc上新增多例文书
                    else
                    {
                        DocItem.Name = SelectedNode.Name + ":New:" + SelectedNode.ToString();
                        DocItem.Text = SelectedNode.Text + ":" + TimeStamp;
                    }
                }
                //FinishDoc上新增多例文书
                else
                {
                    DocItem.Name = SelectedNode.Name + ":New:" + SelectedNode.ToString();
                    DocItem.Text = SelectedNode.Text + ":" + TimeStamp;
                }
                DocContent=App.ReadSqlVal("select content from T_FOLLOW_TEMPPLATE_CONT where tid in (select tid from T_FOLLOW_TEMPPLATE t join T_FOLLOW_TEMPPLATE_SECTION s on t.tid=s.template_id where s.isdefault='Y' and t.text_type="+SelectedNode.Name+")",0,"Content");
            }
            if (DocContent == null)
                DocContent = "";
            frmText text = new frmText();//0, 0, 0, name, 0, currentPatient, true, true, "", "");

            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
            text.MyDoc.IgnoreLine = false;
            text.MyDoc.SetToolEvent();

            XmlDocument tmpxml = new System.Xml.XmlDocument();
            tmpxml.PreserveWhitespace = true;

            //没有模板的时候，传空的进来
            if (DocContent.Contains("emrtextdoc"))
            {
                tmpxml.LoadXml(DocContent);
            }
            else
            {
                tmpxml.LoadXml("<emrtextdoc/>");
                text.MyDoc.ClearContent();
                text.MyDoc.ToXML(tmpxml.DocumentElement);
            }
            text.MyDoc.FromXML(tmpxml.DocumentElement);
            text.MyDoc.ContentChanged();
            text.Dock = DockStyle.Fill;
            DocPnl.Controls.Add(text);
            DocPnl.TabItem = DocItem;
            DocPnl.Dock = DockStyle.Fill;
            this.tctlDoc.Controls.Add(DocPnl);
            this.tctlDoc.Tabs.Add(DocItem);
            this.tctlDoc.Refresh();
            this.tctlDoc.SelectedTab = DocItem;           

        }
        /// <summary>
        /// 关闭Tab上的文书页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Item_Click(object sender, EventArgs e)
        {
            try
            {
                if (tctlDoc.Tabs.Count > 0)
                {
                    tctlDoc.AutoCloseTabs = false;
                    TabItem item = (TabItem)sender;
                    //Point mp = Cursor.Position;
                    MouseEventArgs mp = (MouseEventArgs)e;
                    Point pTab = item.CloseButtonBounds.Location;
                    if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                        mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                    {
                        tctlDoc.Tabs.Remove(item);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            try
            {
                if (tctlDoc.SelectedTabIndex != -1)
                {
                    if (tctlDoc.SelectedPanel.Controls.Count > 0)
                    {
                        frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;

                        if (tempEditor != null)
                        {
                            tempEditor.MyDoc.IsHaveDeleted = true;
                            tempEditor.MyDoc.ToXML(tempxmldoc.DocumentElement);
                            tempEditor.MyDoc.IsHaveDeleted = false;
                        }
                    }
                }
            }
            catch
            { }
            return tempxmldoc.OuterXml;
        }

        /// <summary>
        /// 双击相关文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvRelatedDoc_DoubleClick(object sender, EventArgs e)
        {
            if (trvRelatedDoc.SelectedNode != null)
            {
                try
                {
                    Class_Follow_Patients template = trvRelatedDoc.SelectedNode.Tag as Class_Follow_Patients;
                    string temp = "select content from T_FOLLOW_TEMPPLATE_CONT where tid=" + template.Tid + "";
                    DataSet dsTemp = App.GetDataSet(temp);
                    if (dsTemp != null)
                    {

                        DataTable dtTemp = dsTemp.Tables[0];
                        string content = "";
                        if (dtTemp.Rows.Count != 0)
                        {
                            for (int k = 0; k < dtTemp.Rows.Count; k++)
                            {
                                content = content + dtTemp.Rows[k][0].ToString();
                            }
                            xmlDoc = new XmlDocument();//加入XML的声明段落                
                            xmlDoc.PreserveWhitespace = true;
                            if (content.Contains("emrtextdoc"))
                            {
                                xmlDoc.LoadXml(content);
                            }
                            else
                            {
                                string strXml = GetXmlContent();
                                xmlDoc.LoadXml(strXml);
                                xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//查找<body>

                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                {
                                    if (bodyNode.Name == "body")
                                    {
                                        bodyNode.InnerXml = content;
                                    }
                                }
                            }
                            frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;

                            if (tempEditor != null)
                            {
                                tempEditor.MyDoc.FromXML(xmlDoc.DocumentElement);
                                tempEditor.MyDoc.ContentChanged();
                            }



                        }
                    }
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }

            }

        }            

        //}
        /// <summary>
        /// 双击已完成文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {

            if (SelectedNode.Name != null)
            {
                if (SelectedNode != null)
                {
                    if (SelectedNode.Name == "100")
                    {
                        
                        if (!ExistTab(SelectedNode.Text))
                            CreateCustomPage(SelectedNode);
                        else
                        {
                            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                            {
                                if (SelectedNode.Text == tctlDoc.Tabs[i].Text)
                                {
                                    tctlDoc.SelectedTabIndex = i;
                                    break;
                                }
                            }
                        }
                        trvRelatedDoc.Nodes.Clear();
                    }
                    else
                    {
                        //排除多例的头节点
                        if (SelectedNode.Tag != null)
                        {
                            if (SelectedNode.Tag.ToString().Contains("Class_Follow_Doc"))
                            {
                                Class_Follow_Doc Doc = SelectedNode.Tag as Class_Follow_Doc;
                                if (!ExistTab(SelectedNode.Parent.Text + ":" + Doc.Doc_name))
                                {
                                    CreateTab(true);
                                    IniRelatedDoc(Doc.Text_type, "");
                                }
                                else
                                {
                                    for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                                    {
                                        if (SelectedNode.Text + ":" + Doc.Doc_name == tctlDoc.Tabs[i].Text)
                                        {
                                            tctlDoc.SelectedTabIndex = i;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!ExistTab(SelectedNode.Text))
                                {
                                    CreateTab(true);
                                    IniRelatedDoc(SelectedNode.Name, "");
                                }
                                else
                                {
                                    for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                                    {
                                        if (SelectedNode.Text == tctlDoc.Tabs[i].Text)
                                        {
                                            tctlDoc.SelectedTabIndex = i;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            
                            CreateTab(false);
                            IniRelatedDoc(SelectedNode.Name, "");
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 单击已完成文书树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_Click(object sender, EventArgs e)
        {
            if (advFinishDoc.SelectedNode != null)
            {
                SelectedNode = advFinishDoc.SelectedNode;

            }
            else
                SelectedNode = null;
        }
        /// <summary>
        /// 选项卡选中项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tctlDoc_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0)
                {
                    string SelectedPanelId = tctlDoc.SelectedTab.Name;
                    string SelectedUser="";
                    if (tctlDoc.SelectedTab.Text.IndexOf(":") != -1)
                    {
                        string doc_name=tctlDoc.SelectedTab.Text.Substring(tctlDoc.SelectedTab.Text.IndexOf(":")+1);
                        SelectedUser = App.ReadSqlVal("select creator_id from T_FOLLOW_RECORD_DOC where text_type=" + SelectedPanelId + " and record_id="+myRecord.Id+" and doc_name='"+doc_name+"'", 0, "creator_id");
                    }
                    else
                    {
                        SelectedUser = App.ReadSqlVal("select creator_id from T_FOLLOW_RECORD_DOC where text_type=" + SelectedPanelId + " and record_id="+myRecord.Id+"", 0, "creator_id");
                    }
                    if (SelectedUser == null || SelectedUser == "" || SelectedUser == App.UserAccount.UserInfo.User_id)
                    {
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;

                    }
                    else
                    {
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                    if (tctlDoc.SelectedTab.Text == "定制")
                    {
                        trvRelatedDoc.Nodes.Clear();
                        groupBox1.Visible = false;

                    }
                    else
                    {
                        groupBox1.Visible = true;
                        frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                        if (tempEditor != null)
                        {
                            string something = tctlDoc.SelectedTab.Name;
                            string[] something1 = something.Split(':');

                            string text_id = something1[0];
                            IniRelatedDoc(text_id, "");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 提交保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tctlDoc.Tabs.Count != 0)
            {
                if (tctlDoc.SelectedTabIndex != -1)
                {

                    try
                    {

                        TabItem CurrentItem = tctlDoc.SelectedTab;
                        //currentPatient = currentPage.Tag as InPatientInfo;
                        string Infomation = CurrentItem.Name;
                        //string[] ids = Infomation.Split(':');
                        string isSimple = "1";  //是否为单例文书
                        string text_name = "";  //文书名
                        bool isNewdoc = false;//是否新建文书
                        string text_type = "";   //文书类型号
                        string Key = "";    //主键
                        text_type = Infomation.Substring(0, Infomation.IndexOf(":"));
                        if (CurrentItem.Text.IndexOf(":")!=-1)
                        {
                            isSimple = "1";
                            text_name = CurrentItem.Text.Substring(0, CurrentItem.Text.IndexOf(":"));
                            Key = CurrentItem.Text.Substring(CurrentItem.Text.IndexOf(":")+1);
                        }
                        else
                        {
                            text_name = CurrentItem.Text;
                            isSimple = "0";
                            Key = text_name;
                        }
                        //新建文书保存
                        if (Infomation.Contains(":New:"))
                        {
                            isNewdoc = true;
                        }                                               
                        string content = GetXmlContent();

                        int id = App.GenId("T_FOLLOW_RECORD_DOC", "ID");



                        XmlDocument doc = new XmlDocument();
                        doc.PreserveWhitespace = true;
                        doc.LoadXml(content);
                        XmlElement xmlElement = doc.DocumentElement;
                        //插入到统计数据表内
                        //StaticsToDB InsertXml = new StaticsToDB();
                        //InsertXml.xmlSpit(doc);
                        frmText Text = tctlDoc.SelectedPanel.Controls[0] as frmText;
                        if (!Text.MyDoc._InsertSignature())
                            return;
                        
                        string docSql = "";
                        if (isNewdoc)
                        {

                                docSql = "insert into T_FOLLOW_RECORD_DOC(id,record_id,text_type,doc_name,text_name,doc_content,creator_id,issimpleinstance) values(" + id + "," + myRecord.Id + "," + text_type + ",'" + Key + "','"+text_name+"',:docContent," + App.UserAccount.UserInfo.User_id + ",'"+isSimple+"')";

                        }
                        else
                        {
                            if (CurrentItem.Text.IndexOf(":") == -1)
                                docSql = "update T_FOLLOW_RECORD_DOC set doc_content=:docContent where text_type=" + text_type + " and record_id=" + myRecord.Id + "";
                            else
                                docSql = "update T_FOLLOW_RECORD_DOC set doc_content=:docContent where record_id="+myRecord.Id+" and doc_name='"+Key+"'";
                        }
                        MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                        xmlPars[0] = new MySqlDBParameter();
                        xmlPars[0].ParameterName = "docContent";
                        xmlPars[0].Value = doc.OuterXml;
                        xmlPars[0].DBType = MySqlDbType.Text;
                        xmlPars[0].Direction = ParameterDirection.Input;
                        int message = App.ExecuteSQL(docSql, xmlPars);
                        if (message > 0)
                        {
                            App.Msg("保存成功!");
                            tctlDoc.Tabs.RemoveAt(tctlDoc.SelectedTabIndex);
                            IniFinishedDoc();
                        }
                    }
                    catch (Exception ex)
                    {
                        App.MsgErr(ex.Message);
                    }
                    if (App.ReadSqlVal("Select id from T_FOLLOW_DOC_ATTACH where record_id=" + myRecord.Id + "", 0, "id") == null)
                    {
                        int flag = 0;
                        for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                        {
                            if (tctlDoc.Tabs[i].Name == "100:Custom")
                            {
                                tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            if (!ExistTab("100"))
                                CreateCustomPage();

                        }
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗体关闭，刷新父窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFollowDocOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            myFrm.DataBind();
            myFrm.DetailDataBind(myRecord.Patient_Id, myRecord.Solution_Id);
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Condition = "";
            if (textBox1.Text.Trim() != "")
                Condition += " and tname like '%" + textBox1.Text.Trim() + "%'";
            if (rbtnDefault.Checked)
                Condition += " and isdefault='Y'";
            else
                Condition += " and isdefault='N'";
            if (rbtnPersonal.Checked)
                Condition += " and tempplate_level='P'";
            if (rbtnSection.Checked)
                Condition += " and tempplate_level='S'";
            if (rbtnHospital.Checked)
                Condition += " and tempplate_level='H'";
            IniRelatedDoc("", Condition);

        }
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFollowDocOper_Load(object sender, EventArgs e)
        {
            dockContainerItem1.Text = "文书操作";
            dockContainerItem2.Text = "模版提取";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedNode != null)
            {
                if (SelectedNode.Tag != null)
                {
                    string SelectedUser="";
                    if (SelectedNode.Tag.ToString().Contains("Class_Follow_Text"))
                    {

                        SelectedUser = App.ReadSqlVal("select creator_id from T_FOLLOW_RECORD_DOC where text_type=" + SelectedNode.Name + " and record_id=" + myRecord.Id + "", 0, "creator_id");


                    }
                    else
                    {
                        SelectedUser = App.ReadSqlVal("select creator_id from T_FOLLOW_RECORD_DOC where id=" + SelectedNode.Name + "",0,"creator_id");
 
                    }
                    if (SelectedUser == App.UserAccount.UserInfo.User_id)
                    {

                        删除ToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        删除ToolStripMenuItem.Enabled = false;
                    }
                }
            }
            
        }

        private void advFinishDoc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SelectedNode != null)
                {
                    if (SelectedNode.Tag == null)
                        contextMenuStrip1.Visible = false;
                }
            }
        }

    }
}