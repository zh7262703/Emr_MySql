using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using Bifrost;
using TextEditor.TextDocument.Document;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPLATE
{
    public partial class frmTemplateSave : DevComponents.DotNetBar.Office2007Form
    {
        private XmlDocument xmldoc;
        private DataTable dataTable;
        private DataRow newrow;
        TreeView treeView1;
        private bool isSysInit = false;       //绑定数据源是否触发事件（一级目录）
        private bool isSickInit = false;      //绑定数据源是否触发事件（二级目录）
        //private bool isTextKindInit = false;  //绑定数据源是否触发事件（三级目录）
       
     
        public frmTemplateSave(XmlDocument xmldoc,TreeView treeView1,ZYTextDocument doc)
        {
            InitializeComponent();
            this.doc = doc;
            this.xmldoc = xmldoc;
            this.label9.Text = App.UserAccount.CurrentSelectRole.Section_Id;
            this.label10.Text = App.UserAccount.CurrentSelectRole.Role_id;
            //this.label9.Text = App.getSpell(this.label10.Text);    ---------快捷码
            this.treeView1 = treeView1;
        }

        private ZYTextDocument doc = null;
        public frmTemplateSave(XmlDocument xmldoc,int kind,ZYTextDocument doc)
        {
            InitializeComponent();
            treeView1 = null;
            this.xmldoc = xmldoc;
            this.label9.Text = App.UserAccount.CurrentSelectRole.Section_Id;
            this.label10.Text = App.UserAccount.CurrentSelectRole.Role_id;
            this.doc = doc;
            //this.label9.Text = App.getSpell(this.label10.Text);    ---------快捷码
            //this.treeView1 = treeView1;
            ucTemplateManagement.text_kind = kind;            
        }

        private void frmTemplateSave_Load(object sender, EventArgs e)
        {
            //treeView1.SelectedNode.Tag;
            InitSystemList();   //初始化一级目录（所属系统）

            this.cboSicknessKind.SelectedIndex = 0;
            this.cboTextKind.SelectedIndex = 0;


            //初始化年龄段
            //DataSet dsAges = App.GetDataSet("select * from t_data_code where type=12");
            //dataTable = dsAges.Tables[0];
            //newrow = dataTable.NewRow();
            //newrow[1] = "请选择...";
            //dataTable.Rows.InsertAt(newrow, 0);
            //this.cboAges.DataSource = dsAges.Tables[0].DefaultView;
            //this.cboAges.ValueMember = "ID";
            //this.cboAges.DisplayMember = "Name";

            if (App.UserAccount != null)
            {
                if (App.UserAccount.Roles.Length > 0)
                {
                    if (App.UserAccount.Roles[0].Role_id != "1")
                    {
                        panel1.Enabled = false;
                        panel1.Visible = false;
                        lblDefaultModel.Visible = false;
                    }
                    else
                    {
                        panel1.Enabled = true;
                        panel1.Visible = true;
                        lblDefaultModel.Visible = true;
                    }
                }
            }

            if (App.UserAccount.CurrentSelectRole.Role_name == "系统管理员")
            {
                checkBox1.Visible = true;
            }
            else
            {
                checkBox1.Visible = false;              
                rdoHospital.Visible = true;
            }

        }

        //一级目录选定项改变事件
        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSysInit)
            {
                string msg = this.cboSys.SelectedValue.ToString();
                InitSickList(msg);
            }
        }

        //二级目录选定项改变事件
        private void cboSicknessKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSickInit)
            {
                string msg = this.cboSicknessKind.SelectedValue.ToString();
                InitTextKindList(msg);
            }
        }

        /// <summary>
        /// 三级目录选定项改变事件
        /// 当改变该下拉列表时，将下拉列表中的文本赋予txtAutoTPName文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTextKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAutoTPName.Text = ((ComboBox)sender).Text;
            this.txtAutoTPName.Enabled = false;
            if (cboTextKind.SelectedIndex == 0)
            {
                this.txtAutoTPName.Enabled = true;
                this.txtAutoTPName.Text = "";
            }
            LoadTemplateInfo();   //加载模板信息            
        }

        //加载模板信息
        private void LoadTemplateInfo()
        {
            if (this.txtAutoTPName.Text != "")
            {
                string tName = this.txtAutoTPName.Text;
                string sql = "select * from T_TempPlate where tname='" + tName + "'";
                DataSet dsTemplate = App.GetDataSet(sql);
                Class_Patients cpd = null;
                string isDefault = "";
                int sick_Id = 0;

                if (dsTemplate.Tables[0].Rows.Count > 0)
                {
                    cpd = new Class_Patients();
                    dataTable=dsTemplate.Tables[0];

                    cpd.Tid = Convert.ToInt32(dataTable.Rows[0]["tid"].ToString());
                    cpd.TName = dataTable.Rows[0]["tname"].ToString();
                    cpd.Shortcut = dataTable.Rows[0]["shortcut"].ToString();
                    cpd.TextKind = dataTable.Rows[0]["text_type"].ToString();
                    cpd.TempPlate_Level = Convert.ToChar(dataTable.Rows[0]["tempplate_level"].ToString());
                    cpd.Sex = Convert.ToChar(dataTable.Rows[0]["sex"].ToString());
                    if (dataTable.Rows[0]["ages"] != null)
                    {
                        cpd.Ages = Convert.ToInt32(dataTable.Rows[0]["ages"].ToString());
                    }
                    if (dataTable.Rows[0]["section_id"] != null)
                    {
                        cpd.Section_ID = Convert.ToInt32(dataTable.Rows[0]["section_id"].ToString());
                    }
                    if (dataTable.Rows[0]["sickarea_id"] != null)
                    {
                        cpd.SickArea_ID = Convert.ToInt32(dataTable.Rows[0]["sickarea_id"].ToString());
                    }
                    if (dataTable.Rows[0]["creator_id"] != null)
                    {
                        cpd.Creator_ID = Convert.ToInt32(dataTable.Rows[0]["creator_id"]);
                    }
                    cpd.Create_Time = dataTable.Rows[0]["create_time"].ToString();
                    if (dataTable.Rows[0]["updater_id"] != null)
                    {
                        cpd.Updater_ID = Convert.ToInt32(dataTable.Rows[0]["updater_id"]);
                    }
                    cpd.Update_Time = dataTable.Rows[0]["update_time"].ToString();
                    if (dataTable.Rows[0]["verify_id1"] != null)
                    {
                        cpd.Verify_ID1 = Convert.ToInt32(dataTable.Rows[0]["verify_id1"]);
                    }
                    cpd.Verify_Time1 = dataTable.Rows[0]["verify_time1"].ToString();
                    if (dataTable.Rows[0]["verify_id2"] != null)
                    {
                        cpd.Verify_ID2 = Convert.ToInt32(dataTable.Rows[0]["verify_id2"]);
                    }
                    cpd.Verify_Time2 = dataTable.Rows[0]["verify_time2"].ToString();
                    if (dataTable.Rows[0]["verify_sign"] != null)
                    {
                        cpd.Verify_Sign = Convert.ToInt32(dataTable.Rows[0]["verify_sign"]);
                    }
                    if (dataTable.Rows[0]["isdiag"] != null)
                    {
                        cpd.IsDiag = Convert.ToChar(dataTable.Rows[0]["isdiag"]);
                    }
                    if (dataTable.Rows[0]["enable_flag"] != null)
                    {
                        cpd.Enable_Flag = Convert.ToChar(dataTable.Rows[0]["enable_flag"]);
                    }

                    isDefault = dataTable.Rows[0]["ISDEFAULT"].ToString();  //是否默认模板
                    if (dataTable.Rows[0]["sick_id"] != null)
                    {
                        sick_Id = Convert.ToInt32(dataTable.Rows[0]["sick_id"]);
                    }
                }

                //加载使用范围信息
                if (cpd.TempPlate_Level == 'P')
                {
                    rdoPersonal.Checked = true;
                }
                else if (cpd.TempPlate_Level == 'S')
                {
                    rdoSection.Checked = true;
                }
                else if (cpd.TempPlate_Level == 'H')
                {
                    rdoHospital.Checked = true;
                }

                string ageName="";
                if (cpd.Ages != -1)
                {
                    ageName = App.GetDataSet("select Name from t_data_code where ID=" + cpd.Ages + "").Tables[0].Rows[0]["Name"].ToString();
                }

                //加载年龄段
                if (ageName == "儿童")
                {
                    rdoEnfant.Checked = true;
                }
                else if (ageName == "少年")
                {
                    rdoLad.Checked = true;
                }
                else if (ageName == "青年")
                {
                    rdoYouth.Checked = true;
                }
                else if (ageName == "中年")
                {
                    rdoMiddle.Checked = true;
                }
                else if (ageName == "老年")
                {
                    rdoOld.Checked = true;
                }
                else
                {
                    rdoAgeNull.Checked = true;
                }

                //加载性别
                if (cpd.Sex == '0')
                {
                    rdoMale.Checked = true;
                }
                else if (cpd.Sex == '1')
                {
                    rdoFemale.Checked = true;
                }
                else
                {
                    rdoSexNull.Checked = true;
                }

                //加载时间
                if (cpd.Create_Time != "" && cpd.Create_Time != null)
                {
                    this.dtpTime.Value = Convert.ToDateTime(cpd.Create_Time);
                }

                //加载默认模板
                if (isDefault == "Y")
                {
                    rdbYes.Checked = true;
                }
                else
                {
                    rdbNo.Checked = true;
                }
            }
        }

        //初始化一级目录（所属系统）
        private void InitSystemList()
        {
            isSysInit = false;   //绑定数据源是否触发事件

            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";

            isSysInit = true;  //绑定数据源是否触发事件
        }

        //初始化二级目录（病种类）
        private void InitSickList(string msg)
        {
            isSickInit = false;  //绑定数据源是否触发事件

            string sql = "select s.ID,SICK_CODE," +
                        @"SICK_NAME,SICK_SYSTEM, " +
                        @"t.name as Name  from T_SICK_TYPE s " +
                        @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
            //初始化病种
            DataSet dsSick = App.GetDataSet(sql);
            dataTable = dsSick.Tables[0];
            newrow = dataTable.NewRow();
            newrow[2] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSicknessKind.DataSource = dataTable.DefaultView;
            this.cboSicknessKind.ValueMember = "ID";
            this.cboSicknessKind.DisplayMember = "SICK_NAME";

            isSickInit = true;  //绑定数据源是否触发事件
        }

        //初始化三级目录（模板名称）
        private void InitTextKindList(string msg)
        {

            //isTextKindInit = false;  //绑定数据源是否触发事件

            string sql = "select * from T_TempPlate where SICK_ID='"+msg+"'";
            //初始化文书类型
            DataSet dsTextKind = App.GetDataSet(sql);

            dataTable = dsTextKind.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboTextKind.DataSource = dsTextKind.Tables[0].DefaultView;
            this.cboTextKind.ValueMember = "tid";
            this.cboTextKind.DisplayMember = "tname";

            //isTextKindInit = true;  //绑定数据源是否触发事件

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //保存模板
        private void btnOK_Click(object sender, EventArgs e)
        {
            Class_Patients cpd = new Class_Patients();

            if (InputValid())
            {
                //模版Id
                cpd.Tid = App.GenId("T_TempPlate", "TID");

                string sick_Id = cboSicknessKind.SelectedValue.ToString();  //病种Id

                //使用范围
                if (this.rdoPersonal.Checked == true)
                {
                    cpd.TempPlate_Level = 'P'; //个人
                }
                if (this.rdoSection.Checked == true)
                {
                    cpd.TempPlate_Level = 'S'; //科室
                }
                if (this.rdoHospital.Checked == true)
                {
                    cpd.TempPlate_Level = 'H'; //全院
                }

                cpd.TName = txtAutoTPName.Text;  //模板名称

                //文书类型 --需要通过登录者当前操作的文书来判断是哪一个文书类型 （例如：入院记录、手术小结）
                cpd.TextKind = ucTemplateManagement.text_kind.ToString();

                //if (cboAges.SelectedIndex != 0)
                //{
                //    cpd.Ages = Convert.ToInt32(this.cboAges.SelectedValue.ToString());
                //}
                //else
                //{
                //    App.MsgErr("请选择年龄段");
                //    return;
                //}

                //年龄段
                if (rdoAgeNull.Checked)
                {
                    cpd.Ages = -1;
                }
                else if (rdoEnfant.Checked)
                {
                    cpd.Ages = Convert.ToInt32(App.GetDataSet("select ID from t_data_code where Name='儿童'").Tables[0].Rows[0]["ID"]);
                }
                else if (rdoLad.Checked)
                {
                    cpd.Ages = Convert.ToInt32(App.GetDataSet("select ID from t_data_code where Name='少年'").Tables[0].Rows[0]["ID"]);
                }
                else if (rdoYouth.Checked)
                {
                    cpd.Ages = Convert.ToInt32(App.GetDataSet("select ID from t_data_code where Name='青年'").Tables[0].Rows[0]["ID"]);
                }
                else if (rdoMiddle.Checked)
                {
                    cpd.Ages = Convert.ToInt32(App.GetDataSet("select ID from t_data_code where Name='中年'").Tables[0].Rows[0]["ID"]);
                }
                else if (rdoOld.Checked)
                {
                    cpd.Ages = Convert.ToInt32(App.GetDataSet("select ID from t_data_code where Name='老年'").Tables[0].Rows[0]["ID"]);
                }

                //if (cboSex.SelectedIndex != 0)
                //{
                //    string sex = this.cboSex.SelectedItem.ToString();
                //    if (sex == "男")
                //    {
                //        cpd.Sex = '0';
                //    }
                //    else
                //    {
                //        cpd.Sex = '1'; //女
                //    }
                //}
                //else
                //{
                //    App.MsgErr("请选择性别");
                //    return;
                //}

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


                //科室ID
                if (App.UserAccount.CurrentSelectRole.Section_Id != string.Empty)
                    cpd.Section_ID = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);

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
                if (this.rdbYes.Checked)
                {
                    //默认模板              
                    Sqls.Add("update T_TempPlate set ISDEFAULT='N' where text_type='" + cpd.TextKind + "'");
                    ISDEFAULT = "Y";
                }
                else
                {
                    ISDEFAULT = "N";
                }

                //设置是更新或者新增
                string temp = "";
                if (cboTextKind.SelectedIndex != 0)
                {
                    DataSet samedocs = App.GetDataSet("select tid from T_TempPlate where tname='" + cpd.TName + "' and tid='" + cboTextKind.SelectedValue.ToString() + "'");
                    if (samedocs.Tables[0] != null)
                    {
                        if (samedocs.Tables[0].Rows.Count > 0)
                        {
                            App.MsgWaring("已经存在相同名称的文书，请先修改名称");
                            return;
                        }
                    }
                   
                }
                else
                {
                    string sql = "select * from T_TempPlate where tname='" + cpd.TName + "' and sick_Id='" + sick_Id + "'";
                    DataSet ds = App.GetDataSet(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        App.Msg("此模板已经存在，请更换其它模板名！");
                        return;
                    }
                }

                //插入模版表
                if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SICK_ID,SECTION_ID) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                    + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                    + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                    + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                    + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                    + "'N','N','" + ISDEFAULT + "','" + sick_Id + "'," + App.UserAccount.CurrentSelectRole.Section_Id + ")";

                }
                else
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SICK_ID) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                                       + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                                       + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                                       + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                                       + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                                       + "'N','N','" + ISDEFAULT + "','" + sick_Id + "')";
                }
                Sqls.Add(temp);
                //if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                //{
                    //科室医生保存模板
                    if (cpd.TempPlate_Level == 'S')
                    {
                        Sqls.Add("insert into T_TEMPPLATE_SECTION(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values("+cpd.Tid+",'" + App.UserAccount.CurrentSelectRole.Section_Id + "','N')");
                    }
                //}
                

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

                //过滤模板文件
                DataInit.filterInfo(xmldoc.DocumentElement, Convert.ToInt32(cpd.TextKind));

                string temp3 = InsertLableContent(cpd.Tid, xmldoc.OuterXml);
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
                    this.Close();


                    if (treeView1 != null)
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = cpd;
                        if (txtAutoTPName.Text.Trim() == "")
                            node.Text = cpd.Create_Time;
                        else
                            node.Text = txtAutoTPName.Text;
                        node.ImageIndex = 13;
                        node.SelectedImageIndex = 13;
                        treeView1.SelectedNode.ImageIndex = 6;
                        treeView1.SelectedNode.SelectedImageIndex = 6;
                        treeView1.SelectedNode.Nodes.Add(node);

                        treeView1.Refresh();
                    }
                    //frmTemplateManageMent.ReflashBookTree(treeView1);
                    //InitTree it = new InitTree();

                    // it.InitTreeControl(treeView1);
                }
                else
                {
                    App.MsgErr("保存失败！");
                }
            }

        }

        //输入验证
        private bool InputValid()
        {
            if (cboSys.SelectedIndex == 0)
            {
                App.MsgWaring("请选择所属系统！");
                return false;
            }
            else if (cboSicknessKind.SelectedIndex == 0)
            {
                App.MsgWaring("请选择所属病种！");
                return false;
            }
            else if (txtAutoTPName.Text == "")
            {
                App.MsgErr("请输入模版名称");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 插入标签模板
        /// </summary>
        /// <param name="doc">文书代码</param>
        /// <param name="xmlDoc">标签模板</param>
        /// <returns></returns>       
        public string InsertLableContent(int tid, string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(xmlDoc);
            XmlElement xmlElement = doc.DocumentElement;
            string insertLable = "";
            int message = 0;
            try
            {
                //foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                //{
                //    if (bodyNode.Name == "body")
                //    {
                //        if (bodyNode.HasChildNodes)
                //        {
                            string divTitle = "test";
                            int id = App.GenId("T_TempPlate_Cont", "ID");
                            //插入标签模块
                            insertLable = "insert into T_TempPlate_Cont(ID,TID,LableName,Content)values(" + id + "," + tid + ",'" + divTitle + "',:divContent)";
                            Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                            xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                            xmlPars[0].ParameterName = "divContent";
                            //xmlPars[0].Value = divNode.OuterXml;
                            xmlPars[0].Value = xmlDoc;
                            xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                            xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                            message = App.ExecuteSQL(insertLable, xmlPars);
                    //    }
                    //}
                //}

                if (message != 0)
                {
                    return "成功！";
                }
                else
                {
                    return "失败！";
                }
            }
            catch (Exception ex)
            {
                return "数据库异常！----------------" + ex.ToString();
            }
            finally
            {
                //NClose();
            }
        }


    }
}