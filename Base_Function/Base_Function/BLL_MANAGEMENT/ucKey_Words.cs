using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucKey_Words : UserControl
    {
        public ucKey_Words()
        {
            InitializeComponent();
        }
        bool isUpdate = false;
        string OperationID = "";
        DataSet ds;
        private void SetflgViewData()
        {
            try
            {
                string sql = "select rownum as 序号,t.id,t.key_complaint 主诉关键字,t.key_diagnose 诊断关键字 from T_KEY_WORDS t";
                this.ucGridviewX1.DataBd(sql, "序号", true, "", "");
                ucGridviewX1.fg.Columns["id"].Visible = false;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch (System.Exception ex)
            {

            }

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string key = this.txtKey.Text.Trim();
            if (key == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = @"select t.id,t.key_complaint 主诉关键字,t.key_diagnose 诊断关键字 from T_KEY_WORDS t where  instr(key_complaint,'{0}')>0 
                                union
                                select t.id,t.key_complaint 主诉关键字,t.key_diagnose 诊断关键字 from T_KEY_WORDS t where  instr(key_diagnose,'{0}')>0";
                sql = string.Format("select rownum as 序号,t.* from (" + sql + ") t", key);
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "序号", true, "", "");
                    ucGridviewX1.fg.Columns["id"].Visible = false;
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                OperationID = "";
                txtKEY_COMPLAINT.Enabled = false;
                txtKEY_DIAGNOSE.Enabled = false;
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    OperationID = ucGridviewX1.fg["id", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtKEY_COMPLAINT.Text = ucGridviewX1.fg["主诉关键字", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtKEY_DIAGNOSE.Text = ucGridviewX1.fg["诊断关键字", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void ucKey_Words_Load(object sender, EventArgs e)
        {
            this.txtKEY_COMPLAINT.Enabled = false;
            this.txtKEY_DIAGNOSE.Enabled = false;

            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            this.txtKEY_COMPLAINT.Text="";
            this.txtKEY_DIAGNOSE.Text = "";
            this.txtKEY_COMPLAINT.Enabled = true;
            this.txtKEY_DIAGNOSE.Enabled = true;

            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isUpdate = true;

            this.txtKEY_COMPLAINT.Enabled = true;
            this.txtKEY_DIAGNOSE.Enabled = true;

            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperationID=="")
                {
                    return;
                }
                string deletesql = "delete T_KEY_WORDS where id='" + OperationID + "'";

                if (App.Ask("您确定要删除吗？"))
                {
                    if (App.ExecuteSQL(deletesql) > 0)
                    {
                        App.Msg("删除成功！");
                       
                        ShowEClear();

                        SetflgViewData();
                    }
                    else
                    {
                        App.MsgErr("删除失败，请检查是否有此记录或者关闭后再试");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 非编辑状态
        /// </summary>
        private void ShowEClear()
        {
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;

            this.txtKEY_COMPLAINT.Enabled = false;
            this.txtKEY_DIAGNOSE.Enabled = false;
            txtKEY_COMPLAINT.Text = "";
            txtKEY_DIAGNOSE.Text = "";
            OperationID = "";
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string KEY_COMPLAINT = txtKEY_COMPLAINT.Text;
                string KEY_DIAGNOSE = txtKEY_DIAGNOSE.Text;
                string sql = "";
                if (!isUpdate)
                {//新增
                    string maxid = App.ReadSqlVal("select max(id)+1 maxid from t_key_words", 0, "maxid");
                    if (maxid == "")
                        maxid = "1";
                    sql = string.Format("insert into t_key_words (id,key_complaint,key_diagnose) values({0},'{1}','{2}')",
                                        maxid, KEY_COMPLAINT, KEY_DIAGNOSE);
                }
                else
                {//修改
                    if (OperationID == "")
                    {
                        return;
                    }
                    sql = string.Format("update t_key_words set key_complaint='{1}',key_diagnose='{2}' where id={0} ",
                                      OperationID, KEY_COMPLAINT, KEY_DIAGNOSE);
                }
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("操作成功！");

                    ShowEClear();

                    SetflgViewData();
                }
                else
                {
                    App.MsgErr("操作失败，请检查值是否正确！");
                }
            }
            catch (System.Exception ex)
            {
                App.MsgErr("操作异常！");
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancel_Click(object sender, EventArgs e)
        {
            ShowEClear();
        }
    }
}
