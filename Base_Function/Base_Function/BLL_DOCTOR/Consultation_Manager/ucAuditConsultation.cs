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

namespace Base_Function.BLL_DOCTOR.Consultation_Manager
{
    public partial class ucAuditConsultation : UserControl
    {
        public ucAuditConsultation()
        {
            InitializeComponent();
        }
        

        public delegate void RefEventHandler(object sender, Child_EventArgs e);
        public event RefEventHandler browse_Book;
        private DataTable dt_Jobtitle = new DataTable();
        private frmText text;
        private InPatientInfo inPatient;
        private string Id = "";//会诊ID
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
                string sql = @"SELECT A.ID,A.WRITE_R_ID,D.ID PATIENT_ID,A.CONSUL_RECORD_SECTION_ID,C.SECTION_NAME 会诊申请科室
                        ,(CASE A.CONSULTATION_END WHEN 1 THEN '是' ELSE '否' END) 会诊是否结束
                        ,(CASE  WHEN A.CONSULTATION_TYPE=1 THEN '急会诊' WHEN A.CONSULTATION_TYPE=0 THEN '普通会诊' ELSE '其他' END) 会诊类别
                        , TO_CHAR(A.APPLY_TIME,'YYYY-MM-DD HH24:MI') 申请时间,D.PATIENT_NAME 患者姓名
                        ,D.PID 住院号,(CASE  WHEN D.GENDER_CODE='0' THEN '男' WHEN D.GENDER_CODE='1' THEN '女' ELSE '其他' END) 性别
                        , D.AGE 年龄,D.SICK_BED_NO 床号,E.USER_NAME 申请医生,(CASE  WHEN A.ISRECIEVE=1 THEN '是'   ELSE '否' END) 是否接诊
                        , A.PATIENT_DOC_ID  
                        ,(CASE  WHEN A.ISAUDIT='1' THEN '未审核'   WHEN A.ISAUDIT='2' THEN '已审核' ELSE '无需审核' END) 审核状态
                        FROM T_CONSULTAION_APPLY A 
                        INNER JOIN T_IN_PATIENT D ON A.PATIENT_ID=D.ID 
                        INNER JOIN T_USERINFO E ON A.APPLY_USERID=E.USER_ID  
                        INNER JOIN T_SECTIONINFO C ON A.APPLY_SECTIONID=C.SID 
                        WHERE  A.IS_DALETE='N' AND A.SUBMITED='Y' AND A.ISRECIEVE<>1
                        AND CONSUL_RECORD_SECTION_ID IN(SELECT DISTINCT KSBM FROM T_AUDITCONFIG A WHERE A.YSBM='" + App.UserAccount.UserInfo.User_id.Trim() + "' AND A.SFYX=1 ) ORDER BY A.APPLY_TIME DESC";


                this.dataGridView1.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;

                this.dataGridView1.Columns["ID"].Visible = false;
                this.dataGridView1.Columns["PATIENT_DOC_ID"].Visible = false;
                this.dataGridView1.Columns["PATIENT_ID"].Visible = false;
                this.dataGridView1.Columns["WRITE_R_ID"].Visible = false; 

                 
                SetRowsColor(this.dataGridView1);
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }

        /// <summary>
        /// 设置单元格颜色
        /// </summary>
        /// <param name="fg"></param>
        private void SetRowsColor(System.Windows.Forms.DataGridView fg)
        {
            if (fg != null)
            {
                for (int i = 0; i < fg.Rows.Count; i++)
                {
                    
                    if (fg.Rows[i].Cells["审核状态"].Value.ToString().Trim() == "未审核")
                    {
                        if (fg.Rows[i].Cells["会诊类别"].Value.ToString().Trim() == "急会诊")
                        {
                            //急会诊 红色
                            fg.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (fg.Rows[i].Cells["会诊类别"].Value.ToString().Trim() == "普通会诊")
                        {
                            //取消会诊 黄色
                            fg.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            fg.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                  
                }
            }
        }
        
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
                {
                    
                    this.Id = this.dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim();
                    string patient_doc_id= this.dataGridView1.SelectedRows[0].Cells["PATIENT_DOC_ID"].Value.ToString().Trim();
                    string patient_id = this.dataGridView1.SelectedRows[0].Cells["PATIENT_ID"].Value.ToString().Trim();
                    /*
                     *查出会诊单和病人基本信息
                     * 
                     */
                    string sql_Content = "select * from t_patients_doc where tid=" + patient_doc_id;//查询会诊单
                    string Sql_ByPId = " select * from t_in_patient a where id ='" + patient_id + "'";//查询病人基本信息

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
                    text.MyDoc.Us.Tid = Convert.ToInt32(patient_doc_id);//文书ID
                    text.MyDoc.PageHeader = null;//= null 他会重新new 一个 获取新的病人信息
                    string content = App.DownLoadFtpPatientDoc(patient_doc_id + ".xml", inPatient.Id.ToString());//ds.Tables["TabContent"].Rows[0]["patients_doc"].ToString();//文书内容
                    if (content == "")
                    {
                        content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + patient_doc_id + "", 0, "CONTENT");
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
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                    DataInit.filterInfo(tmpxml.DocumentElement, inPatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                    text.MyDoc.FromXML(tmpxml.DocumentElement);
                    text.MyDoc.ContentChanged();


                    this.comboBox1.SelectedValue = this.dataGridView1.SelectedRows[0].Cells["CONSUL_RECORD_SECTION_ID"].Value.ToString().Trim();
                    //this.comboBox1.Enabled = false;
                    //this.btnSave.Enabled = false;

                    pACSToolStripMenuItem.Visible = true;
                    lISToolStripMenuItem.Visible = true;
                    查看病例ToolStripMenuItem.Visible = true;
                    //审核ToolStripMenuItem.Visible = true;
                    刷新ToolStripMenuItem.Visible = true;
                }else
                {
                    pACSToolStripMenuItem.Visible = false;
                    lISToolStripMenuItem.Visible = false;
                    查看病例ToolStripMenuItem.Visible = false;
                    //审核ToolStripMenuItem.Visible = false;
                    刷新ToolStripMenuItem.Visible = true;
                }
               
            }
            //}
            catch (System.Exception ex)
            {

            }
        }

        private void 查看病例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (inPatient != null)
                    {
                        string patient_id = this.dataGridView1.SelectedRows[0].Cells["PATIENT_ID"].Value.ToString().Trim();
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
            }
            catch (System.Exception ex)
            {

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
            dataGridView1_Click(sender, e);
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
                if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
                {

                    string pid = this.dataGridView1.SelectedRows[0].Cells["住院号"].Value.ToString().Trim();
                    FrmLis fc = new FrmLis(pid);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
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
                if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
                {

                    string patient_id = this.dataGridView1.SelectedRows[0].Cells["PATIENT_ID"].Value.ToString().Trim(); 
                    InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                    Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                    App.FormStytleSet(fc, false);
                    fc.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void getKsXx()
        {
            DataSet ds = App.GetDataSet(" SELECT  A.KSBM,A.KSMC  FROM T_AUDITCONFIG A WHERE A.YSBM='" + App.UserAccount.UserInfo.User_id.Trim() + "' AND A.SFYX=1 ");
            if (ds != null && ds.Tables != null)
            {
                this.comboBox1.DataSource = ds.Tables[0].DefaultView;
                this.comboBox1.ValueMember = "KSBM";
                this.comboBox1.DisplayMember = "KSMC";
            }
        }


        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = true;
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
                 *保存会诊记录信息 
                 */
            if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
            {
                if (this.dataGridView1.SelectedRows[0].Cells["是否接诊"].Value.ToString().Trim() == "是")
                {
                    App.Msg("已接诊，不能重新分配科室！");

                }
                this.Id = this.dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim();
                string Sql_Save_Record = "update t_consultaion_apply set consul_record_section_id='" + this.comboBox1.SelectedValue.ToString().Trim() + "'," +
                                         "consul_section_name='" + this.comboBox1.Text.Trim() + "'," +
                                         "isaudit='2' where id=" + Id + "";
                int count = App.ExecuteSQL(Sql_Save_Record);
                if (count > 0)
                {
                    RefGrid();
                    dataGridView1_Click(sender, e);
                    App.Msg("审核成功！");
                }
                else
                {
                    App.Msg("会诊记录操作失败！");
                }
            }else
            {
                App.Msg("请选择会诊申请！");
            }
        }
        private void loadfrmText()
        {
            text = new frmText(1724, 0, 0, "会诊记录", 0, null, true, true, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"), "");
            text.MyDoc.TextSuperiorSignature = "N";
            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
            text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
            text.MyDoc.IgnoreLine = false;
            text.MyDoc.Locked = true;
            text.Dock = DockStyle.Fill;
            pnlDoc.Controls.Add(text);
        }
        private void ucAuditConsultation_Load(object sender, EventArgs e)
        {
            loadfrmText();
            RefGrid();
            getKsXx();
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.查看病例ToolStripMenuItem.Click += new System.EventHandler(this.查看病例ToolStripMenuItem_Click);
            this.lISToolStripMenuItem.Click += new System.EventHandler(this.lISToolStripMenuItem_Click);
            this.pACSToolStripMenuItem.Click += new System.EventHandler(this.pACSToolStripMenuItem_Click);
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            //this.审核ToolStripMenuItem.Click += new System.EventHandler(this.审核ToolStripMenuItem_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }
         
    }
}
