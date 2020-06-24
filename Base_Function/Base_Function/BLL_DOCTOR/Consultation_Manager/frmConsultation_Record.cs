using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TextEditor;
using Bifrost;
using Base_Function.BASE_COMMON;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class frmConsultation_Record : UserControl
    {
        //职务职称级别信息
        private DataTable dt_Jobtitle = new DataTable();
        private frmText text;
        private InPatientInfo inPatient;
        Operater operater = new Operater();
        //当前会诊记录id
        private string Id = null;
        /// <summary>
        /// 构造函数，获取参数
        /// </summary>
        /// <param name="inpatientInfo">病人对象</param>
        /// <param name="apply_Time">申请时间</param>
        /// <param name="apply_SectionName">申请科室</param>
        /// <param name="consultation_Type">会诊类别</param>
        /// <param name="id">当前会诊记录id</param>
        public frmConsultation_Record()
        {
            InitializeComponent();

            App.UsControlStyle(this);
            //绑定数据到flgGrid
            RefGrid();
            if (flgGrid.Rows.Count > 0 && flgGrid.RowSel > 0)
            {
                this.inPatient = DataInit.GetInpatientInfoByPid(flgGrid[flgGrid.RowSel, "patient_id"].ToString());
                //this.lblApply_Time.Text = flgGrid[flgGrid.RowSel,"申请时间"].ToString();
                //this.lblSonsultation_Type.Text = flgGrid[flgGrid.RowSel, "会诊类别"].ToString();
                //this.lblApply_SectionName.Text = flgGrid[flgGrid.RowSel,"申请科室"].ToString();
                //this.lblSection.Text =DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
                //this.lblConsul_section.Text = DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
                //this.lblConsul_doctor.Text = App.UserAccount.UserInfo.User_name;
                //this.Id = flgGrid[flgGrid.RowSel,"序号"].ToString();
                //this.txtApply_Content.Text = flgGrid[flgGrid.RowSel, "会诊内容"].ToString();
                //this.lblSection.Text = DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
            }
            if (inPatient != null)
            {
                this.lblPatientName.Text = inPatient.Patient_Name;
                this.lblArea.Text = inPatient.Sick_Area_Name;
                this.lblBedNumber.Text = inPatient.Sick_Bed_Name;
            }
        }

        /// <summary>
        /// 接诊
        /// </summary>
        private void btnAccepts_Click(object sender, EventArgs e)
        {
            try
            {
                if (flgGrid.RowSel > 0)
                {
                    if (btnAccepts.Text == "接诊")
                    {
                        //修改当前会诊记录id的接诊状态为接诊
                        string Sql_accept = "update t_consultaion_record set isrecieve =1,consul_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                            "consul_r_name='" + App.UserAccount.UserInfo.User_name + "' where id=" + Id + "";

                        if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                        {
                            int count = App.ExecuteSQL(Sql_accept);
                            if (count > 0)
                            {
                                btnUpdate.Enabled = false;
                                btnSaveing.Enabled = true;
                                btnAccepts.Enabled = true;
                                btnSave.Enabled = true;
                                //btnAdd.Enabled = true;
                                btnCancel.Enabled = true;
                                text.Enabled = true;
                                //operater = Operater.Accepts;
                                //txtRecord_Content.ReadOnly = false;
                                App.Msg("接诊成功，请您填写会诊记录！");
                                btnAccepts.Text = "取消接诊";
                                operater = Operater.Add;
                            }
                            else
                            {
                                btnAccepts.Enabled = true;
                                btnUpdate.Enabled = false;
                                btnSave.Enabled = false;
                                btnSaveing.Enabled = false;
                                btnAdd.Enabled = false;
                                App.Msg("接诊操作失败，请您与管理员联系！");
                            }
                        }

                    }
                    else
                    {
                        string Sql_accept = "update t_consultaion_record set isrecieve =0,consul_r_id=0," +
                                              "consul_r_name='',CONSUL_RECORD_CONTENT='' where id=" + Id + "";
                        int count = App.ExecuteSQL(Sql_accept);
                        if (count > 0)
                        {
                            btnCancel.Enabled = false;
                            btnAdd.Enabled = false;
                            btnUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnSaveing.Enabled = false;
                            btnAccepts.Enabled = true;
                            btnAccepts.Text = "接诊";
                            text.Enabled = false;
                            //txtRecord_Content.Text = "";
                        }
                    }
                    //刷新表格
                    RefGrid();
                }
                else
                {
                    App.Msg("你没有选中任何的会诊记录！");
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;


                switch (operater)
                {
                    case Operater.Add:
                        flag = add();
                        btnAccepts.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnSave.Enabled = true;
                        btnSaveing.Enabled = false;
                        btnAdd.Enabled = false;
                        btnCancel.Enabled = true;
                        break;
                    case Operater.Update:
                        flag = update();
                        btnAccepts.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnSave.Enabled = true;
                        btnSaveing.Enabled = false;
                        btnAdd.Enabled = false;
                        btnCancel.Enabled = true;
                        break;
                    default:
                        App.Msg("您没有做任何操作哦！");
                        break;
                }

                if (flag)      //操作成功，刷新表格
                {
                    //text.commit();
                    RefGrid();
                    btnCancel_Click(sender, e);
                }
            }
            catch (System.Exception ex)
            {

            }
            //operater = Operater.NoThing;
            //txtRecord_Content.ReadOnly = true;
            //txtRecord_Content.Text = "";

        }
        /// <summary>
        /// 添加
        /// </summary>
        private bool add()
        {
            bool Flag = false;
            //bool flag =validating();
            //if (flag)
            //    return false;
            if (!isEnd())
            {
                // txtRecord_Content.ReadOnly = false;
                /*
                 *保存会诊记录信息 
                 */
                string Sql_Save_Record = "update t_consultaion_record set write_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                         "write_r_name='" + App.UserAccount.UserInfo.User_name + "'," +
                                         "consul_time=sysdate,consul_record_submite_state=1,state=1" +
                                         " where id=" + Id + "";
                int count = App.ExecuteSQL(Sql_Save_Record);
                if (count > 0)
                {
                    //设置文书内容
                    SetDoc();

                    string SName = App.GetSystemTime().ToString() + "," + App.UserAccount.CurrentSelectRole.Section_Id + "," +
                                 App.UserAccount.CurrentSelectRole.Section_name + "," + flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString();
                    //text.setNewDoc(inPatient.PId, 133, 0, 0, SName, 0, inPatient.Patient_Name, inPatient.PId, inPatient.Sick_Bed_Name, inPatient.Section_Name, "会诊记录", true);
                    text.setNewDoc(821, 0, 0, "会诊单", 0, inPatient, true);
                    text.MyDoc.Us.Tid = 0; //0增加 文书id 修改
                    text.MyDoc.Us.IsMore = true;
                    text.MyDoc.Us.RecordText = App.UserAccount.CurrentSelectRole.Section_name + " " + App.UserAccount.UserInfo.User_name; //节点名称
                    text.MyDoc.Us.RecordTime = string.Format("{0:g}", App.GetSystemTime()); //记录时间


                    

                    Flag = true;
                    App.Msg("会诊记录信息已经填写成功！");
                }
                else
                {
                    App.Msg("会诊记录操作失败！");
                }
            }
            return Flag;
        }

        /// <summary>
        /// 会诊单提交时，重新拼接Xml
        /// </summary>
        private void SetDoc()
        {
            #region 取出文书


            string sql_Con_Content = "select patients_doc,textname,consultaion_record_id  from t_patients_doc where textkind_id=821 " +
                                             " and patient_id = (select patient_id from t_consultaion_apply where id = " + flgGrid[flgGrid.RowSel, "apply_id"] + ")";
            DataTable dt_ConContent = App.GetDataSet(sql_Con_Content).Tables[0];
            string xml_record = null;
            foreach (DataRow row in dt_ConContent.Rows)
            {
                //if (row["textname"].ToString().Split(',').Length > 0)
                //{
                //会诊记录id
                string Recordid = row["consultaion_record_id"].ToString();
                if (Recordid == flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString())
                {
                    xml_record = row["patients_doc"].ToString();
                    break;
                }
                //}
            }
            #endregion
            if (xml_record != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml_record);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("input");
                if (nodeList != null && nodeList.Count > 0)
                {
                    foreach (XmlNode ChildNode in nodeList)
                    {
                        if (ChildNode.Attributes["name"] != null)
                        {
                            string inputName = ChildNode.Attributes["name"].Value.Trim();
                            switch (inputName)
                            {
                                case "接诊科":
                                    ChildNode.InnerText = App.UserAccount.CurrentSelectRole.Section_name;
                                    break;
                                case "接诊医师":
                                    ChildNode.InnerXml = App.UserAccount.UserInfo.User_name;
                                    break;
                                case "接诊日期":
                                    ChildNode.InnerXml = App.GetSystemTime().ToString();
                                    break;
                                case "会诊答复":
                                    //ChildNode.InnerXml = this.text.MyDoc.GetContainer.ToZYString();
                                    XmlDocument _xmlDoc = new XmlDocument();
                                    _xmlDoc.LoadXml("<a/>");
                                    this.text.MyDoc.GetContainer.ToXML(_xmlDoc.DocumentElement);
                                    ChildNode.InnerXml = _xmlDoc.DocumentElement.InnerXml;

                                    break;
                            }
                        }
                    }
                }
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "Patients_Doc";
                xmlPars[0].Value = xmlDoc.OuterXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                string update_content = "update t_patients_doc set Patients_Doc=:Patients_Doc where consultaion_record_id=" + Convert.ToInt32(flgGrid[flgGrid.RowSel, "会诊记录序号"]);
                int num = App.ExecuteSQL(update_content, xmlPars);
                if (num > 0)
                {

                }
            }
        }
        //private bool validating()
        //{
        //    bool flag = false;
        //    if (txtRecord_Content.Text.Trim().Length<10)
        //    {
        //        App.Msg("会诊意见不能为空或者不能小于10个字符！");
        //        flag = true;
        //    }
        //    return flag;
        //}

        /// <summary>
        /// 刷新表格
        /// </summary>
        /// <returns></returns>
        public DataTable ShowGrid()
        {
            /*
             *查出当前科室的所有会诊记录 
             */
            string Sql_select = "select b.id 会诊记录序号,a.apply_sectionname 申请科室,a.apply_name 申请医生," +
                               " to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请时间," +
                               " case a.apply_type when 0 then '普通会诊' else '急会诊' end 会诊类别," +
                               " case b.state when '0' then '未会诊' else '已会诊' end 会诊状态," +
                               " c.sick_bed_no 病人床号,c.patient_name 病人姓名,c.age 年龄," +
                               " (case c.age when 1 then '女' else '男' end ) 性别,b.consul_r_name 被邀医生,b.write_r_name 填写会诊意见医生," +
                               " (case b.isrecieve when 1 then '是' else '否' end) 是否接诊,to_char(b.consul_time,'yyyy-MM-dd hh24:mi') 会诊时间," +
                               " a.pid,a.id as apply_id,(case a.consultation_end when 1 then '是' else '否' end) 会诊是否结束," +
                               " b.consul_r_id,b.consul_section_name 会诊科室, (case b.consul_record_submite_state when 1 then '是' else '否' end) 会诊意见是否提交,b.write_r_id,a.patient_id from t_consultaion_apply a " +
                               " inner join t_consultaion_record b on a.id = b.apply_id" +
                               " inner join t_in_patient c on a.patient_id = c.id" +
                               " where b.consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.is_dalete='N' order by a.apply_time";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_select);
            if (ds != null)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        private void flgGrid_Click(object sender, EventArgs e)
        {

            try
            {
                txtApply_Content.Text = "";
                // txtRecord_Content.Text = "";
                if (flgGrid.RowSel > 0)
                {
                    //this.inPatient = DataInit.GetInpatientInfoByPid(flgGrid[flgGrid.RowSel, "patient_id"].ToString());
                    if (!isEnd())//验证会诊是否结束
                    {
                        string Isrecieve = flgGrid[flgGrid.RowSel, "是否接诊"].ToString();
                        if (Isrecieve == "否")
                        {
                            btnAccepts.Enabled = true;
                            btnAccepts.Text = "接诊";
                            btnUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnSaveing.Enabled = false;
                            btnAdd.Enabled = false;
                            btnCancel.Enabled = false;
                            btnSubmite.Enabled = false;
                        }
                        else
                        {
                            //if (flgGrid[flgGrid.RowSel, "write_r_id"].ToString() != "")
                            //{
                            ////获取当期用户信息的职务，职称。
                            //string Sql_UserInof_Teach_Post = "select u_tech_post,u_position from t_userinfo where user_id=" + flgGrid[flgGrid.RowSel, "write_r_id"] + "";
                            //DataTable dt_Teach_Post = App.GetDataSet(Sql_UserInof_Teach_Post).Tables[0];
                            ////职务
                            //string position = dt_Teach_Post.Rows[0]["u_position"].ToString();
                            ////职称
                            //string teach_post = dt_Teach_Post.Rows[0]["u_tech_post"].ToString();
                            //if (flgGrid[flgGrid.RowSel, "write_r_id"].ToString() == App.UserAccount.UserInfo.User_id ||
                            //    IsRight(teach_post, position))
                            //有证医生可以操作会诊申请
                            if (Convert.ToBoolean(App.UserAccount.UserInfo.Profession_card) == true)
                            {
                                if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "是")
                                {
                                    btnUpdate.Enabled = true;
                                    btnAccepts.Enabled = true;
                                    btnSave.Enabled = false;
                                    btnSaveing.Enabled = false;
                                    //btnAdd.Enabled = false;
                                    btnCancel.Enabled = true;
                                    btnSubmite.Enabled = true;
                                }
                                else
                                {
                                    btnUpdate.Enabled = true;
                                    btnAccepts.Enabled = true;
                                    btnSave.Enabled = true;
                                    btnSaveing.Enabled = true;
                                    //btnAdd.Enabled = false;
                                    btnCancel.Enabled = true;
                                    btnSubmite.Enabled = true;
                                }
                               
                                btnAccepts.Text = "取消接诊";
                            }
                            else
                            {
                                btnAccepts.Enabled = false;
                                btnUpdate.Enabled = false;
                                btnSave.Enabled = false;
                                btnSaveing.Enabled = false;
                                btnAdd.Enabled = false;
                                btnCancel.Enabled = false;
                                btnSubmite.Enabled = false;
                            }
                            //}
                        }
                        /*
                         *得到当前选中的会诊记录对应的申请内容和会诊内容 
                         */
                        string sql_Content = "select a.consultation_content from t_consultaion_apply a " +
                                             " inner join t_consultaion_record b on a.id = b.apply_id" +
                                             " where b.id=" + flgGrid[flgGrid.RowSel, "会诊记录序号"] + "";
                        string Sql_ByPId = " select * from t_in_patient a" +
                                            " where id ='" + flgGrid[flgGrid.RowSel, "patient_id"] + "'";
                        /*
                         * 会诊记录内容
                         */
                        string sql_Con_Content = "select patients_doc,textname,consultaion_record_id  from t_patients_doc where textkind_id=821 " +
                                                 " and patient_id = (select patient_id from t_consultaion_apply where id = " + flgGrid[flgGrid.RowSel, "apply_id"] + ")";
                        Class_Table[] tabs = new Class_Table[3];
                        /*
                         * 会诊申请内容
                         */
                        tabs[0] = new Class_Table();
                        tabs[0].Sql = sql_Content;
                        tabs[0].Tablename = "TabContent";
                        /*
                         * 病人信息
                         */
                        tabs[1] = new Class_Table();
                        tabs[1].Sql = Sql_ByPId;
                        tabs[1].Tablename = "TabInpatient";
                        /*
                         * 会诊记录内容
                         */
                        tabs[2] = new Class_Table();
                        tabs[2].Sql = sql_Con_Content;
                        tabs[2].Tablename = "tabConContent";
                        DataSet ds = App.GetDataSet(tabs);

                        this.inPatient = null;
                        this.inPatient = DataInit.GetInpatientInfoByPid(ds.Tables["TabInpatient"]);
                        this.lblApply_Time.Text = flgGrid[flgGrid.RowSel, "申请时间"].ToString();
                        this.lblSonsultation_Type.Text = flgGrid[flgGrid.RowSel, "会诊类别"].ToString();
                        this.lblApply_SectionName.Text = flgGrid[flgGrid.RowSel, "申请科室"].ToString();
                        this.lblSection.Text = App.UserAccount.CurrentSelectRole.Section_name; //DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
                        this.lblConsul_section.Text = DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
                        this.lblConsul_doctor.Text = App.UserAccount.UserInfo.User_name;
                        this.lblSection.Text = DataInit.getSectionNameById(App.UserAccount.CurrentSelectRole.Section_Id);
                        this.lblAge.Text = inPatient.Age.ToString();
                        this.lblBedNumber.Text = inPatient.Sick_Bed_Name;
                        this.lblPatientName.Text = inPatient.Patient_Name;
                        this.lblDoctorName.Text = Convert.ToString(flgGrid[flgGrid.RowSel, "申请医生"]);
                        string sex = null;
                        if (inPatient.Gender_Code == "1")
                        {
                            sex = "女";
                        }
                        else
                        {
                            sex = "男";
                        }
                        this.lblSex.Text = sex;

                        this.Id = flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString();
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables["TabContent"];
                            if (dt.Rows.Count > 0)
                            {
                                //会诊申请内容
                                this.txtApply_Content.Text = dt.Rows[0]["consultation_content"].ToString();
                            }
                            DataTable dt_ConContent = ds.Tables["tabConContent"];
                            string xml_record = null;
                            foreach (DataRow row in dt_ConContent.Rows)
                            {
                                //if (row["textname"].ToString().Split(',').Length > 0)
                                //{
                                //会诊记录id
                                string Recordid = row["consultaion_record_id"].ToString();
                                if (Recordid == flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString())
                                {
                                    xml_record = row["patients_doc"].ToString();
                                    break;
                                }
                                //}
                            }
                            if (xml_record != null)
                            {
                                string SName = App.GetSystemTime().ToString() + "," + App.UserAccount.CurrentSelectRole.Section_Id + "," +
                                App.UserAccount.CurrentSelectRole.Section_name + "," + flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString();
                                //text.setNewDoc(inPatient.PId, 133, 0, 0, SName, 0, inPatient.Patient_Name, inPatient.PId, 
                                //               inPatient.Sick_Bed_Name, inPatient.Section_Name, "会诊记录", true);

                                text.setNewDoc(821, 0, 0, "会诊单", 0, inPatient, true);
                                Dictionary<string, string> header = new Dictionary<string, string>();
                                header.Add("姓名", inPatient.Patient_Name);
                                header.Add("科室", inPatient.Section_Name);
                                header.Add("住院号",inPatient.PId);
                                text.MyDoc.PageHeader = header;
                                text.MyDoc.Us.Tid = 1; //0增加 文书id 修改
                                text.MyDoc.Us.RecordText = App.UserAccount.CurrentSelectRole.Section_name + " " + App.UserAccount.UserInfo.User_name; //节点名称
                                text.MyDoc.Us.RecordTime = string.Format("{0:g}", App.GetSystemTime()); //记录时间


                                XmlDocument tempXml = new XmlDocument();    //会诊单全部内容
                                tempXml.LoadXml(xml_record);
                                string answerContent = ""; //会诊答复内容
                                XmlNodeList nodeList = tempXml.GetElementsByTagName("input");
                                if (nodeList != null && nodeList.Count > 0)
                                {
                                    foreach (XmlNode ChildNode in nodeList)
                                    {
                                        if (ChildNode.Attributes["name"] != null)
                                        {
                                            string inputName = ChildNode.Attributes["name"].Value.Trim();
                                            if (inputName == "会诊答复")
                                            {
                                                answerContent = ChildNode.InnerXml;
                                                break;
                                            }



                                        }
                                    }
                                }
                                //拼XML，只显示会诊答复内容
                                XmlDocument tempxmldoc = new XmlDocument();
                                tempxmldoc.PreserveWhitespace = true;
                                tempxmldoc.LoadXml("<emrtextdoc/>");
                                text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                tempxmldoc.SelectSingleNode("emrtextdoc/body").InnerXml = "";
                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                {
                                    if (bodyNode.Name == "body")
                                    {
                                        bodyNode.InnerXml = answerContent;
                                        //bodyNode.InnerText += answerContent;
                                        break;
                                    }
                                }

                                //text.MyDoc.FromText(answerContent);
                                text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                text.MyDoc.ContentChanged();
                            }
                            else
                            {
                                text.MyDoc.ClearContent();
                                //text.setNewDoc(inPatient.PId, 133, 0, 0, "", 0, inPatient.Patient_Name, inPatient.PId,
                                //               inPatient.Sick_Bed_Name, inPatient.Section_Name, "住院病程", false);
                                text.setNewDoc(133, 0, 0, "住院病程", 0, inPatient, true);
                                text.MyDoc.Us.Tid = 1; //0增加 文书id 修改
                                text.MyDoc.Us.RecordText = App.UserAccount.CurrentSelectRole.Section_name + " " + App.UserAccount.UserInfo.User_name; //节点名称
                                text.MyDoc.Us.RecordTime = string.Format("{0:g}", App.GetSystemTime()); //记录时间
                            }

                        }
                        if (inPatient != null)
                        {
                            this.lblPatientName.Text = inPatient.Patient_Name;
                            this.lblArea.Text = inPatient.Sick_Area_Name;
                            this.lblBedNumber.Text = inPatient.Sick_Bed_Name;
                        }
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
                        btnAccepts.Enabled = false;
                        btnSave.Enabled = false;
                        btnSaveing.Enabled = false;
                        btnAdd.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isEnd())
            {
                if (isMyself())
                {
                    //txtRecord_Content.ReadOnly = false;
                    //txtRecord_Content.Enabled = true;
                    operater = Operater.Add;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnSaveing.Enabled = true;
                    btnSubmite.Enabled = true;
                    btnUpdate.Enabled = false;
                    text.Enabled = true;
                }
                else
                {
                    App.Msg("已经有人接诊了，目前只支持一科一诊！");
                }
            }
            else
            {
                App.Msg("改会诊已经结束，不能再做人任何操作了！");
            }
        }
        /// <summary>
        /// 操作类型枚举
        /// </summary>
        private enum Operater
        {
            NoThing,     //不做任何操作
            Add,         //添加
            Update,      //修改
            Delete,      //删除
            Accepts      //接诊
        }
        /// <summary>
        /// 会诊是否结束，true结束,false 未结束。
        /// </summary>
        /// <returns></returns>
        public bool isEnd()
        {
            bool flag = false;
            if (flgGrid[flgGrid.RowSel, "会诊是否结束"].ToString() == "是") //会诊结束
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 会诊记录修改
        /// </summary>
        private bool update()
        {
            bool Flag = false;
            //bool flag = validating();
            //if (flag)
            //    return false;

            /*
             *保存会诊记录信息 
             */
            string Sql_Save_Record = "update t_consultaion_record set write_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                     "write_r_name='" + App.UserAccount.UserInfo.User_name + "'," +
                                     "consul_time=sysdate,consul_record_submite_state=1,state=1 where id=" + Id + "";
            int count = App.ExecuteSQL(Sql_Save_Record);
            if (count > 0)
            {
                //设置文书内容
                SetDoc();

                string SName = App.GetSystemTime().ToString() + "," + App.UserAccount.CurrentSelectRole.Section_Id + "," +
                               App.UserAccount.CurrentSelectRole.Section_name + "," + flgGrid[flgGrid.RowSel, "会诊记录序号"].ToString();
                //text.setNewDoc(inPatient.PId, 133, 0, 0, SName, 133, inPatient.Patient_Name, inPatient.PId, inPatient.Sick_Bed_Name, inPatient.Section_Name, "会诊记录", true);
                text.setNewDoc(821, 0, 0, "会诊单", 0, inPatient, true);
                text.MyDoc.Us.IsMore = true;
                Flag = true;
                App.Msg("会诊记录信息已经填写成功！");
            }
            else
            {
                App.Msg("会诊记录操作失败！");
            }
            return Flag;
        }
        /// <summary>
        /// 当前医生id，和选中的该条会诊记录的医生id是否相同,true 相同，false不相同
        /// </summary>
        /// <returns>bool值</returns>
        private bool isMyself()
        {
            bool flag = false;
            //string Sql_Record_DoctorId = "select consul_r_id from t_consultaion_record where id=" + flgGrid[flgGrid.RowSel, "会诊记录序号"] + "";
            //string doctor_Id = App.ReadSqlVal(Sql_Record_DoctorId, 0, "consul_r_id");
            string doctor_Id = flgGrid[flgGrid.RowSel, "write_r_id"].ToString();
            if (doctor_Id == "0" || doctor_Id == "")
            {
                flag = true;
            }
            else
            {
                if (doctor_Id == App.UserAccount.UserInfo.User_id)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgGrid.RowSel > 0)
                {
                    if (isTakeUp())
                    {
                        if (!isEnd())
                        {
                            if (isMyself())
                            {
                                //txtRecord_Content.Enabled = true;
                                //txtRecord_Content.ReadOnly = false;
                                operater = Operater.Update;
                                btnSave.Enabled = true;
                                btnCancel.Enabled = true;
                                btnAdd.Enabled = false;
                                btnSubmite.Enabled = false;
                                text.Enabled = true;
                                if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "是")
                                {
                                    btnSaveing.Enabled = false;
                                }
                                else
                                {
                                    btnSaveing.Enabled = true;
                                }
                            }
                            else
                            {
                                App.Msg("你暂时没有权限修改他人的会诊记录！");
                            }
                        }
                        else
                        {
                            App.Msg("改会诊已经结束，不能再修改了！");
                        }
                    }
                }
                else
                {
                    App.Msg("你没有选中任何的会诊记录！");
                }
            }
            catch (Exception)
            {
            }
        }

        private bool isTakeUp()
        {
            string isTakeUp = flgGrid[flgGrid.RowSel, "是否接诊"].ToString();
            if (isTakeUp == "是")
            {
                return true;
            }
            else
            {
                App.Msg("请先接诊在修改！");
                return false;
            }
        }
        /// <summary>
        /// 刷新表格
        /// </summary>
        private void RefGrid()
        {
            //DataTable dt = ShowGrid();
            flgGrid.DataSource = ShowGrid();
            flgGrid.Cols["pid"].Visible = false;
            flgGrid.Cols["apply_id"].Visible = false;
            flgGrid.Cols["consul_r_id"].Visible = false;
            flgGrid.Cols["write_r_id"].Visible = false;
            flgGrid.Cols["patient_id"].Visible = false;
            flgGrid.Cols["申请科室"].Visible = false;
            flgGrid.Cols["申请医生"].Visible = false;
            flgGrid.Cols["申请时间"].Visible = false;
            flgGrid.Cols["会诊类别"].Visible = false;
            flgGrid.Cols["病人床号"].Visible = false;
            flgGrid.Cols["病人姓名"].Visible = false;
            flgGrid.Cols["年龄"].Visible = false;
            flgGrid.Cols["性别"].Visible = false;
            flgGrid.Cols["会诊科室"].Visible = false;
            //flgGrid.Cols["consul_r_id"].Visible = false;
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //switch (operater)
            //{
            //    case Operater.Accepts:
            //        /*
            //         *修改当前会诊记录的接诊状态为未接诊 
            //         */
            //        string Sql_accept = "update t_consultaion_record set isrecieve =0,consul_r_id=" + App.UserAccount.UserInfo.User_id + "," +
            //                           "consul_r_name='" + App.UserAccount.UserInfo.User_name + "' where id=" + Id + "";
            //        App.ExecuteSQL(Sql_accept);
            //        operater = Operater.NoThing;
            //        btnAccepts.Enabled = true;
            //        btnCancel.Enabled = false;
            //        btnAdd.Enabled = false;
            //        btnUpdate.Enabled = false;
            //        btnSave.Enabled = false;
            //        btnSaveing.Enabled = false;
            //        break;
            //    case Operater.Add:
            //        //txtRecord_Content.Text = "";
            //        operater = Operater.NoThing;
            //        operater = Operater.NoThing;
            //        btnAccepts.Enabled = false;
            //        btnCancel.Enabled = true;
            //        btnAdd.Enabled = true;
            //        btnUpdate.Enabled = true;
            //        btnSave.Enabled = true;
            //        btnSaveing.Enabled = true;
            //        break;
            //    case Operater.Update:
            //        //txtRecord_Content.Text = "";
            //        operater = Operater.NoThing;
            //        btnAccepts.Enabled = false;
            //        btnCancel.Enabled = true;
            //        btnAdd.Enabled = true;
            //        btnUpdate.Enabled = true;
            //        btnSave.Enabled = true;
            //        if (flgGrid[flgGrid.RowSel,"会诊意见是否提交"].ToString()=="是")
            //        {
            //            btnSaveing.Enabled = false;
            //        }
            //        else
            //        {
            //            btnSaveing.Enabled = true;
            //        }
            //        break;
            //    default:
            //        break;
            //        text.Enabled = false;
            //}
            text.Enabled = false;
            operater = Operater.NoThing;
            flgGrid_Click(sender, e);
        }

        private void frmConsultation_Record_Load(object sender, EventArgs e)
        {
            string sql_Jobtitle = "select * from t_in_doc_jobtitle";
            dt_Jobtitle = App.GetDataSet(sql_Jobtitle).Tables[0];
            DataTable dt = null;
            if (flgGrid.Rows.Count > 1)
            {
                //查看当前科室的当前会诊记录id的接诊状态是否已经为接诊
                string Sql_Accept = "select isrecieve,consul_r_id from t_consultaion_record where apply_id=" + flgGrid[flgGrid.RowSel, "apply_id"] +
                                  "and consul_record_section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "";
                dt = App.GetDataSet(Sql_Accept).Tables[0];
                string Isrecieve = dt.Rows[0]["isrecieve"].ToString();
                string Consul_r_id = dt.Rows[0]["consul_r_id"].ToString();
                string Sql_accept = null;
                if (Isrecieve == "0")
                {
                    btnAccepts.Enabled = true;
                }
                else
                {
                    if (flgGrid[flgGrid.RowSel, "consul_r_id"].ToString() == App.UserAccount.UserInfo.User_id)
                    {
                        btnUpdate.Enabled = true;
                        btnSave.Enabled = false;
                        btnSaveing.Enabled = false;
                        btnAdd.Enabled = false;
                    }
                }
            }
            string Content = App.UserAccount.CurrentSelectRole.Section_name + " " + App.UserAccount.UserInfo.User_name;
            text = new frmText();
            text.MyDoc.Us.IsMore = true;
            pnlDoc.Controls.Add(text);
            text.Dock = DockStyle.Fill;
            text.Enabled = false;
            flgGrid_Click(sender, e);
        }
        //提交
        private void btnSubmite_Click(object sender, EventArgs e)
        {
            if (flgGrid.RowSel > 0)
            {
                if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "否")
                {
                    string update = "update t_consultaion_record set consul_record_submite_state=1,state=1 where id=" + flgGrid[flgGrid.RowSel, "会诊记录序号"] + "";
                    //strBuilder.Append(update);
                    int count = App.ExecuteSQL(update);
                    if (count > 0)
                    {
                        btnSubmite.Enabled = false;
                        //刷新表格
                        RefGrid();
                        App.Msg("提交成功！");
                    }
                    else
                    {
                        App.Msg("提交失败！");
                    }
                }
                else
                {
                    App.Msg("该会诊申请已经提交过了！");
                }
            }
        }
        /// <summary>
        /// 查看当前会诊记录的提交状态true提交，false未提交.
        /// </summary>
        /// <returns>返回true 1,false 0</returns>
        private bool IsSubmite()
        {
            //查看当前会诊记录的提交状态
            string sql = "select t_consultaion_record from t_consultaion_record where id=" + flgGrid[flgGrid.RowSel, "会诊记录序号"] + "";
            string state = App.ReadSqlVal(sql, 0, "t_consultaion_record");
            return state == "1" ? true : false;
        }
        //暂存
        private void btnSaveing_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgGrid.RowSel > 0)
                {
                    if (!isEnd())
                    {
                        //txtRecord_Content.ReadOnly = false;
                        /*
                         *保存会诊记录信息 
                         */
                        string Sql_Save_Record = "update t_consultaion_record set write_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                                 "write_r_name='" + App.UserAccount.UserInfo.User_name + "'," +
                                                 "consul_time=sysdate," +
                                                 "consul_record_submite_state=0,state=0 where id=" + Id + "";
                        //设置文书内容
                        SetDoc();
                        int count = App.ExecuteSQL(Sql_Save_Record);
                        if (count > 0)
                        {
                            App.Msg("会诊记录信息已经暂存！");
                            //btnSaveing.Enabled = false;
                            btnSubmite.Enabled = true;
                        }
                        else
                        {
                            App.Msg("会诊记录操作失败！");
                        }
                    }
                }
                else
                {
                    App.Msg("你没有选中任何的会诊记录！");
                }
            }
            catch (Exception)
            {

            }
        }

        private void chkShenqing_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (this.splitContainerAll.Panel1Collapsed)
            {
                this.splitContainerAll.Panel1Collapsed = false;
            }
            else
            {
                this.splitContainerAll.Panel1Collapsed = true;
            }
        }

        /// <summary>
        /// 根据当前科室id,病人pid找到该病人的文书
        /// </summary>
        /// <param name="Sid">当前科室id</param>
        /// <param name="pid">当前病人pid</param>
        //private void GetPatientDoc(string Sid, string pid)
        //{
        //    string sql_Content = "select patients_doc from t_patients_doc a " +
        //                        " inner join t_consultaion_apply b on a.pid = b.pid" +
        //                        " inner join t_consultaion_record c on b.id = c.apply_id" +
        //                        " where a.textkind_id=133 and c.consul_record_section_id="+Sid+" and b.pid='"+pid+"'";
        //    string Content = App.ReadSqlVal(sql_Content, 0, "patients_doc");
        //    if(Content!=null)
        //    {
        //        System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
        //        tmpxml.LoadXml(Content);
        //        text.MyDoc.FromXML(tmpxml.DocumentElement);
        //        text.MyDoc.ContentChanged();
        //    }
        //}
        /// <summary>
        /// 判断当前用户的职务职称级别是否大于申请人的职务职称级别
        /// </summary>
        /// <param name="teach_post">职称</param>
        /// <param name="postition">职务</param>
        /// <returns>true 大于,false 小于</returns>
        private bool IsRight(string teach_post, string postition)
        {
            bool flag = false;
            //选中的该条申请记录人的职务职称级别
            int Select_levels = 0;
            //当前帐号的职务职称级别
            int Current_Levels = 0;
            if (App.UserAccount.UserInfo.U_position != "" ||
                App.UserAccount.UserInfo.U_position != string.Empty) //职务不等于空的情况，根据职务来判断级别
            {
                for (int i = 0; i < dt_Jobtitle.Rows.Count; i++)
                {
                    if (postition == Convert.ToString(dt_Jobtitle.Rows[i]["jobtitle_id"]))
                    {
                        Select_levels = Convert.ToInt32(dt_Jobtitle.Rows[i]["levels"]);
                    }
                    else if (App.UserAccount.UserInfo.U_position == Convert.ToString(dt_Jobtitle.Rows[i]["jobtitle_id"]))
                    {
                        Current_Levels = Convert.ToInt32(dt_Jobtitle.Rows[i]["levels"]);
                    }
                }
                if (Current_Levels > Select_levels)
                {
                    flag = true;
                }
            }
            else
            {
                if (App.UserAccount.UserInfo.U_tech_post != "" ||
                    App.UserAccount.UserInfo.U_tech_post != string.Empty)  //职务等于空的情况，根据职称来判断级别
                {
                    for (int i = 0; i < dt_Jobtitle.Rows.Count; i++)
                    {
                        if (teach_post == Convert.ToString(dt_Jobtitle.Rows[i]["jobtitle_id"]))
                        {
                            Select_levels = Convert.ToInt32(dt_Jobtitle.Rows[i]["levels"]);
                        }
                        else if (App.UserAccount.UserInfo.U_tech_post == Convert.ToString(dt_Jobtitle.Rows[i]["jobtitle_id"]))
                        {
                            Current_Levels = Convert.ToInt32(dt_Jobtitle.Rows[i]["levels"]);
                        }
                    }
                    if (Current_Levels > Select_levels)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
    }
}