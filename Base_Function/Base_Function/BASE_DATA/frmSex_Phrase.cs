using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class frmSex_Phrase : UserControl
    {
        private bool isSave = false; //�ж������������޸�
        private string T_Sex_Phrase = ""; //��ѯ�ؼ��ֱ�SQL���
        private string ID = "";              //�ؼ���ID
        public frmSex_Phrase()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            T_Sex_Phrase = "select t.id as ���,t.phrase as �ؼ���,(case when t.sex=0 then '��' else 'Ů' end) as �Ա� from t_sex_phrase t";
            DataBd();
            txtPhrase.Enabled = false;
            cboGender.Enabled = false;
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
        }
        /// <summary>
        /// ����Դ�����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            int index = ucGridviewX1.fg.CurrentRow.Index;
            if (ucGridviewX1.fg.RowCount > 0)
            {
                txtPhrase.Text = ucGridviewX1.fg["�ؼ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (ucGridviewX1.fg["�Ա�", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                {
                    cboGender.SelectedIndex = 0;
                }
                else
                {
                    cboGender.SelectedIndex = 1;
                }
                
            }
        }
        //������
        private void DataBd()
        {
            ucGridviewX1.DataBd(T_Sex_Phrase, "���", false, "", "");
            ucGridviewX1.fg.ReadOnly = true;
        }
        //��Ӻ��޸ĸı�ؼ�״̬
        private void Changed()
        {
            ucGridviewX1.fg.Enabled = false;
            txtPhrase.Enabled = true;
            cboGender.Enabled = true;
        }
        //ȡ���ı�ؼ�״̬
        private void ESCChanged()
        {
            ucGridviewX1.fg.Enabled = true;
            txtPhrase.Enabled = false;
            cboGender.Enabled = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        //���
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            Changed();
        }
        //�޸�
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            Changed();
        }
        //ɾ��
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("��ȷ��Ҫɾ����"))
                {
                    string SQLDelete = "delete from t_sex_phrase where id ='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    int count = App.ExecuteSQL(SQLDelete);
                    if (count > 0)
                    {
                        App.Msg("ɾ���ɹ�!");
                    }
                }
            }
            catch (Exception)
            {
                App.Msg("ɾ��ʧ��!");
            }
            //������
            DataBd();
            ESCChanged();
        }
        //����
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhrase.Text.Trim() == "")
                {
                    App.Msg("�ؼ��ֲ���Ϊ�գ�");
                    txtPhrase.Focus();
                    return;
                }
                ID = App.GenId("t_sex_phrase", "id").ToString();
                string sql = "";
                if (isSave)
                {
                    sql = "insert into t_sex_phrase(id, phrase, sex)values('" + ID + "', '" + txtPhrase.Text.Trim() + "', '" + cboGender.SelectedIndex + "')";
                }
                else
                {
                    sql = "update t_sex_phrase set phrase = '" + txtPhrase.Text.Trim() + "',sex = '" + cboGender.SelectedIndex + "' where id = '" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                App.Msg("���ʧ�ܣ�ԭ��" + ex.ToString() + "");
            }
            //������
            DataBd();
            ESCChanged();
        }
        //ȡ��
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ESCChanged();
        }
    }
}