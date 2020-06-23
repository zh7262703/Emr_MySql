using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 单项否决设置UI
    /// </summary>
    public partial class frmMarkInfo : Office2007Form
    {
        public frmMarkInfo(string typeId,string vetoProjects,bool isSave)
        {
            InitializeComponent();

            this.typeId = typeId;
            this.vetoProjects = vetoProjects;
            this.isSave = isSave;
        }

        private string typeId = "";            //类型ID
        private string vetoProjects = "";      //否决项目ID 逗号分隔
        private bool isSave = false;           //用于存放当前的操作状态 true为添加操作 false为修改操作

        private List<string> list = new List<string>();

        public List<string> List
        {
            get
            {
                return list;
            }
        }


        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Mark[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Mark[] Directionary = new Class_Mark[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Mark();

                        Directionary[i].ID = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].TypeId = tempds.Tables[0].Rows[i]["TYPE_ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].CheckReq = tempds.Tables[0].Rows[i]["CHECK_REQ"].ToString();
                        Directionary[i].DeductStand = tempds.Tables[0].Rows[i]["DEDUCT_STAND"].ToString();
                        Directionary[i].DeductScore = tempds.Tables[0].Rows[i]["DEDUCT_SCORE"].ToString();
                        Directionary[i].IsSingVeto = tempds.Tables[0].Rows[i]["ISSINGVETO"].ToString();
                        Directionary[i].SingVetoLev = tempds.Tables[0].Rows[i]["SINGVETO_LEV"].ToString();
                        Directionary[i].IsModifyManual = tempds.Tables[0].Rows[i]["ISMODIFY_MANUAL"].ToString();
                        Directionary[i].ValidState = tempds.Tables[0].Rows[i]["VALID_STATE"].ToString();
                        Directionary[i].SpellCode = tempds.Tables[0].Rows[i]["SPELL_CODE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                        Directionary[i].VetoProjects = tempds.Tables[0].Rows[i]["VETO_PROJECTS"].ToString();
                    }
                    return Directionary;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvMarkInfo.RowCount; i++)
            {
                if (Convert.ToInt32(this.dgvMarkInfo.Rows[i].Cells["状态"].Value) == 1)
                {
                    list.Add(this.dgvMarkInfo.Rows[i].Cells["项目ID"].Value.ToString());
                }
            }


            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void frmMarkInfo_Load(object sender, EventArgs e)
        {
            //string sql = "select t.* from T_MEDICAL_MARK t where t.issingveto = 'N' and t.type_id = '" + typeId + "'";
            //string sql = "select t.* from T_MEDICAL_MARK t inner join T_MEDICAL_MARK_TEXT t2 on t.id=t2.mark_id where t.issingveto = 'N' and t2.text_id in (" + typeId + ")";

            string sql = "select t.* from T_MEDICAL_MARK t where t.issingveto = 'N'";

            DataSet ds = App.GetDataSet(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Class_Mark[] Directionarys = GetSelectDirectionary(ds);


                DataTable dataTable = new DataTable();
                DataColumn boolColumn = new DataColumn("状态", typeof(bool));
                DataColumn idColumn = new DataColumn("项目ID", typeof(string));
                DataColumn nameColumn = new DataColumn("项目名称", typeof(string));
                DataColumn checkReqColumn = new DataColumn("检查要求", typeof(string));
                DataColumn reductStandColumn = new DataColumn("扣分标准", typeof(string));

                dataTable.Columns.Add(boolColumn);
                dataTable.Columns.Add(idColumn);
                dataTable.Columns.Add(nameColumn);
                dataTable.Columns.Add(checkReqColumn);
                dataTable.Columns.Add(reductStandColumn);


                dataTable.BeginLoadData();
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    if (isSave)
                    {
                        DataRow row = dataTable.NewRow();
                        row["状态"] = false;
                        row["项目ID"] = Directionarys[i].ID;
                        row["项目名称"] = Directionarys[i].Name;
                        row["检查要求"] = Directionarys[i].CheckReq;
                        row["扣分标准"] = Directionarys[i].DeductStand;
                        dataTable.Rows.Add(row);
                    }
                    else
                    {
                        DataRow row = dataTable.NewRow();
                        row["状态"] = IsCheck(Directionarys[i].ID);
                        row["项目ID"] = Directionarys[i].ID;
                        row["项目名称"] = Directionarys[i].Name;
                        row["检查要求"] = Directionarys[i].CheckReq;
                        row["扣分标准"] = Directionarys[i].DeductStand;
                        dataTable.Rows.Add(row);
                    }
                }
                dataTable.EndLoadData();

                this.dgvMarkInfo.DataSource = dataTable;
                this.dgvMarkInfo.Columns["项目ID"].Visible = false;
                this.dgvMarkInfo.Columns["状态"].Width = 30;
                this.dgvMarkInfo.Columns["项目名称"].Width = 300;
            }
            else
            {
                App.Msg("当前没有其他评分项目！");
                return;
            }

        }

        /// <summary>
        /// 判断是否勾选
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IsCheck(string id)
        {
            string[] strArr = vetoProjects.Split(',');

            foreach (string str in strArr)
            {
                if (str == id)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
