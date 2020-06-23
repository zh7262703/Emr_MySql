using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Bifrost.SYSTEMSET
{
    public partial class frmDutyTimeSpanSet : UserControl
    {

        bool IsSave = false;             //用于存放当前的操作状态 true为添加操作 false为修改操作
        string id = "";                  //当前选中的记录

        /// <summary>
        /// 获取权限
        /// </summary>
        private void getAllRole()
        {
            DataSet ds=App.GetDataSet("select * from t_role t");
            cboRole.DataSource = ds.Tables[0].DefaultView;
            cboRole.DisplayMember = "ROLE_NAME";
            cboRole.ValueMember = "ROLE_ID";
            if (cboRole.Items.Count > 0)
            {
                cboRole.SelectedIndex = 0;
            }

            
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        private void GetinfoList()
        {            
            ucGridviewX1.DataBd("select a.id as 序号,a.relation_id as 角色主键,b.role_name as 角色名称,a.begin_time as 开始时间,a.end_time as 结束时间,a.begin_logic as 开始条件,a.end_logic as 结束条件 from T_USE_TIME_SPAN a inner join t_role b on a.relation_id=b.role_id", "序号", "", "");
            cboRole.Enabled = false;
            dtpStart.Enabled = false;
            cboC1.Enabled = false;
            dtpEnd.Enabled = false;
            cboC2.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        public frmDutyTimeSpanSet()
        {
            InitializeComponent();
        }

        private void frmDutyTimeSpanSet_Load(object sender, EventArgs e)
        {
            getAllRole();
            GetinfoList();
            cboC1.SelectedIndex = 0;
            cboC2.SelectedIndex = 0;
            ucGridviewX1.fg.Click += new EventHandler(fg_Click);
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit()
        {            
            cboRole.Enabled = true;
            dtpStart.Enabled = true;
            cboC1.Enabled = true;
            dtpEnd.Enabled = true;
            cboC2.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            cboRole.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit();
           
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //删除操作
            try
            {
                string id = ucGridviewX1.fg["序号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                string sql = "delete from T_USE_TIME_SPAN where id=" + id + "";
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("操作已经成功！");
                    frmDutyTimeSpanSet_Load(sender, e);
                }
                else
                {
                    App.MsgErr("操作失败！");
                }
            }
            catch
            {
                App.MsgErr("操作失败！");
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            string c1="0";
            string c2="0";

            if (cboC1.Text == ">")
            {
                c1 = "0";
            }
            else
            {
                c1 = "1";
            }


            if (cboC2.Text == ">")
            {
                c2 = "0";
            }
            else
            {
                c2 = "1";
            }
            string Sql;
            if (IsSave)
            {
                //添加操作
               

                id=App.GenId("T_USE_TIME_SPAN","ID").ToString();
                Sql = "insert into T_USE_TIME_SPAN(id,RELATION_ID,BEGIN_TIME,END_TIME,BEGIN_LOGIC,END_LOGIC)values(" + id
                    + "," + cboRole.SelectedValue.ToString() + ",'" + dtpStart.Value.ToShortTimeString().ToString() + "','" + dtpEnd.Value.ToShortTimeString().ToString() + "','" + c1 + "','" + c2 + "')";

            }
            else
            {
                //修改操作
                Sql = "Update T_USE_TIME_SPAN set RELATION_ID=" + cboRole.SelectedValue.ToString() + ",BEGIN_TIME='" + dtpStart.Value.ToShortTimeString().ToString() + "',END_TIME='" + dtpEnd.Value.ToShortTimeString().ToString() + "',BEGIN_LOGIC='" + c1 + "',END_LOGIC='" + c2 + "' where id=" + id + "";

            }

            if (App.ExecuteSQL(Sql) > 0)
            {
                App.Msg("操作已经成功！");
                GetinfoList();
                
            }
            else
            {
                App.MsgErr("操作失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboRole.Enabled = false;
            dtpStart.Enabled = false;
            cboC1.Enabled = false;
            dtpEnd.Enabled = false;
            cboC2.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void ucGridviewX1_Click(object sender, EventArgs e)
        {
                       
        }

        private void fg_Click(object sender, EventArgs e)
        {
            try
            {
                id = "";
                id = ucGridviewX1.fg["序号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                cboRole.SelectedValue = ucGridviewX1.fg["角色主键", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                dtpStart.Value = Convert.ToDateTime(ucGridviewX1.fg["开始时间", ucGridviewX1.fg.CurrentRow.Index].Value);
                dtpEnd.Value = Convert.ToDateTime(ucGridviewX1.fg["结束时间", ucGridviewX1.fg.CurrentRow.Index].Value);
                cboC1.SelectedIndex = Convert.ToInt16(ucGridviewX1.fg["开始条件", ucGridviewX1.fg.CurrentRow.Index].Value);
                cboC2.SelectedIndex = Convert.ToInt16(ucGridviewX1.fg["结束条件", ucGridviewX1.fg.CurrentRow.Index].Value);
            }
            catch
            { }
        }
    }
}