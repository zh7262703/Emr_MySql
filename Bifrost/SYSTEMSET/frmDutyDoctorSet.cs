using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Bifrost.SYSTEMSET
{
    public partial class frmDutyDoctorSet : DevComponents.DotNetBar.Office2007Form
    {
    
        private ArrayList Userinfos = new ArrayList();//拥有角色的医生集合

        /// <summary>
        /// 找出所有和该科室有关的医生信息
        /// </summary>        
        private void GetAllDoctors()
        {

            string RoleIds = "";

            for (int i = 0; i < atrvRole.Nodes.Count; i++)
            {
                if (RoleIds == "")
                {
                    RoleIds=atrvRole.Nodes[i].Name;
                }
                else
                {
                    RoleIds = RoleIds+","+atrvRole.Nodes[i].Name;
                }
            }
            string Sql = " select distinct e.user_id,e.user_name,a.account_id from T_Account a " +
                         "inner join t_acc_role b on a.account_id=b.account_id "+
                         "inner join t_acc_role_range c on b.id=c.acc_role_id "+
                         "inner join t_account_user d on a.account_id=d.account_id "+
                         "inner join t_userinfo e on e.user_id=d.user_id "+
                         "where c.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "  and a.account_id not in (select account_id from t_acc_role where role_id in (" + RoleIds + "))";
            DataSet ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                advDoctors.Nodes.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                    node.CheckBoxVisible = true;
                    node.Text = ds.Tables[0].Rows[i]["user_name"].ToString();
                    node.Name = ds.Tables[0].Rows[i]["account_id"].ToString();
                    node.ImageIndex = 0;                  
                    advDoctors.Nodes.Add(node);
                }
            }
        }


        /// <summary>
        /// 获取所有的值班医生
        /// </summary>
        /// <param name="role_id"></param>
        private void GetAllDutyDoctors(string role_id)
        {
            advSelectDoctors.Nodes.Clear();           
            for (int i = 0; i < Userinfos.Count; i++)
            {
                UserInfo tempuinfo = (UserInfo)Userinfos[i];
                if (tempuinfo.Role_id == role_id)
                {
                    for (int j = 0; j < tempuinfo.Usernodes.Count; j++)
                    {
                        DevComponents.AdvTree.Node node = (DevComponents.AdvTree.Node)tempuinfo.Usernodes[j];
                        node.CheckBoxVisible = true;
                        node.Text = tempuinfo.Usernodes[j].Text;
                        node.Name = tempuinfo.Usernodes[j].Name;
                        node.ImageIndex = 0;
                        advSelectDoctors.Nodes.Add(node.Copy());
                    }
                }
            }

        
        }


        /// <summary>
        /// 初始化获取所有的值班医生
        /// </summary>
        /// <param name="role_id"></param>
        private void IniAllDutyDoctors()
        {
            string roleids = "";
            Userinfos.Clear();
            for (int i = 0; i < atrvRole.Nodes.Count; i++)
            {
                if (roleids == "")
                {
                    roleids = atrvRole.Nodes[i].Name;
                }
                else
                {
                    roleids =roleids+","+atrvRole.Nodes[i].Name;
                }

                UserInfo tempinfo = new UserInfo();
                tempinfo.Role_id = atrvRole.Nodes[i].Name;
                tempinfo.Usernodes = new DevComponents.AdvTree.NodeCollection();
                Userinfos.Add(tempinfo);
            }


            string Sql = " select b.account_id,e.user_name,b.role_id from T_Account a " +
                         "inner join t_acc_role b on a.account_id=b.account_id " +
                         "inner join t_acc_role_range c on b.id=c.acc_role_id " +
                         "inner join t_account_user d on a.account_id=d.account_id " +
                         "inner join t_userinfo e on e.user_id=d.user_id " +
                         "where c.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and b.role_id in (" + roleids + ")";

            DataSet ds = App.GetDataSet(Sql);
            if (ds != null)
            {


                for (int i = 0; i < Userinfos.Count; i++)
                {
                    UserInfo temp=(UserInfo)Userinfos[i];
                    DataRow[] rows = ds.Tables[0].Select("role_id=" + temp .Role_id+ "");
                    for (int j = 0; j < rows.Length; j++)
                    {
                        DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                        node.CheckBoxVisible = true;
                        node.Text = rows[j]["user_name"].ToString();
                        node.Name = rows[j]["account_id"].ToString();
                        node.ImageIndex = 0;                       
                        temp.Usernodes.Add(node);
                    }
                }
              
            }


        }


        ///// <summary>
        ///// 初始化的时候获取所有的值班医生的集合白班和夜班的
        ///// </summary>
        //private void IniAllDutyDoctors()
        //{
            
        //    string role_ids = "";
        //    for (int i = 0; i < atrvRole.Nodes.Count; i++)
        //    {
        //        if (role_ids == "")
        //        {
        //            role_ids = atrvRole.Nodes[i].Name;
        //        }
        //        else
        //        {
        //            role_ids =role_ids+","+atrvRole.Nodes[i].Name;
        //        }
        //    }
            
        //    string Sql = " select b.account_id,e.user_name,b.role_id from T_Account a " +
        //                 "inner join t_acc_role b on a.account_id=b.account_id " +
        //                 "inner join t_acc_role_range c on b.id=c.acc_role_id " +
        //                 "inner join t_account_user d on a.account_id=d.account_id " +
        //                 "inner join t_userinfo e on e.user_id=d.user_id " +
        //                 "where c.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and b.role_id in (" + role_ids + ")";
        //    DataSet ds = App.GetDataSet(Sql);
        //    /*
        //     * 获取所有相关
        //     */
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        DutyIds.Add(ds.Tables[0].Rows[i]);
        //    }                                               
        //}

        /// <summary>
        /// 获取所有的值班角色
        /// </summary>
        private void GetAllDutyRoles()
        {
            atrvRole.Nodes.Clear();
            string sql = "select * from t_role where role_name like '%班值班医生%'";
            DataSet ds = App.GetDataSet(sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();              
                node.Text = ds.Tables[0].Rows[i]["role_name"].ToString();
                node.Name = ds.Tables[0].Rows[i]["role_id"].ToString();               
                node.ImageIndex = 1;
                atrvRole.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 移除被选中的节点
        /// </summary>
        /// <param name="tr"></param>
        private void RemovNodes(DevComponents.AdvTree.AdvTree tr)
        {
            for (int i = 0; i < tr.Nodes.Count; i++)
            {
                if (tr.Nodes[i].Checked)
                {
                    tr.Nodes.Remove(tr.Nodes[i]);
                    RemovNodes(tr);
                    break;
                }
            }
        }

        /// <summary>
        ///构造函数
        /// </summary>
        public frmDutyDoctorSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDutyDoctorSet_Load(object sender, EventArgs e)
        {
            atrvRole.Nodes.Clear();
            advDoctors.Nodes.Clear();
            advSelectDoctors.Nodes.Clear();

            GetAllDutyRoles();
            IniAllDutyDoctors();
            //IniAllDutyDoctors();
            //GetAllDoctors();
            if (atrvRole.Nodes.Count>0)            
               atrvRole.SelectedNode=atrvRole.Nodes[0];
           GetAllDoctors();
           atrvRole_Click(sender,e);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < advDoctors.Nodes.Count; i++)
            {
                if (advDoctors.Nodes[i].Checked)
                {
                    DevComponents.AdvTree.Node temp = advDoctors.Nodes[i].Copy();
                    temp.Checked = false;
                    advSelectDoctors.Nodes.Add(temp);
                }
            }
            RemovNodes(advDoctors);

            for (int i = 0; i < Userinfos.Count; i++)
            {
                UserInfo tempinfo=(UserInfo)Userinfos[i];
                
                if (tempinfo.Role_id == atrvRole.SelectedNode.Name)
                {
                    tempinfo.Usernodes.Clear();
                     for(int k=0;k<advSelectDoctors.Nodes.Count;k++)
                     {
                         tempinfo.Usernodes.Add(advSelectDoctors.Nodes[k].Copy());
                     }
                }
            }
            advSelectDoctors.Refresh();
            
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < advSelectDoctors.Nodes.Count; i++)
            {
                if (advSelectDoctors.Nodes[i].Checked)
                {
                    DevComponents.AdvTree.Node temp = advSelectDoctors.Nodes[i].Copy();
                    temp.Checked = false;
                    advDoctors.Nodes.Add(temp);
                }
            }
            RemovNodes(advSelectDoctors);

            for (int i = 0; i < Userinfos.Count; i++)
            {
                UserInfo tempinfo = (UserInfo)Userinfos[i];                
                if (tempinfo.Role_id == atrvRole.SelectedNode.Name)
                {
                    tempinfo.Usernodes.Clear();
                    for (int k = 0; k < advSelectDoctors.Nodes.Count; k++)
                    {
                        tempinfo.Usernodes.Add(advSelectDoctors.Nodes[k].Copy());
                    }
                }
            }
            advSelectDoctors.Refresh();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            ArrayList sqlatrs = new ArrayList();

            //给帐号添加角色权限
            int Id = App.GenId("T_ACC_ROLE","ID");

            string roleids = "";
            string Accountids = "";

            for (int k = 0; k < Userinfos.Count; k++)
            {
                UserInfo temp=(UserInfo)Userinfos[k];
                if (roleids == "")
                {
                    roleids = temp.Role_id;
                }
                else
                {
                    roleids = roleids+","+temp.Role_id;
                }

                for (int kk = 0; kk < temp.Usernodes.Count; kk++)
                {
                    
                    if (Accountids == "")
                    {
                        Accountids = temp.Usernodes[kk].Name;
                    }
                    else
                    {
                        Accountids =Accountids+","+temp.Usernodes[kk].Name;
                    }
                }
            }           
                //sqlatrs.Add("delete from T_ACC_ROLE_RANGE where ACC_ROLE_ID in (select id from T_ACC_ROLE where ROLE_ID in (" + roleids + ") and ACCOUNT_ID in (" + Accountids + "))");
                //sqlatrs.Add("delete from T_ACC_ROLE where ROLE_ID=" + atrvRole.SelectedNode.Name + " and ACCOUNT_ID in (" + Accountids + ")");
            sqlatrs.Add("delete from T_ACC_ROLE_RANGE where ACC_ROLE_ID in (select id from T_ACC_ROLE where ROLE_ID in (" + roleids + @")) and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + "");
            sqlatrs.Add("delete from T_ACC_ROLE where ROLE_ID in (" + roleids + ") and ACCOUNT_ID in (select b.account_id from t_acc_role_range t inner join t_acc_role a on t.acc_role_id=a.id inner join t_account b on a.account_id=b.account_id where t.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")");
            for (int k = 0; k < Userinfos.Count; k++)
            {
                UserInfo temp = (UserInfo)Userinfos[k];
                for (int kk = 0; kk < temp.Usernodes.Count; kk++)
                {
                    sqlatrs.Add("insert into T_ACC_ROLE(ID,ACCOUNT_ID,ROLE_ID)values(" + Id.ToString() + "," + temp.Usernodes[kk].Name + "," + temp.Role_id + ")");
                    sqlatrs.Add("insert into T_ACC_ROLE_RANGE(ACC_ROLE_ID,SICKAREA_ID,SECTION_ID,ISBELONGTO)values(" + Id.ToString() + ",0," + App.UserAccount.CurrentSelectRole.Section_Id + ",'0')");
                    Id++;
                }
            }           
            string[] sqls = new string[sqlatrs.Count];
            for (int i = 0; i < sqlatrs.Count; i++)
            {
                sqls[i] = sqlatrs[i].ToString();                   
            }          
            if (App.ExecuteBatch(sqls) > 0)
            {
                App.Msg("操作已经成功！");
            }
            else
            {
                App.Msg("操作失败！");
            }                             
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 选择节点是重新刷新树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atrvRole_Click(object sender, EventArgs e)
        {
            if (atrvRole.SelectedNode != null)
            {
                //GetAllDoctors();
                GetAllDutyDoctors(atrvRole.SelectedNode.Name);
            }
        }

        private void atrvRole_SelectedValueChanged(object sender, EventArgs e)
        {
              
        }

        private void chkAllDoctors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDoctors.Checked)
            {
                for (int i = 0; i < advDoctors.Nodes.Count; i++)
                {
                    advDoctors.Nodes[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < advDoctors.Nodes.Count; i++)
                {
                    advDoctors.Nodes[i].Checked = false;
                }
            }
        }

        private void chkAllSelectDoctors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllSelectDoctors.Checked)
            {
                for (int i = 0; i < advSelectDoctors.Nodes.Count; i++)
                {
                    advSelectDoctors.Nodes[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < advSelectDoctors.Nodes.Count; i++)
                {
                    advSelectDoctors.Nodes[i].Checked = false;
                }
            }
        }

        
    }

    class UserInfo
    {
        private string role_id;
        public string Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        private string role_name;

        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }


        private DevComponents.AdvTree.NodeCollection usernodes;

        public DevComponents.AdvTree.NodeCollection Usernodes
        {
            get { return usernodes; }
            set { usernodes = value; }
        }
    }
}