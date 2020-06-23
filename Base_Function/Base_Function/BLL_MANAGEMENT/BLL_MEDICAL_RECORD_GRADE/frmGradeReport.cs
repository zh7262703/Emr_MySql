using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Bifrost;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 医务和护理评分报表
    /// </summary>
    public partial class frmGradeReport : DevComponents.DotNetBar.Office2007Form
    {
        public frmGradeReport()
        {
            InitializeComponent();
        }

        private string pid = "";
        private string emplType = "";

        frmMainSelectHistoryRepart fmshr;

        DataTable dt;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmGradeReport(frmMainSelectHistoryRepart _fmshr, string _emplType)
        {
            InitializeComponent();

            this.fmshr = _fmshr;

            this.pid = fmshr.SetPingFenID();
            this.emplType = _emplType;

            SetReport();
        }

        private void SetReport()
        {
            if (emplType == "N")
            {
                string selectSQL = 
                    
"select * from " +
"( " +
"select decode(rownum,1,'体温单') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8885' " + 
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'医嘱执行单记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8886' " + 
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'手术护理记录单') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8887' " + 
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'危重患者护理记录、ICU护理记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8888' " + 
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'住院患者护理记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8889' " +
"order by t.id asc " +
") ";

                dt = App.GetDataSet(selectSQL).Tables[0];

                this.c1FlexGrid1.DataSource = dt;

                this.c1FlexGrid1.Cols["项目内容"].Width = 100;
                this.c1FlexGrid1.Cols["检查要求"].Width = 200;
                this.c1FlexGrid1.Cols["扣分标准"].Width = 280;
                this.c1FlexGrid1.Cols["扣分值"].Width = 60;
                this.c1FlexGrid1.Cols["扣分理由"].Width = 100;

                this.c1FlexGrid1.Styles.Normal.WordWrap = true;
                this.c1FlexGrid1.AutoSizeRows();
            }

            if (emplType == "D")
            {
                string selectSQL =
"select * from " +
"( " +
"select decode(rownum,1,'病案首页') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8879' " +
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'入院记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8880' " +
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'病程记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8881' " +
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'出院记录') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8882' " +
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'辅助检查及医嘱') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8883' " +
"order by t.id asc " +
") " +
"union all " +
"select * from " +
"( " +
"select decode(rownum,1,'书写基本要求') as 项目内容,t.check_req as 检查要求,t.deduct_stand as 扣分标准 , " +
"(select g.down_point from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分值, " +
"(select g.down_reason from t_doc_grade g where g.item_id = t.id and g.pid = '" + pid + "') as 扣分理由 " +
"from T_MEDICAL_MARK t " +
"where t.type_id = '8884' " +
"order by t.id asc " +
") ";

                dt = App.GetDataSet(selectSQL).Tables[0];

                this.c1FlexGrid1.DataSource = dt;

                this.c1FlexGrid1.Cols["项目内容"].Width = 100;
                this.c1FlexGrid1.Cols["检查要求"].Width = 200;
                this.c1FlexGrid1.Cols["扣分标准"].Width = 300;
                this.c1FlexGrid1.Cols["扣分值"].Width = 80;
                this.c1FlexGrid1.Cols["扣分理由"].Width = 100;

                this.c1FlexGrid1.Cols["检查要求"].Visible = false;

                this.c1FlexGrid1.Styles.Normal.WordWrap = true;
                this.c1FlexGrid1.AutoSizeRows();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.c1FlexGrid1.PrintGrid("评分报表", PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPreviewDialog);
        }

        public void printGrid()
        {
            this.c1FlexGrid1.PrintGrid("评分报表", PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPreviewDialog);
        }
    }
}
