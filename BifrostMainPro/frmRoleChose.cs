using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace BifrostMainPro
{
    /// <summary>
    /// 角色选择
    /// 创建者：张华
    /// 创建时间：2009-12-10
    /// </summary>
    public partial class frmRoleChose : DevComponents.DotNetBar.Office2007Form
    {
        public frmRoleChose()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 当有时间约束的时候进行限制
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        private bool IsIntimeSpan(string roleid)
        {
            DataSet ds_time_span = App.GetDataSet("select * from T_USE_TIME_SPAN h where h.relation_id=" + roleid + "");
            if (ds_time_span.Tables[0].Rows.Count > 0)
            {
                //判断是否有时间有效期的设定
                DateTime starttime = Convert.ToDateTime(ds_time_span.Tables[0].Rows[0]["begin_time"].ToString());
                DateTime endttime = Convert.ToDateTime(ds_time_span.Tables[0].Rows[0]["end_time"].ToString());
                DateTime Systime = App.GetSystemTime();
                string c1 = ds_time_span.Tables[0].Rows[0]["begin_logic"].ToString();
                string c2 = ds_time_span.Tables[0].Rows[0]["end_logic"].ToString();
                if (starttime > endttime)
                {
                    endttime = endttime.AddDays(1);
                    //跨天    
                    if (c1 == "1")
                    {
                        if (Systime >= starttime)
                        {
                            if (c2 == "1")
                            {
                                if (Systime <= endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (Systime < endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (Systime > starttime)
                        {
                            if (c2 == "1")
                            {
                                if (Systime <= endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (Systime < endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //不跨天
                    //跨天    
                    if (c1 == "1")
                    {
                        if (Systime >= starttime)
                        {
                            if (c2 == "1")
                            {
                                if (Systime <= endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (Systime < endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (Systime > starttime)
                        {
                            if (c2 == "1")
                            {
                                if (Systime <= endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (Systime < endttime)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }                
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 选择角色
        /// </summary>
        private void RoleSelect()
        {
            try
            {
                if (lvRoles.SelectedItems[0] != null)
                {
                    //GListBoxItem tempItem = (GListBoxItem)lvRoles.SelectedItem;
                    Class_Role temp = (Class_Role)lvRoles.SelectedItems[0].Tag;

                    if (!IsIntimeSpan(temp.Role_id))
                    {
                        App.MsgWaring("该角色有使用时间的限制，当前已经超出有效时间范围！");
                        return;
                    }
                    App.UserAccount.CurrentSelectRole = temp;

                    if (lvRoles.SelectedItems[0].ToolTipText == "1" || lvRoles.SelectedItems[0].ToolTipText == "2")
                    {
                        App.CurrentHospitalId = 1;
                    }
                    else if (lvRoles.SelectedItems[0].ToolTipText == "201")
                    {
                        App.CurrentHospitalId = 201;
                    }

                    /*
                     * 获取当前角色所对应的权限
                     */
                    DataSet dsPerssions = App.GetDataSet("select * from T_PERMISSION where PERM_CODE in (select PERM_CODE from T_ROLE_PERMISSION where ROLE_ID=" + App.UserAccount.CurrentSelectRole.Role_id + ")");
                    App.UserAccount.CurrentSelectRole.Permissions = new Class_Permission[dsPerssions.Tables[0].Rows.Count];
                    for (int i = 0; i < dsPerssions.Tables[0].Rows.Count; i++)
                    {
                        App.UserAccount.CurrentSelectRole.Permissions[i] = new Class_Permission();
                        App.UserAccount.CurrentSelectRole.Permissions[i].Id = dsPerssions.Tables[0].Rows[i]["ID"].ToString();
                        App.UserAccount.CurrentSelectRole.Permissions[i].Perm_code = dsPerssions.Tables[0].Rows[i]["PERM_CODE"].ToString();
                        App.UserAccount.CurrentSelectRole.Permissions[i].Perm_name = dsPerssions.Tables[0].Rows[i]["PERM_NAME"].ToString();
                        App.UserAccount.CurrentSelectRole.Permissions[i].Perm_kind = dsPerssions.Tables[0].Rows[i]["PERM_KIND"].ToString();
                        App.UserAccount.CurrentSelectRole.Permissions[i].Num = dsPerssions.Tables[0].Rows[i]["NUM"].ToString();
                    }
                    this.Hide();
                    this.Close();
                }
               
            }
            catch(Exception ex)
            {
               
                App.MsgWaring("请先选择要操作的角色！");
            }
        }

        private void frmRoleChose_Load(object sender, EventArgs e)
        {
            if (App.UserAccount != null)
            {
                if (App.UserAccount.Roles.Length > 0)
                {
                    for (int i = 0; i < App.UserAccount.Roles.Length; i++)
                    {
                        if (App.UserAccount.Roles[i].Rnages.Length > 0)
                        {
                            for (int j = 0; j < App.UserAccount.Roles[i].Rnages.Length; j++)
                            {                                
                                ListViewItem tn = new ListViewItem();
                                Class_Role temprole = new Class_Role();
                                temprole.Role_id = App.UserAccount.Roles[i].Role_id;
                                temprole.Role_name = App.UserAccount.Roles[i].Role_name;
                                temprole.Permissions = App.UserAccount.Roles[i].Permissions;
                                temprole.Rnages = App.UserAccount.Roles[i].Rnages;
                                temprole.CanSelectRange = App.UserAccount.Roles[i].CanSelectRange;
                                temprole.Section_Id = App.UserAccount.Roles[i].Section_Id;
                                //temprole.Section_name = App.UserAccount.Roles[i].Section_name;
                                temprole.Sickarea_Id = App.UserAccount.Roles[i].Sickarea_Id;
                                //temprole.Sickarea_name = App.UserAccount.Roles[i].Sickarea_name;
                                temprole.Role_type = App.UserAccount.Roles[i].Role_type;
                                if (temprole.Rnages[j].Isbelonge == "0")
                                {
                                    temprole.Section_Id = temprole.Rnages[j].Section_id;
                                    temprole.Section_name = temprole.Rnages[j].Rnagename;
                                }
                                else
                                {
                                    temprole.Sickarea_Id = temprole.Rnages[j].Sickarea_id;
                                    temprole.Sickarea_name = temprole.Rnages[j].Rnagename;
                                }
                                temprole.Sub_hospital = temprole.Rnages[j].Shid;

                                tn.Tag = temprole;
                                tn.Text = temprole.Role_name + "--" + temprole.Rnages[j].Rnagename;
                                tn.ImageIndex = 0;
                                tn.ToolTipText = temprole.Rnages[j].Shid;                               
                                lvRoles.Items.Add(tn);
                            }
                        }
                        else
                        {
                                ListViewItem tn = new ListViewItem();
                                tn.Tag = App.UserAccount.Roles[i];
                                tn.Text = App.UserAccount.Roles[i].Role_name;
                                tn.ToolTipText = App.UserAccount.Roles[i].Sub_hospital;
                                tn.ImageIndex = 0;
                                lvRoles.Items.Add(tn);                            
                        }
                    }
                  
                }             
            }
            lvRoles.Select();
            if (lvRoles.Items.Count > 0)
            {
                lvRoles.Items[0].Selected = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (App.UserAccount.CurrentSelectRole==null)
            {
                Application.Exit();
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            App.ReleaseLockedDoc();
            lvRoles_DoubleClick(sender, e);
        }

        private void trvRoles_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void glistRoles_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void lvRoles_DoubleClick(object sender, EventArgs e)
        {            
            RoleSelect();
        }

        private void lvRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RoleSelect();
            }   
        }

        private void lvRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}