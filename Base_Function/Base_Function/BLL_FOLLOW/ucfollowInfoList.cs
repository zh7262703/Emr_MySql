using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucfollowInfoList : UserControl
    {
        private string userids = "";
        private string icd10codes = "";
        private string icd9codes = "";
        private string sectionids = "";
        private string Sql = "";    //查询随访方案的SQL语句
        private string Maintain_Section = ""; //维护科室id号
        DataSet ds_user;
        DataSet ds_sec;
        DataSet ds_icd9;
        DataSet ds_icd10;
        DataSet ds_fwtype;

        public ucfollowInfoList()
        {
            InitializeComponent();
            cmbValid.Items.Insert(0,"");
            cmbMaintainSection.Items.Insert(0,"");
            cmbValid.SelectedIndex = 0;
            ds_sec = App.GetDataSet("select sid ,section_name from t_sectioninfo where  is_follow_visit='Y'");
            ds_icd9 = App.GetDataSet("select code,name from OPER_DEF_ICD9");
            ds_icd10 = App.GetDataSet("select code,name from DIAG_DEF_ICD10");
            InitTable("");
            InitSection();
            
        }
        /// <summary>
        /// 添加新方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFollowInfo frm = new frmFollowInfo("");          
            frm.ShowDialog();
            InitTable("");
            
        }
        /// <summary>
        /// 科室初始化
        /// </summary>
        public void InitSection()
        {
            
            DataRow rw = ds_sec.Tables[0].NewRow();
            rw[0] = "0";
            rw[1] = "";
            ds_sec.Tables[0].Rows.InsertAt(rw, 0);
            cmbSection.DataSource = ds_sec.Tables[0].DefaultView;
            cmbSection.DisplayMember = "section_name";
            cmbSection.ValueMember = "sid";
            cmbSection.SelectedIndex = 0;
            for (int i = 0; i < cmbSection.Items.Count; i++)
            {
                DataRowView drv = cmbSection.Items[i] as DataRowView;
                if (drv["sid"].ToString() == App.UserAccount.UserInfo.Section_id)
                    cmbSection.SelectedIndex = i;
            }

        }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetUserName(string Ids)
        {

            string[] id = Ids.Split(',');
            string names = "";
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] == "")
                        break;
                    string name = "";
                    for (int j = 0; j < ds_user.Tables[0].Rows.Count; j++)
                        if (id[i] == ds_user.Tables[0].Rows[j]["user_id"].ToString())
                        {
                            name = ds_user.Tables[0].Rows[j]["user_name"].ToString();
                            break;
                        }
                    if (i == 0)
                        names = name;
                    else
                        names += "," + name;
                }

                return names;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取科室名
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetSectionName(String Ids)
        {
            if (Ids == "0")
                return "全院";
            else
            {
                string[] id = Ids.Split(',');
                string sections = "";
                try
                {

                    for (int i = 0; i < id.Length; i++)
                    {
                        string name = "";
                        for (int j = 0; j < ds_sec.Tables[0].Rows.Count; j++)
                            if (id[i] == ds_sec.Tables[0].Rows[j]["sid"].ToString())
                            {
                                name = ds_sec.Tables[0].Rows[j]["section_name"].ToString();
                                break;
                            }
                        if (sections == "")
                            sections = name;
                        else
                            sections += "," + name;
                    }

                    return sections;
                }
                catch
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 获取手术名
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetOperationName(string Ids)
        {
            string[] id = Ids.Split(',');
            string operations = "";
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    string name = "";
                    for (int j = 0; j < ds_icd9.Tables[0].Rows.Count; j++)
                        if (id[i] == ds_icd9.Tables[0].Rows[j]["code"].ToString())
                        {
                            name = ds_icd9.Tables[0].Rows[j]["name"].ToString();
                            break;
                        }
                    if (i == 0)
                        operations = name;
                    else
                        operations += "," + name;
                }

                return operations;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取诊断名
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetDiagName(string Ids)
        {
            string[] id = Ids.Split(',');
            string diags = "";
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    string name = "";
                    for (int j = 0; j < ds_icd10.Tables[0].Rows.Count; j++)
                        if (id[i] == ds_icd10.Tables[0].Rows[j]["code"].ToString())
                        {
                            name = ds_icd10.Tables[0].Rows[j]["name"].ToString();
                            break;
                        }
                    if (i == 0)
                        diags = name;
                    else
                        diags += "," + name;
                }

                return diags;
            }
            catch
            {
                return "";
            }
        }
        ///// <summary>
        ///// 获取文书模板
        ///// </summary>
        ///// <param name="Ids"></param>
        ///// <returns></returns>
        //private string GetFollowType(string Ids)
        //{
        //    string[] id = Ids.Split(',');
        //    string types = "";
        //    try
        //    {
        //        for (int i = 0; i < id.Length; i++)
        //        {
        //            if (id[i] == "")
        //                break;
        //            string name = "";
        //            for (int j = 0; j < ds_fwtype.Tables[0].Rows.Count; j++)
        //                if (id[i] == ds_fwtype.Tables[0].Rows[j]["tid"].ToString())
        //                {
        //                    name = ds_fwtype.Tables[0].Rows[j]["tname"].ToString();
        //                    break;
        //                }
        //            if (i == 0)
        //                types = name;
        //            else
        //                types += "," + name;
        //        }

        //        return types;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        /// <summary>
        /// 绑定列表
        /// </summary>
        public void InitTable(string condition)
        {
            DataSet ds;
            Sql = "select  id as 方案号,follow_name as 方案名,section_names 科室,'' 手术,icd9codes as 手术编号,'' 诊断,icd10codes as 诊断编号,startingtime as 参考时间,defaultdays as 首次默认天数,followtype as 随访时间类别,definefollows as 随访循环天数,finishType as 随访结束,trunc(createtime) 创建时间, creator as 创建者,(case when isenable= 'Y' then '有效' else '无效' end) as 是否有效,maintain_section 维护科室 from t_follow_info where id is not null";
            if (condition == "")
            {
                ds = App.GetDataSet(Sql);
            }
            else
            {
                ds = App.GetDataSet(Sql + condition);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string icd9_names = GetOperationName(ds.Tables[0].Rows[i]["手术编号"].ToString());
                ds.Tables[0].Rows[i]["手术"] = icd9_names;
                string icd10_names = GetDiagName(ds.Tables[0].Rows[i]["诊断编号"].ToString());
                ds.Tables[0].Rows[i]["诊断"] = icd10_names;
                string creator = GetUserName(ds.Tables[0].Rows[i]["创建者"].ToString());
                ds.Tables[0].Rows[i]["创建者"] = creator;
            }
            dgvFollowMethod.DataSource = ds.Tables[0].DefaultView;
            dgvFollowMethod.Columns["手术编号"].Visible = false;
            dgvFollowMethod.Columns["诊断编号"].Visible = false;
            dgvFollowMethod.ReadOnly = true;
            //按列排序实现            

        }

        /// <summary>
        /// 设置查询条件，更新dgvGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Condition = "";
            if (txtFollowMethod.Text.Trim() != "")
                Condition+=" and follow_name like '%"+txtFollowMethod.Text.Trim()+"%'";
            if (txtDiag.Text.Trim() != "")
                Condition += " and icd10codes like '%" + icd10codes + "%'";
            if (txtOperation.Text.Trim() != "")
                Condition += " and icd9codes like '%" + icd9codes + "%'";
            if (txtUser.Text.Trim() != "")
                Condition += " and account_ids like '%" + userids + "%'";
            if (cmbSection.Text != "")
                Condition += " and section_ids like '%" + cmbSection.SelectedValue.ToString() + "%' or section_ids='0'";
            if(cmbMaintainSection.Text!="")
            {
                if (cmbMaintainSection.Text == "本科维护")
                    Condition += " and maintain_section =" + App.UserAccount.CurrentSelectRole.Section_Id + "";
                else
                    Condition += "and maintain_section in (select sid from t_sectioninfo where in_flag='I')";
            }
            if (cmbValid.Text.Trim() != "")
            {
                if (cmbValid.Text == "有效")
                    Condition += " and isenable='Y'";
                else
                    Condition += " and isenable='N'";
            }
            InitTable(Condition);
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFollowInfo frm = new frmFollowInfo(dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells["方案号"].Value.ToString());
            frm.ShowDialog();
            InitTable("");
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("确定删除此数据？"))
            {
                try
                {
                    string delete_sql = "delete from t_follow_info where id=" + dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells[0].Value.ToString() + "";
                    if(App.ExecuteSQL(delete_sql)>0)
                        App.Msg("删除成功！");
                    else
                        App.Msg("删除失败！");
                }
                catch
                {
                }
                InitTable("");
            }
        }
        /// <summary>
        /// 快码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtUser.Text = row["用户名"].ToString() ; //textName;
                            userids = row["用户号"].ToString();
                            App.SelectObj = null;
                            //isSelectedDoc = true;
                        }
                }
                else
                {
                    userids = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtUser.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id 用户号,user_name 用户名 from t_userinfo"
                                                + " where shortcut_code like '" + txtUser.Text.ToUpper().Trim() + "%' or user_name like '" + txtUser.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtUser, "用户号", "用户名");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void txtDiag_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDiag.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select code 诊断号,name 诊断名 from DIAG_DEF_ICD10"
                                                + " where shortcut1 like '" + txtDiag.Text.ToUpper().Trim() + "%' or name like '" + txtDiag.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDiag, "诊断号", "诊断名");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void txtDiag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiag.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDiag.Text = row["诊断名"].ToString(); //textName;
                            icd10codes = row["诊断号"].ToString();
                            App.SelectObj = null;
                            //isSelectedDoc = true;
                        }
                }
                else
                {
                    icd10codes = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOperation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOperation.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtOperation.Text = row["手术名"].ToString(); //textName;
                            icd9codes = row["手术号"].ToString();
                            App.SelectObj = null;
                            //isSelectedDoc = true;
                        }
                }
                else
                {
                    icd9codes = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOperation_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtOperation.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select code 手术号,name 手术名 from OPER_DEF_ICD9"
                                                + " where shortcut1 like '" + txtOperation.Text.ToLower().Trim() + "%' or name like '" + txtOperation.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtOperation, "手术号", "手术名");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }
        /// <summary>
        /// 科室sid的赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionids = cmbSection.SelectedValue.ToString();
        }
        /// <summary>
        /// 按列排序的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFollowMethod_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            dgvFollowMethod.Sort(dgvFollowMethod.Columns[e.ColumnIndex], ListSortDirection.Ascending);
        }

        private void 无效ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("确定使此方案无效？"))
            {
                try
                {
                    string update_sql = "update t_follow_info set isenable='N' where id=" + dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells[0].Value.ToString() + "";
                    if (App.ExecuteSQL(update_sql) > 0)
                        App.Msg("操作成功！");
                    else
                        App.Msg("操作失败！");
                }
                catch
                {
                }
                InitTable("");
            }
        }

    }
}
