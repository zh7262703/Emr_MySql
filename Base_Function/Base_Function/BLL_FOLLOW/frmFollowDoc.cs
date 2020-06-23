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
using DevComponents.AdvTree;
using TextEditor;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowDoc : DevComponents.DotNetBar.Office2007Form
    {
  
        private string isSingle = "";   //  �Ƿ�������
        private string rtnTypeIds = "";

        /// <summary>
        /// �ж�Ϊ�������ý���������������
        /// </summary>
        private string IsScheme = "Y"; 

        /// <summary>
        /// ��ǰ������
        /// </summary>
        private AdvTree NowTree = new AdvTree();     
        /// <summary>
        /// ��ǰ�����ڵ�
        /// </summary>
        private static Node CurrentNode = new Node();
        /// <summary>
        /// ��ǰ������Ϣ
        /// </summary>
        private  InPatientInfo currentPatient;


        //��������������Ϣ
        public string RtnTypeIds
        {
            get { return rtnTypeIds; }
            set { rtnTypeIds = value; }
        }
        private string rtnTypeNames = "";

        public string RtnTypeNames
        {
            get { return rtnTypeNames; }
            set { rtnTypeNames = value; }
        }



        private Class_Follow_Text[] DirectionarysText;
        private Class_Follow_Patient[] DirectionarysPatient;
        private string Pid = "";
        private string Sid = "";
        private string isFinished = "Y"; //�Ƿ�Ϊȫ������

        private static DataSet Temp_Sections=new DataSet() ;
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private TreeNode SelectedNode;
        private string SelectId = "";

        public frmFollowDoc()
        {
            InitializeComponent();
            IsScheme = "Y";
            //c1OutPage2.Enabled = false;
            //pnlEditor.Controls.Add(Template.fmT);
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            Template.fmT.MyDoc.Locked = true;
            //advAllDoc.CheckBoxes = true;
            
            IniAllDoc();
        }

        public frmFollowDoc(string pid)
        {
            InitializeComponent();
            Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
            IsScheme = "Y";
            Pid = pid;
            //Sid = sid;
            currentPatient = DataInit.GetInpatientInfoByPid(pid);
            // tabItem1.Controls.Add(Template.fmT);
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            //trvAllDoc.CheckBoxes = false;
            IniAllDoc();
            IniFinishedDoc();
        }

        public frmFollowDoc(string pid,string sid)
        {
            InitializeComponent();
            Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
            IsScheme = "N";
            Pid = pid;
            Sid = sid;
            currentPatient = DataInit.GetInpatientInfoByPid(pid);
            // tabItem1.Controls.Add(Template.fmT);
            Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;
            //trvAllDoc.CheckBoxes = false;
            IniAllDoc();
            IniFinishedDoc();
        }

        /// <summary>
        /// ��ʼ�������������
        /// 1.���ݲ�������֪������Щ���ͣ���������ˢ������
        /// 2.�ҵ�����������д���飬���뵽��Ӧ�ڵ���ȥ
        /// </summary>
        public void IniFinishedDoc()
        {
            advFinishDoc.Nodes.Clear();
            if (string.IsNullOrEmpty(Pid))
            { 
                return;
            }
            else
            {
                //���������ͼ���
                string sql_type = " select distinct text_type,tft.textname from T_FOLLOW_RECORD tfr   inner join T_FOLLOW_TEXT tft on tfr.text_type=tft.id  where patient_id=" + Pid + "";
                DataSet ds_type = new DataSet();
                ds_type = App.GetDataSet(sql_type);
                if (ds_type != null && ds_type.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_type.Tables[0].Rows.Count; i++)
                    {
                        Node tn = new Node();
                        tn.Text = ds_type.Tables[0].Rows[i]["textname"].ToString();
                        tn.Name = ds_type.Tables[0].Rows[i]["text_type"].ToString();
                        advFinishDoc.Nodes.Add(tn);

                        //�������������

                        string sql_text = " select * from T_FOLLOW_RECORD where patient_id=" + Pid + "  and text_type=" + tn.Name + " order by lasttime";
                        DataSet ds = new DataSet();
                        ds = App.GetDataSet(sql_text);
                        DirectionarysPatient = GetPatientsByDs(ds);
                        if (DirectionarysPatient != null)
                        {
                            for (int j = 0; j < DirectionarysPatient.Length; j++)
                            {
                                Node temp = new Node();
                                temp.Tag = DirectionarysPatient[j];
                                temp.Text = DirectionarysPatient[j].TextName;
                                temp.Name = DirectionarysPatient[j].Id.ToString();
                                tn.Nodes.Add(temp);
                            }
                        }
                    }
                }
            }
            advFinishDoc.ExpandAll();

        }

        /// <summary>
        /// ��ʼ��ȫ������
        /// 1.������T_FOLLOW_INFO�����Ƿ��Ӧ��ǰ���� 
        ///   IsScheme�������ý���������������
        /// 2.T_FOLLOW_TEXT��������
        /// </summary>
        public void IniAllDoc()
        {
            string SQl = "";
            if (IsScheme == "Y")
                SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y'";
            else
                SQl = "select * from T_FOLLOW_TEXT where ENABLE_FLAG='Y' and id in(select followtextid from T_FOLLOW_INFO where id =" + Sid + ")";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            DirectionarysText = GetSelectClassDs(ds);
            this.advAllDoc.Nodes.Clear(); ;
            if (DirectionarysText != null)
            {
                for (int i = 0; i < DirectionarysText.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = DirectionarysText[i];
                    tn.Text = DirectionarysText[i].Textname;
                    tn.Name = DirectionarysText[i].Id.ToString();

                    if (IsScheme == "Y")
                    {
                        //���붥���ڵ�
                        if (DirectionarysText[i].Parentid == 0)
                        {
                            advAllDoc.Nodes.Add(tn);
                            SetTreeView(DirectionarysText, tn);
                        }
                    }
                    else
                    {
                        advAllDoc.Nodes.Add(tn);
                    }
                }
            }
            advAllDoc.ExpandAll();
        }

       

        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
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
                    //tn.SelectedImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        private Class_Follow_Patient[] GetPatientsByDs(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Follow_Patient[] class_patients = new Class_Follow_Patient[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_patients[i] = new Class_Follow_Patient();
                        class_patients[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        class_patients[i].Patient_Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["PATIENT_ID"].ToString());
                        class_patients[i].Follow_Times = Convert.ToInt32(tempds.Tables[0].Rows[i]["follow_times"].ToString());
                        if (tempds.Tables[0].Rows[i]["solution_id"] != null && tempds.Tables[0].Rows[i]["solution_id"].ToString() != "")
                            class_patients[i].Solution_Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["solution_id"].ToString());
                        if (tempds.Tables[0].Rows[i]["patient_state"] != null && tempds.Tables[0].Rows[i]["patient_state"].ToString() != "")
                            class_patients[i].Patient_State = Convert.ToInt32(tempds.Tables[0].Rows[i]["patient_state"].ToString());
                        if (tempds.Tables[0].Rows[i]["lasttime"] != null)
                            class_patients[i].LastTime = tempds.Tables[0].Rows[i]["lasttime"].ToString();
                        if (tempds.Tables[0].Rows[i]["creator_id"] != null && tempds.Tables[0].Rows[i]["creator_id"].ToString() != "")
                            class_patients[i].Creator_ID = Convert.ToInt32(tempds.Tables[0].Rows[i]["creator_id"].ToString());
                        if (tempds.Tables[0].Rows[i]["text_type"] != null && tempds.Tables[0].Rows[i]["text_type"].ToString() != "")
                            class_patients[i].Text_Type = Convert.ToInt32(tempds.Tables[0].Rows[i]["text_type"].ToString());
                        if (tempds.Tables[0].Rows[i]["doc_name"] != null)
                            class_patients[i].DocName = tempds.Tables[0].Rows[i]["doc_name"].ToString();
                        if (tempds.Tables[0].Rows[i]["textname"] != null)
                            class_patients[i].TextName = tempds.Tables[0].Rows[i]["textname"].ToString();
                    }
                    return class_patients;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// ʵ��Class_Text����ѯ���
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
            TreeView trvClick = sender as TreeView;
            if (trvClick.SelectedNode != null)
            {
                
                if (trvClick.SelectedNode.Tag != null)
                {
                    //����ȫ��������������˫���¼�
                    if (trvClick.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                    {
                        Class_Follow_Text clss = trvClick.Tag as Class_Follow_Text;
                        //��������
                        if (clss.Issimpleinstance == "0")
                        {

                        }
                    }
                }
            }
            //if (trvAllDoc.SelectedNode != null)
            //{
            //    isFinished = "N";
            //    SelectedNode = trvAllDoc.SelectedNode;
            //    Class_Follow_Text clss = trvAllDoc.SelectedNode.Tag as Class_Follow_Text;
            //    LoadDefaultDoc(clss.Id.ToString()); //���ص�ǰ�ڵ�Ĭ�ϵ�����
            //    IniRelatedDoc(clss.Id.ToString());  //��ʼ����ǰ�ڵ���������������
            //}

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
        /// ��ʼ�����ģ��
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
                    //Class_Follow_Patients[] cfp = GetPatients(dtTemp);
                    for (int i = 0; i < dtTemp.Tables[0].Rows.Count; i++)
                    {
                        TreeNode node = new TreeNode();
                        node.Name = dtTemp.Tables[0].Rows[i]["tid"].ToString();
                        node.Text = dtTemp.Tables[0].Rows[i]["tname"].ToString();
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
        /// ������ʾ������������
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

                        //Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                        //Template.fmT.MyDoc.ContentChanged();

                        if (tctlDoc.SelectedTabIndex != -1)
                        {
                            if (tctlDoc.SelectedPanel.Controls.Count > 0)
                            {
                                frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;

                                if (tempEditor != null)
                                {
                                    tempEditor.MyDoc.FromXML(xmlDoc.DocumentElement);
                                    tempEditor.MyDoc.ContentChanged();
                                }
                            }
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
        /// ����ǰ�༭���е�����ת����xml�������ַ�������ʽ���� �����ڲ������ݿ⣩
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

        private void trvRelatedDoc_DoubleClick(object sender, EventArgs e)
        {         
            LoadRelatedDoc(trvRelatedDoc.SelectedNode.Name);
        }

      
        public int GetRecordId(string id)
        {
            string temp = "select record_id from T_FOLLOW_RECORD_DOC where id=" + id + "";
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp != null)
                if(dsTemp.Tables[0].Rows.Count!=0)
                    return Convert.ToInt32(dsTemp.Tables[0].Rows[0][0].ToString());
            return -1;
        }

        public int GetMaxTimes()
        {
            
            string  Max_String="select max(follow_times) from t_follow_record where patient_id="+Pid+"";

            if(!string.IsNullOrEmpty(Sid))
            {
                Max_String += "and solution_id=" + Sid + "";
            }
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
        /// <summary>
        /// ��ѡ��ѡ��ı�ʱ �������仯
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
            rtnTypeIds = "";
            rtnTypeNames = "";
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
                        if (RtnTypeIds == "")
                        {
                            rtnTypeIds = tn.Name;
                            rtnTypeNames = tn.Text;
                        }
                        else
                        {
                            rtnTypeIds += "," + tn.Name;
                            rtnTypeNames += "," + tn.Text;
                        }
                    }
                    CheckTree(tn);
                }
            }
        }

        private void trvFinishedDoc_DoubleClick(object sender, EventArgs e)
        {
            //if (trvFinishedDoc.SelectedNode != null)
            //{
            //    if (trvFinishedDoc.SelectedNode.Name != "")
            //    {
            //        isFinished = "Y";
            //        SelectedNode = trvFinishedDoc.SelectedNode;
            //        LoadFinisheddDoc(SelectedNode.Name);
            //    }
            //}

            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.TabItem = page;
            tabctpnDoc.Dock = DockStyle.Fill;
            page.AttachedControl = tabctpnDoc;
            //this.tabDoc.Controls.Add(tabctpnDoc);
            //this.tabDoc.Tabs.Add(page);
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



        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="IsFinishDoc"></param>
        private void AddDoc(bool IsFinishDoc)
        {
            if (NowTree.SelectedNode == null)
            {
                return;
            }
            if (NowTree.SelectedNode.Tag != null)
            {
                if (IsFinishDoc)
                {
                    //����������ʾ
                    if (!IsSameTabItem(GetFinishDocTid()))
                    {                                           
                        CreateTabItem(GetFinishDocTid(), IsFinishDoc);
                    }
                }
                else
                {
                    //��������
                    int tid = App.GenId("T_FOLLOW_RECORD", "id");
                    if (!IsSameTabItem(Convert.ToInt32(CurrentNode.Name)))
                    {
                        CreateTabItem(tid, false);
                    }
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private bool DocIsExistDB(string tid)
        {
            bool flag = false;
            string sql = "select id from T_FOLLOW_RECORD  where patient_id=" + currentPatient.Id + " and text_type=" + CurrentNode.Name + "";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// ��ǰѡ�еĽڵ���������ͣ��Ƿ���tctlDoc.Tabs���������Ѿ����ڣ�����true,����false
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private bool IsSameTabItem(int text_id)
        {
            bool flag = false;
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                string something = tctlDoc.Tabs[i].Name;
                string[] something1 = something.Split(':');
                if (something1[1] == text_id.ToString() || something1[0] == text_id.ToString())
                {
                    flag = true;
                    tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                }
            }
            return flag;
        }

        /// <summary>
        /// ��ǰѡ�еĽڵ㣬�Ƿ���tctlDoc.Tabs���������Ѿ����ڣ�����true,����false
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private bool IsSameTabItem(string tid, string ctime)
        {
            bool flag = false;
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                string something = tctlDoc.Tabs[i].Name;
                string[] something1 = something.Split(':');
                if (something1[0] == tid && something1[2].Contains(ctime))
                {
                    flag = true;
                }
            }
            return flag;
        }


        /// <summary>
        /// �õ���д�����Tid
        /// </summary>
        /// <returns></returns>
        private int GetFinishDocTid()
        {
            int tid=0;
            if (NowTree.Name == "advFinishDoc")//��д������
            {
                tid = Convert.ToInt32(CurrentNode.Name);
            }
            else//��������������
            {
                string sql = "select id from T_FOLLOW_RECORD  where patient_id=" + currentPatient.Id + " and text_type=" + CurrentNode.Name + "";
                tid = Convert.ToInt32(App.ReadSqlVal(sql, 0, "id"));
                if (tid ==0)
                    tid = App.GenId("T_FOLLOW_RECORD", "id");
            }
            return tid;
        }


        /// <summary>
        /// �½�����ҳǩ
        /// </summary>
        /// <param name="tid">record_id</param>
        /// <param name="IsFinishDoc">�Ƿ����������</param>
        private void CreateTabItem(int tid, bool IsFinishDoc)
        {
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Click += new EventHandler(page_Click);
            if (IsFinishDoc)
            {
                if (CurrentNode.Tag.GetType().ToString().Contains("Class_Follow_Patient"))
                {
                    Class_Follow_Patient a = CurrentNode.Tag as Class_Follow_Patient;
                    page.Name = tid.ToString() + ":" + a.Text_Type.ToString() + ":" + CurrentNode.Tag.ToString();
                }
                else
                {
                    Class_Follow_Text a = CurrentNode.Tag as Class_Follow_Text;
                    page.Name = tid.ToString() + ":" + a.Id.ToString() + ":" + CurrentNode.Tag.ToString();
                }
            }
            else
            {
                page.Name = tid.ToString() + ":" + CurrentNode.Name + ":0:" + CurrentNode.Tag.ToString();
            }
            page.Text = NowTree.SelectedNode.Text;
            page.Tag = currentPatient as object;

            string content = "";//��������
            if (IsFinishDoc)
            {
                content = App.ReadSqlVal("select doc_content from T_FOLLOW_RECORD_DOC t where record_id=" + tid + "", 0, "doc_content");
            }
            else
            {
                content = App.ReadSqlVal("select content from T_FOLLOW_TEMPPLATE_CONT where tid in (select tid from T_FOLLOW_TEMPPLATE where text_type=" + NowTree.SelectedNode.Name + ") and rownum=1", 0, "content");
            }

            if (content == null)
            {
                content = "";
            }
            
            frmText text = new frmText(0,  0, 0, tid.ToString(),0,currentPatient, true, true, "","");

            text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
            text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
            text.MyDoc.IgnoreLine = false;
            text.MyDoc.SetToolEvent();

            XmlDocument tmpxml = new System.Xml.XmlDocument();
            tmpxml.PreserveWhitespace = true;

            //û��ģ���ʱ�򣬴��յĽ���
            if (content.Contains("emrtextdoc"))
            {
                tmpxml.LoadXml(content);
            }
            else
            {
                tmpxml.LoadXml("<emrtextdoc/>");
                text.MyDoc.ClearContent();
                text.MyDoc.ToXML(tmpxml.DocumentElement);
            }

            text.MyDoc.FromXML(tmpxml.DocumentElement);
            text.MyDoc.ContentChanged();
            tabctpnDoc.Controls.Add(text);
            text.Dock = DockStyle.Fill;

            tabctpnDoc.TabItem = page;
            tabctpnDoc.Dock = DockStyle.Fill;
            page.AttachedControl = tabctpnDoc;
            this.tctlDoc.Controls.Add(tabctpnDoc);
            this.tctlDoc.Tabs.Add(page);
            this.tctlDoc.Refresh();
            this.tctlDoc.SelectedTab = page;

        }

       

        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            if (advFinishDoc.SelectedNode != null)
            {
                NowTree = sender as AdvTree;
                CurrentNode = advFinishDoc.SelectedNode;
                AddDoc(true);
            }
            
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            CurrentNode = NowTree.SelectedNode;
            bool flag = DocIsExistDB(CurrentNode.Name.ToString());
            AddDoc(flag);
        }



        void page_Click(object sender, EventArgs e)
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
        /// �ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (tctlDoc.SelectedTabIndex != -1)
                {
                    if (tctlDoc.SelectedPanel.Controls.Count > 0)
                    {
                        TabItem currentPage=tctlDoc.SelectedTab;

                        currentPatient = currentPage.Tag as InPatientInfo;
                        string something = currentPage.Name;
                        string[] something1 = something.Split(':');
                        string something2 = currentPage.Text;
                        bool isNewdoc=false;//�Ƿ��½�����

                        //�½����鱣��
                        if (something.Contains(":0:"))
                        {
                            isNewdoc = true;
                        }
                        string record_id = something1[0];//����id
                        string text_type = something1[1];//��������
                        string textName = something2;//������������
                        string record_time = DateTime.Now.ToString("yyyy-MM-dd");//doc_name
                        int MaxTimes = GetMaxTimes() + 1;//��ô���

                        string content=GetXmlContent();
                        string sql_record = "";
                        if (isNewdoc)
                        {
                            sql_record = "insert into T_FOLLOW_RECORD(id,patient_id,follow_times,solution_id,patient_state,lasttime,creator_id,text_type,doc_name,textname) values (" +
                                       "" + record_id + "," + currentPatient.Id + "," + MaxTimes + ",'" + Sid + "','" + currentPatient.State + "',to_date('" + record_time + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + "," + text_type + ",'" + record_time + "','" + something2 + "')";
                            currentPage.Name = currentPage.Name.Remove(currentPage.Name.IndexOf(":0:"), 2);
                        }
                        else
                        {
                            sql_record = "UPDATE T_FOLLOW_RECORD SET last_time = to_date('" + record_time + "','yyyy-MM-dd') ,doc_name='" + record_time + "', textname='" + something2 + "' WHERE id = " + record_id + "";
                        }
 
                        XmlDocument doc = new XmlDocument();
                        doc.PreserveWhitespace = true;
                        doc.LoadXml(content);
                        XmlElement xmlElement = doc.DocumentElement;
                        App.ExecuteSQL(sql_record);
                        App.ExecuteSQL("delete from T_FOLLOW_RECORD_DOC where record_id="+record_id+"");
                        string doc_sql = "insert into T_FOLLOW_RECORD_DOC values(" + record_id + ",:docContent)";
                        Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                        xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                        xmlPars[0].ParameterName = "docContent";
                        xmlPars[0].Value = doc.OuterXml;
                        xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                        xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                        int message = App.ExecuteSQL(doc_sql, xmlPars);
                        if (message > 0)
                        {
                            App.Msg("����ɹ�!");
                            IniFinishedDoc();
                        }
                    }
                }
            }
            catch
            { }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
            { }
        }

        private void advFinishDoc_Click(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            CurrentNode = NowTree.SelectedNode;
        }

        private void advAllDoc_Click(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            CurrentNode = NowTree.SelectedNode;
        }

        private void tctlDoc_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0)
                {
                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (tempEditor != null)
                    {
                        string something = tctlDoc.SelectedTab.Name;
                        string[] something1 = something.Split(':');

                        string text_id = something1[1];
                        IniRelatedDoc(text_id);
                    }
                }
            }
        }

     

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnSave_Click(object sender, EventArgs e)
        //{

        //    if (IsScheme == "N")
        //    {
        //        //��trvFinishenDoc������ڵ�
        //        if (SelectedNode.Tag != null)
        //        {
        //            Class_Follow_Text clss = SelectedNode.Tag as Class_Follow_Text;
        //            if (SelectedNode.Nodes.Count == 0)
        //            {
        //                if (clss.Issimpleinstance == "1")
        //                {
        //                    if (trvFinishedDoc.Nodes[0].Nodes.Count != 0)
        //                    {
        //                        foreach (TreeNode nd in trvFinishedDoc.Nodes[0].Nodes)
        //                        {
        //                            if (nd.Text == clss.Textname)
        //                            {
        //                                App.Msg("�Ѵ��ڸ�������");
        //                                return;
        //                            }
        //                        }
        //                    }

        //                    string nodename = trvFinishedDoc.Nodes[0].Text;
        //                    TreeNode node = new TreeNode();

        //                    string time = DateTime.Now.ToString("yyyy-MM-dd");

        //                    int record_id = App.GenId("T_FOLLOW_RECORD", "id");
        //                    int doc_id = App.GenId("T_FOLLOW_RECORD_DOC", "id");
        //                    int MaxTimes = GetMaxTimes() + 1;
        //                    node.Name = doc_id.ToString();
        //                    node.Text = clss.Textname;
        //                    trvFinishedDoc.Nodes[0].Nodes.Add(node);
        //                    //���ݿ����
        //                    try
        //                    {
        //                        string record_sql = "insert into T_FOLLOW_RECORD values(" + record_id + "," + Pid + "," + MaxTimes + ",'" + clss.Textname + "'," + clss.Id + "," + Sid + ",0,to_date('" + time + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + ")";
        //                        App.ExecuteSQL(record_sql);
        //                        string temp = GetXmlContent();
        //                        XmlDocument doc = new XmlDocument();
        //                        doc.PreserveWhitespace = true;
        //                        doc.LoadXml(temp);
        //                        XmlElement xmlElement = doc.DocumentElement;
        //                        string doc_sql = "insert into T_FOLLOW_RECORD_DOC values(" + record_id + ",:docContent)";
        //                        Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
        //                        xmlPars[0] = new Bifrost.WebReference.OracleParameter();
        //                        xmlPars[0].ParameterName = "docContent";
        //                        xmlPars[0].Value = doc.OuterXml;
        //                        xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
        //                        xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
        //                        int message = App.ExecuteSQL(doc_sql, xmlPars);
        //                        if (message != 0)
        //                        {
        //                            App.Msg("����ɹ���");
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        App.MsgErr(ex.Message);
        //                    }
        //                }
        //                else
        //                {
        //                    int isFirst = 0;        //����Ƿ�����������д����������
        //                    string time = DateTime.Now.ToString("yyyy-MM-dd");
        //                    int record_id = App.GenId("T_FOLLOW_RECORD", "id");
        //                    int doc_id = App.GenId("T_FOLLOW_RECORD_DOC", "id");
        //                    int MaxTimes = GetMaxTimes()+1;
        //                    if (trvFinishedDoc.Nodes[1].Nodes.Count != 0)
        //                    {
        //                        foreach (TreeNode nd in trvFinishedDoc.Nodes[1].Nodes)
        //                        {
        //                            TreeNode temp = new TreeNode();
        //                            if (nd.Text == clss.Textname.ToString())
        //                            {
        //                                isFirst = 1;

        //                                temp.Name = doc_id.ToString();
        //                                temp.Text = time;
        //                                nd.Nodes.Add(temp);
        //                                break;

        //                            }
        //                        }
        //                    }
        //                    if (isFirst == 0)
        //                    {
        //                        //һ���ڵ�
        //                        TreeNode temp = new TreeNode();
        //                        temp.Text = clss.Textname;
        //                        trvFinishedDoc.Nodes[1].Nodes.Add(temp);
        //                        //�����ڵ�
        //                        TreeNode node = new TreeNode();
        //                        node.Text = time;
        //                        node.Name = doc_id.ToString();
        //                        temp.Nodes.Add(node);
        //                    }
        //                    try
        //                    {
        //                        string record_sql = "insert into T_FOLLOW_RECORD values(" + record_id + "," + Pid + "," + MaxTimes + ",'" + clss.Textname + "'," + clss.Id + "," + Sid + ",0,to_date('" + time + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + ")";
        //                        App.ExecuteSQL(record_sql);
        //                        string temp = GetXmlContent();
        //                        XmlDocument doc = new XmlDocument();
        //                        doc.PreserveWhitespace = true;
        //                        doc.LoadXml(temp);
        //                        XmlElement xmlElement = doc.DocumentElement;
        //                        string doc_sql = "insert into T_FOLLOW_RECORD_DOC values(" + record_id + ",:docContent)";
        //                        Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
        //                        xmlPars[0] = new Bifrost.WebReference.OracleParameter();
        //                        xmlPars[0].ParameterName = "docContent";
        //                        xmlPars[0].Value = doc.OuterXml;
        //                        xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
        //                        xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
        //                        int message = App.ExecuteSQL(doc_sql, xmlPars);
        //                        if (message != 0)
        //                        {
        //                            App.Msg("����ɹ���");
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        App.MsgErr(ex.Message);
        //                    }

        //                }
        //            }
        //        }
        //        //��ԭ�нڵ��޸�����
        //        else
        //        {
        //            if (SelectedNode.Name != "")
        //            {
        //                string id = SelectedNode.Name;
        //                string time = DateTime.Now.ToString("yyyy-MM-dd");
        //                if (SelectedNode.Parent.Text == "��������")
        //                {
        //                    int rid=-1;
        //                    if (GetRecordId(id) > 0)
        //                        rid = GetRecordId(id);
        //                    if (rid < 0)
        //                        return;
        //                    try
        //                    {
        //                        string sql_uprecord = "update T_FOLLOW_RECORD set lasttime=to_date('" + time + "','yyyy-MM-dd') where id=" + rid + "";
        //                        App.ExecuteSQL(sql_uprecord);
        //                        string temp = GetXmlContent();
        //                        XmlDocument doc = new XmlDocument();
        //                        doc.PreserveWhitespace = true;
        //                        doc.LoadXml(temp);
        //                        XmlElement xmlElement = doc.DocumentElement;
        //                        string sql_updoc = "update T_FOLLOW_RECORD_DOC set doc_name=:docContent where id=" + id + " ";
        //                        Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
        //                        xmlPars[0] = new Bifrost.WebReference.OracleParameter();
        //                        xmlPars[0].ParameterName = "docContent";
        //                        xmlPars[0].Value = doc.OuterXml;
        //                        xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
        //                        xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
        //                        int message = App.ExecuteSQL(sql_updoc, xmlPars);
        //                        if (message != 0)
        //                        {
        //                            App.Msg("����ɹ���");
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        App.MsgErr(ex.Message);
        //                    }
        //                }
        //                //��������
        //                else
        //                {
        //                    int rid=-1;
        //                    if (GetRecordId(id) > 0)
        //                        rid = GetRecordId(id);
        //                    if (rid < 0)
        //                        return;
        //                    try
        //                    {
        //                        string sql_uprecord = "update T_FOLLOW_RECORD set lasttime=to_date('" + time + "','yyyy-MM-dd') where id=" + rid + "";
        //                        App.ExecuteSQL(sql_uprecord);
        //                        string temp = GetXmlContent();
        //                        XmlDocument doc = new XmlDocument();
        //                        doc.PreserveWhitespace = true;
        //                        doc.LoadXml(temp);
        //                        XmlElement xmlElement = doc.DocumentElement;
        //                        string sql_updoc = "update T_FOLLOW_RECORD_DOC set doc_name=:docContent ,doc_name='"+time+"' where id=" + id + " ";
        //                        Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
        //                        xmlPars[0] = new Bifrost.WebReference.OracleParameter();
        //                        xmlPars[0].ParameterName = "docContent";
        //                        xmlPars[0].Value = doc.OuterXml;
        //                        xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
        //                        xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
        //                        int message = App.ExecuteSQL(sql_updoc, xmlPars);
        //                        if (message != 0)
        //                        {
        //                            App.Msg("����ɹ���");
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        App.MsgErr(ex.Message);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (TreeNode node in trvAllDoc.Nodes)
        //        {
        //            if (node.Checked&&node.Nodes.Count==0)
        //            {
        //                if (rtnTypeIds == "")
        //                {
        //                    rtnTypeIds = node.Name;
        //                    rtnTypeNames = node.Text;
        //                }
        //                else
        //                {
        //                    rtnTypeIds += "," + node.Name;
        //                    rtnTypeNames += "," + node.Text;
        //                }
        //            }
        //            CheckTree(node);
        //        }
        //        this.Close();          
        //    }
        //}
        /// <summary>
        /// ��ȡ��ؽڵ��Record_Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
           
           ////��������ļ���
           // string sql_sigle = "select * from T_FOLLOW_RECORD_DOC where text_type in (select id from T_FOLLOW_TEXT where issimpleinstance=1) and record_id in (select id from T_FOLLOW_RECORD where patient_id=" + Pid + " and solution_id=" + Sid + ")";
           // DataSet ds_single = App.GetDataSet(sql_sigle);
           // TreeNode single = new TreeNode();
           // single.Text = "��������";
           // //trvFinishedDoc.Nodes.Add(single);
           // for (int i = 0; i < ds_single.Tables[0].Rows.Count; i++)
           // {
           //     TreeNode temp = new TreeNode();
           //     temp.Name = ds_single.Tables[0].Rows[i]["id"].ToString();
           //     temp.Text = ds_single.Tables[0].Rows[i]["Doc_Name"].ToString();
           //     single.Nodes.Add(temp);
           // }
           // //�����������
           // string sql_multi = "select a.id as �����,record_id,doc_name,textname from T_FOLLOW_RECORD_DOC a join T_FOLLOW_TEXT b on a.text_type=b.id "
           // + "where record_id in (select id from T_FOLLOW_RECORD where patient_id=" + Pid + " and solution_id=" + Sid + ") and b.issimpleinstance=0";
           // DataSet ds_multi = App.GetDataSet(sql_multi);
           // TreeNode multi = new TreeNode();
           // multi.Text = "��������";
           // //trvFinishedDoc.Nodes.Add(multi);
           // int isExsit = 0;
           // for (int j = 0; j < ds_multi.Tables[0].Rows.Count; j++)
           // {
           //     TreeNode temp = new TreeNode();
           //     temp.Text = ds_multi.Tables[0].Rows[j]["textname"].ToString();
           //     foreach (TreeNode nd in multi.Nodes)
           //     {
           //         if (temp.Text == nd.Text)
           //         {
           //             isExsit = 1;
           //             break;
           //         }
           //     }
           //     if (isExsit == 0)
           //     {
           //         multi.Nodes.Add(temp);
           //         for (int k = 0; k < ds_multi.Tables[0].Rows.Count; k++)
           //         {
           //             TreeNode node = new TreeNode();
           //             if (temp.Text == ds_multi.Tables[0].Rows[k]["Textname"].ToString())
           //             {
           //                 node.Text = ds_multi.Tables[0].Rows[k]["Doc_name"].ToString();
           //                 node.Name = ds_multi.Tables[0].Rows[k]["�����"].ToString();
           //                 temp.Nodes.Add(node);
           //             }
           //         }
           //     }
           // }
    }
}