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
        private string Sql = "";    //��ѯ��÷�����SQL���
        private string Maintain_Section = ""; //ά������id��
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
        /// ����·���
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
        /// ���ҳ�ʼ��
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
        /// ��ȡ�û�����
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
        /// ��ȡ������
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetSectionName(String Ids)
        {
            if (Ids == "0")
                return "ȫԺ";
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
        /// ��ȡ������
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
        /// ��ȡ�����
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
        ///// ��ȡ����ģ��
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
        /// ���б�
        /// </summary>
        public void InitTable(string condition)
        {
            DataSet ds;
            Sql = "select  id as ������,follow_name as ������,section_names ����,'' ����,icd9codes as �������,'' ���,icd10codes as ��ϱ��,startingtime as �ο�ʱ��,defaultdays as �״�Ĭ������,followtype as ���ʱ�����,definefollows as ���ѭ������,finishType as ��ý���,trunc(createtime) ����ʱ��, creator as ������,(case when isenable= 'Y' then '��Ч' else '��Ч' end) as �Ƿ���Ч,maintain_section ά������ from t_follow_info where id is not null";
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
                string icd9_names = GetOperationName(ds.Tables[0].Rows[i]["�������"].ToString());
                ds.Tables[0].Rows[i]["����"] = icd9_names;
                string icd10_names = GetDiagName(ds.Tables[0].Rows[i]["��ϱ��"].ToString());
                ds.Tables[0].Rows[i]["���"] = icd10_names;
                string creator = GetUserName(ds.Tables[0].Rows[i]["������"].ToString());
                ds.Tables[0].Rows[i]["������"] = creator;
            }
            dgvFollowMethod.DataSource = ds.Tables[0].DefaultView;
            dgvFollowMethod.Columns["�������"].Visible = false;
            dgvFollowMethod.Columns["��ϱ��"].Visible = false;
            dgvFollowMethod.ReadOnly = true;
            //��������ʵ��            

        }

        /// <summary>
        /// ���ò�ѯ����������dgvGridView
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
                if (cmbMaintainSection.Text == "����ά��")
                    Condition += " and maintain_section =" + App.UserAccount.CurrentSelectRole.Section_Id + "";
                else
                    Condition += "and maintain_section in (select sid from t_sectioninfo where in_flag='I')";
            }
            if (cmbValid.Text.Trim() != "")
            {
                if (cmbValid.Text == "��Ч")
                    Condition += " and isenable='Y'";
                else
                    Condition += " and isenable='N'";
            }
            InitTable(Condition);
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// �޸İ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �޸�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFollowInfo frm = new frmFollowInfo(dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells["������"].Value.ToString());
            frm.ShowDialog();
            InitTable("");
        }
        /// <summary>
        /// ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("ȷ��ɾ�������ݣ�"))
            {
                try
                {
                    string delete_sql = "delete from t_follow_info where id=" + dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells[0].Value.ToString() + "";
                    if(App.ExecuteSQL(delete_sql)>0)
                        App.Msg("ɾ���ɹ���");
                    else
                        App.Msg("ɾ��ʧ�ܣ�");
                }
                catch
                {
                }
                InitTable("");
            }
        }
        /// <summary>
        /// �����ѯ
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
                            txtUser.Text = row["�û���"].ToString() ; //textName;
                            userids = row["�û���"].ToString();
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
                            string sql_select = "select user_id �û���,user_name �û��� from t_userinfo"
                                                + " where shortcut_code like '" + txtUser.Text.ToUpper().Trim() + "%' or user_name like '" + txtUser.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtUser, "�û���", "�û���");
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
                            string sql_select = "select code ��Ϻ�,name ����� from DIAG_DEF_ICD10"
                                                + " where shortcut1 like '" + txtDiag.Text.ToUpper().Trim() + "%' or name like '" + txtDiag.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDiag, "��Ϻ�", "�����");
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
                            txtDiag.Text = row["�����"].ToString(); //textName;
                            icd10codes = row["��Ϻ�"].ToString();
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
                            txtOperation.Text = row["������"].ToString(); //textName;
                            icd9codes = row["������"].ToString();
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
                            string sql_select = "select code ������,name ������ from OPER_DEF_ICD9"
                                                + " where shortcut1 like '" + txtOperation.Text.ToLower().Trim() + "%' or name like '" + txtOperation.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtOperation, "������", "������");
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
        /// ����sid�ĸ�ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionids = cmbSection.SelectedValue.ToString();
        }
        /// <summary>
        /// ���������ʵ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFollowMethod_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            dgvFollowMethod.Sort(dgvFollowMethod.Columns[e.ColumnIndex], ListSortDirection.Ascending);
        }

        private void ��ЧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("ȷ��ʹ�˷�����Ч��"))
            {
                try
                {
                    string update_sql = "update t_follow_info set isenable='N' where id=" + dgvFollowMethod.Rows[dgvFollowMethod.CurrentRow.Index].Cells[0].Value.ToString() + "";
                    if (App.ExecuteSQL(update_sql) > 0)
                        App.Msg("�����ɹ���");
                    else
                        App.Msg("����ʧ�ܣ�");
                }
                catch
                {
                }
                InitTable("");
            }
        }

    }
}
