using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class ucMessageSet : UserControl
    {
        /// <summary>
        /// �Ƿ�����Ӳ���
        /// </summary>
        bool isAdd = false;
        public ucMessageSet()
        {
            InitializeComponent();
        }

        private void ucMessageSet_Load(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ucGridviewX1.fg.Click += new EventHandler(fg_Click);
                //����Ϣ����
                SetMsgType();
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message);
            }
        }

        /// <summary>
        /// ������Ϣ���������˵�
        /// </summary>
        private void SetMsgType()
        {
            cbxEdit_Type.DataSource = null;
            cbxMsgType.DataSource = null;

            string sqlMsgType = "select id,type_name from t_msg_type";
            DataSet ds = App.GetDataSet(sqlMsgType);
            //������
            DataRow dr = ds.Tables[0].NewRow();
            dr["id"] = 0;
            dr["type_name"] = "ȫ��";
            ds.Tables[0].Rows.InsertAt(dr, 0);

           
            //��ѯ����
            cbxMsgType.DisplayMember = "type_name";
            cbxMsgType.ValueMember = "id";
            cbxMsgType.DataSource = ds.Tables[0];

            DataSet ds_2 = App.GetDataSet(sqlMsgType);
            //�༭����
            cbxEdit_Type.DisplayMember = "type_name";
            cbxEdit_Type.ValueMember = "id";
            cbxEdit_Type.DataSource = ds_2.Tables[0];
            cbxMsgType.SelectedIndex = 0;
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select a.id ���,a.type_id,b.type_name ��Ϣ����,a.message ��Ϣ����,a.msg_scale ��Ϣ���� from t_msg_content a inner join t_msg_type b on a.type_id=b.id where 1=1";
            //����Ϣ���ݲ�ѯ
            if (txtMsgName.Text.Trim() != "")
            {
                sql += " and message like '%" + txtMsgName.Text.Trim() + "%'";
            }

            //�����Ͳ�ѯ
            if (cbxMsgType.Text != "ȫ��")
            {
                sql += " and a.type_id =" + cbxMsgType.SelectedValue;
            }
            ucGridviewX1.DataBd(sql, "��Ϣ����", true, "id", "���");
            ucGridviewX1.fg.Columns["type_id"].Visible = false;
        }

        /// <summary>
        /// ��� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region �ؼ�����
            //����
            txtEdit_Msg.Enabled = true;

            cbxEdit_Type.Enabled = true;
            cbMsg_Scale.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //����
            txtEdit_Msg.Text = "";

            cbMsg_Scale.Text = "";
            cbxEdit_Type.SelectedIndex = 0;
            btnAdd.Enabled = false;

            //����
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;


            isAdd = true;
            #endregion


        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow!=null)
            {
                #region �ؼ�����
                txtEdit_Msg.Enabled = true;

                cbxEdit_Type.Enabled = true;
                cbMsg_Scale.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                //����
                groupPanel2.Enabled = false;
                groupPanel1.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;

                isAdd = false;
                #endregion 
            }
            else
            {
                App.Msg("��ѡ��һ�����ݣ�");
            }


        }

        /// <summary>
        /// ��֤�����ȸ���������
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private bool IsFloat(string score)
        {
            try
            {
                float.Parse(score);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                string id = ucGridviewX1.fg.CurrentRow.Cells["���"].Value.ToString();
                if (App.Ask("ȷ��Ҫɾ����"))
                {
                    string del = "delete from t_msg_content where id=" + id;
                    int num = App.ExecuteSQL(del);
                    if (num > 0)
                    {
                        App.Msg("ɾ���ɹ���");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("ɾ��ʧ�ܣ�");
                    }
                }
            }
        }

        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string score = "null";
            #region ��֤����
            if (txtEdit_Msg.Text == "")
            {
                App.Msg("��������Ϣ���ݣ�");
                txtEdit_Msg.Focus();
                return;
            }
            if (cbMsg_Scale.Text == "")
            {
                App.Msg("��������Ϣ����");
                cbMsg_Scale.Focus();
                return;
            }
            //�����Ƿ�ɹ�
            int num = 0;
            #endregion
            if (isAdd)
            {
                #region �������
                int id = App.GenId("t_msg_content", "id");
                string sql = "insert into t_msg_content(id,type_id,message,msg_scale) values" +
                             "(" + id + "," + cbxEdit_Type.SelectedValue + ",'" + txtEdit_Msg.Text + "','"+cbMsg_Scale.Text+"')";

                num = App.ExecuteSQL(sql);

                #endregion
            }
            else
            {
                #region �޸�
                string id = ucGridviewX1.fg.CurrentRow.Cells["���"].Value.ToString();
                string update = "update t_msg_content set type_id=" + cbxEdit_Type.SelectedValue + ",message='" + txtEdit_Msg.Text + "',msg_scale='"+cbMsg_Scale.Text+"' where id=" + id;
                num = App.ExecuteSQL(update);
                #endregion
            }
            if (num > 0)
            {
                App.Msg("�����ɹ���");
                btnCancel_Click(sender, e);
                btnSearch_Click(sender, e);
                
            }
            else
            {
                App.Msg("����ʧ�ܣ�");
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            #region �ؼ�����
            //����
            groupPanel2.Enabled = true;
            groupPanel1.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            //����
            txtEdit_Msg.Enabled = false;

            cbxEdit_Type.Enabled = false;
            cbMsg_Scale.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            fg_Click(sender, e);
            #endregion
        }

        /// <summary>
        /// ��񵥻��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                txtEdit_Msg.Text = ucGridviewX1.fg.CurrentRow.Cells["��Ϣ����"].Value.ToString();
                cbMsg_Scale.Text = ucGridviewX1.fg.CurrentRow.Cells["��Ϣ����"].Value.ToString();
               // txtEdit_Score.Text = ucGridviewX1.fg.CurrentRow.Cells["�۷�ֵ"].Value.ToString(); 
                cbxEdit_Type.SelectedValue = ucGridviewX1.fg.CurrentRow.Cells["type_id"].Value;
            }
        }

        private void btnAddMsgType_Click(object sender, EventArgs e)
        {
            frmAddType frm = new frmAddType();
            frm.ShowDialog();
            if (frm.flag)
            {
                SetMsgType();
            }
            
        }


    }
}
