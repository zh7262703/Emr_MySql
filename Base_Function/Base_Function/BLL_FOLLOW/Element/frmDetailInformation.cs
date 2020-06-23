using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmDetailInformation : DevComponents.DotNetBar.Office2007Form
    {
        private string user_ids = "";
        private string Sql = "";            //查询语句
        private string sequence = "";       //排序语句
        private string selectRow = "";      //保存选中行编号

        DataSet ds_sec;
        DataSet ds_use;

        public frmDetailInformation()
        {
            
            InitializeComponent();
            InitParentNode();
            cmbLevel.SelectedIndex = 0;
            cmbIsValid.SelectedIndex = 0;
            InitSection();
            InitDGV();
        }

        /// <summary>
        /// 获取科室名称集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string sectionnames(string Ids)
        {
            try
            {
                string[] ids = Ids.Split(',');
                string names = "";
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow[] rows = ds_sec.Tables[0].Select("sid=" + ids[i] + "");
                    if (rows.Length > 0)
                    {
                        if (names == "")
                        {
                            names = rows[0]["section_name"].ToString();
                        }
                        else
                        {
                            names = names + "," + rows[0]["section_name"].ToString();
                        }
                    }

                }

                return names;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        private string GetRelativeSolution(string id)
        {
            string name = "";
            DataSet ds=App.GetDataSet("select follow_name,followtextid from t_follow_info ");
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                string[] ids = ds.Tables[0].Rows[i]["followtextid"].ToString().Split(',');
                for (int j = 0; j < ids.Length; j++)
                {
                    if (ids[j] == id)
                    {
                        if (name == "")
                            name = ds.Tables[0].Rows[i]["follow_name"].ToString();
                        else
                            name += "," + ds.Tables[0].Rows[i]["follow_name"].ToString();
                        break;
                    }
                }
            }
            return name;
            
        }
        /// <summary>
        /// 查询表格数据
        /// </summary>
        public void InitDGV()
        {
            //查询
            Sql = "select a.textname  父节点,b.tid 编号,b.tname 文书名称,t.user_name 创建人,b.creator_id 创建id, b.create_time 创建时间,'' 创建科室,b.section_id 科室集合,'' 相关方案,(case when b.isdefault ='Y' then '默认'  when b.isdefault='N'and b.tempplate_level='H' then '全院普通' when b.isdefault='N' and b.tempplate_level='S'then '科室普通' else '个人普通' end) 属性,b.creator_role 用户属性,(case when b.enable_flag='Y' then '有效' else '无效' end) 是否有效"
            + " from t_follow_text a join t_follow_tempplate b on a.id=b.text_type join t_userinfo t on b.creator_id=t.user_id  where b.tid is not null";
            sequence = " order by 父节点,创建时间,是否有效";
            DataSet ds = App.GetDataSet(Sql + sequence);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string ids = ds.Tables[0].Rows[i]["科室集合"].ToString();
                string names = "";
                names = sectionnames(ids);
                ds.Tables[0].Rows[i]["创建科室"] = names;
                string rlsolution = GetRelativeSolution(ds.Tables[0].Rows[i]["编号"].ToString());
                ds.Tables[0].Rows[i]["相关方案"] = rlsolution;

            }

            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                dataGridViewX1.Columns[j].SortMode = DataGridViewColumnSortMode.Programmatic;
                

            }
            dataGridViewX1.Columns["科室集合"].Visible = false;
            dataGridViewX1.Columns["创建id"].Visible = false;
            dataGridViewX1.Columns["编号"].Visible = false;
        }


        /// <summary>
        /// 初始化父节点下拉框
        /// </summary>
        public void InitParentNode()
        {
            DataSet parent_node = App.GetDataSet("select textname,id from t_follow_text where id not in (select parentid from t_follow_text ) and enable_flag='Y'");
            DataRow Row=parent_node.Tables[0].NewRow();
            Row[0] = "";
            Row[1] = 0;
            parent_node.Tables[0].Rows.InsertAt(Row, 0);
            cmbParent.DataSource = parent_node.Tables[0].DefaultView;
            cmbParent.DisplayMember = "textname";
            cmbParent.ValueMember = "id";
        }
        /// <summary>
        /// 初始化科室
        /// </summary>
        public void InitSection()
        {
            string sql_sec = "select sid ,section_name from t_sectioninfo where  is_follow_visit='Y'";
            ds_sec = App.GetDataSet(sql_sec);
            DataRow rw = ds_sec.Tables[0].NewRow();
            rw[0] = "0";
            rw[1] = "";
            ds_sec.Tables[0].Rows.InsertAt(rw, 0);
            cmbSection.DataSource = ds_sec.Tables[0].DefaultView;
            cmbSection.DisplayMember = "section_name";
            cmbSection.ValueMember = "sid";

            
        }
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Str = Sql;
            if (cmbParent.Text != "")
            {
                Str += " and b.text_type ='" + cmbParent.SelectedValue.ToString() + "'";
            }
            if (cmbLevel.Text != "")
            {
                if (cmbLevel.Text == "全院")
                {
                    Str += " and b.tempplate_level='H'";
                }
                if (cmbLevel.Text == "个人")
                {
                    Str += " and b.tempplate_level='P'";
                }
                if (cmbLevel.Text == "科室")
                {
                    Str += " and b.tempplate_level='S'";
                }
            }
            if (txtFollowName.Text != "")
            {
                Str += " and b.tname like '%" + txtFollowName.Text.Trim() + "%'";
            }
            if (isUseTime.Checked)
            {
                Str += " and  b.create_time >= to_date ('" + dateTimePicker1.Value.ToShortDateString() + "','yyyy-mm-dd') and b.create_time<=to_date('" + dateTimePicker2.Value.ToShortDateString() + "','yyyy-mm-dd')";
            }
            if (txtCreator.Text != "")
            {
                Str += " and b.creator_id='" + user_ids + "'";
            }
            if (cmbAttribute.Text != "")
            {
                Str += " and b.isdefault='Y' or b.tid in (select template_id  from T_FOLLOW_TEMPPLATE_SECTION where isdefault='Y')";
            }
            if (cmbSection.Text != "")
            {
                Str += " and b.section_id ='" + cmbSection.SelectedValue.ToString() + "'";
            }
            if (cmbIsValid.Text!="")
            {
                if (string.Compare(cmbIsValid.Text , "有效")==0)
                    Str += " and b.enable_flag='Y'";
                else
                    Str += " and b.enable_flag='N'";
            }
            try
            {
                DataSet ds = App.GetDataSet(Str + sequence);
                if (ds != null)
                    dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
                else
                    App.MsgErr("查询出错！");

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void txtCreator_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCreator.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtCreator.Text = row["用户名"].ToString(); //textName;
                            user_ids= row["用户号"].ToString();
                            App.SelectObj = null;
                            //isSelectedDoc = true;
                        }
                }
                else
                {
                    user_ids = "";
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtCreator_KeyUp(object sender, KeyEventArgs e)
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
                        if (txtCreator.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select user_id 用户号,user_name  用户名 from T_USERINFO"
                                                + " where shortcut_code like '" + txtCreator.Text.ToUpper().Trim() + "%' or user_name like '" + txtCreator.Text.Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtCreator, "用户号", "用户名");
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

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewX1.Sort(dataGridViewX1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = dataGridViewX1.Rows[e.RowIndex].Cells["编号"].Value.ToString();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectRow != "")
            {
                Template.fmT = new TextEditor.frmText();
                frmEditPanel frm = new frmEditPanel(selectRow);
                frm.ShowDialog();
            }
        }

    }
}