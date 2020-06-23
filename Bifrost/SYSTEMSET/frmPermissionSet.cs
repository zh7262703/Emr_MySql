using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;

namespace Bifrost
{  
    /// <summary>
    /// 菜单详细信息设置
    /// 创建者：张华
    /// 创建时间：2010-10-15
    /// </summary>
    public partial class frmPermissionSet : UserControl
    {
        /// <summary>
        /// 用于寄存当前正在操作的菜单、按钮或页签对象
        /// </summary>
        public static Class_Permission CurrentPerssmion;


        /// <summary>
        /// 获取所有的菜单信息以及菜单的功能。
        /// </summary>
        DataSet ds;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPermissionSet()
        {
            
            InitializeComponent();
            getMenuData();           
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        private void getMenuData()
        {
            Bifrost.WebReference.Class_Table[] tabsqls = new Bifrost.WebReference.Class_Table[2];
            tabsqls[0] = new Bifrost.WebReference.Class_Table();
            tabsqls[0].Sql = "select * from t_permission where PERM_KIND='1' order by num asc";
            tabsqls[0].Tablename = "permission";

            tabsqls[1] = new Bifrost.WebReference.Class_Table();
            tabsqls[1].Sql = "select id,PERM_CODE,FUNCTION,VERSION,DLLNAME,FUNCTIONIMAGE from t_permission_fuctions";
            tabsqls[1].Tablename = "fuctions";
            ds = App.GetDataSet(tabsqls);
        }

        /// <summary>
        /// 获取页签数据
        /// </summary>
        private void getTabData()
        {
            Bifrost.WebReference.Class_Table[] tabsqls = new Bifrost.WebReference.Class_Table[2];
            tabsqls[0] = new Bifrost.WebReference.Class_Table();
            tabsqls[0].Sql = "select * from t_permission where PERM_KIND='3' order by num asc";
            tabsqls[0].Tablename = "permission";

            tabsqls[1] = new Bifrost.WebReference.Class_Table();
            tabsqls[1].Sql = "select id,PERM_CODE,FUNCTION,VERSION,DLLNAME,FUNCTIONIMAGE from t_permission_fuctions";
            tabsqls[1].Tablename = "fuctions";
            ds = App.GetDataSet(tabsqls);
        }

        /// <summary>
        /// 返回菜单集合中最大的代码
        /// </summary>
        /// <param name="CodeData"></param>
        /// <returns></returns>
        private string GetMaxMenuCode(DataSet CodeData)
        {
            string maxvalue = "100";
            if (CodeData != null)
            {
                //当该节点是父节点的时候
                for (int i = 0; i < CodeData.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        maxvalue = CodeData.Tables[0].Rows[i]["PERM_CODE"].ToString();
                    }
                    else
                    {
                        int temp1 = Convert.ToInt32(maxvalue);
                        int temp2 = Convert.ToInt32(CodeData.Tables[0].Rows[i]["PERM_CODE"]);
                        if (temp2 > temp1)
                        {
                            maxvalue = CodeData.Tables[0].Rows[i]["PERM_CODE"].ToString();
                        }
                    }
                }
            }
            return maxvalue;
        }

        /// <summary>
        /// 返回菜单集合中最大的代码
        /// </summary>
        /// <param name="CodeData"></param>
        /// <returns></returns>
        private string GetMaxTabCode(DataSet CodeData)
        {
            string maxvalue = "100";
            if (CodeData != null)
            {
                //当该节点是父节点的时候
                for (int i = 0; i < CodeData.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        maxvalue = CodeData.Tables[0].Rows[i]["PERM_CODE"].ToString();
                    }
                    else
                    {
                        int temp1 = Convert.ToInt32(maxvalue);
                        int temp2 = Convert.ToInt32(CodeData.Tables[0].Rows[i]["PERM_CODE"].ToString().Replace("T",""));
                        if (temp2 > temp1)
                        {
                            maxvalue = CodeData.Tables[0].Rows[i]["PERM_CODE"].ToString();
                        }
                    }
                }
            }
            return maxvalue;
        }

        /// <summary>
        /// 根据条件生成菜单code
        /// </summary>
        /// <param name="fathercode">父级菜单的code</param>
        /// <returns></returns>
        private string GenalMenuCode(string fathercode)
        {
            string GenCode="";
            if (fathercode.Trim() == "")   
            {
                //当该节点是父节点的时候
                DataSet ds = App.GetDataSet("select PERM_CODE from T_PERMISSION where length(perm_code)=3 and perm_kind='1'");
                GenCode=GetMaxMenuCode(ds);                
                GenCode=Convert.ToString(Convert.ToInt32(GenCode) + 1);                                
            }
            else
            {
                //当该节点是子级
                DataSet ds = App.GetDataSet("select PERM_CODE from T_PERMISSION where length(perm_code)=" + Convert.ToString(fathercode.Length + 2) + " and perm_kind='1' and perm_code like '"+fathercode+"%'");
                GenCode = GetMaxMenuCode(ds);
                if (GenCode != "100")
                {
                     GenCode = Convert.ToString(Convert.ToInt32(GenCode) + 1);
                }
                else
                {
                    GenCode = fathercode + "01";
                }
            }
            return GenCode;
        }

        /// <summary>
        /// 根据条件生成页签code
        /// </summary>
        /// <param name="fathercode">父级菜单的code</param>
        /// <returns></returns>
        private string GenalTabCode(string fathercode)
        {
            string GenCode = "";
            if (fathercode.Trim() == "")
            {
                //当该节点是父节点的时候
                DataSet ds = App.GetDataSet("select PERM_CODE from T_PERMISSION where length(perm_code)=3 and perm_kind='3'");
                GenCode = GetMaxTabCode(ds);
                GenCode ="T"+Convert.ToString(Convert.ToInt32(GenCode) + 1);
            }
            else
            {
                //当该节点是子级
                DataSet ds = App.GetDataSet("select PERM_CODE from T_PERMISSION where length(perm_code)=" + Convert.ToString(fathercode.Length + 2) + " and perm_kind='3' and perm_code like '" + fathercode + "%'");
                GenCode = GetMaxTabCode(ds);
                if (GenCode != "100")
                {
                    GenCode = Convert.ToString(Convert.ToInt32(GenCode) + 1);
                }
                else
                {
                    GenCode = fathercode + "01";
                }
            }
            return GenCode;
        }

        /// <summary>
        /// 初始化菜单或页签树的根结点
        /// </summary>
        /// <param name="MenuPermissions">菜单项集合</param>
        /// <param name="trv">菜单树</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions, AdvTree trv)
        {
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == 3)
                {
                    Node tn = new Node();
                    tn.Tag = MenuPermissions[i];
                    tn.Text = MenuPermissions[i].Perm_name;
                    tn.ImageIndex = 0;                    
                    trv.Nodes.Add(tn);
                }               
            }
        }

        /// <summary>
        /// 初始化菜单或页签树子结点
        /// </summary>
        /// <param name="MenuPermissions">所有菜单项</param>
        /// <param name="tn">菜单树结点</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions, Node tn)
        {
            Class_Permission tempPermission = (Class_Permission)tn.Tag;
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == tempPermission.Perm_code.Length + 2 &&
                    MenuPermissions[i].Perm_code.Substring(0,tempPermission.Perm_code.Length).Contains(tempPermission.Perm_code))
                {
                    Node tempnode = new Node();
                    tempnode.Tag = MenuPermissions[i];
                    tempnode.Text = MenuPermissions[i].Perm_name;
                    tempnode.ImageIndex = 0;
                    IniMenuTreeview(MenuPermissions, tempnode);
                    tn.Nodes.Add(tempnode);                    
                }
            }
        }

        /// <summary>
        /// 更新菜单树结点
        /// </summary>
        private void UpdateMenuTreeview()
        {
            trvMenuOrButton.Nodes.Clear();          
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
                //DataSet dsinfo = App.GetDataSet("select * from t_permission_fuctions where PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                DataRow[] dsrows = ds.Tables["fuctions"].Select("PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                if (dsrows.Length > 0)
                {
                    MenuPermissions[i].Permission_Info.Id = Convert.ToInt32(dsrows[0]["id"]);
                    MenuPermissions[i].Permission_Info.Perm_code = dsrows[0]["PERM_CODE"].ToString();
                    MenuPermissions[i].Permission_Info.Function = dsrows[0]["FUNCTION"].ToString();
                    MenuPermissions[i].Permission_Info.Version = dsrows[0]["VERSION"].ToString();
                    MenuPermissions[i].Permission_Info.DllName = dsrows[0]["DLLNAME"].ToString();
                    //MenuPermissions[i].Permission_Info.Dll = (byte[])dsinfo.Tables[0].Rows[0]["PERM_DLL"];
                    if (dsrows[0]["FUNCTIONIMAGE"].ToString()!="")
                      MenuPermissions[i].Permission_Info.FunctionImage = (byte[])dsrows[0]["FUNCTIONIMAGE"];
                }

            }

            //刷新树结点
            IniMenuTreeview(MenuPermissions, trvMenuOrButton);
            for(int i=0;i<trvMenuOrButton.Nodes.Count;i++)
            {
                IniMenuTreeview(MenuPermissions, trvMenuOrButton.Nodes[i]);
            }
        }

        /// <summary>
        /// 更新按钮树结点
        /// </summary>
        private void UpdateButtonTreeview()
        {
            trvMenuOrButton.Nodes.Clear();
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
                Node tn = new Node();
                tn.Tag = btnPermissions[i];
                tn.Text = btnPermissions[i].Perm_name;
                tn.ImageIndex = 1;       
                trvMenuOrButton.Nodes.Add(tn);
            }            
        }

        /// <summary>
        /// 添加主菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加主ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentPerssmion = null;
            string code=GenalMenuCode("");
            frmPermissionSet_Info fm = new frmPermissionSet_Info(1, code,null);
            fm.ShowDialog();
            if (CurrentPerssmion != null)
            {
                Node tn = new Node();
                tn.Tag = CurrentPerssmion;
                tn.Text = CurrentPerssmion.Perm_name;
                tn.ImageIndex = 0;              
                trvMenuOrButton.Nodes.Add(tn);
                trvMenuOrButton.Refresh();
            }

            if (rbtnMenu.Checked)
            {
                RefleshGrid(1);
            }
            else if (rbtnButton.Checked)
            {
                RefleshGrid(2);
            }
            else
            {
                RefleshGrid(3);
            }
           
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加子菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvMenuOrButton.SelectedNode != null)
            {
                CurrentPerssmion = null;
                Class_Permission temppermission = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;    
                frmPermissionSet_Info fm = new frmPermissionSet_Info(1, GenalMenuCode(temppermission.Perm_code),null);
                fm.ShowDialog();
                if (CurrentPerssmion != null)
                {
                    Node tn = new Node();
                    tn.Tag = CurrentPerssmion;
                    tn.Text = CurrentPerssmion.Perm_name;
                    tn.ImageIndex = 0;               
                    trvMenuOrButton.SelectedNode.Nodes.Add(tn);                    
                }               
                RefleshGrid(1);               
            }            
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CurrentPerssmion = null;
            frmPermissionSet_Info fm = new frmPermissionSet_Info(2,"",null);
            fm.ShowDialog();          
            if (CurrentPerssmion != null)
            {  
                Node tn = new Node();
                tn.Tag = CurrentPerssmion;
                tn.Text = CurrentPerssmion.Perm_name;
                tn.ImageIndex = 1;              
                trvMenuOrButton.Nodes.Add(tn);                
            }          
            RefleshGrid(2);          
        }

        /// <summary>
        /// 添加页签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            CurrentPerssmion = null;
            string code = GenalTabCode("");
            frmPermissionSet_Info fm = new frmPermissionSet_Info(3, code, null);
            fm.ShowDialog();
            if (CurrentPerssmion != null)
            {
                Node tn = new Node();
                tn.Tag = CurrentPerssmion;
                tn.Text = CurrentPerssmion.Perm_name;
                tn.ImageIndex = 0;
                trvMenuOrButton.Nodes.Add(tn);
                trvMenuOrButton.Refresh();
            }

            if (rbtnMenu.Checked)
            {
                RefleshGrid(1);
            }
            else if (rbtnButton.Checked)
            {
                RefleshGrid(2);
            }
            else
            {
                RefleshGrid(3);
            }
        }

        /// <summary>
        /// 添加子页签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (trvMenuOrButton.SelectedNode != null)
            {
                CurrentPerssmion = null;
                Class_Permission temppermission = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                frmPermissionSet_Info fm = new frmPermissionSet_Info(3, GenalMenuCode(temppermission.Perm_code), null);
                fm.ShowDialog();
                if (CurrentPerssmion != null)
                {
                    Node tn = new Node();
                    tn.Tag = CurrentPerssmion;
                    tn.Text = CurrentPerssmion.Perm_name;
                    tn.ImageIndex = 0;
                    trvMenuOrButton.SelectedNode.Nodes.Add(tn);
                }
                RefleshGrid(3);
            }          
        }      

        /// <summary>
        /// 刷新表格
        /// </summary>
        /// <param name="type"></param>
        private void RefleshGrid(int type)
        {
            string Sql = "";
            if (type==1)
            {
                if (CurrentPerssmion != null)
                {
                    Sql = "select a.Id,a.PERM_CODE as 代码,a.PERM_NAME as 名称,b.DLLNAME as DLL名称,b.FUNCTION as 功能函数,b.VERSION as 版本号 from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='1' and a.PERM_CODE like'" + CurrentPerssmion.Perm_code + "%'";
                }
                else
                {
                    Sql = "select a.Id,a.PERM_CODE as 代码,a.PERM_NAME as 名称,b.DLLNAME as DLL名称,b.FUNCTION as 功能函数,b.VERSION as 版本号 from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='1'";
                }
                DataSet ds = App.GetDataSet(Sql);
                fg.DataSource = ds.Tables[0].DefaultView;                
            }
            else if (type == 2)
            {
                Sql = "select  a.Id,a.PERM_CODE as 代码 ,a.PERM_NAME as 名称 from t_permission a where a.PERM_KIND='2'";
                DataSet ds = App.GetDataSet(Sql);
                fg.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                //页签
                if (CurrentPerssmion != null)
                {
                    Sql = "select a.Id,a.PERM_CODE as 代码,a.PERM_NAME as 名称,b.DLLNAME as DLL名称,b.FUNCTION as 功能函数,b.VERSION as 版本号 from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='3' and a.PERM_CODE like'" + CurrentPerssmion.Perm_code + "%'";
                }
                else
                {
                    Sql = "select a.Id,a.PERM_CODE as 代码,a.PERM_NAME as 名称,b.DLLNAME as DLL名称,b.FUNCTION as 功能函数,b.VERSION as 版本号 from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='3'";
                }
                DataSet ds = App.GetDataSet(Sql);
                fg.DataSource = ds.Tables[0].DefaultView;     
            }
            fg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// 菜单节点的上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (trvMenuOrButton.SelectedNode != null)
            {
                Class_Permission Permission1 = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                if (trvMenuOrButton.SelectedNode.PrevNode != null)
                {

                    Class_Permission Permission2 = (Class_Permission)trvMenuOrButton.SelectedNode.PrevNode.Tag;
                    string[] sqls = new string[2];
                    sqls[0] = "update t_permission set num=" + Permission1.Num + " where id=" + Permission2.Id + "";
                    sqls[1] = "update t_permission set num=" + Permission2.Num + " where id=" + Permission1.Id + "";
                    App.ExecuteBatch(sqls);
                    string num = Permission1.Num;
                    Permission1.Num = Permission2.Num;
                    Permission2.Num = num;
                    int pindex = trvMenuOrButton.SelectedNode.PrevNode.Index;
                    int index = trvMenuOrButton.SelectedNode.Index;
                    Node pnode= trvMenuOrButton.SelectedNode.PrevNode.DeepCopy();
                    Node node = trvMenuOrButton.SelectedNode.DeepCopy();

                    if (trvMenuOrButton.SelectedNode.Parent == null)
                    {
                        trvMenuOrButton.Nodes[pindex] = node;
                        trvMenuOrButton.Nodes[index] = pnode;
                        trvMenuOrButton.Nodes[index].ImageIndex = 0;
                        trvMenuOrButton.Nodes[pindex].ImageIndex = 0;
                    }
                    else
                    {
                        trvMenuOrButton.SelectedNode.Parent.Nodes[pindex] = node;
                        trvMenuOrButton.SelectedNode.Parent.Nodes[index] = pnode;
                        trvMenuOrButton.Nodes[index].ImageIndex = 0;
                        trvMenuOrButton.Nodes[pindex].ImageIndex = 0;
                    }

                    trvMenuOrButton.Refresh();
                     

                }
            }
        }

        /// <summary>
        /// 菜单节点的下移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (trvMenuOrButton.SelectedNode != null)
            {
                Class_Permission Permission1 = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                if (trvMenuOrButton.SelectedNode.NextNode != null)
                {
                    Class_Permission Permission2 = (Class_Permission)trvMenuOrButton.SelectedNode.NextNode.Tag;
                    string[] sqls = new string[2];
                    sqls[0] = "update t_permission set num=" + Permission1.Num + " where id=" + Permission2.Id + "";
                    sqls[1] = "update t_permission set num=" + Permission2.Num + " where id=" + Permission1.Id + "";
                    App.ExecuteBatch(sqls);

                    string num = Permission1.Num;
                    Permission1.Num = Permission2.Num;
                    Permission2.Num = num; 

                    int pindex = trvMenuOrButton.SelectedNode.NextNode.Index;
                    int index = trvMenuOrButton.SelectedNode.Index;
                    Node pnode = trvMenuOrButton.SelectedNode.NextNode.DeepCopy();
                    Node node = trvMenuOrButton.SelectedNode.DeepCopy();

                    if (trvMenuOrButton.SelectedNode.Parent == null)
                    {
                        trvMenuOrButton.Nodes[pindex] = node;
                        trvMenuOrButton.Nodes[index] = pnode;
                        trvMenuOrButton.Nodes[index].ImageIndex = 0;
                        trvMenuOrButton.Nodes[pindex].ImageIndex = 0;
                    }
                    else
                    {
                        trvMenuOrButton.SelectedNode.Parent.Nodes[pindex] = node;
                        trvMenuOrButton.SelectedNode.Parent.Nodes[index] = pnode;
                        trvMenuOrButton.Nodes[index].ImageIndex = 0;
                        trvMenuOrButton.Nodes[pindex].ImageIndex = 0;
                    }                    
                    trvMenuOrButton.Refresh();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (rbtnMenu.Checked)
            {
                添加主ToolStripMenuItem.Enabled = true;
                添加子菜单ToolStripMenuItem.Enabled = true;
                toolStripMenuItem2.Enabled = false;
                上移ToolStripMenuItem.Enabled = true;
                下移ToolStripMenuItem.Enabled = true;
            }
            else if (rbtnButton.Checked)
            {
                添加主ToolStripMenuItem.Enabled = false;
                添加子菜单ToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = true;
                上移ToolStripMenuItem.Enabled = false;
                下移ToolStripMenuItem.Enabled = false;
            }
            else
            {
                添加主ToolStripMenuItem.Enabled = false;
                添加子菜单ToolStripMenuItem.Enabled = false;
                toolStripMenuItem7.Enabled=true;
                toolStripMenuItem8.Enabled = true;
                toolStripMenuItem2.Enabled = false;
                上移ToolStripMenuItem.Enabled = true;
                下移ToolStripMenuItem.Enabled = true;
            }
        }

        private void frmPermissionSet_Load(object sender, EventArgs e)
        {
            //App.Ini();
            //App.ButtonStytle(this);
            UpdateMenuTreeview();
            RefleshGrid(1);
        }

        private void rbtnButton_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rbtnButton.Checked)
            {                
                UpdateButtonTreeview();
                RefleshGrid(2);
                groupPanel1.Text = "按钮详细信息";
               
            }
            else if (rbtnMenu.Checked)
            {
                getMenuData();
                UpdateMenuTreeview();
                RefleshGrid(1);
                groupPanel1.Text = "菜单详细信息";
            }
            else
            {
                getTabData();
                UpdateMenuTreeview();
                RefleshGrid(3);
                groupPanel1.Text = "页签详细信息";
            }
        }

        private void trvMenuOrButton_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        /// <summary>
        /// 删除结点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (trvMenuOrButton.SelectedNode != null)
            { 
                Class_Permission temp = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                if (trvMenuOrButton.SelectedNode.Nodes.Count == 0)
                {                   
                    string[] sqls = new string[2];
                    sqls[0] = "delete from t_permission where PERM_CODE='" + temp.Perm_code + "'";
                    sqls[1] = "delete from t_permission_fuctions where PERM_CODE='" + temp.Perm_code + "'";

                    if (App.ExecuteBatch(sqls) > 0)
                    {                      
                        DeleteTrvNode(trvMenuOrButton.Nodes, trvMenuOrButton.SelectedNode);
                    }                  
                }
                else
                {
                    if (App.Ask("该菜单下存在着子项,如果删除子项菜单将会无法使用，是否还要删除？"))
                    {                       
                        string[] sqls = new string[2];
                        sqls[0] = "delete from t_permission where PERM_CODE='" + temp.Perm_code + "'";
                        sqls[1] = "delete from t_permission_fuctions where PERM_CODE='" + temp.Perm_code + "'";
                        if (App.ExecuteBatch(sqls) > 0)
                        {
                            DeleteTrvNode(trvMenuOrButton.Nodes, trvMenuOrButton.SelectedNode);
                        }                                        
                    }
                }
                if (rbtnMenu.Checked)
                {
                    RefleshGrid(1);
                }
                else
                {
                    RefleshGrid(2);
                }
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="Node1"></param>
        private void DeleteTrvNode(NodeCollection nodes,Node Node1)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i] == Node1)
                {
                    nodes.Remove(Node1);
                    return;
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    DeleteTrvNode(nodes[i].Nodes,Node1);
                }
            }
        }

        private void trvMenuOrButton_MouseDown(object sender, MouseEventArgs e)
        {
            trvMenuOrButton.SelectedNode = trvMenuOrButton.GetNodeAt(e.X, e.Y);
        }

        private void trvMenuOrButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (trvMenuOrButton.SelectedNode != null)
            {
                CurrentPerssmion = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                if (rbtnMenu.Checked)
                {
                    RefleshGrid(1);
                }
            }
        }

        /// <summary>
        /// 对结点进行修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvMenuOrButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (trvMenuOrButton.SelectedNode != null)
            {
                CurrentPerssmion = null;
                Class_Permission Temp = (Class_Permission)trvMenuOrButton.SelectedNode.Tag;
                int Type=1;
                if(rbtnButton.Checked)
                {
                   Type=2;
                }
                frmPermissionSet_Info fm = new frmPermissionSet_Info(Type, "", Temp);
                fm.ShowDialog();
                if (CurrentPerssmion != null)
                {
                    trvMenuOrButton.SelectedNode.Tag = CurrentPerssmion;
                    trvMenuOrButton.SelectedNode.Text = CurrentPerssmion.Perm_name;                   
                    RefleshGrid(2);                    
                }
            }
        }

        private void trvMenuOrButton_AfterNodeDeselect(object sender, AdvTreeNodeEventArgs e)
        {

        }

       
    }
}