using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using System.Collections;
using TextEditor;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.TEMPLATE
{
    public partial class frmSmallEdit : DevComponents.DotNetBar.Office2007Form
    {
        private DataTable dataTable;
        private DataRow newrow;
        private XmlDocument xmldoc;
        private XmlNode xmlNode;
        private string current_id = "";   //获取当前选中模版的ID

        //ZYTextDocumentLib.frmText fmTempEdit;

        //初始化一级目录（所属系统）
        private void InitSystemList()
        {           
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";            
        }

        //初始化二级目录（病种类）
        private void InitSickList(string msg)
        {
            try
            {
                string sql = "select s.ID,SICK_CODE," +
                            @"SICK_NAME,SICK_SYSTEM, " +
                            @"t.name as Name  from T_SICK_TYPE s " +
                            @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
                //初始化病种
                DataSet dsSick = App.GetDataSet(sql); 
                dataTable = dsSick.Tables[0];
                this.cboSicknessKind.DataSource = dataTable.DefaultView;
                this.cboSicknessKind.ValueMember = "ID";
                this.cboSicknessKind.DisplayMember = "SICK_NAME";

                if (dataTable.Rows.Count > 0)
                {
                    this.cboSicknessKind.SelectedIndex = 0;
                }
            }
            catch
            { }
        }

        //初始化查询一级目录（所属系统）
        private void InitSystemCheckList()
        {
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboSysCheck.DataSource = dataTable.DefaultView;
            this.cboSysCheck.ValueMember = "ID";
            this.cboSysCheck.DisplayMember = "Name";
        }

        //初始化查询二级目录（病种类）
        private void InitSickCheckList(string msg)
        {
            try
            {
                string sql = "select s.ID,SICK_CODE," +
                            @"SICK_NAME,SICK_SYSTEM, " +
                            @"t.name as Name  from T_SICK_TYPE s " +
                            @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
                //初始化病种
                DataSet dsSick = App.GetDataSet(sql);
                dataTable = dsSick.Tables[0];
                this.cboSicknessKindCheck.DataSource = dataTable.DefaultView;
                this.cboSicknessKindCheck.ValueMember = "ID";
                this.cboSicknessKindCheck.DisplayMember = "SICK_NAME";
                if (dataTable.Rows.Count > 0)
                {
                    this.cboSicknessKindCheck.SelectedIndex = 0;
                }               
            }
            catch
            { }
        }

        //小模板类别
        private void InitSmallTypeList()
        {
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174' order by order_id");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboModelType.DataSource = dataTable.DefaultView;
            this.cboModelType.ValueMember = "ID";
            this.cboModelType.DisplayMember = "Name";


            this.cmbModelTypeSelect.DataSource = dataTable.DefaultView;
            this.cmbModelTypeSelect.ValueMember = "ID";
            this.cmbModelTypeSelect.DisplayMember = "Name";

           
            //DataSet ds = App.GetDataSet("select * from T_SECTIONINFO t");
            //string[] strsqls = new string[ds.Tables[0].Rows.Count];
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string id=Convert.ToString(i+1);
            //    strsqls[i] = "insert into T_SMALL_TEMPLATE_COUNT_SET(id,SECTION_ID,MAX_COUNT)values(" + id + "," + ds.Tables[0].Rows[i]["SID"].ToString() + ",50)";
            //}

            //App.ExecuteBatch(strsqls);

            chkIsDeleteOther.Checked = false;
            ucSmallTemplate_Count_set1.refleshsection();
            if (App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
            {
                gpMaxCountset.Visible = true;
                chkIsDeleteOther.Enabled = true;
                

            }
            else
            {
                gpMaxCountset.Visible = false;
                chkIsDeleteOther.Enabled = false;
            }
        }

        //小模板类别
        private void InitSmallTypeSelectList()
        {
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174' order by order_id");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);      

            this.cmbModelTypeSelect.DataSource = dataTable.DefaultView;
            this.cmbModelTypeSelect.ValueMember = "ID";
            this.cmbModelTypeSelect.DisplayMember = "Name";


        }




        /// <summary>
        /// 初始化科室
        /// </summary>
        private void IniSection()
        {
            DataSet ds = App.GetDataSet("select sid,section_name from t_sectioninfo");
            this.cmbSection.DataSource = ds.Tables[0].DefaultView;
            this.cmbSection.ValueMember = "sid";
            this.cmbSection.DisplayMember = "section_name";
        }

        public frmSmallEdit()
        {
            InitializeComponent();
        }

        private void frmSmallEdit_Load(object sender, EventArgs e)
        {
            InitSmallTypeList();
            InitSmallTypeSelectList();
            IniSection();
            cmbSection.Visible = false;
            this.cboModelType.SelectedIndex = 0;
            this.cmbSection.SelectedValue = 0;

            Template.fmS = new frmText();
            groupPanel1.Controls.Add(Template.fmS);//编辑器界面嵌入
            Template.fmS.Dock = System.Windows.Forms.DockStyle.Fill;

            InitSystemList();
            InitSystemCheckList();

            App.FormStytleSet(this, false);

            groupPanel1.Enabled = false;
            chk.Enabled = false;
            btnSearch_Click(sender, e);
        
        }

        private void rdoPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoPersonal.Checked)
            {
                if (App.UserAccount.CurrentSelectRole.Section_Id != string.Empty)
                {
                    if (App.UserAccount.CurrentSelectRole.Role_name != "系统管理员")
                    {
                        cmbSection.Visible = false;
                    }
                    else
                    {
                        cmbSection.Visible = true;
                    }
                }
            }
            else
            {
                cmbSection.Visible = false;
            }
        }

        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            Template.fmS.MyDoc.IsHaveDeleted = true;
            Template.fmS.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.fmS.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string tempxml = GetXmlContent();
            xmldoc = new XmlDocument();
            xmldoc.PreserveWhitespace = true;
            xmldoc.LoadXml(tempxml);



            //if (xmldoc.GetElementsByTagName("input").Count > 0 || xmldoc.GetElementsByTagName("div").Count > 0 || xmldoc.GetElementsByTagName("table").Count > 0 || xmldoc.GetElementsByTagName("img").Count > 0)
            //{
            //    App.Msg("提示:小模板中不能存在输入框,图片,表格,文本块等多结构化的元素！\r\n(注意:多结构化东西只能保存到大模板中！)");
            //    return;
            //}

            if (txtAutoTPName.Text.Trim() == "")
            {
                App.MsgWaring("小模板名称不能为空！");
                txtAutoTPName.Focus();
                return;
            }

            bool flag = false;
            for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++)
            {
                if (current_id == "")
                {
                    if (treeView1.Nodes[0].Nodes[i].Text.Trim() == txtAutoTPName.Text.Trim())
                    {
                        flag = true;
                        break;
                    }
                }
                else
                {
                    if (treeView1.Nodes[0].Nodes[i].Text.Trim() == txtAutoTPName.Text.Trim())
                    {
                        if (treeView1.Nodes[0].Nodes[i].Name.Trim() != current_id.Trim())
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                App.MsgWaring("已经存在相同名称的小模板！");
                txtAutoTPName.Focus();
                return;
            }
          

            if (current_id == "")
            {                
                if (cboModelType.Text == "请选择...")
                {
                    App.Msg("请选择小模板类型！");
                    cboModelType.Focus();
                    return;
                }
                Class_Patients cpd = new Class_Patients();
                string modeltype;
                //string SectionId = "";

                //模版Id
                cpd.Tid = App.GenId("T_TempPlate", "TID");

                modeltype = cboModelType.SelectedValue.ToString();  //病种Id

                //使用范围
                if (this.rdoPersonal.Checked == true)
                {
                    cpd.TempPlate_Level = 'P'; //个人

                    if (!App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
                    {
                        /*
                         * 主治一下级别的医生，创建个人模板的时候有创建数量的限制
                         */
                        DataSet ds_get_count = App.GetDataSet("select t.max_count from t_small_template_count_set t where t.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "");
                        if (ds_get_count != null)
                        {
                            if (ds_get_count.Tables[0].Rows.Count > 0)
                            {
                                DataSet ds_count = App.GetDataSet("select count(tid) from t_tempplate t where t.tempplate_level='P' and t.temptype='S' and t.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and t.Creator_Id=" + App.UserAccount.Account_id + "");
                                if (Convert.ToInt32(ds_count.Tables[0].Rows[0][0])>= Convert.ToInt32(ds_get_count.Tables[0].Rows[0][0]))
                                {
                                    App.MsgWaring("主治以下级别的医生，创建个人模板的时候有创建数量的限制,您的小模板数已经超过了上限" + ds_get_count.Tables[0].Rows[0][0].ToString()+ "");
                                    return;
                                }
                            }
                        }
                    }                    
                }
                if (this.rdoSection.Checked == true)
                {
                    cpd.TempPlate_Level = 'S'; //科室                   
                }

                cpd.TName = txtAutoTPName.Text;  //模板名称

                cpd.Ages = -1;

                //性别
                if (rdoSexNull.Checked)
                {
                    cpd.Sex = 'N';
                }
                else if (rdoMale.Checked)
                {
                    cpd.Sex = '0';
                }
                else if (rdoFemale.Checked)
                {
                    cpd.Sex = '1';
                }

                cpd.Section_ID = 0;
                //科室ID
                if (App.UserAccount.CurrentSelectRole.Role_name != "系统管理员")
                    cpd.Section_ID = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);
                else
                {
                    if (cmbSection.Visible)
                    {
                        cpd.Section_ID = Convert.ToInt32(cmbSection.SelectedValue);
                    }
                }

                //病区ID
                if (App.UserAccount.CurrentSelectRole.Sickarea_Id != string.Empty)
                    cpd.SickArea_ID = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Sickarea_Id);

                //创建时间
                cpd.Create_Time = this.dtpTime.Value.ToString("yyyy-MM-dd HH:mm");

                //创建人ID
                cpd.Creator_ID = Convert.ToInt32(App.UserAccount.Account_id);

                ArrayList Sqls = new ArrayList();

                //设置默认模板
                string ISDEFAULT = "N";


                //设置是更新或者新增
                string temp = "";
                //DataSet samedocs = App.GetDataSet("select tid from T_TempPlate where tname='" + cpd.TName + "' and TEMPTYPE='S'");
                //if (samedocs.Tables[0] != null)
                //{
                //    if (samedocs.Tables[0].Rows.Count > 0)
                //    {
                //        App.MsgWaring("已经存在相同名称的文书，请先修改名称");
                //        return;
                //    }
                //}


                string sick_Id = "0";  //病种Id

                if (chkBzfl.Enabled)
                {
                    //if (cboSicknessKind.Text != "请选择...")
                    if (cboSicknessKind.SelectedIndex >= 0)
                        sick_Id = cboSicknessKind.SelectedValue.ToString();
                    //else
                    //{                        
                    //    App.MsgWaring("请选择病种类");
                    //    return;
                    //}
                }                

                //插入模版表
                if (cpd.Section_ID != 0)
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SECTION_ID,SMALLTEMPTYPE,TEMPTYPE,SICK_ID) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                    + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                    + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                    + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                    + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                    + "'N','N','" + ISDEFAULT + "'," + cpd.Section_ID + ",'" + modeltype + "','S'," + sick_Id + ")";

                }
                else
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SECTION_ID,SMALLTEMPTYPE,TEMPTYPE,SICK_ID) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                                       + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                                       + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                                       + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                                       + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                                       + "'N','N','" + ISDEFAULT + "'," + cpd.Section_ID + ",'" + modeltype + "','S'," + sick_Id + ")";
                }
                Sqls.Add(temp);

                /*
                 * 移除含有timeTitle属性的div节点
                 */
                XmlNode root = xmldoc.FirstChild;
                bool atrribue = false;
                foreach (XmlNode firstNode in root.ChildNodes)
                {
                    if (firstNode.Name == "body")
                    {
                        foreach (XmlNode secondNode in firstNode.ChildNodes)
                        {
                            if (secondNode.Name == "div")
                            {
                                if (secondNode != null)
                                {
                                    for (int i = 0; i < secondNode.Attributes.Count; i++)
                                    {
                                        if (secondNode.Attributes[i].Name.Trim().ToLower() == "timetitle")
                                            atrribue = true;
                                    }

                                    if (atrribue)
                                    {
                                        firstNode.RemoveChild(secondNode);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (atrribue)
                        break;
                }

                string temp3 = Template.fmS.MyDoc.InsertLableContent(cpd.Tid, xmldoc.OuterXml);
                if (temp3.Trim() == "")
                {
                    App.MsgErr("保存失败！");
                    Template.fmT.MyDoc.ClearContent();
                    this.Close();
                    return;
                }

                string[] AddSqls = new string[Sqls.Count];

                for (int i = 0; i < Sqls.Count; i++)
                {
                    AddSqls[i] = Sqls[i].ToString();
                }

                int x = App.ExecuteBatch(AddSqls);

                if (x > 0)
                {
                    App.Msg("模版保存成功!");
                    btnSearch_Click(sender, e);
                }
                else
                {
                    App.MsgErr("保存失败！");
                }
            }
            else
            {                            
                XmlElement xmlElement = xmldoc.DocumentElement;
                int message = 0;
                try
                {
                    foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {

                            if (bodyNode.HasChildNodes)
                            {   //int i = 1;           
                                string updateLable = "update T_TempPlate_Cont set Content=:divContent where tid=" + current_id;
                                Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                                xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                                xmlPars[0].ParameterName = "divContent";
                                //xmlPars[0].Value = divNode.OuterXml;
                                xmlPars[0].Value = bodyNode.InnerXml;
                                xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                                xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                                message = App.ExecuteSQL(updateLable, xmlPars);
                                if (message > 0)
                                {

                                    string sick_Id = "0";  //病种Id

                                    if (chkBzfl.Checked)
                                    {
                                        sick_Id = cboSicknessKind.SelectedValue.ToString();
                                    }

                                    string Sql = "update t_tempplate set tname='" + txtAutoTPName.Text + "',SICK_ID='" + sick_Id + "' where tid=" + current_id + "";
                                    if (radp1.Checked)
                                    {
                                        char lever = 'P';
                                        if (this.rdoSection.Checked)
                                        {
                                            lever = 'S'; //科室                   
                                        }

                                        Sql = "update t_tempplate set tname='" + txtAutoTPName.Text + "',tempplate_level='" + lever + "',SICK_ID='" + sick_Id + "' where tid=" + current_id + "";
                                    }

                                    App.ExecuteSQL(Sql);
                                    App.Msg("保存成功");
                                    btnSearch_Click(sender, e);                                    
                                    
                                }
                                else
                                {
                                    App.MsgErr("保存失败");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.MsgErr("保存失败,错误原因:" + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {           
            groupPanel1.Enabled = true;
            chk.Enabled = true;
            current_id = "";
            Template.fmS.MyDoc.ClearContent();
            panel1.Enabled = true;
            cboModelType.Enabled = true;
            txtAutoTPName.Enabled = true;
            pnlSex.Enabled = true;
            dtpTime.Enabled = true;
            txtAutoTPName.Text = "";
            treeView1.SelectedNode = null;
            current_id = "";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (radp1.Checked)
            {
                //个人小模板集合
                treeView1.Nodes.Add("个人小模板");
            }
            else
            {
                //科室小模板集合
                treeView1.Nodes.Add("科室小模板");
            }
            treeView1.Nodes[0].ImageIndex = 6;
            treeView1.Nodes[0].SelectedImageIndex = 6;
            string sql = "";
            if (cmbModelTypeSelect.Items.Count > 0)
            {
                if (cmbModelTypeSelect.Text == "请选择...")
                {
                    sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.TNAME like '" + txtDocName.Text + "%' ";
                }
                else
                {
                    sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.smalltemptype=" + cmbModelTypeSelect.SelectedValue.ToString() + " and t.TNAME like '" + txtDocName.Text + "%'";
                }
            }
            else
            {
                sql = "select t.tid,t.tname,b.name from t_tempplate t inner join t_data_code b on t.smalltemptype=b.id where t.temptype='S' and t.TNAME like '" + txtDocName.Text + "%'";
            }

            if (rads1.Checked)
            {
                sql = sql + " and t.tempplate_level='S' and t.SECTION_ID="+App.UserAccount.CurrentSelectRole.Section_Id+"";
            }
            else
            {
                sql = sql + " and t.tempplate_level='P' and t.creator_id=" + App.UserAccount.Account_id+ "";
            }

            //病种分类
            if (chkBzflCheck.Checked)
            {
                sql = sql + " and SICK_ID=" + cboSicknessKindCheck.SelectedValue.ToString()+ "";
            }

            sql = sql + " order by b.name";

            DataSet dsnods = App.GetDataSet(sql);

            if (dsnods != null)
            {
                for (int i = 0; i < dsnods.Tables[0].Rows.Count; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dsnods.Tables[0].Rows[i]["name"].ToString()+"--"+dsnods.Tables[0].Rows[i]["TNAME"].ToString();
                    tn.Name = dsnods.Tables[0].Rows[i]["TID"].ToString();
                    tn.ImageIndex = 13;
                    tn.SelectedImageIndex = 13;
                    treeView1.Nodes[0].Nodes.Add(tn);
                }
            }
            treeView1.Nodes[0].ExpandAll();
            Template.fmS.MyDoc.ClearContent();
            chk.Enabled = false;
         
            
        }

        /// <summary>
        /// 删除小模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除文书模版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                    bool result = App.Ask("确认要删除吗？");
                    if (result)
                    {

                        string delPatients_Doc = "delete from t_tempplate where tid=" + treeView1.SelectedNode.Name;

                        string delModel_Lable = "delete from t_tempplate_cont where tid=" + treeView1.SelectedNode.Name;
                        string[] strSqls ={ delPatients_Doc, delModel_Lable };
                        int i = App.ExecuteBatch(strSqls);
                        if (i > 0)
                        {
                            App.Msg("操作成功");
                            this.treeView1.SelectedNode.Remove();
                            Template.fmS.MyDoc.ClearContent();
                        }
                        else
                        {
                            App.Msg("操作失败");
                        }


                    }
                }
                else
                {
                    App.MsgWaring("该节点不能被删除");
                }
            }
            else
            {
                App.MsgWaring("请选择要删除的节点");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ctmTreeViewMenu.Enabled = true;
            groupPanel1.Enabled = false; 
            chk.Enabled = false;
            //if (e.Button == MouseButtons.Left)
            //{
            //panel1
            if (radp1.Checked)
            {
                panel1.Enabled = true;
                rdoPersonal.Checked = true;
            }
            else
            {
                panel1.Enabled = false;
                rdoSection.Checked = true;
            }

            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent != null)
                {
                  
                    删除文书模版ToolStripMenuItem.Enabled = true;

                    xmldoc = new XmlDocument();//加入XML的声明段落                
                    xmldoc.PreserveWhitespace = true;
                    string strXml = GetXmlContent();
                    //xmlDoc.Load(@"C:\tempplate.xml");
                    xmldoc.LoadXml(strXml);
                    xmlNode = xmldoc.SelectSingleNode("emrtextdoc");//查找<body>

                    current_id = treeView1.SelectedNode.Name;
                    string temp = "select Content from T_TempPlate_Cont where tid=" + treeView1.SelectedNode.Name;


                    DataSet dsTemp = App.GetDataSet(temp);
                    DataTable dtTemp = dsTemp.Tables[0];
                    string content = "";
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        content = content + dtTemp.Rows[i][0].ToString();
                    }

                    foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {
                            bodyNode.InnerXml = content;
                        }
                    }
                    Template.fmS.MyDoc.FromXML(xmldoc.DocumentElement);
                    Template.fmS.MyDoc.ContentChanged();


                    /*
                     * 基本信息控制
                     */
                    DataSet ds = App.GetDataSet("select t.tname,t.sick_id from t_tempplate t where tid=" + treeView1.SelectedNode.Name + "");
                    txtAutoTPName.Text = ds.Tables[0].Rows[0][0].ToString();

                    //select t.id,t.sick_system from T_SICK_TYPE t where t.id
                    int sickid=0;
                    if (ds.Tables[0].Rows[0][1].ToString() != "")
                    {
                        sickid = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    }

                    //病种
                    DataSet Sick_data = App.GetDataSet("select t.id,t.sick_system from T_SICK_TYPE t where t.id=" + sickid + "");

                    if (Sick_data != null)
                    {
                        if (Sick_data.Tables[0].Rows.Count > 0)
                        {
                            cboSys.SelectedValue = Sick_data.Tables[0].Rows[0][1].ToString();
                            cboSys_SelectedIndexChanged(sender, e);
                            if (cboSicknessKind.Items.Count > 0)
                            {
                                cboSicknessKind.SelectedValue = sickid;
                            }
                        }
                    }
                   

                    chk.Enabled = true;
                    //panel1.Enabled = false;
                    cboModelType.Enabled = false;
                    //txtAutoTPName.Enabled = false;
                    pnlSex.Enabled = false;
                    dtpTime.Enabled = false;
                    btnSure.Enabled = true;
                    groupPanel1.Enabled = true;
                }
            }
            else
            {
                删除文书模版ToolStripMenuItem.Enabled = false;               
            }
        }

        /// <summary>
        /// 批量删除医生模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 批量删除医生模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            //if(App.IsHigherMasterDoctor())
            //IsHigherMasterDoctor
          
        }

        private void ctmTreeViewMenu_Opening(object sender, CancelEventArgs e)
        {
            //if (App.IsHigherMasterDoctor(App.UserAccount.UserInfo.User_id))
            //{
            //    批量删除医生模板ToolStripMenuItem.Visible = true;

            //}
            //else
            //{
            //    批量删除医生模板ToolStripMenuItem.Visible = false;
            //}
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (chkIsDeleteOther.Checked)
            {
                frmGetUserId fc = new frmGetUserId();
                App.ButtonStytle(fc, false);
                fc.ShowDialog();
            }
            else
            {
                string tids = "";
                for (int i = 0; i < treeView1.Nodes[0].Nodes.Count; i++)
                {
                    if (treeView1.Nodes[0].Nodes[i].Checked)
                    {
                        if (tids == "")
                        {
                            tids = treeView1.Nodes[0].Nodes[i].Name;
                        }
                        else
                        {
                            tids = tids + "," + treeView1.Nodes[0].Nodes[i].Name;
                        }
                    }
                }

                if (tids != "")
                {
                    if (App.Ask("确定要删除这些文书吗？"))
                    {

                        string[] sqls = new string[2];
                        sqls[0] = "delete from t_tempplate where tid in (" + tids + ")";
                        sqls[1] = "delete from t_tempplate_cont where tid in (" + tids + ")";
                        if (App.ExecuteBatch(sqls) > 0)
                        {
                            App.Msg("操作已经成功！");
                            btnSearch_Click(sender, e);
                        }
                        else
                        {
                            App.Msg("操作失败！");
                        }

                    }
                }
                else
                {
                    App.MsgErr("请先选者需要删除的模板！");
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                //treeView1.SelectedNode = e.Node;

                if (e.Node.Checked)
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        e.Node.Nodes[i].Checked = true;
                    }
                }
                else
                {
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        e.Node.Nodes[i].Checked = false;
                    }
                }
            }
            catch
            { }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        /// <summary>
        /// 病种分类选择操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBzfl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBzfl.Checked)
            {
                cboSys.Enabled = true;
                cboSicknessKind.Enabled = true;
            }
            else
            {
                cboSys.Enabled = false;
                cboSicknessKind.Enabled = false;
            }
        }

        /// <summary>
        /// 病种分类查询选择操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBzflCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBzflCheck.Checked)
            {
                cboSysCheck.Enabled = true;
                cboSicknessKindCheck.Enabled = true;
            }
            else
            {
                cboSysCheck.Enabled = false;
                cboSicknessKindCheck.Enabled = false;
            }
        }

        private void cboSysCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSysCheck.Text != "请选择..." && cboSysCheck.Text.Trim() != "")
            {
                InitSickCheckList(cboSysCheck.SelectedValue.ToString());
            }
        }

        private void cboSicknessKind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSys.Text != "请选择..." && cboSys.Text.Trim() != "")
            {
                InitSickList(cboSys.SelectedValue.ToString());
            }          
        }
    }
}