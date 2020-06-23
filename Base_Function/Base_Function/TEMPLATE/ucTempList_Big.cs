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
        string kindtid = "0";   //��������     
        string section_id = "";  //��������

    
        private DataTable dataTable;
        private DataRow newrow;
        private bool isSysInit = false;   //������Դ�Ƿ񴥷��¼���һ��Ŀ¼��
       // private bool isSickInit = false;  //������Դ�Ƿ񴥷��¼�������Ŀ¼��
        private string loadContent = string.Empty;

        string path = "";
        string user_id="";   //�˻�ID
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

                InitSystemList();   //��ʼ��һ��Ŀ¼������ϵͳ��

                GetInfoFromXml();

                cboUseRange.Text = "����";
            }
            catch
            { }

        }

        //��Xml�ļ��ж�ȡ��Ϣ
        private void GetInfoFromXml()
        {
            string user_id = App.UserAccount.Account_id;
            //string range = "";
            //string sys = "";
            //string type = "";
            string path = Application.StartupPath + @"\TemplateList.xml";

            if (!File.Exists(path))   //����ļ�������
            {
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

                //writer.Formatting = Formatting.Indented;  //��������
                //writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("TemplateList");
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
            }

            //����һ��XML����
            XmlDocument myXml = new XmlDocument();

            bool isGetItem = false;     //�Ƿ��ܻ��Item
            //��ȡXML�ļ�
            try
            {
                myXml.Load(path);
                //����TemplateList�ڵ�
                XmlNode root = myXml.SelectSingleNode("TemplateList");


                if (root.ChildNodes.Count > 0)
                {
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (user_id == node.Attributes["value"].Value)  //���ڴ��˻�
                        {
                            if (node.ChildNodes.Count > 0)
                            {
                                foreach (XmlNode subNode in node.SelectNodes("Item"))
                                {
                                    if (Kindtid == subNode.Attributes["value"].Value)    //���ڴ�����Ϣ
                                    {
                                        SetFormInfo(subNode);
                                        isGetItem = true;     //��Item����
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch  //���xml�����쳣����xml�е��������
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

        //���ô�����Ϣ
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
                this.cboSys.SelectedIndex = 0;     //��ֵΪ��ʱ��������Ϊ����ѡ��...��
            }

            InitSickList(sysXml);

            string typeXml = subNode.SelectSingleNode("Type").Attributes["value"].Value.ToString();
            if (typeXml != "")
            {
                this.cboSicknessKind.SelectedValue = typeXml;
            }
            else
            {
                this.cboSicknessKind.SelectedIndex = 0;   //��ֵΪ��ʱ��������Ϊ����ѡ��...��
            }

            range = this.cboUseRange.Text;
            sys = this.cboSys.SelectedValue.ToString();
            type = this.cboSicknessKind.SelectedValue.ToString();

            string msg = " ";
            string gpstyle = "";
            //ʹ�÷�Χ
            if (range == "��ѡ��...")
            {
                msg += "";
            }
            else if (range == "����")
            {
                msg += " and tempplate_level='P'"; //����
            }
            else if (range == "����")
            {
                msg += " and tempplate_level='S'"; //����
                gpstyle = "S";
            }
            else if (range == "������")
            {
                msg += " and tempplate_level='G'"; //����
                gpstyle = "G";
            }
            else if (range == "ȫԺ")
            {
                msg += " and tempplate_level='H'"; //ȫԺ
            }

            //����ϵͳ
            if (this.cboSys.Text == "��ѡ��...")
            {
                msg += "";
            }
            else
            {
                msg += " and s.sick_system='" + sys + "'";
            }

            //��������
            if (this.cboSicknessKind.Text == "��ѡ��...")
            {
                msg += "";
            }
            else
            {
                msg += " and t.sick_id='" + type + "'";
            }


            this.chbDefaultSelect.Checked = true;   //��ѡ��ѡ��
            GetTemplateByCondition(msg, gpstyle);
        }

        //����Ϣд��Xml��
        private void SetInfoToXml()
        {
            try
            {
                path = Application.StartupPath + @"\TemplateList.xml";
                if (!File.Exists(path))   //����ļ�������
                {
                    XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

                    //writer.Formatting = Formatting.Indented;  //��������
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
                //����TemplateList�ڵ�
                XmlNode root = myXml.SelectSingleNode("TemplateList");

                range = this.cboUseRange.Text.ToString();
                sys = this.cboSys.Text.ToString();
                type = this.cboSicknessKind.Text.ToString();

                bool isCreateUser=false;
                bool isCreateItem = false;
                if (root.ChildNodes.Count > 0)   //TemplateList�ڵ��´����˺���Ϣ
                {
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["value"].Value == user_id)  //�Ѿ����ڴ��˺�
                        {
                            isCreateUser = true;
                            if (node.ChildNodes.Count > 0)    //���˺��´���Item�ڵ�
                            {
                                foreach (XmlNode subNode in node.SelectNodes("Item"))  
                                {
                                    if (subNode.Attributes["value"].Value == Kindtid)    //�û���Item�Ѿ�����
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

                                //ȫ��ѭ�������ж�,���˻��²����ڴ˽ڵ�
                                if (isCreateItem==false)  
                                {
                                    CreateNewItem(myXml, node);
                                }
                            }
                            else     //���˺��²�����Item�ڵ�
                            {
                                CreateNewItem(myXml, node);
                            }
                        }
                    }

                    //ȫ��ѭһ�飬�����ڴ��˻�
                    if (isCreateUser == false)
                    {
                        CreateNewUser(myXml, root);
                    }
                }
                else  //TemplateList�ڵ��²������˺���Ϣ
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

        //��������
        private void CreateNewItem(XmlDocument myXml, XmlNode node)
        {
            //����Item�ڵ�
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

            //��ӵ�TemplateList�ڵ���
            node.AppendChild(xel1);
            myXml.Save(path);
        }

        //����һ�����û�
        private void CreateNewUser(XmlDocument myXml, XmlNode root)
        {
            //����User�ڵ�
            XmlElement xel = myXml.CreateElement("User");
            xel.SetAttribute("value", user_id);

            //����Item�ڵ�
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

            //��ӵ�TemplateList�ڵ���
            xel.AppendChild(xel1);
            root.AppendChild(xel);
            myXml.Save(path);
        }



        //�������������ģ��
        private void GetTemplateByCondition(string msg,string GStyle)
        {
            //inner join T_TEMPPLATE_GROUP d on t.tid=d.template_id
            DataSet ds = new DataSet();
            string Sql = "select distinct t.Tid,t.tname as ģ������,t.create_time as ����ʱ��,t.TEMPPLATE_LEVEL as ģ�弶�� from t_tempplate t inner join t_sick_type s on t.sick_id=s.id ";
            if (GStyle=="G")
                Sql = "select distinct t.Tid,t.tname as ģ������,t.create_time as ����ʱ��,t.TEMPPLATE_LEVEL as ģ�弶�� from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_GROUP c on t.tid=c.template_id";
            else if (GStyle == "S")
                Sql = "select distinct t.Tid,t.tname as ģ������,t.create_time as ����ʱ��,t.TEMPPLATE_LEVEL as ģ�弶�� from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_SECTION c on t.tid=c.template_id ";

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

        //һ��Ŀ¼ѡ����ı��¼�
        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSysInit)
            {
                string msg = this.cboSys.SelectedValue.ToString();
                InitSickList(msg);
            }
        }

        //��ʼ��һ��Ŀ¼������ϵͳ��
        private void InitSystemList()
        {
            isSysInit = false;   //������Դ�Ƿ񴥷��¼�

            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";

            isSysInit = true;  //������Դ�Ƿ񴥷��¼�
        }

        //��ʼ������Ŀ¼�������ࣩ
        private void InitSickList(string msg)
        {
            //isSickInit = false;  //������Դ�Ƿ񴥷��¼�

            string sql = "select s.ID,SICK_CODE," +
                        @"SICK_NAME,SICK_SYSTEM, " +
                        @"t.name as Name  from T_SICK_TYPE s " +
                        @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
            //��ʼ������
            DataSet dsSick = App.GetDataSet(sql);
            dataTable = dsSick.Tables[0];
            newrow = dataTable.NewRow();
            newrow[2] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSicknessKind.DataSource = dataTable.DefaultView;
            this.cboSicknessKind.ValueMember = "ID";
            this.cboSicknessKind.DisplayMember = "SICK_NAME";

            //isSickInit = true;  //������Դ�Ƿ񴥷��¼�
        }

        //��ѯ
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

            //���ݲ�ͬ��ѯ������ѯ
            if (template_level == "��ѡ��..." && template_name == "" && sys == "��ѡ��...")
            {
                msg = "";
            }
            else
            {
              
                if (template_level != "��ѡ��...")
                {

                    //ʹ�÷�Χ
                    if (template_level == "����")
                    {
                        msg = " and tempplate_level='P' and CREATOR_ID='" + App.UserAccount.Account_id + "'"; //����
                    }
                    if (template_level == "����")
                    {
                        msg = " and tempplate_level='S' and t.SECTION_ID='" + section_id + "'"; //����
                        Styleflag = "S";
                    }
                    if (template_level == "������")
                    {
                        msg = " and tempplate_level='G' and GROUP_ID='" + App.UserAccount.Group_id + "'"; //����
                        Styleflag = "G";
                    }
                    if (template_level == "ȫԺ")
                    {
                        msg = " and tempplate_level='H'"; //ȫԺ
                    }
                    if (template_name != "")
                    {
                        msg += " and tname like '%" + template_name + "%'";
                    }
                    if (sys != "��ѡ��...")
                    {
                        msg += " and s.sick_system='" + sys + "'";
                        if (sick_kind != "��ѡ��...")
                        {
                            msg += " and t.sick_id='" + sick_kind + "'";
                        }
                    }
                }
                else if (template_level == "��ѡ��...")
                {
                    if (template_name != "")
                    {
                        msg += " and tname like '%" + template_name + "%'";
                    }
                    if (sys != "��ѡ��...")
                    {
                        msg += " and s.sick_system='" + sys + "'";
                        if (sick_kind != "��ѡ��...")
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

                    //����TemplateList�ڵ�
                    XmlNode root = myXml.SelectSingleNode("TemplateList");
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Attributes["value"].Value == App.UserAccount.Account_id)  //�Ѿ����ڴ��˺�
                        {
                            foreach (XmlNode subNode in node.SelectNodes("Item"))
                            {
                                if (subNode.Attributes["value"].Value == Kindtid)    //Item�ڵ��Ѿ�����
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
