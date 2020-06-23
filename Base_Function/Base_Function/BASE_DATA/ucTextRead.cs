using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace Base_Function.BASE_DATA
{
    public partial class ucTextRead : UserControl
    {
        bool IsSave = false;　               //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string T_TextRead_Sql;       //文件查询
        DataSet ds;
        private string ID;

        public ucTextRead()
        {
            InitializeComponent();
            T_TextRead_Sql = @"select  id as 编号,currenttid as 当前文书ID, currenttname as 当前文书名称, cistitle as 当前文书是否是标题," +
                             @" ctitlename as 当前标题名称, cisinput as 当前文书是否是新增的输入域, cinputname as 当前输入域的名称 " +
                             //@" sourcetid as 目标文书ID, sourcetname as 目标文书名称, sistitle as 目标文书是否是标题, " +
                             //@" stitlename as 目标标题名称, sisinput as 目标文书是否是新增的输入域, sinputname as 目标输入域的名称" +
                             @" from t_text_read where 1=1 ";
        }

        private void ucTextRead_Load(object sender, EventArgs e)
        {
            ShowValue();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            RefleshFrm();
            //InitAutoCompleteCustomSource(txtBox);
            InitAutoCompleteCustomSource(txtCname);
            InitAutoCompleteCustomSource(txtSName);

            ReflashBookTree(trvText);

            refurbish();
        }

        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Datacodecs[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Datacodecs[] Directionary = new Class_Datacodecs[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Datacodecs();
                        Directionary[i].Id = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].Shortchut_code = tempds.Tables[0].Rows[i]["SHORTCUT_CODE"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                    }
                    return Directionary;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Text[] GetSelectClassDs(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Text[] class_text = new Class_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                    }
                    return class_text;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 树形菜单信息加载（文书除外）
        /// </summary>
        /// <param name="trvBook">树形菜单</param>
        public void ReflashBookTree(TreeView trvBook)
        {
            string Sql_Category = "select * from t_data_code where type=31";
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);

            string SQl = "select * from T_TEXT where ENABLE_FLAG='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);

            if (datacodes != null)
            {


                trvBook.Nodes.Clear();
                for (int j = 0; j < datacodes.Length; j++)
                {
                    TreeNode tempNode = new TreeNode();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j] as object;
                    tempNode.ImageIndex = 1;
                    tempNode.SelectedImageIndex = 1;
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();

                            // Class_Template[] templates = GetTemplates(Directionarys[i]);
                            //setTreeView2(templates, tempNode);
                            //for (int k = 0; k < templates.Length; k++)
                            //{
                            //    TreeNode t = new TreeNode();
                            //    t.Tag = templates[k];
                            //    t.Text = templates[k].Tname;
                            //    t.Name = templates[k].Tid.ToString();
                            //    SetTreeView(Directionarys, t);
                            //}

                            //插入顶级节点
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                }
            }
        }

        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        private static void SetTreeView(Class_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Text cunrrentDir = (Class_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    tn.ImageIndex = 9;
                    tn.SelectedImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }
        public TreeNode nodeallchecks=new TreeNode();

        private void AllCheckNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                if (node.Checked)
                   nodeallchecks.Nodes.Add((TreeNode)node.Clone());
            }

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                AllCheckNodes(node.Nodes[i]);
            }
        }

        private void ShowValue()
        {
            string SQl = T_TextRead_Sql;
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(T_TextRead_Sql, "编号", "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;

                ucGridviewX1.fg.Columns["当前文书是否是标题"].Visible = false;
                ucGridviewX1.fg.Columns["当前文书是否是标题"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前文书是否是新增的输入域"].Visible = false;
                ucGridviewX1.fg.Columns["当前文书是否是新增的输入域"].ReadOnly = true;
                ucGridviewX1.fg.Columns["当前输入域的名称"].Visible = false;
                ucGridviewX1.fg.Columns["当前输入域的名称"].ReadOnly = true;

                //ucGridviewX1.fg.Columns["目标文书是否是标题"].Visible = false;
                //ucGridviewX1.fg.Columns["目标文书是否是标题"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["目标文书是否是新增的输入域"].Visible = false;
                //ucGridviewX1.fg.Columns["目标文书是否是新增的输入域"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["目标输入域的名称"].Visible = false;
                //ucGridviewX1.fg.Columns["目标输入域的名称"].ReadOnly = true;

                ucGridviewX1.fg.ReadOnly = true;
                ucGridviewX1.fg.AutoSize = true;
            }

            //标题列表的现实
            lisBoxDocTittle.Items.Clear();
            string sql="select distinct a.ctitlename from t_text_read a";
            DataSet dsctittle= App.GetDataSet(sql);
            for (int i = 0; i < dsctittle.Tables[0].Rows.Count; i++)
                lisBoxDocTittle.Items.Add(dsctittle.Tables[0].Rows[i]["ctitlename"].ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }

        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    //当前
                    txtCname.Text = ucGridviewX1.fg["当前文书名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtCNameID.Text = ucGridviewX1.fg["当前文书ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtCTitleName.Text = ucGridviewX1.fg["当前标题名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    //if (ucGridviewX1.fg["当前文书是否是标题", ucGridviewX1.fg.CurrentRow.Index].Value.ToString().Trim() == "Y")
                    //{
                    //    rdoCYes.Checked = true;
                    //    txtCTitleName.Text = ucGridviewX1.fg["当前标题名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    //}
                    //if (ucGridviewX1.fg["当前文书是否是新增的输入域", ucGridviewX1.fg.CurrentRow.Index].Value.ToString().Trim() == "Y")
                    //{
                    //    rdoCinputYes.Checked = true;
                    //    txtCInputName.Text = ucGridviewX1.fg["当前输入域的名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    //}                   
                }
            }
            catch
            { 
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.SelectedRows.Count > 0)
            {
                List<string> sqldeles = new List<string>();

                for (int i = 0; i < ucGridviewX1.fg.SelectedRows.Count; i++)
                {
                    string currenttid = ucGridviewX1.fg.SelectedRows[i].Cells["当前文书ID"].Value.ToString();
                    string currenttname = ucGridviewX1.fg.SelectedRows[i].Cells["当前文书名称"].Value.ToString();
                    string ctitlename = ucGridviewX1.fg.SelectedRows[i].Cells["当前标题名称"].Value.ToString();

                    string sql = "delete from t_text_read a where a.currenttid='" + currenttid + "' and ctitlename='" + ctitlename + "'";

                    sqldeles.Add(sql);

                }

                if (App.Ask("你是否要删除当前选中的记录？"))
                {
                    if (App.ExecuteBatch(sqldeles.ToArray()) > 0)
                    {
                        App.Msg("操作已成功！");
                        ShowValue();
                        refurbish();
                    }
                }
            }
            else
            {
                App.MsgWaring("请先选中要删除的记录！");
            }
        }

        private bool check()
        {
            bool falg = false;
            if (txtCname.Text.Trim().Length == 0)
            {
                App.Msg("当前文书名称不能为空！");
                txtCname.Focus();
                return true;
            }
            if (txtCNameID.Text.Trim().Length == 0)
            {
                App.Msg("当前文书ID不能为空！");
                txtCNameID.Focus();
                return true;
            }
            if (rdoCYes.Checked)
            {
                if (txtCTitleName.Text.Trim().Length == 0)
                {
                    App.Msg("当前的标题不能为空！");
                    txtCTitleName.Focus();
                    return true;
                }
            }
            if (rdoCinputYes.Checked)
            {
                if (txtCInputName.Text.Trim().Length == 0)
                {
                    App.Msg("当前的新增的输入域不能为空！");
                    txtCInputName.Focus();
                    return true;
                }
            }
            if (txtSName.Text.Trim().Length == 0)
            {
                App.Msg("目标文书名称不能为空！");
                txtSName.Focus();
                return true;
            }
            if (txtCNameID.Text == txtSNameID.Text)
            {
                App.Msg("2份文书不能相同！");
                txtSName.Focus();
                return true;
            }
            if (txtCname.Text == txtSName.Text)
            {
                App.Msg("2份文书不能相同！");
                txtCname.Focus();
                return true;
            }
            if (txtSNameID.Text.Trim().Length == 0)
            {
                App.Msg("目标文书ID不能为空！");
                txtSNameID.Focus();
                return true;
            }
            if (rdoSYes.Checked)
            {
                if (txtSTitleName.Text.Trim().Length == 0)
                {
                    App.Msg("目标的标题不能为空！");
                    txtSTitleName.Focus();
                    return true;
                }
            }
            if (rdoSInputYes.Checked)
            {
                if (textSInputName.Text.Trim().Length == 0)
                {
                    App.Msg("目标的新增的输入域不能为空！");
                    textSInputName.Focus();
                    return true;
                }
            }
            return falg;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsSave)
            {
               //添加操作 
                nodeallchecks.Nodes.Clear();
                for (int i = 0; i < trvText.Nodes.Count; i++)
                {
                    AllCheckNodes(trvText.Nodes[i]);
                }

                if (nodeallchecks.Nodes.Count == 0)
                {
                    App.MsgWaring("请先选择需要添加的文书！");
                }
                try
                {
                    List<string> strsqls = new List<string>();
                    //删除
                    for (int i = 0; i < nodeallchecks.Nodes.Count; i++)
                    {
                        string currenttid = nodeallchecks.Nodes[i].Name;
                        string sqldele = "delete from t_text_read where currenttid=" + currenttid + " and ctitlename='" + txtCTitleName.Text + "'";
                        strsqls.Add(sqldele);
                    }

                    //插入 
                    for (int i = 0; i < nodeallchecks.Nodes.Count; i++)
                    {
                        string currenttid = nodeallchecks.Nodes[i].Name;
                        string currenttname = nodeallchecks.Nodes[i].Text;

                        string sql = "INSERT INTO t_text_read (currenttid,currenttname,ctitlename,CISTITLE)values('" +
                                     currenttid + "','" + currenttname + "','" + txtCTitleName.Text + "','Y')";
                        strsqls.Add(sql);
                    }
                    if (App.ExecuteBatch(strsqls.ToArray()) > 0)
                    {
                        App.Msg("操作已成功！");
                        ShowValue();
                        refurbish();
                    }
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.ToString());
                }
            }
            else
            {
                //修改操作
                string currenttid = ucGridviewX1.fg.CurrentRow.Cells["当前文书ID"].Value.ToString();
                string currenttname = ucGridviewX1.fg.CurrentRow.Cells["当前文书名称"].Value.ToString();
                string ctitlename = ucGridviewX1.fg.CurrentRow.Cells["当前标题名称"].Value.ToString();

                string sql = "update t_text_read set ctitlename='" + txtCTitleName.Text + "' where currenttid=" + currenttid + " and ctitlename='" + ctitlename + "'";
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("操作已成功！");
                    ShowValue();
                    refurbish();
                }
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
            //txtCname.Enabled = false;
            //txtSName.Enabled = false;
            //panel3.Enabled = false;
            //panel1.Enabled = false;
            IsSave = false;
        }

        /// <summary>
        /// 加载联想库
        /// </summary>
        /// <param name="textBox"></param>
        public void InitAutoCompleteCustomSource(TextBox textBox)
        {
            string[] array = null;
            DataSet ds = App.GetDataSet("select * from T_TEXT where enable_flag='Y' and id not in(select distinct parentid from t_text) and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc");
            if (ds != null)
            {
                array = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    array[i] = ds.Tables[0].Rows[i]["textname"].ToString();
                }
            }
            if (array != null && array.Length > 0)
            {
                AutoCompleteStringCollection ACSC = new AutoCompleteStringCollection();

                for (int i = 0; i < array.Length; i++)
                {
                    ACSC.Add(array[i]);
                }
                textBox.AutoCompleteCustomSource = ACSC;
            }
        }

        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            if (txtSName.Text.Trim().Length > 0)
            {
                string sql = " select *  from T_TEXT where textname='" + txtSName.Text.Trim() + "'";
                txtSNameID.Text = App.ReadSqlVal(sql, 0, "id");
            }
        }
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtCname.Text = "";
                txtCNameID.Text = "";
                txtCTitleName.Text = "";
                txtCInputName.Text = "";
                txtSName.Text = "";
                txtSNameID.Text = "";
                txtSTitleName.Text = "";
                textSInputName.Text = "";
           }
            txtCTitleName.Enabled = true;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
                   
        }

        /// <summary>
        /// 取消,刷新
        /// </summary>
        private void refurbish()
        {
            ID = "";
            //txtBox.Text = "";
            txtCname.Text = "";
            txtCNameID.Text = "";
            txtCTitleName.Text = "";
            txtCInputName.Text = "";
            txtSName.Text = "";
            txtSNameID.Text = "";
            txtSTitleName.Text = "";
            textSInputName.Text = "";
            txtCTitleName.Enabled = false;

            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtBox.Text.Contains("'"))
                //{
                //    App.Msg("该查询条件存在SQL注入的危险！");
                //    txtBox.Focus();
                //    return;
                //}
                //if (txtBox.Text.Trim().Length > 0)
                //{
                //    if (chkCurrent.Checked)
                //    {
                //        T_TextRead_Sql += " and currenttname like '%"+txtBox.Text.Trim()+"%'";
                //    }
                //    else if (chkSource.Checked)
                //    {
                //        T_TextRead_Sql += " and sourcetname like '%" + txtBox.Text.Trim() + "%'";
                //    }
                //}
                //ucGridviewX1.DataBd(T_TextRead_Sql, "编号", "", "");
                //ucGridviewX1.fg.Columns["编号"].Visible = false;
                //ucGridviewX1.fg.Columns["编号"].ReadOnly = true; 
                //ucGridviewX1.fg.Columns["当前文书是否是标题"].Visible = false;
                //ucGridviewX1.fg.Columns["当前文书是否是标题"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["当前文书是否是新增的输入域"].Visible = false;
                //ucGridviewX1.fg.Columns["当前文书是否是新增的输入域"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["当前输入域的名称"].Visible = false;
                //ucGridviewX1.fg.Columns["当前输入域的名称"].ReadOnly = true;

                //ucGridviewX1.fg.Columns["目标文书是否是标题"].Visible = false;
                //ucGridviewX1.fg.Columns["目标文书是否是标题"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["目标文书是否是新增的输入域"].Visible = false;
                //ucGridviewX1.fg.Columns["目标文书是否是新增的输入域"].ReadOnly = true;
                //ucGridviewX1.fg.Columns["目标输入域的名称"].Visible = false;
                //ucGridviewX1.fg.Columns["目标输入域的名称"].ReadOnly = true;
                //ucGridviewX1.fg.AutoSize = true;
                //ucGridviewX1.fg.ReadOnly = true;

            }
            catch
            {
 
            }
        }

        private void chkCurrent_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkCurrent.Checked)
            //{
            //    chkSource.Checked = false;
            //}
            ////else
            ////{
            ////    chkSource.Checked = true;
            ////    txtBox.Text = "";
            ////}
        }

        private void chkSource_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSource.Checked)
            //{
            //    chkCurrent.Checked = false;
            //}
            ////else
            ////{
            ////    chkCurrent.Checked = true;
            ////    txtBox.Text = "";
            ////}
        }

        private void rdoCYes_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoCYes.Checked)
            //{
            //    txtCTitleName.Enabled = true;
            //    txtCInputName.Text = "";
            //    rdoCinputYes.Checked = false;
            //    rdoSYes.Checked = true;
            //}
        }

        private void rdoCinputYes_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoCinputYes.Checked)
            //{
            //    txtCInputName.Enabled = true;
            //    txtCTitleName.Text = "";
            //    rdoCYes.Checked = false;
            //    rdoSInputYes.Checked = true;
            //}
        }

        private void rdoSYes_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoSYes.Checked)
            //{
            //    txtSTitleName.Enabled = true;
            //    textSInputName.Text = "";
            //    rdoSInputYes.Checked = false;
            //    rdoCYes.Checked = true;
            //}
        }

        private void rdoSInputYes_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoSInputYes.Checked)
            //{
            //    textSInputName.Enabled = true;
            //    txtSTitleName.Text = "";
            //    rdoSYes.Checked = false;
            //    rdoCinputYes.Checked = true;

            //}
        }

        private void txtCname_TextChanged(object sender, EventArgs e)
        {
            if (txtCname.Text.Trim().Length > 0)
            {
                string sql = " select *  from T_TEXT where textname='" + txtCname.Text.Trim() + "'";
                txtCNameID.Text = App.ReadSqlVal(sql, 0, "id");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void trvText_AfterCheck(object sender, TreeViewEventArgs e)
        {
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

        private void trvText_Click(object sender, EventArgs e)
        {
           
        }

        private void trvText_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
                
        }

        private void lisBoxDocTittle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = T_TextRead_Sql + " and ctitlename like '%" + lisBoxDocTittle.SelectedItem.ToString() + "%'";
                ucGridviewX1.DataBd(sql, "编号", "", "");
            }
            catch
            { }
        }

        private void btnReflesh_Click(object sender, EventArgs e)
        {
            ShowValue();
            refurbish();
        }
       
    }
}
