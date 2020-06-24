using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TextEditor;
using Bifrost;
using System.Xml;
using System.Collections;
using Microsoft.ReportingServices.ReportRendering;
using Base_Function.BASE_COMMON;
using MySql.Data.MySqlClient;

namespace Base_Function.TEMPLATE
{
    public partial class ucTemplateCheck : UserControl
    {
        /// <summary>
        /// 模板编辑
        /// </summary>
        frmText TempLateEditor = new frmText();

        string currentId = "0";

        /// <summary>
        /// 当前选择行
        /// </summary>
        private int SelRowIndex = 0;

        public ucTemplateCheck()
        {
            InitializeComponent();
            cboType.SelectedIndex = 2;

        }


        /// <summary>
        /// 获取未审核的科室模板
        /// </summary>
        private void GetTemplateListUnCheck()
        {
            dataGridViewX1.Columns.Clear();

            string Sql = "";

            //Sql = "select tid as 编号,tname as 名称,u1.user_name as 创建人,a.create_time 创建时间,a.sectionchek as 审核标记 ,a.mamagechek as 医务科审核 " +
            //            "from t_tempplate a inner join t_account a2 on a2.account_id=a.creator_id " +
            //            "inner join t_account_user a3 on a2.account_id=a3.account_id " +
            //            "inner join t_userinfo u1 on a3.user_id=u1.user_id " +
            //            "where tid in " +
            //            "(select TEMPLATE_ID from t_tempplate_section c where c.section_id=" +
            //            cboCusection.SelectedValue.ToString() + ")";//a.tempplate_level='S' and
            if (cboCusection.Text == "--请选择--" || cboCusection.SelectedIndex == -1)
            {
                Sql = "select tid as 编号,tname as 名称,u1.user_name as 创建人,a.create_time 创建时间,a.mamagechek as 医务科审核 " +
                       "from t_tempplate a inner join t_account a2 on a2.account_id=a.creator_id " +
                       "inner join t_account_user a3 on a2.account_id=a3.account_id " +
                       "inner join t_userinfo u1 on a3.user_id=u1.user_id " +
                       "where tid in " +
                       "(select TEMPLATE_ID from t_tempplate_section c )";
            }
            else
            {
                Sql = "select tid as 编号,tname as 名称,u1.user_name as 创建人,a.create_time 创建时间,a.mamagechek as 医务科审核 " +
                           "from t_tempplate a inner join t_account a2 on a2.account_id=a.creator_id " +
                           "inner join t_account_user a3 on a2.account_id=a3.account_id " +
                           "inner join t_userinfo u1 on a3.user_id=u1.user_id " +
                           "where tid in " +
                           "(select TEMPLATE_ID from t_tempplate_section c where c.section_id=" +
                           cboCusection.SelectedValue.ToString() + ")";
            }

            string condions = "";
            if (txtName.Text.Trim().Length > 0)
            {
                Sql += "  and tname like '%" + txtName.Text.Trim() + "%' ";
            }
            if (App.UserAccount.CurrentSelectRole.Role_name == "医务科主任" || App.UserAccount.CurrentSelectRole.Role_name == "医务科副主任")
            {
                if (cboType.Text == "已审核")
                {
                    condions = " and a.sectionchek='Y' and a.mamagechek='Y'";
                }
                else if (cboType.Text == "未审核")
                {
                    condions = " and (a.mamagechek='N' or a.mamagechek is null or a.sectionchek='N' or a.sectionchek is null) ";
                }
            }
            else
            {
                if (cboType.Text == "已审核")
                {
                    condions = " and a.sectionchek='Y'";
                }
                else if (cboType.Text == "未审核")
                {
                    condions = " and (a.sectionchek='N' or a.sectionchek is null)";
                }
            }

            Sql = Sql + " " + condions;

            DataSet ds = App.GetDataSet(Sql);
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            //解决改版后表格中复选框无法选中(放到数据加载前)
            DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
            newColumn.HeaderCell = cbHeader;
            newColumn.Name = "1";
            dataGridViewX1.Columns.Insert(0, newColumn);

            cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            dataGridViewX1.ReadOnly = false;
            foreach(DataGridViewColumn col in dataGridViewX1.Columns)
            {
                if(col.Name == "1")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
            //newColumn.HeaderText = "选择";
            //dataGridViewX1.Columns.Insert(0, newColumn);
            //dataGridViewX1.Columns[0].ReadOnly = false;


            for (int i = 1; i < dataGridViewX1.Columns.Count; i++)
            {
                dataGridViewX1.Columns[i].ReadOnly = true;
            }

            RefleshRowColor();
            dataGridViewX1.AutoResizeColumns();
            //dataGridViewX1.Refresh();
        }
        void cbHeader_OnCheckBoxClicked (bool state)
        {
            foreach(DataGridViewRow Row in dataGridViewX1.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["1"]).Value = state;
            }
            dataGridViewX1.RefreshEdit();
        }
        /// <summary>
        /// 将当前编辑器中的文书转换成xml，并以字符串的形式读出 （用于插入数据库）
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            TempLateEditor.MyDoc.IsHaveDeleted = true;
            TempLateEditor.MyDoc.ToXML(tempxmldoc.DocumentElement);
            TempLateEditor.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        /// <summary>
        /// 刷新颜色
        /// </summary>
        private void RefleshRowColor()
        {
            //审核标记
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {

                //if (dataGridViewX1["审核标记", i].Value.ToString() == "" ||
                //    dataGridViewX1["审核标记", i].Value == null ||
                //    dataGridViewX1["审核标记", i].Value.ToString() == "N" ||
                //    dataGridViewX1["审核标记", i].Value.ToString() == "未审核")
                //{
                //    dataGridViewX1["审核标记", i].Value = "未审核";
                //    dataGridViewX1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                //}
                //else
                //{
                //    dataGridViewX1["审核标记", i].Value = "已审核";
                //    dataGridViewX1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //}


                if (dataGridViewX1["医务科审核", i].Value.ToString() == "" ||
                   dataGridViewX1["医务科审核", i].Value == null ||
                   dataGridViewX1["医务科审核", i].Value.ToString() == "N" ||
                   dataGridViewX1["医务科审核", i].Value.ToString() == "未审核")
                {
                    dataGridViewX1["医务科审核", i].Value = "未审核";
                    dataGridViewX1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridViewX1["医务科审核", i].Value = "已审核";
                    dataGridViewX1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            this.dataGridViewX1.Refresh();
        }

        private void frmTemplateCheck_Load(object sender, EventArgs e)
        {
            TempLateEditor.Dock = DockStyle.Fill;
            groupPanel2.Controls.Add(TempLateEditor);
            Section();
        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        private void Section()
        {
//            if (App.UserAccount.CurrentSelectRole.Section_name != "" && App.UserAccount.CurrentSelectRole.Section_name != null)
//            {
//                int sid = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);
//                DataSet ds = App.GetDataSet("select sid,section_name from t_sectioninfo where sid=" + sid);
//                cboCusection.DataSource = ds.Tables[0].DefaultView;
//                cboCusection.DisplayMember = "section_name";
//                cboCusection.ValueMember = "sid";
//                cboCusection.Enabled = false;
//            }
//            else
//            {
//                string sql = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
//                                        inner join t_section_area b on a.sid=b.sid
//                                        inner join t_sickareainfo c on b.said=c.said
//                                        where  a.enable_flag='Y' and c.enable_flag='Y'
//                                        group  by a.shid,a.sid,a.section_code,a.section_name
//                                        order by a.shid,to_number(a.section_code)";
//                DataSet ds = App.GetDataSet(sql);
//                cboCusection.DataSource = ds.Tables[0].DefaultView;
//                cboCusection.DisplayMember = "section_name";
//                cboCusection.ValueMember = "sid";
//                cboCusection.Enabled = true;
//            }
            DataTable dt = null;
            if (App.UserAccount.CurrentSelectRole.Section_name != "" && App.UserAccount.CurrentSelectRole.Section_name != null)
            {
                int sid = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);
                dt = App.GetDataSet("select sid,section_name from t_sectioninfo where sid=" + sid).Tables[0];
                cboCusection.Enabled = false;
            }
            else
            {
                string sql = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        inner join t_sickareainfo c on b.said=c.said
                                        where  a.enable_flag='Y' and c.enable_flag='Y'
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.section_name";
                dt = App.GetDataSet(sql).Tables[0];
                cboCusection.Enabled = true;
            }
            cboCusection.DataSource = dt;
            DataRow row = dt.NewRow();
            row["sid"] = "0";
            row["section_name"] = "--请选择--";
            dt.Rows.InsertAt(row, 0);
            cboCusection.DisplayMember = "section_name";
            cboCusection.ValueMember = "sid";
            cboCusection.SelectedIndex = 0;
        }
        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<string> slist = new List<string>();
            //审核标记
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell newColumn = (DataGridViewCheckBoxCell)dataGridViewX1.Rows[i].Cells[0];
                if (newColumn.Value != null)
                {
                    if (newColumn.Value.ToString() == "True")
                    {
                        string tid = dataGridViewX1["编号", i].Value.ToString();
                        if (App.UserAccount.CurrentSelectRole.Role_name == "医务科主任" || App.UserAccount.CurrentSelectRole.Role_name == "医务科副主任")
                        {
                            slist.Add("update T_TEMPPLATE set mamagechek='Y' where TID=" + tid + "");
                            slist.Add("update T_TEMPPLATE set sectionchek='Y' where TID=" + tid + "");
                        }
                        else
                        {
                            //slist.Add("update T_TEMPPLATE set SECTIONCHEK='Y' where TID=" + tid + "");
                            MessageBox.Show("您没有权限审核此模板，请联系医务科主任！");
                            return;
                        }
                    }
                }
            }

            if (slist.Count == 0)
            {
                App.MsgErr("请先勾选需要审核的模板记录！");
                return;
            }

            if (App.ExecuteBatch(slist.ToArray()) > 0)
            {
                App.Msg("审核已经成功！");
                GetTemplateListUnCheck();
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                string tid = dataGridViewX1["编号", SelRowIndex].Value.ToString();
                DataSet ds = App.GetDataSet("select CONTENT from T_TEMPPLATE_CONT where tid=" + tid + "");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ds.Tables[0].Rows[0][0].ToString());
                TempLateEditor.MyDoc.ClearContent();
                TempLateEditor.MyDoc.FromXML(doc.DocumentElement);
            }
            catch
            { }
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int message = 0;
            string temp = "";
            try
            {
                temp = GetXmlContent();
                string updateLable = "update T_TempPlate_Cont set Content=:divContent where tid=" + currentId;
                MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                xmlPars[0] = new MySqlDBParameter();
                xmlPars[0].ParameterName = "divContent";
                //xmlPars[0].Value = divNode.OuterXml;
                xmlPars[0].Value = temp;//bodyNode.InnerXml;
                xmlPars[0].DBType = MySqlDbType.Text;
                xmlPars[0].Direction = ParameterDirection.Input;
                message = App.ExecuteSQL(updateLable, xmlPars);
                if (message > 0)
                {
                    App.Msg("保存成功");
                    TempLateEditor.MyDoc.Modified = false;
                }
                else
                {
                    App.MsgErr("保存失败");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("保存失败,错误原因:" + ex.Message);
            }
        }

        private void dataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                try
                {
                    if (TempLateEditor.MyDoc.Modified)
                    {
                        if (e.RowIndex != SelRowIndex)
                        {
                            App.MsgWaring("请先保存当前模板!");

                            dataGridViewX1.ClearSelection();
                            dataGridViewX1.Rows[SelRowIndex].Selected = true;
                            dataGridViewX1.Refresh();
                            return;
                        }
                    }
                    else
                    {
                        if (e.RowIndex == -1)
                        {
                            return;
                        }
                        currentId = dataGridViewX1["编号", e.RowIndex].Value.ToString();

                        if (dataGridViewX1.Rows.Count > 1)
                        {
                            if (e.RowIndex != SelRowIndex)
                            {
                                DataSet ds = App.GetDataSet("select CONTENT from T_TEMPPLATE_CONT where tid=" + currentId + "");
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(ds.Tables[0].Rows[0][0].ToString());
                                TempLateEditor.MyDoc.ClearContent();
                                TempLateEditor.MyDoc.FromXML(doc.DocumentElement);
                            }
                        }
                        else
                        {
                            DataSet ds = App.GetDataSet("select CONTENT from T_TEMPPLATE_CONT where tid=" + currentId + "");
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(ds.Tables[0].Rows[0][0].ToString());
                            TempLateEditor.MyDoc.ClearContent();
                            TempLateEditor.MyDoc.FromXML(doc.DocumentElement);
                        }
                    }
                    SelRowIndex = e.RowIndex;
                }
                catch (Exception ex)
                {
                    App.MsgErr("请选择需要操作的模板记录，错误信息：" + ex.Message);
                }
            }
        }

        private void 撤销审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (App.UserAccount.CurrentSelectRole.Role_name == "医务科主任" || App.UserAccount.CurrentSelectRole.Role_name == "医务科副主任")
            {
                sql = "update T_TEMPPLATE set mamagechek='N' where TID=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                if (App.ExecuteSQL(sql) > 0)
                {
                    dataGridViewX1["医务科审核", SelRowIndex].Value = "未审核";
                    RefleshRowColor();
                }
                else
                {
                    App.MsgErr("操作失败！");
                }
            }
            else
            {
                App.MsgErr("操作失败！");
                //sql = "update T_TEMPPLATE set SECTIONCHEK='N' where TID=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                //if (App.ExecuteSQL(sql) > 0)
                //{
                //    dataGridViewX1["审核标记", SelRowIndex].Value = "未审核";
                //    RefleshRowColor();
                //}
                //else
                //{
                //    App.MsgErr("操作失败！");
                //}
            }

        }

        private void 删除模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_name == "医务科主任" || App.UserAccount.CurrentSelectRole.Role_name == "医务科副主任")
            {
                if (dataGridViewX1["医务科审核", SelRowIndex].Value.ToString() == "未审核")
                {
                    string[] sqls = new string[2];
                    sqls[0] = "delete from T_TEMPPLATE where tid=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    sqls[1] = "delete from T_TEMPPLATE_CONT where tid=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    if (App.Ask("确定要删除'" + dataGridViewX1["名称", SelRowIndex].Value.ToString() + "'的模板吗？"))
                    {
                        if (App.ExecuteBatch(sqls) > 0)
                        {
                            if (dataGridViewX1.Rows.Count > 0)
                            {
                                dataGridViewX1.Rows[0].Selected = true;
                                SelRowIndex = 0;
                            }
                            GetTemplateListUnCheck();
                            TempLateEditor.MyDoc.Modified = false;
                        }
                    }
                }
                else
                {
                    App.MsgWaring("请先将模板“撤销审核”，再进行删除！");
                }
            }
            else
            {
                if (dataGridViewX1["医务科审核", SelRowIndex].Value.ToString() != "未审核")
                {
                    App.MsgWaring("请先将模板“撤销医务科审核”，再进行删除！");
                    return;
                }

                if (dataGridViewX1["审核标记", SelRowIndex].Value.ToString() == "未审核")
                {
                    string[] sqls = new string[2];
                    sqls[0] = "delete from T_TEMPPLATE where tid=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    sqls[1] = "delete from T_TEMPPLATE_CONT where tid=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    if (App.Ask("确定要删除'" + dataGridViewX1["名称", SelRowIndex].Value.ToString() + "'的模板吗？"))
                    {
                        if (App.ExecuteBatch(sqls) > 0)
                        {
                            if (dataGridViewX1.Rows.Count > 0)
                            {
                                dataGridViewX1.Rows[0].Selected = true;
                                SelRowIndex = 0;
                            }
                            GetTemplateListUnCheck();
                            TempLateEditor.MyDoc.Modified = false;
                        }
                    }
                }
                else
                {
                    App.MsgWaring("请先将模板“撤销审核”，再进行删除！");
                }
            }
        }

        private void dataGridViewX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewX1.ClearSelection();
                    dataGridViewX1.Rows[e.RowIndex].Selected = true;
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_name == "医务科主任" || App.UserAccount.CurrentSelectRole.Role_name == "医务科副主任")
            {
                if (dataGridViewX1.Columns[e.ColumnIndex].HeaderCell.Value.ToString() == "医务科审核")
                {
                    string flag = "Y";
                    if (e.RowIndex == -1){return;}
                    if (dataGridViewX1["医务科审核", SelRowIndex].Value.ToString() == "已审核")
                    {
                        flag = "N";
                    }
                    string sql = "update T_TEMPPLATE set mamagechek='" + flag + "' where TID=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        if (flag == "Y")
                            dataGridViewX1["医务科审核", SelRowIndex].Value = "已审核";
                        else
                            dataGridViewX1["医务科审核", SelRowIndex].Value = "未审核";

                        RefleshRowColor();
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }
                }
            }
            else
            {
                if (dataGridViewX1.Columns[e.ColumnIndex].HeaderCell.Value.ToString() == "审核标记")
                {
                    string flag = "Y";
                    if (dataGridViewX1["审核标记", SelRowIndex].Value.ToString() == "已审核")
                    {
                        flag = "N";
                    }
                    string sql = "update T_TEMPPLATE set SECTIONCHEK='" + flag + "' where TID=" + dataGridViewX1["编号", SelRowIndex].Value.ToString() + "";
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        if (flag == "Y")
                            dataGridViewX1["审核标记", SelRowIndex].Value = "已审核";
                        else
                            dataGridViewX1["审核标记", SelRowIndex].Value = "未审核";

                        RefleshRowColor();
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }
                }
            }

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTemplateListUnCheck();
            dataGridViewX1.ClearSelection();
            dataGridViewX1.Rows[SelRowIndex].Selected = true;
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            dataGridViewX1.ClearSelection();
            for(int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell newColumn = (DataGridViewCheckBoxCell)dataGridViewX1.Rows[i].Cells[0];
                if(newColumn.Value != null)
                {
                    if((bool)newColumn.Value == true)
                    {
                        newColumn.Value = false;
                    }
                    else
                    {
                        newColumn.Value = true;
                    }
                }
                else
                {
                    newColumn.Value = true;
                }
            }
           
        }

        private void btnSerach_Click(object sender, EventArgs e)
        {
            GetTemplateListUnCheck();
        }

        //private string current_id = "";   //获取当前选中模版的ID

        private void 模板重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1["编号", SelRowIndex].Value.ToString() != "编号")
            {
                string current_id = dataGridViewX1["编号", SelRowIndex].Value.ToString();   //获取当前选中模版的ID
                frmRenameTemplateCheck renameTemplate = new frmRenameTemplateCheck(current_id);
                App.FormStytleSet(renameTemplate, false);
                renameTemplate.Show();
            }

        }
    }
}
