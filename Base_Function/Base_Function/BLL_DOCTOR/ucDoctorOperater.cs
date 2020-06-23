using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Bifrost;
using TextEditor;
using System.Xml;
using System.Collections;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_NURSE.NBlood_sugarRecord;
using Base_Function.BLL_NURSE.Nereuse_record;
using Base_Function.BLL_NURSE.Tempreture_Management;
using Base_Function.BLL_NURSE.First_cases;
using Base_Function.BLL_NURSE.SickInformational;
//using Base_Function.BLL_NURSE.Nurse_observes;
using Base_Function.MODEL;
using Base_Function.BLL_NURSE.Odinopoeia_Record;
using Base_Function.BLL_NURSE.Expectant_Record;
using Base_Function.TEMPERATURES;
using Base_Function.TEMPLATE;
using Base_Function.BLL_NURSE.Nurse_Record;
using Paint;
using Moran.Partogram;
using System.Drawing.Imaging;
using System.Diagnostics;
using MoranEditor.GUI;
using ZYCommon;
using TextEditor.TextDocument.Document;
using TempertureEditor.Tempreture_Management;
using Base_Function.BLL_DOCTOR.Patient_Action_Manager;

namespace Base_Function.BLL_DOCTOR
{
    public partial class ucDoctorOperater : UserControl
    {

        /// <summary>
        /// ��ǰ���˶��� 
        /// </summary>
        public InPatientInfo currentPatient;
        private string Record_Time = null;
        private string Record_Content = null;
        private static Node CurrentNode = new Node();
        /// <summary>
        /// ��Ȩ����Ȩ��
        /// </summary>
        public string OperateState;
        /// <summary>
        /// �Ƿ��Ƕ��Ƶ�����
        /// </summary>
        private bool isCustom = false;
        public static bool flagmark = false;
        public static bool flagtq=false;
        /// <summary>
        /// ����ʱ��ѡ����ķ���ֵ�����ȷ������True�����ȡ������false
        /// </summary>
        public static bool isFlagtrue = false;

        public delegate void DeleGetRecord(string time, string content);

        /// <summary>
        /// ��ʵ�����鱣��ɹ��󣬷�������id
        /// </summary>
        private string book_Id = "";

        /// <summary>
        /// ���ҳ���޸ĵ�����id
        /// </summary>
        private string Update_Tid = null;

        /// <summary>
        /// �����ύ��������id
        /// </summary>
        private ArrayList save_TextId = new ArrayList();

        /// <summary>
        /// ���󲡳̼�¼�Ƿ����ӽڵ�
        /// </summary>
        bool isChildNode = false;


        /// <summary>
        /// ���鲻��ɾ����ԭ��
        /// </summary>
        string delBookReason = "";

        /// <summary>
        /// ģ����ȡ
        /// </summary>
        ucTemplateListGet ucTemp;

        /// <summary>
        /// ��������鼯��
        /// </summary>
        private Node BrowseNodes;

        /// <summary>
        /// �Ƿ�ֱ�ӵ�������ť��ʾ true �� false ��
        /// </summary>
        private bool ClickShow = true;

        /// <summary>
        /// ������������
        /// </summary>
        private DataTable patientsDocs;

    

        /// <summary>
        /// ���°󶨰�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PageSelectChange(object sender, TabStripTabChangedEventArgs e)
        {
            tctlDoc_SelectedTabChanged(sender, e);
        }

        /// <summary>
        /// ģ��˫������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Template_Doubleclick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tctlDoc.SelectedPanel.Controls.Count; i++)
                {
                    if (tctlDoc.SelectedPanel.Controls[i].GetType().ToString().Contains("frmText"))
                    {
                        frmText trmptext = (frmText)tctlDoc.SelectedPanel.Controls[i];
                        if (ucTemp.Temptype == "S")
                        {
                            //int lastIndex = ucTemp.LoadContent.LastIndexOf("span");
                            //string strValues = ucTemp.LoadContent.Substring(0, lastIndex + 5);
                            trmptext.MyDoc._insertElements("<a>" + ucTemp.LoadContent + "</a>");
                        }
                        else
                        {
                            if (ucTemp.LoadContent.Contains("emrtextdoc"))
                            {
                                trmptext.MyDoc.ClearContent();
                                XmlDocument tempxmldoc = new XmlDocument();
                                tempxmldoc.PreserveWhitespace = true;
                                tempxmldoc.LoadXml(ucTemp.LoadContent);
                                //DataInit.filterInfo(tempxmldoc.DocumentElement, currentPatient, trmptext.MyDoc.Us.TextKind_id, trmptext.MyDoc.Us.Tid);
                                Class_Text select_text;

                                //tctlDoc.SelectedTab.Name = "125;Bifrost.Class_Text";

                                //66190;Bifrost.Patient_Doc


                                //if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                                //{
                                //    select_text = NowTree.SelectedNode.Tag as Class_Text;
                                //}
                                //else
                                //{
                                //    select_text = NowTree.SelectedNode.Parent.Tag as Class_Text;
                                //}

                                select_text = new Class_Text();

                                string id = tctlDoc.SelectedTab.Name.Split(';')[0].ToString();

                                if (tctlDoc.SelectedTab.Name.Contains("Bifrost.Class_Text"))
                                {
                                    DataSet ds = App.GetDataSet("select a1.id,a1.textname,a1.ishavetime from t_text a1 where a1.id=" + id + "");

                                    select_text.Id = Convert.ToInt32(tctlDoc.SelectedTab.Name.Split(';')[0].ToString());
                                    select_text.Textname = ds.Tables[0].Rows[0]["textname"].ToString();
                                    select_text.Ishavetime = ds.Tables[0].Rows[0]["ishavetime"].ToString();
                                }
                                else
                                {
                                    DataSet ds = App.GetDataSet("select a1.id,a1.textname,a1.ishavetime from t_text a1 inner join t_patients_doc b1 on a1.id=b1.textkind_id where b1.tid=" + id + "");
                                    select_text.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                                    select_text.Textname = ds.Tables[0].Rows[0]["textname"].ToString();
                                    select_text.Ishavetime = ds.Tables[0].Rows[0]["ishavetime"].ToString();
                                }

                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                {
                                    if (bodyNode.Name == "body")
                                    {
                                        if (select_text.Ishavetime != "")
                                        {
                                            int tid = trmptext.MyDoc.Us.Tid;
                                            string strval = App.ReadSqlVal("select t.textname from t_quality_text t where t.tid=" + tid + "", 0, "textname");
                                            if (strval == null)
                                            {

                                                if (Record_Time == "")
                                                {
                                                    Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                                }

                                                if (Record_Content == "")
                                                {
                                                    Record_Content = select_text.Textname;
                                                }
                                            }
                                            else
                                            {
                                                if (tid != 0)
                                                {
                                                    Record_Time = strval;
                                                    Record_Content = "";
                                                }
                                            }
                                            if (select_text.Ishavetime == "B")
                                            {
                                                bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                            }
                                            else if (select_text.Ishavetime == "A")
                                            {
                                                bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                            }
                                        }
                                        XmlElement bodyEle = bodyNode as XmlElement;
                                    }
                                }

                                string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, tempxmldoc.OuterXml, currentPatient);

                                tempxmldoc.LoadXml(content);

                                trmptext.MyDoc.FilterXml(tempxmldoc.OuterXml, 1, null);

                                //����ģ���ļ�
                                DataInit.filterInfo(tempxmldoc.DocumentElement, Convert.ToInt32(select_text.Id));
                                DataInit.filterInfo(tempxmldoc.DocumentElement, currentPatient, trmptext.MyDoc.Us.TextKind_id, trmptext.MyDoc.Us.Tid);
                                trmptext.MyDoc.FromXML(tempxmldoc.DocumentElement);
                            }
                            else
                            {
                                trmptext.MyDoc.FilterXml(ucTemp.LoadContent, 1, null);
                                trmptext.MyDoc.SaveLogs.Clear();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string bug = ex.Message;

            }
        }

        public ucDoctorOperater()
        {
            InitializeComponent();
            DataInit.strid = "";
            ucDoctorOperater.flagmark = false;          
        }

        public ucDoctorOperater(InPatientInfo patientInfo)
        {
            InitializeComponent();               
            dockContainerItem_FinishDoc.Selected = true;;//���Ĭ��ѡ��'��д����'
            DataInit.CurrentFrmText = null;
            currentPatient = patientInfo;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "�������";
            dockContainerItem2.Text = "ģ����ȡ";
            ucTemp = new ucTemplateListGet();
            ucTemp.Dock = DockStyle.Fill;
            ucTemp.TemplateSelect += new EventHandler(Template_Doubleclick);
            panelDockContainer2.Controls.Add(ucTemp);
            DataInit.ReflashBookTree(DataInit.temptrvbook);
            DataInit.strid = patientInfo.Id.ToString();
            ucDoctorOperater.flagmark = false;
            for (int i = 0; i < DataInit.temptrvbook.Nodes.Count; i++)
            {
                advAllDoc.Nodes.Add(DataInit.temptrvbook.Nodes[i].DeepCopy());
            }
            //��ȡ��ǰ���˵��������
            DataInit.GetPatientType(patientInfo.Id.ToString());
            ReflashTrvBook();//ˢ��������  
            advAllDoc.ExpandAll();
            barTemplate.Hide();
          

            if ((App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N") || currentPatient.PatientState == "����")
            {
                /*
                 * �����ҽ����ʿ�˺ŵ�½�Ļ�ֻ�ܲ鿴����
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            //�������������
            InitAutoCompleteCustomSource(txtSearchAllText);
        }
        //public void IniMainToobar()
        //{

        //    //��ϱ༭
        //    ButtonItem btnInsertDiosgin = new ButtonItem();
        //    btnInsertDiosgin.AutoCheckOnClick = true;
        //    btnInsertDiosgin.BeginGroup = false;
        //    btnInsertDiosgin.Image = global::Base_Function.Resource.��ϱ༭;
        //    btnInsertDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        //    btnInsertDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
        //    btnInsertDiosgin.Name = "btnInsertDiosgin";
        //    btnInsertDiosgin.OptionGroup = "Color";
        //    btnInsertDiosgin.Text = "��ϱ༭";
        //    btnInsertDiosgin.ThemeAware = true;
        //    btnInsertDiosgin.Tooltip = "��ϱ༭";
        //    btnInsertDiosgin.Click += new System.EventHandler(this.btnInsertDiosgin_Click);

        //    //ˢ�����
        //    ButtonItem btnRefreshDiosgin = new ButtonItem();
        //    btnRefreshDiosgin.AutoCheckOnClick = true;
        //    btnRefreshDiosgin.BeginGroup = false;
        //    btnRefreshDiosgin.Image = global::Base_Function.Resource.ˢ�����;
        //    btnRefreshDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        //    btnRefreshDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
        //    btnRefreshDiosgin.Name = "btnRefreshDiosgin";
        //    btnRefreshDiosgin.OptionGroup = "Color";
        //    btnRefreshDiosgin.Text = "ˢ�����";
        //    btnRefreshDiosgin.ThemeAware = true;
        //    btnRefreshDiosgin.Tooltip = "ˢ�����";
        //    btnRefreshDiosgin.Click += new System.EventHandler(this.btnRefreshDiosgin_Click);
            
            //App.MainToolBar.Items.Clear();
            //App.MainToolBar.Items.Add(btnInsertDiosgin);//��ϱ༭
            //App.MainToolBar.Items.Add(btnRefreshDiosgin);//ˢ�����
        //}
        /// <summary>
        /// ������Ȩ�������
        /// </summary>
        /// <param name="patientInfo">��Ȩ������Ϣ</param>
        /// <param name="State">��Ȩ����</param>
        public ucDoctorOperater(InPatientInfo patientInfo, string operateState)
        {
            InitializeComponent();
            dockContainerItem_FinishDoc.Selected = true;//���Ĭ��ѡ��'��д����'
            currentPatient = patientInfo;
            OperateState = operateState;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "��д����";
            dockContainerItem2.Text = "ģ����ȡ";
            ucTemp = new ucTemplateListGet();
            ucTemp.Dock = DockStyle.Fill;
            ucTemp.TemplateSelect += new EventHandler(Template_Doubleclick);
            panelDockContainer2.Controls.Add(ucTemp);
            DataInit.ReflashBookTree(DataInit.temptrvbook);
            for (int i = 0; i < DataInit.temptrvbook.Nodes.Count; i++)
            {
                advAllDoc.Nodes.Add(DataInit.temptrvbook.Nodes[i].DeepCopy());
            }
            DataInit.strid = patientInfo.Id.ToString();
            ucDoctorOperater.flagmark = false;
            //��ȡ��ǰ���˵��������
            DataInit.GetPatientType(patientInfo.Id.ToString());
            ReflashTrvBook();//ˢ��������  
            advAllDoc.ExpandAll();
            barTemplate.Hide();

            if (App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N")
            {
                /*
                 * �����ҽ����ʿ�˺ŵ�½�Ļ�ֻ�ܲ鿴����
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            if (operateState.Contains("����"))
            {
                //advAllDoc.Visible = true;
                dockContainerItem_AllDoc.Enabled = true;
            }
            else if (operateState.Contains("��¼"))
            {
                dockContainerItem_AllDoc.Enabled = true;
            }
            else
            {
                //advAllDoc.Visible = false;
                dockContainerItem_AllDoc.Enabled = false;
            }
            //�������������
            InitAutoCompleteCustomSource(txtSearchAllText);
        }

        public string mark_two = "0";

        public ucDoctorOperater(InPatientInfo patientInfo, string operateState, string strMark, string strMark_two)
        {
            InitializeComponent();
         
            //InitializeComponent();
            dockContainerItem_FinishDoc.Selected = true;//���Ĭ��ѡ��'��д����'
            currentPatient = patientInfo;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "�������";

            dockContainerItem2.Text = "ģ����ȡ";
            ucTemp = new ucTemplateListGet();
            ucTemp.Dock = DockStyle.Fill;
            ucTemp.TemplateSelect += new EventHandler(Template_Doubleclick);
            panelDockContainer2.Controls.Add(ucTemp);
            DataInit.ReflashBookTree(DataInit.temptrvbook);
            DataInit.strid = patientInfo.Id.ToString();
            ucDoctorOperater.flagmark = false;
            for (int i = 0; i < DataInit.temptrvbook.Nodes.Count; i++)
            {
                advAllDoc.Nodes.Add(DataInit.temptrvbook.Nodes[i].DeepCopy());
            }
            ReflashTrvBook();//ˢ��������  
            advAllDoc.CollapseAll();
            //advAllDoc.ExpandAll();
            barTemplate.Hide();

            if ((App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N") || currentPatient.PatientState == "����")
            {
                /*
                 * �����ҽ����ʿ�˺ŵ�½�Ļ�ֻ�ܲ鿴����
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            //�������������
            InitAutoCompleteCustomSource(txtSearchAllText);
            mark_two = strMark_two;
            
        }
        #region ��д�������

        /// <summary>
        /// ������������
        /// </summary>
        public void AddFinishNode()
        {

            Bifrost.WebReference.Class_Table[] tablesqls = new Bifrost.WebReference.Class_Table[4];
            tablesqls[0] = new Bifrost.WebReference.Class_Table();

            tablesqls[0].Sql = "select id from t_text where parentid in (103,525)";    //���й����ڲ��̵�С�ڵ�
            tablesqls[0].Tablename = "textbcs";

            tablesqls[1] = new Bifrost.WebReference.Class_Table();

            tablesqls[1].Sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,m.user_name, a.textname," +
                                         "a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid," +
                                         "a.israplacehightdoctor,a.OPERATEID,a.CHARGE_DOCTOR_ID,a.CHIEF_DOCTOR_ID,a.RESIDENT_DOCTOR_ID,a.israplacehightdoctor2,a.SECTION_NAME,operateid,charge_doctor_id,chief_doctor_id,a.bed_no,t.isproblem_name,t.isproblem_time,t.ISNEWPAGE  " +
                                         "from t_patients_doc a left join t_text t on a.textkind_id=t.id left join t_userinfo m on a.operateid = m.user_id" +
                                         " where a.patient_Id='" + currentPatient.Id + "' order by a.doc_name";  //��ȡ���˵���������

            tablesqls[1].Tablename = "patientdocs";

            //tablesqls[2] = new Bifrost.WebReference.Class_Table();
            //tablesqls[2].Sql = "select * from cover_info t where t.patient_id ='" + currentPatient.Id + "'";    //���й����ڲ��̵�С�ڵ�
            //tablesqls[2].Tablename = "caseFirst";

            tablesqls[2] = new Bifrost.WebReference.Class_Table();
            tablesqls[2].Sql = "select * from t_care_doc t where t.inpatient_id ='" + currentPatient.Id + "'";    //���й����ڲ��̵�С�ڵ�
            tablesqls[2].Tablename = "careDoc";

            tablesqls[3] = new Bifrost.WebReference.Class_Table();
            tablesqls[3].Sql = "select * from t_temperature_info t where t.patient_id ='" + currentPatient.Id + "'";    //���й����ڲ��̵�С�ڵ�
            tablesqls[3].Tablename = "temperatureDoc";


            DataSet dstextbc = App.GetDataSet(tablesqls);
            //DataTable table_textnotbc = dstextbc.Tables["textnobc"];
            DataTable table_textbc = dstextbc.Tables["textbcs"];
            DataTable table_patientsdocs = dstextbc.Tables["patientdocs"];
            //DataTable table_caseFirst = dstextbc.Tables["caseFirst"];
            DataTable table_careDoc = dstextbc.Tables["careDoc"];
            DataTable table_temperatureDoc = dstextbc.Tables["temperatureDoc"];
            //DataTable table_textblc = dstextbc.Tables["textblc"];
            patientsDocs = table_patientsdocs; //����ȫ������



            //ˢ���������ڵ�
            DataInit.ReflashBookTree(advFinishDoc, true);


            //������ؽڵ㣨�˲����ڰ󶨾����Ѿ�д��������֮ǰִ�У�
            DataInit.removeNode(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

            //////���ػ����¼�ж�������
            DataInit.removeNodeCareDoc(advFinishDoc.Nodes, table_careDoc, table_temperatureDoc);

            ////��д��������ݰ󶨵���������
            DataInit.getFinishedText(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

        }
        ///// <summary>
        ///// ������������
        ///// </summary>
        //public void AddFinishNode()
        //{         
        //    Node node = null;
        //    if (currentPatient != null)
        //    {
        //        node = DataInit.SelectDoc(currentPatient.Id);//�����д����
        //    }
        //    //ȡ�÷�סԺ���̼�¼���鸸�ڵ��ID��ƴ���ַ����Զ��Ÿ���
        //    string docStr = "";
        //    for (int i = 0; i < node.Nodes.Count; i++)
        //    {
        //        Patient_Doc doc = node.Nodes[i].Tag as Patient_Doc;
        //        if (doc != null)
        //        {
        //            if (docStr == "")
        //            {
        //                docStr = doc.Textkind_id.ToString();
        //            }
        //            else
        //            {
        //                docStr += "," + doc.Textkind_id;
        //            }
        //        }
        //    }
        //    Node tn_doctor = new Node();
        //    Node tn_nurse = new Node();

        //    tn_doctor.Text = "ҽ������";
        //    tn_nurse.Text = "��ʿ����";
        //    tn_doctor.Image = global::Base_Function.Resource.סԺ��¼;
        //    tn_nurse.Image = global::Base_Function.Resource.סԺ��¼;

        //    if (docStr != "")
        //    {
        //        //ҽ������
        //        DataInit.getDoctorFinishedText(ref tn_doctor, docStr);
        //    }
        //    //��ʿ
        //    DataInit.getNurseText(ref tn_nurse);

        //    advFinishDoc.Nodes.Add(tn_doctor);
        //    advFinishDoc.Nodes.Add(tn_nurse);
        //    string selSql = "select id,textname from t_text t where t.parentid=103";
        //    DataTable dtbc = App.GetDataSet(selSql).Tables[0];

        //    foreach (Node pNode in node.Nodes)
        //    {
        //        GetPatientDoc(advFinishDoc.Nodes, pNode, dtbc);
        //    }

        //}

        /// <summary>
        /// ����û����������
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="node"></param>
        public void RemoveBookNode(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name != "118" &&
                    nodes[i].Name != "2022")
                {
                    Node TempNode = nodes[i];

                    Class_Text text = TempNode.Tag as Class_Text;
                    if (text != null)
                    {
                        if (text.Isenable == "0")

                            if (text != null)
                            {
                                if (text.Issimpleinstance == "1")   //��������
                                {
                                    if (TempNode.Nodes.Count == 0)
                                    {
                                        TempNode.Remove();
                                        i--;
                                    }
                                }
                                else
                                {
                                    if (TempNode.Nodes.Count == 0)
                                    {
                                        if (TempNode.ImageIndex != 16)//== 17)   //�����ǰ��������ڵ������id��ͬ,˵���õ�ʵ�������Ѿ��������ˣ���ɫ���Ϊ��ɫ
                                        {
                                            TempNode.Remove();
                                            i--;
                                        }
                                    }
                                }
                            }
                    }
                    if (TempNode.Nodes.Count > 0)
                        RemoveBookNode(TempNode.Nodes);
                }
            }
        }
        #endregion


        /// <summary>
        /// ���������ݽڵ���뵽�����������
        /// </summary>
        /// <param name="nodes">�������</param>
        /// <param name="node">��������</param>
        public void GetPatientDoc(NodeCollection nodes, Node node, DataTable dtbc)
        {
            Patient_Doc doc = node.Tag as Patient_Doc;
            if (doc != null)
            {
                //�����β鷿��ʾ*��
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor == "Y")
                {
                    node.Text = "*" + doc.Docname;
                }
                //�����β鷿��ʾ��
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor2 == "Y")
                {
                    node.Text = "��" + doc.Docname;
                }
            }

            foreach (Node TempNode in nodes)
            {
                Class_Text text = TempNode.Tag as Class_Text;
                if (text != null)
                {
                    if (text.Id == 103)
                    {
                        //���̼�¼����
                        for (int i = 0; i < dtbc.Rows.Count; i++)
                        {
                            if (dtbc.Rows[i]["id"].ToString() == doc.Textkind_id.ToString())
                            {
                                //string sc = doc.Docname;
                                //string dv = "";
                                ////sc = sc.Remove(0, 5);
                                //dv = sc;
                                //if (dv.Length > 19)
                                //    dv = dv.Remove(16, dv.Length - 16);
                                //node.Text = dv + "   " + dtbc.Rows[i]["textname"].ToString();

                                if (doc.Submitted == "N")//�ݴ���ʾΪ��ɫ
                                {
                                    node.Style = elementStyleBlue;
                                    //node.Text += "(�ݴ�)";
                                }
                                else if (doc.Havedoctorsign == "N")//N��ʾ�ܴ�ҽ��δǩ�ֵ����飬��ʾΪ��ɫ
                                {
                                    //node.Style = elementStyleRed;
                                    //node.Text += "(ȱ�ܴ�ҽ��ǩ��)";
                                }
                                else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                                {
                                    if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                                    {
                                        //node.Style = elementStyleOrange;
                                        //node.Text += "(ȱ�ϼ�ҽʦǩ��)";
                                    }
                                }
                                TempNode.Nodes.Add((Node)node.DeepCopy());
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (text.Issimpleinstance == "1")   //��������
                        {
                            if (doc.Textkind_id == text.Id)//|| text.Id == 103) //�����ǰ��������ڵ������id��ͬ���ͰѸ�����������ڵ������
                            {

                                if (doc.Submitted == "N")//�ݴ���ʾΪ��ɫ
                                {
                                    node.Style = elementStyleBlue;
                                    //node.Text += "(�ݴ�)";
                                }
                                else if (doc.Havedoctorsign == "N")//N��ʾ�ܴ�ҽ��δǩ�ֵ����飬��ʾΪ��ɫ
                                {
                                    //node.Style = elementStyleRed;
                                    //node.Text += "(ȱ�ܴ�ҽ��ǩ��)";
                                }
                                else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                                {
                                    if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                                    {
                                        //node.Style = elementStyleOrange;
                                        //node.Text += "(ȱ�ϼ�ҽʦǩ��)";
                                    }
                                }
                                TempNode.Nodes.Add((Node)node.DeepCopy());
                                return;
                            }
                        }
                        else
                        {
                            if (TempNode.Nodes.Count == 0)
                            {
                                if (doc.Textkind_id == text.Id)// || text.Id == 103)   //�����ǰ��������ڵ������id��ͬ,˵���õ�ʵ�������Ѿ��������ˣ���ɫ���Ϊ��ɫ
                                {
                                    //TempNode.SelectedImageIndex = 16;
                                    TempNode.ImageIndex = 16;
                                    if (doc.Submitted == "N")//�ݴ���ʾΪ��ɫ
                                    {
                                        TempNode.Style = elementStyleBlue;
                                        //TempNode.Text += "(�ݴ�)";
                                    }
                                    else if (doc.Havedoctorsign == "N")//N��ʾ�ܴ�ҽ��δǩ�ֵ����飬��ʾΪ��ɫ
                                    {
                                        //TempNode.Style = elementStyleRed;
                                        //TempNode.Text += "(ȱ�ܴ�ҽ��ǩ��)";
                                    }
                                    else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                                    {
                                        if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                                        {
                                            //TempNode.Style = elementStyleOrange;
                                            //TempNode.Text += "(ȱ�ϼ�ҽʦǩ��)";
                                        }
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
                if (TempNode.Nodes.Count > 0)
                {
                    GetPatientDoc(TempNode.Nodes, node,dtbc);
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void FiltrateBook(NodeCollection nodes)
        {
            try
            {
                foreach (Node tempNode in nodes)
                {
                    Class_Text text = null;
                    if (tempNode != null)
                    {
                        text = tempNode.Tag as Class_Text;
                        if (text != null)
                        {
                            Node Parent = tempNode.Parent;
                            string currentSectionId = App.UserAccount.UserInfo.Section_id.ToString();
                            bool isDisplay = false;//�Ƿ���ʾ����
                            string[] sections = text.Sid.Split(',');
                            for (int j = 0; j < sections.Length; j++)
                            {
                                if (sections[j] == currentSectionId)
                                {
                                    isDisplay = true;
                                }
                            }
                            //���SID������0����SID�����ڵ�ǰ��¼ҽ���Ŀ���ID�������������
                            if (!isDisplay && text.Sid != "0")
                            {
                                string sql = "select * from t_patients_doc where textkind_id = " + text.Id + " and patient_id=" + currentPatient.Id;
                                DataSet ds = App.GetDataSet(sql);
                                if (ds != null)
                                {
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count == 0)     //�Ǳ��������飬����Ѿ���ʵ��������ڵĲ�ɾ��
                                    {
                                        tempNode.Remove();
                                        if (Parent != null)//�Ƴ��ڵ���������нڵ�����������仯������Ҫ�Ѹýڵ�ĸ��ڵ���±���
                                        {
                                            FiltrateBook(Parent.Nodes);
                                        }
                                    }
                                }
                            }

                        }
                        if (tempNode.Nodes.Count > 0)
                        {
                            FiltrateBook(tempNode.Nodes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }



        /// <summary>
        /// ˫�����Ƿ��Ƿ��Ϲ涨������
        /// </summary>
        /// <returns></returns>
        private bool isRightBook(Node node)
        {
            bool boolRight = false;
            if (NowTree.SelectedNode != null)
            {
                if (NowTree.SelectedNode.Nodes.Count > 0)
                {
                    if (NowTree.SelectedNode.Nodes[0].Tag.GetType().Name.Contains("Patient_Doc"))
                    {
                        boolRight = true;
                    }
                }
                else
                {
                    if (NowTree.SelectedNode.Tag != null)
                    {
                        if (NowTree.SelectedNode.Tag.GetType().Name.Contains("Class_Text") ||
                            NowTree.SelectedNode.Tag.GetType().Name.Contains("Patient_Doc"))
                        {
                            boolRight = true;
                        }
                    }
                }

            }
            return boolRight;
        }

        /// <summary>
        /// ��ǰѡ�еĽڵ㣬�Ƿ���tctlDoc.Tabs���������Ѿ����ڣ�����true,����false
        /// </summary>
        /// <param name="tid">�����id</param>
        /// <returns></returns>
        private bool IsSameTabItem(string tid, string cTime)
        {
            bool flag = false;
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                InPatientInfo inpatient = tctlDoc.Tabs[i].Tag as InPatientInfo;
                if (inpatient != null)
                {
                    if (currentPatient.Sick_Bed_Id == inpatient.Sick_Bed_Id)
                    {
                        string tabtid = "";
                        if (tctlDoc.Tabs[i].Name.Split(';').Length >= 4 && !tctlDoc.Tabs[i].Name.Contains("Class_Text"))
                        {
                            tabtid = tctlDoc.Tabs[i].Name.Split(';')[2];
                        }
                        else
                        {
                            tabtid = tctlDoc.Tabs[i].Name.Split(';')[0];
                        }
                        if (tabtid.Equals(tid))
                        {
                            if (tctlDoc.Tabs[i].Name.Split(';').Length <= 4
                                || (tctlDoc.Tabs[i].Name.Split(';').Length > 4 && tctlDoc.Tabs[i].Name.Split(';')[4] == cTime))
                            {
                                flag = true;
                                tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                                App.Msg("�Ѿ�������ͬ�����飡");
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// �жϸ��൥�������Ƿ��Ѿ�����
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">����id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "' ";
            //union select tid from t_care_doc  where textkind_id =" + id + " and inpatient_id='" + patient_id + "'
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

        /// <summary>
        /// ������������id������סԺ��pid���õ�����id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patient_id">����id</param>
        /// <returns></returns>
        private int getTidByTextIdAndPid(int id, string patient_id)
        {
            string sql = "select tid from  t_patients_doc where textkind_id=" + id + " and patient_id='" + patient_id + "'";
            int tid = Convert.ToInt32(App.ReadSqlVal(sql, 0, "tid"));
            return tid;
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
                        if (!item.Text.Contains("���"))
                        {
                            if (!IsCommit(item.Name))
                            {
                                //��֤�Ƿ�������
                                string doc_id = item.Name.Split(';')[0].ToString();
                                string sql = "select isenable from t_text where id=" + doc_id;
                                string isenable = App.ReadSqlVal(sql, 0, "isenable");
                                if (isenable == "1")
                                {
                                    isCustom = true;
                                }
                                else
                                {
                                    isCustom = false;
                                }
                                if (!isCustom) //���Ƕ��Ƶ�����
                                {
                                    DevComponents.DotNetBar.TabControlPanel tab = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                                    frmText t = tab.Controls[0] as frmText;

                                    if (t != null)
                                    {
                                        if (t.MyDoc.Modified) //�޸Ĺ����飬��ʾ��ʾ
                                        {


                                            if (App.Ask("�÷�����û���ύ���Ƿ�رգ�"))
                                            {
                                                //tctlDoc.AutoCloseTabs = true;
                                                //�ر����飬�������а�ť ,
                                                //Remove�����ᴥ��SelectedChecked�¼������ö�ѡ������Ĳ���Ȩ��,��Remove֮ǰִ�а�ť���ò���
                                                //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                                                //App.SetToolButtonByUser("ttsbtnPrint", false);
                                                //App.SetToolButtonByUser("tsbtnTempSave", false);
                                                //App.SetToolButtonByUser("tsbtnCommit", false);
                                                tctlDoc.Tabs.Remove(item);
                                            }
                                        }
                                        else
                                        {
                                            tctlDoc.Tabs.Remove(item);
                                            if (tctlDoc.Tabs.Count == 0)
                                            {
                                                App.SetToolButtonByUser("ttsbtnPrint", false);//
                                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                                                App.SetToolButtonByUser("tsbtnTempSave", false);
                                                App.SetToolButtonByUser("tsbtnCommit", false);
                                                App.SetToolButtonByUser("btnInsertDiosgin", false);
                                                App.SetToolButtonByUser("btnRefreshDiosgin", false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tctlDoc.Tabs.Remove(item);
                                    }
                                }
                                else
                                {
                                    tctlDoc.Tabs.Remove(item);
                                    //if (item.Text.Contains("�����¼��"))
                                    //{
                                    //    DevComponents.DotNetBar.TabControlPanel tab2 = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                                    //    MUcToolsControl mutc = tab2.Controls[0] as MUcToolsControl;
                                    //    if (mutc.MyDocument.Modifyed) //�޸Ĺ����飬��ʾ��ʾ
                                    //    {
                                    //        if (App.Ask("�÷ݻ����¼��û�б��棬�Ƿ�رգ�"))
                                    //        {
                                    //            tctlDoc.Tabs.Remove(item);
                                    //            if (!item.Text.Contains("����"))
                                    //            {
                                    //                IsLockBook("t_care_doc", currentPatient.Id, "0", App.UserAccount.UserInfo.User_id);
                                    //                UnlockNurseRecord(App.UserAccount.UserInfo.User_id);
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        tctlDoc.Tabs.Remove(item);
                                    //        if (!item.Text.Contains("����"))
                                    //        {
                                    //            IsLockBook("t_care_doc", currentPatient.Id, "0", App.UserAccount.UserInfo.User_id);
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    tctlDoc.Tabs.Remove(item);
                                    //}
                                }
                            }
                            else
                            {
                                tctlDoc.Tabs.Remove(item);
                                if (tctlDoc.Tabs.Count == 0)
                                {
                                    //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                                    App.SetToolButtonByUser("ttsbtnPrint", false);
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                                    App.SetToolButtonByUser("tsbtnTempSave", false);
                                    App.SetToolButtonByUser("tsbtnCommit", false);
                                    App.SetToolButtonByUser("tsbtnTemplateSave", false);//����ģ��
                                    App.SetToolButtonByUser("btnInsertDiosgin", false);
                                    App.SetToolButtonByUser("btnRefreshDiosgin", false);
                                }
                            }
                        }
                        else
                        {
                            //�ر����飬�������а�ť ,
                            //Remove�����ᴥ��SelectedChecked�¼������ö�ѡ������Ĳ���Ȩ��,��Remove֮ǰִ�а�ť���ò���
                            //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                            App.SetToolButtonByUser("ttsbtnPrint", false);
                            App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                            App.SetToolButtonByUser("tsbtnTempSave", false);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                            tctlDoc.Tabs.Remove(item);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
       
        /// <summary>
        /// �ж������Ƿ��ύ��
        /// </summary>
        /// <param name="textName">�����id</param>
        /// <returns>true�ύ,falseδ�ύ</returns>
        private bool IsCommit(string textName)
        {
            bool isCommit = false;
            for (int i = 0; i < save_TextId.Count; i++)
            {
                if (textName == save_TextId[i].ToString())
                {
                    isCommit = true;
                    save_TextId.RemoveAt(i);
                    break;
                }
            }
            return isCommit;
        }
        /// <summary>
        /// ��������¼ʱ�䣬��¼����
        /// </summary>
        /// <param name="time">��¼ʱ��</param>
        /// <param name="content">��¼����</param>
        private void GetDate(string time, string content)
        {
            this.Record_Time = time;
            this.Record_Content = content;
        }

        /// <summary>
        /// ���ñ��⣬סԺ���̼�¼������id=103,
        /// ���������������Ϊ���̼�¼;
        /// ����������ı��⣬�����������������ʾ
        /// </summary>
        /// <param name="node">��ǰ�ڵ�</param>
        /// <returns></returns>
        private string GetTextTitle(Node node)
        {
            string textTitle = "";
            try
            {
                Class_Text text = node.Tag as Class_Text;
                if (node != null)
                {
                    if (text != null)
                    {
                        textTitle = text.Textname;
                    }
                    else
                    {
                        textTitle = node.Text;
                    }
                }

                if (node.Parent != null)
                {
                    if (node.Parent.Parent != null)
                    {
                        if ((node.Parent.Name == "103") || node.Name == "103"  //סԺ���̼�¼����id
                            || (node.Parent.Parent != null && node.Parent.Parent.Name == "103"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134" ||
                               node.Parent.Parent.Name == "134")  //��ǰС��
                            {
                                textTitle = "����ǰС��";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "���̼�¼";
                            }
                            else
                            {
                                textTitle = "���̼�¼";
                            }
                        }
                        else
                        {
                            if (node.Tag.GetType().Name.Contains("Patient_Doc"))
                            {
                                textTitle = node.Parent.Text;
                            }
                            else
                            {
                                if (text != null)
                                {
                                    textTitle = text.Textname;
                                }
                                else
                                {
                                    textTitle = node.Text;
                                }
                                //textTitle = node.Text;
                            }
                            //textTitle = node.Text;
                        }
                        //return textTitle;
                    }
                    else
                    {
                        if (node.Parent.Name == "103" || (node.Name == "103" && node.Text == "סԺ���̼�¼"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134")//��ǰС��
                            {
                                textTitle = "����ǰС��";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "���̼�¼";
                            }
                            else
                            {
                                textTitle = "���̼�¼";
                            }
                        }
                        else
                        {
                            if (node.Tag.GetType().Name.Contains("Patient_Doc"))
                            {
                                textTitle = node.Parent.Text;
                            }
                            //else if (node.Parent.Name == "102")
                            //{
                            //    textTitle = frmTimeL.txtContent.Text;
                            //}
                            else
                            {
                                if (text != null)
                                {
                                    textTitle = text.Textname;
                                }
                                else
                                {
                                    textTitle = node.Text;
                                }
                                //textTitle = node.Text;
                            }
                        }
                        //return textTitle;
                    }
                }
                else
                {
                    //Class_Text text = node.Tag as Class_Text;
                    if (text != null)
                    {
                        if (text.Parentid.ToString() == "103" || text.Id.ToString() == "103")
                        {
                            if (text.Id.ToString() == "125" || text.Id.ToString() == "103")
                            {
                                textTitle = "���̼�¼";
                            }
                            else
                            {
                                textTitle = "���̼�¼";
                            }
                        }
                        else
                        {
                            textTitle = text.Textname;
                        }
                        if (text.Issimpleinstance == "0")
                        {

                            if (node.Text.Contains("(ȱ�ܴ�ҽ��ǩ��)"))
                            {
                                textTitle = textTitle.Replace("(ȱ�ܴ�ҽ��ǩ��)", "");
                            }
                            else if (node.Text.Contains("(ȱ�ϼ�ҽʦǩ��)"))
                            {
                                textTitle = textTitle.Replace("(ȱ�ϼ�ҽʦǩ��)", "");
                            }
                        }
                    }
                }

                if (textTitle == "��N����Ժ��¼")
                {
                    textTitle = node.Text.Remove(0, 12).Split('(')[0];
                }

            }
            catch (Exception)
            {
            }
            return textTitle;
        }

        /// <summary>
        /// �Ƿ���Ժ��Կ���
        /// </summary>
        /// <param name="node">��ǰѡ�еĽڵ�</param>
        /// <returns>true���ԣ�false������</returns>
        private bool IsNeglectLine(Node node)
        {
            bool NeglectLin = true;
            if (node != null)
            {
                if (node.Tag.ToString().Contains("Class_Text"))//����ڵ�
                {
                    Class_Text class_Text = node.Tag as Class_Text;
                    if (class_Text.Txxttype == "915")//֪��ͬ����
                    {
                        NeglectLin = false;
                    }
                }
                else if (node.Tag.ToString().Contains("Patient_Doc"))//�������ݽڵ�
                {
                    if (node.Parent != null)
                    {
                        Class_Text class_Text = node.Parent.Tag as Class_Text;
                        if (class_Text.Txxttype == "915")//֪��ͬ����
                        {
                            NeglectLin = false;
                        }
                    }
                }
            }
            return NeglectLin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textKind"></param>
        /// <returns></returns>
        private bool IsHomogeneityCase(string textKind,string textKind2,int patient_id)
        {
            bool ret = false;
            if (textKind.IndexOf(textKind2) >= 0)
            {
                string sql = " select distinct textkind_id  from t_patients_doc where  textkind_id in (" + textKind + ")  and patient_id=" + patient_id;
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ret = true;
                }
            }

            return ret;
        }


        private bool isSqjc(string textkind, int patient_id)
        {
            bool ret = false;
            if (textkind.Trim() == "151")
            {
                string sql = " select distinct textkind_id  from t_patients_doc where  textkind_id=47553058  and patient_id=" + patient_id;
                DataSet ds = App.GetDataSet(sql);
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                {
                    ret = true;
                }
            }
            return ret;
        }


        /// <summary>
        ///  �ж����������Ƿ�����ͬ���Ƶ����顣
        /// </summary>
        /// <returns></returns>
        private bool IsSameBookDoc()
        {
            bool flag = false;
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            if (this.currentPatient != null)
            {
                Node node = DataInit.SelectDoc(currentPatient.Id, NowTree.SelectedNode.Name);
                //��ǰ�������������
                string new_TextName = Record_Time + "   " + Record_Content;
                foreach (Node childNode in node.Nodes)
                {
                    Patient_Doc pdoc = childNode.Tag as Patient_Doc;
                    //�Ѿ����ڸ������������
                    string old_TextName = pdoc.Docname;
                    //if (new_TextName.Equals(old_TextName))
                    if (old_TextName.Contains(Record_Time))
                    {
                        flag = true;
                        App.Msg("�Ѿ�������ͬ�����飡");
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertDiosgin_Click(object sender, EventArgs e)
        {
            try
            {

                    //ÿ�ε������ϱ༭����ťʱ��ˢ�»�����������ҽʦ��
                    currentPatient = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString());
                    using (BLL_DIAGNOSE.frmDiagnoseSimple fds = new BLL_DIAGNOSE.frmDiagnoseSimple(currentPatient))
                    {
                        fds.ShowDialog();
                        RefreshTabDocDiagnose(2);//ֻˢ��δ�ύ����
                    }

                //}
            }
            catch (System.Exception ex)
            {
                //App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
            }
        }

        /// <summary>
        /// ˢ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshDiosgin_Click(object sender, EventArgs e)
        {
            try
            {
                //����Ҫ��¼˭����
                RefreshTabDocDiagnose(2);
            }
            catch (System.Exception ex)
            {
                //App.MsgWaring("�ð�ť����δ���û�����δ���ã�");
            }
        }

        //���ҳ����޸�����
        void MyDoc_OnBackTextId(object sender, BackEvenHandle e)
        {
            if (e.Style == 1)
            {
                if (e.Submit)
                {
                    //�����ύ�ɹ����޸ĵ�ǰ�򿪵�����tab.Name�����е�ֵ
                    if (e.Para != "0")
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                    }
                    string tabName = "";
                    for (int i = 0; i < tctlDoc.SelectedTab.Name.Split(';').Length; i++)
                    {
                        if (tabName == "")
                        {
                            tabName = tctlDoc.SelectedTab.Name.Split(';')[i];
                        }
                        else
                        {
                            if (i == 2)//����λ�������ID��0��ʾ�½����ĳɵ�ǰ������id
                            {
                                tabName += ";" + e.Para;
                            }
                            else
                            {
                                tabName += ";" + tctlDoc.SelectedTab.Name.Split(';')[i];
                            }
                        }
                    }
                    tctlDoc.SelectedTab.Name = tabName;
                    book_Id = e.Para;
                    if (e.User.TextKind_id == 119 ||    //��Ժ��¼
                        e.User.TextKind_id == 120 ||    //24Сʱ�����Ժ��¼
                        e.User.TextKind_id == 121 ||    //24Сʱ����Ժ������¼
                        e.User.TextKind_id == 122 ||    //�ٴΣ���Σ���Ժ��¼
                        e.User.TextKind_id == 123)      //����ר����Ժ��¼
                    { }
                    //SubmitDoc(e.XmlString);
                }
            }
            else if (e.Style == 4)
            {
                DataInit.MyDocStye = true;
                DataInit.saveDocument(sender, e);
                DataInit.MyDocStye = false;
            }
            else if (e.Style == 5)
            {
                if (App.UserAccount.CurrentSelectRole.Role_type != "D")     //ҽ��վ
                {
                    App.Msg("��ʾ: ֻ��ҽ�������޸�!");
                    return;
                }
                if (BrowseNodes.Nodes.Count > 0)
                {
                    for (int i = 0; i < BrowseNodes.Nodes.Count; i++)
                    {
                        //if (BrowseNodes.Nodes[i].Name == e.Para)
                        //{
                        //    advFinishDoc.SelectedNode = BrowseNodes.Nodes[i];
                        //}
                        Node tempnode = GetSelectDocNode(BrowseNodes.Nodes, e.Para);

                        if (tempnode != null)
                        {
                            advFinishDoc.SelectedNode = tempnode;
                        }
                        else
                        {
                            //CurrentNode = NowTree.SelectedNode;
                            //SetSelectNode(BrowseNodes.Nodes, e.Para);
                        }

                    }
                }
                else
                {
                    if (BrowseNodes.Name == e.Para)
                    {
                        advFinishDoc.SelectedNode = BrowseNodes;
                    }
                }
                CreateTabItem(Convert.ToInt32(e.Para));
                ClickShow = false;
            }
            else
            {
                bool flag = false;  //��ǰ�ʺŶԸ÷������Ƿ�����д��Ȩ��
                Class_Text text = advAllDoc.SelectedNode.Tag as Class_Text;
                ArrayList list = App.Get_Text_Button_Rights(text.Id, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                for (int i = 0; i < list.Count; i++)
                {
                    string Button_Write = list[i] as string;
                    //App.Text_Rights_Set(Convert.ToInt32(e.Para),Convert.ToInt32(currentPatient.Sick_Doctor_Id),currentPatient.Sick_Group_Id);
                    if (Button_Write == "tsbtnWrite")    //�жϸõ�¼�ʺ��Ƿ��д����÷������Ȩ��
                    {
                        //��������
                        Rethreee_CreateTab(e.Para);
                        flag = true;
                        break;
                    }
                }
                Update_Tid = e.Para;
                if (!flag)
                    App.Msg("����û����д�÷������Ȩ�ޣ�");
            }
        }

        /// <summary>
        /// ��ȡ�������ʱ��Ҫ�޸�ѡ�еĽڵ�
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private Node GetSelectDocNode(NodeCollection nodes, string nodeName)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name == nodeName)
                {
                    return nodes[i];
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    return GetSelectDocNode(nodes[i].Nodes, nodeName);
                }
            }
            return null;
        }

        /// <summary>
        /// �ύסԺ��ʷȷ����
        /// </summary>
        private void SubmitDoc(string strXml)
        {
            //����֤�ò����Ƿ��Ѿ�д��סԺ��ʷȷ����
            string sql_doc = "select * from t_patients_doc where patient_id=" + currentPatient.Id + " and textkind_id=1581";
            DataSet ds = App.GetDataSet(sql_doc);
            if (ds != null && ds.Tables[0].Rows.Count == 0)
            {
                XmlDocument document = new XmlDocument(); //xml�ĵ�����
                document.PreserveWhitespace = true;       //�����Կհײ���
                document.LoadXml(strXml);        //��������ļ�
                //this.OwnerDocument.ToXML(document.DocumentElement);
                XmlDocument newDocument = new XmlDocument();
                newDocument.PreserveWhitespace = true;
                newDocument.LoadXml("<emrtextdoc/>");
                foreach (XmlNode item in document.GetElementsByTagName("body"))
                {
                    XmlNode bodyNode = newDocument.CreateElement("body");
                    foreach (XmlNode item2 in item)
                    {
                        XmlNode node2 = newDocument.CreateElement(item2.Name);
                        foreach (XmlAttribute attribute in item2.Attributes)
                        {
                            ((XmlElement)node2).SetAttribute(attribute.Name, attribute.Value);
                        }
                        node2.InnerXml = item2.InnerXml;
                        bodyNode.AppendChild(node2);
                        if (item2.Name == "div" && item2.Attributes["title"] != null && item2.Attributes["title"].Value.Contains("����ʷ"))
                        {
                            break;
                        }
                    }
                    XmlNode newNode = newDocument.CreateElement("table");
                    ((XmlElement)newNode).SetAttribute("tableLock", "1");
                    newNode.InnerXml = "<row id=\"C1B1C10640\" width=\"679\" min-height=\"40\"><cell id=\"C1B1C10641\" width=\"334\" candelete=\"1\" isVisble=\"0\"><p operatercreater=\"0\" /></cell><cell id=\"C1B1C10642\" width=\"334\" candelete=\"1\" isVisble=\"0\"><p operatercreater=\"0\" /></cell></row><row id=\"C1B1C10643\" width=\"679\"><cell id=\"C1B1C10644\" width=\"334\" candelete=\"1\" isVisble=\"0\"><span operatercreater=\"0\">    ��ʷ������ǩ��:</span><p operatercreater=\"0\" /></cell><cell id=\"C1B1C10645\" width=\"334\" candelete=\"1\" isVisble=\"0\"><span operatercreater=\"0\">�������뻼�߹�ϵ:</span><p operatercreater=\"0\" /></cell></row>";
                    bodyNode.AppendChild(newNode);
                    newDocument.DocumentElement.AppendChild(bodyNode);
                }
                int tid = App.GenId("t_patients_doc", "tid");
                string strinsert =
                          string.Format("insert into T_Patients_Doc(tid,CREATEID, pid, textkind_id, belongtosys_id, sickkind_id, textname,submitted,PATIENT_ID,DOC_NAME,SECTION_NAME,BED_NO,ISHIGHERSIGN,HAVEHIGHERSIGN,HAVEDOCTORSIGN) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')"
                                        , tid.ToString()    //tid                                             //����ID
                                        , App.UserAccount.UserInfo.User_id //�Ƿ��ύ��ť
                                        , currentPatient.PId //pid
                                        , 1581  //��������ID
                                        , 0 //
                                        , 0 //
                                        , "סԺ��ʷȷ����"   //textname
                                        , "Y"  //�ݴ�/�ύ
                                        , currentPatient.Id
                                        , App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss")    //docName
                                        , currentPatient.Section_Name
                                        , currentPatient.Sick_Bed_Name
                                        , "N"
                                        , "N"
                                        , "Y");
                if (App.ExecuteSQL(strinsert) > 0)
                {
                    //App.UpLoadFtpPatientDoc(newDocument.OuterXml, tid.ToString() + ".xml", currentPatient.Id.ToString());
                }
            }
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="tid"></param>
        private void Rethreee_CreateTab(string tid)
        {
            if (tid != "")
            {
                SelectedNodeByTid(advAllDoc.Nodes, tid);
                if (!IsSameTabItem(tid, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")))
                {
                    CreateTabItem(Convert.ToInt32(tid));
                }
            }
        }

        private void SelectedNodeByTid(NodeCollection nodes, string tid)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == tid)
                {
                    advAllDoc.SelectedNode = node;
                    break;
                }
                if (node.Nodes.Count > 0)
                {
                    SelectedNodeByTid(node.Nodes, tid);
                }
            }
        }

        /// <summary>
        /// ������������ѡ�нڵ�
        /// </summary>
        /// <param name="nodes"></param>
        private void SetSelectNode(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name == CurrentNode.Name)
                {
                    advFinishDoc.SelectedNode = nodes[i];
                    advFinishDoc.SelectedNode = nodes[i];
                    return;
                }
                else if (nodes[i].Nodes.Count > 0)
                {
                    SetSelectNode(nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// չ����ǰѡ�нڵ�
        /// </summary>
        private void ExpendTree(Node node)
        {
            if (node != null)
            {
                if (node.Parent != null)
                {
                    node.Expand();
                    node.Parent.Expand();
                    ExpendTree(node.Parent);
                }
            }
        }
        /// <summary>
        /// �����ύ��ˢ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReflashTrvBookEvent(object sender, EventArgs e)
        {
            // App.SetToolButtonByUser("tsbtnTempSave",false);            
            if (advFinishDoc.SelectedNode != null)
            {
                CurrentNode = advFinishDoc.SelectedNode;
                string name = "";
                if (sender.GetType().ToString().Contains("ButtonItem"))
                {
                    name = (((ButtonItem)sender).Text);
                }

                if (name.Contains("�ύ"))
                {
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    int tid = 0;
                    string sql = "";
                    //("Patient_Doc"))//��������

                    //("Class_Text"))//��������

                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (tempEditor != null)
                    {
                        sql = "select submitted from t_patients_doc where TID='" + tempEditor.MyDoc.Us.Tid + "' and patient_id='" + tempEditor.MyDoc.Us.InpatientInfo.Id + "'";
                        string isSubmitted = Convert.ToString(App.ReadSqlVal(sql, 0, "submitted"));
                        if (isSubmitted == "Y")
                        {//�Ѿ��ύ
                            //XmlDocument tempxmldoc = new XmlDocument();
                            //tempxmldoc.PreserveWhitespace = true;
                            //CurrentFrmText.MyDoc.ToXML(tempxmldoc.DocumentElement);
                            ////DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                            //tempEditor.MyDoc.FromXML(tempxmldoc.DocumentElement);
                            //tempEditor.MyDoc.ContentChanged();
                            //App.SetToolButtonByUser("tsbtnCommit", true);//�ύ

                            //try
                            //{
                            //    //�����ʿ�����
                            //    if (backgroundWorker1.IsBusy)
                            //    {
                            //    }
                            //    else
                            //    {
                            //        backgroundWorker1.RunWorkerAsync();
                            //    }
                            //}
                            //catch (System.Exception ex)
                            //{

                            //}
                        }
                        else
                        {//δ�ύ���ݴ�
                            App.SetToolButtonByUser("tsbtnTempSave", true);//�ݴ�
                        }
                    }
                }
            }
            ReflashTrvBook();
            //ˢ�½ڵ�
            SetSelectNode(advFinishDoc.Nodes);
            SelectedNodeByTid(advFinishDoc.Nodes, Update_Tid);
            //չ����ǰѡ�еĽڵ�
            ExpendTree(advFinishDoc.SelectedNode);
        }

     
        /// <summary>
        /// ѡ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tctlDoc_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0 && (App.UserAccount.CurrentSelectRole.Role_type == "D" || App.UserAccount.CurrentSelectRole.Role_type == "N" || App.UserAccount.CurrentSelectRole.Role_type == "B" || App.UserAccount.CurrentSelectRole.Role_type == "Y"))
                {
                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    

                    if (tempEditor != null && currentPatient.PatientState != "����")
                    {
                        InPatientInfo info = tctlDoc.SelectedPanel.TabItem.Tag as InPatientInfo;

                        string Sql_Sick_Doctor = "select Sick_Doctor_Id,Sick_Doctor_Name  from t_in_patient  where id=" + info.Id.ToString();
                        DataSet ds = App.GetDataSet(Sql_Sick_Doctor);
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    info.Sick_Doctor_Id = dt.Rows[0]["Sick_Doctor_Id"].ToString();
                                    info.Sick_Doctor_Name = dt.Rows[0]["sick_doctor_name"].ToString();
                                }
                            }
                        }
                        //tctlDoc.SelectedPanel.TabItem.Tag = info as object;
                        //App.SetToolButtonByUser("tsbtnSmallTemplateSave", true);  //����Сģ��
                        //App.SetToolButtonByUser("ttsbtnPrint", false);
                        App.SetToolButtonByUser("tsbtnTempSave", false);  //�ݴ�
                        App.SetToolButtonByUser("tsbtnCommit", false);    //�ύ
                        App.SetToolButtonByUser("tsbtnTemplateSave", true);//����ģ��
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        //if (tctlDoc.SelectedPanel.TabItem.Text.Contains("���"))
                        //{
                        //    App.SetToolButtonByUser("ttsbtnPrint", true);//��ӡ
                        //}
                        //else
                        //{
                        string sql = "select submitted from t_patients_doc where TID='" + tempEditor.MyDoc.Us.Tid + "' and patient_id='" + tempEditor.MyDoc.Us.InpatientInfo.Id + "'";
                        string isSubmitted = Convert.ToString(App.ReadSqlVal(sql, 0, "submitted"));
                        if (isSubmitted == "Y")
                        {//�Ѿ��ύ
                            App.SetToolButtonByUser("tsbtnCommit", true);//�ύ
                            App.SetToolButtonByUser("btnInsertDiosgin", true);
                            App.SetToolButtonByUser("btnRefreshDiosgin", true);

                            if (App.UserAccount.CurrentSelectRole.Role_name == "����ҽʦ" && !DataInit.ISPrintGPYS(tempEditor.MyDoc.Us.Tid,""))
                            {//"����ҽʦ"��д�����鲻�����д�ӡ��ֻ���ϼ�ҽ��ǩ���󷽿ɴ�ӡ
                                App.SetToolButtonByUser("ttsbtnPrint", false);//��ӡ
                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);//����
                                //App.SetToolButtonByUser("btnInsertDiosgin", false);
                                //App.SetToolButtonByUser("btnRefreshDiosgin", false);
                            }
                            else
                            {
                                App.SetToolButtonByUser("ttsbtnPrint", true);//��ӡ
                                App.SetToolButtonByUser("ttsbtnPrintContinue", true);//����
                                //App.SetToolButtonByUser("btnInsertDiosgin", true);
                                //App.SetToolButtonByUser("btnRefreshDiosgin", true);
                            }
                        }
                        //else if (isSubmitted == "N")
                        //{//�Ѿ��ݴ�
                        //    //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);//����Сģ��
                        //    App.SetToolButtonByUser("ttsbtnPrint", false);//��ӡ
                        //    App.SetToolButtonByUser("tsbtnTempSave", false);//�ݴ�
                        //    App.SetToolButtonByUser("tsbtnCommit", true);//�ύ
                        //}
                        else
                        {//δ�ύ���ݴ�
                            App.SetToolButtonByUser("tsbtnTempSave", true);//�ݴ�
                            App.SetToolButtonByUser("tsbtnCommit", true);//�ύ
                            App.SetToolButtonByUser("ttsbtnPrint", false);//��ӡ
                            App.SetToolButtonByUser("ttsbtnPrintContinue", false);//����
                            App.SetToolButtonByUser("btnInsertDiosgin", true);
                            App.SetToolButtonByUser("btnRefreshDiosgin", true);
                        }
                        //}
                        //App.SetToolButtonByUser("ttsbtnPrint", true);//��ӡ
                        //App.SetToolButtonByUser("ttsbtnPrintContinue",true);
                        ucTemp.Reflesh(tempEditor.MyDoc.Us.TextKind_id.ToString());
                        DataInit.SetToolEvent(tempEditor);
                        //IniMainToobar();
                        App.A_RefleshTreeBook = null;
                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                        if (!tctlDoc.SelectedTab.Text.Contains("���"))
                        {
                            barTemplate.AutoHide = true;
                        }
                        else
                        {
                            App.SetToolButtonByUser("tsbtnCommit", false);    //�ύ
                            App.SetToolButtonByUser("tsbtnTempSave", false);//�ݴ�
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                            barTemplate.Hide(); ;
                            if (!ClickShow)
                            {
                                /*
                               *����ˢ��
                               */
                                if (tctlDoc.SelectedTab.Name != "")
                                {
                                    Patient_Doc[] patient_Docs = GetSelectNodes(Convert.ToInt32(tctlDoc.SelectedTab.Name));//GetContentByType(NowTree.SelectedNode); //// tctlDoc.SelectedTab.Name
                                    SpiltXml(patient_Docs, tempEditor, false);
                                }
                                ClickShow = true;

                            }

                        }
                        foolflag = true;
                    }
                    else
                    {
                        barTemplate.Hide();
                        App.A_Commit = null;
                        App.A_TempSave = null;
                        App.SetToolButtonByUser("ttsbtnPrint", false);
                        App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        App.SetToolButtonByUser("tsbtnTemplateSave", false);//����ģ��
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);

                    }
                }
                else
                {
                    barTemplate.Hide();
                    App.A_Commit = null;
                    App.A_TempSave = null;
                    App.SetToolButtonByUser("ttsbtnPrint", false);//
                    App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    App.SetToolButtonByUser("tsbtnCommit", false);
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);//����ģ��
                    App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);  //����Сģ��
                    App.SetToolButtonByUser("btnInsertDiosgin", false);
                    App.SetToolButtonByUser("btnRefreshDiosgin", false);
                }
            }
            else
            {
                App.A_Commit = null;
                App.A_TempSave = null;
                App.SetToolButtonByUser("ttsbtnPrint", false);
                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                App.SetToolButtonByUser("tsbtnTempSave", false);
                App.SetToolButtonByUser("tsbtnCommit", false);
                App.SetToolButtonByUser("tsbtnTemplateSave", false);//����ģ��
                App.SetToolButtonByUser("btnInsertDiosgin", false);
                App.SetToolButtonByUser("btnRefreshDiosgin", false);

            }

        }

        private void ctmnspDelete_Opening(object sender, CancelEventArgs e)
        {
            //�������Ҽ��˵��ɼ�����
            ɾ��ToolStripMenuItem.Visible = false;
            tlspmnitBrowse.Visible = false;
            �����β鷿ToolStripMenuItem.Visible = false;
            �����β鷿ToolStripMenuItem.Visible = false;
            ȡ�����ϼ��鷿ToolStripMenuItem.Visible = false;

            if (NowTree.SelectedNode != null)
            {
                if (NowTree.SelectedNode.Tag != null)
                {
                    tlspmnitBrowse.Visible = true;
                    if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        Class_Text temp = (Class_Text)NowTree.SelectedNode.Tag;
                        if (temp.Isenable == "1")
                        {
                            ɾ��ToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_type != temp.Right_range &&
                               temp.Right_range != "A")
                            {
                                ɾ��ToolStripMenuItem.Visible = false;
                            }
                            else
                            {
                                if (NowTree.SelectedNode.Nodes.Count == 0)
                                {
                                    tlspmnitBrowse.Visible = true;
                                    ɾ��ToolStripMenuItem.Visible = true;
                                }
                            }
                        }

                        Patient_Doc doc = GetDoc(temp);
                        if (doc != null && temp.Issimpleinstance=="0")//�����Ž�����ʾ
                        {
                            if ((doc.Createid == App.UserAccount.UserInfo.User_id || doc.Textkind_id == 2172 || doc.Textkind_id == 2173) && (OperateState == null || OperateState.Contains("����")))
                            //'����Ѫ�Ǽ���¼��','PICC�����¼��')
                            {
                                ɾ��ToolStripMenuItem.Visible = true;
                            }
                            else
                            {
                                ɾ��ToolStripMenuItem.Visible = false;
                            }
                        }


                    }
                    else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                    {
                        Class_Text temp = (Class_Text)NowTree.SelectedNode.Parent.Tag;
                        if (App.UserAccount.CurrentSelectRole.Role_type == temp.Right_range ||
                               temp.Right_range == "A")
                        {
                            ɾ��ToolStripMenuItem.Visible = true;
                            tlspmnitBrowse.Visible = true;
                        }
                        else
                        {
                            tlspmnitBrowse.Visible = true;
                        }
                        Patient_Doc doc = NowTree.SelectedNode.Tag as Patient_Doc;
                        if ((doc.Createid == App.UserAccount.UserInfo.User_id || doc.Textkind_id == 2172 || doc.Textkind_id == 2173) && (OperateState == null || OperateState.Contains("����")))
                        //'����Ѫ�Ǽ���¼��','PICC�����¼��'
                        {
                            ɾ��ToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            ɾ��ToolStripMenuItem.Visible = false;
                        }
                    }
                }
            }

            if (DataInit.boolAgree)
            {
                ɾ��ToolStripMenuItem.Visible = false;
                �޸ı���ToolStripMenuItem.Visible = false;
                �����β鷿ToolStripMenuItem.Visible = false;
                �����β鷿ToolStripMenuItem.Visible = false;
                ȡ�����ϼ��鷿ToolStripMenuItem.Visible = false;
                // ����-----------------------------------------------------
                if (NowTree.SelectedNode.Text.Trim().Equals("סԺ־") || NowTree.SelectedNode.Text.Trim().Equals("סԺ�����¼�����������¼��"))
                {
                    this.tlspmnitBrowse.Visible = false;
                }
                else
                {
                    tlspmnitBrowse.Visible = true;
                }
                // ---------------------------------------------------------
            }

        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = null;
            string log_Tid = "";



            if (advFinishDoc.SelectedNode != null)
            {
                log_Tid = advFinishDoc.SelectedNode.Name;
                if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    string User_id = App.UserAccount.UserInfo.User_id;
                    string book_Id = advFinishDoc.SelectedNode.Name;


                    //����ɾ��Ȩ�ޣ����ϼ�ҽʦǩ�֣��ܴ�����ɾ���йܴ�ҽʦǩ�֣�ʵϰ���о�������ɾ
                    Patient_Doc doc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                    bool isDelete = false;
                    if (App.UserAccount.UserInfo.User_id != doc.Createid && doc.Textkind_id != 2172 && doc.Textkind_id != 2173)
                    //'����Ѫ�Ǽ���¼��','PICC�����¼��')
                    {//ɾ��Ȩ���жϵ�ǰ�û��Ƿ��Ǵ�����
                        return;
                    }

                    if (doc.Submitted == "Y")
                    {
                        isDelete = ISDelByXmlNode(doc.Id);
                    }
                    else
                    {
                        if (currentPatient.Sick_Doctor_Id == App.UserAccount.UserInfo.User_id || App.UserAccount.UserInfo.User_id == doc.Createid)
                        {
                            isDelete = true;
                        }
                        else
                        {
                            delBookReason = "ֻ�йܴ�ҽ�����˿���ɾ���ݴ����飡";
                        }
                    }
                    if (isDelete) //ֻ�б��˻�ܴ�ҽ������ɾ������
                    {

                        if (advFinishDoc.SelectedNode.Nodes.Count == 0)
                        {
                            if (App.Ask("ȷ��Ҫɾ����"))
                            {
                                Patient_Doc pdoc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                                //patient_doc
                                string sql_Patient = "delete t_patients_doc where tid = " + pdoc.Id + "";
                                //quelsty
                                string sql_Quality = "delete t_quality_text where tid = " + pdoc.Id + "";
                                //t_trend_diagnose
                                string sql_trend = "delete t_trend_diagnose where diagnoseitem_id in(select id from t_diagnose_item where doc_id = " + pdoc.Id + ")";
                                //t_diagnose_item
                                string sql_item = "delete t_diagnose_item where doc_id = " + pdoc.Id;
                                //���뵽������ʷ��
                                string sql_InsertDocHistory = "insert into t_patients_doc_delhistory(tid,pid,textkind_id,belongtosys_id,sickkind_id,textname,childid,deltime,delopeaterid,createid,patient_id,doc_name)" +
                                                              " select tid,pid,textkind_id,belongtosys_id,sickkind_id,textname,childid,sysdate," + App.UserAccount.UserInfo.User_id + ",createid,patient_id,doc_name from  t_patients_doc where tid=" + pdoc.Id + "";

                                string[] arr = new string[5];
                                arr[0] = sql_InsertDocHistory;
                                arr[1] = sql_Patient;
                                arr[2] = sql_Quality;
                                arr[3] = sql_trend;
                                arr[4] = sql_item;

                                int count = 0;
                                try
                                {
                                    count = App.ExecuteBatch(arr);
                                    if (count > 0)
                                    {
                                        result = "S";
                                        ClearTabtl();
                                        if (advFinishDoc.SelectedNode.Parent.Nodes.Count == 1)
                                        {
                                            advFinishDoc.SelectedNode.Parent.Remove();
                                        }
                                        else
                                        {
                                            advFinishDoc.SelectedNode.Remove();
                                        }
                                    }
                                }
                                catch (Exception)
                                {

                                    result = "F";
                                }
                            }
                        }
                        else
                        {
                            App.Msg("ֻ��ɾ���������飡");
                        }
                    }
                    else
                    {
                        App.Msg(delBookReason);
                        return;
                    }
                }
                else if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))//��������ɾ��
                {
                    Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;

                    if (text != null)
                    {
                        Patient_Doc doc = GetDoc(text);
                        if (doc == null)
                        {
                            App.Msg("�ýڵ�û�����飡");
                            return;
                        }
                        string User_id = App.UserAccount.UserInfo.User_id;
                        string book_Id = advFinishDoc.SelectedNode.Name;

                        //����ɾ��Ȩ�ޣ����ϼ�ҽʦǩ�֣��ܴ�����ɾ���йܴ�ҽʦǩ�֣�ʵϰ���о�������ɾ

                        if (App.UserAccount.UserInfo.User_id != doc.Createid && doc.Textkind_id != 2172 && doc.Textkind_id != 2173)
                        //'����Ѫ�Ǽ���¼��','PICC�����¼��')
                        {//ɾ��Ȩ���жϵ�ǰ�û��Ƿ��Ǵ�����
                            return;
                        }
                        bool isDelete = ISDelByXmlNode(doc.Id);
                        if (isDelete)
                        {
                            if (App.Ask("ȷ��Ҫɾ����?"))
                            {

                                //patient_doc
                                string sql_Patient = "delete t_patients_doc where tid = " + doc.Id + "";
                                //quelsty
                                string sql_Quality = "delete t_quality_text where tid = " + doc.Id + "";
                                //���뵽������ʷ��
                                string sql_InsertDocHistory = "insert into t_patients_doc_delhistory(tid,pid,textkind_id,belongtosys_id,sickkind_id,textname,childid,deltime,delopeaterid,createid,patient_id)" +
                                                              " select tid,pid,textkind_id,belongtosys_id,sickkind_id,textname,childid,sysdate," + App.UserAccount.UserInfo.User_id + ",createid,patient_id from  t_patients_doc where tid=" + doc.Id + "";
                                //t_trend_diagnose
                                string sql_trend = "delete t_trend_diagnose where diagnoseitem_id in(select id from t_diagnose_item where doc_id = " + doc.Id + ")";
                                //t_diagnose_item
                                string sql_item = "delete t_diagnose_item where doc_id = " + doc.Id;

                                string[] arr = new string[5];
                                arr[0] = sql_InsertDocHistory;
                                arr[1] = sql_Patient;
                                arr[2] = sql_Quality;
                                arr[3] = sql_trend;
                                arr[4] = sql_item;

                                int count = 0;
                                try
                                {
                                    count = App.ExecuteBatch(arr);
                                    if (count > 0)
                                    {
                                        result = "S";
                                        ClearTabtl();
                                        ReflashTrvBookEvent(sender, e);
                                    }
                                }
                                catch (Exception)
                                {

                                    result = "F";
                                }
                            }
                        }
                        else
                        {
                            App.Msg(delBookReason);
                        }
                    }
                }
            }
            else
            {
                App.Msg("��ѡ�нڵ㣡");
            }

            int patient_id = currentPatient.Id;
            //��¼ϵͳ��־
            LogHelper.SystemLog("ɾ��", log_Tid, currentPatient.PId, patient_id);
        }

        /// <summary>
        /// ��������ڵ������ж��Ƿ����ɾ������
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private bool ISDelByXmlNode(int id)
        {
            //string sql = "select patients_doc from t_patients_doc where tid=" + id;
            string content = "";
            content = content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + id + "", 0, "CONTENT");
            if (content == null || content == "")
            {
                content = App.DownLoadFtpPatientDoc(id + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
            }
            if (content == null || content == "")
            {
                return true;
            }
            XmlDocument textDocument = new XmlDocument();
            textDocument.PreserveWhitespace = true;
            textDocument.LoadXml(content);

            XmlNodeList sign = textDocument.GetElementsByTagName("input");

            string sjysqm = "";//�ϼ�ҽʦǩ��
            string gcysqm = "";//�ܴ�ҽ��ǩ��
            string ptysqm = "";//��ͨҽ��ǩ��
            /* 1.���ж��ϼ�ҽ���Ƿ�ǩ�����еĻ���ǰ������Ա�Ƿ����ϼ�ҽ�������ǵĻ�ֱ�ӷ��ء��ϼ�ҽʦ��ǩ�֣��޷�ɾ������
             * 2.�ϼ�ҽ��û��ǩ�����жϵ�ǰ������Ա�Ƿ����ϼ�ҽ�����ǵĻ����Բ���
             * 3.�жϹܴ�ҽ���Ƿ�ǩ�����еĻ�����ǰ��ʶ�Ƿ��ǹܴ�ҽ�����ǵĻ����Բ���
             * 4.û�йܴ�ҽ������ǰ������Ա�Ƿ��ǹܴ�ҽ�����ǵĻ��ܲ��������ǵĻ����ز���
             * 5.û���ϼ�ҽ���͹ܴ�ҽ������ͨҽ���е�ʱ���ж��Ƿ��ǵ�ǰ�����ǵĻ��ܲ������ǵĻ����ܲ�����û�еĻ��ܲ���
             */
            //�ҵ��ϼ�ҽ��ǩ�����ܴ�ҽʦǩ������ͨҽʦǩ��
            foreach (XmlNode var in sign)
            {
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "�ϼ�ҽʦǩ��")
                {
                    foreach (XmlNode node in var.ChildNodes)
                    {
                        sjysqm += node.InnerText;
                    }
                }
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "�ܴ�ҽʦǩ��")
                {
                    foreach (XmlNode node in var.ChildNodes)
                    {
                        gcysqm += node.InnerText;
                    }
                }
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "��ͨҽʦǩ��")
                {
                    foreach (XmlNode node in var.ChildNodes)
                    {
                        ptysqm += node.InnerText;
                    }
                }
            }
            string gcysmz = "";
            string ishighersign = "";
            string havehighersign = "";
            string havedoctorsign = "";
            string SqlHavingHigh = "select ishighersign,havehighersign,havedoctorsign,b.sick_doctor_name  from t_patients_doc a inner join t_in_patient b on a.patient_id=b.id  where tid=" + id;
            DataSet ds = App.GetDataSet(SqlHavingHigh);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        gcysmz = dt.Rows[0]["sick_doctor_name"].ToString();
                        ishighersign = dt.Rows[0]["ishighersign"].ToString();//�Ƿ���Ҫ�ϼ�ҽ��ǩ��
                        havehighersign = dt.Rows[0]["havehighersign"].ToString();//�Ƿ����ϼ�ҽ��ǩ��
                        havedoctorsign = dt.Rows[0]["havedoctorsign"].ToString();//�Ƿ��йܴ�ҽ��ǩ��
                    }
                }
            }
            string[] ptysnumber = ptysqm.Trim().Split(' ');
            #region
            if (ptysnumber.Length >= 1)
            {
                ArrayList temp = new ArrayList();
                for (int i = 0; i < ptysqm.Length; i++)
                {
                    //temp[i] = st[i];
                    if (temp.Count == 0)
                        temp.Add(ptysqm[i]);
                    else
                    {
                        if (temp[temp.Count - 1].ToString() != " ")
                        {
                            temp.Add(ptysqm[i]);
                        }
                        else
                        {

                            if (ptysqm[i].ToString() != " ")
                                temp.Add(ptysqm[i]);
                        }
                    }
                }
                ptysqm = "";
                for (int i = 0; i < temp.Count; i++)
                {
                    ptysqm += temp[i];
                }
                ptysnumber = ptysqm.Trim().Split(' ');
            }
            if (ptysnumber.Length == 1)
            {
                if (havedoctorsign == "Y" && gcysqm == "" && gcysmz.Trim() == ptysqm.Trim())
                {
                    gcysqm = ptysnumber[0].ToString();
                    ptysqm = "";
                }
                else
                {
                    ptysqm = ptysnumber[0].ToString();
                }

            }
            if (ptysnumber.Length == 2)
            {
                if (gcysmz == ptysnumber[1].ToString())
                {
                    sjysqm = ptysnumber[0].ToString();
                    gcysqm = ptysnumber[1].ToString();
                    ptysqm = "";
                }
                else if (gcysmz == ptysnumber[0].ToString())
                {
                    gcysqm = ptysnumber[0].ToString();
                    ptysqm = ptysnumber[1].ToString();
                }
                else
                {
                    sjysqm = ptysnumber[0].ToString();
                    ptysqm = ptysnumber[1].ToString();
                }
            }
            if (ptysnumber.Length > 2)
            {
                sjysqm = ptysnumber[0].ToString();
                gcysqm = ptysnumber[ptysnumber.Length - 2].ToString();
                ptysqm = ptysnumber[ptysnumber.Length - 1].ToString();
            }
            #endregion
            if (sjysqm.Trim().Length > 0 && sjysqm.Contains("��"))
            {
                sjysqm = sjysqm.Split('��')[1].Trim();
            }
            else
            {
                sjysqm = sjysqm.Trim();
            }

            if (gcysqm.Trim().Length > 0 && gcysqm.Contains("��"))
            {
                gcysqm = gcysqm.Split('��')[1].Trim();
            }
            else
            {
                gcysqm = gcysqm.Trim();
            }
            //gcysqm = gcysqm.Trim();
            if (ptysqm.Trim().Length > 0 && ptysqm.Contains("��"))
            {
                ptysqm = ptysqm.Split('��')[1].Trim();
            }
            else
            {
                ptysqm = ptysqm.Trim();
            }
            //ptysqm = ptysqm.Trim();

            if (sjysqm != "" && sjysqm != App.UserAccount.UserInfo.User_name)
            {
                delBookReason = "�ϼ�ҽʦ��ǩ�֣��޷�ɾ����";
                return false;

            }
            else
            {
                //�жϹܴ�ҽʦ�Ƿ�ǩ��
                if (gcysqm != "")
                {
                    if (gcysqm == App.UserAccount.UserInfo.User_name)
                    {
                        return true;
                    }
                    else
                    {
                        delBookReason = "�ܴ�ҽʦ��ǩ�֣��޷�ɾ����";
                        return false;
                    }
                }
                else
                {
                    if (gcysmz == App.UserAccount.UserInfo.User_name)
                    {
                        return true;
                    }
                    if (ptysqm.Length == 0)
                        return true;
                    else if (ptysqm == App.UserAccount.UserInfo.User_name)
                        return true;
                    else if (ptysqm != App.UserAccount.UserInfo.User_name)
                    {
                        delBookReason = "Ȩ�޲��㣬�޷�ɾ����";
                        return false;
                    }
                }
            }
            #region
            /*
                if (var.Attributes["id"] != null)
                {
                    string userId = var.Attributes["id"].Value;//
                    if (userId!= "")
                    {
                        if (userId == App.UserAccount.UserInfo.User_id)
                            return true;
                        else
                        {
                            //string shangjiyisheng=
                            delBookReason = "�ϼ�ҽʦ��ǩ�֣��޷�ɾ����";
                            return false;
                        }
                    }
                    else
                    {
                        break;
                    }
                } */
            #endregion
            #region
            /*
            foreach (XmlNode var in sign)
            {
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "�ܴ�ҽʦǩ��")
                {
                    if (var.Attributes["id"] != null)
                    {
                        string userId = var.Attributes["id"].Value;
                        if (userId != "" )
                        {
                            if (userId == App.UserAccount.UserInfo.User_id)
                                return true;
                            else
                                delBookReason = "�ܴ�ҽʦ��ǩ�֣��޷�ɾ����";
                                return false;
                            
                        }
                        else 
                        { 
                            break; 
                        }

                    }
                }
            
            }

            foreach (XmlNode var in sign)
            {
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "��ͨҽʦǩ��")
                {
                    if (var.Attributes["id"] != null)
                    {
                        string userId = var.Attributes["id"].Value;
                        if (userId == "")
                        {
                            delBookReason = "ֻ�йܴ�����ɾ�����飡";
                            return false;
                        }
                        if (userId == App.UserAccount.UserInfo.User_id)
                        {
                            return true;
                        }
                        else
                        {
                            if (App.UserAccount.UserInfo.User_id == this.currentPatient.Sick_Doctor_Id)
                            {
                              string maxId =  App.GetTheHighLevelUserId(this.currentPatient.Sick_Doctor_Id, userId);
                              if (maxId == this.currentPatient.Sick_Doctor_Id)
                              {
                                  return true;
                              }
                              else
                              {

                                  delBookReason = "�㲻���������ǩ���ߣ��޷�ɾ��!";
                                  return false;
                              }
                            }
                            break;
                        }
                    }
                }
            }*/
            #endregion
            delBookReason = "Ȩ�޲��㣬�޷�ɾ����";
            return false;
        }

        /// <summary>
        /// ɾ�����ڵ㣬���tablContrain������Ҳ�ж�Ӧ�����飬��ɾ��
        /// </summary>
        private void ClearTabtl()
        {
            int count = tctlDoc.Tabs.Count;
            for (int i = 0; i < count; i++)
            {
                if ((NowTree.SelectedNode.Parent != null && tctlDoc.Tabs[i].Name.Contains(NowTree.SelectedNode.Parent.Name)) ||
                    tctlDoc.Tabs[i].Name.Contains(NowTree.SelectedNode.Name))
                {
                    tctlDoc.Tabs[i].Dispose();
                    tctlDoc.Controls[i].Dispose();
                    break;
                }
            }
        }

        /// <summary>
        /// �õ��������������ʵ��
        /// </summary>
        /// <param name="text"></param>
        private Patient_Doc GetDoc(Class_Text text)
        {
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,a.textname,a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid,a.israplacehightdoctor,a.israplacehightdoctor2  from t_patients_doc a  where textkind_id=" + text.Id + " and patient_id='" + currentPatient.Id.ToString() + "'";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Patient_Doc pDoc = new Patient_Doc();

                    pDoc.Id = Convert.ToInt32(row["tid"]);
                    pDoc.Patient_id = row["patient_Id"].ToString();
                    pDoc.Pid = row["pid"].ToString();

                    if (row["textkind_id"].ToString() != "")
                        pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);

                    if (row["belongtosys_id"].ToString() != "")
                        pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                    //pDoc.Patients_doc =row["patients_doc"].ToString();
                    if (row["sickkind_id"].ToString() != "")
                        pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);

                    pDoc.Docname = row["doc_name"].ToString().TrimStart();
                    pDoc.Textname = row["textname"].ToString().TrimStart();
                    pDoc.Ishighersign = row["ishighersign"].ToString();
                    pDoc.Havehighersign = row["havehighersign"].ToString();
                    pDoc.Havedoctorsign = row["Havedoctorsign"].ToString();
                    pDoc.Submitted = row["submitted"].ToString();
                    pDoc.Createid = row["createId"].ToString();
                    pDoc.Highersignuserid = row["highersignuserid"].ToString();
                    pDoc.Isreplacehighdoctor = row["israplacehightdoctor"].ToString();
                    pDoc.Isreplacehighdoctor2 = row["israplacehightdoctor2"].ToString();
                    return pDoc;
                }
            }
            return null;
        }

        private void AddTlspMnit_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                advAllDoc_DoubleClick(NowTree, e);
            }
            else
            {
                App.Msg("��ѡ������ڵ㣡");
            }

        }

        //���
        private void tlspmnitBrowse_Click(object sender, EventArgs e)
        {
            /*
             * ���ʵ��˼·��
             * 1.�����ǰ�ڵ������нڵ���������ݶ�Ӧ��xml����
             * 2.ƴ�Ӳ��ÿ��xml�ļ���body�����xml���룬�������µ�xml
             * 3.�����µ�xml�ı�������ֻ����
             */
            //try
            //{
                ucDoctorOperater.flagmark = true;
            if (mark_two == "1")
            {
                App.Msg("��˫�����������");
                return;
            }
            barTemplate.Visible = false;
             string tid = "";
            string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
            if (NowTree.SelectedNode != null)
            {
                tid = NowTree.SelectedNode.Name;
                string textTitle = GetTextTitle(NowTree.SelectedNode);
                if (IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")))
                    return;
                bool isExist = false; //�Ƿ�ֻ�ж�������
                if (NowTree.SelectedNode.Nodes.Count > 0)
                {
                    foreach (Node node in NowTree.SelectedNode.Nodes)
                    {
                        if (account_Type == "N")
                        {
                            //��������
                            isExist = CreateNewPage(null, node); //list
                        }
                        else
                        {
                            isExist = CreateNewPageByDoctor(null, node);//list
                        }
                    }
                }
                else
                {
                    if (account_Type == "N")
                    {
                        //��������
                        isExist = CreateNewPage(null, NowTree.SelectedNode);
                    }
                    else
                    {
                        isExist = CreateNewPageByDoctor(null, NowTree.SelectedNode);
                    }
                }
                if (isExist)
                {
                    return;
                }
                #region ��ͨ�������
                //string[,] Contents = GetContentByType(trvBookOprate.SelectedNode);

                Patient_Doc[] patient_Docs = GetContentByType(NowTree.SelectedNode); //�˴�����ʱ����

                //��¼����Ľڵ�
                if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                {
                    BrowseNodes = NowTree.SelectedNode;
                }
                else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    BrowseNodes = NowTree.SelectedNode;
                }


                if (patient_Docs != null && patient_Docs.Length > 0)
                {

                    //else if (doc.Havedoctorsign == "N")//N��ʾ�ܴ�ҽ��δǩ�ֵ����飬��ʾΪ��ɫ
                    //        {
                    //            node.Style = elementStyleRed;
                    //            node.Text += "(ȱ�ܴ�ҽ��ǩ��)";
                    //        }
                    //        else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                    //        {
                    //            if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                    //            {
                    //                node.Style = elementStyleOrange;
                    //                node.Text += "(ȱ�ϼ�ҽʦǩ��)";
                    //            }
                    //        }

                    ////�ݴ�����ֻ���ɱ��˲���
                    //Patient_Doc doc = patient_Docs[0];
                    //if (doc.Submitted == "N" && doc.Createid != App.UserAccount.UserInfo.User_id)
                    //{
                    //    App.Msg("���������ݴ����飬ֻ���ɱ��������");
                    //    return;
                    //}
                    DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                    tabctpnDoc.AutoScroll = true;
                    DevComponents.DotNetBar.TabItem pageDoc = new DevComponents.DotNetBar.TabItem();



                    pageDoc.Name = NowTree.SelectedNode.Name;
                    pageDoc.Text = NowTree.SelectedNode.Text + " ���";
                    pageDoc.Click += new EventHandler(page_Click);
                    InPatientInfo tempInpatinet = null;
                    tempInpatinet = currentPatient;
                    pageDoc.Tag = tempInpatinet as object;
                    InPatientInfo inpat = pageDoc.Tag as InPatientInfo;

                    frmText ucText = new frmText(patient_Docs[0].Textkind_id, patient_Docs[0].Belongtosys_id, patient_Docs[0].Sickkind_id, textTitle, patient_Docs[0].Id, inpat, true);
                    ucText.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                    string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name,bed_no from t_patients_doc where textkind_id=" + patient_Docs[0].Textkind_id + " and patient_id=" + inpat.Id + "";
                    DataTable dt = App.GetDataSet(sql).Tables[0];
                    ucText.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                    ucText.MyDoc.Bed_name = dt.Rows[0]["bed_no"].ToString();
                    ucText.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    //ucText.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs

                    if (DataInit.boolAgree || DataInit.isRightDoc)
                    {
                        string mark = DataInit.GetEncryptWaterMark(inpat.PId, App.UserAccount.Account_name);
                        ucText.MyDoc.IsDrawWaterMark = true;
                        ucText.MyDoc.WaterMarkStr = mark + "\r\n" + App.UserAccount.Account_name;
                    }

                    if (patient_Docs != null)
                    {
                        if (patient_Docs.Length > 1)
                        {
                            bool flag = isSurgeryLater(NowTree.Nodes);
                            switch (flag)
                            {
                                case false:
                                    SpiltXml(patient_Docs, ucText, false);
                                    break;
                                case true:
                                    SpiltXml(patient_Docs, ucText, true);
                                    break;
                                default:
                                    break;

                            }
                        }
                        else
                        {
                            //���������޸ĺۼ��޸�
                            XmlDocument tempxmldoc1 = new XmlDocument();
                            tempxmldoc1.PreserveWhitespace = true;
                            tempxmldoc1.LoadXml(patient_Docs[0].Patients_doc);
                            ucText.MyDoc.FromXML(tempxmldoc1.DocumentElement);
                            ucText.MyDoc.ContentChanged();
                        }
                        SetTextButtonFase(ucText);
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpat, ucText);
                        ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);
                        tabctpnDoc.Controls.Add(ucText);
                        App.UsControlStyle(ucText);
                        tabctpnDoc.TabItem = pageDoc;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        ucText.Dock = DockStyle.Fill;
                        pageDoc.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(pageDoc);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = pageDoc;
                        ClickShow = true;
                        ucText.MyDoc.Locked = true;
                        ucText.MyDoc.EnableShowAll = true;
                    }
                    else
                    {
                        App.Msg("�ýڵ���ʱû�����飡");
                    }
                }
                else
                {
                    App.Msg("�ýڵ���ʱû�����飡");
                }
            }
            else
            {
                App.Msg("û��ѡ�нڵ㣡");
            }
            int patient_Id = currentPatient.Id;
            //��¼ϵͳ������־,
            //LogHelper.SystemLog("", result, "�������", tid, currentPatient.PId, patient_Id);
            //App.SetToolButtonByUser("tsbtnCommit", false);
            //if (account_Type == "N")
            //{
            //    App.SetToolButtonByUser("tsbtnTemplate", false);
            //    App.SetToolButtonByUser("tsbtnTemplateSave", false);
            //    App.SetToolButtonByUser("ttsbtnPrint", false);
            //    App.SetToolButtonByUser("tsbtnTempSave", false);
            //}
            //App.Get_Text_Buttns_Set_rights(Convert.ToInt32(currentPatient.Sick_Doctor_Id), Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode, currentPatient, 1);                     
            barTemplate.Hide();
            //ucDoctorOperater.flagmark = false;
                #endregion
            //}
            //catch
            //{
            //    App.MsgErr("�ýڵ㲢������Ч����������ڵ㣡");
            //}
        }


        /// <summary>
        /// ��������������С��ť
        /// </summary>
        /// <param name="ucText"></param>
        private void SetTextButtonFase(frmText ucText)
        {
            //foreach (Control item in ucText.MyDoc.Menus.PnlMenus.Controls)
            //{
            //    if (item is RibbonBar)
            //    {
            //        RibbonBar b = (RibbonBar)item;
            //        foreach (BaseItem item2 in b.Items)
            //        {
            //            if (item2.Tag != null)
            //            {
            //                if (item2.Tag.ToString() == "fontname" ||
            //                    item2.Tag.ToString() == "fontsize")
            //                {
            //                    item2.Visible = false;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// ���ʱ
        /// </summary>
        /// <param name="list">Ȩ�޼���</param>
        /// <param name="node">��ǰѡ�еĽڵ�</param>
        private bool CreateNewPage(ArrayList list, Node node)
        {
            bool IsHave = true;
            DevComponents.DotNetBar.TabControlPanel tabctpnView = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnView.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Click += new EventHandler(page_Click);
            page.Name = node.Name;
            page.Text = node.Text;
            //if (DataInit.GetActionState(currentPatient.Id.ToString()) == "3")
            //{
            page.Tag = currentPatient as object;
            //}
            //else
            //{
            //page.Tag = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString()) as object;
            //}
            if (page.Tag != null)
            {
                barTemplate.Hide();
                Class_Text ctext = node.Tag as Class_Text;
                if (ctext == null || ctext.Isenable == "0")
                {
                    IsHave = false;
                }
                if (node.Tag.ToString().Contains("Class_Text"))
                {
                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //Ѫ�Ǽ�ⵥ
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnView.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //����ͼ
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();
                        

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }

                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * ��ʿ����
                             */
                            tabctpnView.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnView.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * ҽ��վ
                                              */
                            ucBirthPic.OnlyLook = true;
                            tabctpnView.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnView.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (string.IsNullOrEmpty(section_id_test))
                        {
                            if (inpatient != null)
                            {
                                section_id_test = inpatient.Sike_Area_Id.ToString();
                            }
                            else
                            {
                                section_id_test = "0";
                            }
                        }
                        //MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        MUcToolsControl ucNurseRecord = null;
                        if (currentPatient.Section_Name.Contains("����") )//|| currentPatient.Section_Name.Contains("���ڶ�"))
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        }
                        else
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        }
                        /*
                         * ��ʿ����
                         */
                        tabctpnView.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        if (App.UserAccount.CurrentSelectRole.Role_type != "N")
                        {
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);
                            page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                        }
                        else
                        {
                            if (islock)
                            {
                                string strAsk;
                                if (App.UserAccount.UserInfo.User_name == open_name)
                                {
                                    strAsk = page.Text + "��������Ѿ���" + ip + "�򿪻����ϴ�û�������رգ���ȷ�����������𣿣�";
                                    if (App.Ask(strAsk))
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "", App.UserAccount.UserInfo.User_id);
                                    }
                                    else
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                                    }

                                }
                                else
                                {
                                    strAsk = page.Text + "��������Ѿ���" + ip + "�ɹ��ţ�" + open_num + "������" + open_name + "�Ѿ��򿪣����˲�������������ݴ�����ȷ������";
                                    if (!App.Ask(strAsk))
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                                    }
                                    else
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "", App.UserAccount.UserInfo.User_id);
                                    }
                                }
                            }
                            else
                            {
                                if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//û����֮ǰ
                                {
                                    IsLockBook("t_care_doc", inpatient.Id, "", App.UserAccount.UserInfo.User_id);
                                }
                            }
                        }
                        tabctpnView.AutoScroll = true;
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        ////���µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            //ucTemperPrintDataLoad uctemperPrint = new ucTemperPrintDataLoad(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //���������µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper_bb.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(temper_bb);
                            App.UsControlStyle(temper_bb);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            
                            uctemperPrint_bb.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(uctemperPrint_bb);
                            App.UsControlStyle(uctemperPrint_bb);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        //���¹�ȥ������Ϣ
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnView.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xpû����load�¼�
                            ucCase_First.InitPatientInfo();
                            // ��ȡ������Ϣ
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region ������Ϣ�ı�������
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // ��ȡ�����Ϣ
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region ��Ҫ��ϱ�����д��Ժ�����ת�����
                            dr = Diagnose.Rows[0];
                            #endregion


                            // ��ȡ������Ϣ
                            DataTable Operation = ucCase_First.GetOperation();

                            // ��ȡ����������Ϣ
                            DataTable Quality = ucCase_First.GetQuality();

                            // ��ȡ������ҳ��һЩ����
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region �����ı��������
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // ���� DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnView.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnView.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnView.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnView.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnView.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//���֤����
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnView.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//�ĵ�ʾ����¼��
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnView.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//���������������󲡳̼�¼881
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnView.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        tabctpnView.Dispose();
                        page.Dispose();
                        IsHave = false;
                    }
                }
            }
            if (IsHave == true)
            {
                tabctpnView.TabItem = page;
                tabctpnView.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnView;
                this.tctlDoc.Controls.Add(tabctpnView);
                this.tctlDoc.Tabs.Add(page);
                this.tctlDoc.Refresh();
                this.tctlDoc.SelectedTab = page;
                isCustom = true;
            }
            return IsHave;
        }
        /// <summary>
        /// ҽ���˺ŵ�½ֻ�������ʿ����Ĵ�ӡ����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool CreateNewPageByDoctor(ArrayList list, Node node)
        {
            bool IsHave = true;
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Click += new EventHandler(page_Click);
            page.Name = node.Name;
            page.Tag = currentPatient as object;
            InPatientInfo inpatient = page.Tag as InPatientInfo;
            page.Text = node.Text + " " + " (" + inpatient.Sick_Bed_Name + " ��)";
            if (node.Tag != null)
            {
                if (node.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text ctext = node.Tag as Class_Text;
                    if (ctext == null || ctext.Isenable == "0")
                    {
                        IsHave = false;
                    }
                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //Ѫ�Ǽ�ⵥ

                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnDoc.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //����ͼ

                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * ��ʿ����
                             */
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * ҽ��վ
                                              */
                            ucBirthPic.OnlyLook = true;
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        //InPatientInfo inpatient = page.Tag as InPatientInfo;

                        page.Tooltip = "N";
                        int Section_Id = 0;//����id
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != null &&
                            App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                            Section_Id = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);

                        string Role_type = App.UserAccount.CurrentSelectRole.Role_type;//�û�����
                        if ((Role_type != "N" && Role_type != "D") || currentPatient.PatientState == "����" || (OperateState != null && OperateState.Contains("�鿴") && !OperateState.Contains("��¼")))
                        {
                            Section_Id = Convert.ToInt32(inpatient.Section_Id);
                        }
                        MUcToolsControl ucNurseRecord;
                        if (node.Text.Contains("��������"))
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name), true);
                        else
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name));
                        /*
                         * ��ʿ����
                         */
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);

                        ucNurseRecord.MyDocument.ClearTempInput();
                        ucNurseRecord.SetToolsEnable(false);//�����Ǹ��˵�
                        //Panel bp = ucNurseRecord.GetButtonPanel();
                        //foreach (Control c in bp.Controls)
                        //{//�����ؼ�,��������
                        //    if (c is Button)
                        //    {
                        //        Button b = (Button)c;
                        //        if ((b.Text == "��ӡ" || b.Text == "����") && currentPatient.PatientState != "����")
                        //        {
                        //            b.Visible = true;
                        //            b.Enabled = true;
                        //        }
                        //    }
                        //}

                        tabctpnDoc.AutoScroll = true;
                        IsHave = true;
                        barTemplate.Hide();

                        //string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;

                        //if (string.IsNullOrEmpty(section_id_test))
                        //{
                        //    if (inpatient != null)
                        //    {
                        //        section_id_test = inpatient.Sike_Area_Id.ToString();
                        //    }
                        //    else
                        //    {
                        //        section_id_test = "0";
                        //    }
                        //}
                        ////MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        //MUcToolsControl ucNurseRecord = null;
                        //if (currentPatient.Section_Name.Contains("����") || currentPatient.Section_Name.Contains("���ڶ�"))
                        //{
                        //    ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                        //    ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        //}
                        //else
                        //{
                        //    ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                        //    ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        //}
                        ///*
                        // * ��ʿ����
                        // */
                        //tabctpnDoc.Controls.Add(ucNurseRecord);
                        //ucNurseRecord.Dock = DockStyle.Fill;
                        //App.UsControlStyle(ucNurseRecord);
                        //string open_num = "";
                        //string open_name = "";
                        //string ip = "";
                        //bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        //if (App.UserAccount.CurrentSelectRole.Role_type != "N")
                        //{
                        //    ucNurseRecord.MyDocument.ClearTempInput();
                        //    ucNurseRecord.SetToolsEnable(false);
                        //    page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                        //}
                        //else
                        //{
                        //    if (islock)
                        //    {
                        //        string strAsk;
                        //        if (App.UserAccount.UserInfo.User_name == open_name)
                        //        {
                        //            strAsk = page.Text + "��������Ѿ���" + ip + "�򿪻����ϴ�û�������رգ���ȷ�����������𣿣�";
                        //            if (App.Ask(strAsk))
                        //            {
                        //                IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //            }
                        //            else
                        //            {
                        //                ucNurseRecord.MyDocument.ClearTempInput();
                        //                ucNurseRecord.SetToolsEnable(false);
                        //                page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                        //            }

                        //        }
                        //        else
                        //        {
                        //            strAsk = page.Text + "��������Ѿ���" + ip + "�ɹ��ţ�" + open_num + "������" + open_name + "�Ѿ��򿪣����˲�������������ݴ�����ȷ������";
                        //            if (!App.Ask(strAsk))
                        //            {
                        //                ucNurseRecord.MyDocument.ClearTempInput();
                        //                ucNurseRecord.SetToolsEnable(false);
                        //                page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                        //            }
                        //            else
                        //            {
                        //                IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//û����֮ǰ
                        //        {
                        //            IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //        }
                        //    }
                        //}
                        //tabctpnDoc.AutoScroll = true;
                        //isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //���µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");


                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            ////ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            //TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            //temper.Dock = DockStyle.Fill;
                            //tabctpnDoc.Controls.Add(temper);
                            //App.UsControlStyle(temper);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //���������µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper_bb.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper_bb);
                            App.UsControlStyle(temper_bb);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            uctemperPrint_bb.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint_bb);
                            App.UsControlStyle(uctemperPrint_bb);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {

                        page.Tooltip = "N";
                        //���¹�ȥ������Ϣ
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnDoc.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xpû����load�¼�
                            ucCase_First.InitPatientInfo();
                            // ��ȡ������Ϣ
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region ������Ϣ�ı�������
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // ��ȡ�����Ϣ
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region ��Ҫ��ϱ�����д��Ժ�����ת�����
                            dr = Diagnose.Rows[0];
                            #endregion


                            // ��ȡ������Ϣ
                            DataTable Operation = ucCase_First.GetOperation();

                            // ��ȡ����������Ϣ
                            DataTable Quality = ucCase_First.GetQuality();

                            // ��ȡ������ҳ��һЩ����
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region �����ı��������
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // ���� DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnDoc.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnDoc.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {

                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {

                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//���֤����
                    {

                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//�ĵ�ʾ����¼��
                    {

                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//���������������󲡳̼�¼881
                    {

                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        IsHave = false;
                        //App.Msg("��������û��ȷ����Ӧ�Ĺ���ģ��,���ڹ���Ա��ϵ,���������͹����н������ã�");

                    }
                }
                else
                {
                    IsHave = false;
                }
            }
            if (IsHave == true)
            {
                tabctpnDoc.TabItem = page;
                tabctpnDoc.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnDoc;
                this.tctlDoc.Controls.Add(tabctpnDoc);
                this.tctlDoc.Tabs.Add(page);
                this.tctlDoc.Refresh();
                this.tctlDoc.SelectedTab = page;
                isCustom = true;
            }
            //else
            //{
            //    tabctpnDoc.Dispose();
            //    page.Dispose();
            //}
            return IsHave;
        }


        /// <summary>
        /// �����������ͣ���õ�ǰ���������
        /// </summary>
        /// <returns></returns>
        private Patient_Doc[] GetContentByType(Node node)
        {

            string Type = node.Tag.GetType().Name;
            //string[,] Contents = null;
            Patient_Doc[] patient_Docs = null;
            switch (Type)
            {
                case "Class_Text":
                    Class_Text tempnode = (Class_Text)node.Tag;
                    if (tempnode.Id == 103)
                    {
                        //���̼�¼                  
                        patient_Docs = GetSelectNodes(node.Nodes);
                    }
                    else
                    {
                        if (node.Nodes.Count > 0)
                        {
                            if (node.Nodes[0].Tag.GetType().Name == "Class_Text")
                            {
                                Class_Text cText = node.Tag as Class_Text;
                                patient_Docs = GetSelectNodes(cText.Id);


                            }
                            else                                               //��ʵ�����飬Patient_Doc����
                            {
                                Class_Text cText = node.Tag as Class_Text;
                                patient_Docs = GetSelectNodes(cText);
                            }
                        }
                        else
                        {
                            Class_Text cText = node.Tag as Class_Text;
                            patient_Docs = GetSelectNodes(cText);
                        }
                    }
                    break;
                default:
                    Patient_Doc patientDoc = node.Tag as Patient_Doc;
                    patient_Docs = GetSelectNodes(patientDoc);
                    break;
            }
            return patient_Docs;
        }

        /// <summary>
        /// �ж������״β��̼�¼�Ƿ����ӽڵ�
        /// </summary>
        /// <param name="nodes">����������</param>
        /// <returns>true ���ӽڵ�,false û���ӽڵ�</returns>
        private bool isSurgeryLater(NodeCollection nodes)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == "136") //�����״β��̼�¼
                {
                    if (node.Nodes.Count > 0)
                        isChildNode = true;
                    break;
                }
                if (node.Nodes.Count > 0)
                    isSurgeryLater(node.Nodes);
            }
            return isChildNode;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private Patient_Doc[] GetSelectNodes(NodeCollection nodes)
        {
            if (nodes.Count > 0)
            {
                List<Patient_Doc> patient_DocsList = new List<Patient_Doc>();
                for (int i = 0; i < nodes.Count; i++)
                {
                    Patient_Doc patient_Docs = (Patient_Doc)nodes[i].Tag;
                    if (patient_Docs.Submitted == "N") continue;

                    patient_Docs.Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + patient_Docs.Id.ToString() + "", 0, "CONTENT");
                    if (patient_Docs.Patients_doc == "" || patient_Docs.Patients_doc == null)
                    {
                        patient_Docs.Patients_doc = App.DownLoadFtpPatientDoc(patient_Docs.Id.ToString() + ".xml", currentPatient.Id.ToString());

                    }
                    patient_DocsList.Add(patient_Docs);

                }
                return patient_DocsList.ToArray();
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// ��õ�ǰ�ڵ��������в�������Ľڵ�
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ�������������</param>
        /// <returns>����Patient_Doc����</returns>
        private Patient_Doc[] GetSelectNodes(Class_Text text)
        {
            //string sql = "select a.tid,a.patients_doc,b.textname,a.textkind_id from t_patients_doc a " +
            //             " left join t_quality_text b on a.tid=b.tid " +
            //             " where a.patient_id='" + currentPatient.Id + "'and a.textkind_id=" + text.Id + " order by a.tid";
            string sql = "select tid,a.textname,textkind_id,doc_name,section_name,b.ISNEWPAGE,Bed_no from t_patients_doc a inner join t_text b on a.textkind_id = b.id where patient_id='" + currentPatient.Id + "'and textkind_id=" + text.Id + " and submitted='Y' order by doc_name";
            DataSet ds = App.GetDataSet(sql);
            Patient_Doc[] patient_Docs = null;
            //string[,] arrs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //ȥ����ͬ������
                    int tid = 0;
                    //arrs = new string[dt.Rows.Count,2];
                    if (text.Issimpleinstance == "0")
                    {
                        patient_Docs = new Patient_Doc[1];
                    }
                    else
                    {
                        patient_Docs = new Patient_Doc[dt.Rows.Count];
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                        {
                            patient_Docs[i] = new Patient_Doc();
                            patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                            {
                                patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());

                            }
                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                            if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                            {
                                patient_Docs[i].Isnewpage = "Y";
                            }
                            else
                            {
                                patient_Docs[i].Isnewpage = "N";
                            }
                            if (text.Issimpleinstance == "0")
                                break;
                        }
                        //arrs[i,0] = dt.Rows[i]["patients_doc"].ToString();
                        //arrs[i,1] = dt.Rows[i]["tid"].ToString();
                    }
                }
            }
            return patient_Docs;
        }

        /// <summary>
        /// ��õ�ǰ�ڵ��������в�������Ľڵ�
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ�������������</param>
        /// <returns>����Patient_Doc����</returns>
        private Patient_Doc[] GetSelectNodes(int textid)
        {
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());

            //string[,] arrs = null;
            Patient_Doc[] patient_Docs = null;
            if (currentPatient != null)
            {
                //    string sql = "select a.tid,a.textkind_id,a.patients_doc,b.textname,c.issimpleinstance from t_patients_doc a " +
                //                 " left join t_quality_text b on a.tid=b.tid"+
                //                 " inner join t_text c on a.textkind_id = c.id"+
                //                 " where a.patient_id='" + this.currentPatient.Id + "'  and  a.textkind_id!=135" +    //textkind_id=135��ǰ����
                //                 " and a.textkind_id in (select id from t_text where parentid=" + textid + ") order by a.textkind_id";
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name,c.ISNEWPAGE,Bed_no from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134��ǰ����
                             " and parentid=" + textid + "  and submitted='Y' order by doc_name";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        //arrs = new string[dt.Rows.Count,2];
                        //ȥ����ͬ������
                        int tid = 0;
                        patient_Docs = new Patient_Doc[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                            {

                                patient_Docs[i] = new Patient_Doc();
                                patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                                if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                                {
                                    patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());

                                }
                                patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                                patient_Docs[i].Belongtosys_id = Convert.ToInt32(dt.Rows[i]["issimpleinstance"].ToString());
                                patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                                patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                                patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                                tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                                if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                                {
                                    patient_Docs[i].Isnewpage = "Y";
                                }
                                else
                                {
                                    patient_Docs[i].Isnewpage = "N";
                                }
                            }
                            //arrs[i,0] = dt.Rows[i]["patients_doc"].ToString();
                            //if (dt.Rows[i]["issimpleinstance"].ToString() == "1")
                            //{
                            //    arrs[i,1] = dt.Rows[i]["tid"].ToString();
                            //}
                            //else
                            //{
                            //    arrs[i,1] = dt.Rows[i]["textkind_id"].ToString();
                            //}
                        }
                    }
                }
            }
            return patient_Docs;

        }


        /// <summary>
        /// ��õ�ǰ�ڵ㲡������
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ���������</param>
        /// <returns>����Patient_Doc</returns>
        private Patient_Doc[] GetSelectNodes(Patient_Doc text)
        {
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            //string sql = "select a.tid,a.patients_doc,a.textname,a.textkind_id from t_patients_doc a" +
            //             " left join t_quality_text b on a.tid=b.tid where a.patient_id='" + this.currentPatient.Id + "' "+
            //             " and a.tid=" + text.Id + " order by a.tid";
            string sql = "select a.tid,a.textname,a.textkind_id,a.createid,a.submitted,a.doc_name,a.section_name,b.ISNEWPAGE,Bed_no from t_patients_doc a inner join t_text b on a.textkind_id = b.id " +
                         "where a.patient_id='" + this.currentPatient.Id + "' and a.tid=" + text.Id + " order by doc_name";
            DataSet ds = App.GetDataSet(sql);
            Patient_Doc[] patient_Docs = null;
            //string[,] arrs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    //ȥ����ͬ������
                    int tid = 0;
                    //arrs = new string[dt.Rows.Count,2];
                    patient_Docs = new Patient_Doc[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //arrs[i,0] = dt.Rows[i]["patients_doc"].ToString();
                        //arrs[i, 1] = dt.Rows[i]["tid"].ToString();
                        if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                        {
                            patient_Docs[i] = new Patient_Doc();
                            patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                            {
                                patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                            }

                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Createid = dt.Rows[i]["createid"].ToString();
                            patient_Docs[i].Submitted = dt.Rows[i]["submitted"].ToString();
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                            if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                            {
                                patient_Docs[i].Isnewpage = "Y";
                            }
                            else
                            {
                                patient_Docs[i].Isnewpage = "N";
                            }
                        }
                    }
                }
            }
            return patient_Docs;

        }

        /// <summary>
        /// ƴ��xml�ļ�
        /// </summary>
        /// <param name="Contents">xml����</param>
        /// <param name="ucText">�༭��</param>
        /// <param name="flag">�����״β��̼�¼�Ƿ����ӽڵ�����</param>
        private void SpiltXml(Patient_Doc[] patient_Docs, frmText ucText, bool flag)
        {
            //try
            //{
            XmlDocument TempXml = new XmlDocument();
            TempXml.PreserveWhitespace = true;
            StringBuilder strBuilder = new StringBuilder();

            string sickarea = "";
            string section = "";
            string bed = "";
            ArrayList setnodes = new ArrayList();
            #region ���󲡳̼�¼û���ӽڵ�ƴ��xml
            //������
            setnodes.Clear();
            for (int i = 0; i < patient_Docs.Length; i++)
            {
                if (patient_Docs[i] == null)
                    continue;
                if (i == 0)
                {
                    setnodes = DataInit.DocSets(patient_Docs[i].Patients_doc);

                }

                XmlDocument ChildXml = new XmlDocument();
                ChildXml.PreserveWhitespace = true;
                ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                if (patient_Docs[i].Isnewpage == "Y")
                {
                    //��ʾ��������Ҫ���з�ҳ
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //sickarea = patient_Docs[i].Section_name;
                sickarea = App.ReadSqlVal("select sick_area_name from T_PATIENTS_DOC where TID=" + patient_Docs[i].Id + "", 0, "sick_area_name");
                strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name +
                    "' bed_no='" + patient_Docs[i].Bed + "' sick_area='" + sickarea + "'/>");
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//��������
            }

            #endregion

            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");






            ucText.MyDoc.ToXML(tempxmldoc.DocumentElement);





            #region ��������������
            XmlNode docnodes = tempxmldoc.DocumentElement;
            foreach (XmlNode docnode in docnodes.ChildNodes)
            {
                if (docnode.Name.ToLower() == "docsetting")
                {
                    if (setnodes.Count > 0)
                    {
                        XmlNode tempxmlnode = (XmlNode)setnodes[0];

                        //docnode.InnerXml = tempxmlnode.InnerXml;
                        //docnode.Attributes[""].Value=tempxmlnode
                        docnode.Attributes.RemoveAll();

                        for (int i = 0; i < tempxmlnode.Attributes.Count; i++)
                        {
                            XmlAttribute attr = null;
                            attr = tempxmldoc.CreateAttribute(tempxmlnode.Attributes[i].Name);
                            attr.Value = tempxmlnode.Attributes[i].Value;
                            docnode.Attributes.Append(attr);
                        }
                    }
                }

                if (docnode.Name.ToLower() == "pagesetting")
                {
                    if (setnodes.Count > 1)
                    {
                        XmlNode tempxmlnode = (XmlNode)setnodes[1];
                        docnode.Attributes.RemoveAll();
                        for (int i = 0; i < tempxmlnode.Attributes.Count; i++)
                        {
                            //docnode.Attributes[i].Value = tempxmlnode.Attributes[i].Value;

                            XmlAttribute attr = null;
                            attr = tempxmldoc.CreateAttribute(tempxmlnode.Attributes[i].Name);
                            attr.Value = tempxmlnode.Attributes[i].Value;
                            docnode.Attributes.Append(attr);
                        }
                    }
                }
            }
            #endregion

            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
            string ss = strBuilder.ToString();
            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            {
                if (bodyNode.Name == "body")
                {
                    bodyNode.InnerXml = strBuilder.ToString();
                }
            }

            //DataInit.setXmlHead(tempxmldoc.DocumentElement, sickarea,);




            ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);




            //'����Ѫ�Ǽ���¼��','PICC�����¼��','����(������)�����¼��',��������Ƥ�����ع۲��',
            //'�����ص�ע�۲��¼��'
            if (patient_Docs.Length > 0)
            {
                if (patient_Docs[0].Textkind_id == 2172 || patient_Docs[0].Textkind_id == 2173 ||
                    patient_Docs[0].Textkind_id == 2175 || patient_Docs[0].Textkind_id == 2178
                    || patient_Docs[0].Textkind_id == 2179)
                {
                    ucText.MyDoc.PageStartIndex = NowTree.SelectedNode.Index;
                }
            }
            ucText.MyDoc.ContentChanged();
            ucText.Dock = DockStyle.Fill;

            ucText.MyDoc.Locked = true;
            //}
            //catch(Exception ex)
            //{
            //    App.MsgErr("�����ȡʧ�ܣ�ԭ��:"+ex.Message);
            //}
        }

        //�޸ı���
        private void �޸ı���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] arr = NowTree.SelectedNode.Text.Split(' ');
            string current_Time = arr[0] + " " + arr[1];
            string current_TextName = "";
            if (arr.Length > 2)
                current_TextName = arr[arr.Length - 1];
            string tid = NowTree.SelectedNode.Name;
            frmUpdateTime frmTime = new frmUpdateTime(current_Time, current_TextName, true);
            App.FormStytleSet(frmTime, false);
            frmTime.Event_GetRecord += new DeleGetRecord(GetDate);
            frmTime.ShowDialog();
            if (frmTime.flag)
            {
                string pid = currentPatient.PId;
                string patient_Id = currentPatient.Id.ToString();
                string update_TextName = Record_Time + "   " + Record_Content;
                string Sql = "update t_quality_text set textname ='" + update_TextName + "' " +
                             "where patient_id = '" + patient_Id + "' and tid=" + tid + "";
                int count = App.ExecuteSQL(Sql);
                if (count > 0)
                {
                    NowTree.SelectedNode.Text = update_TextName;
                    Record_Time = null;
                    Record_Content = null;
                    App.Msg("�޸ĳɹ���");
                }
            }
        }

        private void �����β鷿ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (NowTree.SelectedNode != null)
            {
                //��֤Ȩ��
                string msgerr = App.Get_Text_Buttns_Set_rights(currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode as object, currentPatient, 0);
                if (msgerr == "")
                {
                    msgerr = Bifrost.Class_Doc_Rule.Day_Medical_Record_Rule(currentPatient.Id.ToString(), currentPatient.In_Time, 0, "", Convert.ToDateTime(App.GetSystemTime()), NowTree.SelectedNode.Text, 2);
                    if (msgerr == "")
                    {
                        Patient_Doc doc = NowTree.SelectedNode.Tag as Patient_Doc;
                        string sql = "update t_patients_doc set ISRAPLACEHIGHTDOCTOR='Y' where tid=" + doc.Id;
                        int count = App.ExecuteSQL(sql);
                        if (count > 0)
                        {
                            ReflashTrvBook();
                            //ˢ�½ڵ�
                            SetSelectNode(NowTree.Nodes);
                            //չ����ǰѡ�еĽڵ�
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("�޸ĳɹ���");
                        }
                    }
                    else
                    {
                        App.Msg(msgerr);
                    }
                }
                else
                {
                    App.Msg(msgerr);
                }
            }
        }

        private void �����β鷿ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (NowTree.SelectedNode != null)
            {
                //��֤Ȩ��
                string msgerr = App.Get_Text_Buttns_Set_rights(currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode as object, currentPatient, 0);
                if (msgerr == "")
                {
                    msgerr = Bifrost.Class_Doc_Rule.Day_Medical_Record_Rule(currentPatient.Id.ToString(), currentPatient.In_Time, 0, "", Convert.ToDateTime(App.GetSystemTime()), NowTree.SelectedNode.Text, 1);
                    if (msgerr == "")
                    {
                        Patient_Doc doc = NowTree.SelectedNode.Tag as Patient_Doc;
                        string sql = "update t_patients_doc set ISRAPLACEHIGHTDOCTOR2='Y' where tid=" + doc.Id;
                        int count = App.ExecuteSQL(sql);
                        if (count > 0)
                        {
                            ReflashTrvBook();
                            //ˢ�½ڵ�
                            SetSelectNode(NowTree.Nodes);
                            //չ����ǰѡ�еĽڵ�
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("�޸ĳɹ���");
                        }
                    }
                    else
                    {
                        App.Msg(msgerr);
                    }
                }
                else
                {
                    App.Msg(msgerr);
                }
            }
        }

        private void ȡ�����ϼ��鷿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                string msgerr = App.Get_Text_Buttns_Set_rights(currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode as object, currentPatient, 0);

                if (msgerr == "")
                {
                    string docName = "";
                    if (NowTree.SelectedNode.Text.Contains("��") || NowTree.SelectedNode.Text.Contains("*"))
                    {
                        docName = NowTree.SelectedNode.Text.Substring(1);
                    }
                    msgerr = Bifrost.Class_Doc_Rule.Day_Medical_Record_Rule(currentPatient.Id.ToString(), currentPatient.In_Time, 0, "", Convert.ToDateTime(App.GetSystemTime()), docName, 0);
                    if (msgerr == "")
                    {
                        Patient_Doc doc = NowTree.SelectedNode.Tag as Patient_Doc;
                        string sql = "";
                        if (doc.Isreplacehighdoctor == "Y")
                        {
                            sql = "update t_patients_doc set ISRAPLACEHIGHTDOCTOR='N' where tid=" + doc.Id;
                        }
                        else if (doc.Isreplacehighdoctor2 == "Y")
                        {
                            sql = "update t_patients_doc set ISRAPLACEHIGHTDOCTOR2='N' where tid=" + doc.Id;
                        }
                        int count = App.ExecuteSQL(sql);
                        if (count > 0)
                        {
                            CurrentNode = NowTree.SelectedNode;
                            ReflashTrvBook();
                            //ˢ�½ڵ�
                            SetSelectNode(NowTree.Nodes);
                            //չ����ǰѡ�еĽڵ�
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("�޸ĳɹ���");
                        }
                    }
                    else
                    {
                        App.Msg(msgerr);
                    }
                }
                else
                {
                    App.Msg(msgerr);
                }
            }
        }

        #region ȫ������������
        AdvTree NowTree = new AdvTree();
        /// <summary>
        /// 1.������˫���¼�
        /// 2.��˫���������Ľڵ�ʱ����
        /// 3.��������Ĵ�Ȩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            if (OperateState != null && !OperateState.Contains("��¼"))//  ����
            {
                App.Msg("��ʾ : û����Ȩ����Ĳ�¼Ȩ��!");
                return;
            }
            AddDoc();
        }

        /// <summary>
        /// ��д����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            if (OperateState != null && !OperateState.Contains("�޸�"))
            {
                App.Msg("��ʾ : û����Ȩ������޸�Ȩ��ֻ���������������Ҽ����!");
                return;
            }
            if (DataInit.boolAgree)// || ((OperateState.Contains("�鿴") || OperateState.Contains("����"))&& !OperateState.Contains("�޸�")))
            {
                App.Msg("���ĵ�����ֻ���������������Ҽ����!");
                return;
            }

            bool isright = isRightBook(NowTree.SelectedNode);
            if (isright)
            {
                bool isFlag = IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
                if (!isFlag)
                {
                    Class_Text text = null;
                    //�õ��������Ͷ���
                    if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        text = NowTree.SelectedNode.Tag as Class_Text;
                    }
                    else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                    {
                        text = NowTree.SelectedNode.Parent.Tag as Class_Text;
                    }
                    //if (text.Right_range == "N")
                    //{
                    //    /*
                    //     *��ʿ����
                    //     */
                    //    create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                    //}
                    //else
                    //{
                    //    /*
                    //     *ҽ�� 
                    //     */
                    //    if(App.UserAccount.CurrentSelectRole.Role_type=="D")
                    //    {
                    //        AddDoc();
                    //    }
                    //    else
                    //    {
                    //       tlspmnitBrowse_Click(sender, e);
                    //    }
                    //}
                    if (text.Right_range == App.UserAccount.CurrentSelectRole.Role_type ||
                       text.Right_range == "A" ||
                       App.UserAccount.CurrentSelectRole.Role_type == "Z")//�ṩ�ʿؿƲ鿴�ۼ�,��Ϊ�ۼ�ֻ�ڱ༭״̬���ܲ鿴
                    {
                        //�����¼����д������ֻ�����.Textcode == "EMR100009"
                        //��ڵ�������״̬
                        if ((text.Parentid == 147 && text.Textname == "�����¼")||
                            (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text") && text.Issimpleinstance=="1"))
                            tlspmnitBrowse_Click(sender, e);
                        else
                            AddDoc();//��ɫ�������������Ͷ�Ӧ
                    }
                    else
                    {
                        //��������
                        if (!create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient))
                        {
                            //�Ƕ�������
                            //���״̬��ʾ����
                            tlspmnitBrowse_Click(sender, e);
                        }



                    }

        #endregion
                }
            }
        }




        /// <summary>
        /// ��������
        /// </summary>
        private void AddDoc()
        {

            /*
             * ��������ʵ��˼·��
             * 1.�����������ͣ�����סԺ��pid���õ�����id
             * 2.��������id ���ɱ༭���������û��ؼ�
             */
            string log_Tid = "";
            try
            {
                if (NowTree.SelectedNode != null)
                {
                    log_Tid = NowTree.SelectedNode.Name;
                    CurrentNode = (Node)NowTree.SelectedNode.DeepCopy();
                    DataInit.BK_ID = 0;
                    if (NowTree.SelectedNode.Tag != null)
                    {
                        int tid = 0;
                        /*
                         * tctlDoc����tabItem���ж��Ƿ����ظ��ġ�
                         * tctlDoc��û��tabItem����ֱ�Ӵ���
                         */
                        if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                        {
                            Class_Text text = NowTree.SelectedNode.Tag as Class_Text;

                          

                            //text.Ishighersign
                            currentPatient = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString());
                            InPatientInfo inPatient = null;
                            inPatient = currentPatient;


                        


                            if (inPatient.Gender_Code.Trim() == "Ů")
                            {
                                inPatient.Gender_Code = "1";
                            }
                            string temptid = "";
                            if (text != null && text.Issimpleinstance == "0")//��������
                            {
                                temptid = isExitRecord(text.Id, inPatient.Id);//�жϸ��൥�������Ƿ����
                                if (temptid != null && temptid != "")
                                {
                                    tid = getTidByTextIdAndPid(text.Id, inPatient.Id.ToString());
                                }
                                else
                                {
                                    tid = 0;
                                }
                            }
                            else
                            {
                                tid = 0;
                            }

                            if (tctlDoc.Tabs.Count > 0)
                            {
                                /*
                                 * IsSameTabItem()�ж�tctlDoc�Ƿ�����ͬ����������(TabItem)
                                 * IsSameBookDoc()�ж�tctlDoc�Ƿ�����ͬ������(TabItem)
                                 */
                                if (IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")) == false)          //false��ʾ����û����ͬ��tabItem
                                {
                                    if (text.Isenable == "1")
                                    {
                                        //������������
                                        create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                                    }
                                    else
                                    {
                                        //�����Ƕ�������
                                        CreateTabItem(tid);
                                    }
                                }
                            }
                            else
                            {
                                if (text.Isenable == "1")
                                {
                                    //������������
                                    create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                                }
                                else
                                {
                                    //�����Ƕ�������
                                    CreateTabItem(tid);
                                }

                            }
                        }
                        else if (NowTree.SelectedNode.Tag.ToString().Contains("Patient_Doc"))
                        {
                            //�Ѿ�д�Ķ�������
                            CreateTabItem(Convert.ToInt32(NowTree.SelectedNode.Parent.Name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                int patient_Id = currentPatient.Id;
                //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);
                App.MsgErr("���������쳣��ԭ��" + ex.Message);
            }
        }
        public void IniMainToobar()
        {
            App.A_btnInsertDiosgin = null;
            App.A_btnInsertDiosgin += new EventHandler(btnInsertDiosgin_Click);

            App.A_btnRefreshDiosgin = null;
            App.A_btnRefreshDiosgin += new EventHandler(btnRefreshDiosgin_Click);

        }

      

        /// <summary>
        /// �����µ�tabItem
        /// </summary>
        /// <param name="tid">����id</param>
        private void CreateTabItem(int tid)
        {
            //yunbarTemplate.Hide();
            //if (tid == 0 && NowTree.Name == "advFinishDoc")
            //{
            //    return;
            //}           
            Record_Content = "";
            Record_Time = "";
            string docflaag = "";
            string suporSign = "";  //�鷿�ϼ�ҽʦ��userId
            
            /*
             * �����µ�tabItem ��ʵ��˼·��
             * 1.��ǰѡ�е������������ǵ������飬�Ͳ�������ݡ�
             * 2.��ǰѡ�е��ǲ������飬��������id�����������
             */
            //CurrentNode = advAllDoc.SelectedNode.Clone() as TreeNode;
            // ��õ�ǰʱ�䣬��ȷ������
            // string time = string.Format("{0:g}", App.GetSystemTime());
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);

            page.Click += new EventHandler(page_Click);

            if (tid == 0)
            {
                
                Class_Text text = NowTree.SelectedNode.Tag as Class_Text;
                
                if (IsHomogeneityCase("0,102,6988518,284,0", "," + text.Id.ToString().Trim() + ",", currentPatient.Id) == true)
                {
                    App.MsgErr("���������쳣��ԭ������дͬ������");
                    return;
                }
                if (isSqjc(text.Id.ToString().Trim(), currentPatient.Id) == true)
                {
                    App.MsgErr("����д��ǰС�ᣡ");
                }


                //�½����飬pageҳ��Name�÷ֺŸ�������һλ��������������ID;�ڶ�λ����������;����λ�������½�����;����λ���Ƿ�������
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
                flagtq = true;
                //�����Ӧ��ҽ�񴦹���ID
                DataSet YWC_RAW = App.GetDataSet("select a.var_id from t_doc_quality_relation a  where a.text_id=" + text.Id + "");
                if (YWC_RAW.Tables[0].Rows.Count > 0)
                {
                    string strval = "";
                    for (int i = 0; i < YWC_RAW.Tables[0].Rows.Count; i++)
                    {
                        if (strval == "")
                        {
                            strval = YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                        else
                        {
                            strval = strval + "," + YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                    }

                    //������ĺ���ʿؼ�¼
                    //string valsql = "select t.id,t.pid,t.pv,t2.��� as doctypeid,substr(t.note,1,INSTR(t.note,'\"',1,1)-5) as ���ʱ��,t.note as ���˵��,t.patient_id from t_quality_record t inner join quality_var_ywc_view t2 on t.doctype=t2.�ĵ����� where t.pv=1 and t2.��� in (" + strval + ") and t.patient_id=" + currentPatient.Id + " order by to_date(substr(t.note,1,INSTR(t.note,'\"',1,1)-5),'YYYY-MM-DD HH24:MI'),t.note desc";
                    //DataSet Quarry_record = App.GetDataSet(valsql);// and t.patient_id=" + currentPatient.Id + "
                    //if (Quarry_record != null)
                    //{
                    //    if (Quarry_record.Tables[0].Rows.Count > 0)
                    //    {
                    //        frmCreateDocSet fc = new frmCreateDocSet(Quarry_record);
                    //        App.FormStytleSet(fc, false);
                    //        fc.ShowDialog();
                    //    }
                    //}
                }
            }
            else //�޸����飬pageҳ��Name�÷ֺŸ�������һλ������ID���ڶ�λ����������
            {
                ucDoctorOperater.flagtq = false;
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString();
            }

            page.Text = NowTree.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " ��)";
            if (NowTree.SelectedNode.Tag != null)
            {
                if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text tempcl = (Class_Text)NowTree.SelectedNode.Tag;
                    if (App.UserAccount.CurrentSelectRole.Role_type != tempcl.Right_range &&
                        tempcl.Right_range != "A" &&
                       App.UserAccount.CurrentSelectRole.Role_type != "Z")//�ṩ�ʿؿƲ鿴�ۼ�,��Ϊ�ۼ�ֻ�ڱ༭״̬���ܲ鿴
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        App.Msg("��û����д���������Ȩ�ޣ�");
                        return;
                    }

                }
            }



            if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                if (NowTree.SelectedNode.Nodes.Count == 0 ||
                    NowTree.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    Class_Text select_text = NowTree.SelectedNode.Tag as Class_Text;
                    page.Tag = currentPatient as object;
                    if (page.Tag != null)
                    {
                        barTemplate.AutoHide = true;
                        string log_Tid = NowTree.SelectedNode.Name;
                        isCustom = false;
                        //�Ƿ���Կ���
                        bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                        string textTitle = GetTextTitle(NowTree.SelectedNode);

                        if (select_text.Other_textname != "")
                        {
                            textTitle = select_text.Other_textname;
                        }

                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        Class_Text cText = NowTree.SelectedNode.Tag as Class_Text;
                        //page.Tooltip = cText.Id.ToString();
                        if (cText.Submitted == "Y")
                        {
                            docflaag = "Y";

                        }
                        else
                        {
                            //App.SetToolButtonByUser("ttsbtnPrint", false);
                            docflaag = "N";
                        }
                        page.Tooltip = docflaag;

                        #region ʱ���������
                        isFlagtrue = false;
                        if (select_text.Ishavetime == "A") //�༭������ʾʱ�����
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                        }
                        else if ((select_text.Ishavetime == "B" || select_text.Ishavetime == "C") && tid == 0)//������ʾ�򣬱༭������ʾ������+ʱ�����
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                            frmUpdateTime frmTime = null;
                            if (NowTree.SelectedNode.Name == "127")//�ϼ��鷿��¼
                            {
                                frmTime = new frmUpdateTime(Record_Time, "�鷿��¼", true);
                                frmTime.Event_GetRecord += new DeleGetRecord(GetDate);

                                frmTime.ShowDialog();
                                if (!isFlagtrue)
                                {
                                    return;
                                }
                                suporSign = frmTime.suporSign;
                            }
                            else
                            {
                                
                                frmTime = new frmUpdateTime(Record_Time, NowTree.SelectedNode.Text, false);
                                frmTime.Event_GetRecord += new DeleGetRecord(GetDate);
                                DialogResult dr = frmTime.ShowDialog();
                                if (!isFlagtrue)
                                {
                                    return;
                                }
                            }
                        }
                        else if (select_text.Ishavetime == "")
                        {
                            if (Record_Time == "")
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");

                        }
                        if (NowTree.SelectedNode.Text == "������¼")
                        {
                            Record_Content = "������¼";

                        }
                        #endregion

                        if (cText.Issimpleinstance == "1")            //1�����ʵ������
                        {
                            if (inpatient.Sick_Bed_Name != "")
                            {
                                if (!IsSameBookDoc() && !IsSameTabItem(NowTree.SelectedNode.Name, Record_Time))
                                {
                                    if (page.Name.Split(';').Length == 4)
                                    {//��������ѡ�����ʱ���¼,��ֹ�ظ�ʱ�����
                                        page.Name += ";" + Record_Time;
                                    }
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //��ȡ�����Ĭ��ģ��
                                    {

                                        // Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                                        
                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        //��ʾ���а�ť (����Ա�) 
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        //    App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;
                                        SetTextButtonFase(text);
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs                                       
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);


                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc.PreserveWhitespace = true;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (content.Contains("emrtextdoc"))
                                        {
                                            tempxmldoc.LoadXml(content);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime =="C")
                                                        {//ʱ�����������ʱ����
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tempxmldoc.LoadXml("<emrtextdoc/>");
                                            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";

                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//ʱ�����������ʱ����
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                    }
                                                    if (NowTree.SelectedNode.Text.Contains("�ճ����̼�¼") ||
                                                        NowTree.SelectedNode.Text.Contains("ҽ����ͨ��¼"))
                                                    {
                                                        text.MyDoc.HidleNameTitle = true;
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }

                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        //����֪��ͬ�����м��Ĭ��6
                                        if (cText.Id == 1601)
                                        {
                                            text.MyDoc.Info.LineSpacing = 6;
                                            text.MyDoc.Info.ParagraphSpacing = 6;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        text.MyDoc.HidleNameTitle = true;
                                        //if (advAllDoc.SelectedNode.Name == "1102") //͸��
                                        //{
                                        //    text.MyDoc._InsertMoreDiv(Record_Time + " " + Record_Content);
                                        //}                                      

                                    }
                                    else
                                    {
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        //Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        SetTextButtonFase(text);
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                                        text.MyDoc.SuporSign = suporSign; //�鷿�ϼ�ҽʦuserId

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;
                                       
                                        DataInit.SetToolEvent(text);
                                       // IniMainToobar();
                                        App.A_RefleshTreeBook = null;
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;

                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                        }
                                        if (NowTree.SelectedNode.Text.Contains("ҽ����ͨ��¼"))
                                        {
                                            text.MyDoc.HidleNameTitle = true;
                                        }
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                    }
                                }
                                else
                                {
                                    Record_Time = null;
                                    Record_Content = null;
                                    return;
                                }

                            }
                        }
                        else//��������
                        {
                            string temptid = isExitRecord(cText.Id, currentPatient.Id);
                            if (temptid != null && temptid != "")   //����Ѿ����ڣ������޸ġ�
                            {
                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    tid = Convert.ToInt32(temptid);
                                    //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true);
                                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                    string strbed_no = App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + inpatient.Id + "' and a.bed_id=c.bed_id and b.section_name=(select section_name from t_patients_doc where tid='"+temptid+"') and rownum=1 order by happen_time desc", 0, "bed_no");
                                    //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                    if (cText.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }
                                    if (strbed_no!=null && strbed_no!="")
                                    {
                                        text.MyDoc.Bed_name = strbed_no; 
                                    }
                                    //��ʾ���а�ť (����Ա�)
                                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                    //     App.UserAccount.CurrentSelectRole.Role_type == "N")
                                    //    text.MyDoc.EnableShowAll = false;
                                    //else
                                    SetTextButtonFase(text);
                                    text.MyDoc.EnableShowAll = true;
                                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                    text.MyDoc.IgnoreLine = NeglectLine;
                                    XmlDocument tmpxml = new System.Xml.XmlDocument();
                                    tmpxml.PreserveWhitespace = true;
                                    string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name from t_patients_doc where textkind_id=" + cText.Id + " and patient_id=" + inpatient.Id + "";
                                    DataTable dt = App.GetDataSet(sql).Tables[0];

                                    string content = "";
                                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                                    if (content == "" || content == null)
                                    {
                                        content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", inpatient.Id.ToString()); //dt.Rows[0]["patients_doc"].ToString();
                                    }

                                    string ishighersign = dt.Rows[0]["Ishighersign"].ToString();
                                    string havedoctorsign = dt.Rows[0]["Havedoctorsign"].ToString();
                                    string havehighersign = dt.Rows[0]["Havehighersign"].ToString();
                                    docflaag = dt.Rows[0]["submitted"].ToString();
                                    text.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                                    //����ʾ��ǰ���һ��ǲ��˵�ʱ����
                                    //if (OperateState != null && OperateState.Contains("��¼"))
                                    //{
                                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                                    //}
                                    //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                    text.MyDoc.TextSuperiorSignature = ishighersign;
                                    text.MyDoc.HaveTubebedSign = havedoctorsign;  //�ܴ�ҽ���Ƿ���ǩ
                                    text.MyDoc.HaveSuperiorSignature = havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                                    
                                    if (select_text.Ishavetime != "")
                                    {
                                        text.MyDoc.NeedTimeTitle = true;
                                    }

                                    if (select_text.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }

                                    tmpxml.LoadXml(content);
                                    if (NowTree.SelectedNode.Text.Contains("�ճ����̼�¼"))
                                    {
                                        text.MyDoc.HidleNameTitle = true;
                                    }
                                    DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                                    text.MyDoc.ContentChanged();
                                    tabctpnDoc.Controls.Add(text);
                                    text.Dock = DockStyle.Fill;

                                }
                            }
                            else
                            {

                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name,DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //��ȡ�����Ĭ��ģ��
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                       
                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        //������Ȩ(ί��)�� 1603 �Զ���Ժͬ���� 1585 ����Ҫ�ܴ�ǩ��
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }
                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (cText.Id == 1603 || cText.Id == 1585)
                                        {
                                            text.MyDoc.HaveTubebedSign = "Y";
                                        }
                                        else
                                        {
                                            text.MyDoc.HaveTubebedSign = "N";//�ܴ�ҽ���Ƿ���ǩ
                                        }
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc.PreserveWhitespace = true;
                                        if (content.Contains("emrtextdoc"))
                                        {
                                            tempxmldoc.LoadXml(content);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tempxmldoc.LoadXml("<emrtextdoc/>");
                                            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                            //tempxmldoc.SelectSingleNode("emrtextdoc/body").InnerXml = "";
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        text.MyDoc.NeedTimeTitle = true;
                                                        bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }
                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);

                                        //������Ȩ��ί�У����м��4
                                        if (cText.Id == 1603)
                                        {
                                            text.MyDoc.Info.LineSpacing = 4;
                                            text.MyDoc.Info.ParagraphSpacing = 4;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                    }
                                    else
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        
                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        DataInit.SetToolEvent(text);
                                        //IniMainToobar();
                                        App.A_RefleshTreeBook = null;
                                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                        }
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                    }
                                }
                            }
                        }



                        int patient_Id = currentPatient.Id;
                        //��¼������־
                        //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);

                        tabctpnDoc.TabItem = page;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        //if (docflaag == "Y" || NowTree.SelectedNode.Text == "סԺ������ҳ" || NowTree.SelectedNode.Text == "���߻�����Ϣ")
                        //{
                        //    App.SetToolButtonByUser("tsbtnTempSave", false);
                        //}
                        //else
                        //{
                        //    App.SetToolButtonByUser("tsbtnTempSave", true);
                        //}
                    }
                    else
                    {
                        App.Msg("�˲��˴����쳣��");
                    }
                }

            }
            else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {

                Class_Text cText = NowTree.SelectedNode.Parent.Tag as Class_Text;
                barTemplate.AutoHide = true;
                //�����������
                string textTitle = GetTextTitle(NowTree.SelectedNode);
                //�Ƿ���Ժ��Կ���
                bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                page.Tag = currentPatient as object;
                Record_Time = NowTree.SelectedNode.Text;
                InPatientInfo inpatient = page.Tag as InPatientInfo;
                if (inpatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    //��δ�ύ����ͨ����浽arraylist
                    //save_TextId.Add(advAllDoc.SelectedNode.Name);
                    
                    Patient_Doc pdoc = NowTree.SelectedNode.Tag as Patient_Doc;
                    tid = pdoc.Id;

                    frmText text;
                    if (cText.Id == 103)
                    {
                        text = new frmText(pdoc.Textkind_id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                    }
                    else
                    {
                        text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                    }
                   
                    //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                    if (cText.Isneedsign == "Y")
                    {
                        text.MyDoc.AutoGraph = true;
                    }
                    if (textTitle.Contains("����Ѫ�Ǽ���¼��") || textTitle.Contains("����(������)�����¼��") ||
                        textTitle.Contains("��������Ƥ�����ع۲��") || textTitle.Contains("�����ص�ע�۲��¼��") ||
                        textTitle.Contains("PICC�����¼��"))
                    {
                        int nodeIndex = advFinishDoc.SelectedNode.Index;
                        text.MyDoc.PageStartIndex = nodeIndex;
                    }
                    //��ʾ���а�ť (����Ա�)
                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                    //                     App.UserAccount.CurrentSelectRole.Role_type == "N")
                    //    text.MyDoc.EnableShowAll = false;
                    //else
                    SetTextButtonFase(text);
                    text.MyDoc.EnableShowAll = true;

                    // text.MyDoc.Section_name = pdoc.Section_name;//������������ 
                    //if (pdoc.Createid == App.UserAccount.UserInfo.User_id)
                    //{
                        text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //else
                    //{
                        text.MyDoc.Section_name = pdoc.Section_name;//������������ 
                    //}
                        text.MyDoc.Bed_name = pdoc.Bed;
                        //DataInit.strbed = pdoc.Bed;
                    //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //�ܴ�ҽ���Ƿ���ǩ
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //�鷿ҽ����userId
                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                    if (text.MyDoc.OwnerControl.ContextMenuStrip!=null)
                    {
                        text.MyDoc.OwnerControl.ContextMenuStrip.Items[1].Visible = false;

                    }
                    text.MyDoc.IgnoreLine = NeglectLine;
                    //�������Ǳ����ҵ�����
                    string[] sections = cText.Sid.Split(',');
                    bool sectionflag = false;
                    for (int k = 0; k < sections.Length; k++)
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_Id == sections[k])
                        {
                            sectionflag = true;
                            break;
                        }
                    }

                    System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + pdoc.Id + "", 0, "CONTENT");

                    if (content == "" || content == null)
                    {
                        content = App.DownLoadFtpPatientDoc(pdoc.Id + ".xml", inpatient.Id.ToString());
                    }

                    tmpxml.LoadXml(content);
                    DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();
                    tabctpnDoc.Controls.Add(text);
                    text.Dock = DockStyle.Fill;
                    DataInit.SetToolEvent(text);

                    //IniMainToobar();
                    App.A_RefleshTreeBook = null;
                    App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                    tabctpnDoc.TabItem = page;
                    page.Tooltip = docflaag;
                    tabctpnDoc.Dock = DockStyle.Fill;
                    page.AttachedControl = tabctpnDoc;
                    this.tctlDoc.Controls.Add(tabctpnDoc);
                    this.tctlDoc.Tabs.Add(page);
                    this.tctlDoc.Refresh();
                    this.tctlDoc.SelectedTab = page;
                    string log_Tid = NowTree.SelectedNode.Name;
                    int patient_Id = currentPatient.Id;
                    //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);
                    //��������
                    if (!sectionflag)
                    {
                        // text.MyDoc.Locked = true;
                    }
                }
            }

            //if (docflaag == "Y")
            //{
            //App.SetToolButtonByUser("tsbtnTempSave", false);
            //App.SetToolButtonByUser("tsbtnTemplateSave", false);

            //}
            //else
            //{
            //    App.SetToolButtonByUser("ttsbtnPrint", false);
            //}
            App.AddCurrentDocMsg(currentPatient.Id.ToString() + page.Text);
        }

        /// <summary>
        /// �����µ�tabItem �����Ƿ�������
        /// </summary>
        /// <param name="tid">����id</param>
        private void CreateTabItem(int tid,bool issound)
        {
            //yunbarTemplate.Hide();
            //if (tid == 0 && NowTree.Name == "advFinishDoc")
            //{
            //    return;
            //}           
            Record_Content = "";
            Record_Time = "";
            string docflaag = "";
            string suporSign = "";  //�鷿�ϼ�ҽʦ��userId

            /*
             * �����µ�tabItem ��ʵ��˼·��
             * 1.��ǰѡ�е������������ǵ������飬�Ͳ�������ݡ�
             * 2.��ǰѡ�е��ǲ������飬��������id�����������
             */
            //CurrentNode = advAllDoc.SelectedNode.Clone() as TreeNode;
            // ��õ�ǰʱ�䣬��ȷ������
            // string time = string.Format("{0:g}", App.GetSystemTime());
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);

            page.Click += new EventHandler(page_Click);

            if (tid == 0)
            {

                Class_Text text = NowTree.SelectedNode.Tag as Class_Text;

                if (IsHomogeneityCase("0,102,6988518,284,0", "," + text.Id.ToString().Trim() + ",", currentPatient.Id) == true)
                {
                    App.MsgErr("���������쳣��ԭ������дͬ������");
                    return;
                }
                if (isSqjc(text.Id.ToString().Trim(), currentPatient.Id) == true)
                {
                    App.MsgErr("����д��ǰС�ᣡ");
                }


                //�½����飬pageҳ��Name�÷ֺŸ�������һλ��������������ID;�ڶ�λ����������;����λ�������½�����;����λ���Ƿ�������
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
                flagtq = true;
                //�����Ӧ��ҽ�񴦹���ID
                DataSet YWC_RAW = App.GetDataSet("select a.var_id from t_doc_quality_relation a  where a.text_id=" + text.Id + "");
                if (YWC_RAW.Tables[0].Rows.Count > 0)
                {
                    string strval = "";
                    for (int i = 0; i < YWC_RAW.Tables[0].Rows.Count; i++)
                    {
                        if (strval == "")
                        {
                            strval = YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                        else
                        {
                            strval = strval + "," + YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                    }

                    //������ĺ���ʿؼ�¼
                    //string valsql = "select t.id,t.pid,t.pv,t2.��� as doctypeid,substr(t.note,1,INSTR(t.note,'\"',1,1)-5) as ���ʱ��,t.note as ���˵��,t.patient_id from t_quality_record t inner join quality_var_ywc_view t2 on t.doctype=t2.�ĵ����� where t.pv=1 and t2.��� in (" + strval + ") and t.patient_id=" + currentPatient.Id + " order by to_date(substr(t.note,1,INSTR(t.note,'\"',1,1)-5),'YYYY-MM-DD HH24:MI'),t.note desc";
                    //DataSet Quarry_record = App.GetDataSet(valsql);// and t.patient_id=" + currentPatient.Id + "
                    //if (Quarry_record != null)
                    //{
                    //    if (Quarry_record.Tables[0].Rows.Count > 0)
                    //    {
                    //        frmCreateDocSet fc = new frmCreateDocSet(Quarry_record);
                    //        App.FormStytleSet(fc, false);
                    //        fc.ShowDialog();
                    //    }
                    //}
                }
            }
            else //�޸����飬pageҳ��Name�÷ֺŸ�������һλ������ID���ڶ�λ����������
            {
                ucDoctorOperater.flagtq = false;
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString();
            }

            page.Text = NowTree.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " ��)";
            if (NowTree.SelectedNode.Tag != null)
            {
                if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text tempcl = (Class_Text)NowTree.SelectedNode.Tag;
                    if (App.UserAccount.CurrentSelectRole.Role_type != tempcl.Right_range &&
                        tempcl.Right_range != "A" &&
                       App.UserAccount.CurrentSelectRole.Role_type != "Z")//�ṩ�ʿؿƲ鿴�ۼ�,��Ϊ�ۼ�ֻ�ڱ༭״̬���ܲ鿴
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        App.Msg("��û����д���������Ȩ�ޣ�");
                        return;
                    }

                }
            }



            if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                if (NowTree.SelectedNode.Nodes.Count == 0 ||
                    NowTree.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    Class_Text select_text = NowTree.SelectedNode.Tag as Class_Text;
                    page.Tag = currentPatient as object;
                    if (page.Tag != null)
                    {
                        barTemplate.AutoHide = true;
                        string log_Tid = NowTree.SelectedNode.Name;
                        isCustom = false;
                        //�Ƿ���Կ���
                        bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                        string textTitle = GetTextTitle(NowTree.SelectedNode);

                        if (select_text.Other_textname != "")
                        {
                            textTitle = select_text.Other_textname;
                        }

                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        Class_Text cText = NowTree.SelectedNode.Tag as Class_Text;
                        //page.Tooltip = cText.Id.ToString();
                        if (cText.Submitted == "Y")
                        {
                            docflaag = "Y";

                        }
                        else
                        {
                            //App.SetToolButtonByUser("ttsbtnPrint", false);
                            docflaag = "N";
                        }
                        page.Tooltip = docflaag;

                        #region ʱ���������
                        isFlagtrue = false;
                        if (select_text.Ishavetime == "A") //�༭������ʾʱ�����
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                        }
                        else if ((select_text.Ishavetime == "B" || select_text.Ishavetime == "C") && tid == 0)//������ʾ�򣬱༭������ʾ������+ʱ�����
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                            frmUpdateTime frmTime = null;
                            if (NowTree.SelectedNode.Name == "127")//�ϼ��鷿��¼
                            {
                                frmTime = new frmUpdateTime(Record_Time, "�鷿��¼", true);
                                frmTime.Event_GetRecord += new DeleGetRecord(GetDate);

                                frmTime.ShowDialog();
                                if (!isFlagtrue)
                                {
                                    return;
                                }
                                suporSign = frmTime.suporSign;
                            }
                            else
                            {

                                if (!issound)
                                {
                                    frmTime = new frmUpdateTime(Record_Time, NowTree.SelectedNode.Text, false);
                                    frmTime.Event_GetRecord += new DeleGetRecord(GetDate);
                                    DialogResult dr = frmTime.ShowDialog();
                                    if (!isFlagtrue)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        else if (select_text.Ishavetime == "")
                        {
                            if (Record_Time == "")
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");

                        }
                        if (NowTree.SelectedNode.Text == "������¼")
                        {
                            Record_Content = "������¼";

                        }
                        #endregion

                        if (cText.Issimpleinstance == "1")            //1�����ʵ������
                        {
                            if (inpatient.Sick_Bed_Name != "")
                            {
                                if (!IsSameBookDoc() && !IsSameTabItem(NowTree.SelectedNode.Name, Record_Time))
                                {
                                    if (page.Name.Split(';').Length == 4)
                                    {//��������ѡ�����ʱ���¼,��ֹ�ظ�ʱ�����
                                        page.Name += ";" + Record_Time;
                                    }
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //��ȡ�����Ĭ��ģ��
                                    {

                                        // Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        //��ʾ���а�ť (����Ա�) 
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        //    App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;
                                        SetTextButtonFase(text);
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs                                       
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);


                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc.PreserveWhitespace = true;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (content.Contains("emrtextdoc"))
                                        {
                                            tempxmldoc.LoadXml(content);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//ʱ�����������ʱ����
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tempxmldoc.LoadXml("<emrtextdoc/>");
                                            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";

                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//ʱ�����������ʱ����
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                    }
                                                    if (NowTree.SelectedNode.Text.Contains("�ճ����̼�¼") ||
                                                        NowTree.SelectedNode.Text.Contains("ҽ����ͨ��¼"))
                                                    {
                                                        text.MyDoc.HidleNameTitle = true;
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }

                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        //����֪��ͬ�����м��Ĭ��6
                                        if (cText.Id == 1601)
                                        {
                                            text.MyDoc.Info.LineSpacing = 6;
                                            text.MyDoc.Info.ParagraphSpacing = 6;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        text.MyDoc.HidleNameTitle = true;
                                        //if (advAllDoc.SelectedNode.Name == "1102") //͸��
                                        //{
                                        //    text.MyDoc._InsertMoreDiv(Record_Time + " " + Record_Content);
                                        //}                                      

                                    }
                                    else
                                    {
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        //Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        SetTextButtonFase(text);
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                                        text.MyDoc.SuporSign = suporSign; //�鷿�ϼ�ҽʦuserId

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;

                                        DataInit.SetToolEvent(text);
                                        // IniMainToobar();
                                        App.A_RefleshTreeBook = null;
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;

                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                        }
                                        if (NowTree.SelectedNode.Text.Contains("ҽ����ͨ��¼"))
                                        {
                                            text.MyDoc.HidleNameTitle = true;
                                        }
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                    }
                                }
                                else
                                {
                                    Record_Time = null;
                                    Record_Content = null;
                                    return;
                                }

                            }
                        }
                        else//��������
                        {
                            string temptid = isExitRecord(cText.Id, currentPatient.Id);
                            if (temptid != null && temptid != "")   //����Ѿ����ڣ������޸ġ�
                            {
                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    tid = Convert.ToInt32(temptid);
                                    //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true);
                                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                    string strbed_no = App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + inpatient.Id + "' and a.bed_id=c.bed_id and b.section_name=(select section_name from t_patients_doc where tid='" + temptid + "') and rownum=1 order by happen_time desc", 0, "bed_no");
                                    //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                    if (cText.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }
                                    if (strbed_no != null && strbed_no != "")
                                    {
                                        text.MyDoc.Bed_name = strbed_no;
                                    }
                                    //��ʾ���а�ť (����Ա�)
                                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                    //     App.UserAccount.CurrentSelectRole.Role_type == "N")
                                    //    text.MyDoc.EnableShowAll = false;
                                    //else
                                    SetTextButtonFase(text);
                                    text.MyDoc.EnableShowAll = true;
                                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                    text.MyDoc.IgnoreLine = NeglectLine;
                                    XmlDocument tmpxml = new System.Xml.XmlDocument();
                                    tmpxml.PreserveWhitespace = true;
                                    string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name from t_patients_doc where textkind_id=" + cText.Id + " and patient_id=" + inpatient.Id + "";
                                    DataTable dt = App.GetDataSet(sql).Tables[0];

                                    string content = "";
                                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                                    if (content == "" || content == null)
                                    {
                                        content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", inpatient.Id.ToString()); //dt.Rows[0]["patients_doc"].ToString();
                                    }

                                    string ishighersign = dt.Rows[0]["Ishighersign"].ToString();
                                    string havedoctorsign = dt.Rows[0]["Havedoctorsign"].ToString();
                                    string havehighersign = dt.Rows[0]["Havehighersign"].ToString();
                                    docflaag = dt.Rows[0]["submitted"].ToString();
                                    text.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                                    //����ʾ��ǰ���һ��ǲ��˵�ʱ����
                                    //if (OperateState != null && OperateState.Contains("��¼"))
                                    //{
                                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                                    //}
                                    //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                    text.MyDoc.TextSuperiorSignature = ishighersign;
                                    text.MyDoc.HaveTubebedSign = havedoctorsign;  //�ܴ�ҽ���Ƿ���ǩ
                                    text.MyDoc.HaveSuperiorSignature = havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                                    if (select_text.Ishavetime != "")
                                    {
                                        text.MyDoc.NeedTimeTitle = true;
                                    }

                                    if (select_text.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }

                                    tmpxml.LoadXml(content);
                                    if (NowTree.SelectedNode.Text.Contains("�ճ����̼�¼"))
                                    {
                                        text.MyDoc.HidleNameTitle = true;
                                    }
                                    DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                                    text.MyDoc.ContentChanged();
                                    tabctpnDoc.Controls.Add(text);
                                    text.Dock = DockStyle.Fill;

                                }
                            }
                            else
                            {

                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name,DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //��ȡ�����Ĭ��ģ��
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        //������Ȩ(ί��)�� 1603 �Զ���Ժͬ���� 1585 ����Ҫ�ܴ�ǩ��
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }
                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (cText.Id == 1603 || cText.Id == 1585)
                                        {
                                            text.MyDoc.HaveTubebedSign = "Y";
                                        }
                                        else
                                        {
                                            text.MyDoc.HaveTubebedSign = "N";//�ܴ�ҽ���Ƿ���ǩ
                                        }
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc.PreserveWhitespace = true;
                                        if (content.Contains("emrtextdoc"))
                                        {
                                            tempxmldoc.LoadXml(content);
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tempxmldoc.LoadXml("<emrtextdoc/>");
                                            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                            //tempxmldoc.SelectSingleNode("emrtextdoc/body").InnerXml = "";
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        text.MyDoc.NeedTimeTitle = true;
                                                        bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }
                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);

                                        //������Ȩ��ί�У����м��4
                                        if (cText.Id == 1603)
                                        {
                                            text.MyDoc.Info.LineSpacing = 4;
                                            text.MyDoc.Info.ParagraphSpacing = 4;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                    }
                                    else
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        //��ʾ���а�ť (����Ա�)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //������飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                        text.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                                        //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                                        DataInit.SetToolEvent(text);
                                        //IniMainToobar();
                                        App.A_RefleshTreeBook = null;
                                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                        }
                                        XmlDocument tempxmldoc = new XmlDocument();
                                        tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                    }
                                }
                            }
                        }



                        int patient_Id = currentPatient.Id;
                        //��¼������־
                        //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);

                        tabctpnDoc.TabItem = page;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        //if (docflaag == "Y" || NowTree.SelectedNode.Text == "סԺ������ҳ" || NowTree.SelectedNode.Text == "���߻�����Ϣ")
                        //{
                        //    App.SetToolButtonByUser("tsbtnTempSave", false);
                        //}
                        //else
                        //{
                        //    App.SetToolButtonByUser("tsbtnTempSave", true);
                        //}
                    }
                    else
                    {
                        App.Msg("�˲��˴����쳣��");
                    }
                }

            }
            else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {

                Class_Text cText = NowTree.SelectedNode.Parent.Tag as Class_Text;
                barTemplate.AutoHide = true;
                //�����������
                string textTitle = GetTextTitle(NowTree.SelectedNode);
                //�Ƿ���Ժ��Կ���
                bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                page.Tag = currentPatient as object;
                Record_Time = NowTree.SelectedNode.Text;
                InPatientInfo inpatient = page.Tag as InPatientInfo;
                if (inpatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    //��δ�ύ����ͨ����浽arraylist
                    //save_TextId.Add(advAllDoc.SelectedNode.Name);

                    Patient_Doc pdoc = NowTree.SelectedNode.Tag as Patient_Doc;
                    tid = pdoc.Id;

                    frmText text;
                    if (cText.Id == 103)
                    {
                        text = new frmText(pdoc.Textkind_id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                    }
                    else
                    {
                        text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                    }

                    //������д���飬�ݴ�֮�����ύǩ���޷��Զ���������⣨�����������Ѿ������Զ�ǩ����
                    if (cText.Isneedsign == "Y")
                    {
                        text.MyDoc.AutoGraph = true;
                    }
                    if (textTitle.Contains("����Ѫ�Ǽ���¼��") || textTitle.Contains("����(������)�����¼��") ||
                        textTitle.Contains("��������Ƥ�����ع۲��") || textTitle.Contains("�����ص�ע�۲��¼��") ||
                        textTitle.Contains("PICC�����¼��"))
                    {
                        int nodeIndex = advFinishDoc.SelectedNode.Index;
                        text.MyDoc.PageStartIndex = nodeIndex;
                    }
                    //��ʾ���а�ť (����Ա�)
                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                    //                     App.UserAccount.CurrentSelectRole.Role_type == "N")
                    //    text.MyDoc.EnableShowAll = false;
                    //else
                    SetTextButtonFase(text);
                    text.MyDoc.EnableShowAll = true;

                    // text.MyDoc.Section_name = pdoc.Section_name;//������������ 
                    //if (pdoc.Createid == App.UserAccount.UserInfo.User_id)
                    //{
                    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //else
                    //{
                    text.MyDoc.Section_name = pdoc.Section_name;//������������ 
                                                                //}
                    text.MyDoc.Bed_name = pdoc.Bed;
                    //DataInit.strbed = pdoc.Bed;
                    //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //�ܴ�ҽ���Ƿ���ǩ
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //�鷿ҽ����userId
                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                    if (text.MyDoc.OwnerControl.ContextMenuStrip != null)
                    {
                        text.MyDoc.OwnerControl.ContextMenuStrip.Items[1].Visible = false;

                    }
                    text.MyDoc.IgnoreLine = NeglectLine;
                    //�������Ǳ����ҵ�����
                    string[] sections = cText.Sid.Split(',');
                    bool sectionflag = false;
                    for (int k = 0; k < sections.Length; k++)
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_Id == sections[k])
                        {
                            sectionflag = true;
                            break;
                        }
                    }

                    System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + pdoc.Id + "", 0, "CONTENT");

                    if (content == "" || content == null)
                    {
                        content = App.DownLoadFtpPatientDoc(pdoc.Id + ".xml", inpatient.Id.ToString());
                    }

                    tmpxml.LoadXml(content);
                    DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();
                    tabctpnDoc.Controls.Add(text);
                    text.Dock = DockStyle.Fill;
                    DataInit.SetToolEvent(text);

                    //IniMainToobar();
                    App.A_RefleshTreeBook = null;
                    App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                    tabctpnDoc.TabItem = page;
                    page.Tooltip = docflaag;
                    tabctpnDoc.Dock = DockStyle.Fill;
                    page.AttachedControl = tabctpnDoc;
                    this.tctlDoc.Controls.Add(tabctpnDoc);
                    this.tctlDoc.Tabs.Add(page);
                    this.tctlDoc.Refresh();
                    this.tctlDoc.SelectedTab = page;
                    string log_Tid = NowTree.SelectedNode.Name;
                    int patient_Id = currentPatient.Id;
                    //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);
                    //��������
                    if (!sectionflag)
                    {
                        // text.MyDoc.Locked = true;
                    }
                }
            }

            //if (docflaag == "Y")
            //{
            //App.SetToolButtonByUser("tsbtnTempSave", false);
            //App.SetToolButtonByUser("tsbtnTemplateSave", false);

            //}
            //else
            //{
            //    App.SetToolButtonByUser("ttsbtnPrint", false);
            //}
            App.AddCurrentDocMsg(currentPatient.Id.ToString() + page.Text);
        }


        /// <summary>
        /// ��ǰ���˶�Ӧ��������TID
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        private string getTidByTextid(string text_id)
        {
            try
            {
                string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121";
                string sql = "select * from t_patients_doc where patient_id=" + currentPatient.Id + "";
                if (text_id == "125")
                {
                    sql += "  and textkind_id in (" + textlist + ")";
                }
                else
                {
                    sql += "  and textkind_id=125 ";
                }
                return App.ReadSqlVal(sql, 0, "tid");
            }
            catch
            { return ""; }
        }

        /// <summary>
        /// ��ǰ���˵�ǰ�����Ƿ���ڶ�ӦҪ��ȡ���ݵ�����
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        private bool Text_id_haveDoc(string text_id)
        {
            bool flag = false;
            try
            {
                string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121";
                string sql = "select * from t_patients_doc where patient_id=" + currentPatient.Id + "";
                if (text_id == "125")
                {
                    sql += "  and textkind_id in (" + textlist + ")";
                }
                else if (textlist.Contains(text_id))
                {
                    sql += "  and textkind_id=125 ";
                }
                else
                {
                    return flag;
                }
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }

            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// �Ƿ���Ҫ���Ƶ�����
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        private bool isCloneContent(string sc, string text_id)
        {
            bool flag = false;
            string[] source_s = "����,�ֲ�ʷ".Split(',');
            sc = sc.Replace(":", " ").Replace("��", " ").Trim();
            for (int i = 0; i < source_s.Length; i++)
            {
                if (!string.IsNullOrEmpty(sc) && sc == source_s[i])
                {
                    return true;
                }
            }
            if (text_id == "125")
            {
                if (sc == "�������")
                    flag = true;
            }
            string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121";
            if (textlist.Contains(text_id))
            {
                //���ＰԺ����Ҫ�����(������飩��
                if (sc.Contains("���ＰԺ����Ҫ�����") && sc.Contains("�������"))
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// סԺ־ͬ�����׳�
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sc"></param>
        /// <returns></returns>
        private string xmlContent(XmlDocument xml, string sc)
        {
            try
            {
                string content = "";
                sc = sc.Replace(":", " ").Replace("��", " ").Trim();
                XmlNode bodynode = xml.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");//input
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["title"] != null)
                    {
                        string xnname = xn.Attributes["title"].Value.ToString().Trim();
                        xnname = xnname.Replace(":", " ").Replace("��", " ").Trim();
                        if (sc != "�������")
                        {
                            if (!string.IsNullOrEmpty(sc) && sc == xnname)
                            {
                                if (!String.IsNullOrEmpty(xn.InnerText))
                                {
                                    content = xn.InnerXml;// xmlFilter(xn);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (xnname.Contains("���ＰԺ����Ҫ�����"))
                            {
                                if (!String.IsNullOrEmpty(xn.InnerText))
                                {
                                    content = xn.InnerXml;// xmlFilter(xn);
                                    break;
                                }
                            }
                        }
                    }
                }
                return content;
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// �׳�ͬ����סԺ־
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sc"></param>
        /// <returns></returns>
        private string docContent(XmlDocument xml, string sc)
        {
            try
            {
                string content = "";
                sc = sc.Replace(":", " ").Replace("��", " ").Trim();
                XmlNode bodynode = xml.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");//input
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["title"] != null)
                    {
                        string xnname = xn.Attributes["title"].Value.ToString().Trim();
                        xnname = xnname.Replace(":", " ").Replace("��", " ").Trim();

                        if (sc.Contains("�������") && sc.Contains("���ＰԺ����Ҫ�����"))
                        {
                            if (xnname.Contains("�������"))
                            {
                                if (!String.IsNullOrEmpty(xn.InnerText))
                                {
                                    content = xn.InnerXml;// xmlFilter(xn);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(sc) && sc == xnname)
                            {
                                if (!String.IsNullOrEmpty(xn.InnerText))
                                {
                                    content = xn.InnerXml;// xmlFilter(xn);
                                    break;
                                }
                            }
                        }
                    }
                }
                return content;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// ���˵�xml�ڵ��Ѿ�ɾ��������
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        private string xmlFilter(XmlNode xn)
        {
            try
            {
                if (!xn.InnerXml.Contains("deleter"))
                {
                    return xn.InnerText;
                }
                else
                {
                    string s = "";
                    XmlNodeList span = xn.SelectNodes("span");
                    foreach (XmlNode xnl in span)
                    {
                        //if (xnl.Attributes["deleter"] != null)
                        //{

                        //}
                        //else
                        //{
                        s += xnl.InnerText;
                        //}
                    }
                    XmlNodeList input = xn.SelectNodes("input");
                    foreach (XmlNode xn2 in input)
                    {
                        //if (xn2.Attributes["deleter"] != null)
                        //{

                        //}
                        //else
                        //{
                        s += xn2.InnerText;
                        //}
                    }
                    return s;
                }
            }
            catch
            {
                return xn.InnerText;
            }
        }






        /// <summary>
        /// ��סԺ��־����Ĳ������ݺ��׳�ͬ��
        /// </summary>
        /// <param name="text_id"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string DocFromXmlBytText(string text_id, string content)
        {
            try
            {
                if (!Text_id_haveDoc(text_id))
                {
                    return content;
                }
                if (string.IsNullOrEmpty(content))
                    return content;
                else
                {
                    //Դ����
                    string text_tid = getTidByTextid(text_id);

                    XmlDocument tmpxml_source = new XmlDocument();
                    tmpxml_source.PreserveWhitespace = true;
                    string content_source = "";
                    content_source = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + text_tid + "", 0, "CONTENT");
                    if (content_source == "" || content_source == null)
                    {
                        content_source = App.DownLoadFtpPatientDoc(text_tid + ".xml", currentPatient.Id.ToString());
                    }
                    tmpxml_source.LoadXml(content_source);

                    //��ǰ����  ��ȡ���ݣ� ���� �ֲ�ʷ ����ʷ
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    if (content.Contains("emrtextdoc"))
                    {
                        tempxmldoc.LoadXml(content);
                        XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                        XmlNode bodynode = tempxmldoc.ChildNodes[0].SelectSingleNode("body");
                        XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");
                        foreach (XmlNode xn in list)
                        {
                            if (xn.Attributes["title"] != null)
                            {
                                string xnname = xn.Attributes["title"].Value.ToString().Trim();
                                if (!string.IsNullOrEmpty(xnname) && isCloneContent(xnname, text_id))
                                {
                                    if (text_id == "125")
                                    {
                                        if (!string.IsNullOrEmpty(xmlContent(tmpxml_source, xnname)))
                                        {
                                            xn.InnerXml = xmlContent(tmpxml_source, xnname);//InnerText
                                        }
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(docContent(tmpxml_source, xnname)))
                                        {
                                            xn.InnerXml = docContent(tmpxml_source, xnname);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        tempxmldoc.LoadXml("<emrtextdoc/>");
                        XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
                        XmlNode bodynode = tempxmldoc.ChildNodes[0].SelectSingleNode("body");
                        XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");
                        foreach (XmlNode xn in list)
                        {
                            if (xn.Attributes["title"] != null)
                            {
                                string xnname = xn.Attributes["title"].Value.ToString().Trim();
                                if (!string.IsNullOrEmpty(xnname) && isCloneContent(xnname, text_id))
                                {
                                    if (text_id == "125")
                                    {
                                        //InnerXml��ȡ�ṹ  InnerText��ȡ����
                                        if (!string.IsNullOrEmpty(xmlContent(tmpxml_source, xnname)))
                                        {
                                            xn.InnerXml = xmlContent(tmpxml_source, xnname);
                                        }
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(docContent(tmpxml_source, xnname)))
                                        {
                                            xn.InnerXml = docContent(tmpxml_source, xnname);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    content = tempxmldoc.InnerXml;
                }

                return content;
            }
            catch
            {
                return content;
            }
        }



        /// <summary>
        /// ���µ����� ���� ���� Ѫѹ ��Ϣ�Զ���ȡ
        /// </summary>
        /// <param name="content"></param>
        private string PTRHInsert(string content, string text_id)
        {
            if (string.IsNullOrEmpty(content))
                return content;
            //�׳�+סԺ־
            string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121,125";
            if (!textlist.Contains(text_id))
                return content;
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            if (content.Contains("emrtextdoc"))
            {
                tempxmldoc.LoadXml(content);
            }
            else
            {
                tempxmldoc.LoadXml("<emrtextdoc/>");
            }
            XmlNodeList list = tempxmldoc.GetElementsByTagName("input");

            //����
            string temperature = App.ReadSqlVal("select temperature_value from t_vital_signs where patient_id=" + currentPatient.Id + " and temperature_value is not null order by measure_time ", 0, "temperature_value");
            //����
            string pulse = App.ReadSqlVal("select pulse_value from t_vital_signs where patient_id=" + currentPatient.Id + " and pulse_value is not null order by measure_time ", 0, "pulse_value");
            //����
            string breath = App.ReadSqlVal("select breath_value from t_vital_signs where patient_id=" + currentPatient.Id + " and breath_value is not null order by measure_time ", 0, "breath_value");
            //Ѫѹ
            string blood = App.ReadSqlVal("select bp_blood from t_temperature_info where patient_id=" + currentPatient.Id + " and bp_blood is not null and bp_blood like '%/%' order by record_time ", 0, "bp_blood");
            string[] us_blood = { "", "" };
            if (!string.IsNullOrEmpty(blood))
            {
                if (blood.Contains(","))
                {
                    string[] bloods = blood.Split(',');
                    if (bloods[0].Contains("/"))
                        blood = bloods[0];
                    else
                        blood = bloods[1];
                }
                us_blood = blood.Split('/');
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Attributes["name"] != null)
                {
                    if ((list[i].InnerText == ""))
                    {
                        switch (list[i].Attributes["name"].Value.ToString().Trim())
                        {
                            case "����":
                                if (!string.IsNullOrEmpty(temperature))
                                    list[i].InnerText = temperature;
                                break;
                            case "����":
                                if (!string.IsNullOrEmpty(pulse))
                                    list[i].InnerText = pulse;
                                break;
                            case "����":
                                if (!string.IsNullOrEmpty(breath))
                                    list[i].InnerText = breath;
                                break;
                            case "Ѫѹ_1":
                                if (!string.IsNullOrEmpty(us_blood[0]))
                                    list[i].InnerText = us_blood[0];
                                break;
                            case "Ѫѹ_2":
                                if (!string.IsNullOrEmpty(us_blood[1]))
                                    list[i].InnerText = us_blood[1];
                                break;

                        }
                    }
                }
            }
            return content;
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="node">��ǰ������ѡ�еĽڵ�</param>
        /// <param name="tctldoc">tabcontrol</param>
        /// <param name="currentPatient">��ǰ����</param>
        private bool create_Nurse_Book(Node node, DevComponents.DotNetBar.TabControl tctlDoc, InPatientInfo currentPatient)
        {
            bool isExcute = true;
            barTemplate.Hide();
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();

            page.Click += new EventHandler(page_Click);

            page.Name = node.Name;
            page.Text = node.Text + " " + " (" + currentPatient.Sick_Bed_Name + " ��)";
            page.Tag = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString()) as object;
            //InPatientInfo inpatient = currentPatient;

            if (node.Tag != null)
            {
                //Class_Text ctext = (Class_Text)node.Tag;
                Class_Text ctext = node.Tag as Class_Text;
                if (ctext == null || ctext.Isenable == "0")
                {
                    isExcute = false;
                }
                else if (node.Tag.ToString().Contains("Class_Text"))
                {

                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //Ѫ�Ǽ�ⵥ
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnDoc.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //����ͼ
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();
                        

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * ��ʿ����
                             */
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * ҽ��վ
                                              */
                            //ucBirthPic.OnlyLook = true;
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        int Section_Id = 0;//����id
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != null &&
                            App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                            Section_Id = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);

                        string Role_type = App.UserAccount.CurrentSelectRole.Role_type;//�û�����
                        if ((Role_type != "N" && Role_type != "D") || currentPatient.PatientState == "����" || (OperateState != null && OperateState.Contains("�鿴") && !OperateState.Contains("��¼")))
                        {
                            Section_Id = Convert.ToInt32(inpatient.Section_Id);
                        }
                        MUcToolsControl ucNurseRecord;
                        if (node.Text.Contains("������"))
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name), true);
                        else
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name));

                        ucNurseRecord.MyDocument.OnSaveChanged += OnSaveChanged;
                        //��ʿ����
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);

                        //����Ƿ�����
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        //bool islock = GetLockState(inpatient.Id, out open_num, out open_name,out ip);

                        if (Role_type != "N" || (OperateState != null && !OperateState.Contains("����") && !OperateState.Contains("�޸�") && !OperateState.Contains("��¼")))
                        {// || islock
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);//�����Ǹ��˵�
                            //Panel bp = ucNurseRecord.GetButtonPanel();
                            //foreach (Control c in bp.Controls)
                            //{//�����ؼ�,��������
                            //    if (c is Button)
                            //    {
                            //        Button b = (Button)c;
                            //        if ((b.Text == "��ӡ" || b.Text == "����") && currentPatient.PatientState != "����")
                            //        {
                            //            b.Visible = true;
                            //            b.Enabled = true;
                            //        }
                            //    }
                            //}
                            //ucNurseRecord.MyDocument.ClearContent();//��ս���
                            page.Text += " ��� ";

                            //if (islock && Role_type == "N")
                            //{
                            //    string strText = "���������ţ�" + open_num + " ������" + open_name + "��";
                            //    page.Text += strText;
                            //    App.Msg("��ʾ:�����û����ڱ༭���ò��˻����¼���ѱ�������\n�����˹��ţ�" + open_num + "\n������������" + open_name);
                            //}
                        }
                        //else//û����֮ǰ
                        //{
                        //    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //}
                        tabctpnDoc.AutoScroll = true;
                        isCustom = true;

                        #region MyRegion
                        //string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        //if (string.IsNullOrEmpty(section_id_test))
                        //{
                        //    if (inpatient != null)
                        //    {
                        //        section_id_test = inpatient.Sike_Area_Id.ToString();
                        //    }
                        //    else
                        //    {
                        //        section_id_test = "0";
                        //    }
                        //}
                        ////MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        //MUcToolsControl ucNurseRecord = null;
                        //if (currentPatient.Section_Name.Contains("����") || currentPatient.Section_Name.Contains("���ڶ�"))
                        //{
                        //    ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                        //    ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        //}
                        //else
                        //{
                        //    ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                        //    ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'";
                        //}
                        
                        ///*
                        // * ��ʿ����
                        // */
                        //tabctpnDoc.Controls.Add(ucNurseRecord);
                        //ucNurseRecord.Dock = DockStyle.Fill;
                        //App.UsControlStyle(ucNurseRecord);
                        //string open_num = "";
                        //string open_name = "";
                        //string ip = "";
                        //bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        //if (App.UserAccount.CurrentSelectRole.Role_type != "N" || islock)//|| islock
                        //{
                        //    ucNurseRecord.MyDocument.ClearTempInput();
                        //    ucNurseRecord.SetToolsEnable(false);
                        //    if (islock)
                        //    {
                        //        page.Text += "����" + "���ţ�" + open_num + "������" + open_name + "�Ѿ���";
                        //        App.MsgWaring("�÷ݻ����¼��������ʦ�򿪣�ͬһ������ͬʱֻ�ܵ����û�������");
                        //    }
                        //}
                        //tabctpnDoc.AutoScroll = true;
                        //isCustom = true;
                        //if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//û����֮ǰ
                        //{
                        //    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //} 
                        #endregion

                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //���µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //���������µ�
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper_bb.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper_bb);
                            App.UsControlStyle(temper_bb);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint_bb = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            
                            uctemperPrint_bb.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint_bb);
                            App.UsControlStyle(uctemperPrint_bb);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        //���¹�ȥ������Ϣ
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnDoc.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xpû����load�¼�
                            ucCase_First.InitPatientInfo();
                            // ��ȡ������Ϣ
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region ������Ϣ�ı�������
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // ��ȡ�����Ϣ
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region ��Ҫ��ϱ�����д��Ժ�����ת�����
                            dr = Diagnose.Rows[0];
                            #endregion


                            // ��ȡ������Ϣ
                            DataTable Operation = ucCase_First.GetOperation();

                            // ��ȡ����������Ϣ
                            DataTable Quality = ucCase_First.GetQuality();

                            // ��ȡ������ҳ��һЩ����
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region �����ı��������
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // ���� DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnDoc.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnDoc.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//���֤����
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//�ĵ�ʾ����¼��
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//���������������󲡳̼�¼881
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        isExcute = false;
                        App.Msg("��������û��ȷ����Ӧ�Ĺ���ģ��,���ڹ���Ա��ϵ,���������͹����н������ã�");

                    }
                }
                else
                {
                    isExcute = false;
                }
            }
            if (isExcute)
            {
                tabctpnDoc.TabItem = page;
                tabctpnDoc.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnDoc;
                tctlDoc.Controls.Add(tabctpnDoc);
                tctlDoc.Tabs.Add(page);
                tctlDoc.Refresh();
                tctlDoc.SelectedTab = page;
            }
            return isExcute;
        }

        void page_Disposed(object sender, EventArgs e)
        {
            //TabPage item = sender as TabPage;
            //if (!item.Text.Contains("����"))
            //{
            //    IsLockBook("t_care_doc", currentPatient.Id, "0");
            //}
        }


        /// <summary>
        /// 1.����������¼�
        /// 2.���ı���������ѡ����ʱ����
        /// 3.���ƽڵ���Ҽ��˵���ʾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            NowTree = sender as AdvTree;
            if (NowTree != null && NowTree.SelectedNode != null)
            {
                string account_Type = App.UserAccount.CurrentSelectRole.Role_type;

                this.�����β鷿ToolStripMenuItem.Visible = false;
                this.�����β鷿ToolStripMenuItem.Visible = false;
                this.ȡ�����ϼ��鷿ToolStripMenuItem.Visible = false;
                if (account_Type == "D")
                {
                    NowTree.ContextMenuStrip = this.ctmnspDelete;
                    if (NowTree.SelectedNode.Name == "663" ||              //����۲쵥
                       NowTree.SelectedNode.Name == "561" ||            //Ѫ�Ǽ�ⵥ
                       NowTree.SelectedNode.Name == "170" ||            //�����¼��
                       NowTree.SelectedNode.Name == "172" ||            //���µ���¼
                       NowTree.SelectedNode.Name == "173"            //����Һ����¼��
                      )           //����Һ����¼��
                    {
                        this.ɾ��ToolStripMenuItem.Visible = false;
                        this.tlspmnitBrowse.Visible = true;  //���
                        //this.�޸ı���ToolStripMenuItem.Visible = false;
                    }



                    if (NowTree.SelectedNode.Tag != null)
                    {
                        if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                        {
                            this.ɾ��ToolStripMenuItem.Visible = true;
                            this.tlspmnitBrowse.Visible = true;  //���
                            //this.�޸ı���ToolStripMenuItem.Visible = true;
                            Patient_Doc patient_Doc = NowTree.SelectedNode.Tag as Patient_Doc;
                            if (patient_Doc.Textname == "��Ժ����������¼��" ||
                                patient_Doc.Textname == "�š����Ʋ��˽�����¼��" ||
                                patient_Doc.Textname == "����ճ����" ||
                                patient_Doc.Textname == "��������ά���۲��¼��" ||
                                patient_Doc.Textname == "����۲��¼��" ||
                                patient_Doc.Textname == "�������˽�����¼��")
                            {
                                this.ɾ��ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //���
                            }
                            else if (NowTree.SelectedNode.Parent.Name == "126")
                            {
                                this.ȡ�����ϼ��鷿ToolStripMenuItem.Visible = true;
                                this.�����β鷿ToolStripMenuItem.Visible = true;
                                this.�����β鷿ToolStripMenuItem.Visible = true;
                                if (patient_Doc.Isreplacehighdoctor == "Y" || patient_Doc.Isreplacehighdoctor2 == "Y")
                                {
                                    this.ȡ�����ϼ��鷿ToolStripMenuItem.Enabled = true;
                                    this.�����β鷿ToolStripMenuItem.Enabled = false;
                                    this.�����β鷿ToolStripMenuItem.Enabled = false;
                                }
                                else
                                {
                                    this.ȡ�����ϼ��鷿ToolStripMenuItem.Enabled = false;
                                    this.�����β鷿ToolStripMenuItem.Enabled = true;
                                    this.�����β鷿ToolStripMenuItem.Enabled = true;
                                }

                            }

                        }
                        else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                        {
                            if (NowTree.SelectedNode.Nodes.Count == 0 ||
                                NowTree.SelectedNode.Nodes[0].Tag.GetType().
                                ToString().Contains("Patient_Doc"))
                            {

                                Class_Text text = NowTree.SelectedNode.Tag as Class_Text;
                                if (text != null && text.Issimpleinstance == "0" &&
                                    //text.Textname != "ҽ����Լ" &&
                                    text.Textname != "סԺ���˻���ȫ��֪��")
                                {
                                    this.ɾ��ToolStripMenuItem.Visible = true;
                                }
                                else
                                {
                                    this.ɾ��ToolStripMenuItem.Visible = false;
                                }
                                //this.�޸ı���ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //���
                            }
                            else
                            {
                                this.ɾ��ToolStripMenuItem.Visible = false;
                                //this.�޸ı���ToolStripMenuItem.Visible = false;
                                if (NowTree.SelectedNode.Text == "���̼�¼")
                                {
                                    this.tlspmnitBrowse.Visible = true;  //���
                                }
                                else
                                {
                                    this.tlspmnitBrowse.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            this.ɾ��ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = false;  //���

                            //this.�޸ı���ToolStripMenuItem.Visible = false;
                        }
                    }
                }
                else
                {
                    if (NowTree.SelectedNode.Tag != null)
                    {
                        //172 ��663��1874��1875��1876��1877��1878��1879
                        if (NowTree.SelectedNode.Name == "663" ||              //����۲쵥
                           NowTree.SelectedNode.Name == "561" ||            //Ѫ�Ǽ�ⵥ
                           NowTree.SelectedNode.Name == "170" ||            //�����¼��
                           NowTree.SelectedNode.Name == "172" ||            //���µ���¼
                           NowTree.SelectedNode.Name == "173")
                        {
                            this.ɾ��ToolStripMenuItem.Visible = true;
                            //this.�޸ı���ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = true;  //���
                        }
                        else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                        {
                            Patient_Doc patient_Doc = NowTree.SelectedNode.Tag as Patient_Doc;
                            if (patient_Doc.Textname == "��Ժ����������¼��" ||
                                patient_Doc.Textname == "�š����Ʋ��˽�����¼��" ||
                                patient_Doc.Textname == "����ճ����" ||
                                patient_Doc.Textname == "��������ά���۲��¼��" ||
                                patient_Doc.Textname == "����۲��¼��" ||
                                patient_Doc.Textname == "�������˽�����¼��" ||
                                patient_Doc.Textname == "ҽ����Լ" ||
                                //Ӥ�������¼��
                                patient_Doc.Textname.Contains("Ӥ�������¼��") ||
                                patient_Doc.Textname == "סԺ���˻���ȫ��֪��")
                            {
                                this.ɾ��ToolStripMenuItem.Visible = true;
                                this.tlspmnitBrowse.Visible = true;  //���
                            }
                            else
                            {
                                this.ɾ��ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //���
                            }
                            //this.�޸ı���ToolStripMenuItem.Visible = false;

                        }
                        else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                        {
                            Class_Text text = NowTree.SelectedNode.Tag as Class_Text;
                            if (text.Textname == "ҽ����Լ" ||
                                text.Textname == "סԺ���˻���ȫ��֪��")
                            {
                                this.ɾ��ToolStripMenuItem.Visible = true;
                            }
                            else
                            {
                                this.ɾ��ToolStripMenuItem.Visible = false;
                            }
                            //this.�޸ı���ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = true;  //���
                        }
                        else
                        {
                            this.ɾ��ToolStripMenuItem.Visible = false;
                            if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                            {
                                if (NowTree.SelectedNode.Parent.Name == "1874" ||
                                NowTree.SelectedNode.Parent.Name == "1875" ||
                                NowTree.SelectedNode.Parent.Name == "1876" ||
                                NowTree.SelectedNode.Parent.Name == "1877" ||
                                NowTree.SelectedNode.Parent.Name == "1878" ||
                                NowTree.SelectedNode.Parent.Name == "1879")
                                {
                                    this.ɾ��ToolStripMenuItem.Visible = true;
                                    //this.�޸ı���ToolStripMenuItem.Visible = false;
                                    this.tlspmnitBrowse.Visible = true;  //���
                                }
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// ˢ�������������
        /// 1.������ڵ�
        /// 2.����סԺ���̼�¼�µ�������������
        /// 3.����д��������ص�����
        /// 4.�Ƴ�סԺ���̼�¼��û��д����Ľڵ�
        /// </summary>
        private void ReflashTrvBook()
        {
            advFinishDoc.Nodes.Clear();
            AddFinishNode();
            //RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//չ����������ڵ�

        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                advAllDoc_DoubleClick(NowTree, e);
            }
            else
            {
                App.Msg("��ѡ������ڵ㣡");
            }
        }

        private void advAllDoc_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            foolflag = false;
            NowTree = sender as AdvTree;
            if (NowTree != null && NowTree.SelectedNode != null)
            {
                if (NowTree.SelectedNode.Nodes.Count == 0)
                {
                    ���ToolStripMenuItem.Visible = true;
                }
                else
                {
                    ���ToolStripMenuItem.Visible = false;
                }

                if (NowTree.SelectedNode.Tag != null)
                {
                    if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                    {
                        Class_Text tempnode = (Class_Text)NowTree.SelectedNode.Tag;
                        if (tempnode.Isenable == "1")
                        {
                            //���ƽ���
                            ���ToolStripMenuItem.Visible = false;
                        }
                    }
                }
            }
            else
            {
                ���ToolStripMenuItem.Visible = false;
            }
        }

        private void c1OutBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dockContainerItem_FinishDoc.Selected) //"��д����")
            {
                NowTree = advFinishDoc;
            }
            else if (dockContainerItem_FinishDoc.Selected )//== "ȫ������")
            {
                NowTree = advAllDoc;
            }
        }

        private void ctmnspAdd_Opening(object sender, CancelEventArgs e)
        {
            if (NowTree != null)
            {
                advAllDoc_AfterNodeSelect(NowTree, null);
            }
        }

        private void tctlDoc_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (tctlDoc.Tabs.Count <= 0)
            {
                barTemplate.Hide();
            }
        }

        private void txtSearchAllText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                pictureBox2_Click(sender, e);
            }
        }

        private void txtSearchAllText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchAllText.Text.Trim() == "")
            {
                advAllDoc.Nodes.Clear();
                DataInit.ReflashBookTree(advAllDoc);
                advAllDoc.ExpandAll();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            advAllDoc.Nodes.Clear();
            if (txtSearchAllText.Text.Trim() != "")
            {
                DataInit.ReflashBookTree(advAllDoc, txtSearchAllText.Text);
            }
            else
            {
                DataInit.ReflashBookTree(advAllDoc);
                advAllDoc.ExpandAll();
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="textBox"></param>
        public void InitAutoCompleteCustomSource(TextBox textBox)
        {
            string[] array = null;
            DataSet ds = App.GetDataSet("select * from T_TEXT where enable_flag='Y' and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') and (sid='0' or instr(sid,'" + currentPatient.Section_Id.ToString() + "')>0) and id not in(select distinct parentid from t_text) and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc");
            if (ds != null)
            {
                array = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    array[i] = ds.Tables[0].Rows[i]["textname"].ToString();
                }
            }
            //array = ReadTxt();
            if (array != null && array.Length > 0)
            {
                AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();

                for (int i = 0; i < array.Length; i++)
                {
                    ACSC.Add(array[i]);
                }
                textBox.AutoCompleteCustomSource = ACSC;
            }
        }

        /// <summary>
        /// �ͻ����ʿ�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                //Process[] proceses = Process.GetProcessesByName("ClientServers");
                //if (proceses.Length == 0)
                //{
                //Process.Start("ClientServers.exe", currentPatient.Id.ToString());
                //}
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// ��������¼��������
        /// </summary>
        private void UnlockNurseRecord(string user_id)
        {
            string Update_Sql = "update t_care_doc set islock=0 where (open_user='" + user_id + "' or create_id='" + user_id + "') and islock=1";
            int count = App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// ͬһ������ֻ�ܵ����û�����
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="patient_id">����idֵ</param>
        /// <param name="lockState">�Ƿ�����0δ����1����</param>
        /// <param name="colname">����</param>
        /// <param name="tid">����id����</param>
        private void IsLockBook(string tablename, int patient_id, string lockState, string user_id)
        {
            string Update_Sql = "update " + tablename + " set islock='" + lockState
                            + "',OPEN_USER='" + user_id + "',ip='" + App.GetHostIp() + "' where inpatient_id='" + patient_id + "'";
            App.ExecuteSQL(Update_Sql);
        }

        /// <summary>
        /// ͬһ������ֻ�ܵ����û�����
        /// </summary>
        /// <param name="lockState">�Ƿ�����0δ����1����</param>
        public void IsLockBook(int patient_id, string lockState)
        {
            string Update_Sql = "update t_care_doc set islock='" + lockState
                            + "',OPEN_USER='" + App.UserAccount.UserInfo.User_id + "',ip='" + App.GetHostIp() + "' where inpatient_id='" + patient_id + "'";
            App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// ��ȡ��ǰ���˻����¼���Ƿ������ڲ���
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="patient_id"></param>
        /// <returns>1������������û������</returns>
        private bool GetLockState(int patient_id, out string use_open, out string open_name, out string ip)
        {
            string LockState = "";
            open_name = "";
            use_open = "";
            ip = "";
            string Select_Sql = "select a.islock,a.ip,b.user_num,b.user_name from t_care_doc a " +
                                " inner join t_userinfo b on a.open_user=b.user_id" +
                                " where inpatient_id='" + patient_id + "'";
            DataTable dt = App.GetDataSet(Select_Sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                open_name = dt.Rows[0]["user_name"].ToString();
                use_open = dt.Rows[0]["user_num"].ToString();                
                LockState = dt.Rows[0]["islock"].ToString();
                ip = dt.Rows[0]["ip"].ToString();
            }
            return LockState == "1" ? true : false;
        }

        private void ˢ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReflashTrvBook();
        }


        public void OnSaveChanged(string emrdoc)
        {
            ReflashTrvBook();
        }
        //public static void ReflashTool()
        //{
        //    ReflashTrvBook();
        //}
        ///// <summary>
        ///// ͬһ������ֻ�ܵ����û�����
        ///// </summary>
        ///// <param name="tablename">����</param>
        ///// <param name="patient_id">����idֵ</param>
        ///// <param name="lockState">�Ƿ�����0δ����1����</param>
        ///// <param name="colname">����</param>
        ///// <param name="tid">����id����</param>
        //private void IsLockBook(string tablename, int patient_id, string lockState, string colname, string tid)
        //{
        //    string Update_Sql = "update " + tablename + " set islock='" + lockState + "' where " + colname + "='" + patient_id + "' and tid='"+tid+"'";
        //    App.ExecuteSQL(Update_Sql);
        //}

        /// <summary>
        /// ˢ���Ѵ�����༭�������Ϣ
        /// </summary>
        /// <param name="Reftype">����״̬:1.δ�ύ����ˢ��;2.�����Ƿ��ύ��ˢ</param>
        private void RefreshTabDocDiagnose(int Reftype)
        {

            //ѡ��ҳǩˢ��
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0 && (App.UserAccount.CurrentSelectRole.Role_type == "D" || App.UserAccount.CurrentSelectRole.Role_type == "N" || App.UserAccount.CurrentSelectRole.Role_type == "B" || App.UserAccount.CurrentSelectRole.Role_type == "Y"))
                {
                    frmText text = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (text != null)
                    {
                        bool isSubmitt = DataInit.IsDocSubmitted(text.MyDoc.Us.Tid);
                        if (Reftype == 2 || !isSubmitt)
                        {//��ȡ�����Ƿ��ύ״̬
                            if (Reftype == 2)//��¼�����Ϣ
                                LogHelper.SystemLog("ˢ�����", text.MyDoc.Us.Tid.ToString(), text.MyDoc.Us.InpatientInfo.PId.ToString(), text.MyDoc.Us.InpatientInfo.Id);
                            DataInit.RefreshDocDiagnose(text, Reftype);
                        }
                       // DataInit.RefreshDocDiagnose(text, Reftype);
                    }
                }
            }

        }


        /// <summary>
        /// δ������鱸�ݻ�ԭ
        /// </summary>
        private void CreatBakTabItem()
        {
            try
            {

                var files = Directory.GetFiles(App.SysPath + "\\DocTemp\\" + this.currentPatient.Id.ToString(), "*.xml");
                if (files.Length > 0)
                {
                    if (App.Ask("�ϴβ�����δ��������Ĳ������Ƿ�ָ���"))
                    {

                        string SQl = "select * from T_TEXT where enable_flag='Y' and right_range in ('" +
                                     App.UserAccount.CurrentSelectRole.Role_type + "','A') and (sid='0' or instr(sid,'" +
                                     currentPatient.Section_Id.ToString() + ",')=1 or instr(sid,'," +
                                     currentPatient.Section_Id.ToString() + ",')>0) order by shownum asc";

                        DataSet ds = new DataSet();
                        ds = App.GetDataSet(SQl);
                        Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);
                        Class_Text CurrentText = null;
                        XmlDocument xmltempdoc = new XmlDocument();

                        string filename = "";
                        foreach (var file in files)
                        {
                            xmltempdoc.Load(file);
                            filename = Path.GetFileName(file); //��ȡ����

                            string strfile = filename.Split('.')[0];

                            strfile = Encrypt.DecryptStr(strfile);
                            string tid = strfile.Split('_')[0];
                            string textid = strfile.Split('_')[1];
                            string texttitle = strfile.Split('_')[2];
                            string record_time = strfile.Split('_')[3];
                            string record_content = strfile.Split('_')[4];
                            bool ismore = false; //strfile.Split('_')[4];
                            if (strfile.Split('_')[5] == "1")
                            {
                                ismore = true;
                            }

                            /*
                             * ��ȡ�������                            
                             */
                            foreach (Class_Text temptext in Directionarys)
                            {
                                if (temptext.Id.ToString() == textid)
                                {
                                    CurrentText = temptext;
                                    break;
                                }
                            }

                            if (CurrentText != null)
                            {
                                if (CurrentText.Other_textname != "")
                                {
                                    texttitle = CurrentText.Other_textname;
                                }
                            }

                            frmText txtfc = new frmText(Convert.ToInt32(textid), 0, 0, texttitle, Convert.ToInt32(tid), currentPatient, true, ismore, record_time, record_content);
                            txtfc.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                            txtfc.MyDoc.FromXML(xmltempdoc.DocumentElement);

                            if (tid == "0")
                            {
                                txtfc.MyDoc.TextSuperiorSignature = CurrentText.Ishighersign;
                                txtfc.MyDoc.HaveTubebedSign = "N";  //�ܴ�ҽ���Ƿ���ǩ
                                txtfc.MyDoc.HaveSuperiorSignature = "N";//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��                              
                            }

                            if (CurrentText.Ishavetime != "")
                            {
                                txtfc.MyDoc.NeedTimeTitle = true;
                            }

                            if (CurrentText.Isneedsign == "Y")
                            {
                                txtfc.MyDoc.AutoGraph = true;
                            }

                            if (CurrentText.Id == 1603 || CurrentText.Id == 1585)
                            {
                                txtfc.MyDoc.HaveTubebedSign = "Y";
                            }
                            else
                            {
                                txtfc.MyDoc.HaveTubebedSign = "N";//�ܴ�ҽ���Ƿ���ǩ
                            }

                            txtfc.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                            //Ԭ�����2015-7-14
                            txtfc.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;


                            //this.currentPatient;
                            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                            tabctpnDoc.AutoScroll = true;
                            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
                            page.Click += new EventHandler(page_Click);
                            page.Text = "�ָ�" + "_" + tid + "_" + texttitle + " " + " (" + currentPatient.Sick_Bed_Name + " ��)";
                            page.Tag = currentPatient;
                            tabctpnDoc.TabItem = page;
                            tabctpnDoc.Dock = DockStyle.Fill;

                            txtfc.Dock = DockStyle.Fill;
                            //text.MyDoc.HidleNameTitle = false;

                            tabctpnDoc.Controls.Add(txtfc);

                            page.AttachedControl = tabctpnDoc;
                            this.tctlDoc.Controls.Add(tabctpnDoc);
                            this.tctlDoc.Tabs.Add(page);
                            this.tctlDoc.Refresh();
                            this.tctlDoc.SelectedTab = page;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void ucDoctorOperater_Load(object sender, EventArgs e)
        {
            CreatBakTabItem();
        }

        /// <summary>
        /// ����������ȡ�ڵ�
        /// </summary>
        private void GetSelectCurrentNodeBySound(string nodename,NodeCollection nodes,AdvTree trvdoc)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
               
                if (nodes[i].Nodes.Count > 0)
                {
                    GetSelectCurrentNodeBySound(nodename, nodes[i].Nodes, trvdoc);
                }
                else
                {
                    if (nodes[i].Text.Contains(nodename))
                    {
                        if (nodes[i].Parent != null)
                            nodes[i].Parent.ExpandAll();
                        trvdoc.SelectedNode = nodes[i];
                        return;
                    }
                }
            }
        }

        bool foolflag = false;


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string TextBuffer = App.readText();
                if (TextBuffer != "")
                {
                    if (!foolflag)
                    {
                        if (TextBuffer .Contains( "��д����"))
                        {
                            dockContainerItem_FinishDoc.Selected = true;
                        }
                        else if (TextBuffer. Contains( "ȫ������"))
                        {
                            dockContainerItem_AllDoc.Selected = true;
                        }
                        else
                        {
                            if (dockContainerItem_AllDoc.Selected)
                            {
                                GetSelectCurrentNodeBySound(TextBuffer, advAllDoc.Nodes, advAllDoc);
                                if (TextBuffer .Contains( "����"))
                                {
                                    CreateTabItem(0, true);
                                    TextBuffer = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        DataInit.CurrentFrmText.MyDoc._InsertString(TextBuffer);

                    }
                }
            }
            catch
            { }
        }

        private void picSpeech_Click(object sender, EventArgs e)
        {
            if (this.picSpeech.Image.Flags == global::Base_Function.Resource.speech.Flags)
            {                
                App.StartRecording();
                this.picSpeech.Image = global::Base_Function.Resource.speech_stop;
                timer1.Start();
            }
            else if (this.picSpeech.Image.Flags == global::Base_Function.Resource.speech_stop.Flags)
            {
                //App.StopRecording();
                this.picSpeech.Image = global::Base_Function.Resource.speech;
                timer1.Stop();
            }
        }
    }
}
