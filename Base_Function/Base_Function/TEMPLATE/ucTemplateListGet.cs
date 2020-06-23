using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    /// <summary>
    /// 名称：新模板提取
    /// 时间：2012-3-22
    /// 作者：张华
    /// </summary>
    public partial class ucTemplateListGet : UserControl
    {

        private string kindtid = "0";   //文书类型     
        private string section_id = "";  //所属科室
        private DataTable dataTable;
        private DataRow newrow;    
        private DataSet TextData;        //文书类型集合

        public EventHandler TemplateSelect;

        public string Kindtid
        {
            get { return kindtid; }
            set { kindtid = value; }
        }

        /// <summary>
        /// 当前选中的模板
        /// </summary>
        private string loadContent;
        public string LoadContent
        {
            get { return loadContent; }
            set { loadContent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string templateId;
        public string TemplateId
        {
            get { return templateId; }
            set { templateId = value; }
        }

        /// <summary>
        /// 模板类型
        /// </summary>
        private string temptype;
        public string Temptype
        {
            get { return temptype; }
            set { temptype = value; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public ucTemplateListGet()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        /// <summary>
        /// 刷新操作
        /// </summary>
        /// <param name="tid"></param>
        public void Reflesh(string tid)
        {
            try
            {
                Kindtid = tid;               
                BigCheck();              
                SmallCheck();             
            }
            catch
            { }
        }

        //初始化一级目录（所属系统）
        private void InitSystemList(ref ComboBox cbobox)
        {           
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            cbobox.DataSource = dataTable.DefaultView;
            cbobox.ValueMember = "ID";
            cbobox.DisplayMember = "Name";          
        }

        //初始化二级目录（病种类）
        private void InitSickList(ref ComboBox cbobox, string msg)
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
                newrow = dataTable.NewRow();
                newrow[2] = "请选择...";
                dataTable.Rows.InsertAt(newrow, 0);
                cbobox.DataSource = dataTable.DefaultView;
                cbobox.ValueMember = "ID";
                cbobox.DisplayMember = "SICK_NAME";                
            }
            catch
            { }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
               
                    string content = "";
                    string temp = "";
                    if (tabControl1.SelectedTab.Text == "大模板")
                    {
                        if (advTreeBigTemplate.SelectedNode.Nodes.Count == 0)
                        {
                            temp = "select Content from T_TempPlate_Cont where tid=" + advTreeBigTemplate.SelectedNode.Name;
                            this.TemplateId = advTreeBigTemplate.SelectedNode.Name;
                            this.Temptype = "B";
                        }
                    }
                    else
                    {
                        if (advTreeSmallTemplate.SelectedNode.Nodes.Count == 0)
                        {
                            temp = "select Content from T_TempPlate_Cont where tid=" + advTreeSmallTemplate.SelectedNode.Name;
                            this.TemplateId = advTreeSmallTemplate.SelectedNode.Name;
                            this.Temptype = "S";
                        }
                    }
                    DataSet dsTemp = App.GetDataSet(temp);
                    if (dsTemp != null)
                    {
                        DataTable dtTemp = dsTemp.Tables[0];

                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            content = content + dtTemp.Rows[i][0].ToString();
                        }
                        this.loadContent = content;
                        TemplateSelect(sender, e);
                    }
                    else
                    {
                        App.MsgWaring("请先选择要插入的模板！");
                    }               
            }
            catch
            {
                App.MsgErr("请选择正确的模板！");
            }
        }

        /// <summary>
        /// 加载过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucTemplateListGet_Load(object sender, EventArgs e)
        {
            section_id = App.UserAccount.CurrentSelectRole.Section_Id;
            TextData = App.GetDataSet("select t.id,t.textname from t_text t");
            //大模板
            InitSystemList(ref cboBigSys);
            InitSickList(ref cboBigSicknessKind, cboBigSys.SelectedValue.ToString());
            cboBigUseRange.SelectedIndex = 2;
            //小模板
            InitSystemList(ref cboSys1);
            InitSickList(ref cboSmallSicknessKind, cboSys1.SelectedValue.ToString());
            cboSmallUseRange.SelectedIndex = 1;
            btnSearch_Click(sender, e);
            buttonX1_Click(sender, e);
        }                

        #region 大模板
        //根据条件，获得模板
        private void GetTemplateByCondition(string msg, string GStyle)
        {           
            //inner join T_TEMPPLATE_GROUP d on t.tid=d.template_id
            DataSet ds = new DataSet();
            string Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id ";
            if (GStyle == "G")
                Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_GROUP c on t.tid=c.template_id";
            else if (GStyle == "S")
                Sql = "select distinct t.Tid,t.tname as 模板名称,t.create_time as 创建时间,t.TEMPPLATE_LEVEL as 模板级别 from t_tempplate t inner join t_sick_type s on t.sick_id=s.id inner join T_TEMPPLATE_SECTION c on t.tid=c.template_id ";

            if (msg == "")
            {
                ds.Clear();
                string tempSql = Sql + " where t.text_type='" + Kindtid + "' and t.tempplate_level='S' and t.SECTION_ID='" + section_id + "'";
                ds = App.GetDataSet(tempSql);
            }
            else
            {
                ds.Clear();
                string tempSql = Sql + " where text_type='" + Kindtid + "'" + msg;
                ds = App.GetDataSet(tempSql);
            }
            if (ds != null)
            {
                advTreeBigTemplate.Nodes.Clear();
                /*
                 * 类型主节点
                 */
                DevComponents.AdvTree.Node templateKindNode=new DevComponents.AdvTree.Node();
                templateKindNode.Text = TextData.Tables[0].Select("id=" + Kindtid + "")[0]["textname"].ToString();
                templateKindNode.Name = Kindtid+"_";
                templateKindNode.ImageIndex = 12;        
                /*
                 *模板集合
                 */
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DevComponents.AdvTree.Node templateNode = new DevComponents.AdvTree.Node();
                    templateNode.Text = ds.Tables[0].Rows[i]["模板名称"].ToString();
                    templateNode.Name = ds.Tables[0].Rows[i]["Tid"].ToString();
                    templateKindNode.Nodes.Add(templateNode);
                    templateNode.ImageIndex = 13;
                }
                advTreeBigTemplate.Nodes.Add(templateKindNode);
                advTreeBigTemplate.ExpandAll();
            }
        }

        /// <summary>
        /// 大模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advTreeBigTemplate_DoubleClick(object sender, EventArgs e)
        {
            btnSure_Click(sender, e);
        }

        /// <summary>
        /// 大模板查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BigCheck();
        }

        /// <summary>
        /// 大模板查询函数
        /// </summary>
        private void BigCheck()
        {
            try
            {
                string Styleflag = "";
                string msg = "";
                string template_level = this.cboBigUseRange.Text.Trim();
                string sick_kind = "";
                string sys = "";
                string template_name = "";
                if (cboBigSys.SelectedIndex == 0)
                {
                    sys = this.cboBigSys.Text;
                }
                else
                {
                    sys = this.cboBigSys.SelectedValue.ToString();
                }
                if (cboBigSicknessKind.SelectedIndex == 0)
                {
                    sick_kind = this.cboBigSicknessKind.Text;
                }
                else
                {
                    sick_kind = this.cboBigSicknessKind.SelectedValue.ToString();
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
                            msg = " and tempplate_level='S' and c.SECTION_ID='" + section_id + "'"; //科室
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
            catch
            { }
        }

        private void cboBigSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSickList(ref cboBigSicknessKind, cboBigSys.SelectedValue.ToString());
        }
        #endregion

        #region 小模板
        /// <summary>
        /// 小模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advTreeSmallTemplate_DoubleClick(object sender, EventArgs e)
        {
            btnSure_Click(sender, e);
        }

        /// <summary>
        /// 小模板查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            SmallCheck();
        }

        /// <summary>
        /// 小模板查询
        /// </summary>
        private void SmallCheck()
        {
            try
            {
                string tempSql = "";

                if (cboSmallUseRange.Text == "个人")
                {
                    tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID,smalltemptype from t_tempplate t where tempplate_level='P' and temptype='S' and creator_id=" + App.UserAccount.Account_id + "";
                }
                else if (cboSmallUseRange.Text == "科室")
                {
                    tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID,smalltemptype from t_tempplate t where tempplate_level='S' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
                }
                else if (cboSmallUseRange.Text == "诊疗组")
                {
                    tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID,smalltemptype from t_tempplate t where tempplate_level='G' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
                }
                else
                {
                    //tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID from t_tempplate t where temptype='S'";
                }

                //病种分类
                if (chkSys.Checked)
                {
                    tempSql = tempSql + " and SICK_ID='" + cboSmallSicknessKind.SelectedValue.ToString() + "'";
                }

                DataSet ds = App.GetDataSet(tempSql);
                if (ds != null)
                {
                    /*
                     *模板种类节点节点
                     */
                    advTreeSmallTemplate.Nodes.Clear();
                    DataSet dsSys = App.GetDataSet("select id,name from t_data_code where type='174'");
                    for (int i = 0; i < dsSys.Tables[0].Rows.Count; i++)
                    {
                        DevComponents.AdvTree.Node temptypenode = new DevComponents.AdvTree.Node();
                        temptypenode.Text = dsSys.Tables[0].Rows[i]["name"].ToString();
                        temptypenode.Name = dsSys.Tables[0].Rows[i]["id"].ToString() + "_";
                        temptypenode.ImageIndex = 12;
                        /*
                         *对应的模板节点
                         */
                        DataRow[] rows = ds.Tables[0].Select("smalltemptype='" +dsSys.Tables[0].Rows[i]["id"] + "'");
                        for (int j = 0; j < rows.Length; j++)
                        {
                            //smalltemptype  
                            DevComponents.AdvTree.Node tempnode = new DevComponents.AdvTree.Node();
                            tempnode.Text = rows[j]["模板名称"].ToString();
                            tempnode.Name = rows[j]["Tid"].ToString();
                            tempnode.ImageIndex = 14;
                            temptypenode.Nodes.Add(tempnode);
                        }
                        if (rows.Length>0)
                        {
                            advTreeSmallTemplate.Nodes.Add(temptypenode);
                        }                       
                    }
                    advTreeSmallTemplate.ExpandAll();
                }
            }
            catch
            { }
        }

        private void cboSys1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSickList(ref cboSmallSicknessKind, cboSys1.SelectedValue.ToString());
        }
        #endregion

        /// <summary>
        /// 删除相关的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("确定要删除'" + advTreeBigTemplate.SelectedNode.Text + "' 的模板吗？"))
            {
                try
                {
                    if (advTreeBigTemplate.SelectedNode.Parent != null)
                    {
                        string[] sqls = new string[3];
                        sqls[0] = "delete from t_tempplate a where a.tid=" + advTreeBigTemplate.SelectedNode.Name + "";
                        sqls[1] = "delete from T_TEMPPLATE_CONT a where a.tid=" + advTreeBigTemplate.SelectedNode.Name + "";
                        sqls[2] = "delete from T_TEMPPLATE_SECTION a where a.TEMPLATE_ID=" + advTreeBigTemplate.SelectedNode.Name + "";

                        if (cboBigUseRange.Text == "科室")
                        {
                            DataSet ds = App.GetDataSet("select a.tid,a.creator_id from t_tempplate a where a.tid=" + advTreeBigTemplate.SelectedNode.Name + "");
                            if ((ds.Tables[0].Rows[0]["creator_id"].ToString() == App.UserAccount.Account_id || App.UserAccount.CurrentSelectRole.Role_name.Contains("主任")) &&
                                ds.Tables[0].Rows[0]["creator_id"].ToString() != "3" //管理员
                                )
                            {

                                if (App.ExecuteBatch(sqls) > 0)
                                {
                                    App.Msg("操作已经成功！");
                                    btnSearch_Click(sender, e);
                                }
                                else
                                {
                                    App.MsgErr("操作失败！");
                                }

                            }
                            else
                            {
                                App.MsgWaring("您无权删除该模板！");
                            }

                        }
                        else if (cboBigUseRange.Text == "个人")
                        {
                            DataSet ds = App.GetDataSet("select a.tid,a.creator_id from t_tempplate a where a.tid=" + advTreeBigTemplate.SelectedNode.Name + " and a.creator_id=" + App.UserAccount.Account_id + "");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (App.ExecuteBatch(sqls) > 0)
                                {
                                    App.Msg("操作已经成功！");
                                    btnSearch_Click(sender, e);
                                }
                                else
                                {
                                    App.MsgErr("操作失败！");
                                }

                            }
                            else
                            {
                                App.MsgWaring("您无权删除该模板！");

                            }

                        }
                        else
                        {
                            App.MsgWaring("您无权删除该模板！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.MsgErr("操作失败！" + ex.Message);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            if (advTreeBigTemplate.SelectedNode.Parent != null)
            {
                if (cboBigUseRange.Text == "科室" || cboBigUseRange.Text == "个人")
                {
                    contextMenuStrip1.Enabled = true;
                }
                else
                {
                    contextMenuStrip1.Enabled = false;
                }
            }
            else
            {
                contextMenuStrip1.Enabled = false;
            }
                
           
        }

        private void chkSys_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSys.Checked == true)
            {
                this.cboSys1.Enabled = true;
                this.cboSmallSicknessKind.Enabled = true;
            }
            else
            {
                this.cboSys1.Enabled = false;
                this.cboSmallSicknessKind.Enabled = false;
            }
        }          
    }
}
