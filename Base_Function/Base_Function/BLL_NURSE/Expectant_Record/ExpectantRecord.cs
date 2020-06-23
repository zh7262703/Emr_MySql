using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_NURSE.Expectant_Record
{
    public partial class ExpectantRecord : UserControl
    {
        bool isSave = false;//用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID = "";//待产自动增长ID
        string sql_MATERNITY = "";//查询待产记录
        private string PID = "";//住院号
        private string Pidname = "";//病人名字
        private string SickName = "";//病区名字
        private string Bed = "";//床号
        private string PID_IDS = "";//病人ID
        DataSet ds;
        public ExpectantRecord()
        {
           InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid">住院号</param>
        /// <param name="sickname">病区</param>
        /// <param name="bed">床号</param>
        /// <param name="name">病人名字</param>
        /// <param name="pids_id">病人ID</param>
        public ExpectantRecord(string pid,string sickname,string bed,string name,string pids_id)
        {
            try
            {
                InitializeComponent();
                PID = pid;
                Pidname = name;
                SickName = sickname;
                Bed = bed;
                PID_IDS = pids_id;
            }
            catch
            {
            }
        }

        private void ExpectantRecord_Load(object sender, EventArgs e)
        {
            try
            {
                ShowDate();
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                RefleshFrm();
            }
            catch
            {
            }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowDate()
        {
            try
            {
                //sql_MATERNITY = @"select  ID as 编号,to_char(RECORD_TIME,'yyyy-MM-dd') as 日期,to_char(RECORD_TIME,'HH24:mi:ss') as 时间," +
                //        @" PALACE_BOTTOM as 宫底,TIRE_TO_UNCOVER as 胎先露,TIRE_AZIMUTH as 胎方位," +
                //        @" TAIXIN as 胎心,QUICKENED as 胎动,COHESION as 衔接,BLOOD_PRESSURE as 血压,EDEMA as 水肿," +
                //       @" CONTRACTIONS as 宫缩,PROCESSING as 处理,SIGNATURE as 签名,PID as 住院号,PATIENT_ID from T_MATERNITY_BEFORE_RECORD where PATIENT_ID='"+PID_IDS+"'";
                                // + " order by ID desc"
                sql_MATERNITY = "select ID as 编号,to_char(RECORD_TIME,'yyyy-MM-dd') as 日期,to_char(RECORD_TIME,'HH24:mi') as 时间,BLOOD_PRESSURE as 血压,EDEMA as 浮肿," +
                   " PALACE_BOTTOM as 宫底,TIRE_AZIMUTH as 胎位,TAIXIN as 胎心,QUICKENED as 胎动,TIRE_TO_UNCOVER as 先露部位,TOUTONG as 头痛" +
                   " ,TOUYUN as 头晕,EXIN as 恶心,YANHUA as 眼花,REMARK as 备注,signature as 签名,PID as 住院号,PATIENT_ID" +
                   " from T_MATERNITY_BEFORE_RECORD where PATIENT_ID='"+PID_IDS+"'";
                string SQl = sql_MATERNITY;
                ds = App.GetDataSet(SQl);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ucC1FlexGrid1.DataBd(SQl, "编号", false, "", "");
                        ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;

                        ucC1FlexGrid1.fg.Cols["PATIENT_ID"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["PATIENT_ID"].AllowEditing = false;
                        ucC1FlexGrid1.fg.AllowEditing = false;
                    }
                    for (int i = 0; i < ds.Tables[0].Rows.Count+1; i++)
                    {
                        if (ucC1FlexGrid1.fg.Rows[i]["头痛"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["头痛"] = "√";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["头痛"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["头痛"] = "";
                        }
                        
                        if (ucC1FlexGrid1.fg.Rows[i]["头晕"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["头晕"] = "√";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["头晕"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["头晕"] = "";
                        }

                        if (ucC1FlexGrid1.fg.Rows[i]["恶心"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["恶心"] = "√";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["恶心"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["恶心"] = "";
                        }
                        if (ucC1FlexGrid1.fg.Rows[i]["眼花"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["眼花"] = "√";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["眼花"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["眼花"] = "";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            txtFundus.Enabled = false;
            txtFetal_Presentation.Enabled = false;
            txtPosition.Enabled = false;
            txtHeart.Enabled = false;
            txtQuickening.Enabled = false;
            cbxTouTong.Enabled = false;
            txtBloodHigh.Enabled = false;
            txtBloodLow.Enabled = false;
            cbxEdema.Enabled = false;
            cbxTouYun.Enabled = false;
            cbxEXin.Enabled = false;
            cbxYanHua.Enabled = false;
           txtRemark.Enabled = false;
            //txtAutograph.Enabled = false;
            dtpTime.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            ucC1FlexGrid1.fg.Enabled = true;
            if (chKs.Checked == true)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
            isSave = false;


        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtBloodHigh.Text = ""; //血压
                txtBloodLow.Text = "";//血压/低
                cbxEdema.SelectedIndex = 1;//浮肿
                txtFundus.Text = "";//宫底
                txtPosition.Text = "";//胎位
                txtHeart.Text = "";//胎心
                txtQuickening.Text = "";//胎动
                txtFetal_Presentation.Text = "";//先露部位
                cbxTouTong.Checked = false;//头痛
                cbxTouYun.Checked = false;//头晕
                cbxEXin.Checked = false;//恶心
                cbxYanHua.Checked = false;//眼花
                txtRemark.Text = "";//备注
                //txtAutograph.Text = "";//签名
               
            }
            txtBloodHigh.Enabled = true;
            txtBloodLow.Enabled = true;
            cbxEdema.Enabled = true;
            txtFundus.Enabled = true;
            txtPosition.Enabled = true;
            txtHeart.Enabled = true;
            txtQuickening.Enabled = true;
            txtRemark.Enabled = true;
            txtFetal_Presentation.Enabled = true;
            cbxTouTong.Enabled = true;
            cbxTouYun.Enabled = true;
            cbxEXin.Enabled = true;
            cbxYanHua.Enabled = true;
            //txtAutograph.Enabled = true;
            dtpTime.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            ucC1FlexGrid1.fg.Enabled = false;
            txtBloodHigh.Focus();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
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
                string sql = "";
                ID = App.GenId("T_MATERNITY_BEFORE_RECORD", "ID").ToString();
                if (isSave)
                {

                    sql = "insert into T_MATERNITY_BEFORE_RECORD(id, record_time, pid, palace_bottom, tire_to_uncover, tire_azimuth, taixin, quickened, blood_pressure, edema , signature, patient_id, toutong, touyun, exin, yanhua, remark) values(" +
                        ID +
                        ",to_timestamp('" + dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),'" +
                        PID + "','" +
                        txtFundus.Text + "','" +
                        txtFetal_Presentation.Text + "','" +
                        txtPosition.Text + "','" +
                        txtHeart.Text + "','" +
                        txtQuickening.Text + "','" +
                        txtBloodHigh.Text+"/"+txtBloodLow.Text + "','" +
                        cbxEdema.SelectedItem.ToString() + "','" +
                        App.UserAccount.UserInfo.User_name + "'," +
                        PID_IDS + ",'" +
                        cbxTouTong.Checked.ToString() + "','" +
                        cbxTouYun.Checked.ToString() + "','" +
                        cbxEXin.Checked.ToString() + "','" +
                        cbxYanHua.Checked.ToString() + "','" +
                        txtRemark.Text + "')";

                       
                    //+ ID + ",to_timestamp('"
                       //+ dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),'"
                       // +txtFundus.Text+"','"
                       //+txtFetal_Presentation.Text+"','"
                       //+txtPosition.Text+"','"
                       //+txtHeart.Text+"','"
                       //+txtQuickening.Text+"','"
                       //+txtTouTong.Text+"','"
                       //+txtBlood.Text+"','"
                       //+txtEdema.Text+"','"
                       //+txtTouYun.Text+"','"
                       //+txtEXin.Text+"','"
                       //+txtAutograph.Text+"','"+PID+"',"+PID_IDS+")";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    
                    sql = "update t_maternity_before_record"+
                    " set record_time = to_timestamp('"+ dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),"+
                        "pid = '"+PID+"',"+
                        "palace_bottom = '" + txtFundus.Text + "'," +
                        "tire_to_uncover = '" + txtFetal_Presentation.Text + "'," +
                        "tire_azimuth = '" + txtPosition.Text + "'," +
                        "taixin = '" + txtHeart.Text + "'," +
                        "quickened = '" + txtQuickening.Text + "'," +
                        "blood_pressure = '" + txtBloodHigh.Text+"/"+txtBloodLow.Text + "'," +
                        "edema = '" + cbxEdema.SelectedItem.ToString() + "'," +
                        "signature = '" + App.UserAccount.UserInfo.User_name + "'," +
                        "patient_id = "+PID_IDS+","+
                        "toutong = '"+cbxTouTong.Checked.ToString()+"',"+
                        "touyun = '"+cbxTouYun.Checked.ToString()+"',"+
                        "exin = '"+cbxEXin.Checked.ToString()+"',"+
                        "yanhua = '"+cbxYanHua.Checked.ToString()+"',"+
                        "remark = '"+txtRemark.Text+"'"+
                        " where id = " + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString();
                    //sql = "update T_MATERNITY_BEFORE_RECORD set PALACE_BOTTOM='"
                    //    + txtFundus.Text + "',TIRE_TO_UNCOVER='"
                    //    +txtFetal_Presentation.Text +"',TIRE_AZIMUTH='"
                    //    +txtPosition.Text + "',TAIXIN='"
                    //    +txtHeart.Text + "',QUICKENED='"
                    //    +txtQuickening.Text + "',COHESION='"
                    //    +txtTouTong.Text + "',BLOOD_PRESSURE='"
                    //    +txtBlood.Text + "',EDEMA='"
                    //    +txtEdema.Text + "',CONTRACTIONS='"
                    //    +txtTouYun.Text+"',PROCESSING='"
                    //    +txtEXin.Text+"',SIGNATURE='"
                    //    + txtAutograph.Text + "',RECORD_TIME=to_timestamp('"
                    //    + dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),PID='" + PID + "'  where PATIENT_ID=" + PID_IDS + " and ID='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString() + "'";
                    btnUpdate_Click(sender,e);
                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("保存成功！");
                        ShowDate();
                        btnCancel_Click(sender, e);
                    }
                   
                }
       
            }
            catch
            {
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefleshFrms();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrms()
        {

            txtFundus.Text = "";
            txtFetal_Presentation.Text = "";
            txtPosition.Text = "";
            txtHeart.Text = "";
            txtQuickening.Text = "";
            
            txtBloodHigh.Text = "";
            txtBloodLow.Text = "";
            cbxEdema.SelectedIndex = 1;
            cbxTouTong.Checked = false;
            cbxTouYun.Checked = false;
            cbxEXin.Checked = false;
            cbxYanHua.Checked = false;
            //txtAutograph.Text = "";
            
            txtFundus.Enabled = false;
            txtFetal_Presentation.Enabled = false;
            txtPosition.Enabled = false;
            txtHeart.Enabled = false;
            txtQuickening.Enabled = false;
            cbxTouTong.Enabled = false;
            txtBloodHigh.Enabled = false;
            txtBloodLow.Enabled = false;
            cbxEdema.Enabled = false;
            cbxTouYun.Enabled = false;
            cbxEXin.Enabled = false;
            cbxYanHua.Enabled = false;
            //txtAutograph.Enabled = false;
            txtRemark.Enabled = false;
            dtpTime.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            ucC1FlexGrid1.fg.Enabled = true;
            isSave = false;


        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = ucC1FlexGrid1.fg.RowSel;
                if (ucC1FlexGrid1.fg.RowSel >= 0)
                {
                    ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString();
                    string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "日期"].ToString() + " " + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "时间"].ToString();
                    string Blood = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "血压"].ToString();
                    if (Blood.Split('/').Length > 1)
                    {
                        txtBloodHigh.Text = Blood.Split('/')[0].ToString();
                        txtBloodLow.Text = Blood.Split('/')[1].ToString();
                    }
                    else
                    {
                        txtBloodHigh.Text = Blood.Split('/')[0].ToString();
                        txtBloodLow.Text = "";
                    }
                    
                    cbxEdema.SelectedIndex = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "浮肿"].ToString() == "无" ? 1 : 0;
                    txtFundus.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "宫底"].ToString();
                    txtPosition.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "胎位"].ToString();
                    txtHeart.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "胎心"].ToString();
                    txtQuickening.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "胎动"].ToString();
                    txtFetal_Presentation.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "先露部位"].ToString();
                    //症状
                    cbxTouTong.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "头痛"].ToString() == "√" ? true : false;
                    cbxTouYun.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "头晕"].ToString() == "√" ? true : false;
                    cbxEXin.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "恶心"].ToString() == "√" ? true : false;
                    cbxYanHua.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "眼花"].ToString() == "√" ? true : false;
                    
                    //txtTouTong.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "衔接"].ToString();
                    
                    
                    //txtTouYun.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "宫缩"].ToString();
                    //txtEXin.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "处理"].ToString();
                    txtRemark.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "备注"].ToString();
                    //txtAutograph.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "签名"].ToString();
                    
                    dtpTime.Value =Convert.ToDateTime(time);
                    int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
                    if (rows > 0)
                    {
                        if (Rowcount == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //如果不是头行
                            if (rows > 0)
                            {
                                //就改变背景色
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                            {
                                //定义上一次点击过的行还原
                                this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //给上一次的行号赋值
                    Rowcount = rows;
                }
                RefleshFrm();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                string sql = "delete from  T_MATERNITY_BEFORE_RECORD  where  ID='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "编号"].ToString() + "' and PATIENT_ID=" + PID_IDS + "";
                App.ExecuteSQL(sql);
                ShowDate();
                btnCancel_Click(sender,e);
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Date >= dtpStart.Value.Date)
            {
                string sql="";
                sql = sql_MATERNITY;
                if (chKs.Checked == true)
                {
                    if (dtpEnd.Value.Date == dtpStart.Value.Date)
                    {
                        sql = sql_MATERNITY + " and to_char(RECORD_TIME,'yyyy-MM-dd')='" + dtpStart.Text + "'";
                    }
                    else
                    {
                        sql = sql_MATERNITY + " and   to_char(RECORD_TIME,'yyyy-MM-dd') between  '" + dtpStart.Text + "' and  '" + dtpEnd.Text + "'";

                    }
                }
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "编号", false, "", "");
                    ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["PATIENT_ID"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["PATIENT_ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            else
            {
                App.Msg("结束时间大于开始时间！");
            }
        }

        private void txtFundus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFetal_Presentation.Focus();
            }

        }

        private void txtFetal_Presentation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPosition.Focus();
            }
        }

        private void txtPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHeart.Focus();
            }
        }

        private void txtHeart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuickening.Focus();
            }
        }

        private void txtQuickening_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxTouTong.Focus();
            }
        }

        private void txtJion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBloodHigh.Focus();
            }
        }

       

        private void txtEdema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxTouYun.Focus();
            }
        }

        private void txtUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxEXin.Focus();
            }
        }



        private void txtAutograph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTime.Focus();
            }
        }

        private void dtpTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender,e);
            }
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
           //string  sql_MATERNITY1 = @"select  ID as 编号,to_char(RECORD_TIME,'yyyy-MM-dd') as 日期,to_char(RECORD_TIME,'HH24:mi') as 时间," +
           //        @" PALACE_BOTTOM as 宫底,TIRE_TO_UNCOVER as 胎先露,TIRE_AZIMUTH as 胎方位," +
           //        @" TAIXIN as 胎心,QUICKENED as 胎动,COHESION as 衔接,BLOOD_PRESSURE as 血压,EDEMA as 水肿," +
           //       @" CONTRACTIONS as 宫缩,PROCESSING as 处理,SIGNATURE as 签名,PID as 住院号 from T_MATERNITY_BEFORE_RECORD where PID='"+PID+"'";
            string sql_MATERNITY1 = @"select  ID as 编号,to_char(RECORD_TIME,'yyyy-MM-dd') as 日期,to_char(RECORD_TIME,'HH24:mi') as 时间,BLOOD_PRESSURE as 血压,EDEMA as 浮肿,PALACE_BOTTOM as 宫底,TIRE_AZIMUTH as 胎位,TAIXIN as 胎心,QUICKENED as 胎动,TIRE_TO_UNCOVER as 先露部位,(case when TOUTONG='True' then '√' else '' end) as 头痛,(case when TOUYUN='True' then '√' else '' end) as 头晕,(case when EXIN='True' then '√' else '' end) as 恶心,(case when YANHUA='True' then '√' else '' end) as 眼花,REMARK 备注,SIGNATURE as 签名,PID as 住院号 from T_MATERNITY_BEFORE_RECORD where PID='" + PID + "'";
                  
           string SQl = sql_MATERNITY1;
           DataSet ds = App.GetDataSet(SQl);
           if (ds != null)
           {
               if (ds.Tables[0].Rows.Count > 0)
               {
                   FrmExpectant fx = new FrmExpectant(ds, Pidname, SickName, Bed, PID);
                   fx.Show();
               }
           }

        }

        private void chKs_CheckedChanged(object sender, EventArgs e)
        {
            if (chKs.Checked == true)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }
    }
}
