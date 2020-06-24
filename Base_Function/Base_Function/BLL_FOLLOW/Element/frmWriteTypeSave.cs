using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TextEditor.TextDocument.Document;
using Bifrost;
using Base_Function.BASE_COMMON;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmWriteTypeSave : DevComponents.DotNetBar.Office2007Form
    {
        private XmlDocument xmldoc;
        private ZYTextDocument doc;
        private TreeView treeView1;
        private string text_type = "";  //保存父节点Id
        private string patient_id = "";
        private string solution_id = "";
        

        public frmWriteTypeSave()
        {
            InitializeComponent();
        }
        public frmWriteTypeSave(XmlDocument xmldoc, TreeView treeView1, ZYTextDocument doc,string text_type,string patient_id,string solution_id)
        {
            InitializeComponent();
            this.xmldoc = xmldoc;
            this.treeView1 = treeView1;
            this.doc = doc;
            this.text_type = text_type;
            this.patient_id = patient_id;
            this.solution_id = solution_id;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                App.Msg("模板标题不得为空");
                txtName.Focus();
            }
            //检查是否重名
            DataSet ds = App.GetDataSet("select * from T_FOLLOW_RECORD_DOC where doc_name='" + txtName.Text.Trim() + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    App.Msg("模板标题重复，请重新输入");
                    txtName.Text = "";
                    return;
                }
            }
            string r_name = txtName.Text.Trim();        //标题
            string f_time = App.GetSystemTime().ToShortDateString();       //创建时间
            string creator = App.UserAccount.UserInfo.User_id;

            string insertLable = "";
            int message = 0;
            try
            {
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
                DataInit.filterInfo(xmldoc.DocumentElement, Convert.ToInt32(text_type));
                int Id = App.GenId("T_FOLLOW_RECORD", "ID");    //T_FOLLOW_RECORD表主键
                int Did = App.GenId("T_FOLLOW_RECORD_DOC", "ID");   //T_FOLLOW_RECORD_DOC表主键
                string MaxTimes = "";
                int Times = 0;
                if (GetMaxTimes(patient_id, solution_id) != "")
                {
                    MaxTimes = GetMaxTimes(patient_id, solution_id);
                    Times = Convert.ToInt32(MaxTimes) + 1;
                }
                string sql = "";
                //插入标签模块
                sql = "insert into T_FOLLOW_RECORD(id,patient_id,follow_times,solution_id,lasttime,creator_id) values(" + Id + "," + patient_id + ","
                + "" + Times + "," + solution_id + ",to_date('" + f_time + "','yyyy-MM-dd')," + creator + ")";
                App.ExecuteSQL(sql);
                insertLable="insert into T_FOLLOW_RECORD_DOC(ID,RECORD_ID,DOC_NAME,TEXT_TYPE,DOC_CONTENT) VALUES("+Did+","+Id+",'"+r_name+"',"+text_type+",:divContent)";
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "divContent";
                //xmlPars[0].Value = divNode.OuterXml;
                xmlPars[0].Value = xmldoc.OuterXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                xmlPars[0].Direction = ParameterDirection.Input;
                message = App.ExecuteSQL(insertLable, xmlPars);

                if (message != 0)
                {
                    UpdateTree(treeView1, text_type, Did, r_name);
                    Template.fmT.MyDoc.ClearContent();
                    treeView1.ExpandAll();
                    this.Close();
                    App.Msg("插入成功！");

                }
                else
                {
                    App.Msg("失败！");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("数据库异常！----------------" + ex.ToString());
            }
            finally
            {
                //NClose();
            }
        }
        /// <summary>
        /// 更新已完成文书树
        /// </summary>
        /// <param name="trv"></param>
        /// <param name="parent_id"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void UpdateTree(TreeView trv, string parent_id, int id, string name)
        {
            foreach (TreeNode node in trv.Nodes)
            {
                if (node.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                {
                    Class_Follow_Text clss = node.Tag as Class_Follow_Text;
                    if (clss.Id.ToString() == parent_id)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Name = id.ToString();
                        tn.Text = name;
                        node.Nodes.Add(tn);
                        break;
                    }
                    Reflash(node, parent_id,id, name);
                }
            }
        }
        public void Reflash(TreeNode node ,string pid,int id,string name)
        {
            if(node.Nodes.Count!=0)
                foreach (TreeNode nd in node.Nodes)
                {
                    if(nd.Tag!=null)
                        if (nd.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                        {
                            Class_Follow_Text clss = nd.Tag as Class_Follow_Text;
                            if (clss.Id.ToString() == pid)
                            {
                                TreeNode tn = new TreeNode();
                                tn.Name = id.ToString();
                                tn.Text = name;
                                nd.Nodes.Add(tn);
                                break;
                            }
                            Reflash(nd, pid, id,name);
                        } 
                }
        }
        /// <summary>
        /// 获取当前文书已写次数
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public string GetMaxTimes(string pid, string sid)
        {
            string sql = "select max(follow_times) from T_FOLLOW_RECORD where patient_id=" + pid + " and solution_id=" + sid + "";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string MaxTimes = ds.Tables[0].Rows[0][0].ToString();
                    return MaxTimes;
                }
                else
                    return "";
            }
            else
                return ""; 
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}