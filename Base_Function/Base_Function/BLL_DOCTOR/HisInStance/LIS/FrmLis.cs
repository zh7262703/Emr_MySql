using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.HisInStance.LIS
{
    /// <summary>
    /// 检验检查
    /// </summary>
    public partial class FrmLis : DevComponents.DotNetBar.Office2007Form
    {
        // WebReference2.Service WebService;
        //WebReference_Lis.Service WebService = new WebReference_Lis.Service();
        RichTextBox rtxtBx = new RichTextBox();

        //private delegate void  GetListValue(string s);
        //public GetListValue OnGetLisValue = 

        /// <summary>
        /// 读取LIS方法的绑定
        /// </summary>
        public EventHandler GetListValue;

        string SqlConditions = "";




        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmLis()
        {
            InitializeComponent();
            lisoutres = new List<LisOutPutResult>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pid">病人主键</param>
        public FrmLis(string Pid)
        {
            InitializeComponent();
            txtPid.Text = Pid;
            App.FormStytleSet(this, false);
            lisoutres = new List<LisOutPutResult>();
            //App.GetListDatas(txtPid.Text);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Pid">病人主键</param>
        public FrmLis(string Pid, string sqlconditions)
        {
            InitializeComponent();
            //try
            //{
            //    string medicare_no = App.ReadSqlVal("select medicare_no from t_in_patient t where t.Pid='" + Pid + "'", 0, "medicare_no");
            //    if (!string.IsNullOrEmpty(medicare_no))
            //    {
            //        txtPid.Text = medicare_no;
            //    }
            //    else
            //    {
            //        if (medicare_no.Length > Pid.Length)
            //        {
            //            txtPid.Text = medicare_no;
            //        }
            //        else
            //        {
            //            txtPid.Text = Pid;
            //        }
            //    }
            //}
            //catch
            //{
            //    txtPid.Text = Pid;
            //}
            txtPid.Text = Pid;
            App.FormStytleSet(this, false);
            SqlConditions = sqlconditions;
            lisoutres = new List<LisOutPutResult>();
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public FrmLis(InPatientInfo patient)
        {
            InitializeComponent();
            //txtPid.Text = patient.Patient_Id;
            txtPid.Text = patient.PId;
            lisoutres = new List<LisOutPutResult>();
        }


        private void FrmLis_Load(object sender, EventArgs e)
        {
            //flgView_Yb.TabIndex = 0;
            //this.Activate();
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                btnSure.Visible = false;
            }
            //UpdatePatientLis(txtPid.Text);
            btnOk_Click(sender, e);
        }


        /// <summary>
        /// 当前病人住院号
        /// </summary>
        /// <param name="pid"></param>
        private void UpdatePatientLis(string pid)
        {
            // WebReference_List.LISService Ser = new Bifrost.WebReference_List.LISService();          
            //Ser.GetReport

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //distinct
                //string Sql = "select distinct a.mzh as 住院号,xm as 姓名,nl as 年龄,jyrq as 检验日期,c.yzmc as 检验项目,sfzh as 身份证号,bbdm as 标本代码,bbmc as 标本名称,jyrmc as 申请人,b.yzxmdm as 检验项目代码,a.bblsh as 标本流水号 from hnyz_zxyy.View_LIS_SampleInfo@DBHISLINK a inner join hnyz_zxyy.View_LIS_Result@DBHISLINK b on a.bblsh=b.bblsh inner join hnyz_zxyy.intf_emr_undruginfo@dbhislink c on b.yzxmdm=c.yzdm where mzh='" + txtPid.Text.Trim() + "'" + SqlConditions + " order by jyrq desc";
                // inner join hnyz_zxyy.intf_emr_undruginfo c on b.yzxmdm=c.yzdm  c.yzmc as 检验项目
                string Sql = "select distinct a.mzh as 住院号,xm as 姓名,nl as 年龄,jyrq as 检验日期,b.YZXMMC as 检验项目,bbmc as 标本名称,jyrmc as 申请人,b.yzxmdm as 检验项目代码,a.bblsh as 标本流水号 from t_Lis_Sample a left join t_lis_result b  on a.bblsh=b.bblsh where mzh='" + txtPid.Text.Trim() + "'" + SqlConditions + " order by jyrq desc";
                flgview_Patient.DataSource = App.GetDataSet(Sql).Tables[0].DefaultView;
                flgview_Patient.Refresh();

                flgview_Patient.Cols["检验项目代码"].Visible = false;

                flgview_Patient.Cols["标本流水号"].Visible = false;

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

        private void flgview_Patient_Click(object sender, EventArgs e)
        {

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
                string Sql = "";
                if (jyxmdm == "")
                {
                    Sql = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 报告时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "' and yzxmdm is null";
                }
                else
                {
                    Sql = "select xmdm as 项目代码,xmmc as 项目名称,xmywmc as 项目英文名称,xmjg as 项目结果,jgdw as 单位,ckz as 参考值范围,cssj as 报告时间,jgbz as 标志 from t_lis_result where bblsh='" + yblsh + "' and yzxmdm='" + jyxmdm + "'";
                }
                DataTable dt = App.GetDataSet(Sql).Tables[0];
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

                //CellRange rg = flgView.GetCellRange(RowSel, colSel);
                //rg.StyleNew.ForeColor = Color.Red;

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
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["标志"].Index);
                        //rg.StyleNew.BackColor = Color.Blue;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;

                    }
                    else if (flgView_Yb.Rows[i]["标志"].ToString().ToLower() == "高")
                    {
                        flgView_Yb.Rows[i]["项目结果"] = flgView_Yb.Rows[i]["项目结果"] + "↑";
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["标志"].Index);
                        //rg.StyleNew.BackColor = Color.Red;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.Red;
                    }

                    if (flgView_Yb.Rows[i]["项目结果"].ToString().ToLower() == "阴性")
                    {
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["项目结果"].Index);
                        //rg.StyleNew.BackColor = Color.SkyBlue;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.SkyBlue;
                    }
                    else if (flgView_Yb.Rows[i]["项目结果"].ToString().ToLower() == "阳性")
                    {
                        //C1.Win.C1FlexGrid.CellRange rg = flgView_Yb.GetCellRange(i, flgView_Yb.Cols["项目结果"].Index);
                        //rg.StyleNew.BackColor = Color.OrangeRed;
                        flgView_Yb.Rows[i].StyleNew.BackColor = Color.OrangeRed;
                    }

                }
                this.flgView_Yb.Focus();

                //string Sql2 = "select xmdm as 微生物代码,xmmc as 微生物名称,xmywmc as 微生物英文名称,Kssdm as 抗生素代码,Kssmc as 抗生素名称,csff as 测试方法,Jyjg as 检验结果,mgdjg as 敏感度结果 from T_LIS_RESULTMED where bblsh=" + yblsh + "";
                //string Sql2 = "select  germname 细菌名称, anti_name 抗生素,result 结果,(case opertype when '0' then '手工KB法' when '1' then '仪器MiC法' when '2' then '仪器ＫＢ法' end) 实验方法,'' 参考范围," +
                //              " flag  敏感度  from hnyz_zxyy.view_result_germ_yz where  bblsh = '" + yblsh + "' and patientno='" + mzh + "'";

                //flgView_Gm.DataSource = WebService.GetDataSet(Sql2).Tables[0].DefaultView;
                //flgView_Gm.Refresh();
            }
            catch
            {
                //App.MsgErr(ex.ToString());
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
                this.Close();
                #endregion
            }
            catch
            {
                App.Msg("无LIS数据或没有打开文书！");
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.LisResault = "";
            this.Close();
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

        private void chb_qx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                #region
                for (int i = 1; i < flgView_Yb.Rows.Count; i++)
                {
                    string s = flgView_Yb[i, "项目代码"].ToString();
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
        //private void flgview_Patient_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    this.flgView_Yb.Focus();
        //}

    }

    //public class LisOutPutResult
    //{
    //    public LisOutPutResult()
    //    {

    //    }
    //    private string bblsh;

    //    public string Bblsh
    //    {
    //        get { return bblsh; }
    //        set { bblsh = value; }
    //    }
    //    private string yzxmdm;

    //    public string Yzxmdm
    //    {
    //        get { return yzxmdm; }
    //        set { yzxmdm = value; }
    //    }
    //    private string xmdm; //项目代码

    //    public string Xmdm
    //    {
    //        get { return xmdm; }
    //        set { xmdm = value; }
    //    }
    //    private string xmmc; //项目名称

    //    public string Xmmc
    //    {
    //        get { return xmmc; }
    //        set { xmmc = value; }
    //    }
    //    private string xmywmc; //项目英文名称

    //    public string Xmywmc
    //    {
    //        get { return xmywmc; }
    //        set { xmywmc = value; }
    //    }
    //    private string xmjg; //项目结果

    //    public string Xmjg
    //    {
    //        get { return xmjg; }
    //        set { xmjg = value; }
    //    }
    //    private string jgdw; //单位

    //    public string Jgdw
    //    {
    //        get { return jgdw; }
    //        set { jgdw = value; }
    //    }
    //    private string ckz;  //参考值范围

    //    public string Ckz
    //    {
    //        get { return ckz; }
    //        set { ckz = value; }
    //    }
    //    private string cssj; //报告时间

    //    public string Cssj
    //    {
    //        get { return cssj; }
    //        set { cssj = value; }
    //    }
    //    private string jgbz; //标志

    //    public string Jgbz
    //    {
    //        get { return jgbz; }
    //        set { jgbz = value; }
    //    }
    //}
}
