using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{     
   /// <summary>
   /// 病种设置
   /// </summary>
    public partial class frmPropertySet : DevComponents.DotNetBar.Office2007Form
    {
        private DataTable dataTable;
        private DataRow newrow;
        private bool isSysInit = false;       //绑定数据源是否触发事件（一级目录）
        private bool isSickInit = false;      //绑定数据源是否触发事件（二级目录）
        private string Tid = ""; 

        public frmPropertySet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 模板主键
        /// </summary>
        /// <param name="tid"></param>
        public frmPropertySet(string tid)
        {
            InitializeComponent();
            Tid = tid;
        }

        //初始化一级目录（所属系统）
        private void InitSystemList()
        {
            isSysInit = false;   //绑定数据源是否触发事件
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //初始化所属系统疾病
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";
            isSysInit = true;  //绑定数据源是否触发事件           
        }

        //初始化二级目录（病种类）
        private void InitSickList(string msg)
        {
            isSickInit = false;  //绑定数据源是否触发事件
            string sql = "select s.ID,SICK_CODE," +
                        @"SICK_NAME,SICK_SYSTEM, " +
                        @"t.name as Name  from T_SICK_TYPE s " +
                        @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
            //初始化病种
            DataSet dsSick = App.GetDataSet(sql);
            dataTable = dsSick.Tables[0];
            newrow = dataTable.NewRow();
            newrow[2] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSicknessKind.DataSource = dataTable.DefaultView;
            this.cboSicknessKind.ValueMember = "ID";
            this.cboSicknessKind.DisplayMember = "SICK_NAME";
            isSickInit = true;  //绑定数据源是否触发事件
        }

        private void frmPropertySet_Load(object sender, EventArgs e)
        {
            InitSystemList();
            this.cboSicknessKind.SelectedIndex = 0;

            try
            {
                string sqlhaveselect = "select s.ID,SICK_CODE,SICK_NAME," +
                                       "SICK_SYSTEM,t.name as Name  from T_SICK_TYPE s inner join " +
                                       "t_data_code t on t.id=s.sick_system inner join t_tempplate c " +
                                       "on c.sick_id=s.id where c.tid=" + Tid + "";

                DataSet dshaveSelect = App.GetDataSet(sqlhaveselect);
                if (dshaveSelect.Tables[0].Rows.Count > 0)
                {
                    //已经设置过值
                    this.cboSys.SelectedValue = dshaveSelect.Tables[0].Rows[0]["SICK_SYSTEM"].ToString();

                    if (this.cboSicknessKind.Items.Count > 0)
                    {
                        this.cboSicknessKind.SelectedValue = dshaveSelect.Tables[0].Rows[0]["ID"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("初始化出现异常，原因："+ex.Message);
            }
        }

        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSysInit)
            {
                string msg = this.cboSys.SelectedValue.ToString();
                InitSickList(msg);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sick_Id = cboSicknessKind.SelectedValue.ToString();  //病种Id
            string sql = "update T_TempPlate set SICK_ID=" + sick_Id + " where tid=" + Tid + "";
            if (App.ExecuteSQL(sql) > 0)
            {
                App.Msg("操作已经成功！");
            }
            else
            {
                App.MsgErr("操作失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
