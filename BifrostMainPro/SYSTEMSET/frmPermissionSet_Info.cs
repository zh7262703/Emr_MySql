using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Leadron;

namespace LeadronTest.SYSTEMSET
{
    public partial class frmPermissionSet_Info : Form
    {
        private int Type = 1; //1菜单 2按钮
        private string MenuCode = "";
        private Class_Permission CurrentPermission = null;
        private byte[] ImageBytes; //图形字节流
        private byte[] DllBytes;   //动态连接库的字节流

        public frmPermissionSet_Info()
        {
            InitializeComponent();            
        }

        public frmPermissionSet_Info(int type,string Code,Class_Permission perssion)
        {
            InitializeComponent();
            Type = type;
            MenuCode = Code;
            App.ButtonStytle(this);
            CurrentPermission = perssion;            
        }

        private void frmPermissionSet_Info_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            if (Type == 1)
            {
                tabControl1.TabPages.Add(tabPage1);
                cboKindMenu.SelectedIndex = 0;
                this.txtMenuCode.Text = MenuCode;
            }
            else
            {
                tabControl1.TabPages.Add(tabPage2); 
                cboKindButton.SelectedIndex = 1;
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
        private Class_Permission IniCurrentPermission(int permission_id,int perssioninfo_id)
        {
            Class_Permission temp = new Class_Permission();
            if (perssioninfo_id != 0)
            {
                temp.Id = permission_id.ToString();
                temp.Perm_code = txtMenuCode.Text;
                temp.Perm_name = txtMenuName.Text;
                temp.Perm_kind = "1";
                temp.Permission_Info = new Class_Permission_Info();
                temp.Permission_Info.DllName = txtDllName.Text;
                temp.Permission_Info.Function = txtFunctinName.Text;               
                temp.Permission_Info.Perm_code = txtMenuCode.Text;
                temp.Permission_Info.Version = txtVersion.Text;
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
                else
                {
                    txtButtonCode.Text = CurrentPermission.Perm_code;
                    txtButtonName.Text = CurrentPermission.Perm_name;
                    cboKindButton.SelectedIndex = 1;
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

        private void btnSure_Click(object sender, EventArgs e)
        {            
            if (Type == 1) 
            {
                if(txtMenuCode.Text.Trim()=="")
                {
                    App.MsgErr("菜单代码为必填项!");
                    return;
                }

                if (txtMenuName.Text.Trim()=="")
                {
                    App.MsgErr("菜单代码为必填项!");
                    return;
                }

                if (txtVersion.Text.Trim() != "")
                {
                    if (!App.isNumval(txtVersion.Text))
                    {
                        App.MsgErr("版本号要求数值类型!");
                        return;
                    }
                }
               

                if (txtDllpath.Text.Trim() != "")
                {
                    if (!File.Exists(txtDllpath.Text))
                    {
                        App.MsgErr("dll文件的路径不存在!");
                        return;
                    }
                }
                else
                {
                    DllBytes = null;
                }

                if (txtInocPath.Text != "")
                {
                    if (!File.Exists(txtInocPath.Text))
                    {
                        App.MsgErr("图标路径的路径不存在!");
                        return;
                    }
                }
                else
                {
                    ImageBytes = null;
                }
                
                //菜单类型的保存
                try
                {                    

                    //基本信息
                    int Perssion_id = App.GenId("T_PERMISSION", "id");
                    if (CurrentPermission != null)
                    {
                        Perssion_id = Convert.ToInt32(CurrentPermission.Id);
                    }
                    Leadron.WebReference.OracleParameter[] PerParameters = new Leadron.WebReference.OracleParameter[5];
                    PerParameters[0] = new Leadron.WebReference.OracleParameter();
                    PerParameters[0].ParameterName = "VID";
                    PerParameters[0].OracleType = Leadron.WebReference.OracleType.Number;
                    PerParameters[0].Value = Perssion_id;

                    PerParameters[1] = new Leadron.WebReference.OracleParameter();
                    PerParameters[1].ParameterName = "VPERM_CODE";
                    PerParameters[1].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameters[1].Value = txtMenuCode.Text;

                    PerParameters[2] = new Leadron.WebReference.OracleParameter();
                    PerParameters[2].ParameterName = "PERM_NAME";
                    PerParameters[2].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameters[2].Value = txtMenuName.Text;

                    PerParameters[3] = new Leadron.WebReference.OracleParameter();
                    PerParameters[3].ParameterName = "PERM_KIND";
                    PerParameters[3].OracleType = Leadron.WebReference.OracleType.Char;
                    PerParameters[3].Value = "1";

                    PerParameters[4] = new Leadron.WebReference.OracleParameter();
                    PerParameters[4].ParameterName = "NUM";
                    PerParameters[4].OracleType = Leadron.WebReference.OracleType.Number;
                    PerParameters[4].Value = Perssion_id;

                    //详细信息
                    int PerssionInfo_id=App.GenId("T_PERMISSION_FUCTIONS", "id");
                    if (CurrentPermission != null)
                    {
                        PerssionInfo_id = CurrentPermission.Permission_Info.Id;
                    }
                    Leadron.WebReference.OracleParameter[] PerParameter2s = new Leadron.WebReference.OracleParameter[7];
                    PerParameter2s[0] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[0].ParameterName = "VID";
                    PerParameter2s[0].OracleType = Leadron.WebReference.OracleType.Number;
                    PerParameter2s[0].Value = PerssionInfo_id;
                    PerParameter2s[0].IsNullable = true;

                    PerParameter2s[1] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[1].ParameterName = "VPERM_CODE";
                    PerParameter2s[1].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameter2s[1].Value = txtMenuCode.Text;
                    PerParameter2s[1].IsNullable = true;

                    PerParameter2s[2] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[2].ParameterName = "PERM_DLL";
                    PerParameter2s[2].OracleType = Leadron.WebReference.OracleType.Blob;
                    PerParameter2s[2].IsNullable = true;
                    if (DllBytes != null)
                        PerParameter2s[2].Value = DllBytes;
                    else
                    {
                        byte[] temp = new byte[1];
                        temp[0] = 0;
                        PerParameter2s[2].Value = temp;
                    }
                   
                    PerParameter2s[3] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[3].ParameterName = "FUNCTION";
                    PerParameter2s[3].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameter2s[3].IsNullable = true;              
                    PerParameter2s[3].Value = txtFunctinName.Text;                  

                    PerParameter2s[4] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[4].ParameterName = "VERSION";
                    PerParameter2s[4].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameter2s[4].IsNullable = true;                    
                    PerParameter2s[4].Value = txtVersion.Text;                  
                    
                    PerParameter2s[5] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[5].ParameterName = "DLLNAME";
                    PerParameter2s[5].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameter2s[5].IsNullable = true;                   
                    PerParameter2s[5].Value = txtDllName.Text;                   

                    PerParameter2s[6] = new Leadron.WebReference.OracleParameter();
                    PerParameter2s[6].ParameterName = "FUNCTIONIMAGE";
                    PerParameter2s[6].OracleType = Leadron.WebReference.OracleType.Blob;
                    PerParameter2s[6].IsNullable = true;
                    if (ImageBytes != null)
                        PerParameter2s[6].Value = ImageBytes;
                    else
                    {
                        byte[] temp = new byte[1];
                        temp[0] = 0;
                        PerParameter2s[6].Value = temp;
                    }
                   
                    string SQL1 = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND,NUM)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND,:NUM)";
                    string SQL2 = "insert into T_PERMISSION_FUCTIONS(id,PERM_CODE,PERM_DLL,FUNCTION,VERSION,DLLNAME,FUNCTIONIMAGE)values(:VID,:VPERM_CODE,:PERM_DLL,:FUNCTION,:VERSION,:DLLNAME,:FUNCTIONIMAGE)";                                           
                    if (CurrentPermission != null)
                    {
                        SQL1 = "update T_PERMISSION set PERM_CODE=:VPERM_CODE,PERM_NAME=:PERM_NAME,PERM_KIND=:PERM_KIND,NUM=:NUM where id=:VID";
                        SQL2 = "update T_PERMISSION_FUCTIONS set ID=:VID,PERM_CODE=:VPERM_CODE,PERM_DLL=:PERM_DLL,FUNCTION=:FUNCTION,VERSION=:VERSION,DLLNAME=:DLLNAME,FUNCTIONIMAGE=:FUNCTIONIMAGE where PERM_CODE=:VPERM_CODE";                                                                    
                    }
                    App.ExecuteSQL(SQL1, PerParameters);
                    App.ExecuteSQL(SQL2, PerParameter2s);
                    App.Msg("操作已成功！");
                    frmPermissionSet.CurrentPerssmion = IniCurrentPermission(Perssion_id, PerssionInfo_id);
                   
                }
                catch(Exception ex)
                {
                    App.MsgErr("操作失败，原因:"+ex.Message);
                    return;
                }

            }
            else
            {
                //按钮类型的保存
                //基本信息
                try
                {
                    int Perssion_id=App.GenId("T_PERMISSION", "id");
                    if (CurrentPermission != null)
                    {
                        Perssion_id = Convert.ToInt32(CurrentPermission.Id);
                    }
                    Leadron.WebReference.OracleParameter[] PerParameters = new Leadron.WebReference.OracleParameter[4];
                    PerParameters[0] = new Leadron.WebReference.OracleParameter();
                    PerParameters[0].ParameterName = "VID";
                    PerParameters[0].OracleType = Leadron.WebReference.OracleType.Number;
                    PerParameters[0].Value = Perssion_id;

                    PerParameters[1] = new Leadron.WebReference.OracleParameter();
                    PerParameters[1].ParameterName = "VPERM_CODE";
                    PerParameters[1].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameters[1].Value = txtButtonCode.Text;

                    PerParameters[2] = new Leadron.WebReference.OracleParameter();
                    PerParameters[2].ParameterName = "PERM_NAME";
                    PerParameters[2].OracleType = Leadron.WebReference.OracleType.VarChar;
                    PerParameters[2].Value = txtButtonName.Text;

                    PerParameters[3] = new Leadron.WebReference.OracleParameter();
                    PerParameters[3].ParameterName = "PERM_KIND";
                    PerParameters[3].OracleType = Leadron.WebReference.OracleType.Char;
                    PerParameters[3].Value = "2";

                    PerParameters[4] = new Leadron.WebReference.OracleParameter();
                    PerParameters[4].ParameterName = "NUM";
                    PerParameters[4].OracleType = Leadron.WebReference.OracleType.Number;
                    PerParameters[4].Value = Perssion_id;
                    string SQL1="insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND)";
                    if (CurrentPermission == null)
                    {
                        SQL1 = "insert into T_PERMISSION(id,PERM_CODE,PERM_NAME,PERM_KIND)values(:VID,:VPERM_CODE,:PERM_NAME,:PERM_KIND)";
                    }
                    else
                    {
                        SQL1 = "update T_PERMISSION PERM_CODE=:VPERM_CODE,PERM_NAME=:PERM_NAME,PERM_KIND=:PERM_KIND,NUM=:NUM where id=:VID";                        
                    }
                    App.ExecuteSQL(SQL1, PerParameters);
                    App.Msg("操作已成功！");
                    frmPermissionSet.CurrentPerssmion = IniCurrentPermission(Perssion_id, 0);
                }
                catch (Exception ex)
                {
                    App.MsgErr("操作失败，原因:" + ex.Message);
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