using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost.SYSTEMSET;
using DataOperater.Model;

namespace Bifrost
{
    /// <summary>
    /// 角色维护
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
    public partial class frmRoleSet : UserControl
    {
        /// <summary>
        /// 用于存放SQL语句集合
        /// </summary>
        private ArrayList SqlStrs;

        /// <summary>
        /// 用于记录当前选中的权限
        /// </summary>
        private Class_Role CurrentRole;

        /// <summary>
        /// 判断是保存（true） 还是修改(false)
        /// </summary>
        private bool IsSave = false;

        /// <summary>
        /// 判断是否可以进行全选操作
        /// </summary>
        private bool IsChoseAllChildNodes = true;

        /// <summary>
        /// 菜单或功能按钮ID
        /// </summary>
        private int PID = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRoleSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 操作状态,设置相关控件是否可以操作
        /// </summary>
        /// <param name="flag">标记</param>
        private void EditState(bool flag)
        {
            txtRoleName.Enabled = flag;
            cboRoleState.Enabled = flag;
            cboRoleType.Enabled = flag;
            tabControl2.Enabled = flag;
            btnSure.Enabled = flag;
            btnCancel.Enabled = flag;
            if (flag)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                trvRoles.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                trvRoles.Enabled = true;
            }
        }

        /// <summary>
        /// 初始化菜单树的根结点
        /// </summary>
        /// <param name="MenuPermissions">菜单项集合</param>
        /// <param name="trv">菜单树</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions, TreeView trv)
        {
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == 3)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = MenuPermissions[i];
                    tn.Text = MenuPermissions[i].Perm_name;
                    tn.ImageIndex = 1;
                    tn.SelectedImageIndex = 1;
                    trv.Nodes.Add(tn);
                }
            }
        }

        /// <summary>
        /// 初始化菜单树子结点
        /// </summary>
        /// <param name="MenuPermissions">所有菜单项</param>
        /// <param name="tn">菜单树结点</param>
        private void IniMenuTrvNode(Class_Permission[] MenuPermissions, TreeNode tn)
        {
            Class_Permission tempPermission = (Class_Permission)tn.Tag;
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == tempPermission.Perm_code.Length + 2 &&
                    MenuPermissions[i].Perm_code.Substring(0, tempPermission.Perm_code.Length).Contains(tempPermission.Perm_code))
                {
                    TreeNode tempnode = new TreeNode();
                    tempnode.Tag = MenuPermissions[i];
                    tempnode.Text = MenuPermissions[i].Perm_name;
                    tempnode.ImageIndex = 1;
                    tempnode.SelectedImageIndex = 1;
                    IniMenuTrvNode(MenuPermissions, tempnode);
                    tn.Nodes.Add(tempnode);
                }
            }
        }

        /// <summary>
        /// 更新菜单树结点
        /// </summary>
        private void UpdateMenuTreeview()
        {
            trvPerssions.Nodes.Clear();

            Class_Table[] tabSqls = new Class_Table[2];

            tabSqls[0] = new Class_Table();
            tabSqls[0].Sql = "select * from t_permission where PERM_KIND='1' order by num asc";
            tabSqls[0].Tablename = "permission";

            tabSqls[1] = new Class_Table();
            tabSqls[1].Sql = "select id,PERM_CODE,FUNCTION,VERSION,DLLNAME,FUNCTIONIMAGE from t_permission_fuctions";
            tabSqls[1].Tablename = "fuctions";

            DataSet ds = App.GetDataSet(tabSqls);
            Class_Permission[] MenuPermissions = new Class_Permission[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //菜单项
                MenuPermissions[i] = new Class_Permission();
                MenuPermissions[i].Id = ds.Tables["permission"].Rows[i]["id"].ToString();
                MenuPermissions[i].Perm_code = ds.Tables["permission"].Rows[i]["PERM_CODE"].ToString();
                MenuPermissions[i].Perm_name = ds.Tables["permission"].Rows[i]["PERM_NAME"].ToString();
                MenuPermissions[i].Perm_kind = ds.Tables["permission"].Rows[i]["PERM_KIND"].ToString();
                MenuPermissions[i].Num = ds.Tables["permission"].Rows[i]["NUM"].ToString();

                //菜单项详细信息
                MenuPermissions[i].Permission_Info = new Class_Permission_Info();
                DataRow[] rows = ds.Tables["fuctions"].Select("PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                if (rows.Length > 0)
                {
                    MenuPermissions[i].Permission_Info.Id = Convert.ToInt32(rows[0]["id"]);
                    MenuPermissions[i].Permission_Info.Perm_code = rows[0]["PERM_CODE"].ToString();
                    MenuPermissions[i].Permission_Info.Function = rows[0]["FUNCTION"].ToString();
                    MenuPermissions[i].Permission_Info.Version = rows[0]["VERSION"].ToString();
                    MenuPermissions[i].Permission_Info.DllName = rows[0]["DLLNAME"].ToString();
                    MenuPermissions[i].Permission_Info.FunctionImage = (byte[])rows[0]["FUNCTIONIMAGE"];
                }
            }

            //刷新树结点
            IniMenuTreeview(MenuPermissions, trvPerssions);
            for (int i = 0; i < trvPerssions.Nodes.Count; i++)
            {
                IniMenuTrvNode(MenuPermissions, trvPerssions.Nodes[i]);
            }
            trvPerssions.ExpandAll();
        }

        /// <summary>
        /// 更新文书树节点
        /// </summary>
        private void UpdateTextTreeview()
        {
            try
            {
                string Sql_TextType = "select * from t_data_code where type=31 and enable='Y'";
                DataSet ds_type = App.GetDataSet(Sql_TextType);
                string Sql_Text = "select * from T_TEXT where enable_flag='Y'  order by ID asc";
                DataSet ds_text = App.GetDataSet(Sql_Text);

                //文书集合
                Class_Text[] textDire = GetTextDs(ds_text.Tables[0]);
                //文书类型
                Class_Datacodecs[] textType = GetTextTypeDs(ds_type);
                if (textType != null && textDire != null)
                {
                    for (int j = 0; j < textType.Length; j++)
                    {
                        TreeNode tempNode = new TreeNode();
                        tempNode.Name = textType[j].Id;
                        tempNode.Text = textType[j].Name;
                        tempNode.Tag = textType[j] as object;
                        tempNode.ImageIndex = 1;

                        for (int i = 0; i < textDire.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Tag = textDire[i];
                            tn.Text = textDire[i].Textname;
                            tn.Name = textDire[i].Id.ToString();
                            //插入顶级节点
                            if (textDire[i].Parentid == 0 && textType[j].Id.Equals(textDire[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(textDire, tn);   //插入文书的子类文书。                                
                            }
                        }
                        if (tempNode.Nodes.Count > 0)
                        {
                            trvTextRole.Nodes.Add(tempNode);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }


        }
        /// <summary>
        /// 更新按钮树结点
        /// </summary>
        private void UpdateButtonTreeview()
        {
            trvPerssionsButton.Nodes.Clear();
            DataSet ds = App.GetDataSet("select * from t_permission where PERM_KIND='2'");
            Class_Permission[] btnPermissions = new Class_Permission[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                btnPermissions[i] = new Class_Permission();
                btnPermissions[i].Id = ds.Tables[0].Rows[i]["id"].ToString();
                btnPermissions[i].Perm_code = ds.Tables[0].Rows[i]["PERM_CODE"].ToString();
                btnPermissions[i].Perm_name = ds.Tables[0].Rows[i]["PERM_NAME"].ToString();
                btnPermissions[i].Perm_kind = ds.Tables[0].Rows[i]["PERM_KIND"].ToString();
                btnPermissions[i].Num = ds.Tables[0].Rows[i]["NUM"].ToString();
                TreeNode tn = new TreeNode();
                tn.Tag = btnPermissions[i];
                tn.Text = btnPermissions[i].Perm_name;
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 2;
                trvPerssionsButton.Nodes.Add(tn);
            }
        }

        /// <summary>
        /// 清除所有的选择
        /// </summary>   
        /// <param name="nodes">树节点集合</param>
        private void AllCheckFalse(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                //if (nodes[i].Tag.ToString().Contains("Class_Datacodecs"))
                //{
                //    nodes[i].Checked = true;
                //}
                //else
                //{
                    nodes[i].Checked = false;
                //}
                if (nodes[i].Nodes.Count > 0)
                {
                    AllCheckFalse(nodes[i].Nodes);
                }
            }
        }


        /// <summary>
        /// 根据权限选中相应的树节点
        /// </summary>
        /// <param name="Permissions">权限集合</param>
        /// <param name="nodes">节点集合</param>
        private void ALLCheckByCode(Class_Permission[] Permissions, TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < Permissions.Length; j++)
                {
                    Class_Permission temp = (Class_Permission)nodes[i].Tag;
                    if (temp.Perm_code == Permissions[j].Perm_code &&
                        temp.Perm_kind == Permissions[j].Perm_kind)
                    {
                        nodes[i].Checked = true;
                        break;
                    }
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    ALLCheckByCode(Permissions, nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// 根据权限选中相应的树节点
        /// </summary>
        /// <param name="texts">权限集合</param>
        /// <param name="nodes">节点集合</param>
        private void ALLCheckByID(Class_Text[] texts, TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < texts.Length; j++)
                {
                    if (!nodes[i].Tag.ToString().Contains("Class_Datacodecs"))
                    {
                        Class_Text temp = (Class_Text)nodes[i].Tag;
                        if (temp.Id == texts[j].Id)
                        {
                            nodes[i].Checked = true;
                            break;
                        }
                    }
                    else
                    {
                        nodes[i].Checked = true;
                        break;
                    }
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    ALLCheckByID(texts, nodes[i].Nodes);
                }
            }
        }


        /// <summary>
        /// 根据角色初始化所拥有的权限列表
        /// </summary>
        /// <param name="SelectRole">当前角色</param>
        private void IniOwnerPersions(Class_Role SelectRole)
        {
            if (SelectRole != null)
            {
                if (SelectRole.Permissions.Length > 0)
                {

                    for (int i = 0; i < SelectRole.Permissions.Length; i++)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = SelectRole.Permissions[i];
                        tn.Text = SelectRole.Permissions[i].Perm_name;
                        trvPerssions.Nodes.Add(tn);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化角色树结点
        /// </summary>
        private void IniRoles()
        {
            trvRoles.Nodes.Clear();

           Class_Table[] tabSqls = new Class_Table[2];

            tabSqls[0] = new Class_Table();
            tabSqls[0].Sql = "select * from t_role";
            tabSqls[0].Tablename = "role";

            tabSqls[1] = new Class_Table();
            tabSqls[1].Sql = "select * from T_PERMISSION a inner join T_ROLE_PERMISSION b on a.perm_code=b.perm_code";
            tabSqls[1].Tablename = "permission";

            DataSet ds = App.GetDataSet(tabSqls);

            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode tn = new TreeNode();
                    Class_Role tempRole = new Class_Role();
                    tempRole.Role_id = ds.Tables["role"].Rows[i]["ROLE_ID"].ToString();//App.GenId("t_role", "ROLE_ID")
                    tempRole.Role_name = ds.Tables["role"].Rows[i]["ROLE_NAME"].ToString();
                    tempRole.Enable = ds.Tables["role"].Rows[i]["ENABLE_FLAG"].ToString();
                    tempRole.Section_Id = ds.Tables["role"].Rows[i]["SECTION_ID"].ToString();
                    tempRole.Sickarea_Id = ds.Tables["role"].Rows[i]["SICKAREA_ID"].ToString();
                    tempRole.Role_type = ds.Tables["role"].Rows[i]["ROLE_TYPE"].ToString();
                    //绑定角色所对应的权限                    
                    DataRow[] rows = ds.Tables["permission"].Select("ROLE_ID = " + tempRole.Role_id + "");

                    if (rows != null)
                    {
                        tempRole.Permissions = new Class_Permission[rows.Length];
                        for (int j = 0; j < rows.Length; j++)
                        {
                            tempRole.Permissions[j] = new Class_Permission();
                            tempRole.Permissions[j].Id = rows[j]["ID"].ToString();
                            tempRole.Permissions[j].Perm_code = rows[j]["PERM_CODE"].ToString();
                            tempRole.Permissions[j].Perm_name = rows[j]["PERM_NAME"].ToString();
                            tempRole.Permissions[j].Perm_kind = rows[j]["PERM_KIND"].ToString();
                            tempRole.Permissions[j].Num = rows[j]["NUM"].ToString();
                        }
                    }

                    //绑定角色所对应的文书权限
                    DataSet ds_textrole = App.GetDataSet("select * from t_text where id in(select text_id from t_role_text where role_id=" + tempRole.Role_id + ") ");
                    if (ds_textrole != null)
                    {
                        tempRole.Texts = GetTextDs(ds_textrole.Tables[0]);
                    }

                    tn.Tag = tempRole;
                    tn.Text = tempRole.Role_name;
                    if (tempRole.Enable == "Y")
                    {
                        tn.ForeColor = Color.Black;
                    }
                    else
                    {
                        tn.ForeColor = Color.Red;
                    }
                    trvRoles.Nodes.Add(tn);
                }
            }
        }


        /// <summary>
        /// 根据条件保存权限
        /// </summary>
        /// <param name="id">菜单ID</param>
        /// <param name="nodes">菜单集合</param>
        private void SavePerssions(string id, TreeNodeCollection nodes)
        {

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Checked)
                {
                    Class_Permission temp = (Class_Permission)nodes[i].Tag;
                    if (PID >= App.GenId("T_ROLE_PERMISSION", "ID"))
                    {
                        PID = PID + 1;
                    }
                    else
                    {
                        PID = App.GenId("T_ROLE_PERMISSION", "ID");
                    }
                    SqlStrs.Add("insert into T_ROLE_PERMISSION(ID,ROLE_ID,PERM_CODE)values(" + PID.ToString() + "," + id + ",'" + temp.Perm_code + "')");
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    SavePerssions(id, nodes[i].Nodes);
                }
            }

        }

        private void SaveTexts(string id, TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Checked)
                {
                    //if (nodes[i].Tag.ToString().Contains("Class_Datacodecs"))
                    //{
                    //    Class_Datacodecs temp = (Class_Datacodecs)nodes[i].Tag;
                    //    SqlStrs.Add("insert into T_ROLE_TEXT(ROLE_ID,TEXT_ID)values(" + id + ",'" + temp.Id + "')");
                    //}
                    //else
                    //{
                    if (nodes[i].Tag.ToString().Contains("Class_Text"))
                    {
                        Class_Text temp = (Class_Text)nodes[i].Tag;
                        SqlStrs.Add("insert into T_ROLE_TEXT(ROLE_ID,TEXT_ID)values(" + id + ",'" + temp.Id + "')");
                    }
                    //}
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    SaveTexts(id, nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// 判断是否权限名称已经存在
        /// </summary>
        /// <param name="role">帐号</param>
        /// <returns></returns>
        private bool IsExitRole(string role)
        {
            string num = App.ReadSqlVal("select count(ROLE_ID) as num from t_role where ROLE_NAME='" + role + "'", 0, "num");
            if (App.isNumval(num))
            {
                if (Convert.ToInt16(num) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void frmRoleSet_Load(object sender, EventArgs e)
        {
            IniRoles();
            cboRoleState.SelectedIndex = 0;
            EditState(false);
            UpdateMenuTreeview();
            UpdateButtonTreeview();
            //更新文书树
            UpdateTextTreeview();
            cboRoleType.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditState(true);
            IsSave = true;
            txtRoleName.Text = "";
            txtRoleName.Focus();
            cboRoleState.SelectedIndex = 0;
            CurrentRole = null;
            AllCheckFalse(trvPerssions.Nodes);
            AllCheckFalse(trvPerssionsButton.Nodes);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (trvRoles.SelectedNode == null)
            {
                App.MsgErr("请先选择需要修改的角色！");
                return;
            }
            EditState(true);
            IsSave = false;
        }

        string Role_Type = "";    //角色类型
        private void btnSure_Click(object sender, EventArgs e)
        {
            SqlStrs = new ArrayList();
            PID = 0;

            if (cboRoleType.Text == "医生")
            {
                Role_Type = "D";
            }
            else if (cboRoleType.Text == "护士")
            {
                Role_Type = "N";
            }
            else if (cboRoleType.Text == "护理部")
            {
                Role_Type = "H";
            }
            else if (cboRoleType.Text == "医务处")
            {
                Role_Type = "Y";
            }
            else if (cboRoleType.Text == "病案室")
            {
                Role_Type = "B";
            }
            else if (cboRoleType.Text == "管理员")
            {
                Role_Type = "M";
            }
            else if (cboRoleType.Text == "院感科")
            {
                Role_Type = "U";
            }
            else if (cboRoleType.Text == "质控科")
            {
                Role_Type = "Z";
            }
            else if (cboRoleType.Text == "其他")
            {
                Role_Type = "O";
            }
            else
            {
                Role_Type = "";
            }
            if (txtRoleName.Text.Trim() == "")
            {
                App.MsgErr("角色名称不能为空！");
                return;
            }
            string IsUserful = "Y";
            int ID = 0;
            if (cboRoleState.SelectedIndex == 0)
            {
                IsUserful = "Y";
            }
            else
            {
                IsUserful = "N";
            }
            if (IsSave)
            {
                //添加操作
                if (IsExitRole(txtRoleName.Text))
                {
                    App.MsgErr("权限名称已经存在！");
                    return;
                }
                ID = App.GenId("T_ROLE", "ROLE_ID");
                //保存角色                            
                string Sql = "";
                Sql = "insert into T_ROLE(ROLE_ID,ROLE_NAME,ENABLE_FLAG,ROLE_TYPE)values(" + ID.ToString() + ",'" + txtRoleName.Text + "','" + IsUserful + "','" + Role_Type + "')";
                SqlStrs.Add(Sql);

            }
            else
            {
                //修改操作
                if (trvRoles.SelectedNode != null)
                {
                    Class_Role TempRole = (Class_Role)trvRoles.SelectedNode.Tag;
                    ID = Convert.ToInt32(TempRole.Role_id);
                    //更新角色
                    string Sql = "";
                    Sql = "update T_ROLE set ROLE_NAME='" + txtRoleName.Text + "',ENABLE_FLAG='" + IsUserful + "',ROLE_TYPE='" + Role_Type + "' where ROLE_ID=" + TempRole.Role_id + "";
                    SqlStrs.Add(Sql);
                }
            }

            /*
             * 保存与角色相关的权限
             */
            SqlStrs.Add("delete from T_ROLE_PERMISSION where ROLE_ID=" + ID + "");
            SqlStrs.Add("delete from T_ROLE_TEXT where ROLE_ID=" + ID + "");
            //保存菜单权限
            SavePerssions(ID.ToString(), trvPerssions.Nodes);

            //保存按钮权限
            SavePerssions(ID.ToString(), trvPerssionsButton.Nodes);

            //保存文书权限
            SaveTexts(ID.ToString(), trvTextRole.Nodes);

            string[] ESQlS = new string[SqlStrs.Count];
            for (int i = 0; i < ESQlS.Length; i++)
            {
                ESQlS[i] = SqlStrs[i].ToString();
            }
            if (App.ExecuteBatch(ESQlS) > 0)
            {
                App.Msg("操作已成功");
                btnCancel_Click(sender, e);
            }

            //更新角色树
            IniRoles();

            //返回添加状态
            if (IsSave)
            {
                btnAdd_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EditState(false);
        }

        private void trvRoles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (trvRoles.SelectedNode != null)
            {
                IsChoseAllChildNodes = false;
                CurrentRole = (Class_Role)trvRoles.SelectedNode.Tag;
                txtRoleName.Text = CurrentRole.Role_name;

                if (CurrentRole.Enable == "Y")
                {
                    cboRoleState.SelectedIndex = 0;
                }
                else
                {
                    cboRoleState.SelectedIndex = 1;
                }


                /*
                 * 加载界面控件的值
                 */
                if (CurrentRole.Role_type == "D")
                {
                    cboRoleType.Text = "医生";
                }
                else if (CurrentRole.Role_type == "N")
                {
                    cboRoleType.Text = "护士";
                }
                else if (CurrentRole.Role_type == "H")
                {
                    cboRoleType.Text = "护理部";
                }
                else if (CurrentRole.Role_type == "Y")
                {
                    cboRoleType.Text = "医务处";
                }
                else if (CurrentRole.Role_type == "B")
                {
                    cboRoleType.Text = "病案室";
                }
                else if (CurrentRole.Role_type == "M")
                {
                    cboRoleType.Text = "管理员";
                }
                else if (CurrentRole.Role_type == "O")
                {
                    cboRoleType.Text = "其他";
                }
                else
                {

                }

                /*
                 * 加载所有的菜单权限
                 */
                AllCheckFalse(trvPerssions.Nodes);
                ALLCheckByCode(CurrentRole.Permissions, trvPerssions.Nodes);

                /*
                 * 加载所有的按钮权限
                 */
                AllCheckFalse(trvPerssionsButton.Nodes);
                ALLCheckByCode(CurrentRole.Permissions, trvPerssionsButton.Nodes);

                /*
                 * 加载文书权限
                 */
                AllCheckFalse(trvTextRole.Nodes);
                if (CurrentRole.Texts != null)
                {
                    ALLCheckByID(CurrentRole.Texts, trvTextRole.Nodes);
                }

                IsChoseAllChildNodes = true;
            }
        }

        private void trvRoles_MouseDown(object sender, MouseEventArgs e)
        {
            trvRoles.SelectedNode = trvRoles.GetNodeAt(e.X, e.Y);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (trvRoles.SelectedNode != null)
            {
                Class_Role temp = (Class_Role)trvRoles.SelectedNode.Tag;
                if (temp.Enable == "Y")
                {
                    toolMenuUseful.Enabled = false;
                    toolMenuUnUseful.Enabled = true;
                }
                else
                {
                    toolMenuUseful.Enabled = true;
                    toolMenuUnUseful.Enabled = false;
                }
            }
        }

        private void toolMenuUseful_Click(object sender, EventArgs e)
        {
            Class_Role temp = (Class_Role)trvRoles.SelectedNode.Tag;
            App.ExecuteSQL("update t_role set ENABLE_FLAG='Y' where id=" + temp.Role_id + "");
            temp.Enable = "Y";
            trvRoles.SelectedNode.Tag = temp;
            trvRoles.SelectedNode.ForeColor = Color.Black;
        }

        private void toolMenuUnUseful_Click(object sender, EventArgs e)
        {
            if (trvRoles.SelectedNode != null)
            {
                if (App.Ask("该权限可能已经在使用确定要停用吗？"))
                {
                    Class_Role temp = (Class_Role)trvRoles.SelectedNode.Tag;
                    App.ExecuteSQL("update t_role set ENABLE_FLAG='N' where id=" + temp.Role_id + "");
                    temp.Enable = "N";
                    trvRoles.SelectedNode.Tag = temp;
                    trvRoles.SelectedNode.ForeColor = Color.Red;
                }
            }
        }



        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuDelete_Click(object sender, EventArgs e)
        {
            if (trvRoles.SelectedNode != null)
            {
                if (App.Ask("该权限可能已经在使用确定要删除吗？"))
                {
                    if (trvRoles.SelectedNode.Nodes.Count == 0)
                    {
                        ArrayList Slqs = new ArrayList();
                        Class_Role temp = (Class_Role)trvRoles.SelectedNode.Tag;

                        //删除权限
                        Slqs.Add("delete from t_role where role_id=" + temp.Role_id + "");

                        //删除权限所对应的菜单功能项
                        Slqs.Add("delete from t_role_permission where ROLE_ID=" + temp.Role_id + "");

                        //删除帐号权限所对应的使用范围
                        Slqs.Add("delete from t_acc_role_range where acc_role_id in (select id from T_ACC_ROLE where role_id=" + temp.Role_id + ")");

                        //删除帐号所对应的该权限项
                        Slqs.Add("delete from t_acc_role where ROLE_ID=" + temp.Role_id + "");

                        string[] Sqls = new string[Slqs.Count];
                        for (int i = 0; i < Slqs.Count; i++)
                        {
                            Sqls[i] = Slqs[i].ToString();
                        }

                        if (App.ExecuteBatch(Sqls) > 0)
                        {
                            App.Msg("删除已经成功");
                            temp.Enable = "N";
                            trvRoles.SelectedNode.Tag = temp;
                            trvRoles.SelectedNode.ForeColor = Color.Red;
                            trvRoles.Nodes.Remove(trvRoles.SelectedNode);
                        }
                        else
                        {
                            App.MsgErr("删除操作失败");
                        }
                    }
                    else
                    {
                        App.MsgErr("请先删除该菜单的子项!");
                        return;
                    }
                }
            }
        }

        //根据职务生成角色
        private void btnGenRole_Click(object sender, EventArgs e)
        {

            //获取职务信息
            DataSet ds_Zw = App.GetDataSet("select * from t_data_code t where type=2");

            //当前所有的权限信息
            DataSet ds_Roles = App.GetDataSet("select * from T_ROLE");

            bool flag = false;
            for (int i = 0; i < ds_Zw.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds_Roles.Tables[0].Rows.Count; i++)
                {
                    if (ds_Zw.Tables[0].Rows[i]["id"].ToString() == ds_Roles.Tables[0].Rows[j].ToString())
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                string[] SqlInserts = new string[ds_Zw.Tables[0].Rows.Count];
                //插入相关职务角色
                for (int i = 0; i < ds_Zw.Tables[0].Rows.Count; i++)
                {
                    SqlInserts[i] = "insert into t_role(role_id,role_name,enable_flag,role_type)values(" + ds_Zw.Tables[0].Rows[i]["ID"].ToString() + ",'" + ds_Zw.Tables[0].Rows[i]["name"].ToString() + "','Y','D')";
                }

                if (App.ExecuteBatch(SqlInserts) > 0)
                {
                    App.Msg("生成成功！");
                }
                else
                {
                    App.MsgErr("生成失败！");
                }
            }
            else
            {
                App.MsgErr("已经存在了相同的记录，请先将以前的记录删除！");
            }
        }

        /// <summary>
        /// 角色级别设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLevelSet_Click(object sender, EventArgs e)
        {
            frmJobLeverSet fc = new frmJobLeverSet();
            fc.ShowDialog();
        }


        #region 文书权限分配
        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        public static Class_Text[] GetTextDs(DataTable tempdt)
        {
            if (tempdt != null)
            {
                if (tempdt.Rows.Count > 0)
                {
                    Class_Text[] class_text = new Class_Text[tempdt.Rows.Count];
                    for (int i = 0; i < tempdt.Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text();
                        class_text[i].Id = Convert.ToInt32(tempdt.Rows[i]["ID"].ToString());
                        if (tempdt.Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempdt.Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Sid = tempdt.Rows[i]["sid"].ToString();
                        class_text[i].Textcode = tempdt.Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempdt.Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempdt.Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempdt.Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempdt.Rows[i]["issimpleinstance"].ToString();
                        class_text[i].Ishighersign = tempdt.Rows[i]["ishighersign"].ToString();
                        class_text[i].Right_range = tempdt.Rows[i]["right_range"].ToString();
                        class_text[i].Ishavetime = tempdt.Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempdt.Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempdt.Rows[i]["OTHER_TEXTNAME"].ToString();

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
        /// 实例化文书类型
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Datacodecs[] GetTextTypeDs(DataSet tempds)
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
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        public static void SetTreeView(Class_Text[] Directionarys, TreeNode current)
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
                    if (Directionarys[i].Issimpleinstance == "0")   //是单例文书
                    {
                        tn.ImageIndex = 0;
                    }
                    else
                    {
                        tn.ImageIndex = 1;
                    }
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }
        #endregion

        #region 节点勾选
        private void trvTextRole_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (IsChoseAllChildNodes)
            {
                trvTextRole.SelectedNode = e.Node;
            }
        }

        private void trvTextRole_Click(object sender, EventArgs e)
        {
            IsChoseAllChildNodes = false;
            if (trvTextRole.SelectedNode != null)
            {
                if (trvTextRole.SelectedNode.Checked)
                {
                    SetParentChecked(trvTextRole.SelectedNode.Parent);
                    SetChildChecked(trvTextRole.SelectedNode);
                }
                else
                {
                    CancelChildNodeChecked(trvTextRole.SelectedNode);
                    CancelParentNodeChecked(trvTextRole.SelectedNode.Parent);
                }
            }
            IsChoseAllChildNodes = true;
        }

        private void trvPerssions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //if (IsChoseAllChildNodes)
            //{
            //    if (e.Node.Checked)
            //    {
            //        for (int i = 0; i < e.Node.Nodes.Count; i++)
            //        {
            //            e.Node.Nodes[i].Checked = true;
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < e.Node.Nodes.Count; i++)
            //        {
            //            e.Node.Nodes[i].Checked = false;
            //        }
            //    }
            //}
            if (IsChoseAllChildNodes)
            {
                trvPerssions.SelectedNode = e.Node;
            }
        }

        private void trvPerssions_Click(object sender, EventArgs e)
        {
            IsChoseAllChildNodes = false;
            if (trvPerssions.SelectedNode != null)
            {
                if (trvPerssions.SelectedNode.Checked)
                {
                    SetParentChecked(trvPerssions.SelectedNode.Parent);
                    SetChildChecked(trvPerssions.SelectedNode);
                }
                else
                {
                    CancelChildNodeChecked(trvPerssions.SelectedNode);
                    CancelParentNodeChecked(trvPerssions.SelectedNode.Parent);
                }
            }
            IsChoseAllChildNodes = true;
        }

        /// <summary>
        /// 设置父节点选中
        /// </summary>
        /// <param name="parentNode"></param>
        private void SetParentChecked(TreeNode parentNode)
        {
            if (parentNode != null)
            {
                for (int i = 0; i < parentNode.Nodes.Count; i++)
                {
                    if (parentNode.Nodes[i].Checked)
                    {
                        parentNode.Checked = true;
                    }
                }
                SetParentChecked(parentNode.Parent);
            }
        }

        /// <summary>
        /// 设置子节点选中
        /// </summary>
        /// <param name="currNode"></param>
        private void SetChildChecked(TreeNode currNode)
        {
            if (currNode != null)
            {
                for (int i = 0; i < currNode.Nodes.Count; i++)
                {
                    currNode.Nodes[i].Checked = true;
                    ;
                    SetChildChecked(currNode.Nodes[i]);
                }
            }
        }
        /// <summary>
        /// 设置子节点取消选中
        /// </summary>
        /// <param name="currNode"></param>
        private void CancelChildNodeChecked(TreeNode currNode)
        {
            if (currNode != null)
            {
                for (int i = 0; i < currNode.Nodes.Count; i++)
                {
                    currNode.Nodes[i].Checked = false;
                    CancelChildNodeChecked(currNode.Nodes[i]);
                }
            }
        }

        /// <summary>
        /// 设置父节点取消选中
        /// </summary>
        /// <param name="parentNode"></param>
        private void CancelParentNodeChecked(TreeNode parentNode)
        {
            if (parentNode != null)
            {
                bool flag = false;
                for (int i = 0; i < parentNode.Nodes.Count; i++)
                {
                    if (parentNode.Nodes[i].Checked)
                    {
                        flag = true;
                    }
                }
                parentNode.Checked = flag;
                CancelParentNodeChecked(parentNode.Parent);
            }
        }
        #endregion
    }
}