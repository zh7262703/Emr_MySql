using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using System.Collections;
using System.Xml;

using TextEditor;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR.Consultation_Manager;

namespace Bifrost_Doctor.Consultation_Manager
{
    public partial class frmConsultation_Apply : DevComponents.DotNetBar.Office2007Form
    {
        frmText text;        //编辑器
        string book_Id = "";
        private InPatientInfo inPatient;
        private string Apply_Id = ""; //是否获取表格里面的数据
        //职务职称级别信息表
        private DataTable dt_Jobtitle = new DataTable();

        string content = ""; //会诊模板内容

        //获取病人选中文书内容
        public delegate void GetDocContent(string content);

        private bool issaveapply = false; //是添加（true）还是修改(false) 

        string recordsection_id = "";
        string recordsection_name = "";
        string applytime = "";

        /// <summary>
        /// 得到当前所有可用的科室
        /// </summary>
        private string Sql_GetAllSection = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
        public frmConsultation_Apply()
        {
            InitializeComponent();
        }
        public frmConsultation_Apply(InPatientInfo inpatientInfo)
        {
            /*
             * 通过构造函数，获得会诊申请列表数据
             * 获得当前所有可用的科室，获得当前会诊病人对象
             */
            InitializeComponent();
            btnSelect.Enabled = false;
            this.Text = inpatientInfo.Sick_Bed_Name + "-" + inpatientInfo.Patient_Name + "-" + this.Text;
            App.FormStytleSet(this, false);
            this.inPatient = inpatientInfo;
            DataInit.CurrentPatient = inpatientInfo;

        }

        /// <summary>
        /// 加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsultation_Apply_Load(object sender, EventArgs e)
        {
            flgGrid.AllowEditing = false;
            string sql_Jobtitle = "select * from t_in_doc_jobtitle";
            dt_Jobtitle = App.GetDataSet(sql_Jobtitle).Tables[0];
            flgGrid_Click(sender, e);
            text = new frmText(133, 0, 0, "会诊记录", 0, inPatient, true, true, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"), "");//Record_Time
            reflesh();
            text.Dock = DockStyle.Fill;
            panelEdit.Controls.Add(text);
            ShowGrid();
        }

        #region 事件操作

        void MyDoc_OnBackTextId(object sender, BackEvenHandle e)
        {
            book_Id = e.Para;
        }

        /// <summary>
        /// 新增会诊申请
        /// </summary>
        private void btnNewApply_Click(object sender, EventArgs e)
        {

            if (App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
            {
                //gbxEdit.Enabled = true;
                rdbtnNasty.Enabled = true;
                rdbtnNormal.Enabled = true;
                text.MyDoc.Locked = false;
                btnCancelApply.Enabled = true;
                btnSavetemp.Enabled = true;
                btnSave.Enabled = true;
                flgGrid.Enabled = false;
                btnSelect.Enabled = true;
                issaveapply = true;
                btnNewApply.Enabled = false;
                book_Id = "";
                text.MyDoc.Locked = false;
                CleadEditor();
            }
            else
            {
                App.MsgWaring("只有主治医师及以上级别，才能操作次功能！");
            }
        }

        /// <summary>
        /// 取消会诊申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelApply_Click(object sender, EventArgs e)
        {
            reflesh();

        }

        /// <summary>
        ///  暂存操作
        /// </summary>
        private void btnSavetemp_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmldocument = new XmlDocument();
                xmldocument.PreserveWhitespace = true;
                xmldocument.LoadXml("<doc/>");
                text.MyDoc.ToXML(xmldocument.DocumentElement);
                XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");
                //recordsection_id = bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊科目']").Attributes["id"].Value;
                //recordsection_name = bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊科目']").InnerText;
                //applytime = DataInit.GetTimeFromXml(bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊时间']"));

                XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");
                foreach (XmlNode sd in list)
                {
                    if (sd.Attributes["name"] != null)
                    {
                        if (sd.Attributes["name"].Value.Contains("请求会诊科目"))
                        {
                            recordsection_id = sd.Attributes["id"].Value;
                            recordsection_name = sd.InnerText.Trim() == "双击选择科室" ? "" : sd.InnerText;
                        }
                        else if (sd.Attributes["name"].Value == "请求会诊时间")
                        {
                            applytime = sd.InnerText.Replace('，', ' ');
                            sd.InnerXml = DataInit.TimeToXml(applytime);
                        }
                    }
                }
                if (recordsection_name.Contains("--"))
                {
                    recordsection_name = recordsection_name.Replace("--", ",").Split(',')[1];
                }

                text.MyDoc.Us.RecordTime = applytime;

                if (recordsection_name == "")
                {
                    App.MsgWaring("请选择会诊科室！");
                    return;
                }
                if (App.UserAccount.CurrentSelectRole.Section_Id.Trim() == recordsection_id.Trim())
                {
                    App.MsgWaring("申请科室不能为自己所在科室！");
                    return;
                }

                foreach (XmlNode sd in list)
                {
                    if (sd.Attributes["name"] != null)
                    {
                        if (sd.Attributes["name"].Value == "请求会诊科")
                        {
                            sd.InnerText = App.UserAccount.CurrentSelectRole.Section_name; //自动插入提交者科室
                        }
                        else if (sd.Attributes["name"].Value == "接诊科")
                        {
                            sd.InnerText = recordsection_name; //自动插入提交会诊科室
                        }
                    }
                }


                text.MyDoc.FromXML(xmldocument.DocumentElement);
                DataInit.CurrentFrmText = text;
                if (issaveapply)
                {

                    //text.MyDoc.saveDocument(sender, e);
                    DataInit.saveDocument(sender, e);
                    book_Id = DataInit.CurrentFrmText.MyDoc.Us.Tid.ToString();
                    if (book_Id != "")
                    {
                        InsertApply("N");
                        //保存文书表
                        if (!rdbtnNormal.Checked)
                        {
                            App.ExecuteSQL("update t_quality_text set textname=textname || '急会诊' where tid=" + text.MyDoc.Us.Tid + "");
                        }
                        else
                        {
                            App.ExecuteSQL("update t_quality_text set textname=textname || '普通会诊' where tid=" + text.MyDoc.Us.Tid + "");
                        }
                        ShowGrid();
                        reflesh();
                    }
                }
                else
                {
                    //保存文书表
                    //text.MyDoc.saveDocument(sender, e);
                    DataInit.saveDocument(sender, e);
                    updateApply();
                    ShowGrid();
                    reflesh();
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败！原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 已经保存的会诊申请提交，并修改提交状态。
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            XmlDocument xmldocument = new XmlDocument();
            xmldocument.PreserveWhitespace = true;
            xmldocument.LoadXml("<doc/>");
            text.MyDoc.ToXML(xmldocument.DocumentElement);
            XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");
            //recordsection_id = bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊科目']").Attributes["id"].Value;
            //recordsection_name = bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊科目']").InnerText;
            //applytime = DataInit.GetTimeFromXml(bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊时间']"));

            XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");


            //XmlDocument xmldocument = new XmlDocument();
            //xmldocument.LoadXml(text.MyDoc.GetDocXml());
            //XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");
            //XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");
            foreach (XmlNode sd in list)
            {
                if (sd.Attributes["name"] != null)
                {
                    if (sd.Attributes["name"].Value == "请求会诊科目")
                    {
                        recordsection_id = sd.Attributes["id"].Value;
                        recordsection_name = sd.InnerText.Trim() == "双击选择科室" ? "" : sd.InnerText;
                    }
                    else if (sd.Attributes["name"].Value == "请求会诊时间")
                    {
                        applytime = sd.InnerText.Replace('，', ' ');
                        sd.InnerXml = DataInit.TimeToXml(applytime);
                    }
                    //else if(sd.Attributes["name"].Value == "请求会诊时间")
                }
            }

            text.MyDoc.Us.RecordTime = applytime;
            if (recordsection_name.Contains("--"))
            {
                recordsection_name = recordsection_name.Replace("--", ",").Split(',')[1];
            }
            if (recordsection_name == "")
            {
                App.MsgWaring("请选择会诊科室！");
                return;
            }
            if (App.UserAccount.CurrentSelectRole.Section_Id.Trim() == recordsection_id.Trim())
            {
                App.MsgWaring("申请科室不能为自己所在科室！");
                return;
            }
            foreach (XmlNode sd in list)
            {
                if (sd.Attributes["name"] != null)
                {
                    if (sd.Attributes["name"].Value == "请求会诊科")
                    {
                        sd.InnerText = App.UserAccount.CurrentSelectRole.Section_name; //自动插入提交者科室
                    }
                    else if (sd.Attributes["name"].Value == "接诊科")
                    {
                        sd.InnerText = recordsection_name; //自动插入提交会诊科室
                    }
                }
            }
            text.MyDoc.FromXML(xmldocument.DocumentElement);
            DataInit.CurrentFrmText = text;
            if (issaveapply)
            {
                //保存文书表
                //if (!rdbtnNormal.Checked)
                //{
                //    text.MyDoc.Us.TextName = text.MyDoc.Us.RecordTime + " 急会诊";
                //}
                //else
                //{
                //    text.MyDoc.Us.TextName = text.MyDoc.Us.RecordTime + " 普通会诊";
                //}
                //保存文书表
              
                DataInit.saveDocument(sender, e);
                book_Id = DataInit.CurrentFrmText.MyDoc.Us.Tid.ToString();
                if (book_Id != "")
                {
                    InsertApply("Y");
                    string strConsul_tpye = "";
                    if (!rdbtnNormal.Checked)
                    {
                        strConsul_tpye = "急会诊";
                        App.ExecuteSQL("update t_quality_text set textname=textname || '急会诊' where tid=" + text.MyDoc.Us.Tid + "");
                    }
                    else
                    {
                        strConsul_tpye = "普通会诊";
                        App.ExecuteSQL("update t_quality_text set textname=textname || '普通会诊' where tid=" + text.MyDoc.Us.Tid + "");
                    }
                    //向质控临时表新增一条会诊记录
                    strConsul_tpye = strConsul_tpye + "," + recordsection_id;
                    string strAge = string.Empty;
                    if (App.IsNumeric(inPatient.Age))
                    {
                        strAge = inPatient.Age;
                    }
                    string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                            " values('" + inPatient.PId + "','" + strConsul_tpye + "',to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss')," + inPatient.Id + ",'" + strAge + "')";
                    App.ExecuteSQL(InsertJob_Temp);

                    reflesh();
                }
            }
            else
            {
                if (flgGrid.RowSel > 0)
                {
                    if (Convert.ToBoolean(App.UserAccount.UserInfo.Profession_card) == false)
                    {
                        App.Msg("有证医生才能提交会诊申请！");
                        return;
                    }
                    if (flgGrid[flgGrid.RowSel, "submited"].ToString() == "N")
                    {
                        string[] strsql = new string[2];
                        //保存文书表
                        DataInit.saveDocument(sender, e);
                        strsql[0] = "update t_consultaion_apply set submited='Y',apply_time=to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss'),apply_userId=" +
                            App.UserAccount.UserInfo.User_id + ",apply_Name='" +
                            App.UserAccount.UserInfo.User_name + "' where id=" +
                            flgGrid[flgGrid.RowSel, "id"].ToString() + "";

                        string strConsul_tpye = "";
                        if (!rdbtnNormal.Checked)
                        {
                            strConsul_tpye = "急会诊," + recordsection_id;
                        }
                        else
                        {
                            strConsul_tpye = "普通会诊," + recordsection_id;
                        }
                        //向质控临时表新增一条会诊记录
                        string strAge = string.Empty;
                        if (App.IsNumeric(inPatient.Age))
                        {
                            strAge = inPatient.Age;
                        }
                        strsql[1] = "insert into t_job_temp(pid,operate_type,operate_time,patient_id,age)" +
                                                " values('" + inPatient.PId + "','" + strConsul_tpye + "',to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss')," + inPatient.Id + ",'" + strAge + "')";
                        int count = App.ExecuteBatch(strsql);
                        if (count > 0)
                        {
                            reflesh();
                            App.Msg("申请提交成功！");
                        }
                        else
                        {
                            App.Msg("申请提交成功提交失败！");
                        }
                    }
                    else
                    {

                        if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                        {
                            //保存文书表
                            //text.MyDoc.saveDocument(sender, e);
                            DataInit.saveDocument(sender, e);
                            string sql = "update t_consultaion_apply set submited='Y',apply_time=to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss'),apply_userId=" +
                                App.UserAccount.UserInfo.User_id + ",apply_Name='" +
                                App.UserAccount.UserInfo.User_name + "',state=0 where id=" +
                                flgGrid[flgGrid.RowSel, "id"].ToString() + "";
                            if (App.ExecuteSQL(sql) > 0)
                            {
                                reflesh();
                                App.Msg("操作成功！");
                            }
                        }
                        else
                        {
                            App.MsgWaring("该会诊申请已经接诊，无法修改！");
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  选择病程
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmDoctorBook frmdoctorBook = new frmDoctorBook(inPatient.PId, inPatient.Id, text);
            frmdoctorBook.ShowDialog(this);
        }

        /// <summary>
        /// 菜单删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlspmnitDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
                {
                    App.MsgWaring("该功能只有主治及以上级别的医师才能使用！");
                    return;
                }
                if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "是")
                {
                    App.MsgWaring("该申请已经接诊，不能修改！");
                    return;
                }

                if (App.Ask("确定要删除这条申请记录吗？"))
                {
                    if (deleteApply())
                    {
                        App.Msg("操作已成功！");
                        reflesh();
                    }
                }
            }
            catch
            {
                App.MsgErr("删除失败,请先选中要删除的行！");
            }
        }

        /// <summary>
        /// 表格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (flgGrid.RowSel != -1)
                {
                    getSelGrid();
                    if (!Isaccepts())
                    {
                        //获取当期用户信息的职务，职称。
                        string Sql_UserInof_Teach_Post = "select u_tech_post,u_position from t_userinfo where user_id=" + flgGrid[flgGrid.RowSel, "save_id"] + "";
                        DataSet ds_teach_Post = App.GetDataSet(Sql_UserInof_Teach_Post);
                        if (ds_teach_Post != null)
                        {
                            DataTable dt_Teach_Post = ds_teach_Post.Tables[0];
                            string[] arr = GetPostAndPosition(flgGrid[flgGrid.RowSel, "save_id"].ToString());
                            //职务
                            string position = arr[0];
                            //职称
                            string teach_post = arr[1];
                        }
                        if (Convert.ToBoolean(App.UserAccount.UserInfo.Profession_card) == true)
                        {
                            if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "未提交")
                            {
                                btnSavetemp.Enabled = true;
                                btnNewApply.Enabled = true;
                                btnSave.Enabled = true;
                                return;
                            }
                        }
                        else if (flgGrid[flgGrid.RowSel, "save_id"].ToString() == App.UserAccount.UserInfo.User_id)
                        {
                            btnSavetemp.Enabled = false;
                            btnNewApply.Enabled = true;
                            btnSave.Enabled = false;
                            return;
                        }
                    }
                    text.MyDoc.Us.Tid = Convert.ToInt32(flgGrid[flgGrid.RowSel, "PATIENT_DOC_ID"].ToString());
                    System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    //string sql = "select patients_doc from t_patients_doc where tid=" + text.MyDoc.Us.Tid + "";
                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + text.MyDoc.Us.Tid.ToString() + "", 0, "CONTENT");

                    if (content == "" || content == null)
                    {
                        content = App.DownLoadFtpPatientDoc(text.MyDoc.Us.Tid.ToString() + ".xml", inPatient.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                    }

                    tmpxml.LoadXml(content);
                    XmlNode xmlNode = tmpxml.SelectSingleNode("emrtextdoc");

                    //接诊部分的表格锁定            
                    XmlNodeList cellnodes = xmlNode.SelectSingleNode("//body//table[@id='C2FD671443']").ChildNodes;// xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']").ChildNodes;
                    for (int i = 0; i < cellnodes.Count; i++)
                    {
                        if (cellnodes[i].Name == "row")
                        {
                            for (int j = 0; j < cellnodes[i].ChildNodes.Count; j++)
                            {
                                if (cellnodes[i].ChildNodes[j].Name == "cell")
                                {
                                    bool ak = false;
                                    for (int k = 0; k < cellnodes[i].ChildNodes[j].Attributes.Count; k++)
                                    {
                                        if (cellnodes[i].ChildNodes[j].Attributes[k].Name == "candelete")
                                        {
                                            ak = true;
                                        }
                                    }
                                    if (!ak)
                                    {
                                        XmlAttribute temp = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                        temp.Value = "1";
                                        cellnodes[i].ChildNodes[j].Attributes.Append(temp);
                                    }

                                    for (int k = 0; k < cellnodes[i].ChildNodes[j].ChildNodes.Count; k++)
                                    {
                                        if (cellnodes[i].ChildNodes[j].ChildNodes[k].Name == "input")
                                        {
                                            XmlAttribute temp2 = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                            temp2.Value = "1";
                                            cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes.Append(temp2);
                                            if (flgGrid[flgGrid.RowSel, "会诊是否结束"].ToString() == "未结束") //consul_record_submite_state 会诊是否结束
                                            {
                                                cellnodes[i].ChildNodes[j].ChildNodes[k].InnerText = "";
                                            }
                                        }
                                    }


                                }
                            }
                        }
                    }
                    DataInit.filterInfo(tmpxml.DocumentElement, inPatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);        
                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();
                    text.MyDoc.Locked = true;
                    btnSavetemp.Enabled = false;
                    btnSave.Enabled = false;
                    btnNewApply.Enabled = true;
                }
            }
            catch
            { }
        }

        private void LookItem_Click_1(object sender, EventArgs e)
        {
            //string id = flgGrid[this.flgGrid.RowSel, "id"].ToString();
            //string pid = flgGrid[this.flgGrid.RowSel, "patient_id"].ToString();
            //frm_Apply_Look frm_ask = new frm_Apply_Look(id, pid);
            //frm_ask.ShowDialog();
            text.MyDoc.Locked = true;
        }

        private void tlspmnitUpdate_Click(object sender, EventArgs e)
        {
            if (App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
            {
                try
                {
                    if (this.flgGrid.RowSel >= 1)
                    {
                        if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "是")
                        {
                            App.MsgWaring("该申请已经接诊，不能修改！");
                            return;
                        }

                        btnNewApply.Enabled = false;
                        btnCancelApply.Enabled = true;
                        btnSavetemp.Enabled = true;
                        btnSave.Enabled = true;
                        btnSelect.Enabled = true;
                        issaveapply = false;
                        text.MyDoc.Locked = false;
                        flgGrid.Enabled = false;
                        if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "暂存")
                        {
                            tlspmnitDelete.Visible = true;
                            //tlspmnitSubmit.Visible = true;
                            btnSave.Enabled = true;
                            btnSavetemp.Enabled = true;
                            rdbtnNasty.Enabled = true;
                            rdbtnNormal.Enabled = true;
                        }
                        if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "已提交" && flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "是")
                        {
                            tlspmnitDelete.Visible = false;
                            //tlspmnitSubmit.Visible = false;
                            btnSave.Enabled = false;
                            btnSavetemp.Enabled = false;
                            rdbtnNasty.Enabled = false;
                            rdbtnNormal.Enabled = false;
                        }
                        if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "已提交" && flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                        {
                            tlspmnitDelete.Visible = true;
                            //tlspmnitSubmit.Visible = false;
                            btnSave.Enabled = true;
                            btnSavetemp.Enabled = false;
                            rdbtnNasty.Enabled = true;
                            rdbtnNormal.Enabled = true;
                        }
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml("<emrtextdoc/>");
                        //text.MyDoc.InpatientInfo=
                        text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                        XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>

                        //修改会诊表格解锁            
                        XmlNodeList cellnodes = tempxmldoc.GetElementsByTagName("input");
                        for (int i = 0; i < cellnodes.Count; i++)
                        {
                            if (cellnodes[i].Attributes["id"].Value == "C155B8F5157")//解锁简要病历及会诊目的文本框
                            {
                                for (int j = 0; j < cellnodes[i].Attributes.Count; j++)
                                {
                                    if (cellnodes[i].Attributes[j].Name == "candelete")
                                    {
                                        cellnodes[i].Attributes.RemoveAt(j);
                                        break;
                                    }
                                }
                            }
                            if (cellnodes[i].Attributes["id"].Value == "C1553993156")//解锁简要病历及会诊目的文本框
                            {
                                for (int j = 0; j < cellnodes[i].ParentNode.Attributes.Count; j++)
                                {
                                    if (cellnodes[i].ParentNode.Attributes[j].Name == "candelete")
                                    {
                                        cellnodes[i].ParentNode.Attributes.RemoveAt(j);
                                        break;
                                    }
                                }
                            }
                        }
                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                        text.MyDoc.ContentChanged();
                    }
                }
                catch
                { }
            }
            else
            {
                App.MsgWaring("该功能只有主治及以上级别的医师才能使用！");
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintItem_Click(object sender, EventArgs e)
        {
            text.MyDoc.PrintEdit(sender, e);
        }

        /// <summary>
        /// 菜单按钮的设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.flgGrid.RowSel >= 1)
                {
                    if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "暂存" && flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                    {
                        tlspmnitDelete.Visible = true;
                        this.PrintItem.Visible = false;
                        //tlspmnitSubmit.Visible = true;                                       
                    }
                    if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "已提交" && flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "是")
                    {
                        tlspmnitDelete.Visible = false;
                        this.PrintItem.Visible = true;
                        //tlspmnitSubmit.Visible = false;                                   
                    }
                    if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "已提交" && flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                    {
                        tlspmnitDelete.Visible = true;
                        this.PrintItem.Visible = true;
                        //tlspmnitSubmit.Visible = false;                                  
                    }
                }
            }
            catch
            { }
        }


        /// <summary>
        /// 会诊提交，并保存
        /// </summary>
        private void btnSubmited_Click(object sender, EventArgs e)
        {

            if (flgGrid.RowSel > 0)
            {
                string update = "upedate t_consultaion_apply set apply_time='" + applytime + "', set submited=N where id='" + flgGrid[flgGrid.RowSel, "id"] + "'";
                if (IsEnd())
                {
                    int count = 0;
                    try
                    {
                        count = App.ExecuteSQL(update);
                        if (count > 0)
                        {
                            App.Msg("该条记录提交成功！");
                            //btnEnd.Enabled = false;
                            //重新刷表格
                            ShowGrid();
                            this.PrintItem.Visible = true;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        App.Msg("请您选中记录！");
                    }
                }
            }
        }

        /// <summary>
        /// 授权操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改授权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
            {
                App.MsgWaring("该功能只有主治及以上级别的医师才能使用！");
                return;
            }
            if (flgGrid.RowSel > 0)
            {
                if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "修改授权")
                {
                    App.Msg("会诊修改已授权，请不要重复提交！");
                    return;
                }
                if (flgGrid[flgGrid.RowSel, "会诊是否结束"].ToString() == "结束")
                {
                    if (App.ExecuteSQL("update t_consultaion_apply set state=3 where id=" + flgGrid[flgGrid.RowSel, "id"] + "") > 0)
                    {
                        App.Msg("修改授权成功！");
                        reflesh();
                    }
                }
                else
                {
                    App.MsgWaring("会诊尚未结束！");
                }
            }
        }

        #endregion

        #region 功能函数
        /// <summary>
        /// 刷新设置
        /// </summary>
        private void reflesh()
        {
            //gbxEdit.Enabled = false;

            rdbtnNasty.Enabled = false;
            rdbtnNormal.Enabled = false;
            text.MyDoc.Locked = true;
            btnSavetemp.Enabled = false;
            flgGrid.Enabled = true;
            btnSelect.Enabled = false;
            issaveapply = true;
            btnSave.Enabled = false;
            btnCancelApply.Enabled = false;
            btnNewApply.Enabled = true;
            book_Id = "";
            CleadEditor();
            text.MyDoc.Locked = true;
            ShowGrid();

        }

        /// <summary>
        /// 初始化编辑器
        /// </summary>
        private void CleadEditor()
        {
            //try
            //{

                if (content == "")
                {
                    content = DataInit.GetDefaultTemp("133");
                }

                text.MyDoc.Us.RecordTime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                text.MyDoc.Us.Tid = 0;
                //添加文书，Ishighersign是否需要上级医师审签           
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("姓名", inPatient.Patient_Name);
                header.Add("科室", inPatient.Section_Name);
                header.Add("住院号", inPatient.PId);
                text.MyDoc.InpatientInfo = inPatient;
                text.MyDoc.PageHeader = null;
                text.MyDoc.TextSuperiorSignature = "N";
                text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
                text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                text.MyDoc.IgnoreLine = false;
                XmlDocument tempxmldoc = new XmlDocument();
                tempxmldoc.PreserveWhitespace = true;

                if (content.Contains("emrtextdoc"))
                {
                    tempxmldoc.LoadXml(content);                                     
                }
                else
                {
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    //text.MyDoc.InpatientInfo=
                    text.MyDoc.ClearContent();
                    text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                    XmlNode xmlNode2 = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                    foreach (XmlNode bodyNode in xmlNode2.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {
                            bodyNode.InnerXml = "";
                            bodyNode.InnerXml += content;
                        }
                    }                   
                }
                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");
                string datetype = App.GetSystemTime().ToString("yyyy-MM-dd");
                string datetime = App.GetSystemTime().ToString("HH:mm");
                string timexml =
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[0] + "</span>" +
                        "<span operatercreater='0'>-</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[1] + "</span>" +
                        "<span operatercreater='0'>-</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetype.Split('-')[2] + "</span>" +
                        "<span operatercreater='0'> </span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetime.Split(':')[0] + "</span>" +
                        "<span operatercreater='0'>:</span>" +
                        "<span fontname='Times New Roman' operatercreater='0'>" + datetime.Split(':')[1] + "</span>";
                //xmlNode.SelectSingleNode("//body//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input").InnerXml = timexml;\
                //设置默认请求会诊时间
                XmlNodeList list = ((XmlElement)xmlNode).GetElementsByTagName("input");
                foreach (XmlNode sd in list)
                {
                    if (sd.Attributes["name"] != null)
                    {
                        if (sd.Attributes["name"].Value == "请求会诊时间")
                        {
                            sd.InnerXml = timexml;
                        }
                        else if (sd.Attributes["name"].Value == "请求会诊科")
                        {
                            sd.InnerText = this.inPatient.Section_Name;
                        }
                        else if (sd.Attributes["name"].Value == "请求会诊医师")
                        {
                            sd.InnerText = App.UserAccount.UserInfo.User_name;
                        }
                        else if (sd.Attributes["name"].Value == "接诊科")
                        {
                            //sd.InnerText = App.UserAccount.UserInfo.User_name;
                        }
                    }
                }

                string sname = App.UserAccount.CurrentSelectRole.Section_name;
                if (sname.Contains("--"))
                {
                    sname = sname.Replace("--", ",").Split(',')[1];
                }

                //xmlNode.SelectSingleNode("//body//table[@id='C153B370132']//row[@id='C15F984D180']//cell[@id='C153B370142']//input[@id='C156B4AA159']").InnerText = sname;
                //xmlNode.SelectSingleNode("//body//table[@id='C153B370132']//row[@id='C1EBE2D29']//cell[@id='C1EBE2D31']//input[@id='C15701A1160']").InnerText = App.UserAccount.UserInfo.User_name;

                //接诊部分的表格锁定            
                XmlNodeList cellnodes = xmlNode.SelectSingleNode("//body//table[@id='C2FD671443']").ChildNodes;
                for (int i = 0; i < cellnodes.Count; i++)
                {
                    if (cellnodes[i].Name == "row")
                    {
                        for (int j = 0; j < cellnodes[i].ChildNodes.Count; j++)
                        {
                            if (cellnodes[i].ChildNodes[j].Name == "cell")
                            {
                                XmlAttribute temp = tempxmldoc.CreateAttribute("candelete"); //candelete="1"
                                temp.Value = "1";
                                cellnodes[i].ChildNodes[j].Attributes.Append(temp);
                                for (int k = 0; k < cellnodes[i].ChildNodes[j].ChildNodes.Count; k++)
                                {
                                    if (cellnodes[i].ChildNodes[j].ChildNodes[k].Name == "input")
                                    {
                                        XmlAttribute temp2 = tempxmldoc.CreateAttribute("candelete"); //candelete="1"
                                        temp2.Value = "1";
                                        cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes.Append(temp2);
                                    }
                                }
                            }
                        }
                    }
                }
                text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                text.MyDoc.ContentChanged();
            //}
            //catch (Exception ex)
            //{
            //}
        }


        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="submitetype">Y 提交 N暂存</param>
        /// <returns></returns>
        private bool InsertApply(string submitetype)
        {
            try
            {
                int consul_type = 0;       //会诊类别0普通会诊,1急会诊
                if (rdbtnNasty.Checked)
                {
                    consul_type = 1;       //急会诊
                }
                StringBuilder strBuilder = new StringBuilder();
                int MaxId = App.GenId("t_consultaion_apply", "id");
                string ISAUDIT = getAudit(recordsection_id);
                //当前申请人的科室名称             
                string Sql_Insert_Apply = "insert into t_consultaion_apply (id,apply_time,apply_name,save_name,save_id," +
                                         "apply_sectionid,apply_sectionname,consultation_type,apply_type," +
                                         "apply_userid,pid,submited,islock,is_dalete,consultation_end,consultation_content,patient_id,PATIENT_DOC_ID,CONSUL_RECORD_SECTION_ID,ISRECIEVE,CONSUL_SECTION_NAME,state,ISAUDIT)" +
                                         " values(" + MaxId + ",to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss'),'" + App.UserAccount.UserInfo.User_name + "'," +
                                         "'" + App.UserAccount.UserInfo.User_name + "','" +
                                         App.UserAccount.UserInfo.User_id + "'," +
                                         App.UserAccount.CurrentSelectRole.Section_Id + "," +
                                         "'" + App.UserAccount.CurrentSelectRole.Section_name + "'," +
                                         consul_type + ",''," +
                                         App.UserAccount.UserInfo.User_id + ",'" +
                                         inPatient.PId + "','" + submitetype + "',0,'N',0,''," +
                                         inPatient.Id + "," + book_Id + "," + recordsection_id + ",0,'" + recordsection_name + "',0,'"+ ISAUDIT + "')";

                if (App.ExecuteSQL(Sql_Insert_Apply) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改会诊申请
        /// </summary>
        private bool updateApply()
        {
            if (flgGrid.RowSel > 0)
            {
                if (!Isaccepts())
                {
                    if (Convert.ToBoolean(App.UserAccount.UserInfo.Profession_card) == true || flgGrid[flgGrid.RowSel, "save_id"].ToString() == App.UserAccount.UserInfo.User_id)
                    {
                        //会诊类别
                        int Consul_Type = 0;
                        if (rdbtnNasty.Checked)
                        {
                            Consul_Type = 1;      //急会诊
                        }
                        /*
                         *修改会诊申请 
                         */
                        string ISAUDIT = getAudit(recordsection_id);
                        string Sql_Update_Apply = "update t_consultaion_apply set consul_record_section_id=" + recordsection_id +
                                                  ",consul_section_name='" + recordsection_name + "',consultation_type=" +Consul_Type + "," +
                                                  "UPDATEBY_ID=" + App.UserAccount.UserInfo.User_id + "," +
                                                  "UPDATEBY_NAME='" + App.UserAccount.UserInfo.User_name + "'," +
                                                  "ISAUDIT='" + ISAUDIT + "'," +
                                                  "apply_time=to_timestamp('" + applytime + "','yyyy-MM-dd hh24:mi:ss') " +
                                                  " where id=" + flgGrid[flgGrid.RowSel, "id"] + "";
                        App.ExecuteSQL(Sql_Update_Apply);
                        return true;
                    }
                    else
                    {
                        App.Msg("只有会诊申请本人或者本科室上级医师可以修改！");
                    }
                }
                else
                {
                    App.Msg("接诊后，会诊申请就不能修改啦！");
                }
            }
            return false;
        }

        private string getAudit(string ksbm)
        {
            string rets = "0";
            if (!string.IsNullOrEmpty(ksbm))
            {
                DataSet ds = App.GetDataSet(" select*from T_AUDITCONFIG where KSBM='" + ksbm.Trim() + "' ");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rets = "1";
                }
            }
            return rets;
        }

        /// <summary>
        ///文书删除
        /// </summary>
        private bool deleteApply()
        {
            if (flgGrid.RowSel > 0)
            {
                //对方科室未接诊，可以删除
                if (!Isaccepts())
                {
                    int apply_id = Convert.ToInt32(flgGrid[flgGrid.RowSel, "id"]); //会诊申请ID

                    string[] sql_dels = new string[3];
                    //删除文书
                    sql_dels[0] = "delete from t_patients_doc where tid =" + Convert.ToInt32(flgGrid[flgGrid.RowSel, "PATIENT_DOC_ID"]);
                    //删除会诊申请
                    sql_dels[1] = "delete from t_consultaion_apply where id=" + apply_id;

                    //删除质控表
                    sql_dels[2] = "delete from  t_quality_text where tid=" + Convert.ToInt32(flgGrid[flgGrid.RowSel, "PATIENT_DOC_ID"]) + "";

                    if (flgGrid[flgGrid.RowSel, "提交状态"].ToString() == "已提交") //已提交的会诊,需要删除会诊单
                    {
                        //当文书提交时，验证登录者是否是会诊申请人
                        if (App.UserAccount.UserInfo.User_id == flgGrid[flgGrid.RowSel, "apply_userid"].ToString())
                        {
                            if (App.ExecuteBatch(sql_dels) > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            App.Msg("只有会诊申请本人或者本科室上级医师可以删除！");
                        }
                    }
                    else    //暂存的会诊申请
                    {
                        //当文书暂存时，书写者和管床医生都可删
                        if (App.UserAccount.UserInfo.User_id == inPatient.Sick_Doctor_Id
                            || flgGrid[flgGrid.RowSel, "save_id"].ToString() == App.UserAccount.UserInfo.User_id)
                        {
                            if (App.ExecuteBatch(sql_dels) > 0)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            App.Msg("只有会诊申请书写者或者本科室上级医师可以删除！");
                        }
                    }
                }
                else
                {
                    App.Msg("对方科室已经接诊，不能删除会诊申请了！");
                }

            }
            return false;
        }

        /// <summary>
        /// 查看会诊记录表里面，会诊科室是否已经接诊。
        /// </summary>
        /// <returns>true已接诊，false 未接诊</returns>
        public bool Isaccepts()
        {
            bool flag = false;
            if (flgGrid.RowSel != -1)
            {
                //找到当前申请id关联的会诊记录表的接诊字段，看是否已经有接诊的。
                string Sql_accepts = "select isrecieve from T_CONSULTAION_APPLY where id=" + flgGrid[flgGrid.RowSel, "id"].ToString() + "";
                DataSet ds = App.GetDataSet(Sql_accepts);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["isrecieve"].ToString() == "1")
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }

        private void ShowGrid()
        {
            string Sql_Grid = "select to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 会诊申请日期," +
                                "a.apply_sectionname 申请科室,a.apply_name 会诊申请人," +
                                "c.patient_name 患者姓名,a.pid 住院号, c.sick_bed_no 床号," +
                                "case a.consultation_type when 0 then '普通会诊' else '急会诊' end 会诊类别, " +
                                "case a.consul_record_submite_state when 0 then '未结束' else '结束' end 会诊是否结束," +
                                "case a.submited when 'N' then '暂存' else '已提交' end 提交状态," +
                                "case a.state when 0 then '未会诊' when 1 then '已会诊' when 2 then '取消接诊' when 3 then '修改授权'  else '未会诊' end 会诊状态, " +
                                "a.consul_section_name 会诊科室,a.consul_r_name 会诊医生, case isrecieve when 0 then '否' else '是' end 是否接诊," +
                                "to_char(a.consul_time,'yyyy-MM-dd hh24:mi') 会诊日期,a.apply_type,a.save_id ," +
                                "a.consul_record_section_id,a.consul_r_id,a.apply_sectionid,a.apply_userid,a.id," +
                                "a.submited,a.patient_id,a.PATIENT_DOC_ID,a.state from t_consultaion_apply a " +
                                "inner join t_in_patient c on a.patient_id=c.id " +
                                "where a.is_dalete!='Y' and a.patient_id ='" + inPatient.Id + "' order by a.apply_time desc";
            DataSet ds = App.GetDataSet(Sql_Grid);
            flgGrid.DataSource = ds.Tables[0].DefaultView;
            flgGrid.Cols["consul_record_section_id"].Visible = false;
            flgGrid.Cols["consul_r_id"].Visible = false;
            flgGrid.Cols["apply_sectionid"].Visible = false;
            flgGrid.Cols["apply_userid"].Visible = false;
            flgGrid.Cols["id"].Visible = false;
            flgGrid.Cols["submited"].Visible = false;
            flgGrid.Cols["patient_id"].Visible = false;
            flgGrid.Cols["save_id"].Visible = false;
            flgGrid.Cols["apply_type"].Visible = false;
            flgGrid.Cols["会诊是否结束"].Visible = false;
            flgGrid.Cols["PATIENT_DOC_ID"].Visible = false;
            flgGrid.Cols["state"].Visible = false;
            SetRowsColor(flgGrid);
            flgGrid.Select(-1, -1);
        }

        /// <summary>
        /// 设置单元格颜色
        /// </summary>
        /// <param name="fg"></param>
        private void SetRowsColor(C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            if (fg != null)
            {
                for (int i = 0; i < fg.Rows.Count; i++)
                {
                    if (fg[i, "会诊类别"].ToString() == "急会诊")
                    {
                        //急会诊 红色
                        fg.Rows[i].StyleNew.ForeColor = Color.Red;
                    }
                    if (fg[i, "提交状态"].ToString() == "暂存")
                    {
                        //暂存 蓝色
                        fg.Rows[i].StyleNew.BackColor = Color.FromArgb(0, 176, 240);
                    }
                    if (fg[i, "state"].ToString() == "2")
                    {
                        //取消接诊 黄色
                        fg.Rows[i].StyleNew.BackColor = Color.Yellow;
                    }
                    if (fg[i, "state"].ToString() == "3")
                    {
                        //对方修改授权  橙色
                        fg.Rows[i].StyleNew.BackColor = Color.Orange;
                    }
                }


            }
        }

        /// <summary>
        /// 得到所有可用的科室
        /// </summary>
        /// <returns>返回一张两列，sid,section_Nmae的DataTable</returns>
        public DataTable getAllSection()
        {
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_GetAllSection);
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public bool isSameText(string Target, string[] arr)
        {
            bool flag = false;
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == Target)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 判断listbox中是否存在相同的值，相同返回true,否则返回false.
        /// </summary>
        /// <param name="item">新添加的项</param>
        /// <param name="Litems">ListBox项的集合</param>
        /// <returns>返回true,false</returns>
        public bool isSameText(object item, ListBox.ObjectCollection Litems)
        {
            bool flag = false;
            if (Litems.Count > 0)
            {
                for (int i = 0; i < Litems.Count; i++)
                {
                    ListItem Listitem = Litems[i] as ListItem;
                    if (Listitem.Id == item.ToString())
                    {
                        flag = true;
                        //App.Msg("已经存在相同的科室！");
                        break;
                    }
                }
            }
            return flag;
        }



        /// <summary>
        /// 获得当前表格选中的行的数据
        /// </summary>
        private void getSelGrid()
        {
            if (flgGrid.RowSel > 0)
            {
                if (flgGrid[flgGrid.RowSel, "id"].ToString() != Apply_Id)
                {
                    Apply_Id = flgGrid[flgGrid.RowSel, "id"].ToString();
                    if (getDateByGrid("会诊类别", flgGrid[flgGrid.RowSel, "id"]).Equals("普通会诊"))
                    {
                        rdbtnNormal.Checked = true;
                        rdbtnNasty.Checked = false;
                    }
                    else
                    {
                        rdbtnNormal.Checked = false;
                        rdbtnNasty.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 获取表格里面当前行，某一列的有值的一条数据。
        /// </summary>
        /// <param name="ColumnName">列名</param>
        /// <returns>该列的值</returns>
        private object getDateByGrid(string ColumnName, object Id)
        {
            object obj = null;
            for (int i = flgGrid.RowSel; i > 0; i--)
            {
                if (flgGrid[i, "id"].Equals(Id))
                {
                    if (flgGrid[i, ColumnName].ToString() != "")
                    {
                        obj = flgGrid[i, ColumnName];
                        break;
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// 根据当前行的申请id,得到所有会诊科室，会诊医生数据
        /// </summary>
        /// <param name="ColumnName">列名</param>
        /// <returns>集合</returns>
        private DataTable getDateByGrid(string Id)
        {
            /*
             *根据申请id，得到改id所有的会诊科室，会诊医生。 
             */
            string Sql_SectAndDoctByApplyId = "select b.consul_record_section_id,b.consul_section_name,b.consul_r_id,b.consul_r_name" +
                                              " from t_consultaion_apply a" +
                                              " inner join t_consultaion_record b on a.id = b.apply_id" +
                                              " where a.id =" + Id + " ";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_SectAndDoctByApplyId);
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        ///  获取当前申请id邀请的会诊科室数目。
        /// </summary>
        /// <param name="Id">申请id</param>
        /// <returns>邀请科室数目</returns>
        private int getCount(object Id)
        {
            int i = 0;
            for (int j = 0; j < flgGrid.Rows.Count; j++)
            {
                if (flgGrid[j, "id"].Equals(Id))
                {
                    i++;
                }
            }
            return i;
        }


        private static bool IsEnd()
        {
            bool flag = true;
            //查看当前会诊申请的会诊意见是否全部提交
            string sql = "select consul_record_submite_state from t_consultaion_record where apply_id=1";
            DataSet ds = App.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[0][0].ToString() == "0")
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

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
            //else
            //{
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
            //}
            return flag;
        }

        private string[] GetPostAndPosition(string user_id)
        {
            string[] arr = new string[2];
            //获取当期用户信息的职务，职称。
            string Sql_UserInof_Teach_Post = "select u_tech_post,u_position from t_userinfo where user_id=" + user_id + "";
            DataSet ds = App.GetDataSet(Sql_UserInof_Teach_Post);
            if (ds != null)
            {
                DataTable dt_Teach_Post = ds.Tables[0];
                //职务
                arr[0] = dt_Teach_Post.Rows[0]["u_position"].ToString();
                //职称
                arr[1] = dt_Teach_Post.Rows[0]["u_tech_post"].ToString();
                return arr;
            }
            return null;
        }
        #endregion

    }
}