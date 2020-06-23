using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class ucCDiagDict : UserControl
    {
        public ucCDiagDict()
        {
            InitializeComponent();
            this.rbBM.Checked = true;
        }
        
        DataSet ds;
        string sql = "";
        string oldname = "";
        private void SetflgViewData()
        {
            ds = App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql, "名称", false, "", "");
                ucGridviewX1.fg.Columns[0].Width = 200;
                ucGridviewX1.fg.Columns[1].Width = 100;
                ucGridviewX1.fg.Columns[2].Width = 100;
                ucGridviewX1.fg.ReadOnly = true;
            }
        }

        private void rbBM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBM.Checked == true)
            {
                sql = "select a.bm_name as 名称,a.bm_code as 编码,a.py as 拼音,a.wb as 五笔 from t_bm a";
                sql += " where a.bm_name like '%" + txtVindicateName.Text + "%'";
                sql += " or a.py like '%" + txtVindicateName.Text.ToUpper() + "%'";
            }
            SetflgViewData();
        }

        private void rbZH_CheckedChanged(object sender, EventArgs e)
        {
            if (rbZH.Checked == true)
            {
                sql = "select a.zh_name as 名称,a.zh_code as 编码,a.py as 拼音,a.wb as 五笔 from t_zh a";
                sql += " where a.zh_name like '%" + txtVindicateName.Text + "%'";
                sql += " or a.py like '%" + txtVindicateName.Text.ToUpper() + "%'";
            }
            SetflgViewData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SetflgViewData();
        }

        private void txtVindicateName_TextChanged(object sender, EventArgs e)
        {
            if (rbBM.Checked == true)
            {
                sql = "select a.bm_name as 名称,a.bm_code as 编码,a.py as 拼音,a.wb as 五笔 from t_bm a";
                sql += " where a.bm_name like '%" + txtVindicateName.Text + "%'";
                sql += " or a.py like '%" + txtVindicateName.Text.ToUpper() + "%'";
            }
            else
            {
                sql = "select a.zh_name as 名称,a.zh_code as 编码,a.py as 拼音,a.wb as 五笔 from t_zh a";
                sql += " where a.zh_name like '%" + txtVindicateName.Text + "%'";
                sql += " or a.py like '%" + txtVindicateName.Text.ToUpper() + "%'";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ucCDiagDict_Load(object sender, EventArgs e)
        {
            SetflgViewData();
            this.ucGridviewX1.fg.CurrentCellChanged+=new EventHandler(fg_CurrentCellChanged);
        }
        bool isDelectUpdate = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtName.ReadOnly = false;
            this.txtDiaselogCode.ReadOnly = false;
            ShowEClear();
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            isDelectUpdate = true;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            btncancel.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                App.Msg("您没有要修改的信息");
                return;
            }
            oldname = txtName.Text;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            this.btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            this.txtName.ReadOnly = false;
            isDelectUpdate = false;
            this.btncancel.Enabled = true;
            //this.btnUpdate.Enabled = false;
            txtDiaselogCode.ReadOnly = false;
            this.btnDelete.Enabled = false;
            txtDiaselogCode.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string deletesql = "delete from ";
                if (rbBM.Checked == true)
                {
                    deletesql += " t_bm where bm_name='" + txtName.Text + "'";
                }
                else
                {
                    deletesql += " t_zh where zh_name='" + txtName.Text + "'";
                }
                if (App.Ask("您确定要删除吗？"))
                {
                    if (App.ExecuteSQL(deletesql) > 0)
                    {
                        App.Msg("删除成功！");
                        SetflgViewData();
                        this.btncancel.Enabled = true;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnconfirm.Enabled = false;
                        this.btncancel.Enabled = false;

                        ShowEClear();
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

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDelectUpdate == true)
                {
                    string name = this.txtName.Text.Trim();
                    string spellcode = this.txtspellcode.Text.Trim();
                    string fivecode = this.txtfivecode.Text.Trim();
                    string diaselogCode = this.txtDiaselogCode.Text.Trim();                                                   //cotelog
                    string insertsql = "";
                    if (rbBM.Checked == true)
                    {
                        insertsql = "insert into t_bm(bm_name,bm_code,py,wb)values('" + name + "','" + diaselogCode + "','"
                        + spellcode + "','" + fivecode + "')";
                    }
                    else
                    {
                        insertsql = "insert into t_zh(zh_name,zh_code,py,wb)values('" + name + "','" + diaselogCode + "','"
                        + spellcode + "','" + fivecode + "')";
                    }
                    if (App.ExecuteSQL(insertsql) > 0)
                    {
                        App.Msg("添加成功！");
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        SetflgViewData();
                        btnAdd.Enabled = true;
                        this.btncancel.Enabled = false;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        btnconfirm.Enabled = false;
                        ShowEClear();
                    }
                    else
                    {
                        App.MsgErr("添加失败，请检查值是否为空！");
                    }
                }
                else
                {
                    string spellcode = App.getSpell(this.txtName.Text.Trim());
                    string fivecode = App.GetWBcode(this.txtName.Text.Trim());
                    string [] sqls=new string [2];
                    if (rbBM.Checked == true)
                    {
                        sqls[0] = "delete from t_bm where bm_name='" + oldname + "'";
                        sqls[1] = "insert into t_bm(bm_name,bm_code,py,wb)values('" + txtName.Text + "','" + txtDiaselogCode.Text + "','"
                        + txtspellcode.Text + "','" + txtfivecode.Text + "')";
                    }
                    else
                    {
                        sqls[0] = "delete from t_zh where zh_name='" + oldname + "'";
                        sqls[1] = "insert into t_zh(zh_name,zh_code,py,wb)values('" + txtName.Text + "','" + txtDiaselogCode.Text + "','"
                        + txtspellcode.Text + "','" + txtfivecode.Text + "')";
                    }
                    if (App.ExecuteBatch(sqls) > 0)
                    {
                        App.Msg("修改成功");
                        SetflgViewData();
                        this.btncancel.Enabled = false;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnconfirm.Enabled = false;
                        this.btncancel.Enabled = false;
                        btnAdd.Enabled = true;
                        ShowEClear();
                    }
                    else
                    {
                        App.MsgErr("修改失败，请检查是否有此记录或者关闭后再试");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            this.txtName.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btncancel.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            txtDiaselogCode.Enabled = false;
            ShowEClear();
        }

        private void ShowEClear()
        {
            txtName.Text = "";
            txtspellcode.Text = "";
            txtfivecode.Text = "";
            txtDiaselogCode.Text = "";
        }

        private void fg_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg == null||ucGridviewX1.fg.CurrentCell==null)
                return;
            if (ucGridviewX1.fg.CurrentCell.RowIndex >= 0)
            {
                this.txtName.Text = ucGridviewX1.fg.CurrentRow.Cells["名称"].Value.ToString();
                this.txtDiaselogCode.Text = ucGridviewX1.fg.CurrentRow.Cells["编码"].Value.ToString();
                this.txtfivecode.Text = ucGridviewX1.fg.CurrentRow.Cells["五笔"].Value.ToString();
                this.txtspellcode.Text = ucGridviewX1.fg.CurrentRow.Cells["拼音"].Value.ToString();
            }
            else
            {
                this.txtName.Text = "";
                this.txtDiaselogCode.Text = "";
                this.txtfivecode.Text = "";
                this.txtspellcode.Text = "";
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtName.ReadOnly == false)
            {
                this.txtspellcode.Text = App.getSpell(txtName.Text);
                this.txtfivecode.Text = App.GetWBcode(txtName.Text);
            }
        }
    }
}
