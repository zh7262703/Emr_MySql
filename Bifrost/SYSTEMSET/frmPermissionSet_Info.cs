using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Bifrost;
using DataOperater.Model;
using MySql.Data.MySqlClient;

namespace Bifrost
{

    /// <summary>
    /// 权限设置
    /// 创建者：张华
    /// 创建时间：2010-10-15
    /// </summary>
    public partial class frmPermissionSet_Info : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 1菜单 2按钮 3页签
        /// </summary>
        private int Type = 1;

        /// <summary>
        /// 菜单代码
        /// </summary>
        private string MenuCode = "";

       

        /// <summary>
        /// 当前选中的菜单信息
        /// </summary>
        private Class_Permission CurrentPermission = null;

        /// <summary>
        /// 图形字节流
        /// </summary>
        private byte[] ImageBytes; 

        /// <summary>
        /// 动态连接库的字节流
        /// </summary>
        private byte[] DllBytes;   


        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPermissionSet_Info()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="Code">代码</param>
        /// <param name="perssion">权限实体</param>
        public frmPermissionSet_Info(int type,string Code,Class_Permission perssion)
        {
            InitializeComponent();
            Type = type;
            MenuCode = Code;
            App.ButtonStytle(this,false);
            CurrentPermission = perssion;            
        }

        private void frmPermissionSet_Info_Load(object sender, EventArgs e)
        {
            //tabControl2.Tabs.Clear();
            if (Type == 1)
            {
                tabItem1.Visible = true;            
                tabItem2.Visible = false;
                tabItem3.Visible = false;
                cboKindMenu.SelectedIndex = 0;
                this.txtMenuCode.Text = MenuCode;
            }
            else if (Type == 2)
            {
                tabItem1.Visible = false;
                tabItem2.Visible = true;
                tabItem3.Visible = false;
                cboKindButton.SelectedIndex = 1;
            }
            else
            {
                tabItem1.Visible = false;
                tabItem2.Visible = false;
                tabItem3.Visible = true;
                cboKindTab.SelectedIndex = 2;
                this.txtTabCode.Text = MenuCode;
            }


            if (CurrentPermission != null)
            {
                Iniform();
            }
        }

        /// <summary>
        /// 初始化当前操作的菜单或按钮对象
        /// </summary>
        /// <returns></returns>
        private Class_Permission IniCurrentPermission(int permission_id,int perssioninfo_id,int kind)
        {
            Class_Permission temp = new Class_Permission();
            if (perssioninfo_id != 0)
            {
                
                temp.Id = permission_id.ToString();
                temp.Perm_code = txtMenuCode.Text;
                temp.Perm_name = txtMenuName.Text;
                temp.Perm_kind = kind.ToString();
                if (kind == 1)
                {
                    temp.Permission_Info = new Class_Permission_Info();
                    temp.Permission_Info.Id = perssioninfo_id;
                    temp.Permission_Info.DllName = txtDllName.Text;
                    temp.Permission_Info.Function = txtFunctinName.Text;
                    temp.Permission_Info.Perm_code = txtMenuCode.Text;
                    temp.Permission_Info.Version = txtVersion.Text;
                }
                else if (kind==3)
                {
                    temp.Permission_Info = new Class_Permission_Info();
                    temp.Permission_Info.Id = perssioninfo_id;
                    temp.Permission_Info.Function = txtFunctinName.Text;
                    temp.Permission_Info.Perm_code = txtMenuCode.Text;
                   
                }
            }
            else
            {
                temp.Id = permission_id.ToString();
                temp.Perm_code = txtButtonCode.Text;
                temp.Perm_name = txtButtonName.Text;
                temp.Perm_kind = "2";
            }
           

            return temp;
        }

        /// <summary>
        /// 初始化窗体参数，修改操作时使用
        /// </summary>       
        private void Iniform()
        {
            if (CurrentPermission != null)
            {
                if (Type == 1)
                {
                    txtMenuCode.Text = CurrentPermission.Perm_code;
                    txtMenuName.Text = CurrentPermission.Perm_name;
                    txtDllName.Text = CurrentPermission.Permission_Info.DllName;
                    txtFunctinName.Text = CurrentPermission.Permission_Info.Function;
                    cboKindMenu.SelectedIndex = 0;
                    txtVersion.Text = CurrentPermission.Permission_Info.Version;
                    if (CurrentPermission.Permission_Info.Dll != null)
                    {
                        if (CurrentPermission.Permission_Info.Dll.Length > 1)
                        {
                            DllBytes = CurrentPermission.Permission_Info.Dll;
                        }
                    }
                    if (CurrentPermission.Permission_Info.FunctionImage != null)
                    {
                        if (CurrentPermission.Permission_Info.FunctionImage.Length > 1)
                        {
                            ImageBytes = CurrentPermission.Permission_Info.FunctionImage;
                            picIcon.Image = App.ByteToImg(ImageBytes);
                        }
                    }
                }
                else if (Type == 2)
                {
                    txtButtonCode.Text = CurrentPermission.Perm_code;
                    txtButtonName.Text = CurrentPermission.Perm_name;
                    cboKindButton.SelectedIndex = 1;
                }
                else
                {
                    txtTabCode.Text = CurrentPermission.Perm_code;
                    txtTabName.Text = CurrentPermission.Perm_name;
                    txtTabModelName.Text = CurrentPermission.Permission_Info.Function;
                }
            }
        }

        /// <summary>
        /// dll功能模块的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFunctionFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FunctionDialog = new OpenFileDialog();
            FunctionDialog.Filter = "dll files (*.dll)|*.dll";
            if (FunctionDialog.ShowDialog() == DialogResult.OK)
            {
                DllBytes = App.ReadBinFile(FunctionDialog.FileName);
                txtDllpath.Text = FunctionDialog.FileName;
                txtDllName.Text = txtDllpath.Text.Split('\\')[txtDllpath.Text.Split('\\').Length - 1];
            }
        }

        /// <summary>
        /// 图标路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenImageFile_Click(object sender, EventArgs e)
        {
             OpenFileDialog ImageDialog = new OpenFileDialog();
             ImageDialog.Filter = "ico files (*.ICO)|*.ICO|jpg files (*.jpg)|*.jpg|bmp file(*.bmp)|*.bmp";
             if (ImageDialog.ShowDialog() == DialogResult.OK)
             {
                 ImageBytes=App.ReadBinFile(ImageDialog.FileName);
                 txtInocPath.Text = ImageDialog.FileName;
                 picIcon.Image = App.ByteToImg(ImageBytes);
             }
        }

        /// <summary>
        /// 保存菜单的信息。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            int num;
            MySqlDBParameter[] parameterArray;
            string str;
            Exception exception;
            if (this.Type == 1)
            {
                if (this.txtMenuCode.Text.Trim() == "")
                {
                    App.MsgErr("菜单代码为必填项!");
                    return;
                }
                if (this.txtMenuName.Text.Trim() == "")
                {
                    App.MsgErr("菜单代码为必填项!");
                    return;
                }
                if ((this.txtVersion.Text.Trim() != "") && !App.isNumval(this.txtVersion.Text))
                {
                    App.MsgErr("版本号要求数值类型!");
                    return;
                }
                if (this.txtDllpath.Text.Trim() != "")
                {
                    if (!File.Exists(this.txtDllpath.Text))
                    {
                        App.MsgErr("dll文件的路径不存在!");
                        return;
                    }
                }
                else if (this.CurrentPermission == null)
                {
                    this.DllBytes = null;
                }
                if (this.txtInocPath.Text != "")
                {
                    if (!File.Exists(this.txtInocPath.Text))
                    {
                        App.MsgErr("图标路径的路径不存在!");
                        return;
                    }
                }
                else if (this.CurrentPermission == null)
                {
                    this.ImageBytes = null;
                }
                try
                {
                    byte[] buffer;
                    num = App.GenId("T_PERMISSION", "id");
                    if (this.CurrentPermission != null)
                    {
                        num = Convert.ToInt32(this.CurrentPermission.Id);
                    }
                    parameterArray = new MySqlDBParameter[5];
                    parameterArray[0] = new MySqlDBParameter();
                    parameterArray[0].ParameterName = "VID";
                    parameterArray[0].DBType = MySqlDbType.Decimal;
                    parameterArray[0].Value = num;
                    parameterArray[1] = new MySqlDBParameter();
                    parameterArray[1].ParameterName = "VPERM_CODE";
                    parameterArray[1].DBType = MySqlDbType.VarChar;
                    parameterArray[1].Value = this.txtMenuCode.Text;
                    parameterArray[2] = new MySqlDBParameter();
                    parameterArray[2].ParameterName = "PERM_NAME";
                    parameterArray[2].DBType = MySqlDbType.VarChar;
                    parameterArray[2].Value = this.txtMenuName.Text;
                    parameterArray[3] = new MySqlDBParameter();
                    parameterArray[3].ParameterName = "PERM_KIND";
                    parameterArray[3].DBType = MySqlDbType.VarChar;
                    parameterArray[3].Value = "1";
                    parameterArray[4] = new MySqlDBParameter();
                    parameterArray[4].ParameterName = "NUM";
                    parameterArray[4].DBType = MySqlDbType.Decimal;
                    parameterArray[4].Value = num;
                    int id = App.GenId("T_PERMISSION_FUCTIONS", "id");
                    if (this.CurrentPermission != null)
                    {
                        id = this.CurrentPermission.Permission_Info.Id;
                    }
                    MySqlDBParameter[] parameters = new MySqlDBParameter[6];
                    parameters[0] = new MySqlDBParameter();
                    parameters[0].ParameterName = "VID";
                    parameters[0].DBType = MySqlDbType.Decimal;
                    parameters[0].Value = id;
                    
                    parameters[1] = new MySqlDBParameter();
                    parameters[1].ParameterName = "VPERM_CODE";
                    parameters[1].DBType = MySqlDbType.VarChar;
                    parameters[1].Value = this.txtMenuCode.Text;
                    
                    parameters[2] = new MySqlDBParameter();
                    parameters[2].ParameterName = "FUNCTION";
                    parameters[2].DBType = MySqlDbType.VarChar;
                   
                    parameters[2].Value = this.txtFunctinName.Text;
                    parameters[3] = new MySqlDBParameter();
                    parameters[3].ParameterName = "VERSION";
                    parameters[3].DBType = MySqlDbType.VarChar;
                  
                    parameters[3].Value = this.txtVersion.Text;
                    parameters[4] = new MySqlDBParameter();
                    parameters[4].ParameterName = "DLLNAME";
                    parameters[4].DBType = MySqlDbType.VarChar;
                   
                    parameters[4].Value = this.txtDllName.Text;
                    parameters[5] = new MySqlDBParameter();
                    parameters[5].ParameterName = "FUNCTIONIMAGE";
                    parameters[5].DBType = MySqlDbType.Blob;
                  
                    if (this.ImageBytes != null)
                    {
                        parameters[5].Value = this.ImageBytes;
                    }
                    else
                    {
                        buffer = new byte[] { 0 };
                        parameters[5].Value = buffer;
                    }
                    str = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND,NUM)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND,:NUM)";
                    string cmdString = "insert into T_PERMISSION_FUCTIONS(id,PERM_CODE,FUNCTION,VERSION,DLLNAME,FUNCTIONIMAGE)values(:VID,:VPERM_CODE,:FUNCTION,:VERSION,:DLLNAME,:FUNCTIONIMAGE)";
                    if (this.CurrentPermission != null)
                    {
                        str = "update T_PERMISSION set PERM_CODE=:VPERM_CODE,PERM_NAME=:PERM_NAME,PERM_KIND=:PERM_KIND,NUM=:NUM where id=:VID";
                        cmdString = "update T_PERMISSION_FUCTIONS set ID=:VID,PERM_CODE=:VPERM_CODE,FUNCTION=:FUNCTION,VERSION=:VERSION,DLLNAME=:DLLNAME,FUNCTIONIMAGE=:FUNCTIONIMAGE where PERM_CODE=:VPERM_CODE";
                    }

                    if (App.ExecuteSQL(str, parameterArray) > 0)
                    {
                        if (App.ExecuteSQL(cmdString, parameters) > 0)
                        {
                            App.Msg("操作已成功！");
                        }
                        else
                        {                            
                            App.MsgErr("操作失败！");
                        }
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }
                                        
                    
                    frmPermissionSet.CurrentPerssmion = this.IniCurrentPermission(num, id,1);                                       
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    App.MsgErr("操作失败，原因:" + exception.Message);
                    return;
                }
            }
            else if (this.Type == 2)
            {
                try
                {
                    if (this.txtButtonCode.Text.Trim() == "")
                    {
                        App.MsgErr("按钮代码为必填项!");
                        return;
                    }
                    if (this.txtButtonName.Text.Trim() == "")
                    {
                        App.MsgErr("按钮名称为必填项!");
                        return;
                    }
                    num = App.GenId("T_PERMISSION", "id");
                    if (this.CurrentPermission != null)
                    {
                        num = Convert.ToInt32(this.CurrentPermission.Id);
                    }
                    parameterArray = new MySqlDBParameter[5];
                    parameterArray[0] = new MySqlDBParameter();
                    parameterArray[0].ParameterName = "VID";
                    parameterArray[0].DBType = MySqlDbType.Decimal;
                    parameterArray[0].Value = num;
                    parameterArray[1] = new MySqlDBParameter();
                    parameterArray[1].ParameterName = "VPERM_CODE";
                    parameterArray[1].DBType = MySqlDbType.VarChar;
                    parameterArray[1].Value = this.txtButtonCode.Text;
                    parameterArray[2] = new MySqlDBParameter();
                    parameterArray[2].ParameterName = "PERM_NAME";
                    parameterArray[2].DBType = MySqlDbType.VarChar;
                    parameterArray[2].Value = this.txtButtonName.Text;
                    parameterArray[3] = new MySqlDBParameter();
                    parameterArray[3].ParameterName = "PERM_KIND";
                    parameterArray[3].DBType = MySqlDbType.VarChar;
                    parameterArray[3].Value = "2";
                    parameterArray[4] = new MySqlDBParameter();
                    parameterArray[4].ParameterName = "NUM";
                    parameterArray[4].DBType = MySqlDbType.Decimal;
                    parameterArray[4].Value = num;
                    str = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND,NUM)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND,:NUM)";
                    if (this.CurrentPermission == null)
                    {
                        str = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND,NUM)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND,:NUM)";
                    }
                    else
                    {
                        str = "update T_PERMISSION set PERM_CODE=:VPERM_CODE,PERM_NAME=:PERM_NAME,PERM_KIND=:PERM_KIND,NUM=:NUM where id=:VID";
                    }
                    App.ExecuteSQL(str, parameterArray);
                    App.Msg("操作已成功！");
                    frmPermissionSet.CurrentPerssmion = this.IniCurrentPermission(num, 0,2);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    App.MsgErr("操作失败，原因:" + exception.Message);
                    return;
                }
            }
            else
            {
                //页签操作
                if (this.txtTabCode.Text.Trim() == "")
                {
                    App.MsgErr("页签代码为必填项!");
                    return;
                }
                if (this.txtTabName.Text.Trim() == "")
                {
                    App.MsgErr("页签名称为必填项!");
                    return;
                }
                if (this.txtTabModelName.Text.Trim() == "")
                {
                    App.MsgErr("模块为必填项!");
                    return;
                }

                try
                {
                    byte[] buffer;
                    num = App.GenId("T_PERMISSION", "id");
                    if (this.CurrentPermission != null)
                    {
                        num = Convert.ToInt32(this.CurrentPermission.Id);
                    }
                    parameterArray = new MySqlDBParameter[5];
                    parameterArray[0] = new MySqlDBParameter();
                    parameterArray[0].ParameterName = "VID";
                    parameterArray[0].DBType = MySqlDbType.Decimal;
                    parameterArray[0].Value = num;
                    parameterArray[1] = new MySqlDBParameter();
                    parameterArray[1].ParameterName = "VPERM_CODE";
                    parameterArray[1].DBType = MySqlDbType.VarChar;
                    parameterArray[1].Value = this.txtTabCode.Text;
                    parameterArray[2] = new MySqlDBParameter();
                    parameterArray[2].ParameterName = "PERM_NAME";
                    parameterArray[2].DBType = MySqlDbType.VarChar;
                    parameterArray[2].Value = this.txtTabName.Text;
                    parameterArray[3] = new MySqlDBParameter();
                    parameterArray[3].ParameterName = "PERM_KIND";
                    parameterArray[3].DBType = MySqlDbType.VarChar;
                    parameterArray[3].Value = "3";
                    parameterArray[4] = new MySqlDBParameter();
                    parameterArray[4].ParameterName = "NUM";
                    parameterArray[4].DBType = MySqlDbType.Decimal;
                    parameterArray[4].Value = num;
                    int id = App.GenId("T_PERMISSION_FUCTIONS", "id");
                    if (this.CurrentPermission != null)
                    {
                        id = this.CurrentPermission.Permission_Info.Id;
                    }
                    MySqlDBParameter[] parameters = new MySqlDBParameter[3];
                    parameters[0] = new MySqlDBParameter();
                    parameters[0].ParameterName = "VID";
                    parameters[0].DBType = MySqlDbType.Decimal;
                    parameters[0].Value = id;
                  
                    parameters[1] = new MySqlDBParameter();
                    parameters[1].ParameterName = "VPERM_CODE";
                    parameters[1].DBType = MySqlDbType.VarChar;
                    parameters[1].Value = this.txtTabCode.Text;
                 
                    parameters[2] = new MySqlDBParameter();
                    parameters[2].ParameterName = "FUNCTION";
                    parameters[2].DBType = MySqlDbType.VarChar;                   
                    parameters[2].Value = this.txtTabModelName.Text;
                  
                    str = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND,NUM)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND,:NUM)";
                    string cmdString = "insert into T_PERMISSION_FUCTIONS(id,PERM_CODE,FUNCTION)values(:VID,:VPERM_CODE,:FUNCTION)";
                    if (this.CurrentPermission != null)
                    {
                        str = "update T_PERMISSION set PERM_CODE=:VPERM_CODE,PERM_NAME=:PERM_NAME,PERM_KIND=:PERM_KIND,NUM=:NUM where id=:VID";
                        cmdString = "update T_PERMISSION_FUCTIONS set ID=:VID,PERM_CODE=:VPERM_CODE,FUNCTION=:FUNCTION where PERM_CODE=:VPERM_CODE";
                    }

                    if (App.ExecuteSQL(str, parameterArray) > 0)
                    {
                        if (App.ExecuteSQL(cmdString, parameters) > 0)
                        {
                            App.Msg("操作已成功！");
                        }
                        else
                        {
                            App.MsgErr("操作失败！");
                        }
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }


                    frmPermissionSet.CurrentPerssmion = this.IniCurrentPermission(num, id,3);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    App.MsgErr("操作失败，原因:" + exception.Message);
                    return;
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}