using Bifrost;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class frmStochasticRepart : DevComponents.DotNetBar.Office2007Form
    {

        /// <summary>
        /// 传递数据集
        /// </summary>
        DataTable dst;
        public DataTable DST
        {
            get { return dst; }
            set { dst = value; }
        }
        /// <summary>
        /// 传递窗体调用标识
        /// </summary>
        string strbbtext;
        public string strBBTEXT
        {
            get { return strbbtext; }
            set { strbbtext = value; }
        }
        /// <summary>
        /// 传递查询类型
        /// </summary>
        private string strType;
        public string TYPE
        {
            get { return strType; }
            set { strType = value; }
        }
        /// <summary>
        /// 病历类型
        /// </summary>
        private int bltype;

        public int Bltype
        {
            get { return bltype; }
            set { bltype = value; }
        }
        /// <summary>
        /// 历史评分是否选中
        /// </summary>
        private int lsflag;

        public int Lsflag
        {
            get { return lsflag; }
            set { lsflag = value; }
        }
        /// <summary>
        /// 医生自评是否选中
        /// </summary>
        private int ysflag;

        public int Ysflag
        {
            get { return ysflag; }
            set { ysflag = value; }
        }
        /// <summary>
        /// 科室评分是否选中
        /// </summary>
        private int ksflag;

        public int Ksflag
        {
            get { return ksflag; }
            set { ksflag = value; }
        }
        /// <summary>
        /// 全院评分是否选中
        /// </summary>
        private int qyflag;

        public int Qyflag
        {
            get { return qyflag; }
            set { qyflag = value; }
        }

        public frmStochasticRepart()
        {
            InitializeComponent();
        }

        public frmStochasticRepart(DataTable dstDST, string bbtext, int blType, int ysFlag, int ksFlag, int qyFlag, int lsFlag)
        {
            InitializeComponent();
            this.dst = dstDST;
            this.strbbtext = bbtext;
            this.Bltype = blType;
            this.Ysflag = ysFlag;
            this.Ksflag = ksFlag;
            this.Qyflag = qyFlag;
            this.Lsflag = lsFlag;
        }
        public frmStochasticRepart(string strTYPE)
        {
            InitializeComponent();
            this.strType = strTYPE;
            string sql = "select distinct flag from T_DATA_STOCHASTIC_DETAIL t where t.type='" + strType + "'";
            DataSet ds1 = App.GetDataSet(sql);
            string flag = ds1.Tables[0].Rows[0]["flag"].ToString();
            string strSql = "";
            if (flag == "2")
            {
                strSql = "select t.code as 编号,IN_AREA_NAME as 病区,HIS_ID as his_id,PID as 住院号,PATIENT_NAME as 患者姓名,IN_ITME as 住院日期,DIE_TIME as 出院日期,SICK_DOCTOR_NAME as 管床医生,qyYLFZ as 全院医疗分值 from T_DATA_STOCHASTIC_DETAIL t where t.type='" + strType + "'";
            }
            else
            {
                strSql = "select t.code as 编号,IN_AREA_NAME as 病区,HIS_ID as his_id,PID as 住院号,PATIENT_NAME as 患者姓名,IN_ITME as 住院日期,DIE_TIME as 出院日期,SICK_DOCTOR_NAME as 管床医生,qyYLFZ as 全院医疗分值,ksylfz as 科室医疗分值,ysylfz as 医生医疗分值 from T_DATA_STOCHASTIC_DETAIL t where t.type='" + strType + "'";

            }
            DataSet ds = App.GetDataSet(strSql);
            dst = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            }


        }
        private void frmStochasticRepart_Load(object sender, EventArgs e)
        {
            try
            {
                if (strType == null)
                {
                    dataGridViewX1.DataSource = dst;
                    //运行病历
                    if (Bltype == 1 && Lsflag == 1)
                    {
                        if (Ysflag == 0)
                        {
                            dataGridViewX1.Columns["医生医疗分值"].Visible = false;
                            //dataGridViewX1.Columns["医生护理分值"].Visible = false;
                        }
                        if (Ksflag == 0)
                        {
                            dataGridViewX1.Columns["科室医疗分值"].Visible = false;
                            //dataGridViewX1.Columns["科室护理分值"].Visible = false;
                        }
                        if (Qyflag == 0)
                        {
                            dataGridViewX1.Columns["全院医疗分值"].Visible = false;
                            //dataGridViewX1.Columns["全院护理分值"].Visible = false;
                        }
                    }

                    if (Bltype == 2 && Lsflag == 1)
                    {
                        //if (Ysflag == 0)
                        //{
                        //    dataGridViewX1.Columns["医生医疗扣分值"].Visible = false;
                        //    dataGridViewX1.Columns["医生护理扣分值"].Visible = false;
                        //}
                        //if (Ksflag == 0)
                        //{
                        //    dataGridViewX1.Columns["科室医疗扣分值"].Visible = false;
                        //    dataGridViewX1.Columns["科室护理扣分值"].Visible = false;
                        //}
                        if (Qyflag == 1)
                        {
                            dataGridViewX1.Columns["科室医疗分值"].Visible = false;
                            //dataGridViewX1.Columns["科室护理分值"].Visible = false;
                            dataGridViewX1.Columns["医生医疗分值"].Visible = false;
                            //dataGridViewX1.Columns["医生护理分值"].Visible = false;
                        }
                    }
                    dataGridViewX1.ReadOnly = true;
                }
                else
                {
                    label6.Visible = false;
                    txtName.Visible = false;
                    btnSave.Visible = false;
                }
                this.dataGridViewX1.ReadOnly = true;
            }
            catch
            {

            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    App.Msg("请先输入报表名称！");
                    return;
                }
                string strsql = "select * from t_data_stochastic_type t where t.name='" + txtName + "'";
                DataSet ds = App.GetDataSet(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    App.Msg("当前报表名称已经存在，请重新输入！");
                    return;
                }
                ArrayList addlist = new ArrayList();
                int t_data_stochastic_type_id = App.GenId("t_data_stochastic_type", "id");
                string dtCreateTime = App.GetSystemTime().ToString();
                string strInsertSql = "insert into t_data_stochastic_type(id,name,type,createtime)  values('" + t_data_stochastic_type_id + "','" + txtName.Text.ToString() + "','" + t_data_stochastic_type_id + "',to_date('" + dtCreateTime + "','yyyy-MM-dd hh24:mi:ss'))";
                addlist.Add(strInsertSql);
                //int t_data_stochastic_detail_id = App.GenId("t_data_stochastic_detail", "id");
                int intTYPE = t_data_stochastic_type_id;
                for (int i = 0; i < dst.Rows.Count; i++)
                {

                    //int intID = t_data_stochastic_detail_id;
                    string strCode = dst.Rows[i]["编号"].ToString();
                    string strIN_AREA_NAME = dst.Rows[i]["科室"].ToString();
                    //string strHIS_ID = dst.Rows[i]["id"].ToString();
                    string strPID = dst.Rows[i]["住院号"].ToString();
                    string strPATIENT_NAME = dst.Rows[i]["患者姓名"].ToString();
                    DateTime dtIN_ITME = Convert.ToDateTime(dst.Rows[i]["入院日期"]);
                    //DateTime dtDIE_TIME = Convert.ToDateTime(dst.Rows[i]["出院日期"]);
                    string strSICK_DOCTOR_NAME = dst.Rows[i]["管床医生"].ToString();
                    string strQYYLFZ = "";
                    string strQYHLFZ = "";
                    string strKSYLFZ = "";
                    string strKSHLFZ = "";
                    string strYSYLFZ = "";
                    string strYSHLFZ = "";
                    //if (strbbtext == "1")
                    //{
                    strQYYLFZ = dst.Rows[i]["全院医疗分值"].ToString();
                    //strQYHLFZ = dst.Rows[i]["全院护理分值"].ToString();
                    strKSYLFZ = dst.Rows[i]["科室医疗分值"].ToString();
                    //strKSHLFZ = dst.Rows[i]["科室护理分值"].ToString();
                    strYSYLFZ = dst.Rows[i]["医生医疗分值"].ToString();
                    //strYSHLFZ = dst.Rows[i]["医生护理分值"].ToString();
                    //}
                    //if (strbbtext == "2")
                    //{
                    //    strQYYLFZ = dst.Rows[i]["全院医疗扣分值"].ToString();
                    //    strQYHLFZ = dst.Rows[i]["全院护理扣分值"].ToString();
                    //    strKSYLFZ = dst.Rows[i]["科室医疗扣分值"].ToString();
                    //    strKSHLFZ = dst.Rows[i]["科室护理扣分值"].ToString();
                    //    strYSYLFZ = dst.Rows[i]["医生医疗扣分值"].ToString();
                    //    strYSHLFZ = dst.Rows[i]["医生护理扣分值"].ToString();
                    //}



                    string strInsertSqlTwo = "";
                    if (Bltype == 2)
                    {
                        strInsertSqlTwo = "insert into t_data_stochastic_detail(code,IN_AREA_NAME,PID,PATIENT_NAME,IN_ITME,DIE_TIME,SICK_DOCTOR_NAME,QYYLFZ,QYHLFZ,KSYLFZ,KSHLFZ,YSYLFZ,YSHLFZ,TYPE,flag) values('" + strCode + "','" + strIN_AREA_NAME + "','" + strPID + "','" + strPATIENT_NAME + "',to_date('" + dtIN_ITME + "','yyyy-MM-dd hh24:mi:ss'),to_date('" + Convert.ToDateTime(dst.Rows[i]["出院日期"]) + "','yyyy-MM-dd hh24:mi:ss'),'"
                           + strSICK_DOCTOR_NAME + "','" + strQYYLFZ + "','" + strQYHLFZ + "','" + strKSYLFZ + "','" + strKSHLFZ + "','" + strYSYLFZ + "','" + strYSHLFZ + "','" + intTYPE + "','" + Bltype.ToString() + "')";
                    }
                    else
                    {
                        strInsertSqlTwo = "insert into t_data_stochastic_detail(code,IN_AREA_NAME,PID,PATIENT_NAME,IN_ITME,SICK_DOCTOR_NAME,QYYLFZ,QYHLFZ,KSYLFZ,KSHLFZ,YSYLFZ,YSHLFZ,TYPE,flag) values('" + strCode + "','" + strIN_AREA_NAME + "','" + strPID + "','" + strPATIENT_NAME + "',to_date('" + dtIN_ITME + "','yyyy-MM-dd hh24:mi:ss'),'"
                             + strSICK_DOCTOR_NAME + "','" + strQYYLFZ + "','" + strQYHLFZ + "','" + strKSYLFZ + "','" + strKSHLFZ + "','" + strYSYLFZ + "','" + strYSHLFZ + "','" + intTYPE + "','" + Bltype.ToString() + "')";

                    }
                    addlist.Add(strInsertSqlTwo);
                    //t_data_stochastic_detail_id = App.GenId("t_data_stochastic_detail", "id");
                }
                string[] sqlArr = new string[addlist.Count];
                for (int i = 0; i < sqlArr.Length; i++)
                {
                    sqlArr[i] = addlist[i].ToString();
                }
                int m = App.ExecuteBatch(sqlArr);
                if (m > 0)
                {
                    App.Msg("保存成功！");
                    return;
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

                DataToExcel(dataGridViewX1);

            }
            catch
            {

            }
        }
        /// <summary>
        /// 导出方法
        /// </summary>
        /// <param name="m_DataView"></param>
        public void DataToExcel(DataGridViewX m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewX1.Columns[e.ColumnIndex].HeaderCell.Value.ToString() == "全院医疗分值" && Bltype == 2)
            {
                string pantient_id = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                UcfrmGradeShow frm = new UcfrmGradeShow(pantient_id);
                frm.ShowDialog();
            }
            if (dataGridViewX1.Columns[e.ColumnIndex].HeaderCell.Value.ToString() == "全院医疗扣分值" && Bltype == 1)
            {
                string pantient_id = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                UcfrmGradeShow frm = new UcfrmGradeShow(pantient_id);
                frm.ShowDialog();
            }
        }

        private void 扣分详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                frmKFXQ frm = new frmKFXQ(dataGridViewX1.SelectedRows[0].Cells["编号"].Value.ToString());
                frm.ShowDialog();

            }
        }

        private void btnKFXX_Click(object sender, EventArgs e)
        {
            string patient_id = "";
            if (dst != null)
            {
                foreach (DataRow dr in dst.Rows)
                {
                    if (patient_id == "")
                    {
                        patient_id = "'" + dr["编号"].ToString() + "'";
                    }
                    else
                    {
                        patient_id += ",'" + dr["编号"].ToString() + "'";
                    }
                }
                frmKFXQ kfxq = new frmKFXQ(patient_id);
                kfxq.ShowDialog();
            }

        }
    }
}