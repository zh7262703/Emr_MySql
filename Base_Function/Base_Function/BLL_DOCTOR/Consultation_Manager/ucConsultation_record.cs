using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
//using Bifrost_Doctor.CommonClass;

using TextEditor;
using Base_Function.BASE_COMMON;
using Bifrost.HisInstance;
using Base_Function.MODEL;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class ucConsultation_record : UserControl
    {
        public delegate void RefEventHandler(object sender, Child_EventArgs e);
        //浏览文书
        public event RefEventHandler browse_Book;
        private DataTable dt_Jobtitle = new DataTable();
        private frmText text;
        private InPatientInfo inPatient;
        private string Id = "";//会诊ID
        Operater operater = new Operater();

        public ucConsultation_record()
        {
            InitializeComponent();
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
        /// 刷新表格
        /// </summary>
        /// <returns></returns>
        public DataTable ShowGrid()
        {
            /*
             *查出当前科室的所有会诊记录 
             */
            string sql = "select a.id,a.write_r_id," +
                         "d.id patient_id,a.consul_record_section_id,c.section_name 会诊申请科室,(case a.consultation_end when 1 then '是' else '否' end) 会诊是否结束,(case  when a.consultation_type=1 then '急会诊' when a.consultation_type=0 then '普通会诊' else '其他' end) 会诊类别," +
                         "to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请时间,d.patient_name 患者姓名,d.pid 住院号,(case  when d.gender_code='0' then '男' when d.gender_code='1' then '女' else '其他' end) 性别," +
                         "d.age 年龄,d.sick_bed_no 床号,e.user_name 申请医生,(case  when a.isrecieve=1 then '是'   else '否' end) 是否接诊," +
                         "a.consul_r_name 会诊医生,(case a.state when 0 then  '未会诊' when 1 then '已会诊' when 2 then '取消会诊' when 3 then '修改授权' else '未会诊' end)会诊状态," +
                         "(case a.consul_record_submite_state when 1 then '是' else '否' end) 会诊意见是否提交,to_char(a.consul_time,'yyyy-MM-dd hh24:mi') 会诊答复时间,a.patient_doc_id " +
                         "from t_consultaion_apply a inner join t_in_patient d on a.patient_id=d.id inner join t_userinfo e on a.apply_userid=e.user_id " +
                         "inner join t_sectioninfo c on a.apply_sectionid=c.sid where consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.is_dalete='N' and a.submited='Y' order by a.apply_time desc";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                dt = ds.Tables[0];

            }
            return dt;
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        private void RefGrid()
        {
            try
            {
                /*
                 *查出当前科室的所有会诊记录 
                 */
                string sql = "select a.id,a.write_r_id," +
                             "d.id patient_id,a.consul_record_section_id,c.section_name 会诊申请科室,(case a.consultation_end when 1 then '是' else '否' end) 会诊是否结束,(case  when a.consultation_type=1 then '急会诊' when a.consultation_type=0 then '普通会诊' else '其他' end) 会诊类别," +
                             "to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请时间,d.patient_name 患者姓名,d.pid 住院号,(case  when d.gender_code='0' then '男' when d.gender_code='1' then '女' else '其他' end) 性别," +
                             "d.age 年龄,d.sick_bed_no 床号,e.user_name 申请医生,(case  when a.isrecieve=1 then '是'   else '否' end) 是否接诊, (case  when a.isaudit='1' then '未审核'   when a.isaudit='2' then '已审核' else '无需审核' end) 审核状态," +
                             "a.consul_r_name 会诊医生,(case a.state when 0 then  '未会诊' when 1 then '已会诊' when 2 then '取消会诊' when 3 then '修改授权' else '未会诊' end)会诊状态," +
                             "(case a.consul_record_submite_state when 1 then '是' else '否' end) 会诊意见是否提交,to_char(a.consul_time,'yyyy-MM-dd hh24:mi') 会诊答复时间,a.patient_doc_id " +
                             "from t_consultaion_apply a inner join t_in_patient d on a.patient_id=d.id inner join t_userinfo e on a.apply_userid=e.user_id " +
                             "inner join t_sectioninfo c on a.apply_sectionid=c.sid where consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.is_dalete='N' and a.submited='Y' order by a.apply_time desc";
                flgGrid.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;
                flgGrid.Cols["id"].Visible = false;
                flgGrid.Cols["consul_record_section_id"].Visible = false;
                flgGrid.Cols["patient_doc_id"].Visible = false;
                flgGrid.Cols["会诊是否结束"].Visible = false;
                //flgGrid.Cols["会诊记录序号"].Visible = false;
                flgGrid.Cols["patient_id"].Visible = false;
                //flgGrid.Cols["会诊意见是否提交"].Visible = false;
                flgGrid.Cols["write_r_id"].Visible = false;
                SetToolbar();
                SetRowsColor(flgGrid);
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }

        

        private void ucConsultation_record_Load(object sender, EventArgs e)
        {
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).EndInit();//RefGrid()执行前,一定要执行flgGrid初始化
            RefGrid();
            //显示会诊单
            text = new frmText(1724, 0, 0, "会诊记录", 0, null, true, true, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"), "");
            text.MyDoc.TextSuperiorSignature = "N";
            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
            text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
            text.MyDoc.IgnoreLine = false;
            text.MyDoc.Locked = true;
            text.Dock = DockStyle.Fill;
            pnlDoc.Controls.Add(text);
            flgGrid_Click(sender, e);
            cboConsulTimeType.SelectedIndex = 0;
            cboConsulType.SelectedIndex = 0;
            flgGrid.AllowEditing = false;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.AllowUserToAddRows = false;
            //string sql_Jobtitle = "select * from t_in_doc_jobtitle";
            //dt_Jobtitle = App.GetDataSet(sql_Jobtitle).Tables[0];
            //DataTable dt = null;
            //if (flgGrid.Rows.Count > 1)
            //{
            //    //查看当前科室的当前会诊记录id的接诊状态是否已经为接诊
            //    string Sql_Accept = "select isrecieve,consul_r_id from t_consultaion_record where apply_id=" + flgGrid[flgGrid.RowSel, "apply_id"] +
            //                      "and consul_record_section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "";
            //    dt = App.GetDataSet(Sql_Accept).Tables[0];
            //    string Isrecieve = dt.Rows[0]["isrecieve"].ToString();
            //    string Consul_r_id = dt.Rows[0]["consul_r_id"].ToString();
            //    string Sql_accept = null;
            //    if (Isrecieve == "0")
            //    {
            //        btnAccepts.Enabled = true;
            //    }
            //    else
            //    {
            //        if (flgGrid[flgGrid.RowSel, "consul_r_id"].ToString() == App.UserAccount.UserInfo.User_id)
            //        {

            //            btnSave.Enabled = false;
            //            btnSaveing.Enabled = false;
            //        }
            //    }
            //}

        }
        /// <summary>
        /// 未接诊的4个按钮的状态，接诊亮着
        /// </summary>
        private void Receive()
        {
            btnAccepts.Enabled = true;
            btnCancel.Enabled = false;
            btnSaveing.Enabled = false;
            btnSave.Enabled = false;
        }
        /// <summary>
        /// 已接诊状态，接诊不亮
        /// </summary>
        private void Received()
        {
            btnAccepts.Enabled = false;
            btnCancel.Enabled = true;
            btnSaveing.Enabled = true;
            btnSave.Enabled = true;
        }
        /// <summary>
        /// 接诊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (flgGrid.RowSel > 0)
                {

                    if (flgGrid[flgGrid.RowSel, "审核状态"].ToString() == "未审核")
                    {
                        App.Msg("需要审核后方可接诊！");
                        return;
                    }

                    //if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "取消会诊")
                    //{
                    //    App.Msg("会诊已取消！");
                    //    return;
                    //}
                    if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                    {
                        //修改当前会诊记录id的接诊状态为接诊
                        string Sql_accept = "update t_consultaion_apply set isrecieve =1,consul_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                            "consul_r_name='" + App.UserAccount.UserInfo.User_name + "' where id=" + Id + "";
                        int count = App.ExecuteSQL(Sql_accept);
                        if (count > 0)
                        {
                            btnSaveing.Enabled = true;
                            btnAccepts.Enabled = false;
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                            App.Msg("接诊成功，请您填写会诊记录！");
                            operater = Operater.Add;
                            text.MyDoc.Locked = false;
                            RefGrid();

                            /*
                             * 接诊部分设置为可操作的
                             */
                        }
                        else
                        {
                            btnAccepts.Enabled = true;
                            btnSave.Enabled = false;
                            btnSaveing.Enabled = false;
                            App.Msg("接诊操作失败，请您与管理员联系！");
                        }



                    }
                    //刷新表格
                   // RefGrid();
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
        /// 初始化编辑器
        /// </summary>
        private void CleadEditor(XmlNodeList cellnodes)
        {

            //接诊部分解锁
            for (int i = 0; i < cellnodes.Count; i++)
            {
                if (cellnodes[i].Name == "row")
                {
                    for (int j = 0; j < cellnodes[i].ChildNodes.Count; j++)
                    {
                        if (cellnodes[i].ChildNodes[j].Name == "cell")
                        {
                            for (int k1 = 0; k1 < cellnodes[i].ChildNodes[j].Attributes.Count; k1++)
                            {
                                if (cellnodes[i].ChildNodes[j].Attributes[k1].Name == "candelete")
                                {
                                    cellnodes[i].ChildNodes[j].Attributes.Remove(cellnodes[i].ChildNodes[j].Attributes[k1]);
                                }
                            }
                            for (int k = 0; k < cellnodes[i].ChildNodes[j].ChildNodes.Count; k++)
                            {
                                if (cellnodes[i].ChildNodes[j].ChildNodes[k].Name == "input")
                                {
                                    for (int k1 = 0; k1 < cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes.Count; k1++)
                                    {
                                        if (cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes[k1].Name == "candelete")
                                        {
                                            cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes.Remove(cellnodes[i].ChildNodes[j].ChildNodes[k].Attributes[k1]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgGrid.RowSel > 0)
                {
                    //if (!isEnd())
                    //{
                    //txtRecord_Content.ReadOnly = false;

                    //验证文书内容是否正确
                    XmlDocument xmldocument = new XmlDocument();
                    xmldocument.PreserveWhitespace = true;//是否忽略空格
                    xmldocument.LoadXml(text.MyDoc.GetDocXml());
                    XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");//C15F984D182
                    string recordAnswer = "";//bodynode.SelectSingleNode("//table[@id='C1599E84162']//row[@id='C15F984D182']//cell[@id='C1599E84166']//input[@name='会诊答复']").InnerText;
                    string applytime = "";//DataInit.GetTimeFromXml(bodynode.SelectSingleNode("//table[@id='C153B370132']//row[@id='C15F984D177']//cell[@id='C153B370134']//input[@name='请求会诊时间']"));
                    string recordtime = "";// DataInit.GetTimeFromXml(bodynode.SelectSingleNode("//table[@id='C1599E84162']//row[@id='C15F984D181']//cell[@id='C1599E84164']//input[@name='接诊日期']"));

                    XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");
                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "会诊答复")
                            {
                                recordAnswer = sd.InnerText.Trim();
                            }
                            else if (sd.Attributes["name"].Value == "请求会诊时间")
                            {
                                applytime = sd.InnerText.Replace('，', ' ');
                            }
                            else if (sd.Attributes["name"].Value == "接诊日期")
                            {
                                recordtime = sd.InnerText.Replace('，', ' ');
                                sd.InnerXml = DataInit.TimeToXml(recordtime);
                            }
                            //else if (sd.Attributes["name"].Value == "接诊医生签名")
                            //{
                            //    sd.InnerText = App.UserAccount.UserInfo.User_name; 
                            //}
                        }
                    }
                    if (recordAnswer == "")
                    {
                        App.Msg("请填写会诊答复内容！");
                        return;
                    }
                    if (recordtime == "")
                    {
                        App.Msg("请选择会诊答复时间！");
                        return;
                    }
                    else if (Convert.ToDateTime(applytime).ToShortDateString() != Convert.ToDateTime(recordtime).ToShortDateString())
                    {
                        if (Convert.ToDateTime(applytime) > Convert.ToDateTime(recordtime))
                        {
                            App.Msg("会诊答复时间应大于申请时间！");
                            return;
                        }
                    }
                    else if (flgGrid[flgGrid.RowSel, "会诊类别"].ToString() == "急会诊" && Convert.ToDateTime(applytime).AddDays(0.25) < Convert.ToDateTime(recordtime))
                    {
                        App.Msg("急会诊答复时间应在申请时间之后6小时内！");
                        return;
                    }
                    else if (flgGrid[flgGrid.RowSel, "会诊类别"].ToString() == "普通会诊" && Convert.ToDateTime(applytime).AddDays(2) < Convert.ToDateTime(recordtime))
                    {
                        App.Msg("普通会诊答复时间应在申请时间之后48小时内！");
                        return;
                    }
                    string sname = App.UserAccount.CurrentSelectRole.Section_name;
                    if (sname.Contains("--"))
                    {
                        sname = sname.Replace("--", ",").Split(',')[1];
                    }
                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "接诊科")
                            {
                                sd.InnerText = sname; //自动插入提交者科室 App.UserAccount.CurrentSelectRole.Section_name;
                            }
                            else if (sd.Attributes["name"].Value == "接诊医师签名")//接诊医师签名
                            {
                                if (sd.InnerText.Length == 0)
                                {
                                    sd.InnerText = App.UserAccount.UserInfo.User_name;
                                }
                            }
                        }
                    }

                    //bodynode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D183']//cell[@id='C1599E84169']//input[@id='C15CFC93175']").InnerText = sname;
                    //bodynode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C23CAA834']//cell[@id='C23CAA836']//input[@id='C15D7889176']").InnerText = App.UserAccount.UserInfo.User_name;

                    //text.MyDoc.FromXML(xmldocument.DocumentElement);
                    //text.MyDoc.saveDocument(sender, e);
                    text.MyDoc.FromXML(xmldocument.DocumentElement);
                    DataInit.CurrentFrmText = text;
                    DataInit.saveDocument(sender, e);
                    //text.MyDoc.Us.RecordTime = Convert.ToDateTime(recordtime).ToString("yyyy-MM-dd HH:mm");
                    /*
                    *保存会诊记录信息 
                    */
                    string Sql_Save_Record = "update t_consultaion_apply set write_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                             "write_r_name='" + App.UserAccount.UserInfo.User_name + "'," +
                                             "consul_time=to_timestamp('" + recordtime + "','yyyy-MM-dd hh24:mi:ss')," +
                                             "consul_record_submite_state=1,state=1 where id=" + Id + "";
                    string sql_update_DoctorSign = "update t_patients_doc set havedoctorsign='Y' where tid=" + flgGrid[flgGrid.RowSel, "patient_doc_id"].ToString();
                    string[] sqls = new string[2];
                    sqls[0] = Sql_Save_Record;
                    sqls[1] = sql_update_DoctorSign;
                    int count = App.ExecuteBatch(sqls);
                    if (count > 0)
                    {
                        App.ExecuteSQL("update t_quality_text set textname=textname || '" + flgGrid[flgGrid.RowSel, "会诊类别"].ToString() + "' where tid=" + text.MyDoc.Us.Tid + "");
                        RefGrid();
                        flgGrid_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("会诊记录操作失败！");
                    }
                }
                //}
                else
                {
                    App.Msg("你没有选中任何的会诊记录！");
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 暂存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveing_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgGrid.RowSel > 0)
                {
                    //if (!isEnd())
                    //{

                    //验证文书内容是否正确
                    XmlDocument xmldocument = new XmlDocument();
                    xmldocument.PreserveWhitespace = true;//是否忽略空格
                    xmldocument.LoadXml(text.MyDoc.GetDocXml());
                    XmlNode bodynode = xmldocument.ChildNodes[0].SelectSingleNode("body");//C15F984D182
                    string recordAnswer = "";//会诊答复
                    string applytime = "";//请求会诊时间
                    string recordtime = "";//接诊日期


                    XmlNodeList list = ((XmlElement)bodynode).GetElementsByTagName("input");
                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "会诊答复")
                            {
                                recordAnswer = sd.InnerText.Trim();
                            }
                            else if (sd.Attributes["name"].Value == "请求会诊时间")
                            {
                                applytime = sd.InnerText.Replace('，', ' ');

                            }
                            else if (sd.Attributes["name"].Value == "接诊日期")
                            {
                                if (sd.InnerText != "双击选择日期")
                                {
                                    recordtime = sd.InnerText.Replace('，', ' ');
                                    sd.InnerXml = DataInit.TimeToXml(recordtime);
                                }
                            }
                        }
                    }
                    if (recordAnswer == "")
                    {
                        App.Msg("请填写会诊答复内容！");
                        return;
                    }
                    if (recordtime == "")
                    {
                        App.Msg("请选择会诊答复时间！");
                        return;
                    }
                    else if (Convert.ToDateTime(applytime) > Convert.ToDateTime(recordtime))
                    {
                        App.Msg("会诊答复时间应大于申请时间！");
                        return;
                    }
                    else if (flgGrid[flgGrid.RowSel, "会诊类别"].ToString() == "急会诊" && Convert.ToDateTime(applytime).AddDays(1) < Convert.ToDateTime(recordtime))
                    {
                        App.Msg("急会诊答复时间应在申请时间之后24小时内！");
                        return;
                    }
                    else if (flgGrid[flgGrid.RowSel, "会诊类别"].ToString() == "普通会诊" && Convert.ToDateTime(applytime).AddDays(2) < Convert.ToDateTime(recordtime))
                    {
                        App.Msg("普通会诊答复时间应在申请时间之后48小时内！");
                        return;
                    }

                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "接诊科")
                            {
                                sd.InnerText = App.UserAccount.CurrentSelectRole.Section_name; //自动插入提交者科室
                            }
                            else if (sd.Attributes["name"].Value == "接诊医师签名")//接诊医师签名
                            {
                                if (sd.InnerText.Length == 0)
                                {
                                    sd.InnerText = App.UserAccount.UserInfo.User_name;
                                }
                            }
                        }
                    }

                    //string sname = App.UserAccount.CurrentSelectRole.Section_name;
                    //if (sname.Contains("--"))
                    //{
                    //    sname = sname.Replace("--", ",").Split(',')[1];
                    //}
                    //bodynode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D183']//cell[@id='C1599E84169']//input[@id='C15CFC93175']").InnerText = sname;
                    //bodynode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D183']//cell[@id='C1599E84170']//input[@id='C15D7889176']").InnerText = App.UserAccount.UserInfo.User_name;
                    //bodynode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C23CAA834']//cell[@id='C23CAA836']//input[@id='C15D7889176']").InnerText = App.UserAccount.UserInfo.User_name;
                    //text.MyDoc.FromXML(xmldocument.DocumentElement);
                    //text.MyDoc.saveDocument(sender, e);
                    DataInit.CurrentFrmText = text;
                    DataInit.saveDocument(sender, e);
                    /*
                   *保存会诊记录信息 
                   */
                    string Sql_Save_Record = "update t_consultaion_apply set write_r_id=" + App.UserAccount.UserInfo.User_id + "," +
                                             "write_r_name='" + App.UserAccount.UserInfo.User_name + "'," +
                        //"consul_time=to_timestamp('" + recordtime + "','yyyy-MM-dd hh24:mi:ss')," +
                                             "consul_record_submite_state=0 where id=" + Id + "";
                    int count = App.ExecuteSQL(Sql_Save_Record);
                    if (count > 0)
                    {
                        RefGrid();
                        flgGrid_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("会诊记录操作失败！");
                    }
                }
                //}
                else
                {
                    App.Msg("你没有选中任何的会诊记录！");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SetDoc()
        {
            #region 取出文书


            string sql_Con_Content = "select patients_doc,textname,consultaion_record_id  from t_patients_doc where textkind_id=1724 " +
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
                                case "接诊时间":
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
        /// <summary>
        /// 取消接诊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "否")
            {
                if (App.Ask("确定要取消该会诊吗？"))
                {
                    //清空会诊答复内容和答复时间
                    XmlDocument document = new XmlDocument();
                    document.PreserveWhitespace = true;
                    document.LoadXml("<emrtextdoc/>");
                    text.MyDoc.ToXML(document.DocumentElement);
                    XmlNode xmlNode = document.SelectSingleNode("emrtextdoc");

                    XmlNodeList list = ((XmlElement)xmlNode).GetElementsByTagName("input");
                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "会诊答复")
                            {
                                sd.InnerText = "";//清空会诊答复
                            }
                            else if (sd.Attributes["name"].Value == "接诊医师")
                            {
                                sd.InnerText = "";//清空接诊医生
                            }
                            else if (sd.Attributes["name"].Value == "接诊日期")
                            {
                                sd.InnerText = "";//清空接诊时间
                            }
                        }
                    }
                    //xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D183']//cell[@id='C1599E84170']//input[@id='C1553993156']").InnerText = "";//清空接诊时间
                    //xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D182']//cell[@id='C1599E84166']//input[@id='C15B29D7173']").InnerText = "";//清空会诊答复
                    ////xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C15F984D183']//cell[@id='C1599E84169']//input[@id='C15CFC93175']").InnerText = "";//清空接诊科
                    //xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']//row[@id='C23CAA834']//cell[@id='C23CAA836']//input[@id='C15D7889176']").InnerText = "";//清空接诊医生
                    text.MyDoc.FromXML(document.DocumentElement);//重新加载XML
                    text.MyDoc.ContentChanged();
                    //text.MyDoc.saveDocument(sender, e);//保存文书
                    DataInit.saveDocument(sender, e);
                    //接诊状态修改为未接诊状态
                    string sql_Cancle = " update t_consultaion_apply  set isrecieve =0,state=2,consul_r_name='',consul_r_id='' where id=" + Id + " ";
                    if (App.ExecuteSQL(sql_Cancle) > 0)
                    {
                        App.Msg("会诊已经取消！");
                    }
                    RefGrid();
                }
            }
            else
            {
                App.Msg("会诊答复已提交，无法取消！");
            }
        }
        /// <summary>
        /// 会诊是否结束，true结束,false 未结束。
        /// </summary>
        /// <returns></returns>
        //public bool isEnd()
        //{
        //    bool flag = false;
        //    if (flgGrid[flgGrid.RowSel, "会诊是否结束"].ToString() == "是") //会诊结束
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}
        private void flgGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (flgGrid.RowSel > 0)
                {
                    this.Id = flgGrid[flgGrid.RowSel, "id"].ToString();
                    SetToolbar();
                    if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "取消会诊")
                    {
                        btnAccepts.Enabled = true;
                        btnSave.Enabled = false;
                        btnSaveing.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                    else if (flgGrid[flgGrid.RowSel, "是否接诊"].ToString() == "否")
                    {
                        btnAccepts.Enabled = true;
                        btnSave.Enabled = false;
                        btnSaveing.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToBoolean(App.UserAccount.UserInfo.Profession_card) == true)
                        {
                            if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "是")
                            {
                                btnAccepts.Enabled = false;
                                btnSave.Enabled = false;
                                btnSaveing.Enabled = false;
                                btnCancel.Enabled = false;
                            }
                            else
                            {
                                Received();
                                text.MyDoc.Locked = false;
                            }
                        }
                        else
                        {
                            btnAccepts.Enabled = false;
                            btnSave.Enabled = false;
                            btnSaveing.Enabled = false;
                            btnCancel.Enabled = false;
                        }
                        //}
                    }
                    /*
                     *查出会诊单和病人基本信息
                     * 
                     */
                    string sql_Content = "select * from t_patients_doc where tid=" + flgGrid[flgGrid.RowSel, "patient_doc_id"].ToString();//查询会诊单
                    string Sql_ByPId = " select * from t_in_patient a where id ='" + flgGrid[flgGrid.RowSel, "patient_id"] + "'";//查询病人基本信息

                    Class_Table[] tabs = new Class_Table[2];
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

                    DataSet ds = App.GetDataSet(tabs);
                    //设置病人基本信息
                    this.inPatient = null;
                    this.inPatient = DataInit.GetInpatientInfoByPid(ds.Tables["TabInpatient"]);
                    text.MyDoc.Us.InpatientInfo = inPatient;//病人基本信息
                    text.MyDoc.Us.Tid = Convert.ToInt32(flgGrid[flgGrid.RowSel, "patient_doc_id"]);//文书ID
                    text.MyDoc.PageHeader = null;//= null 他会重新new 一个 获取新的病人信息
                    string content = App.DownLoadFtpPatientDoc(flgGrid[flgGrid.RowSel, "patient_doc_id"].ToString() + ".xml", inPatient.Id.ToString());//ds.Tables["TabContent"].Rows[0]["patients_doc"].ToString();//文书内容
                    if (content == "")
                    {
                        content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + flgGrid[flgGrid.RowSel, "patient_doc_id"].ToString() + "", 0, "CONTENT");
                    }
                    System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    tmpxml.LoadXml(content);
                    XmlNode xmlNode = tmpxml.SelectSingleNode("emrtextdoc");
                    //设置默认的接诊时间
                    string datetype = App.GetSystemTime().ToString("yyyy-MM-dd");
                    string datetime = App.GetSystemTime().ToString("HH:mm");
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
                    XmlNodeList list = ((XmlElement)xmlNode).GetElementsByTagName("input");
                    foreach (XmlNode sd in list)
                    {
                        if (sd.Attributes["name"] != null)
                        {
                            if (sd.Attributes["name"].Value == "接诊日期" && sd.InnerXml == "")
                            {
                                sd.InnerXml = timexml;
                            }
                        }
                    }
                    //申请部分的表格锁定            
                    XmlNodeList cellnodes = xmlNode.SelectSingleNode("//body").ChildNodes;
                    for (int t = 0; t < cellnodes.Count; t++)//body
                    {
                        if (cellnodes[t].Name == "table")//table
                        {
                            for (int i = 0; i < cellnodes[t].ChildNodes.Count; i++)
                            {
                                if (cellnodes[t].ChildNodes[i].Name == "row")//row
                                {
                                    for (int j = 0; j < cellnodes[t].ChildNodes[i].ChildNodes.Count; j++)
                                    {
                                        if (cellnodes[t].ChildNodes[i].ChildNodes[j].Name == "cell")
                                        {
                                            #region 锁定单元格
                                            bool ak = false;
                                            for (int k = 0; k < cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Count; k++)
                                            {
                                                if (cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes[k].Name == "candelete")
                                                {
                                                    ak = true;
                                                }
                                            }
                                            if (!ak)
                                            {
                                                XmlAttribute temp = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                                temp.Value = "1";
                                                cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Append(temp);
                                            }
                                            #endregion
                                            #region 锁定input
                                            for (int k = 0; k < cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
                                            {
                                                if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Name == "input")
                                                {
                                                    //移除接诊日期的cell锁定
                                                    if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "接诊日期")
                                                    {

                                                        for (int c = 0; c < cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Count; c++)
                                                        {
                                                            if (cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes[c].Name == "candelete")
                                                            {
                                                                cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.RemoveAt(c);
                                                                //XmlAttribute temp2 = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                                                //temp2.Value = "1";
                                                                //cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Append(temp2);
                                                            }
                                                        }
                                                    }
                                                    if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "会诊答复" ||
                                                        cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "会诊医院" ||
                                                        cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "接诊医师签名" ||
                                                        cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "接诊时间")
                                                    {
                                                        for (int c = 0; c < cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.Count; c++)
                                                        {
                                                            if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes[c].Name == "candelete")
                                                            {
                                                                cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.RemoveAt(c);//移除会诊答复的锁定属性
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        XmlAttribute temp = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                                        temp.Value = "1";
                                                        cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.Append(temp);
                                                    }
                                                }
                                            }
                                            #endregion
                                            #region 锁定input
                                            //for (int k = 0; k < cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
                                            //{
                                            //    if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Name == "input")
                                            //    {
                                            //        //移除接诊日期的cell锁定 
                                            //        if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "接诊日期")
                                            //        {

                                            //            for (int c = 0; c < cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Count; c++)
                                            //            {
                                            //                if (cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes[c].Name == "candelete")
                                            //                {
                                            //                    //cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.RemoveAt(c);
                                            //                    XmlAttribute temp2 = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                            //                    temp2.Value = "1";
                                            //                    cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Append(temp2);
                                            //                }
                                            //            }
                                            //        }

                                            //        if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value == "接诊医师签名")
                                            //        {

                                            //            for (int c = 0; c < cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Count; c++)
                                            //            {
                                            //                if (cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes[c].Name == "candelete")
                                            //                {
                                            //                    //cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.RemoveAt(c);
                                            //                    XmlAttribute temp2 = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                            //                    temp2.Value = "1";
                                            //                    cellnodes[t].ChildNodes[i].ChildNodes[j].Attributes.Append(temp2);
                                            //                }
                                            //            }
                                            //        }
                                            //        if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes["name"].Value != "会诊答复")
                                            //        {
                                            //            XmlAttribute temp = tmpxml.CreateAttribute("candelete"); //candelete="1"
                                            //            temp.Value = "1";
                                            //            cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.Append(temp);
                                            //        }
                                            //        else
                                            //        {
                                            //            for (int c = 0; c < cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.Count; c++)
                                            //            {
                                            //                if (cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes[c].Name == "candelete")
                                            //                {
                                            //                    cellnodes[t].ChildNodes[i].ChildNodes[j].ChildNodes[k].Attributes.RemoveAt(c);//移除会诊答复的锁定属性
                                            //                }
                                            //            }

                                            //        }
                                            //    }
                                            //}
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //cellnodes = xmlNode.SelectSingleNode("//body//table[@id='C1599E84162']").ChildNodes;
                    //CleadEditor(cellnodes);

                    DataInit.filterInfo(tmpxml.DocumentElement, inPatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);

                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();
                    if (!App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))//主治以上才可以接诊
                    {
                        btnAccepts.Enabled = false;
                        btnSave.Enabled = false;
                        btnSaveing.Enabled = false;
                        btnCancel.Enabled = false;
                        修改ToolStripMenuItem.Visible = false;
                        查看病例ToolStripMenuItem.Visible = false;
                        刷新ToolStripMenuItem.Visible = true;
                    }
                }
                else
                {
                    修改ToolStripMenuItem.Visible = false;
                    查看病例ToolStripMenuItem.Visible = false;
                    刷新ToolStripMenuItem.Visible = true;
                }
            }
            //}
            catch (System.Exception ex)
            {

            }
        }
        private void SetToolbar()
        {
            刷新ToolStripMenuItem.Visible = true;
            查看病例ToolStripMenuItem.Visible = true;
            if (flgGrid.Rows.Count > 1)
            {
                if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "取消会诊")
                {
                    修改ToolStripMenuItem.Visible = false;
                }
                else if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "修改授权")
                {
                    修改ToolStripMenuItem.Visible = true;
                }
                else if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "未会诊")
                {
                    修改ToolStripMenuItem.Visible = false;
                }
                else if (flgGrid[flgGrid.RowSel, "会诊状态"].ToString() == "已会诊")
                {

                    if (flgGrid[flgGrid.RowSel, "会诊意见是否提交"].ToString() == "是")
                    {
                        修改ToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        修改ToolStripMenuItem.Visible = false;
                    }

                }
            }
        }
        private void 查看病例ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (inPatient != null)
                {
                    //frmDoctorBook frmdoctorBook = new frmDoctorBook(inPatient.PId, inPatient.Id, text);
                    //frmdoctorBook.ShowDialog(this);
                    string patient_id = flgGrid[flgGrid.RowSel, "patient_id"].ToString();
                    Child_EventArgs args = new Child_EventArgs();
                    args.State = "借阅";
                    args.Id = Convert.ToInt32(patient_id);
                    args.User_Id = App.UserAccount.UserInfo.User_id;
                    if (browse_Book != null)
                    {
                        browse_Book(sender, args);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            text.MyDoc.Locked = false;
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

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
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
                    if (fg[i, "会诊状态"].ToString() == "取消会诊")
                    {
                        //取消会诊 黄色
                        fg.Rows[i].StyleNew.BackColor = Color.Yellow;
                    }
                    if (fg[i, "是否接诊"].ToString() == "是" && fg[i, "会诊意见是否提交"].ToString() == "否")
                    {
                        //暂存 蓝色
                        fg.Rows[i].StyleNew.BackColor = Color.FromArgb(0, 176, 240);
                    }
                    if (fg[i, "会诊状态"].ToString() == "修改授权")
                    {
                        //对方修改授权  橙色
                        fg.Rows[i].StyleNew.BackColor = Color.Orange;
                    }

                }


            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select a.id,a.apply_sectionname 申请科室,a.apply_name 申请人,to_char(a.apply_time,'yyyy-MM-dd hh24:mi') 申请日期,case a.consultation_type when 0 then '普通会诊' else '急会诊' end 会诊类别," +
                        " b.patient_name 患者姓名,a.pid 住院号,case b.gender_code when '0' then '男' else '女' end 性别,b.age||b.age_unit 年龄,b.in_time 入院时间,a.consul_section_name 会诊科室,a.consul_r_name 会诊医师," +
                        " a.consul_time 会诊时间" +
                        " from t_consultaion_apply a" +
                        " inner join t_in_patient b on a.patient_id = b.id" +
                        " where a.CONSUL_RECORD_SUBMITE_STATE=1 ";

            if (txtName.Text != "")//按患者姓名
            {
                sql += " and b.patient_name like '" + txtName.Text + "%'";
            }
            if (txtPid.Text != "")//按住院号
            {
                sql += " and a.pid like '%" + txtPid.Text + "%'";
            }
            //按会诊类型
            if (cboConsulType.SelectedIndex == 0)//发会诊
            {
                sql += " and apply_sectionid=" + App.UserAccount.CurrentSelectRole.Section_Id;
            }
            else
            {
                sql += " and consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id;
            }
            if (checkBoxX1.Checked)//按时间段
            {
                if (cboConsulTimeType.SelectedIndex == 0)//按申请日期
                {
                    sql += " and apply_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
                if (cboConsulTimeType.SelectedIndex == 1)//按会诊日期
                {
                    sql += " and consul_time between to_timestamp('" + dtpBegin.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss') and to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd hh24:mi:ss')";
                }
            }
            sql += " order by a.apply_time desc";
            ucGridviewX1.DataBd(sql, "id", "", "");
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                cboConsulTimeType.Enabled = true;
                dtpBegin.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                cboConsulTimeType.Enabled = false;
                dtpBegin.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 刷新会诊申请表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefGrid();
            flgGrid_Click(sender, e);
        }


        private void flgGrid_SelChange(object sender, EventArgs e)
        {
            //flgGrid_Click(sender, e);            
        }

        /// <summary>
        /// LIS查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = flgGrid[flgGrid.RowSel, "住院号"].ToString();
                FrmLis fc = new FrmLis(pid);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// PACS查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = flgGrid[flgGrid.RowSel, "patient_id"].ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }

}
