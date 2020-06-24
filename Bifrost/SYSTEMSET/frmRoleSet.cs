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
    /// ��ɫά��
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-9-10
    /// </summary>
    public partial class frmRoleSet : UserControl
    {
        /// <summary>
        /// ���ڴ��SQL��伯��
        /// </summary>
        private ArrayList SqlStrs;

        /// <summary>
        /// ���ڼ�¼��ǰѡ�е�Ȩ��
        /// </summary>
        private Class_Role CurrentRole;

        /// <summary>
        /// �ж��Ǳ��棨true�� �����޸�(false)
        /// </summary>
        private bool IsSave = false;

        /// <summary>
        /// �ж��Ƿ���Խ���ȫѡ����
        /// </summary>
        private bool IsChoseAllChildNodes = true;

        /// <summary>
        /// �˵����ܰ�ťID
        /// </summary>
        private int PID = 0;

        /// <summary>
        /// ���캯��
        /// </summary>
        public frmRoleSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����״̬,������ؿؼ��Ƿ���Բ���
        /// </summary>
        /// <param name="flag">���</param>
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
        /// ��ʼ���˵����ĸ����
        /// </summary>
        /// <param name="MenuPermissions">�˵����</param>
        /// <param name="trv">�˵���</param>
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
        /// ��ʼ���˵����ӽ��
        /// </summary>
        /// <param name="MenuPermissions">���в˵���</param>
        /// <param name="tn">�˵������</param>
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
        /// ���²˵������
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
                //�˵���
                MenuPermissions[i] = new Class_Permission();
                MenuPermissions[i].Id = ds.Tables["permission"].Rows[i]["id"].ToString();
                MenuPermissions[i].Perm_code = ds.Tables["permission"].Rows[i]["PERM_CODE"].ToString();
                MenuPermissions[i].Perm_name = ds.Tables["permission"].Rows[i]["PERM_NAME"].ToString();
                MenuPermissions[i].Perm_kind = ds.Tables["permission"].Rows[i]["PERM_KIND"].ToString();
                MenuPermissions[i].Num = ds.Tables["permission"].Rows[i]["NUM"].ToString();

                //�˵�����ϸ��Ϣ
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

            //ˢ�������
            IniMenuTreeview(MenuPermissions, trvPerssions);
            for (int i = 0; i < trvPerssions.Nodes.Count; i++)
            {
                IniMenuTrvNode(MenuPermissions, trvPerssions.Nodes[i]);
            }
            trvPerssions.ExpandAll();
        }

        /// <summary>
        /// �����������ڵ�
        /// </summary>
        private void UpdateTextTreeview()
        {
            try
            {
                string Sql_TextType = "select * from t_data_code where type=31 and enable='Y'";
                DataSet ds_type = App.GetDataSet(Sql_TextType);
                string Sql_Text = "select * from T_TEXT where enable_flag='Y'  order by ID asc";
                DataSet ds_text = App.GetDataSet(Sql_Text);

                //���鼯��
                Class_Text[] textDire = GetTextDs(ds_text.Tables[0]);
                //��������
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
                            //���붥���ڵ�
                            if (textDire[i].Parentid == 0 && textType[j].Id.Equals(textDire[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(textDire, tn);   //����������������顣                                
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
        /// ���°�ť�����
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
        /// ������е�ѡ��
        /// </summary>   
        /// <param name="nodes">���ڵ㼯��</param>
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
        /// ����Ȩ��ѡ����Ӧ�����ڵ�
        /// </summary>
        /// <param name="Permissions">Ȩ�޼���</param>
        /// <param name="nodes">�ڵ㼯��</param>
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
        /// ����Ȩ��ѡ����Ӧ�����ڵ�
        /// </summary>
        /// <param name="texts">Ȩ�޼���</param>
        /// <param name="nodes">�ڵ㼯��</param>
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
        /// ���ݽ�ɫ��ʼ����ӵ�е�Ȩ���б�
        /// </summary>
        /// <param name="SelectRole">��ǰ��ɫ</param>
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
        /// ��ʼ����ɫ�����
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
                    //�󶨽�ɫ����Ӧ��Ȩ��                    
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

                    //�󶨽�ɫ����Ӧ������Ȩ��
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
        /// ������������Ȩ��
        /// </summary>
        /// <param name="id">�˵�ID</param>
        /// <param name="nodes">�˵�����</param>
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
        /// �ж��Ƿ�Ȩ�������Ѿ�����
        /// </summary>
        /// <param name="role">�ʺ�</param>
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
            //����������
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
                App.MsgErr("����ѡ����Ҫ�޸ĵĽ�ɫ��");
                return;
            }
            EditState(true);
            IsSave = false;
        }

        string Role_Type = "";    //��ɫ����
        private void btnSure_Click(object sender, EventArgs e)
        {
            SqlStrs = new ArrayList();
            PID = 0;

            if (cboRoleType.Text == "ҽ��")
            {
                Role_Type = "D";
            }
            else if (cboRoleType.Text == "��ʿ")
            {
                Role_Type = "N";
            }
            else if (cboRoleType.Text == "����")
            {
                Role_Type = "H";
            }
            else if (cboRoleType.Text == "ҽ��")
            {
                Role_Type = "Y";
            }
            else if (cboRoleType.Text == "������")
            {
                Role_Type = "B";
            }
            else if (cboRoleType.Text == "����Ա")
            {
                Role_Type = "M";
            }
            else if (cboRoleType.Text == "Ժ�п�")
            {
                Role_Type = "U";
            }
            else if (cboRoleType.Text == "�ʿؿ�")
            {
                Role_Type = "Z";
            }
            else if (cboRoleType.Text == "����")
            {
                Role_Type = "O";
            }
            else
            {
                Role_Type = "";
            }
            if (txtRoleName.Text.Trim() == "")
            {
                App.MsgErr("��ɫ���Ʋ���Ϊ�գ�");
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
                //��Ӳ���
                if (IsExitRole(txtRoleName.Text))
                {
                    App.MsgErr("Ȩ�������Ѿ����ڣ�");
                    return;
                }
                ID = App.GenId("T_ROLE", "ROLE_ID");
                //�����ɫ                            
                string Sql = "";
                Sql = "insert into T_ROLE(ROLE_ID,ROLE_NAME,ENABLE_FLAG,ROLE_TYPE)values(" + ID.ToString() + ",'" + txtRoleName.Text + "','" + IsUserful + "','" + Role_Type + "')";
                SqlStrs.Add(Sql);

            }
            else
            {
                //�޸Ĳ���
                if (trvRoles.SelectedNode != null)
                {
                    Class_Role TempRole = (Class_Role)trvRoles.SelectedNode.Tag;
                    ID = Convert.ToInt32(TempRole.Role_id);
                    //���½�ɫ
                    string Sql = "";
                    Sql = "update T_ROLE set ROLE_NAME='" + txtRoleName.Text + "',ENABLE_FLAG='" + IsUserful + "',ROLE_TYPE='" + Role_Type + "' where ROLE_ID=" + TempRole.Role_id + "";
                    SqlStrs.Add(Sql);
                }
            }

            /*
             * �������ɫ��ص�Ȩ��
             */
            SqlStrs.Add("delete from T_ROLE_PERMISSION where ROLE_ID=" + ID + "");
            SqlStrs.Add("delete from T_ROLE_TEXT where ROLE_ID=" + ID + "");
            //����˵�Ȩ��
            SavePerssions(ID.ToString(), trvPerssions.Nodes);

            //���水ťȨ��
            SavePerssions(ID.ToString(), trvPerssionsButton.Nodes);

            //��������Ȩ��
            SaveTexts(ID.ToString(), trvTextRole.Nodes);

            string[] ESQlS = new string[SqlStrs.Count];
            for (int i = 0; i < ESQlS.Length; i++)
            {
                ESQlS[i] = SqlStrs[i].ToString();
            }
            if (App.ExecuteBatch(ESQlS) > 0)
            {
                App.Msg("�����ѳɹ�");
                btnCancel_Click(sender, e);
            }

            //���½�ɫ��
            IniRoles();

            //�������״̬
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
                 * ���ؽ���ؼ���ֵ
                 */
                if (CurrentRole.Role_type == "D")
                {
                    cboRoleType.Text = "ҽ��";
                }
                else if (CurrentRole.Role_type == "N")
                {
                    cboRoleType.Text = "��ʿ";
                }
                else if (CurrentRole.Role_type == "H")
                {
                    cboRoleType.Text = "����";
                }
                else if (CurrentRole.Role_type == "Y")
                {
                    cboRoleType.Text = "ҽ��";
                }
                else if (CurrentRole.Role_type == "B")
                {
                    cboRoleType.Text = "������";
                }
                else if (CurrentRole.Role_type == "M")
                {
                    cboRoleType.Text = "����Ա";
                }
                else if (CurrentRole.Role_type == "O")
                {
                    cboRoleType.Text = "����";
                }
                else
                {

                }

                /*
                 * �������еĲ˵�Ȩ��
                 */
                AllCheckFalse(trvPerssions.Nodes);
                ALLCheckByCode(CurrentRole.Permissions, trvPerssions.Nodes);

                /*
                 * �������еİ�ťȨ��
                 */
                AllCheckFalse(trvPerssionsButton.Nodes);
                ALLCheckByCode(CurrentRole.Permissions, trvPerssionsButton.Nodes);

                /*
                 * ��������Ȩ��
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
                if (App.Ask("��Ȩ�޿����Ѿ���ʹ��ȷ��Ҫͣ����"))
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
        /// �˵�ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuDelete_Click(object sender, EventArgs e)
        {
            if (trvRoles.SelectedNode != null)
            {
                if (App.Ask("��Ȩ�޿����Ѿ���ʹ��ȷ��Ҫɾ����"))
                {
                    if (trvRoles.SelectedNode.Nodes.Count == 0)
                    {
                        ArrayList Slqs = new ArrayList();
                        Class_Role temp = (Class_Role)trvRoles.SelectedNode.Tag;

                        //ɾ��Ȩ��
                        Slqs.Add("delete from t_role where role_id=" + temp.Role_id + "");

                        //ɾ��Ȩ������Ӧ�Ĳ˵�������
                        Slqs.Add("delete from t_role_permission where ROLE_ID=" + temp.Role_id + "");

                        //ɾ���ʺ�Ȩ������Ӧ��ʹ�÷�Χ
                        Slqs.Add("delete from t_acc_role_range where acc_role_id in (select id from T_ACC_ROLE where role_id=" + temp.Role_id + ")");

                        //ɾ���ʺ�����Ӧ�ĸ�Ȩ����
                        Slqs.Add("delete from t_acc_role where ROLE_ID=" + temp.Role_id + "");

                        string[] Sqls = new string[Slqs.Count];
                        for (int i = 0; i < Slqs.Count; i++)
                        {
                            Sqls[i] = Slqs[i].ToString();
                        }

                        if (App.ExecuteBatch(Sqls) > 0)
                        {
                            App.Msg("ɾ���Ѿ��ɹ�");
                            temp.Enable = "N";
                            trvRoles.SelectedNode.Tag = temp;
                            trvRoles.SelectedNode.ForeColor = Color.Red;
                            trvRoles.Nodes.Remove(trvRoles.SelectedNode);
                        }
                        else
                        {
                            App.MsgErr("ɾ������ʧ��");
                        }
                    }
                    else
                    {
                        App.MsgErr("����ɾ���ò˵�������!");
                        return;
                    }
                }
            }
        }

        //����ְ�����ɽ�ɫ
        private void btnGenRole_Click(object sender, EventArgs e)
        {

            //��ȡְ����Ϣ
            DataSet ds_Zw = App.GetDataSet("select * from t_data_code t where type=2");

            //��ǰ���е�Ȩ����Ϣ
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
                //�������ְ���ɫ
                for (int i = 0; i < ds_Zw.Tables[0].Rows.Count; i++)
                {
                    SqlInserts[i] = "insert into t_role(role_id,role_name,enable_flag,role_type)values(" + ds_Zw.Tables[0].Rows[i]["ID"].ToString() + ",'" + ds_Zw.Tables[0].Rows[i]["name"].ToString() + "','Y','D')";
                }

                if (App.ExecuteBatch(SqlInserts) > 0)
                {
                    App.Msg("���ɳɹ���");
                }
                else
                {
                    App.MsgErr("����ʧ�ܣ�");
                }
            }
            else
            {
                App.MsgErr("�Ѿ���������ͬ�ļ�¼�����Ƚ���ǰ�ļ�¼ɾ����");
            }
        }

        /// <summary>
        /// ��ɫ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLevelSet_Click(object sender, EventArgs e)
        {
            frmJobLeverSet fc = new frmJobLeverSet();
            fc.ShowDialog();
        }


        #region ����Ȩ�޷���
        /// <summary>
        /// ʵ��Class_Text����ѯ���
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
        /// ʵ������������
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
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
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
                    if (Directionarys[i].Issimpleinstance == "0")   //�ǵ�������
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

        #region �ڵ㹴ѡ
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
        /// ���ø��ڵ�ѡ��
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
        /// �����ӽڵ�ѡ��
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
        /// �����ӽڵ�ȡ��ѡ��
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
        /// ���ø��ڵ�ȡ��ѡ��
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