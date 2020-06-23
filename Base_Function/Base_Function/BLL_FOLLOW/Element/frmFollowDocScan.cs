using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;
using System.Xml;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowDocScan : DevComponents.DotNetBar.Office2007Form
    {


        private string ckTypeNames = "";    //存储选中的类型名

        public string CkTypeNames
        {
            get { return ckTypeNames; }
            set { ckTypeNames = value; }
        }

        private string ckTypeIds = "";      //存储选中的类型IDS


        public string CkTypeIds
        {
            get { return ckTypeIds; }
            set { ckTypeIds = value; }
        }
        private Class_Follow_Text[] Directionarys;        
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private string Sids = "";

        public frmFollowDocScan(string sectionIds)
        {
            InitializeComponent();
            ckTypeIds = "";
            ckTypeNames = "";
            dockContainerItem1.Text = "文书操作";
            dockContainerItem2.Text = "模版提取";
            Sids = sectionIds;
            IniAllDoc();

        }
        /// <summary>
        /// 初始化全部文书
        /// </summary>
        public void IniAllDoc()
        {
            string  SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y' order by shownum";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Directionarys = GetSelectClassDs(ds);
            this.trvAllDoc.Nodes.Clear(); ;
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (FilterText(Directionarys[i], Sids))
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = Directionarys[i] as Class_Follow_Text;
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            trvAllDoc.Nodes.Add(tn);
                            SetTreeView(Directionarys, tn);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 判断文书类型是否可被当前方案浏览
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool FilterText(Class_Follow_Text doc,string sid)
        {
            if (sid == "0")
                return true;
            if (doc.Sid == "0")
                return true;
            if (sid.Split(',') != null)
            {
                string[] SectionId = sid.Split(',');    //保存当前方案页面的科室号
                for (int i = 0; i < SectionId.Length; i++)
                {
                    
                    if (doc.Sid.Split(',') != null)
                    {
                        string[] Text_Sid = doc.Sid.Split(',');//保存文书类型适用的科室号
                        for (int j = 0; j < Text_Sid.Length; j++)
                        {
                            if (Text_Sid[j] == SectionId[i])
                                return true;
                        }
                    }
                }
                return false;
            }
            else
                return false;
        }
        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        public  void SetTreeView(Class_Follow_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
                if (FilterText(Directionarys[i], Sids))
                {
                    if (Directionarys[i].Parentid == cunrrentDir.Id)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        tn.ImageIndex = 9;
                        tn.SelectedImageIndex = 9;
                        current.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn);
                    }
                }
            }
        }
        /// <summary>
        /// 实例化文书类型
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
                        class_text[i].Sid = tempds.Tables[0].Rows[i]["Sid"].ToString();
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
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
        /// 全部文书双击加载默认文书内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvAllDoc_DoubleClick(object sender, EventArgs e)
        {
            if (trvAllDoc.SelectedNode != null)
            {
                if (trvAllDoc.SelectedNode.Tag != null)
                {
                    if (trvAllDoc.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text")&&trvAllDoc.SelectedNode.Nodes.Count==0)
                    {
                        gpnlEditor.Controls.Add(Template.fmT);
                        Template.fmT.Dock = DockStyle.Fill;
                        Template.fmT.MyDoc.Locked = true;
                        Class_Follow_Text clss = trvAllDoc.SelectedNode.Tag as Class_Follow_Text;
                        LoadDefaultDoc(clss.Id.ToString());
                        IniRelatedDoc(clss.Id.ToString());
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
            }
        }
        /// <summary>
        /// 在编辑器显示默认Doc
        /// </summary>
        /// <param name="text_type"></param>
        public void LoadDefaultDoc(string text_type)
        {
            try
            {
                //加载选中文书类型下，科室默认模板的第一份文书
                string temp;
                if(Sids!="0")
                    temp= "select content from T_FOLLOW_TEMPPLATE_CONT a join T_FOLLOW_TEMPPLATE b on b.tid=a.tid where b.text_type=" + text_type + " and a.tid in (select template_id from T_FOLLOW_TEMPPLATE_SECTION where section_id in (" + Sids + ") and isdefault='Y' and rownum=1)";
                else
                    temp= "select content from T_FOLLOW_TEMPPLATE_CONT a join T_FOLLOW_TEMPPLATE b on b.tid=a.tid where b.text_type=" + text_type + " and a.tid in (select template_id from T_FOLLOW_TEMPPLATE_SECTION where isdefault='Y' and rownum=1)";
                //若上述sql无结果，则查找全院默认模板
                string sql = "select content from T_FOLLOW_TEMPPLATE_CONT where tid in (select tid from T_FOLLOW_TEMPPLATE where text_type=" + text_type + " and tempplate_level='H' and isdefault='Y' and rownum=1)"; 
                DataSet dsTemp = App.GetDataSet(temp);
                if (dsTemp != null)
                {
                    //科室默认模板不为空
                    if(dsTemp.Tables[0].Rows.Count!=0)
                    {
                        DataTable dtTemp = dsTemp.Tables[0];
                        string content = "";
                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            content = content + dtTemp.Rows[i][0].ToString();
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
                        Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                        Template.fmT.MyDoc.ContentChanged();
                    }
                    //科室默认模板为空，选择院级默认模板
                    else
                    {
                        DataSet ds= App.GetDataSet(sql);
                        DataTable dtTemp = ds.Tables[0];
                        string content = "";
                        if (dtTemp.Rows.Count != 0)
                        {
                            for (int i = 0; i < dtTemp.Rows.Count; i++)
                            {
                                content = content + dtTemp.Rows[i][0].ToString();
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
                            Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                            Template.fmT.MyDoc.ContentChanged();
                        }
                        //加载空白模板
                        else
                        {
                            
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
                            Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                            Template.fmT.MyDoc.ContentChanged();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }

        }
        /// <summary>
        /// 初始化相关文书树
        /// </summary>
        /// <param name="text_type"></param>
        public void IniRelatedDoc(string text_type)
        {
            trvRelatedDoc.Nodes.Clear();
            string temp="select * from T_FOLLOW_TEMPPLATE where text_type="+text_type+"";
            DataSet dtTemp=App.GetDataSet(temp);
            if (dtTemp != null)
            {
                if (dtTemp.Tables[0].Rows.Count != 0)
                {
                    Class_Follow_Patients[] cfp = GetPatients(dtTemp);
                    for (int i = 0; i < dtTemp.Tables[0].Rows.Count; i++)
                    {
                        TreeNode node = new TreeNode();
                        node.Name = cfp[i].Tid.ToString();
                        node.Text = cfp[i].TName;
                        node.ImageIndex = 13;
                        trvRelatedDoc.Nodes.Add(node);
                    }
                }
            }
        }
        /// <summary>
        /// 实例化文书
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_Follow_Patients[] GetPatients(DataSet temp)
        {
            int sum = temp.Tables[0].Rows.Count;
            Class_Follow_Patients[] des=new Class_Follow_Patients[sum];
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
        /// <summary>
        /// 单击显示相关文书的内容
        /// </summary>
        /// <param name="tid"></param>
        public void LoadRelatedDoc(string tid)
        {
            try
            {
                string temp = "select content from T_FOLLOW_TEMPPLATE_CONT where tid=" + tid + "";
                DataSet dsTemp = App.GetDataSet(temp);
                if (dsTemp != null)
                {

                    DataTable dtTemp = dsTemp.Tables[0];
                    string content = "";
                    if (dtTemp.Rows.Count != 0)
                    {
                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            content = content + dtTemp.Rows[i][0].ToString();
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
                        Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                        Template.fmT.MyDoc.ContentChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
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
            Template.fmT.MyDoc.IsHaveDeleted = true;
            Template.fmT.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.fmT.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        private void trvRelatedDoc_DoubleClick(object sender, EventArgs e)
        {         
            LoadRelatedDoc(trvRelatedDoc.SelectedNode.Name);
        }

        /// <summary>
        /// 获取相关节点的Record_Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetRecordId(string id)
        {
            string temp = "select record_id from T_FOLLOW_RECORD_DOC where id=" + id + "";
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp != null)
                if(dsTemp.Tables[0].Rows.Count!=0)
                    return Convert.ToInt32(dsTemp.Tables[0].Rows[0][0].ToString());
            return -1;
        }

        /// <summary>
        /// 复选框选择改变时 引起级联变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvAllDoc_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Nodes.Count != 0)
                {
                    foreach (TreeNode nd in e.Node.Nodes)
                    {
                        nd.Checked = true;
                        
                    }
                }
            }
            else
            {
                if(e.Node.Nodes.Count!=0)
                    foreach (TreeNode nd in e.Node.Nodes)
                    {
                        nd.Checked = false;
                        
                    }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ckTypeIds = "";
            ckTypeNames = "";
            this.Close();
        }

        /// <summary>
        /// 遍历树获取选中节点的信息
        /// </summary>
        /// <param name="temp"></param>
        public void CheckTree(TreeNode temp)
        {
            if (temp.Nodes.Count != 0)
            {
                foreach (TreeNode tn in temp.Nodes)
                {
                    if (tn.Text == "定制")
                        tn.Checked = true;
                    if (tn.Checked&&tn.Nodes.Count==0)
                    {
                        if (ckTypeIds == "")
                        {
                            ckTypeIds = tn.Name;
                            ckTypeNames = tn.Text;
                        }
                        else
                        {
                            ckTypeIds += "," + tn.Name;
                            ckTypeNames += "," + tn.Text;
                        }
                    }
                    CheckTree(tn);
                }
                this.Close();
            }
        }
        /// <summary>
        /// 根据传进来的Ids设置被选中项
        /// </summary>
        /// <param name="ids"></param>
        public void SetSelectType(string ids)
        {
            if (ids!="")
            {
                string[] TypeId = ids.Split(',');
                for (int i = 0; i < TypeId.Length; i++)
                {
                    foreach (TreeNode tn in trvAllDoc.Nodes)
                    {
                        Class_Follow_Text clss = tn.Tag as Class_Follow_Text;
                        if (clss.Id.ToString() == TypeId[i])
                        {
                            tn.Checked = true;
                            break;
                        }
                        if (SetCheck(tn, TypeId[i])==1)
                            break;
                    }
                }
            }
        }
        public int SetCheck(TreeNode temp,string CompareStr)
        {
            if (temp.Nodes.Count != 0)
            {
                foreach (TreeNode tn in temp.Nodes)
                {
                    Class_Follow_Text clss = tn.Tag as Class_Follow_Text;
                    if (clss.Id.ToString() == CompareStr)
                    {
                        tn.Checked = true;
                        return 1;
                    }
                    if (SetCheck(tn, CompareStr) == 1)
                        break;
                }

            }
            return 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (trvAllDoc.Nodes.Count != 0)
            {
                foreach (TreeNode tn in trvAllDoc.Nodes)
                {
                    if (tn.Checked && tn.Nodes.Count == 0)
                    {
                        if (ckTypeIds == "")
                        {
                            ckTypeIds = tn.Name;
                            ckTypeNames = tn.Text;
                        }
                        else
                        {
                            ckTypeIds += "," + tn.Name;
                            ckTypeNames += "," + tn.Text;
                        }
                    }
                    CheckTree(tn);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}