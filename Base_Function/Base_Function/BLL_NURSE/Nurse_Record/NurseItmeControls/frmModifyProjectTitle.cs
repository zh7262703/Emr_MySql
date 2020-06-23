using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class frmModifyProjectTitle : DevComponents.DotNetBar.Office2007Form
    {

        public string tName = "";
        public string tCode = "";
        public bool flag = false;   

        public frmModifyProjectTitle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="titleName">�Զ�������</param>
        /// <param name="nursetype">�������� N ���� O ���� C ��ͯ</param>
        public frmModifyProjectTitle(string titleName,string nursetype)
        {
            InitializeComponent();
            tName = titleName;
            cboNurseDictIni();

            //����ֵ
            rdoConstomTittle.Checked = true;
            cboNurseDict.Enabled = false;
            txtTitleName.Text = titleName;           
            for (int i = 0; i < cboNurseDict.Items.Count; i++)
            {
                System.Data.DataRowView dr = (System.Data.DataRowView)cboNurseDict.Items[i];
                if (dr["item_name"].ToString().Trim() == titleName.Trim())
                {
                    rdonurseDict.Checked = true;
                    cboNurseDict.Text = titleName;
                    txtTitleName.Text = "";
                    break;
                }
            }

        }

        /// <summary>
        /// ��ʼ������������Ŀ��Ϣ
        /// </summary>
        private void cboNurseDictIni()
        {
            string sql_Nurse = "select item_code,item_name,item_type from t_nurse_record_dict where item_type=96";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);
            cboNurseDict.DataSource = ds_Nurse.Tables[0].DefaultView;
            cboNurseDict.DisplayMember = "item_name";
            cboNurseDict.ValueMember = "item_code";

            if (cboNurseDict.Items.Count > 0)
            {
                cboNurseDict.SelectedIndex = 0;
            }

        }

        private void frmModifyProjectTitle_Load(object sender, EventArgs e)
        {
            txtTitleName.Focus();
            txtTitleName.Text = tName;
        }
           
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {           
            if (rdoConstomTittle.Checked)
            {
                tName = txtTitleName.Text;
                tCode = "";
            }
            else
            {
                tName = cboNurseDict.Text;
                tCode = cboNurseDict.SelectedValue.ToString();
            }
            flag = true;
            this.Close();
        }


        private void txtTitleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSave_Click(sender, e);
            }
        }

        /// <summary>
        /// ����������ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertDataBase_Click(object sender, EventArgs e)
        {
            //insert into T_NURSE_RECORD_DICT(ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_KIND,ITEM_UNIT,DISPLAY_INDEX,HAS_SUM,ITEM_TYPE,ITEM_ATTRIBUTE) values('85','100','����','100','ml','7','1','96',0)
            string ID = App.GenId("T_NURSE_RECORD_DICT", "ID").ToString();
            try
            {
                string sql = "insert into T_NURSE_RECORD_DICT(ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_KIND,ITEM_UNIT,DISPLAY_INDEX,HAS_SUM,ITEM_TYPE,ITEM_ATTRIBUTE) values('" + ID + "','" + ID + "','" + txtTitleName.Text + "','100','ml','7','1','96',0)";
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("��ӻ�����ɹ���");
                    cboNurseDictIni();
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("����ʧ�ܣ�ԭ��:"+ex.Message);
            }
        }

        private void rdoConstomTittle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoConstomTittle.Checked)
            {
                cboNurseDict.Enabled = false;
                txtTitleName.Enabled = true;
            }
            else
            {
                cboNurseDict.Enabled = true;
                txtTitleName.Enabled = false;
            }
        }
    }
}