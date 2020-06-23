using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using System.IO;

namespace Base_Function.TEMPLATE
{
    public partial class ucTempList_Big : UserControl
    {
        string kindtid = "0";   //文书类型     
        string section_id = "";  //所属科室

    
        private DataTable dataTable;
        private DataRow newrow;
        private bool isSysInit = false;   //绑定数据源是否触发事件（一级目录）
       // private bool isSickInit = false;  //绑定数据源是否触发事件（二级目录）
        private string loadContent = string.Empty;

        string path = "";
        string user_id="";   //账户ID
        string range = "";
        string sys = "";
        string type = "";


        public string Kindtid
        {
            get { return kindtid; }
            set { kindtid = value; }
        }

        private string _tid;
        public string Tid
        {
            get { return _tid; }
            set { _tid = value; }
        }

        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }

        public ucTempList_Big()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void ucTempList_Load(object sender, EventArgs e)
        {
            try
            {
                user_id = App.UserAccount.Account_id;
                section_id = App.UserAccount.CurrentSelectRole.Section_Id;
                App.UsControlStyle(this);
                GetTemplateByCondition("","S");

                InitSystemList();   //初始化一级目录（所属系统）

                GetInfoFromXml();

                cboUseRange.Text = "科室";
            }
            catch
            { }

        }

        //从Xml文件中读取信息
        private void GetInfoFromXml()
        {
            string user_id = App.UserAccount.Account_id;
            //string range = "";
            //string sys = "";
            //string type = "";
            string path = Application.StartupPath + @"\TemplateList.xml";

            if (!File.Exists(path))   //如果文件不存在
            {
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

                //writer.Formatting = Formatting.Indented;  //设置缩进
                //writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("TemplateList");
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }

            //创建一个XML对象
            XmlDocument myXml = new XmlDocument();

            bool isGetItem = false;     //是否能获得Item
            //获取XML文件
            try
            {
                myXml.Load(path);
                //查找TemplateList节点
                XmlNode root = myXml.SelectSingleNode("TemplateList");


                if (root.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (user_id == node.Attributes["value"].Value)  //存在此账户
                        {
                            if (node.ChildNodes.Count > 0)
                            {
                                foreach (XmlNode subNode in node.SelectNodes("Item"))
                                {
                                    if (Kindtid == subNode.Attributes["value"].Value)    //存在此项信息
                                    {
                                        SetFormInfo(subNode);
                                        isGetItem = true;     //此Item存在
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch  //如果xml出现异常，将xml中的内容清空
            {
                File.Delete(path);
            }
            finally
            {
                if (isGetItem == false)
                {
                    this.cboUseRange.SelectedIndex = 0;
                    this.cboSicknessKind.SelectedIndex = 0;
                }
            }
        }

        //设置窗体信息
        private void SetFormInfo(XmlNode subNode)
        {
            this.cboUseRange.Text = subNode.SelectSingleNode("Range").InnerText;

            string sysXml = subNode.SelectSingleNode("System").Attributes["value"].Value.ToString();
            if (sysXml != "")
            {
                this.cboSys.SelectedValue = sysXml;
            }
            else
            {
                this.cboSys.SelectedIndex = 0;     //当值为空时，下拉框为“请选择...”
            }

            InitSickList(sysXml);

            string typeXml = subNode.SelectSingleNode("Type").Attributes["value"].Value.ToString();
            if (typeXml != "")
            {
                this.cboSicknessKind.SelectedValue = typeXml;
            }
            else
            {
                this.cboSicknessKind.SelectedIndex = 0;   //当值为空时，下拉框为“请选择...”
            }

            range = this.cboUseRange.Text;
            sys = this.cboSys.SelectedValue.ToString();
            type = this.cboSicknessKind.SelectedValue.ToString();

            string msg = " ";
            string gpstyle = "";
            //使用范围
            if (range == "请选择...")
            {
                msg += "";
            }
            else if (range == "个人")
            {
                msg += " and tempplate_level='P'"; //个人
            }
            else if (range == "科室")
            {
                msg += " and tempplate_level='S'"; //科室
                gpstyle = "S";
            }
            else if (range == "诊疗组")
            {
                msg += " and tempplate_level='G'"; //科室
                gpstyle = "G";
            }
            else if (range == "全院")
            {
                msg += " and tempplate_level='H'"; //全院
            }

            //所属系统
            if (this.cboSys.Text == "请选择...")
            {
                msg += "";
            }
            else
            {
                msg += " and s.sick_system='" + sys + "'";
            }

            //病种类型
            if (this.cboSicknessKind.Text == "请选择...")
            {
                msg += "";
            }
            else
            {
                msg += " and t.sick_id='" + type + "'";
            }


            this.chbDefaultSelect.Checked = true;   //复选框选中
            GetTemplateByCondition(msg, gpstyle);
        }

        //将信息写入Xml中
        private void SetInfoToXml()
        {
            try
            {
                path = Application.StartupPath + @"\TemplateList.xml";
                if (!File.Exists(path))   //如果文件不存在
                {
                    XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

                    //writer.Formatting = Formatting.Indented;  //设置缩进
                    //writer.Indentation = 4;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("TemplateList");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Flush();
                    writer.Close();
                }

                XmlDocument myXml = new XmlDocument();
                myXml.Load(path);
                //查找TemplateList节点
                XmlNode root = myXml.SelectSingleNode("TemplateList");

                range = this.cboUseRange.Text.ToString();
                sys = this.cboSys.Text.ToString();
                type = this.cboSicknessKind.Text.ToString();

                bool isCreateUser=false;
                bool isCreateItem = false;
                if (root.ChildNodes.Count > 0)   //TemplateList节点下存在账号信息
                {
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["value"].Value == user_id)  //已经存在此账号
                        {
                            isCreateUser = true;
                            if (node.ChildNodes.Count > 0)    //此账号下存在Item节点
                            {
                                foreach (XmlNode subNode in node.SelectNodes("Item"))  
                                {
                                    if (subNode.Attributes["value"].Value == Kindtid)    //用户的Item已经存在
                                    {
                                        subNode.SelectSingleNode("Range").InnerText = range;

                                        subNode.SelectSingleNode("System").InnerText = sys;
                                        subNode.SelectSingleNode("System").Attributes["value"].Value = this.cboSys.SelectedValue.ToString();

                                        subNode.SelectSingleNode("Type").InnerText = type;
                                        subNode.SelectSingleNode("Type").Attributes["value"].Value = this.cboSicknessKind.SelectedValue.ToString();
                                        myXml.Save(path);
                                        isCreateItem=true;
                                        break;
                                    }
                                }

                                //全部循环后做判断,此账户下不存在此节点
                                if (isCreateItem==false)  
                                {
                                    CreateNewItem(myXml, node);
                                }
                            }
                            else     //此账号下不存在Item节点
                            {
                                CreateNewItem(myXml, node);
                            }
                        }
                    }

                    //全部循一遍，不存在此账户
                    if (isCreateUser == false)
                    {
                        CreateNewUser(myXml, root);
                    }
                }
                else  //TemplateList节点下不存在账号信息
                {
                    CreateNewUser(myXml, root);
                }
            }
            catch
            {
                File.Delete(path);
                SetInfoToXml();
            }
        }

        //创建新项
        private void CreateNewItem(XmlDocument myXml, XmlNode node)
        {
            //创建Item节点
            XmlElement xel1 = myXml.CreateElement("Item");
            xel1.SetAttribute("value", Kindtid);

            XmlElement xesub1 = myXml.CreateElement("Range");
            xesub1.InnerText = range;
            xel1.AppendChild(xesub1);

            XmlElement xesub2 = myXml.CreateElement("System");
            xesub2.SetAttribute("value", this.cboSys.SelectedValue.ToString());
            xesub2.InnerText = sys;
            xel1.AppendChild(xesub2);

            XmlElement xesub3 = myXml.CreateElement("Type");
            if (this.cboSicknessKind.SelectedValue != null)
            {
                xesub3.SetAttribute("value", this.cboSicknessKind.SelectedValue.ToString());
            }
            else
            {
                xesub3.SetAttribute("value", "");
            }
            xesub3.InnerText = type;
            xel1.AppendChild(xesub3);

            //添加到TemplateList节点中
            node.AppendChild(xel1);
            myXml.Save(path);
        }

        //创建一个新用户
        private void CreateNewUser(XmlDocument myXml, XmlNode root)
        {
            //创建User节点
            XmlElement xel = myXml.CreateElement("User");
            xel.SetAttribute("value", user_id);

            //创建Item节点
            XmlElement xel1 = myXml.CreateElement("Item");
            xel1.SetAttribute("value", Kindtid);

            XmlElement xesub1 = myXml.CreateElement("Range");
            xesub1.InnerText = range;
            xel1.AppendChild(xesub1);

            XmlElement xesub2 = myXml.CreateElement("System");
            xesub2.SetAttribute("value", this.cboSys.SelectedValue.ToString());
            xesub2.InnerText = sys;
            xel1.AppendChild(xesub2);

            XmlElement xesub3 = myXml.CreateElement("Type");
            if (this.cboSicknessKind.SelectedValue != null)
            {
                xesub3.SetAttribute("value", this.cboSicknessKind.SelectedValue.ToString());
            }
            else
            {
                xesub3.SetAttribute("value", "");
            }
            xesub3.InnerText = type;
            xel1.AppendChild(xesub3);

            //添加到TemplateList节点中
            xel.AppendChild(xel1);
            root.AppendChild(xel);
            myXml.Save(path);
        }



        //根据条件，获得模板
        private void GetTemplateByCondition(string msg,string GStyle)
        {
            //inner join T_TEMPPLATE_GROUP d on t.tid=d.template_id
            DataSet ds = new DataSet();
            string Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id ";
            if (GStyle=="G")
                Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_GROUP c on t.tid=c.template_id";
            else if (GStyle == "S")
                Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_SECTION c on t.tid=c.template_id ";

            if (msg == "")
            {
                ds.Clear();
                string tempSql = Sql+" where t.text_type='" + Kindtid + "' and t.tempplate_level='S' and c.SECTION_ID='" + section_id + "'";
                ds = App.GetDataSet(tempSql);
            }
            else
            {
                ds.Clear();
                string tempSql = Sql+" where text_type='" + Kindtid + "'" + msg;
                ds = App.GetDataSet(tempSql);
            }
            if (ds != null)
            {
                flgView.DataSource = ds.Tables[0].DefaultView;
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
            //isSickInit = false;  //绑定数据源是否触发事件

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

            //isSickInit = true;  //绑定数据源是否触发事件
        }

        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Styleflag = "";
            string msg = "";
            string template_level = this.cboUseRange.Text.Trim();
            string sick_kind = "";
            string sys = "";
            string template_name = this.txtTemplateName.Text.Trim();
            if (cboSys.SelectedIndex == 0)
            {
                sys = this.cboSys.Text;
            }
            else
            {
                sys = this.cboSys.SelectedValue.ToString();
            }
            if (cboSicknessKind.SelectedIndex == 0)
            {
                sick_kind = this.cboSicknessKind.Text;
            }
            else
            {
                sick_kind = this.cboSicknessKind.SelectedValue.ToString();
            }

            //根据不同查询条件查询
            if (template_level == "请选择..." && template_name == "" && sys == "请选择...")
            {
                msg = "";
            }
            else
            {
              
                if (template_level != "请选择...")
                {

                    //使用范围
                    if (template_level == "个人")
                    {
                        msg = " and tempplate_level='P' and CREATOR_ID='" + App.UserAccount.Account_id + "'"; //个人
                    }
                    if (template_level == "科室")
                    {
                        msg = " and tempplate_level='S' and t.SECTION_ID='" + section_id + "'"; //科室
                        Styleflag = "S";
                    }
                    if (template_level == "诊疗组")
                    {
                        msg = " and tempplate_level='G' and GROUP_ID='" + App.UserAccount.Group_id + "'"; //科室
                        Styleflag = "G";
                    }
                    if (template_level == "全院")
                    {
                        msg = " and tempplate_level='H'"; //全院
                    }
                    if (template_name != "")
                    {
                        msg += " and tname like '%" + template_name + "%'";
                    }
                    if (sys != "请选择...")
                    {
                        msg += " and s.sick_system='" + sys + "'";
                        if (sick_kind != "请选择...")
                        {
                            msg += " and t.sick_id='" + sick_kind + "'";
                        }
                    }
                }
                else if (template_level == "请选择...")
                {
                    if (template_name != "")
                    {
                        msg += " and tname like '%" + template_name + "%'";
                    }
                    if (sys != "请选择...")
                    {
                        msg += " and s.sick_system='" + sys + "'";
                        if (sick_kind != "请选择...")
                        {
                            msg += " and t.sick_id='" + sick_kind + "'";
                        }
                    }
                }
            }
            GetTemplateByCondition(msg, Styleflag);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //if (this.flgView.RowSel > 0)
            //{
            //    string temp = "select Content from T_TempPlate_Cont where tid=" + flgView[flgView.RowSel, "Tid"].ToString();
            //    DataSet dsTemp = App.GetDataSet(temp);
            //    DataTable dtTemp = dsTemp.Tables[0];
            //    string content = "";
            //    for (int i = 0; i < dtTemp.Rows.Count; i++)
            //    {
            //        content = content + dtTemp.Rows[i][0].ToString();
            //    }
            //    this.loadContent = content;                
            //    this.Close();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.loadContent = string.Empty;
            //this.Close();
        }

        private void frmTemplateList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("1111");
            if (chbDefaultSelect.Checked)
            {
                SetInfoToXml();
            }
            else
            {
                string path = Application.StartupPath + @"\TemplateList.xml";
                if (File.Exists(path))
                {
                    XmlDocument myXml = new XmlDocument();
                    myXml.Load(path);

                    //查找TemplateList节点
                    XmlNode root = myXml.SelectSingleNode("TemplateList");
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["value"].Value == App.UserAccount.Account_id)  //已经存在此账号
                        {
                            foreach (XmlNode subNode in node.SelectNodes("Item"))
                            {
                                if (subNode.Attributes["value"].Value == Kindtid)    //Item节点已经存在
                                {
                                    //subNode.RemoveAll();
                                    node.RemoveChild(subNode);
                                    myXml.Save(path);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void flgView_Click(object sender, EventArgs e)
        {
            if (flgView.Rows.Count > 1)
            {              
                Tid = flgView[flgView.RowSel, "Tid"].ToString();
            }
        }
    }
}
