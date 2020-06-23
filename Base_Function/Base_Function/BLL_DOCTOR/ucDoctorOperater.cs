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
        /// 当前病人对象。 
        /// </summary>
        public InPatientInfo currentPatient;
        private string Record_Time = null;
        private string Record_Content = null;
        private static Node CurrentNode = new Node();
        /// <summary>
        /// 授权操作权限
        /// </summary>
        public string OperateState;
        /// <summary>
        /// 是否是定制的文书
        /// </summary>
        private bool isCustom = false;
        public static bool flagmark = false;
        public static bool flagtq=false;
        /// <summary>
        /// 弹出时间选择窗体的返回值，点击确定返回True，点击取消返回false
        /// </summary>
        public static bool isFlagtrue = false;

        public delegate void DeleGetRecord(string time, string content);

        /// <summary>
        /// 多实例文书保存成功后，返回文书id
        /// </summary>
        private string book_Id = "";

        /// <summary>
        /// 浏览页面修改的文书id
        /// </summary>
        private string Update_Tid = null;

        /// <summary>
        /// 保存提交过的文书id
        /// </summary>
        private ArrayList save_TextId = new ArrayList();

        /// <summary>
        /// 术后病程记录是否有子节点
        /// </summary>
        bool isChildNode = false;


        /// <summary>
        /// 文书不可删除的原因
        /// </summary>
        string delBookReason = "";

        /// <summary>
        /// 模板提取
        /// </summary>
        ucTemplateListGet ucTemp;

        /// <summary>
        /// 浏览的文书集合
        /// </summary>
        private Node BrowseNodes;

        /// <summary>
        /// 是否直接点击浏览按钮显示 true 是 false 否
        /// </summary>
        private bool ClickShow = true;

        /// <summary>
        /// 患者所有文书
        /// </summary>
        private DataTable patientsDocs;

    

        /// <summary>
        /// 重新绑定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PageSelectChange(object sender, TabStripTabChangedEventArgs e)
        {
            tctlDoc_SelectedTabChanged(sender, e);
        }

        /// <summary>
        /// 模板双击操作
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

                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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

                                //过滤模板文件
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
            dockContainerItem_FinishDoc.Selected = true;;//左边默认选择'已写文书'
            DataInit.CurrentFrmText = null;
            currentPatient = patientInfo;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "文书操作";
            dockContainerItem2.Text = "模版提取";
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
            //获取当前病人的排序规则
            DataInit.GetPatientType(patientInfo.Id.ToString());
            ReflashTrvBook();//刷新文书树  
            advAllDoc.ExpandAll();
            barTemplate.Hide();
          

            if ((App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N") || currentPatient.PatientState == "借阅")
            {
                /*
                 * 如果非医生或护士账号登陆的话只能查看病人
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            //加载联想输入库
            InitAutoCompleteCustomSource(txtSearchAllText);
        }
        //public void IniMainToobar()
        //{

        //    //诊断编辑
        //    ButtonItem btnInsertDiosgin = new ButtonItem();
        //    btnInsertDiosgin.AutoCheckOnClick = true;
        //    btnInsertDiosgin.BeginGroup = false;
        //    btnInsertDiosgin.Image = global::Base_Function.Resource.诊断编辑;
        //    btnInsertDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        //    btnInsertDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
        //    btnInsertDiosgin.Name = "btnInsertDiosgin";
        //    btnInsertDiosgin.OptionGroup = "Color";
        //    btnInsertDiosgin.Text = "诊断编辑";
        //    btnInsertDiosgin.ThemeAware = true;
        //    btnInsertDiosgin.Tooltip = "诊断编辑";
        //    btnInsertDiosgin.Click += new System.EventHandler(this.btnInsertDiosgin_Click);

        //    //刷新诊断
        //    ButtonItem btnRefreshDiosgin = new ButtonItem();
        //    btnRefreshDiosgin.AutoCheckOnClick = true;
        //    btnRefreshDiosgin.BeginGroup = false;
        //    btnRefreshDiosgin.Image = global::Base_Function.Resource.刷新诊断;
        //    btnRefreshDiosgin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        //    btnRefreshDiosgin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
        //    btnRefreshDiosgin.Name = "btnRefreshDiosgin";
        //    btnRefreshDiosgin.OptionGroup = "Color";
        //    btnRefreshDiosgin.Text = "刷新诊断";
        //    btnRefreshDiosgin.ThemeAware = true;
        //    btnRefreshDiosgin.Tooltip = "刷新诊断";
        //    btnRefreshDiosgin.Click += new System.EventHandler(this.btnRefreshDiosgin_Click);
            
            //App.MainToolBar.Items.Clear();
            //App.MainToolBar.Items.Add(btnInsertDiosgin);//诊断编辑
            //App.MainToolBar.Items.Add(btnRefreshDiosgin);//刷新诊断
        //}
        /// <summary>
        /// 病人授权文书加载
        /// </summary>
        /// <param name="patientInfo">授权病人信息</param>
        /// <param name="State">授权病人</param>
        public ucDoctorOperater(InPatientInfo patientInfo, string operateState)
        {
            InitializeComponent();
            dockContainerItem_FinishDoc.Selected = true;//左边默认选择'已写文书'
            currentPatient = patientInfo;
            OperateState = operateState;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "已写文书";
            dockContainerItem2.Text = "模版提取";
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
            //获取当前病人的排序规则
            DataInit.GetPatientType(patientInfo.Id.ToString());
            ReflashTrvBook();//刷新文书树  
            advAllDoc.ExpandAll();
            barTemplate.Hide();

            if (App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N")
            {
                /*
                 * 如果非医生或护士账号登陆的话只能查看病人
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            if (operateState.Contains("创建"))
            {
                //advAllDoc.Visible = true;
                dockContainerItem_AllDoc.Enabled = true;
            }
            else if (operateState.Contains("补录"))
            {
                dockContainerItem_AllDoc.Enabled = true;
            }
            else
            {
                //advAllDoc.Visible = false;
                dockContainerItem_AllDoc.Enabled = false;
            }
            //加载联想输入库
            InitAutoCompleteCustomSource(txtSearchAllText);
        }

        public string mark_two = "0";

        public ucDoctorOperater(InPatientInfo patientInfo, string operateState, string strMark, string strMark_two)
        {
            InitializeComponent();
         
            //InitializeComponent();
            dockContainerItem_FinishDoc.Selected = true;//左边默认选择'已写文书'
            currentPatient = patientInfo;
            DataInit.CurrentPatient = patientInfo;
            dockContainerItem_FinishDoc.Text = "文书操作";

            dockContainerItem2.Text = "模版提取";
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
            ReflashTrvBook();//刷新文书树  
            advAllDoc.CollapseAll();
            //advAllDoc.ExpandAll();
            barTemplate.Hide();

            if ((App.UserAccount.CurrentSelectRole.Role_type != "D" && App.UserAccount.CurrentSelectRole.Role_type != "N") || currentPatient.PatientState == "借阅")
            {
                /*
                 * 如果非医生或护士账号登陆的话只能查看病人
                 */
                dockContainerItem_AllDoc.Enabled = false;
            }
            //加载联想输入库
            InitAutoCompleteCustomSource(txtSearchAllText);
            mark_two = strMark_two;
            
        }
        #region 已写文书操作

        /// <summary>
        /// 添加已完成文书
        /// </summary>
        public void AddFinishNode()
        {

            Bifrost.WebReference.Class_Table[] tablesqls = new Bifrost.WebReference.Class_Table[4];
            tablesqls[0] = new Bifrost.WebReference.Class_Table();

            tablesqls[0].Sql = "select id from t_text where parentid in (103,525)";    //所有归类于病程的小节点
            tablesqls[0].Tablename = "textbcs";

            tablesqls[1] = new Bifrost.WebReference.Class_Table();

            tablesqls[1].Sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,m.user_name, a.textname," +
                                         "a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid," +
                                         "a.israplacehightdoctor,a.OPERATEID,a.CHARGE_DOCTOR_ID,a.CHIEF_DOCTOR_ID,a.RESIDENT_DOCTOR_ID,a.israplacehightdoctor2,a.SECTION_NAME,operateid,charge_doctor_id,chief_doctor_id,a.bed_no,t.isproblem_name,t.isproblem_time,t.ISNEWPAGE  " +
                                         "from t_patients_doc a left join t_text t on a.textkind_id=t.id left join t_userinfo m on a.operateid = m.user_id" +
                                         " where a.patient_Id='" + currentPatient.Id + "' order by a.doc_name";  //获取病人的所有文书

            tablesqls[1].Tablename = "patientdocs";

            //tablesqls[2] = new Bifrost.WebReference.Class_Table();
            //tablesqls[2].Sql = "select * from cover_info t where t.patient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            //tablesqls[2].Tablename = "caseFirst";

            tablesqls[2] = new Bifrost.WebReference.Class_Table();
            tablesqls[2].Sql = "select * from t_care_doc t where t.inpatient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            tablesqls[2].Tablename = "careDoc";

            tablesqls[3] = new Bifrost.WebReference.Class_Table();
            tablesqls[3].Sql = "select * from t_temperature_info t where t.patient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            tablesqls[3].Tablename = "temperatureDoc";


            DataSet dstextbc = App.GetDataSet(tablesqls);
            //DataTable table_textnotbc = dstextbc.Tables["textnobc"];
            DataTable table_textbc = dstextbc.Tables["textbcs"];
            DataTable table_patientsdocs = dstextbc.Tables["patientdocs"];
            //DataTable table_caseFirst = dstextbc.Tables["caseFirst"];
            DataTable table_careDoc = dstextbc.Tables["careDoc"];
            DataTable table_temperatureDoc = dstextbc.Tables["temperatureDoc"];
            //DataTable table_textblc = dstextbc.Tables["textblc"];
            patientsDocs = table_patientsdocs; //患者全部文书



            //刷新所有树节点
            DataInit.ReflashBookTree(advFinishDoc, true);


            //隐藏相关节点（此操作在绑定具体已经写文书内容之前执行）
            DataInit.removeNode(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

            //////隐藏护理记录中定制文书
            DataInit.removeNodeCareDoc(advFinishDoc.Nodes, table_careDoc, table_temperatureDoc);

            ////所写文书的内容绑定到文书树上
            DataInit.getFinishedText(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

        }
        ///// <summary>
        ///// 添加已完成文书
        ///// </summary>
        //public void AddFinishNode()
        //{         
        //    Node node = null;
        //    if (currentPatient != null)
        //    {
        //        node = DataInit.SelectDoc(currentPatient.Id);//获得已写文书
        //    }
        //    //取得非住院病程记录文书父节点的ID，拼接字符串以逗号隔开
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

        //    tn_doctor.Text = "医生文书";
        //    tn_nurse.Text = "护士文书";
        //    tn_doctor.Image = global::Base_Function.Resource.住院记录;
        //    tn_nurse.Image = global::Base_Function.Resource.住院记录;

        //    if (docStr != "")
        //    {
        //        //医生文书
        //        DataInit.getDoctorFinishedText(ref tn_doctor, docStr);
        //    }
        //    //护士
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
        /// 隐藏没有文书类型
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
                                        if (TempNode.ImageIndex != 16)//== 17)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
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
        /// 把文书内容节点插入到具体的文书下
        /// </summary>
        /// <param name="nodes">文书类别</param>
        /// <param name="node">文书内容</param>
        public void GetPatientDoc(NodeCollection nodes, Node node, DataTable dtbc)
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
                    if (text.Id == 103)
                    {
                        //病程记录处理
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

                                if (doc.Submitted == "N")//暂存显示为蓝色
                                {
                                    node.Style = elementStyleBlue;
                                    //node.Text += "(暂存)";
                                }
                                else if (doc.Havedoctorsign == "N")//N表示管床医生未签字的文书，显示为红色
                                {
                                    //node.Style = elementStyleRed;
                                    //node.Text += "(缺管床医生签名)";
                                }
                                else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                                {
                                    if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                    {
                                        //node.Style = elementStyleOrange;
                                        //node.Text += "(缺上级医师签名)";
                                    }
                                }
                                TempNode.Nodes.Add((Node)node.DeepCopy());
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (text.Issimpleinstance == "1")   //多例文书
                        {
                            if (doc.Textkind_id == text.Id)//|| text.Id == 103) //如果当前文书和树节点的文书id相同，就把该文书添加树节点的下面
                            {

                                if (doc.Submitted == "N")//暂存显示为蓝色
                                {
                                    node.Style = elementStyleBlue;
                                    //node.Text += "(暂存)";
                                }
                                else if (doc.Havedoctorsign == "N")//N表示管床医生未签字的文书，显示为红色
                                {
                                    //node.Style = elementStyleRed;
                                    //node.Text += "(缺管床医生签名)";
                                }
                                else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                                {
                                    if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                    {
                                        //node.Style = elementStyleOrange;
                                        //node.Text += "(缺上级医师签名)";
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
                                if (doc.Textkind_id == text.Id)// || text.Id == 103)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
                                {
                                    //TempNode.SelectedImageIndex = 16;
                                    TempNode.ImageIndex = 16;
                                    if (doc.Submitted == "N")//暂存显示为蓝色
                                    {
                                        TempNode.Style = elementStyleBlue;
                                        //TempNode.Text += "(暂存)";
                                    }
                                    else if (doc.Havedoctorsign == "N")//N表示管床医生未签字的文书，显示为红色
                                    {
                                        //TempNode.Style = elementStyleRed;
                                        //TempNode.Text += "(缺管床医生签名)";
                                    }
                                    else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                                    {
                                        if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                        {
                                            //TempNode.Style = elementStyleOrange;
                                            //TempNode.Text += "(缺上级医师签名)";
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
        /// 过滤文书
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
                            bool isDisplay = false;//是否显示文书
                            string[] sections = text.Sid.Split(',');
                            for (int j = 0; j < sections.Length; j++)
                            {
                                if (sections[j] == currentSectionId)
                                {
                                    isDisplay = true;
                                }
                            }
                            //如果SID不等于0并且SID不等于当前登录医生的科室ID，则清除该文书
                            if (!isDisplay && text.Sid != "0")
                            {
                                string sql = "select * from t_patients_doc where textkind_id = " + text.Id + " and patient_id=" + currentPatient.Id;
                                DataSet ds = App.GetDataSet(sql);
                                if (ds != null)
                                {
                                    DataTable dt = ds.Tables[0];
                                    if (dt.Rows.Count == 0)     //非本科室文书，如果已经有实例文书存在的不删除
                                    {
                                        tempNode.Remove();
                                        if (Parent != null)//移除节点后由于所有节点的索引发生变化，所以要把该节点的父节点从新遍历
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
        /// 双击的是否是符合规定的文书
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
        /// 当前选中的节点，是否再tctlDoc.Tabs集合里面已经存在，存在true,否则false
        /// </summary>
        /// <param name="tid">文书的id</param>
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
                                App.Msg("已经存在相同的文书！");
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 判断该类单例文书是否已经存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "' ";
            //union select tid from t_care_doc  where textkind_id =" + id + " and inpatient_id='" + patient_id + "'
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

        /// <summary>
        /// 根据文书类型id，病人住院号pid，得到文书id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patient_id">病人id</param>
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
                        if (!item.Text.Contains("浏览"))
                        {
                            if (!IsCommit(item.Name))
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
                                                //tctlDoc.AutoCloseTabs = true;
                                                //关闭文书，禁用下列按钮 ,
                                                //Remove操作会触发SelectedChecked事件，设置对选中文书的操作权限,在Remove之前执行按钮禁用操作
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
                                    //if (item.Text.Contains("护理记录单"))
                                    //{
                                    //    DevComponents.DotNetBar.TabControlPanel tab2 = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                                    //    MUcToolsControl mutc = tab2.Controls[0] as MUcToolsControl;
                                    //    if (mutc.MyDocument.Modifyed) //修改过文书，显示提示
                                    //    {
                                    //        if (App.Ask("该份护理记录单没有保存，是否关闭？"))
                                    //        {
                                    //            tctlDoc.Tabs.Remove(item);
                                    //            if (!item.Text.Contains("锁定"))
                                    //            {
                                    //                IsLockBook("t_care_doc", currentPatient.Id, "0", App.UserAccount.UserInfo.User_id);
                                    //                UnlockNurseRecord(App.UserAccount.UserInfo.User_id);
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        tctlDoc.Tabs.Remove(item);
                                    //        if (!item.Text.Contains("锁定"))
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
                                    App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                                    App.SetToolButtonByUser("btnInsertDiosgin", false);
                                    App.SetToolButtonByUser("btnRefreshDiosgin", false);
                                }
                            }
                        }
                        else
                        {
                            //关闭文书，禁用下列按钮 ,
                            //Remove操作会触发SelectedChecked事件，设置对选中文书的操作权限,在Remove之前执行按钮禁用操作
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
        /// 判断文书是否提交过
        /// </summary>
        /// <param name="textName">文书的id</param>
        /// <returns>true提交,false未提交</returns>
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
                                textTitle = "病程记录";
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
                        if (node.Parent.Name == "103" || (node.Name == "103" && node.Text == "住院病程记录"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134")//术前小结
                            {
                                textTitle = "手术前小结";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "病程记录";
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
                                textTitle = "病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
                            }
                        }
                        else
                        {
                            textTitle = text.Textname;
                        }
                        if (text.Issimpleinstance == "0")
                        {

                            if (node.Text.Contains("(缺管床医生签名)"))
                            {
                                textTitle = textTitle.Replace("(缺管床医生签名)", "");
                            }
                            else if (node.Text.Contains("(缺上级医师签名)"))
                            {
                                textTitle = textTitle.Replace("(缺上级医师签名)", "");
                            }
                        }
                    }
                }

                if (textTitle == "第N次入院记录")
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
        ///  判断文书下面是否有相同名称的文书。
        /// </summary>
        /// <returns></returns>
        private bool IsSameBookDoc()
        {
            bool flag = false;
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            if (this.currentPatient != null)
            {
                Node node = DataInit.SelectDoc(currentPatient.Id, NowTree.SelectedNode.Name);
                //当前创建文书的名称
                string new_TextName = Record_Time + "   " + Record_Content;
                foreach (Node childNode in node.Nodes)
                {
                    Patient_Doc pdoc = childNode.Tag as Patient_Doc;
                    //已经存在该类文书的名称
                    string old_TextName = pdoc.Docname;
                    //if (new_TextName.Equals(old_TextName))
                    if (old_TextName.Contains(Record_Time))
                    {
                        flag = true;
                        App.Msg("已经存在相同的文书！");
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 插入诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertDiosgin_Click(object sender, EventArgs e)
        {
            try
            {

                    //每次点击“诊断编辑”按钮时，刷新患者最新三级医师。
                    currentPatient = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString());
                    using (BLL_DIAGNOSE.frmDiagnoseSimple fds = new BLL_DIAGNOSE.frmDiagnoseSimple(currentPatient))
                    {
                        fds.ShowDialog();
                        RefreshTabDocDiagnose(2);//只刷新未提交文书
                    }

                //}
            }
            catch (System.Exception ex)
            {
                //App.MsgWaring("该按钮参数未设置或功能尚未启用！");
            }
        }

        /// <summary>
        /// 刷新诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshDiosgin_Click(object sender, EventArgs e)
        {
            try
            {
                //还需要记录谁操作
                RefreshTabDocDiagnose(2);
            }
            catch (System.Exception ex)
            {
                //App.MsgWaring("该按钮参数未设置或功能尚未启用！");
            }
        }

        //浏览页面的修改文书
        void MyDoc_OnBackTextId(object sender, BackEvenHandle e)
        {
            if (e.Style == 1)
            {
                if (e.Submit)
                {
                    //文书提交成功后，修改当前打开的文书tab.Name属性中的值
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
                            if (i == 2)//第三位是文书的ID，0表示新建，改成当前的文书id
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
                    if (e.User.TextKind_id == 119 ||    //入院记录
                        e.User.TextKind_id == 120 ||    //24小时内入出院记录
                        e.User.TextKind_id == 121 ||    //24小时内入院死亡记录
                        e.User.TextKind_id == 122 ||    //再次（多次）入院记录
                        e.User.TextKind_id == 123)      //其他专科入院记录
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
                if (App.UserAccount.CurrentSelectRole.Role_type != "D")     //医生站
                {
                    App.Msg("提示: 只有医生才能修改!");
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
                bool flag = false;  //当前帐号对该份文书是否有书写的权限
                Class_Text text = advAllDoc.SelectedNode.Tag as Class_Text;
                ArrayList list = App.Get_Text_Button_Rights(text.Id, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                for (int i = 0; i < list.Count; i++)
                {
                    string Button_Write = list[i] as string;
                    //App.Text_Rights_Set(Convert.ToInt32(e.Para),Convert.ToInt32(currentPatient.Sick_Doctor_Id),currentPatient.Sick_Group_Id);
                    if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                    {
                        //创建文书
                        Rethreee_CreateTab(e.Para);
                        flag = true;
                        break;
                    }
                }
                Update_Tid = e.Para;
                if (!flag)
                    App.Msg("您还没有书写该份文书的权限！");
            }
        }

        /// <summary>
        /// 获取浏览操作时需要修改选中的节点
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
        /// 修改文书
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
        /// 设置文书树的选中节点
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
        /// <summary>
        /// 文书提交后刷新
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

                if (name.Contains("提交"))
                {
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    int tid = 0;
                    string sql = "";
                    //("Patient_Doc"))//多例文书

                    //("Class_Text"))//单例文书

                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (tempEditor != null)
                    {
                        sql = "select submitted from t_patients_doc where TID='" + tempEditor.MyDoc.Us.Tid + "' and patient_id='" + tempEditor.MyDoc.Us.InpatientInfo.Id + "'";
                        string isSubmitted = Convert.ToString(App.ReadSqlVal(sql, 0, "submitted"));
                        if (isSubmitted == "Y")
                        {//已经提交
                            //XmlDocument tempxmldoc = new XmlDocument();
                            //tempxmldoc.PreserveWhitespace = true;
                            //CurrentFrmText.MyDoc.ToXML(tempxmldoc.DocumentElement);
                            ////DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                            //tempEditor.MyDoc.FromXML(tempxmldoc.DocumentElement);
                            //tempEditor.MyDoc.ContentChanged();
                            //App.SetToolButtonByUser("tsbtnCommit", true);//提交

                            //try
                            //{
                            //    //更新质控提醒
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
                        {//未提交或暂存
                            App.SetToolButtonByUser("tsbtnTempSave", true);//暂存
                        }
                    }
                }
            }
            ReflashTrvBook();
            //刷新节点
            SetSelectNode(advFinishDoc.Nodes);
            SelectedNodeByTid(advFinishDoc.Nodes, Update_Tid);
            //展开当前选中的节点
            ExpendTree(advFinishDoc.SelectedNode);
        }

     
        /// <summary>
        /// 选择文书事件
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
                    

                    if (tempEditor != null && currentPatient.PatientState != "借阅")
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
                        //App.SetToolButtonByUser("tsbtnSmallTemplateSave", true);  //保存小模版
                        //App.SetToolButtonByUser("ttsbtnPrint", false);
                        App.SetToolButtonByUser("tsbtnTempSave", false);  //暂存
                        App.SetToolButtonByUser("tsbtnCommit", false);    //提交
                        App.SetToolButtonByUser("tsbtnTemplateSave", true);//保存模版
                        App.SetToolButtonByUser("btnInsertDiosgin", false);
                        App.SetToolButtonByUser("btnRefreshDiosgin", false);
                        //if (tctlDoc.SelectedPanel.TabItem.Text.Contains("浏览"))
                        //{
                        //    App.SetToolButtonByUser("ttsbtnPrint", true);//打印
                        //}
                        //else
                        //{
                        string sql = "select submitted from t_patients_doc where TID='" + tempEditor.MyDoc.Us.Tid + "' and patient_id='" + tempEditor.MyDoc.Us.InpatientInfo.Id + "'";
                        string isSubmitted = Convert.ToString(App.ReadSqlVal(sql, 0, "submitted"));
                        if (isSubmitted == "Y")
                        {//已经提交
                            App.SetToolButtonByUser("tsbtnCommit", true);//提交
                            App.SetToolButtonByUser("btnInsertDiosgin", true);
                            App.SetToolButtonByUser("btnRefreshDiosgin", true);

                            if (App.UserAccount.CurrentSelectRole.Role_name == "规培医师" && !DataInit.ISPrintGPYS(tempEditor.MyDoc.Us.Tid,""))
                            {//"规培医师"书写的文书不可自行打印，只有上级医生签名后方可打印
                                App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                                //App.SetToolButtonByUser("btnInsertDiosgin", false);
                                //App.SetToolButtonByUser("btnRefreshDiosgin", false);
                            }
                            else
                            {
                                App.SetToolButtonByUser("ttsbtnPrint", true);//打印
                                App.SetToolButtonByUser("ttsbtnPrintContinue", true);//续打
                                //App.SetToolButtonByUser("btnInsertDiosgin", true);
                                //App.SetToolButtonByUser("btnRefreshDiosgin", true);
                            }
                        }
                        //else if (isSubmitted == "N")
                        //{//已经暂存
                        //    //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);//保存小模版
                        //    App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                        //    App.SetToolButtonByUser("tsbtnTempSave", false);//暂存
                        //    App.SetToolButtonByUser("tsbtnCommit", true);//提交
                        //}
                        else
                        {//未提交或暂存
                            App.SetToolButtonByUser("tsbtnTempSave", true);//暂存
                            App.SetToolButtonByUser("tsbtnCommit", true);//提交
                            App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                            App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                            App.SetToolButtonByUser("btnInsertDiosgin", true);
                            App.SetToolButtonByUser("btnRefreshDiosgin", true);
                        }
                        //}
                        //App.SetToolButtonByUser("ttsbtnPrint", true);//打印
                        //App.SetToolButtonByUser("ttsbtnPrintContinue",true);
                        ucTemp.Reflesh(tempEditor.MyDoc.Us.TextKind_id.ToString());
                        DataInit.SetToolEvent(tempEditor);
                        //IniMainToobar();
                        App.A_RefleshTreeBook = null;
                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                        if (!tctlDoc.SelectedTab.Text.Contains("浏览"))
                        {
                            barTemplate.AutoHide = true;
                        }
                        else
                        {
                            App.SetToolButtonByUser("tsbtnCommit", false);    //提交
                            App.SetToolButtonByUser("tsbtnTempSave", false);//暂存
                            App.SetToolButtonByUser("btnInsertDiosgin", false);
                            App.SetToolButtonByUser("btnRefreshDiosgin", false);
                            barTemplate.Hide(); ;
                            if (!ClickShow)
                            {
                                /*
                               *内容刷新
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
                        App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
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
                    App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                    App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);  //保存小模版
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
                App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                App.SetToolButtonByUser("btnInsertDiosgin", false);
                App.SetToolButtonByUser("btnRefreshDiosgin", false);

            }

        }

        private void ctmnspDelete_Opening(object sender, CancelEventArgs e)
        {
            //文书树右键菜单可见控制
            删除ToolStripMenuItem.Visible = false;
            tlspmnitBrowse.Visible = false;
            代主治查房ToolStripMenuItem.Visible = false;
            代主任查房ToolStripMenuItem.Visible = false;
            取消代上级查房ToolStripMenuItem.Visible = false;

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
                            删除ToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_type != temp.Right_range &&
                               temp.Right_range != "A")
                            {
                                删除ToolStripMenuItem.Visible = false;
                            }
                            else
                            {
                                if (NowTree.SelectedNode.Nodes.Count == 0)
                                {
                                    tlspmnitBrowse.Visible = true;
                                    删除ToolStripMenuItem.Visible = true;
                                }
                            }
                        }

                        Patient_Doc doc = GetDoc(temp);
                        if (doc != null && temp.Issimpleinstance=="0")//单例才进入显示
                        {
                            if ((doc.Createid == App.UserAccount.UserInfo.User_id || doc.Textkind_id == 2172 || doc.Textkind_id == 2173) && (OperateState == null || OperateState.Contains("创建")))
                            //'电脑血糖监测记录单','PICC护理记录单')
                            {
                                删除ToolStripMenuItem.Visible = true;
                            }
                            else
                            {
                                删除ToolStripMenuItem.Visible = false;
                            }
                        }


                    }
                    else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                    {
                        Class_Text temp = (Class_Text)NowTree.SelectedNode.Parent.Tag;
                        if (App.UserAccount.CurrentSelectRole.Role_type == temp.Right_range ||
                               temp.Right_range == "A")
                        {
                            删除ToolStripMenuItem.Visible = true;
                            tlspmnitBrowse.Visible = true;
                        }
                        else
                        {
                            tlspmnitBrowse.Visible = true;
                        }
                        Patient_Doc doc = NowTree.SelectedNode.Tag as Patient_Doc;
                        if ((doc.Createid == App.UserAccount.UserInfo.User_id || doc.Textkind_id == 2172 || doc.Textkind_id == 2173) && (OperateState == null || OperateState.Contains("创建")))
                        //'电脑血糖监测记录单','PICC护理记录单'
                        {
                            删除ToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            删除ToolStripMenuItem.Visible = false;
                        }
                    }
                }
            }

            if (DataInit.boolAgree)
            {
                删除ToolStripMenuItem.Visible = false;
                修改标题ToolStripMenuItem.Visible = false;
                代主治查房ToolStripMenuItem.Visible = false;
                代主任查房ToolStripMenuItem.Visible = false;
                取消代上级查房ToolStripMenuItem.Visible = false;
                // 新增-----------------------------------------------------
                if (NowTree.SelectedNode.Text.Trim().Equals("住院志") || NowTree.SelectedNode.Text.Trim().Equals("住院护理记录（护理操作记录）"))
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
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


                    //文书删除权限，有上级医师签字，管床不能删，有管床医师签字，实习生研究生不能删
                    Patient_Doc doc = advFinishDoc.SelectedNode.Tag as Patient_Doc;
                    bool isDelete = false;
                    if (App.UserAccount.UserInfo.User_id != doc.Createid && doc.Textkind_id != 2172 && doc.Textkind_id != 2173)
                    //'电脑血糖监测记录单','PICC护理记录单')
                    {//删除权限判断当前用户是否是创建人
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
                            delBookReason = "只有管床医生或本人可以删除暂存文书！";
                        }
                    }
                    if (isDelete) //只有本人或管床医生才能删除文书
                    {

                        if (advFinishDoc.SelectedNode.Nodes.Count == 0)
                        {
                            if (App.Ask("确认要删除吗？"))
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
                                //插入到文书历史表
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
                            App.Msg("只能删除具体文书！");
                        }
                    }
                    else
                    {
                        App.Msg(delBookReason);
                        return;
                    }
                }
                else if (advFinishDoc.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))//单例文书删除
                {
                    Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;

                    if (text != null)
                    {
                        Patient_Doc doc = GetDoc(text);
                        if (doc == null)
                        {
                            App.Msg("该节点没有文书！");
                            return;
                        }
                        string User_id = App.UserAccount.UserInfo.User_id;
                        string book_Id = advFinishDoc.SelectedNode.Name;

                        //文书删除权限，有上级医师签字，管床不能删，有管床医师签字，实习生研究生不能删

                        if (App.UserAccount.UserInfo.User_id != doc.Createid && doc.Textkind_id != 2172 && doc.Textkind_id != 2173)
                        //'电脑血糖监测记录单','PICC护理记录单')
                        {//删除权限判断当前用户是否是创建人
                            return;
                        }
                        bool isDelete = ISDelByXmlNode(doc.Id);
                        if (isDelete)
                        {
                            if (App.Ask("确定要删除吗?"))
                            {

                                //patient_doc
                                string sql_Patient = "delete t_patients_doc where tid = " + doc.Id + "";
                                //quelsty
                                string sql_Quality = "delete t_quality_text where tid = " + doc.Id + "";
                                //插入到文书历史表
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
                App.Msg("请选中节点！");
            }

            int patient_id = currentPatient.Id;
            //记录系统日志
            LogHelper.SystemLog("删除", log_Tid, currentPatient.PId, patient_id);
        }

        /// <summary>
        /// 根据文书节点属性判断是否可以删除文书
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

            string sjysqm = "";//上级医师签名
            string gcysqm = "";//管床医生签名
            string ptysqm = "";//普通医生签名
            /* 1.先判断上级医生是否签名，有的话当前操作人员是否是上级医生，不是的话直接返回“上级医师已签字，无法删除！”
             * 2.上级医生没有签名，判断当前操作人员是否是上级医生，是的话可以操作
             * 3.判断管床医生是否签名，有的话，当前认识是否是管床医生，是的话可以操作
             * 4.没有管床医生，当前操作人员是否是管床医生，是的话能操作，不是的话返回不能
             * 5.没有上级医生和管床医生，普通医生有的时候判断是否是当前是人是的话能操作不是的话不能操作，没有的话能操作
             */
            //找到上级医生签名，管床医师签名，普通医师签名
            foreach (XmlNode var in sign)
            {
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "上级医师签名")
                {
                    foreach (XmlNode node in var.ChildNodes)
                    {
                        sjysqm += node.InnerText;
                    }
                }
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "管床医师签名")
                {
                    foreach (XmlNode node in var.ChildNodes)
                    {
                        gcysqm += node.InnerText;
                    }
                }
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "普通医师签名")
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
                        ishighersign = dt.Rows[0]["ishighersign"].ToString();//是否需要上级医生签名
                        havehighersign = dt.Rows[0]["havehighersign"].ToString();//是否有上级医生签名
                        havedoctorsign = dt.Rows[0]["havedoctorsign"].ToString();//是否有管床医生签名
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
            if (sjysqm.Trim().Length > 0 && sjysqm.Contains("："))
            {
                sjysqm = sjysqm.Split('：')[1].Trim();
            }
            else
            {
                sjysqm = sjysqm.Trim();
            }

            if (gcysqm.Trim().Length > 0 && gcysqm.Contains("："))
            {
                gcysqm = gcysqm.Split('：')[1].Trim();
            }
            else
            {
                gcysqm = gcysqm.Trim();
            }
            //gcysqm = gcysqm.Trim();
            if (ptysqm.Trim().Length > 0 && ptysqm.Contains("："))
            {
                ptysqm = ptysqm.Split('：')[1].Trim();
            }
            else
            {
                ptysqm = ptysqm.Trim();
            }
            //ptysqm = ptysqm.Trim();

            if (sjysqm != "" && sjysqm != App.UserAccount.UserInfo.User_name)
            {
                delBookReason = "上级医师已签字，无法删除！";
                return false;

            }
            else
            {
                //判断管床医师是否签名
                if (gcysqm != "")
                {
                    if (gcysqm == App.UserAccount.UserInfo.User_name)
                    {
                        return true;
                    }
                    else
                    {
                        delBookReason = "管床医师已签字，无法删除！";
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
                        delBookReason = "权限不足，无法删除！";
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
                            delBookReason = "上级医师已签字，无法删除！";
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
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "管床医师签名")
                {
                    if (var.Attributes["id"] != null)
                    {
                        string userId = var.Attributes["id"].Value;
                        if (userId != "" )
                        {
                            if (userId == App.UserAccount.UserInfo.User_id)
                                return true;
                            else
                                delBookReason = "管床医师已签字，无法删除！";
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
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "普通医师签名")
                {
                    if (var.Attributes["id"] != null)
                    {
                        string userId = var.Attributes["id"].Value;
                        if (userId == "")
                        {
                            delBookReason = "只有管床可以删除文书！";
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

                                  delBookReason = "你不是文书最高签名者，无法删除!";
                                  return false;
                              }
                            }
                            break;
                        }
                    }
                }
            }*/
            #endregion
            delBookReason = "权限不足，无法删除！";
            return false;
        }

        /// <summary>
        /// 删除树节点，如果tablContrain容器中也有对应的文书，则删除
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

        private void AddTlspMnit_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                advAllDoc_DoubleClick(NowTree, e);
            }
            else
            {
                App.Msg("请选中文书节点！");
            }

        }

        //浏览
        private void tlspmnitBrowse_Click(object sender, EventArgs e)
        {
            /*
             * 浏览实现思路：
             * 1.查出当前节点下所有节点的文书内容对应的xml代码
             * 2.拼接查出每份xml文件的body下面的xml代码，并生成新的xml
             * 3.读出新的xml文本，设置只读。
             */
            //try
            //{
                ucDoctorOperater.flagmark = true;
            if (mark_two == "1")
            {
                App.Msg("请双击进行浏览！");
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
                bool isExist = false; //是否只有定制文书
                if (NowTree.SelectedNode.Nodes.Count > 0)
                {
                    foreach (Node node in NowTree.SelectedNode.Nodes)
                    {
                        if (account_Type == "N")
                        {
                            //定制文书
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
                        //定制文书
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
                #region 普通文书浏览
                //string[,] Contents = GetContentByType(trvBookOprate.SelectedNode);

                Patient_Doc[] patient_Docs = GetContentByType(NowTree.SelectedNode); //此代码暂时不用

                //记录浏览的节点
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

                    //else if (doc.Havedoctorsign == "N")//N表示管床医生未签字的文书，显示为红色
                    //        {
                    //            node.Style = elementStyleRed;
                    //            node.Text += "(缺管床医生签名)";
                    //        }
                    //        else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                    //        {
                    //            if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                    //            {
                    //                node.Style = elementStyleOrange;
                    //                node.Text += "(缺上级医师签名)";
                    //            }
                    //        }

                    ////暂存文书只能由本人操作
                    //Patient_Doc doc = patient_Docs[0];
                    //if (doc.Submitted == "N" && doc.Createid != App.UserAccount.UserInfo.User_id)
                    //{
                    //    App.Msg("该文书是暂存文书，只能由本人浏览！");
                    //    return;
                    //}
                    DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                    tabctpnDoc.AutoScroll = true;
                    DevComponents.DotNetBar.TabItem pageDoc = new DevComponents.DotNetBar.TabItem();



                    pageDoc.Name = NowTree.SelectedNode.Name;
                    pageDoc.Text = NowTree.SelectedNode.Text + " 浏览";
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
                            //单份文书修改痕迹修改
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
                        App.Msg("该节点暂时没有文书！");
                    }
                }
                else
                {
                    App.Msg("该节点暂时没有文书！");
                }
            }
            else
            {
                App.Msg("没有选中节点！");
            }
            int patient_Id = currentPatient.Id;
            //记录系统操作日志,
            //LogHelper.SystemLog("", result, "文书浏览", tid, currentPatient.PId, patient_Id);
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
            //    App.MsgErr("该节点并不是有效的文书浏览节点！");
            //}
        }


        /// <summary>
        /// 隐藏字体和字体大小按钮
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
        /// 浏览时
        /// </summary>
        /// <param name="list">权限集合</param>
        /// <param name="node">当前选中的节点</param>
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
                        //血糖检测单
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
                        //产程图
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
                             * 护士操作
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
                                              * 医生站
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
                        if (currentPatient.Section_Name.Contains("儿科") )//|| currentPatient.Section_Name.Contains("心内二"))
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
                         * 护士操作
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
                            page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        }
                        else
                        {
                            if (islock)
                            {
                                string strAsk;
                                if (App.UserAccount.UserInfo.User_name == open_name)
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "打开或者上次没有正常关闭，你确定继续操作吗？，";
                                    if (App.Ask(strAsk))
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "", App.UserAccount.UserInfo.User_id);
                                    }
                                    else
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }

                                }
                                else
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "由工号：" + open_num + "姓名：" + open_name + "已经打开，多人操作可能造成内容错误，你确定打开吗？";
                                    if (!App.Ask(strAsk))
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }
                                    else
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "", App.UserAccount.UserInfo.User_id);
                                    }
                                }
                            }
                            else
                            {
                                if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
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
                        ////体温单
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
                        //新生儿体温单
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
                        //重新过去最新信息
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

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
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
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnView.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnView.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
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
        /// 医生账号登陆只能浏览护士文书的打印界面
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
            page.Text = node.Text + " " + " (" + inpatient.Sick_Bed_Name + " 床)";
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
                        //血糖检测单

                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnDoc.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //产程图

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
                             * 护士操作
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
                                              * 医生站
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
                        int Section_Id = 0;//病区id
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != null &&
                            App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                            Section_Id = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);

                        string Role_type = App.UserAccount.CurrentSelectRole.Role_type;//用户类型
                        if ((Role_type != "N" && Role_type != "D") || currentPatient.PatientState == "借阅" || (OperateState != null && OperateState.Contains("查看") && !OperateState.Contains("补录")))
                        {
                            Section_Id = Convert.ToInt32(inpatient.Section_Id);
                        }
                        MUcToolsControl ucNurseRecord;
                        if (node.Text.Contains("新生儿科"))
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name), true);
                        else
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name));
                        /*
                         * 护士操作
                         */
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);

                        ucNurseRecord.MyDocument.ClearTempInput();
                        ucNurseRecord.SetToolsEnable(false);//隐藏那个菜单
                        //Panel bp = ucNurseRecord.GetButtonPanel();
                        //foreach (Control c in bp.Controls)
                        //{//遍历控件,设置属性
                        //    if (c is Button)
                        //    {
                        //        Button b = (Button)c;
                        //        if ((b.Text == "打印" || b.Text == "续打") && currentPatient.PatientState != "借阅")
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
                        //if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
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
                        // * 护士操作
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
                        //    page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        //}
                        //else
                        //{
                        //    if (islock)
                        //    {
                        //        string strAsk;
                        //        if (App.UserAccount.UserInfo.User_name == open_name)
                        //        {
                        //            strAsk = page.Text + "这个文书已经在" + ip + "打开或者上次没有正常关闭，你确定继续操作吗？，";
                        //            if (App.Ask(strAsk))
                        //            {
                        //                IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //            }
                        //            else
                        //            {
                        //                ucNurseRecord.MyDocument.ClearTempInput();
                        //                ucNurseRecord.SetToolsEnable(false);
                        //                page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        //            }

                        //        }
                        //        else
                        //        {
                        //            strAsk = page.Text + "这个文书已经在" + ip + "由工号：" + open_num + "姓名：" + open_name + "已经打开，多人操作可能造成内容错误，你确定打开吗？";
                        //            if (!App.Ask(strAsk))
                        //            {
                        //                ucNurseRecord.MyDocument.ClearTempInput();
                        //                ucNurseRecord.SetToolsEnable(false);
                        //                page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        //            }
                        //            else
                        //            {
                        //                IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
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
                        //体温单
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
                        //新生儿体温单
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
                        //重新过去最新信息
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

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
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
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {

                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {

                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
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
                        //App.Msg("定制文书没有确定对应的功能模块,请于管理员联系,在文书类型管理中进行设置！");

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
                    Class_Text tempnode = (Class_Text)node.Tag;
                    if (tempnode.Id == 103)
                    {
                        //病程记录                  
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
        /// 病程浏览处理
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
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
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
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name,c.ISNEWPAGE,Bed_no from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134术前讨论
                             " and parentid=" + textid + "  and submitted='Y' order by doc_name";
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
        /// 拼接xml文件
        /// </summary>
        /// <param name="Contents">xml内容</param>
        /// <param name="ucText">编辑器</param>
        /// <param name="flag">术后首次病程记录是否有子节点文书</param>
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
            #region 术后病程记录没有子节点拼接xml
            //先清理
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
                    //表示配置中需要进行分页
                    strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                }
                //sickarea = patient_Docs[i].Section_name;
                sickarea = App.ReadSqlVal("select sick_area_name from T_PATIENTS_DOC where TID=" + patient_Docs[i].Id + "", 0, "sick_area_name");
                strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name +
                    "' bed_no='" + patient_Docs[i].Bed + "' sick_area='" + sickarea + "'/>");
                strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//文书内容
            }

            #endregion

            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");






            ucText.MyDoc.ToXML(tempxmldoc.DocumentElement);





            #region 浏览文书参数设置
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

            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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




            //'电脑血糖监测记录单','PICC护理记录单','产科(新生儿)护理记录单',新生儿经皮胆红素观察表',
            //'缩宫素滴注观察记录单'
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
            //    App.MsgErr("文书读取失败！原因:"+ex.Message);
            //}
        }

        //修改标题
        private void 修改标题ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    App.Msg("修改成功！");
                }
            }
        }

        private void 代主治查房ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (NowTree.SelectedNode != null)
            {
                //验证权限
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
                            //刷新节点
                            SetSelectNode(NowTree.Nodes);
                            //展开当前选中的节点
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("修改成功！");
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

        private void 代主任查房ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (NowTree.SelectedNode != null)
            {
                //验证权限
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
                            //刷新节点
                            SetSelectNode(NowTree.Nodes);
                            //展开当前选中的节点
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("修改成功！");
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

        private void 取消代上级查房ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                string msgerr = App.Get_Text_Buttns_Set_rights(currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode as object, currentPatient, 0);

                if (msgerr == "")
                {
                    string docName = "";
                    if (NowTree.SelectedNode.Text.Contains("△") || NowTree.SelectedNode.Text.Contains("*"))
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
                            //刷新节点
                            SetSelectNode(NowTree.Nodes);
                            //展开当前选中的节点
                            ExpendTree(NowTree.SelectedNode);
                            App.Msg("修改成功！");
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

        #region 全部文书树操作
        AdvTree NowTree = new AdvTree();
        /// <summary>
        /// 1.文书树双击事件
        /// 2.当双击文书树的节点时触发
        /// 3.控制文书的打开权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            if (OperateState != null && !OperateState.Contains("补录"))//  创建
            {
                App.Msg("提示 : 没有授权文书的补录权限!");
                return;
            }
            AddDoc();
        }

        /// <summary>
        /// 已写文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            if (OperateState != null && !OperateState.Contains("修改"))
            {
                App.Msg("提示 : 没有授权文书的修改权限只能浏览，请点击鼠标右键浏览!");
                return;
            }
            if (DataInit.boolAgree)// || ((OperateState.Contains("查看") || OperateState.Contains("创建"))&& !OperateState.Contains("修改")))
            {
                App.Msg("借阅的文书只能浏览，请点击鼠标右键浏览!");
                return;
            }

            bool isright = isRightBook(NowTree.SelectedNode);
            if (isright)
            {
                bool isFlag = IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
                if (!isFlag)
                {
                    Class_Text text = null;
                    //得到文书类型对象
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
                    //     *护士文书
                    //     */
                    //    create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                    //}
                    //else
                    //{
                    //    /*
                    //     *医生 
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
                       App.UserAccount.CurrentSelectRole.Role_type == "Z")//提供质控科查看痕迹,因为痕迹只在编辑状态才能查看
                    {
                        //会诊记录在已写文书中只能浏览.Textcode == "EMR100009"
                        //大节点进入浏览状态
                        if ((text.Parentid == 147 && text.Textname == "会诊记录")||
                            (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text") && text.Issimpleinstance=="1"))
                            tlspmnitBrowse_Click(sender, e);
                        else
                            AddDoc();//角色类型与文书类型对应
                    }
                    else
                    {
                        //定制文书
                        if (!create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient))
                        {
                            //非定制文书
                            //浏览状态显示文书
                            tlspmnitBrowse_Click(sender, e);
                        }



                    }

        #endregion
                }
            }
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
                         * tctlDoc的有tabItem，判断是否有重复的。
                         * tctlDoc的没有tabItem，就直接创建
                         */
                        if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                        {
                            Class_Text text = NowTree.SelectedNode.Tag as Class_Text;

                          

                            //text.Ishighersign
                            currentPatient = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString());
                            InPatientInfo inPatient = null;
                            inPatient = currentPatient;


                        


                            if (inPatient.Gender_Code.Trim() == "女")
                            {
                                inPatient.Gender_Code = "1";
                            }
                            string temptid = "";
                            if (text != null && text.Issimpleinstance == "0")//单例文书
                            {
                                temptid = isExitRecord(text.Id, inPatient.Id);//判断该类单例文书是否存在
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
                                 * IsSameTabItem()判断tctlDoc是否有相同的文书类型(TabItem)
                                 * IsSameBookDoc()判断tctlDoc是否有相同的文书(TabItem)
                                 */
                                if (IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")) == false)          //false表示里面没有相同的tabItem
                                {
                                    if (text.Isenable == "1")
                                    {
                                        //创建定制文书
                                        create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                                    }
                                    else
                                    {
                                        //创建非定制文书
                                        CreateTabItem(tid);
                                    }
                                }
                            }
                            else
                            {
                                if (text.Isenable == "1")
                                {
                                    //创建定制文书
                                    create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient);
                                }
                                else
                                {
                                    //创建非定制文书
                                    CreateTabItem(tid);
                                }

                            }
                        }
                        else if (NowTree.SelectedNode.Tag.ToString().Contains("Patient_Doc"))
                        {
                            //已经写的多例文书
                            CreateTabItem(Convert.ToInt32(NowTree.SelectedNode.Parent.Name));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                int patient_Id = currentPatient.Id;
                //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                App.MsgErr("创建文书异常，原因：" + ex.Message);
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
        /// 创建新的tabItem
        /// </summary>
        /// <param name="tid">文书id</param>
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
            string suporSign = "";  //查房上级医师的userId
            
            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            //CurrentNode = advAllDoc.SelectedNode.Clone() as TreeNode;
            // 获得当前时间，精确到分钟
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
                    App.MsgErr("创建文书异常，原因：已书写同类文书");
                    return;
                }
                if (isSqjc(text.Id.ToString().Trim(), currentPatient.Id) == true)
                {
                    App.MsgErr("请书写术前小结！");
                }


                //新建文书，page页的Name用分号隔开，第一位：代表文书类型ID;第二位：文书类型;第三位：代表新建文书;第四位：是否单例文书
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
                flagtq = true;
                //文书对应的医务处规则ID
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

                    //该文书的红灯质控记录
                    //string valsql = "select t.id,t.pid,t.pv,t2.编号 as doctypeid,substr(t.note,1,INSTR(t.note,'\"',1,1)-5) as 红灯时间,t.note as 红灯说明,t.patient_id from t_quality_record t inner join quality_var_ywc_view t2 on t.doctype=t2.文档类型 where t.pv=1 and t2.编号 in (" + strval + ") and t.patient_id=" + currentPatient.Id + " order by to_date(substr(t.note,1,INSTR(t.note,'\"',1,1)-5),'YYYY-MM-DD HH24:MI'),t.note desc";
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
            else //修改文书，page页的Name用分号隔开，第一位：文书ID；第二位：文书类型
            {
                ucDoctorOperater.flagtq = false;
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString();
            }

            page.Text = NowTree.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            if (NowTree.SelectedNode.Tag != null)
            {
                if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text tempcl = (Class_Text)NowTree.SelectedNode.Tag;
                    if (App.UserAccount.CurrentSelectRole.Role_type != tempcl.Right_range &&
                        tempcl.Right_range != "A" &&
                       App.UserAccount.CurrentSelectRole.Role_type != "Z")//提供质控科查看痕迹,因为痕迹只在编辑状态才能查看
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        App.Msg("您没有书写该类文书的权限！");
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
                        //是否忽略空行
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

                        #region 时间标题设置
                        isFlagtrue = false;
                        if (select_text.Ishavetime == "A") //编辑器内显示时间标题
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
                        else if ((select_text.Ishavetime == "B" || select_text.Ishavetime == "C") && tid == 0)//弹出提示框，编辑器内显示文书名+时间标题
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
                            if (NowTree.SelectedNode.Name == "127")//上级查房记录
                            {
                                frmTime = new frmUpdateTime(Record_Time, "查房记录", true);
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
                        if (NowTree.SelectedNode.Text == "手术记录")
                        {
                            Record_Content = "手术记录";

                        }
                        #endregion

                        if (cText.Issimpleinstance == "1")            //1代表多实例文书
                        {
                            if (inpatient.Sick_Bed_Name != "")
                            {
                                if (!IsSameBookDoc() && !IsSameTabItem(NowTree.SelectedNode.Name, Record_Time))
                                {
                                    if (page.Name.Split(';').Length == 4)
                                    {//多例文书选项添加时间记录,防止重复时间添加
                                        page.Name += ";" + Record_Time;
                                    }
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //获取文书的默认模板
                                    {

                                        // Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                                        
                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        //显示所有按钮 (文书对比) 
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        //    App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;
                                        SetTextButtonFase(text);
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime =="C")
                                                        {//时间标题中隐藏时间项
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";

                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//时间标题中隐藏时间项
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                    }
                                                    if (NowTree.SelectedNode.Text.Contains("日常病程记录") ||
                                                        NowTree.SelectedNode.Text.Contains("医患沟通记录"))
                                                    {
                                                        text.MyDoc.HidleNameTitle = true;
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }

                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        //手术知情同意书行间距默认6
                                        if (cText.Id == 1601)
                                        {
                                            text.MyDoc.Info.LineSpacing = 6;
                                            text.MyDoc.Info.ParagraphSpacing = 6;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        text.MyDoc.HidleNameTitle = true;
                                        //if (advAllDoc.SelectedNode.Name == "1102") //透析
                                        //{
                                        //    text.MyDoc._InsertMoreDiv(Record_Time + " " + Record_Content);
                                        //}                                      

                                    }
                                    else
                                    {
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        //Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        SetTextButtonFase(text);
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

                                        text.MyDoc.SuporSign = suporSign; //查房上级医师userId

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        //显示所有按钮 (文书对比)
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
                                        if (NowTree.SelectedNode.Text.Contains("医患沟通记录"))
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
                        else//单例文书
                        {
                            string temptid = isExitRecord(cText.Id, currentPatient.Id);
                            if (temptid != null && temptid != "")   //如果已经存在，则是修改。
                            {
                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    tid = Convert.ToInt32(temptid);
                                    //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true);
                                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                    string strbed_no = App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + inpatient.Id + "' and a.bed_id=c.bed_id and b.section_name=(select section_name from t_patients_doc where tid='"+temptid+"') and rownum=1 order by happen_time desc", 0, "bed_no");
                                    //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                    if (cText.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }
                                    if (strbed_no!=null && strbed_no!="")
                                    {
                                        text.MyDoc.Bed_name = strbed_no; 
                                    }
                                    //显示所有按钮 (文书对比)
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
                                    //是显示当前科室还是病人当时科室
                                    //if (OperateState != null && OperateState.Contains("补录"))
                                    //{
                                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                                    //}
                                    //修改文书，Ishighersign是否需要上级医师审签
                                    text.MyDoc.TextSuperiorSignature = ishighersign;
                                    text.MyDoc.HaveTubebedSign = havedoctorsign;  //管床医生是否审签
                                    text.MyDoc.HaveSuperiorSignature = havehighersign;//是否已经有过上级医生签名
                                    
                                    if (select_text.Ishavetime != "")
                                    {
                                        text.MyDoc.NeedTimeTitle = true;
                                    }

                                    if (select_text.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }

                                    tmpxml.LoadXml(content);
                                    if (NowTree.SelectedNode.Text.Contains("日常病程记录"))
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
                                    if (content != null)         //获取文书的默认模板
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                       
                                        //显示所有按钮 (文书对比)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        //患者授权(委托)书 1603 自动出院同意书 1585 不需要管床签字
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
                                            text.MyDoc.HaveTubebedSign = "N";//管床医生是否审签
                                        }
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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

                                        //患者授权（委托）书行间距4
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

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        
                                        //显示所有按钮 (文书对比)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
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
                        //记录操作日志
                        //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);

                        tabctpnDoc.TabItem = page;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        //if (docflaag == "Y" || NowTree.SelectedNode.Text == "住院病案首页" || NowTree.SelectedNode.Text == "患者基本信息")
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
            else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {

                Class_Text cText = NowTree.SelectedNode.Parent.Tag as Class_Text;
                barTemplate.AutoHide = true;
                //设置文书标题
                string textTitle = GetTextTitle(NowTree.SelectedNode);
                //是否可以忽略空行
                bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                page.Tag = currentPatient as object;
                Record_Time = NowTree.SelectedNode.Text;
                InPatientInfo inpatient = page.Tag as InPatientInfo;
                if (inpatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    //把未提交的普通文书存到arraylist
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
                   
                    //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                    if (cText.Isneedsign == "Y")
                    {
                        text.MyDoc.AutoGraph = true;
                    }
                    if (textTitle.Contains("电脑血糖监测记录单") || textTitle.Contains("产科(新生儿)护理记录单") ||
                        textTitle.Contains("新生儿经皮胆红素观察表") || textTitle.Contains("缩宫素滴注观察记录单") ||
                        textTitle.Contains("PICC护理记录单"))
                    {
                        int nodeIndex = advFinishDoc.SelectedNode.Index;
                        text.MyDoc.PageStartIndex = nodeIndex;
                    }
                    //显示所有按钮 (文书对比)
                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                    //                     App.UserAccount.CurrentSelectRole.Role_type == "N")
                    //    text.MyDoc.EnableShowAll = false;
                    //else
                    SetTextButtonFase(text);
                    text.MyDoc.EnableShowAll = true;

                    // text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                    //if (pdoc.Createid == App.UserAccount.UserInfo.User_id)
                    //{
                        text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //else
                    //{
                        text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                    //}
                        text.MyDoc.Bed_name = pdoc.Bed;
                        //DataInit.strbed = pdoc.Bed;
                    //修改文书，Ishighersign是否需要上级医师审签
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //管床医生是否审签
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//是否已经有过上级医生签名
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //查房医生的userId
                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                    if (text.MyDoc.OwnerControl.ContextMenuStrip!=null)
                    {
                        text.MyDoc.OwnerControl.ContextMenuStrip.Items[1].Visible = false;

                    }
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
                    //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                    //锁定文书
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
        /// 创建新的tabItem 根据是否是语音
        /// </summary>
        /// <param name="tid">文书id</param>
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
            string suporSign = "";  //查房上级医师的userId

            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            //CurrentNode = advAllDoc.SelectedNode.Clone() as TreeNode;
            // 获得当前时间，精确到分钟
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
                    App.MsgErr("创建文书异常，原因：已书写同类文书");
                    return;
                }
                if (isSqjc(text.Id.ToString().Trim(), currentPatient.Id) == true)
                {
                    App.MsgErr("请书写术前小结！");
                }


                //新建文书，page页的Name用分号隔开，第一位：代表文书类型ID;第二位：文书类型;第三位：代表新建文书;第四位：是否单例文书
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
                flagtq = true;
                //文书对应的医务处规则ID
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

                    //该文书的红灯质控记录
                    //string valsql = "select t.id,t.pid,t.pv,t2.编号 as doctypeid,substr(t.note,1,INSTR(t.note,'\"',1,1)-5) as 红灯时间,t.note as 红灯说明,t.patient_id from t_quality_record t inner join quality_var_ywc_view t2 on t.doctype=t2.文档类型 where t.pv=1 and t2.编号 in (" + strval + ") and t.patient_id=" + currentPatient.Id + " order by to_date(substr(t.note,1,INSTR(t.note,'\"',1,1)-5),'YYYY-MM-DD HH24:MI'),t.note desc";
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
            else //修改文书，page页的Name用分号隔开，第一位：文书ID；第二位：文书类型
            {
                ucDoctorOperater.flagtq = false;
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString();
            }

            page.Text = NowTree.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            if (NowTree.SelectedNode.Tag != null)
            {
                if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text tempcl = (Class_Text)NowTree.SelectedNode.Tag;
                    if (App.UserAccount.CurrentSelectRole.Role_type != tempcl.Right_range &&
                        tempcl.Right_range != "A" &&
                       App.UserAccount.CurrentSelectRole.Role_type != "Z")//提供质控科查看痕迹,因为痕迹只在编辑状态才能查看
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        App.Msg("您没有书写该类文书的权限！");
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
                        //是否忽略空行
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

                        #region 时间标题设置
                        isFlagtrue = false;
                        if (select_text.Ishavetime == "A") //编辑器内显示时间标题
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
                        else if ((select_text.Ishavetime == "B" || select_text.Ishavetime == "C") && tid == 0)//弹出提示框，编辑器内显示文书名+时间标题
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
                            if (NowTree.SelectedNode.Name == "127")//上级查房记录
                            {
                                frmTime = new frmUpdateTime(Record_Time, "查房记录", true);
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
                        if (NowTree.SelectedNode.Text == "手术记录")
                        {
                            Record_Content = "手术记录";

                        }
                        #endregion

                        if (cText.Issimpleinstance == "1")            //1代表多实例文书
                        {
                            if (inpatient.Sick_Bed_Name != "")
                            {
                                if (!IsSameBookDoc() && !IsSameTabItem(NowTree.SelectedNode.Name, Record_Time))
                                {
                                    if (page.Name.Split(';').Length == 4)
                                    {//多例文书选项添加时间记录,防止重复时间添加
                                        page.Name += ";" + Record_Time;
                                    }
                                    string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                    //string content = DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                    //content=DocFromXmlBytText(CurrentNode.Name, content);
                                    if (content != null)         //获取文书的默认模板
                                    {

                                        // Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }
                                        //显示所有按钮 (文书对比) 
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        //    App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        text.MyDoc.EnableShowAll = true;
                                        SetTextButtonFase(text);
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//时间标题中隐藏时间项
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                            foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                            {
                                                if (bodyNode.Name == "body")
                                                {
                                                    bodyNode.InnerXml = "";

                                                    if (select_text.Ishavetime != "")
                                                    {
                                                        if (select_text.Ishavetime == "C")
                                                        {//时间标题中隐藏时间项
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' visibleTimeText='N' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        else
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                    }
                                                    if (NowTree.SelectedNode.Text.Contains("日常病程记录") ||
                                                        NowTree.SelectedNode.Text.Contains("医患沟通记录"))
                                                    {
                                                        text.MyDoc.HidleNameTitle = true;
                                                    }
                                                    bodyNode.InnerXml += content;
                                                }
                                            }
                                        }

                                        DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        //手术知情同意书行间距默认6
                                        if (cText.Id == 1601)
                                        {
                                            text.MyDoc.Info.LineSpacing = 6;
                                            text.MyDoc.Info.ParagraphSpacing = 6;
                                        }
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;
                                        text.MyDoc.HidleNameTitle = true;
                                        //if (advAllDoc.SelectedNode.Name == "1102") //透析
                                        //{
                                        //    text.MyDoc._InsertMoreDiv(Record_Time + " " + Record_Content);
                                        //}                                      

                                    }
                                    else
                                    {
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                        //Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        SetTextButtonFase(text);
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

                                        text.MyDoc.SuporSign = suporSign; //查房上级医师userId

                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        //显示所有按钮 (文书对比)
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
                                        if (NowTree.SelectedNode.Text.Contains("医患沟通记录"))
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
                        else//单例文书
                        {
                            string temptid = isExitRecord(cText.Id, currentPatient.Id);
                            if (temptid != null && temptid != "")   //如果已经存在，则是修改。
                            {
                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    tid = Convert.ToInt32(temptid);
                                    //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true);
                                    frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                    string strbed_no = App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + inpatient.Id + "' and a.bed_id=c.bed_id and b.section_name=(select section_name from t_patients_doc where tid='" + temptid + "') and rownum=1 order by happen_time desc", 0, "bed_no");
                                    //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                    if (cText.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }
                                    if (strbed_no != null && strbed_no != "")
                                    {
                                        text.MyDoc.Bed_name = strbed_no;
                                    }
                                    //显示所有按钮 (文书对比)
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
                                    //是显示当前科室还是病人当时科室
                                    //if (OperateState != null && OperateState.Contains("补录"))
                                    //{
                                    //    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                                    //}
                                    //修改文书，Ishighersign是否需要上级医师审签
                                    text.MyDoc.TextSuperiorSignature = ishighersign;
                                    text.MyDoc.HaveTubebedSign = havedoctorsign;  //管床医生是否审签
                                    text.MyDoc.HaveSuperiorSignature = havehighersign;//是否已经有过上级医生签名

                                    if (select_text.Ishavetime != "")
                                    {
                                        text.MyDoc.NeedTimeTitle = true;
                                    }

                                    if (select_text.Isneedsign == "Y")
                                    {
                                        text.MyDoc.AutoGraph = true;
                                    }

                                    tmpxml.LoadXml(content);
                                    if (NowTree.SelectedNode.Text.Contains("日常病程记录"))
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
                                    if (content != null)         //获取文书的默认模板
                                    {
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        //显示所有按钮 (文书对比)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        //患者授权(委托)书 1603 自动出院同意书 1585 不需要管床签字
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
                                            text.MyDoc.HaveTubebedSign = "N";//管床医生是否审签
                                        }
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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
                                            XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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

                                        //患者授权（委托）书行间距4
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

                                        //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                                        if (cText.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        //显示所有按钮 (文书对比)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        SetTextButtonFase(text);
                                        text.MyDoc.EnableShowAll = true;
                                        //添加文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                        text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
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
                        //记录操作日志
                        //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);

                        tabctpnDoc.TabItem = page;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        //if (docflaag == "Y" || NowTree.SelectedNode.Text == "住院病案首页" || NowTree.SelectedNode.Text == "患者基本信息")
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
            else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
            {

                Class_Text cText = NowTree.SelectedNode.Parent.Tag as Class_Text;
                barTemplate.AutoHide = true;
                //设置文书标题
                string textTitle = GetTextTitle(NowTree.SelectedNode);
                //是否可以忽略空行
                bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                page.Tag = currentPatient as object;
                Record_Time = NowTree.SelectedNode.Text;
                InPatientInfo inpatient = page.Tag as InPatientInfo;
                if (inpatient.Sick_Bed_Name != "")
                {
                    isCustom = false;
                    //把未提交的普通文书存到arraylist
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

                    //多例已写文书，暂存之后再提交签名无法自动插入的问题（该文书类型已经设置自动签名）
                    if (cText.Isneedsign == "Y")
                    {
                        text.MyDoc.AutoGraph = true;
                    }
                    if (textTitle.Contains("电脑血糖监测记录单") || textTitle.Contains("产科(新生儿)护理记录单") ||
                        textTitle.Contains("新生儿经皮胆红素观察表") || textTitle.Contains("缩宫素滴注观察记录单") ||
                        textTitle.Contains("PICC护理记录单"))
                    {
                        int nodeIndex = advFinishDoc.SelectedNode.Index;
                        text.MyDoc.PageStartIndex = nodeIndex;
                    }
                    //显示所有按钮 (文书对比)
                    //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                    //                     App.UserAccount.CurrentSelectRole.Role_type == "N")
                    //    text.MyDoc.EnableShowAll = false;
                    //else
                    SetTextButtonFase(text);
                    text.MyDoc.EnableShowAll = true;

                    // text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                    //if (pdoc.Createid == App.UserAccount.UserInfo.User_id)
                    //{
                    text.MyDoc.Section_name = App.UserAccount.CurrentSelectRole.Section_name;
                    //}
                    //else
                    //{
                    text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                                                                //}
                    text.MyDoc.Bed_name = pdoc.Bed;
                    //DataInit.strbed = pdoc.Bed;
                    //修改文书，Ishighersign是否需要上级医师审签
                    text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                    text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //管床医生是否审签
                    text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//是否已经有过上级医生签名
                    text.MyDoc.SuporSign = pdoc.Highersignuserid; //查房医生的userId
                    text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    //text.MyDoc.OwnerControl.ContextMenuStrip.Items[4].Visible = false;//pacs
                    text.MyDoc.OnGetLisPross += new TextEditor.TextDocument.Document.ZYTextDocument.GetLisPross(DataInit.getLisProgress);
                    if (text.MyDoc.OwnerControl.ContextMenuStrip != null)
                    {
                        text.MyDoc.OwnerControl.ContextMenuStrip.Items[1].Visible = false;

                    }
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
                    //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                    //锁定文书
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
        /// 当前病人对应文书文书TID
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
        /// 当前病人当前文书是否存在对应要读取内容的文书
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
        /// 是否是要复制的内容
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        private bool isCloneContent(string sc, string text_id)
        {
            bool flag = false;
            string[] source_s = "主诉,现病史".Split(',');
            sc = sc.Replace(":", " ").Replace("：", " ").Trim();
            for (int i = 0; i < source_s.Length; i++)
            {
                if (!string.IsNullOrEmpty(sc) && sc == source_s[i])
                {
                    return true;
                }
            }
            if (text_id == "125")
            {
                if (sc == "辅助检查")
                    flag = true;
            }
            string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121";
            if (textlist.Contains(text_id))
            {
                //门诊及院外重要检查结果(辅助检查）：
                if (sc.Contains("门诊及院外重要检查结果") && sc.Contains("辅助检查"))
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 住院志同步到首程
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sc"></param>
        /// <returns></returns>
        private string xmlContent(XmlDocument xml, string sc)
        {
            try
            {
                string content = "";
                sc = sc.Replace(":", " ").Replace("：", " ").Trim();
                XmlNode bodynode = xml.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");//input
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["title"] != null)
                    {
                        string xnname = xn.Attributes["title"].Value.ToString().Trim();
                        xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();
                        if (sc != "辅助检查")
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
                            if (xnname.Contains("门诊及院外重要检查结果"))
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
        /// 首程同步到住院志
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="sc"></param>
        /// <returns></returns>
        private string docContent(XmlDocument xml, string sc)
        {
            try
            {
                string content = "";
                sc = sc.Replace(":", " ").Replace("：", " ").Trim();
                XmlNode bodynode = xml.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");//input
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["title"] != null)
                    {
                        string xnname = xn.Attributes["title"].Value.ToString().Trim();
                        xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();

                        if (sc.Contains("辅助检查") && sc.Contains("门诊及院外重要检查结果"))
                        {
                            if (xnname.Contains("辅助检查"))
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
        /// 过滤掉xml节点已经删除的内容
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
        /// 将住院日志里面的部分内容和首程同步
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
                    //源内容
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

                    //当前内容  读取内容： 主诉 现病史 既往史
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    if (content.Contains("emrtextdoc"))
                    {
                        tempxmldoc.LoadXml(content);
                        XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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
                        XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
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
                                        //InnerXml读取结构  InnerText读取内容
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
        /// 体温单体温 呼吸 脉搏 血压 信息自动读取
        /// </summary>
        /// <param name="content"></param>
        private string PTRHInsert(string content, string text_id)
        {
            if (string.IsNullOrEmpty(content))
                return content;
            //首程+住院志
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

            //体温
            string temperature = App.ReadSqlVal("select temperature_value from t_vital_signs where patient_id=" + currentPatient.Id + " and temperature_value is not null order by measure_time ", 0, "temperature_value");
            //脉搏
            string pulse = App.ReadSqlVal("select pulse_value from t_vital_signs where patient_id=" + currentPatient.Id + " and pulse_value is not null order by measure_time ", 0, "pulse_value");
            //呼吸
            string breath = App.ReadSqlVal("select breath_value from t_vital_signs where patient_id=" + currentPatient.Id + " and breath_value is not null order by measure_time ", 0, "breath_value");
            //血压
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
                            case "体温":
                                if (!string.IsNullOrEmpty(temperature))
                                    list[i].InnerText = temperature;
                                break;
                            case "脉搏":
                                if (!string.IsNullOrEmpty(pulse))
                                    list[i].InnerText = pulse;
                                break;
                            case "呼吸":
                                if (!string.IsNullOrEmpty(breath))
                                    list[i].InnerText = breath;
                                break;
                            case "血压_1":
                                if (!string.IsNullOrEmpty(us_blood[0]))
                                    list[i].InnerText = us_blood[0];
                                break;
                            case "血压_2":
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
        /// 创建定制文书
        /// </summary>
        /// <param name="node">当前文书树选中的节点</param>
        /// <param name="tctldoc">tabcontrol</param>
        /// <param name="currentPatient">当前病人</param>
        private bool create_Nurse_Book(Node node, DevComponents.DotNetBar.TabControl tctlDoc, InPatientInfo currentPatient)
        {
            bool isExcute = true;
            barTemplate.Hide();
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();

            page.Click += new EventHandler(page_Click);

            page.Name = node.Name;
            page.Text = node.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
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
                        //血糖检测单
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
                        //产程图
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
                             * 护士操作
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
                                              * 医生站
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
                        int Section_Id = 0;//科室id
                        if (App.UserAccount.CurrentSelectRole.Sickarea_Id != null &&
                            App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                            Section_Id = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);

                        string Role_type = App.UserAccount.CurrentSelectRole.Role_type;//用户类型
                        if ((Role_type != "N" && Role_type != "D") || currentPatient.PatientState == "借阅" || (OperateState != null && OperateState.Contains("查看") && !OperateState.Contains("补录")))
                        {
                            Section_Id = Convert.ToInt32(inpatient.Section_Id);
                        }
                        MUcToolsControl ucNurseRecord;
                        if (node.Text.Contains("新生儿"))
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name), true);
                        else
                            ucNurseRecord = new MUcToolsControl(inpatient, Section_Id, Convert.ToInt32(node.Name));

                        ucNurseRecord.MyDocument.OnSaveChanged += OnSaveChanged;
                        //护士操作
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);

                        //检查是否锁定
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        //bool islock = GetLockState(inpatient.Id, out open_num, out open_name,out ip);

                        if (Role_type != "N" || (OperateState != null && !OperateState.Contains("创建") && !OperateState.Contains("修改") && !OperateState.Contains("补录")))
                        {// || islock
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);//隐藏那个菜单
                            //Panel bp = ucNurseRecord.GetButtonPanel();
                            //foreach (Control c in bp.Controls)
                            //{//遍历控件,设置属性
                            //    if (c is Button)
                            //    {
                            //        Button b = (Button)c;
                            //        if ((b.Text == "打印" || b.Text == "续打") && currentPatient.PatientState != "借阅")
                            //        {
                            //            b.Visible = true;
                            //            b.Enabled = true;
                            //        }
                            //    }
                            //}
                            //ucNurseRecord.MyDocument.ClearContent();//清空界面
                            page.Text += " 浏览 ";

                            //if (islock && Role_type == "N")
                            //{
                            //    string strText = "（锁定工号：" + open_num + " 姓名：" + open_name + "）";
                            //    page.Text += strText;
                            //    App.Msg("提示:已有用户正在编辑，该病人护理记录单已被锁定！\n锁定人工号：" + open_num + "\n锁定人姓名：" + open_name);
                            //}
                        }
                        //else//没锁定之前
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
                        //if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
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
                        // * 护士操作
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
                        //        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        //        App.MsgWaring("该份护理记录单已有老师打开，同一个病人同时只能单个用户操作！");
                        //    }
                        //}
                        //tabctpnDoc.AutoScroll = true;
                        //isCustom = true;
                        //if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
                        //{
                        //    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //} 
                        #endregion

                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //体温单
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
                        //新生儿体温单
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
                        //重新过去最新信息
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

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
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
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
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
                        App.Msg("定制文书没有确定对应的功能模块,请于管理员联系,在文书类型管理中进行设置！");

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
            //if (!item.Text.Contains("锁定"))
            //{
            //    IsLockBook("t_care_doc", currentPatient.Id, "0");
            //}
        }


        /// <summary>
        /// 1.文书树变更事件
        /// 2.当改变文书树的选中项时触发
        /// 3.控制节点的右键菜单显示的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            NowTree = sender as AdvTree;
            if (NowTree != null && NowTree.SelectedNode != null)
            {
                string account_Type = App.UserAccount.CurrentSelectRole.Role_type;

                this.代主治查房ToolStripMenuItem.Visible = false;
                this.代主任查房ToolStripMenuItem.Visible = false;
                this.取消代上级查房ToolStripMenuItem.Visible = false;
                if (account_Type == "D")
                {
                    NowTree.ContextMenuStrip = this.ctmnspDelete;
                    if (NowTree.SelectedNode.Name == "663" ||              //护理观察单
                       NowTree.SelectedNode.Name == "561" ||            //血糖检测单
                       NowTree.SelectedNode.Name == "170" ||            //护理记录单
                       NowTree.SelectedNode.Name == "172" ||            //体温单记录
                       NowTree.SelectedNode.Name == "173"            //出入液量记录单
                      )           //出入液量记录单
                    {
                        this.删除ToolStripMenuItem.Visible = false;
                        this.tlspmnitBrowse.Visible = true;  //浏览
                        //this.修改标题ToolStripMenuItem.Visible = false;
                    }



                    if (NowTree.SelectedNode.Tag != null)
                    {
                        if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                        {
                            this.删除ToolStripMenuItem.Visible = true;
                            this.tlspmnitBrowse.Visible = true;  //浏览
                            //this.修改标题ToolStripMenuItem.Visible = true;
                            Patient_Doc patient_Doc = NowTree.SelectedNode.Tag as Patient_Doc;
                            if (patient_Doc.Textname == "入院病人评估记录单" ||
                                patient_Doc.Textname == "放、化疗病人健康记录单" ||
                                patient_Doc.Textname == "化验粘贴单" ||
                                patient_Doc.Textname == "静脉导管维护观察记录单" ||
                                patient_Doc.Textname == "护理观察记录单" ||
                                patient_Doc.Textname == "手术病人健康记录单")
                            {
                                this.删除ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //浏览
                            }
                            else if (NowTree.SelectedNode.Parent.Name == "126")
                            {
                                this.取消代上级查房ToolStripMenuItem.Visible = true;
                                this.代主治查房ToolStripMenuItem.Visible = true;
                                this.代主任查房ToolStripMenuItem.Visible = true;
                                if (patient_Doc.Isreplacehighdoctor == "Y" || patient_Doc.Isreplacehighdoctor2 == "Y")
                                {
                                    this.取消代上级查房ToolStripMenuItem.Enabled = true;
                                    this.代主治查房ToolStripMenuItem.Enabled = false;
                                    this.代主任查房ToolStripMenuItem.Enabled = false;
                                }
                                else
                                {
                                    this.取消代上级查房ToolStripMenuItem.Enabled = false;
                                    this.代主治查房ToolStripMenuItem.Enabled = true;
                                    this.代主任查房ToolStripMenuItem.Enabled = true;
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
                                    //text.Textname != "医患合约" &&
                                    text.Textname != "住院病人护理安全告知书")
                                {
                                    this.删除ToolStripMenuItem.Visible = true;
                                }
                                else
                                {
                                    this.删除ToolStripMenuItem.Visible = false;
                                }
                                //this.修改标题ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //浏览
                            }
                            else
                            {
                                this.删除ToolStripMenuItem.Visible = false;
                                //this.修改标题ToolStripMenuItem.Visible = false;
                                if (NowTree.SelectedNode.Text == "病程记录")
                                {
                                    this.tlspmnitBrowse.Visible = true;  //浏览
                                }
                                else
                                {
                                    this.tlspmnitBrowse.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            this.删除ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = false;  //浏览

                            //this.修改标题ToolStripMenuItem.Visible = false;
                        }
                    }
                }
                else
                {
                    if (NowTree.SelectedNode.Tag != null)
                    {
                        //172 ，663，1874，1875，1876，1877，1878，1879
                        if (NowTree.SelectedNode.Name == "663" ||              //护理观察单
                           NowTree.SelectedNode.Name == "561" ||            //血糖检测单
                           NowTree.SelectedNode.Name == "170" ||            //护理记录单
                           NowTree.SelectedNode.Name == "172" ||            //体温单记录
                           NowTree.SelectedNode.Name == "173")
                        {
                            this.删除ToolStripMenuItem.Visible = true;
                            //this.修改标题ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = true;  //浏览
                        }
                        else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                        {
                            Patient_Doc patient_Doc = NowTree.SelectedNode.Tag as Patient_Doc;
                            if (patient_Doc.Textname == "入院病人评估记录单" ||
                                patient_Doc.Textname == "放、化疗病人健康记录单" ||
                                patient_Doc.Textname == "化验粘贴单" ||
                                patient_Doc.Textname == "静脉导管维护观察记录单" ||
                                patient_Doc.Textname == "护理观察记录单" ||
                                patient_Doc.Textname == "手术病人健康记录单" ||
                                patient_Doc.Textname == "医患合约" ||
                                //婴儿护理记录单
                                patient_Doc.Textname.Contains("婴儿护理记录单") ||
                                patient_Doc.Textname == "住院病人护理安全告知书")
                            {
                                this.删除ToolStripMenuItem.Visible = true;
                                this.tlspmnitBrowse.Visible = true;  //浏览
                            }
                            else
                            {
                                this.删除ToolStripMenuItem.Visible = false;
                                this.tlspmnitBrowse.Visible = true;  //浏览
                            }
                            //this.修改标题ToolStripMenuItem.Visible = false;

                        }
                        else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                        {
                            Class_Text text = NowTree.SelectedNode.Tag as Class_Text;
                            if (text.Textname == "医患合约" ||
                                text.Textname == "住院病人护理安全告知书")
                            {
                                this.删除ToolStripMenuItem.Visible = true;
                            }
                            else
                            {
                                this.删除ToolStripMenuItem.Visible = false;
                            }
                            //this.修改标题ToolStripMenuItem.Visible = false;
                            this.tlspmnitBrowse.Visible = true;  //浏览
                        }
                        else
                        {
                            this.删除ToolStripMenuItem.Visible = false;
                            if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                            {
                                if (NowTree.SelectedNode.Parent.Name == "1874" ||
                                NowTree.SelectedNode.Parent.Name == "1875" ||
                                NowTree.SelectedNode.Parent.Name == "1876" ||
                                NowTree.SelectedNode.Parent.Name == "1877" ||
                                NowTree.SelectedNode.Parent.Name == "1878" ||
                                NowTree.SelectedNode.Parent.Name == "1879")
                                {
                                    this.删除ToolStripMenuItem.Visible = true;
                                    //this.修改标题ToolStripMenuItem.Visible = false;
                                    this.tlspmnitBrowse.Visible = true;  //浏览
                                }
                            }
                        }
                    }

                }
            }
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
            AddFinishNode();
            //RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//展开所有文书节点

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowTree.SelectedNode != null)
            {
                advAllDoc_DoubleClick(NowTree, e);
            }
            else
            {
                App.Msg("请选中文书节点！");
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
                    添加ToolStripMenuItem.Visible = true;
                }
                else
                {
                    添加ToolStripMenuItem.Visible = false;
                }

                if (NowTree.SelectedNode.Tag != null)
                {
                    if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                    {
                        Class_Text tempnode = (Class_Text)NowTree.SelectedNode.Tag;
                        if (tempnode.Isenable == "1")
                        {
                            //定制界面
                            添加ToolStripMenuItem.Visible = false;
                        }
                    }
                }
            }
            else
            {
                添加ToolStripMenuItem.Visible = false;
            }
        }

        private void c1OutBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dockContainerItem_FinishDoc.Selected) //"已写文书")
            {
                NowTree = advFinishDoc;
            }
            else if (dockContainerItem_FinishDoc.Selected )//== "全部文书")
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
        /// 加载联想库
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
        /// 客户端质控相关事件
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
        /// 解除护理记录单的锁定
        /// </summary>
        private void UnlockNurseRecord(string user_id)
        {
            string Update_Sql = "update t_care_doc set islock=0 where (open_user='" + user_id + "' or create_id='" + user_id + "') and islock=1";
            int count = App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// 同一个病人只能单个用户操作
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="patient_id">病人id值</param>
        /// <param name="lockState">是否锁定0未锁定1锁定</param>
        /// <param name="colname">列名</param>
        /// <param name="tid">文书id列名</param>
        private void IsLockBook(string tablename, int patient_id, string lockState, string user_id)
        {
            string Update_Sql = "update " + tablename + " set islock='" + lockState
                            + "',OPEN_USER='" + user_id + "',ip='" + App.GetHostIp() + "' where inpatient_id='" + patient_id + "'";
            App.ExecuteSQL(Update_Sql);
        }

        /// <summary>
        /// 同一个病人只能单个用户操作
        /// </summary>
        /// <param name="lockState">是否锁定0未锁定1锁定</param>
        public void IsLockBook(int patient_id, string lockState)
        {
            string Update_Sql = "update t_care_doc set islock='" + lockState
                            + "',OPEN_USER='" + App.UserAccount.UserInfo.User_id + "',ip='" + App.GetHostIp() + "' where inpatient_id='" + patient_id + "'";
            App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// 获取当前病人护理记录单是否有人在操作
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="patient_id"></param>
        /// <returns>1是锁定，其他没有锁定</returns>
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

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
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
        ///// 同一个病人只能单个用户操作
        ///// </summary>
        ///// <param name="tablename">表名</param>
        ///// <param name="patient_id">病人id值</param>
        ///// <param name="lockState">是否锁定0未锁定1锁定</param>
        ///// <param name="colname">列名</param>
        ///// <param name="tid">文书id列名</param>
        //private void IsLockBook(string tablename, int patient_id, string lockState, string colname, string tid)
        //{
        //    string Update_Sql = "update " + tablename + " set islock='" + lockState + "' where " + colname + "='" + patient_id + "' and tid='"+tid+"'";
        //    App.ExecuteSQL(Update_Sql);
        //}

        /// <summary>
        /// 刷新已打开文书编辑器诊断信息
        /// </summary>
        /// <param name="Reftype">进入状态:1.未提交文书刷新;2.不管是否提交都刷</param>
        private void RefreshTabDocDiagnose(int Reftype)
        {

            //选中页签刷新
            if (tctlDoc.SelectedTabIndex != -1)
            {
                if (tctlDoc.SelectedPanel.Controls.Count > 0 && (App.UserAccount.CurrentSelectRole.Role_type == "D" || App.UserAccount.CurrentSelectRole.Role_type == "N" || App.UserAccount.CurrentSelectRole.Role_type == "B" || App.UserAccount.CurrentSelectRole.Role_type == "Y"))
                {
                    frmText text = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (text != null)
                    {
                        bool isSubmitt = DataInit.IsDocSubmitted(text.MyDoc.Us.Tid);
                        if (Reftype == 2 || !isSubmitt)
                        {//获取文书是否提交状态
                            if (Reftype == 2)//记录相关信息
                                LogHelper.SystemLog("刷新诊断", text.MyDoc.Us.Tid.ToString(), text.MyDoc.Us.InpatientInfo.PId.ToString(), text.MyDoc.Us.InpatientInfo.Id);
                            DataInit.RefreshDocDiagnose(text, Reftype);
                        }
                       // DataInit.RefreshDocDiagnose(text, Reftype);
                    }
                }
            }

        }


        /// <summary>
        /// 未完成文书备份还原
        /// </summary>
        private void CreatBakTabItem()
        {
            try
            {

                var files = Directory.GetFiles(App.SysPath + "\\DocTemp\\" + this.currentPatient.Id.ToString(), "*.xml");
                if (files.Length > 0)
                {
                    if (App.Ask("上次操作有未正常保存的病历，是否恢复？"))
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
                            filename = Path.GetFileName(file); //获取名称

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
                             * 获取文书大类                            
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
                                txtfc.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                txtfc.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名                              
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
                                txtfc.MyDoc.HaveTubebedSign = "N";//管床医生是否审签
                            }

                            txtfc.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                            //袁杨添加2015-7-14
                            txtfc.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;


                            //this.currentPatient;
                            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                            tabctpnDoc.AutoScroll = true;
                            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
                            page.Click += new EventHandler(page_Click);
                            page.Text = "恢复" + "_" + tid + "_" + texttitle + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
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
        /// 根据语音获取节点
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
                        if (TextBuffer .Contains( "已写文书"))
                        {
                            dockContainerItem_FinishDoc.Selected = true;
                        }
                        else if (TextBuffer. Contains( "全部文书"))
                        {
                            dockContainerItem_AllDoc.Selected = true;
                        }
                        else
                        {
                            if (dockContainerItem_AllDoc.Selected)
                            {
                                GetSelectCurrentNodeBySound(TextBuffer, advAllDoc.Nodes, advAllDoc);
                                if (TextBuffer .Contains( "创建"))
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
