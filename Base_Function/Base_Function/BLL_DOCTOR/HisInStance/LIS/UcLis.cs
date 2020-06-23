using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Digital_Medical_Treatment;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.HisInStance.LIS
{
    public partial class UcLis : UserControl
    {
        RichTextBox rtxtBx = new RichTextBox();
        string Sql_A = "";
        DataTable ds;
        private InPatientInfo inPateintInfo;

        /// <summary>
        /// 读取LIS方法的绑定
        /// </summary>
        public EventHandler GetListValue;

        string SqlConditions = "";

        public bool flg;


        /// <summary>
        /// 构造函数
        /// </summary>
        public UcLis()
        {
            InitializeComponent();
            lisoutres = new List<LisOutPutResult>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pid">病人主键</param>
        public UcLis(string Pid)
        {
            InitializeComponent();
            txtPid.Text = Pid;
            lisoutres = new List<LisOutPutResult>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pid">病人主键</param>
        public UcLis(string Pid, string sqlconditions)
        {
            InitializeComponent();
            txtPid.Text = Pid;
            SqlConditions = sqlconditions;
            lisoutres = new List<LisOutPutResult>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pid">病人主键</param>
        public UcLis(InPatientInfo patient, string msg)
        {
            InitializeComponent();
            txtPid.Text = patient.PId;
            lisoutres = new List<LisOutPutResult>();
            btnSure.Enabled = false;

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public UcLis(InPatientInfo patient)
        {
            InitializeComponent();
            txtPid.Text = patient.PId;
            lisoutres = new List<LisOutPutResult>();
        }
        /// <summary>
        /// 构造函数-质控查看
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public UcLis(InPatientInfo patient, bool flag, bool e)
        {
            InitializeComponent();
            txtPid.Text = patient.PId;
            lisoutres = new List<LisOutPutResult>();
            btnSure.Enabled = false;
            btnCancel.Enabled = false;
            GridAction.SetGridStyle(flgview_Patient);
            GridAction.SetGridStyle(flgView_Yb);
        }

        private void FrmLis_Load(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                btnSure.Visible = false;
            }
            btnOk_Click(sender, e);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string Sql = "select distinct a.mzh as 住院号,xm as 姓名,nl as 年龄,jyrq as 检验日期,b.YZXMMC as 检验项目,bbmc as 标本名称,jyrmc as 申请人,b.yzxmdm as 检验项目代码,a.bblsh as 标本流水号 from t_Lis_Sample a left join t_lis_result b  on a.bblsh=b.bblsh where mzh='" + txtPid.Text.Trim() + "'" + SqlConditions + " order by jyrq desc";
//                string Sql = @"select  t.his_id,t.pid 住院号,t.patient_name 姓名,m.jyrq 检验日期,d.xmmc 检验项目,t.card_id 身份证号,m.bbmc 标本名称,m.jyrmc 
// 申请人,d.xmdm 检验项目代码,m.bblsh 标本流水号 
//                                from t_lis_sample  m 
//                                inner join t_in_patient t on m.mzh=t.pid                                 
//                                inner join t_lis_result d on d.bblsh=m.bblsh
//                                where  t.pid='" + txtPid.Text.Trim() + "'";
                
                flgview_Patient.DataSource = App.GetDataSet(Sql).Tables[0].DefaultView;
                flgview_Patient.Refresh();

                flgview_Patient.Cols["检验项目代码"].Visible = false;

                flgview_Patient.Cols["标本流水号"].Visible = false;

                flgView_Yb.Cols[""].Visible = false;

                for (int i = 1; i < flgview_Patient.Rows.Count; i++)
                {
                    flgview_Patient.Rows[i]["年龄"] = flgview_Patient.Rows[i]["年龄"].ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("LIS数据库连接失败，具体原因：" + ex.Message);
            }
        }

        private string mzh;
        private string yblsh;
        private string jyxmdm;
        private void flgview_Patient_SelChange(object sender, EventArgs e)
        {
            try
            {
                flgView_Yb.Clear();
                flgView_Gm.Clear();
                mzh = flgview_Patient[flgview_Patient.RowSel, "住院号"].ToString();
                yblsh = flgview_Patient[flgview_Patient.RowSel, "标本流水号"].ToString();
                jyxmdm = flgview_Patient[flgview_Patient.RowSel, "检验项目代码"].ToString();
                //if (jyxmdm == "")
                //{
                //    Sql_A = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 报告时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "' and yzxmdm is null order by xmjg asc";
                //}
                //else
                //{
                //    Sql_A = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 报告时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "' and yzxmdm='" + jyxmdm + "' order by xmjg asc";
                //}
                //if (jyxmdm == "")
                //{
                //    Sql_A = "select test_no as 项目代码,REPORT_ITEM_NAME as 项目名称,'' as 项目英文名称,RESULT as 项目结果,UNITS as 单位,PRINT_CONTEXT as 参考值范围,RESULT_DATE_TIME as 测试时间,ABNORMAL_INDICATOR as 标志 from lab_result@dbhislink r where test_no='" + yblsh + "'";
                //}
                //else
                //{
                Sql_A = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 测试时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "'";// and yzxmdm='" + jyxmdm + "'";
                //}
                DataTable dt = App.GetDataSet(Sql_A).Tables[0];
                DataColumn dc = new DataColumn("dcSectFlag", typeof(bool));
                dc.Caption = "选择标记";
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                SetTableSelFlag(dt, yblsh, jyxmdm);
                flgView_Yb.DataSource = dt;
                flgView_Yb.Select(0, 0);
                flgView_Yb.Refresh();
                flgView_Yb.Cols["项目代码"].Visible = false;
                flgView_Yb.Cols["项目英文名称"].Visible = false;

                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    if (flgView_Yb.Rows[i]["标志"].ToString().ToUpper() == "L")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;
                    }
                    else if (flgView_Yb.Rows[i]["标志"].ToString().ToUpper() == "H")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.Red;
                    }


                    if (flgView_Yb.Rows[i]["标志"].ToString().ToLower() == "低")
                    {
                        flgView_Yb.Rows[i]["项目结果"] = flgView_Yb.Rows[i]["项目结果"] + "↓";
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;

                    }
                    else if (flgView_Yb.Rows[i]["标志"].ToString().ToLower() == "高")
                    {
                        flgView_Yb.Rows[i]["项目结果"] = flgView_Yb.Rows[i]["项目结果"] + "↑";
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.Red;
                    }

                    if (flgView_Yb.Rows[i]["项目结果"].ToString().ToLower() == "阴性")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;
                    }
                    else if (flgView_Yb.Rows[i]["项目结果"].ToString().ToLower() == "阳性")
                    {
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.OrangeRed;
                    }

                }
                this.flgView_Yb.Focus();
                flgview_Patient.AllowEditing = false;
                flgView_Yb.Cols["项目名称"].AllowEditing = false;
                flgView_Yb.Cols["项目结果"].AllowEditing = false;
                flgView_Yb.Cols["单位"].AllowEditing = false;
                flgView_Yb.Cols["参考值范围"].AllowEditing = false;
                flgView_Yb.Cols["报告时间"].AllowEditing = false;
                flgView_Yb.Cols["标志"].AllowEditing = false;
                flgView_Yb.Cols["dcSectFlag"].AllowEditing = true;
            }
            catch
            {
                //string sql = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 报告时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "' and yzxmdm is null order by xmjg asc";
                //DataTable dt = App.GetDataSet(sql).Tables[0];
                //flgView_Yb.DataSource = dt;
                //DataColumn dc = new DataColumn("dcSectFlag", typeof(bool));
                //dc.Caption = "选择标记";
                //dc.DefaultValue = false;
                //dt.Columns.Add(dc);
                //flgView_Yb.Cols["项目代码"].Visible = false;
                //flgView_Yb.Cols["项目英文名称"].Visible = false;
            }
        }

        private void SetTableSelFlag(DataTable dt, string str1, string str2)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string s3 = dr["项目代码"].ToString();
                bool iexists = false;
                try
                {
                    iexists = lisoutres.Exists(delegate(LisOutPutResult l) { return l.Xmdm == s3 && l.Bblsh == str1 && l.Yzxmdm == str2; });
                }
                catch (Exception ex)
                {
                    string sss = ex.ToString();
                }
                if (iexists)
                {
                    dr["dcSectFlag"] = true;
                }
                else
                {
                    dr["dcSectFlag"] = false;
                }
            }
        }

        bool flag = false;
        private void flgView_Yb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                flag = true;

            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (flgView_Yb.Rows[flgView_Yb.RowSel].Selected == true)
                {
                    string content = GetContent();
                    Clipboard.SetDataObject(content);
                }
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    flgView_Yb.Rows[i].Selected = true;
                }
            }
        }

        private string GetContent()
        {
            string con = "";
            for (int i = 0; i < flgView_Yb.Rows.Count; i++)
            {
                if (flgView_Yb.Rows[i].Selected == true && i != 0)
                {
                    string xmmc = flgView_Yb[i, "项目名称"].ToString();
                    string xmjg = flgView_Yb[i, "项目结果"].ToString();
                    string dw = flgView_Yb[i, "单位"].ToString();
                    if (con == "")
                    {
                        con = xmmc + " " + xmjg + " " + dw;
                    }
                    else
                    {
                        con += "," + xmmc + " " + xmjg + " " + dw;
                    }
                }
            }
            return con;
        }

        private void flgView_Yb_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void flgView_Yb_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (flgView_Yb.Rows.Count > 0)
                {
                    flgView_Yb.Rows[flgView_Yb.RowSel].Selected = true;
                    flgView_Yb.Rows[flgView_Yb.RowSel]["dcSectFlag"] = true;
                }
            }
            else
            {
                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    flgView_Yb.Rows[i].Selected = false;
                }
                if (flgView_Yb.RowSel == -1)
                {
                    return;
                }
                flgView_Yb.Rows[flgView_Yb.RowSel].Selected = true;
            }
        }

        private void flgView_Yb_Click(object sender, EventArgs e)
        {

        }

        private void flgView_Yb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                flag = false;
        }

        /// <summary>
        /// 过滤数据
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string ChangeChar(string val)
        {
            if (val.Contains("↓"))
            {
                return val.Replace("↓", "");
            }
            else if (val.Contains("↑"))
            {
                return val.Replace("↑", "");
            }
            return val;
        }
        /// <summary>
        /// 存选中的检查结果
        /// </summary>
        private List<LisOutPutResult> lisoutres = null;
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                string strtext = "";
                for (int i = 0; i < lisoutres.Count; i++)
                {
                    LisOutPutResult lop = lisoutres[i];

                    string jg = "";
                    if (lop.Jgdw.Contains("E"))
                    {
                        jg = ChangeChar(lop.Xmjg) + "*" + lop.Jgdw;
                    }
                    else
                    {
                        jg = ChangeChar(lop.Xmjg) + " " + lop.Jgdw;
                    }
                    if (strtext == "")
                    {
                        strtext = lop.Xmmc + " " + jg;
                    }
                    else
                    {
                        strtext = strtext + "," + lop.Xmmc + " " + jg;
                    }
                }
                #  region Ctrl键 选择项目后 按确定可添加到编辑器中
                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    if (flgView_Yb.Rows[i]["dcSectFlag"].ToString() == "True")
                    {
                        if (strtext == "")
                        {
                            string jg = "";
                            if (flgView_Yb.Rows[i]["单位"].ToString().Contains("E"))
                            {//单位
                                jg = ChangeChar(flgView_Yb.Rows[i]["项目结果"].ToString()) + "*" + flgView_Yb.Rows[i]["单位"].ToString();
                            }
                            else
                            {
                                jg = ChangeChar(flgView_Yb.Rows[i]["项目结果"].ToString()) + " " + flgView_Yb.Rows[i]["单位"].ToString();
                            }
                            strtext = flgView_Yb.Rows[i]["项目名称"].ToString() + " " + jg;
                        }
                        else
                        {
                            string jg = "";
                            if (flgView_Yb.Rows[i]["单位"].ToString().Contains("E"))
                            {//单位
                                jg = ChangeChar(flgView_Yb.Rows[i]["项目结果"].ToString()) + "*" + flgView_Yb.Rows[i]["单位"].ToString();
                            }
                            else
                            {
                                jg = ChangeChar(flgView_Yb.Rows[i]["项目结果"].ToString()) + " " + flgView_Yb.Rows[i]["单位"].ToString();
                            }
                            strtext = strtext + ", " + flgView_Yb.Rows[i]["项目名称"].ToString() + " " + jg;
                        }
                    }
                }
                # endregion
                App.LisResault = strtext;
                if (GetListValue != null)
                    GetListValue(sender, e);
                //this.Close();
                frm_Pasc frm = (this.Parent.Parent.Parent) as frm_Pasc;
                frm.Close();
                #endregion
            }
            catch
            {
                App.Msg("无LIS数据或没有打开文书！");
            }
            flg = true;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.LisResault = "";
            //this.Close();
            frm_Pasc frm = (this.Parent.Parent.Parent) as frm_Pasc;
            frm.Close();
        }

        private void flgView_Yb_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (flgView_Yb.Cols[e.Col].Name == "dcSectFlag")
            {
                string s = flgView_Yb[e.Row, "项目代码"].ToString();
                if (flgView_Yb[e.Row, e.Col].ToString() == Boolean.TrueString)
                {
                    LisOutPutResult l = new LisOutPutResult();
                    l.Bblsh = yblsh;
                    l.Yzxmdm = jyxmdm;
                    l.Xmdm = s;
                    l.Xmmc = flgView_Yb[e.Row, "项目名称"].ToString();
                    l.Xmywmc = flgView_Yb[e.Row, "项目英文名称"].ToString();
                    l.Xmjg = flgView_Yb[e.Row, "项目结果"].ToString();
                    l.Jgdw = flgView_Yb[e.Row, "单位"].ToString();
                    l.Ckz = flgView_Yb[e.Row, "参考值范围"].ToString();
                    l.Cssj = flgView_Yb[e.Row, "报告时间"].ToString();
                    l.Jgbz = flgView_Yb[e.Row, "标志"].ToString();
                    lisoutres.Add(l);
                }
                else
                {
                    LisOutPutResult l = lisoutres.Find(delegate(LisOutPutResult lop) { return lop.Bblsh == yblsh && lop.Yzxmdm == jyxmdm && lop.Xmdm == s; });
                    lisoutres.Remove(l);
                }
            }
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                #region
                for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                {
                    string s = flgView_Yb[i, "项目代码"].ToString();
                    mzh = flgview_Patient[flgview_Patient.RowSel, "住院号"].ToString();
                    yblsh = flgview_Patient[flgview_Patient.RowSel, "标本流水号"].ToString();
                    jyxmdm = flgview_Patient[flgview_Patient.RowSel, "检验项目代码"].ToString();
                    switch (flgView_Yb.Rows[i]["标志"].ToString().ToUpper())
                    {
                        case "L":
                        case "H":
                        case "低":
                        case "高":
                            flgView_Yb.Cols[9][i] = chbAll.Checked;
                            if (flgView_Yb.Cols[9][i].ToString() == Boolean.TrueString)
                            {
                                LisOutPutResult l = new LisOutPutResult();
                                l.Bblsh = yblsh;
                                l.Yzxmdm = jyxmdm;
                                l.Xmdm = s;
                                l.Xmmc = flgView_Yb[i, "项目名称"].ToString();
                                l.Xmywmc = flgView_Yb[i, "项目英文名称"].ToString();
                                l.Xmjg = flgView_Yb[i, "项目结果"].ToString();
                                l.Jgdw = flgView_Yb[i, "单位"].ToString();
                                l.Ckz = flgView_Yb[i, "参考值范围"].ToString();
                                l.Cssj = flgView_Yb[i, "报告时间"].ToString();
                                l.Jgbz = flgView_Yb[i, "标志"].ToString();
                                lisoutres.Add(l);
                            }
                            else
                            {
                                LisOutPutResult l = lisoutres.Find(delegate(LisOutPutResult lop) { return lop.Bblsh == yblsh && lop.Yzxmdm == jyxmdm && lop.Xmdm == s; });
                                lisoutres.Remove(l);
                            }
                            break;
                    }
                    switch (flgView_Yb.Rows[i]["项目结果"].ToString().ToUpper())
                    {
                        case "阴性":
                        case "阳性":
                            flgView_Yb.Cols[9][i] = chbAll.Checked;
                            if (flgView_Yb.Cols[9][i].ToString() == Boolean.TrueString)
                            {
                                LisOutPutResult l = new LisOutPutResult();
                                l.Bblsh = yblsh;
                                l.Yzxmdm = jyxmdm;
                                l.Xmdm = s;
                                l.Xmmc = flgView_Yb[i, "项目名称"].ToString();
                                l.Xmywmc = flgView_Yb[i, "项目英文名称"].ToString();
                                l.Xmjg = flgView_Yb[i, "项目结果"].ToString();
                                l.Jgdw = flgView_Yb[i, "单位"].ToString();
                                l.Ckz = flgView_Yb[i, "参考值范围"].ToString();
                                l.Cssj = flgView_Yb[i, "报告时间"].ToString();
                                l.Jgbz = flgView_Yb[i, "标志"].ToString();
                                lisoutres.Add(l);
                            }
                            else
                            {
                                LisOutPutResult l = lisoutres.Find(delegate(LisOutPutResult lop) { return lop.Bblsh == yblsh && lop.Yzxmdm == jyxmdm && lop.Xmdm == s; });
                                lisoutres.Remove(l);
                            }
                            break;
                    }
                }
                #endregion
            }
            catch (Exception)
            {

                App.Msg("当前患者无数据或没有选择任何数据！");
            }
        }
        string s = "";
        private void chb_qx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                #region
                for (int i = 1; i < flgView_Yb.Rows.Count; i++)
                {
                    s = flgView_Yb[i, "项目代码"].ToString();
                    mzh = flgview_Patient[flgview_Patient.RowSel, "住院号"].ToString();
                    yblsh = flgview_Patient[flgview_Patient.RowSel, "标本流水号"].ToString();
                    jyxmdm = flgview_Patient[flgview_Patient.RowSel, "检验项目代码"].ToString();
                    flgView_Yb.Cols[9][i] = chb_qx.Checked;
                    if (flgView_Yb.Cols[9][i].ToString() == Boolean.TrueString)
                    {
                        LisOutPutResult l = new LisOutPutResult();
                        l.Bblsh = yblsh;
                        l.Yzxmdm = jyxmdm;
                        l.Xmdm = s;
                        l.Xmmc = flgView_Yb[i, "项目名称"].ToString();
                        l.Xmywmc = flgView_Yb[i, "项目英文名称"].ToString();
                        l.Xmjg = flgView_Yb[i, "项目结果"].ToString();
                        l.Jgdw = flgView_Yb[i, "单位"].ToString();
                        l.Ckz = flgView_Yb[i, "参考值范围"].ToString();
                        l.Cssj = flgView_Yb[i, "报告时间"].ToString();
                        l.Jgbz = flgView_Yb[i, "标志"].ToString();
                        lisoutres.Add(l);
                    }
                    else
                    {
                        LisOutPutResult l = lisoutres.Find(delegate(LisOutPutResult lop) { return lop.Bblsh == yblsh && lop.Yzxmdm == jyxmdm && lop.Xmdm == s; });
                        lisoutres.Remove(l);
                    }
                }
                if (!chb_qx.Checked)
                {
                    chbAll.Checked = chb_qx.Checked;
                }
                #endregion
            }
            catch (Exception)
            {
                App.Msg("当前患者无数据或没有选择任何数据！");
            }
        }

        private void flgView_Yb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                flgView_Yb.Rows[flgView_Yb.RowSel].Selected = false;
                flgView_Yb.Rows[flgView_Yb.RowSel]["dcSectFlag"] = false;
            }
            catch
            {
                //TODO:双击空白处异常！
            }
        }
        /// <summary>
        /// 结果分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                groupPanel3.Visible = true;
                tChart3.Series.Clear();
                tChart3.Header.Text = "指标趋势分析图";
                tChart3.Axes.Left.Title.Text = "检测值";
                tChart3.Axes.Bottom.Title.Text = "时间日期";
                tChart3.Panel.Color = Color.White;
                string Sql = "select t.xmdm,t.xmmc,t.xmjg,t.cssj from t_lis_result t inner join t_Lis_Sample a on a.bblsh=t.bblsh " +
                            "where  t.cssj is not null and a.mzh='" + txtPid.Text + "'  order by t.xmjg asc";
                ds = App.GetDataSet(Sql).Tables[0];
                ChkItem item = new ChkItem();
                if (ds != null)
                {
                    for (int i = 0; i < flgView_Yb.Rows.Count; i++)
                    {
                        if (flgView_Yb.Rows[i]["dcSectFlag"].ToString() == "True")
                        {
                            item.Dm = ds.Rows[i - 1]["xmdm"].ToString();
                            item.Mc = ds.Rows[i - 1]["xmmc"].ToString();
                            item.Jcjg = ds.Rows[i - 1]["xmjg"].ToString();
                            item.Dtime = Convert.ToDateTime(ds.Rows[i - 1]["cssj"].ToString());

                            Steema.TeeChart.Styles.Bezier templ = new Steema.TeeChart.Styles.Bezier();
                            templ.Marks.Visible = true;
                            templ.Marks.Style = 0;
                            tChart3.Series.Add(templ);
                            templ.Title = item.Mc;

                            DataRow[] temprows = ds.Select("xmdm='" + item.Dm + "'");
                            for (int j = 0; j < temprows.Length; j++)
                            {
                                if (App.IsNumeric(temprows[j]["xmjg"].ToString()))
                                {
                                    try
                                    {
                                        tChart3.Series[tChart3.Series.Count - 1].Add(Convert.ToSingle(temprows[j]["xmjg"]), temprows[j]["cssj"].ToString());
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }

                    }
                }

            }
            catch
            {

            }
        }
        /// <summary>
        /// 判断是否已经存在项目
        /// </summary>
        /// <returns></returns>
        private bool isHaveItem(ChkItem item)
        {
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                ChkItem tempitem = (ChkItem)flgView_Yb.Rows[i]["dcSectFlag"];
                if (item.Mc == tempitem.Mc)
                {
                    return true;
                }
            }
            return false;
        }
        //取消分析
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.groupPanel3.Visible = false;
        }

    }

    public class LisOutPutResult
    {
        public LisOutPutResult()
        {

        }
        private string bblsh;

        public string Bblsh
        {
            get { return bblsh; }
            set { bblsh = value; }
        }
        private string yzxmdm;

        public string Yzxmdm
        {
            get { return yzxmdm; }
            set { yzxmdm = value; }
        }
        private string xmdm; //项目代码

        public string Xmdm
        {
            get { return xmdm; }
            set { xmdm = value; }
        }
        private string xmmc; //项目名称

        public string Xmmc
        {
            get { return xmmc; }
            set { xmmc = value; }
        }
        private string xmywmc; //项目英文名称

        public string Xmywmc
        {
            get { return xmywmc; }
            set { xmywmc = value; }
        }
        private string xmjg; //项目结果

        public string Xmjg
        {
            get { return xmjg; }
            set { xmjg = value; }
        }
        private string jgdw; //单位

        public string Jgdw
        {
            get { return jgdw; }
            set { jgdw = value; }
        }
        private string ckz;  //参考值范围

        public string Ckz
        {
            get { return ckz; }
            set { ckz = value; }
        }
        private string cssj; //报告时间

        public string Cssj
        {
            get { return cssj; }
            set { cssj = value; }
        }
        private string jgbz; //标志

        public string Jgbz
        {
            get { return jgbz; }
            set { jgbz = value; }
        }
    }
    class ChkItem
    {
        private string dm;
        public string Dm
        {
            get { return dm; }
            set { dm = value; }
        }

        private string mc;
        public string Mc
        {
            get { return mc; }
            set { mc = value; }
        }

        private string jcjg;
        public string Jcjg
        {
            get { return jcjg; }
            set { jcjg = value; }
        }

        private DateTime dtime;
        public DateTime Dtime
        {
            get { return dtime; }
            set { dtime = value; }
        }
    }
}
