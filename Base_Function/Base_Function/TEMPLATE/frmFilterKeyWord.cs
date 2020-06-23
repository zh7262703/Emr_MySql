using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    public partial class frmFilterKeyWord : DevComponents.DotNetBar.Office2007Form
    {
        private string T_tempplate_filter_Sql;//查询过滤表
        private int id;//对应数据库中的ID字段
        private bool IsState;//用于区分增加和修改
        

        public frmFilterKeyWord()
        {
            InitializeComponent();
            T_tempplate_filter_Sql = "select ID ,Source_word,Target_word,"+
            @"case when Enable_Flag='Y' then '有效' else '无效' end Enable_Flag from t_tempplate_filter";
        }

        /// <summary>
        /// 新增关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            IsState = true;
            EnableControl(IsState);
          
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableControl(false);
        }

      

        /// <summary>
        /// 用于操作按钮与文本框的可用性
        /// </summary>
        /// <param name="bol">true：代表新增；false：代表初始化</param>
        private void EnableControl(Boolean bol)
        {

            this.txtSourceWord.Enabled = bol;
            this.txtTargetWord.Enabled = bol;
            this.btnNew.Enabled = bol ? false : true;
            this.btnSave.Enabled = bol;
            this.btnDel.Enabled = false;
            this.btnCancel.Enabled = bol;
            this.chkIsEnable.Enabled = bol;
            this.btnUpdate.Enabled =false;
            this.txtSourceWord.Text = "";
            this.txtTargetWord.Text = "";
            this.chkIsEnable.Checked = false;
            this.ucC1FlexGrid1.Enabled = bol ? false : true;
        }

        private void frmFilterKeyWord_Load(object sender, EventArgs e)
        {
            ucC1FlexGrid1.DataBd(T_tempplate_filter_Sql, "ID", "ID,Source_word,Target_word,Enable_Flag", "序号,源词,目标词,是否有效");
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
        }

        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid1.fg.RowSel >= 0)
            {
                this.id = Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString());
                this.txtSourceWord.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "Source_word"].ToString();
                this.txtTargetWord.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "Target_word"].ToString();
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "Enable_Flag"].ToString() == "有效")
                {
                    this.chkIsEnable.Checked = true;
                }
                else
                {
                    this.chkIsEnable.Checked = false;
                }

                this.btnDel.Enabled = true;
                this.btnUpdate.Enabled = true;
            }
        }


        /// <summary>
        /// 保存关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = App.GenId("t_tempplate_filter", "id");
            string sourceWord = this.txtSourceWord.Text;//源词
            string targetWord = this.txtTargetWord.Text;//目标词
            char isEnable; ;//是否有效

            if (sourceWord == "")
            {
                MessageBox.Show("请输入源词");
                this.txtSourceWord.Focus();
            }
            else if (targetWord == "")
            {
                MessageBox.Show("请输入目标词");
                this.txtTargetWord.Focus();
            }
            else
            {
                if (chkIsEnable.Checked == true)
                {
                    isEnable = 'Y';
                }
                else
                {
                    isEnable = 'N';
                }

                if (IsState)
                {
                    if (!IsExist(sourceWord))
                    {
                        string temp = "insert into t_tempplate_filter values(" + id + ",'" + sourceWord + "','" + targetWord + "','" + isEnable + "')";
                        int i = App.ExecuteSQL(temp);
                        if (i > 0)
                        {
                            App.Msg("添加成功！");
                            EnableControl(false);
                            string Sql = T_tempplate_filter_Sql;
                            ucC1FlexGrid1.DataBd(Sql, "ID", "ID,Source_word,Target_word,Enable_Flag", "序号,源词,目标词,是否有效");

                        }
                        else
                        {
                            App.MsgErr("添加失败！");
                        }                       
                    }
                    else
                    {
                        App.MsgErr("该源词已存在！");
                        this.txtSourceWord.Focus();
                        this.txtSourceWord.Text = "";
                        return;
                    }
                }
                else
                {
                    id =Convert.ToInt32(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString());
                    string temp = "update t_tempplate_filter set "+
                        @"Source_word='"+sourceWord+
                        @"',Target_word='"+targetWord+
                        @"',Enable_Flag='"+isEnable+
                        @"' where id="+id+"";
                    int i=App.ExecuteSQL(temp);
                    if (i > 0)
                    {
                        App.Msg("修改成功！");
                        EnableControl(false);
                        string Sql = T_tempplate_filter_Sql;
                        ucC1FlexGrid1.DataBd(Sql, "ID", "ID,Source_word,Target_word,Enable_Flag", "序号,源词,目标词,是否有效");

                    }
                    else
                    {
                        App.MsgErr("修改失败！");
                    }
                }
              
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                string sqlDel = "delete from t_tempplate_filter where ID=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"];
                int i = App.ExecuteSQL(sqlDel);
                if (i > 0)
                {
                    App.Msg("删除成功！");
                    frmFilterKeyWord_Load(sender, e);
                    EnableControl(false);
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.txtSourceWord.Enabled = true;
            this.txtTargetWord.Enabled = true;
            this.chkIsEnable.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnDel.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnSave.Enabled = true;
            IsState = false;
            
        }

        /// <summary>
        /// 判断是否存在源词
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private bool IsExist(string temp)
        {
            string flag="select Source_word from t_tempplate_filter where Source_word ='" + temp+"'";
            DataSet ds = App.GetDataSet(flag);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
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
                return false;
            }
        }      
       
    }
}