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

        //初始化一级目录（所属系统）
        private void InitSystemList()
        {
            DataTable dataTable;
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];           
            this.cboSys1.DataSource = dataTable.DefaultView;
            this.cboSys1.ValueMember = "ID";
            this.cboSys1.DisplayMember = "Name";
            if (dataTable.Rows.Count > 0)
            {
                this.cboSys1.SelectedIndex = 0;
            }
        }

        //初始化二级目录（病种类）
        private void InitSickList(string msg)
        {
            try
            {
                DataTable dataTable;
                string sql = "select s.ID,SICK_CODE," +
                            @"SICK_NAME,SICK_SYSTEM, " +
                            @"t.name as Name  from T_SICK_TYPE s " +
                            @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
                //初始化病种
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


        //小模板类别
        private void InitSmallTypeList()
        {          
            DataTable dataTable;
            DataRow newrow;
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";
           
        }     

        /// <summary>
        /// 查询模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tempSql = "";


            if (cboUseRange.Text == "个人")
            {
                tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID from t_tempplate t where tempplate_level='P' and temptype='S' and creator_id="+App.UserAccount.Account_id+"";
            }
            else if (cboUseRange.Text == "科室")
            {
                tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID from t_tempplate t where tempplate_level='S' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
            }
            else if (cboUseRange.Text == "诊疗组")
            {
                tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID from t_tempplate t where tempplate_level='G' and SECTION_ID=" + App.UserAccount.CurrentSelectRole.Section_Id + " and temptype='S'";
            }
            else
            {
                //tempSql = "select Tid,tname as 模板名称,create_time as 创建时间,TEMPPLATE_LEVEL as 模板级别,SECTION_ID as 科室ID from t_tempplate t where temptype='S'";
            }

            if (cboUseRange.Text == "个人" || cboUseRange.Text == "科室")
            {
                if (cboSys.Text != "请选择..." && cboSys.Text != "")
                {
                    tempSql = tempSql + " and smalltemptype=" + cboSys.SelectedValue.ToString() + "";
                }
                if (txtTemplateName.Text.Trim() != "")
                {
                    tempSql = tempSql + " and tname like '%" + txtTemplateName.Text + "%'";
                }
            }

            //病种分类
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
        /// 所属系统选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSys1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSys1.Text != "请选择..." && cboSys1.Text.Trim() != "")
            {
                InitSickList(cboSys1.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// 所属系统查看选择
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
