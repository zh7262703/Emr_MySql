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
    /// 客观评分项目选择UI
    /// </summary>
    public partial class frmGradeObjectiveInfo : Office2007Form
    {
        public frmGradeObjectiveInfo()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmGradeObjectiveInfo_Load);
        }
        string strRole_tyep = "";


        private List<string> ids = new List<string>();
        private List<string> names = new List<string>();
        //扣分值
        private List<string> koufenzhi = new List<string>();

        /// <summary>
        /// 客观项目ID（逗号分隔）
        /// </summary>
        public string Ids
        {
            get { return listToString(ids); }
        }

        /// <summary>
        /// 客观项目名称(逗号分隔)
        /// </summary>
        public string Names
        {
            get { return listToString(names); }
        }
        /// <summary>
        /// 扣分值
        /// </summary>
        public string KouFenZhi
        {
            get { return listToString(koufenzhi); }
        }
        void frmGradeObjectiveInfo_Load(object sender, EventArgs e)
        {
            strRole_tyep = App.UserAccount.CurrentSelectRole.Role_type.ToString();//获取当前登陆角色类型
            if (strRole_tyep != "H")
            {
                GetItemYWC();
            }
            else
            {
                GetItemHLB();
            }
        }
        
        /// <summary>
        /// 取得客观项目
        /// </summary>
        private void GetItemYWC()
        {
            string Sql = "select q.编号,q.文档类型,q.参考时间,q.偏移时间,q.执行周期,q.预警时间,q.扣分值,q.是否扣分 from QUALITY_VAR_YWC_VIEW q order by q.文档类型,q.执行周期 desc";
            DataSet ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];

                LinkLabel lkbel = new LinkLabel();
                lkbel.Text = "选中";

                DataColumn dc = new DataColumn("" + lkbel.Text + "", typeof(bool));
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                this.c1FlexGrid1.DataSource = dt.DefaultView;
                this.c1FlexGrid1.Cols["" + lkbel.Text + ""].Move(1);

                this.c1FlexGrid1.Cols["选中"].Width = 50;
                this.c1FlexGrid1.Cols["编号"].Width = 50;
                this.c1FlexGrid1.Cols["文档类型"].Width = 150;
                this.c1FlexGrid1.Cols["参考时间"].Width = 100;
                this.c1FlexGrid1.Cols["偏移时间"].Width = 100;
                this.c1FlexGrid1.Cols["执行周期"].Width = 100;
                this.c1FlexGrid1.Cols["预警时间"].Width = 100;
                this.c1FlexGrid1.Cols["扣分值"].Width = 50;
                this.c1FlexGrid1.Cols["是否扣分"].Width = 60;

                this.c1FlexGrid1.Cols["编号"].Visible = false;
            }


        }

        /// <summary>
        /// 把list转换为一个用逗号分隔的字符串 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string listToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                    {
                        sb.Append(list[i] + ",");
                    }
                    else
                    {
                        sb.Append(list[i]);
                    }
                }
            }
            return sb.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (strRole_tyep != "H")
            {
                for (int i = 0; i < this.c1FlexGrid1.Rows.Count; i++)
                {
                    if (c1FlexGrid1[i, "选中"].ToString().ToLower() == "true")
                    {
                        ids.Add(c1FlexGrid1[i, "编号"].ToString());
                        names.Add(c1FlexGrid1[i, "文档类型"].ToString());
                        koufenzhi.Add(c1FlexGrid1[i, "扣分值"].ToString());//扣分值的传递
                    }
                }
            }
            else//护理部门使用
            {
                for (int i = 0; i < this.c1FlexGrid1.Rows.Count; i++)
                {
                    if (c1FlexGrid1[i, "选中"].ToString().ToLower() == "true")
                    {
                        ids.Add(c1FlexGrid1[i, "编号"].ToString());
                        names.Add(c1FlexGrid1[i, "护理类型"].ToString());
                        koufenzhi.Add(c1FlexGrid1[i, "患者类型"].ToString());//扣分值的传递
                    }
                }
            }
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        /// <summary>
        /// 护理部使用
        /// </summary>
        private void GetItemHLB()
        {
            string Sql = "select t.id as 编号, t.nurse_type as 护理类型,t.patient_type as 患者类型,t.consult_time as 参考时间,t.rule as 规则,t.test_time_point as 测试时间点  from T_NURSE t order by  t.id  asc";
            DataSet ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];

                LinkLabel lkbel = new LinkLabel();
                lkbel.Text = "选中";

                DataColumn dc = new DataColumn("" + lkbel.Text + "", typeof(bool));
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                this.c1FlexGrid1.DataSource = dt.DefaultView;
                this.c1FlexGrid1.Cols["" + lkbel.Text + ""].Move(1);

                this.c1FlexGrid1.Cols["选中"].Width = 50;
                this.c1FlexGrid1.Cols["编号"].Width = 50;
                this.c1FlexGrid1.Cols["护理类型"].Width = 100;
                this.c1FlexGrid1.Cols["患者类型"].Width = 100;
                this.c1FlexGrid1.Cols["参考时间"].Width = 100;
                this.c1FlexGrid1.Cols["规则"].Width = 500;
                this.c1FlexGrid1.Cols["测试时间点"].Width = 100;
                

              
            }
        }
    }
}
