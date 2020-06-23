using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Xml;
using Bifrost;
using DevComponents.DotNetBar;
using Bifrost.SYSTEMSET;


namespace BifrostMainPro
{
    /// <summary>
    /// 系统的主框架程序
    /// 创建者：张华
    /// 创建时间：2009-12-10
    /// </summary>
    public partial class MDIParent1 :DevComponents.DotNetBar.Office2007Form
    {
        private int childFormNumber = 0;

        public static bool isReset = false;                    //判断是否是注销操作

        //private ArrayList Openforms = new ArrayList(); //记录打开窗体的步骤（dll名+函数名+窗体类型）

        Thread NoticeLight = new Thread(new ThreadStart(ShowNoticeLight));

        Thread UploadDoc = new Thread(new ThreadStart(UploadDocfiles));    //时时上传文书图片文件

        private int cunum = 0;                           //小灯计数

        private static bool Huizhenflag = false;         //会诊显示信号 true 显示 false 不显示

        private static bool ZhiKongflag = false;         //质量控制显示信号 true 显示 false 不显示 

        private static bool Bkglflag = false;            //报卡管理 true限制 false不显示

        private static int CurrentChildFormsCount = 0;

        private string opstr = "";                       //操作字符串 

        //private int ActioMaxId = 0;                    //检测移动表

        private string ServerIp = "";
        public static XmlDocument updateDoc = new XmlDocument();

        public static int AccountType = 0;

       
        WebRequest req;
        WebResponse res;
        WebClient wClient;
        string CVersion;
        string SerVersion;
        string serverXmlFile;
        string tempUpdatePath;
        string TempClientVersion;

        
       
        public MDIParent1()
        {
           
            /*
             * 初始化一些系统参数
             * 并且进行登录操作
             */
            //App.Ini();
            //App.iniwebservice();           
            //Thread keytest = new Thread(new ThreadStart(CheckUK));
            //keytest.IsBackground = true;
            //keytest.Start();   
            //frmLogin fm = new frmLogin();
            //App.FormStytleSet(fm, false);
            //fm.ShowDialog();
            InitializeComponent();
            ServerIp = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini"));
            req = WebRequest.Create(ServerIp + @"/WebSite1/Update.xml"); 
                      
           
        }

        ///// <summary>
        ///// 初始化按钮的Enable状态
        ///// </summary>
        //private void IniEnableToolButton()
        //{
        //    tsbtnWrite.Enabled = false;
        //    tsbtnSign.Enabled = false;
        //    tsbtnCheck.Enabled = false;
        //    tsbtnModify.Enabled = false;
        //    tsbtnDelete.Enabled = false;
        //    tsbtnLook.Enabled = false;
        //    tsbtnImport.Enabled = false;
        //    tsbtnOutPut.Enabled = false;
        //    tsbtnTemplate.Enabled = false;
        //    tsbtnTemplateSave.Enabled = false;
        //    ttsbtnPrint.Enabled = false;
        //    tsbtnTempSave.Enabled = false;
        //    tsbtnCommit.Enabled = false;
        //}

        /// <summary>
        /// 初始化系统
        /// </summary>
        private void IniSystem()
        {
            //App.Progress("系统正在初始化，请稍后...");
            if (App.UserAccount != null)
            {
                if (App.UserAccount.CurrentSelectRole != null)
                {
                    for (int i = 0; i < this.toolbar.Items.Count; i++)
                    {

                        if (this.toolbar.Items[i].Name == "tsbtnDutySet")
                        {
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("科主任") || App.UserAccount.CurrentSelectRole.Role_name.Contains("科副主任"))
                            {
                                this.toolbar.Items[i].Visible = true;
                            }
                            else
                            {
                                this.toolbar.Items[i].Visible = false;
                            }
                        }
                    }

                    this.Cursor = Cursors.WaitCursor;
                   
                    App.MdiFormTittle = "当前用户：" + App.UserAccount.UserInfo.User_name + "     工号:" + App.UserAccount.Account_name + "     职称："+App.UserAccount.UserInfo.U_tech_post_name + "     角色：" + App.UserAccount.CurrentSelectRole.Role_name;
                    if (App.UserAccount.CurrentSelectRole.Section_Id != "0" && App.UserAccount.CurrentSelectRole.Section_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     科室：" + App.UserAccount.CurrentSelectRole.Section_name;
                    }
                    else if (App.UserAccount.CurrentSelectRole.Sickarea_Id != "0" && App.UserAccount.CurrentSelectRole.Sickarea_Id != "")
                    {
                        App.MdiFormTittle = App.MdiFormTittle + "     病区：" + App.UserAccount.CurrentSelectRole.Sickarea_name;
                    }
                    else
                    {
 
                    }

                    App.ParentForm = this;
                    this.Text = App.MdiFormTittle;
                    
                    MenuBar.Items.Clear();

                    Bifrost.WebReference.Class_Table[] tabsqls = new Bifrost.WebReference.Class_Table[2];

                    tabsqls[0] = new Bifrost.WebReference.Class_Table();
                    tabsqls[0].Sql = "select * from t_permission where PERM_KIND='1' order by num asc";
                    tabsqls[0].Tablename = "permssion";

                    tabsqls[1] = new Bifrost.WebReference.Class_Table();
                    tabsqls[1].Sql = "select PERM_CODE,FUNCTION,VERSION,DLLNAME from t_permission_fuctions";//,FUNCTIONIMAGE 
                    tabsqls[1].Tablename = "permission_fuctions";                                      

                    DataSet ds = App.GetDataSet(tabsqls);                  
                    Class_Permission[] MenuPermissions = new Class_Permission[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //菜单项
                        MenuPermissions[i] = new Class_Permission();
                        MenuPermissions[i].Id = ds.Tables["permssion"].Rows[i]["id"].ToString();
                        MenuPermissions[i].Perm_code = ds.Tables["permssion"].Rows[i]["PERM_CODE"].ToString();
                        MenuPermissions[i].Perm_name = ds.Tables["permssion"].Rows[i]["PERM_NAME"].ToString();
                        MenuPermissions[i].Perm_kind = ds.Tables["permssion"].Rows[i]["PERM_KIND"].ToString();
                        MenuPermissions[i].Num = ds.Tables["permssion"].Rows[i]["NUM"].ToString();

                        //菜单项详细信息
                        MenuPermissions[i].Permission_Info = new Class_Permission_Info();

                        DataRow[] dsinforows = ds.Tables["permission_fuctions"].Select("PERM_CODE='" + MenuPermissions[i].Perm_code + "'");
                        if (dsinforows != null)
                        {
                            if (dsinforows.Length > 0)
                            {
                                MenuPermissions[i].Permission_Info.Perm_code = dsinforows[0]["PERM_CODE"].ToString();
                                MenuPermissions[i].Permission_Info.Function = dsinforows[0]["FUNCTION"].ToString();
                                MenuPermissions[i].Permission_Info.Version = dsinforows[0]["VERSION"].ToString();
                                MenuPermissions[i].Permission_Info.DllName = dsinforows[0]["DLLNAME"].ToString();
                                //MenuPermissions[i].Permission_Info.Dll = (byte[])dsinfo.Tables[0].Rows[0]["PERM_DLL"];
                                //MenuPermissions[i].Permission_Info.FunctionImage = (byte[])dsinforows[0]["FUNCTIONIMAGE"];
                                //MenuPermissions[i].Permission_Info.Ismainfrom = dsinforows[0]["ismainfrom"].ToString();
                            }
                        }
                    }
                    //刷新树结点
                    IniMenuTreeview(MenuPermissions, MenuBar);
                    for (int i = 0; i < MenuBar.Items.Count; i++)
                    {
                        IniMenuTrvNode(MenuPermissions, (ButtonItem)MenuBar.Items[i]);
                    }

                    //隐藏子节点为空的主菜单
                    HideAllRootNoChildsMenu();
                    

                    //设置工具栏控件                      
                    //App.BtnEnableSet(App.UserAccount.CurrentSelectRole.Permissions, this.toolStrip1);  
                    //IniToolBar();
                    this.Cursor = Cursors.Default;
                }
                //this.Show();
                //this.Activate();

                this.Focus();
                ShowMainFrm();
                //App.HideProgress();
            }
        }
       

        /// <summary>
        /// 初始化工具栏 
        /// </summary>
        private void IniToolBar()
        {
            
            for (int i = 0; i < this.toolbar.Items.Count; i++)
            {
                if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                    this.toolbar.Items[i].Name != "tbtnRoleChose" &&
                    this.toolbar.Items[i].Name != "tbtnAccountClear" && 
                    this.toolbar.Items[i].Name != "tsbtnSectionAccountSets" &&  
                    this.toolbar.Items[i].Name != "tbtnPassword" &&
                    this.toolbar.Items[i].Name != "tsbtnZLGF" &&
                    this.toolbar.Items[i].Name != "tsbtnHelp" && 
                    this.toolbar.Items[i].Name != "tsbtnDutySet" && 
                    this.toolbar.Items[i].Name != "tsbtnSmallTemplateSave")
                {
                    this.toolbar.Items[i].Enabled = false;
                }

                if (this.toolbar.Items[i].Name == "tsbtnDutySet")
                {

                    this.toolbar.Items[i].Visible = false;

                }
            }
            tsbtnSectionAccountSets.Visible = true;
            tsbtnSectionAccountSets.Enabled = true;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // 创建此子窗体的一个新实例。
            Form childForm = new Form();
            // 在显示该窗体前使其成为此 MDI 窗体的子窗体。
            childForm.MdiParent = this;
            childForm.Text = "窗口" + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: 在此处添加打开文件的代码。
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: 在此处添加代码，将窗体的当前内容保存到一个文件中。
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard 将所选的文本或图像插入到剪贴板
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard 将所选的文本或图像插入到剪贴板
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 使用 System.Windows.Forms.Clipboard.GetText() 或 System.Windows.Forms.GetData 从剪贴板中检索信息。
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// 判断菜单或按钮是否具有权限
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        private bool IsHaveRight(string code)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < App.UserAccount.CurrentSelectRole.Permissions.Length; i++)
                {
                    if (App.UserAccount.CurrentSelectRole.Permissions[i].Perm_code == code)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化菜单树的根结点
        /// </summary>
        /// <param name="MenuPermissions">菜单项集合</param>
        /// <param name="trv">菜单树</param>
        private void IniMenuTreeview(Class_Permission[] MenuPermissions, DevComponents.DotNetBar.Bar Menu)
        {                        
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == 3)
                {                    
                    //ToolStripMenuItem mn = new ToolStripMenuItem();
                    //mn.Text = MenuPermissions[i].Perm_name;
                    //mn.Name = MenuPermissions[i].Perm_code;
                    //mn.Tag = MenuPermissions[i];
                    //mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                    //mn.Click += new EventHandler(AllMenuItem_Click);
                    //Menu.Items.Add(mn);


                    ButtonItem mn = new ButtonItem();
                    mn.ButtonStyle = eButtonStyle.ImageAndText;
                    mn.PopupType = ePopupType.Menu;
                    mn.Text = MenuPermissions[i].Perm_name;
                    mn.Name = MenuPermissions[i].Perm_code;
                    mn.Tag = MenuPermissions[i];
                    mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                    mn.ImageFixedSize = new Size(16, 16);
                    mn.Click += new EventHandler(AllMenuItem_Click);

                    Menu.Items.Add(mn);
                    Menu.RecalcSize();
                }
            }
        }

        /// <summary>
        /// 初始化菜单树子结点
        /// </summary>
        /// <param name="MenuPermissions">所有菜单项</param>
        /// <param name="tn">菜单树结点</param>
        private void IniMenuTrvNode(Class_Permission[] MenuPermissions, ButtonItem Item)
        {
            Class_Permission tempPermission = (Class_Permission)Item.Tag;
            for (int i = 0; i < MenuPermissions.Length; i++)
            {
                if (MenuPermissions[i].Perm_code.Length == tempPermission.Perm_code.Length + 2 &&
                    MenuPermissions[i].Perm_code.Contains(tempPermission.Perm_code))
                {
                    if (IsHaveRight(MenuPermissions[i].Perm_code))
                    {
                        ButtonItem mn = new ButtonItem();
                        mn.Text = MenuPermissions[i].Perm_name;
                        mn.Name = MenuPermissions[i].Perm_code;
                        mn.Tag = MenuPermissions[i];                        
                        mn.PopupType = ePopupType.Menu;
                        mn.Image = App.ByteToImg(MenuPermissions[i].Permission_Info.FunctionImage);
                        mn.ImageFixedSize = new Size(16, 16);
                        mn.PopupAnimation=DevComponents.DotNetBar.ePopupAnimation.SystemDefault;                     
                        mn.Click += new EventHandler(AllMenuItem_Click);
                        IniMenuTrvNode(MenuPermissions, mn);
                        Item.SubItems.Add(mn);
                    }
                }
            }
        }


        /// <summary>
        /// 隐藏所有没有子节点的根节点菜单
        /// </summary>
        private void HideAllRootNoChildsMenu()
        {
            for (int i = 0; i < MenuBar.Items.Count; i++)
            {
                ButtonItem MenuItem = (ButtonItem)MenuBar.Items[i];
                if(MenuItem.SubItems.Count == 0)
                   MenuBar.Items[i].Visible = false;
            }
        }

        /// <summary>
        /// 显示主界面
        /// </summary>
        private void ShowMainFrm()
        {
            try
            {
                if (App.UserAccount != null)
                {
                    bool flag = false;
                    if (App.UserAccount.CurrentSelectRole != null)
                    {
                        tsbtnTemplateSave.Visible = false;
                        /*
                         * 正式帐号
                         */                        
                        if (App.UserAccount.CurrentSelectRole.Role_type == "M")
                        {
                            //系统管理员
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            //医生
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_Doctor.dll");
                            Type tmpType = assmble.GetType("Bifrost_Doctor.Test");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmShow");
                            object tmpobj = assmble.CreateInstance("Bifrost_Doctor.Test");
                            tmpM.Invoke(tmpobj, null);                           
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //护士                    
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_Doctor.dll");
                            Type tmpType = assmble.GetType("Bifrost_Doctor.Test");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmShow");
                            object tmpobj = assmble.CreateInstance("Bifrost_Doctor.Test");
                            tmpM.Invoke(tmpobj, null);                           
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "H")
                        {
                            //护理部                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\ThreadManagement.dll");
                            Type tmpType = assmble.GetType("ThreadManagement.Template");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmUCEParamShow");
                            object tmpobj = assmble.CreateInstance("ThreadManagement.Template");//ThreadManagement.Template.frmUCEParamShow;ThreadManagement.frmUCEParam
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "Y")
                        {
                            //医教处                 
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\ThreadManagement.dll");
                            Type tmpType = assmble.GetType("ThreadManagement.Template");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmYWCParamShow");
                            object tmpobj = assmble.CreateInstance("ThreadManagement.Template");//ThreadManagement.Template.frmYWCParamShow
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "B")
                        {
                            //病情案管理                   
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_Hospital_Management.dll");
                            Type tmpType = assmble.GetType("Bifrost_Hospital_Management.CaseManagement");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("frmFormTestShow");
                            object tmpobj = assmble.CreateInstance("Bifrost_Hospital_Management.CaseManagement");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type=="O")
                        {
                            //其他
                            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("检验科医师"))
                            {
                                //病情案管理                   
                                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_Doctor.dll");
                                Type tmpType = assmble.GetType("Bifrost_Doctor.Test");
                                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmRightRun");
                                object tmpobj = assmble.CreateInstance("Bifrost_Doctor.Test");
                                tmpM.Invoke(tmpobj, null);
                                flag = true;

                                #region 工具栏的设置


                                for (int i = 0; i < this.toolbar.Items.Count; i++)
                                {
                                    if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                                        this.toolbar.Items[i].Name != "tbtnRoleChose" &&
                                        this.toolbar.Items[i].Name != "tbtnAccountClear" &&
                                        this.toolbar.Items[i].Name != "tsbtnSectionAccountSets" &&
                                        this.toolbar.Items[i].Name != "tbtnPassword" &&
                                        this.toolbar.Items[i].Name != "tsbtnHelp")
                                    {
                                        this.toolbar.Items[i].Visible = false;
                                    }
                                    else
                                    {
                                        this.toolbar.Items[i].Enabled = true;
                                    }                                  
                                }

                                labelItemBktx.Visible = false;
                                toolHuizhen.Visible = false;
                                toolZhikong.Visible = false;
                                #endregion
                            }
                        }
                        if (flag)
                        {
                            DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                            temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                            temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                            temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                            opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                            App.Openforms.Add(opstr);
                            tabOpenForms.Tabs.Add(temptab);
                            tabOpenForms.Refresh();
                        }
                        toolHuizhen.Image = imageList1.Images[0];
                        toolZhikong.Image = imageList1.Images[1];
                    }
                    else
                    {
                        if (MDIParent1.AccountType != 0)
                        {
                            /*
                             * 临时帐号
                             */
                            System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Bifrost_Nurse.dll");
                            Type tmpType = assmble.GetType("frameEMR.test");
                            System.Reflection.MethodInfo tmpM = tmpType.GetMethod("FrmTempAccount_UserInfo");
                            object tmpobj = assmble.CreateInstance("frameEMR.test");
                            tmpM.Invoke(tmpobj, null);
                            flag = true;
                            if (flag)
                            {
                                DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                                temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                                temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                                temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                                opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                                App.Openforms.Add(opstr);
                                tabOpenForms.Tabs.Add(temptab);
                                tabOpenForms.Refresh();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                App.HideProgress();
                App.MsgErr("初始化出错，原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 检查是否存在已打开的子窗体
        /// </summary>
        /// <param name="strfunct">窗体的函数名</param>
        /// <returns></returns>
        private bool checkchildFrmExist(string strfunct)
        {
            for (int i = 0; i < App.Openforms.Count; i++)
            {
                if (App.Openforms[i].ToString().Contains(strfunct))
                {
                    return true;
                }
            }
            return false;         
        }

        /// <summary>
        /// 获得打开窗体的类型
        /// </summary>
        /// <param name="strfunct">窗体的函数名</param>
        /// <returns></returns>
        private string Getfrmtype(string strfunct)
        {
            try
            {
                for (int i = 0; i < App.Openforms.Count; i++)
                {
                    if (App.Openforms[i].ToString().Contains(strfunct))
                    {
                        return App.Openforms[i].ToString().Split(';')[1];
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 所有菜单的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ButtonItem temp = (ButtonItem)sender;
            if (temp.Tag != null)
            {
                try
                {

                    Class_Permission tempPermission = (Class_Permission)temp.Tag;
                    if (tempPermission.Permission_Info.Function.Trim() != "")
                    {
                        System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\" + tempPermission.Permission_Info.DllName);
                        Type tmpType = assmble.GetType(assmble.ManifestModule.Name.Split('.')[0] + "." + tempPermission.Permission_Info.Function.Split('.')[0]);
                        System.Reflection.MethodInfo tmpM = tmpType.GetMethod(tempPermission.Permission_Info.Function.Split('.')[1]);
                        object tmpobj = assmble.CreateInstance(assmble.ManifestModule.Name.Split('.')[0] + "." + tempPermission.Permission_Info.Function.Split('.')[0]);                                                      
                        opstr=assmble.ManifestModule.Name.Split('.')[0] + "." + tempPermission.Permission_Info.Function;
                        if (!checkchildFrmExist(opstr))
                        {
                            //打开新窗体  
                           tmpM.Invoke(tmpobj, null);
                           DevComponents.DotNetBar.TabItem temptab = new DevComponents.DotNetBar.TabItem();
                           temptab.Name = Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();
                           temptab.Text = Application.OpenForms[Application.OpenForms.Count - 1].Text;
                           temptab.AttachedControl = (Control)Application.OpenForms[Application.OpenForms.Count - 1];
                           opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）                          
                           App.Openforms.Add(opstr);//Inhospital_Info.Test.FrmShow;Inhospital_Info.frmMain

                           tabOpenForms.Tabs.Add(temptab);
                           tabOpenForms.Refresh();
                           opstr = "";
                           tabOpenForms.SelectedTab = tabOpenForms.Tabs[tabOpenForms.Tabs.Count - 1];
                          
                       }
                       else//打开已经有的窗体
                       {
                           string frmtype = Getfrmtype(opstr);                           
                           for (int j = 0; j < tabOpenForms.Tabs.Count; j++)
                           {
                               if (frmtype == tabOpenForms.Tabs[j].Name)
                               {
                                   tabOpenForms.SelectedTab = tabOpenForms.Tabs[j];
                                   tabOpenForms.Refresh();                                          
                                   break;
                               }
                           }                                                                    
                           return;                         
                       }                                              
                    }
                    IniToolBar();
                }
                catch (Exception ex)
                {
                    App.MsgErr("再调用菜单功能时出错，原因:" + ex.Message);
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {                                
            IniToolBar();            
            if (App.UserAccount != null)
            {
                if (App.UserAccount.UserInfo != null)
                {

                    /*
                    * 工具栏                     
                    */
                    if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921 || App.UserAccount.Kind == 52 || App.UserAccount.Kind == 70)
                    {
                        //实习生、研究生、进修生
                        tbtnAccountClear.Enabled = true;
                        tbtnAccountClear.Visible = true;
                    }   
                    //this.Show();
                    //角色设置
                    frmRoleChose fmRole = new frmRoleChose();
                    App.ButtonStytle(fmRole, false);
                    fmRole.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    fmRole.ControlBox = false;
                    fmRole.MaximizeBox = false;
                    fmRole.MinimizeBox = false;
                    fmRole.ShowDialog();
                    //App.Progress("正在初始化系统，请稍后...");     
                    IniSystem();


                    if (App.UserAccount.CurrentSelectRole != null)
                    {
                        if (App.UserAccount.CurrentSelectRole.Role_name.Contains("主任") && 
                            Convert.ToInt16(App.UserAccount.CurrentSelectRole.Rnages.Length)>0)
                        {
                            if (App.UserAccount.CurrentSelectRole.Rnages.Length > 0)
                            {
                                tsbtnSectionAccountSets.Enabled = true;
                                tsbtnSectionAccountSets.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    /*
                     * 测试帐号
                     */
                    App.ParentForm = this;
                    ShowMainFrm();

                    for (int i = 0; i < this.toolbar.Items.Count; i++)
                    {
                        if (this.toolbar.Items[i].Name != "tbtnResetSystem" &&
                            this.toolbar.Items[i].Name != "tbtnPassword")
                        {
                            this.toolbar.Items[i].Enabled = false;
                            this.toolbar.Items[i].Visible = false;
                        }
                    }

                }
            }
            CurrentChildFormsCount = Application.OpenForms.Count;
            //this.Visible=true;
            if (App.UserAccount == null)
            {
                Application.Exit();
            }
            //else
            //{
            //    if (App.UserAccount.UserInfo == null)
            //    {
            //        Application.Exit();
            //    }
            //}
            try
            {
                //如果更新程序需要更新的话
                if (File.Exists(App.SysPath + "\\FTPTEST.ex"))
                {
                    if (File.Exists(App.SysPath + "\\FTPTEST.exe"))
                       File.Delete(App.SysPath + "\\FTPTEST.exe");
                    File.Move(App.SysPath + "\\FTPTEST.ex", App.SysPath + "\\FTPTEST.exe");
                }               
            }
            catch
            { }
            NoticeLight.IsBackground = true;
            NoticeLight.Start();

            UploadDoc.IsBackground = true;
            UploadDoc.Start();
           
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {

            //if (App.UserAccount != null)
            //{
            //    App.ExecuteSQL("update T_ACCOUNT set LAST_EXIT_TIME=to_timestamp('" +
            //        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") +
            //        "', 'syyyy-mm-dd hh24:mi:ss.ff9'),IS_ONLINE=0 where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
            //}            
            //Application.Exit(); 
            if (!isReset)
              Environment.Exit(0);
            else
              Application.Exit(); 
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (App.UserAccount != null)
            {
                if (App.UserAccount.UserInfo != null)
                {
                    if (!isReset)
                    {
                        if (App.Ask("是否正要退出吗？") == false)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 角色设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnRoleChose_Click(object sender, EventArgs e)
        {
            
            if (Application.OpenForms.Count > 1)
            {       
                bool flag = true;
                flag=App.Ask("角色切换之前，确定关闭已打开的窗体吗？");
                if (flag == true)
                {
                    Form[] frmList = this.MdiChildren;
                    foreach (Form frm in frmList)
                    {
                        frm.Close();                        
                    }
                    tabOpenForms.Tabs.Clear();
                    App.Openforms.Clear();
                    CurrentChildFormsCount = Application.OpenForms.Count;
                    tabOpenForms.Refresh();
                }  
                else                
                   return;
            }                    
            Class_Role CurrentTemp = App.UserAccount.CurrentSelectRole;
            frmRoleChose fm = new frmRoleChose();
            App.ButtonStytle(fm,false);
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            fm.ControlBox = false;
            fm.MaximizeBox = false;
            fm.MinimizeBox = false;
            fm.ShowDialog();          

            //if (CurrentTemp != App.UserAccount.CurrentSelectRole)
            //{                
                IniSystem();
            //}
        }

        /// <summary>
        /// 系统注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnResetSystem_Click(object sender, EventArgs e)
        {
            if (App.Ask("真的要注销系统吗？"))
            {
                isReset = true;
                Application.Restart();
            }
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnPassword_Click(object sender, EventArgs e)
        {
            frmPasswordChanged frm = new frmPasswordChanged();
            App.ButtonStytle(frm,false);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            frm.ControlBox = false;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ShowDialog();
        }       

        #region ButtonEventsSet
        private void tsbtnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Write(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Write = null;
            }
        }

        private void tsbtnSign_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Sign(sender, e);
            }
            catch 
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Sign = null;
            }
        }

        private void tsbtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Check(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Check = null;
            }
        }

        private void tsbtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Modify(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Modify = null;
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Delete(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Delete = null;
            }
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Look(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Look = null;
            }
        }

        private void tsbtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Import(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Import = null;
            }
        }

        private void tsbtnOutPut_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_OutPut(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_OutPut = null;
            }
        }

        private void tsbtnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Template(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Template = null;
            }
        }

        private void tsbtnTemplateSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_TemplateSave(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_TemplateSave = null;
            }
        }

        private void tsbtnSmallTemplateSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_SmallTemplateSave(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");              
            }
        }

        private void ttsbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Print(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Print = null;
            }
        }

        private void tsbtnTempSave_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_TempSave(sender, e);
                if (App.A_RefleshTreeBook != null)
                {
                    App.A_RefleshTreeBook(sender, e);
                }
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_TempSave = null;
            }
        }

        private void tsbtnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_Commit(sender, e);
                if (App.A_RefleshTreeBook != null)
                {
                    App.A_RefleshTreeBook(sender, e);
                }
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_Commit = null;
            }
        }

        private void tsbtnBKSB_Click(object sender, EventArgs e)
        {
            try
            {
                App.A_BKSB(sender, e);
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_BKSB = null;
            }
        }
        #endregion

        private void MDIParent1_Resize(object sender, EventArgs e)
        {
            //toolStripLabel.Width = ribbonBar1.Width - 100;
        }


      
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {                
                if (cunum % 5 == 0)
                {
                    if (Huizhenflag)
                    {
                        if (toolHuizhen.ImageIndex == 3)
                        {
                            toolHuizhen.Image = imageList1.Images[4];
                            toolHuizhen.ImageIndex = 4;
                        }
                        else
                        {
                            toolHuizhen.Image = imageList1.Images[3];
                            toolHuizhen.ImageIndex = 3;
                        }
                    }
                    else
                    {
                        toolHuizhen.Image = imageList1.Images[4];
                    }

                    if (Bkglflag)
                    {
                        if (toolHuizhen.ImageIndex == 6)
                        {
                            toolHuizhen.Image = imageList1.Images[7];
                            toolHuizhen.ImageIndex = 7;
                        }
                        else
                        {
                            toolHuizhen.Image = imageList1.Images[6];
                            toolHuizhen.ImageIndex = 6;
                        }
                    }
                    else
                    {
 
                    }

                    if (ZhiKongflag)
                    {
                        if (toolZhikong.ImageIndex == 5)
                        {
                            toolZhikong.Image = imageList1.Images[2];
                            toolZhikong.ImageIndex = 2;
                        }
                        else
                        {
                            toolZhikong.Image = imageList1.Images[5];
                            toolZhikong.ImageIndex = 5;
                        }
                    }
                    else if (cunum % 40 == 0)
                    {
                        //try
                        //{

                        //    tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\ItemNewDocUpdate\\";
                        //    serverXmlFile = tempUpdatePath + @"Update.xml";
                        //    res = req.GetResponse();
                        //    if (!Directory.Exists(tempUpdatePath))
                        //    {
                        //        Directory.CreateDirectory(tempUpdatePath);
                        //    }
                        //    if (res.ContentLength > 0)
                        //    {                                
                        //        wClient = new WebClient();
                        //        wClient.DownloadFile(ServerIp + @"/WebSite1/Update.xml", serverXmlFile);//this.UpdaterUrl,serverXmlFile					                                              
                        //        updateDoc.Load(serverXmlFile);
                        //        CVersion = Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Version", Application.StartupPath + "\\Config.ini"));
                        //        SerVersion = updateDoc.ChildNodes[1].SelectSingleNode("vsersion").InnerText;                                
                        //        //TempClientVersion                              
                        //        if (TempClientVersion != SerVersion)
                        //        {
                        //            if (CVersion.Trim() == "")
                        //            {
                        //                CVersion = "0";

                        //            }
                        //            if (SerVersion.Trim() == "")
                        //            {
                        //                SerVersion = "0";
                        //            }
                        //            if (Convert.ToSingle(SerVersion) > Convert.ToSingle(CVersion))
                        //            {
                        //                App.ShowTip("系统消息提示", "已经检到测服务器端有了更新，请及时更新系统！",@"http://192.168.36.6/WebSite1/Help.html");
                        //            }
                        //            TempClientVersion = SerVersion;
                        //        }
                        //    }
                        //}
                        //catch
                        //{
 
                        //}

                    }
                    else
                    {
                        toolZhikong.Image = imageList1.Images[2];
                    }
                    toolZhikong.Refresh();
                    toolHuizhen.Refresh();
                }
                if (cunum == 10000000)
                {
                    cunum = 0;
                }
                else
                {
                    cunum++;
                }
            }
            catch
            {
                cunum=0;
            }
        }

        private static void ShowNoticeLight()
        {
              do
                {
                    try
                    {
                        DataSet ds_N_ZK =new DataSet();
                        DataSet ds_D_HZ = new DataSet();
                        DataSet ds_D_ZK = new DataSet();
                        DataSet ds_D_BK = new DataSet();
                        //Leadron.WebReference.Class_Table[] tabs = new Leadron.WebReference.Class_Table[2];
                        string[] Sqls = new string[3];
                       

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            Sqls[1] = "select tip.sick_area_name from t_quality_record tqr inner join t_in_patient tip on tqr.pid=tip.pid where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " order by tip.sick_bed_id,tqr.noteztime asc";
                            ds_N_ZK = App.GetDataSet(Sqls[1]);
                        }
                        else
                        {

                            Sqls[1] = "select tip.sick_area_name from t_quality_record tqr inner join t_in_patient tip on tqr.pid=tip.pid where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Section_Id + " order by tip.sick_bed_id,tqr.noteztime asc";
                            ds_D_ZK = App.GetDataSet(Sqls[1]);
                            
                            Sqls[0] = "select a.id 序号" +
                                    " from t_consultaion_apply a " +                                   
                                    " where a.consul_record_section_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.submited='Y' and consul_record_submite_state=0";
                            ds_D_HZ = App.GetDataSet(Sqls[0]);
                            ds_D_BK = App.GetDataSet("select id from t_fecter_report_card t where t.state=2 and t.sid="+App.UserAccount.CurrentSelectRole.Section_Id+"");
                        }                      
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            /*
                             * 会诊
                             */                            
                            if (ds_D_HZ.Tables[0].Rows.Count > 0)
                            {
                                Huizhenflag = true;
                            }
                            else
                            {
                                Huizhenflag = false;
                            }                            

                            /*
                             * 医生质控
                             */                           
                            if (ds_D_ZK.Tables[0].Rows.Count > 0)
                            {
                                ZhiKongflag = true;
                            }
                            else
                            {
                                ZhiKongflag = false;
                            }

                            /*
                             *报卡提醒 
                             */
                            if (ds_D_BK.Tables[0].Rows.Count > 0)
                            {
                                Bkglflag = true;
                            }
                            else
                            {
                                Bkglflag = false;
                            }
                            
                        }
                        else
                        {
                            /*
                             * 护士质控
                             */                           
                            if (ds_N_ZK.Tables[0].Rows.Count > 0)
                            {
                                ZhiKongflag = true;
                            }
                            else
                            {
                                ZhiKongflag = false;
                            }                           
                        }
                       
                    }
                    catch
                    { }
                    Thread.Sleep(120000);
                }
                while (true);           
        }

        private void toolHuizhen_Click(object sender, EventArgs e)
        {
            //System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Inhospital_Info.dll");
            //Type tmpType = assmble.GetType("Inhospital_Info.dll." + );
            //System.Reflection.MethodInfo tmpM = tmpType.GetMethod(tempPermission.Permission_Info.Function.Split('.')[1]);
            //object tmpobj = assmble.CreateInstance(assmble.ManifestModule.Name.Split('.')[0] + "." + tempPermission.Permission_Info.Function.Split('.')[0]);
            //string opstr = assmble.ManifestModule.Name.Split('.')[0] + "." + tempPermission.Permission_Info.Function;
            //if (!checkchildFrmExist(opstr))
            //{
            //    //打开新窗体  
            //    tmpM.Invoke(tmpobj, null);
            //    opstr = opstr + ";" + Application.OpenForms[Application.OpenForms.Count - 1].GetType().ToString();//记录打开窗体的步骤（dll名+函数名+窗体类型）
            //    Openforms.Add(opstr);
            //}
            //else//打开已经有的窗体
            //{

            //    string frmtype = Getfrmtype(opstr);
            //    bool flag = false;
            //    for (int i = 0; i < Application.OpenForms.Count; i++)
            //    {
            //        if (Application.OpenForms[i].GetType().ToString() == frmtype)
            //        {
            //            Application.OpenForms[i].Activate();
            //            Application.OpenForms[i].WindowState = FormWindowState.Maximized;
            //            flag = true;
            //            return;
            //        }
            //    }
            //    if (!flag)
            //    {
            //        tmpM.Invoke(tmpobj, null);
            //    }
            //}  
            try
            {
                App.A_HZTX(sender, e);               
            }
            catch
            {
                App.MsgWaring("该按钮参数未设置或功能尚未启用！");
                App.A_HZTX = null;
            }
            
        }

        private void MDIParent1_Activated(object sender, EventArgs e)
        {             
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {           
        }

        private void tabOpenForms_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                if (tabOpenForms.SelectedTab != null)
                {
                    //for (int i = 0; i < tabOpenForms.Tabs.Count; i++)
                    //{
                    //    if (tabOpenForms.Tabs[i] != tabOpenForms.SelectedTab)
                    //    {
                    //        Form notemp = (Form)tabOpenForms.SelectedTab.AttachedControl;
                    //        notemp.WindowState = FormWindowState.Minimized;
                            
                    //    }
                    //}

                    Form temp = (Form)tabOpenForms.SelectedTab.AttachedControl;
                    //temp.Width = temp.Width - 1;
                    temp.WindowState = FormWindowState.Maximized;
                    temp.Show();
                }
            }
            catch
            { }
        }

        private void tabOpenForms_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            for (int i = 0; i < App.Openforms.Count; i++)
            {
                if (App.Openforms[i].ToString().Contains(tabOpenForms.SelectedTab.AttachedControl.GetType().ToString()))
                {
                    App.Openforms.RemoveAt(i);
                    break;
                }
            }
            tabOpenForms.Tabs.Remove(tabOpenForms.SelectedTab);           
        }

        private void toolZhikong_Click(object sender, EventArgs e)
        {
            frmQuitlyNotice f = new frmQuitlyNotice();
            App.FormStytleSet(f, false);
            f.ShowDialog();
        }

        private void MDIParent1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void MenuBar_DoubleClick(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// 诊疗规范
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnZLGF_Click(object sender, EventArgs e)
        {
            frmZLGF fc = new frmZLGF();            
            fc.Show();
        }

        /// <summary>
        /// 值班设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnDutySet_Click(object sender, EventArgs e)
        {
            Bifrost.SYSTEMSET.frmDutyDoctorSet fc = new Bifrost.SYSTEMSET.frmDutyDoctorSet();
            App.ButtonStytle(fc, false);
            fc.ShowDialog();
        }

        private void MDIParent1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.Refresh();
        }


        /// <summary>
        /// 时时上传文书图片
        /// </summary>
        private static void UploadDocfiles()
        {
            while (1 != 0)
            {
                try
                {
                    string pth = App.SysPath + "\\temp";
                    DirectoryInfo Dir = new DirectoryInfo(pth);
                    foreach (FileInfo tfile in Dir.GetFiles())
                    {
                        if (App.UpLoadFtp(pth + "\\" + tfile.ToString(), tfile.ToString(), "D", tfile.ToString().Split('_')[0]))
                        {
                            File.Delete(pth + "\\" + tfile.ToString());
                        }

                    }
                    
                }
                catch
                { }

                Thread.Sleep(300000);
            }
        }

        /// <summary>
        /// 系统帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnHelp_Click(object sender, EventArgs e)
        {
            frmHelp fc = new frmHelp();
            fc.Show();
        }

        /// <summary>
        /// 注销帐号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnAccountClear_Click(object sender, EventArgs e)
        {
            #region

            if (App.Ask("注销帐号之后，当前帐号就无法登录当前系统，确定要注销吗？"))
            {
                string result = "";              
                if (App.UserAccount.Kind == 53 || App.UserAccount.Kind == 54 || App.UserAccount.Kind == 7921)
                {
                    //实习生、研究生、进修生
                    result = "";
                }
                else if (App.UserAccount.Kind == 52)
                {
                   
                     //正式
                    DataSet ds_docs = App.GetDataSet("select t.tid,t3.patient_name,t3.pid,t2.textname,t.doc_name,t.havedoctorsign from t_patients_doc t inner join t_text t2 on t.textkind_id=t2.id inner join t_in_patient t3 on t.patient_id=t3.id where t.createid=" + App.UserAccount.UserInfo.User_id + "");
                    if (ds_docs != null)
                    {
                        if (ds_docs.Tables[0].Rows.Count > 0)
                        {                            
                            for (int i = 0; i < ds_docs.Tables[0].Rows.Count; i++)
                            {
                                if (ds_docs.Tables[0].Rows[i]["havedoctorsign"].ToString() != "Y")
                                {
                                    
                                    string strtemp="病人姓名："+ds_docs.Tables[0].Rows[i]["patient_name"].ToString()+",住院号："+ds_docs.Tables[0].Rows[i]["pid"].ToString()+",文书类型："+ds_docs.Tables[0].Rows[i]["textname"].ToString()+",文书名称："+ds_docs.Tables[0].Rows[i]["doc_name"].ToString();
                                    if (result == "")
                                    {
                                        result = "你还有一些文书没有签名：\n";
                                        result = result + strtemp;

                                    }
                                    else
                                    {
                                        result = result + "\n" + strtemp;
                                    }                                   
                                }
                            }                          
                        }
                    }
                }

                if (result == "")
                {
                    

                    ////注销操作
                    //string[] sqls = new string[2];
                    //sqls[0] = "delete from t_acc_role_range a where a.acc_role_id in (select b.id from t_acc_role b where b.account_id=" + App.UserAccount.Account_id + ")";
                    //sqls[1] = "delete from t_acc_role c where c.account_id=" + App.UserAccount.Account_id + "";

                    //if (App.ExecuteBatch(sqls) > 0)
                    //{
                    //    App.Msg("帐号注销成功！");
                    //    LogHelper.Account_SystemLog(App.UserAccount.Account_id, "注销", "");
                    //    isReset = true;
                    //    Application.Restart();
                    //} 

                    frmPassWordConfirmDel fc = new frmPassWordConfirmDel();
                    fc.ShowDialog();
                }
                else
                {
                    App.MsgWaring(result);
                }
            }
            #endregion
        }
        /// <summary>
        /// 科主任帐号信息维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSectionAccountSets_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("主任") && 
                App.UserAccount.CurrentSelectRole.Rnages.Length>0)
            {
                frmUserInfoAccountSet1 AccountSet = new frmUserInfoAccountSet1();
                App.FormStytleSet(AccountSet, false);
                AccountSet.ShowDialog();
            }
            else
            {
                App.MsgWaring("该功能只有科主任才能使用！");
            }
        }

        private void 系统的一些参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Msg("当前连接的应用服务器是:"+App.remotingIp);
        }

        ///// <summary>
        ///// 检测Key盘
        ///// </summary>
        //private static void CheckUK()
        //{
        //    while (1 != 0)
        //    {
        //        try
        //        {
        //            App.strUserName = App.getUserList1(bjcaSec.GetUserList()); //获取用户信息
        //            App.strRandom = App.Web_GenRandom(24);                         //生成随机数
        //            App.strServerSignValue = App.Web_SignData(App.strRandom);          //对数据进行签名
        //            App.strServerCert = App.Web_GetServerCertificate();
        //        }
        //        catch
        //        {
        //            App.strUserName = "";
        //            App.strRandom = "";                       //生成随机数
        //            App.strServerSignValue = "";              //对数据进行签名
        //            App.strServerCert = "";
        //            App.userId = "";
        //        }
        //    }
        //}


        //#region 客户端部分
        ///// <summary>
        ///// 初始化获取Key信息
        ///// </summary>
        ///// <returns></returns>
        //public static string CL_KeyName()
        //{
        //    string keyName = App.getUserList1(bjcaSec.GetUserList());
        //    App.strRandom = App.Web_GenRandom(24);                         //生成随机数
        //    App.strServerSignValue = App.Web_SignData(App.strRandom);          //对数据进行签名
        //    App.strServerCert = App.Web_GetServerCertificate();            //获取服务器证书   
        //    return keyName;
        //}

        ///// <summary>
        ///// Key盘登录 0登录成功 1登录不成功
        ///// </summary>
        ///// <param name="PassWord">密码</param>
        ///// <returns></returns>
        //public static int CL_UserLogin(string PassWord)
        //{
        //    return bjcaSec.UserLogin(App.strContainerName, PassWord);
        //}

        ///// <summary>
        ///// 客户端 签名验证 0成功 1不成功
        ///// </summary>
        ///// <param name="strservercert"></param>
        ///// <param name="strrandom"></param>
        ///// <param name="strserversignvalue"></param>
        ///// <returns></returns>
        //public static int CL_VerifySignedData(string strservercert, string strrandom, string strserversignvalue)
        //{
        //    return bjcaSec.VerifySignedData(App.strServerCert, App.strRandom, App.strServerSignValue);
        //}

        ///// <summary>
        ///// 客户端签名
        ///// </summary>
        ///// <param name="strcontainername"></param>
        ///// <param name="strrandom"></param>
        ///// <returns></returns>
        //public static string CL_SignData(string strcontainername, string strrandom)
        //{
        //    return bjcaSec.SignData(strcontainername, strrandom);
        //}

        ///// <summary>
        ///// 获取用户证书
        ///// </summary>
        ///// <returns></returns>
        //public static string CL_ExportUserCert()
        //{
        //    return bjcaSec.ExportUserCert(App.strContainerName);
        //}

        ///// <summary>
        ///// 校验证书的有效性
        ///// </summary>
        ///// <returns></returns>
        //public static int CL_ValidateCert()
        //{
        //    return bjcaSec.ValidateCert(App.strClientsignCert);
        //}


        ///// <summary>
        ///// 获取证书的各项值
        ///// </summary>
        ///// <param name="strclientsigncert"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string CL_GetCertInfo(string strclientsigncert, short type)
        //{
        //    return bjcaSec.GetCertInfo(strclientsigncert, type);
        //}

        /////// <summary>
        /////// 判断是否证书过期
        /////// </summary>
        /////// <returns></returns>
        ////public static string CL_IsOutOverTime()
        ////{
        ////    DateTime dt1 = new DateTime();
        ////    dt1 = DateTime.Now;
        ////    DateTime dt2 = Convert.ToDateTime(bjcaSec.GetCertInfo(strClientsignCert, 12));
        ////    TimeSpan dsddd = dt2 - dt1;
        ////    double k = dsddd.TotalDays;
        ////    if (k <= 30)
        ////    {
        ////        MessageBox.Show("还有" + k + "天证书过期，请联系管理员更新证书。");
        ////    }
        ////    else if (k < 0)
        ////    {
        ////        MessageBox.Show("证书过期不可再用，请立即联系管理员更新！");
        ////    }
        ////}

        //#endregion
       
    }
}
