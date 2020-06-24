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
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowTemplateSave : DevComponents.DotNetBar.Office2007Form
    {
        private XmlDocument xmldoc;
        TreeView treeView1;
        private ZYTextDocument doc = null;
       
     
        public frmFollowTemplateSave(XmlDocument xmldoc,TreeView treeView1,ZYTextDocument doc)
        {
            InitializeComponent();
            this.doc = doc;
            this.xmldoc = xmldoc;
            this.treeView1 = treeView1;
        }


        public frmFollowTemplateSave(XmlDocument xmldoc,int kind,ZYTextDocument doc)
        {
            InitializeComponent();
            treeView1 = null;
            this.xmldoc = xmldoc;
            this.doc = doc;
            ucFollowTemplateManagement.text_kind = kind;            
        }

        private void frmFollowTemplateSave_Load(object sender, EventArgs e)
        {
            //treeView1.SelectedNode.Tag;

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
                
            }
            else
            {
                             
                rdoHospital.Visible = true;
            }

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //保存模板
        private void btnOK_Click(object sender, EventArgs e)
        {
            Class_Follow_Patients cpd = new Class_Follow_Patients();

            if (InputValid())
            {
                //模版Id
                cpd.Tid = App.GenId("T_Follow_TempPlate", "TID");

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

                //科室ID
                if (App.UserAccount.CurrentSelectRole.Section_Id != string.Empty)
                    cpd.Section_ID = App.UserAccount.CurrentSelectRole.Section_Id;
                cpd.TextKind = ucFollowTemplateManagement.text_kind.ToString();

                //创建人ID
                cpd.Creator_ID = Convert.ToInt32(App.UserAccount.UserInfo.User_id);
                cpd.Create_Time = App.GetSystemTime().ToShortDateString();

                ArrayList Sqls = new ArrayList();

                //设置默认模板
                string ISDEFAULT = "N";
                if (this.rdbYes.Checked)
                {
                    //默认模板              
                    //Sqls.Add("update T_Follow_TempPlate set ISDEFAULT='Y' where text_type='" + cpd.TextKind + "'");
                    ISDEFAULT = "Y";
                }
                else
                {
                    ISDEFAULT = "N";
                }

                
                string temp = "";
                DataSet samedocs = App.GetDataSet("select tid from T_Follow_TempPlate where tname='" + cpd.TName + "'");
                    if (samedocs.Tables[0] != null)
                    {
                        if (samedocs.Tables[0].Rows.Count > 0)
                        {
                            App.MsgWaring("已经存在相同名称的文书，请先修改名称");
                            return;
                        }
                    }      
                //插入模版表
                if (App.UserAccount.CurrentSelectRole.Section_Id != "")
                {
                    temp = "insert into T_Follow_TempPlate(tid, tname, text_type, tempplate_level, creator_id, enable_flag,ISDEFAULT,SECTION_ID,create_time,creator_role) "
                    +"values(" + cpd.Tid + ",'" + cpd.TName + "',"
                                    + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "',"
                                    +"" + cpd.Creator_ID + ""
                                    + ",'Y','" + ISDEFAULT + "'," + App.UserAccount.CurrentSelectRole.Section_Id + ",to_date('"+cpd.Create_Time+"','yyyy-MM-dd'),'"+App.UserAccount.CurrentSelectRole.Role_name+"')";

                }
                else
                {
                    temp = "insert into T_Follow_TempPlate(tid, tname, , text_type, tempplate_level,   enable_flag,ISDEFAULT,create_time) values(" + cpd.Tid + ",'" + cpd.TName + "',"
                                                       + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "',"

                                                       + "'N','" + ISDEFAULT + "',to_date('" + cpd.Create_Time + "','yyyy-MM-dd'))";
                }
                Sqls.Add(temp);
                if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                {
                    //科室医生保存模板
                    if (cpd.TempPlate_Level == 'S')
                    {
                        Sqls.Add("insert into T_Follow_TEMPPLATE_SECTION(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values("+cpd.Tid+",'" + App.UserAccount.CurrentSelectRole.Section_Id + "','N')");
                    }
                }
                

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

            if (txtAutoTPName.Text == "")
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
                string divTitle = "test";
                int id = App.GenId("T_Follow_TempPlate_Cont", "ID");
                //插入标签模块
                insertLable = "insert into T_Follow_TempPlate_Cont(ID,TID,LableName,Content)values(" + id + "," + tid + ",'" + divTitle + "',:divContent)";
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "divContent";
                //xmlPars[0].Value = divNode.OuterXml;
                xmlPars[0].Value = xmlDoc;
                xmlPars[0].DBType = MySqlDbType.Text;
                xmlPars[0].Direction = ParameterDirection.Input;
                message = App.ExecuteSQL(insertLable, xmlPars);

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