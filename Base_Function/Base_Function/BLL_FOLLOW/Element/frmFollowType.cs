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
    public partial class frmFollowType : DevComponents.DotNetBar.Office2007Form
    {
        private Class_Follow_Text[] Directionarys;
        private string Pid = "";
        private string Sid = "";
        private string isFinished = "Y"; //�Ƿ�Ϊȫ������
        private static DataSet Temp_Sections=new DataSet() ;
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private TreeNode SelectedNode;
        private string SelectId = "";

        public frmFollowType(string pid,string sid)
        {
            InitializeComponent();
            Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
            
            Pid = pid;
            Sid = sid;
          
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            trvAllDoc.CheckBoxes = false;
            IniAllDoc();
            IniFinishedDoc();
        }
        /// <summary>
        /// ��ʼ��ȫ������
        /// </summary>
        public void IniAllDoc()
        {
            string SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y' and id in(select followtextid from T_FOLLOW_INFO where id =" + Sid + ")";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Directionarys = GetSelectClassDs(ds);
            this.trvAllDoc.Nodes.Clear(); ;
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i] as Class_Follow_Text;
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();

                    //if (IsScheme == "Y")
                    //{
                    //    //���붥���ڵ�
                    //    if (Directionarys[i].Parentid == 0)
                    //    {
                    //        trvAllDoc.Nodes.Add(tn);
                    //        SetTreeView(Directionarys, tn);
                    //    }
                    //}
                    //else
                    //{
                    //    trvAllDoc.Nodes.Add(tn);
                    //}
                }
            }

        }
        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
        private static void SetTreeView(Class_Follow_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
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
        /// <summary>
        /// ʵ������������
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
        /// ȫ������˫������Ĭ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvAllDoc_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// �ڱ༭����ʾĬ��Doc
        /// </summary>
        /// <param name="text_type"></param>
        public void LoadDefaultDoc(string text_type)
        {
            try
            {
                string temp = "select content from T_FOLLOW_TEMPPLATE_CONT where tid in (select tid from T_FOLLOW_TEMPPLATE where text_type=" + text_type + ") and rownum=1";
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
                        xmlDoc = new XmlDocument();//����XML����������                
                        xmlDoc.PreserveWhitespace = true;
                        if (content.Contains("emrtextdoc"))
                        {
                            xmlDoc.LoadXml(content);
                        }
                        else
                        {
                            string strXml = GetXmlContent();
                            xmlDoc.LoadXml(strXml);
                            xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

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
        /// ��ʼ�����������
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
                        trvRelatedDoc.Nodes.Add(node);
                    }
                }
            }
        }
        /// <summary>
        /// ʵ��������
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
        /// ˫����ʾ������������
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
                        xmlDoc = new XmlDocument();//����XML����������                
                        xmlDoc.PreserveWhitespace = true;
                        if (content.Contains("emrtextdoc"))
                        {
                            xmlDoc.LoadXml(content);
                        }
                        else
                        {
                            string strXml = GetXmlContent();
                            xmlDoc.LoadXml(strXml);
                            xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

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
        /// ����ǰ�༭���е�����ת����xml�������ַ�������ʽ���� �����ڲ������ݿ⣩
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
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //if (IsScheme == "N")
            //{
            //    //��trvFinishenDoc������ڵ�
            //    if (SelectedNode.Tag != null)
            //    {
            //        Class_Follow_Text clss = SelectedNode.Tag as Class_Follow_Text;
            //        if (SelectedNode.Nodes.Count == 0)
            //        {
            //            if (clss.Issimpleinstance == "1")
            //            {
            //                if (trvFinishedDoc.Nodes[0].Nodes.Count != 0)
            //                {
            //                    foreach (TreeNode nd in trvFinishedDoc.Nodes[0].Nodes)
            //                    {
            //                        if (nd.Text == clss.Textname)
            //                        {
            //                            App.Msg("�Ѵ��ڸ�������");
            //                            return;
            //                        }
            //                    }
            //                }

            //                string nodename = trvFinishedDoc.Nodes[0].Text;
            //                TreeNode node = new TreeNode();

            //                string time = App.GetSystemTime().ToString("yyyy-MM-dd");
                            
            //                int record_id = App.GenId("T_FOLLOW_RECORD", "id");
            //                int doc_id = App.GenId("T_FOLLOW_RECORD_DOC", "id");
            //                int MaxTimes = GetMaxTimes() + 1;
            //                node.Name = doc_id.ToString();
            //                node.Text = clss.Textname;
            //                trvFinishedDoc.Nodes[0].Nodes.Add(node);
            //                //���ݿ����
            //                try
            //                {
            //                    string record_sql = "insert into T_FOLLOW_RECORD values(" + record_id + ","+Pid+"," + MaxTimes + "," + Sid + ",0,to_date('" + time + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + ")";
            //                    App.ExecuteSQL(record_sql);
            //                    string temp = GetXmlContent();
            //                    XmlDocument doc = new XmlDocument();
            //                    doc.PreserveWhitespace = true;
            //                    doc.LoadXml(temp);
            //                    XmlElement xmlElement = doc.DocumentElement;
            //                    string doc_sql = "insert into T_FOLLOW_RECORD_DOC values(" + doc_id + "," + record_id + ",:docContent,'" + clss.Textname + "'," + clss.Id + ")";
            //                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
            //                    xmlPars[0] = new MySqlDBParameter();
            //                    xmlPars[0].ParameterName = "docContent";
            //                    xmlPars[0].Value = doc.OuterXml;
            //                    xmlPars[0].DBType = MySqlDbType.Text;
            //                    xmlPars[0].Direction = ParameterDirection.Input;
            //                    int message = App.ExecuteSQL(doc_sql, xmlPars);
            //                    if (message != 0)
            //                    {
            //                        App.Msg("����ɹ���");
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    App.MsgErr(ex.Message);
            //                }
            //            }
            //            else
            //            {
            //                int isFirst = 0;        //����Ƿ�����������д����������
            //                string time = App.GetSystemTime().ToString("yyyy-MM-dd");
            //                int record_id = App.GenId("T_FOLLOW_RECORD", "id");
            //                int doc_id = App.GenId("T_FOLLOW_RECORD_DOC", "id");
            //                int MaxTimes = GetMaxTimes()+1;
            //                if (trvFinishedDoc.Nodes[1].Nodes.Count != 0)
            //                {
            //                    foreach (TreeNode nd in trvFinishedDoc.Nodes[1].Nodes)
            //                    {
            //                        TreeNode temp = new TreeNode();
            //                        if (nd.Text == clss.Textname.ToString())
            //                        {
            //                            isFirst = 1;

            //                            temp.Name = doc_id.ToString();
            //                            temp.Text = time;
            //                            nd.Nodes.Add(temp);
            //                            break;

            //                        }
            //                    }
            //                }
            //                if (isFirst == 0)
            //                {
            //                    //һ���ڵ�
            //                    TreeNode temp = new TreeNode();
            //                    temp.Text = clss.Textname;
            //                    trvFinishedDoc.Nodes[1].Nodes.Add(temp);
            //                    //�����ڵ�
            //                    TreeNode node = new TreeNode();
            //                    node.Text = time;
            //                    node.Name = doc_id.ToString();
            //                    temp.Nodes.Add(node);
            //                }
            //                try
            //                {
            //                    string record_sql = "insert into T_FOLLOW_RECORD values(" + record_id + ","+Pid+"," + MaxTimes + "," + Sid + ",0,to_date('" + time + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + ")";
            //                    App.ExecuteSQL(record_sql);
            //                    string temp = GetXmlContent();
            //                    XmlDocument doc = new XmlDocument();
            //                    doc.PreserveWhitespace = true;
            //                    doc.LoadXml(temp);
            //                    XmlElement xmlElement = doc.DocumentElement;
            //                    string doc_sql = "insert into T_FOLLOW_RECORD_DOC values(" + doc_id + "," + record_id + ",:docContent,'" + clss.Textname + "'," + clss.Id + ")";
            //                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
            //                    xmlPars[0] = new MySqlDBParameter();
            //                    xmlPars[0].ParameterName = "docContent";
            //                    xmlPars[0].Value = doc.OuterXml;
            //                    xmlPars[0].DBType = MySqlDbType.Text;
            //                    xmlPars[0].Direction = ParameterDirection.Input;
            //                    int message = App.ExecuteSQL(doc_sql, xmlPars);
            //                    if (message != 0)
            //                    {
            //                        App.Msg("����ɹ���");
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    App.MsgErr(ex.Message);
            //                }

            //            }
            //        }
            //    }
            //    //��ԭ�нڵ��޸�����
            //    else
            //    {
            //        if (SelectedNode.Name != "")
            //        {
            //            string id = SelectedNode.Name;
            //            string time = App.GetSystemTime().ToString("yyyy-MM-dd");
            //            if (SelectedNode.Parent.Text == "��������")
            //            {
            //                int rid=-1;
            //                if (GetRecordId(id) > 0)
            //                    rid = GetRecordId(id);
            //                if (rid < 0)
            //                    return;
            //                try
            //                {
            //                    string sql_uprecord = "update T_FOLLOW_RECORD set lasttime=to_date('" + time + "','yyyy-MM-dd') where id=" + rid + "";
            //                    App.ExecuteSQL(sql_uprecord);
            //                    string temp = GetXmlContent();
            //                    XmlDocument doc = new XmlDocument();
            //                    doc.PreserveWhitespace = true;
            //                    doc.LoadXml(temp);
            //                    XmlElement xmlElement = doc.DocumentElement;
            //                    string sql_updoc = "update T_FOLLOW_RECORD_DOC set doc_name=:docContent where id=" + id + " ";
            //                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
            //                    xmlPars[0] = new MySqlDBParameter();
            //                    xmlPars[0].ParameterName = "docContent";
            //                    xmlPars[0].Value = doc.OuterXml;
            //                    xmlPars[0].DBType = MySqlDbType.Text;
            //                    xmlPars[0].Direction = ParameterDirection.Input;
            //                    int message = App.ExecuteSQL(sql_updoc, xmlPars);
            //                    if (message != 0)
            //                    {
            //                        App.Msg("����ɹ���");
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    App.MsgErr(ex.Message);
            //                }
            //            }
            //            //��������
            //            else
            //            {
            //                int rid=-1;
            //                if (GetRecordId(id) > 0)
            //                    rid = GetRecordId(id);
            //                if (rid < 0)
            //                    return;
            //                try
            //                {
            //                    string sql_uprecord = "update T_FOLLOW_RECORD set lasttime=to_date('" + time + "','yyyy-MM-dd') where id=" + rid + "";
            //                    App.ExecuteSQL(sql_uprecord);
            //                    string temp = GetXmlContent();
            //                    XmlDocument doc = new XmlDocument();
            //                    doc.PreserveWhitespace = true;
            //                    doc.LoadXml(temp);
            //                    XmlElement xmlElement = doc.DocumentElement;
            //                    string sql_updoc = "update T_FOLLOW_RECORD_DOC set doc_name=:docContent ,doc_name='"+time+"' where id=" + id + " ";
            //                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
            //                    xmlPars[0] = new MySqlDBParameter();
            //                    xmlPars[0].ParameterName = "docContent";
            //                    xmlPars[0].Value = doc.OuterXml;
            //                    xmlPars[0].DBType = MySqlDbType.Text;
            //                    xmlPars[0].Direction = ParameterDirection.Input;
            //                    int message = App.ExecuteSQL(sql_updoc, xmlPars);
            //                    if (message != 0)
            //                    {
            //                        App.Msg("����ɹ���");
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    App.MsgErr(ex.Message);
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (TreeNode node in trvAllDoc.Nodes)
            //    {
            //        if (node.Checked&&node.Nodes.Count==0)
            //        {
            //            if (rtnTypeIds == "")
            //            {
            //                rtnTypeIds = node.Name;
            //                rtnTypeNames = node.Text;
            //            }
            //            else
            //            {
            //                rtnTypeIds += "," + node.Name;
            //                rtnTypeNames += "," + node.Text;
            //            }
            //        }
            //        CheckTree(node);
            //    }
            //    this.Close();          
            //}
        }
        /// <summary>
        /// ��ȡ��ؽڵ��Record_Id
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
        /// ��ȡ��ǰ���������Ĵ���
        /// </summary>
        /// <returns></returns>
        public int GetMaxTimes()
        {
            string Max_String = "select max(follow_times) from t_follow_record where patient_id="+Pid+" and solution_id="+Sid+"";
            DataSet ds = App.GetDataSet(Max_String);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0][0].ToString() != "")
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                else
                    return 0;
            }
            else
                return 0;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //rtnTypeIds = "";
            //rtnTypeNames = "";
            this.Close();
        }

        /// <summary>
        /// ��������ȡѡ�нڵ����Ϣ
        /// </summary>
        /// <param name="temp"></param>
        public void CheckTree(TreeNode temp)
        {
            if (temp.Nodes.Count != 0)
            {
                foreach (TreeNode tn in temp.Nodes)
                {
                    if (tn.Checked&&tn.Nodes.Count==0)
                    {
                        //if (RtnTypeIds == "")
                        //{
                        //    rtnTypeIds = tn.Name;
                        //    rtnTypeNames = tn.Text;
                        //}
                        //else
                        //{
                        //    rtnTypeIds += "," + tn.Name;
                        //    rtnTypeNames += "," + tn.Text;
                        //}
                    }
                    CheckTree(tn);
                }
            }
        }

        private void trvFinishedDoc_DoubleClick(object sender, EventArgs e)
        {


            //DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            //tabctpnDoc.TabItem = page;
            //tabctpnDoc.Dock = DockStyle.Fill;
            //page.AttachedControl = tabctpnDoc;
            //this.tabDoc.Controls.Add(tabctpnDoc);
            //this.tabDoc.Tabs.Add(page);
        }
        /// <summary>
        /// ��ʼ�������������
        /// </summary>
        public void IniFinishedDoc()
        {
            string sql_finishedDoc = "select * from T_FOLLOW_RECORD_DOC where record_id in (select id from T_FOLLOW_RECORD where patient_id=" + Pid + " and solution_id=" + Sid + ")";
            DataSet temp = App.GetDataSet(sql_finishedDoc);
            //Class_Follow_Doc[] myDoc = GetFollowDoc(temp);


        }

        /// <summary>
        /// ˫����ʾ��������������
        /// </summary>
        /// <param name="tid"></param>
        public void LoadFinisheddDoc(string id)
        {
            try
            {
                string temp = "select doc_content from T_FOLLOW_RECORD_DOC where id=" + id + "";
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
                        xmlDoc = new XmlDocument();//����XML����������                
                        xmlDoc.PreserveWhitespace = true;
                        if (content.Contains("emrtextdoc"))
                        {
                            xmlDoc.LoadXml(content);
                        }
                        else
                        {
                            string strXml = GetXmlContent();
                            xmlDoc.LoadXml(strXml);
                            xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

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
    }
}