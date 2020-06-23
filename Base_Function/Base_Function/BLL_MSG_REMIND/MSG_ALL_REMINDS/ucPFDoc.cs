using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using DevComponents.AdvTree;
using Bifrost;
using TextEditor;
using Base_Function.BLL_NURSE.NBlood_sugarRecord;
//using Base_Function.BLL_MANAGEMENT.QuerySick;
using Bifrost_Nurse.UControl;
//using Bifrost_Hospital_Management.Nereuse_record;
//using Bifrost_Hospital_Management.Nurse_observes;
//using Base_Function.BLL_MANAGEMENT.Nurse_Record_Manager.UcControls;
using Base_Function.BLL_NURSE.First_cases;
using Base_Function.BLL_NURSE.SickInformational;
//using Base_Function.BLL_NURSE.Patient_message;
using Base_Function.BLL_NURSE.Odinopoeia_Record;
using Base_Function.BLL_NURSE.Expectant_Record;
using System.Xml;
using System.Collections;
using DevComponents.DotNetBar;
//using Bifrost_T_Management;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
//using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Net;
using Base_Function.BASE_COMMON;
//using Bifrost.Media;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class ucPFDoc : UserControl
    {
        //�������е���������
        private AdvTree temptrvbook = new AdvTree();
        /// <summary>
        /// ��ǰ���˶��� 
        /// </summary>
        public InPatientInfo currentPatient;
        private string Record_Time = null;
        private string Record_Content = null;
        private static Node CurrentNode = new Node();

        //���ַ��ر༭������
        public delegate void ComeFrmText(frmText frm);
        public ComeFrmText OnComeFrmText;

        /// <summary>
        /// �Ƿ��Ƕ��Ƶ�����
        /// </summary>
        private bool isCustom = false;

        /// <summary>
        /// ����ʱ��ѡ����ķ���ֵ�����ȷ������True�����ȡ������false
        /// </summary>
        public static bool isFlagtrue = false;

        public delegate void DeleGetRecord(string time, string content);

        /// <summary>
        /// �����ύ��������id
        /// </summary>
        private ArrayList save_TextId = new ArrayList();

        /// <summary>
        /// ���󲡳̼�¼�Ƿ����ӽڵ�
        /// </summary>
        bool isChildNode = false;

        /// <summary>
        /// ���°󶨰�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PageSelectChange(object sender, TabStripTabChangedEventArgs e)
        {
            tctlDoc_SelectedTabChanged(sender, e);
        }


        public ucPFDoc()
        {
            InitializeComponent();
        }

        public ucPFDoc(InPatientInfo patientInfo)
        {
            InitializeComponent();
            currentPatient = patientInfo;
            //dockContainerItem1.Text = "�������";
            //dockContainerItem2.Text = "ģ����ȡ";
        }
        public ucPFDoc(InPatientInfo patientInfo,bool flag)
        {
            InitializeComponent();
            currentPatient = patientInfo;
            //dockContainerItem1.Text = "�������";
            //dockContainerItem2.Text = "ģ����ȡ";
            if (flag == false)
            {
                barPF.Visible = false;
            }
        }

        private void ucDoctorOperater_Load(object sender, EventArgs e)
        {
            DataInit.ReflashBookTree(temptrvbook);
            ReflashTrvBook();//ˢ��������
            BindSource();//�������б�         
            frmText text = new frmText();
            //Ԭ��2014-12-18 ע��
            //text.MyDoc.OnBackPfIdDoctor += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFIdDoctor(MyDoc_OnBackPfIdDoctor);
        }

        void MyDoc_OnBackPfIdDoctor(string id)
        {
            BindSource();
        }

      
       
        #region ��д�������

        /// <summary>
        /// ���סԺ���̼�¼
        /// </summary>
        public void AddZYNode(NodeCollection tempNode)
        {
            foreach (Node node in tempNode)
            {
                if (tempNode.Count > 0)
                {
                    AddZYNode(node.Nodes);
                }
                if (node.Text == "סԺ���̼�¼")
                {
                    advFinishDoc.Nodes.Add(node.DeepCopy());
                }
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public void AddFinishNode()
        {
            Node node = null;
            if (currentPatient != null)
            {
                node = DataInit.SelectDoc(currentPatient.Id);//�����д����
            }
            //ȡ�÷�סԺ���̼�¼���鸸�ڵ��ID��ƴ���ַ����Զ��Ÿ���
            string docStr = "";
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                Patient_Doc doc = node.Nodes[i].Tag as Patient_Doc;
                if (doc != null)// && doc.Textname != "���̼�¼")  
                {
                    if (docStr == "")
                    {
                        docStr = doc.Textkind_id.ToString();
                    }
                    else //if (!docStr.Contains(doc.Textkind_id.ToString()))
                    {
                        docStr += "," + doc.Textkind_id;
                    }
                }
            }
            if (docStr != "")
            {
                //������зǲ��̼�¼����д���鸸�ڵ�
                string SQl = "select * from T_TEXT where enable_flag='Y' and id in(" + docStr + ") order by shownum asc";
                DataSet ds = new DataSet();
                ds = App.GetDataSet(SQl);

                Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    if (Directionarys[i].Issimpleinstance == "1")
                    {
                        tn.ImageIndex = 18;
                    }
                    else
                    {
                        tn.ImageIndex = 17;
                    }
                    if (Directionarys[i].Parentid.ToString() == "103")
                    {
                        int count = 0;
                        for (int j = 0; j < advFinishDoc.Nodes.Count; j++)
                        {
                            if (advFinishDoc.Nodes[j].Text == "סԺ���̼�¼")
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            AddZYNode(temptrvbook.Nodes);
                        }
                        for (int j = 0; j < advFinishDoc.Nodes.Count; j++)
                        {
                            if (advFinishDoc.Nodes[j].Text == "סԺ���̼�¼")
                            {
                                advFinishDoc.Nodes[j].Nodes.Add(tn);
                            }
                        }
                    }
                    else
                    {
                        advFinishDoc.Nodes.Add(tn);
                    }
                }
            }

            foreach (Node pNode in node.Nodes)
            {
                GetPatientDoc(advFinishDoc.Nodes, pNode);
            }
        }

        /// <summary>
        /// ����û����������
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="node"></param>
        public void RemoveBookNode(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Node TempNode = nodes[i];
                Class_Text text = TempNode.Tag as Class_Text;
                if (TempNode.Name != "396")
                {
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
                                if (TempNode.ImageIndex == 17)   //�����ǰ��������ڵ������id��ͬ,˵���õ�ʵ�������Ѿ��������ˣ���ɫ���Ϊ��ɫ
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


        #endregion

        /// <summary>
        /// ���������ݽڵ���뵽�����������
        /// </summary>
        /// <param name="nodes">�������</param>
        /// <param name="node">��������</param>
        public void GetPatientDoc(NodeCollection nodes, Node node)
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
                    if (text.Issimpleinstance == "1")   //��������
                    {

                        if (doc.Textkind_id == text.Id) //�����ǰ��������ڵ������id��ͬ���ͰѸ�����������ڵ������
                        {

                            if (doc.Submitted == "N")//�ݴ���ʾΪ��ɫ
                            {
                                node.Style = elementStyleBlue;
                                node.Text += "(�ݴ�)";
                            }
                            else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N��ʾ����ҽʦδǩ�ֵ����飬��ʾΪ��ɫ
                            {
                                node.Style = elementStyleRed;
                                node.Text += "(ȱ����ҽʦǩ��)";
                            }
                            else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                            {
                                if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                                {
                                    node.Style = elementStyleOrange;
                                    node.Text += "(ȱ�ϼ�ҽʦǩ��)";
                                }
                            }
                            TempNode.Nodes.Add((Node)node.DeepCopy());
                            break;
                        }
                    }
                    else
                    {
                        if (TempNode.Nodes.Count == 0)
                        {
                            if (doc.Textkind_id == text.Id)   //�����ǰ��������ڵ������id��ͬ,˵���õ�ʵ�������Ѿ��������ˣ���ɫ���Ϊ��ɫ
                            {
                                //TempNode.SelectedImageIndex = 16;
                                TempNode.ImageIndex = 16;
                                if (doc.Submitted == "N")//�ݴ���ʾΪ��ɫ
                                {
                                    TempNode.Style = elementStyleBlue;
                                    TempNode.Text += "(�ݴ�)";
                                }
                                else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N��ʾ����ҽʦδǩ�ֵ����飬��ʾΪ��ɫ
                                {
                                    TempNode.Style = elementStyleRed;
                                    TempNode.Text += "(ȱ����ҽʦǩ��)";
                                }
                                else if (doc.Ishighersign == "Y")//�Ƿ���Ҫ�ϼ�ҽʦǩ�֣�Y��ʾ��Ҫ
                                {
                                    if (doc.Havehighersign == "N")//�ϼ�ҽʦ�Ƿ���ǩ�֣�N����ûǩ
                                    {
                                        TempNode.Style = elementStyleOrange;
                                        TempNode.Text += "(ȱ�ϼ�ҽʦǩ��)";
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                if (TempNode.Nodes.Count > 0)
                {
                    GetPatientDoc(TempNode.Nodes, node);
                }
            }
        }





        /// <summary>
        /// ��ǰѡ�еĽڵ㣬�Ƿ���tctlDoc.Tabs���������Ѿ����ڣ�����true,����false
        /// </summary>
        /// <param name="tid">�����id</param>
        /// <returns></returns>
        private bool IsSameTabItem(string tid)
        {
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                Patient_Doc doc = tctlDoc.Tabs[i].Tag as Patient_Doc;
                if (doc != null)
                {
                    if (doc.Id.ToString() == tid)
                    {
                        tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                        App.MsgWaring("�Ѿ�������ͬ�����飡");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �жϸ��൥�������Ƿ��Ѿ�����
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">����id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
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
                                            tctlDoc.Tabs.Remove(item);
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
                        }
                    }
                    //��֤����״̬�����ύ����������ݴ水ť

                    //SetZanCunButton(item.Name.Split(';')[0].ToString());
                }

            }
            catch (Exception)
            {

            }
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
                if (node != null)
                {
                    textTitle = node.Text;
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
                                textTitle = "�״β��̼�¼";
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
                                textTitle = node.Text;
                            }
                            //textTitle = node.Text;
                        }
                        return textTitle;
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
                                textTitle = "�״β��̼�¼";
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
                                textTitle = node.Text;
                            }
                        }
                        return textTitle;
                    }
                }
                else
                {
                    Class_Text text = node.Tag as Class_Text;
                    if (text != null)
                    {
                        if (text.Parentid.ToString() == "103" || text.Id.ToString() == "103")
                        {
                            if (text.Id.ToString() == "125" || text.Id.ToString() == "103")
                            {
                                textTitle = "�״β��̼�¼";
                            }
                            else
                            {
                                textTitle = "���̼�¼";
                            }
                        }
                        else
                        {
                            textTitle = node.Text;
                        }
                        if (text.Issimpleinstance == "0")
                        {

                            if (node.Text.Contains("(ȱ����ҽʦǩ��)"))
                            {
                                textTitle = textTitle.Replace("(ȱ����ҽʦǩ��)", "");
                            }
                            else if (node.Text.Contains("(ȱ�ϼ�ҽʦǩ��)"))
                            {
                                textTitle = textTitle.Replace("(ȱ�ϼ�ҽʦǩ��)", "");
                            }
                        }
                    }
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
        ///  �ж����������Ƿ�����ͬ���Ƶ����顣
        /// </summary>
        /// <returns></returns>
        private bool IsSameBookDoc()
        {
            bool flag = false;
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            if (this.currentPatient != null)
            {

                #region Ԭ��2014-12-18 ע��
                // TreeNode node = DataInit.SelectDoc(currentPatient.Id, advFinishDoc.SelectedNode.Name);
                //��ǰ�������������
                //string new_TextName = Record_Time + "   " + Record_Content;
                //foreach (TreeNode childNode in node.Nodes)
                //{
                //    Patient_Doc pdoc = childNode.Tag as Patient_Doc;
                //    //�Ѿ����ڸ������������
                //    string old_TextName = pdoc.Docname;
                //    if (new_TextName.Equals(old_TextName))
                //    {
                //        flag = true;
                //        App.Msg("�Ѿ�������ͬ�����飡");
                //        break;
                //    }
                //} 
                #endregion
            }
            return flag;
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

        #region

        public void GetFinishDocToXml(InPatientInfo info, AdvTree finishTree)
        {
            if (finishTree != null && finishTree.Nodes.Count > 0)
            {
                DataTable dt = App.GetDataSet(string.Format("SELECT T.TID,T.TEXTKIND_ID,T.PAGEINDEX,T.PAGECOUNT FROM T_PATIENTS_DOC T WHERE T.PATIENT_ID = '{0}'", info.Id)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    XmlDocument document = new XmlDocument();
                    document.PreserveWhitespace = true;
                    document.LoadXml("<list/>");
                    returnFinishDocXml(document.DocumentElement, dt);
                    //App.UpLoadFtpPatientDoc(document.OuterXml, "list.xml", info.Id.ToString());
                }
            }
        }
        public void returnFinishDocXml(XmlElement document, DataTable dt)
        {
            foreach (Node node in advFinishDoc.Nodes)
            {
                if (node.Tag != null)
                {
                    if (node.Tag.GetType().Name == "Patient_Doc")
                    {
                        Patient_Doc doc = node.Tag as Patient_Doc;
                        XmlElement patient_node = document.OwnerDocument.CreateElement("Doc_Text");
                        patient_node.SetAttribute("name", node.Text);
                        DataRow[] row = dt.Select(string.Format("TID = '{0}'", doc.Id));
                        if (row.Length > 0)
                        {
                            patient_node.SetAttribute("index", row[0]["pageindex"].ToString());
                            patient_node.SetAttribute("count", row[0]["pagecount"].ToString());
                            patient_node.SetAttribute("firstName", doc.Id.ToString());
                        }
                        document.AppendChild(patient_node);
                    }
                    else if (node.Tag.GetType().Name == "Class_Text")
                    {
                        XmlElement patient_node;
                        Class_Text text = node.Tag as Class_Text;
                        if (text.Issimpleinstance == "0")
                        {
                            DataRow[] row = dt.Select(string.Format("TEXTKIND_ID = '{0}'", text.Id));
                            patient_node = document.OwnerDocument.CreateElement("Doc_Text");
                            patient_node.SetAttribute("name", node.Text);
                            if (row.Length > 0)
                            {
                                patient_node.SetAttribute("index", row[0]["pageindex"].ToString());
                                patient_node.SetAttribute("count", row[0]["pagecount"].ToString());
                                patient_node.SetAttribute("firstName", text.Id.ToString());
                            }
                        }
                        else
                        {
                            patient_node = document.OwnerDocument.CreateElement("Doc_Type");
                            patient_node.SetAttribute("name", node.Text);
                        }
                        if (node.Nodes.Count > 0)
                        {
                            LoadChildNodeToXml(patient_node, node, dt, text.Id);
                        }
                        document.AppendChild(patient_node);
                    }
                }
            }
        }

        public void LoadChildNodeToXml(XmlElement element, Node node, DataTable dt, int isBc)
        {
            foreach (Node node1 in node.Nodes)
            {
                if (node1.Tag != null)
                {
                    if (node1.Tag.GetType().Name == "Patient_Doc")
                    {
                        Patient_Doc doc = node1.Tag as Patient_Doc;
                        XmlElement patient_node = element.OwnerDocument.CreateElement("Doc_Text");
                        patient_node.SetAttribute("name", node1.Text);
                        DataRow[] row = dt.Select(string.Format("TID = '{0}'", doc.Id));
                        if (row.Length > 0)
                        {
                            patient_node.SetAttribute("index", row[0]["pageindex"].ToString());
                            patient_node.SetAttribute("count", row[0]["pagecount"].ToString());
                            patient_node.SetAttribute("firstName", isBc == 103 ? "103" : doc.Id.ToString());
                        }
                        element.AppendChild(patient_node);
                    }
                    else if (node1.Tag.GetType().Name == "Class_Text")
                    {
                        XmlElement patient_node;
                        Class_Text text = node1.Tag as Class_Text;
                        if (text.Issimpleinstance == "0")
                        {
                            DataRow[] row = dt.Select(string.Format("TEXTKIND_ID = '{0}'", text.Id));
                            patient_node = element.OwnerDocument.CreateElement("Doc_Text");
                            patient_node.SetAttribute("name", node1.Text);
                            if (row.Length > 0)
                            {
                                patient_node.SetAttribute("index", row[0]["pageindex"].ToString());
                                patient_node.SetAttribute("count", row[0]["pagecount"].ToString());
                                patient_node.SetAttribute("firstName", isBc == 103 ? "103" : text.Id.ToString());
                            }
                        }
                        else
                        {
                            patient_node = element.OwnerDocument.CreateElement("Doc_Type");
                            patient_node.SetAttribute("name", node1.Text);
                        }
                        if (node1.Nodes.Count > 0)
                        {
                            LoadChildNodeToXml(patient_node, node1, dt, isBc);
                        }
                        element.AppendChild(patient_node);
                    }
                }
            }
        }

        public Patient_Doc[] GetPictureType(Node parentNode)
        {
            return this.GetContentByType(parentNode);
        }

        public static XmlDocument SplitXml(Patient_Doc[] patient_Docs)
        {
            XmlDocument TempXml = new XmlDocument();
            TempXml.PreserveWhitespace = true;
            StringBuilder strBuilder = new StringBuilder();
            #region ���󲡳̼�¼û���ӽڵ�ƴ��xml

            for (int i = 0; i < patient_Docs.Length; i++)
            {
                if (patient_Docs[i] == null)
                    continue;
                XmlDocument ChildXml = new XmlDocument();
                ChildXml.PreserveWhitespace = true;
                if (patient_Docs[i].Patients_doc == "")
                {
                    continue;
                }
                ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                if (patient_Docs[i].Textkind_id == 136 || patient_Docs[i].Textkind_id == 135 || patient_Docs[i].Textkind_id == 301)    //�����״β��� ��ǰС�� ת���¼�����ҳ�� 
                {
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //סԺ���̼�¼�������״β��̺��棬Ҫ�����ҳ��
                //if ((
                //    patient_Docs[i].Textkind_id == 135
                //    ) && (i >= 1 && patient_Docs[i - 1].Textkind_id == 125))//i-1��ʾ��һ�����飬i>=1��ʾ�����������������Ҫ������
                //{
                //    strBuilder.Append(@"<Skip operatercreater='0' /><p operatercreater='0' />");
                //}
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//��������
                //strBuilder.Append(ChildXml.InnerXml );//����XML����
                strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name + "' bed_no='" + patient_Docs[i].Bed + "' />");

                if (patient_Docs[i].Belongtosys_id == 1)
                {
                    //strBuilder.Append(@"<split textId = '" + patient_Docs[i].Id + "'/><p operatercreater='0' align='2'/>");
                }
                else
                {

                }
                {
                    // strBuilder.Append(@"<split textId = '" + patient_Docs[i].Textkind_id + "'/><p operatercreater='0' align='2'/>");
                }
            }
            //}
            #endregion

            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc><body></body></emrtextdoc>");
            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
            string ss = strBuilder.ToString();
            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            {
                if (bodyNode.Name == "body")
                {
                    bodyNode.InnerXml = strBuilder.ToString();
                }
            }
            return tempxmldoc;
        }

        public Node IsInBcjl(Node node)
        {
            if (node == null)
            {
                return null;
            }
            while (node.Parent != null)
            {
                if (node.Parent.Name == "103")
                {
                    return node.Parent;
                }
                else
                {
                    node = node.Parent;
                }
            }
            return null;
        }

        public void returnTextNode(NodeCollection nodes, int tid, int text_id, ref Node selectNode)
        {
            if (selectNode != null)
            {
                return;
            }
            foreach (Node _node in nodes)
            {
                if (_node.Tag == null)
                    continue;

                if (_node.Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    Patient_Doc pdoc = _node.Tag as Patient_Doc;
                    if (pdoc.Id == tid)
                    {
                        selectNode = _node;
                        return;
                    }
                }
                else if (_node.Tag.GetType().ToString().Contains("Class_Text"))
                {
                    if (_node.Name == text_id.ToString())
                    {
                        selectNode = _node;
                        return;
                    }
                }
                if (_node.Nodes.Count > 0)
                {
                    if (selectNode != null)
                    {
                        return;
                    }
                    returnTextNode(_node.Nodes, tid, text_id, ref selectNode);
                }
            }
        }

        #endregion


        private void tctlDoc_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0)
                {
                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (tempEditor != null)
                    {
                        tempEditor.MyDoc.SetToolEvent();
                    }

                }

                //�ύ�ݴ��ӡ��ť����
                TabItem item = e.NewTab;
                if (item != null)
                {
                    if (item.Text.Contains("���"))
                    {
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                    }
                    else if (item.Name.Split(';').Length == 4 && item.Name.Split(';')[2].ToString() == "0")
                    {
                        App.SetToolButtonByUser("tsbtnCommit", true);
                        App.SetToolButtonByUser("tsbtnTempSave", true);
                    }
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

        /// <summary>
        /// �õ���������
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        private Patient_Doc GetDoc(string docId)
        {
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,a.textname,a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid,a.israplacehightdoctor,a.israplacehightdoctor2  from t_patients_doc a  where tid=" + docId;
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
        /// ��õ�ǰ�ڵ��������в�������Ľڵ�
        /// </summary>
        /// <param name="nodes">��ǰ�ڵ��µ�������������</param>
        /// <returns>����Patient_Doc����</returns>
        private Patient_Doc[] GetSelectNodes(Class_Text text)
        {
            //string sql = "select a.tid,a.patients_doc,b.textname,a.textkind_id from t_patients_doc a " +
            //             " left join t_quality_text b on a.tid=b.tid " +
            //             " where a.patient_id='" + currentPatient.Id + "'and a.textkind_id=" + text.Id + " order by a.tid";
            string sql = "select tid,textname,textkind_id,doc_name,section_name,bed_no from t_patients_doc where patient_id='" + currentPatient.Id + "'and textkind_id=" + text.Id + " and submitted='Y' order by doc_name";
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

                            string content = "";
                            content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (content == null || content == "")
                            {
                                content = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                            }

                            patient_Docs[i].Patients_doc = content;//App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
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
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name,a.bed_no from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134��ǰ����
                             " and textkind_id in (select id from t_text where parentid=" + textid + ")  and submitted='Y' order by doc_name";
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

                                string content = "";
                                content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                                if (content == null || content == "")
                                {
                                    content = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                                }

                                patient_Docs[i].Patients_doc = content; //App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                                patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                                patient_Docs[i].Belongtosys_id = Convert.ToInt32(dt.Rows[i]["issimpleinstance"].ToString());
                                patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                                patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                                patient_Docs[i].Bed = dt.Rows[i]["bed_no"].ToString();
                                tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
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
            string sql = "select a.tid,a.textname,a.textkind_id,a.createid,a.submitted,a.doc_name,a.section_name,a.bed_no from t_patients_doc a " +
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

                            string content = "";
                            content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (content == null || content == "")
                            {
                                content = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                            }

                            patient_Docs[i].Patients_doc = content;//App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Createid = dt.Rows[i]["createid"].ToString();
                            patient_Docs[i].Submitted = dt.Rows[i]["submitted"].ToString();
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
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
            XmlDocument TempXml = new XmlDocument();
            TempXml.PreserveWhitespace = true;
            StringBuilder strBuilder = new StringBuilder();
            #region ���󲡳̼�¼û���ӽڵ�ƴ��xml

            for (int i = 0; i < patient_Docs.Length; i++)
            {
                if (patient_Docs[i] == null)
                    continue;
                XmlDocument ChildXml = new XmlDocument();
                ChildXml.PreserveWhitespace = true;
                ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                if (patient_Docs[i].Textkind_id == 136 || patient_Docs[i].Textkind_id == 135 || patient_Docs[i].Textkind_id == 301)    //�����״β��� ��ǰС�� ת���¼�����ҳ�� 
                {
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //סԺ���̼�¼�������״β��̺��棬Ҫ�����ҳ��
                //if ((
                //    patient_Docs[i].Textkind_id == 135
                //    ) && (i >= 1 && patient_Docs[i - 1].Textkind_id == 125))//i-1��ʾ��һ�����飬i>=1��ʾ�����������������Ҫ������
                //{
                //    strBuilder.Append(@"<Skip operatercreater='0' /><p operatercreater='0' />");
                //}
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//��������
                //strBuilder.Append(ChildXml.InnerXml );//����XML����
                strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name + "' bed_no='" + patient_Docs[i].Bed + "' />");

                if (patient_Docs[i].Belongtosys_id == 1)
                {
                    //strBuilder.Append(@"<split textId = '" + patient_Docs[i].Id + "'/><p operatercreater='0' align='2'/>");
                }
                else
                {

                }
                {
                    // strBuilder.Append(@"<split textId = '" + patient_Docs[i].Textkind_id + "'/><p operatercreater='0' align='2'/>");
                }
            }
            //}
            #endregion

            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            ucText.MyDoc.ToXML(tempxmldoc.DocumentElement);

            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//����<body>
            string ss = strBuilder.ToString();
            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            {
                if (bodyNode.Name == "body")
                {
                    bodyNode.InnerXml = strBuilder.ToString();
                }
            }

            ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);
            ucText.MyDoc.ContentChanged();
            ucText.Dock = DockStyle.Fill;

            ucText.MyDoc.Locked = true;
        }

        #region ȫ������������
        /// <summary>
        /// 1.������˫���¼�
        /// 2.��˫���������Ľڵ�ʱ����
        /// 3.��������Ĵ�Ȩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            #region ��������ڵ�
            if (advFinishDoc.SelectedNode != null)
            {
                if (advFinishDoc.SelectedNode.Name != "" && currentPatient != null)
                {
                    if (advFinishDoc.SelectedNode.ImageIndex != 15 && advFinishDoc.SelectedNode.ImageIndex != 20)//��ǰ���Ҳ�������鿴
                    {
                        AddDoc();
                    }
                }
            }
            #endregion
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
            try
            {
                if (advFinishDoc.SelectedNode.Tag != null)
                {
                    int tid = 0;
                    /*
                     * tctlDoc����tabItem���ж��Ƿ����ظ��ġ�
                     * tctlDoc��û��tabItem����ֱ�Ӵ���
                     */
                    if (advFinishDoc.SelectedNode.Tag.ToString().Contains("Class_Text"))
                    {
                        Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
                        string temptid = "";
                        if (text != null && text.Issimpleinstance == "0")//��������
                        {
                            tid = Convert.ToInt32(isExitRecord(text.Id, currentPatient.Id));//�жϸ��൥�������Ƿ����
                            if (tid == 0)
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (advFinishDoc.SelectedNode.Tag.ToString().Contains("Patient_Doc"))
                    {
                        Patient_Doc doc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                        if (doc != null)
                        {
                            tid = doc.Id;
                        }
                    }
                    //if (tctlDoc.Tabs.Count > 0 && tid != 0)
                    //{
                    //    /*
                    //     * IsSameTabItem()�ж�tctlDoc�Ƿ�����ͬ����������(TabItem)
                    //     * IsSameBookDoc()�ж�tctlDoc�Ƿ�����ͬ������(TabItem)
                    //     */
                    //    if (IsSameTabItem(tid.ToString()) == false)          //false��ʾ����û����ͬ��tabItem advFinishDoc.SelectedNode.Name
                    //    {
                    //        CreateTabItem(tid);
                    //    }
                    //}
                    //else
                    //{
                    CreateTabItem(tid);
                    //}
                }

            }
            catch (Exception ex)
            {
                int patient_Id = currentPatient.Id;
                //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);
                App.MsgErr("���������쳣��ԭ��" + ex.Message);
            }
        }
        /// <summary>
        /// �����µ�tabItem
        /// </summary>
        /// <param name="tid">����id</param>
        private void CreateTabItem(int tid)
        {
            //��֤�ظ���
            if (IsSameTabItem(tid.ToString()) == true)
            {
                return;
            }
            /*
             * �����µ�tabItem ��ʵ��˼·��
             * 1.��ǰѡ�е������������ǵ������飬�Ͳ�������ݡ�
             * 2.��ǰѡ�е��ǲ������飬��������id�����������
             */
            // ��õ�ǰʱ�䣬��ȷ������
            // string time = string.Format("{0:g}", App.GetSystemTime());
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);
            //page.Click += new EventHandler(page_Click);

            //if (tid == 0)
            //{
            //    Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
            //    //�½����飬pageҳ��Name�÷ֺŸ�������һλ��������������ID;�ڶ�λ����������;����λ�������½�����;����λ���Ƿ�������
            //    page.Name = advFinishDoc.SelectedNode.Name + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
            //}
            //else //�޸����飬pageҳ��Name�÷ֺŸ�������һλ������ID���ڶ�λ����������
            //{
            //    page.Name = tid + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString();
            //}
            if (advFinishDoc.SelectedNode == null)
            {
                App.Msg("û�ҵ������飡");
                return;
            }
            page.Text = advFinishDoc.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " ��)";
            if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                if (advFinishDoc.SelectedNode.Nodes.Count == 0 ||
                    advFinishDoc.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    //��������
                    Class_Text select_text = advFinishDoc.SelectedNode.Tag as Class_Text;
                    //��д����
                    Patient_Doc doc = GetDoc(select_text);
                    page.Tag = doc;
                    if (page.Tag != null)
                    {
                        string log_Tid = advFinishDoc.SelectedNode.Name;
                        isCustom = false;

                        //�Ƿ���Կ���
                        bool NeglectLine = IsNeglectLine(advFinishDoc.SelectedNode);
                        string textTitle = GetTextTitle(advFinishDoc.SelectedNode);
                        page.Tooltip = select_text.Textname.ToString();

                        //�򿪵�������
                        if (currentPatient.Sick_Bed_Name != "")
                        {
                            //tid = Convert.ToInt32(temptid);
                            frmText text = new frmText(select_text.Id, 0, 0, textTitle, tid, currentPatient, true, false, Record_Time, Record_Content);

                            text.MyDoc.IgnoreLine = NeglectLine;

                            XmlDocument tmpxml = new System.Xml.XmlDocument();
                            tmpxml.PreserveWhitespace = true;
                            string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name from t_patients_doc where textkind_id=" + select_text.Id + " and patient_id=" + currentPatient.Id + "";
                            DataTable dt = App.GetDataSet(sql).Tables[0];
                           
                            string content = "";
                            content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                            if (content == null || content == "")
                            {
                                content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                            }
                            //content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", currentPatient.Id.ToString()); //dt.Rows[0]["patients_doc"].ToString();
                            string ishighersign = dt.Rows[0]["Ishighersign"].ToString();
                            string havedoctorsign = dt.Rows[0]["Havedoctorsign"].ToString();
                            string havehighersign = dt.Rows[0]["Havehighersign"].ToString();
                            text.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                            //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                            text.MyDoc.TextSuperiorSignature = ishighersign;
                            text.MyDoc.HaveTubebedSign = havedoctorsign;  //����ҽʦ�Ƿ���ǩ
                            text.MyDoc.HaveSuperiorSignature = havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��

                            //��������-------------------------------------------------------
                            if (this.OnComeFrmText != null)
                            {
                                //�����¼�
                                OnComeFrmText(text);
                            }
                            //--------------------------------------------------------
                            
    

                            tmpxml.LoadXml(content);
                            if (advFinishDoc.SelectedNode.Text.Contains("�ճ����̼�¼"))
                            {
                                text.MyDoc.HidleNameTitle = false;
                            }
                            text.MyDoc.FromXML(tmpxml.DocumentElement);
                            text.MyDoc.ContentChanged();
                            tabctpnDoc.Controls.Add(text);
                            text.Dock = DockStyle.Fill;
                        }

                        tabctpnDoc.TabItem = page;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        //if (doc.Submitted == "Y")
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
            //�򿪶�������
            else if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {
                //�����������
                string textTitle = GetTextTitle(advFinishDoc.SelectedNode);
                //�Ƿ���Ժ��Կ���
                bool NeglectLine = IsNeglectLine(advFinishDoc.SelectedNode);


                Class_Text cText = advFinishDoc.SelectedNode.Parent.Tag as Class_Text;
                Patient_Doc pdoc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                page.Tag = pdoc;
                if (currentPatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    page.Tooltip = cText.Textname;

                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, currentPatient, true, true, Record_Time, Record_Content);
                    text.MyDoc.Section_name = pdoc.Section_name;//������������ 
                    //if (OperateState != null && OperateState.Contains("��¼"))
                    //{
                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //�޸����飬Ishighersign�Ƿ���Ҫ�ϼ�ҽʦ��ǩ
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //����ҽʦ�Ƿ���ǩ
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//�Ƿ��Ѿ��й��ϼ�ҽ��ǩ��
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //�鷿ҽ����userId

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

                    //��������-------------------------------------------------------
                    if (this.OnComeFrmText != null)
                    {
                        //�����¼�
                        OnComeFrmText(text);
                    }
                    //--------------------------------------------------------
                    

                    System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    //string sql = "select patients_doc from t_patients_doc where tid=" + pdoc.Id + "";
                    //string content = "";//App.ReadSqlVal(sql, 0, "patients_doc");
                    //content = App.DownLoadFtpPatientDoc(pdoc.Id + ".xml", currentPatient.Id.ToString());

                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + tid + "", 0, "CONTENT");
                    if (content == null || content == "")
                    {
                        content = App.DownLoadFtpPatientDoc(tid + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                    }
                    
                    //string content = "";
                    //    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                    //    if (content == null || content == "")
                    //    {
                    //        content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                    //    }
                    
                    tmpxml.LoadXml(content);

                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();
                    tabctpnDoc.Controls.Add(text);
                    text.Dock = DockStyle.Fill;
                    text.MyDoc.SetToolEvent();
                    tabctpnDoc.TabItem = page;
                    //page.Tooltip = docflaag;
                    tabctpnDoc.Dock = DockStyle.Fill;
                    page.AttachedControl = tabctpnDoc;
                    this.tctlDoc.Controls.Add(tabctpnDoc);
                    this.tctlDoc.Tabs.Add(page);
                    this.tctlDoc.Refresh();
                    this.tctlDoc.SelectedTab = page;
                    string log_Tid = advFinishDoc.SelectedNode.Name;
                    int patient_Id = currentPatient.Id;
                    //LogHelper.SystemLog("", "S", "�������", log_Tid, currentPatient.PId, patient_Id);
                    //��������
                    if (!sectionflag)
                    {
                        // text.MyDoc.Locked = true;
                    }
                    if (pdoc.Submitted == "Y")
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                    }
                    else
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", true);
                    }
                }
            }

            App.AddCurrentDocMsg(currentPatient.Id.ToString() + page.Text);
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
            //AddZYNode(temptrvbook.Nodes);
            AddFinishNode();
            RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//չ����������ڵ�

        }
        #endregion

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advFinishDoc.SelectedNode != null)
            {
                advFinishDoc_DoubleClick(advFinishDoc, e);
            }
            else
            {
                App.Msg("��ѡ������ڵ㣡");
            }
        }

        private void ˢ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReflashTrvBook();
        }

        #region ���ֲ���
        private void BindSource()
        {
            try
            {
                dgvSource.Rows.Clear();
                string strKouFenHuiZong = " select t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id,isxg,docId from t_deduct_score t where t.ITEM_PATIENTID='" + currentPatient.Id + "'";
                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvSource.Rows.Add();
                        dgvSource.Rows[i].Cells[0].Value = dt.Rows[i]["id"];
                        dgvSource.Rows[i].Cells[1].Value = dt.Rows[i]["������Ŀ"];
                        dgvSource.Rows[i].Cells[2].Value = dt.Rows[i]["��ֵ"];
                        dgvSource.Rows[i].Cells[3].Value = dt.Rows[i]["�۷ֱ�׼"];
                        dgvSource.Rows[i].Cells[4].Value = dt.Rows[i]["�۷�����"];
                        dgvSource.Rows[i].Cells[5].Value = dt.Rows[i]["medical_mark_id"];
                        dgvSource.Rows[i].Cells[6].Value = dt.Rows[i]["isxg"];
                        dgvSource.Rows[i].Cells[7].Value = dt.Rows[i]["docId"];
                    }
                    for (int j = 0; j < dgvSource.Rows.Count; j++)
                    {
                        string xg = dgvSource.Rows[j].Cells[6].Value.ToString();
                        //���1 Ϊ���޸� ����ɫ
                        if (xg == "1")
                        {
                            dgvSource.Rows[j].DefaultCellStyle.ForeColor = Color.Green;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void ȷ���޸�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvSource.SelectedCells[0].Value.ToString();
                string sql = "update t_deduct_score set isxg ='1' where id ='" + id + "'";
                if (App.Ask("ȷ���޸���ɣ�"))
                {
                    //ȷ����ť�ķ���
                    int result = App.ExecuteSQL(sql);
                    if (result > 0)
                    {
                        App.Msg("�޸ĳɹ���");
                        BindSource();
                    }
                }
                else
                {
                    //ȡ����ť�ķ���
                    return;
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// ˫��ȱ�ݴ򿪶�Ӧ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSource_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSource.CurrentRow != null)
            {
                //��ȡȱ�ݶ�Ӧ������ID
                int docId = Convert.ToInt32(dgvSource.CurrentRow.Cells["docId"].Value);
                if (docId != 0)
                {
                    Patient_Doc doc = GetDoc(docId.ToString());
                    SetSelectNode(advFinishDoc.Nodes, doc);
                    CreateTabItem(docId);                   
                }
            }
        }

        


        /// <summary>
        /// ������������ѡ�нڵ�
        /// </summary>
        /// <param name="advNodes">��ǰ������</param>
        /// <param name="doc">ȱ�ݶ�Ӧ���������</param>
        private void SetSelectNode(NodeCollection advNodes, Patient_Doc doc)
        {
            for (int i = 0; i < advNodes.Count; i++)
            {
                //ѭ���еĵ�ǰ�ڵ㣨Class_Text�ǵ������飩
                if (advNodes[i].Tag.GetType().ToString().Contains("Class_Text"))
                {
                    if (advNodes[i].Nodes.Count > 0)
                    {
                        SetSelectNode(advNodes[i].Nodes,doc);
                    }
                    else if (advNodes[i].Name == doc.Textkind_id.ToString())
                    {
                        advFinishDoc.SelectedNode = advNodes[i];
                        break;
                    }
                }
                else
                {
                    Patient_Doc tempDoc = advNodes[i].Tag as Patient_Doc;
                    if (tempDoc.Id == doc.Id)
                    {
                        advFinishDoc.SelectedNode = advNodes[i];
                        break;
                    }
                }
            }
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    if (nodes[i].Name == CurrentNode.Name)
            //    {
            //        advFinishDoc.SelectedNode = nodes[i];
            //        advFinishDoc.SelectedNode = nodes[i];
            //        return;
            //    }
            //    else if (nodes[i].Nodes.Count > 0)
            //    {
            //        SetSelectNode(nodes[i].Nodes);
            //    }
            //}
        }
        #endregion

        public void QRXG(string id)
        {
            string sql = "update t_deduct_score set isxg ='1' where id ='" + id + "'";
            int result = App.ExecuteSQL(sql);
            if (result > 0)
            {
                MessageBox.Show("�޸ĳɹ���");
                BindSource();                
            }
            else
            {
                return;
            }
        }

        private void ˢ��ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BindSource();
        }


    }
}
