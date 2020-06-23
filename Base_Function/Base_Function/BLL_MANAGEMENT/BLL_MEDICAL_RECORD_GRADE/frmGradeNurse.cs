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
 
using Base_Function.BLL_DOCTOR;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 主观评分（护理）
    /// </summary>
    public partial class frmGradeNurse : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmMainGradeRepart fmgr;
        ucfrmMainGradeRepartDoctor fmgrDoctor;
        ucfrmMainGradeRepartSection fmgrSection;
        frmMainSelectHistoryRepart fmshr;
        string pid = "";
        string suffName = "";
        string patientId = "";

        string pingfenId = "";//获取他的评分ID
        string pingfenTime = "";//获取他的评分时间
        string pingfenName = "";//获取他的评审人
        //string item_Id = "";//获取他每一项的ID

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        public frmGradeNurse(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            pid = fmgr.SetPingfen();
            patientId = fmgr.SetPatientID();
            suffName = fmgr.SetSuffererName();
            this.Text = "给 " + suffName + " 主观评分";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            //SetTongyiShu();

        }
        public frmGradeNurse(ucfrmMainGradeRepartDoctor _fmgrDoctor)
        {
            InitializeComponent();
            this.fmgrDoctor = _fmgrDoctor;
            pid = fmgr.SetPingfen();
            patientId = fmgr.SetPatientID();
            suffName = fmgr.SetSuffererName();
            this.Text = "给 " + suffName + " 主观评分";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            //SetTongyiShu();

        }
        public frmGradeNurse(ucfrmMainGradeRepartSection _fmgrSection)
        {
            InitializeComponent();
            this.fmgrSection = _fmgrSection;
            pid = fmgrSection.SetPingfen();//fmgr
            patientId = fmgrSection.SetPatientID();
            suffName = fmgrSection.SetSuffererName();
            this.Text = "给 " + suffName + " 主观评分";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            //SetTongyiShu();

        }
        public frmGradeNurse(frmMainSelectHistoryRepart _fmshr)
        {
            InitializeComponent();
            this.fmshr = _fmshr;

            pingfenId = fmshr.SetPingFenID();//获取他的评分ID
            patientId = fmshr.SetPatientID();
            pingfenTime = fmshr.SetPingFenTimeNurse();//获取他的评分时间
            pingfenName = fmshr.SetPingFenNameNurse();//获取他的评审人
            //item_Id = fmshr.SetPingFenItem_ID();//获取他每一项的ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "评审人:" + pingfenName + "    评审时间:" + pingfenTime;

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            //SetTongyiShu();
            SetKouFen();
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
            string selectItemIDSQL = "select item_id,down_point from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "' and emptype = 'N'";
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
                //for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                //{
                //    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                //    {
                //        c1FlexGrid1_zhiqingtongyi[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                //        c1FlexGrid1_zhiqingtongyi[j, "■"] = "TRUE";
                //    }
                //}
            }
        }
        /// <summary>
        /// 设置病案首页类容
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8885' order by t.code asc";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_BingAnShouYe.Cols["理由"].Width = 222;
            this.c1FlexGrid1_BingAnShouYe.Cols["■"].Width = 20;

            this.c1FlexGrid1_BingAnShouYe.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_BingAnShouYe.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置入院记录
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8886' order by t.code asc";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_ruYuanJilu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_ruYuanJilu.Cols["理由"].Width = 222;
            this.c1FlexGrid1_ruYuanJilu.Cols["■"].Width = 20;

            this.c1FlexGrid1_ruYuanJilu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_ruYuanJilu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置病程记录
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8887' order by t.code asc";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_bingchengjilu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_bingchengjilu.Cols["理由"].Width = 222;
            this.c1FlexGrid1_bingchengjilu.Cols["■"].Width = 20;

            this.c1FlexGrid1_bingchengjilu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_bingchengjilu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置基本要求及医嘱单
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8884' order by t.code asc";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_jibenyaoqiu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_jibenyaoqiu.Cols["理由"].Width = 222;
            this.c1FlexGrid1_jibenyaoqiu.Cols["■"].Width = 20;

            this.c1FlexGrid1_jibenyaoqiu.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_jibenyaoqiu.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置出院（死亡）记录
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8888' order by t.code asc";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_chuyuansiwang.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_chuyuansiwang.Cols["理由"].Width = 222;
            this.c1FlexGrid1_chuyuansiwang.Cols["■"].Width = 20;

            this.c1FlexGrid1_chuyuansiwang.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_chuyuansiwang.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置辅助检查
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select t.id as ID,t.name as 评分分类,t.check_req as 检查要求,t.deduct_stand as 扣分标准,t.deduct_score as 单项分值,t.type as 主客观分类 from T_MEDICAL_MARK t where t.type_id = '8889' order by t.code asc";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("■", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["扣分标准"].Width = 350;
            this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_fuzhujiancha.Cols["理由"].Width = 222;
            this.c1FlexGrid1_fuzhujiancha.Cols["■"].Width = 20;

            this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_fuzhujiancha.Cols["评分分类"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["检查要求"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["主客观分类"].Visible = false;
        }
        /// <summary>
        ///设置知情同意
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select ID as ID,name as 项目 from t_data_code where type=63";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["项目"].Width = 440;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_zhiqingtongyi.Cols["理由"].Width = 65;

        }


        private void frmGrade_Load(object sender, EventArgs e)
        {
            //病案查阅
            InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patientId);
            Base_Function.BASE_COMMON.DataInit.isRightRun = true;
            ucDoctorOperater fq = new ucDoctorOperater(inPatient);
            fq.Dock = DockStyle.Fill;
            App.UsControlStyle(fq);
            this.panel10.Controls.Add(fq);
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            /*
             * 循环每个c1控件扣分的值然后用100-扣分值 就是评分后的总分。
             */
            #region 总分
            double bingansum = 0;
            //把病案首页扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString() != "")
                {
                    bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString());//扣分项分值
                }
            }
            double ruyuanSum = 0;
            //把入院记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString() != "")
                {
                    ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString());//扣分项分值
                }
            }
            double bingchengSum = 0;
            //把病程记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, "扣分"].ToString() != "")
                {
                    bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, "扣分"].ToString());//扣分项分值
                }
            }
            double jibenyaojiuSum = 0;
            //把基本要求及医嘱单扣的总分算出来
            //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString() != "")
            //    {
            //        jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString());//扣分项分值
            //    }
            //}
            double chuyuanSiwangSum = 0;
            //把出院（死亡）记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString() != "")
                {
                    chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString());//扣分项分值
                }
            }
            double fuzhujianchaSum = 0;
            //把辅助检查扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, "扣分"].ToString() != "")
                {
                    fuzhujianchaSum += Convert.ToDouble(c1FlexGrid1_fuzhujiancha[i, "扣分"].ToString());//扣分项分值
                }
            }
            double zhiqingtongyiSum = 0;
            //把知情同意扣的总分算出来
            //for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_zhiqingtongyi[i, "扣分"].ToString() != "")
            //    {
            //        zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid1_zhiqingtongyi[i, "扣分"].ToString());//扣分项分值
            //    }
            //}


            //扣分调整
            if (bingansum > 15) bingansum = 15;
            if (ruyuanSum > 20) ruyuanSum = 20;
            if (bingchengSum > 15) bingchengSum = 15;
            if (chuyuanSiwangSum > 30) chuyuanSiwangSum = 30;
            if (fuzhujianchaSum > 20) fuzhujianchaSum = 20;

            double zongSum = 100 - (bingansum + ruyuanSum + bingchengSum + jibenyaojiuSum + chuyuanSiwangSum + fuzhujianchaSum + zhiqingtongyiSum);
            if (fmshr == null)
            {
                //fmgr.SetFenzhiNurse(zongSum);
            }
            else
            {
                fmshr.SetFenzhiNurse(zongSum);
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

                if (pingfenId == "" && pid != "")
                {
                    insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                "','" + dosName + "','" + zongSum + "'," + time + ",'N')";

                    list.Add(insertupdateSQL);
                }
                else
                {
                    string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                    "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                "','" + binganKoufen + "','" + binganLiyou + "',56,'" + dosID +
                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                    if (App.ExecuteSQL(insert) > 0)
                        this.Close();
                }

            }
            //循环病案首页的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_BingAnShouYe[i, "ID"].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_BingAnShouYe[i, "扣分"].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_BingAnShouYe[i, "理由"].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名 
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',101,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',101,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }
            //if (App.ExecuteBatch(list.ToArray()) > 0)
            //{
            //    App.Msg("评分成功");
            //}


            //循环入院记录的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_ruYuanJilu[i, "ID"].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_ruYuanJilu[i, "扣分"].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_ruYuanJilu[i, "理由"].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',102,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',102,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环病程记录的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, "扣分"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_bingchengjilu[i, "ID"].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_bingchengjilu[i, "扣分"].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_bingchengjilu[i, "理由"].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',103,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',103,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环基本要求及医嘱单的每一项添加到表里面
            //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString() != "")
            //    {
            //        string binganID = c1FlexGrid1_jibenyaoqiu[i, "ID"].ToString();//扣分项的ID
            //        string binganKoufen = c1FlexGrid1_jibenyaoqiu[i, "扣分"].ToString();//扣分项分值
            //        string binganLiyou = c1FlexGrid1_jibenyaoqiu[i, "理由"].ToString();//扣分原因
            //        string dosID = App.UserAccount.UserInfo.User_id;//医生ID
            //        string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

            //        string insertupdateSQL = "";//定义要执行的sql语句
            //        if (pingfenId == "" && pid != "")
            //        {
            //            insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
            //                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
            //            "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
            //            "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
            //            list.Add(insertupdateSQL);
            //        }
            //        else
            //        {
            //            string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
            //            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
            //        "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
            //        "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
            //            if (App.ExecuteSQL(insert) > 0)
            //                this.Close();
            //        }
            //    }
            //}



            //循环出院（死亡）记录的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_chuyuansiwang[i, "ID"].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_chuyuansiwang[i, "扣分"].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_chuyuansiwang[i, "理由"].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',104,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',104,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环辅助检查的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, "扣分"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_fuzhujiancha[i, "ID"].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_fuzhujiancha[i, "扣分"].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_fuzhujiancha[i, "理由"].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',105,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',105,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环知情同意的每一项添加到表里面
            //for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_zhiqingtongyi[i, "扣分"].ToString() != "")
            //    {
            //        string binganID = c1FlexGrid1_zhiqingtongyi[i, "ID"].ToString();//扣分项的ID
            //        string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, "扣分"].ToString();//扣分项分值
            //        string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, "理由"].ToString();//扣分原因
            //        string dosID = App.UserAccount.UserInfo.User_id;//医生ID
            //        string dosName = App.UserAccount.UserInfo.User_name;//医生姓名

            //        string insertupdateSQL = "";//定义要执行的sql语句
            //        if (pingfenId == "" && pid != "")
            //        {
            //            insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
            //                "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pid + "','" + binganID +
            //            "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
            //            "','" + dosName + "','" + zongSum + "'," + time + ",'N')";
            //            list.Add(insertupdateSQL);
            //        }
            //        else
            //        {
            //            string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
            //            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,emptype) values('" + pingfenId + "','" + binganID +
            //        "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
            //        "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'N') ";
            //            if (App.ExecuteSQL(insert) > 0)
            //                this.Close();
            //        }
            //    }
            //}


            if (fmgr == null)
            {
                return;
            }
            else
            {
                //把所有的评分项目的插入语句用list保存起来
                //fmgr.addPingFen(list);

                //执行要插入的所有sql语句
                if (App.ExecuteBatch(list.ToArray()) > 0)
                {
                    App.Msg("保存成功");
                    //每次保存一次都要清空一次
                    list.Clear();
                }
                else
                {
                    App.Msg("保存失败");
                    list.Clear();
                }
            }
            this.Close();
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void c1FlexGrid1_bingchengjilu_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_bingchengjilu.RowSel;//定义选中的行号

            if (c1FlexGrid1_bingchengjilu[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_bingchengjilu[rows, "扣分"] = c1FlexGrid1_bingchengjilu[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_bingchengjilu[rows, "扣分"] = null;
            }
        }

        private void c1FlexGrid1_ruYuanJilu_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_ruYuanJilu.RowSel;//定义选中的行号

            if (c1FlexGrid1_ruYuanJilu[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_ruYuanJilu[rows, "扣分"] = c1FlexGrid1_ruYuanJilu[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_ruYuanJilu[rows, "扣分"] = null;
            }
        }

        private void c1FlexGrid1_BingAnShouYe_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;//定义选中的行号

            if (c1FlexGrid1_BingAnShouYe[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_BingAnShouYe[rows, "扣分"] = c1FlexGrid1_BingAnShouYe[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_BingAnShouYe[rows, "扣分"] = null;
            }
        }

        private void c1FlexGrid1_chuyuansiwang_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;//定义选中的行号

            if (c1FlexGrid1_chuyuansiwang[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_chuyuansiwang[rows, "扣分"] = c1FlexGrid1_chuyuansiwang[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_chuyuansiwang[rows, "扣分"] = null;
            }
        }

        private void c1FlexGrid1_fuzhujiancha_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;//定义选中的行号

            if (c1FlexGrid1_fuzhujiancha[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_fuzhujiancha[rows, "扣分"] = c1FlexGrid1_fuzhujiancha[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_fuzhujiancha[rows, "扣分"] = null;
            }
        }

        private void c1FlexGrid1_jibenyaoqiu_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//定义选中的行号

            if (c1FlexGrid1_jibenyaoqiu[rows, "■"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_jibenyaoqiu[rows, "扣分"] = c1FlexGrid1_jibenyaoqiu[rows, "单项分值"];
            }
            else
            {
                c1FlexGrid1_jibenyaoqiu[rows, "扣分"] = null;
            }
        }

    }
}