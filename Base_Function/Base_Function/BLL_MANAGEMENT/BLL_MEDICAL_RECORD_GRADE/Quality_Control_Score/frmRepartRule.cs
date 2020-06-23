using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.MODEL;
using Bifrost;
using C1.Win.C1FlexGrid;
using System.Text.RegularExpressions;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class frmRepartRule : DevComponents.DotNetBar.Office2007Form
    {

        public delegate void RefEventHandler(string mark_id, string item, string item_con, string item_score, string did);
        public event RefEventHandler AddMark;

        string textKind_id="";       

        public frmRepartRule()
        {
            InitializeComponent();
        }

        public frmRepartRule(string strTextkind_id)
        {      
            InitializeComponent();
            textKind_id = strTextkind_id;
        }     

        private void frmRepartRule_Load(object sender, EventArgs e)
        {
            //主观规则
            string strSql = "select a.id as ID,a.name as 评分类别,a.check_req as 检查要求,"+
                " a.deduct_stand as 扣分标准,a.deduct_score as 单项分值,a.type as 主客观分类 from"+
                " T_MEDICAL_MARK a inner join t_medical_mark_text b on a.id=b.mark_id where b.text_id='" + textKind_id + "' and type='Y'";

            dgvRules.DataSource = App.GetDataSet(strSql).Tables[0].DefaultView;

            dgvRules.Columns["检查要求"].Visible = false;
            dgvRules.Columns["主客观分类"].Visible = false;
            dgvRules.Columns["评分类别"].Visible = false;
            dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRules.Refresh();
        }

        /// <summary>
        /// 双击规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (AddMark != null)
                {
                    AddMark(dgvRules.CurrentRow.Cells["ID"].Value.ToString(),
                                dgvRules.CurrentRow.Cells["评分类别"].Value.ToString(),
                                dgvRules.CurrentRow.Cells["扣分标准"].Value.ToString(),
                                dgvRules.CurrentRow.Cells["单项分值"].Value.ToString(),
                                App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                    this.Dispose();
                    this.Close();
                }
            }
        }

   
           
    }
}
