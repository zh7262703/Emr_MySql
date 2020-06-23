using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadron;

namespace LeadronTest.SYSTEMSET
{
    public partial class frmPermissionSet : Form
    {
        /// <summary>
        /// 用于寄存当前正在操作的菜单或按钮对象
        /// </summary>
        public static Class_Permission CurrentPerssmion;

        public frmPermissionSet()
        {
            InitializeComponent();           
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
        /// 初始化菜单树的根结点
        /// </summary>
        /// <param name="MenuPermissions">菜单项集合</param>
        /// <param name="trv">菜单树</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions,TreeView trv)
        {
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == 3)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = MenuPermissions[i];
                    tn.Text = MenuPermissions[i].Perm_name;
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = 0;
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
                    MenuPermissions[i].Perm_code.Contains(tempPermission.Perm_code))
                {
                    TreeNode tempnode = new TreeNode();
                    tempnode.Tag = MenuPermissions[i];
                    tempnode.Text = MenuPermissions[i].Perm_name;
                    tempnode.ImageIndex = 0;
                    tempnode.SelectedImageIndex = 0;
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
            trvMenuOrButton.Nodes.Clear();
            DataSet ds = App.GetDataSet("select * from t_permission where PERM_KIND='1' order by num asc");
            Class_Permission[] MenuPermissions = new Class_Permission[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //菜单项
                MenuPermissions[i] = new Class_Permission();
                MenuPermissions[i].Id = ds.Tables[0].Rows[i]["id"].ToString();
                MenuPermissions[i].Perm_code = ds.Tables[0].Rows[i]["PERM_CODE"].ToString();
                MenuPermissions[i].Perm_name = ds.Tables[0].Rows[i]["PERM_NAME"].ToString();
                MenuPermissions[i].Perm_kind = ds.Tables[0].Rows[i]["PERM_KIND"].ToString();
                MenuPermissions[i].Num = ds.Tables[0].Rows[i]["NUM"].ToString();
                
                //菜单项详细信息
                MenuPermissions[i].Permission_Info = new Class_Permission_Info();
                DataSet dsinfo = App.GetDataSet("select * from t_permission_fuctions where PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                MenuPermissions[i].Permission_Info.Id = Convert.ToInt32(dsinfo.Tables[0].Rows[0]["ID"]);
                MenuPermissions[i].Permission_Info.Perm_code = dsinfo.Tables[0].Rows[0]["PERM_CODE"].ToString();
                MenuPermissions[i].Permission_Info.Function = dsinfo.Tables[0].Rows[0]["FUNCTION"].ToString();
                MenuPermissions[i].Permission_Info.Version = dsinfo.Tables[0].Rows[0]["VERSION"].ToString();
                MenuPermissions[i].Permission_Info.DllName = dsinfo.Tables[0].Rows[0]["DLLNAME"].ToString();
                MenuPermissions[i].Permission_Info.Dll = (byte[])dsinfo.Tables[0].Rows[0]["PERM_DLL"];
                MenuPermissions[i].Permission_Info.FunctionImage = (byte[])dsinfo.Tables[0].Rows[0]["FUNCTIONIMAGE"];

            }

            //刷新树结点
            IniMenuTreeview(MenuPermissions, trvMenuOrButton);
            for(int i=0;i<trvMenuOrButton.Nodes.Count;i++)
            {
                IniMenuTrvNode(MenuPermissions, trvMenuOrButton.Nodes[i]);
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
                TreeNode tn = new TreeNode();
                tn.Tag = btnPermissions[i];
                tn.Text = btnPermissions[i].Perm_name;
                tn.ImageIndex = 1;
                tn.SelectedImageIndex = 1;
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
            SYSTEMSET.frmPermissionSet_Info fm = new frmPermissionSet_Info(1, code,null);
            fm.ShowDialog();
            if (CurrentPerssmion != null)
            {
                TreeNode tn = new TreeNode();
                tn.Tag = CurrentPerssmion;
                tn.Text = CurrentPerssmion.Perm_name;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                trvMenuOrButton.Nodes.Add(tn);
                trvMenuOrButton.Refresh();
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
                SYSTEMSET.frmPermissionSet_Info fm = new frmPermissionSet_Info(1, GenalMenuCode(temppermission.Perm_code),null);
                fm.ShowDialog();
                if (CurrentPerssmion != null)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = CurrentPerssmion;
                    tn.Text = CurrentPerssmion.Perm_name;
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = 0;
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
            SYSTEMSET.frmPermissionSet_Info fm = new frmPermissionSet_Info(2,"",null);
            fm.ShowDialog();          
            if (CurrentPerssmion != null)
            {  
                TreeNode tn = new TreeNode();
                tn.Tag = CurrentPerssmion;
                tn.Text = CurrentPerssmion.Perm_name;
                tn.ImageIndex = 1;
                tn.SelectedImageIndex = 1;
                trvMenuOrButton.Nodes.Add(tn);                
            }          
            RefleshGrid(2);          
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
                    Sql = "select a.Id,a.PERM_CODE,a.PERM_NAME,b.DLLNAME,b.FUNCTION,b.VERSION from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='1' and a.PERM_CODE like'" + CurrentPerssmion.Perm_code + "%'";
                }
                else
                {
                    Sql = "select a.Id,a.PERM_CODE ,a.PERM_NAME,b.DLLNAME,b.FUNCTION,b.VERSION from t_permission a inner join T_PERMISSION_FUCTIONS b on a.PERM_CODE=b.PERM_CODE where a.PERM_KIND='1'";
                }
                DataSet ds = App.GetDataSet(Sql);
                App.reFleshFlexGrid(ds, ref fg, "PERM_CODE,PERM_NAME,DLLNAME,FUNCTION,VERSION", "代码,名称,DLL名称,功能函数,版本号");
            }
            else
            {
                Sql = "select  a.Id,a.PERM_CODE ,a.PERM_NAME from t_permission a where a.PERM_KIND='2'";                
                DataSet ds = App.GetDataSet(Sql);
                App.reFleshFlexGrid(ds, ref fg, "PERM_CODE,PERM_NAME", "代码,名称");
            }
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
                    App.ExecuteSQL("update t_permission set num=" + Permission1.Num + " where id=" + Permission2.Id + "");
                    App.ExecuteSQL("update t_permission set num=" + Permission2.Num + " where id=" + Permission1.Id + "");
                    string num = Permission1.Num;
                    Permission1.Num = Permission2.Num;
                    Permission2.Num = num;
                    trvMenuOrButton.SelectedNode.Tag = Permission1;
                    trvMenuOrButton.SelectedNode.PrevNode.Tag = Permission2;
                    App.TrvNodeMovUp(trvMenuOrButton.SelectedNode,trvMenuOrButton);
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
                    App.ExecuteSQL("update t_permission set num=" + Permission1.Num + " where id=" + Permission2.Id + "");
                    App.ExecuteSQL("update t_permission set num=" + Permission2.Num + " where id=" + Permission1.Id + "");
                    string num = Permission1.Num;
                    Permission1.Num = Permission2.Num;
                    Permission2.Num = num;
                    trvMenuOrButton.SelectedNode.Tag = Permission1;
                    trvMenuOrButton.SelectedNode.PrevNode.Tag = Permission2;
                    App.TrvNodeMovDown(trvMenuOrButton.SelectedNode, trvMenuOrButton);
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
            else
            {
                添加主ToolStripMenuItem.Enabled = false;
                添加子菜单ToolStripMenuItem.Enabled = false;
                toolStripMenuItem2.Enabled = true;
                上移ToolStripMenuItem.Enabled = false;
                下移ToolStripMenuItem.Enabled = false;
            }
        }

        private void frmPermissionSet_Load(object sender, EventArgs e)
        {
            App.Ini();
            App.ButtonStytle(this);
            UpdateMenuTreeview();
            RefleshGrid(1);
        }

        private void rbtnButton_CheckedChanged(object sender, EventArgs e)
        {           
            if (rbtnButton.Checked)
            {
                UpdateButtonTreeview();
                RefleshGrid(2);
                groupBox2.Text = "按钮详细信息";
               
            }
            else
            {
                UpdateMenuTreeview();
                RefleshGrid(1);
                groupBox2.Text = "菜单详细信息";
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
                    App.ExecuteSQL("delete from t_permission where PERM_CODE='" + temp.Perm_code + "'");
                    App.ExecuteSQL("delete from t_permission_fuctions where PERM_CODE='" + temp.Perm_code + "'");
                    trvMenuOrButton.Nodes.Remove(trvMenuOrButton.SelectedNode);                 
                }
                else
                {
                    if (App.Ask("该菜单下存在着子项,如果删除子项菜单将会无法使用，是否还要删除？"))
                    {
                        App.ExecuteSQL("delete from t_permission where PERM_CODE='" + temp.Perm_code + "'");
                        App.ExecuteSQL("delete from t_permission_fuctions where PERM_CODE='" + temp.Perm_code + "'");
                        trvMenuOrButton.Nodes.Remove(trvMenuOrButton.SelectedNode);                      
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

        private void rbtnMenu_CheckedChanged(object sender, EventArgs e)
        {

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
                }
            }
        }      
    }
}