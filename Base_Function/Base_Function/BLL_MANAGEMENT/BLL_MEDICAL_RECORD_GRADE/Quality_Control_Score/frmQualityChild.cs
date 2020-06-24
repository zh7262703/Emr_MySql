using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using TextEditor;
using System.Xml;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class frmQualityChild : DevComponents.DotNetBar.Office2007Form
    {
        public delegate void RefEventHandler();
        public event RefEventHandler Refresh;   //质控完成、关闭窗体、重新查询可质控患者
        bool sqc = false;
        bool fgs = false;
        InPatientInfo inPatient;

        string type = "";//D：医生自评；S：科室自评；H：院级；E：终末；M：病历评分；
        string qPerson = "";//质控人员
        string qSection = "";//质控科室
        string qTime = "";//最后质控时间    
        string isRead = "";//是否仅限查看
        List<string> listMark = new List<string> { };  //自动质控扣分勾选，关闭窗体时提示自动质控是否有未保存操作

        DataGridView dgvKouFen = new DataGridView();
        public frmQualityChild()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数,评分环节调用
        /// </summary>
        /// <param name="pId">病人ID</param>
        /// <param name="qPerson">质控人员</param>
        /// <param name="qSection">质控科室</param>
        /// <param name="qTime">最后质控日期</param>
        /// <param name="type">界面调用标志</param>
        public frmQualityChild(string strId, string strQPerson, string strQSection, string strQTime, string strType)
        {
            InitializeComponent();

            inPatient = DataInit.GetInpatientInfoByPid(strId);
            type = strType;
            qPerson = strQPerson;
            qSection = strQSection;
            qTime = strQTime;
        }

        /// <summary>
        /// 构造函数,评分环节调用
        /// </summary>
        /// <param name="pId">病人ID</param>
        /// <param name="qPerson">质控人员</param>
        /// <param name="qSection">质控科室</param>
        /// <param name="qTime">最后质控日期</param>
        /// <param name="type">界面调用标志</param>
        /// <param name="isRead">是否仅限查看</param>
        public frmQualityChild(string strId, string strQPerson, string strQSection, string strQTime, string strType, string strIsRead)
        {
            InitializeComponent();

            inPatient = DataInit.GetInpatientInfoByPid(strId);
            type = strType;
            qPerson = strQPerson;
            qSection = strQSection;
            qTime = strQTime;
            isRead = strIsRead;

        }


        private void frmQualityChild_Load(object sender, EventArgs e)
        {
            try
            {
                DataInit.CurrentPatient = inPatient;

                //自动质控界面lable赋值            
                lblInCount.Text = inPatient.InHospital_count.ToString() != "" ? inPatient.InHospital_count.ToString() : "";
                lblPName.Text = inPatient.Patient_Name.ToString() != "" ? inPatient.Patient_Name.ToString() : "";
                //lblSex.Text = DataInit.StringFormat(inPatient.Gender_Code);//DataInit方法与性别字典中的性别code对应不上
                if (!string.IsNullOrEmpty(inPatient.Gender_Code))
                    lblSex.Text = inPatient.Gender_Code.ToString() == "1" ? "男" : "女";
                if (!string.IsNullOrEmpty(inPatient.Age) && !string.IsNullOrEmpty(inPatient.Age_unit))
                    lblAge.Text = inPatient.Age.ToString() + inPatient.Age_unit.ToString();
                lblSectionName.Text = inPatient.Section_Name.ToString() != "" ? inPatient.Section_Name.ToString() : "";
                //if (inPatient.Pay_Manager != null)
                //{
                if (!string.IsNullOrEmpty(inPatient.Pay_Manager))
                {
                    // string strs = "select name from t_data_code where type='70' and enable='Y' and code='" + inPatient.Pay_Manager + "'";
                    lblPay.Text = inPatient.Pay_Manager;//App.ReadSqlVal(strs, 0, "name");
                }
                //}
                lblQPperson.Text = qPerson;
                lblQsection.Text = qSection;
                lblQTime.Text = qTime;

                //病历评分,"发送评分通知显示"，“整改通知不显示”
                if (type == "M") { btnSendResult.Visible = false; btnNotice.Enabled = false; }
                else if (type == "H") { btnFinish.Visible = false; }
                else if (type == "D") { btnNotice.Enabled = false; chkKouFen.Enabled = false; }
                else if (type == "S" || type == "E") //科级和终末需要判断是否有未完成的整改通知流程，如果有则只能暂存，确定按钮不可用
                {
                    string id = "";
                    id = App.ReadSqlVal("select id from t_amendments_info t where t.patient_id='" + inPatient.Id.ToString() + "' and t.type='" + type + "' and t.state_flag<>4 ", 0, "id");
                    if (!string.IsNullOrEmpty(id))
                    {
                        btnFinish.Enabled = false;
                    }
                }

                if (isRead == "Y")//仅限查看模式，自动质控只读、扣分项全选不可用、按钮不可用
                {
                    panel_Q.Enabled = false;
                    dgvAutomaticScoring.ReadOnly = true;
                    chkKouFen.Enabled = false;
                }

                //手动质控页签
                ucManualDoc fq = new ucManualDoc(inPatient, isRead);
                fq.Dock = DockStyle.Fill;
                fq.DelScore += new ucManualDoc.RefEventHandler(DelScore);
                fq.AddMark += new ucManualDoc.RefEventHandlerAdd(AddMarkData);
                fq.DelMark += new ucManualDoc.RefEventHandlerDel(DelMark);
                panel_Main.Controls.Add(fq);
                dgvKouFen = this.Controls.Find("dgvKouFen", true)[0] as DataGridView;
                cmbLevel.SelectedIndex = 0;
                //绑定自动质控页签dgv数据
                dgvAutomaticScoringShow();
                SetKouFenHuiZong();
                DelScore();

                BLL_DOCTOR.HisInStance.医嘱单.ucYZ frm = new Base_Function.BLL_DOCTOR.HisInStance.医嘱单.ucYZ(inPatient);
                tabControlPanel4.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                //App.UsControlStyle(frm);

                BLL_DOCTOR.HisInStance.LIS.UcLis uc = new Base_Function.BLL_DOCTOR.HisInStance.LIS.UcLis(inPatient, sqc, fgs);
                tabControlPanel5.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                //App.UsControlStyle(uc);

                BLL_DOCTOR.HisInStance.PACS.ucPasc ucp = new Base_Function.BLL_DOCTOR.HisInStance.PACS.ucPasc(inPatient, sqc, fgs);
                tabControlPanel6.Controls.Add(ucp);
                uc.Dock = DockStyle.Fill;
                //App.UsControlStyle(ucp);

                if (type == "D")
                {
                    tabControl1.Tabs.Remove(tabItem2);
                    this.dgvAutomaticScoring.CellPainting -= new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAutomaticScoring_CellPainting);
                }
            }
            catch
            {
                this.Dispose();
                this.Close();
                App.Msg("加载病人数据错误，请检查病人相关数据！");

            }
        }

        /// <summary>
        /// 重新计算分值
        /// </summary>
        private void DelScore()
        {
            try
            {
                double dScore = 100;
                for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
                {
                    if (dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].EditedFormattedValue.ToString() == Boolean.TrueString)
                        dScore -= Convert.ToDouble(dgvAutomaticScoring.Rows[i].Cells["分值"].Value.ToString());
                }
                for (int j = 0; j < dgvKouFen.Rows.Count; j++)
                {
                    if (dgvKouFen.Rows[j].Cells["isNew"].Value.ToString() != "D")
                        dScore -= Convert.ToDouble(dgvKouFen.Rows[j].Cells["分值"].Value.ToString());
                }
                txtScore.Text = dScore.ToString();
                txtScore.Refresh();
            }
            catch
            { txtScore.Text = "出错"; }
        }

        /// <summary>
        /// 自动质控DataGridView数据绑定
        /// </summary>
        private void dgvAutomaticScoringShow()
        {
            //string strKouFenHuiZong = " select t.id,t.item 缺陷类型,t.item_score 分值,t.item_content 质控项目,medical_mark_id 项目编码," +
            //              "t.ITEM_PATIENTID 病人id,isxg,t.medical_mark_id,docId,t.item_type,'O' isNew" +
            //              " from t_deduct_score t where t.ITEM_PATIENTID='" + inPatient.Id + "' and STATE<>2 and item_type='N'";
            DataSet ds = App.GetDataSet("select CASE WGZT WHEN '1' THEN '时限内未完成'" +
                                        " WHEN '3' THEN '超时未完成'  WHEN '4' THEN '超时完成' END 状态,zljlxh 项目编码,WGXX 质控项目,KFQK 分值 " +
                                        "from qc_zlkzjlk where SYXH='" + inPatient.Id + "' and WGZT in ('1','3','4') and ZKLB = 'YL' ");
            /*--------------ToDo 假数据----------------------*/
            //DataSet ds = App.GetDataSet(strKouFenHuiZong);

            DataTable dt = ds.Tables[0];
            DataColumn dc_1 = new DataColumn("dcFlag_1", typeof(bool));
            dc_1.DefaultValue = false;
            dt.Columns.Add(dc_1);


            //DataColumn dc_2 = new DataColumn("dcFlag_2", typeof(bool));
            //dc_2.DefaultValue = false;
            //dt.Columns.Add(dc_2);

            /*********自动质控假数据  *******************/

            dgvAutomaticScoring.DataSource = dt.DefaultView;
            dgvAutomaticScoring.Columns["项目编码"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvAutomaticScoring.Columns["项目编码"].Visible = false;
            dgvAutomaticScoring.Columns["质控项目"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvAutomaticScoring.Columns["质控项目"].ReadOnly = true;
            dgvAutomaticScoring.Columns["分值"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvAutomaticScoring.Columns["分值"].ReadOnly = true;
            dgvAutomaticScoring.Columns["状态"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvAutomaticScoring.Columns["状态"].ReadOnly = true;
            dgvAutomaticScoring.Columns["dcFlag_1"].HeaderText = "扣分标识（   全选）";
            if (isRead == "Y" || type == "D")
            {
                dgvAutomaticScoring.Columns["dcFlag_1"].ReadOnly = true;
            }
            //dgvAutomaticScoring.Columns["dcFlag_2"].HeaderText = "通知发送（   全选）";
            dgvAutomaticScoring.Columns["dcFlag_1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dgvAutomaticScoring.Columns["dcFlag_2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //加载已勾选扣分项
            string strMarkId = App.ReadSqlVal("select mark_id from T_QUALITY_RELATION where key_id='" + inPatient.Id.ToString() + "' and flag='0'", 0, "mark_id");

            for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(strMarkId))
                {
                    if (strMarkId.Contains("," + dgvAutomaticScoring.Rows[i].Cells["项目编码"].Value.ToString() + ",") || dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() == "时限内未完成" || dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() == "超时未完成")
                    {
                        dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].Value = true;
                    }
                }
                else if (dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() == "时限内未完成" || dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() == "超时未完成")
                {
                    dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].Value = true;
                }
            }

        }

        /// <summary>
        /// 标题复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAutomaticScoring_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                if (dgvAutomaticScoring.Columns[e.ColumnIndex].Name == "dcFlag_1")//扣分表示
                {
                    Point p = this.dgvAutomaticScoring.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                    p.Y += this.dgvAutomaticScoring.ColumnHeadersHeight / 4;
                    p.X += this.dgvAutomaticScoring.Columns[4].Width / 9 * 5;
                    p.Offset(this.dgvAutomaticScoring.Left, this.dgvAutomaticScoring.Top);
                    this.chkKouFen.Location = p;
                    this.chkKouFen.Size = this.dgvAutomaticScoring.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
                    this.chkKouFen.Visible = true;
                    this.chkKouFen.BringToFront();
                    panel_LinkQuality.Refresh();
                    panel_Q.Refresh();
                }
                //else if (dgvAutomaticScoring.Columns[e.ColumnIndex].Name == "dcFlag_2")//通知发送
                //{
                //    Point p = this.dgvAutomaticScoring.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                //    p.Y += this.dgvAutomaticScoring.ColumnHeadersHeight / 4;
                //    p.X += this.dgvAutomaticScoring.Columns[5].Width / 9 * 5;
                //    p.Offset(this.dgvAutomaticScoring.Left, this.dgvAutomaticScoring.Top);
                //    this.chkFaSong.Location = p;
                //    this.chkFaSong.Size = this.dgvAutomaticScoring.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Size;
                //    this.chkFaSong.Visible = true;
                //    this.chkFaSong.BringToFront();              
                //}
            }
        }

        /// <summary>
        /// 表格复选框状态更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAutomaticScoring_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    bool flag = false;
                    //扣分值
                    if (dgvAutomaticScoring.Columns[e.ColumnIndex].Name == "dcFlag_1")
                    {
                        //判断是否点中单元格中复选框
                        if (dgvAutomaticScoring.Rows[e.RowIndex].Cells["dcFlag_1"].EditedFormattedValue.ToString() != dgvAutomaticScoring.Rows[e.RowIndex].Cells["dcFlag_1"].Value.ToString())
                        { //判断自动质控是否有新操作
                            if (listMark.Contains(dgvAutomaticScoring.Rows[e.RowIndex].Cells["项目编码"].Value.ToString()))
                                listMark.Remove(dgvAutomaticScoring.Rows[e.RowIndex].Cells["项目编码"].Value.ToString());
                            else
                                listMark.Add(dgvAutomaticScoring.Rows[e.RowIndex].Cells["项目编码"].Value.ToString());
                        }
                        if (dgvAutomaticScoring.Rows[e.RowIndex].Cells["dcFlag_1"].EditedFormattedValue.ToString() == Boolean.FalseString)
                        {
                            chkKouFen.Checked = false;
                        }
                        else
                        {
                            for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
                            {
                                if (dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].EditedFormattedValue.ToString() == Boolean.FalseString)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == false && chkKouFen.Checked == false)
                            {
                                chkKouFen.Checked = true;
                            }
                        }
                        DelScore();
                    }
                    //else if (dgvAutomaticScoring.Columns[e.ColumnIndex].Name == "dcFlag_2")//发送通知
                    //{
                    //    if (dgvAutomaticScoring.Rows[e.RowIndex].Cells["dcFlag_2"].EditedFormattedValue.ToString() == Boolean.FalseString)
                    //    {
                    //        chkFaSong.Checked = false;
                    //    }
                    //    else
                    //    {
                    //        for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
                    //        {
                    //            if (dgvAutomaticScoring.Rows[i].Cells["dcFlag_2"].EditedFormattedValue.ToString() == Boolean.FalseString)
                    //            {
                    //                flag = true;
                    //                break;
                    //            }
                    //        }
                    //        if (flag == false && chkFaSong.Checked == false)
                    //        {
                    //            chkFaSong.Checked = true;
                    //        }
                    //    }
                    //}
                }
            }
            catch { }
        }

        /// <summary>
        /// 整改通知书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNotice_Click(object sender, EventArgs e)
        {
            if (!SaveData())
            {
                App.Msg("保存失败，请稍后再试！");
                return;
            }
            //“项目编码”为自动质控主键
            //客观
            DataTable dtAutomaticScoring = new DataTable();
            DataColumn dcA_1 = new DataColumn("质控项目");
            dtAutomaticScoring.Columns.Add(dcA_1);
            DataColumn dcA_2 = new DataColumn("状态");
            dtAutomaticScoring.Columns.Add(dcA_2);
            DataColumn dcA_3 = new DataColumn("分值");
            dtAutomaticScoring.Columns.Add(dcA_3);
            DataColumn dcA_4 = new DataColumn("项目编码");
            dtAutomaticScoring.Columns.Add(dcA_4);
            //主观
            DataTable dtKouFen = new DataTable();
            DataColumn dcK_1 = new DataColumn("评分项目");
            dtKouFen.Columns.Add(dcK_1);
            DataColumn dcK_2 = new DataColumn("分值");
            dtKouFen.Columns.Add(dcK_2);
            DataColumn dcK_3 = new DataColumn("扣分标准");
            dtKouFen.Columns.Add(dcK_3);
            //bool flag = false;
            //选中“通知发送”的数据
            for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
            {
                //if (dgvAutomaticScoring.Rows[i].Cells["dcFlag_2"].Value.ToString() == Boolean.TrueString)
                //{
                DataRow dr = dtAutomaticScoring.NewRow();
                dr["质控项目"] = dgvAutomaticScoring.Rows[i].Cells["质控项目"].Value.ToString();
                dr["状态"] = dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString();
                dr["分值"] = dgvAutomaticScoring.Rows[i].Cells["分值"].Value.ToString();
                dr["项目编码"] = dgvAutomaticScoring.Rows[i].Cells["项目编码"].Value.ToString();
                dtAutomaticScoring.Rows.Add(dr);
                //flag = true;
                //}
            }

            for (int i = 0; i < dgvKouFen.Rows.Count; i++)
            {
                if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() != "D")
                {
                    DataRow dr = dtKouFen.NewRow();
                    dr["评分项目"] = dgvKouFen.Rows[i].Cells["评分项目"].Value.ToString();
                    dr["分值"] = dgvKouFen.Rows[i].Cells["分值"].Value.ToString();
                    dr["扣分标准"] = dgvKouFen.Rows[i].Cells["扣分标准"].Value.ToString();
                    dtKouFen.Rows.Add(dr);
                }
            }
            //自动质控和手动质控没有记录
            if (dgvAutomaticScoring.Rows.Count > 0 || dgvKouFen.Rows.Count > 0)
            {
                frmSendNotice frm = new frmSendNotice(dtKouFen, dtAutomaticScoring, inPatient, type, "");
                frm.BtnEnable += new frmSendNotice.RefEventHandler(BtnEnable);
                frm.ShowDialog();
            }
            else
            {
                App.Msg("没有质控信息，无法发送整改通知书！");
            }
        }

        /// <summary>
        /// 除院级权限外发送整改通知之后，质控完成按钮不可用
        /// </summary>
        private void BtnEnable()
        {
            btnFinish.Enabled = false;
        }

        /// <summary>
        /// 发送评分通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendResult_Click(object sender, EventArgs e)
        {
            if (App.Ask("发送评分通知后不可修改，确定发送？"))
            {

            }
        }

        /// <summary>
        /// 未发现质控缺陷，插入一条质控记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            /********质控科室暂时只能取角色名称TODO*********/

            if (type != "H")
            {
                if (!App.Ask("将不可再次评分，是否确定？"))
                    return;
            }

            List<string> sqls = new List<string>();
            string id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");

            sqls.Add("insert into t_medical_record(id,user_id,USER_NAME,patient_id，record_time,type,user_section)" +
                            " values('" + id + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                            inPatient.Id.ToString() + "',sysdate,'" + type + "','" + App.UserAccount.CurrentSelectRole.Role_name + "')");

            //院级不参与权限，所以不更新病人评分汇总表
            if (type != "H")
            {
                if (App.ExecuteSQL("select id from T_DEDUCT_SUMMARY where patient_id='" + inPatient.Id.ToString() + "'") > 0)
                {
                    sqls.Add("update T_DEDUCT_SUMMARY set OPERATOR_USER_ID='" + App.UserAccount.UserInfo.User_id.ToString()
                             + "',OPERATOR_USER_NAME='" + App.UserAccount.UserInfo.User_name.ToString() + "',state='" + type + "' where patient_id='" + inPatient.Id.ToString() + "'");
                }
                else
                {
                    sqls.Add("insert into T_DEDUCT_SUMMARY (PATIENT_ID,OPERATOR_USER_ID,OPERATOR_USER_NAME,STATE) values ('" + inPatient.Id.ToString() + "','" +
                            App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" + type + "')");
                }
            }
            sqls.Add("delete T_quality_locked where PATIENT_ID='" + inPatient.Id.ToString() + "'");//评分解锁
            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                if (Refresh != null)
                    Refresh();
                App.Msg("操作成功");
                this.Dispose();
                this.Close();

            }
            else
                App.Msg("请稍后再试！");
        }

        /// <summary>
        /// 保存质控信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                //除“院级”权限外，提交之后不可再次修改
                if (type != "H")
                {
                    if (!App.Ask("将不可再次评分，是否确定？"))
                        return;
                }
                List<string> sqls = new List<string>();

                //插入质控记录表          
                string id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");
                //质控记录表
                sqls.Add("insert into t_medical_record(id,user_id,USER_NAME,patient_id，record_time,type,user_section)" +
                                " values('" + id + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                                inPatient.Id.ToString() + "',sysdate,'" + type + "','" + App.UserAccount.CurrentSelectRole.Role_name + "')");

                //手动质控
                for (int i = 0; i < dgvKouFen.Rows.Count; i++)
                {
                    if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N")
                    {
                        sqls.Add("insert into t_deduct_score (ID,ITEM,ITEM_CONTENT,ITEM_SCORE,ITEM_PATIENTID,MEDICAL_MARK_ID,isxg,docid,ITEM_TYPE,RECORD_ID,STATE) values (" +
                                        int.Parse(dgvKouFen.Rows[i].Cells["id"].Value.ToString()) + ",'" + dgvKouFen.Rows[i].Cells["评分项目"].Value.ToString() + "','" +
                                        dgvKouFen.Rows[i].Cells["扣分标准"].Value.ToString() + "','" + dgvKouFen.Rows[i].Cells["分值"].Value.ToString() + "','" +
                                        dgvKouFen.Rows[i].Cells["病人id"].Value.ToString() + "','" + dgvKouFen.Rows[i].Cells["medical_mark_id"].Value.ToString() + "','0'," +
                                        dgvKouFen.Rows[i].Cells["docId"].Value.ToString() + ",'Y','" + id + "','0')");
                    }
                    else if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D")
                    {
                        sqls.Add("delete t_deduct_score where ID=" + int.Parse(dgvKouFen.Rows[i].Cells["id"].Value.ToString()) + "'");
                    }
                }
                string strMark_id = ",";
                //保存自动质控扣分项  TODO
                for (int k = 0; k < dgvAutomaticScoring.Rows.Count; k++)
                {
                    if (dgvAutomaticScoring.Rows[k].Cells["dcFlag_1"].Value.ToString() == Boolean.TrueString)
                    {

                        if (dgvAutomaticScoring.Rows[k].Cells["dcFlag_1"].Value.ToString() == Boolean.TrueString)
                        {
                            strMark_id += dgvAutomaticScoring.Rows[k].Cells["项目编码"].Value.ToString() + ",";
                        }
                    }
                }
                if (strMark_id != ",")
                {
                    sqls.Add("delete T_QUALITY_RELATION where key_id='" + inPatient.Id.ToString() + "' and flag='0'");
                    sqls.Add("insert into T_QUALITY_RELATION(key_id,mark_id,OPERATOR_USER_ID,time,flag) values('" + inPatient.Id.ToString() + "','" + strMark_id + "','" +
                            App.UserAccount.UserInfo.User_id.ToString() + "',sysdate,'0')");
                }
                //院级不参与权限，所以不更新病人评分汇总表
                if (type != "H")
                {
                    if (!string.IsNullOrEmpty(App.ReadSqlVal("select id from T_DEDUCT_SUMMARY where patient_id='" + inPatient.Id.ToString() + "'", 0, "id")))
                    {
                        sqls.Add("update T_DEDUCT_SUMMARY set score='" + txtScore.Text.Trim().ToString() + "',OPERATOR_USER_ID='" + App.UserAccount.UserInfo.User_id.ToString()
                                 + "',OPERATOR_USER_NAME='" + App.UserAccount.UserInfo.User_name.ToString() + "',doc_level='" + cmbLevel.SelectedIndex.ToString()
                                 + "',state='" + type + "' where patient_id='" + inPatient.Id.ToString() + "'");
                    }
                    else
                    {
                        sqls.Add("insert into T_DEDUCT_SUMMARY (PATIENT_ID,SCORE,OPERATOR_USER_ID,OPERATOR_USER_NAME,DOC_LEVEL,STATE) values ('" + inPatient.Id.ToString() + "','" +
                                txtScore.Text.Trim().ToString() + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                                cmbLevel.SelectedIndex.ToString() + "','" + type + "')");
                    }
                }
                sqls.Add("delete T_quality_locked where PATIENT_ID='" + inPatient.Id.ToString() + "'");//评分解锁
                if (App.ExecuteBatch(sqls.ToArray()) > 0)
                {
                    //SetKouFenHuiZong();
                    save_doc();
                    if (Refresh != null)
                        Refresh();
                    App.Msg("操作成功！");
                    listMark.Clear();
                    this.Dispose();
                    this.Close();

                }
                else
                    App.Msg("操作失败，请检查所选扣分项稍后再试！");
            }
            catch
            {
                App.Msg("操作失败，请检查所选扣分项稍后再试！");
            }
        }

        /// <summary>
        /// 双击规则触发，添加文书注释和扣分记录汇总
        /// </summary>
        /// <param name="mark_id">规则id</param>
        /// <param name="item">评分项目</param>
        /// <param name="item_con">扣分标准</param>
        /// <param name="item_score">分值</param>        
        /// <param name="did">自增id</param>      
        private void AddMarkData(string mark_id, string item, string item_con, string item_score, string did)
        {
            DevComponents.DotNetBar.TabControl tc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;
            if (tc != null && tc.Tabs.Count > 0)
            {
                Patient_Doc doc = tc.SelectedTab.Tag as Patient_Doc;
                int docId = doc.Id;

                int index = dgvKouFen.Rows.Add();

                this.dgvKouFen.Rows[index].Cells["评分项目"].Value = item;
                this.dgvKouFen.Rows[index].Cells["id"].Value = int.Parse(did).ToString();
                this.dgvKouFen.Rows[index].Cells["分值"].Value = item_score;
                this.dgvKouFen.Rows[index].Cells["扣分标准"].Value = item_con;
                this.dgvKouFen.Rows[index].Cells["病人id"].Value = inPatient.Id;
                this.dgvKouFen.Rows[index].Cells["medical_mark_id"].Value = mark_id;
                this.dgvKouFen.Rows[index].Cells["isxg"].Value = "0";
                this.dgvKouFen.Rows[index].Cells["docId"].Value = docId;
                this.dgvKouFen.Rows[index].Cells["item_type"].Value = "Y";
                this.dgvKouFen.Rows[index].Cells["文书名称"].Value = App.ReadSqlVal("select doc_name from t_patients_doc where tid='" + docId + "'", 0, "doc_name"); //新增 
                this.dgvKouFen.Rows[index].Cells["isNew"].Value = "N"; //新增       

                string id = did;
                string KFBZ = item_con;

                frmText frm = tc.SelectedTab.AttachedControl.Controls[0] as frmText;
                frm.MyDoc.InsertBAPF(id, item_con);
                XmlDocument tempxmldoc = new XmlDocument();
                tempxmldoc.PreserveWhitespace = true;
                tempxmldoc.LoadXml("<emrtextdoc/>");
                frm.MyDoc.ToXML(tempxmldoc.DocumentElement);
                frm.MyDoc.Modified = false;
                DelScore();
            }
            else
            {
                App.MsgWaring("没有打开的文书！");
            }
        }

        /// <summary>
        /// 文书中点击编辑器注释（删除，查看）触发
        /// </summary>
        /// <param name="id"></param>
        public void DelMark(string id, int action)
        {
            try
            {
                if (action == 1)//删除
                {
                    for (int i = 0; i < dgvKouFen.Rows.Count; i++)
                    {
                        if (dgvKouFen.Rows[i].Cells["id"].Value.ToString() == id)
                        {
                            DelScore();
                            //如果不是本次新增操作，则修改列标记为删除标记
                            if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "O")
                            {
                                dgvKouFen.Rows[i].Cells["isNew"].Value = "D";
                                dgvKouFen.Rows[i].Visible = false;
                            }
                            else
                            {
                                dgvKouFen.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
                else if (action == 0)//查看,表格数据变为选中状态
                {
                    for (int i = 0; i < dgvKouFen.Rows.Count; i++)
                    {
                        if (dgvKouFen.Rows[i].Cells["id"].Value.ToString() == id)
                        {
                            dgvKouFen.Rows[i].Selected = true;
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 扣分汇总表显示数据
        /// </summary>
        private void SetKouFenHuiZong()
        {
            try
            {
                string strKouFenHuiZong = " select t.id,t.item 评分项目,t.item_score 分值,t.item_content 扣分标准,a.doc_name 文书名称," +
                                          "t.ITEM_PATIENTID 病人id,isxg,t.medical_mark_id,docId,t.item_type,'O' isNew" +
                                          " from t_patients_doc a inner join t_deduct_score t on a.tid=t.docId where t.ITEM_PATIENTID='" +
                                          inPatient.Id + "' and t.STATE<>2 and t.item_type='Y' order by docId";//显示评分人未确认修改的项

                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                dgvKouFen.Rows.Clear();
                dgvKouFen.Columns.Clear();
                this.dgvKouFen.Columns.Add("id", "id");
                this.dgvKouFen.Columns.Add("评分项目", "评分项目");
                this.dgvKouFen.Columns.Add("分值", "分值");
                this.dgvKouFen.Columns.Add("扣分标准", "扣分标准");
                this.dgvKouFen.Columns.Add("病人id", "病人id");
                this.dgvKouFen.Columns.Add("isxg", "isxg");
                this.dgvKouFen.Columns.Add("medical_mark_id", "medical_mark_id");
                this.dgvKouFen.Columns.Add("docId", "docId");
                this.dgvKouFen.Columns.Add("item_type", "item_type");
                this.dgvKouFen.Columns.Add("isNew", "isNew");
                this.dgvKouFen.Columns.Add("文书名称", "文书名称");

                this.dgvKouFen.Columns["id"].Visible = false;
                this.dgvKouFen.Columns["病人id"].Visible = false;
                this.dgvKouFen.Columns["评分项目"].Width = 100;
                this.dgvKouFen.Columns["分值"].Width = 50;
                this.dgvKouFen.Columns["扣分标准"].Width = 250;
                this.dgvKouFen.Columns["medical_mark_id"].Visible = false;
                this.dgvKouFen.Columns["item_type"].Visible = false;
                this.dgvKouFen.Columns["isxg"].Visible = false;
                this.dgvKouFen.Columns["docId"].Visible = false;
                this.dgvKouFen.Columns["isNew"].Visible = false;//新增数据标识

                //为了往dgv中新增数据，不用数据绑定
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int index = dgvKouFen.Rows.Add();

                    this.dgvKouFen.Rows[index].Cells["评分项目"].Value = ds.Tables[0].Rows[i]["评分项目"].ToString();
                    this.dgvKouFen.Rows[index].Cells["id"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                    this.dgvKouFen.Rows[index].Cells["分值"].Value = ds.Tables[0].Rows[i]["分值"].ToString();
                    this.dgvKouFen.Rows[index].Cells["扣分标准"].Value = ds.Tables[0].Rows[i]["扣分标准"].ToString();
                    this.dgvKouFen.Rows[index].Cells["病人id"].Value = ds.Tables[0].Rows[i]["病人id"].ToString();
                    this.dgvKouFen.Rows[index].Cells["medical_mark_id"].Value = ds.Tables[0].Rows[i]["medical_mark_id"].ToString();
                    this.dgvKouFen.Rows[index].Cells["isxg"].Value = ds.Tables[0].Rows[i]["isxg"].ToString();
                    this.dgvKouFen.Rows[index].Cells["docId"].Value = ds.Tables[0].Rows[i]["docId"].ToString();
                    this.dgvKouFen.Rows[index].Cells["item_type"].Value = ds.Tables[0].Rows[i]["item_type"].ToString();
                    this.dgvKouFen.Rows[index].Cells["文书名称"].Value = ds.Tables[0].Rows[i]["文书名称"].ToString();
                    this.dgvKouFen.Rows[index].Cells["isNew"].Value = "O";          //O 数据库查出数据；N 本次操作新增数据据； D 本次操作删除数据（数据库查出数据）
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 保存注释文书
        /// </summary>
        private void save_doc()
        {
            Control[] controls = this.Controls.Find("tctlDoc", true);
            if (controls != null && controls.Length>0)
            {
                DevComponents.DotNetBar.TabControl tctlDoc = controls[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                {
                    frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    frm.MyDoc.ToXML(tempxmldoc.DocumentElement);
                    //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, frm.MyDoc.Us.Tid.ToString() + ".xml", frm.MyDoc.Us.InpatientInfo.Id.ToString());
                    frm.MyDoc.Modified = false;

                    String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", frm.MyDoc.Us.Tid.ToString());
                    MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                    xmlPars[0] = new MySqlDBParameter();
                    xmlPars[0].ParameterName = "doc1";
                    xmlPars[0].Value = tempxmldoc.OuterXml;
                    xmlPars[0].DBType = MySqlDbType.Text;
                    App.ExecuteSQL(sql_clob, xmlPars);

                }
            }
            //else
            //{
            //    App.MsgWaring("没有打开的文书！");
            //}
        }

        /*******临时*********/
        private void 质控信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /********改成编辑器右键传文书类型TODO**********/
            frmRepartRule frm = new frmRepartRule("125");
            frm.AddMark += new frmRepartRule.RefEventHandler(AddMarkData);
            frm.ShowDialog();
        }

        /// <summary>
        /// 病历等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            double result = 0;
            if (double.TryParse(txtScore.Text.ToString(), out result))
            {
                if (Convert.ToDouble(txtScore.Text.ToString()) < 60)
                {
                    cmbLevel.SelectedIndex = 2;
                    if (Convert.ToDouble(txtScore.Text.ToString()) < 0)
                    {
                        txtScore.Text = "0";
                    }
                }
                else if (Convert.ToDouble(txtScore.Text.ToString()) >= 60 && Convert.ToDouble(txtScore.Text.ToString()) < 80)
                {
                    cmbLevel.SelectedIndex = 1;
                }
                else if (Convert.ToDouble(txtScore.Text.ToString()) >= 80)
                {
                    cmbLevel.SelectedIndex = 0;
                }
            }
        }

        private void chkFaSong_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
            //    {
            //        dgvAutomaticScoring.Rows[i].Cells["dcFlag_2"].Value = chkFaSong.Checked;
            //    }                
            //}
            //catch
            //{
            //    App.Msg("当前患者无数据或没有选择任何数据！");
            //}

        }



        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTempSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                App.Msg("操作成功！");
            }
            else
                App.Msg("保存失败，请稍后再试！");
        }

        /// <summary>
        /// 保存当前操作
        /// </summary>
        private bool SaveData()
        {
            //插入质控记录表
            List<string> sqls = new List<string>();
            string id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");
            //质控记录表
            sqls.Add("insert into t_medical_record(id,user_id,USER_NAME,patient_id，record_time,type,user_section)" +
                            " values('" + id + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                            inPatient.Id.ToString() + "',sysdate,'" + type + "','" + App.UserAccount.CurrentSelectRole.Role_name + "')");

            //保存手动质控
            for (int i = 0; i < dgvKouFen.Rows.Count; i++)
            {
                if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N")
                {
                    sqls.Add("insert into t_deduct_score (ID,ITEM,ITEM_CONTENT,ITEM_SCORE,ITEM_PATIENTID,MEDICAL_MARK_ID,isxg,docid,ITEM_TYPE,RECORD_ID,STATE) values (" +
                                    int.Parse(dgvKouFen.Rows[i].Cells["id"].Value.ToString()) + ",'" + dgvKouFen.Rows[i].Cells["评分项目"].Value.ToString() + "','" +
                                    dgvKouFen.Rows[i].Cells["扣分标准"].Value.ToString() + "','" + dgvKouFen.Rows[i].Cells["分值"].Value.ToString() + "','" +
                                    dgvKouFen.Rows[i].Cells["病人id"].Value.ToString() + "','" + dgvKouFen.Rows[i].Cells["medical_mark_id"].Value.ToString() + "','0'," +
                                    dgvKouFen.Rows[i].Cells["docId"].Value.ToString() + ",'Y','" + id + "','0')");
                }
                else if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D")
                {
                    sqls.Add("delete t_deduct_score where ID='" + int.Parse(dgvKouFen.Rows[i].Cells["id"].Value.ToString()) + "'");
                }
            }
            string strMark_id = ",";
            //保存自动质控扣分项
            for (int k = 0; k < dgvAutomaticScoring.Rows.Count; k++)
            {

                if (dgvAutomaticScoring.Rows[k].Cells["dcFlag_1"].Value.ToString() == Boolean.TrueString)
                {
                    strMark_id += dgvAutomaticScoring.Rows[k].Cells["项目编码"].Value.ToString() + ",";
                }

            }
            if (strMark_id != ",")
            {
                sqls.Add("delete T_QUALITY_RELATION where key_id='" + inPatient.Id.ToString() + "' and flag='0'");
                sqls.Add("insert into T_QUALITY_RELATION(key_id,mark_id,OPERATOR_USER_ID,time,flag) values('" + inPatient.Id.ToString() + "','" + strMark_id + "','" +
                        App.UserAccount.UserInfo.User_id.ToString() + "',sysdate,'0')");
            }
            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                save_doc();
                SetKouFenHuiZong();
                listMark.Clear();
                return true;

            }
            else
                return false;
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (listMark.Count > 0)
            {
                if (!App.Ask("您有操作没保存，确定要关闭吗？"))
                {
                    return;
                }
            }
            for (int i = 0; i < dgvKouFen.Rows.Count; i++)
            {
                if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N" || dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D")
                {
                    if (!App.Ask("您有操作没保存，确定要关闭吗？"))
                    {
                        return;
                    }
                }
            }
            App.ExecuteSQL("delete T_quality_locked where PATIENT_ID='" + inPatient.Id.ToString() + "'");
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 关闭窗体触发事件，如果有未提交操作则提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQualityChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listMark.Count > 0)
            {
                if (!App.Ask("您有操作没保存，确定要关闭吗？"))
                {
                    return;
                }
            }
            for (int i = 0; i < dgvKouFen.Rows.Count; i++)
            {
                if (dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "N" || dgvKouFen.Rows[i].Cells["isNew"].Value.ToString() == "D")
                {
                    if (!App.Ask("您有操作没保存，确定要关闭吗？"))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// 评分解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQualityChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                App.ExecuteSQL("delete T_quality_locked where PATIENT_ID='" + inPatient.Id.ToString() + "'");
            }
            catch { }
        }


        private void chkKouFen_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvAutomaticScoring.Rows.Count; i++)
                {
                    if (dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() != "时限内未完成" && dgvAutomaticScoring.Rows[i].Cells["状态"].Value.ToString() != "超时未完成")
                    {
                        //判断自动质控勾选操作是否更改
                        if (dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].Value.ToString() != chkKouFen.Checked.ToString())
                        {
                            if (listMark.Contains(dgvAutomaticScoring.Rows[i].Cells["项目编码"].Value.ToString()))
                                listMark.Remove(dgvAutomaticScoring.Rows[i].Cells["项目编码"].Value.ToString());
                            else
                                listMark.Add(dgvAutomaticScoring.Rows[i].Cells["项目编码"].Value.ToString());
                        }
                        dgvAutomaticScoring.Rows[i].Cells["dcFlag_1"].Value = chkKouFen.Checked;
                    }
                }
                DelScore();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 根据自动质控状态 判断勾选状态是否可修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAutomaticScoring_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvAutomaticScoring.Rows[e.RowIndex].Cells["状态"].Value.ToString() == "时限内未完成" || dgvAutomaticScoring.Rows[e.RowIndex].Cells["状态"].Value.ToString() == "超时未完成")
            {
                e.Cancel = true;
            }
        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            if (e.NewTab == this.tabItem1)
            {
                this.dgvAutomaticScoring.Refresh();
            }
        }
    }
}
