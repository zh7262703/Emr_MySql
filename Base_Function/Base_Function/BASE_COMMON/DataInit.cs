using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bifrost;
using System.Windows.Forms;

using System.Collections;
using DevComponents.AdvTree;
using System.Xml;
using DevComponents.DotNetBar;
using TextEditor;
using TextEditor.TextDocument.frmWindow;
using TextEditor.TextDocument.Document;
using Base_Function.TEMPLATE;
using System.Drawing;
using ZYCommon;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_NURSE.First_cases;
using Base_Function.MODEL;
using Base_Function.TEMPERATURES;
using EmrCommon;
using MoranEditor.GUI;
using MoranEditor.MPrint;
using MySql.Data.MySqlClient;

namespace Base_Function.BASE_COMMON
{
    /// <summary>
    /// 公共类 
    /// </summary>
    public class DataInit
    {
        /// <summary>
        /// 工具栏是否缩放
        /// </summary>
        public static bool SouFang;
        /// <summary>
        /// 病案编目提交-诊断
        /// </summary>
        public static EventHandler A_btnSave;
        /// <summary>
        /// 病案编目提交手术
        /// </summary>
        public static EventHandler A_btnSave_Operation;
        /// <summary>
        /// 上移诊断
        /// </summary>
        public static EventHandler A_UP;
        /// <summary>
        /// 下移
        /// </summary>
        public static EventHandler A_Next;
        /// <summary>
        /// 上移手术
        /// </summary>
        public static EventHandler A_UP_;
        /// <summary>
        /// 下移
        /// </summary>
        public static EventHandler A_Next_;
        /// <summary>
        /// 病案编目提交是否成功
        /// </summary>
        public static int Count = 0;
        /// <summary>
        /// 病案编目提交是否成功(排序)
        /// </summary>
        public static int Count_xh = 0;
        /// <summary>
        /// 当前页面是否编辑过（诊断）
        /// </summary>
        public static bool D_Edite;
        /// <summary>
        /// 当前页面位置是否发生过改变（诊断）
        /// </summary>
        public static bool D_UpOrNext;
        /// <summary>
        /// 当前页面是否编辑过(手术)
        /// </summary>
        public static bool O_Edite;
        /// <summary>
        /// 当前页面位置是否发生过改变（手术）
        /// </summary>
        public static bool O_UpOrNext;
        /// <summary>
        /// 病案编目提交后刷新查询界面数据
        /// </summary>
        public static EventHandler A_btnSelect;

        /// <summary>
        /// 同意借阅的病人只能浏览文书
        /// </summary>
        public static bool boolAgree;

        /// <summary>
        /// 是否是授权文书
        /// </summary>
        public static bool isRightDoc;
        /// <summary>
        /// 当前科室名称
        /// </summary>
        public static string section_name = "";
        /// <summary>
        /// 当前病区名称
        /// </summary>
        public static string sickarea_name = "";
        /// <summary>
        ///操作是否成功
        /// </summary>
        public static bool isInAreaSucceed = false;
        /// <summary>
        /// 病人树节点
        /// </summary>
        public static Node PatientsNode = new Node();
        private static bool flag = false;
        /// <summary>
        /// 找出当前帐号当前权限所对应的科室病区的所有病人-待入区
        /// </summary>
        private static string SELECTALL_INPATIENT;
        public static int ID;

        /// <summary>
        /// 待转出
        /// </summary>
        public static string Sql_out;

        /// <summary>
        /// 待转入
        /// </summary>
        public static string Sql_in;
        /// <summary>
        /// 所有科室病人
        /// </summary>
        public static string Sql_section_Patient;
        /// <summary>
        ///  查出当前病区的所有科室
        /// </summary>
        public static string Sql_getSection_ByArea;
        /// <summary>
        /// 查出当前医生的我的病人
        /// </summary>
        public static string Sql_GetPatientByDoctorID;
        /// <summary>
        /// 根据科室查出病人
        /// </summary>
        public static string Sql_GetPatientBySID;
        /// <summary>
        /// 已出院(死亡)病人
        /// </summary>
        public static string Sql_out_Area;

        /// <summary>
        /// 数据字典
        /// </summary>
        public static DataSet DS_CODE;
        /// <summary>
        /// 行政区域字典
        /// </summary>
        public static DataSet DS_AREA;
        //public static DataSet ds_code_type;

        /// <summary>
        /// 存放报卡文书的ID
        /// </summary>
        public static int BK_ID = 0;

        /// <summary>
        /// 是否运行病例
        /// </summary>
        public static bool isRightRun = false;

        public static InPatientInfo CurrentPatient = null;
        /// <summary>
        /// 视图切换功能:0病人小卡显示,1列表显示
        /// </summary>
        public static int ViewSwitch = 0;   //0病人小卡显示,1列表显示


        //保存所有的文书类型
        public static AdvTree temptrvbook = new AdvTree();

        //当前操作的编辑器
        public static frmText CurrentFrmText = null;

        public static ucDoctorOperater ucdoctorperater1 = null;

        //已签名参数
        public static bool MyDocStye = false;

        public static string strid = "";
        public static string strbed = "";
        /// <summary>
        /// 病人文书排序ID
        /// </summary>
        public static string SortTypeId = "1";

        /// <summary>
        /// 体温单信息读取
        /// </summary>
        public static Dictionary<string, string> dicRYText = new Dictionary<string, string>();

        /// <summary>
        /// 体温单信息新建文书加载
        /// </summary>
        public static Dictionary<string, string> dicTPRBP = new Dictionary<string, string>();

        //1代表女，0表示男
        public static string StringFormat(string str)
        {
            if (str.Equals("0") || str.Equals("男"))
            {
                return "男";
            }
            else
            {
                return "女";
            }
            
        }
        /// <summary>
        /// 根据当前病人的所在病区，科室ID，获得名称
        /// </summary>
        /// <param name="inPatient"></param>
        /// <returns></returns>
        public static DataTable GetTargetSName(InPatientInfo inPatient)
        {

            string SqlgetNameById = "select b.section_name,b.sid,c.sick_area_name,a.target_said from t_inhospital_action a" +
                                    " inner join t_sectioninfo b on a.target_sid = b.sid" +
                                    " inner join t_sickareainfo c on a.target_said = c.said" +
                                    " where a.id = (select max(id) from t_inhospital_action where patient_Id = " + inPatient.Id + ")";
            DataSet ds = App.GetDataSet(SqlgetNameById);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                sickarea_name = dt.Rows[0]["section_name"].ToString();
                section_name = dt.Rows[0]["sick_area_name"].ToString();
            }
            return dt;

        }
        /// <summary>
        /// 得到当前病人最后一条异动记录的状态
        /// </summary>
        /// <param name="inPatient"></param>
        /// <returns></returns>
        public static string GetState(InPatientInfo inPatient)
        {
            string SqlgetNameById = "select action_state from t_inhospital_action " +
                                   " where id = (select max(id) from t_inhospital_action where patient_Id = " + inPatient.Id + ")";
            string state = App.ReadSqlVal(SqlgetNameById, 0, "action_state");
            return state;

        }
        /// <summary>
        /// 获得当前病人的换床记录
        /// </summary>
        /// <param name="inPatient">当前病人</param>
        /// <returns>换床记录</returns>
        public static string ReturnNotes(InPatientInfo inPatient)
        {
            /*
             * 找到当前病人换床的所有记录
             * **/
            string Sql_ActionNotes = "select a.happen_time,b.bed_no from t_inhospital_action a" +
                                    " inner join t_sickbedinfo b on a.bed_id = b.bed_id" +
                                    " where a.patient_Id='" + inPatient.Id + "' and  action_type='换床'" +
                                    " and a.sid=" + inPatient.Section_Id + //and a.said = " + inPatient.Sike_Area_Id + "" +
                                    " order by id";
            /*
             * 找到刚开始入区时候的床号.
             * **/
            string Sql_InArea = "select b.bed_no from t_inhospital_action a" +
                                " inner join t_sickbedinfo b on a.bed_id = b.bed_id" +
                                " where a.patient_Id='" + inPatient.Id + "' and  action_type='入区'" +
                                " and a.sid=" + inPatient.Section_Id;// +" and a.said =" + inPatient.Sike_Area_Id + " ";
            DataSet ds = App.GetDataSet(Sql_ActionNotes);
            StringBuilder strBuilder = new StringBuilder();
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    int i = dt.Rows.Count - 1;
                    while (i >= 0)
                    {
                        if (i != 0)        //换床记录
                        {
                            string time = string.Format("{0:g}", Convert.ToDateTime(dt.Rows[i]["happen_time"].ToString()));
                            string sick_bed = "：从" + dt.Rows[i - 1]["bed_no"].ToString() + "号床 转到";
                            string target_bed = dt.Rows[i]["bed_no"].ToString() + "号床" + "\r\n";
                            strBuilder.Append(time);
                            strBuilder.Append(sick_bed);
                            strBuilder.Append(target_bed);
                        }
                        else              //第一次换床，和第一次入区分配的床号。
                        {
                            string bed = App.ReadSqlVal(Sql_InArea, 0, "bed_no");
                            string time = string.Format("{0:g}", Convert.ToDateTime(dt.Rows[i]["happen_time"].ToString()));
                            string sick_bed = "：从" + bed + "号床 转到";
                            string target_bed = dt.Rows[i]["bed_no"].ToString() + "号床" + "\r\n";
                            strBuilder.Append(time);
                            strBuilder.Append(sick_bed);
                            strBuilder.Append(target_bed);
                        }
                        i--;
                    }
                }
            }
            return strBuilder.ToString();
        }


        /// <summary>
        /// 初始化树控件护士站
        /// </summary>
        public static void IniTreeView(NodeCollection nodes)
        {
            DS_AREA = App.GetDataSet("select area_code,area_name from area_dict");
            DS_CODE = App.GetDataSet("select * from t_data_code where type in (53,70,71,134,132,130)");
            /*
             *科室所有病人 
             */
            /*
           * 科室所有病人 
           */
            string Sql_Sick = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id, a.sick_doctor_name,a.sick_area_id,a.sick_area_name," +
                       "a.section_id, a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree,a.NURSE_LEVEL,a.insection_id,a.insection_name," +
                       "a.in_area_id,in_area_name,a.Die_flag,a.die_time, Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone, Office,Office_Address,Office_Phone," +
                       "Career,Relation_Name,Relation,Relation_Address, Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count, CERT_ID,Pay_Manner,IN_Circs," +
                       "native_place,Birth_Place,Folk_Code,a.Sick_Group_Id,a.card_id,a.patient_Id,b.target_said,b.sid,b.action_state,b.action_type,c.sick_area_name secn,a.Country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,his_id,now_addres_phone,now_address,child_age,a.exe_document_time,a.document_state " +
                       "from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 left join t_sickareainfo c on c.said=b.target_said " +//
                       "where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " or b.target_said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by to_number(case when INSTR(a.sick_bed_no, '_', 1, 1) > 1 then replace(a.sick_bed_no, '_', '') else a.sick_bed_no||'0' end)";//2017-8-16 zhangtong  length(a.sick_bed_no),a.sick_bed_no";
            //string Sql_Sick = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id, a.sick_doctor_name,a.sick_area_id,a.sick_area_name," +
            //             "a.section_id, a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree,a.NURSE_LEVEL,a.insection_id,a.insection_name," +
            //             "a.in_area_id,in_area_name,a.Die_flag,a.die_time, Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone, Office,Office_Address,Office_Phone," +
            //             "Career,Relation_Name,Relation,Relation_Address, Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count, CERT_ID,Pay_Manner,IN_Circs," +
            //             "native_place,Birth_Place,Folk_Code,a.Sick_Group_Id,a.card_id,a.patient_Id,b.target_said,b.said,b.action_state,b.action_type,a.Country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,his_id,now_addres_phone,now_address,child_age,a.exe_document_time,a.document_state  " +
            //             "from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +//
            //             "where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " or b.target_said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by length(a.sick_bed_no),a.sick_bed_no";//order by cast(a.sick_bed_id as number)"; //and a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "
            DataSet ds = App.GetDataSet(Sql_Sick);
            #region 初始化

            nodes.Clear();

            Node tnParent = new Node();
            tnParent.Text = "患者管理";
            tnParent.Name = "tnParentName";
            //tnParent.ImageIndex = 32;
            //tnParent.SelectedImageIndex = 7;
            /*
             * 待入区病人
             */
            Node tnInArea = new Node();
            tnInArea.Text = "待入区病人";
            tnInArea.Name = "tnDairuqu";
            //tnInArea.ImageIndex = 31;
            //tnInArea.SelectedImageIndex = 2;
            /*
             * 待转入病人
             */
            Node tnTurnIn = new Node();
            tnTurnIn.Text = "待转入病人";
            tnTurnIn.Name = "tnDaizhuanru";
            //tnTurnIn.ImageIndex = 31;
            //tnTurnIn.SelectedImageIndex = 3;
            /*
             * 科室病人
             */
            Node tnSection = new Node();
            tnSection.Text = "科室病人";
            tnSection.Name = "tnSection_patient";
            //tnSection.ImageIndex = 29;
            //tnSection.SelectedImageIndex = 10;
            /*
             * 已出院(死亡)病人
             */
            Node tnDead = new Node();
            tnDead.Text = "已出院病人";
            tnDead.Name = "tnYiChuyuan_patient";
            //tnDead.ImageIndex = 37;
            //tnDead.SelectedImageIndex = 9;
            /*
             * 已转出病人
             */
            Node tnRollOut = new Node();
            tnRollOut.Text = "已转出病人";
            tnRollOut.Name = "tnYizhuanchu_patient";
            //tnRollOut.ImageIndex = 30;
            //tnRollOut.SelectedImageIndex = 4;

            tnParent.Nodes.Add(tnInArea);
            tnParent.Nodes.Add(tnTurnIn);
            //ltnParent.Nodes.Add(tnMyInPatient);
            tnParent.Nodes.Add(tnSection);
            tnParent.Nodes.Add(tnDead);
            tnParent.Nodes.Add(tnRollOut);
            nodes.Add(tnParent);
            #endregion

            //tnDairuqu
            #region 待入区病人
            DataSet Drq = App.GetDataSet("select * from t_in_patient ta where ta.document_state is null and ta.id not in (select patient_id from t_inhospital_action) and ta.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by length(ta.sick_bed_no),ta.sick_bed_no");
            DataRow[] dt_Drq = Drq.Tables[0].Select("");
            foreach (DataRow row in dt_Drq)
            {
                IniTree(tnInArea, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            #region 待转入
            DataRow[] dt_in = ds.Tables[0].Select("sick_area_id<>" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and target_said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  action_state=2 and action_type<>'退回'");

            foreach (DataRow row in dt_in)
            {
                IniTree(tnTurnIn, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            #region 科室病人
            DataRow[] dt_Section_Patien = ds.Tables[0].Select("sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and action_state=4");
            Sql_getSection_ByArea = "select b.sid,b.section_name from t_section_area a" +
                                   " inner join t_sectioninfo b on a.sid = b.sid" +
                                   " where a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
            DataTable ds_sectionInfo = App.GetDataSet(Sql_getSection_ByArea).Tables[0];
            foreach (DataRow row in ds_sectionInfo.Rows)
            {
                Node node = new Node();
                node.Text = row["section_name"].ToString();
                node.Name = row["sid"].ToString();
                //node.ImageIndex = 11;
                for (int i = 0; i < nodes[0].Nodes.Count; i++)
                {
                    if (nodes[0].Nodes[i].Name == "tnSection_patient")
                    {
                        nodes[0].Nodes[i].Nodes.Add(node);
                    }
                }
            }

            ArrayList list = new ArrayList();
            //DataTable dt_section = ds.Tables[0].Clone();
            //foreach (DataRow row in dt_Section_Patien)
            //{
            //    dt_section.ImportRow(row);
            //}
            SortByBed_no(dt_Section_Patien, list);
            PatientsNode.Nodes.Clear();

            foreach (InPatientInfo inpatient in list)
            {
                for (int i = 0; i < nodes[0].Nodes.Count; i++)
                {
                    if (nodes[0].Nodes[i].Name == "tnSection_patient")
                    {

                        foreach (Node nodeP in nodes[0].Nodes[i].Nodes)
                        {
                            Node Childnode = new Node();
                            Childnode.Tag = inpatient as object;
                            Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name;
                            Childnode.Name = inpatient.Id.ToString();
                            if (isNewInArea(inpatient.In_Time.ToString()))
                            {
                                Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name + " （新）";
                            }

                            if (inpatient.Gender_Code == "1")
                            {
                                Childnode.ImageIndex = 41;
                            }
                            else
                            {
                                Childnode.ImageIndex = 40;
                            }
                            if (nodeP.Text.Equals(inpatient.Section_Name))
                            {
                                nodeP.Nodes.Add(Childnode);
                                PatientsNode.Nodes.Add(Childnode.DeepCopy() as Node);
                            }
                        }
                    }
                }
            }
            #endregion

            #region 已出院(死亡)病人
            DataRow[] dt_OouArea_Patien = ds.Tables[0].Select("sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  action_state=3", "die_time DESC");
            foreach (DataRow row in dt_OouArea_Patien)
            {
                IniTree(tnDead, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            #region 已转出
            /*
            *已转出病人 
            */
            DataRow[] dt_out = ds.Tables[0].Select("sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and action_state=2 and target_said<>0");

            foreach (DataRow row in dt_out)
            {
                IniTree(tnRollOut, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion
        }

        /// <summary>
        /// 初始化树，医生站。
        /// </summary>
        /// <param name="nodes"></param>
        public static void IniTreeViewByDoctor(NodeCollection nodes)
        {
            ArrayList list = new ArrayList();
            nodes.Clear();
            //53护理等级，70医保类型，71民族，134职业，132婚姻状况，130国家
            DS_AREA = App.GetDataSet("select area_code,area_name from area_dict");
            DS_CODE = App.GetDataSet("select * from t_data_code where type in (53,70,71,134,132,130)");

            /*
             * 科室所有病人 
             */
            string Sql_Sick = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id, a.sick_doctor_name,a.sick_area_id,a.sick_area_name," +
                       "a.section_id, a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree,a.NURSE_LEVEL,a.insection_id,a.insection_name," +
                       "a.in_area_id,in_area_name,a.Die_flag,a.die_time, Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone, Office,Office_Address,Office_Phone," +
                       "Career,Relation_Name,Relation,Relation_Address, Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count, CERT_ID,Pay_Manner,IN_Circs," +
                       "native_place,Birth_Place,Folk_Code,a.Sick_Group_Id,a.card_id,a.patient_Id,b.target_sid,b.sid,b.action_state,b.action_type,c.section_name secn,a.Country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,his_id,now_addres_phone,now_address,child_age,a.exe_document_time,a.document_state " +
                       "from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0  left join t_sectioninfo c on c.sid=b.target_sid " +//
                       "where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " or b.target_sid=" + App.UserAccount.CurrentSelectRole.Section_Id + " order by to_number(case when INSTR(a.sick_bed_no, '_', 1, 1) > 1 then replace(a.sick_bed_no, '_', '') else a.sick_bed_no||'0' end)";//2017-8-16 zhangtong  length(a.sick_bed_no),a.sick_bed_no";//order by cast(a.sick_bed_id as number)"; //and a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " cast(c.bed_code as number),
            //string Sql_Sick = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id, a.sick_doctor_name,a.sick_area_id,a.sick_area_name," +
            //             "a.section_id, a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree,a.NURSE_LEVEL,a.insection_id,a.insection_name," +
            //             "a.in_area_id,in_aea_name,a.Die_flag,a.die_time, Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone, Office,Office_Address,Office_Phone," +
            //             "Career,Relation_Name,Relation,Relation_Address, Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count, CERT_ID,Pay_Manner,IN_Circs," +
            //             "native_place,Birth_Place,Folk_Code,a.Sick_Group_Id,a.card_id,a.patient_Id,b.target_sid,b.sid,b.action_state,b.action_type,a.Country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,his_id,c.bed_code,now_addres_phone,now_address,child_age,a.exe_document_time,a.document_state " +
            //             "from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_Id and b.next_id=0 inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +//
            //             "where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " or b.target_sid=" + App.UserAccount.CurrentSelectRole.Section_Id + " order by length(a.sick_bed_no),a.sick_bed_no";//order by cast(a.sick_bed_id as number)"; //and a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " cast(c.bed_code as number),
            #region 初始化树
            Node tnParent = new Node();
            tnParent.Text = "患者管理";
            tnParent.Name = "tnParentName";
            //tnParent.ImageIndex = 32;
            //tnParent.SelectedImageIndex = 7;

            /*
             * 我的病人
             */
            Node tnMyInPatient = new Node();
            tnMyInPatient.Text = "我的病人";
            tnMyInPatient.Name = "tnMypatient";
            //tnMyInPatient.ImageIndex = 36;
            //tnMyInPatient.SelectedImageIndex = 8;

            /*
             * 科室病人
             */
            Node tnSection = new Node();
            tnSection.Text = "科室病人";
            tnSection.Name = "tnArea_patient";
            //tnSection.ImageIndex = 33;
            //tnSection.SelectedImageIndex = 10;
            /*
             * 已出院(死亡)病人
             */
            Node tnDead = new Node();
            tnDead.Text = "已出院病人";
            tnDead.Name = "tnYiChuyuan_patient";
            //tnDead.ImageIndex = 37;

            Node tnMyOutPatient = new Node();
            tnMyOutPatient.Text = "我的出院病人";
            tnMyOutPatient.Name = "tnMyOutPatient";
            //tnDead.SelectedImageIndex = 9;


            /*
             * 部分护士站功能
             */

            /*
             * 待转入病人
             */
            Node tnTurnIn = new Node();
            tnTurnIn.Text = "待转入病人";
            tnTurnIn.Name = "tnDaizhuanru";
            //tnTurnIn.ImageIndex = 31;
            //tnTurnIn.SelectedImageIndex = 3;

            /*
            * 已转出病人
            */
            Node tnRollOut = new Node();
            tnRollOut.Text = "已转出病人";
            tnRollOut.Name = "tnYizhuanchu_patient";
            //tnRollOut.ImageIndex = 30;
            //tnRollOut.SelectedImageIndex = 4;

            #endregion
            DataSet ds = App.GetDataSet(Sql_Sick);

            #region 我的病人
            //App.UserAccount.UserInfo.User_num = App.ReadSqlVal("select user_num from t_userinfo where user_id='" + App.UserAccount.UserInfo.User_id + "'", 0, "user_num");
            //DataRow[] dt_MyPatien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and sick_doctor_id='" + App.UserAccount.UserInfo.User_num + "' and action_state=4");

            DataRow[] dt_MyPatien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and sick_doctor_id='" + App.UserAccount.UserInfo.User_id + "' and action_state=4");

            SortByBed_no(dt_MyPatien, list);


            foreach (InPatientInfo inpatient in list)
            {

                Node Childnode = new Node();
                Childnode.Tag = inpatient as object;
                Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name;
                Childnode.Name = inpatient.Id.ToString();

                if (isNewInArea(inpatient.In_Time.ToString()))
                {
                    Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name + " (新)";
                }


                if (inpatient.Gender_Code == "1")
                {
                    Childnode.ImageIndex = 41;
                }
                else
                {
                    Childnode.ImageIndex = 40;
                }
                tnMyInPatient.Nodes.Add(Childnode);

            }

            //foreach (DataRow row in dt_MyPatien)
            //{
            //    IniTree(tnMyInPatient, row, App.UserAccount.CurrentSelectRole.Section_name);
            //}
            #endregion





            //#region 科室病人

            //DataRow[] dt_Section_Patien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and action_state=4");
            //Node node = new Node();
            //node.Text = App.UserAccount.CurrentSelectRole.Section_name;
            //node.Name = App.UserAccount.CurrentSelectRole.Section_Id;
            ////node.ImageIndex = 33;
            ////node.SelectedImageIndex = 11;                      
            //SortByBed_no(dt_Section_Patien, list);

            ////foreach (DataRow row in dt_Section_Patien)
            ////{
            ////    IniTree(node, row, App.UserAccount.CurrentSelectRole.Section_name);
            ////}                  
            //foreach (InPatientInfo inpatient in list)
            //{

            //    Node Childnode = new Node();
            //    Childnode.Tag = inpatient as object;
            //    Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name;
            //    Childnode.Name = inpatient.Id.ToString();
            //    if (isNewInArea(inpatient.In_Time.ToString()))
            //    {
            //        Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name + " (新)";
            //    }
            //    if (inpatient.Gender_Code == "1")
            //    {
            //        Childnode.ImageIndex = 41;
            //    }
            //    else
            //    {
            //        Childnode.ImageIndex = 40;
            //    }
            //    node.Nodes.Add(Childnode);

            //}
            //tnSection.Nodes.Add(node);


            //#endregion

            #region 对应病区病人

            DataRow[] dt_Section_Patien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and action_state=4");

            Sql_getSection_ByArea = "select b.said,b.sick_area_name from t_section_area a" +
                                  " inner join t_sickareainfo b on a.said = b.said" +
                                  " where a.sid=" + App.UserAccount.CurrentSelectRole.Section_Id + "";
            DataTable ds_areaInfo = App.GetDataSet(Sql_getSection_ByArea).Tables[0];


            foreach (DataRow row in ds_areaInfo.Rows)
            {
                Node node = new Node();
                node.Text = row["sick_area_name"].ToString();
                node.Name = row["said"].ToString();
                //node.ImageIndex = 11;
                //for (int i = 0; i < tnSection.Nodes.Count; i++)
                //{
                //    if (tnSection.Nodes[i].Name == "tnArea_patient")
                //    {
                tnSection.Nodes.Add(node);
                //}
                //}
            }

            //DataTable dt_section = ds.Tables[0].Clone();
            //foreach (DataRow row in dt_Section_Patien)
            //{
            //    dt_section.ImportRow(row);
            //}
            SortByBed_no(dt_Section_Patien, list);
            PatientsNode.Nodes.Clear();

            foreach (InPatientInfo inpatient in list)
            {
                for (int i = 0; i < tnSection.Nodes.Count; i++)
                {


                    foreach (Node nodeP in tnSection.Nodes)
                    {
                        Node Childnode = new Node();
                        Childnode.Tag = inpatient as object;
                        Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name;
                        Childnode.Name = inpatient.Id.ToString();
                        if (isNewInArea(inpatient.In_Time.ToString()))
                        {
                            Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name + " （新）";
                        }

                        if (inpatient.Gender_Code == "1")
                        {
                            Childnode.ImageIndex = 41;
                        }
                        else
                        {
                            Childnode.ImageIndex = 40;
                        }
                        if (nodeP.Text.Equals(inpatient.Sick_Area_Name))
                        {
                            nodeP.Nodes.Add(Childnode);
                            PatientsNode.Nodes.Add(Childnode.DeepCopy() as Node);
                        }
                    }

                }
            }



            //Node node = new Node();
            //node.Text = App.UserAccount.CurrentSelectRole.Section_name;
            //node.Name = App.UserAccount.CurrentSelectRole.Section_Id;
            ////node.ImageIndex = 33;
            ////node.SelectedImageIndex = 11;                      
            //SortByBed_no(dt_Section_Patien, list);

            ////foreach (DataRow row in dt_Section_Patien)
            ////{
            ////    IniTree(node, row, App.UserAccount.CurrentSelectRole.Section_name);
            ////}                  


            //foreach (InPatientInfo inpatient in list)
            //{

            //    Node Childnode = new Node();
            //    Childnode.Tag = inpatient as object;
            //    Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name;
            //    Childnode.Name = inpatient.Id.ToString();
            //    if (isNewInArea(inpatient.In_Time.ToString()))
            //    {
            //        Childnode.Text = inpatient.Sick_Bed_Name + "  " + inpatient.Patient_Name + " (新)";
            //    }
            //    if (inpatient.Gender_Code == "1")
            //    {
            //        Childnode.ImageIndex = 41;
            //    }
            //    else
            //    {
            //        Childnode.ImageIndex = 40;
            //    }
            //    node.Nodes.Add(Childnode);

            //}
            //tnSection.Nodes.Add(node);
            #endregion

            #region 我的出院病人
            DataRow[] dt_MyOutPatien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and sick_doctor_id='" + App.UserAccount.UserInfo.User_id + "' and action_state=3", "die_time DESC");
            foreach (DataRow row in dt_MyOutPatien)
            {
                IniTree(tnMyOutPatient, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            tnDead.Nodes.Add(tnMyOutPatient);
            #endregion

            #region 已出院(死亡)病人
            DataRow[] dt_OouArea_Patien = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  action_state=3", "die_time DESC");
            foreach (DataRow row in dt_OouArea_Patien)
            {
                IniTree(tnDead, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            #region 待转入
            DataRow[] dt_in = ds.Tables[0].Select("section_id<>" + App.UserAccount.CurrentSelectRole.Section_Id + " and target_sid=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  action_state=2 and action_type<>'退回'");

            foreach (DataRow row in dt_in)
            {
                IniTree(tnTurnIn, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            #region 已转出
            /*
            *已转出病人 
            */
            DataRow[] dt_out = ds.Tables[0].Select("section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and action_state=2 and target_sid<>0");

            foreach (DataRow row in dt_out)
            {
                IniTree(tnRollOut, row, App.UserAccount.CurrentSelectRole.Section_name);
            }
            #endregion

            tnParent.Nodes.Add(tnTurnIn.DeepCopy() as Node);
            tnParent.Nodes.Add(tnMyInPatient.DeepCopy() as Node);
            tnParent.Nodes.Add(tnSection.DeepCopy() as Node);
            tnParent.Nodes.Add(tnDead.DeepCopy() as Node);
            tnParent.Nodes.Add(tnRollOut.DeepCopy() as Node);
            nodes.Add(tnParent.DeepCopy() as Node);
        }



        /// <summary>
        /// 根据床号按升序排，不是数字的就放在最后面。
        /// </summary>
        /// <param name="dt_section">科室病人</param>
        /// <param name="list"></param>
        private static void SortByBed_no(DataTable dt_section, ArrayList list)
        {
            /*
             *根据床号按升序排，不是数字的就放在最后面。 
             * **/
            foreach (DataRow row in dt_section.Rows)
            {
                InPatientInfo inpatient = null;
                inpatient = InitPatient(row);
                bool flag = false;
                for (int i = 0; i < list.Count; i++)
                {
                    InPatientInfo tempinfo = (InPatientInfo)list[i];
                    if (inpatient.Id == tempinfo.Id)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    list.Add(inpatient);
                }
            }

            list.Sort(new InPatientInfo());
            //for (int i = 0; i < list.Count; i++)
            //{

            //    InPatientInfo inpatient = list[i] as InPatientInfo;
            //    //int count = 0;
            //    if (!App.isNumval(inpatient.Sick_Bed_Name))
            //    {
            //        list.RemoveAt(i);
            //        list.Insert(list.Count, inpatient);
            //    }
            //    else
            //    {
            //        if (inpatient.Sick_Bed_Name.Contains("+") ||
            //            inpatient.Sick_Bed_Name.Contains("-"))
            //        {
            //            list.RemoveAt(i);
            //            list.Insert(list.Count, inpatient);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 根据床号按升序排，不是数字的就放在最后面。
        /// </summary>
        /// <param name="dt_section">科室病人</param>
        /// <param name="list"></param>
        private static void SortByBed_no(DataRow[] OrderRows, ArrayList list)
        {
            /*
             *根据床号按升序排，不是数字的就放在最后面。 
             * **/
            if (OrderRows.Length > 0)
            {
                for (int i = 0; i < OrderRows.Length; i++)
                {
                    DataRow row = OrderRows[i];
                    InPatientInfo inpatient = null;
                    inpatient = InitPatient(row);
                    bool flag = false;
                    for (int j = 0; j < list.Count; j++)
                    {
                        InPatientInfo tempinfo = (InPatientInfo)list[j];
                        if (inpatient.Id == tempinfo.Id)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        list.Add(inpatient);
                    }
                }
            }
            //foreach (DataRow row in OrderRows)
            //{
            //    InPatientInfo inpatient = null;
            //    inpatient = InitPatient(row);
            //    bool flag = false;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        InPatientInfo tempinfo = (InPatientInfo)list[i];
            //        if (inpatient.Id == tempinfo.Id)
            //        {
            //            flag = true;
            //            break;
            //        }
            //    }
            //    if (!flag)
            //    {
            //        list.Add(inpatient);
            //    }
            //}


            //list.Sort(new InPatientInfo());          
        }

        /// <summary>
        /// 更新病人信息
        /// </summary>
        /// <param name="node">当前选中的树节点</param>
        public static void UpdatPatientsNodes(Node node, int action_state)
        {
            try
            {
                if (App.UserAccount.CurrentSelectRole.Role_type == "D") //医生登录查询对应科室的病人
                {
                    Sql_section_Patient = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id," +
                                    " a.sick_doctor_name,a.sick_area_id,a.sick_area_name,a.section_id," +
                                    " a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit," +
                                    " a.Sick_Degree,a.NURSE_LEVEL,a.insection_id,a.insection_name,a.in_area_id," +
                                    " a.in_area_name,a.Die_flag,a.die_time,a.Sick_Group_Id,Marriage_State,Medicare_NO,Home_Address," +
                                    " Homepostal_Code,Home_Phone,Office,Office_Address,Office_Phone,Career,Relation_Name,Relation,Relation_Address," +
                                    " Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count,Birth_Place,Folk_Code," +
                                    " CERT_ID,Pay_Manner,IN_Circs,native_place,a.card_id,a.patient_Id,a.country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,a.his_id,a.now_addres_phone,a.now_address,a.child_age from t_in_patient a " +
                                    " inner join t_inhospital_action b on a.id=b.patient_Id inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                                    " where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "" +
                                    " and  b.action_state=" + action_state + " and  b.next_id=0 order by cast(sick_bed_id as number)";
                }
                else      //护士登录查询病区下的所有病人
                {
                    Sql_section_Patient = " select distinct a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id," +
                                         " a.sick_doctor_name,a.sick_area_id,a.sick_area_name,a.section_id," +
                                         " a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,a.Sick_Degree," +
                                         " a.NURSE_LEVEL,a.insection_id,a.insection_name,a.in_area_id,a.in_area_name,a.Die_flag,a.die_time," +
                                         " Marriage_State,Medicare_NO,Home_Address,homepostal_Code,Home_Phone," +
                                         " Office,Office_Address,Office_Phone,Career,Relation_Name,Relation,Relation_Address," +
                                         " Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count,Birth_Place,Folk_Code," +
                                         " CERT_ID,Pay_Manner,IN_Circs,native_place," +
                                         " a.Sick_Group_Id,a.card_id,a.patient_Id,a.country,a.out_id,a.PROPERTY_FLAG,a.CAREER_OTHER,a.SICK_DOC_NO,a.his_id,a.now_addres_phone,a.now_address,a.child_age from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_Id " +
                                         " inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                                         " where  a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "" +
                                         " and  b.action_state=" + action_state + " and  b.next_id=0 order by cast(sick_bed_id as number)";
                }
                DataSet ds = App.GetDataSet(Sql_section_Patient);
                DataTable dt_section = ds.Tables[0];

                //nodes.Clear();      //清除当前nodes集合下的子节点
                PatientsNode.Nodes.Clear();
                if (node.Nodes.Count > 0)
                {
                    //for (int i = 0; i < node.Nodes.Count; i++)
                    //{
                    foreach (DataRow row in dt_section.Rows)
                    {
                        if (node.Nodes[0].Nodes.Count > 0)     //选中科室病人
                        {
                            Node Childnode = new Node();
                            //初始化病人信息
                            InPatientInfo inpatient = InitPatient(row);
                            for (int i = 0; i < node.Nodes[0].Nodes.Count; i++)
                            {
                                if (inpatient.Section_Id.ToString() == node.Nodes[0].Name)//科室ID相同
                                {
                                    if (inpatient.Id.ToString() == node.Nodes[0].Nodes[i].Name)//病人ID相同
                                    {
                                        Childnode.Tag = inpatient as object;
                                        Childnode.Text = inpatient.Patient_Name;
                                        Childnode.Name = inpatient.Id.ToString();
                                        //选择图片
                                        SelectImg(Childnode, inpatient);
                                        PatientsNode.Nodes.Add(Childnode.DeepCopy() as Node);
                                        node.Nodes[0].Nodes[i].Tag = inpatient as object;
                                        SelectImg(node.Nodes[0].Nodes[i], inpatient);
                                        break;
                                    }
                                }
                            }
                        }
                        else                          //选中具体的科室
                        {
                            Node Childnode = new Node();
                            //初始化病人信息
                            InPatientInfo inpatient = InitPatient(row);
                            if (inpatient.Section_Id.ToString() == node.Name)
                            {
                                for (int i = 0; i < node.Nodes.Count; i++)
                                {
                                    if (inpatient.Id.ToString() == node.Nodes[i].Name)
                                    {
                                        Childnode.Tag = inpatient as object;
                                        Childnode.Text = inpatient.Patient_Name;
                                        Childnode.Name = inpatient.Id.ToString();
                                        //选择图片
                                        SelectImg(Childnode, inpatient);
                                        PatientsNode.Nodes.Add(Childnode.DeepCopy() as Node);
                                        node.Nodes[i].Tag = inpatient as object;
                                        SelectImg(node.Nodes[i], inpatient);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //}
                }
                else              //选中的病人节点
                {
                    if (node.Tag != null)
                    {
                        foreach (DataRow row in dt_section.Rows)
                        {
                            Node Childnode = new Node();
                            //初始化病人信息
                            InPatientInfo inpatient = InitPatient(row);
                            for (int i = 0; i < node.Parent.Nodes.Count; i++)
                            {
                                if (inpatient.Id.ToString() == node.Parent.Nodes[i].Name)
                                {
                                    Childnode.Tag = inpatient as object;
                                    Childnode.Text = inpatient.Patient_Name;
                                    Childnode.Name = inpatient.Id.ToString();
                                    //选择图片
                                    SelectImg(Childnode, inpatient);
                                    PatientsNode.Nodes.Add(Childnode.DeepCopy() as Node);
                                    node.Parent.Nodes[i].Tag = inpatient as object;
                                    SelectImg(node.Parent.Nodes[i], inpatient);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //App.Msg(ex.Message);
                //throw ex;
            }

        }
        /// <summary>
        /// 根据病人的性别选择图片
        /// </summary>
        /// <param name="Childnode">当前节点</param>
        /// <param name="inpatient">病人对象</param>
        private static void SelectImg(Node Childnode, InPatientInfo inpatient)
        {
            if (inpatient.Gender_Code == "1")//女
            {
                Childnode.ImageIndex = 41;
            }
            else
            {
                Childnode.ImageIndex = 40;
            }
        }
        /// <summary>
        /// 初始化病人信息
        /// </summary>
        /// <param name="row">当前行</param>
        /// <returns>病人对象</returns>
        public static InPatientInfo InitPatient(DataRow row)
        {
            InPatientInfo inpatient = new InPatientInfo(0, "", "", "", "", "", "", "", "", "");
            try
            {

                DataRow[] codesrows = null;
                //婚姻
                codesrows = DS_CODE.Tables[0].Select("type='132' and code='" + row["Marriage_State"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Marrige_State = codesrows[0]["name"].ToString();
                else
                    inpatient.Marrige_State = row["Marriage_State"].ToString();
                //籍贯 查不到默认北京市
                //if (ds_code_type == null)
                //    ds_code_type = App.GetDataSet("select * from t_data_code_type");
                //codesrows = ds_code_type.Tables[0].Select("type='" + row["native_place"].ToString() + "'");
                //if (codesrows.Length > 0)
                //    inpatient.Natiye_place = codesrows[0]["name"].ToString();
                //else
                //    inpatient.Natiye_place = "北京市";//row["native_place"].ToString();
                if (DS_AREA != null)
                {
                    if (row["native_place"].ToString() != "")
                    {
                        inpatient.Natiye_place = row["native_place"].ToString();
                    }
                    else
                    {
                        inpatient.Natiye_place = "";
                    }
                }

                //民族

                codesrows = DS_CODE.Tables[0].Select("type='71' and code='" + row["Folk_Code"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Folk_code = codesrows[0]["name"].ToString();
                else
                    inpatient.Folk_code = row["Folk_Code"].ToString();
                //职业

                codesrows = DS_CODE.Tables[0].Select("type='134' and code='" + row["Career"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Career = codesrows[0]["name"].ToString();
                else
                    inpatient.Career = row["Career"].ToString();

                inpatient.Career_other = row["career_other"].ToString();
                //病人性质
                codesrows = DS_CODE.Tables[0].Select("type='70' and code='" + row["Pay_Manner"].ToString() + "'");
                if (codesrows.Length > 0)
                    inpatient.Pay_Manager = codesrows[0]["name"].ToString();
                else
                    inpatient.Pay_Manager = row["Pay_Manner"].ToString();
            }
            catch (Exception ex)
            {
                //App.Msg(ex.Message);
            }
            try
            {
                inpatient.Now_address = row["now_address"].ToString();
                inpatient.Now_addres_phone = row["now_addres_phone"].ToString();
                inpatient.Country = row["country"].ToString();
                inpatient.Medicare_no = row["Medicare_NO"].ToString();
                inpatient.Home_address = row["Home_Address"].ToString();
                inpatient.HomePostal_code = row["Homepostal_Code"].ToString();
                inpatient.Home_phone = row["Home_Phone"].ToString();
                inpatient.Office = row["Office"].ToString();
                inpatient.Office_address = row["Office_Address"].ToString();
                inpatient.Office_phone = row["Office_Phone"].ToString();
                inpatient.Relation = row["Relation"].ToString();
                inpatient.Relation_name = row["Relation_Name"].ToString();
                inpatient.Relation_address = row["Relation_Address"].ToString();
                inpatient.Relation_phone = row["Relation_Phone"].ToString();
                inpatient.RelationPos_code = row["RelationPOS_Code"].ToString();
                inpatient.OfficePos_code = row["OfficePOS_Code"].ToString();
                if (row["InHospital_Count"].ToString() != "")
                    inpatient.InHospital_count = Convert.ToInt32(row["InHospital_Count"].ToString());
                inpatient.Cert_Id = row["CERT_ID"].ToString();
                inpatient.Out_Id = row["out_id"].ToString();
                inpatient.In_Circs = row["IN_Circs"].ToString();
                inpatient.Birth_place = row["Birth_Place"].ToString();
                inpatient.Id = Int32.Parse(row["id"].ToString());
                inpatient.Patient_Name = row["patient_name"].ToString();
                inpatient.Gender_Code = row["gender_code"].ToString();
                inpatient.Birthday = row["birthday"].ToString();
                inpatient.PId = row["pid"].ToString();
                if (row["insection_id"].ToString() != "")
                    inpatient.Insection_Id = Convert.ToInt32(row["insection_id"]);
                inpatient.Insection_Name = row["insection_name"].ToString();
                inpatient.In_Area_Id = Convert.ToInt32(row["in_area_id"]).ToString();
                inpatient.In_Area_Name = row["in_area_name"].ToString();
                //计算年龄和单位
                int year, month, day;
                if (row["age"].ToString() != "")
                {
                    inpatient.Age = row["age"].ToString();
                }
                else
                {
                    GetAgeByBirthday(Convert.ToDateTime(inpatient.Birthday), App.GetSystemTime(), out year, out month, out day);
                    if (year != 0)
                    {
                        inpatient.Age = year.ToString();
                        inpatient.Age_unit = "岁";
                    }
                    //else if (year == 0 && month != 0)
                    //{
                    //    inpatient.Age = month.ToString();
                    //    inpatient.Age_unit = "月";
                    //}
                    //else if (year == 0 && month == 0)
                    //{
                    //    inpatient.Age = day.ToString();
                    //    inpatient.Age_unit = "天";
                    //}
                }
                //if (row["age_unit"].ToString() == "")
                //{
                //    inpatient.Age_unit = "岁";
                //}
                //else
                //{
                inpatient.Age_unit = row["age_unit"].ToString();
                //}
                try
                {
                    inpatient.Child_age = row["child_age"].ToString();
                }
                catch (Exception) { }
                //inpatient.Action_State = row["action_state"].ToString();
                inpatient.Sick_Doctor_Id = row["sick_doctor_id"].ToString();
                inpatient.Sick_Doctor_Name = row["sick_doctor_name"].ToString();
                if (row["sick_area_id"].ToString() != "")
                    inpatient.Sike_Area_Id = Int32.Parse(row["sick_area_id"].ToString()).ToString();
                inpatient.Sick_Area_Name = row["sick_area_name"].ToString();
                if (row["section_id"].ToString() != "")
                    inpatient.Section_Id = Int32.Parse(row["section_id"].ToString());
                inpatient.Section_Name = row["section_name"].ToString();
                if (row["in_time"] != null)
                    inpatient.In_Time = DateTime.Parse(row["in_time"].ToString());
                inpatient.State = row["state"].ToString();
                if (row["sick_bed_id"].ToString() != "")
                    inpatient.Sick_Bed_Id = Int32.Parse(row["sick_bed_id"].ToString());
                inpatient.Sick_Bed_Name = row["sick_bed_no"].ToString();


                inpatient.Sick_Degree = Convert.ToString(row["Sick_Degree"]);
                inpatient.Nurse_Level = Convert.ToString(row["Nurse_Level"]);
                if (row["Die_flag"].ToString() != "")
                    inpatient.Die_flag = Convert.ToInt32(row["Die_flag"]);
                if (row["die_time"].ToString() != "")
                {
                    inpatient.Die_time = Convert.ToDateTime(row["die_time"]);
                }
                if (row["Sick_Group_Id"].ToString() != "")
                    inpatient.Sick_Group_Id = Convert.ToInt32(row["Sick_Group_Id"]);
                inpatient.Card_Id = row["card_id"].ToString();

                inpatient.Patient_Id = row["patient_Id"].ToString();
                if (row["PROPERTY_FLAG"] != null)
                    inpatient.Property_flag = row["PROPERTY_FLAG"].ToString();
                if (row["CAREER_OTHER"] != null)
                    inpatient.Property_flag = row["CAREER_OTHER"].ToString();
                inpatient.Sick_doc_no = row["SICK_DOC_NO"].ToString();

                inpatient.His_id = row["his_id"].ToString();
                inpatient.Exe_document_time = row["exe_document_time"].ToString();
                try
                {
                    if (row["document_state"] != null && row["document_state"].ToString() != "")
                        inpatient.Document_State = row["document_state"].ToString();
                }
                catch (System.Exception ex)
                {

                }

            }
            catch (System.Exception ex)
            {
                //App.Msg(ex.Message);
            }
            return inpatient;
        }


        /// 通过生日和当前日期计算岁，月，天

        /// </summary>

        /// <param name="birthday">生日</param>

        /// <param name="now">当前日期</param>

        /// <param name="year">岁</param>

        /// <param name="month">月</param>

        /// <param name="day">天</param>

        public static void GetAgeByBirthday(DateTime birthday, DateTime now, out int year, out int month, out int day)
        {
            //int day, month, year;
            //生日的年，月，日

            int birthdayYear = birthday.Year;

            int birthdayMonth = birthday.Month;

            int birthdayDay = birthday.Day;



            //当前时间的年,月,日



            int nowYear = now.Year;

            int nowMonth = now.Month;

            int nowDay = now.Day;



            //得到天

            if (nowDay >= birthdayDay)
            {

                day = nowDay - birthdayDay;

            }

            else
            {

                nowMonth -= 1;

                day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;

            }



            //得到月

            if (nowMonth >= birthdayMonth)
            {

                month = nowMonth - birthdayMonth;

            }

            else
            {

                nowYear -= 1;

                month = 12 + nowMonth - birthdayMonth;

            }



            //得到年

            year = nowYear - birthdayYear;
        }

        /// 通过生日和当前日期计算岁，月，天

        /// </summary>

        /// <param name="birthday">生日</param>

        /// <param name="now">当前日期</param>

        /// <param name="year">岁</param>

        /// <param name="month">月</param>

        /// <param name="day">天</param>

        public static void GetAgeByBirthday(DateTime birthday, DateTime now, out int year, out int month, out int day, out int hour, out int minute)
        {
            //生日的年,月,日,时,分
            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;
            int birthdayHour = birthday.Hour;
            int birthdayMinute = birthday.Minute;

            //当前时间的年,月,日,时,分
            int nowYear = now.Year;
            int nowMonth = now.Month;
            int nowDay = now.Day;
            int nowHour = now.Hour;
            int nowMinute = now.Minute;


            //得到分钟
            if (birthdayYear == nowYear && birthdayMonth == nowMonth && birthdayDay == nowDay && birthdayHour == nowHour)
            {
                minute = nowMinute - birthdayMinute;
            }
            else if (birthdayYear == nowYear && birthdayMonth == nowMonth && birthdayDay == nowDay && (birthdayHour == nowHour - 1))
            {
                minute = nowMinute + 60 - birthdayMinute;
            }
            else if (birthdayYear == nowYear && birthdayMonth == nowMonth && birthdayDay == (nowDay - 1) && birthdayHour == 23)
            {
                minute = nowMinute + 60 - birthdayMinute;
            }
            else
            {
                minute = 0;
            }

            //得到小时
            if (birthdayHour == nowHour)//Hour相等时,比较分钟数
            {
                if (birthdayMinute <= nowMinute)
                {
                    hour = 0;
                }
                else
                {
                    nowDay -= 1;
                    hour = 23;
                }
            }
            else if (birthdayHour < nowHour)
            {
                if (birthdayMinute <= nowMinute)
                {
                    hour = nowHour - birthdayHour;
                }
                else
                {
                    hour = nowHour - birthdayHour - 1;
                }
            }
            else
            {
                nowDay -= 1;
                if (birthdayMinute <= nowMinute)
                {
                    hour = 24 - birthdayHour + nowHour;
                }
                else
                {
                    hour = 24 - birthdayHour + nowHour - 1;
                }
            }

            //得到天

            if (nowDay >= birthdayDay)
            {

                day = nowDay - birthdayDay;

            }
            else
            {

                nowMonth -= 1;

                day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;

            }



            //得到月

            if (nowMonth >= birthdayMonth)
            {

                month = nowMonth - birthdayMonth;

            }

            else
            {

                nowYear -= 1;

                month = 12 + nowMonth - birthdayMonth;

            }



            //得到年

            year = nowYear - birthdayYear;
        }


        /// <summary>

        /// 获取天数

        /// </summary>

        private static int GetDay(int month, int year)
        {

            int day = 0;

            switch (month)
            {

                case 1:

                case 3:

                case 5:

                case 7:

                case 8:

                case 10:

                case 12:

                    day = 31;

                    break;

                case 2:

                    //闰年天，平年天

                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {

                        day = 29;

                    }

                    else
                    {

                        day = 28;

                    }

                    break;

                case 4:

                case 6:

                case 9:

                case 11:

                    day = 30;

                    break;

            }

            return day;

        }


        /// <summary>
        /// 初始化病人信息
        /// </summary>
        /// <param name="row">当前行</param>
        /// <param name="bed_Id">床号id</param>
        /// <param name="bed_No">床号名称</param>
        /// <returns>病人对象</returns>
        public static InPatientInfo InitPatient(InPatientInfo oldInpatient, int bed_Id, string bed_No)
        {
            InPatientInfo inpatient = new InPatientInfo(0, "", "", "", "", "0", "", "", "", "");
            if (oldInpatient != null)
            {
                inpatient.Marrige_State = oldInpatient.Marrige_State;
                inpatient.Medicare_no = oldInpatient.Medicare_no;
                inpatient.Home_address = oldInpatient.Home_address;
                inpatient.HomePostal_code = oldInpatient.HomePostal_code;
                inpatient.Home_phone = oldInpatient.Home_phone;
                inpatient.Office = oldInpatient.Office;
                inpatient.Office_address = oldInpatient.Office_address;
                inpatient.Office_phone = oldInpatient.Office_phone;
                inpatient.Relation = oldInpatient.Relation;
                inpatient.Relation_address = oldInpatient.Relation_address;
                inpatient.Relation_phone = oldInpatient.Relation_phone;
                inpatient.RelationPos_code = oldInpatient.RelationPos_code;
                inpatient.OfficePos_code = oldInpatient.OfficePos_code;
                inpatient.InHospital_count = oldInpatient.InHospital_count;
                inpatient.Cert_Id = oldInpatient.Cert_Id;
                inpatient.Pay_Manager = oldInpatient.Pay_Manager;
                inpatient.In_Circs = oldInpatient.In_Circs;
                inpatient.Natiye_place = oldInpatient.Natiye_place;
                inpatient.Birth_place = oldInpatient.Birth_place;
                inpatient.Folk_code = oldInpatient.Folk_code;

                inpatient.Id = oldInpatient.Id;
                inpatient.Patient_Name = oldInpatient.Patient_Name;
                inpatient.Gender_Code = oldInpatient.Gender_Code;
                inpatient.Birthday = oldInpatient.Birthday;
                inpatient.PId = oldInpatient.PId;
                inpatient.Insection_Id = oldInpatient.Insection_Id;
                inpatient.Insection_Name = oldInpatient.Insection_Name;
                inpatient.In_Area_Id = oldInpatient.In_Area_Id;
                inpatient.In_Area_Name = oldInpatient.In_Area_Name;
                inpatient.Age = oldInpatient.Age;
                inpatient.Sick_Doctor_Id = oldInpatient.Sick_Doctor_Id;
                inpatient.Sick_Doctor_Name = oldInpatient.Sick_Doctor_Name;
                inpatient.Sike_Area_Id = oldInpatient.Sike_Area_Id;
                inpatient.Sick_Area_Name = oldInpatient.Sick_Area_Name;
                inpatient.Section_Id = oldInpatient.Section_Id;
                inpatient.Section_Name = oldInpatient.Section_Name;
                inpatient.In_Time = oldInpatient.In_Time;
                inpatient.State = oldInpatient.State;
                inpatient.Sick_Bed_Id = bed_Id;
                inpatient.Sick_Bed_Name = bed_No;
                inpatient.Age_unit = oldInpatient.Age_unit;
                inpatient.Sick_Degree = oldInpatient.Sick_Degree;
                inpatient.Nurse_Level = oldInpatient.Nurse_Level;
                inpatient.Die_flag = oldInpatient.Die_flag;
                inpatient.Sick_Group_Id = oldInpatient.Sick_Group_Id;
                inpatient.Card_Id = oldInpatient.Card_Id;
                inpatient.Patient_Id = oldInpatient.Patient_Id;
            }
            return inpatient;
        }

        /// <summary>
        /// 更新病人信息
        /// </summary>
        /// <param name="oldInpatient">已更新更新病人</param>
        /// <param name="inpatient">需要更新的病人</param>
        /// <returns>病人对象</returns>
        public static void InitPatient(InPatientInfo oldInpatient, InPatientInfo inpatient)
        {
            inpatient.Marrige_State = oldInpatient.Marrige_State;
            inpatient.Medicare_no = oldInpatient.Medicare_no;
            inpatient.Home_address = oldInpatient.Home_address;
            inpatient.HomePostal_code = oldInpatient.HomePostal_code;
            inpatient.Home_phone = oldInpatient.Home_phone;
            inpatient.Office = oldInpatient.Office;
            inpatient.Office_address = oldInpatient.Office_address;
            inpatient.Office_phone = oldInpatient.Office_phone;
            inpatient.Relation = oldInpatient.Relation;
            inpatient.Relation_address = oldInpatient.Relation_address;
            inpatient.Relation_phone = oldInpatient.Relation_phone;
            inpatient.RelationPos_code = oldInpatient.RelationPos_code;
            inpatient.OfficePos_code = oldInpatient.OfficePos_code;
            inpatient.InHospital_count = oldInpatient.InHospital_count;
            inpatient.Cert_Id = oldInpatient.Cert_Id;
            inpatient.Pay_Manager = oldInpatient.Pay_Manager;
            inpatient.In_Circs = oldInpatient.In_Circs;
            inpatient.Natiye_place = oldInpatient.Natiye_place;
            inpatient.Birth_place = oldInpatient.Birth_place;
            inpatient.Folk_code = oldInpatient.Folk_code;

            inpatient.Id = oldInpatient.Id;
            inpatient.Patient_Name = oldInpatient.Patient_Name;
            inpatient.Gender_Code = oldInpatient.Gender_Code;
            inpatient.Birthday = oldInpatient.Birthday;
            inpatient.PId = oldInpatient.PId;
            inpatient.Insection_Id = oldInpatient.Insection_Id;
            inpatient.Insection_Name = oldInpatient.Insection_Name;
            inpatient.In_Area_Id = oldInpatient.In_Area_Id;
            inpatient.In_Area_Name = oldInpatient.In_Area_Name;
            inpatient.Age = oldInpatient.Age;
            inpatient.Sick_Doctor_Id = oldInpatient.Sick_Doctor_Id;
            inpatient.Sick_Doctor_Name = oldInpatient.Sick_Doctor_Name;
            inpatient.Sike_Area_Id = oldInpatient.Sike_Area_Id;
            inpatient.Sick_Area_Name = oldInpatient.Sick_Area_Name;
            inpatient.Section_Id = oldInpatient.Section_Id;
            inpatient.Section_Name = oldInpatient.Section_Name;
            inpatient.In_Time = oldInpatient.In_Time;
            inpatient.State = oldInpatient.State;
            inpatient.Sick_Bed_Id = oldInpatient.Sick_Bed_Id;
            inpatient.Sick_Bed_Name = oldInpatient.Sick_Bed_Name;
            inpatient.Age_unit = oldInpatient.Age_unit;
            inpatient.Sick_Degree = oldInpatient.Sick_Degree;
            inpatient.Nurse_Level = oldInpatient.Nurse_Level;
            inpatient.Die_flag = oldInpatient.Die_flag;
            inpatient.Sick_Group_Id = oldInpatient.Sick_Group_Id;
            inpatient.Card_Id = oldInpatient.Card_Id;
            inpatient.Patient_Id = oldInpatient.Patient_Id;
            inpatient.Medicare_no = oldInpatient.Medicare_no;
        }




        private static void IniTree(Node ChildNode, DataRow row, string sectionName)
        {
            Node node = new Node();
            InPatientInfo inpatient = InitPatient(row);
            node.Tag = inpatient as object;
            if (ChildNode.Name == "tnDaizhuanru")          //找出病人再异动表里面的最后一条记录来源科室
            {
                //node.Text = inpatient.Patient_Name + " " + sectionName;
                node.Text = inpatient.Patient_Name + " (" + row["section_name"].ToString() + ")";
            }
            else if (ChildNode.Name == "tnMypatient" ||
                ChildNode.Name == inpatient.Section_Id.ToString() ||
                ChildNode.Name == inpatient.Sike_Area_Id.ToString())
            {
                node.Text = inpatient.Sick_Bed_Name + " " + inpatient.Patient_Name;
            }
            else if (ChildNode.Name == "tnYiChuyuan_patient" && inpatient.Die_flag == 1)
            {
                node.Text = inpatient.Patient_Name + "(死亡)";
            }
            else if (ChildNode.Name == "tnMyOutPatient")
            {
                node.Text = inpatient.Patient_Name;
                if (inpatient.Die_flag == 1)
                {
                    node.Text = inpatient.Patient_Name + "(死亡)";
                }
                if (inpatient.Exe_document_time.Length > 0)
                {
                    node.Text += " " + Convert.ToDateTime(inpatient.Exe_document_time).ToString("MM-dd") + "归档";
                }
            }
            else if (ChildNode.Name == "tnYizhuanchu_patient")
            {
                if (row["action_type"].ToString() == "退回")
                    node.Text = inpatient.Patient_Name + "(退回)";
                else if (row["action_type"].ToString() == "转出" && row["secn"].ToString() != "")
                {
                    node.Text = inpatient.Patient_Name + " (" + row["secn"].ToString() + ")";
                }
                else
                    node.Text = inpatient.Patient_Name;
            }
            else
            {
                node.Text = inpatient.Patient_Name;
            }

            if (isNewInArea(inpatient.In_Time.ToString()))
            {
                node.Text = node.Text + " （新）";
            }


            //头像规则
            //0-6岁幼年 7-17少年 18-40 青年 41-65 中年 66以上老年
            if (inpatient.Gender_Code == "1")//女
            {
                //if (inpatient.Age <= 6)
                //{
                //    node.ImageIndex = 22;//幼女
                //}
                //else if (inpatient.Age > 6 && inpatient.Age <= 17)
                //{
                //    node.ImageIndex = 24;//少女
                //}
                //else if (inpatient.Age > 17 && inpatient.Age <= 40)
                //{
                //    node.ImageIndex = 12;//青年
                //}
                //else if (inpatient.Age > 40 && inpatient.Age <= 65)
                //{
                //    node.ImageIndex = 26;//中年
                //}
                //else if (inpatient.Age > 65)
                //{
                //    node.ImageIndex = 28;
                //}
                node.ImageIndex = 41;
                //node.SelectedImageIndex = 12;
            }
            else
            {
                node.ImageIndex = 40;
                //node.SelectedImageIndex = 13;
            }
            node.Name = inpatient.Id.ToString();
            ChildNode.Nodes.Add(node);
        }

        /// <summary>
        /// 根据当前病区找到该病区下面的所有科室名称,与当前病人所属科室比较。
        /// </summary>
        /// <returns></returns>
        public static bool IsSectionName(string str)
        {
            bool flag = false;
            DataSet ds = App.GetDataSet(Sql_getSection_ByArea);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string strTarget = row["section_name"].ToString();
                        if (str.Equals(strTarget))
                        {
                            flag = true;
                            return flag;
                        }
                    }
                }
            }
            return flag;
        }


        /// <summary>
        /// 根据科室，病区，得到床号,状态。
        /// </summary>
        /// <param name="inPatientInfo"></param>
        /// <returns></returns>
        public static DataTable GetBedInfo(InPatientInfo inPatientInfo)
        {
            string SqlGetBed = "select bed_id,bed_no,state from t_sickbedinfo" +
                               " where said =" + inPatientInfo.Sike_Area_Id + "";// order by cast(bed_id as number)
            DataSet ds = App.GetDataSet(SqlGetBed);
            DataTable dt = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return dt;


        }


        private static Node temp = null;
        /// <summary>
        /// 病人小卡操作后，移除该病人对应树的节点。
        /// </summary>
        public static Node RefCardTree(NodeCollection nodes, InPatientInfo inPatient)
        {
            foreach (Node node in nodes)
            {
                if (node.Tag == null)
                {
                    RefCardTree(node.Nodes, inPatient);
                }
                else
                {
                    if (node.Tag.GetType().ToString().Contains("InPatientInfo"))
                    {
                        InPatientInfo inpatient = node.Tag as InPatientInfo;
                        if (inpatient.Id == inPatient.Id)
                        {
                            node.Remove();
                            temp = node.DeepCopy() as Node;
                            return temp;
                        }
                    }
                }
            }
            return temp;
        }
        /// <summary>
        /// 根据床号id得到病人信息
        /// </summary>
        /// <param name="bedId">床号Id</param>
        /// <returns>InPatientInfo对象</returns>
        public static InPatientInfo GetInpatientInfoById(int bedId)
        {
            string SqlById = "select a.id,patient_name,gender_code,birthday,a.pid,age,sick_doctor_id," +
                             " sick_doctor_name,sick_area_id,sick_area_name,section_id," +
                             " section_name,in_time,state,sick_bed_id,sick_bed_no,age_unit,Sick_Degree," +
                             " NURSE_LEVEL,insection_id,insection_name,in_area_id,in_area_name,Die_flag,a.die_time," +
                             " a.Sick_Group_Id,Marriage_State,Medicare_NO,Home_Address,homepostal_Code,Home_Phone," +
                             " Office,Office_Address,Office_Phone,Career,Relation_Name,Relation,Relation_Address," +
                             " Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count,Birth_Place,Folk_Code," +
                             " CERT_ID,Pay_Manner,IN_Circs,native_place,a.card_id,a.patient_Id,country,out_id,a.now_address,now_addres_phone,PROPERTY_FLAG,CAREER_OTHER,SICK_DOC_NO,HIS_ID,a.child_age from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_Id  " +
                             " where b.action_state=4 and b.id in (select max(id) from t_inhospital_action group by patient_Id) and a.sick_bed_id =" + bedId + "";
            InPatientInfo inpatient = null;
            DataSet ds = App.GetDataSet(SqlById);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        inpatient = InitPatient(dt.Rows[0]);
                    }
                }
            }
            return inpatient;
        }

        /// <summary>
        /// 根据病人id得到病人信息
        /// </summary>
        /// <param name="bedId">病人id</param>
        /// <returns>InPatientInfo对象</returns>
        public static InPatientInfo GetInpatientInfoByPid(string patient)
        {
            string SqlByPId = "select * from t_in_patient where id ='" + patient + "'";
            InPatientInfo inpatient = null;
            DataSet ds = App.GetDataSet(SqlByPId);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    inpatient = InitPatient(dt.Rows[0]);
                }
            }
            return inpatient;
        }

        /// <summary>
        /// 根据病人pid得到病人信息
        /// </summary>
        /// <param name="bedId">病人pid</param>
        /// <returns>InPatientInfo对象</returns>
        public static InPatientInfo GetInpatientInfoByPid(DataTable dt)
        {
            InPatientInfo inpatient = null;
            if (dt.Rows.Count > 0)
            {
                inpatient = InitPatient(dt.Rows[0]);
            }

            return inpatient;
        }

        /// <summary>
        ///  显示文书
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(AdvTree trvBook)
        {
            trvBook.Nodes.Clear();
            //查出所有文书
            string SQl = "select * from T_TEXT where enable_flag='Y' and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') and (sid='0' or instr(sid,'" + CurrentPatient.Section_Id.ToString() + ",')=1 or instr(sid,'," + CurrentPatient.Section_Id.ToString() + ",')>0) order by shownum asc";
            //找出文书所有类别
            string Sql_Category = "select * from t_data_code where type=31 and enable='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);
            //得到文书的类型
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (datacodes != null)
            {
                for (int j = 0; j < datacodes.Length; j++)    //添加文书类别节点
                {
                    Node tempNode = new Node();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j];
                    tempNode.ImageIndex = 1;
                    //tempNode.SelectedImageIndex = 1;
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            Node tn = new Node();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();
                            //插入顶级节点
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);   //插入文书的子类文书。                                
                            }
                        }
                    }
                    if (tempNode.Nodes.Count > 0)
                    {
                        trvBook.Nodes.Add(tempNode);
                        SetTreeNodesImage(trvBook.Nodes);
                    }
                }
            }
        }

        

        /// <summary>
        /// 获取医生类缩写的文书
        /// </summary>
        /// <param name="trvD"></param>
        public static void getDoctorFinishedText(ref Node trvD, string docStrs)
        {
            //118
            string sql = "select * from T_TEXT where enable_flag='Y' and id in(" + docStrs + ",118,103" + ") and right_range in ('D','A') order by shownum asc "; //and right_range='D' and id in(" + docStrs + ") or id in (118,2022)
            DataSet dstree = App.GetDataSet(sql);
            Class_Text[] Directionarys = GetSelectClassDs(dstree);
            if (Directionarys != null)
            {
                /*
                 * 首页
                 */
                //for (int i = 0; i < Directionarys.Length; i++)
                //{
                //    Node tn = new Node();
                //    tn.Tag = Directionarys[i];
                //    tn.Text = Directionarys[i].Textname;
                //    tn.Name = Directionarys[i].Id.ToString();
                //    if (Directionarys[i].Issimpleinstance == "1")
                //    {
                //        tn.Image = global::Base_Function.Resource.多例文书;
                //    }
                //    else
                //    {
                //        tn.Image = global::Base_Function.Resource.单例文书;
                //    }

                //    if (tn.Name == "118" ||
                //        tn.Name == "2022")
                //    {
                //        trvD.Nodes.Add(tn);
                //    }
                //}

                /*
                * 入院记录
                */
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Parentid == 102 || Directionarys[i].Id == 119)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        if (Directionarys[i].Issimpleinstance == "1")
                        {
                            tn.Image = global::Base_Function.Resource.多例文书;
                        }
                        else
                        {
                            tn.Image = global::Base_Function.Resource.单例文书;
                        }

                        trvD.Nodes.Add(tn);
                    }
                }

                /*
                 * 病程记录
                 * 103
                 */

                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Id == 103)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        if (Directionarys[i].Issimpleinstance == "1")
                        {
                            tn.Image = global::Base_Function.Resource.多例文书;
                        }
                        else
                        {
                            tn.Image = global::Base_Function.Resource.单例文书;
                        }

                        //for (int j = 0; j < Directionarys.Length; j++)
                        //{
                        //    if (Directionarys[j].Parentid == 103)
                        //    {
                        //        Node tn2 = new Node();
                        //        tn2.Tag = Directionarys[j];
                        //        tn2.Text = Directionarys[j].Textname;
                        //        tn2.Name = Directionarys[j].Id.ToString();
                        //        if (Directionarys[j].Issimpleinstance == "1")
                        //        {
                        //            tn2.Image = global::Base_Function.Resource.多例文书;
                        //        }
                        //        else
                        //        {
                        //            tn2.Image = global::Base_Function.Resource.单例文书;
                        //        }
                        //        tn.Nodes.Add(tn2);
                        //    }
                        //}
                        trvD.Nodes.Add(tn);
                        break;
                    }
                }

                /*
                 * 其他文书（不含知情同意书）
                 */
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Parentid != 103 && Directionarys[i].Parentid != 102 && Directionarys[i].Id != 119 &&
                        Directionarys[i].Id != 118 && Directionarys[i].Txxttype != "19760")
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        if (Directionarys[i].Issimpleinstance == "1")
                        {
                            tn.Image = global::Base_Function.Resource.多例文书;
                        }
                        else
                        {
                            tn.Image = global::Base_Function.Resource.单例文书;
                        }

                        trvD.Nodes.Add(tn);
                    }
                }

                /*
                * 知情同意书
                */
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Parentid != 103 && Directionarys[i].Parentid != 102 &&
                        Directionarys[i].Id != 118 && Directionarys[i].Txxttype == "19760")
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        if (Directionarys[i].Issimpleinstance == "1")
                        {
                            tn.Image = global::Base_Function.Resource.多例文书;
                        }
                        else
                        {
                            tn.Image = global::Base_Function.Resource.单例文书;
                        }

                        trvD.Nodes.Add(tn);
                    }
                }
                SetTreeNodesImage(trvD.Nodes);
            }
        }

        /// <summary>
        /// 添加住院病程记录
        /// </summary>
        private static void AddZYNode(NodeCollection tempNode, Node ByAddNode)
        {
            foreach (Node node in tempNode)
            {
                if (tempNode.Count > 0)
                {
                    AddZYNode(node.Nodes, ByAddNode);
                }
                if (node.Text == "住院病程记录")
                {
                    ByAddNode.Nodes.Add(node.DeepCopy());
                }
            }
        }


        /// <summary>
        /// 获取相关的护士类型文书节点(已写)
        /// </summary>
        /// <param name="trvD">已写文书的树</param>
        public static void getNurseText(ref Node trvD)
        {
            //转科之后也加载之前科室的护士文书,获取护理记录单定制文书id 空（或者 D）-成人, C-儿童, O-产科, B-新生儿; 和 产程图
            string sql = "select * from (select * from T_TEXT where enable_flag='Y' and right_range='N' and (sid='0' or instr(sid,'" + CurrentPatient.Section_Id.ToString() + ",')=1 or instr(sid,'," + CurrentPatient.Section_Id.ToString() + ",')>1 or " +
                        " id in (select a.textkind_id from t_patients_doc a  where a.patient_Id='" + CurrentPatient.Id + "'and a.textkind_id in (select id from T_TEXT where enable_flag='Y' and right_range='N'))) " +
                        " union select * from T_TEXT where enable_flag='Y' and right_range='N' and id in (" +
                        " select distinct textkind_id from ( " +
                        " select count(*) con,(CASE  " +
                        " WHEN RECORD_TYPE='O' THEN 2177  " +
                        " WHEN RECORD_TYPE='C' THEN 2174  " +
                        " WHEN RECORD_TYPE='B' THEN 2299811  " +
                        " ELSE 2171 END) textkind_id from t_nurse_record tn where  patient_Id=" + CurrentPatient.Id + " group by RECORD_TYPE " +
                        " union " +
                        " select count(*) con,841299 textkind_id from t_partogram where patient_Id=" + CurrentPatient.Id + ") where con>0 " +
                        ")) order by shownum,id asc ";
            DataSet dstree = App.GetDataSet(sql);
            Class_Text[] Directionarys = GetSelectClassDs(dstree);
            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    trvD.Nodes.Add(tn);
                }
                SetTreeNodesImage(trvD.Nodes);
            }
        }



        /// <summary>
        /// 设置树图标
        /// </summary>
        /// <param name="nodes">节点集合</param>
        public static void SetTreeNodesImage(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Parent == null)
                {
                    nodes[i].Image = global::Base_Function.Resource.住院记录;
                }
                else if (nodes[i].Nodes.Count > 0 && nodes[i].Parent != null)
                {
                    nodes[i].Image = global::Base_Function.Resource.文书类型;
                }
                else
                {
                    if (nodes[i].Tag != null)
                    {
                        Class_Text cunrrentDir = nodes[i].Tag as Class_Text;
                        if (cunrrentDir != null)
                        {
                            if (cunrrentDir.Issimpleinstance == "0")   //是单例文书
                            {
                                nodes[i].Image = global::Base_Function.Resource.单例文书;
                            }
                            else
                            {
                                nodes[i].Image = global::Base_Function.Resource.多例文书;
                            }
                        }
                    }
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    SetTreeNodesImage(nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        public static void SetTreeView(Class_Text[] Directionarys, Node current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Text cunrrentDir = (Class_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    if (Directionarys[i].Issimpleinstance == "0")   //是单例文书
                    {
                        tn.Image = global::Base_Function.Resource.单例文书;
                    }
                    else
                    {
                        tn.Image = global::Base_Function.Resource.多例文书;
                    }
                    if (tn.Text=="体温记录")
                    {
                        if (!CurrentPatient.PId.Contains("_"))
                        {
                            current.Nodes.Add(tn);
                        }
                    }
                    else if (tn.Text=="新生儿体温单")
                    {
                        if (CurrentPatient.PId.Contains("_") || (App.UserAccount.CurrentSelectRole.Section_Id == "8578992" || App.UserAccount.CurrentSelectRole.Sickarea_Id == "8579000"))
                        {
                            current.Nodes.Add(tn);
                        }
                    }
                    else
                    {
                        current.Nodes.Add(tn);
                    }
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        public static Class_Text[] GetSelectClassDs(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Text[] class_text = new Class_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Sid = tempds.Tables[0].Rows[i]["sid"].ToString();
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["issimpleinstance"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Right_range = tempds.Tables[0].Rows[i]["right_range"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                        class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();

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
        /// 实例化天津武警医院老病历系统的查询结果
        /// </summary>
        /// <returns></returns>
        public static Class_Mr_File_Index[] GetEveryTimeDocs(DataRow[] dr)
        {
            if (dr != null && dr.Length != 0)
            {
                Class_Mr_File_Index[] class_file = new Class_Mr_File_Index[dr.Length];
                for (int i = 0; i < dr.Length; i++)
                {
                    class_file[i] = new Class_Mr_File_Index();
                    class_file[i].Patient_id = dr[i]["patient_id"].ToString();
                    class_file[i].Visit_id = dr[i]["visit_id"].ToString();
                    class_file[i].File_no = dr[i]["file_no"].ToString();
                    class_file[i].File_name = dr[i]["file_name"].ToString();
                    class_file[i].Topic = dr[i]["topic"].ToString();
                    class_file[i].Creator_name = dr[i]["creator_name"].ToString();
                    class_file[i].Creator_id = dr[i]["creator_id"].ToString();
                    class_file[i].Create_date_time = dr[i]["create_date_time"].ToString();
                    class_file[i].Last_modify_date_time = dr[i]["last_modify_date_time"].ToString();

                }
                return class_file;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Datacodecs[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Datacodecs[] Directionary = new Class_Datacodecs[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Datacodecs();
                        Directionary[i].Id = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].Shortchut_code = tempds.Tables[0].Rows[i]["SHORTCUT_CODE"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                    }
                    return Directionary;
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
        /// 获得当前病区科室所有已占用的床号
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetSickAreaBusyBed(int sick_Area)
        {
            DataTable dt = null;
            if (sick_Area != 0)
            {
                string Sql_GetBusyBed = "select a.sick_bed_id,a.sick_bed_no from t_in_patient a " +
                                         " inner join t_sickbedinfo b on a.sick_bed_id = b.bed_id" +
                                         " where sick_area_id=" + sick_Area + " and b.state=74";
                DataSet ds = App.GetDataSet(Sql_GetBusyBed);
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }



        /// <summary>
        /// 根据病人住院号，得到该病人的所有文书
        /// </summary>
        /// <param name="patient_id">病人id号</param>
        /// <returns>有文书的树节点</returns>
        public static Node SelectDoc(int patient_id)
        {
            Node nodeTemp = new Node();
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id," +
                         " a.textname,a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid,a.israplacehightdoctor,a.israplacehightdoctor2,a.SECTION_NAME,t.parentid,t.isbelongtotype  from t_patients_doc a " +
                         "  inner join t_text t on a.textkind_id=t.id where a.patient_Id='" + patient_id + "' order by a.doc_name";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //去掉重复的文书id
                    string tid = "0";
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["tid"].ToString() != "")
                        {
                            if (tid != row["tid"].ToString())
                            {
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
                                //病程记录单独处理
                                //if (row["isbelongtotype"].ToString() == "484" && row["parentid"].ToString() == "103")
                                //{
                                //    pDoc.Textkind_id = 103;
                                //}
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
                                pDoc.Section_name = row["SECTION_NAME"].ToString();
                                Node node = new Node();
                                node.Text = pDoc.Docname;
                                node.Tag = pDoc as object;
                                node.Name = pDoc.Id.ToString();
                                //node.ImageIndex = 19;
                                //node.SelectedImageIndex = 19;
                                nodeTemp.Nodes.Add(node);
                                tid = row["tid"].ToString();
                            }
                        }
                    }
                }
            }
            return nodeTemp;
        }

        /// <summary>
        /// 根据病人住院号，得到该病人当前类型的所有文书
        /// </summary>
        /// <param name="pid">主键</param>
        ///<param name="tid">住文书类型id</param>
        /// <returns>有文书的树节点</returns>
        public static Node SelectDoc(int id, string tid)
        {
            Node nodeTemp = new Node();
            //string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,b.textname,b.create_time,a.patient_Id from t_patients_doc a " +
            //             "left join t_quality_text b on a.tid=b.tid where a.patient_Id='" + id + "' and a.textkind_id=" + tid + " order by a.textname desc";
            string sql = "select tid,pid,textkind_id,belongtosys_id,sickkind_id,textname,doc_name,patient_Id from t_patients_doc where patient_Id='" + id + "' and textkind_id=" + tid + " order by sickkind_id desc";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Patient_Doc pDoc = new Patient_Doc();
                        pDoc.Id = Convert.ToInt32(row["tid"]);
                        pDoc.Pid = row["pid"].ToString();
                        pDoc.Patient_id = row["patient_Id"].ToString();
                        if (row["textkind_id"].ToString() != "")
                            pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);
                        if (row["belongtosys_id"].ToString() != "")
                            pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                        //pDoc.Patients_doc =row["patients_doc"].ToString();
                        if (row["sickkind_id"].ToString() != "")
                            pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);

                        pDoc.Docname = row["doc_name"].ToString().TrimStart();
                        pDoc.Textname = row["textname"].ToString().TrimStart();

                        Node node = new Node();
                        node.Text = pDoc.Docname;
                        node.Tag = pDoc as object;
                        node.Name = pDoc.Id.ToString();
                        node.ImageIndex = 22;

                        nodeTemp.Nodes.Add(node);

                    }

                }
            }
            return nodeTemp;
        }
        /// <summary>
        /// 根据pid得到异动表该病人最后一条记录的异动状态
        /// </summary>
        /// <param name="pid">病人id</param>
        /// <returns>异动状态</returns>
        public static string GetActionState(string pid)
        {
            string sql_atcionState = "select action_state from t_inhospital_action " +
                                    " where id = (select max(id) from t_inhospital_action where patient_Id = '" + pid + "') ";
            string action_state = App.ReadSqlVal(sql_atcionState, 0, "action_state");
            return action_state;
        }
        /// <summary>
        /// 根据科室id，得到科室名称
        /// </summary>
        /// <param name="sid">科室id</param>
        /// <returns>科室名称</returns>
        public static string getSectionNameById(string sid)
        {
            string Sql_SectionNameById = "select section_name from t_sectioninfo where sid=" + sid + "";
            string Name = null;
            Name = App.ReadSqlVal(Sql_SectionNameById, 0, "section_name");
            return Name;
        }

        /// <summary>
        /// 做出入转操作后，添加树节点根据床号的大小放到合适的位置
        /// </summary>
        /// <param name="CurrentNode">当前选中的节点</param>
        /// <param name="bed_Name">当前床号</param>
        public static void RefLocationTreeNode(Node CurrentNode, string bed_Name, NodeCollection nodes)
        {
            bool flag = false;      //是否科室的床号有大于当前的床号
            InPatientInfo CurrentInpat = CurrentNode.Tag as InPatientInfo;
            for (int i = 0; i < nodes[0].Nodes.Count; i++)
            {
                if (nodes[0].Nodes[i].Name == "tnSection_patient")
                {
                    foreach (Node node in nodes[0].Nodes[i].Nodes)
                    {
                        if (CurrentInpat.Section_Id.ToString() == node.Name)  //当前节点的科室id找到科室病人的对应科室id
                        {
                            for (int j = 0; j < node.Nodes.Count; j++)
                            {
                                string bed = node.Nodes[j].Text.Split(' ')[0];
                                for (int k = 0; k < bed.Length; k++)
                                {
                                    char a = bed[k];
                                    char b = bed_Name[k];
                                    if (a > b)    //a大于b，则插入
                                    {
                                        //obj = node.Nodes[i].Clone() as TreeNode;
                                        node.Nodes.Insert(j, CurrentNode);
                                        flag = true;
                                        return;
                                    }
                                    else if (a < b) //a小于b,则跳出循环，下一个床号匹配
                                    {
                                        break;
                                    }
                                }
                                //if (Convert.ToInt32(bed) > Convert.ToInt32(bed_Name))

                                //    obj = node.Nodes[i].Clone() as TreeNode;
                                //    node.Nodes.Insert(i, CurrentNode);
                                //    flag = true;
                                //    break;
                                //}
                            }
                            if (!flag)   //科室里面没有比当前床号大的就插到最后
                                node.Nodes.Insert(node.Nodes.Count, CurrentNode);
                            break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 返回护理等级
        /// </summary>
        /// <param name="nurse_leavel">护理等级</param>
        /// <returns>I,II,III,特护</returns>
        //public static string Nurse_leavel(string nurse_leavel)
        //{
        //    string NurseLeavel = null;
        //    string nurse_Name = GetNurse_Leavel_Name(nurse_leavel);
        //    if (nurse_Name == "一级护理")
        //    {
        //        NurseLeavel = "△";
        //    }
        //    else if (nurse_Name == "二级护理")
        //    {
        //        NurseLeavel = "△";
        //    }
        //    else if (nurse_Name == "三级护理")
        //    {
        //        NurseLeavel = "△";
        //    }
        //    else if (nurse_Name == "特护")
        //    {
        //        NurseLeavel = "特护";
        //    }
        //    return NurseLeavel;
        //}

        /// <summary>
        /// 返回护理名称
        /// </summary>
        /// <param name="nurse_leavel"></param>
        /// <returns></returns>
        public static string GetNurse_Leavel_Name(string nurse_leavel)
        {
            string nurse_Leavel_Name = null;
            if (nurse_leavel != "")
            {

                //string sql_Nurse_Name = "select name from t_data_code where id = " + nurse_leavel + "";
                //nurse_Leavel_Name = App.ReadSqlVal(sql_Nurse_Name, 0, "name");
                DataRow[] rows = DS_CODE.Tables[0].Select("id = " + nurse_leavel + "");
                if (rows.Length > 0)
                    nurse_Leavel_Name = rows[0]["name"].ToString();
            }
            return nurse_Leavel_Name;
        }
        public static string[] GetSids()
        {
            string[] arrs = null;
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                Sql_getSection_ByArea = "select b.sid,b.section_name from t_section_area a" +
                                    " inner join t_sectioninfo b on a.sid = b.sid" +
                                    " where a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
                DataSet ds = App.GetDataSet(Sql_getSection_ByArea);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    arrs = new string[dt.Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        arrs[i] = ds.Tables[0].Rows[i][0].ToString();
                    }
                }
            }
            else
            {
                arrs = new string[1];
                arrs[0] = App.UserAccount.CurrentSelectRole.Section_Id;
            }
            return arrs;
        }
        /// <summary>
        /// 获得默认的文书模版tid
        /// </summary>
        /// <param name="textId">该类型文书的Id</param>
        /// <returns></returns>
        public static string GetDefaultTempTid(string textId)
        {
            try
            {
                string tempTid = "";
                //其次判断科室默认模版
                string section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
                if (section_Id != null)
                {
                    DataSet ds_t_s = App.GetDataSet("select tid from t_tempplate a inner join T_TEMPPLATE_SECTION c on a.tid=c.template_id where a.text_type='" + textId + "' and c.section_id='" + section_Id + "' and c.ISDEFAULT='Y'");

                    string Sql = "";

                    if (ds_t_s != null)
                    {
                        //有科室模板
                        if (ds_t_s.Tables[0].Rows.Count > 0)
                        {
                            Sql = "select b.tid from t_tempplate a" +
                                                      " inner join t_tempplate_cont b on a.tid = b.tid inner join t_tempplate_section c on a.tid=c.template_id " +
                                                      " where c.isdefault='Y' and a.text_type='" + textId + "' and c.section_id=" + section_Id + "";

                            tempTid = App.ReadSqlVal(Sql, 0, "tid");
                        }
                        else
                        {
                            Sql = "select b.tid from t_tempplate a" +
                                  " inner join t_tempplate_cont b on a.tid = b.tid" +
                                  " where a.isdefault='Y' and a.text_type='" + textId + "' and a.section_id is null";
                            tempTid = App.ReadSqlVal(Sql, 0, "tid");

                        }
                    }
                }
                return tempTid;
            }
            catch (Exception)
            {

                return "";
            }
        }


        /// <summary>
        /// 获得默认的文书模板 
        /// </summary>
        /// <param name="textId">该类型文书Id</param>       
        /// <returns></returns>
        public static string GetDefaultTemp(string textId)
        {
            /*
             *获取该份文书的默认模板
             * 新增诊疗组模版：诊疗组默认模版优先级最高
             *首先判断是否有科室默认模板，如果没有的话查看这类文书的全员默认模板，如果再没有的话，那就
             */
            string content = "";
            //重新获取入院记录中相关值
            //dicRYText = GetTextInfo(CurrentPatient, textId);
            try
            {
                //首先判断是否有诊疗组默认模版
                int group_id = App.UserAccount.Group_id;

                if (group_id != 0)
                {
                    DataSet ds_group_tid = App.GetDataSet("select tid from t_tempplate a inner join T_TEMPPLATE_GROUP c on a.tid=c.template_id where a.text_type='" +
                                                           textId + "' and c.ISDEFAULT='Y'");
                    string sql = "";
                    if (ds_group_tid != null)
                    {
                        //有诊疗组默认模版
                        if (ds_group_tid.Tables[0].Rows.Count > 0)
                        {
                            sql = "select b.content from t_tempplate a" +
                                                     " inner join t_tempplate_cont b on a.tid = b.tid inner join t_tempplate_group c on a.tid=c.template_id " +
                                                     " where c.isdefault='Y' and a.text_type='" + textId + "' ";

                            content = App.ReadSqlVal(sql, 0, "content");
                            return content;
                        }
                    }
                }
                //其次判断科室默认模版
                string section_Id = CurrentPatient.Section_Id.ToString();//App.UserAccount.CurrentSelectRole.Section_Id; 
                if (section_Id != null)
                {
                    DataSet ds_t_s = App.GetDataSet("select tid from t_tempplate a inner join T_TEMPPLATE_SECTION c on a.tid=c.template_id where a.text_type='" +
                        textId + "' and c.section_id='" + section_Id + "' and c.ISDEFAULT='Y'");

                    string Sql = "";

                    if (ds_t_s != null)
                    {
                        //有科室模板
                        if (ds_t_s.Tables[0].Rows.Count > 0)
                        {
                            Sql = "select b.content from t_tempplate a" +
                                                      " inner join t_tempplate_cont b on a.tid = b.tid inner join t_tempplate_section c on a.tid=c.template_id " +
                                                      " where c.isdefault='Y' and a.text_type='" + textId + "' and c.section_id=" + section_Id + "";

                            content = App.ReadSqlVal(Sql, 0, "content");
                        }
                        else
                        {
                            Sql = "select b.content from t_tempplate a" +
                                  " inner join t_tempplate_cont b on a.tid = b.tid" +
                                  " where a.isdefault='Y' and a.text_type='" + textId + "' and a.section_id is null";
                            content = App.ReadSqlVal(Sql, 0, "content");

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
        /// 组合xml中的时间
        /// </summary>
        /// <param name="timenode">时间节点</param>
        /// <returns></returns>
        public static string GetTimeFromXml(XmlNode timenode)
        {


            string record_time = "";
            string jlrq = "";
            try
            {
                for (int i = 0; i < timenode.ChildNodes.Count; i++)
                {
                    //if (timenode.ChildNodes[i].OuterXml.ToString().Contains("deleter"))
                    //{
                    //    continue;
                    //}
                    if (jlrq == "")
                    {
                        jlrq = timenode.ChildNodes[i].InnerText;
                    }
                    else
                    {
                        jlrq = jlrq + timenode.ChildNodes[i].InnerText;
                    }
                }

                if (jlrq != "")
                {
                    //记录时间
                    jlrq = jlrq.Replace("：", ":");
                    record_time = jlrq.Replace("，", " ");
                }

                return record_time;
            }
            catch
            {
                return "";
            }
        }

        #region 校验函数
        /// <summary>
        /// 判断当前床位是否被占用
        /// </summary>
        /// <param name="bedid">床位ID</param>
        /// <returns></returns>
        public static bool IsBedOccupy(string bedid)
        {
            string state = App.ReadSqlVal("select t.state from t_sickbedinfo t where bed_id=" + bedid + "", 0, "state");
            if (state == "75")
            {
                return false;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 判断病人是否还在病区
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <param name="SickArea_id">病区主键</param>
        /// <returns>false 不在病区 true 在病区</returns>
        public static bool IsPatientInArea(string Patient_id, string SickArea_id)
        {
            string state = App.ReadSqlVal("select count(id) as num from t_in_patient t where id=" + Patient_id + " and sick_area_id=" + SickArea_id + "", 0, "num");
            if (state == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 判断病人是否还在科室
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <param name="Section_id">病区主键</param>
        /// <returns>false 不在科室 true 在科室</returns>
        public static bool IsPatientInSection(string Patient_id, string Section_id)
        {
            string state = App.ReadSqlVal("select count(id) as num from t_in_patient t where id=" + Patient_id + " and section_id=" + Section_id + "", 0, "num");
            if (state != null)
            {
                if (state == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断病人是否已经入区
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <returns>false 未入区 true 入区</returns>
        public static bool IsInArea(string Patient_id)
        {
            string state = App.ReadSqlVal("select count(id) as num from t_inhospital_action t where t.action_type='入区' and t.pid=" + Patient_id + "", 0, "num");
            if (state == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断病人是否出区
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <returns>false 未入区 true 入区</returns>
        public static bool IsOutArea(string Patient_id)
        {
            string state = App.ReadSqlVal("select count(id) as num from t_inhospital_action t where t.next_id=0  and t.action_type='出区' and t.pid=" + Patient_id + "", 0, "num");
            if (state == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断是否是在院病人和在当前病区的病人
        /// </summary>
        /// <param name="Patient_id">病人主键</param>
        /// <returns></returns>
        public static bool IsInAreaPatient(string Patient_id)
        {
            string state = App.ReadSqlVal("select count(id) as num from t_inhospital_action t where t.next_id=0  and t.action_type<>'出区' and t.pid=" + Patient_id + "", 0, "num");
            if (state == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 判断是否可以执行操作
        /// </summary>
        /// <param name="patient_id">病人主键</param>
        /// <param name="section_id">科室主键</param>
        /// <param name="SickArea_id">病区主键</param>
        /// <param name="bedid">床位主键</param>
        /// <param name="operatertye">操作类型 '入区'，'换床','转科(转出)'，'转科(转入)'，'出区收回',‘转科收回’,'出区'</param>
        /// <returns></returns>
        public static bool IsCanSure(string patient_id, string section_id, string SickArea_id, string bedid, string operatertye)
        {
            if (operatertye == "入区")
            {
                /*
                 * 首先判断一下，病人是否已经入区，如果没入区的话，继续判断所分配的床位是否已经被占用。
                 */
                if (!IsInArea(patient_id))
                {
                    if (!IsBedOccupy(bedid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "换床")
            {
                /*
                 * 首先要在院病人
                 */
                if (IsInAreaPatient(patient_id))
                {
                    /*
                     * 是否还在当前病区
                     * 南院不验证病区
                     */
                    if (App.CurrentHospitalId != 201)
                    {
                        if (IsPatientInArea(patient_id, SickArea_id))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "转科(转出)")
            {
                /*
                 *转科，判断  section_id是目标科室的ID,如果已经在目标科室的话就不需要再转出了
                 */
                if (IsInAreaPatient(patient_id))
                {
                    if (!IsPatientInSection(patient_id, section_id))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "转科(转入)")
            {
                /*
                 *转科，判断要分配的床位是否被占用
                 */
                if (IsInAreaPatient(patient_id))
                {
                    if (!IsBedOccupy(bedid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "出区收回")
            {
                /*
                 * 首先，判断是否已经出区，如果已经出区了，收回的时候再判断是否，要分配的床位已经被占用
                 * 
                 */
                if (IsOutArea(patient_id))
                {
                    if (!IsBedOccupy(bedid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "转科收回")
            {
                /*
                 * 首先,是否是在院病人，判断是否已经在对方科室了，如果对方已经接受了就不允许在收回了，如果可以收回的话，再判断床位是否被占用。
                 * 
                 */
                if (IsInAreaPatient(patient_id))
                {
                    if (!IsPatientInSection(patient_id, section_id))
                    {
                        if (!IsBedOccupy(bedid))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (operatertye == "出区")
            {
                /*
                 * 首先，判断是否已经出区，如果已经出区了，则无需再出区
                 * 
                 */
                if (!IsOutArea(patient_id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        #endregion

        /// <summary>
        /// 根据病人ID得到入院诊断
        /// </summary>
        /// <param name="patientId">病人ID</param>
        /// <returns></returns>
        public static string GetDiagnose(string patientId)
        {
            string sqldiagnose = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='403' and Patient_Id  =" + patientId;//初步诊断
            string sqldiagnose2 = "select diagnose_name,Patient_Id from t_diagnose_item where diagnose_type='408' and Patient_Id = " + patientId;//入院诊断
            Class_Table[] tables = new Class_Table[2];
            tables[0] = new Class_Table();
            tables[0].Sql = sqldiagnose;
            tables[0].Tablename = "chubu";

            tables[1] = new Class_Table();
            tables[1].Sql = sqldiagnose2;
            tables[1].Tablename = "ruyuan";

            DataSet dsdiagnose = App.GetDataSet(tables);

            string diagnose = "";

            if (dsdiagnose.Tables["chubu"].Rows.Count > 0)
                diagnose = dsdiagnose.Tables["chubu"].Rows[0][0].ToString();
            //如果初步诊断为空，则读取入院诊断
            if (diagnose == "" && dsdiagnose.Tables["ruyuan"].Rows.Count > 0)
            {
                diagnose = dsdiagnose.Tables["ruyuan"].Rows[0][0].ToString();
            }
            return diagnose;
        }

        /// <summary>
        /// 判断是否是当天入院
        /// </summary>
        /// <param name="in_time"></param>
        /// <returns></returns>
        public static bool isNewInArea(string in_time)
        {
            DateTime patient_in_time = Convert.ToDateTime(in_time);
            DateTime NowTime = App.GetSystemTime();

            if (patient_in_time.Year == NowTime.Year)
            {
                if (patient_in_time.Month == NowTime.Month)
                {
                    if (patient_in_time.Day == NowTime.Day)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 判断是否是当天入院
        /// </summary>
        /// <param name="in_time"></param>
        /// <returns></returns>
        public static bool isTURN(string patient_id)
        {
            string sql_turn = "select count(*) as count_turn from t_turn_section where PATIENT_ID='" + patient_id + "'";
            string n = "0";
            try
            {
                n = App.ReadSqlVal(sql_turn, 0, "count_turn");
                if (Convert.ToInt32(n) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }


        }

        /// <summary>
        /// 根据病人住院号，得到该病人的所有文书
        /// </summary>
        /// <param name="patient_Id">病人id号</param>
        /// <returns>有文书的树节点</returns>
        public static Node SelectDocNode(string patient_Id)
        {
            Node nodeTemp = new Node();
            //string sql = "select tid,pid,textkind_id,belongtosys_id,sickkind_id,textname from t_patients_doc where patient_Id=" + patient_Id + " order by textname";
            string sql = "select a.tid," +
                               "a.pid," +
                               "a.textkind_id," +
                               "a.belongtosys_id," +
                               "a.sickkind_id," +
                               "a.textname," +
                               "a.doc_name," +
                               "a.patient_Id," +
                               "a.ishighersign," +
                               "a.havehighersign," +
                               "a.havedoctorsign," +
                               "a.submitted," +
                               "a.createId," +
                               "a.highersignuserid," +
                               "a.israplacehightdoctor," +
                               "a.israplacehightdoctor2," +
                               "a.SECTION_NAME " +
                         " from t_patients_doc a" +
                         " where a.patient_Id = " + patient_Id + " order by a.doc_name";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //去掉重复的文书id
                    string tid = "0";
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["tid"].ToString() != "")
                        {
                            if (tid != row["tid"].ToString())
                            {
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
                                pDoc.Section_name = row["SECTION_NAME"].ToString();
                                Node node = new Node();
                                node.Text = pDoc.Docname;
                                node.Tag = pDoc as object;
                                node.Name = pDoc.Id.ToString();
                                //node.ImageIndex = 19;
                                //node.SelectedImageIndex = 19;
                                nodeTemp.Nodes.Add(node);
                                tid = row["tid"].ToString();
                            }
                        }
                    }

                }
            }
            return nodeTemp;
        }

        /// <summary>
        /// 根据病人pid得到病人信息
        /// </summary>
        /// <param name="bedId">病人pid</param>
        /// <returns>InPatientInfo对象</returns>
        public static InPatientInfo GetIninpatientByPid(DataTable dt)
        {
            InPatientInfo inpatient = new InPatientInfo();
            if (dt.Rows.Count > 0)
            {
                inpatient.Id = Int32.Parse(dt.Rows[0]["id"].ToString());
                inpatient.Patient_Name = dt.Rows[0]["patient_name"].ToString();
                inpatient.Gender_Code = dt.Rows[0]["gender_code"].ToString();
                inpatient.Birthday = dt.Rows[0]["birthday"].ToString();
                inpatient.PId = dt.Rows[0]["pid"].ToString();
                //inpatient.Action_State = row["action_state"].ToString();
                inpatient.Sick_Doctor_Id = dt.Rows[0]["sick_doctor_id"].ToString();
                inpatient.Sick_Doctor_Name = dt.Rows[0]["sick_doctor_name"].ToString();
                if (dt.Rows[0]["sick_area_id"].ToString() != "")
                    inpatient.Sike_Area_Id = Int32.Parse(dt.Rows[0]["sick_area_id"].ToString()).ToString();
                inpatient.Sick_Area_Name = dt.Rows[0]["sick_area_name"].ToString();
                if (dt.Rows[0]["section_id"].ToString() != "")
                    inpatient.Section_Id = Int32.Parse(dt.Rows[0]["section_id"].ToString());
                inpatient.Section_Name = dt.Rows[0]["section_name"].ToString();
                if (dt.Rows[0]["in_time"] != null)
                    inpatient.In_Time = DateTime.Parse(dt.Rows[0]["in_time"].ToString());
                inpatient.State = dt.Rows[0]["state"].ToString();
                if (dt.Rows[0]["sick_bed_id"].ToString() != "")
                    inpatient.Sick_Bed_Id = Int32.Parse(dt.Rows[0]["sick_bed_id"].ToString());
                inpatient.Sick_Bed_Name = dt.Rows[0]["sick_bed_no"].ToString();
                inpatient.Age_unit = dt.Rows[0]["age_unit"].ToString();
                inpatient.Sick_Degree = Convert.ToString(dt.Rows[0]["Sick_Degree"]);
                inpatient.Nurse_Level = Convert.ToString(dt.Rows[0]["Nurse_Level"]);

                inpatient.Marrige_State = dt.Rows[0]["marriage_state"].ToString();
                inpatient.Medicare_no = dt.Rows[0]["Medicare_no"].ToString();
                inpatient.Home_address = dt.Rows[0]["Home_address"].ToString();
                inpatient.HomePostal_code = dt.Rows[0]["HomePostal_code"].ToString();
                inpatient.Home_phone = dt.Rows[0]["Home_phone"].ToString();
                inpatient.Office = dt.Rows[0]["Office"].ToString();
                inpatient.Office_address = dt.Rows[0]["Office_Address"].ToString();
                inpatient.Office_phone = dt.Rows[0]["Office_phone"].ToString();
                inpatient.Relation = dt.Rows[0]["Relation"].ToString();
                inpatient.Relation_address = dt.Rows[0]["Relation_address"].ToString();
                inpatient.Relation_phone = dt.Rows[0]["Relation_phone"].ToString();
                inpatient.RelationPos_code = dt.Rows[0]["RelationPos_code"].ToString();
                inpatient.OfficePos_code = dt.Rows[0]["OfficePos_code"].ToString();
                if (dt.Rows[0]["InHospital_Count"].ToString() != "")
                    inpatient.InHospital_count = Convert.ToInt32(dt.Rows[0]["InHospital_Count"].ToString());
                inpatient.Cert_Id = dt.Rows[0]["cert_id"].ToString();
                inpatient.Pay_Manager = dt.Rows[0]["pay_manner"].ToString();
                inpatient.In_Circs = dt.Rows[0]["IN_Circs"].ToString();
                inpatient.Natiye_place = dt.Rows[0]["native_place"].ToString();
                inpatient.Birth_place = dt.Rows[0]["Birth_place"].ToString();
                inpatient.Folk_code = dt.Rows[0]["Folk_code"].ToString();

                inpatient.Insection_Id = Convert.ToInt32(dt.Rows[0]["insection_id"]);
                inpatient.Insection_Name = dt.Rows[0]["insection_name"].ToString();
                inpatient.In_Area_Id = Convert.ToInt32(dt.Rows[0]["in_area_id"]).ToString();
                inpatient.In_Area_Name = dt.Rows[0]["in_area_name"].ToString();
                if (dt.Rows[0]["Age"].ToString() != "")
                    inpatient.Age = dt.Rows[0]["Age"].ToString();
                else
                {
                    if (inpatient.Age == "0")
                    {
                        inpatient.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(inpatient.Birthday).Year);
                        inpatient.Age_unit = "岁";
                    }
                }
                if (dt.Rows[0]["Die_flag"].ToString() != "")
                    inpatient.Die_flag = Convert.ToInt32(dt.Rows[0]["Die_flag"]);
                inpatient.Card_Id = dt.Rows[0]["card_id"].ToString();
                inpatient.Career = dt.Rows[0]["Career"].ToString();//职业
                inpatient.Out_Id = dt.Rows[0]["out_id"].ToString();//门诊号
                inpatient.Relation_name = dt.Rows[0]["Relation_Name"].ToString();//联系人姓名

            }

            return inpatient;
        }


        public static void SelectChooseNode(NodeCollection nodes, Node choosenode, AdvTree trvn)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Tag == choosenode.Tag)
                {
                    trvn.SelectedNode = nodes[i];
                    break;
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    SelectChooseNode(nodes[i].Nodes, choosenode, trvn);
                }
            }
        }

        /// <summary>
        /// 获取住院天数
        /// </summary>
        /// <param name="In_Time"></param>
        /// <returns></returns>
        public static string GetInHospitalDaysCount(DateTime In_Time)
        {
            string days = "1天";
            DateTime dtime = App.GetSystemTime();

            TimeSpan ts = (Convert.ToDateTime(dtime) - Convert.ToDateTime(In_Time));
            if (ts.Days == 0)
            {
                int h = 0;
                if (ts.Minutes > 0)
                    h = ts.Hours + 1;
                else
                    h = ts.Hours;
                days = h.ToString() == "0" ? "1小时" : h.ToString() + "小时";
                if (h == 24)
                    days = "1天";
            }
            else
            {
                days = ((TimeSpan)(Convert.ToDateTime(dtime.ToShortDateString()) - Convert.ToDateTime(In_Time.ToShortDateString()))).Days.ToString() + "天";
            }
            return days;
        }

        #region 文书的相关操作
        /// <summary>
        /// 文书操作
        /// </summary>
        /// <param name="g"></param>
        /// <param name="drawRegion"></param>
        /// <param name="pageIndex"></param>
        /// <param name="splitStaterHeader"></param>
        /// <param name="emrdoc"></param>
        public static void EMRDoc_OnDrawPageHeader(Graphics g, Rectangle drawRegion, int pageIndex, PageHeaders splitStaterHeader, ZYTextDocument emrdoc)
        {

            //emrdoc.PageHeader 集合列表
            //姓名", 
            //科别", 
            //床号", 
            //病区", 
            //住院号"
            //性别", 
            //入院时间
            //年龄", 

            string sql = "select id from t_patients_doc a inner join t_account_user b on a.createid=b.user_id inner join t_account c on b.account_id=c.account_id  where tid='" + emrdoc.Us.Tid+ "' and c.kind='53'";
            string h=App.ReadSqlVal(sql, 0, "id");
            if (h!=null)
            {
                Watermark(drawRegion.Left, drawRegion.Top, g); 
            }
            //Font f = new Font("宋体", 12f);
            //Font hospitalFont = new Font("宋体", 16);
            //Font textNameFont = new Font("黑体", 20);
            //Font f = new Font("宋体", 12f);//黑色小四号字
            Font f = new Font("宋体", 10.5f);//黑色五号字
            Font hospitalFont = new Font("黑体", 16f);//黑色三号字
            Font hospitalFont1 = new Font("黑体", 12.5f);//郧西妇幼
            Font textNameFont = new Font("宋体", 15f);//黑色小三号字
            StringFormat titleStringFormat = new StringFormat();
            titleStringFormat.Alignment = StringAlignment.Center;
            int titleMarginTop = emrdoc.Pages.TopMargin - emrdoc.Pages.TitleMarginTop;

            Pen p = new Pen(Color.Black);
            Brush b = new SolidBrush(Color.Black);
            g.DrawLine(p, drawRegion.Left, drawRegion.Top - 5, drawRegion.Left + drawRegion.Width, drawRegion.Top - 5);
            g.DrawString(Bifrost.App.HospitalTittle.Replace("\\r\\n", "\r\n"), hospitalFont, b, new Rectangle(drawRegion.Left, drawRegion.Top - (titleMarginTop + 30), drawRegion.Width, 25), titleStringFormat);
            //郧西县儿童医院
            //g.DrawString("郧 西 县 儿 童 医 院", hospitalFont1, b, new Rectangle(drawRegion.Left, drawRegion.Top - (titleMarginTop + 8), drawRegion.Width, 25), titleStringFormat);
            g.DrawString(emrdoc.Us.TextName, textNameFont, b, new Rectangle(drawRegion.Left, drawRegion.Top - (titleMarginTop - 25), drawRegion.Width, 34), titleStringFormat);

            if (emrdoc.PageHeader != null)
            {
                ArrayList list = new ArrayList();
                int maxWdith = 0;

                string patient_name = "姓名:" + emrdoc.PageHeader["姓名"];
                int pWidth = DataInit.GetTextWidth(g, patient_name, f);
                list.Add(new PageHeaderNode(patient_name, pWidth));
                maxWdith += pWidth;

                string patient_sex = "性别:" + emrdoc.PageHeader["性别"];
                pWidth = DataInit.GetTextWidth(g, patient_sex, f);
                list.Add(new PageHeaderNode(patient_sex, pWidth));
                maxWdith += pWidth;


                //延安市妇幼保健院，页眉年龄特殊处理
                #region
                if ((emrdoc.PageHeader["年龄"].Contains("岁") && emrdoc.PageHeader["年龄"].Contains("月")) || (emrdoc.PageHeader["年龄"].Contains("月") && emrdoc.PageHeader["年龄"].Contains("天")))
                {
                    string age_1 = "年龄:";          //年龄：余数
                    string age_2 = "";               //分子          
                    string age_3 = "";               //分母
                    string age_4 = "";               //单位

                    if (emrdoc.PageHeader["年龄"].Contains("岁"))
                    {
                        string[] age = emrdoc.PageHeader["年龄"].Split('岁');
                        age_1 += age[0];
                        age_2 = age[1].Split('月')[0];
                        age_3 = "12";
                        age_4 = "岁";
                    }
                    else
                    {
                        string[] age = emrdoc.PageHeader["年龄"].Split('月');
                        age_1 += age[0];
                        age_2 = age[1].Split('天')[0];
                        age_3 = "30";
                        age_4 = "月";
                    }
                    string section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : emrdoc.PageHeader["科别"]);

                    string bed_no = "床号:" + (splitStaterHeader.Bed_no != "" ? splitStaterHeader.Bed_no : emrdoc.PageHeader["床号"]);

                    string p_id = "病案号:" + emrdoc.PageHeader["住院号"];

                    maxWdith += DataInit.GetTextWidth(g, age_1, f) + DataInit.GetTextWidth(g, age_3, f) + DataInit.GetTextWidth(g, age_4, f) +
                        DataInit.GetTextWidth(g, section_name, f) + DataInit.GetTextWidth(g, bed_no, f) + DataInit.GetTextWidth(g, p_id, f);
                    int MarginWidth = (drawRegion.Width - maxWdith) / (list.Count - 1 + 4);//加上年龄和住院号
                    int realWidth = 0;

                    foreach (PageHeaderNode node in list)
                    {
                        g.DrawString(node.HeaderStr, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                        realWidth += node.Width + MarginWidth;
                    }

                    //余数
                    g.DrawString(age_1, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, age_1, f);

                    //分子
                    //分子为个位数时候，居中显示
                    if (age_2.Length == 1)
                        g.DrawString(age_2, f, b, drawRegion.Left + realWidth + DataInit.GetTextWidth(g, age_3, f) / 2 - DataInit.GetTextWidth(g, age_2, f) / 2, drawRegion.Top - 31 - GetTextHeight(g, "年龄", f) / 2, System.Drawing.StringFormat.GenericTypographic);
                    else
                        g.DrawString(age_2, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31 - GetTextHeight(g, "年龄", f) / 2, System.Drawing.StringFormat.GenericTypographic);

                    //横线
                    //g.DrawString("一", f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    g.DrawLine(p, drawRegion.Left + realWidth, drawRegion.Top - 33 + GetTextHeight(g, "年龄", f) / 2, drawRegion.Left + realWidth + DataInit.GetTextWidth(g, age_3, f), drawRegion.Top - 33 + GetTextHeight(g, "年龄", f) / 2);

                    //分母
                    g.DrawString(age_3, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31 + GetTextHeight(g, "年龄", f) / 2, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, age_3, f);

                    //单位
                    g.DrawString(age_4, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, age_4, f) + MarginWidth;

                    //科室
                    g.DrawString(section_name, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, section_name, f) + MarginWidth;

                    //床号
                    g.DrawString(bed_no, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, bed_no, f) + MarginWidth;

                    //住院号
                    g.DrawString(p_id, f, b, drawRegion.Left + realWidth, drawRegion.Top - 31, System.Drawing.StringFormat.GenericTypographic);
                    realWidth += DataInit.GetTextWidth(g, p_id, f) + MarginWidth;
                }
                else
                {
                    string patient_age = "年龄:" + emrdoc.PageHeader["年龄"];
                    pWidth = DataInit.GetTextWidth(g, patient_age, f);
                    list.Add(new PageHeaderNode(patient_age, pWidth));
                    maxWdith += pWidth;
                    //string t=App.UserAccount.CurrentSelectRole.Section_name
                    //string section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : emrdoc.PageHeader["科别"]);
                    //string section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : App.UserAccount.CurrentSelectRole.Section_name);
                    string section_name = "";
                    if (ucDoctorOperater.flagtq == true)
                    {
                        if (App.UserAccount.CurrentSelectRole.Section_name!=null)
                        {
                            section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : App.UserAccount.CurrentSelectRole.Section_name); 
                        }
                        else
                        {
                            section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : App.UserAccount.CurrentSelectRole.Sickarea_name.Replace("护理单元", "病区")); 
                        }

                    }
                    else
                    {
                        section_name = "科室:" + (splitStaterHeader.Section_name != "" ? splitStaterHeader.Section_name : emrdoc.PageHeader["科别"].Replace("护理单元", "病区")); 

                    }
                    pWidth = DataInit.GetTextWidth(g, section_name, f);
                    list.Add(new PageHeaderNode(section_name, pWidth));
                    maxWdith += pWidth;

                    string bed_no = "";
                    if (DataInit.strid != "" && (App.UserAccount.CurrentSelectRole.Section_name == emrdoc.PageHeader["科别"] || ucDoctorOperater.flagtq == true) && ucDoctorOperater.flagmark==false)
                    {
                        //string strbedno ="select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + DataInit.strid + "' and a.bed_id=c.bed_id and b.section_name='" + App.UserAccount.CurrentSelectRole.Section_name + "' and rownum=1 order by happen_time desc";

                        if (App.UserAccount.CurrentSelectRole.Section_name!=null)
                        {
                            bed_no = "床号:" + App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + DataInit.strid + "' and a.bed_id=c.bed_id and b.section_name='" + App.UserAccount.CurrentSelectRole.Section_name + "' and rownum=1 order by happen_time desc", 0, "bed_no");
                            pWidth = DataInit.GetTextWidth(g, bed_no, f);
                            list.Add(new PageHeaderNode(bed_no, pWidth));
                            maxWdith += pWidth;
                        }
                        else
                        {
                            bed_no = "床号:" + App.ReadSqlVal("select bed_no from t_inhospital_action a inner join t_sickareainfo b on a.said=b.said inner join t_sickbedinfo c on a.sid=c.sid   where a.patient_id='" + DataInit.strid + "' and a.bed_id=c.bed_id and b.sick_area_name='" + App.UserAccount.CurrentSelectRole.Sickarea_name + "' and rownum=1 order by happen_time desc", 0, "bed_no");
                            pWidth = DataInit.GetTextWidth(g, bed_no, f);
                            list.Add(new PageHeaderNode(bed_no, pWidth));
                            maxWdith += pWidth;
                        
                        }
                    }
                    else 
                    {
                        bed_no = "床号:" + (splitStaterHeader.Bed_no != "" ? splitStaterHeader.Bed_no : emrdoc.PageHeader["床号"]);
                        pWidth = DataInit.GetTextWidth(g, bed_no, f);
                        list.Add(new PageHeaderNode(bed_no, pWidth));
                        maxWdith += pWidth;
                    }

                    DataInit.strbed = bed_no;
                    //string area_name = "病区:" + (splitStaterHeader.Sick_area != "" ? splitStaterHeader.Sick_area : emrdoc.PageHeader["病区"]);
                    //pWidth = DataInit.GetTextWidth(g, area_name, f);
                    //list.Add(new PageHeaderNode(area_name, pWidth));
                    //maxWdith += pWidth;

                    string p_id = "住院号:" + emrdoc.PageHeader["住院号"];
                    pWidth = DataInit.GetTextWidth(g, p_id, f);
                    list.Add(new PageHeaderNode(p_id, pWidth));
                    maxWdith += pWidth;

                    int MarginWidth = (drawRegion.Width - maxWdith) / (list.Count - 1);
                    int realWidth = 0;

                    foreach (PageHeaderNode node in list)
                    {
                        g.DrawString(node.HeaderStr, f, b, drawRegion.Left + realWidth, drawRegion.Top - 26, System.Drawing.StringFormat.GenericTypographic);
                        realWidth += node.Width + MarginWidth;
                    }
                }
                #endregion

                Font bottomPageCurrent = new Font("宋体", 10.5f);
                g.DrawLine(p, drawRegion.Left, drawRegion.Bottom, drawRegion.Left + drawRegion.Width, drawRegion.Bottom);
                g.DrawString("第  " + (pageIndex + emrdoc.PageStartIndex) + "  页", bottomPageCurrent, b, new Rectangle(drawRegion.Left, drawRegion.Bottom + 5, drawRegion.Width, 20), titleStringFormat);

                bottomPageCurrent.Dispose();
            }
            p.Dispose();
            b.Dispose();
            f.Dispose();
            hospitalFont.Dispose();
            textNameFont.Dispose();
        }

        public static int GetTextWidth(Graphics g, string name, Font f)
        {
            return (int)g.MeasureString(name, f, 1000, System.Drawing.StringFormat.GenericTypographic).Width;
        }

        public static int GetTextHeight(Graphics g, string name, Font f)
        {
            return (int)g.MeasureString(name, f, 1000, System.Drawing.StringFormat.GenericTypographic).Height;
        }

        /// <summary>
        /// 删除相关备份文书
        /// </summary>
        /// <param name="patientid">病人主键</param>
        /// <param name="tid">文书id</param>
        /// <param name="textid">文书类型ID</param>
        public static void delbakdoc(string patientid, string Tid, string Textid)
        {
            try
            {

                var files = Directory.GetFiles(App.SysPath + "\\DocTemp\\" + patientid, "*.xml");
                string filename = "";
                string strfile;
                string tid;
                string textid;
                string texttitle;
                string record_time;
                string record_content;
                foreach (string file in files)
                {
                    filename = Path.GetFileName(file); //获取名称
                    strfile = filename.Split('.')[0];
                    strfile =Bifrost.Encrypt.DecryptStr(strfile);
                    tid = strfile.Split('_')[0];
                    textid = strfile.Split('_')[1];
                    texttitle = strfile.Split('_')[2];
                    record_time = strfile.Split('_')[3];
                    record_content = strfile.Split('_')[4];

                    if (Tid == tid && textid == Textid)
                    {
                        File.Delete(file); //删除文书备份文件                       
                    }
                }


            }
            catch
            {

            }
        }

        public static void getLisProgress()
        {
            Base_Function.BLL_DOCTOR.Patient_Action_Manager.frmPatientProgress fc = new Base_Function.BLL_DOCTOR.Patient_Action_Manager.frmPatientProgress(CurrentPatient);
            fc.ShowDialog();
        }



        /// <summary>
        /// 插入诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnInsertDiosgin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //每次点击“诊断编辑”按钮时，刷新患者最新三级医师。
        //        CurrentPatient = DataInit.GetInpatientInfoByPid(CurrentPatient.Id.ToString());
        //        using (BLL_DIAGNOSE.frmDiagnoseSimple fds = new BLL_DIAGNOSE.frmDiagnoseSimple(CurrentPatient))
        //        {
        //            fds.ShowDialog();
        //            RefreshTabDocDiagnose(1);//只刷新未提交文书
        //        }
        //        //}
        //    }
        //    catch (System.Exception ex)
        //    {
        //        App.MsgWaring("该按钮参数未设置或功能尚未启用！");
        //    }
        //}

        /// <summary>
        /// 刷新诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnRefreshDiosgin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //还需要记录谁操作
        //        RefreshTabDocDiagnose(2);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        App.MsgWaring("该按钮参数未设置或功能尚未启用！");
        //    }
        //}


        /// <summary>
        /// 保存文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void saveDocument(object sender, EventArgs e)
        {
            try
            {
                //SaveImgTo();
                if (CurrentFrmText != null)
                {
                    if (CurrentFrmText.MyDoc.Us.TextKind_id == 0 || CurrentFrmText.MyDoc.Locked)
                    {
                        App.Msg("文书已经锁定！");
                        return;
                    }
                    if (CurrentFrmText.MyDoc.Section_name != "" && CurrentFrmText.MyDoc.Section_name != CurrentFrmText.MyDoc.Us.GetSectionName)
                    {
                        App.Msg("该文书不是当前科室创建，不允许签字。");
                        return;
                    }
                    string str = "";
                    if (CurrentFrmText.MyDoc.Us.TextKind_id == 127)//上级查房记录提交之前提醒
                    {
                        str = @"请确认检查结果(异常)分析、目前诊断、诊断依据、鉴别诊断、下一步诊疗计划，预后及新进展（主任查房必写）是否书写完整!";

                    }
                    else if (CurrentFrmText.MyDoc.Us.TextKind_id == 120 ||
                        CurrentFrmText.MyDoc.Us.TextKind_id == 121 ||
                        CurrentFrmText.MyDoc.Us.TextKind_id == 47553087 ||
                        CurrentFrmText.MyDoc.Us.TextKind_id == 47553088 ||
                        CurrentFrmText.MyDoc.Us.TextKind_id == 47553089 ||
                        CurrentFrmText.MyDoc.Us.TextKind_id == 6982569)//入院记录提交之前提醒
                    {
                        str = "请确认主诉、现病史与诊断是否相符合!";
                    }


                    if (!string.IsNullOrEmpty(str))
                    {
                        if (!App.Ask(str))
                        {
                            return;
                        }
                    }
                    //提交按钮操作 true 暂存false
                    string btnName = "";
                    bool blfalse = false;
                    if (sender is ButtonItem)
                    {
                        blfalse = (sender as ButtonItem).Name == "tsbtnCommit";
                        btnName = "tsbtnCommit";

                    }
                    else if (sender is ButtonX)
                    {
                        blfalse = (sender as ButtonX).Name == "btnSave";
                        btnName = "btnSave";
                    }
                    else
                    {
                        blfalse = true;
                    }

                    #region 性别关键字检查

               

                    if (blfalse)
                    {
                        StringBuilder filterMessage;
                        string first;
                        CurrentFrmText.MyDoc.FindWords(out filterMessage, out first);
                        if (filterMessage.Length > 0)
                        {
                            filterMessage.Insert(0, "该病人性别为【" + (CurrentFrmText.MyDoc.Us.InpatientInfo.Gender_Code == "0" ? "男" : "女") + "】文书中含有下列关键字,继续保存点是,不保存点否\n");
                            if (MessageBox.Show(filterMessage.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                CurrentFrmText.MyDoc._Find(first, 0);
                                return;
                            }
                        }
                    }

                    #endregion

                    /***
                * 验证元素
                */
                    if (blfalse && !CurrentFrmText.MyDoc.CheckContent())
                    {
                        return;
                    }

                    if (!MyDocStye)
                    {
                        if (blfalse && CurrentFrmText.MyDoc.Us.TextKind_id != 1724 && CurrentFrmText.MyDoc.Us.TextKind_id != 133)
                        {//会诊申请不进入
                            if (!CurrentFrmText.MyDoc.SaveTrue)
                            {
                                //CurrentFrmText.MyDoc.isHaveTextId()
                                if (CurrentFrmText.MyDoc.isHaveTextId())
                                {
                                    if (!CurrentFrmText.MyDoc._InsertSignature())
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!CurrentFrmText.MyDoc._otherTextSign())
                                    {
                                        return;
                                    }
                                    CurrentFrmText.MyDoc.ContentChanged();
                                }
                            }
                        }
                    }
                    //获取文书XMl
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    CurrentFrmText.MyDoc.ToXML(tempxmldoc.DocumentElement);

                    //关键字比对-主诉和诊断
                    int KeywordType = Keyword_matching(tempxmldoc);
                    if (KeywordType == 2)
                    {
                        if (!App.Ask("提示: 主诉与诊断关键字不一致,是否提交!"))
                            return;
                    }

                    bool isTakeSuperiorZz = false;
                    bool isTakeSuperiorZr = false;
                    if (CurrentFrmText.MyDoc.Us.TextKind_id == 6982569)
                    {
                        if (!pdzd(tempxmldoc.DocumentElement))
                        {
                            App.Msg("请插入诊断后提交！");
                            return;
                        }
                    }
                    //if (CurrentFrmText.MyDoc.Us.TextKind_id == 126)
                    //{
                    //    if (CurrentFrmText.MyDoc.Us.Tid == 0)
                    //    {
                    //        using (frmMessageBox messageBox = new frmMessageBox())
                    //        {
                    //            messageBox.ShowDialog();
                    //            if (messageBox.Succeed)
                    //            {
                    //                isTakeSuperiorZz = messageBox.IsZZCheck;
                    //                isTakeSuperiorZr = messageBox.IsZRCheck;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {

                    //        string sql = "SELECT ISRAPLACEHIGHTDOCTOR,ISRAPLACEHIGHTDOCTOR2 FROM T_Patients_Doc T WHERE T.TID = '" + CurrentFrmText.MyDoc.Us.Tid + "'";
                    //        DataTable dt = App.GetDataSet(sql).Tables[0];
                    //        if (dt != null && dt.Rows.Count > 0)
                    //        {
                    //            isTakeSuperiorZz = dt.Rows[0]["ISRAPLACEHIGHTDOCTOR"].ToString() == "Y";
                    //            isTakeSuperiorZr = dt.Rows[0]["ISRAPLACEHIGHTDOCTOR2"].ToString() == "Y";
                    //        }
                    //    }
                    //}
                    //修改
                    string haveSuperior = "N";
                    //(CurrentFrmText.MyDoc.HaveSuperiorSign(blfalse) ? "Y" : "N");

                    if (!CurrentFrmText.MyDoc.HaveSuperiorSign(blfalse))
                    {
                        if (btnName == "" || btnName == "tsbtnCommit")
                        {
                            haveSuperior = "Y";
                        }
                    }
                    else
                    {
                        haveSuperior = "Y";
                    }

                    //if (haveSuperior == "Y")//若上级医师签名，自动提交
                    //{
                    //    blfalse = true;
                    //}
                    string havaTube = "N"; //(CurrentFrmText.MyDoc.HaveTubeBedSign(blfalse) ? "Y" : "N");

                    if (!CurrentFrmText.MyDoc.HaveTubeBedSign(blfalse))
                    {
                        if (btnName == "" || btnName == "tsbtnCommit")
                        {
                            havaTube = "Y";
                        }
                    }
                    else
                    {
                        havaTube = "Y";
                    }

                    string textTitle = "";
                    string qualityTitle = "";
                    DateTime sysTime = App.GetSystemTime();
                    XmlNodeList nodeList = tempxmldoc.GetElementsByTagName("div");
                    foreach (XmlNode childNode in nodeList)
                    {
                        if (childNode.Attributes["timeTitle"] != null && childNode.Attributes["timeTitle"].Value == "Y")
                        {
                            textTitle = childNode.Attributes["title"] != null ? childNode.Attributes["title"].Value : "";
                            break;
                        }
                    }
                    if (textTitle != "")
                    {
                        qualityTitle = textTitle;
                    }
                    if (textTitle == "")
                    {
                        textTitle = sysTime.ToString("yyyy-MM-dd HH:mm") + "   " + CurrentFrmText.MyDoc.Us.OldTextName;
                        qualityTitle = textTitle;
                    }
                    //if (qualityTitle == "")
                    //{
                    //    XmlNodeList inputNodeList = tempxmldoc.GetElementsByTagName("input");
                    //    foreach (XmlNode childNode in inputNodeList)
                    //    {
                    //        if (childNode.Attributes["name"] != null)
                    //        {
                    //            string writeTime = childNode.Attributes["name"].Value;
                    //            if (writeTime == "记录日期" || writeTime == "us_jlrq" || writeTime == "死亡时间" || writeTime == "出院时间" || writeTime == "出院日期" || writeTime == "书写时间")
                    //            {
                    //                qualityTitle = childNode.InnerText.Replace("，", " ") + "  " + CurrentFrmText.MyDoc.Us.TextName;
                    //                textTitle = qualityTitle;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                    //if (textTitle == "" && CurrentFrmText.MyDoc.Us.RecordTime != "")
                    //{
                    //    textTitle = CurrentFrmText.MyDoc.Us.RecordTime + "   " + CurrentFrmText.MyDoc.Us.RecordText;
                    //    qualityTitle = CurrentFrmText.MyDoc.Us.RecordTime + "  " + CurrentFrmText.MyDoc.Us.RecordText;
                    //}
                    //if (textTitle == "")
                    //{
                    //    textTitle = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm") + "   " + CurrentFrmText.MyDoc.Us.TextName;
                    //    qualityTitle = textTitle;
                    //}
                    bool haveD = false;//是否包含D型病历
                    XmlNodeList inputNodeListD = tempxmldoc.GetElementsByTagName("input");
                    foreach (XmlNode childNode in inputNodeListD)
                    {
                        if (childNode.Attributes["name"] != null)
                        {
                            string nameType = childNode.Attributes["name"].Value;
                            if (nameType == "病例分型")
                            {
                                if (childNode.InnerText.Contains("D型"))
                                {
                                    haveD = true;
                                }
                            }
                        }
                    }


                    //if (blfalse && CurrentFrmText.MyDoc.Us.Tid != 0)
                    //{//提交时进入,判断是不是第一次提交,是的话,把之前操作的痕迹去除
                    //    //获取文书是否提交状态
                    //    bool Submitted = DataInit.IsDocSubmitted(CurrentFrmText.MyDoc.Us.Tid);
                    //    if (!Submitted)
                    //    {
                    //        //暂存文书移除模版痕迹
                    //        XmlNodeList xnList = tempxmldoc.GetElementsByTagName("body");
                    //        if (xnList != null && xnList.Count > 0)
                    //        {
                    //            foreach (XmlNode ChildNode in xnList)
                    //            {
                    //                //XmlNode xn = xnList[0];
                    //                //xnList.ParentNode.RemoveChild(xn);
                    //                xmlFilter(ChildNode);
                    //            }
                    //            CurrentFrmText.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    //            CurrentFrmText.MyDoc.ContentChanged();
                    //        }
                    //    }
                    //}
                    try
                    {
                        qualityTitle += isTakeSuperiorZz == true ? "代主治医师查房记录" : "";
                        qualityTitle += isTakeSuperiorZr == true ? "代主任医师查房记录" : "";
                        if (CurrentFrmText.MyDoc.Us.Tid != 0)
                        {
                            //修改文书内容
                            if (blfalse) //点的提交按钮
                            {
                                DataTable dt = App.GetDataSet(string.Format("select submitted from T_PATIENTS_DOC where TID = {0} AND PATIENT_ID = '{1}'", CurrentFrmText.MyDoc.Us.Tid, CurrentFrmText.MyDoc.Us.InpatientInfo.Id)).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    string submmit = dt.Rows[0][0].ToString();
                                    if (submmit == "Y")
                                    {
                                        LogHelper.SystemLog("修改", CurrentFrmText.MyDoc.Us.Tid.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.PId.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.Id);
                                    }
                                    else
                                    {
                                        LogHelper.SystemLog("创建", CurrentFrmText.MyDoc.Us.Tid.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.PId.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.Id);
                                        if (CurrentFrmText.MyDoc.Us.TextKind_id == 890)
                                        {
                                            CurrentFrmText.MyDoc.InsertJobTemp(qualityTitle);
                                        }
                                    }
                                }
                            }
                            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                            {
                                //当护士操作的时候，特殊处理
                                haveSuperior = "Y";
                            }

                            String sql = string.Format("update T_PATIENTS_DOC set HAVEDOCTORSIGN = '{3}' ,ISHIGHERSIGN = '{4}',HAVEHIGHERSIGN = '{5}',submitted='{6}',highersignuserid = '{7}',textname='{8}',OPERATEID='{9}' {2} where TID = {0} AND PATIENT_ID = '{1}' ",
                                CurrentFrmText.MyDoc.Us.Tid,
                                CurrentFrmText.MyDoc.Us.InpatientInfo.Id,
                                textTitle == "" ? "" : ",doc_name ='" + textTitle.Trim() + "'",
                                havaTube,
                                CurrentFrmText.MyDoc.TextSuperiorSignature,
                                haveSuperior,
                                (blfalse == true ? "Y" : "N"),  //暂存/提交,
                                CurrentFrmText.MyDoc.SuporSign,
                                CurrentFrmText.MyDoc.Us.OldTextName,
                                App.UserAccount.UserInfo.User_id);
                            if (App.ExecuteSQL(sql) > 0)
                            {
                                CurrentFrmText.MyDoc.ExcuteDiagnoseSql();
                                //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, CurrentFrmText.MyDoc.Us.Tid.ToString() + ".xml", CurrentFrmText.MyDoc.Us.InpatientInfo.Id.ToString());
                                //InsertKeys(tempxmldoc, this.Us.Tid);
                                #region 质控表
                                if (blfalse)
                                {
                                    if (App.GetDataSet("SELECT pid from t_quality_text where tid = '" + CurrentFrmText.MyDoc.Us.Tid + "'").Tables[0].Rows.Count < 1)
                                    {
                                        //如果质控表没数据 插入该数据
                                        string sql2 = string.Format(" insert into t_quality_text"
                                                                  + " (textname, TEXTTKIND_ID, pid, create_time,tid,PATIENT_ID)"
                                                                  + " values"
                                                                  + " ('{0}','{1}','{2}',to_TIMESTAMP('{3}','yyyy-MM-dd hh24:mi'),'{4}','{5}')"
                                                                  , ""
                                                                  , CurrentFrmText.MyDoc.Us.TextKind_id
                                                                  , CurrentFrmText.MyDoc.Us.InpatientInfo.PId
                                                                  , sysTime.ToString("yyyy-MM-dd HH:mm")
                                                                  , CurrentFrmText.MyDoc.Us.Tid, CurrentFrmText.MyDoc.Us.InpatientInfo.Id);
                                        App.ExecuteSQL(sql2);
                                    }
                                    string sql3 = string.Format("UPDATE t_quality_text SET textname ='{0}' where tid = {1}"
                                        , qualityTitle
                                        , CurrentFrmText.MyDoc.Us.Tid);
                                    int i = App.ExecuteSQL(sql3);
                                    if (haveD && App.GetDataSet("SELECT PATIENT_ID from t_job_temp where operate_type='D型病历' and PATIENT_ID = '" + CurrentFrmText.MyDoc.Us.InpatientInfo.Id + "'").Tables[0].Rows.Count < 1)
                                    {
                                        string strAge = string.Empty;
                                        if (App.IsNumeric(CurrentFrmText.MyDoc.Us.InpatientInfo.Age))
                                        {
                                            strAge = CurrentFrmText.MyDoc.Us.InpatientInfo.Age;
                                        }
                                        string sqlD = string.Format("insert into t_job_temp(pid,operate_type,operate_time,patient_id,age) " +
                                                               " values('{0}','{1}',to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi'),'{3}','{4}')",
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.PId, "D型病历",
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.In_Time.ToString("yyyy-MM-dd HH:mm"),
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.Id, strAge);
                                        if (App.ExecuteSQL(sqlD) < 1)
                                        {
                                            App.Msg("质控事件表保存失败");
                                        }
                                    }

                                }
                                #endregion

                                
                                   
                                String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", CurrentFrmText.MyDoc.Us.Tid);
                                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                xmlPars[0] = new MySqlDBParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = tempxmldoc.OuterXml;
                                xmlPars[0].DBType = MySqlDbType.Text;
                                App.ExecuteSQL(sql_clob, xmlPars);
                                App.Msg("文书保存成功！");
                                CurrentFrmText.MyDoc.Modified = false;

                                if (blfalse && (App.UserAccount.CurrentSelectRole.Role_name != "规培医师" || ISPrintGPYS(CurrentFrmText.MyDoc.Us.Tid, tempxmldoc.OuterXml)))
                                {//提交    "规培医师"书写的文书不可自行打印，只有上级医生签名后方可打印
                                    App.SetToolButtonByUser("ttsbtnPrint", true);//打印
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", true);//续打
                                }
                                else
                                {
                                    App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                                }

                                WEBESPort("SC20170726030656227", GetTextData(CurrentFrmText.MyDoc.Us.Tid.ToString(), tempxmldoc.OuterXml));
                            }
                            else
                            {

                                App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                                App.Msg("文书保存失败！");
                                return;
                            }
                            //this.Modified 
                        }
                        else
                        {
                            //文书Tid
                            if (!CurrentFrmText.MyDoc.Us.IsMore)
                            {
                                DataTable havaCount =
                                    App.GetDataSet(string.Format("SELECT COUNT(t.pid) FROM T_PATIENTS_DOC T WHERE T.PATIENT_ID = '{0}' AND t.textkind_id = '{1}'", CurrentFrmText.MyDoc.Us.InpatientInfo.Id, CurrentFrmText.MyDoc.Us.TextKind_id)).Tables[0];
                                if (havaCount != null && Convert.ToInt32(havaCount.Rows[0][0]) > 0)
                                {
                                    App.Msg("该文书已经存在！可能别的账号登录已经书写提交。");
                                    return;
                                }
                            }

                            int tid = App.GenId();
                            string strinsert =
                                string.Format("insert into T_Patients_Doc(tid,CREATEID, pid, textkind_id, belongtosys_id, sickkind_id, textname,submitted,PATIENT_ID,DOC_NAME,HAVEDOCTORSIGN,ISHIGHERSIGN,HAVEHIGHERSIGN,highersignuserid,ISRAPLACEHIGHTDOCTOR,ISRAPLACEHIGHTDOCTOR2,SECTION_NAME,BED_NO,SICK_AREA_NAME,OPERATEID,sid) " +
                                              "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{1}','{19}')"
                                              , tid.ToString()                                                 //文书ID
                                              , App.UserAccount.UserInfo.User_id //是否提交按钮
                                              , CurrentFrmText.MyDoc.Us.InpatientInfo.PId
                                              , CurrentFrmText.MyDoc.Us.TextKind_id
                                              , CurrentFrmText.MyDoc.Us.Belong_ToSys_ID
                                              , CurrentFrmText.MyDoc.Us.SickKind_ID
                                              , CurrentFrmText.MyDoc.Us.OldTextName
                                              , (blfalse == true ? "Y" : "N")  //暂存/提交
                                              , CurrentFrmText.MyDoc.Us.InpatientInfo.Id
                                              , textTitle.Trim()
                                              , havaTube
                                              , CurrentFrmText.MyDoc.TextSuperiorSignature
                                              , haveSuperior
                                              , CurrentFrmText.MyDoc.SuporSign
                                              , (isTakeSuperiorZz == true ? "Y" : "N")
                                              , (isTakeSuperiorZr == true ? "Y" : "N")
                                              , App.UserAccount.CurrentSelectRole.Section_name//CurrentFrmText.MyDoc.Us.InpatientInfo.Section_Name
                                              , DataInit.strbed.Replace("床号:","")//CurrentFrmText.MyDoc.Us.InpatientInfo.Sick_Bed_Name
                                              //, CurrentFrmText.MyDoc.Us.InpatientInfo.Sick_Area_Name,CurrentFrmText.MyDoc.Us.InpatientInfo.Section_Id);
                                              , App.UserAccount.CurrentSelectRole.Sickarea_name, App.UserAccount.CurrentSelectRole.Section_Id);
                            //如果保存文书成功
                            if (App.ExecuteSQL(strinsert) > 0)
                            {
                                CurrentFrmText.MyDoc.Us.Tid = tid;
                                CurrentFrmText.MyDoc.ExcuteDiagnoseSql();
                                App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, CurrentFrmText.MyDoc.Us.Tid.ToString() + ".xml", CurrentFrmText.MyDoc.Us.InpatientInfo.Id.ToString());
                                if (blfalse)
                                {
                                    //控制暂存按钮
                                    App.SetToolButtonByUser("tsbtnTempSave", false);
                                    LogHelper.SystemLog("创建", CurrentFrmText.MyDoc.Us.Tid.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.PId.ToString(), CurrentFrmText.MyDoc.Us.InpatientInfo.Id);
                                    if (CurrentFrmText.MyDoc.Us.TextKind_id == 890)
                                    {
                                        CurrentFrmText.MyDoc.InsertJobTemp(qualityTitle);
                                    }
                                    /***
                                     * 质控表
                                     * 
                                     */
                                    string sql2 = string.Format(" insert into t_quality_text"
                                                              + " (textname, TEXTTKIND_ID, pid, create_time,tid,PATIENT_ID)"
                                                              + " values"
                                                              + " ('{0}','{1}','{2}',to_TIMESTAMP('{3}','yyyy-MM-dd hh24:mi'),'{4}','{5}')",
                                                              qualityTitle
                                                              , CurrentFrmText.MyDoc.Us.TextKind_id
                                                              , CurrentFrmText.MyDoc.Us.InpatientInfo.PId
                                                              , sysTime.ToString("yyyy-MM-dd HH:mm")
                                                              , tid
                                                              , CurrentFrmText.MyDoc.Us.InpatientInfo.Id);
                                    /***
                                     * 临床路径文书相关
                                     */
                                    //MySqlDBParameter op1 = new MySqlDBParameter();
                                    //op1.ParameterName = "yizhu";
                                    //op1.Value = tid;
                                    //MySqlDBParameter op2 = new MySqlDBParameter();
                                    //op2.ParameterName = "patient_id";
                                    //op2.Value = this.Us.InpatientInfo.Id;
                                    //MySqlDBParameter op3 = new MySqlDBParameter();
                                    //op3.ParameterName = "tiem";
                                    //op3.Value = sysTime.ToString("yyyy-MM-dd HH:mm");
                                    //MySqlDBParameter op4 = new MySqlDBParameter();
                                    //op4.ParameterName = "execute_person";
                                    //op4.Value = App.UserAccount.UserInfo.User_id + "|" + App.UserAccount.UserInfo.User_name;

                                    //App.RunProcedure("ecp.proc_excute_patientdoc", new MySqlDBParameter[] { op1, op2, op3, op4 });
                                    if (App.ExecuteSQL(sql2) < 1)
                                    {
                                        App.Msg("质控表保存失败" + sql2);
                                    }
                                    // 首次病程中如果在病历分型中有“D型病历”，则在提交文书的同时需要插入一下事件：
                                    // insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)
                                    //values('病人pid','D型病历','入院时间','病人id','年龄')

                                    if (haveD && App.GetDataSet("SELECT PATIENT_ID from t_job_temp where operate_type='D型病历' and PATIENT_ID = '" + CurrentFrmText.MyDoc.Us.InpatientInfo.Id + "'").Tables[0].Rows.Count < 1)
                                    {
                                        string strAge = string.Empty;
                                        if (App.IsNumeric(CurrentFrmText.MyDoc.Us.InpatientInfo.Age))
                                        {
                                            strAge = CurrentFrmText.MyDoc.Us.InpatientInfo.Age;
                                        }
                                        string sqlD = string.Format("insert into t_job_temp(pid,operate_type,operate_time,patient_id,age) " +
                                                               " values('{0}','{1}',to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi'),'{3}','{4}')",
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.PId, "D型病历",
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.In_Time.ToString("yyyy-MM-dd HH:mm"),
                                                                CurrentFrmText.MyDoc.Us.InpatientInfo.Id, strAge);
                                        if (App.ExecuteSQL(sqlD) < 1)
                                        {
                                            App.Msg("质控事件表保存失败");
                                        }
                                    }


                                }

                                string sql_clob = "insert into T_PATIENT_DOC_COLB(tid,CONTENT)values(" + CurrentFrmText.MyDoc.Us.Tid + ",:doc1)";
                                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                xmlPars[0] = new MySqlDBParameter();
                                xmlPars[0].ParameterName = "doc1";
                                xmlPars[0].Value = tempxmldoc.OuterXml;
                                xmlPars[0].DBType = MySqlDbType.Text;
                                App.ExecuteSQL(sql_clob, xmlPars);
                                App.Msg("文书保存成功！");
                                CurrentFrmText.MyDoc.Modified = false;

                                if (blfalse && (App.UserAccount.CurrentSelectRole.Role_name != "规培医师" || ISPrintGPYS(tid, tempxmldoc.OuterXml)))
                                {//提交      "规培医师"书写的文书不可自行打印，只有上级医生签名后方可打印
                                    App.SetToolButtonByUser("ttsbtnPrint", true);//打印
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", true);//续打
                                }
                                else
                                {
                                    App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                                }

                                if (blfalse)
                                {
                                    //消息发给平台CDR接收
                                    WEBESPort("SC20170726030656227", GetTextData(CurrentFrmText.MyDoc.Us.Tid.ToString(), tempxmldoc.OuterXml));
                                }

                            }
                            else
                            {
                                App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                                App.Msg("文书保存失败!");

                            }

                            delbakdoc(CurrentFrmText.MyDoc.Us.InpatientInfo.Id.ToString(), CurrentFrmText.MyDoc.Us.Tid.ToString(), CurrentFrmText.MyDoc.Us.TextKind_id.ToString());

                        }
                    }
                    catch (Exception x)
                    {
                        App.Msg(x.Message);
                        App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                        App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
                    }
                    if (blfalse)
                    {
                        //InsertMeg();
                    }

                    #region 原代码暂时注释
                    ///***
                    // * 传递文书 TID 过去
                    // */
                    //if (fm.MyDoc.OnBackTextId != null)
                    //{

                    //    BackEvenHandle backHandle = new BackEvenHandle();
                    //    backHandle.Style = 1;
                    //    backHandle.Submit = blfalse;
                    //    backHandle.Para = fm.MyDoc.Us.Tid.ToString();
                    //    backHandle.XmlString = tempxmldoc.OuterXml;
                    //    backHandle.User = fm.MyDoc.Us;
                    //    backHandle.SctionName = fm.MyDoc.Us.GetSectionName;
                    //    fm.MyDoc.OnBackTextId(fm.MyDoc, backHandle);
                    //}

                    //CurrentFrmText.MyDoc.
                    //fm.MyDoc.ExcuteDiagnoseSql();
                    //fm.MyDoc.HaveSuperiorSignature = haveSuperior;
                    //fm.MyDoc.HaveTubebedSign = havaTube;
                    //fm.MyDoc.Modified = false;
                    //fm.MyDoc.RefreshPages();
                    //fm.MyDoc.SaveTrue = false;
                    #endregion
                    //UpLoadImg.Instance.SaveImags(this.PageHeader, this.Us, tempxmldoc);
                    //InsertText(tempxmldoc,"");

                }
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message + "|\n" + ex.TargetSite);
                App.SetToolButtonByUser("ttsbtnPrint", false);//打印
                App.SetToolButtonByUser("ttsbtnPrintContinue", false);//续打
            }
        }
        /// <summary>
        /// 保存主诉，现病史，既往史
        /// </summary>
        /// <param name="xml">xml文件病人住院志或首次病程</param>
        /// <param name="operator_type">操作类型0，新增，1修改</param>
        private void SaveDiv(XmlDocument xml, int operator_type)
        {
            XmlNodeList nodes = xml.SelectNodes("//div[@title='主诉:' or @title='现病史：' or @title='既往史：']");
            string sql_clob = "";
            if (operator_type == 0)
            {
                sql_clob = "insert into t_patient_doc_colb_div(patient_id,CONTENT)values(" + CurrentFrmText.MyDoc.Us.InpatientInfo.Id + ",:doc1)";
            }
            else
            {
                sql_clob = "update t_patient_doc_colb_div set CONTENT=:doc1 where patient_id='" + CurrentFrmText.MyDoc.Us.InpatientInfo.Id + "'";
            }
            MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
            xmlPars[0] = new MySqlDBParameter();
            xmlPars[0].ParameterName = "doc1";
            xmlPars[0].Value = nodes[0].OuterXml + nodes[1].OuterXml + nodes[2].OuterXml;
            xmlPars[0].DBType = MySqlDbType.Text;
            App.ExecuteSQL(sql_clob, xmlPars);
        }


        /// <summary>
        /// 文书提取模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void getTemplate(object sender, EventArgs e)
        {
            // 2012-05-08
            try
            {
                frmTemplateList ff = new frmTemplateList(CurrentFrmText.MyDoc.Us.TextKind_id.ToString());
                ff.ShowDialog();
                if (ff.LoadContent != "")
                {
                    if (ff.Temptype == "S") //小模板
                    {
                        CurrentFrmText.MyDoc._InsertDocument("<emr2011><body>" + ff.LoadContent + "</body></emr2011>", 0);
                    }
                    else
                    {
                        CurrentFrmText.MyDoc.FilterXml(ff.LoadContent, 1, null);
                        CurrentFrmText.MyDoc.SaveLogs.Clear();
                    }
                }
            }
            catch (Exception ez)
            {
                App.Msg(ez.Message);
            }
        }

        /// <summary>
        /// 文书保存模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void saveTemplate(object sender, EventArgs e)
        {   //2012-05-08
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            CurrentFrmText.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.XmlClearInfo(ref tempxmldoc);
            frmTemplateSave frmtemplate = new frmTemplateSave(tempxmldoc, CurrentFrmText.MyDoc.Us.TextKind_id, CurrentFrmText.MyDoc);
            frmtemplate.ShowDialog();
        }

        /// <summary>
        /// 文书绑定工具栏按钮的设置
        /// </summary>
        public static void SetToolEvent(frmText cf)
        {
            CurrentFrmText = cf;

            App.A_Commit = null;
            App.A_Commit += new EventHandler(saveDocument);

            App.A_Template = null;
            App.A_Template += new EventHandler(getTemplate);

            App.A_Print = null;
            App.A_Print += new EventHandler(CurrentFrmText.MyDoc.PrintEdit);

            App.A_PrintContinue = null;
            App.A_PrintContinue += new EventHandler(SetEnableJumpPrint);

            App.A_TemplateSave = null;
            App.A_TemplateSave += new EventHandler(saveTemplate);

            App.A_TempSave = null;
            App.A_TempSave += new EventHandler(saveDocument);

            //App.A_btnInsertDiosgin = null;
            //App.A_btnInsertDiosgin += new EventHandler(btnInsertDiosgin_Click);

            //App.A_btnRefreshDiosgin = null;
            //App.A_btnRefreshDiosgin += new EventHandler(btnRefreshDiosgin_Click);
        }

        /// <summary>
        /// 续打参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SetEnableJumpPrint(object sender, EventArgs e)
        {
            if (CurrentFrmText.MyDoc.EnableJumpPrint)
                CurrentFrmText.MyDoc.EnableJumpPrint = false;
            else
                CurrentFrmText.MyDoc.EnableJumpPrint = true;
        }

        /// <summary>
        /// 无模版的文书创建时过滤基本信息
        /// </summary>
        /// <param name="tempxmldoc"></param>
        /// <param name="inpatient"></param>
        /// <param name="TextKind_id"></param>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public static XmlDocument XmlDoc(XmlDocument tempxmldoc, InPatientInfo InpatientInfo, frmText text)
        {
            //XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            //text.MyDoc.IsHaveDeleted = true;

            text.MyDoc.ToXML(tempxmldoc.DocumentElement);
            //text.MyDoc.IsHaveDeleted = false;

            //过滤基本信息
            try
            {
                DataInit.filterInfo(tempxmldoc.DocumentElement, InpatientInfo, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
            }
            catch (Exception ex)
            {
                string strex = ex.Message.ToString();
            }
            return tempxmldoc;
        }

        private static void setXmlFont(XmlNodeList list, XmlElement bodyElement)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == "div")
                {
                    bool eflag = false;
                    for (int j = 0; j < list[i].Attributes.Count; j++)
                    {
                        //fontsize
                        if (list[i].Attributes[j].Name == "fontsize")
                        {
                            eflag = true;
                        }
                    }
                    if (!eflag)
                    {

                        XmlAttribute xmlAttribute = bodyElement.OwnerDocument.CreateAttribute("fontsize");
                        xmlAttribute.Value = App.Read_ConfigInfo("Editor", "FontSize", App.SysPath + "//Config.ini");
                        list[i].Attributes.Append(xmlAttribute);
                    }

                }

                if (list[i].ChildNodes.Count > 0)
                {
                    setXmlFont(list[i].ChildNodes, bodyElement);
                }
            }

        }

        public static void setXmlHead(XmlElement bodyElement, string sickarea_name, string bed_no, string section)
        {
            try
            {
                XmlNode head = bodyElement.GetElementsByTagName("head")[0];
                head.Attributes["sick_area"].Value = sickarea_name;
                head.Attributes["section_name"].Value = sickarea_name;
                head.Attributes["bed_name"].Value = section;
            }
            catch (System.Exception ex)
            {
            }



        }

        /// <summary>
        /// 过滤基本信息
        /// </summary>
        /// <param name="bodyElement">xml内容</param>
        /// <param name="InpatientInfo">病人基本信息实体</param>
        /// <param name="TextKind_id">文书类型</param>
        /// <param name="Tid">所写的文书ID</param>
        public static void filterInfo(XmlElement bodyElement, InPatientInfo InpatientInfo, int TextKind_id, int Tid)
        {
            //if (dicRYText.Count == 0)
            //{
            //    //重新获取入院记录中相关值
            //    dicRYText = GetTextInfo(InpatientInfo, TextKind_id.ToString());
            //}
            dicTPRBP =new Dictionary<string,string>();
            XmlNodeList list;
            //获取文书是否提交状态
            bool Submitted = DataInit.IsDocSubmitted(Tid);
            if (!Submitted)
            {
                if (dicRYText.Count == 0)
                {//重新获取入院记录中相关值
                    dicRYText = GetTextInfo(InpatientInfo, TextKind_id.ToString());
                }
                dicTPRBP = dicRYText;//绑定数据
                //暂存文书移除模版痕迹
                XmlNodeList savelogList = bodyElement.GetElementsByTagName("savelogs");
                if (savelogList != null && savelogList.Count > 0)
                {
                    XmlNode savelogNode = savelogList[0];
                    savelogNode.ParentNode.RemoveChild(savelogNode);
                }
            }


            if (bodyElement.GetElementsByTagName("body").Count > 0)
            {
                #region boby
                XmlNode body = bodyElement.GetElementsByTagName("body")[0];
                list = body.ChildNodes;

                setXmlFont(list, bodyElement);

                //if (list != null)
                //{
                //    if (list.Count > 0 && InpatientInfo != null)
                //    {
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            if (list[i].Name == "div")
                //            {
                //                bool eflag = false;
                //                for (int j = 0; j < list[i].Attributes.Count; j++)
                //                {
                //                    //fontsize
                //                    if (list[i].Attributes[j].Name == "fontsize")
                //                    {
                //                        eflag = true;
                //                    }
                //                }
                //                if (!eflag)
                //                {

                //                    XmlAttribute xmlAttribute = bodyElement.OwnerDocument.CreateAttribute("fontsize");
                //                    xmlAttribute.Value = "14";
                //                    list[i].Attributes.Append(xmlAttribute);
                //                }
                //            }
                //        }
                //    }
                //}
                if (list != null)
                {
                    if (list.Count > 0 && InpatientInfo != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Attributes["title"] != null && list[i].Name == "div")
                            {
                                if (InpatientInfo.Gender_Code == "0" || InpatientInfo.Gender_Code == "男")
                                {
                                    if (list[i].Attributes["title"].Value.ToString().Contains("月经婚育史") ||
                                        list[i].Attributes["title"].Value.ToString().Contains("月经史"))
                                    {

                                        body.RemoveChild(list[i]);
                                    }
                                }
                                //else
                                //{
                                //    if (InpatientInfo.Age < 14)
                                //    {
                                //        body.RemoveChild(list[i]);
                                //    }
                                //}
                            }
                        }
                    }
                }
                #endregion
            }

            if (App.UserAccount.CurrentSelectRole.Section_Id == InpatientInfo.Section_Id.ToString())
            {
                list = bodyElement.GetElementsByTagName("head");
                if (list != null)
                {
                    if (list.Count > 0)
                        bodyElement.RemoveChild(list[0]);
                }
            }

            var flag = App.GetHospitalConfig("ZM2016122901");
            if (flag.IsNotEmptyAndEquals("1"))
            {
                Filter(bodyElement, InpatientInfo.Id);
                filterinfo(bodyElement, InpatientInfo, Tid);
            }
            else
                filterinfo(bodyElement, InpatientInfo, Tid);
            //XmlNodeList list = bodyElement.GetElementsByTagName("input");                        


        }
        static void filterinfo(XmlElement bodyElement, InPatientInfo InpatientInfo, int Tid)
        {
            var list = bodyElement.GetElementsByTagName("input");

            if (list != null)
            {
                if (list.Count > 0 && InpatientInfo != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Attributes["name"] != null)
                        {
                            if (list[i].InnerText.Trim() == "" || Tid == 0)
                            {
                                //string sss = list[i].Attributes["name"].Value.ToString().Trim();
                                //if (sss.Contains("体温") || sss.Contains("脉搏") || sss.Contains("呼吸"))
                                //{
                                //    sss = "aaaa" + sss;
                                //}
                                switch (list[i].Attributes["name"].Value.ToString().Trim())
                                {
                                    case "户口地址":
                                    case "us_jtdz":
                                        list[i].InnerText = InpatientInfo.Home_address;
                                        break;
                                    case "电话":
                                        list[i].InnerText = InpatientInfo.Now_addres_phone;
                                        break;
                                    case "家庭电话":
                                        list[i].InnerText = InpatientInfo.Home_phone;
                                        break;
                                    case "联系人姓名":
                                    case "联系人":
                                        list[i].InnerText = InpatientInfo.Relation_name;
                                        break;
                                    case "联系人地址":
                                    case "联系人住址":
                                        list[i].InnerText = InpatientInfo.Relation_address;
                                        break;
                                    case "联系人电话":
                                        list[i].InnerText = InpatientInfo.Relation_phone;
                                        break;
                                    case "联系人关系":
                                    case "关系":
                                        list[i].InnerText = App.ReadSqlVal("select name from t_data_code where type=131 and code='" + InpatientInfo.Relation + "'", 0, "name");
                                        break;
                                    case "姓名":
                                    case "us_xm":
                                        list[i].InnerText = InpatientInfo.Patient_Name;
                                        break;
                                    case "出生地":
                                    case "us_csd":
                                        if (InpatientInfo.Birth_place != null)
                                            list[i].InnerText = InpatientInfo.Birth_place.Replace("|", "");
                                        break;
                                    case "出生日期":                                     
                                            list[i].InnerText = Convert.ToDateTime(InpatientInfo.Birthday).ToString("yyyy-MM-dd");
                                        break;
                                    case "性别":
                                    case "us_xb":
                                        if (InpatientInfo.Gender_Code == "0" || InpatientInfo.Gender_Code == "男")
                                            list[i].InnerText = "男";
                                        else
                                            list[i].InnerText = "女";
                                        break;
                                    case "民族":
                                    case "us_mz":
                                        list[i].InnerText = InpatientInfo.Folk_code;
                                        break;
                                    case "年龄":
                                    case "us_nl":
                                        if (!string.IsNullOrEmpty(InpatientInfo.Age))
                                            list[i].InnerText = InpatientInfo.Age + InpatientInfo.Age_unit;
                                        else
                                            list[i].InnerText = "0岁";
                                        break;
                                    case "入院时间":
                                    case "us_rysj":
                                        list[i].InnerText = InpatientInfo.In_Time.ToString("yyyy-MM-dd HH:mm");
                                        break;
                                    case "入院日期":
                                    case "us_ryrq":
                                        list[i].InnerText = InpatientInfo.In_Time.ToString("yyyy-MM-dd");
                                        break;
                                    case "记录日期":
                                    case "us_jlrq":
                                        list[i].InnerText = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                        break;
                                    case "婚姻":
                                    case "us_hy":
                                        list[i].InnerText = InpatientInfo.Marrige_State;
                                        break;
                                    case "职业":
                                    case "us_zy":
                                        if (InpatientInfo.Career != null && !InpatientInfo.Career.Contains("其他"))
                                            list[i].InnerText = InpatientInfo.Career;
                                        else
                                            list[i].InnerText = InpatientInfo.Career_other;
                                        break;
                                    case "单位及职业":
                                    case "us_dwjzy":
                                        if (InpatientInfo.Career != null && !InpatientInfo.Career.Contains("其他"))
                                            list[i].InnerText = InpatientInfo.Office + "  " + InpatientInfo.Career;
                                        else
                                            list[i].InnerText = InpatientInfo.Office + "  " + InpatientInfo.Career_other;
                                        break;
                                    case "工作单位":
                                    case "us_gzdw":
                                        list[i].InnerText = InpatientInfo.Office_address;
                                        break;
                                    case "工作单位电话":
                                    case "us_gzdwdh":
                                        list[i].InnerText = InpatientInfo.Office_phone;
                                        break;
                                    case "住址":
                                    case "现住址":
                                    case "us_jtzz":
                                        list[i].InnerText = InpatientInfo.Now_address;
                                        break;
                                    case "邮编":
                                    case "现住址邮编":
                                        list[i].InnerText = InpatientInfo.HomePostal_code;
                                        break;
                                    case "现住址电话":
                                        list[i].InnerText = InpatientInfo.Home_phone;
                                        break;
                                    case "us_jg":
                                    case "籍贯":
                                        if (InpatientInfo.Natiye_place != null)
                                            list[i].InnerText = InpatientInfo.Natiye_place.Replace("|", "");
                                        break;
                                    case "初步诊断":
                                        list[i].InnerText = "";
                                        break;
                                    case "住院号":
                                    case "us_zyh":
                                        list[i].InnerText = InpatientInfo.PId;
                                        break;
                                    case "住院日数":
                                        TimeSpan timespan = TimeSpan.Zero;
                                        if (InpatientInfo.Die_time!=DateTime.MinValue)
                                        {
                                            timespan = Convert.ToDateTime(InpatientInfo.Die_time.ToString("yyyy-MM-dd")) - Convert.ToDateTime(InpatientInfo.In_Time.ToString("yyyy-MM-dd"));
                                        }
                                        else
                                        {
                                            timespan = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd")) - Convert.ToDateTime(InpatientInfo.In_Time.ToString("yyyy-MM-dd"));
                                        }
                                        if (timespan.Days == 0 || timespan.Days == 1)
                                        {
                                            list[i].InnerText = "1";
                                        }
                                        else if (timespan.Days > 1)
                                        {
                                            list[i].InnerText = timespan.Days.ToString();
                                        }
                                        break;
                                    case "科室":
                                    case "us_ks":
                                        //case "请求会诊科":
                                        list[i].InnerText = InpatientInfo.Section_Name;
                                        break;
                                    case "病区":
                                    case "us_bq":
                                        list[i].InnerText = InpatientInfo.Sick_Area_Name;
                                        break;
                                    case "床号":
                                    case "us_ch":
                                        list[i].InnerText = InpatientInfo.Sick_Bed_Name;
                                        break;
                                    case "身份证":
                                    case "us_sfz":
                                        if (InpatientInfo.Card_Id.Length > 10)
                                        {
                                            list[i].InnerText = InpatientInfo.Card_Id;
                                        }
                                        break;
                                    case "his_id":
                                        //if (!string.IsNullOrEmpty(Us.InpatientInfo.His_id))
                                        //{
                                        list[i].InnerText = InpatientInfo.His_id;
                                        //}
                                        break;
                                    //case "住院号":
                                    //    list[i].InnerText = InpatientInfo.PId;
                                    //    break;
                                    //体温T,P,R,BP
                                    case "体温":
                                    case "脉搏":
                                    case "呼吸":
                                    //case "收缩压":
                                    //case "舒张压":
                                        
                                    case "血压":
                                        if (dicTPRBP.Count > 0 && dicTPRBP.ContainsKey(list[i].Attributes["name"].Value.ToString().Trim()))
                                            list[i].InnerText = dicTPRBP[list[i].Attributes["name"].Value.ToString().Trim()].ToString();
                                        break;
                                    case "入院科室":
                                        list[i].InnerText = InpatientInfo.Insection_Name;
                                        break;
                                    case "住院天数":
                                        TimeSpan tsp = new TimeSpan();
                                        tsp = InpatientInfo.Die_time - Convert.ToDateTime(InpatientInfo.In_Time);
                                        int day = tsp.Days + 1;
                                        if (day > 0)
                                        {
                                            list[i].InnerText = day.ToString();
                                        }
                                        break;
                                    case "死亡日期":
                                        if (InpatientInfo.Die_flag == 1)
                                        {
                                            list[i].InnerText = InpatientInfo.Die_time.ToString("yyyy-MM-dd");
                                        }
                                        break;
                                    case "死亡时间":
                                        if (InpatientInfo.Die_flag == 1)
                                        {
                                            list[i].InnerText = InpatientInfo.Die_time.ToString("yyyy-MM-dd HH:mm");
                                        }
                                        break;
                                    case "出院日期":
                                        if (InpatientInfo.Die_time.Year > 2014)
                                        {
                                            list[i].InnerText = InpatientInfo.Die_time.ToString("yyyy-MM-dd");
                                        }
                                        break;
                                    case "出院时间":
                                        list[i].InnerText = InpatientInfo.Die_time.ToString("yyyy-MM-dd HH:mm");
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// WEBESPort消息
        /// </summary>
        public static void WEBESPort(string service, string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }
            try
            {


                WebReference.WEBESPort web = new WebReference.WEBESPort();
                string xml = @"<MSG><HEAD><REQ_ID>00000000-0000-0000-0000-000000000000</REQ_ID><SEC_ID>Cleartext</SEC_ID><SEC_KEY>0004</SEC_KEY>";
                xml += "<SERVICE>" + service + "</SERVICE><FORMAT></FORMAT><PARTNER>N10004</PARTNER><CREATETIME>" + App.GetSystemTime().ToString("yyyyMMdd") + "</CREATETIME>";
                xml += "<MSGTYPE>V3</MSGTYPE><TICKET></TICKET><EVENT></EVENT><EVENT_KEY></EVENT_KEY></HEAD>";
                xml += "<BODY><CONTENT><![CDATA[" + data + "]]>";
                xml += "</CONTENT></BODY></MSG>";
                web.executes(xml);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static string GetTextData(string tid, string text)
        {
            try
            {
                DataRow dr = App.GetDataSet("select * from v_cdr_text where 文档本地ID='" + tid + "'").Tables[0].Rows[0];
                StringBuilder data = new StringBuilder();
                data.Append("<DATA>");
                //data.Append("<!--文档本地ID-->");
                data.Append("<DOCUMENT_LID>" + tid + "</DOCUMENT_LID>");
                //data.Append("<!--HIS病人ID-->");
                data.Append("<PATIENT_LID>" + dr["HIS病人ID"].ToString() + "</PATIENT_LID>");
                //data.Append("<!--住院次数-->");
                data.Append("<VISIT_ID>" + dr["住院次数"].ToString() + "</VISIT_ID>");
                //data.Append("<!--住院号-->");
                data.Append("<INP_NO>" + dr["住院号"].ToString() + "</INP_NO>");
                //data.Append("<!--文档创建科室ID-->");
                data.Append("<DOCUMENT_DEPT_ID>" + dr["文档创建科室ID"].ToString() + "</DOCUMENT_DEPT_ID>");
                //data.Append("<!--文档创建科室名称-->");
                data.Append("<DOCUMENT_DEPT_NAME>" + dr["文档创建科室名称"].ToString() + "</DOCUMENT_DEPT_NAME>");
                //data.Append("<!--床位号-->");
                data.Append("<BED_NO>" + dr["床位号"].ToString() + "</BED_NO>");
                //data.Append("<!--医疗机构编码-->");
                data.Append("<ORG_CODE>52131000732914406B</ORG_CODE>");
                //data.Append("<!--医疗机构名称-->");
                data.Append("<ORG_NAME>廊坊爱德堡医院</ORG_NAME>");
                //data.Append("<!--接口服务ID-->");
                data.Append("<SERVICE_ID></SERVICE_ID>");
                //data.Append("<!--文档类别代码-->");
                data.Append("<DOCUMENT_TYPE>" + dr["文档类别代码"].ToString() + "</DOCUMENT_TYPE>");
                //data.Append("<!--文档类别名称-->");
                data.Append("<DOCUMENT_TYPE_NAME>" + dr["文档类别名称"].ToString() + "</DOCUMENT_TYPE_NAME>");
                //data.Append("<!--文档名称-->");
                data.Append("<DOCUMENT_NAME>" + dr["文档名称"].ToString() + "</DOCUMENT_NAME>");
                //data.Append("<!--文档作者ID-->");
                data.Append("<DOCUMENT_AUTHOR>" + dr["文档作者ID"].ToString() + "</DOCUMENT_AUTHOR>");
                //data.Append("<!--文档作者姓名-->");
                data.Append("<DOCUMENT_AUTHOR_NAME>" + dr["文档作者姓名"].ToString() + "</DOCUMENT_AUTHOR_NAME>");
                //data.Append("<!--完成时间-->");
                data.Append("<WRITE_TIME>" + dr["完成时间"].ToString() + "</WRITE_TIME>");
                //data.Append("<!--文档修改者ID-->");
                data.Append("<DOCUMENT_MODIFIER>" + dr["文档修改者ID"].ToString() + "</DOCUMENT_MODIFIER>");
                //data.Append("<!--文档修改者姓名-->");
                data.Append("<DOCUMENT_MODIFIER_NAME>" + dr["文档修改者姓名"].ToString() + "</DOCUMENT_MODIFIER_NAME>");
                //data.Append("<!--修改时间-->");
                data.Append("<MODIFY_TIME>" + dr["修改时间"].ToString() + "</MODIFY_TIME>");
                //data.Append("<!--审核人ID-->");
                data.Append("<REVIEW_PERSON>" + dr["审核人ID"].ToString() + "</REVIEW_PERSON>");
                //data.Append("<!--审核人姓名-->");
                data.Append("<REVIEW_PERSON_NAME>" + dr["审核人姓名"].ToString() + "</REVIEW_PERSON_NAME>");
                //data.Append("<!--审核时间-->");
                data.Append("<REVIEW_TIME></REVIEW_TIME>");
                //data.Append("<!--提交时间-->");
                data.Append("<SUBMIT_TIME>" + dr["提交时间"].ToString() + "</SUBMIT_TIME>");
                //data.Append("<!--签名文档URI-->");
                data.Append("<DOCUMENT_URL></DOCUMENT_URL>");
                //data.Append("<!--电子签名时间-->");
                data.Append("<SIGN_TIME>" + dr["电子签名时间"].ToString() + "</SIGN_TIME>");
                //data.Append("<!--文档内容-->");
                data.Append("<DOCUMENT_CONTENT>" + text.Replace("<![CDATA[]]>", "") + "</DOCUMENT_CONTENT>");
                //data.Append("<!--文档CDA-->");
                data.Append("<DOCUMENT_CDA></DOCUMENT_CDA>");
                //data.Append("<!--签章ID-->");
                data.Append("<SIGNATURE_ID></SIGNATURE_ID>");
                //data.Append("<!--病程记录的标题时间-->");
                data.Append("<DOCUMENT_TITLE_TIME>" + dr["病程记录的标题时间"].ToString().Trim() + "</DOCUMENT_TITLE_TIME>");
                //data.Append("<!--病程记录的标题名称-->");
                data.Append("<TITLE_NAME>" + dr["病程记录的标题名称"].ToString() + "</TITLE_NAME>");
                //data.Append("<!--删除标识-->");
                data.Append("<DELETE_FLAG>" + dr["删除标识"].ToString() + "</DELETE_FLAG>");
                //data.Append("<!--删除时间-->");
                data.Append("<DELETE_TIME>" + dr["删除时间"].ToString() + "</DELETE_TIME>");
                data.Append("</DATA>");
                return data.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 过滤签名
        /// </summary>
        /// <param name="bodyElement"></param>
        /// <param name="TextKind_id"></param>
        public static void filterInfo(XmlElement bodyElement, int TextKind_id)
        {
            //1963,125,126,127,130,131,132,135,136,153,301,890,891,741

            //过滤病程记录下的所有类型的文书 武汉这边很多住院治要过滤TextKind_id从119-47560141
            if (TextKind_id == 1963 ||
                TextKind_id == 125 ||
                TextKind_id == 126 ||
                TextKind_id == 127 ||
                TextKind_id == 130 ||
                TextKind_id == 131 ||
                TextKind_id == 132 ||
                TextKind_id == 135 ||
                TextKind_id == 136 ||
                TextKind_id == 153 ||
                TextKind_id == 301 ||
                TextKind_id == 890 ||
                TextKind_id == 891 ||
                TextKind_id == 741 ||
                TextKind_id == 119 ||
                TextKind_id == 47553087 || TextKind_id == 47553088 ||
                TextKind_id == 47553089 || TextKind_id == 47561196 ||
                TextKind_id == 63471477 || TextKind_id == 47607562 ||
                TextKind_id == 47587230 || TextKind_id == 47560141 ||
                TextKind_id == 6988518)
            {
                XmlNodeList list;
                list = bodyElement.GetElementsByTagName("input");
                XmlNode body = bodyElement.GetElementsByTagName("body")[0];
                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Attributes["name"] != null)
                            {
                                if (list[i].Attributes["name"].Value.ToString().Contains("医师签名") ||
                                    list[i].Attributes["name"].Value.ToString().Contains("时间") ||
                                    list[i].Attributes["name"].Value.ToString().Contains("联系人地址") ||
                                    list[i].Attributes["name"].Value.ToString().Contains("联系人电话") ||
                                    list[i].Attributes["name"].Value.ToString().Contains("工作单位电话") ||
                                    list[i].Attributes["name"].Value.ToString().Contains("现住址"))
                                {
                                    try
                                    {
                                        list[i].InnerText = "";
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 刷新文书树
        /// 不需要显示层级结构
        /// </summary>
        /// <param name="trvBook">树控件对象</param>
        /// <param name="key">查询关键字</param>
        public static void ReflashBookTree(AdvTree trvBook, string key)
        {
            //查出与关键字匹配的文书
            string SQl = "select * from T_TEXT where enable_flag='Y' and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') and upper(textname) like '%" + key.ToUpper() + "%' and (sid='0' or instr(sid,'" + CurrentPatient.Section_Id.ToString() + "')>0) and id not in(select distinct parentid from t_text) and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc";
            //string SQl = "select * from T_TEXT where enable_flag='Y' and id not in(select distinct parentid from t_text) and upper(textname) like '%" + key.ToUpper() + "%' and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc";
            DataSet ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);

            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    if (Directionarys[i].Issimpleinstance == "1")
                    {
                        tn.Image = global::Base_Function.Resource.多例文书;
                    }
                    else
                    {
                        tn.Image = global::Base_Function.Resource.单例文书;
                    }
                    if (ValidateTextSection(Directionarys[i].Sid))
                    {
                        trvBook.Nodes.Add(tn);
                        //SetTreeNodesImage(trvBook.Nodes);
                    }
                }
            }
        }

        /// <summary>
        /// 以逗号隔开的科室ID字符串
        /// </summary>
        /// <param name="sids"></param>
        /// <returns></returns>
        public static bool ValidateTextSection(string sids)
        {
            //0表示全院
            if (sids == "0")
            {
                return true;
            }
            else
            {
                string[] sidArr = sids.Split(',');//文书所属科室数组
                //当前科室ID
                string currSid = App.UserAccount.CurrentSelectRole.Section_Id;
                for (int i = 0; i < sidArr.Length; i++)
                {
                    if (currSid == sidArr[i])
                    {
                        return true;
                    }
                }
                return false;
            }

        }


        /// <summary>
        /// 年龄差
        /// </summary>
        /// <param name="dtBirthday">出生年月日</param>
        /// <param name="dtNow">当前时间</param>
        /// <returns></returns>
        public static string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty;                         // 年龄的字符串表示
            int intYear = 0;                                    // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天

            // 如果没有设定出生日期, 返回空


            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;

            // 格式化年龄输出
            if (intYear >= 1)                                            // 年份输出
            {
                strAge = intYear.ToString() + "岁";
            }

            if (intMonth > 0 && intYear <= 1)                           // 1岁以下可以输出月数
            {
                strAge += intMonth.ToString() + "月";
            }

            if (intDay >= 0 && intYear < 1)                              // 一岁以下可以输出天数
            {
                if (strAge.Length == 0 || intDay > 0)
                {
                    strAge += intDay.ToString() + "日";
                }
            }

            return strAge;
        }

        /// <summary>
        /// 换取患者儿童不满一周岁年龄
        /// </summary>
        /// <param name="patientid"></param>
        /// <returns></returns>
        public static string GetAge(string patientid)
        {
            string strAge = string.Empty;
            try
            {
                DateTime dtbirth = Convert.ToDateTime(App.ReadSqlVal(" select birthday from t_in_patient where id=" + patientid, 0, "birthday"));
                DateTime dtintime = Convert.ToDateTime(App.ReadSqlVal(" select in_time from t_in_patient where id=" + patientid, 0, "in_time"));
                strAge = GetAgeNew(dtbirth, dtintime);
                //strAge = App.ReadSqlVal("select CHILD_AGE from t_in_patient where id=" + patientid, 0, "CHILD_AGE");
            }
            catch
            { }
            return strAge;
        }
        /// <summary>
        /// 获得年龄
        /// </summary>
        /// <param name="patientRow">当前病人</param>
        /// <param name="AGE">年龄</param>
        /// <param name="AGE_UNIT">单位</param>
        public static string GetAgeNew(DateTime birthday, DateTime in_time)
        {
            int year = 0;
            int mont = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;
            string AGE = string.Empty;
            string AGE_UNIT = string.Empty;
            DataInit.GetAgeByBirthday(birthday, in_time, out year, out mont, out day, out hour, out minute);//App.GetSystemTime()
            if (year > 0)
            {
                if (year >= 5)
                {
                    AGE = year.ToString();
                    AGE_UNIT = "岁";
                }
                else
                {
                    AGE = year.ToString();
                    AGE_UNIT = "岁" + mont.ToString() + "月";
                }
            }
            else if (mont > 0)
            {
                if (mont >= 3)
                {
                    AGE = mont.ToString();
                    AGE_UNIT = "月";
                }
                else
                {
                    AGE = mont.ToString();
                    AGE_UNIT = "月" + day.ToString() + "天";
                }
            }
            else if (day > 0)
            {

                AGE = day.ToString();
                AGE_UNIT = "天";
            }
            else if (hour > 0)
            {
                AGE = hour.ToString();
                AGE_UNIT = "小时";
            }
            else
            {
                AGE = minute.ToString();
                AGE_UNIT = "分";
            }
            return AGE + AGE_UNIT;
        }
        /// <summary>
        /// 中文符号转英文符号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceZYChar(string str)
        {
            if (str == String.Empty)
                return String.Empty; str = str.Replace("‘", "'");
            str = str.Replace("、", ",");
            str = str.Replace("，", ",");
            str = str.Replace("。", ".");
            str = str.Replace("：", ":");
            str = str.Replace("“", @"""");
            str = str.Replace("”", @"""");
            str = str.Replace("（", "(");
            str = str.Replace("）", ")");
            str = str.Replace("＝", "=");
            str = str.Replace("＋", "+");
            str = str.Replace("＊", "*");
            str = str.Replace("＆", "&");
            str = str.Replace("＃", "#");
            str = str.Replace("％", "%");
            str = str.Replace("￥", "$");
            str = str.Replace("＠", "@");
            str = str.Replace("　", "  ");

            return str;
        }

        /// <summary>
        /// 时间字符串转出xml格式字符串
        /// </summary>
        /// <param name="time">时间字符串</param>
        /// <returns></returns>
        public static string TimeToXml(string time)
        {
            try
            {
                if (time.Length == 15)
                {
                    time = time.Insert(10, " ");
                }
                //设置接诊时间的样式
                string datetype = Convert.ToDateTime(time).ToString("yyyy-MM-dd");
                string datetime = Convert.ToDateTime(time).ToString("HH:mm");
                string timexml =
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[0] + "</span>" +
                        "<span operatercreater='0'>-</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[1] + "</span>" +
                        "<span operatercreater='0'>-</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[2] + "</span>" +
                        "<span operatercreater='0'>，</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetime.Split(':')[0] + "</span>" +
                        "<span operatercreater='0'>:</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetime.Split(':')[1] + "</span>";
                return timexml;
            }
            catch (Exception)
            {
                App.Msg("提示:时间格式不正确,请双击时间选项修改!");
                return "";
            }
        }

        public static string[] GetManually_turn_area()
        {
            string[] Mta = null;
            string Sql_getSection = "";
            Sql_getSection = "select b.sid,b.section_name from t_section_area a" +
                                   " inner join t_sectioninfo b on a.sid = b.sid" +
                                   " where b.enable_flag='Y' and b.Manually_turn_area is not null";


            DataSet ds = App.GetDataSet(Sql_getSection);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                Mta = new string[dt.Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Mta[i] = ds.Tables[0].Rows[i][1].ToString();
                }
            }

            return Mta;
        }

        /// <summary>
        /// 文书内容相互读取
        /// 2014-12-09
        /// </summary>
        /// <param name="text_id"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string DocFromXmlBytText(string text_id, string content, InPatientInfo inPatient)
        {
            try
            {
                string cont = content;
                //if (!TidHaveClone(text_id, inPatient))
                //{
                //    return content;
                //}
                if (string.IsNullOrEmpty(content))
                {
                    return content;
                }
                else
                {
                    //存在文书
                    string sql = " select * from t_text_read  a inner join t_patients_doc b on a.CURRENTTID=b.textkind_id where b.patient_id='" + inPatient.Id + "'"; //  and a.currenttid='" + text_id + "'";
                    DataSet ds = App.GetDataSet(sql);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string text_tid = ds.Tables[0].Rows[i]["tid"].ToString();

                            string ctitlename = ds.Tables[0].Rows[i]["ctitlename"].ToString().Trim();

                            string cinputname = ds.Tables[0].Rows[i]["cinputname"].ToString().Trim();


                            XmlDocument tmpxml_source = new XmlDocument();
                            tmpxml_source.PreserveWhitespace = true;
                            string content_source = "";
                            content_source = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + text_tid + "", 0, "CONTENT");
                            if (content_source == "" || content_source == null)
                            {
                                content_source = App.DownLoadFtpPatientDoc(text_tid + ".xml", inPatient.Id.ToString());
                            }
                            tmpxml_source.LoadXml(content_source);

                            bool ishavediv = false;
                            XmlNode sourcebodynode = tmpxml_source.ChildNodes[0].SelectSingleNode("body");
                            XmlNodeList sourcelist = ((XmlElement)sourcebodynode).GetElementsByTagName("div");
                            foreach (XmlNode xn in sourcelist)
                            {
                                if (xn.Attributes["title"] != null)
                                {
                                    string xnname = xn.Attributes["title"].Value.ToString().Trim();
                                    xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();
                                    ctitlename = ctitlename.Replace(":", " ").Replace("：", " ").Trim();
                                    if (xnname == ctitlename)
                                    {
                                        ishavediv = true;
                                    }
                                }
                            }

                            if (ishavediv)
                            {
                                XmlDocument tempxmldoc = new XmlDocument();
                                tempxmldoc.PreserveWhitespace = true;
                                if (content.Contains("emrtextdoc"))
                                {
                                    tempxmldoc.LoadXml(content);
                                    XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                    //标题字段读取

                                    XmlNode bodynode = tempxmldoc.ChildNodes[0].SelectSingleNode("body");
                                    XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");

                                    foreach (XmlNode xn in list)
                                    {
                                        if (xn.Attributes["title"] != null)
                                        {
                                            string xnname = xn.Attributes["title"].Value.ToString().Trim();
                                            xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();
                                            ctitlename = ctitlename.Replace(":", " ").Replace("：", " ").Trim();
                                            if (xnname == ctitlename)
                                            {
                                                XmlNode temp = ReadXml(content_source, ctitlename, true, ctitlename, false);
                                                if (temp != null)
                                                    xn.InnerText = temp.InnerText;

                                            }
                                        }
                                    }

                                    //插入input
                                    XmlNodeList list2 = tempxmldoc.GetElementsByTagName("input");
                                    if (list2 != null && list2.Count > 0)
                                    {
                                        for (int j = 0; j < list2.Count; j++)
                                        {
                                            if (list2[j].Attributes["name"] != null)
                                            {
                                                ctitlename = ctitlename.Replace(":", " ").Replace("：", " ").Trim();
                                                string xnname = list2[j].Attributes["name"].Value.ToString().Trim();
                                                xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();
                                                if (!string.IsNullOrEmpty(ctitlename) && xnname == ctitlename)
                                                {

                                                    XmlNode temp = ReadXml(content_source, ctitlename, true, ctitlename, false);
                                                    if (temp != null)
                                                        list2[j].InnerText = temp.InnerText;//ReadXml(content_source, stitlename, false, ctitlename, true);
                                                }
                                            }
                                        }
                                    }

                                    content = tempxmldoc.InnerXml;
                                }
                            }
                        }
                    }


                }
                return content;
            }
            catch
            {
                return content;
            }
        }

        /// <summary>
        /// 读取文书里面的内容
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="inputName"></param>
        /// <param name="isTitle"></param>
        /// <param name="isInput"></param>
        /// <returns></returns>
        private static XmlNode ReadXml(string xml, string TitleName, bool isTitle, string InputName, bool isInput)
        {
            string result = string.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                //if (isTitle == true)
                //{
                XmlNode bodynode = doc.ChildNodes[0].SelectSingleNode("body");
                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("div");
                foreach (XmlNode xn in list)
                {
                    if (xn.Attributes["title"] != null)
                    {
                        string xnname = xn.Attributes["title"].Value.ToString().Trim();
                        xnname = xnname.Replace(":", " ").Replace("：", " ").Trim();
                        if (!string.IsNullOrEmpty(TitleName) && TitleName == xnname)
                        {
                            if (!String.IsNullOrEmpty(xn.InnerText))
                            {
                                xmlFilter(xn);
                                return xn;
                            }
                        }
                    }
                }
                //}
                //if (isInput == true)
                //{
                //XmlNodeList list2 = doc.GetElementsByTagName("input");
                //if (list2 != null && list2.Count>0)
                //{
                //    for (int i = 0; i < list2.Count; i++)
                //    {
                //        if (list2[i].Attributes["name"] != null&&list2[i].InnerText.Trim() == "")
                //        {

                //            string xnname = list2[i].Attributes["name"].Value.ToString().Trim();
                //            xnname=xnname.Replace(":", " ").Replace("：", " ").Trim();
                //            InputName = InputName.Replace(":", " ").Replace("：", " ").Trim();

                //            if (!string.IsNullOrEmpty(InputName) && xnname == InputName)
                //            {
                //                return  xmlFilter(list2[i]);
                //            }                                
                //        }
                //    }  
                //}
                //}

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 过滤掉xml节点已经删除的内容
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        private static void xmlFilter(XmlNode xn)
        {
            try
            {
                if (xn.InnerXml.Contains("deleter"))
                {
                    XmlNodeList span = xn.SelectNodes("span");
                    foreach (XmlNode xnl in span)
                    {
                        for (int i = 0; i < xnl.Attributes.Count; i++)
                        {
                            if (xnl.Attributes[i].Name == "deleter")
                            {
                                xn.RemoveChild(xnl);
                                xmlFilter(xn);
                            }
                        }
                    }


                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 当前文书是否需要自动读取其他文书的信息
        /// 是否存在对应的文书
        /// </summary>
        /// <param name="text_id"></param>
        /// <returns></returns>
        private static bool TidHaveClone(string text_id, InPatientInfo inPatient)
        {
            bool flag = false;
            try
            {
                string sql = " select * from t_text_read  a inner join t_patients_doc b on a.sourcetid=b.textkind_id where b.patient_id='" + inPatient.Id + "' and a.currenttid='" + text_id + "'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    flag = true;
                }
                return flag;
            }
            catch
            {
                return flag;
            }
        }



        /// <summary>
        /// 获取相关的文书信息
        /// </summary>
        /// <param name="inPatient">住院病人</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetTextInfo(InPatientInfo inPatient, string textId)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //string textlist = "47560141,119,47553087,47553088,47553089,47561196,102,120,121,6982569,6988518";
            if (textId!=null)//入院记录类型id   textlist.Contains(textId)
            {//打开入院记录时,需获取T,P,R,BP值
                try
                {
                    //体温单首次T,P,R,BP
                    //string TPRBPSql = @"select * from (select measure_time,TEMPERATURE_VALUE,PULSE_VALUE,BREATH_VALUE, " +
                    //                "(select bp_blood from (select tt.record_time,tt.bp_blood from t_temperature_info tt  " +
                    //                "where patient_id='" + inPatient.Id + "' and bp_blood is not null order by record_time ) where rownum=1) bp_blood " +
                    //                " from t_vital_signs  where patient_id='" + inPatient.Id + "' and TEMPERATURE_VALUE<>0.0 order by measure_time) where rownum=1";

                    string TPRBPSql = @"select * from (select t.measure_time,'体温' valtype,t.t_val from T_TEMPERATURE_RECORD t where t.patient_id={0} and t.valtype in('腋温','口温','肛温') and rownum = 1 order by measure_time)
                                    union all
                                    select * from (select t.measure_time,t.valtype,t.t_val from T_TEMPERATURE_RECORD t where t.patient_id={0} and t.valtype='脉搏'  order by measure_time) where rownum = 1
                                    union all
                                    select * from (select t.measure_time,t.valtype,t.t_val from T_TEMPERATURE_RECORD t where t.patient_id={0} and t.valtype='呼吸次数'  order by measure_time) where rownum = 1
                                    union all
                                    select * from (select t.measure_time,'血压' valtype,t.t_val from T_TEMPERATURE_RECORD t where t.patient_id={0} and t.valtype in('血压1','血压2') and rownum = 1 order by measure_time)";
                    TPRBPSql = string.Format(TPRBPSql, inPatient.Id);
                    DataTable dtTPRBP = App.GetDataSet(TPRBPSql).Tables[0];
                    for (int i = 0; i < dtTPRBP.Rows.Count; i++)
                    {
                        if (dtTPRBP.Rows[i]["valtype"].ToString()=="体温")
                        {
                            dic.Add("体温", dtTPRBP.Rows[i]["t_val"].ToString());
                        }
                        else if (dtTPRBP.Rows[i]["valtype"].ToString() == "脉搏")
                        {
                            dic.Add("脉搏", dtTPRBP.Rows[i]["t_val"].ToString());
                        }
                        else if (dtTPRBP.Rows[i]["valtype"].ToString() == "呼吸次数")
                        {
                            dic.Add("呼吸", dtTPRBP.Rows[i]["t_val"].ToString());
                        }
                        else if (dtTPRBP.Rows[i]["valtype"].ToString() == "血压")
                        {
                            dic.Add("血压", dtTPRBP.Rows[i]["t_val"].ToString());
                            //string bp_blood = dtTPRBP.Rows[i]["t_val"].ToString().Trim();//O128/84,T140/80
                            //if (!string.IsNullOrEmpty(bp_blood))
                            //{
                            //    if (bp_blood.Contains("/"))
                            //    {
                            //        string[] us_blood = bp_blood.Split('/');
                            //        dic.Add("收缩压", us_blood[0]);
                            //        dic.Add("舒张压", us_blood[1]);
                            //    }
                            //}
                        }
                    }
                    //if (dtTPRBP.Rows.Count > 0)
                    //{
                    //    dic.Add("体温", Convert.ToDouble(dtTPRBP.Rows[0]["TEMPERATURE_VALUE"]).ToString());
                    //    string PULSE_VALUE = dtTPRBP.Rows[0]["PULSE_VALUE"].ToString();
                    //    if (PULSE_VALUE == "0" || PULSE_VALUE == "0.0")
                    //    { }
                    //    else
                    //    {
                    //        dic.Add("脉搏", PULSE_VALUE);
                    //    }
                    //    string BREATH_VALUE = dtTPRBP.Rows[0]["BREATH_VALUE"].ToString();
                    //    if (BREATH_VALUE == "0" || BREATH_VALUE == "0.0")
                    //    { }
                    //    else
                    //    {
                    //        dic.Add("呼吸", dtTPRBP.Rows[0]["BREATH_VALUE"].ToString());
                    //    }

                    //    string bp_blood = dtTPRBP.Rows[0]["bp_blood"].ToString().Trim();//O128/84,T140/80
                    //    if (!string.IsNullOrEmpty(bp_blood))
                    //    {
                    //        if (bp_blood.Contains("/"))
                    //        {
                    //            if (bp_blood.Contains(","))
                    //            {
                    //                string[] bloods = bp_blood.Split(',');
                    //                if (bloods[0].Contains("/"))
                    //                    bp_blood = bloods[0];
                    //                else
                    //                    bp_blood = bloods[1];
                    //            }
                    //            string[] us_blood = bp_blood.Split('/');
                    //            dic.Add("收缩压", us_blood[0]);
                    //            dic.Add("舒张压", us_blood[1]);
                    //        }
                    //    }

                        //if (bp_blood != "")
                        //{
                        //if (!bp_blood.ToString().Contains(","))
                        //{
                        //    if(bp_blood)
                        //    string[] one = bp_blood.Split('/');//bp_blood.Substring(1, bp_blood.Length - 1).Split('/')
                        //    if (one.Length > 1)
                        //    {
                        //        dic.Add("收缩压", one[0]);
                        //        dic.Add("舒张压", one[1]);
                        //    }
                        //}
                        //else
                        //{
                        //    string[] bloodArr = bp_blood.Split(',');
                        //    if (bloodArr.Length > 0)
                        //    {
                        //        string[] bloodOne = bloodArr[0].Substring(1, bloodArr[0].Length - 1).Split('/');
                        //        if (bloodOne.Length > 1)
                        //        {
                        //            dic.Add("收缩压", bloodOne[0]);
                        //            dic.Add("舒张压", bloodOne[1]);
                        //        }
                        //    }
                        //}
                        //}
                    //}
                    return dic;
                }
                catch (System.Exception ex)
                { return dic; }
            }
            return dic;
        }

        /// <summary>
        /// 患者是否下了符合传染病的诊断
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsPatientInfection(int patient_id)
        {
            string sql = " select 1 col from t_diagnose_item a inner join t_infection_detail b on a.diagnose_code=b.diagnosis_code inner join t_infection_index c on c.infection_id=b.infection_id and c.enabled='1'  where a.patient_id=" + patient_id;
            if (App.ReadSqlVal(sql, 0, "col") == "1")
                return true;
            return false;
        }

        /// <summary>
        /// 文书的设置信息
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public static ArrayList DocSets(string Content)
        {
            try
            {
                ArrayList setnodes = new ArrayList();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(Content);
                XmlNode nodes = xmldoc.DocumentElement;

                foreach (XmlNode node in nodes.ChildNodes)
                {
                    if (node.Name.ToLower() == "docsetting")
                    {
                        setnodes.Add(node.Clone());
                    }

                    if (node.Name.ToLower() == "pagesetting")
                    {
                        setnodes.Add(node.Clone());
                    }
                }

                return setnodes;
            }
            catch
            {
                return null;
            }


        }

        #region 数字化病区
        /// <summary>
        /// 病例讨论文书的节点
        /// </summary>
        public static int discuss_text_id = 0;

        /// <summary>
        /// 文书保存
        /// </summary>
        /// <param name="editor"></param>
        public static void DiscussDocSave(frmText editor)
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            editor.MyDoc.ToXML(tempxmldoc.DocumentElement);
            if (editor.MyDoc.Us.Tid == 0)
            {
                int id = App.GenId("T_DISCUSS_DOC", "id");
                //添加操作
                String sql_clob = string.Format("insert into T_DISCUSS_DOC(id,DOC_NAME,TEXTKIND_ID,CREATE_TIME,CREATE_USER_ID,CONTENT,PATIENT_ID)values(" + id + ",'" +
                    editor.MyDoc.Us.TextName + "'," +
                    editor.MyDoc.Us.TextKind_id + ",sysdate," +
                    App.UserAccount.UserInfo.User_id + ",:doc1," +
                    editor.MyDoc.Us.InpatientInfo.Id + ")");

                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = tempxmldoc.OuterXml;
                xmlPars[0].DBType = MySqlDbType.Text;

                if (App.ExecuteSQL(sql_clob, xmlPars) > 0)
                {
                    App.Msg("操作成功！");
                }

            }
            else
            {
                //修改操作
                String sql_clob = string.Format("update T_DISCUSS_DOC set CONTENT=:doc1 where id = '{0}'", editor.MyDoc.Us.Tid);
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = tempxmldoc.OuterXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                if (App.ExecuteSQL(sql_clob, xmlPars) > 0)
                {
                    App.Msg("操作成功！");
                }
            }
        }
        #endregion


        private static
            bool pdzd(XmlElement xml)
        {
            XmlNodeList list;
            list = xml.GetElementsByTagName("input");
            if (list != null)
            {
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Attributes["name"] != null)
                        {
                            if (list[i].Attributes["name"].Value.ToString().Contains("医师签名日期"))
                            {
                                try
                                {
                                    if (list[i].Attributes["name"].InnerText != "")
                                    {
                                        return true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 根据文书节点属性判断是否可以打印文书
        /// "规培医师"书写的文书不可自行打印，只有上级医生签名后方可打印
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static bool ISPrintGPYS(int id, string content)
        {
            //string content = "";
            if (content == null || content == "")
            {
                content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + id + "", 0, "CONTENT");
            }
            if (content == null || content == "")
            {
                content = App.DownLoadFtpPatientDoc(id + ".xml", CurrentPatient.Id.ToString());
            }
            if (content == null || content == "")
            {
                return false;
            }
            XmlDocument textDocument = new XmlDocument();
            textDocument.PreserveWhitespace = true;
            textDocument.LoadXml(content);

            XmlNodeList sign = textDocument.GetElementsByTagName("input");

            string sjysqm = "";//上级医师签名
            //找到上级医生签名,存在返回true,否则返回false
            foreach (XmlNode var in sign)
            {
                if (var.Attributes["name"] != null && var.Attributes["name"].Value == "普通医师签名" &&
                    var.Attributes["id"] != null && var.Attributes["id"].Value != App.UserAccount.UserInfo.User_id)
                {
                    sjysqm = var.Attributes["id"].Value;
                    if (IsPrintLevels(sjysqm))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 判断当前用户角色级别是否小于签名人的角色级别
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <returns>true 大于,false 小于</returns>
        private static bool IsPrintLevels(string user_id)
        {
            try
            {
                //获取当期用户角色级别
                string Sql_UserInof_Teach_Post = @"select t2.user_id,t2.user_name,t4.levels from t_account_user t1 
                                                    inner join t_userinfo t2 on t1.user_id=t2.user_id
                                                    inner join t_acc_role t3 on t1.account_id=t3.account_id
                                                    inner join t_in_doc_jobtitle t4 on t3.role_id=t4.jobtitle_id
                                                    where t2.user_id=";
                //签名用户等级
                string levels1 = App.ReadSqlVal(Sql_UserInof_Teach_Post + user_id, 0, "levels");
                //当前用户等级
                string levels2 = App.ReadSqlVal(Sql_UserInof_Teach_Post + App.UserAccount.UserInfo.User_id, 0, "levels");

                bool flag = false;

                if (levels1 != "" && levels2 != "") //不等于空
                {
                    //签名用户等级
                    int Select_levels = Int32.Parse(levels1);
                    //当前用户等级
                    int Current_Levels = Int32.Parse(levels2);
                    if (Current_Levels < Select_levels)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary> 
        /// 将数据集中的数据保存到EXCEL文件 
        /// </summary> 
        /// <param name="dataSet">输入数据集</param> 
        /// <param name="fileName">保存EXCEL文件的绝对路径名</param> 
        /// <param name="isShowExcle">是否打开EXCEL文件</param> 
        /// <returns></returns> 
        public static bool DataSetToExcel(DataSet dataSet, string fileName, bool isShowExcle)
        {
            DataTable dataTable = dataSet.Tables[0];
            int rowNumber = dataTable.Rows.Count;//不包括字段名 
            int columnNumber = dataTable.Columns.Count;
            int colIndex = 0;

            if (rowNumber == 0)
            {
                return false;
            }

            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true); 
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            excel.Visible = isShowExcle;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1]; 
            Microsoft.Office.Interop.Excel.Range range;

            //生成字段名称 
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;
                excel.Cells[1, colIndex] = col.ColumnName;
            }

            object[,] objData = new object[rowNumber, columnNumber];

            for (int r = 0; r < rowNumber; r++)
            {
                for (int c = 0; c < columnNumber; c++)
                {
                    objData[r, c] = dataTable.Rows[r][c].ToString() + "\t"; //格式化 +"\t"
                }
                //Application.DoEvents(); 
            }

            // 写入Excel 

            range = worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]);
            //range.NumberFormat = "@";//设置单元格为文本格式 
            //range.Font.Size = 9;
            range.Value2 = objData;
            //worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm";
            worksheet.get_Range(excel.Cells[1, 1], excel.Cells[rowNumber + 1, columnNumber]).Font.Size = 9;

            string Version = excel.Version;//获取你使用的excel 的版本号
            int FormatNum;//保存excel文件的格式
            if (Convert.ToDouble(Version) < 12)//You use Excel 97-2003
            {
                FormatNum = -4143;
            }
            else//you use excel 2007 or later
            {
                FormatNum = 56;
            }
            workbook.SaveAs(fileName, FormatNum, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //workbook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            try
            {

                workbook.Saved = true;

                excel.UserControl = false;
                //excelapp.Quit(); 
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                workbook.Close(Microsoft.Office.Interop.Excel.XlSaveAction.xlSaveChanges, Missing.Value, Missing.Value);
                excel.Quit();
                excel = null;
                GC.Collect();//垃圾回收 
            }

            if (isShowExcle)
            {
                System.Diagnostics.Process.Start(fileName);
            }
            return true;
        }

        /// <summary>
        /// 宏元素大类
        /// </summary>
        /// <returns></returns>
        internal static List<DataEntity> GetMacrosKinds()
        {
            return new List<DataEntity>()
            {
                new DataEntity () { Id="1",Name="当前患者基本信息"},
                new DataEntity () {Id="5",Name="当前患者诊断信息" },
                new DataEntity() {Id="6",Name="当前患者体征信息" },
                new DataEntity() {Id="7",Name="当前患者其他体征信息" },
                new DataEntity () {Id="2",Name="当前用户信息" },
                new DataEntity () { Id="3",Name="当前角色信息"},
                new DataEntity () { Id="4",Name="当前时间"}
            };
        }

        /// <summary>
        /// 获取是实体类中属性的描述内容不为空的属性名及描述内容
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static List<DataEntity> GetPropertyDescription(object obj)
        {
            var res = new List<DataEntity>();
            if (obj != null)
            {
                var ps = obj.GetType().GetProperties().Cast<PropertyInfo>().Select(o => new
                {
                    Name = o.Name,
                    Desc = Attribute.GetCustomAttribute(o, typeof(DescriptionAttribute)).As<DescriptionAttribute>()
                }).Where(o => o.Desc != null && o.Desc.Description != null);
                if (ps != null && ps.Any())
                {
                    ps.ToList().ForEach(o =>
                    {
                        res.Add(new DataEntity() { Id = o.Name, Name = o.Desc.Description });
                    });
                }
            }
            return res;
        }

        /// <summary>
        /// 通过配置宏元素替换input元素的内容
        /// 根据input的name标签找到对应的宏元素替换内容
        /// </summary>
        /// <param name="bodyElement"></param>
        /// <param name="patient_id"></param>
        internal static void Filter(XmlElement bodyElement, int patient_id)
        {

            try
            {
                if (bodyElement != null && patient_id > 0)
                {
                    var xelements = bodyElement.GetElementsByTagName("input").Cast<XmlElement>().Where(o => o.HasAttribute("name")).ToList();
                    var macrosElements = EmrDAL.DbQuery.Query<T_MACROS_ELEMENTS>(o => o.Enable.Equals("1"));
                    //当前患者
                    Filter(xelements, macrosElements, "1", "select * from V_PATIENT_BASEINFO a where a.patient_id='" + patient_id + "'", false);

                    //当前用户
                    Filter(xelements, macrosElements, "2", Bifrost.App.UserAccount.UserInfo);

                    //当前角色
                    Filter(xelements, macrosElements, "3", Bifrost.App.UserAccount.CurrentSelectRole);

                    //当前时间
                    var res = from x in xelements
                              join m in macrosElements on x.Attributes["name"].Value equals m.Name
                              where m.Type.Equals("4")
                              select new
                              {
                                  X = x,
                                  M = m
                              };
                    if (res != null && res.Any())
                    {
                        var time = Bifrost.App.GetSystemTime();
                        res.ToList().ForEach(o =>
                        {

                            if (o.X.InnerText.IsNullOrEmpty() || o.M.OnlyOnNull.IsNotEmptyAndEquals("0"))
                                o.X.InnerText = time.ToString(o.M.Format);
                        });
                    }

                    //当前诊断
                    Filter(xelements, macrosElements, "5", "select a.DIAGNOSE_TYPE colname,a.DIAGNOSE_NAME colvalue from v_first_diagnose a where a.patient_id='" + patient_id + "'", true);

                    //体征信息 T、P、R等
                    Filter(xelements, macrosElements, "6", "select * from v_patient_tpr a where a.patient_id='" + patient_id + "'", false);

                    //其他体征信息BP等
                    Filter(xelements, macrosElements, "7", "select * from v_patient_other_vital a where a.patient_id='" + patient_id + "'", false);
                }
            }
            catch { }

        }

        /// <summary>
        /// 根据传入的对象的属性名与宏元素列名的对应关系替换内容
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="macros"></param>
        /// <param name="type"></param>
        /// <param name="obj">传入的对象</param>
        static void Filter(List<XmlElement> inputs, List<T_MACROS_ELEMENTS> macros, string type, object obj)
        {
            var res = from x in inputs
                      join m in macros on x.Attributes["name"].Value equals m.Name
                      where m.Type.Equals(type) && m.ColName.IsNotEmpty() && (x.InnerText.IsNullOrEmpty() || (x.InnerText.IsNotEmpty() && m.OnlyOnNull.Equals("0")))
                      select new
                      {
                          X = x,
                          M = m
                      };
            if (res != null && res.Any())
            {
                if (obj != null)
                {
                    var us = from u1 in res
                             join u2 in obj.GetType().GetProperties().Cast<PropertyInfo>() on u1.M.ColName.ToUpper() equals u2.Name.ToUpper()
                             select new
                             {
                                 U1 = u1,
                                 U2 = u2
                             };
                    if (us != null && us.Any())
                    {
                        us.ToList().ForEach(u =>
                        {
                            var obj2 = u.U2.GetValue(obj, null);
                            if (obj2 != null)
                            {
                                if (obj2 is DateTime)
                                {
                                    u.U1.X.InnerText = obj2.ToString().ParseTo<DateTime>().ToString(u.U1.M.Format);
                                }
                                else
                                {
                                    if (u.U1.M.Split.IsNotEmpty())
                                    {
                                        u.U1.X.InnerText = obj2.ToString().SplitAndSelect(u.U1.M.Split.ToArray(), u.U1.M.Select_Index);
                                    }
                                    else
                                    {
                                        u.U1.X.InnerText = obj2.ToString();
                                    }
                                }
                            }
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 根据传入的sql查询出来的数据替换
        /// 当结果为行数据时必须要有colname和colvalue两列
        /// 分别对应宏元素的colname和要替换的内容
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="macros"></param>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="rowData">结果为是否为行数据</param>
        static void Filter(List<XmlElement> inputs, List<T_MACROS_ELEMENTS> macros, string type, string sql, bool rowData)
        {
            var res = from x in inputs
                      join m in macros on x.Attributes["name"].Value equals m.Name
                      where m.Type.Equals(type) && m.ColName.IsNotEmpty() && (x.InnerText.IsNullOrEmpty() || (x.InnerText.IsNotEmpty() && m.OnlyOnNull.Equals("0")))
                      select new
                      {
                          X = x,
                          M = m
                      };
            if (res != null && res.Any())
            {
                var data = App.GetDataSet(sql);
                if (data != null && data.Tables != null && data.Tables[0].Rows.Count > 0)
                {
                    if (rowData)
                    {
                        if (data.Tables[0].Columns.Contains("ColName") && data.Tables[0].Columns.Contains("ColValue"))
                        {
                            var data2 = from r in res
                                        join d in data.Tables[0].Rows.Cast<DataRow>() on r.M.ColName.ToUpper() equals d["ColName"].ToString().ToUpper()
                                        select new
                                        {
                                            R = r,
                                            V = d["ColValue"]
                                        };
                            if (data2 != null && data2.Any())
                            {
                                data2.ToList().ForEach(p =>
                                {
                                    if (p.V != null)
                                    {
                                        if (p.V is DateTime)
                                        {
                                            p.R.X.InnerText = p.V.ToString().ParseTo<DateTime>().ToString(p.R.M.Format);
                                        }
                                        else
                                        {
                                            if (p.R.M.Split.IsNotEmpty())
                                            {
                                                p.R.X.InnerText = p.V.ToString().SplitAndSelect(p.R.M.Split.ToArray(), p.R.M.Select_Index);
                                            }
                                            else
                                            {
                                                p.R.X.InnerText = p.V.ToString();
                                            }
                                        }
                                    }
                                });
                            }
                        }
                    }
                    else
                    {
                        res = res.Where(o => data.Tables[0].Columns.Contains(o.M.ColName));
                        if (res != null && res.Any())
                        {
                            var row = data.Tables[0].Rows[0];
                            res.ToList().ForEach(p =>
                            {
                                object obj = row[p.M.ColName];
                                if (obj != null)
                                {
                                    if (obj is DateTime)
                                    {
                                        p.X.InnerText = obj.ToString().ParseTo<DateTime>().ToString(p.M.Format);
                                    }
                                    else
                                    {
                                        if (p.M.Split.IsNotEmpty())
                                        {
                                            p.X.InnerText = obj.ToString().SplitAndSelect(p.M.Split.ToArray(), p.M.Select_Index);
                                        }
                                        else
                                        {
                                            p.X.InnerText = obj.ToString();
                                        }

                                    }
                                }
                            });
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 获取数据库中表或者视图的列的描述内容
        /// </summary>
        /// <param name="objname"></param>
        /// <returns></returns>
        internal static List<DataEntity> GetObjectComments(string objname)
        {
            List<DataEntity> templists = new List<DataEntity>();
            string sql = " select a.column_name id,a.comments Name from user_col_comments a where a.table_name='" + objname.ToUpper() + "' and a.comments is not null";
            DataSet ds = App.GetDataSet(sql);

            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataEntity dataenit = new DataEntity();
                    dataenit.Id = ds.Tables[0].Rows[i]["id"].ToString();
                    dataenit.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    templists.Add(dataenit);
                }
                return templists;
            }
            return null;

            //return EmrDAL.DbQuery.Query<DataEntity>(" select a.column_name id,a.comments Name from user_col_comments a where a.table_name='" + objname.ToUpper() + "' and a.comments is not null");
        }




        /// <summary>
        /// 获取数据库中表或者视图的列的描述内容
        /// </summary>
        /// <param name="objname"></param>
        /// <returns></returns>
        //internal static List<DataEntity> GetObjectComments(string objname)
        //{
        //    return EmrDAL.DbQuery.Query<DataEntity>(" select a.column_name id,a.comments Name from user_col_comments a where a.table_name='" + objname.ToUpper() + "' and a.comments is not null");
        //}

        /// <summary>
        /// 刷新编辑器中诊断内容
        /// </summary>
        /// <param name="text">编辑器</param>
        public static void RefreshDocDiagnose(frmText text, int Reftype)
        {
            try
            {
                ArrayList arrlist = new ArrayList();
                text.MyDoc.DiagnoseDiv(text.MyDoc.DocumentElement, arrlist);
                if (arrlist != null)
                {//获取到编辑器中div
                    //删除之前的
                    if (text.MyDoc.Us.Tid != 0 && Reftype == 2)
                    {
                        App.ExecuteSQL("delete from t_text_diag where tid=" + text.MyDoc.Us.Tid);
                    }
                    DateTime sysTime = App.GetSystemTime();
                    foreach (ZYTextElement element in arrlist)
                    {
                        if (element is ZYTextDiv)
                        {
                            ZYTextDiv div = (ZYTextDiv)element;
                            string divtitle = div.Title != null ? div.Title.Trim() : "";
                            string type = string.Empty;
                            string title = string.Empty;
                            DataInit.getDivtitle(divtitle, ref title, ref type);
                            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(title))
                            {//加载最新诊断内容到对应div
                                string divname = div.Name != null ? div.Name.Trim() : "";
                                div.ChildElements.Clear();
                                div.CanDelete = false;
                                bool EnableTime = true;
                                string TimeName = "日期:";
                                if (title == "初步诊断" || title == "确定诊断" || title == "修正诊断" || title == "补充诊断")
                                {//除“初步、确定、修正、补充”诊断以外，文书中加载"签名日期"
                                    if (title == "确定诊断")
                                    {
                                        EnableTime = false;
                                        TimeName = "";
                                    }
                                    else
                                    {
                                        TimeName = title.Replace("诊断", "日期:");
                                        if (title == "确定诊断")
                                            TimeName = TimeName.Replace("确定", "确诊");
                                    }
                                }
                                //List<ZYTextElement> myList = Base_Function.BLL_DIAGNOSE.DiagnoseAction.GetDiagnoseToElement(text.MyDoc, type, title, divname, text.MyDoc.Us.InpatientInfo.Id.ToString(), EnableTime, TimeName);
                                string Diagnose = Base_Function.BLL_DIAGNOSE.DiagnoseAction.GetDiagnoseToStr(text.MyDoc, type, title, divname, text.MyDoc.Us.InpatientInfo.Id.ToString(), EnableTime, TimeName);

                                XmlDocument xmlDocument = new XmlDocument();
                                xmlDocument.PreserveWhitespace = true;
                                StringBuilder strb = new StringBuilder();
                                strb.Append("<emrtextdocument2005>");
                                strb.Append(Diagnose);
                                strb.Append("</emrtextdocument2005>");
                                //List<ZYTextElement> myList = new List<ZYTextElement>();
                                ArrayList myList = new ArrayList();
                                xmlDocument.LoadXml(strb.ToString());
                                text.MyDoc.LoadElementsToList(xmlDocument.DocumentElement, myList);

                                foreach (ZYTextElement elementE in myList)
                                {
                                    elementE.Parent = div; //div
                                    elementE.OwnerDocument = text.MyDoc;
                                    elementE.DeleterIndex = -1;
                                    elementE.CreatorIndex = text.MyDoc.SaveLogs.CurrentIndex;
                                    elementE.RefreshSize();
                                }
                                div.ChildElements.InsertRange(0, myList);
                                div.CanDelete = true;

                                if (text.MyDoc.Us.Tid != 0 && Reftype == 2)
                                {//不是新建时并且是点击刷新诊断按钮,才进入
                                    string insertDiagnose = string.Format(@"insert into t_text_diag
																  (ID,
																   TID,
																   DIAG_TYPE,
																   PATIENT_ID,
																   IS_SUBMIT,
																   REFRESH_ID,
																   REFRESH_TIME,
																   DIAG_XML)
																values
																  ({0},
																   {1},
																   '{2}',
																   '{3}',
																   '{4}',
																   '{5}',
																   sysdate,
																   :doc)", App.GenId(), text.MyDoc.Us.Tid, type, text.MyDoc.Us.InpatientInfo.Id, "Y", App.UserAccount.UserInfo.User_id);
                                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                                    xmlPars[0] = new MySqlDBParameter();
                                    xmlPars[0].ParameterName = "doc";
                                    xmlPars[0].Value = Diagnose;
                                    xmlPars[0].DBType = MySqlDbType.Text;
                                    App.ExecuteSQL(insertDiagnose, xmlPars);
                                }
                            }
                        }
                    }
                    text.MyDoc.RefreshSize();//刷新
                    text.MyDoc.ContentChanged();
                }
            }
            catch (System.Exception ex)
            {
                App.Msg("提示: 刷新诊断失败!");
            }
        }

        /// <summary>
        /// 获取三级医师等级
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static int GetThreeLevel(InPatientInfo entity, string user_id)
        {
            int level = 0;

            if (user_id == entity.Chief_Doctor_Id.ToString())
            {
                level = 3;
            }
            else if (user_id == entity.Charge_Doctor_Id.ToString())
            {
                level = 2;
            }
            else if (user_id == entity.Resident_Doctor_Id.ToString())
            {
                level = 1;
            }
            else
            {
                level = 0;
            }

            return level;
        }
        /// <summary>
        /// 获取对应诊断
        /// </summary>
        /// <param name="divtitle">文本块title</param>
        /// <param name="title">诊断类型名称</param>
        /// <param name="type">诊断类型ID</param>
        public static void getDivtitle(string divtitle, ref string title, ref string type)
        {
            title = "";
            type = "";
            if (divtitle.Contains("术前诊断"))
            {
                type = "401";
                title = "术前诊断";
            }
            else if (divtitle.Contains("术后诊断"))
            {
                type = "402";
                title = "术后诊断";
            }
            else if (divtitle.Contains("初步诊断"))
            {
                type = "403";
                title = "初步诊断";
            }
            else if (divtitle.Contains("补充诊断"))
            {
                type = "404";
                title = "补充诊断";
            }
            else if (divtitle.Contains("修正诊断"))
            {
                type = "405";
                title = "修正诊断";
            }
            else if (divtitle.Contains("出院诊断"))
            {
                type = "406";
                title = "出院诊断";
            }
            else if (divtitle.Contains("死亡诊断"))
            {
                type = "407";
                title = "死亡诊断";
            }
            else if (divtitle.Contains("入院诊断"))
            {
                type = "408";
                title = "入院诊断";
            }
            else if (divtitle.Contains("确定诊断"))
            {
                type = "7923";
                title = "确定诊断";
            }
            else if (divtitle.Contains("术中诊断"))
            {
                type = "8603";
                title = "术中诊断";
            }
            else if (divtitle.Contains("转出诊断"))
            {
                type = "8604";
                title = "转出诊断";
            }
            else if (divtitle.Contains("转入诊断"))
            {
                type = "8605";
                title = "转入诊断";
            }
            else if (divtitle.Contains("门诊诊断"))
            {
                type = "7593865";
                title = "门诊诊断";
            }
        }
        /// <summary>
        /// 设置TableLayoutPanel激活双缓存
        /// </summary>
        /// <param name="tableLayoutPanel1"></param>
        /// <param name="doubleBuffered"></param>
        public static void SetDoubleBuffered(TableLayoutPanel tableLayoutPanel1, bool doubleBuffered)
        {
            tableLayoutPanel1
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(tableLayoutPanel1, doubleBuffered, null);
        }

        /// <summary>
        /// 文书节点排序
        /// </summary>
        /// <param name="sortRows"></param>
        /// <returns></returns>
        public static DataRow[] ReSort(DataRow[] sortRows)
        {
            //重新排序
            for (int i = 0; i < sortRows.Length - 1; i++)
            {
                for (int j = 0; j < sortRows.Length - i - 1; j++)
                {
                    if (App.UserAccount.CurrentSelectRole.Role_type == "N")     //当前角色为护士时 护理文书自动置顶
                    {
                        if (Convert.ToInt32(sortRows[j]["TEXT_ID"]) == 110)     //护理记录
                        {
                            sortRows[j]["shownum"] = -2;
                        }
                        if (Convert.ToInt32(sortRows[j]["TEXT_ID"]) == 6973623) //护理评估表
                        {
                            sortRows[j]["shownum"] = -1;
                        }

                        if (Convert.ToInt32(sortRows[j]["shownum"]) > Convert.ToInt32(sortRows[j + 1]["shownum"]))
                        {
                            DataRow empty = sortRows[j];
                            sortRows[j] = sortRows[j + 1];
                            sortRows[j + 1] = empty;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(sortRows[j]["shownum"]) > Convert.ToInt32(sortRows[j + 1]["shownum"]))
                        {
                            DataRow empty = sortRows[j];
                            sortRows[j] = sortRows[j + 1];
                            sortRows[j + 1] = empty;
                        }
                    }
                }
            }

            return sortRows;
        }

        /// <summary>
        /// 根据排序类型获取排序信息
        /// </summary>
        /// <param name="SortType"></param>
        /// <returns></returns>
        public static DataTable GetTextSortSet(string SortType)
        {
            string sqlSort = "select * from t_text_sort where sort_type=" + SortType + "";
            DataTable TableSort = App.GetDataSet(sqlSort).Tables[0]; //获取该类型所有的排序信息
            return TableSort;
        }

        public static DataTable GetTextSortSet(string SortType, string patientid)
        {
            string sqlSort = "select TEXT_ID,SORT_TYPE,PARENT_ID,SHOWNUM from t_text_sort where sort_type=" + SortType + " union all select distinct textkind_id TEXT_ID,1 SORT_TYPE,525 PARENT_ID,0 SHOWNUM from t_patients_doc b where textname like '%知情同意书' and patient_id='" + patientid + "'";
            DataTable TableSort = App.GetDataSet(sqlSort).Tables[0]; //获取该类型所有的排序信息
            return TableSort;
        }

        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        public static void SetTreeView(Class_Text[] Directionarys, Node current, DataTable TableSort)
        {
            TableSort.DefaultView.Sort = "shownum asc";
            Class_Text cunrrentDir = (Class_Text)current.Tag;
            DataRow[] sorttemprows = TableSort.Select("parent_id=" + cunrrentDir.Id.ToString() + "");
            DataRow[] sortrows = DataInit.ReSort(sorttemprows);
            if (sortrows.Length > 0)
            {
                //有排序信息
                for (int k = 0; k < sortrows.Length; k++)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        if (Directionarys[i].Id.ToString() == sortrows[k]["text_id"].ToString())
                        {
                            //有匹配情况出现
                            if (Directionarys[i].Parentid == cunrrentDir.Id)
                            {
                                Node tn = new Node();
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                                tn.Name = Directionarys[i].Id.ToString();
                                if (Directionarys[i].Issimpleinstance == "0")   //是单例文书
                                {
                                    tn.Image = global::Base_Function.Resource.单例文书;
                                }
                                else
                                {
                                    tn.Image = global::Base_Function.Resource.多例文书;
                                }
                                current.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn, TableSort);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                //无排序信息
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (Directionarys[i].Parentid == cunrrentDir.Id)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        if (Directionarys[i].Issimpleinstance == "0")   //是单例文书
                        {
                            tn.Image = global::Base_Function.Resource.单例文书;
                        }
                        else
                        {
                            tn.Image = global::Base_Function.Resource.多例文书;
                        }
                        current.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn, TableSort);
                    }
                }
            }
        }

        /// <summary>
        ///  显示文书(去除病程子节点)
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(AdvTree trvBook, bool flag)
        {
            string sq_section = CurrentPatient.Section_Id.ToString();

            //if (CurrentPatient.PatientState == "授权")
            //{
            //    if (App.UserAccount.CurrentSelectRole.Section_Id == "")
            //    {
            //        sq_section = App.ReadSqlVal("select sid from t_section_area where said='" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "'", 0, "sid");
            //    }
            //    else
            //    {
            //        sq_section = App.UserAccount.CurrentSelectRole.Section_Id;
            //    }
            //}
            trvBook.Nodes.Clear();
            //查出所有文书
            //string SQl = "select id,textname,textcode,isenable,isbelongtotype,(case when  instr(textname,'知情同意书')>0 then 525 else PARENTID end) as PARENTID,issimpleinstance,enable_flag,shownum,sid,ishighersign,right_range,ishavetime,formname,iscommon,printorder,isnewpage,issubmitsign,isneedsign,other_textname,pyjm,isproblem_name,isproblem_time,istempsavesign from T_TEXT where enable_flag='Y' and parentid!=103 and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') and (sid='0' or instr(sid,'" + sq_section + ",')=1 or instr(sid,'," + sq_section + ",')>0) order by shownum asc";
            string SQl = "select * from T_TEXT where enable_flag='Y' and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') order by shownum asc";

            if (flag)
            {
                //已完成文书树刷新
                //SQl = "select id,textname,textcode,isenable,isbelongtotype,(case when  instr(textname,'知情同意书')>0 then 525 else PARENTID end) as PARENTID,issimpleinstance,enable_flag,shownum,sid,ishighersign,right_range,ishavetime,formname,iscommon,printorder,isnewpage,issubmitsign,isneedsign,other_textname,pyjm,isproblem_name,isproblem_time,istempsavesign from T_TEXT where enable_flag='Y' and parentid!=103 and (sid='0' or instr(sid,'" + sq_section + ",')=1 or instr(sid,'," + sq_section + ",')>0) order by shownum asc";

                SQl = " select* from (select * from T_TEXT where enable_flag = 'Y' and parentid != 103 and instr(sid, '" + App.UserAccount.CurrentSelectRole.Section_Id.ToString() + "') > 0 " +
                     "union all " +
                     "select * from T_TEXT where enable_flag = 'Y' and parentid != 103 and(sid is null or sid = '0') ) order by shownum asc";


                //SQl = "select * from T_TEXT where enable_flag='Y' and parentid!=103 order by shownum asc";

            }

            //找出文书所有类别
            //string Sql_Category = "select * from t_data_code where type=31 and enable='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);

            DataTable TableSort = DataInit.GetTextSortSet(DataInit.SortTypeId);//App.GetDataSet(sqlSort).Tables[0]; //获取该类型所有的排序信息
            DataRow[] toptempRows = TableSort.Select("parent_id=0"); //获取顶级节点
            DataRow[] topRows = DataInit.ReSort(toptempRows);               //顶级节点排序

            ////得到文书的类型
            //DataSet ds_category = App.GetDataSet(Sql_Category);
            //Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (Directionarys != null)
            {
                if (topRows.Length > 0)
                {
                    //有排序
                    for (int k = 0; k < topRows.Length; k++)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            if (topRows[k]["text_id"].ToString() == Directionarys[i].Id.ToString())
                            {
                                Node tn = new Node();
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                                tn.Name = Directionarys[i].Id.ToString();
                                //插入顶级节点
                                if (Directionarys[i].Parentid == 0)
                                {
                                    tn.Image = global::Base_Function.Resource.住院记录;
                                    trvBook.Nodes.Add(tn);
                                    SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            tn.Image = global::Base_Function.Resource.住院记录;
                            trvBook.Nodes.Add(tn);
                            SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 隐藏多余的节点
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="table_patientDoc"></param>
        /// <param name="table_bcs"></param>
        public static void removeNode(NodeCollection nodes, DataTable table_patientDoc, DataTable table_bcs)
        {
            DataRow[] docrows = table_patientDoc.Select("textname not like '%知情同意书'");
            //bool flag = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                Class_Text textTemp = (Class_Text)nodes[i].Tag;

                if (nodes[i].Nodes.Count == 0 && textTemp.Isenable == "0")
                {
                    if (!removeNullNode(textTemp, docrows, table_bcs))
                    {
                        nodes.Remove(nodes[i]);//移除空节点
                        removeNode(nodes, table_patientDoc, table_bcs); //继续移除节点
                    }
                }
                else
                {
                    //nodes.Remove(nodes[i]);
                    removeNode(nodes[i].Nodes, table_patientDoc, table_bcs);//小节点移除空节点
                    if (nodes[i].Nodes.Count == 0 && textTemp.Isenable == "0")
                    {
                        if (!removeNullNode(textTemp, docrows, table_bcs))
                        {
                            nodes.Remove(nodes[i]);//移除空节点
                            removeNode(nodes, table_patientDoc, table_bcs); //继续下一个节点
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 判断当前编辑器文书是否书写
        /// </summary>
        /// <param name="textTemp"></param>
        /// <param name="docrows"></param>
        /// <param name="table_bcs"></param>
        /// <returns></returns>
        public static bool removeNullNode(Class_Text textTemp, DataRow[] docrows, DataTable table_bcs)
        {
            bool flag = false;
            if (textTemp.Id == 103)
            {
                //病程判断
                for (int j = 0; j < docrows.Length; j++)
                {
                    DataRow[] bcrows = table_bcs.Select("id=" + docrows[j]["textkind_id"].ToString());
                    if (bcrows.Length > 0)
                    {
                        //说明有值
                        flag = true;
                        break;
                    }
                }
            } 
            if (textTemp.Id == 525)
            {
                flag = true;
       
            }
            else
            {
                //页节点
                if (textTemp.Issimpleinstance == "1")
                {
                    //多例文书

                    for (int j = 0; j < docrows.Length; j++)
                    {
                        if (docrows[j]["textkind_id"].ToString() == textTemp.Id.ToString())
                        {
                           flag = true; 
                            break;
                        }
                    }
                }
                else
                {
                    //单例文书
                    for (int j = 0; j < docrows.Length; j++)
                    {
                        if (docrows[j]["textkind_id"].ToString() == textTemp.Id.ToString())
                        {
                           flag = true;
                            break;
                        }
                    }
                }

            }

            return flag;
        }

        /// <summary>
        /// 隐藏多余的节点(护理记录)
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="table_patientDoc"></param>
        /// <param name="table_bcs"></param>
        public static void removeNodeCareDoc(NodeCollection nodes, DataTable table_patientDoc, DataTable table_temperatureDoc)
        {
            DataRow[] docrows = table_patientDoc.Select();
            bool flag = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                Class_Text textTemp = (Class_Text)nodes[i].Tag;

                if (nodes[i].Nodes.Count == 0 && textTemp.Isenable == "1" && textTemp.Parentid == 110)
                {
                    flag = false;

                    if (textTemp.Textname == "体温记录")
                    {
                        //if (table_temperatureDoc.Rows.Count != 0)
                        //{//正常显示
                        if (!CurrentPatient.PId.Contains("_"))
                        {
                            flag = true;
                        }
                        //}
                    }
                    else if (textTemp.Textname == "新生儿体温单")
                    {
                        if (CurrentPatient.PId.Contains("_") || (App.UserAccount.CurrentSelectRole.Section_Id == "8578992" || App.UserAccount.CurrentSelectRole.Sickarea_Id == "8579000"))
                        {
                            flag = true;
                        }
                    }
                    else if (textTemp.Textname == "产程图")
                    {
                        string sql = "select count(*) c from t_partogram where patient_id=" + CurrentPatient.Id.ToString();
                        if (App.ReadSqlVal(sql, 0, "c") != "0")
                        {//正常显示
                            flag = true;
                        }
                    }
                    else
                    {
                        //单例文书
                        for (int j = 0; j < docrows.Length; j++)
                        {
                            if (docrows[j]["textkind_id"].ToString() == textTemp.Id.ToString())
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag && textTemp.Textname != "产程图")
                    {
                        nodes.Remove(nodes[i]);
                        removeNodeCareDoc(nodes, table_patientDoc, table_temperatureDoc); //继续移除节点
                    }
                }
                else
                {
                    if (textTemp.Textname == "护理记录")
                    {
                        removeNodeCareDoc(nodes[i].Nodes, table_patientDoc, table_temperatureDoc);
                    }
                }

               
            }
        }

        /// <summary>
        ///刷所有的已完成的节点
        /// </summary>
        /// <param name="table_patientsdoc"></param>
        public static void getFinishedText(NodeCollection nodes, DataTable table_patientsdoc, DataTable table_bcs)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count == 0)
                {
                    //页节点
                    Class_Text tempText = (Class_Text)nodes[i].Tag;
                    
                    if (tempText.Id == 103)
                    {
                        //病程记录的处理
                        GetPatientsDocByTextId(nodes[i], table_patientsdoc, table_bcs);
                    }
                    else
                    {
                        if (tempText.Issimpleinstance == "1" && tempText.Parentid != 47555200)  //|| tempText.Issimpleinstance == "0"
                        {
                            //非病程记录 多例(正常逻辑)
                            GetPatientsDocByTextId(nodes[i], table_patientsdoc, null);
                        }
                        else
                        {
                            //非病程记录 单例(正常逻辑)
                            var item = table_patientsdoc.Rows.Cast<DataRow>().ToList().FirstOrDefault(o => o["textkind_id"].ToString() == tempText.Id.ToString());
                            if (item != null)
                            {
                                string docName = (item as DataRow)["doc_name"].ToString();
                                string textName = (item as DataRow)["textname"].ToString();
                                string Createname = (item as DataRow)["user_name"].ToString();
                                string Operateid = (item as DataRow)["OPERATEID"].ToString();//操作员
                                string TwoDoctor = (item as DataRow)["CHARGE_DOCTOR_ID"].ToString();//二级
                                string ThreeDoctor = (item as DataRow)["CHIEF_DOCTOR_ID"].ToString();//三级

                                string titleName = "";
                                docName = docName.Substring(5, 11);
                                //if (Operateid != null && TwoDoctor == "0" && ThreeDoctor == "0")
                                //{
                                //    titleName = docName + " " + textName + "(已签)" + Createname;
                                //    nodes[i].Image = global::Base_Function.Resource.一级审签;
                                //}
                                //if (Operateid != null && TwoDoctor != "0" && ThreeDoctor == "0")
                                //{
                                //    titleName = docName + " " + textName + "(上级已签)" + Createname;
                                //    nodes[i].Image = global::Base_Function.Resource.二级审签过文书;
                                //}
                                //if (Operateid != null && TwoDoctor == "0" && ThreeDoctor != "0")
                                //{
                                //    titleName = docName + " " + textName + "(主任已签)" + Createname;
                                //    nodes[i].Image = global::Base_Function.Resource.三级审签;
                                //}
                                //if (Operateid != null && TwoDoctor != "0" && ThreeDoctor != "0")
                                //{
                                //    titleName = docName + " " + textName + "(主任已签)" + Createname;
                                //    nodes[i].Image = global::Base_Function.Resource.三级审签;
                                //}
                                if ((item as DataRow)["submitted"].ToString() == "N")
                                {
                                    titleName = docName + " " + textName + "(未签)" + Createname;
                                    nodes[i].Image = global::Base_Function.Resource.子文书;
                                }
                                else
                                {
                                    titleName = docName + " " + textName + "(已签)" + Createname;
                                    nodes[i].Image = global::Base_Function.Resource.一级审签;
                                }
                                //附属账号验证:根据当前操作文书用户是否存在带教医生判断
                                //if (!string.IsNullOrEmpty((item as DataRow)["GUID_DOCTOR_ID"].ToString()))
                                //{
                                //    DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
                                //    elementStyle.TextColor = System.Drawing.Color.Orange;
                                //    //if ((item as DataRow)["submitted"].ToString() == "N")
                                //    //    elementStyle.TextColor = System.Drawing.Color.Orange;
                                //    //else if ((item as DataRow)["submitted"].ToString() == "Y")
                                //    //    elementStyle.TextColor = System.Drawing.Color.Gold;
                                //    nodes[i].Style = elementStyle;
                                //}
                                nodes[i].Text = titleName;
                            }

                            //SetForeColor(nodes[i], table_patientsdoc);
                        }
                    }

                }
                else
                {
                     getFinishedText(nodes[i].Nodes, table_patientsdoc, table_bcs);
                }
            }
        }



        public static void OpenPatientPath(int patient_id)
        {
            try
            {
                string classname = "DataInit";
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(o => o.GetName().Name == "EmrClinicPath");
                if (assembly == null)
                    assembly = Assembly.Load("EmrClinicPath");
                Type type = assembly.GetExportedTypes().ToList().FirstOrDefault(o => o.Name

 == classname);
                object item = assembly.CreateInstance(type.FullName);
                var method = type.GetMethod("OpenPatientPath");
                if (item != null && method != null)
                {
                    List<object> parameters = new List<object>();
                    parameters.Add(patient_id);
                    method.Invoke(item, parameters.ToArray());
                }
            }
            catch { }
        }
        /// <summary>
        /// 根据文书ID获取所有已写文书
        /// </summary>
        /// <param name="textid"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static void GetPatientsDocByTextId(Node textNode, DataTable table_patientDoc, DataTable table_bcs)
        {
            //只针对于多例文书
            Class_Text nodetemp = (Class_Text)textNode.Tag;
            DataRow[] rows = table_patientDoc.Select(); //获取所有该节点的已写文书

            for (int i = 0; i < rows.Length; i++)
            {
                if (nodetemp.Id == 103)//nodetemp.Id == 103 || nodetemp.Id == 525)
                {
                    //病程记录处理
                    for (int j = 0; j < table_bcs.Rows.Count; j++)
                    {
                        if (table_bcs.Rows[j]["id"].ToString() == rows[i]["textkind_id"].ToString())
                            SetPatientDocNode(rows[i], textNode);
                    }
                }
                else if (nodetemp.Id == 525  && rows[i][6].ToString().Contains("知情同意书"))
                {
                    //病程记录处理

                    //if (table_bcs.Rows[j]["id"].ToString() == rows[i]["textkind_id"].ToString())
                            SetPatientDocNode(rows[i], textNode);

                }
                else
                {
                    if (nodetemp.Id.ToString() == rows[i]["textkind_id"].ToString())
                    {
                        //非病程记录出来
                        SetPatientDocNode(rows[i], textNode);
                    }

                }
            }
        }


        /// <summary> 
        /// 获取科室或者全院医师
        /// </summary>
        /// <param name="section_id">科室id 为null是为全院医生</param>
        /// <param name="isAll">true 科室所有医生 fasle 科室所有有效医生</param>
        /// <returns></returns>
        public static DataTable GetSectionDoctor(string section_id, bool isAll)
        {
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a inner join t_account_user b on a.user_id=b.user_id inner join t_account c on b.account_id = c.account_id inner join t_acc_role d on d.account_id = c.account_id inner join t_role e on e.role_id = d.role_id inner join t_acc_role_range f on d.id = f.acc_role_id where 1=1";
            if (!string.IsNullOrEmpty(section_id))
                Sql += " and f.section_id='" + section_id + "'";
            Sql += " and  e.role_type='D' and a.Profession_Card='true'";
            if (isAll == false)
                Sql += " and a.enable='Y'";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            return table;
        }

        private static void SetPatientDocNode(DataRow row, Node textNode)
        {
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
            pDoc.Createname = row["user_name"].ToString();
            pDoc.Highersignuserid = row["highersignuserid"].ToString();
            pDoc.Isreplacehighdoctor = row["israplacehightdoctor"].ToString();
            pDoc.Isreplacehighdoctor2 = row["israplacehightdoctor2"].ToString();
            pDoc.Section_name = row["SECTION_NAME"].ToString();
            pDoc.Operateid = row["Operateid"].ToString();
            pDoc.Charge_doctor_id = row["Charge_doctor_id"].ToString();
            pDoc.Chief_doctor_id = row["Chief_doctor_id"].ToString();
            pDoc.Bed = row["bed_no"].ToString();
            pDoc.Isproblem_name = row["Isproblem_name"].ToString();
            pDoc.Isproblem_time = row["Isproblem_time"].ToString();
          //  pDoc.Isnewpage = row["ISNEWPAGE"].ToString() == "Y"?"Y":"N";


            Node tempnode = new Node();
            string sc = pDoc.Docname;

            string dv = "";
            int i = 0, length = 5;
            sc = sc.Remove(i, length);
            dv = sc;
            int j = 11, lenght = 2;
            if (dv.Length > 14)
                dv = dv.Remove(j, lenght);
            else
                dv += " "; 

            //if (pDoc.Operateid != null && pDoc.Charge_doctor_id == "0" && pDoc.Chief_doctor_id == "0")
            //{
            //    tempnode.Text = dv + "(已签)" + pDoc.Createname;
            //    tempnode.Image = global::Base_Function.Resource.一级审签;
            //}
            //if (pDoc.Operateid != null && pDoc.Charge_doctor_id != "0" && pDoc.Chief_doctor_id == "0")
            //{
            //    tempnode.Text = dv + "(上级已签)" + pDoc.Createname;
            //    tempnode.Image = global::Base_Function.Resource.二级审签过文书;
            //}
            //if (pDoc.Operateid != null && pDoc.Charge_doctor_id == "0" && pDoc.Chief_doctor_id != "0")
            //{
            //    tempnode.Text = dv + "(主任已签)" + pDoc.Createname;
            //    tempnode.Image = global::Base_Function.Resource.三级审签;
            //}
            //if (pDoc.Operateid != null && pDoc.Charge_doctor_id != "0" && pDoc.Chief_doctor_id != "0")
            //{
            //    tempnode.Text = dv + "(主任已签)" + pDoc.Createname;
            //    tempnode.Image = global::Base_Function.Resource.三级审签;
            //}
            //if (pDoc.Submitted != "Y")
            //{
            //    if (tempnode.Style == null)
            //    {
            //        tempnode.Style = new ElementStyle();
            //    }
            //    tempnode.Style.TextColor = Color.Blue;
            //}
            if (pDoc.Submitted == "N")
            {
                tempnode.Text = dv + "(未签)" + pDoc.Createname;
                tempnode.Image = global::Base_Function.Resource.子文书;
            }
            else
            {
                tempnode.Text = dv + "(已签)" + pDoc.Createname;
                tempnode.Image = global::Base_Function.Resource.一级审签;
            }
            ////附属账号验证:根据当前操作文书用户是否存在带教医生判断
            //if (!string.IsNullOrEmpty(row["GUID_DOCTOR_ID"].ToString()))
            //{
            //    DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
            //    elementStyle.TextColor = System.Drawing.Color.Orange;
            //    //if (pDoc.Submitted == "N")
            //    //    elementStyle.TextColor = System.Drawing.Color.Orange;
            //    //else if (pDoc.Submitted == "Y")
            //    //    elementStyle.TextColor = System.Drawing.Color.Gold;
            //    tempnode.Style = elementStyle;
            //}
            tempnode.Tag = pDoc as object;
            tempnode.Name = pDoc.Id.ToString();
            tempnode.ImageIndex = 28;
            textNode.Nodes.Add(tempnode);
        }

        public static void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXCEL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                //MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 文书是否已经提交
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static bool IsDocSubmitted(int tid)
        {
            try
            {
                if (tid > 0)
                {
                    string col = App.ReadSqlVal("select 1 col from t_patients_doc a where a.tid='" + tid.ToString() + "' and a.submitted='Y'", 0, "col");
                    if (string.IsNullOrEmpty(col))
                        return false;
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        /// <summary>
        /// 获取当前病人所对应的排序类型
        /// </summary>
        /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        public static void GetPatientType(string patient_id)
        {
            try
            {
                
                string sql = "select b.action_type from t_inhospital_action b where b.patient_id=" + patient_id + " order by id desc";
                DataSet ds_patient_state = App.GetDataSet(sql);
                DataTable settable = App.GetDataSet("select * from T_TEXT_PATIENTSTATE_SORT").Tables[0]; //获取病人类型和文书排序的关系设置
                DataInit.SortTypeId = "1";
                if (ds_patient_state.Tables[0].Rows.Count > 0)
                {
                    //未归档
                    string state = ds_patient_state.Tables[0].Rows[0]["action_type"].ToString();
                    if (state == "出区")
                    {
                        //出院病人
                        DataInit.SortTypeId = settable.Select("patientid=2")[0]["sorttype"].ToString();
                    }
                    else
                    {
                        //在医病人
                        DataInit.SortTypeId = settable.Select("patientid=1")[0]["sorttype"].ToString();
                    }
                }
                else
                {
                    //已归档
                    DataInit.SortTypeId = settable.Select("patientid=3")[0]["sorttype"].ToString();
                }
            }
            catch
            {
                DataInit.SortTypeId = "1";
            }
        }

        public static void Watermark(int x, int y, Graphics g)
        {
            Color color = Color.FromArgb(50, Color.Gray);
            Font font = new Font("Verdana", 32);
            using (Brush brush = new SolidBrush(color))
            {
                for (int i = 0; i < 10; i++)
                {
                    g.DrawString("草 稿", font, brush, x + i * 75, y + i * 120);
                }
                font.Dispose();
            }
        }

        /// <summary>
        /// 获取加密后的水印信息
        /// </summary>
        /// <param name="pid">住院号</param>
        /// <param name="pName">患者姓名</param>
        /// <param name="account">工号</param>
        /// <returns></returns>
        public static string GetEncryptWaterMark(string pid, string account)
        {
            string timeStr = DateTime.Now.ToString("yyyy-MM-dd");
            string ip = App.GetHostIp();
            string temp = timeStr + "|" + ip + "|" + pid + "|" + account;

            return EncryptDES(temp, "12345678");
        }

        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        private static string EncryptDES(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static string DecryptDES(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }


        /// <summary>
        /// 关键字比对-主诉和诊断
        /// 0:两项未匹配到; 1:匹配两项成功; 2:匹配一项成功
        /// </summary>
        public static int Keyword_matching(XmlDocument tempxmldoc)
        {
            try
            {
                int type = 0;
                XmlNodeList nodeList_key = tempxmldoc.GetElementsByTagName("input");
                string complaint = string.Empty;
                string diagnoses = string.Empty;
                foreach (XmlNode childNode in nodeList_key)
                {//获取当前提交文书中主诉内容
                    if (childNode.Attributes["name"] != null && childNode.Attributes["name"].Value == "主诉")
                    {
                        complaint = childNode.InnerText;
                        break;
                    }
                }
                string sql_diagnose_item = "select id,DIAGNOSE_NAME from t_diagnose_item where patient_id='{0}'";
                string sql_trend_diagnose = "select id,TREND_DIAGNOSE_NAME from t_trend_diagnose where parent_id = '{0}'";
                //查询诊断
                DataTable DiagnoseTable = App.GetDataSet(string.Format(sql_diagnose_item, CurrentFrmText.MyDoc.Us.InpatientInfo.Id)).Tables[0];

                if (DiagnoseTable != null && DiagnoseTable.Rows.Count > 0)
                {
                    foreach (DataRow row in DiagnoseTable.Rows)
                    {
                        diagnoses += "+" + row["diagnose_name"].ToString();
                        diagnoses += SelTrendDiagnose(row["id"].ToString(), sql_trend_diagnose);
                    }
                }

                if (complaint != "" || diagnoses != "")
                {
                    string sql = @"select distinct t.key_complaint 主诉关键字,t.key_diagnose 诊断关键字 from T_KEY_WORDS t";
                    DataSet ds = App.GetDataSet(sql);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow[] rows = ds.Tables[0].Select();
                            for (int i = 0; i < rows.Length; i++)
                            {
                                bool blcomplaint = false;
                                bool bldiagnoses = false;
                                string KEY_ZS = rows[i]["主诉关键字"].ToString();
                                string KEY_ZD = rows[i]["诊断关键字"].ToString();
                                if (complaint.IndexOf(KEY_ZS) != -1)
                                    blcomplaint = true;
                                if (diagnoses.IndexOf(KEY_ZD) != -1)
                                    bldiagnoses = true;
                                if (blcomplaint && bldiagnoses)
                                    return 1;//双项匹配直接返回
                                else if (blcomplaint || bldiagnoses)
                                    type = 2;//单项匹配到记录状态
                            }
                        }
                    }
                }
                //else if (complaint != "" || diagnoses != "")
                //{
                //    type = 2;
                //}

                return type;

            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询附属诊断
        /// </summary>
        /// <param name="parent_id"></param>
        /// <param name="sql_trend_diagnose"></param>
        /// <returns></returns>
        public static string SelTrendDiagnose(string parent_id, string sql_trend_diagnose)
        {
            string strTrendDiagnose = "";
            DataTable trendDiagnose = App.GetDataSet(string.Format(sql_trend_diagnose, parent_id)).Tables[0];
            if (trendDiagnose != null && trendDiagnose.Rows.Count > 0)
            {
                foreach (DataRow row in trendDiagnose.Rows)
                {
                    strTrendDiagnose += "+" + row["trend_diagnose_name"].ToString();
                    strTrendDiagnose += SelTrendDiagnose(row["id"].ToString(), sql_trend_diagnose);
                }
            }
            return strTrendDiagnose;
        }

        public static void MatchPath(int patient_id, string diagnose_code, string diagnose_name, string diagnose_type)
        {
            try
            {
                string classname = "DataInit";
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(o => o.GetName().Name == "EmrClinicPath");
                if (assembly == null)
                    assembly = Assembly.Load("EmrClinicPath");
                Type type = assembly.GetExportedTypes().ToList().FirstOrDefault(o => o.Name

 == classname);
                object item = assembly.CreateInstance(type.FullName);
                var method = type.GetMethod("MatchPath");
                if (item != null && method != null)
                {
                    List<object> parameters = new List<object>();
                    parameters.Add(patient_id);
                    parameters.Add(diagnose_code);
                    parameters.Add(diagnose_name);
                    parameters.Add(diagnose_type);
                    method.Invoke(item, parameters.ToArray());
                }
            }
            catch { }
        }

        /// <summary>
        /// 获取所有临床科室
        /// </summary>
        /// <returns></returns>
        public static List<EntityData> GetAllClinicSection()
        {
            try
            {
                string sql = "select distinct a.sid id,a.section_name name from t_sectioninfo a ,t_section_area b where a.sid=b.sid order by a.section_name ";
                DataTable table = App.GetDataSet(sql).Tables[0];
                if (table != null)
                {
                    List<EntityData> list = new List<EntityData>();
                    table.Rows.Cast<DataRow>().ToList().ForEach(r =>
                    {
                        list.Add(new EntityData()
                        {
                            Key = r["id"].ToString(),
                            Data = r["name"].ToString()
                        });
                    });
                    return list;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 是否获取权限
        /// </summary>
        /// <param name="patientId">患者id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public static bool IsAccessRights(int patientId)
        {
            try
            {
                string sql = string.Format("select count(t.id) as num from T_SUPER_USER t where t.user_id = {0} and t.patient_id = {1}", App.UserAccount.UserInfo.User_id, patientId);
                string count = App.ReadSqlVal(sql, 0, "num");
                if (Convert.ToInt32(count) > 0)
                {
                    return true;
                }
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                {//检查是否是管床医生
                    sql = string.Format("select count(t.id) as num from t_patient_section_doctors t where resident_doctor_id={0}  and  patient_id={1} and section_id={2}", App.UserAccount.UserInfo.User_id, patientId, App.UserAccount.CurrentSelectRole.Section_Id);
                    count = App.ReadSqlVal(sql, 0, "num");
                    if (Convert.ToInt32(count) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        sql = string.Format("select count(t.id) as num from t_in_patient t where t.sick_doctor_id = {0} and t.id = {1}", App.UserAccount.UserInfo.User_id, patientId);
                        count = App.ReadSqlVal(sql, 0, "num");
                        if (Convert.ToInt32(count) > 0)
                        {
                            return true;
                        }
                    }
                }
                else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {//检查是不是责任护士
                    sql = string.Format("select count(t.id) as num from t_patient_area_nurser t where nurser_id={0}  and  patient_id={1} and area_id={2}", App.UserAccount.UserInfo.User_id, patientId, App.UserAccount.CurrentSelectRole.Sickarea_Id);
                    count = App.ReadSqlVal(sql, 0, "num");
                    if (Convert.ToInt32(count) > 0)
                    {
                        return true;
                    }
                }
                sql = string.Format("select encryptlevel from t_in_patient  where  id = {0}", patientId);
                string level = App.ReadSqlVal(sql, 0, "encryptlevel");
                if (GetUserLevel(App.UserAccount.UserInfo.U_tech_post_name) >= Convert.ToInt32(level))
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据职称判断用户等级
        /// 加密等级1：主管护师、该病例责任护士、特别用户
        /// 加密等级2：副主任护师、该病例责任护士、特别用户
        /// 加密等级3：主任护师、该病例责任护士、特别用户
        /// 加密等级4：该病例责任护士、特别用户
        /// </summary>
        /// <param name="postName">职称</param>
        /// <returns></returns>
        public static int GetUserLevel(string postName)
        {
            int level = 0;
            switch (postName)
            {
                case "住院医师":
                case "护师":
                    level = 0;
                    break;

                case "主治医师":
                case "主管护师":
                    level = 1;
                    break;

                case "副主任医师":
                case "副主任护师":
                    level = 2;
                    break;

                case "主任医师":
                case "主任护师":
                    level = 3;
                    break;

                default:
                    level = 0;
                    break;
            }
            return level;
        }



    }
}
