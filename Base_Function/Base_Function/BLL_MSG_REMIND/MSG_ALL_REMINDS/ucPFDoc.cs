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
        //保存所有的文书类型
        private AdvTree temptrvbook = new AdvTree();
        /// <summary>
        /// 当前病人对象。 
        /// </summary>
        public InPatientInfo currentPatient;
        private string Record_Time = null;
        private string Record_Content = null;
        private static Node CurrentNode = new Node();

        //评分返回编辑器对象
        public delegate void ComeFrmText(frmText frm);
        public ComeFrmText OnComeFrmText;

        /// <summary>
        /// 是否是定制的文书
        /// </summary>
        private bool isCustom = false;

        /// <summary>
        /// 弹出时间选择窗体的返回值，点击确定返回True，点击取消返回false
        /// </summary>
        public static bool isFlagtrue = false;

        public delegate void DeleGetRecord(string time, string content);

        /// <summary>
        /// 保存提交过的文书id
        /// </summary>
        private ArrayList save_TextId = new ArrayList();

        /// <summary>
        /// 术后病程记录是否有子节点
        /// </summary>
        bool isChildNode = false;

        /// <summary>
        /// 重新绑定按钮
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
            //dockContainerItem1.Text = "文书操作";
            //dockContainerItem2.Text = "模版提取";
        }
        public ucPFDoc(InPatientInfo patientInfo,bool flag)
        {
            InitializeComponent();
            currentPatient = patientInfo;
            //dockContainerItem1.Text = "文书操作";
            //dockContainerItem2.Text = "模版提取";
            if (flag == false)
            {
                barPF.Visible = false;
            }
        }

        private void ucDoctorOperater_Load(object sender, EventArgs e)
        {
            DataInit.ReflashBookTree(temptrvbook);
            ReflashTrvBook();//刷新文书树
            BindSource();//绑定评分列表         
            frmText text = new frmText();
            //袁杨2014-12-18 注释
            //text.MyDoc.OnBackPfIdDoctor += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFIdDoctor(MyDoc_OnBackPfIdDoctor);
        }

        void MyDoc_OnBackPfIdDoctor(string id)
        {
            BindSource();
        }

      
       
        #region 已写文书操作

        /// <summary>
        /// 添加住院病程记录
        /// </summary>
        public void AddZYNode(NodeCollection tempNode)
        {
            foreach (Node node in tempNode)
            {
                if (tempNode.Count > 0)
                {
                    AddZYNode(node.Nodes);
                }
                if (node.Text == "住院病程记录")
                {
                    advFinishDoc.Nodes.Add(node.DeepCopy());
                }
            }
        }

        /// <summary>
        /// 添加已完成文书
        /// </summary>
        public void AddFinishNode()
        {
            Node node = null;
            if (currentPatient != null)
            {
                node = DataInit.SelectDoc(currentPatient.Id);//获得已写文书
            }
            //取得非住院病程记录文书父节点的ID，拼接字符串以逗号隔开
            string docStr = "";
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                Patient_Doc doc = node.Nodes[i].Tag as Patient_Doc;
                if (doc != null)// && doc.Textname != "病程记录")  
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
                //查出所有非病程记录的已写文书父节点
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
                            if (advFinishDoc.Nodes[j].Text == "住院病程记录")
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
                            if (advFinishDoc.Nodes[j].Text == "住院病程记录")
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
        /// 隐藏没有文书类型
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
                        if (text.Issimpleinstance == "1")   //多例文书
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
                                if (TempNode.ImageIndex == 17)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
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
        /// 把文书内容节点插入到具体的文书下
        /// </summary>
        /// <param name="nodes">文书类别</param>
        /// <param name="node">文书内容</param>
        public void GetPatientDoc(NodeCollection nodes, Node node)
        {
            Patient_Doc doc = node.Tag as Patient_Doc;
            if (doc != null)
            {
                //代主治查房显示*号
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor == "Y")
                {
                    node.Text = "*" + doc.Docname;
                }
                //代主任查房显示△
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor2 == "Y")
                {
                    node.Text = "△" + doc.Docname;
                }
            }

            foreach (Node TempNode in nodes)
            {
                Class_Text text = TempNode.Tag as Class_Text;
                if (text != null)
                {
                    if (text.Issimpleinstance == "1")   //多例文书
                    {

                        if (doc.Textkind_id == text.Id) //如果当前文书和树节点的文书id相同，就把该文书添加树节点的下面
                        {

                            if (doc.Submitted == "N")//暂存显示为蓝色
                            {
                                node.Style = elementStyleBlue;
                                node.Text += "(暂存)";
                            }
                            else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N表示经治医师未签字的文书，显示为红色
                            {
                                node.Style = elementStyleRed;
                                node.Text += "(缺经治医师签名)";
                            }
                            else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                            {
                                if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                {
                                    node.Style = elementStyleOrange;
                                    node.Text += "(缺上级医师签名)";
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
                            if (doc.Textkind_id == text.Id)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
                            {
                                //TempNode.SelectedImageIndex = 16;
                                TempNode.ImageIndex = 16;
                                if (doc.Submitted == "N")//暂存显示为蓝色
                                {
                                    TempNode.Style = elementStyleBlue;
                                    TempNode.Text += "(暂存)";
                                }
                                else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N表示经治医师未签字的文书，显示为红色
                                {
                                    TempNode.Style = elementStyleRed;
                                    TempNode.Text += "(缺经治医师签名)";
                                }
                                else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                                {
                                    if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                    {
                                        TempNode.Style = elementStyleOrange;
                                        TempNode.Text += "(缺上级医师签名)";
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
        /// 当前选中的节点，是否再tctlDoc.Tabs集合里面已经存在，存在true,否则false
        /// </summary>
        /// <param name="tid">文书的id</param>
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
                        App.MsgWaring("已经存在相同的文书！");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 判断该类单例文书是否已经存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
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
                        if (!item.Text.Contains("浏览"))
                        {
                            //验证是否定制文书
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
                            if (!isCustom) //不是定制的文书
                            {
                                DevComponents.DotNetBar.TabControlPanel tab = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                                frmText t = tab.Controls[0] as frmText;
                                if (t != null)
                                {
                                    if (t.MyDoc.Modified) //修改过文书，显示提示
                                    {
                                        if (App.Ask("该份文书没有提交，是否关闭？"))
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
                    //验证文书状态，已提交的文书禁用暂存按钮

                    //SetZanCunButton(item.Name.Split(';')[0].ToString());
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 获得文书记录时间，记录内容
        /// </summary>
        /// <param name="time">记录时间</param>
        /// <param name="content">记录内容</param>
        private void GetDate(string time, string content)
        {
            this.Record_Time = time;
            this.Record_Content = content;
        }

        /// <summary>
        /// 设置标题，住院病程记录的文书id=103,
        /// 下面所有文书标题为病程记录;
        /// 其他的文书的标题，则根据文书名称来显示
        /// </summary>
        /// <param name="node">当前节点</param>
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
                        if ((node.Parent.Name == "103") || node.Name == "103"  //住院病程记录文书id
                            || (node.Parent.Parent != null && node.Parent.Parent.Name == "103"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134" ||
                               node.Parent.Parent.Name == "134")  //术前小结
                            {
                                textTitle = "手术前小结";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "首次病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
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
                        if (node.Parent.Name == "103" || (node.Name == "103" && node.Text == "住院病程记录"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134")//术前小结
                            {
                                textTitle = "手术前小结";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "首次病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
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
                                textTitle = "首次病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
                            }
                        }
                        else
                        {
                            textTitle = node.Text;
                        }
                        if (text.Issimpleinstance == "0")
                        {

                            if (node.Text.Contains("(缺经治医师签名)"))
                            {
                                textTitle = textTitle.Replace("(缺经治医师签名)", "");
                            }
                            else if (node.Text.Contains("(缺上级医师签名)"))
                            {
                                textTitle = textTitle.Replace("(缺上级医师签名)", "");
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
        /// 是否可以忽略空行
        /// </summary>
        /// <param name="node">当前选中的节点</param>
        /// <returns>true忽略，false不忽略</returns>
        private bool IsNeglectLine(Node node)
        {
            bool NeglectLin = true;
            if (node != null)
            {
                if (node.Tag.ToString().Contains("Class_Text"))//文书节点
                {
                    Class_Text class_Text = node.Tag as Class_Text;
                    if (class_Text.Txxttype == "915")//知情同意书
                    {
                        NeglectLin = false;
                    }
                }
                else if (node.Tag.ToString().Contains("Patient_Doc"))//文书内容节点
                {
                    if (node.Parent != null)
                    {
                        Class_Text class_Text = node.Parent.Tag as Class_Text;
                        if (class_Text.Txxttype == "915")//知情同意书
                        {
                            NeglectLin = false;
                        }
                    }
                }
            }
            return NeglectLin;
        }

        /// <summary>
        ///  判断文书下面是否有相同名称的文书。
        /// </summary>
        /// <returns></returns>
        private bool IsSameBookDoc()
        {
            bool flag = false;
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            if (this.currentPatient != null)
            {

                #region 袁杨2014-12-18 注释
                // TreeNode node = DataInit.SelectDoc(currentPatient.Id, advFinishDoc.SelectedNode.Name);
                //当前创建文书的名称
                //string new_TextName = Record_Time + "   " + Record_Content;
                //foreach (TreeNode childNode in node.Nodes)
                //{
                //    Patient_Doc pdoc = childNode.Tag as Patient_Doc;
                //    //已经存在该类文书的名称
                //    string old_TextName = pdoc.Docname;
                //    if (new_TextName.Equals(old_TextName))
                //    {
                //        flag = true;
                //        App.Msg("已经存在相同的文书！");
                //        break;
                //    }
                //} 
                #endregion
            }
            return flag;
        }

        /// <summary>
        /// 提交住院病史确认书
        /// </summary>
        private void SubmitDoc(string strXml)
        {
            //先验证该病人是否已经写过住院病史确认书
            string sql_doc = "select * from t_patients_doc where patient_id=" + currentPatient.Id + " and textkind_id=1581";
            DataSet ds = App.GetDataSet(sql_doc);
            if (ds != null && ds.Tables[0].Rows.Count == 0)
            {
                XmlDocument document = new XmlDocument(); //xml文档对象
                document.PreserveWhitespace = true;       //不忽略空白部分
                document.LoadXml(strXml);        //这里加载文件
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
                        if (item2.Name == "div" && item2.Attributes["title"] != null && item2.Attributes["title"].Value.Contains("家族史"))
                        {
                            break;
                        }
                    }
                    XmlNode newNode = newDocument.CreateElement("table");
                    ((XmlElement)newNode).SetAttribute("tableLock", "1");
                    newNode.InnerXml = "<row id=\"C1B1C10640\" width=\"679\" min-height=\"40\"><cell id=\"C1B1C10641\" width=\"334\" candelete=\"1\" isVisble=\"0\"><p operatercreater=\"0\" /></cell><cell id=\"C1B1C10642\" width=\"334\" candelete=\"1\" isVisble=\"0\"><p operatercreater=\"0\" /></cell></row><row id=\"C1B1C10643\" width=\"679\"><cell id=\"C1B1C10644\" width=\"334\" candelete=\"1\" isVisble=\"0\"><span operatercreater=\"0\">    病史陈述者签名:</span><p operatercreater=\"0\" /></cell><cell id=\"C1B1C10645\" width=\"334\" candelete=\"1\" isVisble=\"0\"><span operatercreater=\"0\">陈述者与患者关系:</span><p operatercreater=\"0\" /></cell></row>";
                    bodyNode.AppendChild(newNode);


                    newDocument.DocumentElement.AppendChild(bodyNode);
                }
                int tid = App.GenId("t_patients_doc", "tid");
                string strinsert =
                          string.Format("insert into T_Patients_Doc(tid,CREATEID, pid, textkind_id, belongtosys_id, sickkind_id, textname,submitted,PATIENT_ID,DOC_NAME,SECTION_NAME,BED_NO,ISHIGHERSIGN,HAVEHIGHERSIGN,HAVEDOCTORSIGN) " +
                                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')"
                                        , tid.ToString()    //tid                                             //文书ID
                                        , App.UserAccount.UserInfo.User_id //是否提交按钮
                                        , currentPatient.PId //pid
                                        , 1581  //文书类型ID
                                        , 0 //
                                        , 0 //
                                        , "住院病史确认书"   //textname
                                        , "Y"  //暂存/提交
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
        /// 展开当前选中节点
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
            #region 术后病程记录没有子节点拼接xml

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
                if (patient_Docs[i].Textkind_id == 136 || patient_Docs[i].Textkind_id == 135 || patient_Docs[i].Textkind_id == 301)    //术后首次病程 术前小结 转入记录插入分页符 
                {
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //住院病程记录，跟在首次病程后面，要插入分页符
                //if ((
                //    patient_Docs[i].Textkind_id == 135
                //    ) && (i >= 1 && patient_Docs[i - 1].Textkind_id == 125))//i-1表示上一份文书，i>=1表示浏览的文书数量至少要有两份
                //{
                //    strBuilder.Append(@"<Skip operatercreater='0' /><p operatercreater='0' />");
                //}
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//文书内容
                //strBuilder.Append(ChildXml.InnerXml );//完整XML内容
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
            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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

                //提交暂存打印按钮控制
                TabItem item = e.NewTab;
                if (item != null)
                {
                    if (item.Text.Contains("浏览"))
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
        /// 得到单利文书的文书实例
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
        /// 得到单例文书
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
        /// 根据文书类型，获得当前文书的内容
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
                        else                                               //多实例文书，Patient_Doc类型
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
        /// 判断术后首次病程记录是否有子节点
        /// </summary>
        /// <param name="nodes">文书树集合</param>
        /// <returns>true 有子节点,false 没有子节点</returns>
        private bool isSurgeryLater(NodeCollection nodes)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == "136") //术后首次病程记录
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
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
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
                    //去掉相同的文书
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
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
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
                //                 " where a.patient_id='" + this.currentPatient.Id + "'  and  a.textkind_id!=135" +    //textkind_id=135术前讨论
                //                 " and a.textkind_id in (select id from t_text where parentid=" + textid + ") order by a.textkind_id";
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name,a.bed_no from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134术前讨论
                             " and textkind_id in (select id from t_text where parentid=" + textid + ")  and submitted='Y' order by doc_name";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        //arrs = new string[dt.Rows.Count,2];
                        //去掉相同的文书
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
        /// 获得当前节点病人文书
        /// </summary>
        /// <param name="nodes">当前节点下的文书内容</param>
        /// <returns>返回Patient_Doc</returns>
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
                    //去掉相同的文书
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
        /// 拼接xml文件
        /// </summary>
        /// <param name="Contents">xml内容</param>
        /// <param name="ucText">编辑器</param>
        /// <param name="flag">术后首次病程记录是否有子节点文书</param>
        private void SpiltXml(Patient_Doc[] patient_Docs, frmText ucText, bool flag)
        {
            XmlDocument TempXml = new XmlDocument();
            TempXml.PreserveWhitespace = true;
            StringBuilder strBuilder = new StringBuilder();
            #region 术后病程记录没有子节点拼接xml

            for (int i = 0; i < patient_Docs.Length; i++)
            {
                if (patient_Docs[i] == null)
                    continue;
                XmlDocument ChildXml = new XmlDocument();
                ChildXml.PreserveWhitespace = true;
                ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                if (patient_Docs[i].Textkind_id == 136 || patient_Docs[i].Textkind_id == 135 || patient_Docs[i].Textkind_id == 301)    //术后首次病程 术前小结 转入记录插入分页符 
                {
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //住院病程记录，跟在首次病程后面，要插入分页符
                //if ((
                //    patient_Docs[i].Textkind_id == 135
                //    ) && (i >= 1 && patient_Docs[i - 1].Textkind_id == 125))//i-1表示上一份文书，i>=1表示浏览的文书数量至少要有两份
                //{
                //    strBuilder.Append(@"<Skip operatercreater='0' /><p operatercreater='0' />");
                //}
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//文书内容
                //strBuilder.Append(ChildXml.InnerXml );//完整XML内容
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

            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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

        #region 全部文书树操作
        /// <summary>
        /// 1.文书树双击事件
        /// 2.当双击文书树的节点时触发
        /// 3.控制文书的打开权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            #region 所有文书节点
            if (advFinishDoc.SelectedNode != null)
            {
                if (advFinishDoc.SelectedNode.Name != "" && currentPatient != null)
                {
                    if (advFinishDoc.SelectedNode.ImageIndex != 15 && advFinishDoc.SelectedNode.ImageIndex != 20)//当前科室病人文书查看
                    {
                        AddDoc();
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 创建文书
        /// </summary>
        private void AddDoc()
        {

            /*
             * 创建文书实现思路：
             * 1.根据文书类型，病人住院号pid，得到文书id
             * 2.根据文书id 生成编辑器，或者用户控件
             */
            try
            {
                if (advFinishDoc.SelectedNode.Tag != null)
                {
                    int tid = 0;
                    /*
                     * tctlDoc的有tabItem，判断是否有重复的。
                     * tctlDoc的没有tabItem，就直接创建
                     */
                    if (advFinishDoc.SelectedNode.Tag.ToString().Contains("Class_Text"))
                    {
                        Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
                        string temptid = "";
                        if (text != null && text.Issimpleinstance == "0")//单例文书
                        {
                            tid = Convert.ToInt32(isExitRecord(text.Id, currentPatient.Id));//判断该类单例文书是否存在
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
                    //     * IsSameTabItem()判断tctlDoc是否有相同的文书类型(TabItem)
                    //     * IsSameBookDoc()判断tctlDoc是否有相同的文书(TabItem)
                    //     */
                    //    if (IsSameTabItem(tid.ToString()) == false)          //false表示里面没有相同的tabItem advFinishDoc.SelectedNode.Name
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
                //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                App.MsgErr("创建文书异常，原因：" + ex.Message);
            }
        }
        /// <summary>
        /// 创建新的tabItem
        /// </summary>
        /// <param name="tid">文书id</param>
        private void CreateTabItem(int tid)
        {
            //验证重复打开
            if (IsSameTabItem(tid.ToString()) == true)
            {
                return;
            }
            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            // 获得当前时间，精确到分钟
            // string time = string.Format("{0:g}", App.GetSystemTime());
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);
            //page.Click += new EventHandler(page_Click);

            //if (tid == 0)
            //{
            //    Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
            //    //新建文书，page页的Name用分号隔开，第一位：代表文书类型ID;第二位：文书类型;第三位：代表新建文书;第四位：是否单例文书
            //    page.Name = advFinishDoc.SelectedNode.Name + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
            //}
            //else //修改文书，page页的Name用分号隔开，第一位：文书ID；第二位：文书类型
            //{
            //    page.Name = tid + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString();
            //}
            if (advFinishDoc.SelectedNode == null)
            {
                App.Msg("没找到该文书！");
                return;
            }
            page.Text = advFinishDoc.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                if (advFinishDoc.SelectedNode.Nodes.Count == 0 ||
                    advFinishDoc.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    //文书类型
                    Class_Text select_text = advFinishDoc.SelectedNode.Tag as Class_Text;
                    //已写文书
                    Patient_Doc doc = GetDoc(select_text);
                    page.Tag = doc;
                    if (page.Tag != null)
                    {
                        string log_Tid = advFinishDoc.SelectedNode.Name;
                        isCustom = false;

                        //是否忽略空行
                        bool NeglectLine = IsNeglectLine(advFinishDoc.SelectedNode);
                        string textTitle = GetTextTitle(advFinishDoc.SelectedNode);
                        page.Tooltip = select_text.Textname.ToString();

                        //打开单例文书
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
                            //修改文书，Ishighersign是否需要上级医师审签
                            text.MyDoc.TextSuperiorSignature = ishighersign;
                            text.MyDoc.HaveTubebedSign = havedoctorsign;  //经治医师是否审签
                            text.MyDoc.HaveSuperiorSignature = havehighersign;//是否已经有过上级医生签名

                            //病案评分-------------------------------------------------------
                            if (this.OnComeFrmText != null)
                            {
                                //触发事件
                                OnComeFrmText(text);
                            }
                            //--------------------------------------------------------
                            
    

                            tmpxml.LoadXml(content);
                            if (advFinishDoc.SelectedNode.Text.Contains("日常病程记录"))
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
                        App.Msg("此病人床号异常！");
                    }
                }

            }
            //打开多例文书
            else if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {
                //设置文书标题
                string textTitle = GetTextTitle(advFinishDoc.SelectedNode);
                //是否可以忽略空行
                bool NeglectLine = IsNeglectLine(advFinishDoc.SelectedNode);


                Class_Text cText = advFinishDoc.SelectedNode.Parent.Tag as Class_Text;
                Patient_Doc pdoc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                page.Tag = pdoc;
                if (currentPatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    page.Tooltip = cText.Textname;

                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, currentPatient, true, true, Record_Time, Record_Content);
                    text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                    //if (OperateState != null && OperateState.Contains("补录"))
                    //{
                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //修改文书，Ishighersign是否需要上级医师审签
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //经治医师是否审签
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//是否已经有过上级医生签名
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //查房医生的userId

                    text.MyDoc.IgnoreLine = NeglectLine;
                    //锁定不是本科室的文书
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

                    //病案评分-------------------------------------------------------
                    if (this.OnComeFrmText != null)
                    {
                        //触发事件
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
                    //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                    //锁定文书
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
        /// 刷新文书操作的树
        /// 1.清空树节点
        /// 2.加载住院病程记录下的所有文书类型
        /// 3.把已写的文书加载到树上
        /// 4.移除住院病程记录下没有写文书的节点
        /// </summary>
        private void ReflashTrvBook()
        {
            advFinishDoc.Nodes.Clear();
            //AddZYNode(temptrvbook.Nodes);
            AddFinishNode();
            RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//展开所有文书节点

        }
        #endregion

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advFinishDoc.SelectedNode != null)
            {
                advFinishDoc_DoubleClick(advFinishDoc, e);
            }
            else
            {
                App.Msg("请选中文书节点！");
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReflashTrvBook();
        }

        #region 评分操作
        private void BindSource()
        {
            try
            {
                dgvSource.Rows.Clear();
                string strKouFenHuiZong = " select t.id,t.item 评分项目,t.item_score 分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,isxg,docId from t_deduct_score t where t.ITEM_PATIENTID='" + currentPatient.Id + "'";
                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvSource.Rows.Add();
                        dgvSource.Rows[i].Cells[0].Value = dt.Rows[i]["id"];
                        dgvSource.Rows[i].Cells[1].Value = dt.Rows[i]["评分项目"];
                        dgvSource.Rows[i].Cells[2].Value = dt.Rows[i]["分值"];
                        dgvSource.Rows[i].Cells[3].Value = dt.Rows[i]["扣分标准"];
                        dgvSource.Rows[i].Cells[4].Value = dt.Rows[i]["扣分理由"];
                        dgvSource.Rows[i].Cells[5].Value = dt.Rows[i]["medical_mark_id"];
                        dgvSource.Rows[i].Cells[6].Value = dt.Rows[i]["isxg"];
                        dgvSource.Rows[i].Cells[7].Value = dt.Rows[i]["docId"];
                    }
                    for (int j = 0; j < dgvSource.Rows.Count; j++)
                    {
                        string xg = dgvSource.Rows[j].Cells[6].Value.ToString();
                        //标记1 为已修改 变绿色
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

        private void 确认修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvSource.SelectedCells[0].Value.ToString();
                string sql = "update t_deduct_score set isxg ='1' where id ='" + id + "'";
                if (App.Ask("确定修改完成？"))
                {
                    //确定按钮的方法
                    int result = App.ExecuteSQL(sql);
                    if (result > 0)
                    {
                        App.Msg("修改成功！");
                        BindSource();
                    }
                }
                else
                {
                    //取消按钮的方法
                    return;
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// 双击缺陷打开对应文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSource_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSource.CurrentRow != null)
            {
                //获取缺陷对应的文书ID
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
        /// 设置文书树的选中节点
        /// </summary>
        /// <param name="advNodes">当前文书树</param>
        /// <param name="doc">缺陷对应的文书对象</param>
        private void SetSelectNode(NodeCollection advNodes, Patient_Doc doc)
        {
            for (int i = 0; i < advNodes.Count; i++)
            {
                //循环中的当前节点（Class_Text是单例文书）
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
                MessageBox.Show("修改成功！");
                BindSource();                
            }
            else
            {
                return;
            }
        }

        private void 刷新ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BindSource();
        }


    }
}
