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
using Base_Function.BLL_NURSE.NBlood_sugarRecord;
using Bifrost_Nurse.UControl;
using Base_Function.BLL_NURSE.First_cases;
using Base_Function.BLL_NURSE.SickInformational;
using Base_Function.BLL_NURSE.Odinopoeia_Record;
using Base_Function.BLL_NURSE.Expectant_Record;
using System.Xml;
using System.Collections;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using Base_Function.BASE_COMMON;

using Moran.Partogram;
using MoranEditor.GUI;
using Base_Function.TEMPERATURES;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_NURSE.Nereuse_record;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class ucManualDoc : UserControl
    {
        //文书右键“质控信息”，双击规则增加文书注释，增加扣分汇总表数据
        public delegate void RefEventHandlerAdd(string mark_id, string item, string item_con, string item_score, string did);
        public event RefEventHandlerAdd AddMark;

        public delegate void RefEventHandler();
        public event RefEventHandler DelScore;

        public delegate void RefEventHandlerDel(string mark_id,int action);
        public event RefEventHandlerDel DelMark;

        //保存所有的文书类型
        private AdvTree temptrvbook = new AdvTree();
        /// <summary>
        /// 当前病人对象。 
        /// </summary>
        private InPatientInfo currentPatient;
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

        private frmText CurrentFrmText=null;
        string isRead = "";//是否仅限查看

        public ucManualDoc()
        {
            InitializeComponent();
        }

        public ucManualDoc(InPatientInfo patientInfo,string strIsRead)
        {
            InitializeComponent();
            currentPatient = patientInfo;
            isRead = strIsRead;
            dockContainerItem1.Text = "操作集合";
        }

        private void ucManualDoc_Load(object sender, EventArgs e)
        {
            DataInit.ReflashBookTree(temptrvbook);
            ReflashTrvBook();//刷新文书树            
            frmText text = new frmText();
            if (isRead == "Y")
            {
                删除ToolStripMenuItem.Visible = false;
            }
        }

        #region 已写文书操作


        /// <summary>
        /// 添加已完成文书
        /// </summary>
        public void AddFinishNode()
        {
            Class_Table[] tablesqls = new Class_Table[4];
            tablesqls[0] = new Class_Table();

            tablesqls[0].Sql = "select id from t_text where parentid in(103,525)";    //所有归类于病程的小节点

            tablesqls[0].Tablename = "textbcs";

            tablesqls[1] = new Class_Table();

            tablesqls[1].Sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,m.user_name, a.textname," +
                                         "a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid," +
                                         "a.israplacehightdoctor,a.OPERATEID,a.CHARGE_DOCTOR_ID,a.CHIEF_DOCTOR_ID,a.RESIDENT_DOCTOR_ID,a.israplacehightdoctor2,a.SECTION_NAME,operateid,charge_doctor_id,chief_doctor_id,a.bed_no,t.isproblem_name,t.isproblem_time  " +
                                         "from t_patients_doc a left join t_text t on a.textkind_id=t.id left join t_userinfo m on a.operateid = m.user_id" +
                                         " where a.patient_Id='" + currentPatient.Id + "' order by a.doc_name";  //获取病人的所有文书

            tablesqls[1].Tablename = "patientdocs";

            //tablesqls[2] = new Class_Table();
            //tablesqls[2].Sql = "select * from cover_info t where t.patient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            //tablesqls[2].Tablename = "caseFirst";

            tablesqls[2] = new Class_Table();
            tablesqls[2].Sql = "select * from t_care_doc t where t.inpatient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            tablesqls[2].Tablename = "careDoc";

            tablesqls[3] = new Class_Table();
            tablesqls[3].Sql = "select * from t_temperature_info t where t.patient_id ='" + currentPatient.Id + "'";    //所有归类于病程的小节点
            tablesqls[3].Tablename = "temperatureDoc";


            DataSet dstextbc = App.GetDataSet(tablesqls);
            DataTable table_textnotbc = dstextbc.Tables["textnobc"];
            DataTable table_textbc = dstextbc.Tables["textbcs"];
            DataTable table_patientsdocs = dstextbc.Tables["patientdocs"];
            //DataTable table_caseFirst = dstextbc.Tables["caseFirst"];
            DataTable table_careDoc = dstextbc.Tables["careDoc"];
            DataTable table_temperatureDoc = dstextbc.Tables["temperatureDoc"];

            //刷新所有树节点
            DataInit.ReflashBookTree(advFinishDoc, true);


            //隐藏相关节点（此操作在绑定具体已经写文书内容之前执行）
            DataInit.removeNode(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

            //隐藏护理记录中定制文书
            DataInit.removeNodeCareDoc(advFinishDoc.Nodes, table_careDoc, table_temperatureDoc);

            //所写文书的内容绑定到文书树上
            DataInit.getFinishedText(advFinishDoc.Nodes, table_patientsdocs, table_textbc);

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
                            {                                                            //隐藏患者基本信息节点
                                if (TempNode.ImageIndex == 17 || TempNode.Name == "381")   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
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
                                //App.Msg("已经存在相同的文书！");
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
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
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
                            if (text.Isenable == "1")
                            {
                                if (text.Parentid != 0)
                                {
                                    //创建定制文书
                                    create_Nurse_Book(advFinishDoc.SelectedNode, tctlDoc, currentPatient);
                                }
                                return;
                            }
                            else
                            {
                                //创建非定制文书
                                tid = Convert.ToInt32(isExitRecord(text.Id, currentPatient.Id));//判断该类单例文书是否存在
                                if (tid == 0)
                                {
                                    return;
                                }
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

                    //扣分记录汇总表所属该份文书的数据做标识
                    bool b = true;
                    for (int i = 0; i < dgvKouFen.Rows.Count; i++)
                    {
                        if (dgvKouFen.Rows[i].Cells["docId"].Value.ToString() == tid.ToString())
                        {
                            dgvKouFen.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                            if (b)
                            {
                                dgvKouFen.Rows[i].Selected = true;
                                dgvKouFen.FirstDisplayedScrollingRowIndex = i;
                                b = false;
                            }
                        }
                        else
                        {
                            dgvKouFen.Rows[i].DefaultCellStyle.BackColor = dgvKouFen.BackgroundColor;
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

        /// <summary>
        /// 创建定制文书
        /// </summary>
        /// <param name="node">当前文书树选中的节点</param>
        /// <param name="tctldoc">tabcontrol</param>
        /// <param name="currentPatient">当前病人</param>
        private bool create_Nurse_Book(Node node, DevComponents.DotNetBar.TabControl tctlDoc, InPatientInfo currentPatient)
        {
            bool isFlag = IsSameTabItem(node.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
            if (isFlag)
            {
                return false;
            }

            bool isExcute = true;
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();

            page.Click += new EventHandler(page_Click);

            page.Name = node.Name;
            page.Text = node.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            page.Tag = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString()) as object;
            page.Tag = currentPatient as object;
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
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }

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
                        string user_section_id = App.ReadSqlVal("select sid from t_section_area where said='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'", 0, "sid");
                        if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, Convert.ToInt32(user_section_id), Convert.ToInt32(node.Name), true);
                        }
                        else
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, Convert.ToInt32(user_section_id), Convert.ToInt32(node.Name));
                        }
                        /*
                         * 护士操作
                         */
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        //bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        if (App.UserAccount.CurrentSelectRole.Role_type != "N")//|| islock
                        {
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);
                            //if (islock)
                            //{
                            //    page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                            //    App.MsgWaring("该份护理记录单已有老师打开，同一个病人同时只能单个用户操作！");
                            //}
                        }
                        tabctpnDoc.AutoScroll = true;
                        isCustom = true;
                        //if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
                        //{
                        //    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        //}
                        ucNurseRecord.MyDocument.OwnerControl.AutoScrollPosition = new Point(0, ucNurseRecord.MyDocument.Pages[ucNurseRecord.MyDocument.Pages.Count - 1].Y);
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
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {
                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        //page.Tooltip = "N";
                        ////重新过去最新信息
                        //string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        //DataSet ds = App.GetDataSet(Sql_section_Patient);
                        //inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        //frmCases_First ucCase_First = new frmCases_First(inpatient);

                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                        // App.UserAccount.CurrentSelectRole.Role_type == "N")
                        //{
                        //    //frmCases_First ucCase_First = new frmCases_First(inpatient);
                        //    tabctpnDoc.Controls.Add(ucCase_First);
                        //    ucCase_First.Dock = DockStyle.Fill;
                        //}
                        //else
                        //{
                        //    ucCase_First.InitFirstCase_Page();
                        //    //xp没进入load事件
                        //    ucCase_First.InitPatientInfo();
                        //    // 获取病人信息
                        //    DataTable CoverInfo = ucCase_First.GetCoverInfo();
                        //    #region 病人信息的必填项检查
                        //    DataRow dr = CoverInfo.Rows[0];
                        //    #endregion

                        //    // 获取诊断信息
                        //    DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                        //    #region 主要诊断必须填写入院病情和转归情况
                        //    dr = Diagnose.Rows[0];
                        //    #endregion


                        //    // 获取手术信息
                        //    DataTable Operation = ucCase_First.GetOperation();

                        //    // 获取病案质量信息
                        //    DataTable Quality = ucCase_First.GetQuality();

                        //    // 获取病案首页的一些杂项
                        //    DataTable Temp = ucCase_First.GetTemp();
                        //    dr = Temp.Rows[0];
                        //    #region 杂项表的必填项控制
                        //    #endregion

                        //    DataTable cost = ucCase_First.GetCost();

                        //    // 构造 DataSet
                        //    DataSet ds_case = new DataSet();
                        //    ds_case.Tables.Add(CoverInfo);
                        //    ds_case.Tables.Add(Diagnose);
                        //    ds_case.Tables.Add(Operation);
                        //    ds_case.Tables.Add(Quality);
                        //    ds_case.Tables.Add(Temp);
                        //    ds_case.Tables.Add(cost);

                        //    Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                        //    ucprint.Dock = DockStyle.Fill;
                        //    App.UsControlStyle(ucprint);
                        //    tabctpnDoc.Controls.Add(ucprint);
                        //}
                        //App.SetToolButtonByUser("tsbtnCommit", false);
                        ////App.UsControlStyle(ucCase_First);
                        //isCustom = true;
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
            //当前打开文书是否有新增操作未保存,如果没有则关闭当前文书打开新文书
            if (tctlDoc.Tabs.Count > 0)
            {
                for (int i = 0; i < dgvKouFen.Rows.Count; i++)
                {
                    if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N")
                    {
                        App.Msg("请点击确定按钮或关闭已打开文书！");
                        return;
                    }
                }
                //tctlDoc.Tabs[0].Dispose();
                //tctlDoc.Tabs.Clear();

                //非定制文书同时只能打开一个页签（覆盖） 定制文书可以打开多个页签
                List<DevComponents.DotNetBar.TabItem> tabs = new List<TabItem>();
                foreach (DevComponents.DotNetBar.TabItem tab in tctlDoc.Tabs)
                {
                    Patient_Doc doc = tab.Tag as Patient_Doc;
                    if (doc == null)
                    {
                        continue;
                    }
                    else
                    {
                        tabs.Add(tab);
                    }
                }

                foreach (DevComponents.DotNetBar.TabItem tab in tabs)
                {
                    tctlDoc.Tabs.Remove(tab);
                }

            }
            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            // 获得当前时间，精确到分钟
            // string time = string.Format("{0:g}", DateTime.Now);
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);
            page.Click += new EventHandler(page_Click);

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
                            if (isRead != "Y")
                            {
                                text.MyDoc.OnBackPFId += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFId(MyDoc_OnBackPFId);                                
                            }
                        
                            text.MyDoc.Menus.PnlMenus.Visible = false;//隐藏工具栏
                            text.MyDoc.IgnoreLine = NeglectLine;

                            if (text.MyDoc.OwnerControl.ContextMenuStrip != null)
                            {
                                ToolStripMenuItem bapfButton = new ToolStripMenuItem("质控信息");
                                text.MyDoc.OwnerControl.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { bapfButton });
                                bapfButton.Click += new EventHandler(bapfButton_Click);
                            }

                            //除质控信息外其他隐藏
                            foreach (ToolStripItem item in text.MyDoc.OwnerControl.ContextMenuStrip.Items)
                            {
                                if (item.Text == "质控信息" && isRead != "Y")
                                    item.Visible = true;
                                else
                                    item.Visible = false;

                            }

                            CurrentFrmText = text;        

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
                            text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                            text.MyDoc.Locked = true;

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
                            DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
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

                    frmText text = new frmText(pdoc.Textkind_id, 0, 0, textTitle, tid, currentPatient, true, true, Record_Time, Record_Content);

                    if (isRead != "Y")
                    {
                        text.MyDoc.OnBackPFId += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFId(MyDoc_OnBackPFId);

                       
                    }                 
                    text.MyDoc.Menus.PnlMenus.Visible = false;//隐藏工具栏

                    if (text.MyDoc.OwnerControl.ContextMenuStrip != null)
                    {
                        ToolStripMenuItem bapfButton = new ToolStripMenuItem("质控信息");
                        text.MyDoc.OwnerControl.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { bapfButton });
                        bapfButton.Click += new EventHandler(bapfButton_Click);
                    }

                    foreach (ToolStripItem item in text.MyDoc.OwnerControl.ContextMenuStrip.Items)
                    {
                        if (item.Text == "质控信息"&&isRead!="Y")
                            item.Visible = true;
                        else
                            item.Visible = false;

                    }

                    CurrentFrmText = text;
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
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;//规定新页眉
                    text.MyDoc.IgnoreLine = NeglectLine;
                    text.MyDoc.Locked = true;


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
                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + tid + "", 0, "CONTENT");
                    if (content == null || content == "")
                    {
                        content = App.DownLoadFtpPatientDoc(tid + ".xml", currentPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                    }             

                    tmpxml.LoadXml(content);

                    DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
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
        /// 文书注释按钮触发事件
        /// </summary>
        /// <param name="id">注释ID</param>
        /// <param name="action">0、查看；1、删除</param>
        void MyDoc_OnBackPFId(string id, int action)
        {
            if (DelMark != null)
            {
                DelMark(id, action);
            }
        }

        void bapfButton_Click(object sender, EventArgs e)
        {
            /********改成编辑器右键传文书类型TODO**********/
            frmRepartRule frm = new frmRepartRule(CurrentFrmText.MyDoc.Us.TextKind_id.ToString());
            frm.AddMark += new frmRepartRule.RefEventHandler(Add);
            frm.ShowDialog();
        }

        private void Add(string mark_id, string item, string item_con, string item_score, string did)
        {
            if (AddMark != null)
            {
                AddMark(mark_id,item,item_con,item_score,did);
            }
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
                        DevComponents.DotNetBar.TabControlPanel tab = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                        frmText t = tab.Controls[0] as frmText;
                        if (t != null)
                        {                            
                            for (int i = dgvKouFen.Rows.Count - 1; i >= 0; i--)
                            {
                                if ((dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N" || dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D") && dgvKouFen.Rows[i].Cells["docId"].Value.ToString() == t.MyDoc.Us.Tid.ToString())
                                {
                                    if (!App.Ask("文书未保存，确定要关闭吗？"))
                                    {
                                        return;
                                    }

                                    if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N")
                                    { dgvKouFen.Rows.RemoveAt(i); }
                                    else if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D")
                                    {
                                        dgvKouFen.Rows[i].Cells["isNew"].Value = "Y";
                                        dgvKouFen.Rows[i].Visible = true;
                                    }

                                    if (DelScore != null)
                                        DelScore();                             
                                }
                            }
                            tctlDoc.Tabs.Remove(item);                        
                        }
                        else
                        {
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
            RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//展开所有文书节点

        }
        #endregion

        /// <summary>
        ///行标题 行号 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvKouFen_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        /// <summary>
        /// 右键删除规则，删除对应文书中的注释
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvKouFen.SelectedRows.Count > 0)
            {
                if (App.Ask("确定删除“" + dgvKouFen.SelectedRows[0].Cells["文书名称"].Value.ToString() + "”文书中“" + dgvKouFen.SelectedRows[0].Cells["评分项目"].Value.ToString() + "”扣分项？"))
                {
                    save_doc(dgvKouFen.SelectedRows[0].Cells["docId"].Value.ToString(), dgvKouFen.SelectedRows[0].Cells["id"].Value.ToString());
                    dgvKouFen.Rows.RemoveAt(dgvKouFen.SelectedRows[0].Index);
                    
                    if (DelScore != null)
                        DelScore();
                }

                //删除之后还需点击保存按钮
            }
        }

        /// <summary>
        /// 删除文书注释，保存文书
        /// </summary>
        private void save_doc(string tid, string mark_id)
        {
            try
            {
                //如已打开 刷新编辑器内容
                for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                {
                    Patient_Doc doc = tctlDoc.Tabs[i].Tag as Patient_Doc;
                    if (doc.Id.ToString() == tid)
                    {
                        frmText frm = tctlDoc.Tabs[i].AttachedControl.Controls[0] as frmText;
                        foreach (var ele in frm.MyDoc.Elements)
                        {
                            if (ele is ZYTextBapfMark)
                            {
                                ZYTextBapfMark mark = (ZYTextBapfMark)ele;
                                if (mark.Value == mark_id)
                                {
                                    mark.Parent.ChildElements.Remove(mark);
                                }
                            }
                        }
                        frm.MyDoc.ContentChanged();
                    }
                }

                //取出clob
                string strSql_Doc = "select a.content from T_PATIENT_DOC_COLB a where a.tid='" + tid + "'";
                DataSet ds_Doc = App.GetDataSet(strSql_Doc);
                string content_source = "";
                XmlDocument tmpxml_source = new XmlDocument();
                tmpxml_source.PreserveWhitespace = true;
                XmlNodeList list;
                content_source = ds_Doc.Tables[0].Rows[0]["content"].ToString();
                if (content_source == "" || content_source == null)
                {
                    content_source = App.DownLoadFtpPatientDoc(tid + ".xml", currentPatient.Id.ToString());
                }
                tmpxml_source.LoadXml(content_source);
                //修改clob
                list = tmpxml_source.GetElementsByTagName("bapf");
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string aa = list[i].Attributes["value"].Value.ToString();
                        if (aa == mark_id)
                        {
                            list[i].ParentNode.RemoveChild(list[i]);
                        }
                    }
                }

                //提交clob
                //重新生成XML文件
                //App.UpLoadFtpPatientDoc(tmpxml_source.OuterXml, tid + ".xml", currentPatient.Id.ToString());

                // 更新数据库
                String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", tid);
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = tmpxml_source.OuterXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                App.ExecuteSQL(sql_clob, xmlPars);
                App.ExecuteSQL("delete T_DEDUCT_SCORE where id='" + dgvKouFen.SelectedRows[0].Cells["id"].Value.ToString() + "'");
            }
            catch { }
        }

        /// <summary>
        /// 定位到文书注释-如所属文书已经打开则定位，未打开不管
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvKouFen_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    string strMark_id = dgvKouFen.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    frmText text = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    if (text.MyDoc.Us.Tid.ToString() == dgvKouFen.Rows[e.RowIndex].Cells["docId"].Value.ToString())
                    {
                        foreach (var ele in text.MyDoc.Elements)
                        {
                            if (ele is ZYTextBapfMark)
                            {
                                ZYTextBapfMark mark = (ZYTextBapfMark)ele;
                                if (mark.Value == strMark_id)
                                {
                                    Point point = new Point(mark.RealLeft, mark.RealTop);
                                    point = text.MyDoc.OwnerControl.ViewPointToClient(point.X, point.Y);
                                    text.MyDoc.OwnerControl.AutoScrollPosition = new Point(text.MyDoc.OwnerControl.AutoScrollPosition.X/2+point.X/2, point.Y - text.MyDoc.OwnerControl.AutoScrollPosition.Y);
                                    text.MyDoc.Content.MoveSelectStart(text.MyDoc.Elements.IndexOf(mark));
                                    text.MyDoc.OwnerControl.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
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
                        this.groupBox1.Visible = true;
                    }
                    else
                    {
                        this.groupBox1.Visible = false;
                    }
                }
            }
        }

    }
}
