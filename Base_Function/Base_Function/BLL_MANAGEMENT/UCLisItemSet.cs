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
    public partial class UCLisItem : UserControl
    { /// <summary>
        /// ��ǰ��������
        /// </summary>
        public enum Operater
        {
            noThing,
            update,
            delete,
            add
        }

        public Operater operater = new Operater();

        public UCLisItem()
        {
            InitializeComponent();
            operater = Operater.noThing;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        private void GetData()
        {
            string sql_LisItem = "select a.item_code,item_name LIS��Ŀ����,a.item_unit ��λ,a.max_value ���ֵ, a.min_value ���ֵ,a.item_type �Ƿ���Ҫ from t_lis_item a where 1=1 ";
            if (txtSearchName.Text != "")
            {
                sql_LisItem += " and item_name like '%" + txtSearchName.Text + "%'";
            }
            if (ckbSearch.Checked)
            {
                sql_LisItem += " and a.item_type='��Ҫ'";
            }
            try
            {
                DataSet ds = App.GetDataSet(sql_LisItem);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        dgvItemList.DataSource = dt;
                        dgvItemList.Columns["item_code"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UCLisItem_Load(object sender, EventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            operater = Operater.add;
            //���ÿؼ�
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //����
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            //����ı���
            txtItemName.Text = "";
            txtMax.Text = "";
            txtMin.Text = "";
            txtUnit.Text = "";
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            operater = Operater.update;
            //���ÿؼ�
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //����
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            operater = Operater.delete;
            //���ÿؼ�
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //����
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (operater == Operater.add)//���
            {
                Add();
            }
            else if (operater == Operater.update)//�޸�
            {
                Modify();
            }
            else if (operater == Operater.delete)//ɾ��
            {
                Del();
            }
            else
            {
                App.Msg("��û��ѡ���κβ�����");
            }
            //������ɣ���ԭ����
            operater = Operater.noThing;
            //���ÿؼ�
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnDel.Enabled = true;
            dgvItemList.Enabled = true;
            //���ÿؼ�
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtItemName.Enabled = false;
            txtMax.Enabled = false;
            txtMin.Enabled = false;
            txtUnit.Enabled = false;
            GetData();
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //������ɣ���ԭ����
            operater = Operater.noThing;
            //���ÿؼ�
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnDel.Enabled = true;
            dgvItemList.Enabled = true;
            //���ÿؼ�
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtItemName.Enabled = false;
            txtMax.Enabled = false;
            txtMin.Enabled = false;
            txtUnit.Enabled = false;
            GetData();
        }

        /// <summary>
        /// ��ӣ��������item_code������µ�item_code
        /// </summary>
        private void Add()
        {
            try
            {
                //�������item_code����string������
                string sql_item = "select item_code from t_lis_item";
                string[] str_arr = null;
                DataSet ds = App.GetDataSet(sql_item);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    str_arr = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str_arr[i] = dt.Rows[i]["item_code"].ToString();
                    }
                }

                //��string�����н�ȡ�ַ������õ�int���͵�����
                int[] int_code = new int[str_arr.Length];
                for (int i = 0; i < int_code.Length; i++)
                {
                    int_code[i] = Convert.ToInt32(str_arr[i].Substring(3));
                }
                //��int�����е����ֵ
                int temp = 0;
                for (int i = 0; i < int_code.Length; i++)
                {
                    if (int_code[i] > temp)
                    {
                        temp = int_code[i];
                    }
                }
                //ƴ�����µ�item_code
                string newCode = "WJX" + (temp + 1);
                //�Ƿ���Ҫ
                string isImportant = ckbImportant.Checked ? "��Ҫ" : "";
                //�������ݿ�
                string sql_insert = "insert into t_lis_item(item_code,item_name,item_type,item_unit,max_value,min_value) values" +
                    "('" + newCode + "','" + txtItemName.Text + "','" + isImportant + "','" + txtUnit.Text + "','" + txtMax.Text + "','" + txtMin.Text + "')";
                int num = App.ExecuteSQL(sql_insert);
                if (num > 0)
                {
                    App.Msg("��ӳɹ���");
                }
                else
                {
                    App.Msg("���ʧ�ܣ�");
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// �޸�
        /// </summary>
        private void Modify()
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    string item_code = dgvItemList.CurrentRow.Cells["item_code"].Value.ToString();
                    int num = 0;
                    string isImportant = ckbImportant.Checked ? "��Ҫ" : "";
                    string sql_update = "update t_lis_item set item_unit='" + txtUnit.Text + "',max_value='" + txtMax.Text + "',min_value='" + txtMin.Text + "',item_type='" + isImportant + "' where item_code='" + item_code + "'";
                    num = App.ExecuteSQL(sql_update);
                    if (num > 0)
                    {
                        App.Msg("���³ɹ���");
                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        private void Del()
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    string item_code = dgvItemList.CurrentRow.Cells["item_code"].Value.ToString();
                    string sql_del = "delete from t_lis_item where item_code='" + item_code + "'";

                    int num = App.ExecuteSQL(sql_del);
                    if (num > 0)
                    {
                        App.Msg("ɾ���ɹ���");
                    }
                    else
                    {
                        App.Msg("ɾ��ʧ�ܣ�");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ��񵥻�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItemList_Click(object sender, EventArgs e)
        {
            if (dgvItemList.CurrentRow != null)
            {
                txtItemName.Text = dgvItemList.CurrentRow.Cells["LIS��Ŀ����"].Value.ToString();
                txtUnit.Text = dgvItemList.CurrentRow.Cells["��λ"].Value.ToString();
                txtMax.Text = dgvItemList.CurrentRow.Cells["���ֵ"].Value.ToString();
                txtMin.Text = dgvItemList.CurrentRow.Cells["���ֵ"].Value.ToString();
                ckbImportant.Checked = dgvItemList.CurrentRow.Cells["�Ƿ���Ҫ"].Value.ToString() == "��Ҫ" ? true : false;
            }

        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
