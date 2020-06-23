using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Bifrost.SYSTEMSET
{
    public partial class frmMsg : DevComponents.DotNetBar.Office2007Form
    {
        private bool flagAdd = false;
        private string ID = ""; //当前选择记录的主键
        public frmMsg()
        {
            InitializeComponent();
        }

        private void frmMsg_Load(object sender, EventArgs e)
        {            
            cboType.SelectedIndex = 0;
            enableEdit(false);
            btnSearch_Click(sender, e);
        }

        private void enableEdit(bool flag)
        {
            if (flag)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;                
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
            btnDelete.Enabled = flag;
            txtName.Enabled = flag;
            txtUrl.Enabled = flag;
            cboType.Enabled = flag;
            txtContent.Enabled = flag;
            chkIsEnable.Enabled = flag;
            btnSure.Enabled = flag;
            btnCancel.Enabled = flag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            txtName.Text = "";
            txtContent.Text = "";
            enableEdit(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flagAdd = false;
            enableEdit(true);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string sql = "";           
            string mtype = "A";
            if (cboSearchType.SelectedText == "医生")
            {
                mtype = "D";
            }
            else if (cboSearchType.SelectedText == "护士")
            {
                mtype = "N";
            }
            string enable="Y";
            if (!chkIsEnable.Checked)
            {
                enable = "N";
            }            
            if (flagAdd)
            { 
                int AId = App.GenId("T_PUBLIC_MESSAGE", "id");

                txtUrl.Text = @"http://175.16.8.95/WebSite2/Default_Notiece.aspx?MsgId=" + AId.ToString() + "";
                //添加
                sql = "insert into T_PUBLIC_MESSAGE(id,msg_name,content,Msg_Type,ENDABLE,URL)values(" + AId + ",'" + txtName.Text + "','" + txtContent.Text + "','" + mtype + "','"+enable+"','"+txtUrl.Text+"')";
            }
            else
            {
                //修改
                sql = "update T_PUBLIC_MESSAGE set msg_name='" + txtName.Text + "',content='" + txtContent.Text + "',Msg_Type='" + mtype + "',ENDABLE='" + enable + "',Url='" + txtUrl.Text + "' where id=" + ID + "";
            }
            if (App.ExecuteSQL(sql) > 0)
            {
                App.Msg("操作成功！");
                btnSearch_Click(sender, e);
            }
            else
            {
                App.MsgErr("操作失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            enableEdit(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string mtype = "A";
                if (cboSearchType.SelectedText == "医生")
                {
                    mtype = "D";
                }
                else if (cboSearchType.SelectedText == "护士")
                {
                    mtype = "N";
                }
                string Sql = "select id as 主键,t.msg_name as 名称,t.content as 内容,t.msg_type as 类型,t.ENDABLE as 状态,t.url as 路径 from T_PUBLIC_MESSAGE t where t.msg_name like '%" + txtSearchName.Text + "%' and t.msg_type='" + mtype + "'";
                DataSet ds = App.GetDataSet(Sql);

                dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
                dataGridViewX1.Refresh();
            }
            catch(Exception ex)
            {
                App.MsgErr("查询失败！原因:"+ex.Message);
            }
            
        }

        private void dataGridViewX1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ID = dataGridViewX1["主键", dataGridViewX1.CurrentRow.Index].Value.ToString();
                txtName.Text = dataGridViewX1["名称", dataGridViewX1.CurrentRow.Index].Value.ToString();
                txtContent.Text = dataGridViewX1["内容", dataGridViewX1.CurrentRow.Index].Value.ToString();
                
                if (dataGridViewX1["类型", dataGridViewX1.CurrentRow.Index].Value.ToString() == "A")
                {
                    cboType.Text = "A";
                }
                else if (dataGridViewX1["类型", dataGridViewX1.CurrentRow.Index].Value.ToString() == "D")
                {
                    cboType.Text = "D";
                }
                else
                {
                    cboType.Text = "N";
                }

                if (dataGridViewX1["状态", dataGridViewX1.CurrentRow.Index].Value.ToString() == "Y")
                {
                    chkIsEnable.Checked=true;
                }
                else
                {
                    chkIsEnable.Checked = false;
                }

                txtUrl.Text = dataGridViewX1["路径", dataGridViewX1.CurrentRow.Index].Value.ToString();

            }
            catch(Exception ex)
            {
                App.MsgErr("请先选择记录行！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string aid=dataGridViewX1["主键", dataGridViewX1.CurrentRow.Index].Value.ToString();
                string xname=dataGridViewX1["名称", dataGridViewX1.CurrentRow.Index].Value.ToString();
                if (App.Ask("确定要删除" + xname + "的记录吗？"))
                {
                    if (App.ExecuteSQL("delete from T_PUBLIC_MESSAGE where id=" + aid + "") > 0)
                    {
                        App.Msg("操作成功！");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        App.MsgErr("操作失败！");
                    }
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("操作失败！原因"+ex.Message);
            }
        }

        private void lblGenUrl_Click(object sender, EventArgs e)
        {
            txtUrl.Text = @"http://175.16.8.180:81/WebSite2/Default_Notiece.aspx?MsgId=" + ID + "";
        }
    }
}