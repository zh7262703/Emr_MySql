using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucFollowTimeTypeSet : UserControl
    {
        private string T_SQL_Type = null;//��ѯ��������
        private DataSet ds;             //�洢��ѯ��������
        private bool IsNew = true;     //�ж��Ƿ�Ϊ�½�
        private static int id = 0;            //����ѡ���е�ID
        private string TimeType = "";       //�������ݿ��ʱ������
        public ucFollowTimeTypeSet()
        {
            InitializeComponent();
            T_SQL_Type = "select id ���,typename ������ from t_follow_type order by ��� asc";
        }

        private void followTypeSet_Load(object sender, EventArgs e)
        {
            ShowData();
            cmbUnit.SelectedIndex = 1;
        }
        /// <summary>
        /// ��GridView����
        /// </summary>
        private void ShowData()
        {
            ds = App.GetDataSet(T_SQL_Type);
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            //��ʼ���ؼ�           
            dataGridViewX1.ReadOnly = true;
            txtName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        /// <summary>
        /// �½�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //��ʼ���ؼ�
            IsNew = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtName.Enabled = true;
            txtName.Text = "";
            txtName.Focus();

        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            IsNew = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtName.Enabled = true;
            txtName.Focus();
        }
        /// <summary>
        /// ɾ��ѡ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("�Ƿ�ɾ��"))
            {
                try
                {
                    string sql_delete = "delete from t_follow_type where id=" + id + "";
                    App.ExecuteSQL(sql_delete);
                    ShowData();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
            
        }
        /// <summary>
        /// �����޸Ļ��½�����
        /// </summary>
        private bool Edit()
        {
            string sql="";
            int i=0;
            if (txtName.Text == "" )
            {
                App.Msg("���벻��Ϊ��");
                txtName.Focus();
               
            }
            if (IsNew)
            {
                if (checkName())
                {
                    App.Msg("�Ѵ��ڸ�ʱ�����ͣ�����������");
                    return false;
                }
                sql = "insert into t_follow_type(typename) values('" + txtName.Text.Trim()+cmbUnit.Text+"1��" + "')";
            }
            else
            {
                if (checkName())
                {
                    App.Msg("�Ѵ��ڸ�ʱ�����ͣ�����������");
                    return false;
                }
                else
                {
                    if (id != 0)
                        sql = "update t_follow_type set typename='" + txtName.Text.Trim() + cmbUnit.Text + "1��" + "' where id=" + id + "";
                    else
                        App.Msg("ѡ�����ݺ���ܽ����޸ģ�");
                }
            }

            try
            {
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("����ɹ�!");
                    return true;
                }
                else
                {
                    App.Msg("����ʧ��!");
                    return false;
                }
            }
            catch(Exception ex)
            {
                
                App.MsgErr(ex.Message);
                return false;
            }
        }

        //��������Ƿ��ظ�
        private bool checkName()
        {
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if ((txtName.Text+cmbUnit.Text+"1��") == ds.Tables[0].Rows[i][1].ToString())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit())
                ShowData();
            else
                refreshForm();
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        /// <summary>
        /// ѡ��datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void refreshForm()
        {
            txtName.Text = "";
            txtName.Enabled = false;
            
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            else
            {
                string name = dataGridViewX1.Rows[e.RowIndex].Cells["������"].Value.ToString();
                txtName.Text=name.Substring(0,name.IndexOf('��')-2);
                cmbUnit.Text = name.Substring(name.IndexOf('��')-2,1);
                id = Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//�������������˸��  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//������������0-9����  
                {
                    e.Handled = true;
                }
            } 
        }

    }
}
