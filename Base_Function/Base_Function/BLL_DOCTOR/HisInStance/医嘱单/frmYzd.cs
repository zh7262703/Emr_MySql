using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.HisInStance.医嘱单
{
    public partial class frmYzd : UserControl
    {
        DataSet ds;
        InPatientInfo patient;
        DataTable dt_yz = new DataTable();
        bool msg;

        /// <summary>
        /// 医嘱
        /// </summary>
        public frmYzd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">住院号</param>
        public frmYzd(InPatientInfo inPatient)
        {
            patient = inPatient;
            string sql = @"select ZYH,KSSJ,YZMC,YCJL,YCSL,SYPC,YPYF,XMMC,YPDJ,TZSJ,CZGH,FHGH,FYSX,YSGH,YSXGGH,TZYS,BZXX,LSYZ,XMLX,zfpb from t_in_lsyz where zyh='" + patient.His_id + "'";
            //ds = App.GetHisYz("", patient.His_id);
            ds = App.GetDataSet(sql);
            InitializeComponent();
            lblPatient.Text = "  住院号：" + patient.PId + "   姓名：" + patient.Patient_Name;
            Setdt_yz();
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                chkAll.Visible = false;
                btnSure.Visible = false;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">住院号</param>
        public frmYzd(InPatientInfo inPatient,string msg)
        {
            patient = inPatient;
            string sql = @"select ZYH,KSSJ,YZMC,YCJL,YCSL,SYPC,YPYF,XMMC,YPDJ,TZSJ,CZGH,FHGH,FYSX,YSGH,YSXGGH,TZYS,BZXX,LSYZ,XMLX,zfpb from t_in_lsyz where zyh='" + patient.His_id + "'";
            //ds = App.GetHisYz("", patient.His_id);
            ds = App.GetDataSet(sql);
            InitializeComponent();
            lblPatient.Text = "  住院号：" + patient.PId + "   姓名：" + patient.Patient_Name;
            Setdt_yz();
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                chkAll.Visible = false;
                btnSure.Visible = false;
            }
            btnSure.Enabled = false;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">住院号</param>
        public frmYzd(InPatientInfo inPatient,bool flag,bool e)
        {
            patient = inPatient;
            string sql = @"select ZYH,KSSJ,YZMC,YCJL,YCSL,SYPC,YPYF,XMMC,YPDJ,TZSJ,CZGH,FHGH,FYSX,YSGH,YSXGGH,TZYS,BZXX,LSYZ,XMLX,zfpb from t_in_lsyz where zyh='" + patient.His_id + "'";
            //ds = App.GetHisYz("", patient.His_id);
            ds = App.GetDataSet(sql);
            InitializeComponent();
            lblPatient.Text = "  住院号：" + patient.PId + "   姓名：" + patient.Patient_Name;
            Setdt_yz();
            panel3.Visible = false;
        }
        private void Setdt_yz()
        {
            DataColumn dc = new DataColumn("住院号");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("开始时间");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("医嘱名称");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("剂量");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("数量");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("用法");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("途径");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("停止时间");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("开嘱医生");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("备注");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("项目类型");
            dt_yz.Columns.Add(dc);
            dc = new DataColumn("医嘱类型");
            dt_yz.Columns.Add(dc);

        }

        private void frmYZ_Load(object sender, EventArgs e)
        {
            //App.FormStytleSet(this, true);
            //解决改版后表格中复选框无法选中(放到数据加载前)
            DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
            cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            longDgv.ReadOnly = false;
            foreach (DataGridViewColumn col in longDgv.Columns)
            {
                if (col.Name == "选择")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
            btnOk_Click(sender, e);
            longDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShortDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        /// <summary>
        /// 医嘱查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string conditions = "";

                dt_yz.Clear();
                if (IsLongTabPage)
                {
                    if (ds == null)
                    {
                        //App.Msg("该患者没有医嘱信息。");
                        //this.Close();
                        return;
                    }
                    //repeat_indicator 1:长期医嘱 2:临时医嘱
                    DataRow[] drs = ds.Tables[0].Select("lsyz='长期' " + conditions);
                    foreach (DataRow row in drs)
                    {
                        DataRow dr_yz = dt_yz.NewRow();
                        dr_yz["住院号"] = row["zyh"].ToString();
                        dr_yz["开始时间"] = row["kssj"].ToString();
                        dr_yz["医嘱名称"] = row["yzmc"].ToString();
                        dr_yz["剂量"] = row["ycjl"].ToString();
                        dr_yz["数量"] = row["ycsl"].ToString();
                        dr_yz["用法"] = row["sypc"].ToString();
                        dr_yz["途径"] = row["xmmc"].ToString();
                        dr_yz["停止时间"] = row["tzsj"].ToString();
                        dr_yz["开嘱医生"] = row["ysgh"].ToString();
                        dr_yz["备注"] = row["bzxx"].ToString();
                        dr_yz["医嘱类型"] = row["lsyz"].ToString();
                        dr_yz["项目类型"] = row["xmlx"].ToString();
                        dt_yz.Rows.Add(dr_yz);
                    }
                    longDgv.DataSource = dt_yz.DefaultView;
                    if (!longDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "选择";
                        checkColumn.DisplayIndex = 0;
                        checkColumn.Width = 30;
                        checkColumn.TrueValue = "true";
                        checkColumn.FalseValue = "false";
                        longDgv.Columns.Insert(0, checkColumn);                        
                    }
                    else
                    {
                        for (int i = 0; i < longDgv.Rows.Count; i++)
                        {
                            longDgv[0, i].Value = "false";
                        }
                    }

                    longDgv.AutoResizeColumns();
                }
                else
                {
                    if (ds == null)
                    {
                        //App.Msg("该患者没有医嘱信息。");
                        //this.Close();
                        return;
                    }
                    DataRow[] drs = ds.Tables[0].Select("lsyz='临时' " + conditions);

                    foreach (DataRow row in drs)
                    {
                        DataRow dr_yz = dt_yz.NewRow();
                        dr_yz["住院号"] = row["zyh"].ToString();
                        dr_yz["开始时间"] = row["kssj"].ToString();
                        dr_yz["医嘱名称"] = row["yzmc"].ToString();
                        dr_yz["剂量"] = row["ycjl"].ToString();
                        dr_yz["数量"] = row["ycsl"].ToString();
                        dr_yz["用法"] = row["sypc"].ToString();
                        dr_yz["途径"] = row["xmmc"].ToString();
                        dr_yz["停止时间"] = row["tzsj"].ToString();
                        dr_yz["开嘱医生"] = row["ysgh"].ToString();
                        dr_yz["备注"] = row["bzxx"].ToString();
                        dr_yz["医嘱类型"] = row["lsyz"].ToString();
                        dr_yz["项目类型"] = row["xmlx"].ToString();
                        dt_yz.Rows.Add(dr_yz);
                    }
                    ShortDgv.DataSource = dt_yz.DefaultView;
                    if (!ShortDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "选择";
                        checkColumn.DisplayIndex = 0;
                        checkColumn.Width = 30;
                        checkColumn.TrueValue = "true";
                        checkColumn.FalseValue = "false";
                        ShortDgv.Columns.Insert(0, checkColumn);
                    }
                    else
                    {
                        for (int i = 0; i < ShortDgv.Rows.Count; i++)
                        {
                            ShortDgv[0, i].Value = "false";
                        }
                    }

                    ShortDgv.AutoResizeColumns();
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("查询出错，原因：" + ex.Message);
            }
        }

        void cbHeader_OnCheckBoxClicked(bool state)
        {
            foreach (DataGridViewRow Row in longDgv.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["选择"]).Value = state;
            }
            longDgv.RefreshEdit();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 医嘱属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYzlx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string strtext = "";
            for (int i = 0; i < longDgv.RowCount; i++)
            {
                DataGridViewCheckBoxCell sc = longDgv[0, i] as DataGridViewCheckBoxCell;
                if (sc != null)
                {
                    if (sc.Value != null)
                    {
                        if (sc.Value.ToString() == "true")
                        {
                            if (strtext == "")
                            {
                                strtext = OutText(longDgv.Rows[i]);
                            }
                            else
                            {
                                strtext += ";" + OutText(longDgv.Rows[i]);
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < ShortDgv.RowCount; i++)
            {
                DataGridViewCheckBoxCell sc = ShortDgv[0, i] as DataGridViewCheckBoxCell;
                if (sc != null)
                {
                    if (sc.Value != null)
                    {
                        if (sc.Value.ToString() == "true")
                        {
                            if (strtext == "")
                            {
                                strtext = OutText(ShortDgv.Rows[i]);
                            }
                            else
                            {
                                strtext += ";" + OutText(ShortDgv.Rows[i]);

                            } 
                        }
                    }
                }
            }
            App.His_Yz_Resault = strtext;
            //this.Close();
            frm_Pasc frm = (this.Parent.Parent.Parent) as frm_Pasc;
            frm.Close();

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.His_Yz_Resault = "";
            //this.Close();
            frm_Pasc frm = (this.Parent.Parent.Parent) as frm_Pasc;
            frm.Close();
        }

        /// <summary>
        ///重新排列遗嘱名称
        /// </summary>
        /// <param name="yzm">医嘱名称</param>
        /// <param name="jl">剂量</param>
        /// <param name="sl">数量</param>
        /// <param name="yf">用法</param>
        /// <param name="tj">途径</param>
        /// <returns></returns>
        private string Reset_Yz_Name(string yzm, string jl, string sl, string yf, string tj)
        {
            string newyzm = "";
            try
            {

                string[] tempyzm = yzm.Split('/');
                string dw = ""; //单位

                /*
                 * 获取剂量单位
                 */
                string temp_jl = "";
                int indexstart = 0;
                int indexend = 0;
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (temp_jl == "")
                        temp_jl = tempyzm[1][i].ToString();
                    else
                        temp_jl = temp_jl + tempyzm[1][i];
                    if (!App.IsNumeric(temp_jl))
                    {
                        indexstart = i;
                        break;
                    }
                }
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (tempyzm[1][i] == '*' || tempyzm[1][i] == '＊' || tempyzm[1][i] == ':' || tempyzm[1][i] == '：')
                    {
                        indexend = i;
                        break;
                    }
                }
                dw = tempyzm[1].Substring(indexstart, indexend - indexstart);

                float sl1 = Convert.ToSingle(sl);
                newyzm = tempyzm[0] + " " + tempyzm[1].Substring(0, indexend) + "＊" + sl1.ToString() + " " + tempyzm[2] + @"/" + jl + dw + " " + tj + " " + yf;

            }
            catch
            {
                newyzm = yzm + "," + jl + "," + sl;
            }

            return newyzm;
        }

        /// <summary>
        /// 处理乘组号
        /// </summary>
        /// <param name="dt"></param>
        private void ResetCZBS(DataTable dt)
        {
            string objCZBS = "";
            foreach (DataRow objdr in dt.Rows)
            {
                if (objCZBS == objdr["乘组号"].ToString())
                {
                    continue;
                }
                objCZBS = objdr["乘组号"].ToString();
                DataRow[] drs = dt.Select("乘组号='" + objCZBS + "'");
                if (drs.Length > 1)
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        if (i == 0)
                        {
                            drs[i]["CZH"] = "┐";
                        }
                        else if (i == drs.Length - 1)
                        {
                            drs[i]["CZH"] = "┘";
                        }
                        else
                        {
                            drs[i]["CZH"] = "│";
                        }
                    }
                }
            }
        }


        private string OutText(DataGridViewRow dr)
        {
            string strReturn = "";
            if (dr == null)
                return strReturn;
            if (dr.Cells["项目类型"].Value.ToString() == "西成药")
            {
                strReturn += dr.Cells["医嘱名称"].Value.ToString();
                strReturn += " " + dr.Cells["剂量"].Value.ToString();
                strReturn += dr.Cells["单位"].Value.ToString();
                strReturn += " " + dr.Cells["途径"].Value.ToString();
                strReturn += " " + dr.Cells["用法"].Value.ToString();
            }
            else if (dr.Cells["项目类型"].Value.ToString() != "西成药")
            {
                strReturn += dr.Cells["医嘱名称"].Value.ToString();
                strReturn += " " + dr.Cells["途径"].Value.ToString();
            }
            return strReturn;
        }

        private void dataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewCheckBoxCell sc = longDgv[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
                    if (sc != null)
                    {
                        if (sc.Value != null)
                        {
                            if (sc.Value.ToString() != "true")
                            {
                                sc.Value = "true";
                            }
                            else
                            {
                                sc.Value = "false";
                            }
                        }
                        else
                        {
                            sc.Value = "true";
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell cell = null;
            for (int i = 0; i < longDgv.Rows.Count; i++)
            {
                cell = longDgv[0, i] as DataGridViewCheckBoxCell;
                if (cell != null)
                {

                    if (chkAll.Checked)
                    {
                        cell.Value = "true";
                    }
                    else
                    {
                        cell.Value = "false";
                    }
                }
            }
            for (int i = 0; i < ShortDgv.Rows.Count; i++)
            {
                cell = ShortDgv[0, i] as DataGridViewCheckBoxCell;
                if (cell != null)
                {

                    if (chkAll.Checked)
                    {
                        cell.Value = "true";
                    }
                    else
                    {
                        cell.Value = "false";
                    }
                }
            }
        }
        private bool IsLongTabPage = true;
        private void tabControl1_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (this.tabControl1.SelectedTab.Name == "longtab")
            {
                IsLongTabPage = true;
                btnOk_Click(sender, e);
                longDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else if (this.tabControl1.SelectedTab.Name == "shorttab")
            {
                IsLongTabPage = false;
                btnOk_Click(sender, e);
                ShortDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void longDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                string content = GetContent();
                Clipboard.SetDataObject(content);

            }
        }

        private string GetContent()
        {
            string strtext = "";
            for (int i = 0; i < longDgv.Rows.Count; i++)
            {
                if (longDgv.Rows[i].Selected == true)
                {
                    if (strtext == "")
                    {
                        strtext = OutText(longDgv.Rows[i]);
                    }
                    else
                    {
                        strtext += ";" + OutText(longDgv.Rows[i]);
                    }
                }
            }
            return strtext;
        }

        private void ShortDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                string content = GetContent();
                Clipboard.SetDataObject(content);
            }
        }
    }
}
