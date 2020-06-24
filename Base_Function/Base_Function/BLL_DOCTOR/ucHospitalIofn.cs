using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using System.Collections;
using C1.Win.C1FlexGrid;
using Bifrost.HisInstance;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;

using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_DOCTOR.NApply_Medical_Record;
using Base_Function.BLL_DOCTOR.Patient_Action_Manager;
using Bifrost_Doctor.Consultation_Manager;
using Base_Function.BLL_DOCTOR.SurgeryManager;
using Base_Function.BLL_DOCTOR.Archive;
using Base_Function.BLL_DOCTOR.AppForm;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;

namespace Base_Function.BLL_DOCTOR
{
    public partial class ucHospitalIofn : UserControl
    {
        private string strflag = ""; //是否进行小卡刷新
        private int intflag = 3;
        //操作后，重新刷新病人小卡界面
        public delegate void DelerefInpatient(UcInhospital ucinhospital);
        //操作后，重新刷新病人小卡界面
        public delegate void DelerefInpatient2(InPatientInfo inpatient, UCPictureBox ucPicture);
        public delegate void CardToolTipHide(UCPictureBox ucPicture);
        public NodeCollection nodetemp = null;
        /// <summary>
        /// 当前病人
        /// </summary>
        private InPatientInfo inpat;
        /// <summary>
        /// 目标床号病人
        /// </summary>
        InPatientInfo old_Inpatient = null;
        /// <summary>
        /// 小卡对应的病人树节点
        /// </summary>
        private DevComponents.AdvTree.Node nodeInpatient = new DevComponents.AdvTree.Node();
        private UCPictureBox CurrentucPictureBox;
        //DataGridViewX flgView = null;
        DataGridView flgView = null;
        private static string nodeText = null;
        /// <summary>
        /// 获得当前选中的节点集合
        /// </summary>
        private NodeCollection selectNodes = null;
        /// <summary>
        /// 病人树
        /// </summary>
        private AdvTree patientTree = new AdvTree();
        //鼠标移到小卡显示动画的效果
        //public delegate void DeleFlash(UcInhospital ucinhospital);
        //private bool ChangeColor = false;
        /// <summary>
        /// 树当前选中的节点名称
        /// </summary>
        private string selectText = "";
        /// <summary>
        /// 保存姓名模糊查询的病人对象
        /// </summary>
        //ArrayList inpatientList = new ArrayList();
        MBindingList<InPatientInfo> inpatientList = new MBindingList<InPatientInfo>();
        public ucHospitalIofn()
        {
            InitializeComponent();
            flgView = new DataGridView();
            gbxInpatientInfo.Controls.Add(flgView);
        }


        /// <summary>
        /// 刷新小卡
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="nodeTemp"></param>
        /// <param name="selectnode"></param>
        public void HospitalIni(NodeCollection nodes, NodeCollection nodeTemp, DevComponents.AdvTree.Node sectionnode, string nodename, int intFlag, AdvTree patientTree)
        {          
            nodeText = nodename;
            this.nodetemp = nodeTemp;
            this.selectText = nodename;
            this.selectNodes = nodes;
            this.patientTree = patientTree;
            ArrayList list = new ArrayList();
            //if (strflag == nodename && intFlag == intflag)
            //{
            //    return;
            //}
            strflag = nodename;
            this.intflag = intFlag;
            //int x = 5;
            //int y = 5;
            flowLayoutPanel1.Controls.Clear();
            string patient_ids = "";
            try
            {
                foreach (DevComponents.AdvTree.Node node in nodes)
                {
                    if (node.Tag != null)
                    {
                        if (node.Tag.GetType().ToString().Contains("InPatientInfo"))
                        {
                            InPatientInfo inpatinet = (InPatientInfo)node.Tag;
                            //UcInhospital hospitalInfo = new UcInhospital((InPatientInfo)node.Tag, nodeTemp);
                            list.Add(inpatinet);
                            if (patient_ids == "")
                            {
                                patient_ids = inpatinet.Id.ToString();
                            }
                            else
                            {
                                patient_ids = patient_ids + "," + inpatinet.Id.ToString();
                            }
                        }
                    }
                }

                /*
                 * 显示该病区该科室所有的空床
                 *
                 */
                if (sectionnode != null)
                {

                    string Sql_Empty_Bed = null;
                    if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                    {

                        Sql_Empty_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a " +
                                         " left join t_sickroominfo b on a.srid = b.srid " +
                                        "  left join t_sickareainfo c on b.said = c.said " +
                                        "  where  a.state=75 and a.enableflag='Y' and a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by bed_no";

                    }
                    else
                    {
                        //Sql_Empty_Bed = "select distinct(a.bed_id),a.* from T_SICKBEDINFO a inner join t_section_area b on a.said=b.said " +
                        //                "where a.sid = " + sectionnode.Name + " and a.state=75 and a.enableflag='Y' order by cast(a.bed_id as number)";
                    }
                    DataSet ds = App.GetDataSet(Sql_Empty_Bed);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt != null)
                        {

                            //DataView dv = dt.DefaultView;
                            //dv.Sort = "bed_id asc";
                            foreach (DataRow row in dt.Rows)
                            {
                                int bed_id = Convert.ToInt32(row["bed_id"]);
                                string bed_no = row["bed_no"].ToString();
                                InPatientInfo inpatient = new InPatientInfo();
                                inpatient.Id = 0;
                                inpatient.Sick_Bed_Id = bed_id;
                                inpatient.Sick_Bed_Name = bed_no;
                                //UcInhospital hospitalInfo = new UcInhospital(inpatient, nodeTemp);
                                list.Add(inpatient);

                            }
                        }
                    }
                    //if (App.UserAccount.CurrentSelectRole.Role_type == "N")//只在护士站从新排序
                    //{
                    //    //list.Sort(new InPatientInfo());
                    //}
                }


                if (patient_ids == "")
                {
                    patient_ids = "0";
                }

                //string sqldiagnose = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='403' and Patient_Id in (" + patient_ids + ") order by diagnose_sort asc";//初步诊断
                //string sqldiagnose2 = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='408' and Patient_Id in (" + patient_ids + ") order by diagnose_sort asc";//入院诊断
                //Class_Table[] tables = new Class_Table[2];
                //tables[0] = new Class_Table();
                //tables[0].Sql = sqldiagnose;
                //tables[0].Tablename = "chubu";

                //tables[1] = new Class_Table();
                //tables[1].Sql = sqldiagnose2;
                //tables[1].Tablename = "ruyuan";

                //DataSet dsdiagnose = App.GetDataSet(tables);
                string sqldiagnose = "select a.diagnose_name,a.Patient_Id from t_diagnose_item a "
           //+ " inner join t_patients_doc c on a.doc_id=c.tid "
           //+ " inner join t_text b on a.text_id=b.id and (b.textname  like '%入院记录%' or b.textname like '%入院死亡记录%' or b.textname like '%住院志%')"
           + " where a.diagnose_type='403'"
           + " and a.patient_id in(" + patient_ids + ")"
           + "order by a.patient_id,a.diagnose_sort asc";

                DataSet dsdiagnose = App.GetDataSet(sqldiagnose);

                this.flowLayoutPanel1.SuspendLayout();
                for (int j = 0; j < list.Count; j++)
                {
                    InPatientInfo inpatient = list[j] as InPatientInfo;
                    DataRow[] rows = dsdiagnose.Tables[0].Select("Patient_Id=" + inpatient.Id + "");
                    string diagnose = "";
                    if (rows.Length > 0)
                        diagnose = rows[0][0].ToString();
                    //DataRow[] rows = dsdiagnose.Tables[0].Select("Patient_Id=" + inpatient.Id + "");
                    //string diagnose = "";
                    //if (rows.Length > 0)
                    //    diagnose = rows[0][0].ToString();
                    ////如果初步诊断为空，则读取入院诊断
                    //if (diagnose == "")
                    //{
                    //    rows = dsdiagnose.Tables["ruyuan"].Select("Patient_Id=" + inpatient.Id + "");
                    //    if (rows.Length > 0)
                    //    {
                    //        diagnose = rows[0][0].ToString();
                    //    }
                    //}
                    UCPictureBox pictureBox = new UCPictureBox(inpatient, nodeTemp, diagnose);
                    pictureBox.EventReflash += new DelerefInpatient2(pictureBox_EventReflash);
                    pictureBox.ToolTipHide += new CardToolTipHide(superToolTip_Hide);
                    pictureBox.Name = inpatient.Id.ToString();
                    pictureBox.ContextMenuStrip = contextMenuStrip1;
                    pictureBox.Tag = inpatient;
                    //panel1.Controls.Add(pictureBox);
                    //panel1.Controls.Add(hospitalInfo); 
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }


                // 给panel里面的用户控件统一排列位置。            
                //ReLacation(flowLayoutPanel1);
                this.flowLayoutPanel1.ResumeLayout();
                //将His中所在科室与电子病历中不一致的小卡背景色设为红色
                if (selectText != "待转入病人" && selectText != "已出院病人" && selectText != "已转出病人")
                {
                    SetCardByTurnSection();
                }
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                {
                    //btnFB.Visible = true;//评分反馈
                    SetCardByDocRight();
                }
                //panel1.Refresh();
                flowLayoutPanel1.Visible = true;
            }
            catch(Exception ex)
            { App.Msg(ex.Message); }
        }
        /// <summary>
        /// 刷新小卡
        /// </summary>
        /// <param name="patientnodes"></param>
        /// <param name="nodeTemp"></param>
        /// <param name="nodename"></param>
        /// <param name="intFlag"></param>
        public void HospitalIni(NodeCollection patientnodes, NodeCollection nodeTemp, string nodename, int intFlag, AdvTree patientTree)
        {           
            nodeText = nodename;
            this.nodetemp = nodeTemp;
            this.selectText = nodename;
            this.selectNodes = patientnodes;
            this.patientTree = patientTree;
            ArrayList list = new ArrayList();
            //if (strflag == nodename && intFlag == intflag)
            //{
            //    return;
            //}
            strflag = nodename;
            intflag = intFlag;
            //int x = 5;
            //int y = 5;
            flowLayoutPanel1.Controls.Clear();
            string patient_ids = "";
            try
            {
                foreach (DevComponents.AdvTree.Node node in patientnodes)
                {
                    foreach (DevComponents.AdvTree.Node item in node.Nodes)
                    {

                        if (item.Tag != null)
                        {
                            if (item.Tag.GetType().ToString().Contains("InPatientInfo"))
                            {
                                InPatientInfo inpatient = (InPatientInfo)item.Tag;
                                list.Add(inpatient);
                                if (patient_ids == "")
                                {
                                    patient_ids = inpatient.Id.ToString();
                                }
                                else
                                {
                                    patient_ids = patient_ids + "," + inpatient.Id.ToString();
                                }
                            }
                        }
                    }

                }

                /*
                 * 显示该病区所有的空床
                 *
                 */
                string Sql_Empty_Bed = null;
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                {
                    //Sql_Empty_Bed = "select distinct(a.bed_id), a.* from T_SICKBEDINFO a inner join t_section_area b on a.said=b.said " +
                    //                "where a.sid = " + App.UserAccount.CurrentSelectRole.Section_Id +
                    //                " and a.state=75 and a.enableflag='Y' order by cast(a.bed_id as number)";

                }
                else
                {
                    Sql_Empty_Bed = "select a.bed_id,a.bed_no from t_sickbedinfo a " +
                                    " left join t_sickroominfo b on a.srid = b.srid " +
                                   "  left join t_sickareainfo c on b.said = c.said " +
                                   "  where  a.state=75 and a.enableflag='Y' and a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by bed_no";
                }
                DataSet ds = App.GetDataSet(Sql_Empty_Bed);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int bed_id = Convert.ToInt32(row["bed_id"]);
                            string bed_no = row["bed_no"].ToString();
                            InPatientInfo inpatient = new InPatientInfo();
                            inpatient.Id = 0;
                            inpatient.Sick_Bed_Id = bed_id;
                            inpatient.Sick_Bed_Name = bed_no;
                            list.Add(inpatient);
                        }
                    }
                }
                //if (App.UserAccount.CurrentSelectRole.Role_type == "N")//只在护士站重新排序
                //{
                //    list.Sort(new InPatientInfo());
                //}

                ////string sql = "select diagnose_name from t_diagnose_item  where in_patient_id='" + inpat.PId + "' and " +
                ////       " diagnose_type='408'";

                if (patient_ids == "")
                {
                    patient_ids = "0";
                }
                //string sqldiagnose = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='403' and Patient_Id in (" + patient_ids + ")";//初步诊断
                //string sqldiagnose2 = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='408' and Patient_Id in (" + patient_ids + ")";//入院诊断
                //Class_Table[] tables = new Class_Table[2];
                //tables[0] = new Class_Table();
                //tables[0].Sql = sqldiagnose;
                //tables[0].Tablename = "chubu";

                //tables[1] = new Class_Table();
                //tables[1].Sql = sqldiagnose2;
                //tables[1].Tablename = "ruyuan";

                string sqldiagnose = "select a.diagnose_name,a.Patient_Id from t_diagnose_item a "
                           + " inner join t_patients_doc c on a.doc_id=c.tid "
                           + " inner join t_text b on a.text_id=b.id and (b.textname  like '%入院记录%' or b.textname like '%入院死亡记录%' or b.textname like '%住院志%')"
                           + " where a.diagnose_type='403'"
                           + " and a.patient_id in(" + patient_ids + ")"
                           + "order by a.patient_id,a.diagnose_sort asc";

                DataSet dsdiagnose = App.GetDataSet(sqldiagnose);
                this.flowLayoutPanel1.SuspendLayout();

                for (int j = 0; j < list.Count; j++)
                {
                    InPatientInfo inpatient = list[j] as InPatientInfo;
                    string diagnose = "";

                    DataRow[] rows = dsdiagnose.Tables[0].Select("Patient_Id=" + inpatient.Id + "");
                    if (rows.Length > 0)
                        diagnose = rows[0][0].ToString();

                    //DataRow[] rows = dsdiagnose.Tables["chubu"].Select("Patient_Id=" + inpatient.Id + "");
                    //if (rows.Length > 0)
                    //    diagnose = rows[0][0].ToString();
                    ////如果初步诊断为空，则读取入院诊断
                    //if (diagnose == "")
                    //{
                    //    rows = dsdiagnose.Tables["ruyuan"].Select("Patient_Id=" + inpatient.Id + "");
                    //    if (rows.Length > 0)
                    //    {
                    //        diagnose = rows[0][0].ToString();
                    //    }
                    //}

                    UCPictureBox pictureBox = new UCPictureBox(inpatient, nodeTemp, diagnose);
                    pictureBox.EventReflash += new DelerefInpatient2(pictureBox_EventReflash);
                    pictureBox.ToolTipHide += new CardToolTipHide(superToolTip_Hide);
                    pictureBox.ContextMenuStrip = contextMenuStrip1;
                    pictureBox.Name = inpatient.Id.ToString();
                    pictureBox.Tag = inpatient;
                    //pictureBox.EventRefinpatient += new DelerefInpatient2(pictureBox_EventRefinpatient);
                    flowLayoutPanel1.Controls.Add(pictureBox);
                    //panel1.Controls.Add(hospitalInfo);                  
                }
                // 给panel里面的用户控件统一排列位置。
                //ReLacation(flowLayoutPanel1);
                this.flowLayoutPanel1.ResumeLayout();
                //panel1.Refresh();
                //将His中所在科室与电子病历中不一致的小卡背景色设为红色
                if (selectText != "待转入病人" && selectText != "已出院病人" && selectText != "已转出病人")
                {
                    SetCardByTurnSection();
                }
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                {
                    SetCardByDocRight();
                }
                flowLayoutPanel1.Visible = true;
            }
            catch
            { }
        }


        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Refresh();
        }
        /// <summary>
        /// 姓名模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            inpatientList.Clear();
            if (DataInit.ViewSwitch == 0)  //病人小卡
            {
                ViewCard(selectNodes, false);
            }
            else
            {
                InpatientViewList(selectNodes, false, nodeText);
            }
        }
        /// <summary>
        /// 显示小卡片
        /// </summary>
        /// <param name="nodes"></param>
        private void ViewCard(NodeCollection nodes, bool isSwitch)
        {
            string pName = txtName.Text.Trim();
            string pid = txtPid.Text.Trim();
            GetInpatients(nodes, isSwitch, pName, pid);
            string patient_ids = "0";
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                if (node.Tag != null)
                {
                    if (node.Tag.GetType().ToString().Contains("InPatientInfo"))
                    {
                        InPatientInfo inpatinet = (InPatientInfo)node.Tag;
                        patient_ids = patient_ids + "," + inpatinet.Id.ToString();
                        
                    }
                }
            }
            //inpatientList.Sort(new InPatientInfo());
            //string sqldiagnose = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='403'";//初步诊断
            //string sqldiagnose2 = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='408'";//入院诊断
            string sqldiagnose = "select a.diagnose_name,a.Patient_Id from t_diagnose_item a "
                    + " inner join t_patients_doc c on a.doc_id=c.tid "
                    + " inner join t_text b on a.text_id=b.id and (b.textname  like '%入院记录%' or b.textname like '%入院死亡记录%' or b.textname like '%住院志%')"
                    + " where a.diagnose_type='403'"
                    + " and a.patient_id in(" + patient_ids + ")"
                    + "order by a.patient_id,a.diagnose_sort asc";
            DataSet dsdiagnose = App.GetDataSet(sqldiagnose);
            //Class_Table[] tables = new Class_Table[2];
            //tables[0] = new Class_Table();
            //tables[0].Sql = sqldiagnose;
            //tables[0].Tablename = "chubu";

            //tables[1] = new Class_Table();
            //tables[1].Sql = sqldiagnose2;
            //tables[1].Tablename = "ruyuan";
            //DataSet dsdiagnose = App.GetDataSet(tables);
            for (int i = 0; i < inpatientList.Count; i++)
            {
                InPatientInfo inpatient = inpatientList[i] as InPatientInfo;
                DataRow[] rows = dsdiagnose.Tables[0].Select("Patient_Id=" + inpatient.Id + "");
                string diagnose = "";
                if (rows.Length > 0)
                    diagnose = rows[0][0].ToString();

                //DataRow[] rows = dsdiagnose.Tables["chubu"].Select("Patient_Id=" + inpatient.Id + "");
                //string diagnose = "";
                //if (rows.Length > 0)
                //    diagnose = rows[0][0].ToString();
                ////如果初步诊断为空，则读取入院诊断
                //if (diagnose == "")
                //{
                //    rows = dsdiagnose.Tables["ruyuan"].Select("Patient_Id=" + inpatient.Id + "");
                //    if (rows.Length > 0)
                //    {
                //        diagnose = rows[0][0].ToString();
                //    }
                //}
                UCPictureBox pictureBox = new UCPictureBox(inpatient, nodetemp, diagnose);
                pictureBox.EventReflash += new DelerefInpatient2(pictureBox_EventReflash);
                pictureBox.ToolTipHide += new CardToolTipHide(superToolTip_Hide);
                pictureBox.ContextMenuStrip = contextMenuStrip1;
                pictureBox.Name = inpatient.Id.ToString();
                pictureBox.Tag = inpatient;
                flowLayoutPanel1.Controls.Add(pictureBox);

            }
            // 给panel里面的用户控件统一排列位置。
            ReLacation(flowLayoutPanel1);
            flowLayoutPanel1.Refresh();

           
        }

        /// <summary>
        /// 给panel里面的用户控件统一排列位置。
        /// </summary>
        /// <param name="panel"></param>
        private void ReLacation(Panel panel)
        {

            panel.Width = gbxInpatientInfo.Width;
            int x = 5, y = 5;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (flowLayoutPanel1.Width - x >= 180)  //当剩余位置不足以放下一个小卡时换行
                {
                    panel.Controls[i].Location = new Point(x, y);
                    x += panel.Controls[i].Width + 5;
                }
                else
                {
                    x = 5;
                    y += panel.Controls[i].Height + 5;
                    panel.Controls[i].Location = new Point(x, y);
                    x += panel.Controls[i].Width + 5;
                }
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            //ReLacation(panel1);

        }
        /// <summary>
        /// 重新刷新小卡
        /// </summary>
        /// <param name="ucInhospital"></param>
        public void hospitalInfo_EventRefinpatient(UcInhospital ucInhospital)
        {
            this.flowLayoutPanel1.Controls.Remove(ucInhospital);
            //ReLacation(this.flowLayoutPanel1);
        }
        public void pictureBox_EventRefinpatient(UCPictureBox ucPictureBox)
        {
            this.flowLayoutPanel1.Controls.Remove(ucPictureBox);
            //ReLacation(this.flowLayoutPanel1);
            this.Visible = true;
        }

        #region 菜单方法
        private void 入区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId; ;
                try
                {
                    frmInArea zone = new frmInArea(inpat);
                    zone.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        if (node != null)
                        {
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnSection_patient")
                                {
                                    for (int j = 0; j < nodetemp[0].Nodes[i].Nodes.Count; j++)
                                    {
                                        DevComponents.AdvTree.Node tempNode = nodetemp[0].Nodes[i].Nodes[j];
                                        if (tempNode.Name == inpat.Section_Id.ToString())
                                        {
                                            node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                            //把当前选中的节点移到科室病人节点下
                                            DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                                        }
                                    }
                                }
                            }
                            //foreach (DevComponents.AdvTree.Node tempNode in nodetemp[0].Nodes["tnSection_patient"].Nodes)
                            //{
                            //    if (tempNode.Name == inpat.Section_Id.ToString())
                            //    {
                            //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                            //        //把当前选中的节点移到科室病人节点下
                            //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                            //    }
                            //}
                        }
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            pictureBox_EventRefinpatient(CurrentucPictureBox);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string content = name + "," + sex + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("入区异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "入区", "", pid, patient_Id);
            }
        }

        private void 转入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmTurn_In inAction = new frmTurn_In(inpat);
                    inAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        if (node != null)
                        {
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnSection_patient")
                                {
                                    for (int j = 0; j < nodetemp[0].Nodes[i].Nodes.Count; j++)
                                    {
                                        DevComponents.AdvTree.Node tempNode = nodetemp[0].Nodes[i].Nodes[j];
                                        if (tempNode.Text.Equals(inpat.Section_Name))
                                        {
                                            node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                            //把当前选中的节点移到科室病人节点下
                                            DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                                        }
                                    }
                                }
                            }
                            //foreach (TreeNode tempNode in nodetemp[0].Nodes["tnSection_patient"].Nodes)
                            //{
                            //    if (tempNode.Text.Equals(inpat.Section_Name))
                            //    {
                            //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                            //        //把当前选中的节点移到科室病人节点下
                            //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                            //    }
                            //}
                        }
                        //自定义刷新事件
                        // EventRefinpatient(this);
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            //pictureBox_EventRefinpatient(CurrentucPictureBox);
                            GetInpatientRefCard(inpat);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                        //转入成功删除病人的授权
                        string sql_Cancle = "delete from t_set_text_rights where patient_id=" + inpat.Id;
                        App.ExecuteSQL(sql_Cancle);
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("转入异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "转入", "", pid, patient_Id);
            }
        }

        private void 退回转出科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmCancleTurnIn outAction = new frmCancleTurnIn(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        this.Visible = false;
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            pictureBox_EventRefinpatient(CurrentucPictureBox);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("退回转出科室异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "退回转出科室", "", pid, patient_Id);
            }
        }

        private void 修改入区时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmUpdate_InArea_Time outAction = new frmUpdate_InArea_Time(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        if (DataInit.ViewSwitch == 0)
                        {
                            CurrentucPictureBox.Img(inpat);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("修改入区时间异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "修改入区时间", "", pid, patient_Id);
            }
        }

        private void 换床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmUpdateBed frmBed = new frmUpdateBed(inpat);
                    frmBed.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        //DataInit.UpdatPatientsNodes(nodeInpatient,4);
                        //if (Test.ViewSwitch == 0)
                        //{
                        //    int sick_id = frmBed.Target_Bed_Id;
                        //    string sick_No = frmBed.Target_Bed_No;
                        //    //要换的床的病人
                        //    old_Inpatient = GetInpatientByBedId(sick_id);
                        //    if (old_Inpatient == null) //空床
                        //    {
                        //        old_Inpatient = new InPatientInfo();
                        //        old_Inpatient.Id = 0;
                        //        old_Inpatient.Sick_Bed_Id = sick_id;
                        //        old_Inpatient.Sick_Bed_Name = sick_No;
                        //    }
                        //    RefCardByUpdateBed(inpat, frmBed.Target_Bed_Id, frmBed.Target_Bed_No, ref old_Inpatient, frmBed.IsEmpty);
                        //}
                        //else
                        //{
                        //    strflag = "";
                        //    old_Inpatient = GetPatientByList(frmBed.Target_Bed_Id);
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefAllTree();
                            main.RefCard();
                        //}
                        //TreeNode node = DataInit.RefCardTree(nodetemp, inpat);
                        //if (node != null)
                        //{
                       //RefTree(nodetemp, inpat, old_Inpatient);
                        //}
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("换床异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "换床", "", pid, patient_Id);
            }
        }
        /// <summary>
        /// 刷新树
        /// </summary>
        /// <param name="nodes">树节点集合</param>
        /// <param name="inpat">当前病人</param>
        /// <param name="old_Inpatient">目标病人</param>
        public void RefTree(NodeCollection nodes, InPatientInfo inpat, InPatientInfo old_Inpatient)
        {
            for (int m = 0; m < nodes[0].Nodes.Count; m++)
            {
                if (nodes[0].Nodes[m].Name == "tnSection_patient")
                {
                    for (int n = 0; n < nodes[0].Nodes[m].Nodes.Count; n++)
                    {
                        DevComponents.AdvTree.Node tempNode = nodes[0].Nodes[m].Nodes[n];
                        if (tempNode.Name == inpat.Section_Id.ToString())
                        {
                            for (int i = 0; i < tempNode.Nodes.Count; i++)
                            {
                                InPatientInfo iPInfo = tempNode.Nodes[i].Tag as InPatientInfo;
                                if (iPInfo.Id == inpat.Id)
                                {
                                    if (old_Inpatient.Id != 0)//不是空床
                                    {
                                        tempNode.Nodes[i].Text = old_Inpatient.Sick_Bed_Name + "  " + old_Inpatient.Patient_Name;
                                        tempNode.Nodes[i].Tag = null;
                                        tempNode.Nodes[i].Tag = old_Inpatient;
                                        if (old_Inpatient.Gender_Code == "1")
                                        {
                                            tempNode.Nodes[i].ImageIndex = 12;
                                            //tempNode.Nodes[i].SelectedImageIndex = 12;
                                        }
                                        else
                                        {
                                            tempNode.Nodes[i].ImageIndex = 13;
                                            //tempNode.Nodes[i].SelectedImageIndex = 13;
                                        }
                                    }
                                    else  //空床
                                    {
                                        tempNode.Nodes[i].Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                        tempNode.Nodes[i].Tag = null;
                                        tempNode.Nodes[i].Tag = inpat;
                                        if (inpat.Gender_Code == "1")
                                        {
                                            tempNode.Nodes[i].ImageIndex = 12;
                                            //tempNode.Nodes[i].SelectedImageIndex = 12;
                                        }
                                        else
                                        {
                                            tempNode.Nodes[i].ImageIndex = 13;
                                            //tempNode.Nodes[i].SelectedImageIndex = 13;
                                        }
                                    }
                                    //node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                    ////把当前选中的节点移到科室病人节点下
                                    //DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                                }
                                else if (iPInfo.Id == old_Inpatient.Id)
                                {
                                    tempNode.Nodes[i].Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                    tempNode.Nodes[i].Tag = null;
                                    tempNode.Nodes[i].Tag = inpat;
                                    if (inpat.Gender_Code == "1")
                                    {
                                        tempNode.Nodes[i].ImageIndex = 12;
                                        //tempNode.Nodes[i].SelectedImageIndex = 12;
                                    }
                                    else
                                    {
                                        tempNode.Nodes[i].ImageIndex = 13;
                                        //tempNode.Nodes[i].SelectedImageIndex = 13;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
            //{
            //    if (tempNode.Name == inpat.Section_Id.ToString())
            //    {
            //        for (int i = 0; i < tempNode.Nodes.Count; i++)
            //        {
            //            InPatientInfo iPInfo = tempNode.Nodes[i].Tag as InPatientInfo;
            //            if (iPInfo.Id == inpat.Id)
            //            {
            //                if (old_Inpatient.Id != 0)//不是空床
            //                {
            //                    tempNode.Nodes[i].Text = old_Inpatient.Sick_Bed_Name + "  " + old_Inpatient.Patient_Name;
            //                    tempNode.Nodes[i].Tag = null;
            //                    tempNode.Nodes[i].Tag = old_Inpatient;
            //                    if (old_Inpatient.Gender_Code == "1")
            //                    {
            //                        tempNode.Nodes[i].ImageIndex = 12;
            //                        tempNode.Nodes[i].SelectedImageIndex = 12;
            //                    }
            //                    else
            //                    {
            //                        tempNode.Nodes[i].ImageIndex = 13;
            //                        tempNode.Nodes[i].SelectedImageIndex = 13;
            //                    }
            //                }
            //                else  //空床
            //                {
            //                    tempNode.Nodes[i].Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
            //                    tempNode.Nodes[i].Tag = null;
            //                    tempNode.Nodes[i].Tag = inpat;
            //                    if (inpat.Gender_Code == "1")
            //                    {
            //                        tempNode.Nodes[i].ImageIndex = 12;
            //                        tempNode.Nodes[i].SelectedImageIndex = 12;
            //                    }
            //                    else
            //                    {
            //                        tempNode.Nodes[i].ImageIndex = 13;
            //                        tempNode.Nodes[i].SelectedImageIndex = 13;
            //                    }
            //                }
            //                //node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
            //                ////把当前选中的节点移到科室病人节点下
            //                //DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
            //            }
            //            else if (iPInfo.Id == old_Inpatient.Id)
            //            {
            //                tempNode.Nodes[i].Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
            //                tempNode.Nodes[i].Tag = null;
            //                tempNode.Nodes[i].Tag = inpat;
            //                if (inpat.Gender_Code == "1")
            //                {
            //                    tempNode.Nodes[i].ImageIndex = 12;
            //                    tempNode.Nodes[i].SelectedImageIndex = 12;
            //                }
            //                else
            //                {
            //                    tempNode.Nodes[i].ImageIndex = 13;
            //                    tempNode.Nodes[i].SelectedImageIndex = 13;
            //                }
            //            }

            //        }
            //    }
            //}//foreach结束
        }

        private void 更换管床医生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inpat = GetPatientByList();
            //WebReference.Service wbs = new WebReference.Service();
            //string webip = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite2/Service.asmx";
            //wbs.Url = webip;
            //DataSet ds = wbs.His_GetDataSet("select zyys from v_dzbl_zy_brry where zyh=" +inpat.Id +"");
            //string doctor_id = ds.Tables[0].Rows[0][0].ToString();
            //if (doctor_id != inpat.Sick_Doctor_Id)
            //{
            //    /*
            //     * 管床医生发生了变化,更换管床医生
            //     */
            //    if (App.ExecuteSQL("update t_in_patient t set t.sick_doctor_id=" + inpat.Sick_Doctor_Id + ",t.sick_doctor_name=(select a.user_name from t_userinfo a where a.user_id=" + inpat.Sick_Doctor_Id + ") where t.id=" + inpat.Id + "") > 0)
            //    {
            //        App.Msg("已经同步HIS管床医生！");
            //    }
            //}

            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmUpdateDoctor outAction = new frmUpdateDoctor(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        //刷新当前小卡，会造成诊断显示错误
                        //if (Test.ViewSwitch == 0)
                        //{
                        //    CurrentucPictureBox.Img(inpat);
                        //}
                        //else
                        //{
                        strflag = "";
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "床,管床医生：" + doctor_Name + "。";
                        App.Msg(content);

                        ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                        main.RefCard();
                        //}
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("更换管床医生异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "更换管床医生", "", pid, patient_Id);
            }
        }

        private void 出区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmOutArea outAction = new frmOutArea(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        if (node != null)
                        {
                            if (inpat.Die_flag == 1)
                            {
                                node.Text = inpat.Patient_Name + "(已死亡)";
                            }
                            else
                            {
                                node.Text = inpat.Patient_Name;
                            }
                            node.Remove();
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnYiChuyuan_patient")
                                {
                                    nodetemp[0].Nodes[i].Nodes.Add(node);
                                    break;
                                }
                            }
                            //nodetemp[0].Nodes["tnYiChuyuan_patient"].Nodes.Add(node);
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        // App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        //自定义刷新事件
                        //EventRefinpatient(this);
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            //pictureBox_EventRefinpatient(CurrentucPictureBox);
                            RefCard(inpat);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("出区异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "出区", "", pid, patient_Id);
            }
        }

        private void 转出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmRoll_Out inAction = new frmRoll_Out(inpat);
                    inAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        //DevComponents.AdvTree.Node node = DataInit.RefCardTree(selectNodes, inpat);
                        if (node != null)
                        {
                            node.Text = inpat.Patient_Name;
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnYizhuanchu_patient")
                                {
                                    nodetemp[0].Nodes[i].Nodes.Add(node);
                                    break;
                                }
                            }
                            //nodetemp[0].Nodes["tnYizhuanchu_patient"].Nodes.Add(node);
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            //pictureBox_EventRefinpatient(CurrentucPictureBox);
                            RefCard(inpat);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        DataInit.UpdatPatientsNodes(nodeInpatient, 4);
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("转出异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "转出", "", pid, patient_Id);
            }
        }

        private void 取消转科ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmBackRollOut outAction = new frmBackRollOut(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        if (node != null)
                        {
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnSection_patient")
                                {
                                    for (int j = 0; j < nodetemp[0].Nodes[i].Nodes.Count; j++)
                                    {
                                        DevComponents.AdvTree.Node tempNode = nodetemp[0].Nodes[i].Nodes[j];
                                        if (tempNode.Text.Contains(inpat.Section_Name))
                                        {
                                            node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                            //把当前选中的节点移到科室病人节点下
                                            DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                                        }
                                    }
                                }
                            }
                            //foreach (TreeNode tempNode in nodetemp[0].Nodes["tnSection_patient"].Nodes)
                            //{
                            //    if (tempNode.Text.Equals(inpat.Section_Name))
                            //    {
                            //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                            //        //把当前选中的节点移到科室病人节点下
                            //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                            //    }
                            //}
                        }
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            pictureBox_EventRefinpatient(CurrentucPictureBox);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("取消转科异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "取消转科", "", pid, patient_Id);
            }
        }

        private void 回收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {

                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmBack_Area outAction = new frmBack_Area(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        DevComponents.AdvTree.Node node = DataInit.RefCardTree(nodetemp, inpat);
                        if (node != null)
                        {
                            for (int i = 0; i < nodetemp[0].Nodes.Count; i++)
                            {
                                if (nodetemp[0].Nodes[i].Name == "tnSection_patient")
                                {
                                    for (int j = 0; j < nodetemp[0].Nodes[i].Nodes.Count; j++)
                                    {
                                        DevComponents.AdvTree.Node tempNode = nodetemp[0].Nodes[i].Nodes[j];
                                        if (tempNode.Text.Equals(inpat.Section_Name))
                                        {
                                            node.Text = inpat.Sick_Bed_Name + " " + inpat.Patient_Name;
                                            //把当前选中的节点移到科室病人节点下
                                            DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                                        }
                                    }
                                }
                            }
                            //foreach (TreeNode tempNode in nodetemp[0].Nodes["tnSection_patient"].Nodes)
                            //{
                            //    if (tempNode.Text.Equals(inpat.Section_Name))
                            //    {
                            //        node.Text = inpat.Sick_Bed_Name + " " + inpat.Patient_Name;
                            //        //把当前选中的节点移到科室病人节点下
                            //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodetemp);
                            //    }
                            //}
                        }
                        if (DataInit.ViewSwitch == 0)
                        {
                            //自定义刷新事件
                            //EventRefinpatient(this);
                            pictureBox_EventRefinpatient(CurrentucPictureBox);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("回收异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "回收", "", pid, patient_Id);
            }
        }

        private void tlspmnitApply_Click(object sender, EventArgs e)
        {
            frmConsultation_Apply frmconsultation_apply = new frmConsultation_Apply(inpat);
            App.FormStytleSet(frmconsultation_apply,false);
            //frmconsultation_apply.MdiParent = App.ParentForm;
            frmconsultation_apply.ShowDialog();
            //App.AddNewChildForm(frmconsultation_apply);
        }

        private void 病人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmPatientInfo frmpatient = new frmPatientInfo(inpat);
                    frmpatient.StartPosition = FormStartPosition.CenterParent;
                    frmpatient.ShowDialog();
                    // App.AddNewChildForm(frmpatient);
                    if (DataInit.isInAreaSucceed)
                    {
                        result = "S";
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        App.SendMessage(content, App.GetHostIp());
                        if (DataInit.ViewSwitch == 0)
                        {
                            DataInit.UpdatPatientsNodes(nodeInpatient, 4);
                            UCPictureBox.dianose_Name= DataInit.GetDiagnose(inpat.Id.ToString());
                            CurrentucPictureBox.Img(inpat);
                            //this.HospitalIni(DataInit.PatientsNode.Nodes, nodetemp, nodeText, Test.ViewSwitch,patientTree);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("病人信息异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "病人信息", "", pid, patient_Id);
            }
        }

        private void 挂床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {

                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmHangBed outAction = new frmHangBed(inpat);
                    outAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        string name = inpat.Patient_Name;
                        string sex = DataInit.StringFormat(inpat.Gender_Code);
                        string bed_no = inpat.Sick_Bed_Name;
                        string doctor_Name = inpat.Sick_Doctor_Name;
                        string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                        //App.Msg(content);
                        //this.Paint += new PaintEventHandler(ucHospitalIofn_Paint); //修改用户名的颜色

                        if (DataInit.ViewSwitch == 0)
                        {
                            CurrentucPictureBox.Img(inpat);
                        }
                        else
                        {
                            strflag = "";
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                            main.RefCard();
                        }
                        App.SendMessage(content, App.GetHostIp());
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("挂床异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "挂床", "", pid, patient_Id);
            }
        }

        //void ucHospitalIofn_Paint(object sender, PaintEventArgs e)
        //{

        //    e.Graphics.DrawString(inpat.Patient_Name + " " + inpat.Age.ToString() + inpat.Age_unit, new Font("宋体", 9F, FontStyle.Regular,
        //                    GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(4, 52));
        //}
        #endregion

        /// <summary>
        /// 设置当前小卡对应的病人树节点
        /// </summary>
        /// <param name="currPatient"></param>
        /// <param name="Patients"></param>
        private void GetSelectedNodeByPatientTree(ref DevComponents.AdvTree.Node currPatient,DevComponents.AdvTree.NodeCollection Patients)
        {
            foreach (DevComponents.AdvTree.Node node in Patients)
            {
                if (node.Tag != null)
                {
                    InPatientInfo patient = node.Tag as InPatientInfo;
                    if (inpat.Id ==patient.Id)
                    {
                         currPatient = node;
                         break;
                    }
                }
                if (node.Nodes.Count > 0)
                {
                    GetSelectedNodeByPatientTree(ref currPatient, node.Nodes);
                }
            }
        }
        internal void pictureBox_EventReflash(InPatientInfo inpatientInfo, UCPictureBox ucPictureBox)
        {
            inpat = inpatientInfo;
            GetSelectedNodeByPatientTree(ref nodeInpatient, patientTree.Nodes);
            CurrentucPictureBox = ucPictureBox;
            string sex = "";
            if (inpat.Gender_Code != null)
            {
                if (inpat.Gender_Code == "0" || inpat.Gender_Code == "男")
                {
                    sex = "男";
                }
                else
                {
                    sex = "女";
                }
                //sex = inpat.Gender_Code == "0" ? "男" : "女";//性别
            }

            string operTime = App.ReadSqlVal("select max(doc_name) as maxtime from t_patients_doc t where t.textkind_id=151 and t.patient_id='" + inpat.Id + "'", 0, "maxtime");
            //string payManager = App.ReadSqlVal("select name from t_data_code t where t.code='" + inpat.Pay_Manager + "'",0,"name");
            //付款方式
            string pay_Manager = inpat.Pay_Manager;//App.ReadSqlVal("select name from t_data_code where type =70 and code='" + inpat.Pay_Manager + "'", 0, "name");
            //病人情况
            string in_Circs = App.ReadSqlVal("select * from t_data_code where type='133' and code='" + inpat.Sick_Degree + "'", 0, "name");
            //护理级别
            string Nurse_Level = "";
            if (App.IsNumeric(inpat.Nurse_Level))
            {
                Nurse_Level = App.ReadSqlVal("select * from t_data_code where type='53' and id=" + inpat.Nurse_Level, 0, "name");
            }
            else
            {
                Nurse_Level = inpat.Nurse_Level;
            }

            //SuperToolTip悬浮详细信息卡
            SuperTooltipInfo stinfo = new SuperTooltipInfo(
                                 inpat.Sick_Bed_Name + "床", "管床医师：" + inpat.Sick_Doctor_Name,
                                  "\n病人性别：" + sex + " 年龄：" + inpat.Age + inpat.Age_unit
                                 + "\n病人科室：" + inpat.Insection_Name
                                 + "\n工作单位：" + inpat.Office
                                 + "\n病人情况：" + in_Circs
                                 + "\n护理级别：" + Nurse_Level
                                 + "\n手术日期：" + operTime
                                 + "\n病人性质：" + pay_Manager, null, null, DevComponents.DotNetBar.eTooltipColor.Cyan);

            superTooltip1.SetSuperTooltip(ucPictureBox, stinfo);
        }

        /// <summary>
        /// 隐藏悬浮窗
        /// </summary>
        /// <param name="ucPicture"></param>
        internal void superToolTip_Hide(UCPictureBox ucPicture)
        {
            superTooltip1.HideTooltip();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int id = 0;
            if (DataInit.ViewSwitch == 0)
            {
                id = inpat.Id;
            }
            else
            {
                try
                {
                    id = Convert.ToInt32(flgView.SelectedRows[0].Cells["id"].Value);
                }
                catch (Exception)
                {
                }
                
            }
            if (id != 0)
            {
                if (nodeText == "待入区病人")
                {
                    this.病案归档ToolStripMenuItem.Visible = false;
                    this.入区ToolStripMenuItem.Visible = true;
                    this.历史病历查看lisfToolStripMenuItem.Visible = true;
                    //检测单ToolStripMenuItem.Visible = true;
                    检验报告toolStripMenuItem2.Visible = true;
                    病理报告toolStripMenuItem3.Visible = true;
                    医嘱单toolStripMenuItem.Visible = true;
                    影像报告toolStripMenuItem.Visible = true;
                    手麻报告查阅toolStripMenuItem1.Visible = false;
                    心电图toolStripMenuItem1.Visible = true;
                    病人综合视图toolStripMenuItem1.Visible = true;
                    病人检查趋势图toolStripMenuItem1.Visible = true;
                    this.历史病案查阅toolStripMenuItem1.Visible = false;

                    this.退回转出科室ToolStripMenuItem.Visible = false;
                    //this.修改入区时间ToolStripMenuItem.Visible = false;
                    this.换床ToolStripMenuItem.Visible = false;
                    this.更换管床医生ToolStripMenuItem.Visible = false;
                    this.出区ToolStripMenuItem.Visible = false;
                    this.挂床ToolStripMenuItem.Visible = false;
                    this.转出ToolStripMenuItem.Visible = false;
                    this.回收ToolStripMenuItem.Visible = false;
                    this.取消转科ToolStripMenuItem.Visible = false;
                    this.转入ToolStripMenuItem.Visible = false;
                    this.会诊申请tlspmnitApply.Visible = false;
                    this.病人信息ToolStripMenuItem.Visible = false;
                    ////this.手术ToolStripMenuItem1.Visible = false;
                    this.重新转出toolStripMenuItem1.Visible = false;
                    this.文书授权toolStripMenuItem1.Visible = false;
                    this.取消授权toolStripMenuItem1.Visible = false;
                    this.临床路径toolStripMenuItem.Visible = false;
                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
                else if (nodeText == "已转出病人")
                {

                    this.病案归档ToolStripMenuItem.Visible = false;
                    this.取消转科ToolStripMenuItem.Visible = true;
                    病人综合视图toolStripMenuItem1.Visible = true;
                    病人检查趋势图toolStripMenuItem1.Visible = true;
                    检测单ToolStripMenuItem.Visible = false;
                    检验报告toolStripMenuItem2.Visible = true;
                    病理报告toolStripMenuItem3.Visible = false;
                    医嘱单toolStripMenuItem.Visible = true;
                    影像报告toolStripMenuItem.Visible = true;
                    手麻报告查阅toolStripMenuItem1.Visible = false;
                    心电图toolStripMenuItem1.Visible = true;
                    this.历史病案查阅toolStripMenuItem1.Visible = false;

                    this.回收ToolStripMenuItem.Visible = false;
                    this.修改入区时间ToolStripMenuItem.Visible = false;
                    this.转出ToolStripMenuItem.Visible = false;
                    this.换床ToolStripMenuItem.Visible = false;
                    this.更换管床医生ToolStripMenuItem.Visible = false;
                    this.出区ToolStripMenuItem.Visible = false;
                    this.挂床ToolStripMenuItem.Visible = false;
                    this.转入ToolStripMenuItem.Visible = false;
                    this.退回转出科室ToolStripMenuItem.Visible = false;
                    this.入区ToolStripMenuItem.Visible = false;
                    this.会诊申请tlspmnitApply.Visible = false;
                    this.病人信息ToolStripMenuItem.Visible = false;
                    //this.手术ToolStripMenuItem1.Visible = false;
                    this.历史病历查看lisfToolStripMenuItem.Visible = false;
                    string sql = "select action_type from t_inhospital_action where next_id=0 and patient_id=" + inpat.Id;
                    string action_type = App.ReadSqlVal(sql, 0, "action_type");
                    if (action_type == "退回")
                        this.重新转出toolStripMenuItem1.Visible = true;
                    else
                        this.重新转出toolStripMenuItem1.Visible = false;
                    this.文书授权toolStripMenuItem1.Visible = false;
                    this.取消授权toolStripMenuItem1.Visible = false;
                    this.临床路径toolStripMenuItem.Visible = false;

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
                else if (nodeText == "待转入病人")
                {
                    this.病案归档ToolStripMenuItem.Visible = false;
                    this.转入ToolStripMenuItem.Visible = true;
                    this.退回转出科室ToolStripMenuItem.Visible = true;
                    检测单ToolStripMenuItem.Visible = true;
                    检验报告toolStripMenuItem2.Visible = true;
                    病理报告toolStripMenuItem3.Visible = true;
                    医嘱单toolStripMenuItem.Visible = true;
                    影像报告toolStripMenuItem.Visible = true;
                    手麻报告查阅toolStripMenuItem1.Visible = false; 
                    心电图toolStripMenuItem1.Visible = true;
                    病人综合视图toolStripMenuItem1.Visible = true;
                    病人检查趋势图toolStripMenuItem1.Visible = true;
                    this.历史病案查阅toolStripMenuItem1.Visible = false;

                    this.入区ToolStripMenuItem.Visible = false;
                    this.修改入区时间ToolStripMenuItem.Visible = false;
                    this.换床ToolStripMenuItem.Visible = false;
                    this.更换管床医生ToolStripMenuItem.Visible = false;
                    this.出区ToolStripMenuItem.Visible = false;
                    this.挂床ToolStripMenuItem.Visible = false;
                    this.转出ToolStripMenuItem.Visible = false;
                    this.回收ToolStripMenuItem.Visible = false;
                    this.取消转科ToolStripMenuItem.Visible = false;
                    this.会诊申请tlspmnitApply.Visible = false;
                    //this.手术ToolStripMenuItem1.Visible = false;
                    this.病人信息ToolStripMenuItem.Visible = false;
                    this.历史病历查看lisfToolStripMenuItem.Visible = false;
                    this.重新转出toolStripMenuItem1.Visible = false;
                    this.文书授权toolStripMenuItem1.Visible = false;
                    this.取消授权toolStripMenuItem1.Visible = false;
                    this.临床路径toolStripMenuItem.Visible = false;

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
                else if (nodeText == "我的病人")
                {
                    this.历史病历查看lisfToolStripMenuItem.Visible = false;
                    this.入区ToolStripMenuItem.Visible = false;
                    this.退回转出科室ToolStripMenuItem.Visible = false;
                    if (App.UserAccount.CurrentSelectRole.Role_type == "N" && App.UserAccount.CurrentSelectRole.Role_name.Contains("护士长"))
                    {
                        this.修改入区时间ToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                    }
                    if (App.CurrentHospitalId == 201)//201是南院id
                    {
                        this.换床ToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        this.换床ToolStripMenuItem.Visible = false;
                    }
                    this.更换管床医生ToolStripMenuItem.Visible = true;
                    this.出区ToolStripMenuItem.Visible = true;
                    this.挂床ToolStripMenuItem.Visible = false;
                    this.转出ToolStripMenuItem.Visible = true;
                    this.回收ToolStripMenuItem.Visible = false;
                    this.取消转科ToolStripMenuItem.Visible = false;
                    this.转入ToolStripMenuItem.Visible = false;
                    this.历史病案查阅toolStripMenuItem1.Visible = true;

                    检测单ToolStripMenuItem.Visible = false;
                    检验报告toolStripMenuItem2.Visible = true;
                    病理报告toolStripMenuItem3.Visible = true;
                    医嘱单toolStripMenuItem.Visible = true;
                    影像报告toolStripMenuItem.Visible = true;
                    手麻报告查阅toolStripMenuItem1.Visible = false;
                    心电图toolStripMenuItem1.Visible = true;
                    病人综合视图toolStripMenuItem1.Visible = true;
                    病人检查趋势图toolStripMenuItem1.Visible = true;
                    this.会诊申请tlspmnitApply.Visible = true;
                    this.病人信息ToolStripMenuItem.Visible = true;
                    //this.手术ToolStripMenuItem1.Visible = true;
                    this.重新转出toolStripMenuItem1.Visible = false;
                    this.文书授权toolStripMenuItem1.Visible = true;
                    this.取消授权toolStripMenuItem1.Visible = true;
                    this.临床路径toolStripMenuItem.Visible = true;

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
                else if (nodeText == "已出院病人")
                {
                    if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                    {
                        this.病案归档ToolStripMenuItem.Visible = true;
                        this.回收ToolStripMenuItem.Visible = true;
                        检测单ToolStripMenuItem.Visible = false;
                        检验报告toolStripMenuItem2.Visible = true;
                        病理报告toolStripMenuItem3.Visible = true;
                        医嘱单toolStripMenuItem.Visible = true;
                        影像报告toolStripMenuItem.Visible = true;
                        手麻报告查阅toolStripMenuItem1.Visible = false;
                        心电图toolStripMenuItem1.Visible = true;
                        病人综合视图toolStripMenuItem1.Visible = true;
                        病人检查趋势图toolStripMenuItem1.Visible = true;
                        this.临床路径toolStripMenuItem.Visible = true;
                        this.历史病案查阅toolStripMenuItem1.Visible = false;
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = false;
                        this.换床ToolStripMenuItem.Visible = false;
                        this.更换管床医生ToolStripMenuItem.Visible = false;
                        this.出区ToolStripMenuItem.Visible = false;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.转入ToolStripMenuItem.Visible = false;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.入区ToolStripMenuItem.Visible = false;
                        this.会诊申请tlspmnitApply.Visible = false;
                        this.病人信息ToolStripMenuItem.Visible = true;
                        //this.手术ToolStripMenuItem1.Visible = false;
                        this.历史病历查看lisfToolStripMenuItem.Visible = false;
                        this.重新转出toolStripMenuItem1.Visible = false;
                    }
                    else
                    {

                       this.病案归档ToolStripMenuItem.Visible = true;
                        this.历史病历查看lisfToolStripMenuItem.Visible = false;
                        this.入区ToolStripMenuItem.Visible = false;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                        this.换床ToolStripMenuItem.Visible = false;
                        this.更换管床医生ToolStripMenuItem.Visible = false;
                        this.出区ToolStripMenuItem.Visible = false;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = false;
                        this.回收ToolStripMenuItem.Visible = true;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.转入ToolStripMenuItem.Visible = false;
                        this.重新转出toolStripMenuItem1.Visible = false;
                        this.会诊申请tlspmnitApply.Visible = true;
                        this.病人信息ToolStripMenuItem.Visible = true;
                        //this.手术ToolStripMenuItem1.Visible = true;
                        //检测单ToolStripMenuItem.Visible = true;
                        检验报告toolStripMenuItem2.Visible = true;
                        病理报告toolStripMenuItem3.Visible = true;
                        医嘱单toolStripMenuItem.Visible = true;
                        影像报告toolStripMenuItem.Visible = true;
                        手麻报告查阅toolStripMenuItem1.Visible = false;
                        心电图toolStripMenuItem1.Visible = true;
                        病人综合视图toolStripMenuItem1.Visible = true;
                        病人检查趋势图toolStripMenuItem1.Visible = true;
                        this.回收ToolStripMenuItem.Visible = true;
                        this.文书授权toolStripMenuItem1.Visible = true;
                        this.取消授权toolStripMenuItem1.Visible = true;
                        this.历史病案查阅toolStripMenuItem1.Visible = false;
                        this.临床路径toolStripMenuItem.Visible = true;

                    }

                    this.toolStripMenuItem1.Visible = true;
                    this.添加标示ToolStripMenuItem.Visible = true;
                    this.取消标示ToolStripMenuItem.Visible = true;
                }
                else if (nodeText == "科室病人" || nodeText.Contains(inpat.Section_Name))
                {
                    if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                    {
                        this.病案归档ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = true;
                        this.换床ToolStripMenuItem.Visible = true;
                        this.更换管床医生ToolStripMenuItem.Visible = true;
                        this.出区ToolStripMenuItem.Visible = true;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.病人信息ToolStripMenuItem.Visible = true;
                        检测单ToolStripMenuItem.Visible = false;
                        检验报告toolStripMenuItem2.Visible = true;
                        病理报告toolStripMenuItem3.Visible = true;
                        医嘱单toolStripMenuItem.Visible = true;
                        影像报告toolStripMenuItem.Visible = true;
                        手麻报告查阅toolStripMenuItem1.Visible = false;
                        心电图toolStripMenuItem1.Visible = true;
                        病人综合视图toolStripMenuItem1.Visible = true;
                        this.临床路径toolStripMenuItem.Visible = true;
                        病人检查趋势图toolStripMenuItem1.Visible = true;

                        this.转入ToolStripMenuItem.Visible = false;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.回收ToolStripMenuItem.Visible = false;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.入区ToolStripMenuItem.Visible = false;
                        this.会诊申请tlspmnitApply.Visible = false;
                        //this.手术ToolStripMenuItem1.Visible = false;
                        this.历史病历查看lisfToolStripMenuItem.Visible = false;
                        this.重新转出toolStripMenuItem1.Visible = false;
                        this.历史病案查阅toolStripMenuItem1.Visible = true;

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N" && App.UserAccount.CurrentSelectRole.Role_name.Contains("护士长"))
                        {
                            this.修改入区时间ToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            this.修改入区时间ToolStripMenuItem.Visible = false;
                        }
                    }
                    else
                    {
                        this.历史病历查看lisfToolStripMenuItem.Visible = false;
                        this.入区ToolStripMenuItem.Visible = false;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                        this.更换管床医生ToolStripMenuItem.Visible = true;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = true;
                        this.回收ToolStripMenuItem.Visible = false;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.转入ToolStripMenuItem.Visible = false;
                        this.重新转出toolStripMenuItem1.Visible = false;
                        this.会诊申请tlspmnitApply.Visible = true;
                        this.病人信息ToolStripMenuItem.Visible = true;
                        //this.手术ToolStripMenuItem1.Visible = true;
                        //检测单ToolStripMenuItem.Visible = true;
                        检验报告toolStripMenuItem2.Visible = true;
                        病理报告toolStripMenuItem3.Visible = true;
                        医嘱单toolStripMenuItem.Visible = true;
                        影像报告toolStripMenuItem.Visible = true;
                        手麻报告查阅toolStripMenuItem1.Visible = false;
                        this.临床路径toolStripMenuItem.Visible = true;
                        this.历史病案查阅toolStripMenuItem1.Visible = true;

                        //this.转入ToolStripMenuItem.Visible = true;
                        this.出区ToolStripMenuItem.Visible = true;
                        if (App.CurrentHospitalId == 201)//201是南院id
                        {
                            this.换床ToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            this.换床ToolStripMenuItem.Visible = false;
                        }
                        病人综合视图toolStripMenuItem1.Visible = true;
                        病人检查趋势图toolStripMenuItem1.Visible = true;
                        this.文书授权toolStripMenuItem1.Visible = true;
                        this.取消授权toolStripMenuItem1.Visible = true;
                    }

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.回收ToolStripMenuItem.Visible = false;
                    this.历史病案查阅toolStripMenuItem1.Visible = false;

                    this.修改入区时间ToolStripMenuItem.Visible = false;
                    this.转出ToolStripMenuItem.Visible = false;
                    this.换床ToolStripMenuItem.Visible = false;
                    this.更换管床医生ToolStripMenuItem.Visible = false;
                    this.出区ToolStripMenuItem.Visible = false;
                    this.挂床ToolStripMenuItem.Visible = false;
                    this.转入ToolStripMenuItem.Visible = false;
                    this.退回转出科室ToolStripMenuItem.Visible = false;
                    this.取消转科ToolStripMenuItem.Visible = false;
                    this.入区ToolStripMenuItem.Visible = false;
                    this.会诊申请tlspmnitApply.Visible = false;
                    this.病人信息ToolStripMenuItem.Visible = true;
                    //this.手术ToolStripMenuItem1.Visible = false;
                    this.历史病历查看lisfToolStripMenuItem.Visible = false;
                    this.重新转出toolStripMenuItem1.Visible = false;
                    this.病案归档ToolStripMenuItem.Visible = false;
                    检测单ToolStripMenuItem.Visible = true;
                    检验报告toolStripMenuItem2.Visible = true;
                    病理报告toolStripMenuItem3.Visible = true;
                    医嘱单toolStripMenuItem.Visible = true;
                    影像报告toolStripMenuItem.Visible = true;
                    手麻报告查阅toolStripMenuItem1.Visible = false;
                    心电图toolStripMenuItem1.Visible = true;
                    病人综合视图toolStripMenuItem1.Visible = true;
                    病人检查趋势图toolStripMenuItem1.Visible = true;
                    this.临床路径toolStripMenuItem.Visible = true;

                    this.toolStripMenuItem1.Visible = false;
                    this.添加标示ToolStripMenuItem.Visible = false;
                    this.取消标示ToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                this.回收ToolStripMenuItem.Visible = false;
                this.历史病案查阅toolStripMenuItem1.Visible = false;

                this.修改入区时间ToolStripMenuItem.Visible = false;
                this.转出ToolStripMenuItem.Visible = false;
                this.换床ToolStripMenuItem.Visible = false;
                this.更换管床医生ToolStripMenuItem.Visible = false;
                this.出区ToolStripMenuItem.Visible = false;
                this.挂床ToolStripMenuItem.Visible = false;
                this.转入ToolStripMenuItem.Visible = false;
                this.退回转出科室ToolStripMenuItem.Visible = false;
                this.取消转科ToolStripMenuItem.Visible = false;
                this.入区ToolStripMenuItem.Visible = false;
                this.会诊申请tlspmnitApply.Visible = false;
                this.病人信息ToolStripMenuItem.Visible = false;
                //this.手术ToolStripMenuItem1.Visible = false;
                this.历史病历查看lisfToolStripMenuItem.Visible = false;
                检测单ToolStripMenuItem.Visible = false;
                检验报告toolStripMenuItem2.Visible = false;
                病理报告toolStripMenuItem3.Visible = false;
                医嘱单toolStripMenuItem.Visible = false;
                影像报告toolStripMenuItem.Visible = false;//lianwei
                手麻报告查阅toolStripMenuItem1.Visible = false;
                心电图toolStripMenuItem1.Visible = true;
                this.重新转出toolStripMenuItem1.Visible = false;
                更新当前病人toolStripMenuItem1.Visible = false;
                病人综合视图toolStripMenuItem1.Visible = false;
                病人检查趋势图toolStripMenuItem1.Visible = false;
                this.临床路径toolStripMenuItem.Visible = false;

                this.病案归档ToolStripMenuItem.Visible = false;
                this.toolStripMenuItem1.Visible = false;
                this.添加标示ToolStripMenuItem.Visible = false;
                this.取消标示ToolStripMenuItem.Visible = false;
            }
            if (inpat.IsHaveRight)//已授权的文书授权按钮变为查看授权，取消授权启用
            {
                this.文书授权toolStripMenuItem1.Text = "查看授权";
                this.取消授权toolStripMenuItem1.Enabled = true;
            }
            else
            {
                this.文书授权toolStripMenuItem1.Text = "文书授权";
                this.取消授权toolStripMenuItem1.Enabled = false;
            }

            #region 屏蔽按钮-镇平中医院

            //检测单ToolStripMenuItem.Visible = false;
            //病理报告toolStripMenuItem3.Visible = false;
            ////影像报告toolStripMenuItem.Visible = false;//lianwei
            //手麻报告查阅toolStripMenuItem1.Visible = false;
            //心电图toolStripMenuItem1.Visible = true;
            //病人检查趋势图toolStripMenuItem1.Visible = false;
            //this.临床路径toolStripMenuItem.Visible = true;
            //更新当前病人toolStripMenuItem1.Visible = false;
            //this.会诊申请tlspmnitApply.Visible = false;
            //this.换床ToolStripMenuItem.Visible = false;
            #endregion
        }

        private void 手术ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            frmSurgery frm = new frmSurgery(inpat);
            //App.AddNewChildForm(frm);
            //frm.Show();
        }

        private void ucHospitalIofn_Resize(object sender, EventArgs e)
        {
            //给panel里面的用户控件统一排列位置。               
            //ReLacation(flowLayoutPanel1);
            //flowLayoutPanel1.Refresh();
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            DataInit.isInAreaSucceed = false;
        }
        /// <summary>
        /// 用列表显示病人
        /// </summary>
        /// <param name="nodes">树集合</param>
        /// <param name="isSwitch">是否为试图切换</param>
        public void InpatientViewList(NodeCollection nodes, bool isSwitch, string text)
        {
            string pName = txtName.Text.Trim();
            string pid = txtPid.Text.Trim();
            nodeText = text;
            this.nodetemp = nodes;
            this.selectText = text;
            this.selectNodes = nodes;
            int intFlag = Convert.ToInt32(isSwitch);
            //if (strflag == text && intFlag == intflag)
            //{
            //    return;
            //}
            strflag = text;
            intflag = intFlag;
            inpatientList.Clear();
            try
            {
                this.intflag = DataInit.ViewSwitch;
                GetInpatients(nodes, isSwitch, pName, pid);
                this.flowLayoutPanel1.Controls.Clear();
                //flgView = new DataGridViewX();
                flgView.MouseDoubleClick += new MouseEventHandler(flgView_MouseDoubleClick);
                flgView.MouseClick += new MouseEventHandler(flgView_MouseClick);
                flgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;   //
                flgView.CellMouseDown += new DataGridViewCellMouseEventHandler(flgView_CellMouseDown);
                //flowLayoutPanel1.Controls.Add(flgView);
                //flgView.DataSource = dt.DefaultView;
                flgView.DataSource = null;
                flgView.DataSource = inpatientList;
                //flgView.Dock = DockStyle.Fill;
                flgView.ReadOnly = true;
                flgView.ContextMenuStrip = contextMenuStrip1;
                flgView.BackgroundColor = Color.White;

                
                //if (inpatientList.Count != 0)
                //{
                    flgView.Columns["ID"].HeaderText = "主键";
                    flgView.Columns["ID"].DisplayIndex = 0;
                    flgView.Columns["Sick_Bed_Name"].HeaderText = "床号";
                    flgView.Columns["Sick_Bed_Name"].DisplayIndex = 1;
                    flgView.Columns["Patient_Name"].HeaderText = "姓名";
                    flgView.Columns["Patient_Name"].DisplayIndex = 3;
                    flgView.Columns["Gender_Code"].HeaderText = "性别";
                    flgView.Columns["Gender_Code"].DisplayIndex = 4;
                    flgView.Columns["Birthday"].HeaderText = "出生年月";
                    flgView.Columns["Birthday"].DisplayIndex = 5;
                    flgView.Columns["PId"].HeaderText = "住院号";
                    flgView.Columns["PId"].DisplayIndex = 2;
                    flgView.Columns["Age"].HeaderText = "年龄";
                    flgView.Columns["Age"].DisplayIndex = 6;
                    flgView.Columns["Age_unit"].HeaderText = "年龄单位";
                    flgView.Columns["Age_unit"].DisplayIndex = 7;
                    flgView.Columns["Sick_Doctor_Name"].HeaderText = "管床医生";
                    flgView.Columns["Sick_Doctor_Name"].DisplayIndex = 8;
                    flgView.Columns["In_Time"].HeaderText = "入院时间";
                    flgView.Columns["In_Time"].DisplayIndex = 9;
                    
                    
                    flgView.Columns["Sick_Degree"].HeaderText = "危重程度";
                    flgView.Columns["Sick_Degree"].DisplayIndex = 10;
                    flgView.Columns["Nurse_Level"].HeaderText = "护理等级";
                    flgView.Columns["Nurse_Level"].DisplayIndex = 11;                  
                    for (int i = 0; i < flgView.Columns.Count; i++)
                    {
                        if (flgView.Columns[i].HeaderText == flgView.Columns[i].Name)
                        {
                            flgView.Columns[i].Visible = false;
                        }
                    }
                    flgView.Columns["ID"].Visible = false;
                    //flgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

                    //flgView.Columns[1].Visible = false;
                    //flgView.Columns[7].Visible = false;
                    //flgView.Columns[9].Visible = false;
                    //flgView.Columns[10].Visible = false;
                    //flgView.Columns[11].Visible = false;
                    //flgView.Columns[12].Visible = false;
                    //flgView.Columns[14].Visible = false;
                    //flgView.Columns[15].Visible = false;
                    //flgView.Columns[20].Visible = false;
                    //flgView.Columns[21].Visible = false;
                    //flgView.Columns[22].Visible = false;
                    //flgView.Columns[23].Visible = false;
                    //flgView.Columns[24].Visible = false;
                    //flgView.Columns[25].Visible = false;
                    //flgView.Columns[26].Visible = false;
                    //flgView.Columns[27].Visible = false;
                    //flgView.Columns[28].Visible = false;
                    //flgView.Columns[29].Visible = false;
                    //flgView.Columns[30].Visible = false;
                    //flgView.Columns[31].Visible = false;
                    //flgView.Columns[32].Visible = false;
                    //flgView.Columns[33].Visible = false;
                    //flgView.Columns[34].Visible = false;
                    //flgView.Columns[35].Visible = false;
                    //flgView.Columns[36].Visible = false;
                    //flgView.Columns[37].Visible = false;
                    //flgView.Columns[38].Visible = false;
                    //flgView.Columns[39].Visible = false;
                    //flgView.Columns[40].Visible = false;
                    //flgView.Columns[41].Visible = false;
                    //flgView.Columns[42].Visible = false;
                    //flgView.Columns[43].Visible = false;
                    //flgView.Columns[44].Visible = false;
                    //flgView.Columns[45].Visible = false;
                    //flgView.Columns[46].Visible = false;
                    //flgView.Columns[47].Visible = false;
                    ////    //flgView.Columns[17].Move(7);
                    ////    //flgView.Columns["sick_bed_name"].Move(2);
                //}
                for (int i = 0; i < flgView.Rows.Count; i++)
                {
                    if (flgView["Gender_Code", i].Value.ToString().Equals("0"))
                    {
                        flgView["Gender_Code", i].Value = "男";
                    }
                    else if (flgView["Gender_Code", i].Value.ToString().Equals("1"))
                    {
                        flgView["Gender_Code", i].Value = "女";
                    }

                    //.ToString( "yyyy-MM-dd ");                    
                    flgView["Birthday", i].Value = Convert.ToDateTime(flgView["Birthday", i].Value.ToString().Trim()).ToString("yyyy-MM-dd");                    
                    if (flgView["NURSE_LEVEL", i].Value.ToString().Equals("233"))
                    {
                        flgView["NURSE_LEVEL", i].Value = "一级护理";
                    }
                    else if (flgView["NURSE_LEVEL", i].Value.ToString().Equals("234"))
                    {
                        flgView["NURSE_LEVEL", i].Value = "二级护理";
                    }
                    else if (flgView["NURSE_LEVEL", i].Value.ToString().Equals("235"))
                    {
                        flgView["NURSE_LEVEL", i].Value = "三级护理";
                    }
                    else if (flgView["NURSE_LEVEL", i].Value.ToString().Equals("236"))
                    {
                        flgView["NURSE_LEVEL", i].Value = "特护";
                    }
                    else if (flgView["NURSE_LEVEL", i].Value.ToString().Equals("0"))
                    {
                        flgView["NURSE_LEVEL", i].Value = "";
                    }

                    //危重程度
                    if (flgView["Sick_Degree", i].Value.ToString().Equals("1"))
                    {
                        flgView["Sick_Degree", i].Value = "一般";
                    }
                    else if (flgView["Sick_Degree", i].Value.ToString().Equals("2"))
                    {
                        flgView["Sick_Degree", i].Value = "急";
                    }
                    else if (flgView["Sick_Degree", i].Value.ToString().Equals("3"))
                    {
                        flgView["Sick_Degree", i].Value = "危";
                    }
                    else if (flgView["Sick_Degree", i].Value.ToString().Equals("4"))
                    {
                        flgView["Sick_Degree", i].Value = "死亡";
                    }

                    if (DataInit.isNewInArea(flgView["In_Time", i].Value.ToString()))
                    {
                        flgView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (DataInit.isTURN(flgView["ID", i].Value.ToString()))
                    {
                        flgView.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                    }


                }

               
                flgView.Width = flowLayoutPanel1.Width-10;
                flgView.Height = flowLayoutPanel1.Height-10;
                App.UsControlStyle(this);
                flgView.AutoResizeColumns();
                flgView.Dock = DockStyle.Fill;
                //gbxInpatientInfo.Controls.Add(flgView);
                flowLayoutPanel1.Visible = false;
                          
            }
            catch (System.Exception ex)
            {

            }
        }
        //小卡父窗体对象
        DevComponents.DotNetBar.TabControl tabControl_Patient = null;
        void page_Click(object sender, EventArgs e)
        {
            if (tabControl_Patient.Tabs.Count > 0)
            {
                this.tabControl_Patient.AutoCloseTabs = false;
                TabItem item = (TabItem)sender;
                //Point mp = Cursor.Position;
                MouseEventArgs mp = (MouseEventArgs)e;
                Point pTab = item.CloseButtonBounds.Location;
                if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                    mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                {
                    if (App.Ask("是否关闭当前病人的文书？"))
                    {
                        App.ReleaseLockedDoc(item.Name);
                        this.tabControl_Patient.Tabs.Remove(item);
                    }
                }               
            }
        }

        void flgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataInit.boolAgree = false;
            DataInit.isRightDoc = false;
            if (e.Button == MouseButtons.Left)
            {
               inpat=GetPatientByList();
                if (inpat.Id != 0)
                {
                    string action_State = DataInit.GetActionState(inpat.Id.ToString());
                    if (action_State == "4" || action_State == "3")
                    {
                        tabControl_Patient = (this.Parent.Parent.Parent.Parent) as DevComponents.DotNetBar.TabControl;
                        //验证TabControl是否有重复
                        if (tabControl_Patient != null)
                        {
                            for (int i = 0; i < tabControl_Patient.Tabs.Count; i++)
                            {
                                if (inpat.Id.ToString() == tabControl_Patient.Tabs[i].Name)
                                {
                                    tabControl_Patient.SelectedTabIndex = i;
                                    return;
                                }
                            }
                        }
                        ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                        main.action_State = action_State;
                        main.currentPatient = inpat;

                        TabControlPanel tabctpnDoc = new TabControlPanel();
                        tabctpnDoc.AutoScroll = true;
                        TabItem pageDoc = new TabItem();
                        pageDoc.Name = inpat.Id.ToString();
                        pageDoc.Text = inpat.Sick_Bed_Name + " " + inpat.Patient_Name;
                        pageDoc.Click += new EventHandler(page_Click);
                        pageDoc.Tag = inpat;
                        ucDoctorOperater fm = new ucDoctorOperater(inpat);
                        fm.Dock = DockStyle.Fill;
                        tabctpnDoc.Controls.Add(fm);
                        tabctpnDoc.Dock = DockStyle.Fill;
                        pageDoc.AttachedControl = tabctpnDoc;
                        tabControl_Patient.Controls.Add(tabctpnDoc);
                        tabControl_Patient.Tabs.Add(pageDoc);
                        tabControl_Patient.Refresh();
                        tabControl_Patient.SelectedTab = pageDoc;
                        //flag = true;
                    }
                }
                else
                {
                    App.Msg("该床是空床！");
                }
            }
        }

        private InPatientInfo GetPatientByList()
        { 
            InPatientInfo patientInfo = new InPatientInfo();
            if (flgView.CurrentRow.Index > 0 || flgView.CurrentRow.Index == 0)
            {
                patientInfo.Id = Int32.Parse(flgView["id", flgView.CurrentRow.Index].Value.ToString());
                patientInfo.Patient_Name = flgView["Patient_Name", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("男"))
                {
                    patientInfo.Gender_Code = "0";
                }
                else
                {
                    patientInfo.Gender_Code = "1";
                }
                patientInfo.Now_address = flgView["Now_address", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Now_addres_phone = flgView["Now_addres_phone", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Marrige_State = flgView["Marrige_State", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Medicare_no = flgView["Medicare_no", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Home_address = flgView["Home_address", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.HomePostal_code = flgView["HomePostal_code", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Home_phone = flgView["Home_phone", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Office = flgView["Office", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Office_address = flgView["Office_Address", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Office_phone = flgView["Office_phone", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Relation = flgView["Relation", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Relation_address = flgView["Relation_address", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Relation_phone = flgView["Relation_phone", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.RelationPos_code = flgView["RelationPos_code", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.OfficePos_code = flgView["OfficePos_code", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["InHospital_Count", flgView.CurrentRow.Index].Value.ToString() != "")
                    patientInfo.InHospital_count = Convert.ToInt32(flgView["InHospital_Count", flgView.CurrentRow.Index].Value.ToString());
                patientInfo.Cert_Id = flgView["Cert_Id", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Pay_Manager = flgView["Pay_Manager", flgView.CurrentRow.Index].Value as string;
                patientInfo.In_Circs = flgView["IN_Circs", flgView.CurrentRow.Index].Value as string;
                patientInfo.Natiye_place = flgView["Natiye_place", flgView.CurrentRow.Index].Value as string;
                patientInfo.Birth_place = flgView["Birth_place", flgView.CurrentRow.Index].Value as string;
                patientInfo.Folk_code = flgView["Folk_code", flgView.CurrentRow.Index].Value as string;

                patientInfo.Birthday = flgView["Birthday", flgView.CurrentRow.Index].Value as string;
                patientInfo.PId = flgView["PId", flgView.CurrentRow.Index].Value as string;
                patientInfo.Insection_Id = Convert.ToInt32(flgView["insection_id", flgView.CurrentRow.Index].Value);
                patientInfo.Insection_Name = flgView["insection_name", flgView.CurrentRow.Index].Value as string;
                patientInfo.In_Area_Id = flgView["in_area_id", flgView.CurrentRow.Index].Value as string;
                patientInfo.In_Area_Name = flgView["in_area_name", flgView.CurrentRow.Index].Value as string;
                if (flgView["Age", flgView.CurrentRow.Index].Value.ToString() != "")
                    patientInfo.Age = flgView["Age", flgView.CurrentRow.Index].Value.ToString();
                //inpatient.Action_State = row["action_state"].ToString();
                patientInfo.Sick_Doctor_Id = flgView["sick_doctor_id", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Sick_Doctor_Name = flgView["sick_doctor_name", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["Sike_Area_Id", flgView.CurrentRow.Index] != null)
                    patientInfo.Sike_Area_Id = flgView["Sike_Area_Id", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Sick_Area_Name = flgView["sick_area_name", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["section_id", flgView.CurrentRow.Index].Value.ToString() != "")
                    patientInfo.Section_Id = Int32.Parse(flgView["section_id", flgView.CurrentRow.Index].Value.ToString());
                patientInfo.Section_Name = flgView["section_name", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["in_time", flgView.CurrentRow.Index].Value != null)
                    patientInfo.In_Time = DateTime.Parse(flgView["in_time", flgView.CurrentRow.Index].Value.ToString());
                patientInfo.State = flgView["state", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["sick_bed_id", flgView.CurrentRow.Index].ToString() != "")
                    patientInfo.Sick_Bed_Id = Int32.Parse(flgView["sick_bed_id", flgView.CurrentRow.Index].Value.ToString());
                patientInfo.Sick_Bed_Name = flgView["Sick_Bed_Name", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Age_unit = flgView["age_unit", flgView.CurrentRow.Index].Value.ToString();
                patientInfo.Sick_Degree = Convert.ToString(flgView["Sick_Degree", flgView.CurrentRow.Index].Value);
                if (flgView["Die_flag", flgView.CurrentRow.Index].ToString() != "")
                    patientInfo.Die_flag = Convert.ToInt32(flgView["Die_flag", flgView.CurrentRow.Index].Value);
                patientInfo.Card_Id = flgView["card_id", flgView.CurrentRow.Index].Value.ToString();
                if (flgView["Nurse_Level", flgView.CurrentRow.Index].Value.ToString().Equals("一级护理"))
                {
                    patientInfo.Nurse_Level = "233";
                }
                else if (flgView["Nurse_Level", flgView.CurrentRow.Index].Value.ToString().Equals("二级护理"))
                {
                    patientInfo.Nurse_Level = "234";
                }
                else if (flgView["Nurse_Level", flgView.CurrentRow.Index].Value.ToString().Equals("三级护理"))
                {
                    patientInfo.Nurse_Level = "235";
                }
                else if (flgView["Nurse_Level", flgView.CurrentRow.Index].Value.ToString().Equals("特护"))
                {
                    patientInfo.Nurse_Level = "236";
                }
                else 
                {
                    patientInfo.Nurse_Level = "";
                }
                patientInfo.His_id = flgView["his_id", flgView.CurrentRow.Index].Value.ToString();
            }
            return patientInfo;
        }

        void flgView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {               
                string sex = "";
                if (flgView.CurrentRow == null)
                {
                    return;
                }
                if (flgView.CurrentRow.Index > 0)
                {
                    if (flgView["Gender_Code", flgView.CurrentRow.Index].Value != null)
                    {
                        if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("0"))
                        {
                            sex = "男";
                        }
                        else if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("1"))
                        {
                            sex = "女";
                        }
                        else
                        {
                            sex = flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString();
                        }
                        App.SetMainFrmMsgToolBarText(flgView["sick_bed_name", flgView.CurrentRow.Index].Value.ToString() + "床  " + "ID:" + flgView["id", flgView.CurrentRow.Index].Value.ToString() +
                                                    "  住院号:" + flgView["pid", flgView.CurrentRow.Index].Value.ToString() + "  姓名:" + flgView["patient_name", flgView.CurrentRow.Index].Value.ToString() +
                                                    "  性别:" + sex + "  年龄:" + flgView["age", flgView.CurrentRow.Index].Value.ToString() +
                                                    "  入院时间:" + flgView["in_time", flgView.CurrentRow.Index].Value.ToString() +
                                                    "  当前科室:" + flgView["Section_Name", flgView.CurrentRow.Index].Value.ToString());
                    }
                }
            }
          
        }

        void flgView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    flgView.ClearSelection();
                    flgView.Rows[e.RowIndex].Selected = true;
                    flgView.CurrentCell = flgView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    inpat = GetPatientByList();
                    string sex = "";
                    if (flgView.CurrentRow == null)
                    {
                        return;
                    }
                    if (flgView.CurrentRow.Index > 0)
                    {
                        if (flgView["Gender_Code", flgView.CurrentRow.Index].Value != null)
                        {
                            if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("0"))
                            {
                                sex = "男";
                            }
                            else if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("1"))
                            {
                                sex = "女";
                            }
                            else
                            {
                                sex = flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString();
                            }
                            App.SetMainFrmMsgToolBarText(flgView["sick_bed_name", flgView.CurrentRow.Index].Value.ToString() + "床  " + "ID:" + flgView["id", flgView.CurrentRow.Index].Value.ToString() +
                                                        "  住院号:" + flgView["pid", flgView.CurrentRow.Index].Value.ToString() + "  姓名:" + flgView["patient_name", flgView.CurrentRow.Index].Value.ToString() +
                                                        "  性别:" + sex + "  年龄:" + flgView["age", flgView.CurrentRow.Index].Value.ToString() +
                                                        "  入院时间:" + flgView["in_time", flgView.CurrentRow.Index].Value.ToString() +
                                                        "  当前科室:" + flgView["Section_Name", flgView.CurrentRow.Index].Value.ToString());
                        }
                    }
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);


                }
            }
        }

        private void lisfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookHistory frmbookHistory = new frmBookHistory(inpat);
            frmbookHistory.ShowDialog();
        }
        /// <summary>
        /// 根据选中的树节点，获得病人集合
        /// </summary>
        /// <param name="nodes">树集合</param>
        /// <param name="isSwitch">是否为切换</param>
        /// <param name="pName">病人姓名</param>
        /// <param name="pid">住院号</param>
        public void GetInpatients(NodeCollection nodes, bool isSwitch, string pName, string pid)
        {
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                if (node.Tag != null)
                {
                    if (node.Tag.GetType().ToString().Contains("InPatientInfo"))
                    {
                        InPatientInfo inPatientInfo = node.Tag as InPatientInfo;
                        if (!isSwitch)
                        {
                            if (pName != "" && pid != "")
                            {
                                if (inPatientInfo.Patient_Name.Contains(pName) &&
                                    inPatientInfo.PId.Contains(pid))//病人姓名和住院号联合查询
                                {
                                    InPatientInfo inpateint = node.Tag as InPatientInfo;
                                    inpatientList.Add(inpateint);
                                }
                            }
                            else
                            {
                                if (pName == "" && pid == "")
                                {
                                    InPatientInfo inpateint = node.Tag as InPatientInfo;
                                    inpatientList.Add(inpateint);
                                }
                                if (pName != "")
                                {
                                    if (inPatientInfo.Patient_Name.Contains(pName))
                                    {
                                        InPatientInfo inpateint = node.Tag as InPatientInfo;
                                        inpatientList.Add(inpateint);
                                    }
                                }
                                if (pid != "")
                                {
                                    if (inPatientInfo.PId.Contains(pid))
                                    {
                                        InPatientInfo inpateint = node.Tag as InPatientInfo;
                                        inpatientList.Add(inpateint);
                                    }
                                }
                            }
                        }
                        else
                        {
                            InPatientInfo inpateint = node.Tag as InPatientInfo;
                            inpatientList.Add(inpateint);
                        }
                    }
                }
                if (node.Nodes.Count > 0)
                    GetInpatients(node.Nodes, isSwitch, pName, pid);

            }
        }
        /// <summary>
        /// 换床后更新小卡
        /// </summary>
        /// <param name="target_Inpat">目标小卡病人对象</param>
        /// <param name="bed_Id">原来小卡床号id</param>
        /// <param name="isEmpty">原来小卡床号id</param>
        /// <param name="isEmpty">是否为空床</param>
        /// <param name="target_Bed_Id">目标小卡床号id</param>
        /// <param name="target_Bed_No">目标小卡床号id</param>
        public void RefCardByUpdateBed(InPatientInfo target_Inpat, int target_Bed_Id, string target_Bed_No, ref InPatientInfo old_Inpatient, bool isEmpty)
        {
            nodeText = "科室病人";
            int bed_id = target_Inpat.Sick_Bed_Id;
            string bed_no = target_Inpat.Sick_Bed_Name;
            //当前病人
            InPatientInfo current_Inpatient = null;
            //要换的床的病人
            //InPatientInfo old_Inpatient = GetInpatientByBedId(target_Bed_Id);
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                UCPictureBox ucPicture = flowLayoutPanel1.Controls[i] as UCPictureBox;
                if (ucPicture.Inpat.Sick_Bed_Id == bed_id)//当前床号
                {
                    old_Inpatient = DataInit.InitPatient(old_Inpatient, bed_id, bed_no);
                    ucPicture.Inpat = old_Inpatient;
                    ucPicture.Img(ucPicture.Inpat);
                }
                else if (target_Bed_Id == ucPicture.Inpat.Sick_Bed_Id)//目标床号
                {
                    current_Inpatient = DataInit.InitPatient(target_Inpat, target_Bed_Id, target_Bed_No);
                    ucPicture.Inpat = current_Inpatient;
                    ucPicture.Img(ucPicture.Inpat);
                }
            }
            target_Inpat.Sick_Bed_Name = target_Bed_No;
            target_Inpat.Sick_Bed_Id = target_Bed_Id;
            //old_Inpatient.Sick_Bed_Name = bed_no;
            //old_Inpatient.Sick_Bed_Id = bed_id;
        }
        /// <summary>
        /// 根据床号得到病人对象
        /// </summary>
        /// <param name="bed_Id">床号</param>
        /// <returns></returns>
        //private InPatientInfo GetInpatientByBedId(int bed_Id)
        //{
        //    InPatientInfo inpatient = null;
        //    foreach (Control control in panel1.Controls)
        //    {
        //        UCPictureBox ucPicture = control as UCPictureBox;
        //        if(ucPicture.Inpat.Sick_Bed_Id==bed_Id)
        //        {
        //            inpatient = ucPicture.Inpat;
        //            break;
        //        }
        //    }
        //    return inpatient;
        //}
        /// <summary>
        /// 根据床号得到病人对象
        /// </summary>
        /// <param name="bed_Id">床号</param>
        /// <returns></returns>
        private InPatientInfo GetInpatientByBedId(int bed_Id)
        {
            InPatientInfo inpatient = null;
            for (int i = 0; i < nodetemp.Count; i++)
            {
                if (nodetemp[i].Name == "tnParentName")
                {
                    for (int j = 0; j < nodetemp[i].Nodes.Count; j++)
                    {
                        if (nodetemp[i].Nodes[j].Name == "tnSection_patient")
                        {
                            DevComponents.AdvTree.Node node = nodetemp[i].Nodes[j].Nodes[0];
                            foreach (DevComponents.AdvTree.Node nodePatient in node.Nodes)
                            {
                                for (int k = 0; k < node.Nodes.Count; k++)
                                {
                                    if (node.Nodes[k].Tag != null)
                                    {
                                        InPatientInfo inptient = node.Nodes[k].Tag as InPatientInfo;
                                        if (inptient.Sick_Bed_Id == bed_Id)
                                        {
                                            inpatient = inptient;
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            //foreach (TreeNode node in nodetemp["tnParentName"].Nodes["tnSection_patient"].Nodes)//科室病人
            //{
            //    for (int i = 0; i < node.Nodes.Count; i++)
            //    {
            //        if (node.Nodes[i].Tag != null)
            //        {
            //            InPatientInfo inptient = node.Nodes[i].Tag as InPatientInfo;
            //            if (inptient.Sick_Bed_Id == bed_Id)
            //            {
            //                inpatient = inptient;
            //                break;
            //            }
            //        }
            //    }
            //}
            return inpatient;
        }
        private void RefCard(InPatientInfo inpat)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                UCPictureBox ucPicture = control as UCPictureBox;
                if (ucPicture.Inpat.Id == inpat.Id)
                {
                    InPatientInfo inpInfo = new InPatientInfo();
                    inpInfo.Id = 0;
                    inpInfo.Sick_Bed_Id = inpat.Sick_Bed_Id;
                    inpInfo.Sick_Bed_Name = inpat.Sick_Bed_Name;
                    inpInfo.Nurse_Level = inpat.Nurse_Level;
                    ucPicture.Tag = null;
                    ucPicture.Tag = inpInfo;
                    ucPicture.Inpat = inpInfo;
                    ucPicture.Img(inpInfo);
                    break;
                }
            }
        }

        /// <summary>
        /// 根据床号修改病人小卡
        /// </summary>
        /// <param name="bed_Id">床号</param>
        /// <returns></returns>
        private InPatientInfo GetInpatientRefCard(InPatientInfo inpatInfo)
        {
            InPatientInfo inpatient = null;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                UCPictureBox ucPicture = control as UCPictureBox;
                if (ucPicture.Inpat.Sick_Bed_Id == inpatInfo.Sick_Bed_Id)
                {
                    ucPicture.Inpat = inpatInfo;
                    ucPicture.Tag = inpatInfo;
                    ucPicture.Img(inpatInfo);
                    break;
                }
            }
            return inpatient;
        }

        /// <summary>
        /// 检验检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    FrmLis fc = new FrmLis(inpat.PId);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("请先选择0病人!");
            }
        }

        /// <summary>
        /// 病理报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    frmBljc fc = new frmBljc(inpat.PId);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("请先选择病人!");
            }
        }

        private void 医嘱单toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    frmYZ fc = new frmYZ(inpat);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("请先选择病人或当前病人没有数据!");
            }
        }

        private void 影像报告toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {

                    Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inpat);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                //App.MsgErr("请先选择病人!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bed_id"></param>
        /// <returns></returns>
        private InPatientInfo GetPatientByList(int bed_id)
        {
            InPatientInfo patientInfo = new InPatientInfo();
            if (flgView.CurrentRow.Index > 0)
            {
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    if (bed_id == Convert.ToInt32(flgView["sick_bed_id", i].Value))
                    {
                        patientInfo.Id = Int32.Parse(flgView["id", flgView.CurrentRow.Index].Value.ToString());
                        patientInfo.Patient_Name = flgView["Patient_Name", flgView.CurrentRow.Index].Value.ToString();
                        if (flgView["Gender_Code", flgView.CurrentRow.Index].Value.ToString().Equals("男"))
                        {
                            patientInfo.Gender_Code = "0";
                        }
                        else
                        {
                            patientInfo.Gender_Code = "1";
                        }
                        patientInfo.Marrige_State = flgView["Marrige_State", i].Value.ToString();
                        patientInfo.Medicare_no = flgView["Medicare_no", i].Value.ToString();
                        patientInfo.Home_address = flgView["Home_address", i].Value.ToString();
                        patientInfo.HomePostal_code = flgView["HomePostal_code", i].Value.ToString();
                        patientInfo.Home_phone = flgView["Home_phone", i].Value.ToString();
                        patientInfo.Office = flgView["Office", i].Value.ToString();
                        patientInfo.Office_address = flgView["Office_Address", i].Value.ToString();
                        patientInfo.Office_phone = flgView["Office_phone", i].Value.ToString();
                        patientInfo.Relation = flgView["Relation", i].Value.ToString();
                        patientInfo.Relation_address = flgView["Relation_address", i].Value.ToString();
                        patientInfo.Relation_phone = flgView["Relation_phone", i].Value.ToString();
                        patientInfo.RelationPos_code = flgView["RelationPos_code", i].Value.ToString();
                        patientInfo.OfficePos_code = flgView["OfficePos_code", i].Value.ToString();
                        if (flgView["InHospital_Count", i].Value.ToString() != "")
                            patientInfo.InHospital_count = Convert.ToInt32(flgView["InHospital_Count", i].Value.ToString());
                        patientInfo.Cert_Id = flgView["Cert_Id", i].Value.ToString();
                        patientInfo.Pay_Manager = flgView["Pay_Manager", i].Value.ToString();
                        patientInfo.In_Circs = flgView["IN_Circs", i].Value.ToString();
                        patientInfo.Natiye_place = flgView["Natiye_place", i].Value.ToString();
                        patientInfo.Birth_place = flgView["Birth_place", i].Value.ToString();
                        patientInfo.Folk_code = flgView["Folk_code", i].Value.ToString();

                        patientInfo.Birthday = flgView["Birthday", i].Value.ToString();
                        patientInfo.PId = flgView["PId", i].Value.ToString();
                        patientInfo.Insection_Id = Convert.ToInt32(flgView["insection_id", i].Value);
                        patientInfo.Insection_Name = flgView["insection_name", i].Value.ToString();
                        patientInfo.In_Area_Id = flgView["in_area_id", i].Value.ToString();
                        patientInfo.In_Area_Name = flgView["in_area_name", flgView.CurrentRow.Index].Value.ToString();
                        if (flgView["Age", flgView.CurrentRow.Index].Value.ToString() != "")
                            patientInfo.Age = flgView["Age", i].Value.ToString();
                        //inpatient.Action_State = row["action_state",i].Value.ToString();
                        patientInfo.Sick_Doctor_Id = flgView["sick_doctor_id", i].Value.ToString();
                        patientInfo.Sick_Doctor_Name = flgView["sick_doctor_name", i].Value.ToString();
                        if (flgView["Sike_Area_Id", i].Value != null)
                            patientInfo.Sike_Area_Id = flgView["Sike_Area_Id", i].Value.ToString();
                        patientInfo.Sick_Area_Name = flgView["sick_area_name", i].Value.ToString();
                        if (flgView["section_id", i].Value.ToString() != "")
                            patientInfo.Section_Id = Int32.Parse(flgView["section_id", i].Value.ToString());
                        patientInfo.Section_Name = flgView["section_name", i].Value.ToString();
                        if (flgView["in_time", i].Value != null)
                            patientInfo.In_Time = DateTime.Parse(flgView["in_time", i].Value.ToString());
                        patientInfo.State = flgView["state", i].Value.ToString();
                        if (flgView["sick_bed_id", flgView.CurrentRow.Index].Value.ToString() != "")
                            patientInfo.Sick_Bed_Id = Int32.Parse(flgView["sick_bed_id", flgView.CurrentRow.Index].Value.ToString());
                        patientInfo.Sick_Bed_Name = flgView["Sick_Bed_Name", i].Value.ToString();
                        patientInfo.Age_unit = flgView["age_unit", i].Value.ToString();
                        patientInfo.Sick_Degree = Convert.ToString(flgView["Sick_Degree", i].Value);
                        if (flgView["Die_flag", flgView.CurrentRow.Index].Value.ToString() != "")
                            patientInfo.Die_flag = Convert.ToInt32(flgView["Die_flag", i].Value);
                        patientInfo.Card_Id = flgView["card_id", i].Value.ToString();
                        if (flgView["Nurse_Level", i].Value.ToString().Equals("一级护理"))
                        {
                            patientInfo.Nurse_Level = "233";
                        }
                        else if (flgView["Nurse_Level", i].Value.ToString().Equals("二级护理"))
                        {
                            patientInfo.Nurse_Level = "234";
                        }
                        else if (flgView["Nurse_Level", i].Value.ToString().Equals("三级护理"))
                        {
                            patientInfo.Nurse_Level = "235";
                        }
                        else if (flgView["Nurse_Level", i].Value.ToString().Equals("特护"))
                        {
                            patientInfo.Nurse_Level = "236";
                        }
                        break;
                    }
                }

            }
            return patientInfo;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.flowLayoutPanel1.Focus();
        }

        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            int lastRightPanelVerticalScrollValue = -1;//为鼠标滚动事件提供一个静态变量，用来存储上次滚动后的VerticalScroll.Value

            if (!(this.VerticalScroll.Visible == false || (this.VerticalScroll.Value == 0 && e.Delta > 0) || (this.VerticalScroll.Value == lastRightPanelVerticalScrollValue && e.Delta < 0)))
            {
                this.VerticalScroll.Value += 10;
                this.Refresh();
                this.Invalidate();
                this.Update();
            }
        }

        private void 更新当前病人toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_patientInfo = "select * from t_in_patient where id=" + inpat.Id;
                DataSet ds = App.GetDataSet(sql_patientInfo);
                DataTable dt = ds.Tables[0];
                InPatientInfo newInpatient = DataInit.InitPatient(dt.Rows[0]);

                //在Panel中查找当前病人的小卡，重新加载对象并设置图片显示
                for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    UCPictureBox uc = flowLayoutPanel1.Controls[i] as UCPictureBox;
                    if (uc.Inpat.Id == newInpatient.Id)
                    {
                        uc.Inpat = newInpatient;
                        uc.Img(inpat);
                        break;
                    }
                }

                //更新对应的树节点
                ucMain main = (this.Parent.Parent.Parent.Parent.Parent) as ucMain;
                main.RefAllTree();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 重新转出后，修改树节点的状态
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="inPatient"></param>
        public static void MedifyTreeNode(NodeCollection nodes, InPatientInfo inPatient)
        {
            foreach (DevComponents.AdvTree.Node node in nodes)
            {
                if (node.Tag == null)
                {
                    MedifyTreeNode(node.Nodes, inPatient);
                }
                else
                {
                    if (node.Tag.GetType().ToString().Contains("InPatientInfo"))
                    {
                        InPatientInfo inpatient = node.Tag as InPatientInfo;
                        if (inpatient.Id == inPatient.Id)
                        {
                            node.Text = inpatient.Patient_Name;
                        }
                    }
                }
            }
        }
        private void 重新转出toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (DataInit.ViewSwitch == 1)
            {
                inpat = GetPatientByList();
            }
            if (inpat != null)
            {
                string result = "";
                string pid = inpat.PId;
                try
                {
                    frmRoll_Out inAction = new frmRoll_Out(inpat);
                    inAction.ShowDialog();
                    if (DataInit.isInAreaSucceed == true)
                    {
                        result = "S";
                        MedifyTreeNode(nodetemp, inpat);
                        DataInit.isInAreaSucceed = false;
                    }
                    else
                    {
                        result = "F";
                    }
                    DataInit.UpdatPatientsNodes(nodeInpatient, 4);
                }
                catch (Exception ex)
                {
                    result = "F";
                    App.MsgErr("转出异常：" + ex.Message);
                }
                int patient_Id = inpat.Id;
                //LogHelper.SystemLog("", result, "转出", "", pid, patient_Id);
            }
        }

        private void 病人综合视图toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPatientComView patientComView = new frmPatientComView(inpat);
            patientComView.ShowDialog();
        }

        private void 病人检查趋势图toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPatientProgress patientProgress = new frmPatientProgress(inpat);
            patientProgress.ShowDialog();
        }

        /// <summary>
        /// 设置授权病人小卡背景图片
        /// </summary>
        private void SetCardByDocRight()
        {
            try
            {
                string sql_docRight = "select a.patient_id from t_set_text_rights a inner join t_in_patient b on a.patient_id=b.id where b.section_id = " + App.UserAccount.CurrentSelectRole.Section_Id + " and a.end_time>sysdate and b.document_state is null";
                DataSet ds = App.GetDataSet(sql_docRight);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //循环文书授权表
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //循环当前Panel中的小卡
                            for (int j = 0; j < flowLayoutPanel1.Controls.Count; j++)
                            {
                                //取出小卡的病人对象
                                InPatientInfo patient = flowLayoutPanel1.Controls[j].Tag as InPatientInfo;
                                if (patient != null)
                                {
                                    if (patient.Id == Convert.ToInt32(dt.Rows[i]["patient_id"]))
                                    {
                                        if (patient.IsChangeSection != 'T')//当转科标记存在时，不显示授权的背景图片
                                        {
                                            //flowLayoutPanel1.Controls[j].BackgroundImage = global::Base_Function.Resource.card_Purple;
                                        }
                                        patient.IsHaveRight = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 根据t_turn_section表中的数据设置对应病人小卡的背景色为红色
        /// </summary>
        private void SetCardByTurnSection()
        {
            try
            {
                //flowLayoutPanel1
                string sql_turn = "select * from t_turn_section where OUR_SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id;
                DataSet ds = App.GetDataSet(sql_turn);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //循环专科变化表的数据
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //循环当前Panel中的小卡
                            for (int j = 0; j < flowLayoutPanel1.Controls.Count; j++)
                            {
                                //取出小卡的病人对象
                                InPatientInfo patient = flowLayoutPanel1.Controls[j].Tag as InPatientInfo;
                                if (patient != null)
                                {
                                    if (patient.Id == Convert.ToInt32(dt.Rows[i]["patient_id"]))
                                    {
                                        //flowLayoutPanel1.Controls[j].BackgroundImage = global::Base_Function.Resource.card_Red_Turn;
                                        patient.IsChangeSection = 'T';
                                        UCPictureBox temp = (UCPictureBox)flowLayoutPanel1.Controls[j];
                                        temp.Img(patient);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void 文书授权toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (inpat.Sick_Doctor_Id == App.UserAccount.UserInfo.User_id)
            {
                Bifrost.SYSTEMSET.frmTextRightSet frmTextRight = new Bifrost.SYSTEMSET.frmTextRightSet(inpat.Id.ToString());
                frmTextRight.StartPosition = FormStartPosition.CenterParent;
                frmTextRight.ShowDialog();
                //授权界面关闭后，重新设置小卡背景
                SetCardByDocRight();
            }
            else
            {
                App.Msg("只有管床医生可以授权！");
            }
        }

        /// <summary>
        /// 取消文书授权：
        /// 1.删除授权表相关记录。
        /// 
        /// 2.设置当前病人对象的IsHaveRight属性为false。
        /// 3.设置小卡背景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 取消授权toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (App.Ask("确定要取消文书授权吗？"))
            {
                if (inpat != null)
                {
                    if (inpat.Sick_Doctor_Id == App.UserAccount.UserInfo.User_id)
                    {
                        string sql_Cancel = "delete from t_set_text_rights where patient_id=" + inpat.Id;
                        int num = App.ExecuteSQL(sql_Cancel);//删除授权表相关记录
                        if (num > 0)
                        {
                            App.Msg("操作成功！");
                            inpat.IsHaveRight = false;//设置当前选中节点的IsHaveRight为false
                            //CurrentucPictureBox.BackgroundImage = global::Base_Function.Resource.card_Blue;
                        }
                    }
                    else
                    {
                        App.Msg("只有管床医生可以取消授权！");
                    }
                }
            }
        }

        private void toolStripMenuItem住院医嘱_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    //CpoeFormMain fc = new CpoeFormMain(inpat);
                    //App.FormStytleSet(fc, false);
                    //fc.Show();
                    App.MsgWaring("医嘱暂时未启用,只提供查看功能！");
                    Bifrost.HisInstance.frmYZ fc = new frmYZ(inpat);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("请先选择病人或当前病人没有数据!");
            }
        }

        private void 临床路径toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inpat != null)
            {
                DataInit.OpenPatientPath(inpat.Id);
            }
        }

        private void tsmnitLookBook_Click(object sender, EventArgs e)
        {

            frmLookSignByDoctor frmSign = new frmLookSignByDoctor(inpat.Patient_Name);
            App.FormStytleSet(frmSign,false);
            frmSign.ShowDialog();
        }

        /// <summary>
        /// 历史病案查阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 历史病案查阅toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ucHospitalization_Records uc = new ucHospitalization_Records(inpat.Patient_Name);
            uc.Dock = DockStyle.Fill;
            frmApp fm = new frmApp();
            fm.Text = "运行病案查阅";
            fm.Controls.Add(uc);
            App.FormStytleSet(fm, false);
            fm.ShowDialog();
        }

        /// <summary>
        /// 评分反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFB_Click(object sender, EventArgs e)
        {
            //ucMsgFB uc = new ucMsgFB(App.UserAccount.CurrentSelectRole.Section_Id);
            ucfrmMainGradeRepart uc = new ucfrmMainGradeRepart(App.UserAccount.CurrentSelectRole.Section_name,false);
            uc.Dock = DockStyle.Fill;
            frmApp fm = new frmApp();
            fm.Text = "评分反馈";
            fm.Controls.Add(uc);
            App.FormStytleSet(fm, false);
            fm.Show();
        }



        
        private void 心电图toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BASE_DATA.FrmECGReport frm = new BASE_DATA.FrmECGReport(inpat.PId, inpat.InHospital_count.ToString());
            frm.ShowDialog();
        }


        private void 病案归档toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_MedicalRecords(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_MedicalRecords = null;
            }
        }

        private void 手麻报告查阅toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    //参数	    示例	    说明	            备注
                    //IP	    175.16.8.68	服务指向	
                    //Type	    Patient_id	病人ID号	        根据HIS
                    //Visit_id	Visit_id	住院次数或住院标识	根据HIS
                    //Mr_class	1001	    1001:麻醉
                    //His_no		        麻醉：his手术流水号 His手术流水号
                    //                      （可为空）	        （可为空）
                    //http://175.16.8.68/DocareInterfaceV4/main/Patient_history.aspx?patient_id=ZY010013134663&visit_id=1&mr_class=1001&his_no=27103

                    string urlSSMZ = @"http://175.16.8.68/DocareInterfaceV4/main/Patient_history.aspx?patient_id=" + inpat.His_id + "&visit_id=" + inpat.InHospital_count + "&mr_class=1001&his_no=";
                    Bifrost.HisInStance.frmPicShow fc = new Bifrost.HisInStance.frmPicShow(urlSSMZ);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch
            {
                App.MsgErr("请先选择病人!");
            }
        }

        private void 添加标示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    string sqls = "update t_in_patient set typicalflag='1' where id=" + inpat.Id;
                    if (App.ExecuteSQL(sqls) > 0)
                    {
                        App.Msg("选择的病人添加典型病历成功!");
                    }
                }
            }
            catch
            {
                App.MsgErr("请先选择病人或当前病人没有数据!");
            }
        }

        private void 取消标示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataInit.ViewSwitch == 1)
                {
                    inpat = GetPatientByList();
                }
                if (inpat != null)
                {
                    string sqls = "update t_in_patient set typicalflag=null where id=" + inpat.Id;
                    if (App.ExecuteSQL(sqls) > 0)
                    {
                        App.Msg("选择的病人取消典型病历成功!");
                    }
                }
            }
            catch
            {
                App.MsgErr("请先选择病人或当前病人没有数据!");
            }
        }
    }
}
