using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class frmJobLeverSet : DevComponents.DotNetBar.Office2007Form
    {
        private bool isAdd = false;  //true ���   false �޸�

        public frmJobLeverSet()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// ��ʼ��ֵ
        /// </summary>
        private void iniCboData(int dtype)
        {


            if (dtype == 1)
            {
                DataSet ds = App.GetDataSet("select t.role_id,t.role_name from t_role t where t.role_type='D'");
                cboJobRole.DataSource = ds.Tables[0].DefaultView;
                cboJobRole.DisplayMember = "role_name";
                cboJobRole.ValueMember = "role_id";
            }
            else if (dtype == 2)
            {
                DataSet ds = App.GetDataSet("select t.role_id,t.role_name from t_role t where t.role_type='N'");
                cboJobRole.DataSource = ds.Tables[0].DefaultView;
                cboJobRole.DisplayMember = "role_name";
                cboJobRole.ValueMember = "role_id";
            }
            else if (dtype == 3 || dtype == 4)
            {
                DataSet ds = App.GetDataSet("select id,name from t_data_code aa where aa.type=1");
                cboJobRole.DataSource = ds.Tables[0].DefaultView;
                cboJobRole.DisplayMember = "name";
                cboJobRole.ValueMember = "id";
            }

            if (cboJobRole.Items.Count > 0)
            {
                cboJobRole.SelectedIndex = 0;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //�������Ĳ������ּ���Ҳ���ǻس�����Backspace������ȡ��������
            if (!(Char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
            } 
        }

        /// <summary>
        /// ���ñ༭״̬
        /// </summary>
        /// <param name="flag"></param>
        private void EnableFlag(bool flag)
        {
            cboType.Enabled = flag;
            cboJobRole.Enabled = flag;
            txtLevel.Enabled = flag;
            if (flag)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;              
            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                txtLevel.Text = "0";
            }
            btnOK.Enabled = flag;
            btnCancel.Enabled = flag;
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableFlag(true);
            isAdd = true;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EnableFlag(true);
            isAdd = false;
            cboType.Enabled = false;
            cboJobRole.Enabled = false;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdd)
                {
                    //���
                    DataSet ds = App.GetDataSet("select * from T_IN_DOC_JOBTITLE t where t.jobtitle_id=" + cboJobRole.SelectedValue.ToString() + "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        App.MsgWaring("�ý�ɫ��ְ���Ѿ������ù��ˣ�");
                        return;
                    }
                    int id = App.GenId("T_IN_DOC_JOBTITLE", "ID");
                    int types = cboSelectType.SelectedIndex + 1;
                    string level = "0";
                    if (txtLevel.Text != "")
                    {
                        level = txtLevel.Text;
                    }
                    string sql = "insert into T_IN_DOC_JOBTITLE(ID,JOBTITLE_ID,TYPES,LEVELS)values(" + id + "," + cboJobRole.SelectedValue.ToString() + "," + types + "," + level + ")";
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                        cboSelectType_SelectedIndexChanged(sender, e);
                        btnCancel_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                }
                else
                {
                    string level = "0";
                    if (txtLevel.Text != "")
                    {
                        level = txtLevel.Text;
                    }
                    //�޸�
                    if (App.ExecuteSQL("update T_IN_DOC_JOBTITLE set LEVELS=" + level + " where ID=" + dataGridViewX1["ID", dataGridViewX1.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                        cboSelectType_SelectedIndexChanged(sender, e);
                        btnCancel_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                }
            }
            catch(Exception ex)
            {
                App.Msg("����ʧ�ܣ�ԭ��:"+ex.Message);
            }
        }

        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableFlag(false);
        }

        /// <summary>
        /// ��ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                iniCboData(1);
            }
            else if (cboType.SelectedIndex == 1)
            {
                iniCboData(2);
            }
            else if (cboType.SelectedIndex == 2)
            {
                iniCboData(3);
            }
            else if (cboType.SelectedIndex == 3)
            {
                iniCboData(4);
            }

        }

        private void frmJobLeverSet_Load(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
            cboSelectType.SelectedIndex = 0;
            EnableFlag(false);
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds=new DataSet();
            if (cboSelectType.SelectedIndex == 0)
            {
                ds = App.GetDataSet("select t.id,t.jobtitle_id,a.role_name as ��ɫ����,t.types as ����,t.levels as ���� from T_IN_DOC_JOBTITLE t inner join T_ROLE a on t.jobtitle_id=a.role_id where a.role_type='D'  order by t.levels asc");              
            }
            else if (cboSelectType.SelectedIndex == 1)
            {
                ds = App.GetDataSet("select t.id,t.jobtitle_id,a.role_name as ��ɫ����,t.types as ����,t.levels as ���� from T_IN_DOC_JOBTITLE t inner join T_ROLE a on t.jobtitle_id=a.role_id where a.role_type='N'  order by t.levels asc");               
            }
            else if (cboSelectType.SelectedIndex == 2)
            {
                ds = App.GetDataSet("select t.id,t.jobtitle_id,a.name as ְ������,t.types as ����,t.levels as ���� from T_IN_DOC_JOBTITLE t inner join T_DATA_CODE a on t.jobtitle_id=a.id where a.type=1 and t.types=3  order by t.levels asc");
            }
            else if (cboSelectType.SelectedIndex == 3)
            {
                ds = App.GetDataSet("select t.id,t.jobtitle_id,a.name as ְ������,t.types as ����,t.levels as ���� from T_IN_DOC_JOBTITLE t inner join T_DATA_CODE a on t.jobtitle_id=a.id where a.type=1 and t.types=4  order by t.levels asc");
            }
            if (ds != null)
            {
                if(ds.Tables!=null)
                   dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void ɾ����¼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string items = dataGridViewX1[2, dataGridViewX1.CurrentRow.Index].Value.ToString();
                if (App.Ask("ȷ��Ҫɾ����" + items + "���ļ�¼��"))
                {
                    if (App.ExecuteSQL("delete from T_IN_DOC_JOBTITLE where id=" + dataGridViewX1["id", dataGridViewX1.CurrentRow.Index].Value.ToString() + "")>0)
                    {
                        App.Msg("�����Ѿ��ɹ�");
                        cboSelectType_SelectedIndexChanged(sender, e);
                    }
                }

            }
            catch(Exception ex)
            {
                App.Msg("����ʧ��!ԭ��"+ex.Message);
            }
        }

        private void ȫ��ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (App.Ask("ȷ��Ҫɾ����" + cboSelectType.Text + "�������м�¼��"))
                {
                    int types = cboSelectType.SelectedIndex + 1;
                    if (App.ExecuteSQL("delete from T_IN_DOC_JOBTITLE where types=" + types .ToString()+ "") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ�");
                        cboSelectType_SelectedIndexChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                App.Msg("����ʧ��!ԭ��" + ex.Message);
            }
        }




    }
}