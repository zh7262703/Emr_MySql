using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using System.IO;

namespace Base_Function.TEMPLATE
{
    public partial class ucTempList_Small : UserControl
    {
        private string tid;

        public string Tid
        {
            get { return tid; }
            set { tid = value; }
        }    

        public ucTempList_Small()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        //��ʼ��һ��Ŀ¼������ϵͳ��
        private void InitSystemList()
        {
            DataTable dataTable;
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];           
            this.cboSys1.DataSource = dataTable.DefaultView;
            this.cboSys1.ValueMember = "ID";
            this.cboSys1.DisplayMember = "Name";
            if (dataTable.Rows.Count > 0)
            {
                this.cboSys1.SelectedIndex = 0;
            }
        }

        //��ʼ������Ŀ¼�������ࣩ
        private void InitSickList(string msg)
        {
            try
            {
                DataTable dataTable;
                string sql = "select s.ID,SICK_CODE," +
                            @"SICK_NAME,SICK_SYSTEM, " +
                            @"t.name as Name  from T_SICK_TYPE s " +
                            @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
                //��ʼ������
                DataSet dsSick = App.GetDataSet(sql);
                dataTable = dsSick.Tables[0];
                this.cboSicknessKind.DataSource = dataTable.DefaultView;
                this.cboSicknessKind.ValueMember = "ID";
                this.cboSicknessKind.DisplayMember = "SICK_NAME";
                if (dataTable.Rows.Count > 0)
                {
                    this.cboSicknessKind.SelectedIndex = 0;
                }
            }
            catch
            { }
        }


        //Сģ�����
        private void InitSmallTypeList()
        {          
            DataTable dataTable;
            DataRow newrow;
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";
           
        }     

        /// <summary>
        /// ��ѯģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tempSql = "";


            if (cboUseRange.Text == "����")
            {
                tempSql = "select Tid,tname as ģ������,create_time as ����ʱ��,TEMPPLATE_LEVEL as ģ�弶��,SECTION_ID as ����ID from t_tempplate t where tempplate_level='P' and temptype='S' and creator_id="+App.UserAccount.Account_id+"";
            }
            else if (cboUseRange.Text == "����")
            {
                tempSql = "select Tid,tname as ģ������,create_time as ����ʱ��,TEMPPLATE_LEVEL as ģ�弶��,SECTION_ID as ����ID from t_tempplate t where tempplate_level='S' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
            }
            else if (cboUseRange.Text == "������")
            {
                tempSql = "select Tid,tname as ģ������,create_time as ����ʱ��,TEMPPLATE_LEVEL as ģ�弶��,SECTION_ID as ����ID from t_tempplate t where tempplate_level='G' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
            }
            else
            {
                //tempSql = "select Tid,tname as ģ������,create_time as ����ʱ��,TEMPPLATE_LEVEL as ģ�弶��,SECTION_ID as ����ID from t_tempplate t where temptype='S'";
            }

            if (cboUseRange.Text == "����" || cboUseRange.Text == "����")
            {
                if (cboSys.Text != "��ѡ��..." && cboSys.Text != "")
                {
                    tempSql = tempSql + " and smalltemptype=" + cboSys.SelectedValue.ToString() + "";
                }
                if (txtTemplateName.Text.Trim() != "")
                {
                    tempSql = tempSql + " and tname like '%" + txtTemplateName.Text + "%'";
                }
            }

            //���ַ���
            if (chkSys.Checked)
            {
                tempSql = tempSql + " and SICK_ID='"+cboSicknessKind.SelectedValue.ToString()+"'";
            }

            DataSet ds = App.GetDataSet(tempSql);
            if (ds != null)
            {
                flgView.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void flgView_Click(object sender, EventArgs e)
        {
            if (flgView.Rows.Count > 0)
            {
                Tid = flgView[flgView.RowSel, "Tid"].ToString();
            }
        }

        private void ucTempList_Small_Load(object sender, EventArgs e)
        {
            try
            {
                InitSmallTypeList();
                cboSys.SelectedIndex = 0;
                cboUseRange.SelectedIndex = 0;
                InitSystemList();
                btnSearch_Click(sender, e);
            }
            catch
            { }
        }

        /// <summary>
        /// ����ϵͳѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSys1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSys1.Text != "��ѡ��..." && cboSys1.Text.Trim() != "")
            {
                InitSickList(cboSys1.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// ����ϵͳ�鿴ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSys_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSys.Checked)
            {
                cboSys1.Enabled = true;
                cboSicknessKind.Enabled = true;
            }
            else
            {
                cboSys1.Enabled = false;
                cboSicknessKind.Enabled = false;
            }
        }
    }
}
