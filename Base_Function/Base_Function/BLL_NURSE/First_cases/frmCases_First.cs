
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;

using System.Text.RegularExpressions;
using DevComponents.DotNetBar;
using Base_Function.MODEL;
using Base_Function.BLL_MANAGEMENT.SICKFILE.BINGANCODE;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// 病案首页
    /// 设计者: 杨妹
    /// 设计日期: 2011-11-18
    /// </summary>
    public partial class frmCases_First : UserControl
    {

        //WebReferenceHIS.Service wc= new WebReferenceHIS.Service();
        #region 杂项
        /// <summary>
        /// 病例分型
        /// </summary>
        private string sBLFX;

        /// <summary>
        /// 实施重症监护
        /// </summary>
        private string sSSZZJH;

        /// <summary>
        /// 监护天
        /// </summary>
        private string sJH_DAY;

        /// <summary>
        /// 监护小时
        /// </summary>
        private string sJH_HOUR;

        /// <summary>
        /// 单病种管理
        /// </summary>
        private string sDBZGL;

        /// <summary>
        /// 临床路径管理
        /// </summary>
        private string sLCLJGL;

        /// <summary>
        /// 实施DRGs管理
        /// </summary>
        private string sSSDRGS;

        /// <summary>
        /// 抗生素使用
        /// </summary>
        private string sKSSSY;

        /// <summary>
        /// 细菌培养标本送检
        /// </summary>
        private string sXJPYBBSJ;

        /// <summary>
        /// 法定传染病
        /// </summary>
        private string sFDCRB;

        /// <summary>
        /// 肿瘤分期T
        /// </summary>
        private string sZLFQ_T = "";

        /// <summary>
        /// 肿瘤分期N
        /// </summary>
        private string sZLFQ_N = "";

        /// <summary>
        /// 肿瘤分期M1
        /// </summary>
        private string sZLFQ_M1 = "";

        /// <summary>
        /// 肿瘤分期M2
        /// </summary>
        private string sZLFQ_M2 = "";

        /// <summary>
        /// 新生儿Apgar评分
        /// </summary>
        private string sBABY_APGAR;
        #endregion
        /// <summary>
        /// HIS费用手术的信息
        /// </summary>
        DataSet ds_cost;


        /// <summary>
        /// 读取病人信息表病人实例
        /// </summary>
        private InPatientInfo inPatientInfo;


        /// <summary>
        /// 首页附页
        /// </summary>
        private ucCOVER_APPEND_MAIN unconver;

        /// <summary>
        /// 首页附页
        /// </summary>
        private ucCover_Append_QAS QAS;

        /// <summary>
        /// 
        /// </summary>
        public frmCases_First()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inpatient"></param>
        public frmCases_First(InPatientInfo inpatient)
        {

            // 重构病人实例（病人信息表）
            this.inPatientInfo = GetInPatientById(inpatient.Id.ToString());
            InitializeComponent();
            // 重构病人实例（病案信息表）
            //this.inPatientInfoWithCover = GetInPatientByIdWithCoverInfo(inpatient.Id.ToString());
            //select_Code();


        }

        ///// <summary>
        ///// 查询该患者当前编目状态
        ///// 1.提交 不可操作 只允许打印
        ///// 2.未完成 可操作 可更改 可打印
        ///// </summary>
        //private void select_Code()
        //{
        //    if (inPatientInfo.Die_time.ToString() != "")
        //    {
        //        string Sql = "select codestate from (select t.*,row_number() over(partition by t.patient_id order by t.codetime desc) rn from T_IN_Code_Information t) c where rn = 1 and c.patient_id='" + inPatientInfo.PId + "'";
        //        string codeState = App.ReadSqlVal(Sql, 0, "codestate");
        //        string valueState = App.ReadSqlVal("select value from t_hospital_config where code='LW2017041101'", 0, "value");
        //        if (valueState == "1")
        //        {
        //            if (codeState == "提交")
        //            {//申请功能开放
        //                btnUpdateCode.Enabled = true;
        //                btnSave.Enabled = false;
        //                btnRef.Enabled = false;
        //                btnPrint.Enabled = true;
        //                //buttonX3.Enabled = false;
        //            }
        //            else
        //            {
        //                btnUpdateCode.Enabled = false;
        //            }
        //        }

        //    }
        //}

        /// <summary>
        /// 绑定省份
        /// </summary>
        private void dataBingProvince()
        {
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 and code<>45 order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            DataRow row1 = dt.NewRow();

            row["name"] = "-请选择-";
            row["id"] = "-1";
            row1["name"] = "安徽省";
            row1["id"] = "45";

            dt.Rows.InsertAt(row, 0);
            dt.Rows.InsertAt(row1, 1);
            cbxProvince.DisplayMember = "name";
            cbxProvince.ValueMember = "id";
            cbxProvince.DataSource = dt;
        }
        /// <summary>
        /// 绑定省份1
        /// </summary>
        private void dataBingNativePlaceS()
        {
            //string sql = "select id,name from t_data_code_type where id between 140 and 172";
            //string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 order by order_id,code";
            //DataTable dt = App.GetDataSet(sql).Tables[0];
            //DataRow row = dt.NewRow();
            //row["name"] = "-请选择-";
            //row["id"] = "-1";
            //dt.Rows.InsertAt(row, 0);
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 and code<>45 order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            DataRow row1 = dt.NewRow();

            row["name"] = "-请选择-";
            row["id"] = "-1";
            row1["name"] = "安徽省";
            row1["id"] = "45";

            dt.Rows.InsertAt(row, 0);
            dt.Rows.InsertAt(row1, 1);

            cboNativePlaceS.DisplayMember = "name";
            cboNativePlaceS.ValueMember = "id";
            cboNativePlaceS.DataSource = dt;
        }
        /// <summary>
        /// 根据省查找市
        /// </summary>
        /// <param name="id"></param>
        private void dataBindShi(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by case  when name='永州市' then 0 else 1 end,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//直辖市除外 北京，上海 ，天津
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxShi.DisplayMember = "name";
            cbxShi.ValueMember = "id";
            cbxShi.DataSource = dt;
        }

        /// <summary>
        /// 根据省查找市1
        /// </summary>
        /// <param name="id"></param>
        private void dataBindNativePlaceSh(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by case  when name='永州市' then 0 else 1 end,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//直辖市除外 北京，上海 ，天津
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboNativePlaceSh.DisplayMember = "name";
            cboNativePlaceSh.ValueMember = "id";
            cboNativePlaceSh.DataSource = dt;
        }

        /// <summary>
        /// 绑定省份2
        /// </summary>
        private void dataBingNowAddressS()
        {
            //string sql = "select id,name from t_data_code_type where id between 140 and 172";
            //string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 order by order_id,code";
            //DataTable dt = App.GetDataSet(sql).Tables[0];
            //DataRow row = dt.NewRow();
            //row["name"] = "-请选择-";
            //row["id"] = "-1";
            //dt.Rows.InsertAt(row, 0);
            string sql = "select name,code as id from t_data_code where  type=185 and enable='Y' and code between 35 and 68 and code<>45 order by order_id,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            DataRow row1 = dt.NewRow();

            row["name"] = "-请选择-";
            row["id"] = "-1";
            row1["name"] = "安徽省";
            row1["id"] = "45";

            dt.Rows.InsertAt(row, 0);
            dt.Rows.InsertAt(row1, 1);
            cboNowAddressS.DisplayMember = "name";
            cboNowAddressS.ValueMember = "id";
            cboNowAddressS.DataSource = dt;
        }

        /// <summary>
        /// 根据省查找市2
        /// </summary>
        /// <param name="id"></param>
        private void dataBindNowAddressSh(object id)
        {
            //string sql = "select id,name from t_data_code where type='" + id + "'";
            string select_bzdm = "select bzdm from t_data_code where substr(bzdm,3,4)='0000' and code='" + id + "' and type='185'";
            string qydm = App.ReadSqlVal(select_bzdm, 0, "bzdm");
            string bzdm = qydm.Substring(0, 2);
            string sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and substr(bzdm,5,2)='00' and bzdm!='" + qydm + "'order by case  when name='永州市' then 0 else 1 end,bzdm";
            if (bzdm.Contains("11") || bzdm.Contains("12") ||
                bzdm.Contains("31") || bzdm.Contains("50"))//直辖市除外 北京，上海 ，天津
            {
                sql = "select id,name from t_data_code" +
                        " where substr(bzdm,0,2)='" + bzdm + "' and bzdm!='" + qydm + "' order by bzdm";
            }
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboNowAddressSh.DisplayMember = "name";
            cboNowAddressSh.ValueMember = "id";
            cboNowAddressSh.DataSource = dt;
        }

        /// <summary>
        ///刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRef_Click(object sender, EventArgs e)
        {
            // 重构病人实例（病人信息表）
            this.inPatientInfo = GetInPatientById(inPatientInfo.Id.ToString());
            InitFormPatientInfo(this.inPatientInfo);
        }

        private void frmCases_First_Load(object sender, EventArgs e)
        {
            try
            {
                //unconver = new ucCOVER_APPEND_MAIN(inPatientInfo);
                //unconver.Dock = DockStyle.Fill;
                //App.UsControlStyle(unconver);
                //tabControlPanel5.Controls.Add(unconver);

                //wc.Url = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite2/Service.asmx";
                App.UsControlStyle(this);
                InitPatientInfo();
                rdoOutHospital_Click(sender, e);
                // 禁用基本信息,只能查看
                //foreach (Control ctr in groupPanel1.Controls)
                //{
                //    Label lbl = ctr as Label;
                //    if (lbl == null)
                //    {
                //        ctr.Enabled = false;
                //    }
                //}

                QAS = new ucCover_Append_QAS(inPatientInfo);
                QAS.Dock = DockStyle.Fill;
                App.UsControlStyle(QAS);
                QAS.BackColor = System.Drawing.Color.Transparent;
                tabControlPanel5.Controls.Add(QAS);


                txtYear.Enabled = true;
                txtMonth.Enabled = true;
                txtHour.Enabled = true;
            }
            catch (Exception ex)
            {
                App.MsgErr("加载过程中存在错误，原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 返回病人实例（病人基本信息表）
        /// </summary>
        /// <param name="id">病人表主键 ID</param>
        private InPatientInfo GetInPatientById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            InPatientInfo inPatientInfo = new InPatientInfo();

            #region 创建病人信息实例

            string sql = string.Format("select * from t_in_patient where id = '{0}'", id);
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt != null && dt.Rows.Count == 1)
            {
                inPatientInfo.Id = Convert.ToInt32(id);
                //医疗付款方式
                inPatientInfo.Pay_Manager = dt.Rows[0]["PAY_MANNER"] is DBNull ? "" : dt.Rows[0]["PAY_MANNER"].ToString();

                //住院次数
                inPatientInfo.InHospital_count = dt.Rows[0]["INHOSPITAL_COUNT"] is DBNull ? 1 : Convert.ToInt32(dt.Rows[0]["INHOSPITAL_COUNT"]);

                //姓名
                inPatientInfo.Patient_Name = dt.Rows[0]["PATIENT_NAME"] is DBNull ? "" : dt.Rows[0]["PATIENT_NAME"].ToString();

                //性别
                inPatientInfo.Gender_Code = dt.Rows[0]["GENDER_CODE"] is DBNull ? "" : dt.Rows[0]["GENDER_CODE"].ToString();

                //婚姻
                inPatientInfo.Marrige_State = dt.Rows[0]["MARRIAGE_STATE"] is DBNull ? "" : dt.Rows[0]["MARRIAGE_STATE"].ToString();

                //身份证
                inPatientInfo.Medicare_no = dt.Rows[0]["CARD_ID"] is DBNull ? "" : dt.Rows[0]["CARD_ID"].ToString();

                //出生日期
                inPatientInfo.Birthday = dt.Rows[0]["BIRTHDAY"] is DBNull ? "" : dt.Rows[0]["BIRTHDAY"].ToString();

                //民族
                inPatientInfo.Folk_code = dt.Rows[0]["FOLK_CODE"] is DBNull ? "" : dt.Rows[0]["FOLK_CODE"].ToString();

                //国籍
                inPatientInfo.Country = dt.Rows[0]["COUNTRY"] is DBNull ? "" : dt.Rows[0]["COUNTRY"].ToString();

                //出生地
                inPatientInfo.Birth_place = dt.Rows[0]["BIRTH_PLACE"] is DBNull ? "" : dt.Rows[0]["BIRTH_PLACE"].ToString();

                //工作单位及地址
                inPatientInfo.Office_address = dt.Rows[0]["OFFICE_ADDRESS"] is DBNull ? "" : dt.Rows[0]["OFFICE_ADDRESS"].ToString();

                //职业
                inPatientInfo.Career = dt.Rows[0]["CAREER"] is DBNull ? "" : dt.Rows[0]["CAREER"].ToString();

                //职业其他
                inPatientInfo.Career_other = dt.Rows[0]["career_other"] is DBNull ? "" : dt.Rows[0]["career_other"].ToString();

                //单位电话
                inPatientInfo.Office_phone = dt.Rows[0]["OFFICE_PHONE"] is DBNull ? "" : dt.Rows[0]["OFFICE_PHONE"].ToString();

                //单位邮政编码
                inPatientInfo.OfficePos_code = dt.Rows[0]["OFFICEPOS_CODE"] is DBNull ? "" : dt.Rows[0]["OFFICEPOS_CODE"].ToString();

                //户口地址：
                inPatientInfo.Home_address = dt.Rows[0]["HOME_ADDRESS"] is DBNull ? "" : dt.Rows[0]["HOME_ADDRESS"].ToString();

                //邮政编码
                inPatientInfo.HomePostal_code = dt.Rows[0]["HOMEPOSTAL_CODE"] is DBNull ? "" : dt.Rows[0]["HOMEPOSTAL_CODE"].ToString();

                //联系人地址
                inPatientInfo.Relation_address = dt.Rows[0]["RELATION_ADDRESS"] is DBNull ? "" : dt.Rows[0]["RELATION_ADDRESS"].ToString();

                //关系
                inPatientInfo.Relation = dt.Rows[0]["RELATION"] is DBNull ? "" : dt.Rows[0]["RELATION"].ToString();

                //联系人姓名
                inPatientInfo.Relation_name = dt.Rows[0]["RELATION_NAME"] is DBNull ? "" : dt.Rows[0]["RELATION_NAME"].ToString();
                
                //入院途径
                inPatientInfo.In_Approach = dt.Rows[0]["In_Approach"] is DBNull ? "" : dt.Rows[0]["In_Approach"].ToString();
                //联系人电话
                inPatientInfo.Relation_phone = dt.Rows[0]["RELATION_PHONE"] is DBNull ? "" : dt.Rows[0]["RELATION_PHONE"].ToString();

                //入院日期
                inPatientInfo.In_Time = dt.Rows[0]["IN_TIME"] is DBNull ? Convert.ToDateTime("3000-1-1") : Convert.ToDateTime(dt.Rows[0]["IN_TIME"]);

                //护理等级
                inPatientInfo.Nurse_Level = dt.Rows[0]["NURSE_LEVEL"] is DBNull ? "" : dt.Rows[0]["NURSE_LEVEL"].ToString();

                //入院时情况
                inPatientInfo.In_Circs = dt.Rows[0]["IN_CIRCS"] is DBNull ? "" : dt.Rows[0]["IN_CIRCS"].ToString();

                //状态
                inPatientInfo.State = dt.Rows[0]["State"] is DBNull ? "" : dt.Rows[0]["State"].ToString();

                //入院科室
                inPatientInfo.Insection_Name = dt.Rows[0]["insection_name"].ToString();
                //入院病区
                inPatientInfo.In_Area_Name = dt.Rows[0]["In_Area_Name"].ToString();
                //出院日期(如果没出院,保存日期最小值)
                inPatientInfo.Die_time = dt.Rows[0]["Die_time"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["Die_time"]);
                //出院科室
                inPatientInfo.Section_Id = dt.Rows[0]["Section_Id"] is DBNull ? 0 : Convert.ToInt32(dt.Rows[0]["Section_Id"].ToString());

                inPatientInfo.Section_Name = dt.Rows[0]["Section_Name"].ToString();
                //出院病区
                inPatientInfo.Sike_Area_Id = dt.Rows[0]["Sick_Area_Id"] is DBNull ? "0" : dt.Rows[0]["Sick_Area_Id"].ToString();
                inPatientInfo.Sick_Area_Name = dt.Rows[0]["Sick_Area_Name"].ToString();

                //病案号
                inPatientInfo.PId = dt.Rows[0]["PID"].ToString();

                //HIS的zyh
                inPatientInfo.His_id = dt.Rows[0]["HIS_ID"].ToString();

                //现住地址
                inPatientInfo.Now_address = dt.Rows[0]["Now_address"] is DBNull ? "" : dt.Rows[0]["Now_address"].ToString();
                //现住地址邮编
                inPatientInfo.Now_addres_postno = dt.Rows[0]["Now_addres_PostNo"] is DBNull ? "" : dt.Rows[0]["Now_addres_postno"].ToString();
                //现住地址电话 
                inPatientInfo.Now_addres_phone = dt.Rows[0]["Now_addres_phone"] is DBNull ? "" : dt.Rows[0]["Now_addres_phone"].ToString();
                // dianua 
                inPatientInfo.Home_phone = dt.Rows[0]["Home_phone"] is DBNull ? "" : dt.Rows[0]["Home_phone"].ToString();
                // 健康卡号 
                inPatientInfo.Health_card_no = dt.Rows[0]["Health_card_no"] is DBNull ? "" : dt.Rows[0]["Health_card_no"].ToString();
                //新生儿出生体重
                inPatientInfo.Bornweight = dt.Rows[0]["BornWeight"].ToString(); //== "" ? 0 : float.Parse(dt.Rows[0]["BornWeight"].ToString());
                //新生儿入院体重
                inPatientInfo.Inweight = dt.Rows[0]["INWEIGHT"].ToString(); //== "" ? 0 : float.Parse(dt.Rows[0]["INWEIGHT"].ToString());
                //籍贯
                inPatientInfo.Natiye_place = dt.Rows[0]["NATIVE_PLACE"] is DBNull ? "" : dt.Rows[0]["NATIVE_PLACE"].ToString();
                //入院途径
                inPatientInfo.In_Approach = dt.Rows[0]["In_Approach"] is DBNull ? "" : dt.Rows[0]["In_Approach"].ToString();

                //年龄
                inPatientInfo.Age = dt.Rows[0]["age"] is DBNull ? "" : dt.Rows[0]["age"].ToString();
                //年龄单位
                inPatientInfo.Age_unit = dt.Rows[0]["AGE_UNIT"] is DBNull ? "" : dt.Rows[0]["AGE_UNIT"].ToString();
                //儿童年龄（不满一周岁的）
                inPatientInfo.Child_age = dt.Rows[0]["CHILD_AGE"] is DBNull ? "" : dt.Rows[0]["CHILD_AGE"].ToString();
                //病案号
                inPatientInfo.Sick_doc_no = dt.Rows[0]["SICK_DOC_NO"] is DBNull ? "" : dt.Rows[0]["SICK_DOC_NO"].ToString();
                //床号
                inPatientInfo.Sick_Bed_Name = dt.Rows[0]["sick_bed_no"] is DBNull ? "" : dt.Rows[0]["sick_bed_no"].ToString();
            }

            #endregion

            return inPatientInfo;
        }

        /// <summary>
        ///  初始化病案首页
        /// </summary>
        public void InitPatientInfo()
        {
            // dataBindPayKind();
            dataBindNational();
            dataSectioninfo();
            dataSickareainfo();
            DataBindNationlity();
            dataBingProvince();
            dataBindMarred();
            //dataBindboInKind();
            dataBingNativePlaceS();
            dataBingNowAddressS();
            dataBindRelation();
            dataBindCareer();
            // 初始化病人信息界面
            InitFormPatientInfo(this.inPatientInfo);

            //2013-02-06:注释跳过
            //ds_cost = wc.HIS_GET_FIRST_CASE(inPatientInfo.PId);
            
            // 初始化诊断界面
            InitDiagnose();

            // 初始化手术界面
            InitOperating();

            // 初始病案质量及医师
            InitQuality();

            // 初始化杂项(过敏药物,血型,RH)
            InitTemp();
            //费用
            InitCost();
            ////诊断（新）
            //BindDiag();
        }

        /// <summary>
        /// 初始化信息表各选项及文字域
        /// 取值来自 this.inPatient
        /// </summary>
        private void InitFormPatientInfo(InPatientInfo inPatientInfo)
        {
            DataBindPayMethos();
            // 对所有文本域赋值，由上而下，由左而右
            txtIn_Count.Text = inPatientInfo.InHospital_count.ToString();
            txtPName.Text = inPatientInfo.Patient_Name;
            txtId_Number.Text = inPatientInfo.Medicare_no;
            txtWorkAddress.Text = inPatientInfo.Office_address;
            txtOffice_Phone.Text = inPatientInfo.Office_phone;
            txtOffice_Post.Text = inPatientInfo.OfficePos_code;
            txtAccountAddress.Text = inPatientInfo.Home_address;
            txtHome_Post.Text = inPatientInfo.HomePostal_code;
            txtContactAddress.Text = inPatientInfo.Relation_address;
            txtRelationName.Text = inPatientInfo.Relation_name;
            txtRelation_Phone.Text = inPatientInfo.Relation_phone;
            dtpInTime.Value = inPatientInfo.In_Time;
            txtInSection.Text = inPatientInfo.Insection_Name;
            txtInSickArea.Text = inPatientInfo.In_Area_Name;
            txtCreer.Text = inPatientInfo.Career_other;
            //cbxNational.SelectedValue= inPatientInfo.Folk_code;

            //// 出院日期 科室 病区
            if (inPatientInfo.Die_time == DateTime.MinValue)
            {
                // 未出院则隐藏所有出院相关信息
                label2.Text = "在院病房：";
                label3.Text = "在院科别：";
                label4.Visible = false;
                dtpOutTime.Visible = false;
                txtOutSection.Visible = false;
                txtOutSickArea.Visible = false;
                txtOut_Time.Visible = false;
                dtpOutTime.Visible = false;
                cboOutSection.Visible = true;
                cboOutSickArea.Visible = true;
                cboOutSection.Enabled = false;
                cboOutSickArea.Enabled = false;
                dtpOutTime.Value = App.GetSystemTime();
                cboOutSection.SelectedValue = inPatientInfo.Section_Id;
                //cboOutSection.Text = inPatientInfo.Section_Name.Length == 0 ? "0" : inPatientInfo.Section_Name;
                //cboOutSickArea.Text = inPatientInfo.Sick_Area_Name.Length == 0 ? "0" : inPatientInfo.Sick_Area_Name;
            }
            else
            {
                txtOut_Time.Visible = false;
                dtpOutTime.Enabled = true;
                cboOutSection.Enabled = true;
                cboOutSickArea.Enabled = true;
                dtpOutTime.Value = inPatientInfo.Die_time;
                cboOutSection.SelectedValue = inPatientInfo.Section_Id;
                //cboOutSection.Text = inPatientInfo.Section_Name;
                //cboOutSickArea.Text = inPatientInfo.Sick_Area_Name;
                //txtOutSection.Text = inPatientInfo.Section_Name;
                //txtOutSickArea.Text = inPatientInfo.Sick_Area_Name;

            }

            txtPID.Text = inPatientInfo.PId; // inPatientInfo.Sick_doc_no;
            //健康卡号
            txtCardNo.Text = inPatientInfo.Health_card_no;
            ////出生体重
            txtBornWeight.Text = inPatientInfo.Bornweight;// == 0 ? "" : inPatientInfo.Bornweight.ToString();
            ////入院体重
            txtBornInWeight.Text = inPatientInfo.Inweight;// == 0 ? "" : inPatientInfo.Inweight.ToString();
            //现住地址电话
            txtNowHomePhone.Text = inPatientInfo.Home_phone;
            //现住地址邮编
            txtNowPostNo.Text = inPatientInfo.Now_addres_postno;

            // 住院天数
            //if (this.inPatientInfo.Die_time == DateTime.MinValue) //未出院
            //{
            //    txtDays.Text = ((TimeSpan)(Convert.ToDateTime(App.GetSystemTime().ToShortDateString()) - Convert.ToDateTime(this.inPatientInfo.In_Time.ToShortDateString()))).Days.ToString() + "天";
            //}
            //else
            //{
            //    TimeSpan ts = (Convert.ToDateTime(this.inPatientInfo.Die_time.ToShortDateString()) - Convert.ToDateTime(this.inPatientInfo.In_Time.ToShortDateString()));
            //    txtDays.Text = ts.Days.ToString() == "0" ? "1" : ts.Days.ToString();
            //    txtDays.Text = txtDays.Text + "天";
            //} 
            //TimeSpan ts;
            //if (this.inPatientInfo.Die_time == DateTime.MinValue) //未出院
            //{
            //    ts = (Convert.ToDateTime(App.GetSystemTime()) - Convert.ToDateTime(this.inPatientInfo.In_Time));
            //}
            //else
            //{
            //    ts = (Convert.ToDateTime(this.inPatientInfo.Die_time) - Convert.ToDateTime(this.inPatientInfo.In_Time));
            //}
            DateTime dtime = App.GetSystemTime();
            if (this.inPatientInfo.Die_time != DateTime.MinValue) //已出院
            {
                dtime = this.inPatientInfo.Die_time;
            }
            TimeSpan ts = (Convert.ToDateTime(dtime) - Convert.ToDateTime(this.inPatientInfo.In_Time));
            if (ts.Days == 0)
            {
                int h=0;
                if (ts.Minutes > 0)
                    h = ts.Hours + 1;
                else
                    h = ts.Hours;
                txtDays.Text = h.ToString() == "0" ? "1小时" : h.ToString() + "小时";
                if (h == 24)
                    txtDays.Text = "1天";
            }
            else
            {
                txtDays.Text = ((TimeSpan)(Convert.ToDateTime(dtime.ToShortDateString()) - Convert.ToDateTime(this.inPatientInfo.In_Time.ToShortDateString()))).Days.ToString() + "天";
            }

            //入院途径
            cboInKind.Text = inPatientInfo.In_Approach.Length == 0 ? "" : inPatientInfo.In_Approach.ToString()== "1" ? "急诊": inPatientInfo.In_Approach.ToString()=="2"?"门诊": inPatientInfo.In_Approach.ToString() == "3"?"其他医疗机构转入":"其他";
            //医疗付款方式         
            cbxPay.SelectedValue = inPatientInfo.Pay_Manager.Length == 0 ? "0" : inPatientInfo.Pay_Manager;

            // 转科信息
            string selTurnWithAction = "select distinct ti.sid,ts.section_name,ti.happen_time,ti.action_type from t_inhospital_action ti"
                    + " inner join t_sectioninfo ts on ti.sid=ts.sid where ti.patient_id='" + inPatientInfo.Id + "' and ti.action_type in ('转入','入区')"
                    + " order by ti.happen_time asc";

            DataSet dsTuen = App.GetDataSet(selTurnWithAction);
            int length = dsTuen.Tables[0].Rows.Count;
            string sectionTemp = "";
            for (int i = 0; i < length; i++)
            {
                string sectionName = dsTuen.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                if (length > 1)
                {
                    sectionTemp += sectionName + "→";
                }
            }

            txtTurnSection.Text = sectionTemp.Substring(0, sectionTemp.Length > 1 ? sectionTemp.Length - 1 : 0);

            int temp = 0;
            if(int.TryParse(inPatientInfo.Gender_Code,out temp))
            {
                temp++;
            }
            cbxSex.SelectedIndex = temp;
            // 婚姻
            try
            {
                cbxMarred.Text = this.inPatientInfo.Marrige_State.Length == 0 ? "0" : this.inPatientInfo.Marrige_State;
            }
            catch
            {
                cbxMarred.SelectedIndex = 0;
            }
            //try
            //{
            //    cbxMarred.SelectedIndex = Convert.ToInt32(inPatientInfo.Marrige_State);
            //}
            //catch
            //{
            //    cbxMarred.SelectedIndex = 0;
            //}

            dtpBirth_Date.Value = Convert.ToDateTime(inPatientInfo.Birthday);



            cbxNational.Text = inPatientInfo.Folk_code.Length <= 0 ? "489" : inPatientInfo.Folk_code;
            //cbxNationality.Text = "中国";
            //cbxNational.DisplayMember = inPatientInfo.Folk_code;
            // 国籍
            try
            {
                cbxNationality.SelectedValue = this.inPatientInfo.Country;
            }
            catch
            {
                cbxNationality.SelectedIndex = 0;
            }
            //出生地

            //出生地
            try
            {
                if (this.inPatientInfo.Birth_place.Length != 0)
                {
                    if (inPatientInfo.Birth_place.ToString().Contains("|"))
                    {
                        string[] birthPlace = this.inPatientInfo.Birth_place.Split('|');
                        for (int i = 0; i < birthPlace.Length; i++)
                        {
                            if (i == 0)
                            {
                                cbxProvince.Text = birthPlace[0];
                            }
                            else if (i == 1)
                            {
                                cbxShi.Text = birthPlace[1];
                            }
                            else if (i == 2)
                            {
                                txtXian.Text = birthPlace[2];
                            }
                        }
                    }
                    else if (inPatientInfo.Birth_place.ToString().Contains("省"))
                    {
                        string[] birthPlace = this.inPatientInfo.Birth_place.Split('省');
                        if (birthPlace.Length == 2)
                        {
                            cbxProvince.Text = birthPlace[0] + "省";
                            if (birthPlace[1].ToString().Contains("市"))
                            {
                                string[] birthPlaces = birthPlace[1].ToString().Split('市');
                                cbxShi.Text = birthPlaces[0] + "市";
                                txtXian.Text = birthPlaces[1];
                            }
                            else
                            {
                                txtXian.Text = birthPlace[1];
                            }
                        }
                    }
                    else if (inPatientInfo.Birth_place.ToString().Contains("市"))
                    {
                        string[] birthPlace = this.inPatientInfo.Birth_place.Split('市');
                        if (birthPlace.Length == 2)
                        {
                            //cbxProvince.Text = birthPlace[0];
                            string shi = birthPlace[0] + "市";
                            string sql = @"select name from t_data_code 
                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                                        from t_data_code where name='" + shi + "')";
                            DataTable dts = App.GetDataSet(sql).Tables[0];
                            if (dts.Rows.Count > 0)
                            {
                                cbxProvince.Text = dts.Rows[0]["name"].ToString();
                            }
                            cbxShi.Text = shi;
                            txtXian.Text = birthPlace[1];

                        }
                    }
                }
                else
                {
                    cbxProvince.SelectedIndex = 0;
                }

                //籍贯
                if (this.inPatientInfo.Natiye_place.Length != 0)
                {
                    if (inPatientInfo.Natiye_place.ToString().Contains("|"))
                    {
                        string[] Natiye_place = this.inPatientInfo.Natiye_place.Split('|');
                        for (int i = 0; i < Natiye_place.Length; i++)
                        {
                            if (i == 0)
                            {
                                cboNativePlaceS.Text = Natiye_place[0];
                            }
                            else if (i == 1)
                            {
                                cboNativePlaceSh.Text = Natiye_place[1];
                            }
                            else if (i == 2)
                            {
                                //txtJGXian.Text = Natiye_place[2];
                                txtJGXian.Text = "";
                            }
                        }
                    }
                    else if (inPatientInfo.Natiye_place.ToString().Contains("省"))
                    {
                        string[] natiye_place = this.inPatientInfo.Natiye_place.Split('省');
                        if (natiye_place.Length == 2)
                        {
                            cboNativePlaceS.Text = natiye_place[0] + "省";
                            if (natiye_place[1].ToString().Contains("市"))
                            {
                                string[] natiye_placeS = natiye_place[1].ToString().Split('市');
                                cboNativePlaceSh.Text = natiye_placeS[0] + "市";
                                txtJGXian.Text = natiye_placeS[1];
                            }
                            else
                            {
                                txtJGXian.Text = natiye_place[1];
                            }
                        }
                    }
                    else if (inPatientInfo.Natiye_place.ToString().Contains("市"))
                    {
                        string[] natiye_place = this.inPatientInfo.Natiye_place.Split('市');
                        if (natiye_place.Length == 2)
                        {
                            //cbxProvince.Text = birthPlace[0];
                            string shi = natiye_place[0] + "市";
                            string sql = @"select name from t_data_code 
                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                                        from t_data_code where name='" + shi + "')";
                            DataTable dts = App.GetDataSet(sql).Tables[0];
                            if (dts.Rows.Count > 0)
                            {
                                cboNativePlaceS.Text = dts.Rows[0]["name"].ToString();
                            }
                            cboNativePlaceSh.Text = shi;
                            txtJGXian.Text = natiye_place[1];
                        }
                    }
                }
                else
                {
                    cboNativePlaceS.SelectedIndex = 0;
                }
                //现住地址
                if (this.inPatientInfo.Now_address.Length != 0)
                {
                    if (inPatientInfo.Now_address.ToString().Contains("|"))
                    {
                        string[] Now_address = this.inPatientInfo.Now_address.Split('|');
                        for (int i = 0; i < Now_address.Length; i++)
                        {
                            if (i == 0)
                            {
                                cboNowAddressS.Text = Now_address[0];
                            }
                            else if (i == 1)
                            {
                                cboNowAddressSh.Text = Now_address[1];
                            }
                            else if (i == 2)
                            {
                                txtNowXian.Text = Now_address[2];
                            }
                        }
                    }
                    else if (inPatientInfo.Now_address.ToString().Contains("省"))
                    {
                        string[] now_address = this.inPatientInfo.Now_address.Split('省');
                        if (now_address.Length == 2)
                        {
                            cboNowAddressS.Text = now_address[0] + "省";
                            if (now_address[1].ToString().Contains("市"))
                            {
                                string[] now_addressS = now_address[1].ToString().Split('市');
                                cboNowAddressSh.Text = now_addressS[0] + "市";
                                txtNowXian.Text = now_addressS[1];
                            }
                            else
                            {
                                txtNowXian.Text = now_address[1];
                            }
                        }
                    }
                    else if (inPatientInfo.Now_address.ToString().Contains("市"))
                    {
                        string[] now_address = this.inPatientInfo.Now_address.Split('市');
                        if (now_address.Length == 2)
                        {
                            //cbxProvince.Text = birthPlace[0];
                            string shi = now_address[0] + "市";
                            string sql = @"select name from t_data_code 
                                        where bzdm=(select substr(bzdm,0,2)||'0000' 
                                        from t_data_code where name='" + shi + "')";
                            DataTable dts = App.GetDataSet(sql).Tables[0];
                            if (dts.Rows.Count > 0)
                            {
                                cboNowAddressS.Text = dts.Rows[0][0].ToString();
                            }
                            cboNowAddressSh.Text = shi;
                            txtNowXian.Text = now_address[1];
                        }
                    }
                }
                else
                {
                    cboNowAddressS.SelectedIndex = 0;
                }
            }
            catch
            { }
            // 职业
            if (this.inPatientInfo.Career.Length != 0)
            {
                //if (this.inPatientInfo.Career == "13")// 集童和散童
                //{
                //    cboCreer.SelectedIndex = 3;
                //    txtCreer.Text = "集童";
                //}
                //else if (this.inPatientInfo.Career == "14")
                //{
                //    cboCreer.SelectedIndex = 3;
                //    txtCreer.Text = "散童";
                //}
                //else if (this.inPatientInfo.Career == "农民" || this.inPatientInfo.Career == "学生")
                //{

                string sql = "select distinct name from t_data_code where type='134' and code='"+ this.inPatientInfo.Career + "'";
                DataTable dts = App.GetDataSet(sql).Tables[0];
                if (dts.Rows.Count > 0)
                {
                    cboCreer.Text = dts.Rows[0][0].ToString();

                }
                else
                {
                    cboCreer.Text = "-未填写职业-";
                }
                //cboCreer.Text = this.inPatientInfo.Career;
                //}
                //else
                //{
                //    cboCreer.SelectedIndex = 3;
                //}
            }
            else
            {
                cboCreer.SelectedIndex = 0;
            }

            // 关系
            cbxRelationship.SelectedValue = this.inPatientInfo.Relation; //GetRelation(this.inPatientInfo.Relation);

            //年龄
            //DateTime dt1 = inPatientInfo.In_Time;
            //DateTime dt2 = Convert.ToDateTime(inPatientInfo.Birthday);
            //TimeSpan ts1 = dt1 - dt2;
            //int year = ts1.Days / 365;
            //int month = ts1.Days % 365 / 30;
            //int day = ts1.Days % 365 % 30;
            //int hour = ts1.Hours;
            //txtAge1.Text = year == 0 ? "" : year.ToString();
            //txtAge2.Text = month == 0 ? "" : month.ToString();
            //txtAge3.Text = day == 0 ? "" : day.ToString();
            //txtAge4.Text = hour == 0 ? "" : hour.ToString();
            //if (inPatientInfo.Age!="0")
            //{               
            txtAge1.Text = inPatientInfo.Age;
            //}

            //if (!string.IsNullOrEmpty(inPatientInfo.Child_age))
            //{
            txtAge2.Text = inPatientInfo.Child_age;
            //}

            //else
            //{ 
            //    DateTime birthDay;
            //    DateTime.TryParse(inPatientInfo.Birthday,out birthDay);
            //    txtAge2.Text = App.GetTheAgeTime(birthDay, inPatientInfo.In_Time, false);
            //}

            //inPatientInfo


            //==================  读取临时存储的手打年龄 ===================
            //try
            //{
            //    string sSelectAge = "select age_year,age_month,age_hour from cover_info where patient_id='" + inPatientInfo.Id + "'";
            //    DataTable dt = App.GetDataSet(sSelectAge).Tables[0];
            //    txtYear.Text = dt.Rows[0]["age_year"].ToString();
            //    txtMonth.Text = dt.Rows[0]["age_month"].ToString();
            //    txtHour.Text = dt.Rows[0]["age_hour"].ToString();
            //}
            //catch
            //{
            //}
        }
        /// <summary>
        /// 绑定付款方式
        /// </summary>
        private void DataBindPayMethos()
        {
            try
            {
                string sql = "select name ,code from t_data_code t where t.type='70'";
                DataSet ds = App.GetDataSet(sql);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.NewRow();
                row[0] = "请选择";
                row[1] = "0";
                dt.Rows.InsertAt(row, 0);
                cbxPay.DisplayMember = "name";
                cbxPay.ValueMember = "code";
                cbxPay.DataSource = dt.DefaultView;
                cbxPay.SelectedIndex = 0;
            }
            catch (Exception)
            {

                //throw;
            }
        }

        /// <summary>
        /// 获取对应关系
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetRelation(string p)
        {
            if (p.Length == 0)
            {
                return "-请选择-";
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("1", "父子");
            dict.Add("2", "父女");
            dict.Add("3", "母子");
            dict.Add("4", "母女");
            dict.Add("5", "姐妹");
            dict.Add("6", "朋友");
            dict.Add("7", "祖孙");
            dict.Add("8", "兄弟");
            dict.Add("9", "其他监护人");

            try
            {
                return dict[p];
            }
            catch (Exception ex)
            {
                return p;
            }
        }

        #region 绑定民族、省份、城市、护理等级、医疗付款方式、婚姻、入院途径

        /// <summary>
        /// 绑定关系
        /// </summary>
        private void dataBindRelation()
        {
            string sql = "select id,name,code from t_data_code where type='131'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["code"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxRelationship.DisplayMember = "name";
            cbxRelationship.ValueMember = "code";
            cbxRelationship.DataSource = dt;
        }
        /// <summary>
        /// 职业
        /// </summary>
        private void dataBindCareer()
        {
            string sql = "select id,code,name from t_data_code where type='134'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboCreer.DisplayMember = "name";
            cboCreer.ValueMember = "code";
            cboCreer.DataSource = dt;
        }
        ///// <summary>
        ///// 绑定入院方式
        ///// </summary>
        //private void dataBindboInKind()
        //{
        //    string sql = "select id,name,code from t_data_code where type='110' and enable='Y'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboInKind.DisplayMember = "name";
        //    cboInKind.ValueMember = "id";
        //    cboInKind.DataSource = dt;
        //}

        /// <summary>
        /// 绑定婚姻
        /// </summary>
        private void dataBindMarred()
        {
            string sql = "select id,name,code from t_data_code where type='132' and enable='Y'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxMarred.DisplayMember = "name";
            cbxMarred.ValueMember = "code";
            cbxMarred.DataSource = dt;
        }

        ///// <summary>
        ///// 绑定医疗付款方式
        ///// </summary>
        //private void dataBindPayKind()
        //{
        //    string sql = "select id,name,code from t_data_code where type='70' and enable='Y'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cbxPay.DisplayMember = "name";
        //    cbxPay.ValueMember = "id";
        //    cbxPay.DataSource = dt;
        //}

        /// <summary>
        /// 绑定56个民族下拉列表
        /// </summary>
        private void dataBindNational()
        {
            string sql = "select code,name from t_data_code where type='71' and enable='Y' order by case  when name='汉族' then 0 else 1 end,code";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["code"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cbxNational.DisplayMember = "name";
            cbxNational.ValueMember = "code";
            cbxNational.DataSource = dt;
        }

        /// <summary>
        /// 绑定出院科别下拉列表
        /// </summary>
        private void dataSectioninfo()
        {
            

            //string sql = "select t.sid,t.section_name from t_sectioninfo t order by section_name,sid";
            string sql = "select t2.sid,t2.section_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 where t1.sid=t2.sid and t1.said=t3.said and t2.ENABLE_FLAG='Y' order by t2.section_name,t2.sid";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["section_name"] = "-请选择-";
            row["sid"] = "-1";
            dt.Rows.InsertAt(row, 0);
            cboOutSection.DisplayMember = "section_name";
            cboOutSection.ValueMember = "sid";
            cboOutSection.DataSource = dt;
            if (inPatientInfo.Section_Id!=null)
            {
                cboOutSection.SelectedValue = inPatientInfo.Section_Id;
            }
            else
            {
                cboOutSection.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 绑定出院病房下拉列表
        /// </summary>
        private void dataSickareainfo()
        {
            //string sql = "select t.said,t.sick_area_name from t_sickareainfo t";

            //DataTable dt = App.GetDataSet(sql).Tables[0];
            //DataRow row = dt.NewRow();
            //row["sick_area_name"] = "-请选择-";
            //row["said"] = "-1";
            //dt.Rows.InsertAt(row, 0);
            //cboOutSickArea.DisplayMember = "sick_area_name";
            //cboOutSickArea.ValueMember = "said";
            //cboOutSickArea.DataSource = dt;
            //if (!string.IsNullOrEmpty(inPatientInfo.Sick_Area_Name))
            //{
            //    cboOutSickArea.Text = inPatientInfo.Sick_Area_Name;
            //}
            //else
            //{
            //    cboOutSickArea.SelectedIndex = 0;
            //}
        }

        ///// <summary>
        ///// 绑定省份
        ///// </summary>
        //private void dataBingProvince()
        //{
        //    string sql = "select id,name from t_data_code_type where id between 140 and 172";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cbxProvince.DisplayMember = "name";
        //    cbxProvince.ValueMember = "id";
        //    cbxProvince.DataSource = dt;
        //}

        ///// <summary>
        ///// 根据省查找市
        ///// </summary>
        ///// <param name="id"></param>
        //private void dataBindShi(object id)
        //{
        //    string sql = "select id,name from t_data_code where type='" + id + "'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cbxShi.DisplayMember = "name";
        //    cbxShi.ValueMember = "id";
        //    cbxShi.DataSource = dt;
        //}


        ///// <summary>
        ///// 绑定省份1
        ///// </summary>
        //private void dataBingNativePlaceS()
        //{
        //    string sql = "select id,name from t_data_code_type where id between 140 and 172";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboNativePlaceS.DisplayMember = "name";
        //    cboNativePlaceS.ValueMember = "id";
        //    cboNativePlaceS.DataSource = dt;
        //}

        ///// <summary>
        ///// 根据省查找市1
        ///// </summary>
        ///// <param name="id"></param>
        //private void dataBindNativePlaceSh(object id)
        //{
        //    string sql = "select id,name from t_data_code where type='" + id + "'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboNativePlaceSh.DisplayMember = "name";
        //    cboNativePlaceSh.ValueMember = "id";
        //    cboNativePlaceSh.DataSource = dt;
        //}

        ///// <summary>
        ///// 绑定省份2
        ///// </summary>
        //private void dataBingNowAddressS()
        //{
        //    string sql = "select id,name from t_data_code_type where id between 140 and 172";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboNowAddressS.DisplayMember = "name";
        //    cboNowAddressS.ValueMember = "id";
        //    cboNowAddressS.DataSource = dt;
        //}

        ///// <summary>
        ///// 根据省查找市2
        ///// </summary>
        ///// <param name="id"></param>
        //private void dataBindNowAddressSh(object id)
        //{
        //    string sql = "select id,name from t_data_code where type='" + id + "'";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["name"] = "-请选择-";
        //    row["id"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboNowAddressSh.DisplayMember = "name";
        //    cboNowAddressSh.ValueMember = "id";
        //    cboNowAddressSh.DataSource = dt;
        //}

        /// <summary>
        /// 绑定护理等级
        /// </summary>
        private void dataBindNurseLevel()
        {
            //            string sql = @"select a.id,a.name from t_data_code a inner join t_data_code_type b 
            //                            on a.type = b.id where b.name = '护理等级'";
            //            DataTable dt = App.GetDataSet(sql).Tables[0];
            //            DataRow row = dt.NewRow();
            //            row["name"] = "-请选择-";
            //            row["id"] = "-1";
            //            dt.Rows.InsertAt(row, 0);
            //            cbxNurse_Leavel.DataSource = dt;
            //            cbxNurse_Leavel.DisplayMember = "NAME";
            //            cbxNurse_Leavel.ValueMember = "ID";
        }

        #endregion

        #region 省市联动、生日年龄联动
        /// <summary>
        /// 省市联动效果-出生地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProvince.SelectedIndex != 0)
            {
                dataBindShi(cbxProvince.SelectedValue);
            }
            else
            {
                cbxShi.DataSource = null;
                cbxShi.Items.Add("-请选择-");
                cbxShi.SelectedIndex = 0;
                txtXian.Text = "";
            }
        }
        /// <summary>
        /// 省市联动效果-籍贯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboNativePlaceS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNativePlaceS.SelectedIndex != 0)
            {
                dataBindNativePlaceSh(cboNativePlaceS.SelectedValue);
            }
            else
            {
                cboNativePlaceSh.DataSource = null;
                cboNativePlaceSh.Items.Add("-请选择-");
                cboNativePlaceSh.SelectedIndex = 0;
                txtJGXian.Text = "";
            }
        }
        /// <summary>
        /// 省市联动效果-现住地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboNowAddressS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNowAddressS.SelectedIndex != 0)
            {
                dataBindNowAddressSh(cboNowAddressS.SelectedValue);
            }
            else
            {
                cboNowAddressSh.DataSource = null;
                cboNowAddressSh.Items.Add("-请选择-");
                cboNowAddressSh.SelectedIndex = 0;
                txtNowXian.Text = "";
            }
        }
        #endregion
        /// <summary>
        /// 绑定国籍
        /// </summary>
        private void DataBindNationlity()
        {
            DataTable dt = null;
            DataSet ds = App.GetDataSet("select code,name from t_data_code t where t.type=130 order by case  when t.name='中国' then 0 else 1 end,code");
            dt = ds.Tables[0];
            DataRow row = dt.NewRow();
            row[0] = "0";
            row[1] = "请选择";
            dt.Rows.InsertAt(row, 0);
            cbxNationality.DisplayMember = "name";
            cbxNationality.ValueMember = "code";
            cbxNationality.DataSource = dt.DefaultView;
            if (!string.IsNullOrEmpty(inPatientInfo.Country))
            {
                cbxNationality.SelectedValue = inPatientInfo.Country;
            }
            else
            {
                cbxNationality.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 无论点击哪个选择诊断按钮,都进入此方法
        /// </summary>
        /// <param name="sender">被点击的按钮</param>
        private void btnSelectDiagnose(object sender, EventArgs e)
        {
            ButtonX btn = sender as ButtonX;
            //是否自由录入 true自由
            bool isFree = true;
            if (btn.Tag.ToString() == "病理诊断")
            {
                isFree = true;
            }
            FrmCaselist frm = new FrmCaselist(this.inPatientInfo, this, btn, isFree);
            frm.ShowDialog();
        }

        /// <summary>
        /// 从父容器中移除本页签
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Parent.Parent.Controls.Remove(this.Parent);
            }
        }

        /// <summary>
        /// 控制药物过敏文本框的可输入状态
        /// </summary>
        private void ChangeTextMedicineState(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtMedicine.Text = "";
                txtMedicine.ReadOnly = true;
            }
            else
            {
                txtMedicine.Text = "";
                txtMedicine.ReadOnly = false;
            }
        }

        /// <summary>
        /// 保存病案首页三大块数据
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabctrlHead.SelectedTabIndex != tabctrlHead.Tabs.Count - 1)
            {
                // 病案首页三大块内容进行保存的 Sql 语句集合
                List<string> Sqls = new List<string>();

                // 保存病人信息界面的相关 SQL
                Sqls.AddRange(SavePatientInfoToCover(this.inPatientInfo));

                // 保存病人出院诊断界面的 SQL
                Sqls.AddRange(SaveOutPatientDiagnose());

                //Sqls.AddRange(SaveOutPatientDiagnoseNew());

                // 保存病人手术界面的 SQL
                Sqls.AddRange(SavePatientOperating());

                // 保存杂项(血型,RH指标,过敏药物)
                Sqls.AddRange(SavePatientTemp());
                Sqls.AddRange(SavePaitentCost());

                try
                {
                    App.ExecuteBatch(Sqls.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("病案首页各项内容保存成功!");
            }
            else
            {
                //unconver.SaveConver();
                if (!QAS.SaveData())
                {
                    App.Msg("提示:保存失败,还有必选项未选择!");
                }
                
            }
        }

        /// <summary>
        /// 保存病人信息界面的 SQL
        /// </summary>
        /// <param name="inPatientInfo">病人实例</param>
        /// <returns>SQL 集合</returns>
        private IEnumerable<string> SavePatientInfoToCover(InPatientInfo inPatientInfo)
        {
            List<string> sqls = new List<string>();

            //出生地
            if (cbxProvince.SelectedIndex != 0)
            {
                inPatientInfo.Birth_place = cbxProvince.Text + "|";
                if (cbxShi.SelectedIndex != 0)
                {
                    inPatientInfo.Birth_place += cbxShi.Text + "|" + txtXian.Text;
                }
            }
            else
            {
                inPatientInfo.Birth_place = "";
            }
            //籍贯
            if (cboNativePlaceS.SelectedIndex != 0)
            {
                inPatientInfo.Natiye_place = cboNativePlaceS.Text + "|";
                if (cboNativePlaceSh.SelectedIndex != 0)
                {
                    inPatientInfo.Natiye_place += cboNativePlaceSh.Text + "|" + txtJGXian.Text;
                }
            }
            else
            {
                inPatientInfo.Natiye_place = "";
            }
            //现住址
            if (cboNowAddressS.SelectedIndex != 0)
            {
                inPatientInfo.Now_address = cboNowAddressS.Text + "|";
                if (cboNowAddressSh.SelectedIndex != 0)
                {
                    inPatientInfo.Now_address += cboNowAddressSh.Text + "|" + txtNowXian.Text;
                }
            }
            else
            {
                inPatientInfo.Now_address = "";
            }
            //科室
            if (cboOutSection.SelectedIndex != 0)
            {
                inPatientInfo.Section_Id = int.Parse(cboOutSection.SelectedValue.ToString());
                inPatientInfo.Section_Name = cboOutSection.Text;
            }
            //病区
            //string Sick_Area_Id = "";
            if (Convert.ToInt32(cboOutSickArea.SelectedValue) > 0)
            {
                inPatientInfo.Sike_Area_Id = cboOutSickArea.SelectedValue.ToString();
                //Sick_Area_Id = cboOutSickArea.SelectedValue.ToString();
                inPatientInfo.Sick_Area_Name = cboOutSickArea.Text;
            }

            string sql = "";
            if (inPatientInfo.Die_time == DateTime.MinValue)
            {
                sql = string.Format(@"update t_in_patient set Birth_Place='{0}',NATIVE_PLACE='{1}',NOW_ADDRESS='{2}'" +
                                        " where id='{3}'",
                                        inPatientInfo.Birth_place, inPatientInfo.Natiye_place, inPatientInfo.Now_address, inPatientInfo.Id);
            }
            else
            {
                inPatientInfo.Die_time = dtpOutTime.Value;
                sql = string.Format(@"update t_in_patient set Birth_Place='{0}',NATIVE_PLACE='{1}',NOW_ADDRESS='{2}',Section_ID='{3}'," +
                                        "Section_Name='{4}',Sick_Area_ID='{5}',Sick_Area_Name='{6}',Leave_Time=to_date('{7}','YYYY-MM-DD HH24:MI:SS'),DIE_TIME=to_date('{8}','YYYY-MM-DD HH24:MI:SS') where id='{9}'",
                                        inPatientInfo.Birth_place, inPatientInfo.Natiye_place, inPatientInfo.Now_address, inPatientInfo.Section_Id, inPatientInfo.Section_Name, inPatientInfo.Sike_Area_Id, inPatientInfo.Sick_Area_Name, inPatientInfo.Die_time, inPatientInfo.Die_time, inPatientInfo.Id);
            }
            sqls.Add(sql);
            sql = string.Format(@"delete COVER_INFO where PATIENT_ID = '{0}'", inPatientInfo.Id);//'{28}','{29}','{30}','{31}','{32}',
            sqls.Add(sql);//ARCH_ID,NOW_ADDRESS,NOW_ADDRES_POSTNO,NOW_ADDRES_PHONE,HEALTH_CARD_NO,BORNWEIGHT,
            sql = string.Format(@"insert into COVER_INFO(INPATIENT_ID,FEE_TYPE,IN_TIMES,NAME,SEX,MARRIAGE,
                CERT_NO,BIRTHDAY,NATION,COUNRTY,BORN_PLACE,WORK_ORG,CAREER,W_PHONE,W_POST_CODE,HOME_ADDR,
                H_POST_CODE,RELATION_ADDRESS,RELATION,RELATION_NAME,RELATION_PHONE,IN_TIME,INSECTION_NAME,
                IN_AREA_NAME,DIE_TIME,SECTION_NAME,SICK_AREA_NAME,ARCH_ID,NOW_ADDRESS,NOW_ADDRES_POSTNO,
                NOW_ADDRES_PHONE,HEALTH_CARD_NO,WEIGHT,NATIVE_PLACE,IN_APPROACH,PATIENT_ID,
                age_year,age_month,age_hour,age,age_unit,BORNWEIGHT) 
                values('{0}','{1}',{2},'{3}','{4}','{5}','{6}',to_date('{7}','YYYY-MM-DD HH24:MI:SS'),
                '{8}','{9}', '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',
                '{20}',to_date('{21}','YYYY-MM-DD HH24:MI:SS'),'{22}','{23}',to_date('{24}','YYYY-MM-DD HH24:MI:SS'),
                '{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}')",
                inPatientInfo.PId, inPatientInfo.Pay_Manager, inPatientInfo.InHospital_count, inPatientInfo.Patient_Name,
                inPatientInfo.Gender_Code, inPatientInfo.Marrige_State, inPatientInfo.Cert_Id, inPatientInfo.Birthday,
                inPatientInfo.Folk_code, inPatientInfo.Country, inPatientInfo.Birth_place, inPatientInfo.Office_address,
                inPatientInfo.Career, inPatientInfo.Office_phone, inPatientInfo.OfficePos_code, inPatientInfo.Home_address,
                inPatientInfo.HomePostal_code, inPatientInfo.Relation_address, inPatientInfo.Relation, inPatientInfo.Relation_name,
                inPatientInfo.Relation_phone, inPatientInfo.In_Time, inPatientInfo.Insection_Name, inPatientInfo.In_Area_Name,
                inPatientInfo.Die_time, inPatientInfo.Section_Name, inPatientInfo.Sick_Area_Name, inPatientInfo.PId,
                inPatientInfo.Now_address, inPatientInfo.Now_addres_postno, inPatientInfo.Now_addres_phone,
                inPatientInfo.Health_card_no, inPatientInfo.Inweight, inPatientInfo.Natiye_place,
                inPatientInfo.In_Approach, inPatientInfo.Id, txtYear.Text, txtMonth.Text, txtHour.Text, inPatientInfo.Age, inPatientInfo.Age_unit, inPatientInfo.Bornweight);// inPatientInfo.Now_address, inPatientInfo.Now_addres_PostNo,
            //inPatientInfo.Now_addres_phone, inPatientInfo.Health_card_no, inPatientInfo.BornWeight,
            sqls.Add(sql);
            return sqls;
        }

        /// <summary>
        /// 保存病人出院诊断界面的 SQL
        /// </summary>
        /// <returns>SQL 集合</returns>
        private IEnumerable<string> SaveOutPatientDiagnose()
        {
            // 所有类型的诊断集合
            List<OutPatientDiagndose> Opds = new List<OutPatientDiagndose>();
            OutPatientDiagndose opd = null;

            // 门急诊
            if (txtEmergencyDiagnose.Text.Length != 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = App.ReplaceSQLCharEN(txtEmergencyDiagnose.Text);
                opd.ICD10 = App.ReplaceSQLCharEN(txtEmergencyCode.Text);
                opd.DType = OutPatientDiagndose.DiagnoseType.E;
                if (cboxMZ.Checked)
                {
                    opd.Is_Chinese = "1";
                }
                else
                {
                    opd.Is_Chinese = "0";
                }
                Opds.Add(opd);
            }

            // 病理诊断
            if (txtPathology.Text.Length != 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = App.ReplaceSQLCharEN(txtPathology.Text);
                opd.ICD10 = App.ReplaceSQLCharEN(txtPathologyCode.Text);
                opd.DType = OutPatientDiagndose.DiagnoseType.P;
                opd.Number = App.ReplaceSQLCharEN(txtPathologyNumber.Text);
                Opds.Add(opd);
            }

            // 损伤中毒诊断
            if (txtPoison.Text.Length != 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = App.ReplaceSQLCharEN(txtPoison.Text);
                opd.ICD10 = App.ReplaceSQLCharEN(txtPoisonCode.Text);
                opd.DType = OutPatientDiagndose.DiagnoseType.S;
                Opds.Add(opd);
            }

            // 主要诊断
            if (txtMajorDiagnose.Text.Length != 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = App.ReplaceSQLCharEN(txtMajorDiagnose.Text);
                opd.ICD10 = App.ReplaceSQLCharEN(txtMajorDiagnoseCode.Text);
                opd.DType = OutPatientDiagndose.DiagnoseType.M;
                opd.Condition = cboMajorPatientCondition.Text;
                opd.TurnTo = cboTurnTo.Text;
                if (cboxZY.Checked)
                {
                    opd.Is_Chinese = "1";
                }
                else
                {
                    opd.Is_Chinese = "0";
                }
                Opds.Add(opd);
            }

            // 其他诊断
            foreach (Control ctr in this.grpOtherDiagnose.Controls)
            {
                ucOtherDiagnose uc = ctr as ucOtherDiagnose;
                if (uc != null && uc.OtherDiagnose.Length != 0)
                {
                    opd = new OutPatientDiagndose();
                    opd.Name = App.ReplaceSQLCharEN(uc.OtherDiagnose);
                    opd.ICD10 = App.ReplaceSQLChar(uc.ICD10);
                    opd.DType = OutPatientDiagndose.DiagnoseType.O;
                    opd.Condition = uc.InCondition;
                    if (uc.Ischinese)
                    {
                        opd.Is_Chinese = "1";
                    }
                    else
                    {
                        opd.Is_Chinese = "0";
                    }
                    Opds.Add(opd);
                }
            }

            // 遍历 Opds 集合,组合SQL语句
            List<string> Sqls = new List<string>();
            string sql = @"delete COVER_DIAGNOSE where PATIENT_ID='" + inPatientInfo.Id + "'";
            Sqls.Add(sql);
            sql = @"insert into COVER_DIAGNOSE(INPATIENT_ID,TYPE,NAME,ICD10CODE,PATIENT_ID,INCONDITION,PNUMBER,TURN_TO,is_chinese) 
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
            foreach (OutPatientDiagndose var in Opds)
            {
                Sqls.Add(string.Format(sql, inPatientInfo.PId, var.DType, var.Name, var.ICD10, inPatientInfo.Id, var.Condition, var.Number, var.TurnTo,var.Is_Chinese));
            }

            // 病案质量
            sql = @"delete COVER_QUALITY where PATIENT_ID='" + inPatientInfo.Id + "'";
            Sqls.Add(sql);
            string sQuality = string.Empty;
            foreach (RadioButton var in pnlMEDICAL_RECODE.Controls)
            {
                if (var.Checked)
                {
                    sQuality = var.Text;
                    break;
                }

            }
            string strQdate = txtQC_Time.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(strQdate) && !strQdate.Contains("XXXX-XX-XX"))
                {
                    DateTime dtqcdate = Convert.ToDateTime(strQdate);
                    strQdate = dtqcdate.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception)
            {
                App.Msg("您输入的质控时间无效！");
                strQdate = "";

            }
            sql = string.Format(@"insert into  COVER_QUALITY(INPATIENT_ID,QUALITY,Q_DOCTOR_NAME,Q_NURSE_NAME,Q_DATE,PATIENT_ID,SX_DOCTOR_NAME,
                    JX_DOCTOR_NAME,ZR_NURSE_NAME,ZY_DOCTOR_NAME,ZZ_DOCTOR_NAME,ZR_DOCTOR_NAME,SECTION_HEAD,CODER_NAME) values('{0}','{1}','{2}','{3}',
                    '{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", inPatientInfo.PId,
                sQuality, txtSTU_DOC_NAME.Text, txtQC_Nurse.Text, strQdate, inPatientInfo.Id, txtQC_Doctor.Text, txtIN_DOC_NAME.Text,
                txtPRA_DOC_NAME.Text, txtPOS_DOC_NAME.Text, txtDUTY_DOC_NAME.Text, txtDIRE_NAME.Text, txtSEC_DIRE_NAME.Text, txtCoder.Text);
            Sqls.Add(sql);


            return Sqls;
        }
        /// <summary>
        /// 保存费用的sql
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> SavePaitentCost()
        {
            int pat_id = inPatientInfo.Id;
            List<string> sqls = new List<string>();
            sqls.Add(@"delete convert_cost where PATIENT_ID='" + pat_id + "'");
            //总费用
            string total_Cost = txttotal_cost.Text.Trim();
            //自付费用
            string seft_Cost = txtSeft_Cost.Text.Trim();
            //服务费
            string service_Cost = txtService_Cost.Text.Trim();
            //操作费
            string operator_Cost = txtOperator_Cost.Text.Trim();
            //护理费
            string nurse_Cost = txtNurse_Cost.Text.Trim();
            //其他费
            string other_Cost = txtOthser_Cost.Text.Trim();
            //病理诊断费
            string blzd_Cost = txtBlzd_Cost.Text.Trim();
            //实验室诊断费
            string syszd_Cost = txtsyszd_Cost.Text.Trim();
            //影像学诊断费
            string yxxzd_Cost = txtYxxzd_Cost.Text.Trim();
            //临床诊断项目费
            string zdxm_Cost = txtZdxm_Cost.Text.Trim();
            //抗菌药物费用
            string kjyw_Cost = txtKjyw_Cost.Text.Trim();
            //非手术治疗费
            string fshszl_Cost = txtFshszl_Cost.Text.Trim();
            //临床物理治疗费
            string wlzl_Cost = txtWlzl_Cost.Text.Trim();
            //手术治疗费
            string shszl_Cost = txtShszl_Cost.Text.Trim();
            //麻醉费
            string mz_Cost = txtMz_Cost.Text.Trim();
            //手术费
            string shs_Cost = txtShs_Cost.Text.Trim();
            //康复费
            string kf_Cost = txtKf_Cost.Text.Trim();
            //中医治疗肺
            string zyzl_Cost = txtZyzl_Cost.Text.Trim();
            //西药费
            string xy_Cost = txtXy_Cost.Text.Trim();
            //中成药费
            string zchy_Cost = txtZchy_Cost.Text.Trim();
            //中草药费
            string zcy_Cost = txtZcy_Cost.Text.Trim();
            //血费
            string xue_Cost = txtXue_Cost.Text.Trim();
            //白蛋白类制品费
            string bdbl_Cost = txtBdbl_Cost.Text.Trim();
            //球蛋白类制品费
            string qdbl_Cost = txtQdbl_Cost.Text.Trim();
            //凝血因子类制品费
            string nxyzl_Cost = txtNxyzl_Cost.Text.Trim();
            //细胞因子类制品费
            string xbyzl_Cost = txtXbyzl_Cost.Text.Trim();
            //检查一次性医用材料费
            string jccl_Cost = txtJccl_Cost.Text.Trim();
            //手术一次性医用材料费
            string shscl_Cost = txtShscl_Cost.Text.Trim();
            //治疗一次性医用材料费
            string zlcl_Cost = txtZlcl_Cost.Text.Trim();
            //其他类费用
            string qt_Cost = txtQt_Cost.Text.Trim();
            string Insert_Sql = string.Format(@"insert into convert_cost(total_cost,seft_cost,service_cost,operator_cost,nurse_cost,other_cost," +
                                " blzd_cost,syszd_cost,yxxzd_cost,zdxm_cost,fssxm_cost,wlzl_cost,sszl_cost,mz_cost,kjyw_cost," +
                                " kf_cost,zxzl_cost,xy_cost,zchy_cost,zcy_cost,xue_cost,bdbl_cost,qdbl_cost,nxyz_cost,xbyzl_cost," +
                                " jcyycl_cost,zlyycl_cost,ssyycl_cost,ol_cost,patient_id,Shs_Cost)values" +
                                " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'," +
                                " '{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}')",
                                total_Cost, seft_Cost, service_Cost, operator_Cost, nurse_Cost, other_Cost, blzd_Cost, syszd_Cost, yxxzd_Cost, zdxm_Cost,
                                fshszl_Cost, wlzl_Cost, shszl_Cost, mz_Cost, kjyw_Cost, kf_Cost, zyzl_Cost, xy_Cost, zchy_Cost, zcy_Cost,
                                xue_Cost, bdbl_Cost, qdbl_Cost, nxyzl_Cost, xbyzl_Cost, jccl_Cost, zlcl_Cost, shscl_Cost, qt_Cost, pat_id, shs_Cost);
            sqls.Add(Insert_Sql);
            return sqls;

        }

        /// <summary>
        /// 保存病人手术界面的 SQL
        /// </summary>
        /// <returns>SQL 集合</returns>
        private IEnumerable<string> SavePatientOperating()
        {
            List<string> sqls = new List<string>();
            sqls.Add(@"delete COVER_OPERATION where PATIENT_ID='" + inPatientInfo.Id + "'");
            // 以下是每一条手术信息的十个字段
            // TextBox
            string OperHandle = string.Empty;
            string OperCode = string.Empty;
            string OperDoctor = string.Empty;
            string AnesthesiaDoctor = string.Empty;
            string AnesthesiaWay = string.Empty;
            string OperAssistant1 = string.Empty;
            string OperAssistant2 = string.Empty;

            // ComboBox
            string ToHealLevel = string.Empty;
            string OperLevel = string.Empty;

            // DateTimePicker
            string OperDate = "";

            // 计数器
            int count = 0;
            foreach (Control var in panel5.Controls)
            {
                #region 获取 TextBox、ComboBox、DateTimePicker 的值
                if (var.Name.Contains("OperHandle"))
                {
                    OperHandle = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("OperCode"))
                {
                    OperCode = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("OperDoctor"))
                {
                    OperDoctor = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("AnesthesiaDoctor"))
                {
                    AnesthesiaDoctor = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("AnesthesiaWay"))
                {
                    AnesthesiaWay = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("OperAssistant1"))
                {
                    OperAssistant1 = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("OperAssistant2"))
                {
                    OperAssistant2 = App.ReplaceSQLCharEN(var.Text);
                }

                if (var.Name.Contains("ToHealLevel"))
                {
                    ToHealLevel = App.ReplaceSQLCharEN(var.Text);
                }
                if (var.Name.Contains("OperLevel"))
                {
                    OperLevel = App.ReplaceSQLCharEN(var.Text);
                }

                if (var.Name.Contains("OperDate"))
                {
                    DateTimePicker dtp = var as DateTimePicker;
                    OperDate = dtp.Value.ToShortDateString();
                }
                #endregion

                count++;
                if (count == 10) // 遍历10个控件就完成了一组手术指标的记录
                {
                    if (OperHandle.Length != 0)
                    {
                        string sql = @"insert into COVER_OPERATION(INPATIENT_ID,OPER_CODE,OPER_NAME,OPER_DATE,OPERATOR,OPER_ASSIST1,
                        OPER_ASSIST2,ANAES_METHOD,CLOSE_LEVEL,ANAESTHETIST,OPER_LEVEL,PATIENT_ID) values('{0}','{1}','{2}',
                       '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')";
                        sql = string.Format(sql, inPatientInfo.PId, OperCode, OperHandle, OperDate, OperDoctor, OperAssistant1,
                            OperAssistant2, AnesthesiaWay, ToHealLevel, AnesthesiaDoctor, OperLevel, inPatientInfo.Id);
                        sqls.Add(sql);
                    }
                    count = 0;
                }
            }
            return sqls;
        }

        /// <summary>
        /// 保存杂项(血型,RH指标,过敏药物)
        /// </summary>
        /// <returns>SQL 集合</returns>
        private IEnumerable<string> SavePatientTemp()
        {
            RadioButton rdo = null;

            // 血型选项值
            string bloodType = CheckRadioPanel(panel2);

            // RH 指标选项值
            string rh = CheckRadioPanel(panel3);

            // corpse 尸检
            string checkCorpse = CheckRadioPanel(panel6);

            // 离院方式
            string outHospital = CheckRadioPanel(panel7);
            string turnToHospital = txtOutHospital2.Text.Length > txtOutHospital3.Text.Length ?
                txtOutHospital2.Text : txtOutHospital3.Text;

            // 是否再住院
            string inAgain = CheckRadioPanel(panel8);
            string purpose = txtPurpose.Text;

            // 颅脑损伤
            string beforeIn_Day = txtBeforeIn_Day.Text;
            string beforeIn_Hour = txtBeforeIn_Hour.Text;
            string beforeIn_Minute = txtBeforeIn_Minute.Text;
            string afterIn_Day = txtAfterIn_Day.Text;
            string afterIn_Hour = txtAfterIn_Hour.Text;
            string afterIn_Minute = txtAfterIn_Minute.Text;
            //湖南新加的 病例分型------新生儿评分
            InitTempVal();

            if (radioButton2.Checked == true && txtMedicine.Text.Length == 0)
            {
                txtMedicine.Text = "  ";
            }
            List<string> sqls = new List<string>();
            sqls.Add(@"delete COVER_TEMP where PATIENT_ID='" + inPatientInfo.Id + "'");
            string sql = string.Format(@"insert into COVER_TEMP(MEDICINESENSITIVE,BLOOD_TYPE,RH,PATIENT_ID,CHECKCORPSE,
                            OUTHOSPITAL,TURNTOHOSPITAL,INAGAIN,PURPOSE,BEFOREIN_DAY,BEFOREIN_HOUR,BEFOREIN_MINUTE,
                            AFTERIN_DAY,AFTERIN_HOUR,AFTERIN_MINUTE, BLFX,SSZZJH,JH_DAY,JH_HOUR,DBZGL,SSDRGS,KSSSY,
                            XJPYBBSJ,FDCRB,ZLFQ_T,ZLFQ_N,ZLFQ_M1,ZLFQ_M2,BABY_APGAR,LCLJGL) 
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',
                            '{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}',
                            '{26}','{27}','{28}','{29}')", txtMedicine.Text, bloodType,
                            rh, inPatientInfo.Id, checkCorpse, outHospital, turnToHospital, inAgain, purpose, beforeIn_Day,
                            beforeIn_Hour, beforeIn_Minute, afterIn_Day, afterIn_Hour, afterIn_Minute, sBLFX, sSSZZJH, sJH_DAY,
                            sJH_HOUR, sDBZGL, sSSDRGS, sKSSSY, sXJPYBBSJ, sFDCRB, sZLFQ_T, sZLFQ_N, sZLFQ_M1, sZLFQ_M2, sBABY_APGAR, sLCLJGL);
            sqls.Add(sql);
            return sqls;
        }

        /// <summary>
        /// 返回Panel中被选中的单选按钮值
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        private string CheckRadioPanel(Panel panel)
        {
            foreach (Control var in panel.Controls)
            {
                RadioButton rdo = var as RadioButton;
                if (rdo != null && rdo.Checked)
                {
                    return rdo.Text;
                }
            }
            return "/";
        }

        /// <summary>
        /// 离院方式中单选按钮事件
        /// </summary>
        private void rdoOutHospital_Click(object sender, EventArgs e)
        {
            RefleshPanel(panel7);
            if (rdoOutHospital2.Checked)
            {
                txtOutHospital2.ReadOnly = false;
            }
            if (rdoOutHospital3.Checked)
            {
                txtOutHospital3.ReadOnly = false;
            }
        }

        /// <summary>
        /// 清空 Panel 中的文本框内容,并设为只读
        /// </summary>
        /// <param name="panel"></param>
        private void RefleshPanel(Panel panel)
        {
            foreach (Control var in panel.Controls)
            {
                if (var is TextBox)
                {
                    TextBox txt = var as TextBox;
                    txt.Text = "";
                    txt.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 初始化诊断界面
        /// </summary>
        private void InitDiagnose()
        {
            /*
             * 诊断界面中的一些杂项             
             */
            if (ds_cost != null)
            {
                //药物过敏
                if (ds_cost.Tables["GMYWBJ"].Rows[0][0].ToString() == "1")
                {
                    radioButton1.Checked = true;
                    txtMedicine.Text = "";
                }
                else
                {
                    radioButton2.Checked = true;
                    txtMedicine.Text = ds_cost.Tables["GMYWMC"].Rows[0][0].ToString();
                }

                //血型  BRXX
                if (ds_cost.Tables["BRXX"].Rows.Count > 0)
                {
                    if (ds_cost.Tables["BRXX"].Rows[0][0].ToString() == "A")
                    {
                        rdoBloodA.Checked = true;
                    }
                    else if (ds_cost.Tables["BRXX"].Rows[0][0].ToString() == "B")
                    {
                        rdoBloodB.Checked = true;
                    }
                    else if (ds_cost.Tables["BRXX"].Rows[0][0].ToString() == "AB")
                    {
                        rdoBloodAB.Checked = true;
                    }
                    else if (ds_cost.Tables["BRXX"].Rows[0][0].ToString() == "O")
                    {
                        rdoBloodO.Checked = true;
                    }
                    else if (ds_cost.Tables["BRXX"].Rows[0][0].ToString() == "不详")
                    {
                        rdoBloodNotKnow.Checked = true;
                    }
                    else
                    {
                        rdoBloodNotCheck.Checked = true;
                    }
                }
                else
                {
                    rdoBloodNotCheck.Checked = true;
                }

                //RH血型 BRRHXX
                if (ds_cost.Tables["BRRHXX"].Rows.Count > 0)
                {
                    if (ds_cost.Tables["BRRHXX"].Rows[0][0].ToString().Contains("阴性"))
                    {
                        rdoRHFeminine.Checked = true;
                    }
                    else if (ds_cost.Tables["BRRHXX"].Rows[0][0].ToString().Contains("阳性"))
                    {
                        rdoRHMasculine.Checked = true;
                    }
                    else if (ds_cost.Tables["BRRHXX"].Rows[0][0].ToString().Contains("未知"))
                    {
                        rdoRHNotKnow.Checked = true;
                    }
                    else
                    {
                        rdoRHNotCheck.Checked = true;
                    }
                }
                else
                {
                    rdoRHNotCheck.Checked = true;
                }


                //出院主诊断
                if (ds_cost.Tables["CYZZD"].Rows.Count > 0)
                    txtMajorDiagnose.Text = ds_cost.Tables["CYZZD"].Rows[0][0].ToString();
                if (ds_cost.Tables["CYZZDDM"].Rows.Count > 0)
                    txtMajorDiagnoseCode.Text = ds_cost.Tables["CYZZDDM"].Rows[0][0].ToString();
                if (ds_cost.Tables["CYZZDRYQK"].Rows.Count > 0)
                    cboMajorPatientCondition.Text = ds_cost.Tables["CYZZDRYQK"].Rows[0][0].ToString();

            }

            string sql = "select TYPE,NAME,ICD10CODE,INCONDITION,PNUMBER,TURN_TO,is_chinese from cover_diagnose where PATIENT_ID='" + this.inPatientInfo.Id + "'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                List<OutPatientDiagndose> opds = new List<OutPatientDiagndose>();
                OutPatientDiagndose opd = null;
                foreach (DataRow dr in dt.Rows)
                {
                    string type = dr["TYPE"].ToString();
                    switch (type)
                    {
                        case "M": // 主要诊断
                            if (dr["NAME"].ToString().Trim() != "")
                                txtMajorDiagnose.Text = dr["NAME"].ToString();
                            if (dr["ICD10CODE"].ToString().Trim() != "")
                                txtMajorDiagnoseCode.Text = dr["ICD10CODE"].ToString();
                            if (dr["INCONDITION"].ToString().Trim() != "")
                                cboMajorPatientCondition.Text = dr["INCONDITION"].ToString();
                            cboTurnTo.Text = dr["TURN_TO"].ToString();
                            if (dr["is_chinese"].ToString() == "1")
                            {
                                InitZYValidation();
                                cboxZY.Checked = true;
                            }
                            else
                            {
                                InitZYValidation();
                                cboxZY.Checked = false;
                            }
                            break;
                        case "P": // 病理诊断
                            txtPathology.Text = dr["NAME"].ToString();
                            txtPathologyCode.Text = dr["ICD10CODE"].ToString();
                            txtPathologyNumber.Text = dr["PNUMBER"].ToString();
                            break;
                        case "S": // 损伤中毒
                            txtPoison.Text = dr["NAME"].ToString();
                            txtPoisonCode.Text = dr["ICD10CODE"].ToString();
                            break;
                        case "E": // 门急诊
                            txtEmergencyDiagnose.Text = dr["NAME"].ToString();
                            txtEmergencyCode.Text = dr["ICD10CODE"].ToString();
                            if (dr["is_chinese"].ToString() == "1")
                            {
                                InitMZValidation();
                                cboxMZ.Checked = true;
                            }
                            else
                            {
                                InitMZValidation();
                                cboxMZ.Checked = false;
                            }
                            break;
                        case "O": // 其他诊断
                            opd = new OutPatientDiagndose();
                            opd.Name = dr["NAME"].ToString();
                            opd.ICD10 = dr["ICD10CODE"].ToString();
                            opd.Condition = dr["INCONDITION"].ToString();
                            opd.Is_Chinese = dr["is_chinese"].ToString();
                            opds.Add(opd);
                            break;
                    }
                }

                // 对其他诊断控件进行初始化
                if (opds.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < opds.Count; i++)
                    {
                        ucOtherDiagnose uc = grpOtherDiagnose.Controls[j] as ucOtherDiagnose;
                        j++;
                        if (uc == null)
                        {
                            i--;
                            continue;
                        }
                        uc.OtherDiagnose = opds[i].Name;
                        uc.ICD10 = opds[i].ICD10;
                        uc.InCondition = opds[i].Condition;
                        uc.Ischinese = string.IsNullOrEmpty(opds[i].Is_Chinese) ? false : (opds[i].Is_Chinese == "1" ? true : false);
                        uc.SetCheckBox(uc.Ischinese);
                    }
                }

            }
        }

        /// <summary>
        /// 初始化手术界面
        /// </summary>
        private void InitOperating()
        {
            #region HIS中的手术信息
            if (ds_cost != null)
            {
                if (ds_cost.Tables["OPERATOR"].Rows.Count > 0)
                {
                    DataTable dt_his = ds_cost.Tables["OPERATOR"];
                    TextBox txt_his = null;
                    ComboBox cbo_his = null;
                    DateTimePicker dtp_his = null;
                    for (int i = 0; i < dt_his.Rows.Count; i++)
                    {
                        foreach (Control ctr in panel5.Controls)
                        {
                            #region 对文本框赋值
                            txt_his = ctr as TextBox;
                            if (txt_his != null && txt_his.Name.Substring(txt_his.Name.Length - 1) == (i + 1).ToString())
                            {
                                if (txt_his.Name.Contains("txtOperCode"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["手术及操作编码"].ToString();
                                }
                                if (txt_his.Name.Contains("txtOperHandle"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["手术名称"].ToString();
                                }
                                if (txt_his.Name.Contains("txtOperDoctor"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["手术医生"].ToString();
                                }
                                if (txt_his.Name.Contains("txtOperAssistant1_"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["手术医生I助"].ToString();
                                }
                                if (txt_his.Name.Contains("txtOperAssistant2_"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["手术医生II助"].ToString();
                                }
                                if (txt_his.Name.Contains("txtAnesthesiaWay"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["麻醉方式"].ToString();
                                }
                                if (txt_his.Name.Contains("txtAnesthesiaDoctor"))
                                {
                                    txt_his.Text = dt_his.Rows[i]["麻醉医生"].ToString();
                                }
                            }
                            #endregion

                            #region 对下拉列表赋值
                            cbo_his = ctr as ComboBox;
                            if (cbo_his != null && cbo_his.Name.Contains((i + 1).ToString()))
                            {
                                if (cbo_his.Name.Contains("cboOperLevel"))
                                {
                                    cbo_his.Text = dt_his.Rows[i]["手术级别"].ToString();
                                }
                                if (cbo_his.Name.Contains("cboToHealLevel"))
                                {
                                    cbo_his.Text = dt_his.Rows[i]["手术切口等级"].ToString();
                                }
                            }
                            #endregion

                            #region 对时间赋值
                            dtp_his = ctr as DateTimePicker;
                            if (dtp_his != null && dtp_his.Name.Contains((i + 1).ToString()))
                            {
                                dtp_his.Value = Convert.ToDateTime(dt_his.Rows[i]["手术及操作日期"]);
                            }
                            #endregion
                        }
                    }


                }

                //其他的一些杂项 SSYTJH SSYTMD
                if (ds_cost.Tables["SSYTJH"].Rows[0][0].ToString() == "1")
                {
                    rdoAgainIn2.Checked = true;
                    txtPurpose.Text = ds_cost.Tables["SSYTMD"].Rows[0][0].ToString();
                }
                else
                {
                    rdoAgainIn1.Checked = true;
                }
            }
            #endregion

            #region 我方数据库中存储的手术信息
            string sql = @"select OPER_CODE,OPER_NAME,OPER_DATE,OPERATOR,OPER_ASSIST1,OPER_ASSIST2,ANAES_METHOD,
                CLOSE_LEVEL,ANAESTHETIST,OPER_LEVEL from cover_operation where PATIENT_ID='" + this.inPatientInfo.Id + "'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextBox txt = null;
                ComboBox cbo = null;
                DateTimePicker dtp = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (Control ctr in panel5.Controls)
                    {
                        #region 对文本框赋值
                        txt = ctr as TextBox;
                        if (txt != null && txt.Name.Substring(txt.Name.Length - 1) == (i + 1).ToString())
                        {
                            if (txt.Name.Contains("txtOperCode"))
                            {
                                if (dt.Rows[i]["OPER_CODE"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["OPER_CODE"].ToString();
                            }
                            if (txt.Name.Contains("txtOperHandle"))
                            {
                                if (dt.Rows[i]["OPER_NAME"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["OPER_NAME"].ToString();
                            }
                            if (txt.Name.Contains("txtOperDoctor"))
                            {
                                if (dt.Rows[i]["OPERATOR"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["OPERATOR"].ToString();
                            }
                            if (txt.Name.Contains("txtOperAssistant1_"))
                            {
                                if (dt.Rows[i]["OPER_ASSIST1"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["OPER_ASSIST1"].ToString();
                            }
                            if (txt.Name.Contains("txtOperAssistant2_"))
                            {
                                if (dt.Rows[i]["OPER_ASSIST2"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["OPER_ASSIST2"].ToString();
                            }
                            if (txt.Name.Contains("txtAnesthesiaWay"))
                            {
                                if (dt.Rows[i]["ANAES_METHOD"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["ANAES_METHOD"].ToString();
                            }
                            if (txt.Name.Contains("txtAnesthesiaDoctor"))
                            {
                                if (dt.Rows[i]["ANAESTHETIST"].ToString().Trim() != "")
                                    txt.Text = dt.Rows[i]["ANAESTHETIST"].ToString();
                            }
                        }
                        #endregion

                        #region 对下拉列表赋值
                        cbo = ctr as ComboBox;
                        if (cbo != null && cbo.Name.Contains((i + 1).ToString()))
                        {
                            if (cbo.Name.Contains("cboOperLevel"))
                            {
                                if (dt.Rows[i]["OPER_LEVEL"].ToString().Trim() != "")
                                    cbo.Text = dt.Rows[i]["OPER_LEVEL"].ToString();
                            }
                            if (cbo.Name.Contains("cboToHealLevel"))
                            {
                                if (dt.Rows[i]["CLOSE_LEVEL"].ToString().Trim() != "")
                                    cbo.Text = dt.Rows[i]["CLOSE_LEVEL"].ToString();
                            }
                        }
                        #endregion

                        #region 对时间赋值
                        dtp = ctr as DateTimePicker;
                        if (dtp != null && dtp.Name.Contains((i + 1).ToString()))
                        {
                            if (dt.Rows[i]["OPER_DATE"].ToString().Trim() != "")
                                try
                                {
                                    dtp.Value = Convert.ToDateTime(dt.Rows[i]["OPER_DATE"]);
                                }
                                catch
                                {
                                    dtp.Value = App.GetSystemTime();
                                }
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 初始病案质量及医师
        /// </summary>
        private void InitQuality()
        {
            string sql = @"select QUALITY,Q_DOCTOR_NAME,Q_NURSE_NAME,Q_DATE,PATIENT_ID,SX_DOCTOR_NAME,JX_DOCTOR_NAME,
                ZR_NURSE_NAME,ZY_DOCTOR_NAME,ZZ_DOCTOR_NAME,ZR_DOCTOR_NAME,SECTION_HEAD,CODER_NAME from cover_quality 
                where PATIENT_ID='" + this.inPatientInfo.Id + "'";
            //dtpQC_Time.Value = Convert.ToDateTime("1949-10-01"); ;
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtSEC_DIRE_NAME.Text = dt.Rows[0]["SECTION_HEAD"].ToString();
                txtDIRE_NAME.Text = dt.Rows[0]["ZR_DOCTOR_NAME"].ToString();
                txtDUTY_DOC_NAME.Text = dt.Rows[0]["ZZ_DOCTOR_NAME"].ToString();
                txtPOS_DOC_NAME.Text = dt.Rows[0]["ZY_DOCTOR_NAME"].ToString();
                txtPRA_DOC_NAME.Text = dt.Rows[0]["ZR_NURSE_NAME"].ToString();
                txtIN_DOC_NAME.Text = dt.Rows[0]["JX_DOCTOR_NAME"].ToString();
                txtQC_Doctor.Text = dt.Rows[0]["SX_DOCTOR_NAME"].ToString();
                txtCoder.Text = dt.Rows[0]["CODER_NAME"].ToString();
                txtSTU_DOC_NAME.Text = dt.Rows[0]["Q_DOCTOR_NAME"].ToString();
                txtQC_Nurse.Text = dt.Rows[0]["Q_NURSE_NAME"].ToString();
                if (dt.Rows[0]["Q_DATE"].ToString() != "")
                {
                    //dtpQC_Time.Value = Convert.ToDateTime(dt.Rows[0]["Q_DATE"]);
                    txtQC_Time.Text = dt.Rows[0]["Q_DATE"].ToString();
                }
                string sTemp = dt.Rows[0]["QUALITY"].ToString();
                foreach (Control ctr in pnlMEDICAL_RECODE.Controls)
                {
                    if (ctr.Text == sTemp.Trim())
                    {
                        RadioButton rdo = ctr as RadioButton;
                        rdo.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化杂项(过敏药物,血型,RH)
        /// </summary>
        private void InitTemp()
        {
            string sql = @"select MEDICINESENSITIVE,BLOOD_TYPE,RH,CHECKCORPSE,OUTHOSPITAL,TURNTOHOSPITAL,INAGAIN,
                PURPOSE,BEFOREIN_DAY,BEFOREIN_HOUR,BEFOREIN_MINUTE,AFTERIN_DAY,AFTERIN_HOUR,AFTERIN_MINUTE, BLFX,SSZZJH,JH_DAY,JH_HOUR,DBZGL,LCLJGL ,SSDRGS,KSSSY,
                            XJPYBBSJ,FDCRB,ZLFQ_T,ZLFQ_N,ZLFQ_M1,ZLFQ_M2,BABY_APGAR from COVER_TEMP where PATIENT_ID='" + inPatientInfo.Id + "'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string sTemp = dt.Rows[0]["MEDICINESENSITIVE"].ToString();
                if (sTemp.Length != 0)
                {
                    radioButton2.Checked = true;
                    txtMedicine.Text = sTemp;
                    txtMedicine.ReadOnly = false;
                }

                sTemp = dt.Rows[0]["BLOOD_TYPE"].ToString();
                RadioButton rdo = null;
                foreach (Control var in panel2.Controls)
                {
                    rdo = var as RadioButton;
                    if (rdo != null && rdo.Text == sTemp)
                    {
                        rdo.Checked = true;
                        break;
                    }
                }

                sTemp = dt.Rows[0]["RH"].ToString();
                foreach (Control var in panel3.Controls)
                {
                    rdo = var as RadioButton;
                    if (rdo != null && rdo.Text == sTemp)
                    {
                        rdo.Checked = true;
                        break;
                    }
                }

                sTemp = dt.Rows[0]["CHECKCORPSE"].ToString();
                foreach (Control var in panel6.Controls)
                {
                    rdo = var as RadioButton;
                    if (rdo != null && rdo.Text == sTemp)
                    {
                        rdo.Checked = true;
                        break;
                    }
                }

                sTemp = dt.Rows[0]["OUTHOSPITAL"].ToString();
                foreach (Control var in panel7.Controls)
                {
                    rdo = var as RadioButton;
                    if (rdo != null && rdo.Text == sTemp)
                    {
                        rdo.Checked = true;
                        break;
                    }
                }

                sTemp = dt.Rows[0]["INAGAIN"].ToString();
                foreach (Control var in panel8.Controls)
                {
                    rdo = var as RadioButton;
                    if (rdo != null && rdo.Text == sTemp)
                    {
                        rdo.Checked = true;
                        break;
                    }
                }

                sTemp = dt.Rows[0]["TURNTOHOSPITAL"].ToString();
                if (rdoOutHospital2.Checked)
                {
                    txtOutHospital2.Text = sTemp;
                }
                if (rdoOutHospital3.Checked)
                {
                    txtOutHospital3.Text = sTemp;
                }

                txtPurpose.Text = dt.Rows[0]["PURPOSE"].ToString();
                txtBeforeIn_Day.Text = dt.Rows[0]["BEFOREIN_DAY"].ToString();
                txtBeforeIn_Hour.Text = dt.Rows[0]["BEFOREIN_HOUR"].ToString();
                txtBeforeIn_Minute.Text = dt.Rows[0]["BEFOREIN_MINUTE"].ToString();
                txtAfterIn_Day.Text = dt.Rows[0]["AFTERIN_DAY"].ToString();
                txtAfterIn_Hour.Text = dt.Rows[0]["AFTERIN_HOUR"].ToString();
                txtAfterIn_Minute.Text = dt.Rows[0]["AFTERIN_MINUTE"].ToString();

                sBLFX = dt.Rows[0]["BLFX"].ToString();
                sSSZZJH = dt.Rows[0]["SSZZJH"].ToString();
                sJH_DAY = dt.Rows[0]["JH_DAY"].ToString();
                sJH_HOUR = dt.Rows[0]["JH_HOUR"].ToString();
                sDBZGL = dt.Rows[0]["DBZGL"].ToString();
                sLCLJGL = dt.Rows[0]["LCLJGL"].ToString();
                sSSDRGS = dt.Rows[0]["SSDRGS"].ToString();
                sKSSSY = dt.Rows[0]["KSSSY"].ToString();
                sXJPYBBSJ = dt.Rows[0]["XJPYBBSJ"].ToString();
                sFDCRB = dt.Rows[0]["FDCRB"].ToString();
                sZLFQ_T = dt.Rows[0]["ZLFQ_T"].ToString();
                sZLFQ_N = dt.Rows[0]["ZLFQ_N"].ToString();
                sZLFQ_M1 = dt.Rows[0]["ZLFQ_M1"].ToString();
                sZLFQ_M2 = dt.Rows[0]["ZLFQ_M2"].ToString();
                sBABY_APGAR = dt.Rows[0]["BABY_APGAR"].ToString();
                ReadTempVal();
            }
        }

        /// <summary>
        /// 将入院情况的字样转换为阿拉伯数字
        /// </summary>   
        private string ChangeInCondition(object obj)
        {
            if (obj != null)
            {
                string sVal = string.Empty;
                switch (obj.ToString())
                {
                    case "有":
                        sVal = "1";
                        break;
                    case "临床未确定":
                        sVal = "2";
                        break;
                    case "情况不明":
                        sVal = "3";
                        break;
                    case "无":
                        sVal = "4";
                        break;
                }
                return sVal;
            }
            return "-";
        }
        /// <summary>
        /// 将付款方式转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string ConvertPay(string obj)
        {
            string vals = string.Empty;
            switch (obj)
            {
                case "城镇职工基本医疗保险":
                    vals = "1";
                    break;
                case "城镇居民基本医疗保险":
                    vals = "2";
                    break;
                case "新型农村合作医疗":
                    vals = "3";
                    break;
                case "贫困救助":
                    vals = "4";
                    break;
                case "商业医疗保险":
                    vals = "5";
                    break;
                case "全公费":
                    vals = "6";
                    break;
                case "全自费":
                    vals = "7";
                    break;
                case "其他社会保险":
                    vals = "8";
                    break;
                default:
                    vals = "—";
                    break;
            }
            return vals;
        }

        /// <summary>
        /// 将病案质量的字样转换为阿拉伯数字
        /// </summary>        
        private string ChangeQuality(object obj)
        {
            if (obj != null)
            {
                string sVal = string.Empty;
                switch (obj.ToString().Trim())
                {
                    case "甲":
                        sVal = "1";
                        break;
                    case "乙":
                        sVal = "2";
                        break;
                    case "丙":
                        sVal = "3";
                        break;
                }
                return sVal;
            }
            return "-";
        }

        /// <summary>
        /// 打印病案首页
        /// </summary>
        public void btnPrint_Click(object sender, EventArgs e)
        {
            //if (!App.Ask("当前病案首页页面的内容是否保存了?未保存请点“否”,保存后再进入打印界面! "))
            //{
            //    return;
            //}

            //string sql_doc = "select count(*) as count_doc from t_patients_doc t where t.patient_id=" + this.inPatientInfo.Id + " and (t.textkind_id=389 or t.textkind_id=151)";
            //string str_doc = App.ReadSqlVal(sql, 0, "count_doc");
            //if (str_doc > 0)
            //{
            //    string sql_oper = "select count(*) as count_oper from COVER_APPEND_OPER where PATIENT_ID='" + this.inPatientInfo.Id + "'";
            //    string str_oper = App.ReadSqlVal(sql, 0, "count_oper");
            //    if (str_oper <= 0)
            //    {

            //        return;
            //    }

            //}
            //20140420注释:先不开放附页
            //0401开放
            //string sql_QAS = "select count(*) as count_QAS from COVER_APPEND_QAS where PATIENT_ID='" + this.inPatientInfo.Id + "'";
            //string str_QAS = App.ReadSqlVal(sql_QAS, 0, "count_QAS");
            //if (Convert.ToInt32(str_QAS) <= 0)
            //{
            //    App.Msg("提示:打印之前,请完成首页附页信息!");
            //    return;
            //}


            // 获取病人信息
            DataTable CoverInfo = GetCoverInfo();
            #region 病人信息的必填项检查
            DataRow dr = CoverInfo.Rows[0];
            if (dr["Pay_Manager"].ToString().Trim() == "-" || dr["Pay_Manager"].ToString().Trim() == "")
            {
                App.Msg("付费方式为空,不能打印！");
                return;
            }
            if (dr["Patient_Name"].ToString().Trim() == "-" || dr["Patient_Name"].ToString().Trim() == "")
            {
                App.Msg("患者姓名为空,不能打印！");
                return;
            }
            if (dr["Gender_Code"].ToString().Trim() == "-" || dr["Gender_Code"].ToString().Trim() == "")
            {
                App.Msg("患者性别为空,不能打印！");
                return;
            }
            if (dr["Age"] != null && dr["Age"].ToString() == "0")
            {
                App.Msg("患者年龄为0,不能打印！");
                return;
            }
            //dr["Born_City"] = "-";
            //dr["Born_Xian"] = "-";
            if (dr["Born_Province"].ToString().Trim() == "-" || dr["Born_Province"].ToString().Trim() == ""|| dr["Born_Xian"].ToString().Trim() == "-" || dr["Born_Xian"].ToString().Trim() == ""|| dr["Born_City"].ToString().Trim() == "-" || dr["Born_City"].ToString().Trim() == "")
            {
                App.Msg("患者出生不能为空或者填写不完全！");
                return;
            }
            if (dr["Natiye_place_Province"].ToString().Trim() == "-" || dr["Natiye_place_Province"].ToString().Trim() == ""|| dr["Natiye_place_City"].ToString().Trim() == "-" || dr["Natiye_place_City"].ToString().Trim() == "")
            {
                App.Msg("籍贯不能为空或者填写不完全！");
                return;
            }
            //if (dr["Folk_code"].ToString().Trim() == "-" || dr["Folk_code"].ToString().Trim() == "")
            //{
            //    App.Msg("民族为空,不能打印！");
            //    return;
            //}
            if (dr["Cert_Id"].ToString().Trim() == "-" || dr["Cert_Id"].ToString().Trim() == "")
            {
                App.Msg("身份证为空,不能打印！");
                return;
            }
            //if (dr["Career"].ToString().Trim() == "-" || dr["Career"].ToString().Trim() == "")
            //{
            //    App.Msg("职业为空,不能打印！");
            //    return;
            //}
            //if (dr["Now_address"].ToString().Trim() == "-" || dr["Now_address"].ToString().Trim() == "")
            //{
            //    App.Msg("现住址为空,不能打印！");
            //    return;
            //}
            //if (dr["Now_addres_phone"].ToString().Trim() == "-" || dr["Now_addres_phone"].ToString().Trim() == "")
            //{
            //    App.Msg("现住址电话为空,不能打印！");
            //    return;
            //}
            //if (dr["Now_addres_PostNo"].ToString().Trim() == "-" || dr["Now_addres_PostNo"].ToString().Trim() == "")
            //{
            //    App.Msg("现住址邮编为空,不能打印！");
            //    return;
            //}
            //if (dr["Home_address"].ToString().Trim() == "-" || dr["Home_address"].ToString().Trim() == "")
            //{
            //    App.Msg("户口地址为空,不能打印！");
            //    return;
            //}
            //if (dr["HomePostal_code"].ToString().Trim() == "-" || dr["HomePostal_code"].ToString().Trim() == "")
            //{
            //    App.Msg("户口邮编为空,不能打印！");
            //    return;
            //}
            //if (dr["In_Approach"].ToString().Trim() == "-" || dr["In_Approach"].ToString().Trim() == "")
            //{
            //    App.Msg("患者入院途径为空,不能打印！");
            //    return;
            //}
            //if (dr["Marrige_State"].ToString().Trim() == "-" || dr["Marrige_State"].ToString().Trim() == "")
            //{
            //    App.Msg("患者婚姻为空,不能打印！");
            //    return;
            //}

            //if (dr["Birthday_Year"].ToString() == "-" || dr["Birthday_Month"].ToString() == "-" || dr["Birthday_Day"].ToString() == "-")
            //{
            //    MessageBox.Show("生日填写不完整,请检查并重新填写!");
            //    return;
            //}
            //if (dr["Born_Province"].ToString() == "-" && dr["Born_City"].ToString() == "-" && dr["Born_Xian"].ToString() == "-")
            //{
            //    MessageBox.Show("出生地填写不完整,请检查并重新填写!");
            //    return;
            ////}
            //if (dr["Natiye_place_Province"].ToString() == "-" || dr["Natiye_place_City"].ToString() == "-" || dr["Natiye_place_Province"].ToString() == "" || dr["Natiye_place_City"].ToString() == "")
            //{
            //    MessageBox.Show("籍贯填写不完整,请检查并重新填写!");
            //    return;
            //}
            //if (dr["Now_address"].ToString() == "-")
            //{
            //    MessageBox.Show("现住址必须填写!");
            //    return;
            //}
            //if (dr["Relation_name"].ToString() == "-" || dr["Relation_name"].ToString() == "")
            //{
            //    App.Msg("联系人姓名为空,不能打印！");
            //    return;
            //}
            //if (dr["Relation"].ToString() == "-" || dr["Relation"].ToString() == "")
            //{
            //    App.Msg("联系人关系为空,不能打印！");
            //    return;
            //}
            //if (dr["Relation_address"].ToString() == "-" || dr["Relation_address"].ToString() == "")
            //{
            //    App.Msg("联系人地址为空,不能打印！");
            //    return;
            //}
            //if (dr["Relation_phone"].ToString() == "-" || dr["Relation_phone"].ToString() == "")
            //{
            //    App.Msg("联系人电话为空,不能打印！");
            //    return;
            //}
            if (dr["Die_time_Year"].ToString() == "-" || dr["Die_time_Year"].ToString() == "")
            {
                App.Msg("出院时间为空,不能打印！");
                return;
            }
            if (dr["insection_name"].ToString() == "-" || dr["insection_name"].ToString() == "")
            {
                App.Msg("出院科别为空,不能打印！");
                return;
            }
            if (dr["In_Area_Name"].ToString() == "-" || dr["In_Area_Name"].ToString() == "")
            {
                App.Msg("出院病房为空,不能打印！");
                return;
            }
            if (dr["InHospital_Days"].ToString() == "-" || dr["InHospital_Days"].ToString() == "")
            {
                App.Msg("实际住院天数为空,不能打印！");
                return;
            }
            //if (dr["Age"].ToString() == "")//&& dr["Age_Month"].ToString() == "-" && dr["Age_Hours"].ToString() == "-"
            //{
            //    MessageBox.Show("年龄必须填写!");
            //    return;
            //}
            #endregion

            // 获取诊断信息
            DataTable Diagnose = GetCoverDiagnose();
            #region 主要诊断必须填写入院病情和转归情况
            dr = Diagnose.Rows[0];
            if (dr["Diagnose_M"].ToString().Trim() == "" || dr["Diagnose_M"].ToString().Trim() == "-")
            {
                App.Msg("主要诊断为空,不能打印！");
                return;
            }
            if (dr["Diagnose_M_Condition"].ToString().Trim() == "" || dr["Diagnose_M_Condition"].ToString().Trim() == "-")
            {
                App.Msg("主要诊断入院病情为空,不能打印！");
                return;
            }
            //出院其它诊断入院病情
            for (int i = 1; i <=21; i++)
            {
                string strOtherDiagName = dr["Diagnose_O_" + i.ToString()].ToString();
                if (strOtherDiagName.Trim() != "" && strOtherDiagName.Trim() != "-")
                {
                    string strOtherInCondition = dr["Diagnose_O_Condition_" + i.ToString()].ToString();
                    if (strOtherInCondition.Trim() == "" || strOtherInCondition.Trim() == "-")
                    {
                        App.Msg("出院其它诊断入院病情为空,不能打印！");
                        return;
                    }
                }
            }
            //if (dr["Diagnose_M"].ToString() != "-")
            //{
                //if (dr["Diagnose_M_Condition"].ToString() == "-")
                //{
                //    MessageBox.Show("主要诊断必须填写入院病情!");
                //    return;
                //}
                //if (dr["TURN_TO"].ToString() == "-")
                //{
                //    MessageBox.Show("主要诊断必须填写转归情况!");
                //    return;
                //}
            //}
            #endregion


            // 获取手术信息
            DataTable Operation = GetOperation();

            // 获取病案质量信息
            DataTable Quality = GetQuality();
            dr = Quality.Rows[0];
            #region 病案质量必填项控制
            if (dr["SECTION_HEAD"].ToString().Trim() == "-" || dr["SECTION_HEAD"].ToString().Trim() == "")
            {
                App.Msg("科主任为空,不能打印！");
                return;
            }
            if (dr["ZY_DOCTOR_NAME"].ToString().Trim() == "-" || dr["ZY_DOCTOR_NAME"].ToString().Trim() == "")
            {
                App.Msg("住院医师为空,不能打印！");
                return;
            }
            if (dr["ZR_NURSE_NAME"].ToString().Trim() == "-" || dr["ZR_NURSE_NAME"].ToString().Trim() == "")
            {
                App.Msg("责任护士为空,不能打印！");
                return;
            }
            if (dr["Q_DOCTOR_NAME"].ToString().Trim() == "-" || dr["Q_DOCTOR_NAME"].ToString().Trim() == "")
            {
                App.Msg("质控医师为空,不能打印！");
                return;
            }
            if (dr["Q_NURSE_NAME"].ToString().Trim() == "-" || dr["Q_NURSE_NAME"].ToString().Trim() == "")
            {
                App.Msg("质控护士为空,不能打印！");
                return;
            }
            if (dr["QUALITY"].ToString().Trim() == "-" || dr["QUALITY"].ToString().Trim() == "")
            {
                App.Msg("病案质量为空,不能打印！");
                return;
            }
            #endregion

            // 获取病案首页的一些杂项
            DataTable Temp = GetTemp();
            dr = Temp.Rows[0];
            #region 杂项表的必填项控制

            if (dr["BLFX"].ToString().Trim() == "-" || dr["BLFX"].ToString().Trim() == "")
            {
                App.Msg("病例分型为空,不能打印！");
                return;
            }
            if (dr["DBZGL"].ToString().Trim() == "-" || dr["DBZGL"].ToString().Trim() == "")
            {
                App.Msg("单病种管理为空,不能打印！");
                return;
            }
            if (dr["LCLJGL"].ToString().Trim() == "-" || dr["LCLJGL"].ToString().Trim() == "")
            {
                App.Msg("实施临床路径管理为空,不能打印！");
                return;
            }
            if (dr["SSDRGS"].ToString().Trim() == "-" || dr["SSDRGS"].ToString().Trim() == "")
            {
                App.Msg("实施DRGs管理为空,不能打印！");
                return;
            }
            if (dr["KSSSY"].ToString().Trim() == "-" || dr["KSSSY"].ToString().Trim() == "")
            {
                App.Msg("抗生素使用为空,不能打印！");
                return;
            }
            if (dr["XJPYBBSJ"].ToString().Trim() == "-" || dr["XJPYBBSJ"].ToString().Trim() == "")
            {
                App.Msg("细菌培养标本送检为空,不能打印！");
                return;
            }
            //if (dr["FDCRB"].ToString().Trim() == "-" || dr["FDCRB"].ToString().Trim() == "")
            //{
            //    App.Msg("法定传染病为空,不能打印！");
            //    return;
            //}
            if (dr["OUTHOSPITAL"].ToString().Trim() == "2" && (dr["TURNTOHOSPITAL1"].ToString().Trim() == "" || dr["TURNTOHOSPITAL1"].ToString().Trim() == "-"))
            {
                App.Msg("离院方式为医嘱转院时，接收医疗机构名称为空,不能打印！");
                return;
            }
            if (dr["OUTHOSPITAL"].ToString().Trim() == "3" && (dr["TURNTOHOSPITAL2"].ToString().Trim() == "" || dr["TURNTOHOSPITAL2"].ToString().Trim() == "-"))
            {
                App.Msg("离院方式为医嘱转社区时，接收医疗机构名称为空,不能打印！");
                return;
            }
            if (dr["INAGAIN"].ToString().Trim() == "2" && (dr["PURPOSE"].ToString().Trim() == "" || dr["PURPOSE"].ToString()=="-"))
            {
                App.Msg("有出院31天内再住院计划时，目的为空,不能打印！");
                return;
            }

            //if (dr["MZYCY"].ToString() == "-")
            //{
            //    MessageBox.Show("门诊与出院必须填写!");
            //    return;
            //}
            //if (dr["RYYCY"].ToString() == "-")
            //{
            //    MessageBox.Show("入院与出院必须填写!");
            //    return;
            //}
            //if (dr["SQYSH"].ToString() == "-")
            //{
            //    MessageBox.Show("术前与术后必须填写!");
            //    return;
            //}
            //if (dr["LCYBL"].ToString() == "-")
            //{
            //    MessageBox.Show("临床与病理必须填写!");
            //    return;
            //}
            //if (dr["FSYBL"].ToString() == "-")
            //{
            //    MessageBox.Show("放射与病理必须填写!");
            //    return;
            //}
            //if (dr["LCLJGL"].ToString() == "-")
            //{
            //    MessageBox.Show("临床路径管理必须填写!");
            //    return;
            //}
            //if (dr["QJQK_QJ"].ToString() == "-" || dr["QJQK_CG"].ToString() == "-")
            //{
            //    MessageBox.Show("抢救次数必须填写!");
            //    return;
            //}
            #endregion

            DataTable cost = GetCost();

            // 构造 DataSet
            DataSet ds = new DataSet();
            ds.Tables.Add(CoverInfo);
            ds.Tables.Add(Diagnose);
            ds.Tables.Add(Operation);
            ds.Tables.Add(Quality);
            ds.Tables.Add(Temp);
            ds.Tables.Add(cost);
            frmFirstCases_Print frmPrint = new frmFirstCases_Print(ds);
            frmPrint.Show();
        }

        public DataTable GetCost()
        {
            DataTable dt = new DataTable();

            #region 构造列
            DataColumn dc = new DataColumn("Total_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Seft_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Service_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Operator_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Nurse_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Other_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Blzd_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Syszd_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Yxxzd_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Zdxm_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("fssxm_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Wlzl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Sszl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Mz_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Shs_Cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Kjyw_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Kf_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Zxzl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Xy_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Zchy_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Zcy_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Xue_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("bdbl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Qdbl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Nxyz_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Xbyzl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("jcyycl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Zlyycl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Ssyycl_cost");
            dt.Columns.Add(dc);
            dc = new DataColumn("Ol_cost");
            dt.Columns.Add(dc);
            #endregion
            #region 填充值
            DataRow row = dt.NewRow();
            //总费用
            row["Total_cost"] = txttotal_cost.Text.Trim();
            //自付费用
            row["Seft_cost"] = txtSeft_Cost.Text.Trim();
            //服务费
            row["Service_cost"] = txtService_Cost.Text.Trim();
            //操作费
            row["Operator_cost"] = txtOperator_Cost.Text.Trim();
            //护理费
            row["Nurse_cost"] = txtNurse_Cost.Text.Trim();
            //其他费
            row["Other_cost"] = txtOthser_Cost.Text.Trim();
            //病理诊断费
            row["Blzd_cost"] = txtBlzd_Cost.Text.Trim();
            //实验室诊断费
            row["Syszd_cost"] = txtsyszd_Cost.Text.Trim();
            //影像学诊断费
            row["Yxxzd_cost"] = txtYxxzd_Cost.Text.Trim();
            //临床诊断项目费
            row["Zdxm_cost"] = txtZdxm_Cost.Text.Trim();
            //抗菌药物费用
            row["Kjyw_cost"] = txtKjyw_Cost.Text.Trim();
            //非手术治疗费
            row["fssxm_cost"] = txtFshszl_Cost.Text.Trim();
            //临床物理治疗费
            row["Wlzl_cost"] = txtWlzl_Cost.Text.Trim();
            //手术治疗费
            row["Sszl_cost"] = txtShszl_Cost.Text.Trim();
            //麻醉费
            row["Mz_cost"] = txtMz_Cost.Text.Trim();
            //手术费
            row["Shs_Cost"] = txtShs_Cost.Text.Trim();
            //康复费
            row["Kf_cost"] = txtKf_Cost.Text.Trim();
            //中医治疗肺
            row["Zxzl_cost"] = txtZyzl_Cost.Text.Trim();
            //西药费
            row["Xy_cost"] = txtXy_Cost.Text.Trim();
            //中成药费
            row["Zchy_cost"] = txtZchy_Cost.Text.Trim();
            //中草药费
            row["Zcy_cost"] = txtZcy_Cost.Text.Trim();
            //血费
            row["Xue_cost"] = txtXue_Cost.Text.Trim();
            //白蛋白类制品费
            row["bdbl_cost"] = txtBdbl_Cost.Text.Trim();
            //球蛋白类制品费
            row["Qdbl_cost"] = txtQdbl_Cost.Text.Trim();
            //凝血因子类制品费
            row["Nxyz_cost"] = txtNxyzl_Cost.Text.Trim();
            //细胞因子类制品费
            row["Xbyzl_cost"] = txtXbyzl_Cost.Text.Trim();
            //检查一次性医用材料费
            row["jcyycl_cost"] = txtJccl_Cost.Text.Trim();
            //手术一次性医用材料费
            row["Ssyycl_cost"] = txtShscl_Cost.Text.Trim();
            //治疗一次性医用材料费
            row["Zlyycl_cost"] = txtZlcl_Cost.Text.Trim();
            //其他类费用
            row["Ol_cost"] = txtQt_Cost.Text.Trim();
            dt.Rows.Add(row);
            #endregion
            return dt;
        }
        /// <summary>
        /// 读取费用
        /// </summary>
        private void InitCost()
        {
            #region HIS数据库中读取

            if (ds_cost != null)
            {
                //总费用
                txttotal_cost.Text = ds_cost.Tables["ZYFYHJ"].Rows[0][0].ToString();
                //自付费用 
                txtSeft_Cost.Text = ds_cost.Tables["ZYZFJE"].Rows[0][0].ToString();
                //服务费
                txtService_Cost.Text = ds_cost.Tables["YBYLFWF"].Rows[0][0].ToString();
                //操作费
                txtOperator_Cost.Text = ds_cost.Tables["YBZLCZF"].Rows[0][0].ToString();
                //护理费
                txtNurse_Cost.Text = ds_cost.Tables["HLF"].Rows[0][0].ToString();
                //其他费
                txtOthser_Cost.Text = ds_cost.Tables["QTFY"].Rows[0][0].ToString();
                //病理诊断费
                txtBlzd_Cost.Text = ds_cost.Tables["BLF"].Rows[0][0].ToString();
                //实验室诊断费
                txtsyszd_Cost.Text = ds_cost.Tables["QTFY"].Rows[0][0].ToString();
                //影像学诊断费
                txtYxxzd_Cost.Text = ds_cost.Tables["YXXZDF"].Rows[0][0].ToString();
                //临床诊断项目费
                txtZdxm_Cost.Text = ds_cost.Tables["LCZDXMF"].Rows[0][0].ToString();

                //抗菌药物费用
                txtKjyw_Cost.Text = ds_cost.Tables["KJYWFY"].Rows[0][0].ToString();
                //非手术治疗费
                txtFshszl_Cost.Text = ds_cost.Tables["FSSZLXMF"].Rows[0][0].ToString();
                //临床物理治疗费
                txtWlzl_Cost.Text = ds_cost.Tables["QTFY"].Rows[0][0].ToString();//无
                //手术治疗费
                txtShszl_Cost.Text = ds_cost.Tables["SSZLF"].Rows[0][0].ToString();
                //麻醉费
                txtMz_Cost.Text = ds_cost.Tables["MZF"].Rows[0][0].ToString();
                //手术费
                txtShs_Cost.Text = ds_cost.Tables["SSF"].Rows[0][0].ToString();
                //康复费
                txtKf_Cost.Text = ds_cost.Tables["KFF"].Rows[0][0].ToString();
                //中医治疗肺
                txtZyzl_Cost.Text = ds_cost.Tables["ZYZLF"].Rows[0][0].ToString();
                //西药费
                txtXy_Cost.Text = ds_cost.Tables["XYF"].Rows[0][0].ToString();
                //中成药费
                txtZchy_Cost.Text = ds_cost.Tables["ZCY"].Rows[0][0].ToString();
                //中草药费
                txtZcy_Cost.Text = ds_cost.Tables["ZCYF"].Rows[0][0].ToString();
                //血费
                txtXue_Cost.Text = ds_cost.Tables["SXF"].Rows[0][0].ToString();
                //白蛋白类制品费
                txtBdbl_Cost.Text = ds_cost.Tables["DBBLZPF"].Rows[0][0].ToString();
                //球蛋白类制品费
                txtQdbl_Cost.Text = ds_cost.Tables["QDBLZPF"].Rows[0][0].ToString();
                //凝血因子类制品费
                txtNxyzl_Cost.Text = ds_cost.Tables["NXYZLZPF"].Rows[0][0].ToString();
                //细胞因子类制品费
                txtXbyzl_Cost.Text = ds_cost.Tables["XBYZLZPF"].Rows[0][0].ToString();
                //检查一次性医用材料费
                txtJccl_Cost.Text = ds_cost.Tables["JCYYCXYYCL"].Rows[0][0].ToString();
                //手术一次性医用材料费
                txtShscl_Cost.Text = ds_cost.Tables["SSYYCXYYCL"].Rows[0][0].ToString();
                //治疗一次性医用材料费
                txtZlcl_Cost.Text = ds_cost.Tables["ZLYYCXYYCL"].Rows[0][0].ToString();
                //其他类费用
                txtQt_Cost.Text = ds_cost.Tables["QTF"].Rows[0][0].ToString();
            }

            #endregion

            #region 我方数据库读取
            DataSet ds = App.GetDataSet("select * from convert_cost where PATIENT_ID='" + inPatientInfo.Id + "'");
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                if (row["Total_cost"].ToString().Trim() != "")
                {   //总费用
                    txttotal_cost.Text = row["Total_cost"].ToString();
                }
                if (row["Seft_cost"].ToString().Trim() != "")
                {
                    //自付费用
                    txtSeft_Cost.Text = row["Seft_cost"].ToString();
                }
                if (row["Service_cost"].ToString().Trim() != "")
                {
                    //服务费
                    txtService_Cost.Text = row["Service_cost"].ToString();
                }
                if (row["Operator_cost"].ToString().Trim() != "")
                {
                    //操作费
                    txtOperator_Cost.Text = row["Operator_cost"].ToString();
                }
                if (row["Nurse_cost"].ToString().Trim() != "")
                {
                    //护理费
                    txtNurse_Cost.Text = row["Nurse_cost"].ToString();
                }
                if (row["Other_cost"].ToString().Trim() != "")
                {
                    //其他费
                    txtOthser_Cost.Text = row["Other_cost"].ToString();
                }
                if (row["Total_cost"].ToString().Trim() != "")
                {
                    //病理诊断费
                    txtBlzd_Cost.Text = row["Blzd_cost"].ToString();
                }
                if (row["Syszd_cost"].ToString().Trim() != "")
                {
                    //实验室诊断费
                    txtsyszd_Cost.Text = row["Syszd_cost"].ToString();
                }
                if (row["Yxxzd_cost"].ToString().Trim() != "")
                {
                    //影像学诊断费
                    txtYxxzd_Cost.Text = row["Yxxzd_cost"].ToString();
                }
                if (row["Zdxm_cost"].ToString().Trim() != "")
                {
                    //临床诊断项目费
                    txtZdxm_Cost.Text = row["Zdxm_cost"].ToString();
                }
                if (row["Kjyw_cost"].ToString().Trim() != "")
                {
                    //抗菌药物费用
                    txtKjyw_Cost.Text = row["Kjyw_cost"].ToString();
                }
                if (row["fssxm_cost"].ToString().Trim() != "")
                {
                    //非手术治疗费
                    txtFshszl_Cost.Text = row["fssxm_cost"].ToString();
                }
                if (row["Wlzl_cost"].ToString().Trim() != "")
                {
                    //临床物理治疗费
                    txtWlzl_Cost.Text = row["Wlzl_cost"].ToString();
                }
                if (row["Sszl_cost"].ToString().Trim() != "")
                {
                    //手术治疗费
                    txtShszl_Cost.Text = row["Sszl_cost"].ToString();
                }
                if (row["Mz_cost"].ToString().Trim() != "")
                {
                    //麻醉费
                    txtMz_Cost.Text = row["Mz_cost"].ToString();
                }
                if (row["Shs_Cost"].ToString().Trim() != "")
                {
                    //手术费
                    txtShs_Cost.Text = row["Shs_Cost"].ToString();
                }
                if (row["Kf_cost"].ToString().Trim() != "")
                {
                    //康复费
                    txtKf_Cost.Text = row["Kf_cost"].ToString();
                }
                if (row["Zxzl_cost"].ToString().Trim() != "")
                {
                    //中医治疗肺
                    txtZyzl_Cost.Text = row["Zxzl_cost"].ToString();
                }
                if (row["Xy_cost"].ToString().Trim() != "")
                {
                    //西药费
                    txtXy_Cost.Text = row["Xy_cost"].ToString();
                }
                if (row["Zchy_cost"].ToString().Trim() != "")
                {
                    //中成药费
                    txtZchy_Cost.Text = row["Zchy_cost"].ToString();
                }
                if (row["Zcy_cost"].ToString().Trim() != "")
                {
                    //中草药费
                    txtZcy_Cost.Text = row["Zcy_cost"].ToString();
                }
                if (row["Xue_cost"].ToString().Trim() != "")
                {
                    //血费
                    txtXue_Cost.Text = row["Xue_cost"].ToString();
                }
                if (row["bdbl_cost"].ToString().Trim() != "")
                {
                    //白蛋白类制品费
                    txtBdbl_Cost.Text = row["bdbl_cost"].ToString();
                }
                if (row["Qdbl_cost"].ToString().Trim() != "")
                {
                    //球蛋白类制品费
                    txtQdbl_Cost.Text = row["Qdbl_cost"].ToString();
                }
                if (row["Nxyz_cost"].ToString().Trim() != "")
                {
                    //凝血因子类制品费
                    txtNxyzl_Cost.Text = row["Nxyz_cost"].ToString();
                }
                if (row["Xbyzl_cost"].ToString().Trim() != "")
                {
                    //细胞因子类制品费
                    txtXbyzl_Cost.Text = row["Xbyzl_cost"].ToString();
                }
                if (row["jcyycl_cost"].ToString().Trim() != "")
                {
                    //检查一次性医用材料费
                    txtJccl_Cost.Text = row["jcyycl_cost"].ToString();
                }
                if (row["Ssyycl_cost"].ToString().Trim() != "")
                {
                    //手术一次性医用材料费
                    txtShscl_Cost.Text = row["Ssyycl_cost"].ToString();
                }
                if (row["Zlyycl_cost"].ToString().Trim() != "")
                {
                    //治疗一次性医用材料费
                    txtZlcl_Cost.Text = row["Zlyycl_cost"].ToString();
                }
                if (row["Ol_cost"].ToString().Trim() != "")
                {
                    //其他类费用
                    txtQt_Cost.Text = row["Ol_cost"].ToString();
                }
            }
            #endregion
        }

        /// <summary>
        /// 获取病案首页的一些杂项
        /// </summary>
        /// <returns></returns>
        public DataTable GetTemp()
        {
            DataTable dt = new DataTable();

            #region 构造列
            DataColumn dc = new DataColumn("HASMEDICINESENSITIVE");
            dt.Columns.Add(dc);
            dc = new DataColumn("MEDICINESENSITIVE");
            dt.Columns.Add(dc);
            dc = new DataColumn("BLOOD_TYPE");
            dt.Columns.Add(dc);
            dc = new DataColumn("RH");
            dt.Columns.Add(dc);
            dc = new DataColumn("CHECKCORPSE");
            dt.Columns.Add(dc);
            dc = new DataColumn("OUTHOSPITAL");
            dt.Columns.Add(dc);
            dc = new DataColumn("TURNTOHOSPITAL1");
            dt.Columns.Add(dc);
            dc = new DataColumn("TURNTOHOSPITAL2");
            dt.Columns.Add(dc);
            dc = new DataColumn("INAGAIN");
            dt.Columns.Add(dc);
            dc = new DataColumn("PURPOSE");
            dt.Columns.Add(dc);
            dc = new DataColumn("BEFOREIN_DAY");
            dt.Columns.Add(dc);
            dc = new DataColumn("BEFOREIN_HOUR");
            dt.Columns.Add(dc);
            dc = new DataColumn("BEFOREIN_MINUTE");
            dt.Columns.Add(dc);
            dc = new DataColumn("AFTERIN_DAY");
            dt.Columns.Add(dc);
            dc = new DataColumn("AFTERIN_HOUR");
            dt.Columns.Add(dc);
            dc = new DataColumn("AFTERIN_MINUTE");
            dt.Columns.Add(dc);
            dc = new DataColumn("BLFX");
            dt.Columns.Add(dc);
            dc = new DataColumn("SSZZJH");
            dt.Columns.Add(dc);
            dc = new DataColumn("JH_DAY");
            dt.Columns.Add(dc);
            dc = new DataColumn("JH_HOUR");
            dt.Columns.Add(dc);
            dc = new DataColumn("DBZGL");
            dt.Columns.Add(dc);
            dc = new DataColumn("LCLJGL");
            dt.Columns.Add(dc);
            dc = new DataColumn("SSDRGS");
            dt.Columns.Add(dc);
            dc = new DataColumn("KSSSY");
            dt.Columns.Add(dc);
            dc = new DataColumn("XJPYBBSJ");
            dt.Columns.Add(dc);
            dc = new DataColumn("FDCRB");
            dt.Columns.Add(dc);

            dc = new DataColumn("ZLFQ_T");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZLFQ_N");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZLFQ_M1");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZLFQ_M2");
            dt.Columns.Add(dc);
            dc = new DataColumn("BABY_APGAR");
            dt.Columns.Add(dc);

            #endregion

            #region 填充值
            DataRow dr = dt.NewRow();
            string sql = string.Format(@"select * from COVER_TEMP where patient_id='{0}'", this.inPatientInfo.Id);
            DataTable dtTemp = App.GetDataSet(sql).Tables[0];
            if (dtTemp.Rows.Count != 0)
            {
                dr["MEDICINESENSITIVE"] = dtTemp.Rows[0]["MEDICINESENSITIVE"];
                if (dr["MEDICINESENSITIVE"] != null && dr["MEDICINESENSITIVE"].ToString().Length != 0)
                {
                    dr["HASMEDICINESENSITIVE"] = 2;
                }
                else
                {
                    dr["HASMEDICINESENSITIVE"] = 1;
                }

                dr["BLOOD_TYPE"] = dtTemp.Rows[0]["BLOOD_TYPE"];
                switch (dr["BLOOD_TYPE"].ToString())
                {
                    case "A":
                        dr["BLOOD_TYPE"] = 1;
                        break;
                    case "B":
                        dr["BLOOD_TYPE"] = 2;
                        break;
                    case "O":
                        dr["BLOOD_TYPE"] = 3;
                        break;
                    case "AB":
                        dr["BLOOD_TYPE"] = 4;
                        break;
                    case "不详":
                        dr["BLOOD_TYPE"] = 5;
                        break;
                    case "未查":
                        dr["BLOOD_TYPE"] = 6;
                        break;
                }

                dr["RH"] = dtTemp.Rows[0]["RH"];
                switch (dr["RH"].ToString())
                {
                    case "阴性":
                        dr["RH"] = 1;
                        break;
                    case "阳性":
                        dr["RH"] = 2;
                        break;
                    case "不详":
                        dr["RH"] = 3;
                        break;
                    case "未查":
                        dr["RH"] = 4;
                        break;
                }

                dr["CHECKCORPSE"] = dtTemp.Rows[0]["CHECKCORPSE"];
                if (dr["CHECKCORPSE"].ToString() == "是")
                {
                    dr["CHECKCORPSE"] = 1;
                }
                else if (dr["CHECKCORPSE"].ToString() == "否")
                {
                    dr["CHECKCORPSE"] = 2;
                }

                dr["OUTHOSPITAL"] = dtTemp.Rows[0]["OUTHOSPITAL"];
                if (dr["OUTHOSPITAL"].ToString() == "医嘱离院")
                {
                    dr["OUTHOSPITAL"] = 1;
                }
                if (dr["OUTHOSPITAL"].ToString().Contains("医嘱转院"))
                {
                    dr["OUTHOSPITAL"] = 2;
                    dr["TURNTOHOSPITAL1"] = dtTemp.Rows[0]["TURNTOHOSPITAL"];
                }
                if (dr["OUTHOSPITAL"].ToString().Contains("医嘱转社区"))
                {
                    dr["OUTHOSPITAL"] = 3;
                    dr["TURNTOHOSPITAL2"] = dtTemp.Rows[0]["TURNTOHOSPITAL"];
                }
                if (dr["OUTHOSPITAL"].ToString() == "非医嘱离院")
                {
                    dr["OUTHOSPITAL"] = 4;
                }
                if (dr["OUTHOSPITAL"].ToString() == "死亡")
                {
                    dr["OUTHOSPITAL"] = 5;
                }
                if (dr["OUTHOSPITAL"].ToString() == "其他")
                {
                    dr["OUTHOSPITAL"] = 9;
                }

                dr["INAGAIN"] = dtTemp.Rows[0]["INAGAIN"];
                if (dr["INAGAIN"].ToString() == "无")
                {
                    dr["INAGAIN"] = 1;
                }
                else
                {
                    dr["INAGAIN"] = 2;
                }

                dr["PURPOSE"] = dtTemp.Rows[0]["PURPOSE"];
                dr["BEFOREIN_DAY"] = dtTemp.Rows[0]["BEFOREIN_DAY"];
                if (dr["BEFOREIN_DAY"] == DBNull.Value || dr["BEFOREIN_DAY"].ToString().Trim().Length == 0)
                {
                    dr["BEFOREIN_DAY"] = "0";
                }
                dr["BEFOREIN_HOUR"] = dtTemp.Rows[0]["BEFOREIN_HOUR"];
                if (dr["BEFOREIN_HOUR"] == DBNull.Value || dr["BEFOREIN_HOUR"].ToString().Trim().Length == 0)
                {
                    dr["BEFOREIN_HOUR"] = "0";
                }
                dr["BEFOREIN_MINUTE"] = dtTemp.Rows[0]["BEFOREIN_MINUTE"];
                if (dr["BEFOREIN_MINUTE"] == DBNull.Value || dr["BEFOREIN_MINUTE"].ToString().Trim().Length == 0)
                {
                    dr["BEFOREIN_MINUTE"] = "0";
                }
                dr["AFTERIN_DAY"] = dtTemp.Rows[0]["AFTERIN_DAY"];
                if (dr["AFTERIN_DAY"] == DBNull.Value || dr["AFTERIN_DAY"].ToString().Trim().Length == 0)
                {
                    dr["AFTERIN_DAY"] = "0";
                }
                dr["AFTERIN_HOUR"] = dtTemp.Rows[0]["AFTERIN_HOUR"];
                if (dr["AFTERIN_HOUR"] == DBNull.Value || dr["AFTERIN_HOUR"].ToString().Trim().Length == 0)
                {
                    dr["AFTERIN_HOUR"] = "0";
                }
                dr["AFTERIN_MINUTE"] = dtTemp.Rows[0]["AFTERIN_MINUTE"];
                if (dr["AFTERIN_MINUTE"] == DBNull.Value || dr["AFTERIN_MINUTE"].ToString().Trim().Length == 0)
                {
                    dr["AFTERIN_MINUTE"] = "0";
                }

                dr["BLFX"] = dtTemp.Rows[0]["BLFX"];
                dr["SSZZJH"] = dtTemp.Rows[0]["SSZZJH"];
                dr["JH_DAY"] = dtTemp.Rows[0]["JH_DAY"];
                dr["JH_HOUR"] = dtTemp.Rows[0]["JH_HOUR"];
                if (dr["SSZZJH"] == DBNull.Value || dr["SSZZJH"].ToString().Trim().Length == 0 || dr["SSZZJH"].ToString() == "1")
                {
                    dr["JH_DAY"] = "0";
                    dr["JH_HOUR"] = "0";
                }
                dr["DBZGL"] = dtTemp.Rows[0]["DBZGL"];
                dr["LCLJGL"] = dtTemp.Rows[0]["LCLJGL"];
                dr["SSDRGS"] = dtTemp.Rows[0]["SSDRGS"];
                dr["KSSSY"] = dtTemp.Rows[0]["KSSSY"];
                dr["XJPYBBSJ"] = dtTemp.Rows[0]["XJPYBBSJ"];
                dr["FDCRB"] = dtTemp.Rows[0]["FDCRB"].ToString() == "0" ? "-" : dtTemp.Rows[0]["FDCRB"];
                string T = dtTemp.Rows[0]["ZLFQ_T"].ToString();
                string N = dtTemp.Rows[0]["ZLFQ_N"].ToString();
                string M1 = dtTemp.Rows[0]["ZLFQ_M1"].ToString();
                string M2 = dtTemp.Rows[0]["ZLFQ_M2"].ToString();
                dr["ZLFQ_T"] = T;
                dr["ZLFQ_N"] = N;
                dr["ZLFQ_M1"] = M1;
                dr["ZLFQ_M2"] = M2;
                dr["BABY_APGAR"] = dtTemp.Rows[0]["BABY_APGAR"];
                //,,,,, ,,,
                //,,,,,,

            }
            #endregion

            dt.Rows.Add(dr);
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "MEDICINESENSITIVE")
                    continue;
                if (dt.Rows[0][col] == null || dt.Rows[0][col].ToString().Length == 0)
                    //||(dt.Rows[0][col].ToString() == "0" && col.ColumnName != "ZLFQ_T" && col.ColumnName != "ZLFQ_N" &&
                    //col.ColumnName != "ZLFQ_M1" && col.ColumnName != "ZLFQ_M2" && col.ColumnName != "BABY_APGAR"))
                {//TNM选择的数字是什么，打印就显示那个数字。
                    dt.Rows[0][col] = "-";
                }

            }
            return dt;
        }

        /// <summary>
        /// 获取病案质量
        /// </summary>
        /// <returns></returns>
        public DataTable GetQuality()
        {
            DataTable dt = new DataTable();

            #region 构造列
            DataColumn dc = new DataColumn("SECTION_HEAD");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZR_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZZ_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZY_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("ZR_NURSE_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("JX_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("SX_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("CODER_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("Q_DOCTOR_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("Q_NURSE_NAME");
            dt.Columns.Add(dc);
            dc = new DataColumn("QUALITY");
            dt.Columns.Add(dc);
            dc = new DataColumn("Q_DATE_YEAR");
            dt.Columns.Add(dc);
            dc = new DataColumn("Q_DATE_MONTH");
            dt.Columns.Add(dc);
            dc = new DataColumn("Q_DATE_DAY");
            dt.Columns.Add(dc);
            #endregion

            #region 填充值
            DataRow dr = dt.NewRow();
            string sql = string.Format(@"select * from cover_quality where patient_id='{0}'", this.inPatientInfo.Id);
            DataTable dtTemp = App.GetDataSet(sql).Tables[0];
            if (dtTemp.Rows.Count != 0)
            {
                dr["SECTION_HEAD"] = dtTemp.Rows[0]["SECTION_HEAD"];
                dr["ZR_DOCTOR_NAME"] = dtTemp.Rows[0]["ZR_DOCTOR_NAME"];
                dr["ZZ_DOCTOR_NAME"] = dtTemp.Rows[0]["ZZ_DOCTOR_NAME"];
                dr["ZY_DOCTOR_NAME"] = dtTemp.Rows[0]["ZY_DOCTOR_NAME"];
                dr["ZR_NURSE_NAME"] = dtTemp.Rows[0]["ZR_NURSE_NAME"];
                dr["JX_DOCTOR_NAME"] = dtTemp.Rows[0]["JX_DOCTOR_NAME"];
                dr["SX_DOCTOR_NAME"] = dtTemp.Rows[0]["SX_DOCTOR_NAME"];
                dr["CODER_NAME"] = dtTemp.Rows[0]["CODER_NAME"];
                dr["Q_DOCTOR_NAME"] = dtTemp.Rows[0]["Q_DOCTOR_NAME"];
                dr["Q_NURSE_NAME"] = dtTemp.Rows[0]["Q_NURSE_NAME"];
                dr["QUALITY"] = ChangeQuality(dtTemp.Rows[0]["QUALITY"]);

                try
                {
                    DateTime dtTime = Convert.ToDateTime(dtTemp.Rows[0]["Q_DATE"].ToString());
                    dr["Q_DATE_YEAR"] = dtTime.Year;
                    dr["Q_DATE_MONTH"] = dtTime.Month;
                    dr["Q_DATE_DAY"] = dtTime.Day;
                }
                catch
                {
                    dr["Q_DATE_YEAR"] = "";
                    dr["Q_DATE_MONTH"] = "";
                    dr["Q_DATE_DAY"] = "";
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dr[i] == null || dr[i].ToString().Length == 0 ||
                    dr[i].ToString() == "0")
                    {
                        try
                        {
                            dr[i] = "";//"-"
                        }
                        catch
                        { }
                    }
                }

            }
            #endregion

            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 获取手术信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperation()
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;

            #region 构造列
            for (int i = 0; i < 11; i++)
            {
                dc = new DataColumn("OperCode" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperDate" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperLevel" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperName" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperDoctor" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperAssistant1_" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("OperAssistant2_" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("ToHealLevel" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("AnesthesiaWay" + (i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn("AnesthesiaDoctor" + (i + 1));
                dt.Columns.Add(dc);
            }
            #endregion

            #region 填充值
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Rows[0][i] = ""; // 默认全部是 "-"
            }

            string sql = string.Format(@"select * from cover_operation where patient_id='{0}'", this.inPatientInfo.Id);
            DataTable dtTemp = App.GetDataSet(sql).Tables[0];
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                string str3 = dtTemp.Rows[i]["OPER_DATE"].ToString();
                dr["OperCode" + (i + 1)] = dtTemp.Rows[i]["OPER_CODE"];
                dr["OperDate" + (i + 1)] = dtTemp.Rows[i]["OPER_DATE"];
                dr["OperLevel" + (i + 1)] = dtTemp.Rows[i]["OPER_LEVEL"];
                dr["OperName" + (i + 1)] = dtTemp.Rows[i]["OPER_NAME"];
                dr["OperDoctor" + (i + 1)] = dtTemp.Rows[i]["OPERATOR"];
                dr["OperAssistant1_" + (i + 1)] = dtTemp.Rows[i]["OPER_ASSIST1"];
                dr["OperAssistant2_" + (i + 1)] = dtTemp.Rows[i]["OPER_ASSIST2"];
                dr["ToHealLevel" + (i + 1)] = dtTemp.Rows[i]["CLOSE_LEVEL"];
                dr["AnesthesiaWay" + (i + 1)] = dtTemp.Rows[i]["ANAES_METHOD"];
                dr["AnesthesiaDoctor" + (i + 1)] = dtTemp.Rows[i]["ANAESTHETIST"];
            }

            string[] arrs = null;
            string str = string.Empty;
            SplitStrFirst("OperName", 9, ref dt, arrs, "", 1, true);
            SplitStrSecend("AnesthesiaWay", 7, ref dt, str, "", 1, true);
            #endregion

            return dt;
        }

        /// <summary>
        /// 获取诊断信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetCoverDiagnose()
        {
            DataTable dt = new DataTable();

            #region 构造列
            DataColumn dc = new DataColumn("Diagnose_E");// 门急诊
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_E_Code");
            dt.Columns.Add(dc);
            dc=new DataColumn ("Diagnose_E_C");
            dt.Columns.Add(dc);

            dc = new DataColumn("Diagnose_S"); // 损伤中毒
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_S_Code");
            dt.Columns.Add(dc);

            dc = new DataColumn("Diagnose_P"); // 病理
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_P_Code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_P_Number");
            dt.Columns.Add(dc);

            dc = new DataColumn("Diagnose_M"); // 主要
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_M_Code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_M_Condition");
            dt.Columns.Add(dc);
            dc = new DataColumn("TURN_TO");
            dt.Columns.Add(dc);
            dc = new DataColumn("Diagnose_M_C");
            dt.Columns.Add(dc);

            // 18个其他诊断
            for (int i = 0; i < 27; i++)
            {
                dc = new DataColumn(string.Format("Diagnose_O_{0}", i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn(string.Format("Diagnose_O_Code_{0}", i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn(string.Format("Diagnose_O_Condition_{0}", i + 1));
                dt.Columns.Add(dc);
                dc = new DataColumn(string.Format("Diagnose_O_C_{0}", i + 1));
            }
            #endregion

            #region 填充值
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            string sql = string.Format(@"select * from cover_diagnose where patient_id='{0}'", this.inPatientInfo.Id);
            DataTable dtTemp = App.GetDataSet(sql).Tables[0];
            DataRow[] drs = dtTemp.Select("type='E'");
            if (drs.Length != 0)
            {
                dr["Diagnose_E"] = drs[0]["NAME"];
                dr["Diagnose_E_Code"] = drs[0]["ICD10CODE"];
                dr["Diagnose_E_C"] = drs[0]["is_chinese"];
            }
            else
            {
                dr["Diagnose_E"] = "-";
                dr["Diagnose_E_Code"] = "-";
            }

            drs = dtTemp.Select("type='S'");
            if (drs.Length != 0)
            {
                dr["Diagnose_S"] = drs[0]["NAME"];
                dr["Diagnose_S_Code"] = drs[0]["ICD10CODE"];
            }
            else
            {
                dr["Diagnose_S"] = "-";
                dr["Diagnose_S_Code"] = "-";
            }

            drs = dtTemp.Select("type='P'");
            if (drs.Length != 0)
            {
                dr["Diagnose_P"] = drs[0]["NAME"];
                dr["Diagnose_P_Code"] = drs[0]["ICD10CODE"];
                dr["Diagnose_P_Number"] = drs[0]["PNUMBER"];
            }
            else
            {
                dr["Diagnose_P"] = "-";
                dr["Diagnose_P_Code"] = "-";
                dr["Diagnose_P_Number"] = "-";
            }
            bool iSWritedCDiag = false;
            drs = dtTemp.Select("type='M'");
            if (drs.Length != 0)
            {
                if (drs[0]["is_chinese"].ToString() == "1")
                {
                    dr["Diagnose_M"] = "中医诊断:" + TransferDiagnoseName(drs[0]["NAME"]);
                    iSWritedCDiag = true;
                }
                else
                {
                    dr["Diagnose_M"] = TransferDiagnoseName(drs[0]["NAME"]);
                }
                dr["Diagnose_M_Code"] = drs[0]["ICD10CODE"];
                dr["Diagnose_M_Condition"] = ChangeInCondition(drs[0]["INCONDITION"]);
                dr["Diagnose_M_C"] = drs[0]["is_chinese"];
                string sTemp = drs[0]["TURN_TO"].ToString();
                if (sTemp == "治愈")
                {
                    dr["TURN_TO"] = 1;
                }
                else if (sTemp == "好转")
                {
                    dr["TURN_TO"] = 2;
                }
                else if (sTemp == "未愈")
                {
                    dr["TURN_TO"] = 3;
                }
            }

            drs = dtTemp.Select("type='O' and is_chinese='1'");
            int clen = drs.Length;
            if (drs.Length != 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    if (!iSWritedCDiag)
                    {
                        dr[string.Format("Diagnose_O_{0}", i + 1)] = "中医诊断:" + TransferDiagnoseName(drs[i]["NAME"]);
                        iSWritedCDiag = true;
                    }
                    else
                    {
                        dr[string.Format("Diagnose_O_{0}", i + 1)] =TransferDiagnoseName(drs[i]["NAME"]);
                    }
                    dr[string.Format("Diagnose_O_Code_{0}", i + 1)] = drs[i]["ICD10CODE"];
                    dr[string.Format("Diagnose_O_Condition_{0}", i + 1)] = ChangeInCondition(drs[i]["INCONDITION"]);
                }
            }
            drs = dtTemp.Select("type='O' and (is_chinese<>'1' or is_chinese is null)");
            if (drs.Length != 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    if (iSWritedCDiag==true)
                    {
                        dr[string.Format("Diagnose_O_{0}", i + 1+clen)] = "西医诊断:" + TransferDiagnoseName(drs[i]["NAME"]);
                        iSWritedCDiag = false;
                    }
                    else
                    {
                        dr[string.Format("Diagnose_O_{0}", i + 1+clen)] = TransferDiagnoseName(drs[i]["NAME"]);
                    }
                    dr[string.Format("Diagnose_O_Code_{0}", i + 1+clen)] = drs[i]["ICD10CODE"];
                    dr[string.Format("Diagnose_O_Condition_{0}", i + 1+clen)] = ChangeInCondition(drs[i]["INCONDITION"]);
                }
            }
            #endregion

            //foreach (DataColumn col in dt.Columns)
            //{
            //    if (dt.Rows[0][col] != null && dt.Rows[0][col].ToString().Trim().Length == 0)
            //    {
            //        dt.Rows[0][col] = "";//"-"
            //    }
            //}
            return dt;
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetCoverInfo()
        {
            DataTable dt = new DataTable();
           
            #region 构造列
            DataColumn dc = new DataColumn("Pay_Manager");
            dt.Columns.Add(dc);
            dc = new DataColumn("Health_card_no");
            dt.Columns.Add(dc);
            dc = new DataColumn("InHospital_count");
            dt.Columns.Add(dc);
            dc = new DataColumn("PId");
            dt.Columns.Add(dc);
            dc = new DataColumn("Patient_Name");
            dt.Columns.Add(dc);
            dc = new DataColumn("Gender_Code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Marrige_State");
            dt.Columns.Add(dc);
            dc = new DataColumn("Birthday_Year");
            dt.Columns.Add(dc);
            dc = new DataColumn("Birthday_Month");
            dt.Columns.Add(dc);
            dc = new DataColumn("Birthday_Day");
            dt.Columns.Add(dc);
            dc = new DataColumn("Age");
            dt.Columns.Add(dc);
            dc = new DataColumn("Age_Month");
            dt.Columns.Add(dc);
            dc = new DataColumn("Age_Hours");
            dt.Columns.Add(dc);
            dc = new DataColumn("BornWeight");
            dt.Columns.Add(dc);
            dc = new DataColumn("Weight");
            dt.Columns.Add(dc);
            dc = new DataColumn("Born_Province");
            dt.Columns.Add(dc);
            dc = new DataColumn("Born_City");
            dt.Columns.Add(dc);
            dc = new DataColumn("Born_Xian");
            dt.Columns.Add(dc);
            dc = new DataColumn("Natiye_place_Province");
            dt.Columns.Add(dc);
            dc = new DataColumn("Natiye_place_City");
            dt.Columns.Add(dc);
            dc = new DataColumn("Folk_code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Cert_Id");
            dt.Columns.Add(dc);
            dc = new DataColumn("Career");
            dt.Columns.Add(dc);
            dc = new DataColumn("Now_address");
            dt.Columns.Add(dc);
            dc = new DataColumn("Now_addres_phone");
            dt.Columns.Add(dc);
            dc = new DataColumn("Now_addres_PostNo");
            dt.Columns.Add(dc);
            dc = new DataColumn("Home_address");
            dt.Columns.Add(dc);
            dc = new DataColumn("HomePostal_code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Office_address");
            dt.Columns.Add(dc);
            dc = new DataColumn("Office_phone");
            dt.Columns.Add(dc);
            dc = new DataColumn("OfficePos_code");
            dt.Columns.Add(dc);
            dc = new DataColumn("Country");
            dt.Columns.Add(dc);
            dc = new DataColumn("Relation_name");
            dt.Columns.Add(dc);
            dc = new DataColumn("Relation");
            dt.Columns.Add(dc);
            dc = new DataColumn("Relation_address");
            dt.Columns.Add(dc);
            dc = new DataColumn("Relation_phone");
            dt.Columns.Add(dc);
            dc = new DataColumn("IN_TIME_Year");
            dt.Columns.Add(dc);
            dc = new DataColumn("IN_TIME_Month");
            dt.Columns.Add(dc);
            dc = new DataColumn("IN_TIME_Day");
            dt.Columns.Add(dc);
            dc = new DataColumn("IN_TIME_Hour");
            dt.Columns.Add(dc);
            dc = new DataColumn("IN_TIME_Minute");
            dt.Columns.Add(dc);
            dc = new DataColumn("Section_Name");
            dt.Columns.Add(dc);
            dc = new DataColumn("Sick_Area_Name");
            dt.Columns.Add(dc);
            dc = new DataColumn("InHospital_Days");
            dt.Columns.Add(dc);
            dc = new DataColumn("In_Approach");
            dt.Columns.Add(dc);
            dc = new DataColumn("Die_time_Year");
            dt.Columns.Add(dc);
            dc = new DataColumn("Die_time_Month");
            dt.Columns.Add(dc);
            dc = new DataColumn("Die_time_Day");
            dt.Columns.Add(dc);
            dc = new DataColumn("Die_time_Hour");
            dt.Columns.Add(dc);
            dc = new DataColumn("Die_time_Minute");
            dt.Columns.Add(dc);
            dc = new DataColumn("insection_name");
            dt.Columns.Add(dc);
            dc = new DataColumn("In_Area_Name");
            dt.Columns.Add(dc);
            dc = new DataColumn("TurnSection");
            dt.Columns.Add(dc);
            dc = new DataColumn("Sick_Doc_No");
            dt.Columns.Add(dc);
            dc = new DataColumn("Home_Phone");
            dt.Columns.Add(dc);
            #endregion

            #region 填充值
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            //if (cbxPay.SelectedValue.ToString() == "6000")
            //{
            //    if (inPatientInfo.Property_flag == "1")
            //    {
            //        dr["Pay_Manager"] = "1";
            //    }
            //    else
            //    {
            //        dr["Pay_Manager"] = "2";
            //    }


            //}
            //else
            //{
            //    dr["Pay_Manager"] = "7";
            //}

            //dr["Sick_Doc_No"] = inPatientInfo.Sick_doc_no;
            dr["Sick_Doc_No"] = inPatientInfo.His_id;
            dr["Pay_Manager"] = inPatientInfo.Pay_Manager;
            //ConvertPay() ; ///GetPay_Manner(inPatientInfo.Pay_Manager);
            ///
            dr["Health_card_no"] = inPatientInfo.Health_card_no;
            dr["InHospital_count"] = inPatientInfo.InHospital_count;
            dr["PId"] = inPatientInfo.PId;
            dr["Patient_Name"] = inPatientInfo.Patient_Name;

            dr["Cert_Id"] = inPatientInfo.Medicare_no;

            if (inPatientInfo.Gender_Code == "0")
            {
                dr["Gender_Code"] = 1;
            }
            if (inPatientInfo.Gender_Code == "1")
            {
                dr["Gender_Code"] = 2;
            }
            var x="";
            if (inPatientInfo.Marrige_State == "未婚")
            {
                x = "1";
            }
            else if (inPatientInfo.Marrige_State == "已婚")
            {
                x = "2";
            }
            else if (inPatientInfo.Marrige_State == "丧偶")
            {
                x = "3";
            }
            else if (inPatientInfo.Marrige_State == "离婚")
            {
                x = "4";
            }
            else
            {
                x = "5";
            }
                dr["Marrige_State"] = x;
            DateTime birthDay;
            DateTime.TryParse(inPatientInfo.Birthday, out birthDay);
            string birth = birthDay.ToString("yyyy-MM-dd");
            //string sTemp = birth.Substring(0, birth.IndexOf(' '));
            string[] Birthday = birth.Split('-');
            dr["Birthday_Year"] = Birthday[0];
            dr["Birthday_Month"] = Birthday[1];
            dr["Birthday_Day"] = Birthday[2];

            // 年龄[暂时是首页自己填写]
            dr["Age"] = System.Text.RegularExpressions.Regex.Replace(txtAge1.Text, @"[^0-9]+", "");
            dr["Age_Month"] = txtAge2.Text;
            dr["Age_Hours"] = "";

            // 新生儿出生体重
            if (!string.IsNullOrEmpty(txtBornWeight.Text))
            {
                dr["BornWeight"] = txtBornWeight.Text;
            }

            if (!string.IsNullOrEmpty(txtBornInWeight.Text))
            {
                dr["Weight"] = txtBornInWeight.Text;
            }
            else
            {
                dr["Age"] = txtAge1.Text;
            }


            // 出生地
            if (inPatientInfo.Birth_place.ToString().Contains("|"))
            {
                string[] birthPlace = this.inPatientInfo.Birth_place.Split('|');
                if (birthPlace.Length >=3)
                {
                    dr["Born_Province"] = birthPlace[0]+ birthPlace[1]+ birthPlace[2];
                    dr["Born_City"] = birthPlace[1];
                    dr["Born_Xian"] = birthPlace[2];
                }
                else
                {
                    dr["Born_Province"] = "-";
                    dr["Born_City"] = "-";
                    dr["Born_Xian"] = "-";
                }
            }
            else // 不包含 ',' 按照省市县标准格式来处理
            {
                dr["Born_Province"] = "-";
                dr["Born_City"] = "-";
                dr["Born_Xian"] = "-";
            }

            // 籍贯

            if (inPatientInfo.Natiye_place.ToString().Contains("|"))
            {
        
                string[] birthPlace1 = this.inPatientInfo.Natiye_place.Split('|');
                if (birthPlace1.Length >=2)
                {
                    dr["Natiye_place_Province"] = birthPlace1[0]+ birthPlace1[1];
                    dr["Natiye_place_City"] = birthPlace1[1];
                }
                else
                {
                    dr["Natiye_place_Province"] = "-";
                    dr["Natiye_place_Province"] = "-";
                }
            }

            else
            {
  

                dr["Natiye_place_Province"] = "-" ;
                dr["Natiye_place_City"] =  "-" ;
            }


            // 民族由于接口扫描的原因,即使存盘也会被接口修改掉
            string sql = "select name from t_data_code t where id=" + inPatientInfo.Folk_code + " and type=71";
            string mingzu = string.Empty;
            try
            {
                mingzu = cbxNational.Text; //App.ReadSqlVal(sql, 0, "name");
            }
            catch
            {
            }
            dr["Folk_code"] = string.IsNullOrEmpty(mingzu) ? "" : mingzu;//不默认加载汉族

            if (inPatientInfo.Medicare_no.Length != 0)
            {
                dr["Cert_Id"] = inPatientInfo.Medicare_no;
            }

            // 职业
            if (inPatientInfo.Career.Length != 0)
            {
                if (cboCreer.Text.Length > 6)
                {
                    dr["Career"] = cboCreer.Text.Substring(0, 6);
                }
                else
                {
                    dr["Career"] = cboCreer.Text;
                }

                if (txtCreer.Text != "")
                {
                    dr["Career"] = txtCreer.Text;
                }

                //if (sCareer == "13")
                //{
                //    dr["Career"] = "集童";
                //}
                //else if (sCareer == "14")
                //{
                //    dr["Career"] = "散童";
                //}
                //else if (sCareer == "学生" || sCareer == "农民")
                //{
                //    dr["Career"] = sCareer;
                //}
                //else
                //{
                //    dr["Career"] = txtCreer.Text;
                //}
            }
            else
            {
                dr["Career"] = "-";
            }


            // 婚姻锁定为 "1"
            //dr["Marrige_State"] = inPatientInfo.Marrige_State;

            dr["Now_address"] = inPatientInfo.Now_address.Replace("|", "");
            dr["Now_addres_phone"] = inPatientInfo.Home_phone;
            dr["Now_addres_PostNo"] = inPatientInfo.Now_addres_postno;
            dr["Home_address"] = inPatientInfo.Home_address;
            dr["HomePostal_code"] = inPatientInfo.HomePostal_code;
            dr["Office_address"] = inPatientInfo.Office_address;
            dr["Office_phone"] = inPatientInfo.Office_phone;
            dr["OfficePos_code"] = inPatientInfo.OfficePos_code;
            dr["Country"] = cbxNationality.SelectedIndex == 0 ? "-" : cbxNationality.Text;
            dr["Relation_name"] = inPatientInfo.Relation_name;

            // 也是接口原因造成
            //dr["Relation"] = inPatientInfo.Religion;
            dr["Relation"] = cbxRelationship.Text;


            dr["Relation_address"] = inPatientInfo.Relation_address;
            dr["Relation_phone"] = inPatientInfo.Relation_phone;
            dr["IN_TIME_Year"] = inPatientInfo.In_Time.Year;
            dr["IN_TIME_Month"] = inPatientInfo.In_Time.Month;
            dr["IN_TIME_Day"] = inPatientInfo.In_Time.Day;
            dr["IN_TIME_Hour"] = inPatientInfo.In_Time.Hour;
            dr["IN_TIME_Minute"] = inPatientInfo.In_Time.Minute;

            //if (inPatientInfo.In_Approach == "急诊")
            //{
            //    dr["In_Approach"] = 1;
            //}
            //if (inPatientInfo.In_Approach == "门诊")
            //{
            //    dr["In_Approach"] = 2;
            //}
            //if (inPatientInfo.In_Approach == "其他医疗机构转入")
            //{
            //    dr["In_Approach"] = 3;
            //}
            //if (inPatientInfo.In_Approach == "其他")
            //{
                dr["In_Approach"] = inPatientInfo.In_Approach;
            //}

            dr["insection_name"] = inPatientInfo.Insection_Name;
            dr["In_Area_Name"] = inPatientInfo.In_Area_Name;

            if (inPatientInfo.Die_time != DateTime.MinValue) // 已出院
            {
                dr["Die_time_Year"] = inPatientInfo.Die_time.Year;
                dr["Die_time_Month"] = inPatientInfo.Die_time.Month;
                dr["Die_time_Day"] = inPatientInfo.Die_time.Day;
                dr["Die_time_Hour"] = inPatientInfo.Die_time.Hour;
                dr["Die_time_Minute"] = inPatientInfo.Die_time.Minute;

                string dt3 = inPatientInfo.In_Time.ToShortDateString();
                string dt4 = inPatientInfo.Die_time.ToShortDateString();
                TimeSpan ts2 = Convert.ToDateTime(inPatientInfo.Die_time) - Convert.ToDateTime(inPatientInfo.In_Time);
                TimeSpan ts3 = Convert.ToDateTime(dt4) - Convert.ToDateTime(dt3);
                if (ts2.Days == 0)
                {
                    int h = 0;
                    if (ts2.Minutes > 0)//大于0分钟时,小时加1
                        h = ts2.Hours + 1;
                    else
                        h = ts2.Hours;
                    dr["InHospital_Days"] = h.ToString() == "0" ? "1小时" : h.ToString() + "小时";
                    if (h == 24)
                        dr["InHospital_Days"] = "1天";
                }
                else
                {
                    dr["InHospital_Days"] = ts3.Days.ToString() + "天";
                }
                //dr["InHospital_Days"] = ts2.Days.ToString() == "0" ? "1" : ts2.Days.ToString();
                dr["Section_Name"] = inPatientInfo.Section_Name;
                dr["Sick_Area_Name"] = inPatientInfo.Sick_Area_Name;
            }
            else
            {
                dr["Die_time_Year"] = "";
                dr["Die_time_Month"] = "";
                dr["Die_time_Day"] = "";
                dr["Die_time_Hour"] = "";
                dr["Die_time_Minute"] = "";
                dr["InHospital_Days"] = "";
                dr["Section_Name"] = "";
                dr["Sick_Area_Name"] = "";
            }


            string sTurnSec = txtTurnSection.Text.Trim();
            if (sTurnSec.Contains("→"))
            {
                string[] aTurnSec = sTurnSec.Split('→');
                if (aTurnSec.Length == 2)
                {
                    dr["TurnSection"] = aTurnSec[1];
                }
                else
                {
                    string sTemp1 = string.Empty;
                    for (int i = 1; i < aTurnSec.Length; i++)
                    {
                        sTemp1 = sTemp1 + aTurnSec[i] + " → ";
                    }
                    dr["TurnSection"] = sTemp1.Substring(0, sTemp1.Length - 3);
                }
            }
            else
            {
                dr["TurnSection"] = "-";
            }
            dr["Home_Phone"] = inPatientInfo.Home_phone;
            #endregion

            foreach (DataColumn col in dt.Columns)
            {
                if (dt.Rows[0][col] != null && dt.Rows[0][col].ToString().Trim().Length == 0)
                {
                    if (!col.ColumnName.Contains("Pay_Manager") && !col.ColumnName.Contains("Health_card_no") &&
                        !col.ColumnName.Contains("PId") && !col.ColumnName.Contains("Sick_Doc_No"))
                    {
                        dt.Rows[0][col] = "-";
                    }
                }
            }
            
            return dt;
        }

        /// <summary>
        /// 获取付款方式 || 入院途径等字典类对象的代号
        /// </summary>
        /// <param name="?">代码</param>
        /// <returns>返回 1-9 或 ""</returns>
        private string GetPay_Manner(string code)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 972, j = 1; i <= 980; i++, j++) // 付款方式
            {
                dict.Add(i.ToString(), j.ToString());
            }
            try
            {
                return dict[code];
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 职业选择其他,文本框可用(这是一个暂时的措施,以后会去除)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCreer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCreer.Text.Contains("其他"))
            {
                //txtCreer.ReadOnly = false;
            }
            else
            {
                txtCreer.Text = "";
                txtCreer.ReadOnly = true;
            }
        }

        /// <summary>
        /// 修改异动表 next_id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_T_Inhospital_Action_NextID_(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            string sqlPatient_ID = "select distinct patient_id from t_inhospital_action";
            DataTable dtPatient_ID = App.GetDataSet(sqlPatient_ID).Tables[0];
            for (int i = 0; i < dtPatient_ID.Rows.Count; i++)
            {
                string Patient_ID = dtPatient_ID.Rows[i]["patient_id"].ToString();
                string sqlRecords = string.Format(@"select t.id,t.preview_id,t.next_id,patient_id from t_inhospital_action t 
                    where patient_id='{0}' order by patient_id, id", Patient_ID);
                DataTable dtRecords = App.GetDataSet(sqlRecords).Tables[0];
                for (int j = 0; j < dtRecords.Rows.Count - 1; j++)
                {
                    string id = dtRecords.Rows[j]["id"].ToString();
                    string nextID = dtRecords.Rows[j + 1]["id"].ToString();
                    string sqlTemp = string.Format(@"update t_inhospital_action set next_id='{0}'
                        where id={1}", nextID, id);
                    sqls.Add(sqlTemp);
                }
            }
            try
            {
                App.ExecuteBatch(sqls.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        ///// <summary>
        ///// 单选按钮被点击后对相应属性赋值
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void RadioButton_Click(object sender, EventArgs e)
        //{
        //    RadioButton rdo = sender as RadioButton;
        //    if (rdo.Name.Contains("MZYCY"))
        //    {
        //        sMZYCY = rdo.Text;
        //    }
        //    if (rdo.Name.Contains("RYYCY"))
        //    {
        //        sRYYCY = rdo.Text;
        //    }
        //    if (rdo.Name.Contains("SQYSH"))
        //    {
        //        sSQYSH = rdo.Text;
        //    }
        //    if (rdo.Name.Contains("LCYBL"))
        //    {
        //        sLCYBL = rdo.Text;
        //    }
        //    if (rdo.Name.Contains("FSYBL"))
        //    {
        //        sFSYBL = rdo.Text;
        //    }
        //    if (rdo.Name.Contains("LCLJGL"))
        //    {
        //        sLCLJGL = rdo.Text;
        //    }
        //}

        /// <summary>
        /// 将诊断情况转为数字字符
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private object Transfer(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            else
            {
                if (obj.ToString() == "未作")
                {
                    return 0;
                }
                else if (obj.ToString() == "符合")
                {
                    return 1;
                }
                else if (obj.ToString() == "不符合")
                {
                    return 2;
                }
                else if (obj.ToString() == "不确定")
                {
                    return 3;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 拆分含有附属诊断的诊断名
        /// </summary>
        /// <param name="obj"></param>
        private object TransferDiagnoseName(object obj)
        {
            if (obj != null && obj.ToString().Contains("|"))
            {
                obj = obj.ToString().Replace("|", "\n");
            }
            return obj;
        }

        private void txtEmergencyDiagnose_KeyUp(object sender, KeyEventArgs e)
        {
            //if (cboxMZ.Checked)
            //    return;
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10  where ((upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%')";
                            //sql_select += order;
                            if (cboxMZ.Checked)
                            {
                                sql_select += " and is_chinese='Y'";
                                sql_select += " Union";
                                sql_select += " select bm_code 疾病编码,bm_name 疾病名称 from t_bm  where (upper(py) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(py,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(bm_name) like '%" + text.ToUpper() + "%'";
                            }
                            else
                            {
                                sql_select += " and (is_chinese is null or is_chinese='N')";
                            }
                            App.FastCodeCheck(sql_select, txtBox, "疾病编码", "疾病名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtEmergencyDiagnose_TextChanged(object sender, EventArgs e)
        {
            newEmergencyDiagnose = "";
            //if (cboxMZ.Checked)
            //    return;
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["疾病名称"].ToString();
                            newEmergencyDiagnose = row["疾病名称"].ToString();
                            txtEmergencyCode.Text = row["疾病编码"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtPathology_KeyUp(object sender, KeyEventArgs e)
        {
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10  where (upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "疾病编码", "疾病名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtPoison_KeyUp(object sender, KeyEventArgs e)
        {
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10  where (upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "疾病编码", "疾病名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtPathology_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["疾病名称"].ToString();
                            txtPathologyCode.Text = row["疾病编码"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtPoison_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["疾病名称"].ToString();
                            txtPoisonCode.Text = row["疾病编码"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOperDoctor1_KeyUp(object sender, KeyEventArgs e)
        {
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            // string order = " order by case when substr(shortcut_code,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select a.user_id 医生id,a.user_name 医生名称 from t_userinfo a"
                                                + " inner join t_account_user b on a.user_id=b.user_id"
                                                + " inner join t_account c on b.account_id=c.account_id"
                                                + " inner join t_acc_role d on d.account_id=c.account_id"
                                                + " inner join t_role e on e.role_id=d.role_id"
                                                + " where shortcut_code like '%" + text
                                                + "%' AND substr(shortcut_code,0," + length + ")='" + text + "'"
                                                + " and e.role_type='D'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "医生id", "医生名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtOperDoctor1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["医生名称"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOperAssistant1_1_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_1_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_1_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_1_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor2_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor2_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_2_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_2_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_2_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_2_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor3_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor3_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_3_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_3_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_3_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_3_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor4_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor4_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_4_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_4_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_4_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_4_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor5_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor5_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_5_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_5_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_5_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_5_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor6_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor6_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_6_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_6_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_6_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_6_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor7_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor7_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_7_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_7_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_7_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_7_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperDoctor8_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperDoctor8_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant1_8_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant1_8_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtOperAssistant2_8_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtOperAssistant2_8_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor1_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor1_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor2_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor2_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor3_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor3_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor4_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor4_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor5_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor5_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor6_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor6_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor7_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor7_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txtAnesthesiaDoctor8_TextChanged(object sender, EventArgs e)
        {
            txtOperDoctor1_TextChanged(sender, e);
        }

        private void txtAnesthesiaDoctor8_KeyUp(object sender, KeyEventArgs e)
        {
            txtOperDoctor1_KeyUp(sender, e);
        }

        private void txttotal_cost_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            string text = txt.Text.Trim();
            if (text.Equals("0"))
                return;
            double test = 0;
            if (!string.IsNullOrEmpty(text))
            {
                double.TryParse(text, out test);
                if (test == 0)
                {
                    //txt.Focus();
                    App.Msg("请您输入数字！");
                }
            }
        }

        private void txttotal_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                TextBox _textbox = (TextBox)sender;
                if (_textbox.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(_textbox.Text, out oldf);
                    b2 = float.TryParse(_textbox.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }


        }

        private void label106_Click(object sender, EventArgs e)
        {

        }

        private void rdoAgainIn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAgainIn1.Checked)
            {
                txtPurpose.ReadOnly = true;
            }
        }

        private void rdoAgainIn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAgainIn2.Checked)
            {
                txtPurpose.ReadOnly = false;
            }
        }

        private void txtEmergencyCode_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtEmergencyCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBeforeIn_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        private void ucOtherDiagnose10_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdoSQYSH2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoSQYSH3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 获取当前选择的RadioButtonValues的值
        /// </summary>
        /// <param name="pbl"></param>
        /// <param name="str"></param>
        /// <param name="operator_type">操作类型0从数据库读取，1保存到数据库</param>
        private void GetRadioButtonValues(Panel pbl, ref string str, int operator_type)
        {
            for (int i = 0; i < pbl.Controls.Count; i++)
            {
                if (pbl.Controls[i].GetType().Name.Contains("RadioButton"))
                {
                    RadioButton rdbtn = pbl.Controls[i] as RadioButton;
                    if (operator_type == 1)
                    {
                        if (rdbtn.Checked)
                        {
                            int len = pbl.Controls[i].Name.Length - 1;
                            string val = pbl.Controls[i].Name.Substring(len, 1);
                            str = val;
                            break;
                        }
                    }
                    else
                    {
                        if (rdbtn.Name.Contains(str))
                        {
                            rdbtn.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private void rdbtnJH1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnJH1.Checked)
            {
                TXTJHDay.ReadOnly = true;
                txtJHHour.ReadOnly = true;
            }
        }

        private void rdbtnJH2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnJH2.Checked)
            {
                TXTJHDay.ReadOnly = false;
                txtJHHour.ReadOnly = false;
            }
        }
        /// <summary>
        /// 初始化杂项值
        /// </summary>
        private void InitTempVal()
        {
            //病例分型
            GetRadioButtonValues(pnlblfx, ref sBLFX, 1);
            //实施重症监护
            GetRadioButtonValues(panel16, ref sSSZZJH, 1);

            //单病种管理
            GetRadioButtonValues(panel10, ref sDBZGL, 1);
            //临床路径管理
            GetRadioButtonValues(panel11, ref sLCLJGL, 1);

            //实施DRGs管理
            GetRadioButtonValues(panel15, ref sSSDRGS, 1);
            //抗生素使用
            GetRadioButtonValues(panel17, ref sKSSSY, 1);
            //细菌培养标本送检
            GetRadioButtonValues(panel18, ref sXJPYBBSJ, 1);
            //法定传染病
            GetRadioButtonValues(panel13, ref sFDCRB, 1);

            sJH_DAY = TXTJHDay.Text.Trim();
            sJH_HOUR = txtJHHour.Text.Trim();
            sZLFQ_T = cbxZLFX_T.Text;
            sZLFQ_N = cbxZLFX_N.Text;
            sZLFQ_M1 = cbxZLFX_M1.Text;
            sZLFQ_M2 = cbxZLFX_M2.SelectedIndex == -1 ? "" : cbxZLFX_M2.SelectedIndex == 0 ? "" : Convert.ToString(cbxZLFX_M2.SelectedIndex);
            sBABY_APGAR = TXTBaby.Text.Trim();
        }

        /// <summary>
        /// 初始化杂项值
        /// </summary>
        private void ReadTempVal()
        {
            //病例分型
            GetRadioButtonValues(pnlblfx, ref sBLFX, 0);
            //实施重症监护
            GetRadioButtonValues(panel16, ref sSSZZJH, 0);

            //单病种管理
            GetRadioButtonValues(panel10, ref sDBZGL, 0);
            //临床路径管理
            GetRadioButtonValues(panel11, ref sLCLJGL, 0);

            //实施DRGs管理
            GetRadioButtonValues(panel15, ref sSSDRGS, 0);
            //抗生素使用
            GetRadioButtonValues(panel17, ref sKSSSY, 0);
            //细菌培养标本送检
            GetRadioButtonValues(panel18, ref sXJPYBBSJ, 0);
            //法定传染病
            GetRadioButtonValues(panel13, ref sFDCRB, 0);

            TXTJHDay.Text = sJH_DAY;
            txtJHHour.Text = sJH_HOUR;
            cbxZLFX_T.Text = sZLFQ_T;
            cbxZLFX_N.Text = sZLFQ_N;
            cbxZLFX_M1.Text = sZLFQ_M1;
            cbxZLFX_M2.SelectedIndex = sZLFQ_M2 == "" ? 0 : Convert.ToInt32(sZLFQ_M2);
            TXTBaby.Text = sBABY_APGAR;
        }

        /// <summary>
        /// 手术或者麻醉方式过长，截取截取字符串到下一行显示
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="len"></param>
        private void SplitStrFirst(string colName, int len, ref DataTable dt, string[] arrs, string nextStr, int i, bool flag)
        {
            if (i < 8)
            {
                string str = dt.Rows[0][colName + i].ToString();
                if (!string.IsNullOrEmpty(nextStr))
                {
                    str = nextStr;
                }
                if (!flag)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0][colName + i].ToString()))
                    {
                        arrs = new string[10];
                        arrs[0] = dt.Rows[0]["OperCode" + i].ToString();
                        arrs[1] = dt.Rows[0]["OperDate" + i].ToString();
                        arrs[2] = dt.Rows[0]["OperLevel" + i].ToString();
                        arrs[3] = dt.Rows[0]["OperDoctor" + i].ToString();
                        arrs[4] = dt.Rows[0]["OperAssistant1_" + i].ToString();
                        arrs[5] = dt.Rows[0]["OperAssistant2_" + i].ToString();
                        arrs[6] = dt.Rows[0]["ToHealLevel" + i].ToString();
                        arrs[7] = dt.Rows[0]["AnesthesiaWay" + i].ToString();
                        arrs[8] = dt.Rows[0]["AnesthesiaDoctor" + i].ToString();
                        arrs[9] = dt.Rows[0][colName + i].ToString();
                        dt.Rows[0]["OperCode" + i] = null;
                        dt.Rows[0]["OperDate" + i] = null;
                        dt.Rows[0]["OperLevel" + i] = null;
                        dt.Rows[0]["OperDoctor" + i] = null;
                        dt.Rows[0]["OperAssistant1_" + i] = null;
                        dt.Rows[0]["OperAssistant2_" + i] = null;
                        dt.Rows[0]["ToHealLevel" + i] = null;
                        dt.Rows[0]["AnesthesiaWay" + i] = null;
                        dt.Rows[0]["AnesthesiaDoctor" + i] = null;
                    }
                }
                if (str.Length > len)
                {
                    flag = false;
                    dt.Rows[0][colName + i] = str.Substring(0, len);
                    string nextstr = str.Substring(len);
                    SplitStrFirst(colName, len, ref dt, arrs, nextstr, i + 1, flag);
                }
                else
                {
                    dt.Rows[0][colName + i] = str;
                    int j = i + 1;
                    if (arrs != null)
                    {
                        string[] args = new string[10];
                        args[0] = dt.Rows[0]["OperCode" + j].ToString();
                        args[1] = dt.Rows[0]["OperDate" + j].ToString();
                        args[2] = dt.Rows[0]["OperLevel" + j].ToString();
                        args[3] = dt.Rows[0]["OperDoctor" + j].ToString();
                        args[4] = dt.Rows[0]["OperAssistant1_" + j].ToString();
                        args[5] = dt.Rows[0]["OperAssistant2_" + j].ToString();
                        args[6] = dt.Rows[0]["ToHealLevel" + j].ToString();
                        args[7] = dt.Rows[0]["AnesthesiaWay" + j].ToString();
                        args[8] = dt.Rows[0]["AnesthesiaDoctor" + j].ToString();
                        args[9] = dt.Rows[0][colName + j].ToString();
                        dt.Rows[0]["OperCode" + j] = arrs[0];
                        dt.Rows[0]["OperDate" + j] = arrs[1];
                        dt.Rows[0]["OperLevel" + j] = arrs[2];
                        dt.Rows[0]["OperDoctor" + j] = arrs[3];
                        dt.Rows[0]["OperAssistant1_" + j] = arrs[4];
                        dt.Rows[0]["OperAssistant2_" + j] = arrs[5];
                        dt.Rows[0]["ToHealLevel" + j] = arrs[6];
                        dt.Rows[0]["AnesthesiaWay" + j] = arrs[7];
                        dt.Rows[0]["AnesthesiaDoctor" + j] = arrs[8];
                        dt.Rows[0][colName + j] = arrs[9];
                        if (dt.Rows[0][colName + j] != null &&
                            !string.IsNullOrEmpty(dt.Rows[0][colName + j].ToString().Trim()))
                        {
                            flag = true;
                            SplitStrFirst(colName, len, ref dt, args, "", j, flag);
                        }
                        else
                        {
                            dt.Rows[0][colName + j] = "";//"-"
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dt.Rows[0][colName + j].ToString()) && str != "")
                        {
                            dt.Rows[0][colName + j] = "";//"-"
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 手术或者麻醉方式过长，截取截取字符串到下一行显示
        /// </summary>
        /// <param name="colName"></param>
        /// <param name="len"></param>
        private void SplitStrSecend(string colName, int len, ref DataTable dt, string arrs, string nextStr, int i, bool flag)
        {
            if (i < 8)
            {
                string str = dt.Rows[0][colName + i].ToString();
                string nextstr = "";
                if (!string.IsNullOrEmpty(nextStr))
                {
                    str = nextStr;
                }
                if (!flag)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0][colName + i].ToString()))
                    {
                        arrs = dt.Rows[0][colName + i].ToString();
                    }
                }
                if (str.Length > len)
                {
                    flag = false;
                    dt.Rows[0][colName + i] = str.Substring(0, len);
                    nextstr = str.Substring(len);
                }
                else
                {
                    dt.Rows[0][colName + i] = str;
                    int j = i + 1;
                    if (!string.IsNullOrEmpty(arrs))
                    {
                        if (dt.Rows[0][colName + (i + 1)] != null &&
                            !string.IsNullOrEmpty(dt.Rows[0][colName + (i + 1)].ToString().Trim()))
                        {
                            //中间变量
                            string midStr = arrs;
                            arrs = dt.Rows[0][colName + (i + 1)].ToString().Trim();
                            dt.Rows[0][colName + (i + 1)] = midStr;
                        }
                    }
                    flag = true;
                }
                SplitStrSecend(colName, len, ref dt, arrs, nextstr, i + 1, flag);
            }
        }
        /// <summary>
        /// 根据跨行的行数来确定优先级，已行数多的为准
        /// </summary>
        /// <param name="operNameLen"></param>
        /// <param name="AnesthesiaWayLen"></param>
        private void NewLine(int operNameLen, int AnesthesiaWayLen, ref DataTable dt)
        {
            string[] arrs = null;
            string str = string.Empty;
            //手术名称字符数的行数为准
            if (operNameLen > AnesthesiaWayLen)
            {
                SplitStrFirst("OperName", 9, ref dt, arrs, "", 1, true);
                SplitStrSecend("AnesthesiaWay", 7, ref dt, str, "", 1, true);
            }
            else
            {
                SplitStrFirst("AnesthesiaWay", 7, ref dt, arrs, "", 1, true);
                SplitStrSecend("OperName", 9, ref dt, str, "", 1, true);
            }
        }
        string strTime = string.Empty;
        private void txtQC_Time_Click(object sender, EventArgs e)
        {
            strTime = txtQC_Time.Text;
            txtQC_Time.Text = "";
        }

        private void dtpQC_Time_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpQC_Time.Value.ToString("yyyy-MM-dd") == "1949-10-01")
            //{
            //    dtpQC_Time.Visible = false;
            //    txtQC_Time.Visible = true;
            //}
            //else
            //{
            //    dtpQC_Time.Visible = true;
            //    txtQC_Time.Visible = false;
            //}
        }

        private void txtQC_Time_Leave(object sender, EventArgs e)
        {
            DateTime time;
            if (DateTime.TryParse(txtQC_Time.Text, out time)&&time.Year>1000)
            {
                txtQC_Time.Text = time.ToString("yyyy-MM-dd");
            }
            else
            {
                App.Msg("请输入正确的日期格式");
                txtQC_Time.Text = "";
            }
        }

        private void txtInSection_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMajorDiagnose_TextChanged(object sender, EventArgs e)
        {
            newMainDiag = "";
            //if (cboxZY.Checked)
            //    return;
            //if (txtMajorDiagnose.ReadOnly == true)
            //    return;
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["疾病名称"].ToString();
                            newMainDiag = row["疾病名称"].ToString();
                            txtMajorDiagnoseCode.Text = row["疾病编码"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtMajorDiagnose_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtMajorDiagnose.ReadOnly == true)
            //    return;
            //if (cboxZY.Checked)
            //    return;
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10  where ((upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%')";
                            //sql_select += order;
                            if (cboxZY.Checked)
                            {
                                sql_select += " and is_chinese='Y'";
                                sql_select += " Union";
                                sql_select += " select bm_code 疾病编码,bm_name 疾病名称 from t_bm  where (upper(py) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(py,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(bm_name) like '%" + text.ToUpper() + "%'";
                            }
                            else
                            {
                                sql_select += " and (is_chinese is null or is_chinese='N')";
                            }
                            App.FastCodeCheck(sql_select, txtBox, "疾病编码", "疾病名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 读取HIS的手术费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetHisInfo_Click(object sender, EventArgs e)
        {
            His_Get_Cost(inPatientInfo.His_id);
            His_Get_OperaterInfo(inPatientInfo.His_id);
        }


        /// <summary>
        /// 获取HIS的费用信息
        /// </summary>
        private void His_Get_Cost(string His_Id)
        {
            try
            {
                string sql = "select * from HNYZ_ZXYY.intf_emr_costview@DBHISLINK where zyh='" + His_Id + "'";
                DataSet ds_his_fee = App.GetDataSet(sql);

                /*
                 * 费用信息的读取
                 */


                /*
                 * 获取小类编码
                 */
                string sql_fee = "select code,bzdm from t_data_code where type=209";
                DataSet ds_fee = App.GetDataSet(sql_fee);

                /*
                 * 费用大类
                 */
                string sql_ba_cl = "select code from t_data_code where type=210";
                DataSet ds_ba_fee = App.GetDataSet(sql_ba_cl);

                #region 通用计算
                for (int i = 0; i < ds_ba_fee.Tables[0].Rows.Count; i++)
                {
                    string bz = ds_ba_fee.Tables[0].Rows[i]["code"].ToString();

                    if (bz.Length < 2)
                    {
                        bz = "0" + bz;
                    }
                    if (bz == "01")
                    {
                        txtService_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "02")
                    {
                        txtOperator_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "03")
                    {
                        txtNurse_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "04")
                    { txtOthser_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "05")
                    { txtBlzd_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "06")
                    { txtsyszd_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "07")
                    { txtYxxzd_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "08")
                    { txtZdxm_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "09")
                    { txtFshszl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "10")
                    { txtShszl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "11")
                    { txtKf_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "12")
                    { txtZyzl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "13")
                    { txtXy_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "14")
                    { txtZchy_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "15")
                    { txtZcy_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "16")
                    { txtXue_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "17")
                    { txtBdbl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "18")
                    { txtQdbl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "19")
                    { txtNxyzl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "20")
                    { txtXbyzl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "21")
                    { txtJccl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "22")
                    { txtZlcl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "23")
                    { txtShscl_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "24")
                    { txtQt_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                }
                #endregion

                #region 特殊项计算
                //总费用
                txttotal_cost.Text = GetFeeSum(ds_his_fee, ds_fee, "", "");

                //麻醉费
                txtMz_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, "", "039");

                //手术费
                txtShs_Cost.Text = GetFeeSum(ds_his_fee, ds_fee, "", "037");

                #endregion

            }
            catch
            {

            }


        }

        /// <summary>
        /// 计算总费用
        /// </summary>
        /// <param name="ds_his_fee">HIS费用集合</param>
        /// <param name="ds_fee_code">我方数据库费用代码集合</param>
        /// <param name="dl">大类 ""代表所有费用的总量</param>
        /// <param name="spacial_code"></param>
        /// <returns></returns>
        private string GetFeeSum(DataSet ds_his_fee, DataSet ds_fee_code, string dl, string spacial_code)
        {
            //ds_fee_code.Tables[0].Select("bzdm='" + dl + "'");
            string strReturn = "";
            try
            {
                float sumval = 0;

                for (int i = 0; i < ds_his_fee.Tables[0].Rows.Count; i++)
                {
                    string FYLBBM = ds_his_fee.Tables[0].Rows[i]["FYLBBM"].ToString();
                    string ZFY = ds_his_fee.Tables[0].Rows[i]["ZFY"].ToString();
                    if (dl != "")
                    {
                        //按大类计算
                        if (ds_fee_code.Tables[0].Select("bzdm='" + dl + FYLBBM + "'").Length > 0)
                        {
                            sumval = sumval + Convert.ToSingle(ZFY);
                        }
                    }
                    else
                    {
                        if (spacial_code == "")
                        {
                            //计算总量
                            sumval = sumval + Convert.ToSingle(ZFY);
                        }
                        else
                        {
                            //特殊代码
                            if (FYLBBM == spacial_code)
                            {
                                strReturn = ZFY;
                            }
                        }
                    }
                }

                strReturn = sumval.ToString();
            }
            catch
            {
                strReturn = "";
            }
            finally
            {
                if (strReturn == "0")
                    strReturn = "";
            }
            return strReturn;
        }

        /// <summary>
        /// 获取HIS的手术信息
        /// </summary>
        private void His_Get_OperaterInfo(string His_Id)
        {
            string sql = "select a.SSRQ,a.SSMC,a.SSJB,c.User_name,a.YZ,a.Ez,YHDJ,a.MZFS,a.MZYS,b.CODE from HNYZ_ZXYY.intf_emr_operationview@DBHISLINK a left join OPER_DEF_ICD9 b on a.SSMC=b.NAME inner join t_userinfo c on a.SSYS=c.User_num where zyh='"+His_Id+"' order by ssrq asc";
            DataSet dt_his = App.GetDataSet(sql);
            for (int i = 0; i < dt_his.Tables[0].Rows.Count; i++)
            {
                TextBox txt_his = null;
                ComboBox cbo_his = null;
                DateTimePicker dtp_his = null;               
                foreach (Control ctr in panel5.Controls)
                {
                    #region 对文本框赋值
                    txt_his = ctr as TextBox;
                    if (txt_his != null && txt_his.Name.Substring(txt_his.Name.Length - 1) == (i + 1).ToString())
                    {
                        if (txt_his.Name.Contains("txtOperCode"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["CODE"].ToString();
                        }
                        if (txt_his.Name.Contains("txtOperHandle"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["SSMC"].ToString();
                        }
                        if (txt_his.Name.Contains("txtOperDoctor"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["User_name"].ToString();
                        }
                        if (txt_his.Name.Contains("txtOperAssistant1_"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["YZ"].ToString();
                        }
                        if (txt_his.Name.Contains("txtOperAssistant2_"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["Ez"].ToString();
                        }
                        if (txt_his.Name.Contains("txtAnesthesiaWay"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["MZFS"].ToString();
                        }
                        if (txt_his.Name.Contains("txtAnesthesiaDoctor"))
                        {
                            txt_his.Text = dt_his.Tables[0].Rows[i]["MZYS"].ToString();
                        }
                    }
                    #endregion

                    #region 对下拉列表赋值
                    //cbo_his = ctr as ComboBox;
                    //if (cbo_his != null && cbo_his.Name.Contains((i + 1).ToString()))
                    //{
                    //    if (cbo_his.Name.Contains("cboOperLevel"))
                    //    {
                    //        cbo_his.Text = dt_his.Rows[i]["手术级别"].ToString();
                    //    }
                    //    if (cbo_his.Name.Contains("cboToHealLevel"))
                    //    {
                    //        cbo_his.Text = dt_his.Rows[i]["手术切口等级"].ToString();
                    //    }
                    //}
                    #endregion

                    #region 对时间赋值
                    dtp_his = ctr as DateTimePicker;
                    if (dtp_his != null && dtp_his.Name.Contains((i + 1).ToString()))
                    {
                        dtp_his.Value = Convert.ToDateTime(dt_his.Tables[0].Rows[i]["SSRQ"]);
                    }
                    #endregion
                }
            }
        }

        
        /// <summary>
        /// 打印时必填项提醒
        /// </summary>
        /// <returns></returns>
        private bool IsNeedToWrite()
        {
            if (txtPName.Text.Trim().Length == 0)
            {
                App.Msg("患者姓名为空,不能打印！");
                return false;
            }
            if (cbxSex.SelectedIndex==0)
            {
                App.Msg("患者性别为空,不能打印！");
                return false;
            }
            if (cboInKind.SelectedIndex == 0)
            {
                App.Msg("患者入院途径为空,不能打印！");
                return false;
            }
            if (txtSEC_DIRE_NAME.Text.Trim().Length == 0)
            {
                App.Msg("科主任为空,不能打印！");
                return false;
            }
            if (txtPOS_DOC_NAME.Text.Trim().Length == 0)
            {
                App.Msg("住院医师为空,不能打印！");
                return false;
            }
            if (txtPRA_DOC_NAME.Text.Trim().Length == 0)
            {
                App.Msg("责任护士为空,不能打印！");
                return false;
            }
            if (txtSTU_DOC_NAME.Text.Trim().Length == 0)
            {
                App.Msg("质控医师为空,不能打印！");
                return false;
            }
            if (txtQC_Nurse.Text.Trim().Length == 0)
            {
                App.Msg("质控护士为空,不能打印！");
                return false;
            }
            if (!(rbtnMedical_recordJ.Checked || rbtnMedical_recordY.Checked || rbtnMedical_recordB.Checked))
            {
                App.Msg("病案质量为空,不能打印！");
                return false;
            }
            if (!(rdbtnblfx1.Checked || rdbtnblfx2.Checked || rdbtnblfx3.Checked || rdbtnblfx4.Checked))
            {
                App.Msg("病例分型为空,不能打印！");
                return false;
            }
            if (!(rdbtnDBZ1.Checked || rdbtnDBZ2.Checked))
            {
                App.Msg("单病种管理为空,不能打印！");
                return false;
            }
            if (!(rdoLCLJGL1.Checked || rdoLCLJGL2.Checked || rdoLCLJGL3.Checked))
            {
                App.Msg("实施临床路径管理为空,不能打印！");
                return false;
            }
            if (!(rdbrnDGRs1.Checked || rdbrnDGRs2.Checked || rdbrnDGRs3.Checked || rdbrnDGRs4.Checked))
            {
                App.Msg("实施DRGs管理为空,不能打印！");
                return false;
            }
            if (!(rdbtnKSS1.Checked || rdbtnKSS2.Checked))
            {
                App.Msg("抗生素使用为空,不能打印！");
                return false;
            }
            if (!(rdbtnBZSJ1.Checked || rdbtnBZSJ2.Checked))
            {
                App.Msg("细菌培养标本送检为空,不能打印！");
                return false;
            }
            if (!(rdbtnCRB0.Checked || rdbtnCRB1.Checked || rdbtnCRB2.Checked || rdbtnCRB3.Checked))
            {
                App.Msg("法定传染病为空,不能打印！");
                return false;
            }
            if (rdoOutHospital2.Checked && txtOutHospital2.Text.Trim().Length==0)
            {
                App.Msg("离院方式为医嘱转院时，接收医疗机构名称为空,不能打印！");
                return false;
            }
            if (rdoOutHospital3.Checked && txtOutHospital3.Text.Trim().Length == 0)
            {
                App.Msg("离院方式为医嘱转社区时，接收医疗机构名称为空,不能打印！");
                return false;
            }
            if (rdoAgainIn2.Checked && txtPurpose.Text.Trim().Length == 0)
            {
                App.Msg("有出院31天内再住院计划时，目的为空,不能打印！");
                return false;
            }
            return true;
        }

        private void txtOperation_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            //if (textBox.ReadOnly == true)
            //    return;
            newOperation = "";
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["手术名称"].ToString();
                            newOperation = row["手术名称"].ToString();
                            if (textBox.Name.Contains("1"))
                            {
                                txtOperCode1.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("2"))
                            {
                                txtOperCode2.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("3"))
                            {
                                txtOperCode3.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("4"))
                            {
                                txtOperCode4.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("4"))
                            {
                                txtOperCode4.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("5"))
                            {
                                txtOperCode5.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("6"))
                            {
                                txtOperCode6.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("7"))
                            {
                                txtOperCode7.Text = row["手术编码"].ToString();
                            }
                            else if (textBox.Name.Contains("8"))
                            {
                                txtOperCode8.Text = row["手术编码"].ToString();
                            }
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtOperation_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.ReadOnly == true)
                return;
            App.FastCodeFlag = false;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code 手术编码,name 手术名称 from oper_def_icd9  where (upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                +" or upper(name) like '%" + text.ToUpper() + "%'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "手术编码", "手术名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// HIS费用查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {

            string sql = "select * from HNYZ_ZXYY.intf_emr_costview@DBHISLINK where zyh='" + inPatientInfo.His_id + "'";
            DataSet ds_his_fee = App.GetDataSet(sql);
            if (ds_his_fee.Tables.Count > 0)
            {
                frmHISFee frmfee = new frmHISFee(ds_his_fee);
                frmfee.ShowDialog();
            }
        }


        private void txtQC_Nurse_KeyUp(object sender, KeyEventArgs e)
        {
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            // string order = " order by case when substr(shortcut_code,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select a.user_id 护士id,a.user_name 护士名称 from t_userinfo a  "
                                                + " inner join t_account_user b on a.user_id=b.user_id"
                                                + " inner join t_account c on b.account_id=c.account_id"
                                                + " inner join t_acc_role d on d.account_id=c.account_id"
                                                + " inner join t_role e on e.role_id=d.role_id"
                                                + " where shortcut_code like '%" + text
                                                + "%' AND substr(shortcut_code,0," + length + ")='" + text + "'"
                                                + " and e.role_type='N'";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "护士id", "护士名称");
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void txtQC_Nurse_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            textBox.Text = row["护士名称"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    //txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtMajorDiagnose_DoubleClick(object sender, EventArgs e)
        {
            //if (cboxZY.Checked == true)
            //{
            //    oldMainDiag = txtMajorDiagnose.Text;
            //    frmCDiagDict frm = new frmCDiagDict();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.txtMajorDiagnoseCode.Text = frm.Bmcode;
            //        this.txtMajorDiagnose.Text = frm.Bmname;
            //        if (frm.Zhname.Length > 0)
            //        {
            //            this.txtMajorDiagnose.Text += "—" + frm.Zhname;
            //        }
            //        newMainDiag = txtMajorDiagnose.Text;
            //    }
            //}
            //TextBox textBox = sender as TextBox;
            //if (textBox.ReadOnly == false)
            //    return;
            //string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10 where rownum<200";
            //List<string> oldlist = new List<string>();
            //oldlist.Add("name");
            //oldlist.Add("code");
            //oldlist.Add("shortcut1");
            //List<string> Newlist = new List<string>();
            //Newlist.Add("疾病名称");
            //Newlist.Add("疾病编码");
            //Newlist.Add("名称拼音");
            //Bifrost.frmCode f = new frmCode(sql_select, oldlist, Newlist);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    if (App.SelectObj != null)
            //    {
            //        if (App.SelectObj.Select_Row != null)
            //        {
            //            DataRow row = App.SelectObj.Select_Row;
            //            txtMajorDiagnose.Text = row["疾病名称"].ToString();
            //            txtMajorDiagnoseCode.Text = row["疾病编码"].ToString();
            //            App.SelectObj = null;
            //        }
            //    }
            //}
        }

        private void txtOperHandle1_DoubleClick(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.ReadOnly == false)
                return;
            string sql_select = "select code 手术编码,name 手术名称 from oper_def_icd9 where rownum<200";
            List<string> oldlist = new List<string>();
            oldlist.Add("name");
            oldlist.Add("code");
            oldlist.Add("shortcut1");
            List<string> Newlist = new List<string>();
            Newlist.Add("手术名称");
            Newlist.Add("手术编码");
            Newlist.Add("名称拼音");
            Bifrost.frmCode f = new frmCode(sql_select, oldlist, Newlist);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (App.SelectObj != null)
                {
                    if (App.SelectObj.Select_Row != null)
                    {
                        DataRow row = App.SelectObj.Select_Row;
                        textBox.Text = row["手术名称"].ToString();
                        if (textBox.Name.Contains("1"))
                        {
                            txtOperCode1.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("2"))
                        {
                            txtOperCode2.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("3"))
                        {
                            txtOperCode3.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("4"))
                        {
                            txtOperCode4.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("4"))
                        {
                            txtOperCode4.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("5"))
                        {
                            txtOperCode5.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("6"))
                        {
                            txtOperCode6.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("7"))
                        {
                            txtOperCode7.Text = row["手术编码"].ToString();
                        }
                        else if (textBox.Name.Contains("8"))
                        {
                            txtOperCode8.Text = row["手术编码"].ToString();
                        }
                        App.SelectObj = null;
                    }
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable ();
            dt.Columns.Add("id");
            dt.Columns.Add("icd10");
            dt.Columns.Add("name");
            dt.Columns.Add("incondition");
            dt.Columns.Add("ischinese");
            int i = 1;
            List<ucOtherDiagnose> otherDiagnoseList = new List<ucOtherDiagnose>();
            foreach (Control c in grpOtherDiagnose.Controls)
            {
                ucOtherDiagnose uc = c as ucOtherDiagnose;
                
                if (uc != null)
                {
                    if (uc.OtherDiagnose.Trim().Length > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["id"] = i.ToString();
                        dr["icd10"] = uc.ICD10;
                        dr["name"] = uc.OtherDiagnose;
                        dr["incondition"] = uc.InCondition;
                        dr["ischinese"] = (uc.Ischinese == true) ? "Y" : "";
                        dt.Rows.Add(dr);
                        i++;
                    }
                    otherDiagnoseList.Add(uc);
                    uc = new ucOtherDiagnose();
                    //uc.OtherDiagnose = "";
                    //uc.ICD10="";
                    //uc.InCondition = "";

                }
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("没有诊断需要调整！");
                return;
            }
            frmSortDiagnose fsd = new frmSortDiagnose(dt,otherDiagnoseList);
            fsd.ShowDialog();
            //// 先清空所有控件的值
            //ClearGroup(this.frmCaseFirst.grpOtherDiagnose);

            //// 按设定的排列顺序进行排序
            ////rows.Sort(CompareRow);

            //// 遍历所有的选择行,对其他诊断分组中的用户控件赋值
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    ucOtherDiagnose uc = frmCaseFirst.grpOtherDiagnose.Controls[i] as ucOtherDiagnose;
            //    uc.OtherDiagnose = rows[i][2].ToString();
            //    uc.ICD10 = rows[i][3].ToString();
            //    //uc.InCondition = true;// = rows[i][4].ToString();
            //}
        }

        /// <summary>
        /// 获取首页诊断信息
        /// </summary>
        /// <returns></returns>
        private DataSet GetDiagData()
        {
            //string sqlDiag = "select a.id,a.patient_id as patientid,a.type typecode,"
            //+ "decode(a.type,'E','门诊诊断','S','损伤中毒及外部因素','P','病理诊断','M','出院主要诊断','O','出院其它诊断') as typename,"
            //+ "a.name diagnosename,a.icd10code,a.icd10name,a.incondition,a.pnumber sicknumber "
            //+ " from cover_diagnose a"
            //+ " where a.patient_id=" + inPatientInfo.Id
            //+ " order by type";

            StringBuilder sb = new StringBuilder("select a.typecode,a.typename,a.patientid,");
            sb.Append("b.name diagnosename,b.icd10code,b.incondition,b.pnumber sicknumber,b.TURN_TO turnto,b.is_chinese as ischinese ");
            sb.Append(" from");
            sb.Append("(select 'E' typecode,'门诊诊断' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'S' typecode,'损伤中毒' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'P' typecode,'病理诊断' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'M' typecode,'出院主要诊断' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'O' typecode,'出院其它诊断' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1) a");
            sb.Append(" left join cover_diagnose b on a.typecode=b.type and b.patient_id=a.patientid");
            sb.Append(" order by decode(a.typecode,'E','1','M','2','O','3','P','4','S','5') asc");
            return App.GetDataSet(sb.ToString());

        }
        private DataTable dtDiag;
        private void BindDiag()
        {
            dtDiag = GetDiagData().Tables[0];
            this.dataGridViewX1.DataSource = dtDiag.DefaultView;
        }
        /// <summary>
        /// 行上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagUp_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = this.dataGridViewX1.CurrentRow;
            if (curRow.Cells[0].RowIndex == 0)
            {
                return;
            }
            DataGridViewRow nextRow = this.dataGridViewX1.Rows[curRow.Cells[0].RowIndex-1];
            if (curRow.Cells["typename"].Value == nextRow.Cells["typename"].Value)
            {
                SwapRows(dtDiag.Rows[curRow.Cells[0].RowIndex], dtDiag.Rows[nextRow.Cells[0].RowIndex]);
            }
            else
            {
                return;
            }
        }

        private void SwapRows(DataGridViewRow row1, DataGridViewRow row2)
        {
            for (int i = 0; i < row1.Cells.Count; i++)
            {
                string strTemp = row1.Cells[i].Value.ToString();
                row1.Cells[i].Value = row2.Cells[i].Value;
                row2.Cells[i].Value = strTemp;
            }
        }

        private void SwapRows(DataRow row1, DataRow row2)
        {
            for (int i = 0; i < row1.Table.Columns.Count; i++)
            {
                string strTemp = row1[i].ToString();
                row1[i] = row2[i];
                row2[i] = strTemp;
            }
        }
        /// <summary>
        /// 行下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagDown_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = this.dataGridViewX1.CurrentRow;
            if (curRow.Cells[0].RowIndex == dataGridViewX1.Rows.Count - 1)
            {
                return;
            }
            DataGridViewRow nextRow = this.dataGridViewX1.Rows[curRow.Cells[0].RowIndex+1];
            if (curRow.Cells["typename"].Value == nextRow.Cells["typename"].Value)
            {
                //SwapRows(curRow, nextRow);
                SwapRows(dtDiag.Rows[curRow.Cells[0].RowIndex], dtDiag.Rows[nextRow.Cells[0].RowIndex]);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagInsert_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("请选择需要插入诊断的位置");
                return;
            }
            else
            {
                //DataGridViewRow row=new DataGridViewRow ();
                DataRow row = dtDiag.NewRow();
                DataRow curRow = dtDiag.Rows[this.dataGridViewX1.CurrentCell.RowIndex];
                for (int i = 0; i < dtDiag.Columns.Count; i++)
                {
                    string strColName = dataGridViewX1.Columns[i].Name;
                    switch (strColName)
                    {
                        case "diagnosename":
                        case "icd10code":
                        case "incondition":
                        case"sicknumber":
                            row[strColName] = "";
                            break;
                        default:
                            row[strColName] = curRow[strColName];
                            break;
                    }
                }
                dtDiag.Rows.InsertAt(row, dataGridViewX1.CurrentCell.RowIndex+1);
                //dataGridViewX1.Rows.Insert(dataGridViewX1.CurrentCell.RowIndex, row);
            }
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell.RowIndex<0)
            {
                App.Msg("请选择需要删除的诊断");
                return;
            }
            else
            {
                int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                //bool isfirst = false;
                bool istopsame = true;
                bool isbottomsame = true;
                if (rowindex > 0)
                {
                    if (dtDiag.Rows[rowindex]["typename"].ToString() != dtDiag.Rows[rowindex - 1]["typename"].ToString())
                    {
                        istopsame = false;
                    }
                }
                else
                {
                    istopsame = false;
                }
                if (rowindex < dtDiag.Rows.Count - 1)
                {
                    if (dtDiag.Rows[rowindex]["typename"].ToString() != dtDiag.Rows[rowindex + 1]["typename"].ToString())
                    {
                        isbottomsame = false;
                    }
                }
                else
                {
                    isbottomsame = false;
                }
                if (istopsame||isbottomsame)
                {
                    //dtDiag.Rows[dataGridViewX1.CurrentCell.RowIndex].Delete();
                    dtDiag.Rows.RemoveAt(dataGridViewX1.CurrentCell.RowIndex);
                }
                else
                {
                    DataRow curRow=dtDiag.Rows[rowindex];
                    for (int i = 0; i < dtDiag.Columns.Count; i++)
                    {
                        string strColName = dtDiag.Columns[i].ColumnName.ToLower();
                        switch (strColName)
                        {
                            case "diagnosename":
                            case "icd10code":
                            case "incondition":
                            case "sicknumber":
                            case "turnto":
                                curRow[strColName] = "";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void btnDiagSelect_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("请先选择需要选择提取诊断的位置");
                return;
            }
            DataRow curRow = dtDiag.Rows[dataGridViewX1.CurrentCell.RowIndex];
            int rowindex = dataGridViewX1.CurrentCell.RowIndex;
            frmSelDiag fdiag = new frmSelDiag(inPatientInfo);
            if (fdiag.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fdiag.List.Count;i++)
                {
                    if (i == 0)
                    {
                        curRow["diagnosename"] = fdiag.List[i]["诊断名称"];
                        curRow["icd10code"] = fdiag.List[i]["编码"];
                        continue;
                    }
                    DataRow dr = dtDiag.NewRow();
                    dr["diagnosename"] = fdiag.List[i]["诊断名称"];
                    dr["icd10code"] = fdiag.List[i]["编码"].ToString();
                    dr["patientid"] = curRow["patientid"];
                    dr["typecode"] = curRow["typecode"];
                    dr["typename"] = curRow["typename"];
                    dtDiag.Rows.InsertAt(dr, rowindex + 1);
                    rowindex++;
                }
                for (int i = 0; i < fdiag.Clist.Count; i++)
                {
                    if (i == 0&&fdiag.List.Count==0)
                    {
                        curRow["diagnosename"] = fdiag.Clist[i]["病名"];
                        curRow["icd10code"] = fdiag.Clist[i]["编码"];
                        continue;
                    }
                    DataRow dr = dtDiag.NewRow();
                    dr["diagnosename"] = fdiag.Clist[i]["病名"];
                    dr["icd10code"] = fdiag.Clist[i]["编码"].ToString();
                    dr["patientid"] = curRow["patientid"];
                    dr["typecode"] = curRow["typecode"];
                    dr["typename"] = curRow["typename"];
                    dtDiag.Rows.InsertAt(dr, rowindex + 1);
                    rowindex++;
                }
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
            if (e.RowIndex < 0)
                return;
            string strColName = dataGridViewX1.Columns[e.ColumnIndex].Name;
            string strDiagType = dataGridViewX1.Rows[e.RowIndex].Cells["typecode"].Value.ToString();
            if (strColName != "diagnosename")
                return;
            string sql_select = "select code 疾病编码,name 疾病名称 from diag_def_icd10 where rownum<200";
            List<string> oldlist = new List<string>();
            oldlist.Add("name");
            oldlist.Add("code");
            oldlist.Add("shortcut1");
            List<string> Newlist = new List<string>();
            Newlist.Add("疾病名称");
            Newlist.Add("疾病编码");
            Newlist.Add("名称拼音");
            Bifrost.frmCode f = new frmCode(sql_select, oldlist, Newlist);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (App.SelectObj != null)
                {
                    if (App.SelectObj.Select_Row != null)
                    {
                        DataRow row = App.SelectObj.Select_Row;
                        DataGridViewRow objRow =dataGridViewX1.Rows[e.RowIndex];
                        objRow.Cells["diagnosename"].Value = row["疾病名称"].ToString();
                        objRow.Cells["icd10code"].Value = row["疾病编码"].ToString();
                        objRow.Cells["ischinese"].Value = "0";
                        App.SelectObj = null;
                    }
                }
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;
            string strColName = dataGridViewX1.Columns[e.ColumnIndex].Name;
            string strDiagType = dataGridViewX1.Rows[e.RowIndex].Cells["typecode"].Value.ToString();            
            switch (strColName)
            {
                case "typename":
                    dataGridViewX1.Columns[strColName].ReadOnly = true;
                    return;
                case"diagnosename":
                    if(strDiagType=="E"||strDiagType=="M"||strDiagType=="O")
                    {
                        dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly=true;
                    }
                    return;
                case "incondition":
                    if(strDiagType!="M"&&strDiagType!="O")
                    {
                        dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly=true;
                    }
                    return;
                case "sicknumber":
                    if (strDiagType != "P")
                    {
                        dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }
                    return;
                case"turnto":
                    if (strDiagType != "M")
                    {
                        dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    }
                    return;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// 病名
        /// T_BM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCDiagName_Click(object sender, EventArgs e)
        {
            frmCDiagDict frmcdiag = new frmCDiagDict();
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("请先选择行");
            }
            DataRow dr = dtDiag.Rows[this.dataGridViewX1.CurrentCell.RowIndex];
            if (frmcdiag.ShowDialog() == DialogResult.OK)
            {
                dr["diagnosename"] = frmcdiag.Bmname + (frmcdiag.Zhname.Length == 0 ? "" : "-" + frmcdiag.Zhname);
                dr["icd10code"] = frmcdiag.Bmcode;
                dr["ischinese"] = "1";
            }
        }

        /// <summary>
        /// 症候
        /// T_ZH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCDiagZH_Click(object sender, EventArgs e)
        {
            string sql_select = "select zh_code 编码,zh_name 症候 from T_ZH where rownum<200";
            List<string> oldlist = new List<string>();
            oldlist.Add("zh_name");
            oldlist.Add("zh_code");
            oldlist.Add("py");
            List<string> Newlist = new List<string>();
            Newlist.Add("症候");
            Newlist.Add("编码");
            Newlist.Add("症候拼音");
            Bifrost.frmCode f = new frmCode(sql_select, oldlist, Newlist);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (App.SelectObj != null)
                {
                    if (App.SelectObj.Select_Row != null)
                    {
                        DataRow row = App.SelectObj.Select_Row;
                        int rowindex = 0;
                        if (this.dataGridViewX1.CurrentCell.RowIndex >= 0)
                        {
                            rowindex = dataGridViewX1.CurrentCell.RowIndex;
                        }
                        else
                        {
                            return;
                        }
                        DataRow objRow = GetDiagData().Tables[0].Rows[rowindex];
                        objRow["diagnosename"] = row["疾病名称"].ToString();
                        objRow["icd10code"] = row["疾病编码"].ToString();
                        objRow["ischinese"] = "1";
                        App.SelectObj = null;
                    }
                }
            }
        }

        /// <summary>
        /// 保存出院诊断
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> SaveOutPatientDiagnoseNew()
        {
            // 所有类型的诊断集合
            List<OutPatientDiagndose> Opds = new List<OutPatientDiagndose>();
            OutPatientDiagndose opd = null;
            DataRow[] drows;
            // 门急诊
            drows = dtDiag.Select("TYPECODE='E' and DIAGNOSENAME is not null and DIAGNOSENAME<>''");
            if(drows.Length>0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = drows[0]["diagnosename"].ToString();
                opd.ICD10 = drows[0]["icd10code"].ToString();
                opd.DType = OutPatientDiagndose.DiagnoseType.E;
                opd.Is_Chinese = drows[0]["ischinese"].ToString();
                Opds.Add(opd);
            }
            // 病理诊断
            drows = dtDiag.Select("TYPECODE='P' and DIAGNOSENAME is not null and DIAGNOSENAME<>''");
            if (drows.Length > 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = drows[0]["diagnosename"].ToString();
                opd.ICD10 = drows[0]["icd10code"].ToString();
                opd.DType = OutPatientDiagndose.DiagnoseType.P;
                opd.Number = drows[0]["sicknumber"].ToString();
                opd.Is_Chinese = drows[0]["ischinese"].ToString();
                Opds.Add(opd);
            }

            // 损伤中毒诊断
            drows = dtDiag.Select("TYPECODE='S' and DIAGNOSENAME is not null and DIAGNOSENAME<>''");
            if (drows.Length > 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = drows[0]["diagnosename"].ToString();
                opd.ICD10 = drows[0]["icd10code"].ToString();
                opd.DType = OutPatientDiagndose.DiagnoseType.S;
                opd.Is_Chinese = drows[0]["ischinese"].ToString();
                Opds.Add(opd);
            }

            // 主要诊断
            drows = dtDiag.Select("TYPECODE='M' and DIAGNOSENAME is not null and DIAGNOSENAME<>''");
            if (drows.Length > 0)
            {
                opd = new OutPatientDiagndose();
                opd.Name = drows[0]["diagnosename"].ToString();
                opd.ICD10 = drows[0]["icd10code"].ToString();
                opd.DType = OutPatientDiagndose.DiagnoseType.M;
                opd.Condition = drows[0]["incondition"].ToString();
                opd.TurnTo = drows[0]["turnto"].ToString();
                opd.Is_Chinese = drows[0]["ischinese"].ToString();
                Opds.Add(opd);
            }

            // 其他诊断
            drows = dtDiag.Select("TYPECODE='O' and DIAGNOSENAME is not null and DIAGNOSENAME<>''");
            foreach (DataRow dr in drows)
            {
                opd = new OutPatientDiagndose();
                opd.Name = dr["diagnosename"].ToString();
                opd.ICD10 = dr["icd10code"].ToString();
                opd.DType = OutPatientDiagndose.DiagnoseType.O;
                opd.Condition = dr["incondition"].ToString();
                opd.Is_Chinese = dr["ischinese"].ToString();
                Opds.Add(opd);
            }

            // 遍历 Opds 集合,组合SQL语句
            List<string> Sqls = new List<string>();
            string sql = "delete COVER_DIAGNOSE where PATIENT_ID='" + inPatientInfo.Id + "'";
            Sqls.Add(sql);
            sql = @"insert into COVER_DIAGNOSE(INPATIENT_ID,TYPE,NAME,ICD10CODE,PATIENT_ID,INCONDITION,PNUMBER,TURN_TO,is_chinese) 
                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
            foreach (OutPatientDiagndose var in Opds)
            {
                Sqls.Add(string.Format(sql, inPatientInfo.PId, var.DType, var.Name, var.ICD10, inPatientInfo.Id, var.Condition, var.Number, var.TurnTo,var.Is_Chinese));
            }

            // 病案质量
            sql = "delete COVER_QUALITY where PATIENT_ID='" + inPatientInfo.Id + "'";
            Sqls.Add(sql);
            string sQuality = string.Empty;
            foreach (RadioButton var in pnlMEDICAL_RECODE.Controls)
            {
                if (var.Checked)
                {
                    sQuality = var.Text;
                    break;
                }

            }
            string strQdate = txtQC_Time.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(strQdate) && !strQdate.Contains("XXXX-XX-XX"))
                {
                    DateTime dtqcdate = Convert.ToDateTime(strQdate);
                    strQdate = dtqcdate.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception)
            {
                App.Msg("您输入的质控时间无效！");
                strQdate = "";

            }
            sql = string.Format(@"insert into  COVER_QUALITY(INPATIENT_ID,QUALITY,Q_DOCTOR_NAME,Q_NURSE_NAME,Q_DATE,PATIENT_ID,SX_DOCTOR_NAME,
                    JX_DOCTOR_NAME,ZR_NURSE_NAME,ZY_DOCTOR_NAME,ZZ_DOCTOR_NAME,ZR_DOCTOR_NAME,SECTION_HEAD,CODER_NAME) values('{0}','{1}','{2}','{3}',
                    '{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", inPatientInfo.PId,
                sQuality, txtSTU_DOC_NAME.Text, txtQC_Nurse.Text, strQdate, inPatientInfo.Id, txtQC_Doctor.Text, txtIN_DOC_NAME.Text,
                txtPRA_DOC_NAME.Text, txtPOS_DOC_NAME.Text, txtDUTY_DOC_NAME.Text, txtDIRE_NAME.Text, txtSEC_DIRE_NAME.Text, txtCoder.Text);
            Sqls.Add(sql);


            return Sqls;
        }
        private string oldMainDiag;
        private string newMainDiag;
        private void txtMajorDiagnose_Enter(object sender, EventArgs e)
        {
            oldMainDiag = txtMajorDiagnose.Text;
            isZYValidation = true;
        }

        private void txtMajorDiagnose_Leave(object sender, EventArgs e)
        {
            //if (!isZYValidation)
            //    return;
            //if (string.IsNullOrEmpty(newMainDiag))
            //{
            //    if (txtMajorDiagnose.Text != oldMainDiag&&txtMajorDiagnose.Text.Length>0)
            //    {
            //        txtMajorDiagnose.Text = oldMainDiag;
            //        App.Msg("只允许添加字典中的诊断");
            //    }
            //}
        }

        private void cboxZY_CheckedChanged(object sender, EventArgs e)
        {
            if (isZYSet)
            {
                isZYSet = false;
            }
            else
            {
                this.txtMajorDiagnose.Text = "";
                this.txtMajorDiagnoseCode.Text = "";
            }
            //if (cboxZY.Checked == true)
            //{
            //    frmCDiagDict frm = new frmCDiagDict();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.txtMajorDiagnoseCode.Text = frm.Bmcode;
            //        this.txtMajorDiagnose.Text = frm.Bmname;
            //        if (frm.Zhname.Length > 0)
            //        {
            //            this.txtMajorDiagnose.Text += "——" + frm.Zhname;
            //        }
            //    }
            //}
        }

        private void cboxMZ_CheckedChanged(object sender, EventArgs e)
        {
            if (isMZSet)
            {
                isMZSet = false;
            }
            else
            {
                this.txtEmergencyDiagnose.Text = "";
                this.txtEmergencyCode.Text = "";
            }
        }

        private void txtEmergencyDiagnose_DoubleClick(object sender, EventArgs e)
        {
            //if (cboxMZ.Checked == true)
            //{
            //    oldEmergencyDiagnose = txtEmergencyDiagnose.Text;
            //    frmCDiagDict frm = new frmCDiagDict();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.txtEmergencyDiagnose.Text = frm.Bmcode;
            //        this.txtEmergencyDiagnose.Text = frm.Bmname;
            //        if (frm.Zhname.Length > 0)
            //        {
            //            this.txtEmergencyDiagnose.Text += "—" + frm.Zhname;
            //        }
            //        newEmergencyDiagnose = txtEmergencyDiagnose.Text;
            //    }
            //}
        }
        private string oldEmergencyDiagnose;
        private string newEmergencyDiagnose;
        private void txtEmergencyDiagnose_Enter(object sender, EventArgs e)
        {
            oldEmergencyDiagnose = txtEmergencyDiagnose.Text;
            isMZValidation = true;
        }

        private void txtEmergencyDiagnose_Leave(object sender, EventArgs e)
        {
            //if (!isMZValidation)
            //    return;
            //if (string.IsNullOrEmpty(newEmergencyDiagnose))
            //{
            //    if (txtEmergencyDiagnose.Text != oldEmergencyDiagnose&&txtEmergencyDiagnose.Text.Length>0)
            //    {
            //        txtEmergencyDiagnose.Text = oldEmergencyDiagnose;
            //        App.Msg("只允许添加字典中的诊断");
            //    }
            //}
        }
        private bool isMZValidation = true;
        private bool isMZSet = false;
        private void cboxMZ_MouseEnter(object sender, EventArgs e)
        {
            isMZValidation = false;
        }
        public void InitMZValidation()
        {
            isMZSet = true;
        }
        public void InitZYValidation()
        {
            isZYSet = true;
        }
        private bool isZYValidation = true;
        private bool isZYSet = false;
        private void cboxZY_MouseEnter(object sender, EventArgs e)
        {
            isZYValidation = false;
        }

        private void cboxMZ_MouseLeave(object sender, EventArgs e)
        {
            isMZValidation = true;
        }

        private void cboxZY_MouseLeave(object sender, EventArgs e)
        {
            isZYValidation = true;
        }

        private string oldOperation;
        private string newOperation;
        /// <summary>
        /// 手术开始编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOperHandle1_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            oldOperation = text.Text;
        }
        /// <summary>
        /// 手术结束编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOperHandle1_Leave(object sender, EventArgs e)
        {
            //TextBox text = sender as TextBox;
            //if (string.IsNullOrEmpty(newOperation))
            //{
            //    if (text.Text != oldOperation&&text.Text.Length>0)
            //    {
            //        text.Text = oldOperation;
            //        App.Msg("只允许添加字典中的手术");
            //    }
            //}
        }

        private void txtAge1_TextChanged(object sender, EventArgs e)
        {
            if (txtAge1.Text.Length > 0)
            {
                txtAge2.Text = "";
            }
        }

        private void txtAge2_TextChanged(object sender, EventArgs e)
        {
            if (txtAge2.Text.Length > 0)
            {
                txtAge1.Text = "";
            }
        }

        private void txtSEC_DIRE_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    TextBox textBox = sender as TextBox;
            //    try
            //    {
            //        string text = textBox.Text.Trim();
            //        if (!string.IsNullOrEmpty(text))
            //        {
            //            if (App.SelectObj != null)
            //                if (App.SelectObj.Select_Row != null)
            //                {
            //                    DataRow row = App.SelectObj.Select_Row;
            //                    textBox.Text = row["医生名称"].ToString();
            //                    App.SelectObj = null;
            //                }
            //        }
            //        else
            //        {
            //            //txtContent.Text = textName;
            //            App.HideFastCodeCheck();
            //        }
            //    }
            //    catch
            //    { }
            //}
        }

        /// <summary>
        /// 当前科室联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboOutSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOutSection.SelectedIndex > 0)
            {
                dataBindOutSection(cboOutSection.SelectedValue);
            }
            else
            {
                cboOutSickArea.DataSource = null;
                cboOutSickArea.Items.Add("-请选择-");
                cboOutSickArea.SelectedIndex = 0;
            }
        }

        private void dataBindOutSection(object id)
        {
            try
            {
                //select t2.section_code,t3.sick_area_code,t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 where t1.sid=t2.sid and t1.said=t3.said
                //string sql = "select t.said,t.sick_area_name from t_sickareainfo t";
                string sql = "select t2.section_code,t3.sick_area_code,t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 " +
                            " where t1.sid=t2.sid and t1.said=t3.said and t2.sid='" + id + "'";
                DataTable dt = App.GetDataSet(sql).Tables[0];
                cboOutSickArea.DisplayMember = "sick_area_name";
                cboOutSickArea.ValueMember = "said";
                cboOutSickArea.DataSource = dt;
                cboOutSickArea.SelectedIndex = 0;

            }
            catch (System.Exception ex)
            {
                cboOutSickArea.DataSource = null;
                cboOutSickArea.Items.Add("-请选择-");
                cboOutSickArea.SelectedIndex = 0;
            }
            
        }


        private void cboOutSection_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboOutSection.SelectedIndex > 0)
                {
                    dataBindOutSection(cboOutSection.SelectedValue);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 编目修改申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCode_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否存在有效的删除申请
                string sql = "select count(0) col from(select a.status, a.apply_date from t_in_Code_modify_apply a where a.apply_date=(select max(apply_date) from t_in_Code_modify_apply where patient_id='" + inPatientInfo.Id + "') and status='0')";
                if (!App.ReadSqlVal(sql, 0, "col").Equals("0"))
                {
                    App.Msg("已经发了修改申请，请等待病案室审批！");
                    return;
                }
                //if (DataInit.IsExistsValidatedModifyApplyCode())//此处不完善
                //{
                //    App.Msg("修改申请已经审核，无需再次申请！");
                //    return;
                //}
                FrmCode frm = new FrmCode();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string sqls = "select  id from t_in_code_information  where codetime = (select max(codetime) from t_in_code_information where inpatient_id = '" + inPatientInfo.Id + "')";
                    string iid = App.ReadSqlVal(sqls, 0, "id");
                    sql = " insert into t_in_Code_modify_apply(id, patient_id, doctor_id, apply_reason, apply_date,section_id,status,iid)values(t_genid.nextval, '" + inPatientInfo.Id.ToString() + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + frm.Reason + "',sysdate,'" + App.UserAccount.CurrentSelectRole.Section_Id.ToString() + "','0','" + iid + "')";
                    App.ExecuteSQL(sql);
                    App.Msg("申请成功！");
                }
            }
            catch (Exception ex)
            {
                App.Msg("申请修改首页操作出现异常：" + ex.Message.ToString());
            }
        }


        ///// <summary>
        ///// 当前病区联动
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void cboOutSickArea_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboOutSickArea.SelectedIndex != 0)
        //    {
        //        dataBindOutSickArea(cboOutSickArea.SelectedValue);

        //    }
        //    else
        //    {
        //        //cboNativePlaceSh.DataSource = null;
        //        //cboNativePlaceSh.Items.Add("-请选择-");
        //        //cboNativePlaceSh.SelectedIndex = 0;
        //        //txtJGXian.Text = "";
        //    }
        //}

        //private void dataBindOutSickArea(object id)
        //{
            
        //    string sql = "select t2.section_code,t3.sick_area_code,t2.sid,t3.said,t2.section_name,t3.sick_area_name from t_section_area t1,t_sectioninfo t2,t_sickareainfo t3 " +
        //                " where t1.sid=t2.sid and t1.said=t3.said and t3.said='" + id + "'";
        //    //string sql = "select t.sid,t.section_name from t_sectioninfo t";
        //    DataTable dt = App.GetDataSet(sql).Tables[0];
        //    DataRow row = dt.NewRow();
        //    row["section_name"] = "-请选择-";
        //    row["sid"] = "-1";
        //    dt.Rows.InsertAt(row, 0);
        //    cboOutSection.DisplayMember = "section_name";
        //    cboOutSection.ValueMember = "sid";
        //    cboOutSection.DataSource = dt;
        //}
    }
}