using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Bifrost.HisInStance;
//using Bifrost_Hospital_Management.CommonClass;
using Base_Function.BLL_DOCTOR;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;
using TextEditor;
using System.Xml;
//using Bifrost_Nurse.DOCTOR_MANAGE.Message;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Base_Function.BLL_MEDICAL_RECORD_GRADE;

using Base_Function.BLL_DOCTOR.HisInStance.LIS;
using Base_Function.BLL_DOCTOR.HisInStance;
using Base_Function.BLL_DOCTOR.HisInStance.医嘱单;
using MySql.Data.MySqlClient;
//using Bifrost.HisInstance;


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 主观评分（医务）
    /// </summary>
    public partial class frmGrade : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmMainGradeRepart fmgr;
        ucfrmMainGradeRepartDoctor fmgrDoctor;
        ucfrmMainGradeRepartSection fmgrSection;
        frmMainSelectHistoryRepart fmshr;
        string pid = "";
        string suffName = "";
        string patientId = "";
        public string BingLiType = "";//运行病历或者终末病历

        string pingfenId = "";//获取他的评分ID
        string pingfenTime = "";//获取他的评分时间
        string pingfenName = "";//获取他的评审人
        public string strMark = "";//评分模块标识
        //string item_Id = "";//获取他每一项的ID

        string strAllTypePF = "";//全院评分标志
        string strSectionTypePF = "";//科室评分标志
        string strDoctorTypePF = "";//医生评分标志

        public string strMark_after = "";    //修改之后分值
        public string strMark_before = ""; //修改之前分值
        bool newflag;

        DataTable dt_list = new DataTable();

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        /// <summary>
        /// 调用窗体（文书调用2013-11-06）
        /// </summary>
        /// <param name="_fmgr"></param>
        /// <param name="PingfenMark"></param>
        public frmGrade(string strPatientID, string strPId, string strsuffname, string PingfenMark)
        {
            InitializeComponent();
            patientId = strPatientID;//要传递患者id
            pid = strPId;//要传递病人住院号
            suffName = strsuffname;//要传递管床医生姓名
            strMark = PingfenMark;//这个给1，string 类型的，作为标记使用
            this.Text = "给" + suffName + " 主观评分";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            SetKouFenHuiZong();
        }
        public delegate void BackId(string id);
        public BackId OnBackId;
        public frmGrade(ucfrmMainGradeRepart _fmgr, string PingfenMark, bool isnew, string bingliType)
        {
            InitializeComponent();
            strMark = PingfenMark;
            this.fmgr = _fmgr;
            pid = fmgr.SetPingfen();
            patientId = fmgr.SetPatientID();
            suffName = fmgr.SetSuffererName();
            newflag = isnew;
            BingLiType = bingliType;
            this.Text = "给 " + suffName + " 主观评分";

            strAllTypePF = "1";//全院评分标志

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            SetKouFenHuiZong();
        }
        public frmGrade(ucfrmMainGradeRepartDoctor _fmgrDoctor, string PingfenMark, bool isnew, string bingliType)
        {
            InitializeComponent();
            strMark = PingfenMark;
            this.fmgrDoctor = _fmgrDoctor;
            pid = fmgrDoctor.SetPingfen();
            patientId = fmgrDoctor.SetPatientID();
            suffName = fmgrDoctor.SetSuffererName();
            newflag = isnew;
            BingLiType = bingliType;
            this.Text = "给 " + suffName + " 主观评分";

            strDoctorTypePF = "3";//医生评分标志

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            SetKouFenHuiZong();
        }
        public frmGrade(ucfrmMainGradeRepartSection _fmgrSection, string PingfenMark, bool isnew, string bingliType)
        {
            InitializeComponent();
            strMark = PingfenMark;
            this.fmgrSection = _fmgrSection;
            pid = fmgrSection.SetPingfen();
            patientId = fmgrSection.SetPatientID();
            suffName = fmgrSection.SetSuffererName();
            newflag = isnew;
            BingLiType = bingliType;
            this.Text = "给 " + suffName + " 主观评分";

            strSectionTypePF = "2";//科室评分标志

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            SetKouFenHuiZong();
        }
        public frmGrade(frmMainSelectHistoryRepart _fmshr)
        {
            InitializeComponent();
            this.fmshr = _fmshr;

            pingfenId = fmshr.SetPingFenID();//获取他的评分ID
            patientId = fmshr.SetPatientID();
            pingfenTime = fmshr.SetPingFenTime();//获取他的评分时间
            pingfenName = fmshr.SetPingFenName();//获取他的评审人
            //item_Id = fmshr.SetPingFenItem_ID();//获取他每一项的ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "评审人:" + pingfenName + "    评审时间:" + pingfenTime;

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            //SetKouFen();因为要支持双击到左侧进行扣分，所以就不需要在右侧字典表中进行扣分
            SetKouFenHuiZong();
        }
        DataTable dtitem_Id;//查找扣过分的项目集合
        /// <summary>
        /// 根据条件查看扣分情况显示出来
        /// </summary>
        private void SetKouFen()
        {
            /*先根据病人住院号与评分时间把全部评过分的项目找出来然后在循环每一个c1控件 如果c1控件里面的项目ID与
             * item_id相同的话，就是扣过分的，就显示到对应的单元格里面
             */
            string selectItemIDSQL = "select item_id,down_point from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "' and emptype = 'D'";
            dtitem_Id = App.GetDataSet(selectItemIDSQL).Tables[0];
            //第一次循环是循环他小项目扣分的项数
            for (int i = 0; i < dtitem_Id.Rows.Count; i++)
            {
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_BingAnShouYe.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_BingAnShouYe[j, "ID"].ToString())
                    {
                        c1FlexGrid1_BingAnShouYe[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_BingAnShouYe[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_ruYuanJilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_ruYuanJilu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_ruYuanJilu[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_bingchengjilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_bingchengjilu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_bingchengjilu[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_jibenyaoqiu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_jibenyaoqiu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_jibenyaoqiu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_jibenyaoqiu[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_chuyuansiwang[j, "ID"].ToString())
                    {
                        c1FlexGrid1_chuyuansiwang[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_chuyuansiwang[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_fuzhujiancha.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_fuzhujiancha[j, "ID"].ToString())
                    {
                        c1FlexGrid1_fuzhujiancha[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_fuzhujiancha[j, "■"] = "TRUE";
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                    {
                        c1FlexGrid1_zhiqingtongyi[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_zhiqingtongyi[j, "■"] = "TRUE";
                    }
                }
            }
        }
        private void SetKouFenHuiZong()
        {
            try
            {
                string strKouFenHuiZong = "";
                //if (strAllTypePF == "1")
                //{
                //    strKouFenHuiZong = " select t.id,t.item 评分项目,t.item_score 分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id from t_deduct_score t where t.ITEM_PATIENTID='" + patientId + "'";

                //}
                if (newflag == true)
                {
                    strKouFenHuiZong = " select t.id,t.item 评分项目,t.item_score 分值,t.item_score 比较分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,t.item_type from t_deduct_score t where t.ITEM_PATIENTID='" + patientId + "'";

                }
                else
                {
                    if (strMark == "1")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item 评分项目,t.item_score 分值,t.item_score 比较分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.alltypepf ='1' and b.patient_id ='" + patientId + "'";

                    }
                    if (strMark == "2")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item 评分项目,t.item_score 分值,t.item_score 比较分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.sectiontypepf ='2' and b.patient_id ='" + patientId + "'";

                    }
                    if (strMark == "3")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item 评分项目,t.item_score 分值,t.item_score 比较分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.doctortypepf ='3' and b.patient_id ='" + patientId + "'";

                    }
                }


                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                this.c1FlexGrid2.DataSource = ds.Tables[0].DefaultView;
                //}
                this.c1FlexGrid2.Cols["id"].Visible = false;
                this.c1FlexGrid2.Cols["病人id"].Visible = false;
                this.c1FlexGrid2.Cols["评分项目"].Width = 100;
                this.c1FlexGrid2.Cols["分值"].Width = 50;
                this.c1FlexGrid2.Cols["比较分值"].Width = 50;
                this.c1FlexGrid2.Cols["比较分值"].Visible = false;
                this.c1FlexGrid2.Cols["扣分标准"].Width = 250;
                this.c1FlexGrid2.Cols["扣分理由"].Width = 500;
                this.c1FlexGrid2.Cols["medical_mark_id"].Visible = false;
                this.c1FlexGrid2.Cols["item_type"].Visible = false;
                if (strMark == "1" || strMark == "2" || strMark == "3")
                {
                    this.c1FlexGrid2.Cols["alltypepf"].Visible = false;
                    this.c1FlexGrid2.Cols["sectiontypepf"].Visible = false;
                    this.c1FlexGrid2.Cols["doctortypepf"].Visible = false;
                }

                //        c1FlexGrid2[i, "id"] = dt.Rows[i]["medical_mark_id"];
                //        c1FlexGrid2[i, "病人id"] = dt.Rows[i]["item_patientid"];
                //        c1FlexGrid2[i, "评分项目"] = dt.Rows[i]["item"];
                //        c1FlexGrid2[i, "分值"] = dt.Rows[i]["item_score"];
                //        c1FlexGrid2[i, "扣分标准"] = dt.Rows[i]["item_content"];
                //        c1FlexGrid2[i, "扣分理由"] = dt.Rows[i]["item_reason"];
            }
            catch
            {

            }
        }
        /// <summary>
        /// 设置病案首页类容
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960653' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_BingAnShouYe.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_BingAnShouYe.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_BingAnShouYe.Cols["■"].Width = 20;

            //this.c1FlexGrid1_BingAnShouYe.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_BingAnShouYe.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置入院记录
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8880' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_ruYuanJilu.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_ruYuanJilu.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_ruYuanJilu.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_ruYuanJilu.Cols["■"].Width = 20;

            //this.c1FlexGrid1_ruYuanJilu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_ruYuanJilu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["主客观分类"].Visible = false;


            string sql = "select b.name as 项目,count(b.id) as 次数 from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
            {
                if (c1FlexGrid1_ruYuanJilu[j, "主客观分类"].ToString() == "N")
                {
                    c1FlexGrid1_ruYuanJilu.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["项目"].ToString() == c1FlexGrid1_ruYuanJilu[j, "评分分类"].ToString())
                        {
                            //c1FlexGrid1_ruYuanJilu[j, "■"] = "TRUE";
                            //  c1FlexGrid1_ruYuanJilu[j, "扣分"] = Convert.ToDecimal(c1FlexGrid1_ruYuanJilu[j, "单项分值"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["次数"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///设置病程记录
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960658' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["扣分标准"].Width = 350;

            this.c1FlexGrid1_bingchengjilu.Cols["单项分值"].Width = 100;

            //this.c1FlexGrid1_bingchengjilu.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_bingchengjilu.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_bingchengjilu.Cols["■"].Width = 20;

            //this.c1FlexGrid1_bingchengjilu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_bingchengjilu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["主客观分类"].Visible = false;




            string sql = "select b.name as 项目,count(b.id) as 次数 from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
            {
                if (c1FlexGrid1_bingchengjilu[j, "主客观分类"].ToString() == "N")
                {
                    c1FlexGrid1_bingchengjilu.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["项目"].ToString() == c1FlexGrid1_bingchengjilu[j, "评分分类"].ToString())
                        {
                            //c1FlexGrid1_bingchengjilu[j, "■"] = "TRUE";
                            //c1FlexGrid1_bingchengjilu[j, "扣分"] = Convert.ToDecimal(c1FlexGrid1_bingchengjilu[j, "单项分值"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["次数"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///设置基本要求及医嘱单 69630004
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_jibenyaoqiu.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["■"].Width = 20;

            // this.c1FlexGrid1_jibenyaoqiu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_jibenyaoqiu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置出院（死亡）记录
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8882' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_chuyuansiwang.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_chuyuansiwang.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_chuyuansiwang.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_chuyuansiwang.Cols["■"].Width = 20;

            //this.c1FlexGrid1_chuyuansiwang.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_chuyuansiwang.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["主客观分类"].Visible = false;


            string sql = "select b.name as 项目,count(b.id) as 次数 from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
            {
                if (c1FlexGrid1_chuyuansiwang[j, "主客观分类"].ToString() == "N")
                {
                    c1FlexGrid1_chuyuansiwang.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["项目"].ToString() == c1FlexGrid1_chuyuansiwang[j, "评分分类"].ToString())
                        {
                            //c1FlexGrid1_chuyuansiwang[j, "■"] = "TRUE";
                            //c1FlexGrid1_chuyuansiwang[j, "扣分"] = Convert.ToDecimal(c1FlexGrid1_chuyuansiwang[j, "单项分值"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["次数"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///设置辅助检查
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////添加一行扣分列
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////添加一行理由列
            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_fuzhujiancha.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].Width = 100;
            //this.c1FlexGrid1_fuzhujiancha.Cols["理由"].Width = 222;
            //this.c1FlexGrid1_fuzhujiancha.Cols["■"].Width = 20;

            //this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_fuzhujiancha.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置知情同意
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960664' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //DataColumn dc1 = new DataColumn("扣分", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("■", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            //DataColumn dc2 = new DataColumn("理由", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            this.c1FlexGrid1_zhiqingtongyi.Cols["扣分标准"].Width = 440;
            this.c1FlexGrid1_zhiqingtongyi.Cols["单项分值"].Width = 100;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["扣分"].Width = 40;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["■"].Width = 40;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["理由"].Width = 220;

            this.c1FlexGrid1_zhiqingtongyi.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_zhiqingtongyi.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_zhiqingtongyi.Cols["主客观分类"].Visible = false;

        }
        /// <summary>
        /// 医嘱单
        /// </summary>
        private void SetYiZhudan()
        {
            try
            {
                string fuzhujianche = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
                DataSet ds = App.GetDataSet(fuzhujianche);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                this.c1FlexGrid1_yizhudan.DataSource = dt.DefaultView;
                this.c1FlexGrid1_yizhudan.Cols["扣分标准"].Width = 450;
                this.c1FlexGrid1_yizhudan.Cols["单项分值"].Width = 100;
                //this.c1FlexGrid1_fuzhujiancha.Cols["理由"].Width = 222;
                //this.c1FlexGrid1_fuzhujiancha.Cols["■"].Width = 20;

                //this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

                this.c1FlexGrid1_yizhudan.Cols["评分分类"].Visible = false;
                this.c1FlexGrid1_yizhudan.Cols["检查要求"].Visible = false;
                this.c1FlexGrid1_yizhudan.Cols["主客观分类"].Visible = false;

            }
            catch
            {

            }
        }


        private void frmGrade_Load(object sender, EventArgs e)
        {

            //c1FlexGrid1_bingchengjilu.Enabled = false;
            //c1FlexGrid1_ruYuanJilu.Enabled = false;
            //c1FlexGrid1_BingAnShouYe.Enabled = false;
            //c1FlexGrid1_chuyuansiwang.Enabled = false;
            //c1FlexGrid1_fuzhujiancha.Enabled = false;
            //c1FlexGrid1_jibenyaoqiu.Enabled = false;
            //c1FlexGrid1_zhiqingtongyi.Enabled = false;

            InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patientId);
            DataInit.CurrentPatient = inPatient;

            #region Pacs 影像报告

            //DataSet ds = App.GetDataSet("select distinct * from T_PASC_DATA t where ZYH='" + inPatient.PId + "' order by sqsj asc");
            ////this.tabControl2.Tabs.Clear();
            //string yxh;
            //string jch;
            //string shys;
            //string bgys;
            //string sqks;
            //string sqbw;
            //string sqys;
            //string jcff;
            //string yxxbx;
            //string yxxyj;
            //string sqsj;
            //string jclx;
            //if (ds != null)
            //{

            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        yxh = ds.Tables[0].Rows[i]["YXH"].ToString();
            //        jch = ds.Tables[0].Rows[i]["JCH"].ToString();
            //        shys = ds.Tables[0].Rows[i]["SHYD"].ToString();
            //        bgys = ds.Tables[0].Rows[i]["BGYS"].ToString();
            //        sqks = ds.Tables[0].Rows[i]["SQKS"].ToString();
            //        sqbw = ds.Tables[0].Rows[i]["JCBW"].ToString();
            //        sqys = ds.Tables[0].Rows[i]["SQYS"].ToString();
            //        jcff = ds.Tables[0].Rows[i]["METHOD"].ToString();
            //        yxxbx = ds.Tables[0].Rows[i]["EYESEE"].ToString();
            //        yxxyj = ds.Tables[0].Rows[i]["ZDBG"].ToString();
            //        sqsj = ds.Tables[0].Rows[i]["SQSJ"].ToString();
            //        jclx = ds.Tables[0].Rows[i]["JCLX"].ToString();

            //        if (sqsj.Trim() != "")
            //        {
            //            sqsj = Convert.ToDateTime(sqsj).ToString("yyyy-MM-dd");
            //        }

            //        ucPascInfo pascinfo = new ucPascInfo(yxh, jch, shys, bgys, sqks, sqbw, sqys, jcff, yxxbx, yxxyj, sqsj, jclx, inPatient.PId);
            //        pascinfo.Dock = DockStyle.Fill;
            //        DevComponents.DotNetBar.TabControlPanel tabctpnDoc1 = new DevComponents.DotNetBar.TabControlPanel();
            //        tabctpnDoc1.AutoScroll = true;
            //        DevComponents.DotNetBar.TabItem page1 = new DevComponents.DotNetBar.TabItem();
            //        page1.Text = jch + "--" + jclx;
            //        tabctpnDoc1.TabItem = page1;
            //        tabctpnDoc1.Dock = DockStyle.Fill;
            //        page1.AttachedControl = tabctpnDoc1;
            //        page1.Tag = pascinfo;
            //        tabctpnDoc1.Controls.Add(pascinfo);
            //        this.tabControl2.Controls.Add(tabctpnDoc1);
            //        this.tabControl2.Tabs.Add(page1);
            //        this.tabControl2.Refresh();
            //    }
            //}

            #endregion

            #region 电子归档病历
            ArrayList searchFiles = new ArrayList();
            //searchFiles = Tools_Others.SearchFiles(patientId, "", "");
            //this.search_FilesBrowse.Patients = Tools_FileOperation.GetScanFiles(GlobalSettings.BrowsePath);
            //this.search_FilesBrowse.LoadTree();
            #endregion
            //病案查阅
            Base_Function.BASE_COMMON.DataInit.isRightRun = true;

            //ucDoctorOperater fq = new ucDoctorOperater(inPatient);
            ucPFDoc fq = new ucPFDoc(inPatient, false);
            fq.Dock = DockStyle.Fill;

            //fq.flagGrade = true;
            if (newflag == true)
            {
                fq.OnComeFrmText = SetFrmDelegate;
            }
            else
            {
                btnZC.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = false;
            }

            panel_Main.Controls.Add(fq);
        }
        void SetFrmDelegate(TextEditor.frmText text)
        {
            text.MyDoc.OwnerControl.ContextMenuStrip = null;
            //text.MyDoc.Locked = true;
            //text.MyDoc.ContentChanged();
            //袁杨暂时注释 141218
            //            
            text.MyDoc.OnBackPFId += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFId(MyDoc_OnBackPFId);

        }
        //1:删除，0变色
        void MyDoc_OnBackPFId(string id, int flag)
        {
            if (flag == 0)
            {
                SetColor(id);
            }
            if (flag == 1)
            {
                DeleteRow(id);
            }
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {


            if (App.Ask("确定评分操作已经全部完成？若没有完成，建议您完成后在点击此操作！"))
            {
                btnConfirm.Visible = false;

                try
                {
                    /*
                                 * 循环每个c1控件扣分的值然后用100-扣分值 就是评分后的总分。
                                 */
                    #region 总分
                    double bingansum = 0;
                    //把病案首页扣的总分算出来
                    //for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString() != "")
                    //    {
                    //        bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString());//扣分项分值
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "病案首页")
                        {
                            bingansum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double ruyuanSum = 0;
                    //把入院记录扣的总分算出来
                    //for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString() != "")
                    //    {
                    //        ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString());//扣分项分值
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "入院记录")
                        {
                            ruyuanSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double bingchengSum = 0;
                    //把病程记录扣的总分算出来
                    //for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_bingchengjilu[i, "扣分"].ToString() != "")
                    //    {
                    //        bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, "扣分"].ToString());//扣分项分值
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "病程记录")
                        {
                            bingchengSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }

                    double fuzhujianchaSum = 0;
                    //把辅助检查及医嘱单扣的总分算出来
                    //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString() != "")
                    //    {
                    //        jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString());//扣分项分值
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "辅助检查及医嘱单")
                        {
                            fuzhujianchaSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double chuyuanSiwangSum = 0;
                    //把出院（死亡）记录扣的总分算出来
                    //for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString() != "")
                    //    {
                    //        chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString());//扣分项分值
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "出院记录")
                        {
                            chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double jibenyaojiuSum = 0;
                    //把书写要求扣的总分算出来
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "书写要求")
                        {
                            jibenyaojiuSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double zhiqingtongyiSum = 0;
                    // 把知情同意扣的总分算出来
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "知情同意书")
                        {
                            zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    double yizhudanSum = 0;
                    // 把医嘱单扣的总分算出来
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "医嘱单")
                        {
                            yizhudanSum += Convert.ToDouble(c1FlexGrid2[i, "分值"].ToString());//扣分项分值
                        }
                    }
                    //扣分调整
                    if (bingansum > 10) bingansum = 10;
                    if (ruyuanSum > 20) ruyuanSum = 20;
                    if (bingchengSum > 50) bingchengSum = 50;
                    if (chuyuanSiwangSum > 10) chuyuanSiwangSum = 10;
                    if (fuzhujianchaSum > 5) fuzhujianchaSum = 5;
                    if (jibenyaojiuSum > 5) jibenyaojiuSum = 5;
                    if (yizhudanSum > 3) yizhudanSum = 3;

                    double zongSum = 100 - (bingansum + ruyuanSum + bingchengSum + jibenyaojiuSum + chuyuanSiwangSum + fuzhujianchaSum + zhiqingtongyiSum + yizhudanSum);
                    if (fmshr == null)
                    {
                        if (strMark == "1")
                        {
                            fmgr.SetFenzhi(zongSum);
                        }
                        if (strMark == "2")
                        {
                            fmgrSection.SetFenzhi(zongSum);
                        }
                        if (strMark == "3")
                        {
                            fmgrDoctor.SetFenzhi(zongSum);
                        }
                    }
                    else
                    {
                        fmshr.SetFenzhi(zongSum);
                    }
                    #endregion
                    /*
             * 如果是评分就是把记录插入到数据库里面。如果是编辑评分，那么首先根据病人住院ID(pid)和时间删除所有评分
             * 过的项目，在插入新评分的项
             */
                    #region 添加或修改评分
                    string time = "sysdate";
                    List<string> list = new List<string>();

                    //如果是编辑的时候就要先删除，如果不是，那就是第一次评分
                    if (fmshr != null)
                    {
                        //添加之前先要根据他的Pid，评分时间，和小项ID删除然后在添加
                        for (int k = 0; k < dtitem_Id.Rows.Count; k++)
                        {
                            string deleteSQL = "delete t_doc_grade where pid='" + pingfenId +
                                "' and item_id=" + dtitem_Id.Rows[k]["item_id"].ToString() + " and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "'";
                            App.ExecuteSQL(deleteSQL);
                        }
                    }
                    //满分
                    if (zongSum == 100)
                    {
                        string binganID = "0";//扣分项的ID
                        string binganKoufen = "";//扣分项分值
                        string binganLiyou = "";//扣分原因
                        string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                        string dosName = App.UserAccount.UserInfo.User_name;//医生姓名 
                        string insertupdateSQL = "";//定义要执行的sql语句

                        if (strMark == "1")//这是全院评分模式
                        {
                            if (pingfenId == "" && pid != "")
                            {
                                insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "')";

                                list.Add(insertupdateSQL);
                            }
                            else
                            {
                                string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                if (App.ExecuteSQL(insert) > 0)
                                    this.Close();
                            }
                        }
                        if (strMark == "2")//这是科室评分模式
                        {
                            if (pingfenId == "" && pid != "")
                            {
                                insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "')";

                                list.Add(insertupdateSQL);
                            }
                            else
                            {
                                string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                if (App.ExecuteSQL(insert) > 0)
                                    this.Close();
                            }
                        }
                        if (strMark == "3")//这是医生评分模式
                        {
                            if (pingfenId == "" && pid != "")
                            {
                                insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "'," + time + ",'D',3, '" + patientId + "')";

                                list.Add(insertupdateSQL);
                            }
                            else
                            {
                                string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                            "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                            "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                if (App.ExecuteSQL(insert) > 0)
                                    this.Close();
                            }
                        }

                    }

                    //循环病案首页的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "病案首页")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名 
                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "')";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }
                    //if (App.ExecuteBatch(list.ToArray()) > 0)
                    //{
                    //    App.Msg("评分成功");
                    //}


                    //循环入院记录的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {

                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "入院记录")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是医生评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }

                    //循环病程记录的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "病程记录")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是个人评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }




                    //循环基本要求及医嘱单的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "出院记录")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }



                    //循环出院（死亡）记录的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "辅助检查及医嘱单")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是医生评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }



                    //循环辅助检查的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "书写要求")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是医生评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }



                    // 循环知情同意的每一项添加到表里面
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        #region 修改后的数据
                        int deductid = int.Parse(c1FlexGrid2[i, "id"].ToString());
                        string fz = c1FlexGrid2[i, "分值"].ToString();
                        string ly = c1FlexGrid2[i, "扣分理由"].ToString();
                        string sql = "update t_deduct_score set item_score ='" + fz + "',item_reason ='" + ly + "' where id =" + deductid;
                        App.ExecuteSQL(sql);
                        #endregion
                        if (this.c1FlexGrid2[i, "评分项目"].ToString() == "知情同意书")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//扣分项的ID
                            string binganKoufen = c1FlexGrid2[i, "分值"].ToString();//扣分项分值
                            string binganLiyou = c1FlexGrid2[i, "扣分理由"].ToString();//扣分原因
                            //string binganID = c1FlexGrid1_zhiqingtongyi[i, "ID"].ToString();//扣分项的ID
                            //string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, "扣分"].ToString();//扣分项分值
                            //string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, "理由"].ToString();//扣分原因
                            string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                            string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                            string insertupdateSQL = "";//定义要执行的sql语句
                            if (strMark == "1")//这是全院评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',1,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,alltypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',1,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "2")//这是科室评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',2,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,sectiontypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',2,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                            if (strMark == "3")//这是医生评分方式
                            {
                                if (pingfenId == "" && pid != "")
                                {
                                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pid + "','" + binganID +
                                    "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                    "','" + dosName + "','" + zongSum + "'," + time + ",'D',3,'" + patientId + "') ";
                                    list.Add(insertupdateSQL);
                                }
                                else
                                {
                                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype,doctortypepf,patient_id) values('" + pingfenId + "','" + binganID +
                                "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'D',3,'" + patientId + "') ";
                                    if (App.ExecuteSQL(insert) > 0)
                                        this.Close();
                                }
                            }
                        }
                    }

                    if (strMark == "1")
                    {
                        if (fmgr == null)
                        {
                            #region 修改消息信息 袁杨添加130724
                            string strDatetimeU = App.GetSystemTime().ToString();//获取当前操作时间
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "本次病例最终得分为" + zongSum;//消息内容
                            }
                            else
                            {
                                strContentU = "运行病历有缺陷请修改";//运行病历消息内容
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //把所有的评分项目的插入语句用list保存起来
                            //fmgr.addPingFen(list);

                            //执行要插入的所有sql语句
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region 袁杨添加 插入评分消息内容130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//主键
                                string strDoctor_name = "";//管床医生姓名
                                string strDoctor_id = "";//管床医生id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//管床医生姓名赋值
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//管床医生id赋值
                                    }
                                }

                                string strDatetime = App.GetSystemTime().ToString();//获取当前操作时间
                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "本次病例最终得分为" + zongSum;//消息内容
                                }
                                else
                                {
                                    strContent = "运行病历有缺陷请修改";//运行病历消息内容
                                }
                                string strInsertSql = @"insert into t_msg_info
                                              (id,
                                               pid,
                                               patient_name,
                                               receive_user_id,
                                               receive_user_name,
                                               operator_user_id,
                                               operator_user_name,
                                               type_id,
                                               type_name,
                                               content_id,
                                               content,
                                               add_time,
                                               msg_status,
                                               dispose_time,
                                               flag,
                                               reply_msg,
                                               isreply,
                                               reply_flag,
                                               type_id_cy,
                                               type_name_cy,
                                               operator_user_sender,
                                               section_target,
                                               warn_type,
                                               read_flag)
                                            values
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','病案评分','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("保存成功");
                                    //每次保存一次都要清空一次
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("保存失败");
                                list.Clear();
                                return;
                            }
                        }
                    }
                    if (strMark == "2")
                    {
                        if (fmgrSection == null)
                        {
                            #region 修改消息信息 袁杨添加130724
                            string strDatetimeU = App.GetSystemTime().ToString();//获取当前操作时间
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "本次病例最终得分为" + zongSum;//消息内容
                            }
                            else
                            {
                                strContentU = "运行病历有缺陷请修改";//运行病历消息内容
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //把所有的评分项目的插入语句用list保存起来
                            //fmgr.addPingFen(list);

                            //执行要插入的所有sql语句
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region 袁杨添加 插入评分消息内容130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//主键
                                string strDoctor_name = "";//管床医生姓名
                                string strDoctor_id = "";//管床医生id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//管床医生姓名赋值
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//管床医生id赋值
                                    }
                                }
                                string strDatetime = App.GetSystemTime().ToString();//获取当前操作时间

                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "本次病例最终得分为" + zongSum;//消息内容
                                }
                                else
                                {
                                    strContent = "运行病历有缺陷请修改";//运行病历消息内容
                                }
                                string strInsertSql = @"insert into t_msg_info
                                              (id,
                                               pid,
                                               patient_name,
                                               receive_user_id,
                                               receive_user_name,
                                               operator_user_id,
                                               operator_user_name,
                                               type_id,
                                               type_name,
                                               content_id,
                                               content,
                                               add_time,
                                               msg_status,
                                               dispose_time,
                                               flag,
                                               reply_msg,
                                               isreply,
                                               reply_flag,
                                               type_id_cy,
                                               type_name_cy,
                                               operator_user_sender,
                                               section_target,
                                               warn_type,
                                               read_flag)
                                            values
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','病案评分','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("保存成功");
                                    //每次保存一次都要清空一次
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("保存失败");
                                list.Clear();
                                return;
                            }
                        }
                    }
                    if (strMark == "3")
                    {
                        if (fmgrDoctor == null)
                        {
                            #region 修改消息信息 袁杨添加130724
                            string strDatetimeU = App.GetSystemTime().ToString();//获取当前操作时间
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "本次病例最终得分为" + zongSum;//消息内容
                            }
                            else
                            {
                                strContentU = "运行病历有缺陷请修改";//运行病历消息内容
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //把所有的评分项目的插入语句用list保存起来
                            //fmgr.addPingFen(list);

                            //执行要插入的所有sql语句
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region 袁杨添加 插入评分消息内容130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//主键
                                string strDoctor_name = "";//管床医生姓名
                                string strDoctor_id = "";//管床医生id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//管床医生姓名赋值
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//管床医生id赋值
                                    }
                                }
                                string strDatetime = App.GetSystemTime().ToString();//获取当前操作时间

                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "本次病例最终得分为" + zongSum;//消息内容
                                }
                                else
                                {
                                    strContent = "运行病历有缺陷请修改";//运行病历消息内容
                                }
                                string strInsertSql = @"insert into t_msg_info
                                              (id,
                                               pid,
                                               patient_name,
                                               receive_user_id,
                                               receive_user_name,
                                               operator_user_id,
                                               operator_user_name,
                                               type_id,
                                               type_name,
                                               content_id,
                                               content,
                                               add_time,
                                               msg_status,
                                               dispose_time,
                                               flag,
                                               reply_msg,
                                               isreply,
                                               reply_flag,
                                               type_id_cy,
                                               type_name_cy,
                                               operator_user_sender,
                                               section_target,
                                               warn_type,
                                               read_flag)
                                            values
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','病案评分','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("保存成功");
                                    //每次保存一次都要清空一次
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("保存失败");
                                list.Clear();
                                return;
                            }
                        }
                    }
                    this.Close();
                    #endregion
                    save_doc();
                }
                catch (Exception ex)
                {
                    App.MsgErr("请确定评分项与文书类型是否一致，以及书写都正确！错误原因：" + ex.Message);
                }
            }
        }


        private void save_doc()
        {
            DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
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
            else
            {
                App.MsgWaring("没有打开的文书！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnConfirm.Visible)
            {
                string del_sql = "delete t_deduct_score where item_patientid='" + patientId + "'";
                App.ExecuteSQL(del_sql);
            }
            this.Close();
        }




        private void c1FlexGrid1_bingchengjilu_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_bingchengjilu.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_bingchengjilu[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_bingchengjilu[rows, "扣分"].ToString()))
            //        {
            //            c1FlexGrid1_bingchengjilu[rows, "扣分"] = c1FlexGrid1_bingchengjilu[rows, "单项分值"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_bingchengjilu[rows, "扣分"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_ruYuanJilu_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_ruYuanJilu.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_ruYuanJilu[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_ruYuanJilu[rows, "扣分"].ToString()))
            //        {
            //            c1FlexGrid1_ruYuanJilu[rows, "扣分"] = c1FlexGrid1_ruYuanJilu[rows, "单项分值"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_ruYuanJilu[rows, "扣分"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_BingAnShouYe_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;//定义选中的行号

            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_BingAnShouYe[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_BingAnShouYe[rows, "扣分"] = c1FlexGrid1_BingAnShouYe[rows, "单项分值"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_BingAnShouYe[rows, "扣分"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_chuyuansiwang_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_chuyuansiwang[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_chuyuansiwang[rows, "扣分"].ToString()))
            //        {
            //            c1FlexGrid1_chuyuansiwang[rows, "扣分"] = c1FlexGrid1_chuyuansiwang[rows, "单项分值"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_chuyuansiwang[rows, "扣分"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_fuzhujiancha_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_fuzhujiancha[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_fuzhujiancha[rows, "扣分"] = c1FlexGrid1_fuzhujiancha[rows, "单项分值"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_fuzhujiancha[rows, "扣分"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_jibenyaoqiu_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_jibenyaoqiu[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_jibenyaoqiu[rows, "扣分"] = c1FlexGrid1_jibenyaoqiu[rows, "单项分值"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_jibenyaoqiu[rows, "扣分"] = null;
            //    }
            //}
        }
        private void c1FlexGrid1_zhiqingtongyi_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//定义选中的行号
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_zhiqingtongyi[rows, "■"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_zhiqingtongyi[rows, "扣分"] = c1FlexGrid1_zhiqingtongyi[rows, "扣分标准"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_zhiqingtongyi[rows, "扣分"] = null;
            //    }
            //}
        }
        /// <summary>
        /// 左侧双击向右侧添加数据 病案首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_BingAnShouYe_Click(object sender, EventArgs e) //  注意：这里是双击事件，只是名称是click
        {
            try
            {

                int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;
                if (!CheckWS() && c1FlexGrid1_BingAnShouYe[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_BingAnShouYe[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_BingAnShouYe[rows, "扣分"] = c1FlexGrid1_BingAnShouYe[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strBingAnShouYe_PatientID = patientId;
                if (strBingAnShouYe_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strBingAnShouYe_PatientID);//取到病人id
                }
                newRow["评分项目"] = "病案首页";
                if (c1FlexGrid1_BingAnShouYe[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_BingAnShouYe[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_BingAnShouYe[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_BingAnShouYe[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_BingAnShouYe[rows, "ID"];
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_BingAnShouYe[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_BingAnShouYe[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();

            }
            catch
            {


            }
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pingfentoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid2.RowSel > 0)
            {
                int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;
                c1FlexGrid2.Rows.Remove(rows);

            }
        }
        /// <summary>
        /// 删除当前扣分记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid2.RowSel > 0)
            {
                int rows = 0;
                rows = this.c1FlexGrid2.RowSel;
                //rows = c1FlexGrid1_BingAnShouYe.RowSel;
                if (rows >= 0)
                {
                    string mark_id = c1FlexGrid2[rows, "id"].ToString();
                    string sql = "delete t_deduct_score where item_patientid ='" + patientId + "' and id ='" + mark_id + "'";
                    int result = App.ExecuteSQL(sql);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功！");
                        c1FlexGrid2.Rows.Remove(rows);
                    }
                }
                else
                {
                    App.Msg("请选中一行进行删除!");
                }

            }
        }
        /// <summary>
        /// 左侧双击向右侧添加数据 入院记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_ruYuanJilu_Click(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_ruYuanJilu.RowSel;
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_ruYuanJilu[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_ruYuanJilu[rows, "扣分"] = c1FlexGrid1_ruYuanJilu[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                if (!CheckWS() && c1FlexGrid1_ruYuanJilu[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                Row newRow = c1FlexGrid2.Rows.Add();
                string strruYuanJilu_PatientID = patientId;
                if (strruYuanJilu_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strruYuanJilu_PatientID);//取到病人id
                }
                newRow["评分项目"] = "入院记录";
                if (c1FlexGrid1_ruYuanJilu[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_ruYuanJilu[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_ruYuanJilu[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_ruYuanJilu[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_ruYuanJilu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_ruYuanJilu[rows, "ID"];
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_ruYuanJilu[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_ruYuanJilu[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 左侧双击向右侧添加数据 病程记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_bingchengjilu_Click(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_bingchengjilu.RowSel;
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_bingchengjilu[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_bingchengjilu[rows, "扣分"] = c1FlexGrid1_bingchengjilu[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                if (!CheckWS() && c1FlexGrid1_bingchengjilu[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                Row newRow = c1FlexGrid2.Rows.Add();
                string strbingchengjilu_PatientID = patientId;
                if (strbingchengjilu_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strbingchengjilu_PatientID);//取到病人id
                }
                newRow["评分项目"] = "病程记录";
                if (c1FlexGrid1_bingchengjilu[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_bingchengjilu[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_bingchengjilu[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_bingchengjilu[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_bingchengjilu[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_bingchengjilu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_bingchengjilu[rows, "ID"];
                }
                if (c1FlexGrid1_bingchengjilu[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_bingchengjilu[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_bingchengjilu[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_bingchengjilu[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 左侧双击向右侧添加数据 出院记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_chuyuansiwang_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;
                if (!CheckWS() && c1FlexGrid1_chuyuansiwang[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_chuyuansiwang[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_chuyuansiwang[rows, "扣分"] = c1FlexGrid1_chuyuansiwang[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strchuyuansiwang_PatientID = patientId;
                if (strchuyuansiwang_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strchuyuansiwang_PatientID);//取到病人id
                }
                newRow["评分项目"] = "出院记录";
                if (c1FlexGrid1_chuyuansiwang[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_chuyuansiwang[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_chuyuansiwang[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_chuyuansiwang[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_chuyuansiwang[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_chuyuansiwang[rows, "ID"];
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_chuyuansiwang[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_chuyuansiwang[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 辅助及检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_fuzhujiancha_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;
                if (!CheckWS() && c1FlexGrid1_fuzhujiancha[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_fuzhujiancha[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_fuzhujiancha[rows, "扣分"] = c1FlexGrid1_fuzhujiancha[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strfuzhujiancha_PatientID = patientId;
                if (strfuzhujiancha_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strfuzhujiancha_PatientID);//取到病人id
                }
                newRow["评分项目"] = "辅助检查";
                if (c1FlexGrid1_fuzhujiancha[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_fuzhujiancha[rows, "扣分标准"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_fuzhujiancha[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_fuzhujiancha[rows, "单项分值"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_fuzhujiancha[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_fuzhujiancha[rows, "ID"];
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_fuzhujiancha[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_fuzhujiancha[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 书写要求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_jibenyaoqiu_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;
                if (!CheckWS() && c1FlexGrid1_jibenyaoqiu[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_jibenyaoqiu[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_jibenyaoqiu[rows, "扣分"] = c1FlexGrid1_jibenyaoqiu[rows, "单项分值"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strjibenyaoqiu_PatientID = patientId;
                if (strjibenyaoqiu_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strjibenyaoqiu_PatientID);//取到病人id
                }
                newRow["评分项目"] = "书写要求";
                if (c1FlexGrid1_jibenyaoqiu[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_jibenyaoqiu[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_jibenyaoqiu[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_jibenyaoqiu[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_jibenyaoqiu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_jibenyaoqiu[rows, "ID"];
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_jibenyaoqiu[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_jibenyaoqiu[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 知情同意书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_zhiqingtongyi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!CheckWS())
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }
                int rows = this.c1FlexGrid1_zhiqingtongyi.RowSel;
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_zhiqingtongyi[rows, "■"].ToString() == "True")
                //    {
                //        c1FlexGrid1_zhiqingtongyi[rows, "扣分"] = c1FlexGrid1_zhiqingtongyi[rows, "扣分标准"];
                //    }
                //    else
                //    {
                //        App.Msg("请先选择扣分项！");
                //        return;
                //    }
                //}

                Row newRow = c1FlexGrid2.Rows.Add();
                string strzhiqingtongyi_PatientID = patientId;
                if (strzhiqingtongyi_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strzhiqingtongyi_PatientID);//取到病人id
                }
                newRow["评分项目"] = "知情同意书";
                if (c1FlexGrid1_zhiqingtongyi[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_zhiqingtongyi[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_zhiqingtongyi[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_zhiqingtongyi[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_zhiqingtongyi[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_zhiqingtongyi[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_zhiqingtongyi[rows, "ID"];
                }

                AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));


                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// 医嘱单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_yizhudan.RowSel;
                if (!CheckWS() && c1FlexGrid1_yizhudan[rows, "主客观分类"].ToString() == "Y")
                {
                    MessageBox.Show("没有打开的文书！");
                    return;
                }

                Row newRow = c1FlexGrid2.Rows.Add();
                string strYIZHUDAN_PatientID = patientId;
                if (strYIZHUDAN_PatientID != "")
                {
                    newRow["病人id"] = Convert.ToInt32(strYIZHUDAN_PatientID);//取到病人id
                }
                newRow["评分项目"] = "医嘱单";
                if (c1FlexGrid1_yizhudan[rows, "单项分值"].ToString() != "")
                {
                    newRow["分值"] = c1FlexGrid1_yizhudan[rows, "单项分值"];
                    newRow["比较分值"] = c1FlexGrid1_yizhudan[rows, "单项分值"];
                }
                else
                {
                    App.Msg("请先选择扣分项！");
                    return;
                }
                if (c1FlexGrid1_yizhudan[rows, "扣分标准"].ToString() != "")
                {
                    newRow["扣分标准"] = c1FlexGrid1_yizhudan[rows, "扣分标准"];
                }
                newRow["扣分理由"] = "";
                if (c1FlexGrid1_yizhudan[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_yizhudan[rows, "ID"];
                }
                if (c1FlexGrid1_yizhudan[rows, "主客观分类"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_yizhudan[rows, "主客观分类"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }

                if (c1FlexGrid1_yizhudan[rows, "主客观分类"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_yizhudan[rows, "主客观分类"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["评分项目"].ToString(), newRow["扣分标准"].ToString(), newRow["分值"].ToString(), newRow["病人id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }

            catch
            {

            }

        }
        private void AddMarkN(string mark_id, string item, string item_con, string item_score, string item_pid, string did)
        {
            string sql = "insert into t_deduct_score (ID,ITEM,ITEM_CONTENT,ITEM_SCORE,ITEM_PATIENTID,MEDICAL_MARK_ID,isxg,ITEM_TYPE) values (" + int.Parse(did)
                + ",'" + item + "','" + item_con + "','" + item_score + "','" + item_pid + "','" + mark_id + "','0','N')";
            int result = App.ExecuteSQL(sql);
        }

        private void AddMark(string mark_id, string item, string item_con, string item_score, string item_pid, string did)
        {
            DevComponents.DotNetBar.TabControl tc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;
            Patient_Doc doc = tc.SelectedTab.Tag as Patient_Doc;
            int docId = doc.Id;
            string sql = "insert into t_deduct_score (ID,ITEM,ITEM_CONTENT,ITEM_SCORE,ITEM_PATIENTID,MEDICAL_MARK_ID,isxg,docid,ITEM_TYPE) values (" + int.Parse(did)
                + ",'" + item + "','" + item_con + "','" + item_score + "','" + item_pid + "','" + mark_id + "','0'," + docId + ",'Y')";
            int result = App.ExecuteSQL(sql);
            if (result > 0)
            {
                string id = did;
                string KFBZ = item_con;
                if (OnBackId != null)
                    OnBackId(id);

                //获取编辑器对象
                //tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0].Name
                //for (int i = 0; i < tabControl1.Tabs.Count; i++)
                //{
                //    if (tabControl1.Tabs[i].Text == "病案查阅")
                //    {
                DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                {
                    frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    frm.MyDoc.InsertBAPF(id, item_con);// 袁杨暂时注释掉
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    frm.MyDoc.ToXML(tempxmldoc.DocumentElement);
                    //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, frm.MyDoc.Us.Tid.ToString() + ".xml", frm.MyDoc.Us.InpatientInfo.Id.ToString());
                    frm.MyDoc.Modified = false;


                    //XmlDocument tempxmldoc2 = new XmlDocument();
                    //tempxmldoc2.PreserveWhitespace = true;
                    //tempxmldoc2.LoadXml("<emrtextdoc/>");
                    //frm.MyDoc.ToXML(tempxmldoc2.DocumentElement);
                    //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, Us.Tid.ToString() + ".xml", Us.InpatientInfo.Id.ToString());                   
                    //String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", frm.MyDoc.Us.Tid.ToString());
                    //MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                    //xmlPars[0] = new MySqlDBParameter();
                    //xmlPars[0].ParameterName = "doc1";
                    //xmlPars[0].Value = tempxmldoc.OuterXml;
                    //xmlPars[0].DBType = MySqlDbType.Text;
                    //App.ExecuteSQL(sql_clob, xmlPars);


                }
                else
                {
                    App.MsgWaring("没有打开的文书！");
                }
                //    }
            }
            //}
        }

        public void SavePFDocument()
        {

        }

        private bool CheckWS()
        {
            DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
            if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetColor(string newid)
        {
            if (c1FlexGrid2.Rows.Count > 0)
            {
                for (int i = 0; i < c1FlexGrid2.Rows.Count; i++)
                {
                    if (c1FlexGrid2[i, "id"].ToString() == newid)
                    {
                        c1FlexGrid2.Rows[i].StyleNew.BackColor = Color.Red;
                    }
                    else
                    {
                        c1FlexGrid2.Rows[i].StyleNew.BackColor = c1FlexGrid2.BackColor;
                    }
                }
            }
        }
        public void DeleteRow(string newid)
        {
            if (c1FlexGrid2.RowSel > 0)
            {

                string sql = "delete t_deduct_score where id ='" + newid + "'";
                int result = App.ExecuteSQL(sql);
                if (result > 0)
                {
                    MessageBox.Show("删除成功！");
                    DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                    if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                    {
                        frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                        //frm.MyDoc.InsertBAPF(id, item_con);// 袁杨暂时注释掉
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml("<emrtextdoc/>");
                        frm.MyDoc.ToXML(tempxmldoc.DocumentElement);
                        //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, frm.MyDoc.Us.Tid.ToString() + ".xml", frm.MyDoc.Us.InpatientInfo.Id.ToString());
                        frm.MyDoc.Modified = false;


                        //XmlDocument tempxmldoc2 = new XmlDocument();
                        //tempxmldoc2.PreserveWhitespace = true;
                        //tempxmldoc2.LoadXml("<emrtextdoc/>");
                        //frm.MyDoc.ToXML(tempxmldoc2.DocumentElement);
                        //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, Us.Tid.ToString() + ".xml", Us.InpatientInfo.Id.ToString());                   
                        //String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", frm.MyDoc.Us.Tid.ToString());
                        //MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                        //xmlPars[0] = new MySqlDBParameter();
                        //xmlPars[0].ParameterName = "doc1";
                        //xmlPars[0].Value = tempxmldoc.OuterXml;
                        //xmlPars[0].DBType = MySqlDbType.Text;
                        //App.ExecuteSQL(sql_clob, xmlPars);


                    }
                    else
                    {
                        App.MsgWaring("没有打开的文书！");
                    }
                    SetKouFenHuiZong();
                }
            }
        }

        private void btnZC_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
            {
                #region 修改后的数据
                int deductid = int.Parse(c1FlexGrid2[i, "id"].ToString());
                string fz = c1FlexGrid2[i, "分值"].ToString();
                string ly = c1FlexGrid2[i, "扣分理由"].ToString();

                string sql = "update t_deduct_score set item_score ='" + fz + "',item_reason ='" + ly + "' where id =" + deductid;
                int a = App.ExecuteSQL(sql);
                #endregion
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rows = this.c1FlexGrid2.RowSel;
            if (rows > 0)
            {

                if (c1FlexGrid2[rows, "item_type"].ToString() == "N")
                {
                    if (c1FlexGrid2.RowSel > 0)
                    {
                        //rows = c1FlexGrid1_BingAnShouYe.RowSel;
                        if (rows >= 0)
                        {
                            string id = c1FlexGrid2[rows, "id"].ToString();
                            string sql = "delete t_deduct_score where id ='" + id + "'";
                            int result = App.ExecuteSQL(sql);
                            if (result > 0)
                            {
                                App.Msg("删除成功！");
                                c1FlexGrid2.Rows.Remove(rows);
                            }
                        }
                        else
                        {
                            App.Msg("请选中一行进行删除!");
                        }

                    }
                }
                else
                {
                    App.Msg("请在文书内删除!");
                }
            }
        }



        private void c1FlexGrid2_MouseDown(object sender, MouseEventArgs e)
        {
            int rows = c1FlexGrid2.MouseRow;
            if (rows > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (c1FlexGrid2[rows, "item_type"].ToString() == "N")
                    {
                        c1FlexGrid2.ContextMenuStrip = contextMenuStrip1;
                    }
                    else
                    {
                        c1FlexGrid2.ContextMenuStrip = null;
                    }

                }
            }
        }

        private void c1FlexGrid2_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void c1FlexGrid2_BeforeEdit(object sender, RowColEventArgs e)
        {

        }

        private void c1FlexGrid2_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid2.RowSel;
                strMark_after = c1FlexGrid2[rows, "分值"].ToString();
                strMark_before = c1FlexGrid2[rows, "比较分值"].ToString();
                if (Convert.ToDouble(strMark_after) > Convert.ToDouble(strMark_before))
                {

                    App.Msg("当前修改后的分值已经超出最大分值,请重新修改！");
                    c1FlexGrid2[rows, "分值"] = c1FlexGrid2[rows, "比较分值"];
                    return;

                }

                string kfbz = c1FlexGrid2[rows, "扣分标准"].ToString();
                string kfly = c1FlexGrid2[rows, "扣分理由"].ToString();
                string id = c1FlexGrid2[rows, "ID"].ToString();

                DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                {
                    frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    //frm.MyDoc.InsertBAPF(id, kfbz + "\n扣分理由：\n" + "    " + kfly);// 袁杨暂时注释掉
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    frm.MyDoc.ToXML(tempxmldoc.DocumentElement);

                    XmlNode bapf_xnl = tempxmldoc.SelectSingleNode("//bapf[@value=\"" + id + "\"]");

                    bapf_xnl.Attributes["sign"].Value = kfbz + "\n扣分理由：\n" + "    " + kfly;


                    //App.UpLoadFtpPatientDoc(tempxmldoc.OuterXml, frm.MyDoc.Us.Tid.ToString() + ".xml", frm.MyDoc.Us.InpatientInfo.Id.ToString());
                    frm.MyDoc.Modified = false;

                    frm.MyDoc.FromXML(tempxmldoc.DocumentElement);

                    //XmlDocument tempxmldoc2 = new XmlDocument();
                    //tempxmldoc2.PreserveWhitespace = true;
                    //tempxmldoc2.LoadXml("<emrtextdoc/>");
                    //frm.MyDoc.ToXML(tempxmldoc2.DocumentElement);
                    //String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", frm.MyDoc.Us.Tid.ToString());
                    //MySqlDBParameter[] xmlPars = new MySqlDBParameter[1];
                    //xmlPars[0] = new MySqlDBParameter();
                    //xmlPars[0].ParameterName = "doc1";
                    //xmlPars[0].Value = tempxmldoc.OuterXml;
                    //xmlPars[0].DBType = MySqlDbType.Text;
                    //App.ExecuteSQL(sql_clob, xmlPars);

                }
                else
                {
                    App.MsgWaring("没有打开的文书！");
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid2_Leave(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_jibenyaoqiu_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_ruYuanJilu_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_bingchengjilu_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_zhiqingtongyi_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_fuzhujiancha_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_yizhudan_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_chuyuansiwang_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid1_BingAnShouYe_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6)
            {
                e.Cancel = true;
                return;
            }
        }

        private void c1FlexGrid2_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 2 || e.Col == 5)
            {
                e.Cancel = true;
                return;
            }
        }

        private void tabControl4_Click(object sender, EventArgs e)
        {

        }

        private void expandableSplitter1_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {

        }

        /// <summary>
        /// 查看LIS信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLis_Click(object sender, EventArgs e)
        {
            FrmLis fc = new FrmLis(this.pid);
            fc.WindowState = FormWindowState.Normal;
            fc.Show();
        }

        //查看PACS信息
        private void btnPacs_Click(object sender, EventArgs e)
        {
            InPatientInfo inpat = DataInit.GetInpatientInfoByPid(this.patientId);
            Base_Function.BLL_DOCTOR.HisInStance.frm_Pasc fc = new Base_Function.BLL_DOCTOR.HisInStance.frm_Pasc(inpat);
            fc.Show();
        }

        private void btnYZ_Click(object sender, EventArgs e)
        {
            InPatientInfo inpat = DataInit.GetInpatientInfoByPid(this.patientId);
            frmYZ fc = new frmYZ(inpat);
            fc.Show();
        }

        private void frmGrade_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btnConfirm.Visible)
            {
                string del_sql = "delete t_deduct_score where item_patientid='" + patientId + "'";
                App.ExecuteSQL(del_sql);
            }
        }

    }
}