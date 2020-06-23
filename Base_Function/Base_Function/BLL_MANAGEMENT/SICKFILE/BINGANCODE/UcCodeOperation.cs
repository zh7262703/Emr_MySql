using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// 设计者：连伟
    /// 时  间：2017/02/26
    /// </summary>
    public partial class UcCodeOperation : UserControl
    {
        string Pid = "";
        private DataTable dt;
        /// <summary>
        /// 默认构造器
        /// </summary>
        public UcCodeOperation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">传值 住院号</param>
        public UcCodeOperation(string pid)
        {
            InitializeComponent();
            Pid = pid;
            Operation();
            DataInit.A_btnSave_Operation = null;
            DataInit.A_btnSave_Operation = new EventHandler(btn_tj_Click);
            DataInit.A_UP_ = null;
            DataInit.A_UP_ = new EventHandler(buttonX1_Click);
            DataInit.A_Next_ = null;
            DataInit.A_Next_ = new EventHandler(buttonX2_Click);
        }
        /// <summary>
        /// 查询手术信息
        /// </summary>
        private void Operation()
        {
            //左侧数据源
            string Sql = @"select oper_name 手术操作名称,oper_code 操作编码,oper_date 操作日期,operator 手术操作人,id ID,o_number 序号 from cover_operation where inpatient_id='" + Pid + "' order by 序号 asc";
            DataSet ds1 = App.GetDataSet(Sql);
            this.dgv_1.DataSource = ds1.Tables[0].DefaultView;
            for (int i = 0; i < this.dgv_1.Columns.Count; i++)
            {
                this.dgv_1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //右侧数据源
            DataSet ds2 = App.GetDataSet(Sql);
            dt = App.GetDataSet(Sql).Tables[0];
            this.dgv_2.DataSource = ds2.Tables[0].DefaultView;
            for (int i = 0; i < this.dgv_2.Columns.Count; i++)
            {
                this.dgv_2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_1.Columns[5].Visible = false;
            dgv_2.Columns[5].Visible = false;
        }
        /// <summary>
        /// 双击编辑表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_2_DoubleClick(object sender, EventArgs e)
        {
            dgv_2.ReadOnly = false;
            foreach (DataGridViewColumn col in dgv_2.Columns)
            {
                if (col.Name == "操作编码")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        private DataGridViewTextBoxEditingControl dgvBoxEditingControl;
        private void dgv_2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvBoxEditingControl = (DataGridViewTextBoxEditingControl)e.Control;
            dgvBoxEditingControl.KeyUp += new KeyEventHandler(dgvBoxEditingControl_KeyUp);
        }
        void dgvBoxEditingControl_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.ReadOnly == true)
                return;
            App.FastCodeFlag = false;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
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
                else if (e.KeyCode == Keys.Enter)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            DataInit.O_Edite = true;
                            App.SelectObj = null;
                            int length = text.Length;
                            string sql_select = "";
                            sql_select = "select code 手术编码,name 手术名称 from oper_def_icd9  where 1=1 and upper(code) like '%" + text.ToUpper() + "%'";
                            string BABM = "";
                            App.FastCodeCheck(sql_select, txtBox, "手术编码", "手术名称", BABM);
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 监听消息钩子
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {

            if (keyData == Keys.Down || keyData == Keys.Up)　　//监听 上、下 事件　
            {
                if (this.dgv_2.IsCurrentCellInEditMode)　　//如果当前单元格处于编辑模式　
                {
                    return true;
                }
            }
            //继续原来base.ProcessCmdKey中的处理　
            return base.ProcessCmdKey(ref　msg, keyData);
        }
        /// <summary>
        /// 提交 手术
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tj_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 * T_IN_Code_Information 编目信息表
                 * ID
                 * 编目状态
                 * 编目人
                 * 编目时间
                 * 住院号
                 */
                //TODO:
                string User_Id = App.UserAccount.UserInfo.User_id;
                List<string> ls_name = new List<string>();//存储dgv_1中的手术操作名称
                List<string> ls_ID = new List<string>();//存储dgv_1中的主键ID
                List<string> ls_code = new List<string>();
                List<string> ls_time = new List<string>();
                List<string> ls_operationor = new List<string>();
                List<string> ls_xh = new List<string>();

                DataInit.Count = 0;
                DataInit.Count_xh = 0;
                for (int i = 0; i < dgv_1.Rows.Count; i++)
                {
                    string operationName = dgv_1.Rows[i].Cells["手术操作名称"].Value.ToString();
                    string iid = dgv_1.Rows[i].Cells["ID"].Value.ToString();
                    string operationCode = dgv_1.Rows[i].Cells["操作编码"].Value.ToString();
                    string operationTime = dgv_1.Rows[i].Cells["操作日期"].Value.ToString();
                    string operationor = dgv_1.Rows[i].Cells["手术操作人"].Value.ToString();
                    string xh = dgv_1.Rows[i].Cells["序号"].Value.ToString();

                    ls_name.Add(operationName);
                    ls_ID.Add(iid);
                    ls_code.Add(operationCode);
                    ls_time.Add(operationTime);
                    ls_operationor.Add(operationor);
                    ls_xh.Add(xh);
                }
                List<string> ls_2_icd10 = new List<string>();//存储dgv_2中的编码
                List<string> ls_2_ID = new List<string>();//存储dgv_2中的主键ID
                List<string> ls_2_xh= new List<string>();//存储dgv_2中的主键ID
                for (int i = 0; i < dgv_2.Rows.Count; i++)
                {
                    string icd10_2_operationor = dgv_2.Rows[i].Cells["操作编码"].Value.ToString();
                    string ID_2_operationor = dgv_2.Rows[i].Cells["ID"].Value.ToString();
                    string xh_2 = dgv_2.Rows[i].Cells["序号"].Value.ToString();
                    ls_2_icd10.Add(icd10_2_operationor);
                    ls_2_ID.Add(ID_2_operationor);
                    ls_2_xh.Add(xh_2);
                }
                for (int k = 0; k < ls_code.Count; k++)
                {
                    if (ls_code[k].ToString() != ls_2_icd10[k].ToString() && ls_ID[k].ToString() == ls_2_ID[k].ToString())
                    {
                        DataInit.Count++;
                        int _ID = App.GenId();
                        int ID_ = App.GenId();
                        string operationCode_Befor = ls_code[k].ToString();//之前的诊断编码
                        string operationCode_After = ls_2_icd10[k].ToString();//之后的诊断编码
                        string iid = ls_2_ID[k].ToString();//与首页手术表主键相关联的ID
                        string befor = "修改前"; string after = "修改后";
                        /*
                         * 1.先插入之前的手术信息
                         * 2.再插入新的手术信息
                         * 3.更新cover_operation中的诊断信息
                         * **/
                        string Sql_Operation_Befor = "insert into T_IN_Code_Operation(ID,PATIENT_ID,operationname,operationcode,operationtime,operator,user_id,iid,key_id,befororafter )values('" + _ID + "','" + Pid + "','" + ls_name[k].ToString() + "','" + operationCode_Befor + "',to_date('" + ls_time[k].ToString() + "','yyyy-MM-dd hh24:mi:ss'),'" + ls_operationor[k].ToString() + "','" + User_Id + "','" + iid + "','" + DataInit.ID + "','" + befor + "')";
                        App.ExecuteSQL(Sql_Operation_Befor);//1

                        string Sql_Operation_After = "insert into T_IN_Code_Operation(ID,PATIENT_ID,operationname,operationcode,operationtime,operator,user_id,iid,key_id,befororafter )values('" + ID_ + "','" + Pid + "','" + ls_name[k].ToString() + "','" + operationCode_After + "',to_date('" + ls_time[k].ToString() + "','yyyy-MM-dd hh24:mi:ss'),'" + ls_operationor[k].ToString() + "','" + User_Id + "','" + iid + "','" + DataInit.ID + "','" + after + "')";
                        App.ExecuteSQL(Sql_Operation_After);//2

                        string Sql_Update = "update cover_operation set oper_code='" + operationCode_After + "' where id='" + iid + "'";//3
                        App.ExecuteSQL(Sql_Update);
                    }
                    if (ls_xh[k].ToString() != ls_2_xh[k].ToString())
                    {
                        DataInit.Count_xh++;
                        string iid = ls_2_ID[k].ToString();//与首页手术表主键相关联的ID
                        string xh_2 = ls_2_xh[k].ToString();
                        string Sql_Update = "update cover_operation set o_number='" + xh_2 + "' where id='" + iid + "'";
                        App.ExecuteSQL(Sql_Update);
                    }
                }
                //App.Msg("提交成功!");
                Operation();
                ls_name = null;
                ls_ID = null;
                ls_code = null;
                ls_time = null;
                ls_operationor = null;
                ls_2_icd10 = null;
                ls_2_ID = null;
            }
            catch (Exception)
            {
                App.MsgErr(e.ToString());
            }
        }
        /// <summary>
        /// 事件 buttonX1_Click
        /// 名字不做改动
        /// 承载界面委托调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            int rowIndex = dgv_2.SelectedRows[0].Index;  //得到当前选中行的索引     
            dgv_1.Rows[0].Selected = false;
            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了!");
                return;
            }
            List<string> list = new List<string>();
            List<string> list_ = new List<string>();
            for (int i = 0; i < dgv_2.Columns.Count; i++)
            {
                list.Add(dgv_2.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中  
                list_.Add(dgv_2.Rows[rowIndex - 1].Cells[i].Value.ToString());
            }
            for (int j = 0; j < dgv_2.Columns.Count; j++)
            {
                if (j < 5 )
                {
                    dgv_2.Rows[rowIndex].Cells[j].Value = dgv_2.Rows[rowIndex - 1].Cells[j].Value;
                    dgv_2.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                else
                {
                    dgv_2.Rows[rowIndex].Cells[j].Value = list[j].ToString();
                    dgv_2.Rows[rowIndex - 1].Cells[j].Value = list_[j].ToString();
                }
            }
            dgv_2.Rows[rowIndex - 1].Selected = true;
            dgv_2.Rows[rowIndex].Selected = false;
            this.dgv_2.Refresh();

            List<string> list2 = new List<string>();
            List<string> list_2 = new List<string>();
            for (int h = 0; h < dgv_1.Columns.Count; h++)
            {
                list2.Add(dgv_1.Rows[rowIndex].Cells[h].Value.ToString());   //把当前选中行的数据存入list数组中  
                list_2.Add(dgv_1.Rows[rowIndex - 1].Cells[h].Value.ToString());
            }
            for (int l = 0; l < dgv_1.Columns.Count; l++)
            {
                dgv_1.Rows[rowIndex].Cells[l].Value = dgv_1.Rows[rowIndex - 1].Cells[l].Value;
                dgv_1.Rows[rowIndex - 1].Cells[l].Value = list2[l].ToString();
            }
            dgv_1.Rows[rowIndex - 1].Selected = false;
            dgv_1.Rows[rowIndex].Selected = false;
            this.dgv_1.Refresh();
            DataInit.O_UpOrNext = true;
        }
        /// <summary>
        /// 事件 buttonX2_Click
        /// 名字不做改动
        /// 承载界面委托调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            int rowIndex = dgv_2.SelectedRows[0].Index;  //得到当前选中行的索引     
            dgv_1.Rows[0].Selected = false;
            if (rowIndex == dgv_2.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!");
                return;
            }
            List<string> list = new List<string>();
            List<string> list_ = new List<string>();
            for (int i = 0; i < dgv_2.Columns.Count; i++)
            {
                list.Add(dgv_2.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中  
                list_.Add(dgv_2.Rows[rowIndex + 1].Cells[i].Value.ToString());
            }

            for (int j = 0; j < dgv_2.Columns.Count; j++)
            {
                if (j < 5)
                {
                    dgv_2.Rows[rowIndex].Cells[j].Value = dgv_2.Rows[rowIndex + 1].Cells[j].Value;
                    dgv_2.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                else
                {
                    dgv_2.Rows[rowIndex].Cells[j].Value = list[j].ToString();
                    dgv_2.Rows[rowIndex + 1].Cells[j].Value = list_[j].ToString();
                }
            }
            dgv_2.Rows[rowIndex + 1].Selected = true;
            dgv_2.Rows[rowIndex].Selected = false;
            this.dgv_2.Refresh();

            List<string> list2 = new List<string>();
            List<string> list_2 = new List<string>();
            for (int h = 0; h < dgv_1.Columns.Count; h++)
            {
                list2.Add(dgv_1.Rows[rowIndex].Cells[h].Value.ToString());   //把当前选中行的数据存入list数组中  
                list_2.Add(dgv_1.Rows[rowIndex + 1].Cells[h].Value.ToString());
            }
            for (int l = 0; l < dgv_1.Columns.Count; l++)
            {
                dgv_1.Rows[rowIndex].Cells[l].Value = dgv_1.Rows[rowIndex + 1].Cells[l].Value;
                dgv_1.Rows[rowIndex + 1].Cells[l].Value = list2[l].ToString();
            }
            dgv_1.Rows[rowIndex + 1].Selected = false;
            dgv_1.Rows[rowIndex].Selected = false;
            this.dgv_1.Refresh();
            DataInit.O_UpOrNext = true;
        }
    }
}
